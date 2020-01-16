Public Class ParametrosDeEspecificacion

    Dim Renglon As Integer

    Dim WparametrosFormula(11) As String

    Sub New(Optional ByVal Fila As Integer = 0)


        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Renglon = Fila

        If renglon > 0 Then _PoblarGrilla(renglon)


    End Sub


    Sub _PoblarGrilla(ByVal Renglon As Integer)

        Dim SQLCnslt As String

        SQLCnslt = "SELECT * FROM FormulasDeEnsayos WHERE Renglon = '" & Renglon & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then

            txtVar1.Text = Trim(IIf(IsDBNull(row.Item("Var1")), "", row.Item("Var1")))
            txtVar2.Text = Trim(IIf(IsDBNull(row.Item("Var2")), "", row.Item("Var2")))
            txtVar3.Text = Trim(IIf(IsDBNull(row.Item("Var3")), "", row.Item("Var3")))
            txtVar4.Text = Trim(IIf(IsDBNull(row.Item("Var4")), "", row.Item("Var4")))
            txtVar5.Text = Trim(IIf(IsDBNull(row.Item("Var5")), "", row.Item("Var5")))
            txtVar6.Text = Trim(IIf(IsDBNull(row.Item("Var6")), "", row.Item("Var6")))
            txtVar7.Text = Trim(IIf(IsDBNull(row.Item("Var7")), "", row.Item("Var7")))
            txtVar8.Text = Trim(IIf(IsDBNull(row.Item("Var8")), "", row.Item("Var8")))
            txtVar9.Text = Trim(IIf(IsDBNull(row.Item("Var9")), "", row.Item("Var9")))
            txtVar10.Text = Trim(IIf(IsDBNull(row.Item("Var10")), "", row.Item("Var10")))

            txtDescripcion.Text = Trim(IIf(IsDBNull(row.Item("Descripcion")), "", row.Item("Descripcion")))
            txtFormula.Text = Trim(IIf(IsDBNull(row.Item("Formula")), "", row.Item("Formula")))

        End If


    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        For i = 1 To 10
            WParametrosFormula(i) = gbVariables.Controls("txtVar" & i).Text.Trim
        Next

        Dim WOwner2 As IGrabadoDeFormula = TryCast(Owner, IGrabadoDeFormula)

        If WOwner2 IsNot Nothing Then
            WOwner2._GrabarFormula(txtFormula.Text, WparametrosFormula, txtDescripcion.Text, Renglon)
            Close()
        End If

    End Sub

    Private Sub ParametrosDeEspecificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtVar1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar2.Focus()

            Case Keys.Escape

                txtVar1.Text = ""

        End Select
    End Sub
    Private Sub txtVar2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar3.Focus()

            Case Keys.Escape

                txtVar2.Text = ""

        End Select
    End Sub

    Private Sub txtVar3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar4.Focus()

            Case Keys.Escape

                txtVar3.Text = ""

        End Select
    End Sub

    Private Sub txtVar4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar4.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar5.Focus()

            Case Keys.Escape

                txtVar4.Text = ""

        End Select
    End Sub

    Private Sub txtVar5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar5.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar6.Focus()

            Case Keys.Escape

                txtVar5.Text = ""

        End Select
    End Sub

    Private Sub txtVar6_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar6.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar7.Focus()

            Case Keys.Escape

                txtVar6.Text = ""

        End Select
    End Sub

    Private Sub txtVar7_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar7.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar8.Focus()

            Case Keys.Escape

                txtVar7.Text = ""

        End Select
    End Sub

    Private Sub txtVar8_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar8.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar9.Focus()

            Case Keys.Escape

                txtVar8.Text = ""

        End Select
    End Sub

    Private Sub txtVar9_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar9.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtVar10.Focus()

            Case Keys.Escape

                txtVar9.Text = ""

        End Select
    End Sub

    Private Sub txtVar10_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVar10.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtFormula.Focus()

            Case Keys.Escape

                txtVar10.Text = ""

        End Select
    End Sub

    Private Sub txtFormula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFormula.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtDescripcion.Focus()

            Case Keys.Escape

                txtFormula.Text = ""

        End Select
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Escape

                txtDescripcion.Text = ""

        End Select
    End Sub

    Private Sub ParametrosDeEspecificacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtVar1.Focus()
    End Sub
End Class