<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoDatosAdicMP
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreArticulo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxPalabraAdvertencia = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cbxMedioAmbiente9 = New System.Windows.Forms.ComboBox()
        Me.cbxPeligroPLASalud8 = New System.Windows.Forms.ComboBox()
        Me.cbxPeligro7 = New System.Windows.Forms.ComboBox()
        Me.cbxToxico6 = New System.Windows.Forms.ComboBox()
        Me.cbxCorrosivo5 = New System.Windows.Forms.ComboBox()
        Me.cbxGasesBajo4 = New System.Windows.Forms.ComboBox()
        Me.cbxCarburante3 = New System.Windows.Forms.ComboBox()
        Me.cbxInflamable2 = New System.Windows.Forms.ComboBox()
        Me.cbxExplosivo1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DGV_FrasesH = New Util.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionesH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DGV_FrasesP = New Util.DBDataGridView()
        Me.CodigoFraseP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionFraseP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtTipoEtiqueta = New System.Windows.Forms.TextBox()
        Me.lblTipoEtiqueta = New System.Windows.Forms.Label()
        Me.cbxTipoProducto = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCaracteristicas = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmbalaje = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtIntervencion = New System.Windows.Forms.TextBox()
        Me.txtRiesgo = New System.Windows.Forms.TextBox()
        Me.txtSecundario = New System.Windows.Forms.TextBox()
        Me.txtClase = New System.Windows.Forms.TextBox()
        Me.txtNroNacionesUnidas = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.DGV_DemoCompPeligrosos = New Util.DBDataGridView()
        Me.Denominacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.DGV_FrasesHIngles = New Util.DBDataGridView()
        Me.CodigoFraseHINgles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionFraseHINgles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.DGV_FrasesPIngles = New Util.DBDataGridView()
        Me.CodigoFrasesPIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionFrasesPIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlConsultarDatos = New System.Windows.Forms.Panel()
        Me.btnAnteriorPag = New System.Windows.Forms.Button()
        Me.btnVolverConsultarDatos = New System.Windows.Forms.Button()
        Me.txtConsultaDatos = New System.Windows.Forms.TextBox()
        Me.LstboxConsultaDatos = New System.Windows.Forms.ListBox()
        Me.DGV_Consulta = New Util.DBDataGridView()
        Me.Codigo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionesConsulta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.masktxtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnConsultarDatos = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnImprimirReporte = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV_FrasesH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DGV_FrasesP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.DGV_DemoCompPeligrosos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.DGV_FrasesHIngles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.DGV_FrasesPIngles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsultarDatos.SuspendLayout()
        CType(Me.DGV_Consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(19, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CODIGO"
        '
        'txtNombreArticulo
        '
        Me.txtNombreArticulo.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtNombreArticulo.Enabled = False
        Me.txtNombreArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreArticulo.Location = New System.Drawing.Point(147, 55)
        Me.txtNombreArticulo.Name = "txtNombreArticulo"
        Me.txtNombreArticulo.Size = New System.Drawing.Size(415, 20)
        Me.txtNombreArticulo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(568, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PALABRA ADVERTENCIA"
        '
        'cbxPalabraAdvertencia
        '
        Me.cbxPalabraAdvertencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPalabraAdvertencia.FormattingEnabled = True
        Me.cbxPalabraAdvertencia.Items.AddRange(New Object() {"", "ATENCIÓN", "PELIGRO"})
        Me.cbxPalabraAdvertencia.Location = New System.Drawing.Point(713, 55)
        Me.cbxPalabraAdvertencia.Name = "cbxPalabraAdvertencia"
        Me.cbxPalabraAdvertencia.Size = New System.Drawing.Size(93, 21)
        Me.cbxPalabraAdvertencia.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.ItemSize = New System.Drawing.Size(150, 30)
        Me.TabControl1.Location = New System.Drawing.Point(13, 82)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(50, 3)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(793, 392)
        Me.TabControl1.TabIndex = 6
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.cbxMedioAmbiente9)
        Me.TabPage1.Controls.Add(Me.cbxPeligroPLASalud8)
        Me.TabPage1.Controls.Add(Me.cbxPeligro7)
        Me.TabPage1.Controls.Add(Me.cbxToxico6)
        Me.TabPage1.Controls.Add(Me.cbxCorrosivo5)
        Me.TabPage1.Controls.Add(Me.cbxGasesBajo4)
        Me.TabPage1.Controls.Add(Me.cbxCarburante3)
        Me.TabPage1.Controls.Add(Me.cbxInflamable2)
        Me.TabPage1.Controls.Add(Me.cbxExplosivo1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.PictureBox9)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PictureBox8)
        Me.TabPage1.Controls.Add(Me.PictureBox7)
        Me.TabPage1.Controls.Add(Me.PictureBox6)
        Me.TabPage1.Controls.Add(Me.PictureBox5)
        Me.TabPage1.Controls.Add(Me.PictureBox4)
        Me.TabPage1.Controls.Add(Me.PictureBox3)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 64)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(785, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PICTOGRAMA"
        '
        'cbxMedioAmbiente9
        '
        Me.cbxMedioAmbiente9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMedioAmbiente9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMedioAmbiente9.FormattingEnabled = True
        Me.cbxMedioAmbiente9.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxMedioAmbiente9.Location = New System.Drawing.Point(592, 286)
        Me.cbxMedioAmbiente9.Name = "cbxMedioAmbiente9"
        Me.cbxMedioAmbiente9.Size = New System.Drawing.Size(83, 24)
        Me.cbxMedioAmbiente9.TabIndex = 26
        '
        'cbxPeligroPLASalud8
        '
        Me.cbxPeligroPLASalud8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPeligroPLASalud8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPeligroPLASalud8.FormattingEnabled = True
        Me.cbxPeligroPLASalud8.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxPeligroPLASalud8.Location = New System.Drawing.Point(432, 286)
        Me.cbxPeligroPLASalud8.Name = "cbxPeligroPLASalud8"
        Me.cbxPeligroPLASalud8.Size = New System.Drawing.Size(83, 24)
        Me.cbxPeligroPLASalud8.TabIndex = 25
        '
        'cbxPeligro7
        '
        Me.cbxPeligro7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPeligro7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPeligro7.FormattingEnabled = True
        Me.cbxPeligro7.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxPeligro7.Location = New System.Drawing.Point(274, 286)
        Me.cbxPeligro7.Name = "cbxPeligro7"
        Me.cbxPeligro7.Size = New System.Drawing.Size(83, 24)
        Me.cbxPeligro7.TabIndex = 24
        '
        'cbxToxico6
        '
        Me.cbxToxico6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxToxico6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxToxico6.FormattingEnabled = True
        Me.cbxToxico6.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxToxico6.Location = New System.Drawing.Point(117, 286)
        Me.cbxToxico6.Name = "cbxToxico6"
        Me.cbxToxico6.Size = New System.Drawing.Size(83, 24)
        Me.cbxToxico6.TabIndex = 23
        '
        'cbxCorrosivo5
        '
        Me.cbxCorrosivo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCorrosivo5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCorrosivo5.FormattingEnabled = True
        Me.cbxCorrosivo5.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxCorrosivo5.Location = New System.Drawing.Point(664, 129)
        Me.cbxCorrosivo5.Name = "cbxCorrosivo5"
        Me.cbxCorrosivo5.Size = New System.Drawing.Size(83, 24)
        Me.cbxCorrosivo5.TabIndex = 22
        '
        'cbxGasesBajo4
        '
        Me.cbxGasesBajo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGasesBajo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGasesBajo4.FormattingEnabled = True
        Me.cbxGasesBajo4.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxGasesBajo4.Location = New System.Drawing.Point(512, 129)
        Me.cbxGasesBajo4.Name = "cbxGasesBajo4"
        Me.cbxGasesBajo4.Size = New System.Drawing.Size(83, 24)
        Me.cbxGasesBajo4.TabIndex = 21
        '
        'cbxCarburante3
        '
        Me.cbxCarburante3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCarburante3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCarburante3.FormattingEnabled = True
        Me.cbxCarburante3.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxCarburante3.Location = New System.Drawing.Point(354, 129)
        Me.cbxCarburante3.Name = "cbxCarburante3"
        Me.cbxCarburante3.Size = New System.Drawing.Size(83, 24)
        Me.cbxCarburante3.TabIndex = 20
        '
        'cbxInflamable2
        '
        Me.cbxInflamable2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInflamable2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxInflamable2.FormattingEnabled = True
        Me.cbxInflamable2.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxInflamable2.Location = New System.Drawing.Point(195, 129)
        Me.cbxInflamable2.Name = "cbxInflamable2"
        Me.cbxInflamable2.Size = New System.Drawing.Size(83, 24)
        Me.cbxInflamable2.TabIndex = 19
        '
        'cbxExplosivo1
        '
        Me.cbxExplosivo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxExplosivo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxExplosivo1.FormattingEnabled = True
        Me.cbxExplosivo1.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.cbxExplosivo1.Location = New System.Drawing.Point(38, 129)
        Me.cbxExplosivo1.Name = "cbxExplosivo1"
        Me.cbxExplosivo1.Size = New System.Drawing.Size(83, 24)
        Me.cbxExplosivo1.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(573, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "MEDIO AMBIENTE ( 9 )"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.Laboratorio.My.Resources.Resources.SGA9
        Me.PictureBox9.Location = New System.Drawing.Point(583, 165)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 16
        Me.PictureBox9.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(401, 266)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "PELIGRO P/ LA SALUD ( 8 )"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(278, 266)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "PELIGRO ( 7 )"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(124, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "TÓXICO ( 6 )"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(659, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "CORROSIVO ( 5 )"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(506, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "GASES BAJO ( 4 )"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(344, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "CARBURANTE ( 3 )"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "INFLAMABLE ( 2 )"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "EXPLOSIVO ( 1 )"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.Laboratorio.My.Resources.Resources.SGA8
        Me.PictureBox8.Location = New System.Drawing.Point(423, 165)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 7
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.Laboratorio.My.Resources.Resources.SGA7
        Me.PictureBox7.Location = New System.Drawing.Point(265, 165)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 6
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.Laboratorio.My.Resources.Resources.SGA6
        Me.PictureBox6.Location = New System.Drawing.Point(108, 165)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 5
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Laboratorio.My.Resources.Resources.SGA5
        Me.PictureBox5.Location = New System.Drawing.Point(655, 9)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 4
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Laboratorio.My.Resources.Resources.SGA4
        Me.PictureBox4.Location = New System.Drawing.Point(503, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Laboratorio.My.Resources.Resources.SGA3
        Me.PictureBox3.Location = New System.Drawing.Point(345, 9)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Laboratorio.My.Resources.Resources.SGA2
        Me.PictureBox2.Location = New System.Drawing.Point(186, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Laboratorio.My.Resources.Resources.SGA1
        Me.PictureBox1.Location = New System.Drawing.Point(29, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DGV_FrasesH)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 64)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(785, 324)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "FRASES H"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DGV_FrasesH
        '
        Me.DGV_FrasesH.AllowUserToAddRows = False
        Me.DGV_FrasesH.AllowUserToOrderColumns = True
        Me.DGV_FrasesH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FrasesH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.DescripcionH, Me.ObservacionesH})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FrasesH.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_FrasesH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_FrasesH.DoubleBuffered = True
        Me.DGV_FrasesH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_FrasesH.Location = New System.Drawing.Point(3, 3)
        Me.DGV_FrasesH.Name = "DGV_FrasesH"
        Me.DGV_FrasesH.OrdenamientoColumnasHabilitado = False
        Me.DGV_FrasesH.ReadOnly = True
        Me.DGV_FrasesH.RowHeadersWidth = 15
        Me.DGV_FrasesH.RowTemplate.Height = 20
        Me.DGV_FrasesH.ShowCellToolTips = False
        Me.DGV_FrasesH.SinClickDerecho = False
        Me.DGV_FrasesH.Size = New System.Drawing.Size(779, 318)
        Me.DGV_FrasesH.TabIndex = 0
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Codigo.Width = 46
        '
        'DescripcionH
        '
        Me.DescripcionH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionH.DataPropertyName = "Descripcion"
        Me.DescripcionH.HeaderText = "Descripcion"
        Me.DescripcionH.MaxInputLength = 450
        Me.DescripcionH.Name = "DescripcionH"
        Me.DescripcionH.ReadOnly = True
        Me.DescripcionH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ObservacionesH
        '
        Me.ObservacionesH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ObservacionesH.DataPropertyName = "Observaciones"
        Me.ObservacionesH.HeaderText = "Observaciones"
        Me.ObservacionesH.Name = "ObservacionesH"
        Me.ObservacionesH.ReadOnly = True
        Me.ObservacionesH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ObservacionesH.Width = 84
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DGV_FrasesP)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 64)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(785, 324)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "FRASES P"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DGV_FrasesP
        '
        Me.DGV_FrasesP.AllowUserToAddRows = False
        Me.DGV_FrasesP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FrasesP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoFraseP, Me.DescripcionFraseP, Me.Observaciones})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FrasesP.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_FrasesP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_FrasesP.DoubleBuffered = True
        Me.DGV_FrasesP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_FrasesP.Location = New System.Drawing.Point(3, 3)
        Me.DGV_FrasesP.Name = "DGV_FrasesP"
        Me.DGV_FrasesP.OrdenamientoColumnasHabilitado = False
        Me.DGV_FrasesP.ReadOnly = True
        Me.DGV_FrasesP.RowHeadersWidth = 15
        Me.DGV_FrasesP.RowTemplate.Height = 20
        Me.DGV_FrasesP.ShowCellToolTips = False
        Me.DGV_FrasesP.SinClickDerecho = False
        Me.DGV_FrasesP.Size = New System.Drawing.Size(779, 318)
        Me.DGV_FrasesP.TabIndex = 1
        '
        'CodigoFraseP
        '
        Me.CodigoFraseP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoFraseP.DataPropertyName = "Codigo"
        Me.CodigoFraseP.HeaderText = "Codigo"
        Me.CodigoFraseP.Name = "CodigoFraseP"
        Me.CodigoFraseP.ReadOnly = True
        Me.CodigoFraseP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoFraseP.Width = 46
        '
        'DescripcionFraseP
        '
        Me.DescripcionFraseP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionFraseP.DataPropertyName = "Descripcion"
        Me.DescripcionFraseP.HeaderText = "Descripcion"
        Me.DescripcionFraseP.MaxInputLength = 450
        Me.DescripcionFraseP.Name = "DescripcionFraseP"
        Me.DescripcionFraseP.ReadOnly = True
        Me.DescripcionFraseP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MaxInputLength = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Observaciones.Width = 84
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Controls.Add(Me.txtTipoEtiqueta)
        Me.TabPage4.Controls.Add(Me.lblTipoEtiqueta)
        Me.TabPage4.Controls.Add(Me.cbxTipoProducto)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Controls.Add(Me.cbxEstado)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.txtCaracteristicas)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Controls.Add(Me.txtEmbalaje)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Controls.Add(Me.txtIntervencion)
        Me.TabPage4.Controls.Add(Me.txtRiesgo)
        Me.TabPage4.Controls.Add(Me.txtSecundario)
        Me.TabPage4.Controls.Add(Me.txtClase)
        Me.TabPage4.Controls.Add(Me.txtNroNacionesUnidas)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 64)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(785, 324)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "DATOS ONU"
        '
        'txtTipoEtiqueta
        '
        Me.txtTipoEtiqueta.Location = New System.Drawing.Point(115, 26)
        Me.txtTipoEtiqueta.MaxLength = 20
        Me.txtTipoEtiqueta.Name = "txtTipoEtiqueta"
        Me.txtTipoEtiqueta.Size = New System.Drawing.Size(157, 20)
        Me.txtTipoEtiqueta.TabIndex = 4
        Me.txtTipoEtiqueta.Visible = False
        '
        'lblTipoEtiqueta
        '
        Me.lblTipoEtiqueta.AutoSize = True
        Me.lblTipoEtiqueta.Location = New System.Drawing.Point(18, 29)
        Me.lblTipoEtiqueta.Name = "lblTipoEtiqueta"
        Me.lblTipoEtiqueta.Size = New System.Drawing.Size(89, 13)
        Me.lblTipoEtiqueta.TabIndex = 18
        Me.lblTipoEtiqueta.Text = "TIPO ETIQUETA"
        Me.lblTipoEtiqueta.Visible = False
        '
        'cbxTipoProducto
        '
        Me.cbxTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoProducto.FormattingEnabled = True
        Me.cbxTipoProducto.Items.AddRange(New Object() {"", "Neutro", "Acido Debil", "Acido Fuerte", "Alcalino Debil", "Alcalino Fuerte"})
        Me.cbxTipoProducto.Location = New System.Drawing.Point(132, 263)
        Me.cbxTipoProducto.Name = "cbxTipoProducto"
        Me.cbxTipoProducto.Size = New System.Drawing.Size(121, 21)
        Me.cbxTipoProducto.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 266)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "TIPO PRODUCTO"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"", "Polvo", "Liquido", "Metal", "Pasta"})
        Me.cbxEstado.Location = New System.Drawing.Point(132, 226)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(121, 21)
        Me.cbxEstado.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 229)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "ESTADO"
        '
        'txtCaracteristicas
        '
        Me.txtCaracteristicas.Location = New System.Drawing.Point(132, 195)
        Me.txtCaracteristicas.MaxLength = 100
        Me.txtCaracteristicas.Name = "txtCaracteristicas"
        Me.txtCaracteristicas.Size = New System.Drawing.Size(629, 20)
        Me.txtCaracteristicas.TabIndex = 13
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 198)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 13)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "CARACTERÍSTICAS"
        '
        'txtEmbalaje
        '
        Me.txtEmbalaje.Location = New System.Drawing.Point(132, 157)
        Me.txtEmbalaje.MaxLength = 10
        Me.txtEmbalaje.Name = "txtEmbalaje"
        Me.txtEmbalaje.Size = New System.Drawing.Size(157, 20)
        Me.txtEmbalaje.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "GRUPO EMBALAJE"
        '
        'txtIntervencion
        '
        Me.txtIntervencion.Location = New System.Drawing.Point(115, 124)
        Me.txtIntervencion.MaxLength = 10
        Me.txtIntervencion.Name = "txtIntervencion"
        Me.txtIntervencion.Size = New System.Drawing.Size(157, 20)
        Me.txtIntervencion.TabIndex = 9
        '
        'txtRiesgo
        '
        Me.txtRiesgo.Location = New System.Drawing.Point(520, 124)
        Me.txtRiesgo.MaxLength = 10
        Me.txtRiesgo.Name = "txtRiesgo"
        Me.txtRiesgo.Size = New System.Drawing.Size(100, 20)
        Me.txtRiesgo.TabIndex = 8
        '
        'txtSecundario
        '
        Me.txtSecundario.Location = New System.Drawing.Point(340, 124)
        Me.txtSecundario.MaxLength = 10
        Me.txtSecundario.Name = "txtSecundario"
        Me.txtSecundario.Size = New System.Drawing.Size(100, 20)
        Me.txtSecundario.TabIndex = 7
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(115, 90)
        Me.txtClase.MaxLength = 30
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(325, 20)
        Me.txtClase.TabIndex = 6
        '
        'txtNroNacionesUnidas
        '
        Me.txtNroNacionesUnidas.Location = New System.Drawing.Point(115, 58)
        Me.txtNroNacionesUnidas.MaxLength = 10
        Me.txtNroNacionesUnidas.Name = "txtNroNacionesUnidas"
        Me.txtNroNacionesUnidas.Size = New System.Drawing.Size(157, 20)
        Me.txtNroNacionesUnidas.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "INTERVENCIÓN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(471, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "RIESGO"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(294, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "R. SEC"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "CLASE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "NRO ONU:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DGV_DemoCompPeligrosos)
        Me.TabPage5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 64)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(785, 324)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "DENOMINACION COMP. PELIGROSOS"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DGV_DemoCompPeligrosos
        '
        Me.DGV_DemoCompPeligrosos.AllowUserToAddRows = False
        Me.DGV_DemoCompPeligrosos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DemoCompPeligrosos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Denominacion})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_DemoCompPeligrosos.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_DemoCompPeligrosos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_DemoCompPeligrosos.DoubleBuffered = True
        Me.DGV_DemoCompPeligrosos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_DemoCompPeligrosos.Location = New System.Drawing.Point(3, 3)
        Me.DGV_DemoCompPeligrosos.Name = "DGV_DemoCompPeligrosos"
        Me.DGV_DemoCompPeligrosos.OrdenamientoColumnasHabilitado = False
        Me.DGV_DemoCompPeligrosos.RowHeadersWidth = 15
        Me.DGV_DemoCompPeligrosos.RowTemplate.Height = 20
        Me.DGV_DemoCompPeligrosos.ShowCellToolTips = False
        Me.DGV_DemoCompPeligrosos.SinClickDerecho = False
        Me.DGV_DemoCompPeligrosos.Size = New System.Drawing.Size(779, 318)
        Me.DGV_DemoCompPeligrosos.TabIndex = 0
        '
        'Denominacion
        '
        Me.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Denominacion.DataPropertyName = "Denominacion"
        Me.Denominacion.HeaderText = "Denominaciones"
        Me.Denominacion.Name = "Denominacion"
        Me.Denominacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.DGV_FrasesHIngles)
        Me.TabPage6.Location = New System.Drawing.Point(4, 64)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(785, 324)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "FRASES H (INGLÉS)"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'DGV_FrasesHIngles
        '
        Me.DGV_FrasesHIngles.AllowUserToAddRows = False
        Me.DGV_FrasesHIngles.AllowUserToOrderColumns = True
        Me.DGV_FrasesHIngles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FrasesHIngles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoFraseHINgles, Me.DescripcionFraseHINgles})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FrasesHIngles.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_FrasesHIngles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_FrasesHIngles.DoubleBuffered = True
        Me.DGV_FrasesHIngles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_FrasesHIngles.Location = New System.Drawing.Point(0, 0)
        Me.DGV_FrasesHIngles.Name = "DGV_FrasesHIngles"
        Me.DGV_FrasesHIngles.OrdenamientoColumnasHabilitado = False
        Me.DGV_FrasesHIngles.ReadOnly = True
        Me.DGV_FrasesHIngles.RowHeadersWidth = 15
        Me.DGV_FrasesHIngles.RowTemplate.Height = 20
        Me.DGV_FrasesHIngles.ShowCellToolTips = False
        Me.DGV_FrasesHIngles.SinClickDerecho = False
        Me.DGV_FrasesHIngles.Size = New System.Drawing.Size(785, 324)
        Me.DGV_FrasesHIngles.TabIndex = 1
        '
        'CodigoFraseHINgles
        '
        Me.CodigoFraseHINgles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoFraseHINgles.DataPropertyName = "Codigo"
        Me.CodigoFraseHINgles.HeaderText = "Codigo"
        Me.CodigoFraseHINgles.Name = "CodigoFraseHINgles"
        Me.CodigoFraseHINgles.ReadOnly = True
        Me.CodigoFraseHINgles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoFraseHINgles.Width = 46
        '
        'DescripcionFraseHINgles
        '
        Me.DescripcionFraseHINgles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionFraseHINgles.DataPropertyName = "Descripcion"
        Me.DescripcionFraseHINgles.HeaderText = "Descripcion"
        Me.DescripcionFraseHINgles.MaxInputLength = 450
        Me.DescripcionFraseHINgles.Name = "DescripcionFraseHINgles"
        Me.DescripcionFraseHINgles.ReadOnly = True
        Me.DescripcionFraseHINgles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.DGV_FrasesPIngles)
        Me.TabPage7.Location = New System.Drawing.Point(4, 64)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(785, 324)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "FRASES P (INGLÉS)"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'DGV_FrasesPIngles
        '
        Me.DGV_FrasesPIngles.AllowUserToAddRows = False
        Me.DGV_FrasesPIngles.AllowUserToOrderColumns = True
        Me.DGV_FrasesPIngles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FrasesPIngles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoFrasesPIngles, Me.DescripcionFrasesPIngles})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FrasesPIngles.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_FrasesPIngles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_FrasesPIngles.DoubleBuffered = True
        Me.DGV_FrasesPIngles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_FrasesPIngles.Location = New System.Drawing.Point(0, 0)
        Me.DGV_FrasesPIngles.Name = "DGV_FrasesPIngles"
        Me.DGV_FrasesPIngles.OrdenamientoColumnasHabilitado = False
        Me.DGV_FrasesPIngles.ReadOnly = True
        Me.DGV_FrasesPIngles.RowHeadersWidth = 15
        Me.DGV_FrasesPIngles.RowTemplate.Height = 20
        Me.DGV_FrasesPIngles.ShowCellToolTips = False
        Me.DGV_FrasesPIngles.SinClickDerecho = False
        Me.DGV_FrasesPIngles.Size = New System.Drawing.Size(785, 324)
        Me.DGV_FrasesPIngles.TabIndex = 2
        '
        'CodigoFrasesPIngles
        '
        Me.CodigoFrasesPIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoFrasesPIngles.DataPropertyName = "Codigo"
        Me.CodigoFrasesPIngles.HeaderText = "Codigo"
        Me.CodigoFrasesPIngles.Name = "CodigoFrasesPIngles"
        Me.CodigoFrasesPIngles.ReadOnly = True
        Me.CodigoFrasesPIngles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoFrasesPIngles.Width = 46
        '
        'DescripcionFrasesPIngles
        '
        Me.DescripcionFrasesPIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionFrasesPIngles.DataPropertyName = "Descripcion"
        Me.DescripcionFrasesPIngles.HeaderText = "Descripcion"
        Me.DescripcionFrasesPIngles.MaxInputLength = 450
        Me.DescripcionFrasesPIngles.Name = "DescripcionFrasesPIngles"
        Me.DescripcionFrasesPIngles.ReadOnly = True
        Me.DescripcionFrasesPIngles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'pnlConsultarDatos
        '
        Me.pnlConsultarDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConsultarDatos.Controls.Add(Me.btnAnteriorPag)
        Me.pnlConsultarDatos.Controls.Add(Me.btnVolverConsultarDatos)
        Me.pnlConsultarDatos.Controls.Add(Me.txtConsultaDatos)
        Me.pnlConsultarDatos.Controls.Add(Me.LstboxConsultaDatos)
        Me.pnlConsultarDatos.Controls.Add(Me.DGV_Consulta)
        Me.pnlConsultarDatos.Location = New System.Drawing.Point(119, 134)
        Me.pnlConsultarDatos.Name = "pnlConsultarDatos"
        Me.pnlConsultarDatos.Size = New System.Drawing.Size(537, 272)
        Me.pnlConsultarDatos.TabIndex = 1
        '
        'btnAnteriorPag
        '
        Me.btnAnteriorPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnteriorPag.Location = New System.Drawing.Point(362, 216)
        Me.btnAnteriorPag.Name = "btnAnteriorPag"
        Me.btnAnteriorPag.Size = New System.Drawing.Size(120, 47)
        Me.btnAnteriorPag.TabIndex = 3
        Me.btnAnteriorPag.Text = "PAG. ANT."
        Me.btnAnteriorPag.UseVisualStyleBackColor = True
        '
        'btnVolverConsultarDatos
        '
        Me.btnVolverConsultarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolverConsultarDatos.Location = New System.Drawing.Point(187, 216)
        Me.btnVolverConsultarDatos.Name = "btnVolverConsultarDatos"
        Me.btnVolverConsultarDatos.Size = New System.Drawing.Size(120, 47)
        Me.btnVolverConsultarDatos.TabIndex = 2
        Me.btnVolverConsultarDatos.Text = "CERRAR"
        Me.btnVolverConsultarDatos.UseVisualStyleBackColor = True
        '
        'txtConsultaDatos
        '
        Me.txtConsultaDatos.Location = New System.Drawing.Point(9, 22)
        Me.txtConsultaDatos.Name = "txtConsultaDatos"
        Me.txtConsultaDatos.Size = New System.Drawing.Size(476, 20)
        Me.txtConsultaDatos.TabIndex = 0
        '
        'LstboxConsultaDatos
        '
        Me.LstboxConsultaDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstboxConsultaDatos.FormattingEnabled = True
        Me.LstboxConsultaDatos.ItemHeight = 18
        Me.LstboxConsultaDatos.Location = New System.Drawing.Point(9, 54)
        Me.LstboxConsultaDatos.Name = "LstboxConsultaDatos"
        Me.LstboxConsultaDatos.Size = New System.Drawing.Size(476, 130)
        Me.LstboxConsultaDatos.TabIndex = 1
        '
        'DGV_Consulta
        '
        Me.DGV_Consulta.AllowUserToAddRows = False
        Me.DGV_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo1, Me.Descripcion, Me.ObservacionesConsulta})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Consulta.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGV_Consulta.DoubleBuffered = True
        Me.DGV_Consulta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Consulta.Location = New System.Drawing.Point(9, 54)
        Me.DGV_Consulta.Name = "DGV_Consulta"
        Me.DGV_Consulta.OrdenamientoColumnasHabilitado = True
        Me.DGV_Consulta.RowHeadersWidth = 15
        Me.DGV_Consulta.RowTemplate.Height = 20
        Me.DGV_Consulta.ShowCellToolTips = False
        Me.DGV_Consulta.SinClickDerecho = False
        Me.DGV_Consulta.Size = New System.Drawing.Size(476, 130)
        Me.DGV_Consulta.TabIndex = 4
        '
        'Codigo1
        '
        Me.Codigo1.DataPropertyName = "Codigo"
        Me.Codigo1.HeaderText = "Codigo"
        Me.Codigo1.Name = "Codigo1"
        Me.Codigo1.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'ObservacionesConsulta
        '
        Me.ObservacionesConsulta.DataPropertyName = "Observaciones"
        Me.ObservacionesConsulta.HeaderText = "Observaciones"
        Me.ObservacionesConsulta.Name = "ObservacionesConsulta"
        Me.ObservacionesConsulta.ReadOnly = True
        '
        'masktxtCodigo
        '
        Me.masktxtCodigo.Location = New System.Drawing.Point(72, 55)
        Me.masktxtCodigo.Mask = ">LL-000-000"
        Me.masktxtCodigo.Name = "masktxtCodigo"
        Me.masktxtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.masktxtCodigo.Size = New System.Drawing.Size(69, 20)
        Me.masktxtCodigo.TabIndex = 7
        Me.masktxtCodigo.Text = "AA999999"
        Me.masktxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(32, 480)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(135, 49)
        Me.btnGrabar.TabIndex = 8
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Location = New System.Drawing.Point(188, 480)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(135, 49)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnConsultarDatos
        '
        Me.btnConsultarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarDatos.Location = New System.Drawing.Point(344, 480)
        Me.btnConsultarDatos.Name = "btnConsultarDatos"
        Me.btnConsultarDatos.Size = New System.Drawing.Size(135, 49)
        Me.btnConsultarDatos.TabIndex = 10
        Me.btnConsultarDatos.Text = "CONSULTAR DATOS"
        Me.btnConsultarDatos.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(656, 480)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(135, 49)
        Me.btnVolver.TabIndex = 11
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirReporte.Location = New System.Drawing.Point(500, 480)
        Me.btnImprimirReporte.Name = "btnImprimirReporte"
        Me.btnImprimirReporte.Size = New System.Drawing.Size(135, 49)
        Me.btnImprimirReporte.TabIndex = 12
        Me.btnImprimirReporte.Text = "IMPRIMIR"
        Me.btnImprimirReporte.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(816, 49)
        Me.Panel2.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.Control
        Me.Label22.Location = New System.Drawing.Point(24, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(288, 18)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "DATOS ADICIONALES (MATERIA PRIMA)"
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.Control
        Me.Label21.Location = New System.Drawing.Point(637, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(155, 20)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "SURFACTAN S.A."
        '
        'IngresoDatosAdicMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 538)
        Me.Controls.Add(Me.pnlConsultarDatos)
        Me.Controls.Add(Me.btnImprimirReporte)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnConsultarDatos)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.masktxtCodigo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cbxPalabraAdvertencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombreArticulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.Name = "IngresoDatosAdicMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DGV_FrasesH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DGV_FrasesP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.DGV_DemoCompPeligrosos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.DGV_FrasesHIngles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        CType(Me.DGV_FrasesPIngles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsultarDatos.ResumeLayout(False)
        Me.pnlConsultarDatos.PerformLayout()
        CType(Me.DGV_Consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxPalabraAdvertencia As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents cbxMedioAmbiente9 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxPeligroPLASalud8 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxPeligro7 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxToxico6 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCorrosivo5 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxGasesBajo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarburante3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxInflamable2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxExplosivo1 As System.Windows.Forms.ComboBox
    Friend WithEvents DGV_FrasesH As Util.DBDataGridView
    Friend WithEvents DGV_FrasesP As Util.DBDataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DGV_DemoCompPeligrosos As Util.DBDataGridView
    Friend WithEvents masktxtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCaracteristicas As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEmbalaje As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtIntervencion As System.Windows.Forms.TextBox
    Friend WithEvents txtRiesgo As System.Windows.Forms.TextBox
    Friend WithEvents txtSecundario As System.Windows.Forms.TextBox
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents txtNroNacionesUnidas As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnConsultarDatos As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Denominacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlConsultarDatos As System.Windows.Forms.Panel
    Friend WithEvents LstboxConsultaDatos As System.Windows.Forms.ListBox
    Friend WithEvents txtConsultaDatos As System.Windows.Forms.TextBox
    Friend WithEvents btnVolverConsultarDatos As System.Windows.Forms.Button
    Friend WithEvents btnAnteriorPag As System.Windows.Forms.Button
    Friend WithEvents DGV_Consulta As Util.DBDataGridView
    Friend WithEvents btnImprimirReporte As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservacionesH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoFraseP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionFraseP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTipoEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoEtiqueta As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents DGV_FrasesHIngles As Util.DBDataGridView
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents DGV_FrasesPIngles As Util.DBDataGridView
    Friend WithEvents CodigoFraseHINgles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionFraseHINgles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoFrasesPIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionFrasesPIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservacionesConsulta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
