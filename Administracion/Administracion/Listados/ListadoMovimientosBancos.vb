Imports ClasesCompartidas
Imports System.IO

Public Class ListadoMovimientosBancos

    Dim txtVectorBanco(1000) As String

    Private Sub ListadoMovimientosBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        txtDesdeBanco.Text = "0"
        txtHastaBanco.Text = "9999"

        opcPantalla.Checked = False
        opcImpesora.Checked = True
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
                txtDesdeBanco.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txtdesdebanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeBanco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaBanco.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthastabanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaBanco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeFecha.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(477, 461)

        lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        End If
    End Sub

    Private Sub mostrarbanco(ByVal banco As Banco)
        txtDesdeBanco.Text = banco.id
        txtHastaBanco.Text = banco.id
        txtDesdeBanco.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarbanco(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim varUno As String

        Dim varEmpresa As String
        Dim varFormula As String
        Dim x As Char = Chr(34)
        Dim varDesdefechaOrd, varHastafechaOrd As String

        Dim varBancoCodigo As Integer
        Dim varBancoCuenta As String

        Dim varRenglon As Integer
        Dim varTitulo As String
        Dim varTituloList As String
        Dim varVarios As String

        Dim varDebito, varCredito As Double
        Dim varAcredita, varAcreditaOrd As String
        Dim varBanco As Integer

        Dim vardada As String

        SQLConnector.retrieveDataTable("limpiar_movban")

        varEmpresa = "Surfactan S.A."

        varDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        varHastafechaOrd = ordenaFecha(txthastafecha.Text)

        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_banco_por_nombre", "")

        For Each row As DataRow In tablaII.Rows

            Dim CamposBanco As New LeeBanco(row.Item(0), row.Item(1), row.Item(2))

            varBancoCuenta = CamposBanco.Cuenta
            varBancoCodigo = CamposBanco.banco

            txtVectorBanco(varBancoCodigo) = varBancoCuenta

        Next


        Dim tabla As DataTable
        varRenglon = 0


        tabla = SQLConnector.retrieveDataTable("buscar_pagos_Movban", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoPagos As New LeePagosMovBan(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString,
                                            row.Item(3), row.Item(4).ToString, row.Item(5).ToString,
                                            row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString,
                                            row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                            row.Item(13), row.Item(14), row.Item(15))


            vardada = CampoPagos.renglon
            REM If CampoPagos.orden = 116720 Then Stop

            varRenglon = varRenglon + 1

            varTitulo = "Pagos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."
            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            varAcredita = CampoPagos.fecha2
            varAcreditaOrd = CampoPagos.fechaord2
            varDebito = 0
            varCredito = CampoPagos.importe2

            SQLConnector.executeProcedure("alta_movban", varRenglon, CampoPagos.banco2, CampoPagos.fecha, CampoPagos.fechaord, varAcredita, varAcreditaOrd, CampoPagos.observaciones,
                                          CampoPagos.numero2, varDebito, varCredito, CampoPagos.orden, varEmpresa, varTitulo, varTituloList, CampoPagos.proveedor)


        Next









        tabla = SQLConnector.retrieveDataTable("buscar_pagos_MovbanII", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoPagos As New LeePagosMovBan(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString,
                                            row.Item(3), row.Item(4).ToString, row.Item(5).ToString,
                                            row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString,
                                            row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                            row.Item(13), row.Item(14), row.Item(15))

            REM If Val(CampoPagos.orden) = 114551 Then Stop
            vardada = CampoPagos.renglon
            REM If CampoPagos.orden = 116720 Then Stop



            If CampoPagos.tiporeg = "1" Then

                varRenglon = varRenglon + 1

                varTitulo = "Pagos"
                varEmpresa = 1
                varTituloList = "Surfactan S.A."
                varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

                varAcredita = CampoPagos.fecha
                varAcreditaOrd = CampoPagos.fechaord
                varDebito = CampoPagos.importe1
                varCredito = 0

                SQLConnector.executeProcedure("alta_movban", varRenglon, CampoPagos.banco2, CampoPagos.fecha, CampoPagos.fechaord, varAcredita, varAcreditaOrd, CampoPagos.observaciones,
                                              CampoPagos.numero2, varDebito, varCredito, CampoPagos.orden, varEmpresa, varTitulo, varTituloList, CampoPagos.proveedor)

            End If

        Next








        tabla = SQLConnector.retrieveDataTable("buscar_depositos_Movban", varDesdefechaOrd, varHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)

        For Each row As DataRow In tabla.Rows

            Dim CampoDepositos As New LeeDepositosMovban(row.Item(0), row.Item(1), row.Item(2),
                                   row.Item(3), row.Item(4), row.Item(5),
                                   row.Item(6), row.Item(7), row.Item(8), row.Item(9))

            varRenglon = varRenglon + 1

            varTitulo = "Depositos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."
            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            varAcredita = CampoDepositos.acredita
            varAcreditaOrd = CampoDepositos.acreditaord
            varDebito = CampoDepositos.importe
            varCredito = 0

            SQLConnector.executeProcedure("alta_movban", varRenglon, CampoDepositos.Banco, CampoDepositos.Fecha, CampoDepositos.fechaord, varAcredita, varAcreditaOrd, "Deposito",
                                          CampoDepositos.deposito, varDebito, varCredito, CampoDepositos.deposito, varEmpresa, varTitulo, varTituloList, "")


        Next










        tabla = SQLConnector.retrieveDataTable("buscar_recibos_Movban", varDesdefechaOrd, varHastafechaOrd)

        For Each row As DataRow In tabla.Rows

            Dim CampoRecibos As New LeeRecibos(row.Item(0), row.Item(1), row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5),
                                           row.Item(6), row.Item(7), row.Item(8),
                                           row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                           row.Item(13), row.Item(14), row.Item(15), row.Item(16), row.Item(17),
                                           row.Item(18), row.Item(19), row.Item(20))

            varRenglon = varRenglon + 1

            If CampoRecibos.recibo = 88523 Then Stop

            varTitulo = "Recibos"
            varEmpresa = 1
            varTituloList = "Surfactan S.A."
            varVarios = "Desde el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text

            varAcredita = CampoRecibos.fecha
            varAcreditaOrd = CampoRecibos.fechaord
            varDebito = CampoRecibos.importe2
            varCredito = 0
            varBanco = 0

            Select Case LTrim(RTrim(CampoRecibos.cuenta))
                Case "21"
                    varBanco = 3
                Case "22"
                    varBanco = 8
                Case "26"
                    varBanco = 12
                Case "27"
                    varBanco = 16
                Case Else
                    varBanco = 99
            End Select

            If varBanco >= Val(txtDesdeBanco.Text) And varBanco <= Val(txtHastaBanco.Text) Then

                SQLConnector.executeProcedure("alta_movban", varRenglon, varBanco, CampoRecibos.fecha, CampoRecibos.fechaord, varAcredita, varAcreditaOrd, "Recibos",
                                              CampoRecibos.recibo, varDebito, varCredito, CampoRecibos.recibo, varEmpresa, varTitulo, varTituloList, "")

            End If

        Next




        'Dim txtdada As Double
        'txtdada = SQLConnector.executeProcedureWithReturnValue("get_saldo_inicial_pagos", txtDesdefechaOrd, txtHastafechaOrd, txtDesdeBanco.Text, txtHastaBanco.Text)



        varUno = "{Movban.Banco} in " + txtDesdeBanco.Text + " to " + txtHastaBanco.Text
        varFormula = varUno

        Dim viewer As New ReportViewer("Listado de Movimientos Bancarios", Globals.reportPathWithName("wMovbannet.rpt"), varFormula)

        If opcPantalla.Checked = True Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If

    End Sub

    Private Sub txtDesdeBanco_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeBanco.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub


    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

End Class