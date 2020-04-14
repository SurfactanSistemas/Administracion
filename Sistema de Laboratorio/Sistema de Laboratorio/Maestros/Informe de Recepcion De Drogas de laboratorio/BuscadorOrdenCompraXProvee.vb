Public Class BuscadorOrdenCompraXProvee

    Sub New(ByVal CodProvee As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim SQLCnslt As String
        SQLCnslt = "SELECT AyudaDescripcion = a.Descripcion, AyudaArticulo = o.Articulo,  AyudaSaldo = o.Cantidad - o.Recibida, NroOrden = o.Orden "
        SQLCnslt = SQLCnslt & "FROM Orden o INNER JOIN Articulo a ON o.Articulo = a.Codigo  WHERE (o.Tipo = 3 OR o.Tipo = 4) AND o.Saldo > 0 AND o.Recibida < o.Cantidad  AND o.Proveedor = '" & CodProvee & "' ORDER BY o.Articulo "
        Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

        DGV_AyudaProv.DataSource = tablaOrdenesCompra

    End Sub


    Private Sub DGV_AyudaProv_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_AyudaProv.CellMouseDoubleClick

        Dim Wowner As IBuscarOrdenCompraXProvee = TryCast(Owner, IBuscarOrdenCompraXProvee)

        If Wowner IsNot Nothing Then
            Wowner.ProcesarDatosOrdenCompraProvee(DGV_AyudaProv.CurrentRow.Cells("NroOrden").Value)
            Close()
        End If

    End Sub
End Class