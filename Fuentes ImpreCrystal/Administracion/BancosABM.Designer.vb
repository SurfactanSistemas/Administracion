<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancosABM
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
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.txtDescripcion = New WindowsApplication1.CustomTextBox()
        Me.txtCuenta = New WindowsApplication1.CustomTextBox()
        Me.txtNombre = New WindowsApplication1.CustomTextBox()
        Me.txtCodigo = New WindowsApplication1.CustomTextBox()
        Me.SuspendLayout()
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 3
        Me.CustomLabel3.Location = New System.Drawing.Point(31, 89)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(86, 13)
        Me.CustomLabel3.TabIndex = 27
        Me.CustomLabel3.Text = "Cuenta Contable"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(31, 56)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(44, 13)
        Me.CustomLabel2.TabIndex = 26
        Me.CustomLabel2.Text = "Nombre"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(31, 26)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(40, 13)
        Me.CustomLabel1.TabIndex = 25
        Me.CustomLabel1.Text = "Código"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Cleanable = True
        Me.txtDescripcion.Empty = True
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.EnterIndex = -1
        Me.txtDescripcion.LabelAssociationKey = 3
        Me.txtDescripcion.Location = New System.Drawing.Point(221, 86)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(71, 20)
        Me.txtDescripcion.TabIndex = 22
        Me.txtDescripcion.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtCuenta
        '
        Me.txtCuenta.Cleanable = True
        Me.txtCuenta.Empty = False
        Me.txtCuenta.EnterIndex = 3
        Me.txtCuenta.LabelAssociationKey = 3
        Me.txtCuenta.Location = New System.Drawing.Point(136, 86)
        Me.txtCuenta.MaxLength = 10
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(79, 20)
        Me.txtCuenta.TabIndex = 21
        Me.txtCuenta.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = True
        Me.txtNombre.Empty = False
        Me.txtNombre.EnterIndex = 2
        Me.txtNombre.LabelAssociationKey = 2
        Me.txtNombre.Location = New System.Drawing.Point(136, 53)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(326, 20)
        Me.txtNombre.TabIndex = 19
        Me.txtNombre.Validator = WindowsApplication1.ValidatorType.NotEmpty
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(136, 23)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(79, 20)
        Me.txtCodigo.TabIndex = 18
        Me.txtCodigo.Validator = WindowsApplication1.ValidatorType.Numeric
        '
        'BancosABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 177)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "BancosABM"
        Me.Text = "Ingreso de Bancos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCodigo As WindowsApplication1.CustomTextBox
    Friend WithEvents txtCuenta As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDescripcion As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
End Class
