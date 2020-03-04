<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.txtCodigoGral = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTotalPedido = New System.Windows.Forms.Label
        Me.txtSuma = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCandidad = New System.Windows.Forms.TextBox
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblCuentaRegresiva = New System.Windows.Forms.Label
        Me.picError = New System.Windows.Forms.PictureBox
        Me.picExito = New System.Windows.Forms.PictureBox
        Me.lblMensajeestado = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCodProd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlCantidades = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtCantPorEtiq = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCantEtiq = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.pnlPedido = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtCodPedido = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.pnlConfirmarEtiq = New System.Windows.Forms.Panel
        Me.btnRevalidarContenedor = New System.Windows.Forms.Button
        Me.btnVolver = New System.Windows.Forms.Button
        Me.btnConfirmarPedido = New System.Windows.Forms.Button
        Me.txtContenedor = New System.Windows.Forms.TextBox
        Me.txtEtiqAConfirmar = New System.Windows.Forms.TextBox
        Me.lblCantEtiqValidadas = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.pnlValidarContenedor = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnCancelarVerificarContenedor = New System.Windows.Forms.Button
        Me.btnVerificarContenedor = New System.Windows.Forms.Button
        Me.txtUlt = New System.Windows.Forms.TextBox
        Me.txtUltPartida = New System.Windows.Forms.TextBox
        Me.txtVerificarContenedor = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.pnlMenu = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.pnlConsEtiqFinal = New System.Windows.Forms.Panel
        Me.txtCodEtiqFinal = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCodEtiqPreenvasado = New System.Windows.Forms.TextBox
        Me.btnSalirConsEtiqFinal = New System.Windows.Forms.Button
        Me.pnlMsg.SuspendLayout()
        Me.pnlCantidades.SuspendLayout()
        Me.pnlPedido.SuspendLayout()
        Me.pnlConfirmarEtiq.SuspendLayout()
        Me.pnlValidarContenedor.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlConsEtiqFinal.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigoGral
        '
        Me.txtCodigoGral.Location = New System.Drawing.Point(106, 44)
        Me.txtCodigoGral.Name = "txtCodigoGral"
        Me.txtCodigoGral.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCodigoGral.Size = New System.Drawing.Size(122, 23)
        Me.txtCodigoGral.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(7, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 18)
        Me.Label2.Text = "Etiqueta General"
        '
        'txtTotalPedido
        '
        Me.txtTotalPedido.Location = New System.Drawing.Point(113, 243)
        Me.txtTotalPedido.Name = "txtTotalPedido"
        Me.txtTotalPedido.Size = New System.Drawing.Size(78, 19)
        Me.txtTotalPedido.Text = "450 Kg(s)"
        Me.txtTotalPedido.Visible = False
        '
        'txtSuma
        '
        Me.txtSuma.Location = New System.Drawing.Point(161, 252)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(35, 10)
        Me.txtSuma.Text = "100"
        Me.txtSuma.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtSuma.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(17, 239)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(28, 23)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(191, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 19)
        Me.Label5.Text = "/"
        Me.Label5.Visible = False
        '
        'txtCandidad
        '
        Me.txtCandidad.Location = New System.Drawing.Point(208, 243)
        Me.txtCandidad.Name = "txtCandidad"
        Me.txtCandidad.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCandidad.Size = New System.Drawing.Size(27, 23)
        Me.txtCandidad.TabIndex = 0
        Me.txtCandidad.Visible = False
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.White
        Me.pnlMsg.Controls.Add(Me.lblCuentaRegresiva)
        Me.pnlMsg.Controls.Add(Me.picError)
        Me.pnlMsg.Controls.Add(Me.picExito)
        Me.pnlMsg.Controls.Add(Me.lblMensajeestado)
        Me.pnlMsg.Location = New System.Drawing.Point(62, 222)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(44, 40)
        '
        'lblCuentaRegresiva
        '
        Me.lblCuentaRegresiva.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblCuentaRegresiva.Location = New System.Drawing.Point(18, 207)
        Me.lblCuentaRegresiva.Name = "lblCuentaRegresiva"
        Me.lblCuentaRegresiva.Size = New System.Drawing.Size(169, 17)
        Me.lblCuentaRegresiva.Text = "Mensaje se cierra en 1 seg(s)"
        Me.lblCuentaRegresiva.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.Transparent
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(74, 10)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(70, 66)
        Me.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picError.Visible = False
        '
        'picExito
        '
        Me.picExito.BackColor = System.Drawing.Color.Transparent
        Me.picExito.Image = CType(resources.GetObject("picExito.Image"), System.Drawing.Image)
        Me.picExito.Location = New System.Drawing.Point(73, 10)
        Me.picExito.Name = "picExito"
        Me.picExito.Size = New System.Drawing.Size(70, 66)
        Me.picExito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picExito.Visible = False
        '
        'lblMensajeestado
        '
        Me.lblMensajeestado.BackColor = System.Drawing.Color.White
        Me.lblMensajeestado.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblMensajeestado.Location = New System.Drawing.Point(14, 81)
        Me.lblMensajeestado.Multiline = True
        Me.lblMensajeestado.Name = "lblMensajeestado"
        Me.lblMensajeestado.ReadOnly = True
        Me.lblMensajeestado.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.lblMensajeestado.Size = New System.Drawing.Size(174, 122)
        Me.lblMensajeestado.TabIndex = 3
        Me.lblMensajeestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.Text = "Producto"
        '
        'txtCodProd
        '
        Me.txtCodProd.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtCodProd.Enabled = False
        Me.txtCodProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodProd.Location = New System.Drawing.Point(70, 71)
        Me.txtCodProd.Name = "txtCodProd"
        Me.txtCodProd.ReadOnly = True
        Me.txtCodProd.Size = New System.Drawing.Size(157, 23)
        Me.txtCodProd.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 18)
        Me.Label4.Text = "Partida"
        '
        'txtPartida
        '
        Me.txtPartida.BackColor = System.Drawing.SystemColors.Control
        Me.txtPartida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPartida.Enabled = False
        Me.txtPartida.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartida.Location = New System.Drawing.Point(70, 96)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(156, 23)
        Me.txtPartida.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(39, 141)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 46)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "EMITIR ETIQUETA"
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.Add("Pto de Trab. 1")
        Me.ComboBox1.Items.Add("Pto de Trab. 2")
        Me.ComboBox1.Items.Add("Pto de Trab. 3")
        Me.ComboBox1.Location = New System.Drawing.Point(106, 135)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 23)
        Me.ComboBox1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 18)
        Me.Label6.Text = "Puesto Trabajo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlCantidades
        '
        Me.pnlCantidades.Controls.Add(Me.Button2)
        Me.pnlCantidades.Controls.Add(Me.txtCantPorEtiq)
        Me.pnlCantidades.Controls.Add(Me.Label7)
        Me.pnlCantidades.Controls.Add(Me.txtCantEtiq)
        Me.pnlCantidades.Controls.Add(Me.Label1)
        Me.pnlCantidades.Controls.Add(Me.Button1)
        Me.pnlCantidades.Location = New System.Drawing.Point(4, 37)
        Me.pnlCantidades.Name = "pnlCantidades"
        Me.pnlCantidades.Size = New System.Drawing.Size(231, 172)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(40, 206)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 32)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "CANCELAR"
        '
        'txtCantPorEtiq
        '
        Me.txtCantPorEtiq.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.txtCantPorEtiq.Location = New System.Drawing.Point(87, 100)
        Me.txtCantPorEtiq.Name = "txtCantPorEtiq"
        Me.txtCantPorEtiq.Size = New System.Drawing.Size(56, 35)
        Me.txtCantPorEtiq.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(42, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 20)
        Me.Label7.Text = "Cantidad Kgs por Etiq:"
        '
        'txtCantEtiq
        '
        Me.txtCantEtiq.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.txtCantEtiq.Location = New System.Drawing.Point(87, 39)
        Me.txtCantEtiq.Name = "txtCantEtiq"
        Me.txtCantEtiq.Size = New System.Drawing.Size(56, 35)
        Me.txtCantEtiq.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(70, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.Text = "Cantidad Etiq"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(38, 175)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(158, 35)
        Me.btnSalir.TabIndex = 22
        Me.btnSalir.Text = "SALIR"
        '
        'pnlPedido
        '
        Me.pnlPedido.Controls.Add(Me.Button3)
        Me.pnlPedido.Controls.Add(Me.txtCodPedido)
        Me.pnlPedido.Controls.Add(Me.Label8)
        Me.pnlPedido.Location = New System.Drawing.Point(3, 8)
        Me.pnlPedido.Name = "pnlPedido"
        Me.pnlPedido.Size = New System.Drawing.Size(231, 254)
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(48, 137)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 55)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "CERRAR"
        '
        'txtCodPedido
        '
        Me.txtCodPedido.Location = New System.Drawing.Point(21, 89)
        Me.txtCodPedido.Name = "txtCodPedido"
        Me.txtCodPedido.Size = New System.Drawing.Size(188, 23)
        Me.txtCodPedido.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(56, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 20)
        Me.Label8.Text = "INGRESE PEDIDO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlConfirmarEtiq
        '
        Me.pnlConfirmarEtiq.Controls.Add(Me.btnRevalidarContenedor)
        Me.pnlConfirmarEtiq.Controls.Add(Me.btnVolver)
        Me.pnlConfirmarEtiq.Controls.Add(Me.btnConfirmarPedido)
        Me.pnlConfirmarEtiq.Controls.Add(Me.txtContenedor)
        Me.pnlConfirmarEtiq.Controls.Add(Me.txtEtiqAConfirmar)
        Me.pnlConfirmarEtiq.Controls.Add(Me.lblCantEtiqValidadas)
        Me.pnlConfirmarEtiq.Controls.Add(Me.Label10)
        Me.pnlConfirmarEtiq.Controls.Add(Me.Label9)
        Me.pnlConfirmarEtiq.Location = New System.Drawing.Point(3, 66)
        Me.pnlConfirmarEtiq.Name = "pnlConfirmarEtiq"
        Me.pnlConfirmarEtiq.Size = New System.Drawing.Size(231, 192)
        Me.pnlConfirmarEtiq.Visible = False
        '
        'btnRevalidarContenedor
        '
        Me.btnRevalidarContenedor.Location = New System.Drawing.Point(25, 216)
        Me.btnRevalidarContenedor.Name = "btnRevalidarContenedor"
        Me.btnRevalidarContenedor.Size = New System.Drawing.Size(181, 31)
        Me.btnRevalidarContenedor.TabIndex = 32
        Me.btnRevalidarContenedor.Text = "VALIDAR CONTENEDOR"
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(40, 141)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(151, 43)
        Me.btnVolver.TabIndex = 5
        Me.btnVolver.Text = "VOLVER"
        '
        'btnConfirmarPedido
        '
        Me.btnConfirmarPedido.Location = New System.Drawing.Point(40, 96)
        Me.btnConfirmarPedido.Name = "btnConfirmarPedido"
        Me.btnConfirmarPedido.Size = New System.Drawing.Size(151, 43)
        Me.btnConfirmarPedido.TabIndex = 5
        Me.btnConfirmarPedido.Text = "CONFIRMAR PEDIDO"
        '
        'txtContenedor
        '
        Me.txtContenedor.Location = New System.Drawing.Point(37, 26)
        Me.txtContenedor.Name = "txtContenedor"
        Me.txtContenedor.Size = New System.Drawing.Size(157, 23)
        Me.txtContenedor.TabIndex = 4
        '
        'txtEtiqAConfirmar
        '
        Me.txtEtiqAConfirmar.Location = New System.Drawing.Point(36, 70)
        Me.txtEtiqAConfirmar.Name = "txtEtiqAConfirmar"
        Me.txtEtiqAConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEtiqAConfirmar.Size = New System.Drawing.Size(159, 23)
        Me.txtEtiqAConfirmar.TabIndex = 3
        '
        'lblCantEtiqValidadas
        '
        Me.lblCantEtiqValidadas.Location = New System.Drawing.Point(38, 191)
        Me.lblCantEtiqValidadas.Name = "lblCantEtiqValidadas"
        Me.lblCantEtiqValidadas.Size = New System.Drawing.Size(154, 20)
        Me.lblCantEtiqValidadas.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(65, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.Text = "Contenedor"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(61, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 20)
        Me.Label9.Text = "Etiqueta"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlValidarContenedor
        '
        Me.pnlValidarContenedor.Controls.Add(Me.Label14)
        Me.pnlValidarContenedor.Controls.Add(Me.Label13)
        Me.pnlValidarContenedor.Controls.Add(Me.Label12)
        Me.pnlValidarContenedor.Controls.Add(Me.btnCancelarVerificarContenedor)
        Me.pnlValidarContenedor.Controls.Add(Me.btnVerificarContenedor)
        Me.pnlValidarContenedor.Controls.Add(Me.txtUlt)
        Me.pnlValidarContenedor.Controls.Add(Me.txtUltPartida)
        Me.pnlValidarContenedor.Controls.Add(Me.txtVerificarContenedor)
        Me.pnlValidarContenedor.Controls.Add(Me.Label11)
        Me.pnlValidarContenedor.Location = New System.Drawing.Point(3, 121)
        Me.pnlValidarContenedor.Name = "pnlValidarContenedor"
        Me.pnlValidarContenedor.Size = New System.Drawing.Size(232, 105)
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(17, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 17)
        Me.Label14.Text = "Partida:"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 17)
        Me.Label13.Text = "Código:"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(61, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 17)
        Me.Label12.Text = "Producto Anterior"
        '
        'btnCancelarVerificarContenedor
        '
        Me.btnCancelarVerificarContenedor.Location = New System.Drawing.Point(26, 183)
        Me.btnCancelarVerificarContenedor.Name = "btnCancelarVerificarContenedor"
        Me.btnCancelarVerificarContenedor.Size = New System.Drawing.Size(181, 31)
        Me.btnCancelarVerificarContenedor.TabIndex = 32
        Me.btnCancelarVerificarContenedor.Text = "CANCELAR"
        '
        'btnVerificarContenedor
        '
        Me.btnVerificarContenedor.Location = New System.Drawing.Point(26, 146)
        Me.btnVerificarContenedor.Name = "btnVerificarContenedor"
        Me.btnVerificarContenedor.Size = New System.Drawing.Size(181, 31)
        Me.btnVerificarContenedor.TabIndex = 32
        Me.btnVerificarContenedor.Text = "VALIDAR"
        '
        'txtUlt
        '
        Me.txtUlt.Location = New System.Drawing.Point(76, 54)
        Me.txtUlt.Name = "txtUlt"
        Me.txtUlt.ReadOnly = True
        Me.txtUlt.Size = New System.Drawing.Size(138, 23)
        Me.txtUlt.TabIndex = 1
        '
        'txtUltPartida
        '
        Me.txtUltPartida.Location = New System.Drawing.Point(76, 28)
        Me.txtUltPartida.Name = "txtUltPartida"
        Me.txtUltPartida.ReadOnly = True
        Me.txtUltPartida.Size = New System.Drawing.Size(138, 23)
        Me.txtUltPartida.TabIndex = 1
        '
        'txtVerificarContenedor
        '
        Me.txtVerificarContenedor.Location = New System.Drawing.Point(38, 111)
        Me.txtVerificarContenedor.Name = "txtVerificarContenedor"
        Me.txtVerificarContenedor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtVerificarContenedor.Size = New System.Drawing.Size(157, 23)
        Me.txtVerificarContenedor.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(79, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 20)
        Me.Label11.Text = "Contenedor"
        '
        'txtPedido
        '
        Me.txtPedido.BackColor = System.Drawing.SystemColors.Control
        Me.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPedido.Enabled = False
        Me.txtPedido.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPedido.Location = New System.Drawing.Point(68, 13)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(157, 23)
        Me.txtPedido.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 18)
        Me.Label15.Text = "Pedido"
        '
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 600000
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.Button5)
        Me.pnlMenu.Controls.Add(Me.Button4)
        Me.pnlMenu.Location = New System.Drawing.Point(3, 8)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(231, 253)
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Button5.Location = New System.Drawing.Point(7, 11)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(217, 114)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "FRACCIONAR PEDIDO"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Button4.Location = New System.Drawing.Point(9, 129)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(215, 114)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "VALIDAR ETIQ FINALES"
        '
        'pnlConsEtiqFinal
        '
        Me.pnlConsEtiqFinal.Controls.Add(Me.txtCodEtiqFinal)
        Me.pnlConsEtiqFinal.Controls.Add(Me.Label17)
        Me.pnlConsEtiqFinal.Controls.Add(Me.Label16)
        Me.pnlConsEtiqFinal.Controls.Add(Me.txtCodEtiqPreenvasado)
        Me.pnlConsEtiqFinal.Controls.Add(Me.btnSalirConsEtiqFinal)
        Me.pnlConsEtiqFinal.Location = New System.Drawing.Point(3, 8)
        Me.pnlConsEtiqFinal.Name = "pnlConsEtiqFinal"
        Me.pnlConsEtiqFinal.Size = New System.Drawing.Size(231, 254)
        '
        'txtCodEtiqFinal
        '
        Me.txtCodEtiqFinal.Location = New System.Drawing.Point(22, 130)
        Me.txtCodEtiqFinal.Name = "txtCodEtiqFinal"
        Me.txtCodEtiqFinal.Size = New System.Drawing.Size(193, 23)
        Me.txtCodEtiqFinal.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(68, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 20)
        Me.Label17.Text = "ETIQUETA FINAL"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(35, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(167, 20)
        Me.Label16.Text = "ETIQUETA PREENVASADO"
        '
        'txtCodEtiqPreenvasado
        '
        Me.txtCodEtiqPreenvasado.Location = New System.Drawing.Point(20, 68)
        Me.txtCodEtiqPreenvasado.Name = "txtCodEtiqPreenvasado"
        Me.txtCodEtiqPreenvasado.Size = New System.Drawing.Size(193, 23)
        Me.txtCodEtiqPreenvasado.TabIndex = 1
        '
        'btnSalirConsEtiqFinal
        '
        Me.btnSalirConsEtiqFinal.Location = New System.Drawing.Point(42, 183)
        Me.btnSalirConsEtiqFinal.Name = "btnSalirConsEtiqFinal"
        Me.btnSalirConsEtiqFinal.Size = New System.Drawing.Size(145, 48)
        Me.btnSalirConsEtiqFinal.TabIndex = 0
        Me.btnSalirConsEtiqFinal.Text = "SALIR"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 269)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlConsEtiqFinal)
        Me.Controls.Add(Me.pnlPedido)
        Me.Controls.Add(Me.pnlConfirmarEtiq)
        Me.Controls.Add(Me.pnlValidarContenedor)
        Me.Controls.Add(Me.pnlCantidades)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.txtCodProd)
        Me.Controls.Add(Me.txtCodigoGral)
        Me.Controls.Add(Me.txtCandidad)
        Me.Controls.Add(Me.txtTotalPedido)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtSuma)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.Text = "    LECTORA"
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlCantidades.ResumeLayout(False)
        Me.pnlPedido.ResumeLayout(False)
        Me.pnlConfirmarEtiq.ResumeLayout(False)
        Me.pnlValidarContenedor.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlConsEtiqFinal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCodigoGral As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPedido As System.Windows.Forms.Label
    Friend WithEvents txtSuma As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCandidad As System.Windows.Forms.TextBox
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblMensajeestado As System.Windows.Forms.TextBox
    Friend WithEvents picExito As System.Windows.Forms.PictureBox
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents lblCuentaRegresiva As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodProd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlCantidades As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantPorEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlPedido As System.Windows.Forms.Panel
    Friend WithEvents txtCodPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pnlConfirmarEtiq As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnConfirmarPedido As System.Windows.Forms.Button
    Friend WithEvents txtContenedor As System.Windows.Forms.TextBox
    Friend WithEvents txtEtiqAConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents pnlValidarContenedor As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVerificarContenedor As System.Windows.Forms.TextBox
    Friend WithEvents btnVerificarContenedor As System.Windows.Forms.Button
    Friend WithEvents btnCancelarVerificarContenedor As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUltPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtUlt As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblCantEtiqValidadas As System.Windows.Forms.Label
    Friend WithEvents btnRevalidarContenedor As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents pnlConsEtiqFinal As System.Windows.Forms.Panel
    Friend WithEvents btnSalirConsEtiqFinal As System.Windows.Forms.Button
    Friend WithEvents txtCodEtiqFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCodEtiqPreenvasado As System.Windows.Forms.TextBox

End Class
