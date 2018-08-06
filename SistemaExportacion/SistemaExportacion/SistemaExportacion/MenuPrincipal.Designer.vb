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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPrincipal = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAperturaArchivos = New System.Windows.Forms.Button()
        Me.btnHistorialProforma = New System.Windows.Forms.Button()
        Me.btnNuevaProforma = New System.Windows.Forms.Button()
        Me.LayoutFiltros = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckMostrarEntregadas = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.cmbTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFiltrarPor = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NroProforma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaLimite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingListImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Entregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(938, 479)
        Me.LayoutPrincipal.TabIndex = 0
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
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
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(938, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Exportaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(761, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutCuerpoPrincipal
        '
        Me.LayoutCuerpoPrincipal.ColumnCount = 2
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.dgvPrincipal, 1, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 101)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 1
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 378.0!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(938, 378)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.AllowUserToAddRows = False
        Me.dgvPrincipal.AllowUserToDeleteRows = False
        Me.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroProforma, Me.Fecha, Me.Cliente, Me.Razon, Me.Pais, Me.Total, Me.FechaLimite, Me.PackingList, Me.PackingListImg, Me.Entregado})
        Me.dgvPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrincipal.Location = New System.Drawing.Point(99, 15)
        Me.dgvPrincipal.Margin = New System.Windows.Forms.Padding(15)
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.Size = New System.Drawing.Size(824, 348)
        Me.dgvPrincipal.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnAperturaArchivos)
        Me.Panel1.Controls.Add(Me.btnHistorialProforma)
        Me.Panel1.Controls.Add(Me.btnNuevaProforma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(84, 378)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(5, 219)
        Me.Button1.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 56)
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
        Me.btnAperturaArchivos.Location = New System.Drawing.Point(5, 154)
        Me.btnAperturaArchivos.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnAperturaArchivos.Name = "btnAperturaArchivos"
        Me.btnAperturaArchivos.Size = New System.Drawing.Size(74, 56)
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
        Me.btnHistorialProforma.Location = New System.Drawing.Point(5, 89)
        Me.btnHistorialProforma.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnHistorialProforma.Name = "btnHistorialProforma"
        Me.btnHistorialProforma.Size = New System.Drawing.Size(74, 56)
        Me.btnHistorialProforma.TabIndex = 3
        Me.btnHistorialProforma.Text = "Historial de Proforma"
        Me.ToolTip1.SetToolTip(Me.btnHistorialProforma, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btnHistorialProforma.UseVisualStyleBackColor = True
        '
        'btnNuevaProforma
        '
        Me.btnNuevaProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevaProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaProforma.Location = New System.Drawing.Point(5, 24)
        Me.btnNuevaProforma.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnNuevaProforma.Name = "btnNuevaProforma"
        Me.btnNuevaProforma.Size = New System.Drawing.Size(74, 56)
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
        Me.LayoutFiltros.Location = New System.Drawing.Point(0, 45)
        Me.LayoutFiltros.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutFiltros.Name = "LayoutFiltros"
        Me.LayoutFiltros.RowCount = 1
        Me.LayoutFiltros.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.LayoutFiltros.Size = New System.Drawing.Size(938, 56)
        Me.LayoutFiltros.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(938, 56)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckMostrarEntregadas)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarFiltros)
        Me.GroupBox1.Controls.Add(Me.cmbTipoFiltro)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFiltrarPor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(22, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(901, 43)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar datos"
        '
        'ckMostrarEntregadas
        '
        Me.ckMostrarEntregadas.AutoSize = True
        Me.ckMostrarEntregadas.Location = New System.Drawing.Point(707, 17)
        Me.ckMostrarEntregadas.Name = "ckMostrarEntregadas"
        Me.ckMostrarEntregadas.Size = New System.Drawing.Size(175, 17)
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
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(572, 11)
        Me.btnLimpiarFiltros.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(123, 26)
        Me.btnLimpiarFiltros.TabIndex = 3
        Me.btnLimpiarFiltros.Text = "Limpiar Filtros"
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'cmbTipoFiltro
        '
        Me.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoFiltro.FormattingEnabled = True
        Me.cmbTipoFiltro.Items.AddRange(New Object() {"", "Nro de Proforma", "Fecha", "Cliente", "País", "S/Packing List", "Vencidas (S/Packing List)"})
        Me.cmbTipoFiltro.Location = New System.Drawing.Point(103, 15)
        Me.cmbTipoFiltro.Name = "cmbTipoFiltro"
        Me.cmbTipoFiltro.Size = New System.Drawing.Size(108, 21)
        Me.cmbTipoFiltro.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(34, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Columna:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(225, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aquellos que contengan:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrarPor
        '
        Me.txtFiltrarPor.Location = New System.Drawing.Point(390, 15)
        Me.txtFiltrarPor.Name = "txtFiltrarPor"
        Me.txtFiltrarPor.Size = New System.Drawing.Size(164, 20)
        Me.txtFiltrarPor.TabIndex = 0
        '
        'NroProforma
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroProforma.DefaultCellStyle = DataGridViewCellStyle1
        Me.NroProforma.HeaderText = "Nro Proforma"
        Me.NroProforma.MaxInputLength = 6
        Me.NroProforma.Name = "NroProforma"
        Me.NroProforma.ReadOnly = True
        '
        'Fecha
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 10
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MaxInputLength = 6
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        '
        'Pais
        '
        Me.Pais.HeaderText = "Pais"
        Me.Pais.Name = "Pais"
        Me.Pais.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle3
        Me.Total.HeaderText = "Monto Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'FechaLimite
        '
        Me.FechaLimite.HeaderText = "FechaLimite"
        Me.FechaLimite.MaxInputLength = 8
        Me.FechaLimite.Name = "FechaLimite"
        Me.FechaLimite.ReadOnly = True
        Me.FechaLimite.Visible = False
        '
        'PackingList
        '
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
        Me.PackingListImg.Width = 90
        '
        'Entregado
        '
        Me.Entregado.HeaderText = "Entregado"
        Me.Entregado.Name = "Entregado"
        Me.Entregado.ReadOnly = True
        Me.Entregado.Visible = False
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 479)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents NroProforma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaLimite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingListImg As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Entregado As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
