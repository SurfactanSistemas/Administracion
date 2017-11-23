Imports ClasesCompartidas

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
    End Sub

    Private Sub txtfecha1_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Dim WFecha = txtFecha1.Text
            If ValidaFecha(WFecha) = "S" Or Trim(WFecha.Replace("/", "")) = "" Then
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

            Dim WFecha = txtFecha2.Text
            If ValidaFecha(txtFecha2.Text) = "S" Or Trim(WFecha.Replace("/", "")) = "" Then
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
            Dim WFecha = txtFecha3.Text
            If ValidaFecha(txtFecha3.Text) = "S" Or Trim(WFecha.Replace("/", "")) = "" Then
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
            Dim WFecha = txtFecha4.Text
            If ValidaFecha(txtFecha4.Text) = "S" Or Trim(WFecha.Replace("/", "")) = "" Then
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

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        Dim varUno As String
        Dim varFormula As String
        Dim varDesdefechaOrd, varHastafechaOrd As String
        Dim varDesdeCliente, varHastaCliente As String
        Dim varFecha1, varFecha2, VarFecha3, VarFecha4 As String

        Dim varImpo1, varImpo2, varImpo3, varImpo4, varImpo5 As Double
        Dim vartitulo1, vartitulo2, vartitulo3, vartitulo4, vartitulo5 As String
        Dim varVencimiento As String

        SQLConnector.retrieveDataTable("limpiar_valcar")

        If Proceso._EsPellital() Then
        End If

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
        Dim fechaord, recibo, tiporeg, tiporec, cuenta, cliente, tipo1, letra1, punto1, numero1, fecha, tipo2, numero2, importe1, paridad, importe2, retiva, retotra, retsuss, retganancias, renglon, Banco2, Fecha2, FechaOrd2, destino

        tabla = SQLConnector.retrieveDataTable("buscar_cheques_valcar", varDesdefechaOrd, varHastafechaOrd, varDesdeCliente, varHastaCliente)

        For Each row As DataRow In tabla.Rows

            fechaord = IIf(IsDBNull(row.Item(0)), "", row.Item(0))
            recibo = IIf(IsDBNull(row.Item(1)), "", row.Item(1))
            tiporeg = IIf(IsDBNull(row.Item(2)), "", row.Item(2))
            tiporec = IIf(IsDBNull(row.Item(3)), "", row.Item(3))
            cuenta = IIf(IsDBNull(row.Item(4)), "", row.Item(4))
            cliente = IIf(IsDBNull(row.Item(5)), "", row.Item(5))
            tipo1 = IIf(IsDBNull(row.Item(6)), "", row.Item(6))
            letra1 = IIf(IsDBNull(row.Item(7)), "", row.Item(7))
            punto1 = IIf(IsDBNull(row.Item(8)), "", row.Item(8))
            numero1 = IIf(IsDBNull(row.Item(9)), "", row.Item(9))
            fecha = IIf(IsDBNull(row.Item(10)), "", row.Item(10))
            tipo2 = IIf(IsDBNull(row.Item(11)), "", row.Item(11))
            numero2 = IIf(IsDBNull(row.Item(12)), "", row.Item(12))
            importe1 = IIf(IsDBNull(row.Item(13)), 0, row.Item(13))
            paridad = IIf(IsDBNull(row.Item(14)), 0, row.Item(14))
            importe2 = IIf(IsDBNull(row.Item(15)), 0, row.Item(15))
            retiva = IIf(IsDBNull(row.Item(16)), 0, row.Item(16))
            retotra = IIf(IsDBNull(row.Item(17)), 0, row.Item(17))
            retsuss = IIf(IsDBNull(row.Item(18)), 0, row.Item(18))
            retganancias = IIf(IsDBNull(row.Item(19)), 0, row.Item(19))
            renglon = IIf(IsDBNull(row.Item(20)), 0, row.Item(20))
            Banco2 = IIf(IsDBNull(row.Item(21)), "", row.Item(21))
            Fecha2 = IIf(IsDBNull(row.Item(22)), "", row.Item(22))
            FechaOrd2 = IIf(IsDBNull(row.Item(23)), "", row.Item(23))
            destino = IIf(IsDBNull(row.Item(24)), "", row.Item(24))

            Dim CampoRecibos As New LeeRecibosValcar(fechaord, recibo, tiporeg, tiporec, cuenta, cliente, tipo1, letra1, punto1, numero1, fecha, tipo2, numero2, importe1, paridad, importe2, retiva, retotra, retsuss, retganancias, renglon, Banco2, Fecha2, FechaOrd2, destino)

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

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With
    End Sub


    Private Sub txtCliente_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCliente.MouseDoubleClick
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



    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub

    Private Sub ListadoValoresEnCartera_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFecha1.Focus()
    End Sub
End Class