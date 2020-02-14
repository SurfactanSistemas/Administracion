<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmisionEtiquetas
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCliente = New System.Windows.Forms.MaskedTextBox()
        Me.txtTerminado = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        Me.txtDescCliente = New System.Windows.Forms.TextBox()
        Me.txtLoteMP = New System.Windows.Forms.TextBox()
        Me.txtCodSeg = New System.Windows.Forms.TextBox()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCodSeg = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantEtiq = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTara = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEmitir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckImprimeNumEtiq = New System.Windows.Forms.CheckBox()
        Me.ckRangos = New System.Windows.Forms.CheckBox()
        Me.gbRango = New System.Windows.Forms.GroupBox()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbIdioma = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbRango.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(704, 49)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(518, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(30, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMISIÓN DE ETIQUETAS (SGA)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtTerminado)
        Me.GroupBox1.Controls.Add(Me.txtDescTerminado)
        Me.GroupBox1.Controls.Add(Me.txtDescCliente)
        Me.GroupBox1.Controls.Add(Me.txtLoteMP)
        Me.GroupBox1.Controls.Add(Me.txtCodSeg)
        Me.GroupBox1.Controls.Add(Me.txtPedido)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblCodSeg)
        Me.GroupBox1.Controls.Add(Me.lblPedido)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(673, 104)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PRODUCTO"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(74, 45)
        Me.txtCliente.Mask = ">L00000"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCliente.Size = New System.Drawing.Size(51, 20)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.Text = "A00013"
        '
        'txtTerminado
        '
        Me.txtTerminado.Location = New System.Drawing.Point(227, 19)
        Me.txtTerminado.Mask = ">LL-00000-000"
        Me.txtTerminado.Name = "txtTerminado"
        Me.txtTerminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTerminado.Size = New System.Drawing.Size(80, 20)
        Me.txtTerminado.TabIndex = 2
        Me.txtTerminado.Text = "PT99999999"
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.Location = New System.Drawing.Point(313, 19)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.Size = New System.Drawing.Size(342, 20)
        Me.txtDescTerminado.TabIndex = 1
        '
        'txtDescCliente
        '
        Me.txtDescCliente.Location = New System.Drawing.Point(131, 45)
        Me.txtDescCliente.Name = "txtDescCliente"
        Me.txtDescCliente.Size = New System.Drawing.Size(524, 20)
        Me.txtDescCliente.TabIndex = 1
        '
        'txtLoteMP
        '
        Me.txtLoteMP.Location = New System.Drawing.Point(74, 71)
        Me.txtLoteMP.Name = "txtLoteMP"
        Me.txtLoteMP.Size = New System.Drawing.Size(85, 20)
        Me.txtLoteMP.TabIndex = 1
        Me.txtLoteMP.Text = "999999"
        '
        'txtCodSeg
        '
        Me.txtCodSeg.Location = New System.Drawing.Point(331, 71)
        Me.txtCodSeg.MaxLength = 4
        Me.txtCodSeg.Name = "txtCodSeg"
        Me.txtCodSeg.Size = New System.Drawing.Size(51, 20)
        Me.txtCodSeg.TabIndex = 1
        Me.txtCodSeg.Text = "999999"
        Me.txtCodSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(211, 71)
        Me.txtPedido.MaxLength = 6
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(51, 20)
        Me.txtPedido.TabIndex = 1
        Me.txtPedido.Text = "999999"
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(74, 19)
        Me.txtLote.MaxLength = 6
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(51, 20)
        Me.txtLote.TabIndex = 1
        Me.txtLote.Text = "999999"
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Prod. Terminado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Lote MP:"
        '
        'lblCodSeg
        '
        Me.lblCodSeg.AutoSize = True
        Me.lblCodSeg.Location = New System.Drawing.Point(268, 75)
        Me.lblCodSeg.Name = "lblCodSeg"
        Me.lblCodSeg.Size = New System.Drawing.Size(57, 13)
        Me.lblCodSeg.TabIndex = 0
        Me.lblCodSeg.Text = "Cod. Seg.:"
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Location = New System.Drawing.Point(168, 75)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(43, 13)
        Me.lblPedido.TabIndex = 0
        Me.lblPedido.Text = "Pedido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Lote:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Cantidad (Kgs):"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(93, 25)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(51, 20)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.Text = "999999"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(150, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cantidad Etiq.:"
        '
        'txtCantEtiq
        '
        Me.txtCantEtiq.Location = New System.Drawing.Point(232, 25)
        Me.txtCantEtiq.MaxLength = 6
        Me.txtCantEtiq.Name = "txtCantEtiq"
        Me.txtCantEtiq.Size = New System.Drawing.Size(51, 20)
        Me.txtCantEtiq.TabIndex = 1
        Me.txtCantEtiq.Text = "999999"
        Me.txtCantEtiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(289, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Tara:"
        '
        'txtTara
        '
        Me.txtTara.Location = New System.Drawing.Point(327, 25)
        Me.txtTara.Name = "txtTara"
        Me.txtTara.Size = New System.Drawing.Size(51, 20)
        Me.txtTara.TabIndex = 1
        Me.txtTara.Text = "999999"
        Me.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(395, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tipo:"
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(427, 25)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(112, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gbRango)
        Me.GroupBox2.Controls.Add(Me.ckRangos)
        Me.GroupBox2.Controls.Add(Me.ckImprimeNumEtiq)
        Me.GroupBox2.Controls.Add(Me.cmbIdioma)
        Me.GroupBox2.Controls.Add(Me.cmbTipo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.txtCantEtiq)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTara)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(673, 100)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PARÁMETROS ETIQUETAS"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(431, 262)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(125, 38)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEmitir
        '
        Me.btnEmitir.Location = New System.Drawing.Point(149, 262)
        Me.btnEmitir.Name = "btnEmitir"
        Me.btnEmitir.Size = New System.Drawing.Size(125, 38)
        Me.btnEmitir.TabIndex = 4
        Me.btnEmitir.Text = "EMITIR ETIQUETA(S)"
        Me.btnEmitir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(290, 262)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(125, 38)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(598, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cod. Seg.:"
        '
        'ckImprimeNumEtiq
        '
        Me.ckImprimeNumEtiq.AutoSize = True
        Me.ckImprimeNumEtiq.Location = New System.Drawing.Point(26, 65)
        Me.ckImprimeNumEtiq.Name = "ckImprimeNumEtiq"
        Me.ckImprimeNumEtiq.Size = New System.Drawing.Size(158, 17)
        Me.ckImprimeNumEtiq.TabIndex = 5
        Me.ckImprimeNumEtiq.Text = "Imprimir Número de Etiqueta"
        Me.ckImprimeNumEtiq.UseVisualStyleBackColor = True
        '
        'ckRangos
        '
        Me.ckRangos.AutoSize = True
        Me.ckRangos.Location = New System.Drawing.Point(190, 65)
        Me.ckRangos.Name = "ckRangos"
        Me.ckRangos.Size = New System.Drawing.Size(63, 17)
        Me.ckRangos.TabIndex = 5
        Me.ckRangos.Text = "Rangos"
        Me.ckRangos.UseVisualStyleBackColor = True
        '
        'gbRango
        '
        Me.gbRango.Controls.Add(Me.txtHasta)
        Me.gbRango.Controls.Add(Me.txtDesde)
        Me.gbRango.Controls.Add(Me.Label13)
        Me.gbRango.Controls.Add(Me.Label8)
        Me.gbRango.Location = New System.Drawing.Point(266, 52)
        Me.gbRango.Name = "gbRango"
        Me.gbRango.Size = New System.Drawing.Size(381, 43)
        Me.gbRango.TabIndex = 6
        Me.gbRango.TabStop = False
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(133, 14)
        Me.txtDesde.MaxLength = 3
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(51, 20)
        Me.txtDesde.TabIndex = 2
        Me.txtDesde.Text = "999999"
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(254, 14)
        Me.txtHasta.MaxLength = 3
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(51, 20)
        Me.txtHasta.TabIndex = 2
        Me.txtHasta.Text = "999999"
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(76, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Desde:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(200, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Hasta:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(550, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Idioma:"
        '
        'cmbIdioma
        '
        Me.cmbIdioma.FormattingEnabled = True
        Me.cmbIdioma.Items.AddRange(New Object() {"CASTELLANO", "INGLÉS"})
        Me.cmbIdioma.Location = New System.Drawing.Point(592, 25)
        Me.cmbIdioma.Name = "cmbIdioma"
        Me.cmbIdioma.Size = New System.Drawing.Size(73, 21)
        Me.cmbIdioma.TabIndex = 4
        '
        'EmisionEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 305)
        Me.Controls.Add(Me.btnEmitir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmisionEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbRango.ResumeLayout(False)
        Me.gbRango.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTerminado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
    Friend WithEvents txtDescCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLoteMP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents txtCodSeg As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSeg As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTara As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEmitir As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ckRangos As System.Windows.Forms.CheckBox
    Friend WithEvents ckImprimeNumEtiq As System.Windows.Forms.CheckBox
    Friend WithEvents gbRango As System.Windows.Forms.GroupBox
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
