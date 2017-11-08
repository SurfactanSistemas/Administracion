Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ComparacionesMensuales

    Private Sub cmbTipoGrafico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoGrafico.SelectedIndexChanged

        Select Case cmbTipoGrafico.SelectedIndex
            Case 1
                PictureBox1.Image = My.Resources.GraficoBarras
            Case 2
                PictureBox1.Image = My.Resources.GraficoTortas
            Case 3
                PictureBox1.Image = My.Resources.GraficoLineas
            Case Else
                PictureBox1.Image = Nothing
                Exit Sub
        End Select

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim tabla As New DataTable("Detalles")

        With tabla
            .Columns.Add("Tipo")
            .Columns.Add("Descripcion")
            .Columns.Add("Titulo")

            For i = 1 To 12
                .Columns.Add("Valor" & i, System.Type.GetType("System.Double"))
            Next

            For i = 1 To 12
                .Columns.Add("Titulo" & i)
            Next

        End With

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim ZSql As String = ""
        Dim Temp = "SELECT Tipo, Descripcion, Descripcion as Titulo #DATOS# FROM Comando", Aux = ""
        Dim dato = "Venta"

        For i = 1 To 12
            Aux &= ", " & dato & i & " as Valor" & i
        Next

        For i = 1 To 12
            Aux &= ", Impre" & i & " as Titulo" & i
        Next

        ZSql = Temp.Replace("#DATOS#", Aux)

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            cm.CommandText = ZSql
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

        Dim WReporte As ReportDocument = Nothing

        Select Case cmbTipoComparacion.SelectedIndex
            Case 1

                Select Case cmbTipoGrafico.SelectedIndex
                    Case 1
                        WReporte = New TrimestralValorUnicoBarras
                    Case 2
                        WReporte = New TrimestralValorUnicoTortas
                    Case 3
                        WReporte = New TrimestralValorUnicoLineas
                    Case Else
                        Exit Sub
                End Select

            Case Else
                Exit Sub
        End Select

        With VistaPrevia
            .Reporte = WReporte
            .Reporte.SetDataSource(tabla)
            .Mostrar()
        End With
    End Sub
End Class