<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaPedidosPendXCliente
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.DGV_PedidosPendientes = New Util.DBDataGridView()
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFechaPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_PedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(394, 40)
        Me.panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(239, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SURFACTAN S.A."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(220, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Consulta Pedidos Pendientes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Filtro"
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(7, 59)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(382, 20)
        Me.txt_Filtro.TabIndex = 13
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(157, 303)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 43)
        Me.btn_Cerrar.TabIndex = 16
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'DGV_PedidosPendientes
        '
        Me.DGV_PedidosPendientes.AllowUserToAddRows = False
        Me.DGV_PedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PedidosPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pedido, Me.NroPedido, Me.Cliente, Me.FechaPedido, Me.OrdFechaPedido, Me.FechaEntrega, Me.OrdFechaEntrega})
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
        Me.DGV_PedidosPendientes.Location = New System.Drawing.Point(7, 85)
        Me.DGV_PedidosPendientes.Name = "DGV_PedidosPendientes"
        Me.DGV_PedidosPendientes.OrdenamientoColumnasHabilitado = True
        Me.DGV_PedidosPendientes.RowHeadersWidth = 15
        Me.DGV_PedidosPendientes.RowTemplate.Height = 20
        Me.DGV_PedidosPendientes.ShowCellToolTips = False
        Me.DGV_PedidosPendientes.SinClickDerecho = False
        Me.DGV_PedidosPendientes.Size = New System.Drawing.Size(382, 215)
        Me.DGV_PedidosPendientes.TabIndex = 15
        '
        'Pedido
        '
        Me.Pedido.DataPropertyName = "Pedido"
        Me.Pedido.HeaderText = "Pedido"
        Me.Pedido.Name = "Pedido"
        Me.Pedido.Visible = False
        '
        'NroPedido
        '
        Me.NroPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NroPedido.DataPropertyName = "NroPedido"
        Me.NroPedido.HeaderText = "Nro Pedido"
        Me.NroPedido.Name = "NroPedido"
        Me.NroPedido.ReadOnly = True
        Me.NroPedido.Width = 85
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 70
        '
        'FechaPedido
        '
        Me.FechaPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaPedido.DataPropertyName = "FechaPedido"
        Me.FechaPedido.HeaderText = "Fecha Pedico"
        Me.FechaPedido.Name = "FechaPedido"
        Me.FechaPedido.ReadOnly = True
        Me.FechaPedido.Width = 98
        '
        'OrdFechaPedido
        '
        Me.OrdFechaPedido.DataPropertyName = "OrdFechaPedido"
        Me.OrdFechaPedido.HeaderText = "OrdFechaPedido"
        Me.OrdFechaPedido.Name = "OrdFechaPedido"
        Me.OrdFechaPedido.ReadOnly = True
        Me.OrdFechaPedido.Visible = False
        Me.OrdFechaPedido.Width = 70
        '
        'FechaEntrega
        '
        Me.FechaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaEntrega.DataPropertyName = "FechaEntrega"
        Me.FechaEntrega.HeaderText = "Fecha Entrega"
        Me.FechaEntrega.Name = "FechaEntrega"
        Me.FechaEntrega.ReadOnly = True
        Me.FechaEntrega.Width = 102
        '
        'OrdFechaEntrega
        '
        Me.OrdFechaEntrega.DataPropertyName = "OrdFechaEntrega"
        Me.OrdFechaEntrega.HeaderText = "OrdFechaEntrega"
        Me.OrdFechaEntrega.Name = "OrdFechaEntrega"
        Me.OrdFechaEntrega.ReadOnly = True
        Me.OrdFechaEntrega.Visible = False
        Me.OrdFechaEntrega.Width = 70
        '
        'ConsultaPedidosPendXCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 349)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_PedidosPendientes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ConsultaPedidosPendXCliente"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_PedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents DGV_PedidosPendientes As Util.DBDataGridView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFechaPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFechaEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
