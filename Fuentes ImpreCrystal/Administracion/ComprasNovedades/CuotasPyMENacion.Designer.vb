<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuotasPyMENacion
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
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.txtCantidadCuotas = New WindowsApplication1.CustomTextBox()
        Me.txtMes = New WindowsApplication1.CustomTextBox()
        Me.txtAnio = New WindowsApplication1.CustomTextBox()
        Me.SuspendLayout()
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(12, 19)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Cuotas"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(12, 47)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(86, 13)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Fecha 1er Cuota"
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.Cleanable = False
        Me.txtCantidadCuotas.Empty = False
        Me.txtCantidadCuotas.EnterIndex = 1
        Me.txtCantidadCuotas.LabelAssociationKey = 1
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(113, 13)
        Me.txtCantidadCuotas.MaxLength = 3
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(52, 20)
        Me.txtCantidadCuotas.TabIndex = 2
        Me.txtCantidadCuotas.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtMes
        '
        Me.txtMes.Cleanable = False
        Me.txtMes.Empty = False
        Me.txtMes.EnterIndex = 2
        Me.txtMes.LabelAssociationKey = 2
        Me.txtMes.Location = New System.Drawing.Point(113, 44)
        Me.txtMes.MaxLength = 3
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(52, 20)
        Me.txtMes.TabIndex = 3
        Me.txtMes.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtAnio
        '
        Me.txtAnio.Cleanable = False
        Me.txtAnio.Empty = False
        Me.txtAnio.EnterIndex = 3
        Me.txtAnio.LabelAssociationKey = 2
        Me.txtAnio.Location = New System.Drawing.Point(171, 44)
        Me.txtAnio.MaxLength = 5
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(65, 20)
        Me.txtAnio.TabIndex = 4
        Me.txtAnio.Validator = WindowsApplication1.ValidatorType.None
        '
        'CuotasPyMENacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 84)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.txtMes)
        Me.Controls.Add(Me.txtCantidadCuotas)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CuotasPyMENacion"
        Me.Text = "Cuotas PyME Nación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents txtCantidadCuotas As WindowsApplication1.CustomTextBox
    Friend WithEvents txtMes As WindowsApplication1.CustomTextBox
    Friend WithEvents txtAnio As WindowsApplication1.CustomTextBox
End Class
