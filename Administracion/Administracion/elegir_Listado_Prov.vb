Public Class elegir_Listado_Prov

    

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If rabtn_Resumido.Checked Then
            With VistaPrevia
                .Reporte = New ListadoResumidoProveedores
                .Mostrar()
            End With
        End If

        If rabtn_Calidad.Checked Then
            With VistaPrevia
                .Reporte = New ListadoCalidadProveedores
                .Mostrar()
            End With
        End If
        Close()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub
End Class