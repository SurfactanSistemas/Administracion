<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesoReteRecibos
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
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.btnAcepta = New WindowsApplication1.CustomButton()
        Me.TipoProceso = New WindowsApplication1.CustomComboBox()
        Me.txtNombre = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.SuspendLayout()
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(171, 24)
        Me.txtDesde.Mask = "##/##/####"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(106, 20)
        Me.txtDesde.TabIndex = 0
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(171, 63)
        Me.txtHasta.Mask = "##/##/####"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(106, 20)
        Me.txtHasta.TabIndex = 1
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(202, 186)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 29)
        Me.btnCancela.TabIndex = 20
        Me.btnCancela.Text = "Cancelar"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Cleanable = False
        Me.btnAcepta.EnterIndex = -1
        Me.btnAcepta.LabelAssociationKey = -1
        Me.btnAcepta.Location = New System.Drawing.Point(78, 186)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(88, 29)
        Me.btnAcepta.TabIndex = 19
        Me.btnAcepta.Text = "Aceptar"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'TipoProceso
        '
        Me.TipoProceso.Cleanable = False
        Me.TipoProceso.Empty = False
        Me.TipoProceso.EnterIndex = -1
        Me.TipoProceso.FormattingEnabled = True
        Me.TipoProceso.LabelAssociationKey = -1
        Me.TipoProceso.Location = New System.Drawing.Point(171, 134)
        Me.TipoProceso.Name = "TipoProceso"
        Me.TipoProceso.Size = New System.Drawing.Size(144, 21)
        Me.TipoProceso.TabIndex = 3
        Me.TipoProceso.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = False
        Me.txtNombre.Empty = True
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = -1
        Me.txtNombre.Location = New System.Drawing.Point(171, 99)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(116, 20)
        Me.txtNombre.TabIndex = 2
        Me.txtNombre.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(75, 142)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(70, 13)
        Me.CustomLabel4.TabIndex = 16
        Me.CustomLabel4.Text = "Tipo Proceso"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(75, 99)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(44, 13)
        Me.CustomLabel3.TabIndex = 13
        Me.CustomLabel3.Text = "Nombre"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(75, 63)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 12
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(75, 24)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 11
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'ProcesoReteRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 234)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.TipoProceso)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtHasta)
        Me.Controls.Add(Me.txtDesde)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ProcesoReteRecibos"
        Me.Text = "Proceso de Retenciones de Recibos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombre As WindowsApplication1.CustomTextBox
    Friend WithEvents TipoProceso As WindowsApplication1.CustomComboBox
    Friend WithEvents btnAcepta As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
