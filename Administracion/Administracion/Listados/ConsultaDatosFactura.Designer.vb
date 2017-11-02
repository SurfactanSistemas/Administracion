<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaDatosFactura
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DGVArticulos = New System.Windows.Forms.DataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFactura = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaInformeRecepcion = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaOrdenCompra = New System.Windows.Forms.MaskedTextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.txtCarpeta = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtRemito = New System.Windows.Forms.TextBox()
        Me.txtInformeRecepcion = New System.Windows.Forms.TextBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFechaVto2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaVto1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaVtoIva = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaEmision = New System.Windows.Forms.MaskedTextBox()
        Me.txtDespacho = New System.Windows.Forms.TextBox()
        Me.txtParidad = New System.Windows.Forms.TextBox()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.txtNroInterno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(879, 50)
        Me.Panel1.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(636, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consulta de Datos de Factura"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(389, 524)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 25)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGVArticulos
        '
        Me.DGVArticulos.AllowUserToAddRows = False
        Me.DGVArticulos.AllowUserToDeleteRows = False
        Me.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Producto, Me.Descripcion, Me.Cantidad, Me.Precio})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVArticulos.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGVArticulos.Location = New System.Drawing.Point(26, 233)
        Me.DGVArticulos.Name = "DGVArticulos"
        Me.DGVArticulos.ReadOnly = True
        Me.DGVArticulos.Size = New System.Drawing.Size(713, 172)
        Me.DGVArticulos.TabIndex = 33
        '
        'Orden
        '
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Orden.DefaultCellStyle = DataGridViewCellStyle1
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        '
        'Producto
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Producto.DefaultCellStyle = DataGridViewCellStyle2
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'Descripcion
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 270
        '
        'Cantidad
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'Precio
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle5
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFactura)
        Me.GroupBox1.Controls.Add(Me.txtFechaInformeRecepcion)
        Me.GroupBox1.Controls.Add(Me.txtFechaOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.txtNombreProveedor)
        Me.GroupBox1.Controls.Add(Me.txtCarpeta)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtRemito)
        Me.GroupBox1.Controls.Add(Me.txtInformeRecepcion)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(56, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(652, 220)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Historial"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaFactura.Location = New System.Drawing.Point(402, 122)
        Me.txtFechaFactura.Mask = "00/00/0000"
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaFactura.TabIndex = 2
        Me.txtFechaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaInformeRecepcion
        '
        Me.txtFechaInformeRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaInformeRecepcion.Location = New System.Drawing.Point(402, 52)
        Me.txtFechaInformeRecepcion.Mask = "00/00/0000"
        Me.txtFechaInformeRecepcion.Name = "txtFechaInformeRecepcion"
        Me.txtFechaInformeRecepcion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaInformeRecepcion.ReadOnly = True
        Me.txtFechaInformeRecepcion.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaInformeRecepcion.TabIndex = 2
        Me.txtFechaInformeRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaOrdenCompra
        '
        Me.txtFechaOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaOrdenCompra.Location = New System.Drawing.Point(402, 26)
        Me.txtFechaOrdenCompra.Mask = "00/00/0000"
        Me.txtFechaOrdenCompra.Name = "txtFechaOrdenCompra"
        Me.txtFechaOrdenCompra.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaOrdenCompra.ReadOnly = True
        Me.txtFechaOrdenCompra.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaOrdenCompra.TabIndex = 2
        Me.txtFechaOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNombreProveedor.Location = New System.Drawing.Point(272, 188)
        Me.txtNombreProveedor.MaxLength = 50
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.ReadOnly = True
        Me.txtNombreProveedor.Size = New System.Drawing.Size(223, 20)
        Me.txtNombreProveedor.TabIndex = 1
        '
        'txtCarpeta
        '
        Me.txtCarpeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCarpeta.Location = New System.Drawing.Point(274, 154)
        Me.txtCarpeta.Name = "txtCarpeta"
        Me.txtCarpeta.ReadOnly = True
        Me.txtCarpeta.Size = New System.Drawing.Size(116, 20)
        Me.txtCarpeta.TabIndex = 1
        Me.txtCarpeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFactura.Location = New System.Drawing.Point(274, 122)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(116, 20)
        Me.txtFactura.TabIndex = 1
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemito
        '
        Me.txtRemito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRemito.Location = New System.Drawing.Point(274, 90)
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.ReadOnly = True
        Me.txtRemito.Size = New System.Drawing.Size(116, 20)
        Me.txtRemito.TabIndex = 1
        Me.txtRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInformeRecepcion
        '
        Me.txtInformeRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInformeRecepcion.Location = New System.Drawing.Point(274, 58)
        Me.txtInformeRecepcion.Name = "txtInformeRecepcion"
        Me.txtInformeRecepcion.ReadOnly = True
        Me.txtInformeRecepcion.Size = New System.Drawing.Size(116, 20)
        Me.txtInformeRecepcion.TabIndex = 1
        Me.txtInformeRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrdenCompra.Location = New System.Drawing.Point(274, 26)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.ReadOnly = True
        Me.txtOrdenCompra.Size = New System.Drawing.Size(116, 20)
        Me.txtOrdenCompra.TabIndex = 1
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(125, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Proveedor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(125, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Carpeta:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(125, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Factura:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(125, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Remito:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(125, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Informe de Recepción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(125, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Orden de Compra:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Location = New System.Drawing.Point(2, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(879, 464)
        Me.Panel2.TabIndex = 32
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(53, 6)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(10, 10)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(773, 455)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.DGVArticulos)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Location = New System.Drawing.Point(4, 36)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(765, 415)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos de Factura"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(765, 415)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles de Factura"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFechaVto2)
        Me.GroupBox2.Controls.Add(Me.txtFechaVto1)
        Me.GroupBox2.Controls.Add(Me.txtFechaVtoIva)
        Me.GroupBox2.Controls.Add(Me.txtFechaEmision)
        Me.GroupBox2.Controls.Add(Me.txtDespacho)
        Me.GroupBox2.Controls.Add(Me.txtParidad)
        Me.GroupBox2.Controls.Add(Me.txtMoneda)
        Me.GroupBox2.Controls.Add(Me.txtNroInterno)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(56, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 220)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalles"
        '
        'txtFechaVto2
        '
        Me.txtFechaVto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaVto2.Location = New System.Drawing.Point(446, 101)
        Me.txtFechaVto2.Mask = "00/00/0000"
        Me.txtFechaVto2.Name = "txtFechaVto2"
        Me.txtFechaVto2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto2.ReadOnly = True
        Me.txtFechaVto2.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaVto2.TabIndex = 2
        Me.txtFechaVto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaVto1
        '
        Me.txtFechaVto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaVto1.Location = New System.Drawing.Point(241, 100)
        Me.txtFechaVto1.Mask = "00/00/0000"
        Me.txtFechaVto1.Name = "txtFechaVto1"
        Me.txtFechaVto1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto1.ReadOnly = True
        Me.txtFechaVto1.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaVto1.TabIndex = 2
        Me.txtFechaVto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaVtoIva
        '
        Me.txtFechaVtoIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaVtoIva.Location = New System.Drawing.Point(446, 74)
        Me.txtFechaVtoIva.Mask = "00/00/0000"
        Me.txtFechaVtoIva.Name = "txtFechaVtoIva"
        Me.txtFechaVtoIva.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVtoIva.ReadOnly = True
        Me.txtFechaVtoIva.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaVtoIva.TabIndex = 2
        Me.txtFechaVtoIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaEmision.Location = New System.Drawing.Point(241, 72)
        Me.txtFechaEmision.Mask = "00/00/0000"
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaEmision.TabIndex = 2
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDespacho
        '
        Me.txtDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDespacho.Location = New System.Drawing.Point(241, 157)
        Me.txtDespacho.MaxLength = 50
        Me.txtDespacho.Name = "txtDespacho"
        Me.txtDespacho.ReadOnly = True
        Me.txtDespacho.Size = New System.Drawing.Size(298, 20)
        Me.txtDespacho.TabIndex = 1
        '
        'txtParidad
        '
        Me.txtParidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtParidad.Location = New System.Drawing.Point(241, 129)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.ReadOnly = True
        Me.txtParidad.Size = New System.Drawing.Size(93, 20)
        Me.txtParidad.TabIndex = 1
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMoneda
        '
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMoneda.Location = New System.Drawing.Point(446, 127)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(93, 20)
        Me.txtMoneda.TabIndex = 1
        Me.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNroInterno
        '
        Me.txtNroInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNroInterno.Location = New System.Drawing.Point(241, 44)
        Me.txtNroInterno.Name = "txtNroInterno"
        Me.txtNroInterno.ReadOnly = True
        Me.txtNroInterno.Size = New System.Drawing.Size(93, 20)
        Me.txtNroInterno.TabIndex = 1
        Me.txtNroInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(160, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Despacho:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(349, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 18)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Segundo Vto:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(173, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Paridad:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(153, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 18)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Primer Vto:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(375, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 18)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Moneda:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(381, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 18)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Vto IVA:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(113, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 18)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fecha de Emisión:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(129, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 18)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Nro de Interno:"
        '
        'ConsultaDatosFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 560)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ConsultaDatosFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DGVArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFactura As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaInformeRecepcion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaOrdenCompra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCarpeta As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtRemito As System.Windows.Forms.TextBox
    Friend WithEvents txtInformeRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaVto1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaVtoIva As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDespacho As System.Windows.Forms.TextBox
    Friend WithEvents txtParidad As System.Windows.Forms.TextBox
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtNroInterno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaVto2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
