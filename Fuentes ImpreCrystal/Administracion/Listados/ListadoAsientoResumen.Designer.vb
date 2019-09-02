<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoAsientoResumen
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
        Me.txthastafecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.btnAcepta = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.TipoListado = New WindowsApplication1.CustomComboBox()
        Me.txtHastaCuenta = New WindowsApplication1.CustomTextBox()
        Me.txtDesdeCuenta = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel5 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.SuspendLayout()
        '
        'txthastafecha
        '
        Me.txthastafecha.Location = New System.Drawing.Point(217, 60)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(106, 20)
        Me.txthastafecha.TabIndex = 1
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Location = New System.Drawing.Point(217, 24)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtDesdeFecha.TabIndex = 0
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(254, 218)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 33
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(120, 218)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 32
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Location = New System.Drawing.Point(33, 255)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(125, 37)
        Me.btnAcepta.TabIndex = 34
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(183, 255)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(125, 37)
        Me.btnCancela.TabIndex = 35
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(331, 255)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(120, 37)
        Me.btnConsulta.TabIndex = 38
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(34, 308)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 37
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(34, 334)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 36
        Me.lstAyuda.Visible = False
        '
        'TipoListado
        '
        Me.TipoListado.Cleanable = False
        Me.TipoListado.Empty = False
        Me.TipoListado.EnterIndex = -1
        Me.TipoListado.FormattingEnabled = True
        Me.TipoListado.LabelAssociationKey = -1
        Me.TipoListado.Location = New System.Drawing.Point(217, 173)
        Me.TipoListado.Name = "TipoListado"
        Me.TipoListado.Size = New System.Drawing.Size(146, 21)
        Me.TipoListado.TabIndex = 4
        Me.TipoListado.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtHastaCuenta
        '
        Me.txtHastaCuenta.Cleanable = False
        Me.txtHastaCuenta.Empty = True
        Me.txtHastaCuenta.EnterIndex = -1
        Me.txtHastaCuenta.LabelAssociationKey = -1
        Me.txtHastaCuenta.Location = New System.Drawing.Point(217, 133)
        Me.txtHastaCuenta.Name = "txtHastaCuenta"
        Me.txtHastaCuenta.Size = New System.Drawing.Size(131, 20)
        Me.txtHastaCuenta.TabIndex = 3
        Me.txtHastaCuenta.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtDesdeCuenta
        '
        Me.txtDesdeCuenta.Cleanable = False
        Me.txtDesdeCuenta.Empty = True
        Me.txtDesdeCuenta.EnterIndex = -1
        Me.txtDesdeCuenta.LabelAssociationKey = -1
        Me.txtDesdeCuenta.Location = New System.Drawing.Point(217, 93)
        Me.txtDesdeCuenta.Name = "txtDesdeCuenta"
        Me.txtDesdeCuenta.Size = New System.Drawing.Size(131, 20)
        Me.txtDesdeCuenta.TabIndex = 2
        Me.txtDesdeCuenta.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = -1
        Me.CustomLabel5.Location = New System.Drawing.Point(83, 176)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(65, 13)
        Me.CustomLabel5.TabIndex = 26
        Me.CustomLabel5.Text = "Tipo Listado"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(83, 136)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel4.TabIndex = 25
        Me.CustomLabel4.Text = "Hasta Cuenta"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(83, 100)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(75, 13)
        Me.CustomLabel3.TabIndex = 24
        Me.CustomLabel3.Text = "Desde Cuenta"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(83, 63)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 23
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(83, 27)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 22
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'ListadoAsientoResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 301)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.opcImpesora)
        Me.Controls.Add(Me.opcPantalla)
        Me.Controls.Add(Me.TipoListado)
        Me.Controls.Add(Me.txtHastaCuenta)
        Me.Controls.Add(Me.txtDesdeCuenta)
        Me.Controls.Add(Me.txthastafecha)
        Me.Controls.Add(Me.txtDesdeFecha)
        Me.Controls.Add(Me.CustomLabel5)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ListadoAsientoResumen"
        Me.Text = "Asiento Resumen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel5 As WindowsApplication1.CustomLabel
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeCuenta As WindowsApplication1.CustomTextBox
    Friend WithEvents txtHastaCuenta As WindowsApplication1.CustomTextBox
    Friend WithEvents TipoListado As WindowsApplication1.CustomComboBox
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
End Class
