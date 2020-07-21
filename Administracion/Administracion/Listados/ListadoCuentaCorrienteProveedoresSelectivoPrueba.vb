﻿Imports System.ComponentModel
Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms

Public Class ListadoCuentaCorrienteProveedoresSelectivoPrueba

    Dim varRenglon As Integer
    Dim varTotal, varSaldo, varTotalUs, varSaldoUs, varSaldoOriginal, varDife, varParidad, varParidadTotal As Double
    Dim _Claves As New List(Of Object)

    Dim WTipoSalida As Reporte

    Private Sub ListadoCuentaCorrienteProveedoresSelectivo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeProveedor.Text = ""
        txtFechaEmision.Clear()
        varRenglon = 0
        '_CargarProveedoresPreCargados()
        _Claves.Clear()

        CheckForIllegalCrossThreadCalls = False

        _PurgarSaldosCtaCtePrvs()
    End Sub

    Private Sub _CargarProveedoresPreCargados()
        Dim _Proveedores As New List(Of Object)
        'Dim _CargadosHaceMasDeUnaSemana As Integer = 0
        'Dim _FechaLimite As String = _DeterminarFechaLimite()

        GRilla.DataSource = GetAll("SELECT ps.Proveedor, p.Nombre, ps.EnviarAvisoOp FROM ProveedorSelectivo ps INNER JOIN Proveedor p ON p.Proveedor = ps.Proveedor WHERE ps.Fecha = '" & txtFechaEmision.Text & "' ORDER BY p.Nombre")

        Exit Sub

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Proveedor, FechaOrd, EnviarAvisoOp FROM ProveedorSelectivo WHERE Fecha = '" & txtFechaEmision.Text & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            GRilla.Rows.Clear()
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    _Proveedores.Add({dr.Item("Proveedor"), dr.Item("FechaOrd")})

                Loop
                'Else
                'MsgBox("No hay proveedores que listar.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los Proveedores Selectivos precargados en la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        For Each _Proveedor As Object In _Proveedores
            _CargarProveedor(DAOProveedor.buscarProveedorPorCodigo(_Proveedor(0)))
        Next

        GRilla.Sort(GRilla.Columns(1), ListSortDirection.Ascending)

    End Sub

    Private Sub _CargarProveedor(ByVal CampoProveedor As Proveedor)
        If IsNothing(CampoProveedor) Then
            MsgBox("Proveedor incorrecto")
        Else


            If txtFechaEmision.Text.Replace(" ", "").Length < 10 Then
                MsgBox("Debe indicarse una fecha de Pago antes de cargar un Proveedor.", MsgBoxStyle.Exclamation)
                txtFechaEmision.Focus()
                Exit Sub
            End If


            varRenglon = GRilla.Rows.Add()
            GRilla.Item(0, varRenglon).Value = CampoProveedor.id
            GRilla.Item(1, varRenglon).Value = CampoProveedor.razonSocial

            GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
            GRilla.CurrentCell = GRilla(0, 0)

            txtDesdeProveedor.Text = ""
            txtRazon.Text = ""
            txtDesdeProveedor.Focus()
        End If
    End Sub

    Private Function _ProveedorYaAgregado(ByVal _Proveedor As String) As Boolean
        Dim _YaAgregado = False

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

    Private Function _ProveedorYaAgregado(ByVal _Proveedor As String, ByVal Excepto As Integer) As Boolean
        Dim _YaAgregado = False

        For Each row As DataGridViewRow In GRilla.Rows

            If Trim(row.Cells(0).Value) = Trim(_Proveedor) And row.Index <> Excepto Then
                _YaAgregado = True
                Exit For
            ElseIf Trim(row.Cells(1).Value) = Trim(_Proveedor) And row.Index <> Excepto Then
                _YaAgregado = True
                Exit For
            End If

        Next

        Return _YaAgregado
    End Function

    Private Sub txtfechaemision_KeyPress(ByVal sender As Object, _
               ByVal e As KeyPressEventArgs) _
               Handles txtFechaEmision.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFechaEmision.Text) = "S" Then

                Dim CampoTipoCambio As TipoDeCambio = DAOTipoCambio.buscarTipoCambioPorFechaPago(txtFechaEmision.Text)
                If IsNothing(CampoTipoCambio) Then
                    If txtFechaEmision.Text = Date.Now.ToString("dd/MM/yyyy") Then
                        MsgBox("Paridad Inexistente")
                        txtFechaEmision.Focus()
                        Exit Sub
                    End If
                Else
                    varParidadTotal = CampoTipoCambio.paridad
                End If
                txtDesdeProveedor.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFechaEmision.Text = "  /  /    "
            txtFechaEmision.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancela.Click
        Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click

        _DeshabilitarConsulta()

        _ListarProveedores()

    End Sub

    Private Sub _HabilitarConsulta()
        txtAyuda.Text = ""
        GrupoConsultas.Visible = True
        txtAyuda.Focus()
    End Sub

    Private Sub _DeshabilitarConsulta()
        txtAyuda.Text = ""
        GrupoConsultas.Visible = False
    End Sub

    Private Sub _ListarProveedores()
        Dim _Proveedores As List(Of Proveedor) = DAOProveedor.buscarProveedoresActivoPorNombre()
        Dim item = ""

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

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstAyuda.Click

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

            lstFiltrada.Visible = False
            lstAyuda.Visible = True
            txtAyuda.Text = ""
            txtAyuda.Focus()

        End If

    End Sub

    Private Sub _LimpiarImpCtaCtePrvNet()
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("DELETE FROM impCtaCtePrvNet")

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer limpiar la tabla ImpCtaCtePrvNet en la Base de Datos.")
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _BuscarTipoCambio(ByVal fecha As String) As Double
        Dim Paridad = 0.0
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT CambioDivisa FROM Cambios WHERE Fecha = '" & fecha & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Paridad = IIf(IsDBNull(dr.Item("CambioDivisa")), 0, dr.Item("CambioDivisa"))

                If Val(Paridad) = 0 Then
                    Throw New SinParidadException("Paridad Inexistente")
                End If

            Else
                Throw New SinParidadException("Paridad Inexistente")
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Paridad
    End Function

    Private Function _BuscarCtaCtePrvSelectivo(ByVal proveedor As String) As DataTable
        Dim tabla As New DataTable
        Dim cn = New SqlConnection()
        'Dim cm = "SELECT ccp.Tipo, ccp.Letra, ccp.Punto, ccp.Numero, ccp.Tovartal, ccp.Saldo, ccp.Fecha, ccp.Vencimiento, ccp.Vencimiento1, Impre = CASE ISNULL(i.Rechazado, 0) WHEN 1 THEN 'CHR' ELSE ccp.Impre END, ccp.NroInterno, ccp.Clave, ccp.Pago, ccp.Paridad FROM CtaCtePrv ccp LEFT OUTER JOIN IvaComp i ON i.NroInterno = ccp.NroInterno WHERE ccp.Proveedor = '" & proveedor.Trim() & "' AND ccp.Saldo <> 0 ORDER BY ccp.Proveedor, ccp.OrdFecha, ccp.NroInterno"
        'Dim cm = "SELECT ccp.Tipo, ccp.Letra, ccp.Punto, ccp.Numero, ccp.Total, ccp.Saldo, ccp.Fecha, ccp.Vencimiento, ccp.Vencimiento1, Impre = CASE ISNULL(i.Rechazado, 0) WHEN 1 THEN 'CHR' ELSE ccp.Impre END, ccp.NroInterno, ccp.Clave, ccp.Pago, ccp.Paridad, ccp.MarcaVirtual FROM CtaCtePrv ccp LEFT OUTER JOIN IvaComp i ON i.NroInterno = ccp.NroInterno WHERE ccp.Proveedor = '" & proveedor.Trim() & "' AND ccp.Saldo <> 0 ORDER BY ccp.Proveedor, ccp.OrdFecha, ccp.Numero"
        Dim cm = "SELECT ccp.Tipo, ccp.Letra, ccp.Punto, ccp.Numero, ccp.Total, ccp.Saldo, ccp.Fecha, ccp.Vencimiento, ccp.Vencimiento1, Impre = CASE ISNULL(i.Rechazado, 0) WHEN 1 THEN 'CHR' ELSE ccp.Impre END, ccp.NroInterno, ccp.Clave, ccp.Pago, ccp.Paridad, ccp.MarcaVirtual FROM CtaCtePrv ccp LEFT OUTER JOIN IvaComp i ON i.NroInterno = ccp.NroInterno WHERE ccp.Proveedor = '" & proveedor.Trim() & "' AND ccp.Saldo <> 0 And ISNULL(ccp.MarcaVirtual, '') <> 'X' and ccp.pago =2 ORDER BY ccp.Proveedor, ccp.OrdFecha, ccp.Numero"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _ConectarA()
            cn.Open()

            dr.Fill(tabla)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Cuenta Corriente del Proveedor en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If tabla.Rows.Count > 0 Then
            Return _NormalizarFilas(tabla)
        Else
            Return Nothing
        End If
    End Function

    Private Function _BuscarProveedor(ByVal codProveedor As String) As DataRow
        Dim proveedor As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = "SELECT CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & codProveedor & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _ConectarA()
            cn.Open()

            dr.Fill(proveedor)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos del Proveedor en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If proveedor.Rows.Count > 0 Then
            Return _NormalizarFila(proveedor.Rows(0))
        Else
            Return Nothing
        End If

    End Function

    Private Function _BuscarCompra(ByVal NroInterno As Integer) As DataRow
        Dim compra As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = "SELECT Letra, Neto, Iva21, Iva5, Iva27, Iva105, Ib, Exento, ISNULL(MarcaDifCambio, 0) As MarcaDifCambio, ISNULL(Rechazado, 0) As Rechazado FROM IvaComp WHERE NroInterno = '" & NroInterno & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _ConectarA()
            cn.Open()

            dr.Fill(compra)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Factura en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If compra.Rows.Count > 0 Then
            Return _NormalizarFila(compra.Rows(0))
        Else
            Return Nothing
        End If
    End Function

    Private Function _BuscarAcumulado(ByVal proveedor As String, ByVal fecha As String) As DataRow
        Dim acumulado As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = "SELECT Neto, Retenido, Anticipo, Bruto, Iva FROM Retencion WHERE Proveedor = '" & proveedor & "' AND Fecha = '" & fecha & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _ConectarA()
            cn.Open()

            dr.Fill(acumulado)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los valores acumulados correspondientes al Proveedor: " & proveedor & " en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If acumulado.Rows.Count > 0 Then
            Return _NormalizarFila(acumulado.Rows(0))
        Else
            Return Nothing
        End If
    End Function

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        Dim ds As New DBAuxi

        Dim WTabla As DataTable = New DBAuxi.impCtaCtePrvNetDataTable 'ds.Tables("impCtaCtePrvNet")

        Dim txtUno, txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)

        Dim WOrden = 0
        Dim txtEmpresa As String

        Dim varAcumPesosNetoParaIB, varAcumPesosNetoParaGanancias As Double
        Dim varOrdFecha As String
        Dim varCiclo As Integer
        Dim varPorce As Double
        Dim varAcumulado, varAcuNeto, varAcuRetenido, varAcuIva, varAcuAnticipo, varAcuBruto, varAcumulaUs As Double
        Dim varProveedor, varLetra As String
        Dim varNeto, varIva, varIva5, varIva27, varIva105, varIb, varExento, varTotalTrabajo As Double
        Dim varRetIb, varRetIva, varRetGan
        REM Dim varRetIb, varRetIva, varRetGan, varAcumulaIb, varRete As Double
        Dim varPorceIb, varPorceIbCaba As Double
        Dim varTipoIbCaba, varTipoIva, varTipoPrv, varTipoIb As Integer
        Dim varPago, varEmpresa As Integer
        Dim varAcumulaNeto, varAcumulaNetoII, varAcumulaIva, varPesosOrig, varDifCambio, AcumPesosOrig, AcumPesosOrigII, AcumDifCambio As Double
        Dim varRetIbI, varRetIbII As Double

        'Try

        '    _LimpiarImpCtaCtePrvNet()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Sub
        'End Try

        txtEmpresa = "Surfactan S.A."
        varEmpresa = 1

        If _EsPellital() Then
            txtEmpresa = "Pellital S.A"
            varEmpresa = 8
        End If

        varOrdFecha = ordenaFecha(txtFechaEmision.Text)

        Try

            varParidadTotal = _BuscarTipoCambio(txtFechaEmision.Text)

        Catch ex As SinParidadException
            MsgBox(ex.Message, MsgBoxStyle.Information)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            txtFechaEmision.Focus()
            Exit Sub
        End Try

        GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)

        ProgressBar1.Maximum = GRilla.Rows.Count + 1

        For varCiclo = 0 To GRilla.Rows.Count - 1

            varAcumulaUs = 0
            varProveedor = GRilla.Item(0, varCiclo).Value

            If Trim(varProveedor) <> "" Then

                Dim datosProveedor As DataRow = GetSingle("SELECT Proveedor, Nombre, NombreCheque, ImpreCuitCliente, FormaPago FROM Proveedor WHERE Proveedor = '" & varProveedor & "'", IIf(_EsPellital, "Pellital_III", "SurfactanSa"))

                varAcumulado = 0
                varAcumulaIva = 0
                varAcumulaNeto = 0

                varPesosOrig = 0
                varDifCambio = 0

                AcumDifCambio = 0
                AcumPesosOrig = 0
                AcumPesosOrigII = 0

                varRetIbI = 0
                varRetIbII = 0
                varRetIb = 0
                varRetIva = 0
                varRetGan = 0

                varTotal = 0
                varSaldo = 0
                varTotalUs = 0
                varSaldoUs = 0
                varSaldoOriginal = 0
                varDife = 0

                varAcumPesosNetoParaIB = 0
                varAcumPesosNetoParaGanancias = 0

                Dim tabla As New DataTable

                Try

                    tabla = _BuscarCtaCtePrvSelectivo(varProveedor)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If Not IsNothing(tabla) Then
                    For Each row As DataRow In tabla.Rows

                        WOrden += 1

                        Dim CCPrv As New CtaCteProveedoresDeudaDesdeHastaII(row("Tipo"), row("Letra"), row("Punto"), row("Numero"), row("Total"), row("Saldo"), row("Fecha"), row("Vencimiento"), row("Vencimiento1"), row("Impre"), row("NroInterno"), row("Clave"), varProveedor, row("Pago"), row("Paridad"))

                        varPago = CCPrv.pago
                        varParidad = CCPrv.paridad

                        If varPago <> 2 Then
                            varTotal = CCPrv.total
                            varSaldo = CCPrv.saldo
                            varTotalUs = 0
                            varSaldoUs = 0
                            varSaldoOriginal = 0
                            varDife = 0
                        Else
                            If Val(varParidad) = 0 Then
                                MsgBox("La factura con Nro Interno " & CCPrv.nroInterno & " del Proveedor " & CCPrv.Proveedor & ", no posee Paridad cargada.", MsgBoxStyle.Information)

                                varTotal = 0
                                varSaldo = 0
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


                            varAcumulaUs += varTotalUs

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

                        Dim CampoProveedor = Nothing

                        Try
                            CampoProveedor = _BuscarProveedor(varProveedor)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try

                        If Not IsNothing(CampoProveedor) Then

                            varTipoIb = CampoProveedor("CodIb")
                            varTipoIbCaba = CampoProveedor("CodIbCaba")
                            varTipoIva = CampoProveedor("Iva")
                            varTipoPrv = CampoProveedor("Tipo") + 1
                            varPorceIb = CampoProveedor("PorceIb")
                            varPorceIbCaba = CampoProveedor("PorceIbCaba")

                        End If

                        Dim compra As DataRow = Nothing
                        Try
                            compra = _BuscarCompra(CCPrv.nroInterno)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try

                        If Not IsNothing(compra) Then

                            varLetra = compra("Letra")
                            varNeto = compra("Neto")
                            varIva = compra("iva21")
                            varIva5 = compra("Iva5")
                            varIva27 = compra("Iva27")
                            varIva105 = compra("iva105")
                            varIb = compra("Ib")
                            varExento = compra("Exento")
                            varTotalTrabajo = varNeto + varIva + varIva5 + varIva27 + varIva105 + varIb + varExento

                        End If

                        'varRetIbI = 0
                        'varRetIbII = 0
                        'varRetIb = 0
                        'varRetIva = 0
                        'varRetGan = 0

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
                        If compra Is Nothing OrElse compra.Item("Rechazado") <> 1 Then
                            varRetIbI = CaculoRetencionIngresosBrutos(varTipoIb, varPorceIb, varAcumulaNeto)
                        End If

                        '
                        'calculo de retencion de Ingresos brutos CABA. SOLO PARA SURFACTAN.
                        '
                        If varEmpresa = 1 And (compra Is Nothing OrElse compra.Item("Rechazado") <> 1) Then

                            If Val(varPorceIbCaba) <> 0 And Val(varTipoIbCaba) <> 2 Then
                                varRetIbII = CaculoRetencionIngresosBrutosCaba(varTipoIbCaba, varPorceIbCaba, varAcumulaNeto)
                            End If

                        End If


                        '
                        'calculo de rtencion de Ganancias
                        '

                        varAcuNeto = varAcumulaNeto
                        varAcuRetenido =
                        varAcuAnticipo = 0
                        varAcuBruto = 0
                        varAcuIva = 0

                        varOrdFecha = Mid(ordenaFecha(txtFechaEmision.Text), 3, 4)

                        Dim CampoAcumulado = Nothing

                        Try
                            CampoAcumulado = _BuscarAcumulado(varProveedor, varOrdFecha)

                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try

                        If Not IsNothing(CampoAcumulado) Then

                            varAcuNeto = CampoAcumulado("Neto")
                            varAcuRetenido = CampoAcumulado("Retenido")
                            varAcuAnticipo = CampoAcumulado("Anticipo")
                            varAcuBruto = CampoAcumulado("Bruto")
                            varAcuIva = CampoAcumulado("Iva")

                        Else

                            varAcuNeto = 0
                            varAcuRetenido = 0
                            varAcuAnticipo = 0
                            varAcuBruto = 0
                            varAcuIva = 0

                        End If

                        Dim varAcuNetoOrig As Double = varAcuNeto

                        If compra Is Nothing OrElse compra.Item("Rechazado") <> 1 Then
                            varRetGan = CaculoRetencionGanancia(varTipoPrv, varAcumulaNeto, varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva)
                        End If

                        '
                        'calculo de rtencion de IVA
                        '
                        If varLetra = "M" And (compra Is Nothing OrElse compra.Item("Rechazado") <> 1) Then
                            If varNeto >= 1000 Then
                                varAcumulaIva = varAcumulaIva + varIva
                            End If
                            varRetIva = varAcumulaIva
                        End If

                        If compra IsNot Nothing AndAlso compra.Item("MarcaDifCambio") = 1 Then
                            varParidad = 0
                            varTotalUs = 0
                            varSaldoUs = 0
                            CCPrv.Impre = "NDC"
                            varPago = 1
                        End If

                        varRetIb = varRetIbI + varRetIbII + varRetIva

                        varDifCambio = 0

                        varAcuNeto = (varAcumulado - varRetIb - varRetGan)

                        If varParidad = 0 Then
                            varPesosOrig = varSaldo
                        Else
                            varPesosOrig = varParidad * varSaldoUs
                        End If

                        AcumPesosOrigII += varPesosOrig
                        varAcumPesosNetoParaIB += varAcumulaNetoII
                        varAcumPesosNetoParaGanancias += varAcumulaNetoII - (varDife / 1.21)

                        If varParidad <> 0 Then

                            If compra.Item("MarcaDifCambio") = 0 Then

                                Dim WIbI As Double = 0.0
                                Dim WIbII As Double = 0.0
                                Dim WIbIII = 0.0
                                Dim WIbIV = 0.0

                                If compra Is Nothing OrElse compra.Item("Rechazado") <> 1 Then
                                    WIbI = CaculoRetencionIngresosBrutos(varTipoIb, varPorceIb, varAcumPesosNetoParaIB)
                                    WIbIII = CaculoRetencionIngresosBrutos(varTipoIb, varPorceIb, varAcumPesosNetoParaGanancias)
                                End If

                                If varEmpresa = 1 And (compra Is Nothing OrElse compra.Item("Rechazado") <> 1) Then

                                    If Val(varPorceIbCaba) <> 0 And Val(varTipoIbCaba) <> 2 Then
                                        WIbII = CaculoRetencionIngresosBrutosCaba(varTipoIbCaba, varPorceIbCaba, varAcumPesosNetoParaIB)
                                        WIbIV = CaculoRetencionIngresosBrutosCaba(varTipoIbCaba, varPorceIbCaba, varAcumPesosNetoParaGanancias)
                                    End If

                                End If

                                Dim WRetGananciasDC As Double

                                If compra Is Nothing OrElse compra.Item("Rechazado") <> 1 Then

                                    WRetGananciasDC = CaculoRetencionGanancia(varTipoPrv, varAcumPesosNetoParaGanancias, varAcuNetoOrig, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva)

                                End If

                                If varRetGan <> 0 Or varPago = 2 Then
                                    varDifCambio = varAcuNeto - (AcumPesosOrigII - WIbIII - WIbIV - WRetGananciasDC) - AcumDifCambio
                                Else
                                    varDifCambio = varAcuNeto - (AcumPesosOrigII - WIbI - WIbII - WRetGananciasDC) - AcumDifCambio
                                End If

                                AcumDifCambio += varDifCambio

                            End If

                            'AcumPesosOrig = IIf(varDifCambio >= 0, (varAcuNeto - AcumDifCambio), varAcuNeto)
                            AcumPesosOrig = varAcuNeto - AcumDifCambio


                        ElseIf compra IsNot Nothing AndAlso compra.Item("Rechazado") = 1 Then
                            AcumPesosOrig += varPesosOrig
                        Else
                            AcumPesosOrig = varAcuNeto - AcumDifCambio
                        End If

                        Try
                            'SQLConnector.executeProcedure("alta_impCtaCtePrvNetII", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra,
                            '                              CCPrv.punto, CCPrv.numero, varTotal, varSaldo, CCPrv.fecha, CCPrv.vencimiento, CCPrv.VencimientoII,
                            '                              CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, varAcumulado, WOrden, txtFechaEmision.Text, "", "", "",
                            '                              varParidadTotal, varSaldoOriginal, varDife, 0, 0, "", varRetIb, varRetGan, varAcuNeto, varParidad,
                            '                              varTotalUs, varSaldoUs, varAcumulaUs, varPago, IIf(varParidad = 0, 0, varPesosOrig),
                            '                              varDifCambio, AcumDifCambio, AcumPesosOrig)

                            Dim r2 As DataRow = WTabla.NewRow

                            With r2
                                .Item("Clave") = CCPrv.Clave
                                .Item("Proveedor") = CCPrv.Proveedor
                                .Item("Tipo") = CCPrv.Tipo
                                .Item("Letra") = CCPrv.letra
                                .Item("Punto") = CCPrv.punto
                                .Item("Numero") = CCPrv.numero
                                .Item("Total") = varTotal
                                .Item("Saldo") = varSaldo
                                .Item("Fecha") = CCPrv.fecha
                                .Item("Vencimiento") = CCPrv.vencimiento
                                .Item("Vencimiento1") = CCPrv.VencimientoII
                                .Item("Impre") = CCPrv.Impre
                                .Item("NroInterno") = CCPrv.nroInterno
                                .Item("Empresa") = varEmpresa
                                .Item("Acumulado") = varAcumulado
                                .Item("Orden") = WOrden
                                .Item("Titulo1") = txtFechaEmision.Text
                                .Item("Impre1") = varParidadTotal
                                .Item("Impre2") = varSaldoOriginal
                                .Item("Impre3") = varDife
                                .Item("RetIb") = varRetIb
                                .Item("RetGanan") = varRetGan
                                .Item("AcuNeto") = varAcuNeto
                                .Item("Paridad") = varParidad
                                .Item("TotalUs") = varTotalUs
                                .Item("SaldoUs") = varSaldoUs
                                .Item("AcumulaUs") = varAcumulaUs
                                .Item("Pago") = varPago
                                .Item("PesosOrig") = IIf(varParidad = 0, 0, varPesosOrig)
                                .Item("Difcambio") = varDifCambio
                                .Item("AcumDifCambio") = AcumDifCambio
                                .Item("AcumPesosOrig") = AcumPesosOrig
                                .Item("MarcaVirtual") = OrDefault(row("MarcaVirtual"), "")

                                .Item("Nombre") = OrDefault(datosProveedor("Nombre"), "")
                                .Item("NombreCheque") = OrDefault(datosProveedor("NombreCheque"), "")
                                .Item("ImpreCuitCliente") = OrDefault(datosProveedor("ImpreCuitCliente"), "")
                                .Item("FormaPago") = OrDefault(datosProveedor("FormaPago"), "")
                            End With

                            WTabla.Rows.Add(r2)

                            'If OrDefault(row("MarcaVirtual"), "") = "X" Then ExecuteNonQueries({"UPDATE impCtaCtePrvNet SET MarcaVirtual = 'X' WHERE Clave = '" & row("Clave") & "'"})
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try


                    Next
                End If

            End If

            ProgressBar1.Increment(1)

        Next

        '_ActualizarMarcaCuitCliente()

        'ds.Tables.AddRange({New DBAuxi.AvisosNoEnviadosDataTable, New DBAuxi.TablaArqueoChequesDataTable, New DBAuxi.TablaChequesAQueFacturaDataTable, WTabla, WTablaProveedor})

        BackgroundWorker1.ReportProgress(0, WTabla)

    End Sub

    Private Sub _ActualizarMarcaCuitCliente()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "UPDATE Proveedor SET ImpreCuitCliente = ''"
            cm.ExecuteNonQuery()

            cm.CommandText = "UPDATE Proveedor SET ImpreCuitCliente = '1' FROM Proveedor INNER JOIN Cliente ON Proveedor.Cuit = Cliente.Cuit"
            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar la marca de Proveedor con mismo cuit que Cliente consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtDesdeProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesdeProveedor.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtDesdeProveedor.Text) = "" Then
                btnConsulta.PerformClick()
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

    Private Sub btnLimpiarTodo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiarTodo.Click
        _DeshabilitarConsulta()

        Dim WFecha = txtFechaEmision.Text

        For Each _C As TextBox In Panel2.Controls.OfType(Of TextBox)()
            _C.Text = ""
        Next

        For Each _C As MaskedTextBox In Panel2.Controls.OfType(Of MaskedTextBox)()
            _C.Clear()
        Next

        GRilla.Rows.Clear()

        txtFechaEmision.Text = WFecha
        txtFechaEmision.Focus()

        varRenglon = 0

    End Sub

    Private Sub lstAyuda_Filtrada_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstAyuda_Filtrada.Click
        If Trim(lstFiltrada.SelectedItem) <> "" Then
            _AgregarProveedorAListadoGeneral(lstFiltrada.SelectedItem)
        End If
    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick
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

    Private Sub lstFiltrada_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        If Trim(filtrado.SelectedItem) = "" Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPantalla.Click
        If Not BackgroundWorker1.IsBusy Then
            WTipoSalida = Reporte.Pantalla
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click

        If Not BackgroundWorker1.IsBusy Then
            WTipoSalida = Reporte.Imprimir
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub CustomButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CustomButton1.Click

        If txtFechaEmision.Text.Replace(" ", "").Length = 10 Then
            _CargarProveedoresPreCargados()
        Else
            MsgBox("Debe indicar una fecha de Pago.", MsgBoxStyle.Exclamation)
            txtFechaEmision.Focus()
            Exit Sub
        End If

        txtDesdeProveedor.Focus()

    End Sub

    Private Sub GRilla_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles GRilla.CellMouseDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex = 2 Then : Exit Sub : End If
        Dim fila = GRilla.Rows(e.RowIndex)
        If Not IsNothing(fila) Then

            If Trim(fila.Cells(0).Value) <> "" Then

                If MsgBox("¿Seguro de querer eliminar el Proveedor Seleccionado?", MsgBoxStyle.YesNo, MsgBoxStyle.Information) = DialogResult.Yes Then
                    GRilla.Rows.Remove(fila)
                End If

            End If

        End If
    End Sub

    Private Sub ListadoCuentaCorrienteProveedoresSelectivo_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtFechaEmision.Focus()
    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 109)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If GRilla.Focused Or GRilla.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = GRilla.CurrentCell.ColumnIndex
            Dim iRow = GRilla.CurrentCell.RowIndex

            ' Limitamos los caracteres permitidos para cada una de las columnas.
            Select Case iCol
                Case 0
                    If Not _EsNumeroOControl(keyData) Then
                        Return True
                    End If
            End Select

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = GRilla.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then

                        Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(valor)

                        If Not IsNothing(proveedor) Then
                            If Not _ProveedorYaAgregado(proveedor.id, iRow) Then
                                GRilla.Rows(iRow).Cells(1).Value = Trim(proveedor.razonSocial)

                                If GRilla.Rows.Count < iRow + 1 Then
                                    GRilla.CurrentCell = GRilla.Rows(GRilla.Rows.Add).Cells(iCol)
                                Else
                                    GRilla.CurrentCell = GRilla.Rows(iRow + 1).Cells(iCol)
                                End If
                            Else
                                MsgBox("Proveedor ya cargado con anterioridad.", MsgBoxStyle.Information)
                                GRilla.CurrentCell = GRilla.Rows(iRow).Cells(iCol)
                            End If

                        End If

                    End If

                    Return True
                Else

                    With GRilla
                        Select Case iCol
                            Case 0, 1
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                        End Select
                    End With

                    Return True

                End If
            ElseIf msg.WParam.ToInt32() = Keys.Escape Then

                With GRilla
                    .Rows(iRow).Cells(iCol).Value = ""

                    ' Solo para que pierda el foco y se refresque el contenido sino sigue quedando ahi.
                    If iCol = 1 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End With


            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub txtFechaEmision_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaEmision.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaEmision.Text).Replace("/", "") = "" Then : Exit Sub : End If

            If _ExistenProveedoresCargados() Then

                If MsgBox("Existen Proveedores cargados para esta fecha ¿Desea traerlos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CustomButton1.PerformClick()
                    Exit Sub
                End If

            End If

            txtDesdeProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEmision.Text = ""
        End If

    End Sub

    Private Function _ExistenProveedoresCargados() As Boolean
        Dim WExistenProveedoresCargados As Boolean

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Proveedor FROM ProveedorSelectivo WHERE Fecha = '" & txtFechaEmision.Text & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            WExistenProveedoresCargados = dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        Return WExistenProveedoresCargados
    End Function

    Private Sub btnCerrarConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrarConsulta.Click
        _DeshabilitarConsulta()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _Imprimir(WTipoSalida)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim WTabla As DataTable = TryCast(e.UserState, DataTable)

        Dim rpt As New ListadoCtaCtePrvSelectivoPrueba
        rpt.SetDataSource(WTabla)

        With New VistaPrevia

            .Reporte = rpt

            .Reconectar = False

            .Formula = "{impCtaCtePrvNet.Proveedor} in '' to 'ZZZZZZZZZZZ' and {impCtaCtePrvNet.Saldo} <> 0.00"

            Select Case WTipoSalida
                Case Reporte.Imprimir
                    .Imprimir()
                Case Reporte.Pantalla
                    .Mostrar()
            End Select
        End With

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Value = 0

        If WTipoSalida = Reporte.Imprimir Then
            MsgBox("El reporte se ha impreso correctamente.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As EventArgs) Handles CustomButton2.Click
        Dim s As DataTable = GetAll("Select distinct proveedor from ctacteprv where pago = 2")

        For Each r As DataRow In s.Rows
            GRilla.Rows.Add(r("proveedor"))
        Next
    End Sub
End Class