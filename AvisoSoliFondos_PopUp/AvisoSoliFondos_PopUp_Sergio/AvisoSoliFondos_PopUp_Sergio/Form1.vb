Imports Sistema_Solicitud_Fondos
Imports Util.Clases.Query
Public Class Form1
    Dim listaFilasApintar As New List(Of Integer)

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      

        Dim SQLCnslt As String = "SELECT NroSolicitud, MarcaPopUp_Sergio FROM SolicitudFondos WHERE MarcaPopUp_Sergio <> 'X'"
        Dim TablaPopUp As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaPopUp.Rows.Count = 0 Then
            Close()
        Else


            For Each RowPopUp As DataRow In TablaPopUp.Rows
                listaFilasApintar.Add(RowPopUp("NroSolicitud"))
            Next

            ' SQLCnslt = "UPDATE SolicitudFondos SET MarcaPopUp_Sergio = 'X'"
            ' ExecuteNonQueries("SurfactanSa", SQLCnslt)

            '            Me.Show()
            Me.BringToFront()
            Me.WindowState = FormWindowState.Normal

            TopMost = True

        End If

    End Sub

    Private Sub btn_Abrir_Click(sender As Object, e As EventArgs) Handles btn_Abrir.Click
        Try
            Dim SQLCnslt As String = "UPDATE SolicitudFondos SET MarcaPopUp_Sergio = 'X'"
            ExecuteNonQueries("SurfactanSa", SQLCnslt)
        Catch ex As Exception

        End Try
        
        'With New Gestion_Solicitudes(listaFilasApintar)
        '    .Show()
        'End With
        With New Login("Gestor", "", listaFilasApintar)
            .Show()
        End With


        Close()
    End Sub

    
End Class

