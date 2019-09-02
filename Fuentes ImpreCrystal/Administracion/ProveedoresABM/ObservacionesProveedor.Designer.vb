<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObservacionesProveedor
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
        Me.CustomTextBox1 = New WindowsApplication1.CustomTextBox()
        Me.btnAceptar = New WindowsApplication1.CustomButton()
        Me.SuspendLayout()
        '
        'CustomTextBox1
        '
        Me.CustomTextBox1.Cleanable = False
        Me.CustomTextBox1.Empty = True
        Me.CustomTextBox1.EnterIndex = -1
        Me.CustomTextBox1.LabelAssociationKey = -1
        Me.CustomTextBox1.Location = New System.Drawing.Point(9, 6)
        Me.CustomTextBox1.Multiline = True
        Me.CustomTextBox1.Name = "CustomTextBox1"
        Me.CustomTextBox1.Size = New System.Drawing.Size(401, 280)
        Me.CustomTextBox1.TabIndex = 0
        Me.CustomTextBox1.Validator = WindowsApplication1.ValidatorType.None
        '
        'btnAceptar
        '
        Me.btnAceptar.Cleanable = False
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.EnterIndex = -1
        Me.btnAceptar.LabelAssociationKey = -1
        Me.btnAceptar.Location = New System.Drawing.Point(308, 292)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 35)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ObservacionesProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 339)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.CustomTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ObservacionesProveedor"
        Me.Text = "Observaciones del Proveedor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomTextBox1 As WindowsApplication1.CustomTextBox
    Friend WithEvents btnAceptar As WindowsApplication1.CustomButton
End Class
