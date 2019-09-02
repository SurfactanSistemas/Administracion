<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesoRetencionesPagos
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
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.btnAceptaRetePago = New WindowsApplication1.CustomButton()
        Me.TipoProceso = New WindowsApplication1.CustomComboBox()
        Me.txtNombre = New WindowsApplication1.CustomTextBox()
        Me.SuspendLayout()
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(180, 67)
        Me.txtHasta.Mask = "##/##/####"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(106, 20)
        Me.txtHasta.TabIndex = 11
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(180, 31)
        Me.txtDesde.Mask = "##/##/####"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(106, 20)
        Me.txtDesde.TabIndex = 8
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(228, 190)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 29)
        Me.btnCancela.TabIndex = 16
        Me.btnCancela.Text = "Cancelar"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(75, 142)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(70, 13)
        Me.CustomLabel4.TabIndex = 15
        Me.CustomLabel4.Text = "Tipo Proceso"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(75, 106)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(44, 13)
        Me.CustomLabel3.TabIndex = 10
        Me.CustomLabel3.Text = "Nombre"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(75, 70)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 9
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(75, 31)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 7
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'btnAceptaRetePago
        '
        Me.btnAceptaRetePago.Cleanable = False
        Me.btnAceptaRetePago.EnterIndex = -1
        Me.btnAceptaRetePago.LabelAssociationKey = -1
        Me.btnAceptaRetePago.Location = New System.Drawing.Point(78, 190)
        Me.btnAceptaRetePago.Name = "btnAceptaRetePago"
        Me.btnAceptaRetePago.Size = New System.Drawing.Size(88, 29)
        Me.btnAceptaRetePago.TabIndex = 18
        Me.btnAceptaRetePago.Text = "Aceptar"
        Me.btnAceptaRetePago.UseVisualStyleBackColor = True
        '
        'TipoProceso
        '
        Me.TipoProceso.Cleanable = False
        Me.TipoProceso.Empty = False
        Me.TipoProceso.EnterIndex = -1
        Me.TipoProceso.FormattingEnabled = True
        Me.TipoProceso.LabelAssociationKey = -1
        Me.TipoProceso.Location = New System.Drawing.Point(176, 142)
        Me.TipoProceso.Name = "TipoProceso"
        Me.TipoProceso.Size = New System.Drawing.Size(127, 21)
        Me.TipoProceso.TabIndex = 17
        Me.TipoProceso.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = False
        Me.txtNombre.Empty = True
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = -1
        Me.txtNombre.Location = New System.Drawing.Point(176, 106)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(108, 20)
        Me.txtNombre.TabIndex = 13
        Me.txtNombre.Validator = WindowsApplication1.ValidatorType.None
        '
        'ProcesoRetencionesPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 241)
        Me.Controls.Add(Me.btnAceptaRetePago)
        Me.Controls.Add(Me.TipoProceso)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.txtHasta)
        Me.Controls.Add(Me.txtDesde)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ProcesoRetencionesPagos"
        Me.Text = "Proceso de Retenciones de Ordenes de Pago"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombre As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents TipoProceso As WindowsApplication1.CustomComboBox
    Friend WithEvents btnAceptaRetePago As WindowsApplication1.CustomButton
End Class
