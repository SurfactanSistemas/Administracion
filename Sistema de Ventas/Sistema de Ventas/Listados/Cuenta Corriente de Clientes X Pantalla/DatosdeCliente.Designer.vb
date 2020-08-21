<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosdeCliente
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
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.txt_Razon = New System.Windows.Forms.TextBox()
        Me.txt_Direccion = New System.Windows.Forms.TextBox()
        Me.txt_Localidad = New System.Windows.Forms.TextBox()
        Me.cbx_Provincia = New System.Windows.Forms.ComboBox()
        Me.txt_CPostal = New System.Windows.Forms.TextBox()
        Me.txt_Cuit = New System.Windows.Forms.TextBox()
        Me.txt_Telefono = New System.Windows.Forms.TextBox()
        Me.txt_Vendedor = New System.Windows.Forms.TextBox()
        Me.txt_DesVendedor = New System.Windows.Forms.TextBox()
        Me.txt_Contacto = New System.Windows.Forms.TextBox()
        Me.txt_Email = New System.Windows.Forms.TextBox()
        Me.txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.txt_Fax = New System.Windows.Forms.TextBox()
        Me.txt_Rubro = New System.Windows.Forms.TextBox()
        Me.txt_DesRubro = New System.Windows.Forms.TextBox()
        Me.txt_Horarios = New System.Windows.Forms.TextBox()
        Me.txt_Pago1 = New System.Windows.Forms.TextBox()
        Me.txt_DesPago1 = New System.Windows.Forms.TextBox()
        Me.txt_Pago2 = New System.Windows.Forms.TextBox()
        Me.txt_DesPago2 = New System.Windows.Forms.TextBox()
        Me.txt_Limite = New System.Windows.Forms.TextBox()
        Me.txt_Minimo = New System.Windows.Forms.TextBox()
        Me.txt_DirEntrega = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Incripto = New System.Windows.Forms.RadioButton()
        Me.rabtn_NoIncripto = New System.Windows.Forms.RadioButton()
        Me.rabtn_Monotributo = New System.Windows.Forms.RadioButton()
        Me.rabtn_ConsFinal = New System.Windows.Forms.RadioButton()
        Me.rabtn_Exento = New System.Windows.Forms.RadioButton()
        Me.rabtn_NoCatalogado = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(561, 50)
        Me.panel1.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(406, 30)
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
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(128, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Datos de Cliente"
        '
        'txt_Cliente
        '
        Me.txt_Cliente.Location = New System.Drawing.Point(112, 57)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.Size = New System.Drawing.Size(100, 20)
        Me.txt_Cliente.TabIndex = 40
        '
        'txt_Razon
        '
        Me.txt_Razon.Location = New System.Drawing.Point(112, 79)
        Me.txt_Razon.Name = "txt_Razon"
        Me.txt_Razon.Size = New System.Drawing.Size(100, 20)
        Me.txt_Razon.TabIndex = 41
        '
        'txt_Direccion
        '
        Me.txt_Direccion.Location = New System.Drawing.Point(112, 102)
        Me.txt_Direccion.Name = "txt_Direccion"
        Me.txt_Direccion.Size = New System.Drawing.Size(100, 20)
        Me.txt_Direccion.TabIndex = 42
        '
        'txt_Localidad
        '
        Me.txt_Localidad.Location = New System.Drawing.Point(112, 125)
        Me.txt_Localidad.Name = "txt_Localidad"
        Me.txt_Localidad.Size = New System.Drawing.Size(100, 20)
        Me.txt_Localidad.TabIndex = 43
        '
        'cbx_Provincia
        '
        Me.cbx_Provincia.FormattingEnabled = True
        Me.cbx_Provincia.Items.AddRange(New Object() {"Capital Federal", "Buenos Aires", "Catamarca", "Cordoba", "Corrientes", "Chaco", "Chubut", "Entre Rios", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquen", "Rio Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tucuman", "Tierra del Fuego", "Exterior"})
        Me.cbx_Provincia.Location = New System.Drawing.Point(112, 148)
        Me.cbx_Provincia.Name = "cbx_Provincia"
        Me.cbx_Provincia.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Provincia.TabIndex = 44
        '
        'txt_CPostal
        '
        Me.txt_CPostal.Location = New System.Drawing.Point(112, 171)
        Me.txt_CPostal.Name = "txt_CPostal"
        Me.txt_CPostal.Size = New System.Drawing.Size(100, 20)
        Me.txt_CPostal.TabIndex = 45
        Me.txt_CPostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Cuit
        '
        Me.txt_Cuit.Location = New System.Drawing.Point(266, 171)
        Me.txt_Cuit.Name = "txt_Cuit"
        Me.txt_Cuit.Size = New System.Drawing.Size(100, 20)
        Me.txt_Cuit.TabIndex = 46
        Me.txt_Cuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Telefono
        '
        Me.txt_Telefono.Location = New System.Drawing.Point(112, 194)
        Me.txt_Telefono.Name = "txt_Telefono"
        Me.txt_Telefono.Size = New System.Drawing.Size(100, 20)
        Me.txt_Telefono.TabIndex = 47
        Me.txt_Telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Vendedor
        '
        Me.txt_Vendedor.Location = New System.Drawing.Point(288, 194)
        Me.txt_Vendedor.Name = "txt_Vendedor"
        Me.txt_Vendedor.Size = New System.Drawing.Size(39, 20)
        Me.txt_Vendedor.TabIndex = 48
        Me.txt_Vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DesVendedor
        '
        Me.txt_DesVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesVendedor.Location = New System.Drawing.Point(330, 194)
        Me.txt_DesVendedor.Name = "txt_DesVendedor"
        Me.txt_DesVendedor.ReadOnly = True
        Me.txt_DesVendedor.Size = New System.Drawing.Size(216, 20)
        Me.txt_DesVendedor.TabIndex = 49
        '
        'txt_Contacto
        '
        Me.txt_Contacto.Location = New System.Drawing.Point(112, 217)
        Me.txt_Contacto.Name = "txt_Contacto"
        Me.txt_Contacto.Size = New System.Drawing.Size(100, 20)
        Me.txt_Contacto.TabIndex = 50
        '
        'txt_Email
        '
        Me.txt_Email.Location = New System.Drawing.Point(288, 217)
        Me.txt_Email.Name = "txt_Email"
        Me.txt_Email.Size = New System.Drawing.Size(258, 20)
        Me.txt_Email.TabIndex = 51
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.Location = New System.Drawing.Point(112, 240)
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.Size = New System.Drawing.Size(178, 20)
        Me.txt_Observaciones.TabIndex = 52
        '
        'txt_Fax
        '
        Me.txt_Fax.Location = New System.Drawing.Point(349, 240)
        Me.txt_Fax.Name = "txt_Fax"
        Me.txt_Fax.Size = New System.Drawing.Size(100, 20)
        Me.txt_Fax.TabIndex = 53
        Me.txt_Fax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Rubro
        '
        Me.txt_Rubro.Location = New System.Drawing.Point(112, 263)
        Me.txt_Rubro.Name = "txt_Rubro"
        Me.txt_Rubro.Size = New System.Drawing.Size(44, 20)
        Me.txt_Rubro.TabIndex = 54
        Me.txt_Rubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DesRubro
        '
        Me.txt_DesRubro.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesRubro.Location = New System.Drawing.Point(159, 263)
        Me.txt_DesRubro.Name = "txt_DesRubro"
        Me.txt_DesRubro.ReadOnly = True
        Me.txt_DesRubro.Size = New System.Drawing.Size(168, 20)
        Me.txt_DesRubro.TabIndex = 55
        '
        'txt_Horarios
        '
        Me.txt_Horarios.Location = New System.Drawing.Point(112, 286)
        Me.txt_Horarios.Name = "txt_Horarios"
        Me.txt_Horarios.Size = New System.Drawing.Size(100, 20)
        Me.txt_Horarios.TabIndex = 56
        '
        'txt_Pago1
        '
        Me.txt_Pago1.Location = New System.Drawing.Point(112, 309)
        Me.txt_Pago1.Name = "txt_Pago1"
        Me.txt_Pago1.Size = New System.Drawing.Size(44, 20)
        Me.txt_Pago1.TabIndex = 57
        Me.txt_Pago1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DesPago1
        '
        Me.txt_DesPago1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesPago1.Location = New System.Drawing.Point(159, 309)
        Me.txt_DesPago1.Name = "txt_DesPago1"
        Me.txt_DesPago1.ReadOnly = True
        Me.txt_DesPago1.Size = New System.Drawing.Size(207, 20)
        Me.txt_DesPago1.TabIndex = 58
        '
        'txt_Pago2
        '
        Me.txt_Pago2.Location = New System.Drawing.Point(137, 332)
        Me.txt_Pago2.Name = "txt_Pago2"
        Me.txt_Pago2.Size = New System.Drawing.Size(44, 20)
        Me.txt_Pago2.TabIndex = 59
        Me.txt_Pago2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DesPago2
        '
        Me.txt_DesPago2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesPago2.Location = New System.Drawing.Point(184, 332)
        Me.txt_DesPago2.Name = "txt_DesPago2"
        Me.txt_DesPago2.ReadOnly = True
        Me.txt_DesPago2.Size = New System.Drawing.Size(204, 20)
        Me.txt_DesPago2.TabIndex = 60
        '
        'txt_Limite
        '
        Me.txt_Limite.Location = New System.Drawing.Point(137, 355)
        Me.txt_Limite.Name = "txt_Limite"
        Me.txt_Limite.Size = New System.Drawing.Size(100, 20)
        Me.txt_Limite.TabIndex = 61
        Me.txt_Limite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Minimo
        '
        Me.txt_Minimo.Location = New System.Drawing.Point(345, 355)
        Me.txt_Minimo.Name = "txt_Minimo"
        Me.txt_Minimo.Size = New System.Drawing.Size(100, 20)
        Me.txt_Minimo.TabIndex = 62
        Me.txt_Minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DirEntrega
        '
        Me.txt_DirEntrega.Location = New System.Drawing.Point(137, 378)
        Me.txt_DirEntrega.Name = "txt_DirEntrega"
        Me.txt_DirEntrega.Size = New System.Drawing.Size(303, 20)
        Me.txt_DirEntrega.TabIndex = 63
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(460, 345)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 43)
        Me.Button1.TabIndex = 64
        Me.Button1.Text = "CERRAR PANTALLA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rabtn_NoCatalogado)
        Me.GroupBox1.Controls.Add(Me.rabtn_Exento)
        Me.GroupBox1.Controls.Add(Me.rabtn_ConsFinal)
        Me.GroupBox1.Controls.Add(Me.rabtn_Monotributo)
        Me.GroupBox1.Controls.Add(Me.rabtn_NoIncripto)
        Me.GroupBox1.Controls.Add(Me.rabtn_Incripto)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 88)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Condicion de IVA"
        '
        'rabtn_Incripto
        '
        Me.rabtn_Incripto.AutoSize = True
        Me.rabtn_Incripto.Checked = True
        Me.rabtn_Incripto.Location = New System.Drawing.Point(6, 19)
        Me.rabtn_Incripto.Name = "rabtn_Incripto"
        Me.rabtn_Incripto.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_Incripto.TabIndex = 0
        Me.rabtn_Incripto.TabStop = True
        Me.rabtn_Incripto.Text = "Incripto"
        Me.rabtn_Incripto.UseVisualStyleBackColor = True
        '
        'rabtn_NoIncripto
        '
        Me.rabtn_NoIncripto.AutoSize = True
        Me.rabtn_NoIncripto.Location = New System.Drawing.Point(6, 42)
        Me.rabtn_NoIncripto.Name = "rabtn_NoIncripto"
        Me.rabtn_NoIncripto.Size = New System.Drawing.Size(77, 17)
        Me.rabtn_NoIncripto.TabIndex = 1
        Me.rabtn_NoIncripto.Text = "No Incripto"
        Me.rabtn_NoIncripto.UseVisualStyleBackColor = True
        '
        'rabtn_Monotributo
        '
        Me.rabtn_Monotributo.AutoSize = True
        Me.rabtn_Monotributo.Location = New System.Drawing.Point(102, 42)
        Me.rabtn_Monotributo.Name = "rabtn_Monotributo"
        Me.rabtn_Monotributo.Size = New System.Drawing.Size(81, 17)
        Me.rabtn_Monotributo.TabIndex = 2
        Me.rabtn_Monotributo.Text = "Monotributo"
        Me.rabtn_Monotributo.UseVisualStyleBackColor = True
        '
        'rabtn_ConsFinal
        '
        Me.rabtn_ConsFinal.AutoSize = True
        Me.rabtn_ConsFinal.Location = New System.Drawing.Point(6, 65)
        Me.rabtn_ConsFinal.Name = "rabtn_ConsFinal"
        Me.rabtn_ConsFinal.Size = New System.Drawing.Size(77, 17)
        Me.rabtn_ConsFinal.TabIndex = 3
        Me.rabtn_ConsFinal.Text = "Cons. Final"
        Me.rabtn_ConsFinal.UseVisualStyleBackColor = True
        '
        'rabtn_Exento
        '
        Me.rabtn_Exento.AutoSize = True
        Me.rabtn_Exento.Location = New System.Drawing.Point(102, 19)
        Me.rabtn_Exento.Name = "rabtn_Exento"
        Me.rabtn_Exento.Size = New System.Drawing.Size(58, 17)
        Me.rabtn_Exento.TabIndex = 4
        Me.rabtn_Exento.Text = "Exento"
        Me.rabtn_Exento.UseVisualStyleBackColor = True
        '
        'rabtn_NoCatalogado
        '
        Me.rabtn_NoCatalogado.AutoSize = True
        Me.rabtn_NoCatalogado.Location = New System.Drawing.Point(102, 65)
        Me.rabtn_NoCatalogado.Name = "rabtn_NoCatalogado"
        Me.rabtn_NoCatalogado.Size = New System.Drawing.Size(96, 17)
        Me.rabtn_NoCatalogado.TabIndex = 5
        Me.rabtn_NoCatalogado.Text = "No Catalogado"
        Me.rabtn_NoCatalogado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Codigo de Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Razon Social"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Direccion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Localidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Provincia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Codigo Postal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(235, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Cuit"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Telefono"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(229, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Vendedor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Contacto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(235, 220)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "E-mail"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 243)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Observaciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(296, 243)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Fax"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 266)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Rubro"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 289)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Horario"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 312)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Condicion de Pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 335)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(125, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "Condicion de Proyeccion"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 358)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 13)
        Me.Label20.TabIndex = 83
        Me.Label20.Text = "Limite de Credito"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(248, 358)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 13)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "Minimo a Facturar"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 381)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(107, 13)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Direccion de Entrega"
        '
        'DatosdeCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 405)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_DirEntrega)
        Me.Controls.Add(Me.txt_Minimo)
        Me.Controls.Add(Me.txt_Limite)
        Me.Controls.Add(Me.txt_DesPago2)
        Me.Controls.Add(Me.txt_Pago2)
        Me.Controls.Add(Me.txt_DesPago1)
        Me.Controls.Add(Me.txt_Pago1)
        Me.Controls.Add(Me.txt_Horarios)
        Me.Controls.Add(Me.txt_DesRubro)
        Me.Controls.Add(Me.txt_Rubro)
        Me.Controls.Add(Me.txt_Fax)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.txt_Email)
        Me.Controls.Add(Me.txt_Contacto)
        Me.Controls.Add(Me.txt_DesVendedor)
        Me.Controls.Add(Me.txt_Vendedor)
        Me.Controls.Add(Me.txt_Telefono)
        Me.Controls.Add(Me.txt_Cuit)
        Me.Controls.Add(Me.txt_CPostal)
        Me.Controls.Add(Me.cbx_Provincia)
        Me.Controls.Add(Me.txt_Localidad)
        Me.Controls.Add(Me.txt_Direccion)
        Me.Controls.Add(Me.txt_Razon)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.panel1)
        Me.Name = "DatosdeCliente"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_Razon As System.Windows.Forms.TextBox
    Friend WithEvents txt_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents txt_Localidad As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Provincia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_CPostal As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cuit As System.Windows.Forms.TextBox
    Friend WithEvents txt_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_Vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_Contacto As System.Windows.Forms.TextBox
    Friend WithEvents txt_Email As System.Windows.Forms.TextBox
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_Fax As System.Windows.Forms.TextBox
    Friend WithEvents txt_Rubro As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesRubro As System.Windows.Forms.TextBox
    Friend WithEvents txt_Horarios As System.Windows.Forms.TextBox
    Friend WithEvents txt_Pago1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesPago1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Pago2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesPago2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Limite As System.Windows.Forms.TextBox
    Friend WithEvents txt_Minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_DirEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_NoCatalogado As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Exento As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_ConsFinal As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Monotributo As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_NoIncripto As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Incripto As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
