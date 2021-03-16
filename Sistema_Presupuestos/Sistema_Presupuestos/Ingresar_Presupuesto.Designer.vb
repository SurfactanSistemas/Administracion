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
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(543, 40)
        Me.panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(367, 10)
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
        Me.label1.Location = New System.Drawing.Point(7, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(234, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "INGRESO DE PRESUPUESTOS"
        '
        'txt_Titulo
        '
        Me.txt_Titulo.Location = New System.Drawing.Point(92, 106)
        Me.txt_Titulo.MaxLength = 50
        Me.txt_Titulo.Name = "txt_Titulo"
        Me.txt_Titulo.Size = New System.Drawing.Size(366, 20)
        Me.txt_Titulo.TabIndex = 9
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(92, 132)
        Me.txt_Descripcion.MaxLength = 500
        Me.txt_Descripcion.Multiline = True
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(366, 89)
        Me.txt_Descripcion.TabIndex = 10
        '
        'txt_Descrip_Prov
        '
        Me.txt_Descrip_Prov.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Descrip_Prov.Location = New System.Drawing.Point(185, 74)
        Me.txt_Descrip_Prov.Name = "txt_Descrip_Prov"
        Me.txt_Descrip_Prov.ReadOnly = True
        Me.txt_Descrip_Prov.Size = New System.Drawing.Size(273, 20)
        Me.txt_Descrip_Prov.TabIndex = 11
        '
        'txt_Monto
        '
        Me.txt_Monto.Location = New System.Drawing.Point(92, 259)
        Me.txt_Monto.MaxLength = 20
        Me.txt_Monto.Name = "txt_Monto"
        Me.txt_Monto.Size = New System.Drawing.Size(100, 20)
        Me.txt_Monto.TabIndex = 12
        '
        'txt_Codigo_Prov
        '
        Me.txt_Codigo_Prov.Location = New System.Drawing.Point(92, 74)
        Me.txt_Codigo_Prov.Name = "txt_Codigo_Prov"
        Me.txt_Codigo_Prov.Size = New System.Drawing.Size(87, 20)
        Me.txt_Codigo_Prov.TabIndex = 13
        '
        'txt_NroPresupuesto
        '
        Me.txt_NroPresupuesto.Location = New System.Drawing.Point(92, 46)
        Me.txt_NroPresupuesto.Name = "txt_NroPresupuesto"
        Me.txt_NroPresupuesto.ReadOnly = True
        Me.txt_NroPresupuesto.Size = New System.Drawing.Size(74, 20)
        Me.txt_NroPresupuesto.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Titulo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Descripcion"
        '
        'txt_Fecha
        '
        Me.txt_Fecha.Location = New System.Drawing.Point(390, 48)
        Me.txt_Fecha.Mask = "00/00/0000"
        Me.txt_Fecha.Name = "txt_Fecha"
        Me.txt_Fecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Fecha.Size = New System.Drawing.Size(68, 20)
        Me.txt_Fecha.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(351, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Forma de Pago"
        '
        'txt_FormaPago
        '
        Me.txt_FormaPago.Location = New System.Drawing.Point(92, 229)
        Me.txt_FormaPago.MaxLength = 100
        Me.txt_FormaPago.Name = "txt_FormaPago"
        Me.txt_FormaPago.Size = New System.Drawing.Size(366, 20)
        Me.txt_FormaPago.TabIndex = 21
        '
        'btn_Adjuntar
        '
        Me.btn_Adjuntar.Location = New System.Drawing.Point(464, 61)
        Me.btn_Adjuntar.Name = "btn_Adjuntar"
        Me.btn_Adjuntar.Size = New System.Drawing.Size(75, 44)
        Me.btn_Adjuntar.TabIndex = 22
        Me.btn_Adjuntar.Text = "   Adjuntar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documentos"
        Me.btn_Adjuntar.UseVisualStyleBackColor = True
        '
        'btn_CerrarPresupuesto
        '
        Me.btn_CerrarPresupuesto.Location = New System.Drawing.Point(464, 111)
        Me.btn_CerrarPresupuesto.Name = "btn_CerrarPresupuesto"
        Me.btn_CerrarPresupuesto.Size = New System.Drawing.Size(75, 44)
        Me.btn_CerrarPresupuesto.TabIndex = 23
        Me.btn_CerrarPresupuesto.Text = "Cerrar Presupuesto"
        Me.btn_CerrarPresupuesto.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Monto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Nro. Presupuesto"
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(464, 161)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 44)
        Me.btn_Grabar.TabIndex = 26
        Me.btn_Grabar.Text = "Grabar"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'cbx_Moneda
        '
        Me.cbx_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Moneda.FormattingEnabled = True
        Me.cbx_Moneda.Items.AddRange(New Object() {"Pesos ($)", "Dolares (U$S)"})
        Me.cbx_Moneda.Location = New System.Drawing.Point(272, 258)
        Me.cbx_Moneda.Name = "cbx_Moneda"
        Me.cbx_Moneda.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Moneda.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(215, 261)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Moneda"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(464, 211)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 44)
        Me.btn_Cerrar.TabIndex = 29
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Ingresar_Presupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 288)
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
End Class
