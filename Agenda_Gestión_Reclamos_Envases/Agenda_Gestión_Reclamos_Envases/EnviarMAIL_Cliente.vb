Imports System.Web.UI.WebControls.Expressions
Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class EnviarMAIL_Cliente

    Sub New(ByVal CodigoCli As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Cliente.Text = CodigoCli
        txt_Asunto.Text = "CONTACTO POR CONTENEDORES"
        Dim SQLCnslt As String = "SELECT Razon, Emailenv, Email FROM Cliente WHERE Cliente = '" & CodigoCli & "'"

        Dim RowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        If RowCliente IsNot Nothing Then

            txt_ClienteDes.Text = RowCliente.Item("Razon")
            If Trim(RowCliente.Item("Emailenv")) <> "" Then
                txt_DirMail.Text = Trim(RowCliente.Item("Emailenv"))
            Else
                If RowCliente.Item("Email") <> "" Then
                    If MsgBox("No cuenta con un mail de envases. ¿Desea usar el mail de contacto?", vbYesNo) = vbYes Then
                        txt_DirMail.Text = Trim(RowCliente.Item("Email"))
                    End If
                End If
                
            End If
        End If

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        If MsgBox("Se enviara a la direccion : " & txt_DirMail.Text & " " & vbCrLf & " " _
                    & "Con el asunto : " & txt_Asunto.Text & " " & vbCrLf & " " _
                    & "Con el texto : " & txt_Texto.Text & " " & vbCrLf & " ", vbYesNoCancel) = vbYes Then
            Try
                _EnviarEmail(txt_DirMail.Text, txt_Asunto.Text, txt_Texto.Text, {}, True)
                Close()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub txt_DirMail_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DirMail.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Asunto.Focus()
            Case Keys.Escape
                txt_DirMail.Text = ""
        End Select
    End Sub

    Private Sub txt_Asunto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Asunto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Texto.Focus()
            Case Keys.Escape
                txt_Asunto.Text = ""
        End Select
    End Sub

    Private Sub txt_Texto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Texto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btn_Enviar_Click(Nothing, Nothing)
            Case Keys.Escape
                txt_Texto.Text = ""
        End Select
    End Sub
End Class