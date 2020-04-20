<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoPTVencidos
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
        Me.mastxtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.mastxtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rabPantalla = New System.Windows.Forms.RadioButton()
        Me.rabImprimir = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rabExportarExel = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mastxtDesde
        '
        Me.mastxtDesde.Location = New System.Drawing.Point(118, 64)
        Me.mastxtDesde.Mask = ">LL-00000-000"
        Me.mastxtDesde.Name = "mastxtDesde"
        Me.mastxtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtDesde.Size = New System.Drawing.Size(81, 20)
        Me.mastxtDesde.TabIndex = 0
        Me.mastxtDesde.Text = "PT99999999"
        Me.mastxtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mastxtHasta
        '
        Me.mastxtHasta.Location = New System.Drawing.Point(265, 64)
        Me.mastxtHasta.Mask = ">LL-00000-000"
        Me.mastxtHasta.Name = "mastxtHasta"
        Me.mastxtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtHasta.Size = New System.Drawing.Size(82, 20)
        Me.mastxtHasta.TabIndex = 1
        Me.mastxtHasta.Text = "PT99999999"
        Me.mastxtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DESDE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "HASTA"
        '
        'rabPantalla
        '
        Me.rabPantalla.AutoSize = True
        Me.rabPantalla.Checked = True
        Me.rabPantalla.Location = New System.Drawing.Point(53, 103)
        Me.rabPantalla.Name = "rabPantalla"
        Me.rabPantalla.Size = New System.Drawing.Size(80, 17)
        Me.rabPantalla.TabIndex = 4
        Me.rabPantalla.TabStop = True
        Me.rabPantalla.Text = "PANTALLA"
        Me.rabPantalla.UseVisualStyleBackColor = True
        '
        'rabImprimir
        '
        Me.rabImprimir.AutoSize = True
        Me.rabImprimir.Location = New System.Drawing.Point(148, 103)
        Me.rabImprimir.Name = "rabImprimir"
        Me.rabImprimir.Size = New System.Drawing.Size(75, 17)
        Me.rabImprimir.TabIndex = 5
        Me.rabImprimir.Text = "IMPRIMIR"
        Me.rabImprimir.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(72, 137)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(128, 46)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(222, 137)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(128, 46)
        Me.btnVolver.TabIndex = 7
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 52)
        Me.Panel1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Listado de PT Vencidos"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(260, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "SURFACTAN S.A."
        '
        'rabExportarExel
        '
        Me.rabExportarExel.AutoSize = True
        Me.rabExportarExel.Location = New System.Drawing.Point(238, 103)
        Me.rabExportarExel.Name = "rabExportarExel"
        Me.rabExportarExel.Size = New System.Drawing.Size(131, 17)
        Me.rabExportarExel.TabIndex = 9
        Me.rabExportarExel.Text = "EXPORTAR A EXCEL"
        Me.rabExportarExel.UseVisualStyleBackColor = True
        '
        'ListadoPTVencidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 196)
        Me.Controls.Add(Me.rabExportarExel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rabImprimir)
        Me.Controls.Add(Me.rabPantalla)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mastxtHasta)
        Me.Controls.Add(Me.mastxtDesde)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListadoPTVencidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mastxtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mastxtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rabPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabImprimir As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rabExportarExel As System.Windows.Forms.RadioButton
End Class
