Public Class VistaPreviaDS

    Private WDatos As DataTable

    Sub New(ByVal DS As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WDatos = DS

    End Sub

    Private Sub VistaPreviaDS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = WDatos
    End Sub
End Class