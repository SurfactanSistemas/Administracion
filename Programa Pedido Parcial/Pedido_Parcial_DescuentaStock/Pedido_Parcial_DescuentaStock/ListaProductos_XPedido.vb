Imports Util.Clases.Query

Public Class ListaProductos_XPedido
    Dim NRO_PEDIDO As String = 0
    Dim BASE_CONSULTAR As String = ""

    Sub New(ByVal Pedido As String, ByVal Base As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        NRO_PEDIDO = Pedido
        lbl_Pedido.Text = lbl_Pedido.Text & Pedido

        BASE_CONSULTAR = Base


        CargarProductosPedidos()

    End Sub
    
    Private Sub CargarProductosPedidos()
        Dim SQLCnslt As String = "SELECT DISTINCT Articulo FROM Estadistica WHERE Pedido = '" & NRO_PEDIDO & "'" _
                                  & " AND Marca = 'X' AND Lote1 = '999999'"
        Dim tableEstadistica As DataTable = GetAll(SQLCnslt, BASE_CONSULTAR)
        If tableEstadistica.Rows.Count > 0 Then
            For Each Row As DataRow In tableEstadistica.Rows
                dgv_Productos.Rows.Add(Row.Item("Articulo"), "")
            Next
        End If

        If dgv_Productos.Rows.Count > 0 Then
            BuscarDescripcion()
        End If

    End Sub

    Private Sub BuscarDescripcion()
        Dim SQLCnslt As String = ""
        For Each dgv_Row As DataGridViewRow In dgv_Productos.Rows
            If dgv_Row.Cells("Producto").Value.ToString().StartsWith("DY-") Then
                Dim CodigoArticulo As String = Microsoft.VisualBasic.Left(dgv_Row.Cells("Producto").Value, 3) & Microsoft.VisualBasic.Right(dgv_Row.Cells("Producto").Value, 7)
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & CodigoArticulo & "'"
                Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowArticulo IsNot Nothing Then
                    dgv_Row.Cells("Descripcion").Value = RowArticulo.Item("Descripcion")
                End If

            Else
                SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & dgv_Row.Cells("Producto").Value & "'"
                Dim RowTerminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowTerminado IsNot Nothing Then
                    dgv_Row.Cells("Descripcion").Value = RowTerminado.Item("Descripcion")
                End If
            End If
        Next
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub dgv_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Productos.CellDoubleClick
        Dim Wowner As IPasaCodigo = TryCast(Owner, IPasaCodigo)
        If Wowner IsNot Nothing Then
            Wowner.PasaCodigo(dgv_Productos.CurrentRow.Cells("Producto").Value)
        End If
        Close()
    End Sub
End Class