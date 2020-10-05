<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosPendientesXClientes
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_ClienteDes = New System.Windows.Forms.TextBox()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.DGV_PedidosPendientes = New Util.DBDataGridView()
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFecEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_PedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(390, 50)
        Me.panel1.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(235, 30)
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
        Me.label1.Size = New System.Drawing.Size(152, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Pedidos Pendientes"
        '
        'txt_ClienteDes
        '
        Me.txt_ClienteDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ClienteDes.Location = New System.Drawing.Point(77, 56)
        Me.txt_ClienteDes.Name = "txt_ClienteDes"
        Me.txt_ClienteDes.ReadOnly = True
        Me.txt_ClienteDes.Size = New System.Drawing.Size(309, 20)
        Me.txt_ClienteDes.TabIndex = 135
        '
        'txt_Cliente
        '
        Me.txt_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cliente.Location = New System.Drawing.Point(6, 56)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.ReadOnly = True
        Me.txt_Cliente.Size = New System.Drawing.Size(65, 20)
        Me.txt_Cliente.TabIndex = 134
        '
        'DGV_PedidosPendientes
        '
        Me.DGV_PedidosPendientes.AllowUserToAddRows = False
        Me.DGV_PedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PedidosPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pedido, Me.FechaPedido, Me.FecEntrega, Me.OrdFecEntrega})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_PedidosPendientes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_PedidosPendientes.DoubleBuffered = True
        Me.DGV_PedidosPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_PedidosPendientes.Location = New System.Drawing.Point(6, 83)
        Me.DGV_PedidosPendientes.Name = "DGV_PedidosPendientes"
        Me.DGV_PedidosPendientes.OrdenamientoColumnasHabilitado = True
        Me.DGV_PedidosPendientes.RowHeadersWidth = 15
        Me.DGV_PedidosPendientes.RowTemplate.Height = 20
        Me.DGV_PedidosPendientes.ShowCellToolTips = False
        Me.DGV_PedidosPendientes.SinClickDerecho = False
        Me.DGV_PedidosPendientes.Size = New System.Drawing.Size(306, 238)
        Me.DGV_PedidosPendientes.TabIndex = 136
        '
        'Pedido
        '
        Me.Pedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pedido.DataPropertyName = "Pedido"
        Me.Pedido.HeaderText = "Nro Pedido"
        Me.Pedido.Name = "Pedido"
        Me.Pedido.ReadOnly = True
        Me.Pedido.Width = 85
        '
        'FechaPedido
        '
        Me.FechaPedido.DataPropertyName = "FechaPedido"
        Me.FechaPedido.HeaderText = "Fecha Pedido"
        Me.FechaPedido.Name = "FechaPedido"
        Me.FechaPedido.ReadOnly = True
        '
        'FecEntrega
        '
        Me.FecEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FecEntrega.DataPropertyName = "FecEntrega"
        Me.FecEntrega.HeaderText = "Fecha Entrega"
        Me.FecEntrega.Name = "FecEntrega"
        Me.FecEntrega.ReadOnly = True
        Me.FecEntrega.Width = 102
        '
        'OrdFecEntrega
        '
        Me.OrdFecEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.OrdFecEntrega.DataPropertyName = "OrdFecEntrega"
        Me.OrdFecEntrega.HeaderText = "OrdFecEntrega"
        Me.OrdFecEntrega.Name = "OrdFecEntrega"
        Me.OrdFecEntrega.ReadOnly = True
        Me.OrdFecEntrega.Visible = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(318, 82)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(68, 43)
        Me.btn_Cerrar.TabIndex = 139
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'PedidosPendientesXClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 326)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_PedidosPendientes)
        Me.Controls.Add(Me.txt_ClienteDes)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.panel1)
        Me.Name = "PedidosPendientesXClientes"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_PedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ClienteDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents DGV_PedidosPendientes As Util.DBDataGridView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFecEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
