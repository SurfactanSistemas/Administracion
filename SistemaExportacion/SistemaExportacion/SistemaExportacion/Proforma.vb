Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Proforma

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 6
    Private Const SEPARADOR_CONSULTA = "____"

    Private Sub Proforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        btnLimpiar.PerformClick()

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

        txtNroProforma.Text = Helper.ceros(ultimo + 1, 6)
    End Sub

    Private Sub Proforma_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtNroProforma.Focus()
    End Sub

    Private Function _CS(Optional ByVal empresa As String = "SurfactanSA")
        Return Helper._ConectarA()
        'Return Helper._ConectarA(empresa)
    End Function

    Private Sub _TraerDescripcionCliente()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Razon FROM Cliente WHERE CLiente = '" & txtCliente.Text & "'")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                txtDescripcionCliente.Text = dr.Item("Razon")
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

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
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
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
                    .Cells(2).Value = Helper.formatonumerico(.Cells(2).Value)
                    .Cells(3).Value = Helper.formatonumerico(.Cells(3).Value)

                    .Cells(4).Value = Helper.formatonumerico((Val(.Cells(2).Value) * Val(.Cells(3).Value)))

                Else
                    Exit For
                End If

            End With
        Next
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
        Dim cm As SqlCommand = New SqlCommand("SELECT p.Renglon, p.Proforma, p.Fecha, p.Cliente, c.Razon, p.Direccion, p.Localidad, p.CondPago, p.OCCliente, p.Condicion, p.Via, p.Observaciones, p.Total, p.DescriTotal, p.Pais, p.CondPagoII, p.ViaII, p.ObservacionesII, p.ObservacionesIII, p.DescriTotalII, p.Producto, p.Cantidad, p.Precio FROM ProformaExportacion as p, Cliente as c WHERE Proforma = '" & NroProforma & "' AND p.Cliente = c.Cliente ORDER BY Renglon")
        Dim dr As SqlDataReader
        Dim WClave, WRenglon, WNroProforma, WFecha, WFechaOrd, WCliente, WDescripcionCliente, WDireccion, WLocalidad, WCondPago, WOCCliente, WCondicion, WVia, WObservaciones, WTotal, WDescripcionMonto, WPais, WCondPagoII, WViaII, WObservacionesII, WObservacionesIII, WDescripcionMontoII, WRowIndex

        WClave = ""
        WRenglon = 0
        WNroProforma = ""
        WFecha = ""
        WFechaOrd = ""
        WCliente = ""
        WDescripcionCliente = ""
        WDireccion = ""
        WLocalidad = ""
        WCondPago = ""
        WOCCliente = ""
        WCondicion = ""
        WVia = ""
        WObservaciones = ""
        WTotal = 0.0
        WDescripcionMonto = ""
        WPais = ""
        WCondPagoII = ""
        WViaII = ""
        WObservacionesII = ""
        WObservacionesIII = ""
        WDescripcionMontoII = ""

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

                            WNroProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                            WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                            WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                            WDescripcionCliente = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                            WDireccion = IIf(IsDBNull(.Item("Direccion")), "", .Item("Direccion"))
                            WLocalidad = IIf(IsDBNull(.Item("Localidad")), "", .Item("Localidad"))
                            WCondPago = IIf(IsDBNull(.Item("CondPago")), "", .Item("CondPago"))
                            WOCCliente = IIf(IsDBNull(.Item("OCCliente")), "", .Item("OCCliente"))
                            WCondicion = IIf(IsDBNull(.Item("Condicion")), "", .Item("Condicion"))
                            WVia = IIf(IsDBNull(.Item("Via")), "", .Item("Via"))
                            WObservaciones = IIf(IsDBNull(.Item("Observaciones")), "", .Item("Observaciones"))
                            WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))
                            WDescripcionMonto = IIf(IsDBNull(.Item("DescriTotal")), "", .Item("DescriTotal"))
                            WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                            WCondPagoII = IIf(IsDBNull(.Item("CondPagoII")), "", .Item("CondPagoII"))
                            WViaII = IIf(IsDBNull(.Item("ViaII")), "", .Item("ViaII"))
                            WObservacionesII = IIf(IsDBNull(.Item("ObservacionesII")), "", .Item("ObservacionesII"))
                            WObservacionesIII = IIf(IsDBNull(.Item("ObservacionesIII")), "", .Item("ObservacionesIII"))
                            WDescripcionMontoII = IIf(IsDBNull(.Item("DescriTotalII")), "", .Item("DescriTotalII"))

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
                            txtVia.Text = WVia
                            txtViaII.Text = WViaII
                            txtObservaciones.Text = WObservaciones
                            txtObservacionesII.Text = WObservacionesII
                            txtObservacionesIII.Text = WObservacionesIII
                            txtDescripcionTotal.Text = WDescripcionMonto
                            txtDescripcionTotalII.Text = WDescripcionMontoII
                            txtPais.Text = WPais
                            txtTotal.Text = Helper.formatonumerico(WTotal)

                        End If

                        WRowIndex = Val(WRenglon) - 1

                        dgvProductos.Rows(WRowIndex).Cells(0).Value = IIf(IsDBNull(.Item("Producto")), "", .Item("Producto"))
                        dgvProductos.Rows(WRowIndex).Cells(2).Value = IIf(IsDBNull(.Item("Cantidad")), "", .Item("Cantidad"))
                        dgvProductos.Rows(WRowIndex).Cells(3).Value = IIf(IsDBNull(.Item("Precio")), "", .Item("Precio"))

                    End With
                Loop

                _ProcesarDatosGrilla()

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

            txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6)

            Try
                _TraerProforma(txtNroProforma.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            txtFechaAux.Visible = False
            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNroProforma.Text = ""
        End If

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFecha.Text) Then
                txtCliente.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Sub _ConsultarProductos()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, Descripcion FROM Terminado WHERE Codigo >= 'PT-00004-100' AND Codigo <= 'PT-99999-999' ORDER BY Codigo")
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
                        WItem = .Item("Codigo") & SEPARADOR_CONSULTA & .Item("Descripcion")

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
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            If Not IsNothing(cliente) Then
                ' Guardar y llenar los datos que se puedan extraer del registro de cliente.
                txtCliente.Text = cliente("Cliente")
                txtDescripcionCliente.Text = cliente("Razon")
                txtDireccionCliente.Text = cliente("Direccion")
                txtLocalidadCliente.Text = cliente("Localidad")

                txtPais.Focus()
            Else
                MsgBox("Cliente inexistente.", MsgBoxStyle.Information)
                txtPais.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

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
            Return Helper._NormalizarFila(resultados.Rows(0))
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
            Else
                txtOCCliente.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCondicionPago.Text = ""
        End If

    End Sub

    Private Sub txtOCCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOCCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtOCCliente.Text) = "" Then : Exit Sub : End If

            cmbCondicion.Focus()
            cmbCondicion.DroppedDown = True

        ElseIf e.KeyData = Keys.Escape Then
            txtOCCliente.Text = ""
        End If

    End Sub

    Private Sub cmbCondicion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCondicion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(cmbCondicion.SelectedItem) = "" Then : Exit Sub : End If

            txtVia.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicion_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCondicion.DropDownClosed
        If cmbCondicion.SelectedIndex > 0 Then
            txtVia.Focus()
        End If
    End Sub

    Private Sub txtVia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVia.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtVia.Text) <> "" Then
                txtViaII.Focus()
            Else
                txtObservaciones.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtVia.Text = ""
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
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If resultados.Rows.Count > 0 Then
            Return Helper._NormalizarFila(resultados.Rows(0))
        Else
            Return Nothing
        End If

    End Function

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then : Exit Sub : End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvProductos
                    .Rows(WRow).Cells(0).Value = txtFechaAux.Text

                    Dim terminado = _BuscarTerminado(txtFechaAux.Text)

                    If Not IsNothing(terminado) Then
                        .Rows(WRow).Cells(0).Value = terminado("Codigo")
                        .Rows(WRow).Cells(1).Value = terminado("Descripcion")

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

                    If valor <> "" Then

                        Select Case iCol
                            Case 2, 3
                                _RecalcularTotalFila(iRow)
                            Case Else

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

                        Case Else

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

            .Cells(4).Value = Helper.formatonumerico(WTotal)
        End With

    End Sub

    Private Sub _NormalizarNumerosGrilla()
        Dim WTotal = 0.0

        For Each row As DataGridViewRow In dgvProductos.Rows
            With row
                .Cells(2).Value = IIf(.Cells(2).Value <> "", Helper.formatonumerico(.Cells(2).Value), "")
                .Cells(3).Value = IIf(.Cells(3).Value <> "", Helper.formatonumerico(.Cells(3).Value), "")
                '.Cells(4).Value = IIf(.Cells(4).Value <> "", Helper.formatonumerico(.Cells(4).Value), "")
                WTotal += (Val(.Cells(2).Value) * Val(.Cells(3).Value))
            End With
        Next

        txtTotal.Text = Helper.formatonumerico(WTotal)
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProforma.KeyPress, txtOCCliente.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcionTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionTotal.KeyDown, txtDescripcionTotalII.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDescripcionTotal.Text) = "" Then : Exit Sub : End If

            'txtTotal.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcionTotal.Text = ""
        End If

    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtObservaciones.Text) <> "" Then
                txtObservacionesII.Focus()
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
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
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
            Dim trans As SqlTransaction

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

            Catch ex As Exception

                If Not IsNothing(trans) Then
                    trans.Rollback()
                End If

                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)

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
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
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


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cn As New SqlConnection()
        Dim trans As SqlTransaction
        Dim cm As New SqlCommand()
        Dim _Actualiza As Boolean = False
        Dim WClave, WRenglon, XRenglon, WNroProforma, XNroProforma, WFecha, WFechaOrd, WCliente, WDireccion, WLocalidad, WCondPago, WOCCliente, WCondicion, WVia, WObservaciones, WTotal, WDescripcionMonto, WSql, WPais
        Dim WCondPagoII, WViaII, WObservacionesII, WObservacionesIII, WDescripcionMontoII
        Dim WProd As String, WCant, WPrecio


        WClave = ""
        WRenglon = 0
        XRenglon = ""
        WNroProforma = _Left(txtNroProforma.Text, 6)
        XNroProforma = Helper.ceros(WNroProforma, 6)
        WFecha = txtFecha.Text
        WFechaOrd = Helper.ordenaFecha(WFecha)
        WCliente = _Left(txtCliente.Text, 6)
        WDireccion = _Left(txtDireccionCliente.Text, 100)
        WLocalidad = _Left(txtLocalidadCliente.Text, 50)
        WCondPago = _Left(txtCondicionPago.Text, 50)
        WOCCliente = _Left(txtOCCliente.Text, 20)
        WCondicion = Val(cmbCondicion.SelectedIndex)
        WVia = _Left(txtVia.Text, 20)
        WObservaciones = _Left(txtObservaciones.Text, 100)
        WTotal = Val(Helper.formatonumerico(txtTotal.Text))
        WDescripcionMonto = UCase(_Left(txtDescripcionTotal.Text, 100))
        WPais = _Left(txtPais.Text, 15)

        WCondPagoII = Trim(txtCondicionPagoII.Text)
        WViaII = Trim(txtViaII.Text)
        WObservacionesII = Trim(txtObservacionesII.Text)
        WObservacionesIII = Trim(txtObservacionesIII.Text)
        WDescripcionMontoII = Trim(txtDescripcionTotalII.Text)

        WSql = ""

        WProd = ""
        WCant = 0.0
        WPrecio = 0.0

        Try
            cn.ConnectionString = _CS() ' TRUE: Para testing en local.

            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn


            WSql = "DELETE ProformaExportacion WHERE Proforma = '" & XNroProforma & "'"

            cm.Transaction = trans

            cm.CommandText = WSql

            cm.ExecuteNonQuery()

            For Each row As DataGridViewRow In dgvProductos.Rows
                With row
                    WProd = Trim(.Cells(0).Value)
                    WCant = Val(.Cells(2).Value)
                    WPrecio = Val(.Cells(3).Value)

                    If WProd.Replace("-", "") <> "" Then

                        If WCant > 0 And WPrecio > 0 Then
                            WRenglon += 1

                            XRenglon = Helper.ceros(WRenglon, 2)

                            WClave = XNroProforma & XRenglon

                            WSql = "INSERT INTO ProformaExportacion (Clave, Proforma, Renglon, Fecha, FechaOrd, Cliente, Direccion, Localidad, CondPago, CondPagoII, OCCliente, Condicion, Via, ViaII, Observaciones, ObservacionesII, ObservacionesIII, Producto, Cantidad, Precio, Total, DescriTotal, DescriTotalII, Pais)" _
                                 & " VALUES " _
                                 & " ('" & WClave & "', '" & XNroProforma & "', '" & XRenglon & "', '" & WFecha & "', '" & WFechaOrd & "', '" & WCliente & "', '" & WDireccion & "', '" & WLocalidad & "', '" & WCondPago & "', '" & WCondPagoII & "', '" & WOCCliente & "', '" & WCondicion & "', '" & WVia & "', '" & WViaII & "', '" & WObservaciones & "', '" & WObservacionesII & "', '" & WObservacionesIII & "', '" & WProd & "', " & Helper.formatonumerico(WCant) & ", " & Helper.formatonumerico(WPrecio) & ", " & Helper.formatonumerico(WTotal) & ", '" & WDescripcionMonto & "', '" & WDescripcionMontoII & "', '" & WPais & "')"


                            cm.CommandText = WSql

                            cm.ExecuteNonQuery()

                        End If
                    Else
                        Exit For
                    End If

                End With
            Next

            ' Si no hubo nigun error durante la carga de datos, confirmo los cambios.
            trans.Commit()

            txtNroProforma.Text = WNroProforma
            txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            txtNroProforma.Focus()

        Catch ex As Exception
            If Not IsNothing(trans) Then
                ' En caso de una Excepcion, vuelvo para atras los cambios.
                trans.Rollback()
                trans = Nothing
            End If
            cn.Close()
            cn = Nothing
            cm = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        MsgBox("La Proforma " & XNroProforma & ", ha sido grabada con exito.", MsgBoxStyle.Information)

        btnVistaPrevia.PerformClick()

        btnLimpiar.PerformClick()

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtNroProforma.Text = ""
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtCliente.Text = ""
        txtDescripcionCliente.Text = ""
        txtDireccionCliente.Text = ""
        txtLocalidadCliente.Text = ""
        txtCondicionPago.Text = ""
        txtOCCliente.Text = ""
        txtVia.Text = ""
        cmbCondicion.SelectedIndex = 0
        txtObservaciones.Text = ""
        txtDescripcionTotal.Text = ""
        txtTotal.Text = ""
        txtPais.Text = ""
        _LimpiarGrilla()

        txtNroProforma.Focus()

        GrupoConsulta.Visible = False

        txtFechaAux.Visible = False

        WRow = -1
        Wcol = -1

        ' Cargamos automaticamente el próximo número de Proforma.
        _TraerProximoNroProforma()
    End Sub

    Private Sub btnVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVistaPrevia.Click
        With VistaPrevia
            .Reporte = New ProformaVistaPrevia
            '.Reporte.DataSourceConnections(0).SetLogonProperties()
            .Formula = "{ProformaExportacion.Proforma} = '" & txtNroProforma.Text & "'"
            .Mostrar()
        End With
    End Sub

    Private Sub txtObservacionesII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionesII.KeyDown
        If e.KeyData = Keys.Enter Then

            txtObservacionesIII.Focus()

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
            If Trim(txtCondicionPago.Text) = "" Then : Exit Sub : End If

            txtOCCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCondicionPago.Text = ""
        End If
    End Sub

    Private Sub txtViaII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtViaII.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtVia.Text) = "" Then : Exit Sub : End If

            txtObservaciones.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtVia.Text = ""
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

                    .CurrentCell = .Rows(WRowIndex).Cells(0)
                    .Focus()
                End With

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
    End Sub

    Private Sub txtPais_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPais.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtPais.Text) = "" Then : Exit Sub : End If

            txtCondicionPago.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPais.Text = ""
        End If

    End Sub

    Private Sub txtCliente_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCliente.MouseDoubleClick

        lstOpcionesConsulta.SelectedIndex = 0

        btnConsulta.PerformClick()

        lstOpcionesConsulta_MouseClick(Nothing, Nothing)

    End Sub
End Class