Imports System.Data.SqlClient

Public Class MenuPrincipal

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebaToolStripMenuItem.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Comando")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable("Detalles")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try



        With VistaPrevia
            .Reporte = New ListadoNormal
            .Reporte.SetDataSource(tabla)
            .Mostrar()
        End With

    End Sub

    Private Sub ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem.Click
        ComparacionEntreFamiliasPeriodos.Show()
    End Sub
End Class
