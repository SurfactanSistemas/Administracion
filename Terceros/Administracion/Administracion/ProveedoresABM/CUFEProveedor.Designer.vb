<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUFEProveedor
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
        Me.txtCUFE3 = New Administracion.CustomTextBox()
        Me.txtCUFE2 = New Administracion.CustomTextBox()
        Me.txtCUFE1 = New Administracion.CustomTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.txtCUFE3Fecha = New Administracion.CustomTextBox()
        Me.txtCUFE2Fecha = New Administracion.CustomTextBox()
        Me.txtCUFE1Fecha = New Administracion.CustomTextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCUFE3
        '
        Me.txtCUFE3.Cleanable = False
        Me.txtCUFE3.Empty = True
        Me.txtCUFE3.EnterIndex = 5
        Me.txtCUFE3.LabelAssociationKey = 3
        Me.txtCUFE3.Location = New System.Drawing.Point(117, 115)
        Me.txtCUFE3.MaxLength = 20
        Me.txtCUFE3.Name = "txtCUFE3"
        Me.txtCUFE3.Size = New System.Drawing.Size(142, 20)
        Me.txtCUFE3.TabIndex = 5
        Me.txtCUFE3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCUFE3.Validator = Administracion.ValidatorType.None
        '
        'txtCUFE2
        '
        Me.txtCUFE2.Cleanable = False
        Me.txtCUFE2.Empty = True
        Me.txtCUFE2.EnterIndex = 3
        Me.txtCUFE2.LabelAssociationKey = 2
        Me.txtCUFE2.Location = New System.Drawing.Point(117, 75)
        Me.txtCUFE2.MaxLength = 20
        Me.txtCUFE2.Name = "txtCUFE2"
        Me.txtCUFE2.Size = New System.Drawing.Size(142, 20)
        Me.txtCUFE2.TabIndex = 4
        Me.txtCUFE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCUFE2.Validator = Administracion.ValidatorType.None
        '
        'txtCUFE1
        '
        Me.txtCUFE1.Cleanable = False
        Me.txtCUFE1.Empty = True
        Me.txtCUFE1.EnterIndex = 1
        Me.txtCUFE1.LabelAssociationKey = 1
        Me.txtCUFE1.Location = New System.Drawing.Point(117, 37)
        Me.txtCUFE1.MaxLength = 20
        Me.txtCUFE1.Name = "txtCUFE1"
        Me.txtCUFE1.Size = New System.Drawing.Size(142, 20)
        Me.txtCUFE1.TabIndex = 3
        Me.txtCUFE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCUFE1.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(60, 116)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(55, 18)
        Me.CustomLabel3.TabIndex = 2
        Me.CustomLabel3.Text = "CUFE III"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(63, 76)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(51, 18)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "CUFE II"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(66, 38)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(47, 18)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "CUFE I"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 50)
        Me.Panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(398, 9)
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
        Me.Label1.Size = New System.Drawing.Size(118, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CUFE Proveedor"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtCUFE2)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.txtCUFE3Fecha)
        Me.Panel2.Controls.Add(Me.txtCUFE2Fecha)
        Me.Panel2.Controls.Add(Me.txtCUFE1Fecha)
        Me.Panel2.Controls.Add(Me.txtCUFE1)
        Me.Panel2.Controls.Add(Me.txtCUFE3)
        Me.Panel2.Location = New System.Drawing.Point(-1, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 156)
        Me.Panel2.TabIndex = 10
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 1
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(386, 13)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(66, 18)
        Me.CustomLabel5.TabIndex = 0
        Me.CustomLabel5.Text = "Dirección"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 1
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(162, 13)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(51, 18)
        Me.CustomLabel4.TabIndex = 0
        Me.CustomLabel4.Text = "Código"
        '
        'txtCUFE3Fecha
        '
        Me.txtCUFE3Fecha.Cleanable = False
        Me.txtCUFE3Fecha.Empty = True
        Me.txtCUFE3Fecha.EnterIndex = 1
        Me.txtCUFE3Fecha.LabelAssociationKey = 1
        Me.txtCUFE3Fecha.Location = New System.Drawing.Point(265, 114)
        Me.txtCUFE3Fecha.MaxLength = 20
        Me.txtCUFE3Fecha.Name = "txtCUFE3Fecha"
        Me.txtCUFE3Fecha.Size = New System.Drawing.Size(289, 20)
        Me.txtCUFE3Fecha.TabIndex = 3
        Me.txtCUFE3Fecha.Validator = Administracion.ValidatorType.None
        '
        'txtCUFE2Fecha
        '
        Me.txtCUFE2Fecha.Cleanable = False
        Me.txtCUFE2Fecha.Empty = True
        Me.txtCUFE2Fecha.EnterIndex = 1
        Me.txtCUFE2Fecha.LabelAssociationKey = 1
        Me.txtCUFE2Fecha.Location = New System.Drawing.Point(265, 74)
        Me.txtCUFE2Fecha.MaxLength = 20
        Me.txtCUFE2Fecha.Name = "txtCUFE2Fecha"
        Me.txtCUFE2Fecha.Size = New System.Drawing.Size(289, 20)
        Me.txtCUFE2Fecha.TabIndex = 3
        Me.txtCUFE2Fecha.Validator = Administracion.ValidatorType.None
        '
        'txtCUFE1Fecha
        '
        Me.txtCUFE1Fecha.Cleanable = False
        Me.txtCUFE1Fecha.Empty = True
        Me.txtCUFE1Fecha.EnterIndex = 1
        Me.txtCUFE1Fecha.LabelAssociationKey = 1
        Me.txtCUFE1Fecha.Location = New System.Drawing.Point(265, 37)
        Me.txtCUFE1Fecha.MaxLength = 20
        Me.txtCUFE1Fecha.Name = "txtCUFE1Fecha"
        Me.txtCUFE1Fecha.Size = New System.Drawing.Size(289, 20)
        Me.txtCUFE1Fecha.TabIndex = 3
        Me.txtCUFE1Fecha.Validator = Administracion.ValidatorType.None
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Location = New System.Drawing.Point(259, 212)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(56, 37)
        Me.btnAgregar.TabIndex = 71
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Cerrar ventana")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'CUFEProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 257)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CUFEProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtCUFE1 As Administracion.CustomTextBox
    Friend WithEvents txtCUFE2 As Administracion.CustomTextBox
    Friend WithEvents txtCUFE3 As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtCUFE3Fecha As Administracion.CustomTextBox
    Friend WithEvents txtCUFE2Fecha As Administracion.CustomTextBox
    Friend WithEvents txtCUFE1Fecha As Administracion.CustomTextBox
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
