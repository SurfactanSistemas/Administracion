<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RubrosProveedorABM
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
        Me.CustomLabel2.Location = New System.Drawing.Point(26, 79)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(63, 13)
        Me.CustomLabel2.TabIndex = 30
        Me.CustomLabel2.Text = "Descripcion"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(26, 49)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel1.TabIndex = 29
        Me.CustomLabel1.Text = "Codigo"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Cleanable = True
        Me.txtDescripcion.Empty = False
        Me.txtDescripcion.EnterIndex = 2
        Me.txtDescripcion.LabelAssociationKey = 2
        Me.txtDescripcion.Location = New System.Drawing.Point(131, 76)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(326, 20)
        Me.txtDescripcion.TabIndex = 28
        Me.txtDescripcion.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(131, 46)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(79, 20)
        Me.txtCodigo.TabIndex = 27
        Me.txtCodigo.Validator = WindowsApplication1.ValidatorType.Positive
        '
        'RubrosProveedorABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 262)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "RubrosProveedorABM"
        Me.Text = "Ingreso de Rubros Proveedor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents txtDescripcion As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCodigo As WindowsApplication1.CustomTextBox
End Class
