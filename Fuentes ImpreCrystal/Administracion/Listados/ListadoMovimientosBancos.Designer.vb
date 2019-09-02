<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoMovimientosBancos
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
        Me.txtHastaBanco = New System.Windows.Forms.TextBox()
        Me.txtDesdeBanco = New System.Windows.Forms.TextBox()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btnAcepta = New System.Windows.Forms.Button()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.txthastafecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.SuspendLayout()
        '
        'txtHastaBanco
        '
        Me.txtHastaBanco.Location = New System.Drawing.Point(221, 124)
        Me.txtHastaBanco.MaxLength = 4
        Me.txtHastaBanco.Name = "txtHastaBanco"
        Me.txtHastaBanco.Size = New System.Drawing.Size(69, 20)
        Me.txtHastaBanco.TabIndex = 62
        Me.txtHastaBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesdeBanco
        '
        Me.txtDesdeBanco.Location = New System.Drawing.Point(221, 95)
        Me.txtDesdeBanco.MaxLength = 4
        Me.txtDesdeBanco.Name = "txtDesdeBanco"
        Me.txtDesdeBanco.Size = New System.Drawing.Size(69, 20)
        Me.txtDesdeBanco.TabIndex = 61
        Me.txtDesdeBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(23, 267)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 60
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(23, 293)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 59
        Me.lstAyuda.Visible = False
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(320, 214)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(120, 37)
        Me.btnConsulta.TabIndex = 58
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(172, 214)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(125, 37)
        Me.btnCancela.TabIndex = 57
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Location = New System.Drawing.Point(22, 214)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(125, 37)
        Me.btnAcepta.TabIndex = 56
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(243, 177)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 55
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(109, 177)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 54
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(87, 127)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel4.TabIndex = 53
        Me.CustomLabel4.Text = "Desde Banco"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(87, 98)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel3.TabIndex = 52
        Me.CustomLabel3.Text = "Desde Banco"
        '
        'txthastafecha
        '
        Me.txthastafecha.Location = New System.Drawing.Point(221, 61)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(106, 20)
        Me.txthastafecha.TabIndex = 49
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Location = New System.Drawing.Point(221, 25)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtDesdeFecha.TabIndex = 48
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(87, 64)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 51
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(87, 28)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 50
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'ListadoMovimientosBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 460)
        Me.Controls.Add(Me.txtHastaBanco)
        Me.Controls.Add(Me.txtDesdeBanco)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.opcImpesora)
        Me.Controls.Add(Me.opcPantalla)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.txthastafecha)
        Me.Controls.Add(Me.txtDesdeFecha)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ListadoMovimientosBancos"
        Me.Text = "Listado de Movimientos  de Bancos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHastaBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtDesdeBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
End Class
