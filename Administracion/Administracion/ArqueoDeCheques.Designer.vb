<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArqueoDeCheques
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCodigoCheque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumeroCheque = New System.Windows.Forms.TextBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.txtSumaImportes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.gbDiscriminado = New System.Windows.Forms.GroupBox()
        Me.btnImprimirAcumulado = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtmesesRestantes = New System.Windows.Forms.TextBox()
        Me.txtmes4Q2 = New System.Windows.Forms.TextBox()
        Me.txtmes4Q1 = New System.Windows.Forms.TextBox()
        Me.txtmes3Q2 = New System.Windows.Forms.TextBox()
        Me.txtmes3Q1 = New System.Windows.Forms.TextBox()
        Me.txtmes2Q2 = New System.Windows.Forms.TextBox()
        Me.txtmes2Q1 = New System.Windows.Forms.TextBox()
        Me.txtmesInicial = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DGV_Cheques = New ConsultasVarias.DBDataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTraerCambios = New System.Windows.Forms.Button()
        Me.btnDiscriminadoXQuincena = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.gbDiscriminado.SuspendLayout()
        CType(Me.DGV_Cheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodigoCheque
        '
        Me.txtCodigoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCheque.Location = New System.Drawing.Point(13, 76)
        Me.txtCodigoCheque.MaxLength = 31
        Me.txtCodigoCheque.Name = "txtCodigoCheque"
        Me.txtCodigoCheque.Size = New System.Drawing.Size(271, 22)
        Me.txtCodigoCheque.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Codigo de Cheque"
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mastxtFecha.Location = New System.Drawing.Point(13, 171)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(95, 24)
        Me.mastxtFecha.TabIndex = 3
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNumeroCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCheque.Location = New System.Drawing.Point(13, 128)
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        Me.txtNumeroCheque.ReadOnly = True
        Me.txtNumeroCheque.Size = New System.Drawing.Size(111, 24)
        Me.txtNumeroCheque.TabIndex = 4
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(13, 217)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(111, 24)
        Me.txtImporte.TabIndex = 5
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBanco
        '
        Me.txtBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanco.Location = New System.Drawing.Point(13, 267)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.ReadOnly = True
        Me.txtBanco.Size = New System.Drawing.Size(271, 24)
        Me.txtBanco.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Numero Cheque"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Importe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Banco"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 44)
        Me.Panel1.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 19)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Arqueo de Cheques"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(702, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 26)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "SURFACTAN S.A."
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(49, 339)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 38)
        Me.btnImprimir.TabIndex = 12
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'txtSumaImportes
        '
        Me.txtSumaImportes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSumaImportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumaImportes.Location = New System.Drawing.Point(173, 438)
        Me.txtSumaImportes.Name = "txtSumaImportes"
        Me.txtSumaImportes.ReadOnly = True
        Me.txtSumaImportes.Size = New System.Drawing.Size(111, 24)
        Me.txtSumaImportes.TabIndex = 13
        Me.txtSumaImportes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSumaImportes.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(173, 419)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Suma de Importes"
        Me.Label8.Visible = False
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Location = New System.Drawing.Point(147, 339)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(75, 38)
        Me.btnExportarExcel.TabIndex = 15
        Me.btnExportarExcel.Text = "Exportar a Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'gbDiscriminado
        '
        Me.gbDiscriminado.Controls.Add(Me.btnDiscriminadoXQuincena)
        Me.gbDiscriminado.Controls.Add(Me.btnImprimirAcumulado)
        Me.gbDiscriminado.Controls.Add(Me.Label16)
        Me.gbDiscriminado.Controls.Add(Me.Label15)
        Me.gbDiscriminado.Controls.Add(Me.Label14)
        Me.gbDiscriminado.Controls.Add(Me.Label13)
        Me.gbDiscriminado.Controls.Add(Me.Label12)
        Me.gbDiscriminado.Controls.Add(Me.Label11)
        Me.gbDiscriminado.Controls.Add(Me.Label10)
        Me.gbDiscriminado.Controls.Add(Me.Label9)
        Me.gbDiscriminado.Controls.Add(Me.txtmesesRestantes)
        Me.gbDiscriminado.Controls.Add(Me.txtmes4Q2)
        Me.gbDiscriminado.Controls.Add(Me.txtmes4Q1)
        Me.gbDiscriminado.Controls.Add(Me.txtmes3Q2)
        Me.gbDiscriminado.Controls.Add(Me.txtmes3Q1)
        Me.gbDiscriminado.Controls.Add(Me.txtmes2Q2)
        Me.gbDiscriminado.Controls.Add(Me.txtmes2Q1)
        Me.gbDiscriminado.Controls.Add(Me.txtmesInicial)
        Me.gbDiscriminado.Location = New System.Drawing.Point(690, 50)
        Me.gbDiscriminado.Name = "gbDiscriminado"
        Me.gbDiscriminado.Size = New System.Drawing.Size(174, 439)
        Me.gbDiscriminado.TabIndex = 16
        Me.gbDiscriminado.TabStop = False
        Me.gbDiscriminado.Text = "Discriminado Mensual"
        '
        'btnImprimirAcumulado
        '
        Me.btnImprimirAcumulado.Location = New System.Drawing.Point(6, 397)
        Me.btnImprimirAcumulado.Name = "btnImprimirAcumulado"
        Me.btnImprimirAcumulado.Size = New System.Drawing.Size(75, 38)
        Me.btnImprimirAcumulado.TabIndex = 24
        Me.btnImprimirAcumulado.Text = "Imprimir Acumulado"
        Me.btnImprimirAcumulado.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 351)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Label16"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 305)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Label15"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 259)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Label14"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Label13"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Label9"
        '
        'txtmesesRestantes
        '
        Me.txtmesesRestantes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmesesRestantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmesesRestantes.Location = New System.Drawing.Point(17, 367)
        Me.txtmesesRestantes.Name = "txtmesesRestantes"
        Me.txtmesesRestantes.ReadOnly = True
        Me.txtmesesRestantes.Size = New System.Drawing.Size(134, 24)
        Me.txtmesesRestantes.TabIndex = 12
        Me.txtmesesRestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes4Q2
        '
        Me.txtmes4Q2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes4Q2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes4Q2.Location = New System.Drawing.Point(17, 321)
        Me.txtmes4Q2.Name = "txtmes4Q2"
        Me.txtmes4Q2.ReadOnly = True
        Me.txtmes4Q2.Size = New System.Drawing.Size(134, 24)
        Me.txtmes4Q2.TabIndex = 11
        Me.txtmes4Q2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes4Q1
        '
        Me.txtmes4Q1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes4Q1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes4Q1.Location = New System.Drawing.Point(17, 275)
        Me.txtmes4Q1.Name = "txtmes4Q1"
        Me.txtmes4Q1.ReadOnly = True
        Me.txtmes4Q1.Size = New System.Drawing.Size(134, 24)
        Me.txtmes4Q1.TabIndex = 10
        Me.txtmes4Q1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes3Q2
        '
        Me.txtmes3Q2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes3Q2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes3Q2.Location = New System.Drawing.Point(17, 225)
        Me.txtmes3Q2.Name = "txtmes3Q2"
        Me.txtmes3Q2.ReadOnly = True
        Me.txtmes3Q2.Size = New System.Drawing.Size(134, 24)
        Me.txtmes3Q2.TabIndex = 9
        Me.txtmes3Q2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes3Q1
        '
        Me.txtmes3Q1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes3Q1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes3Q1.Location = New System.Drawing.Point(17, 180)
        Me.txtmes3Q1.Name = "txtmes3Q1"
        Me.txtmes3Q1.ReadOnly = True
        Me.txtmes3Q1.Size = New System.Drawing.Size(134, 24)
        Me.txtmes3Q1.TabIndex = 8
        Me.txtmes3Q1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes2Q2
        '
        Me.txtmes2Q2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes2Q2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes2Q2.Location = New System.Drawing.Point(17, 134)
        Me.txtmes2Q2.Name = "txtmes2Q2"
        Me.txtmes2Q2.ReadOnly = True
        Me.txtmes2Q2.Size = New System.Drawing.Size(134, 24)
        Me.txtmes2Q2.TabIndex = 7
        Me.txtmes2Q2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmes2Q1
        '
        Me.txtmes2Q1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmes2Q1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes2Q1.Location = New System.Drawing.Point(17, 88)
        Me.txtmes2Q1.Name = "txtmes2Q1"
        Me.txtmes2Q1.ReadOnly = True
        Me.txtmes2Q1.Size = New System.Drawing.Size(134, 24)
        Me.txtmes2Q1.TabIndex = 6
        Me.txtmes2Q1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmesInicial
        '
        Me.txtmesInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmesInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmesInicial.Location = New System.Drawing.Point(17, 38)
        Me.txtmesInicial.Name = "txtmesInicial"
        Me.txtmesInicial.ReadOnly = True
        Me.txtmesInicial.Size = New System.Drawing.Size(134, 24)
        Me.txtmesInicial.TabIndex = 5
        Me.txtmesInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(588, 469)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Label17"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.Location = New System.Drawing.Point(419, 465)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(163, 24)
        Me.txtMontoTotal.TabIndex = 18
        Me.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(349, 469)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Monto Total"
        '
        'DGV_Cheques
        '
        Me.DGV_Cheques.AllowUserToAddRows = False
        Me.DGV_Cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Cheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Numero, Me.Importe, Me.Banco, Me.ClaveCheque, Me.Origen, Me.FechaOrd, Me.Clave})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Cheques.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Cheques.DoubleBuffered = True
        Me.DGV_Cheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_Cheques.Location = New System.Drawing.Point(290, 50)
        Me.DGV_Cheques.Name = "DGV_Cheques"
        Me.DGV_Cheques.OrdenamientoColumnasHabilitado = True
        Me.DGV_Cheques.RowHeadersWidth = 15
        Me.DGV_Cheques.RowTemplate.Height = 20
        Me.DGV_Cheques.ShowCellToolTips = False
        Me.DGV_Cheques.SinClickDerecho = False
        Me.DGV_Cheques.Size = New System.Drawing.Size(394, 412)
        Me.DGV_Cheques.TabIndex = 0
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 70
        '
        'Numero
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle1
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 70
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle2
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.Width = 67
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.Width = 170
        '
        'ClaveCheque
        '
        Me.ClaveCheque.HeaderText = "ClaveCheque"
        Me.ClaveCheque.Name = "ClaveCheque"
        Me.ClaveCheque.Visible = False
        Me.ClaveCheque.Width = 120
        '
        'Origen
        '
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.Visible = False
        '
        'FechaOrd
        '
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.Visible = False
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'txtTraerCambios
        '
        Me.txtTraerCambios.Location = New System.Drawing.Point(19, 438)
        Me.txtTraerCambios.Name = "txtTraerCambios"
        Me.txtTraerCambios.Size = New System.Drawing.Size(105, 41)
        Me.txtTraerCambios.TabIndex = 20
        Me.txtTraerCambios.Text = "Traer Datos de Secundarios"
        Me.txtTraerCambios.UseVisualStyleBackColor = True
        '
        'btnDiscriminadoXQuincena
        '
        Me.btnDiscriminadoXQuincena.Location = New System.Drawing.Point(87, 397)
        Me.btnDiscriminadoXQuincena.Name = "btnDiscriminadoXQuincena"
        Me.btnDiscriminadoXQuincena.Size = New System.Drawing.Size(75, 38)
        Me.btnDiscriminadoXQuincena.TabIndex = 25
        Me.btnDiscriminadoXQuincena.Text = "Discriminado Quincena"
        Me.btnDiscriminadoXQuincena.UseVisualStyleBackColor = True
        '
        'ArqueoDeCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(873, 491)
        Me.Controls.Add(Me.txtTraerCambios)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtMontoTotal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.gbDiscriminado)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSumaImportes)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBanco)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.txtNumeroCheque)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigoCheque)
        Me.Controls.Add(Me.DGV_Cheques)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "ArqueoDeCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ArqueoDeCheques"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbDiscriminado.ResumeLayout(False)
        Me.gbDiscriminado.PerformLayout()
        CType(Me.DGV_Cheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Cheques As ConsultasVarias.DBDataGridView
    Friend WithEvents txtCodigoCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumeroCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtSumaImportes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents gbDiscriminado As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtmesesRestantes As System.Windows.Forms.TextBox
    Friend WithEvents txtmes4Q2 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes4Q1 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes3Q2 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes3Q1 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes2Q2 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes2Q1 As System.Windows.Forms.TextBox
    Friend WithEvents txtmesInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirAcumulado As System.Windows.Forms.Button
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTraerCambios As System.Windows.Forms.Button
    Friend WithEvents btnDiscriminadoXQuincena As System.Windows.Forms.Button
End Class
