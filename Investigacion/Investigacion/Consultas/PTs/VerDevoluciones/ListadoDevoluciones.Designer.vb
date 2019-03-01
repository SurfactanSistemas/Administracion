<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoDevoluciones
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvDevoluciones = New ConsultasVarias.DBDataGridView()
        Me.Devolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartiOri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerEnsayosDeProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerMovimientosDeProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.VerDevolucionesParaEstaPartidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerDevolucionesParaEsteCódigoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel99 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmbOrdenIII = New System.Windows.Forms.ComboBox()
        Me.cmbOrdenII = New System.Windows.Forms.ComboBox()
        Me.cmbOrdenI = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.clbClientes = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.clbEstados = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.MaskedTextBox()
        Me.rbPorPartida = New System.Windows.Forms.RadioButton()
        Me.rbPorCodigo = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.panel99.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(887, 50)
        Me.Panel1.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(786, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "- CONSULTA -"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(362, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DEVOLUCIONES DE PRODUCTOS TERMINADOS"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDevoluciones, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.panel99, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 263.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(887, 511)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'dgvDevoluciones
        '
        Me.dgvDevoluciones.AllowUserToAddRows = False
        Me.dgvDevoluciones.AllowUserToDeleteRows = False
        Me.dgvDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDevoluciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Devolucion, Me.Fecha, Me.FechaOrd, Me.Codigo, Me.Partida, Me.Cantidad, Me.PartiOri, Me.Observaciones, Me.Cliente, Me.DescCliente, Me.Estado, Me.Empresa})
        Me.dgvDevoluciones.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDevoluciones.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDevoluciones.DoubleBuffered = True
        Me.dgvDevoluciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvDevoluciones.Location = New System.Drawing.Point(3, 266)
        Me.dgvDevoluciones.Name = "dgvDevoluciones"
        Me.dgvDevoluciones.ReadOnly = True
        Me.dgvDevoluciones.RowHeadersWidth = 10
        Me.dgvDevoluciones.RowTemplate.Height = 20
        Me.dgvDevoluciones.ShowCellToolTips = False
        Me.dgvDevoluciones.Size = New System.Drawing.Size(881, 242)
        Me.dgvDevoluciones.TabIndex = 12
        '
        'Devolucion
        '
        Me.Devolucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Devolucion.DataPropertyName = "Devolucion"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Devolucion.DefaultCellStyle = DataGridViewCellStyle10
        Me.Devolucion.HeaderText = "Nº Dev."
        Me.Devolucion.MinimumWidth = 65
        Me.Devolucion.Name = "Devolucion"
        Me.Devolucion.ReadOnly = True
        Me.Devolucion.Width = 65
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MinimumWidth = 62
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
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.MinimumWidth = 65
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Partida
        '
        Me.Partida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Partida.DataPropertyName = "Partida"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Partida.DefaultCellStyle = DataGridViewCellStyle15
        Me.Partida.HeaderText = "Partida"
        Me.Partida.MinimumWidth = 65
        Me.Partida.Name = "Partida"
        Me.Partida.ReadOnly = True
        Me.Partida.Width = 65
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle16
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 74
        '
        'PartiOri
        '
        Me.PartiOri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PartiOri.DataPropertyName = "PartiOri"
        Me.PartiOri.HeaderText = "Lote Prov."
        Me.PartiOri.Name = "PartiOri"
        Me.PartiOri.ReadOnly = True
        Me.PartiOri.Width = 75
        '
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MinimumWidth = 103
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Width = 103
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 64
        '
        'DescCliente
        '
        Me.DescCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescCliente.DataPropertyName = "DescCliente"
        Me.DescCliente.HeaderText = "Nombre Cliente"
        Me.DescCliente.MinimumWidth = 207
        Me.DescCliente.Name = "DescCliente"
        Me.DescCliente.ReadOnly = True
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Estado.DefaultCellStyle = DataGridViewCellStyle17
        Me.Estado.HeaderText = "Est."
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 50
        '
        'Empresa
        '
        Me.Empresa.DataPropertyName = "Empresa"
        Me.Empresa.HeaderText = "Empresa"
        Me.Empresa.Name = "Empresa"
        Me.Empresa.ReadOnly = True
        Me.Empresa.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerEnsayosDeProductoToolStripMenuItem, Me.VerMovimientosDeProductoToolStripMenuItem, Me.ToolStripSeparator1, Me.VerDevolucionesParaEstaPartidaToolStripMenuItem, Me.VerDevolucionesParaEsteCódigoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(257, 98)
        '
        'VerEnsayosDeProductoToolStripMenuItem
        '
        Me.VerEnsayosDeProductoToolStripMenuItem.Name = "VerEnsayosDeProductoToolStripMenuItem"
        Me.VerEnsayosDeProductoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.VerEnsayosDeProductoToolStripMenuItem.Text = "Ver Ensayos de Producto"
        '
        'VerMovimientosDeProductoToolStripMenuItem
        '
        Me.VerMovimientosDeProductoToolStripMenuItem.Name = "VerMovimientosDeProductoToolStripMenuItem"
        Me.VerMovimientosDeProductoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.VerMovimientosDeProductoToolStripMenuItem.Text = "Ver Movimientos de Producto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(253, 6)
        '
        'VerDevolucionesParaEstaPartidaToolStripMenuItem
        '
        Me.VerDevolucionesParaEstaPartidaToolStripMenuItem.Name = "VerDevolucionesParaEstaPartidaToolStripMenuItem"
        Me.VerDevolucionesParaEstaPartidaToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.VerDevolucionesParaEstaPartidaToolStripMenuItem.Text = "Ver Devoluciones para esta Partida"
        '
        'VerDevolucionesParaEsteCódigoToolStripMenuItem
        '
        Me.VerDevolucionesParaEsteCódigoToolStripMenuItem.Name = "VerDevolucionesParaEsteCódigoToolStripMenuItem"
        Me.VerDevolucionesParaEsteCódigoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.VerDevolucionesParaEsteCódigoToolStripMenuItem.Text = "Ver Devoluciones para este Código"
        '
        'panel99
        '
        Me.panel99.Controls.Add(Me.GroupBox1)
        Me.panel99.Controls.Add(Me.GroupBox6)
        Me.panel99.Controls.Add(Me.btnLimpiar)
        Me.panel99.Controls.Add(Me.btnExportar)
        Me.panel99.Controls.Add(Me.btnCerrar)
        Me.panel99.Controls.Add(Me.btnFiltrar)
        Me.panel99.Controls.Add(Me.GroupBox5)
        Me.panel99.Controls.Add(Me.GroupBox4)
        Me.panel99.Controls.Add(Me.GroupBox3)
        Me.panel99.Controls.Add(Me.GroupBox2)
        Me.panel99.Location = New System.Drawing.Point(10, 3)
        Me.panel99.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.panel99.Name = "panel99"
        Me.panel99.Size = New System.Drawing.Size(868, 257)
        Me.panel99.TabIndex = 13
        Me.panel99.TabStop = False
        Me.panel99.Text = "PARAMETROS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.txtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 49)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Entre Fechas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "AL"
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.Location = New System.Drawing.Point(227, 18)
        Me.txtFechaHasta.Mask = "00/00/0000"
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaHasta.Size = New System.Drawing.Size(71, 20)
        Me.txtFechaHasta.TabIndex = 2
        Me.txtFechaHasta.Text = "00000000"
        Me.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.Location = New System.Drawing.Point(116, 18)
        Me.txtFechaDesde.Mask = "00/00/0000"
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaDesde.Size = New System.Drawing.Size(71, 20)
        Me.txtFechaDesde.TabIndex = 2
        Me.txtFechaDesde.Text = "00000000"
        Me.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmbOrdenIII)
        Me.GroupBox6.Controls.Add(Me.cmbOrdenII)
        Me.GroupBox6.Controls.Add(Me.cmbOrdenI)
        Me.GroupBox6.Location = New System.Drawing.Point(430, 77)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(430, 49)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Ordenamiento de Resultados"
        '
        'cmbOrdenIII
        '
        Me.cmbOrdenIII.FormattingEnabled = True
        Me.cmbOrdenIII.Items.AddRange(New Object() {"FECHA", "CLIENTE", "ESTADO"})
        Me.cmbOrdenIII.Location = New System.Drawing.Point(293, 19)
        Me.cmbOrdenIII.Name = "cmbOrdenIII"
        Me.cmbOrdenIII.Size = New System.Drawing.Size(118, 21)
        Me.cmbOrdenIII.TabIndex = 0
        '
        'cmbOrdenII
        '
        Me.cmbOrdenII.FormattingEnabled = True
        Me.cmbOrdenII.Items.AddRange(New Object() {"FECHA", "CLIENTE", "ESTADO"})
        Me.cmbOrdenII.Location = New System.Drawing.Point(156, 19)
        Me.cmbOrdenII.Name = "cmbOrdenII"
        Me.cmbOrdenII.Size = New System.Drawing.Size(118, 21)
        Me.cmbOrdenII.TabIndex = 0
        '
        'cmbOrdenI
        '
        Me.cmbOrdenI.FormattingEnabled = True
        Me.cmbOrdenI.Items.AddRange(New Object() {"FECHA", "CLIENTE", "ESTADO"})
        Me.cmbOrdenI.Location = New System.Drawing.Point(19, 19)
        Me.cmbOrdenI.Name = "cmbOrdenI"
        Me.cmbOrdenI.Size = New System.Drawing.Size(118, 21)
        Me.cmbOrdenI.TabIndex = 0
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(710, 171)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(131, 34)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(571, 171)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(133, 34)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "EXPORTAR LISTADO"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(709, 134)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(132, 34)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(571, 134)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(132, 34)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "FILTRAR"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.clbClientes)
        Me.GroupBox5.Location = New System.Drawing.Point(165, 129)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(400, 122)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cliente que Realizó Devolución"
        '
        'clbClientes
        '
        Me.clbClientes.CheckOnClick = True
        Me.clbClientes.FormattingEnabled = True
        Me.clbClientes.Location = New System.Drawing.Point(7, 18)
        Me.clbClientes.Name = "clbClientes"
        Me.clbClientes.Size = New System.Drawing.Size(387, 94)
        Me.clbClientes.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.clbEstados)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 129)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(151, 122)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Estado de Prod. Devuelto"
        '
        'clbEstados
        '
        Me.clbEstados.CheckOnClick = True
        Me.clbEstados.FormattingEnabled = True
        Me.clbEstados.Items.AddRange(New Object() {"TODOS", "PT", "RE", "NK"})
        Me.clbEstados.Location = New System.Drawing.Point(7, 19)
        Me.clbEstados.Name = "clbEstados"
        Me.clbEstados.Size = New System.Drawing.Size(137, 94)
        Me.clbEstados.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDescTerminado)
        Me.GroupBox3.Controls.Add(Me.txtCodigo)
        Me.GroupBox3.Location = New System.Drawing.Point(313, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(547, 57)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PRODUCTO REFERIDO"
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.txtDescTerminado.Location = New System.Drawing.Point(105, 23)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.ReadOnly = True
        Me.txtDescTerminado.Size = New System.Drawing.Size(433, 20)
        Me.txtDescTerminado.TabIndex = 0
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(9, 23)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtBuscar)
        Me.GroupBox2.Controls.Add(Me.rbPorPartida)
        Me.GroupBox2.Controls.Add(Me.rbPorCodigo)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 57)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Devoluciones de Producto Según"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(181, 24)
        Me.txtBuscar.Mask = ">LL-00000-000"
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBuscar.Size = New System.Drawing.Size(79, 20)
        Me.txtBuscar.TabIndex = 1
        Me.txtBuscar.Text = "PT00000000"
        '
        'rbPorPartida
        '
        Me.rbPorPartida.AutoSize = True
        Me.rbPorPartida.Location = New System.Drawing.Point(109, 26)
        Me.rbPorPartida.Name = "rbPorPartida"
        Me.rbPorPartida.Size = New System.Drawing.Size(58, 17)
        Me.rbPorPartida.TabIndex = 0
        Me.rbPorPartida.Text = "Partida"
        Me.rbPorPartida.UseVisualStyleBackColor = True
        '
        'rbPorCodigo
        '
        Me.rbPorCodigo.AutoSize = True
        Me.rbPorCodigo.Checked = True
        Me.rbPorCodigo.Location = New System.Drawing.Point(38, 26)
        Me.rbPorCodigo.Name = "rbPorCodigo"
        Me.rbPorCodigo.Size = New System.Drawing.Size(58, 17)
        Me.rbPorCodigo.TabIndex = 0
        Me.rbPorCodigo.TabStop = True
        Me.rbPorCodigo.Text = "Código"
        Me.rbPorCodigo.UseVisualStyleBackColor = True
        '
        'ListadoDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ListadoDevoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.panel99.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDevoluciones As ConsultasVarias.DBDataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents panel99 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rbPorPartida As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents clbEstados As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents clbClientes As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbOrdenIII As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrdenII As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrdenI As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Devolucion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartiOri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerEnsayosDeProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerMovimientosDeProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VerDevolucionesParaEstaPartidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerDevolucionesParaEsteCódigoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
