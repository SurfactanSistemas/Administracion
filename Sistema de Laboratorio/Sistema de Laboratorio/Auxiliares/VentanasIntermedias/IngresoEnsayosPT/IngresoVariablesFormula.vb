Public Class IngresoVariablesFormula

    Private WVariables(10, 2) As String
    Private WFormula As String
    Public WValor As String

    Sub New(ByVal Formula As String, ByVal Variables(,) As String, ByVal Valor As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WVariables = Variables
        WFormula = Trim(Formula)
        WValor = Valor.Replace(",", ".")

    End Sub

    Private Sub IngresoVariablesFormula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvVariables.Rows.Clear()

        For i = 1 To 10

            dgvVariables.Rows.Add(i, WVariables(i, 1), WVariables(i, 2).Replace(",", "."))

        Next

        txtFormula.Text = WFormula

    End Sub

    Private Sub IngresoVariablesFormula_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        With dgvVariables
            .CurrentCell = .Rows(0).Cells("Valor")
            .Focus()
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        DialogResult = Windows.Forms.DialogResult.OK

        Close()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

        Close()
    End Sub
End Class