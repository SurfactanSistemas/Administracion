Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaCliente

    Private Sub ConsultaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Cliente, Razon FROM Cliente ORDER BY Cliente ASC"

        Dim TablaCliente As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaCliente.Rows.Count > 0 Then
            DGV_Cliente.DataSource = TablaCliente
        End If
    End Sub



    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_Cliente.DataSource
        TablaFiltrar.DefaultView.RowFilter = "Cliente LIKE '%" & txt_Filtro.Text & "%' OR Razon LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub DGV_Cliente_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Cliente.CellMouseDoubleClick
        Dim Accion As String = "Desde"
        If chk_Desde.Checked And chk_Hasta.Checked Then
            Accion = "Ambos"
        Else
            If chk_Hasta.Checked And chk_Desde.Checked = False Then
                Accion = "Hasta"
            End If
        End If
        Dim WOwner As IBuscarClienteCashFlow = TryCast(Owner, IBuscarClienteCashFlow)
        If WOwner IsNot Nothing Then
            WOwner.CompletaCliente(DGV_Cliente.CurrentRow.Cells("Cliente").Value, Accion)
        End If


    End Sub
End Class