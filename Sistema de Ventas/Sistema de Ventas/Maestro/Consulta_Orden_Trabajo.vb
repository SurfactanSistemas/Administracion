
Imports Util.Clases.Query
Public Class Consulta_Orden_Trabajo

    Private Sub Consulta_Orden_Trabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT o.Orden, o.Cliente, c.Razon FROM OrdenTrabajo o " _
                             & "left join Cliente c on o.Cliente = c.Cliente WHERE LEN(o.Orden) = 8 ORDER BY o.Orden"
        Dim tabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")
        If tabla.Rows.Count > 0 Then
            DGV_Ordenes.DataSource = tabla
        End If
    End Sub

    Private Sub Consulta_Orden_Trabajo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFiltro.Focus()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        Dim tabla As DataTable = DGV_Ordenes.DataSource
        tabla.DefaultView.RowFilter = " Orden LIKE '%" & txtFiltro.Text & "%' OR Cliente LIKE '%" & txtFiltro.Text & "%' OR Razon LIKE '%" & txtFiltro.Text & "%'"
    End Sub


    Private Sub DGV_Ordenes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Ordenes.CellMouseDoubleClick
        Dim WOwner As IConsulta_Orden_Trabajo = TryCast(Owner, IConsulta_Orden_Trabajo)
        If WOwner IsNot Nothing Then
            WOwner.PasarDatos(DGV_Ordenes.CurrentRow.Cells("Orden").Value)
        End If
        Close()
    End Sub
End Class