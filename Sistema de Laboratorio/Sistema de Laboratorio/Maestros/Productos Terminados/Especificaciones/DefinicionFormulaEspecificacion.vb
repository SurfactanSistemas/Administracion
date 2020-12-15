Public Class DefinicionFormulaEspecificacion : Implements IGrabadoDeFormula

    Private WParametrosFormula(10) As String
    Private WFormula As String
    Private Terminado As String

    Sub New(ByVal Terminado As String, ByVal Formula As String, ByVal ParametrosFormula() As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WParametrosFormula = ParametrosFormula
        WFormula = Formula
        Me.Terminado = Terminado

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

    Private Sub btnAyudaFormula_Click(sender As Object, e As EventArgs) Handles btnAyudaFormula.Click
        With New IngresoFormulasEnsayo(Terminado)
            .Show(Me)
        End With
    End Sub


    Public Sub _GrabarFormula(Formula As String, ParametrosFormula As String(), Descripcion As String, Optional Renglon As Integer = 0) Implements IGrabadoDeFormula._GrabarFormula
        txtVar1.Text = Trim(ParametrosFormula(1))
        txtVar2.Text = Trim(ParametrosFormula(2))
        txtVar3.Text = Trim(ParametrosFormula(3))
        txtVar4.Text = Trim(ParametrosFormula(4))
        txtVar5.Text = Trim(ParametrosFormula(5))
        txtVar6.Text = Trim(ParametrosFormula(6))
        txtVar7.Text = Trim(ParametrosFormula(7))
        txtVar8.Text = Trim(ParametrosFormula(8))
        txtVar9.Text = Trim(ParametrosFormula(9))
        txtVar10.Text = Trim(ParametrosFormula(10))

        txtFormula.Text = Trim(Formula)
    End Sub

    Private Sub _GrabarFormulaMod(ByVal Formula As String, ByVal ParametrosFormula() As String, ByVal Descripcion As String, Optional ByVal Renglon As Integer = 0, Optional _
                         ByVal Modificado As Boolean = False) Implements IGrabadoDeFormula._GrabarFormulaMod

    End Sub
End Class