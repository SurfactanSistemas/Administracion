Public Class IngresoMotivoDesvio

    Private WMotivo As String

    Sub New(Optional ByVal _Motivo As Object = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WMotivo = Trim(_Motivo)

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If txtMotivo.Text.Trim = "" Then Exit Sub

        Dim WOwner As IIngresoMotivoDesvio = CType(Owner, IIngresoMotivoDesvio)

        If Not IsNothing(WOwner) Then WOwner._ProcesarIngresoMotivoDesvio(txtMotivo.Text.Trim)

        Close()

    End Sub

    Private Sub IngresoMotivoDesvio_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtMotivo.Text = Trim(WMotivo)
    End Sub

    Private Sub IngresoMotivoDesvio_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtMotivo.Focus()
    End Sub

    Private Sub txtMotivo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMotivo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtMotivo.Text) = "" Then : Exit Sub : End If

            btnAceptar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtMotivo.Text = ""
        End If

    End Sub
End Class