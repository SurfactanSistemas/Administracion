<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoGraficoAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoGraficoAnual))
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.P_Buscar = New System.Windows.Forms.Panel()
        Me.txtAnoII = New System.Windows.Forms.TextBox()
        Me.ImpreAnoII = New System.Windows.Forms.Label()
        Me.TipoListadoII = New Esta.CustomComboBox()
        Me.txtAno = New System.Windows.Forms.TextBox()
        Me.TipoCosto = New Esta.CustomComboBox()
        Me.sfsdfsdf = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TipoListado = New Esta.CustomComboBox()
        Me.ImpreAno = New System.Windows.Forms.Label()
        Me.LBErrorFecha = New System.Windows.Forms.Label()
        Me.LBError = New System.Windows.Forms.Label()
        Me.PantaDatos = New System.Windows.Forms.GroupBox()
        Me.txtTerminadoFiltro = New System.Windows.Forms.MaskedTextBox()
        Me.btnConsultaTerminado = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DesTerminado = New System.Windows.Forms.Label()
        Me.btnConsultaRubro = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DesRubro = New System.Windows.Forms.Label()
        Me.txtRubroFiltro = New System.Windows.Forms.TextBox()
        Me.btnConsultaLinea = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DesLinea = New System.Windows.Forms.Label()
        Me.txtLineaFiltro = New System.Windows.Forms.TextBox()
        Me.btnConsultaVendedor = New System.Windows.Forms.Button()
        Me.btnConsultaCliente = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DesVendedor = New System.Windows.Forms.Label()
        Me.DesCliente = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtClienteFiltro = New System.Windows.Forms.TextBox()
        Me.txtVendedorFiltro = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnImpresora = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAyuda = New Esta.CustomTextBox()
        Me.lstAyuda = New Esta.CustomListBox()
        Me.panel1.SuspendLayout()
        Me.P_Buscar.SuspendLayout()
        Me.PantaDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(694, 31)
        Me.panel1.TabIndex = 89
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(3, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(142, 19)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Emision de Graficos"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(412, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(156, 26)
        Me.label3.TabIndex = 0
        Me.label3.Text = "SURFACTAN S.A."
        '
        'P_Buscar
        '
        Me.P_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.P_Buscar.Controls.Add(Me.txtAnoII)
        Me.P_Buscar.Controls.Add(Me.ImpreAnoII)
        Me.P_Buscar.Controls.Add(Me.TipoListadoII)
        Me.P_Buscar.Controls.Add(Me.txtAno)
        Me.P_Buscar.Controls.Add(Me.TipoCosto)
        Me.P_Buscar.Controls.Add(Me.sfsdfsdf)
        Me.P_Buscar.Controls.Add(Me.Label6)
        Me.P_Buscar.Controls.Add(Me.TipoListado)
        Me.P_Buscar.Controls.Add(Me.ImpreAno)
        Me.P_Buscar.Controls.Add(Me.LBErrorFecha)
        Me.P_Buscar.Controls.Add(Me.LBError)
        Me.P_Buscar.Location = New System.Drawing.Point(0, 30)
        Me.P_Buscar.Name = "P_Buscar"
        Me.P_Buscar.Size = New System.Drawing.Size(697, 84)
        Me.P_Buscar.TabIndex = 90
        '
        'txtAnoII
        '
        Me.txtAnoII.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnoII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnoII.Location = New System.Drawing.Point(123, 44)
        Me.txtAnoII.MaxLength = 4
        Me.txtAnoII.Name = "txtAnoII"
        Me.txtAnoII.Size = New System.Drawing.Size(74, 20)
        Me.txtAnoII.TabIndex = 93
        Me.txtAnoII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAnoII.Visible = False
        '
        'ImpreAnoII
        '
        Me.ImpreAnoII.AutoSize = True
        Me.ImpreAnoII.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ImpreAnoII.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ImpreAnoII.Location = New System.Drawing.Point(12, 46)
        Me.ImpreAnoII.Name = "ImpreAnoII"
        Me.ImpreAnoII.Size = New System.Drawing.Size(33, 18)
        Me.ImpreAnoII.TabIndex = 92
        Me.ImpreAnoII.Text = "Año"
        Me.ImpreAnoII.Visible = False
        '
        'TipoListadoII
        '
        Me.TipoListadoII.Cleanable = False
        Me.TipoListadoII.Empty = False
        Me.TipoListadoII.EnterIndex = -1
        Me.TipoListadoII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoListadoII.FormattingEnabled = True
        Me.TipoListadoII.LabelAssociationKey = -1
        Me.TipoListadoII.Location = New System.Drawing.Point(203, 15)
        Me.TipoListadoII.Name = "TipoListadoII"
        Me.TipoListadoII.Size = New System.Drawing.Size(134, 21)
        Me.TipoListadoII.TabIndex = 91
        Me.TipoListadoII.Validator = Esta.ValidatorType.None
        '
        'txtAno
        '
        Me.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAno.Location = New System.Drawing.Point(123, 15)
        Me.txtAno.MaxLength = 4
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(74, 20)
        Me.txtAno.TabIndex = 90
        Me.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TipoCosto
        '
        Me.TipoCosto.Cleanable = False
        Me.TipoCosto.Empty = False
        Me.TipoCosto.EnterIndex = -1
        Me.TipoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoCosto.FormattingEnabled = True
        Me.TipoCosto.LabelAssociationKey = -1
        Me.TipoCosto.Location = New System.Drawing.Point(499, 44)
        Me.TipoCosto.Name = "TipoCosto"
        Me.TipoCosto.Size = New System.Drawing.Size(151, 21)
        Me.TipoCosto.TabIndex = 87
        Me.TipoCosto.Validator = Esta.ValidatorType.None
        '
        'sfsdfsdf
        '
        Me.sfsdfsdf.AutoSize = True
        Me.sfsdfsdf.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.sfsdfsdf.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.sfsdfsdf.Location = New System.Drawing.Point(387, 44)
        Me.sfsdfsdf.Name = "sfsdfsdf"
        Me.sfsdfsdf.Size = New System.Drawing.Size(92, 18)
        Me.sfsdfsdf.TabIndex = 86
        Me.sfsdfsdf.Text = "Tipo de Costo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(387, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 18)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Tipo de Listado"
        '
        'TipoListado
        '
        Me.TipoListado.Cleanable = False
        Me.TipoListado.Empty = False
        Me.TipoListado.EnterIndex = -1
        Me.TipoListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoListado.FormattingEnabled = True
        Me.TipoListado.LabelAssociationKey = -1
        Me.TipoListado.Location = New System.Drawing.Point(499, 17)
        Me.TipoListado.Name = "TipoListado"
        Me.TipoListado.Size = New System.Drawing.Size(151, 21)
        Me.TipoListado.TabIndex = 84
        Me.TipoListado.Validator = Esta.ValidatorType.None
        '
        'ImpreAno
        '
        Me.ImpreAno.AutoSize = True
        Me.ImpreAno.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ImpreAno.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ImpreAno.Location = New System.Drawing.Point(12, 17)
        Me.ImpreAno.Name = "ImpreAno"
        Me.ImpreAno.Size = New System.Drawing.Size(33, 18)
        Me.ImpreAno.TabIndex = 62
        Me.ImpreAno.Text = "Año"
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
        'PantaDatos
        '
        Me.PantaDatos.Controls.Add(Me.txtTerminadoFiltro)
        Me.PantaDatos.Controls.Add(Me.btnConsultaTerminado)
        Me.PantaDatos.Controls.Add(Me.Label9)
        Me.PantaDatos.Controls.Add(Me.DesTerminado)
        Me.PantaDatos.Controls.Add(Me.btnConsultaRubro)
        Me.PantaDatos.Controls.Add(Me.Label10)
        Me.PantaDatos.Controls.Add(Me.DesRubro)
        Me.PantaDatos.Controls.Add(Me.txtRubroFiltro)
        Me.PantaDatos.Controls.Add(Me.btnConsultaLinea)
        Me.PantaDatos.Controls.Add(Me.Label5)
        Me.PantaDatos.Controls.Add(Me.DesLinea)
        Me.PantaDatos.Controls.Add(Me.txtLineaFiltro)
        Me.PantaDatos.Controls.Add(Me.btnConsultaVendedor)
        Me.PantaDatos.Controls.Add(Me.btnConsultaCliente)
        Me.PantaDatos.Controls.Add(Me.Label7)
        Me.PantaDatos.Controls.Add(Me.Label1)
        Me.PantaDatos.Controls.Add(Me.DesVendedor)
        Me.PantaDatos.Controls.Add(Me.DesCliente)
        Me.PantaDatos.Controls.Add(Me.Label8)
        Me.PantaDatos.Controls.Add(Me.txtClienteFiltro)
        Me.PantaDatos.Controls.Add(Me.txtVendedorFiltro)
        Me.PantaDatos.Location = New System.Drawing.Point(0, 120)
        Me.PantaDatos.Name = "PantaDatos"
        Me.PantaDatos.Size = New System.Drawing.Size(543, 185)
        Me.PantaDatos.TabIndex = 113
        Me.PantaDatos.TabStop = False
        '
        'txtTerminadoFiltro
        '
        Me.txtTerminadoFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerminadoFiltro.Location = New System.Drawing.Point(185, 136)
        Me.txtTerminadoFiltro.Mask = "AA-#####-###"
        Me.txtTerminadoFiltro.Name = "txtTerminadoFiltro"
        Me.txtTerminadoFiltro.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTerminadoFiltro.Size = New System.Drawing.Size(98, 20)
        Me.txtTerminadoFiltro.TabIndex = 110
        '
        'btnConsultaTerminado
        '
        Me.btnConsultaTerminado.AutoSize = True
        Me.btnConsultaTerminado.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaTerminado.BackgroundImage = CType(resources.GetObject("btnConsultaTerminado.BackgroundImage"), System.Drawing.Image)
        Me.btnConsultaTerminado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaTerminado.FlatAppearance.BorderSize = 0
        Me.btnConsultaTerminado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaTerminado.Location = New System.Drawing.Point(25, 132)
        Me.btnConsultaTerminado.Name = "btnConsultaTerminado"
        Me.btnConsultaTerminado.Size = New System.Drawing.Size(48, 22)
        Me.btnConsultaTerminado.TabIndex = 109
        Me.ToolTip1.SetToolTip(Me.btnConsultaTerminado, "Ayuda de Productos Terminados")
        Me.btnConsultaTerminado.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(82, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "P.Terminado"
        '
        'DesTerminado
        '
        Me.DesTerminado.AutoSize = True
        Me.DesTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesTerminado.Location = New System.Drawing.Point(304, 141)
        Me.DesTerminado.Name = "DesTerminado"
        Me.DesTerminado.Size = New System.Drawing.Size(71, 13)
        Me.DesTerminado.TabIndex = 108
        Me.DesTerminado.Text = "                "
        '
        'btnConsultaRubro
        '
        Me.btnConsultaRubro.AutoSize = True
        Me.btnConsultaRubro.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRubro.BackgroundImage = CType(resources.GetObject("btnConsultaRubro.BackgroundImage"), System.Drawing.Image)
        Me.btnConsultaRubro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaRubro.FlatAppearance.BorderSize = 0
        Me.btnConsultaRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaRubro.Location = New System.Drawing.Point(25, 106)
        Me.btnConsultaRubro.Name = "btnConsultaRubro"
        Me.btnConsultaRubro.Size = New System.Drawing.Size(48, 22)
        Me.btnConsultaRubro.TabIndex = 105
        Me.ToolTip1.SetToolTip(Me.btnConsultaRubro, "Ayuda de Rubros")
        Me.btnConsultaRubro.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(82, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Rubro"
        '
        'DesRubro
        '
        Me.DesRubro.AutoSize = True
        Me.DesRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesRubro.Location = New System.Drawing.Point(304, 110)
        Me.DesRubro.Name = "DesRubro"
        Me.DesRubro.Size = New System.Drawing.Size(71, 13)
        Me.DesRubro.TabIndex = 104
        Me.DesRubro.Text = "                "
        '
        'txtRubroFiltro
        '
        Me.txtRubroFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRubroFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRubroFiltro.Location = New System.Drawing.Point(185, 106)
        Me.txtRubroFiltro.MaxLength = 6
        Me.txtRubroFiltro.Name = "txtRubroFiltro"
        Me.txtRubroFiltro.Size = New System.Drawing.Size(74, 20)
        Me.txtRubroFiltro.TabIndex = 102
        Me.txtRubroFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnConsultaLinea
        '
        Me.btnConsultaLinea.AutoSize = True
        Me.btnConsultaLinea.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaLinea.BackgroundImage = CType(resources.GetObject("btnConsultaLinea.BackgroundImage"), System.Drawing.Image)
        Me.btnConsultaLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaLinea.FlatAppearance.BorderSize = 0
        Me.btnConsultaLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaLinea.Location = New System.Drawing.Point(25, 78)
        Me.btnConsultaLinea.Name = "btnConsultaLinea"
        Me.btnConsultaLinea.Size = New System.Drawing.Size(48, 22)
        Me.btnConsultaLinea.TabIndex = 101
        Me.ToolTip1.SetToolTip(Me.btnConsultaLinea, "Ayuda de Lineas")
        Me.btnConsultaLinea.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Linea"
        '
        'DesLinea
        '
        Me.DesLinea.AutoSize = True
        Me.DesLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesLinea.Location = New System.Drawing.Point(304, 83)
        Me.DesLinea.Name = "DesLinea"
        Me.DesLinea.Size = New System.Drawing.Size(71, 13)
        Me.DesLinea.TabIndex = 100
        Me.DesLinea.Text = "                "
        '
        'txtLineaFiltro
        '
        Me.txtLineaFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineaFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineaFiltro.Location = New System.Drawing.Point(185, 78)
        Me.txtLineaFiltro.MaxLength = 6
        Me.txtLineaFiltro.Name = "txtLineaFiltro"
        Me.txtLineaFiltro.Size = New System.Drawing.Size(74, 20)
        Me.txtLineaFiltro.TabIndex = 98
        Me.txtLineaFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnConsultaVendedor
        '
        Me.btnConsultaVendedor.AutoSize = True
        Me.btnConsultaVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaVendedor.BackgroundImage = CType(resources.GetObject("btnConsultaVendedor.BackgroundImage"), System.Drawing.Image)
        Me.btnConsultaVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaVendedor.FlatAppearance.BorderSize = 0
        Me.btnConsultaVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaVendedor.Location = New System.Drawing.Point(25, 25)
        Me.btnConsultaVendedor.Name = "btnConsultaVendedor"
        Me.btnConsultaVendedor.Size = New System.Drawing.Size(48, 23)
        Me.btnConsultaVendedor.TabIndex = 97
        Me.ToolTip1.SetToolTip(Me.btnConsultaVendedor, "Ayuda de Vendedores")
        Me.btnConsultaVendedor.UseVisualStyleBackColor = False
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
        Me.btnConsultaCliente.Location = New System.Drawing.Point(25, 54)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(48, 22)
        Me.btnConsultaCliente.TabIndex = 94
        Me.ToolTip1.SetToolTip(Me.btnConsultaCliente, "Ayuda de Clientes")
        Me.btnConsultaCliente.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(82, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Vendedor"
        '
        'DesVendedor
        '
        Me.DesVendedor.AutoSize = True
        Me.DesVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesVendedor.Location = New System.Drawing.Point(304, 28)
        Me.DesVendedor.Name = "DesVendedor"
        Me.DesVendedor.Size = New System.Drawing.Size(71, 13)
        Me.DesVendedor.TabIndex = 92
        Me.DesVendedor.Text = "                "
        '
        'DesCliente
        '
        Me.DesCliente.AutoSize = True
        Me.DesCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesCliente.Location = New System.Drawing.Point(304, 57)
        Me.DesCliente.Name = "DesCliente"
        Me.DesCliente.Size = New System.Drawing.Size(71, 13)
        Me.DesCliente.TabIndex = 91
        Me.DesCliente.Text = "                "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 90
        '
        'txtClienteFiltro
        '
        Me.txtClienteFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClienteFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteFiltro.Location = New System.Drawing.Point(185, 52)
        Me.txtClienteFiltro.MaxLength = 6
        Me.txtClienteFiltro.Name = "txtClienteFiltro"
        Me.txtClienteFiltro.Size = New System.Drawing.Size(74, 20)
        Me.txtClienteFiltro.TabIndex = 87
        '
        'txtVendedorFiltro
        '
        Me.txtVendedorFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendedorFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendedorFiltro.Location = New System.Drawing.Point(185, 23)
        Me.txtVendedorFiltro.MaxLength = 4
        Me.txtVendedorFiltro.Name = "txtVendedorFiltro"
        Me.txtVendedorFiltro.Size = New System.Drawing.Size(74, 20)
        Me.txtVendedorFiltro.TabIndex = 85
        Me.txtVendedorFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 323)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(526, 29)
        Me.ProgressBar1.TabIndex = 116
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
        Me.btnPantalla.Location = New System.Drawing.Point(99, 374)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(72, 72)
        Me.btnPantalla.TabIndex = 115
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Generacion del  Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = False
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
        Me.btnImpresora.Location = New System.Drawing.Point(262, 373)
        Me.btnImpresora.Name = "btnImpresora"
        Me.btnImpresora.Size = New System.Drawing.Size(72, 72)
        Me.btnImpresora.TabIndex = 114
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
        Me.btnCancela.Location = New System.Drawing.Point(432, 373)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(72, 73)
        Me.btnCancela.TabIndex = 117
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
        Me.txtAyuda.Location = New System.Drawing.Point(10, 474)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(527, 20)
        Me.txtAyuda.TabIndex = 119
        Me.txtAyuda.Validator = Esta.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(10, 500)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(525, 147)
        Me.lstAyuda.TabIndex = 118
        Me.lstAyuda.Visible = False
        '
        'ListadoGraficoAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 656)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnImpresora)
        Me.Controls.Add(Me.PantaDatos)
        Me.Controls.Add(Me.P_Buscar)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ListadoGraficoAnual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.P_Buscar.ResumeLayout(False)
        Me.P_Buscar.PerformLayout()
        Me.PantaDatos.ResumeLayout(False)
        Me.PantaDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents P_Buscar As System.Windows.Forms.Panel
    Friend WithEvents TipoCosto As Esta.CustomComboBox
    Private WithEvents sfsdfsdf As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TipoListado As Esta.CustomComboBox
    Private WithEvents ImpreAno As System.Windows.Forms.Label
    Private WithEvents LBErrorFecha As System.Windows.Forms.Label
    Private WithEvents LBError As System.Windows.Forms.Label
    Friend WithEvents PantaDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultaRubro As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DesRubro As System.Windows.Forms.Label
    Friend WithEvents txtRubroFiltro As System.Windows.Forms.TextBox
    Friend WithEvents btnConsultaLinea As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DesLinea As System.Windows.Forms.Label
    Friend WithEvents txtLineaFiltro As System.Windows.Forms.TextBox
    Friend WithEvents btnConsultaVendedor As System.Windows.Forms.Button
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DesVendedor As System.Windows.Forms.Label
    Friend WithEvents DesCliente As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtClienteFiltro As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedorFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnImpresora As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents txtAyuda As Esta.CustomTextBox
    Friend WithEvents lstAyuda As Esta.CustomListBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents btnConsultaTerminado As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DesTerminado As System.Windows.Forms.Label
    Friend WithEvents txtTerminadoFiltro As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TipoListadoII As Esta.CustomComboBox
    Friend WithEvents txtAnoII As System.Windows.Forms.TextBox
    Private WithEvents ImpreAnoII As System.Windows.Forms.Label
End Class
