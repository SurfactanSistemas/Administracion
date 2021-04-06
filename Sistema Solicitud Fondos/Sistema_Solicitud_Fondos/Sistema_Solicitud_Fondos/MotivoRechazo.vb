Imports System.Diagnostics.Eventing.Reader

Public Class MotivoRechazo

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If Trim(txt_Motivo.Text) <> "" Then
            Dim Wowner As IMotivoRechazo = TryCast(Owner, IMotivoRechazo)

            If Wowner IsNot Nothing Then
                Wowner.PasaMotivo(Trim(txt_Motivo.Text))
            End If
            Close()
        Else
            MsgBox("Debe ingresar un motivo para rechazar la/s solicitudes", vbExclamation)
        End If
        
    End Sub
End Class