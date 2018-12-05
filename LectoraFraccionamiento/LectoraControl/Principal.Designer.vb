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
        Me.txtDescProd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigoGral
        '
        Me.txtCodigoGral.Location = New System.Drawing.Point(106, 19)
        Me.txtCodigoGral.Name = "txtCodigoGral"
        Me.txtCodigoGral.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCodigoGral.Size = New System.Drawing.Size(122, 23)
        Me.txtCodigoGral.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 18)
        Me.Label2.Text = "Etiqueta General"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.pnlMsg.Location = New System.Drawing.Point(63, 229)
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
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 18)
        Me.Label3.Text = "Producto"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCodProd
        '
        Me.txtCodProd.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtCodProd.Enabled = False
        Me.txtCodProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodProd.Location = New System.Drawing.Point(70, 46)
        Me.txtCodProd.Name = "txtCodProd"
        Me.txtCodProd.ReadOnly = True
        Me.txtCodProd.Size = New System.Drawing.Size(157, 23)
        Me.txtCodProd.TabIndex = 0
        '
        'txtDescProd
        '
        Me.txtDescProd.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDescProd.Enabled = False
        Me.txtDescProd.Location = New System.Drawing.Point(10, 98)
        Me.txtDescProd.Name = "txtDescProd"
        Me.txtDescProd.ReadOnly = True
        Me.txtDescProd.Size = New System.Drawing.Size(216, 23)
        Me.txtDescProd.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(-2, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 18)
        Me.Label4.Text = "Partida"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPartida
        '
        Me.txtPartida.BackColor = System.Drawing.SystemColors.Control
        Me.txtPartida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPartida.Enabled = False
        Me.txtPartida.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartida.Location = New System.Drawing.Point(70, 71)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(156, 23)
        Me.txtPartida.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 59)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Limpiar Formulario"
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.Add("Pto de Trab. 1")
        Me.ComboBox1.Items.Add("Pto de Trab. 2")
        Me.ComboBox1.Items.Add("Pto de Trab. 3")
        Me.ComboBox1.Location = New System.Drawing.Point(107, 217)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 23)
        Me.ComboBox1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 18)
        Me.Label6.Text = "Puesto Trabajo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 269)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.txtDescProd)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.txtCodProd)
        Me.Controls.Add(Me.txtCodigoGral)
        Me.Controls.Add(Me.txtCandidad)
        Me.Controls.Add(Me.txtTotalPedido)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtSuma)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.Text = "Fraccionamiento"
        Me.pnlMsg.ResumeLayout(False)
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
    Friend WithEvents txtDescProd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
