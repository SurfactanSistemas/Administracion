Imports ClasesCompartidas
Imports System.IO

Public Class ListadoEstaVendedorRubroLinea

    Dim txtCosto As Double
    Dim txtarticulo As String
    Dim varVector(,) As String
    Dim varAuxiliar(,) As String
    Dim varListaMp(,) As String
    Dim txtLugarMp As Integer
    Dim txtTitulo As String
    Dim txtSalida As Integer

    Private Sub ListadoEstaVendedorRubroLinea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReDim varListaMp(10000, 2)

        txtLugarMp = 0

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        txtDesdeVendedor.Text = "0"
        txtHastaVendedor.Text = "9999"

        txtDesdeVendedor.Focus()

        TipoCosto.Items.Clear()
        TipoCosto.Items.Add("Actual")
        TipoCosto.Items.Add("Fecha Facturacion")
        TipoCosto.SelectedIndex = 0

        _HabilitarSegunPermisos()

    End Sub

    Private Sub _HabilitarSegunPermisos()
        If Vendedor.permisos <> 99 Then
            txtDesdeVendedor.Text = Vendedor.permisos
            txtHastaVendedor.Text = Vendedor.permisos

            txtDesdeVendedor.Enabled = False
            txtHastaVendedor.Enabled = False
            TipoCosto.Visible = False
            Label5.Visible = False
        End If
    End Sub

    Private Sub txtdesdevendedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeVendedor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaVendedor.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeVendedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthastavendedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaVendedor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeFecha.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaVendedor.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeFecha.KeyPress

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
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthastafecha.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtDesdeVendedor.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(580, 460)

        lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    'Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
    '               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    '               Handles txtAyuda.KeyPress
    '    If e.KeyChar = Convert.ToChar(Keys.Return) Then
    '        e.Handled = True
    '        lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre(txtAyuda.Text)
    '    ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
    '        e.Handled = True
    '        txtAyuda.Text = ""
    '        lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre(txtAyuda.Text)
    '    End If
    'End Sub

    Private Sub mostrarvendedor(ByVal vendedor As Vendedor)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        Me.Size = New System.Drawing.Size(578, 270)
        txtDesdeVendedor.Text = vendedor.id
        txtHastaVendedor.Text = vendedor.id
        txtDesdeVendedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarvendedor(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub


    Private Sub Proceso()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim tabla As DataTable

        Dim varIngresaArticulo = ""
        Dim varIngresaCosto = ""
        Dim varSuma = 0

        Dim txtarticulo = ""
        Dim txtCosto
        Dim txtDescripcion = ""

        Dim txtTitulo = "Del " + txtDesdeFecha.Text + " al " + txthastafecha.Text

        txtDesde = ordenaFecha(txtDesdeFecha.Text)
        txtHasta = ordenaFecha(txthastafecha.Text)


        If Vendedor.permisos = 99 Or Vendedor.permisos = 2 Or Vendedor.permisos = 13 Then

            If TipoCosto.SelectedIndex = 0 Then
                txtTitulo = txtTitulo + " (Costo Actual)"
            Else
                txtTitulo = txtTitulo + " (Costo Historico)"
            End If

            If TipoCosto.SelectedIndex = 0 Then

                Dim txtLugarMp = 0
                Dim tablaMp As DataTable
                tablaMp = SQLConnector.retrieveDataTable("buscar_materiaPrima")
                For Each row As DataRow In tablaMp.Rows
                    Dim CampoMP As New LeeMateriaPrimaCosto(row.Item(0), row.Item(1), row.Item(2))
                    varIngresaArticulo = CampoMP.Articulo
                    varIngresaCosto = CampoMP.Costo
                    If varIngresaCosto <> 0 Then
                        txtLugarMp = txtLugarMp + 1
                        varListaMp(txtLugarMp, 1) = varIngresaArticulo
                        varListaMp(txtLugarMp, 2) = Str$(varIngresaCosto)
                    End If
                Next

                tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productos", txtDesdeVendedor.Text, txtHastaVendedor.Text, 0, 9999, 0, 9999, "", "Z99999", "", "Z99999", txtDesde, txtHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)


                    txtarticulo = CampoEstadistica.Articulo

                    txtCosto = Calcula_Costo(txtarticulo)
                    SQLConnector.executeProcedure("Modifica_Estadistica_Costo", txtDesde, txtHasta, txtarticulo, txtCosto, txtTitulo)

                    txtDescripcion = Busca_Nombre(txtarticulo)
                    SQLConnector.executeProcedure("Modifica_Estadistica_DescriTerminado", txtDesde, txtHasta, txtarticulo, txtDescripcion)

                    varSuma = varSuma + 1

                Next

                ProgressBar1.Visible = False

            Else

                tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productosII", txtDesdeVendedor.Text, txtHastaVendedor.Text, 0, 9999, 0, 9999, "", "Z99999", "", "Z99999", txtDesde, txtHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)

                    txtarticulo = CampoEstadistica.Articulo

                    txtDescripcion = Busca_Nombre(txtarticulo)
                    SQLConnector.executeProcedure("Modifica_Estadistica_DescriTerminado", txtDesde, txtHasta, txtarticulo, txtDescripcion)

                    varSuma = varSuma + 1

                Next

                SQLConnector.executeProcedure("Modifica_Estadistica_Costo_Historico", txtDesde, txtHasta, txtTitulo)

            End If
        Else
            SQLConnector.executeProcedure("Modifica_Estadistica_Costo_Historico", txtDesde, txtHasta, txtTitulo)
        End If


        lstAyuda.Visible = False
        txtAyuda.Visible = False

        txtUno = "{Estadistica.Vendedor} in " + txtDesdeVendedor.Text + " to " + txtHastaVendedor.Text
        txtDos = " and {Estadistica.OrdFecha} in " + x + txtDesde + x + " to " + x + txtHasta + x
        txtFormula = txtUno + txtDos

        Dim WReporte As String = "WEstavennet.rpt"

        If Vendedor.permisos <> 99 And Vendedor.permisos <> 2 And Vendedor.permisos <> 13 Then
            WReporte = "WEstavennetVendedor.rpt"
        End If

        Dim viewer As New ReportViewer("Listado de Vendedores, Rubro y Linea", Globals.reportPathWithName(WReporte), txtFormula)

        If txtSalida = 0 Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If

    End Sub


    Private Function Calcula_Costo(ByVal pasaArticulo As String)

        Dim varMateria As String
        Dim varCosto As Double
        Dim varCostoMP As Double

        Dim txtRenglon, txtLugar, txtCicla As Integer
        Dim txtTipo, txtArticulo, txtArticulo1, txtArticulo2 As String
        Dim txtCantidad, txtXVector As Double
        Dim txtEntra As String
        Dim txtEntraMP As String
        Dim txtTipopro As String

        ReDim varVector(200, 10)
        ReDim varAuxiliar(200, 10)

        txtRenglon = 0
        txtTipopro = leederecha(pasaArticulo, 2)

        If txtTipopro = "PT" Or txtTipopro = "PE" Or txtTipopro = "NK" Or txtTipopro = "RE" Then

            If txtTipopro = "NK" Or txtTipopro = "RE" Then
                pasaArticulo = "PT" + Mid$(pasaArticulo, 3, 10)
            End If

            If txtTipopro = "NW" Then
                pasaArticulo = "DW" + Mid$(pasaArticulo, 3, 10)
            End If

            varVector(1, 1) = pasaArticulo
            varVector(1, 2) = "1"

            txtCosto = 0
            txtLugar = 1
            txtCicla = 0
            varCosto = 0

            Do
                txtCicla = txtCicla + 1
                If varVector(txtCicla, 1) <> "" Then

                    txtEntra = "S"

                    Dim tablaCompo As DataTable
                    tablaCompo = SQLConnector.retrieveDataTable("buscar_Composicion_por_codigo", varVector(txtCicla, 1))
                    For Each row As DataRow In tablaCompo.Rows

                        Dim CampoCompo As New LeeComposicion(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5))
                        txtEntra = "N"

                        txtTipo = CampoCompo.Tipo
                        txtArticulo1 = CampoCompo.Articulo1
                        txtArticulo2 = CampoCompo.Articulo2
                        txtCantidad = CampoCompo.Cantidad

                        'If leederecha(txtArticulo1, 2) = "DW" Then
                        '    txtTipo = "T"
                        '    txtArticulo2 = leederecha(txtArticulo1, 3) + "00" + Mid$(txtArticulo1, 6, 7)
                        'End If

                        Select Case txtTipo
                            Case "T"
                                If pasaArticulo <> txtArticulo2 Then
                                    If txtLugar < 200 Then
                                        txtLugar = txtLugar + 1
                                        varVector(txtLugar, 1) = txtArticulo2
                                        varVector(txtLugar, 2) = Str$(txtCantidad * Val(varVector(txtCicla, 2)))
                                    Else
                                        Exit Do
                                    End If
                                End If
                            Case "M"
                                If txtRenglon < 200 Then
                                    txtRenglon = txtRenglon + 1
                                    varAuxiliar(txtRenglon, 1) = txtArticulo1
                                    varAuxiliar(txtRenglon, 2) = Str$(txtCantidad)
                                    varAuxiliar(txtRenglon, 3) = varVector(txtCicla, 2)
                                Else
                                    Exit Do
                                End If
                            Case Else
                        End Select

                    Next


                    If txtEntra = "S" And leederecha(varVector(txtCicla, 1), 2) = "DW" Then
                        txtRenglon = txtRenglon + 1
                        varAuxiliar(txtRenglon, 1) = leederecha(varVector(txtCicla, 1), 3) + Mid$(varVector(txtCicla, 1), 6, 7)
                        varAuxiliar(txtRenglon, 2) = 1
                        varAuxiliar(txtRenglon, 3) = varVector(txtCicla, 2)
                    End If

                Else

                    Exit Do

                End If

            Loop

            If txtRenglon > 0 Then

                For da = 1 To txtRenglon

                    txtArticulo = varAuxiliar(da, 1)
                    txtCantidad = Val(varAuxiliar(da, 2))
                    txtXVector = Val(varAuxiliar(da, 3))

                    varCostoMP = 0
                    txtEntraMP = "S"

                    For CicloMp = 1 To txtLugarMp
                        If varListaMp(CicloMp, 1) = txtArticulo Then
                            varCostoMP = Val(varListaMp(CicloMp, 2))
                            txtEntraMP = "N"
                            Exit For
                        End If
                    Next

                    If txtEntraMP = "S" Then
                        Dim tablaMp As DataTable
                        tablaMp = SQLConnector.retrieveDataTable("buscar_materiaPrima_por_codigo_costo", txtArticulo)
                        For Each row As DataRow In tablaMp.Rows
                            Dim CampoMP As New LeeMateriaPrimaCosto(row.Item(0), row.Item(1), row.Item(2))
                            varCostoMP = CampoMP.Costo
                            txtLugarMp = txtLugarMp + 1
                            varListaMp(txtLugarMp, 1) = txtArticulo
                            varListaMp(txtLugarMp, 2) = Str$(varCostoMP)
                        Next
                    End If

                    If varCostoMP <> 0 Then
                        varCosto = varCosto + (txtCantidad * varCostoMP * txtXVector)
                    End If

                Next da
            Else

                varMateria = leederecha(pasaArticulo, 3) + Mid$(pasaArticulo, 6, 7)

                varCosto = 0
                txtEntraMP = "S"

                For CicloMp = 1 To txtLugarMp
                    If varListaMp(CicloMp, 1) = varMateria Then
                        varCosto = Val(varListaMp(CicloMp, 2))
                        txtEntraMP = "N"
                        Exit For
                    End If
                Next

                If txtEntraMP = "S" Then
                    Dim tablaMp As DataTable
                    tablaMp = SQLConnector.retrieveDataTable("buscar_materiaPrima_por_codigo_costo", varMateria)
                    For Each row As DataRow In tablaMp.Rows
                        Dim CampoMP As New LeeMateriaPrimaCosto(row.Item(0), row.Item(1), row.Item(2))
                        varCosto = CampoMP.Costo
                        txtLugarMp = txtLugarMp + 1
                        varListaMp(txtLugarMp, 1) = varMateria
                        varListaMp(txtLugarMp, 2) = Str$(varCosto)
                    Next
                End If
            End If

        Else

            varMateria = leederecha(pasaArticulo, 3) + Mid$(pasaArticulo, 6, 7)

            varCosto = 0
            txtEntraMP = "S"

            For CicloMp = 1 To txtLugarMp
                If varListaMp(CicloMp, 1) = varMateria Then
                    varCosto = Val(varListaMp(CicloMp, 2))
                    txtEntraMP = "N"
                    Exit For
                End If
            Next

            If txtEntraMP = "S" Then
                Dim tablaMp As DataTable
                tablaMp = SQLConnector.retrieveDataTable("buscar_materiaPrima_por_codigo_costo", varMateria)
                For Each row As DataRow In tablaMp.Rows
                    Dim CampoMP As New LeeMateriaPrimaCosto(row.Item(0), row.Item(1), row.Item(2))
                    varCosto = CampoMP.Costo
                    txtLugarMp = txtLugarMp + 1
                    varListaMp(txtLugarMp, 1) = varMateria
                    varListaMp(txtLugarMp, 2) = Str$(varCosto)
                Next
            End If

        End If

        Return varCosto

    End Function

    Private Function Busca_Nombre(ByVal pasaArticulo As String)

        Dim txtTipopro As String
        Dim varDescricpion As String

        txtTipopro = leederecha(pasaArticulo, 2)
        varDescricpion = ""

        If txtTipopro = "PT" Or txtTipopro = "PE" Or txtTipopro = "NK" Or txtTipopro = "RE" Then
            REM pasaArticulo = "PT" + Mid$(pasaArticulo, 3, 10)
            Dim tablaPt As DataTable
            tablaPt = SQLConnector.retrieveDataTable("buscar_terminado_por_codigo", pasaArticulo)
            For Each row As DataRow In tablaPt.Rows
                Dim Campopt As New LeeTerminado(row.Item(0), row.Item(1))
                varDescricpion = Campopt.Descripcion
            Next
        Else
            pasaArticulo = leederecha(pasaArticulo, 3) + Mid$(pasaArticulo, 6, 10)
            Dim tablaMp As DataTable
            tablaMp = SQLConnector.retrieveDataTable("buscar_materiaPrima_por_codigo_costo", pasaArticulo)
            For Each row As DataRow In tablaMp.Rows
                Dim CampoMP As New LeeMateriaPrimaCosto(row.Item(0), row.Item(1), row.Item(2))
                varDescricpion = CampoMP.Descripcion
            Next
        End If

        Return varDescricpion

    End Function

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        txtSalida = 0
        Call Proceso()
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click
        txtSalida = 1
        Call Proceso()
    End Sub

    Private Sub ListadoEstaVendedorRubroLinea_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If Not txtDesdeVendedor.Enabled Then
            txtDesdeFecha.Focus()
        Else
            txtDesdeVendedor.Focus()
        End If
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

        If IsNothing(filtrado.SelectedItem) Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub



    Private Sub txtAyuda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub
End Class