<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnsayosMonocomponente
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvEnsayos = New ConsultasVarias.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Farmacopea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorBandera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesdeEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HastaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenorIgualEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InformaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.VariableValor1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableValor10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecificacionIngles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decimales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorLabora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorIniciales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLotePartida = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEnsayos
        '
        Me.dgvEnsayos.AllowUserToAddRows = False
        Me.dgvEnsayos.AllowUserToDeleteRows = False
        Me.dgvEnsayos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnsayos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEnsayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnsayos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Especificacion, Me.Farmacopea, Me.Valor, Me.ValorBandera, Me.Resultado, Me.Parametro, Me.Descripcion, Me.TipoEspecif, Me.DesdeEspecif, Me.HastaEspecif, Me.UnidadEspecif, Me.MenorIgualEspecif, Me.InformaEspecif, Me.Observaciones, Me.FormulaEspecif, Me.Variable1, Me.Variable2, Me.Variable3, Me.Variable4, Me.Variable5, Me.Variable6, Me.Variable7, Me.Variable8, Me.Variable9, Me.Variable10, Me.VariableValor1, Me.VariableValor2, Me.VariableValor3, Me.VariableValor4, Me.VariableValor5, Me.VariableValor6, Me.VariableValor7, Me.VariableValor8, Me.VariableValor9, Me.VariableValor10, Me.EspecificacionIngles, Me.Decimales, Me.OperadorLabora, Me.OperadorIniciales})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnsayos.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEnsayos.DoubleBuffered = True
        Me.dgvEnsayos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnsayos.Location = New System.Drawing.Point(7, 115)
        Me.dgvEnsayos.Name = "dgvEnsayos"
        Me.dgvEnsayos.OrdenamientoColumnasHabilitado = False
        Me.dgvEnsayos.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnsayos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEnsayos.RowHeadersWidth = 30
        Me.dgvEnsayos.RowTemplate.Height = 20
        Me.dgvEnsayos.ShowCellToolTips = False
        Me.dgvEnsayos.SinClickDerecho = False
        Me.dgvEnsayos.Size = New System.Drawing.Size(682, 271)
        Me.dgvEnsayos.TabIndex = 5
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ensayo.HeaderText = "Ens"
        Me.Ensayo.MaxInputLength = 10
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ensayo.Width = 31
        '
        'Especificacion
        '
        Me.Especificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Especificacion.HeaderText = "Especificación"
        Me.Especificacion.MinimumWidth = 150
        Me.Especificacion.Name = "Especificacion"
        Me.Especificacion.ReadOnly = True
        Me.Especificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Farmacopea
        '
        Me.Farmacopea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Farmacopea.HeaderText = "Farmac"
        Me.Farmacopea.Name = "Farmacopea"
        Me.Farmacopea.ReadOnly = True
        Me.Farmacopea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Farmacopea.Visible = False
        '
        'Valor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MinimumWidth = 50
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Visible = False
        Me.Valor.Width = 50
        '
        'ValorBandera
        '
        Me.ValorBandera.HeaderText = "ValorBandera"
        Me.ValorBandera.Name = "ValorBandera"
        Me.ValorBandera.ReadOnly = True
        Me.ValorBandera.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorBandera.Visible = False
        '
        'Resultado
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Resultado.DefaultCellStyle = DataGridViewCellStyle4
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.MinimumWidth = 100
        Me.Resultado.Name = "Resultado"
        Me.Resultado.ReadOnly = True
        Me.Resultado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Parametro.DefaultCellStyle = DataGridViewCellStyle5
        Me.Parametro.HeaderText = "Parámetro"
        Me.Parametro.MinimumWidth = 150
        Me.Parametro.Name = "Parametro"
        Me.Parametro.ReadOnly = True
        Me.Parametro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Parametro.Width = 150
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Visible = False
        '
        'TipoEspecif
        '
        Me.TipoEspecif.HeaderText = "TipoEspecif"
        Me.TipoEspecif.Name = "TipoEspecif"
        Me.TipoEspecif.ReadOnly = True
        Me.TipoEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TipoEspecif.Visible = False
        '
        'DesdeEspecif
        '
        Me.DesdeEspecif.HeaderText = "DesdeEspecif"
        Me.DesdeEspecif.Name = "DesdeEspecif"
        Me.DesdeEspecif.ReadOnly = True
        Me.DesdeEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DesdeEspecif.Visible = False
        '
        'HastaEspecif
        '
        Me.HastaEspecif.HeaderText = "HastaEspecif"
        Me.HastaEspecif.Name = "HastaEspecif"
        Me.HastaEspecif.ReadOnly = True
        Me.HastaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HastaEspecif.Visible = False
        '
        'UnidadEspecif
        '
        Me.UnidadEspecif.HeaderText = "UnidadEspecif"
        Me.UnidadEspecif.Name = "UnidadEspecif"
        Me.UnidadEspecif.ReadOnly = True
        Me.UnidadEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UnidadEspecif.Visible = False
        '
        'MenorIgualEspecif
        '
        Me.MenorIgualEspecif.HeaderText = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Name = "MenorIgualEspecif"
        Me.MenorIgualEspecif.ReadOnly = True
        Me.MenorIgualEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MenorIgualEspecif.Visible = False
        '
        'InformaEspecif
        '
        Me.InformaEspecif.HeaderText = "InformaEspecif"
        Me.InformaEspecif.Name = "InformaEspecif"
        Me.InformaEspecif.ReadOnly = True
        Me.InformaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.InformaEspecif.Visible = False
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MinimumWidth = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Observaciones.Visible = False
        '
        'FormulaEspecif
        '
        Me.FormulaEspecif.HeaderText = "FormulaEspecif"
        Me.FormulaEspecif.Name = "FormulaEspecif"
        Me.FormulaEspecif.ReadOnly = True
        Me.FormulaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaEspecif.Visible = False
        '
        'Variable1
        '
        Me.Variable1.HeaderText = "Variable1"
        Me.Variable1.Name = "Variable1"
        Me.Variable1.ReadOnly = True
        Me.Variable1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable1.Visible = False
        '
        'Variable2
        '
        Me.Variable2.HeaderText = "Variable2"
        Me.Variable2.Name = "Variable2"
        Me.Variable2.ReadOnly = True
        Me.Variable2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable2.Visible = False
        '
        'Variable3
        '
        Me.Variable3.HeaderText = "Variable3"
        Me.Variable3.Name = "Variable3"
        Me.Variable3.ReadOnly = True
        Me.Variable3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable3.Visible = False
        '
        'Variable4
        '
        Me.Variable4.HeaderText = "Variable4"
        Me.Variable4.Name = "Variable4"
        Me.Variable4.ReadOnly = True
        Me.Variable4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable4.Visible = False
        '
        'Variable5
        '
        Me.Variable5.HeaderText = "Variable5"
        Me.Variable5.Name = "Variable5"
        Me.Variable5.ReadOnly = True
        Me.Variable5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable5.Visible = False
        '
        'Variable6
        '
        Me.Variable6.HeaderText = "Variable6"
        Me.Variable6.Name = "Variable6"
        Me.Variable6.ReadOnly = True
        Me.Variable6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable6.Visible = False
        '
        'Variable7
        '
        Me.Variable7.HeaderText = "Variable7"
        Me.Variable7.Name = "Variable7"
        Me.Variable7.ReadOnly = True
        Me.Variable7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable7.Visible = False
        '
        'Variable8
        '
        Me.Variable8.HeaderText = "Variable8"
        Me.Variable8.Name = "Variable8"
        Me.Variable8.ReadOnly = True
        Me.Variable8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable8.Visible = False
        '
        'Variable9
        '
        Me.Variable9.HeaderText = "Variable9"
        Me.Variable9.Name = "Variable9"
        Me.Variable9.ReadOnly = True
        Me.Variable9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable9.Visible = False
        '
        'Variable10
        '
        Me.Variable10.HeaderText = "Variable10"
        Me.Variable10.Name = "Variable10"
        Me.Variable10.ReadOnly = True
        Me.Variable10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable10.Visible = False
        '
        'VariableValor1
        '
        Me.VariableValor1.HeaderText = "VariableValor1"
        Me.VariableValor1.Name = "VariableValor1"
        Me.VariableValor1.ReadOnly = True
        Me.VariableValor1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor1.Visible = False
        '
        'VariableValor2
        '
        Me.VariableValor2.HeaderText = "VariableValor2"
        Me.VariableValor2.Name = "VariableValor2"
        Me.VariableValor2.ReadOnly = True
        Me.VariableValor2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor2.Visible = False
        '
        'VariableValor3
        '
        Me.VariableValor3.HeaderText = "VariableValor3"
        Me.VariableValor3.Name = "VariableValor3"
        Me.VariableValor3.ReadOnly = True
        Me.VariableValor3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor3.Visible = False
        '
        'VariableValor4
        '
        Me.VariableValor4.HeaderText = "VariableValor4"
        Me.VariableValor4.Name = "VariableValor4"
        Me.VariableValor4.ReadOnly = True
        Me.VariableValor4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor4.Visible = False
        '
        'VariableValor5
        '
        Me.VariableValor5.HeaderText = "VariableValor5"
        Me.VariableValor5.Name = "VariableValor5"
        Me.VariableValor5.ReadOnly = True
        Me.VariableValor5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor5.Visible = False
        '
        'VariableValor6
        '
        Me.VariableValor6.HeaderText = "VariableValor6"
        Me.VariableValor6.Name = "VariableValor6"
        Me.VariableValor6.ReadOnly = True
        Me.VariableValor6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor6.Visible = False
        '
        'VariableValor7
        '
        Me.VariableValor7.HeaderText = "VariableValor7"
        Me.VariableValor7.Name = "VariableValor7"
        Me.VariableValor7.ReadOnly = True
        Me.VariableValor7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor7.Visible = False
        '
        'VariableValor8
        '
        Me.VariableValor8.HeaderText = "VariableValor8"
        Me.VariableValor8.Name = "VariableValor8"
        Me.VariableValor8.ReadOnly = True
        Me.VariableValor8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor8.Visible = False
        '
        'VariableValor9
        '
        Me.VariableValor9.HeaderText = "VariableValor9"
        Me.VariableValor9.Name = "VariableValor9"
        Me.VariableValor9.ReadOnly = True
        Me.VariableValor9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor9.Visible = False
        '
        'VariableValor10
        '
        Me.VariableValor10.HeaderText = "VariableValor10"
        Me.VariableValor10.Name = "VariableValor10"
        Me.VariableValor10.ReadOnly = True
        Me.VariableValor10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor10.Visible = False
        '
        'EspecificacionIngles
        '
        Me.EspecificacionIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EspecificacionIngles.DataPropertyName = "EspecificacionIngles"
        Me.EspecificacionIngles.HeaderText = "Especif. Inglés"
        Me.EspecificacionIngles.MinimumWidth = 200
        Me.EspecificacionIngles.Name = "EspecificacionIngles"
        Me.EspecificacionIngles.ReadOnly = True
        Me.EspecificacionIngles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EspecificacionIngles.Visible = False
        '
        'Decimales
        '
        Me.Decimales.HeaderText = "Decimales"
        Me.Decimales.Name = "Decimales"
        Me.Decimales.ReadOnly = True
        Me.Decimales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Decimales.Visible = False
        '
        'OperadorLabora
        '
        Me.OperadorLabora.HeaderText = "Operador ID"
        Me.OperadorLabora.Name = "OperadorLabora"
        Me.OperadorLabora.ReadOnly = True
        Me.OperadorLabora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperadorLabora.Visible = False
        '
        'OperadorIniciales
        '
        Me.OperadorIniciales.HeaderText = "Opera."
        Me.OperadorIniciales.Name = "OperadorIniciales"
        Me.OperadorIniciales.ReadOnly = True
        Me.OperadorIniciales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperadorIniciales.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblLotePartida)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.lblProducto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 56)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMACIÓN"
        '
        'lblLotePartida
        '
        Me.lblLotePartida.BackColor = System.Drawing.Color.Cyan
        Me.lblLotePartida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLotePartida.Location = New System.Drawing.Point(611, 20)
        Me.lblLotePartida.Name = "lblLotePartida"
        Me.lblLotePartida.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblLotePartida.Size = New System.Drawing.Size(57, 21)
        Me.lblLotePartida.TabIndex = 0
        Me.lblLotePartida.Text = "999999"
        Me.lblLotePartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Cyan
        Me.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescripcion.Location = New System.Drawing.Point(200, 20)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDescripcion.Size = New System.Drawing.Size(328, 21)
        Me.lblDescripcion.TabIndex = 0
        Me.lblDescripcion.Text = "PT-99999-999"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProducto
        '
        Me.lblProducto.BackColor = System.Drawing.Color.Cyan
        Me.lblProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProducto.Location = New System.Drawing.Point(104, 20)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblProducto.Size = New System.Drawing.Size(90, 21)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "PT-99999-999"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "COMPONENTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(534, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "LOTE / PDA:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 49)
        Me.Panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(506, 12)
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
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ENSAYOS Y RESULTADOS DE COMPONENTE"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(263, 395)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 48)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "CERRAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EnsayosMonocomponente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 451)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvEnsayos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "EnsayosMonocomponente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvEnsayos As ConsultasVarias.DBDataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLotePartida As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Farmacopea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorBandera As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesdeEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HastaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenorIgualEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InformaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents VariableValor1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableValor10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EspecificacionIngles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Decimales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorLabora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorIniciales As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
