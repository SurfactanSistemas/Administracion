Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class PedidoDetallado


    Sub New(ByVal Pedido As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Pedido.Text = Pedido

        Dim SQLCnslt As String = "SELECT DISTINCT Terminado, FecEntrega, OrdFecEntrega, Pendiente = (Cantidad - Facturado)  " _
                             & "FROM Pedido " _
                             & "WHERE Pedido = '" & txt_Pedido.Text & "' " _
                             & "AND Facturado < Cantidad " _
                             & "ORDER BY OrdFecEntrega"

        Dim TablaPed As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        With TablaPed.Columns
            .Add("Descripcion")
        End With

        If TablaPed.Rows.Count > 0 Then

            For Each RowPed As DataRow In TablaPed.Rows

                If UCase(RowPed.Item("Terminado").ToString().Substring(0, 2)) = "DY" Then
                    Dim CodDy As String = RowPed.Item("Terminado").ToString().Substring(0, 3) & Microsoft.VisualBasic.Right(RowPed.Item("Terminado"), 7)
                    RowPed.Item("Terminado") = CodDy
                End If
                If RowPed.Item("Terminado").ToString().Length = 10 Then
                    SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & RowPed.Item("Terminado") & "'"
                    Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowArticulo IsNot Nothing Then
                        RowPed.Item("Descripcion") = Trim(RowArticulo.Item("Descripcion"))
                    End If
                Else
                    SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & RowPed.Item("Terminado") & "'"
                    Dim RowTerminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowTerminado IsNot Nothing Then
                        RowPed.Item("Descripcion") = Trim(RowTerminado.Item("Descripcion"))
                    End If
                End If

            Next

            DGV_PedidosPendientes.DataSource = TablaPed

        End If

    End Sub
    
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class