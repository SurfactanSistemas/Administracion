Public Class CommonEventsHandler
    Private controls As List(Of CustomControl)
    Private isCRUDForm As Boolean = True

    Public Sub setIndexTab(ByVal form As Form)
        controls = New List(Of CustomControl)
        For Each txtBox As CustomTextBox In form.Controls.OfType(Of CustomTextBox)()
            If txtBox.EnterIndex > 0 Then
                AddHandler txtBox.KeyPress, AddressOf enterPressed
                AddHandler txtBox.KeyPress, AddressOf enterOrEscapePressedWithoutSound
                controls.Add(txtBox)
            End If
        Next
        For Each cmbBox As CustomComboBox In form.Controls.OfType(Of CustomComboBox)()
            If cmbBox.EnterIndex > 0 Then
                AddHandler cmbBox.KeyPress, AddressOf enterPressed
                controls.Add(cmbBox)
            End If
        Next
        For Each lstBox As CustomListBox In form.Controls.OfType(Of CustomListBox)()
            If lstBox.EnterIndex > 0 Then
                AddHandler lstBox.KeyPress, AddressOf enterPressed
                controls.Add(lstBox)
            End If
        Next
        For Each btn As CustomButton In form.Controls.OfType(Of CustomButton)()
            If btn.EnterIndex > 0 Then
                AddHandler btn.KeyPress, AddressOf enterPressed
                controls.Add(btn)
            End If
        Next

        For Each validableControl As CustomTextBox In form.Controls.OfType(Of CustomTextBox)() 'Ver si agregar los combo
            addValidableControlFormatTo(validableControl)
        Next

        form.Show()
        If Not IsNothing(firstControl) Then
            firstControl.Focus()
        End If
    End Sub

    Public Sub setIndexTabNotCRUDForm(ByVal form As Form)
        isCRUDForm = False
        setIndexTab(form)
    End Sub

    Public Sub addValidableControlFormatTo(ByVal validableControl As ValidableControl)
        Dim control = DirectCast(validableControl, Control)
        Select Case validableControl.Validator
            Case ValidatorType.Numeric, ValidatorType.Positive, ValidatorType.PositiveWithMax
                AddHandler control.KeyPress, AddressOf numericKeyPressed
                setRightAlign(control)
            Case ValidatorType.PositiveFloat, ValidatorType.StrictlyPositiveFloat
                AddHandler control.KeyPress, AddressOf numericKeyOrDecimalSeparatorPressed
                setRightAlign(control)
            Case ValidatorType.Float
                AddHandler control.KeyPress, AddressOf numericKeyOrDecimalSeparatorOrMinusPressed
                setRightAlign(control)
            Case ValidatorType.DateFormat
                AddHandler control.KeyDown, AddressOf deleteOrBackSpaceDownForDateFormat
                AddHandler control.KeyPress, AddressOf dateKeyPressed
                control.Text = "  /  /    "
                setRightAlign(control)
        End Select
    End Sub

    Private Sub setRightAlign(ByVal control As Control)
        Try
            DirectCast(control, CustomTextBox).TextAlign = HorizontalAlignment.Right
        Catch ex As Exception

        End Try
    End Sub

    Private Sub numericKeyPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub numericKeyOrDecimalSeparatorPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim customText = DirectCast(sender, CustomTextBox)
        If e.KeyChar = "." Or e.KeyChar = "," Then
            If Not customText.Text.Contains(",") Then
                Dim selectionStart As Integer = customText.SelectionStart
                If selectionStart = 0 Then
                    customText.Text = customText.Text.Insert(selectionStart, "0")
                    selectionStart = selectionStart + 1
                End If
                customText.Text = customText.Text.Insert(selectionStart, ",")
                customText.Select(selectionStart + 1, 0)
            End If
            e.Handled = True
        End If
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub numericKeyOrDecimalSeparatorOrMinusPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim customText = DirectCast(sender, CustomTextBox)
        If e.KeyChar = "-" And customText.SelectionStart = 0 Then
            If Not customText.Text.Contains("-") Then
                customText.Text = customText.Text.Insert(0, "-")
                customText.Select(1, 0)
            End If
            e.Handled = True
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            If Not customText.Text.Contains(",") Then
                Dim selectionStart As Integer = customText.SelectionStart
                If selectionStart = 0 Or (selectionStart = 1 And customText.Text.Contains("-")) Then
                    customText.Text = customText.Text.Insert(selectionStart, "0")
                    selectionStart = selectionStart + 1
                End If
                customText.Text = customText.Text.Insert(selectionStart, ",")
                customText.Select(selectionStart + 1, 0)
            End If
            e.Handled = True
        End If
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub deleteOrBackSpaceDownForDateFormat(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim customControl = DirectCast(sender, CustomTextBox)
        If e.KeyValue = Keys.Delete Then
            deleteCharOf(customControl, customControl.SelectionStart, 1)
            e.SuppressKeyPress = True
        End If
        If e.KeyValue = Keys.Back Then
            deleteCharOf(customControl, customControl.SelectionStart - 1, 0)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub deleteCharOf(ByVal textBox As CustomTextBox, ByVal selectionStart As Integer, ByVal selectionNextPosition As Integer)
        Select Case selectionStart
            Case 0, 1, 3, 4, 6 To 9
                textBox.Text = textBox.Text.Remove(selectionStart, 1).Insert(selectionStart, " ")
                Dim nextSelection As Integer = Math.Max(selectionStart + selectionNextPosition, selectionNextPosition)
                If nextSelection = 10 Then
                    textBox.Select(0, 0)
                Else
                    textBox.Select(nextSelection, 0)
                End If
            Case 2, 5 'No se borra nada, porque es un slash
                textBox.Select(Math.Max(selectionStart + selectionNextPosition, 1), 0)
        End Select
    End Sub

    Private Sub dateKeyPressed(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim customControl = DirectCast(sender, CustomTextBox)
        Dim firstSpaceIndex As Integer = customControl.Text.IndexOf(" ")
        Select Case firstSpaceIndex
            Case -1
                If IsNumeric(e.KeyChar) Then
                    Dim selectionStart As Integer = customControl.SelectionStart
                    If customControl.SelectionLength = customControl.Text.Length Then
                        customControl.Text = "  /  /    "
                        customControl.Select(selectionStart, 0)
                        dateKeyPressed(sender, e)
                    End If
                End If
            Case 0, 1, 3, 4, 6 To 9 'Es una entrada de fecha
                If IsNumeric(e.KeyChar) Then
                    customControl.Text = customControl.Text.Remove(firstSpaceIndex, 1).Insert(firstSpaceIndex, e.KeyChar)
                    customControl.Select(Math.Max(customControl.Text.IndexOf(" "), 0), 0)
                End If
        End Select
        e.Handled = True
    End Sub

    Private Sub enterPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            If (sender.Validator = ValidatorType.Float Or sender.Validator = ValidatorType.PositiveFloat) And sender.Text = "" Then
                sender.Text = "0"
            End If
            If sender.Validator = ValidatorType.Float Or sender.Validator = ValidatorType.PositiveFloat Or sender.Validator = ValidatorType.StrictlyPositiveFloat Then
                sender.Text = CustomConvert.toStringWithTwoDecimalPlaces(CustomConvert.toDoubleOrZero(sender.Text))
            End If
            If sender.Validator = ValidatorType.DateFormat Then
                sender.Text = CustomConvert.asTextDate(sender.Text)
                If Not sender.Empty And sender.text = "  /  /    " Then : Exit Sub : End If
            End If
            Dim nextControl As Control = findNextControl(sender)
            setFocus(nextControl)
        End If
    End Sub

    Private Function findNextControl(ByVal sender As CustomControl)
        Return controls.Find(Function(control) control.EnterIndex = sender.EnterIndex + 1)
    End Function

    Private Sub setFocus(ByVal nextControl As Control)
        If IsNothing(nextControl) Then
            If isCRUDForm Then
                secondControl().Focus()
            Else
                firstControl.Focus()
            End If
        Else
            If Not nextControl.Focus() Then
                setFocus(findNextControl(nextControl))
            End If
        End If
    End Sub

    Private Function secondControl() As Control
        Dim sndControl As Control
        sndControl = controls.Find(Function(control) control.EnterIndex = 2)
        Return sndControl
    End Function

    Private Function firstControl() As Control
        Dim fstControl As Control
        fstControl = controls.Find(Function(control) control.EnterIndex = 1)
        Return fstControl
    End Function

    Private Sub enterOrEscapePressedWithoutSound(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = Keys.Escape Then
            Dim defaultEmptyText = ""
            If DirectCast(sender, CustomTextBox).Validator = ValidatorType.DateFormat Then
                defaultEmptyText = "  /  /    "
            End If
            DirectCast(sender, CustomTextBox).Text = defaultEmptyText
            e.Handled = True
        End If
    End Sub
End Class
