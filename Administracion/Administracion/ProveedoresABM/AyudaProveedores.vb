Public Class AyudaProveedores

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dgvProveedores.DataSource = GetAll("SELECT Proveedor, Nombre FROM Proveedor ORDER BY Nombre")

    End Sub

    Private Sub AyudaProveedores_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim tabla As DataTable = TryCast(dgvProveedores.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Proveedor LIKE '%{0}%' OR Nombre LIKE '%{0}%'", TextBox1.Text)

    End Sub

    Private Sub dgvProveedores_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProveedores.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaProveedores = TryCast(Owner, IAyudaProveedores)

        With dgvProveedores.Rows(e.RowIndex)
            If WOwner IsNot Nothing Then WOwner._ProcesarAyudaProveedores(OrDefault(.Cells("Proveedor").Value, ""), OrDefault(.Cells("Nombre").Value, ""))
        End With

        Close()

    End Sub
End Class