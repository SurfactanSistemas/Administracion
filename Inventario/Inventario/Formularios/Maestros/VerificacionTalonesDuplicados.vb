Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class VerificacionTalonesDuplicados

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub VerificacionCorrelatividades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbSoloDuplicados.Checked = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT i.Numero, i.Tipo, i.Terminado, i.Articulo, ISNULL(i.Talon, 0) Talon, (SELECT Count(i2.Talon) FROM Inventario i2 WHERE i2.Talon = i.Talon GROUP BY i2.Talon) Cantidad FROM Inventario i ORDER BY i.Numero, i.Talon")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

            If tabla.Rows.Count > 0 Then

                Dim ds As New DSVerificaTalonesDuplicados
                
                For Each row As DataRow In tabla.Rows
                    Dim r As DataRow = ds.Tables("Detalles").NewRow

                    With r
                        .Item("Clave") = row.Item("Numero") & row.Item("Talon")
                        .Item("Numero") = row.Item("Numero")
                        .Item("Talon") = row.Item("Talon")
                        '.Item("Renglon") = row.Item("Renglon")
                        .Item("Tipo") = row.Item("Tipo")
                        .Item("Terminado") = row.Item("Terminado")
                        .Item("Articulo") = row.Item("Articulo")
                        .Item("Cantidad") = row.Item("Cantidad")
                    End With

                    ds.Tables("Detalles").Rows.Add(r)

                Next

                Dim rpt As New VerificarTalonesDuplicados
                Dim frm As New VistaPrevia

                rpt.SetDataSource(ds)

                frm.Reporte = rpt

                If rbSoloDuplicados.Checked Then
                    frm.Formula = "{Detalles.Cantidad} > 1"
                End If

                frm.Mostrar()

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class