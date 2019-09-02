Public Class Cleanner
    Private Shared controls As New List(Of CustomControl)

    Public Shared Sub clean(ByVal form As Form)
        For Each txtBox As CustomTextBox In form.Controls.OfType(Of CustomTextBox)()
            If txtBox.Cleanable Then
                If txtBox.Validator = ValidatorType.DateFormat Then
                    txtBox.Text = "  /  /    "
                Else
                    txtBox.Text = ""
                End If
            End If
            controls.Add(txtBox)
        Next
        For Each cmbBox As CustomComboBox In form.Controls.OfType(Of CustomComboBox)()
            If cmbBox.Cleanable Then
                cmbBox.Text = ""
                cmbBox.SelectedIndex = -1
            End If
            controls.Add(cmbBox)
        Next
        For Each lstBox As CustomListBox In form.Controls.OfType(Of CustomListBox)()
            If lstBox.Cleanable Then
                lstBox.DataSource = Nothing
                lstBox.Items.Clear()
            End If
            controls.Add(lstBox)
        Next
        For Each btn As CustomButton In form.Controls.OfType(Of CustomButton)()
            If btn.Cleanable Then
                btn.Visible = False
            End If
            controls.Add(btn)
        Next

        Dim firstControl As Control
        firstControl = controls.Find(Function(control) control.EnterIndex = 1)
        If Not IsNothing(firstControl) Then
            firstControl.Focus()
        End If
    End Sub
End Class
