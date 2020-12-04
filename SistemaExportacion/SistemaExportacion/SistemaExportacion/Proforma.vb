Imports System.Data.SqlClient
Imports System.IO
Imports ArmadoPallets
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop
Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class Proforma : Implements IConsultaPedPrepo

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 8
    Private Const SEPARADOR_CONSULTA = "____"

    ' Control de Idiomas
    Private MOSTRAR_MSG_IDIOMAS As Boolean = True
    Private VIAS_ESP = {"", "TERRESTRE", "AÉREA", "MARÍTIMA"}
    Private VIAS_ING = {"", "LAND ROUTE", "BY AIR", "BY SEA"}

    Private NROPEDIDOPRO As String = ""

    Private _NroProforma As String
    Public Property NroProforma() As String
        Get
            Return _NroProforma
        End Get
        Set(ByVal value As String)
            _NroProforma = ceros(value, 6)
        End Set
    End Property


    Public Property Bloqueado As Boolean


    Private Sub Proforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsNothing(Me.NroProforma) Then
            txtNroProforma.Text = Me.NroProforma
            MOSTRAR_MSG_IDIOMAS = False

            txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            CargarDatosAdicionales()


        Else
            btnLimpiar.PerformClick()
        End If

    End Sub

    Private Sub _TraerProximoNroProforma()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Proforma FROM ProformaExportacion ORDER BY Proforma DESC")
        Dim dr As SqlDataReader
        Dim ultimo = 0

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                ultimo = IIf(IsDBNull(dr.Item("Proforma")), 0, dr.Item("Proforma"))
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al consultar el próximo Nro de Proforma.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtNroProforma.Text = ceros(ultimo + 1, 6)
    End Sub

    Private Sub Proforma_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtNroProforma.Focus()
    End Sub

    Private Function _CS()
        Return _ConectarA()
        'Return Helper._ConectarA(empresa)
    End Function

    Private Function _TraerDescripcionProducto(ByVal codigo As String) As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Terminado WHERE Codigo = '" & codigo & "'")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()

            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                Return dr.Item("Descripcion")
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Exclamation)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""

    End Function

    Private Sub _ProcesarDatosGrilla()
        For Each row As DataGridViewRow In dgvProductos.Rows
            With row

                If Trim(.Cells(0).Value) <> "" Then

                    .Cells(1).Value = _TraerDescripcionProducto(.Cells(0).Value)
                    .Cells(2).Value = formatonumerico(.Cells(2).Value)
                    .Cells(3).Value = formatonumerico(.Cells(3).Value)

                    .Cells(4).Value = formatonumerico((Val(.Cells(2).Value) * Val(.Cells(3).Value)))

                Else
                    Exit For
                End If

            End With
        Next

        '_RecalcularTotal()
        _NormalizarNumerosGrilla()
    End Sub

    Private Sub _LimpiarGrilla()

        dgvProductos.Rows.Clear()

        For i = 0 To PRODUCTOS_MAX - 1
            dgvProductos.Rows.Add("", "", "", "", "")
        Next

        dgvProductos.ClearSelection()

    End Sub

    Private Sub _TraerProforma(ByVal NroProforma As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT p.Renglon, p.Proforma, p.Estado, p.Fecha, p.FechaLimite, p.Cliente, c.Razon, p.Direccion, p.Localidad, p.CondPago, p.OCCliente, p.Condicion, p.Via, p.Observaciones, p.SubTotal, p.Flete, p.Seguro, p.Total, p.DescriTotal, p.Pais, p.CondPagoII, p.ObservacionesII, p.ObservacionesIII, p.DescriTotalII, p.Producto, p.Cantidad, p.Precio, p.Cerrada, p.PackingList, p.Idioma, p.Entregado, p.Otros, p.MotivoOtros FROM ProformaExportacion as p, Cliente as c WHERE Proforma = '" & NroProforma & "' AND p.Cliente = c.Cliente ORDER BY Renglon")
        Dim dr As SqlDataReader
        Dim WRenglon, WEstado, WNroProforma, WFecha, WCliente, WDescripcionCliente, WDireccion, WLocalidad, WCondPago, WOCCliente, WCondicion, WVia, WObservaciones, WSubTotal, WFlete, WSeguro, WTotal, WDescripcionMonto, WPais, WCondPagoII, WObservacionesII, WObservacionesIII, WDescripcionMontoII, WRowIndex
        Dim WNroPedido, WNroFactura, WEntregado, WEnviarDocumentacion, WProformaCerrada, WPackingList, WIdioma, WFechaLimite

        WRenglon = 0
        WEstado = 0
        WNroProforma = ""
        WFecha = ""
        WCliente = ""
        WDescripcionCliente = ""
        WDireccion = ""
        WLocalidad = ""
        WCondPago = ""
        WOCCliente = ""
        WCondicion = ""
        WVia = 0
        WObservaciones = ""
        WSubTotal = 0.0
        WFlete = 0.0
        WSeguro = 0.0
        WTotal = 0.0
        Dim WOtros As Double = 0.0
        Dim WMotivoOtros As String = ""
        WDescripcionMonto = ""
        WPais = ""
        WCondPagoII = ""
        WObservacionesII = ""
        WObservacionesIII = ""
        WDescripcionMontoII = ""

        ' Completarlas cuando se definan desde ventas.
        WNroPedido = ""
        WNroFactura = ""
        WEntregado = ""
        WEnviarDocumentacion = ""
        WProformaCerrada = ""
        WPackingList = ""
        WFechaLimite = ""
        WIdioma = 0

        btnLimpiar.PerformClick()

        WRowIndex = 0

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                Do While dr.Read()
                    With dr

                        WRenglon = IIf(IsDBNull(.Item("Renglon")), 0, .Item("Renglon"))

                        If Val(.Item("Renglon")) = 1 Then

                            WEstado = IIf(IsDBNull(.Item("Estado")), 0, .Item("Estado"))
                            WNroProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                            WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                            WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                            WDescripcionCliente = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            WDireccion = IIf(IsDBNull(.Item("Direccion")), "", .Item("Direccion"))
                            WLocalidad = IIf(IsDBNull(.Item("Localidad")), "", .Item("Localidad"))
                            WCondPago = IIf(IsDBNull(.Item("CondPago")), "", .Item("CondPago"))
                            WOCCliente = IIf(IsDBNull(.Item("OCCliente")), "", .Item("OCCliente"))
                            WCondicion = IIf(IsDBNull(.Item("Condicion")), "", .Item("Condicion"))
                            WVia = IIf(IsDBNull(.Item("Via")), 0, .Item("Via"))
                            WObservaciones = IIf(IsDBNull(.Item("Observaciones")), "", .Item("Observaciones"))
                            WSubTotal = IIf(IsDBNull(.Item("SubTotal")), 0.0, .Item("SubTotal"))
                            WFlete = IIf(IsDBNull(.Item("Flete")), 0.0, .Item("Flete"))
                            WSeguro = IIf(IsDBNull(.Item("Seguro")), 0.0, .Item("Seguro"))
                            WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))
                            WDescripcionMonto = IIf(IsDBNull(.Item("DescriTotal")), "", .Item("DescriTotal"))
                            WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                            WCondPagoII = IIf(IsDBNull(.Item("CondPagoII")), "", .Item("CondPagoII"))
                            WObservacionesII = IIf(IsDBNull(.Item("ObservacionesII")), "", .Item("ObservacionesII"))
                            WObservacionesIII = IIf(IsDBNull(.Item("ObservacionesIII")), "", .Item("ObservacionesIII"))
                            WDescripcionMontoII = IIf(IsDBNull(.Item("DescriTotalII")), "", .Item("DescriTotalII"))
                            WProformaCerrada = IIf(IsDBNull(.Item("Cerrada")), "0", .Item("Cerrada"))
                            WPackingList = IIf(IsDBNull(.Item("PackingList")), "0", .Item("PackingList"))
                            WIdioma = IIf(IsDBNull(.Item("Idioma")), 0, .Item("Idioma"))
                            WFechaLimite = IIf(IsDBNull(.Item("FechaLimite")), "", .Item("FechaLimite"))
                            WEntregado = IIf(IsDBNull(.Item("Entregado")), "", .Item("Entregado"))

                            WOtros = IIf(IsDBNull(.Item("Otros")), 0.0, .Item("Otros"))
                            WMotivoOtros = IIf(IsDBNull(.Item("MotivoOtros")), "", .Item("MotivoOtros"))


                            txtNroProforma.Text = WNroProforma
                            txtFecha.Text = WFecha
                            txtCliente.Text = WCliente
                            txtDescripcionCliente.Text = WDescripcionCliente
                            txtDireccionCliente.Text = WDireccion
                            txtLocalidadCliente.Text = WLocalidad
                            txtCondicionPago.Text = WCondPago
                            txtCondicionPagoII.Text = WCondPagoII
                            txtOCCliente.Text = WOCCliente
                            cmbCondicion.SelectedIndex = Val(WCondicion)
                            cmbVia.SelectedIndex = WVia
                            txtObservaciones.Text = WObservaciones
                            txtObservacionesII.Text = WObservacionesII
                            txtObservacionesIII.Text = WObservacionesIII
                            txtDescripcionTotal.Text = WDescripcionMonto
                            txtDescripcionTotalII.Text = WDescripcionMontoII
                            txtPais.Text = WPais
                            txtSubTotal.Text = formatonumerico(WSubTotal)
                            cmbEstado.SelectedIndex = Val(WEstado)
                            cmbIdioma.SelectedIndex = Val(WIdioma)
                            txtFechaLimite.Text = WFechaLimite


                            txt_MotivoOtros.Text = WMotivoOtros
                            txt_Otros.Text = WOtros


                            If Val(WProformaCerrada) = 1 Then
                                ckCerrado.Checked = True
                            End If

                            If Val(WPackingList) = 1 Then
                                ckPakingList.Checked = True
                            End If

                            txtNroFactura.Text = WNroFactura
                            txtNroPedido.Text = WNroPedido
                            txtSaldoFactura.Text = ""

                            txtFlete.Text = formatonumerico(WFlete)
                            txtSeguro.Text = formatonumerico(WSeguro)

                            If UCase(WEntregado) = "X" then
                                btnEntregado.Visible=False
                                gbEntregado.Visible = True
                            End If

                            If Val(WEstado) = 1 Then
                                Me.Bloqueado = True
                            End If

                        End If

                        WRowIndex = Val(WRenglon) - 1

                        dgvProductos.Rows(WRowIndex).Cells(0).Value = IIf(IsDBNull(.Item("Producto")), "", .Item("Producto"))
                        dgvProductos.Rows(WRowIndex).Cells(2).Value = IIf(IsDBNull(.Item("Cantidad")), "", .Item("Cantidad"))
                        dgvProductos.Rows(WRowIndex).Cells(3).Value = IIf(IsDBNull(.Item("Precio")), "", .Item("Precio"))

                    End With
                Loop



                _ProcesarDatosGrilla()

                _TraerNombresProductos()

                _TraerViasSegunIdioma()

            Else
                txtNroProforma.Text = NroProforma
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtNroProforma_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroProforma.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

            txtNroProforma.Text = ceros(txtNroProforma.Text, 6)

            Try
                _TraerProforma(txtNroProforma.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Exit Sub
            End Try

            txtFechaAux.Visible = False
            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNroProforma.Text = ""
        End If

    End Sub

    Private Sub txtFechaLimite_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaLimite.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaLimite.Text.Replace("/", "")) = "" Then
                txtObservaciones.Focus()
                Exit Sub
            End If

            If Val(ordenaFecha(txtFecha.Text)) > Val(ordenaFecha(txtFechaLimite.Text)) Then

                MsgBox("La fecha límite debe ser posterior a la fecha de la Proforma.", MsgBoxStyle.Exclamation)

                txtFechaLimite.Focus()

                Exit Sub
            End If

            If _ValidarFecha(txtFechaLimite.Text) Then
                txtObservaciones.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaLimite.Text = ""
        End If

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If _ValidarFecha(txtFecha.Text) Then
                txtCliente.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Function _BuscarNombreProductoPorCliente(ByVal _CodProd, ByVal _Cliente)
        _CodProd = UCase(Trim(_CodProd))
        _Cliente = UCase(Trim(_Cliente))

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM Precios WHERE Clave = '" & _Cliente & _CodProd & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""
    End Function

    Private Sub _ConsultarProductos()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT t.Codigo, t.Linea, t.Descripcion, t.DescripcionIngles, p.Descripcion as DescripcionNoFarma FROM Terminado as t, Precios as p WHERE t.Codigo >= 'PT-00004-100' AND t.Codigo <= 'PT-99999-999' AND t.Codigo = p.Terminado AND p.Cliente = '" & txtCliente.Text & "' ORDER BY t.Codigo")
        Dim dr As SqlDataReader
        Dim WItem = "", WLinea = 0, WDescripcion = "", WDescripcionIng = ""

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                lstConsulta.Items.Clear()

                Do While dr.Read()
                    WItem = ""
                    WLinea = 0
                    WDescripcion = ""
                    WDescripcionIng = ""

                    With dr

                        WLinea = IIf(IsDBNull(.Item("Linea")), 0, Val(.Item("Linea")))

                        Select Case WLinea
                            Case 10, 20, 22, 24, 25, 26, 29, 30 ' Producto de Farma

                                WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", Trim(.Item("Descripcion")))
                                WDescripcionIng = IIf(IsDBNull(.Item("DescripcionIngles")), "", Trim(.Item("DescripcionIngles")))

                                If cmbIdioma.SelectedIndex = 2 Then
                                    If Trim(WDescripcionIng) <> "" Then
                                        WDescripcion = WDescripcionIng
                                    End If
                                End If

                            Case Else ' Productos NO Farma

                                WDescripcion = IIf(IsDBNull(.Item("DescripcionNoFarma")), "", Trim(.Item("DescripcionNoFarma")))
                                'WDescripcion = _BuscarNombreProductoPorCliente(.Item("Codigo"), txtCliente.Text)
                        End Select

                        WItem = .Item("Codigo") & SEPARADOR_CONSULTA & WDescripcion

                        lstConsulta.Items.Add(WItem)

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer listar los Productos disponibles para este Cliente desde la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _ConsultarClientes()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cliente, Razon FROM Cliente WHERE Razon <> '' ORDER BY Razon")
        Dim dr As SqlDataReader
        Dim WItem = ""

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                lstConsulta.Items.Clear()

                Do While dr.Read()
                    WItem = ""

                    With dr
                        WItem = .Item("Cliente") & SEPARADOR_CONSULTA & .Item("Razon")

                        lstConsulta.Items.Add(WItem)

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer listar los Clientes desde la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then

                txtCliente_MouseDoubleClick(Nothing, Nothing)
                Exit Sub
            End If

            Dim cliente = Nothing

            ' Buscamos todos los datos del cliente.
            Try
                cliente = _BuscarCliente(txtCliente.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Exit Sub
            End Try

            If Not IsNothing(cliente) Then
                ' Guardar y llenar los datos que se puedan extraer del registro de cliente.
                txtCliente.Text = cliente("Cliente")
                txtDescripcionCliente.Text = cliente("Razon")
                txtDireccionCliente.Text = cliente("Direccion")
                txtLocalidadCliente.Text = cliente("Localidad")

                txtPais.Focus()

                CargarDatosAdicionales()

            Else
                MsgBox("Cliente inexistente.", MsgBoxStyle.Information)
                txtCliente.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub CargarDatosAdicionales()
        'CARGAMOS LOS DATOS ADICIONALES DE LAS ETIQUETAS
        Try
            Dim SQlCnslt As String = "SELECT EnvasesI, EnvasesII, EnvasesIII, EtiquetaI, EtiquetaII, " _
                    & "Especif1, Especif2, Especif3, Especif4, Especif5 " _
                    & "FROM ClienteEspecif WHERE Cliente = '" & UCase(txtCliente.Text) & "'"
            Dim rowEspecif As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
            If rowEspecif IsNot Nothing Then
                With rowEspecif
                    txt_Envases.Text = OrDefault(.Item("EnvasesI"), "") & vbCrLf _
                                     & OrDefault(.Item("EnvasesII"), "") & vbCrLf _
                                     & OrDefault(.Item("EnvasesIII"), "")

                    txt_Etiquetas.Text = OrDefault(.Item("EtiquetaI"), "") & vbCrLf _
                                       & OrDefault(.Item("EtiquetaII"), "")

                    txt_Otras.Text = OrDefault(.Item("Especif1"), "") & vbCrLf _
                                   & OrDefault(.Item("Especif2"), "") & vbCrLf _
                                   & OrDefault(.Item("Especif3"), "") & vbCrLf _
                                   & OrDefault(.Item("Especif4"), "") & vbCrLf _
                                   & OrDefault(.Item("Especif5"), "")
                End With
            End If
        Catch ex As Exception

        End Try
     


    End Sub

    Private Function _BuscarCliente(ByVal Codigo As String) As DataRow
        Dim resultados As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm = "SELECT cliente, Razon, Direccion, Localidad FROM Cliente WHERE Cliente = '" & Codigo.Trim() & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _CS()
            cn.Open()

            dr.Fill(resultados)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al consultar los datos del Cliente en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If resultados.Rows.Count > 0 Then
            Return _NormalizarFila(resultados.Rows(0))
        Else
            Return Nothing
        End If

    End Function

    Private Sub txtDireccionCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccionCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDireccionCliente.Text) = "" Then : Exit Sub : End If

            txtLocalidadCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDireccionCliente.Text = ""
        End If

    End Sub

    Private Sub txtLocalidadCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidadCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLocalidadCliente.Text) = "" Then : Exit Sub : End If

            txtCondicionPago.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidadCliente.Text = ""
        End If

    End Sub

    Private Sub txtCondicionPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCondicionPago.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtCondicionPago.Text) <> "" Then
                txtCondicionPagoII.Focus()
                txtCondicionPagoII.SelectionStart = txtCondicionPagoII.Text.Length
            Else
                txtOCCliente.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCondicionPago.Text = ""
        End If

    End Sub

    Private Sub txtOCCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOCCliente.KeyDown, txtSaldoFactura.KeyDown, txtNroPedido.KeyDown, txtNroFactura.KeyDown

        If e.KeyData = Keys.Enter Then

            cmbCondicion.Focus()
            cmbCondicion.DroppedDown = True

        ElseIf e.KeyData = Keys.Escape Then
            txtOCCliente.Text = ""
        End If

    End Sub

    Private Sub cmbCondicion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCondicion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(cmbCondicion.SelectedItem) = "" Then : Exit Sub : End If

            cmbVia.Focus()
            cmbVia.DroppedDown = True

        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicion_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCondicion.DropDownClosed
        If cmbCondicion.SelectedIndex > 0 Then
            cmbVia.Focus()
            cmbVia.DroppedDown = True
        End If
    End Sub

    Private Function _BuscarTerminado(ByVal terminado As String) As DataRow
        Dim resultados As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm = "SELECT * FROM Terminado WHERE Codigo = '" & terminado.Trim() & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try

            cn.ConnectionString = _CS()
            cn.Open()

            dr.Fill(resultados)

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Exclamation)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If resultados.Rows.Count > 0 Then
            Return _NormalizarFila(resultados.Rows(0))
        Else
            Return Nothing
        End If

    End Function

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then
                txtFechaAux_DoubleClick(Nothing, Nothing)
                Exit Sub
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvProductos
                    .Rows(WRow).Cells(0).Value = txtFechaAux.Text

                    Dim terminado = _BuscarTerminado(txtFechaAux.Text)

                    If Not IsNothing(terminado) Then
                        .Rows(WRow).Cells(0).Value = terminado("Codigo")
                        .Rows(WRow).Cells(1).Value = _TraerNombreProducto(terminado("Codigo")) 'terminado("Descripcion")

                        .CurrentCell = .Rows(WRow).Cells(2)
                        .Focus()

                        txtFechaAux.Visible = False
                        txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                    Else
                        txtFechaAux.Focus()
                    End If
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvProductos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = .CurrentCell.Value

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    'Case 1
                    'If Not _EsNumeroOControl(keyData) Then
                    '    Return True
                    'End If
                    Case 1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If Val(valor) <> 0 Then

                        Select Case iCol
                            Case 2, 3
                                _RecalcularTotalFila(iRow)
                        End Select

                        _NormalizarNumerosGrilla()

                    End If

                    Select Case iCol
                        Case 3, 4
                            If iRow = PRODUCTOS_MAX - 1 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                Try
                                    .CurrentCell = .Rows(iRow + 1).Cells(0)
                                Catch ex As Exception
                                    .CurrentCell = .Rows(iRow).Cells(iCol)
                                End Try
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then


                    Select Case iCol
                        Case 0, 2, 3

                            .Rows(iRow).Cells(iCol).Value = ""

                            If iCol = 4 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                            Else
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            End If

                            .CurrentCell = .Rows(iRow).Cells(iCol)

                    End Select

                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub dgvProductos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellEnter
        With dgvProductos
            If e.ColumnIndex = 0 Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(0, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(0).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub

    Private Sub _RecalcularTotalFila(ByVal iRow As Integer)

        Dim WTotal = 0.0

        With dgvProductos.Rows(iRow)
            WTotal += Val(.Cells(2).Value)
            WTotal *= Val(.Cells(3).Value)

            .Cells(4).Value = formatonumerico(WTotal)
        End With

    End Sub

    Private Sub _NormalizarNumerosGrilla()
        Dim WTotal = 0.0

        For Each row As DataGridViewRow In dgvProductos.Rows
            With row
                .Cells(2).Value = IIf(Val(.Cells(2).Value) <> 0, formatonumerico(.Cells(2).Value), "")
                .Cells(3).Value = IIf(Val(.Cells(3).Value) <> 0, formatonumerico(.Cells(3).Value), "")
                WTotal += (Val(.Cells(2).Value) * Val(.Cells(3).Value))
            End With
        Next

        txtTotal.Text = formatonumerico(WTotal)
        _RecalcularTotal()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProforma.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubTotal.KeyPress, txtFlete.KeyPress, txtSeguro.KeyPress, txtTotal.KeyPress, txt_Otros.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcionTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionTotal.KeyDown, txtDescripcionTotalII.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcionTotal.Text) <> "" Then
                txtDescripcionTotalII.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcionTotal.Text = ""
        End If

    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtObservaciones.Text) <> "" Then
                txtObservacionesII.Focus()
                txtObservacionesII.SelectionStart = txtObservacionesII.Text.Length
            Else
                dgvProductos.CurrentCell = dgvProductos.Rows(0).Cells(0)
                dgvProductos.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        MenuPrincipal.btnLimpiarFiltros.PerformClick()
    End Sub

    Private Function _ExisteProforma(ByVal NroProforma As String) As Boolean
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()

            cm.Connection = cn
            cm.CommandText = "SELECT Proforma FROM ProformaExportacion WHERE Proforma = '" & txtNroProforma.Text & "'"

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Exclamation)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtNroProforma.Text) = "" Or Not _ExisteProforma(txtNroProforma.Text) Then

            txtNroProforma.Focus()
            Exit Sub

        End If

        If MsgBox("¿Esta seguro de que quiere eliminar la Preforma " & txtNroProforma.Text & " ?", MsgBoxStyle.YesNo, MsgBoxStyle.Exclamation) = DialogResult.Yes Then

            Dim cn As New SqlConnection()
            Dim cm As New SqlCommand()
            Dim trans As SqlTransaction = Nothing

            Try

                cn.ConnectionString = _CS()
                cn.Open()
                trans = cn.BeginTransaction

                cm.Connection = cn
                cm.CommandText = "DELETE FROM ProformaExportacion WHERE Proforma = '" & txtNroProforma.Text & "'"
                cm.Transaction = trans

                cm.ExecuteNonQuery()

                trans.Commit()

                btnLimpiar.PerformClick()

                txtNroProforma.Focus()

                MenuPrincipal.btnLimpiarFiltros.PerformClick()

            Catch ex As Exception

                If Not IsNothing(trans) Then
                    trans.Rollback()
                End If

                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Exclamation)

            Finally

                trans = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        'MsgBox("Aun no implementado. No hay todavia realizadas consultas.", MsgBoxStyle.Information)
        GrupoConsulta.Visible = True
    End Sub

    Private Function _ProformaExiste(ByVal nroproforma)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Proforma FROM ProformaExpo WHERE Proforma = '" & nroproforma & "'")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia de la proforma en la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub _ActualizaProforma(ByVal WSql)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As New SqlCommand(WSql)
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar la Proforma.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub


    Function _Left(ByVal texto, ByVal largo) As String
        Return Microsoft.VisualBasic.Left(Trim(texto), largo)
    End Function

    Private Function _TieneFDS(ByVal _CodProducto As String, ByVal _Descripcion As String) As Boolean

        Dim CarpetaFDS = "W:\impresion pdf\FDS\"
        Dim _RutaArchivo = ""
        Dim AuxiCod = "", AuxiDesc = ""

        _CodProducto = Trim(_CodProducto)
        _Descripcion = Trim(_Descripcion)

        If Trim(_CodProducto) = "" Then
            Throw New Exception("No se ha especificado el Código del Producto.")
        End If

        If Trim(_Descripcion) = "" Then
            Throw New Exception("No se ha especificado la Descripción del Producto.")
        End If

        AuxiCod = _CodProducto.Replace("PT", "").Replace("-", "")
        AuxiDesc = _Descripcion.Replace(" ", "").Replace("/", "")

        _RutaArchivo = CarpetaFDS & "FDS" & AuxiDesc & AuxiCod & ".pdf"

        If File.Exists(_RutaArchivo) Then

            Try
                File.Copy(_RutaArchivo, _CarpetaArchivosProforma(txtNroProforma.Text) & "FDS" & AuxiDesc & AuxiCod & ".pdf", True)
            Catch ex As Exception
                'Throw New Exception("No se pudo copiar FDS a Carpeta de Archivos de la Proforma: " & txtNroProforma.Text & vbCrLf & "Motivo: " & ex.Message)
                Return False
            End Try

            Return True
        End If

        Return False
    End Function


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        
        Dim cn As New SqlConnection()
        Dim trans As SqlTransaction = Nothing
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader
        Dim WClave, WRenglon, WEstado, XRenglon, WNroProforma, XNroProforma, WFecha, WFechaOrd, WCliente, WDireccion, WLocalidad, WCondPago, WOCCliente, WCondicion, WVia, WObservaciones, WSubTotal, WSeguro, WFlete, WTotal, WDescripcionMonto, WSql, WPais
        Dim WCondPagoII, WObservacionesII, WObservacionesIII, WDescripcionMontoII, WProformaCerrada, WPackingList, WEnviarDoc, WIdioma, WViaDesc, WEntregado, WEntregadoFecha, WEntregadoFechaOrd
        Dim WProd As String, WDescriProducto, WCant, WPrecio, WDesc, WSinFDS, WFechaLimite, WFechaLimiteOrd


        'If Me.Bloqueado Then

        '    MsgBox("No se puede modificar una Proforma que ya se encuentra Aprobada.", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        WProformaCerrada = "0"
        WPackingList = "0"
        WEnviarDoc = "0"
        WDescriProducto = ""
        WEntregado = ""
        WEntregadoFecha = ""
        WEntregadoFechaOrd = ""

        WClave = ""
        WRenglon = 0
        XRenglon = ""
        WNroProforma = _Left(txtNroProforma.Text, 6)
        XNroProforma = ceros(WNroProforma, 6)
        WFecha = txtFecha.Text
        WFechaOrd = ordenaFecha(WFecha)
        WCliente = _Left(txtCliente.Text, 6)
        WDireccion = _Left(txtDireccionCliente.Text, 100)
        WLocalidad = _Left(txtLocalidadCliente.Text, 50)
        WCondPago = _Left(txtCondicionPago.Text, 50)
        WOCCliente = _Left(txtOCCliente.Text, 20)
        WCondicion = Val(cmbCondicion.SelectedIndex)
        WVia = cmbVia.SelectedIndex.ToString()
        WObservaciones = _Left(txtObservaciones.Text, 100)
        WSubTotal = Val(formatonumerico(txtSubTotal.Text))
        WFlete = Val(formatonumerico(txtFlete.Text))
        WSeguro = Val(formatonumerico(txtSeguro.Text))
        WTotal = Val(formatonumerico(txtTotal.Text))
        WDescripcionMonto = UCase(_Left(txtDescripcionTotal.Text, 100))
        WPais = _Left(txtPais.Text, 15)

        WCondPagoII = _Left(Trim(txtCondicionPagoII.Text), 50)
        WObservacionesII = _Left(Trim(txtObservacionesII.Text), 100)
        WObservacionesIII = _Left(Trim(txtObservacionesIII.Text), 100)
        WDescripcionMontoII = _Left(Trim(txtDescripcionTotalII.Text), 100)

        WEstado = Trim(Str$(cmbEstado.SelectedIndex))
        WIdioma = Trim(Str$(cmbIdioma.SelectedIndex))

        WFechaLimite = txtFechaLimite.Text
        WFechaLimiteOrd = ordenaFecha(WFechaLimite)

        If ckCerrado.Checked Then
            WProformaCerrada = "1"
        End If

        If ckEnviarDocumentacion.Checked Then
            WEnviarDoc = "1"
        End If

        If ckPakingList.Checked Then
            WPackingList = "1"
        End If

        WSql = ""

        WProd = ""
        WDesc = ""
        WCant = 0.0
        WPrecio = 0.0

        WSinFDS = ""

        Dim WOtros As Double = Val(txt_Otros.Text)
        Dim WMotivoOtros As String = UCase(txt_MotivoOtros.Text)


        ' Validamos los datos minimos que se necesitan por lo menos para poder generar una proforma.
        If WCliente = "" Or Trim(WFecha).Length < 10 Then
            Exit Sub
        End If

        If WIdioma = "" Then
            MsgBox("No se ha informado un idioma para la Proforma.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If WVia = "" Then
            MsgBox("No se ha indicado la Vía de Transporte.", MsgBoxStyle.Information)
            Exit Sub
        End If

        WViaDesc = UCase(_Left(cmbVia.SelectedItem, 20))

        ' Validar fecha limite como obligatoria?
        'If WFechaLimiteOrd = 0 Then
        '    MsgBox("La fecha límite, debe ser una fecha válida.", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If

        ' Valido que la fecha limite, en caso de existir, sea posterior a la fecha de la Proforma.
        If WFechaLimite.ToString.Replace(" ", "").Length = 10 Then
            If Val(WFechaOrd) >= Val(WFechaLimiteOrd) Then
                MsgBox("La fecha límite debe ser posterior a la fecha de creación de la Proforma.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        'WViaDesc = UCase(Trim(cmbVia.SelectedText))

        'Try
        cn.ConnectionString = _CS() ' TRUE: Para testing en local.

        cn.Open()
        trans = cn.BeginTransaction

        cm.Connection = cn

        WSql = "SELECT ISNULL(Entregado, '') as Entregado, ISNULL(FechaEntregado, '') as EntregadoFecha, ISNULL(FechaEntregadoOrd, '') as EntregadoFechaOrd FROM ProformaExportacion WHERE Proforma = '" & XNroProforma & "'"

        cm.Transaction = trans
        cm.CommandText = WSql

        dr = cm.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            WEntregado = dr.Item("Entregado")
            WEntregadoFecha = dr.Item("EntregadoFecha")
            WEntregadoFechaOrd = dr.Item("EntregadoFechaOrd")
        End If

        If Not dr.IsClosed Then dr.Close()

        WSql = "DELETE ProformaExportacion WHERE Proforma = '" & XNroProforma & "'"

        cm.CommandText = WSql

        cm.ExecuteNonQuery()

        For Each row As DataGridViewRow In dgvProductos.Rows
            With row
                WProd = Trim(.Cells(0).Value)
                WDesc = Trim(.Cells(1).Value)
                WDesc = _Left(WDesc, 100)
                WCant = Val(.Cells(2).Value)
                WPrecio = Val(.Cells(3).Value)

                If WProd.Replace("-", "") <> "" Then

                    If WCant > 0 And WPrecio > 0 Then
                        WRenglon += 1

                        XRenglon = ceros(WRenglon, 2)

                        WClave = XNroProforma & XRenglon

                        WSql = "INSERT INTO ProformaExportacion (Clave, Proforma, Renglon, Fecha, FechaOrd, Estado, Cliente, Direccion, Localidad, CondPago, CondPagoII, OCCliente, Condicion, Via, ViaDesc, Observaciones, ObservacionesII, ObservacionesIII, Producto, DescriProducto, Cantidad, Precio, SubTotal, Flete, Seguro, Total, DescriTotal, DescriTotalII, Pais, Cerrada, PackingList, EnviarDocumentacion, Idioma, FechaLimite, FechaLimiteOrd, MotivoOtros, Otros)" _
                             & " VALUES " _
                             & " ('" & WClave & "', '" & XNroProforma & "', '" & XRenglon & "', '" & WFecha & "', '" & WFechaOrd & "', '" & WEstado & "', '" & WCliente & "', '" & WDireccion & "', '" & WLocalidad & "', '" & WCondPago & "', '" & WCondPagoII & "', '" & WOCCliente & "', '" & WCondicion & "', '" & WVia & "', '" & WViaDesc & "', " _
                             & "'" & WObservaciones & "', '" & WObservacionesII & "', '" & WObservacionesIII & "', '" & WProd & "', '" & WDesc & "', " & formatonumerico(WCant) & ", " & formatonumerico(WPrecio) & ", " & formatonumerico(WSubTotal) & ", " & formatonumerico(WFlete) & ", " & formatonumerico(WSeguro) & ", " _
                             & formatonumerico(WTotal) & ", '" & WDescripcionMonto & "', '" & WDescripcionMontoII & "', '" & WPais & "', '" & WProformaCerrada & "', '" & WPackingList & "', '" & WEnviarDoc & "', '" & WIdioma & "', '" & WFechaLimite & "', '" & WFechaLimiteOrd & "', '" & WMotivoOtros & "', '" & WOtros & "')"

                        cm.CommandText = WSql

                        cm.ExecuteNonQuery()

                        cm.CommandText = "UPDATE ProformaExportacion SET Entregado = '" & WEntregado & "', FechaEntregado = '" & WEntregadoFecha & "', FechaEntregadoOrd = '" & WEntregadoFechaOrd & "' WHERE Proforma = '" & XNroProforma & "'"
                        cm.ExecuteNonQuery()

                        If Not _TieneFDS(WProd, WDesc) Then
                            WSinFDS &= WProd & " (" & WDesc & ") " & vbCrLf
                        End If

                    End If

                End If

            End With
        Next

        ' Si no hubo nigun error durante la carga de datos, confirmo los cambios.
        trans.Commit()

        If Trim(WSinFDS) <> "" Then
            MsgBox("Los siguientes Productos, no poseen FDS: " & vbCrLf & WSinFDS, MsgBoxStyle.Information)
        End If


        'ANDRES

        If NROPEDIDOPRO <> "" Then
            Dim SQLCnslt As String = "SELECT NroProforma FROM PedidoProformaExportacion WHERE NroProforma = '' AND NroPedido = '" & NROPEDIDOPRO & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If Row IsNot Nothing Then
                SQLCnslt = "UPDATE PedidoProformaExportacion SET NroProforma = '" & txtNroProforma.Text & "' WHERE NroProforma = '' AND NroPedido = '" & NROPEDIDOPRO & "'"
                ExecuteNonQueries("SurfactanSa", SQLCnslt)
            End If
        End If

        'ANDRES

        txtNroProforma.Text = WNroProforma
        MOSTRAR_MSG_IDIOMAS = False
        txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        txtNroProforma.Focus()

        'Catch ex As Exception
        '    If Not IsNothing(trans) Then
        '        ' En caso de una Excepcion, vuelvo para atras los cambios.
        '        If Not IsNothing(dr) Then
        '            If Not dr.IsClosed Then
        '                dr.Close()
        '            End If
        '        End If
        '        trans.Rollback()
        '        trans = Nothing
        '    End If
        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End Try

        MsgBox("La Proforma " & XNroProforma & ", ha sido grabada con exito.", MsgBoxStyle.Information)

        ' Consultar si se quiere enviar una notificación a ventas sobre el cambio de estado de la Proforma.

        If Val(WEstado) = 1 Then

            Try

                ' GUARDAMOS/ACTUALIZAMOS EL PDF DE LA PROFORMA.
                _ActualizarPDFProforma(XNroProforma)

            Catch ex As Exception

                MsgBox("No se ha podido actualizar el archivo PDF relacionado a esta Proforma." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)

            End Try

            If MsgBox("¿Desea notificar a Ventas sobre la aprobación de la actual Proforma?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                _NotificarAVentas(XNroProforma)
            End If


        End If

        
        btnVistaPrevia.PerformClick()

        'btnLimpiar.PerformClick()
        btnCerrar.PerformClick()

        MenuPrincipal.btnLimpiarFiltros.PerformClick()

    End Sub

    Private Sub _ActualizarPDFProforma(ByVal WNroProforma As String)

        If Val(WNroProforma) <= 0 Then : Exit Sub : End If

        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & WNroProforma

        With VistaPrevia
            .Reporte = New ProformaVistaPrevia
            '.Reporte.DataSourceConnections(0).SetLogonProperties()
            .Formula = "{ProformaExportacion.Proforma} = '" & WNroProforma & "'"

            Try

                If Not Directory.Exists(WRutaArchivosRelacionados) Then
                    Directory.CreateDirectory(WRutaArchivosRelacionados)
                End If

                .GuardarPDF("Proforma" & WNroProforma, WRutaArchivosRelacionados)
            Catch ex As Exception
                Throw New Exception(ex.Message)
                'Exit Sub
            End Try

        End With

    End Sub

    Private Sub _NotificarAVentas(ByVal NroProforma)
        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem
        Dim WArchivoProforma = ""

        Try
            oApp = New Outlook.Application()


            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = "Notificación de Aprobación de Proforma (Nº: " & NroProforma & ")"
            oMsg.Body = "Se encuentra APROBADA la Proforma Nº: " & NroProforma

            If NroProforma.ToString.Length < 6 Then : ceros(NroProforma, 6) : End If

            WArchivoProforma = _CarpetaArchivosProforma(NroProforma) & "Proforma" & NroProforma & ".pdf"

            If Not File.Exists(WArchivoProforma) Then
                _ActualizarPDFProforma(NroProforma)
            End If

            oMsg.Attachments.Add(WArchivoProforma)

            ' Modificar por los E-Mails que correspondan.
            'oMsg.To = "gferreyra@surfactan.com.ar"
            oMsg.To = "nsoto@surfactan.com.ar"

            oMsg.Display()

            oMsg.Send()
        Catch ex As Exception
            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        ' Reseteamos los campos de Texto.
        For Each txt As TextBox In {txtNroProforma, txtCliente, txtDescripcionCliente, txtDireccionCliente, txtLocalidadCliente, _
                                    txtCondicionPago, txtCondicionPagoII, txtOCCliente, txtObservaciones, txtObservacionesII, txtObservacionesIII, _
                                    txtDescripcionTotal, txtDescripcionTotalII, txtSubTotal, txtSeguro, txtFlete, txtTotal, txtPais, txtNroPedido, _
                                    txtNroFactura, txtSaldoFactura}
            txt.Text = ""

        Next

        ' Reseteamos los Combobox
        For Each cmb As ComboBox In {cmbVia, cmbCondicion, cmbEstado, cmbIdioma}
            cmb.SelectedIndex = 0
        Next

        ' Reseteamos los Checks
        For Each ck As CheckBox In {ckCerrado, ckEnviarDocumentacion, ckPakingList}
            ck.Checked = False
        Next

        ' Asignamos valores por defecto.
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        ckEnviarDocumentacion.Checked = False
        cmbIdioma.SelectedIndex = 1 ' Español por defecto.

        txtFecha.Clear()
        txtFechaLimite.Clear()

        _LimpiarGrilla()

        txtNroProforma.Focus()

        GrupoConsulta.Visible = False

        gbEntregado.Visible=False

        txtFechaAux.Visible = False

        Me.Bloqueado = False

        WRow = -1
        Wcol = -1

        ' Cargamos automaticamente el próximo número de Proforma.
        _TraerProximoNroProforma()

        _TraerViasSegunIdioma()

        NROPEDIDOPRO = ""

    End Sub

    Private Sub _ActualizarNombresProductos()

        If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            Dim WNroProforma As String = ceros(txtNroProforma.Text, 6)

            For Each row As DataGridViewRow In dgvProductos.Rows
                With row

                    If .Cells("Producto").Value <> "" Then

                        cm.CommandText = "UPDATE ProformaExportacion SET DescriProducto = '" & _Left(.Cells("Descripcion").Value, 100) & "' WHERE Proforma = '" & WNroProforma & "' AND Producto = '" & Trim(.Cells("Producto").Value) & "'"

                        cm.ExecuteNonQuery()

                    End If

                End With
            Next

            trans.Commit()

        Catch ex As Exception

            If Not IsNothing(trans) Then
                trans.Rollback()
            End If

            Throw New Exception(ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVistaPrevia.Click
        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text

        Try
            _TraerNombresProductos()
        Catch ex As Exception

        End Try

        Try

            _ActualizarNombresProductos()

        Catch ex As Exception
            _MsgBoxConMotivo(ex, "Hubo un problema al querer traer los datos de los Productos de la Proforma para mostrar la Vista Previa.")
            Exit Sub
        End Try

        With VistaPrevia
            .Reporte = New ProformaVistaPrevia
            '.Reporte.DataSourceConnections(0).SetLogonProperties()
            .Formula = "{ProformaExportacion.Proforma} = '" & txtNroProforma.Text & "'"

            Try

                If Not Directory.Exists(WRutaArchivosRelacionados) Then
                    Directory.CreateDirectory(WRutaArchivosRelacionados)
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message)
                'Exit Sub
            End Try

            .GuardarPDF("Proforma" & txtNroProforma.Text, WRutaArchivosRelacionados)

            .Mostrar()
        End With
    End Sub

    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub txtObservacionesII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionesII.KeyDown
        If e.KeyData = Keys.Enter Then

            txtObservacionesIII.Focus()
            txtObservacionesIII.SelectionStart = txtObservacionesIII.Text.Length

        ElseIf e.KeyData = Keys.Escape Then
            txtObservacionesII.Text = ""
        End If
    End Sub

    Private Sub txtObservacionesIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionesIII.KeyDown
        If e.KeyData = Keys.Enter Then

            dgvProductos.CurrentCell = dgvProductos.Rows(0).Cells(0)
            dgvProductos.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtObservacionesIII.Text = ""
        End If
    End Sub

    Private Sub txtCondicionPagoII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCondicionPagoII.KeyDown
        If e.KeyData = Keys.Enter Then

            txtOCCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCondicionPagoII.Text = ""
        End If
    End Sub

    Private Sub lstOpcionesConsulta_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstOpcionesConsulta.MouseClick

        If Trim(lstOpcionesConsulta.SelectedItem) = "" Then : Exit Sub : End If

        Select Case lstOpcionesConsulta.SelectedIndex
            Case 0
                _ConsultarClientes()
            Case 1
                _ConsultarProductos()
            Case Else
                Exit Sub
        End Select

        'lstConsulta.Visible = True
        With txtAyuda
            .Visible = True
            .Text = ""
            .Focus()
        End With

        lstOpcionesConsulta.Visible = False
    End Sub

    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
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
            origen.Visible = False

        Else

            final.Visible = False
            origen.Visible = True

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        If IsNothing(filtrado.SelectedItem) Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_MouseClick(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub txtAyuda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAyuda.KeyDown

        If e.KeyData = Keys.Escape Then
            txtAyuda.Text = ""
        End If

    End Sub

    Private Function _ProductoYaAgregado(ByVal codigo)

        For i = 0 To PRODUCTOS_MAX - 1

            With dgvProductos.Rows(i)
                If Trim(.Cells(0).Value) = codigo Then
                    Return True
                    Exit For
                End If
            End With

        Next

        Return False
    End Function

    Private Sub lstConsulta_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstConsulta.MouseClick
        Dim WDatos()
        Dim WRowIndex = -1

        If Trim(lstConsulta.SelectedItem) = "" Then : Exit Sub : End If

        WDatos = Trim(lstConsulta.SelectedItem).Replace(SEPARADOR_CONSULTA, "#").Split("#")


        Select Case lstOpcionesConsulta.SelectedIndex
            Case 0

                txtCliente.Text = Trim(WDatos(0))

                txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            Case 1

                If _ProductoYaAgregado(WDatos(0)) Then

                    MsgBox("El producto ya se encuentra agregado a la lista.", MsgBoxStyle.Information)
                    Exit Sub

                End If

                For i = 0 To PRODUCTOS_MAX - 1

                    With dgvProductos.Rows(i)
                        If Trim(.Cells(0).Value).Replace("-", "") = "" Then
                            WRowIndex = i
                            Exit For
                        End If
                    End With

                Next

                If WRowIndex < 0 Then
                    MsgBox("No se pueden seguir agregando productos. Se ha alcanzado el número máximo permitido por Proforma.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                With dgvProductos
                    .Rows(WRowIndex).Cells(0).Value = Trim(WDatos(0))
                    .Rows(WRowIndex).Cells(1).Value = Trim(WDatos(1))
                End With

                Try
                    _TraerNombresProductos()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                    Exit Sub
                End Try

                With dgvProductos
                    .CurrentCell = .Rows(WRowIndex).Cells(2)
                    .Focus()
                End With

                GrupoConsulta.Visible = False
                If txtFechaAux.Visible Then : txtFechaAux.Visible = False : End If
                'txtFechaAux_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

                Exit Sub

            Case Else



        End Select


        btnCerrarConsulta.PerformClick()

    End Sub

    Private Sub btnCerrarConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        lstFiltrada.Visible = False
        txtAyuda.Visible = False
        lstOpcionesConsulta.Visible = True
        GrupoConsulta.Visible = False

        If txtFechaAux.Visible Then : txtFechaAux.Focus() : End If
    End Sub

    Private Sub txtPais_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPais.KeyDown

        If e.KeyData = Keys.Enter Then

            txtPais.Text = UCase(txtPais.Text)

            cmbIdioma.Focus()
            cmbIdioma.DroppedDown = True

        ElseIf e.KeyData = Keys.Escape Then
            txtPais.Text = ""
        End If

    End Sub

    Private Sub txtCliente_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCliente.MouseDoubleClick

        lstOpcionesConsulta.SelectedIndex = 0

        btnConsulta.PerformClick()

        lstOpcionesConsulta_MouseClick(Nothing, Nothing)

    End Sub

    Private Sub btnHistorialArchivosRelacionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorialArchivosRelacionados.Click

        If Trim(txtNroProforma.Text) <> "" Then

            With HistorialProforma

                .NroProforma = txtNroProforma.Text

                .Show()

            End With

        End If

    End Sub

    Private Sub txtSubTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubTotal.KeyDown

        If e.KeyData = Keys.Enter Then
            txtFlete.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtSubTotal.Text = ""
        End If

    End Sub



    Private Sub _RecalcularTotal()
        txtSubTotal.Text = formatonumerico(txtSubTotal.Text)
        txtFlete.Text = formatonumerico(txtFlete.Text)
        txtSeguro.Text = formatonumerico(txtSeguro.Text)
        txtTotal.Text = formatonumerico(txtTotal.Text)
        txt_Otros.Text = formatonumerico(txt_Otros.Text)

        txtSubTotal.Text = Val(txtTotal.Text) - Val(txtFlete.Text) - Val(txtSeguro.Text) - Val(txt_Otros.Text)

        txtSubTotal.Text = formatonumerico(txtSubTotal.Text)
    End Sub

    Private Sub txtFlete_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFlete.KeyDown

        If e.KeyData = Keys.Enter Then

            txtSeguro.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFlete.Text = ""
        End If

    End Sub

    Private Sub txtSeguro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSeguro.KeyDown
        If e.KeyData = Keys.Enter Then

            txt_MotivoOtros.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtSeguro.Text = ""
        End If
        

    End Sub

    Private Sub RecalcularTotal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeguro.Leave, txtFlete.Leave, txt_Otros.Leave
        _RecalcularTotal()
    End Sub

    Private Sub cmbIdioma_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdioma.DropDownClosed
        If cmbIdioma.SelectedIndex > -1 Then
            txtCondicionPago.Focus()
        End If
    End Sub

    Private Sub cmbIdioma_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdioma.KeyDown
        If e.KeyData = Keys.Enter Then

            txtCondicionPago.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbIdioma.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbEstado_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.DropDownClosed
        If cmbEstado.SelectedIndex > -1 Then
            txtFechaLimite.Focus()
        End If
    End Sub

    Private Sub cmbEstado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEstado.KeyDown
        If e.KeyData = Keys.Enter Then

            txtFechaLimite.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbEstado.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbVia_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVia.DropDownClosed
        If cmbVia.SelectedIndex > 0 Then
            cmbEstado.Focus()
            cmbEstado.DroppedDown = True
        End If
    End Sub

    Private Sub cmbVia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbVia.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(cmbVia.SelectedIndex) = 0 Then : Exit Sub : End If

            cmbEstado.Focus()
            cmbEstado.DroppedDown = True

        ElseIf e.KeyData = Keys.Escape Then
            cmbVia.SelectedIndex = 0
        End If

    End Sub

    Private Sub dgvProductos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductos.RowHeaderMouseDoubleClick
        If MsgBox("¿Seguro de que quiere eliminar el renglón correspondiente a este Producto?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        With dgvProductos.Rows(e.RowIndex)

            txtFechaAux.Clear()

            For i = 0 To .Cells.Count - 1

                .Cells(i).Value = ""

            Next

        End With

        dgvProductos.ClearSelection()
    End Sub

    Private Sub txtFechaAux_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaAux.DoubleClick
        If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then
            ' Abrimos la Consulta de Productos que el Cliente Puede Comprar.
            
            btnConsulta.PerformClick()
            lstOpcionesConsulta.SelectedIndex = 1
            lstOpcionesConsulta_MouseClick(Nothing, Nothing)

        End If
    End Sub

    Private Function _TraerNombreProducto(ByVal _Codigo As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT t.Linea, t.Descripcion, t.DescripcionIngles, p.Descripcion as DescripcionNoFarma FROM Terminado as t, Precios as p WHERE t.Codigo = '" & Trim(_Codigo) & "' AND t.Codigo = p.Terminado AND p.Cliente = '" & txtCliente.Text & "' ORDER BY t.Codigo")
        Dim dr As SqlDataReader
        Dim WLinea = 0, WDescripcion = "", WDescripcionIng = ""

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                lstConsulta.Items.Clear()

                dr.Read()
                'WItem = ""
                WLinea = 0
                WDescripcion = ""

                With dr

                    WLinea = IIf(IsDBNull(.Item("Linea")), 0, Val(.Item("Linea")))

                    Select Case WLinea
                        Case 10, 20, 22, 24, 25, 26, 27, 29, 30 ' Producto de Farma

                            WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", Trim(.Item("Descripcion")))
                            WDescripcionIng = IIf(IsDBNull(.Item("DescripcionIngles")), "", Trim(.Item("DescripcionIngles")))

                            If cmbIdioma.SelectedIndex = 2 Then
                                If Trim(WDescripcionIng) = "" Then
                                    'Throw New Exception("El Código " & _Codigo & ", no posee descripción en Inglés.")

                                    If MOSTRAR_MSG_IDIOMAS Then
                                        MsgBox("El Código " & _Codigo & ", no posee descripción en Inglés.", MsgBoxStyle.Exclamation)
                                    End If

                                    Return WDescripcion
                                End If

                                Return WDescripcionIng
                            Else
                                Return WDescripcion
                            End If

                        Case Else ' Productos NO Farma

                            WDescripcion = IIf(IsDBNull(.Item("DescripcionNoFarma")), "", Trim(.Item("DescripcionNoFarma")))

                            Return WDescripcion
                            'WDescripcion = _BuscarNombreProductoPorCliente(.Item("Codigo"), txtCliente.Text)
                    End Select

                    '   WItem = .Item("Codigo") & SEPARADOR_CONSULTA & WDescripcion

                    'lstConsulta.Items.Add(WItem)

                End With

                'Loop

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDescripcion
    End Function

    Private Sub _TraerNombresProductos()
        For Each row As DataGridViewRow In dgvProductos.Rows
            With row
                If Trim(.Cells(0).Value) <> "" Then
                    Try
                        .Cells(1).Value = _TraerNombreProducto(.Cells(0).Value)
                    Catch ex As Exception
                        Throw New Exception("No se ha podido recuperar las descripciones de todos los productos." & vbCrLf & "Motivo: " & vbCrLf & ex.Message)
                        Exit Sub
                    End Try
                End If
            End With
        Next

        MOSTRAR_MSG_IDIOMAS = True
    End Sub

    Private Sub _TraerViasSegunIdioma()
        Dim _index = cmbVia.SelectedIndex

        Select Case cmbIdioma.SelectedIndex
            Case 1
                cmbVia.DataSource = VIAS_ESP
            Case 2
                cmbVia.DataSource = VIAS_ING
            Case Else

        End Select

        cmbVia.SelectedIndex = _index
    End Sub

    Private Sub cmbIdioma_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdioma.Leave
        Try
            _TraerNombresProductos()

            _TraerViasSegunIdioma()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub btnEntregado_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnEntregado.Click
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        Try
            If MsgBox("¿Está seguro de querer marcar como Entregada a la Proforma? Esta acción hará que la misma ya no se encuentre listada por defecto en el Listado Principal del Sistema de Exportación.", vbYesNo) = MsgBoxResult.No Then Exit Sub

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            Dim WFechaEntrega = Date.Now.ToString("dd/MM/yyyy")
            Dim WFechaEntregaOrd = ordenaFecha(WFechaEntrega)

            cm.CommandText = "UPDATE ProformaExportacion SET Entregado = 'X', FechaEntregado = '" & WFechaEntrega & "', FechaEntregadoOrd = '" & WFechaEntregaOrd & "' WHERE Proforma = '" & txtNroProforma.Text & "'"

            cm.ExecuteNonQuery()

            btnCerrar.PerformClick()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        
    End Sub

    
    Private Sub btn_TraerDatos_Click(sender As Object, e As EventArgs) Handles btn_TraerDatos.Click
        With New ConsultaPedidosDeProforma
            .Show(Me)
        End With
    End Sub

    Public Sub PasarNroPedido(NroPedido As String) Implements IConsultaPedPrepo.PasarNroPedido
        Dim SQLCnslt As String = "SELECT p.*, c.Razon  FROM PedidoProformaExportacion p INNER JOIN Cliente c ON p.Cliente = c.Cliente " _
                                     & "WHERE NroPedido = '" & NroPedido & "' ORDER BY Renglon"
        Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If Tabla.Rows.Count > 0 Then
            Dim Posicion As Integer = 0
            For Each row As DataRow In Tabla.Rows
                With row
                    If Posicion = 0 Then
                        NROPEDIDOPRO = Trim(.Item("NroPedido"))
                        txtFecha.Text = .Item("Fecha")
                        txtCliente.Text = .Item("Cliente")
                        txtDescripcionCliente.Text = .Item("Razon")
                        txtCondicionPago.Text = .Item("CondPago")
                        txtOCCliente.Text = .Item("OCCliente")
                        cmbCondicion.SelectedIndex = .Item("Condicion")
                        cmbIdioma.SelectedIndex = .Item("idioma")
                        cmbVia.SelectedIndex = .Item("Via")
                        txtDireccionCliente.Text = .Item("Direccion")
                        txtLocalidadCliente.Text = .Item("Localidad")
                        txtPais.Text = .Item("Pais")
                        txtObservaciones.Text = .Item("Observaciones")
                        txtObservacionesII.Text = .Item("ObservacionesII")
                        txtObservacionesIII.Text = .Item("ObservacionesIII")
                        txt_Contacto.Text = .Item("Contacto")
                        txt_MailContacto.Text = .Item("MailContacto")
                        txtSubTotal.Text = formatonumerico(.Item("Total"))
                    End If
                    Dim Saldo As Double = .Item("Cantidad") * .Item("Precio")
                    dgvProductos.Rows(Posicion).Cells(0).Value = .Item("Producto")
                    dgvProductos.Rows(Posicion).Cells(1).Value = .Item("DescriProducto")
                    dgvProductos.Rows(Posicion).Cells(2).Value = .Item("Cantidad")
                    dgvProductos.Rows(Posicion).Cells(3).Value = .Item("Precio")
                    dgvProductos.Rows(Posicion).Cells(4).Value = formatonumerico(Saldo)
                    Posicion += 1
                End With

            Next


        End If
        CargarDatosAdicionales()
        _NormalizarNumerosGrilla()
    End Sub

    

    Private Sub btn_GenerarBotaEmpaque_Click(sender As Object, e As EventArgs) Handles btn_GenerarNotaEmpaque.Click

        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text & "\" & "Packing List\"

        'ELIMINO CUALQUIERA DE LOS DOS QUE ESTUVIERA GENERADO PARA QUE SOLO QUEDE UNO
        Dim WRutaArchivosRelacionadosI = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text & "\" & "Packing List" & "\" & "Nota de Empaque.pdf"
        Dim WRutaArchivosRelacionadosII = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text & "\" & "Packing List" & "\" & "Nota de Empaque Ingles.pdf"

        System.IO.File.Delete(WRutaArchivosRelacionadosI)
        System.IO.File.Delete(WRutaArchivosRelacionadosII)

        Select Case cmbIdioma.SelectedIndex

            Case 0, 1
                With New Util.VistaPrevia
                    .Base = "SurfactanSa"
                    .Reporte = New NotaEmpaque
                    .Formula = "{ArmadoPallets.Proforma} = '" & txtNroProforma.Text & "' AND {ArmadoPallets.Proforma} = {ProformaExportacion.Proforma} AND {ProformaExportacion.Renglon} = '01'"
                    '.Mostrar()
                    '.Exportar("Nota de Empaque", ExportFormatType.PortableDocFormat, WRutaArchivosRelacionados)
                    .GuardarPDF("Nota de Empaque", WRutaArchivosRelacionados)
                End With
            Case 2

                With New Util.VistaPrevia
                    .Base = "SurfactanSa"
                    .Reporte = New NotaEmpaqueIngles
                    .Formula = "{ArmadoPallets.Proforma} = '" & txtNroProforma.Text & "' AND {ArmadoPallets.Proforma} = {ProformaExportacion.Proforma} AND {ProformaExportacion.Renglon} = '01'"
                    '.Mostrar()
                    '.Exportar("Nota de Empaque Ingles", ExportFormatType.PortableDocFormat, WRutaArchivosRelacionados)
                    .GuardarPDF("Nota de Empaque Ingles", WRutaArchivosRelacionados)
                End With

        End Select


        GenerarRegistroEnHistorial()

        MsgBox("Se genero la nota de empaque en la carpeta de Packing List")
    End Sub

    Private Sub GenerarRegistroEnHistorial()

        Try
            Dim WNro_Observacion As String = _ProximoNroObservacion()
            Dim WRenglon As String = "01"
            Dim WClave As String = WNro_Observacion.PadRight(6, "0") & WRenglon
            Dim WProforma As String = Trim(txtNroProforma.Text)
            Dim WObservaciones As String = "Se actualizo la Nota de Envases por " & Trim(Operador.Descripcion)
            Dim WUsuario As String = Operador.Descripcion
            Dim WFecha As String = Date.Today.ToString("dd/MM/yyyy")
            Dim WFechaOrd As String = ordenaFecha(WFecha)

            Dim SQLCnslt As String = ""

            SQLCnslt = "INSERT INTO ProformaExportacionHistorial (Clave, NroObservacion, Renglon, Proforma, Usuario, Fecha, FechaOrd, Observaciones) " _
                                  & "VALUES ('" & WClave & "'," & WNro_Observacion & ",'" & WRenglon & "','" & WProforma & "','" & WUsuario & "','" & WFecha & "','" & WFechaOrd & "','" & WObservaciones & "')"
         
            ExecuteNonQueries("SurfactanSa", SQLCnslt)

        Catch ex As Exception
            MsgBox("Hubo un error al generar el registro de historial para la proforma " & Trim(txtNroProforma.Text) & "")
        End Try

    End Sub

    Private Function _ProximoNroObservacion()

        Dim actual = 0
        Dim SQLCnslt As String = "SELECT TOP 1 NroObservacion as NroActual FROM ProformaExportacionHistorial ORDER BY NroObservacion DESC"
        Try
            Dim RowObservacion As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowObservacion IsNot Nothing Then
                actual = RowObservacion.Item("NroActual")

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el próximo número de Observación de la Base de Datos.")

        End Try

        Return actual + 1

    End Function

    Private Sub txt_Otros_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Otros.KeyDown

        If e.KeyData = Keys.Enter Then
            txtTotal.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txt_Otros.Text = ""
        End If
    End Sub

    Private Sub txt_MotivoOtros_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MotivoOtros.KeyDown
        If e.KeyData = Keys.Enter Then

            txt_Otros.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txt_MotivoOtros.Text = ""
        End If

    End Sub
End Class