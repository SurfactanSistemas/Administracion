Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class PedidosPendientesXClientes

    Sub New(ByVal Cliente As String, ByVal DesCliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Cliente.Text = Cliente
        txt_ClienteDes.Text = DesCliente
        
        Dim SQLCnslt As String = "SELECT DISTINCT Pedido, FecEntrega, OrdFecEntrega, FechaPedido = Fecha " _
                                 & "FROM Pedido " _
                                 & "WHERE Cliente = '" & Cliente & "' " _
                                 & "AND Facturado < Cantidad " _
                                 & "ORDER BY OrdFecEntrega"

        Dim TablaPed As DataTable = GetAll(SQLCnslt, "SurfactanSa")


        If TablaPed.Rows.Count > 0 Then

            DGV_PedidosPendientes.DataSource = TablaPed

        End If


    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub DGV_PedidosPendientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PedidosPendientes.CellDoubleClick
        With New PedidoDetallado(DGV_PedidosPendientes.CurrentRow.Cells("Pedido").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_PedidosPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PedidosPendientes.CellClick
        DGV_PedidosPendientes.Rows(DGV_PedidosPendientes.CurrentCell.RowIndex).Selected = True
    End Sub
End Class