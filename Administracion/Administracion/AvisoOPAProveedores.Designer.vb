<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvisoOPAProveedores
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
        Me.rbEntreRango = New System.Windows.Forms.RadioButton()
        Me.rbEntreFechas = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(505, 50)
        Me.Panel1.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(346, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Aviso de OP a Proveedores"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.rbEntreRango)
        Me.GroupBox1.Controls.Add(Me.rbEntreFechas)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 141)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros"
        '
        'rbEntreRango
        '
        Me.rbEntreRango.AutoSize = True
        Me.rbEntreRango.Location = New System.Drawing.Point(31, 72)
        Me.rbEntreRango.Name = "rbEntreRango"
        Me.rbEntreRango.Size = New System.Drawing.Size(118, 17)
        Me.rbEntreRango.TabIndex = 1
        Me.rbEntreRango.Text = "Entre Rango de OP"
        Me.rbEntreRango.UseVisualStyleBackColor = True
        '
        'rbEntreFechas
        '
        Me.rbEntreFechas.AutoSize = True
        Me.rbEntreFechas.Checked = True
        Me.rbEntreFechas.Location = New System.Drawing.Point(31, 32)
        Me.rbEntreFechas.Name = "rbEntreFechas"
        Me.rbEntreFechas.Size = New System.Drawing.Size(88, 17)
        Me.rbEntreFechas.TabIndex = 1
        Me.rbEntreFechas.TabStop = True
        Me.rbEntreFechas.Text = "Entre Fechas"
        Me.rbEntreFechas.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtHasta)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(175, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 98)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(159, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "HASTA"
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(213, 42)
        Me.txtHasta.Mask = "00/00/0000"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtHasta.TabIndex = 0
        Me.txtHasta.Text = "99999999"
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "DESDE"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(77, 42)
        Me.txtDesde.Mask = "00/00/0000"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtDesde.TabIndex = 0
        Me.txtDesde.Text = "99999999"
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEnviar
        '
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Location = New System.Drawing.Point(51, 205)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(118, 38)
        Me.btnEnviar.TabIndex = 62
        Me.btnEnviar.Text = "ENVIAR"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(193, 205)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(118, 38)
        Me.btnLimpiar.TabIndex = 62
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(335, 205)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(118, 38)
        Me.btnCerrar.TabIndex = 62
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 118)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(458, 11)
        Me.ProgressBar1.TabIndex = 2
        '
        'AvisoOPAProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 252)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AvisoOPAProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEntreRango As System.Windows.Forms.RadioButton
    Friend WithEvents rbEntreFechas As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
