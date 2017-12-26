<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComparacionesMensualesValorUnico
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cmbTipoGrafico = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckPapel = New System.Windows.Forms.CheckBox()
        Me.ckVarios = New System.Windows.Forms.CheckBox()
        Me.ckFazonQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckFazonFarma = New System.Windows.Forms.CheckBox()
        Me.ckBiocidas = New System.Windows.Forms.CheckBox()
        Me.ckFazonPellital = New System.Windows.Forms.CheckBox()
        Me.ckFarma = New System.Windows.Forms.CheckBox()
        Me.ckColorantes = New System.Windows.Forms.CheckBox()
        Me.ckQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckConsolidado = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ckPorcentaje = New System.Windows.Forms.CheckBox()
        Me.ckRotacion = New System.Windows.Forms.CheckBox()
        Me.ckStock = New System.Windows.Forms.CheckBox()
        Me.ckPrecio = New System.Windows.Forms.CheckBox()
        Me.ckFactor = New System.Windows.Forms.CheckBox()
        Me.ckPorcentajeAtrasos = New System.Windows.Forms.CheckBox()
        Me.ckKilos = New System.Windows.Forms.CheckBox()
        Me.ckAtrasados = New System.Windows.Forms.CheckBox()
        Me.ckVenta = New System.Windows.Forms.CheckBox()
        Me.ckPedidos = New System.Windows.Forms.CheckBox()
        Me.ckTodosValores = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAnioDesde = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rbMonto = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnSeleccionarAnios = New System.Windows.Forms.Button()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pnlAnios = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ckAnios = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtMesDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtMesHasta = New System.Windows.Forms.MaskedTextBox()
        Me.txtAnioHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAnios.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnGenerar.Location = New System.Drawing.Point(459, 308)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(153, 38)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Graficar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmbTipoGrafico
        '
        Me.cmbTipoGrafico.FormattingEnabled = True
        Me.cmbTipoGrafico.Items.AddRange(New Object() {"Barras", "Lineas"})
        Me.cmbTipoGrafico.Location = New System.Drawing.Point(501, 24)
        Me.cmbTipoGrafico.Name = "cmbTipoGrafico"
        Me.cmbTipoGrafico.Size = New System.Drawing.Size(89, 21)
        Me.cmbTipoGrafico.TabIndex = 2
        Me.cmbTipoGrafico.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckPapel)
        Me.GroupBox2.Controls.Add(Me.ckVarios)
        Me.GroupBox2.Controls.Add(Me.ckFazonQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckFazonFarma)
        Me.GroupBox2.Controls.Add(Me.ckBiocidas)
        Me.GroupBox2.Controls.Add(Me.ckFazonPellital)
        Me.GroupBox2.Controls.Add(Me.ckFarma)
        Me.GroupBox2.Controls.Add(Me.ckColorantes)
        Me.GroupBox2.Controls.Add(Me.ckQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckConsolidado)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(342, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(270, 148)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lineas a Comparar"
        '
        'ckPapel
        '
        Me.ckPapel.AutoSize = True
        Me.ckPapel.Location = New System.Drawing.Point(129, 117)
        Me.ckPapel.Name = "ckPapel"
        Me.ckPapel.Size = New System.Drawing.Size(64, 22)
        Me.ckPapel.TabIndex = 0
        Me.ckPapel.Text = "Papel"
        Me.ckPapel.UseVisualStyleBackColor = True
        '
        'ckVarios
        '
        Me.ckVarios.AutoSize = True
        Me.ckVarios.Location = New System.Drawing.Point(129, 95)
        Me.ckVarios.Name = "ckVarios"
        Me.ckVarios.Size = New System.Drawing.Size(69, 22)
        Me.ckVarios.TabIndex = 0
        Me.ckVarios.Text = "Varios"
        Me.ckVarios.UseVisualStyleBackColor = True
        '
        'ckFazonQuimicos
        '
        Me.ckFazonQuimicos.AutoSize = True
        Me.ckFazonQuimicos.Location = New System.Drawing.Point(129, 73)
        Me.ckFazonQuimicos.Name = "ckFazonQuimicos"
        Me.ckFazonQuimicos.Size = New System.Drawing.Size(137, 22)
        Me.ckFazonQuimicos.TabIndex = 0
        Me.ckFazonQuimicos.Text = "Fazón Químicos"
        Me.ckFazonQuimicos.UseVisualStyleBackColor = True
        '
        'ckFazonFarma
        '
        Me.ckFazonFarma.AutoSize = True
        Me.ckFazonFarma.Location = New System.Drawing.Point(129, 51)
        Me.ckFazonFarma.Name = "ckFazonFarma"
        Me.ckFazonFarma.Size = New System.Drawing.Size(116, 22)
        Me.ckFazonFarma.TabIndex = 0
        Me.ckFazonFarma.Text = "Fazón Farma"
        Me.ckFazonFarma.UseVisualStyleBackColor = True
        '
        'ckBiocidas
        '
        Me.ckBiocidas.AutoSize = True
        Me.ckBiocidas.Location = New System.Drawing.Point(13, 117)
        Me.ckBiocidas.Name = "ckBiocidas"
        Me.ckBiocidas.Size = New System.Drawing.Size(84, 22)
        Me.ckBiocidas.TabIndex = 0
        Me.ckBiocidas.Text = "Biocidas"
        Me.ckBiocidas.UseVisualStyleBackColor = True
        '
        'ckFazonPellital
        '
        Me.ckFazonPellital.AutoSize = True
        Me.ckFazonPellital.Location = New System.Drawing.Point(13, 95)
        Me.ckFazonPellital.Name = "ckFazonPellital"
        Me.ckFazonPellital.Size = New System.Drawing.Size(115, 22)
        Me.ckFazonPellital.TabIndex = 0
        Me.ckFazonPellital.Text = "Fazon Pellital"
        Me.ckFazonPellital.UseVisualStyleBackColor = True
        '
        'ckFarma
        '
        Me.ckFarma.AutoSize = True
        Me.ckFarma.Location = New System.Drawing.Point(129, 27)
        Me.ckFarma.Name = "ckFarma"
        Me.ckFarma.Size = New System.Drawing.Size(70, 22)
        Me.ckFarma.TabIndex = 0
        Me.ckFarma.Text = "Farma"
        Me.ckFarma.UseVisualStyleBackColor = True
        '
        'ckColorantes
        '
        Me.ckColorantes.AutoSize = True
        Me.ckColorantes.Location = New System.Drawing.Point(13, 71)
        Me.ckColorantes.Name = "ckColorantes"
        Me.ckColorantes.Size = New System.Drawing.Size(100, 22)
        Me.ckColorantes.TabIndex = 0
        Me.ckColorantes.Text = "Colorantes"
        Me.ckColorantes.UseVisualStyleBackColor = True
        '
        'ckQuimicos
        '
        Me.ckQuimicos.AutoSize = True
        Me.ckQuimicos.Location = New System.Drawing.Point(13, 49)
        Me.ckQuimicos.Name = "ckQuimicos"
        Me.ckQuimicos.Size = New System.Drawing.Size(91, 22)
        Me.ckQuimicos.TabIndex = 0
        Me.ckQuimicos.Text = "Químicos"
        Me.ckQuimicos.UseVisualStyleBackColor = True
        '
        'ckConsolidado
        '
        Me.ckConsolidado.AutoSize = True
        Me.ckConsolidado.Location = New System.Drawing.Point(13, 27)
        Me.ckConsolidado.Name = "ckConsolidado"
        Me.ckConsolidado.Size = New System.Drawing.Size(111, 22)
        Me.ckConsolidado.TabIndex = 0
        Me.ckConsolidado.Text = "Consolidado"
        Me.ckConsolidado.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ckPorcentaje)
        Me.GroupBox3.Controls.Add(Me.ckRotacion)
        Me.GroupBox3.Controls.Add(Me.ckStock)
        Me.GroupBox3.Controls.Add(Me.ckPrecio)
        Me.GroupBox3.Controls.Add(Me.ckFactor)
        Me.GroupBox3.Controls.Add(Me.ckPorcentajeAtrasos)
        Me.GroupBox3.Controls.Add(Me.ckKilos)
        Me.GroupBox3.Controls.Add(Me.ckAtrasados)
        Me.GroupBox3.Controls.Add(Me.ckVenta)
        Me.GroupBox3.Controls.Add(Me.ckPedidos)
        Me.GroupBox3.Controls.Add(Me.ckTodosValores)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(310, 181)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Valores a Graficar"
        '
        'ckPorcentaje
        '
        Me.ckPorcentaje.AutoSize = True
        Me.ckPorcentaje.Location = New System.Drawing.Point(155, 77)
        Me.ckPorcentaje.Name = "ckPorcentaje"
        Me.ckPorcentaje.Size = New System.Drawing.Size(98, 22)
        Me.ckPorcentaje.TabIndex = 0
        Me.ckPorcentaje.Text = "Porcentaje"
        Me.ckPorcentaje.UseVisualStyleBackColor = True
        '
        'ckRotacion
        '
        Me.ckRotacion.AutoSize = True
        Me.ckRotacion.Location = New System.Drawing.Point(155, 54)
        Me.ckRotacion.Name = "ckRotacion"
        Me.ckRotacion.Size = New System.Drawing.Size(87, 22)
        Me.ckRotacion.TabIndex = 0
        Me.ckRotacion.Text = "Rotación"
        Me.ckRotacion.UseVisualStyleBackColor = True
        '
        'ckStock
        '
        Me.ckStock.AutoSize = True
        Me.ckStock.Location = New System.Drawing.Point(13, 146)
        Me.ckStock.Name = "ckStock"
        Me.ckStock.Size = New System.Drawing.Size(66, 22)
        Me.ckStock.TabIndex = 0
        Me.ckStock.Text = "Stock"
        Me.ckStock.UseVisualStyleBackColor = True
        '
        'ckPrecio
        '
        Me.ckPrecio.AutoSize = True
        Me.ckPrecio.Location = New System.Drawing.Point(13, 123)
        Me.ckPrecio.Name = "ckPrecio"
        Me.ckPrecio.Size = New System.Drawing.Size(139, 22)
        Me.ckPrecio.TabIndex = 0
        Me.ckPrecio.Text = "Precio Promedio"
        Me.ckPrecio.UseVisualStyleBackColor = True
        '
        'ckFactor
        '
        Me.ckFactor.AutoSize = True
        Me.ckFactor.Location = New System.Drawing.Point(13, 100)
        Me.ckFactor.Name = "ckFactor"
        Me.ckFactor.Size = New System.Drawing.Size(70, 22)
        Me.ckFactor.TabIndex = 0
        Me.ckFactor.Text = "Factor"
        Me.ckFactor.UseVisualStyleBackColor = True
        '
        'ckPorcentajeAtrasos
        '
        Me.ckPorcentajeAtrasos.AutoSize = True
        Me.ckPorcentajeAtrasos.Location = New System.Drawing.Point(155, 146)
        Me.ckPorcentajeAtrasos.Name = "ckPorcentajeAtrasos"
        Me.ckPorcentajeAtrasos.Size = New System.Drawing.Size(153, 22)
        Me.ckPorcentajeAtrasos.TabIndex = 0
        Me.ckPorcentajeAtrasos.Text = "Porcentaje Atrasos"
        Me.ckPorcentajeAtrasos.UseVisualStyleBackColor = True
        '
        'ckKilos
        '
        Me.ckKilos.AutoSize = True
        Me.ckKilos.Location = New System.Drawing.Point(13, 77)
        Me.ckKilos.Name = "ckKilos"
        Me.ckKilos.Size = New System.Drawing.Size(60, 22)
        Me.ckKilos.TabIndex = 0
        Me.ckKilos.Text = "Kilos"
        Me.ckKilos.UseVisualStyleBackColor = True
        '
        'ckAtrasados
        '
        Me.ckAtrasados.AutoSize = True
        Me.ckAtrasados.Location = New System.Drawing.Point(155, 123)
        Me.ckAtrasados.Name = "ckAtrasados"
        Me.ckAtrasados.Size = New System.Drawing.Size(152, 22)
        Me.ckAtrasados.TabIndex = 0
        Me.ckAtrasados.Text = "Pedidos Atrasados"
        Me.ckAtrasados.UseVisualStyleBackColor = True
        '
        'ckVenta
        '
        Me.ckVenta.AutoSize = True
        Me.ckVenta.Location = New System.Drawing.Point(13, 54)
        Me.ckVenta.Name = "ckVenta"
        Me.ckVenta.Size = New System.Drawing.Size(107, 22)
        Me.ckVenta.TabIndex = 0
        Me.ckVenta.Text = "Venta (U$S)"
        Me.ckVenta.UseVisualStyleBackColor = True
        '
        'ckPedidos
        '
        Me.ckPedidos.AutoSize = True
        Me.ckPedidos.Location = New System.Drawing.Point(155, 100)
        Me.ckPedidos.Name = "ckPedidos"
        Me.ckPedidos.Size = New System.Drawing.Size(81, 22)
        Me.ckPedidos.TabIndex = 0
        Me.ckPedidos.Text = "Pedidos"
        Me.ckPedidos.UseVisualStyleBackColor = True
        '
        'ckTodosValores
        '
        Me.ckTodosValores.AutoSize = True
        Me.ckTodosValores.Location = New System.Drawing.Point(13, 31)
        Me.ckTodosValores.Name = "ckTodosValores"
        Me.ckTodosValores.Size = New System.Drawing.Size(69, 22)
        Me.ckTodosValores.TabIndex = 0
        Me.ckTodosValores.Text = "Todas"
        Me.ckTodosValores.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Año:"
        '
        'txtAnioDesde
        '
        Me.txtAnioDesde.Location = New System.Drawing.Point(146, 20)
        Me.txtAnioDesde.Mask = "0000"
        Me.txtAnioDesde.Name = "txtAnioDesde"
        Me.txtAnioDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtAnioDesde.Size = New System.Drawing.Size(62, 24)
        Me.txtAnioDesde.TabIndex = 5
        Me.txtAnioDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbPorcentaje)
        Me.GroupBox4.Controls.Add(Me.rbMonto)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(310, 51)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Unidad"
        Me.GroupBox4.Visible = False
        '
        'rbPorcentaje
        '
        Me.rbPorcentaje.AutoSize = True
        Me.rbPorcentaje.Location = New System.Drawing.Point(134, 21)
        Me.rbPorcentaje.Name = "rbPorcentaje"
        Me.rbPorcentaje.Size = New System.Drawing.Size(97, 22)
        Me.rbPorcentaje.TabIndex = 0
        Me.rbPorcentaje.Text = "Porcentaje"
        Me.rbPorcentaje.UseVisualStyleBackColor = True
        '
        'rbMonto
        '
        Me.rbMonto.AutoSize = True
        Me.rbMonto.Checked = True
        Me.rbMonto.Location = New System.Drawing.Point(58, 21)
        Me.rbMonto.Name = "rbMonto"
        Me.rbMonto.Size = New System.Drawing.Size(69, 22)
        Me.rbMonto.TabIndex = 0
        Me.rbMonto.TabStop = True
        Me.rbMonto.Text = "Monto"
        Me.rbMonto.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnSeleccionarAnios)
        Me.GroupBox5.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox5.Location = New System.Drawing.Point(342, 62)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(270, 83)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tipo de Comparación"
        '
        'btnSeleccionarAnios
        '
        Me.btnSeleccionarAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnSeleccionarAnios.Location = New System.Drawing.Point(59, 52)
        Me.btnSeleccionarAnios.Name = "btnSeleccionarAnios"
        Me.btnSeleccionarAnios.Size = New System.Drawing.Size(153, 25)
        Me.btnSeleccionarAnios.TabIndex = 10
        Me.btnSeleccionarAnios.Text = "Seleccionar Años"
        Me.btnSeleccionarAnios.UseVisualStyleBackColor = True
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Items.AddRange(New Object() {"Mensual", "Comparativo Entre Lineas", "Comparativo Entre Periodos"})
        Me.cmbPeriodo.Location = New System.Drawing.Point(25, 22)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(221, 24)
        Me.cmbPeriodo.TabIndex = 2
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(12, 382)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(585, 150)
        Me.DataGridView1.TabIndex = 8
        Me.DataGridView1.Visible = False
        '
        'pnlAnios
        '
        Me.pnlAnios.Controls.Add(Me.GroupBox6)
        Me.pnlAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.pnlAnios.Location = New System.Drawing.Point(146, 392)
        Me.pnlAnios.Name = "pnlAnios"
        Me.pnlAnios.Size = New System.Drawing.Size(374, 220)
        Me.pnlAnios.TabIndex = 9
        Me.pnlAnios.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Controls.Add(Me.ckAnios)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox6.Location = New System.Drawing.Point(13, 10)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(348, 201)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Seleccione los Años a Comparar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(115, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 25)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ckAnios
        '
        Me.ckAnios.CheckOnClick = True
        Me.ckAnios.FormattingEnabled = True
        Me.ckAnios.Location = New System.Drawing.Point(19, 26)
        Me.ckAnios.Name = "ckAnios"
        Me.ckAnios.Size = New System.Drawing.Size(311, 118)
        Me.ckAnios.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtMesDesde)
        Me.GroupBox7.Controls.Add(Me.txtAnioDesde)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox7.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(230, 51)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Desde"
        '
        'txtMesDesde
        '
        Me.txtMesDesde.Location = New System.Drawing.Point(64, 20)
        Me.txtMesDesde.Mask = "00"
        Me.txtMesDesde.Name = "txtMesDesde"
        Me.txtMesDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtMesDesde.Size = New System.Drawing.Size(37, 24)
        Me.txtMesDesde.TabIndex = 5
        Me.txtMesDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Mes:"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtMesHasta)
        Me.GroupBox8.Controls.Add(Me.txtAnioHasta)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox8.Location = New System.Drawing.Point(252, 5)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(230, 51)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Hasta"
        '
        'txtMesHasta
        '
        Me.txtMesHasta.Location = New System.Drawing.Point(64, 20)
        Me.txtMesHasta.Mask = "00"
        Me.txtMesHasta.Name = "txtMesHasta"
        Me.txtMesHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtMesHasta.Size = New System.Drawing.Size(37, 24)
        Me.txtMesHasta.TabIndex = 5
        Me.txtMesHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnioHasta
        '
        Me.txtAnioHasta.Location = New System.Drawing.Point(148, 20)
        Me.txtAnioHasta.Mask = "0000"
        Me.txtAnioHasta.Name = "txtAnioHasta"
        Me.txtAnioHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtAnioHasta.Size = New System.Drawing.Size(62, 24)
        Me.txtAnioHasta.TabIndex = 5
        Me.txtAnioHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(106, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 18)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Año:"
        '
        'ComparacionesMensualesValorUnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 353)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbTipoGrafico)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.pnlAnios)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.Name = "ComparacionesMensualesValorUnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Comando"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAnios.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoGrafico As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckVarios As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonPellital As System.Windows.Forms.CheckBox
    Friend WithEvents ckFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckColorantes As System.Windows.Forms.CheckBox
    Friend WithEvents ckQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckConsolidado As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ckPorcentaje As System.Windows.Forms.CheckBox
    Friend WithEvents ckRotacion As System.Windows.Forms.CheckBox
    Friend WithEvents ckStock As System.Windows.Forms.CheckBox
    Friend WithEvents ckPrecio As System.Windows.Forms.CheckBox
    Friend WithEvents ckFactor As System.Windows.Forms.CheckBox
    Friend WithEvents ckPorcentajeAtrasos As System.Windows.Forms.CheckBox
    Friend WithEvents ckKilos As System.Windows.Forms.CheckBox
    Friend WithEvents ckAtrasados As System.Windows.Forms.CheckBox
    Friend WithEvents ckVenta As System.Windows.Forms.CheckBox
    Friend WithEvents ckPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents ckTodosValores As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAnioDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents rbMonto As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlAnios As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ckAnios As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSeleccionarAnios As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMesDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMesHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAnioHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ckPapel As System.Windows.Forms.CheckBox
    Friend WithEvents ckBiocidas As System.Windows.Forms.CheckBox
End Class
