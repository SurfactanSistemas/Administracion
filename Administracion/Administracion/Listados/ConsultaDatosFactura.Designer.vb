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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.txtFechaOrdenCompra = New System.Windows.Forms.MaskedTextBox()
        Me.txtInformeRecepcion = New System.Windows.Forms.TextBox()
        Me.txtFechaInformeRecepcion = New System.Windows.Forms.MaskedTextBox()
        Me.txtRemito = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtFechaFactura = New System.Windows.Forms.MaskedTextBox()
        Me.txtCarpeta = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.DGVArticulos = New System.Windows.Forms.DataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 50)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(2, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(834, 246)
        Me.Panel2.TabIndex = 32
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
        Me.GroupBox1.Location = New System.Drawing.Point(91, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(652, 228)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Historial"
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
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrdenCompra.Location = New System.Drawing.Point(274, 26)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.ReadOnly = True
        Me.txtOrdenCompra.Size = New System.Drawing.Size(116, 20)
        Me.txtOrdenCompra.TabIndex = 1
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
        'txtInformeRecepcion
        '
        Me.txtInformeRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInformeRecepcion.Location = New System.Drawing.Point(274, 58)
        Me.txtInformeRecepcion.Name = "txtInformeRecepcion"
        Me.txtInformeRecepcion.ReadOnly = True
        Me.txtInformeRecepcion.Size = New System.Drawing.Size(116, 20)
        Me.txtInformeRecepcion.TabIndex = 1
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
        'txtRemito
        '
        Me.txtRemito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRemito.Location = New System.Drawing.Point(274, 90)
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.ReadOnly = True
        Me.txtRemito.Size = New System.Drawing.Size(116, 20)
        Me.txtRemito.TabIndex = 1
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFactura.Location = New System.Drawing.Point(274, 122)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(116, 20)
        Me.txtFactura.TabIndex = 1
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
        'txtCarpeta
        '
        Me.txtCarpeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCarpeta.Location = New System.Drawing.Point(274, 154)
        Me.txtCarpeta.Name = "txtCarpeta"
        Me.txtCarpeta.ReadOnly = True
        Me.txtCarpeta.Size = New System.Drawing.Size(116, 20)
        Me.txtCarpeta.TabIndex = 1
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
        'DGVArticulos
        '
        Me.DGVArticulos.AllowUserToAddRows = False
        Me.DGVArticulos.AllowUserToDeleteRows = False
        Me.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Producto, Me.Descripcion, Me.Cantidad, Me.Precio})
        Me.DGVArticulos.Location = New System.Drawing.Point(60, 302)
        Me.DGVArticulos.Name = "DGVArticulos"
        Me.DGVArticulos.ReadOnly = True
        Me.DGVArticulos.Size = New System.Drawing.Size(713, 172)
        Me.DGVArticulos.TabIndex = 33
        '
        'Orden
        '
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 270
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(381, 497)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 25)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConsultaDatosFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 534)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGVArticulos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ConsultaDatosFactura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaOrdenCompra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaFactura As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaInformeRecepcion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCarpeta As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtRemito As System.Windows.Forms.TextBox
    Friend WithEvents txtInformeRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents DGVArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
