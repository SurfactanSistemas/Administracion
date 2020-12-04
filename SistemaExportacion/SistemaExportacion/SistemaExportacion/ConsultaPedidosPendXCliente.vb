Imports Util.Clases.Query
Public Class ConsultaPedidosPendXCliente


    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub ConsultaPedidosPendXCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT  DISTINCT  p.Pedido, NroPedido  = Try_CAST(isnull(p.Pedido, '') AS char) , p.Cliente, FechaPedido = p.Fecha, OrdFechaPedido = p.FechaOrd, FechaEntrega = p.FecEntrega, OrdFechaEntrega = p.OrdFecEntrega " _
                                  & "FROM PedidoProformaExportacion ppe RIGHT OUTER JOIN Pedido p ON ppe.Nropedido = p.Pedido INNER JOIN Cliente c ON p.Cliente = c.Cliente " _
                                  & "WHERE p.Facturado < p.Cantidad AND c.Provincia = 24" _
                                  & "ORDER BY p.Pedido ASC"

        Dim TablaPed As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPed.Rows.Count > 0 Then
            DGV_PedidosPendientes.DataSource = TablaPed
        End If
    End Sub
    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_PedidosPendientes.DataSource
        TablaFiltrar.DefaultView.RowFilter = "Cliente LIKE '%" & txt_Filtro.Text & "%' OR FechaEntrega LIKE '%" & txt_Filtro.Text & "%' OR FechaPedido LIKE '%" & txt_Filtro.Text & "%' OR NroPedido LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

    Private Sub DGV_PedidosPendientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PedidosPendientes.CellDoubleClick

        Dim WOwner As IConsultaPedidos = TryCast(Owner, IConsultaPedidos)
        If WOwner IsNot Nothing Then
            WOwner.PasaPedido(DGV_PedidosPendientes.CurrentRow.Cells("Pedido").Value)
        End If


    End Sub
End Class