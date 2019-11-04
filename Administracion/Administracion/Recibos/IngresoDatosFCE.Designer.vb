<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoDatosFCE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBoleto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lblDescProveedor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInteres = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAranceles = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIvaAranceles = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDerechos = New System.Windows.Forms.TextBox()
        Me.txtIvaDerechos = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAyudaProveedores = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 47)
        Me.Panel1.TabIndex = 125
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INGRESO DE DATOS DE FACTURA DE CRÉDITO ELECTRÓNICA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "N° BOLETO"
        '
        'txtBoleto
        '
        Me.txtBoleto.Location = New System.Drawing.Point(77, 57)
        Me.txtBoleto.MaxLength = 10
        Me.txtBoleto.Name = "txtBoleto"
        Me.txtBoleto.Size = New System.Drawing.Size(55, 20)
        Me.txtBoleto.TabIndex = 127
        Me.txtBoleto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(137, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "PROVEEDOR"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(239, 57)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(78, 20)
        Me.txtProveedor.TabIndex = 127
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescProveedor
        '
        Me.lblDescProveedor.BackColor = System.Drawing.Color.Cyan
        Me.lblDescProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescProveedor.Location = New System.Drawing.Point(323, 57)
        Me.lblDescProveedor.Name = "lblDescProveedor"
        Me.lblDescProveedor.Size = New System.Drawing.Size(238, 20)
        Me.lblDescProveedor.TabIndex = 126
        Me.lblDescProveedor.Text = "Proveedor"
        Me.lblDescProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "INTERÉS"
        '
        'txtInteres
        '
        Me.txtInteres.Location = New System.Drawing.Point(77, 86)
        Me.txtInteres.MaxLength = 32000
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(86, 20)
        Me.txtInteres.TabIndex = 127
        Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(178, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "ARANCELES"
        '
        'txtAranceles
        '
        Me.txtAranceles.Location = New System.Drawing.Point(255, 85)
        Me.txtAranceles.MaxLength = 32000
        Me.txtAranceles.Name = "txtAranceles"
        Me.txtAranceles.Size = New System.Drawing.Size(86, 20)
        Me.txtAranceles.TabIndex = 127
        Me.txtAranceles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "IVA 21% (ARANCELES)"
        '
        'txtIvaAranceles
        '
        Me.txtIvaAranceles.Location = New System.Drawing.Point(481, 85)
        Me.txtIvaAranceles.MaxLength = 32000
        Me.txtIvaAranceles.Name = "txtIvaAranceles"
        Me.txtIvaAranceles.Size = New System.Drawing.Size(80, 20)
        Me.txtIvaAranceles.TabIndex = 127
        Me.txtIvaAranceles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "DERECHOS"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "IVA 21% (DERECHOS)"
        '
        'txtDerechos
        '
        Me.txtDerechos.Location = New System.Drawing.Point(255, 115)
        Me.txtDerechos.MaxLength = 32000
        Me.txtDerechos.Name = "txtDerechos"
        Me.txtDerechos.Size = New System.Drawing.Size(86, 20)
        Me.txtDerechos.TabIndex = 127
        Me.txtDerechos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaDerechos
        '
        Me.txtIvaDerechos.Location = New System.Drawing.Point(481, 115)
        Me.txtIvaDerechos.MaxLength = 32000
        Me.txtIvaDerechos.Name = "txtIvaDerechos"
        Me.txtIvaDerechos.Size = New System.Drawing.Size(80, 20)
        Me.txtIvaDerechos.TabIndex = 127
        Me.txtIvaDerechos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(159, 151)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(119, 45)
        Me.btnAceptar.TabIndex = 128
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(294, 151)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(119, 45)
        Me.btnCerrar.TabIndex = 128
        Me.btnCerrar.Text = "CANCELAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAyudaProveedores
        '
        Me.btnAyudaProveedores.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnAyudaProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAyudaProveedores.FlatAppearance.BorderSize = 0
        Me.btnAyudaProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyudaProveedores.Location = New System.Drawing.Point(210, 54)
        Me.btnAyudaProveedores.Name = "btnAyudaProveedores"
        Me.btnAyudaProveedores.Size = New System.Drawing.Size(25, 25)
        Me.btnAyudaProveedores.TabIndex = 129
        Me.btnAyudaProveedores.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 130
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 115)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(86, 20)
        Me.TextBox1.TabIndex = 131
        '
        'IngresoDatosFCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 207)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAyudaProveedores)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.lblDescProveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIvaDerechos)
        Me.Controls.Add(Me.txtIvaAranceles)
        Me.Controls.Add(Me.txtDerechos)
        Me.Controls.Add(Me.txtAranceles)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtInteres)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBoleto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IngresoDatosFCE"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBoleto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblDescProveedor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAranceles As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIvaAranceles As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDerechos As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaDerechos As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAyudaProveedores As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
