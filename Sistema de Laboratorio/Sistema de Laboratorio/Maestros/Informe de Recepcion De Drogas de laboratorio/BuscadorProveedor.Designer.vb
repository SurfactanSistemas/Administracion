<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscadorProveedor
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
        Me.txtBuscardorProv = New System.Windows.Forms.TextBox()
        Me.btnVolver_PnlProveedores = New System.Windows.Forms.Button()
        Me.DGV_Proveedores = New ConsultasVarias.DBDataGridView()
        Me.CodigoProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.DGV_Proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscardorProv
        '
        Me.txtBuscardorProv.Location = New System.Drawing.Point(12, 60)
        Me.txtBuscardorProv.Name = "txtBuscardorProv"
        Me.txtBuscardorProv.Size = New System.Drawing.Size(476, 20)
        Me.txtBuscardorProv.TabIndex = 7
        '
        'btnVolver_PnlProveedores
        '
        Me.btnVolver_PnlProveedores.Location = New System.Drawing.Point(203, 277)
        Me.btnVolver_PnlProveedores.Name = "btnVolver_PnlProveedores"
        Me.btnVolver_PnlProveedores.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver_PnlProveedores.TabIndex = 6
        Me.btnVolver_PnlProveedores.Text = "Volver"
        Me.btnVolver_PnlProveedores.UseVisualStyleBackColor = True
        '
        'DGV_Proveedores
        '
        Me.DGV_Proveedores.AllowUserToAddRows = False
        Me.DGV_Proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Proveedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoProv, Me.DescripcionProv})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Proveedores.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Proveedores.DoubleBuffered = True
        Me.DGV_Proveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_Proveedores.Location = New System.Drawing.Point(12, 86)
        Me.DGV_Proveedores.Name = "DGV_Proveedores"
        Me.DGV_Proveedores.OrdenamientoColumnasHabilitado = True
        Me.DGV_Proveedores.RowHeadersWidth = 15
        Me.DGV_Proveedores.RowTemplate.Height = 20
        Me.DGV_Proveedores.ShowCellToolTips = False
        Me.DGV_Proveedores.SinClickDerecho = False
        Me.DGV_Proveedores.Size = New System.Drawing.Size(476, 187)
        Me.DGV_Proveedores.TabIndex = 5
        '
        'CodigoProv
        '
        Me.CodigoProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoProv.DataPropertyName = "CodigoProv"
        Me.CodigoProv.HeaderText = "Codigo"
        Me.CodigoProv.MinimumWidth = 100
        Me.CodigoProv.Name = "CodigoProv"
        '
        'DescripcionProv
        '
        Me.DescripcionProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionProv.DataPropertyName = "DescripcionProv"
        Me.DescripcionProv.HeaderText = "Descripcion"
        Me.DescripcionProv.Name = "DescripcionProv"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label23)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(494, 54)
        Me.Panel8.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.Control
        Me.Label23.Location = New System.Drawing.Point(2, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(201, 20)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Busqueda de Proveedor"
        '
        'BuscadorProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 303)
        Me.Controls.Add(Me.txtBuscardorProv)
        Me.Controls.Add(Me.btnVolver_PnlProveedores)
        Me.Controls.Add(Me.DGV_Proveedores)
        Me.Controls.Add(Me.Panel8)
        Me.Location = New System.Drawing.Point(30, 30)
        Me.MaximumSize = New System.Drawing.Size(510, 342)
        Me.MinimumSize = New System.Drawing.Size(510, 342)
        Me.Name = "BuscadorProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.DGV_Proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBuscardorProv As System.Windows.Forms.TextBox
    Friend WithEvents btnVolver_PnlProveedores As System.Windows.Forms.Button
    Friend WithEvents DGV_Proveedores As ConsultasVarias.DBDataGridView
    Friend WithEvents CodigoProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
