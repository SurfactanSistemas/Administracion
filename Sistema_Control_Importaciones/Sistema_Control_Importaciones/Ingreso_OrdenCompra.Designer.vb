<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingreso_OrdenCompra
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGV_Orden = New Util.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PosicionArancelaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Derechos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_FechaImpo = New System.Windows.Forms.MaskedTextBox()
        Me.cbx_TipoImpo = New System.Windows.Forms.ComboBox()
        Me.cbx_TipoPago = New System.Windows.Forms.ComboBox()
        Me.cbx_Leyenda = New System.Windows.Forms.ComboBox()
        Me.txt_FechaDjai = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Djai = New System.Windows.Forms.TextBox()
        Me.txt_Flete = New System.Windows.Forms.TextBox()
        Me.txt_PedidoImpo = New System.Windows.Forms.TextBox()
        Me.txt_Origen = New System.Windows.Forms.TextBox()
        Me.cbx_Moneda = New System.Windows.Forms.ComboBox()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Carpeta = New System.Windows.Forms.TextBox()
        Me.txt_DesProveedor = New System.Windows.Forms.TextBox()
        Me.txt_Proveedor = New System.Windows.Forms.TextBox()
        Me.txt_Orden = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.DGV_Orden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(881, 473)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(197, 41)
        Me.btn_Cerrar.TabIndex = 100
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(781, 417)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 17)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Tipo Pago"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(951, 417)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 17)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Flete U$S"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 417)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 17)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "Origen"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(160, 417)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 17)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Condicion"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(625, 87)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 17)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(265, 465)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 17)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "Fecha Djai"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(628, 121)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 17)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Carpeta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 465)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 17)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "DJai"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(299, 89)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 17)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 122)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(329, 417)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Pedido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(471, 417)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(612, 417)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 17)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Via"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 17)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Orden de Compra"
        '
        'DGV_Orden
        '
        Me.DGV_Orden.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Orden.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Orden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Orden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.Descripcion, Me.Cantidad, Me.Precio, Me.PosicionArancelaria, Me.Derechos})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Orden.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_Orden.DoubleBuffered = True
        Me.DGV_Orden.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Orden.Location = New System.Drawing.Point(13, 150)
        Me.DGV_Orden.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Orden.Name = "DGV_Orden"
        Me.DGV_Orden.OrdenamientoColumnasHabilitado = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Orden.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV_Orden.RowHeadersWidth = 15
        Me.DGV_Orden.RowTemplate.Height = 20
        Me.DGV_Orden.ShowCellToolTips = False
        Me.DGV_Orden.SinClickDerecho = False
        Me.DGV_Orden.Size = New System.Drawing.Size(1072, 255)
        Me.DGV_Orden.TabIndex = 85
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 94
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 93
        '
        'Precio
        '
        Me.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle3
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 77
        '
        'PosicionArancelaria
        '
        Me.PosicionArancelaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PosicionArancelaria.HeaderText = "PosicionArancelaria"
        Me.PosicionArancelaria.Name = "PosicionArancelaria"
        Me.PosicionArancelaria.Width = 162
        '
        'Derechos
        '
        Me.Derechos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Derechos.DefaultCellStyle = DataGridViewCellStyle4
        Me.Derechos.HeaderText = "% Derechos"
        Me.Derechos.Name = "Derechos"
        Me.Derechos.ReadOnly = True
        Me.Derechos.Width = 105
        '
        'txt_FechaImpo
        '
        Me.txt_FechaImpo.Location = New System.Drawing.Point(475, 436)
        Me.txt_FechaImpo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaImpo.Mask = "00/00/0000"
        Me.txt_FechaImpo.Name = "txt_FechaImpo"
        Me.txt_FechaImpo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaImpo.Size = New System.Drawing.Size(132, 22)
        Me.txt_FechaImpo.TabIndex = 84
        '
        'cbx_TipoImpo
        '
        Me.cbx_TipoImpo.FormattingEnabled = True
        Me.cbx_TipoImpo.Items.AddRange(New Object() {"", "Maritimo", "Terrestre", "Aereo"})
        Me.cbx_TipoImpo.Location = New System.Drawing.Point(616, 434)
        Me.cbx_TipoImpo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_TipoImpo.Name = "cbx_TipoImpo"
        Me.cbx_TipoImpo.Size = New System.Drawing.Size(160, 24)
        Me.cbx_TipoImpo.TabIndex = 83
        '
        'cbx_TipoPago
        '
        Me.cbx_TipoPago.FormattingEnabled = True
        Me.cbx_TipoPago.Items.AddRange(New Object() {"", "Pago Anticipado", "A la vista", "Cuenta Corriente"})
        Me.cbx_TipoPago.Location = New System.Drawing.Point(785, 434)
        Me.cbx_TipoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_TipoPago.Name = "cbx_TipoPago"
        Me.cbx_TipoPago.Size = New System.Drawing.Size(160, 24)
        Me.cbx_TipoPago.TabIndex = 82
        '
        'cbx_Leyenda
        '
        Me.cbx_Leyenda.FormattingEnabled = True
        Me.cbx_Leyenda.Items.AddRange(New Object() {"", "FOB", "CIF", "CFR", "CPT", "EXW", "FCA"})
        Me.cbx_Leyenda.Location = New System.Drawing.Point(164, 437)
        Me.cbx_Leyenda.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Leyenda.Name = "cbx_Leyenda"
        Me.cbx_Leyenda.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Leyenda.TabIndex = 81
        '
        'txt_FechaDjai
        '
        Me.txt_FechaDjai.Location = New System.Drawing.Point(269, 489)
        Me.txt_FechaDjai.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaDjai.Mask = "00/00/0000"
        Me.txt_FechaDjai.Name = "txt_FechaDjai"
        Me.txt_FechaDjai.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaDjai.Size = New System.Drawing.Size(132, 22)
        Me.txt_FechaDjai.TabIndex = 80
        '
        'txt_Djai
        '
        Me.txt_Djai.Location = New System.Drawing.Point(16, 489)
        Me.txt_Djai.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Djai.Name = "txt_Djai"
        Me.txt_Djai.Size = New System.Drawing.Size(244, 22)
        Me.txt_Djai.TabIndex = 79
        '
        'txt_Flete
        '
        Me.txt_Flete.Location = New System.Drawing.Point(955, 436)
        Me.txt_Flete.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Flete.Name = "txt_Flete"
        Me.txt_Flete.Size = New System.Drawing.Size(132, 22)
        Me.txt_Flete.TabIndex = 78
        '
        'txt_PedidoImpo
        '
        Me.txt_PedidoImpo.Location = New System.Drawing.Point(333, 437)
        Me.txt_PedidoImpo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_PedidoImpo.Name = "txt_PedidoImpo"
        Me.txt_PedidoImpo.Size = New System.Drawing.Size(132, 22)
        Me.txt_PedidoImpo.TabIndex = 77
        '
        'txt_Origen
        '
        Me.txt_Origen.Location = New System.Drawing.Point(13, 437)
        Me.txt_Origen.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Origen.Name = "txt_Origen"
        Me.txt_Origen.Size = New System.Drawing.Size(132, 22)
        Me.txt_Origen.TabIndex = 76
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"Dolares", "Pesos", "Euros"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(711, 84)
        Me.cbx_Moneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Moneda.TabIndex = 75
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(359, 85)
        Me.txt_Fecha.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.ReadOnly = True
        Me.txt_Fecha.Size = New System.Drawing.Size(132, 22)
        Me.txt_Fecha.TabIndex = 74
        '
        'txt_Carpeta
        '
        Me.txt_Carpeta.Location = New System.Drawing.Point(711, 118)
        Me.txt_Carpeta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Carpeta.Name = "txt_Carpeta"
        Me.txt_Carpeta.Size = New System.Drawing.Size(132, 22)
        Me.txt_Carpeta.TabIndex = 73
        '
        'txt_DesProveedor
        '
        Me.txt_DesProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesProveedor.Location = New System.Drawing.Point(253, 118)
        Me.txt_DesProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_DesProveedor.Name = "txt_DesProveedor"
        Me.txt_DesProveedor.ReadOnly = True
        Me.txt_DesProveedor.Size = New System.Drawing.Size(353, 22)
        Me.txt_DesProveedor.TabIndex = 72
        '
        'txt_Proveedor
        '
        Me.txt_Proveedor.Location = New System.Drawing.Point(111, 118)
        Me.txt_Proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Proveedor.Name = "txt_Proveedor"
        Me.txt_Proveedor.Size = New System.Drawing.Size(132, 22)
        Me.txt_Proveedor.TabIndex = 71
        '
        'txt_Orden
        '
        Me.txt_Orden.Location = New System.Drawing.Point(152, 85)
        Me.txt_Orden.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Orden.Name = "txt_Orden"
        Me.txt_Orden.ReadOnly = True
        Me.txt_Orden.Size = New System.Drawing.Size(132, 22)
        Me.txt_Orden.TabIndex = 70
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
        Me.panel1.Size = New System.Drawing.Size(1095, 62)
        Me.panel1.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(888, 37)
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
        Me.label1.Size = New System.Drawing.Size(199, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingreso Orden Compra"
        '
        'Ingreso_OrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 521)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV_Orden)
        Me.Controls.Add(Me.txt_FechaImpo)
        Me.Controls.Add(Me.cbx_TipoImpo)
        Me.Controls.Add(Me.cbx_TipoPago)
        Me.Controls.Add(Me.cbx_Leyenda)
        Me.Controls.Add(Me.txt_FechaDjai)
        Me.Controls.Add(Me.txt_Djai)
        Me.Controls.Add(Me.txt_Flete)
        Me.Controls.Add(Me.txt_PedidoImpo)
        Me.Controls.Add(Me.txt_Origen)
        Me.Controls.Add(Me.cbx_Moneda)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.txt_Carpeta)
        Me.Controls.Add(Me.txt_DesProveedor)
        Me.Controls.Add(Me.txt_Proveedor)
        Me.Controls.Add(Me.txt_Orden)
        Me.Name = "Ingreso_OrdenCompra"
        CType(Me.DGV_Orden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV_Orden As Util.DBDataGridView
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PosicionArancelaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Derechos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_FechaImpo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbx_TipoImpo As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_TipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Leyenda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_FechaDjai As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Djai As System.Windows.Forms.TextBox
    Friend WithEvents txt_Flete As System.Windows.Forms.TextBox
    Friend WithEvents txt_PedidoImpo As System.Windows.Forms.TextBox
    Friend WithEvents txt_Origen As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Moneda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_Orden As System.Windows.Forms.TextBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
