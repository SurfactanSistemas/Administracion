Imports System.IO
Imports Util.Clases

Public Class IngresoActualizacionHojaProduccionFarma

    Dim SaldoAnterior As Double

    Dim lineaSeleccionada As String

    Dim CantidadDeFila As Double

    Dim PermisoGrabar As Boolean

    Sub New(Optional ByVal ID As String = "00")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If

    End Sub
    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub IngresoActualizacionHojaProduccionFarma_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Text = ""
        cbxTipo.SelectedIndex = 0
        pnlLotes.Visible = False
        mastxtFecha.Text = Date.Today
        txtHojaProduccion.Text = 0
        txtVersionFormulaV1.Enabled = False
        txtProcedimientoV2.Enabled = False
        txtEspecificacionV3.Enabled = False
        pnlAgenda.Visible = False
        pnlAyuda.Visible = False

        _LimpiarForm()

        If PermisoGrabar = False Then
            btnGrabar.Enabled = False
            btnNuevaFila.Enabled = False
            btnEditarFila.Enabled = False
            btnBajaHoja.Enabled = False

            mastxtMPoPT.ReadOnly = True
            txtDescripcionMPoPT.ReadOnly = True
            txtCantidad.ReadOnly = True
            txtPartLote1.ReadOnly = True
            txtPartLote2.ReadOnly = True
            txtPartLote3.ReadOnly = True
            txtPartLote1.ReadOnly = True
            txtPartLote2.ReadOnly = True
            txtPartLote3.ReadOnly = True
            rtxtAgenda.ReadOnly = True
        End If

    End Sub

    Private Sub IngresoActualizacionHojaProduccionFarma_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtHojaProduccion.Focus()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtHojaProduccion.KeyPress, txtVersionFormulaV1.KeyPress, txtProcedimientoV2.KeyPress, txtPartLote3.KeyPress, txtPartLote2.KeyPress, txtPartLote1.KeyPress, txtEspecificacionV3.KeyPress, txtEquipo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtRendimientoTeorico.KeyPress, txtRendimientoReal.KeyPress, txtCantLote3.KeyPress, txtCantLote2.KeyPress, txtCantLote1.KeyPress, txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtHojaProduccion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHojaProduccion.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtHojaProduccion.Text) <> 0 Then
                    Dim Entra = "N"
                    Dim SQLCnslt As String

                    SQLCnslt = "SELECT Fecha, Real, Teorico, FechaIng, Producto, Equipo, VersionI, VersionII, VersionIII "
                    SQLCnslt = SQLCnslt & "FROM Hoja WHERE Hoja = '" & txtHojaProduccion.Text & "' ORDER BY Clave"

                    Dim TablaHoja As DataTable = GetAll(SQLCnslt)

                    If TablaHoja.Rows.Count > 0 Then
                        With TablaHoja.Rows(0)
                            Entra = "S"
                            mastxtFecha.Text = .Item("Fecha")
                            txtRendimientoReal.Text = formatonumerico(.Item("Real"))
                            txtRendimientoTeorico.Text = formatonumerico(.Item("Teorico"))
                            mastxtFechaIngreso.Text = .Item("FechaIng")
                            mastxtProducto.Text = OrDefault(.Item("Producto"), "  -     -   ")
                            txtEquipo.Text = IIf(IsDBNull(.Item("Equipo")), "", .Item("Equipo"))
                            txtVersionFormulaV1.Text = IIf(IsDBNull(.Item("VersionI")), "", .Item("VersionI"))
                            txtProcedimientoV2.Text = IIf(IsDBNull(.Item("VersionII")), "", .Item("VersionII"))
                            txtEspecificacionV3.Text = IIf(IsDBNull(.Item("VersionIII")), "", .Item("VersionIII"))
                        End With
                    End If

                    If Entra = "S" Then
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"
                        Dim rowTerminado As DataRow = GetSingle(SQLCnslt)
                        If rowTerminado IsNot Nothing Then
                            txtDescipcion.Text = rowTerminado.Item("Descripcion")
                        End If

                        _LlenarGrilla()


                    Else

                        Dim Hoja As String = txtHojaProduccion.Text
                        _LimpiarForm()
                        txtHojaProduccion.Text = Hoja
                        txtHojaProduccion.Focus()
                    End If
                Else
                    mastxtProducto.Focus()

                End If
            Case Keys.Escape
                txtHojaProduccion.Text = ""

        End Select
    End Sub

    Private Sub _LlenarGrilla()
        DGV_IngredientosHojaProduccion.Rows.Clear()

        Dim Renglon As Integer = 0
        Dim SQLCnslt As String



        SQLCnslt = "SELECT Tipo, Articulo, Terminado, Cantidad, Saldo, Lote, Lote1, Lote2, Lote3, Canti1, Canti2, Canti3  "
        SQLCnslt = SQLCnslt & "FROM Hoja WHERE Hoja = '" & txtHojaProduccion.Text & "' ORDER BY Clave"
        Dim TablaHoja As DataTable = GetAll(SQLCnslt)

        If TablaHoja.Rows.Count > 0 Then

            For i As Integer = 0 To TablaHoja.Rows.Count - 1

                With DGV_IngredientosHojaProduccion

                    Renglon = Renglon + 1

                    .Rows.Add()

                    .Rows(i).Cells("Linea").Value = i + 1

                    .Rows(i).Cells("tipo").Value = TablaHoja.Rows(i).Item("Tipo")

                    If .Rows(i).Cells("tipo").Value = "M" Then
                        .Rows(i).Cells("MPoPT").Value = TablaHoja.Rows(i).Item("Articulo")
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & .Rows(i).Cells("MPoPT").Value & "'"
                    Else
                        .Rows(i).Cells("MPoPT").Value = TablaHoja.Rows(i).Item("Terminado")
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & .Rows(i).Cells("MPoPT").Value & "'"
                    End If

                    Dim rowDescripcion As DataRow = GetSingle(SQLCnslt)

                    .Rows(i).Cells("Descripcion").Value = rowDescripcion.Item("Descripcion")

                    .Rows(i).Cells("Cantidad").Value = formatonumerico(TablaHoja.Rows(i).Item("Cantidad"), 3)

                    If Renglon = 1 Then
                        SaldoAnterior = IIf(IsDBNull(TablaHoja.Rows(i).Item("Saldo")), "0", TablaHoja.Rows(i).Item("Saldo"))
                        SaldoAnterior = formatonumerico(SaldoAnterior)
                    End If

                    .Rows(i).Cells("Lote1").Value = IIf(IsDBNull(TablaHoja.Rows(i).Item("Lote1")), "", TablaHoja.Rows(i).Item("Lote1"))
                    .Rows(i).Cells("CantLote1").Value = formatonumerico(IIf(IsDBNull(TablaHoja.Rows(i).Item("Canti1")), "", TablaHoja.Rows(i).Item("Canti1")))
                    .Rows(i).Cells("Lote2").Value = IIf(IsDBNull(TablaHoja.Rows(i).Item("Lote2")), "", TablaHoja.Rows(i).Item("Lote2"))
                    .Rows(i).Cells("CantLote2").Value = formatonumerico(IIf(IsDBNull(TablaHoja.Rows(i).Item("Canti2")), "", TablaHoja.Rows(i).Item("Canti2")))
                    .Rows(i).Cells("Lote3").Value = IIf(IsDBNull(TablaHoja.Rows(i).Item("Lote3")), "", TablaHoja.Rows(i).Item("Lote3"))
                    .Rows(i).Cells("CantLote3").Value = formatonumerico(IIf(IsDBNull(TablaHoja.Rows(i).Item("Canti3")), "", TablaHoja.Rows(i).Item("Canti3")))

                    If Val(txtRendimientoReal.Text) <> 0 Then
                        If Val(.Rows(i).Cells("Lote1").Value) = 0 And TablaHoja.Rows(i).Item("Lote") <> 0 Then
                            .Rows(i).Cells("Lote1").Value = TablaHoja.Rows(i).Item("Lote")
                            .Rows(i).Cells("CantLote1").Value = formatonumerico(TablaHoja.Rows(i).Item("Cantidad"))
                        End If
                    End If

                End With

            Next

        End If



        If Val(txtRendimientoReal.Text) <> 0 And Val(txtRendimientoReal.Text) <> SaldoAnterior Then
            btnBajaHoja.Enabled = False
            btnGrabar.Enabled = False
        Else
            btnBajaHoja.Enabled = True
            btnGrabar.Enabled = True
        End If

        If Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "YQ" Then
            btnBajaHoja.Enabled = False
            btnGrabar.Enabled = False
        End If
        If Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "YF" Then
            btnBajaHoja.Enabled = False
            btnGrabar.Enabled = False
        End If
        If Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "YP" Then
            btnBajaHoja.Enabled = False
            btnGrabar.Enabled = False
        End If


    End Sub

    Private Sub _LimpiarForm()
        txtHojaProduccion.Text = ""
        mastxtFecha.Text = ""
        txtVersionFormulaV1.Text = ""
        txtProcedimientoV2.Text = ""
        txtEspecificacionV3.Text = ""
        mastxtProducto.Text = ""
        txtDescipcion.Text = ""
        txtEquipo.Text = ""
        txtRendimientoTeorico.Text = ""
        txtRendimientoReal.Text = ""
        mastxtFechaIngreso.Text = ""

        DGV_IngredientosHojaProduccion.Rows.Clear()

        _LimpiarRenglonCarga()
        _LimpiarPnlLote()


        txtHojaProduccion.Text = 0
        txtHojaProduccion.Focus()
        mastxtFecha.Text = Date.Today

        btnGrabar.Enabled = True

        If PermisoGrabar = False Then
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub _LimpiarRenglonCarga()
        lineaSeleccionada = ""
        cbxTipo.SelectedIndex = 0
        lblMPoPT.Text = "Materia Prima"
        mastxtMPoPT.Mask = ">LL-000-000"
        mastxtMPoPT.Text = ""
        txtDescripcionMPoPT.Text = ""
        txtCantidad.Text = ""
    End Sub

    Private Sub _LimpiarPnlLote()
        txtCantLote1.Text = ""
        txtCantLote2.Text = ""
        txtCantLote3.Text = ""
        txtCantLote1.Text = ""
        txtCantLote2.Text = ""
        txtCantLote3.Text = ""
    End Sub


    Private Sub cbxTipo_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cbxTipo.DropDownClosed
        If cbxTipo.Text = "M" Then
            lblMPoPT.Text = "Materia Prima"
            mastxtMPoPT.Mask = ">LL-000-000"
        Else
            lblMPoPT.Text = "Producto Terminado"
            mastxtMPoPT.Mask = ">LL-00000-000"
        End If
    End Sub

    Private Sub cbxTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxTipo.SelectedIndexChanged
        If cbxTipo.Text = "M" Then
            lblMPoPT.Text = "Materia Prima"
            mastxtMPoPT.Mask = ">LL-000-000"
        Else
            lblMPoPT.Text = "Producto Terminado"
            mastxtMPoPT.Mask = ">LL-00000-000"
        End If
    End Sub


    Private Sub DGV_IngredientosHojaProduccion_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV_IngredientosHojaProduccion.CellDoubleClick

        lineaSeleccionada = DGV_IngredientosHojaProduccion.CurrentRow.Cells("Linea").Value

        With DGV_IngredientosHojaProduccion.CurrentRow
            cbxTipo.Text = .Cells("Tipo").Value
            mastxtMPoPT.Text = .Cells("MPoPT").Value
            txtDescripcionMPoPT.Text = .Cells("Descripcion").Value
            txtCantidad.Text = .Cells("Cantidad").Value

            txtPartLote1.Text = .Cells("Lote1").Value
            txtPartLote2.Text = .Cells("Lote2").Value
            txtPartLote3.Text = .Cells("Lote3").Value

            txtCantLote1.Text = .Cells("CantLote1").Value
            txtCantLote2.Text = .Cells("CantLote2").Value
            txtCantLote3.Text = .Cells("CantLote3").Value
            pnlLotes.Visible = True

            If PermisoGrabar = False Then
                btnEditarFila.Enabled = False
            Else
                btnEditarFila.Enabled = True
            End If

        End With
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs, Optional ByRef Permitir As String = "N") Handles txtCantidad.KeyDown

        Dim stock As Double = 0



        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtCantidad.Text) > 0 Then

                    txtCantidad.Text = formatonumerico(txtCantidad.Text, 3)

                    'GUARDO EL VALOR DE LA LINEA SELECCIONADA PARA PODER SUMARSELO AL STOCK Y PERMITIR MODIFICAR EL MONTO
                    CantidadDeFila = Val(DGV_IngredientosHojaProduccion.Rows(Val(lineaSeleccionada) - 1).Cells("Cantidad").Value)

                    If Permitir = "NE" Then
                        formatonumerico(_CalcularSTOCKDEPRODUCTO(cbxTipo.Text, mastxtMPoPT.Text, stock, "SE"))
                    Else
                        formatonumerico(_CalcularSTOCKDEPRODUCTO(cbxTipo.Text, mastxtMPoPT.Text, stock, "S"))
                    End If



                End If
                If Val(txtRendimientoReal.Text) = 0 Then

                    If Val(txtCantidad.Text) <= Val(formatonumerico(stock, 3)) Then
                        If txtDescripcionMPoPT.Text <> "" Then
                            Permitir = "S"
                            txtPartLote1.Focus()
                        End If
                    Else
                        If txtDescripcionMPoPT.Text <> "" Then
                            Dim m As String = "No existe stock suficiente"
                            MsgBox(m, 0, "Ingreso de Hoja de Produccion")
                        End If
                    End If

                End If
        End Select


    End Sub

    Private Sub _Alta_Linea(ByVal btn As String)

        If btn = "Editar" Then

            With DGV_IngredientosHojaProduccion
                .Rows(Val(lineaSeleccionada) - 1).Cells("Tipo").Value = cbxTipo.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("MPoPT").Value = mastxtMPoPT.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("Descripcion").Value = txtDescripcionMPoPT.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("Cantidad").Value = formatonumerico(txtCantidad.Text, 3)

                .Rows(Val(lineaSeleccionada) - 1).Cells("Lote1").Value = txtPartLote1.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("Lote2").Value = txtPartLote2.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("Lote3").Value = txtPartLote3.Text

                .Rows(Val(lineaSeleccionada) - 1).Cells("CantLote1").Value = txtCantLote1.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("CantLote2").Value = txtCantLote2.Text
                .Rows(Val(lineaSeleccionada) - 1).Cells("CantLote3").Value = txtCantLote3.Text

            End With

        Else

            Dim posicion = DGV_IngredientosHojaProduccion.Rows.Count
            With DGV_IngredientosHojaProduccion
                .Rows.Add()
                .Rows(posicion).Cells("Linea").Value = posicion
                .Rows(posicion).Cells("Tipo").Value = cbxTipo.Text
                .Rows(posicion).Cells("MPoPT").Value = mastxtMPoPT.Text
                .Rows(posicion).Cells("Descripcion").Value = txtDescripcionMPoPT.Text
                .Rows(posicion).Cells("Cantidad").Value = formatonumerico(txtCantidad.Text, 3)

                .Rows(posicion).Cells("Lote1").Value = ""
                .Rows(posicion).Cells("Lote2").Value = ""
                .Rows(posicion).Cells("Lote3").Value = ""
                .Rows(posicion).Cells("CantLote1").Value = ""
                .Rows(posicion).Cells("CantLote2").Value = ""
                .Rows(posicion).Cells("CantLote3").Value = ""
            End With
        End If
    End Sub

    Private Sub btnNuevaFila_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevaFila.Click

        If txtDescripcionMPoPT.Text <> "" Then
            If txtCantidad.Text <> "" Then
                If txtCantidad.Text <> 0 Then
                    Dim Permitir As String = "N"

                    txtCantidad_KeyDown(Nothing, New KeyEventArgs(Keys.Enter), Permitir)

                    If Permitir = "S" Then
                        _Alta_Linea("Nueva")
                        pnlLotes.Visible = False
                        _LimpiarRenglonCarga()
                    End If


                End If
            End If
        End If


    End Sub

    Private Sub btnEditarFila_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditarFila.Click

        If Val(txtCantidad.Text) > 0 Then
            Dim permitir As String = "NE"
            txtCantidad_KeyDown(Nothing, New KeyEventArgs(Keys.Enter), Permitir)
            If txtPartLote1.Text = "0" Or txtPartLote1.Text = "" Then
                If permitir = "S" Then
                    _Alta_Linea("Editar")
                    _LimpiarPnlLote()
                    _LimpiarRenglonCarga()
                    pnlLotes.Visible = False
                    btnEditarFila.Enabled = False

                End If
                Exit Sub
            End If

            Dim suma As Double

            suma = Val(formatonumerico(txtCantLote1.Text)) + Val(formatonumerico(txtCantLote2.Text)) + Val(formatonumerico(txtCantLote3.Text))

            If suma = Val(txtCantidad.Text) Then
                If _ChequearLotes() = "Si graba" Then
                    _Alta_Linea("Editar")
                    pnlLotes.Visible = False
                    _LimpiarPnlLote()
                    _LimpiarRenglonCarga()
                    btnEditarFila.Enabled = False
                End If
            Else
                MsgBox("La suma de la cantidad por lote no coincide con el total a usar")

            End If




        End If





    End Sub

    Private Function _ChequearLotes() As String

        Dim listaMensaje As New List(Of String)

        Dim SQLCnslt As String
        Dim StockDisponible As Double

        For i As Integer = 1 To 3

            If Controls("pnlLotes").Controls("txtPartLote" & i).Text <> "" Then
                If Val(Controls("pnlLotes").Controls("txtPartLote" & i).Text) <> 0 Then

                    If Controls("pnlLotes").Controls("txtCantLote" & i).Text = "" Then
                        listaMensaje.Add("Se ingreso el lote: " & Controls("pnlLotes").Controls("txtPartLote" & i).Text & ", pero no una cantidad")
                    End If
                    If Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text) = 0 Then
                        listaMensaje.Add("Se ingreso el lote: " & Controls("pnlLotes").Controls("txtPartLote" & i).Text & ", pero no una cantidad")
                    End If
                End If
            End If

            If Controls("pnlLotes").Controls("txtCantLote" & i).Text <> "" Then
                If Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text) <> 0 Then

                    If Controls("pnlLotes").Controls("txtPartLote" & i).Text = "" Then
                        listaMensaje.Add("Se ingreso el Cantidad: " & Controls("pnlLotes").Controls("txtCantLote" & i).Text & ", pero no una Lote")
                    End If
                    If Val(Controls("pnlLotes").Controls("txtPartLote" & i).Text) = 0 Then
                        listaMensaje.Add("Se ingreso el Cantidad: " & Controls("pnlLotes").Controls("txtCantLote" & i).Text & ", pero no una Lote")
                    End If
                End If
            End If


        Next

        If listaMensaje.Count > 0 Then

            MsgBox(String.Join(vbCrLf, listaMensaje))
            Return "No graba"

        End If

        For i As Integer = 1 To 3

            If Val(Controls("pnlLotes").Controls("txtPartLote" & i).Text) <> 0 Then
                Continue For
            End If

            If cbxTipo.Text = "M" Then

                SQLCnslt = "SELECT Saldo FROM Laudo WHERE Articulo = '" & mastxtMPoPT.Text & "' AND Laudo = '" & Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 "

                Dim ROWLaudo As DataRow = GetSingle(SQLCnslt)

                If ROWLaudo IsNot Nothing Then

                    StockDisponible = ROWLaudo.Item("Saldo") - Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                    If StockDisponible < 0 Then
                        listaMensaje.Add("Saldo insuficiente para el Lote " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                    End If


                Else

                    SQLCnslt = "SELECT Saldo FROM Guia WHERE Articulo = '" & mastxtMPoPT.Text & "' AND Lote = '" & Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 AND Movi = 'E'"

                    Dim ROWGuia As DataRow = GetSingle(SQLCnslt)

                    If ROWGuia IsNot Nothing Then

                        StockDisponible = ROWGuia.Item("Saldo") - Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                        If StockDisponible < 0 Then
                            listaMensaje.Add("Saldo insuficiente para el lote " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                        End If
                    Else
                        listaMensaje.Add("No se encuentra el Lote de la Materia Prima: " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)

                    End If

                End If

            Else

                SQLCnslt = "SELECT Saldo FROM Hoja WHERE Producto = '" & mastxtMPoPT.Text & "' AND  Hoja = '" & Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 "

                Dim ROWHoja As DataRow = GetSingle(SQLCnslt)

                If ROWHoja IsNot Nothing Then

                    StockDisponible = ROWHoja.Item("Saldo") - Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                    If StockDisponible < 0 Then
                        listaMensaje.Add("Saldo insuficiente para el lote " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                    End If


                Else

                    SQLCnslt = "SELECT Saldo FROM Guia WHERE Terminado = '" & mastxtMPoPT.Text & "' AND Lote = '" & Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 AND Movi = 'E'"

                    Dim ROWGuia As DataRow = GetSingle(SQLCnslt)

                    If ROWGuia IsNot Nothing Then

                        StockDisponible = ROWGuia.Item("Saldo") - Val(Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                        If StockDisponible < 0 Then
                            listaMensaje.Add("Saldo insuficiente para el lote " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                        End If
                    Else
                        listaMensaje.Add("No se encuentra el Lote de la Producto Terminado: " & Controls("pnlLotes").Controls("txtPartLote" & i).Text)

                    End If
                End If
            End If


        Next

        If listaMensaje.Count > 0 Then

            MsgBox(String.Join(vbCrLf, listaMensaje))
            Return "No graba"
        Else
            Return "Si graba"

        End If


    End Function



    Private Sub txtPartLote1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartLote1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtPartLote1.Text = "0" Or txtPartLote1.Text = "" Then
                    txtCantLote3_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                Else
                    txtCantLote1.Focus()
                End If

            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtCantLote1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantLote1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote1.Text = formatonumerico(txtCantLote1.Text)
                txtPartLote2.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtPartLote2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartLote2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote2.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtCantLote2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantLote2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote2.Text = formatonumerico(txtCantLote2.Text)
                txtPartLote3.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtPartLote3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartLote3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote3.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtCantLote3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantLote3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote3.Text = formatonumerico(txtCantLote3.Text)
                btnEditarFila_Click(Nothing, Nothing)
            Case Keys.Escape

        End Select

    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        _LimpiarForm()
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then
                    mastxtProducto.Focus()
                End If
            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select

    End Sub



    Private Sub mastxtProducto_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtProducto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtProducto.Text.Trim().Length = 12 Then
                    Dim SQLCnslt = "SELECT Descripcion, Estado, EstadoI, EstadoII, Version, VersionI, VersionII FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"
                    Dim rowTerminado As DataRow = GetSingle(SQLCnslt)

                    If rowTerminado IsNot Nothing Then

                        If {"SurfactanSa", "Surfactan_II"}.Contains(Operador.Base) AndAlso (Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "PT" Or Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "SE" Or Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "DW") Then
                            If Val(Codigo) = 1 Or Val(Codigo) = 2 Or Val(Codigo) = 3 Or Val(Codigo) = 4 Then
                                Dim EstadoI As String = IIf(IsDBNull(rowTerminado.Item("Estado")), "", rowTerminado.Item("Estado"))
                                Dim EstadoII As String = IIf(IsDBNull(rowTerminado.Item("Estadoi")), "", rowTerminado.Item("EstadoI"))
                                Dim EstadoIII As String = IIf(IsDBNull(rowTerminado.Item("EstadoII")), "", rowTerminado.Item("EstadoII"))


                                Dim m As String
                                If EstadoI = "N" Or EstadoII = "N" Or EstadoIII = "N" Then
                                    m = "El Producto Terminado no se encuentra autorizado para la Produccion"
                                    If EstadoI = "N" Then
                                        m = m & vbCrLf & "(No se encuentra habilitada la formula)"
                                    End If
                                    If EstadoII = "N" Then
                                        m = m & vbCrLf & "(No se encuentra habilitada los procesos)"
                                    End If
                                    If EstadoIII = "N" Then
                                        m = m & vbCrLf & "(No se encuentra habilitada las especificaciones)"
                                    End If
                                    MsgBox(m$, 0, "Ingreso de Hoja de Produccion")
                                    Exit Sub
                                End If
                            End If

                            txtVersionFormulaV1.Text = IIf(IsDBNull(rowTerminado.Item("Version")), "", rowTerminado.Item("Version"))
                            txtProcedimientoV2.Text = IIf(IsDBNull(rowTerminado.Item("VersionI")), "", rowTerminado.Item("VersionI"))
                            txtEspecificacionV3.Text = IIf(IsDBNull(rowTerminado.Item("VersionII")), "", rowTerminado.Item("VersionII"))

                        End If

                        txtDescipcion.Text = rowTerminado.Item("Descripcion")
                        txtRendimientoTeorico.Focus()


                    End If
                End If
            Case Keys.Escape
                mastxtProducto.Text = ""
        End Select
    End Sub

    Private Sub txtEquipo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEquipo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtRendimientoTeorico.Focus()
            Case Keys.Escape
                txtEquipo.Text = ""
        End Select
    End Sub

    Private Sub txtRendimientoTeorico_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRendimientoTeorico.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtRendimientoTeorico.Text = formatonumerico(txtRendimientoTeorico.Text)
                mastxtMPoPT.Focus()

                If Val(txtRendimientoTeorico.Text) > 0 AndAlso mastxtProducto.Text.Replace(" ", "").Length = 12 AndAlso _ExisteProducto() Then

                    _BuscarComposicion()

                End If

            Case Keys.Escape
                txtRendimientoTeorico.Text = ""
        End Select
    End Sub

    Private Function _ExisteProducto() As Boolean

        Dim row As DataRow = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'")

        Return row IsNot Nothing

    End Function

    Private Sub _BuscarComposicion()
        Dim SQLCnslt As String

        SQLCnslt = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion WHERE Terminado = '" & mastxtProducto.Text & "' ORDER BY Clave"

        Dim TablaComposicion As DataTable = GetAll(SQLCnslt)
        Dim Renglon As Integer = 0

        DGV_IngredientosHojaProduccion.Rows.Clear()

        If TablaComposicion.Rows.Count > 0 Then

            For i = 0 To TablaComposicion.Rows.Count - 1

                If TablaComposicion.Rows(i).Item("Tipo") = "M" Then
                    If Microsoft.VisualBasic.Left$(UCase(TablaComposicion.Rows(i).Item("Articulo1")), 2) = "YA" Then
                        Continue For
                    End If
                End If


                With DGV_IngredientosHojaProduccion
                    .Rows.Add()
                    .Rows(Renglon).Cells("Linea").Value = Renglon + 1
                    .Rows(Renglon).Cells("Tipo").Value = TablaComposicion.Rows(i).Item("Tipo")

                    If TablaComposicion.Rows(i).Item("Tipo") = "M" Then
                        .Rows(Renglon).Cells("MPoPT").Value = TablaComposicion.Rows(i).Item("Articulo1")
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & .Rows(Renglon).Cells("MPoPT").Value & "'"

                    Else
                        .Rows(Renglon).Cells("MPoPT").Value = TablaComposicion.Rows(i).Item("Articulo2")
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & .Rows(Renglon).Cells("MPoPT").Value & "'"

                    End If

                    Dim row As DataRow = GetSingle(SQLCnslt)
                    If row IsNot Nothing Then
                        .Rows(Renglon).Cells("Descripcion").Value = row.Item("Descripcion")
                    End If

                    .Rows(Renglon).Cells("Cantidad").Value = formatonumerico(Val(txtRendimientoTeorico.Text) * Val(TablaComposicion.Rows(i).Item("Cantidad")), 3)

                    Renglon += 1
                End With

            Next

            Dim WTipo, WMPoPT As String

            For Each row As DataGridViewRow In DGV_IngredientosHojaProduccion.Rows
                Dim WCantidad As String = ""
                With row
                    WTipo = .Cells("Tipo").Value
                    WMPoPT = .Cells("MPoPT").Value
                    WCantidad = .Cells("Cantidad").Value
                End With

                Dim WStock As Double = 0
                Dim StockString As String

                StockString = _CalcularSTOCKDEPRODUCTO(WTipo, WMPoPT, WStock)

                With row

                    If Val(WCantidad) <= WStock Then
                        row.Cells("Cantidad").Value = WCantidad
                    Else
                        Dim Impre As String = StockString

                        Dim mensaje As String = "No existe stock suficiente del item " & row.Cells("MPoPT").Value & " Stock: " & Impre & " Kgs."
                        MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")

                        row.Cells("Cantidad").Value = ""
                    End If

                End With
            Next

        End If

    End Sub

    Private Function _ObtenerEmpresaOriginal(ByVal WLote As Object) As String

        For Each empresa As Object In Conexion.Empresas

            Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Fecha, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "' And Renglon IN ('1', '01')", empresa)

            If WLaudo IsNot Nothing Then Return empresa

        Next

        Return Nothing

    End Function

    Function _SaldoPTXCodigo(ByVal _LotePT As String) As Double
        
        Dim WMovimientos As New DataTable

        With WMovimientos.Columns
            .Add("Entrada")
            .Add("Salida")
            .Add("Marca")
        End With

        Dim empresa As String = Operador.Base

        '
        ' Busco Stock generado por Hojas de Producción.
        '
        Dim WSql As String = ""

        WSql = "SELECT sum(h.Real) FROM Hoja h INNER JOIN Terminado t ON t.COdigo = h.Producto WHERE h.Producto = '" & _LotePT & "' And h.Marca <> 'X' And h.Renglon = '1'"

        Dim WHojasTotal As DataRow = GetSingle(WSql, empresa)

        If WHojasTotal IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = formatonumerico(OrDefault(WHojasTotal.Item(0), 0))
                .Item("Salida") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        Dim WLiberada As String

        '
        ' Busco uso como componente en Hojas de Producción posteriores a la Fecha de Cierre (Incluyendo a las que no se encuentran cerradas).
        '
        Dim WHojasComponente As DataRow = GetSingle("SELECT SUM(CASE WHEN ISNULL(Lote1, 0) = 0 And ISNULL(Lote2, 0) = 0 And ISNULL(Lote3, 0) = 0 THEN Cantidad ELSE (Canti1 + Canti2 + Canti3) END) FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Terminado WHERE Tipo = 'T' and h.Marca <> 'X' And h.FechaOrd >= t.OrdFechaCierre And h.Terminado = '" & _LotePT & "'", empresa)

        If WHojasComponente IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = formatonumerico(OrDefault(WHojasComponente.Item(0), 0))
                .Item("Entrada") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Movimientos Varios.
        '
        Dim WMovVars As DataRow = GetSingle("SELECT sum(Cantidad) FROM MovVar WHERE Tipo = 'T' And MARCA <> 'X' And Movi = 'E' And Terminado = '" & _LotePT & "'", empresa)

        If WMovVars IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = formatonumerico(OrDefault(WMovVars.Item(0), 0))
                .Item("Salida") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Movimientos Varios.
        '
        WMovVars = GetSingle("SELECT sum(Cantidad) FROM MovVar WHERE Tipo = 'T' And MARCA <> 'X' And Movi = 'S' And Terminado = '" & _LotePT & "'", empresa)

        If WMovVars IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = formatonumerico(OrDefault(WMovVars.Item(0), 0))
                .Item("Entrada") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Guias.
        '
        Dim WGuiasInt As DataRow = GetSingle("SELECT SUM(Cantidad) FROM Guia WHERE Tipo = 'T' And Marca <> 'X' and movi = 'E' And Terminado = '" & _LotePT & "'", empresa)

        If WGuiasInt IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = ""
                .Item("Entrada") = formatonumerico(OrDefault(WGuiasInt.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Guias.
        '
        WGuiasInt = GetSingle("SELECT SUM(Cantidad) FROM Guia WHERE Tipo = 'T' And Marca <> 'X' and movi = 'S' And Terminado = '" & _LotePT & "'", empresa)

        If WGuiasInt IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = ""
                .Item("Salida") = formatonumerico(OrDefault(WGuiasInt.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Movimientos de Laboratorio.
        '
        Dim WMovLab As DataRow = GetSingle("SELECT SUM(Cantidad) FROM MovLab WHERE Tipo = 'T' And MARCA <> 'X' And Terminado = '" & _LotePT & "' And movi = 'E'", empresa)

        If WMovLab IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = ""
                .Item("Entrada") = formatonumerico(OrDefault(WMovLab.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Movimientos de Laboratorio.
        '
        WMovLab = GetSingle("SELECT SUM(Cantidad) FROM MovLab WHERE Tipo = 'T' And MARCA <> 'X' And Terminado = '" & _LotePT & "' And movi = 'S'", empresa)

        If WMovLab IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = ""
                .Item("Salida") = formatonumerico(OrDefault(WMovLab.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco movimientos en Estadisticas.
        '
        Dim WEstadisticas As DataTable = GetAll("SELECT e.Tipo, e.LoteAdicional, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.Marca <> 'X' And e.Articulo = '" & _LotePT & "'", empresa)

        For Each row As DataRow In WEstadisticas.Rows

            Dim XLotes(12, 2) As String
            Dim WTipo

            With row
                WTipo = OrDefault(.Item("Tipo"), 0)

                For i = 1 To 5
                    XLotes(i, 2) = OrDefault(.Item("Canti" & i), "")
                Next

                Dim WLoteAdicional As String = OrDefault(.Item("LoteAdicional"), "")
                WLoteAdicional = WLoteAdicional.PadRight(98, "0")

                XLotes(6, 2) = Mid$(WLoteAdicional, 9, 6)
                XLotes(7, 2) = Mid$(WLoteAdicional, 23, 6)
                XLotes(8, 2) = Mid$(WLoteAdicional, 37, 6)
                XLotes(9, 2) = Mid$(WLoteAdicional, 51, 6)
                XLotes(10, 2) = Mid$(WLoteAdicional, 65, 6)
                XLotes(11, 2) = Mid$(WLoteAdicional, 79, 6)
                XLotes(12, 2) = Mid$(WLoteAdicional, 93, 6)

            End With

            For i = 1 To 12

                WLiberada = Math.Abs(Val(formatonumerico(XLotes(i, 2))))

                If Val(WLiberada) = 0 Then Continue For

                Dim r = WMovimientos.NewRow
                With r
                    If Val(WTipo) = 1 Then
                        .Item("Salida") = formatonumerico(WLiberada)
                        .Item("Entrada") = ""
                    Else
                        .Item("Entrada") = formatonumerico(WLiberada)
                        .Item("Salida") = ""
                    End If

                End With
                WMovimientos.Rows.Add(r)

            Next

        Next

        '
        ' Calculo Salidas por Consignaciones.
        '
        Dim WConsig As DataRow = GetSingle("select sum(Cantidad - Facturado) from Consig where Terminado = '" & _LotePT & "' and Marca <> 'X'", empresa)

        If WConsig IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = ""
                .Item("Salida") = formatonumerico(OrDefault(WConsig.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            WSaldo += Val(m.Item("Entrada"))
            WSaldo -= Val(m.Item("Salida"))
        Next

        Return Val(formatonumerico(WSaldo))

    End Function

    Function _SaldoMPXCodigo(ByVal _LoteMp As String) As Double
        Dim WCodMP As String = _LoteMp
        Dim WTipoMat As String = ""
        Dim WMarca As String = ""
        Dim Auxi = ""

        Dim WMovimientos As New DataTable

        With WMovimientos.Columns
            .Add("Entrada")
            .Add("Salida")
            .Add("Marca")
        End With

        Dim WFiltroMarca As String = " And ISNULL(Marca, '') <> 'X' "

        Dim empresa As String = Operador.Base

        WTipoMat = WCodMP.ToString.Substring(0, 2)

        '
        ' Busco el o los Laudos que se correspondan con el Lote o PartiOrig segun sea o no Reventa.
        '
        Dim WSql As String = ""

        WSql = "SELECT sum(l.Liberada) FROM Laudo l INNER JOIN Articulo a ON a.COdigo = l.Articulo WHERE l.Articulo = '" & _LoteMp & "' And l.Marca <> 'X' And l.Liberada > 0"

        Dim WLaudos As DataRow = GetSingle(WSql, empresa)

        If WLaudos IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = formatonumerico(OrDefault(WLaudos.Item(0), 0))
                .Item("Salida") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        Dim WLiberada As String

        '
        ' Busco uso en Hojas de Producción posteriores a la Fecha de Cierre (Incluyendo a las que no se encuentran cerradas).
        '
        Dim WHojas As DataRow = GetSingle("SELECT SUM(CASE WHEN ISNULL(Lote1, 0) = 0 And ISNULL(Lote2, 0) = 0 And ISNULL(Lote3, 0) = 0 THEN Cantidad ELSE (Canti1 + Canti2 + Canti3) END) FROM Hoja h INNER JOIN Articulo a ON a.Codigo = h.Articulo WHERE Tipo = 'M' and Marca <> 'X' And h.FechaOrd >= a.OrdFechaCierre And h.Articulo = '" & _LoteMp & "'", empresa)

        If WHojas IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = formatonumerico(OrDefault(WHojas.Item(0), 0))
                .Item("Entrada") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Movimientos Varios.
        '
        Dim WMovVars As DataRow = GetSingle("SELECT sum(Cantidad) FROM MovVar WHERE Tipo = 'M' And MARCA <> 'X' And Movi = 'E' And Articulo = '" & _LoteMp & "'", empresa)

        If WMovVars IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = formatonumerico(OrDefault(WMovVars.Item(0), 0))
                .Item("Salida") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Movimientos Varios.
        '
        WMovVars = GetSingle("SELECT sum(Cantidad) FROM MovVar WHERE Tipo = 'M' And MARCA <> 'X' And Movi = 'S' And Articulo = '" & _LoteMp & "'", empresa)

        If WMovVars IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = formatonumerico(OrDefault(WMovVars.Item(0), 0))
                .Item("Entrada") = ""
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Guias.
        '
        Dim WGuiasInt As DataRow = GetSingle("SELECT SUM(Cantidad) FROM Guia WHERE Tipo = 'M' And Marca <> 'X' and movi = 'E' And Articulo = '" & _LoteMp & "'", empresa)

        If WGuiasInt IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = ""
                .Item("Entrada") = formatonumerico(OrDefault(WGuiasInt.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Guias.
        '
        WGuiasInt = GetSingle("SELECT SUM(Cantidad) FROM Guia WHERE Tipo = 'M' And Marca <> 'X' and movi = 'S' And Articulo = '" & _LoteMp & "'", empresa)

        If WGuiasInt IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = ""
                .Item("Salida") = formatonumerico(OrDefault(WGuiasInt.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Entradas en Movimientos de Laboratorio.
        '
        Dim WMovLab As DataRow = GetSingle("SELECT SUM(Cantidad) FROM MovLab WHERE Tipo = 'M' And MARCA <> 'X' And Articulo = '" & _LoteMp & "' And movi = 'E'", empresa)

        If WMovLab IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Salida") = ""
                .Item("Entrada") = formatonumerico(OrDefault(WMovLab.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        '
        ' Busco Salidas en Movimientos de Laboratorio.
        '
        WMovLab = GetSingle("SELECT SUM(Cantidad) FROM MovLab WHERE Tipo = 'M' And MARCA <> 'X' And Articulo = '" & _LoteMp & "' And movi = 'S'", empresa)

        If WMovLab IsNot Nothing Then
            Dim r = WMovimientos.NewRow
            With r
                .Item("Entrada") = ""
                .Item("Salida") = formatonumerico(OrDefault(WMovLab.Item(0), 0))
            End With
            WMovimientos.Rows.Add(r)
        End If

        Auxi = WCodMP

        If WTipoMat = "DK" Then Auxi = "DY-" & Microsoft.VisualBasic.Right(WCodMP, 7)
        If WTipoMat = "NS" Then Auxi = "DS-" & Microsoft.VisualBasic.Right(WCodMP, 7)
        If WTipoMat = "NQ" Then Auxi = "DQ-" & Microsoft.VisualBasic.Right(WCodMP, 7)

        If WFiltroMarca <> "" Then WFiltroMarca = " And e.Marca <> 'X' "

        Dim WEstadisticas As DataTable = GetAll("SELECT e.Tipo, e.LoteAdicional, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.TipoProDy = 'M' " & WFiltroMarca & " And e.ArticuloDy = '" & Auxi & "'", empresa)
        WMarca = ""
        For Each row As DataRow In WEstadisticas.Rows

            Dim XLotes(12, 2) As String
            Dim WTipo

            With row
                WTipo = OrDefault(.Item("Tipo"), 0)

                Select Case UCase(WTipoMat)
                    Case "DK", "NS", "NK"
                        If WTipo = 2 Then
                            WMarca = OrDefault(.Item("Marca"), "")
                            WLiberada = Math.Abs(Val(formatonumerico(OrDefault(.Item("Canti1"), "0"))))

                            Dim r = WMovimientos.NewRow
                            With r
                                .Item("Tipo") = "0"
                                .Item("Salida") = formatonumerico(WLiberada)
                                .Item("Entrada") = ""
                                .Item("Marca") = WMarca
                            End With
                            WMovimientos.Rows.Add(r)

                        End If
                    Case Else
                        If WTipo = 2 Or WTipo = 1 Then
                            WMarca = OrDefault(.Item("Marca"), "")

                            For i = 1 To 5
                                XLotes(i, 2) = OrDefault(.Item("Canti" & i), "")
                            Next

                            Dim WLoteAdicional As String = OrDefault(.Item("LoteAdicional"), "")
                            WLoteAdicional = WLoteAdicional.PadRight(98, "0")

                            XLotes(6, 2) = Mid$(WLoteAdicional, 9, 6)
                            XLotes(7, 2) = Mid$(WLoteAdicional, 23, 6)
                            XLotes(8, 2) = Mid$(WLoteAdicional, 37, 6)
                            XLotes(9, 2) = Mid$(WLoteAdicional, 51, 6)
                            XLotes(10, 2) = Mid$(WLoteAdicional, 65, 6)
                            XLotes(11, 2) = Mid$(WLoteAdicional, 79, 6)
                            XLotes(12, 2) = Mid$(WLoteAdicional, 93, 6)

                        End If
                End Select

            End With

            For i = 1 To 12

                WLiberada = Math.Abs(Val(formatonumerico(XLotes(i, 2))))

                If Val(WLiberada) = 0 Then Continue For

                Dim r = WMovimientos.NewRow
                With r

                    If Val(WTipo) = 2 Then
                        .Item("Entrada") = formatonumerico(WLiberada)
                        .Item("Salida") = ""
                    Else
                        .Item("Salida") = formatonumerico(WLiberada)
                        .Item("Entrada") = ""
                    End If

                End With
                WMovimientos.Rows.Add(r)

            Next

        Next

        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            WSaldo += Val(m.Item("Entrada"))
            WSaldo -= Val(m.Item("Salida"))
        Next

        Return Val(formatonumerico(WSaldo))

    End Function

    Private Function _CalcularSTOCKDEPRODUCTO(ByVal WTipo As String, ByVal WMPoPT As String, Optional ByRef WStock As Double = 0, Optional ByRef VerificaDatosHoja As String = "N") As String

        Dim SQLCnslt As String

        Dim StockString As String = ""
        Dim CantidadBloqueada As Double

        Select Case WTipo
            Case "M"

                WStock = _SaldoMPXCodigo(WMPoPT)
                
                StockString = formatonumerico(WStock, 3)
                
                'DETERMINA EL STOCK RESERVADO SEGUN LAS HOJAS QUE SE ENCUENTRAN AUN ABIERTAS, SI ES LA HOJA ACTUAL NO LA TOMA EN CUENTA.
                SQLCnslt = "SELECT SUM(h.Cantidad) FROM Hoja h INNER JOIN Articulo a ON a.Codigo = h.Articulo WHERE Articulo = '" & WMPoPT & "' AND Real = 0 AND Marca <> 'X' AND h.FechaOrd >= a.OrdFechaCierre AND h.Hoja <> '" & txtHojaProduccion.Text & "'"

                Dim tablahoja As DataRow = GetSingle(SQLCnslt)
                Dim WStockReservado As String = ""

                WStockReservado = formatonumerico(OrDefault(tablahoja.Item(0), 0), 3)

                If Val(WStockReservado) > 0 Then
                    MsgBox(String.Format("Stock Total:  {1} Kgs{0}Stock Reservado:  {2} Kgs{0}Stock Disponible:  {3} Kgs {0}", vbCrLf, WStock, Val(WStockReservado), WStock - Val(WStockReservado)))
                End If

                If VerificaDatosHoja <> "N" Then
                    'DESCUENTA EL STOCK YA INGRESADO EN LA HOJA
                    Dim StockEnHojaActual As Double = 0
                    For i = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1
                        If DGV_IngredientosHojaProduccion.Rows(i).Cells("MPoPT").Value = WMPoPT Then
                            StockEnHojaActual += Val(DGV_IngredientosHojaProduccion.Rows(i).Cells("Cantidad").Value)
                        End If
                    Next
                    WStock = WStock - StockEnHojaActual
                    'LE SUMO EL VALOR DE LA FILA PARA QUE PERMITA EDITAR
                    If VerificaDatosHoja = "SE" Then
                        WStock = WStock + CantidadDeFila
                    End If
                    StockString = formatonumerico(WStock, 3)
                End If

                'DESCUENTA EL STOCK DE MATERIA VENCIDO
                Dim Vencido As Double = 0
                Vencido = _CalcularVencido(WMPoPT)

                If Vencido > 0 Then
                    Dim mensaje As String = "Existe la materia prima " & WMPoPT & " la cantidad de : " & Vencido & " Kgs. vencidos." & vbCrLf & "Comuniquese con el laboratorio para su revalida"
                    MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                End If

                'DESCUENTA EL STOCK MATERIAL BLOQUEADO
                CantidadBloqueada = _CalcularBloqueo(WTipo, WMPoPT)
                If CantidadBloqueada < 0 Then
                    Dim mensaje As String
                    mensaje = "Existe la Materia Prima " & WMPoPT & " la cantidad de : " & CantidadBloqueada & " Kgs. Bloqueados" & vbCrLf & "Comuniquese con el laboratorio para su liberacion"
                    MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                End If

            Case "T"
                
                WStock = _SaldoPTXCodigo(WMPoPT)

                StockString = formatonumerico(WStock, 3)

                'DESCUENTA EL STOCK DE LAS HOJAS, SI ES LA HOJA ACTUAL IGNORA EL STOCK
                SQLCnslt = "SELECT SUM(h.Cantidad) FROM Hoja h inner join Terminado T on h.Terminado = T.Codigo WHERE h.Terminado = '" & WMPoPT & "' AND h.Real = 0 AND h.Marca <> 'X' and h.FechaOrd >= T.OrdFechaCierre"

                Dim tablahoja As DataRow = GetSingle(SQLCnslt)

                Dim WStockReservado As String = ""

                WStockReservado = formatonumerico(OrDefault(tablahoja.Item(0), 0), 3)

                If Val(WStockReservado) > 0 Then
                    MsgBox(String.Format("Stock Total:  {1} Kgs{0}Stock Reservado:  {2} Kgs{0}Stock Disponible:  {3} Kgs{0}", vbCrLf, WStock, Val(WStockReservado), WStock - Val(WStockReservado)))
                End If

                If VerificaDatosHoja <> "N" Then
                    'DESCUENTA EL STOCK YA INGRESADO EN LA HOJA
                    Dim StockEnHojaActual As Double = 0
                    For i = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1
                        If DGV_IngredientosHojaProduccion.Rows(i).Cells("MPoPT").Value = WMPoPT Then
                            StockEnHojaActual += Val(DGV_IngredientosHojaProduccion.Rows(i).Cells("Cantidad").Value)
                        End If
                    Next
                    WStock = WStock - StockEnHojaActual
                    'LE SUMO EL VALOR DE LA FILA PARA QUE PERMITA EDITAR
                    If VerificaDatosHoja = "SE" Then
                        WStock = WStock + CantidadDeFila

                    End If
                End If

                If Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "PT" Then
                    CantidadBloqueada = _CalcularBloqueo(WTipo, WMPoPT)
                    If CantidadBloqueada < 0 Then
                        Dim mensaje As String
                        mensaje = "Existe el producto " & WMPoPT & " la cantidad de : " & CantidadBloqueada & " Kgs. Bloqueados" & vbCrLf & "Comuniquese con el laboratorio para su liberacion"
                        MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                    End If
                End If

        End Select

        Return StockString

    End Function

    Private Function _CalcularStockTotalTerminado(ByVal codigo As String) As Double
        Dim stockAcumulado As Double = 0

        Dim SQLCnslt As String = "SELECT SumStock = SUM(h.Real) FROM Hoja h WHERE h.Marca <> 'X' AND H.Real > 0 AND H.Producto = '" & codigo & "' "
        Dim row As DataRow = GetSingle(SQLCnslt)

        If row IsNot Nothing Then stockAcumulado += OrDefault(row.Item("SumStock"), 0)

        SQLCnslt = "SELECT SumStock = SUM(g.Cantidad) FROM Guia g WHERE g.Marca <> 'X' AND g.Movi = 'E' AND g.Tipo = 'T' AND g.Terminado = '" & codigo & "' "
        row = GetSingle(SQLCnslt)

        If row IsNot Nothing Then stockAcumulado += OrDefault(row.Item("SumStock"), 0)

        Return stockAcumulado
    End Function


    Private Function _CalcularVencido(ByVal Codigo As String) As Double

        Dim VTO, FechaVTO As String
        Dim SQLCnslt As String
        Dim Vencido As Double = 0


        Dim tabla As New DataTable

        With tabla.Columns
            .Add("Laudo")
            .Add("Articulo")
            .Add("Cantidad")
            .Add("Saldo")
            .Add("Fecha")
            .Add("FechaVencimiento")
            .Add("Clave")
            .Add("Letra")

        End With

        If Codigo = "AA-100-100" Then
            Return Vencido
        End If
        'PROCESA VENCIDOS DE LAUDO

        SQLCnslt = "SELECT Marca, Articulo, Laudo, Saldo, Liberada, Fecha, FechaVencimiento, Clave FROM Laudo WHERE Articulo = '" & Codigo & "' AND Saldo <> 0 And Marca <> 'X'"

        Dim tablaLaudo As DataTable = GetAll(SQLCnslt)

        For Each row As Datarow In tablaLaudo.Rows
            With row

                Dim saldo As Double = OrDefault(.Item("Saldo"), 0)
                FechaVTO = OrDefault(.Item("Fechavencimiento"), "")

                tabla.Rows.Add(.Item("Laudo"), saldo, .Item("Articulo"), .Item("Liberada"), .Item("Fecha"), FechaVTO, .Item("Clave"), "L")

            End With
        Next

        'PROCESA VENCIDOS DE LAS GUIAS DE TRANSLADO INTERNO

        SQLCnslt = " SELECT Marca, Saldo, Lote, Codigo, Articulo, Cantidad, Saldo, Fecha, Clave, Tipo FROM Guia WHERE Articulo = '" & Codigo & "' AND Saldo <> 0 And Codigo < 900000 And Marca <> 'X' And Tipo = 'M'"

        Dim tablaGuias As DataTable = GetAll(SQLCnslt)

        For Each row As Datarow In tablaGuias.Rows
            With row

                Dim laudo As String = IIf(IsDBNull(.Item("Lote")), 0, .Item("Lote"))
                Dim Saldo As String = formatonumerico(IIf(IsDBNull(.Item("Saldo")), 0, .Item("Saldo")))

                tabla.Rows.Add(laudo, .Item("Articulo"), .Item("Cantidad"), Saldo, .Item("Fecha"), "", .Item("Clave"), "G")

            End With
        Next

        For i = 0 To tabla.Rows.Count - 1

            If tabla.Rows(i).Item("Letra") = "G" Then
                For j = 1 To 11
                    With tabla.Rows(i)
                        Dim base As String = _BuscarPlanta(i)

                        SQLCnslt = "SELECT Fecha, Fechavencimiento FROM " & base & ".dbo.LAUDO WHERE Laudo = '" & .Item("Laudo") & "' AND Articulo = '" & .Item("Articulo") & "'"
                        Dim Rowlaudo As DataRow = GetSingle(SQLCnslt)

                        If Rowlaudo IsNot Nothing Then

                            .Item("Fecha") = Rowlaudo.Item("Fecha")
                            .Item("FechaVencimiento") = IIf(IsDBNull(Rowlaudo.Item("Fechavencimiento")), "", Rowlaudo.Item("Fechavencimiento"))
                            Exit For

                        End If
                    End With
                Next
            End If

            With tabla.Rows(i)
                VTO = ""
                If .Item("FechaVencimiento") <> "" And .Item("FechaVencimiento") <> "  /  /    " And .Item("FechaVencimiento") <> " 00/00/0000" Then
                    If ValidaFecha(.Item("FechaVencimiento")) = "S" Then
                        VTO = .Item("FechaVencimiento")
                    End If
                End If

                If VTO = "" Then

                    Dim Meses As Integer = 0

                    SQLCnslt = "SELECT Meses FROM Articulo WHERE Codigo = '" & .Item("Articulo") & "'"
                    Dim rowArticulo As DataRow = GetSingle(SQLCnslt)
                    If rowArticulo IsNot Nothing Then
                        Meses = rowArticulo.Item("Meses")
                    End If

                    Dim Mes As Integer = Val(Mid$(.Item("Fecha"), 4, 2))
                    Dim Ano As Integer = Val(Microsoft.VisualBasic.Right$(.Item("Fecha"), 4))
                    For ZCiclo = 1 To Meses
                        Mes = Mes + 1
                        If Mes > 12 Then
                            Ano = Ano + 1
                            Mes = 1
                        End If
                    Next ZCiclo

                    Dim XMes As String = Mes.ToString()
                    Dim XAno As String = Ano.ToString()

                    If Val(Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)) <= 30 Then
                        If Val(XMes) = 2 And Val(Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)) > 28 Then
                            VTO = "28/" + XMes + "/" + XAno
                        Else
                            VTO = Microsoft.VisualBasic.Left$(.Item("Fecha"), 3) + XMes + "/" + XAno
                        End If
                    Else
                        If Val(XMes) = 2 Then
                            VTO = "28/" + XMes + "/" + XAno
                        Else
                            VTO = "30/" + XMes + "/" + XAno
                        End If
                    End If

                End If

                Dim MarcaVencida As String = ""

                If .Item("Fecha") <> "" Then

                    Do
                        If ValidaFecha(VTO) = "S" Then

                            Exit Do

                        Else
                            Dim Fec1 As String = VTO
                            Dim SumaDia As Integer = 1
                            Dim Fec2 = _Calcula_vencimiento(Fec1, SumaDia)
                            VTO = Fec2
                        End If
                    Loop


                    Dim ComparaI As String = mastxtFecha.Text
                    Dim ComparaII As String
                    If Microsoft.VisualBasic.Left$(VTO, 2) > "28" Then
                        ComparaII = "28" + Mid$(VTO, 3, 8)
                    Else
                        ComparaII = VTO
                    End If

                    Dim Dias As Integer = DateDiff("d", ComparaI, ComparaII)

                    If Val(Dias) < 0 Then
                        MarcaVencida = "S"
                        Vencido = Vencido + .Item("Saldo")
                    End If

                End If

                If .Item("Letra") = "L" Then
                    SQLCnslt = "UPDATE Laudo SET MarcaVencida = '" & MarcaVencida & "' WHERE Clave = '" & .Item("Clave") & "'"
                Else
                    SQLCnslt = "UPDATE Guia SET MarcaVencida = '" & MarcaVencida & "' WHERE Clave = '" & .Item("Clave") & "'"
                End If

                ExecuteNonQueries(SQLCnslt)

            End With
            Return Vencido
        Next

        Return Vencido

    End Function

    Private Function _Calcula_vencimiento(ByVal WFecha As String, ByVal Plazo As Integer) As String

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
        Dim WDia As String
        Dim aa As Integer
        Dim Ds(20) As Integer

        Ds(1) = 31
        Ds(2) = 28
        Ds(3) = 31
        Ds(4) = 30
        Ds(5) = 31
        Ds(6) = 30
        Ds(7) = 31
        Ds(8) = 31
        Ds(9) = 30
        Ds(10) = 31
        Ds(11) = 30
        Ds(12) = 31

        REM   DATA "0101","0105","2505", , ,"0907", ,"1210", ,"2512", , , , , ,

        Dg = 0
        WAno = Mid$(WFecha, 7, 4)
        Ano = Val(WAno)
        WMes = Mid$(WFecha, 4, 2)
        Mes = Val(WMes)
        WDia = Mid$(WFecha, 1, 2)
        Dia = Val(WDia)

        'CANTIDAD DE DIAS HASTA LA FECHA

        Dg = Dia + Plazo - 1

        Do
            For aa = Mes To 12
                If (Ano Mod 4 = 0) And Mes = 2 Then Ds(2) = 29 Else Ds(2) = 28
                If Dg <= Ds(aa) Then Exit Do
                Dg = Dg - Ds(aa)
            Next aa
            Ano = Ano + 1
            Mes = 1
        Loop

        Dia = Dg
        WDia$ = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Dia), 2, Len(Str$(Dia)) - 1), 2)

        Mes = aa
        WMes = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Mes), 2, Len(Str$(Mes)) - 1), 2)

        WAno = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Ano), 2, Len(Str$(Ano)) - 1), 4)

        Return WDia + "/" + WMes + "/" + WAno

    End Function

    Private Function _BuscarPlanta(ByVal numero As Integer) As String
        If numero = 1 Then
            Return "SurfactanSA"
        End If
        If numero = 2 Then
            Return "Surfactan_II"
        End If
        If numero = 3 Then
            Return "Surfactan_III"
        End If
        If numero = 4 Then
            Return "Surfactan_IV"
        End If
        If numero = 5 Then
            Return "Surfactan_V"
        End If
        If numero = 6 Then
            Return "Surfactan_VI"
        End If
        If numero = 7 Then
            Return "Surfactan_VII"
        End If
        If numero = 8 Then
            Return "PellitalSA"
        End If
        If numero = 9 Then
            Return "Pelitall_II"
        End If
        If numero = 10 Then
            Return "Pellital_III"
        End If
        Return "Pellital_V"
    End Function

    Private Function _CalcularBloqueo(ByVal WTipo As String, ByVal Codigo As String) As Double
        Dim Saldo As Double
        Dim CantidadBloqueada As Double = 0
        Dim SQLCnlst As String


        If WTipo = "M" Then
            'CALCULA LOS SALDOS BLOQUEADOS DE LAUDO
            SQLCnlst = "SELECT Saldo FROM Laudo WHERE Articulo = '" & Codigo & "' AND Saldo <> 0 AND Estado = 'N'"

            Dim tablaLaudo As DataTable = GetAll(SQLCnlst)

            If tablaLaudo.Rows.Count > 0 Then
                For i = 0 To tablaLaudo.Rows.Count - 1
                    Saldo = formatonumerico(IIf(IsDBNull(tablaLaudo.Rows(i).Item("Saldo")), 0, tablaLaudo.Rows(i).Item("Saldo")))
                    CantidadBloqueada = CantidadBloqueada + Saldo
                Next
            End If

            'CALCULA LOS SALDOS BLOQUEADOS DE LAS GUIAS

            SQLCnlst = "SELECT Saldo FROM Guia WHERE Articulo = '" & Codigo & "' AND Saldo <> 0 AND Estado = 'N'"

            Dim TablaGuia As DataTable = GetAll(SQLCnlst)

            If TablaGuia.Rows.Count > 0 Then
                For i = 0 To TablaGuia.Rows.Count - 1
                    Saldo = formatonumerico(IIf(IsDBNull(TablaGuia.Rows(i).Item("Saldo")), 0, TablaGuia.Rows(i).Item("Saldo")))
                    CantidadBloqueada = CantidadBloqueada + Saldo
                Next
            End If
        Else
            'CALCULA EL SALDO BLOQUEADO DE LAS HOJAS

            SQLCnlst = "SELECT Saldo FROM Hoja WHERE Producto = '" & Codigo & "' AND Saldo <> 0 AND Estado = 'N'"

            Dim TablaHoja As DataTable = GetAll(SQLCnlst)

            If TablaHoja.Rows.Count > 0 Then
                For i = 0 To TablaHoja.Rows.Count - 1
                    Saldo = formatonumerico(IIf(IsDBNull(TablaHoja.Rows(i).Item("Saldo")), 0, TablaHoja.Rows(i).Item("Saldo")))
                    CantidadBloqueada = CantidadBloqueada + Saldo
                Next
            End If

            'CALCULA EL SALDO BLOQUEADO DE LAS HOJAS

            SQLCnlst = "SELECT Saldo FROM Guia WHERE Terminado = '" & Codigo & "' AND Saldo <> 0 AND Estado = 'N'"

            Dim TablaGuia As DataTable = GetAll(SQLCnlst)

            If TablaGuia.Rows.Count > 0 Then
                For i = 0 To TablaGuia.Rows.Count - 1
                    Saldo = formatonumerico(IIf(IsDBNull(TablaGuia.Rows(i).Item("Saldo")), 0, TablaGuia.Rows(i).Item("Saldo")))
                    CantidadBloqueada = CantidadBloqueada + Saldo
                Next
            End If

        End If

        Return CantidadBloqueada

    End Function

    Private Sub mastxtMPoPT_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles mastxtMPoPT.KeyDown
        Dim SQLCnslt As String

        Select Case e.KeyData
            Case Keys.Enter
                If mastxtMPoPT.Text.Trim().Length = 12 Then
                    If cbxTipo.Text = "M" Then
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & mastxtMPoPT.Text & "'"
                    Else
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtMPoPT.Text & "'"
                    End If

                    Dim rowDescripcion As DataRow = GetSingle(SQLCnslt)

                    If rowDescripcion IsNot Nothing Then
                        txtDescripcionMPoPT.Text = rowDescripcion.Item("Descripcion")
                        txtCantidad.Focus()
                    End If
                End If

            Case Keys.Escape
                mastxtMPoPT.Text = ""
        End Select
    End Sub

    Private Sub DGV_IngredientosHojaProduccion_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGV_IngredientosHojaProduccion.RowHeaderMouseDoubleClick

        If MsgBox("¿Desea borrar la fila?", MsgBoxStyle.YesNo) = vbYes Then
            Dim filaBorrar As Integer = DGV_IngredientosHojaProduccion.CurrentRow.Index
            DGV_IngredientosHojaProduccion.Rows.RemoveAt(filaBorrar)
            _OrdenarIndiceFilas()
        End If


    End Sub

    Private Sub _OrdenarIndiceFilas()
        Dim indice As Integer = 1

        For i = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1
            DGV_IngredientosHojaProduccion.Rows(i).Cells("Linea").Value = indice
            indice = indice + 1
        Next
    End Sub


    Private Function _ObtenerNroHojaDisponible(ByVal NroHojaIngresada As String, Optional ByRef existe As String = "N") As String
        Dim SQLCnslt As String

        If Val(NroHojaIngresada) = 0 Then
            SQLCnslt = "SELECT Hoja = MAX(hoja) + 1 FROM Hoja"
            Dim row As DataRow = GetSingle(SQLCnslt)
            Return row.Item("Hoja")

        Else

            SQLCnslt = "SELECT Hoja FROM Hoja WHERE Hoja = '" & NroHojaIngresada & "'"
            Dim row As DataRow = GetSingle(SQLCnslt)
            If row IsNot Nothing Then
                existe = "S"
                Return row.Item("Hoja")

            Else
                Return "No permitido"
            End If

        End If

    End Function

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        Dim SQLCnslt As String
        Dim listaSQLCnslt As New List(Of String)

        For Each row As DataGridViewRow In DGV_IngredientosHojaProduccion.Rows
            If row.Cells("Cantidad").Value = "" Then
                MsgBox("No se puede grabar si no hay stock suficiente")
                Exit Sub
            End If
        Next

        If _ObtenerNroHojaDisponible(txtHojaProduccion.Text) = "No permitido" Then

            MsgBox("Para poder grabar una hoja nueva, debe ingresar un Nro. Hoja con valor 0")
            Exit Sub

        Else
            Dim existe As String = "N"
            txtHojaProduccion.Text = _ObtenerNroHojaDisponible(txtHojaProduccion.Text, existe)

            If existe = "S" Then

                SQLCnslt = "DELETE FROM Hoja WHERE Hoja = '" & txtHojaProduccion.Text & "'"

                listaSQLCnslt.Add(SQLCnslt)

            End If

        End If

        If Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "PT" Or Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "SE" Or Microsoft.VisualBasic.Left$(mastxtProducto.Text, 2) = "DW" Then

            If Codigo = 1 Or Codigo = 2 Or Codigo = 3 Or Codigo = 4 Then

                SQLCnslt = "SELECT Estado, EstadoI, EstadoII FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"

                Dim rowTerminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If rowTerminado IsNot Nothing Then

                    Dim WEstadoI As String = IIf(IsDBNull(rowTerminado.Item("Estado")), "", rowTerminado.Item("Estado"))
                    Dim WEstadoII As String = IIf(IsDBNull(rowTerminado.Item("EstadoI")), "", rowTerminado.Item("EstadoI"))
                    Dim WEstadoIII As String = IIf(IsDBNull(rowTerminado.Item("EstadoII")), "", rowTerminado.Item("EstadoII"))
                    If WEstadoI = "N" Or WEstadoII = "N" Or WEstadoIII = "N" Then
                        Dim mensaje As String = "El Producto Terminado no se encuentra autorizado para la Produccion"
                        If WEstadoI = "N" Then
                            mensaje = mensaje + vbCrLf + "(No se encuentra habilitada la formula)"
                        End If
                        If WEstadoII = "N" Then
                            mensaje = mensaje + vbCrLf + "(No se encuentra habilitada los procesos)"
                        End If
                        If WEstadoIII = "N" Then
                            mensaje = mensaje + vbCrLf + "(No se encuentra habilitada las especificaciones)"
                        End If
                        MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                        Exit Sub
                    End If

                End If

                Dim Suma As Double = 0

                Dim ZTipo As String = ""
                Dim Articulo As String
                Dim Terminado As String
                Dim ZCantidad As Double
                Dim Renglon As String = ""

                Dim auxiliar(50, 7)

                Dim WHoja As String = txtHojaProduccion.Text
                Dim WFecha As String = mastxtFecha.Text

                Dim XParam As String

                For iRow = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1

                    With DGV_IngredientosHojaProduccion.Rows(iRow)

                        Suma = Suma + 1

                        ZTipo = .Cells("Tipo").Value
                        If ZTipo = "M" Then

                            Articulo = UCase(.Cells("MPoPT").Value)
                            Terminado = "  -     -  "
                        Else
                            Terminado = UCase(.Cells("MPoPT").Value)
                            Articulo = "  -   -   "
                        End If

                        ZCantidad = Val(.Cells("Cantidad").Value)

                        Dim hoja As String

                        Renglon = .Cells("Linea").Value
                        Renglon = Renglon.PadLeft(2, "0")

                        hoja = txtHojaProduccion.Text.PadLeft(6, "0")

                        Dim WClave As String = hoja + Renglon
                        Dim WRenglon As String = Renglon
                        Dim WProducto As String = mastxtProducto.Text
                        Dim WTeorico As String = txtRendimientoTeorico.Text
                        Dim WReal As String = txtRendimientoReal.Text
                        Dim WFechaing As String = mastxtFechaIngreso.Text
                        Dim WFechaingord As String = Microsoft.VisualBasic.Right$(WFechaing, 4) + Mid$(WFechaing, 4, 2) + Microsoft.VisualBasic.Left$(WFechaing, 2)
                        Dim WTipo As String = ZTipo
                        Dim WTerminado As String = Terminado
                        Dim WArticulo As String = Articulo
                        Dim WCantidad As String = formatonumerico(ZCantidad, 3)
                        Dim WLote As String = "0"
                        Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")
                        Dim WImporte As String = ""
                        Dim WMarca As String = ""
                        Dim WSaldo As String = "0"

                        Dim WLote1 As String = ""
                        Dim WLote2 As String = ""
                        Dim WLote3 As String = ""
                        Dim WCanti1 As String = "0"
                        Dim WCanti2 As String = "0"
                        Dim WCanti3 As String = "0"
                        Dim WCosto1 As String = "0"
                        Dim WCosto2 As String = "0"
                        Dim WCosto3 As String = "0"

                        Dim XCosto1 As Double = 0
                        Dim XCosto2 As Double = 0
                        Dim XCosto3 As Double = 0

                        Select Case ZTipo
                            Case "T"

                                _Calcula_Costo_Produccion(Terminado, XCosto1, XCosto2, XCosto3)

                            Case "M"

                                SQLCnslt = "SELECT Costo1, Costo2, Costo3 FROM Articulo WHERE Codigo = '" & Articulo & "'"
                                Dim RowArticulo As DataRow = GetSingle(SQLCnslt)
                                If RowArticulo IsNot Nothing Then
                                    With RowArticulo
                                        XCosto1 = .Item("Costo1")
                                        XCosto2 = .Item("Costo2")
                                        XCosto3 = IIf(IsDBNull(.Item("Costo3")), "0", .Item("Costo3"))
                                    End With

                                End If

                        End Select

                        WCosto1 = formatonumerico(XCosto1)
                        WCosto2 = formatonumerico(XCosto2)
                        WCosto3 = formatonumerico(XCosto3)

                        XParam = "'" + WClave & "','" _
                                     + WHoja & "','" _
                                     + WRenglon & "','" _
                                     + WFecha & "','" _
                                     + WProducto & "','" _
                                     + WCantidad & "','" _
                                     + WTipo & "','" _
                                     + WLote & "','" _
                                     + WArticulo & "','" _
                                     + WTerminado & "','" _
                                     + WTeorico & "','" _
                                     + WReal & "','" _
                                     + WFechaing & "','" _
                                     + WFechaingord & "','" _
                                     + WDate & "','" _
                                     + WImporte & "','" _
                                     + WMarca & "','" _
                                     + WSaldo & "','" _
                                     + WLote1 & "','" & WCanti1 & "','" _
                                     + WLote2 & "','" & WCanti2 & "','" _
                                     + WLote3 & "','" & WCanti3 & "','" _
                                     + WCosto1 & "','" _
                                     + WCosto2 & "','" _
                                     + WCosto3 & "'"

                        SQLCnslt = "INSERT INTO Hoja(Clave, Hoja, Renglon, Fecha, Producto, Cantidad, Tipo, Lote, Articulo, Terminado, Teorico, Real, "
                        SQLCnslt = SQLCnslt & "Fechaing, Fechaingord, Wdate, Wimporte, Marca, Saldo, Lote1, Canti1, Lote2, Canti2, Lote3, Canti3, Costo1, "
                        SQLCnslt = SQLCnslt & "Costo2, Costo3) VALUES(" & XParam & ")"

                        listaSQLCnslt.Add(SQLCnslt)

                        Dim WFechaord As String = Microsoft.VisualBasic.Right$(WFecha, 4) + Mid$(WFecha, 4, 2) + Microsoft.VisualBasic.Left$(WFecha, 2)

                        SQLCnslt = "UPDATE Hoja SET Fechaord = '" & WFechaord & "', VersionI = '" & txtVersionFormulaV1.Text & "', VersionII = '" & txtProcedimientoV2.Text & "',  VersionIII = '" & txtEspecificacionV3.Text & "' WHERE Hoja = '" & txtHojaProduccion.Text & "'"

                        listaSQLCnslt.Add(SQLCnslt)

                        auxiliar(Renglon, 1) = WProducto
                        auxiliar(Renglon, 2) = WTerminado
                        auxiliar(Renglon, 3) = WArticulo
                        auxiliar(Renglon, 4) = WCantidad
                        auxiliar(Renglon, 5) = WReal
                        auxiliar(Renglon, 6) = WTeorico
                        auxiliar(Renglon, 7) = WTipo

                    End With
                Next

                If txtRendimientoReal.Text <> "" Then
                    If txtRendimientoReal.Text > 0 Then

                        For i = 1 To Val(Renglon)

                            Terminado = auxiliar(i, 2)
                            Articulo = auxiliar(i, 3)
                            Cantidad = auxiliar(i, 4)
                            Dim Teorico As String = auxiliar(i, 6)
                            tipo = auxiliar(i, 7)

                            Dim WProceso As String = ""
                            Dim WEntradas As String = ""
                            Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")

                            If i = 1 Then

                                SQLCnslt = "SELECT Proceso, Entradas FROM Terminado WHERE Codigo = '" & Terminado & "'"

                                rowTerminado = GetSingle(SQLCnslt)

                                If rowTerminado IsNot Nothing Then
                                    With rowTerminado
                                        WProceso = formatonumerico(.Item("Proceso") + Val(Teorico))
                                        WEntradas = formatonumerico(.Item("Entradas"))
                                    End With
                                End If

                                SQLCnslt = "UPDATE Terminado SET Entradas = '" & WEntradas & "', Proceso = '" & WProceso & "' WHERE Codigo = '" & Terminado & "'"

                                listaSQLCnslt.Add(SQLCnslt)

                            End If

                            Dim WSalidas As String

                            Select Case ZTipo
                                Case "M"

                                    SQLCnslt = "SELECT Salidas FROM Articulo WHERE Codigo = '" & Articulo & "'"

                                    Dim rowArticulo As DataRow = GetSingle(SQLCnslt)

                                    If rowArticulo IsNot Nothing Then
                                        With rowArticulo
                                            WSalidas = formatonumerico(.Item("Salidas") + Val(Cantidad))
                                        End With

                                        SQLCnslt = "UPDATE Articulo SET Salidas = '" & WSalidas & "', Wdate = '" & WDate & "' WHERE Codigo = '" & Articulo & "'"

                                        listaSQLCnslt.Add(SQLCnslt)

                                    End If

                                Case "T"

                                    SQLCnslt = "SELECT Salidas FROM Terminado WHERE Codigo = '" & Terminado & "'"

                                    rowTerminado = GetSingle(SQLCnslt)

                                    If rowTerminado IsNot Nothing Then
                                        WSalidas = formatonumerico(rowTerminado.Item("Salidas") + Val(Cantidad))

                                        SQLCnslt = "UPDATE Terminado SET Salidas = '" & WSalidas & "', Wdate = '" & WDate & "' WHERE Codigo = '" & Terminado & "'"

                                        listaSQLCnslt.Add(SQLCnslt)

                                    End If

                            End Select

                        Next

                    End If

                End If
            End If
        End If

        If listaSQLCnslt.Count > 0 Then
            ExecuteNonQueries(listaSQLCnslt.ToArray())
        End If

        _LimpiarForm()

    End Sub

    Private Sub _Calcula_Costo_Produccion(ByVal Producto As String, ByRef XCosto1 As Double, ByRef XCosto2 As Double, ByRef XCosto3 As Double)

        Dim Auxiliar(50, 3) As String
        Dim Renglon As Integer = 0

        Dim SQLCnslt As String

        SQLCnslt = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion WHERE Terminado = '" & Producto & "' ORDER BY Clave"

        Dim TablaComposicion As DataTable = GetAll(SQLCnslt)

        If TablaComposicion.Rows.Count > 0 Then

            For i = 0 To TablaComposicion.Rows.Count - 1
                With TablaComposicion.Rows(i)
                    If .Item("Tipo") = "M" Then
                        Renglon = Renglon + 1
                        Auxiliar(Renglon, 1) = .Item("Articulo1")
                        Auxiliar(Renglon, 2) = .Item("Cantidad")
                        Auxiliar(Renglon, 3) = 1
                    End If
                End With
            Next

        End If

        For ZDa = 1 To Renglon
            Dim ZArticulo = Auxiliar(ZDa, 1)
            Dim ZCantidad = Auxiliar(ZDa, 2)
            Dim ZWVector = Auxiliar(ZDa, 3)

            SQLCnslt = "SELECT Costo1, Costo2, Costo3 FROM Articulo WHERE Codigo = '" & ZArticulo & "'"
            Dim RowArticulo As DataRow = GetSingle(SQLCnslt)

            Dim WCos1, WCos2, WCos3 As Double

            If RowArticulo IsNot Nothing Then
                With RowArticulo
                    WCos1 = (ZCantidad * .Item("Costo2") * Val(ZWVector))
                    XCosto1 = XCosto1 + WCos1
                    WCos2 = (ZCantidad * .Item("Costo1") * Val(ZWVector))
                    XCosto2 = XCosto2 + WCos2
                    WCos3 = IIf(IsDBNull(.Item("Costo3")), "0", .Item("Costo3"))
                    WCos3 = (ZCantidad * WCos3 * Val(ZWVector))
                    XCosto3 = XCosto3 + WCos3
                End With

            End If
        Next

        formatonumerico(XCosto1)
        formatonumerico(XCosto2)
        formatonumerico(XCosto3)

    End Sub

    Private Sub btnBlockNotas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBlockNotas.Click
        Try
            If pnlAgenda.Visible = False Then
                If File.Exists("\\193.168.0.2\g$\vb\NET\Sistema de Laboratorio\BlockNotas\H" + txtHojaProduccion.Text + ".rtf") Then
                    rtxtAgenda.LoadFile("\\193.168.0.2\g$\vb\NET\Sistema de Laboratorio\BlockNotas\H" + txtHojaProduccion.Text + ".rtf", 0)
                Else
                    'rtxtAgenda.LoadFile("blanco.rtf", 0)
                    rtxtAgenda.LoadFile("\\193.168.0.2\g$\vb\NET\Sistema de Laboratorio\BlockNotas\blanco.rtf", 1)
                End If
                pnlAgenda.Visible = True
                rtxtAgenda.Focus()

            Else

                If PermisoGrabar Then
                    If Val(txtHojaProduccion.Text) > 0 Then
                        rtxtAgenda.SaveFile("\\193.168.0.2\g$\vb\NET\Sistema de Laboratorio\BlockNotas\H" + txtHojaProduccion.Text + ".rtf", 0)
                    End If

                End If
                
                pnlAgenda.Visible = False

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click
        txtAyuda.Text = ""
        pnlAyuda.Visible = True
        cbxAyuda.SelectedIndex = 0

        Dim SQLCnslt As String = "SELECT CodigoAyuda = Codigo, DescripcionAyuda = Descripcion FROM Articulo"

        Dim tabla As DataTable = GetAll(SQLCnslt)

        DGV_Ayuda.DataSource = tabla
    End Sub

    Private Sub cbxAyuda_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cbxAyuda.DropDownClosed
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

    Private Sub txtAyuda_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtAyuda.KeyUp
        Dim tabla As DataTable = TryCast(DGV_Ayuda.DataSource, DataTable)

        tabla.DefaultView.RowFilter = "CodigoAyuda LIKE '%" & txtAyuda.Text & "%' or DescripcionAyuda LIKE '%" & txtAyuda.Text & "%'"
        DGV_Ayuda.DataSource = tabla
    End Sub

    Private Sub DGV_Ayuda_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGV_Ayuda.CellMouseDoubleClick

        If cbxAyuda.SelectedIndex = 0 Then
            cbxTipo.SelectedIndex = 0

        Else
            cbxTipo.SelectedIndex = 1
        End If
        mastxtMPoPT.Text = DGV_Ayuda.CurrentRow.Cells("CodigoAyuda").Value
        txtDescripcionMPoPT.Text = DGV_Ayuda.CurrentRow.Cells("DescripcionAyuda").Value


        pnlAyuda.Visible = False



    End Sub

    Private Sub btnpnlAyudaVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnpnlAyudaVolver.Click
        pnlAyuda.Visible = False
        txtAyuda.Text = ""
    End Sub

    Private Sub btnBajaHoja_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBajaHoja.Click
        If Val(txtRendimientoReal.Text) = 0 Then
            Dim SQLCnslt As String

            SQLCnslt = "SELECT hoja, Real FROM Hoja WHERE Hoja = '" & txtHojaProduccion.Text & "'"

            Dim rowHoja As DataRow = GetSingle(SQLCnslt)

            If rowHoja IsNot Nothing Then

                If rowHoja.Item("Real") = 0 Then
                    SQLCnslt = "DELETE FROM Hoja WHERE Hoja = '" & txtHojaProduccion.Text & "'"

                    ExecuteNonQueries(SQLCnslt)

                    _LimpiarForm()
                End If


            End If

        End If
    End Sub


End Class