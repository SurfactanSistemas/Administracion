<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesIncidenciaRechazoMP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMPAsociadasOC = New System.Windows.Forms.Button()
        Me.btnSac = New System.Windows.Forms.Button()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.txtDescProv = New System.Windows.Forms.TextBox()
        Me.txtIncidencia = New System.Windows.Forms.TextBox()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLotePartida = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.MaskedTextBox()
        Me.rbProdTerminado = New System.Windows.Forms.RadioButton()
        Me.rbMatPrima = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescProducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMotivos = New System.Windows.Forms.TextBox()
        Me.btnMovimientos = New System.Windows.Forms.Button()
        Me.btnHojaProduccion = New System.Windows.Forms.Button()
        Me.btnControles = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAcciones = New System.Windows.Forms.TextBox()
        Me.txtDescMP = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCantidadMP = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(801, 50)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(422, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "INFORME DE NO CONFORMIDAD POR RECHAZO DE MATERIA PRIMA"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(681, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMPAsociadasOC)
        Me.GroupBox1.Controls.Add(Me.btnSac)
        Me.GroupBox1.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtReferencia)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.txtOrden)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.txtCantidadMP)
        Me.GroupBox1.Controls.Add(Me.txtDescMP)
        Me.GroupBox1.Controls.Add(Me.txtDescProv)
        Me.GroupBox1.Controls.Add(Me.txtIncidencia)
        Me.GroupBox1.Controls.Add(Me.txtTitulo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 150)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS GENERALES"
        '
        'btnMPAsociadasOC
        '
        Me.btnMPAsociadasOC.Location = New System.Drawing.Point(607, 44)
        Me.btnMPAsociadasOC.Name = "btnMPAsociadasOC"
        Me.btnMPAsociadasOC.Size = New System.Drawing.Size(157, 22)
        Me.btnMPAsociadasOC.TabIndex = 10
        Me.btnMPAsociadasOC.Text = "Seleccionar MP Asociadas"
        Me.btnMPAsociadasOC.UseVisualStyleBackColor = True
        '
        'btnSac
        '
        Me.btnSac.Location = New System.Drawing.Point(607, 17)
        Me.btnSac.Name = "btnSac"
        Me.btnSac.Size = New System.Drawing.Size(157, 22)
        Me.btnSac.TabIndex = 10
        Me.btnSac.Text = "Ver SAC Asociada"
        Me.btnSac.UseVisualStyleBackColor = True
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownWidth = 200
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(490, 18)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(107, 21)
        Me.cmbEmpresa.TabIndex = 4
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownWidth = 200
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"PENDIENTE DE ANÁLISIS", "GENERA SAC", "NO GENERA SAC"})
        Me.cmbEstado.Location = New System.Drawing.Point(299, 18)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(135, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(186, 18)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.Text = "99999999"
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(79, 121)
        Me.txtReferencia.MaxLength = 100
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(681, 20)
        Me.txtReferencia.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(140, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fecha:"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(200, 45)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(101, 20)
        Me.txtProveedor.TabIndex = 1
        Me.txtProveedor.TabStop = False
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(79, 45)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(53, 20)
        Me.txtOrden.TabIndex = 5
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescProv
        '
        Me.txtDescProv.BackColor = System.Drawing.Color.Cyan
        Me.txtDescProv.Location = New System.Drawing.Point(307, 45)
        Me.txtDescProv.Name = "txtDescProv"
        Me.txtDescProv.ReadOnly = True
        Me.txtDescProv.Size = New System.Drawing.Size(295, 20)
        Me.txtDescProv.TabIndex = 1
        Me.txtDescProv.TabStop = False
        '
        'txtIncidencia
        '
        Me.txtIncidencia.Location = New System.Drawing.Point(79, 18)
        Me.txtIncidencia.Name = "txtIncidencia"
        Me.txtIncidencia.Size = New System.Drawing.Size(53, 20)
        Me.txtIncidencia.TabIndex = 1
        Me.txtIncidencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(79, 96)
        Me.txtTitulo.MaxLength = 100
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(681, 20)
        Me.txtTitulo.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(438, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Empresa:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(138, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Proveedor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(258, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Estado:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(34, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Orden:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Inf. Nro:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Referencia:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Título:"
        '
        'txtLotePartida
        '
        Me.txtLotePartida.Location = New System.Drawing.Point(351, 189)
        Me.txtLotePartida.MaxLength = 6
        Me.txtLotePartida.Name = "txtLotePartida"
        Me.txtLotePartida.Size = New System.Drawing.Size(53, 20)
        Me.txtLotePartida.TabIndex = 6
        Me.txtLotePartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLotePartida.Visible = False
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(79, 71)
        Me.txtProducto.Mask = ">LL-00000-000"
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtProducto.Size = New System.Drawing.Size(78, 20)
        Me.txtProducto.TabIndex = 3
        Me.txtProducto.Text = "PT00000000"
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbProdTerminado
        '
        Me.rbProdTerminado.AutoSize = True
        Me.rbProdTerminado.Location = New System.Drawing.Point(19, 197)
        Me.rbProdTerminado.Name = "rbProdTerminado"
        Me.rbProdTerminado.Size = New System.Drawing.Size(103, 17)
        Me.rbProdTerminado.TabIndex = 2
        Me.rbProdTerminado.Text = "Prod. Terminado"
        Me.rbProdTerminado.UseVisualStyleBackColor = True
        Me.rbProdTerminado.Visible = False
        '
        'rbMatPrima
        '
        Me.rbMatPrima.AutoSize = True
        Me.rbMatPrima.Checked = True
        Me.rbMatPrima.Location = New System.Drawing.Point(19, 197)
        Me.rbMatPrima.Name = "rbMatPrima"
        Me.rbMatPrima.Size = New System.Drawing.Size(75, 17)
        Me.rbMatPrima.TabIndex = 2
        Me.rbMatPrima.TabStop = True
        Me.rbMatPrima.Text = "Mat. Prima"
        Me.rbMatPrima.UseVisualStyleBackColor = True
        Me.rbMatPrima.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(264, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Lote/Partida:"
        Me.Label7.Visible = False
        '
        'txtDescProducto
        '
        Me.txtDescProducto.BackColor = System.Drawing.Color.Cyan
        Me.txtDescProducto.Location = New System.Drawing.Point(410, 194)
        Me.txtDescProducto.Name = "txtDescProducto"
        Me.txtDescProducto.ReadOnly = True
        Me.txtDescProducto.Size = New System.Drawing.Size(205, 20)
        Me.txtDescProducto.TabIndex = 1
        Me.txtDescProducto.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Producto:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMotivos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(742, 210)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'txtMotivos
        '
        Me.txtMotivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivos.Location = New System.Drawing.Point(13, 15)
        Me.txtMotivos.Margin = New System.Windows.Forms.Padding(10)
        Me.txtMotivos.Multiline = True
        Me.txtMotivos.Name = "txtMotivos"
        Me.txtMotivos.Size = New System.Drawing.Size(716, 185)
        Me.txtMotivos.TabIndex = 8
        '
        'btnMovimientos
        '
        Me.btnMovimientos.Location = New System.Drawing.Point(598, 483)
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Size = New System.Drawing.Size(120, 41)
        Me.btnMovimientos.TabIndex = 1
        Me.btnMovimientos.Text = "SEGUIMIENTO DE MOVIMIENTOS"
        Me.btnMovimientos.UseVisualStyleBackColor = True
        Me.btnMovimientos.Visible = False
        '
        'btnHojaProduccion
        '
        Me.btnHojaProduccion.Location = New System.Drawing.Point(601, 483)
        Me.btnHojaProduccion.Name = "btnHojaProduccion"
        Me.btnHojaProduccion.Size = New System.Drawing.Size(115, 41)
        Me.btnHojaProduccion.TabIndex = 1
        Me.btnHojaProduccion.Text = "VER HOJA PROD."
        Me.btnHojaProduccion.UseVisualStyleBackColor = True
        Me.btnHojaProduccion.Visible = False
        '
        'btnControles
        '
        Me.btnControles.Location = New System.Drawing.Point(601, 483)
        Me.btnControles.Name = "btnControles"
        Me.btnControles.Size = New System.Drawing.Size(115, 41)
        Me.btnControles.TabIndex = 1
        Me.btnControles.Text = "VER CONTROLES"
        Me.btnControles.UseVisualStyleBackColor = True
        Me.btnControles.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(403, 483)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 41)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(274, 483)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(107, 41)
        Me.btnGrabar.TabIndex = 11
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(300, 30)
        Me.TabControl1.Location = New System.Drawing.Point(13, 216)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 259)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 221)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "MOTIVOS"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(768, 222)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ACCIONES"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAcciones)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(742, 210)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'txtAcciones
        '
        Me.txtAcciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcciones.Location = New System.Drawing.Point(13, 15)
        Me.txtAcciones.Margin = New System.Windows.Forms.Padding(10)
        Me.txtAcciones.Multiline = True
        Me.txtAcciones.Name = "txtAcciones"
        Me.txtAcciones.Size = New System.Drawing.Size(716, 185)
        Me.txtAcciones.TabIndex = 9
        '
        'txtDescMP
        '
        Me.txtDescMP.BackColor = System.Drawing.Color.Cyan
        Me.txtDescMP.Location = New System.Drawing.Point(163, 71)
        Me.txtDescMP.Name = "txtDescMP"
        Me.txtDescMP.ReadOnly = True
        Me.txtDescMP.Size = New System.Drawing.Size(379, 20)
        Me.txtDescMP.TabIndex = 1
        Me.txtDescMP.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(549, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Cantidad:"
        '
        'txtCantidadMP
        '
        Me.txtCantidadMP.BackColor = System.Drawing.Color.Cyan
        Me.txtCantidadMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadMP.Location = New System.Drawing.Point(607, 71)
        Me.txtCantidadMP.Name = "txtCantidadMP"
        Me.txtCantidadMP.ReadOnly = True
        Me.txtCantidadMP.Size = New System.Drawing.Size(77, 20)
        Me.txtCantidadMP.TabIndex = 1
        Me.txtCantidadMP.TabStop = False
        Me.txtCantidadMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DetallesIncidenciaRechazoMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 534)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnMovimientos)
        Me.Controls.Add(Me.txtLotePartida)
        Me.Controls.Add(Me.btnHojaProduccion)
        Me.Controls.Add(Me.btnControles)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.rbMatPrima)
        Me.Controls.Add(Me.txtDescProducto)
        Me.Controls.Add(Me.rbProdTerminado)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "DetallesIncidenciaRechazoMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIncidencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbProdTerminado As System.Windows.Forms.RadioButton
    Friend WithEvents rbMatPrima As System.Windows.Forms.RadioButton
    Friend WithEvents txtProducto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescProducto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSac As System.Windows.Forms.Button
    Friend WithEvents txtMotivos As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnHojaProduccion As System.Windows.Forms.Button
    Friend WithEvents btnControles As System.Windows.Forms.Button
    Friend WithEvents btnMovimientos As System.Windows.Forms.Button
    Friend WithEvents txtLotePartida As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescProv As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAcciones As System.Windows.Forms.TextBox
    Friend WithEvents btnMPAsociadasOC As System.Windows.Forms.Button
    Friend WithEvents txtCantidadMP As System.Windows.Forms.TextBox
    Friend WithEvents txtDescMP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
