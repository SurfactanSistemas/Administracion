<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CierreMes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtMes = New Administracion.CustomTextBox()
        Me.txtAno = New Administracion.CustomTextBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.Proceso = New Administracion.CustomComboBox()
        Me.btnGraba = New Administracion.CustomButton()
        Me.btnMenu = New Administracion.CustomButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMes
        '
        Me.txtMes.Cleanable = False
        Me.txtMes.Empty = True
        Me.txtMes.EnterIndex = -1
        Me.txtMes.LabelAssociationKey = -1
        Me.txtMes.Location = New System.Drawing.Point(151, 19)
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(66, 20)
        Me.txtMes.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtMes, "Mes")
        Me.txtMes.Validator = Administracion.ValidatorType.None
        '
        'txtAno
        '
        Me.txtAno.Cleanable = False
        Me.txtAno.Empty = True
        Me.txtAno.EnterIndex = -1
        Me.txtAno.LabelAssociationKey = -1
        Me.txtAno.Location = New System.Drawing.Point(223, 19)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(66, 20)
        Me.txtAno.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtAno, "Año")
        Me.txtAno.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(69, 20)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(72, 18)
        Me.CustomLabel1.TabIndex = 8
        Me.CustomLabel1.Text = "Mes / Ano"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(305, 20)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(49, 18)
        Me.CustomLabel2.TabIndex = 11
        Me.CustomLabel2.Text = "Estado"
        '
        'Proceso
        '
        Me.Proceso.Cleanable = False
        Me.Proceso.Empty = False
        Me.Proceso.EnterIndex = -1
        Me.Proceso.FormattingEnabled = True
        Me.Proceso.LabelAssociationKey = -1
        Me.Proceso.Location = New System.Drawing.Point(368, 19)
        Me.Proceso.Name = "Proceso"
        Me.Proceso.Size = New System.Drawing.Size(151, 21)
        Me.Proceso.TabIndex = 2
        Me.Proceso.Validator = Administracion.ValidatorType.None
        '
        'btnGraba
        '
        Me.btnGraba.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnGraba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGraba.Cleanable = False
        Me.btnGraba.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGraba.EnterIndex = -1
        Me.btnGraba.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnGraba.FlatAppearance.BorderSize = 0
        Me.btnGraba.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnGraba.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnGraba.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnGraba.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGraba.LabelAssociationKey = -1
        Me.btnGraba.Location = New System.Drawing.Point(154, 117)
        Me.btnGraba.Name = "btnGraba"
        Me.btnGraba.Size = New System.Drawing.Size(138, 44)
        Me.btnGraba.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnGraba, "Aceptar")
        Me.btnGraba.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMenu.Cleanable = False
        Me.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu.EnterIndex = -1
        Me.btnMenu.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnMenu.FlatAppearance.BorderSize = 0
        Me.btnMenu.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu.LabelAssociationKey = -1
        Me.btnMenu.Location = New System.Drawing.Point(303, 117)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(131, 44)
        Me.btnMenu.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnMenu, "Cerrar")
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(582, 50)
        Me.Panel1.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(400, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cierre de Mes"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtMes)
        Me.Panel2.Controls.Add(Me.txtAno)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.Proceso)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 59)
        Me.Panel2.TabIndex = 15
        '
        'CierreMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 169)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnGraba)
        Me.Name = "CierreMes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMes As Administracion.CustomTextBox
    Friend WithEvents txtAno As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents Proceso As Administracion.CustomComboBox
    Friend WithEvents btnGraba As Administracion.CustomButton
    Friend WithEvents btnMenu As Administracion.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
