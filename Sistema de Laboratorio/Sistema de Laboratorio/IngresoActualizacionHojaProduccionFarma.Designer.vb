<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoActualizacionHojaProduccionFarma
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
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHojaProduccion = New System.Windows.Forms.TextBox()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtFechaIngreso = New System.Windows.Forms.MaskedTextBox()
        Me.txtVersionFormulaV1 = New System.Windows.Forms.TextBox()
        Me.txtProcedimientoV2 = New System.Windows.Forms.TextBox()
        Me.txtEspecificacionV3 = New System.Windows.Forms.TextBox()
        Me.mastxtProducto = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescipcion = New System.Windows.Forms.TextBox()
        Me.txtEquipo = New System.Windows.Forms.TextBox()
        Me.txtRendimientoTeorico = New System.Windows.Forms.TextBox()
        Me.txtRendimientoReal = New System.Windows.Forms.TextBox()
        Me.cbxTipo = New System.Windows.Forms.ComboBox()
        Me.mastxtMPoPT = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescripcionMPoPT = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPartLote1 = New System.Windows.Forms.TextBox()
        Me.txtCantLote1 = New System.Windows.Forms.TextBox()
        Me.txtPartLote2 = New System.Windows.Forms.TextBox()
        Me.txtCantLote2 = New System.Windows.Forms.TextBox()
        Me.txtPartLote3 = New System.Windows.Forms.TextBox()
        Me.txtCantLote3 = New System.Windows.Forms.TextBox()
        Me.pnlLotes = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMPoPT = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnBlockNotas = New System.Windows.Forms.Button()
        Me.btnBajaHoja = New System.Windows.Forms.Button()
        Me.btnNuevaFila = New System.Windows.Forms.Button()
        Me.btnEditarFila = New System.Windows.Forms.Button()
        Me.DGV_IngredientosHojaProduccion = New Util.DBDataGridView()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPoPT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantLote1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantLote2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantLote3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rtxtAgenda = New System.Windows.Forms.RichTextBox()
        Me.pnlAgenda = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnpnlAyudaVolver = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DGV_Ayuda = New Util.DBDataGridView()
        Me.CodigoAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxAyuda = New System.Windows.Forms.ComboBox()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.pnlLotes.SuspendLayout()
        CType(Me.DGV_IngredientosHojaProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAgenda.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(135, 475)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(126, 36)
        Me.btnVolver.TabIndex = 0
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(764, 46)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(410, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "INGRESO Y ACTUALIZACIÓN DE HOJA DE PRODUCCIÓN"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(573, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'txtHojaProduccion
        '
        Me.txtHojaProduccion.Location = New System.Drawing.Point(53, 66)
        Me.txtHojaProduccion.MaxLength = 6
        Me.txtHojaProduccion.Name = "txtHojaProduccion"
        Me.txtHojaProduccion.Size = New System.Drawing.Size(74, 20)
        Me.txtHojaProduccion.TabIndex = 2
        Me.txtHojaProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(189, 66)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(69, 20)
        Me.mastxtFecha.TabIndex = 3
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFechaIngreso
        '
        Me.mastxtFechaIngreso.BackColor = System.Drawing.Color.Cyan
        Me.mastxtFechaIngreso.Enabled = False
        Me.mastxtFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mastxtFechaIngreso.Location = New System.Drawing.Point(652, 137)
        Me.mastxtFechaIngreso.Mask = "00/00/0000"
        Me.mastxtFechaIngreso.Name = "mastxtFechaIngreso"
        Me.mastxtFechaIngreso.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaIngreso.Size = New System.Drawing.Size(95, 20)
        Me.mastxtFechaIngreso.TabIndex = 4
        Me.mastxtFechaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersionFormulaV1
        '
        Me.txtVersionFormulaV1.BackColor = System.Drawing.Color.Cyan
        Me.txtVersionFormulaV1.Location = New System.Drawing.Point(98, 17)
        Me.txtVersionFormulaV1.MaxLength = 2
        Me.txtVersionFormulaV1.Name = "txtVersionFormulaV1"
        Me.txtVersionFormulaV1.Size = New System.Drawing.Size(29, 20)
        Me.txtVersionFormulaV1.TabIndex = 5
        Me.txtVersionFormulaV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProcedimientoV2
        '
        Me.txtProcedimientoV2.BackColor = System.Drawing.Color.Cyan
        Me.txtProcedimientoV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcedimientoV2.Location = New System.Drawing.Point(256, 17)
        Me.txtProcedimientoV2.MaxLength = 2
        Me.txtProcedimientoV2.Name = "txtProcedimientoV2"
        Me.txtProcedimientoV2.Size = New System.Drawing.Size(34, 20)
        Me.txtProcedimientoV2.TabIndex = 6
        Me.txtProcedimientoV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEspecificacionV3
        '
        Me.txtEspecificacionV3.BackColor = System.Drawing.Color.Cyan
        Me.txtEspecificacionV3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEspecificacionV3.Location = New System.Drawing.Point(416, 17)
        Me.txtEspecificacionV3.MaxLength = 2
        Me.txtEspecificacionV3.Name = "txtEspecificacionV3"
        Me.txtEspecificacionV3.Size = New System.Drawing.Size(29, 20)
        Me.txtEspecificacionV3.TabIndex = 7
        Me.txtEspecificacionV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtProducto
        '
        Me.mastxtProducto.Location = New System.Drawing.Point(85, 104)
        Me.mastxtProducto.Mask = ">LL-00000-000"
        Me.mastxtProducto.Name = "mastxtProducto"
        Me.mastxtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtProducto.Size = New System.Drawing.Size(77, 20)
        Me.mastxtProducto.TabIndex = 8
        Me.mastxtProducto.Text = "PT99999999"
        Me.mastxtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescipcion
        '
        Me.txtDescipcion.BackColor = System.Drawing.Color.Cyan
        Me.txtDescipcion.Enabled = False
        Me.txtDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescipcion.Location = New System.Drawing.Point(168, 104)
        Me.txtDescipcion.Name = "txtDescipcion"
        Me.txtDescipcion.Size = New System.Drawing.Size(425, 20)
        Me.txtDescipcion.TabIndex = 9
        '
        'txtEquipo
        '
        Me.txtEquipo.Location = New System.Drawing.Point(647, 104)
        Me.txtEquipo.MaxLength = 2
        Me.txtEquipo.Name = "txtEquipo"
        Me.txtEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtEquipo.TabIndex = 10
        Me.txtEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRendimientoTeorico
        '
        Me.txtRendimientoTeorico.Location = New System.Drawing.Point(162, 15)
        Me.txtRendimientoTeorico.MaxLength = 8
        Me.txtRendimientoTeorico.Name = "txtRendimientoTeorico"
        Me.txtRendimientoTeorico.Size = New System.Drawing.Size(100, 20)
        Me.txtRendimientoTeorico.TabIndex = 11
        Me.txtRendimientoTeorico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRendimientoReal
        '
        Me.txtRendimientoReal.BackColor = System.Drawing.Color.Cyan
        Me.txtRendimientoReal.Enabled = False
        Me.txtRendimientoReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRendimientoReal.Location = New System.Drawing.Point(377, 15)
        Me.txtRendimientoReal.MaxLength = 8
        Me.txtRendimientoReal.Name = "txtRendimientoReal"
        Me.txtRendimientoReal.Size = New System.Drawing.Size(100, 20)
        Me.txtRendimientoReal.TabIndex = 12
        Me.txtRendimientoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxTipo
        '
        Me.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipo.FormattingEnabled = True
        Me.cbxTipo.Items.AddRange(New Object() {"M", "T"})
        Me.cbxTipo.Location = New System.Drawing.Point(11, 409)
        Me.cbxTipo.Name = "cbxTipo"
        Me.cbxTipo.Size = New System.Drawing.Size(44, 21)
        Me.cbxTipo.TabIndex = 14
        '
        'mastxtMPoPT
        '
        Me.mastxtMPoPT.Location = New System.Drawing.Point(60, 409)
        Me.mastxtMPoPT.Mask = ">LL-000-000"
        Me.mastxtMPoPT.Name = "mastxtMPoPT"
        Me.mastxtMPoPT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtMPoPT.Size = New System.Drawing.Size(86, 20)
        Me.mastxtMPoPT.TabIndex = 15
        Me.mastxtMPoPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionMPoPT
        '
        Me.txtDescripcionMPoPT.BackColor = System.Drawing.Color.Cyan
        Me.txtDescripcionMPoPT.Enabled = False
        Me.txtDescripcionMPoPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionMPoPT.Location = New System.Drawing.Point(151, 409)
        Me.txtDescripcionMPoPT.Name = "txtDescripcionMPoPT"
        Me.txtDescripcionMPoPT.Size = New System.Drawing.Size(344, 20)
        Me.txtDescripcionMPoPT.TabIndex = 16
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(500, 409)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(82, 20)
        Me.txtCantidad.TabIndex = 17
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote1
        '
        Me.txtPartLote1.Location = New System.Drawing.Point(6, 24)
        Me.txtPartLote1.MaxLength = 6
        Me.txtPartLote1.Name = "txtPartLote1"
        Me.txtPartLote1.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote1.TabIndex = 18
        Me.txtPartLote1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote1
        '
        Me.txtCantLote1.Location = New System.Drawing.Point(81, 24)
        Me.txtCantLote1.MaxLength = 8
        Me.txtCantLote1.Name = "txtCantLote1"
        Me.txtCantLote1.Size = New System.Drawing.Size(71, 20)
        Me.txtCantLote1.TabIndex = 19
        Me.txtCantLote1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote2
        '
        Me.txtPartLote2.Location = New System.Drawing.Point(6, 50)
        Me.txtPartLote2.MaxLength = 6
        Me.txtPartLote2.Name = "txtPartLote2"
        Me.txtPartLote2.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote2.TabIndex = 20
        Me.txtPartLote2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote2
        '
        Me.txtCantLote2.Location = New System.Drawing.Point(81, 50)
        Me.txtCantLote2.MaxLength = 8
        Me.txtCantLote2.Name = "txtCantLote2"
        Me.txtCantLote2.Size = New System.Drawing.Size(71, 20)
        Me.txtCantLote2.TabIndex = 21
        Me.txtCantLote2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote3
        '
        Me.txtPartLote3.Location = New System.Drawing.Point(6, 76)
        Me.txtPartLote3.MaxLength = 6
        Me.txtPartLote3.Name = "txtPartLote3"
        Me.txtPartLote3.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote3.TabIndex = 22
        Me.txtPartLote3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote3
        '
        Me.txtCantLote3.Location = New System.Drawing.Point(81, 76)
        Me.txtCantLote3.MaxLength = 8
        Me.txtCantLote3.Name = "txtCantLote3"
        Me.txtCantLote3.Size = New System.Drawing.Size(71, 20)
        Me.txtCantLote3.TabIndex = 23
        Me.txtCantLote3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlLotes
        '
        Me.pnlLotes.Controls.Add(Me.Label17)
        Me.pnlLotes.Controls.Add(Me.Label16)
        Me.pnlLotes.Controls.Add(Me.txtPartLote1)
        Me.pnlLotes.Controls.Add(Me.txtCantLote3)
        Me.pnlLotes.Controls.Add(Me.txtCantLote1)
        Me.pnlLotes.Controls.Add(Me.txtPartLote3)
        Me.pnlLotes.Controls.Add(Me.txtPartLote2)
        Me.pnlLotes.Controls.Add(Me.txtCantLote2)
        Me.pnlLotes.Location = New System.Drawing.Point(595, 386)
        Me.pnlLotes.Name = "pnlLotes"
        Me.pnlLotes.Size = New System.Drawing.Size(159, 101)
        Me.pnlLotes.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(85, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "CANTIDAD"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "PARTIDA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "HOJA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "FECHA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "FÓRMULA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(143, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "PROCEDIMIENTO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(306, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "ESPECIFICACIÓN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "PRODUCTO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(599, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "EQUIPO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(67, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "TEÓRICO"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(302, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "REAL"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(571, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Fecha Ingreso"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 393)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "TIPO"
        '
        'lblMPoPT
        '
        Me.lblMPoPT.AutoSize = True
        Me.lblMPoPT.Location = New System.Drawing.Point(63, 393)
        Me.lblMPoPT.Name = "lblMPoPT"
        Me.lblMPoPT.Size = New System.Drawing.Size(70, 13)
        Me.lblMPoPT.TabIndex = 36
        Me.lblMPoPT.Text = "MAT. PRIMA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(148, 393)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "DESCRIPCIÓN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(510, 392)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "CANTIDAD"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(8, 436)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(126, 36)
        Me.btnGrabar.TabIndex = 39
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(8, 475)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(126, 36)
        Me.btnLimpiar.TabIndex = 40
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(262, 436)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(126, 36)
        Me.btnConsulta.TabIndex = 41
        Me.btnConsulta.Text = "CONSULTA"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnBlockNotas
        '
        Me.btnBlockNotas.Location = New System.Drawing.Point(135, 436)
        Me.btnBlockNotas.Name = "btnBlockNotas"
        Me.btnBlockNotas.Size = New System.Drawing.Size(126, 36)
        Me.btnBlockNotas.TabIndex = 42
        Me.btnBlockNotas.Text = "BLOCK NOTAS"
        Me.btnBlockNotas.UseVisualStyleBackColor = True
        '
        'btnBajaHoja
        '
        Me.btnBajaHoja.Location = New System.Drawing.Point(262, 475)
        Me.btnBajaHoja.Name = "btnBajaHoja"
        Me.btnBajaHoja.Size = New System.Drawing.Size(126, 36)
        Me.btnBajaHoja.TabIndex = 43
        Me.btnBajaHoja.Text = "DAR DE BAJA"
        Me.btnBajaHoja.UseVisualStyleBackColor = True
        '
        'btnNuevaFila
        '
        Me.btnNuevaFila.Location = New System.Drawing.Point(481, 435)
        Me.btnNuevaFila.Name = "btnNuevaFila"
        Me.btnNuevaFila.Size = New System.Drawing.Size(109, 37)
        Me.btnNuevaFila.TabIndex = 44
        Me.btnNuevaFila.Text = "NUEVA FILA"
        Me.btnNuevaFila.UseVisualStyleBackColor = True
        '
        'btnEditarFila
        '
        Me.btnEditarFila.Enabled = False
        Me.btnEditarFila.Location = New System.Drawing.Point(481, 474)
        Me.btnEditarFila.Name = "btnEditarFila"
        Me.btnEditarFila.Size = New System.Drawing.Size(109, 37)
        Me.btnEditarFila.TabIndex = 45
        Me.btnEditarFila.Text = "EDITAR FILA"
        Me.btnEditarFila.UseVisualStyleBackColor = True
        '
        'DGV_IngredientosHojaProduccion
        '
        Me.DGV_IngredientosHojaProduccion.AllowUserToAddRows = False
        Me.DGV_IngredientosHojaProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_IngredientosHojaProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.Tipo, Me.MPoPT, Me.Descripcion, Me.Cantidad, Me.Lote1, Me.CantLote1, Me.Lote2, Me.CantLote2, Me.Lote3, Me.CantLote3})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_IngredientosHojaProduccion.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_IngredientosHojaProduccion.DoubleBuffered = True
        Me.DGV_IngredientosHojaProduccion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV_IngredientosHojaProduccion.Location = New System.Drawing.Point(15, 181)
        Me.DGV_IngredientosHojaProduccion.Name = "DGV_IngredientosHojaProduccion"
        Me.DGV_IngredientosHojaProduccion.OrdenamientoColumnasHabilitado = True
        Me.DGV_IngredientosHojaProduccion.RowHeadersWidth = 15
        Me.DGV_IngredientosHojaProduccion.RowTemplate.Height = 20
        Me.DGV_IngredientosHojaProduccion.ShowCellToolTips = False
        Me.DGV_IngredientosHojaProduccion.SinClickDerecho = False
        Me.DGV_IngredientosHojaProduccion.Size = New System.Drawing.Size(734, 201)
        Me.DGV_IngredientosHojaProduccion.TabIndex = 13
        '
        'Linea
        '
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.Visible = False
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 53
        '
        'MPoPT
        '
        Me.MPoPT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MPoPT.DataPropertyName = "MPoPT"
        Me.MPoPT.HeaderText = "Mat. Prima o Prod. Terminado"
        Me.MPoPT.MinimumWidth = 180
        Me.MPoPT.Name = "MPoPT"
        Me.MPoPT.Width = 180
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cantidad.DataPropertyName = "Cantidad"
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 74
        '
        'Lote1
        '
        Me.Lote1.HeaderText = "Lote1"
        Me.Lote1.Name = "Lote1"
        Me.Lote1.Visible = False
        '
        'CantLote1
        '
        Me.CantLote1.HeaderText = "CantLote1"
        Me.CantLote1.Name = "CantLote1"
        Me.CantLote1.Visible = False
        '
        'Lote2
        '
        Me.Lote2.HeaderText = "Lote2"
        Me.Lote2.Name = "Lote2"
        Me.Lote2.Visible = False
        '
        'CantLote2
        '
        Me.CantLote2.HeaderText = "CantLote2"
        Me.CantLote2.Name = "CantLote2"
        Me.CantLote2.Visible = False
        '
        'Lote3
        '
        Me.Lote3.HeaderText = "Lote3"
        Me.Lote3.Name = "Lote3"
        Me.Lote3.Visible = False
        '
        'CantLote3
        '
        Me.CantLote3.HeaderText = "CantLote3"
        Me.CantLote3.Name = "CantLote3"
        Me.CantLote3.Visible = False
        '
        'rtxtAgenda
        '
        Me.rtxtAgenda.Location = New System.Drawing.Point(3, 3)
        Me.rtxtAgenda.Name = "rtxtAgenda"
        Me.rtxtAgenda.Size = New System.Drawing.Size(545, 344)
        Me.rtxtAgenda.TabIndex = 46
        Me.rtxtAgenda.Text = ""
        '
        'pnlAgenda
        '
        Me.pnlAgenda.Controls.Add(Me.rtxtAgenda)
        Me.pnlAgenda.Location = New System.Drawing.Point(95, 92)
        Me.pnlAgenda.Name = "pnlAgenda"
        Me.pnlAgenda.Size = New System.Drawing.Size(551, 350)
        Me.pnlAgenda.TabIndex = 47
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnpnlAyudaVolver)
        Me.pnlAyuda.Controls.Add(Me.Label19)
        Me.pnlAyuda.Controls.Add(Me.DGV_Ayuda)
        Me.pnlAyuda.Controls.Add(Me.cbxAyuda)
        Me.pnlAyuda.Controls.Add(Me.txtAyuda)
        Me.pnlAyuda.Location = New System.Drawing.Point(179, 122)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(403, 245)
        Me.pnlAyuda.TabIndex = 49
        '
        'btnpnlAyudaVolver
        '
        Me.btnpnlAyudaVolver.Location = New System.Drawing.Point(116, 206)
        Me.btnpnlAyudaVolver.Name = "btnpnlAyudaVolver"
        Me.btnpnlAyudaVolver.Size = New System.Drawing.Size(170, 32)
        Me.btnpnlAyudaVolver.TabIndex = 5
        Me.btnpnlAyudaVolver.Text = "CERRAR"
        Me.btnpnlAyudaVolver.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(73, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Que desea buscar :"
        '
        'DGV_Ayuda
        '
        Me.DGV_Ayuda.AllowUserToAddRows = False
        Me.DGV_Ayuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ayuda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoAyuda, Me.DescripcionAyuda})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Ayuda.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Ayuda.DoubleBuffered = True
        Me.DGV_Ayuda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Ayuda.Location = New System.Drawing.Point(10, 71)
        Me.DGV_Ayuda.Name = "DGV_Ayuda"
        Me.DGV_Ayuda.OrdenamientoColumnasHabilitado = True
        Me.DGV_Ayuda.RowHeadersWidth = 15
        Me.DGV_Ayuda.RowTemplate.Height = 20
        Me.DGV_Ayuda.ShowCellToolTips = False
        Me.DGV_Ayuda.SinClickDerecho = False
        Me.DGV_Ayuda.Size = New System.Drawing.Size(381, 130)
        Me.DGV_Ayuda.TabIndex = 3
        '
        'CodigoAyuda
        '
        Me.CodigoAyuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CodigoAyuda.DataPropertyName = "CodigoAyuda"
        Me.CodigoAyuda.HeaderText = "Codigo"
        Me.CodigoAyuda.Name = "CodigoAyuda"
        Me.CodigoAyuda.Width = 65
        '
        'DescripcionAyuda
        '
        Me.DescripcionAyuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionAyuda.DataPropertyName = "DescripcionAyuda"
        Me.DescripcionAyuda.HeaderText = "Descripcion"
        Me.DescripcionAyuda.Name = "DescripcionAyuda"
        '
        'cbxAyuda
        '
        Me.cbxAyuda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAyuda.FormattingEnabled = True
        Me.cbxAyuda.Items.AddRange(New Object() {"Materia Prima", "Producto Terminado"})
        Me.cbxAyuda.Location = New System.Drawing.Point(174, 15)
        Me.cbxAyuda.Name = "cbxAyuda"
        Me.cbxAyuda.Size = New System.Drawing.Size(168, 21)
        Me.cbxAyuda.TabIndex = 2
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(10, 45)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(381, 20)
        Me.txtAyuda.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtVersionFormulaV1)
        Me.GroupBox1.Controls.Add(Me.txtProcedimientoV2)
        Me.GroupBox1.Controls.Add(Me.txtEspecificacionV3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(281, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 50)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "VERSIONES"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtRendimientoTeorico)
        Me.GroupBox2.Controls.Add(Me.txtRendimientoReal)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 43)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RENDIMIENTOS"
        '
        'IngresoActualizacionHojaProduccionFarma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 514)
        Me.Controls.Add(Me.pnlAgenda)
        Me.Controls.Add(Me.pnlAyuda)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEditarFila)
        Me.Controls.Add(Me.btnNuevaFila)
        Me.Controls.Add(Me.btnBajaHoja)
        Me.Controls.Add(Me.btnBlockNotas)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblMPoPT)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlLotes)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtDescripcionMPoPT)
        Me.Controls.Add(Me.mastxtMPoPT)
        Me.Controls.Add(Me.cbxTipo)
        Me.Controls.Add(Me.DGV_IngredientosHojaProduccion)
        Me.Controls.Add(Me.txtEquipo)
        Me.Controls.Add(Me.txtDescipcion)
        Me.Controls.Add(Me.mastxtProducto)
        Me.Controls.Add(Me.mastxtFechaIngreso)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.txtHojaProduccion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(10, 20)
        Me.MaximizeBox = False
        Me.Name = "IngresoActualizacionHojaProduccionFarma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlLotes.ResumeLayout(False)
        Me.pnlLotes.PerformLayout()
        CType(Me.DGV_IngredientosHojaProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAgenda.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHojaProduccion As System.Windows.Forms.TextBox
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtFechaIngreso As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtVersionFormulaV1 As System.Windows.Forms.TextBox
    Friend WithEvents txtProcedimientoV2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEspecificacionV3 As System.Windows.Forms.TextBox
    Friend WithEvents mastxtProducto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescipcion As System.Windows.Forms.TextBox
    Friend WithEvents txtEquipo As System.Windows.Forms.TextBox
    Friend WithEvents txtRendimientoTeorico As System.Windows.Forms.TextBox
    Friend WithEvents txtRendimientoReal As System.Windows.Forms.TextBox
    Friend WithEvents DGV_IngredientosHojaProduccion As Util.DBDataGridView
    Friend WithEvents cbxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents mastxtMPoPT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescripcionMPoPT As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPartLote1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCantLote1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartLote2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCantLote2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartLote3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCantLote3 As System.Windows.Forms.TextBox
    Friend WithEvents pnlLotes As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblMPoPT As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnBlockNotas As System.Windows.Forms.Button
    Friend WithEvents btnBajaHoja As System.Windows.Forms.Button
    Friend WithEvents btnNuevaFila As System.Windows.Forms.Button
    Friend WithEvents btnEditarFila As System.Windows.Forms.Button
    Friend WithEvents rtxtAgenda As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlAgenda As System.Windows.Forms.Panel
    Friend WithEvents pnlAyuda As System.Windows.Forms.Panel
    Friend WithEvents btnpnlAyudaVolver As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DGV_Ayuda As Util.DBDataGridView
    Friend WithEvents CodigoAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxAyuda As System.Windows.Forms.ComboBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPoPT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantLote1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantLote2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantLote3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
