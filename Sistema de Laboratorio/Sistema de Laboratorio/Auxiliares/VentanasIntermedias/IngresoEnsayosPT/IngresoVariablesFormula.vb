Imports System.Text.RegularExpressions
Imports info.lundin.math

Public Class IngresoVariablesFormula

    Public Property Formula As String
    Public Property Variables As String(,)
    Public Property Valor As String
    Public Property Decimales As String

    Private DGV As DataGridView



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
                                btnAceptar_Click(Nothing, Nothing)

                            Else
                                If Trim(.Rows(iRow + 1).Cells("Variable").Value) <> "" Then
                                    .CurrentCell = .Rows(iRow + 1).Cells("WValor")
                                Else
                                    btnAceptar_Click(Nothing, Nothing)
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









    Sub New(ByVal Formula As String, ByVal Variables(,) As String, ByVal Valor As String, ByVal Grilla As DataGridView, Optional ByVal Decimales As Object = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Variables = Variables
        Me.Decimales = OrDefault(Decimales, 2)
        Me.Formula = Trim(Formula)
        Me.Valor = Valor.Replace(",", ".")
        DGV = Grilla

        txtDecimales.Text = Me.Decimales
        txtDecimales.Text = IIf(Valor.Trim = "", "2", "0")

        Dim aux As Integer = Valor.IndexOfAny({",", "."})

        If aux > 0 Then
            Dim t As String = _Right(Valor, Valor.Replace(".", "").Replace(",", "").Length - aux)
            txtDecimales.Text = t.Length
        End If

    End Sub

    Private Sub IngresoVariablesFormula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvVariables.Rows.Clear()
        Dim wultima As Short = 1

        For i = 1 To 10
            If Variables(i, 1) <> "" Then
                dgvVariables.Rows.Add(i, Variables(i, 1), Variables(i, 2).Replace(",", "."))
                wultima += 1
            End If
        Next

        '
        ' Definimos las Referencias.
        '
        Dim regex As New Regex("R[0-9]{1,2}")

        For Each m As Match In regex.Matches(Formula)

            Dim renglon As Integer = Val(m.Value.ToString.Replace("R", ""))

            If renglon <= DGV.Rows.Count And wultima <= 10 Then
                Dim x = dgvVariables.Rows.Add(wultima, m.Value, OrDefault(DGV.Rows(renglon - 1).Cells("Valor").Value, "0").ToString.Replace(",", "."))
                dgvVariables.Rows(x).Cells("WValor").ReadOnly = True
                wultima += 1
            End If

        Next

        For i = wultima To 10
            dgvVariables.Rows.Add(i, "", "")
        Next

        txtFormula.Text = Formula

        With dgvVariables
            .CurrentCell = .Rows(0).Cells("WValor")
            '.Focus()
        End With

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
        With dgvVariables
            For i = 1 To 10

                If .Rows(i - 1).Cells("WValor").Value.ToString.StartsWith(".") Then .Rows(i - 1).Cells("WValor").Value = "0" & .Rows(i - 1).Cells("WValor").Value

                Variables(i, 1) = OrDefault(.Rows(i - 1).Cells("Variable").Value, "")
                Variables(i, 2) = OrDefault(.Rows(i - 1).Cells("WValor").Value, "0").ToString.Replace(",", ".")

            Next
        End With

        '
        ' Calculamos el valor segun formula.
        '
        Dim parser As New ExpressionParser()

        With parser.Values
            For i = 1 To 10
                If Variables(i, 1).Trim <> "" Then
                    .Add("v" & i, Variables(i, 2))
                End If
            Next
        End With

        Dim regex As New Regex("R[0-9]{1,2}")

        For Each row As DataGridViewRow In dgvVariables.Rows
            If regex.IsMatch(OrDefault(row.Cells("Variable").Value, "")) Then parser.Values.Add(LCase(row.Cells("Variable").Value.ToString), OrDefault(row.Cells("WValor").Value, "0").ToString.Replace(",", "."))
        Next

        Valor = formatonumerico(parser.Parse(Formula), Val(txtDecimales.Text))

        If Val(txtDecimales.Text) = 0 Then Valor = CInt(Valor.Replace(".", ","))

        Decimales = Val(txtDecimales.Text)

        'MsgBox(Valor)

        Close()

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

End Class