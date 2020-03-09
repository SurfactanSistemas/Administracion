Imports ConsultasVarias.Clases.Query
Public Class MostrarClientesXVendedor

    Sub New(ByVal NroVendedor As Integer, ByVal NombreVendedor As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtNroVendedor.Text = NroVendedor
        txtNomVendedor.Text = Trim(NombreVendedor)

        Dim SQLCnslt As String = "SELECT Codigo = Cliente, Nombre = Razon FROM Cliente WHERE Vendedor = '" & txtNroVendedor.Text & "' ORDER BY Razon"
        Dim TablaClientesXVend As DataTable = GetAll(SQLCnslt)
        DGV_ClientesXVendedor.DataSource = TablaClientesXVend
    End Sub

    Private Sub MostrarClientesXVendedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub

 
    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaXVendedor As DataTable = DGV_ClientesXVendedor.DataSource
        TablaXVendedor.DefaultView.RowFilter = "Codigo LIKE '%" & txtBuscador.Text & "%' OR Nombre LIKE '%" & txtBuscador.Text & "%'"
    End Sub
End Class