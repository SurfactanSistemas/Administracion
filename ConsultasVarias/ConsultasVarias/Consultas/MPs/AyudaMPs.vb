Imports ConsultasVarias.Interfaces
Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Globales

Public Class AyudaMPs

    Private Sub AyudaMPs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim WMPs As DataTable = GetAll("SELECT Codigo, Descripcion FROM Articulo ORDER BY Codigo")

        DataGridView1.DataSource = WMPs

    End Sub

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp

        Dim tabla As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaMPs = TryCast(Owner, IAyudaMPs)

        Dim WCodigo = OrDefault(DataGridView1.CurrentRow.Cells("Codigo").Value, "")
        Dim WDescripcion = OrDefault(DataGridView1.CurrentRow.Cells("Descripcion").Value, "")

        If WOwner IsNot Nothing Then WOwner._ProcesarAyudaMPs(WCodigo, WDescripcion)

        Close()

    End Sub

    Private Sub AyudaMPs_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub
End Class