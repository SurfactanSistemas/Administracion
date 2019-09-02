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
        Me.txtMes = New WindowsApplication1.CustomTextBox()
        Me.txtAno = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.Proceso = New WindowsApplication1.CustomComboBox()
        Me.btnGraba = New WindowsApplication1.CustomButton()
        Me.btnMenu = New WindowsApplication1.CustomButton()
        Me.SuspendLayout()
        '
        'txtMes
        '
        Me.txtMes.Cleanable = False
        Me.txtMes.Empty = True
        Me.txtMes.EnterIndex = -1
        Me.txtMes.LabelAssociationKey = -1
        Me.txtMes.Location = New System.Drawing.Point(144, 61)
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(66, 20)
        Me.txtMes.TabIndex = 0
        Me.txtMes.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtAno
        '
        Me.txtAno.Cleanable = False
        Me.txtAno.Empty = True
        Me.txtAno.EnterIndex = -1
        Me.txtAno.LabelAssociationKey = -1
        Me.txtAno.Location = New System.Drawing.Point(216, 61)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(71, 20)
        Me.txtAno.TabIndex = 1
        Me.txtAno.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(51, 61)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(57, 13)
        Me.CustomLabel1.TabIndex = 8
        Me.CustomLabel1.Text = "Mes / Ano"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(51, 107)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(40, 13)
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
        Me.Proceso.Location = New System.Drawing.Point(144, 104)
        Me.Proceso.Name = "Proceso"
        Me.Proceso.Size = New System.Drawing.Size(151, 21)
        Me.Proceso.TabIndex = 2
        Me.Proceso.Validator = WindowsApplication1.ValidatorType.None
        '
        'btnGraba
        '
        Me.btnGraba.Cleanable = False
        Me.btnGraba.EnterIndex = -1
        Me.btnGraba.LabelAssociationKey = -1
        Me.btnGraba.Location = New System.Drawing.Point(83, 167)
        Me.btnGraba.Name = "btnGraba"
        Me.btnGraba.Size = New System.Drawing.Size(96, 34)
        Me.btnGraba.TabIndex = 12
        Me.btnGraba.Text = "Graba"
        Me.btnGraba.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.Cleanable = False
        Me.btnMenu.EnterIndex = -1
        Me.btnMenu.LabelAssociationKey = -1
        Me.btnMenu.Location = New System.Drawing.Point(232, 167)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(89, 34)
        Me.btnMenu.TabIndex = 13
        Me.btnMenu.Text = "Menu Principal"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'CierreMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 318)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnGraba)
        Me.Controls.Add(Me.Proceso)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.txtMes)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "CierreMes"
        Me.Text = "CierreMes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMes As WindowsApplication1.CustomTextBox
    Friend WithEvents txtAno As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents Proceso As WindowsApplication1.CustomComboBox
    Friend WithEvents btnGraba As WindowsApplication1.CustomButton
    Friend WithEvents btnMenu As WindowsApplication1.CustomButton
End Class
