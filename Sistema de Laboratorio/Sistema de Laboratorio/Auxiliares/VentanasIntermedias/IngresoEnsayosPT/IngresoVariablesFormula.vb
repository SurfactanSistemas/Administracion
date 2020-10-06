Imports System.Text.RegularExpressions
Imports Util
Imports info.lundin.math

Public Class IngresoVariablesFormula : Implements IIngresoClaveSeguridad

    Public Property Formula As String
    Public Property Variables As String(,)
    Public Property Referencias As String(,)
    Public Property Valor As String
    Public Property Decimales As String

    Private DGV As DataGridView

    Private RenglonID As Integer



    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        With dgvVariables
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Select Case iCol
                        Case 2
                            If iRow = .Rows.Count - 1 Then

                                ' .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                                If txtValorEstandar.Visible = True Then
                                    txtValorEstandar.Focus()
                                Else
                                    btnAceptar_Click(Nothing, Nothing)
                                End If


                            Else
                                If Trim(.Rows(iRow + 1).Cells("Variable").Value) <> "" Then
                                    .CurrentCell = .Rows(iRow + 1).Cells("WValor")
                                Else
                                    If txtValorEstandar.Visible = True Then
                                        txtValorEstandar.Focus()
                                    Else
                                        btnAceptar_Click(Nothing, Nothing)
                                    End If
                                End If

                            End If


                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .CurrentCell = .Rows(iRow).Cells("WValor")
                    .CurrentCell.Value = ""

                    'Muevo de linea para que tome el cambio
                    If iRow = .Rows.Count - 1 Then
                        iRow -= 1
                        .CurrentCell = .Rows(iRow).Cells("WValor")
                        iRow += 1
                        .CurrentCell = .Rows(iRow).Cells("WValor")
                    Else
                        iRow += 1
                        .CurrentCell = .Rows(iRow).Cells("WValor")
                        iRow -= 1
                        .CurrentCell = .Rows(iRow).Cells("WValor")
                    End If

                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorEstandar.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub




    Sub New(ByVal Formula As String, ByVal Variables(,) As String, ByVal Valor As String, Optional ByVal Grilla As DataGridView = Nothing, Optional ByVal Decimales As Object = Nothing, Optional ByVal Renglon As Integer = -1, Optional ByVal Referencias(,) As String = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Variables = Variables
        Me.Referencias = Referencias
        Me.Decimales = OrDefault(Decimales, 2)
        Me.Formula = Trim(Formula)
        Me.Valor = Valor.Replace(",", ".")

        DGV = Grilla

        txtDecimales.Text = Me.Decimales
        txtDecimales.Text = IIf(Valor.Trim = "", "2", "0")

        Dim aux As Integer = Valor.IndexOfAny({",", "."})

        RenglonID = Renglon

        If aux > 0 Then
            Dim t As String = _Right(Valor, Valor.Replace(".", "").Replace(",", "").Length - aux)
            txtDecimales.Text = t.Length
        End If

    End Sub

    Private Sub IngresoVariablesFormula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvVariables.Rows.Clear()
        
        Dim Wowner = TryCast(Owner, ParametrosDeEspecificacion)


        If Wowner IsNot Nothing Then

            txtValorEstandar.Visible = True
            lblValorEstandar.Visible = True

            Dim SQLCnslt As String
            SQLCnslt = "SELECT * FROM FormulasVerificadasValores WHERE IDRenglon = '" & RenglonID & "' ORDER BY Fila ASC"
            Dim Dtabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")

            If Dtabla.Rows.Count > 0 Then
                For Each row As DataRow In Dtabla.Rows
                    With row

                        dgvVariables.Rows.Add(.Item("fila"), Trim(.Item("Variable")), Trim(.Item("Valor")), .Item("IDRenglon"))

                        txtValorEstandar.Text = (.Item("ResultadoVerificado")).ToString().Replace(",", ".")

                    End With
                Next
            Else
                _CargarDatosFormulaDefault()
            End If
        Else
            _CargarDatosFormulaDefault()
        End If

        txtFormula.Text = Formula

        With dgvVariables
            .CurrentCell = .Rows(0).Cells("WValor")
            '.Focus()
        End With

    End Sub

    Private Sub _CargarDatosFormulaDefault()
        Dim wultima As Short = 1

        For i = 1 To 10
            Variables(i, 1) = Trim(Variables(i, 1))
            Variables(i, 2) = Trim(OrDefault(Variables(i, 2), ""))

            Referencias(i, 1) = Trim(Referencias(i, 1))
            Referencias(i, 2) = Trim(OrDefault(Referencias(i, 2), ""))
        Next

        For i = 1 To 10
            If Variables(i, 1) <> "" Then
                dgvVariables.Rows.Add(i, Variables(i, 1), Variables(i, 2).Replace(",", "."))
                wultima += 1
            End If
        Next

        For i = 1 To 10
            If Referencias(i, 1) <> "" Then
                dgvVariables.Rows.Add(wultima, Referencias(i, 1), Referencias(i, 2).Replace(",", "."))
                wultima += 1
            End If
        Next

        '
        ' Definimos las Referencias.
        '
        Dim regex As New Regex("R[0-9]{1,2}")

        For Each m As Match In regex.Matches(Formula)

            Dim renglon As Integer = Val(m.Value.ToString.Replace("R", ""))

            If DGV IsNot Nothing AndAlso renglon <= DGV.Rows.Count And wultima <= 10 Then
                Dim x = dgvVariables.Rows.Add(wultima, m.Value, OrDefault(DGV.Rows(renglon - 1).Cells("Valor").Value, "0").ToString.Replace(",", "."))
                dgvVariables.Rows(x).Cells("WValor").ReadOnly = True
                wultima += 1
            End If
            
        Next

        For i = wultima To 10
            dgvVariables.Rows.Add(i, "", "")
        Next

    End Sub

    Private Sub IngresoVariablesFormula_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        With dgvVariables
            .CurrentCell = .Rows(0).Cells("WValor")
            '.Focus()
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        DialogResult = Windows.Forms.DialogResult.OK

        '
        ' Reasignamos los valores de las variables.
        '


        Dim regex As New Regex("R[0-9]{1,2}")

        With dgvVariables
            For i = 1 To dgvVariables.Rows.Count

                If .Rows(i - 1).Cells("WValor").Value.ToString.StartsWith(".") Then .Rows(i - 1).Cells("WValor").Value = "0" & .Rows(i - 1).Cells("WValor").Value

                If Not .Rows(i - 1).Cells("Variable").Value.ToString.StartsWith("R") Then

                    Variables(i, 0) = OrDefault(.Rows(i - 1).Cells("idVariable").Value, "")
                    Variables(i, 1) = OrDefault(.Rows(i - 1).Cells("Variable").Value, "")
                    Variables(i, 2) = OrDefault(.Rows(i - 1).Cells("WValor").Value, "0").ToString.Replace(",", ".")

                    If Val(Variables(i, 2)) = 0 Then Variables(i, 2) = "0"

                End If
                
            Next

            For i = 1 To dgvVariables.Rows.Count

                If .Rows(i - 1).Cells("WValor").Value.ToString.StartsWith(".") Then .Rows(i - 1).Cells("WValor").Value = "0" & .Rows(i - 1).Cells("WValor").Value

                If .Rows(i - 1).Cells("Variable").Value.ToString.StartsWith("R") Then

                    Referencias(i, 0) = OrDefault(.Rows(i - 1).Cells("idVariable").Value, "")
                    Referencias(i, 1) = OrDefault(.Rows(i - 1).Cells("Variable").Value, "")
                    Referencias(i, 2) = OrDefault(.Rows(i - 1).Cells("WValor").Value, "0").ToString.Replace(",", ".")

                    If Val(Referencias(i, 2)) = 0 Then Referencias(i, 2) = "0"

                End If

            Next

        End With

        '
        ' Calculamos el valor segun formula.
        '
        Dim parser As New ExpressionParser()

        With parser.Values
            For i = 1 To 10
                If Variables(i, 1).Trim <> "" And Formula.ToLower.Contains("v" & Variables(i, 0)) Then
                    .Add("v" & i, Variables(i, 2))
                End If
            Next
        End With

        With parser.Values
            For i = 1 To 10
                If Referencias(i, 1).Trim <> "" And Referencias(i, 2).Trim <> "" And Formula.ToUpper.Contains(Referencias(i, 1)) Then
                    If Val(Referencias(i, 2)) = 0 Then Referencias(i, 2) = "0"
                    .Add(Referencias(i, 1).ToLower, Referencias(i, 2))
                End If
            Next
        End With

        'Dim regex As New Regex("R[0-9]{1,2}")

        'For Each row As DataGridViewRow In dgvVariables.Rows
        '    If regex.IsMatch(OrDefault(row.Cells("Variable").Value, "")) Then parser.Values.Add(LCase(row.Cells("Variable").Value.ToString), OrDefault(row.Cells("WValor").Value, "0").ToString.Replace(",", "."))
        'Next

        Valor = formatonumerico(parser.Parse(Formula), Val(txtDecimales.Text))

        If Not regex.IsMatch(Valor, "\d") Then
            MsgBox("El resultado del cálculo no es correcto.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Val(txtDecimales.Text) = 0 Then Valor = CInt(Valor.Replace(".", ","))

        Decimales = Val(txtDecimales.Text)


        'SI NOS LLAMO LA VENTANA DE CREAR FORMULAS 
        Dim Wowner = TryCast(Owner, ParametrosDeEspecificacion)

        'SE VERIFICA QUE CONCUERDEN LOS VALORES INGRESADOS
        If Wowner IsNot Nothing Then
            If Val(Valor) <> Val(txtValorEstandar.Text) Then
                MsgBox("El valor calculado por la formula: " & Valor & " no corresponde con" & vbCrLf &
                       "el valor ingresado en Valor Estandar : " & txtValorEstandar.Text & "" & vbCrLf &
                       "Verifique los valores ingresados o la formula")
            Else


                Dim frm As New IngresoClaveSeguridad()
                frm.ShowDialog(Me)

                Me.Close()
                Exit Sub




                '
                '
                '
                '
                '
                '
                '


            End If
        End If

        'MsgBox(Valor)

        ' Close()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDecimales.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad

        Dim WDatos As DataRow = GetSingle("SELECT GrabaV, FechaGrabaV, Operador FROM Operador WHERE Clave = '" & UCase(WClave) & "'", "SurfactanSa")

        If WDatos IsNot Nothing Then
            Dim WGrabaV As String = OrDefault(WDatos.Item("GrabaV"), "")
            If WGrabaV.ToUpper = "S" Then

                Dim SQLCnslt As String = ""

                Dim ListaSQLCnslt As New List(Of String)

                Dim Fila As Integer = 1

                SQLCnslt = "DELETE  FROM FormulasVerificadasValores WHERE IDRenglon = '" & RenglonID & "'"

                ListaSQLCnslt.Add(SQLCnslt)

                For Each RowDGV As DataGridViewRow In dgvVariables.Rows

                    SQLCnslt = "INSERT INTO FormulasVerificadasValores (IDRenglon, Formula, Variable , Valor ,AnalistaLab, ResultadoVerificado, Fila)" &
                    "VALUES('" & RenglonID & "', '" & txtFormula.Text & "', '" & RowDGV.Cells("Variable").Value &
                        "' , '" & RowDGV.Cells("WValor").Value & "' , '" & WDatos.Item("Operador") & "', '" & txtValorEstandar.Text & "','" & Fila & "')"

                    Fila += 1

                    ListaSQLCnslt.Add(SQLCnslt)
                Next

                SQLCnslt = "UPDATE FormulasDeEnsayos SET EstadoVerificado = 1, Analistalab = '" & WDatos.Item("Operador") & "' WHERE Renglon = '" & RenglonID & "'"
                ListaSQLCnslt.Add(SQLCnslt)

                ExecuteNonQueries("Surfactan_II", ListaSQLCnslt.ToArray())
                Exit Sub
            End If
        End If

        MsgBox("Clave Incorrecta")
        Dim frm As New IngresoClaveSeguridad
        frm.ShowDialog(Me)



    End Sub



End Class