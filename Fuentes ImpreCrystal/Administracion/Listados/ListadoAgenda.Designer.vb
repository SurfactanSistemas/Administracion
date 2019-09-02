<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoAgenda
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
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btnAcepta = New System.Windows.Forms.Button()
        Me.TipoListado = New WindowsApplication1.CustomComboBox()
        Me.txthastafecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.TipoLetras = New WindowsApplication1.CustomComboBox()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.SuspendLayout()
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(207, 207)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(125, 34)
        Me.btnCancela.TabIndex = 47
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Location = New System.Drawing.Point(51, 207)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(125, 34)
        Me.btnAcepta.TabIndex = 46
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'TipoListado
        '
        Me.TipoListado.Cleanable = False
        Me.TipoListado.Empty = False
        Me.TipoListado.EnterIndex = -1
        Me.TipoListado.FormattingEnabled = True
        Me.TipoListado.LabelAssociationKey = -1
        Me.TipoListado.Location = New System.Drawing.Point(186, 90)
        Me.TipoListado.Name = "TipoListado"
        Me.TipoListado.Size = New System.Drawing.Size(146, 21)
        Me.TipoListado.TabIndex = 40
        Me.TipoListado.Validator = WindowsApplication1.ValidatorType.None
        '
        'txthastafecha
        '
        Me.txthastafecha.Location = New System.Drawing.Point(186, 58)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(106, 20)
        Me.txthastafecha.TabIndex = 39
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Location = New System.Drawing.Point(186, 22)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtDesdeFecha.TabIndex = 38
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(64, 98)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(65, 13)
        Me.CustomLabel3.TabIndex = 45
        Me.CustomLabel3.Text = "Tipo Listado"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(64, 61)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 44
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(64, 25)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 43
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(220, 163)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 42
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(86, 163)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 41
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'TipoLetras
        '
        Me.TipoLetras.Cleanable = False
        Me.TipoLetras.Empty = False
        Me.TipoLetras.EnterIndex = -1
        Me.TipoLetras.FormattingEnabled = True
        Me.TipoLetras.LabelAssociationKey = -1
        Me.TipoLetras.Location = New System.Drawing.Point(186, 127)
        Me.TipoLetras.Name = "TipoLetras"
        Me.TipoLetras.Size = New System.Drawing.Size(146, 21)
        Me.TipoLetras.TabIndex = 48
        Me.TipoLetras.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(64, 135)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(60, 13)
        Me.CustomLabel4.TabIndex = 49
        Me.CustomLabel4.Text = "Tipo Letras"
        '
        'ListadoAgenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 277)
        Me.Controls.Add(Me.TipoLetras)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.TipoListado)
        Me.Controls.Add(Me.txthastafecha)
        Me.Controls.Add(Me.txtDesdeFecha)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Controls.Add(Me.opcImpesora)
        Me.Controls.Add(Me.opcPantalla)
        Me.Name = "ListadoAgenda"
        Me.Text = "Listado de Agenda de Vencimientos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    Friend WithEvents TipoListado As WindowsApplication1.CustomComboBox
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents TipoLetras As WindowsApplication1.CustomComboBox
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
End Class
