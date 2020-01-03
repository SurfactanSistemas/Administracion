Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports Laboratorio

Public Class IngresoActualizacionHojaProduccionFarma

    Dim SaldoAnterior As Double

    Dim lineaSeleccionada As String

    Dim CantidadDeFila As Double




    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub IngresoActualizacionHojaProduccionFarma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbxTipo.SelectedIndex = 0
        pnlLotes.Visible = False
        mastxtFecha.Text = Date.Today
        txtHojaProduccion.Text = 0
        txtVersionFormulaV1.Enabled = False
        txtProcedimientoV2.Enabled = False
        txtEspecificacionV3.Enabled = False
        pnlAgenda.Visible = False
        pnlAyuda.Visible = False


    End Sub

    Private Sub IngresoActualizacionHojaProduccionFarma_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtHojaProduccion.Focus()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHojaProduccion.KeyPress, txtVersionFormulaV1.KeyPress, txtProcedimientoV2.KeyPress, txtPartLote3.KeyPress, txtPartLote2.KeyPress, txtPartLote1.KeyPress, txtEspecificacionV3.KeyPress, txtEquipo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRendimientoTeorico.KeyPress, txtRendimientoReal.KeyPress, txtCantLote3.KeyPress, txtCantLote2.KeyPress, txtCantLote1.KeyPress, txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtHojaProduccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHojaProduccion.KeyDown

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
        Dim Auxiliar As String
        Dim XLote As String
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


    Private Sub cbxTipo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTipo.DropDownClosed
        If cbxTipo.Text = "M" Then
            lblMPoPT.Text = "Materia Prima"
            mastxtMPoPT.Mask = ">LL-000-000"
        Else
            lblMPoPT.Text = "Producto Terminado"
            mastxtMPoPT.Mask = ">LL-00000-000"
        End If
    End Sub

    Private Sub cbxTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTipo.SelectedIndexChanged
        If cbxTipo.Text = "M" Then
            lblMPoPT.Text = "Materia Prima"
            mastxtMPoPT.Mask = ">LL-000-000"
        Else
            lblMPoPT.Text = "Producto Terminado"
            mastxtMPoPT.Mask = ">LL-00000-000"
        End If
    End Sub


    Private Sub DGV_IngredientosHojaProduccion_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_IngredientosHojaProduccion.CellDoubleClick

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
            btnEditarFila.Enabled = True
        End With
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs, Optional ByRef Permitir As String = "N") Handles txtCantidad.KeyDown

        Dim SQLCnslt As String
        Dim stock As Double



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

    Private Sub btnNuevaFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaFila.Click

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

    Private Sub btnEditarFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarFila.Click

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

            If Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text <> "" Then
                If Val(Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text) <> 0 Then

                    If Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text = "" Then
                        listaMensaje.Add("Se ingreso el lote: " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & ", pero no una cantidad")
                    End If
                    If Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text) = 0 Then
                        listaMensaje.Add("Se ingreso el lote: " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & ", pero no una cantidad")
                    End If
                End If
            End If

            If Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text <> "" Then
                If Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text) <> 0 Then

                    If Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text = "" Then
                        listaMensaje.Add("Se ingreso el Cantidad: " & Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text & ", pero no una Lote")
                    End If
                    If Val(Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text) = 0 Then
                        listaMensaje.Add("Se ingreso el Cantidad: " & Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text & ", pero no una Lote")
                    End If
                End If
            End If


        Next

        If listaMensaje.Count > 0 Then

            MsgBox(String.Join(vbCrLf, listaMensaje))
            Return "No graba"

        End If


        For i As Integer = 1 To 3

            If Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text <> "" Then
                If Val(Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text) = 0 Then

                    Continue For
                End If
            Else
                Continue For
            End If


            If cbxTipo.Text = "M" Then

                SQLCnslt = "SELECT Saldo FROM Laudo WHERE Articulo = '" & mastxtMPoPT.Text & "' AND Laudo = '" & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 "

                Dim ROWLaudo As DataRow = GetSingle(SQLCnslt)

                If ROWLaudo IsNot Nothing Then

                    StockDisponible = ROWLaudo.Item("Saldo") - Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                    If StockDisponible < 0 Then
                        listaMensaje.Add("Saldo insuficiente para el Lote " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                    End If


                Else

                    SQLCnslt = "SELECT Saldo FROM Guia WHERE Articulo = '" & mastxtMPoPT.Text & "' AND Lote = '" & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 AND Movi = 'E'"

                    Dim ROWGuia As DataRow = GetSingle(SQLCnslt)

                    If ROWGuia IsNot Nothing Then

                        StockDisponible = ROWGuia.Item("Saldo") - Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                        If StockDisponible < 0 Then
                            listaMensaje.Add("Saldo insuficiente para el lote " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                        End If
                    Else
                        listaMensaje.Add("No se encuentra el Lote de la Materia Prima: " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)

                    End If

                End If

            Else

                SQLCnslt = "SELECT Saldo FROM Hoja WHERE Producto = '" & mastxtMPoPT.Text & "' AND  Hoja = '" & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 "

                Dim ROWHoja As DataRow = GetSingle(SQLCnslt)

                If ROWHoja IsNot Nothing Then

                    StockDisponible = ROWHoja.Item("Saldo") - Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                    If StockDisponible < 0 Then
                        listaMensaje.Add("Saldo insuficiente para el lote " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                    End If


                Else

                    SQLCnslt = "SELECT Saldo FROM Guia WHERE Terminado = '" & mastxtMPoPT.Text & "' AND Lote = '" & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text & "' AND Marca <> 'X' AND Saldo > 0 AND Movi = 'E'"

                    Dim ROWGuia As DataRow = GetSingle(SQLCnslt)

                    If ROWGuia IsNot Nothing Then

                        StockDisponible = ROWGuia.Item("Saldo") - Val(Me.Controls("pnlLotes").Controls("txtCantLote" & i).Text)

                        If StockDisponible < 0 Then
                            listaMensaje.Add("Saldo insuficiente para el lote " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)
                        End If
                    Else
                        listaMensaje.Add("No se encuentra el Lote de la Producto Terminado: " & Me.Controls("pnlLotes").Controls("txtPartLote" & i).Text)

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



    Private Sub txtPartLote1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartLote1.KeyDown
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

    Private Sub txtCantLote1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantLote1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote1.Text = formatonumerico(txtCantLote1.Text)
                txtPartLote2.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtPartLote2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartLote2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote2.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtCantLote2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantLote2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote2.Text = formatonumerico(txtCantLote2.Text)
                txtPartLote3.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtPartLote3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartLote3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote3.Focus()
            Case Keys.Escape

        End Select

    End Sub

    Private Sub txtCantLote3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantLote3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCantLote3.Text = formatonumerico(txtCantLote3.Text)
                btnEditarFila_Click(Nothing, Nothing)
            Case Keys.Escape

        End Select

    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _LimpiarForm()
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then
                    mastxtProducto.Focus()
                End If
            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select

    End Sub



    Private Sub mastxtProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtProducto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtProducto.Text.Trim().Length = 12 Then
                    Dim SQLCnslt = "SELECT Descripcion, Estado, EstadoI, EstadoII, Version, VersionI, VersionII FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"
                    Dim rowTerminado As DataRow = GetSingle(SQLCnslt)

                    If rowTerminado IsNot Nothing Then

                        If Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "PT" Or Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "SE" Or Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "DW" Then
                            If Val(Operador.Codigo) = 1 Or Val(Operador.Codigo) = 2 Or Val(Operador.Codigo) = 3 Or Val(Operador.Codigo) = 4 Then
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

    Private Sub txtEquipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEquipo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtRendimientoTeorico.Focus()
            Case Keys.Escape
                txtEquipo.Text = ""
        End Select
    End Sub

    Private Sub txtRendimientoTeorico_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRendimientoTeorico.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtRendimientoTeorico.Text = formatonumerico(txtRendimientoTeorico.Text)
                mastxtMPoPT.Focus()

                If Val(txtRendimientoTeorico.Text) > 0 Then
                    If mastxtProducto.Text <> "" Then
                        If _BuscarProducto() = "S" Then
                            _BuscarComposicion()
                        End If
                    End If
                End If


            Case Keys.Escape
                txtRendimientoTeorico.Text = ""
        End Select
    End Sub


    Private Function _BuscarProducto() As String
        Dim SQLCnslt As String

        SQLCnslt = "SELECT Codigo FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"

        Dim row As DataRow = GetSingle(SQLCnslt)

        If row IsNot Nothing Then
            Return "S"
        Else
            Return "N"
        End If

    End Function

    Private Sub _BuscarComposicion()
        Dim SQLCnslt As String

        SQLCnslt = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion WHERE Terminado = '" & mastxtProducto.Text & "' ORDER BY Clave"

        Dim TablaComposicion As DataTable = GetAll(SQLCnslt)
        Dim Renglon As Integer = 0
        Dim Descripcion As String

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


            Dim Tipo, MPoPT, Cantidad As String

            Dim CantidadBloqueada As Double


            For Each row As DataGridViewRow In DGV_IngredientosHojaProduccion.Rows
                With row
                    Tipo = .Cells("Tipo").Value
                    MPoPT = .Cells("MPoPT").Value
                    Cantidad = .Cells("Cantidad").Value
                End With

                Dim WStock As Double = 0
                Dim StockString As String

                StockString = _CalcularSTOCKDEPRODUCTO(Tipo, MPoPT, WStock)


                With row

                    If Val(Cantidad) <= WStock Then

                        row.Cells("Cantidad").Value = Cantidad

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

    Private Function _CalcularSTOCKDEPRODUCTO(ByVal Tipo As String, ByVal MPoPT As String, Optional ByRef WStock As Double = 0, Optional ByRef VerificaDatosHoja As String = "N") As String

        Dim SQLCnslt As String

        Dim StockString As String
        Dim StockReservadoEnHojas As Double = 0
        Dim CantidadBloqueada As Double

        Select Case Tipo
            Case "M"




                SQLCnslt = "SELECT Descripcion, Inicial, Entradas, Salidas FROM Articulo WHERE Codigo = '" & MPoPT & "'"
                Dim RowArticulo As DataRow = GetSingle(SQLCnslt)

                If RowArticulo IsNot Nothing Then
                    WStock = Val(RowArticulo.Item("Inicial") + RowArticulo.Item("Entradas") - RowArticulo.Item("Salidas"))
                    StockString = formatonumerico(WStock, 3)
                End If




                'DESCUENTA EL STOCK DE LAS HOJAS, SI ES LA HOJA ACTUAL IGNORA EL STOCK

                SQLCnslt = "SELECT Cantidad, Hoja FROM Hoja WHERE Articulo = '" & MPoPT & "' AND Real = 0 AND Marca <> 'X'"

                Dim tablahoja As DataTable = GetAll(SQLCnslt)

                If tablahoja.Rows.Count > 0 Then

                    For i = 0 To tablahoja.Rows.Count - 1
                        If tablahoja.Rows(i).Item("Hoja") <> txtHojaProduccion.Text Then

                            StockReservadoEnHojas += tablahoja.Rows(i).Item("Cantidad")

                        End If
                    Next
                    WStock = WStock - StockReservadoEnHojas
                    StockString = formatonumerico(WStock, 3)
                End If


                If VerificaDatosHoja <> "N" Then
                    'DESCUENTA EL STOCK YA INGRESADO EN LA HOJA
                    Dim StockEnHojaActual As Double = 0
                    For i = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1
                        If DGV_IngredientosHojaProduccion.Rows(i).Cells("MPoPT").Value = MPoPT Then
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
                Vencido = _CalcularVencido(MPoPT)

                If Vencido > 0 Then
                    Dim mensaje As String = "Existe la materia prima " & MPoPT & " la cantidad de : " & Vencido & " Kgs. vencidos." & vbCrLf & "Comuniquese con el laboratorio para su revalida"
                    MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                    WStock = WStock - Vencido
                    StockString = formatonumerico(WStock, 3)
                End If

                'DESCUENTA EL STOCK MATERIAL BLOQUEADO
                If Microsoft.VisualBasic.Left(mastxtMPoPT.Text, 2) = "PT" Then
                    CantidadBloqueada = _CalcularBloqueo(Tipo, MPoPT)
                    If CantidadBloqueada < 0 Then
                        Dim mensaje As String
                        mensaje = "Existe la Materia Prima " & MPoPT & " la cantidad de : " & CantidadBloqueada & " Kgs. Bloqueados" & vbCrLf & "Comuniquese con el laboratorio para su liberacion"
                        MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                        WStock = WStock - CantidadBloqueada
                        StockString = formatonumerico(WStock, 3)
                    End If
                End If





            Case "T"
                SQLCnslt = "SELECT Descripcion, Inicial, Entradas, Salidas FROM Terminado WHERE Codigo = '" & MPoPT & "'"
                Dim RowTerminado As DataRow = GetSingle(SQLCnslt)

                If RowTerminado IsNot Nothing Then
                    WStock = RowTerminado.Item("Inicial") + RowTerminado.Item("Entradas") - RowTerminado.Item("Salidas")
                    'StockString = formatonumerico(WStock, 3)
                End If



                'DESCUENTA EL STOCK DE LAS HOJAS, SI ES LA HOJA ACTUAL IGNORA EL STOCK

                SQLCnslt = "SELECT Cantidad, Hoja FROM Hoja WHERE Terminado = '" & MPoPT & "' AND Real = 0 AND Marca <> 'X'"

                Dim tablahoja As DataTable = GetAll(SQLCnslt)

                If tablahoja.Rows.Count > 0 Then

                    For i = 0 To tablahoja.Rows.Count - 1
                        If tablahoja.Rows(i).Item("Hoja") <> txtHojaProduccion.Text Then

                            StockReservadoEnHojas += tablahoja.Rows(i).Item("Cantidad")

                        End If
                    Next
                    WStock = WStock - StockReservadoEnHojas
                End If




                If VerificaDatosHoja <> "N" Then
                    'DESCUENTA EL STOCK YA INGRESADO EN LA HOJA
                    Dim StockEnHojaActual As Double = 0
                    For i = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1
                        If DGV_IngredientosHojaProduccion.Rows(i).Cells("MPoPT").Value = MPoPT Then
                            StockEnHojaActual += Val(DGV_IngredientosHojaProduccion.Rows(i).Cells("Cantidad").Value)
                        End If
                    Next
                    WStock = WStock - StockEnHojaActual
                    'LE SUMO EL VALOR DE LA FILA PARA QUE PERMITA EDITAR
                    If VerificaDatosHoja = "SE" Then
                        WStock = WStock + CantidadDeFila
                    End If
                End If



                StockString = formatonumerico(WStock, 3)


                If Microsoft.VisualBasic.Left(mastxtProducto.Text, 2) = "PT" Then
                    CantidadBloqueada = _CalcularBloqueo(Tipo, MPoPT)
                    If CantidadBloqueada < 0 Then
                        Dim mensaje As String
                        mensaje = "Existe el producto " & MPoPT & " la cantidad de : " & CantidadBloqueada & " Kgs. Bloqueados" & vbCrLf & "Comuniquese con el laboratorio para su liberacion"
                        MsgBox(mensaje, 0, "Ingreso de Hoja de Produccion")
                        WStock = WStock - CantidadBloqueada
                        StockString = formatonumerico(WStock, 3)
                    End If
                End If



        End Select


        Return StockString

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
            Exit Function
        End If
        'PROCESA VENCIDOS DE LAUDO

        SQLCnslt = "SELECT Marca, Articulo, Laudo, Saldo, Liberada, Fecha, FechaVencimiento, Clave FROM Laudo WHERE Articulo = '" & Codigo & "' AND Saldo <> 0"

        Dim tablaLaudo As DataTable = GetAll(SQLCnslt)

        If tablaLaudo.Rows.Count > 0 Then
            For i = 0 To tablaLaudo.Rows.Count - 1
                If tablaLaudo.Rows(i).Item("Marca") <> "X" Then
                    If tablaLaudo.Rows(i).Item("Saldo") <> 0 Then

                        Dim saldo As Double = formatonumerico(IIf(tablaLaudo.Rows(i).Item("Saldo"), 0, tablaLaudo.Rows(i).Item("Saldo")))
                        FechaVTO = IIf(IsDBNull(tablaLaudo.Rows(i).Item("Fechavencimiento")), "", tablaLaudo.Rows(i).Item("Fechavencimiento"))
                        With tablaLaudo.Rows(i)
                            tabla.Rows.Add(.Item("Laudo"), saldo, .Item("Articulo"), .Item("Liberada"), .Item("Fecha"), FechaVTO, .Item("Clave"), "L")
                        End With

                    End If
                End If
            Next
        End If

        'PROCESA VENCIDOS DE LAS GUIAS DE TRANSLADO INTERNO

        SQLCnslt = " SELECT Marca, Saldo, Lote, Codigo, Articulo, Cantidad, Saldo, Fecha, Clave, Tipo FROM Guia WHERE Articulo = '" & Codigo & "' AND Saldo <> 0"

        Dim tablaGuias As DataTable = GetAll(SQLCnslt)

        If tablaGuias.Rows.Count > 0 Then
            For i = 0 To tablaGuias.Rows.Count - 1

                With tablaGuias.Rows(i)

                    If .Item("Marca") <> "X" And .Item("Saldo") <> 0 And .Item("Codigo") < 900000 Then

                        If .Item("Tipo") = "M" Then

                            Dim laudo As String = IIf(IsDBNull(.Item("Lote")), 0, .Item("Lote"))
                            Dim Saldo As String = formatonumerico(IIf(IsDBNull(.Item("Saldo")), 0, .Item("Saldo")))

                            tabla.Rows.Add(laudo, .Item("Articulo"), .Item("Cantidad"), Saldo, .Item("Fecha"), "", .Item("Clave"), "G")

                        End If

                    End If

                End With
            Next
        End If


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
                Dim FechaOrd As String = Microsoft.VisualBasic.Right$(.Item("Fecha"), 4) + Mid$(.Item("Fecha"), 4, 2) + Microsoft.VisualBasic.Left$(.Item("Fecha"), 2)
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

                    XMes.PadLeft(2, "0")
                    XAno.PadLeft(6, "0")

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




    End Function


    Private Function _Calcula_vencimiento(ByVal WFecha As String, ByVal Plazo As Integer) As String

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
        Dim WDia As String
        Dim Di As Integer
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

    Private Function _CalcularBloqueo(ByVal Tipo As String, ByVal Codigo As String) As Double
        Dim Saldo As Double
        Dim CantidadBloqueada As Double = 0
        Dim SQLCnlst As String


        If Tipo = "M" Then
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

    Private Sub mastxtMPoPT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtMPoPT.KeyDown
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

    Private Sub DGV_IngredientosHojaProduccion_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_IngredientosHojaProduccion.RowHeaderMouseDoubleClick

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




    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

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





            If Operador.Codigo = 1 Or Operador.Codigo = 2 Or Operador.Codigo = 3 Or Operador.Codigo = 4 Then

                SQLCnslt = "SELECT Estado, EstadoI, EstadoII FROM Terminado WHERE Codigo = '" & mastxtProducto.Text & "'"

                Dim rowTerminado As DataRow = GetSingle(SQLCnslt)

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

                Dim tipo As String
                Dim Articulo As String
                Dim Terminado As String
                Dim Cantidad As Double
                Dim Renglon As String

                Dim auxiliar(50, 7)

                Dim WHoja As String = txtHojaProduccion.Text
                Dim WFecha As String = mastxtFecha.Text

                Dim XParam As String

                For iRow = 0 To DGV_IngredientosHojaProduccion.Rows.Count - 1

                    With DGV_IngredientosHojaProduccion.Rows(iRow)

                        Suma = Suma + 1


                        tipo = .Cells("Tipo").Value
                        If tipo = "M" Then

                            Articulo = UCase(.Cells("MPoPT").Value)
                            Terminado = "  -     -  "
                        Else
                            Terminado = UCase(.Cells("MPoPT").Value)
                            Articulo = "  -   -   "
                        End If

                        Cantidad = Val(.Cells("Cantidad").Value)





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
                        Dim WTipo As String = tipo
                        Dim WTerminado As String = Terminado
                        Dim WArticulo As String = Articulo
                        Dim WCantidad As String = formatonumerico(Cantidad, 3)
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

                        Select Case tipo
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

                            Dim Producto As String = auxiliar(i, 1)
                            Terminado = auxiliar(i, 2)
                            Articulo = auxiliar(i, 3)
                            Cantidad = auxiliar(i, 4)
                            Dim Real As String = auxiliar(i, 5)
                            Dim Teorico As String = auxiliar(i, 6)
                            tipo = auxiliar(i, 7)


                            Dim WProceso As String
                            Dim WEntradas As String
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

                            Select Case tipo
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






    Private Sub btnBlockNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlockNotas.Click
        Try
            If pnlAgenda.Visible = False Then
                If File.Exists("H" + txtHojaProduccion.Text + ".rtf") Then
                    rtxtAgenda.LoadFile("H" + txtHojaProduccion.Text + ".rtf", 0)
                Else
                    rtxtAgenda.LoadFile("blanco.rtf", 0)
                End If
                ' rtxtAgenda.LoadFile("blanco.rtf", 0)
                'rtxtAgenda.LoadFile("H" + txtHojaProduccion.Text + ".rtf", 0)
                pnlAgenda.Visible = True
                rtxtAgenda.Focus()


            Else

                rtxtAgenda.SaveFile("H" + txtHojaProduccion.Text + ".rtf", 0)
                pnlAgenda.Visible = False

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        txtAyuda.Text = ""
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
            cbxTipo.SelectedIndex = 0

        Else
            cbxTipo.SelectedIndex = 1
        End If
        mastxtMPoPT.Text = DGV_Ayuda.CurrentRow.Cells("CodigoAyuda").Value
        txtDescripcionMPoPT.Text = DGV_Ayuda.CurrentRow.Cells("DescripcionAyuda").Value


        pnlAyuda.Visible = False



    End Sub

    Private Sub btnpnlAyudaVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpnlAyudaVolver.Click
        pnlAyuda.Visible = False
        txtAyuda.Text = ""
    End Sub

    Private Sub btnBajaHoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBajaHoja.Click
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
