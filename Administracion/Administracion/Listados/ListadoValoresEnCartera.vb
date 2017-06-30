Imports ClasesCompartidas
Imports System.IO

Public Class ListadoValoresEnCartera

    Private Sub ListadoValoresEnCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAyuda.Text = ""
        txtFecha1.Text = "  /  /    "
        txtFecha2.Text = "  /  /    "
        txtFecha3.Text = "  /  /    "
        txtFecha4.Text = "  /  /    "
        txtDesdeFecha.Text = "  /  /    "
        txtHastaFecha.Text = "  /  /    "
        txtCliente.Text = ""
        txtRazonSocial.Text = ""
        opcPantalla.Checked = False
        opcImpesora.Checked = True
    End Sub

    Private Sub txtfecha1_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha1.Text) = "S" Then
                txtFecha2.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha1.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha2_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha2.Text) = "S" Then
                txtFecha3.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha2.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha3_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha3.Text) = "S" Then
                txtFecha4.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha3.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha4_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha4.Text) = "S" Then
                txtDesdeFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha4.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txtHastaFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtHastaFecha.Text) = "S" Then
                txtCliente.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaFecha.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtcliente_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtCliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Dim CampoCliente As Cliente = DAOCliente.buscarClientePorCodigo(txtCliente.Text)
            txtRazonSocial.Text = CampoCliente.razon.ToString
            txtFecha1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtCliente.Text = ""
            txtRazonSocial.Text = ""
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(508, 592)

        lstAyuda.DataSource = DAOCliente.buscarClientePorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtAyuda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub mostrarCliente(ByVal cliente As Cliente)
        txtCliente.Text = cliente.id
        txtRazonSocial.Text = cliente.razon
        txtCliente.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarCliente(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim varUno As String

        Dim varEmpresa As String
        Dim varFormula As String
        Dim x As Char = Chr(34)
        Dim varDesdefechaOrd, varHastafechaOrd As String
        Dim varDesdeCliente, varHastaCliente As String
        Dim varFecha1, varFecha2, VarFecha3, VarFecha4 As String

        Dim varImpo1, varImpo2, varImpo3, varImpo4, varImpo5 As Double
        Dim vartitulo1, vartitulo2, vartitulo3, vartitulo4, vartitulo5 As String
        Dim varVencimiento As String

        SQLConnector.retrieveDataTable("limpiar_valcar")

        varEmpresa = "Surfactan S.A."

        varDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        varHastafechaOrd = ordenaFecha(txtHastaFecha.Text)

        varFecha1 = ordenaFecha(txtFecha1.Text)
        varFecha2 = ordenaFecha(txtFecha2.Text)
        VarFecha3 = ordenaFecha(txtFecha3.Text)
        VarFecha4 = ordenaFecha(txtFecha4.Text)

        If LTrim(RTrim(txtCliente.Text)) <> "" Then
            varDesdeCliente = txtCliente.Text
            varHastaCliente = txtCliente.Text
        Else
            varDesdeCliente = ""
            varHastaCliente = "Z99999"
        End If

        vartitulo1 = txtFecha1.Text
        vartitulo2 = txtFecha2.Text
        vartitulo3 = txtFecha3.Text
        vartitulo4 = txtFecha4.Text
        vartitulo5 = "Posterior"

        Dim tabla As DataTable

        tabla = SQLConnector.retrieveDataTable("buscar_cheques_valcar", varDesdefechaOrd, varHastafechaOrd, varDesdeCliente, varHastaCliente)

        For Each row As DataRow In tabla.Rows

            Dim CampoRecibos As New LeeRecibosValcar(row.Item(0), row.Item(1), row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5),
                                           row.Item(6), row.Item(7), row.Item(8),
                                           row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                           row.Item(13), row.Item(14), row.Item(15), row.Item(16), row.Item(17),
                                           row.Item(18), row.Item(19), row.Item(20), row.Item(21), row.Item(22), row.Item(23), row.Item(24))

            varEmpresa = 1

            varImpo1 = 0
            varImpo2 = 0
            varImpo3 = 0
            varImpo4 = 0
            varImpo5 = 0

            varVencimiento = CampoRecibos.FechaOrd2

            If varVencimiento <= varFecha1 Then
                varImpo1 = CampoRecibos.importe2
            Else
                If varVencimiento > varFecha1 And varVencimiento <= varFecha2 Then
                    varImpo2 = CampoRecibos.importe2
                Else
                    If varVencimiento > varFecha2 And varVencimiento <= VarFecha3 Then
                        varImpo3 = CampoRecibos.importe2
                    Else
                        If varVencimiento > VarFecha3 And varVencimiento <= VarFecha4 Then
                            varImpo4 = CampoRecibos.importe2
                        Else
                            varImpo5 = CampoRecibos.importe2
                        End If
                    End If
                End If
            End If

            ''If Impre(5) = 0 Then
            '?????

            SQLConnector.executeProcedure("alta_valcar", CampoRecibos.recibo, CampoRecibos.cliente, CampoRecibos.numero2, CampoRecibos.Banco2, varImpo1, varImpo2, varImpo3,
                                          varImpo4, varImpo5, vartitulo1, vartitulo2, vartitulo3, vartitulo4, vartitulo5)

        Next





        'Dim txtdada As Double
        'txtdada = SQLConnector.executeProcedureWithReturnValue("get_saldo_inicial_pagos", txtDesdefechaOrd, txtHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)



        varUno = "{Valcar.recibo} in 0 to 999999"
        varFormula = varUno

        Dim viewer As New ReportViewer("Listado de Valores en Cartera", Globals.reportPathWithName("wvalcarnet.rpt"), varFormula)

        If opcPantalla.Checked = True Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If







    End Sub
End Class