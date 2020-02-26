
Imports ConsultasVarias.Clases.Query
Public Class BuscadorCliente

    Private Sub BuscadorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Cliente, Nombre = Razon FROM Cliente WHERE Razon <> '' ORDER BY Nombre"
        Dim TablaClientes As DataTable = GetAll(SQLCnslt)
        If TablaClientes.Rows.Count > 0 Then
            DGV_Clientes.DataSource = TablaClientes
        End If
    End Sub

    Private Sub txtBuscador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscador.KeyPress
        Dim TablaClientes As DataTable = DGV_Clientes.DataSource

        TablaClientes.DefaultView.RowFilter = "Nombre LIKE '%" & txtBuscador.Text & "%' OR Codigo LIKE '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Select
                txtBuscador.Text = ""
        End Select
    End Sub

    Private Sub DGV_Clientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Clientes.CellMouseDoubleClick
        Dim WOwner As IBuscadorCliente = TryCast(Owner, IBuscadorCliente)

        If WOwner IsNot Nothing Then
            WOwner._ProcesarDatosCLiente(DGV_Clientes.CurrentRow.Cells("Codigo").Value, DGV_Clientes.CurrentRow.Cells("Nombre").Value)
            Close()
        End If

    End Sub

    Private Sub BuscadorCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub
End Class