Imports ClasesCompartidas
Imports System.IO


Public Class ListadoGrafico

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

    Dim varGraba(1000, 10) As String

    Private Sub ListadoGrafico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReDim varListaMp(50000, 2)

        txtLugarMp = 0

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        TipoOrden.Items.Clear()
        TipoOrden.Items.Add("Linea")
        TipoOrden.Items.Add("Rubro")
        TipoOrden.Items.Add("Vendedor")
        TipoOrden.SelectedIndex = 0


        TipoCosto.Items.Clear()
        TipoCosto.Items.Add("Actual")
        TipoCosto.Items.Add("Fecha Facturacion")
        TipoCosto.SelectedIndex = 0


        TipoListado.Items.Clear()
        TipoListado.Items.Add("Cantidad")
        TipoListado.Items.Add("$")
        TipoListado.Items.Add("U$S")
        TipoListado.Items.Add("Factor")
        TipoListado.SelectedIndex = 0

        txtDesdeFecha.Focus()

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
                txtDesdeFecha.Focus()
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

        Dim txtPasa As Integer
        Dim txtCorte As Integer
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
        Dim txtRubro As Integer
        Dim txtVendedor As Integer
        Dim txtDesLinea As String
        Dim txtDesRubro As String
        Dim txtDesVendedor As String
        Dim WDesdeVendedor = 0, WHastaVendedor = 9999

        ReDim varGraba(1000, 10)

        txtLugar = 0

        txtDesde = ordenaFecha(txtDesdeFecha.Text)
        txtHasta = ordenaFecha(txthastafecha.Text)

        txtTitulo = ""

        'If Vendedor.permisos <> 99 Then
        '    WDesdeVendedor = Vendedor.permisos
        '    WHastaVendedor = Vendedor.permisos
        'End If


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
            tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productos", WDesdeVendedor, WHastaVendedor, 0, 9999, 0, 9999, "", "Z999999", "", "ZZ-99999-999", txtDesde, txtHasta)

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

        Select Case TipoOrden.SelectedIndex

            Case 0
                txtTitulo = "Ventas por linea del " + txtDesdeFecha.Text + " al " + txthastafecha.Text



                Dim tablaII As DataTable
                tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_linea", txtDesde, txtHasta)

                For Each row As DataRow In tablaII.Rows

                    Dim CampoEsta As New LeeEstadisticaRanking(row.Item(0), row.Item(1).ToString, row.Item(2),
                                                   row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9))

                    If txtPasa = 0 Then
                        txtPasa = 1
                        txtCorte = CampoEsta.Linea
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If txtCorte <> CampoEsta.Linea Then
                        txtLugar = txtLugar + 1
                        varGraba(txtLugar, 1) = txtCorte
                        varGraba(txtLugar, 2) = Str(txtSuma)
                        varGraba(txtLugar, 3) = Str(txtSumaI)
                        txtCorte = CampoEsta.Linea
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If Val(CampoEsta.Tipo) = 1 Then
                        txtCantidad = CampoEsta.Cantidad
                    Else
                        txtCantidad = CampoEsta.Cantidad * -1
                    End If

                    If TipoListado.SelectedIndex = 0 Then
                        txtSuma = txtSuma + txtCantidad
                        txtSumaII = txtSumaII + txtCantidad
                        txtTituloII = "Cantidad"
                    Else
                        If TipoListado.SelectedIndex = 1 Then
                            txtSuma = txtSuma + CampoEsta.Importe
                            txtSumaII = txtSumaII + CampoEsta.Importe
                            txtTituloII = "Pesos"
                        Else
                            If TipoListado.SelectedIndex = 2 Then
                                txtSuma = txtSuma + CampoEsta.ImporteUs
                                txtSumaII = txtSumaII + CampoEsta.ImporteUs
                                txtTituloII = "Dolares"
                            Else
                                If TipoListado.SelectedIndex = 3 Then
                                    txtSuma = txtSuma + CampoEsta.ImporteUs
                                    txtSumaI = txtSumaI + CampoEsta.Costo2
                                    txtTituloII = "Factor"
                                    If TipoCosto.SelectedIndex = 0 Then
                                        txtTituloII = txtTituloII + " (Costo Actual)"
                                    Else
                                        txtTituloII = txtTituloII + " (Costo Historico)"
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                If txtSuma <> 0 Then
                    txtLugar = txtLugar + 1
                    varGraba(txtLugar, 1) = txtCorte
                    varGraba(txtLugar, 2) = Str(txtSuma)
                End If

                txtResto = 0

                For txtCiclo = 1 To txtLugar

                    txtLinea = Val(varGraba(txtCiclo, 1))
                    txtSuma = Val(varGraba(txtCiclo, 2))
                    txtSumaI = Val(varGraba(txtCiclo, 3))
                    txtDesLinea = ""

                    If TipoListado.SelectedIndex = 3 Then
                        If txtSuma <> 0 And txtSumaI <> 0 Then
                            txtFactor = txtSuma / txtSumaI
                        Else
                            txtFactor = 0
                        End If
                    End If

                    Dim tablaLinea As DataTable
                    tablaLinea = SQLConnector.retrieveDataTable("buscar_linea", txtLinea)
                    For Each row As DataRow In tablaLinea.Rows
                        Dim CampoLinea As New Linea(row.Item(0), row.Item(1))
                        txtDesLinea = CampoLinea.nombre
                    Next

                    txtCampo1 = txtLinea
                    txtCampo1 = ceros(txtCampo1, 2)

                    txtCampo2 = txtCampo1 + " - " + leederecha(txtDesLinea, 40)
                    txtPorce = redondeo(txtSuma / txtSumaII * 100)

                    If TipoListado.SelectedIndex <> 3 Then
                        If txtPorce > 1 Then
                            SQLConnector.executeProcedure("alta_grafico", txtLinea, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        Else
                            txtResto = txtResto + txtSuma
                        End If
                    Else
                        If txtFactor <> 0 And txtLinea <> 20 Then
                            SQLConnector.executeProcedure("alta_grafico", txtLinea, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        End If
                    End If
                Next

                If txtResto > 0 Then
                    txtCampo1 = "99"

                    txtCampo2 = txtCampo1 + " - " + "Varios"
                    txtPorce = redondeo(txtResto / txtSumaII * 100)

                    SQLConnector.executeProcedure("alta_grafico", 99, txtResto, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                End If

                ProgressBar1.Visible = False

                txtUno = "{Grafico2.codigo} in " & WDesdeVendedor & " to " & WHastaVendedor
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





            Case 1
                txtTitulo = "Ventas por Rubro del " + txtDesdeFecha.Text + " al " + txthastafecha.Text



                Dim tablaII As DataTable
                tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_rubro", txtDesde, txtHasta)

                For Each row As DataRow In tablaII.Rows

                    Dim CampoEsta As New LeeEstadisticaRankingOtro(row.Item(0), row.Item(1).ToString, row.Item(2),
                                                   row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11))

                    If txtPasa = 0 Then
                        txtPasa = 1
                        txtCorte = CampoEsta.Rubro
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If txtCorte <> CampoEsta.Rubro Then
                        txtLugar = txtLugar + 1
                        varGraba(txtLugar, 1) = txtCorte
                        varGraba(txtLugar, 2) = Str(txtSuma)
                        varGraba(txtLugar, 3) = Str(txtSumaI)
                        txtCorte = CampoEsta.Rubro
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If Val(CampoEsta.Tipo) = 1 Then
                        txtCantidad = CampoEsta.Cantidad
                    Else
                        txtCantidad = CampoEsta.Cantidad * -1
                    End If

                    If TipoListado.SelectedIndex = 0 Then
                        txtSuma = txtSuma + txtCantidad
                        txtSumaII = txtSumaII + txtCantidad
                        txtTituloII = "Cantidad"
                    Else
                        If TipoListado.SelectedIndex = 1 Then
                            txtSuma = txtSuma + CampoEsta.Importe
                            txtSumaII = txtSumaII + CampoEsta.Importe
                            txtTituloII = "Pesos"
                        Else
                            If TipoListado.SelectedIndex = 2 Then
                                txtSuma = txtSuma + CampoEsta.ImporteUs
                                txtSumaII = txtSumaII + CampoEsta.ImporteUs
                                txtTituloII = "Dolares"
                            Else
                                If TipoListado.SelectedIndex = 3 Then
                                    txtSuma = txtSuma + CampoEsta.ImporteUs
                                    txtSumaI = txtSumaI + CampoEsta.Costo2
                                    txtTituloII = "Factor"
                                    If TipoCosto.SelectedIndex = 0 Then
                                        txtTituloII = txtTituloII + " (Costo Actual)"
                                    Else
                                        txtTituloII = txtTituloII + " (Costo Historico)"
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                If txtSuma <> 0 Then
                    txtLugar = txtLugar + 1
                    varGraba(txtLugar, 1) = txtCorte
                    varGraba(txtLugar, 2) = Str(txtSuma)
                End If

                txtResto = 0

                For txtCiclo = 1 To txtLugar

                    txtRubro = Val(varGraba(txtCiclo, 1))
                    txtSuma = Val(varGraba(txtCiclo, 2))
                    txtSumaI = Val(varGraba(txtCiclo, 3))
                    txtDesRubro = ""

                    If TipoListado.SelectedIndex = 3 Then
                        If txtSuma <> 0 And txtSumaI <> 0 Then
                            txtFactor = txtSuma / txtSumaI
                        Else
                            txtFactor = 0
                        End If
                    End If

                    Dim tablaRubro As DataTable
                    tablaRubro = SQLConnector.retrieveDataTable("buscar_rubro", txtRubro)
                    For Each row As DataRow In tablaRubro.Rows
                        Dim CampoRubro As New Rubro(row.Item(0), row.Item(1))
                        txtDesRubro = CampoRubro.nombre
                    Next

                    txtCampo1 = txtRubro
                    txtCampo1 = ceros(txtCampo1, 2)

                    txtCampo2 = txtCampo1 + " - " + leederecha(txtDesRubro, 40)
                    txtPorce = redondeo(txtSuma / txtSumaII * 100)

                    If TipoListado.SelectedIndex <> 3 Then
                        If txtPorce > 1 Then
                            SQLConnector.executeProcedure("alta_grafico", txtRubro, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        Else
                            txtResto = txtResto + txtSuma
                        End If
                    Else
                        If txtFactor <> 0 Then
                            SQLConnector.executeProcedure("alta_grafico", txtRubro, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        End If
                    End If
                Next

                If txtResto > 0 Then
                    txtCampo1 = "99"

                    txtCampo2 = txtCampo1 + " - " + "Varios"
                    txtPorce = redondeo(txtResto / txtSumaII * 100)

                    SQLConnector.executeProcedure("alta_grafico", 99, txtResto, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                End If

                ProgressBar1.Visible = False

                txtUno = "{Grafico2.codigo} in " & WDesdeVendedor & " to " & WHastaVendedor
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




            Case Else
                txtTitulo = "Ventas por Vendedor del " + txtDesdeFecha.Text + " al " + txthastafecha.Text



                Dim tablaII As DataTable
                tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_vendedor", txtDesde, txtHasta)

                For Each row As DataRow In tablaII.Rows

                    Dim CampoEsta As New LeeEstadisticaRankingOtro(row.Item(0), row.Item(1).ToString, row.Item(2),
                                                   row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11))

                    If txtPasa = 0 Then
                        txtPasa = 1
                        txtCorte = CampoEsta.Vendedor
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If txtCorte <> CampoEsta.Vendedor Then
                        txtLugar = txtLugar + 1
                        varGraba(txtLugar, 1) = txtCorte
                        varGraba(txtLugar, 2) = Str(txtSuma)
                        varGraba(txtLugar, 3) = Str(txtSumaI)
                        txtCorte = CampoEsta.Vendedor
                        txtSuma = 0
                        txtSumaI = 0
                    End If

                    If Val(CampoEsta.Tipo) = 1 Then
                        txtCantidad = CampoEsta.Cantidad
                    Else
                        txtCantidad = CampoEsta.Cantidad * -1
                    End If

                    If TipoListado.SelectedIndex = 0 Then
                        txtSuma = txtSuma + txtCantidad
                        txtSumaII = txtSumaII + txtCantidad
                        txtTituloII = "Cantidad"
                    Else
                        If TipoListado.SelectedIndex = 1 Then
                            txtSuma = txtSuma + CampoEsta.Importe
                            txtSumaII = txtSumaII + CampoEsta.Importe
                            txtTituloII = "Pesos"
                        Else
                            If TipoListado.SelectedIndex = 2 Then
                                txtSuma = txtSuma + CampoEsta.ImporteUs
                                txtSumaII = txtSumaII + CampoEsta.ImporteUs
                                txtTituloII = "Dolares"
                            Else
                                If TipoListado.SelectedIndex = 3 Then
                                    txtSuma = txtSuma + CampoEsta.ImporteUs
                                    txtSumaI = txtSumaI + CampoEsta.Costo2
                                    txtTituloII = "Factor"
                                    If TipoCosto.SelectedIndex = 0 Then
                                        txtTituloII = txtTituloII + " (Costo Actual)"
                                    Else
                                        txtTituloII = txtTituloII + " (Costo Historico)"
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                If txtSuma <> 0 Then
                    txtLugar = txtLugar + 1
                    varGraba(txtLugar, 1) = txtCorte
                    varGraba(txtLugar, 2) = Str(txtSuma)
                End If

                txtResto = 0

                For txtCiclo = 1 To txtLugar

                    txtVendedor = Val(varGraba(txtCiclo, 1))
                    txtSuma = Val(varGraba(txtCiclo, 2))
                    txtSumaI = Val(varGraba(txtCiclo, 3))
                    txtDesVendedor = ""

                    If TipoListado.SelectedIndex = 3 Then
                        If txtSuma <> 0 And txtSumaI <> 0 Then
                            txtFactor = txtSuma / txtSumaI
                        Else
                            txtFactor = 0
                        End If
                    End If

                    Dim tablaVendedor As DataTable
                    tablaVendedor = SQLConnector.retrieveDataTable("buscar_vendedor_por_codigo", txtVendedor)
                    For Each row As DataRow In tablaVendedor.Rows
                        Dim CampoVendedor As New Vendedor(row.Item(0), row.Item(1))
                        txtDesVendedor = CampoVendedor.nombre
                    Next

                    txtCampo1 = txtVendedor
                    txtCampo1 = ceros(txtCampo1, 2)

                    txtCampo2 = txtCampo1 + " - " + leederecha(txtDesVendedor, 40)
                    txtPorce = redondeo(txtSuma / txtSumaII * 100)

                    If TipoListado.SelectedIndex <> 3 Then
                        If txtPorce > 1 Then
                            SQLConnector.executeProcedure("alta_grafico", txtVendedor, txtSuma, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        Else
                            txtResto = txtResto + txtSuma
                        End If
                    Else
                        If txtFactor <> 0 Then
                            SQLConnector.executeProcedure("alta_grafico", txtVendedor, txtFactor, 0, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                        End If
                    End If
                Next

                If txtResto > 0 Then
                    txtCampo1 = "99"

                    txtCampo2 = txtCampo1 + " - " + "Varios"
                    txtPorce = redondeo(txtResto / txtSumaII * 100)

                    SQLConnector.executeProcedure("alta_grafico", 99, txtResto, txtPorce, txtTitulo, txtTituloII, txtCampo1, txtCampo2)
                End If

                ProgressBar1.Visible = False

                txtUno = "{Grafico2.codigo} in " & WDesdeVendedor & " to " & WHastaVendedor
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



        End Select

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
        Call Proceso()
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click
        txtSalida = 1
        Call Proceso()
    End Sub

End Class