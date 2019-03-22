Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Outlook

Public Class AvisoOPAProveedores

    Private WNoEnviados(,) As String = New String(1000, 2) {}
    Dim WIndiceNoEnviados As Integer = 0

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEntreRango.Click, rbEntreFechas.Click

        txtDesde.Mask = "000000"
        txtHasta.Mask = "000000"

        txtDesde.Text = ""
        txtHasta.Text = ""

        If rbEntreFechas.Checked Then
            txtDesde.Mask = "00/00/0000"
            txtHasta.Mask = "00/00/0000"
            txtDesde.Text = Date.Now.ToString("dd/MM/yyyy")
            txtHasta.Text = txtDesde.Text
        End If

        With txtDesde
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        txtDesde.Text = ""
        txtHasta.Text = ""

        WNoEnviados = New String(1000, 2) {}
        WIndiceNoEnviados = 0

        rbEntreFechas.Checked = True

        RadioButton1_Click(Nothing, Nothing)

    End Sub

    Private Sub AvisoOPAProveedores_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        With txtDesde
            .Focus()
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub AvisoOPAProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Try

            WNoEnviados = New String(1000, 2) {}
            WIndiceNoEnviados = 0

            Dim WParametros As String = "Entre " & txtDesde.Text & " al " & txtHasta.Text

            '
            ' Buscamos los proveedores con OP.
            '
            Dim WOrdenesPago As DataTable = _TraerProveedoresConOP()

            For Each row2 As DataRow In WOrdenesPago.Rows
                With row2
                    Dim WOrden As String = OrDefault(.Item("Orden"), "")

                    If Trim(WOrden) = "" Then Continue For

                    '
                    ' Consultamos la información de la Orden de Pago para determinar si es o no por transferencia.
                    '
                    Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(WOrden)
                    Dim EsPorTransferencia As Boolean = False
                    Dim WTipoOrd As Integer = 0
                    Dim WProveedor As String = ""

                    If WOrdenPago.Rows.Count > 0 Then

                        '
                        ' Si el Tipo2 es 2, tiene una única fila y en Número no tiene cargado datos, asumimos que es por transferencia.
                        '
                        For Each row As DataRow In WOrdenPago.Rows
                            With row

                                Dim WTipo2 = OrDefault(.Item("Tipo2"), "00")

                                Select Case Val(WTipo2)
                                    Case 2

                                        If WOrdenPago.Rows.Count = 1 Then
                                            EsPorTransferencia = Val(OrDefault(.Item("Numero2"), "")) = 0
                                        Else
                                            EsPorTransferencia = False
                                        End If

                                    Case Else
                                        EsPorTransferencia = False
                                End Select


                            End With
                        Next

                        With WOrdenPago.Rows(0)

                            WProveedor = OrDefault(.Item("Proveedor"), "")

                            If Trim(WProveedor) <> "" Then

                                _EnviarAvisoOPDisponible(WProveedor, WOrden, EsPorTransferencia)

                            End If

                        End With

                    End If

                End With
            Next

            If WIndiceNoEnviados > 0 Then
                MsgBox("Hay Proveedores a los que no se pudieron enviar el Aviso debido a que no tienen informado una Casilla de Mail a dónde enviar el mismo.", MsgBoxStyle.Information)

                Dim tabla As DataTable = New DBAuxi.AvisosNoEnviadosDataTable

                For i = 1 To WIndiceNoEnviados
                    If Trim(WNoEnviados(i, 0)) <> "" Then

                        Dim r As DataRow = tabla.NewRow

                        r.Item("Id") = i
                        r.Item("Proveedor") = WNoEnviados(i, 0)
                        r.Item("OrdenPago") = WNoEnviados(i, 1)
                        r.Item("DescProveedor") = _TraerDescProveedor(r.Item("Proveedor"))
                        r.Item("Parámetro") = WParametros

                        tabla.Rows.Add(r)

                    End If
                Next

                Dim rpt As New AvisosNoEnviados
                rpt.SetDataSource(tabla)

                With VistaPrevia
                    .Reporte = rpt
                    .Mostrar()
                End With

            End If

        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function _TraerDescProveedor(ByVal Proveedor As Object) As String

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return UCase(Trim(OrDefault(dr.Item("Nombre"), "")))

            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""

    End Function

    Private Function _TraerDatosOrdenPago(ByVal OrdenPago As String) As DataTable

        Dim tabla As New DataTable

        Using cn As New SqlConnection

            cn.ConnectionString = _ConectarA()
            cn.Open()

            Using cm As New SqlCommand()
                cm.Connection = cn
                cm.CommandText = "SELECT Proveedor, Tipo2, Importe2, Numero2, Importe FROM Pagos WHERE Orden = '" & OrdenPago & "' and TipoReg IN ('02', '2')"

                Using dr As SqlDataReader = cm.ExecuteReader

                    If dr.HasRows Then
                        tabla.Load(dr)
                    End If

                End Using
            End Using
        End Using

        Return tabla

    End Function

    Private Function _TraerProveedoresConOP() As DataTable
        Dim WTabla As New DataTable
        Dim WFiltro As String = ""

        If rbEntreFechas.Checked Then
            Dim WDesdeOrd As String = ordenaFecha(txtDesde.Text)
            Dim WHastaOrd As String = ordenaFecha(txtHasta.Text)

            WFiltro = " FechaOrd BETWEEN '" & WDesdeOrd & "' And '" & WHastaOrd & "' "

        Else

            WFiltro = " Orden BETWEEN '" & txtDesde.Text & "' And '" & txtHasta.Text & "' "

        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT Proveedor, Orden FROM Pagos WHERE Proveedor <> '' And TipoOrd IN ('1', '4', '5') And " & WFiltro & " ")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                WTabla.Load(dr)
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar los Proveedores con OP." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTabla
    End Function

    Private Function _TraerProveedoresTransferencia() As DataTable
        Dim WTabla As New DataTable
        Dim WFiltro As String = ""

        If rbEntreFechas.Checked Then
            Dim WDesdeOrd As String = ordenaFecha(txtDesde.Text)
            Dim WHastaOrd As String = ordenaFecha(txtHasta.Text)

            WFiltro = " FechaOrd BETWEEN '" & WDesdeOrd & "' And '" & WHastaOrd & "' "

        Else

            WFiltro = " Orden BETWEEN '" & txtDesde.Text & "' And '" & txtHasta.Text & "' "

        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT Proveedor, Orden FROM Pagos WHERE Proveedor <> '' And TipoOrd IN ('1', '4', '5') And " & WFiltro & " ")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                WTabla.Load(dr)
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar los Proveedores con OP." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTabla
    End Function

    Private Function _TraerProveedoresNoTransferencia() As DataTable
        Dim WTabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT Proveedor FROM Pagos WHERE Proveedor <> '' And ISNULL(AvisoMailOp, '') = '1'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                WTabla.Load(dr)
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar los Proveedores con OP que no sean Transferencia." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTabla
    End Function

    Private Sub _EnviarAvisoOPDisponible(ByVal Proveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False)

        If Proveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Dim WMailOp As String = dr.Item("MailOp")

                If WMailOp.Trim = "" Then
                    WIndiceNoEnviados += 1
                    WNoEnviados(WIndiceNoEnviados, 0) = Proveedor
                    WNoEnviados(WIndiceNoEnviados, 1) = OrdenPago
                    Exit Sub
                End If

                Dim WBody = ""

                If EsPorTransferencia Then
                    WBody = "Acercamos a usted la Orden de Pago " & OrdenPago
                Else
                    WBody = "Se encuentra disponible una Orden de Pago para ser retirada por la recepción de nuestras oficinas."
                End If

                Dim WAdjuntos As New List(Of String)

                If EsPorTransferencia Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        Throw New System.Exception("No existe el archivo " & wAdjunto)
                    End If
                Next

                _EnviarEmail(WMailOp, "", "Orden de Pago - SURFACTTAN S.A - ", WBody, WAdjuntos.ToArray)

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

    Private Function _PrepararAdjuntos(ByVal ordenPago As String) As List(Of String)
        Dim WAdjuntos As New List(Of String)

        If Val(ordenPago) <> 0 Then

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Orden FROM Pagos WHERE Orden = '" & ordenPago & "' And Renglon IN ('01', '1')")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = Proceso._ConectarA
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
        Dim _Outlook As New Microsoft.Office.Interop.Outlook.Application

        Try
            Dim _Mail As MailItem = _Outlook.CreateItem(OlItemType.olMailItem)

            With _Mail

                .To = _to
                .BCC = _bcc
                .Subject = _subject
                .Body = _body

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


    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Or (rbEntreFechas.Checked And txtDesde.Text.Replace(" ", "").Length < 10) Then : Exit Sub : End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Or (rbEntreFechas.Checked And txtHasta.Text.Replace(" ", "").Length < 10) Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

End Class