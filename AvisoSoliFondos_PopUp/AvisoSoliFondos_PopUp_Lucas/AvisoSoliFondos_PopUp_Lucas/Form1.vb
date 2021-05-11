Imports Sistema_Solicitud_Fondos
Imports Util.Clases.Query
Public Class Form1

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.BringToFront()
        Me.WindowState = FormWindowState.Normal
        TopMost = True
        Dim SQLCnslt As String = "SELECT MarcaPopUp_Lucas FROM SolicitudFondos WHERE MarcaPopUp_Lucas <> 'X'"
        Dim RowPopUp As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If RowPopUp.Rows.Count = 0 Then
            Close()
        Else
            SQLCnslt = "UPDATE SolicitudFondos SET MarcaPopUp_Lucas = 'X'"
            ExecuteNonQueries("SurfactanSa", SQLCnslt)
        End If

    End Sub

    Private Sub btn_Abrir_Click(sender As Object, e As EventArgs) Handles btn_Abrir.Click
        With New MenuPrincipal()
            .Show(Me)
        End With

    End Sub
End Class