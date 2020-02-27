<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoLineasDeVentas
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnAgregarLineaVenta = New System.Windows.Forms.Button()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.txtAccesoRap = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DGV_LineasVentas = New ConsultasVarias.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_LineasVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Acceso Rapido"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(104, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Buscador"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(306, 301)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 23)
        Me.btnCerrar.TabIndex = 17
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.Location = New System.Drawing.Point(171, 301)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(88, 23)
        Me.btnPantalla.TabIndex = 16
        Me.btnPantalla.Text = "Pantalla"
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'btnAgregarLineaVenta
        '
        Me.btnAgregarLineaVenta.Location = New System.Drawing.Point(12, 301)
        Me.btnAgregarLineaVenta.Name = "btnAgregarLineaVenta"
        Me.btnAgregarLineaVenta.Size = New System.Drawing.Size(115, 23)
        Me.btnAgregarLineaVenta.TabIndex = 15
        Me.btnAgregarLineaVenta.Text = "Agregar Linea Venta"
        Me.btnAgregarLineaVenta.UseVisualStyleBackColor = True
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(102, 84)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(332, 20)
        Me.txtBuscador.TabIndex = 14
        '
        'txtAccesoRap
        '
        Me.txtAccesoRap.Location = New System.Drawing.Point(1, 84)
        Me.txtAccesoRap.Name = "txtAccesoRap"
        Me.txtAccesoRap.Size = New System.Drawing.Size(95, 20)
        Me.txtAccesoRap.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 61)
        Me.Panel1.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(280, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(208, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Ingreso de Lineas de Venta"
        '
        'DGV_LineasVentas
        '
        Me.DGV_LineasVentas.AllowUserToAddRows = False
        Me.DGV_LineasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_LineasVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_LineasVentas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_LineasVentas.DoubleBuffered = True
        Me.DGV_LineasVentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_LineasVentas.Location = New System.Drawing.Point(1, 110)
        Me.DGV_LineasVentas.Name = "DGV_LineasVentas"
        Me.DGV_LineasVentas.OrdenamientoColumnasHabilitado = True
        Me.DGV_LineasVentas.RowHeadersWidth = 15
        Me.DGV_LineasVentas.RowTemplate.Height = 20
        Me.DGV_LineasVentas.ShowCellToolTips = False
        Me.DGV_LineasVentas.SinClickDerecho = False
        Me.DGV_LineasVentas.Size = New System.Drawing.Size(433, 185)
        Me.DGV_LineasVentas.TabIndex = 11
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'IngresoLineasDeVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 329)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnAgregarLineaVenta)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.txtAccesoRap)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV_LineasVentas)
        Me.Name = "IngresoLineasDeVentas"
        Me.Text = "IngresoLineasDeVentas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_LineasVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnAgregarLineaVenta As System.Windows.Forms.Button
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents txtAccesoRap As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_LineasVentas As ConsultasVarias.DBDataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
