<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaContableABM
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
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.txtDescripcion = New WindowsApplication1.CustomTextBox()
        Me.txtCodigo = New WindowsApplication1.CustomTextBox()
        Me.SuspendLayout()
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(30, 60)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(63, 13)
        Me.CustomLabel2.TabIndex = 12
        Me.CustomLabel2.Text = "Descripción"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(30, 30)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel1.TabIndex = 11
        Me.CustomLabel1.Text = "Código"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Cleanable = True
        Me.txtDescripcion.Empty = False
        Me.txtDescripcion.EnterIndex = 2
        Me.txtDescripcion.LabelAssociationKey = 2
        Me.txtDescripcion.Location = New System.Drawing.Point(110, 57)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(265, 20)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(110, 27)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(80, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'CuentaContableABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 115)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "CuentaContableABM"
        Me.Text = "Ingreso de Cuentas Contables"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodigo As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDescripcion As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
End Class
