Imports Util.Clases.Query
Public Class Mail_Reclamo_Historial
    Sub New(ByVal nroSolicitud As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        CargarMAil(nroSolicitud)

    End Sub

    Private Sub CargarMAil(ByVal NroSolicitud As Integer)

        Try
            Dim SQLCnslt As String = "SELECT Envio = RTRIM(Envio), Asunto = RTRIM(Asunto), Cuerpo, NumeroMail FROM SolicitudFondos_HistorialMails WHERE NroSolicitud = '" & NroSolicitud & "' ORDER BY NumeroMail"
            Dim TablaHistorial As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            DGV_HistorialMails.DataSource = TablaHistorial
        Catch ex As Exception

        End Try
    End Sub

End Class