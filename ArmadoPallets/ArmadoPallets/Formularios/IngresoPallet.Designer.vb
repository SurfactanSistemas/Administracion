﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoPallet
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_Base = New System.Windows.Forms.TextBox()
        Me.txtDisponible = New System.Windows.Forms.MaskedTextBox()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.txtProforma = New System.Windows.Forms.TextBox()
        Me.txtAltura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTara = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescPallet = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btn_ActualizarDatosEnvases = New System.Windows.Forms.Button()
        Me.btnAgregarPallet = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregarPT = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblTotalKgNetos = New System.Windows.Forms.Label()
        Me.lblTotalKgBrutos = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtFechaAux2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.Terminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescTerminado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Envase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEnvase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadUnidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutMenu, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.Panel1, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 2
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(833, 418)
        Me.LayoutPrincipal.TabIndex = 1
        '
        'LayoutMenu
        '
        Me.LayoutMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.LayoutMenu.ColumnCount = 3
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.LayoutMenu.Controls.Add(Me.Panel4, 2, 0)
        Me.LayoutMenu.Controls.Add(Me.Panel2, 0, 0)
        Me.LayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutMenu.Location = New System.Drawing.Point(0, 0)
        Me.LayoutMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutMenu.Name = "LayoutMenu"
        Me.LayoutMenu.RowCount = 1
        Me.LayoutMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.Size = New System.Drawing.Size(833, 46)
        Me.LayoutMenu.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(586, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(247, 46)
        Me.Panel4.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(35, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 46)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(33, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO PALLET"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(833, 372)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(833, 372)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(827, 81)
        Me.Panel3.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Base)
        Me.GroupBox1.Controls.Add(Me.txtDisponible)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPedido)
        Me.GroupBox1.Controls.Add(Me.txtProforma)
        Me.GroupBox1.Controls.Add(Me.txtAltura)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTara)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblDescPallet)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(816, 77)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información Pallet"
        '
        'txt_Base
        '
        Me.txt_Base.Location = New System.Drawing.Point(401, 49)
        Me.txt_Base.MaxLength = 15
        Me.txt_Base.Name = "txt_Base"
        Me.txt_Base.Size = New System.Drawing.Size(100, 20)
        Me.txt_Base.TabIndex = 4
        '
        'txtDisponible
        '
        Me.txtDisponible.Location = New System.Drawing.Point(282, 48)
        Me.txtDisponible.Mask = "00/00/0000"
        Me.txtDisponible.Name = "txtDisponible"
        Me.txtDisponible.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDisponible.Size = New System.Drawing.Size(67, 20)
        Me.txtDisponible.TabIndex = 3
        Me.txtDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(112, 19)
        Me.txtCodigo.Mask = "AA-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(67, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(523, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Peso (Tara):"
        '
        'txtPedido
        '
        Me.txtPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedido.Location = New System.Drawing.Point(644, 48)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(12, 21)
        Me.txtPedido.TabIndex = 1
        Me.txtPedido.Visible = False
        '
        'txtProforma
        '
        Me.txtProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProforma.Location = New System.Drawing.Point(655, 48)
        Me.txtProforma.Name = "txtProforma"
        Me.txtProforma.Size = New System.Drawing.Size(12, 21)
        Me.txtProforma.TabIndex = 1
        Me.txtProforma.Visible = False
        '
        'txtAltura
        '
        Me.txtAltura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltura.Location = New System.Drawing.Point(112, 48)
        Me.txtAltura.Name = "txtAltura"
        Me.txtAltura.Size = New System.Drawing.Size(67, 21)
        Me.txtAltura.TabIndex = 1
        Me.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(357, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Base:"
        '
        'lblTara
        '
        Me.lblTara.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblTara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTara.Cursor = System.Windows.Forms.Cursors.No
        Me.lblTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTara.Location = New System.Drawing.Point(597, 48)
        Me.lblTara.Name = "lblTara"
        Me.lblTara.Size = New System.Drawing.Size(65, 21)
        Me.lblTara.TabIndex = 0
        Me.lblTara.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(188, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Disponible el:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Altura:"
        '
        'lblDescPallet
        '
        Me.lblDescPallet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblDescPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescPallet.Cursor = System.Windows.Forms.Cursors.No
        Me.lblDescPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescPallet.Location = New System.Drawing.Point(191, 19)
        Me.lblDescPallet.Name = "lblDescPallet"
        Me.lblDescPallet.Size = New System.Drawing.Size(476, 21)
        Me.lblDescPallet.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Codigo Pallet:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btn_ActualizarDatosEnvases)
        Me.Panel5.Controls.Add(Me.btnAgregarPallet)
        Me.Panel5.Controls.Add(Me.btnEliminar)
        Me.Panel5.Controls.Add(Me.btnAgregarPT)
        Me.Panel5.Controls.Add(Me.btnLimpiar)
        Me.Panel5.Controls.Add(Me.btnCerrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 310)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(833, 62)
        Me.Panel5.TabIndex = 1
        '
        'btn_ActualizarDatosEnvases
        '
        Me.btn_ActualizarDatosEnvases.Location = New System.Drawing.Point(746, 7)
        Me.btn_ActualizarDatosEnvases.Name = "btn_ActualizarDatosEnvases"
        Me.btn_ActualizarDatosEnvases.Size = New System.Drawing.Size(75, 49)
        Me.btn_ActualizarDatosEnvases.TabIndex = 1
        Me.btn_ActualizarDatosEnvases.Text = "Actualizar Datos Envases"
        Me.btn_ActualizarDatosEnvases.UseVisualStyleBackColor = True
        '
        'btnAgregarPallet
        '
        Me.btnAgregarPallet.Location = New System.Drawing.Point(150, 10)
        Me.btnAgregarPallet.Name = "btnAgregarPallet"
        Me.btnAgregarPallet.Size = New System.Drawing.Size(80, 43)
        Me.btnAgregarPallet.TabIndex = 0
        Me.btnAgregarPallet.Text = "Guardar"
        Me.btnAgregarPallet.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(489, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 43)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregarPT
        '
        Me.btnAgregarPT.Location = New System.Drawing.Point(376, 10)
        Me.btnAgregarPT.Name = "btnAgregarPT"
        Me.btnAgregarPT.Size = New System.Drawing.Size(80, 43)
        Me.btnAgregarPT.TabIndex = 0
        Me.btnAgregarPT.Text = "Agregar Producto"
        Me.btnAgregarPT.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(263, 10)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 43)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(602, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 43)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblTotalKgNetos)
        Me.Panel6.Controls.Add(Me.lblTotalKgBrutos)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 268)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(833, 42)
        Me.Panel6.TabIndex = 4
        '
        'lblTotalKgNetos
        '
        Me.lblTotalKgNetos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalKgNetos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalKgNetos.Cursor = System.Windows.Forms.Cursors.No
        Me.lblTotalKgNetos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKgNetos.Location = New System.Drawing.Point(551, 11)
        Me.lblTotalKgNetos.Name = "lblTotalKgNetos"
        Me.lblTotalKgNetos.Size = New System.Drawing.Size(81, 21)
        Me.lblTotalKgNetos.TabIndex = 0
        Me.lblTotalKgNetos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalKgBrutos
        '
        Me.lblTotalKgBrutos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalKgBrutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalKgBrutos.Cursor = System.Windows.Forms.Cursors.No
        Me.lblTotalKgBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKgBrutos.Location = New System.Drawing.Point(308, 11)
        Me.lblTotalKgBrutos.Name = "lblTotalKgBrutos"
        Me.lblTotalKgBrutos.Size = New System.Drawing.Size(71, 21)
        Me.lblTotalKgBrutos.TabIndex = 0
        Me.lblTotalKgBrutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(445, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total Kg Netos:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(200, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Total Kg Brutos:"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtFechaAux2)
        Me.Panel7.Controls.Add(Me.txtFechaAux)
        Me.Panel7.Controls.Add(Me.dgvProductos)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 87)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(833, 181)
        Me.Panel7.TabIndex = 5
        '
        'txtFechaAux2
        '
        Me.txtFechaAux2.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaAux2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux2.Location = New System.Drawing.Point(440, 32)
        Me.txtFechaAux2.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux2.Mask = "AA-000-000"
        Me.txtFechaAux2.Name = "txtFechaAux2"
        Me.txtFechaAux2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux2.Size = New System.Drawing.Size(63, 13)
        Me.txtFechaAux2.TabIndex = 4
        Me.txtFechaAux2.Visible = False
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Location = New System.Drawing.Point(24, 32)
        Me.txtFechaAux.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux.Mask = "AA-00000-000"
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(71, 13)
        Me.txtFechaAux.TabIndex = 1
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Terminado, Me.DescTerminado, Me.Partida, Me.Envase, Me.DescEnvase, Me.CantidadUnidades, Me.KgUnidad, Me.Tara})
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductos.Location = New System.Drawing.Point(3, 3)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersWidth = 18
        Me.dgvProductos.RowTemplate.Height = 18
        Me.dgvProductos.ShowCellToolTips = False
        Me.dgvProductos.Size = New System.Drawing.Size(827, 175)
        Me.dgvProductos.TabIndex = 3
        '
        'Terminado
        '
        Me.Terminado.HeaderText = "Terminado"
        Me.Terminado.MaxInputLength = 12
        Me.Terminado.Name = "Terminado"
        Me.Terminado.ReadOnly = True
        Me.Terminado.Width = 80
        '
        'DescTerminado
        '
        Me.DescTerminado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescTerminado.HeaderText = "Descripcion"
        Me.DescTerminado.MinimumWidth = 100
        Me.DescTerminado.Name = "DescTerminado"
        Me.DescTerminado.ReadOnly = True
        '
        'Partida
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Partida.DefaultCellStyle = DataGridViewCellStyle1
        Me.Partida.HeaderText = "Partida"
        Me.Partida.MaxInputLength = 6
        Me.Partida.Name = "Partida"
        Me.Partida.Width = 80
        '
        'Envase
        '
        Me.Envase.HeaderText = "Envase"
        Me.Envase.MaxInputLength = 10
        Me.Envase.Name = "Envase"
        Me.Envase.ReadOnly = True
        Me.Envase.Width = 70
        '
        'DescEnvase
        '
        Me.DescEnvase.HeaderText = "Descripcion"
        Me.DescEnvase.MinimumWidth = 150
        Me.DescEnvase.Name = "DescEnvase"
        Me.DescEnvase.ReadOnly = True
        Me.DescEnvase.Width = 150
        '
        'CantidadUnidades
        '
        Me.CantidadUnidades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CantidadUnidades.DefaultCellStyle = DataGridViewCellStyle2
        Me.CantidadUnidades.HeaderText = "Cant Envases"
        Me.CantidadUnidades.MaxInputLength = 3
        Me.CantidadUnidades.Name = "CantidadUnidades"
        Me.CantidadUnidades.Width = 98
        '
        'KgUnidad
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.KgUnidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.KgUnidad.HeaderText = "Kg x Unidad"
        Me.KgUnidad.Name = "KgUnidad"
        Me.KgUnidad.Width = 90
        '
        'Tara
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tara.DefaultCellStyle = DataGridViewCellStyle4
        Me.Tara.HeaderText = "Tara x Unidad"
        Me.Tara.Name = "Tara"
        '
        'IngresoPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 418)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IngresoPallet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtAltura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblTotalKgNetos As System.Windows.Forms.Label
    Friend WithEvents lblTotalKgBrutos As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarPallet As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTara As System.Windows.Forms.Label
    Friend WithEvents lblDescPallet As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtProforma As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtFechaAux2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtDisponible As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarPT As System.Windows.Forms.Button
    Friend WithEvents Terminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescTerminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescEnvase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadUnidades As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KgUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tara As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_ActualizarDatosEnvases As System.Windows.Forms.Button
    Friend WithEvents txt_Base As System.Windows.Forms.TextBox
End Class
