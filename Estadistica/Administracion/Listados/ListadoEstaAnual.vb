Imports ClasesCompartidas
Imports System.IO

Public Class ListadoEstaAnual

    Dim varVector(,) As String
    Dim varAuxiliar(,) As String
    Dim txtLugarMp As Integer
    Dim txtTitulo As String
    Dim txtSalida As Integer

    Dim varImpo() As Double
    Dim varTitulo(,) As String
    Dim varMes() As Integer
    Dim varAno() As Integer

    Dim txtDescripcion As String
    Dim varPasaCampo As String
    Dim varProcesoBusqueda As Integer

    Private Sub ListadoEstaAnual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        DesCliente.Text = ""
        DesVendedor.Text = ""

        TipoDY.Checked = False


        txtDesdeTerminado.Text = "AA-00000-000"
        txtHastaTerminado.Text = "ZZ-99999-999"

        TipoListado.Items.Clear()
        TipoListado.Items.Add("Cantidad")
        TipoListado.Items.Add("$")
        TipoListado.Items.Add("U$S")
        TipoListado.SelectedIndex = 0

        txtDesdeTerminado.Focus()
        txtDesdeTerminado.SelectionStart = 0

        _HabilitarSegunVendedor()

    End Sub

    Private Sub _HabilitarSegunVendedor()
        If Vendedor.permisos <> 99 Then

            txtVendedorFiltro.Text = Vendedor.permisos
            txtVendedorFiltro.Enabled = False

            btnCliente.PerformClick()
            btnCliente.Visible = False

        End If
    End Sub

    Private Sub txtdesdeterminado_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeTerminado.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeTerminado.Text = UCase(txtDesdeTerminado.Text)
            txtHastaTerminado.Focus()
            txtHastaTerminado.SelectionStart = 0
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeTerminado.Text = "  -     -   "
            txtDesdeTerminado.SelectionStart = 0
        End If
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        '    Me.txtDesdeTerminado.SelectionStart = 0
        'End If
    End Sub

    Private Sub txthastaterminado_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaTerminado.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaTerminado.Text = UCase(txtHastaTerminado.Text)
            txtDesdeFecha.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaTerminado.Text = "  -     -   "
            txtHastaTerminado.SelectionStart = 0
        End If
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        '    Me.txtHastaTerminado.SelectionStart = 0
        'End If
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
                txtDesdeTerminado.Focus()
                txtDesdeTerminado.SelectionStart = 0
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(610, 460)

        lstAyuda.DataSource = DAOTerminado.buscarTerminadoPorNombre("")
        varProcesoBusqueda = 0

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
                    lstAyuda.DataSource = DAOTerminado.buscarTerminadoPorNombre(txtAyuda.Text)
                Case 1
                    lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre(txtAyuda.Text)
                Case 2
                    lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
            End Select
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
        End If
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

        Dim txtCantidad As Double
        Dim txtPasa As String
        Dim txtCorte As String

        Dim txtClave As String
        Dim txtcliente As String
        Dim txtLinea As String
        Dim txtArticulo As String

        Dim varImporte As Double

        Dim varMesCicla As Integer
        Dim varAnoCicla As Integer
        Dim varMesFin As Integer
        Dim varAnoFin As Integer
        Dim varSumaMes As String
        Dim varMeses As Integer
        Dim txtMes As String
        Dim txtAno As String
        Dim varMesGraba As String
        Dim varTituloII As String
        Dim txtCorteTipoDY As String
        Dim txtDesdeVendedor As Integer
        Dim txtHastaVendedor As Integer
        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String

        Dim varTotalImpo As Double
        Dim varPromedio As Double

        ReDim varImpo(100)
        ReDim varTitulo(100, 2)
        ReDim varAno(100)
        ReDim varMes(100)
        ReDim varImpo(100)

        txtDesde = ordenaFecha(txtDesdeFecha.Text)
        txtHasta = ordenaFecha(txthastafecha.Text)

        txtPasa = 0
        txtCorte = ""
        txtDescripcion = ""
        txtLinea = 0

        varMesCicla = Val(Mid(txtDesdeFecha.Text, 4, 2))
        varAnoCicla = Val(Mid(txtDesdeFecha.Text, 7, 4))
        varMesFin = Val(Mid(txthastafecha.Text, 4, 2))
        varAnoFin = Val(Mid(txthastafecha.Text, 7, 4))
        varSumaMes = "S"
        varMeses = 0

        varTituloII = ""
        txtCorteTipoDY = ""

        If TipoDY.Checked = True Then
            If leederecha(txtDesdeTerminado.Text, 2) <> "DY" Then
                txtDesdeTerminado.Text = "DY-00000-000"
            End If
            If leederecha(txtHastaTerminado.Text, 2) <> "DY" Then
                txtHastaTerminado.Text = "DY-99999-999"
            End If
        End If

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "Z99999"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
        End If

        If Val(txtVendedorFiltro.Text) = 0 Then
            txtDesdeVendedor = 0
            txtHastaVendedor = 9999
        Else
            txtDesdeVendedor = Val(txtVendedorFiltro.Text)
            txtHastaVendedor = Val(txtVendedorFiltro.Text)
        End If

        For Ciclo = 1 To 12

            If varSumaMes = "S" Then
                varMeses = varMeses + 1
            End If
            If varMesCicla = varMesFin And varAnoCicla = varAnoFin Then
                varSumaMes = "N"
            End If

            varMes(Ciclo) = Str$(varMesCicla)
            varAno(Ciclo) = Str$(varAnoCicla)
            txtMes = varMes(Ciclo)
            txtAno = varAno(Ciclo)
            varTitulo(Ciclo, 1) = txtMes + "/" + txtAno
            varTitulo(Ciclo, 2) = ceros(txtMes, 2) + ceros(txtAno, 4)

            varMesCicla = varMesCicla + 1
            If varMesCicla > 12 Then
                varMesCicla = 1
                varAnoCicla = varAnoCicla + 1
            End If

        Next Ciclo


        ProgressBar1.Visible = True
        With ProgressBar1
            ProgressBar1.Maximum = 5000
            ProgressBar1.Minimum = 0
            ProgressBar1.Value = 0
        End With

        txtTitulo = "Del " + txtDesdeFecha.Text + " al " + txthastafecha.Text
        txtDesdeTerminado.Text = UCase(txtDesdeTerminado.Text)
        txtHastaTerminado.Text = UCase(txtHastaTerminado.Text)


        SQLConnector.retrieveDataTable("limpiar_estaanu")



        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productosII", 0, 9999, 0, 9999, 0, 9999, "", "Z99999", txtDesdeTerminado.Text, txtHastaTerminado.Text, txtDesde, txtHasta)

        For Each row As DataRow In tabla.Rows

            Dim CampoEstadistica As New LeeEstadisticaProducto(row.Item(0).ToString)

            txtArticulo = CampoEstadistica.Articulo

            Busca_Nombre(txtArticulo)
            SQLConnector.executeProcedure("Modifica_Estadistica_DescriTerminado", txtDesde, txtHasta, txtArticulo, txtDescripcion)

            varBarra = varBarra + 1
            If varBarra > 5000 Then
                varBarra = 1
            End If
            ProgressBar1.Value = varBarra

        Next




        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_producto_anual", txtDesde, txtHasta, txtDesdeTerminado.Text, txtHastaTerminado.Text, txtDesdeVendedor, txtHastaVendedor, txtDesdeCliente, txtHastaCliente)

        For Each row As DataRow In tablaII.Rows

            Dim CampoEsta As New LeeEstadisticaRanking(row.Item(0), row.Item(1).ToString, row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9))

            varBarra = varBarra + 1
            If varBarra > 5000 Then
                varBarra = 1
            End If
            ProgressBar1.Value = varBarra


            If txtPasa = 0 Then
                txtPasa = 1
                txtCorte = CampoEsta.Articulo
                txtDescripcion = CampoEsta.DescriTerminado
                ReDim varImpo(100)
            End If

            If txtCorte <> CampoEsta.Articulo Then

                varSuma = varSuma + 1

                txtClave = LTrim(RTrim(txtCorte))
                txtcliente = ""
                txtLinea = 0
                txtArticulo = LTrim(RTrim(txtCorte))
                txtCorteTipoDY = leederecha(txtDescripcion, 5)

                varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10) + varImpo(11) + varImpo(12)
                If varMeses <> 0 Then
                    varPromedio = varTotalImpo / varMeses
                Else
                    varPromedio = 0
                End If

                SQLConnector.executeProcedure("alta_estaanu", txtCorte, "", txtCorte, txtDescripcion, txtCorteTipoDY, txtLinea, varImpo(1), varTitulo(1, 1), varImpo(2), varTitulo(2, 1), varImpo(3), varTitulo(3, 1), varImpo(4), varTitulo(4, 1),
                                              varImpo(5), varTitulo(5, 1), varImpo(6), varTitulo(6, 1), varImpo(7), varTitulo(7, 1), varImpo(8), varTitulo(8, 1), varImpo(9), varTitulo(9, 1), varImpo(10), varTitulo(10, 1), varImpo(11), varTitulo(11, 1), varImpo(12), varTitulo(12, 1), varPromedio, txtTitulo, varTituloII)

                txtCorte = CampoEsta.Articulo
                txtDescripcion = CampoEsta.DescriTerminado
                ReDim varImpo(100)

            End If

            If Val(CampoEsta.Tipo) = 1 Then
                txtCantidad = CampoEsta.Cantidad
            Else
                txtCantidad = CampoEsta.Cantidad * -1
            End If

            Select Case TipoListado.SelectedIndex
                Case 0
                    varImporte = txtCantidad
                    varTituloII = "Cantidad"
                Case 1
                    varImporte = CampoEsta.Importe
                    varTituloII = "Pesos"
                Case 2
                    varImporte = CampoEsta.ImporteUs
                    varTituloII = "Dolares"
                Case Else
            End Select

            varMesGraba = Mid(CampoEsta.Fecha, 4, 2) + Mid(CampoEsta.Fecha, 7, 4)
            For txtCicla = 1 To 12
                If varMesGraba = varTitulo(txtCicla, 2) Then
                    varImpo(txtCicla) = varImpo(txtCicla) + varImporte
                End If
            Next

        Next


        If txtPasa <> 0 Then
            varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10) + varImpo(11) + varImpo(12)
            If varMeses <> 0 Then
                varPromedio = varTotalImpo / varMeses
            Else
                varPromedio = 0
            End If

            SQLConnector.executeProcedure("alta_estaanu", txtCorte, "", txtCorte, txtDescripcion, txtCorteTipoDY, txtLinea, varImpo(1), varTitulo(1, 1), varImpo(2), varTitulo(2, 1), varImpo(3), varTitulo(3, 1), varImpo(4), varTitulo(4, 1),
                                          varImpo(5), varTitulo(5, 1), varImpo(6), varTitulo(6, 1), varImpo(7), varTitulo(7, 1), varImpo(8), varTitulo(8, 1), varImpo(9), varTitulo(9, 1), varImpo(10), varTitulo(10, 1), varImpo(11), varTitulo(11, 1), varImpo(12), varTitulo(12, 1), varPromedio, txtTitulo, varTituloII)
        End If


        REM txtDos = Globals.reportPathWithName("WGraficoNet.rpt")


        ProgressBar1.Visible = False

        txtUno = "{EstaAnu.Codigo} in " + x + "AA-00000-000" + x + " to " + x + "ZZ-99999-999" + x
        txtDos = ""
        txtFormula = txtUno + txtDos

        If TipoDY.Checked = True Then
            Dim viewer As New ReportViewer("Listado de Venta Anual", Globals.reportPathWithName("WEstaAnuDyNet.rpt"), txtFormula)
            If txtSalida = 0 Then
                viewer.Show()
            Else
                viewer.imprimirReporte()
            End If
        Else
            If LTrim(RTrim(txtClienteFiltro.Text)) <> "" Or Val(txtVendedorFiltro.Text) <> 0 Then
                Dim viewer As New ReportViewer("Listado de Venta Anual", Globals.reportPathWithName("WEstaAnuClienteNet.rpt"), txtFormula)
                If txtSalida = 0 Then
                    viewer.Show()
                Else
                    viewer.imprimirReporte()
                End If
            Else
                Dim viewer As New ReportViewer("Listado de Venta Anual", Globals.reportPathWithName("WEstaAnuNet.rpt"), txtFormula)
                If txtSalida = 0 Then
                    viewer.Show()
                Else
                    viewer.imprimirReporte()
                End If
            End If
        End If


    End Sub


    Private Sub ProcesoCliente()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim varBarra As Integer

        Dim varSuma As Integer

        Dim txtCantidad As Double
        Dim txtPasa As String
        Dim txtCorte As String
        Dim txtCorteII As String

        Dim txtClave As String
        Dim txtcliente As String
        Dim txtLinea As String
        Dim txtArticulo As String

        Dim varImporte As Double

        Dim varMesCicla As Integer
        Dim varAnoCicla As Integer
        Dim varMesFin As Integer
        Dim varAnoFin As Integer
        Dim varSumaMes As String
        Dim varMeses As Integer
        Dim txtMes As String
        Dim txtAno As String
        Dim varMesGraba As String
        Dim varTituloII As String
        Dim txtCorteTipoDY As String
        Dim txtDesdeVendedor As Integer
        Dim txtHastaVendedor As Integer
        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String

        Dim varTotalImpo As Double
        Dim varPromedio As Double

        ReDim varImpo(100)
        ReDim varTitulo(100, 2)
        ReDim varAno(100)
        ReDim varMes(100)
        ReDim varImpo(100)

        txtDesde = ordenaFecha(txtDesdeFecha.Text)
        txtHasta = ordenaFecha(txthastafecha.Text)

        txtPasa = 0
        txtCorte = ""
        txtCorteII = ""
        txtDescripcion = ""
        txtLinea = 0

        varMesCicla = Val(Mid(txtDesdeFecha.Text, 4, 2))
        varAnoCicla = Val(Mid(txtDesdeFecha.Text, 7, 4))
        varMesFin = Val(Mid(txthastafecha.Text, 4, 2))
        varAnoFin = Val(Mid(txthastafecha.Text, 7, 4))
        varSumaMes = "S"
        varMeses = 0

        varTituloII = ""
        txtCorteTipoDY = ""

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "Z99999"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
        End If

        If Val(txtVendedorFiltro.Text) = 0 Then
            txtDesdeVendedor = 0
            txtHastaVendedor = 9999
        Else
            txtDesdeVendedor = Val(txtVendedorFiltro.Text)
            txtHastaVendedor = Val(txtVendedorFiltro.Text)
        End If

        For Ciclo = 1 To 12

            If varSumaMes = "S" Then
                varMeses = varMeses + 1
            End If
            If varMesCicla = varMesFin And varAnoCicla = varAnoFin Then
                varSumaMes = "N"
            End If

            varMes(Ciclo) = Str$(varMesCicla)
            varAno(Ciclo) = Str$(varAnoCicla)
            txtMes = varMes(Ciclo)
            txtAno = varAno(Ciclo)
            varTitulo(Ciclo, 1) = txtMes + "/" + txtAno
            varTitulo(Ciclo, 2) = ceros(txtMes, 2) + ceros(txtAno, 4)

            varMesCicla = varMesCicla + 1
            If varMesCicla > 12 Then
                varMesCicla = 1
                varAnoCicla = varAnoCicla + 1
            End If

        Next Ciclo


        ProgressBar1.Visible = True
        With ProgressBar1
            ProgressBar1.Maximum = 5000
            ProgressBar1.Minimum = 0
            ProgressBar1.Value = 0
        End With

        txtTitulo = "Del " + txtDesdeFecha.Text + " al " + txthastafecha.Text
        txtDesdeTerminado.Text = UCase(txtDesdeTerminado.Text)
        txtHastaTerminado.Text = UCase(txtHastaTerminado.Text)


        SQLConnector.retrieveDataTable("limpiar_estaanu")


        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_producto_anual", txtDesde, txtHasta, txtDesdeTerminado.Text, txtHastaTerminado.Text, txtDesdeVendedor, txtHastaVendedor, txtDesdeCliente, txtHastaCliente)

        For Each row As DataRow In tablaII.Rows

            Dim CampoEsta As New LeeEstadisticaRanking(row.Item(0), row.Item(1).ToString, row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9))

            varBarra = varBarra + 1
            If varBarra > 5000 Then
                varBarra = 1
            End If
            ProgressBar1.Value = varBarra


            If txtPasa = 0 Then
                txtPasa = 1
                txtCorte = CampoEsta.Articulo
                txtCorteII = CampoEsta.Cliente
                txtDescripcion = CampoEsta.DescriTerminado
                ReDim varImpo(100)
            End If

            If txtCorte <> CampoEsta.Articulo Or txtCorteII <> CampoEsta.Cliente Then

                varSuma = varSuma + 1

                txtClave = LTrim(RTrim(txtCorte))
                txtcliente = txtCorteII
                txtLinea = 0
                txtArticulo = LTrim(RTrim(txtCorte))
                txtCorteTipoDY = leederecha(txtDescripcion, 5)

                varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10) + varImpo(11) + varImpo(12)
                If varMeses <> 0 Then
                    varPromedio = varTotalImpo / varMeses
                Else
                    varPromedio = 0
                End If

                SQLConnector.executeProcedure("alta_estaanu", txtCorte, txtcliente, txtCorte, txtDescripcion, txtCorteTipoDY, txtLinea, varImpo(1), varTitulo(1, 1), varImpo(2), varTitulo(2, 1), varImpo(3), varTitulo(3, 1), varImpo(4), varTitulo(4, 1),
                                              varImpo(5), varTitulo(5, 1), varImpo(6), varTitulo(6, 1), varImpo(7), varTitulo(7, 1), varImpo(8), varTitulo(8, 1), varImpo(9), varTitulo(9, 1), varImpo(10), varTitulo(10, 1), varImpo(11), varTitulo(11, 1), varImpo(12), varTitulo(12, 1), varPromedio, txtTitulo, varTituloII)

                txtCorte = CampoEsta.Articulo
                txtCorteII = CampoEsta.Cliente
                txtDescripcion = CampoEsta.DescriTerminado
                ReDim varImpo(100)

            End If

            If Val(CampoEsta.Tipo) = 1 Then
                txtCantidad = CampoEsta.Cantidad
            Else
                txtCantidad = CampoEsta.Cantidad * -1
            End If

            Select Case TipoListado.SelectedIndex
                Case 0
                    varImporte = txtCantidad
                    varTituloII = "Cantidad"
                Case 1
                    varImporte = CampoEsta.Importe
                    varTituloII = "Pesos"
                Case 2
                    varImporte = CampoEsta.ImporteUs
                    varTituloII = "Dolares"
                Case Else
            End Select


            varMesGraba = Mid(CampoEsta.Fecha, 4, 2) + Mid(CampoEsta.Fecha, 7, 4)
            For txtCicla = 1 To 12
                If varMesGraba = varTitulo(txtCicla, 2) Then
                    varImpo(txtCicla) = varImpo(txtCicla) + varImporte
                End If
            Next

        Next


        If txtPasa <> 0 Then

            varSuma = varSuma + 1

            txtClave = LTrim(RTrim(txtCorte))
            txtcliente = txtCorteII
            txtLinea = 0
            txtArticulo = LTrim(RTrim(txtCorte))
            txtCorteTipoDY = leederecha(txtDescripcion, 5)

            varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10) + varImpo(11) + varImpo(12)
            If varMeses <> 0 Then
                varPromedio = varTotalImpo / varMeses
            Else
                varPromedio = 0
            End If

            SQLConnector.executeProcedure("alta_estaanu", txtCorte, txtcliente, txtCorte, txtDescripcion, txtCorteTipoDY, txtLinea, varImpo(1), varTitulo(1, 1), varImpo(2), varTitulo(2, 1), varImpo(3), varTitulo(3, 1), varImpo(4), varTitulo(4, 1),
                                          varImpo(5), varTitulo(5, 1), varImpo(6), varTitulo(6, 1), varImpo(7), varTitulo(7, 1), varImpo(8), varTitulo(8, 1), varImpo(9), varTitulo(9, 1), varImpo(10), varTitulo(10, 1), varImpo(11), varTitulo(11, 1), varImpo(12), varTitulo(12, 1), varPromedio, txtTitulo, varTituloII)
        End If



        txtUno = "{EstaAnu.Codigo} in " + x + "AA-00000-000" + x + " to " + x + "ZZ-99999-999" + x
        txtDos = ""
        txtFormula = txtUno + txtDos

        'txtFormula = ""
        'Dim viewer As New ReportViewer("Listado de Venta Anual", Globals.reportPathWithName("WGraficoNet.rpt"), txtFormula)
        Dim viewer As New ReportViewer("Listado de Venta Anual", Globals.reportPathWithName("WEstaAnuClienteNet.rpt"), txtFormula)
        If txtSalida = 0 Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
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

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        txtSalida = 0
        txtVendedorFiltro.Text = ""
        txtClienteFiltro.Text = ""
        Call Proceso()
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click
        txtSalida = 1
        txtVendedorFiltro.Text = ""
        txtClienteFiltro.Text = ""
        Call Proceso()
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click

        PantaDatos.Width = 543
        PantaDatos.Height = 138

        PantaDatos.Visible = True

        txtVendedorFiltro.Focus()

    End Sub


    Private Sub btnPantallaII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantallaII.Click
        txtSalida = 0
        PantaDatos.Visible = False
        Call ProcesoCliente()
    End Sub

    Private Sub btnImpresoraII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresoraII.Click
        txtSalida = 1
        PantaDatos.Visible = False
        Call ProcesoCliente()
    End Sub

    Private Sub btnCancelaII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaII.Click
        PantaDatos.Visible = False
    End Sub

    Private Sub txtVendedor_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVendedorFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            varPasaCampo = "N"
            Dim tablaVendedor As DataTable
            tablaVendedor = SQLConnector.retrieveDataTable("buscar_vendedor_por_codigo", txtVendedorFiltro.Text)
            For Each row As DataRow In tablaVendedor.Rows
                Dim CampoVendedor As New Vendedor(row.Item(0), row.Item(1))
                varPasaCampo = "S"
                DesVendedor.Text = CampoVendedor.nombre
            Next
            If varPasaCampo = "S" Or Val(txtVendedorFiltro.Text) = 0 Then
                txtClienteFiltro.Focus()
            End If

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtVendedorFiltro.Text = ""
        End If

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub



    Private Sub txtCliente_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            varPasaCampo = "N"
            Dim tablaCliente As DataTable
            tablaCliente = SQLConnector.retrieveDataTable("buscar_cliente_por_codigo", txtClienteFiltro.Text)
            For Each row As DataRow In tablaCliente.Rows
                Dim Campocliente As New Cliente(row.Item(0), row.Item(1))
                varPasaCampo = "S"
                DesCliente.Text = Campocliente.razon
            Next
            If varPasaCampo = "S" Or LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
                txtVendedorFiltro.Focus()
            End If

        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtClienteFiltro.Text = ""
        End If

        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        '    Me.txtDesdeTerminado.SelectionStart = 0
        'End If

    End Sub



    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click

        Me.Size = New System.Drawing.Size(580, 460)

        lstAyuda.DataSource = DAOCliente.buscarClientePorNombre("")
        varProcesoBusqueda = 2

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub btnConsultaVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaVendedor.Click

        Me.Size = New System.Drawing.Size(580, 460)

        lstAyuda.DataSource = DaoVendedor.buscarVendedorPorNombre("")
        varProcesoBusqueda = 1

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        Select Case varProcesoBusqueda
            Case 0
                mostrarterminado(lstAyuda.SelectedValue)
            Case 1
                mostrarvendedor(lstAyuda.SelectedValue)
            Case 2
                mostrarcliente(lstAyuda.SelectedValue)
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
        txtDesdeTerminado.Focus()
    End Sub


End Class