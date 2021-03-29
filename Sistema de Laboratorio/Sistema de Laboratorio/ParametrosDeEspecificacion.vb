Imports System.Text.RegularExpressions
Imports Util

Public Class ParametrosDeEspecificacion : Implements INotificaActualizacion, ITraerFormulaOtroCodigo, IAyudaGeneral
    Dim Renglon As Integer
    Private ReadOnly Terminado As String
    Dim WID As String
    Private WDecimales As Integer = 2
    
    Dim WparametrosFormula(11) As String

    Sub New(Optional ByVal Terminado As String = "", Optional ByVal Fila As Integer = 0, Optional ByVal Permiso As Boolean = False, Optional ByVal Decimales As Integer = 2)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Renglon = Fila
        Me.Terminado = Terminado
        Me.WDecimales = Decimales

        If Permiso = False Then
            For Each c As TextBox In Me.gbVariables.Controls.OfType(Of TextBox)()
                c.ReadOnly = True
            Next
            For Each c As TextBox In Me.GroupBox2.Controls.OfType(Of TextBox)()
                c.ReadOnly = True
            Next
            btnAceptar.Enabled = False
            btnVerificar.Enabled = False
        End If
        If Renglon > 0 And Terminado.Trim <> "" Then _PoblarGrilla(Renglon)

    End Sub

    Sub _PoblarGrilla(ByVal Renglon As Integer)

        Dim SQLCnslt As String

        SQLCnslt = "SELECT * FROM FormulasDeEnsayos WHERE Renglon = '" & Renglon & "' And Terminado = '" & Terminado & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then

            txtVar1.Text = Trim(OrDefault(row.Item("Var1"), ""))
            txtVar2.Text = Trim(OrDefault(row.Item("Var2"), ""))
            txtVar3.Text = Trim(OrDefault(row.Item("Var3"), ""))
            txtVar4.Text = Trim(OrDefault(row.Item("Var4"), ""))
            txtVar5.Text = Trim(OrDefault(row.Item("Var5"), ""))
            txtVar6.Text = Trim(OrDefault(row.Item("Var6"), ""))
            txtVar7.Text = Trim(OrDefault(row.Item("Var7"), ""))
            txtVar8.Text = Trim(OrDefault(row.Item("Var8"), ""))
            txtVar9.Text = Trim(OrDefault(row.Item("Var9"), ""))
            txtVar10.Text = Trim(OrDefault(row.Item("Var10"), ""))
            txtAdic1.Text = Trim(OrDefault(row.Item("FormulaAdic1"), ""))
            txtAdic2.Text = Trim(OrDefault(row.Item("FormulaAdic2"), ""))
            txtAdic3.Text = Trim(OrDefault(row.Item("FormulaAdic3"), ""))
            txtDecAdic1.Text = Trim(OrDefault(row.Item("FormulaAdic1Dec"), "2"))
            txtDecAdic2.Text = Trim(OrDefault(row.Item("FormulaAdic2Dec"), "2"))
            txtDecAdic3.Text = Trim(OrDefault(row.Item("FormulaAdic3Dec"), "2"))
            WDecimales = Val(Trim(OrDefault(row.Item("Decimales"), "2")))
            WDecimales = Val(Trim(OrDefault(row.Item("Unidad"), "")))

            txtDescripcion.Text = Trim(OrDefault(row.Item("Descripcion"), ""))
            If Renglon = 0 And txtDescripcion.Text <> "" Then txtDescripcion.Text = "<--" & txtDescripcion.Text & "-->"
            txtFormula.Text = Trim(IIf(IsDBNull(row.Item("Formula")), "", row.Item("Formula")))

        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        txtFormula.Text = txtFormula.Text.Replace("=", "")

        Dim Mofidicado As Boolean = False

        For i = 1 To 10
            WparametrosFormula(i) = gbVariables.Controls("txtVar" & i).Text.Trim
        Next

        Dim SQLCnslt As String

        SQLCnslt = "SELECT Descripcion, Formula, Var1, Var2, Var3, Var4, Var5, Var6, Var7, Var8, Var9, Var10, AnalistaLab, EstadoVerificado FROM FormulasDeEnsayos WHERE Renglon = '" & Renglon & "' and Terminado  = '" & Terminado & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then
            If OrDefault(row.Item("EstadoVerificado"), False) = True Then
                For i = 1 To 10

                    If WparametrosFormula(i) <> Trim(OrDefault(row.Item("Var" & i), "")) Then
                        Mofidicado = True
                    End If
                Next
                If txtFormula.Text <> Trim(OrDefault(row.Item("Formula"), "")) Then
                    Mofidicado = True
                End If
                If txtDescripcion.Text <> Trim(OrDefault(row.Item("Descripcion"), "")) Then
                    Mofidicado = True
                End If
            End If
        End If


        If Mofidicado = True Then
            If MsgBox("Se modificaron campos, y esta formula se encuentra verificada." & vbCrLf & "Si procede debera verificar los nuevamente.", vbYesNo) = vbNo Then

                Exit Sub
            Else

                Dim WOwner As IGrabadoDeFormula = TryCast(Owner, IGrabadoDeFormula)

                If WOwner IsNot Nothing Then
                    WOwner._GrabarFormulaMod(txtFormula.Text, WparametrosFormula, txtDescripcion.Text, Renglon, Mofidicado, txtAdic1.Text, txtAdic2.Text, txtAdic3.Text, txtDecAdic1.Text, txtDecAdic2.Text, txtDecAdic3.Text)
                    Close()
                End If

            End If
        End If

        Dim WOwner2 As IGrabadoDeFormula = TryCast(Owner, IGrabadoDeFormula)

        If WOwner2 IsNot Nothing Then

            WOwner2._GrabarFormulaMod(txtFormula.Text, WparametrosFormula, txtDescripcion.Text, Renglon, False, txtAdic1.Text, txtAdic2.Text, txtAdic3.Text, txtDecAdic1.Text, txtDecAdic2.Text, txtDecAdic3.Text)

            Close()
        End If

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

                txtAdic1.Focus()

            Case Keys.Escape

                txtAdic1.Text = ""

        End Select
    End Sub

    Private Sub txtAdic1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdic1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtAdic2.Focus()

            Case Keys.Escape

                txtAdic1.Text = ""

        End Select
    End Sub

    Private Sub txtAdic2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdic2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtAdic3.Focus()

            Case Keys.Escape

                txtAdic2.Text = ""

        End Select
    End Sub

    Private Sub txtAdic3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdic3.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txtFormula.Focus()

            Case Keys.Escape

                txtAdic3.Text = ""

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


    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click

        Dim SQLCnslt As String

        If Renglon = 0 Then
            MsgBox("Para poder Verificar la formula primero debe guardarla")
            Exit Sub
        End If

        SQLCnslt = "SELECT * FROM FormulasDeEnsayos WHERE Renglon = '" & Renglon & "' And Terminado = '" & Terminado & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then

            Dim Wvariables(11, 2) As String
            Dim WReferencias(11, 2) As String
            Dim WFormula As String = Trim(txtFormula.Text)
            Dim Wvalor As String = ""
            WDecimales = OrDefault(row("Decimales"), 2)
            Dim WUnidad As String = OrDefault(row("Unidad"), "")
            Dim WRenglon As Short = 0

            For i = 1 To 10

                WRenglon += 1

                Wvariables(WRenglon, 1) = Trim(OrDefault(gbVariables.Controls.Item("txtVar" & WRenglon).Text, ""))

            Next

            Dim regex As New Regex("R[0-9]{1,2}")

            Dim mts As MatchCollection = regex.Matches(WFormula)

            WRenglon = 0

            For Each mt As Match In mts
                WRenglon += 1
                WReferencias(WRenglon, 1) = mt.Value
            Next

            Dim WAdicionales(2, 1) As String

            WAdicionales(0, 0) = txtAdic1.Text.Trim
            WAdicionales(1, 0) = txtAdic2.Text.Trim
            WAdicionales(2, 0) = txtAdic3.Text.Trim

            WAdicionales(0, 1) = txtDecAdic1.Text.Trim
            WAdicionales(1, 1) = txtDecAdic2.Text.Trim
            WAdicionales(2, 1) = txtDecAdic3.Text.Trim

            With New IngresoVariablesFormula(WFormula, Wvariables, Wvalor, Nothing, WDecimales, Renglon, WReferencias, False, Terminado, WAdicionales, Unidad:=WUnidad)
                .Show(Me)
            End With
        End If

    End Sub

    Private Sub txtFormula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFormula.KeyPress, txtAdic1.KeyPress, txtAdic2.KeyPress, txtAdic3.KeyPress, txtDecAdic1.KeyPress, txtDecAdic2.KeyPress, txtDecAdic3.KeyPress
        e.Handled = Not {"v", "V", "r", "R", "F", "A", "/", "(", ")", "[", "]", "^", "+", "-", "*"}.ToList().Any(Function(v) CChar(v) = e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not Chr(Keys.Back) = e.KeyChar And Not Chr(Keys.Delete) = e.KeyChar
    End Sub

    Public Sub _ProcesarNotificaActualizacion() Implements INotificaActualizacion._ProcesarNotificaActualizacion
        Dim WOwner As INotificaActualizacion = TryCast(Owner, INotificaActualizacion)

        If WOwner IsNot Nothing Then WOwner._ProcesarNotificaActualizacion()

        Close()
    End Sub

    Private Sub btnTraer_Click(sender As Object, e As EventArgs) Handles btnTraer.Click

        Dim tabla As DataTable = Nothing

        If Terminado.Replace(" ", "").Length = 12 Then
            tabla = GetAll("SELECT distinct f.Terminado As Codigo, t.Descripcion FROM SurfactanSa.dbo.Terminado t INNER JOIN Surfactan_II.dbo.FormulasDeEnsayos f ON f.Terminado = t.Codigo ORDER BY f.Terminado, t.Descripcion")
        Else
            tabla = GetAll("SELECT distinct f.Terminado As Codigo, a.Descripcion FROM SurfactanSa.dbo.Articulo a INNER JOIN Surfactan_II.dbo.FormulasDeEnsayos f ON f.Terminado = a.Codigo ORDER BY f.Terminado, a.Descripcion")
        End If

        With New Util.AyudaGeneral(tabla, "SELECCIONE EL CODIGO DEL PRODUCTO")
            .ShowDialog(Me)
        End With

    End Sub

    Public Sub _ProcesarTraerFormulaOtroCodigo(ByVal _di As String, ByVal WRenglon As Object, ByVal Termi As String) Implements ITraerFormulaOtroCodigo._ProcesarTraerFormulaOtroCodigo
        WID = _di
        Dim SQLCnslt As String

        SQLCnslt = "SELECT * FROM FormulasDeEnsayos WHERE Renglon = '" & WRenglon & "' And Terminado = '" & Termi & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then

            txtVar1.Text = Trim(OrDefault(row.Item("Var1"), ""))
            txtVar2.Text = Trim(OrDefault(row.Item("Var2"), ""))
            txtVar3.Text = Trim(OrDefault(row.Item("Var3"), ""))
            txtVar4.Text = Trim(OrDefault(row.Item("Var4"), ""))
            txtVar5.Text = Trim(OrDefault(row.Item("Var5"), ""))
            txtVar6.Text = Trim(OrDefault(row.Item("Var6"), ""))
            txtVar7.Text = Trim(OrDefault(row.Item("Var7"), ""))
            txtVar8.Text = Trim(OrDefault(row.Item("Var8"), ""))
            txtVar9.Text = Trim(OrDefault(row.Item("Var9"), ""))
            txtVar10.Text = Trim(OrDefault(row.Item("Var10"), ""))
            txtAdic1.Text = Trim(OrDefault(row.Item("FormulaAdic1"), ""))
            txtAdic2.Text = Trim(OrDefault(row.Item("FormulaAdic2"), ""))
            txtAdic3.Text = Trim(OrDefault(row.Item("FormulaAdic3"), ""))
            txtDecAdic1.Text = Trim(OrDefault(row.Item("FormulaAdic1dec"), "2"))
            txtDecAdic2.Text = Trim(OrDefault(row.Item("FormulaAdic2dec"), "2"))
            txtDecAdic3.Text = Trim(OrDefault(row.Item("FormulaAdic3dec"), "2"))
            WDecimales = Val(OrDefault(row.Item("Decimales"), "2"))

            txtDescripcion.Text = Trim(OrDefault(row.Item("Descripcion"), ""))
            If Renglon = 0 And txtDescripcion.Text <> "" Then txtDescripcion.Text = "<--" & txtDescripcion.Text & "-->"
            txtFormula.Text = Trim(IIf(IsDBNull(row.Item("Formula")), "", row.Item("Formula")))

        End If

        txtVar1.Focus()

    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        Dim WTerminado As String = OrDefault(row.Cells("Codigo").Value, "")

        With New IngresoFormulasEnsayo(WID, WTerminado)
            .Show(Me)
            '.btnAgregar.PerformClick()
        End With

    End Sub

    Private Sub txtDecAdic1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDecAdic1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAdic2.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtDecAdic1.Text = ""
        End If
    End Sub

    Private Sub txtDecAdic2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDecAdic2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAdic3.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtDecAdic2.Text = ""
        End If
    End Sub

End Class