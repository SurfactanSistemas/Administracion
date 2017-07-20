Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient

Public Class ListadoCuentaCorrienteProveedoresSelectivo

    Dim varRenglon As Integer
    Dim varTotal, varSaldo, varTotalUs, varSaldoUs, varSaldoOriginal, varDife, varParidad, varParidadTotal As Double
    Dim varPago As Integer
    Dim _Claves As New List(Of Object)

    Private Sub ListadoCuentaCorrienteProveedoresSelectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesdeProveedor.Text = ""
        txtFechaEmision.Text = "  /  /    "
        varRenglon = 0
        opcPantalla.Checked = False
        opcImpesora.Checked = True
        _CargarProveedoresPreCargados()
        _Claves.Clear()
    End Sub

    Private Function _DeterminarFechaLimite() As String
        Dim _Fecha As Date = Nothing
        Dim _FechaActual As Date = Date.Now
        Const DIA_LIMITE As Integer = 4

        _Fecha = DateAdd(DateInterval.Day, (DIA_LIMITE - _FechaActual.DayOfWeek), _FechaActual)
        _Fecha = DateAdd(DateInterval.Day, -7, _Fecha)

        Return String.Join("", _Fecha.ToString("dd/MM/yyyy").Split("/").Reverse())
    End Function

    Private Sub _CargarProveedoresPreCargados()
        Dim _Proveedores As New List(Of Object)
        Dim _CargadosHaceMasDeUnaSemana As Integer = 0
        Dim _FechaLimite As String = _DeterminarFechaLimite()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Proveedor, FechaOrd FROM ProveedorSelectivo")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    _Proveedores.Add({dr.Item("Proveedor"), dr.Item("FechaOrd")})

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        For Each _Proveedor As Object In _Proveedores
            If _Proveedor(1) <= _FechaLimite Then ' Comprobamos si hay proveedores guardados fuera del periodo actual.
                _CargadosHaceMasDeUnaSemana += 1
                _CargarProveedor(DAOProveedor.buscarProveedorPorCodigo(_Proveedor(0)), True)
            Else
                _CargarProveedor(DAOProveedor.buscarProveedorPorCodigo(_Proveedor(0)))
            End If
        Next

        If Val(_CargadosHaceMasDeUnaSemana) > 0 Then
            MsgBox("Hay " & _CargadosHaceMasDeUnaSemana & " Proveedor(es) que se encuentra(n) cargado(s) antes del periodo actual.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub _CargarProveedor(ByVal CampoProveedor As Proveedor, Optional ByVal marcar As Boolean = False)
        If IsNothing(CampoProveedor) Then
            MsgBox("Proveedor incorrecto")
        Else
            GRilla.Rows.Add()
            GRilla.Item(0, varRenglon).Value = CampoProveedor.id
            GRilla.Item(1, varRenglon).Value = CampoProveedor.razonSocial

            If marcar Then
                GRilla.Rows(varRenglon).Cells(0).Style.BackColor = Color.IndianRed
                GRilla.Rows(varRenglon).Cells(1).Style.BackColor = Color.IndianRed
            End If

            GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
            varRenglon = varRenglon + 1
            GRilla.CurrentCell = GRilla(0, 0)

            txtDesdeProveedor.Text = ""
            txtRazon.Text = ""
            txtDesdeProveedor.Focus()
        End If
    End Sub

    Private Function _ProveedorYaAgregado(ByVal _Proveedor As String) As Boolean
        Dim _YaAgregado As Boolean = False

        For Each row As DataGridViewRow In GRilla.Rows

            If Trim(row.Cells(0).Value) = Trim(_Proveedor) Then
                _YaAgregado = True
                Exit For
            ElseIf Trim(row.Cells(1).Value) = Trim(_Proveedor) Then
                _YaAgregado = True
                Exit For
            End If

        Next

        Return _YaAgregado
    End Function

    Private Sub txtfechaemision_KeyPress(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
               Handles txtFechaEmision.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFechaEmision.Text) = "S" Then

                Dim CampoTipoCambio As TipoDeCambio = DAOTipoCambio.buscarTipoCambioPorFecha(txtFechaEmision.Text)
                If IsNothing(CampoTipoCambio) Then
                    MsgBox("Paridad Inexistente")
                    txtFechaEmision.Focus()
                Else
                    varParidadTotal = CampoTipoCambio.paridad
                    txtDesdeProveedor.Focus()
                End If
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFechaEmision.Text = "  /  /    "
            Me.txtFechaEmision.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Height = 690

        'lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre("")

        _DeshabilitarConsulta()

        _ListarProveedores()

    End Sub

    Private Sub _HabilitarConsulta()
        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()
    End Sub

    Private Sub _DeshabilitarConsulta()
        txtAyuda.Text = ""
        txtAyuda.Visible = False
        lstAyuda.Visible = False
    End Sub

    Private Sub _ListarProveedores()
        Dim _Proveedores As List(Of Proveedor) = DAOProveedor.buscarProveedoresActivoPorNombre()
        Dim item As String = ""

        If _Proveedores.Count > 0 Then

            lstAyuda.Items.Clear()
            _Claves.Clear()

            For Each _prv As Proveedor In _Proveedores

                item = ceros(_prv.id, 11) & "    " & _prv.razonSocial

                lstAyuda.Items.Add(item)

                _Claves.Add({item, _prv.id})

            Next

            _HabilitarConsulta()
        Else
            _DeshabilitarConsulta()
        End If

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtAyuda.KeyPress
        'If e.KeyChar = Convert.ToChar(Keys.Return) Then
        '    e.Handled = True
        '    lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre(txtAyuda.Text)
        'ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
        '    e.Handled = True
        '    txtAyuda.Text = ""
        'End If
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click

        If Trim(lstAyuda.SelectedItem) <> "" Then
            _AgregarProveedorAListadoGeneral(lstAyuda.SelectedItem)
        End If

    End Sub

    Private Sub _AgregarProveedorAListadoGeneral(ByVal item As String)

        If Trim(item) = "" Then
            Exit Sub
        End If

        Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(_Claves.FindLast(Function(p) p(0) = item)(1))
        If Not IsNothing(proveedor) Then
            If Not _ProveedorYaAgregado(proveedor.id) Then
                _CargarProveedor(proveedor)
            End If

            ' Sacamos el item del listado
            lstAyuda.Items(lstAyuda.FindStringExact(item)) = ""
            lstFiltrada.Visible = False
            lstAyuda.Visible = True
            txtAyuda.Text = ""
            txtAyuda.Focus()

        End If

    End Sub

    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim txtUno, txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)

        Dim WOrden As Integer
        Dim txtEmpresa As String

        Dim varOrdFecha As String
        Dim varCiclo As Integer
        Dim varPorce As Double
        Dim varAcumulado As Double
        Dim varProveedor, varLetra As String
        Dim varNeto, varIva, varIva5, varIva27, varIva105, varIb, varExento, varTotalTrabajo As Double
        Dim varRetIb, varRetIva, varRetGan, varAcumulaIb
        REM Dim varRetIb, varRetIva, varRetGan, varAcumulaIb, varRete As Double
        Dim varPorceIb, varPorceIbCaba As Double
        Dim varTipoIbCaba, varTipoIva, varTipoPrv, varTipoIb As Integer
        Dim varPago, varEmpresa As Integer
        Dim varAcumulaNeto, varAcumulaNetoII, varAcumulaIva As Double
        Dim varFecha As String
        Dim varRetIbI, varRetIbII As Double

        SQLConnector.retrieveDataTable("limpiar_impCtaCtePrvNet")

        txtEmpresa = "Surfactan S.A."
        varEmpresa = 1

        varOrdFecha = ordenaFecha(txtFechaEmision.Text)

        For varCiclo = 0 To varRenglon

            varProveedor = GRilla.Item(0, varCiclo).Value

            If LTrim(RTrim(varProveedor)) <> "" Then

                varAcumulado = 0
                varAcumulaIva = 0
                varAcumulaNeto = 0

                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_selectivo", varProveedor)

                For Each row As DataRow In tabla.Rows

                    Dim CCPrv As New CtaCteProveedoresDeudaDesdeHastaII(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString, row.Item(10), row.Item(11).ToString, row.Item(12).ToString, row.Item(13), row.Item(14))

                    varPago = CCPrv.pago
                    varParidad = CCPrv.paridad
                    varFecha = CCPrv.fecha

                    If varPago <> 2 Then
                        varTotal = CCPrv.total
                        varSaldo = CCPrv.saldo
                        varTotalUs = 0
                        varSaldoUs = 0
                        varSaldoOriginal = 0
                        varDife = 0
                    Else
                        varTotal = (CCPrv.total / varParidad) * varParidadTotal
                        varSaldo = (CCPrv.saldo / varParidad) * varParidadTotal
                        varTotalUs = (CCPrv.total / varParidad)
                        varSaldoUs = (CCPrv.saldo / varParidad)
                        varSaldoOriginal = CCPrv.saldo
                        varDife = varSaldo - CCPrv.saldo
                    End If

                    redondeo(varTotal)
                    redondeo(varSaldo)

                    varAcumulado = varAcumulado + varSaldo

                    If varTotal = varSaldo Then
                        varPorce = 1
                    Else
                        varPorce = varSaldo / varTotal
                    End If

                    varNeto = 0
                    varIva = 0
                    varIva5 = 0
                    varIva27 = 0
                    varIva105 = 0
                    varIb = 0
                    varExento = 0
                    varTotalTrabajo = 0
                    varLetra = ""

                    Dim CampoProveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(CCPrv.Proveedor)
                    If IsNothing(CampoProveedor) Then
                        REM no existe
                    Else
                        varTipoIb = CampoProveedor.condicionIB1
                        varTipoIbCaba = CampoProveedor.condicionIB2
                        varTipoIva = CampoProveedor.codIva
                        varTipoPrv = CampoProveedor.tipo + 1
                        varPorceIb = CampoProveedor.porceIBProvincia
                        varPorceIbCaba = CampoProveedor.porceIBCABA

                        'WTipoIb = RstProveedor!CodIb
                        'WTipoIbCaba = RstProveedor!CodIbCaba
                        'WTipoiva = RstProveedor!Iva
                        'WTipoprv = Val(RstProveedor!Tipo) + 1
                        'WPorceIb = IIf(IsNull(RstProveedor!PorceIb), "0", RstProveedor!PorceIb)
                        'WPorceIbCaba = IIf(IsNull(RstProveedor!PorceIbCaba), "0", RstProveedor!PorceIbCaba)

                    End If

                    Dim compra As Compra = DAOCompras.buscarCompraPorCodigo(CCPrv.nroInterno)
                    If IsNothing(compra) Then
                        REM no existe
                    Else
                        varLetra = compra.letra
                        varNeto = compra.neto
                        varIva = compra.iva21
                        varIva5 = compra.ivaRG
                        varIva27 = compra.iva27
                        varIva105 = compra.iva105
                        varIb = compra.percibidoIB
                        varExento = compra.exento
                        varTotalTrabajo = varNeto + varIva + varIva5 + varIva27 + varIva105 + varIb + varExento
                    End If

                    varRetIbI = 0
                    varRetIbII = 0
                    varRetIb = 0
                    varRetIva = 0
                    varRetGan = 0
                    varAcumulaIb = 0



                    '
                    'calcula el neto para el calculo de las retenciones
                    '
                    If varTotalTrabajo <> 0 Then
                        varAcumulaNetoII = varNeto * varPorce
                    Else
                        If varTipoIva = 2 Then
                            varAcumulaNetoII = (varSaldo / 1.21)
                        Else
                            varAcumulaNetoII = varSaldo
                        End If
                    End If

                    If varPago = 2 Then
                        varAcumulaNetoII = varAcumulaNetoII + (varDife / 1.21)
                    End If
                    varAcumulaNeto = varAcumulaNeto + varAcumulaNetoII

                    '
                    'calculo de rtencion de Ingresos brutos Pcia
                    '
                    varRetIbI = CaculoRetencionIngresosBrutos(varTipoIb, varPorceIb, varAcumulaNeto)

                    '
                    'calculo de rtencion de Ingresos brutos CABA
                    '
                    If varEmpresa = 1 Then
                        varRetIbII = CaculoRetencionIngresosBrutos(varTipoIbCaba, varPorceIbCaba, varAcumulaNeto)
                    End If


                    Stop

                    '
                    'calculo de rtencion de Ganancias
                    '
                    varOrdFecha = leederecha(ordenaFecha(varFecha), 6)
                    Dim CampoAcumulado As LeeAcumulado = DaoAcumulado.buscarAcumulado(varProveedor, varOrdFecha)

                    varRetGan = CaculoRetencionGanancia(varTipoPrv, varAcumulaNeto, CampoAcumulado.neto, CampoAcumulado.retenido, CampoAcumulado.anticipo, CampoAcumulado.bruto, CampoAcumulado.iva)


                    '
                    'calculo de rtencion de IVA
                    '
                    If varLetra = "M" Then
                        If varNeto >= 1000 Then
                            varAcumulaIva = varAcumulaIva + varIva
                        End If
                        varRetIva = varAcumulaIva
                    End If

                    varRetIb = varRetIbI + varRetIbII + varRetIva

                    '!acuneto = !Acumulado - WRetIb - WRetgan
                    '!Nombre = WNombre
                    '!Cheque = WCheque
                    '!ReteIb = WRetIb
                    '!ReteGan = WRetgan

                    SQLConnector.executeProcedure("alta_impCtaCtePrvNet", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra, CCPrv.punto, CCPrv.numero, varTotal, varSaldo, CCPrv.fecha, CCPrv.vencimiento, txtFechaEmision.Text, CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, varAcumulado, WOrden, txtFechaEmision.Text, "", "", "", varParidadTotal, varSaldoOriginal, varDife, 0, 0, "", 0, 0, 0, varParidad, varTotalUs, varSaldoUs, 0, 0)


                Next

            End If

        Next

        Stop

        txtUno = "{impCtaCtePrvNet.Proveedor} in " + x + "" + x + " to " + x + "ZZZZZZZZZZZ" + x
        txtDos = " and {impCtaCtePrvNet.Saldo} <> 0.00"
        txtFormula = txtUno + txtDos

        'Dim viewer As New ReportViewer("Listado de Corriente de Proveedres Selectivo", Globals.reportPathWithName("wccprvfecnet.rpt"), txtFormula)

        'If opcPantalla.Checked = True Then
        '    viewer.Show()
        'Else
        '    viewer.imprimirReporte()
        'End If

        _ConsultarSiEliminarListaParcialDeProveedores()
    End Sub

    Private Sub _ConsultarSiEliminarListaParcialDeProveedores()

        If MsgBox("¿Desea limpiar la lista parcial de proveedores de este periodo?", MsgBoxStyle.Exclamation) = DialogResult.OK Then
            _LimpiarTodosLosProveedoresSelectivos()
        End If

    End Sub

    Private Sub _LimpiarTodosLosProveedoresSelectivos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM ProveedorSelectivo")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

            MsgBox("Se han eliminado todos los proveedores correspondientes a este periodo.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtDesdeProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesdeProveedor.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtDesdeProveedor.Text) = "" Then
                _ListarProveedores()
                Exit Sub
            End If

            If Not _ProveedorYaAgregado(txtDesdeProveedor.Text) Then
                ' DADA que no rompa cuando el codigo no existe y usar la funcion "ceros" para completar??
                _CargarProveedor(DAOProveedor.buscarProveedorPorCodigo(txtDesdeProveedor.Text))
            Else
                MsgBox("El proveedor indicado ya se encuentra agregado a la lista semanal.", MsgBoxStyle.Information)
                txtDesdeProveedor.Focus()
                Exit Sub
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeProveedor.Text = ""
            txtDesdeProveedor.Focus()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If GRilla.Focused Or GRilla.IsCurrentCellInEditMode Then

            Dim key As Integer = msg.WParam.ToInt32()

            GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If key = Keys.Escape Then

                If GRilla.SelectedRows.Count > 0 Then

                    _EliminarProveedoresSeleccionados()

                End If

            End If

            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnLimpiarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarTodo.Click
        _DeshabilitarConsulta()

        For Each _C As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            _C.Text = ""
        Next

        For Each _C As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            _C.Clear()
        Next

        GRilla.Rows.Clear()

        '_LimpiarProveedoresSelectivos()

    End Sub

    Private Sub _LimpiarProveedoresSelectivos()

        If GRilla.SelectedRows.Count > 0 Then ' Eliminamos solamente los seleccionados.

            _EliminarProveedoresSeleccionados()

        End If

    End Sub

    Private Sub _EliminarProveedoresSeleccionados()
        If MsgBox("¿Esta seguro que desea eliminar los proveedores seleccionados?", MsgBoxStyle.OkCancel) = DialogResult.OK Then
            For Each row As DataGridViewRow In GRilla.SelectedRows

                If Not IsNothing(row.Cells(0).Value) And Trim(row.Cells(0).Value) <> "" Then

                    If _EliminarProveedorSelectivo(row.Cells(0).Value) Then
                        GRilla.Rows.Remove(row)
                        varRenglon -= 1
                    End If

                End If

            Next
        End If
    End Sub

    Private Function _EliminarProveedorSelectivo(ByVal codProv As String) As Boolean
        Dim exito As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(codProv) & "'")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()
            exito = True

        Catch ex As Exception
            MsgBox("Hubo un problema al querer eliminar el Proveedor del periodo actual.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return exito
    End Function

    Private Sub lstAyuda_Filtrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAyuda_Filtrada.Click
        If Trim(lstFiltrada.SelectedItem) <> "" Then
            _AgregarProveedorAListadoGeneral(lstFiltrada.SelectedItem)
        End If
    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick
        _ListarProveedores()
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