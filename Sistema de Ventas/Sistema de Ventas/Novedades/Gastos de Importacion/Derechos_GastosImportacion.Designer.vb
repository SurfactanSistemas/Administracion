<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Derechos_GastosImportacion
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DGV_Derechos = New Util.DBDataGridView()
        Me.btn_FinIngreso = New System.Windows.Forms.Button()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Derechos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Derechos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(478, 40)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(319, 19)
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
        Me.label1.Location = New System.Drawing.Point(7, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(282, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Ingresos de Derechos de Estadisticas"
        '
        'DGV_Derechos
        '
        Me.DGV_Derechos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Derechos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Articulo, Me.Descripcion, Me.Derechos, Me.Clave})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Derechos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Derechos.DoubleBuffered = True
        Me.DGV_Derechos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Derechos.Location = New System.Drawing.Point(10, 46)
        Me.DGV_Derechos.Name = "DGV_Derechos"
        Me.DGV_Derechos.OrdenamientoColumnasHabilitado = True
        Me.DGV_Derechos.RowHeadersWidth = 15
        Me.DGV_Derechos.RowTemplate.Height = 20
        Me.DGV_Derechos.ShowCellToolTips = False
        Me.DGV_Derechos.SinClickDerecho = False
        Me.DGV_Derechos.Size = New System.Drawing.Size(456, 213)
        Me.DGV_Derechos.TabIndex = 6
        '
        'btn_FinIngreso
        '
        Me.btn_FinIngreso.Location = New System.Drawing.Point(200, 265)
        Me.btn_FinIngreso.Name = "btn_FinIngreso"
        Me.btn_FinIngreso.Size = New System.Drawing.Size(103, 35)
        Me.btn_FinIngreso.TabIndex = 7
        Me.btn_FinIngreso.Text = "FIN DE INGRESO"
        Me.btn_FinIngreso.UseVisualStyleBackColor = True
        '
        'Articulo
        '
        Me.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Width = 67
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Derechos
        '
        Me.Derechos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Derechos.HeaderText = "Derechos"
        Me.Derechos.Name = "Derechos"
        Me.Derechos.Width = 78
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'Derechos_GastosImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 313)
        Me.Controls.Add(Me.btn_FinIngreso)
        Me.Controls.Add(Me.DGV_Derechos)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Derechos_GastosImportacion"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Derechos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Derechos As Util.DBDataGridView
    Friend WithEvents btn_FinIngreso As System.Windows.Forms.Button
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Derechos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
