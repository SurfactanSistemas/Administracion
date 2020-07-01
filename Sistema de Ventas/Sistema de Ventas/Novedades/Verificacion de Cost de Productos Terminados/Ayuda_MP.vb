Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Ayuda_MP

    Private Sub Ayuda_MP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Articulo order by codigo"

        Dim tabla As DataTable = getall(SQLCnslt, "SurfactanSa")

        If tabla.Rows.Count > 0 Then
            DGV_Ayuda.DataSource = tabla
        End If
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub


    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        Dim tablaFiltrar As DataTable = DGV_Ayuda.DataSource
        tablaFiltrar.DefaultView.RowFilter = "Codigo LIKE '%" & txtFiltro.Text & "%' OR Descripcion LIKE '%" & txtFiltro.Text & "%'"
    End Sub

    Private Sub DGV_Ayuda_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Ayuda.CellMouseDoubleClick
        Dim WOwner As IVerificaCostoPT = TryCast(Owner, IVerificaCostoPT)
        If WOwner IsNot Nothing Then
            WOwner.AgregaMP(DGV_Ayuda.CurrentRow.Cells("Codigo").Value, DGV_Ayuda.CurrentRow.Cells("Descripcion").Value)
        End If

    End Sub
End Class