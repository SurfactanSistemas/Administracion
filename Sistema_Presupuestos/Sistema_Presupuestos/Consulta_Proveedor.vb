Imports Util.Clases.Query
Public Class Consulta_Proveedor

    Private Sub Consulta_Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo = Proveedor, Descripcion = Nombre FROM Proveedor ORDER BY Proveedor"
        Dim tablaProv As DataTable = getall(SQLCnslt, "SurfactanSa")
        If tablaProv.Rows.Count > 0 Then
            dgv_Prov.DataSource = tablaProv
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim tabla As DataTable = dgv_Prov.DataSource
        tabla.DefaultView.RowFilter = "Codigo LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

  
    Private Sub dgv_Prov_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgv_Prov.MouseDoubleClick
        Dim WOwner As IAyudaProv = TryCast(Owner, IAyudaProv)
        If WOwner IsNot Nothing Then
            WOwner.PasaProve(dgv_Prov.CurrentRow.Cells("Codigo").Value, dgv_Prov.CurrentRow.Cells("Descripcion").Value)
            Close()
        End If
    End Sub

    Private Sub Consulta_Proveedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Filtro.Focus()
    End Sub
End Class