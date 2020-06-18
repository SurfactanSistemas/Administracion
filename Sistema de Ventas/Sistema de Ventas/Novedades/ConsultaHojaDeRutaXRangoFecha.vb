Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaHojaDeRutaXRangoFecha
    Private ReadOnly tablaDGV As New DataTable

    Private Sub ConsultaHojaDeRutaXRangoFecha_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFechaDesde.Focus()
    End Sub

    Private Sub txtFechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtFechaDesde.Text) = "S" Then
                    txtFechaHasta.Focus()
                End If
            Case Keys.Escape
                txtFechaDesde.Text = ""
        End Select
    End Sub

    Private Sub txtFechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If ValidaFecha(txtFechaHasta.Text) = "S" And ValidaFecha(txtFechaDesde.Text) = "S" Then
                    Cargar_DGV()
                End If
            Case Keys.Escape
                txtFechaHasta.Text = ""
        End Select
    End Sub

    Private Sub Cargar_DGV()
        
        Dim w As Stopwatch = Stopwatch.StartNew

        tablaDGV.Rows.Clear()

        'BORRO LO QUE ALLA CARGADO
        'DGV_HojaRuta.DataSource = Nothing
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True

        Dim SQLCnslt As String = "SELECT hr.Pedido, hr.Cliente, hr.Razon, Remito = CASE WHEN ISNULL(p.Remito, 0) = 0 THEN hr.Remito ELSE p.Remito END, hr.Hoja, p.TipoPedido " _
                                 & "FROM HojaRuta hr LEFT OUTER JOIN Pedido p ON p.Pedido = hr.Pedido And p.Renglon = 1 " _
                                 & "WHERE hr.OrdFecha BETWEEN '" & ordenaFecha(txtFechaDesde.Text) & "' AND '" & ordenaFecha(txtFechaHasta.Text) & "' " _
                                 & "Order by hr.Clave"
        Dim tablaDatos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If tablaDatos.Rows.Count = 0 Then Exit Sub

        With tablaDatos.Columns
            .Add("Factura")
        End With

        ProgressBar1.Maximum = tablaDatos.Rows.Count + 1

        For Each Row As DataRow In tablaDatos.Rows

            Row.Item("Factura") = 0

            SQLCnslt = "SELECT Pedido, Remito, Numero FROM CtaCte " _
                     & "WHERE Pedido = '" & Row.Item("Pedido") & "' And Remito = '" & Row.Item("Remito") & "'"
            Dim TablaCtaCte As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If TablaCtaCte IsNot Nothing Then Row.Item("Factura") = TablaCtaCte.Item("Numero")
            
            If Val(Row.Item("Factura")) <> 0 Then

                SQLCnslt = "SELECT Numero, Cliente, Articulo, Cantidad FROM Estadistica " _
                        & "WHERE Numero = '" & Row.Item("Factura") & "' AND Cliente = '" & Row.Item("Cliente") & "'"

                Dim tablaEstadistica As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tablaEstadistica.Rows.Count > 0 Then
                    For Each RowEstadistica As DataRow In tablaEstadistica.Rows
                        Dim r As DataRow = tablaDGV.NewRow

                        With r
                            .Item("Hoja") = Row.Item("Hoja")
                            .Item("Factura") = Row.Item("Factura")
                            .Item("Remito") = ""

                            If Row.Item("Remito") <> 0 Then .Item("Remito") = Row.Item("Remito")

                            .Item("Pedido") = Row.Item("Pedido")
                            .Item("RazonSocial") = Row.Item("Razon")

                            Dim Articulo As String = RowEstadistica("Articulo").ToString.ToUpper

                            If Articulo.StartsWith("PT") Then
                                .Item("Producto") = Articulo
                                .Item("Tipo") = "T"
                            Else
                                .Item("Producto") = Helper.Left(Articulo, 3) & Helper.Right(Articulo, 7)
                                .Item("Tipo") = "M"
                            End If

                            .Item("Descripcion") = ""
                            .Item("Kilos") = RowEstadistica.Item("Cantidad")
                            .Item("Cliente") = Row.Item("Cliente")
                        End With

                        tablaDGV.Rows.Add(r)

                    Next
                End If

            Else
                Dim WCantidadFac, WSumaCantidad, WKilos As String

                SQLCnslt = "SELECT Pedido, SumaCantidad = (CantiLote1 + CantiLote2 + CantiLote3 + CantiLote4 + CantiLote5), Cantidad, Terminado, CantidadFac " _
                         & "FROM Pedido WHERE Pedido = '" & Row.Item("Pedido") & "'"

                Dim tablaPedido As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                For Each RowPed As DataRow In tablaPedido.Rows
                    Dim r As DataRow = tablaDGV.NewRow

                    With r

                        WCantidadFac = OrDefault(RowPed("CantidadFac"), 0)
                        WSumaCantidad = OrDefault(RowPed("SumaCantidad"), 0)

                        If Val(WSumaCantidad) = 0 Then WSumaCantidad = WCantidadFac

                        WKilos = IIf(Val(WSumaCantidad) <> 0, WSumaCantidad, RowPed("Cantidad"))

                        .Item("Hoja") = Row("Hoja")
                        .Item("Factura") = ""
                        .Item("Remito") = ""
                        If Row("Remito") <> 0 Then .Item("Remito") = Row("Remito")
                        .Item("Pedido") = Row("Pedido")
                        .Item("RazonSocial") = Row("Razon")

                        Dim Terminado As String = UCase(RowPed("Terminado"))

                        If Terminado.StartsWith("PT") Then
                            .Item("Producto") = Terminado
                            .Item("Tipo") = "T"
                        Else
                            .Item("Producto") = Helper.Left(Terminado, 3) & Helper.Right(Terminado, 7)
                            .Item("Tipo") = "M"
                        End If

                        .Item("Descripcion") = ""
                        .Item("Kilos") = formatonumerico(WKilos, 3)
                        .Item("Cliente") = Row("Cliente")
                    End With

                    tablaDGV.Rows.Add(r)
                Next

            End If

            ProgressBar1.Value += 1

        Next

        Dim auxi As DataView = New DataView(tablaDGV)
        Dim WTerminados As DataRow() = auxi.ToTable(True, "Producto", "Tipo").Select("Tipo = 'T'")
        Dim WArticulos As DataRow() = auxi.ToTable(True, "Producto", "Tipo").Select("Tipo = 'M'")

        For Each o As DataRow In WTerminados
            Dim Desc As String = ""

            SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & o("Producto") & "'"
            Dim RowTerminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowTerminado IsNot Nothing Then Desc = RowTerminado.Item("Descripcion")

            For Each o1 As DataRow In tablaDGV.Select("Producto = '" & o("Producto") & "'")
                o1("Descripcion") = Desc.Trim
            Next

        Next

        For Each o As DataRow In WArticulos

            Dim Desc As String = ""

            SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & o("Producto") & "'"
            Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowArticulo IsNot Nothing Then Desc = RowArticulo.Item("Descripcion")

            For Each o1 As DataRow In tablaDGV.Select("Producto = '" & o("Producto") & "'")
                o1("Descripcion") = Desc.Trim
            Next

        Next

        ProgressBar1.Visible = False

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        Dim Tablafiltro As DataTable = DGV_HojaRuta.DataSource
        Tablafiltro.DefaultView.RowFilter = "RazonSocial LIKE '%" & txtFiltro.Text & "%' OR Producto LIKE '%" & txtFiltro.Text & "%' OR Descripcion LIKE '%" & txtFiltro.Text & "%'"
    End Sub

    Private Sub DGV_HojaRuta_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_HojaRuta.CellMouseDoubleClick
        Dim WOwner As IHojaDeRuta = TryCast(Owner, IHojaDeRuta)
        If WOwner IsNot Nothing Then
            WOwner.CargarHojaDeRuta(DGV_HojaRuta.CurrentRow.Cells("Hoja").Value)
        End If

    End Sub

   
    Private Sub ConsultaHojaDeRutaXRangoFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With tablaDGV.Columns
            .Add("Hoja")
            .Add("Factura")
            .Add("Remito")
            .Add("Pedido")
            .Add("RazonSocial")
            .Add("Producto")
            .Add("Descripcion")
            .Add("Kilos")
            .Add("Cliente")
            .Add("Tipo")
        End With

        DGV_HojaRuta.DataSource = tablaDGV

    End Sub

End Class