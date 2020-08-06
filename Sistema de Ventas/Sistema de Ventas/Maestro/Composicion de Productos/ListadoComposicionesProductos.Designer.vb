<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoComposicionesProductos
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txtProducto = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvListado = New Util.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefLaboratorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(810, 40)
        Me.panel1.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(634, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(323, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "LISTADO DE COMPOSICIONES DE PRODUCTOS"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnExportar)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.txtHasta)
        Me.GroupBox1.Controls.Add(Me.txtDesde)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 80)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(343, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(96, 29)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(483, 11)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(96, 38)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "NUEVO"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(585, 11)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 38)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "EXPORTAR"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(687, 11)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(96, 38)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(257, 21)
        Me.txtHasta.Mask = ">LL-00000-000"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(80, 20)
        Me.txtHasta.TabIndex = 2
        Me.txtHasta.Text = "ZZ99999999"
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(149, 21)
        Me.txtDesde.Mask = ">LL-00000-000"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(80, 20)
        Me.txtDesde.TabIndex = 2
        Me.txtDesde.Text = "PT00000000"
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(84, 55)
        Me.txtProducto.Mask = ">LL-00000-000"
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtProducto.Size = New System.Drawing.Size(80, 20)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.Text = "PT99999999"
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "PRODUCTO"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(243, 55)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(540, 20)
        Me.txtFiltrar.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "FILTRAR POR CODIGOS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "AL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(185, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "FILTRAR"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.Descripcion, Me.Fecha, Me.Version, Me.Estado, Me.Responsable, Me.RefLaboratorio})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListado.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvListado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvListado.DoubleBuffered = True
        Me.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvListado.Location = New System.Drawing.Point(0, 128)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.OrdenamientoColumnasHabilitado = False
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 15
        Me.dgvListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.dgvListado.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvListado.RowTemplate.Height = 20
        Me.dgvListado.ShowCellToolTips = False
        Me.dgvListado.SinClickDerecho = False
        Me.dgvListado.Size = New System.Drawing.Size(810, 294)
        Me.dgvListado.TabIndex = 40
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Producto.Width = 56
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
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle9
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha.Width = 43
        '
        'Version
        '
        Me.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Version.DataPropertyName = "Version"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.Version.DefaultCellStyle = DataGridViewCellStyle10
        Me.Version.HeaderText = "Versión"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Version.Width = 48
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Estado.Width = 46
        '
        'Responsable
        '
        Me.Responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Responsable.DataPropertyName = "Responsable"
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        Me.Responsable.ReadOnly = True
        Me.Responsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Responsable.Width = 75
        '
        'RefLaboratorio
        '
        Me.RefLaboratorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RefLaboratorio.DataPropertyName = "RefLaboratorio"
        Me.RefLaboratorio.HeaderText = "Ref. Lab."
        Me.RefLaboratorio.Name = "RefLaboratorio"
        Me.RefLaboratorio.ReadOnly = True
        Me.RefLaboratorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RefLaboratorio.Width = 57
        '
        'ListadoComposicionesProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 422)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ListadoComposicionesProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvListado As Util.DBDataGridView
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefLaboratorio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
