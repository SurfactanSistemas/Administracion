<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaMinuta
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtCliente = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtObservaciones2 = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbPesos = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvCtaCtes = New Util.DBDataGridView()
        Me.Marca = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Impre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalUs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoUs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblACobrar = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCtaCtes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(124, 81)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(390, 20)
        Me.txtObservaciones.TabIndex = 17
        Me.txtObservaciones.Text = "LLAMAR EL LUNES TEMPRANO"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(568, 54)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(66, 20)
        Me.txtFecha.TabIndex = 15
        Me.txtFecha.Text = "00000000"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(72, 55)
        Me.txtCliente.Mask = ">L00000"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCliente.Size = New System.Drawing.Size(46, 20)
        Me.txtCliente.TabIndex = 16
        Me.txtCliente.Text = "A99999"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "OBSERVACIONES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(520, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "FECHA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "CLIENTE"
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCliente.Location = New System.Drawing.Point(124, 54)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Size = New System.Drawing.Size(390, 23)
        Me.lblDescCliente.TabIndex = 14
        Me.lblDescCliente.Text = "CLIENTE"
        Me.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(691, 40)
        Me.panel1.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(515, 10)
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
        Me.label1.Size = New System.Drawing.Size(99, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "ALTA MINUTA"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(520, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 44)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "EMITIR MINUTA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtObservaciones2
        '
        Me.txtObservaciones2.Location = New System.Drawing.Point(124, 104)
        Me.txtObservaciones2.MaxLength = 50
        Me.txtObservaciones2.Name = "txtObservaciones2"
        Me.txtObservaciones2.Size = New System.Drawing.Size(390, 20)
        Me.txtObservaciones2.TabIndex = 17
        Me.txtObservaciones2.Text = "LLAMAR EL LUNES TEMPRANO"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDolares)
        Me.GroupBox1.Controls.Add(Me.rbPesos)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 39)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(92, 14)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(83, 17)
        Me.rbDolares.TabIndex = 0
        Me.rbDolares.Text = "DOLARES"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'rbPesos
        '
        Me.rbPesos.AutoSize = True
        Me.rbPesos.Checked = True
        Me.rbPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPesos.Location = New System.Drawing.Point(11, 14)
        Me.rbPesos.Name = "rbPesos"
        Me.rbPesos.Size = New System.Drawing.Size(66, 17)
        Me.rbPesos.TabIndex = 0
        Me.rbPesos.TabStop = True
        Me.rbPesos.Text = "PESOS"
        Me.rbPesos.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(519, 126)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 34)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "CERRAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvCtaCtes
        '
        Me.dgvCtaCtes.AllowUserToAddRows = False
        Me.dgvCtaCtes.AllowUserToDeleteRows = False
        Me.dgvCtaCtes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCtaCtes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Marca, Me.Tipo, Me.Impre, Me.Numero, Me.Fecha, Me.Total, Me.TotalUs, Me.Importe1, Me.Importe2, Me.Saldo, Me.SaldoUs, Me.Vencimiento, Me.Vencimiento1})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCtaCtes.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgvCtaCtes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCtaCtes.DoubleBuffered = True
        Me.dgvCtaCtes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCtaCtes.EnableHeadersVisualStyles = False
        Me.dgvCtaCtes.Location = New System.Drawing.Point(0, 163)
        Me.dgvCtaCtes.Name = "dgvCtaCtes"
        Me.dgvCtaCtes.OrdenamientoColumnasHabilitado = False
        Me.dgvCtaCtes.ReadOnly = True
        Me.dgvCtaCtes.RowHeadersWidth = 15
        Me.dgvCtaCtes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle26.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.dgvCtaCtes.RowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvCtaCtes.RowTemplate.Height = 20
        Me.dgvCtaCtes.ShowCellToolTips = False
        Me.dgvCtaCtes.SinClickDerecho = False
        Me.dgvCtaCtes.Size = New System.Drawing.Size(691, 237)
        Me.dgvCtaCtes.TabIndex = 20
        '
        'Marca
        '
        Me.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Marca.DataPropertyName = "Marca"
        Me.Marca.FalseValue = "0"
        Me.Marca.HeaderText = ""
        Me.Marca.IndeterminateValue = "0"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        Me.Marca.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Marca.TrueValue = "1"
        Me.Marca.Width = 8
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tipo.Visible = False
        '
        'Impre
        '
        Me.Impre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Impre.DataPropertyName = "Impre"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Impre.DefaultCellStyle = DataGridViewCellStyle14
        Me.Impre.HeaderText = "Tipo"
        Me.Impre.Name = "Impre"
        Me.Impre.ReadOnly = True
        Me.Impre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Impre.Width = 40
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Numero.DataPropertyName = "Numero"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "0#####"
        DataGridViewCellStyle15.NullValue = "0"
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle15
        Me.Numero.HeaderText = "Numero"
        Me.Numero.MinimumWidth = 80
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Numero.Width = 80
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Format = "d"
        DataGridViewCellStyle16.NullValue = "00/00/0000"
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle16
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MinimumWidth = 70
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha.Width = 70
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle17
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Total.Visible = False
        '
        'TotalUs
        '
        Me.TotalUs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TotalUs.DataPropertyName = "TotalUs"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        DataGridViewCellStyle18.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.TotalUs.DefaultCellStyle = DataGridViewCellStyle18
        Me.TotalUs.HeaderText = "Total"
        Me.TotalUs.Name = "TotalUs"
        Me.TotalUs.ReadOnly = True
        Me.TotalUs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalUs.Visible = False
        '
        'Importe1
        '
        Me.Importe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Importe1.DataPropertyName = "Importe1"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0"
        Me.Importe1.DefaultCellStyle = DataGridViewCellStyle19
        Me.Importe1.HeaderText = "Débito"
        Me.Importe1.MinimumWidth = 100
        Me.Importe1.Name = "Importe1"
        Me.Importe1.ReadOnly = True
        Me.Importe1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Importe2
        '
        Me.Importe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Importe2.DataPropertyName = "Importe2"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0"
        Me.Importe2.DefaultCellStyle = DataGridViewCellStyle20
        Me.Importe2.HeaderText = "Crédito"
        Me.Importe2.MinimumWidth = 100
        Me.Importe2.Name = "Importe2"
        Me.Importe2.ReadOnly = True
        Me.Importe2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Saldo
        '
        Me.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Saldo.DataPropertyName = "Saldo"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = "0"
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle21
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.MinimumWidth = 100
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        Me.Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SaldoUs
        '
        Me.SaldoUs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SaldoUs.DataPropertyName = "SaldoUs"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "0"
        DataGridViewCellStyle22.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SaldoUs.DefaultCellStyle = DataGridViewCellStyle22
        Me.SaldoUs.HeaderText = "Saldo"
        Me.SaldoUs.MinimumWidth = 100
        Me.SaldoUs.Name = "SaldoUs"
        Me.SaldoUs.ReadOnly = True
        Me.SaldoUs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SaldoUs.Visible = False
        '
        'Vencimiento
        '
        Me.Vencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Vencimiento.DataPropertyName = "Vencimiento"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "d"
        DataGridViewCellStyle23.NullValue = "00/00/0000"
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle23
        Me.Vencimiento.HeaderText = "Venc"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        Me.Vencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vencimiento.Width = 75
        '
        'Vencimiento1
        '
        Me.Vencimiento1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Vencimiento1.DataPropertyName = "Vencimiento1"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "d"
        DataGridViewCellStyle24.NullValue = "00/00/0000"
        Me.Vencimiento1.DefaultCellStyle = DataGridViewCellStyle24
        Me.Vencimiento1.HeaderText = "Venc"
        Me.Vencimiento1.Name = "Vencimiento1"
        Me.Vencimiento1.ReadOnly = True
        Me.Vencimiento1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vencimiento1.Width = 75
        '
        'lblACobrar
        '
        Me.lblACobrar.BackColor = System.Drawing.Color.Cyan
        Me.lblACobrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblACobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACobrar.Location = New System.Drawing.Point(232, 132)
        Me.lblACobrar.Name = "lblACobrar"
        Me.lblACobrar.Size = New System.Drawing.Size(88, 22)
        Me.lblACobrar.TabIndex = 14
        Me.lblACobrar.Text = "CLIENTE"
        Me.lblACobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(166, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "A COBRAR"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Cyan
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(60, 132)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(101, 22)
        Me.lblTotal.TabIndex = 14
        Me.lblTotal.Text = "CLIENTE"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "TOTAL"
        '
        'AltaMinuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 400)
        Me.Controls.Add(Me.dgvCtaCtes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.txtObservaciones2)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblACobrar)
        Me.Controls.Add(Me.lblDescCliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaMinuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCtaCtes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDescCliente As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvCtaCtes As Util.DBDataGridView
    Friend WithEvents txtObservaciones2 As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbPesos As System.Windows.Forms.RadioButton
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Impre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalUs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoUs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblACobrar As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
