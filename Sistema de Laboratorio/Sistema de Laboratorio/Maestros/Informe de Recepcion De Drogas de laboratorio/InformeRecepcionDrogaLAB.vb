Public Class InformeRecepcionDrogaLAB : Implements IBuscadorProveedor, IBuscarOrdenCompraXProvee

    Private Sub InformeRecepcionDrogaLAB_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtOrdenCompra.Focus()
    End Sub

    Private Sub InformeRecepcionDrogaLAB_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Text = ""
        PnlEstadoEnvases.Visible = False
        pnlAviso.Visible = False

        txtNroInforme.Text = 0
        mastxtFecha.Text = Date.Today
        txtOrdenCompra.Text = 0

        btnLimpiarForm_Click(Nothing, Nothing)

    End Sub

    Private Sub txtNroInforme_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNroInforme.KeyDown

        Dim SQLCnsl As String
        Dim Entra As String = "N"

        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtNroInforme.Text) <> 0 Then

                    SQLCnsl = "SELECT Fecha, Proveedor, Remito, Orden FROM Informe WHERE Informe = '" & txtNroInforme.Text & "' ORDER BY Renglon"
                    Dim tabla As DataTable = GetAll(SQLCnsl)
                    If tabla.Rows.Count > 0 Then
                        Entra = "S"
                        mastxtFecha.Text = tabla.Rows(0).Item("Fecha")
                        txtProveedor.Text = tabla.Rows(0).Item("Proveedor")
                        txtRemito.Text = tabla.Rows(0).Item("Remito")
                        txtOrdenCompra.Text = tabla.Rows(0).Item("Orden")
                    End If

                    If Entra = "S" Then
                        SQLCnsl = "SELECT Nombre FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'"
                        Dim row As DataRow = GetSingle(SQLCnsl)
                        If row IsNot Nothing Then
                            txtDescripcionProv.Text = row.Item("Nombre")
                        End If
                        _ProcesarInformesViejos()
                    Else
                        Dim Variable As String = txtNroInforme.Text
                        _LimpiarForm()
                        txtNroInforme.Text = Variable
                        txtNroInforme.Focus()
                    End If

                Else
                    _LimpiarForm()
                    txtNroInforme.Focus()
                End If

            Case Keys.Escape
                txtNroInforme.Text = ""
        End Select
    End Sub

    Private Sub _LimpiarRenglonDeModicacion()
        txtOrden.Text = ""
        mastxtMateriaPrima.Text = ""
        txtDescripcionMP.Text = ""
        txtCantIngre.Text = ""
        txtSaldoOC.Text = ""
        txtDescOC.Text = ""
        txtEnvase.Text = ""
        txtEtiqueta.Text = ""
    End Sub

    Private Sub _LimpiarForm()
        txtNroInforme.Text = ""
        mastxtFecha.Text = ""
        txtProveedor.Text = ""
        txtDescripcionProv.Text = ""
        txtOrdenCompra.Text = ""
        txtRemito.Text = ""

        DGV_InformeRecepcion.Rows.Clear()

        txtNroInforme.Text = 0
        mastxtFecha.Text = Date.Today
        txtOrdenCompra.Text = 0

        _LimpiarRenglonDeModicacion()

        btnGrabar.Enabled = True
        txtOrdenCompra.Focus()
    End Sub

    Private Sub _ProcesarInformesViejos()
        DGV_InformeRecepcion.Rows.Clear()
        Dim vuelta As Integer = -1
        Dim SQLCnslt As String

        SQLCnslt = "SELECT * FROM Informe WHERE Informe = '" & txtNroInforme.Text & "' ORDER BY Renglon"

        Dim tabla As DataTable = GetAll(SQLCnslt)

        If tabla.Rows.Count > 0 Then
            For Each Row As DataRow In tabla.Rows
                vuelta = DGV_InformeRecepcion.Rows.Add()

                With DGV_InformeRecepcion.Rows(vuelta)

                    .Cells("Orden").Value = Row.Item("Orden")
                    .Cells("Producto").Value = Row.Item("Articulo")
                    .Cells("CantIngre").Value = Row.Item("Cantidad")
                    .Cells("DescOC").Value = Row.Item("Resta")
                    .Cells("Envase").Value = Row.Item("Envase")

                    .Cells("Certificado1").Value = Val(OrDefault(Row.Item("Certificado1"), "0")) > 0

                    .Cells("Certificado2").Value = OrDefault(Row.Item("Certificado2"), "")

                    .Cells("Estado1").Value = Val(OrDefault(Row.Item("Estado1"), "0")) > 0

                    .Cells("Estado2").Value = OrDefault(Row.Item("Estado2"), "")
                    .Cells("FechaVencimiento").Value = OrDefault(Row.Item("Fechavencimiento"), "  /  /    ")
                    .Cells("EstadoEnvI").Value = OrDefault(Row.Item("EstadoEnvI"), False)
                    .Cells("ObservaI").Value = Trim(OrDefault(Row.Item("ObservaI"), "")) & " " & Trim(OrDefault(Row.Item("ObservaII"), ""))
                    .Cells("EstadoEnvIII").Value = OrDefault(Row.Item("EstadoEnvIII"), False)
                    .Cells("ObservaIII").Value = Trim(OrDefault(Row.Item("ObservaIII"), "")) & " " & Trim(OrDefault(Row.Item("ObservaIV"), ""))
                    .Cells("EstadoEnvV").Value = OrDefault(Row.Item("EstadoEnvV"), False)
                    .Cells("EstadoEnvVII").Value = OrDefault(Row.Item("EstadoEnvVII"), False)
                    .Cells("EstadoEnvIX").Value = OrDefault(Row.Item("EstadoEnvIX"), False)
                    .Cells("CantidadEnv").Value = OrDefault(Row.Item("CantidadEnv"), "0")

                    SQLCnslt = "SELECT Descripcion FROM Envases WHERE Envases = '" & Row.Item("Envase") & "'"

                    Dim RowEnvases As DataRow = GetSingle(SQLCnslt)

                    If RowEnvases IsNot Nothing Then .Cells("DescripcionEnvase").Value = OrDefault(RowEnvases.Item("Descripcion"), "")

                    .Cells("Descripcion").Value = ""

                    SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Row.Item("Articulo") & "'"
                    Dim rowArticulo As DataRow = GetSingle(SQLCnslt)

                    If rowArticulo IsNot Nothing Then .Cells("Descripcion").Value = rowArticulo.Item("Descripcion")

                End With
            Next
        End If
    End Sub

    Sub _ModificarDatosGRilla()

        Dim row As DataGridViewRow = DGV_InformeRecepcion.Rows.Cast(Of DataGridViewRow).ToList.First(Function(r) r.Cells("Producto").Value = mastxtMateriaPrima.Text)

        If row IsNot Nothing Then
            row.Cells("CantIngre").Value = txtCantIngre.Text
            row.Cells("DescOC").Value = txtDescOC.Text
            row.Cells("Envase").Value = txtEnvase.Text
            row.Cells("Etiqueta").Value = txtEtiqueta.Text
        End If

        txtOrden.Text = ""
        mastxtMateriaPrima.Text = ""
        txtDescripcionMP.Text = ""
        txtCantIngre.Text = ""
        txtSaldoOC.Text = ""
        txtDescOC.Text = ""
        txtEnvase.Text = ""
        txtEtiqueta.Text = ""
        txtDescOC.Enabled = True

    End Sub

    Private Sub DGV_InformeRecepcion_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV_InformeRecepcion.CellDoubleClick
        'Renglon abajo de la grilla
        txtOrden.Text = DGV_InformeRecepcion.CurrentRow.Cells("Orden").Value
        mastxtMateriaPrima.Text = DGV_InformeRecepcion.CurrentRow.Cells("Producto").Value
        txtDescripcionMP.Text = DGV_InformeRecepcion.CurrentRow.Cells("Descripcion").Value
        txtCantIngre.Text = DGV_InformeRecepcion.CurrentRow.Cells("CantIngre").Value
        txtSaldoOC.Text = DGV_InformeRecepcion.CurrentRow.Cells("SaldoOC").Value
        txtDescOC.Text = DGV_InformeRecepcion.CurrentRow.Cells("DescOC").Value
        txtEnvase.Text = DGV_InformeRecepcion.CurrentRow.Cells("Envase").Value

        'Panel grande

        With DGV_InformeRecepcion.CurrentRow
            If .Cells("EstadoEnvI").Value = True Then
                rabtnCum_CertifAnalisis.Checked = True
            Else
                rabtnNOCum_CertifAnalisis.Checked = True
            End If

            txtCertifAnalisis.Text = .Cells("ObservaI").Value
            If .Cells("EstadoEnvIII").Value = True Then
                rabtnCum_EstadoEnvases1.Checked = True
            Else
                rabtnNOCum_EstadoEnvases1.Checked = True
            End If

            txtEstadoEnvases1.Text = .Cells("ObservaIII").Value
            If .Cells("EstadoEnvV").Value = True Then
                rabtnCum_EstadoEnvases2.Checked = True
            Else
                rabtnNOCum_EstadoEnvases2.Checked = True
            End If

            If .Cells("EstadoEnvVII").Value = True Then
                rabtnCum_EstadoEnvases3.Checked = True
            Else
                rabtnNOCum_EstadoEnvases3.Checked = True
            End If

            If .Cells("EstadoEnvIX").Value = True Then
                rabtnCum_EstadoEnvases4.Checked = True
            Else
                rabtnNOCum_EstadoEnvases4.Checked = True
            End If

            txtCantRechazada.Text = .Cells("CantidadEnv").Value
        End With

        txtCantIngre.Focus()

        _CargarLebels()

    End Sub

    Sub _CargarLebels()

        Dim SQLCnslt As String

        Dim Ensayo1 As String = "0"
        Dim Ensayo2 As String = "0"
        Dim Ensayo3 As String = "0"
        Dim Ensayo4 As String = "0"

        lblCertifAnalisis.Text = ""
        lblEstadoEnvases1.Text = ""
        lblEstadoEnvases2.Text = ""
        lblEstadoEnvases3.Text = ""
        lblEstadoEnvases4.Text = ""

        SQLCnslt = "SELECT Ensayo1, Ensayo2, Ensayo3, Ensayo4, Ensayo5 FROM EspecificacionesUnifica WHERE Producto = '" & mastxtMateriaPrima.Text & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then
            Ensayo1 = Str$(row.Item("Ensayo1"))
            Ensayo2 = Str$(row.Item("Ensayo2"))
            Ensayo3 = Str$(row.Item("Ensayo3"))
            Ensayo4 = Str$(row.Item("Ensayo4"))
        End If

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo1 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then lblEstadoEnvases1.Text = row.Item("Descripcion")

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo2 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then lblEstadoEnvases2.Text = row.Item("Descripcion")

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo3 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then lblEstadoEnvases3.Text = row.Item("Descripcion")

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo4 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then lblEstadoEnvases4.Text = row.Item("Descripcion")

    End Sub

    Private Sub btnAceptar_pnlAviso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar_pnlAviso.Click
        pnlAviso.Visible = False
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtOrdenCompra.KeyPress, txtRemito.KeyPress, txtProveedor.KeyPress, txtNroInforme.KeyPress, txtEtiqueta.KeyPress, txtEnvase.KeyPress, mastxtFecha.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCantIngre.KeyPress, txtDescOC.KeyPress, txtCantRechazada.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOrdenCompra_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtOrdenCompra.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If Val(txtOrdenCompra.Text) = 0 Then
                    txtProveedor.Focus()
                Else
                    Dim TipoOrden As Integer
                    Dim SQLCnslt As String = "SELECT Tipo FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "'"
                    Dim roworden As DataRow = GetSingle(SQLCnslt)
                    If roworden IsNot Nothing Then
                        TipoOrden = roworden.Item("Tipo")
                    End If
                    Dim auxiliar As String = txtOrdenCompra.Text
                    _LimpiarForm()
                    txtOrdenCompra.Text = auxiliar
                    If TipoOrden = 4 Or TipoOrden = 3 Then
                        txtNroInforme.Text = 0
                        _LimpiarRenglonDeModicacion()
                        txtRemito.Text = ""
                        _ProcesoLLenarGrilla()
                        If _BuscarRepetidos() <> "" Then
                            btnGrabar.Enabled = False
                            MsgBox("No se podra grabar un informe, ya que hay Articulos repetidos en la orden de compra")
                        End If
                    Else
                        Exit Sub 'sino es orden de drogas de lab termina el proceso
                    End If
                End If
            Case Keys.Escape
                txtOrdenCompra.Text = ""
        End Select
    End Sub

    Private Function _BuscarRepetidos() As String
        Dim PosicionActual As Integer = 0
        Dim CodigoActual As String
        For i As Integer = 0 To DGV_InformeRecepcion.Rows.Count - 1
            With DGV_InformeRecepcion
                CodigoActual = .Rows(i).Cells("Producto").Value
                PosicionActual = i
                For j As Integer = 0 To .Rows.Count - 1
                    If PosicionActual = j Then
                        Continue For
                    End If
                    If CodigoActual = .Rows(j).Cells("Producto").Value Then
                        Return "SE REPITEN"
                    End If
                Next
            End With
        Next

        Return ""

    End Function

    Private Sub _ProcesoLLenarGrilla()

        If Val(txtOrdenCompra.Text) <> 0 Then

            DGV_InformeRecepcion.Rows.Clear()

            Dim Renglon As Integer = -1
            Dim SQLCnslt As String

            SQLCnslt = "SELECT Cantidad, Recibida, Articulo, Proveedor FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "' ORDER BY Renglon"

            Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

            For Each row As DataRow In tablaOrdenesCompra.Rows.Cast(Of DataRow).Where(Function(r) r.Item("Cantidad") - r.Item("Recibida"))

                Dim Saldo As Double = row.Item("Cantidad") - row.Item("Recibida")

                Renglon = DGV_InformeRecepcion.Rows.Add()

                With DGV_InformeRecepcion.Rows(Renglon)
                    .Cells("Orden").Value = txtOrdenCompra.Text
                    .Cells("Producto").Value = row.Item("Articulo")

                    Saldo = row.Item("Cantidad") - row.Item("Recibida")

                    .Cells("CantIngre").Value = "0.00"
                    .Cells("SaldoOC").Value = formatonumerico(Saldo)
                    .Cells("DescOC").Value = "0"
                    .Cells("Envase").Value = ""
                End With

                txtProveedor.Text = row.Item("Proveedor")

            Next

            SQLCnslt = " SELECT Nombre FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'"

            Dim RowProveedor As DataRow = GetSingle(SQLCnslt)
            If RowProveedor IsNot Nothing Then
                txtDescripcionProv.Text = RowProveedor.Item("Nombre")
            End If

            For Each DG_ROW As DataGridViewRow In DGV_InformeRecepcion.Rows
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & DG_ROW.Cells("Producto").Value & "'"
                Dim rowArticulo As DataRow = GetSingle(SQLCnslt)

                If rowArticulo IsNot Nothing Then
                    DG_ROW.Cells("Descripcion").Value = rowArticulo.Item("Descripcion")
                End If

            Next
        End If

        If DGV_InformeRecepcion.Rows.Count > 0 Then
            txtRemito.Focus()
        End If

    End Sub

    Private Sub txtCantIngre_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantIngre.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtSaldoOC.Text = "" Then
                    txtEnvase.Focus()
                Else
                    txtCantIngre.Text = formatonumerico(txtCantIngre.Text)
                    If Val(txtCantIngre.Text) >= Val(txtSaldoOC.Text) Then
                        txtDescOC.Text = txtSaldoOC.Text
                        txtDescOC.Enabled = False
                        txtEnvase.Focus()
                    Else
                        txtDescOC.Enabled = True
                        txtDescOC.Focus()
                    End If

                    txtDescOC.Focus()
                End If

            Case Keys.Escape
                txtCantIngre.Text = ""
        End Select
    End Sub

    Private Sub txtDescOC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDescOC.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If Val(txtDescOC.Text) > Val(txtSaldoOC.Text) Then
                    MsgBox("No puede ser mayor al Saldo de Orden de Compra")
                    txtDescOC.Focus()
                    Exit Sub
                ElseIf Val(txtDescOC.Text) < Val(txtSaldoOC.Text) And Val(txtDescOC.Text) < Val(txtCantIngre.Text) Then
                        txtDescOC.Text = txtCantIngre.Text
                End If

                txtDescOC.Text = formatonumerico(txtDescOC.Text)

                txtEnvase.Focus()

            Case Keys.Escape
                txtDescOC.Text = ""
        End Select
    End Sub

    Private Sub txtEnvase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEnvase.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If txtSaldoOC.Text.Trim() = "" And Val(txtCantIngre.Text) > 0 And Val(txtDescOC.Text) > 0 And txtDescripcionMP.Text <> "" Then
                    PnlEstadoEnvases.Visible = True
                Else
                    If Val(txtCantIngre.Text) = 0 Then
                        txtCantIngre.Focus()
                        Exit Sub
                    ElseIf Val(txtDescOC.Text) = 0 Then
                        txtDescOC.Focus()
                        Exit Sub
                    End If

                    Dim TipoOrden As Integer = 0
                    Dim SQLCnslt As String
                    Dim Entra As String

                    SQLCnslt = "SELECT Tipo FROM Orden WHERE Orden = '" & txtOrden.Text & "' ORDER BY Renglon"
                    Dim rowOrden As DataRow = GetSingle(SQLCnslt)
                    If rowOrden IsNot Nothing Then
                        TipoOrden = rowOrden.Item("Tipo")
                    End If

                    If TipoOrden <> 3 And TipoOrden <> 4 Then

                        SQLCnslt = "SELECT Envases FROM Envases WHERE Envases = '" & txtEnvase.Text & "'"
                        rowOrden = GetSingle(SQLCnslt)
                        If rowOrden IsNot Nothing Then
                            txtEtiqueta.Focus()
                        Else
                            txtEnvase.Focus()
                        End If

                        PnlEstadoEnvases.Visible = txtEnvase.Text <> ""

                    ElseIf TipoOrden = 3 Or TipoOrden = 4 Then

                        Entra = "N"
                        SQLCnslt = "SELECT Informe FROM Informe WHERE Informe = '" & _txtNroInforme.Text & "'"
                        Dim rowInforme As DataRow = GetSingle(SQLCnslt)
                        If rowInforme IsNot Nothing Then
                            Entra = "S"
                        End If

                        txtEnvase.Text = "0"
                        txtEtiqueta.Text = "0"

                        If Entra = "N" And Val(txtDescOC.Text) > Val(txtSaldoOC.Text) Then
                            Dim mensaje As String = "La cantidad a descontar supera el saldo de la orden de compra"
                            MsgBox(mensaje, 0, "Ingreso de Informe de recepcion")
                            txtDescOC.Text = ""
                            txtDescOC.Focus()
                            Exit Sub
                        ElseIf Val(txtDescOC.Text) <> Val(txtSaldoOC.Text) Then
                            Dim Dife As Double = Str$(Val(txtSaldoOC.Text) - Val(txtDescOC.Text))
                            Dim Termina As String = "Ingreso de Informe de recepcion"
                            Dim mensaje As String = "La orden de compra del " & mastxtMateriaPrima.Text & " quedara con un saldo pendiente de entrega de " & Dife & " Kgs" & vbCrLf & "Confirma este procedimiento"
                            Dim Respuesta = MsgBox(mensaje, 32 + 4, Termina)
                            If Respuesta <> 6 Then
                                Exit Sub
                            End If
                            lblAviso2.Text = "LA CANTIDAD DE " + Str$(Dife) + " KGS. Y QUE EL PROVEEDOR"
                            pnlAviso.Visible = True
                        End If
                    End If

                    _ModificarDatosGRilla()
                End If

            Case Keys.Escape
                txtEnvase.Text = ""
        End Select
    End Sub

    Private Sub btnAceptar_pnlEstadoEnvases_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar_pnlEstadoEnvases.Click
        PnlEstadoEnvases.Visible = False
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtProveedor.KeyDown

        Dim SQLCnslt As String

        Select Case e.KeyData
            Case Keys.Enter
                If txtProveedor.Text <> "" Then
                    If txtOrdenCompra.Text <> "" Then
                        SQLCnslt = "SELECT Articulo FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "' AND Proveedor = '" & txtProveedor.Text & "'"
                        Dim rowOrd As DataRow = GetSingle(SQLCnslt)
                        If rowOrd IsNot Nothing Then
                            Exit Sub
                        End If
                    End If

                    Dim Auxiliar As String = txtProveedor.Text
                    _LimpiarForm()
                    txtProveedor.Text = Auxiliar

                    SQLCnslt = "SELECT AyudaDescripcion = a.Descripcion, AyudaArticulo = o.Articulo,  AyudaSaldo = o.Cantidad - o.Recibida, NroOrden = o.Orden "
                    SQLCnslt = SQLCnslt & "FROM Orden o INNER JOIN Articulo a ON o.Articulo = a.Codigo  WHERE (o.Tipo = 3 OR o.Tipo = 4) AND o.Saldo > 0 AND o.Recibida < o.Cantidad  AND o.Proveedor = '" & txtProveedor.Text & "' ORDER BY o.Articulo "
                    Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

                    '  DGV_AyudaProv.DataSource = tablaOrdenesCompra

                    If tablaOrdenesCompra.Rows.Count > 0 Then
                        With New BuscadorOrdenCompraXProvee(txtProveedor.Text)
                            .Show(Me)
                        End With
                    Else
                        SQLCnslt = "Select Proveedor from proveedor where proveedor = '" & txtProveedor.Text & "'"
                        Dim row As DataRow = GetSingle(SQLCnslt)
                        If row IsNot Nothing Then
                            MsgBox("No existen ordenes de compra pendientes para este proveedor")
                        Else
                            txtProveedor.Focus()
                        End If

                    End If
                End If
            Case Keys.Escape
                txtProveedor.Text = ""
        End Select
    End Sub

    Private Sub btnLimpiarForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiarForm.Click
        _LimpiarForm()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub txtOrdenCompra_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrdenCompra.DoubleClick
        Dim SQLCnslt As String
        If txtProveedor.Text <> "" Then
            SQLCnslt = "SELECT AyudaDescripcion = a.Descripcion, AyudaArticulo = o.Articulo,  AyudaSaldo = o.Cantidad - o.Recibida, NroOrden = o.Orden "
            SQLCnslt = SQLCnslt & "FROM Orden o INNER JOIN Articulo a ON o.Articulo = a.Codigo  WHERE (o.Tipo = 3 OR o.Tipo = 4) AND o.Saldo > 0 AND o.Recibida < o.Cantidad  AND o.Proveedor = '" & txtProveedor.Text & "' ORDER BY o.Articulo "
            Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

            ' DGV_AyudaProv.DataSource = tablaOrdenesCompra

            If tablaOrdenesCompra.Rows.Count > 0 Then
                With New BuscadorOrdenCompraXProvee(txtProveedor.Text)
                    .Show(Me)
                End With
            End If
        End If


    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        Dim Auxiliar, Auxiliar2 As String

        auxiliar = ValidaFecha(mastxtFecha.Text)

        If auxiliar <> "S" Then
            Dim mensaje As String = "La fecha del informe de recepcion es incorrecta"
            MsgBox(mensaje, 0, "Ingreso de WOrden de Compra")
            Exit Sub
        End If

        If Trim(txtRemito.Text) = "" Then
            Dim mensaje As String = "Es obligatorio informar el numero de remito"
            MsgBox(mensaje, 0, "Ingreso de Informe de recepcion")
            Exit Sub
        End If

        Dim WOrden, Articulo, Cantidad, Resta, WEnvase, Vencimiento, OrdVencimiento, WCertificado1, WEstado1, WCertificado2, WObservaI, WObservaII, WObservaIII, WObservaIV, Clave, Informe, Fecha, Proveedor, Remito, Fechaord, WDate, ClaveWOrden, Recibida, Entradas, Costo1, Costo3, Tipo, Terminado, Movi, Lote, Tipomov, Observaciones, Marca, SQLCnslt, CodMovVar, WEstado2 As String
        
        Dim Renglon, CertificadoSi, CertificadoNo, EstadoSi, EstadoNo, EstadoEnv1, EstadoEnv2, EstadoEnv3, EstadoEnv4, EstadoEnv5, EstadoEnv6, EstadoEnv7, EstadoEnv8, EstadoEnv9, EstadoEnv10, WCantidadEnv As Integer
        
        Dim listaSQLCnslt As New List(Of String)

        SQLCnslt = "SELECT Codigo = MAX(Codigo) + 1 FROM Movvar "
        Dim rowmovvar As DataRow = GetSingle(SQLCnslt)

        CodMovVar = 1

        If rowmovvar IsNot Nothing Then CodMovVar = rowmovvar.Item("Codigo")

        SQLCnslt = "SELECT Informe = MAX(Informe) +1 FROM Informe "
        Dim row As DataRow = GetSingle(SQLCnslt)

        txtNroInforme.Text = row.Item("Informe")

        For i = 0 To DGV_InformeRecepcion.Rows.Count - 1

            If Val(DGV_InformeRecepcion.Rows(i).Cells("CantIngre").Value) = 0 Then
                Continue For
            End If

            If DGV_InformeRecepcion.Rows(i).Cells("SaldoOC").Value Is Nothing Then
                MsgBox("No puede grabar un Informe ya existente")
                Exit Sub
            End If


            With DGV_InformeRecepcion.Rows(i)

                WOrden = .Cells("WOrden").Value
                Articulo = UCase(.Cells("Producto").Value)
                UCase(.Cells("Descripcion").Value)
                Cantidad = .Cells("CantIngre").Value
                Resta = .Cells("DescOC").Value
                WEnvase = .Cells("WEnvase").Value

            End With

            Dim XLote1 As String = ""
            Dim XLote2 As String = ""
            Dim XLote3 As String = ""
            Dim XLote4 As String = ""
            Dim XLote5 As String = ""
            Dim XCantiLote1 As String = ""
            Dim XCantiLote2 As String = ""
            Dim XCantiLote3 As String = ""
            Dim XCantiLote4 As String = ""
            Dim XCantiLote5 As String = ""

            CertificadoSi = 1
            CertificadoNo = 0
            WCertificado2 = ""

            EstadoSi = 1
            EstadoNo = 0
            WEstado2 = ""

            If CertificadoNo = 1 Then
                WCertificado1 = 0
            End If

            If CertificadoSi = 1 Then
                WCertificado1 = 1
            End If

            If EstadoNo = 1 Then
                WEstado1 = 1
            End If

            If EstadoSi = 1 Then
                WEstado1 = 1
            End If

            Vencimiento = "  /  /    "
            OrdVencimiento = ""

            EstadoEnv1 = 1
            EstadoEnv2 = 0
            EstadoEnv3 = 1
            EstadoEnv4 = 0
            EstadoEnv5 = 1
            EstadoEnv6 = 0
            EstadoEnv7 = 1
            EstadoEnv8 = 0
            EstadoEnv9 = 1
            EstadoEnv10 = 0
            WCantidadEnv = 0
            WObservaI = ""
            WObservaII = ""
            WObservaIII = ""
            WObservaIV = ""

            If Articulo <> "" Then

                Auxiliar = Renglon.ToString().PadLeft(2, "0")

                Auxiliar2 = txtNroInforme.Text.PadLeft(6, "0")

                Clave = Auxiliar2 + Auxiliar
                Informe = txtNroInforme.Text   'FALTA OBTERNER EL VALOR MAXIMO ANTES DE INSERTAR
                Renglon = (Renglon).ToString()
                Fecha = mastxtFecha.Text
                Proveedor = txtProveedor.Text
                Remito = txtRemito.Text
                Fechaord = Microsoft.VisualBasic.Right(Fecha, 4) + Mid$(Fecha, 4, 2) + Microsoft.VisualBasic.Left(Fecha, 2)
                WDate = Date.Now.ToString("MM-dd-yyyy")



                SQLCnslt = "INSERT INTO Informe (Clave , Informe , Renglon , Fecha ,"
                SQLCnslt = SQLCnslt & "Remito , Proveedor , WOrden , Articulo , Cantidad ,"
                SQLCnslt = SQLCnslt & "Resta , FechaOrd , WEnvase , Lote1 , Canti1 ,"
                SQLCnslt = SQLCnslt & "Lote2 , Canti2 , Lote3 , Canti3 , Lote4 ,"
                SQLCnslt = SQLCnslt & "Canti4 ,Lote5 , Canti5 , WCertificado1 , WCertificado2 ,"
                SQLCnslt = SQLCnslt & "WEstado1 , WEstado2 , EstadoEnvI , EstadoEnvII , EstadoEnvIII ,"
                SQLCnslt = SQLCnslt & "EstadoEnvIV , EstadoEnvV , EstadoEnvVI , EstadoEnvVII ,EstadoEnvVIII ,"
                SQLCnslt = SQLCnslt & "EstadoEnvIX ,EstadoEnvX , WCantidadEnv , WObservaI , WObservaII ,"
                SQLCnslt = SQLCnslt & "WObservaIII , WObservaIV , FechaVencimiento , OrdFechaVencimiento )"
                SQLCnslt = SQLCnslt & "Values ('" & Clave & "', '" & Informe & "', '" & Renglon & "', '" & Fecha & "',"
                SQLCnslt = SQLCnslt & "'" & Remito & "', '" & Proveedor & "', '" & WOrden & "', '" & Articulo & "', '" & Cantidad & "',"
                SQLCnslt = SQLCnslt & "'" & Resta & "', '" & Fechaord & "', '" & WEnvase & "', '" & XLote1 & "', '" & XCantiLote1 & "',"
                SQLCnslt = SQLCnslt & "'" & XLote2 & "', '" & XCantiLote2 & "', '" & XLote3 & "', '" & XCantiLote3 & "', '" & XLote4 & "',"
                SQLCnslt = SQLCnslt & "'" & XCantiLote4 & "', '" & XLote5 & "', '" & XCantiLote5 & "', '" & WCertificado1 & "', '" & WCertificado2 & "',"
                SQLCnslt = SQLCnslt & "'" & WEstado1 & "', '" & WEstado2 & "', '" & EstadoEnv1 & "', '" & EstadoEnv2 & "', '" & EstadoEnv3 & "',"
                SQLCnslt = SQLCnslt & "'" & EstadoEnv4 & "', '" & EstadoEnv5 & "', '" & EstadoEnv6 & "', '" & EstadoEnv7 & "', '" & EstadoEnv8 & "',"
                SQLCnslt = SQLCnslt & "'" & EstadoEnv9 & "', '" & EstadoEnv10 & "', '" & WCantidadEnv & "', '" & WObservaI & "', '" & WObservaII & "',"
                SQLCnslt = SQLCnslt & "'" & WObservaIII & "', '" & WObservaIV & "', '" & Vencimiento & "', '" & OrdVencimiento & "')"

                listaSQLCnslt.Add(SQLCnslt)

                Dim TipoWOrden As Integer = 0

                SQLCnslt = "SELECT Tipo FROM WOrden WHERE WOrden = '" & WOrden & "'"
                row = GetSingle(SQLCnslt)

                TipoWOrden = row.Item("Tipo")


                SQLCnslt = "SELECT Pedido, Laboratorio FROM Articulo WHERE Codigo = '" & Articulo & "'"

                Dim RowArticulo As DataRow = GetSingle(SQLCnslt)

                If RowArticulo IsNot Nothing Then

                    If TipoWOrden <> 2 Then

                        Dim Pedido As String = (RowArticulo.Item("Pedido") - Val(Resta)).ToString()
                        Dim Laboratorio As String = (RowArticulo.Item("Laboratorio") + Val(Cantidad)).ToString()

                        SQLCnslt = "UPDATE Articulo SET Pedido = '" & Pedido & "', Laboratorio = '" & Laboratorio & "', Wdate = '" & WDate & "' WHERE Codigo = '" & Articulo & "'"

                        listaSQLCnslt.Add(SQLCnslt)


                        For j = 1 To 11
                            SQLCnslt = "UPDATE  " & _AQueEmpresa(j) & ".dbo.Articulo SET WEnvase = '" & WEnvase & "', Proveedor = '" & Proveedor & "' WHERE Codigo = '" & Articulo & "'"
                            listaSQLCnslt.Add(SQLCnslt)
                        Next

                        SQLCnslt = "SELECT Clave, Recibida FROM WOrden WHERE WOrden = '" & WOrden & "' AND Articulo = '" & Articulo & "'"

                        Dim RowWOrden As DataRow = GetSingle(SQLCnslt)

                        If RowWOrden IsNot Nothing Then
                            ClaveWOrden = RowWOrden.Item("Clave")
                            Recibida = RowWOrden.Item("Recibida") + Val(Resta)

                            SQLCnslt = "UPDATE WOrden SET Recibida = '" & Recibida & "', Wdate = '" & WDate & "' WHERE Clave = '" & ClaveWOrden & "'"

                            listaSQLCnslt.Add(SQLCnslt)


                            If Val(txtOrden.Text) >= 800000 Then
                                If TipoWOrden = 3 Then

                                    If Val(Cantidad) <> 0 Then

                                        SQLCnslt = "SELECT  Entradas, Costo1, Costo3 FROM Articulo WHERE Codigo = '" & Articulo & "'"
                                        RowArticulo = GetSingle(SQLCnslt)

                                        If RowArticulo IsNot Nothing Then

                                            Entradas = (RowArticulo.Item("Entradas") + Val(Cantidad)).ToString()
                                            Costo1 = (RowArticulo.Item("Costo1")).ToString()
                                            Costo3 = (IIf(IsDBNull(RowArticulo.Item("Costo3")), "0", RowArticulo.Item("Costo3"))).ToString()

                                            SQLCnslt = "UPDATE Articulo SET Laboratorio = '" & Laboratorio & "', Entradas = '" & Entradas & "', Wdate = " & WDate & "', Costo1 = '" & Costo1 & "', Costo3 = '" & Costo3 & "' WHERE Codigo = '" & Articulo & "'"
                                            listaSQLCnslt.Add(SQLCnslt)
                                        End If


                                        Auxiliar = CodMovVar.PadLeft(6, "0")
                                        Auxiliar2 = Renglon.ToString().PadLeft(2, "0")

                                        Tipo = "M"
                                        Terminado = ""
                                        Movi = "E"
                                        Lote = ""
                                        Tipomov = "0"
                                        Observaciones = "Informe " + txtNroInforme.Text + " O/C " + txtOrdenCompra.Text
                                        Marca = ""

                                        SQLCnslt = "INSER INTO Movvar(Clave,Codigo,Renglon,Fecha,Tipo,Articulo,Terminado,Cantidad,FechaOrd,Movi,Tipomov,Observaciones,Wdate,Marca,Lote) "
                                        SQLCnslt = SQLCnslt & "VALUES('" & CodMovVar & "', '" & CodMovVar & "', '" & Renglon & "', '" & Fecha & "', '" & Tipo & "', '" & Articulo & "', "
                                        SQLCnslt = SQLCnslt & "'" & Terminado & "', '" & Cantidad & "', '" & Fechaord & "', '" & Movi & "', '" & Tipomov & "', '" & Observaciones & "', "
                                        SQLCnslt = SQLCnslt & "'" & WDate & "', '" & Marca & "', '" & Lote & "')"

                                        listaSQLCnslt.Add(SQLCnslt)
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Renglon += 1

        Next

        If listaSQLCnslt.Count > 0 Then
            ExecuteNonQueries(listaSQLCnslt.ToArray())

            _LimpiarForm()
        Else
            MsgBox("No informo ningun ingreso")
        End If

    End Sub

    Private Function _AQueEmpresa(ByVal Empresa As String) As String
        If (Empresa = "1") Then
            Return "SurfactanSa"
        End If
        If (Empresa = "2") Then
            Return "Surfactan_II"
        End If
        If (Empresa = "3") Then
            Return "Surfactan_III"
        End If
        If (Empresa = "4") Then
            Return "Surfactan_IV"
        End If
        If (Empresa = "5") Then
            Return "Surfactan_V"
        End If
        If (Empresa = "6") Then
            Return "Surfactan_VI"
        End If
        If (Empresa = "7") Then
            Return "Surfactan_VII"
        End If
        If (Empresa = "8") Then
            Return "PellitalSa"
        End If
        If (Empresa = "9") Then
            Return "Pelitall_II"
        End If
        If (Empresa = "10") Then
            Return "Pellital_III"
        End If

        Return "Pellital_V"

    End Function

    Private Sub btnBuscarProv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarProv.Click
        With New BuscadorProveedor
            .Show(Me)
        End With
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then
                    txtOrdenCompra.Focus()
                Else
                    mastxtFecha.Focus()
                End If
            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub

    Private Sub txtRemito_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRemito.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtRemito.Text = ""
        End Select
    End Sub

    Public Sub ProcesarDatosProveedor(CodProvee As String, DescripcionProvee As String) Implements IBuscadorProveedor.ProcesarDatosProveedor

        txtProveedor.Text = CodProvee
        txtProveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        txtDescripcionProv.Text = DescripcionProvee
    End Sub

    Public Sub ProcesarDatosOrdenCompraProvee(NroOrdenCompra As Integer) Implements IBuscarOrdenCompraXProvee.ProcesarDatosOrdenCompraProvee
        txtOrdenCompra.Text = NroOrdenCompra
        txtOrdenCompra_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

End Class