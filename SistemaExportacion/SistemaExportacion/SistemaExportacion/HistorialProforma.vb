Imports System.Data.SqlClient

Public Class HistorialProforma

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 6

    Private _Proforma As String

    Public Property Proforma() As String
        Get
            Return _Proforma
        End Get
        Set(ByVal value As String)
            _Proforma = value
        End Set
    End Property

    Private Sub HistorialProforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _LimpiarGrilla()

        If Not IsNothing(Me.Proforma) Then
            Try
                _MostrarHistorial()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Me.Close()
            End Try
        End If

        txtFechaAux.Visible = False

        WRow = -1
        Wcol = -1

    End Sub

    Private Sub HistorialProforma_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtNroProforma.Focus()
    End Sub

    Private Function _CS(Optional ByVal empresa As String = "SurfactanSA")
        Return Helper._ConectarA(empresa, True)
        'Return Helper._ConectarA(empresa)
    End Function

    Private Sub _MostrarHistorial()
        If IsNothing(Me.Proforma) Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.CommandText = ""
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

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
        'Dim cn As SqlConnection = New SqlConnection()
        'Dim cm As SqlCommand = New SqlCommand("SELECT * FROM ProformaExportacion WHERE Proforma = '" & NroProforma & "'")
        'Dim dr As SqlDataReader
        'Dim WRenglon = 0

        'btnLimpiar.PerformClick()

        'Try
        '    cn.ConnectionString = _CS()
        '    cn.Open()
        '    cm.Connection = cn

        '    dr = cm.ExecuteReader()

        '    If dr.HasRows Then
        '        Do While dr.Read()
        '            With dr
        '                If Val(.Item("Renglon")) = 1 Then
        '                    txtNroProforma.Text = .Item("Proforma")
        '                    txtFecha.Text = .Item("Fecha")
        '                    txtCliente.Text = .Item("Cliente")
        '                    _TraerDescripcionCliente()
        '                    txtDireccionCliente.Text = .Item("Direccion")
        '                    txtLocalidadCliente.Text = .Item("Localidad")
        '                    txtCondicionPago.Text = .Item("CondPago")
        '                    txtOCCliente.Text = .Item("OCCliente")
        '                    cmbCondicion.SelectedIndex = Val(.Item("Condicion"))
        '                    txtVia.Text = .Item("Via")
        '                    txtObservaciones.Text = .Item("Observaciones")
        '                    txtDescripcionTotal.Text = .Item("DescriTotal")
        '                    txtPais.Text = .Item("Pais")
        '                    txtTotal.Text = Helper.formatonumerico(.Item("Total"))
        '                End If

        '                dgvProductos.Rows(WRenglon).Cells(0).Value = .Item("Producto")
        '                dgvProductos.Rows(WRenglon).Cells(2).Value = .Item("Cantidad")
        '                dgvProductos.Rows(WRenglon).Cells(3).Value = .Item("Precio")

        '                WRenglon += 1

        '            End With
        '        Loop

        '        _ProcesarDatosGrilla()

        '    Else
        '        txtNroProforma.Text = NroProforma
        '    End If

        'Catch ex As Exception
        '    Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        'Finally

        '    dr = Nothing
        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing

        'End Try

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

    'Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

    '        If Helper._ValidarFecha(txtFecha.Text) Then
    '            txtCliente.Focus()
    '        End If

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtFecha.Text = ""
    '    End If

    'End Sub

    'Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtCliente.Text) = "" Then : Exit Sub : End If

    '        Dim cliente = _BuscarCliente(txtCliente.Text)

    '        If Not IsNothing(cliente) Then
    '            ' Guardar y llenar los datos que se puedan extraer del registro de cliente.
    '            txtCliente.Text = cliente("Cliente")
    '            txtDescripcionCliente.Text = cliente("Razon")
    '            txtDireccionCliente.Text = cliente("Direccion")
    '            txtLocalidadCliente.Text = cliente("Localidad")

    '            txtCondicionPago.Focus()
    '        Else
    '            MsgBox("Cliente inexistente.", MsgBoxStyle.Information)
    '            txtCliente.Focus()
    '        End If

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtCliente.Text = ""
    '    End If

    'End Sub

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

                'With dgvProductos
                '    .Rows(WRow).Cells(0).Value = txtFechaAux.Text

                '    Dim terminado = _BuscarTerminado(txtFechaAux.Text)

                '    If Not IsNothing(terminado) Then
                '        .Rows(WRow).Cells(0).Value = terminado("Codigo")
                '        .Rows(WRow).Cells(1).Value = terminado("Descripcion")

                '        .CurrentCell = .Rows(WRow).Cells(2)
                '        .Focus()

                '        txtFechaAux.Visible = False
                '        txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                '    Else
                '        txtFechaAux.Focus()
                '    End If
                'End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Clear()
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
                    'Case 1
                    '    If Not _EsDecimalOControl(keyData) Then
                    '        Return True
                    '    End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If valor <> "" Then

                        Select Case iCol
                            'Case 2, 3
                            '    _RecalcularTotalFila(iRow)
                            Case Else

                        End Select

                        '_NormalizarNumerosGrilla()

                    End If

                    Select Case iCol
                        'Case 3, 4
                        '    If iRow = PRODUCTOS_MAX - 1 Then
                        '        .CurrentCell = .Rows(iRow).Cells(iCol)
                        '    Else
                        '        Try
                        '            .CurrentCell = .Rows(iRow + 1).Cells(0)
                        '        Catch ex As Exception
                        '            .CurrentCell = .Rows(iRow).Cells(iCol)
                        '        End Try
                        '    End If

                        'Case Else
                        '    .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then


                    Select Case iCol
                        'Case 0, 2, 3

                        '    .Rows(iRow).Cells(iCol).Value = ""

                        '    If iCol = 4 Then
                        '        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                        '    Else
                        '        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        '    End If

                        '    .CurrentCell = .Rows(iRow).Cells(iCol)

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

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProforma.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
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
        MsgBox("Aun no implementado. No hay todavia realizadas consultas.", MsgBoxStyle.Information)
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
        'Dim cn As New SqlConnection()
        'Dim trans As SqlTransaction
        'Dim cm As New SqlCommand()
        'Dim _Actualiza As Boolean = False
        'Dim WClave, WRenglon, XRenglon, WNroProforma, XNroProforma, WFecha, WFechaOrd, WCliente, WDireccion, WLocalidad, WCondPago, WOCCliente, WCondicion, WVia, WObservaciones, WTotal, WDescripcionMonto, WSql, WPais
        'Dim WProd As String, WCant, WPrecio

        'WClave = ""
        'WRenglon = 0
        'XRenglon = ""
        'WNroProforma = _Left(txtNroProforma.Text, 6)
        'XNroProforma = Helper.ceros(WNroProforma, 6)
        'WFecha = txtFecha.Text
        'WFechaOrd = Helper.ordenaFecha(WFecha)
        'WCliente = _Left(txtCliente.Text, 6)
        'WDireccion = _Left(txtDireccionCliente.Text, 100)
        'WLocalidad = _Left(txtLocalidadCliente.Text, 50)
        'WCondPago = _Left(txtCondicionPago.Text, 50)
        'WOCCliente = _Left(txtOCCliente.Text, 20)
        'WCondicion = Val(cmbCondicion.SelectedIndex)
        'WVia = _Left(txtVia.Text, 20)
        'WObservaciones = _Left(txtObservaciones.Text, 100)
        'WTotal = Val(Helper.formatonumerico(txtTotal.Text))
        'WDescripcionMonto = UCase(_Left(txtDescripcionTotal.Text, 100))
        'WPais = _Left(txtPais.Text, 15)

        'WSql = ""

        'WProd = ""
        'WCant = 0.0
        'WPrecio = 0.0

        'Try
        '    cn.ConnectionString = _CS() ' TRUE: Para testing en local.

        '    cn.Open()
        '    trans = cn.BeginTransaction

        '    cm.Connection = cn


        '    WSql = "DELETE ProformaExportacion WHERE Proforma = '" & XNroProforma & "'"

        '    cm.Transaction = trans

        '    cm.CommandText = WSql

        '    cm.ExecuteNonQuery()

        '    For Each row As DataGridViewRow In dgvProductos.Rows
        '        With row
        '            WProd = Trim(.Cells(0).Value)
        '            WCant = Val(.Cells(2).Value)
        '            WPrecio = Val(.Cells(3).Value)

        '            If WProd.Replace("-", "") <> "" Then

        '                If WCant > 0 And WPrecio > 0 Then
        '                    WRenglon += 1

        '                    XRenglon = Helper.ceros(WRenglon, 2)

        '                    WClave = XNroProforma & XRenglon

        '                    WSql = "INSERT INTO ProformaExportacion (Clave, Proforma, Renglon, Fecha, FechaOrd, Cliente, Direccion, Localidad, CondPago, OCCliente, Condicion, Via, Observaciones, Producto, Cantidad, Precio, Total, DescriTotal, Pais)" _
        '                         & " VALUES " _
        '                         & " ('" & WClave & "', '" & XNroProforma & "', '" & XRenglon & "', '" & WFecha & "', '" & WFechaOrd & "', '" & WCliente & "', '" & WDireccion & "', '" & WLocalidad & "', '" & WCondPago & "', '" & WOCCliente & "', '" & WCondicion & "', '" & WVia & "', '" & WObservaciones & "', '" & WProd & "', " & Helper.formatonumerico(WCant) & ", " & Helper.formatonumerico(WPrecio) & ", " & Helper.formatonumerico(WTotal) & ", '" & WDescripcionMonto & "', '" & WPais & "')"


        '                    cm.CommandText = WSql

        '                    cm.ExecuteNonQuery()

        '                End If
        '            Else
        '                Exit For
        '            End If

        '        End With
        '    Next

        '    ' Si no hubo nigun error durante la carga de datos, confirmo los cambios.
        '    trans.Commit()

        '    txtNroProforma.Text = WNroProforma
        '    txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        '    txtNroProforma.Focus()

        'Catch ex As Exception
        '    If Not IsNothing(trans) Then
        '        ' En caso de una Excepcion, vuelvo para atras los cambios.
        '        trans.Rollback()
        '        trans = Nothing
        '    End If
        '    cn.Close()
        '    cn = Nothing
        '    cm = Nothing
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        '    Exit Sub
        'End Try

        'MsgBox("La Proforma " & XNroProforma & ", ha sido grabada con exito.", MsgBoxStyle.Information)

        'btnVistaPrevia.PerformClick()

        'btnLimpiar.PerformClick()

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'txtNroProforma.Text = ""
        'txtFecha.Text = Date.Now.ToString("dd-MM-yyyy")
        'txtCliente.Text = ""
        'txtDescripcionCliente.Text = ""
        'txtDireccionCliente.Text = ""
        'txtLocalidadCliente.Text = ""
        'txtCondicionPago.Text = ""
        'txtOCCliente.Text = ""
        'txtVia.Text = ""
        'cmbCondicion.SelectedIndex = 0
        'txtObservaciones.Text = ""
        'txtDescripcionTotal.Text = ""
        'txtTotal.Text = ""
        'txtPais.Text = ""
        '_LimpiarGrilla()

        'txtNroProforma.Focus()
    End Sub

    Private Sub btnVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVistaPrevia.Click
        With VistaPrevia
            .Reporte = New ProformaVistaPrevia
            .Formula = "{ProformaExportacion.Proforma} = '" & txtNroProforma.Text & "'"
            .Mostrar()
        End With
    End Sub
End Class