<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPreProformas
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPrincipal = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_PedidoProforma = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_MostrarConProforma = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFiltrarPor = New System.Windows.Forms.TextBox()
        Me.NroPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroProforma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto_7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(862, 52)
        Me.Panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(681, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pedidos de Proformas"
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.AllowUserToAddRows = False
        Me.dgvPrincipal.AllowUserToDeleteRows = False
        Me.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroPedido, Me.Fecha, Me.Cliente, Me.Razon, Me.Pais, Me.Total, Me.NroProforma, Me.Producto_0, Me.Producto_1, Me.Producto_2, Me.Producto_3, Me.Producto_4, Me.Producto_5, Me.Producto_6, Me.Producto_7})
        Me.dgvPrincipal.Location = New System.Drawing.Point(100, 109)
        Me.dgvPrincipal.Margin = New System.Windows.Forms.Padding(15)
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.Size = New System.Drawing.Size(753, 348)
        Me.dgvPrincipal.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_Cerrar)
        Me.Panel2.Controls.Add(Me.btn_PedidoProforma)
        Me.Panel2.Location = New System.Drawing.Point(10, 106)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(84, 351)
        Me.Panel2.TabIndex = 8
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Location = New System.Drawing.Point(5, 100)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(74, 56)
        Me.btn_Cerrar.TabIndex = 3
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_PedidoProforma
        '
        Me.btn_PedidoProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_PedidoProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_PedidoProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PedidoProforma.Location = New System.Drawing.Point(5, 24)
        Me.btn_PedidoProforma.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btn_PedidoProforma.Name = "btn_PedidoProforma"
        Me.btn_PedidoProforma.Size = New System.Drawing.Size(74, 56)
        Me.btn_PedidoProforma.TabIndex = 2
        Me.btn_PedidoProforma.Text = "Nuevo Pedido Proforma"
        Me.btn_PedidoProforma.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_MostrarConProforma)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarFiltros)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFiltrarPor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(10, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 43)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar datos"
        '
        'chk_MostrarConProforma
        '
        Me.chk_MostrarConProforma.AutoSize = True
        Me.chk_MostrarConProforma.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk_MostrarConProforma.Location = New System.Drawing.Point(585, 18)
        Me.chk_MostrarConProforma.Name = "chk_MostrarConProforma"
        Me.chk_MostrarConProforma.Size = New System.Drawing.Size(207, 17)
        Me.chk_MostrarConProforma.TabIndex = 4
        Me.chk_MostrarConProforma.Text = "Incluir Solicitudes Con Proforma"
        Me.chk_MostrarConProforma.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiarFiltros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(448, 11)
        Me.btnLimpiarFiltros.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(123, 26)
        Me.btnLimpiarFiltros.TabIndex = 3
        Me.btnLimpiarFiltros.Text = "Limpiar Filtros"
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        Me.btnLimpiarFiltros.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aquellos que contengan:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrarPor
        '
        Me.txtFiltrarPor.Location = New System.Drawing.Point(168, 15)
        Me.txtFiltrarPor.Name = "txtFiltrarPor"
        Me.txtFiltrarPor.Size = New System.Drawing.Size(267, 20)
        Me.txtFiltrarPor.TabIndex = 0
        '
        'NroPedido
        '
        Me.NroPedido.DataPropertyName = "NroPedido"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroPedido.DefaultCellStyle = DataGridViewCellStyle4
        Me.NroPedido.HeaderText = "Nro Pedido"
        Me.NroPedido.MaxInputLength = 6
        Me.NroPedido.Name = "NroPedido"
        Me.NroPedido.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MaxInputLength = 10
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MaxInputLength = 6
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.DataPropertyName = "Razon"
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        '
        'Pais
        '
        Me.Pais.DataPropertyName = "Pais"
        Me.Pais.HeaderText = "Pais"
        Me.Pais.Name = "Pais"
        Me.Pais.ReadOnly = True
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle6
        Me.Total.HeaderText = "Monto Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'NroProforma
        '
        Me.NroProforma.DataPropertyName = "NroProforma"
        Me.NroProforma.HeaderText = "Nro Proforma"
        Me.NroProforma.Name = "NroProforma"
        Me.NroProforma.ReadOnly = True
        Me.NroProforma.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Producto_0
        '
        Me.Producto_0.DataPropertyName = "Producto_0"
        Me.Producto_0.HeaderText = "Producto_0"
        Me.Producto_0.Name = "Producto_0"
        Me.Producto_0.ReadOnly = True
        Me.Producto_0.Visible = False
        '
        'Producto_1
        '
        Me.Producto_1.DataPropertyName = "Producto_1"
        Me.Producto_1.HeaderText = "Producto_1"
        Me.Producto_1.Name = "Producto_1"
        Me.Producto_1.ReadOnly = True
        Me.Producto_1.Visible = False
        '
        'Producto_2
        '
        Me.Producto_2.DataPropertyName = "Producto_2"
        Me.Producto_2.HeaderText = "Producto_2"
        Me.Producto_2.Name = "Producto_2"
        Me.Producto_2.ReadOnly = True
        Me.Producto_2.Visible = False
        '
        'Producto_3
        '
        Me.Producto_3.DataPropertyName = "Producto_3"
        Me.Producto_3.HeaderText = "Producto_3"
        Me.Producto_3.Name = "Producto_3"
        Me.Producto_3.ReadOnly = True
        Me.Producto_3.Visible = False
        '
        'Producto_4
        '
        Me.Producto_4.DataPropertyName = "Producto_4"
        Me.Producto_4.HeaderText = "Producto_4"
        Me.Producto_4.Name = "Producto_4"
        Me.Producto_4.ReadOnly = True
        Me.Producto_4.Visible = False
        '
        'Producto_5
        '
        Me.Producto_5.DataPropertyName = "Producto_5"
        Me.Producto_5.HeaderText = "Producto_5"
        Me.Producto_5.Name = "Producto_5"
        Me.Producto_5.ReadOnly = True
        Me.Producto_5.Visible = False
        '
        'Producto_6
        '
        Me.Producto_6.DataPropertyName = "Producto_6"
        Me.Producto_6.HeaderText = "Producto_6"
        Me.Producto_6.Name = "Producto_6"
        Me.Producto_6.ReadOnly = True
        Me.Producto_6.Visible = False
        '
        'Producto_7
        '
        Me.Producto_7.DataPropertyName = "Producto_7"
        Me.Producto_7.HeaderText = "Producto_7"
        Me.Producto_7.Name = "Producto_7"
        Me.Producto_7.ReadOnly = True
        Me.Producto_7.Visible = False
        '
        'MenuPreProformas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 466)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvPrincipal)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MenuPreProformas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPrincipal As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_PedidoProforma As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_MostrarConProforma As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFiltrarPor As System.Windows.Forms.TextBox
    Friend WithEvents NroPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroProforma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto_7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
