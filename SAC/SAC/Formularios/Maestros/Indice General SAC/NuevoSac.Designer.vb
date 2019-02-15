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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnProximoNumeroLibre = New System.Windows.Forms.Button()
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtIngresoCausa = New System.Windows.Forms.TextBox()
        Me.txtIngresoNoCon = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvAcciones = New System.Windows.Forms.DataGridView()
        Me.idAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plazo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtFechaAux2 = New System.Windows.Forms.MaskedTextBox()
        Me.dgvImplementaciones = New System.Windows.Forms.DataGridView()
        Me.ImpleIdAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpleAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpleResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpleDescResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpleFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Comentarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtFechaAux4 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaAux3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnInmovilizarAcciones = New System.Windows.Forms.Button()
        Me.dgvVerificaciones = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MovilizarInmovilizarAccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.FechaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icono = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PathArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.dgvIncidencias = New System.Windows.Forms.DataGridView()
        Me.Incidencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Renglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveSAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnNumeroSiguiente = New System.Windows.Forms.Button()
        Me.btnNumeroAnterior = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnTipoSiguiente = New System.Windows.Forms.Button()
        Me.btnTipoAnterior = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.VerIdAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerResponsableI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerDescResponsableI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerFechaI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerEstadoI = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VerResponsableII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerDescResponsableII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerFechaII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerEstadoII = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VerComentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvImplementaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvVerificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgvIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(803, 128)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales SAC"
        '
        'btnProximoNumeroLibre
        '
        Me.btnProximoNumeroLibre.Location = New System.Drawing.Point(533, 19)
        Me.btnProximoNumeroLibre.Name = "btnProximoNumeroLibre"
        Me.btnProximoNumeroLibre.Size = New System.Drawing.Size(151, 21)
        Me.btnProximoNumeroLibre.TabIndex = 4
        Me.btnProximoNumeroLibre.Text = "Traer Próximo Numero Libre"
        Me.btnProximoNumeroLibre.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"", "Iniciada", "Investigación", "Implementación", "Implementación a Verificar", "Implementación Verificada", "Cerrada"})
        Me.cmbEstado.Location = New System.Drawing.Point(365, 46)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'cmbOrigen
        '
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Items.AddRange(New Object() {"", "Auditoría", "Reclamo", "I. de No Conformidad", "Proceso / Sist", "Otro"})
        Me.cmbOrigen.Location = New System.Drawing.Point(196, 46)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(121, 21)
        Me.cmbOrigen.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(76, 46)
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
        Me.lblDescCentro.Location = New System.Drawing.Point(656, 44)
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
        Me.lblDescResponsable.Location = New System.Drawing.Point(656, 95)
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
        Me.lblDescEmisor.Location = New System.Drawing.Point(656, 69)
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
        Me.lblDescTipo.Location = New System.Drawing.Point(111, 19)
        Me.lblDescTipo.Name = "lblDescTipo"
        Me.lblDescTipo.Size = New System.Drawing.Size(225, 22)
        Me.lblDescTipo.TabIndex = 1
        Me.lblDescTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(417, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(464, 20)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(53, 20)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(337, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(366, 20)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(45, 20)
        Me.txtAnio.TabIndex = 0
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(573, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Centro"
        '
        'txtCentro
        '
        Me.txtCentro.Location = New System.Drawing.Point(617, 45)
        Me.txtCentro.Name = "txtCentro"
        Me.txtCentro.Size = New System.Drawing.Size(32, 20)
        Me.txtCentro.TabIndex = 0
        Me.txtCentro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(321, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Estado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(152, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Origen"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(542, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Responsable"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Tipo"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(617, 96)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(32, 20)
        Me.txtResponsable.TabIndex = 0
        Me.txtResponsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(573, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Emisor"
        '
        'txtEmisor
        '
        Me.txtEmisor.Location = New System.Drawing.Point(617, 70)
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(32, 20)
        Me.txtEmisor.TabIndex = 0
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(76, 97)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(460, 20)
        Me.txtReferencia.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Titulo"
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(76, 74)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(460, 20)
        Me.txtTitulo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(76, 20)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(31, 20)
        Me.txtTipo.TabIndex = 0
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(147, 25)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(1037, 366)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
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
        Me.TabPage1.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Descripción"
        '
        'txtIngresoCausa
        '
        Me.txtIngresoCausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoCausa.Location = New System.Drawing.Point(524, 48)
        Me.txtIngresoCausa.Multiline = True
        Me.txtIngresoCausa.Name = "txtIngresoCausa"
        Me.txtIngresoCausa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtIngresoCausa.Size = New System.Drawing.Size(467, 231)
        Me.txtIngresoCausa.TabIndex = 0
        '
        'txtIngresoNoCon
        '
        Me.txtIngresoNoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresoNoCon.Location = New System.Drawing.Point(34, 48)
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
        Me.Label20.Location = New System.Drawing.Point(524, 15)
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
        Me.Label19.Location = New System.Drawing.Point(34, 15)
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
        Me.TabPage2.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acciones"
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(949, 48)
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
        Me.dgvAcciones.Size = New System.Drawing.Size(1013, 293)
        Me.dgvAcciones.TabIndex = 0
        '
        'idAccion
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.idAccion.DefaultCellStyle = DataGridViewCellStyle2
        Me.idAccion.HeaderText = "Nº"
        Me.idAccion.Name = "idAccion"
        Me.idAccion.ReadOnly = True
        Me.idAccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idAccion.Width = 35
        '
        'Acciones
        '
        Me.Acciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Acciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.Acciones.HeaderText = "Acciones Correctivas"
        Me.Acciones.Name = "Acciones"
        Me.Acciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Responsable
        '
        Me.Responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Responsable.DefaultCellStyle = DataGridViewCellStyle4
        Me.Responsable.HeaderText = "Resp."
        Me.Responsable.Name = "Responsable"
        Me.Responsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Responsable.Width = 41
        '
        'DescResponsable
        '
        Me.DescResponsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescResponsable.HeaderText = "Descripción"
        Me.DescResponsable.Name = "DescResponsable"
        Me.DescResponsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DescResponsable.Width = 69
        '
        'Plazo
        '
        Me.Plazo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Plazo.DefaultCellStyle = DataGridViewCellStyle5
        Me.Plazo.HeaderText = "Plazo"
        Me.Plazo.MinimumWidth = 70
        Me.Plazo.Name = "Plazo"
        Me.Plazo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Plazo.Width = 70
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.txtFechaAux2)
        Me.TabPage3.Controls.Add(Me.dgvImplementaciones)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Implementaciones"
        '
        'txtFechaAux2
        '
        Me.txtFechaAux2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux2.Location = New System.Drawing.Point(470, 137)
        Me.txtFechaAux2.Mask = "00/00/0000"
        Me.txtFechaAux2.Name = "txtFechaAux2"
        Me.txtFechaAux2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux2.Size = New System.Drawing.Size(58, 13)
        Me.txtFechaAux2.TabIndex = 3
        Me.txtFechaAux2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaAux2.Visible = False
        '
        'dgvImplementaciones
        '
        Me.dgvImplementaciones.AllowUserToAddRows = False
        Me.dgvImplementaciones.AllowUserToDeleteRows = False
        Me.dgvImplementaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImplementaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ImpleIdAccion, Me.ImpleAcciones, Me.ImpleResponsable, Me.ImpleDescResponsable, Me.ImpleFecha, Me.Estado, Me.Comentarios})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvImplementaciones.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvImplementaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvImplementaciones.Location = New System.Drawing.Point(5, 6)
        Me.dgvImplementaciones.Name = "dgvImplementaciones"
        Me.dgvImplementaciones.RowHeadersWidth = 20
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvImplementaciones.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvImplementaciones.RowTemplate.Height = 20
        Me.dgvImplementaciones.Size = New System.Drawing.Size(1015, 293)
        Me.dgvImplementaciones.TabIndex = 1
        '
        'ImpleIdAccion
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ImpleIdAccion.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImpleIdAccion.HeaderText = "Nº"
        Me.ImpleIdAccion.Name = "ImpleIdAccion"
        Me.ImpleIdAccion.ReadOnly = True
        Me.ImpleIdAccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpleIdAccion.Width = 35
        '
        'ImpleAcciones
        '
        Me.ImpleAcciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ImpleAcciones.DefaultCellStyle = DataGridViewCellStyle10
        Me.ImpleAcciones.HeaderText = "Acciones Correctivas"
        Me.ImpleAcciones.Name = "ImpleAcciones"
        Me.ImpleAcciones.ReadOnly = True
        Me.ImpleAcciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ImpleResponsable
        '
        Me.ImpleResponsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ImpleResponsable.DefaultCellStyle = DataGridViewCellStyle11
        Me.ImpleResponsable.HeaderText = "Resp."
        Me.ImpleResponsable.Name = "ImpleResponsable"
        Me.ImpleResponsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpleResponsable.Width = 41
        '
        'ImpleDescResponsable
        '
        Me.ImpleDescResponsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ImpleDescResponsable.HeaderText = "Descripción"
        Me.ImpleDescResponsable.Name = "ImpleDescResponsable"
        Me.ImpleDescResponsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpleDescResponsable.Width = 69
        '
        'ImpleFecha
        '
        Me.ImpleFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ImpleFecha.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImpleFecha.HeaderText = "Fecha"
        Me.ImpleFecha.MinimumWidth = 70
        Me.ImpleFecha.Name = "ImpleFecha"
        Me.ImpleFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpleFecha.Width = 70
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.NullValue = " "
        Me.Estado.DefaultCellStyle = DataGridViewCellStyle13
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Items.AddRange(New Object() {"", "Imple.", "Nula"})
        Me.Estado.MinimumWidth = 70
        Me.Estado.Name = "Estado"
        Me.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Estado.Width = 70
        '
        'Comentarios
        '
        Me.Comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Comentarios.HeaderText = "Comentarios"
        Me.Comentarios.MaxInputLength = 100
        Me.Comentarios.MinimumWidth = 100
        Me.Comentarios.Name = "Comentarios"
        Me.Comentarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage4.Controls.Add(Me.txtFechaAux4)
        Me.TabPage4.Controls.Add(Me.txtFechaAux3)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.btnInmovilizarAcciones)
        Me.TabPage4.Controls.Add(Me.dgvVerificaciones)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Verificación"
        '
        'txtFechaAux4
        '
        Me.txtFechaAux4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux4.Location = New System.Drawing.Point(696, 151)
        Me.txtFechaAux4.Mask = "00/00/0000"
        Me.txtFechaAux4.Name = "txtFechaAux4"
        Me.txtFechaAux4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux4.Size = New System.Drawing.Size(58, 13)
        Me.txtFechaAux4.TabIndex = 10
        Me.txtFechaAux4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaAux4.Visible = False
        '
        'txtFechaAux3
        '
        Me.txtFechaAux3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux3.Location = New System.Drawing.Point(470, 151)
        Me.txtFechaAux3.Mask = "00/00/0000"
        Me.txtFechaAux3.Name = "txtFechaAux3"
        Me.txtFechaAux3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux3.Size = New System.Drawing.Size(58, 13)
        Me.txtFechaAux3.TabIndex = 9
        Me.txtFechaAux3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaAux3.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Green
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(587, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 18)
        Me.Label14.TabIndex = 8
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(623, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(245, 18)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Verificación Efectividad"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(302, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(245, 18)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Verficación Implementración"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Orange
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(265, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 18)
        Me.Label12.TabIndex = 8
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnInmovilizarAcciones
        '
        Me.btnInmovilizarAcciones.Location = New System.Drawing.Point(21, 3)
        Me.btnInmovilizarAcciones.Name = "btnInmovilizarAcciones"
        Me.btnInmovilizarAcciones.Size = New System.Drawing.Size(142, 22)
        Me.btnInmovilizarAcciones.TabIndex = 7
        Me.btnInmovilizarAcciones.Text = "Inmov. Columna"
        Me.btnInmovilizarAcciones.UseVisualStyleBackColor = True
        '
        'dgvVerificaciones
        '
        Me.dgvVerificaciones.AllowUserToAddRows = False
        Me.dgvVerificaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVerificaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvVerificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVerificaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VerIdAcciones, Me.VerAcciones, Me.VerResponsableI, Me.VerDescResponsableI, Me.VerFechaI, Me.VerEstadoI, Me.VerResponsableII, Me.VerDescResponsableII, Me.VerFechaII, Me.VerEstadoII, Me.VerComentario})
        Me.dgvVerificaciones.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVerificaciones.DefaultCellStyle = DataGridViewCellStyle21
        Me.dgvVerificaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVerificaciones.Location = New System.Drawing.Point(6, 29)
        Me.dgvVerificaciones.Name = "dgvVerificaciones"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVerificaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvVerificaciones.RowHeadersWidth = 15
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVerificaciones.RowsDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvVerificaciones.RowTemplate.Height = 20
        Me.dgvVerificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect
        Me.dgvVerificaciones.Size = New System.Drawing.Size(1013, 288)
        Me.dgvVerificaciones.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovilizarInmovilizarAccionesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(237, 26)
        '
        'MovilizarInmovilizarAccionesToolStripMenuItem
        '
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Name = "MovilizarInmovilizarAccionesToolStripMenuItem"
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.MovilizarInmovilizarAccionesToolStripMenuItem.Text = "Movilizar/Inmovilizar Acciones"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(195, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Referencias"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage5.Controls.Add(Me.txtComentarios)
        Me.TabPage5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Comentarios"
        '
        'txtComentarios
        '
        Me.txtComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarios.Location = New System.Drawing.Point(15, 6)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarios.Size = New System.Drawing.Size(994, 303)
        Me.txtComentarios.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage6.Controls.Add(Me.Button2)
        Me.TabPage6.Controls.Add(Me.Button1)
        Me.TabPage6.Controls.Add(Me.dgvArchivos)
        Me.TabPage6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage6.Location = New System.Drawing.Point(4, 29)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Archivos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(179, 296)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Eliminar Archivo(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar Archivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaArchivo, Me.DescArchivo, Me.Icono, Me.PathArchivo})
        Me.dgvArchivos.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgvArchivos.Location = New System.Drawing.Point(8, 8)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersWidth = 15
        Me.dgvArchivos.RowTemplate.Height = 30
        Me.dgvArchivos.ShowCellToolTips = False
        Me.dgvArchivos.Size = New System.Drawing.Size(1012, 282)
        Me.dgvArchivos.TabIndex = 0
        '
        'FechaArchivo
        '
        Me.FechaArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaArchivo.HeaderText = "Fecha"
        Me.FechaArchivo.Name = "FechaArchivo"
        Me.FechaArchivo.ReadOnly = True
        Me.FechaArchivo.Width = 62
        '
        'DescArchivo
        '
        Me.DescArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescArchivo.HeaderText = "Descripción"
        Me.DescArchivo.Name = "DescArchivo"
        Me.DescArchivo.ReadOnly = True
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Icono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarArchivoToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(162, 26)
        Me.ContextMenuStrip2.Text = "Eliminar Archivo"
        '
        'EliminarArchivoToolStripMenuItem
        '
        Me.EliminarArchivoToolStripMenuItem.Name = "EliminarArchivoToolStripMenuItem"
        Me.EliminarArchivoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.EliminarArchivoToolStripMenuItem.Text = "Eliminar Archivo"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage7.Controls.Add(Me.dgvIncidencias)
        Me.TabPage7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage7.Location = New System.Drawing.Point(4, 29)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(1029, 333)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "INC's Vinculados"
        Me.TabPage7.ToolTipText = "Doble Click sobre Informe de No Conformidad para ver la información del mismo"
        '
        'dgvIncidencias
        '
        Me.dgvIncidencias.AllowUserToAddRows = False
        Me.dgvIncidencias.AllowUserToDeleteRows = False
        Me.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Incidencia, Me.Renglon, Me.Tipo, Me.DescTipo, Me.Fecha, Me.FechaOrd, Me.DataGridViewTextBoxColumn1, Me.DescEstado, Me.Titulo, Me.Referencia, Me.Producto, Me.Lote, Me.ClaveSAC})
        Me.dgvIncidencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvIncidencias.Location = New System.Drawing.Point(6, 6)
        Me.dgvIncidencias.Name = "dgvIncidencias"
        Me.dgvIncidencias.ReadOnly = True
        Me.dgvIncidencias.RowHeadersWidth = 15
        Me.dgvIncidencias.RowTemplate.Height = 20
        Me.dgvIncidencias.ShowCellToolTips = False
        Me.dgvIncidencias.Size = New System.Drawing.Size(1015, 304)
        Me.dgvIncidencias.TabIndex = 4
        '
        'Incidencia
        '
        Me.Incidencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Incidencia.DataPropertyName = "Incidencia"
        Me.Incidencia.HeaderText = "Nro"
        Me.Incidencia.Name = "Incidencia"
        Me.Incidencia.ReadOnly = True
        Me.Incidencia.Width = 49
        '
        'Renglon
        '
        Me.Renglon.DataPropertyName = "Renglon"
        Me.Renglon.HeaderText = "Renglon"
        Me.Renglon.Name = "Renglon"
        Me.Renglon.ReadOnly = True
        Me.Renglon.Visible = False
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Visible = False
        '
        'DescTipo
        '
        Me.DescTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescTipo.DataPropertyName = "DescTipo"
        Me.DescTipo.HeaderText = "Tipo"
        Me.DescTipo.Name = "DescTipo"
        Me.DescTipo.ReadOnly = True
        Me.DescTipo.Width = 53
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'FechaOrd
        '
        Me.FechaOrd.DataPropertyName = "FechaOrd"
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.ReadOnly = True
        Me.FechaOrd.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Estado"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DescEstado
        '
        Me.DescEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescEstado.DataPropertyName = "DescEstado"
        Me.DescEstado.HeaderText = "Estado"
        Me.DescEstado.Name = "DescEstado"
        Me.DescEstado.ReadOnly = True
        Me.DescEstado.Width = 65
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Título"
        Me.Titulo.MinimumWidth = 350
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.MinimumWidth = 350
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 350
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Visible = False
        '
        'Lote
        '
        Me.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Lote.DataPropertyName = "Lote"
        Me.Lote.HeaderText = "Lote/Partida"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Visible = False
        '
        'ClaveSAC
        '
        Me.ClaveSAC.DataPropertyName = "ClaveSAC"
        Me.ClaveSAC.HeaderText = "ClaveSAC"
        Me.ClaveSAC.Name = "ClaveSAC"
        Me.ClaveSAC.ReadOnly = True
        Me.ClaveSAC.Visible = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1037, 366)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.btnExportar)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1037, 138)
        Me.Panel3.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNumeroSiguiente)
        Me.GroupBox3.Controls.Add(Me.btnNumeroAnterior)
        Me.GroupBox3.Location = New System.Drawing.Point(831, 53)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 48)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Navegar Por Numero"
        '
        'btnNumeroSiguiente
        '
        Me.btnNumeroSiguiente.Location = New System.Drawing.Point(93, 17)
        Me.btnNumeroSiguiente.Name = "btnNumeroSiguiente"
        Me.btnNumeroSiguiente.Size = New System.Drawing.Size(77, 24)
        Me.btnNumeroSiguiente.TabIndex = 7
        Me.btnNumeroSiguiente.Text = "Siguiente"
        Me.btnNumeroSiguiente.UseVisualStyleBackColor = True
        '
        'btnNumeroAnterior
        '
        Me.btnNumeroAnterior.Location = New System.Drawing.Point(13, 17)
        Me.btnNumeroAnterior.Name = "btnNumeroAnterior"
        Me.btnNumeroAnterior.Size = New System.Drawing.Size(77, 24)
        Me.btnNumeroAnterior.TabIndex = 6
        Me.btnNumeroAnterior.Text = "Anterior"
        Me.btnNumeroAnterior.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTipoSiguiente)
        Me.GroupBox2.Controls.Add(Me.btnTipoAnterior)
        Me.GroupBox2.Location = New System.Drawing.Point(831, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(182, 48)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Navegar Por Tipo"
        '
        'btnTipoSiguiente
        '
        Me.btnTipoSiguiente.Location = New System.Drawing.Point(93, 17)
        Me.btnTipoSiguiente.Name = "btnTipoSiguiente"
        Me.btnTipoSiguiente.Size = New System.Drawing.Size(77, 24)
        Me.btnTipoSiguiente.TabIndex = 7
        Me.btnTipoSiguiente.Text = "Siguiente"
        Me.btnTipoSiguiente.UseVisualStyleBackColor = True
        '
        'btnTipoAnterior
        '
        Me.btnTipoAnterior.Location = New System.Drawing.Point(13, 17)
        Me.btnTipoAnterior.Name = "btnTipoAnterior"
        Me.btnTipoAnterior.Size = New System.Drawing.Size(77, 24)
        Me.btnTipoAnterior.TabIndex = 6
        Me.btnTipoAnterior.Text = "Anterior"
        Me.btnTipoAnterior.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(831, 105)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(182, 24)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar Datos"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1037, 36)
        Me.Panel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(25, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ingreso de SAC"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(917, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGrabar.Location = New System.Drawing.Point(202, 5)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(96, 37)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConsultas.Location = New System.Drawing.Point(336, 5)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(96, 37)
        Me.btnConsultas.TabIndex = 7
        Me.btnConsultas.Text = "Consultas"
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImprimir.Location = New System.Drawing.Point(470, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(96, 37)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnLimpiar.Location = New System.Drawing.Point(604, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(96, 37)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCerrar.Location = New System.Drawing.Point(738, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(96, 37)
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
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 540)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1037, 47)
        Me.Panel4.TabIndex = 8
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'VerIdAcciones
        '
        Me.VerIdAcciones.HeaderText = "Nº"
        Me.VerIdAcciones.Name = "VerIdAcciones"
        Me.VerIdAcciones.ReadOnly = True
        Me.VerIdAcciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerIdAcciones.Width = 35
        '
        'VerAcciones
        '
        Me.VerAcciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VerAcciones.DefaultCellStyle = DataGridViewCellStyle17
        Me.VerAcciones.HeaderText = "Acciones Correctivas"
        Me.VerAcciones.MinimumWidth = 200
        Me.VerAcciones.Name = "VerAcciones"
        Me.VerAcciones.ReadOnly = True
        Me.VerAcciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerAcciones.Width = 200
        '
        'VerResponsableI
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.VerResponsableI.DefaultCellStyle = DataGridViewCellStyle18
        Me.VerResponsableI.HeaderText = "Resp."
        Me.VerResponsableI.Name = "VerResponsableI"
        Me.VerResponsableI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerResponsableI.Width = 45
        '
        'VerDescResponsableI
        '
        Me.VerDescResponsableI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerDescResponsableI.HeaderText = "Descripción"
        Me.VerDescResponsableI.MinimumWidth = 100
        Me.VerDescResponsableI.Name = "VerDescResponsableI"
        Me.VerDescResponsableI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'VerFechaI
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.VerFechaI.DefaultCellStyle = DataGridViewCellStyle19
        Me.VerFechaI.HeaderText = "Fecha"
        Me.VerFechaI.Name = "VerFechaI"
        Me.VerFechaI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerFechaI.Width = 70
        '
        'VerEstadoI
        '
        Me.VerEstadoI.HeaderText = "Estado"
        Me.VerEstadoI.Items.AddRange(New Object() {"No Imple.", "Implem.", "Nula", "Cerrada"})
        Me.VerEstadoI.Name = "VerEstadoI"
        Me.VerEstadoI.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'VerResponsableII
        '
        Me.VerResponsableII.HeaderText = "Resp."
        Me.VerResponsableII.Name = "VerResponsableII"
        Me.VerResponsableII.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerResponsableII.Width = 45
        '
        'VerDescResponsableII
        '
        Me.VerDescResponsableII.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerDescResponsableII.HeaderText = "Descripción"
        Me.VerDescResponsableII.MinimumWidth = 100
        Me.VerDescResponsableII.Name = "VerDescResponsableII"
        Me.VerDescResponsableII.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'VerFechaII
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.VerFechaII.DefaultCellStyle = DataGridViewCellStyle20
        Me.VerFechaII.HeaderText = "Fecha"
        Me.VerFechaII.Name = "VerFechaII"
        Me.VerFechaII.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VerFechaII.Width = 70
        '
        'VerEstadoII
        '
        Me.VerEstadoII.HeaderText = "Estado"
        Me.VerEstadoII.Items.AddRange(New Object() {"No Efect.", "Parc. Efect.", "Nula", "Efectiva"})
        Me.VerEstadoII.Name = "VerEstadoII"
        Me.VerEstadoII.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'VerComentario
        '
        Me.VerComentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VerComentario.HeaderText = "Comentarios"
        Me.VerComentario.MaxInputLength = 100
        Me.VerComentario.MinimumWidth = 100
        Me.VerComentario.Name = "VerComentario"
        Me.VerComentario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NuevoSac
        '
        Me.ClientSize = New System.Drawing.Size(1037, 587)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "NuevoSac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvImplementaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvVerificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        CType(Me.dgvIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents dgvIncidencias As System.Windows.Forms.DataGridView
    Friend WithEvents Incidencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Renglon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveSAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerIdAcciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerAcciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerResponsableI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerDescResponsableI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerFechaI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerEstadoI As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents VerResponsableII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerDescResponsableII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerFechaII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerEstadoII As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents VerComentario As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
