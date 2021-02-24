
Imports System
Imports System.IO


Public Class MP_DY
    'Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
    '   Select Case e.KeyData
    '      Case Keys.Enter
    ' Dim codigo, DY As String
    ' Dim bandera As Boolean = False
    '            DY = "DY"
    '           If (MaskedTextBox1.Text <> "") Then
    '              bandera = MaskedTextBox1.Text.Substring(0, 2) = DY
    '             If (bandera = True) Then
    '                codigo = MaskedTextBox1.Text.Substring(3, 7)
    '               ListBox1.Items.Clear()
    '
    '    Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
    '
    '                   ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    '                  codigo = MaskedTextBox1.Text.Substring(3, 7).Replace("-", "")
    '                 ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
    '
    '               Else
    '                  codigo = MaskedTextBox1.Text.Replace("-", "")
    '                 ListBox1.Items.Clear()
    'Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH") & "\FDS MP")
    '
    '                   ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.AllDirectories).ToArray())
    '              End If
    '         End If
    '    Case Keys.Escape
    '       MaskedTextBox1.Text = ""
    '  End Select
    'End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Dim codigo As String
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH") & "\FDS MP")
        codigo = TextBox1.Text.Replace(" ", "")
        ListBox1.Items.Clear()
        ' For Each f As FileInfo In d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.AllDirectories)
        'ListBox1.Items.Add(f.Name)
        'Next
        ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.AllDirectories).ToArray())
    End Sub



    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH") & "\FDS MP")
        ListBox1.Items.Clear()
        ' For Each f As FileInfo In d.GetFiles("*.pdf", System.IO.SearchOption.AllDirectories)
        ' ListBox1.Items.Add(f.Name)
        ' Next
        ListBox1.Items.AddRange(d.GetFiles("*.pdf", System.IO.SearchOption.AllDirectories).ToArray())
    End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim j As String = Configuration.ConfigurationManager.AppSettings("PATH") & ListBox1.SelectedItem.ToString()
        If (ListBox1.SelectedItem.ToString().Substring(0, 5) = "FDSDY") Then

            Process.Start(j)
        Else
            j = Configuration.ConfigurationManager.AppSettings("PATH") & "FDS MP\" & ListBox1.SelectedItem.ToString()
            Process.Start(j)
        End If



    End Sub

    Private Sub MP_DY_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Show()
    End Sub

    Private Sub MP_DY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH") & "FDS MP")
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(d.GetFiles("*.pdf", System.IO.SearchOption.AllDirectories).ToArray())

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
        Dim codigo, DY As String
        Dim bandera As Boolean = False
        DY = "DY"
        If (MaskedTextBox1.Text <> "") Then
            If (MaskedTextBox1.Text.Substring(0, 1) = DY.Substring(0, 1)) Then
                bandera = MaskedTextBox1.Text.Substring(1, 1) = DY.Substring(1, 1)
            End If
            If (bandera = True) Then
                codigo = MaskedTextBox1.Text.TrimEnd("-").Trim
                ListBox1.Items.Clear()

                Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH"))
                
                ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*pdf", System.IO.SearchOption.TopDirectoryOnly).ToArray())
                'codigo = MaskedTextBox1.Text.Substring(3, 7).Replace("-", "")

            Else
                codigo = MaskedTextBox1.Text.Replace("-", "").Trim()
                ListBox1.Items.Clear()
                Dim d As New DirectoryInfo(Configuration.ConfigurationManager.AppSettings("PATH") & "\FDS MP")
                ListBox1.Items.AddRange(d.GetFiles("*" & codigo & "*.pdf", System.IO.SearchOption.AllDirectories).ToArray())
            End If
        End If
        Select Case e.KeyData
            Case Keys.Escape
                MaskedTextBox1.Text = ""
        End Select
    End Sub


End Class