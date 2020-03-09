<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoValoresEnCartera
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecha4 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha3 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtHastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbTipoCheques = New System.Windows.Forms.ComboBox()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.txtRazonSocial = New Administracion.CustomTextBox()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.txtCliente = New Administracion.CustomTextBox()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.btnPantalla = New Administracion.CustomButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(27, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 114)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETROS DE FECHA"
        '
        'txtFecha4
        '
        Me.txtFecha4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha4.Location = New System.Drawing.Point(299, 70)
        Me.txtFecha4.Mask = "##/##/####"
        Me.txtFecha4.Name = "txtFecha4"
        Me.txtFecha4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha4.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha4.TabIndex = 3
        '
        'txtFecha3
        '
        Me.txtFecha3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha3.Location = New System.Drawing.Point(299, 35)
        Me.txtFecha3.Mask = "##/##/####"
        Me.txtFecha3.Name = "txtFecha3"
        Me.txtFecha3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha3.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha3.TabIndex = 2
        '
        'txtFecha2
        '
        Me.txtFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha2.Location = New System.Drawing.Point(103, 70)
        Me.txtFecha2.Mask = "##/##/####"
        Me.txtFecha2.Name = "txtFecha2"
        Me.txtFecha2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha2.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha2.TabIndex = 1
        '
        'txtFecha1
        '
        Me.txtFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha1.Location = New System.Drawing.Point(103, 35)
        Me.txtFecha1.Mask = "##/##/####"
        Me.txtFecha1.Name = "txtFecha1"
        Me.txtFecha1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha1.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha1.TabIndex = 0
        '
        'txtHastaFecha
        '
        Me.txtHastaFecha.Location = New System.Drawing.Point(344, 159)
        Me.txtHastaFecha.Mask = "##/##/####"
        Me.txtHastaFecha.Name = "txtHastaFecha"
        Me.txtHastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHastaFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtHastaFecha.TabIndex = 5
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Location = New System.Drawing.Point(148, 159)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtDesdeFecha.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 50)
        Me.Panel1.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(326, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Valores En Cartera"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cbTipoCheques)
        Me.Panel2.Controls.Add(Me.txtRazonSocial)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.txtDesdeFecha)
        Me.Panel2.Controls.Add(Me.txtHastaFecha)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Location = New System.Drawing.Point(-1, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(495, 256)
        Me.Panel2.TabIndex = 49
        '
        'cbTipoCheques
        '
        Me.cbTipoCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoCheques.FormattingEnabled = True
        Me.cbTipoCheques.Items.AddRange(New Object() {"Cheques Fisicos", "Cheques Electronicos"})
        Me.cbTipoCheques.Location = New System.Drawing.Point(148, 222)
        Me.cbTipoCheques.Name = "cbTipoCheques"
        Me.cbTipoCheques.Size = New System.Drawing.Size(192, 21)
        Me.cbTipoCheques.TabIndex = 51
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(38, 398)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(417, 147)
        Me.lstFiltrada.TabIndex = 50
        Me.lstFiltrada.Visible = False
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRazonSocial.Cleanable = False
        Me.txtRazonSocial.Empty = True
        Me.txtRazonSocial.EnterIndex = -1
        Me.txtRazonSocial.LabelAssociationKey = -1
        Me.txtRazonSocial.Location = New System.Drawing.Point(260, 195)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(190, 20)
        Me.txtRazonSocial.TabIndex = 50
        Me.txtRazonSocial.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = -1
        Me.CustomLabel6.Location = New System.Drawing.Point(234, 73)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(54, 18)
        Me.CustomLabel6.TabIndex = 28
        Me.CustomLabel6.Text = "Fecha 4"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = -1
        Me.CustomLabel5.Location = New System.Drawing.Point(234, 38)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(54, 18)
        Me.CustomLabel5.TabIndex = 27
        Me.CustomLabel5.Text = "Fecha 3"
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Location = New System.Drawing.Point(40, 73)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(54, 18)
        Me.CustomLabel4.TabIndex = 26
        Me.CustomLabel4.Text = "Fecha 2"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Location = New System.Drawing.Point(40, 38)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(54, 18)
        Me.CustomLabel3.TabIndex = 25
        Me.CustomLabel3.Text = "Fecha 1"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(51, 160)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(86, 18)
        Me.CustomLabel1.TabIndex = 34
        Me.CustomLabel1.Text = "Desde Fecha"
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(259, 160)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(81, 18)
        Me.CustomLabel2.TabIndex = 35
        Me.CustomLabel2.Text = "Hasta Fecha"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = -1
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(85, 196)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(53, 18)
        Me.CustomLabel7.TabIndex = 38
        Me.CustomLabel7.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Cleanable = False
        Me.txtCliente.Empty = True
        Me.txtCliente.EnterIndex = -1
        Me.txtCliente.LabelAssociationKey = -1
        Me.txtCliente.Location = New System.Drawing.Point(148, 195)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(106, 20)
        Me.txtCliente.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Doble Click: Abrir Consulta de Clientes")
        Me.txtCliente.Validator = Administracion.ValidatorType.None
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(38, 398)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(417, 147)
        Me.lstAyuda.TabIndex = 47
        Me.lstAyuda.Visible = False
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(373, 318)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(67, 40)
        Me.btnConsulta.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta de Clientes")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(38, 372)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(417, 20)
        Me.txtAyuda.TabIndex = 45
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'btnCancela
        '
        Me.btnCancela.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cleanable = False
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(266, 318)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(67, 40)
        Me.btnCancela.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImprimir.Cleanable = False
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.EnterIndex = -1
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.LabelAssociationKey = -1
        Me.btnImprimir.Location = New System.Drawing.Point(159, 318)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(67, 41)
        Me.btnImprimir.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Reporte")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.BackgroundImage = Global.Administracion.My.Resources.Resources.Screen_preview
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.Cleanable = False
        Me.btnPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPantalla.EnterIndex = -1
        Me.btnPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.LabelAssociationKey = -1
        Me.btnPantalla.Location = New System.Drawing.Point(52, 317)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(67, 41)
        Me.btnPantalla.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Mostrar Reporte")
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'ListadoValoresEnCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 368)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnPantalla)
        Me.Name = "ListadoValoresEnCartera"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtFecha4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecha1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtCliente As Administracion.CustomTextBox
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents btnPantalla As Administracion.CustomButton
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtRazonSocial As Administracion.CustomTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents btnImprimir As Administracion.CustomButton
    Friend WithEvents cbTipoCheques As System.Windows.Forms.ComboBox
End Class
