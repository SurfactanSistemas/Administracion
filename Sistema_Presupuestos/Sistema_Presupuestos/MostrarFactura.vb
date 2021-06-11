Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class MostrarFactura

    Sub New(ByVal NroInterno As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_NroInterno.Text = NroInterno

    End Sub


    Dim esModificacion As Boolean = False
    Private _RetIB1, _RetIB2, _RetIB3, _RetIB4, _RetIB5, _RetIB6, _RetIB7, _
            _RetIB8, _RetIB9, _RetIB10, _RetIB11, _RetIB12, _RetIB13, _RetIB14, _RetIB15, _RetIB16 As String
    Private Sub MostrarFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _BuscarCompraPorNumeroInterno()
    End Sub

    Private Sub _BuscarCompraPorNumeroInterno()
        Dim interno As String = txt_NroInterno.Text
        Dim SQLCnslt As String = "SELECT * FROM IvaComp ic WHERE ic.NroInterno = '" & interno & "'"
        Dim RowCompra As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowCompra IsNot Nothing Then
            '   apertura = New Apertura
            mostrarCompra(RowCompra)
            _RecalcularTotal()
            'Else
            '    esModificacion = False
            '    btnLimpiar.PerformClick()
            '    txtNroInterno.Text = interno
            '    txtCodigoProveedor.Focus()
        End If
    End Sub

    Private Sub _RecalcularTotal()
        txtTotal.Text = formatonumerico(calculoTotal())
    End Sub

    Private Sub mostrarCompra(ByVal RowCompra As DataRow)

        mostrarProveedor(RowCompra.Item("proveedor"))
        esModificacion = True
        txtTipo.Text = RowCompra.Item("tipo")

        If RowCompra.Item("tipo") = 99 Then
            For Each o As Object In cmbTipo.Items
                If o = "OC" Then
                    cmbTipo.SelectedItem = o
                    Exit For
                End If
            Next
        ElseIf RowCompra.Item("tipo") = 66 Then
            For Each o As Object In cmbTipo.Items
                If o = "DI" Then
                    cmbTipo.SelectedItem = o
                    Exit For
                End If
            Next
        ElseIf RowCompra.Item("tipo") >= 0 Then
            cmbTipo.SelectedIndex = RowCompra.Item("tipo")
        Else
            cmbTipo.SelectedIndex = 0
        End If

        CBLetra.SelectedItem = RowCompra.Item("letra")
        txtPunto.Text = RowCompra.Item("punto")
        txtNumero.Text = RowCompra.Item("numero")
        txtFechaEmision.Text = RowCompra.Item("fecha")
        txtFechaIVA.Text = RowCompra.Item("Periodo")
        txtFechaVto1.Text = RowCompra.Item("Vencimiento")
        'txtFechaVto2.Text = compra.fechaVto2
        txtRemito.Text = RowCompra.Item("remito")
        cmbFormaPago.SelectedIndex = RowCompra.Item("Pago")
        txtParidad.Text = formatonumerico(RowCompra.Item("paridad"), 4)
        txtNeto.Text = formatonumerico(RowCompra.Item("neto"))
        txtIVA10.Text = formatonumerico(RowCompra.Item("iva105"))
        txtIVA21.Text = formatonumerico(RowCompra.Item("iva21"))
        txtIVA27.Text = formatonumerico(RowCompra.Item("iva27"))
        txtIVARG.Text = formatonumerico(RowCompra.Item("iva5"))
        txtPercIB.Text = formatonumerico(RowCompra.Item("IB"))
        txtNoGravado.Text = formatonumerico(RowCompra.Item("exento"))
        txtDespacho.Text = RowCompra.Item("despacho")
        'chkSoloIVA.Checked = RowCompra.Item("soloIVA")
        pulsarOption(RowCompra.Item("Contado"))

        If txtCAI.Visible = True Then
            txtCAI.Text = RowCompra.Item("Cai")
            txtVtoCAI.Text = RowCompra.Item("VtoCai")
        End If

        traerValoresIb(txt_NroInterno.Text)
        txtImporte_Leave(Nothing, Nothing)
        mostrarImputaciones(txt_NroInterno.Text)

        'ckChequeRechazado.Checked = _BuscarRechazado(compra.nroInterno)
        'ckMarcaDifCambio.Checked = _BuscarMarcaDifCambio(compra.nroInterno)

        calcularAsiento()
    End Sub

    Public Sub mostrarProveedor(ByVal CodProveedor As String)

        Dim SQLCnslt As String = "SELECT ISNULL(Proveedor,'') as Proveedor " _
        & " ,ISNULL(Nombre,'') as Nombre" _
        & " , ISNULL(Iva,'') as Iva" _
        & " , ISNULL(Cai,'') as Cai " _
        & " , ISNULL(VtoCai,'') as VtoCai" _
        & " FROM Proveedor p WHERE p.Proveedor = '" & CodProveedor & "'"

        Dim RowProveedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        'If Not optNacion.Checked Then
        '    proveedor = proveedorAMostrar
        'End If
        txt_CodigoProveedor.Text = RowProveedor.Item("Proveedor")
        txtNombreProveedor.Text = RowProveedor.Item("Nombre")

        CBLetra.SelectedItem = "A"
        cmbFormaPago.SelectedIndex = 0

        If Val(RowProveedor.Item("Iva")) = 5 Or Val(RowProveedor.Item("Iva")) = 3 Then
            cmbTipo.SelectedItem = "FC"
            CBLetra.SelectedItem = "C"
            _HabilitarDeshabilitarControlesSegunLetra()
        End If

        _MostrarCAI(RowProveedor.Item("cai"), RowProveedor.Item("vtocai"))
        'diasPlazo = _ExtraerSoloNumeros(proveedorAMostrar.diasPlazo)

        'COMENTADO ANDRES
        'Buscar_Presupuestos(proveedorAMostrar.id, proveedorAMostrar.razonSocial)

    End Sub

    Private Sub _HabilitarDeshabilitarControlesSegunLetra()
        Dim _controles As New List(Of TextBox) From {txtIVA21, txtIVA10, txtIVARG, txtIVA27, txtPercIB, txtNoGravado}
        If UCase(CBLetra.SelectedItem) = "C" Then
            For Each _c In _controles
                _c.Enabled = False
            Next
            txtTotal.Enabled = True


            If Trim(txtCAI.Text) <> "" And Trim(txtVtoCAI.Text.Replace("/", "")) <> "" Then
                _HabilitarCAI()
            End If

        Else
            For Each _c In _controles
                _c.Enabled = True
            Next

            If Val(txtIVA21.Text) = 0 Or Trim(txtIVA21.Text) = "" Then
                txtIVA21.Text = formatonumerico(Val(txtNeto.Text) * 0.21)
                _RecalcularTotal()
            End If

            txtTotal.Enabled = False

            _DeshabilitarCAI()
        End If
        
    End Sub


    Private Sub _MostrarCAI(ByVal Cai As String, ByVal Vtocai As String)

        txtCAI.Text = Cai
        txtVtoCAI.Text = ordenaFecha(Vtocai)

        If CBLetra.SelectedItem = "C" Then
            _HabilitarCAI()
        End If

    End Sub
    Private Sub _HabilitarCAI()
        lblCai.Visible = True
        lblVtoCai.Visible = True
        txtCAI.Visible = True
        txtVtoCAI.Visible = True
    End Sub

    Private Sub _DeshabilitarCAI()
        lblCai.Visible = False
        lblVtoCai.Visible = False
        txtCAI.Visible = False
        txtVtoCAI.Visible = False
    End Sub
    Private Sub pulsarOption(ByVal val As Integer)
        Select Case val
            Case 3
                optNacion.Checked = True
            Case 2
                optCtaCte.Checked = True
            Case Else
                optEfectivo.Checked = True
        End Select
    End Sub

    Private Sub traerValoresIb(ByVal nroInterno As String)


        Dim SQLCnslt As String = "SELECT TOP 1 RetIB1, RetIB2, RetIB3, RetIB4, RetIB5, RetIB6, RetIB7, RetIB8, RetIB9, RetIB10, RetIB11, RetIB12, RetIB13, RetIB14, RetIB15, RetIB16 FROM IvaComp WHERE NroInterno = '" & Trim(nroInterno) & "'"

        Try

            Dim RowIvaComp As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowIvaComp IsNot Nothing Then


                _RetIB1 = IIf(IsDBNull(RowIvaComp.Item("RetIB1")), "", RowIvaComp.Item("RetIB1"))
                _RetIB2 = IIf(IsDBNull(RowIvaComp.Item("RetIB2")), "", RowIvaComp.Item("RetIB2"))
                _RetIB3 = IIf(IsDBNull(RowIvaComp.Item("RetIB3")), "", RowIvaComp.Item("RetIB3"))
                _RetIB4 = IIf(IsDBNull(RowIvaComp.Item("RetIB4")), "", RowIvaComp.Item("RetIB4"))
                _RetIB5 = IIf(IsDBNull(RowIvaComp.Item("RetIB5")), "", RowIvaComp.Item("RetIB5"))
                _RetIB6 = IIf(IsDBNull(RowIvaComp.Item("RetIB6")), "", RowIvaComp.Item("RetIB6"))
                _RetIB7 = IIf(IsDBNull(RowIvaComp.Item("RetIB7")), "", RowIvaComp.Item("RetIB7"))
                _RetIB8 = IIf(IsDBNull(RowIvaComp.Item("RetIB8")), "", RowIvaComp.Item("RetIB8"))
                _RetIB9 = IIf(IsDBNull(RowIvaComp.Item("RetIB9")), "", RowIvaComp.Item("RetIB9"))
                _RetIB10 = IIf(IsDBNull(RowIvaComp.Item("RetIB10")), "", RowIvaComp.Item("RetIB10"))
                _RetIB11 = IIf(IsDBNull(RowIvaComp.Item("RetIB11")), "", RowIvaComp.Item("RetIB11"))
                _RetIB12 = IIf(IsDBNull(RowIvaComp.Item("RetIB12")), "", RowIvaComp.Item("RetIB12"))
                _RetIB13 = IIf(IsDBNull(RowIvaComp.Item("RetIB13")), "", RowIvaComp.Item("RetIB13"))
                _RetIB14 = IIf(IsDBNull(RowIvaComp.Item("RetIB14")), "", RowIvaComp.Item("RetIB14"))
                _RetIB15 = IIf(IsDBNull(RowIvaComp.Item("RetIB15")), "", RowIvaComp.Item("RetIB15"))
                _RetIB16 = IIf(IsDBNull(RowIvaComp.Item("RetIB16")), "", RowIvaComp.Item("RetIB16"))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub txtImporte_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtIVARG.Leave, txtPercIB.Leave, txtNoGravado.Leave, txtIVA27.Leave, txtIVA21.Leave, txtIVA10.Leave
        If esModificacion Then : Exit Sub : End If
        Dim total As Double = calculoTotal()
        txtTotal.Text = formatonumerico(total)
    End Sub

    Private Function calculoTotal() As Double

        If UCase(CBLetra.SelectedItem) = "C" Then
            Return Val(txtNeto.Text)
        End If

        Return Val(txtIVA21.Text) + Val(txtIVARG.Text) + Val(txtIVA27.Text) + Val(txtPercIB.Text) + Val(txtNoGravado.Text) + Val(txtIVA10.Text) + Val(txtNeto.Text)
    End Function

    Private Sub calcularAsiento()
        Dim valorDebe As Double = 0
        Dim valorHaber As Double = 0

        For Each row As DataGridViewRow In gridAsientos.Rows
            valorDebe += Val(row.Cells(2).Value)
            valorHaber += Val(row.Cells(3).Value)
        Next
        lblDebito.Text = formatonumerico(valorDebe)
        lblCredito.Text = formatonumerico(valorHaber)
    End Sub
    Private Sub mostrarImputaciones(ByVal interno As Integer)
        gridAsientos.Rows.Clear()
        

        Try
            Dim SQLCnslt As String = "SELECT * FROM Imputac im WHERE im.NroInterno = '" & interno & "'"
            'Dim SQLCnslt As String = "SELECT LTRIM(RTRIM(cu.Cuenta)) as Cuenta, LTRIM(RTRIM(cu.Descripcion)) as Descripcion, Debito, Credito FROM Cuenta cu WHERE Cuenta = '" & interno & "'"

            Dim table As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            For Each row As DataRow In table.Rows
                gridAsientos.Rows.Add(row.Item("cuenta"), TraerDescripCuenta(row.Item("cuenta")), row.Item("debito"), row.Item("credito"))
            Next
        Catch ex As Exception

        End Try
        
           
    End Sub

    Private Function TraerDescripCuenta(ByVal Cuenta As Integer) As String
        Try

            Dim SQLCnslt As String = "SELECT LTRIM(RTRIM(cu.Cuenta)) as Cuenta, LTRIM(RTRIM(cu.Descripcion)) as Descripcion FROM Cuenta cu WHERE Cuenta = '" & Cuenta & "'"

            Dim RowAux As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowAux IsNot Nothing Then
                Return RowAux.Item("Descripcion")
            End If
            
        Catch ex As Exception

        End Try

        Return ""

    End Function


End Class