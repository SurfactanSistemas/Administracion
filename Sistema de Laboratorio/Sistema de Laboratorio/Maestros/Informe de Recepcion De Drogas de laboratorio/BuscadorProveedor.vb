Public Class BuscadorProveedor
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtBuscardorProv.Text = ""
        Dim SQLCnslt As String
        SQLCnslt = "SELECT CodigoProv = Proveedor, DescripcionProv = Nombre FROM Proveedor WHERE TipoProv = 4 or TipoProv = 2 or TipoProv = 31 ORDER BY Nombre "
        Dim tablaProv As DataTable = GetAll(SQLCnslt)
        DGV_Proveedores.DataSource = tablaProv
        txtBuscardorProv.Focus()
    End Sub

    Private Sub txtBuscardorProv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscardorProv.KeyUp
        Dim tabla As DataTable = DGV_Proveedores.DataSource
        tabla.DefaultView.RowFilter = "CodigoProv LIKE '%" & txtBuscardorProv.Text & "%' OR DescripcionProv LIKE '%" & txtBuscardorProv.Text & "%'"
        DGV_Proveedores.DataSource = tabla
    End Sub

    Private Sub DGV_Proveedores_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Proveedores.CellDoubleClick

        Dim Wowner As IBuscadorProveedor = TryCast(Owner, IBuscadorProveedor)

        If Wowner IsNot Nothing Then
            Wowner.ProcesarDatosProveedor(DGV_Proveedores.CurrentRow.Cells("CodigoProv").Value, DGV_Proveedores.CurrentRow.Cells("DescripcionProv").Value)
        End If

    End Sub

    Private Sub btnVolver_PnlProveedores_Click(sender As Object, e As EventArgs) Handles btnVolver_PnlProveedores.Click
        Close()
    End Sub
End Class