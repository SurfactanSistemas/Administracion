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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Orden = New System.Windows.Forms.TextBox()
        Me.txt_Proveedor = New System.Windows.Forms.TextBox()
        Me.txt_DesProveedor = New System.Windows.Forms.TextBox()
        Me.txt_Carpeta = New System.Windows.Forms.TextBox()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.cbx_Moneda = New System.Windows.Forms.ComboBox()
        Me.txt_Origen = New System.Windows.Forms.TextBox()
        Me.txt_PedidoImpo = New System.Windows.Forms.TextBox()
        Me.txt_Flete = New System.Windows.Forms.TextBox()
        Me.txt_Djai = New System.Windows.Forms.TextBox()
        Me.txt_FechaDjai = New System.Windows.Forms.MaskedTextBox()
        Me.cbx_Leyenda = New System.Windows.Forms.ComboBox()
        Me.cbx_TipoPago = New System.Windows.Forms.ComboBox()
        Me.cbx_TipoImpo = New System.Windows.Forms.ComboBox()
        Me.txt_FechaImpo = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DGV_Orden = New Util.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PosicionArancelaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Derechos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Orden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(815, 50)
        Me.panel1.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(660, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(172, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingreso Orden Compra"
        '
        'txt_Orden
        '
        Me.txt_Orden.Location = New System.Drawing.Point(108, 56)
        Me.txt_Orden.Name = "txt_Orden"
        Me.txt_Orden.ReadOnly = True
        Me.txt_Orden.Size = New System.Drawing.Size(100, 20)
        Me.txt_Orden.TabIndex = 38
        '
        'txt_Proveedor
        '
        Me.txt_Proveedor.Location = New System.Drawing.Point(77, 83)
        Me.txt_Proveedor.Name = "txt_Proveedor"
        Me.txt_Proveedor.Size = New System.Drawing.Size(100, 20)
        Me.txt_Proveedor.TabIndex = 39
        '
        'txt_DesProveedor
        '
        Me.txt_DesProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesProveedor.Location = New System.Drawing.Point(184, 83)
        Me.txt_DesProveedor.Name = "txt_DesProveedor"
        Me.txt_DesProveedor.ReadOnly = True
        Me.txt_DesProveedor.Size = New System.Drawing.Size(266, 20)
        Me.txt_DesProveedor.TabIndex = 40
        '
        'txt_Carpeta
        '
        Me.txt_Carpeta.Location = New System.Drawing.Point(527, 83)
        Me.txt_Carpeta.Name = "txt_Carpeta"
        Me.txt_Carpeta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Carpeta.TabIndex = 41
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(263, 56)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.ReadOnly = True
        Me.txt_Fecha.Size = New System.Drawing.Size(100, 20)
        Me.txt_Fecha.TabIndex = 42
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"Dolares", "Pesos", "Euros"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(527, 55)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Moneda.TabIndex = 43
        '
        'txt_Origen
        '
        Me.txt_Origen.Location = New System.Drawing.Point(4, 342)
        Me.txt_Origen.Name = "txt_Origen"
        Me.txt_Origen.Size = New System.Drawing.Size(100, 20)
        Me.txt_Origen.TabIndex = 44
        '
        'txt_PedidoImpo
        '
        Me.txt_PedidoImpo.Location = New System.Drawing.Point(244, 342)
        Me.txt_PedidoImpo.Name = "txt_PedidoImpo"
        Me.txt_PedidoImpo.Size = New System.Drawing.Size(100, 20)
        Me.txt_PedidoImpo.TabIndex = 45
        '
        'txt_Flete
        '
        Me.txt_Flete.Location = New System.Drawing.Point(710, 341)
        Me.txt_Flete.Name = "txt_Flete"
        Me.txt_Flete.Size = New System.Drawing.Size(100, 20)
        Me.txt_Flete.TabIndex = 46
        '
        'txt_Djai
        '
        Me.txt_Djai.Location = New System.Drawing.Point(6, 384)
        Me.txt_Djai.Name = "txt_Djai"
        Me.txt_Djai.Size = New System.Drawing.Size(184, 20)
        Me.txt_Djai.TabIndex = 47
        '
        'txt_FechaDjai
        '
        Me.txt_FechaDjai.Location = New System.Drawing.Point(196, 384)
        Me.txt_FechaDjai.Mask = "00/00/0000"
        Me.txt_FechaDjai.Name = "txt_FechaDjai"
        Me.txt_FechaDjai.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaDjai.Size = New System.Drawing.Size(100, 20)
        Me.txt_FechaDjai.TabIndex = 48
        '
        'cbx_Leyenda
        '
        Me.cbx_Leyenda.FormattingEnabled = True
        Me.cbx_Leyenda.Items.AddRange(New Object() {"", "FOB", "CIF", "CFR", "CPT", "EXW", "FCA"})
        Me.cbx_Leyenda.Location = New System.Drawing.Point(117, 342)
        Me.cbx_Leyenda.Name = "cbx_Leyenda"
        Me.cbx_Leyenda.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Leyenda.TabIndex = 49
        '
        'cbx_TipoPago
        '
        Me.cbx_TipoPago.FormattingEnabled = True
        Me.cbx_TipoPago.Items.AddRange(New Object() {"", "Pago Anticipado", "A la vista", "Cuenta Corriente"})
        Me.cbx_TipoPago.Location = New System.Drawing.Point(583, 340)
        Me.cbx_TipoPago.Name = "cbx_TipoPago"
        Me.cbx_TipoPago.Size = New System.Drawing.Size(121, 21)
        Me.cbx_TipoPago.TabIndex = 50
        '
        'cbx_TipoImpo
        '
        Me.cbx_TipoImpo.FormattingEnabled = True
        Me.cbx_TipoImpo.Items.AddRange(New Object() {"", "Maritimo", "Terrestre", "Aereo"})
        Me.cbx_TipoImpo.Location = New System.Drawing.Point(456, 340)
        Me.cbx_TipoImpo.Name = "cbx_TipoImpo"
        Me.cbx_TipoImpo.Size = New System.Drawing.Size(121, 21)
        Me.cbx_TipoImpo.TabIndex = 51
        '
        'txt_FechaImpo
        '
        Me.txt_FechaImpo.Location = New System.Drawing.Point(350, 341)
        Me.txt_FechaImpo.Mask = "00/00/0000"
        Me.txt_FechaImpo.Name = "txt_FechaImpo"
        Me.txt_FechaImpo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaImpo.Size = New System.Drawing.Size(100, 20)
        Me.txt_FechaImpo.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Orden de Compra"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(453, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Via"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(347, 326)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(241, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Pedido"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Proveedor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(218, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Fecha"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 365)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "DJai"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(465, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Carpeta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(193, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Fecha Djai"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(463, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Moneda"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(114, 326)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Condicion"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 326)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Origen"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(707, 326)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Flete U$S"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(580, 326)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Tipo Pago"
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
        Me.DGV_Orden.Location = New System.Drawing.Point(4, 109)
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
        Me.DGV_Orden.Size = New System.Drawing.Size(804, 207)
        Me.DGV_Orden.TabIndex = 53
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 75
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
        Me.Cantidad.Width = 74
        '
        'Precio
        '
        Me.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle3
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 62
        '
        'PosicionArancelaria
        '
        Me.PosicionArancelaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PosicionArancelaria.HeaderText = "PosicionArancelaria"
        Me.PosicionArancelaria.Name = "PosicionArancelaria"
        Me.PosicionArancelaria.Width = 125
        '
        'Derechos
        '
        Me.Derechos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Derechos.DefaultCellStyle = DataGridViewCellStyle4
        Me.Derechos.HeaderText = "% Derechos"
        Me.Derechos.Name = "Derechos"
        Me.Derechos.ReadOnly = True
        Me.Derechos.Width = 89
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(655, 371)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(148, 33)
        Me.btn_Cerrar.TabIndex = 69
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Ingreso_OrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 413)
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
        Me.Controls.Add(Me.panel1)
        Me.Name = "Ingreso_OrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Orden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Orden As System.Windows.Forms.TextBox
    Friend WithEvents txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbx_Moneda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_PedidoImpo As System.Windows.Forms.TextBox
    Friend WithEvents txt_Flete As System.Windows.Forms.TextBox
    Friend WithEvents txt_Djai As System.Windows.Forms.TextBox
    Friend WithEvents txt_FechaDjai As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbx_Leyenda As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_TipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_TipoImpo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_FechaImpo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DGV_Orden As Util.DBDataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PosicionArancelaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Derechos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
End Class
