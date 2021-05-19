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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.pnlMenu = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.txtTotalPedido = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.txtCodigoGral = New System.Windows.Forms.TextBox
        Me.pnlValidarEtiqFinal = New System.Windows.Forms.Panel
        Me.btnSalirConsEtiqFinal = New System.Windows.Forms.Button
        Me.txtCodEtiqPreenvasado = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCodEtiqFinal = New System.Windows.Forms.TextBox
        Me.pnlMsg.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlValidarEtiqFinal.SuspendLayout()
        Me.SuspendLayout()
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
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 600000
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.Button5)
        Me.pnlMenu.Controls.Add(Me.Button4)
        Me.pnlMenu.Location = New System.Drawing.Point(161, 201)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(73, 60)
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Button5.Location = New System.Drawing.Point(205, 106)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(19, 19)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "FRACCIONAR PEDIDO"
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Button4.Location = New System.Drawing.Point(7, 58)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(218, 114)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "VALIDAR ETIQ FINALES"
        '
        'txtTotalPedido
        '
        Me.txtTotalPedido.Location = New System.Drawing.Point(113, 243)
        Me.txtTotalPedido.Name = "txtTotalPedido"
        Me.txtTotalPedido.Size = New System.Drawing.Size(78, 19)
        Me.txtTotalPedido.Text = "450 Kg(s)"
        Me.txtTotalPedido.Visible = False
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
        'txtCodigoGral
        '
        Me.txtCodigoGral.Location = New System.Drawing.Point(106, 44)
        Me.txtCodigoGral.Name = "txtCodigoGral"
        Me.txtCodigoGral.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCodigoGral.Size = New System.Drawing.Size(122, 23)
        Me.txtCodigoGral.TabIndex = 0
        '
        'pnlValidarEtiqFinal
        '
        Me.pnlValidarEtiqFinal.Controls.Add(Me.txtCodEtiqFinal)
        Me.pnlValidarEtiqFinal.Controls.Add(Me.Label17)
        Me.pnlValidarEtiqFinal.Controls.Add(Me.Label16)
        Me.pnlValidarEtiqFinal.Controls.Add(Me.txtCodEtiqPreenvasado)
        Me.pnlValidarEtiqFinal.Controls.Add(Me.btnSalirConsEtiqFinal)
        Me.pnlValidarEtiqFinal.Location = New System.Drawing.Point(4, 3)
        Me.pnlValidarEtiqFinal.Name = "pnlValidarEtiqFinal"
        Me.pnlValidarEtiqFinal.Size = New System.Drawing.Size(231, 254)
        '
        'btnSalirConsEtiqFinal
        '
        Me.btnSalirConsEtiqFinal.Location = New System.Drawing.Point(43, 178)
        Me.btnSalirConsEtiqFinal.Name = "btnSalirConsEtiqFinal"
        Me.btnSalirConsEtiqFinal.Size = New System.Drawing.Size(145, 48)
        Me.btnSalirConsEtiqFinal.TabIndex = 0
        Me.btnSalirConsEtiqFinal.Text = "SALIR"
        '
        'txtCodEtiqPreenvasado
        '
        Me.txtCodEtiqPreenvasado.Location = New System.Drawing.Point(19, 68)
        Me.txtCodEtiqPreenvasado.Name = "txtCodEtiqPreenvasado"
        Me.txtCodEtiqPreenvasado.Size = New System.Drawing.Size(192, 23)
        Me.txtCodEtiqPreenvasado.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(192, 20)
        Me.Label16.Text = "ETIQUETA CUARENTENA"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(193, 20)
        Me.Label17.Text = "ETIQUETA DEFINITIVA"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCodEtiqFinal
        '
        Me.txtCodEtiqFinal.Location = New System.Drawing.Point(19, 130)
        Me.txtCodEtiqFinal.Name = "txtCodEtiqFinal"
        Me.txtCodEtiqFinal.Size = New System.Drawing.Size(193, 23)
        Me.txtCodEtiqFinal.TabIndex = 5
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 269)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlValidarEtiqFinal)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.txtCodigoGral)
        Me.Controls.Add(Me.txtCandidad)
        Me.Controls.Add(Me.txtTotalPedido)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtSuma)
        Me.Controls.Add(Me.Label5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.Text = "    LECTORA"
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlValidarEtiqFinal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtTotalPedido As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigoGral As System.Windows.Forms.TextBox
    Friend WithEvents pnlValidarEtiqFinal As System.Windows.Forms.Panel
    Friend WithEvents txtCodEtiqFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCodEtiqPreenvasado As System.Windows.Forms.TextBox
    Friend WithEvents btnSalirConsEtiqFinal As System.Windows.Forms.Button

End Class
