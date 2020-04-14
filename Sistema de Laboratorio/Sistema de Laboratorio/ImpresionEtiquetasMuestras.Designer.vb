<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionEtiquetasMuestras
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
        Me.txtInforme = New System.Windows.Forms.TextBox()
        Me.txtDescripcionMP = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtAnalista = New System.Windows.Forms.TextBox()
        Me.TxtCantEtiq = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.LtbMP = New System.Windows.Forms.ListBox()
        Me.LtbLotes = New System.Windows.Forms.ListBox()
        Me.txtCodigoMP2 = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(87, 61)
        Me.txtInforme.MaxLength = 6
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.Size = New System.Drawing.Size(51, 20)
        Me.txtInforme.TabIndex = 0
        Me.txtInforme.Text = "999999"
        Me.txtInforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcionMP
        '
        Me.txtDescripcionMP.BackColor = System.Drawing.Color.Cyan
        Me.txtDescripcionMP.Enabled = False
        Me.txtDescripcionMP.Location = New System.Drawing.Point(161, 92)
        Me.txtDescripcionMP.Name = "txtDescripcionMP"
        Me.txtDescripcionMP.Size = New System.Drawing.Size(366, 20)
        Me.txtDescripcionMP.TabIndex = 2
        '
        'txtLote
        '
        Me.txtLote.Enabled = False
        Me.txtLote.Location = New System.Drawing.Point(88, 125)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(150, 20)
        Me.txtLote.TabIndex = 3
        '
        'txtAnalista
        '
        Me.txtAnalista.Location = New System.Drawing.Point(317, 125)
        Me.txtAnalista.MaxLength = 50
        Me.txtAnalista.Name = "txtAnalista"
        Me.txtAnalista.Size = New System.Drawing.Size(61, 20)
        Me.txtAnalista.TabIndex = 5
        '
        'TxtCantEtiq
        '
        Me.TxtCantEtiq.Location = New System.Drawing.Point(497, 125)
        Me.TxtCantEtiq.MaxLength = 2
        Me.TxtCantEtiq.Name = "TxtCantEtiq"
        Me.TxtCantEtiq.Size = New System.Drawing.Size(30, 20)
        Me.TxtCantEtiq.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "INFORME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "MAT. PRIMA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "LOTE PROV:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "FECHA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "ANALISTA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(388, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "CANT. ETIQUETAS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 46)
        Me.Panel1.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(23, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(233, 18)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Emision de Etiquetas de Muestras"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(360, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SURFACTAN S.A."
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(26, 172)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(141, 42)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(199, 172)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(141, 42)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(372, 172)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(141, 42)
        Me.btnVolver.TabIndex = 16
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(198, 61)
        Me.mastxtFecha.Mask = ">00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(74, 20)
        Me.mastxtFecha.TabIndex = 17
        Me.mastxtFecha.Text = "99999999"
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LtbMP
        '
        Me.LtbMP.FormattingEnabled = True
        Me.LtbMP.Location = New System.Drawing.Point(377, 184)
        Me.LtbMP.Name = "LtbMP"
        Me.LtbMP.Size = New System.Drawing.Size(39, 30)
        Me.LtbMP.TabIndex = 18
        '
        'LtbLotes
        '
        Me.LtbLotes.FormattingEnabled = True
        Me.LtbLotes.Location = New System.Drawing.Point(377, 184)
        Me.LtbLotes.Name = "LtbLotes"
        Me.LtbLotes.Size = New System.Drawing.Size(39, 30)
        Me.LtbLotes.TabIndex = 19
        '
        'txtCodigoMP2
        '
        Me.txtCodigoMP2.Location = New System.Drawing.Point(88, 92)
        Me.txtCodigoMP2.Mask = ">LL-000-000"
        Me.txtCodigoMP2.Name = "txtCodigoMP2"
        Me.txtCodigoMP2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigoMP2.Size = New System.Drawing.Size(67, 20)
        Me.txtCodigoMP2.TabIndex = 17
        Me.txtCodigoMP2.Text = "AA999999"
        Me.txtCodigoMP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpresionEtiquetasMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 231)
        Me.Controls.Add(Me.LtbLotes)
        Me.Controls.Add(Me.LtbMP)
        Me.Controls.Add(Me.txtCodigoMP2)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCantEtiq)
        Me.Controls.Add(Me.txtAnalista)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.txtDescripcionMP)
        Me.Controls.Add(Me.txtInforme)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImpresionEtiquetasMuestras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInforme As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionMP As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtAnalista As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LtbMP As System.Windows.Forms.ListBox
    Friend WithEvents LtbLotes As System.Windows.Forms.ListBox
    Friend WithEvents txtCodigoMP2 As System.Windows.Forms.MaskedTextBox
End Class