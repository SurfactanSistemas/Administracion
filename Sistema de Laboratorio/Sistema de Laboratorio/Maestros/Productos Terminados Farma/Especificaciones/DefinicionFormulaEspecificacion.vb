Public Class DefinicionFormulaEspecificacion

    Private WParametrosFormula(10) As String
    Private WFormula As String

    Sub New(ByVal Formula As String, ByVal ParametrosFormula() As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WParametrosFormula = ParametrosFormula
        WFormula = Formula

    End Sub

    Private Sub DefinicionFormulaEspecificacion_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        For i = 1 To WParametrosFormula.Count - 1

            CType(gbVariables.Controls("txtVar" & i), TextBox).Text = Trim(WParametrosFormula(i))
            AddHandler CType(gbVariables.Controls("txtVar" & i), TextBox).KeyDown, AddressOf txtVar1_KeyDown

        Next

        With txtFormula
            .Text = WFormula.Trim
            .Focus()
        End With
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Seguro de querar salir? " & vbCrLf & vbCrLf & "Se perderá cualquier información no grabada.", vbYesNo) <> MsgBoxResult.Yes Then Exit Sub
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        For i = 1 To 10
            WParametrosFormula(i) = gbVariables.Controls("txtVar" & i).Text.Trim
        Next

        Dim WOwner As IDefinicionFormulaEspecificacion = TryCast(Owner, IDefinicionFormulaEspecificacion)

        If WOwner IsNot Nothing Then WOwner._ProcesarDefinicionFormulaEspecificacion(txtFormula.Text.Trim, WParametrosFormula)

        Close()

    End Sub

    Private Sub txtFormula_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtFormula.KeyPress

        For Each s As String In {"/", "[", "]", "(", ")", ".", "*", "+", "-", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ChrW(Keys.Back), ChrW(Keys.Enter), ChrW(Keys.Delete), "R", "V", "r", "v"}
            If CChar(s) = e.KeyChar Then
                e.Handled = False
                Exit Sub
            End If
        Next

        e.Handled = True

    End Sub

    Private Sub DefinicionFormulaEspecificacion_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtVar1.Focus()
    End Sub

    Private Sub txtVar1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtVar1.KeyDown

        If e.KeyData = Keys.Enter Then

            Dim WControl As TextBox = TryCast(sender, TextBox)

            If WControl Is Nothing Then Exit Sub

            Dim wID As Short = Val(WControl.Name.Replace("txtVar", ""))

            If wID < 10 Then
                gbVariables.Controls.Item("txtVar" & (wID + 1)).Focus()
            Else
                txtFormula.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            TryCast(sender, TextBox).Text = ""
        End If

    End Sub
End Class