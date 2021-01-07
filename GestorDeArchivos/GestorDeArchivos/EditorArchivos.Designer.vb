<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorArchivos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorArchivos))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.FechaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icono = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PathArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarNombreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.cmb_Carpeta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbx_Carpetas = New System.Windows.Forms.GroupBox()
        Me.lbl_CarpetasCompletas = New System.Windows.Forms.Label()
        Me.Img_INVOIS = New System.Windows.Forms.Button()
        Me.Img_BL = New System.Windows.Forms.Button()
        Me.Img_COAS = New System.Windows.Forms.Button()
        Me.Img_PackingList = New System.Windows.Forms.Button()
        Me.Img_OrdenDeCompra = New System.Windows.Forms.Button()
        Me.Img_SIMI = New System.Windows.Forms.Button()
        Me.Img_Proforma = New System.Windows.Forms.Button()
        Me.Img_General = New System.Windows.Forms.Button()
        Me.rbn_INVOIS = New System.Windows.Forms.RadioButton()
        Me.rbn_BL = New System.Windows.Forms.RadioButton()
        Me.rbn_COAS = New System.Windows.Forms.RadioButton()
        Me.rbn_PackingList = New System.Windows.Forms.RadioButton()
        Me.rbn_OrdenDeCompra = New System.Windows.Forms.RadioButton()
        Me.rbn_SIMI = New System.Windows.Forms.RadioButton()
        Me.rbn_Proforma = New System.Windows.Forms.RadioButton()
        Me.rbn_General = New System.Windows.Forms.RadioButton()
        Me.pnl_CambioNombre = New System.Windows.Forms.Panel()
        Me.txt_NuevoNombre = New System.Windows.Forms.TextBox()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbx_Carpetas.SuspendLayout()
        Me.pnl_CambioNombre.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(490, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(164, 23)
        Me.Button3.TabIndex = 58
        Me.Button3.Text = "CERRAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(173, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 23)
        Me.Button2.TabIndex = 59
        Me.Button2.Text = "Eliminar Archivo(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 23)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Agregar Archivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaArchivo, Me.DescArchivo, Me.Icono, Me.PathArchivo, Me.Operador})
        Me.dgvArchivos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvArchivos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvArchivos.Location = New System.Drawing.Point(0, 103)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersWidth = 15
        Me.dgvArchivos.RowTemplate.Height = 30
        Me.dgvArchivos.ShowCellToolTips = False
        Me.dgvArchivos.Size = New System.Drawing.Size(658, 244)
        Me.dgvArchivos.TabIndex = 56
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
        'Operador
        '
        Me.Operador.HeaderText = "Operador"
        Me.Operador.Name = "Operador"
        Me.Operador.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PegarToolStripMenuItem, Me.CambiarNombreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(167, 48)
        '
        'PegarToolStripMenuItem
        '
        Me.PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        Me.PegarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.PegarToolStripMenuItem.Text = "Pegar"
        '
        'CambiarNombreToolStripMenuItem
        '
        Me.CambiarNombreToolStripMenuItem.Name = "CambiarNombreToolStripMenuItem"
        Me.CambiarNombreToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CambiarNombreToolStripMenuItem.Text = "Cambiar Nombre"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(490, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Gestor de Archivos"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 54)
        Me.Panel1.TabIndex = 61
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'cmb_Carpeta
        '
        Me.cmb_Carpeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Carpeta.FormattingEnabled = True
        Me.cmb_Carpeta.Location = New System.Drawing.Point(356, 72)
        Me.cmb_Carpeta.Name = "cmb_Carpeta"
        Me.cmb_Carpeta.Size = New System.Drawing.Size(121, 21)
        Me.cmb_Carpeta.TabIndex = 62
        Me.cmb_Carpeta.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Carpeta"
        Me.Label3.Visible = False
        '
        'gbx_Carpetas
        '
        Me.gbx_Carpetas.Controls.Add(Me.lbl_CarpetasCompletas)
        Me.gbx_Carpetas.Controls.Add(Me.Img_INVOIS)
        Me.gbx_Carpetas.Controls.Add(Me.Img_BL)
        Me.gbx_Carpetas.Controls.Add(Me.Img_COAS)
        Me.gbx_Carpetas.Controls.Add(Me.Img_PackingList)
        Me.gbx_Carpetas.Controls.Add(Me.Img_OrdenDeCompra)
        Me.gbx_Carpetas.Controls.Add(Me.Img_SIMI)
        Me.gbx_Carpetas.Controls.Add(Me.Img_Proforma)
        Me.gbx_Carpetas.Controls.Add(Me.Img_General)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_INVOIS)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_BL)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_COAS)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_PackingList)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_OrdenDeCompra)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_SIMI)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_Proforma)
        Me.gbx_Carpetas.Controls.Add(Me.rbn_General)
        Me.gbx_Carpetas.Location = New System.Drawing.Point(7, 110)
        Me.gbx_Carpetas.Name = "gbx_Carpetas"
        Me.gbx_Carpetas.Size = New System.Drawing.Size(633, 64)
        Me.gbx_Carpetas.TabIndex = 64
        Me.gbx_Carpetas.TabStop = False
        Me.gbx_Carpetas.Text = "Carpetas"
        Me.gbx_Carpetas.Visible = False
        '
        'lbl_CarpetasCompletas
        '
        Me.lbl_CarpetasCompletas.AutoSize = True
        Me.lbl_CarpetasCompletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CarpetasCompletas.ForeColor = System.Drawing.Color.Green
        Me.lbl_CarpetasCompletas.Location = New System.Drawing.Point(483, 13)
        Me.lbl_CarpetasCompletas.Name = "lbl_CarpetasCompletas"
        Me.lbl_CarpetasCompletas.Size = New System.Drawing.Size(143, 26)
        Me.lbl_CarpetasCompletas.TabIndex = 24
        Me.lbl_CarpetasCompletas.Text = "SE CARGARON TODOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      LOS ARCHIVOS"
        '
        'Img_INVOIS
        '
        Me.Img_INVOIS.BackgroundImage = CType(resources.GetObject("Img_INVOIS.BackgroundImage"), System.Drawing.Image)
        Me.Img_INVOIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_INVOIS.Enabled = False
        Me.Img_INVOIS.Location = New System.Drawing.Point(481, 38)
        Me.Img_INVOIS.Name = "Img_INVOIS"
        Me.Img_INVOIS.Size = New System.Drawing.Size(21, 20)
        Me.Img_INVOIS.TabIndex = 23
        Me.Img_INVOIS.UseVisualStyleBackColor = True
        Me.Img_INVOIS.Visible = False
        '
        'Img_BL
        '
        Me.Img_BL.BackgroundImage = CType(resources.GetObject("Img_BL.BackgroundImage"), System.Drawing.Image)
        Me.Img_BL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_BL.Enabled = False
        Me.Img_BL.Location = New System.Drawing.Point(454, 16)
        Me.Img_BL.Name = "Img_BL"
        Me.Img_BL.Size = New System.Drawing.Size(21, 20)
        Me.Img_BL.TabIndex = 22
        Me.Img_BL.UseVisualStyleBackColor = True
        Me.Img_BL.Visible = False
        '
        'Img_COAS
        '
        Me.Img_COAS.BackgroundImage = CType(resources.GetObject("Img_COAS.BackgroundImage"), System.Drawing.Image)
        Me.Img_COAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_COAS.Enabled = False
        Me.Img_COAS.Location = New System.Drawing.Point(343, 38)
        Me.Img_COAS.Name = "Img_COAS"
        Me.Img_COAS.Size = New System.Drawing.Size(21, 20)
        Me.Img_COAS.TabIndex = 21
        Me.Img_COAS.UseVisualStyleBackColor = True
        Me.Img_COAS.Visible = False
        '
        'Img_PackingList
        '
        Me.Img_PackingList.BackgroundImage = CType(resources.GetObject("Img_PackingList.BackgroundImage"), System.Drawing.Image)
        Me.Img_PackingList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_PackingList.Enabled = False
        Me.Img_PackingList.Location = New System.Drawing.Point(371, 15)
        Me.Img_PackingList.Name = "Img_PackingList"
        Me.Img_PackingList.Size = New System.Drawing.Size(21, 20)
        Me.Img_PackingList.TabIndex = 20
        Me.Img_PackingList.UseVisualStyleBackColor = True
        Me.Img_PackingList.Visible = False
        '
        'Img_OrdenDeCompra
        '
        Me.Img_OrdenDeCompra.BackgroundImage = CType(resources.GetObject("Img_OrdenDeCompra.BackgroundImage"), System.Drawing.Image)
        Me.Img_OrdenDeCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_OrdenDeCompra.Enabled = False
        Me.Img_OrdenDeCompra.Location = New System.Drawing.Point(239, 38)
        Me.Img_OrdenDeCompra.Name = "Img_OrdenDeCompra"
        Me.Img_OrdenDeCompra.Size = New System.Drawing.Size(21, 20)
        Me.Img_OrdenDeCompra.TabIndex = 19
        Me.Img_OrdenDeCompra.UseVisualStyleBackColor = True
        Me.Img_OrdenDeCompra.Visible = False
        '
        'Img_SIMI
        '
        Me.Img_SIMI.BackgroundImage = CType(resources.GetObject("Img_SIMI.BackgroundImage"), System.Drawing.Image)
        Me.Img_SIMI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_SIMI.Enabled = False
        Me.Img_SIMI.Location = New System.Drawing.Point(190, 15)
        Me.Img_SIMI.Name = "Img_SIMI"
        Me.Img_SIMI.Size = New System.Drawing.Size(21, 20)
        Me.Img_SIMI.TabIndex = 18
        Me.Img_SIMI.UseVisualStyleBackColor = True
        Me.Img_SIMI.Visible = False
        '
        'Img_Proforma
        '
        Me.Img_Proforma.BackgroundImage = CType(resources.GetObject("Img_Proforma.BackgroundImage"), System.Drawing.Image)
        Me.Img_Proforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_Proforma.Enabled = False
        Me.Img_Proforma.Location = New System.Drawing.Point(94, 38)
        Me.Img_Proforma.Name = "Img_Proforma"
        Me.Img_Proforma.Size = New System.Drawing.Size(21, 20)
        Me.Img_Proforma.TabIndex = 17
        Me.Img_Proforma.UseVisualStyleBackColor = True
        Me.Img_Proforma.Visible = False
        '
        'Img_General
        '
        Me.Img_General.BackgroundImage = CType(resources.GetObject("Img_General.BackgroundImage"), System.Drawing.Image)
        Me.Img_General.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Img_General.Enabled = False
        Me.Img_General.Location = New System.Drawing.Point(92, 15)
        Me.Img_General.Name = "Img_General"
        Me.Img_General.Size = New System.Drawing.Size(21, 20)
        Me.Img_General.TabIndex = 16
        Me.Img_General.UseVisualStyleBackColor = True
        Me.Img_General.Visible = False
        '
        'rbn_INVOIS
        '
        Me.rbn_INVOIS.AutoSize = True
        Me.rbn_INVOIS.Location = New System.Drawing.Point(398, 42)
        Me.rbn_INVOIS.Name = "rbn_INVOIS"
        Me.rbn_INVOIS.Size = New System.Drawing.Size(85, 17)
        Me.rbn_INVOIS.TabIndex = 7
        Me.rbn_INVOIS.Text = "(00) IN VOIS"
        Me.rbn_INVOIS.UseVisualStyleBackColor = True
        '
        'rbn_BL
        '
        Me.rbn_BL.AutoSize = True
        Me.rbn_BL.Location = New System.Drawing.Point(398, 19)
        Me.rbn_BL.Name = "rbn_BL"
        Me.rbn_BL.Size = New System.Drawing.Size(59, 17)
        Me.rbn_BL.TabIndex = 6
        Me.rbn_BL.Text = "(00) BL"
        Me.rbn_BL.UseVisualStyleBackColor = True
        '
        'rbn_COAS
        '
        Me.rbn_COAS.AutoSize = True
        Me.rbn_COAS.Location = New System.Drawing.Point(269, 41)
        Me.rbn_COAS.Name = "rbn_COAS"
        Me.rbn_COAS.Size = New System.Drawing.Size(75, 17)
        Me.rbn_COAS.TabIndex = 5
        Me.rbn_COAS.Text = "(00) COAS"
        Me.rbn_COAS.UseVisualStyleBackColor = True
        '
        'rbn_PackingList
        '
        Me.rbn_PackingList.AutoSize = True
        Me.rbn_PackingList.Location = New System.Drawing.Point(269, 19)
        Me.rbn_PackingList.Name = "rbn_PackingList"
        Me.rbn_PackingList.Size = New System.Drawing.Size(104, 17)
        Me.rbn_PackingList.TabIndex = 4
        Me.rbn_PackingList.Text = "(00) Packing List"
        Me.rbn_PackingList.UseVisualStyleBackColor = True
        '
        'rbn_OrdenDeCompra
        '
        Me.rbn_OrdenDeCompra.AutoSize = True
        Me.rbn_OrdenDeCompra.Location = New System.Drawing.Point(116, 41)
        Me.rbn_OrdenDeCompra.Name = "rbn_OrdenDeCompra"
        Me.rbn_OrdenDeCompra.Size = New System.Drawing.Size(129, 17)
        Me.rbn_OrdenDeCompra.TabIndex = 3
        Me.rbn_OrdenDeCompra.Text = "(00) Orden de Compra"
        Me.rbn_OrdenDeCompra.UseVisualStyleBackColor = True
        '
        'rbn_SIMI
        '
        Me.rbn_SIMI.AutoSize = True
        Me.rbn_SIMI.Location = New System.Drawing.Point(116, 20)
        Me.rbn_SIMI.Name = "rbn_SIMI"
        Me.rbn_SIMI.Size = New System.Drawing.Size(68, 17)
        Me.rbn_SIMI.TabIndex = 2
        Me.rbn_SIMI.Text = "(00) SIMI"
        Me.rbn_SIMI.UseVisualStyleBackColor = True
        '
        'rbn_Proforma
        '
        Me.rbn_Proforma.AutoSize = True
        Me.rbn_Proforma.Location = New System.Drawing.Point(9, 41)
        Me.rbn_Proforma.Name = "rbn_Proforma"
        Me.rbn_Proforma.Size = New System.Drawing.Size(88, 17)
        Me.rbn_Proforma.TabIndex = 1
        Me.rbn_Proforma.Text = "(00) Proforma"
        Me.rbn_Proforma.UseVisualStyleBackColor = True
        '
        'rbn_General
        '
        Me.rbn_General.AutoSize = True
        Me.rbn_General.Checked = True
        Me.rbn_General.Location = New System.Drawing.Point(9, 20)
        Me.rbn_General.Name = "rbn_General"
        Me.rbn_General.Size = New System.Drawing.Size(83, 17)
        Me.rbn_General.TabIndex = 0
        Me.rbn_General.TabStop = True
        Me.rbn_General.Text = "(00) General"
        Me.rbn_General.UseVisualStyleBackColor = True
        '
        'pnl_CambioNombre
        '
        Me.pnl_CambioNombre.Controls.Add(Me.txt_NuevoNombre)
        Me.pnl_CambioNombre.Controls.Add(Me.btn_Cancelar)
        Me.pnl_CambioNombre.Controls.Add(Me.Panel3)
        Me.pnl_CambioNombre.Location = New System.Drawing.Point(221, 175)
        Me.pnl_CambioNombre.Name = "pnl_CambioNombre"
        Me.pnl_CambioNombre.Size = New System.Drawing.Size(200, 100)
        Me.pnl_CambioNombre.TabIndex = 65
        Me.pnl_CambioNombre.Visible = False
        '
        'txt_NuevoNombre
        '
        Me.txt_NuevoNombre.Location = New System.Drawing.Point(3, 44)
        Me.txt_NuevoNombre.Name = "txt_NuevoNombre"
        Me.txt_NuevoNombre.Size = New System.Drawing.Size(194, 20)
        Me.txt_NuevoNombre.TabIndex = 64
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(61, 70)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.TabIndex = 63
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 30)
        Me.Panel3.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(16, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 19)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Ingrese Nuevo Nombre"
        '
        'EditorArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 347)
        Me.Controls.Add(Me.pnl_CambioNombre)
        Me.Controls.Add(Me.gbx_Carpetas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_Carpeta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvArchivos)
        Me.Name = "EditorArchivos"
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbx_Carpetas.ResumeLayout(False)
        Me.gbx_Carpetas.PerformLayout()
        Me.pnl_CambioNombre.ResumeLayout(False)
        Me.pnl_CambioNombre.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvArchivos As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmb_Carpeta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbx_Carpetas As System.Windows.Forms.GroupBox
    Friend WithEvents rbn_COAS As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_PackingList As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_OrdenDeCompra As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_SIMI As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_Proforma As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_General As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_BL As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_INVOIS As System.Windows.Forms.RadioButton
    Friend WithEvents Img_INVOIS As System.Windows.Forms.Button
    Friend WithEvents Img_BL As System.Windows.Forms.Button
    Friend WithEvents Img_COAS As System.Windows.Forms.Button
    Friend WithEvents Img_PackingList As System.Windows.Forms.Button
    Friend WithEvents Img_OrdenDeCompra As System.Windows.Forms.Button
    Friend WithEvents Img_SIMI As System.Windows.Forms.Button
    Friend WithEvents Img_Proforma As System.Windows.Forms.Button
    Friend WithEvents Img_General As System.Windows.Forms.Button
    Friend WithEvents lbl_CarpetasCompletas As System.Windows.Forms.Label
    Friend WithEvents FechaArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Icono As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PathArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CambiarNombreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_CambioNombre As System.Windows.Forms.Panel
    Friend WithEvents txt_NuevoNombre As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
