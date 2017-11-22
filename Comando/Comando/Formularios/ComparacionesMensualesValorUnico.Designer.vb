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
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cmbTipoGrafico = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckVarios = New System.Windows.Forms.CheckBox()
        Me.ckFazonQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckFazonFarma = New System.Windows.Forms.CheckBox()
        Me.ckFazonPellital = New System.Windows.Forms.CheckBox()
        Me.ckFarma = New System.Windows.Forms.CheckBox()
        Me.ckColorantes = New System.Windows.Forms.CheckBox()
        Me.ckQuimicos = New System.Windows.Forms.CheckBox()
        Me.ckTodas = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTipoComparacion = New System.Windows.Forms.ComboBox()
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
        Me.txtAnio = New System.Windows.Forms.MaskedTextBox()
        Me.PanelMeses = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckSeptiembre = New System.Windows.Forms.CheckBox()
        Me.ckTodosMeses = New System.Windows.Forms.CheckBox()
        Me.ckJulio = New System.Windows.Forms.CheckBox()
        Me.ckAgosto = New System.Windows.Forms.CheckBox()
        Me.ckOctubre = New System.Windows.Forms.CheckBox()
        Me.ckJunio = New System.Windows.Forms.CheckBox()
        Me.ckMayo = New System.Windows.Forms.CheckBox()
        Me.ckEnero = New System.Windows.Forms.CheckBox()
        Me.ckAbril = New System.Windows.Forms.CheckBox()
        Me.ckNoviembre = New System.Windows.Forms.CheckBox()
        Me.ckMarzo = New System.Windows.Forms.CheckBox()
        Me.ckFebrero = New System.Windows.Forms.CheckBox()
        Me.ckDiciembre = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PanelMeses.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(575, 333)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(153, 38)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Generar Informe"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmbTipoGrafico
        '
        Me.cmbTipoGrafico.FormattingEnabled = True
        Me.cmbTipoGrafico.Items.AddRange(New Object() {"Barras", "Lineas"})
        Me.cmbTipoGrafico.Location = New System.Drawing.Point(301, 24)
        Me.cmbTipoGrafico.Name = "cmbTipoGrafico"
        Me.cmbTipoGrafico.Size = New System.Drawing.Size(117, 21)
        Me.cmbTipoGrafico.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo Gráfico"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckVarios)
        Me.GroupBox2.Controls.Add(Me.ckFazonQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckFazonFarma)
        Me.GroupBox2.Controls.Add(Me.ckFazonPellital)
        Me.GroupBox2.Controls.Add(Me.ckFarma)
        Me.GroupBox2.Controls.Add(Me.ckColorantes)
        Me.GroupBox2.Controls.Add(Me.ckQuimicos)
        Me.GroupBox2.Controls.Add(Me.ckTodas)
        Me.GroupBox2.Location = New System.Drawing.Point(611, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(139, 272)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Familias a Comparar"
        '
        'ckVarios
        '
        Me.ckVarios.AutoSize = True
        Me.ckVarios.Location = New System.Drawing.Point(19, 244)
        Me.ckVarios.Name = "ckVarios"
        Me.ckVarios.Size = New System.Drawing.Size(55, 17)
        Me.ckVarios.TabIndex = 0
        Me.ckVarios.Text = "Varios"
        Me.ckVarios.UseVisualStyleBackColor = True
        '
        'ckFazonQuimicos
        '
        Me.ckFazonQuimicos.AutoSize = True
        Me.ckFazonQuimicos.Location = New System.Drawing.Point(19, 213)
        Me.ckFazonQuimicos.Name = "ckFazonQuimicos"
        Me.ckFazonQuimicos.Size = New System.Drawing.Size(103, 17)
        Me.ckFazonQuimicos.TabIndex = 0
        Me.ckFazonQuimicos.Text = "Fazón Químicos"
        Me.ckFazonQuimicos.UseVisualStyleBackColor = True
        '
        'ckFazonFarma
        '
        Me.ckFazonFarma.AutoSize = True
        Me.ckFazonFarma.Location = New System.Drawing.Point(19, 182)
        Me.ckFazonFarma.Name = "ckFazonFarma"
        Me.ckFazonFarma.Size = New System.Drawing.Size(87, 17)
        Me.ckFazonFarma.TabIndex = 0
        Me.ckFazonFarma.Text = "Fazón Farma"
        Me.ckFazonFarma.UseVisualStyleBackColor = True
        '
        'ckFazonPellital
        '
        Me.ckFazonPellital.AutoSize = True
        Me.ckFazonPellital.Location = New System.Drawing.Point(19, 151)
        Me.ckFazonPellital.Name = "ckFazonPellital"
        Me.ckFazonPellital.Size = New System.Drawing.Size(88, 17)
        Me.ckFazonPellital.TabIndex = 0
        Me.ckFazonPellital.Text = "Fazon Pellital"
        Me.ckFazonPellital.UseVisualStyleBackColor = True
        '
        'ckFarma
        '
        Me.ckFarma.AutoSize = True
        Me.ckFarma.Location = New System.Drawing.Point(19, 120)
        Me.ckFarma.Name = "ckFarma"
        Me.ckFarma.Size = New System.Drawing.Size(55, 17)
        Me.ckFarma.TabIndex = 0
        Me.ckFarma.Text = "Farma"
        Me.ckFarma.UseVisualStyleBackColor = True
        '
        'ckColorantes
        '
        Me.ckColorantes.AutoSize = True
        Me.ckColorantes.Location = New System.Drawing.Point(19, 89)
        Me.ckColorantes.Name = "ckColorantes"
        Me.ckColorantes.Size = New System.Drawing.Size(76, 17)
        Me.ckColorantes.TabIndex = 0
        Me.ckColorantes.Text = "Colorantes"
        Me.ckColorantes.UseVisualStyleBackColor = True
        '
        'ckQuimicos
        '
        Me.ckQuimicos.AutoSize = True
        Me.ckQuimicos.Location = New System.Drawing.Point(19, 58)
        Me.ckQuimicos.Name = "ckQuimicos"
        Me.ckQuimicos.Size = New System.Drawing.Size(71, 17)
        Me.ckQuimicos.TabIndex = 0
        Me.ckQuimicos.Text = "Químicos"
        Me.ckQuimicos.UseVisualStyleBackColor = True
        '
        'ckTodas
        '
        Me.ckTodas.AutoSize = True
        Me.ckTodas.Location = New System.Drawing.Point(19, 27)
        Me.ckTodas.Name = "ckTodas"
        Me.ckTodas.Size = New System.Drawing.Size(56, 17)
        Me.ckTodas.TabIndex = 0
        Me.ckTodas.Text = "Todas"
        Me.ckTodas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(442, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Tipo Comparacion"
        '
        'cmbTipoComparacion
        '
        Me.cmbTipoComparacion.FormattingEnabled = True
        Me.cmbTipoComparacion.Items.AddRange(New Object() {"Por Familia", "Entre Familias"})
        Me.cmbTipoComparacion.Location = New System.Drawing.Point(543, 24)
        Me.cmbTipoComparacion.Name = "cmbTipoComparacion"
        Me.cmbTipoComparacion.Size = New System.Drawing.Size(117, 21)
        Me.cmbTipoComparacion.TabIndex = 2
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
        Me.GroupBox3.Location = New System.Drawing.Point(312, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 181)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Valores a Graficar"
        '
        'ckPorcentaje
        '
        Me.ckPorcentaje.AutoSize = True
        Me.ckPorcentaje.Location = New System.Drawing.Point(151, 77)
        Me.ckPorcentaje.Name = "ckPorcentaje"
        Me.ckPorcentaje.Size = New System.Drawing.Size(77, 17)
        Me.ckPorcentaje.TabIndex = 0
        Me.ckPorcentaje.Text = "Porcentaje"
        Me.ckPorcentaje.UseVisualStyleBackColor = True
        '
        'ckRotacion
        '
        Me.ckRotacion.AutoSize = True
        Me.ckRotacion.Location = New System.Drawing.Point(151, 54)
        Me.ckRotacion.Name = "ckRotacion"
        Me.ckRotacion.Size = New System.Drawing.Size(69, 17)
        Me.ckRotacion.TabIndex = 0
        Me.ckRotacion.Text = "Rotación"
        Me.ckRotacion.UseVisualStyleBackColor = True
        '
        'ckStock
        '
        Me.ckStock.AutoSize = True
        Me.ckStock.Location = New System.Drawing.Point(27, 146)
        Me.ckStock.Name = "ckStock"
        Me.ckStock.Size = New System.Drawing.Size(54, 17)
        Me.ckStock.TabIndex = 0
        Me.ckStock.Text = "Stock"
        Me.ckStock.UseVisualStyleBackColor = True
        '
        'ckPrecio
        '
        Me.ckPrecio.AutoSize = True
        Me.ckPrecio.Location = New System.Drawing.Point(27, 123)
        Me.ckPrecio.Name = "ckPrecio"
        Me.ckPrecio.Size = New System.Drawing.Size(103, 17)
        Me.ckPrecio.TabIndex = 0
        Me.ckPrecio.Text = "Precio Promedio"
        Me.ckPrecio.UseVisualStyleBackColor = True
        '
        'ckFactor
        '
        Me.ckFactor.AutoSize = True
        Me.ckFactor.Location = New System.Drawing.Point(27, 100)
        Me.ckFactor.Name = "ckFactor"
        Me.ckFactor.Size = New System.Drawing.Size(56, 17)
        Me.ckFactor.TabIndex = 0
        Me.ckFactor.Text = "Factor"
        Me.ckFactor.UseVisualStyleBackColor = True
        '
        'ckPorcentajeAtrasos
        '
        Me.ckPorcentajeAtrasos.AutoSize = True
        Me.ckPorcentajeAtrasos.Location = New System.Drawing.Point(151, 146)
        Me.ckPorcentajeAtrasos.Name = "ckPorcentajeAtrasos"
        Me.ckPorcentajeAtrasos.Size = New System.Drawing.Size(115, 17)
        Me.ckPorcentajeAtrasos.TabIndex = 0
        Me.ckPorcentajeAtrasos.Text = "Porcentaje Atrasos"
        Me.ckPorcentajeAtrasos.UseVisualStyleBackColor = True
        '
        'ckKilos
        '
        Me.ckKilos.AutoSize = True
        Me.ckKilos.Location = New System.Drawing.Point(27, 77)
        Me.ckKilos.Name = "ckKilos"
        Me.ckKilos.Size = New System.Drawing.Size(48, 17)
        Me.ckKilos.TabIndex = 0
        Me.ckKilos.Text = "Kilos"
        Me.ckKilos.UseVisualStyleBackColor = True
        '
        'ckAtrasados
        '
        Me.ckAtrasados.AutoSize = True
        Me.ckAtrasados.Location = New System.Drawing.Point(151, 123)
        Me.ckAtrasados.Name = "ckAtrasados"
        Me.ckAtrasados.Size = New System.Drawing.Size(114, 17)
        Me.ckAtrasados.TabIndex = 0
        Me.ckAtrasados.Text = "Pedidos Atrasados"
        Me.ckAtrasados.UseVisualStyleBackColor = True
        '
        'ckVenta
        '
        Me.ckVenta.AutoSize = True
        Me.ckVenta.Location = New System.Drawing.Point(27, 54)
        Me.ckVenta.Name = "ckVenta"
        Me.ckVenta.Size = New System.Drawing.Size(84, 17)
        Me.ckVenta.TabIndex = 0
        Me.ckVenta.Text = "Venta (U$S)"
        Me.ckVenta.UseVisualStyleBackColor = True
        '
        'ckPedidos
        '
        Me.ckPedidos.AutoSize = True
        Me.ckPedidos.Location = New System.Drawing.Point(151, 100)
        Me.ckPedidos.Name = "ckPedidos"
        Me.ckPedidos.Size = New System.Drawing.Size(64, 17)
        Me.ckPedidos.TabIndex = 0
        Me.ckPedidos.Text = "Pedidos"
        Me.ckPedidos.UseVisualStyleBackColor = True
        '
        'ckTodosValores
        '
        Me.ckTodosValores.AutoSize = True
        Me.ckTodosValores.Location = New System.Drawing.Point(27, 31)
        Me.ckTodosValores.Name = "ckTodosValores"
        Me.ckTodosValores.Size = New System.Drawing.Size(56, 17)
        Me.ckTodosValores.TabIndex = 0
        Me.ckTodosValores.Text = "Todas"
        Me.ckTodosValores.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(108, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(142, 26)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtAnio.Size = New System.Drawing.Size(62, 20)
        Me.txtAnio.TabIndex = 5
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PanelMeses
        '
        Me.PanelMeses.Controls.Add(Me.GroupBox1)
        Me.PanelMeses.Location = New System.Drawing.Point(43, 109)
        Me.PanelMeses.Name = "PanelMeses"
        Me.PanelMeses.Size = New System.Drawing.Size(254, 215)
        Me.PanelMeses.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckSeptiembre)
        Me.GroupBox1.Controls.Add(Me.ckTodosMeses)
        Me.GroupBox1.Controls.Add(Me.ckJulio)
        Me.GroupBox1.Controls.Add(Me.ckAgosto)
        Me.GroupBox1.Controls.Add(Me.ckOctubre)
        Me.GroupBox1.Controls.Add(Me.ckJunio)
        Me.GroupBox1.Controls.Add(Me.ckMayo)
        Me.GroupBox1.Controls.Add(Me.ckEnero)
        Me.GroupBox1.Controls.Add(Me.ckAbril)
        Me.GroupBox1.Controls.Add(Me.ckNoviembre)
        Me.GroupBox1.Controls.Add(Me.ckMarzo)
        Me.GroupBox1.Controls.Add(Me.ckFebrero)
        Me.GroupBox1.Controls.Add(Me.ckDiciembre)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccion de Meses a Graficar"
        '
        'ckSeptiembre
        '
        Me.ckSeptiembre.AutoSize = True
        Me.ckSeptiembre.Location = New System.Drawing.Point(144, 103)
        Me.ckSeptiembre.Name = "ckSeptiembre"
        Me.ckSeptiembre.Size = New System.Drawing.Size(79, 17)
        Me.ckSeptiembre.TabIndex = 0
        Me.ckSeptiembre.Text = "Septiembre"
        Me.ckSeptiembre.UseVisualStyleBackColor = True
        '
        'ckTodosMeses
        '
        Me.ckTodosMeses.AutoSize = True
        Me.ckTodosMeses.Location = New System.Drawing.Point(53, 36)
        Me.ckTodosMeses.Name = "ckTodosMeses"
        Me.ckTodosMeses.Size = New System.Drawing.Size(56, 17)
        Me.ckTodosMeses.TabIndex = 0
        Me.ckTodosMeses.Text = "Todos"
        Me.ckTodosMeses.UseVisualStyleBackColor = True
        '
        'ckJulio
        '
        Me.ckJulio.AutoSize = True
        Me.ckJulio.Location = New System.Drawing.Point(144, 57)
        Me.ckJulio.Name = "ckJulio"
        Me.ckJulio.Size = New System.Drawing.Size(47, 17)
        Me.ckJulio.TabIndex = 0
        Me.ckJulio.Text = "Julio"
        Me.ckJulio.UseVisualStyleBackColor = True
        '
        'ckAgosto
        '
        Me.ckAgosto.AutoSize = True
        Me.ckAgosto.Location = New System.Drawing.Point(144, 80)
        Me.ckAgosto.Name = "ckAgosto"
        Me.ckAgosto.Size = New System.Drawing.Size(59, 17)
        Me.ckAgosto.TabIndex = 0
        Me.ckAgosto.Text = "Agosto"
        Me.ckAgosto.UseVisualStyleBackColor = True
        '
        'ckOctubre
        '
        Me.ckOctubre.AutoSize = True
        Me.ckOctubre.Location = New System.Drawing.Point(144, 126)
        Me.ckOctubre.Name = "ckOctubre"
        Me.ckOctubre.Size = New System.Drawing.Size(64, 17)
        Me.ckOctubre.TabIndex = 0
        Me.ckOctubre.Text = "Octubre"
        Me.ckOctubre.UseVisualStyleBackColor = True
        '
        'ckJunio
        '
        Me.ckJunio.AutoSize = True
        Me.ckJunio.Location = New System.Drawing.Point(53, 172)
        Me.ckJunio.Name = "ckJunio"
        Me.ckJunio.Size = New System.Drawing.Size(51, 17)
        Me.ckJunio.TabIndex = 0
        Me.ckJunio.Text = "Junio"
        Me.ckJunio.UseVisualStyleBackColor = True
        '
        'ckMayo
        '
        Me.ckMayo.AutoSize = True
        Me.ckMayo.Location = New System.Drawing.Point(53, 151)
        Me.ckMayo.Name = "ckMayo"
        Me.ckMayo.Size = New System.Drawing.Size(52, 17)
        Me.ckMayo.TabIndex = 0
        Me.ckMayo.Text = "Mayo"
        Me.ckMayo.UseVisualStyleBackColor = True
        '
        'ckEnero
        '
        Me.ckEnero.AutoSize = True
        Me.ckEnero.Location = New System.Drawing.Point(53, 59)
        Me.ckEnero.Name = "ckEnero"
        Me.ckEnero.Size = New System.Drawing.Size(54, 17)
        Me.ckEnero.TabIndex = 0
        Me.ckEnero.Text = "Enero"
        Me.ckEnero.UseVisualStyleBackColor = True
        '
        'ckAbril
        '
        Me.ckAbril.AutoSize = True
        Me.ckAbril.Location = New System.Drawing.Point(53, 128)
        Me.ckAbril.Name = "ckAbril"
        Me.ckAbril.Size = New System.Drawing.Size(46, 17)
        Me.ckAbril.TabIndex = 0
        Me.ckAbril.Text = "Abril"
        Me.ckAbril.UseVisualStyleBackColor = True
        '
        'ckNoviembre
        '
        Me.ckNoviembre.AutoSize = True
        Me.ckNoviembre.Location = New System.Drawing.Point(144, 149)
        Me.ckNoviembre.Name = "ckNoviembre"
        Me.ckNoviembre.Size = New System.Drawing.Size(77, 17)
        Me.ckNoviembre.TabIndex = 0
        Me.ckNoviembre.Text = "Noviembre"
        Me.ckNoviembre.UseVisualStyleBackColor = True
        '
        'ckMarzo
        '
        Me.ckMarzo.AutoSize = True
        Me.ckMarzo.Location = New System.Drawing.Point(53, 105)
        Me.ckMarzo.Name = "ckMarzo"
        Me.ckMarzo.Size = New System.Drawing.Size(55, 17)
        Me.ckMarzo.TabIndex = 0
        Me.ckMarzo.Text = "Marzo"
        Me.ckMarzo.UseVisualStyleBackColor = True
        '
        'ckFebrero
        '
        Me.ckFebrero.AutoSize = True
        Me.ckFebrero.Location = New System.Drawing.Point(53, 82)
        Me.ckFebrero.Name = "ckFebrero"
        Me.ckFebrero.Size = New System.Drawing.Size(62, 17)
        Me.ckFebrero.TabIndex = 0
        Me.ckFebrero.Text = "Febrero"
        Me.ckFebrero.UseVisualStyleBackColor = True
        '
        'ckDiciembre
        '
        Me.ckDiciembre.AutoSize = True
        Me.ckDiciembre.Location = New System.Drawing.Point(144, 172)
        Me.ckDiciembre.Name = "ckDiciembre"
        Me.ckDiciembre.Size = New System.Drawing.Size(73, 17)
        Me.ckDiciembre.TabIndex = 0
        Me.ckDiciembre.Text = "Diciembre"
        Me.ckDiciembre.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Location = New System.Drawing.Point(45, 52)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(252, 51)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Unidad"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(58, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Monto"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(134, 21)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(76, 17)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.Text = "Porcentaje"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RadioButton3)
        Me.GroupBox5.Controls.Add(Me.RadioButton4)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.ComboBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(312, 52)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(293, 85)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuración Gráfico"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(26, 49)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(131, 17)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.Text = "Graficos por Separado"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(26, 26)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(122, 17)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "En un mismo Gráfico"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(167, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Período Comparación"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Mensual", "Anual", "Comparativo Mensual"})
        Me.ComboBox1.Location = New System.Drawing.Point(164, 45)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(45, 379)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(704, 94)
        Me.DataGridView1.TabIndex = 8
        '
        'ComparacionesMensualesValorUnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 485)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PanelMeses)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbTipoComparacion)
        Me.Controls.Add(Me.cmbTipoGrafico)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGenerar)
        Me.MaximizeBox = False
        Me.Name = "ComparacionesMensualesValorUnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ComparacionesMensuales"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelMeses.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoGrafico As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckVarios As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckFazonPellital As System.Windows.Forms.CheckBox
    Friend WithEvents ckFarma As System.Windows.Forms.CheckBox
    Friend WithEvents ckColorantes As System.Windows.Forms.CheckBox
    Friend WithEvents ckQuimicos As System.Windows.Forms.CheckBox
    Friend WithEvents ckTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoComparacion As System.Windows.Forms.ComboBox
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
    Friend WithEvents txtAnio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PanelMeses As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckSeptiembre As System.Windows.Forms.CheckBox
    Friend WithEvents ckTodosMeses As System.Windows.Forms.CheckBox
    Friend WithEvents ckJulio As System.Windows.Forms.CheckBox
    Friend WithEvents ckAgosto As System.Windows.Forms.CheckBox
    Friend WithEvents ckOctubre As System.Windows.Forms.CheckBox
    Friend WithEvents ckJunio As System.Windows.Forms.CheckBox
    Friend WithEvents ckMayo As System.Windows.Forms.CheckBox
    Friend WithEvents ckEnero As System.Windows.Forms.CheckBox
    Friend WithEvents ckAbril As System.Windows.Forms.CheckBox
    Friend WithEvents ckNoviembre As System.Windows.Forms.CheckBox
    Friend WithEvents ckMarzo As System.Windows.Forms.CheckBox
    Friend WithEvents ckFebrero As System.Windows.Forms.CheckBox
    Friend WithEvents ckDiciembre As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
