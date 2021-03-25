Imports Util

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoEspecificacionesPT
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckSubEtapas = New System.Windows.Forms.CheckBox()
        Me.AgregarRenglon = New System.Windows.Forms.Button()
        Me.btnHistorialCambios = New System.Windows.Forms.Button()
        Me.btnNotas = New System.Windows.Forms.Button()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnRevalidar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtDescEtapa = New System.Windows.Forms.TextBox()
        Me.txtTipoProceso = New System.Windows.Forms.TextBox()
        Me.txtControlCambios = New System.Windows.Forms.TextBox()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        Me.txtEtapa = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTerminado = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEtapa = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProcedimientos = New Util.DBDataGridView()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvEspecif = New Util.DBDataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvEspecifIngles = New Util.DBDataGridView()
        Me.NroRenglonIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnsayoIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecificacionIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEnsayoIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FarmacopeaIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadEspecifIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.NroRenglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEnsayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Farmacopea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesdeEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HastaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenorIgualEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InformaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic1dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic2dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic3dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoRenglon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProcedimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvEspecifIngles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(919, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(729, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(34, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(431, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO DE ESPECIFICACIONES DE PRODUCTOS TERMINADOS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckSubEtapas)
        Me.GroupBox1.Controls.Add(Me.AgregarRenglon)
        Me.GroupBox1.Controls.Add(Me.btnHistorialCambios)
        Me.GroupBox1.Controls.Add(Me.btnNotas)
        Me.GroupBox1.Controls.Add(Me.btnImpresion)
        Me.GroupBox1.Controls.Add(Me.btnConsultas)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnRevalidar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.txtDescEtapa)
        Me.GroupBox1.Controls.Add(Me.txtTipoProceso)
        Me.GroupBox1.Controls.Add(Me.txtControlCambios)
        Me.GroupBox1.Controls.Add(Me.txtDescTerminado)
        Me.GroupBox1.Controls.Add(Me.txtEtapa)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTerminado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblEtapa)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(899, 147)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'ckSubEtapas
        '
        Me.ckSubEtapas.AutoSize = True
        Me.ckSubEtapas.Location = New System.Drawing.Point(410, 126)
        Me.ckSubEtapas.Name = "ckSubEtapas"
        Me.ckSubEtapas.Size = New System.Drawing.Size(224, 17)
        Me.ckSubEtapas.TabIndex = 7
        Me.ckSubEtapas.Text = "LLEVA CONTROLES CON SUB ETAPAS"
        Me.ckSubEtapas.UseVisualStyleBackColor = True
        '
        'AgregarRenglon
        '
        Me.AgregarRenglon.Location = New System.Drawing.Point(652, 113)
        Me.AgregarRenglon.Name = "AgregarRenglon"
        Me.AgregarRenglon.Size = New System.Drawing.Size(112, 32)
        Me.AgregarRenglon.TabIndex = 6
        Me.AgregarRenglon.Text = "AGRE. RENGLON"
        Me.AgregarRenglon.UseVisualStyleBackColor = True
        '
        'btnHistorialCambios
        '
        Me.btnHistorialCambios.Location = New System.Drawing.Point(553, 37)
        Me.btnHistorialCambios.Name = "btnHistorialCambios"
        Me.btnHistorialCambios.Size = New System.Drawing.Size(81, 34)
        Me.btnHistorialCambios.TabIndex = 5
        Me.btnHistorialCambios.Text = "Historial de Cambios"
        Me.btnHistorialCambios.UseVisualStyleBackColor = True
        Me.btnHistorialCambios.Visible = False
        '
        'btnNotas
        '
        Me.btnNotas.Location = New System.Drawing.Point(511, 73)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(123, 43)
        Me.btnNotas.TabIndex = 4
        Me.btnNotas.Text = "NOTAS"
        Me.btnNotas.UseVisualStyleBackColor = True
        '
        'btnImpresion
        '
        Me.btnImpresion.Location = New System.Drawing.Point(652, 77)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(112, 32)
        Me.btnImpresion.TabIndex = 4
        Me.btnImpresion.Text = "IMPRESIÓN"
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Location = New System.Drawing.Point(652, 43)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(112, 32)
        Me.btnConsultas.TabIndex = 4
        Me.btnConsultas.Text = "CONSULTAS"
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(770, 77)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(112, 32)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnRevalidar
        '
        Me.btnRevalidar.Location = New System.Drawing.Point(770, 9)
        Me.btnRevalidar.Name = "btnRevalidar"
        Me.btnRevalidar.Size = New System.Drawing.Size(112, 32)
        Me.btnRevalidar.TabIndex = 4
        Me.btnRevalidar.Text = "REVALIDAR"
        Me.btnRevalidar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(770, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(112, 32)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(652, 9)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(112, 32)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtDescEtapa
        '
        Me.txtDescEtapa.BackColor = System.Drawing.Color.Cyan
        Me.txtDescEtapa.Location = New System.Drawing.Point(122, 96)
        Me.txtDescEtapa.MaxLength = 100
        Me.txtDescEtapa.Name = "txtDescEtapa"
        Me.txtDescEtapa.ReadOnly = True
        Me.txtDescEtapa.Size = New System.Drawing.Size(386, 20)
        Me.txtDescEtapa.TabIndex = 3
        Me.txtDescEtapa.TabStop = False
        '
        'txtTipoProceso
        '
        Me.txtTipoProceso.BackColor = System.Drawing.Color.Cyan
        Me.txtTipoProceso.Location = New System.Drawing.Point(122, 74)
        Me.txtTipoProceso.MaxLength = 100
        Me.txtTipoProceso.Name = "txtTipoProceso"
        Me.txtTipoProceso.ReadOnly = True
        Me.txtTipoProceso.Size = New System.Drawing.Size(386, 20)
        Me.txtTipoProceso.TabIndex = 3
        Me.txtTipoProceso.TabStop = False
        '
        'txtControlCambios
        '
        Me.txtControlCambios.Location = New System.Drawing.Point(122, 37)
        Me.txtControlCambios.MaxLength = 100
        Me.txtControlCambios.Multiline = True
        Me.txtControlCambios.Name = "txtControlCambios"
        Me.txtControlCambios.Size = New System.Drawing.Size(427, 33)
        Me.txtControlCambios.TabIndex = 3
        Me.txtControlCambios.Text = "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" & _
    "OOOOOOOOOOOOOOOOOOO"
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.txtDescTerminado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescTerminado.Location = New System.Drawing.Point(160, 12)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.ReadOnly = True
        Me.txtDescTerminado.Size = New System.Drawing.Size(404, 20)
        Me.txtDescTerminado.TabIndex = 2
        Me.txtDescTerminado.TabStop = False
        Me.txtDescTerminado.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'txtEtapa
        '
        Me.txtEtapa.Location = New System.Drawing.Point(610, 12)
        Me.txtEtapa.Mask = "00"
        Me.txtEtapa.Name = "txtEtapa"
        Me.txtEtapa.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtEtapa.Size = New System.Drawing.Size(24, 20)
        Me.txtEtapa.TabIndex = 2
        Me.txtEtapa.Text = "99"
        Me.txtEtapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Desc. Etapa:"
        '
        'txtTerminado
        '
        Me.txtTerminado.Location = New System.Drawing.Point(74, 12)
        Me.txtTerminado.Mask = ">LL-00000-000"
        Me.txtTerminado.Name = "txtTerminado"
        Me.txtTerminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTerminado.Size = New System.Drawing.Size(80, 20)
        Me.txtTerminado.TabIndex = 1
        Me.txtTerminado.Text = "PT99999999"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo de Proceso:"
        '
        'lblEtapa
        '
        Me.lblEtapa.AutoSize = True
        Me.lblEtapa.Location = New System.Drawing.Point(570, 16)
        Me.lblEtapa.Name = "lblEtapa"
        Me.lblEtapa.Size = New System.Drawing.Size(34, 13)
        Me.lblEtapa.TabIndex = 0
        Me.lblEtapa.Text = "Paso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Control de Cambios:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Producto:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(250, 30)
        Me.TabControl1.Location = New System.Drawing.Point(0, 202)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(919, 308)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TabControl1, "Hacer <Doble-Click> sobre la fila para definir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "los parémetros del Ensayo.")
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.dgvProcedimientos)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(911, 270)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PROCEDIMIENTOS"
        '
        'dgvProcedimientos
        '
        Me.dgvProcedimientos.AllowUserToAddRows = False
        Me.dgvProcedimientos.AllowUserToDeleteRows = False
        Me.dgvProcedimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Articulo, Me.Terminado, Me.Letra, Me.Descripcion, Me.Cantidad})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProcedimientos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProcedimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcedimientos.DoubleBuffered = True
        Me.dgvProcedimientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProcedimientos.Location = New System.Drawing.Point(3, 3)
        Me.dgvProcedimientos.Name = "dgvProcedimientos"
        Me.dgvProcedimientos.OrdenamientoColumnasHabilitado = True
        Me.dgvProcedimientos.ReadOnly = True
        Me.dgvProcedimientos.RowHeadersWidth = 10
        Me.dgvProcedimientos.RowTemplate.Height = 20
        Me.dgvProcedimientos.ShowCellToolTips = False
        Me.dgvProcedimientos.SinClickDerecho = False
        Me.dgvProcedimientos.Size = New System.Drawing.Size(905, 264)
        Me.dgvProcedimientos.TabIndex = 0
        '
        'Articulo
        '
        Me.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Width = 67
        '
        'Terminado
        '
        Me.Terminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Terminado.HeaderText = "Terminado"
        Me.Terminado.Name = "Terminado"
        Me.Terminado.ReadOnly = True
        Me.Terminado.Width = 82
        '
        'Letra
        '
        Me.Letra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle1
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 56
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 74
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.dgvEspecif)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(911, 270)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ESPECIFICACIONES"
        '
        'dgvEspecif
        '
        Me.dgvEspecif.AllowUserToAddRows = False
        Me.dgvEspecif.AllowUserToDeleteRows = False
        Me.dgvEspecif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecif.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroRenglon, Me.Ensayo, Me.Especificacion, Me.DescEnsayo, Me.Farmacopea, Me.TipoEspecif, Me.DesdeEspecif, Me.HastaEspecif, Me.UnidadEspecif, Me.MenorIgualEspecif, Me.InformaEspecif, Me.Parametro, Me.FormulaEspecif, Me.Variable1, Me.Variable2, Me.Variable3, Me.Variable4, Me.Variable5, Me.Variable6, Me.Variable7, Me.Variable8, Me.Variable9, Me.Variable10, Me.FormulaAdic1, Me.FormulaAdic2, Me.FormulaAdic3, Me.FormulaAdic1dec, Me.FormulaAdic2dec, Me.FormulaAdic3dec, Me.SegundoRenglon})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecif.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEspecif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEspecif.DoubleBuffered = True
        Me.dgvEspecif.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEspecif.Location = New System.Drawing.Point(3, 3)
        Me.dgvEspecif.Name = "dgvEspecif"
        Me.dgvEspecif.OrdenamientoColumnasHabilitado = True
        Me.dgvEspecif.RowHeadersWidth = 10
        Me.dgvEspecif.RowTemplate.Height = 20
        Me.dgvEspecif.ShowCellToolTips = False
        Me.dgvEspecif.SinClickDerecho = False
        Me.dgvEspecif.Size = New System.Drawing.Size(905, 264)
        Me.dgvEspecif.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.dgvEspecifIngles)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(911, 270)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ESPECIFICACIONES INGLÉS"
        '
        'dgvEspecifIngles
        '
        Me.dgvEspecifIngles.AllowUserToAddRows = False
        Me.dgvEspecifIngles.AllowUserToDeleteRows = False
        Me.dgvEspecifIngles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecifIngles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroRenglonIngles, Me.EnsayoIngles, Me.EspecificacionIngles, Me.DescEnsayoIngles, Me.FarmacopeaIngles, Me.UnidadEspecifIngles})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecifIngles.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEspecifIngles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEspecifIngles.DoubleBuffered = True
        Me.dgvEspecifIngles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEspecifIngles.Location = New System.Drawing.Point(0, 0)
        Me.dgvEspecifIngles.Name = "dgvEspecifIngles"
        Me.dgvEspecifIngles.OrdenamientoColumnasHabilitado = True
        Me.dgvEspecifIngles.RowHeadersWidth = 10
        Me.dgvEspecifIngles.RowTemplate.Height = 20
        Me.dgvEspecifIngles.ShowCellToolTips = False
        Me.dgvEspecifIngles.SinClickDerecho = False
        Me.dgvEspecifIngles.Size = New System.Drawing.Size(911, 270)
        Me.dgvEspecifIngles.TabIndex = 1
        '
        'NroRenglonIngles
        '
        Me.NroRenglonIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NroRenglonIngles.HeaderText = "Nro."
        Me.NroRenglonIngles.Name = "NroRenglonIngles"
        Me.NroRenglonIngles.Width = 52
        '
        'EnsayoIngles
        '
        Me.EnsayoIngles.HeaderText = "Ens."
        Me.EnsayoIngles.Name = "EnsayoIngles"
        Me.EnsayoIngles.Width = 40
        '
        'EspecificacionIngles
        '
        Me.EspecificacionIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EspecificacionIngles.HeaderText = "Descripción Ensayo"
        Me.EspecificacionIngles.MaxInputLength = 50
        Me.EspecificacionIngles.MinimumWidth = 250
        Me.EspecificacionIngles.Name = "EspecificacionIngles"
        Me.EspecificacionIngles.ReadOnly = True
        Me.EspecificacionIngles.Width = 250
        '
        'DescEnsayoIngles
        '
        Me.DescEnsayoIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescEnsayoIngles.HeaderText = "Descripción Parámetro Inglés"
        Me.DescEnsayoIngles.MaxInputLength = 70
        Me.DescEnsayoIngles.MinimumWidth = 150
        Me.DescEnsayoIngles.Name = "DescEnsayoIngles"
        '
        'FarmacopeaIngles
        '
        Me.FarmacopeaIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FarmacopeaIngles.HeaderText = "Farmacopea"
        Me.FarmacopeaIngles.MaxInputLength = 20
        Me.FarmacopeaIngles.Name = "FarmacopeaIngles"
        Me.FarmacopeaIngles.Width = 91
        '
        'UnidadEspecifIngles
        '
        Me.UnidadEspecifIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.UnidadEspecifIngles.HeaderText = "Unidad"
        Me.UnidadEspecifIngles.MaxInputLength = 20
        Me.UnidadEspecifIngles.MinimumWidth = 80
        Me.UnidadEspecifIngles.Name = "UnidadEspecifIngles"
        Me.UnidadEspecifIngles.Width = 80
        '
        'NroRenglon
        '
        Me.NroRenglon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NroRenglon.HeaderText = "Nro."
        Me.NroRenglon.MaxInputLength = 2
        Me.NroRenglon.Name = "NroRenglon"
        Me.NroRenglon.ReadOnly = True
        Me.NroRenglon.Width = 52
        '
        'Ensayo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Ensayo.HeaderText = "Ens."
        Me.Ensayo.MaxInputLength = 4
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.Width = 40
        '
        'Especificacion
        '
        Me.Especificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Especificacion.HeaderText = "Descripción Ensayo"
        Me.Especificacion.MaxInputLength = 50
        Me.Especificacion.MinimumWidth = 250
        Me.Especificacion.Name = "Especificacion"
        Me.Especificacion.ReadOnly = True
        Me.Especificacion.Width = 250
        '
        'DescEnsayo
        '
        Me.DescEnsayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescEnsayo.HeaderText = "Descripción Parámetro"
        Me.DescEnsayo.MaxInputLength = 100
        Me.DescEnsayo.MinimumWidth = 150
        Me.DescEnsayo.Name = "DescEnsayo"
        Me.DescEnsayo.ReadOnly = True
        '
        'Farmacopea
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Farmacopea.DefaultCellStyle = DataGridViewCellStyle5
        Me.Farmacopea.HeaderText = "Farmacopea"
        Me.Farmacopea.MaxInputLength = 20
        Me.Farmacopea.Name = "Farmacopea"
        Me.Farmacopea.ReadOnly = True
        Me.Farmacopea.Width = 75
        '
        'TipoEspecif
        '
        Me.TipoEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TipoEspecif.HeaderText = "TipoEspecif"
        Me.TipoEspecif.Name = "TipoEspecif"
        Me.TipoEspecif.ReadOnly = True
        Me.TipoEspecif.Visible = False
        Me.TipoEspecif.Width = 88
        '
        'DesdeEspecif
        '
        Me.DesdeEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DesdeEspecif.HeaderText = "DesdeEspecif"
        Me.DesdeEspecif.Name = "DesdeEspecif"
        Me.DesdeEspecif.ReadOnly = True
        Me.DesdeEspecif.Visible = False
        Me.DesdeEspecif.Width = 98
        '
        'HastaEspecif
        '
        Me.HastaEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.HastaEspecif.HeaderText = "HastaEspecif"
        Me.HastaEspecif.Name = "HastaEspecif"
        Me.HastaEspecif.ReadOnly = True
        Me.HastaEspecif.Visible = False
        Me.HastaEspecif.Width = 95
        '
        'UnidadEspecif
        '
        Me.UnidadEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.UnidadEspecif.HeaderText = "UnidadEspecif"
        Me.UnidadEspecif.Name = "UnidadEspecif"
        Me.UnidadEspecif.ReadOnly = True
        Me.UnidadEspecif.Visible = False
        Me.UnidadEspecif.Width = 101
        '
        'MenorIgualEspecif
        '
        Me.MenorIgualEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MenorIgualEspecif.HeaderText = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Name = "MenorIgualEspecif"
        Me.MenorIgualEspecif.ReadOnly = True
        Me.MenorIgualEspecif.Visible = False
        Me.MenorIgualEspecif.Width = 120
        '
        'InformaEspecif
        '
        Me.InformaEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InformaEspecif.HeaderText = "InformaEspecif"
        Me.InformaEspecif.Name = "InformaEspecif"
        Me.InformaEspecif.ReadOnly = True
        Me.InformaEspecif.Visible = False
        Me.InformaEspecif.Width = 102
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Parametro.HeaderText = "Parametro"
        Me.Parametro.MaxInputLength = 50
        Me.Parametro.MinimumWidth = 150
        Me.Parametro.Name = "Parametro"
        Me.Parametro.ReadOnly = True
        Me.Parametro.Width = 150
        '
        'FormulaEspecif
        '
        Me.FormulaEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FormulaEspecif.HeaderText = "FormulaEspecif"
        Me.FormulaEspecif.Name = "FormulaEspecif"
        Me.FormulaEspecif.ReadOnly = True
        Me.FormulaEspecif.Visible = False
        Me.FormulaEspecif.Width = 104
        '
        'Variable1
        '
        Me.Variable1.HeaderText = "Variable1"
        Me.Variable1.Name = "Variable1"
        Me.Variable1.ReadOnly = True
        Me.Variable1.Visible = False
        '
        'Variable2
        '
        Me.Variable2.HeaderText = "Variable2"
        Me.Variable2.Name = "Variable2"
        Me.Variable2.ReadOnly = True
        Me.Variable2.Visible = False
        '
        'Variable3
        '
        Me.Variable3.HeaderText = "Variable3"
        Me.Variable3.Name = "Variable3"
        Me.Variable3.ReadOnly = True
        Me.Variable3.Visible = False
        '
        'Variable4
        '
        Me.Variable4.HeaderText = "Variable4"
        Me.Variable4.Name = "Variable4"
        Me.Variable4.ReadOnly = True
        Me.Variable4.Visible = False
        '
        'Variable5
        '
        Me.Variable5.HeaderText = "Variable5"
        Me.Variable5.Name = "Variable5"
        Me.Variable5.ReadOnly = True
        Me.Variable5.Visible = False
        '
        'Variable6
        '
        Me.Variable6.HeaderText = "Variable6"
        Me.Variable6.Name = "Variable6"
        Me.Variable6.ReadOnly = True
        Me.Variable6.Visible = False
        '
        'Variable7
        '
        Me.Variable7.HeaderText = "Variable7"
        Me.Variable7.Name = "Variable7"
        Me.Variable7.ReadOnly = True
        Me.Variable7.Visible = False
        '
        'Variable8
        '
        Me.Variable8.HeaderText = "Variable8"
        Me.Variable8.Name = "Variable8"
        Me.Variable8.ReadOnly = True
        Me.Variable8.Visible = False
        '
        'Variable9
        '
        Me.Variable9.HeaderText = "Variable9"
        Me.Variable9.Name = "Variable9"
        Me.Variable9.ReadOnly = True
        Me.Variable9.Visible = False
        '
        'Variable10
        '
        Me.Variable10.HeaderText = "Variable10"
        Me.Variable10.Name = "Variable10"
        Me.Variable10.ReadOnly = True
        Me.Variable10.Visible = False
        '
        'FormulaAdic1
        '
        Me.FormulaAdic1.DataPropertyName = "FormulaAdic1"
        Me.FormulaAdic1.HeaderText = "FormulaAdic1"
        Me.FormulaAdic1.Name = "FormulaAdic1"
        Me.FormulaAdic1.ReadOnly = True
        Me.FormulaAdic1.Visible = False
        '
        'FormulaAdic2
        '
        Me.FormulaAdic2.DataPropertyName = "FormulaAdic2"
        Me.FormulaAdic2.HeaderText = "FormulaAdic2"
        Me.FormulaAdic2.Name = "FormulaAdic2"
        Me.FormulaAdic2.ReadOnly = True
        Me.FormulaAdic2.Visible = False
        '
        'FormulaAdic3
        '
        Me.FormulaAdic3.DataPropertyName = "FormulaAdic3"
        Me.FormulaAdic3.HeaderText = "FormulaAdic3"
        Me.FormulaAdic3.Name = "FormulaAdic3"
        Me.FormulaAdic3.ReadOnly = True
        Me.FormulaAdic3.Visible = False
        '
        'FormulaAdic1dec
        '
        Me.FormulaAdic1dec.HeaderText = "FormulaAdic1dec"
        Me.FormulaAdic1dec.Name = "FormulaAdic1dec"
        Me.FormulaAdic1dec.ReadOnly = True
        Me.FormulaAdic1dec.Visible = False
        '
        'FormulaAdic2dec
        '
        Me.FormulaAdic2dec.HeaderText = "FormulaAdic2dec"
        Me.FormulaAdic2dec.Name = "FormulaAdic2dec"
        Me.FormulaAdic2dec.ReadOnly = True
        Me.FormulaAdic2dec.Visible = False
        '
        'FormulaAdic3dec
        '
        Me.FormulaAdic3dec.HeaderText = "FormulaAdic3dec"
        Me.FormulaAdic3dec.Name = "FormulaAdic3dec"
        Me.FormulaAdic3dec.ReadOnly = True
        Me.FormulaAdic3dec.Visible = False
        '
        'SegundoRenglon
        '
        Me.SegundoRenglon.HeaderText = "SegundoRenglon"
        Me.SegundoRenglon.Name = "SegundoRenglon"
        Me.SegundoRenglon.ReadOnly = True
        Me.SegundoRenglon.Visible = False
        '
        'IngresoEspecificacionesPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 510)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IngresoEspecificacionesPT"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvProcedimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvEspecifIngles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTerminado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
    Friend WithEvents txtEtapa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblEtapa As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtControlCambios As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoProceso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents btnConsultas As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnRevalidar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvProcedimientos As DBDataGridView
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dgvEspecif As DBDataGridView
    Friend WithEvents btnNotas As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvEspecifIngles As Util.DBDataGridView
    Friend WithEvents txtDescEtapa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnHistorialCambios As System.Windows.Forms.Button
    Friend WithEvents AgregarRenglon As System.Windows.Forms.Button
    Friend WithEvents ckSubEtapas As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents NroRenglonIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnsayoIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EspecificacionIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEnsayoIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FarmacopeaIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadEspecifIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroRenglon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEnsayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Farmacopea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesdeEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HastaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenorIgualEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InformaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variable10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic1dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic2dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic3dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoRenglon As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
