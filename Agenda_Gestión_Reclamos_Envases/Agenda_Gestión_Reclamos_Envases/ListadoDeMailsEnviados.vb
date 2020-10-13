Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query


Public Class ListadoDeMailsEnviados


    Private WOrd As String = ""
    Sub New(ByVal CodClie As String, ByVal DesClie As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Cliente.Text = CodClie
        txt_ClienteDes.Text = DesClie

        Dim SQlCnslt As String = "SELECT id, Fecha, FechaOrd, Asunto FROM DevolucionEnvMails WHERE Cliente = '" & CodClie & "' ORDER BY Fechaord"

        Dim TablaMails As DataTable = GetAll(SQlCnslt, "SurfactanSa")

        If TablaMails.Rows.Count > 0 Then

            DGV_Mails.DataSource = TablaMails

        End If

    End Sub

    Private Sub DGV_Mails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Mails.CellDoubleClick
        With DGV_Mails.CurrentRow
            With New EnviarMAIL_Cliente(txt_Cliente.Text, txt_ClienteDes.Text, .Cells("id").Value)
                .Show(Me)
            End With
        End With
    End Sub

    Private Sub DGV_Mails_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Mails.ColumnHeaderMouseClick

        Dim TablaAuxII As DataTable = TryCast(DGV_Mails.DataSource, DataTable)

        ' Yo, lo haría asi. O mejor dicho, lo hago así.

        WOrd = IIf(WOrd = "", "DESC", "")


        Select Case e.ColumnIndex

            Case 1
                TablaAuxII.DefaultView.Sort = "FechaOrd " & WOrd
            Case 3
                TablaAuxII.DefaultView.Sort = "Asunto " & WOrd
           

        End Select
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class