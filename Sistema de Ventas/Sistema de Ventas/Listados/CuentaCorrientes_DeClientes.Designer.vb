<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorrientes_DeClientes
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
        Me.txt_Desde = New System.Windows.Forms.TextBox()
        Me.txt_Hasta = New System.Windows.Forms.TextBox()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.rabtn_Impresora = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx_TipoCliente = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Total = New System.Windows.Forms.RadioButton()
        Me.rabtn_Diferencia = New System.Windows.Forms.RadioButton()
        Me.rabtn_Documentos = New System.Windows.Forms.RadioButton()
        Me.rabtn_CtaCte = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Dolares = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pesos = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Tipo2_Completo = New System.Windows.Forms.RadioButton()
        Me.rabtn_Tipo1_Pendiente = New System.Windows.Forms.RadioButton()
        Me.cbx_TipoFecha = New System.Windows.Forms.ComboBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.chk_FechaVto = New System.Windows.Forms.CheckBox()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(574, 40)
        Me.panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(398, 10)
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
        Me.label1.Size = New System.Drawing.Size(217, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Cuenta Corriente de Clientes"
        '
        'txt_Desde
        '
        Me.txt_Desde.Location = New System.Drawing.Point(89, 22)
        Me.txt_Desde.MaxLength = 6
        Me.txt_Desde.Name = "txt_Desde"
        Me.txt_Desde.Size = New System.Drawing.Size(100, 20)
        Me.txt_Desde.TabIndex = 5
        '
        'txt_Hasta
        '
        Me.txt_Hasta.Location = New System.Drawing.Point(89, 48)
        Me.txt_Hasta.MaxLength = 6
        Me.txt_Hasta.Name = "txt_Hasta"
        Me.txt_Hasta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Hasta.TabIndex = 6
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(345, 22)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(65, 20)
        Me.txt_DesdeFecha.TabIndex = 7
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(345, 48)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(65, 20)
        Me.txt_HastaFecha.TabIndex = 8
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(12, 85)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 9
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'rabtn_Impresora
        '
        Me.rabtn_Impresora.AutoSize = True
        Me.rabtn_Impresora.Location = New System.Drawing.Point(128, 85)
        Me.rabtn_Impresora.Name = "rabtn_Impresora"
        Me.rabtn_Impresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtn_Impresora.TabIndex = 10
        Me.rabtn_Impresora.Text = "Impresora"
        Me.rabtn_Impresora.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_FechaVto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbx_TipoCliente)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cbx_TipoFecha)
        Me.GroupBox1.Controls.Add(Me.txt_Hasta)
        Me.GroupBox1.Controls.Add(Me.rabtn_Impresora)
        Me.GroupBox1.Controls.Add(Me.txt_Desde)
        Me.GroupBox1.Controls.Add(Me.rabtn_Pantalla)
        Me.GroupBox1.Controls.Add(Me.txt_DesdeFecha)
        Me.GroupBox1.Controls.Add(Me.txt_HastaFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 300)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Listado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(271, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Hasta Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(268, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Desde Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Hasta Codigo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Desde Codigo"
        '
        'cbx_TipoCliente
        '
        Me.cbx_TipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TipoCliente.FormattingEnabled = True
        Me.cbx_TipoCliente.Items.AddRange(New Object() {"Todos los Clientes", "Exterior"})
        Me.cbx_TipoCliente.Location = New System.Drawing.Point(12, 265)
        Me.cbx_TipoCliente.Name = "cbx_TipoCliente"
        Me.cbx_TipoCliente.Size = New System.Drawing.Size(183, 21)
        Me.cbx_TipoCliente.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rabtn_Total)
        Me.GroupBox4.Controls.Add(Me.rabtn_Diferencia)
        Me.GroupBox4.Controls.Add(Me.rabtn_Documentos)
        Me.GroupBox4.Controls.Add(Me.rabtn_CtaCte)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 196)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(458, 63)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Comprobante"
        '
        'rabtn_Total
        '
        Me.rabtn_Total.AutoSize = True
        Me.rabtn_Total.Location = New System.Drawing.Point(372, 29)
        Me.rabtn_Total.Name = "rabtn_Total"
        Me.rabtn_Total.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_Total.TabIndex = 20
        Me.rabtn_Total.Text = "Total"
        Me.rabtn_Total.UseVisualStyleBackColor = True
        '
        'rabtn_Diferencia
        '
        Me.rabtn_Diferencia.AutoSize = True
        Me.rabtn_Diferencia.Location = New System.Drawing.Point(210, 29)
        Me.rabtn_Diferencia.Name = "rabtn_Diferencia"
        Me.rabtn_Diferencia.Size = New System.Drawing.Size(149, 17)
        Me.rabtn_Diferencia.TabIndex = 19
        Me.rabtn_Diferencia.Text = "N/D y N/C por Dif Cambio"
        Me.rabtn_Diferencia.UseVisualStyleBackColor = True
        '
        'rabtn_Documentos
        '
        Me.rabtn_Documentos.AutoSize = True
        Me.rabtn_Documentos.Location = New System.Drawing.Point(98, 29)
        Me.rabtn_Documentos.Name = "rabtn_Documentos"
        Me.rabtn_Documentos.Size = New System.Drawing.Size(85, 17)
        Me.rabtn_Documentos.TabIndex = 18
        Me.rabtn_Documentos.Text = "Documentos"
        Me.rabtn_Documentos.UseVisualStyleBackColor = True
        '
        'rabtn_CtaCte
        '
        Me.rabtn_CtaCte.AutoSize = True
        Me.rabtn_CtaCte.Checked = True
        Me.rabtn_CtaCte.Location = New System.Drawing.Point(6, 29)
        Me.rabtn_CtaCte.Name = "rabtn_CtaCte"
        Me.rabtn_CtaCte.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_CtaCte.TabIndex = 17
        Me.rabtn_CtaCte.TabStop = True
        Me.rabtn_CtaCte.Text = "Cta Cte"
        Me.rabtn_CtaCte.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rabtn_Dolares)
        Me.GroupBox3.Controls.Add(Me.rabtn_Pesos)
        Me.GroupBox3.Location = New System.Drawing.Point(241, 127)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(223, 63)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Moneda"
        '
        'rabtn_Dolares
        '
        Me.rabtn_Dolares.AutoSize = True
        Me.rabtn_Dolares.Location = New System.Drawing.Point(135, 29)
        Me.rabtn_Dolares.Name = "rabtn_Dolares"
        Me.rabtn_Dolares.Size = New System.Drawing.Size(61, 17)
        Me.rabtn_Dolares.TabIndex = 18
        Me.rabtn_Dolares.Text = "Dolares"
        Me.rabtn_Dolares.UseVisualStyleBackColor = True
        '
        'rabtn_Pesos
        '
        Me.rabtn_Pesos.AutoSize = True
        Me.rabtn_Pesos.Checked = True
        Me.rabtn_Pesos.Location = New System.Drawing.Point(25, 29)
        Me.rabtn_Pesos.Name = "rabtn_Pesos"
        Me.rabtn_Pesos.Size = New System.Drawing.Size(54, 17)
        Me.rabtn_Pesos.TabIndex = 17
        Me.rabtn_Pesos.TabStop = True
        Me.rabtn_Pesos.Text = "Pesos"
        Me.rabtn_Pesos.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rabtn_Tipo2_Completo)
        Me.GroupBox2.Controls.Add(Me.rabtn_Tipo1_Pendiente)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 63)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Listado"
        '
        'rabtn_Tipo2_Completo
        '
        Me.rabtn_Tipo2_Completo.AutoSize = True
        Me.rabtn_Tipo2_Completo.Location = New System.Drawing.Point(122, 29)
        Me.rabtn_Tipo2_Completo.Name = "rabtn_Tipo2_Completo"
        Me.rabtn_Tipo2_Completo.Size = New System.Drawing.Size(69, 17)
        Me.rabtn_Tipo2_Completo.TabIndex = 16
        Me.rabtn_Tipo2_Completo.Text = "Completo"
        Me.rabtn_Tipo2_Completo.UseVisualStyleBackColor = True
        '
        'rabtn_Tipo1_Pendiente
        '
        Me.rabtn_Tipo1_Pendiente.AutoSize = True
        Me.rabtn_Tipo1_Pendiente.Checked = True
        Me.rabtn_Tipo1_Pendiente.Location = New System.Drawing.Point(6, 29)
        Me.rabtn_Tipo1_Pendiente.Name = "rabtn_Tipo1_Pendiente"
        Me.rabtn_Tipo1_Pendiente.Size = New System.Drawing.Size(73, 17)
        Me.rabtn_Tipo1_Pendiente.TabIndex = 15
        Me.rabtn_Tipo1_Pendiente.TabStop = True
        Me.rabtn_Tipo1_Pendiente.Text = "Pendiente"
        Me.rabtn_Tipo1_Pendiente.UseVisualStyleBackColor = True
        '
        'cbx_TipoFecha
        '
        Me.cbx_TipoFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TipoFecha.FormattingEnabled = True
        Me.cbx_TipoFecha.Items.AddRange(New Object() {"Toda la informacion ", "Entre fechas"})
        Me.cbx_TipoFecha.Location = New System.Drawing.Point(296, 84)
        Me.cbx_TipoFecha.Name = "cbx_TipoFecha"
        Me.cbx_TipoFecha.Size = New System.Drawing.Size(121, 21)
        Me.cbx_TipoFecha.TabIndex = 11
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(488, 68)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Aceptar.TabIndex = 12
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(488, 131)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(75, 46)
        Me.btn_Consulta.TabIndex = 13
        Me.btn_Consulta.Text = "CONSULTA"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(488, 190)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Cerrar.TabIndex = 14
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'chk_FechaVto
        '
        Me.chk_FechaVto.AutoSize = True
        Me.chk_FechaVto.Checked = True
        Me.chk_FechaVto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_FechaVto.Location = New System.Drawing.Point(296, 108)
        Me.chk_FechaVto.Name = "chk_FechaVto"
        Me.chk_FechaVto.Size = New System.Drawing.Size(131, 17)
        Me.chk_FechaVto.TabIndex = 20
        Me.chk_FechaVto.Text = "Fecha de vencimiento"
        Me.chk_FechaVto.UseVisualStyleBackColor = True
        '
        'CuentaCorrientes_DeClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 358)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "CuentaCorrientes_DeClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Impresora As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbx_TipoCliente As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Total As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Diferencia As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Documentos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_CtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Dolares As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pesos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Tipo2_Completo As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Tipo1_Pendiente As System.Windows.Forms.RadioButton
    Friend WithEvents cbx_TipoFecha As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_FechaVto As System.Windows.Forms.CheckBox
End Class
