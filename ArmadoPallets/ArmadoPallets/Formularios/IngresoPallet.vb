Imports System.Data.SqlClient
Imports System.IO
Imports ArmadoPallets.Clases

Public Class IngresoPallet

    Private Const YMARGEN = 1.2
    Private Const XMARGEN = 3
    Private WRow, Wcol As Integer
    Private WNroPallet As Integer

    Sub New(Optional ByVal WProforma As String = "", Optional ByVal WPedido As String = "", Optional ByVal XNroPallet As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtProforma.Text = WProforma
        txtPedido.Text = WPedido
        WNroPallet = XNroPallet

    End Sub

    Private Sub IngresoPallet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WRow = -1
        Wcol = -1

        If Trim(txtProforma.Text) <> "" Then
            btnLimpiar.PerformClick()
            _CargarInformacionPallets()
        End If
    End Sub

    Private Sub _CargarInformacionPallets()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT CodigoPallet, Altura, Producto, Partida, CodigoEnvase, Bultos, KgBultos, FechaDisponible FROM ArmadoPallets WHERE Proforma = '" & txtProforma.Text & "' AND Pedido = '" & txtPedido.Text & "' AND Pallet = '" & WNroPallet & "' ORDER BY Pallet")
        Dim dr As SqlDataReader

        Try
            dgvProductos.Rows.Clear()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        txtCodigo.Text = IIf(IsDBNull(.Item("CodigoPallet")), "", .Item("CodigoPallet"))
                        txtAltura.Text = IIf(IsDBNull(.Item("Altura")), "", .Item("Altura"))

                        Dim R = dgvProductos.Rows.Add

                        dgvProductos.Rows(R).Cells("Terminado").Value = IIf(IsDBNull(.Item("Producto")), "", .Item("Producto"))
                        dgvProductos.Rows(R).Cells("Partida").Value = IIf(IsDBNull(.Item("Partida")), "", .Item("Partida"))
                        dgvProductos.Rows(R).Cells("Envase").Value = IIf(IsDBNull(.Item("CodigoEnvase")), "", .Item("CodigoEnvase"))
                        dgvProductos.Rows(R).Cells("CantidadUnidades").Value = IIf(IsDBNull(.Item("Bultos")), "", .Item("Bultos"))
                        dgvProductos.Rows(R).Cells("KgUnidad").Value = IIf(IsDBNull(.Item("KgBultos")), "", .Item("KgBultos"))
                        dgvProductos.Rows(R).Cells("Disponible").Value = IIf(IsDBNull(.Item("FechaDisponible")), "", .Item("FechaDisponible"))

                    Loop

                    ' Traemos los datos del Pallet.
                    txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

                    ' Traemos los datos de los Envases y Productos Terminados.
                    For Each row As DataGridViewRow In dgvProductos.Rows
                        Dim WTerminado = If(row.Cells("Terminado").Value, "")
                        If WTerminado.ToString.Trim <> "" Then row.Cells("DescTerminado").Value = _TraerDescripcionTerminado(WTerminado)

                        Dim WEnvase = If(row.Cells("Envase").Value, "")
                        If WEnvase.ToString.Trim <> "" Then row.Cells("DescEnvase").Value = _TraerDescripcionEnvase(WEnvase)
                    Next

                    ' Recalculamos los Pesos Totales.
                    _CalcularPesos()

                    ' Ocultamos las mascaras auxiliares de la grilla.
                    For Each msk As MaskedTextBox In {txtFechaAux, txtFechaAux2, txtFechaAux3}
                        msk.Visible = False
                    Next

                End If
            End With

            ' Agregamos una nueva fila por si se quiere agregar un nuevo item.
            Dim _R = dgvProductos.Rows.Add()

            ' Se selecciona la fila para que se actualicen las demas filas y se muestren los datos.
            dgvProductos.CurrentCell = dgvProductos.Rows(_R).Cells(0)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al cargar los Pallets referidos a esta Proforma desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoPallet_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Len(txtCodigo.Text.Replace(" ", "")) < 10 Then : Exit Sub : End If

            txtCodigo.Text = UCase(txtCodigo.Text)

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion, TamanioBase, Tara FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = Helper._ConectarA
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                lblDescPallet.Text = ""
                lblBase.Text = ""
                lblTara.Text = ""

                If dr.HasRows Then

                    dr.Read()

                    lblDescPallet.Text = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                    lblBase.Text = IIf(IsDBNull(dr.Item("TamanioBase")), "", dr.Item("TamanioBase"))
                    lblTara.Text = IIf(IsDBNull(dr.Item("Tara")), "0", dr.Item("Tara"))

                    lblDescPallet.Text = UCase(lblDescPallet.Text.Trim)
                    lblBase.Text = UCase(lblBase.Text.Trim)
                    lblTara.Text = Helper.formatonumerico(lblTara.Text)

                    txtAltura.Focus()

                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la información del Pallet desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Clear()
        End If

    End Sub

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then : Exit Sub : End If

            With dgvProductos
                .Rows(WRow).Cells("Terminado").Value = UCase(txtFechaAux.Text)

                Dim WDescTerminado As String = _TraerDescripcionTerminado(txtFechaAux.Text)

                If WDescTerminado <> "" Then
                    .Rows(WRow).Cells("DescTerminado").Value = WDescTerminado

                    .CurrentCell = .Rows(WRow).Cells("Partida")

                    txtFechaAux.Visible = False
                    txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                Else
                    MsgBox("Producto Inexistente")
                End If

                '.Focus()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub txtFechaAux2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux2.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux2.Text.Replace("-", "")) = "" Then : Exit Sub : End If

            With dgvProductos
                .Rows(WRow).Cells("Envase").Value = UCase(txtFechaAux2.Text)

                Dim WDescTerminado As String = _TraerDescripcionEnvase(txtFechaAux2.Text)

                If WDescTerminado <> "" Then
                    .Rows(WRow).Cells("DescEnvase").Value = WDescTerminado

                    .CurrentCell = .Rows(WRow).Cells("CantidadUnidades")

                    .Focus()

                    txtFechaAux2.Visible = False
                    txtFechaAux2.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                Else
                    MsgBox("Envase Inexistente")
                End If

                '.Focus()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux2.Text = ""
        End If

    End Sub

    Private Sub txtFechaAux3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux3.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux3.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtFechaAux3.Text) Then Exit Sub

            With dgvProductos
                .Rows(WRow).Cells("Disponible").Value = UCase(txtFechaAux3.Text)

                .CurrentCell = .Rows(WRow).Cells("Disponible")

                If WRow >= .Rows.Count - 1 Then
                    .Rows.Add()
                End If

                .CurrentCell = .Rows(WRow + 1).Cells("Terminado")

                txtFechaAux3.Visible = False
                txtFechaAux3.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux2.Text = ""
        End If

    End Sub

    Private Function _TraerDescripcionEnvase(ByVal WEnvase As String) As String
        Dim WDesc = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Articulo WHERE Codigo = '" & WEnvase & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WDesc = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc.Trim()
    End Function

    Private Function _TraerDescripcionTerminado(ByVal WTerminado As String) As String
        Dim WDesc = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Terminado WHERE Codigo = '" & WTerminado & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WDesc = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Producto Terminado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc.Trim
    End Function

    Private Sub dgvProductos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellEnter
        txtFechaAux.Visible = False
        txtFechaAux2.Visible = False
        txtFechaAux3.Visible = False
        With dgvProductos
            Dim _location As New Point

            Select Case e.ColumnIndex
                Case 0, 3, 7

                    .ClearSelection()
                    .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                    _location = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                    _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN * 2
                    _location.X += .Location.X + XMARGEN '+ (.CurrentCell.Size.Width - txtFechaAux.Size.Width) 
                    WRow = e.RowIndex
                    Wcol = e.ColumnIndex

            End Select



            Select Case e.ColumnIndex
                Case 0
                    Dim _R = .Rows(e.RowIndex).Cells("Terminado").Value

                    With txtFechaAux
                        .Visible = True
                        .Location = _location
                        .Clear()
                        .Text = .Text.Replace(" ", "")
                        .Text = _R
                        .Focus()
                    End With
                Case 3
                    Dim _R = .Rows(e.RowIndex).Cells("Envase").Value

                    With txtFechaAux2
                        .Visible = True
                        .Location = _location
                        .Clear()
                        .Text = .Text.Replace(" ", "")
                        .Text = _R
                        .Focus()
                    End With

                Case 7
                    Dim _R = .Rows(e.RowIndex).Cells("Disponible").Value
                    _location.X -= XMARGEN

                    With txtFechaAux3
                        .Visible = True
                        .Location = _location
                        .Clear()
                        .Text = .Text.Replace(" ", "")
                        .Text = _R
                        .Focus()
                    End With
            End Select

        End With
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        With dgvProductos.Rows
            .Clear()
            .Add()
        End With

        txtAltura.Text = ""
        txtCodigo.Clear()
        txtFechaAux.Visible = False
        txtFechaAux.Clear()
        txtFechaAux2.Visible = False
        txtFechaAux2.Clear()

        For Each lbl As Label In {lblBase, lblTara, lblTotalKgBrutos, lblTotalKgNetos}
            lbl.Text = ""
        Next

        txtCodigo.Focus()

    End Sub

    Private Sub txtAltura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAltura.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAltura.Text) = "" Then : Exit Sub : End If

            txtAltura.Text = Helper.formatonumerico(txtAltura.Text)

            With dgvProductos
                If .Rows.Count > 0 Then
                    .ClearSelection()
                    .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                    Dim _location As Point = .GetCellDisplayRectangle(0, 0, False).Location

                    _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN * 2
                    _location.X += .Location.X + XMARGEN '+ (.CurrentCell.Size.Width - txtFechaAux.Size.Width) 
                    txtFechaAux.Location = _location
                    txtFechaAux.Clear()
                    txtFechaAux.Text = .Rows(0).Cells("Terminado").Value
                    txtFechaAux.Text = txtFechaAux.Text.Replace(" ", "")
                    WRow = 0
                    Wcol = 0
                    txtFechaAux.Visible = True
                    txtFechaAux.Focus()
                End If
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtAltura.Text = ""
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
                Dim valor = If(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 5
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case 6
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    valor = Trim(valor)

                    ' Validamos los datos segun las columnas antes de seguir.

                    Select Case iCol
                        Case 2, 5, 6
                            If Val(valor) = 0 Then Return True
                    End Select

                    If valor <> "" Then

                        Select Case iCol
                            Case 2
                                Dim WTerminado = If(.CurrentRow.Cells(0).Value, "")
                                If Not _PartidaValida(valor, WTerminado) Then
                                    MsgBox("La Partida no coincide con el Producto Terminado indicado")
                                    Return True
                                End If

                            Case 6
                                valor = Helper.formatonumerico(valor)
                                .CurrentCell.Value = valor
                        End Select

                        ' Actualizamos los calculos de pesos.
                        _CalcularPesos()

                    End If

                    Select Case iCol
                        Case 7

                            If iRow < .Rows.Count - 1 Then
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            ElseIf valor <> "" Then
                                .Rows.Add()
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 6 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub _CalcularPesos()
        Dim WPeso = 0.0
        For Each row As DataGridViewRow In dgvProductos.Rows

            Dim P1 = If(row.Cells("CantidadUnidades").Value, 0)
            Dim P2 = If(row.Cells("KgUnidad").Value, 0)

            P1 = Val(Helper.formatonumerico(P1))
            P2 = Val(Helper.formatonumerico(P2))

            WPeso += P1 * P2

        Next

        lblTotalKgBrutos.Text = Val(Helper.formatonumerico(WPeso)) + Val(lblTara.Text)
        lblTotalKgNetos.Text = Helper.formatonumerico(WPeso)

        lblTotalKgBrutos.Text = Helper.formatonumerico(lblTotalKgBrutos.Text)
        lblTotalKgNetos.Text = Helper.formatonumerico(lblTotalKgNetos.Text)

    End Sub

    Private Function _PartidaValida(ByVal WPartida As Object, ByVal wTerminado As String) As Boolean

        For Each WEmpresa As String In Conexion.Empresas

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Hoja, Producto FROM Hoja WHERE Hoja = '" & WPartida & "' AND Producto = '" & wTerminado & "' AND Renglon = 1")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = Helper._ConectarA(WEmpresa)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Catch ex As Exception
                Throw New Exception("Hubo un problema al querer consultar la Partida en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        Next

        Return False

    End Function

    Private Sub btnAgregarPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPallet.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        Try

            '
            ' Validamos los datos.
            '
            If Not _ExisteArticulo(txtCodigo.Text) Then
                Throw New Exception("El Codigo de Pallet indicado no es existente")
            End If

            If Val(txtAltura.Text) = 0 Then
                Throw New Exception("Debe indicarse una altura válida.")
            End If

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            ' Recorro las fila y voy guardando a medida que corroboro que la informacion del producto y el envase sean correctas.
            Dim WDate = Date.Now.ToString("dd-MM-yyyy")
            Dim WProforma = Helper.ceros(txtProforma.Text, 6)
            Dim WPedido = Helper.ceros(txtPedido.Text, 6)
            Dim WCodPallet = txtCodigo.Text
            Dim WAltura = Helper.formatonumerico(txtAltura.Text)
            Dim WRenglon = 0

            If WNroPallet = -1 Then
                cm.CommandText = "SELECT Max(Pallet) as Maximo FROM ArmadoPallets WHERE Proforma = '" & WProforma & "' AND Pedido = '" & WPedido & "'"
                Using dr = cm.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        WNroPallet = IIf(IsDBNull(dr.Item("Maximo")), 0, dr.Item("Maximo"))
                        WNroPallet += 1
                    Else
                        WNroPallet = 1
                    End If
                End Using
            End If

            ' Elimino la información anterior en caso de existir.
            cm.CommandText = "DELETE FROM ArmadoPallets WHERE Proforma = '" & txtProforma.Text & "' AND Pedido = '" & txtPedido.Text & "' AND Pallet = '" & WNroPallet & "'"
            cm.ExecuteNonQuery()

            For Each row As DataGridViewRow In dgvProductos.Rows

                Dim WClave = ""
                Dim WTerminado = If(row.Cells("Terminado").Value, "")
                Dim WPartida = If(row.Cells("Partida").Value, "")
                Dim WEnvase = If(row.Cells("Envase").Value, "")
                Dim WCantUnidades = If(row.Cells("CantidadUnidades").Value, "")
                Dim WKgUnidad = If(row.Cells("KgUnidad").Value, "")
                Dim WDisponible = If(row.Cells("Disponible").Value, "")
                Dim WDisponibleOrd = Helper.ordenaFecha(WDisponible)

                If WTerminado.ToString.Replace("-", "").Trim = "" Then
                    Continue For
                End If

                If Val(WPartida) = 0 Then
                    Throw New Exception("Debe indicar una partida para el Producto: " & WTerminado)
                End If

                If Not _ExisteTerminado(WTerminado) Then
                    Throw New Exception("El Codigo " & WTerminado & " no existe.")
                End If

                If Not _PartidaSeCorrespondeConTerminado(WPartida, WTerminado) Then
                    Throw New Exception("El Codigo " & WTerminado & " no se corresponde al informado con la Partida " & WPartida & ".")
                End If

                If WEnvase.ToString.Replace("-", "").Trim = "" Or Not _ExisteArticulo(WEnvase) Then
                    Throw New Exception("Debe indicar un Envase válido para el Producto: " & WTerminado)
                End If

                If WDisponible.ToString.Replace("/", "").Trim = "" Or Not Helper._ValidarFecha(WDisponible) Then
                    Throw New Exception("La fecha " & WDisponible & " no es una fecha válida.")
                End If

                If Val(WCantUnidades) = 0 Then
                    Throw New Exception("Debe indicar la Cantidad de Unidades para el Producto " & WTerminado & " Pda: " & WPartida)
                End If

                If Val(WKgUnidad) = 0 Then
                    Throw New Exception("Debe indicar la cantidad de Kg x Unidad para el Producto " & WTerminado & " Pda: " & WPartida)
                End If

                WKgUnidad = Helper.formatonumerico(WKgUnidad)

                WRenglon += 1

                WClave = WProforma & Helper.ceros(WNroPallet, 2) & Helper.ceros(WRenglon, 2)

                cm.CommandText = String.Format("INSERT INTO ArmadoPallets (Clave, Proforma, Pedido, Pallet, Renglon, CodigoPallet, Altura, CodigoEnvase, Bultos, KgBultos, Producto, Partida, FechaDisponible, FechaDisponibleOrd, WDate)" &
                                               " VALUES " &
                                               "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}', '{8}', {9}, '{10}', '{11}', '{12}', '{13}', '{14}')",
                                               WClave, WProforma, WPedido, WNroPallet, WRenglon, WCodPallet, WAltura, WEnvase, WCantUnidades, WKgUnidad, WTerminado, WPartida, WDisponible, WDisponibleOrd, WDate)
                cm.ExecuteNonQuery()

            Next

            trans.Commit()

            Close()

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _PartidaSeCorrespondeConTerminado(ByVal wPartida As Object, ByVal wTerminado As Object) As Boolean

        For Each WEmpresa As String In Conexion.Empresas

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Hoja FROM Hoja WHERE Producto = '" & wTerminado & "' AND Hoja = '" & wPartida & "'")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = Helper._ConectarA(WEmpresa)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Catch ex As Exception
                Throw New Exception("Hubo un problema al querer validar la correspondecia entre el Producto " & wTerminado & " y la Partida " & wPartida & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        Next

        Return False

    End Function

    Private Function _ExisteTerminado(ByVal wTerminado As Object) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Terminado WHERE Codigo = '" & wTerminado & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer validar la existencia del codigo del Producto " & wTerminado & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Function _ExisteArticulo(ByVal s As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Articulo WHERE Codigo = '" & s & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al validar la existencia del Articulo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If txtCodigo.Text.Replace("-", "").Trim <> "" And txtProforma.Text <> "" And txtPedido.Text <> "" And WNroPallet <> -1 Then

            If MsgBox("¿Está seguro de querer eliminar este Pallet?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("DELETE FROM ArmadoPallets WHERE Proforma = '" & txtProforma.Text & "' AND Pedido = '" & txtPedido.Text & "' AND Pallet = '" & WNroPallet & "'")

            Try

                cn.ConnectionString = Helper._ConectarA
                cn.Open()
                cm.Connection = cn
                cm.ExecuteNonQuery()

                MsgBox("El pallet se ha eliminado correctamente", MsgBoxStyle.Information)
                Close()

            Catch ex As Exception
                Throw New Exception("Hubo un problema al querer eliminar el Pellet en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally

                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

        End If

    End Sub

    Private Sub dgvProductos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductos.RowHeaderMouseDoubleClick

        Try
            If e.RowIndex < 0 Then Exit Sub

            If MsgBox("¿Está seguro de querer eliminar este item?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            With dgvProductos
                .Rows.Remove(.Rows(e.RowIndex))
            End With

            _CalcularPesos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class