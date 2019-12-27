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
        Me.DGV_IngredientosHojaProduccion = New ConsultasVarias.DBDataGridView()
        Me.rtxtAgenda = New System.Windows.Forms.RichTextBox()
        Me.pnlAgenda = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnpnlAyudaVolver = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DGV_Ayuda = New ConsultasVarias.DBDataGridView()
        Me.CodigoAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAyuda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxAyuda = New System.Windows.Forms.ComboBox()
        Me.txtAyuda = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
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
        Me.Panel1.SuspendLayout()
        Me.pnlLotes.SuspendLayout()
        CType(Me.DGV_IngredientosHojaProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAgenda.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(173, 464)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 0
        Me.btnVolver.Text = "Volver"
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
        Me.Panel1.Size = New System.Drawing.Size(761, 66)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingreso y Actualizacion de Hoja de Produccion"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(570, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'txtHojaProduccion
        '
        Me.txtHojaProduccion.Location = New System.Drawing.Point(119, 72)
        Me.txtHojaProduccion.MaxLength = 6
        Me.txtHojaProduccion.Name = "txtHojaProduccion"
        Me.txtHojaProduccion.Size = New System.Drawing.Size(74, 20)
        Me.txtHojaProduccion.TabIndex = 2
        Me.txtHojaProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(252, 72)
        Me.mastxtFecha.Mask = "00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(69, 20)
        Me.mastxtFecha.TabIndex = 3
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFechaIngreso
        '
        Me.mastxtFechaIngreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mastxtFechaIngreso.Enabled = False
        Me.mastxtFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mastxtFechaIngreso.Location = New System.Drawing.Point(595, 152)
        Me.mastxtFechaIngreso.Mask = "00/00/0000"
        Me.mastxtFechaIngreso.Name = "mastxtFechaIngreso"
        Me.mastxtFechaIngreso.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaIngreso.Size = New System.Drawing.Size(95, 20)
        Me.mastxtFechaIngreso.TabIndex = 4
        Me.mastxtFechaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersionFormulaV1
        '
        Me.txtVersionFormulaV1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVersionFormulaV1.Location = New System.Drawing.Point(434, 72)
        Me.txtVersionFormulaV1.MaxLength = 2
        Me.txtVersionFormulaV1.Name = "txtVersionFormulaV1"
        Me.txtVersionFormulaV1.Size = New System.Drawing.Size(29, 20)
        Me.txtVersionFormulaV1.TabIndex = 5
        Me.txtVersionFormulaV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProcedimientoV2
        '
        Me.txtProcedimientoV2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProcedimientoV2.Location = New System.Drawing.Point(557, 72)
        Me.txtProcedimientoV2.MaxLength = 2
        Me.txtProcedimientoV2.Name = "txtProcedimientoV2"
        Me.txtProcedimientoV2.Size = New System.Drawing.Size(34, 20)
        Me.txtProcedimientoV2.TabIndex = 6
        Me.txtProcedimientoV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEspecificacionV3
        '
        Me.txtEspecificacionV3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtEspecificacionV3.Location = New System.Drawing.Point(696, 72)
        Me.txtEspecificacionV3.MaxLength = 2
        Me.txtEspecificacionV3.Name = "txtEspecificacionV3"
        Me.txtEspecificacionV3.Size = New System.Drawing.Size(29, 20)
        Me.txtEspecificacionV3.TabIndex = 7
        Me.txtEspecificacionV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtProducto
        '
        Me.mastxtProducto.Location = New System.Drawing.Point(66, 110)
        Me.mastxtProducto.Mask = ">LL-00000-000"
        Me.mastxtProducto.Name = "mastxtProducto"
        Me.mastxtProducto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtProducto.Size = New System.Drawing.Size(100, 20)
        Me.mastxtProducto.TabIndex = 8
        Me.mastxtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescipcion
        '
        Me.txtDescipcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescipcion.Enabled = False
        Me.txtDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescipcion.Location = New System.Drawing.Point(172, 110)
        Me.txtDescipcion.Name = "txtDescipcion"
        Me.txtDescipcion.Size = New System.Drawing.Size(316, 20)
        Me.txtDescipcion.TabIndex = 9
        '
        'txtEquipo
        '
        Me.txtEquipo.Location = New System.Drawing.Point(625, 110)
        Me.txtEquipo.MaxLength = 2
        Me.txtEquipo.Name = "txtEquipo"
        Me.txtEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtEquipo.TabIndex = 10
        Me.txtEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRendimientoTeorico
        '
        Me.txtRendimientoTeorico.Location = New System.Drawing.Point(119, 152)
        Me.txtRendimientoTeorico.MaxLength = 8
        Me.txtRendimientoTeorico.Name = "txtRendimientoTeorico"
        Me.txtRendimientoTeorico.Size = New System.Drawing.Size(100, 20)
        Me.txtRendimientoTeorico.TabIndex = 11
        Me.txtRendimientoTeorico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRendimientoReal
        '
        Me.txtRendimientoReal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRendimientoReal.Enabled = False
        Me.txtRendimientoReal.Location = New System.Drawing.Point(340, 152)
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
        Me.cbxTipo.Location = New System.Drawing.Point(13, 409)
        Me.cbxTipo.Name = "cbxTipo"
        Me.cbxTipo.Size = New System.Drawing.Size(44, 21)
        Me.cbxTipo.TabIndex = 14
        '
        'mastxtMPoPT
        '
        Me.mastxtMPoPT.Location = New System.Drawing.Point(63, 409)
        Me.mastxtMPoPT.Mask = ">LL-000-000"
        Me.mastxtMPoPT.Name = "mastxtMPoPT"
        Me.mastxtMPoPT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtMPoPT.Size = New System.Drawing.Size(100, 20)
        Me.mastxtMPoPT.TabIndex = 15
        Me.mastxtMPoPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionMPoPT
        '
        Me.txtDescripcionMPoPT.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescripcionMPoPT.Enabled = False
        Me.txtDescripcionMPoPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionMPoPT.Location = New System.Drawing.Point(168, 409)
        Me.txtDescripcionMPoPT.Name = "txtDescripcionMPoPT"
        Me.txtDescripcionMPoPT.Size = New System.Drawing.Size(309, 20)
        Me.txtDescripcionMPoPT.TabIndex = 16
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(483, 409)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 17
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote1
        '
        Me.txtPartLote1.Location = New System.Drawing.Point(8, 21)
        Me.txtPartLote1.MaxLength = 6
        Me.txtPartLote1.Name = "txtPartLote1"
        Me.txtPartLote1.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote1.TabIndex = 18
        Me.txtPartLote1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote1
        '
        Me.txtCantLote1.Location = New System.Drawing.Point(85, 21)
        Me.txtCantLote1.MaxLength = 8
        Me.txtCantLote1.Name = "txtCantLote1"
        Me.txtCantLote1.Size = New System.Drawing.Size(71, 20)
        Me.txtCantLote1.TabIndex = 19
        Me.txtCantLote1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote2
        '
        Me.txtPartLote2.Location = New System.Drawing.Point(8, 47)
        Me.txtPartLote2.MaxLength = 6
        Me.txtPartLote2.Name = "txtPartLote2"
        Me.txtPartLote2.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote2.TabIndex = 20
        Me.txtPartLote2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote2
        '
        Me.txtCantLote2.Location = New System.Drawing.Point(85, 47)
        Me.txtCantLote2.MaxLength = 8
        Me.txtCantLote2.Name = "txtCantLote2"
        Me.txtCantLote2.Size = New System.Drawing.Size(71, 20)
        Me.txtCantLote2.TabIndex = 21
        Me.txtCantLote2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLote3
        '
        Me.txtPartLote3.Location = New System.Drawing.Point(8, 73)
        Me.txtPartLote3.MaxLength = 6
        Me.txtPartLote3.Name = "txtPartLote3"
        Me.txtPartLote3.Size = New System.Drawing.Size(71, 20)
        Me.txtPartLote3.TabIndex = 22
        Me.txtPartLote3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantLote3
        '
        Me.txtCantLote3.Location = New System.Drawing.Point(85, 73)
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
        Me.Label17.Location = New System.Drawing.Point(82, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Cantidad"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Partida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Hoja de Produccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(207, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(348, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Version Formula"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(477, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Procedimiento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(614, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Especificaicon"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Producto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(577, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Equipo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Rendimiento Teorico"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(243, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Rendimiento Real"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(514, 155)
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
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Tipo"
        '
        'lblMPoPT
        '
        Me.lblMPoPT.AutoSize = True
        Me.lblMPoPT.Location = New System.Drawing.Point(63, 393)
        Me.lblMPoPT.Name = "lblMPoPT"
        Me.lblMPoPT.Size = New System.Drawing.Size(71, 13)
        Me.lblMPoPT.TabIndex = 36
        Me.lblMPoPT.Text = "Materia Prima"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(170, 393)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Descripcion"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(480, 393)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Cantidad"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(11, 436)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 39
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(11, 464)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 40
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(172, 436)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnConsulta.TabIndex = 41
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnBlockNotas
        '
        Me.btnBlockNotas.Location = New System.Drawing.Point(92, 436)
        Me.btnBlockNotas.Name = "btnBlockNotas"
        Me.btnBlockNotas.Size = New System.Drawing.Size(75, 51)
        Me.btnBlockNotas.TabIndex = 42
        Me.btnBlockNotas.Text = "Block de Notas"
        Me.btnBlockNotas.UseVisualStyleBackColor = True
        '
        'btnBajaHoja
        '
        Me.btnBajaHoja.Location = New System.Drawing.Point(252, 436)
        Me.btnBajaHoja.Name = "btnBajaHoja"
        Me.btnBajaHoja.Size = New System.Drawing.Size(75, 23)
        Me.btnBajaHoja.TabIndex = 43
        Me.btnBajaHoja.Text = "Baja Hoja"
        Me.btnBajaHoja.UseVisualStyleBackColor = True
        '
        'btnNuevaFila
        '
        Me.btnNuevaFila.Location = New System.Drawing.Point(517, 436)
        Me.btnNuevaFila.Name = "btnNuevaFila"
        Me.btnNuevaFila.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevaFila.TabIndex = 44
        Me.btnNuevaFila.Text = "Nueva Fila"
        Me.btnNuevaFila.UseVisualStyleBackColor = True
        '
        'btnEditarFila
        '
        Me.btnEditarFila.Enabled = False
        Me.btnEditarFila.Location = New System.Drawing.Point(517, 464)
        Me.btnEditarFila.Name = "btnEditarFila"
        Me.btnEditarFila.Size = New System.Drawing.Size(75, 23)
        Me.btnEditarFila.TabIndex = 45
        Me.btnEditarFila.Text = "Editar Fila"
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
        'rtxtAgenda
        '
        Me.rtxtAgenda.Location = New System.Drawing.Point(3, 6)
        Me.rtxtAgenda.Name = "rtxtAgenda"
        Me.rtxtAgenda.Size = New System.Drawing.Size(565, 341)
        Me.rtxtAgenda.TabIndex = 46
        Me.rtxtAgenda.Text = ""
        '
        'pnlAgenda
        '
        Me.pnlAgenda.Controls.Add(Me.rtxtAgenda)
        Me.pnlAgenda.Location = New System.Drawing.Point(0, 94)
        Me.pnlAgenda.Name = "pnlAgenda"
        Me.pnlAgenda.Size = New System.Drawing.Size(571, 350)
        Me.pnlAgenda.TabIndex = 47
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnpnlAyudaVolver)
        Me.pnlAyuda.Controls.Add(Me.Label19)
        Me.pnlAyuda.Controls.Add(Me.DGV_Ayuda)
        Me.pnlAyuda.Controls.Add(Me.cbxAyuda)
        Me.pnlAyuda.Controls.Add(Me.txtAyuda)
        Me.pnlAyuda.Controls.Add(Me.Panel4)
        Me.pnlAyuda.Location = New System.Drawing.Point(179, 122)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(403, 245)
        Me.pnlAyuda.TabIndex = 49
        '
        'btnpnlAyudaVolver
        '
        Me.btnpnlAyudaVolver.Location = New System.Drawing.Point(306, 44)
        Me.btnpnlAyudaVolver.Name = "btnpnlAyudaVolver"
        Me.btnpnlAyudaVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnpnlAyudaVolver.TabIndex = 5
        Me.btnpnlAyudaVolver.Text = "Volver"
        Me.btnpnlAyudaVolver.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 49)
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
        Me.DGV_Ayuda.Location = New System.Drawing.Point(10, 99)
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
        Me.cbxAyuda.Location = New System.Drawing.Point(113, 46)
        Me.cbxAyuda.Name = "cbxAyuda"
        Me.cbxAyuda.Size = New System.Drawing.Size(168, 21)
        Me.cbxAyuda.TabIndex = 2
        '
        'txtAyuda
        '
        Me.txtAyuda.Location = New System.Drawing.Point(10, 73)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(381, 20)
        Me.txtAyuda.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(403, 40)
        Me.Panel4.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.Control
        Me.Label20.Location = New System.Drawing.Point(8, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 20)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Buscador "
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
        'IngresoActualizacionHojaProduccionFarma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 489)
        Me.Controls.Add(Me.pnlAyuda)
        Me.Controls.Add(Me.pnlAgenda)
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
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlLotes)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtDescripcionMPoPT)
        Me.Controls.Add(Me.mastxtMPoPT)
        Me.Controls.Add(Me.cbxTipo)
        Me.Controls.Add(Me.DGV_IngredientosHojaProduccion)
        Me.Controls.Add(Me.txtRendimientoReal)
        Me.Controls.Add(Me.txtRendimientoTeorico)
        Me.Controls.Add(Me.txtEquipo)
        Me.Controls.Add(Me.txtDescipcion)
        Me.Controls.Add(Me.mastxtProducto)
        Me.Controls.Add(Me.txtEspecificacionV3)
        Me.Controls.Add(Me.txtProcedimientoV2)
        Me.Controls.Add(Me.txtVersionFormulaV1)
        Me.Controls.Add(Me.mastxtFechaIngreso)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.txtHojaProduccion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVolver)
        Me.Location = New System.Drawing.Point(10, 20)
        Me.Name = "IngresoActualizacionHojaProduccionFarma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IngresoActualizacionHojaProduccionFarma"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlLotes.ResumeLayout(False)
        Me.pnlLotes.PerformLayout()
        CType(Me.DGV_IngredientosHojaProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAgenda.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        CType(Me.DGV_Ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
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
    Friend WithEvents DGV_IngredientosHojaProduccion As ConsultasVarias.DBDataGridView
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
    Friend WithEvents DGV_Ayuda As ConsultasVarias.DBDataGridView
    Friend WithEvents CodigoAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAyuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxAyuda As System.Windows.Forms.ComboBox
    Friend WithEvents txtAyuda As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
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
End Class
