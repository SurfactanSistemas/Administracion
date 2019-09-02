<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoImputacionesContable
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
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.CustomLabel5 = New WindowsApplication1.CustomLabel()
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btnAcepta = New System.Windows.Forms.Button()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkPagos = New System.Windows.Forms.CheckBox()
        Me.chkRecibos = New System.Windows.Forms.CheckBox()
        Me.chkDepositos = New System.Windows.Forms.CheckBox()
        Me.txtDesdeCuenta = New System.Windows.Forms.TextBox()
        Me.txtHastaCuenta = New System.Windows.Forms.TextBox()
        Me.TipoListado = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txthastafecha
        '
        Me.txthastafecha.Location = New System.Drawing.Point(302, 67)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(106, 20)
        Me.txthastafecha.TabIndex = 25
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Location = New System.Drawing.Point(302, 31)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtDesdeFecha.TabIndex = 24
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(168, 70)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(68, 13)
        Me.CustomLabel2.TabIndex = 27
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(168, 34)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(71, 13)
        Me.CustomLabel1.TabIndex = 26
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(168, 139)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(72, 13)
        Me.CustomLabel4.TabIndex = 29
        Me.CustomLabel4.Text = "Hasta Cuenta"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(168, 103)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(75, 13)
        Me.CustomLabel3.TabIndex = 28
        Me.CustomLabel3.Text = "Desde Cuenta"
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(331, 251)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 36
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(197, 251)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 35
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = -1
        Me.CustomLabel5.Location = New System.Drawing.Point(168, 173)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(65, 13)
        Me.CustomLabel5.TabIndex = 34
        Me.CustomLabel5.Text = "Tipo Listado"
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(399, 293)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(120, 37)
        Me.btnConsulta.TabIndex = 41
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(251, 293)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(125, 37)
        Me.btnCancela.TabIndex = 40
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Location = New System.Drawing.Point(101, 293)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(125, 37)
        Me.btnAcepta.TabIndex = 39
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(99, 346)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 43
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(99, 372)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 160)
        Me.lstAyuda.TabIndex = 42
        Me.lstAyuda.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDepositos)
        Me.GroupBox1.Controls.Add(Me.chkRecibos)
        Me.GroupBox1.Controls.Add(Me.chkPagos)
        Me.GroupBox1.Location = New System.Drawing.Point(101, 189)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 45)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        '
        'chkPagos
        '
        Me.chkPagos.AutoSize = True
        Me.chkPagos.Location = New System.Drawing.Point(27, 17)
        Me.chkPagos.Name = "chkPagos"
        Me.chkPagos.Size = New System.Drawing.Size(56, 17)
        Me.chkPagos.TabIndex = 0
        Me.chkPagos.Text = "Pagos"
        Me.chkPagos.UseVisualStyleBackColor = True
        '
        'chkRecibos
        '
        Me.chkRecibos.AutoSize = True
        Me.chkRecibos.Location = New System.Drawing.Point(151, 16)
        Me.chkRecibos.Name = "chkRecibos"
        Me.chkRecibos.Size = New System.Drawing.Size(65, 17)
        Me.chkRecibos.TabIndex = 1
        Me.chkRecibos.Text = "Recibos"
        Me.chkRecibos.UseVisualStyleBackColor = True
        '
        'chkDepositos
        '
        Me.chkDepositos.AutoSize = True
        Me.chkDepositos.Location = New System.Drawing.Point(288, 16)
        Me.chkDepositos.Name = "chkDepositos"
        Me.chkDepositos.Size = New System.Drawing.Size(73, 17)
        Me.chkDepositos.TabIndex = 2
        Me.chkDepositos.Text = "Depositos"
        Me.chkDepositos.UseVisualStyleBackColor = True
        '
        'txtDesdeCuenta
        '
        Me.txtDesdeCuenta.Location = New System.Drawing.Point(302, 105)
        Me.txtDesdeCuenta.Name = "txtDesdeCuenta"
        Me.txtDesdeCuenta.Size = New System.Drawing.Size(141, 20)
        Me.txtDesdeCuenta.TabIndex = 45
        '
        'txtHastaCuenta
        '
        Me.txtHastaCuenta.Location = New System.Drawing.Point(302, 136)
        Me.txtHastaCuenta.Name = "txtHastaCuenta"
        Me.txtHastaCuenta.Size = New System.Drawing.Size(141, 20)
        Me.txtHastaCuenta.TabIndex = 46
        '
        'TipoListado
        '
        Me.TipoListado.FormattingEnabled = True
        Me.TipoListado.Location = New System.Drawing.Point(302, 165)
        Me.TipoListado.Name = "TipoListado"
        Me.TipoListado.Size = New System.Drawing.Size(148, 21)
        Me.TipoListado.TabIndex = 47
        '
        'ListadoImputacionesContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 336)
        Me.Controls.Add(Me.TipoListado)
        Me.Controls.Add(Me.txtHastaCuenta)
        Me.Controls.Add(Me.txtDesdeCuenta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.opcImpesora)
        Me.Controls.Add(Me.opcPantalla)
        Me.Controls.Add(Me.CustomLabel5)
        Me.Controls.Add(Me.CustomLabel4)
        Me.Controls.Add(Me.CustomLabel3)
        Me.Controls.Add(Me.txthastafecha)
        Me.Controls.Add(Me.txtDesdeFecha)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ListadoImputacionesContable"
        Me.Text = "Listado de Imputaciones Contables"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents CustomLabel5 As WindowsApplication1.CustomLabel
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDepositos As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecibos As System.Windows.Forms.CheckBox
    Friend WithEvents chkPagos As System.Windows.Forms.CheckBox
    Friend WithEvents txtDesdeCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtHastaCuenta As System.Windows.Forms.TextBox
    Friend WithEvents TipoListado As System.Windows.Forms.ComboBox
End Class
