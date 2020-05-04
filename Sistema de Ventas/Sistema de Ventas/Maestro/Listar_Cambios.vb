Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class Listar_Cambios

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidaFecha(txtDesdeFecha.Text) = "S" And ValidaFecha(txtHastaFecha.Text) = "S" Then
            Dim SQLCnslt As String = "SELECT Fecha, Cambio, OrdFecha, CambioII, CambioDivisa " _
                                     & "FROM Cambios WHERE OrdFecha >= '" & ordenaFecha(txtDesdeFecha.Text) & "' " _
                                     & "AND OrdFecha <= '" & ordenaFecha(txtHastaFecha.Text) & "'"
            Dim ListaCambios As DataTable = GetAll(SQLCnslt, "SurfactanSA")

            If ListaCambios.Rows.Count > 0 Then
                Dim SubTitulo As String = "Desde " & txtDesdeFecha.Text & " Hasta " & txtHastaFecha.Text
                With New VistaPrevia
                    .Reporte = New ReporteListaCambios()
                    .Reporte.SetDataSource(ListaCambios)
                    .Reporte.SetParameterValue(0, SubTitulo)

                    If rabtnPantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
                End With
            End If

        End If
    End Sub



    Private Sub txtDesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                    txtHastaFecha.Focus()
                End If
            Case Keys.Escape
                txtDesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txtHastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtHastaFecha.Text) = "S" Then
                    btnAceptar_Click(Nothing, Nothing)
                End If
            Case Keys.Escape
                txtHastaFecha.Text = ""
        End Select
    End Sub
End Class