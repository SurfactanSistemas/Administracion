﻿Public Class GridBuilder
    Private dataGrid As DataGridView
    Private validatorForColumn As New Dictionary(Of Integer, DataGridValidator)
    Private decimalColumns As New List(Of Integer)
    Private columnsNotJumpables As New List(Of Integer)

    Public Sub New(ByVal grid As DataGridView)
        dataGrid = grid
        AddHandler dataGrid.CellEndEdit, AddressOf dataGridCellEndEdit
        AddHandler dataGrid.KeyDown, AddressOf dataGridEnterPressed
        AddHandler dataGrid.CellValueChanged, AddressOf cellValueChanged
        AddHandler dataGrid.RowsAdded, AddressOf cellValueChanged
    End Sub

    Public Sub addTextColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        addColumn(index, header, New DataGridValidator(ValidatorType.NotEmpty), jump)
    End Sub

    Public Sub addDateColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        addColumn(index, header, New DataGridValidator(ValidatorType.DateFormat), jump)
    End Sub

    Public Sub addStrictlyPositiveFloatColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        decimalColumns.Add(index)
        addColumn(index, header, New DataGridValidator(ValidatorType.StrictlyPositiveFloat), jump)
    End Sub

    Public Sub addPositiveFloatColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        decimalColumns.Add(index)
        addColumn(index, header, New DataGridValidator(ValidatorType.PositiveFloat), jump)
    End Sub

    Public Sub addPositiveColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        addColumn(index, header, New DataGridValidator(ValidatorType.Positive), jump)
    End Sub

    Public Sub addNumericColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        addColumn(index, header, New DataGridValidator(ValidatorType.Numeric), jump)
    End Sub

    Public Sub addFloatColumn(ByVal index As Integer, ByVal header As String, Optional ByVal jump As Boolean = True)
        decimalColumns.Add(index)
        addColumn(index, header, New DataGridValidator(ValidatorType.Float), jump)
    End Sub


    Public Sub addColumn(ByVal index As Integer, ByVal header As String, ByVal validator As DataGridValidator, ByVal jump As Boolean)
        If Not jump Then : columnsNotJumpables.add(index) : End If
        If dataGrid.Columns.Count <= index Then
            dataGrid.Columns.Add(asName(header), header)
        Else
            dataGrid.Columns(index).Name = asName(header)
            dataGrid.Columns(index).HeaderText = header
        End If
        dataGrid.Columns(index).SortMode = DataGridViewColumnSortMode.NotSortable
        Select Case validator.validatorType
            Case ValidatorType.Float, ValidatorType.PositiveFloat, ValidatorType.StrictlyPositiveFloat, ValidatorType.DateFormat, ValidatorType.Positive, ValidatorType.Numeric
                rightAlign(index)
        End Select
        validatorForColumn.Add(index, validator)
    End Sub

    Private Function validate(ByVal columnIndex As Integer, ByVal rowIndex As Integer)
        Dim validator As DataGridValidator = validatorForColumn.ElementAt(columnIndex).Value
        Return validator.validate(dataGrid(columnIndex, rowIndex).Value)
    End Function

    Private Function asName(ByVal header As String)
        Return New String(header.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

    Private Sub rightAlign(ByVal index As Integer)
        dataGrid.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Function nextNotReadOnlyFrom(ByVal iCol As Integer, ByVal iRow As Integer)
        Dim i = 1
        Do While (iCol + i < dataGrid.Columns.Count)
            If Not (dataGrid(iCol + i, iRow).ReadOnly Or dataGrid(iCol + i, iRow).Frozen) And dataGrid(iCol + i, iRow).Visible Then
                Return dataGrid(iCol + i, iRow)
            End If
            i += 1
        Loop

        Return dataGrid(0, Math.Min(iRow + 1, dataGrid.Rows.Count - 1))
    End Function

    Private Sub dataGridEnterPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim iCol = dataGrid.CurrentCell.ColumnIndex
            Dim iRow = dataGrid.CurrentCell.RowIndex
            If validate(iCol, iRow) Then
                If Not columnsNotJumpables.Contains(iCol) Then
                    If iCol = dataGrid.Columns.Count - 1 Then
                        If iRow < dataGrid.Rows.Count - 1 Then
                            dataGrid.CurrentCell = dataGrid(0, iRow + 1)
                        End If
                    Else
                        dataGrid.CurrentCell = nextNotReadOnlyFrom(iCol, iRow)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dataGridCellEndEdit(ByVal sender As Object, ByVal e As Object)
        'Dim iCol = dataGrid.CurrentCell.ColumnIndex
        'Dim iRow = dataGrid.CurrentCell.RowIndex
        'If iRow < dataGrid.Rows.Count - 1 Then
        '    SendKeys.Send("{up}")
        'End If
        'SendKeys.Send("{enter}")
    End Sub

    Private Sub cellValueChanged(ByVal sender As Object, ByVal e As Object)
        'For Each row As DataGridViewRow In sender.Rows
        '    For Each index In decimalColumns
        '        If Not IsNothing(row.Cells(index).Value) Then
        '            row.Cells(index).Value = row.Cells(index).Value.ToString.Replace(".", ",")
        '            row.Cells(index).Value = CustomConvert.toStringWithTwoDecimalPlaces(CustomConvert.toDoubleOrZero(row.Cells(index).Value))
        '        End If
        '    Next
        'Next
    End Sub
End Class
