<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoProyeccionCobros
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
        Me.btnConsulta = New WindowsApplication1.CustomButton()
        Me.btnCancela = New WindowsApplication1.CustomButton()
        Me.btnAcepta = New WindowsApplication1.CustomButton()
        Me.opcImpesora = New System.Windows.Forms.RadioButton()
        Me.opcPantalla = New System.Windows.Forms.RadioButton()
        Me.txtHastaProveedor = New WindowsApplication1.CustomTextBox()
        Me.txtDesdeProveedor = New WindowsApplication1.CustomTextBox()
        Me.CustomLabel2 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel1 = New WindowsApplication1.CustomLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CustomLabel6 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel5 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel4 = New WindowsApplication1.CustomLabel()
        Me.CustomLabel3 = New WindowsApplication1.CustomLabel()
        Me.txtFecha4 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha3 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.lstAyuda = New WindowsApplication1.CustomListBox()
        Me.txtAyuda = New WindowsApplication1.CustomTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConsulta
        '
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(312, 259)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(120, 40)
        Me.btnConsulta.TabIndex = 31
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Cleanable = False
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(170, 259)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(120, 40)
        Me.btnCancela.TabIndex = 30
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.Cleanable = False
        Me.btnAcepta.EnterIndex = -1
        Me.btnAcepta.LabelAssociationKey = -1
        Me.btnAcepta.Location = New System.Drawing.Point(19, 258)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(120, 41)
        Me.btnAcepta.TabIndex = 29
        Me.btnAcepta.Text = "Acepta"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'opcImpesora
        '
        Me.opcImpesora.AutoSize = True
        Me.opcImpesora.Location = New System.Drawing.Point(262, 221)
        Me.opcImpesora.Name = "opcImpesora"
        Me.opcImpesora.Size = New System.Drawing.Size(71, 17)
        Me.opcImpesora.TabIndex = 28
        Me.opcImpesora.TabStop = True
        Me.opcImpesora.Text = "Impresora"
        Me.opcImpesora.UseVisualStyleBackColor = True
        '
        'opcPantalla
        '
        Me.opcPantalla.AutoSize = True
        Me.opcPantalla.Location = New System.Drawing.Point(128, 221)
        Me.opcPantalla.Name = "opcPantalla"
        Me.opcPantalla.Size = New System.Drawing.Size(63, 17)
        Me.opcPantalla.TabIndex = 27
        Me.opcPantalla.TabStop = True
        Me.opcPantalla.Text = "Pantalla"
        Me.opcPantalla.UseVisualStyleBackColor = True
        '
        'txtHastaProveedor
        '
        Me.txtHastaProveedor.Cleanable = False
        Me.txtHastaProveedor.Empty = True
        Me.txtHastaProveedor.EnterIndex = -1
        Me.txtHastaProveedor.LabelAssociationKey = -1
        Me.txtHastaProveedor.Location = New System.Drawing.Point(214, 60)
        Me.txtHastaProveedor.Name = "txtHastaProveedor"
        Me.txtHastaProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtHastaProveedor.TabIndex = 1
        Me.txtHastaProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(214, 22)
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 0
        Me.txtDesdeProveedor.Validator = WindowsApplication1.ValidatorType.None
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Location = New System.Drawing.Point(77, 63)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(87, 13)
        Me.CustomLabel2.TabIndex = 24
        Me.CustomLabel2.Text = "Hasta Proveedor"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Location = New System.Drawing.Point(77, 25)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(90, 13)
        Me.CustomLabel1.TabIndex = 23
        Me.CustomLabel1.Text = "Desde Proveedor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CustomLabel6)
        Me.GroupBox1.Controls.Add(Me.CustomLabel5)
        Me.GroupBox1.Controls.Add(Me.CustomLabel4)
        Me.GroupBox1.Controls.Add(Me.CustomLabel3)
        Me.GroupBox1.Controls.Add(Me.txtFecha4)
        Me.GroupBox1.Controls.Add(Me.txtFecha3)
        Me.GroupBox1.Controls.Add(Me.txtFecha2)
        Me.GroupBox1.Controls.Add(Me.txtFecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 108)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETROS DE FECHA"
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = -1
        Me.CustomLabel6.Location = New System.Drawing.Point(208, 68)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(46, 13)
        Me.CustomLabel6.TabIndex = 28
        Me.CustomLabel6.Text = "Fecha 4"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = -1
        Me.CustomLabel5.Location = New System.Drawing.Point(208, 33)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(46, 13)
        Me.CustomLabel5.TabIndex = 27
        Me.CustomLabel5.Text = "Fecha 3"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(6, 68)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(46, 13)
        Me.CustomLabel4.TabIndex = 26
        Me.CustomLabel4.Text = "Fecha 2"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(6, 33)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(46, 13)
        Me.CustomLabel3.TabIndex = 25
        Me.CustomLabel3.Text = "Fecha 1"
        '
        'txtFecha4
        '
        Me.txtFecha4.Location = New System.Drawing.Point(315, 65)
        Me.txtFecha4.Mask = "##/##/####"
        Me.txtFecha4.Name = "txtFecha4"
        Me.txtFecha4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha4.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha4.TabIndex = 5
        '
        'txtFecha3
        '
        Me.txtFecha3.Location = New System.Drawing.Point(315, 30)
        Me.txtFecha3.Mask = "##/##/####"
        Me.txtFecha3.Name = "txtFecha3"
        Me.txtFecha3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha3.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha3.TabIndex = 4
        '
        'txtFecha2
        '
        Me.txtFecha2.Location = New System.Drawing.Point(92, 65)
        Me.txtFecha2.Mask = "##/##/####"
        Me.txtFecha2.Name = "txtFecha2"
        Me.txtFecha2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha2.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha2.TabIndex = 3
        '
        'txtFecha1
        '
        Me.txtFecha1.Location = New System.Drawing.Point(92, 30)
        Me.txtFecha1.Mask = "##/##/####"
        Me.txtFecha1.Name = "txtFecha1"
        Me.txtFecha1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha1.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha1.TabIndex = 2
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(12, 338)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 34
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(12, 312)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 33
        Me.txtAyuda.Validator = WindowsApplication1.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'ListadoProyeccionCobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 303)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.opcImpesora)
        Me.Controls.Add(Me.opcPantalla)
        Me.Controls.Add(Me.txtHastaProveedor)
        Me.Controls.Add(Me.txtDesdeProveedor)
        Me.Controls.Add(Me.CustomLabel2)
        Me.Controls.Add(Me.CustomLabel1)
        Me.Name = "ListadoProyeccionCobros"
        Me.Text = "Listado de Proyeccion de Cobros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConsulta As WindowsApplication1.CustomButton
    Friend WithEvents btnCancela As WindowsApplication1.CustomButton
    Friend WithEvents btnAcepta As WindowsApplication1.CustomButton
    Friend WithEvents opcImpesora As System.Windows.Forms.RadioButton
    Friend WithEvents opcPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents txtHastaProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents txtDesdeProveedor As WindowsApplication1.CustomTextBox
    Friend WithEvents CustomLabel2 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel1 As WindowsApplication1.CustomLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CustomLabel6 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel5 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel4 As WindowsApplication1.CustomLabel
    Friend WithEvents CustomLabel3 As WindowsApplication1.CustomLabel
    Friend WithEvents txtFecha4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lstAyuda As WindowsApplication1.CustomListBox
    Friend WithEvents txtAyuda As WindowsApplication1.CustomTextBox
End Class
