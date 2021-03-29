<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprePlanillaValidaciones
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
        Me.DbDataGridView1 = New Util.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Metodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DbDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbDataGridView1
        '
        Me.DbDataGridView1.AllowUserToAddRows = False
        Me.DbDataGridView1.AllowUserToDeleteRows = False
        Me.DbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DbDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.DescProducto, Me.Metodo, Me.Ensayo, Me.Formula, Me.Resultado})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DbDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DbDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DbDataGridView1.DoubleBuffered = True
        Me.DbDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DbDataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DbDataGridView1.Name = "DbDataGridView1"
        Me.DbDataGridView1.OrdenamientoColumnasHabilitado = True
        Me.DbDataGridView1.ReadOnly = True
        Me.DbDataGridView1.RowHeadersWidth = 15
        Me.DbDataGridView1.RowTemplate.Height = 20
        Me.DbDataGridView1.ShowCellToolTips = False
        Me.DbDataGridView1.SinClickDerecho = False
        Me.DbDataGridView1.Size = New System.Drawing.Size(778, 427)
        Me.DbDataGridView1.TabIndex = 0
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'DescProducto
        '
        Me.DescProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescProducto.HeaderText = "DescProducto"
        Me.DescProducto.Name = "DescProducto"
        Me.DescProducto.ReadOnly = True
        '
        'Metodo
        '
        Me.Metodo.HeaderText = "Metodo"
        Me.Metodo.Name = "Metodo"
        Me.Metodo.ReadOnly = True
        '
        'Ensayo
        '
        Me.Ensayo.HeaderText = "Ensayo"
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        '
        'Formula
        '
        Me.Formula.HeaderText = "Formula"
        Me.Formula.Name = "Formula"
        Me.Formula.ReadOnly = True
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.Name = "Resultado"
        Me.Resultado.ReadOnly = True
        '
        'ImprePlanillaValidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 427)
        Me.Controls.Add(Me.DbDataGridView1)
        Me.Name = "ImprePlanillaValidaciones"
        Me.Text = "ImprePlanillaValidaciones"
        CType(Me.DbDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbDataGridView1 As Util.DBDataGridView
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Metodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Formula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
