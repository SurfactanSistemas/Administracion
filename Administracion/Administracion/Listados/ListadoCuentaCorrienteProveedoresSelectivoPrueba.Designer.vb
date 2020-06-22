<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCuentaCorrienteProveedoresSelectivoPrueba
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtFechaEmision = New System.Windows.Forms.MaskedTextBox()
        Me.GRilla = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GrupoConsultas = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.btnPantalla = New Administracion.CustomButton()
        Me.btnLimpiarTodo = New Administracion.CustomButton()
        Me.CustomButton1 = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnCancela = New Administracion.CustomButton()
        Me.btnCerrarConsulta = New Administracion.CustomButton()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtRazon = New Administracion.CustomTextBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.txtDesdeProveedor = New Administracion.CustomTextBox()
        Me.lstAyuda_Filtrada = New Administracion.CustomListBox()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnviarAviso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrupoConsultas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Location = New System.Drawing.Point(130, 12)
        Me.txtFechaEmision.Mask = "##/##/####"
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaEmision.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaEmision.TabIndex = 48
        Me.txtFechaEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtFechaEmision, "Fecha de Pago. Si hubiesen proveedores cargados se traeran automáticamente.")
        '
        'GRilla
        '
        Me.GRilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Razon, Me.EnviarAviso})
        Me.GRilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GRilla.Location = New System.Drawing.Point(16, 64)
        Me.GRilla.Name = "GRilla"
        Me.GRilla.RowHeadersWidth = 15
        Me.GRilla.RowTemplate.Height = 20
        Me.GRilla.Size = New System.Drawing.Size(557, 271)
        Me.GRilla.StandardTab = True
        Me.GRilla.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(589, 50)
        Me.Panel1.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(414, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(333, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado Cuenta Corriente Proveedores Selectivo"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Controls.Add(Me.GrupoConsultas)
        Me.Panel2.Controls.Add(Me.txtRazon)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.txtFechaEmision)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.txtDesdeProveedor)
        Me.Panel2.Controls.Add(Me.GRilla)
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(589, 359)
        Me.Panel2.TabIndex = 60
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 337)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(557, 18)
        Me.ProgressBar1.TabIndex = 54
        '
        'GrupoConsultas
        '
        Me.GrupoConsultas.Controls.Add(Me.GroupBox1)
        Me.GrupoConsultas.Location = New System.Drawing.Point(97, 100)
        Me.GrupoConsultas.Name = "GrupoConsultas"
        Me.GrupoConsultas.Size = New System.Drawing.Size(395, 231)
        Me.GrupoConsultas.TabIndex = 53
        Me.GrupoConsultas.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCerrarConsulta)
        Me.GroupBox1.Controls.Add(Me.lstFiltrada)
        Me.GroupBox1.Controls.Add(Me.txtAyuda)
        Me.GroupBox1.Controls.Add(Me.lstAyuda)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 225)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImprimir.Cleanable = False
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.EnterIndex = -1
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.LabelAssociationKey = -1
        Me.btnImprimir.Location = New System.Drawing.Point(458, 417)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(48, 40)
        Me.btnImprimir.TabIndex = 61
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Reporte")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.BackgroundImage = Global.Administracion.My.Resources.Resources.Screen_preview
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.Cleanable = False
        Me.btnPantalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPantalla.EnterIndex = -1
        Me.btnPantalla.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.LabelAssociationKey = -1
        Me.btnPantalla.Location = New System.Drawing.Point(385, 417)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(48, 40)
        Me.btnPantalla.TabIndex = 61
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Mostrar Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'btnLimpiarTodo
        '
        Me.btnLimpiarTodo.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiarTodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiarTodo.Cleanable = False
        Me.btnLimpiarTodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarTodo.EnterIndex = -1
        Me.btnLimpiarTodo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarTodo.FlatAppearance.BorderSize = 0
        Me.btnLimpiarTodo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarTodo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiarTodo.LabelAssociationKey = -1
        Me.btnLimpiarTodo.Location = New System.Drawing.Point(312, 417)
        Me.btnLimpiarTodo.Name = "btnLimpiarTodo"
        Me.btnLimpiarTodo.Size = New System.Drawing.Size(48, 40)
        Me.btnLimpiarTodo.TabIndex = 61
        Me.ToolTip1.SetToolTip(Me.btnLimpiarTodo, "Limpiar Seleccionados / Todos")
        Me.btnLimpiarTodo.UseVisualStyleBackColor = True
        '
        'CustomButton1
        '
        Me.CustomButton1.BackgroundImage = Global.Administracion.My.Resources.Resources.refresh
        Me.CustomButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CustomButton1.Cleanable = False
        Me.CustomButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CustomButton1.EnterIndex = -1
        Me.CustomButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.BorderSize = 0
        Me.CustomButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.CustomButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton1.LabelAssociationKey = -1
        Me.CustomButton1.Location = New System.Drawing.Point(237, 417)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.Size = New System.Drawing.Size(50, 40)
        Me.CustomButton1.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.CustomButton1, "Cargar Listado Parcial de Proveedores Selectivo")
        Me.CustomButton1.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(162, 417)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(50, 40)
        Me.btnConsulta.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consultar Proveedores")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cleanable = False
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancela.EnterIndex = -1
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.LabelAssociationKey = -1
        Me.btnCancela.Location = New System.Drawing.Point(82, 417)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(55, 40)
        Me.btnCancela.TabIndex = 57
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Cerrar Ventana")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnCerrarConsulta
        '
        Me.btnCerrarConsulta.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrarConsulta.Cleanable = False
        Me.btnCerrarConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarConsulta.EnterIndex = -1
        Me.btnCerrarConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrarConsulta.FlatAppearance.BorderSize = 0
        Me.btnCerrarConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarConsulta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarConsulta.LabelAssociationKey = -1
        Me.btnCerrarConsulta.Location = New System.Drawing.Point(155, 196)
        Me.btnCerrarConsulta.Name = "btnCerrarConsulta"
        Me.btnCerrarConsulta.Size = New System.Drawing.Size(78, 23)
        Me.btnCerrarConsulta.TabIndex = 63
        Me.btnCerrarConsulta.Text = "Cerrar Consulta"
        Me.ToolTip1.SetToolTip(Me.btnCerrarConsulta, "Cerrar Ventana")
        Me.btnCerrarConsulta.UseVisualStyleBackColor = False
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(10, 43)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(368, 147)
        Me.lstFiltrada.TabIndex = 62
        Me.lstFiltrada.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(10, 17)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(368, 20)
        Me.txtAyuda.TabIndex = 53
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(10, 43)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(368, 147)
        Me.lstAyuda.TabIndex = 54
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.Silver
        Me.txtRazon.Cleanable = False
        Me.txtRazon.Empty = True
        Me.txtRazon.EnterIndex = -1
        Me.txtRazon.LabelAssociationKey = -1
        Me.txtRazon.Location = New System.Drawing.Point(248, 38)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(296, 20)
        Me.txtRazon.TabIndex = 51
        Me.txtRazon.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(29, 14)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(96, 18)
        Me.CustomLabel3.TabIndex = 47
        Me.CustomLabel3.Text = "Fecha de Pago"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(49, 40)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(73, 18)
        Me.CustomLabel1.TabIndex = 50
        Me.CustomLabel1.Text = "Proveedor"
        '
        'txtDesdeProveedor
        '
        Me.txtDesdeProveedor.Cleanable = False
        Me.txtDesdeProveedor.Empty = True
        Me.txtDesdeProveedor.EnterIndex = -1
        Me.txtDesdeProveedor.LabelAssociationKey = -1
        Me.txtDesdeProveedor.Location = New System.Drawing.Point(130, 38)
        Me.txtDesdeProveedor.MaxLength = 11
        Me.txtDesdeProveedor.Name = "txtDesdeProveedor"
        Me.txtDesdeProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtDesdeProveedor.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.txtDesdeProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtDesdeProveedor.Validator = Administracion.ValidatorType.None
        '
        'lstAyuda_Filtrada
        '
        Me.lstAyuda_Filtrada.Cleanable = False
        Me.lstAyuda_Filtrada.EnterIndex = -1
        Me.lstAyuda_Filtrada.FormattingEnabled = True
        Me.lstAyuda_Filtrada.LabelAssociationKey = -1
        Me.lstAyuda_Filtrada.Location = New System.Drawing.Point(36, 498)
        Me.lstAyuda_Filtrada.Name = "lstAyuda_Filtrada"
        Me.lstAyuda_Filtrada.Size = New System.Drawing.Size(545, 147)
        Me.lstAyuda_Filtrada.TabIndex = 62
        Me.lstAyuda_Filtrada.Visible = False
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Proveedor"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.MaxInputLength = 11
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 65
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.DataPropertyName = "Nombre"
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        '
        'EnviarAviso
        '
        Me.EnviarAviso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EnviarAviso.DataPropertyName = "EnviarAvisoOp"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnviarAviso.DefaultCellStyle = DataGridViewCellStyle1
        Me.EnviarAviso.HeaderText = "Env. Aviso"
        Me.EnviarAviso.Name = "EnviarAviso"
        Me.EnviarAviso.ReadOnly = True
        Me.EnviarAviso.Width = 83
        '
        'ListadoCuentaCorrienteProveedoresSelectivoPrueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 469)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnLimpiarTodo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CustomButton1)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.Panel2)
        Me.Location = New System.Drawing.Point(50, 10)
        Me.Name = "ListadoCuentaCorrienteProveedoresSelectivoPrueba"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoConsultas.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtFechaEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRazon As Administracion.CustomTextBox
    Friend WithEvents txtDesdeProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents GRilla As System.Windows.Forms.DataGridView
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnCancela As Administracion.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiarTodo As Administracion.CustomButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents lstAyuda_Filtrada As Administracion.CustomListBox
    Friend WithEvents btnPantalla As Administracion.CustomButton
    Friend WithEvents btnImprimir As Administracion.CustomButton
    Friend WithEvents CustomButton1 As Administracion.CustomButton
    Friend WithEvents GrupoConsultas As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarConsulta As Administracion.CustomButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnviarAviso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
