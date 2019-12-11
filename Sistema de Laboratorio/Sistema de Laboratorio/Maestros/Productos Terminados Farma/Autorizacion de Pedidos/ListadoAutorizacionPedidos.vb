Public Class ListadoAutorizacionPedidos

    Private Sub ListadoAutorizacionPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim WPedidos As DataTable = GetAll("SELECT p.Pedido, p.Cliente, c.Razon, p.Fecha, p.FecEntrega, Tipo = CASE p.TipoPed WHEN 0 THEN 'NORMAL' WHEN 1 THEN 'A FECHA' WHEN 2 THEN 'FECHA LIMITE' WHEN 3 THEN 'URGENTE' WHEN 4 THEN 'RETIRA CLIENTE' WHEN 5 THEN 'MUESTRA' ELSE '' END , Importe = sum((p.Cantidad - p.Facturado) * p.Precio) from Pedido p INNER JOIN Cliente c ON c.Cliente = p.Cliente where p.MarcaFactura='9' group by p.Pedido, p.Cliente, c.Razon, p.Fecha, p.FecEntrega, p.TipoPed", "SurfactanSa")
        dgvPedidos.DataSource = WPedidos
        dgvPedidos.Focus()
    End Sub

    Private Sub dgvPedidos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPedidos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        With New AutorizarPedido(dgvPedidos.CurrentRow.Cells("Pedido").Value)
            .ShowDialog(Me)
        End With

    End Sub
End Class