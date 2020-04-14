<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscadorOrdenCompraXProvee
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
        Me.btnVolver_pnlAyudaProv = New System.Windows.Forms.Button()
        Me.DGV_AyudaProv = New ConsultasVarias.DBDataGridView()
        Me.AyudaArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AyudaDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AyudaSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        CType(Me.DGV_AyudaProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVolver_pnlAyudaProv
        '
        Me.btnVolver_pnlAyudaProv.Location = New System.Drawing.Point(185, 220)
        Me.btnVolver_pnlAyudaProv.Name = "btnVolver_pnlAyudaProv"
        Me.btnVolver_pnlAyudaProv.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver_pnlAyudaProv.TabIndex = 5
        Me.btnVolver_pnlAyudaProv.Text = "Volver"
        Me.btnVolver_pnlAyudaProv.UseVisualStyleBackColor = True
        '
        'DGV_AyudaProv
        '
        Me.DGV_AyudaProv.AllowUserToAddRows = False
        Me.DGV_AyudaProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_AyudaProv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AyudaArticulo, Me.AyudaDescripcion, Me.AyudaSaldo, Me.NroOrden})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_AyudaProv.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_AyudaProv.DoubleBuffered = True
        Me.DGV_AyudaProv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_AyudaProv.Location = New System.Drawing.Point(9, 53)
        Me.DGV_AyudaProv.Name = "DGV_AyudaProv"
        Me.DGV_AyudaProv.OrdenamientoColumnasHabilitado = True
        Me.DGV_AyudaProv.RowHeadersWidth = 15
        Me.DGV_AyudaProv.RowTemplate.Height = 20
        Me.DGV_AyudaProv.ShowCellToolTips = False
        Me.DGV_AyudaProv.SinClickDerecho = False
        Me.DGV_AyudaProv.Size = New System.Drawing.Size(451, 160)
        Me.DGV_AyudaProv.TabIndex = 4
        '
        'AyudaArticulo
        '
        Me.AyudaArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AyudaArticulo.DataPropertyName = "AyudaArticulo"
        Me.AyudaArticulo.HeaderText = "Materia Prima"
        Me.AyudaArticulo.Name = "AyudaArticulo"
        Me.AyudaArticulo.Width = 96
        '
        'AyudaDescripcion
        '
        Me.AyudaDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AyudaDescripcion.DataPropertyName = "AyudaDescripcion"
        Me.AyudaDescripcion.HeaderText = "Descripcion"
        Me.AyudaDescripcion.Name = "AyudaDescripcion"
        '
        'AyudaSaldo
        '
        Me.AyudaSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.AyudaSaldo.DataPropertyName = "AyudaSaldo"
        Me.AyudaSaldo.HeaderText = "Saldo"
        Me.AyudaSaldo.Name = "AyudaSaldo"
        Me.AyudaSaldo.Width = 59
        '
        'NroOrden
        '
        Me.NroOrden.DataPropertyName = "NroOrden"
        Me.NroOrden.HeaderText = "NroOrden"
        Me.NroOrden.Name = "NroOrden"
        Me.NroOrden.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(466, 47)
        Me.Panel7.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Control
        Me.Label16.Location = New System.Drawing.Point(4, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(249, 20)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Ayuda Ordenes por Proveedor"
        '
        'BuscadorOrdenCompraXProvee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 249)
        Me.Controls.Add(Me.btnVolver_pnlAyudaProv)
        Me.Controls.Add(Me.DGV_AyudaProv)
        Me.Controls.Add(Me.Panel7)
        Me.Location = New System.Drawing.Point(30, 30)
        Me.MaximumSize = New System.Drawing.Size(482, 288)
        Me.MinimumSize = New System.Drawing.Size(482, 288)
        Me.Name = "BuscadorOrdenCompraXProvee"
        CType(Me.DGV_AyudaProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVolver_pnlAyudaProv As System.Windows.Forms.Button
    Friend WithEvents DGV_AyudaProv As ConsultasVarias.DBDataGridView
    Friend WithEvents AyudaArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AyudaDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AyudaSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroOrden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
