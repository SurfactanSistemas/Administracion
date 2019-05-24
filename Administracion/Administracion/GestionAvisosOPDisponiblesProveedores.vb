Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Outlook

Public Class GestionAvisosOPDisponiblesProveedores

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        rbAnticipos.Checked = True
        dgvPagos.Rows.Clear()
        txtFecha.Focus()
    End Sub

    Private Sub GestionAvisosOPDisponiblesProveedores_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub GestionAvisosOPDisponiblesProveedores_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtFecha.Focus()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click

        If dgvPagos.Rows.Count > 0 AndAlso MsgBox("¿Está seguro de querer salir? Se perderán todos los cambios realizados.", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        Close()

    End Sub

    Private Sub btnTraerPagos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTraerPagos.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            '
            ' Armamos la consulta según los parámetros indicados.
            '
            Dim ZSql As String = "SELECT op.Orden, op.Proveedor, op.TipoOrd, p.Nombre FROM Pagos op INNER JOIN Proveedor p ON p.Proveedor = op.Proveedor WHERE op.Fecha = '" & txtFecha.Text & "' And ISNULL(op.AvisoMailOp, '0') = '0' And op.Renglon IN ('1', '01') And isnull(p.MailOp, '') <> '' "

            If Not rbTodos.Checked Then

                If rbAnticipos.Checked Then ZSql &= " And op.TipoOrd IN ('2', '02')"

                If rbCtaCtes.Checked Then ZSql &= " And op.TipoOrd IN ('1', '01')"

            End If

            cm.CommandText = ZSql & " Order by op.Orden"

            dr = cm.ExecuteReader()

            dgvPagos.Rows.Clear()

            If dr.HasRows Then

                Dim WOrden, WProveedor, WNombre, WTipo, WDescTipo As String

                Do While dr.Read()

                    With dr
                        WOrden = OrDefault(.Item("Orden"), "")
                        WProveedor = OrDefault(.Item("Proveedor"), "")
                        WNombre = OrDefault(.Item("Nombre"), "")
                        WTipo = OrDefault(.Item("TipoOrd"), "")
                        WDescTipo = ""
                        Select Case Val(WTipo)
                            Case 1 ' Cta Cte
                                WDescTipo = "CC"
                            Case 2 ' Anticipos
                                WDescTipo = "AN"
                        End Select

                    End With

                    Dim r = dgvPagos.Rows.Add

                    With dgvPagos.Rows(r)
                        .Cells("Orden").Value = WOrden
                        .Cells("Proveedor").Value = WProveedor
                        .Cells("Nombre").Value = WNombre
                        .Cells("Tipo").Value = WTipo
                        .Cells("DescTipo").Value = WDescTipo
                        .Cells("Enviar").Value = True
                    End With

                Loop
            Else
                MsgBox("No hay Órdenes de Pago que coincidan con los parámetros de búsqueda.", MsgBoxStyle.Information)
                txtFecha.Focus()
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _TraerDatosOrdenPago(ByVal OrdenPago As String) As DataTable

        Dim tabla As New DataTable

        Using cn As New SqlConnection

            cn.ConnectionString = _ConectarA()
            cn.Open()

            Using cm As New SqlCommand()
                cm.Connection = cn
                cm.CommandText = "SELECT p.Proveedor, p.Fecha, pr.Nombre, p.Fecha2, p.Tipo2, p.Importe2, p.Numero2, p.Importe, p.Cuenta FROM Pagos p LEFT OUTER JOIN Proveedor pr ON pr.Proveedor = p.Proveedor WHERE p.Orden = '" & OrdenPago & "' and p.TipoReg IN ('02', '2')"

                Using dr As SqlDataReader = cm.ExecuteReader

                    If dr.HasRows Then
                        tabla.Load(dr)
                    End If

                End Using
            End Using
        End Using

        Return tabla

    End Function

    Private Sub _EnviarAvisoOPDisponible(ByVal ZProveedor As String, ByVal wDescProveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False, Optional ByVal wFechasTransferencias As String = "")

        If ZProveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & ZProveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Dim WMailOp As String = dr.Item("MailOp")

                If Trim(WMailOp) = "" Then Exit Sub

                '
                ' SACAR DESPUES. SOLO PRUEBA.
                '
                ' WMailOp = "sistemas@surfactan.com.ar"

                Dim WBody = ""

                If EsPorTransferencia Then

                    WBody = "Informamos que en el día de la fecha, SURFACTAN S.A. le ha realizado una transferencia"

                    If wFechasTransferencias.Trim <> "" Then WBody &= " a las siguientes fechas: " & wFechasTransferencias

                    WBody &= "." & vbCrLf & vbCrLf & "Adjuntamos Orden de Pago y retenciones si correspondiesen."

                Else
                    WBody = "Informamos que se encuentra a su disposición un pago que podrá ser retirado por nuestras oficinas (Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires) en el horario de 14:00 a 17:00 hs."
                End If

                If Trim(wDescProveedor) <> "" Then
                    WBody = "Sres. " & wDescProveedor.Trim.ToUpper & vbCrLf & vbCrLf & WBody
                End If

                Select Case ZProveedor
                    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912", "10023969933", "10014123562"
                        WBody = WBody & vbCrLf & vbCrLf & "En caso de cualquier consulta, por favor dirigirla a fgmonti@surfactan.com.ar"
                End Select

                Dim WAdjuntos As New List(Of String)

                If EsPorTransferencia Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        Throw New System.Exception("No existe el archivo " & wAdjunto)
                    End If
                Next

                _EnviarEmail(WMailOp, "", "Orden de Pago - SURFACTAN S.A. - ", WBody, WAdjuntos.ToArray)

                _MarcarOPComoEnviada(OrdenPago)

            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _MarcarOPComoEnviada(ByVal OrdenPago As Object)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("UPDATE Pagos SET AvisoMailOp = '1' WHERE Orden = '" & OrdenPago & "'")

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo marcar la Orden de Pago '" & OrdenPago & "' como 'ENVIADA'." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _PrepararAdjuntos(ByVal ordenPago As String) As List(Of String)
        Dim WAdjuntos As New List(Of String)

        If Val(ordenPago) <> 0 Then

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM Pagos WHERE Orden = '" & ordenPago & "' And Renglon IN ('01', '1')")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = _ConectarA()
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    With New Pagos
                        .WindowState = FormWindowState.Minimized
                        .GenerarPDF = True
                        .Show(Me)
                        .txtOrdenPago.Text = ordenPago
                        .txtOrdenPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        .btnImprimir.PerformClick()
                        .Close()
                    End With

                    For Each o As String In Directory.GetFiles("C:/ImpreOrdenPagoTemp", ordenPago & "OrdenPago*")
                        WAdjuntos.Add(o)
                    Next
                    'WAdjuntos.Add("C:/ImpreOrdenPagoTemp/" & ordenPago & "OrdenPago.pdf")

                End If

            Catch ex As System.Exception
                Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        End If

        Return WAdjuntos
    End Function

    Private Sub _EnviarEmail(ByVal _to As String, ByVal _bcc As String, ByVal _subject As String, ByVal _body As String, ByVal _adjuntos() As String)
        Dim _Outlook As New Application

        Try
            Dim _Mail As MailItem = _Outlook.CreateItem(OlItemType.olMailItem)

            With _Mail

                .To = _to
                .BCC = _bcc
                .Subject = _subject
                .Body = _body
                '.HTMLBody = _body & vbCrLf & vbCrLf & .HTMLBody

                For Each adjunto As String In _adjuntos
                    If Trim(adjunto) <> "" Then
                        .Attachments.Add(adjunto)
                    End If
                Next

                .Send()
                '.Display()

            End With

            _Mail = Nothing

        Catch ex As System.Exception
            Throw New System.Exception("Ocurrió un problema al querer enviar Aviso de Orden de Pago disponible." & vbCrLf & vbCrLf & " Motivo: " & ex.Message)
        Finally
            _Outlook = Nothing
        End Try

    End Sub


    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = dgvPagos.Rows.Count + 1

        For Each row2 As DataGridViewRow In dgvPagos.Rows
            Dim WFechasTransferencias As String = ""
            With row2
                Dim WOrden As String = OrDefault(.Cells("Orden").Value, "")
                Dim WEnviar As Boolean = OrDefault(.Cells("Enviar").Value, False)

                If Trim(WOrden) = "" Then Continue For

                If Not WEnviar Then
                    _MarcarOPComoEnviada(WOrden)
                    Continue For
                End If

                ProgressBar1.Increment(1)

                '
                ' Consultamos la información de la Orden de Pago para determinar si es o no por transferencia.
                '
                Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(WOrden)
                Dim EsPorTransferencia As Boolean = False
                Dim WProveedor As String = ""

                If WOrdenPago.Rows.Count > 0 Then

                    For Each row As DataRow In WOrdenPago.Rows

                        With row

                            Dim WTipo2 = OrDefault(.Item("Tipo2"), "00")

                            Select Case Val(WTipo2)
                                Case 2

                                    EsPorTransferencia = Val(OrDefault(.Item("Numero2"), "")) = 0

                                    If EsPorTransferencia And Not WFechasTransferencias.Contains(OrDefault(.Item("Fecha2"), "")) Then
                                        WFechasTransferencias &= OrDefault(.Item("Fecha2"), "") & ","
                                    End If

                                Case 6 ' Compensación entre Cuentas Corrientes.
                                    EsPorTransferencia = Val(OrDefault(.Item("Cuenta"), "00")) = 5

                                    If EsPorTransferencia And Not WFechasTransferencias.Contains(OrDefault(.Item("Fecha2"), "")) Then
                                        WFechasTransferencias &= OrDefault(.Item("Fecha2"), "") & ","
                                    End If

                                    If EsPorTransferencia Then Exit For
                                Case Else
                                    EsPorTransferencia = False
                            End Select


                        End With
                    Next

                    With WOrdenPago.Rows(0)

                        WProveedor = OrDefault(.Item("Proveedor"), "")
                        Dim WDescProveedor = OrDefault(.Item("Nombre"), "")

                        If Trim(WProveedor) <> "" Then

                            WFechasTransferencias = WFechasTransferencias.TrimEnd(",")

                            _EnviarAvisoOPDisponible(WProveedor, WDescProveedor, WOrden, EsPorTransferencia, WFechasTransferencias)

                        End If

                    End With

                End If

            End With

        Next

        ProgressBar1.Value = 0

        btnLimpiar_Click(Nothing, Nothing)

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFecha.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            btnTraerPagos_Click(Nothing, Nothing)

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Sub rbAnticipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.Click, rbCtaCtes.Click, rbAnticipos.Click
        btnTraerPagos_Click(Nothing, Nothing)
    End Sub
End Class