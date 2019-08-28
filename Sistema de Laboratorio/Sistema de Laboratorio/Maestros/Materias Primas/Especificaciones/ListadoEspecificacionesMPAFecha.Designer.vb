<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoEspecificacionesMPAFecha
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
        Me.rbImpresora = New System.Windows.Forms.RadioButton()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHastaMP = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesdeMP = New System.Windows.Forms.MaskedTextBox()
        Me.txtHastaMes = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeMes = New System.Windows.Forms.MaskedTextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(562, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(380, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LISTADO  DE ESPECIFICACIONES DE MP A FECHA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.rbImpresora)
        Me.GroupBox1.Controls.Add(Me.rbPantalla)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtHastaMP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDesdeMP)
        Me.GroupBox1.Controls.Add(Me.txtHastaMes)
        Me.GroupBox1.Controls.Add(Me.txtDesdeMes)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 123)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS"
        '
        'rbImpresora
        '
        Me.rbImpresora.AutoSize = True
        Me.rbImpresora.Location = New System.Drawing.Point(410, 34)
        Me.rbImpresora.Name = "rbImpresora"
        Me.rbImpresora.Size = New System.Drawing.Size(89, 17)
        Me.rbImpresora.TabIndex = 2
        Me.rbImpresora.TabStop = True
        Me.rbImpresora.Text = "IMPRESORA"
        Me.rbImpresora.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(313, 34)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(80, 17)
        Me.rbPantalla.TabIndex = 2
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "PANTALLA"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(174, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "HASTA MES"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(248, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "DESDE MAT. PRIMA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DESDE MAT. PRIMA"
        '
        'txtHastaMP
        '
        Me.txtHastaMP.Location = New System.Drawing.Point(364, 73)
        Me.txtHastaMP.Mask = ">AA-000-000"
        Me.txtHastaMP.Name = "txtHastaMP"
        Me.txtHastaMP.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHastaMP.Size = New System.Drawing.Size(67, 20)
        Me.txtHastaMP.TabIndex = 0
        Me.txtHastaMP.Text = "ZZ999999"
        Me.txtHastaMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "DESDE MES"
        '
        'txtDesdeMP
        '
        Me.txtDesdeMP.Location = New System.Drawing.Point(164, 73)
        Me.txtDesdeMP.Mask = ">AA-000-000"
        Me.txtDesdeMP.Name = "txtDesdeMP"
        Me.txtDesdeMP.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeMP.Size = New System.Drawing.Size(67, 20)
        Me.txtDesdeMP.TabIndex = 0
        Me.txtDesdeMP.Text = "AA000000"
        Me.txtDesdeMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHastaMes
        '
        Me.txtHastaMes.Location = New System.Drawing.Point(250, 34)
        Me.txtHastaMes.Mask = "00"
        Me.txtHastaMes.Name = "txtHastaMes"
        Me.txtHastaMes.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHastaMes.Size = New System.Drawing.Size(26, 20)
        Me.txtHastaMes.TabIndex = 0
        Me.txtHastaMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesdeMes
        '
        Me.txtDesdeMes.Location = New System.Drawing.Point(124, 33)
        Me.txtDesdeMes.Mask = "00"
        Me.txtDesdeMes.Name = "txtDesdeMes"
        Me.txtDesdeMes.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeMes.Size = New System.Drawing.Size(26, 20)
        Me.txtDesdeMes.TabIndex = 0
        Me.txtDesdeMes.Text = "1"
        Me.txtDesdeMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(166, 181)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(105, 41)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(292, 181)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 41)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(34, 99)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(474, 16)
        Me.ProgressBar1.TabIndex = 3
        '
        'ListadoEspecificacionesMPAFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 227)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ListadoEspecificacionesMPAFecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtDesdeMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHastaMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHastaMP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeMP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
