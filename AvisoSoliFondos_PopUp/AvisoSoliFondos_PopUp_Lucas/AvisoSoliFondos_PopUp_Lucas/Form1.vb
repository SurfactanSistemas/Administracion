Imports Util.Clases.Query
Public Class Form1

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.BringToFront()
        Me.WindowState = FormWindowState.Normal
        TopMost = True
        Dim SQLCnslt As String = "SELECT MarcaPopUp_Lucas FROM SolicitudFondos WHERE MarcaPopUp_Lucas <> 'X'"
        Dim RowPopUp As DataTable = getall(SQLCnslt, "SurfactanSa")
        If RowPopUp.Rows.Count = 0 Then
            Close()
        End If

    End Sub
End Class