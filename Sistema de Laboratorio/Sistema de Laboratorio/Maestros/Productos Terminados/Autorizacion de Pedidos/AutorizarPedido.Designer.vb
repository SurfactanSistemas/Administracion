<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutorizarPedido
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipoPedido = New System.Windows.Forms.Label()
        Me.lblFecEntrega = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvDatos = New Util.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Canti = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venc75 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Revalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoA = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.PathCoA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(751, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(561, 12)
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
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AUTORIZAR PEDIDO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnAutorizar)
        Me.GroupBox1.Controls.Add(Me.lblDescCliente)
        Me.GroupBox1.Controls.Add(Me.lblCliente)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblTipoPedido)
        Me.GroupBox1.Controls.Add(Me.lblFecEntrega)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblPedido)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 78)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(608, 42)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(121, 28)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizar.Location = New System.Drawing.Point(481, 42)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(121, 28)
        Me.btnAutorizar.TabIndex = 1
        Me.btnAutorizar.Text = "AUTORIZAR"
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCliente.Location = New System.Drawing.Point(425, 18)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescCliente.Size = New System.Drawing.Size(304, 21)
        Me.lblDescCliente.TabIndex = 0
        Me.lblDescCliente.Text = "bla"
        Me.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(345, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCliente.Size = New System.Drawing.Size(74, 21)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "A99999"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CLIENTE"
        '
        'lblTipoPedido
        '
        Me.lblTipoPedido.BackColor = System.Drawing.Color.Cyan
        Me.lblTipoPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPedido.Location = New System.Drawing.Point(302, 44)
        Me.lblTipoPedido.Name = "lblTipoPedido"
        Me.lblTipoPedido.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTipoPedido.Size = New System.Drawing.Size(74, 21)
        Me.lblTipoPedido.TabIndex = 0
        Me.lblTipoPedido.Text = "NORMAL"
        Me.lblTipoPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFecEntrega
        '
        Me.lblFecEntrega.BackColor = System.Drawing.Color.Cyan
        Me.lblFecEntrega.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFecEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecEntrega.Location = New System.Drawing.Point(116, 44)
        Me.lblFecEntrega.Name = "lblFecEntrega"
        Me.lblFecEntrega.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblFecEntrega.Size = New System.Drawing.Size(74, 21)
        Me.lblFecEntrega.TabIndex = 0
        Me.lblFecEntrega.Text = "00/00/0000"
        Me.lblFecEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(199, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "TIPO DE PEDIDO"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Cyan
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(202, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblFecha.Size = New System.Drawing.Size(74, 21)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "00/00/0000"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "FECHA ENTREGA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(154, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "FECHA"
        '
        'lblPedido
        '
        Me.lblPedido.BackColor = System.Drawing.Color.Cyan
        Me.lblPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedido.Location = New System.Drawing.Point(66, 18)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPedido.Size = New System.Drawing.Size(74, 21)
        Me.lblPedido.TabIndex = 0
        Me.lblPedido.Text = "999999"
        Me.lblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PEDIDO"
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.Descripcion, Me.Cantidad, Me.Entregar, Me.Partida, Me.Canti, Me.Venc75, Me.Revalida, Me.CoA, Me.PathCoA})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDatos.DoubleBuffered = True
        Me.dgvDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvDatos.Location = New System.Drawing.Point(5, 131)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.OrdenamientoColumnasHabilitado = False
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.RowHeadersWidth = 15
        Me.dgvDatos.RowTemplate.Height = 20
        Me.dgvDatos.ShowCellToolTips = False
        Me.dgvDatos.SinClickDerecho = False
        Me.dgvDatos.Size = New System.Drawing.Size(741, 303)
        Me.dgvDatos.TabIndex = 5
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Producto.Width = 62
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cantidad.Width = 61
        '
        'Entregar
        '
        Me.Entregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Entregar.DataPropertyName = "Entregar"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Entregar.DefaultCellStyle = DataGridViewCellStyle2
        Me.Entregar.HeaderText = "A Entregar"
        Me.Entregar.Name = "Entregar"
        Me.Entregar.ReadOnly = True
        Me.Entregar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Entregar.Width = 69
        '
        'Partida
        '
        Me.Partida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Partida.DataPropertyName = "Partida"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Partida.DefaultCellStyle = DataGridViewCellStyle3
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        Me.Partida.ReadOnly = True
        Me.Partida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Partida.Width = 52
        '
        'Canti
        '
        Me.Canti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Canti.DataPropertyName = "Canti"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Canti.DefaultCellStyle = DataGridViewCellStyle4
        Me.Canti.HeaderText = "Cant x Partida"
        Me.Canti.Name = "Canti"
        Me.Canti.ReadOnly = True
        Me.Canti.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Canti.Width = 85
        '
        'Venc75
        '
        Me.Venc75.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Venc75.DataPropertyName = "Venc75"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Venc75.DefaultCellStyle = DataGridViewCellStyle5
        Me.Venc75.HeaderText = "75%"
        Me.Venc75.Name = "Venc75"
        Me.Venc75.ReadOnly = True
        Me.Venc75.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Venc75.Width = 39
        '
        'Revalida
        '
        Me.Revalida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Revalida.DataPropertyName = "Revalida"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Revalida.DefaultCellStyle = DataGridViewCellStyle6
        Me.Revalida.HeaderText = "Reválida"
        Me.Revalida.Name = "Revalida"
        Me.Revalida.ReadOnly = True
        Me.Revalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Revalida.Width = 61
        '
        'CoA
        '
        Me.CoA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CoA.DataPropertyName = "CoA"
        DataGridViewCellStyle7.NullValue = " "
        Me.CoA.DefaultCellStyle = DataGridViewCellStyle7
        Me.CoA.HeaderText = "CoA"
        Me.CoA.Name = "CoA"
        Me.CoA.ReadOnly = True
        Me.CoA.Text = "Generar"
        Me.CoA.Width = 39
        '
        'PathCoA
        '
        Me.PathCoA.DataPropertyName = "PathCoA"
        Me.PathCoA.HeaderText = "PathCoA"
        Me.PathCoA.Name = "PathCoA"
        Me.PathCoA.ReadOnly = True
        Me.PathCoA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PathCoA.Visible = False
        '
        'AutorizarPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 438)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutorizarPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescCliente As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTipoPedido As System.Windows.Forms.Label
    Friend WithEvents lblFecEntrega As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Util.DBDataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Canti As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Venc75 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Revalida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents PathCoA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
