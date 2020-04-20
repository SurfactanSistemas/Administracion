<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoParametrosEspecificaciones
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IngresoParametrosEspecificaciones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtParametro = New System.Windows.Forms.TextBox()
        Me.txtDescEnsayo = New System.Windows.Forms.TextBox()
        Me.txtFarmacopea = New System.Windows.Forms.TextBox()
        Me.txtEnsayo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFormula = New System.Windows.Forms.RadioButton()
        Me.rbNumerico = New System.Windows.Forms.RadioButton()
        Me.rbCumpleNoCumple = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ckMenorIgual = New System.Windows.Forms.CheckBox()
        Me.ckInforma = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.btnDefinirFormula = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ckHabDesdeHasta = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(435, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(280, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PARÁMETROS DE ESPECIFICACIÓN"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtParametro)
        Me.GroupBox1.Controls.Add(Me.txtDescEnsayo)
        Me.GroupBox1.Controls.Add(Me.txtFarmacopea)
        Me.GroupBox1.Controls.Add(Me.txtEnsayo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 104)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'txtParametro
        '
        Me.txtParametro.Location = New System.Drawing.Point(103, 47)
        Me.txtParametro.Name = "txtParametro"
        Me.txtParametro.Size = New System.Drawing.Size(301, 20)
        Me.txtParametro.TabIndex = 1
        '
        'txtDescEnsayo
        '
        Me.txtDescEnsayo.BackColor = System.Drawing.Color.Cyan
        Me.txtDescEnsayo.Location = New System.Drawing.Point(131, 20)
        Me.txtDescEnsayo.Name = "txtDescEnsayo"
        Me.txtDescEnsayo.ReadOnly = True
        Me.txtDescEnsayo.Size = New System.Drawing.Size(273, 20)
        Me.txtDescEnsayo.TabIndex = 1
        Me.txtDescEnsayo.TabStop = False
        '
        'txtFarmacopea
        '
        Me.txtFarmacopea.Location = New System.Drawing.Point(103, 73)
        Me.txtFarmacopea.Name = "txtFarmacopea"
        Me.txtFarmacopea.Size = New System.Drawing.Size(67, 20)
        Me.txtFarmacopea.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtFarmacopea, "Nombre Abreviado de la Farmacopea " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a la que hace referencia el Ensayo actual.")
        '
        'txtEnsayo
        '
        Me.txtEnsayo.Enabled = False
        Me.txtEnsayo.Location = New System.Drawing.Point(86, 20)
        Me.txtEnsayo.Name = "txtEnsayo"
        Me.txtEnsayo.Size = New System.Drawing.Size(39, 20)
        Me.txtEnsayo.TabIndex = 1
        Me.txtEnsayo.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Farmacopea:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Desc. Parámetro:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ensayo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFormula)
        Me.GroupBox2.Controls.Add(Me.rbNumerico)
        Me.GroupBox2.Controls.Add(Me.rbCumpleNoCumple)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 55)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Valor"
        '
        'rbFormula
        '
        Me.rbFormula.AutoSize = True
        Me.rbFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFormula.Location = New System.Drawing.Point(309, 22)
        Me.rbFormula.Name = "rbFormula"
        Me.rbFormula.Size = New System.Drawing.Size(84, 17)
        Me.rbFormula.TabIndex = 4
        Me.rbFormula.TabStop = True
        Me.rbFormula.Text = "FÓRMULA"
        Me.rbFormula.UseVisualStyleBackColor = True
        '
        'rbNumerico
        '
        Me.rbNumerico.AutoSize = True
        Me.rbNumerico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNumerico.Location = New System.Drawing.Point(204, 22)
        Me.rbNumerico.Name = "rbNumerico"
        Me.rbNumerico.Size = New System.Drawing.Size(91, 17)
        Me.rbNumerico.TabIndex = 4
        Me.rbNumerico.TabStop = True
        Me.rbNumerico.Text = "NUMÉRICO"
        Me.rbNumerico.UseVisualStyleBackColor = True
        '
        'rbCumpleNoCumple
        '
        Me.rbCumpleNoCumple.AutoSize = True
        Me.rbCumpleNoCumple.Checked = True
        Me.rbCumpleNoCumple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCumpleNoCumple.Location = New System.Drawing.Point(29, 22)
        Me.rbCumpleNoCumple.Name = "rbCumpleNoCumple"
        Me.rbCumpleNoCumple.Size = New System.Drawing.Size(161, 17)
        Me.rbCumpleNoCumple.TabIndex = 3
        Me.rbCumpleNoCumple.TabStop = True
        Me.rbCumpleNoCumple.Text = "CUMPLE / NO CUMPLE"
        Me.rbCumpleNoCumple.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ckHabDesdeHasta)
        Me.GroupBox3.Controls.Add(Me.txtHasta)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtDesde)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 212)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(281, 55)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de Valores"
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(192, 21)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(63, 20)
        Me.txtHasta.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtHasta, resources.GetString("txtHasta.ToolTip"))
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(154, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Hasta:"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(83, 21)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(63, 20)
        Me.txtDesde.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtDesde, resources.GetString("txtDesde.ToolTip"))
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Desde:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtUnidad)
        Me.GroupBox4.Location = New System.Drawing.Point(293, 212)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(135, 55)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Unidad"
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(31, 20)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(73, 20)
        Me.txtUnidad.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtUnidad, resources.GetString("txtUnidad.ToolTip"))
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ckMenorIgual)
        Me.GroupBox5.Controls.Add(Me.ckInforma)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 267)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(422, 56)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuración de Comportamiento"
        '
        'ckMenorIgual
        '
        Me.ckMenorIgual.AutoSize = True
        Me.ckMenorIgual.Location = New System.Drawing.Point(211, 25)
        Me.ckMenorIgual.Name = "ckMenorIgual"
        Me.ckMenorIgual.Size = New System.Drawing.Size(192, 17)
        Me.ckMenorIgual.TabIndex = 0
        Me.ckMenorIgual.Text = "Valor Superior como Menor Estricto"
        Me.ckMenorIgual.UseVisualStyleBackColor = True
        '
        'ckInforma
        '
        Me.ckInforma.AutoSize = True
        Me.ckInforma.Location = New System.Drawing.Point(20, 25)
        Me.ckInforma.Name = "ckInforma"
        Me.ckInforma.Size = New System.Drawing.Size(181, 17)
        Me.ckInforma.TabIndex = 7
        Me.ckInforma.Text = "Informa Valor en Cert. de Análisis"
        Me.ToolTip1.SetToolTip(Me.ckInforma, "Por defecto, para los tipos de valores numéricos," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "se imprimirán el rango para el" & _
        " cual se encuentra definido " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "como válido el parámetro." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Desmarcando ésta opci" & _
        "ón, se imprimirá el texto 'Informativo'")
        Me.ckInforma.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(65, 385)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(147, 40)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(222, 385)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(147, 40)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtFormula)
        Me.GroupBox6.Controls.Add(Me.btnDefinirFormula)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 323)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(422, 56)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Definición de Fórmula"
        '
        'txtFormula
        '
        Me.txtFormula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormula.Location = New System.Drawing.Point(68, 21)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(251, 20)
        Me.txtFormula.TabIndex = 5
        '
        'btnDefinirFormula
        '
        Me.btnDefinirFormula.Location = New System.Drawing.Point(325, 21)
        Me.btnDefinirFormula.Name = "btnDefinirFormula"
        Me.btnDefinirFormula.Size = New System.Drawing.Size(86, 21)
        Me.btnDefinirFormula.TabIndex = 9
        Me.btnDefinirFormula.Text = "DEFINIR"
        Me.btnDefinirFormula.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fórmula:"
        '
        'ckHabDesdeHasta
        '
        Me.ckHabDesdeHasta.AutoSize = True
        Me.ckHabDesdeHasta.Location = New System.Drawing.Point(20, 24)
        Me.ckHabDesdeHasta.Name = "ckHabDesdeHasta"
        Me.ckHabDesdeHasta.Size = New System.Drawing.Size(15, 14)
        Me.ckHabDesdeHasta.TabIndex = 8
        Me.ckHabDesdeHasta.UseVisualStyleBackColor = True
        '
        'IngresoParametrosEspecificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 432)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IngresoParametrosEspecificaciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtParametro As System.Windows.Forms.TextBox
    Friend WithEvents txtDescEnsayo As System.Windows.Forms.TextBox
    Friend WithEvents txtEnsayo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNumerico As System.Windows.Forms.RadioButton
    Friend WithEvents rbCumpleNoCumple As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents txtFarmacopea As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ckMenorIgual As System.Windows.Forms.CheckBox
    Friend WithEvents ckInforma As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents rbFormula As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDefinirFormula As System.Windows.Forms.Button
    Friend WithEvents ckHabDesdeHasta As System.Windows.Forms.CheckBox
End Class
