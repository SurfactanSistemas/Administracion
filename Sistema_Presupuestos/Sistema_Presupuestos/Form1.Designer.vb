<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_filtro = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btn_NuevoPresupuesto = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.dgv_Presupuestos = New Util.DBDataGridView()
        Me.NroPresu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_Presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1334, 49)
        Me.panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1100, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(28, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(276, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "GESTION DE PRESUPUESTOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Proveedor"
        '
        'txt_filtro
        '
        Me.txt_filtro.Location = New System.Drawing.Point(16, 79)
        Me.txt_filtro.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_filtro.Name = "txt_filtro"
        Me.txt_filtro.Size = New System.Drawing.Size(355, 22)
        Me.txt_filtro.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(380, 81)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(202, 21)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Listar Cerradas/Finalizadas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_NuevoPresupuesto
        '
        Me.btn_NuevoPresupuesto.Location = New System.Drawing.Point(592, 59)
        Me.btn_NuevoPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_NuevoPresupuesto.Name = "btn_NuevoPresupuesto"
        Me.btn_NuevoPresupuesto.Size = New System.Drawing.Size(100, 47)
        Me.btn_NuevoPresupuesto.TabIndex = 12
        Me.btn_NuevoPresupuesto.Text = "Nuevo Presupuesto"
        Me.btn_NuevoPresupuesto.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(1213, 59)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(100, 47)
        Me.btn_Cerrar.TabIndex = 13
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'dgv_Presupuestos
        '
        Me.dgv_Presupuestos.AllowUserToAddRows = False
        Me.dgv_Presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Presupuestos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroPresu, Me.Cod_Proveedor, Me.Proveedor, Me.Titulo, Me.Fecha, Me.FormaPago, Me.Monto, Me.Pagado, Me.Saldo, Me.Moneda})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Presupuestos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_Presupuestos.DoubleBuffered = True
        Me.dgv_Presupuestos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Presupuestos.Location = New System.Drawing.Point(16, 111)
        Me.dgv_Presupuestos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Presupuestos.Name = "dgv_Presupuestos"
        Me.dgv_Presupuestos.OrdenamientoColumnasHabilitado = True
        Me.dgv_Presupuestos.RowHeadersWidth = 15
        Me.dgv_Presupuestos.RowTemplate.Height = 20
        Me.dgv_Presupuestos.ShowCellToolTips = False
        Me.dgv_Presupuestos.SinClickDerecho = False
        Me.dgv_Presupuestos.Size = New System.Drawing.Size(1297, 435)
        Me.dgv_Presupuestos.TabIndex = 8
        '
        'NroPresu
        '
        Me.NroPresu.DataPropertyName = "NroPresu"
        Me.NroPresu.HeaderText = "Nro. "
        Me.NroPresu.Name = "NroPresu"
        Me.NroPresu.ReadOnly = True
        Me.NroPresu.Width = 40
        '
        'Cod_Proveedor
        '
        Me.Cod_Proveedor.DataPropertyName = "Cod_Proveedor"
        Me.Cod_Proveedor.HeaderText = "Cod_Proveedor"
        Me.Cod_Proveedor.Name = "Cod_Proveedor"
        Me.Cod_Proveedor.Visible = False
        '
        'Proveedor
        '
        Me.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Width = 103
        '
        'Titulo
        '
        Me.Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Titulo.DataPropertyName = "Titulo"
        Me.Titulo.HeaderText = "Titulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 76
        '
        'FormaPago
        '
        Me.FormaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FormaPago.DataPropertyName = "FormaPago"
        Me.FormaPago.HeaderText = "Forma Pago"
        Me.FormaPago.Name = "FormaPago"
        Me.FormaPago.ReadOnly = True
        '
        'Monto
        '
        Me.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Monto.DataPropertyName = "Monto"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle1
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 76
        '
        'Pagado
        '
        Me.Pagado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pagado.DataPropertyName = "Pagado"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Pagado.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pagado.HeaderText = "Pagado"
        Me.Pagado.Name = "Pagado"
        Me.Pagado.Width = 86
        '
        'Saldo
        '
        Me.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Saldo.DataPropertyName = "Saldo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.Width = 73
        '
        'Moneda
        '
        Me.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Moneda.DataPropertyName = "Moneda"
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.Width = 88
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 559)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_NuevoPresupuesto)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txt_filtro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.dgv_Presupuestos)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_Presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_Presupuestos As Util.DBDataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_filtro As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_NuevoPresupuesto As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents NroPresu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cod_Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pagado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
