<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidoDetallado
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Pedido = New System.Windows.Forms.TextBox()
        Me.DGV_PedidosPendientes = New Util.DBDataGridView()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Terminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pendiente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFecEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.panel1.Size = New System.Drawing.Size(437, 50)
        Me.panel1.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(282, 30)
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
        Me.label1.Size = New System.Drawing.Size(132, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Pedido Detallado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Nro Pedido"
        '
        'txt_Pedido
        '
        Me.txt_Pedido.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Pedido.Location = New System.Drawing.Point(70, 52)
        Me.txt_Pedido.Name = "txt_Pedido"
        Me.txt_Pedido.ReadOnly = True
        Me.txt_Pedido.Size = New System.Drawing.Size(63, 20)
        Me.txt_Pedido.TabIndex = 132
        '
        'DGV_PedidosPendientes
        '
        Me.DGV_PedidosPendientes.AllowUserToAddRows = False
        Me.DGV_PedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PedidosPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Terminado, Me.Descripcion, Me.FecEntrega, Me.Pendiente, Me.OrdFecEntrega})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_PedidosPendientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_PedidosPendientes.DoubleBuffered = True
        Me.DGV_PedidosPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_PedidosPendientes.Location = New System.Drawing.Point(9, 74)
        Me.DGV_PedidosPendientes.Name = "DGV_PedidosPendientes"
        Me.DGV_PedidosPendientes.OrdenamientoColumnasHabilitado = True
        Me.DGV_PedidosPendientes.RowHeadersWidth = 15
        Me.DGV_PedidosPendientes.RowTemplate.Height = 20
        Me.DGV_PedidosPendientes.ShowCellToolTips = False
        Me.DGV_PedidosPendientes.SinClickDerecho = False
        Me.DGV_PedidosPendientes.Size = New System.Drawing.Size(424, 184)
        Me.DGV_PedidosPendientes.TabIndex = 133
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(358, 50)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cerrar.TabIndex = 134
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Terminado
        '
        Me.Terminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Terminado.DataPropertyName = "Terminado"
        Me.Terminado.HeaderText = "Producto"
        Me.Terminado.Name = "Terminado"
        Me.Terminado.ReadOnly = True
        Me.Terminado.Width = 75
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'FecEntrega
        '
        Me.FecEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FecEntrega.DataPropertyName = "FecEntrega"
        Me.FecEntrega.HeaderText = "FecEntrega"
        Me.FecEntrega.Name = "FecEntrega"
        Me.FecEntrega.ReadOnly = True
        Me.FecEntrega.Width = 87
        '
        'Pendiente
        '
        Me.Pendiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pendiente.DataPropertyName = "Pendiente"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Pendiente.DefaultCellStyle = DataGridViewCellStyle1
        Me.Pendiente.HeaderText = "Pendiente"
        Me.Pendiente.Name = "Pendiente"
        Me.Pendiente.ReadOnly = True
        Me.Pendiente.Width = 80
        '
        'OrdFecEntrega
        '
        Me.OrdFecEntrega.DataPropertyName = "OrdFecEntrega"
        Me.OrdFecEntrega.HeaderText = "OrdFecEntrega"
        Me.OrdFecEntrega.Name = "OrdFecEntrega"
        Me.OrdFecEntrega.Visible = False
        '
        'PedidoDetallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 261)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_PedidosPendientes)
        Me.Controls.Add(Me.txt_Pedido)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.panel1)
        Me.Name = "PedidoDetallado"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_PedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Pedido As System.Windows.Forms.TextBox
    Friend WithEvents DGV_PedidosPendientes As Util.DBDataGridView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Terminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pendiente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFecEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
