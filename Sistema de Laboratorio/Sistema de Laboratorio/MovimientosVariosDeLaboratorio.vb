Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Text

Public Class MovimientosVariosDeLaboratorio


    Private Sub cbxMP_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMP.DropDownClosed
        If cbxMP.SelectedIndex = 0 Then
            mastxtCodigo.Text = ""
            mastxtCodigo.BackColor = SystemColors.Window
            Label6.Text = "Materia Prima"
            mastxtCodigo.Mask = ">LL-000-000"
            mastxtCodigo.Focus()
        End If
        If cbxMP.SelectedIndex = 1 Then
            mastxtCodigo.Text = ""
            mastxtCodigo.BackColor = SystemColors.Window
            Label6.Text = "Producto Terminado"
            mastxtCodigo.Mask = ">LL-00000-000"
            mastxtCodigo.Focus()
        End If
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub cbxMP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxMP.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If cbxMP.Text = "M" Then
                    Label6.Text = "Materia Prima"
                    mastxtCodigo.Mask = ">LL-000-000"
                    mastxtCodigo.BackColor = SystemColors.Window
                    mastxtCodigo.Enabled = True
                    mastxtCodigo.Focus()
                Else
                    Label6.Text = "Producto Terminado"
                    mastxtCodigo.Mask = ">LL-00000-000"
                    mastxtCodigo.BackColor = SystemColors.Window
                    mastxtCodigo.Enabled = True
                    mastxtCodigo.Focus()
                End If
        End Select
    End Sub

    Private Sub MovimientosVariosDeLaboratorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ""
        pnlContra.Visible = False
        pnlAyuda.Visible = False
        txtNroMovimiento.Text = 0
        mastxtFecha.Text = Date.Today
        cbxTipoMovimiento.SelectedIndex = 1
        cbxMP.SelectedIndex = 0
        cbxMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        cbxAyuda.SelectedIndex = 0
        cbxTipoMovimiento_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Function _BuscarCodigoMax() As String
        Dim SQLCnslt As String = "SELECT Codigo = Max(Codigo) From Movlab"
        Dim Row As DataRow = GetSingle(SQLCnslt)
        Return Row.Item("Codigo")
    End Function

    Private Sub MovimientosVariosDeLaboratorio_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtObservaciones.Focus()
    End Sub

    Private Sub cbxTipoMovimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxTipoMovimiento.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If cbxTipoMovimiento.Text = "Entrada" Then
                    txtES.Text = "E"
                Else
                    txtES.Text = "S"
                End If
                txtObservaciones.Focus()
        End Select
    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                mastxtCodigo.Focus()
        End Select
    End Sub

    Private Sub mastxtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If cbxMP.Text = "M" Then
                    If mastxtCodigo.Text.Trim().Length = 10 Then
                        txtDescripcion.Text = _BuscarArticuloPT()
                        If txtDescripcion.Text <> "" Then
                            txtCantidad.Focus()
                        Else
                            mastxtCodigo.Focus()
                        End If
                    End If
                End If
                If cbxMP.Text = "T" Then
                    If mastxtCodigo.Text.Trim().Length = 12 Then
                        txtDescripcion.Text = _BuscarArticuloPT()
                        If txtDescripcion.Text <> "" Then
                            txtCantidad.Focus()
                        Else
                            mastxtCodigo.Focus()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtCantidad.Text <> "" Then
                    If txtCantidad.Text > 0 Then
                        txtCantidad.Text = formatonumerico(txtCantidad.Text)
                        txtLote.Focus()
                    End If
                End If

        End Select
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress, mastxtFecha.KeyPress, txtNroMovimiento.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Function _BuscarArticuloPT() As String
        Dim SQLCnslt As String
        If cbxMP.Text = "M" Then
            SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & mastxtCodigo.Text & "'"
        Else
            SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtCodigo.Text & "'"
        End If

        Dim row As DataRow = GetSingle(SQLCnslt)
        If row IsNot Nothing Then
            Return row.Item("Descripcion")
        Else
            Return ""
        End If

    End Function

    Private Sub cbxTipoMovimiento_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTipoMovimiento.DropDownClosed
        If cbxTipoMovimiento.Text = "Entrada" Then
            txtES.Text = "E"
        Else
            txtES.Text = "S"
        End If
    End Sub

    Private Sub txtLote_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLote.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If txtNroMovimiento.Text <> "" And mastxtFecha.Text.Replace("/", "").Trim <> "" And txtDescripcion.Text <> "" Then
                    If txtCantidad.Text <> "" And Val(txtCantidad.Text) > "0" Then
                        If txtLote.Text <> "" Then
                            If txtES.Text = "S" Then
                                Dim stockActual As String = _ConsultarStock(txtLote.Text, cbxMP.Text)
                                If stockActual <> "" AndAlso stockActual >= txtCantidad.Text Then
                                    _AgregarFila()
                                    _LimpiarAndPosition()
                                Else
                                    If stockActual = "" Then
                                        MsgBox("Laudo/Hoja inexistente")
                                    Else
                                        MsgBox("Saldo insuficiente para descontar esa cantidad. Saldo Actual: " & stockActual)
                                    End If

                                End If
                            Else
                                _AgregarFila()
                                _LimpiarAndPosition()

                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Function _ConsultarStock(ByVal Lote As String, ByVal tipo As String) As String
        Dim SQLCnslt As String
        If cbxMP.Text = "M" Then
            SQLCnslt = "SELECT Saldo FROM Laudo WHERE Laudo = '" & Lote & "' AND Renglon = 1"
        Else
            SQLCnslt = "SELECT Saldo FROM Hoja WHERE hoja = '" & Lote & "' AND Renglon = 1"
        End If

        Dim Row As DataRow = GetSingle(SQLCnslt)
        If Row IsNot Nothing Then
            Return Row.Item("Saldo")
        End If
        Return ""

    End Function

    Private Sub _LimpiarAndPosition()
        mastxtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtCantidad.Text = ""
        txtLote.Text = ""
        mastxtCodigo.Focus()
    End Sub

    Private Sub _AgregarFila()
        DGV_Movimientos.Rows.Add()
        DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("Tipo").Value = cbxMP.Text
        If cbxMP.Text = "T" Then
            DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("ProdTerminado").Value = mastxtCodigo.Text
        Else
            DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("ProdTerminado").Value = "  -     -   "

        End If
        If cbxMP.Text = "M" Then
            DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("MateriaPrima").Value = mastxtCodigo.Text
        Else
            DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("MateriaPrima").Value = "  -   -   "
        End If
        DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("Descripcion").Value = txtDescripcion.Text
        DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("Cantidad").Value = txtCantidad.Text
        DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("Movimiento").Value = txtES.Text
        DGV_Movimientos.Rows(DGV_Movimientos.Rows.Count - 1).Cells("Lote").Value = txtLote.Text
    End Sub


    Private Sub cbxTipoMovimiento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTipoMovimiento.Leave
        If cbxTipoMovimiento.Text = "Entrada" Then
            txtES.Text = "E"
        Else
            txtES.Text = "S"
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Val(txtNroMovimiento.Text) = 0 Then
            If ValidaFecha(mastxtFecha.Text) = "S" Then
                pnlContra.Visible = True
                txtContrasena.Focus()
            Else
                MsgBox("La fecha es invalida, verifique que sea una fecha real")
                mastxtFecha.Focus()
            End If


        Else
            If DGV_Movimientos.Rows.Count > 0 Then
                MsgBox("El Nro. Movimiento debe ser valor 0 para poder grabar")
            End If
        End If


    End Sub

    Private Sub txtContrasena_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContrasena.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If UCase(txtContrasena.Text) = "AUTORIZO" Then
                    If DGV_Movimientos.Rows.Count > 0 Then
                        _GrabarMovimientos()
                    End If
                Else
                    txtContrasena.Text = ""
                End If
        End Select
    End Sub

    Private Sub btnpnlVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpnlVolver.Click
        pnlContra.Visible = False
        txtContrasena.Text = ""
    End Sub

    Private Sub _GrabarMovimientos()

        Dim SQLCnslt As String
        Dim listaSQLCnslt As New List(Of String)
        Dim Controla As String = "0"
        Dim Codigo, WDate As String
        Dim Entradas, Salidas As String
        Dim Clave, Saldo As String
        Dim Renglon As Integer = 0

        txtNroMovimiento.Text = Val(_BuscarCodigoMax()) + 1

        For Each DGC_Row As DataGridViewRow In DGV_Movimientos.Rows
            With DGC_Row


                WDate = Date.Now.ToString("MM-dd-yyyy")

                Select Case .Cells("Tipo").Value
                    Case "M"
                        SQLCnslt = "SELECT Controla, Entradas, Salidas FROM Articulo WHERE Codigo = '" & .Cells("MateriaPrima").Value & "'"
                        Dim datarow As DataRow = GetSingle(SQLCnslt)
                        If datarow IsNot Nothing Then
                            Controla = IIf(IsDBNull(datarow.Item("Controla")), "0", datarow.Item("Controla"))
                            Codigo = .Cells("MateriaPrima").Value
                            If .Cells("Movimiento").Value = "E" Then
                                Entradas = formatonumerico(datarow.Item("Entradas") + Val(.Cells("Cantidad").Value))
                                Salidas = formatonumerico(datarow.Item("Salidas"))
                            Else
                                Salidas = formatonumerico(datarow.Item("Salidas") + Val(.Cells("Cantidad").Value))
                                Entradas = formatonumerico(datarow.Item("Entradas"))
                            End If


                            SQLCnslt = "UPDATE Articulo SET Entradas = '" & Entradas & "',Salidas = '" & Salidas & "',Wdate = '" & WDate & "' WHERE Codigo = '" & Codigo & "'"


                            listaSQLCnslt.Add(SQLCnslt)


                            If Controla = 0 And Val(.Cells("Lote").Value) <> 0 Then

                                SQLCnslt = "SELECT Clave, Saldo FROM Laudo WHERE Articulo = '" & .Cells("MateriaPrima").Value & "' AND Laudo = '" & .Cells("Lote").Value & "'"
                                datarow = GetSingle(SQLCnslt)

                                If datarow IsNot Nothing Then
                                    Clave = datarow.Item("Clave")
                                    If .Cells("Movimiento").Value = "E" Then
                                        Saldo = formatonumerico(datarow.Item("Saldo") + Val(.Cells("Cantidad").Value))
                                    Else
                                        Saldo = formatonumerico(datarow.Item("Saldo") - Val(.Cells("Cantidad").Value))
                                    End If

                                    SQLCnslt = "UPDATE Laudo SET Wdate = '" & WDate & "', Saldo = '" & Saldo & "' WHERE Clave = '" & Clave & "'"

                                    listaSQLCnslt.Add(SQLCnslt)
                                End If



                            Else
                                SQLCnslt = "SELECT Clave, Saldo FROM Guia WHERE Articulo = '" & .Cells("MateriaPrima").Value & "' AND Laudo = '" & .Cells("Lote").Value & "' AND Saldo > 0"
                                datarow = GetSingle(SQLCnslt)
                                If datarow IsNot Nothing Then
                                    Clave = datarow.Item("Clave")
                                    If .Cells("Mobimiento").Value = "E" Then
                                        Saldo = formatonumerico(datarow.Item("Saldo") + Val(.Cells("Cantidad").Value))
                                    Else
                                        Saldo = formatonumerico(datarow.Item("Saldo") - Val(.Cells("Cantidad").Value))
                                    End If

                                    SQLCnslt = "UPDATE Guia SET Wdate= '" & WDate & "' , Saldo = '" & Saldo & "') WHERE Clave = '" & Clave & "'"

                                    listaSQLCnslt.Add(SQLCnslt)

                                End If
                            End If
                        End If
                    Case "T"
                        Controla = "0"

                        SQLCnslt = "SELECT Controla, Entradas, Salidas FROM Terminado WHERE Codigo = '" & .Cells("ProdTerminado").Value & "'"
                        Dim DataRow As DataRow = GetSingle(SQLCnslt)

                        If DataRow IsNot Nothing Then
                            Controla = IIf(IsDBNull(DataRow.Item("Controla")), "0", DataRow.Item("Controla"))
                            If .Cells("Movimiento").Value = "E" Then

                                Entradas = formatonumerico(DataRow.Item("Entradas") + Val(.Cells("Cantidad").Value))
                                Salidas = formatonumerico(DataRow.Item("Salidas"))

                            Else

                                Salidas = formatonumerico(DataRow.Item("Salidas") + Val(.Cells("Cantidad").Value))
                                Entradas = formatonumerico(DataRow.Item("Entradas"))

                            End If

                            SQLCnslt = "UPDATE Terminado SET Entradas = '" & Entradas & "', Salidas = '" & Salidas & "', Wdate = '" & WDate & "' WHERE Codigo = '" & .Cells("ProdTerminado").Value & "'"
                            listaSQLCnslt.Add(SQLCnslt)

                            If Controla = 0 And Val(.Cells("Lote").Value) <> 0 Then

                                SQLCnslt = "SELECT Clave, Saldo FROM Hoja WHERE Producto = '" & .Cells("ProdTerminado").Value & "' AND Renglon = 1 AND Hoja = '" & .Cells("Lote").Value & "'"

                                DataRow = GetSingle(SQLCnslt)

                                If DataRow IsNot Nothing Then
                                    Clave = DataRow.Item("Clave")
                                    If .Cells("Movimiento").Value = "E" Then
                                        Saldo = formatonumerico((DataRow.Item("Saldo") + Val(.Cells("Cantidad").Value)))
                                    Else
                                        Saldo = formatonumerico((DataRow.Item("Saldo") - Val(.Cells("Cantidad").Value)))
                                    End If

                                    SQLCnslt = "UPDATE Hoja SET Wdate = '" & WDate & "', Saldo = '" & Saldo & "' WHERE Clave = '" & Clave & "'"

                                    listaSQLCnslt.Add(SQLCnslt)
                                End If
                            Else
                                SQLCnslt = "SELECT Clave, Saldo FROM Guia WHERE Terminado = '" & .Cells("ProdTermiando").Value & "' AND Lote = '" & .Cells("Lote").Value & "' AND Saldo > 0"
                                DataRow = GetSingle(SQLCnslt)

                                If DataRow IsNot Nothing Then
                                    Clave = DataRow.Item("Clave")
                                    If .Cells("Movimiento").Value = "E" Then
                                        Saldo = formatonumerico((DataRow.Item("Saldo") + Val(.Cells("Cantidad").Value)))
                                    Else
                                        Saldo = formatonumerico((DataRow.Item("Saldo") - Val(.Cells("Cantidad").Value)))
                                    End If
                                    SQLCnslt = "UPDATE Guia SET Wdate = '" & WDate & "', Saldo = '" & Saldo & "' WHERE Clave = '" & Clave & "'"
                                    listaSQLCnslt.Add(SQLCnslt)
                                End If
                            End If
                        End If
                End Select


                Renglon += 1
                Dim RenglonConCeros As String = Renglon.ToString().PadLeft(2, "0")
                Dim NroMoviConCeros As String = txtNroMovimiento.Text.PadLeft(6, "0")
                Dim FechaOrd As String = ordenaFecha(mastxtFecha.Text)
                Dim TipoMov As String = cbxTipoMovimiento.SelectedIndex
                Clave = NroMoviConCeros & RenglonConCeros
                Dim Marca As String = ""

                SQLCnslt = "INSERT INTO Movlab (Clave, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, Tipomov, Observaciones, Wdate, Marca, Lote) "
                SQLCnslt = SQLCnslt & "VALUES('" & Clave & "', '" & txtNroMovimiento.Text & "', '" & Renglon & "', '" & mastxtFecha.Text & "', '" & .Cells("Tipo").Value & "', "
                SQLCnslt = SQLCnslt & "'" & .Cells("MateriaPrima").Value & "', '" & .Cells("ProdTerminado").Value & "', '" & .Cells("Cantidad").Value & "', '" & FechaOrd & "', "
                SQLCnslt = SQLCnslt & "'" & .Cells("Movimiento").Value & "', '" & TipoMov & "', '" & txtObservaciones.Text & "', '" & WDate & "', '" & Marca & "', "
                SQLCnslt = SQLCnslt & "'" & .Cells("Lote").Value & "')"

                listaSQLCnslt.Add(SQLCnslt)

            End With
        Next

        ExecuteNonQueries(listaSQLCnslt.ToArray())

        _LimpiarForm()
        btnpnlVolver_Click(Nothing, Nothing)
    End Sub


    Private Sub txtNroMovimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroMovimiento.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtNroMovimiento.Text <> "" Then
                    If Val(txtNroMovimiento.Text) = 0 Then
                        mastxtFecha.Text = Date.Today
                        txtObservaciones.Focus()
                    Else
                        Dim SQLCnslt As String = "SELECT Fecha FROM Movlab WHERE Codigo = '" & txtNroMovimiento.Text & "'"
                        Dim Row As DataRow = GetSingle(SQLCnslt)
                        If Row IsNot Nothing Then
                            mastxtFecha.Text = Row.Item("Fecha")
                            Dim Codigo As String = txtNroMovimiento.Text
                            _LimpiarForm()
                            txtNroMovimiento.Text = Codigo
                            _ProcesoBusquedaMovVarios()
                        Else
                            Dim Codigo As String = txtNroMovimiento.Text
                            _LimpiarForm()
                            txtNroMovimiento.Text = Codigo
                        End If

                    End If
                    
                End If
        End Select
    End Sub

    Private Sub _LimpiarForm()
        txtNroMovimiento.Text = ""
        mastxtFecha.Text = ""
        txtObservaciones.Text = ""
        mastxtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtCantidad.Text = ""
        txtLote.Text = ""
        DGV_Movimientos.Rows.Clear()
        mastxtFecha.Text = Date.Today
        txtNroMovimiento.Text = 0
        txtNroMovimiento.Focus()
    End Sub

    Private Sub _ProcesoBusquedaMovVarios()
        Dim SQLCnslt As String = "SELECT Tipo, Terminado, Articulo, Cantidad, Movi, Lote, Observaciones, Fecha FROM Movlab WHERE Codigo = '" & txtNroMovimiento.Text & "' ORDER BY Renglon"
        Dim Descripcion As String
        Dim tabla As DataTable = GetAll(SQLCnslt)
        If tabla.Rows.Count > 0 Then
            mastxtFecha.Text = tabla.Rows(0).Item("Fecha")
            txtObservaciones.Text = tabla.Rows(0).Item("Observaciones")
            For Each row As DataRow In tabla.Rows
                With row
                    Descripcion = _BuscarDescripcion(.Item("Tipo"), .Item("Terminado"), .Item("Articulo"))
                    DGV_Movimientos.Rows.Add(.Item("Tipo"), .Item("Terminado"), .Item("Articulo"), Descripcion, .Item("Cantidad"), .Item("Movi"), .Item("Lote"))
                End With

            Next
        End If
    End Sub

    Private Function _BuscarDescripcion(ByVal Tipo As String, ByVal Terminado As String, ByVal Articulo As String) As String
        Dim SQLCnslt As String
        If Tipo = "M" Then
            SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Articulo & "'"
        Else
            SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & Terminado & "'"
        End If
        Dim row As DataRow = GetSingle(SQLCnslt)
        If row IsNot Nothing Then
            Return row.Item("Descripcion")
        Else
            Return ""
        End If

    End Function

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _LimpiarForm()
        txtNroMovimiento.Focus()
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then
                    txtObservaciones.Focus()
                Else
                    MsgBox("La fecha es invalida, verifique que sea una fecha real")
                    mastxtFecha.Focus()
                End If
        End Select
    End Sub

    Private Sub btnpnlAyudaVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpnlAyudaVolver.Click
        pnlAyuda.Visible = False
    End Sub

    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        pnlAyuda.Visible = True
        cbxAyuda.SelectedIndex = 0

        Dim SQLCnslt As String = "SELECT CodigoAyuda = Codigo, DescripcionAyuda = Descripcion FROM Articulo"

        Dim tabla As DataTable = GetAll(SQLCnslt)

        DGV_Ayuda.DataSource = tabla
    End Sub

    Private Sub cbxAyuda_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAyuda.DropDownClosed
        Dim SQLCnslt As String
        If cbxAyuda.SelectedIndex = 0 Then
            SQLCnslt = "SELECT CodigoAyuda = Codigo, DescripcionAyuda = Descripcion FROM Articulo"

        Else
            SQLCnslt = "SELECT CodigoAyuda = Codigo, DescripcionAyuda = Descripcion FROM Terminado"
        End If

        Dim tabla As DataTable = GetAll(SQLCnslt)

        DGV_Ayuda.DataSource = tabla

        txtAyuda.Text = ""

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAyuda.KeyUp
        Dim tabla As DataTable = TryCast(DGV_Ayuda.DataSource, DataTable)

        tabla.DefaultView.RowFilter = "CodigoAyuda LIKE '%" & txtAyuda.Text & "%' or DescripcionAyuda LIKE '%" & txtAyuda.Text & "%'"
        DGV_Ayuda.DataSource = tabla
    End Sub

   
    Private Sub DGV_Ayuda_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_Ayuda.CellMouseDoubleClick

        If cbxAyuda.SelectedIndex = 0 Then
            cbxMP.SelectedIndex = 0
            cbxMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Else
            cbxMP.SelectedIndex = 1
            cbxMP_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If
        mastxtCodigo.Text = DGV_Ayuda.CurrentRow.Cells("CodigoAyuda").Value

        pnlAyuda.Visible = False

        mastxtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))



    End Sub
End Class