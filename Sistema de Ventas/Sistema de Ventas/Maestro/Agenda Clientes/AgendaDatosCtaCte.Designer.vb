<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgendaDatosCtaCte
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbPesos = New System.Windows.Forms.RadioButton()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbDocumentos = New System.Windows.Forms.RadioButton()
        Me.rbCtaCte = New System.Windows.Forms.RadioButton()
        Me.rbTotal = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbPendientes = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.dgvCtaCtes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCtaCtes
        '
        Me.dgvCtaCtes.AllowUserToAddRows = False
        Me.dgvCtaCtes.AllowUserToDeleteRows = False
        Me.dgvCtaCtes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCtaCtes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Marca, Me.Tipo, Me.Impre, Me.Numero, Me.Fecha, Me.Total, Me.TotalUs, Me.Importe1, Me.Importe2, Me.Saldo, Me.SaldoUs, Me.Vencimiento, Me.Vencimiento1})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCtaCtes.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCtaCtes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCtaCtes.DoubleBuffered = True
        Me.dgvCtaCtes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCtaCtes.EnableHeadersVisualStyles = False
        Me.dgvCtaCtes.Location = New System.Drawing.Point(0, 177)
        Me.dgvCtaCtes.Name = "dgvCtaCtes"
        Me.dgvCtaCtes.OrdenamientoColumnasHabilitado = False
        Me.dgvCtaCtes.ReadOnly = True
        Me.dgvCtaCtes.RowHeadersWidth = 15
        Me.dgvCtaCtes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.dgvCtaCtes.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCtaCtes.RowTemplate.Height = 20
        Me.dgvCtaCtes.ShowCellToolTips = False
        Me.dgvCtaCtes.SinClickDerecho = False
        Me.dgvCtaCtes.Size = New System.Drawing.Size(691, 271)
        Me.dgvCtaCtes.TabIndex = 36
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Impre.DefaultCellStyle = DataGridViewCellStyle1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "0#####"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = "00/00/0000"
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle3
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle4
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.TotalUs.DefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Importe1.DefaultCellStyle = DataGridViewCellStyle6
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Importe2.DefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SaldoUs.DefaultCellStyle = DataGridViewCellStyle9
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.NullValue = "00/00/0000"
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle10
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
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = "00/00/0000"
        Me.Vencimiento1.DefaultCellStyle = DataGridViewCellStyle11
        Me.Vencimiento1.HeaderText = "Venc"
        Me.Vencimiento1.Name = "Vencimiento1"
        Me.Vencimiento1.ReadOnly = True
        Me.Vencimiento1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vencimiento1.Width = 75
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(23, 90)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 34)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "CERRAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(24, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 36)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "RECLAMAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(79, 149)
        Me.txtCliente.Mask = ">L00000"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(46, 20)
        Me.txtCliente.TabIndex = 31
        Me.txtCliente.Text = "A99999"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(526, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "TOTAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "CLIENTE"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Cyan
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(572, 148)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(101, 22)
        Me.lblTotal.TabIndex = 27
        Me.lblTotal.Text = "CLIENTE"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.Cyan
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCliente.Location = New System.Drawing.Point(131, 148)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Size = New System.Drawing.Size(390, 23)
        Me.lblDescCliente.TabIndex = 29
        Me.lblDescCliente.Text = "CLIENTE"
        Me.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDolares)
        Me.GroupBox1.Controls.Add(Me.rbPesos)
        Me.GroupBox1.Location = New System.Drawing.Point(266, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 94)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(11, 44)
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
        Me.rbPesos.Location = New System.Drawing.Point(11, 19)
        Me.rbPesos.Name = "rbPesos"
        Me.rbPesos.Size = New System.Drawing.Size(66, 17)
        Me.rbPesos.TabIndex = 0
        Me.rbPesos.TabStop = True
        Me.rbPesos.Text = "PESOS"
        Me.rbPesos.UseVisualStyleBackColor = True
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
        Me.panel1.TabIndex = 38
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
        Me.label1.Size = New System.Drawing.Size(284, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "DATOS CUENTA CORRIENTE DE CLIENTE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDocumentos)
        Me.GroupBox2.Controls.Add(Me.rbCtaCte)
        Me.GroupBox2.Controls.Add(Me.rbTotal)
        Me.GroupBox2.Location = New System.Drawing.Point(372, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(137, 94)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        '
        'rbDocumentos
        '
        Me.rbDocumentos.AutoSize = True
        Me.rbDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocumentos.Location = New System.Drawing.Point(11, 67)
        Me.rbDocumentos.Name = "rbDocumentos"
        Me.rbDocumentos.Size = New System.Drawing.Size(112, 17)
        Me.rbDocumentos.TabIndex = 0
        Me.rbDocumentos.Text = "DOCUMENTOS"
        Me.rbDocumentos.UseVisualStyleBackColor = True
        '
        'rbCtaCte
        '
        Me.rbCtaCte.AutoSize = True
        Me.rbCtaCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCtaCte.Location = New System.Drawing.Point(11, 43)
        Me.rbCtaCte.Name = "rbCtaCte"
        Me.rbCtaCte.Size = New System.Drawing.Size(77, 17)
        Me.rbCtaCte.TabIndex = 0
        Me.rbCtaCte.Text = "CTA CTE"
        Me.rbCtaCte.UseVisualStyleBackColor = True
        '
        'rbTotal
        '
        Me.rbTotal.AutoSize = True
        Me.rbTotal.Checked = True
        Me.rbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTotal.Location = New System.Drawing.Point(11, 19)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(65, 17)
        Me.rbTotal.TabIndex = 0
        Me.rbTotal.TabStop = True
        Me.rbTotal.Text = "TOTAL"
        Me.rbTotal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbTodos)
        Me.GroupBox3.Controls.Add(Me.rbPendientes)
        Me.GroupBox3.Location = New System.Drawing.Point(515, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(155, 94)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(11, 44)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(68, 17)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.Text = "TODOS"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Checked = True
        Me.rbPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPendientes.Location = New System.Drawing.Point(11, 19)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(141, 17)
        Me.rbPendientes.TabIndex = 0
        Me.rbPendientes.TabStop = True
        Me.rbPendientes.Text = "SÓLO PENDIENTES"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'AgendaDatosCtaCte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 448)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.dgvCtaCtes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblDescCliente)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AgendaDatosCtaCte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvCtaCtes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCtaCtes As Util.DBDataGridView
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblDescCliente As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbPesos As System.Windows.Forms.RadioButton
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDocumentos As System.Windows.Forms.RadioButton
    Friend WithEvents rbCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
