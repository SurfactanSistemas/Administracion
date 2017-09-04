<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoEstaInterAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoEstaInterAnual))
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.P_Buscar = New System.Windows.Forms.Panel()
        Me.btnConsultaCliente = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DesCliente = New System.Windows.Forms.Label()
        Me.txtClienteFiltro = New System.Windows.Forms.TextBox()
        Me.txtDesdeTerminado = New System.Windows.Forms.MaskedTextBox()
        Me.txtHastaTerminado = New System.Windows.Forms.MaskedTextBox()
        Me.TipoListado = New Esta.CustomComboBox()
        Me.txthastafecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBErrorFecha = New System.Windows.Forms.Label()
        Me.LBError = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lstAyuda = New Esta.CustomListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnImpresora = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.txtAyuda = New Esta.CustomTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstFiltrada = New Esta.CustomListBox()
        Me.panel1.SuspendLayout()
        Me.P_Buscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(609, 33)
        Me.panel1.TabIndex = 98
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(3, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(323, 19)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Listado de Estadistica Comparativa entre Años"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(415, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(156, 26)
        Me.label3.TabIndex = 0
        Me.label3.Text = "SURFACTAN S.A."
        '
        'P_Buscar
        '
        Me.P_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.P_Buscar.Controls.Add(Me.btnConsultaCliente)
        Me.P_Buscar.Controls.Add(Me.Label7)
        Me.P_Buscar.Controls.Add(Me.DesCliente)
        Me.P_Buscar.Controls.Add(Me.txtClienteFiltro)
        Me.P_Buscar.Controls.Add(Me.txtDesdeTerminado)
        Me.P_Buscar.Controls.Add(Me.txtHastaTerminado)
        Me.P_Buscar.Controls.Add(Me.TipoListado)
        Me.P_Buscar.Controls.Add(Me.txthastafecha)
        Me.P_Buscar.Controls.Add(Me.txtDesdeFecha)
        Me.P_Buscar.Controls.Add(Me.Label5)
        Me.P_Buscar.Controls.Add(Me.Label2)
        Me.P_Buscar.Controls.Add(Me.LBErrorFecha)
        Me.P_Buscar.Controls.Add(Me.LBError)
        Me.P_Buscar.Controls.Add(Me.label1)
        Me.P_Buscar.Location = New System.Drawing.Point(0, 30)
        Me.P_Buscar.Name = "P_Buscar"
        Me.P_Buscar.Size = New System.Drawing.Size(612, 78)
        Me.P_Buscar.TabIndex = 99
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.AutoSize = True
        Me.btnConsultaCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaCliente.BackgroundImage = CType(resources.GetObject("btnConsultaCliente.BackgroundImage"), System.Drawing.Image)
        Me.btnConsultaCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaCliente.FlatAppearance.BorderSize = 0
        Me.btnConsultaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaCliente.Location = New System.Drawing.Point(282, 43)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(35, 23)
        Me.btnConsultaCliente.TabIndex = 95
        Me.btnConsultaCliente.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(323, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Cliente"
        '
        'DesCliente
        '
        Me.DesCliente.AutoSize = True
        Me.DesCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesCliente.Location = New System.Drawing.Point(485, 46)
        Me.DesCliente.Name = "DesCliente"
        Me.DesCliente.Size = New System.Drawing.Size(68, 13)
        Me.DesCliente.TabIndex = 94
        Me.DesCliente.Text = "DesCliente"
        '
        'txtClienteFiltro
        '
        Me.txtClienteFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClienteFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteFiltro.Location = New System.Drawing.Point(384, 43)
        Me.txtClienteFiltro.MaxLength = 6
        Me.txtClienteFiltro.Name = "txtClienteFiltro"
        Me.txtClienteFiltro.Size = New System.Drawing.Size(74, 20)
        Me.txtClienteFiltro.TabIndex = 92
        '
        'txtDesdeTerminado
        '
        Me.txtDesdeTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeTerminado.Location = New System.Drawing.Point(110, 14)
        Me.txtDesdeTerminado.Mask = "AA-#####-###"
        Me.txtDesdeTerminado.Name = "txtDesdeTerminado"
        Me.txtDesdeTerminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeTerminado.Size = New System.Drawing.Size(98, 20)
        Me.txtDesdeTerminado.TabIndex = 78
        '
        'txtHastaTerminado
        '
        Me.txtHastaTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHastaTerminado.Location = New System.Drawing.Point(214, 14)
        Me.txtHastaTerminado.Mask = "AA-#####-###"
        Me.txtHastaTerminado.Name = "txtHastaTerminado"
        Me.txtHastaTerminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHastaTerminado.Size = New System.Drawing.Size(95, 20)
        Me.txtHastaTerminado.TabIndex = 77
        '
        'TipoListado
        '
        Me.TipoListado.Cleanable = False
        Me.TipoListado.Empty = False
        Me.TipoListado.EnterIndex = -1
        Me.TipoListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoListado.FormattingEnabled = True
        Me.TipoListado.LabelAssociationKey = -1
        Me.TipoListado.Location = New System.Drawing.Point(110, 43)
        Me.TipoListado.Name = "TipoListado"
        Me.TipoListado.Size = New System.Drawing.Size(151, 21)
        Me.TipoListado.TabIndex = 75
        Me.TipoListado.Validator = Esta.ValidatorType.None
        '
        'txthastafecha
        '
        Me.txthastafecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthastafecha.Location = New System.Drawing.Point(488, 14)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(95, 20)
        Me.txthastafecha.TabIndex = 4
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeFecha.Location = New System.Drawing.Point(384, 14)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtDesdeFecha.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 18)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Tipo de Listado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(323, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Fecha"
        '
        'LBErrorFecha
        '
        Me.LBErrorFecha.AutoSize = True
        Me.LBErrorFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.LBErrorFecha.Location = New System.Drawing.Point(12, 39)
        Me.LBErrorFecha.Name = "LBErrorFecha"
        Me.LBErrorFecha.Size = New System.Drawing.Size(11, 13)
        Me.LBErrorFecha.TabIndex = 10
        Me.LBErrorFecha.Text = "*"
        '
        'LBError
        '
        Me.LBError.AutoSize = True
        Me.LBError.Location = New System.Drawing.Point(73, 56)
        Me.LBError.Name = "LBError"
        Me.LBError.Size = New System.Drawing.Size(0, 13)
        Me.LBError.TabIndex = 9
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.label1.Location = New System.Drawing.Point(13, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 18)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Producto"
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(39, 280)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(527, 134)
        Me.lstAyuda.TabIndex = 105
        Me.lstAyuda.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(39, 206)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(526, 29)
        Me.ProgressBar1.TabIndex = 104
        Me.ProgressBar1.Visible = False
        '
        'btnPantalla
        '
        Me.btnPantalla.AutoSize = True
        Me.btnPantalla.BackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.BackgroundImage = CType(resources.GetObject("btnPantalla.BackgroundImage"), System.Drawing.Image)
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPantalla.Location = New System.Drawing.Point(188, 125)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(72, 72)
        Me.btnPantalla.TabIndex = 103
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Generacion del  Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = False
        '
        'btnConsulta
        '
        Me.btnConsulta.AutoSize = True
        Me.btnConsulta.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.BackgroundImage = CType(resources.GetObject("btnConsulta.BackgroundImage"), System.Drawing.Image)
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.Location = New System.Drawing.Point(61, 125)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(72, 72)
        Me.btnConsulta.TabIndex = 102
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Ayuda de Producto Terminado")
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'btnImpresora
        '
        Me.btnImpresora.AutoSize = True
        Me.btnImpresora.BackColor = System.Drawing.SystemColors.Control
        Me.btnImpresora.BackgroundImage = Global.Esta.My.Resources.Resources.imprimir
        Me.btnImpresora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImpresora.FlatAppearance.BorderSize = 0
        Me.btnImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpresora.Location = New System.Drawing.Point(315, 126)
        Me.btnImpresora.Name = "btnImpresora"
        Me.btnImpresora.Size = New System.Drawing.Size(72, 72)
        Me.btnImpresora.TabIndex = 100
        Me.ToolTip1.SetToolTip(Me.btnImpresora, "Generacion del  Reporte por Impresora")
        Me.btnImpresora.UseVisualStyleBackColor = False
        '
        'btnCancela
        '
        Me.btnCancela.AutoSize = True
        Me.btnCancela.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.BackgroundImage = Global.Esta.My.Resources.Resources.Salir1
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancela.Location = New System.Drawing.Point(453, 125)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(72, 73)
        Me.btnCancela.TabIndex = 101
        Me.btnCancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Menu Principal")
        Me.btnCancela.UseVisualStyleBackColor = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(39, 254)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(527, 20)
        Me.txtAyuda.TabIndex = 114
        Me.txtAyuda.Validator = Esta.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(39, 280)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(527, 134)
        Me.lstFiltrada.TabIndex = 115
        Me.lstFiltrada.Visible = False
        '
        'ListadoEstaInterAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 243)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnImpresora)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.P_Buscar)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ListadoEstaInterAnual"
        Me.Text = "ListadoEstaInterAnual"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.P_Buscar.ResumeLayout(False)
        Me.P_Buscar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents P_Buscar As System.Windows.Forms.Panel
    Friend WithEvents txtDesdeTerminado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHastaTerminado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TipoListado As Esta.CustomComboBox
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents LBErrorFecha As System.Windows.Forms.Label
    Private WithEvents LBError As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DesCliente As System.Windows.Forms.Label
    Friend WithEvents txtClienteFiltro As System.Windows.Forms.TextBox
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.Button
    Friend WithEvents lstAyuda As Esta.CustomListBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnImpresora As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents txtAyuda As Esta.CustomTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Esta.CustomListBox
End Class
