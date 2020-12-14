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
        Me.chk_ChequeTerceros = New System.Windows.Forms.CheckBox()
        Me.chk_Echeq = New System.Windows.Forms.CheckBox()
        Me.chk_Tranferencia = New System.Windows.Forms.CheckBox()
        Me.txt_Concepto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_CuentaDescrip = New System.Windows.Forms.TextBox()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_MostrarSolicitud = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Titulo = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.gp_FormasDePago.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(539, 40)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(363, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(164, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "INGRESO SOLICITUD"
        '
        'txt_Solicitante
        '
        Me.txt_Solicitante.BackColor = System.Drawing.Color.Cyan
        Me.txt_Solicitante.Location = New System.Drawing.Point(59, 52)
        Me.txt_Solicitante.MaxLength = 20
        Me.txt_Solicitante.Name = "txt_Solicitante"
        Me.txt_Solicitante.ReadOnly = True
        Me.txt_Solicitante.Size = New System.Drawing.Size(135, 20)
        Me.txt_Solicitante.TabIndex = 6
        '
        'txt_FechaSolicitud
        '
        Me.txt_FechaSolicitud.BackColor = System.Drawing.Color.Aqua
        Me.txt_FechaSolicitud.Location = New System.Drawing.Point(291, 50)
        Me.txt_FechaSolicitud.Mask = "00/00/0000"
        Me.txt_FechaSolicitud.Name = "txt_FechaSolicitud"
        Me.txt_FechaSolicitud.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaSolicitud.ReadOnly = True
        Me.txt_FechaSolicitud.Size = New System.Drawing.Size(68, 20)
        Me.txt_FechaSolicitud.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Solicitante"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha Solicitud"
        '
        'cbx_Tipo
        '
        Me.cbx_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Tipo.FormattingEnabled = True
        Me.cbx_Tipo.Items.AddRange(New Object() {"", "Pago a Proveedores", "Varios"})
        Me.cbx_Tipo.Location = New System.Drawing.Point(59, 78)
        Me.cbx_Tipo.Name = "cbx_Tipo"
        Me.cbx_Tipo.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Tipo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Tipo"
        '
        'txt_Proveedor
        '
        Me.txt_Proveedor.Location = New System.Drawing.Point(59, 106)
        Me.txt_Proveedor.MaxLength = 11
        Me.txt_Proveedor.Name = "txt_Proveedor"
        Me.txt_Proveedor.Size = New System.Drawing.Size(77, 20)
        Me.txt_Proveedor.TabIndex = 12
        Me.txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ProveedorDescrip
        '
        Me.txt_ProveedorDescrip.BackColor = System.Drawing.Color.Aqua
        Me.txt_ProveedorDescrip.Location = New System.Drawing.Point(142, 106)
        Me.txt_ProveedorDescrip.Name = "txt_ProveedorDescrip"
        Me.txt_ProveedorDescrip.ReadOnly = True
        Me.txt_ProveedorDescrip.Size = New System.Drawing.Size(287, 20)
        Me.txt_ProveedorDescrip.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Proveedor"
        '
        'txt_Cuenta
        '
        Me.txt_Cuenta.Location = New System.Drawing.Point(59, 139)
        Me.txt_Cuenta.MaxLength = 10
        Me.txt_Cuenta.Name = "txt_Cuenta"
        Me.txt_Cuenta.Size = New System.Drawing.Size(77, 20)
        Me.txt_Cuenta.TabIndex = 15
        Me.txt_Cuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 26)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cuenta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contable"
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"", "Pesos", "Dolares"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(59, 170)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Moneda.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Moneda"
        '
        'txt_Importe
        '
        Me.txt_Importe.Location = New System.Drawing.Point(244, 171)
        Me.txt_Importe.Name = "txt_Importe"
        Me.txt_Importe.Size = New System.Drawing.Size(100, 20)
        Me.txt_Importe.TabIndex = 19
        Me.txt_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_FechaRequerida
        '
        Me.txt_FechaRequerida.Location = New System.Drawing.Point(97, 204)
        Me.txt_FechaRequerida.Mask = "00/00/0000"
        Me.txt_FechaRequerida.Name = "txt_FechaRequerida"
        Me.txt_FechaRequerida.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaRequerida.Size = New System.Drawing.Size(68, 20)
        Me.txt_FechaRequerida.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Importe"
        '
        'chk_Efectivo
        '
        Me.chk_Efectivo.AutoSize = True
        Me.chk_Efectivo.Location = New System.Drawing.Point(17, 28)
        Me.chk_Efectivo.Name = "chk_Efectivo"
        Me.chk_Efectivo.Size = New System.Drawing.Size(65, 17)
        Me.chk_Efectivo.TabIndex = 22
        Me.chk_Efectivo.Text = "Efectivo"
        Me.chk_Efectivo.UseVisualStyleBackColor = True
        '
        'gp_FormasDePago
        '
        Me.gp_FormasDePago.Controls.Add(Me.chk_ChequeTerceros)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Echeq)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Tranferencia)
        Me.gp_FormasDePago.Controls.Add(Me.chk_Efectivo)
        Me.gp_FormasDePago.Location = New System.Drawing.Point(10, 232)
        Me.gp_FormasDePago.Name = "gp_FormasDePago"
        Me.gp_FormasDePago.Size = New System.Drawing.Size(304, 76)
        Me.gp_FormasDePago.TabIndex = 23
        Me.gp_FormasDePago.TabStop = False
        Me.gp_FormasDePago.Text = "Formas de Pago"
        '
        'chk_ChequeTerceros
        '
        Me.chk_ChequeTerceros.AutoSize = True
        Me.chk_ChequeTerceros.Location = New System.Drawing.Point(155, 51)
        Me.chk_ChequeTerceros.Name = "chk_ChequeTerceros"
        Me.chk_ChequeTerceros.Size = New System.Drawing.Size(108, 17)
        Me.chk_ChequeTerceros.TabIndex = 25
        Me.chk_ChequeTerceros.Text = "Cheque Terceros"
        Me.chk_ChequeTerceros.UseVisualStyleBackColor = True
        '
        'chk_Echeq
        '
        Me.chk_Echeq.AutoSize = True
        Me.chk_Echeq.Location = New System.Drawing.Point(155, 28)
        Me.chk_Echeq.Name = "chk_Echeq"
        Me.chk_Echeq.Size = New System.Drawing.Size(60, 17)
        Me.chk_Echeq.TabIndex = 24
        Me.chk_Echeq.Text = "E-cheq"
        Me.chk_Echeq.UseVisualStyleBackColor = True
        '
        'chk_Tranferencia
        '
        Me.chk_Tranferencia.AutoSize = True
        Me.chk_Tranferencia.Location = New System.Drawing.Point(17, 51)
        Me.chk_Tranferencia.Name = "chk_Tranferencia"
        Me.chk_Tranferencia.Size = New System.Drawing.Size(91, 17)
        Me.chk_Tranferencia.TabIndex = 23
        Me.chk_Tranferencia.Text = "Transferencia"
        Me.chk_Tranferencia.UseVisualStyleBackColor = True
        '
        'txt_Concepto
        '
        Me.txt_Concepto.Location = New System.Drawing.Point(70, 338)
        Me.txt_Concepto.MaxLength = 100
        Me.txt_Concepto.Multiline = True
        Me.txt_Concepto.Name = "txt_Concepto"
        Me.txt_Concepto.Size = New System.Drawing.Size(359, 38)
        Me.txt_Concepto.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Fecha Requerida"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 341)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Detalle"
        '
        'txt_CuentaDescrip
        '
        Me.txt_CuentaDescrip.BackColor = System.Drawing.Color.Aqua
        Me.txt_CuentaDescrip.Location = New System.Drawing.Point(142, 139)
        Me.txt_CuentaDescrip.Name = "txt_CuentaDescrip"
        Me.txt_CuentaDescrip.ReadOnly = True
        Me.txt_CuentaDescrip.Size = New System.Drawing.Size(287, 20)
        Me.txt_CuentaDescrip.TabIndex = 27
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(457, 50)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 45)
        Me.btn_Grabar.TabIndex = 28
        Me.btn_Grabar.Text = "GRABAR"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(457, 101)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 45)
        Me.btn_Cancelar.TabIndex = 29
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(457, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 45)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "ADJUNTAR ARCHIVOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_MostrarSolicitud
        '
        Me.btn_MostrarSolicitud.Location = New System.Drawing.Point(457, 255)
        Me.btn_MostrarSolicitud.Name = "btn_MostrarSolicitud"
        Me.btn_MostrarSolicitud.Size = New System.Drawing.Size(75, 45)
        Me.btn_MostrarSolicitud.TabIndex = 31
        Me.btn_MostrarSolicitud.Text = "IMPRIMIR"
        Me.btn_MostrarSolicitud.UseVisualStyleBackColor = True
        Me.btn_MostrarSolicitud.Visible = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(457, 203)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(75, 45)
        Me.btn_Limpiar.TabIndex = 32
        Me.btn_Limpiar.Text = "LIMPIAR"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 311)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Titulo"
        '
        'txt_Titulo
        '
        Me.txt_Titulo.Location = New System.Drawing.Point(70, 311)
        Me.txt_Titulo.MaxLength = 30
        Me.txt_Titulo.Name = "txt_Titulo"
        Me.txt_Titulo.Size = New System.Drawing.Size(359, 20)
        Me.txt_Titulo.TabIndex = 34
        '
        'Ingreso_Solicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 384)
        Me.Controls.Add(Me.txt_Titulo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.btn_MostrarSolicitud)
        Me.Controls.Add(Me.Button1)
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
        Me.Name = "Ingreso_Solicitud"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.gp_FormasDePago.ResumeLayout(False)
        Me.gp_FormasDePago.PerformLayout()
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_MostrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Titulo As System.Windows.Forms.TextBox
End Class
