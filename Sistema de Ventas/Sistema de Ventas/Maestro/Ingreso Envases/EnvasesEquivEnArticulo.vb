Imports ConsultasVarias.Clases.Query
Public Class EnvasesEquivEnArticulo

    Sub New(ByVal NroEnvase As Integer, ByVal NomEnvase As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtNroEnvases.Text = NroEnvase
        txtNomEnvases.Text = NomEnvase

        Dim SQLCnslt As String = "SELECT Codigo = Articulo, Nombre = Descripcion FROM EquivEnvArticulo WHERE Envase = '" & txtNroEnvases.Text & "'"
        Dim tablaEnvArt As DataTable = GetAll(SQLCnslt)
        DGV_EnvasesEnArticulo.DataSource = tablaEnvArt
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaEnvArt As DataTable = DGV_EnvasesEnArticulo.DataSource
        TablaEnvArt.DefaultView.RowFilter = "Codigo LIKE '%" & txtBuscador.Text & "%' OR Nombre LIKE '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub EnvasesEquivEnArticulo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub
End Class