Imports Util

Public Class LoginNotaRetiro

    Private Sub LoginNotaRetiro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtClave.Focus()
    End Sub

    Private Sub LoginNotaRetiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtClave.Text = ""
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If

            btnAceptar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        DialogResult = Windows.Forms.DialogResult.Ignore

        If txtClave.Text.Trim = "" Then Exit Sub

        Dim WOperador As DataRow = GetSingle("SELECT Operador, Descripcion FROM Operador WHERE Clave = '" & txtClave.Text & "'", "SurfactanSa")

        If WOperador Is Nothing Then Exit Sub

        Dim WAutorizados As String() = Configuration.ConfigurationManager.AppSettings("AUTORIZADOS_NOTA_RETIRO").ToString.Split(",")

        If WAutorizados.Contains(WOperador(0)) Then
            Operador.FirmaDigital = Clases.Helper.FirmaDigital(WOperador(0))
            Operador.Descripcion = Clases.Helper.FirmaDigital(WOperador(1))

            DialogResult = Windows.Forms.DialogResult.OK

            Close()
        End If

    End Sub
End Class