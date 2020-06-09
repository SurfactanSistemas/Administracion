
Imports Util.Clases.Query

Public Class BuscadorVendedor

    Private Sub BuscadorVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Vendedor, Nombre FROM Vendedor WHERE Vendedor <> 0 ORDER BY Vendedor"
        Dim tablaVendedores As DataTable = GetAll(SQLCnslt)
        If tablaVendedores.Rows.Count > 0 Then
            DGV_Vendedores.DataSource = tablaVendedores
        End If
    End Sub

    Private Sub BuscadorVendedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TxtBuscador.Focus()
    End Sub

    Private Sub TxtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                TxtBuscador.Text = ""
        End Select
    End Sub

    Private Sub DGV_Vendedores_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Vendedores.CellMouseDoubleClick
        Dim Wowner As IBuscadorVendedor = TryCast(Owner, IBuscadorVendedor)

        If Wowner IsNot Nothing Then
            Wowner._ProcesarDatosVendedor(DGV_Vendedores.CurrentRow.Cells("Codigo").Value, DGV_Vendedores.CurrentRow.Cells("Nombre").Value)
            Close()
        End If
    End Sub

    Private Sub TxtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtBuscador.KeyUp
        Dim tablaVendedores As DataTable = DGV_Vendedores.DataSource

        tablaVendedores.DefaultView.RowFilter = "convert(Codigo, System.String) LIKE '%" & TxtBuscador.Text & "%' OR Nombre LIKE '%" & TxtBuscador.Text & "%'"
    End Sub
End Class