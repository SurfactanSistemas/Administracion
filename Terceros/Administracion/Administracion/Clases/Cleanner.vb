Public Class Cleanner

    Private Shared Function controls(ByVal form As Form) As List(Of CustomControl)
        Dim formControls As New List(Of CustomControl)
        For Each control As CustomControl In form.Controls.OfType(Of CustomControl)()
            formControls.Add(control)
        Next
        Return formControls
    End Function

    Public Shared Sub clean(ByVal form As Form)
        cleanWithoutChangeFocus(form)
        changeFocus(form)
    End Sub

    Private Shared Sub changeFocus(ByVal form As Form)
        Dim firstControl As Control
        firstControl = controls(form).Find(Function(control) control.EnterIndex = 1)
        If Not IsNothing(firstControl) Then
            firstControl.Focus()
        End If
    End Sub

    Public Shared Sub cleanWithoutChangeFocus(ByVal form As Form)
        For Each txtBox As CustomTextBox In form.Controls.OfType(Of CustomTextBox)()
            If txtBox.Cleanable Then
                If txtBox.Validator = ValidatorType.DateFormat Then
                    txtBox.Text = "  /  /    "
                Else
                    txtBox.Text = ""
                End If
            End If
        Next
        For Each cmbBox As CustomComboBox In form.Controls.OfType(Of CustomComboBox)()
            If cmbBox.Cleanable Then
                cmbBox.Text = ""
                cmbBox.SelectedIndex = -1
            End If
        Next
        For Each lstBox As CustomListBox In form.Controls.OfType(Of CustomListBox)()
            If lstBox.Cleanable Then
                lstBox.DataSource = Nothing
                lstBox.Items.Clear()
            End If
        Next
        For Each btn As CustomButton In form.Controls.OfType(Of CustomButton)()
            If btn.Cleanable Then
                btn.Visible = False
            End If
        Next
    End Sub
End Class
