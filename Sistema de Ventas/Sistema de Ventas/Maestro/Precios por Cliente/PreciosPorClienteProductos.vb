Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class PreciosPorClienteProductos

    Private WCliente As String = ""

    Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        WCliente = Cliente

    End Sub

    Private Sub PreciosPorClienteProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        txtCliente.Text = WCliente

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WClienteDatos As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & WCliente & "'")

        BackgroundWorker1.ReportProgress(1, WClienteDatos)

        Dim WProductos As DataTable = GetAll("SELECT Producto, Tipo, Descripcion, Estado = CASE Estado WHEN '2' THEN 'COTIZACIÓN' WHEN '1' THEN 'HISTÓRICO' ELSE 'ACTIVO' END, Operador = '' FROM (SELECT Terminado As Producto, Tipo = 'T', Descripcion, ISNULL(Estado, 0) As Estado FROM Precios WHERE Cliente = '" & WCliente & "' UNION SELECT pmp.Articulo AS Producto, Tipo = 'M', Descripcion = CASE WHEN ISNULL(a.DescriComercial,'') = '' THEN a.Descripcion ELSE a.DescriComercial END, ISNULL(Estado, 0) As Estado  FROM PreciosMp pmp INNER JOIN Articulo a ON a.Codigo = pmp.Articulo WHERE Cliente = '" & WCliente & "') AS p ORDER BY p.Producto")

        BackgroundWorker1.ReportProgress(2, WProductos)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                lblRazon.Text = ""

                Dim WClienteDatos As DataRow = TryCast(e.UserState, DataRow)

                If WClienteDatos IsNot Nothing Then lblRazon.Text = Trim(OrDefault(WClienteDatos("Razon"), ""))

            Case 2
                dgvProductos.DataSource = TryCast(e.UserState, DataTable)
        End Select

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtFiltrar.Focus()
    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvProductos.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Producto LIKE '%{0}%' OR Descripcion LIKE '%{0}%' OR Operador LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then
                Dim tabla = TryCast(dgvProductos.DataSource, DataTable)
                If tabla IsNot Nothing Then tabla.Rows.Clear()

                Exit Sub
            End If

            WCliente = txtCliente.Text

            If BackgroundWorker1.IsBusy Then BackgroundWorker1.CancelAsync()

            BackgroundWorker1.RunWorkerAsync()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub dgvProductos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvProductos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        Dim WProducto As String = OrDefault(dgvProductos.CurrentRow.Cells("Producto").Value, "")
        Dim WTipo As String = OrDefault(dgvProductos.CurrentRow.Cells("Tipo").Value, "")

        If WProducto.Trim = "" Then Exit Sub

        '
        ' Llamamos para editar el Precio y datos extras para este Producto.
        '
        With New PreciosClienteProducto(txtCliente.Text, WProducto, WTipo = "M")
            .Show(Me)
        End With

    End Sub
End Class