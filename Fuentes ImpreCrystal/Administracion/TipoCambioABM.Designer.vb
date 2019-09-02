<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TipoCambioABM
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
        Me.txtParidad = New WindowsApplication1.CustomTextBox()
        Me.txtFecha = New WindowsApplication1.CustomTextBox()
        Me.SuspendLayout()
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Location = New System.Drawing.Point(35, 65)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(88, 13)
        Me.CustomLabel2.TabIndex = 16
        Me.CustomLabel2.Text = "Paridad del Dólar"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Location = New System.Drawing.Point(35, 33)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(37, 13)
        Me.CustomLabel1.TabIndex = 15
        Me.CustomLabel1.Text = "Fecha"
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = False
        Me.txtParidad.EnterIndex = 2
        Me.txtParidad.LabelAssociationKey = 2
        Me.txtParidad.Location = New System.Drawing.Point(170, 62)
        Me.txtParidad.MaxLength = 8
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(100, 20)
        Me.txtParidad.TabIndex = 14
        Me.txtParidad.Validator = WindowsApplication1.ValidatorType.StrictlyPositiveFloat
        '
        'txtFecha
        '
        Me.txtFecha.Cleanable = True
        Me.txtFecha.Empty = False
        Me.txtFecha.EnterIndex = 1
        Me.txtFecha.LabelAssociationKey = 1
        Me.txtFecha.Location = New System.Drawing.Point(166, 26)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(104, 20)
        Me.txtFecha.TabIndex = 13
        Me.txtFecha.Validator = WindowsApplication1.ValidatorType.DateFormat
        '
        'TipoCambioABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 416)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.txtParidad)
        Me.Controls.Add(Me.txtFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "TipoCambioABM"
        Me.Text = "Ingreso de Cambios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents txtParidad As WindowsApplication1.CustomTextBox
    Friend WithEvents txtFecha As WindowsApplication1.CustomTextBox
End Class
