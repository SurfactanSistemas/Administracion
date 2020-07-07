<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreciosClienteProducto
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbReventa = New System.Windows.Forms.RadioButton()
        Me.rbTerminado = New System.Windows.Forms.RadioButton()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtProducto = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescComercial = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtCondicionPago = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblDescripcion2 = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblDescProducto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDescPago = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblRazon = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnMantenimiento = New System.Windows.Forms.Button()
        Me.dgvFacturas = New Util.DBDataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(638, 40)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(462, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(297, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "PRECIOS POR CLIENTE - Precio de Producto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbReventa)
        Me.GroupBox1.Controls.Add(Me.rbTerminado)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.txtDescComercial)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtCondicionPago)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion2)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.lblDescProducto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblDescPago)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblUltimaActualizacion)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblRazon)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 150)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'rbReventa
        '
        Me.rbReventa.AutoSize = True
        Me.rbReventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbReventa.Location = New System.Drawing.Point(503, 40)
        Me.rbReventa.Name = "rbReventa"
        Me.rbReventa.Size = New System.Drawing.Size(72, 17)
        Me.rbReventa.TabIndex = 4
        Me.rbReventa.Text = "REVENTA"
        Me.rbReventa.UseVisualStyleBackColor = True
        '
        'rbTerminado
        '
        Me.rbTerminado.AutoSize = True
        Me.rbTerminado.Checked = True
        Me.rbTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTerminado.Location = New System.Drawing.Point(503, 17)
        Me.rbTerminado.Name = "rbTerminado"
        Me.rbTerminado.Size = New System.Drawing.Size(122, 17)
        Me.rbTerminado.TabIndex = 4
        Me.rbTerminado.TabStop = True
        Me.rbTerminado.Text = "PROD. TERMINADO"
        Me.rbTerminado.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "HISTÓRICO", "COTIZACIÓN"})
        Me.cmbEstado.Location = New System.Drawing.Point(227, 64)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(124, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(86, 39)
        Me.txtProducto.Mask = ">LL-00000-000"
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtProducto.Size = New System.Drawing.Size(81, 20)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.Text = "PT99999999"
        '
        'txtDescComercial
        '
        Me.txtDescComercial.Location = New System.Drawing.Point(86, 90)
        Me.txtDescComercial.Name = "txtDescComercial"
        Me.txtDescComercial.Size = New System.Drawing.Size(408, 20)
        Me.txtDescComercial.TabIndex = 1
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(86, 64)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(57, 20)
        Me.txtPrecio.TabIndex = 1
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCondicionPago
        '
        Me.txtCondicionPago.Location = New System.Drawing.Point(86, 116)
        Me.txtCondicionPago.MaxLength = 4
        Me.txtCondicionPago.Name = "txtCondicionPago"
        Me.txtCondicionPago.Size = New System.Drawing.Size(57, 20)
        Me.txtCondicionPago.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Location = New System.Drawing.Point(86, 15)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(57, 20)
        Me.txtCliente.TabIndex = 1
        '
        'lblDescripcion2
        '
        Me.lblDescripcion2.AutoSize = True
        Me.lblDescripcion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion2.Location = New System.Drawing.Point(500, 93)
        Me.lblDescripcion2.Name = "lblDescripcion2"
        Me.lblDescripcion2.Size = New System.Drawing.Size(78, 13)
        Me.lblDescripcion2.TabIndex = 0
        Me.lblDescripcion2.Text = "DESCRIPCION"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(2, 94)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(80, 13)
        Me.lblDescripcion.TabIndex = 0
        Me.lblDescripcion.Text = "DESCRIPCION"
        '
        'lblDescProducto
        '
        Me.lblDescProducto.BackColor = System.Drawing.Color.Cyan
        Me.lblDescProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescProducto.Location = New System.Drawing.Point(173, 40)
        Me.lblDescProducto.Name = "lblDescProducto"
        Me.lblDescProducto.Size = New System.Drawing.Size(321, 19)
        Me.lblDescProducto.TabIndex = 0
        Me.lblDescProducto.Text = "CLIENTE"
        Me.lblDescProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "PRODUCTO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(170, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "ESTADO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "PRECIO"
        '
        'lblDescPago
        '
        Me.lblDescPago.BackColor = System.Drawing.Color.Cyan
        Me.lblDescPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescPago.Location = New System.Drawing.Point(149, 117)
        Me.lblDescPago.Name = "lblDescPago"
        Me.lblDescPago.Size = New System.Drawing.Size(463, 19)
        Me.lblDescPago.TabIndex = 0
        Me.lblDescPago.Text = "CLIENTE"
        Me.lblDescPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "COND. PAGO"
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.BackColor = System.Drawing.Color.Cyan
        Me.lblUltimaActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(482, 65)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(130, 19)
        Me.lblUltimaActualizacion.TabIndex = 0
        Me.lblUltimaActualizacion.Text = "  /  /    "
        Me.lblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(357, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "ULT. ACTUALIZACIÓN"
        '
        'lblRazon
        '
        Me.lblRazon.BackColor = System.Drawing.Color.Cyan
        Me.lblRazon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRazon.Location = New System.Drawing.Point(149, 16)
        Me.lblRazon.Name = "lblRazon"
        Me.lblRazon.Size = New System.Drawing.Size(345, 19)
        Me.lblRazon.TabIndex = 0
        Me.lblRazon.Text = "CLIENTE"
        Me.lblRazon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CLIENTE"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 198)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(446, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "ULTIMAS VENTAS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(457, 196)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(173, 35)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(457, 234)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(173, 35)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(457, 273)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(173, 35)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnMantenimiento
        '
        Me.btnMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMantenimiento.Location = New System.Drawing.Point(457, 338)
        Me.btnMantenimiento.Name = "btnMantenimiento"
        Me.btnMantenimiento.Size = New System.Drawing.Size(173, 35)
        Me.btnMantenimiento.TabIndex = 9
        Me.btnMantenimiento.Text = "MANTENIMIENTO DE NOMBRES"
        Me.btnMantenimiento.UseVisualStyleBackColor = True
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.AllowUserToDeleteRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Factura, Me.Precio, Me.Cantidad})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFacturas.DoubleBuffered = True
        Me.dgvFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvFacturas.Location = New System.Drawing.Point(5, 216)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.OrdenamientoColumnasHabilitado = True
        Me.dgvFacturas.ReadOnly = True
        Me.dgvFacturas.RowHeadersWidth = 15
        Me.dgvFacturas.RowTemplate.Height = 20
        Me.dgvFacturas.ShowCellToolTips = False
        Me.dgvFacturas.SinClickDerecho = False
        Me.dgvFacturas.Size = New System.Drawing.Size(446, 157)
        Me.dgvFacturas.TabIndex = 8
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Factura
        '
        Me.Factura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Factura.DataPropertyName = "Factura"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Factura.DefaultCellStyle = DataGridViewCellStyle2
        Me.Factura.HeaderText = "Factura"
        Me.Factura.Name = "Factura"
        Me.Factura.ReadOnly = True
        '
        'Precio
        '
        Me.Precio.DataPropertyName = "Precio"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle3
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'PreciosClienteProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 385)
        Me.Controls.Add(Me.btnMantenimiento)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PreciosClienteProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblRazon As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDescProducto As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents lblDescPago As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbReventa As System.Windows.Forms.RadioButton
    Friend WithEvents rbTerminado As System.Windows.Forms.RadioButton
    Friend WithEvents dgvFacturas As Util.DBDataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnMantenimiento As System.Windows.Forms.Button
End Class
