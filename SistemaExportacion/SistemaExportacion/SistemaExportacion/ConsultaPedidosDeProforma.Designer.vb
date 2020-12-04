<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaPedidosDeProforma
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPrincipal = New System.Windows.Forms.DataGridView()
        Me.txtFiltrarPor = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NroPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(793, 52)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(612, 27)
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
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pedido Proforma"
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.AllowUserToAddRows = False
        Me.dgvPrincipal.AllowUserToDeleteRows = False
        Me.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroPedido, Me.Fecha, Me.Cliente, Me.Razon, Me.Pais, Me.Total, Me.OperadorDesc})
        Me.dgvPrincipal.Location = New System.Drawing.Point(6, 102)
        Me.dgvPrincipal.Margin = New System.Windows.Forms.Padding(15)
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.Size = New System.Drawing.Size(782, 348)
        Me.dgvPrincipal.TabIndex = 9
        '
        'txtFiltrarPor
        '
        Me.txtFiltrarPor.Location = New System.Drawing.Point(6, 75)
        Me.txtFiltrarPor.Name = "txtFiltrarPor"
        Me.txtFiltrarPor.Size = New System.Drawing.Size(694, 20)
        Me.txtFiltrarPor.TabIndex = 10
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(706, 59)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 36)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Filtrar"
        '
        'NroPedido
        '
        Me.NroPedido.DataPropertyName = "NroPedido"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroPedido.DefaultCellStyle = DataGridViewCellStyle1
        Me.NroPedido.HeaderText = "Nro Pedido"
        Me.NroPedido.MaxInputLength = 6
        Me.NroPedido.Name = "NroPedido"
        Me.NroPedido.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle3
        Me.Total.HeaderText = "Monto Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'OperadorDesc
        '
        Me.OperadorDesc.DataPropertyName = "OperadorDesc"
        Me.OperadorDesc.HeaderText = "Vendedor"
        Me.OperadorDesc.Name = "OperadorDesc"
        Me.OperadorDesc.ReadOnly = True
        '
        'ConsultaPedidosDeProforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 457)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.txtFiltrarPor)
        Me.Controls.Add(Me.dgvPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ConsultaPedidosDeProforma"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPrincipal As System.Windows.Forms.DataGridView
    Friend WithEvents txtFiltrarPor As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NroPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorDesc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
