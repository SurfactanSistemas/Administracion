Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Pedi_Pendi_Fazon_Pellital

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
       
        

        Dim WDesde As String = "00000000"
        Dim WHasta As String = "99999999"


        Dim SQLCnlst As String = "UPDATE Pedido SET Importe = 0"

        ExecuteNonQueries("SurfactanSa", {SQLCnlst})

        SQLCnlst = "UPDATE  Pedido SET Importe = Cantidad - Facturado WHERE OrdFecEntrega >= '" & WDesde & "' " _
                    & "AND OrdFecentrega <= '" & WHasta & "'"

        ExecuteNonQueries("SurfactanSa", {SQLCnlst})

        
        SQLCnlst = "SELECT Terminado FROM Pedido WHERE Importe > 0 ORDER BY Pedido"

        Dim TablaPedido As DataTable = GetAll(SQLCnlst)

        Dim ListaTerminados As New List(Of String)

        If TablaPedido.Rows.Count > 0 Then

            For Each RowPedido As DataRow In TablaPedido.Rows

                If RowPedido.Item("Terminado") = "P00005" Then
                    Dim EntraVector As String = "S"
                    For Ciclo = 0 To ListaTerminados.Count - 1
                        If ListaTerminados(Ciclo) = RowPedido.Item("Terminado") Then
                            EntraVector = "N"
                            Exit For
                        End If
                    Next Ciclo
                    If EntraVector = "S" Then
                        ListaTerminados.Add(ListaTerminados.Item("Terminado"))
                    End If
                End If

            Next
                        
        End If

        Dim WDescripcion As String = ""
        For Ciclo = 0 To ListaTerminados.Count - 1
            Dim WProducto As String = ListaTerminados(Ciclo)
            Dim WTipopro As String = Microsoft.VisualBasic.Left$(WProducto, 2)
            If WTipopro <> "PT" And WTipopro <> "PE" Then

                Dim WArticulo As String = Microsoft.VisualBasic.Left$(WProducto, 3) + Microsoft.VisualBasic.Right$(WProducto, 7)

                SQLCnlst = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArticulo & "'"

                Dim RowArticulo As DataRow = GetSingle(SQLCnlst, "SurfactanSa")
                If RowArticulo IsNot Nothing Then
                    WDescripcion = RowArticulo.Item("Descripcion")


                    SQLCnlst = "UPDATE Pedido SET Descripcion = '" & WDescripcion & "' WHERE Articulo = '" & WArticulo & "'"

                    ExecuteNonQueries("SurfactanSa", {SQLCnlst})

                End If


            Else

                Dim WTerminado As String = WProducto

                Dim RowTerminado As DataRow = GetSingle(SQLCnlst, "SurfactanSa")

                If RowTerminado IsNot Nothing Then

                    WDescripcion = RowTerminado.Item("Descripcion")

                    SQLCnlst = "PDATE Pedido SET Descripcion = '" & WDescripcion & "'  WHERE Terminado = '" & WTerminado & "'"

                    ExecuteNonQueries("SurfactanSa", {SQLCnlst})

                End If

            End If
        Next Ciclo


        SQLCnlst = "UPDATE Pedido SET Descripcion = NombreComercial WHERE Terminado >= '" & "ML-00000-000" & "' " _
                    & "AND Terminado <= '" & "ML-99999-999" & "'"

        ExecuteNonQueries("SurfactanSa", {SQLCnlst})


        
        With New VistaPrevia
            .Reporte = New Reporte_Pedidos_Pendientes_Fazon_Pellital()
            .Reporte.SetParameterValue(0, Operador.Base)

            If rabtn_Pantalla.Checked = True Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

        
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class