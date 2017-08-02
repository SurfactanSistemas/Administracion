<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibosProvisorios
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridRecibos = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optVarios = New System.Windows.Forms.RadioButton()
        Me.optAnticipos = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.CustomLabel10 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.lblTotal = New Administracion.CustomLabel()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtConsulta = New Administracion.CustomTextBox()
        Me.txtRecibo = New Administracion.CustomTextBox()
        Me.txtCliente = New Administracion.CustomTextBox()
        Me.txtNombre = New Administracion.CustomTextBox()
        Me.txtRetGanancias = New Administracion.CustomTextBox()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.txtRetIva = New Administracion.CustomTextBox()
        Me.txtTotal = New Administracion.CustomTextBox()
        Me.txtRetIB = New Administracion.CustomTextBox()
        Me.CustomLabel8 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.CustomLabel9 = New Administracion.CustomLabel()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.txtParidad = New Administracion.CustomTextBox()
        Me.txtRetSuss = New Administracion.CustomTextBox()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnIntereses = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.btnEliminar = New Administracion.CustomButton()
        CType(Me.gridRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridRecibos
        '
        Me.gridRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridRecibos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRecibos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.numero, Me.fecha, Me.banco, Me.importe})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridRecibos.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridRecibos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridRecibos.Location = New System.Drawing.Point(18, 179)
        Me.gridRecibos.Name = "gridRecibos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridRecibos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridRecibos.Size = New System.Drawing.Size(756, 363)
        Me.gridRecibos.TabIndex = 13
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tipo.FillWeight = 80.0!
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.MaxInputLength = 31
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 53
        '
        'numero
        '
        Me.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero.FillWeight = 120.0!
        Me.numero.HeaderText = "Numero/Cta"
        Me.numero.MaxInputLength = 8
        Me.numero.Name = "numero"
        Me.numero.Width = 170
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.fecha.FillWeight = 120.0!
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.MaxInputLength = 10
        Me.fecha.Name = "fecha"
        Me.fecha.Width = 110
        '
        'banco
        '
        Me.banco.FillWeight = 150.0!
        Me.banco.HeaderText = "Banco"
        Me.banco.MaxInputLength = 20
        Me.banco.Name = "banco"
        '
        'importe
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.importe.FillWeight = 80.0!
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 50)
        Me.Panel1.TabIndex = 119
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(617, 9)
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
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Recibos Provisorios"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtFechaAux)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.CustomLabel10)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.txtConsulta)
        Me.Panel2.Controls.Add(Me.txtRecibo)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.gridRecibos)
        Me.Panel2.Controls.Add(Me.txtRetGanancias)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.txtRetIva)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.txtRetIB)
        Me.Panel2.Controls.Add(Me.CustomLabel8)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.CustomLabel9)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Controls.Add(Me.txtParidad)
        Me.Panel2.Controls.Add(Me.txtRetSuss)
        Me.Panel2.Controls.Add(Me.lstFiltrada)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(793, 579)
        Me.Panel2.TabIndex = 120
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaAux.Location = New System.Drawing.Point(337, 268)
        Me.txtFechaAux.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.MaximumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.MinimumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(60, 13)
        Me.txtFechaAux.TabIndex = 123
        Me.txtFechaAux.ValidatingType = GetType(Date)
        Me.txtFechaAux.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(316, 7)
        Me.txtFecha.Mask = "##/##/####"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(81, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optVarios)
        Me.GroupBox1.Controls.Add(Me.optAnticipos)
        Me.GroupBox1.Controls.Add(Me.optCtaCte)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(18, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 41)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Location = New System.Drawing.Point(257, 14)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(64, 22)
        Me.optVarios.TabIndex = 2
        Me.optVarios.Text = "Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Location = New System.Drawing.Point(168, 14)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(84, 22)
        Me.optAnticipos.TabIndex = 1
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Location = New System.Drawing.Point(42, 12)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(118, 22)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Cobro Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(42, 8)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(80, 18)
        Me.CustomLabel1.TabIndex = 0
        Me.CustomLabel1.Text = "Nro. Recibo"
        '
        'CustomLabel10
        '
        Me.CustomLabel10.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel10.ControlAssociationKey = -1
        Me.CustomLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel10.Location = New System.Drawing.Point(210, 545)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(412, 22)
        Me.CustomLabel10.TabIndex = 118
        Me.CustomLabel10.Text = "Tipo Doc.: 1) Ef. 2) Ch. 3) Doc. 4) Varios "
        Me.CustomLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 3
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(38, 34)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(84, 18)
        Me.CustomLabel2.TabIndex = 1
        Me.CustomLabel2.Text = "Cod. Cliente"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ControlAssociationKey = -1
        Me.lblTotal.Location = New System.Drawing.Point(628, 545)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(146, 22)
        Me.lblTotal.TabIndex = 74
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(404, 8)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(370, 134)
        Me.lstSeleccion.TabIndex = 78
        Me.lstSeleccion.Visible = False
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 2
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(266, 8)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(44, 18)
        Me.CustomLabel3.TabIndex = 3
        Me.CustomLabel3.Text = "Fecha"
        '
        'txtConsulta
        '
        Me.txtConsulta.Cleanable = False
        Me.txtConsulta.Empty = True
        Me.txtConsulta.EnterIndex = -1
        Me.txtConsulta.LabelAssociationKey = -1
        Me.txtConsulta.Location = New System.Drawing.Point(403, 12)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(370, 20)
        Me.txtConsulta.TabIndex = 77
        Me.txtConsulta.Validator = Administracion.ValidatorType.None
        Me.txtConsulta.Visible = False
        '
        'txtRecibo
        '
        Me.txtRecibo.Cleanable = True
        Me.txtRecibo.Empty = False
        Me.txtRecibo.EnterIndex = 1
        Me.txtRecibo.LabelAssociationKey = 1
        Me.txtRecibo.Location = New System.Drawing.Point(128, 7)
        Me.txtRecibo.MaxLength = 6
        Me.txtRecibo.Name = "txtRecibo"
        Me.txtRecibo.Size = New System.Drawing.Size(87, 20)
        Me.txtRecibo.TabIndex = 0
        Me.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRecibo.Validator = Administracion.ValidatorType.Numeric
        '
        'txtCliente
        '
        Me.txtCliente.Cleanable = True
        Me.txtCliente.Empty = False
        Me.txtCliente.EnterIndex = 3
        Me.txtCliente.LabelAssociationKey = 3
        Me.txtCliente.Location = New System.Drawing.Point(128, 33)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(87, 20)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Doble Click: Abrir Consulta de Clientes")
        Me.txtCliente.Validator = Administracion.ValidatorType.None
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = True
        Me.txtNombre.Empty = False
        Me.txtNombre.Enabled = False
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = 3
        Me.txtNombre.Location = New System.Drawing.Point(221, 33)
        Me.txtNombre.MaxLength = 1000
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(176, 20)
        Me.txtNombre.TabIndex = 12
        Me.txtNombre.Validator = Administracion.ValidatorType.None
        '
        'txtRetGanancias
        '
        Me.txtRetGanancias.Cleanable = True
        Me.txtRetGanancias.Empty = False
        Me.txtRetGanancias.EnterIndex = 4
        Me.txtRetGanancias.LabelAssociationKey = 4
        Me.txtRetGanancias.Location = New System.Drawing.Point(128, 59)
        Me.txtRetGanancias.Name = "txtRetGanancias"
        Me.txtRetGanancias.Size = New System.Drawing.Size(87, 20)
        Me.txtRetGanancias.TabIndex = 3
        Me.txtRetGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetGanancias.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 4
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(23, 60)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel4.TabIndex = 15
        Me.CustomLabel4.Text = "Ret. Ganancias"
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 6
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(65, 86)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(57, 18)
        Me.CustomLabel5.TabIndex = 16
        Me.CustomLabel5.Text = "Ret. IVA"
        '
        'txtRetIva
        '
        Me.txtRetIva.Cleanable = True
        Me.txtRetIva.Empty = False
        Me.txtRetIva.EnterIndex = 6
        Me.txtRetIva.LabelAssociationKey = 6
        Me.txtRetIva.Location = New System.Drawing.Point(128, 85)
        Me.txtRetIva.Name = "txtRetIva"
        Me.txtRetIva.Size = New System.Drawing.Size(87, 20)
        Me.txtRetIva.TabIndex = 17
        Me.txtRetIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIva.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtTotal
        '
        Me.txtTotal.Cleanable = True
        Me.txtTotal.Empty = False
        Me.txtTotal.EnterIndex = 8
        Me.txtTotal.LabelAssociationKey = 9
        Me.txtTotal.Location = New System.Drawing.Point(643, 153)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtTotal.TabIndex = 25
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtRetIB
        '
        Me.txtRetIB.Cleanable = True
        Me.txtRetIB.Empty = False
        Me.txtRetIB.EnterIndex = 5
        Me.txtRetIB.LabelAssociationKey = 5
        Me.txtRetIB.Location = New System.Drawing.Point(294, 58)
        Me.txtRetIB.Name = "txtRetIB"
        Me.txtRetIB.ReadOnly = True
        Me.txtRetIB.Size = New System.Drawing.Size(103, 20)
        Me.txtRetIB.TabIndex = 18
        Me.txtRetIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIB.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel8
        '
        Me.CustomLabel8.AutoSize = True
        Me.CustomLabel8.ControlAssociationKey = 9
        Me.CustomLabel8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel8.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel8.Location = New System.Drawing.Point(554, 154)
        Me.CustomLabel8.Name = "CustomLabel8"
        Me.CustomLabel8.Size = New System.Drawing.Size(83, 18)
        Me.CustomLabel8.TabIndex = 24
        Me.CustomLabel8.Text = "Total Recibo"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 5
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(234, 59)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(56, 18)
        Me.CustomLabel7.TabIndex = 19
        Me.CustomLabel7.Text = "Ret. I.B."
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 8
        Me.CustomLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel9.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel9.Location = New System.Drawing.Point(67, 112)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(55, 18)
        Me.CustomLabel9.TabIndex = 23
        Me.CustomLabel9.Text = "Paridad"
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 7
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(223, 85)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(67, 18)
        Me.CustomLabel6.TabIndex = 20
        Me.CustomLabel6.Text = "Ret. Suss."
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = -1
        Me.txtParidad.LabelAssociationKey = 8
        Me.txtParidad.Location = New System.Drawing.Point(128, 111)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(87, 20)
        Me.txtParidad.TabIndex = 22
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtParidad.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtRetSuss
        '
        Me.txtRetSuss.Cleanable = True
        Me.txtRetSuss.Empty = False
        Me.txtRetSuss.EnterIndex = 7
        Me.txtRetSuss.LabelAssociationKey = 7
        Me.txtRetSuss.Location = New System.Drawing.Point(294, 84)
        Me.txtRetSuss.Name = "txtRetSuss"
        Me.txtRetSuss.Size = New System.Drawing.Size(103, 20)
        Me.txtRetSuss.TabIndex = 21
        Me.txtRetSuss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetSuss.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(404, 33)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(370, 108)
        Me.lstFiltrada.TabIndex = 122
        Me.lstFiltrada.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = False
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(403, 33)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(370, 108)
        Me.lstConsulta.TabIndex = 76
        Me.lstConsulta.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(623, 644)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 44)
        Me.btnLimpiar.TabIndex = 125
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(518, 644)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(69, 44)
        Me.btnCerrar.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnIntereses
        '
        Me.btnIntereses.BackgroundImage = Global.Administracion.My.Resources.Resources.calculadora
        Me.btnIntereses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnIntereses.Cleanable = False
        Me.btnIntereses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIntereses.EnterIndex = -1
        Me.btnIntereses.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.BorderSize = 0
        Me.btnIntereses.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIntereses.LabelAssociationKey = -1
        Me.btnIntereses.Location = New System.Drawing.Point(413, 644)
        Me.btnIntereses.Name = "btnIntereses"
        Me.btnIntereses.Size = New System.Drawing.Size(69, 44)
        Me.btnIntereses.TabIndex = 123
        Me.ToolTip1.SetToolTip(Me.btnIntereses, "Intereses")
        Me.btnIntereses.UseVisualStyleBackColor = True
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
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(308, 644)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(69, 44)
        Me.btnConsulta.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(98, 644)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 44)
        Me.btnAgregar.TabIndex = 121
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.Administracion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminar.Cleanable = False
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.EnterIndex = -1
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.LabelAssociationKey = -1
        Me.btnEliminar.Location = New System.Drawing.Point(203, 644)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 44)
        Me.btnEliminar.TabIndex = 122
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar el Recibo Provisorio Actual")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'RecibosProvisorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 702)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnIntereses)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "RecibosProvisorios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.gridRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents txtRecibo As Administracion.CustomTextBox
    Friend WithEvents txtCliente As Administracion.CustomTextBox
    Friend WithEvents txtNombre As Administracion.CustomTextBox
    Friend WithEvents gridRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents txtRetGanancias As Administracion.CustomTextBox
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents txtRetIva As Administracion.CustomTextBox
    Friend WithEvents txtRetSuss As Administracion.CustomTextBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtRetIB As Administracion.CustomTextBox
    Friend WithEvents txtTotal As Administracion.CustomTextBox
    Friend WithEvents CustomLabel8 As Administracion.CustomLabel
    Friend WithEvents CustomLabel9 As Administracion.CustomLabel
    Friend WithEvents txtParidad As Administracion.CustomTextBox
    Friend WithEvents lblTotal As Administracion.CustomLabel
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents txtConsulta As Administracion.CustomTextBox
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents CustomLabel10 As Administracion.CustomLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnIntereses As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optVarios As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipos As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnEliminar As Administracion.CustomButton
End Class
