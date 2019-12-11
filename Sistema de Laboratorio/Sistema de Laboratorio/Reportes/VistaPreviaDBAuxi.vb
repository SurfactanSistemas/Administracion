Public Class VistaPreviaDBAuxi

    Sub New(ByVal datos As DataTable)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DbDataGridView1.DataSource = datos

    End Sub

    Private Sub VistaPreviaDBAuxi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each c As DataGridViewColumn In DbDataGridView1.Columns
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

    End Sub
End Class