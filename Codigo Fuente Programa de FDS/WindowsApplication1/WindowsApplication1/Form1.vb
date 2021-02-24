Imports System
Imports System.IO

Public Class Form1



    '  Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
    '     Select Case e.KeyData
    '        Case Keys.Enter
    ' Dim codigo As String
    '            If (MaskedTextBox1.Text <> "") Then
    '               codigo = MaskedTextBox1.Text.Substring(2, 8)
    '              ListBox1.Items.Clear()
    'Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
    '
    '               ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    '          End If
    '     Case Keys.Escape
    '        MaskedTextBox1.Text = ""
    '
    '   End Select
    'End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim j As String = Configuration.ConfigurationManager.AppSettings("PATH") & "\" & ListBox1.SelectedItem.ToString()
        Process.Start(j)

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(d.GetFiles("*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    End Sub


    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
        ListBox1.Items.Clear()
        'For Each f As FileInfo In d.GetFiles("*.pdf", System.IO.SearchOption.AllDirectories)
        'ListBox1.Items.Add(f.Name)
        'Next
        ListBox1.Items.AddRange(d.GetFiles("*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Dim codigo As String
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
        codigo = TextBox1.Text.Replace(" ", "")
        ListBox1.Items.Clear()
        'For Each f As FileInfo In d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.AllDirectories)
        'ListBox1.Items.Add(f.Name)
        'Next
        ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                TextBox1.Text = ""
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MenuPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub MaskedTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyUp


        Dim codigo As String
        If (MaskedTextBox1.Text <> "") Then
            If (MaskedTextBox1.Text.Length() > 2) Then
                codigo = MaskedTextBox1.Text.Substring(2).Replace("-", "")
                ListBox1.Items.Clear()
                Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))

                ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
            End If

        End If
        Select Case e.KeyData

            Case Keys.Escape
                MaskedTextBox1.Text = ""
                ListBox1.Items.Clear()
                Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
                ListBox1.Items.AddRange(d.GetFiles("*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
        End Select

    End Sub
End Class
