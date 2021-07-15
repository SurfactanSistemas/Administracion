<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Centro_Importaciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl_ArticuloKg = New System.Windows.Forms.Label()
        Me.txt_Articulo = New System.Windows.Forms.TextBox()
        Me.lbl_Articulo = New System.Windows.Forms.Label()
        Me.txt_SumaLetra = New System.Windows.Forms.TextBox()
        Me.txt_SumaDespacho = New System.Windows.Forms.TextBox()
        Me.chk_LetraPendiente = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx_Activas = New System.Windows.Forms.ComboBox()
        Me.btn_Actualiza = New System.Windows.Forms.Button()
        Me.btn_Djai = New System.Windows.Forms.Button()
        Me.btn_Exportacion = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.chk_DespachoPendiente = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGV_Muestra = New Util.DBDataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Carpeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DJai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Incoterms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLLegada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpoDespacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VtoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USPagadoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEmbarque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Buque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contenedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_cbx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLlegadaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VtoLetraOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FembarqueOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoLetraOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIngresoOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_ArticuloKg
        '
        Me.lbl_ArticuloKg.AutoSize = True
        Me.lbl_ArticuloKg.Location = New System.Drawing.Point(894, 48)
        Me.lbl_ArticuloKg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ArticuloKg.Name = "lbl_ArticuloKg"
        Me.lbl_ArticuloKg.Size = New System.Drawing.Size(36, 17)
        Me.lbl_ArticuloKg.TabIndex = 71
        Me.lbl_ArticuloKg.Text = "Kgs."
        '
        'txt_Articulo
        '
        Me.txt_Articulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Articulo.Location = New System.Drawing.Point(752, 45)
        Me.txt_Articulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Articulo.Name = "txt_Articulo"
        Me.txt_Articulo.ReadOnly = True
        Me.txt_Articulo.Size = New System.Drawing.Size(132, 22)
        Me.txt_Articulo.TabIndex = 70
        '
        'lbl_Articulo
        '
        Me.lbl_Articulo.AutoSize = True
        Me.lbl_Articulo.Location = New System.Drawing.Point(688, 51)
        Me.lbl_Articulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Articulo.Name = "lbl_Articulo"
        Me.lbl_Articulo.Size = New System.Drawing.Size(55, 17)
        Me.lbl_Articulo.TabIndex = 69
        Me.lbl_Articulo.Text = "Articulo"
        '
        'txt_SumaLetra
        '
        Me.txt_SumaLetra.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaLetra.Location = New System.Drawing.Point(499, 46)
        Me.txt_SumaLetra.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_SumaLetra.Name = "txt_SumaLetra"
        Me.txt_SumaLetra.ReadOnly = True
        Me.txt_SumaLetra.Size = New System.Drawing.Size(132, 22)
        Me.txt_SumaLetra.TabIndex = 68
        '
        'txt_SumaDespacho
        '
        Me.txt_SumaDespacho.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_SumaDespacho.Location = New System.Drawing.Point(254, 48)
        Me.txt_SumaDespacho.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_SumaDespacho.Name = "txt_SumaDespacho"
        Me.txt_SumaDespacho.ReadOnly = True
        Me.txt_SumaDespacho.Size = New System.Drawing.Size(132, 22)
        Me.txt_SumaDespacho.TabIndex = 67
        '
        'chk_LetraPendiente
        '
        Me.chk_LetraPendiente.AutoSize = True
        Me.chk_LetraPendiente.Location = New System.Drawing.Point(991, 17)
        Me.chk_LetraPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_LetraPendiente.Name = "chk_LetraPendiente"
        Me.chk_LetraPendiente.Size = New System.Drawing.Size(131, 21)
        Me.chk_LetraPendiente.TabIndex = 66
        Me.chk_LetraPendiente.Text = "Letra Pendiente"
        Me.chk_LetraPendiente.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(410, 51)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "U$S Letra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(150, 51)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "$ Despacho"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(151, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Filtro"
        '
        'cbx_Activas
        '
        Me.cbx_Activas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Activas.FormattingEnabled = True
        Me.cbx_Activas.Items.AddRange(New Object() {"Activas", "Cerradas"})
        Me.cbx_Activas.Location = New System.Drawing.Point(1132, 13)
        Me.cbx_Activas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Activas.Name = "cbx_Activas"
        Me.cbx_Activas.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Activas.TabIndex = 62
        '
        'btn_Actualiza
        '
        Me.btn_Actualiza.Location = New System.Drawing.Point(1170, 45)
        Me.btn_Actualiza.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Actualiza.Name = "btn_Actualiza"
        Me.btn_Actualiza.Size = New System.Drawing.Size(100, 28)
        Me.btn_Actualiza.TabIndex = 58
        Me.btn_Actualiza.Text = "ACTUALIZA"
        Me.btn_Actualiza.UseVisualStyleBackColor = True
        '
        'btn_Djai
        '
        Me.btn_Djai.Location = New System.Drawing.Point(7, 51)
        Me.btn_Djai.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Djai.Name = "btn_Djai"
        Me.btn_Djai.Size = New System.Drawing.Size(135, 28)
        Me.btn_Djai.TabIndex = 57
        Me.btn_Djai.Text = "TXT DJAI"
        Me.btn_Djai.UseVisualStyleBackColor = True
        Me.btn_Djai.Visible = False
        '
        'btn_Exportacion
        '
        Me.btn_Exportacion.Location = New System.Drawing.Point(7, 12)
        Me.btn_Exportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exportacion.Name = "btn_Exportacion"
        Me.btn_Exportacion.Size = New System.Drawing.Size(135, 53)
        Me.btn_Exportacion.TabIndex = 56
        Me.btn_Exportacion.Text = "EXPORTAR FILAS SELECCIONADAS"
        Me.btn_Exportacion.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1741, 62)
        Me.panel1.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1534, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(4, 7)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(215, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Centro de Importaciones"
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(197, 15)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(580, 22)
        Me.txt_Filtro.TabIndex = 74
        '
        'chk_DespachoPendiente
        '
        Me.chk_DespachoPendiente.AutoSize = True
        Me.chk_DespachoPendiente.Location = New System.Drawing.Point(809, 15)
        Me.chk_DespachoPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_DespachoPendiente.Name = "chk_DespachoPendiente"
        Me.chk_DespachoPendiente.Size = New System.Drawing.Size(162, 21)
        Me.chk_DespachoPendiente.TabIndex = 75
        Me.chk_DespachoPendiente.Text = "Despacho Pendiente"
        Me.chk_DespachoPendiente.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DGV_Muestra, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 62)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1741, 738)
        Me.TableLayoutPanel1.TabIndex = 76
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Exportacion)
        Me.GroupBox1.Controls.Add(Me.chk_DespachoPendiente)
        Me.GroupBox1.Controls.Add(Me.btn_Djai)
        Me.GroupBox1.Controls.Add(Me.txt_Filtro)
        Me.GroupBox1.Controls.Add(Me.btn_Actualiza)
        Me.GroupBox1.Controls.Add(Me.cbx_Activas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbl_ArticuloKg)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_Articulo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_Articulo)
        Me.GroupBox1.Controls.Add(Me.chk_LetraPendiente)
        Me.GroupBox1.Controls.Add(Me.txt_SumaLetra)
        Me.GroupBox1.Controls.Add(Me.txt_SumaDespacho)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1735, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DGV_Muestra
        '
        Me.DGV_Muestra.AllowUserToAddRows = False
        Me.DGV_Muestra.AllowUserToDeleteRows = False
        Me.DGV_Muestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Muestra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Pta, Me.Fecha, Me.Proveedor, Me.Mon, Me.Carpeta, Me.DJai, Me.Origen, Me.Incoterms, Me.Transporte, Me.FLLegada, Me.TPago, Me.ImpoDespacho, Me.PagoDes, Me.LetraTotal, Me.PagoLetra, Me.VtoLetra, Me.USPagadoLetra, Me.FEmbarque, Me.SaldoLetra, Me.ProveedorCod, Me.BL, Me.Buque, Me.Contenedor, Me.Despacho, Me.Tipo_cbx, Me.Estado, Me.FechaIngreso, Me.FechaOrd, Me.FLlegadaOrd, Me.VtoLetraOrd, Me.FembarqueOrd, Me.SaldoLetraOrd, Me.FechaIngresoOrd})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Muestra.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_Muestra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Muestra.DoubleBuffered = True
        Me.DGV_Muestra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Muestra.Location = New System.Drawing.Point(4, 91)
        Me.DGV_Muestra.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Muestra.Name = "DGV_Muestra"
        Me.DGV_Muestra.OrdenamientoColumnasHabilitado = False
        Me.DGV_Muestra.RowHeadersWidth = 15
        Me.DGV_Muestra.RowTemplate.Height = 20
        Me.DGV_Muestra.ShowCellToolTips = False
        Me.DGV_Muestra.SinClickDerecho = False
        Me.DGV_Muestra.Size = New System.Drawing.Size(1733, 643)
        Me.DGV_Muestra.TabIndex = 72
        '
        'Orden
        '
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Orden.Width = 60
        '
        'Pta
        '
        Me.Pta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pta.DataPropertyName = "Pta"
        Me.Pta.HeaderText = "Pta"
        Me.Pta.Name = "Pta"
        Me.Pta.ReadOnly = True
        Me.Pta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Pta.Width = 35
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha.Width = 53
        '
        'Proveedor
        '
        Me.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Proveedor.Width = 80
        '
        'Mon
        '
        Me.Mon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Mon.DataPropertyName = "Mon"
        Me.Mon.HeaderText = "Mon"
        Me.Mon.Name = "Mon"
        Me.Mon.ReadOnly = True
        Me.Mon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mon.Width = 41
        '
        'Carpeta
        '
        Me.Carpeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Carpeta.DataPropertyName = "Carpeta"
        Me.Carpeta.HeaderText = "Carpeta"
        Me.Carpeta.Name = "Carpeta"
        Me.Carpeta.ReadOnly = True
        Me.Carpeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Carpeta.Width = 64
        '
        'DJai
        '
        Me.DJai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DJai.DataPropertyName = "DJai"
        Me.DJai.HeaderText = "DJai"
        Me.DJai.Name = "DJai"
        Me.DJai.ReadOnly = True
        Me.DJai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DJai.Width = 42
        '
        'Origen
        '
        Me.Origen.DataPropertyName = "Origen"
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.ReadOnly = True
        Me.Origen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Origen.Width = 80
        '
        'Incoterms
        '
        Me.Incoterms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Incoterms.DataPropertyName = "Incoterms"
        Me.Incoterms.HeaderText = "Incoterms"
        Me.Incoterms.Name = "Incoterms"
        Me.Incoterms.ReadOnly = True
        Me.Incoterms.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Incoterms.Width = 75
        '
        'Transporte
        '
        Me.Transporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Transporte.DataPropertyName = "Transporte"
        Me.Transporte.HeaderText = "Transporte"
        Me.Transporte.Name = "Transporte"
        Me.Transporte.ReadOnly = True
        Me.Transporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Transporte.Width = 84
        '
        'FLLegada
        '
        Me.FLLegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FLLegada.DataPropertyName = "FLLegada"
        Me.FLLegada.HeaderText = "F.LLegada"
        Me.FLLegada.Name = "FLLegada"
        Me.FLLegada.ReadOnly = True
        Me.FLLegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FLLegada.Width = 82
        '
        'TPago
        '
        Me.TPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TPago.DataPropertyName = "TPago"
        Me.TPago.HeaderText = "T.Pago"
        Me.TPago.Name = "TPago"
        Me.TPago.ReadOnly = True
        Me.TPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TPago.Width = 60
        '
        'ImpoDespacho
        '
        Me.ImpoDespacho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ImpoDespacho.DataPropertyName = "ImpoDespacho"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ImpoDespacho.DefaultCellStyle = DataGridViewCellStyle1
        Me.ImpoDespacho.HeaderText = "Impo Despacho"
        Me.ImpoDespacho.Name = "ImpoDespacho"
        Me.ImpoDespacho.ReadOnly = True
        Me.ImpoDespacho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImpoDespacho.Width = 101
        '
        'PagoDes
        '
        Me.PagoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoDes.DataPropertyName = "PagoDes"
        Me.PagoDes.HeaderText = "Pago Des"
        Me.PagoDes.Name = "PagoDes"
        Me.PagoDes.ReadOnly = True
        Me.PagoDes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PagoDes.Width = 68
        '
        'LetraTotal
        '
        Me.LetraTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.LetraTotal.DataPropertyName = "LetraTotal"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.LetraTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.LetraTotal.HeaderText = "Letra Total"
        Me.LetraTotal.Name = "LetraTotal"
        Me.LetraTotal.ReadOnly = True
        Me.LetraTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LetraTotal.Width = 75
        '
        'PagoLetra
        '
        Me.PagoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PagoLetra.DataPropertyName = "PagoLetra"
        Me.PagoLetra.HeaderText = "Pago Letra"
        Me.PagoLetra.Name = "PagoLetra"
        Me.PagoLetra.ReadOnly = True
        Me.PagoLetra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PagoLetra.Width = 76
        '
        'VtoLetra
        '
        Me.VtoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VtoLetra.DataPropertyName = "VtoLetra"
        Me.VtoLetra.HeaderText = "Vto Letra"
        Me.VtoLetra.Name = "VtoLetra"
        Me.VtoLetra.ReadOnly = True
        Me.VtoLetra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VtoLetra.Width = 65
        '
        'USPagadoLetra
        '
        Me.USPagadoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.USPagadoLetra.DataPropertyName = "USPagadoLetra"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.USPagadoLetra.DefaultCellStyle = DataGridViewCellStyle3
        Me.USPagadoLetra.HeaderText = "U$S Pagado Letra"
        Me.USPagadoLetra.Name = "USPagadoLetra"
        Me.USPagadoLetra.ReadOnly = True
        Me.USPagadoLetra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.USPagadoLetra.Width = 118
        '
        'FEmbarque
        '
        Me.FEmbarque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FEmbarque.DataPropertyName = "FEmbarque"
        Me.FEmbarque.HeaderText = "F.Embarque"
        Me.FEmbarque.Name = "FEmbarque"
        Me.FEmbarque.ReadOnly = True
        Me.FEmbarque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FEmbarque.Width = 91
        '
        'SaldoLetra
        '
        Me.SaldoLetra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SaldoLetra.DataPropertyName = "SaldoLetra"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SaldoLetra.DefaultCellStyle = DataGridViewCellStyle4
        Me.SaldoLetra.HeaderText = "Saldo Letra"
        Me.SaldoLetra.Name = "SaldoLetra"
        Me.SaldoLetra.ReadOnly = True
        Me.SaldoLetra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SaldoLetra.Width = 78
        '
        'ProveedorCod
        '
        Me.ProveedorCod.DataPropertyName = "ProveedorCod"
        Me.ProveedorCod.HeaderText = "ProveedorCod"
        Me.ProveedorCod.Name = "ProveedorCod"
        Me.ProveedorCod.ReadOnly = True
        Me.ProveedorCod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProveedorCod.Visible = False
        '
        'BL
        '
        Me.BL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.BL.DataPropertyName = "BL"
        Me.BL.HeaderText = "BL"
        Me.BL.Name = "BL"
        Me.BL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BL.Width = 31
        '
        'Buque
        '
        Me.Buque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Buque.DataPropertyName = "Buque"
        Me.Buque.HeaderText = "Buque"
        Me.Buque.Name = "Buque"
        Me.Buque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Buque.Width = 55
        '
        'Contenedor
        '
        Me.Contenedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Contenedor.DataPropertyName = "Contenedor"
        Me.Contenedor.HeaderText = "Contenedor"
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Contenedor.Width = 88
        '
        'Despacho
        '
        Me.Despacho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Despacho.DataPropertyName = "Despacho"
        Me.Despacho.HeaderText = "Despacho"
        Me.Despacho.Name = "Despacho"
        Me.Despacho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Despacho.Width = 78
        '
        'Tipo_cbx
        '
        Me.Tipo_cbx.DataPropertyName = "Tipo_cbx"
        Me.Tipo_cbx.HeaderText = "Tipo"
        Me.Tipo_cbx.Name = "Tipo_cbx"
        Me.Tipo_cbx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tipo_cbx.Width = 70
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Estado.Width = 58
        '
        'FechaIngreso
        '
        Me.FechaIngreso.DataPropertyName = "FechaIngreso"
        Me.FechaIngreso.HeaderText = "Fecha Ingreso"
        Me.FechaIngreso.Name = "FechaIngreso"
        Me.FechaIngreso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FechaOrd
        '
        Me.FechaOrd.DataPropertyName = "FechaOrd"
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaOrd.Visible = False
        '
        'FLlegadaOrd
        '
        Me.FLlegadaOrd.DataPropertyName = "FLlegadaOrd"
        Me.FLlegadaOrd.HeaderText = "FLlegadaOrd"
        Me.FLlegadaOrd.Name = "FLlegadaOrd"
        Me.FLlegadaOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FLlegadaOrd.Visible = False
        '
        'VtoLetraOrd
        '
        Me.VtoLetraOrd.DataPropertyName = "VtoLetraOrd"
        Me.VtoLetraOrd.HeaderText = "VtoLetraOrd"
        Me.VtoLetraOrd.Name = "VtoLetraOrd"
        Me.VtoLetraOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VtoLetraOrd.Visible = False
        '
        'FembarqueOrd
        '
        Me.FembarqueOrd.DataPropertyName = "FembarqueOrd"
        Me.FembarqueOrd.HeaderText = "FembarqueOrd"
        Me.FembarqueOrd.Name = "FembarqueOrd"
        Me.FembarqueOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FembarqueOrd.Visible = False
        '
        'SaldoLetraOrd
        '
        Me.SaldoLetraOrd.DataPropertyName = "SaldoLetraOrd"
        Me.SaldoLetraOrd.HeaderText = "SaldoLetraOrd"
        Me.SaldoLetraOrd.Name = "SaldoLetraOrd"
        Me.SaldoLetraOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SaldoLetraOrd.Visible = False
        '
        'FechaIngresoOrd
        '
        Me.FechaIngresoOrd.DataPropertyName = "FechaIngresoOrd"
        Me.FechaIngresoOrd.HeaderText = "FechaIngresoOrd"
        Me.FechaIngresoOrd.Name = "FechaIngresoOrd"
        Me.FechaIngresoOrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaIngresoOrd.Visible = False
        '
        'Centro_Importaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1741, 800)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Centro_Importaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_Muestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_Muestra As Util.DBDataGridView
    Friend WithEvents lbl_ArticuloKg As System.Windows.Forms.Label
    Friend WithEvents txt_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Articulo As System.Windows.Forms.Label
    Friend WithEvents txt_SumaLetra As System.Windows.Forms.TextBox
    Friend WithEvents txt_SumaDespacho As System.Windows.Forms.TextBox
    Friend WithEvents chk_LetraPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Activas As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Actualiza As System.Windows.Forms.Button
    Friend WithEvents btn_Djai As System.Windows.Forms.Button
    Friend WithEvents btn_Exportacion As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents chk_DespachoPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carpeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DJai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Incoterms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLLegada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImpoDespacho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PagoDes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LetraTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PagoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VtoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USPagadoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FEmbarque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoLetra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProveedorCod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Buque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Contenedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despacho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_cbx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLlegadaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VtoLetraOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FembarqueOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoLetraOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIngresoOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
