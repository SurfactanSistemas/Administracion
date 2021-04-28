Public Class CarteldeProcesados

    Sub New(ByVal Cant_Grabados As Integer, ByVal Cant_No_Grabados As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim total As Integer = Cant_No_Grabados + Cant_Grabados

        lbl_Cargados.Text = lbl_Cargados.Text & " " & Cant_Grabados
        lbl_NoCargados.Text = lbl_NoCargados.Text & " " & Cant_No_Grabados
        lbl_Total.Text = lbl_Total.Text & " " & total
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Close()
    End Sub
End Class