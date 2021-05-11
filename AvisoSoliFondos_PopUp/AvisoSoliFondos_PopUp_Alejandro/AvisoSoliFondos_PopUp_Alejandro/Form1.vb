
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
        Dim SQLCnslt As String = "SELECT MarcaPopUp_Alejandro FROM SolicitudFondos WHERE MarcaPopUp_Alejandro <> 'X'"
        Dim RowPopUp As DataTable = getall(SQLCnslt, "SurfactanSa")
        If RowPopUp.Rows.Count = 0 Then
            Close()
        Else
            SQLCnslt = "UPDATE SolicitudFondos SET MarcaPopUp_Alejandro = 'X'"
            ExecuteNonQueries("SurfactanSa", SQLCnslt)
        End If

    End Sub

    Private Sub btn_Abrir_Click(sender As Object, e As EventArgs) Handles btn_Abrir.Click
        Try
            Process.Start("\\193.168.0.2\g$\vb\NET\Sistema SoliFondos Externo\Debug\Sistema_Solicitud_Fondos.exe", "f")
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
        ' With New MenuPrincipal()
        '     .Show(Me)
        ' End With
    End Sub
End Class
