Imports System.Configuration
Imports System.Data.SqlClient

Public Class ListadoDeEnsayoDePT

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
        cn.Open()
        Dim sqlconsulta As String
        sqlconsulta = "DELETE VerificaEnsayo"
        Dim cmd As New SqlCommand(sqlconsulta, cn)
        cmd.ExecuteNonQuery()


        sqlconsulta = "SELECT Producto, Ensayo1 , Valor1, Ensayo2 , Valor2, Ensayo3 , Valor3,"
        sqlconsulta = sqlconsulta & " Ensayo4 , Valor4, Ensayo5 , Valor5,Ensayo6 , Valor6, "
        sqlconsulta = sqlconsulta & " Ensayo7 , Valor7,Ensayo8 , Valor8, Ensayo9 , Valor9, Ensayo10 , Valor10 FROM EspecifUnifica"
        Dim dr As SqlDataReader
        cmd = New SqlCommand(sqlconsulta, cn)
        dr = cmd.ExecuteReader()
        Dim tablaReporte As New DataTable
        With tablaReporte.Columns
            .Add("Producto")
            .Add("Ensayo")
            .Add("Valor")
        End With



        If (dr.HasRows) Then
            While (dr.Read())

                For i As Integer = 1 To 10
                    If (dr.Item("Ensayo" & i) >= Val(txtDesde.Text) And dr.Item("Ensayo" & i) <= Val(txtHasta.Text)) Then
                        Dim row As DataRow = tablaReporte.NewRow()
                        row("Producto") = dr.Item("Producto")
                        row("Ensayo") = dr.Item("Ensayo" & i)
                        row("Valor") = dr.Item("Valor" & i)
                        tablaReporte.Rows.Add(row)
                    End If

                Next
            End While

        End If

        With New VistaPrevia
            .Base = "SURFACTAN_II"
            .Reporte = New ReporteListadoEspecifPTaFecha()
            .Reporte.SetDataSource(tablaReporte)

            If (rabPantalla.Checked = True) Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtHasta.Focus()
        End Select
    End Sub

    Private Sub ListadoDeEnsayoDePT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Focus()
    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If (txtHasta.Text = "") Then
                    txtHasta.Text = txtDesde.Text
                End If

        End Select
    End Sub
End Class