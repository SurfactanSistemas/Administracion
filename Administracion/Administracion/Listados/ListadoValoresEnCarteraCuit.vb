Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient

Public Class ListadoValoresEnCarteraCuit

    Private Sub ListadoValoresEnCarteraCuit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "
        txtCuit.Text = ""

    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
               Handles txtDesdeFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txthastafecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
            Me.txtDesdeFecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txthastafecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtCuit.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    'Private Sub txtcuit_KeyPress(ByVal sender As Object, _
    '               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    '               Handles txtCuit.KeyPress
    '    If e.KeyChar = Convert.ToChar(Keys.Return) Then
    '        e.Handled = True
    '        txtDesdeFecha.Focus()
    '    ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
    '        e.Handled = True
    '        txtCuit.Text = ""
    '    End If
    'End Sub


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        Dim varUno, varDos As String

        Dim varFormula As String
        Dim x As Char = Chr(34)
        Dim varDesdefechaOrd, varHastafechaOrd As String

        varDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        varHastafechaOrd = ordenaFecha(txthastafecha.Text)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Clave, Destino, Estado2 FROM Recibos WHERE Cuit = '" & txtCuit.Text & "' AND FechaOrd2 BETWEEN " & varDesdefechaOrd & " AND " & varHastafechaOrd & " ORDER BY Clave")
        Dim dr As SqlDataReader
        Dim WClave, WDestino, WEstado2

        'Try

        cn.ConnectionString = Proceso._ConectarA
        cn.Open()
        cm.Connection = cn

        dr = cm.ExecuteReader()

        WClave = ""
        WDestino = ""
        WEstado2 = ""

        If dr.HasRows Then

            While dr.Read()

                With dr
                    WClave = Trim(.Item("Clave"))
                    WDestino = IIf(IsDBNull(.Item("Destino")), "", Trim(.Item("Destino")))
                    WEstado2 = IIf(IsDBNull(.Item("Estado2")), "", Trim(.Item("Estado2")))

                    _ActualizarRecibo(WClave, WDestino, WEstado2)
                End With


            End While

        End If

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        'Finally

        '    dr = Nothing
        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try











        varUno = "{Recibos.fechaord2} in " + x + varDesdefechaOrd + x + " to " + x + varHastafechaOrd + x
        varDos = " and {recibos.cuit} in " + x + txtCuit.Text + x + " to " + x + txtCuit.Text + x

        varFormula = varUno + varDos

        Dim viewer As New ReportViewer("Listado de Valores en Cartera por Cuit", Globals.reportPathWithName("listavalorescuitnet.rpt"), varFormula)

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With

    End Sub

    Private Sub _ActualizarRecibo(ByVal wClave As Object, ByVal wDestino As Object, ByVal wEstado2 As Object)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WProveedor, WDesProveedor, WOrden

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            If Trim(UCase(wEstado2)) = "X" AndAlso Microsoft.VisualBasic.Left(Trim(wDestino), 8) <> "Deposito" Then

                WProveedor = ""
                WDesProveedor = ""
                WOrden = ""

                cm.CommandText = "SELECT Proveedor, Orden FROM Pagos WHERE ClaveRecibo = '" & wClave & "'"
                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    With dr
                        WProveedor = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))
                        WOrden = IIf(IsDBNull(.Item("Orden")), "", .Item("Orden"))
                    End With
                    dr.Close()
                End If

                If Trim(WProveedor) <> "" Then

                    cm.CommandText = "SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Trim(WProveedor) & "'"
                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        With dr
                            WDesProveedor = IIf(IsDBNull(.Item("Nombre")), "", .Item("Nombre"))
                        End With
                        dr.Close()
                    End If

                End If

                If Not dr.IsClosed Then dr.Close()

                If Trim(WDesProveedor) <> "" Then
                    wDestino = Microsoft.VisualBasic.Left(Trim(WDesProveedor) & "  O.P.:" & Trim(WOrden), 50)
                End If

            End If

            cm.CommandText = "UPDATE Recibos SET ImpreObserva = '" & wDestino & "' WHERE Clave  = '" & wClave & "'"
            cm.ExecuteNonQuery()


        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar las observaciones de los cheques en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try


    End Sub

    Private Sub txtCuit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuit.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCuit.Text) = "" Then : Exit Sub : End If

            If Not Proceso.CuitValido(Trim(txtCuit.Text)) Then
                Exit Sub
            End If

            txtDesdeFecha.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtCuit.Text = ""
        End If

    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub

    Private Sub ListadoValoresEnCarteraCuit_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesdeFecha.Focus()
    End Sub
End Class