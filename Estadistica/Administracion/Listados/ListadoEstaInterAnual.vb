Imports ClasesCompartidas
Imports System.IO

Public Class ListadoEstaInterAnual

    Dim txtSalida As Integer

    Dim varImpo() As Double
    Dim varTitulo() As String
    Dim varMes() As Integer
    Dim varAno() As Integer

    Dim txtDescripcion As String
    Dim varPasaCampo As String
    Dim varProcesoBusqueda As Integer

    Dim varImpreFecha() As String

    Private Sub ListadoEstaInterAnual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        DesCliente.Text = ""

        txtDesdeTerminado.Text = "AA-00000-000"
        txtHastaTerminado.Text = "ZZ-99999-999"

        TipoListado.Items.Clear()
        TipoListado.Items.Add("Cantidad")
        TipoListado.Items.Add("$")
        TipoListado.Items.Add("U$S")
        TipoListado.SelectedIndex = 0

        txtDesdeTerminado.Focus()
        txtDesdeTerminado.SelectionStart = 0

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
                    lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
            End Select
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
        End If
    End Sub

    Private Sub mostrarterminado(ByVal terminado As LeeTerminado)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        Me.Size = New System.Drawing.Size(610, 270)
        'txtDesdeTerminado.Text = LeeTerminado.Articulo
        'txtHastaTerminado.Text = LeeTerminado.Descripcion
        txtDesdeTerminado.Focus()
    End Sub

    Private Sub mostrarcliente(ByVal cliente As Cliente)
        txtAyuda.Visible = False
        lstAyuda.Visible = False
        txtClienteFiltro.Text = cliente.id
        DesCliente.Text = cliente.razon
        txtClienteFiltro.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        Select Case varProcesoBusqueda
            Case 0
                mostrarterminado(lstAyuda.SelectedValue)
                REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
            Case 1
                mostrarcliente(lstAyuda.SelectedValue)
        End Select
    End Sub

    Private Sub Proceso()

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtOrdDesde As String
        Dim txtOrdHasta As String
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

        Dim txtDesdeCliente As String
        Dim txtHastaCliente As String

        ReDim varImpo(100)
        ReDim varAno(100)
        ReDim varMes(100)
        ReDim varTitulo(100)
        ReDim varImpreFecha(100)

        Dim varAnoInicio As Integer
        Dim varAnoFinal As Integer
        Dim varInicio As Integer
        Dim varAnoTrabajo As Integer
        Dim varCiclo As Integer
        Dim varImpreAno As String
        Dim varDesdeFecha As String
        Dim varHastaFecha As String
        Dim varAnoGraba As Integer
        Dim varTotalImpo As Double
        Dim varPromedio As Double

        Dim varTituloI As String
        Dim varTituloII As String

        txtDesde = "01/01/" + Mid(txtDesdeFecha.Text, 7, 4)
        txtHasta = "31/12/" + Mid(txthastafecha.Text, 7, 4)

        txtOrdDesde = ordenaFecha(txtDesde)
        txtOrdHasta = ordenaFecha(txtHasta)

        varAnoInicio = Val(Mid(txtDesdeFecha.Text, 7, 4))
        varAnoFinal = Val(Mid(txthastafecha.Text, 7, 4))
        varInicio = Val(Mid(txtDesdeFecha.Text, 7, 4))

        varAnoTrabajo = 0

        For varCiclo = varAnoInicio To varAnoFinal
            varAnoTrabajo = varAnoTrabajo + 1
        Next varCiclo

        If varAnoTrabajo > 10 Then
            MsgBox("No se puede seleccionar mas de 10 años", 0, "Estadistica InterAnual")
            Exit Sub
        End If

        For varCiclo = 1 To 12
            varImpreFecha(varCiclo) = ""
        Next varCiclo

        For varCiclo = 1 To varAnoTrabajo
            varImpreFecha(varCiclo) = Str$(varInicio)
            varInicio = varInicio + 1
        Next varCiclo

        varImpreAno = Mid(txtDesdeFecha.Text, 7, 4)
        varDesdeFecha = varImpreAno + "0101"

        varImpreAno = Mid(txthastafecha.Text, 7, 4)
        varHastaFecha = varImpreAno + "1231"

        varTituloI = "entre el " + txtDesdeFecha.Text + " hasta el " + txthastafecha.Text
        varTituloII = ""

        If LTrim(RTrim(txtClienteFiltro.Text)) = "" Then
            txtDesdeCliente = ""
            txtHastaCliente = "Z99999"
        Else
            txtDesdeCliente = txtClienteFiltro.Text
            txtHastaCliente = txtClienteFiltro.Text
        End If

        If txtClienteFiltro.Text <> "" Then
            Dim tablaCliente As DataTable
            tablaCliente = SQLConnector.retrieveDataTable("buscar_cliente_por_codigo", txtClienteFiltro.Text)
            For Each row As DataRow In tablaCliente.Rows
                Dim Campocliente As New Cliente(row.Item(0), row.Item(1))
                varPasaCampo = "S"
                DesCliente.Text = Campocliente.razon
            Next
        End If


        ProgressBar1.Visible = True
        With ProgressBar1
            ProgressBar1.Maximum = 5000
            ProgressBar1.Minimum = 0
            ProgressBar1.Value = 0
        End With

        txtDesdeTerminado.Text = UCase(txtDesdeTerminado.Text)
        txtHastaTerminado.Text = UCase(txtHastaTerminado.Text)
        txtClienteFiltro.Text = UCase(txtClienteFiltro.Text)

        lstAyuda.Visible = False
        txtAyuda.Visible = False

        SQLConnector.retrieveDataTable("limpiar_estaanu")


        Dim tabla As DataTable
        Dim DesdeVendedor = 0, HastaVendedor = 9999

        If Vendedor.permisos <> 99 Then
            DesdeVendedor = Vendedor.permisos
            HastaVendedor = Vendedor.permisos
        End If

        tabla = SQLConnector.retrieveDataTable("buscar_estadistica_productosII", DesdeVendedor, HastaVendedor, 0, 9999, 0, 9999, txtDesdeCliente, txtHastaCliente, txtDesdeTerminado.Text, txtHastaTerminado.Text, txtOrdDesde, txtOrdHasta)

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



        txtPasa = 0
        txtCorte = ""
        txtDescripcion = ""
        txtLinea = ""

        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_Estadistica_Ranking_producto_anual", txtOrdDesde, txtOrdHasta, txtDesdeTerminado.Text, txtHastaTerminado.Text, 0, 9999, txtDesdeCliente, txtHastaCliente)

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

                varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10)
                If varAnoTrabajo <> 0 Then
                    varPromedio = varTotalImpo / varAnoTrabajo
                Else
                    varPromedio = 0
                End If

                SQLConnector.executeProcedure("alta_estaanu", txtCorte, "", txtCorte, txtDescripcion, "", txtLinea, varImpo(1), varImpreFecha(1), varImpo(2), varImpreFecha(2), varImpo(3), varImpreFecha(3), varImpo(4), varImpreFecha(4),
                                              varImpo(5), varImpreFecha(5), varImpo(6), varImpreFecha(6), varImpo(7), varImpreFecha(7), varImpo(8), varImpreFecha(8), varImpo(9), varImpreFecha(9), varImpo(10), varImpreFecha(10), varImpo(11), varImpreFecha(11), varImpo(12), varImpreFecha(12), varPromedio, varTituloI, varTituloII)

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
                    If DesCliente.Text <> "" Then
                        varTituloII = DesCliente.Text + " - Cantidad"
                    Else
                        varTituloII = "Cantidad"
                    End If
                Case 1
                    varImporte = CampoEsta.Importe
                    If DesCliente.Text <> "" Then
                        varTituloII = DesCliente.Text + " - Pesos"
                    Else
                        varTituloII = "Pesos"
                    End If
                Case 2
                    varImporte = CampoEsta.ImporteUs
                    If DesCliente.Text <> "" Then
                        varTituloII = DesCliente.Text + " - Dolares"
                    Else
                        varTituloII = "Dolares"
                    End If
                Case Else
            End Select

            varAnoGraba = Val(Mid(CampoEsta.Fecha, 7, 4))

            For varCiclo = 1 To 10
                If Val(varImpreFecha(varCiclo)) = Val(varAnoGraba) Then
                    varImpo(varCiclo) = varImpo(varCiclo) + varImporte
                End If
            Next varCiclo

        Next


        If txtPasa <> 0 Then

            varSuma = varSuma + 1

            txtClave = LTrim(RTrim(txtCorte))
            txtcliente = ""
            txtLinea = 0
            txtArticulo = LTrim(RTrim(txtCorte))

            varTotalImpo = varImpo(1) + varImpo(2) + varImpo(3) + varImpo(4) + varImpo(5) + varImpo(6) + varImpo(7) + varImpo(8) + varImpo(9) + varImpo(10)
            If varAnoTrabajo <> 0 Then
                varPromedio = varTotalImpo / varAnoTrabajo
            Else
                varPromedio = 0
            End If

            SQLConnector.executeProcedure("alta_estaanu", txtCorte, "", txtCorte, txtDescripcion, "", txtLinea, varImpo(1), varImpreFecha(1), varImpo(2), varImpreFecha(2), varImpo(3), varImpreFecha(3), varImpo(4), varImpreFecha(4),
                                          varImpo(5), varImpreFecha(5), varImpo(6), varImpreFecha(6), varImpo(7), varImpreFecha(7), varImpo(8), varImpreFecha(8), varImpo(9), varImpreFecha(9), varImpo(10), varImpreFecha(10), varImpo(11), varImpreFecha(11), varImpo(12), varImpreFecha(12), varPromedio, varTituloI, varTituloII)

        End If


        REM txtDos = Globals.reportPathWithName("WGraficoNet.rpt")


        ProgressBar1.Visible = False

        txtUno = "{EstaAnu.Codigo} in " + x + "AA-00000-000" + x + " to " + x + "ZZ-99999-999" + x
        txtDos = ""
        txtFormula = txtUno + txtDos

        Dim viewer As New ReportViewer("Listado de Venta InterAnual", Globals.reportPathWithName("WEstaInterAnualNet.rpt"), txtFormula)
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
        Call Proceso()
    End Sub

    Private Sub btnImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresora.Click
        txtSalida = 1
        Call Proceso()
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub


    Private Sub txtCliente_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteFiltro.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            varPasaCAmpo = "N"
            Dim tablaCliente As DataTable
            tablaCliente = SQLConnector.retrieveDataTable("buscar_cliente_por_codigo", txtClienteFiltro.Text)
            For Each row As DataRow In tablaCliente.Rows
                Dim Campocliente As New Cliente(row.Item(0), row.Item(1))
                varPasaCAmpo = "S"
                DesCliente.Text = Campocliente.razon
            Next
    
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtClienteFiltro.Text = ""
        End If

    End Sub



    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click

        Me.Size = New System.Drawing.Size(580, 460)

        lstAyuda.DataSource = DAOCliente.buscarClientePorNombre("")
        varProcesoBusqueda = 1

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub
End Class