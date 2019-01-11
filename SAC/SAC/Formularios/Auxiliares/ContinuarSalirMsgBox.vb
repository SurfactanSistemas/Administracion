Partial Public Class ContinuarSalirMsgBox

    Property _Msg As String
    Property _MsgOk As String
    Property _MsgCancel As String

    Sub New(Optional ByVal msg As Object = "", Optional ByVal msgOk As Object = "", Optional ByVal msgCancel As Object = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Msg = msg
        _MsgOk = msgOk
        _MsgCancel = msgCancel
    End Sub

    Public Shared Function Show(ByVal msg As Object, Optional ByVal msgOk As Object = "Continuar", Optional ByVal msgCancel As Object = "Salir") As DialogResult
        Dim frm As New ContinuarSalirMsgBox(msg, msgOk, msgCancel)
        Return frm.ShowDialog()
    End Function

    Private Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnContinuar.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub ContinuarSalirMsgBox_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label1.Text = _Msg
        btnContinuar.Text = _MsgOk
        btnSalir.Text = _MsgCancel
        Beep()
        Beep()
    End Sub
End Class