﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recibos
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridPagos = New System.Windows.Forms.DataGridView()
        Me.TipoCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PuntoCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridFormasPago = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optVarios = New System.Windows.Forms.RadioButton()
        Me.optAnticipos = New System.Windows.Forms.RadioButton()
        Me.optCtaCte = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFechaAux = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstSeleccion = New Administracion.CustomListBox()
        Me.CustomLabel1 = New Administracion.CustomLabel()
        Me.lblDolares = New Administracion.CustomLabel()
        Me.lblTotalDebitos = New Administracion.CustomLabel()
        Me.txtObservaciones = New Administracion.CustomTextBox()
        Me.CustomLabel12 = New Administracion.CustomLabel()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.lblTotalCreditos = New Administracion.CustomLabel()
        Me.CustomLabel13 = New Administracion.CustomLabel()
        Me.CustomLabel3 = New Administracion.CustomLabel()
        Me.txtRecibo = New Administracion.CustomTextBox()
        Me.txtCliente = New Administracion.CustomTextBox()
        Me.txtNombre = New Administracion.CustomTextBox()
        Me.txtRetGanancias = New Administracion.CustomTextBox()
        Me.txtNombreCuenta = New Administracion.CustomTextBox()
        Me.CustomLabel4 = New Administracion.CustomLabel()
        Me.txtCuenta = New Administracion.CustomTextBox()
        Me.CustomLabel5 = New Administracion.CustomLabel()
        Me.CustomLabel11 = New Administracion.CustomLabel()
        Me.txtRetIva = New Administracion.CustomTextBox()
        Me.txtProvi = New Administracion.CustomTextBox()
        Me.txtRetIB = New Administracion.CustomTextBox()
        Me.CustomLabel10 = New Administracion.CustomLabel()
        Me.CustomLabel7 = New Administracion.CustomLabel()
        Me.CustomLabel6 = New Administracion.CustomLabel()
        Me.txtConsulta = New Administracion.CustomTextBox()
        Me.txtRetSuss = New Administracion.CustomTextBox()
        Me.txtParidad = New Administracion.CustomTextBox()
        Me.CustomLabel9 = New Administracion.CustomLabel()
        Me.lstFiltrada = New Administracion.CustomListBox()
        Me.lstConsulta = New Administracion.CustomListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImpresion = New Administracion.CustomButton()
        Me.btnDias = New Administracion.CustomButton()
        Me.btnLimpiar = New Administracion.CustomButton()
        Me.btnCerrar = New Administracion.CustomButton()
        Me.btnIntereses = New Administracion.CustomButton()
        Me.btnAgregar = New Administracion.CustomButton()
        Me.btnConsulta = New Administracion.CustomButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCtaCte = New Administracion.CustomButton()
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridPagos
        '
        Me.gridPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoCC, Me.LetraCC, Me.PuntoCC, Me.NumeroCC, Me.ImporteCC})
        Me.gridPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridPagos.Location = New System.Drawing.Point(31, 229)
        Me.gridPagos.Name = "gridPagos"
        Me.gridPagos.RowHeadersWidth = 20
        Me.gridPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridPagos.Size = New System.Drawing.Size(405, 271)
        Me.gridPagos.TabIndex = 20
        '
        'TipoCC
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TipoCC.DefaultCellStyle = DataGridViewCellStyle9
        Me.TipoCC.FillWeight = 61.20156!
        Me.TipoCC.HeaderText = "Tipo"
        Me.TipoCC.Name = "TipoCC"
        Me.TipoCC.ReadOnly = True
        '
        'LetraCC
        '
        Me.LetraCC.FillWeight = 59.29222!
        Me.LetraCC.HeaderText = "Letra"
        Me.LetraCC.Name = "LetraCC"
        Me.LetraCC.ReadOnly = True
        '
        'PuntoCC
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PuntoCC.DefaultCellStyle = DataGridViewCellStyle10
        Me.PuntoCC.FillWeight = 55.11111!
        Me.PuntoCC.HeaderText = "Punto"
        Me.PuntoCC.Name = "PuntoCC"
        Me.PuntoCC.ReadOnly = True
        '
        'NumeroCC
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroCC.DefaultCellStyle = DataGridViewCellStyle11
        Me.NumeroCC.FillWeight = 125.6672!
        Me.NumeroCC.HeaderText = "Numero"
        Me.NumeroCC.Name = "NumeroCC"
        Me.NumeroCC.ReadOnly = True
        '
        'ImporteCC
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ImporteCC.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImporteCC.FillWeight = 125.6672!
        Me.ImporteCC.HeaderText = "Importe ($)"
        Me.ImporteCC.Name = "ImporteCC"
        '
        'gridFormasPago
        '
        Me.gridFormasPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridFormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFormasPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.numero, Me.fecha, Me.banco, Me.importe})
        Me.gridFormasPago.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridFormasPago.Location = New System.Drawing.Point(444, 229)
        Me.gridFormasPago.Name = "gridFormasPago"
        Me.gridFormasPago.RowHeadersWidth = 20
        Me.gridFormasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridFormasPago.Size = New System.Drawing.Size(402, 272)
        Me.gridFormasPago.TabIndex = 119
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle13
        Me.Tipo.FillWeight = 80.0!
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 53
        '
        'numero
        '
        Me.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numero.DefaultCellStyle = DataGridViewCellStyle14
        Me.numero.FillWeight = 180.0!
        Me.numero.HeaderText = "Numero/Cta"
        Me.numero.Name = "numero"
        Me.numero.Width = 70
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle15
        Me.fecha.FillWeight = 120.0!
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.Width = 90
        '
        'banco
        '
        Me.banco.FillWeight = 90.0!
        Me.banco.HeaderText = "Banco"
        Me.banco.Name = "banco"
        '
        'importe
        '
        Me.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.importe.DefaultCellStyle = DataGridViewCellStyle16
        Me.importe.FillWeight = 80.0!
        Me.importe.HeaderText = "Importe ($)"
        Me.importe.Name = "importe"
        Me.importe.Width = 82
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optVarios)
        Me.GroupBox1.Controls.Add(Me.optAnticipos)
        Me.GroupBox1.Controls.Add(Me.optCtaCte)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(47, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 49)
        Me.GroupBox1.TabIndex = 120
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'optVarios
        '
        Me.optVarios.AutoSize = True
        Me.optVarios.Location = New System.Drawing.Point(371, 18)
        Me.optVarios.Name = "optVarios"
        Me.optVarios.Size = New System.Drawing.Size(64, 22)
        Me.optVarios.TabIndex = 2
        Me.optVarios.Text = "Varios"
        Me.optVarios.UseVisualStyleBackColor = True
        '
        'optAnticipos
        '
        Me.optAnticipos.AutoSize = True
        Me.optAnticipos.Location = New System.Drawing.Point(231, 18)
        Me.optAnticipos.Name = "optAnticipos"
        Me.optAnticipos.Size = New System.Drawing.Size(84, 22)
        Me.optAnticipos.TabIndex = 1
        Me.optAnticipos.Text = "Anticipos"
        Me.optAnticipos.UseVisualStyleBackColor = True
        '
        'optCtaCte
        '
        Me.optCtaCte.AutoSize = True
        Me.optCtaCte.Checked = True
        Me.optCtaCte.Location = New System.Drawing.Point(57, 18)
        Me.optCtaCte.Name = "optCtaCte"
        Me.optCtaCte.Size = New System.Drawing.Size(118, 22)
        Me.optCtaCte.TabIndex = 0
        Me.optCtaCte.TabStop = True
        Me.optCtaCte.Text = "Cobro Cta. Cte."
        Me.optCtaCte.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 50)
        Me.Panel1.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(715, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(27, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Recibos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtFechaAux)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lstSeleccion)
        Me.Panel2.Controls.Add(Me.CustomLabel1)
        Me.Panel2.Controls.Add(Me.lblDolares)
        Me.Panel2.Controls.Add(Me.lblTotalDebitos)
        Me.Panel2.Controls.Add(Me.txtObservaciones)
        Me.Panel2.Controls.Add(Me.CustomLabel12)
        Me.Panel2.Controls.Add(Me.CustomLabel2)
        Me.Panel2.Controls.Add(Me.lblTotalCreditos)
        Me.Panel2.Controls.Add(Me.CustomLabel13)
        Me.Panel2.Controls.Add(Me.CustomLabel3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtRecibo)
        Me.Panel2.Controls.Add(Me.gridFormasPago)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.gridPagos)
        Me.Panel2.Controls.Add(Me.txtRetGanancias)
        Me.Panel2.Controls.Add(Me.txtNombreCuenta)
        Me.Panel2.Controls.Add(Me.CustomLabel4)
        Me.Panel2.Controls.Add(Me.txtCuenta)
        Me.Panel2.Controls.Add(Me.CustomLabel5)
        Me.Panel2.Controls.Add(Me.CustomLabel11)
        Me.Panel2.Controls.Add(Me.txtRetIva)
        Me.Panel2.Controls.Add(Me.txtProvi)
        Me.Panel2.Controls.Add(Me.txtRetIB)
        Me.Panel2.Controls.Add(Me.CustomLabel10)
        Me.Panel2.Controls.Add(Me.CustomLabel7)
        Me.Panel2.Controls.Add(Me.CustomLabel6)
        Me.Panel2.Controls.Add(Me.txtConsulta)
        Me.Panel2.Controls.Add(Me.txtRetSuss)
        Me.Panel2.Controls.Add(Me.txtParidad)
        Me.Panel2.Controls.Add(Me.CustomLabel9)
        Me.Panel2.Controls.Add(Me.lstFiltrada)
        Me.Panel2.Controls.Add(Me.lstConsulta)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(-1, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(883, 571)
        Me.Panel2.TabIndex = 125
        '
        'txtFechaAux
        '
        Me.txtFechaAux.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFechaAux.Location = New System.Drawing.Point(614, 254)
        Me.txtFechaAux.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFechaAux.Mask = "00/00/0000"
        Me.txtFechaAux.MaximumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.MinimumSize = New System.Drawing.Size(60, 15)
        Me.txtFechaAux.Name = "txtFechaAux"
        Me.txtFechaAux.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaAux.Size = New System.Drawing.Size(60, 13)
        Me.txtFechaAux.TabIndex = 127
        Me.txtFechaAux.ValidatingType = GetType(Date)
        Me.txtFechaAux.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(305, 17)
        Me.txtFecha.Mask = "##/##/####"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(70, 20)
        Me.txtFecha.TabIndex = 126
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(634, 504)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 18)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Total Crédito ($)"
        '
        'lstSeleccion
        '
        Me.lstSeleccion.Cleanable = False
        Me.lstSeleccion.EnterIndex = -1
        Me.lstSeleccion.FormattingEnabled = True
        Me.lstSeleccion.Items.AddRange(New Object() {"Clientes", "Cuentas Corrientes"})
        Me.lstSeleccion.LabelAssociationKey = -1
        Me.lstSeleccion.Location = New System.Drawing.Point(559, 20)
        Me.lstSeleccion.Name = "lstSeleccion"
        Me.lstSeleccion.Size = New System.Drawing.Size(254, 199)
        Me.lstSeleccion.TabIndex = 108
        Me.lstSeleccion.Visible = False
        '
        'CustomLabel1
        '
        Me.CustomLabel1.AutoSize = True
        Me.CustomLabel1.ControlAssociationKey = 1
        Me.CustomLabel1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel1.Location = New System.Drawing.Point(72, 20)
        Me.CustomLabel1.Name = "CustomLabel1"
        Me.CustomLabel1.Size = New System.Drawing.Size(80, 18)
        Me.CustomLabel1.TabIndex = 80
        Me.CustomLabel1.Text = "Nro. Recibo"
        '
        'lblDolares
        '
        Me.lblDolares.BackColor = System.Drawing.SystemColors.Control
        Me.lblDolares.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDolares.ControlAssociationKey = -1
        Me.lblDolares.Location = New System.Drawing.Point(174, 503)
        Me.lblDolares.Name = "lblDolares"
        Me.lblDolares.Size = New System.Drawing.Size(74, 22)
        Me.lblDolares.TabIndex = 121
        Me.lblDolares.Text = "0,00"
        Me.lblDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDebitos
        '
        Me.lblTotalDebitos.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalDebitos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalDebitos.ControlAssociationKey = -1
        Me.lblTotalDebitos.Location = New System.Drawing.Point(352, 503)
        Me.lblTotalDebitos.Name = "lblTotalDebitos"
        Me.lblTotalDebitos.Size = New System.Drawing.Size(84, 22)
        Me.lblTotalDebitos.TabIndex = 121
        Me.lblTotalDebitos.Text = "0,00"
        Me.lblTotalDebitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Cleanable = False
        Me.txtObservaciones.Empty = True
        Me.txtObservaciones.EnterIndex = 11
        Me.txtObservaciones.LabelAssociationKey = 12
        Me.txtObservaciones.Location = New System.Drawing.Point(158, 147)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(381, 20)
        Me.txtObservaciones.TabIndex = 123
        Me.txtObservaciones.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel12
        '
        Me.CustomLabel12.BackColor = System.Drawing.SystemColors.Control
        Me.CustomLabel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomLabel12.ControlAssociationKey = -1
        Me.CustomLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel12.Location = New System.Drawing.Point(444, 538)
        Me.CustomLabel12.Name = "CustomLabel12"
        Me.CustomLabel12.Size = New System.Drawing.Size(402, 22)
        Me.CustomLabel12.TabIndex = 118
        Me.CustomLabel12.Text = "Tipo Doc.: 1) Ef. 2) Ch. 3) Doc. 4) Varios "
        Me.CustomLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.ControlAssociationKey = 4
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(68, 46)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(84, 18)
        Me.CustomLabel2.TabIndex = 82
        Me.CustomLabel2.Text = "Cod. Cliente"
        '
        'lblTotalCreditos
        '
        Me.lblTotalCreditos.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalCreditos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCreditos.ControlAssociationKey = -1
        Me.lblTotalCreditos.Location = New System.Drawing.Point(742, 503)
        Me.lblTotalCreditos.Name = "lblTotalCreditos"
        Me.lblTotalCreditos.Size = New System.Drawing.Size(100, 22)
        Me.lblTotalCreditos.TabIndex = 104
        Me.lblTotalCreditos.Text = "0,00"
        Me.lblTotalCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomLabel13
        '
        Me.CustomLabel13.AutoSize = True
        Me.CustomLabel13.ControlAssociationKey = 12
        Me.CustomLabel13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel13.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel13.Location = New System.Drawing.Point(53, 149)
        Me.CustomLabel13.Name = "CustomLabel13"
        Me.CustomLabel13.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel13.TabIndex = 122
        Me.CustomLabel13.Text = "Observaciones"
        '
        'CustomLabel3
        '
        Me.CustomLabel3.AutoSize = True
        Me.CustomLabel3.ControlAssociationKey = 2
        Me.CustomLabel3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel3.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel3.Location = New System.Drawing.Point(257, 20)
        Me.CustomLabel3.Name = "CustomLabel3"
        Me.CustomLabel3.Size = New System.Drawing.Size(44, 18)
        Me.CustomLabel3.TabIndex = 85
        Me.CustomLabel3.Text = "Fecha"
        '
        'txtRecibo
        '
        Me.txtRecibo.Cleanable = True
        Me.txtRecibo.Empty = False
        Me.txtRecibo.EnterIndex = 2
        Me.txtRecibo.LabelAssociationKey = 1
        Me.txtRecibo.Location = New System.Drawing.Point(158, 17)
        Me.txtRecibo.MaxLength = 6
        Me.txtRecibo.Name = "txtRecibo"
        Me.txtRecibo.Size = New System.Drawing.Size(73, 20)
        Me.txtRecibo.TabIndex = 79
        Me.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRecibo.Validator = Administracion.ValidatorType.Numeric
        '
        'txtCliente
        '
        Me.txtCliente.Cleanable = True
        Me.txtCliente.Empty = False
        Me.txtCliente.EnterIndex = 4
        Me.txtCliente.LabelAssociationKey = 4
        Me.txtCliente.Location = New System.Drawing.Point(158, 43)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(73, 20)
        Me.txtCliente.TabIndex = 83
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Doble Click: Abrir Consulta de Clientes")
        Me.txtCliente.Validator = Administracion.ValidatorType.None
        '
        'txtNombre
        '
        Me.txtNombre.Cleanable = True
        Me.txtNombre.Empty = False
        Me.txtNombre.Enabled = False
        Me.txtNombre.EnterIndex = -1
        Me.txtNombre.LabelAssociationKey = 4
        Me.txtNombre.Location = New System.Drawing.Point(237, 43)
        Me.txtNombre.MaxLength = 1000
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(302, 20)
        Me.txtNombre.TabIndex = 86
        Me.txtNombre.Validator = Administracion.ValidatorType.None
        '
        'txtRetGanancias
        '
        Me.txtRetGanancias.Cleanable = True
        Me.txtRetGanancias.Empty = False
        Me.txtRetGanancias.EnterIndex = 5
        Me.txtRetGanancias.LabelAssociationKey = 5
        Me.txtRetGanancias.Location = New System.Drawing.Point(158, 69)
        Me.txtRetGanancias.Name = "txtRetGanancias"
        Me.txtRetGanancias.Size = New System.Drawing.Size(73, 20)
        Me.txtRetGanancias.TabIndex = 84
        Me.txtRetGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetGanancias.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtNombreCuenta
        '
        Me.txtNombreCuenta.Cleanable = True
        Me.txtNombreCuenta.Empty = True
        Me.txtNombreCuenta.Enabled = False
        Me.txtNombreCuenta.EnterIndex = -1
        Me.txtNombreCuenta.LabelAssociationKey = 9
        Me.txtNombreCuenta.Location = New System.Drawing.Point(237, 121)
        Me.txtNombreCuenta.MaxLength = 1000
        Me.txtNombreCuenta.Name = "txtNombreCuenta"
        Me.txtNombreCuenta.Size = New System.Drawing.Size(302, 20)
        Me.txtNombreCuenta.TabIndex = 113
        Me.txtNombreCuenta.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel4
        '
        Me.CustomLabel4.AutoSize = True
        Me.CustomLabel4.ControlAssociationKey = 5
        Me.CustomLabel4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel4.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel4.Location = New System.Drawing.Point(53, 72)
        Me.CustomLabel4.Name = "CustomLabel4"
        Me.CustomLabel4.Size = New System.Drawing.Size(99, 18)
        Me.CustomLabel4.TabIndex = 88
        Me.CustomLabel4.Text = "Ret. Ganancias"
        '
        'txtCuenta
        '
        Me.txtCuenta.Cleanable = True
        Me.txtCuenta.Empty = True
        Me.txtCuenta.EnterIndex = 9
        Me.txtCuenta.LabelAssociationKey = 9
        Me.txtCuenta.Location = New System.Drawing.Point(158, 121)
        Me.txtCuenta.MaxLength = 10
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(73, 20)
        Me.txtCuenta.TabIndex = 112
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCuenta, "Doble Click: Abrir Consulta de Cuentas Contables")
        Me.txtCuenta.Validator = Administracion.ValidatorType.None
        '
        'CustomLabel5
        '
        Me.CustomLabel5.AutoSize = True
        Me.CustomLabel5.ControlAssociationKey = 7
        Me.CustomLabel5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel5.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel5.Location = New System.Drawing.Point(95, 98)
        Me.CustomLabel5.Name = "CustomLabel5"
        Me.CustomLabel5.Size = New System.Drawing.Size(57, 18)
        Me.CustomLabel5.TabIndex = 89
        Me.CustomLabel5.Text = "Ret. IVA"
        '
        'CustomLabel11
        '
        Me.CustomLabel11.AutoSize = True
        Me.CustomLabel11.ControlAssociationKey = 9
        Me.CustomLabel11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel11.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel11.Location = New System.Drawing.Point(41, 124)
        Me.CustomLabel11.Name = "CustomLabel11"
        Me.CustomLabel11.Size = New System.Drawing.Size(111, 18)
        Me.CustomLabel11.TabIndex = 111
        Me.CustomLabel11.Text = "Cuenta Contable"
        '
        'txtRetIva
        '
        Me.txtRetIva.Cleanable = True
        Me.txtRetIva.Empty = False
        Me.txtRetIva.EnterIndex = 7
        Me.txtRetIva.LabelAssociationKey = 7
        Me.txtRetIva.Location = New System.Drawing.Point(158, 95)
        Me.txtRetIva.Name = "txtRetIva"
        Me.txtRetIva.Size = New System.Drawing.Size(73, 20)
        Me.txtRetIva.TabIndex = 90
        Me.txtRetIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIva.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtProvi
        '
        Me.txtProvi.Cleanable = True
        Me.txtProvi.Empty = True
        Me.txtProvi.EnterIndex = 1
        Me.txtProvi.LabelAssociationKey = 3
        Me.txtProvi.Location = New System.Drawing.Point(477, 19)
        Me.txtProvi.MaxLength = 6
        Me.txtProvi.Name = "txtProvi"
        Me.txtProvi.Size = New System.Drawing.Size(62, 20)
        Me.txtProvi.TabIndex = 109
        Me.txtProvi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtProvi.Validator = Administracion.ValidatorType.Numeric
        '
        'txtRetIB
        '
        Me.txtRetIB.Cleanable = True
        Me.txtRetIB.Empty = False
        Me.txtRetIB.EnterIndex = 6
        Me.txtRetIB.LabelAssociationKey = 6
        Me.txtRetIB.Location = New System.Drawing.Point(305, 69)
        Me.txtRetIB.Name = "txtRetIB"
        Me.txtRetIB.Size = New System.Drawing.Size(70, 20)
        Me.txtRetIB.TabIndex = 91
        Me.txtRetIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetIB.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel10
        '
        Me.CustomLabel10.AutoSize = True
        Me.CustomLabel10.ControlAssociationKey = 3
        Me.CustomLabel10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel10.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel10.Location = New System.Drawing.Point(378, 19)
        Me.CustomLabel10.Name = "CustomLabel10"
        Me.CustomLabel10.Size = New System.Drawing.Size(100, 18)
        Me.CustomLabel10.TabIndex = 110
        Me.CustomLabel10.Text = "Rec. Provisorio"
        '
        'CustomLabel7
        '
        Me.CustomLabel7.AutoSize = True
        Me.CustomLabel7.ControlAssociationKey = 6
        Me.CustomLabel7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel7.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel7.Location = New System.Drawing.Point(245, 70)
        Me.CustomLabel7.Name = "CustomLabel7"
        Me.CustomLabel7.Size = New System.Drawing.Size(56, 18)
        Me.CustomLabel7.TabIndex = 92
        Me.CustomLabel7.Text = "Ret. I.B."
        '
        'CustomLabel6
        '
        Me.CustomLabel6.AutoSize = True
        Me.CustomLabel6.ControlAssociationKey = 8
        Me.CustomLabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel6.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel6.Location = New System.Drawing.Point(234, 96)
        Me.CustomLabel6.Name = "CustomLabel6"
        Me.CustomLabel6.Size = New System.Drawing.Size(67, 18)
        Me.CustomLabel6.TabIndex = 93
        Me.CustomLabel6.Text = "Ret. Suss."
        '
        'txtConsulta
        '
        Me.txtConsulta.Cleanable = False
        Me.txtConsulta.Empty = True
        Me.txtConsulta.EnterIndex = -1
        Me.txtConsulta.LabelAssociationKey = -1
        Me.txtConsulta.Location = New System.Drawing.Point(559, 19)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(254, 20)
        Me.txtConsulta.TabIndex = 107
        Me.txtConsulta.Validator = Administracion.ValidatorType.None
        Me.txtConsulta.Visible = False
        '
        'txtRetSuss
        '
        Me.txtRetSuss.Cleanable = True
        Me.txtRetSuss.Empty = False
        Me.txtRetSuss.EnterIndex = 8
        Me.txtRetSuss.LabelAssociationKey = 8
        Me.txtRetSuss.Location = New System.Drawing.Point(305, 95)
        Me.txtRetSuss.Name = "txtRetSuss"
        Me.txtRetSuss.Size = New System.Drawing.Size(70, 20)
        Me.txtRetSuss.TabIndex = 94
        Me.txtRetSuss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetSuss.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'txtParidad
        '
        Me.txtParidad.Cleanable = True
        Me.txtParidad.Empty = True
        Me.txtParidad.EnterIndex = 10
        Me.txtParidad.LabelAssociationKey = 11
        Me.txtParidad.Location = New System.Drawing.Point(440, 72)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(99, 20)
        Me.txtParidad.TabIndex = 95
        Me.txtParidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtParidad.Validator = Administracion.ValidatorType.PositiveFloat
        '
        'CustomLabel9
        '
        Me.CustomLabel9.AutoSize = True
        Me.CustomLabel9.ControlAssociationKey = 11
        Me.CustomLabel9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CustomLabel9.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel9.Location = New System.Drawing.Point(381, 71)
        Me.CustomLabel9.Name = "CustomLabel9"
        Me.CustomLabel9.Size = New System.Drawing.Size(55, 18)
        Me.CustomLabel9.TabIndex = 96
        Me.CustomLabel9.Text = "Paridad"
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(559, 45)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(254, 173)
        Me.lstFiltrada.TabIndex = 124
        Me.lstFiltrada.Visible = False
        '
        'lstConsulta
        '
        Me.lstConsulta.Cleanable = False
        Me.lstConsulta.EnterIndex = -1
        Me.lstConsulta.FormattingEnabled = True
        Me.lstConsulta.LabelAssociationKey = -1
        Me.lstConsulta.Location = New System.Drawing.Point(559, 45)
        Me.lstConsulta.Name = "lstConsulta"
        Me.lstConsulta.Size = New System.Drawing.Size(254, 173)
        Me.lstConsulta.TabIndex = 106
        Me.lstConsulta.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(251, 504)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 18)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Total Débito ($)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(33, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 14)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Diferencia de Cambio (u$s)"
        '
        'btnImpresion
        '
        Me.btnImpresion.BackgroundImage = Global.Administracion.My.Resources.Resources.imprimir
        Me.btnImpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImpresion.Cleanable = False
        Me.btnImpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImpresion.EnterIndex = -1
        Me.btnImpresion.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.BorderSize = 0
        Me.btnImpresion.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresion.LabelAssociationKey = -1
        Me.btnImpresion.Location = New System.Drawing.Point(464, 631)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(58, 51)
        Me.btnImpresion.TabIndex = 132
        Me.ToolTip1.SetToolTip(Me.btnImpresion, "Imprimir")
        Me.btnImpresion.UseVisualStyleBackColor = True
        '
        'btnDias
        '
        Me.btnDias.BackgroundImage = Global.Administracion.My.Resources.Resources.calendar
        Me.btnDias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDias.Cleanable = False
        Me.btnDias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDias.EnterIndex = -1
        Me.btnDias.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDias.FlatAppearance.BorderSize = 0
        Me.btnDias.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnDias.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnDias.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDias.LabelAssociationKey = -1
        Me.btnDias.Location = New System.Drawing.Point(672, 631)
        Me.btnDias.Name = "btnDias"
        Me.btnDias.Size = New System.Drawing.Size(58, 51)
        Me.btnDias.TabIndex = 131
        Me.ToolTip1.SetToolTip(Me.btnDias, "Dias")
        Me.btnDias.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cleanable = False
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.EnterIndex = -1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.LabelAssociationKey = -1
        Me.btnLimpiar.Location = New System.Drawing.Point(568, 631)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(58, 51)
        Me.btnLimpiar.TabIndex = 130
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cleanable = False
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.EnterIndex = -1
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.LabelAssociationKey = -1
        Me.btnCerrar.Location = New System.Drawing.Point(360, 631)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(58, 51)
        Me.btnCerrar.TabIndex = 129
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnIntereses
        '
        Me.btnIntereses.BackgroundImage = Global.Administracion.My.Resources.Resources.calculadora
        Me.btnIntereses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnIntereses.Cleanable = False
        Me.btnIntereses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIntereses.EnterIndex = -1
        Me.btnIntereses.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.BorderSize = 0
        Me.btnIntereses.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnIntereses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIntereses.LabelAssociationKey = -1
        Me.btnIntereses.Location = New System.Drawing.Point(152, 631)
        Me.btnIntereses.Name = "btnIntereses"
        Me.btnIntereses.Size = New System.Drawing.Size(58, 51)
        Me.btnIntereses.TabIndex = 128
        Me.ToolTip1.SetToolTip(Me.btnIntereses, "Intereses")
        Me.btnIntereses.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cleanable = False
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.EnterIndex = -1
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.LabelAssociationKey = -1
        Me.btnAgregar.Location = New System.Drawing.Point(48, 631)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(58, 51)
        Me.btnAgregar.TabIndex = 126
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cleanable = False
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.EnterIndex = -1
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.LabelAssociationKey = -1
        Me.btnConsulta.Location = New System.Drawing.Point(256, 631)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(58, 51)
        Me.btnConsulta.TabIndex = 127
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consulta Clientes/Cuentas Contables")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCtaCte
        '
        Me.btnCtaCte.BackgroundImage = Global.Administracion.My.Resources.Resources.bank
        Me.btnCtaCte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCtaCte.Cleanable = False
        Me.btnCtaCte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCtaCte.EnterIndex = -1
        Me.btnCtaCte.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.BorderSize = 0
        Me.btnCtaCte.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCtaCte.LabelAssociationKey = -1
        Me.btnCtaCte.Location = New System.Drawing.Point(776, 631)
        Me.btnCtaCte.Name = "btnCtaCte"
        Me.btnCtaCte.Size = New System.Drawing.Size(58, 51)
        Me.btnCtaCte.TabIndex = 131
        Me.ToolTip1.SetToolTip(Me.btnCtaCte, "Consultar Ctas Ctes")
        Me.btnCtaCte.UseVisualStyleBackColor = True
        '
        'Recibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 690)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnCtaCte)
        Me.Controls.Add(Me.btnDias)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnIntereses)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Recibos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.gridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstSeleccion As Administracion.CustomListBox
    Friend WithEvents txtConsulta As Administracion.CustomTextBox
    Friend WithEvents lstConsulta As Administracion.CustomListBox
    Friend WithEvents lblTotalCreditos As Administracion.CustomLabel
    Friend WithEvents CustomLabel9 As Administracion.CustomLabel
    Friend WithEvents txtParidad As Administracion.CustomTextBox
    Friend WithEvents txtRetSuss As Administracion.CustomTextBox
    Friend WithEvents CustomLabel6 As Administracion.CustomLabel
    Friend WithEvents CustomLabel7 As Administracion.CustomLabel
    Friend WithEvents txtRetIB As Administracion.CustomTextBox
    Friend WithEvents txtRetIva As Administracion.CustomTextBox
    Friend WithEvents CustomLabel5 As Administracion.CustomLabel
    Friend WithEvents CustomLabel4 As Administracion.CustomLabel
    Friend WithEvents txtRetGanancias As Administracion.CustomTextBox
    Friend WithEvents gridPagos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombre As Administracion.CustomTextBox
    Friend WithEvents txtCliente As Administracion.CustomTextBox
    Friend WithEvents txtRecibo As Administracion.CustomTextBox
    Friend WithEvents CustomLabel3 As Administracion.CustomLabel
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents CustomLabel1 As Administracion.CustomLabel
    Friend WithEvents txtProvi As Administracion.CustomTextBox
    Friend WithEvents CustomLabel10 As Administracion.CustomLabel
    Friend WithEvents txtNombreCuenta As Administracion.CustomTextBox
    Friend WithEvents txtCuenta As Administracion.CustomTextBox
    Friend WithEvents CustomLabel11 As Administracion.CustomLabel
    Friend WithEvents CustomLabel12 As Administracion.CustomLabel
    Friend WithEvents gridFormasPago As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optVarios As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipos As System.Windows.Forms.RadioButton
    Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents lblTotalDebitos As Administracion.CustomLabel
    Friend WithEvents CustomLabel13 As Administracion.CustomLabel
    Friend WithEvents txtObservaciones As Administracion.CustomTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnImpresion As Administracion.CustomButton
    Friend WithEvents btnDias As Administracion.CustomButton
    Friend WithEvents btnLimpiar As Administracion.CustomButton
    Friend WithEvents btnCerrar As Administracion.CustomButton
    Friend WithEvents btnIntereses As Administracion.CustomButton
    Friend WithEvents btnAgregar As Administracion.CustomButton
    Friend WithEvents btnConsulta As Administracion.CustomButton
    Friend WithEvents lstFiltrada As Administracion.CustomListBox
    Friend WithEvents lblDolares As Administracion.CustomLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaAux As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LetraCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PuntoCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCtaCte As Administracion.CustomButton
End Class
