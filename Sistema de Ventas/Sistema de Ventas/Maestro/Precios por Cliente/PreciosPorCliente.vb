Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class PreciosPorCliente

    Private Sub PreciosPorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim WClientes As DataTable = GetAll("SELECT c.Cliente, c.Razon, NumProd = COUNT(p.Producto) FROM Cliente c LEFT OUTER JOIN (SELECT Cliente, Terminado As Producto FROM Precios UNION SELECT Cliente, Articulo AS Producto FROM PreciosMp) as p ON p.Cliente = c.Cliente GROUP BY c.Cliente, c.Razon ORDER BY c.Cliente")

        BackgroundWorker1.ReportProgress(1, WClientes)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        dgvClientes.DataSource = TryCast(e.UserState, DataTable)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtCliente.Focus()
    End Sub

    Private Sub PreciosPorCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCliente.Focus()
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then
                txtFiltrar.Focus()
                Exit Sub
            End If

            Dim _Cli As String = Helper.Left(txtCliente.Text, 1) & String.Format("{0,5:00000}", Val(txtCliente.Text.Substring(1, txtCliente.Text.Length - 1)))

            txtCliente.Text = _Cli

            Dim WCliente As DataRow = GetSingle("SELECT Cliente FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If WCliente Is Nothing Then Exit Sub

            With New PreciosPorClienteProductos(txtCliente.Text)
                .Show(Me)
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvClientes.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Cliente LIKE '%{0}%' OR Razon LIKE '%{0}%'", txtFiltrar.Text)
    End Sub

    Private Sub dgvClientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvClientes.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        Dim WCliente As String = OrDefault(dgvClientes.CurrentRow.Cells("Cliente").Value, "")

        If WCliente.Trim = "" Then Exit Sub

        '
        ' Llamo a la ventana con los productos de cada cliente.
        '
        With New PreciosPorClienteProductos(WCliente)
            .Show(Me)
        End With

    End Sub
End Class