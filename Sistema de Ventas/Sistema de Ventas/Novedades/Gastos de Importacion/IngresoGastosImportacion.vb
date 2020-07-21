Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class IngresoGastosImportacion : Implements IConsulta_GasImportacion
    Dim BaseOrdenCompra As String = ""
    Dim WProveedor As String = ""


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Concepto.KeyPress, txt_OrdenCompra.KeyPress, txt_Carpeta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Importe.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub





    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click

        txt_Carpeta.Text = ""
        txt_OrdenCompra.Text = ""
        txt_Origen.Text = ""
        txt_Fecha.Text = ""


        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")

        txt_fila.Text = ""
        txt_Concepto.Text = ""
        txt_Descripcion.Text = ""
        txt_Importe.Text = ""

        cbx_TipoCosto.SelectedIndex = 0
        cbx_Estado.SelectedIndex = 0
        cbx_Moneda.SelectedIndex = 0
        cbx_Transporte.SelectedIndex = 0

        DGV_GastosImportacion.Rows.Clear()

        Dim SQLCnslt As String = "SELECT MaxCarpeta = MAX(Carpeta) FROM MovGas"

        Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If row IsNot Nothing Then
            txt_Carpeta.Text = row.Item("MaxCarpeta") + 1
        End If


    End Sub

    Private Sub txt_Concepto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Concepto.KeyDown

        Select Case e.KeyData
            Case Keys.Enter

                Try
                    Dim SQLCnslt As String = "SELECT Nombre FROM Gasimpo WHERE Codigo = '" & txt_Concepto.Text & "'"

                    Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                    If Row IsNot Nothing Then
                        txt_Descripcion.Text = Row.Item("Nombre")
                        txt_Importe.Focus()
                    Else
                        MsgBox("El codigo no es valido, Verificar", vbExclamation)
                        txt_Concepto.Select()

                    End If

                Catch ex As Exception
                    MsgBox("Se produjo un error en la consulta a Gasimpo")
                End Try
            Case Keys.Escape
                txt_Concepto.Text = ""
        End Select
    End Sub

    Private Sub txt_Importe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Importe.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_Importe.Text = formatonumerico(txt_Importe.Text, 2)
                If cbx_TipoCosto.TabIndex = 2 And Val(txt_Concepto.Text) = 4 Then
                    MsgBox("El costo de la mercaderia ya incluye el flete (CYF)", 0, "Ingreso de Gastos de Importacion")
                    Exit Sub
                End If

                If Val(txt_Concepto.Text) = 2 Then
                    Dim WImporteFob As Double = Calcula_Fob()
                    If Val(txt_Importe.Text) > (WImporteFob * 0.002) Then
                        MsgBox("Atencion : El seguro supera el 0.2% del importe FOB", 0, "Ingreso de Gastos de Importacion")
                    End If
                End If

                If Val(txt_Concepto.Text) = 1 Then
                    Dim WImporteFob As Double = Calcula_Fob()
                    If Val(txt_Importe.Text) > WImporteFob * 0.001 Then
                        MsgBox("Atencion : El gasto bancario supera el 0.1% del importe FOB", 0, "Ingreso de Gastos de Importacion")
                    End If
                End If

                Carga_gastos()

            Case Keys.Escape
                txt_Importe.Text = ""
        End Select



    End Sub

    Private Sub Carga_gastos()

        If txt_fila.Text = "" Then
            DGV_GastosImportacion.Rows.Add(txt_Concepto.Text, txt_Descripcion.Text, formatonumerico(txt_Importe.Text, 2))

        Else
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Concepto").Value = txt_Concepto.Text
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Descripcion").Value = txt_Descripcion.Text
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Importe").Value = formatonumerico(txt_Importe.Text, 2)

            txt_fila.Text = ""

        End If
        txt_Concepto.Text = ""
        txt_Importe.Text = ""
        txt_Descripcion.Text = ""

        BaseOrdenCompra = ""

    End Sub
    Private Function Calcula_Fob() As Double

        Dim WImporteFob As Double = 0

        Dim SQLCnslt As String = "SELECT Precio, Cantidad FROM Orden WHERE Orden = '" & txt_OrdenCompra.Text & "' Order by Orden,Renglon"

        Dim Tabla As DataTable = GetAll(SQLCnslt, Operador.Base)

        If Tabla.Rows.Count > 0 Then
            For Each Row As DataRow In Tabla.Rows
                WImporteFob = WImporteFob + (Val(Row.Item("Precio")) * Val(Row.Item("Cantiadad")))
            Next

        End If

        Return WImporteFob

    End Function

    Private Sub IngresoGastosImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txt_fila.Text = ""

        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")

        cbx_TipoCosto.SelectedIndex = 0
        cbx_Estado.SelectedIndex = 0
        cbx_Moneda.SelectedIndex = 0
        cbx_Transporte.SelectedIndex = 0

        Dim SQLCnslt As String = "SELECT MaximaCarpeta = MAX(Carpeta) From Movgas "

        Dim row As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If row IsNot Nothing Then
            txt_Carpeta.Text = row.Item("MaximaCarpeta") + 1
        End If


        lbl_EmpresaConeccion.Text = "Conectado a: " & Operador.Base

        'BaseAConectar = Operador.Base

    End Sub

    Private Sub IngresoGastosImportacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_OrdenCompra.Focus()
    End Sub

    Private Sub txt_OrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_OrdenCompra.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If txt_OrdenCompra.Text <> "" Then

                    Dim SQLCnlst As String = "SELECT Tipo, Proveedor ,Leyenda, TipoImpo, MarcaActualiza FROM Orden " _
                                             & "WHERE Orden = '" & txt_OrdenCompra.Text & "'"

                    Dim Row As DataRow = GetSingle(SQLCnlst, Operador.Base)

                    If Row IsNot Nothing Then
                        Dim WTipoOrden As String = IIf(IsDBNull(Row.Item("Tipo")), "0", Row.Item("Tipo"))
                        If WTipoOrden <> 1 Then
                            MsgBox("La Orden no es de importacion", 0, "Carga de Gastos de Importacion")
                        Else
                            WProveedor = Row.Item("Proveedor")
                            cbx_TipoCosto.SelectedIndex = IIf(IsDBNull(Row.Item("Leyenda")), "0", Row.Item("Leyenda"))
                            cbx_Transporte.SelectedIndex = IIf(IsDBNull(Row.Item("TipoImpo")), "0", Row.Item("TipoImpo"))

                            If cbx_Transporte.SelectedIndex = 3 And cbx_Estado.SelectedIndex = 0 Then
                                Dim WEstado As String = IIf(IsDBNull(Row.Item("MarcaActualiza")), "0", Row.Item("MarcaActualiza"))
                                If WEstado = "X" Then
                                    cbx_Estado.SelectedIndex = 1
                                End If
                            End If


                            txt_Origen.Focus()
                        End If
                    Else
                        '  MsgBox("no existe el numero de Orden de Compra", 0, "Carga de Gastos de Importacion")
                        txt_OrdenCompra.Focus()
                    End If



                End If


            Case Keys.Escape
                txt_OrdenCompra.Text = ""

        End Select

    End Sub

    Private Sub txt_Carpeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Carpeta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Carpeta.Text <> 0 Then
                    Dim SQLCnsl As String = "SELECT Fecha, Marca FROM Movgas WHERE Carpeta = '" & txt_Carpeta.Text & "' Order by Carpeta"

                    Dim row As DataRow = GetSingle(SQLCnsl, Operador.Base)

                    If row IsNot Nothing Then
                        txt_Fecha.Text = row.Item("Fecha")
                        Dim WMarca As String = IIf(IsDBNull(row.Item("Marca")), "", row.Item("Marca"))
                        If UCase(Trim(WMarca)) = "X" Then
                            cbx_Estado.SelectedIndex = 1
                        Else
                            cbx_Estado.SelectedIndex = 0
                        End If
                        Proceso()
                        BuscaDatosOrden()

                    Else
                        Dim WCarpeta As String = txt_Carpeta.Text
                        btn_Limpiar_Click(Nothing, Nothing)
                        txt_Carpeta.Text = WCarpeta
                        Dim VectorRespuesta() As String = BuscarBase_Carpeta()
                        txt_OrdenCompra.Text = VectorRespuesta(0)
                        txt_OrdenCompra_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        txt_Fecha.Focus()

                    End If


                End If
            Case Keys.Escape
                txt_Carpeta.Text = ""
        End Select

    End Sub


    Private Sub BuscaDatosOrden()

        Dim VectorRespuesta() As String = BuscarBase_Carpeta()

        BaseOrdenCompra = VectorRespuesta(1)

        Dim SQLCnslt As String = "SELECT Tipo, Proveedor, Leyenda, TipoImpo, MarcaActualiza " _
                                 & "FROM " & BaseOrdenCompra & ".dbo.Orden " _
                                 & " WHERE Orden = '" & txt_OrdenCompra.Text & "' ORDER BY Orden,Renglon"

        Dim RowOrden As DataRow = GetSingle(SQLCnslt)

        If RowOrden IsNot Nothing Then


            Dim WTipoOrden As Integer = IIf(IsDBNull(RowOrden.Item("Tipo")), 0, RowOrden.Item("Tipo"))
            If WTipoOrden <> 1 Then

                MsgBox("La Orden no es de importacion", 0, "Carga de Gastos de Importacion")
                txt_OrdenCompra.Focus()
            Else
                WProveedor = RowOrden.Item("Proveedor")
                cbx_TipoCosto.SelectedIndex = IIf(IsDBNull(RowOrden.Item("Leyenda")), 0, RowOrden.Item("Leyenda"))
                cbx_Transporte.SelectedIndex = IIf(IsDBNull(RowOrden.Item("TipoImpo")), 0, RowOrden.Item("TipoImpo"))

                If cbx_Transporte.SelectedIndex = 3 And cbx_Estado.SelectedIndex = 0 Then
                    Dim ZZEstado As String = IIf(IsDBNull(RowOrden.Item("MarcaActualiza")), "0", RowOrden.Item("MarcaActualiza"))
                    If ZZEstado = "X" Then
                        cbx_Estado.SelectedIndex = 1
                    End If
                End If
                txt_Origen.Focus()
            End If



        Else
            MsgBox("No existe el numero de Orden de Compra", 0, "Carga de Gastos de Importacion")
            txt_OrdenCompra.Focus()
        End If

    End Sub
    Private Function BuscarBase_Carpeta() As Object

        Dim VectorEmpresas(6) As String
        VectorEmpresas(0) = "SurfactanSa"
        VectorEmpresas(1) = "Surfactan_II"
        VectorEmpresas(2) = "Surfactan_III"
        VectorEmpresas(3) = "Surfactan_IV"
        VectorEmpresas(4) = "Surfactan_V"
        VectorEmpresas(5) = "Surfactan_VI"
        VectorEmpresas(6) = "Surfactan_VII"

        Dim OrdenYBase(2) As String
        Dim WOrden As String
        For i = 0 To 6

            Dim SQLCnlst As String = "SELECT Tipo, Orden FROM Orden WHERE Carpeta = '" & txt_Carpeta.Text & "' ORDER BY Orden"
            Dim Row As DataRow = GetSingle(SQLCnlst, VectorEmpresas(i))

            If Row IsNot Nothing Then
                Dim WTipoOrden As String = IIf(IsDBNull(Row.Item("Tipo")), "0", Row.Item("Tipo"))
                If Val(WTipoOrden) = 1 Then

                    WOrden = Row.Item("Orden")

                    OrdenYBase(0) = WOrden
                    OrdenYBase(1) = VectorEmpresas(i)

                End If

            End If

        Next

        Return OrdenYBase
    End Function

    Private Sub Proceso()

        DGV_GastosImportacion.Rows.Clear()

        Dim SQLCnslt As String = "SELECT Fecha, Orden, Derechos, Origen, Moneda, Empresa, Concepto, Importe " _
                                 & "FROM Movgas WHERE Carpeta = '" & txt_Carpeta.Text & "'"


        Dim tabla As DataTable = GetAll(SQLCnslt)

        Dim TablaGastos As New DataTable

        With TablaGastos.Columns
            .Add("Concepto")
            .Add("Descripcion")
            .Add("Importe")
        End With

        If tabla.Rows.Count > 0 Then
            For Each Row As DataRow In tabla.Rows
                txt_Fecha.Text = Row.Item("Fecha")
                txt_OrdenCompra.Text = Row.Item("Orden")
                txt_Origen.Text = Row.Item("Origen")
                cbx_Moneda.SelectedIndex = Row.Item("Moneda")

                TablaGastos.Rows.Add(Row.Item("Concepto"), "", formatonumerico(Row.Item("Importe"), 2))

            Next

            txt_OrdenCompra_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            For Each row As DataRow In TablaGastos.Rows

                SQLCnslt = "SELECT Nombre FROM Gasimpo WHERE Codigo = '" & row.Item("Concepto") & "'"

                Dim RowGastos As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowGastos IsNot Nothing Then
                    row.Item("Descripcion") = RowGastos.Item("Nombre")
                End If
            Next

            For Each row As DataRow In TablaGastos.Rows
                DGV_GastosImportacion.Rows.Add(row.Item("Concepto"), row.Item("Descripcion"), row.Item("Importe"))
            Next


            txt_Concepto.Focus()
        End If

    End Sub


    Private Sub DGV_GastosImportacion_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_GastosImportacion.RowHeaderMouseDoubleClick
        With DGV_GastosImportacion.CurrentRow
            If MsgBox("Desea borrar el Concepto: " & Trim(.Cells("Descripcion").Value) & " con un importe de: " & .Cells("Importe").Value, vbYesNo) = vbYes Then
                Dim Posicion As Integer = .Index
                If Posicion = Val(txt_fila.Text) Then
                    txt_fila.Text = ""
                End If
                DGV_GastosImportacion.Rows.RemoveAt(Posicion)
            End If

        End With
    End Sub

    Private Sub DGV_GastosImportacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_GastosImportacion.CellDoubleClick

        With DGV_GastosImportacion.CurrentRow

            If e.ColumnIndex <> -1 Then
                txt_Concepto.Text = .Cells("Concepto").Value
                txt_Descripcion.Text = .Cells("Descripcion").Value
                txt_Importe.Text = .Cells("Importe").Value

                txt_fila.Text = .Index

            End If


        End With
    End Sub

    Private Sub btn_Derechos_Click(sender As Object, e As EventArgs) Handles btn_Derechos.Click

        If txt_OrdenCompra.Text <> "" And BaseOrdenCompra <> "" Then
            With New Derechos_GastosImportacion(txt_OrdenCompra.Text, BaseOrdenCompra)
                .Show()
            End With
        Else
            Dim VectorRespuesta() As String = BuscarBase_Carpeta()
            With New Derechos_GastosImportacion(VectorRespuesta(0), VectorRespuesta(1))
                .Show()
            End With
        End If
    End Sub

    Private Sub btn_IngresaObservaciones_Click(sender As Object, e As EventArgs) Handles btn_IngresaObservaciones.Click

        Dim VectorRespuesta() As String = BuscarBase_Carpeta()

        Dim SQLCnslt As String = "SELECT Tipo FROM " & VectorRespuesta(1) & ".dbo.Orden WHERE Orden = '" & txt_OrdenCompra.Text & "' ORDER BY Orden,Renglon"

        Dim Row As DataRow = GetSingle(SQLCnslt)

        If Row IsNot Nothing Then
            Dim WTipoOrden As Integer = IIf(IsDBNull(Row.Item("Tipo")), 0, Row.Item("Tipo"))

            If WTipoOrden <> 1 Then
                MsgBox("La Orden no es de importacion", 0, "Carga de Gastos de Importacion")
                Exit Sub
            End If
        Else
            MsgBox("No existe el numero de Orden de Compra", 0, "Carga de Gastos de Importacion")
            Exit Sub
        End If





        With New IngresoObservaciones_Orden(txt_OrdenCompra.Text, txt_Carpeta.Text, VectorRespuesta(1))
            .Show()
        End With


    End Sub

    Private Sub btn_Graba_Click(sender As Object, e As EventArgs) Handles btn_Graba.Click

        Dim SQlCnslt As String = "SELECT Marca FROM Movgas WHERE Carpeta = '" & txt_Carpeta.Text & "'"

        Dim row As DataRow = GetSingle(SQlCnslt, Operador.Base)
        If row IsNot Nothing Then
            Dim WMarca As String = IIf(IsDBNull(row.Item("Marca")), "", row.Item("Marca"))

            If WMarca = "X" Then

                MsgBox("Esta carpeta ya fue actualizada", 0, "Ingreso de Gastos")
                Exit Sub
            End If
        End If


        Dim VectorRespuesta() As String = BuscarBase_Carpeta()

        Dim WTipoOrden As String
        Dim WPasa As String = "S"

        SQlCnslt = "SELECT Tipo, Proveedor FROM Orden WHERE Orden = '" & txt_OrdenCompra.Text & "' ORDER BY Orden. Reglon"

        Dim rowOrden As DataRow = GetSingle(SQlCnslt, VectorRespuesta(1))

        If rowOrden IsNot Nothing Then

            WTipoOrden = IIf(IsDBNull(rowOrden.Item("Tipo")), "0", rowOrden.Item("Tipo"))
            If WTipoOrden <> 1 Then
                MsgBox("La Orden no es de importacion", 0, "Carga de Gastos de Importacion")
                WPasa = "N"
            Else
                WProveedor = rowOrden.Item("Proveedor")
            End If
        Else
            MsgBox("Nro. de Orden de Compra Inexistente", 0, "Carga de Gastos de Importacion")
            WPasa = "N"
        End If


        If WPasa = "N" Then
            Exit Sub
        End If

        If WPasa = "S" Then



            Dim TablaCalculos As New DataTable
            With TablaCalculos.Columns
                .Add("Articulo")
                .Add("Cantidad")
                .Add("Derechos")
                .Add("Precio")
            End With



            SQlCnslt = "SELECT Articulo, Cantidad, Derechos, Precio FROM " & BaseOrdenCompra & "dbo.Orden " _
                     & "WHERE Orden = '" & txt_OrdenCompra.Text & "' ORDER BY Orden, Renglon"

            Dim TablaOrden As DataTable = GetAll(SQlCnslt)

            If TablaOrden.Rows.Count > 0 Then
                For Each Row_Orden As DataRow In TablaOrden.Rows
                    With Row_Orden
                        Dim Auxi As String = IIf(IsDBNull(.Item("Derechos")), 0, .Item("Derechos"))
                        TablaCalculos.Rows.Add(.Item("Articulo"), .Item("Cantidad"), formatonumerico(.Item("Derechos"), 2), formatonumerico(.Item("Precio"), 2))
                    End With
                Next
            End If



            REM For Cicla = 1 To Ingre
            REM     spArticulo = "ConsultaArticulo " + "'" + WCalcula(Cicla, 1) + "'"
            REM     Set rstArticulo = db.OpenRecordset(spArticulo, dbOpenSnapshot, dbSQLPassThrough)
            REM     If rstArticulo.RecordCount > 0 Then
            REM         WCalcula(Cicla, 4) = Str$(rstArticulo!Flete)
            REM         rstArticulo.Close
            REM     End If
            REM Next Cicla

            Dim XImpoDerechos As Double = 0

            For Cicla = 0 To TablaCalculos.Rows.Count - 1
                Dim WPrecio As String = TablaCalculos.Rows(Cicla).Item("Precio")
                Dim WCantidad As String = TablaCalculos.Rows(Cicla).Item("Cantidad")
                Dim WDerechos As String = TablaCalculos.Rows(Cicla).Item("Derechos")

                XImpoDerechos = XImpoDerechos + ((Val(WPrecio) * Val(WCantidad)) * Val(WDerechos) / 100)
            Next


            Dim ListaSQLCnslt As New List(Of String)

            SQlCnslt = "DELETE	Movgas WHERE Carpeta = '" & txt_Carpeta.Text & "'"

            ListaSQLCnslt.Add(SQlCnslt)

            Dim Renglon As Integer = 0

            For Each RowDGV As DataGridViewRow In DGV_GastosImportacion.Rows
                If Val(RowDGV.Cells("Concepto").Value) <> 0 Then

                    Renglon = Renglon + 1
                    Dim Auxi As String = Renglon.ToString().PadLeft(2, "0")

                    Dim Auxi2 As String = txt_Carpeta.Text.PadLeft(6, "0")



                    Dim WClave As String = Auxi2 + Auxi
                    Dim WCarpeta As String = txt_Carpeta.Text
                    Dim WRenglon As String = Str$(Renglon)
                    Dim WFecha As String = txt_Fecha.Text
                    Dim WDerechos As String = ""
                    Dim WOrden As String = txt_OrdenCompra.Text
                    Dim WConcepto As String = RowDGV.Cells("Concepto").Value
                    Dim WImporte As String = RowDGV.Cells("Importe").Value
                    Dim WAuxiliar As String = ""
                    Dim WOrdFecha As String = ordenaFecha(txt_Fecha.Text)
                    Dim WMoneda As String = Str$(cbx_Moneda.SelectedIndex)
                    Dim WOrigen As String = txt_Origen.Text
                    Dim WMarca As String = ""
                    Dim WImpoDerechos As String = Str$(XImpoDerechos)
                    Dim WFechaLlegada As String = ""
                    Dim WOrdFechaLLegada As String = ""
                    Dim WCostoFlete As String = ""
                    Dim WGastos As String = ""
                    Dim WPagado As String = ""
                    Dim WEmpreOtro As String = VectorRespuesta(1)


                    SQlCnslt = "INSERT INTO  Movgas ( " _
                        & " Clave," _
                        & " Carpeta," _
                        & " Renglon," _
                        & " Fecha," _
                        & " Derechos," _
                        & " Orden," _
                        & " Concepto," _
                        & " Importe," _
                        & " Auxiliar," _
                        & " OrdFecha," _
                        & " Proveedor," _
                        & " Origen," _
                        & " Moneda," _
                        & " Marca," _
                        & " ImpoDerechos," _
                        & " FechaLLegada," _
                        & " OrdFechaLLegada," _
                        & " CostoFlete," _
                        & " Gastos," _
                        & " Pagado," _
                        & " Empresa) " _
                        & "VALUES( " _
                    & "'" & WClave & "', " _
                    & "'" & WCarpeta & ", " _
                    & "'" & WRenglon & "', " _
                    & "'" & WFecha & "', " _
                    & "'" & WDerechos & "', " _
                    & "'" & WOrden & "', " _
                    & "'" & WConcepto & "', " _
                    & "'" & WImporte & "', " _
                    & "'" & WAuxiliar & "', " _
                    & "'" & WOrdFecha & "', " _
                    & "'" & WProveedor & "', " _
                    & "'" & WOrigen & "', " _
                    & "'" & WMoneda & "', " _
                    & "'" & WMarca & "', " _
                    & "'" & WImpoDerechos & "', " _
                    & "'" & WFechaLlegada & "', " _
                    & "'" & WOrdFechaLLegada & "', " _
                    & "'" & WCostoFlete & "', " _
                    & "'" & WGastos & "', " _
                    & "'" & WPagado & "', " _
                    & "'" & WEmpreOtro & "')"


                    ListaSQLCnslt.Add(SQlCnslt)

                End If
            Next


            ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)


            btn_Limpiar_Click(Nothing, Nothing)



        End If


        txt_Carpeta.Focus()

    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With Consulta_GastImportacion
            .Show(Me)
        End With
    End Sub

    Public Sub PasaGasto(Codigo As String, Descripcion As String) Implements IConsulta_GasImportacion.PasaGasto
        txt_Concepto.Text = Codigo
        txt_Descripcion.Text = Descripcion
        txt_Importe.Focus()
    End Sub
End Class