<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingreso_Solicitud
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Solicitante = New System.Windows.Forms.TextBox()
        Me.txt_FechaSolicitud = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbx_Tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Proveedor = New System.Windows.Forms.TextBox()
        Me.txt_ProveedorDescrip = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbx_Moneda = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Importe = New System.Windows.Forms.TextBox()
        Me.txt_FechaRequerida = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chk_Efectivo = New System.Windows.Forms.CheckBox()
        Me.gp_FormasDePago = New System.Windows.Forms.GroupBox()
        Me.chk_DebitoAutomatico = New System.Windows.Forms.CheckBox()
        Me.chk_Tarjeta = New System.Windows.Forms.CheckBox()
        Me.chk_ChequePropio = New System.Windows.Forms.CheckBox()
        Me.chk_ChequeTerceros = New System.Windows.Forms.CheckBox()
        Me.chk_Echeq = New System.Windows.Forms.CheckBox()
        Me.chk_Tranferencia = New System.Windows.Forms.CheckBox()
        Me.txt_Concepto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_CuentaDescrip = New System.Windows.Forms.TextBox()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Adjuntar = New System.Windows.Forms.Button()
        Me.btn_MostrarSolicitud = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Titulo = New System.Windows.Forms.TextBox()
        Me.txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbx_Retenciones = New System.Windows.Forms.GroupBox()
        Me.txt_TotalRetenciones = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_TotalApagar = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_ImportePesos = New System.Windows.Forms.TextBox()
        Me.txt_Paridad = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_RetIVA = New System.Windows.Forms.TextBox()
        Me.txt_RetIBru = New System.Windows.Forms.TextBox()
        Me.txt_RetIBCiudad = New System.Windows.Forms.TextBox()
        Me.txt_RetGanancia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_TipoDolar = New System.Windows.Forms.Label()
        Me.cbx_TipoDolar = New System.Windows.Forms.ComboBox()
        Me.btn_Autorizar = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_Concepto_Pago = New System.Windows.Forms.TextBox()
        Me.btn_MailReclamo = New System.Windows.Forms.Button()
        Me.txt_FechaEmitirOrdenPago = New System.Windows.Forms.MaskedTextBox()
        Me.lbl_FechaEmitirOrdenPago = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.gp_FormasDePago.SuspendLayout()
        Me.gbx_Retenciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(719, 49)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(484, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(28, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(196, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "INGRESO SOLICITUD"
        '
        'txt_Solicitante
        '
        Me.txt_Solicitante.BackColor = System.Drawing.Color.Cyan
        Me.txt_Solicitante.Location = New System.Drawing.Point(79, 64)
        Me.txt_Solicitante.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Solicitante.MaxLength = 20
        Me.txt_Solicitante.Name = "txt_Solicitante"
        Me.txt_Solicitante.ReadOnly = True
        Me.txt_Solicitante.Size = New System.Drawing.Size(179, 22)
        Me.txt_Solicitante.TabIndex = 6
        '
        'txt_FechaSolicitud
        '
        Me.txt_FechaSolicitud.BackColor = System.Drawing.Color.Aqua
        Me.txt_FechaSolicitud.Location = New System.Drawing.Point(388, 62)
        Me.txt_FechaSolicitud.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaSolicitud.Mask = "00/00/0000"
        Me.txt_FechaSolicitud.Name = "txt_FechaSolicitud"
        Me.txt_FechaSolicitud.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaSolicitud.ReadOnly = True
        Me.txt_FechaSolicitud.Size = New System.Drawing.Size(89, 22)
        Me.txt_FechaSolicitud.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Solicitante"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(273, 66)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha Solicitud"
        '
        'cbx_Tipo
        '
        Me.cbx_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Tipo.FormattingEnabled = True
        Me.cbx_Tipo.Items.AddRange(New Object() {"", "Pago a Proveedores", "Varios"})
        Me.cbx_Tipo.Location = New System.Drawing.Point(79, 96)
        Me.cbx_Tipo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Tipo.Name = "cbx_Tipo"
        Me.cbx_Tipo.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Tipo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 101)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Tipo"
        '
        'txt_Proveedor
        '
        Me.txt_Proveedor.Location = New System.Drawing.Point(79, 130)
        Me.txt_Proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Proveedor.MaxLength = 11
        Me.txt_Proveedor.Name = "txt_Proveedor"
        Me.txt_Proveedor.Size = New System.Drawing.Size(101, 22)
        Me.txt_Proveedor.TabIndex = 12
        Me.txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ProveedorDescrip
        '
        Me.txt_ProveedorDescrip.BackColor = System.Drawing.Color.Aqua
        Me.txt_ProveedorDescrip.Location = New System.Drawing.Point(189, 130)
        Me.txt_ProveedorDescrip.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ProveedorDescrip.Name = "txt_ProveedorDescrip"
        Me.txt_ProveedorDescrip.ReadOnly = True
        Me.txt_ProveedorDescrip.Size = New System.Drawing.Size(381, 22)
        Me.txt_ProveedorDescrip.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 134)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Proveedor"
        '
        'txt_Cuenta
        '
        Me.txt_Cuenta.Location = New System.Drawing.Point(79, 171)
        Me.txt_Cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Cuenta.MaxLength = 10
        Me.txt_Cuenta.Name = "txt_Cuenta"
        Me.txt_Cuenta.Size = New System.Drawing.Size(101, 22)
        Me.txt_Cuenta.TabIndex = 15
        Me.txt_Cuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 164)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 34)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cuenta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contable"
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"", "Pesos", "Dolares"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(79, 209)
        Me.cbx_Moneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(101, 24)
        Me.cbx_Moneda.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 213)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Moneda"
        '
        'txt_Importe
        '
        Me.txt_Importe.Location = New System.Drawing.Point(464, 210)
        Me.txt_Importe.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Importe.Name = "txt_Importe"
        Me.txt_Importe.Size = New System.Drawing.Size(132, 22)
        Me.txt_Importe.TabIndex = 19
        Me.txt_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_FechaRequerida
        '
        Me.txt_FechaRequerida.Location = New System.Drawing.Point(143, 341)
        Me.txt_FechaRequerida.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaRequerida.Mask = "00/00/0000"
        Me.txt_FechaRequerida.Name = "txt_FechaRequerida"
        Me.txt_FechaRequerida.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaRequerida.Size = New System.Drawing.Size(89, 22)
        Me.txt_FechaRequerida.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(400, 213)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Importe"
        '
        'chk_Efectivo
        '
        Me.chk_Efectivo.AutoSize = True
        Me.chk_Efectivo.Location = New System.Drawing.Point(9, 32)
        Me.chk_Efectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Efectivo.Name = "chk_Efectivo"
        Me.chk_Efectivo.Size = New System.Drawing.Size(80, 21)
        Me.chk_Efectivo.TabIndex = 22
        Me.chk_Efectivo.Text = "Efectivo"
        Me.chk_Efectivo.UseVisualStyleBackColor = True
        '
        'gp_FormasDePago
        '
        Me.gp_FormasDePago.Controls.Add(Me.chk_DebitoAutomatico)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Tarjeta)
        Me.gp_FormasDePago.Controls.Add(Me.chk_ChequePropio)
        Me.gp_FormasDePago.Controls.Add(Me.chk_ChequeTerceros)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Echeq)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Tranferencia)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Efectivo)
        Me.gp_FormasDePago.Location = New System.Drawing.Point(15, 366)
        Me.gp_FormasDePago.Margin = New System.Windows.Forms.Padding(4)
        Me.gp_FormasDePago.Name = "gp_FormasDePago"
        Me.gp_FormasDePago.Padding = New System.Windows.Forms.Padding(4)
        Me.gp_FormasDePago.Size = New System.Drawing.Size(588, 94)
        Me.gp_FormasDePago.TabIndex = 23
        Me.gp_FormasDePago.TabStop = False
        Me.gp_FormasDePago.Text = "Formas de Pago"
        '
        'chk_DebitoAutomatico
        '
        Me.chk_DebitoAutomatico.AutoSize = True
        Me.chk_DebitoAutomatico.Location = New System.Drawing.Point(449, 32)
        Me.chk_DebitoAutomatico.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_DebitoAutomatico.Name = "chk_DebitoAutomatico"
        Me.chk_DebitoAutomatico.Size = New System.Drawing.Size(145, 21)
        Me.chk_DebitoAutomatico.TabIndex = 28
        Me.chk_DebitoAutomatico.Text = "Debito Automatico"
        Me.chk_DebitoAutomatico.UseVisualStyleBackColor = True
        '
        'chk_Tarjeta
        '
        Me.chk_Tarjeta.AutoSize = True
        Me.chk_Tarjeta.Location = New System.Drawing.Point(317, 61)
        Me.chk_Tarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Tarjeta.Name = "chk_Tarjeta"
        Me.chk_Tarjeta.Size = New System.Drawing.Size(75, 21)
        Me.chk_Tarjeta.TabIndex = 27
        Me.chk_Tarjeta.Text = "Tarjeta"
        Me.chk_Tarjeta.UseVisualStyleBackColor = True
        '
        'chk_ChequePropio
        '
        Me.chk_ChequePropio.AutoSize = True
        Me.chk_ChequePropio.Location = New System.Drawing.Point(317, 32)
        Me.chk_ChequePropio.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_ChequePropio.Name = "chk_ChequePropio"
        Me.chk_ChequePropio.Size = New System.Drawing.Size(124, 21)
        Me.chk_ChequePropio.TabIndex = 26
        Me.chk_ChequePropio.Text = "Cheque Propio"
        Me.chk_ChequePropio.UseVisualStyleBackColor = True
        '
        'chk_ChequeTerceros
        '
        Me.chk_ChequeTerceros.AutoSize = True
        Me.chk_ChequeTerceros.Location = New System.Drawing.Point(156, 61)
        Me.chk_ChequeTerceros.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_ChequeTerceros.Name = "chk_ChequeTerceros"
        Me.chk_ChequeTerceros.Size = New System.Drawing.Size(140, 21)
        Me.chk_ChequeTerceros.TabIndex = 25
        Me.chk_ChequeTerceros.Text = "Cheque Terceros"
        Me.chk_ChequeTerceros.UseVisualStyleBackColor = True
        '
        'chk_Echeq
        '
        Me.chk_Echeq.AutoSize = True
        Me.chk_Echeq.Location = New System.Drawing.Point(156, 32)
        Me.chk_Echeq.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Echeq.Name = "chk_Echeq"
        Me.chk_Echeq.Size = New System.Drawing.Size(75, 21)
        Me.chk_Echeq.TabIndex = 24
        Me.chk_Echeq.Text = "E-cheq"
        Me.chk_Echeq.UseVisualStyleBackColor = True
        '
        'chk_Tranferencia
        '
        Me.chk_Tranferencia.AutoSize = True
        Me.chk_Tranferencia.Location = New System.Drawing.Point(9, 61)
        Me.chk_Tranferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Tranferencia.Name = "chk_Tranferencia"
        Me.chk_Tranferencia.Size = New System.Drawing.Size(118, 21)
        Me.chk_Tranferencia.TabIndex = 23
        Me.chk_Tranferencia.Text = "Transferencia"
        Me.chk_Tranferencia.UseVisualStyleBackColor = True
        '
        'txt_Concepto
        '
        Me.txt_Concepto.Location = New System.Drawing.Point(95, 530)
        Me.txt_Concepto.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Concepto.MaxLength = 200
        Me.txt_Concepto.Multiline = True
        Me.txt_Concepto.Name = "txt_Concepto"
        Me.txt_Concepto.Size = New System.Drawing.Size(477, 96)
        Me.txt_Concepto.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 345)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 17)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Fecha Requerida"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 534)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Detalle"
        '
        'txt_CuentaDescrip
        '
        Me.txt_CuentaDescrip.BackColor = System.Drawing.Color.Aqua
        Me.txt_CuentaDescrip.Location = New System.Drawing.Point(189, 171)
        Me.txt_CuentaDescrip.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_CuentaDescrip.Name = "txt_CuentaDescrip"
        Me.txt_CuentaDescrip.ReadOnly = True
        Me.txt_CuentaDescrip.Size = New System.Drawing.Size(381, 22)
        Me.txt_CuentaDescrip.TabIndex = 27
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(605, 66)
        Me.btn_Grabar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(109, 55)
        Me.btn_Grabar.TabIndex = 28
        Me.btn_Grabar.Text = "GRABAR"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(605, 129)
        Me.btn_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(109, 55)
        Me.btn_Cancelar.TabIndex = 29
        Me.btn_Cancelar.Text = "SALIR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_Adjuntar
        '
        Me.btn_Adjuntar.Location = New System.Drawing.Point(605, 192)
        Me.btn_Adjuntar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Adjuntar.Name = "btn_Adjuntar"
        Me.btn_Adjuntar.Size = New System.Drawing.Size(109, 55)
        Me.btn_Adjuntar.TabIndex = 30
        Me.btn_Adjuntar.Text = "ADJUNTAR ARCHIVOS"
        Me.btn_Adjuntar.UseVisualStyleBackColor = True
        '
        'btn_MostrarSolicitud
        '
        Me.btn_MostrarSolicitud.Location = New System.Drawing.Point(605, 319)
        Me.btn_MostrarSolicitud.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_MostrarSolicitud.Name = "btn_MostrarSolicitud"
        Me.btn_MostrarSolicitud.Size = New System.Drawing.Size(109, 55)
        Me.btn_MostrarSolicitud.TabIndex = 31
        Me.btn_MostrarSolicitud.Text = "IMPRIMIR"
        Me.btn_MostrarSolicitud.UseVisualStyleBackColor = True
        Me.btn_MostrarSolicitud.Visible = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(605, 255)
        Me.btn_Limpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(109, 55)
        Me.btn_Limpiar.TabIndex = 32
        Me.btn_Limpiar.Text = "LIMPIAR"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 501)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 17)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Titulo"
        '
        'txt_Titulo
        '
        Me.txt_Titulo.Location = New System.Drawing.Point(95, 497)
        Me.txt_Titulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Titulo.MaxLength = 30
        Me.txt_Titulo.Name = "txt_Titulo"
        Me.txt_Titulo.Size = New System.Drawing.Size(477, 22)
        Me.txt_Titulo.TabIndex = 34
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.Location = New System.Drawing.Point(95, 465)
        Me.txt_Observaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Observaciones.MaxLength = 100
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.Size = New System.Drawing.Size(477, 22)
        Me.txt_Observaciones.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 460)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 34)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Observacion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    de Pago"
        '
        'gbx_Retenciones
        '
        Me.gbx_Retenciones.Controls.Add(Me.txt_TotalRetenciones)
        Me.gbx_Retenciones.Controls.Add(Me.Label21)
        Me.gbx_Retenciones.Controls.Add(Me.txt_TotalApagar)
        Me.gbx_Retenciones.Controls.Add(Me.Label19)
        Me.gbx_Retenciones.Controls.Add(Me.Label20)
        Me.gbx_Retenciones.Controls.Add(Me.txt_ImportePesos)
        Me.gbx_Retenciones.Controls.Add(Me.txt_Paridad)
        Me.gbx_Retenciones.Controls.Add(Me.Label18)
        Me.gbx_Retenciones.Controls.Add(Me.Label17)
        Me.gbx_Retenciones.Controls.Add(Me.Label16)
        Me.gbx_Retenciones.Controls.Add(Me.Label15)
        Me.gbx_Retenciones.Controls.Add(Me.txt_RetIVA)
        Me.gbx_Retenciones.Controls.Add(Me.txt_RetIBru)
        Me.gbx_Retenciones.Controls.Add(Me.txt_RetIBCiudad)
        Me.gbx_Retenciones.Controls.Add(Me.txt_RetGanancia)
        Me.gbx_Retenciones.Controls.Add(Me.Label14)
        Me.gbx_Retenciones.Location = New System.Drawing.Point(3, 238)
        Me.gbx_Retenciones.Margin = New System.Windows.Forms.Padding(4)
        Me.gbx_Retenciones.Name = "gbx_Retenciones"
        Me.gbx_Retenciones.Padding = New System.Windows.Forms.Padding(4)
        Me.gbx_Retenciones.Size = New System.Drawing.Size(600, 102)
        Me.gbx_Retenciones.TabIndex = 37
        Me.gbx_Retenciones.TabStop = False
        Me.gbx_Retenciones.Text = "Retenciones"
        '
        'txt_TotalRetenciones
        '
        Me.txt_TotalRetenciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_TotalRetenciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalRetenciones.Location = New System.Drawing.Point(484, 23)
        Me.txt_TotalRetenciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_TotalRetenciones.Name = "txt_TotalRetenciones"
        Me.txt_TotalRetenciones.ReadOnly = True
        Me.txt_TotalRetenciones.Size = New System.Drawing.Size(111, 23)
        Me.txt_TotalRetenciones.TabIndex = 20
        Me.txt_TotalRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(395, 58)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 34)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "     Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   a Pagar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_TotalApagar
        '
        Me.txt_TotalApagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_TotalApagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalApagar.Location = New System.Drawing.Point(484, 63)
        Me.txt_TotalApagar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_TotalApagar.Name = "txt_TotalApagar"
        Me.txt_TotalApagar.ReadOnly = True
        Me.txt_TotalApagar.Size = New System.Drawing.Size(111, 23)
        Me.txt_TotalApagar.TabIndex = 46
        Me.txt_TotalApagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(209, 74)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 17)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Importe Pesos"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 74)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 17)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Paridad"
        '
        'txt_ImportePesos
        '
        Me.txt_ImportePesos.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ImportePesos.Location = New System.Drawing.Point(308, 70)
        Me.txt_ImportePesos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ImportePesos.Name = "txt_ImportePesos"
        Me.txt_ImportePesos.ReadOnly = True
        Me.txt_ImportePesos.Size = New System.Drawing.Size(84, 22)
        Me.txt_ImportePesos.TabIndex = 43
        Me.txt_ImportePesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Paridad
        '
        Me.txt_Paridad.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Paridad.Location = New System.Drawing.Point(117, 70)
        Me.txt_Paridad.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Paridad.Name = "txt_Paridad"
        Me.txt_Paridad.ReadOnly = True
        Me.txt_Paridad.Size = New System.Drawing.Size(84, 22)
        Me.txt_Paridad.TabIndex = 42
        Me.txt_Paridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(225, 47)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 17)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Ret. I.V.A."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(219, 21)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 17)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Ret. I.Brutos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 47)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 17)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Ret. IB Ciudad"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 21)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 17)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Ret. Ganancia"
        '
        'txt_RetIVA
        '
        Me.txt_RetIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_RetIVA.Location = New System.Drawing.Point(308, 43)
        Me.txt_RetIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_RetIVA.Name = "txt_RetIVA"
        Me.txt_RetIVA.ReadOnly = True
        Me.txt_RetIVA.Size = New System.Drawing.Size(84, 22)
        Me.txt_RetIVA.TabIndex = 25
        Me.txt_RetIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_RetIBru
        '
        Me.txt_RetIBru.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_RetIBru.Location = New System.Drawing.Point(308, 17)
        Me.txt_RetIBru.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_RetIBru.Name = "txt_RetIBru"
        Me.txt_RetIBru.ReadOnly = True
        Me.txt_RetIBru.Size = New System.Drawing.Size(84, 22)
        Me.txt_RetIBru.TabIndex = 24
        Me.txt_RetIBru.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_RetIBCiudad
        '
        Me.txt_RetIBCiudad.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_RetIBCiudad.Location = New System.Drawing.Point(117, 43)
        Me.txt_RetIBCiudad.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_RetIBCiudad.Name = "txt_RetIBCiudad"
        Me.txt_RetIBCiudad.ReadOnly = True
        Me.txt_RetIBCiudad.Size = New System.Drawing.Size(84, 22)
        Me.txt_RetIBCiudad.TabIndex = 23
        Me.txt_RetIBCiudad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_RetGanancia
        '
        Me.txt_RetGanancia.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_RetGanancia.Location = New System.Drawing.Point(117, 17)
        Me.txt_RetGanancia.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_RetGanancia.Name = "txt_RetGanancia"
        Me.txt_RetGanancia.ReadOnly = True
        Me.txt_RetGanancia.Size = New System.Drawing.Size(84, 22)
        Me.txt_RetGanancia.TabIndex = 22
        Me.txt_RetGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(393, 23)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 34)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "     Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Retenciones"
        '
        'lbl_TipoDolar
        '
        Me.lbl_TipoDolar.AutoSize = True
        Me.lbl_TipoDolar.Location = New System.Drawing.Point(195, 214)
        Me.lbl_TipoDolar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TipoDolar.Name = "lbl_TipoDolar"
        Me.lbl_TipoDolar.Size = New System.Drawing.Size(55, 17)
        Me.lbl_TipoDolar.TabIndex = 39
        Me.lbl_TipoDolar.Text = "T.Dolar"
        Me.lbl_TipoDolar.Visible = False
        '
        'cbx_TipoDolar
        '
        Me.cbx_TipoDolar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TipoDolar.FormattingEnabled = True
        Me.cbx_TipoDolar.Items.AddRange(New Object() {"", "Divisa", "Nacion", "Informado"})
        Me.cbx_TipoDolar.Location = New System.Drawing.Point(257, 210)
        Me.cbx_TipoDolar.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_TipoDolar.Name = "cbx_TipoDolar"
        Me.cbx_TipoDolar.Size = New System.Drawing.Size(137, 24)
        Me.cbx_TipoDolar.TabIndex = 38
        Me.cbx_TipoDolar.Visible = False
        '
        'btn_Autorizar
        '
        Me.btn_Autorizar.Location = New System.Drawing.Point(605, 534)
        Me.btn_Autorizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Autorizar.Name = "btn_Autorizar"
        Me.btn_Autorizar.Size = New System.Drawing.Size(109, 55)
        Me.btn_Autorizar.TabIndex = 40
        Me.btn_Autorizar.Text = "AUTORIZAR"
        Me.btn_Autorizar.UseVisualStyleBackColor = True
        Me.btn_Autorizar.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(4, 652)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 34)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Banco y" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Fecha "
        '
        'txt_Concepto_Pago
        '
        Me.txt_Concepto_Pago.Location = New System.Drawing.Point(95, 649)
        Me.txt_Concepto_Pago.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Concepto_Pago.MaxLength = 200
        Me.txt_Concepto_Pago.Multiline = True
        Me.txt_Concepto_Pago.Name = "txt_Concepto_Pago"
        Me.txt_Concepto_Pago.Size = New System.Drawing.Size(477, 96)
        Me.txt_Concepto_Pago.TabIndex = 41
        '
        'btn_MailReclamo
        '
        Me.btn_MailReclamo.Location = New System.Drawing.Point(605, 382)
        Me.btn_MailReclamo.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_MailReclamo.Name = "btn_MailReclamo"
        Me.btn_MailReclamo.Size = New System.Drawing.Size(109, 55)
        Me.btn_MailReclamo.TabIndex = 43
        Me.btn_MailReclamo.Text = "ENVIAR MAIL"
        Me.btn_MailReclamo.UseVisualStyleBackColor = True
        Me.btn_MailReclamo.Visible = False
        '
        'txt_FechaEmitirOrdenPago
        '
        Me.txt_FechaEmitirOrdenPago.Location = New System.Drawing.Point(605, 501)
        Me.txt_FechaEmitirOrdenPago.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FechaEmitirOrdenPago.Mask = "00/00/0000"
        Me.txt_FechaEmitirOrdenPago.Name = "txt_FechaEmitirOrdenPago"
        Me.txt_FechaEmitirOrdenPago.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaEmitirOrdenPago.Size = New System.Drawing.Size(89, 22)
        Me.txt_FechaEmitirOrdenPago.TabIndex = 44
        Me.txt_FechaEmitirOrdenPago.Visible = False
        '
        'lbl_FechaEmitirOrdenPago
        '
        Me.lbl_FechaEmitirOrdenPago.AutoSize = True
        Me.lbl_FechaEmitirOrdenPago.Location = New System.Drawing.Point(597, 460)
        Me.lbl_FechaEmitirOrdenPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_FechaEmitirOrdenPago.Name = "lbl_FechaEmitirOrdenPago"
        Me.lbl_FechaEmitirOrdenPago.Size = New System.Drawing.Size(109, 34)
        Me.lbl_FechaEmitirOrdenPago.TabIndex = 45
        Me.lbl_FechaEmitirOrdenPago.Text = "   Fecha Emitir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Orden de Pago"
        Me.lbl_FechaEmitirOrdenPago.Visible = False
        '
        'Ingreso_Solicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 748)
        Me.Controls.Add(Me.lbl_FechaEmitirOrdenPago)
        Me.Controls.Add(Me.txt_FechaEmitirOrdenPago)
        Me.Controls.Add(Me.btn_MailReclamo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txt_Concepto_Pago)
        Me.Controls.Add(Me.btn_Autorizar)
        Me.Controls.Add(Me.lbl_TipoDolar)
        Me.Controls.Add(Me.cbx_TipoDolar)
        Me.Controls.Add(Me.gbx_Retenciones)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_Titulo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.btn_MostrarSolicitud)
        Me.Controls.Add(Me.btn_Adjuntar)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.txt_CuentaDescrip)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_Concepto)
        Me.Controls.Add(Me.gp_FormasDePago)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_FechaRequerida)
        Me.Controls.Add(Me.txt_Importe)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbx_Moneda)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Cuenta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_ProveedorDescrip)
        Me.Controls.Add(Me.txt_Proveedor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbx_Tipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_FechaSolicitud)
        Me.Controls.Add(Me.txt_Solicitante)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Ingreso_Solicitud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.gp_FormasDePago.ResumeLayout(False)
        Me.gp_FormasDePago.PerformLayout()
        Me.gbx_Retenciones.ResumeLayout(False)
        Me.gbx_Retenciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Solicitante As System.Windows.Forms.TextBox
    Friend WithEvents txt_FechaSolicitud As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbx_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_ProveedorDescrip As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbx_Moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents txt_FechaRequerida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chk_Efectivo As System.Windows.Forms.CheckBox
    Friend WithEvents gp_FormasDePago As System.Windows.Forms.GroupBox
    Friend WithEvents chk_ChequeTerceros As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Echeq As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Tranferencia As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Concepto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_CuentaDescrip As System.Windows.Forms.TextBox
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Adjuntar As System.Windows.Forms.Button
    Friend WithEvents btn_MostrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents chk_ChequePropio As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbx_Retenciones As System.Windows.Forms.GroupBox
    Friend WithEvents txt_TotalRetenciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_RetIVA As System.Windows.Forms.TextBox
    Friend WithEvents txt_RetIBru As System.Windows.Forms.TextBox
    Friend WithEvents txt_RetIBCiudad As System.Windows.Forms.TextBox
    Friend WithEvents txt_RetGanancia As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalApagar As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_ImportePesos As System.Windows.Forms.TextBox
    Friend WithEvents txt_Paridad As System.Windows.Forms.TextBox
    Friend WithEvents lbl_TipoDolar As System.Windows.Forms.Label
    Friend WithEvents cbx_TipoDolar As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Autorizar As System.Windows.Forms.Button
    Friend WithEvents chk_Tarjeta As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_Concepto_Pago As System.Windows.Forms.TextBox
    Friend WithEvents btn_MailReclamo As System.Windows.Forms.Button
    Friend WithEvents chk_DebitoAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents txt_FechaEmitirOrdenPago As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_FechaEmitirOrdenPago As System.Windows.Forms.Label
End Class
