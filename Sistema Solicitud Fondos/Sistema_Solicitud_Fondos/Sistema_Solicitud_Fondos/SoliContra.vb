Public Class SoliContra

    Private NroSolicitud As Integer
    Sub New(Optional ByVal NroSoli As Integer = 0)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        NroSolicitud = NroSoli

    End Sub
    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub txt_Contraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Contraseña.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If UCase(txt_Contraseña.Text) = "AUTORIZO" Then
                    Dim Wowner As IContraseña = TryCast(Owner, IContraseña)

                    If NroSolicitud < 0 Then
                        If Wowner IsNot Nothing Then
                            Wowner.Autorizado("S", NroSolicitud)
                            Close()
                        End If
                    Else
                        If Wowner IsNot Nothing Then
                            Wowner.AutorizarSolicitudes()
                            Close()
                        End If
                    End If
                   
                Else
                    txt_Contraseña.Text = ""
                End If
            Case Keys.Escape
                txt_Contraseña.Text = ""
        End Select
        
    End Sub
End Class