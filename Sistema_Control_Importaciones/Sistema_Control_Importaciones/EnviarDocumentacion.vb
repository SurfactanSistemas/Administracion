Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class EnviarDocumentacion

    Dim WBaseConectar As String = ""

    Sub New(ByVal Orden As String, ByVal Provee As String, ByVal DescripProvee As String, ByVal BaseConectar As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txt_Orden.Text = Orden
        txt_Provee.Text = Provee
        txt_DesProvee.Text = DescripProvee

        WBaseConectar = BaseConectar
    End Sub

    Private Sub txt_MailOriginal_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_BLOriginal.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_BLOriginal.Text) <> "" Then
                    txt_FacturaOriginal.Focus()
                End If
            Case Keys.Escape
                txt_BLOriginal.Text = ""
        End Select
    End Sub

    Private Sub txt_FacturaOriginal_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FacturaOriginal.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_FacturaOriginal.Text) <> "" Then
                    txt_CertificadoOrigen.Focus()
                End If
            Case Keys.Escape
                txt_FacturaOriginal.Text = ""
        End Select
    End Sub

    Private Sub txt_CertificadoOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_CertificadoOrigen.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_CertificadoOrigen.Text) <> "" Then
                    txt_FacturaOriginal.Focus()
                End If
            Case Keys.Escape
                txt_CertificadoOrigen.Text = ""
        End Select
    End Sub

    Private Sub txt_PackingList_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PackingList.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_PackingList.Text) <> "" Then
                    txt_Coas.Focus()
                End If
            Case Keys.Escape
                txt_PackingList.Text = ""
        End Select
    End Sub

    Private Sub txt_Coas_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Coas.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_PackingList.Text) <> "" Then
                    txt_Coas.Focus()
                End If
            Case Keys.Escape
                txt_PackingList.Text = ""
        End Select
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub btn_Imprimir_Click(sender As Object, e As EventArgs) Handles btn_Imprimir.Click

        Dim WCarpeta As String = ""

        Dim SQLCnslt As String = "SELECT Carpeta FROM Orden WHERE Orden = '" & Trim(txt_Orden.Text) & "'"
        Dim RowOrden As DataRow = GetSingle(SQLCnslt, WBaseConectar)

        If RowOrden IsNot Nothing Then

            WCarpeta = OrDefault(RowOrden.Item("Carpeta"), "")

            With New VistaPrevia
                .Reporte = New Reporte_EntregarDocumentacion()
                .Reporte.SetParameterValue("DesProveedor", txt_DesProvee.Text)
                .Reporte.SetParameterValue("Carpeta", WCarpeta)
                .Reporte.SetParameterValue("BLOriginal", txt_BLOriginal.Text)
                .Reporte.SetParameterValue("FacturaOriginal", txt_FacturaOriginal.Text)
                .Reporte.SetParameterValue("CertificadoOrigen", txt_CertificadoOrigen.Text)
                .Reporte.SetParameterValue("PackingList", txt_PackingList.Text)
                .Reporte.SetParameterValue("COAS", txt_Coas.Text)

                For i = 0 To 1
                    .Imprimir()
                Next

                Close()

            End With
        End If
        
    End Sub
End Class