﻿Imports Util

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoEnsayosLaboratorioMP
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbPool = New System.Windows.Forms.RadioButton()
        Me.rbFinal = New System.Windows.Forms.RadioButton()
        Me.txtPool = New System.Windows.Forms.TextBox()
        Me.btnPoolEnsayos = New System.Windows.Forms.Button()
        Me.txtInforme = New System.Windows.Forms.TextBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtEtapa = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLoteProveedor = New System.Windows.Forms.TextBox()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblIDPool = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescMP = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbDatosAdicionales = New System.Windows.Forms.GroupBox()
        Me.txtMeses = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFechaRevalida = New System.Windows.Forms.MaskedTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtEspecifActual = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtEspecifOrig = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRevalida = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFechaVto = New System.Windows.Forms.MaskedTextBox()
        Me.lblDescEtapa = New System.Windows.Forms.Label()
        Me.lblTipoProceso = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCantidadEtiquetas = New System.Windows.Forms.TextBox()
        Me.txtDesvio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.txtConfecciono = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEnvases = New System.Windows.Forms.TextBox()
        Me.txtPaginas = New System.Windows.Forms.TextBox()
        Me.txtLibros = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtOOS = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLotePartida = New System.Windows.Forms.TextBox()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNotasCertAnalisis = New System.Windows.Forms.Button()
        Me.btnRevalida = New System.Windows.Forms.Button()
        Me.btnNotasAnteriores = New System.Windows.Forms.Button()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.btnImprimirEnsayosIngresados = New System.Windows.Forms.Button()
        Me.btnActualizarEspecif = New System.Windows.Forms.Button()
        Me.btnNotas = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvEnsayos = New Util.DBDataGridView()
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
        Me.OperadorIniciales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperadorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic1dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic2dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormulaAdic3dec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbDatosAdicionales.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(998, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(808, 12)
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
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO DE ENSAYOS DE MATERIA PRIMA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPool)
        Me.GroupBox1.Controls.Add(Me.rbFinal)
        Me.GroupBox1.Controls.Add(Me.txtPool)
        Me.GroupBox1.Controls.Add(Me.btnPoolEnsayos)
        Me.GroupBox1.Controls.Add(Me.txtInforme)
        Me.GroupBox1.Controls.Add(Me.txtOrden)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtEtapa)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtLoteProveedor)
        Me.GroupBox1.Controls.Add(Me.txtPartida)
        Me.GroupBox1.Controls.Add(Me.lblIDPool)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDescMP)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.gbDatosAdicionales)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(989, 70)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Materia Prima"
        '
        'rbPool
        '
        Me.rbPool.AutoSize = True
        Me.rbPool.Location = New System.Drawing.Point(371, 46)
        Me.rbPool.Name = "rbPool"
        Me.rbPool.Size = New System.Drawing.Size(54, 17)
        Me.rbPool.TabIndex = 5
        Me.rbPool.TabStop = True
        Me.rbPool.Text = "POOL"
        Me.rbPool.UseVisualStyleBackColor = True
        '
        'rbFinal
        '
        Me.rbFinal.AutoSize = True
        Me.rbFinal.Location = New System.Drawing.Point(295, 46)
        Me.rbFinal.Name = "rbFinal"
        Me.rbFinal.Size = New System.Drawing.Size(55, 17)
        Me.rbFinal.TabIndex = 5
        Me.rbFinal.TabStop = True
        Me.rbFinal.Text = "FINAL"
        Me.rbFinal.UseVisualStyleBackColor = True
        '
        'txtPool
        '
        Me.txtPool.Location = New System.Drawing.Point(439, 44)
        Me.txtPool.MaxLength = 2
        Me.txtPool.Name = "txtPool"
        Me.txtPool.Size = New System.Drawing.Size(30, 20)
        Me.txtPool.TabIndex = 2
        Me.txtPool.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPoolEnsayos
        '
        Me.btnPoolEnsayos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPoolEnsayos.Location = New System.Drawing.Point(741, 56)
        Me.btnPoolEnsayos.Name = "btnPoolEnsayos"
        Me.btnPoolEnsayos.Size = New System.Drawing.Size(192, 23)
        Me.btnPoolEnsayos.TabIndex = 3
        Me.btnPoolEnsayos.Text = "INGRESO POOL DE ENSAYOS"
        Me.btnPoolEnsayos.UseVisualStyleBackColor = True
        Me.btnPoolEnsayos.Visible = False
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(686, 20)
        Me.txtInforme.MaxLength = 6
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.Size = New System.Drawing.Size(49, 20)
        Me.txtInforme.TabIndex = 2
        Me.txtInforme.Text = "999999"
        Me.txtInforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(586, 20)
        Me.txtOrden.MaxLength = 6
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(48, 20)
        Me.txtOrden.TabIndex = 2
        Me.txtOrden.Text = "999999"
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(638, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(45, 13)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Informe:"
        '
        'txtEtapa
        '
        Me.txtEtapa.Location = New System.Drawing.Point(711, 57)
        Me.txtEtapa.MaxLength = 2
        Me.txtEtapa.Name = "txtEtapa"
        Me.txtEtapa.Size = New System.Drawing.Size(24, 20)
        Me.txtEtapa.TabIndex = 2
        Me.txtEtapa.Text = "99"
        Me.txtEtapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEtapa.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(559, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(25, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "OC:"
        '
        'txtLoteProveedor
        '
        Me.txtLoteProveedor.Location = New System.Drawing.Point(161, 44)
        Me.txtLoteProveedor.MaxLength = 30
        Me.txtLoteProveedor.Name = "txtLoteProveedor"
        Me.txtLoteProveedor.Size = New System.Drawing.Size(115, 20)
        Me.txtLoteProveedor.TabIndex = 2
        Me.txtLoteProveedor.Text = "300000"
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(57, 44)
        Me.txtPartida.MaxLength = 6
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(52, 20)
        Me.txtPartida.TabIndex = 2
        Me.txtPartida.Text = "300000"
        Me.txtPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIDPool
        '
        Me.lblIDPool.AutoSize = True
        Me.lblIDPool.Location = New System.Drawing.Point(777, 24)
        Me.lblIDPool.Name = "lblIDPool"
        Me.lblIDPool.Size = New System.Drawing.Size(38, 13)
        Me.lblIDPool.TabIndex = 0
        Me.lblIDPool.Text = "Etapa:"
        Me.lblIDPool.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(670, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Etapa:"
        Me.Label5.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(478, 19)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Text = "12021990"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(115, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "L Prov:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(57, 19)
        Me.txtCodigo.Mask = ">LL-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "PT225100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Lote:"
        '
        'txtDescMP
        '
        Me.txtDescMP.BackColor = System.Drawing.Color.Cyan
        Me.txtDescMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDescMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescMP.Location = New System.Drawing.Point(123, 19)
        Me.txtDescMP.Name = "txtDescMP"
        Me.txtDescMP.Size = New System.Drawing.Size(309, 20)
        Me.txtDescMP.TabIndex = 0
        Me.txtDescMP.Text = "MICRONIZADO"
        Me.txtDescMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(436, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Código:"
        '
        'gbDatosAdicionales
        '
        Me.gbDatosAdicionales.Controls.Add(Me.txtMeses)
        Me.gbDatosAdicionales.Controls.Add(Me.Label24)
        Me.gbDatosAdicionales.Controls.Add(Me.txtFechaRevalida)
        Me.gbDatosAdicionales.Controls.Add(Me.Label22)
        Me.gbDatosAdicionales.Controls.Add(Me.txtKilos)
        Me.gbDatosAdicionales.Controls.Add(Me.Label23)
        Me.gbDatosAdicionales.Controls.Add(Me.txtEspecifActual)
        Me.gbDatosAdicionales.Controls.Add(Me.Label25)
        Me.gbDatosAdicionales.Controls.Add(Me.txtEspecifOrig)
        Me.gbDatosAdicionales.Controls.Add(Me.Label8)
        Me.gbDatosAdicionales.Controls.Add(Me.txtRevalida)
        Me.gbDatosAdicionales.Controls.Add(Me.Label9)
        Me.gbDatosAdicionales.Location = New System.Drawing.Point(16, 61)
        Me.gbDatosAdicionales.Name = "gbDatosAdicionales"
        Me.gbDatosAdicionales.Size = New System.Drawing.Size(519, 17)
        Me.gbDatosAdicionales.TabIndex = 4
        Me.gbDatosAdicionales.TabStop = False
        Me.gbDatosAdicionales.Visible = False
        '
        'txtMeses
        '
        Me.txtMeses.Location = New System.Drawing.Point(269, 11)
        Me.txtMeses.MaxLength = 2
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.ReadOnly = True
        Me.txtMeses.Size = New System.Drawing.Size(24, 20)
        Me.txtMeses.TabIndex = 2
        Me.txtMeses.Text = "99"
        Me.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Kilos:"
        '
        'txtFechaRevalida
        '
        Me.txtFechaRevalida.Location = New System.Drawing.Point(161, 11)
        Me.txtFechaRevalida.Mask = "00/00/0000"
        Me.txtFechaRevalida.Name = "txtFechaRevalida"
        Me.txtFechaRevalida.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaRevalida.ReadOnly = True
        Me.txtFechaRevalida.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaRevalida.TabIndex = 3
        Me.txtFechaRevalida.Text = "12021990"
        Me.txtFechaRevalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(386, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Orig:"
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(40, 11)
        Me.txtKilos.MaxLength = 2
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.ReadOnly = True
        Me.txtKilos.Size = New System.Drawing.Size(53, 20)
        Me.txtKilos.TabIndex = 2
        Me.txtKilos.Text = "99"
        Me.txtKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(448, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(26, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Act:"
        '
        'txtEspecifActual
        '
        Me.txtEspecifActual.Location = New System.Drawing.Point(479, 11)
        Me.txtEspecifActual.MaxLength = 2
        Me.txtEspecifActual.Name = "txtEspecifActual"
        Me.txtEspecifActual.ReadOnly = True
        Me.txtEspecifActual.Size = New System.Drawing.Size(24, 20)
        Me.txtEspecifActual.TabIndex = 2
        Me.txtEspecifActual.Text = "99"
        Me.txtEspecifActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(231, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Meses:"
        '
        'txtEspecifOrig
        '
        Me.txtEspecifOrig.Location = New System.Drawing.Point(417, 11)
        Me.txtEspecifOrig.MaxLength = 2
        Me.txtEspecifOrig.Name = "txtEspecifOrig"
        Me.txtEspecifOrig.ReadOnly = True
        Me.txtEspecifOrig.Size = New System.Drawing.Size(24, 20)
        Me.txtEspecifOrig.TabIndex = 2
        Me.txtEspecifOrig.Text = "99"
        Me.txtEspecifOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(99, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Rev:"
        '
        'txtRevalida
        '
        Me.txtRevalida.Location = New System.Drawing.Point(132, 11)
        Me.txtRevalida.MaxLength = 2
        Me.txtRevalida.Name = "txtRevalida"
        Me.txtRevalida.ReadOnly = True
        Me.txtRevalida.Size = New System.Drawing.Size(24, 20)
        Me.txtRevalida.TabIndex = 2
        Me.txtRevalida.Text = "99"
        Me.txtRevalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(306, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Especificación:"
        '
        'txtFechaVto
        '
        Me.txtFechaVto.Location = New System.Drawing.Point(125, 115)
        Me.txtFechaVto.Mask = "00/00/0000"
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto.ReadOnly = True
        Me.txtFechaVto.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaVto.TabIndex = 1
        Me.txtFechaVto.Text = "12021990"
        Me.txtFechaVto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFechaVto.Visible = False
        '
        'lblDescEtapa
        '
        Me.lblDescEtapa.BackColor = System.Drawing.Color.Cyan
        Me.lblDescEtapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescEtapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescEtapa.Location = New System.Drawing.Point(28, 104)
        Me.lblDescEtapa.Name = "lblDescEtapa"
        Me.lblDescEtapa.Size = New System.Drawing.Size(309, 20)
        Me.lblDescEtapa.TabIndex = 0
        Me.lblDescEtapa.Text = "MICRONIZADO"
        Me.lblDescEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDescEtapa.Visible = False
        '
        'lblTipoProceso
        '
        Me.lblTipoProceso.BackColor = System.Drawing.Color.Cyan
        Me.lblTipoProceso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoProceso.Location = New System.Drawing.Point(28, 104)
        Me.lblTipoProceso.Name = "lblTipoProceso"
        Me.lblTipoProceso.Size = New System.Drawing.Size(309, 20)
        Me.lblTipoProceso.TabIndex = 0
        Me.lblTipoProceso.Text = "MICRONIZADO"
        Me.lblTipoProceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTipoProceso.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(139, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "F. Vto:"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(146, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Tipo Proceso:"
        Me.Label15.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(148, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Desc. Etapa:"
        Me.Label7.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCantidadEtiquetas)
        Me.GroupBox2.Controls.Add(Me.txtDesvio)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtArchivo)
        Me.GroupBox2.Controls.Add(Me.txtConfecciono)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtEnvases)
        Me.GroupBox2.Controls.Add(Me.txtPaginas)
        Me.GroupBox2.Controls.Add(Me.txtLibros)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtOOS)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 95)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'txtCantidadEtiquetas
        '
        Me.txtCantidadEtiquetas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadEtiquetas.Location = New System.Drawing.Point(344, 42)
        Me.txtCantidadEtiquetas.MaxLength = 3
        Me.txtCantidadEtiquetas.Name = "txtCantidadEtiquetas"
        Me.txtCantidadEtiquetas.Size = New System.Drawing.Size(40, 20)
        Me.txtCantidadEtiquetas.TabIndex = 2
        Me.txtCantidadEtiquetas.Text = "300000"
        Me.txtCantidadEtiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesvio
        '
        Me.txtDesvio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesvio.Location = New System.Drawing.Point(207, 42)
        Me.txtDesvio.MaxLength = 10
        Me.txtDesvio.Name = "txtDesvio"
        Me.txtDesvio.Size = New System.Drawing.Size(66, 20)
        Me.txtDesvio.TabIndex = 2
        Me.txtDesvio.Text = "300000"
        Me.txtDesvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Desvío Nº:"
        '
        'txtArchivo
        '
        Me.txtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchivo.Location = New System.Drawing.Point(63, 68)
        Me.txtArchivo.MaxLength = 50
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(220, 20)
        Me.txtArchivo.TabIndex = 2
        Me.txtArchivo.Text = "300000"
        '
        'txtConfecciono
        '
        Me.txtConfecciono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfecciono.Location = New System.Drawing.Point(365, 68)
        Me.txtConfecciono.MaxLength = 50
        Me.txtConfecciono.Name = "txtConfecciono"
        Me.txtConfecciono.Size = New System.Drawing.Size(95, 20)
        Me.txtConfecciono.TabIndex = 2
        Me.txtConfecciono.Text = "300000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Archivo:"
        '
        'txtEnvases
        '
        Me.txtEnvases.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEnvases.Location = New System.Drawing.Point(329, 13)
        Me.txtEnvases.MaxLength = 50
        Me.txtEnvases.Name = "txtEnvases"
        Me.txtEnvases.Size = New System.Drawing.Size(143, 20)
        Me.txtEnvases.TabIndex = 2
        Me.txtEnvases.Text = "300000"
        Me.txtEnvases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaginas
        '
        Me.txtPaginas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaginas.Location = New System.Drawing.Point(188, 13)
        Me.txtPaginas.MaxLength = 20
        Me.txtPaginas.Name = "txtPaginas"
        Me.txtPaginas.Size = New System.Drawing.Size(70, 20)
        Me.txtPaginas.TabIndex = 2
        Me.txtPaginas.Text = "300000"
        Me.txtPaginas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLibros
        '
        Me.txtLibros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLibros.Location = New System.Drawing.Point(63, 13)
        Me.txtLibros.MaxLength = 20
        Me.txtLibros.Name = "txtLibros"
        Me.txtLibros.Size = New System.Drawing.Size(70, 20)
        Me.txtLibros.TabIndex = 2
        Me.txtLibros.Text = "300000"
        Me.txtLibros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(264, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Nº Envases:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(141, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Páginas"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(282, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Cant. Etiq:"
        '
        'txtOOS
        '
        Me.txtOOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOOS.Location = New System.Drawing.Point(63, 42)
        Me.txtOOS.MaxLength = 10
        Me.txtOOS.Name = "txtOOS"
        Me.txtOOS.Size = New System.Drawing.Size(70, 20)
        Me.txtOOS.TabIndex = 2
        Me.txtOOS.Text = "300000"
        Me.txtOOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Libros:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(289, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Confeccionó:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "OOS Nº:"
        '
        'txtLotePartida
        '
        Me.txtLotePartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotePartida.Location = New System.Drawing.Point(52, 125)
        Me.txtLotePartida.MaxLength = 6
        Me.txtLotePartida.Name = "txtLotePartida"
        Me.txtLotePartida.Size = New System.Drawing.Size(70, 20)
        Me.txtLotePartida.TabIndex = 2
        Me.txtLotePartida.Text = "300000"
        Me.txtLotePartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLotePartida.Visible = False
        '
        'txtComponente
        '
        Me.txtComponente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComponente.Location = New System.Drawing.Point(52, 125)
        Me.txtComponente.MaxLength = 12
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(70, 20)
        Me.txtComponente.TabIndex = 2
        Me.txtComponente.Text = "300000"
        Me.txtComponente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtComponente.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(53, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Lote/Partida:"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(52, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Componente:"
        Me.Label19.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnConsulta)
        Me.GroupBox3.Controls.Add(Me.btnGrabar)
        Me.GroupBox3.Controls.Add(Me.btnNotasCertAnalisis)
        Me.GroupBox3.Controls.Add(Me.btnRevalida)
        Me.GroupBox3.Controls.Add(Me.btnNotasAnteriores)
        Me.GroupBox3.Controls.Add(Me.txtFechaVto)
        Me.GroupBox3.Controls.Add(Me.btnReimprimir)
        Me.GroupBox3.Controls.Add(Me.txtLotePartida)
        Me.GroupBox3.Controls.Add(Me.txtComponente)
        Me.GroupBox3.Controls.Add(Me.btnImprimirEnsayosIngresados)
        Me.GroupBox3.Controls.Add(Me.lblDescEtapa)
        Me.GroupBox3.Controls.Add(Me.lblTipoProceso)
        Me.GroupBox3.Controls.Add(Me.btnActualizarEspecif)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.btnNotas)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.btnCerrar)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.btnLimpiar)
        Me.GroupBox3.Location = New System.Drawing.Point(596, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 94)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(10, 46)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(109, 30)
        Me.btnConsulta.TabIndex = 3
        Me.btnConsulta.Text = "CONSULTA"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(125, 13)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(109, 30)
        Me.btnGrabar.TabIndex = 0
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNotasCertAnalisis
        '
        Me.btnNotasCertAnalisis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotasCertAnalisis.Location = New System.Drawing.Point(202, 109)
        Me.btnNotasCertAnalisis.Name = "btnNotasCertAnalisis"
        Me.btnNotasCertAnalisis.Size = New System.Drawing.Size(224, 30)
        Me.btnNotasCertAnalisis.TabIndex = 0
        Me.btnNotasCertAnalisis.Text = "NOTAS CERTIFICADO ANÁLISIS"
        Me.btnNotasCertAnalisis.UseVisualStyleBackColor = True
        Me.btnNotasCertAnalisis.Visible = False
        '
        'btnRevalida
        '
        Me.btnRevalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevalida.Location = New System.Drawing.Point(224, 109)
        Me.btnRevalida.Name = "btnRevalida"
        Me.btnRevalida.Size = New System.Drawing.Size(181, 30)
        Me.btnRevalida.TabIndex = 0
        Me.btnRevalida.Text = "REVALIDAR PROD. TERMINADO"
        Me.btnRevalida.UseVisualStyleBackColor = True
        Me.btnRevalida.Visible = False
        '
        'btnNotasAnteriores
        '
        Me.btnNotasAnteriores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotasAnteriores.Location = New System.Drawing.Point(224, 109)
        Me.btnNotasAnteriores.Name = "btnNotasAnteriores"
        Me.btnNotasAnteriores.Size = New System.Drawing.Size(181, 30)
        Me.btnNotasAnteriores.TabIndex = 0
        Me.btnNotasAnteriores.Text = "NOTAS ANTERIORES"
        Me.btnNotasAnteriores.UseVisualStyleBackColor = True
        Me.btnNotasAnteriores.Visible = False
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.Location = New System.Drawing.Point(202, 109)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(224, 30)
        Me.btnReimprimir.TabIndex = 0
        Me.btnReimprimir.Text = "REIMPRIMIR RESULTADOS DE ENSAYOS"
        Me.btnReimprimir.UseVisualStyleBackColor = True
        Me.btnReimprimir.Visible = False
        '
        'btnImprimirEnsayosIngresados
        '
        Me.btnImprimirEnsayosIngresados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirEnsayosIngresados.Location = New System.Drawing.Point(125, 46)
        Me.btnImprimirEnsayosIngresados.Name = "btnImprimirEnsayosIngresados"
        Me.btnImprimirEnsayosIngresados.Size = New System.Drawing.Size(224, 30)
        Me.btnImprimirEnsayosIngresados.TabIndex = 0
        Me.btnImprimirEnsayosIngresados.Text = "VER PDF ENSAYOS INGRESADOS"
        Me.btnImprimirEnsayosIngresados.UseVisualStyleBackColor = True
        Me.btnImprimirEnsayosIngresados.Visible = False
        '
        'btnActualizarEspecif
        '
        Me.btnActualizarEspecif.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarEspecif.Location = New System.Drawing.Point(224, 109)
        Me.btnActualizarEspecif.Name = "btnActualizarEspecif"
        Me.btnActualizarEspecif.Size = New System.Drawing.Size(181, 30)
        Me.btnActualizarEspecif.TabIndex = 0
        Me.btnActualizarEspecif.Text = "ACTUALIZAR ESPECIFICACIONES"
        Me.btnActualizarEspecif.UseVisualStyleBackColor = True
        Me.btnActualizarEspecif.Visible = False
        '
        'btnNotas
        '
        Me.btnNotas.Location = New System.Drawing.Point(260, 109)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(109, 30)
        Me.btnNotas.TabIndex = 0
        Me.btnNotas.Text = "NOTAS"
        Me.btnNotas.UseVisualStyleBackColor = True
        Me.btnNotas.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(240, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(109, 30)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(10, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(109, 30)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvEnsayos, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 49)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(998, 454)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'dgvEnsayos
        '
        Me.dgvEnsayos.AllowUserToAddRows = False
        Me.dgvEnsayos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnsayos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEnsayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnsayos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Especificacion, Me.Farmacopea, Me.Valor, Me.ValorBandera, Me.Resultado, Me.Parametro, Me.Descripcion, Me.TipoEspecif, Me.DesdeEspecif, Me.HastaEspecif, Me.UnidadEspecif, Me.MenorIgualEspecif, Me.InformaEspecif, Me.Observaciones, Me.FormulaEspecif, Me.Variable1, Me.Variable2, Me.Variable3, Me.Variable4, Me.Variable5, Me.Variable6, Me.Variable7, Me.Variable8, Me.Variable9, Me.Variable10, Me.VariableValor1, Me.VariableValor2, Me.VariableValor3, Me.VariableValor4, Me.VariableValor5, Me.VariableValor6, Me.VariableValor7, Me.VariableValor8, Me.VariableValor9, Me.VariableValor10, Me.EspecificacionIngles, Me.Decimales, Me.OperadorIniciales, Me.OperadorID, Me.FormulaAdic1, Me.FormulaAdic2, Me.FormulaAdic3, Me.FormulaAdic1dec, Me.FormulaAdic2dec, Me.FormulaAdic3dec})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnsayos.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEnsayos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEnsayos.DoubleBuffered = True
        Me.dgvEnsayos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnsayos.Location = New System.Drawing.Point(3, 79)
        Me.dgvEnsayos.Name = "dgvEnsayos"
        Me.dgvEnsayos.OrdenamientoColumnasHabilitado = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnsayos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEnsayos.RowHeadersWidth = 10
        Me.dgvEnsayos.RowTemplate.Height = 20
        Me.dgvEnsayos.ShowCellToolTips = False
        Me.dgvEnsayos.SinClickDerecho = False
        Me.dgvEnsayos.Size = New System.Drawing.Size(992, 264)
        Me.dgvEnsayos.TabIndex = 4
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
        Me.Especificacion.MinimumWidth = 301
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
        Me.Farmacopea.Width = 48
        '
        'Valor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MinimumWidth = 50
        Me.Valor.Name = "Valor"
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Width = 50
        '
        'ValorBandera
        '
        Me.ValorBandera.HeaderText = "ValorBandera"
        Me.ValorBandera.Name = "ValorBandera"
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
        Me.TipoEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TipoEspecif.Visible = False
        '
        'DesdeEspecif
        '
        Me.DesdeEspecif.HeaderText = "DesdeEspecif"
        Me.DesdeEspecif.Name = "DesdeEspecif"
        Me.DesdeEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DesdeEspecif.Visible = False
        '
        'HastaEspecif
        '
        Me.HastaEspecif.HeaderText = "HastaEspecif"
        Me.HastaEspecif.Name = "HastaEspecif"
        Me.HastaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HastaEspecif.Visible = False
        '
        'UnidadEspecif
        '
        Me.UnidadEspecif.HeaderText = "UnidadEspecif"
        Me.UnidadEspecif.Name = "UnidadEspecif"
        Me.UnidadEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UnidadEspecif.Visible = False
        '
        'MenorIgualEspecif
        '
        Me.MenorIgualEspecif.HeaderText = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Name = "MenorIgualEspecif"
        Me.MenorIgualEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MenorIgualEspecif.Visible = False
        '
        'InformaEspecif
        '
        Me.InformaEspecif.HeaderText = "InformaEspecif"
        Me.InformaEspecif.Name = "InformaEspecif"
        Me.InformaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.InformaEspecif.Visible = False
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MinimumWidth = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Observaciones.Visible = False
        '
        'FormulaEspecif
        '
        Me.FormulaEspecif.HeaderText = "FormulaEspecif"
        Me.FormulaEspecif.Name = "FormulaEspecif"
        Me.FormulaEspecif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaEspecif.Visible = False
        '
        'Variable1
        '
        Me.Variable1.HeaderText = "Variable1"
        Me.Variable1.Name = "Variable1"
        Me.Variable1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable1.Visible = False
        '
        'Variable2
        '
        Me.Variable2.HeaderText = "Variable2"
        Me.Variable2.Name = "Variable2"
        Me.Variable2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable2.Visible = False
        '
        'Variable3
        '
        Me.Variable3.HeaderText = "Variable3"
        Me.Variable3.Name = "Variable3"
        Me.Variable3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable3.Visible = False
        '
        'Variable4
        '
        Me.Variable4.HeaderText = "Variable4"
        Me.Variable4.Name = "Variable4"
        Me.Variable4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable4.Visible = False
        '
        'Variable5
        '
        Me.Variable5.HeaderText = "Variable5"
        Me.Variable5.Name = "Variable5"
        Me.Variable5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable5.Visible = False
        '
        'Variable6
        '
        Me.Variable6.HeaderText = "Variable6"
        Me.Variable6.Name = "Variable6"
        Me.Variable6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable6.Visible = False
        '
        'Variable7
        '
        Me.Variable7.HeaderText = "Variable7"
        Me.Variable7.Name = "Variable7"
        Me.Variable7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable7.Visible = False
        '
        'Variable8
        '
        Me.Variable8.HeaderText = "Variable8"
        Me.Variable8.Name = "Variable8"
        Me.Variable8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable8.Visible = False
        '
        'Variable9
        '
        Me.Variable9.HeaderText = "Variable9"
        Me.Variable9.Name = "Variable9"
        Me.Variable9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable9.Visible = False
        '
        'Variable10
        '
        Me.Variable10.HeaderText = "Variable10"
        Me.Variable10.Name = "Variable10"
        Me.Variable10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Variable10.Visible = False
        '
        'VariableValor1
        '
        Me.VariableValor1.HeaderText = "VariableValor1"
        Me.VariableValor1.Name = "VariableValor1"
        Me.VariableValor1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor1.Visible = False
        '
        'VariableValor2
        '
        Me.VariableValor2.HeaderText = "VariableValor2"
        Me.VariableValor2.Name = "VariableValor2"
        Me.VariableValor2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor2.Visible = False
        '
        'VariableValor3
        '
        Me.VariableValor3.HeaderText = "VariableValor3"
        Me.VariableValor3.Name = "VariableValor3"
        Me.VariableValor3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor3.Visible = False
        '
        'VariableValor4
        '
        Me.VariableValor4.HeaderText = "VariableValor4"
        Me.VariableValor4.Name = "VariableValor4"
        Me.VariableValor4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor4.Visible = False
        '
        'VariableValor5
        '
        Me.VariableValor5.HeaderText = "VariableValor5"
        Me.VariableValor5.Name = "VariableValor5"
        Me.VariableValor5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor5.Visible = False
        '
        'VariableValor6
        '
        Me.VariableValor6.HeaderText = "VariableValor6"
        Me.VariableValor6.Name = "VariableValor6"
        Me.VariableValor6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor6.Visible = False
        '
        'VariableValor7
        '
        Me.VariableValor7.HeaderText = "VariableValor7"
        Me.VariableValor7.Name = "VariableValor7"
        Me.VariableValor7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor7.Visible = False
        '
        'VariableValor8
        '
        Me.VariableValor8.HeaderText = "VariableValor8"
        Me.VariableValor8.Name = "VariableValor8"
        Me.VariableValor8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor8.Visible = False
        '
        'VariableValor9
        '
        Me.VariableValor9.HeaderText = "VariableValor9"
        Me.VariableValor9.Name = "VariableValor9"
        Me.VariableValor9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor9.Visible = False
        '
        'VariableValor10
        '
        Me.VariableValor10.HeaderText = "VariableValor10"
        Me.VariableValor10.Name = "VariableValor10"
        Me.VariableValor10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableValor10.Visible = False
        '
        'EspecificacionIngles
        '
        Me.EspecificacionIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EspecificacionIngles.DataPropertyName = "EspecificacionIngles"
        Me.EspecificacionIngles.HeaderText = "Especif. Inglés"
        Me.EspecificacionIngles.MinimumWidth = 200
        Me.EspecificacionIngles.Name = "EspecificacionIngles"
        Me.EspecificacionIngles.ReadOnly = True
        Me.EspecificacionIngles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EspecificacionIngles.Width = 200
        '
        'Decimales
        '
        Me.Decimales.HeaderText = "Decimales"
        Me.Decimales.Name = "Decimales"
        Me.Decimales.ReadOnly = True
        Me.Decimales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Decimales.Visible = False
        '
        'OperadorIniciales
        '
        Me.OperadorIniciales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OperadorIniciales.HeaderText = "Opera."
        Me.OperadorIniciales.Name = "OperadorIniciales"
        Me.OperadorIniciales.ReadOnly = True
        Me.OperadorIniciales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperadorIniciales.Width = 75
        '
        'OperadorID
        '
        Me.OperadorID.HeaderText = "OperadorID"
        Me.OperadorID.Name = "OperadorID"
        Me.OperadorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperadorID.Visible = False
        '
        'FormulaAdic1
        '
        Me.FormulaAdic1.HeaderText = "FormulaAdic1"
        Me.FormulaAdic1.Name = "FormulaAdic1"
        Me.FormulaAdic1.ReadOnly = True
        Me.FormulaAdic1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic1.Visible = False
        '
        'FormulaAdic2
        '
        Me.FormulaAdic2.HeaderText = "FormulaAdic2"
        Me.FormulaAdic2.Name = "FormulaAdic2"
        Me.FormulaAdic2.ReadOnly = True
        Me.FormulaAdic2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic2.Visible = False
        '
        'FormulaAdic3
        '
        Me.FormulaAdic3.HeaderText = "FormulaAdic3"
        Me.FormulaAdic3.Name = "FormulaAdic3"
        Me.FormulaAdic3.ReadOnly = True
        Me.FormulaAdic3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic3.Visible = False
        '
        'FormulaAdic1dec
        '
        Me.FormulaAdic1dec.HeaderText = "FormulaAdic1dec"
        Me.FormulaAdic1dec.Name = "FormulaAdic1dec"
        Me.FormulaAdic1dec.ReadOnly = True
        Me.FormulaAdic1dec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic1dec.Visible = False
        '
        'FormulaAdic2dec
        '
        Me.FormulaAdic2dec.HeaderText = "FormulaAdic2dec"
        Me.FormulaAdic2dec.Name = "FormulaAdic2dec"
        Me.FormulaAdic2dec.ReadOnly = True
        Me.FormulaAdic2dec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic2dec.Visible = False
        '
        'FormulaAdic3dec
        '
        Me.FormulaAdic3dec.HeaderText = "FormulaAdic3dec"
        Me.FormulaAdic3dec.Name = "FormulaAdic3dec"
        Me.FormulaAdic3dec.ReadOnly = True
        Me.FormulaAdic3dec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FormulaAdic3dec.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 349)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(992, 102)
        Me.Panel2.TabIndex = 5
        '
        'IngresoEnsayosLaboratorioMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 503)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IngresoEnsayosLaboratorioMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbDatosAdicionales.ResumeLayout(False)
        Me.gbDatosAdicionales.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvEnsayos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEtapa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTipoProceso As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvEnsayos As DBDataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesvio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOOS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtConfecciono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNotas As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnActualizarEspecif As System.Windows.Forms.Button
    Friend WithEvents txtFechaVto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirEnsayosIngresados As System.Windows.Forms.Button
    Friend WithEvents lblDescEtapa As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEnvases As System.Windows.Forms.TextBox
    Friend WithEvents txtPaginas As System.Windows.Forms.TextBox
    Friend WithEvents txtLibros As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLotePartida As System.Windows.Forms.TextBox
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadEtiquetas As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnNotasAnteriores As System.Windows.Forms.Button
    Friend WithEvents btnNotasCertAnalisis As System.Windows.Forms.Button
    Friend WithEvents btnRevalida As System.Windows.Forms.Button
    Friend WithEvents txtEspecifActual As System.Windows.Forms.TextBox
    Friend WithEvents txtEspecifOrig As System.Windows.Forms.TextBox
    Friend WithEvents txtRevalida As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnReimprimir As System.Windows.Forms.Button
    Friend WithEvents txtFechaRevalida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMeses As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents gbDatosAdicionales As System.Windows.Forms.GroupBox
    Friend WithEvents btnPoolEnsayos As System.Windows.Forms.Button
    Friend WithEvents txtDescMP As System.Windows.Forms.Label
    Friend WithEvents txtInforme As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtLoteProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents rbPool As System.Windows.Forms.RadioButton
    Friend WithEvents rbFinal As System.Windows.Forms.RadioButton
    Friend WithEvents txtPool As System.Windows.Forms.TextBox
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
    Friend WithEvents OperadorIniciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperadorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic1dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic2dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormulaAdic3dec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblIDPool As System.Windows.Forms.Label
End Class
