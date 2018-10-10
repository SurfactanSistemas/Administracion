<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoSac
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.lblDescCentro = New System.Windows.Forms.Label()
        Me.lblDescResponsable = New System.Windows.Forms.Label()
        Me.lblDescEmisor = New System.Windows.Forms.Label()
        Me.lblDescTipo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAnio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCentro = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmisor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtIngresoCausa = New System.Windows.Forms.TextBox()
        Me.txtIngresoNoCon = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvAcciones = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.idAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plazo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.cmbOrigen)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.lblDescCentro)
        Me.GroupBox1.Controls.Add(Me.lblDescResponsable)
        Me.GroupBox1.Controls.Add(Me.lblDescEmisor)
        Me.GroupBox1.Controls.Add(Me.lblDescTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAnio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCentro)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtResponsable)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtEmisor)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtReferencia)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtTitulo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTipo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(803, 136)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales SAC"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "Iniciada", "Investigación", "Implementación", "Implementación a Verificar", "Implementación Verificada", "Cerrada"})
        Me.cmbEstado.Location = New System.Drawing.Point(365, 55)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'cmbOrigen
        '
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Items.AddRange(New Object() {"", "Auditoría", "Reclamo", "I. de No Conformidad", "Proceso / Sist", "Otro"})
        Me.cmbOrigen.Location = New System.Drawing.Point(196, 55)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(121, 21)
        Me.cmbOrigen.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(76, 55)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(68, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescCentro
        '
        Me.lblDescCentro.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCentro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCentro.Location = New System.Drawing.Point(656, 53)
        Me.lblDescCentro.Name = "lblDescCentro"
        Me.lblDescCentro.Size = New System.Drawing.Size(127, 22)
        Me.lblDescCentro.TabIndex = 1
        Me.lblDescCentro.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDescResponsable
        '
        Me.lblDescResponsable.BackColor = System.Drawing.Color.Cyan
        Me.lblDescResponsable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescResponsable.Location = New System.Drawing.Point(656, 106)
        Me.lblDescResponsable.Name = "lblDescResponsable"
        Me.lblDescResponsable.Size = New System.Drawing.Size(127, 22)
        Me.lblDescResponsable.TabIndex = 1
        Me.lblDescResponsable.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDescEmisor
        '
        Me.lblDescEmisor.BackColor = System.Drawing.Color.Cyan
        Me.lblDescEmisor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescEmisor.Location = New System.Drawing.Point(656, 80)
        Me.lblDescEmisor.Name = "lblDescEmisor"
        Me.lblDescEmisor.Size = New System.Drawing.Size(127, 22)
        Me.lblDescEmisor.TabIndex = 1
        Me.lblDescEmisor.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDescTipo
        '
        Me.lblDescTipo.BackColor = System.Drawing.Color.Cyan
        Me.lblDescTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescTipo.Location = New System.Drawing.Point(111, 24)
        Me.lblDescTipo.Name = "lblDescTipo"
        Me.lblDescTipo.Size = New System.Drawing.Size(127, 22)
        Me.lblDescTipo.TabIndex = 1
        Me.lblDescTipo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(371, 25)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(53, 20)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(273, 25)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(45, 20)
        Me.txtAnio.TabIndex = 0
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(573, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Centro"
        '
        'txtCentro
        '
        Me.txtCentro.Location = New System.Drawing.Point(617, 54)
        Me.txtCentro.Name = "txtCentro"
        Me.txtCentro.Size = New System.Drawing.Size(32, 20)
        Me.txtCentro.TabIndex = 0
        Me.txtCentro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(321, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Estado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(152, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Origen"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(542, 111)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Responsable"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Tipo"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(617, 107)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(32, 20)
        Me.txtResponsable.TabIndex = 0
        Me.txtResponsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(573, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Emisor"
        '
        'txtEmisor
        '
        Me.txtEmisor.Location = New System.Drawing.Point(617, 81)
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(32, 20)
        Me.txtEmisor.TabIndex = 0
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(76, 108)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(460, 20)
        Me.txtReferencia.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Titulo"
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(76, 85)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(460, 20)
        Me.txtTitulo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(76, 25)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(31, 20)
        Me.txtTipo.TabIndex = 0
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 36)
        Me.Panel1.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Control
        Me.Label17.Location = New System.Drawing.Point(25, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 18)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Carga SAC"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Control
        Me.Label18.Location = New System.Drawing.Point(905, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 18)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "SURFACTAN S.A."
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1010, 323)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.txtIngresoCausa)
        Me.TabPage1.Controls.Add(Me.txtIngresoNoCon)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1002, 290)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Descripción"
        '
        'txtIngresoCausa
        '
        Me.txtIngresoCausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoCausa.Location = New System.Drawing.Point(515, 48)
        Me.txtIngresoCausa.Multiline = True
        Me.txtIngresoCausa.Name = "txtIngresoCausa"
        Me.txtIngresoCausa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtIngresoCausa.Size = New System.Drawing.Size(467, 231)
        Me.txtIngresoCausa.TabIndex = 0
        '
        'txtIngresoNoCon
        '
        Me.txtIngresoNoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoNoCon.Location = New System.Drawing.Point(25, 48)
        Me.txtIngresoNoCon.Multiline = True
        Me.txtIngresoNoCon.Name = "txtIngresoNoCon"
        Me.txtIngresoNoCon.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtIngresoNoCon.Size = New System.Drawing.Size(467, 231)
        Me.txtIngresoNoCon.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(515, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(467, 26)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Causas que la Originaron"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(25, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(467, 26)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Descripción de No Conformidad"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.txtFechaAux)
        Me.TabPage2.Controls.Add(Me.dgvAcciones)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1002, 290)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acciones"
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(931, 50)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(58, 13)
        Me.txtFechaAux.TabIndex = 2
        Me.txtFechaAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaAux.Visible = False
        '
        'dgvAcciones
        '
        Me.dgvAcciones.AllowUserToAddRows = False
        Me.dgvAcciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAcciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAcciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idAccion, Me.Acciones, Me.Responsable, Me.DescResponsable, Me.Plazo})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAcciones.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAcciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvAcciones.Location = New System.Drawing.Point(6, 6)
        Me.dgvAcciones.Name = "dgvAcciones"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAcciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAcciones.RowHeadersWidth = 20
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAcciones.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAcciones.RowTemplate.Height = 20
        Me.dgvAcciones.Size = New System.Drawing.Size(986, 271)
        Me.dgvAcciones.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 197)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1025, 333)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1025, 153)
        Me.Panel3.TabIndex = 5
        '
        'idAccion
        '
        Me.idAccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.idAccion.DefaultCellStyle = DataGridViewCellStyle2
        Me.idAccion.HeaderText = "Accion Nº"
        Me.idAccion.Name = "idAccion"
        Me.idAccion.ReadOnly = True
        Me.idAccion.Width = 80
        '
        'Acciones
        '
        Me.Acciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Acciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.Acciones.HeaderText = "Acciones Correctivas"
        Me.Acciones.Name = "Acciones"
        '
        'Responsable
        '
        Me.Responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Responsable.DefaultCellStyle = DataGridViewCellStyle4
        Me.Responsable.HeaderText = "Resp."
        Me.Responsable.Name = "Responsable"
        Me.Responsable.Width = 60
        '
        'DescResponsable
        '
        Me.DescResponsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescResponsable.HeaderText = "Descripción"
        Me.DescResponsable.Name = "DescResponsable"
        Me.DescResponsable.Width = 88
        '
        'Plazo
        '
        Me.Plazo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Plazo.DefaultCellStyle = DataGridViewCellStyle5
        Me.Plazo.HeaderText = "Plazo"
        Me.Plazo.MinimumWidth = 70
        Me.Plazo.Name = "Plazo"
        Me.Plazo.Width = 70
        '
        'NuevoSac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 530)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.Name = "NuevoSac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents lblDescCentro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCentro As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDescResponsable As System.Windows.Forms.Label
    Friend WithEvents lblDescEmisor As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmisor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtIngresoNoCon As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtIngresoCausa As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvAcciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents idAccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plazo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
