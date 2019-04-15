<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoCuentaCorrienteProveedoresSelectivoPreparacion
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
        Me.GRilla = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaPago = New System.Windows.Forms.MaskedTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnviarAviso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.btnSalir = New Administracion.CustomButton()
        Me.btnImprimir = New Administracion.CustomButton()
        Me.btnLimpiarTodo = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnAcepta = New Administracion.CustomButton()
        Me.lstAyuda = New Administracion.CustomListBox()
        Me.txtAyuda = New Administracion.CustomTextBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtCodProveedor = New Administracion.CustomTextBox()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRilla
        '
        Me.GRilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Razon, Me.Observaciones, Me.EnviarAviso})
        Me.GRilla.Location = New System.Drawing.Point(12, 129)
        Me.GRilla.Name = "GRilla"
        Me.GRilla.RowHeadersWidth = 15
        Me.GRilla.RowTemplate.Height = 20
        Me.GRilla.Size = New System.Drawing.Size(649, 225)
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
        Me.Panel1.Size = New System.Drawing.Size(672, 50)
        Me.Panel1.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(496, 9)
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
        Me.Label1.Location = New System.Drawing.Point(33, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Proveedor a Pago Semanal"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtFechaPago)
        Me.Panel2.Controls.Add(Me.txtCodProveedor)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 313)
        Me.Panel2.TabIndex = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDesde)
        Me.GroupBox1.Controls.Add(Me.txtHasta)
        Me.GroupBox1.Controls.Add(Me.CustomLabel2)
        Me.GroupBox1.Controls.Add(Me.CustomLabel3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(337, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 62)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'txtDesde
        '
        Me.txtDesde.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesde.Enabled = False
        Me.txtDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDesde.Location = New System.Drawing.Point(58, 23)
        Me.txtDesde.Mask = "00/00/0000"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.ReadOnly = True
        Me.txtDesde.Size = New System.Drawing.Size(83, 20)
        Me.txtDesde.TabIndex = 51
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtDesde, "Fecha calculada automáticamente con respecto al Miércoles indicado")
        '
        'txtHasta
        '
        Me.txtHasta.BackColor = System.Drawing.SystemColors.Window
        Me.txtHasta.Enabled = False
        Me.txtHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtHasta.Location = New System.Drawing.Point(178, 23)
        Me.txtHasta.Mask = "00/00/0000"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.ReadOnly = True
        Me.txtHasta.Size = New System.Drawing.Size(83, 20)
        Me.txtHasta.TabIndex = 51
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtHasta, "Fecha calculada automáticamente con respecto al Miércoles indicado")
        '
        'txtFechaPago
        '
        Me.txtFechaPago.Location = New System.Drawing.Point(178, 42)
        Me.txtFechaPago.Mask = "00/00/0000"
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaPago.Size = New System.Drawing.Size(83, 20)
        Me.txtFechaPago.TabIndex = 51
        Me.txtFechaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtFechaPago, "Fecha del Miércoles en el cual se realizará el control de Pagos a Proveedores Sel" & _
                "ectivos")
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 65
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MaxInputLength = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Observaciones.Width = 150
        '
        'EnviarAviso
        '
        Me.EnviarAviso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnviarAviso.DefaultCellStyle = DataGridViewCellStyle1
        Me.EnviarAviso.HeaderText = "Env. Aviso"
        Me.EnviarAviso.Name = "EnviarAviso"
        Me.EnviarAviso.ReadOnly = True
        Me.EnviarAviso.Width = 83
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(36, 498)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(545, 147)
        Me.lstFiltrada.TabIndex = 61
        Me.lstFiltrada.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSalir.Cleanable = False
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.EnterIndex = -1
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.LabelAssociationKey = -1
        Me.btnSalir.Location = New System.Drawing.Point(412, 376)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 40)
        Me.btnSalir.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnSalir, "Salir del Formulario")
        Me.btnSalir.UseVisualStyleBackColor = True
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
        Me.btnImprimir.Location = New System.Drawing.Point(293, 376)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(87, 40)
        Me.btnImprimir.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Listado de Proveedores Ingresados")
        Me.btnImprimir.UseVisualStyleBackColor = True
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
        Me.btnLimpiarTodo.Location = New System.Drawing.Point(531, 376)
        Me.btnLimpiarTodo.Name = "btnLimpiarTodo"
        Me.btnLimpiarTodo.Size = New System.Drawing.Size(87, 40)
        Me.btnLimpiarTodo.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnLimpiarTodo, "Eliminar Seleccionados / Todos")
        Me.btnLimpiarTodo.UseVisualStyleBackColor = True
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
        Me.btnConsulta.Location = New System.Drawing.Point(174, 376)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(87, 40)
        Me.btnConsulta.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consultar Proveedores")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnAcepta
        '
        Me.btnAcepta.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAcepta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAcepta.Cleanable = False
        Me.btnAcepta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAcepta.EnterIndex = -1
        Me.btnAcepta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatAppearance.BorderSize = 0
        Me.btnAcepta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAcepta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcepta.LabelAssociationKey = -1
        Me.btnAcepta.Location = New System.Drawing.Point(55, 376)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(87, 41)
        Me.btnAcepta.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.btnAcepta, "Aceptar y Cerrar")
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(36, 498)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(545, 147)
        Me.lstAyuda.TabIndex = 54
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(36, 472)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(545, 20)
        Me.txtAyuda.TabIndex = 53
        Me.txtAyuda.Validator = Administracion.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = -1
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(23, 24)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(29, 18)
        Me.CustomLabel2.TabIndex = 50
        Me.CustomLabel2.Text = "Del"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel3.ControlAssociationKey = -1
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(151, 24)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(21, 18)
        Me.CustomLabel3.TabIndex = 50
        Me.CustomLabel3.Text = "Al"
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.Cleanable = False
        Me.txtCodProveedor.Empty = True
        Me.txtCodProveedor.EnterIndex = -1
        Me.txtCodProveedor.LabelAssociationKey = -1
        Me.txtCodProveedor.Location = New System.Drawing.Point(178, 16)
        Me.txtCodProveedor.MaxLength = 11
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.Size = New System.Drawing.Size(154, 20)
        Me.txtCodProveedor.TabIndex = 49
        Me.txtCodProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCodProveedor, "Doble Click: Abrir Consulta de Proveedores")
        Me.txtCodProveedor.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel4.ControlAssociationKey = -1
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(53, 43)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(119, 18)
        Me.CustomLabel4.TabIndex = 50
        Me.CustomLabel4.Text = "Para el Miercoles:"
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel1.ControlAssociationKey = -1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(95, 17)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(77, 18)
        Me.CustomLabel1.TabIndex = 50
        Me.CustomLabel1.Text = "Proveedor:"
        '
        'ListadoCuentaCorrienteProveedoresSelectivoPreparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 427)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnLimpiarTodo)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.txtAyuda)
        Me.Controls.Add(Me.GRilla)
        Me.Controls.Add(Me.Panel2)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "ListadoCuentaCorrienteProveedoresSelectivoPreparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.GRilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodProveedor As Administracion.CustomTextBox
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents GRilla As System.Windows.Forms.DataGridView
    Friend WithEvents lstAyuda As Administracion.CustomListBox
    Friend WithEvents txtAyuda As Administracion.CustomTextBox
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnAcepta As Administracion.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiarTodo As Administracion.CustomButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents btnImprimir As Administracion.CustomButton
    Friend WithEvents btnSalir As Administracion.CustomButton
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaPago As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnviarAviso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
