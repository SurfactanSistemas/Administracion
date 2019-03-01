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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbEntity = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPsw = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(200, 126)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(124, 40)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "SALIR"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAccept.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAccept.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAccept.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccept.Location = New System.Drawing.Point(58, 126)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(124, 40)
        Me.btnAccept.TabIndex = 3
        Me.btnAccept.Text = "INICIAR SESIÓN"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 50)
        Me.Panel1.TabIndex = 8
        '
        'cmbEntity
        '
        Me.cmbEntity.Items.AddRange(New Object() {"SURFACTAN S.A.", "PELLITAL S.A"})
        Me.cmbEntity.Location = New System.Drawing.Point(15, 57)
        Me.cmbEntity.Name = "cmbEntity"
        Me.cmbEntity.Size = New System.Drawing.Size(52, 21)
        Me.cmbEntity.TabIndex = 1
        Me.cmbEntity.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "EMPRESA"
        Me.Label1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(170, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Clave"
        '
        'txtPsw
        '
        Me.txtPsw.Location = New System.Drawing.Point(104, 88)
        Me.txtPsw.Name = "txtPsw"
        Me.txtPsw.Size = New System.Drawing.Size(174, 20)
        Me.txtPsw.TabIndex = 2
        Me.txtPsw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPsw.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SISTEMA DE INVESTIGACIÓN"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(239, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "- INICIO DE SESIÓN -"
        '
        'Login
        '
        Me.ClientSize = New System.Drawing.Size(383, 193)
        Me.Controls.Add(Me.txtPsw)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cmbEntity)
        Me.Controls.Add(Me.btnAccept)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAccept As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPsw As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
