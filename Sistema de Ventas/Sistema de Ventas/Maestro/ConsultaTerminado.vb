Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class ConsultaTerminado

    Private Sub DbDataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Terminado.CellMouseDoubleClick
        Dim WOwner As IConsultaTerminado = TryCast(Owner, IConsultaTerminado)
        If WOwner IsNot Nothing Then
            WOwner.CargaDatos(DGV_Terminado.CurrentRow.Cells("Codigo").Value, DGV_Terminado.CurrentRow.Cells("Descripcion").Value)
        End If
        Close()
    End Sub

    Private Sub ConsultaTerminado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo ASC"
        Dim tabla As DataTable = GetAll(SQLCnslt)
        DGV_Terminado.DataSource = tabla
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim tabla As DataTable = DGV_Terminado.DataSource
        tabla.DefaultView.RowFilter = "Codigo LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub
End Class