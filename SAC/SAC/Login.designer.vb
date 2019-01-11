Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices
Imports SAC.My.Resources

<DesignerGenerated()> _
Partial Class Login
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbEntity = New ComboBox()
        Me.Label1 = New Label()
        Me.btnCancel = New Button()
        Me.btnAccept = New Button()
        Me.Panel1 = New Panel()
        Me.Label2 = New Label()
        Me.Label3 = New Label()
        Me.Panel2 = New Panel()
        Me.txtPsw = New TextBox()
        Me.Label4 = New Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbEntity
        '
        Me.cmbEntity.Items.AddRange(New Object() {"SURFACTAN S.A.", "PELLITAL S.A"})
        Me.cmbEntity.Location = New Point(184, 33)
        Me.cmbEntity.Name = "cmbEntity"
        Me.cmbEntity.Size = New Size(192, 21)
        Me.cmbEntity.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold)
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(108, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(65, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa:"
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Salir2
        Me.btnCancel.BackgroundImageLayout = ImageLayout.Zoom
        Me.btnCancel.Cursor = Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderColor = SystemColors.Control
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.CheckedBackColor = SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseDownBackColor = SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseOverBackColor = SystemColors.Control
        Me.btnCancel.FlatStyle = FlatStyle.Flat
        Me.btnCancel.Location = New Point(276, 174)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New Size(58, 59)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.BackgroundImage = Aceptar_N2
        Me.btnAccept.BackgroundImageLayout = ImageLayout.Zoom
        Me.btnAccept.Cursor = Cursors.Hand
        Me.btnAccept.FlatAppearance.BorderColor = SystemColors.Control
        Me.btnAccept.FlatAppearance.BorderSize = 0
        Me.btnAccept.FlatAppearance.CheckedBackColor = SystemColors.Control
        Me.btnAccept.FlatAppearance.MouseDownBackColor = SystemColors.Control
        Me.btnAccept.FlatAppearance.MouseOverBackColor = SystemColors.Control
        Me.btnAccept.FlatStyle = FlatStyle.Flat
        Me.btnAccept.Location = New Point(160, 174)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New Size(58, 59)
        Me.btnAccept.TabIndex = 6
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(496, 50)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 15.75!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(47, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(128, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SISTEMA SAC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New Font("Calibri", 12.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = SystemColors.Control
        Me.Label3.Location = New Point(317, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(133, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "- Inicio de Sesión -"
        '
        'Panel2
        '
        Me.Panel2.BackColor = Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtPsw)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbEntity)
        Me.Panel2.Location = New Point(-1, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(496, 118)
        Me.Panel2.TabIndex = 9
        '
        'txtPsw
        '
        Me.txtPsw.Location = New Point(184, 67)
        Me.txtPsw.Name = "txtPsw"
        Me.txtPsw.Size = New Size(192, 20)
        Me.txtPsw.TabIndex = 3
        Me.txtPsw.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New Font("Calibri", 11.25!, FontStyle.Bold)
        Me.Label4.ForeColor = SystemColors.Control
        Me.Label4.Location = New Point(91, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(82, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Contraseña:"
        '
        'Login
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(495, 237)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAccept)
        Me.FormBorderStyle = FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbEntity As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAccept As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPsw As TextBox
    Friend WithEvents Label4 As Label
End Class
