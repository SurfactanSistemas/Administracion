Imports ClasesCompartidas

Public Class ListadoCuentaCorrienteProveedoresAnalisitico

    Private Sub ListadoCuentaCorrienteProveedoresAnalisitico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesdeProveedor.Text = ""
        txtHastaProveedor.Text = ""
        txtFechaEmision.Text = "  /  /    "
        txtDias.Text = ""
        Label2.Text = Globals.NombreEmpresa()
    End Sub

    Private Sub txtfechaemision_KeyPress(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
               Handles txtFechaEmision.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFechaEmision.Text) = "S" Then
                txtDesdeProveedor.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFechaEmision.Text = "  /  /    "
            Me.txtFechaEmision.SelectionStart = 0
        End If
    End Sub

    Private Sub txtdesdeproveedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaProveedor.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeProveedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthastaproveedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDias.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaProveedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdias_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDias.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtFechaEmision.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDias.Text = ""
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

        Me.Size = New System.Drawing.Size(664, 538)

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre()

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtDesdeProveedor.Text = proveedor.id
        txtHastaProveedor.Text = proveedor.id
        txtDesdeProveedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        Dim varFormula, varUno, varDos, varTres As String
        Dim x As Char = Chr(34)
        Dim varFecha As String
        Dim varCicla As Integer
        Dim varDias As Integer
        Dim varDia, varMes, varAno As String
        Dim varDesdeFecha, varHastaFecha As String
        Dim varTitulo As String


        varFecha = txtFechaEmision.Text
        varCicla = 0

        Do

            varCicla = varCicla + 1
            If varCicla = 1000 Then Exit Sub

            varDias = DateDiff("d", varFecha, txtFechaEmision.Text)
            If varDias >= Val(txtDias.Text) Then Exit Do


            varDia = Mid$(varFecha, 1, 2)
            varMes = Mid$(varFecha, 4, 2)
            varAno = Mid$(varFecha, 7, 4)

            varDia = Str$(Val(varDia) - 1)
            If Val(varDia) = 0 Then
                varMes = Str$(Val(varMes) - 1)
                If Val(varMes) = 0 Then
                    varAno = Str$(Val(varAno) - 1)
                    varMes = "12"
                End If
                If Val(varMes) = 2 Then
                    varDia = "28"
                Else
                    varDia = "30"
                End If
            End If

            varFecha = ceros(varDia, 2) + "/" + ceros(varMes, 2) + "/" + ceros(varAno, 4)

        Loop

        varDesdeFecha = "00000000"

        varAno = leeizquierda(varFecha, 4)
        varMes = Mid$(varFecha, 4, 2)
        varDia = leederecha(varFecha, 2)
        varHastaFecha = varAno + varMes + varDia

        varTitulo = "Fecha de Emision : " + txtFechaEmision.Text + "    (Plazo :" + txtDias.Text + ")"

        varUno = "{CtaCtePrv.Proveedor} in " + x + txtDesdeProveedor.Text + x + " to " + x + txtHastaProveedor.Text + x
        varDos = " and {CtaCtePrv.ordfecha} in " + x + varDesdeFecha + x + " to " + x + varHastaFecha + x
        varTres = " and not ({CtaCtePrv.Saldo} in -1.00 to 1.00)"

        varFormula = varUno + varDos + varTres

        SQLConnector.executeProcedure("modificar_ctacteprv_titulo", "Surfactan S.A.", varTitulo, "", "", "", "", varDesdeFecha, varHastaFecha, txtDesdeProveedor.Text, txtHastaProveedor.Text)

        Dim viewer As New ReportViewer("Listado de Corriente de Proveedores Analitico", Globals.reportPathWithName("wccprvanaliticonet.rpt"), varFormula)

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With
    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick
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


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress, txtHastaProveedor.KeyPress, txtDias.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class