
Imports Sistema_Solicitud_Fondos
Imports Util.Clases.Query
Public Class Form1
    Dim listaFilasApintar As New List(Of Integer)
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Dim SQLCnslt As String = "SELECT NroSolicitud, MarcaPopUp_Alejandro FROM SolicitudFondos WHERE MarcaPopUp_Alejandro <> 'X'"
        Dim TablaPopUp As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaPopUp.Rows.Count = 0 Then
            Close()
        Else

            For Each RowPopUp As DataRow In TablaPopUp.Rows
                listaFilasApintar.Add(RowPopUp("NroSolicitud"))
            Next

            SQLCnslt = "UPDATE SolicitudFondos SET MarcaPopUp_Alejandro = 'X'"
            ExecuteNonQueries("SurfactanSa", SQLCnslt)

            '            Me.Show()
            Me.BringToFront()
            Me.WindowState = FormWindowState.Normal

            TopMost = True

        End If

    End Sub

    Private Sub btn_Abrir_Click(sender As Object, e As EventArgs) Handles btn_Abrir.Click
        'Try
        '    Process.Start("\\193.168.0.2\g$\vb\NET\Sistema SoliFondos Externo\Debug\Sistema_Solicitud_Fondos.exe", "f")
        'Catch ex As System.Exception
        '    MsgBox(ex.Message)
        'End Try
        With New Login("Gestor", "", listaFilasApintar)
            .Show()
        End With


        Me.Close()

    End Sub
End Class
