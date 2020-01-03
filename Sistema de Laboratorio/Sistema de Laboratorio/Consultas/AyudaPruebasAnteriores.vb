Public Class AyudaPruebasAnteriores

    Sub New(ByVal WDatos As DataTable)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        dgvDatos.DataSource = WDatos

    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvDatos.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR CONVERT(LotePartida, System.String) LIKE '%{0}%' OR Fecha LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaPruebasAnteriores = TryCast(Owner, IAyudaPruebasAnteriores)
        
        If WOwner IsNot Nothing Then WOwner._ProcesarAyudaPruebasAnteriores(dgvDatos.CurrentRow.Cells("LotePartida").Value)

        Close()

    End Sub

    Private Sub AyudaPruebasAnteriores_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub
End Class