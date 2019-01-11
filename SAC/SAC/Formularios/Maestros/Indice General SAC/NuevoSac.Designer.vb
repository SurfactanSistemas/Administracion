Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class NuevoSac
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New Container()
        Dim DataGridViewCellStyle39 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle75 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle76 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle73 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle74 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle77 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle78 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle79 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle80 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle81 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Me.GroupBox1 = New GroupBox()
        Me.btnProximoNumeroLibre = New Button()
        Me.cmbEstado = New ComboBox()
        Me.cmbOrigen = New ComboBox()
        Me.txtFecha = New MaskedTextBox()
        Me.lblDescCentro = New Label()
        Me.lblDescResponsable = New Label()
        Me.lblDescEmisor = New Label()
        Me.lblDescTipo = New Label()
        Me.Label4 = New Label()
        Me.txtNumero = New TextBox()
        Me.Label2 = New Label()
        Me.txtAnio = New TextBox()
        Me.Label5 = New Label()
        Me.txtCentro = New TextBox()
        Me.Label10 = New Label()
        Me.Label9 = New Label()
        Me.Label8 = New Label()
        Me.Label13 = New Label()
        Me.Label7 = New Label()
        Me.txtResponsable = New TextBox()
        Me.Label11 = New Label()
        Me.txtEmisor = New TextBox()
        Me.Label16 = New Label()
        Me.txtReferencia = New TextBox()
        Me.Label15 = New Label()
        Me.txtTitulo = New TextBox()
        Me.Label1 = New Label()
        Me.txtTipo = New TextBox()
        Me.TabControl1 = New TabControl()
        Me.TabPage1 = New TabPage()
        Me.txtIngresoCausa = New TextBox()
        Me.txtIngresoNoCon = New TextBox()
        Me.Label20 = New Label()
        Me.Label19 = New Label()
        Me.TabPage2 = New TabPage()
        Me.txtFechaAux = New MaskedTextBox()
        Me.dgvAcciones = New DataGridView()
        Me.idAccion = New DataGridViewTextBoxColumn()
        Me.Acciones = New DataGridViewTextBoxColumn()
        Me.Responsable = New DataGridViewTextBoxColumn()
        Me.DescResponsable = New DataGridViewTextBoxColumn()
        Me.Plazo = New DataGridViewTextBoxColumn()
        Me.TabPage3 = New TabPage()
        Me.txtFechaAux2 = New MaskedTextBox()
        Me.dgvImplementaciones = New DataGridView()
        Me.ImpleIdAccion = New DataGridViewTextBoxColumn()
        Me.ImpleAcciones = New DataGridViewTextBoxColumn()
        Me.ImpleResponsable = New DataGridViewTextBoxColumn()
        Me.ImpleDescResponsable = New DataGridViewTextBoxColumn()
        Me.ImpleFecha = New DataGridViewTextBoxColumn()
        Me.Estado = New DataGridViewComboBoxColumn()
        Me.Comentarios = New DataGridViewTextBoxColumn()
        Me.TabPage4 = New TabPage()
        Me.txtFechaAux4 = New MaskedTextBox()
        Me.txtFechaAux3 = New MaskedTextBox()
        Me.Label14 = New Label()
        Me.Label18 = New Label()
        Me.Label17 = New Label()
        Me.Label12 = New Label()
        Me.btnInmovilizarAcciones = New Button()
        Me.dgvVerificaciones = New DataGridView()
        Me.VerIdAcciones = New DataGridViewTextBoxColumn()
        Me.VerAcciones = New DataGridViewTextBoxColumn()
        Me.VerResponsableI = New DataGridViewTextBoxColumn()
        Me.VerDescResponsableI = New DataGridViewTextBoxColumn()
        Me.VerFechaI = New DataGridViewTextBoxColumn()
        Me.VerEstadoI = New DataGridViewComboBoxColumn()
        Me.VerResponsableII = New DataGridViewTextBoxColumn()
        Me.VerDescResponsableII = New DataGridViewTextBoxColumn()
        Me.VerFechaII = New DataGridViewTextBoxColumn()
        Me.VerEstadoII = New DataGridViewComboBoxColumn()
        Me.VerComentario = New DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New ContextMenuStrip(Me.components)
        Me.MovilizarInmovilizarAccionesToolStripMenuItem = New ToolStripMenuItem()
        Me.Label21 = New Label()
        Me.TabPage5 = New TabPage()
        Me.txtComentarios = New TextBox()
        Me.TabPage6 = New TabPage()
        Me.dgvArchivos = New DataGridView()
        Me.FechaArchivo = New DataGridViewTextBoxColumn()
        Me.DescArchivo = New DataGridViewTextBoxColumn()
        Me.Icono = New DataGridViewImageColumn()
        Me.PathArchivo = New DataGridViewTextBoxColumn()
        Me.ContextMenuStrip2 = New ContextMenuStrip(Me.components)
        Me.EliminarArchivoToolStripMenuItem = New ToolStripMenuItem()
        Me.Panel2 = New Panel()
        Me.Panel3 = New Panel()
        Me.GroupBox3 = New GroupBox()
        Me.btnNumeroSiguiente = New Button()
        Me.btnNumeroAnterior = New Button()
        Me.GroupBox2 = New GroupBox()
        Me.btnTipoSiguiente = New Button()
        Me.btnTipoAnterior = New Button()
        Me.btnExportar = New Button()
        Me.Panel1 = New Panel()
        Me.Label3 = New Label()
        Me.Label6 = New Label()
        Me.btnGrabar = New Button()
        Me.btnConsultas = New Button()
        Me.btnImprimir = New Button()
        Me.btnLimpiar = New Button()
        Me.btnCerrar = New Button()
        Me.Panel4 = New Panel()
        Me.Button1 = New Button()
        Me.Button2 = New Button()
        Me.OpenFileDialog1 = New OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvAcciones, ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvImplementaciones, ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvVerificaciones, ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvArchivos, ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnProximoNumeroLibre)
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
        Me.GroupBox1.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New Point(20, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(803, 128)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales SAC"
        '
        'btnProximoNumeroLibre
        '
        Me.btnProximoNumeroLibre.Location = New Point(533, 19)
        Me.btnProximoNumeroLibre.Name = "btnProximoNumeroLibre"
        Me.btnProximoNumeroLibre.Size = New Size(151, 21)
        Me.btnProximoNumeroLibre.TabIndex = 4
        Me.btnProximoNumeroLibre.Text = "Traer Próximo Numero Libre"
        Me.btnProximoNumeroLibre.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "Iniciada", "Investigación", "Implementación", "Implementación a Verificar", "Implementación Verificada", "Cerrada"})
        Me.cmbEstado.Location = New Point(365, 46)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New Size(121, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'cmbOrigen
        '
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Items.AddRange(New Object() {"", "Auditoría", "Reclamo", "I. de No Conformidad", "Proceso / Sist", "Otro"})
        Me.cmbOrigen.Location = New Point(196, 46)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New Size(121, 21)
        Me.cmbOrigen.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Location = New Point(76, 46)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = ChrW(32)
        Me.txtFecha.Size = New Size(68, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TextAlign = HorizontalAlignment.Right
        '
        'lblDescCentro
        '
        Me.lblDescCentro.BackColor = Color.Cyan
        Me.lblDescCentro.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescCentro.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCentro.Location = New Point(656, 44)
        Me.lblDescCentro.Name = "lblDescCentro"
        Me.lblDescCentro.Size = New Size(127, 22)
        Me.lblDescCentro.TabIndex = 1
        Me.lblDescCentro.TextAlign = ContentAlignment.BottomLeft
        '
        'lblDescResponsable
        '
        Me.lblDescResponsable.BackColor = Color.Cyan
        Me.lblDescResponsable.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescResponsable.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescResponsable.Location = New Point(656, 95)
        Me.lblDescResponsable.Name = "lblDescResponsable"
        Me.lblDescResponsable.Size = New Size(127, 22)
        Me.lblDescResponsable.TabIndex = 1
        Me.lblDescResponsable.TextAlign = ContentAlignment.BottomLeft
        '
        'lblDescEmisor
        '
        Me.lblDescEmisor.BackColor = Color.Cyan
        Me.lblDescEmisor.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescEmisor.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescEmisor.Location = New Point(656, 69)
        Me.lblDescEmisor.Name = "lblDescEmisor"
        Me.lblDescEmisor.Size = New Size(127, 22)
        Me.lblDescEmisor.TabIndex = 1
        Me.lblDescEmisor.TextAlign = ContentAlignment.BottomLeft
        '
        'lblDescTipo
        '
        Me.lblDescTipo.BackColor = Color.Cyan
        Me.lblDescTipo.BorderStyle = BorderStyle.Fixed3D
        Me.lblDescTipo.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescTipo.Location = New Point(111, 19)
        Me.lblDescTipo.Name = "lblDescTipo"
        Me.lblDescTipo.Size = New Size(225, 22)
        Me.lblDescTipo.TabIndex = 1
        Me.lblDescTipo.TextAlign = ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(417, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(44, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New Point(464, 20)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New Size(53, 20)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TextAlign = HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(337, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New Point(366, 20)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New Size(45, 20)
        Me.txtAnio.TabIndex = 0
        Me.txtAnio.TextAlign = HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New Point(573, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Centro"
        '
        'txtCentro
        '
        Me.txtCentro.Location = New Point(617, 45)
        Me.txtCentro.Name = "txtCentro"
        Me.txtCentro.Size = New Size(32, 20)
        Me.txtCentro.TabIndex = 0
        Me.txtCentro.TextAlign = HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New Point(321, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New Size(40, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Estado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New Point(152, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New Size(38, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Origen"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New Point(30, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(37, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New Point(542, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New Size(69, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Responsable"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New Point(39, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(28, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Tipo"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New Point(617, 96)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New Size(32, 20)
        Me.txtResponsable.TabIndex = 0
        Me.txtResponsable.TextAlign = HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New Point(573, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New Size(38, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Emisor"
        '
        'txtEmisor
        '
        Me.txtEmisor.Location = New Point(617, 70)
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New Size(32, 20)
        Me.txtEmisor.TabIndex = 0
        Me.txtEmisor.TextAlign = HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New Point(8, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New Size(59, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New Point(76, 97)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New Size(460, 20)
        Me.txtReferencia.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New Point(34, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New Size(33, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Titulo"
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New Point(76, 74)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New Size(460, 20)
        Me.txtTitulo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(39, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(28, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New Point(76, 20)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New Size(31, 20)
        Me.txtTipo.TabIndex = 0
        Me.txtTipo.TextAlign = HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = DockStyle.Fill
        Me.TabControl1.Font = New Font("Microsoft Sans Serif", 13.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New Size(167, 25)
        Me.TabControl1.Location = New Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New Size(1025, 366)
        Me.TabControl1.SizeMode = TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.txtIngresoCausa)
        Me.TabPage1.Controls.Add(Me.txtIngresoNoCon)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New Padding(3)
        Me.TabPage1.Size = New Size(1017, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Descripción"
        '
        'txtIngresoCausa
        '
        Me.txtIngresoCausa.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoCausa.Location = New Point(515, 48)
        Me.txtIngresoCausa.Multiline = True
        Me.txtIngresoCausa.Name = "txtIngresoCausa"
        Me.txtIngresoCausa.ScrollBars = ScrollBars.Both
        Me.txtIngresoCausa.Size = New Size(467, 231)
        Me.txtIngresoCausa.TabIndex = 0
        '
        'txtIngresoNoCon
        '
        Me.txtIngresoNoCon.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoNoCon.Location = New Point(25, 48)
        Me.txtIngresoNoCon.Multiline = True
        Me.txtIngresoNoCon.Name = "txtIngresoNoCon"
        Me.txtIngresoNoCon.ScrollBars = ScrollBars.Both
        Me.txtIngresoNoCon.Size = New Size(467, 231)
        Me.txtIngresoNoCon.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.BackColor = SystemColors.ControlLight
        Me.Label20.BorderStyle = BorderStyle.Fixed3D
        Me.Label20.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New Point(515, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New Size(467, 26)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Causas que la Originaron"
        Me.Label20.TextAlign = ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.BackColor = SystemColors.ControlLight
        Me.Label19.BorderStyle = BorderStyle.Fixed3D
        Me.Label19.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New Point(25, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New Size(467, 26)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Descripción de No Conformidad"
        Me.Label19.TextAlign = ContentAlignment.TopCenter
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = SystemColors.Control
        Me.TabPage2.BorderStyle = BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.txtFechaAux)
        Me.TabPage2.Controls.Add(Me.dgvAcciones)
        Me.TabPage2.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New Padding(3)
        Me.TabPage2.Size = New Size(1017, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acciones"
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = BorderStyle.None
        Me.txtFechaAux.Location = New Point(931, 50)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = ChrW(32)
        Me.txtFechaAux.Size = New Size(58, 13)
        Me.txtFechaAux.TabIndex = 2
        Me.txtFechaAux.TextAlign = HorizontalAlignment.Center
        Me.txtFechaAux.Visible = False
        '
        'dgvAcciones
        '
        Me.dgvAcciones.AllowUserToAddRows = False
        Me.dgvAcciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = SystemColors.Control
        DataGridViewCellStyle39.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle39.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle39.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle39.WrapMode = DataGridViewTriState.[True]
        Me.dgvAcciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle39
        Me.dgvAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAcciones.Columns.AddRange(New DataGridViewColumn() {Me.idAccion, Me.Acciones, Me.Responsable, Me.DescResponsable, Me.Plazo})
        DataGridViewCellStyle67.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = SystemColors.Window
        DataGridViewCellStyle67.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle67.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = DataGridViewTriState.[True]
        Me.dgvAcciones.DefaultCellStyle = DataGridViewCellStyle67
        Me.dgvAcciones.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvAcciones.Location = New Point(6, 6)
        Me.dgvAcciones.Name = "dgvAcciones"
        DataGridViewCellStyle68.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle68.BackColor = SystemColors.Control
        DataGridViewCellStyle68.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle68.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle68.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle68.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle68.WrapMode = DataGridViewTriState.[True]
        Me.dgvAcciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle68
        Me.dgvAcciones.RowHeadersWidth = 20
        DataGridViewCellStyle69.WrapMode = DataGridViewTriState.[True]
        Me.dgvAcciones.RowsDefaultCellStyle = DataGridViewCellStyle69
        Me.dgvAcciones.RowTemplate.Height = 20
        Me.dgvAcciones.Size = New Size(986, 293)
        Me.dgvAcciones.TabIndex = 0
        '
        'idAccion
        '
        DataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.idAccion.DefaultCellStyle = DataGridViewCellStyle44
        Me.idAccion.HeaderText = "Nº"
        Me.idAccion.Name = "idAccion"
        Me.idAccion.ReadOnly = True
        Me.idAccion.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.idAccion.Width = 35
        '
        'Acciones
        '
        Me.Acciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle45.WrapMode = DataGridViewTriState.[True]
        Me.Acciones.DefaultCellStyle = DataGridViewCellStyle45
        Me.Acciones.HeaderText = "Acciones Correctivas"
        Me.Acciones.Name = "Acciones"
        Me.Acciones.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'Responsable
        '
        Me.Responsable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.Responsable.DefaultCellStyle = DataGridViewCellStyle46
        Me.Responsable.HeaderText = "Resp."
        Me.Responsable.Name = "Responsable"
        Me.Responsable.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.Responsable.Width = 41
        '
        'DescResponsable
        '
        Me.DescResponsable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescResponsable.HeaderText = "Descripción"
        Me.DescResponsable.Name = "DescResponsable"
        Me.DescResponsable.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.DescResponsable.Width = 69
        '
        'Plazo
        '
        Me.Plazo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle66.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.Plazo.DefaultCellStyle = DataGridViewCellStyle66
        Me.Plazo.HeaderText = "Plazo"
        Me.Plazo.MinimumWidth = 70
        Me.Plazo.Name = "Plazo"
        Me.Plazo.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.Plazo.Width = 70
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = SystemColors.Control
        Me.TabPage3.BorderStyle = BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.txtFechaAux2)
        Me.TabPage3.Controls.Add(Me.dgvImplementaciones)
        Me.TabPage3.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New Size(1017, 333)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Implementaciones"
        '
        'txtFechaAux2
        '
        Me.txtFechaAux2.BorderStyle = BorderStyle.None
        Me.txtFechaAux2.Location = New Point(470, 137)
        Me.txtFechaAux2.Mask = "00/00/0000"
        Me.txtFechaAux2.Name = "txtFechaAux2"
        Me.txtFechaAux2.PromptChar = ChrW(32)
        Me.txtFechaAux2.Size = New Size(58, 13)
        Me.txtFechaAux2.TabIndex = 3
        Me.txtFechaAux2.TextAlign = HorizontalAlignment.Center
        Me.txtFechaAux2.Visible = False
        '
        'dgvImplementaciones
        '
        Me.dgvImplementaciones.AllowUserToAddRows = False
        Me.dgvImplementaciones.AllowUserToDeleteRows = False
        Me.dgvImplementaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImplementaciones.Columns.AddRange(New DataGridViewColumn() {Me.ImpleIdAccion, Me.ImpleAcciones, Me.ImpleResponsable, Me.ImpleDescResponsable, Me.ImpleFecha, Me.Estado, Me.Comentarios})
        DataGridViewCellStyle75.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle75.BackColor = SystemColors.Window
        DataGridViewCellStyle75.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle75.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle75.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle75.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle75.WrapMode = DataGridViewTriState.[False]
        Me.dgvImplementaciones.DefaultCellStyle = DataGridViewCellStyle75
        Me.dgvImplementaciones.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvImplementaciones.Location = New Point(6, 6)
        Me.dgvImplementaciones.Name = "dgvImplementaciones"
        Me.dgvImplementaciones.RowHeadersWidth = 20
        DataGridViewCellStyle76.WrapMode = DataGridViewTriState.[False]
        Me.dgvImplementaciones.RowsDefaultCellStyle = DataGridViewCellStyle76
        Me.dgvImplementaciones.RowTemplate.Height = 20
        Me.dgvImplementaciones.Size = New Size(986, 293)
        Me.dgvImplementaciones.TabIndex = 1
        '
        'ImpleIdAccion
        '
        DataGridViewCellStyle70.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.ImpleIdAccion.DefaultCellStyle = DataGridViewCellStyle70
        Me.ImpleIdAccion.HeaderText = "Nº"
        Me.ImpleIdAccion.Name = "ImpleIdAccion"
        Me.ImpleIdAccion.ReadOnly = True
        Me.ImpleIdAccion.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.ImpleIdAccion.Width = 35
        '
        'ImpleAcciones
        '
        Me.ImpleAcciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle71.WrapMode = DataGridViewTriState.[True]
        Me.ImpleAcciones.DefaultCellStyle = DataGridViewCellStyle71
        Me.ImpleAcciones.HeaderText = "Acciones Correctivas"
        Me.ImpleAcciones.Name = "ImpleAcciones"
        Me.ImpleAcciones.ReadOnly = True
        Me.ImpleAcciones.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'ImpleResponsable
        '
        Me.ImpleResponsable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle72.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.ImpleResponsable.DefaultCellStyle = DataGridViewCellStyle72
        Me.ImpleResponsable.HeaderText = "Resp."
        Me.ImpleResponsable.Name = "ImpleResponsable"
        Me.ImpleResponsable.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.ImpleResponsable.Width = 41
        '
        'ImpleDescResponsable
        '
        Me.ImpleDescResponsable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ImpleDescResponsable.HeaderText = "Descripción"
        Me.ImpleDescResponsable.Name = "ImpleDescResponsable"
        Me.ImpleDescResponsable.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.ImpleDescResponsable.Width = 69
        '
        'ImpleFecha
        '
        Me.ImpleFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle73.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.ImpleFecha.DefaultCellStyle = DataGridViewCellStyle73
        Me.ImpleFecha.HeaderText = "Fecha"
        Me.ImpleFecha.MinimumWidth = 70
        Me.ImpleFecha.Name = "ImpleFecha"
        Me.ImpleFecha.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.ImpleFecha.Width = 70
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle74.NullValue = " "
        Me.Estado.DefaultCellStyle = DataGridViewCellStyle74
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Items.AddRange(New Object() {"", "Imple.", "Nula"})
        Me.Estado.MinimumWidth = 70
        Me.Estado.Name = "Estado"
        Me.Estado.Resizable = DataGridViewTriState.[True]
        Me.Estado.Width = 70
        '
        'Comentarios
        '
        Me.Comentarios.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Comentarios.HeaderText = "Comentarios"
        Me.Comentarios.MaxInputLength = 100
        Me.Comentarios.MinimumWidth = 100
        Me.Comentarios.Name = "Comentarios"
        Me.Comentarios.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = SystemColors.Control
        Me.TabPage4.BorderStyle = BorderStyle.Fixed3D
        Me.TabPage4.Controls.Add(Me.txtFechaAux4)
        Me.TabPage4.Controls.Add(Me.txtFechaAux3)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.btnInmovilizarAcciones)
        Me.TabPage4.Controls.Add(Me.dgvVerificaciones)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New Size(1017, 333)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Verificación"
        '
        'txtFechaAux4
        '
        Me.txtFechaAux4.BorderStyle = BorderStyle.None
        Me.txtFechaAux4.Location = New Point(696, 151)
        Me.txtFechaAux4.Mask = "00/00/0000"
        Me.txtFechaAux4.Name = "txtFechaAux4"
        Me.txtFechaAux4.PromptChar = ChrW(32)
        Me.txtFechaAux4.Size = New Size(58, 13)
        Me.txtFechaAux4.TabIndex = 10
        Me.txtFechaAux4.TextAlign = HorizontalAlignment.Center
        Me.txtFechaAux4.Visible = False
        '
        'txtFechaAux3
        '
        Me.txtFechaAux3.BorderStyle = BorderStyle.None
        Me.txtFechaAux3.Location = New Point(470, 151)
        Me.txtFechaAux3.Mask = "00/00/0000"
        Me.txtFechaAux3.Name = "txtFechaAux3"
        Me.txtFechaAux3.PromptChar = ChrW(32)
        Me.txtFechaAux3.Size = New Size(58, 13)
        Me.txtFechaAux3.TabIndex = 9
        Me.txtFechaAux3.TextAlign = HorizontalAlignment.Center
        Me.txtFechaAux3.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = Color.Green
        Me.Label14.BorderStyle = BorderStyle.Fixed3D
        Me.Label14.Location = New Point(587, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New Size(31, 18)
        Me.Label14.TabIndex = 8
        Me.Label14.TextAlign = ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = SystemColors.ControlLight
        Me.Label18.BorderStyle = BorderStyle.Fixed3D
        Me.Label18.Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New Point(623, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New Size(245, 18)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Verificación Efectividad"
        Me.Label18.TextAlign = ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = SystemColors.ControlLight
        Me.Label17.BorderStyle = BorderStyle.Fixed3D
        Me.Label17.Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New Point(302, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New Size(245, 18)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Verficación Implementración"
        Me.Label17.TextAlign = ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = Color.Orange
        Me.Label12.BorderStyle = BorderStyle.Fixed3D
        Me.Label12.Location = New Point(265, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New Size(31, 18)
        Me.Label12.TabIndex = 8
        Me.Label12.TextAlign = ContentAlignment.MiddleCenter
        '
        'btnInmovilizarAcciones
        '
        Me.btnInmovilizarAcciones.Location = New Point(21, 3)
        Me.btnInmovilizarAcciones.Name = "btnInmovilizarAcciones"
        Me.btnInmovilizarAcciones.Size = New Size(142, 22)
        Me.btnInmovilizarAcciones.TabIndex = 7
        Me.btnInmovilizarAcciones.Text = "Inmov. Columna"
        Me.btnInmovilizarAcciones.UseVisualStyleBackColor = True
        '
        'dgvVerificaciones
        '
        Me.dgvVerificaciones.AllowUserToAddRows = False
        Me.dgvVerificaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle77.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle77.BackColor = SystemColors.Control
        DataGridViewCellStyle77.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle77.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle77.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle77.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle77.WrapMode = DataGridViewTriState.[False]
        Me.dgvVerificaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle77
        Me.dgvVerificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVerificaciones.Columns.AddRange(New DataGridViewColumn() {Me.VerIdAcciones, Me.VerAcciones, Me.VerResponsableI, Me.VerDescResponsableI, Me.VerFechaI, Me.VerEstadoI, Me.VerResponsableII, Me.VerDescResponsableII, Me.VerFechaII, Me.VerEstadoII, Me.VerComentario})
        Me.dgvVerificaciones.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle82.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle82.BackColor = SystemColors.Window
        DataGridViewCellStyle82.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle82.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle82.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle82.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle82.WrapMode = DataGridViewTriState.[False]
        Me.dgvVerificaciones.DefaultCellStyle = DataGridViewCellStyle82
        Me.dgvVerificaciones.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvVerificaciones.Location = New Point(6, 29)
        Me.dgvVerificaciones.Name = "dgvVerificaciones"
        DataGridViewCellStyle83.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle83.BackColor = SystemColors.Control
        DataGridViewCellStyle83.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle83.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle83.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle83.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle83.WrapMode = DataGridViewTriState.[False]
        Me.dgvVerificaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle83
        Me.dgvVerificaciones.RowHeadersWidth = 15
        DataGridViewCellStyle84.WrapMode = DataGridViewTriState.[False]
        Me.dgvVerificaciones.RowsDefaultCellStyle = DataGridViewCellStyle84
        Me.dgvVerificaciones.RowTemplate.Height = 20
        Me.dgvVerificaciones.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect
        Me.dgvVerificaciones.Size = New Size(987, 288)
        Me.dgvVerificaciones.TabIndex = 6
        '
        'VerIdAcciones
        '
        Me.VerIdAcciones.HeaderText = "Nº"
        Me.VerIdAcciones.Name = "VerIdAcciones"
        Me.VerIdAcciones.ReadOnly = True
        Me.VerIdAcciones.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerIdAcciones.Width = 35
        '
        'VerAcciones
        '
        Me.VerAcciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle78.WrapMode = DataGridViewTriState.[False]
        Me.VerAcciones.DefaultCellStyle = DataGridViewCellStyle78
        Me.VerAcciones.HeaderText = "Acciones Correctivas"
        Me.VerAcciones.MinimumWidth = 200
        Me.VerAcciones.Name = "VerAcciones"
        Me.VerAcciones.ReadOnly = True
        Me.VerAcciones.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerAcciones.Width = 200
        '
        'VerResponsableI
        '
        DataGridViewCellStyle79.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.VerResponsableI.DefaultCellStyle = DataGridViewCellStyle79
        Me.VerResponsableI.HeaderText = "Resp."
        Me.VerResponsableI.Name = "VerResponsableI"
        Me.VerResponsableI.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerResponsableI.Width = 45
        '
        'VerDescResponsableI
        '
        Me.VerDescResponsableI.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerDescResponsableI.HeaderText = "Descripción"
        Me.VerDescResponsableI.MinimumWidth = 100
        Me.VerDescResponsableI.Name = "VerDescResponsableI"
        Me.VerDescResponsableI.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'VerFechaI
        '
        DataGridViewCellStyle80.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.VerFechaI.DefaultCellStyle = DataGridViewCellStyle80
        Me.VerFechaI.HeaderText = "Fecha"
        Me.VerFechaI.Name = "VerFechaI"
        Me.VerFechaI.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerFechaI.Width = 70
        '
        'VerEstadoI
        '
        Me.VerEstadoI.HeaderText = "Estado"
        Me.VerEstadoI.Items.AddRange(New Object() {"No Imple.", "Imple.", "Nula", "Cerrada"})
        Me.VerEstadoI.Name = "VerEstadoI"
        Me.VerEstadoI.Resizable = DataGridViewTriState.[True]
        '
        'VerResponsableII
        '
        Me.VerResponsableII.HeaderText = "Resp."
        Me.VerResponsableII.Name = "VerResponsableII"
        Me.VerResponsableII.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerResponsableII.Width = 45
        '
        'VerDescResponsableII
        '
        Me.VerDescResponsableII.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerDescResponsableII.HeaderText = "Descripción"
        Me.VerDescResponsableII.MinimumWidth = 100
        Me.VerDescResponsableII.Name = "VerDescResponsableII"
        Me.VerDescResponsableII.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'VerFechaII
        '
        DataGridViewCellStyle81.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.VerFechaII.DefaultCellStyle = DataGridViewCellStyle81
        Me.VerFechaII.HeaderText = "Fecha"
        Me.VerFechaII.Name = "VerFechaII"
        Me.VerFechaII.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.VerFechaII.Width = 70
        '
        'VerEstadoII
        '
        Me.VerEstadoII.HeaderText = "Estado"
        Me.VerEstadoII.Items.AddRange(New Object() {"No Imple.", "Imple.", "Nula", "Cerrada"})
        Me.VerEstadoII.Name = "VerEstadoII"
        Me.VerEstadoII.Resizable = DataGridViewTriState.[True]
        '
        'VerComentario
        '
        Me.VerComentario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerComentario.HeaderText = "Comentarios"
        Me.VerComentario.MaxInputLength = 100
        Me.VerComentario.MinimumWidth = 100
        Me.VerComentario.Name = "VerComentario"
        Me.VerComentario.SortMode = DataGridViewColumnSortMode.NotSortable
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Me.MovilizarInmovilizarAccionesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New Size(237, 26)
        '
        'MovilizarInmovilizarAccionesToolStripMenuItem
        '
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Name = "MovilizarInmovilizarAccionesToolStripMenuItem"
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Size = New Size(236, 22)
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Text = "Movilizar/Inmovilizar Acciones"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New Point(195, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New Size(64, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Referencias"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = SystemColors.Control
        Me.TabPage5.BorderStyle = BorderStyle.Fixed3D
        Me.TabPage5.Controls.Add(Me.txtComentarios)
        Me.TabPage5.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New Padding(3)
        Me.TabPage5.Size = New Size(1017, 333)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Comentarios"
        '
        'txtComentarios
        '
        Me.txtComentarios.Font = New Font("Microsoft Sans Serif", 11.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarios.Location = New Point(13, 6)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.ScrollBars = ScrollBars.Vertical
        Me.txtComentarios.Size = New Size(972, 303)
        Me.txtComentarios.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = SystemColors.Control
        Me.TabPage6.Controls.Add(Me.Button2)
        Me.TabPage6.Controls.Add(Me.Button1)
        Me.TabPage6.Controls.Add(Me.dgvArchivos)
        Me.TabPage6.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage6.Location = New Point(4, 29)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New Padding(3)
        Me.TabPage6.Size = New Size(1017, 333)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Archivos"
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New DataGridViewColumn() {Me.FechaArchivo, Me.DescArchivo, Me.Icono, Me.PathArchivo})
        Me.dgvArchivos.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgvArchivos.Location = New Point(9, 8)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersWidth = 15
        Me.dgvArchivos.RowTemplate.Height = 30
        Me.dgvArchivos.ShowCellToolTips = False
        Me.dgvArchivos.Size = New Size(1000, 282)
        Me.dgvArchivos.TabIndex = 0
        '
        'FechaArchivo
        '
        Me.FechaArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaArchivo.HeaderText = "Fecha"
        Me.FechaArchivo.Name = "FechaArchivo"
        Me.FechaArchivo.ReadOnly = True
        Me.FechaArchivo.Width = 62
        '
        'DescArchivo
        '
        Me.DescArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DescArchivo.HeaderText = "Descripción"
        Me.DescArchivo.Name = "DescArchivo"
        Me.DescArchivo.ReadOnly = True
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = DataGridViewTriState.[True]
        Me.Icono.SortMode = DataGridViewColumnSortMode.Automatic
        Me.Icono.Width = 50
        '
        'PathArchivo
        '
        Me.PathArchivo.HeaderText = "Path"
        Me.PathArchivo.Name = "PathArchivo"
        Me.PathArchivo.ReadOnly = True
        Me.PathArchivo.Visible = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New ToolStripItem() {Me.EliminarArchivoToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New Size(162, 26)
        Me.ContextMenuStrip2.Text = "Eliminar Archivo"
        '
        'EliminarArchivoToolStripMenuItem
        '
        Me.EliminarArchivoToolStripMenuItem.Name = "EliminarArchivoToolStripMenuItem"
        Me.EliminarArchivoToolStripMenuItem.Size = New Size(161, 22)
        Me.EliminarArchivoToolStripMenuItem.Text = "Eliminar Archivo"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = DockStyle.Fill
        Me.Panel2.Location = New Point(0, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(1025, 366)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.btnExportar)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = DockStyle.Top
        Me.Panel3.Location = New Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(1025, 138)
        Me.Panel3.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNumeroSiguiente)
        Me.GroupBox3.Controls.Add(Me.btnNumeroAnterior)
        Me.GroupBox3.Location = New Point(831, 53)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New Size(182, 48)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Navegar Por Numero"
        '
        'btnNumeroSiguiente
        '
        Me.btnNumeroSiguiente.Location = New Point(93, 17)
        Me.btnNumeroSiguiente.Name = "btnNumeroSiguiente"
        Me.btnNumeroSiguiente.Size = New Size(77, 24)
        Me.btnNumeroSiguiente.TabIndex = 7
        Me.btnNumeroSiguiente.Text = "Siguiente"
        Me.btnNumeroSiguiente.UseVisualStyleBackColor = True
        '
        'btnNumeroAnterior
        '
        Me.btnNumeroAnterior.Location = New Point(13, 17)
        Me.btnNumeroAnterior.Name = "btnNumeroAnterior"
        Me.btnNumeroAnterior.Size = New Size(77, 24)
        Me.btnNumeroAnterior.TabIndex = 6
        Me.btnNumeroAnterior.Text = "Anterior"
        Me.btnNumeroAnterior.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTipoSiguiente)
        Me.GroupBox2.Controls.Add(Me.btnTipoAnterior)
        Me.GroupBox2.Location = New Point(831, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New Size(182, 48)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Navegar Por Tipo"
        '
        'btnTipoSiguiente
        '
        Me.btnTipoSiguiente.Location = New Point(93, 17)
        Me.btnTipoSiguiente.Name = "btnTipoSiguiente"
        Me.btnTipoSiguiente.Size = New Size(77, 24)
        Me.btnTipoSiguiente.TabIndex = 7
        Me.btnTipoSiguiente.Text = "Siguiente"
        Me.btnTipoSiguiente.UseVisualStyleBackColor = True
        '
        'btnTipoAnterior
        '
        Me.btnTipoAnterior.Location = New Point(13, 17)
        Me.btnTipoAnterior.Name = "btnTipoAnterior"
        Me.btnTipoAnterior.Size = New Size(77, 24)
        Me.btnTipoAnterior.TabIndex = 6
        Me.btnTipoAnterior.Text = "Anterior"
        Me.btnTipoAnterior.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New Point(831, 105)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New Size(182, 24)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar Datos"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Location = New Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(1025, 36)
        Me.Panel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left), AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = SystemColors.Control
        Me.Label3.Location = New Point(25, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(100, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ingreso de SAC"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = SystemColors.Control
        Me.Label6.Location = New Point(905, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(108, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = AnchorStyles.Bottom
        Me.btnGrabar.Location = New Point(196, 5)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New Size(96, 37)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Anchor = AnchorStyles.Bottom
        Me.btnConsultas.Location = New Point(330, 5)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New Size(96, 37)
        Me.btnConsultas.TabIndex = 7
        Me.btnConsultas.Text = "Consultas"
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = AnchorStyles.Bottom
        Me.btnImprimir.Location = New Point(464, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New Size(96, 37)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = AnchorStyles.Bottom
        Me.btnLimpiar.Location = New Point(598, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New Size(96, 37)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = AnchorStyles.Bottom
        Me.btnCerrar.Location = New Point(732, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(96, 37)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnGrabar)
        Me.Panel4.Controls.Add(Me.btnConsultas)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Controls.Add(Me.btnImprimir)
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Dock = DockStyle.Bottom
        Me.Panel4.Location = New Point(0, 540)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New Size(1025, 47)
        Me.Panel4.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New Point(9, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(164, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar Archivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New Point(179, 296)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(164, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Eliminar Archivo(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'NuevoSac
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1025, 587)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New Point(5, 5)
        Me.Name = "NuevoSac"
        Me.StartPosition = FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvAcciones, ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvImplementaciones, ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvVerificaciones, ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dgvArchivos, ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblDescTipo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents lblDescCentro As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAnio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCentro As TextBox
    Friend WithEvents txtFecha As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents cmbOrigen As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblDescResponsable As Label
    Friend WithEvents lblDescEmisor As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmisor As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTitulo As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtIngresoNoCon As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtIngresoCausa As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvAcciones As DataGridView
    Friend WithEvents txtFechaAux As MaskedTextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvImplementaciones As DataGridView
    Friend WithEvents txtFechaAux2 As MaskedTextBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MovilizarInmovilizarAccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnInmovilizarAcciones As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFechaAux4 As MaskedTextBox
    Friend WithEvents txtFechaAux3 As MaskedTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents txtComentarios As TextBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnConsultas As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents dgvVerificaciones As DataGridView
    Friend WithEvents btnProximoNumeroLibre As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents idAccion As DataGridViewTextBoxColumn
    Friend WithEvents Acciones As DataGridViewTextBoxColumn
    Friend WithEvents Responsable As DataGridViewTextBoxColumn
    Friend WithEvents DescResponsable As DataGridViewTextBoxColumn
    Friend WithEvents Plazo As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnNumeroSiguiente As Button
    Friend WithEvents btnNumeroAnterior As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnTipoSiguiente As Button
    Friend WithEvents btnTipoAnterior As Button
    Friend WithEvents VerIdAcciones As DataGridViewTextBoxColumn
    Friend WithEvents VerAcciones As DataGridViewTextBoxColumn
    Friend WithEvents VerResponsableI As DataGridViewTextBoxColumn
    Friend WithEvents VerDescResponsableI As DataGridViewTextBoxColumn
    Friend WithEvents VerFechaI As DataGridViewTextBoxColumn
    Friend WithEvents VerEstadoI As DataGridViewComboBoxColumn
    Friend WithEvents VerResponsableII As DataGridViewTextBoxColumn
    Friend WithEvents VerDescResponsableII As DataGridViewTextBoxColumn
    Friend WithEvents VerFechaII As DataGridViewTextBoxColumn
    Friend WithEvents VerEstadoII As DataGridViewComboBoxColumn
    Friend WithEvents VerComentario As DataGridViewTextBoxColumn
    Friend WithEvents ImpleIdAccion As DataGridViewTextBoxColumn
    Friend WithEvents ImpleAcciones As DataGridViewTextBoxColumn
    Friend WithEvents ImpleResponsable As DataGridViewTextBoxColumn
    Friend WithEvents ImpleDescResponsable As DataGridViewTextBoxColumn
    Friend WithEvents ImpleFecha As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewComboBoxColumn
    Friend WithEvents Comentarios As DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents dgvArchivos As DataGridView
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents EliminarArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FechaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents DescArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Icono As DataGridViewImageColumn
    Friend WithEvents PathArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
