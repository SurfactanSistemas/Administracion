Imports ConsultasVarias

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoEnsayosIntermediosPT
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEtapa = New System.Windows.Forms.TextBox()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaVto = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTipoProceso = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPaginas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesvio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.txtConfecciono = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOOS = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLibros = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnImprimirEnsayosIngresados = New System.Windows.Forms.Button()
        Me.btnActualizarEspecif = New System.Windows.Forms.Button()
        Me.btnNotas = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvEnsayos = New ConsultasVarias.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesdeEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HastaEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadEspecif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Farmacopea = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblDescEtapa = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(971, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(781, 12)
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
        Me.Label1.Size = New System.Drawing.Size(446, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO DE ENSAYOS INTERMEDIOS DE PRODUCTO TERMINADO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEtapa)
        Me.GroupBox1.Controls.Add(Me.txtPartida)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFechaVto)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblDescEtapa)
        Me.GroupBox1.Controls.Add(Me.lblTipoProceso)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 53)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Producto Terminado"
        '
        'txtEtapa
        '
        Me.txtEtapa.Location = New System.Drawing.Point(284, 23)
        Me.txtEtapa.MaxLength = 2
        Me.txtEtapa.Name = "txtEtapa"
        Me.txtEtapa.Size = New System.Drawing.Size(24, 20)
        Me.txtEtapa.TabIndex = 2
        Me.txtEtapa.Text = "99"
        Me.txtEtapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(57, 23)
        Me.txtPartida.MaxLength = 6
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(52, 20)
        Me.txtPartida.TabIndex = 2
        Me.txtPartida.Text = "300000"
        Me.txtPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Etapa:"
        '
        'txtFechaVto
        '
        Me.txtFechaVto.Location = New System.Drawing.Point(469, 23)
        Me.txtFechaVto.Mask = "00/00/0000"
        Me.txtFechaVto.Name = "txtFechaVto"
        Me.txtFechaVto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaVto.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaVto.TabIndex = 1
        Me.txtFechaVto.Text = "12021990"
        Me.txtFechaVto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(357, 23)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Text = "12021990"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(160, 23)
        Me.txtCodigo.Mask = "AA-00000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(76, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Text = "PT25025100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Partida:"
        '
        'lblTipoProceso
        '
        Me.lblTipoProceso.BackColor = System.Drawing.Color.Cyan
        Me.lblTipoProceso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoProceso.Location = New System.Drawing.Point(624, 10)
        Me.lblTipoProceso.Name = "lblTipoProceso"
        Me.lblTipoProceso.Size = New System.Drawing.Size(309, 20)
        Me.lblTipoProceso.TabIndex = 0
        Me.lblTipoProceso.Text = "MICRONIZADO"
        Me.lblTipoProceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(429, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "F. Vto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(545, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Desc. Etapa:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(314, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(116, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Código:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPaginas)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDesvio)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtArchivo)
        Me.GroupBox2.Controls.Add(Me.txtConfecciono)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtOOS)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtLibros)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(474, 80)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'txtPaginas
        '
        Me.txtPaginas.Location = New System.Drawing.Point(438, -9)
        Me.txtPaginas.Name = "txtPaginas"
        Me.txtPaginas.Size = New System.Drawing.Size(53, 20)
        Me.txtPaginas.TabIndex = 2
        Me.txtPaginas.Text = "300000"
        Me.txtPaginas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPaginas.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(443, -2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Páginas:"
        Me.Label9.Visible = False
        '
        'txtDesvio
        '
        Me.txtDesvio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesvio.Location = New System.Drawing.Point(214, 19)
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
        Me.Label11.Location = New System.Drawing.Point(148, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Desvío Nº:"
        '
        'txtArchivo
        '
        Me.txtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchivo.Location = New System.Drawing.Point(70, 45)
        Me.txtArchivo.MaxLength = 30
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(389, 20)
        Me.txtArchivo.TabIndex = 2
        Me.txtArchivo.Text = "300000"
        '
        'txtConfecciono
        '
        Me.txtConfecciono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfecciono.Location = New System.Drawing.Point(364, 19)
        Me.txtConfecciono.MaxLength = 50
        Me.txtConfecciono.Name = "txtConfecciono"
        Me.txtConfecciono.Size = New System.Drawing.Size(95, 20)
        Me.txtConfecciono.TabIndex = 2
        Me.txtConfecciono.Text = "300000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Archivo:"
        '
        'txtOOS
        '
        Me.txtOOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOOS.Location = New System.Drawing.Point(70, 19)
        Me.txtOOS.MaxLength = 10
        Me.txtOOS.Name = "txtOOS"
        Me.txtOOS.Size = New System.Drawing.Size(70, 20)
        Me.txtOOS.TabIndex = 2
        Me.txtOOS.Text = "300000"
        Me.txtOOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(288, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Confeccionó:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "OOS Nº:"
        '
        'txtLibros
        '
        Me.txtLibros.Location = New System.Drawing.Point(441, -6)
        Me.txtLibros.Name = "txtLibros"
        Me.txtLibros.Size = New System.Drawing.Size(53, 20)
        Me.txtLibros.TabIndex = 2
        Me.txtLibros.Text = "300000"
        Me.txtLibros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLibros.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(451, -2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Libro:"
        Me.Label8.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGrabar)
        Me.GroupBox3.Controls.Add(Me.btnImprimirEnsayosIngresados)
        Me.GroupBox3.Controls.Add(Me.btnActualizarEspecif)
        Me.GroupBox3.Controls.Add(Me.btnNotas)
        Me.GroupBox3.Controls.Add(Me.btnCerrar)
        Me.GroupBox3.Controls.Add(Me.btnLimpiar)
        Me.GroupBox3.Location = New System.Drawing.Point(489, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(467, 80)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(135, 12)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(109, 30)
        Me.btnGrabar.TabIndex = 0
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnImprimirEnsayosIngresados
        '
        Me.btnImprimirEnsayosIngresados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirEnsayosIngresados.Location = New System.Drawing.Point(250, 45)
        Me.btnImprimirEnsayosIngresados.Name = "btnImprimirEnsayosIngresados"
        Me.btnImprimirEnsayosIngresados.Size = New System.Drawing.Size(181, 30)
        Me.btnImprimirEnsayosIngresados.TabIndex = 0
        Me.btnImprimirEnsayosIngresados.Text = "VER PDF ENSAYOS INGRESADOS"
        Me.btnImprimirEnsayosIngresados.UseVisualStyleBackColor = True
        '
        'btnActualizarEspecif
        '
        Me.btnActualizarEspecif.Location = New System.Drawing.Point(250, 12)
        Me.btnActualizarEspecif.Name = "btnActualizarEspecif"
        Me.btnActualizarEspecif.Size = New System.Drawing.Size(181, 30)
        Me.btnActualizarEspecif.TabIndex = 0
        Me.btnActualizarEspecif.Text = "ACTUALIZA ESPECIFICACIONES"
        Me.btnActualizarEspecif.UseVisualStyleBackColor = True
        '
        'btnNotas
        '
        Me.btnNotas.Location = New System.Drawing.Point(135, 45)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(109, 30)
        Me.btnNotas.TabIndex = 0
        Me.btnNotas.Text = "NOTAS"
        Me.btnNotas.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(20, 45)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(109, 30)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(20, 12)
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(971, 479)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'dgvEnsayos
        '
        Me.dgvEnsayos.AllowUserToAddRows = False
        Me.dgvEnsayos.AllowUserToDeleteRows = False
        Me.dgvEnsayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnsayos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Especificacion, Me.Valor, Me.Resultado, Me.Parametro, Me.Descripcion, Me.TipoEspecif, Me.DesdeEspecif, Me.HastaEspecif, Me.UnidadEspecif, Me.Farmacopea, Me.MenorIgualEspecif, Me.InformaEspecif, Me.Observaciones, Me.FormulaEspecif, Me.Variable1, Me.Variable2, Me.Variable3, Me.Variable4, Me.Variable5, Me.Variable6, Me.Variable7, Me.Variable8, Me.Variable9, Me.Variable10, Me.VariableValor1, Me.VariableValor2, Me.VariableValor3, Me.VariableValor4, Me.VariableValor5, Me.VariableValor6, Me.VariableValor7, Me.VariableValor8, Me.VariableValor9, Me.VariableValor10, Me.EspecificacionIngles, Me.Decimales})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnsayos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEnsayos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEnsayos.DoubleBuffered = True
        Me.dgvEnsayos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEnsayos.Location = New System.Drawing.Point(3, 62)
        Me.dgvEnsayos.Name = "dgvEnsayos"
        Me.dgvEnsayos.OrdenamientoColumnasHabilitado = True
        Me.dgvEnsayos.RowHeadersWidth = 10
        Me.dgvEnsayos.RowTemplate.Height = 20
        Me.dgvEnsayos.ShowCellToolTips = False
        Me.dgvEnsayos.SinClickDerecho = False
        Me.dgvEnsayos.Size = New System.Drawing.Size(965, 312)
        Me.dgvEnsayos.TabIndex = 4
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Ensayo.HeaderText = "Ens"
        Me.Ensayo.MaxInputLength = 10
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.Width = 50
        '
        'Especificacion
        '
        Me.Especificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Especificacion.HeaderText = "Especificación"
        Me.Especificacion.MinimumWidth = 150
        Me.Especificacion.Name = "Especificacion"
        Me.Especificacion.ReadOnly = True
        '
        'Valor
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle2
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MinimumWidth = 50
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 50
        '
        'Resultado
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Resultado.DefaultCellStyle = DataGridViewCellStyle3
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.MinimumWidth = 100
        Me.Resultado.Name = "Resultado"
        Me.Resultado.ReadOnly = True
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Parametro.HeaderText = "Parámetro"
        Me.Parametro.MinimumWidth = 150
        Me.Parametro.Name = "Parametro"
        Me.Parametro.Width = 150
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Visible = False
        '
        'TipoEspecif
        '
        Me.TipoEspecif.HeaderText = "TipoEspecif"
        Me.TipoEspecif.Name = "TipoEspecif"
        Me.TipoEspecif.Visible = False
        '
        'DesdeEspecif
        '
        Me.DesdeEspecif.HeaderText = "DesdeEspecif"
        Me.DesdeEspecif.Name = "DesdeEspecif"
        Me.DesdeEspecif.Visible = False
        '
        'HastaEspecif
        '
        Me.HastaEspecif.HeaderText = "HastaEspecif"
        Me.HastaEspecif.Name = "HastaEspecif"
        Me.HastaEspecif.Visible = False
        '
        'UnidadEspecif
        '
        Me.UnidadEspecif.HeaderText = "UnidadEspecif"
        Me.UnidadEspecif.Name = "UnidadEspecif"
        Me.UnidadEspecif.Visible = False
        '
        'Farmacopea
        '
        Me.Farmacopea.HeaderText = "Farmacopea"
        Me.Farmacopea.Name = "Farmacopea"
        Me.Farmacopea.Visible = False
        '
        'MenorIgualEspecif
        '
        Me.MenorIgualEspecif.HeaderText = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Name = "MenorIgualEspecif"
        Me.MenorIgualEspecif.Visible = False
        '
        'InformaEspecif
        '
        Me.InformaEspecif.HeaderText = "InformaEspecif"
        Me.InformaEspecif.Name = "InformaEspecif"
        Me.InformaEspecif.Visible = False
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.MinimumWidth = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Visible = False
        '
        'FormulaEspecif
        '
        Me.FormulaEspecif.HeaderText = "FormulaEspecif"
        Me.FormulaEspecif.Name = "FormulaEspecif"
        Me.FormulaEspecif.Visible = False
        '
        'Variable1
        '
        Me.Variable1.HeaderText = "Variable1"
        Me.Variable1.Name = "Variable1"
        Me.Variable1.Visible = False
        '
        'Variable2
        '
        Me.Variable2.HeaderText = "Variable2"
        Me.Variable2.Name = "Variable2"
        Me.Variable2.Visible = False
        '
        'Variable3
        '
        Me.Variable3.HeaderText = "Variable3"
        Me.Variable3.Name = "Variable3"
        Me.Variable3.Visible = False
        '
        'Variable4
        '
        Me.Variable4.HeaderText = "Variable4"
        Me.Variable4.Name = "Variable4"
        Me.Variable4.Visible = False
        '
        'Variable5
        '
        Me.Variable5.HeaderText = "Variable5"
        Me.Variable5.Name = "Variable5"
        Me.Variable5.Visible = False
        '
        'Variable6
        '
        Me.Variable6.HeaderText = "Variable6"
        Me.Variable6.Name = "Variable6"
        Me.Variable6.Visible = False
        '
        'Variable7
        '
        Me.Variable7.HeaderText = "Variable7"
        Me.Variable7.Name = "Variable7"
        Me.Variable7.Visible = False
        '
        'Variable8
        '
        Me.Variable8.HeaderText = "Variable8"
        Me.Variable8.Name = "Variable8"
        Me.Variable8.Visible = False
        '
        'Variable9
        '
        Me.Variable9.HeaderText = "Variable9"
        Me.Variable9.Name = "Variable9"
        Me.Variable9.Visible = False
        '
        'Variable10
        '
        Me.Variable10.HeaderText = "Variable10"
        Me.Variable10.Name = "Variable10"
        Me.Variable10.Visible = False
        '
        'VariableValor1
        '
        Me.VariableValor1.HeaderText = "VariableValor1"
        Me.VariableValor1.Name = "VariableValor1"
        Me.VariableValor1.Visible = False
        '
        'VariableValor2
        '
        Me.VariableValor2.HeaderText = "VariableValor2"
        Me.VariableValor2.Name = "VariableValor2"
        Me.VariableValor2.Visible = False
        '
        'VariableValor3
        '
        Me.VariableValor3.HeaderText = "VariableValor3"
        Me.VariableValor3.Name = "VariableValor3"
        Me.VariableValor3.Visible = False
        '
        'VariableValor4
        '
        Me.VariableValor4.HeaderText = "VariableValor4"
        Me.VariableValor4.Name = "VariableValor4"
        Me.VariableValor4.Visible = False
        '
        'VariableValor5
        '
        Me.VariableValor5.HeaderText = "VariableValor5"
        Me.VariableValor5.Name = "VariableValor5"
        Me.VariableValor5.Visible = False
        '
        'VariableValor6
        '
        Me.VariableValor6.HeaderText = "VariableValor6"
        Me.VariableValor6.Name = "VariableValor6"
        Me.VariableValor6.Visible = False
        '
        'VariableValor7
        '
        Me.VariableValor7.HeaderText = "VariableValor7"
        Me.VariableValor7.Name = "VariableValor7"
        Me.VariableValor7.Visible = False
        '
        'VariableValor8
        '
        Me.VariableValor8.HeaderText = "VariableValor8"
        Me.VariableValor8.Name = "VariableValor8"
        Me.VariableValor8.Visible = False
        '
        'VariableValor9
        '
        Me.VariableValor9.HeaderText = "VariableValor9"
        Me.VariableValor9.Name = "VariableValor9"
        Me.VariableValor9.Visible = False
        '
        'VariableValor10
        '
        Me.VariableValor10.HeaderText = "VariableValor10"
        Me.VariableValor10.Name = "VariableValor10"
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
        Me.EspecificacionIngles.Width = 200
        '
        'Decimales
        '
        Me.Decimales.HeaderText = "Decimales"
        Me.Decimales.Name = "Decimales"
        Me.Decimales.ReadOnly = True
        Me.Decimales.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(965, 96)
        Me.Panel2.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(545, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Tipo Proceso:"
        '
        'lblDescEtapa
        '
        Me.lblDescEtapa.BackColor = System.Drawing.Color.Cyan
        Me.lblDescEtapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescEtapa.Location = New System.Drawing.Point(624, 32)
        Me.lblDescEtapa.Name = "lblDescEtapa"
        Me.lblDescEtapa.Size = New System.Drawing.Size(309, 20)
        Me.lblDescEtapa.TabIndex = 0
        Me.lblDescEtapa.Text = "MICRONIZADO"
        Me.lblDescEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IngresoEnsayosIntermediosPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 528)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "IngresoEnsayosIntermediosPT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
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
    Friend WithEvents txtPaginas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesvio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOOS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLibros As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Especificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesdeEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HastaEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadEspecif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Farmacopea As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents btnImprimirEnsayosIngresados As System.Windows.Forms.Button
    Friend WithEvents lblDescEtapa As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
