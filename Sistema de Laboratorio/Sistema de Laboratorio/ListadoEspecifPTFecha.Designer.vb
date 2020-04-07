<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoEspecifPTFecha
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
        Me.mastxtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtDePT = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtAPT = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.rabPantalla = New System.Windows.Forms.RadioButton()
        Me.rabImprimir = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mastxtFechaDesde
        '
        Me.mastxtFechaDesde.Location = New System.Drawing.Point(63, 56)
        Me.mastxtFechaDesde.Mask = "00/00/0000"
        Me.mastxtFechaDesde.Name = "mastxtFechaDesde"
        Me.mastxtFechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaDesde.Size = New System.Drawing.Size(71, 20)
        Me.mastxtFechaDesde.TabIndex = 0
        Me.mastxtFechaDesde.Text = "99999999"
        Me.mastxtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtFechaHasta
        '
        Me.mastxtFechaHasta.Location = New System.Drawing.Point(191, 56)
        Me.mastxtFechaHasta.Mask = "00/00/0000"
        Me.mastxtFechaHasta.Name = "mastxtFechaHasta"
        Me.mastxtFechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFechaHasta.Size = New System.Drawing.Size(72, 20)
        Me.mastxtFechaHasta.TabIndex = 1
        Me.mastxtFechaHasta.Text = "99999999"
        Me.mastxtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtDePT
        '
        Me.mastxtDePT.Location = New System.Drawing.Point(62, 87)
        Me.mastxtDePT.Mask = ">LL-00000-000"
        Me.mastxtDePT.Name = "mastxtDePT"
        Me.mastxtDePT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtDePT.Size = New System.Drawing.Size(80, 20)
        Me.mastxtDePT.TabIndex = 2
        Me.mastxtDePT.Text = "PT99999999"
        Me.mastxtDePT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtAPT
        '
        Me.mastxtAPT.Location = New System.Drawing.Point(197, 87)
        Me.mastxtAPT.Mask = ">LL-00000-000"
        Me.mastxtAPT.Name = "mastxtAPT"
        Me.mastxtAPT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtAPT.Size = New System.Drawing.Size(81, 20)
        Me.mastxtAPT.TabIndex = 3
        Me.mastxtAPT.Text = "PT99999999"
        Me.mastxtAPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "DESDE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "HASTA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "DESDE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "HASTA"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(98, 124)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(121, 51)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(225, 124)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(121, 51)
        Me.btnVolver.TabIndex = 9
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'rabPantalla
        '
        Me.rabPantalla.AutoSize = True
        Me.rabPantalla.Checked = True
        Me.rabPantalla.Location = New System.Drawing.Point(270, 58)
        Me.rabPantalla.Name = "rabPantalla"
        Me.rabPantalla.Size = New System.Drawing.Size(80, 17)
        Me.rabPantalla.TabIndex = 10
        Me.rabPantalla.TabStop = True
        Me.rabPantalla.Text = "PANTALLA"
        Me.rabPantalla.UseVisualStyleBackColor = True
        '
        'rabImprimir
        '
        Me.rabImprimir.AutoSize = True
        Me.rabImprimir.Location = New System.Drawing.Point(357, 58)
        Me.rabImprimir.Name = "rabImprimir"
        Me.rabImprimir.Size = New System.Drawing.Size(75, 17)
        Me.rabImprimir.TabIndex = 11
        Me.rabImprimir.Text = "IMPRIMIR"
        Me.rabImprimir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 46)
        Me.Panel1.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(213, 18)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Listado Especif. de PT a Fecha"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(254, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 24)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "SURFACTAN S.A."
        '
        'ListadoEspecifPTFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 186)
        Me.Controls.Add(Me.rabImprimir)
        Me.Controls.Add(Me.rabPantalla)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mastxtAPT)
        Me.Controls.Add(Me.mastxtDePT)
        Me.Controls.Add(Me.mastxtFechaHasta)
        Me.Controls.Add(Me.mastxtFechaDesde)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListadoEspecifPTFecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mastxtFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtDePT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtAPT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents rabPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabImprimir As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

