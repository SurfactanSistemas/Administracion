<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingresar_Presupuesto
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
        Me.txt_Titulo = New System.Windows.Forms.TextBox()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.txt_Descrip_Prov = New System.Windows.Forms.TextBox()
        Me.txt_Monto = New System.Windows.Forms.TextBox()
        Me.txt_Codigo_Prov = New System.Windows.Forms.TextBox()
        Me.txt_NroPresupuesto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Fecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_FormaPago = New System.Windows.Forms.TextBox()
        Me.btn_Adjuntar = New System.Windows.Forms.Button()
        Me.btn_CerrarPresupuesto = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.cbx_Moneda = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_novedades = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Pagado = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txt_Saldo = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(724, 49)
        Me.panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(489, 12)
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
        Me.label1.Location = New System.Drawing.Point(9, 16)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(278, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "INGRESO DE PRESUPUESTOS"
        '
        'txt_Titulo
        '
        Me.txt_Titulo.Location = New System.Drawing.Point(123, 130)
        Me.txt_Titulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Titulo.MaxLength = 50
        Me.txt_Titulo.Name = "txt_Titulo"
        Me.txt_Titulo.Size = New System.Drawing.Size(487, 22)
        Me.txt_Titulo.TabIndex = 9
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(123, 162)
        Me.txt_Descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Descripcion.MaxLength = 500
        Me.txt_Descripcion.Multiline = True
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(487, 109)
        Me.txt_Descripcion.TabIndex = 10
        '
        'txt_Descrip_Prov
        '
        Me.txt_Descrip_Prov.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Descrip_Prov.Location = New System.Drawing.Point(247, 91)
        Me.txt_Descrip_Prov.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Descrip_Prov.Name = "txt_Descrip_Prov"
        Me.txt_Descrip_Prov.ReadOnly = True
        Me.txt_Descrip_Prov.Size = New System.Drawing.Size(363, 22)
        Me.txt_Descrip_Prov.TabIndex = 11
        '
        'txt_Monto
        '
        Me.txt_Monto.Location = New System.Drawing.Point(123, 319)
        Me.txt_Monto.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Monto.MaxLength = 20
        Me.txt_Monto.Name = "txt_Monto"
        Me.txt_Monto.Size = New System.Drawing.Size(132, 22)
        Me.txt_Monto.TabIndex = 12
        Me.txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Codigo_Prov
        '
        Me.txt_Codigo_Prov.Location = New System.Drawing.Point(123, 91)
        Me.txt_Codigo_Prov.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Codigo_Prov.MaxLength = 11
        Me.txt_Codigo_Prov.Name = "txt_Codigo_Prov"
        Me.txt_Codigo_Prov.Size = New System.Drawing.Size(115, 22)
        Me.txt_Codigo_Prov.TabIndex = 13
        Me.txt_Codigo_Prov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_NroPresupuesto
        '
        Me.txt_NroPresupuesto.Location = New System.Drawing.Point(123, 57)
        Me.txt_NroPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_NroPresupuesto.Name = "txt_NroPresupuesto"
        Me.txt_NroPresupuesto.ReadOnly = True
        Me.txt_NroPresupuesto.Size = New System.Drawing.Size(97, 22)
        Me.txt_NroPresupuesto.TabIndex = 14
        Me.txt_NroPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 134)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Titulo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 166)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Descripcion"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(520, 59)
        Me.txt_Fecha.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(89, 22)
        Me.txt_Fecha.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 95)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(468, 63)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 286)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Forma de Pago"
        '
        'txt_FormaPago
        '
        Me.txt_FormaPago.Location = New System.Drawing.Point(123, 282)
        Me.txt_FormaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_FormaPago.MaxLength = 100
        Me.txt_FormaPago.Name = "txt_FormaPago"
        Me.txt_FormaPago.Size = New System.Drawing.Size(487, 22)
        Me.txt_FormaPago.TabIndex = 21
        '
        'btn_Adjuntar
        '
        Me.btn_Adjuntar.Location = New System.Drawing.Point(619, 75)
        Me.btn_Adjuntar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Adjuntar.Name = "btn_Adjuntar"
        Me.btn_Adjuntar.Size = New System.Drawing.Size(100, 54)
        Me.btn_Adjuntar.TabIndex = 22
        Me.btn_Adjuntar.Text = "   Adjuntar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documentos"
        Me.btn_Adjuntar.UseVisualStyleBackColor = True
        '
        'btn_CerrarPresupuesto
        '
        Me.btn_CerrarPresupuesto.Location = New System.Drawing.Point(619, 137)
        Me.btn_CerrarPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_CerrarPresupuesto.Name = "btn_CerrarPresupuesto"
        Me.btn_CerrarPresupuesto.Size = New System.Drawing.Size(100, 54)
        Me.btn_CerrarPresupuesto.TabIndex = 23
        Me.btn_CerrarPresupuesto.Text = "Cerrar Presupuesto"
        Me.btn_CerrarPresupuesto.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 322)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Monto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 60)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Nro. Presupuesto"
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(619, 198)
        Me.btn_Grabar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(100, 54)
        Me.btn_Grabar.TabIndex = 26
        Me.btn_Grabar.Text = "Grabar"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"Pesos ($)", "Dolares (U$S)"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(363, 318)
        Me.cbx_Moneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(160, 24)
        Me.cbx_Moneda.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(287, 321)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Moneda"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(619, 260)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(100, 54)
        Me.btn_Cerrar.TabIndex = 29
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(0, 363)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 17)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Novedades"
        '
        'txt_novedades
        '
        Me.txt_novedades.Location = New System.Drawing.Point(122, 359)
        Me.txt_novedades.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_novedades.MaxLength = 500
        Me.txt_novedades.Multiline = True
        Me.txt_novedades.Name = "txt_novedades"
        Me.txt_novedades.Size = New System.Drawing.Size(487, 109)
        Me.txt_novedades.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1, 491)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 17)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Pagado"
        '
        'txt_Pagado
        '
        Me.txt_Pagado.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Pagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Pagado.Location = New System.Drawing.Point(123, 488)
        Me.txt_Pagado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Pagado.MaxLength = 20
        Me.txt_Pagado.Name = "txt_Pagado"
        Me.txt_Pagado.ReadOnly = True
        Me.txt_Pagado.Size = New System.Drawing.Size(132, 22)
        Me.txt_Pagado.TabIndex = 32
        Me.txt_Pagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(360, 491)
        Me.label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(44, 17)
        Me.label13.TabIndex = 35
        Me.label13.Text = "Saldo"
        '
        'txt_Saldo
        '
        Me.txt_Saldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Saldo.Location = New System.Drawing.Point(429, 488)
        Me.txt_Saldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Saldo.MaxLength = 20
        Me.txt_Saldo.Name = "txt_Saldo"
        Me.txt_Saldo.ReadOnly = True
        Me.txt_Saldo.Size = New System.Drawing.Size(132, 22)
        Me.txt_Saldo.TabIndex = 34
        Me.txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Ingresar_Presupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 532)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txt_Saldo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_Pagado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_novedades)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbx_Moneda)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_CerrarPresupuesto)
        Me.Controls.Add(Me.btn_Adjuntar)
        Me.Controls.Add(Me.txt_FormaPago)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Fecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_NroPresupuesto)
        Me.Controls.Add(Me.txt_Codigo_Prov)
        Me.Controls.Add(Me.txt_Monto)
        Me.Controls.Add(Me.txt_Descrip_Prov)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.txt_Titulo)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Ingresar_Presupuesto"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_Descrip_Prov As System.Windows.Forms.TextBox
    Friend WithEvents txt_Monto As System.Windows.Forms.TextBox
    Friend WithEvents txt_Codigo_Prov As System.Windows.Forms.TextBox
    Friend WithEvents txt_NroPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Fecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_FormaPago As System.Windows.Forms.TextBox
    Friend WithEvents btn_Adjuntar As System.Windows.Forms.Button
    Friend WithEvents btn_CerrarPresupuesto As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents cbx_Moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_novedades As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Pagado As System.Windows.Forms.TextBox
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txt_Saldo As System.Windows.Forms.TextBox
End Class
