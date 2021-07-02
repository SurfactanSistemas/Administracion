<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPrincipal = New System.Windows.Forms.DataGridView()
        Me.NroProforma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Combox_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaLimite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingListImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Entregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Limite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Incoterm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MV_Buque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETD_FechaSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETA_FechaArribo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso_Neto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Permiso_de_Embarque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Forwarder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Cobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Menustrip_Grilla = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Exportar_Excel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAperturaArchivos = New System.Windows.Forms.Button()
        Me.btnHistorialProforma = New System.Windows.Forms.Button()
        Me.btnNuevaProforma = New System.Windows.Forms.Button()
        Me.LayoutFiltros = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_BuscarProducto = New System.Windows.Forms.Button()
        Me.txt_Producto = New System.Windows.Forms.MaskedTextBox()
        Me.ckMostrarEntregadas = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.cmbTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFiltrarPor = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menustrip_Grilla.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.LayoutFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCabecera, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCuerpoPrincipal, 0, 2)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutFiltros, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 3
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(1378, 590)
        Me.LayoutPrincipal.TabIndex = 0
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.LayoutCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.LayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCabecera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutCabecera.ForeColor = System.Drawing.SystemColors.Control
        Me.LayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.LayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCabecera.Name = "LayoutCabecera"
        Me.LayoutCabecera.RowCount = 1
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(1378, 55)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Exportaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1142, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 55)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutCuerpoPrincipal
        '
        Me.LayoutCuerpoPrincipal.ColumnCount = 2
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.dgvPrincipal, 1, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 124)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 1
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 466.0!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(1378, 466)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.AllowUserToAddRows = False
        Me.dgvPrincipal.AllowUserToDeleteRows = False
        Me.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroProforma, Me.Fecha, Me.Cliente, Me.Razon, Me.Pais, Me.Total, Me.Combox_Estado, Me.FechaLimite, Me.PackingList, Me.PackingListImg, Me.Entregado, Me.Fecha_Limite, Me.Incoterm, Me.MV_Buque, Me.ETD_FechaSalida, Me.ETA_FechaArribo, Me.Peso_Neto, Me.Permiso_de_Embarque, Me.BL, Me.Forwarder, Me.Fecha_Cobro, Me.NroFactura, Me.SaldoFactura})
        Me.dgvPrincipal.ContextMenuStrip = Me.Menustrip_Grilla
        Me.dgvPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrincipal.Location = New System.Drawing.Point(132, 18)
        Me.dgvPrincipal.Margin = New System.Windows.Forms.Padding(20, 18, 20, 18)
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.Size = New System.Drawing.Size(1226, 430)
        Me.dgvPrincipal.TabIndex = 0
        '
        'NroProforma
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroProforma.DefaultCellStyle = DataGridViewCellStyle7
        Me.NroProforma.HeaderText = "Nro Proforma"
        Me.NroProforma.MaxInputLength = 6
        Me.NroProforma.Name = "NroProforma"
        Me.NroProforma.ReadOnly = True
        Me.NroProforma.Width = 55
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle8
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 10
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 76
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MaxInputLength = 6
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 50
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        Me.Razon.Width = 110
        '
        'Pais
        '
        Me.Pais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pais.HeaderText = "Pais"
        Me.Pais.Name = "Pais"
        Me.Pais.ReadOnly = True
        Me.Pais.Width = 64
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle9
        Me.Total.HeaderText = "Monto Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 103
        '
        'Combox_Estado
        '
        Me.Combox_Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Combox_Estado.HeaderText = "Estado"
        Me.Combox_Estado.Name = "Combox_Estado"
        Me.Combox_Estado.ReadOnly = True
        Me.Combox_Estado.Width = 81
        '
        'FechaLimite
        '
        Me.FechaLimite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaLimite.HeaderText = "OrdFechaLimite"
        Me.FechaLimite.MaxInputLength = 8
        Me.FechaLimite.Name = "FechaLimite"
        Me.FechaLimite.ReadOnly = True
        Me.FechaLimite.Visible = False
        '
        'PackingList
        '
        Me.PackingList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PackingList.HeaderText = "PackingList"
        Me.PackingList.Name = "PackingList"
        Me.PackingList.ReadOnly = True
        Me.PackingList.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PackingList.Visible = False
        '
        'PackingListImg
        '
        Me.PackingListImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PackingListImg.HeaderText = "Packing List"
        Me.PackingListImg.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.PackingListImg.Name = "PackingListImg"
        Me.PackingListImg.ReadOnly = True
        Me.PackingListImg.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PackingListImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PackingListImg.Width = 104
        '
        'Entregado
        '
        Me.Entregado.HeaderText = "Entregado"
        Me.Entregado.Name = "Entregado"
        Me.Entregado.ReadOnly = True
        Me.Entregado.Visible = False
        '
        'Fecha_Limite
        '
        Me.Fecha_Limite.HeaderText = "Fecha Limite"
        Me.Fecha_Limite.Name = "Fecha_Limite"
        Me.Fecha_Limite.ReadOnly = True
        Me.Fecha_Limite.Width = 70
        '
        'Incoterm
        '
        Me.Incoterm.HeaderText = "Incoterm"
        Me.Incoterm.Name = "Incoterm"
        Me.Incoterm.ReadOnly = True
        Me.Incoterm.Width = 55
        '
        'MV_Buque
        '
        Me.MV_Buque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MV_Buque.HeaderText = "M.V."
        Me.MV_Buque.Name = "MV_Buque"
        Me.MV_Buque.ReadOnly = True
        Me.MV_Buque.Width = 65
        '
        'ETD_FechaSalida
        '
        Me.ETD_FechaSalida.HeaderText = "E.T.D"
        Me.ETD_FechaSalida.Name = "ETD_FechaSalida"
        Me.ETD_FechaSalida.ReadOnly = True
        Me.ETD_FechaSalida.Width = 70
        '
        'ETA_FechaArribo
        '
        Me.ETA_FechaArribo.HeaderText = "E.T.A"
        Me.ETA_FechaArribo.Name = "ETA_FechaArribo"
        Me.ETA_FechaArribo.ReadOnly = True
        Me.ETA_FechaArribo.Width = 70
        '
        'Peso_Neto
        '
        Me.Peso_Neto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Peso_Neto.DefaultCellStyle = DataGridViewCellStyle10
        Me.Peso_Neto.HeaderText = "Peso Neto"
        Me.Peso_Neto.Name = "Peso_Neto"
        Me.Peso_Neto.ReadOnly = True
        Me.Peso_Neto.Width = 95
        '
        'Permiso_de_Embarque
        '
        Me.Permiso_de_Embarque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Permiso_de_Embarque.HeaderText = "Permiso de Embarque"
        Me.Permiso_de_Embarque.Name = "Permiso_de_Embarque"
        Me.Permiso_de_Embarque.ReadOnly = True
        Me.Permiso_de_Embarque.Width = 162
        '
        'BL
        '
        Me.BL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.BL.HeaderText = "BL"
        Me.BL.MinimumWidth = 45
        Me.BL.Name = "BL"
        Me.BL.ReadOnly = True
        Me.BL.Width = 54
        '
        'Forwarder
        '
        Me.Forwarder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Forwarder.HeaderText = "Forwarder"
        Me.Forwarder.Name = "Forwarder"
        Me.Forwarder.ReadOnly = True
        Me.Forwarder.Width = 101
        '
        'Fecha_Cobro
        '
        Me.Fecha_Cobro.HeaderText = "Fecha Cobro"
        Me.Fecha_Cobro.Name = "Fecha_Cobro"
        Me.Fecha_Cobro.ReadOnly = True
        '
        'NroFactura
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroFactura.DefaultCellStyle = DataGridViewCellStyle11
        Me.NroFactura.HeaderText = "Nro. Factura"
        Me.NroFactura.Name = "NroFactura"
        Me.NroFactura.ReadOnly = True
        '
        'SaldoFactura
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SaldoFactura.DefaultCellStyle = DataGridViewCellStyle12
        Me.SaldoFactura.HeaderText = "Saldo Factura"
        Me.SaldoFactura.Name = "SaldoFactura"
        Me.SaldoFactura.ReadOnly = True
        '
        'Menustrip_Grilla
        '
        Me.Menustrip_Grilla.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Menustrip_Grilla.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.Menustrip_Grilla.Name = "Menustrip_Grilla"
        Me.Menustrip_Grilla.Size = New System.Drawing.Size(234, 28)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(233, 24)
        Me.ToolStripMenuItem1.Text = "Exportar Seleccionados"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Exportar_Excel)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnAperturaArchivos)
        Me.Panel1.Controls.Add(Me.btnHistorialProforma)
        Me.Panel1.Controls.Add(Me.btnNuevaProforma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 466)
        Me.Panel1.TabIndex = 1
        '
        'btn_Exportar_Excel
        '
        Me.btn_Exportar_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Exportar_Excel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exportar_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exportar_Excel.Location = New System.Drawing.Point(7, 385)
        Me.btn_Exportar_Excel.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.btn_Exportar_Excel.Name = "btn_Exportar_Excel"
        Me.btn_Exportar_Excel.Size = New System.Drawing.Size(99, 69)
        Me.btn_Exportar_Excel.TabIndex = 4
        Me.btn_Exportar_Excel.Text = "Exportar a Excel"
        Me.ToolTip1.SetToolTip(Me.btn_Exportar_Excel, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btn_Exportar_Excel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(7, 185)
        Me.Button1.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 69)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cerrar"
        Me.ToolTip1.SetToolTip(Me.Button1, "Cerrar Sistema")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAperturaArchivos
        '
        Me.btnAperturaArchivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAperturaArchivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAperturaArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAperturaArchivos.Location = New System.Drawing.Point(7, 107)
        Me.btnAperturaArchivos.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.btnAperturaArchivos.Name = "btnAperturaArchivos"
        Me.btnAperturaArchivos.Size = New System.Drawing.Size(99, 69)
        Me.btnAperturaArchivos.TabIndex = 3
        Me.btnAperturaArchivos.Text = "Apertura por Articulos"
        Me.ToolTip1.SetToolTip(Me.btnAperturaArchivos, "Desplegar Información de Articulos por Proforma")
        Me.btnAperturaArchivos.UseVisualStyleBackColor = True
        '
        'btnHistorialProforma
        '
        Me.btnHistorialProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHistorialProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHistorialProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistorialProforma.Location = New System.Drawing.Point(7, 261)
        Me.btnHistorialProforma.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.btnHistorialProforma.Name = "btnHistorialProforma"
        Me.btnHistorialProforma.Size = New System.Drawing.Size(99, 69)
        Me.btnHistorialProforma.TabIndex = 3
        Me.btnHistorialProforma.Text = "Historial de Proforma"
        Me.ToolTip1.SetToolTip(Me.btnHistorialProforma, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btnHistorialProforma.UseVisualStyleBackColor = True
        Me.btnHistorialProforma.Visible = False
        '
        'btnNuevaProforma
        '
        Me.btnNuevaProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevaProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaProforma.Location = New System.Drawing.Point(7, 30)
        Me.btnNuevaProforma.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.btnNuevaProforma.Name = "btnNuevaProforma"
        Me.btnNuevaProforma.Size = New System.Drawing.Size(99, 69)
        Me.btnNuevaProforma.TabIndex = 2
        Me.btnNuevaProforma.Text = "Nueva Proforma"
        Me.ToolTip1.SetToolTip(Me.btnNuevaProforma, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btnNuevaProforma.UseVisualStyleBackColor = True
        '
        'LayoutFiltros
        '
        Me.LayoutFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.LayoutFiltros.ColumnCount = 1
        Me.LayoutFiltros.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.LayoutFiltros.Controls.Add(Me.Panel2, 0, 0)
        Me.LayoutFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutFiltros.Location = New System.Drawing.Point(0, 55)
        Me.LayoutFiltros.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutFiltros.Name = "LayoutFiltros"
        Me.LayoutFiltros.RowCount = 1
        Me.LayoutFiltros.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.LayoutFiltros.Size = New System.Drawing.Size(1378, 69)
        Me.LayoutFiltros.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1378, 69)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_BuscarProducto)
        Me.GroupBox1.Controls.Add(Me.txt_Producto)
        Me.GroupBox1.Controls.Add(Me.ckMostrarEntregadas)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarFiltros)
        Me.GroupBox1.Controls.Add(Me.cmbTipoFiltro)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFiltrarPor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(13, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1361, 65)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar datos"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(1094, 35)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(260, 23)
        Me.ProgressBar1.TabIndex = 8
        Me.ProgressBar1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(679, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Producto:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_BuscarProducto
        '
        Me.btn_BuscarProducto.BackgroundImage = Global.SistemaExportacion.My.Resources.Resources.Consulta_Dat_N1
        Me.btn_BuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_BuscarProducto.Location = New System.Drawing.Point(886, 22)
        Me.btn_BuscarProducto.Name = "btn_BuscarProducto"
        Me.btn_BuscarProducto.Size = New System.Drawing.Size(34, 32)
        Me.btn_BuscarProducto.TabIndex = 6
        Me.btn_BuscarProducto.Text = "Button2"
        Me.ToolTip1.SetToolTip(Me.btn_BuscarProducto, "Buscar por Producto")
        Me.btn_BuscarProducto.UseVisualStyleBackColor = True
        '
        'txt_Producto
        '
        Me.txt_Producto.Location = New System.Drawing.Point(769, 26)
        Me.txt_Producto.Mask = ">LL-00000-000"
        Me.txt_Producto.Name = "txt_Producto"
        Me.txt_Producto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Producto.Size = New System.Drawing.Size(117, 23)
        Me.txt_Producto.TabIndex = 5
        '
        'ckMostrarEntregadas
        '
        Me.ckMostrarEntregadas.AutoSize = True
        Me.ckMostrarEntregadas.Location = New System.Drawing.Point(1100, 12)
        Me.ckMostrarEntregadas.Margin = New System.Windows.Forms.Padding(4)
        Me.ckMostrarEntregadas.Name = "ckMostrarEntregadas"
        Me.ckMostrarEntregadas.Size = New System.Drawing.Size(224, 21)
        Me.ckMostrarEntregadas.TabIndex = 4
        Me.ckMostrarEntregadas.Text = "Incluir Proformas Cerradas"
        Me.ckMostrarEntregadas.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(936, 19)
        Me.btnLimpiarFiltros.Margin = New System.Windows.Forms.Padding(13, 12, 0, 12)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(137, 32)
        Me.btnLimpiarFiltros.TabIndex = 3
        Me.btnLimpiarFiltros.Text = "Limpiar Filtros"
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'cmbTipoFiltro
        '
        Me.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoFiltro.FormattingEnabled = True
        Me.cmbTipoFiltro.Items.AddRange(New Object() {"", "Nro de Proforma", "Fecha", "Cliente", "País", "S/Packing List", "Vencidas (S/Packing List)", "Razon Social", "Fecha Limite", "M.V.", "E.T.D", "E.T.A", "Peso Neto", "Permiso de Embarque", "BL", "Forwarder", "Estado"})
        Me.cmbTipoFiltro.Location = New System.Drawing.Point(86, 26)
        Me.cmbTipoFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipoFiltro.Name = "cmbTipoFiltro"
        Me.cmbTipoFiltro.Size = New System.Drawing.Size(143, 25)
        Me.cmbTipoFiltro.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(5, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 23)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Columna:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(236, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aquellos que contengan:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrarPor
        '
        Me.txtFiltrarPor.Location = New System.Drawing.Point(442, 26)
        Me.txtFiltrarPor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltrarPor.Name = "txtFiltrarPor"
        Me.txtFiltrarPor.Size = New System.Drawing.Size(217, 23)
        Me.txtFiltrarPor.TabIndex = 0
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1378, 590)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menustrip_Grilla.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.LayoutFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LayoutCuerpoPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutFiltros As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvPrincipal As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnHistorialProforma As System.Windows.Forms.Button
    Friend WithEvents btnNuevaProforma As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbTipoFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFiltrarPor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnAperturaArchivos As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents ckMostrarEntregadas As System.Windows.Forms.CheckBox
    Friend WithEvents Menustrip_Grilla As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Exportar_Excel As System.Windows.Forms.Button
    Friend WithEvents NroProforma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Combox_Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaLimite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingListImg As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Entregado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Limite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Incoterm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MV_Buque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD_FechaSalida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA_FechaArribo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso_Neto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Permiso_de_Embarque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Forwarder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Cobro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_BuscarProducto As System.Windows.Forms.Button
    Friend WithEvents txt_Producto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
