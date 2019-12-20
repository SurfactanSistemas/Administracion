Imports ConsultasVarias

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoEspecificacionesMP
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnHistorialCambios = New System.Windows.Forms.Button()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtControlCambios = New System.Windows.Forms.TextBox()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvEspecif = New ConsultasVarias.DBDataGridView()
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
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvEspecifIngles = New ConsultasVarias.DBDataGridView()
        Me.EnsayoIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecificacionIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEnsayoIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FarmacopeaIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadEspecifIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCondicionMuestreo = New System.Windows.Forms.TextBox()
        Me.txtDescIngles = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCas = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(376, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO DE ESPECIFICACIONES DE MATERIAS PRIMAS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCas)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtVersion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtOperador)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnHistorialCambios)
        Me.GroupBox1.Controls.Add(Me.btnImpresion)
        Me.GroupBox1.Controls.Add(Me.btnConsultas)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.txtCondicionMuestreo)
        Me.GroupBox1.Controls.Add(Me.txtControlCambios)
        Me.GroupBox1.Controls.Add(Me.txtDescIngles)
        Me.GroupBox1.Controls.Add(Me.txtDescTerminado)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(899, 133)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnHistorialCambios
        '
        Me.btnHistorialCambios.Location = New System.Drawing.Point(652, 62)
        Me.btnHistorialCambios.Name = "btnHistorialCambios"
        Me.btnHistorialCambios.Size = New System.Drawing.Size(112, 30)
        Me.btnHistorialCambios.TabIndex = 5
        Me.btnHistorialCambios.Text = "Historial de Cambios"
        Me.btnHistorialCambios.UseVisualStyleBackColor = True
        Me.btnHistorialCambios.Visible = False
        '
        'btnImpresion
        '
        Me.btnImpresion.Location = New System.Drawing.Point(770, 63)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(112, 28)
        Me.btnImpresion.TabIndex = 4
        Me.btnImpresion.Text = "IMPRESIÓN"
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnConsultas
        '
        Me.btnConsultas.Location = New System.Drawing.Point(652, 34)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(112, 28)
        Me.btnConsultas.TabIndex = 4
        Me.btnConsultas.Text = "CONSULTAS"
        Me.btnConsultas.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(770, 34)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(112, 28)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(770, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(112, 24)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(652, 9)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(112, 24)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtControlCambios
        '
        Me.txtControlCambios.Location = New System.Drawing.Point(142, 59)
        Me.txtControlCambios.MaxLength = 100
        Me.txtControlCambios.Multiline = True
        Me.txtControlCambios.Name = "txtControlCambios"
        Me.txtControlCambios.Size = New System.Drawing.Size(492, 33)
        Me.txtControlCambios.TabIndex = 3
        Me.txtControlCambios.Text = "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" & _
    "OOOOOOOOOOOOOOOOOOO"
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.BackColor = System.Drawing.Color.Cyan
        Me.txtDescTerminado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescTerminado.Location = New System.Drawing.Point(142, 12)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.ReadOnly = True
        Me.txtDescTerminado.Size = New System.Drawing.Size(492, 20)
        Me.txtDescTerminado.TabIndex = 2
        Me.txtDescTerminado.TabStop = False
        Me.txtDescTerminado.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(74, 12)
        Me.txtCodigo.Mask = ">LL-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(64, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "AA000000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 66)
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
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Código:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(250, 30)
        Me.TabControl1.Location = New System.Drawing.Point(0, 186)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(919, 324)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TabControl1, "Hacer <Doble-Click> sobre la fila para definir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "los parémetros del Ensayo.")
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.dgvEspecif)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(911, 286)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ESPECIFICACIONES"
        '
        'dgvEspecif
        '
        Me.dgvEspecif.AllowUserToAddRows = False
        Me.dgvEspecif.AllowUserToDeleteRows = False
        Me.dgvEspecif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecif.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Especificacion, Me.DescEnsayo, Me.Farmacopea, Me.TipoEspecif, Me.DesdeEspecif, Me.HastaEspecif, Me.UnidadEspecif, Me.MenorIgualEspecif, Me.InformaEspecif, Me.Parametro, Me.FormulaEspecif, Me.Variable1, Me.Variable2, Me.Variable3, Me.Variable4, Me.Variable5, Me.Variable6, Me.Variable7, Me.Variable8, Me.Variable9, Me.Variable10})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecif.DefaultCellStyle = DataGridViewCellStyle14
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
        Me.dgvEspecif.Size = New System.Drawing.Size(905, 280)
        Me.dgvEspecif.TabIndex = 0
        '
        'Ensayo
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle13
        Me.Ensayo.HeaderText = "Ens."
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.Width = 40
        '
        'Especificacion
        '
        Me.Especificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Especificacion.HeaderText = "Descripción Ensayo"
        Me.Especificacion.MinimumWidth = 250
        Me.Especificacion.Name = "Especificacion"
        Me.Especificacion.ReadOnly = True
        Me.Especificacion.Width = 250
        '
        'DescEnsayo
        '
        Me.DescEnsayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescEnsayo.HeaderText = "Descripción Parámetro"
        Me.DescEnsayo.MinimumWidth = 150
        Me.DescEnsayo.Name = "DescEnsayo"
        Me.DescEnsayo.ReadOnly = True
        '
        'Farmacopea
        '
        Me.Farmacopea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Farmacopea.HeaderText = "Farmacopea"
        Me.Farmacopea.Name = "Farmacopea"
        Me.Farmacopea.ReadOnly = True
        Me.Farmacopea.Visible = False
        '
        'TipoEspecif
        '
        Me.TipoEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TipoEspecif.HeaderText = "TipoEspecif"
        Me.TipoEspecif.Name = "TipoEspecif"
        Me.TipoEspecif.ReadOnly = True
        Me.TipoEspecif.Visible = False
        '
        'DesdeEspecif
        '
        Me.DesdeEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DesdeEspecif.HeaderText = "DesdeEspecif"
        Me.DesdeEspecif.Name = "DesdeEspecif"
        Me.DesdeEspecif.ReadOnly = True
        Me.DesdeEspecif.Visible = False
        '
        'HastaEspecif
        '
        Me.HastaEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.HastaEspecif.HeaderText = "HastaEspecif"
        Me.HastaEspecif.Name = "HastaEspecif"
        Me.HastaEspecif.ReadOnly = True
        Me.HastaEspecif.Visible = False
        '
        'UnidadEspecif
        '
        Me.UnidadEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.UnidadEspecif.HeaderText = "UnidadEspecif"
        Me.UnidadEspecif.Name = "UnidadEspecif"
        Me.UnidadEspecif.ReadOnly = True
        Me.UnidadEspecif.Visible = False
        '
        'MenorIgualEspecif
        '
        Me.MenorIgualEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MenorIgualEspecif.HeaderText = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Name = "MenorIgualEspecif"
        Me.MenorIgualEspecif.ReadOnly = True
        Me.MenorIgualEspecif.Visible = False
        '
        'InformaEspecif
        '
        Me.InformaEspecif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InformaEspecif.HeaderText = "InformaEspecif"
        Me.InformaEspecif.Name = "InformaEspecif"
        Me.InformaEspecif.ReadOnly = True
        Me.InformaEspecif.Visible = False
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Parametro.HeaderText = "Parametro"
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
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.dgvEspecifIngles)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(911, 286)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ESPECIFICACIONES INGLÉS"
        '
        'dgvEspecifIngles
        '
        Me.dgvEspecifIngles.AllowUserToAddRows = False
        Me.dgvEspecifIngles.AllowUserToDeleteRows = False
        Me.dgvEspecifIngles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecifIngles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EnsayoIngles, Me.EspecificacionIngles, Me.DescEnsayoIngles, Me.FarmacopeaIngles, Me.UnidadEspecifIngles})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecifIngles.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvEspecifIngles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEspecifIngles.DoubleBuffered = True
        Me.dgvEspecifIngles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEspecifIngles.Location = New System.Drawing.Point(3, 3)
        Me.dgvEspecifIngles.Name = "dgvEspecifIngles"
        Me.dgvEspecifIngles.OrdenamientoColumnasHabilitado = True
        Me.dgvEspecifIngles.RowHeadersWidth = 10
        Me.dgvEspecifIngles.RowTemplate.Height = 20
        Me.dgvEspecifIngles.ShowCellToolTips = False
        Me.dgvEspecifIngles.SinClickDerecho = False
        Me.dgvEspecifIngles.Size = New System.Drawing.Size(905, 280)
        Me.dgvEspecifIngles.TabIndex = 1
        '
        'EnsayoIngles
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.EnsayoIngles.DefaultCellStyle = DataGridViewCellStyle15
        Me.EnsayoIngles.HeaderText = "Ens."
        Me.EnsayoIngles.Name = "EnsayoIngles"
        Me.EnsayoIngles.Width = 40
        '
        'EspecificacionIngles
        '
        Me.EspecificacionIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EspecificacionIngles.HeaderText = "Descripción Ensayo"
        Me.EspecificacionIngles.MinimumWidth = 250
        Me.EspecificacionIngles.Name = "EspecificacionIngles"
        Me.EspecificacionIngles.ReadOnly = True
        Me.EspecificacionIngles.Width = 250
        '
        'DescEnsayoIngles
        '
        Me.DescEnsayoIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescEnsayoIngles.HeaderText = "Descripción Parámetro Inglés"
        Me.DescEnsayoIngles.MinimumWidth = 150
        Me.DescEnsayoIngles.Name = "DescEnsayoIngles"
        '
        'FarmacopeaIngles
        '
        Me.FarmacopeaIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FarmacopeaIngles.HeaderText = "Farmacopea"
        Me.FarmacopeaIngles.Name = "FarmacopeaIngles"
        Me.FarmacopeaIngles.Width = 91
        '
        'UnidadEspecifIngles
        '
        Me.UnidadEspecifIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.UnidadEspecifIngles.HeaderText = "Unidad"
        Me.UnidadEspecifIngles.MinimumWidth = 80
        Me.UnidadEspecifIngles.Name = "UnidadEspecifIngles"
        Me.UnidadEspecifIngles.Width = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Condición de Muestreo:"
        '
        'txtCondicionMuestreo
        '
        Me.txtCondicionMuestreo.Location = New System.Drawing.Point(142, 96)
        Me.txtCondicionMuestreo.MaxLength = 150
        Me.txtCondicionMuestreo.Multiline = True
        Me.txtCondicionMuestreo.Name = "txtCondicionMuestreo"
        Me.txtCondicionMuestreo.Size = New System.Drawing.Size(492, 33)
        Me.txtCondicionMuestreo.TabIndex = 3
        Me.txtCondicionMuestreo.Text = "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" & _
    "OOOOOOOOOOOOOOOOOOO"
        '
        'txtDescIngles
        '
        Me.txtDescIngles.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescIngles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescIngles.Location = New System.Drawing.Point(142, 35)
        Me.txtDescIngles.Name = "txtDescIngles"
        Me.txtDescIngles.Size = New System.Drawing.Size(492, 20)
        Me.txtDescIngles.TabIndex = 2
        Me.txtDescIngles.TabStop = False
        Me.txtDescIngles.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Descripción Inglés:"
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.Cyan
        Me.txtOperador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperador.Location = New System.Drawing.Point(680, 92)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(202, 18)
        Me.txtOperador.TabIndex = 7
        Me.txtOperador.TabStop = False
        Me.txtOperador.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(653, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Op:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(653, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Ver:"
        '
        'txtVersion
        '
        Me.txtVersion.BackColor = System.Drawing.Color.Cyan
        Me.txtVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersion.Location = New System.Drawing.Point(680, 112)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReadOnly = True
        Me.txtVersion.Size = New System.Drawing.Size(25, 18)
        Me.txtVersion.TabIndex = 7
        Me.txtVersion.TabStop = False
        Me.txtVersion.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(708, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Fec:"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.Cyan
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(736, 112)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(53, 18)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.TabStop = False
        Me.txtFecha.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(789, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "CAS:"
        '
        'txtCas
        '
        Me.txtCas.BackColor = System.Drawing.Color.Cyan
        Me.txtCas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCas.Location = New System.Drawing.Point(818, 112)
        Me.txtCas.Name = "txtCas"
        Me.txtCas.ReadOnly = True
        Me.txtCas.Size = New System.Drawing.Size(64, 18)
        Me.txtCas.TabIndex = 7
        Me.txtCas.TabStop = False
        Me.txtCas.Text = "NOMBRE DE PRODUCTO TEMINADO"
        '
        'IngresoEspecificacionesMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 510)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IngresoEspecificacionesMP"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
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
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtControlCambios As System.Windows.Forms.TextBox
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents btnConsultas As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dgvEspecif As DBDataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvEspecifIngles As ConsultasVarias.DBDataGridView
    Friend WithEvents btnHistorialCambios As System.Windows.Forms.Button
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
    Friend WithEvents EnsayoIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EspecificacionIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEnsayoIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FarmacopeaIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadEspecifIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCondicionMuestreo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescIngles As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCas As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
