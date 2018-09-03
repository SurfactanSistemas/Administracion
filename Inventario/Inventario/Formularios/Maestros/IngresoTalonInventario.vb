Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class IngresoTalonInventario

    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 3
    Private WRow, Wcol As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dgvTalones.Rows.Clear()
        dgvTalones.Rows.Add()
        txtNroMovimiento.Text = ""
        txtNroMovimiento.Focus()

        WRow = -1
        Wcol = -1
    End Sub

    Private Sub IngresoTalonInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
        _TraerProximoNumero()
    End Sub

    Private Sub _TraerProximoNumero()
        txtNroMovimiento.Text = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MAX(Numero), 0) + 1 As Proximo FROM Inventario")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                txtNroMovimiento.Text = dr.Item("Proximo")
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub IngresoTalonInventario_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtNroMovimiento.Focus()
    End Sub

    Private Sub txtNroMovimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroMovimiento.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroMovimiento.Text) = "" Then : Exit Sub : End If

            If Not _ExisteMovimiento(txtNroMovimiento.Text) Then
                dgvTalones.Rows.Clear()
                dgvTalones.Rows.Add()
                dgvTalones.CurrentCell = dgvTalones.Rows(0).Cells("Talon")
                dgvTalones.Focus()
                Exit Sub
            End If

            _CargarMovimiento(txtNroMovimiento.Text)

        ElseIf e.KeyData = Keys.Escape Then
            txtNroMovimiento.Text = ""
        End If

    End Sub

    Private Sub _CargarMovimiento(ByVal s As String)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Talon, ISNULL(Tipo, '') Tipo, Articulo, Terminado, ISNULL(Cantidad, 0) Cantidad, Lote, Ubicacion, Observaciones FROM Inventario WHERE Numero = '" & s & "' ORDER BY Talon")
        Dim dr As SqlDataReader
        Dim row As Integer = 0

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Dim WMovimiento = txtNroMovimiento.Text

            btnLimpiar_Click(Nothing, Nothing)
            dgvTalones.Rows.Clear()

            If dr.HasRows Then

                txtNroMovimiento.Text = WMovimiento

                Do While dr.Read()

                    row = dgvTalones.Rows.Add

                    With dgvTalones.Rows(row)

                        .Cells("Talon").Value = dr.Item("Talon")
                        .Cells("Tipo").Value = dr.Item("Tipo")
                        .Cells("Articulo").Value = dr.Item("Articulo")
                        .Cells("Terminado").Value = dr.Item("Terminado")
                        .Cells("Descripcion").Value = If(dr.Item("Tipo").ToUpper = "T", _TraerDescripcionTerminado(dr.Item("Terminado")), _TraerDescripcionArticulo(dr.Item("Articulo")))
                        .Cells("Cantidad").Value = Helper.formatonumerico(dr.Item("Cantidad"))
                        .Cells("Lote").Value = dr.Item("Lote")
                        .Cells("Ubicacion").Value = dr.Item("Ubicacion")
                        .Cells("Observaciones").Value = dr.Item("Observaciones")

                    End With

                Loop

                With dgvTalones
                    row = .Rows.Add()
                    .CurrentCell = .Rows(row).Cells("Talon")
                    .Focus()
                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ExisteMovimiento(ByVal s As String) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Numero FROM Inventario WHERE Numero = '" & s & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del movimiento en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Sub dgvTalones_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTalones.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        If MsgBox("¿Está seguro de eliminar la fila seleccionada?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        With dgvTalones

            .Rows.Remove(.Rows(e.RowIndex))

            Dim I = IIf(.Rows.Count < 1, .Rows.Add, .Rows.Count - 1)

            .CurrentCell = .Rows(I).Cells("Talon")

            .Focus()

        End With

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            cm.CommandText = "DELETE FROM Inventario WHERE Numero = '" & txtNroMovimiento.Text & "'"
            cm.ExecuteNonQuery()

            Dim WRenglon = 0

            For Each row As DataGridViewRow In dgvTalones.Rows

                With row

                    Dim WTalon As String = If(.Cells("Talon").Value, "")
                    Dim WTipo As String = If(.Cells("Tipo").Value, "")
                    Dim WTerminado As String = If(.Cells("Terminado").Value, "")
                    Dim WArticulo As String = If(.Cells("Articulo").Value, "")
                    Dim WCantidad As String = If(.Cells("Cantidad").Value, "")
                    Dim WLote As String = If(.Cells("Lote").Value, "")
                    Dim WUbicacion As String = If(.Cells("Ubicacion").Value, "")
                    Dim WObservaciones As String = If(.Cells("Observaciones").Value, "")
                    Dim WPartida As String = ""


                    If Val(WTalon) = 0 Then Continue For

                    If Trim(WTipo) = "" Or Not {"M", "T"}.Contains(UCase(WTipo)) Then
                        Throw New Exception("Debe especificarse el tipo de Producto en el talón " & WTalon)
                    End If

                    Select Case UCase(WTipo.Trim)
                        Case "M"

                            If WArticulo.Replace("-", "").Trim = "" Or Not _ExisteArticulo(WArticulo) Then
                                Throw New Exception("Debe especificarse el Artículo en el talón " & WTalon)
                            End If

                            'If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
                            '    If Helper._MateriaPrimaValidaPtaI(WArticulo) Then
                            '        Throw New Exception("No se permite realizar inventario de esta Materia Prima en Planta I.")
                            '    End If
                            'End If

                            If {"DY", "DW", "DS"}.Contains(WArticulo.Substring(0, 2).ToUpper) AndAlso Conexion.EmpresaDeTrabajo.ToUpper <> "PELLITAL_III" Then

                                WPartida = WLote

                                cm.CommandText = "SELECT Laudo FROM Laudo WHERE Codigo  = '" & WArticulo & "' AND PartiOri = '" & WLote & "'"

                                Using dr2 = cm.ExecuteReader

                                    If dr2.HasRows Then
                                        dr2.Read()

                                        WLote = dr2.Item("Laudo")
                                    Else
                                        If Not dr2.IsClosed Then dr2.Close()

                                        cm.CommandText = "SELECT Lote FROM Guia WHERE Articulo = '" & WArticulo & "' AND PartiOri = '" & WLote & "'"

                                        Using dr3 As SqlDataReader = cm.ExecuteReader

                                            If dr3.HasRows Then
                                                dr3.Read()
                                                WLote = dr2.Item("Lote")
                                            End If

                                        End Using


                                    End If

                                End Using

                            End If

                        Case "T"

                            If WTerminado.Replace("-", "").Trim = "" Or Not _ExisteTerminado(WTerminado) Then
                                Throw New Exception("Debe especificarse el Producto Terminado en el talón " & WTalon)
                            End If

                            'If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
                            '    If Helper._ProdTerminadoValidoPtaI(WTerminado) Then
                            '        Throw New Exception("No se permite realizar inventario de este Producto Terminado en Planta I.")
                            '    End If
                            'End If

                        Case Else
                            Exit Sub
                    End Select

                    If Val(WCantidad) = 0 Then
                        Throw New Exception("Debe especificarse el la cantidad del Producto en el talón " & WTalon)
                    End If

                    If WTipo = "M" Then

                        If Not _ExisteLaudo(WArticulo, WLote) Then
                            Throw New Exception("Debe especificarse un Lote válido para el Articulo en el talón " & WTalon)
                        End If

                    ElseIf WTipo = "T" Then

                        If Not _ExisteHoja(WTerminado, WLote) Then
                            Throw New Exception("Debe especificarse un Lote válido para el Producto Terminado en el talón " & WTalon)
                        End If

                        If _CantidadSuperaTotalOriginal(WTerminado, WLote, WCantidad) Then
                            Throw New Exception("La cantidad ingresada supera a la cantidad registrada en la Hoja del Producto indicado en el Talón " & WTalon & " .")
                        End If

                    End If

                    WUbicacion = Trim(WUbicacion)
                    WObservaciones = Trim(WObservaciones)
                    WCantidad = Helper.formatonumerico(WCantidad)

                    '
                    ' Ya validado los valores, guardamos la fila.
                    '
                    WRenglon += 1

                    Dim WClave = ""

                    WClave = txtNroMovimiento.Text.Trim.PadLeft(6, "0") & WRenglon.ToString.PadLeft(2, "0")

                    Dim ZSQL = ""

                    ZSQL = String.Format("INSERT INTO Inventario (Clave, Numero, Renglon, Tipo, Articulo, Terminado, Cantidad, Lote, Talon, Observaciones, Ubicacion, Partida)" &
                                         " VALUES " &
                                         " ('{0}', {1}, {2}, '{3}', '{4}', '{5}', {6}, {7}, {8}, '{9}', '{10}', '{11}')",
                                         WClave, txtNroMovimiento.Text, WRenglon, WTipo, WArticulo, WTerminado, WCantidad, WLote, WTalon, WObservaciones, WUbicacion, WPartida)
                    cm.CommandText = ZSQL
                    cm.ExecuteNonQuery()

                End With

            Next

            trans.Commit()

            btnLimpiar.PerformClick()

        Catch ex As Exception

            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            MsgBox("Hubo un problema al querer guardar el Movimiento en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ExisteHoja(ByVal wTerminado As String, ByVal wLote As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Hoja FROM Hoja WHERE Hoja = '" & wLote & "' AND Producto = '" & wTerminado & "' ")
        Dim dr As SqlDataReader

        Try

            For Each emp As String In Conexion.Empresas

                If cn.IsOpened Then cn.Close()

                cn.ConnectionString = Helper._ConectarA(emp)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Next

            Return False

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Laudo " & wLote & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Function _ExisteLaudo(ByVal wArticulo As String, ByVal wLote As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Laudo FROM Laudo WHERE Laudo = '" & wLote & "' AND Articulo = '" & wArticulo & "' ")
        Dim dr As SqlDataReader

        Try

            For Each emp As String In Conexion.Empresas

                If cn.IsOpened Then cn.Close()

                cn.ConnectionString = Helper._ConectarA(emp)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Next

            Return False

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Laudo " & wLote & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _ExisteTerminado(ByVal wTerminado As String) As Boolean

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
            Throw New Exception("Hubo un problema al querer consultar la existencia del Terminado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _ExisteArticulo(ByVal wArticulo As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Articulo WHERE Codigo = '" & wArticulo & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Articulo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function




    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back, Keys.Back, Keys.Delete
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

        With dgvTalones
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = If(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.

                Select Case iCol
                    Case 0, 5
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case 1

                        Select Case keyData
                            Case Keys.T, Keys.M, Keys.Enter, Keys.Escape, Keys.Back, Keys.Delete, Keys.Left, Keys.Right, Keys.Up, Keys.Down

                            Case Else
                                Return True
                        End Select

                    Case 6
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    '
                    ' Procesamos el Valor.
                    '

                    Select Case iCol
                        Case 0
                            If Val(valor) = 0 Then Return True

                        Case 1
                            If valor.Trim = "" Then Return True
                            .CurrentCell.Value = valor.ToString.ToUpper

                            If valor.Trim.ToUpper = "T" Then
                                .CurrentRow.Cells("Terminado").ReadOnly = False
                                .CurrentRow.Cells("Articulo").ReadOnly = True
                                .CurrentCell = .CurrentRow.Cells("Terminado")
                            ElseIf valor.Trim.ToUpper = "M" Then
                                .CurrentRow.Cells("Terminado").ReadOnly = True
                                .CurrentRow.Cells("Articulo").ReadOnly = False
                            Else
                                Return True
                            End If

                        Case 5
                            If Val(valor) = 0 Then Return True

                            Dim WTipo As String = If(.CurrentRow.Cells("Tipo").Value, "")
                            Dim WArticulo As String = If(.CurrentRow.Cells("Articulo").Value, "")
                            Dim WTerminado As String = If(.CurrentRow.Cells("Terminado").Value, "")

                            If UCase(WTipo) = "M" Then
                                If Not _ExisteLaudo(WArticulo, valor) Then
                                    MsgBox("El Lote ingresado no se corresponde con el Producto que informo anteriormente.")
                                    Return True
                                End If
                            Else
                                If Not _ExisteHoja(WTerminado, valor) Then
                                    MsgBox("El Lote ingresado no se corresponde con el Producto que informo anteriormente.")
                                    Return True
                                End If
                            End If

                        Case 6
                            If Val(valor) = 0 Then Return True
                            Dim WTipo As String = If(.CurrentRow.Cells("Tipo").Value, "")

                            If WTipo = "T" Then

                                Dim WTerminado As String = If(.CurrentRow.Cells("Terminado").Value, "")
                                Dim WLote As String = If(.CurrentRow.Cells("Lote").Value, "")

                                If _CantidadSuperaTotalOriginal(WTerminado, WLote, valor) Then
                                    MsgBox("La cantidad ingresada supera a la cantidad registrada en la Hoja del Producto indicada.")
                                    Return True
                                End If

                            End If
                            .CurrentCell.Value = Helper.formatonumerico(valor)

                    End Select


                    '
                    '
                    '
                    Select Case iCol
                        Case 8

                            If iRow = .Rows.Count - 1 Then
                                .CurrentCell = .Rows(.Rows.Add).Cells("Talon")
                            Else
                                .CurrentCell = .Rows(iRow + 1).Cells("Talon")
                            End If
                        Case 1

                            If valor.Trim.ToUpper = "T" Then
                                .CurrentCell = .CurrentRow.Cells("Terminado")
                            ElseIf valor.Trim.ToUpper = "M" Then
                                .CurrentCell = .CurrentRow.Cells("Articulo")
                            Else
                                Return True
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = .Columns("Observaciones").Index Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                    .Focus()
                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _CantidadSuperaTotalOriginal(ByVal wTerminado As String, ByVal wLote As String, ByVal valor As Object) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Real, RealAnt FROM Hoja WHERE Hoja = '" & wLote & "' AND Producto = '" & wTerminado & "' AND Renglon = '1'")
        Dim dr As SqlDataReader

        Try

            For Each emp As String In Conexion.Empresas

                If cn.IsOpened Then cn.Close()

                cn.ConnectionString = Helper._ConectarA(emp)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    '
                    ' Verificamos si tiene alguna marca. En caso de que si, se lo considera que ya fue inventariado anteriormente.
                    '
                    Dim WCantidadOrig As Double = 0
                    Dim WCantidadOrigI As Double = 0
                    Dim WCantidadOrigII As Double = 0

                    WCantidadOrigII = IIf(IsDBNull(dr.Item("RealAnt")), 0, dr.Item("RealAnt"))
                    WCantidadOrigI = IIf(IsDBNull(dr.Item("Real")), 0, dr.Item("Real"))

                    WCantidadOrig = WCantidadOrigI

                    If WCantidadOrigII <> 0 Then
                        WCantidadOrig = WCantidadOrigII
                    End If

                    WCantidadOrig = Val(Helper.formatonumerico(WCantidadOrig))
                    valor = Val(Helper.formatonumerico(valor))

                    Return valor > WCantidadOrig

                End If

            Next

            Return False

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer corroborar la cantidad de producto original del Laudo " & wLote & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Sub txtArticuloAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticuloAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtArticuloAux.Text.Replace("-", "")) = "" Or Trim(txtArticuloAux.Text.Replace(" ", "")).Length < 10 Then : Exit Sub : End If

            'If Helper._ValidarFecha(Trim(txtTerminadoAux.Text)) And WRow >= 0 And Wcol >= 0 Then

            If Not _ExisteArticulo(txtArticuloAux.Text) Then Exit Sub

            'If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
            '    If Helper._MateriaPrimaValidaPtaI(txtArticuloAux.Text) Then
            '        MsgBox("No se permite realizar inventario de esta Materia Prima en Planta I.")
            '        Exit Sub
            '    End If
            'End If

            With dgvTalones
                .Rows(WRow).Cells("Articulo").Value = txtArticuloAux.Text.ToUpper
                .Rows(WRow).Cells("Descripcion").Value = _TraerDescripcionArticulo(txtArticuloAux.Text)

                .CurrentCell = .Rows(WRow).Cells("Lote")
                .Focus()

                txtArticuloAux.Visible = False
                txtArticuloAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
            End With

            'End If

        ElseIf e.KeyData = Keys.Escape Then
            txtArticuloAux.Text = ""
        End If

    End Sub

    Private Function _TraerDescripcionArticulo(ByVal s As String) As Object

        Dim WDesc = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Articulo WHERE Codigo = '" & s & "'")
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
            Throw New Exception("Hubo un problema al querer consultar la descripción del Artículo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc.Trim

    End Function

    Private Function _TraerDescripcionTerminado(ByVal s As String) As Object

        Dim WDesc = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Terminado WHERE Codigo = '" & s & "'")
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
            Throw New Exception("Hubo un problema al querer consultar la descripción del Producto Terminado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDesc.Trim

    End Function

    Private Sub txtCodigo2_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTalones.CellEnter
        With dgvTalones
            If e.ColumnIndex = .Rows(e.RowIndex).Cells("Articulo").ColumnIndex Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                _location.Y += .Location.Y + YMARGEN
                _location.X += .Location.X + XMARGEN
                txtArticuloAux.Location = _location
                txtArticuloAux.Text = .Rows(e.RowIndex).Cells("Articulo").Value
                txtArticuloAux.Text = txtArticuloAux.Text.Replace("-", "").Trim
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                Dim s As Size = .CurrentCell.Size
                s.Width -= XMARGEN * 2
                txtArticuloAux.Size = s
                txtArticuloAux.Visible = True
                txtArticuloAux.Focus()
            End If
        End With
    End Sub

    Private Sub txtTerminadoAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTerminadoAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtTerminadoAux.Text.Replace("-", "")) = "" Or Trim(txtTerminadoAux.Text.Replace(" ", "")).Length < 12 Then : Exit Sub : End If

            'If Helper._ValidarFecha(Trim(txtTerminadoAux.Text)) And WRow >= 0 And Wcol >= 0 Then

            If Not _ExisteTerminado(txtTerminadoAux.Text) Then Exit Sub

            'If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
            '    If Helper._ProdTerminadoValidoPtaI(txtTerminadoAux.Text) Then
            '        MsgBox("No se permite realizar inventario de este Producto Terminado en Planta I.")
            '        Exit Sub
            '    End If
            'End If

            With dgvTalones
                .Rows(WRow).Cells("Terminado").Value = txtTerminadoAux.Text.ToUpper
                .Rows(WRow).Cells("Descripcion").Value = _TraerDescripcionTerminado(txtTerminadoAux.Text)

                .CurrentCell = .Rows(WRow).Cells("Lote")
                .Focus()

                txtTerminadoAux.Visible = False
                txtTerminadoAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
            End With

            'End If

        ElseIf e.KeyData = Keys.Escape Then
            txtTerminadoAux.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTalones.CellEnter
        With dgvTalones
            If e.ColumnIndex = .Rows(e.RowIndex).Cells("Terminado").ColumnIndex Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                _location.Y += .Location.Y + YMARGEN
                _location.X += .Location.X + XMARGEN
                txtTerminadoAux.Location = _location
                txtTerminadoAux.Text = .Rows(e.RowIndex).Cells("Terminado").Value
                txtTerminadoAux.Text = txtTerminadoAux.Text.Replace("-", "").Trim
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                Dim s As Size = .CurrentCell.Size
                s.Width -= XMARGEN * 2
                txtTerminadoAux.Size = s
                txtTerminadoAux.Visible = True
                txtTerminadoAux.Focus()
            End If
        End With
    End Sub

End Class