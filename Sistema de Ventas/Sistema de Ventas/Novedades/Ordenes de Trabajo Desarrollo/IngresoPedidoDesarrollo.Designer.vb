<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoPedidoDesarrollo
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
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.txtCodVendedor = New System.Windows.Forms.TextBox()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.txtDescpCliente = New System.Windows.Forms.TextBox()
        Me.txtDescripVendedor = New System.Windows.Forms.TextBox()
        Me.txtCodCliente = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.PagDescripcion = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtUso = New System.Windows.Forms.TextBox()
        Me.txtMuestra = New System.Windows.Forms.TextBox()
        Me.TxtMaterial = New System.Windows.Forms.TextBox()
        Me.PagEspecificaciones = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtReferencia3 = New System.Windows.Forms.TextBox()
        Me.txtReferencia2 = New System.Windows.Forms.TextBox()
        Me.txtReferencia1 = New System.Windows.Forms.TextBox()
        Me.txtRequisitosLegales = New System.Windows.Forms.TextBox()
        Me.txtOtrosRequisitos = New System.Windows.Forms.TextBox()
        Me.txtRequisito = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TabControl.SuspendLayout()
        Me.PagDescripcion.SuspendLayout()
        Me.PagEspecificaciones.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(70, 49)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtPedido.TabIndex = 0
        '
        'txtCodVendedor
        '
        Me.txtCodVendedor.Location = New System.Drawing.Point(70, 101)
        Me.txtCodVendedor.Name = "txtCodVendedor"
        Me.txtCodVendedor.Size = New System.Drawing.Size(100, 20)
        Me.txtCodVendedor.TabIndex = 2
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(70, 127)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(386, 20)
        Me.txtTitulo.TabIndex = 3
        '
        'txtDescpCliente
        '
        Me.txtDescpCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescpCliente.Location = New System.Drawing.Point(176, 75)
        Me.txtDescpCliente.Name = "txtDescpCliente"
        Me.txtDescpCliente.ReadOnly = True
        Me.txtDescpCliente.Size = New System.Drawing.Size(280, 20)
        Me.txtDescpCliente.TabIndex = 4
        '
        'txtDescripVendedor
        '
        Me.txtDescripVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescripVendedor.Location = New System.Drawing.Point(176, 101)
        Me.txtDescripVendedor.Name = "txtDescripVendedor"
        Me.txtDescripVendedor.ReadOnly = True
        Me.txtDescripVendedor.Size = New System.Drawing.Size(280, 20)
        Me.txtDescripVendedor.TabIndex = 5
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Location = New System.Drawing.Point(70, 75)
        Me.txtCodCliente.Mask = ">L00000"
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtCodCliente.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nro Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Vendedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Titulo"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.PagDescripcion)
        Me.TabControl.Controls.Add(Me.PagEspecificaciones)
        Me.TabControl.Location = New System.Drawing.Point(8, 153)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(543, 287)
        Me.TabControl.TabIndex = 11
        '
        'PagDescripcion
        '
        Me.PagDescripcion.BackColor = System.Drawing.SystemColors.Control
        Me.PagDescripcion.Controls.Add(Me.Label11)
        Me.PagDescripcion.Controls.Add(Me.Label10)
        Me.PagDescripcion.Controls.Add(Me.Label9)
        Me.PagDescripcion.Controls.Add(Me.Label8)
        Me.PagDescripcion.Controls.Add(Me.Label7)
        Me.PagDescripcion.Controls.Add(Me.Label6)
        Me.PagDescripcion.Controls.Add(Me.Label5)
        Me.PagDescripcion.Controls.Add(Me.txtCosto)
        Me.PagDescripcion.Controls.Add(Me.txtVolumen)
        Me.PagDescripcion.Controls.Add(Me.txtObservaciones)
        Me.PagDescripcion.Controls.Add(Me.txtDescripcion)
        Me.PagDescripcion.Controls.Add(Me.txtUso)
        Me.PagDescripcion.Controls.Add(Me.txtMuestra)
        Me.PagDescripcion.Controls.Add(Me.TxtMaterial)
        Me.PagDescripcion.Location = New System.Drawing.Point(4, 22)
        Me.PagDescripcion.Name = "PagDescripcion"
        Me.PagDescripcion.Padding = New System.Windows.Forms.Padding(3)
        Me.PagDescripcion.Size = New System.Drawing.Size(535, 261)
        Me.PagDescripcion.TabIndex = 0
        Me.PagDescripcion.Text = "Descripcion"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Costo Maximo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Volumen Estimado de Venta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Observaciones"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Descripcion del Trabajo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Uso"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Muestra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Material Provisto por el Cliente"
        '
        'txtCosto
        '
        Me.txtCosto.Location = New System.Drawing.Point(162, 228)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(100, 20)
        Me.txtCosto.TabIndex = 6
        '
        'txtVolumen
        '
        Me.txtVolumen.Location = New System.Drawing.Point(162, 202)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumen.TabIndex = 5
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(162, 160)
        Me.txtObservaciones.MaxLength = 150
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(369, 37)
        Me.txtObservaciones.TabIndex = 4
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(162, 93)
        Me.txtDescripcion.MaxLength = 250
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(369, 59)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtUso
        '
        Me.txtUso.Location = New System.Drawing.Point(162, 67)
        Me.txtUso.MaxLength = 50
        Me.txtUso.Name = "txtUso"
        Me.txtUso.Size = New System.Drawing.Size(369, 20)
        Me.txtUso.TabIndex = 2
        '
        'txtMuestra
        '
        Me.txtMuestra.Location = New System.Drawing.Point(162, 41)
        Me.txtMuestra.MaxLength = 50
        Me.txtMuestra.Name = "txtMuestra"
        Me.txtMuestra.Size = New System.Drawing.Size(369, 20)
        Me.txtMuestra.TabIndex = 1
        '
        'TxtMaterial
        '
        Me.TxtMaterial.Location = New System.Drawing.Point(162, 15)
        Me.TxtMaterial.MaxLength = 50
        Me.TxtMaterial.Name = "TxtMaterial"
        Me.TxtMaterial.Size = New System.Drawing.Size(369, 20)
        Me.TxtMaterial.TabIndex = 0
        '
        'PagEspecificaciones
        '
        Me.PagEspecificaciones.BackColor = System.Drawing.SystemColors.Control
        Me.PagEspecificaciones.Controls.Add(Me.Label20)
        Me.PagEspecificaciones.Controls.Add(Me.Label19)
        Me.PagEspecificaciones.Controls.Add(Me.Label18)
        Me.PagEspecificaciones.Controls.Add(Me.Label17)
        Me.PagEspecificaciones.Controls.Add(Me.Label16)
        Me.PagEspecificaciones.Controls.Add(Me.Label15)
        Me.PagEspecificaciones.Controls.Add(Me.Label14)
        Me.PagEspecificaciones.Controls.Add(Me.Label13)
        Me.PagEspecificaciones.Controls.Add(Me.txtReferencia3)
        Me.PagEspecificaciones.Controls.Add(Me.txtReferencia2)
        Me.PagEspecificaciones.Controls.Add(Me.txtReferencia1)
        Me.PagEspecificaciones.Controls.Add(Me.txtRequisitosLegales)
        Me.PagEspecificaciones.Controls.Add(Me.txtOtrosRequisitos)
        Me.PagEspecificaciones.Controls.Add(Me.txtRequisito)
        Me.PagEspecificaciones.Location = New System.Drawing.Point(4, 22)
        Me.PagEspecificaciones.Name = "PagEspecificaciones"
        Me.PagEspecificaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.PagEspecificaciones.Size = New System.Drawing.Size(535, 261)
        Me.PagEspecificaciones.TabIndex = 1
        Me.PagEspecificaciones.Text = "Especificaciones"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(4, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = " / Regulaciones"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 231)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Otros"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 205)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Hoja Seguridad"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 179)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Hoja Tecnica"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Referencias"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Requisitos Legales/ Normas"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Otros Requisitos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Requisitos Funcionales"
        '
        'txtReferencia3
        '
        Me.txtReferencia3.Location = New System.Drawing.Point(149, 228)
        Me.txtReferencia3.MaxLength = 50
        Me.txtReferencia3.Name = "txtReferencia3"
        Me.txtReferencia3.Size = New System.Drawing.Size(382, 20)
        Me.txtReferencia3.TabIndex = 10
        '
        'txtReferencia2
        '
        Me.txtReferencia2.Location = New System.Drawing.Point(149, 202)
        Me.txtReferencia2.MaxLength = 50
        Me.txtReferencia2.Name = "txtReferencia2"
        Me.txtReferencia2.Size = New System.Drawing.Size(382, 20)
        Me.txtReferencia2.TabIndex = 9
        '
        'txtReferencia1
        '
        Me.txtReferencia1.Location = New System.Drawing.Point(149, 176)
        Me.txtReferencia1.MaxLength = 50
        Me.txtReferencia1.Name = "txtReferencia1"
        Me.txtReferencia1.Size = New System.Drawing.Size(382, 20)
        Me.txtReferencia1.TabIndex = 8
        '
        'txtRequisitosLegales
        '
        Me.txtRequisitosLegales.Location = New System.Drawing.Point(149, 99)
        Me.txtRequisitosLegales.MaxLength = 100
        Me.txtRequisitosLegales.Multiline = True
        Me.txtRequisitosLegales.Name = "txtRequisitosLegales"
        Me.txtRequisitosLegales.Size = New System.Drawing.Size(382, 33)
        Me.txtRequisitosLegales.TabIndex = 7
        '
        'txtOtrosRequisitos
        '
        Me.txtOtrosRequisitos.Location = New System.Drawing.Point(149, 59)
        Me.txtOtrosRequisitos.MaxLength = 100
        Me.txtOtrosRequisitos.Multiline = True
        Me.txtOtrosRequisitos.Name = "txtOtrosRequisitos"
        Me.txtOtrosRequisitos.Size = New System.Drawing.Size(382, 33)
        Me.txtOtrosRequisitos.TabIndex = 6
        '
        'txtRequisito
        '
        Me.txtRequisito.Location = New System.Drawing.Point(149, 20)
        Me.txtRequisito.MaxLength = 100
        Me.txtRequisito.Multiline = True
        Me.txtRequisito.Name = "txtRequisito"
        Me.txtRequisito.Size = New System.Drawing.Size(382, 33)
        Me.txtRequisito.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(176, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(220, 48)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFecha.Size = New System.Drawing.Size(68, 20)
        Me.txtFecha.TabIndex = 13
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(476, 45)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 14
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(476, 74)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(476, 103)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Location = New System.Drawing.Point(476, 132)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(75, 23)
        Me.btnAutorizar.TabIndex = 17
        Me.btnAutorizar.Text = "Autorizar"
        Me.btnAutorizar.UseVisualStyleBackColor = True
        Me.btnAutorizar.Visible = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label21)
        Me.panel1.Controls.Add(Me.Label22)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(555, 40)
        Me.panel1.TabIndex = 18
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(379, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(155, 20)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "SURFACTAN S.A."
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(21, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(166, 17)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "SISTEMA DE VENTAS"
        '
        'IngresoPedidoDesarrollo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 447)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodCliente)
        Me.Controls.Add(Me.txtDescripVendedor)
        Me.Controls.Add(Me.txtDescpCliente)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.txtCodVendedor)
        Me.Controls.Add(Me.txtPedido)
        Me.Name = "IngresoPedidoDesarrollo"
        Me.TabControl.ResumeLayout(False)
        Me.PagDescripcion.ResumeLayout(False)
        Me.PagDescripcion.PerformLayout()
        Me.PagEspecificaciones.ResumeLayout(False)
        Me.PagEspecificaciones.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtCodVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescpCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents PagDescripcion As System.Windows.Forms.TabPage
    Friend WithEvents txtCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtUso As System.Windows.Forms.TextBox
    Friend WithEvents txtMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaterial As System.Windows.Forms.TextBox
    Friend WithEvents PagEspecificaciones As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia3 As System.Windows.Forms.TextBox
    Friend WithEvents txtReferencia2 As System.Windows.Forms.TextBox
    Friend WithEvents txtReferencia1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRequisitosLegales As System.Windows.Forms.TextBox
    Friend WithEvents txtOtrosRequisitos As System.Windows.Forms.TextBox
    Friend WithEvents txtRequisito As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents Label22 As System.Windows.Forms.Label
End Class
