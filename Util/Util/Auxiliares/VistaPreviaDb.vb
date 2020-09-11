Public Class VistaPreviaDb
    Sub New(Optional ByVal ds As DataTable = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DbDataGridView1.DataSource = ds
    End Sub
End Class