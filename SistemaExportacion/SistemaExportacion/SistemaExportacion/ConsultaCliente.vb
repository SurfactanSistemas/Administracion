Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaCliente

    Private Sub ConsultaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Cliente, Razon, ISNULL(NombrePais,'') NombrePais FROM Cliente WHERE Provincia = 24 ORDER BY Cliente ASC"

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
       
        Dim WOwner As IConsultaCliente = TryCast(Owner, IConsultaCliente)
        If WOwner IsNot Nothing Then
            WOwner.PasarCliente(DGV_Cliente.CurrentRow.Cells("Cliente").Value, DGV_Cliente.CurrentRow.Cells("Razon").Value, DGV_Cliente.CurrentRow.Cells("NombrePais").Value)
            Close()
        End If


    End Sub

    Private Sub ConsultaCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Filtro.Focus()
    End Sub
End Class