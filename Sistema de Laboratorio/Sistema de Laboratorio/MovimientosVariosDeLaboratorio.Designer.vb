<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosVariosDeLaboratorio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNroMovimiento = New System.Windows.Forms.TextBox()
        Me.cbxTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cbxMP = New System.Windows.Forms.ComboBox()
        Me.mastxtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtES = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlContra = New System.Windows.Forms.Panel()
        Me.btnpnlVolver = New System.Windows.Forms.Button()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnpnlAyudaVolver = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DGV_Ayuda = New ConsultasVarias.DBDataGridView()
        Me.CodigoAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxAyuda = New System.Windows.Forms.ComboBox()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.DGV_Movimientos = New ConsultasVarias.DBDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdTerminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MateriaPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnlContra.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Movimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNroMovimiento
        '
        Me.txtNroMovimiento.Location = New System.Drawing.Point(94, 57)
        Me.txtNroMovimiento.MaxLength = 6
        Me.txtNroMovimiento.Name = "txtNroMovimiento"
        Me.txtNroMovimiento.Size = New System.Drawing.Size(51, 20)
        Me.txtNroMovimiento.TabIndex = 0
        Me.txtNroMovimiento.Text = "999999"
        Me.txtNroMovimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxTipoMovimiento
        '
        Me.cbxTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoMovimiento.FormattingEnabled = True
        Me.cbxTipoMovimiento.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cbxTipoMovimiento.Location = New System.Drawing.Point(446, 57)
        Me.cbxTipoMovimiento.Name = "cbxTipoMovimiento"
        Me.cbxTipoMovimiento.Size = New System.Drawing.Size(142, 21)
        Me.cbxTipoMovimiento.TabIndex = 2
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(117, 84)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(710, 20)
        Me.txtObservaciones.TabIndex = 3
        '
        'cbxMP
        '
        Me.cbxMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMP.FormattingEnabled = True
        Me.cbxMP.Items.AddRange(New Object() {"M", "T"})
        Me.cbxMP.Location = New System.Drawing.Point(12, 388)
        Me.cbxMP.Name = "cbxMP"
        Me.cbxMP.Size = New System.Drawing.Size(39, 21)
        Me.cbxMP.TabIndex = 5
        '
        'mastxtCodigo
        '
        Me.mastxtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mastxtCodigo.Location = New System.Drawing.Point(59, 388)
        Me.mastxtCodigo.Name = "mastxtCodigo"
        Me.mastxtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtCodigo.Size = New System.Drawing.Size(86, 20)
        Me.mastxtCodigo.TabIndex = 6
        Me.mastxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(153, 388)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(470, 20)
        Me.txtDescripcion.TabIndex = 7
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(631, 388)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(96, 20)
        Me.txtCantidad.TabIndex = 8
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtES
        '
        Me.txtES.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtES.Enabled = False
        Me.txtES.Location = New System.Drawing.Point(735, 388)
        Me.txtES.Name = "txtES"
        Me.txtES.Size = New System.Drawing.Size(28, 20)
        Me.txtES.TabIndex = 9
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(771, 388)
        Me.txtLote.MaxLength = 6
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(60, 20)
        Me.txtLote.TabIndex = 10
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(58, 418)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(157, 41)
        Me.btnGrabar.TabIndex = 11
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(247, 418)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(157, 42)
        Me.btnLimpiar.TabIndex = 12
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnAyuda
        '
        Me.btnAyuda.Location = New System.Drawing.Point(436, 417)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(157, 41)
        Me.btnAyuda.TabIndex = 13
        Me.btnAyuda.Text = "AYUDA"
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(625, 416)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(157, 41)
        Me.btnVolver.TabIndex = 14
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "MOVIMIENTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "FECHA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "TIPO MOVIMIENTO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "OBSERVACIONES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "M/P"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 369)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Materia Prima          "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(154, 369)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "DESCRIPCIÓN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(630, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "CANTIDAD"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(737, 369)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "E/S"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(773, 369)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "LOTE"
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(222, 57)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(71, 20)
        Me.mastxtFecha.TabIndex = 1
        Me.mastxtFecha.Text = "99999999"
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 50)
        Me.Panel1.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(25, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 18)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Movimientos Varios de Laboratorio"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(663, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(155, 20)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "SURFACTAN S.A."
        '
        'pnlContra
        '
        Me.pnlContra.Controls.Add(Me.btnpnlVolver)
        Me.pnlContra.Controls.Add(Me.txtContrasena)
        Me.pnlContra.Controls.Add(Me.Panel3)
        Me.pnlContra.Location = New System.Drawing.Point(271, 186)
        Me.pnlContra.Name = "pnlContra"
        Me.pnlContra.Size = New System.Drawing.Size(225, 127)
        Me.pnlContra.TabIndex = 26
        '
        'btnpnlVolver
        '
        Me.btnpnlVolver.Location = New System.Drawing.Point(76, 95)
        Me.btnpnlVolver.Name = "btnpnlVolver"
        Me.btnpnlVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnpnlVolver.TabIndex = 2
        Me.btnpnlVolver.Text = "Volver"
        Me.btnpnlVolver.UseVisualStyleBackColor = True
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(34, 64)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(165, 20)
        Me.txtContrasena.TabIndex = 1
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(225, 52)
        Me.Panel3.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(33, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 20)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Ingrese Contraseña"
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnpnlAyudaVolver)
        Me.pnlAyuda.Controls.Add(Me.Label15)
        Me.pnlAyuda.Controls.Add(Me.DGV_Ayuda)
        Me.pnlAyuda.Controls.Add(Me.cbxAyuda)
        Me.pnlAyuda.Controls.Add(Me.txtAyuda)
        Me.pnlAyuda.Location = New System.Drawing.Point(211, 113)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(403, 245)
        Me.pnlAyuda.TabIndex = 27
        '
        'btnpnlAyudaVolver
        '
        Me.btnpnlAyudaVolver.Location = New System.Drawing.Point(142, 208)
        Me.btnpnlAyudaVolver.Name = "btnpnlAyudaVolver"
        Me.btnpnlAyudaVolver.Size = New System.Drawing.Size(119, 32)
        Me.btnpnlAyudaVolver.TabIndex = 5
        Me.btnpnlAyudaVolver.Text = "CERRAR"
        Me.btnpnlAyudaVolver.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(64, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Que desea buscar :"
        '
        'DGV_Ayuda
        '
        Me.DGV_Ayuda.AllowUserToAddRows = False
        Me.DGV_Ayuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ayuda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoAyuda, Me.DescripcionAyuda})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Ayuda.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Ayuda.DoubleBuffered = True
        Me.DGV_Ayuda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Ayuda.Location = New System.Drawing.Point(11, 74)
        Me.DGV_Ayuda.Name = "DGV_Ayuda"
        Me.DGV_Ayuda.OrdenamientoColumnasHabilitado = True
        Me.DGV_Ayuda.RowHeadersWidth = 15
        Me.DGV_Ayuda.RowTemplate.Height = 20
        Me.DGV_Ayuda.ShowCellToolTips = False
        Me.DGV_Ayuda.SinClickDerecho = False
        Me.DGV_Ayuda.Size = New System.Drawing.Size(381, 130)
        Me.DGV_Ayuda.TabIndex = 3
        '
        'CodigoAyuda
        '
        Me.CodigoAyuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoAyuda.DataPropertyName = "CodigoAyuda"
        Me.CodigoAyuda.HeaderText = "Codigo"
        Me.CodigoAyuda.Name = "CodigoAyuda"
        Me.CodigoAyuda.Width = 65
        '
        'DescripcionAyuda
        '
        Me.DescripcionAyuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionAyuda.DataPropertyName = "DescripcionAyuda"
        Me.DescripcionAyuda.HeaderText = "Descripcion"
        Me.DescripcionAyuda.Name = "DescripcionAyuda"
        '
        'cbxAyuda
        '
        Me.cbxAyuda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAyuda.FormattingEnabled = True
        Me.cbxAyuda.Items.AddRange(New Object() {"Materia Prima", "Producto Terminado"})
        Me.cbxAyuda.Location = New System.Drawing.Point(170, 17)
        Me.cbxAyuda.Name = "cbxAyuda"
        Me.cbxAyuda.Size = New System.Drawing.Size(168, 21)
        Me.cbxAyuda.TabIndex = 2
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(11, 48)
        Me.txtAyuda.MaxLength = 100
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(381, 20)
        Me.txtAyuda.TabIndex = 1
        '
        'DGV_Movimientos
        '
        Me.DGV_Movimientos.AllowUserToAddRows = False
        Me.DGV_Movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Movimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.ProdTerminado, Me.MateriaPrima, Me.Descripcion, Me.Cantidad, Me.Movimiento, Me.Lote})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Movimientos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Movimientos.DoubleBuffered = True
        Me.DGV_Movimientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Movimientos.Location = New System.Drawing.Point(12, 119)
        Me.DGV_Movimientos.Name = "DGV_Movimientos"
        Me.DGV_Movimientos.OrdenamientoColumnasHabilitado = True
        Me.DGV_Movimientos.RowHeadersWidth = 15
        Me.DGV_Movimientos.RowTemplate.Height = 20
        Me.DGV_Movimientos.ShowCellToolTips = False
        Me.DGV_Movimientos.SinClickDerecho = False
        Me.DGV_Movimientos.Size = New System.Drawing.Size(815, 244)
        Me.DGV_Movimientos.TabIndex = 4
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 53
        '
        'ProdTerminado
        '
        Me.ProdTerminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ProdTerminado.HeaderText = "Prod.Terminado"
        Me.ProdTerminado.Name = "ProdTerminado"
        Me.ProdTerminado.Width = 107
        '
        'MateriaPrima
        '
        Me.MateriaPrima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MateriaPrima.HeaderText = "M.Prima"
        Me.MateriaPrima.Name = "MateriaPrima"
        Me.MateriaPrima.Width = 70
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Movimiento
        '
        Me.Movimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Movimiento.HeaderText = "Movimiento"
        Me.Movimiento.Name = "Movimiento"
        Me.Movimiento.Width = 86
        '
        'Lote
        '
        Me.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Width = 53
        '
        'MovimientosVariosDeLaboratorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 469)
        Me.Controls.Add(Me.pnlAyuda)
        Me.Controls.Add(Me.pnlContra)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAyuda)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.txtES)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.mastxtCodigo)
        Me.Controls.Add(Me.cbxMP)
        Me.Controls.Add(Me.DGV_Movimientos)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.cbxTipoMovimiento)
        Me.Controls.Add(Me.txtNroMovimiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MovimientosVariosDeLaboratorio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlContra.ResumeLayout(False)
        Me.pnlContra.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Movimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNroMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents cbxTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents DGV_Movimientos As ConsultasVarias.DBDataGridView
    Friend WithEvents cbxMP As System.Windows.Forms.ComboBox
    Friend WithEvents mastxtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtES As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdTerminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MateriaPrima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Movimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlContra As System.Windows.Forms.Panel
    Friend WithEvents btnpnlVolver As System.Windows.Forms.Button
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlAyuda As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DGV_Ayuda As ConsultasVarias.DBDataGridView
    Friend WithEvents cbxAyuda As System.Windows.Forms.ComboBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents btnpnlAyudaVolver As System.Windows.Forms.Button
    Friend WithEvents CodigoAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
