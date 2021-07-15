<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmisionNotaRetiro
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnEmitir = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ckSiCheque = New System.Windows.Forms.CheckBox()
        Me.txtMontoCheque = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtBancoCheque = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaCheque = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtCoordinado = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtNotasAdicionales = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtQueRetirar = New System.Windows.Forms.TextBox()
        Me.txtFechaRetiro = New System.Windows.Forms.MaskedTextBox()
        Me.btnSugerirResp = New System.Windows.Forms.Button()
        Me.btnSugerirDestinatarios = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHorarios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreRespRetiro = New System.Windows.Forms.TextBox()
        Me.txtMailRetira = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMailDestinatario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDestinatario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(707, 53)
        Me.Panel2.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(542, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(12, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "EMISIÓN DE NOTA DE RETIRO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnEmitir)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtFechaRetiro)
        Me.GroupBox1.Controls.Add(Me.btnSugerirResp)
        Me.GroupBox1.Controls.Add(Me.btnSugerirDestinatarios)
        Me.GroupBox1.Controls.Add(Me.btnConsulta)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtHorarios)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNombreRespRetiro)
        Me.GroupBox1.Controls.Add(Me.txtMailRetira)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMailDestinatario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDestinatario)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 526)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(347, 470)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(177, 49)
        Me.btnCerrar.TabIndex = 24
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnEmitir
        '
        Me.btnEmitir.Location = New System.Drawing.Point(164, 470)
        Me.btnEmitir.Name = "btnEmitir"
        Me.btnEmitir.Size = New System.Drawing.Size(177, 49)
        Me.btnEmitir.TabIndex = 24
        Me.btnEmitir.Text = "EMITIR"
        Me.btnEmitir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ckSiCheque)
        Me.GroupBox4.Controls.Add(Me.txtMontoCheque)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtNumero)
        Me.GroupBox4.Controls.Add(Me.txtBancoCheque)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtFechaCheque)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 327)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(667, 50)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "¿SE ADJUNTA ALGÚN CHEQUE?"
        '
        'ckSiCheque
        '
        Me.ckSiCheque.AutoSize = True
        Me.ckSiCheque.Location = New System.Drawing.Point(184, 0)
        Me.ckSiCheque.Name = "ckSiCheque"
        Me.ckSiCheque.Size = New System.Drawing.Size(36, 17)
        Me.ckSiCheque.TabIndex = 2
        Me.ckSiCheque.Text = "SI"
        Me.ckSiCheque.UseVisualStyleBackColor = True
        '
        'txtMontoCheque
        '
        Me.txtMontoCheque.Location = New System.Drawing.Point(83, 19)
        Me.txtMontoCheque.Name = "txtMontoCheque"
        Me.txtMontoCheque.Size = New System.Drawing.Size(70, 20)
        Me.txtMontoCheque.TabIndex = 1
        Me.txtMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "MONTO ($)"
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(320, 19)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(90, 20)
        Me.txtNumero.TabIndex = 1
        '
        'txtBancoCheque
        '
        Me.txtBancoCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBancoCheque.Location = New System.Drawing.Point(466, 19)
        Me.txtBancoCheque.Name = "txtBancoCheque"
        Me.txtBancoCheque.Size = New System.Drawing.Size(189, 20)
        Me.txtBancoCheque.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(281, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "NUM:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(416, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "BANCO"
        '
        'txtFechaCheque
        '
        Me.txtFechaCheque.Location = New System.Drawing.Point(205, 19)
        Me.txtFechaCheque.Mask = "00/00/0000"
        Me.txtFechaCheque.Name = "txtFechaCheque"
        Me.txtFechaCheque.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaCheque.Size = New System.Drawing.Size(70, 20)
        Me.txtFechaCheque.TabIndex = 3
        Me.txtFechaCheque.Text = "00000000"
        Me.txtFechaCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(157, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "FECHA"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtCoordinado)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 274)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(667, 50)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "¿CON QUIÉN SE COORDINÓ?"
        '
        'txtCoordinado
        '
        Me.txtCoordinado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCoordinado.Location = New System.Drawing.Point(10, 19)
        Me.txtCoordinado.Name = "txtCoordinado"
        Me.txtCoordinado.Size = New System.Drawing.Size(646, 20)
        Me.txtCoordinado.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtNotasAdicionales)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 379)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(667, 87)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "NOTAS ADICIONALES"
        '
        'txtNotasAdicionales
        '
        Me.txtNotasAdicionales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotasAdicionales.Location = New System.Drawing.Point(10, 19)
        Me.txtNotasAdicionales.Multiline = True
        Me.txtNotasAdicionales.Name = "txtNotasAdicionales"
        Me.txtNotasAdicionales.Size = New System.Drawing.Size(646, 57)
        Me.txtNotasAdicionales.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtQueRetirar)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(667, 114)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "¿QUÉ SE DEBE RETIRAR?"
        '
        'txtQueRetirar
        '
        Me.txtQueRetirar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQueRetirar.Location = New System.Drawing.Point(10, 19)
        Me.txtQueRetirar.Multiline = True
        Me.txtQueRetirar.Name = "txtQueRetirar"
        Me.txtQueRetirar.Size = New System.Drawing.Size(646, 88)
        Me.txtQueRetirar.TabIndex = 1
        '
        'txtFechaRetiro
        '
        Me.txtFechaRetiro.Location = New System.Drawing.Point(99, 92)
        Me.txtFechaRetiro.Mask = "00/00/0000"
        Me.txtFechaRetiro.Name = "txtFechaRetiro"
        Me.txtFechaRetiro.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFechaRetiro.Size = New System.Drawing.Size(70, 20)
        Me.txtFechaRetiro.TabIndex = 3
        Me.txtFechaRetiro.Text = "00000000"
        Me.txtFechaRetiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSugerirResp
        '
        Me.btnSugerirResp.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnSugerirResp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSugerirResp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSugerirResp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSugerirResp.FlatAppearance.BorderSize = 0
        Me.btnSugerirResp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSugerirResp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSugerirResp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSugerirResp.Location = New System.Drawing.Point(637, 65)
        Me.btnSugerirResp.Name = "btnSugerirResp"
        Me.btnSugerirResp.Size = New System.Drawing.Size(29, 21)
        Me.btnSugerirResp.TabIndex = 2
        Me.btnSugerirResp.UseVisualStyleBackColor = True
        '
        'btnSugerirDestinatarios
        '
        Me.btnSugerirDestinatarios.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnSugerirDestinatarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSugerirDestinatarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSugerirDestinatarios.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSugerirDestinatarios.FlatAppearance.BorderSize = 0
        Me.btnSugerirDestinatarios.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSugerirDestinatarios.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSugerirDestinatarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSugerirDestinatarios.Location = New System.Drawing.Point(637, 41)
        Me.btnSugerirDestinatarios.Name = "btnSugerirDestinatarios"
        Me.btnSugerirDestinatarios.Size = New System.Drawing.Size(29, 21)
        Me.btnSugerirDestinatarios.TabIndex = 2
        Me.btnSugerirDestinatarios.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Location = New System.Drawing.Point(637, 17)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(29, 21)
        Me.btnConsulta.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Buscar datos desde Proveedor")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Location = New System.Drawing.Point(136, 118)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(530, 20)
        Me.txtDireccion.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "DIRECCION DE RETIRO"
        '
        'txtHorarios
        '
        Me.txtHorarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHorarios.Location = New System.Drawing.Point(254, 92)
        Me.txtHorarios.Name = "txtHorarios"
        Me.txtHorarios.Size = New System.Drawing.Size(412, 20)
        Me.txtHorarios.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "HORARIOS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "FECHA RETIRO"
        '
        'txtNombreRespRetiro
        '
        Me.txtNombreRespRetiro.Location = New System.Drawing.Point(139, 67)
        Me.txtNombreRespRetiro.Name = "txtNombreRespRetiro"
        Me.txtNombreRespRetiro.Size = New System.Drawing.Size(175, 20)
        Me.txtNombreRespRetiro.TabIndex = 1
        '
        'txtMailRetira
        '
        Me.txtMailRetira.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtMailRetira.Location = New System.Drawing.Point(390, 67)
        Me.txtMailRetira.Name = "txtMailRetira"
        Me.txtMailRetira.Size = New System.Drawing.Size(241, 20)
        Me.txtMailRetira.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "NOMBRE RESP. RETIRO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "MAIL RESP"
        '
        'txtMailDestinatario
        '
        Me.txtMailDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtMailDestinatario.Location = New System.Drawing.Point(76, 42)
        Me.txtMailDestinatario.Name = "txtMailDestinatario"
        Me.txtMailDestinatario.Size = New System.Drawing.Size(555, 20)
        Me.txtMailDestinatario.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "MAIL AVISO"
        '
        'txtDestinatario
        '
        Me.txtDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestinatario.Location = New System.Drawing.Point(76, 18)
        Me.txtDestinatario.Name = "txtDestinatario"
        Me.txtDestinatario.Size = New System.Drawing.Size(555, 20)
        Me.txtDestinatario.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SEÑORES"
        '
        'EmisionNotaRetiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Name = "EmisionNotaRetiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMailDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMailRetira As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaRetiro As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHorarios As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCoordinado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBancoCheque As System.Windows.Forms.TextBox
    Friend WithEvents ckSiCheque As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQueRetirar As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaCheque As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMontoCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNotasAdicionales As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnEmitir As System.Windows.Forms.Button
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNombreRespRetiro As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnSugerirDestinatarios As System.Windows.Forms.Button
    Friend WithEvents btnSugerirResp As System.Windows.Forms.Button
End Class
