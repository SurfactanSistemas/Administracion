Public Class CambioEmpresa

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If cmbEmpresas.SelectedIndex < -1 Then cmbEmpresas.SelectedIndex = 0

        Globales.EmpresaActual = cmbEmpresas.SelectedIndex

        ComparacionesMensualesValorUnico.Show()

        Close()

    End Sub

    Private Sub CambioEmpresa_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbEmpresas.SelectedIndex = 0

        With New ComparacionesMensualesValorUnico
            .txtFechaDiaria.Text = Date.Now.ToString("dd/MM/yyyy")
            .rbDiaria.Checked = True
            ._ProcesarComparacionDiaria(True)
        End With
        Close()

    End Sub

    Private Sub CambioEmpresa_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        cmbEmpresas.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub cmbEmpresas_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbEmpresas.KeyDown

        If e.KeyData = Keys.Enter Then
            btnAceptar.PerformClick()
        End If

    End Sub
End Class