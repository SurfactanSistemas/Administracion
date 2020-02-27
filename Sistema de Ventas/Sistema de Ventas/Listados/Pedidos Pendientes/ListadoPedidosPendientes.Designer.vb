<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoPedidosPendientes
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.mastxtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.mastxtProductoDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCliente1 = New System.Windows.Forms.TextBox()
        Me.txtCliente2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoListado = New System.Windows.Forms.ComboBox()
        Me.RabtnPantalla = New System.Windows.Forms.RadioButton()
        Me.rabtnImpresora = New System.Windows.Forms.RadioButton()
        Me.RabtnExportar = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.mastxtProductoHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 51)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(250, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(210, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Listado Pedidos Pendientes"
        '
        'mastxtFechaDesde
        '
        Me.mastxtFechaDesde.Location = New System.Drawing.Point(104, 69)
        Me.mastxtFechaDesde.Mask = "00/00/0000"
        Me.mastxtFechaDesde.Name = "mastxtFechaDesde"
        Me.mastxtFechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaDesde.Size = New System.Drawing.Size(73, 20)
        Me.mastxtFechaDesde.TabIndex = 1
        Me.mastxtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFechaHasta
        '
        Me.mastxtFechaHasta.Location = New System.Drawing.Point(104, 101)
        Me.mastxtFechaHasta.Mask = "00/00/0000"
        Me.mastxtFechaHasta.Name = "mastxtFechaHasta"
        Me.mastxtFechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaHasta.Size = New System.Drawing.Size(73, 20)
        Me.mastxtFechaHasta.TabIndex = 2
        Me.mastxtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Desde Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Hasta Fecha"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(28, 141)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 5
        Me.lblProducto.Text = "Producto"
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Items.AddRange(New Object() {"PT", "MP"})
        Me.CmbTipo.Location = New System.Drawing.Point(106, 138)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(47, 21)
        Me.CmbTipo.TabIndex = 6
        '
        'mastxtProductoDesde
        '
        Me.mastxtProductoDesde.Location = New System.Drawing.Point(159, 138)
        Me.mastxtProductoDesde.Mask = ">LL-00000-000"
        Me.mastxtProductoDesde.Name = "mastxtProductoDesde"
        Me.mastxtProductoDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtProductoDesde.Size = New System.Drawing.Size(78, 20)
        Me.mastxtProductoDesde.TabIndex = 7
        Me.mastxtProductoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cliente"
        '
        'txtCliente1
        '
        Me.txtCliente1.Location = New System.Drawing.Point(105, 173)
        Me.txtCliente1.MaxLength = 6
        Me.txtCliente1.Name = "txtCliente1"
        Me.txtCliente1.Size = New System.Drawing.Size(100, 20)
        Me.txtCliente1.TabIndex = 9
        '
        'txtCliente2
        '
        Me.txtCliente2.Location = New System.Drawing.Point(211, 173)
        Me.txtCliente2.MaxLength = 6
        Me.txtCliente2.Name = "txtCliente2"
        Me.txtCliente2.Size = New System.Drawing.Size(100, 20)
        Me.txtCliente2.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Vendedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(104, 209)
        Me.txtVendedor.MaxLength = 2
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(49, 20)
        Me.txtVendedor.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(184, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Tipo de listado"
        '
        'cmbTipoListado
        '
        Me.cmbTipoListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoListado.FormattingEnabled = True
        Me.cmbTipoListado.Items.AddRange(New Object() {"Solo Autorizados", "Incluir NO Autorizados"})
        Me.cmbTipoListado.Location = New System.Drawing.Point(266, 209)
        Me.cmbTipoListado.Name = "cmbTipoListado"
        Me.cmbTipoListado.Size = New System.Drawing.Size(131, 21)
        Me.cmbTipoListado.TabIndex = 14
        '
        'RabtnPantalla
        '
        Me.RabtnPantalla.AutoSize = True
        Me.RabtnPantalla.Checked = True
        Me.RabtnPantalla.Location = New System.Drawing.Point(69, 254)
        Me.RabtnPantalla.Name = "RabtnPantalla"
        Me.RabtnPantalla.Size = New System.Drawing.Size(63, 17)
        Me.RabtnPantalla.TabIndex = 15
        Me.RabtnPantalla.TabStop = True
        Me.RabtnPantalla.Text = "Pantalla"
        Me.RabtnPantalla.UseVisualStyleBackColor = True
        '
        'rabtnImpresora
        '
        Me.rabtnImpresora.AutoSize = True
        Me.rabtnImpresora.Location = New System.Drawing.Point(176, 254)
        Me.rabtnImpresora.Name = "rabtnImpresora"
        Me.rabtnImpresora.Size = New System.Drawing.Size(71, 17)
        Me.rabtnImpresora.TabIndex = 16
        Me.rabtnImpresora.Text = "Impresora"
        Me.rabtnImpresora.UseVisualStyleBackColor = True
        '
        'RabtnExportar
        '
        Me.RabtnExportar.AutoSize = True
        Me.RabtnExportar.Location = New System.Drawing.Point(283, 254)
        Me.RabtnExportar.Name = "RabtnExportar"
        Me.RabtnExportar.Size = New System.Drawing.Size(64, 17)
        Me.RabtnExportar.TabIndex = 17
        Me.RabtnExportar.Text = "Exportar"
        Me.RabtnExportar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(320, 69)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(320, 104)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 19
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'mastxtProductoHasta
        '
        Me.mastxtProductoHasta.Location = New System.Drawing.Point(243, 138)
        Me.mastxtProductoHasta.Mask = ">LL-00000-000"
        Me.mastxtProductoHasta.Name = "mastxtProductoHasta"
        Me.mastxtProductoHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtProductoHasta.Size = New System.Drawing.Size(78, 20)
        Me.mastxtProductoHasta.TabIndex = 20
        Me.mastxtProductoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListadoPedidosPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 293)
        Me.Controls.Add(Me.mastxtProductoHasta)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.RabtnExportar)
        Me.Controls.Add(Me.rabtnImpresora)
        Me.Controls.Add(Me.RabtnPantalla)
        Me.Controls.Add(Me.cmbTipoListado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCliente2)
        Me.Controls.Add(Me.txtCliente1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.mastxtProductoDesde)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mastxtFechaHasta)
        Me.Controls.Add(Me.mastxtFechaDesde)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "ListadoPedidosPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents mastxtFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents mastxtProductoDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCliente1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoListado As System.Windows.Forms.ComboBox
    Friend WithEvents RabtnPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabtnImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents RabtnExportar As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents mastxtProductoHasta As System.Windows.Forms.MaskedTextBox
End Class
