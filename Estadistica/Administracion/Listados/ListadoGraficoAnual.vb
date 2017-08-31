Imports ClasesCompartidas
Imports System.IO



Public Class ListadoGraficoAnual

    Dim txtCosto As Double
    Dim txtDescripcion As String
    Dim txtarticulo As String
    Dim varVector(,) As String
    Dim varAuxiliar(,) As String
    Dim varListaMp(,) As String
    Dim txtLugarMp As Integer
    Dim txtTitulo As String
    Dim txtTituloII As String
    Dim txtSalida As Integer

    Dim varGraba(1000, 10) As Double
    Dim txtImpreMes(100) As String
    Dim varProcesoBusqueda As Integer

    Private Sub ListadoGrafico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReDim varListaMp(50000, 2)

        txtLugarMp = 0

        txtAno.Text = ""
        txtAnoII.Text = ""

        TipoCosto.Items.Clear()
        TipoCosto.Items.Add("Actual")
        TipoCosto.Items.Add("Fecha Facturacion")
        TipoCosto.SelectedIndex = 0


        TipoListadoII.Items.Clear()
        TipoListadoII.Items.Add("Anual")
        TipoListadoII.Items.Add("InterAnual")
        TipoListadoII.Items.Add("Comparativo")
        TipoListadoII.SelectedIndex = 0


        TipoListado.Items.Clear()
        TipoListado.Items.Add("Cantidad")
        TipoListado.Items.Add("$")
        TipoListado.Items.Add("U$S")
        TipoListado.SelectedIndex = 0

        txtAno.Focus()

        _HabilitarSegunVendedor()

    End Sub

    Private Sub _HabilitarSegunVendedor()
        If Vendedor.permisos <> 99 Then

            txtVendedorFiltro.Text = Vendedor.permisos
            txtVendedorFiltro.Enabled = False

        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub Proceso()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim varBarra As Integer

        Dim varSuma As Integer
        Dim varIngresaCosto As Double
        Dim varIngresaArticulo As String

        Dim txtSuma As Double
        Dim txtSumaI As Double
        Dim txtSumaII As Double
        Dim txtCantidad As Double
        Dim txtFactor As Double
        Dim txtLugar As Integer
        Dim txtPorce As Double
        Dim txtResto As Double

        Dim txtCampo1 As String
        Dim txtCampo2 As String

        Dim txtLinea As Integer

        Dim txtDesdeVendedor As Integer
        Dim txtHastaVendedor As Integer
        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String
        Dim txtDesdeLinea As Integer
        Dim txtHastaLinea As Integer
        Dim txtDesdeRubro As Integer
        Dim txtHastaRubro As Integer
        Dim txtDesdeTerminado As String
        Dim txtHastaTerminado As String
        Dim txtSumaTitulo As String

        Dim varMesGraba As Integer

        ReDim varGraba(1000, 10)
        ReDim txtImpreMes(100)

        txtImpreMes(1) = "Enero"
        txtImpreMes(2) = "Febrero"
        txtImpreMes(3) = "Marzo"
        txtImpreMes(4) = "Abril"
        txtImpreMes(5) = "Mayo"
        txtImpreMes(6) = "Junio"
        txtImpreMes(7) = "Julio"
        txtImpreMes(8) = "Agosto"
        txtImpreMes(9) = "Septiembre"
        txtImpreMes(10) = "Octubre"
        txtImpreMes(11) = "Noviembre"
        txtImpreMes(12) = "Diciembre"

        txtLugar = 0

        txtDesde = txtAno.Text + "0101"
        txtHasta = txtAno.Text + "1231"

        txtTitulo = ""
        txtSumaTitulo = ""

        If Val(txtLineaFiltro.Text) = 0 Then
            txtDesdeLinea = 0
            txtHastaLinea = 9999
        Else
            txtDesdeLinea = Val(txtLineaFiltro.Text)
            txtHastaLinea = Val(txtLineaFiltro.Text)
            txtSumaTitulo = DesLinea.Text
        End If

        If Val(txtRubroFiltro.Text) = 0 Then
            txtDesdeRubro = 0
            txtHastaRubro = 9999
        Else
            txtDesdeRubro = Val(txtRubroFiltro.Text)
            txtHastaRubro = Val(txtRubroFiltro.Text)
            If txtSumaTitulo = "" Then
                txtSumaTitulo = DesRubro.Text
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesRubro.Text
            End If
        End If

        If Val(txtVendedorFiltro.Text) = 0 Then
            txtDesdeVendedor = 0
            txtHastaVendedor = 9999
        Else
            txtDesdeVendedor = Val(txtVendedorFiltro.Text)
            txtHastaVendedor = Val(txtVendedorFiltro.Text)
            If txtSumaTitulo = "" Then
                txtSumaTitulo = DesVendedor.Text
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesVendedor.Text
            End If
        End If

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "ZZZZZZ"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
            If txtSumaTitulo = "" Then
                txtSumaTitulo = DesCliente.Text
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesCliente.Text
            End If
        End If

        If LTrim(RTrim(leederecha(txtTerminadoFiltro.Text, 2))) = "" Then
            txtDesdeTerminado = "AA-00000-000"
            txtHastaTerminado = "ZZ-99999-999"
        Else
            txtDesdeTerminado = txtTerminadoFiltro.Text
            txtHastaTerminado = txtTerminadoFiltro.Text
            If txtSumaTitulo = "" Then
                txtSumaTitulo = DesTerminado.Text
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesTerminado.Text
            End If
        End If

        If txtSumaTitulo <> "" Then
            txtSumaTitulo = txtSumaTitulo + " - "
        End If

        If TipoListado.SelectedIndex = 3 Then

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

            ProgressBar1.Visible = True
            With ProgressBar1
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 0
            End With

            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productos", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

            For Each row As DataRow In tabla.Rows

                Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)

                txtarticulo = CampoEstadistica.Articulo

                varBarra = varBarra + 4
                If varBarra > 5000 Then
                    varBarra = 4
                End If
                ProgressBar1.Value = varBarra

                Calcula_Costo(txtarticulo)
                SQLConnector.executeProcedure("Modifica_Estadistica_Costo", txtDesde, txtHasta, txtarticulo, txtCosto, txtTitulo)

                varSuma = varSuma + 1

            Next

            ProgressBar1.Visible = False

        Else

            SQLConnector.executeProcedure("Modifica_Estadistica_Costo_Historico", txtDesde, txtHasta, txtTitulo)

        End If








        SQLConnector.retrieveDataTable("limpiar_grafico")

        txtTitulo = ""
        txtTituloII = ""

        txtTitulo = "Ventas del " + txtAno.Text


        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_registros", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

        For Each row As DataRow In tablaII.Rows

            Dim CampoEsta As New LeeEstadisticaRankingOtro(row.Item(0), row.Item(1).ToString, row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8).ToString, row.Item(9), row.Item(10), row.Item(11))



            If Val(CampoEsta.Tipo) = 1 Then
                txtCantidad = CampoEsta.Cantidad
            Else
                txtCantidad = CampoEsta.Cantidad * -1
            End If

            If TipoListado.SelectedIndex = 0 Then
                txtSuma = txtCantidad
                txtSumaII = txtSumaII + txtCantidad
                txtTituloII = txtSumaTitulo + "Cantidad"
            Else
                If TipoListado.SelectedIndex = 1 Then
                    txtSuma = CampoEsta.Importe
                    txtSumaII = txtSumaII + CampoEsta.Importe
                    txtTituloII = txtSumaTitulo + "Pesos"
                Else
                    If TipoListado.SelectedIndex = 2 Then
                        txtSuma = CampoEsta.ImporteUs
                        txtSumaII = txtSumaII + CampoEsta.ImporteUs
                        txtTituloII = txtSumaTitulo + "Dolares"
                    Else
                        If TipoListado.SelectedIndex = 3 Then
                            txtSuma = CampoEsta.ImporteUs
                            txtSumaI = CampoEsta.Costo2
                            If TipoCosto.SelectedIndex = 0 Then
                                txtTituloII = txtSumaTitulo + "Factor (Costo Actual)"
                            Else
                                txtTituloII = txtSumaTitulo + " (Costo Historico)"
                            End If
                        End If
                    End If
                End If
            End If

            txtTituloII = leederecha(txtTituloII, 50)

            varMesGraba = Val(Mid(CampoEsta.Fecha, 4, 2))
            varGraba(varMesGraba, 1) = varGraba(varMesGraba, 1) + txtSuma

        Next

        For txtCiclo = 1 To 12

            txtLinea = txtCiclo
            txtSuma = varGraba(txtCiclo, 1)

            txtCampo1 = txtLinea
            txtCampo1 = ceros(txtCampo1, 2)

            txtCampo2 = txtCampo1 + " - " + txtImpreMes(txtCiclo)
            txtPorce = 0
            If txtSumaII <> 0 Then
                txtPorce = redondeo(txtSuma / txtSumaII * 100)
            End If

            'If TipoListado.SelectedIndex <> 3 Then
            '    If txtPorce > 1 Then
            '        SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
            '    Else
            '        txtResto = txtResto + txtSuma
            '    End If
            'Else
            '    If txtFactor <> 0 Then
            '        SQLConnector.executeProcedure("alta_grafico", txtLinea, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
            '    End If
            'End If

            If TipoListado.SelectedIndex <> 3 Then
                SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
            Else
                If txtFactor <> 0 Then
                    SQLConnector.executeProcedure("alta_grafico", txtLinea, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                End If
            End If


        Next

        If txtResto > 0 Then
            txtCampo1 = "99"

            txtCampo2 = txtCampo1 + " - " + "Varios"
            txtPorce = 0
            If txtSumaII <> 0 Then
                txtPorce = redondeo(txtResto / txtSumaII * 100)
            End If

            SQLConnector.executeProcedure("alta_grafico", 99, txtResto, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
        End If

        ProgressBar1.Visible = False

        txtUno = "{Grafico2.codigo} in 0 to 9999"
        txtDos = ""

        If Vendedor.permisos <> 99 Then
            txtUno = "{Grafico2.codigo} in " & Vendedor.permisos & " to " & Vendedor.permisos
        End If

        txtFormula = txtUno + txtDos

        If TipoListado.SelectedIndex <> 3 Then
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        Else
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoFactorNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        End If




    End Sub



    Private Sub ProcesoII()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim varBarra As Integer

        Dim varSuma As Integer
        Dim varIngresaCosto As Double
        Dim varIngresaArticulo As String

        Dim txtSuma As Double
        Dim txtSumaI As Double
        Dim txtSumaII As Double
        Dim txtCantidad As Double
        Dim txtFactor As Double
        Dim txtLugar As Integer
        Dim txtPorce As Double
        Dim txtResto As Double

        Dim txtCampo1 As String
        Dim txtCampo2 As String

        Dim txtLinea As Integer

        Dim txtDesdeVendedor As Integer
        Dim txtHastaVendedor As Integer
        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String
        Dim txtDesdeLinea As Integer
        Dim txtHastaLinea As Integer
        Dim txtDesdeRubro As Integer
        Dim txtHastaRubro As Integer
        Dim txtDesdeTerminado As String
        Dim txtHastaTerminado As String
        Dim txtSumaTitulo As String

        Dim varMesGraba As Integer

        ReDim varGraba(10000, 10)
        ReDim txtImpreMes(100)

        txtImpreMes(1) = "Enero"
        txtImpreMes(2) = "Febrero"
        txtImpreMes(3) = "Marzo"
        txtImpreMes(4) = "Abril"
        txtImpreMes(5) = "Mayo"
        txtImpreMes(6) = "Junio"
        txtImpreMes(7) = "Julio"
        txtImpreMes(8) = "Agosto"
        txtImpreMes(9) = "Septiembre"
        txtImpreMes(10) = "Octubre"
        txtImpreMes(11) = "Noviembre"
        txtImpreMes(12) = "Diciembre"

        txtLugar = 0

        txtDesde = txtAno.Text + "0101"
        txtHasta = txtAnoII.Text + "1231"

        txtTitulo = ""
        txtSumaTitulo = ""

        If Val(txtLineaFiltro.Text) = 0 Then
            txtDesdeLinea = 0
            txtHastaLinea = 9999
        Else
            txtDesdeLinea = Val(txtLineaFiltro.Text)
            txtHastaLinea = Val(txtLineaFiltro.Text)
            txtSumaTitulo = DesLinea.Text
        End If

        If Val(txtRubroFiltro.Text) = 0 Then
            txtDesdeRubro = 0
            txtHastaRubro = 9999
        Else
            txtDesdeRubro = Val(txtRubroFiltro.Text)
            txtHastaRubro = Val(txtRubroFiltro.Text)
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesRubro.Text
            End If
        End If

        If Val(txtVendedorFiltro.Text) = 0 Then
            txtDesdeVendedor = 0
            txtHastaVendedor = 9999
        Else
            txtDesdeVendedor = Val(txtVendedorFiltro.Text)
            txtHastaVendedor = Val(txtVendedorFiltro.Text)
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesVendedor.Text
            End If
        End If

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "ZZZZZZ"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesCliente.Text
            End If
        End If

        If LTrim(RTrim(leederecha(txtTerminadoFiltro.Text, 2))) = "" Then
            txtDesdeTerminado = "AA-00000-000"
            txtHastaTerminado = "ZZ-99999-999"
        Else
            txtDesdeTerminado = txtTerminadoFiltro.Text
            txtHastaTerminado = txtTerminadoFiltro.Text
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesTerminado.Text
            End If
        End If

        If txtSumaTitulo <> "" Then
            txtSumaTitulo = txtSumaTitulo + " - "
        End If

        If TipoListado.SelectedIndex = 3 Then

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

            ProgressBar1.Visible = True
            With ProgressBar1
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 0
            End With

            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productos", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

            For Each row As DataRow In tabla.Rows

                Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)

                txtarticulo = CampoEstadistica.Articulo

                varBarra = varBarra + 4
                If varBarra > 5000 Then
                    varBarra = 4
                End If
                ProgressBar1.Value = varBarra

                Calcula_Costo(txtarticulo)
                SQLConnector.executeProcedure("Modifica_Estadistica_Costo", txtDesde, txtHasta, txtarticulo, txtCosto, txtTitulo)

                varSuma = varSuma + 1

            Next

            ProgressBar1.Visible = False

        Else

            SQLConnector.executeProcedure("Modifica_Estadistica_Costo_Historico", txtDesde, txtHasta, txtTitulo)

        End If








        SQLConnector.retrieveDataTable("limpiar_grafico")

        txtTitulo = ""
        txtTituloII = ""

        txtTitulo = "Ventas del " + txtAno.Text


        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_registros", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

        For Each row As DataRow In tablaII.Rows

            Dim CampoEsta As New LeeEstadisticaRankingOtro(row.Item(0), row.Item(1).ToString, row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8).ToString, row.Item(9), row.Item(10), row.Item(11))



            If Val(CampoEsta.Tipo) = 1 Then
                txtCantidad = CampoEsta.Cantidad
            Else
                txtCantidad = CampoEsta.Cantidad * -1
            End If

            If TipoListado.SelectedIndex = 0 Then
                txtSuma = txtCantidad
                txtSumaII = txtSumaII + txtCantidad
                txtTituloII = txtSumaTitulo + "Cantidad"
            Else
                If TipoListado.SelectedIndex = 1 Then
                    txtSuma = CampoEsta.Importe
                    txtSumaII = txtSumaII + CampoEsta.Importe
                    txtTituloII = txtSumaTitulo + "Pesos"
                Else
                    If TipoListado.SelectedIndex = 2 Then
                        txtSuma = CampoEsta.ImporteUs
                        txtSumaII = txtSumaII + CampoEsta.ImporteUs
                        txtTituloII = txtSumaTitulo + "Dolares"
                    Else
                        If TipoListado.SelectedIndex = 3 Then
                            txtSuma = CampoEsta.ImporteUs
                            txtSumaI = CampoEsta.Costo2
                            If TipoCosto.SelectedIndex = 0 Then
                                txtTituloII = txtSumaTitulo + "Factor (Costo Actual)"
                            Else
                                txtTituloII = txtSumaTitulo + " (Costo Historico)"
                            End If
                        End If
                    End If
                End If
            End If

            txtTituloII = leederecha(txtTituloII, 50)

            varMesGraba = Val(Mid(CampoEsta.Fecha, 7, 4))
            varGraba(varMesGraba, 1) = varGraba(varMesGraba, 1) + txtSuma

        Next

        For txtCiclo = 1 To 9999

            txtLinea = txtCiclo
            txtSuma = varGraba(txtCiclo, 1)

            If txtSuma <> 0 Then

                txtCampo1 = txtLinea
                txtCampo1 = ceros(txtCampo1, 4)

                txtCampo2 = txtCampo1
                txtPorce = 0
                If txtSumaII <> 0 Then
                    txtPorce = redondeo(txtSuma / txtSumaII * 100)
                End If


                'If TipoListado.SelectedIndex <> 3 Then
                '    If txtPorce > 1 Then
                '        SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                '    Else
                '        txtResto = txtResto + txtSuma
                '    End If
                'Else
                '    If txtFactor <> 0 Then
                '        SQLConnector.executeProcedure("alta_grafico", txtLinea, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                '    End If
                'End If

                If TipoListado.SelectedIndex <> 3 Then
                    SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                Else
                    If txtFactor <> 0 Then
                        SQLConnector.executeProcedure("alta_grafico", txtLinea, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                    End If
                End If

            End If
        Next

        If txtResto > 0 Then
            txtCampo1 = "99"

            txtCampo2 = txtCampo1 + " - " + "Varios"
            txtPorce = 0
            If txtSumaII <> 0 Then
                txtPorce = redondeo(txtResto / txtSumaII * 100)
            End If

            SQLConnector.executeProcedure("alta_grafico", 99, txtResto, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
        End If

        ProgressBar1.Visible = False

        txtUno = "{Grafico2.codigo} in 0 to 9999"
        txtDos = ""
        txtFormula = txtUno + txtDos

        If TipoListado.SelectedIndex <> 3 Then
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        Else
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoFactorNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        End If




    End Sub







    Private Sub ProcesoIII()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim varBarra As Integer

        Dim varSuma As Integer
        Dim varIngresaCosto As Double
        Dim varIngresaArticulo As String

        Dim txtSuma As Double
        Dim txtSumaI As Double
        Dim txtSumaII As Double
        Dim txtCantidad As Double
        Dim txtLugar As Integer
        Dim txtPorce As Double

        Dim txtSumaTotal As Double
        Dim txtSumaTotalI As Double
        REM Dim txtSumaTotalII As Double


        Dim txtCampo1 As String
        Dim txtCampo2 As String

        Dim txtLinea As Integer

        Dim txtDesdeVendedor As Integer
        Dim txtHastaVendedor As Integer
        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String
        Dim txtDesdeLinea As Integer
        Dim txtHastaLinea As Integer
        Dim txtDesdeRubro As Integer
        Dim txtHastaRubro As Integer
        Dim txtDesdeTerminado As String
        Dim txtHastaTerminado As String
        Dim txtSumaTitulo As String

        Dim varMesGraba As Integer

        ReDim varGraba(10000, 10)
        ReDim txtImpreMes(100)

        txtImpreMes(1) = "Enero"
        txtImpreMes(2) = "Febrero"
        txtImpreMes(3) = "Marzo"
        txtImpreMes(4) = "Abril"
        txtImpreMes(5) = "Mayo"
        txtImpreMes(6) = "Junio"
        txtImpreMes(7) = "Julio"
        txtImpreMes(8) = "Agosto"
        txtImpreMes(9) = "Septiembre"
        txtImpreMes(10) = "Octubre"
        txtImpreMes(11) = "Noviembre"
        txtImpreMes(12) = "Diciembre"

        txtLugar = 0

        txtAnoII.Text = Str$(Val(txtAno.Text) - 1)
        Call ceros(txtAnoII.Text, 4)
        txtAnoII.Text = LTrim(RTrim(txtAnoII.Text))

        txtDesde = txtAnoII.Text + "0101"
        txtHasta = txtAno.Text + "1231"

        txtTitulo = ""
        txtSumaTitulo = ""

        If Val(txtLineaFiltro.Text) = 0 Then
            txtDesdeLinea = 0
            txtHastaLinea = 9999
        Else
            txtDesdeLinea = Val(txtLineaFiltro.Text)
            txtHastaLinea = Val(txtLineaFiltro.Text)
            txtSumaTitulo = DesLinea.Text
        End If

        If Val(txtRubroFiltro.Text) = 0 Then
            txtDesdeRubro = 0
            txtHastaRubro = 9999
        Else
            txtDesdeRubro = Val(txtRubroFiltro.Text)
            txtHastaRubro = Val(txtRubroFiltro.Text)
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesRubro.Text
            End If
        End If

        If Val(txtVendedorFiltro.Text) = 0 Then
            txtDesdeVendedor = 0
            txtHastaVendedor = 9999
        Else
            txtDesdeVendedor = Val(txtVendedorFiltro.Text)
            txtHastaVendedor = Val(txtVendedorFiltro.Text)
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesVendedor.Text
            End If
        End If

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "ZZZZZZ"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesCliente.Text
            End If
        End If

        If LTrim(RTrim(leederecha(txtTerminadoFiltro.Text, 2))) = "" Then
            txtDesdeTerminado = "AA-00000-000"
            txtHastaTerminado = "ZZ-99999-999"
        Else
            txtDesdeTerminado = txtTerminadoFiltro.Text
            txtHastaTerminado = txtTerminadoFiltro.Text
            If txtTitulo = "" Then
                txtSumaTitulo = txtSumaTitulo
            Else
                txtSumaTitulo = txtSumaTitulo + " - " + DesTerminado.Text
            End If
        End If

        If txtSumaTitulo <> "" Then
            txtSumaTitulo = txtSumaTitulo + " - "
        End If

        If TipoListado.SelectedIndex = 3 Then

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

            ProgressBar1.Visible = True
            With ProgressBar1
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 0
            End With

            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productos", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

            For Each row As DataRow In tabla.Rows

                Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)

                txtarticulo = CampoEstadistica.Articulo

                varBarra = varBarra + 4
                If varBarra > 5000 Then
                    varBarra = 4
                End If
                ProgressBar1.Value = varBarra

                Calcula_Costo(txtarticulo)
                SQLConnector.executeProcedure("Modifica_Estadistica_Costo", txtDesde, txtHasta, txtarticulo, txtCosto, txtTitulo)

                varSuma = varSuma + 1

            Next

            ProgressBar1.Visible = False

        Else

            SQLConnector.executeProcedure("Modifica_Estadistica_Costo_Historico", txtDesde, txtHasta, txtTitulo)

        End If








        SQLConnector.retrieveDataTable("limpiar_grafico")

        txtTitulo = ""
        txtTituloII = ""

        txtTitulo = "Comparativo del " + txtAno.Text + " con " + txtAnoII.Text


        txtSuma = 0
        txtSumaI = 0
        txtSumaII = 0



        txtDesde = txtAnoII.Text + "0101"
        txtHasta = txtAno.Text + "1231"

        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_registros", txtDesdeVendedor, txtHastaVendedor, txtDesdeLinea, txtHastaLinea, txtDesdeRubro, txtHastaRubro, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado, txtHastaTerminado, txtDesde, txtHasta)

        For Each row As DataRow In tablaII.Rows

            Dim CampoEsta As New LeeEstadisticaRankingOtro(row.Item(0), row.Item(1).ToString, row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8).ToString, row.Item(9), row.Item(10), row.Item(11))


            If Val(CampoEsta.Tipo) = 1 Then
                txtCantidad = CampoEsta.Cantidad
            Else
                txtCantidad = CampoEsta.Cantidad * -1
            End If


            If TipoListado.SelectedIndex = 0 Then
                txtSuma = txtCantidad
                txtTituloII = txtSumaTitulo + "Cantidad"
            Else
                If TipoListado.SelectedIndex = 1 Then
                    txtSuma = CampoEsta.Importe
                    txtTituloII = txtSumaTitulo + "Pesos"
                Else
                    If TipoListado.SelectedIndex = 2 Then
                        txtSuma = CampoEsta.ImporteUs
                        txtTituloII = txtSumaTitulo + "Dolares"
                    End If
                End If
            End If

            txtTituloII = leederecha(txtTituloII, 50)

            varMesGraba = Val(Mid(CampoEsta.Fecha, 4, 2))
            If Mid(CampoEsta.Fecha, 7, 4) = txtAno.Text Then
                varGraba(varMesGraba, 1) = varGraba(varMesGraba, 1) + txtSuma
            Else
                varGraba(varMesGraba, 2) = varGraba(varMesGraba, 2) + txtSuma
            End If

        Next

























        For txtCiclo = 1 To 12

            txtLinea = txtCiclo
            txtSuma = varGraba(txtCiclo, 1)
            txtSumaI = varGraba(txtCiclo, 2)
            txtSumaII = txtSuma - txtSumaI

            txtSumaTotal = txtSumaTotal + txtSuma
            txtSumaTotalI = txtSumaTotalI + txtSumaI

            If txtSuma <> 0 And txtSumaI <> 0 Then

                txtCampo1 = txtLinea
                txtCampo1 = ceros(txtCampo1, 2)
                txtCampo2 = txtCampo1 + " - " + txtImpreMes(txtCiclo)

                txtPorce = 0
                If txtSumaI <> 0 Then
                    txtPorce = redondeo(txtSumaII / txtSumaI * 100)
                End If

                SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSumaII, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)

            End If
        Next

        'If txtSumaTotal <> 0 And txtSumaTotalI <> 0 Then

        '    txtCampo1 = 99
        '    txtCampo1 = ceros(txtCampo1, 2)
        '    txtCampo2 = txtCampo1 + " - " + "Total"
        '    txtSumaTotalII = txtSumaTotal - txtSumaTotalI

        '    txtPorce = 0
        '    If txtSumaTotalI <> 0 Then
        '        txtPorce = redondeo(txtSumaTotalII / txtSumaTotalI * 100)
        '    End If

        '    SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSumaTotalII, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)

        'End If

        ProgressBar1.Visible = False

        txtUno = "{Grafico2.codigo} in 0 to 9999"
        txtDos = ""
        txtFormula = txtUno + txtDos

        If TipoListado.SelectedIndex <> 3 Then
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        Else
            Dim viewer As New ReportViewer("Emision de Graficos", Globals.reportPathWithName("WGraficoFactorNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        End If




    End Sub




    Private Sub Calcula_Costo(ByVal pasaArticulo As String)

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

        txtCosto = varCosto

    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        txtSalida = 0
        If TipoListadoII.SelectedIndex = 0 Then
            Call Proceso()
        Else
            If TipoListadoII.SelectedIndex = 1 Then
                Call ProcesoII()
            Else
                Call ProcesoIII()
            End If
        End If
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click
        txtSalida = 1
        If TipoListadoII.SelectedIndex = 0 Then
            Call Proceso()
        Else
            If TipoListadoII.SelectedIndex = 1 Then
                Call ProcesoII()
            Else
                Call ProcesoIII()
            End If
        End If
    End Sub


    Private Sub Busca_Nombre(ByVal pasaArticulo As String)

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

        txtDescripcion = varDescricpion

    End Sub


    Private Sub txtVendedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVendedorFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Dim tablaVendedor As DataTable
            tablaVendedor = SQLConnector.retrieveDataTable("buscar_vendedor_por_codigo", txtVendedorFiltro.Text)
            For Each row As DataRow In tablaVendedor.Rows
                Dim CampoVendedor As New Vendedor(row.Item(0), row.Item(1))
                DesVendedor.Text = CampoVendedor.nombre
            Next

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
        e.Handled = True
            txtVendedorFiltro.Text = ""
            DesVendedor.Text = Space$(20)
        End If

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Dim tablaCliente As DataTable
            tablaCliente = SQLConnector.retrieveDataTable("buscar_cliente_por_codigo", txtClienteFiltro.Text)
            For Each row As DataRow In tablaCliente.Rows
                Dim Campocliente As New Cliente(row.Item(0), row.Item(1))
                DesCliente.Text = Campocliente.razon
            Next

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtClienteFiltro.Text = ""
            DesCliente.Text = Space(20)
        End If

        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        '    Me.txtDesdeTerminado.SelectionStart = 0
        'End If

    End Sub

    Private Sub txtlinea_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLineaFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Dim tablalinea As DataTable
            tablalinea = SQLConnector.retrieveDataTable("buscar_linea", txtLineaFiltro.Text)
            For Each row As DataRow In tablalinea.Rows
                Dim CampoLinea As New Linea(row.Item(0), row.Item(1))
                DesLinea.Text = CampoLinea.nombre
            Next

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtLineaFiltro.Text = ""
            DesLinea.Text = Space(20)
        End If

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtRubro_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRubroFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Dim tablarubro As DataTable
            tablarubro = SQLConnector.retrieveDataTable("buscar_rubro", txtRubroFiltro.Text)
            For Each row As DataRow In tablarubro.Rows
                Dim CampoRubro As New Rubro(row.Item(0), row.Item(1))
                DesRubro.Text = CampoRubro.nombre
            Next

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtRubroFiltro.Text = ""
            DesRubro.Text = Space(20)
        End If

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub


    Private Sub txtTerminado_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTerminadoFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Dim tablaTerminado As DataTable
            tablaTerminado = SQLConnector.retrieveDataTable("buscar_terminado_por_codigo", txtTerminadoFiltro.Text)
            For Each row As DataRow In tablaTerminado.Rows
                Dim CampoTerminado As New LeeTerminado(row.Item(0), row.Item(1))
                DesTerminado.Text = CampoTerminado.Descripcion
            Next

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtTerminadoFiltro.Text = "  / /     "
            DesTerminado.Text = Space(20)
        End If

        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        '    Me.txtDesdeTerminado.SelectionStart = 0
        'End If

    End Sub


    Private Sub btnConsultaVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaVendedor.Click

        lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre("")
        varProcesoBusqueda = 0

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click

        lstAyuda.DataSource = DAOCliente.buscarClientePorNombre("")
        varProcesoBusqueda = 1

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub


    Private Sub btnConsultaLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaLinea.Click

        lstAyuda.DataSource = DAOLinea.buscarLineaPorNombre("")
        varProcesoBusqueda = 2

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub


    Private Sub btnConsultaRubro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaRubro.Click

        lstAyuda.DataSource = DAORubro.buscarRubroPorNombre("")
        varProcesoBusqueda = 3

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub


    Private Sub btnConsultaTerminado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaTerminado.Click

        lstAyuda.DataSource = DAOTerminado.buscarTerminadoPorNombre("")
        varProcesoBusqueda = 4

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
            Select Case varProcesoBusqueda
                Case 0
                    lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre(txtAyuda.Text)
                Case 1
                    lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
                Case 2
                    lstAyuda.DataSource = DAOLinea.buscarLineaPorNombre(txtAyuda.Text)
                Case 3
                    lstAyuda.DataSource = DAORubro.buscarRubroPorNombre(txtAyuda.Text)
                Case 4
                    lstAyuda.DataSource = DAOTerminado.buscarTerminadoPorNombre(txtAyuda.Text)
            End Select
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
        End If
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        Select Case varProcesoBusqueda
            Case 0
                mostrarvendedor(lstAyuda.SelectedValue)
            Case 1
                mostrarcliente(lstAyuda.SelectedValue)
            Case 2
                mostrarlinea(lstAyuda.SelectedValue)
            Case 3
                mostrarrubro(lstAyuda.SelectedValue)
            Case Else
                mostrarterminado(lstAyuda.SelectedValue)
        End Select
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub



    Private Sub mostrarcliente(ByVal cliente As Cliente)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        txtClienteFiltro.Text = cliente.id
        DesCliente.Text = cliente.razon
        txtClienteFiltro.Focus()
    End Sub

    Private Sub mostrarrubro(ByVal rubro As Rubro)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        txtRubroFiltro.Text = Rubro.id
        DesRubro.Text = Rubro.nombre
        txtRubroFiltro.Focus()
    End Sub

    Private Sub mostrarlinea(ByVal linea As Linea)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        txtLineaFiltro.Text = linea.id
        DesLinea.Text = linea.nombre
        txtLineaFiltro.Focus()
    End Sub

    Private Sub mostrarvendedor(ByVal vendedor As Vendedor)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        txtVendedorFiltro.Text = vendedor.id
        DesVendedor.Text = vendedor.nombre
        txtVendedorFiltro.Focus()
    End Sub

    Private Sub mostrarterminado(ByVal terminado As LeeTerminado)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        'txtDesdeTerminado.Text = LeeTerminado.Articulo
        'txtHastaTerminado.Text = LeeTerminado.Descripcion
        txtTerminadoFiltro.Focus()
    End Sub


    Private Sub TipoListadoII_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoListadoII.SelectedIndexChanged
        If TipoListadoII.SelectedIndex = 0 Or TipoListadoII.SelectedIndex = 2 Then
            ImpreAno.Text = "Año"
            ImpreAnoII.Visible = False
            txtAnoII.Visible = False
        Else
            ImpreAno.Text = "Desde Año"
            ImpreAnoII.Text = "Hasta Año"
            ImpreAnoII.Visible = True
            txtAnoII.Visible = True
        End If
        txtAno.Focus()
    End Sub

   
End Class