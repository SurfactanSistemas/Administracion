<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoDeEnsayoDePT
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rabPantalla = New System.Windows.Forms.RadioButton()
        Me.RabImprimir = New System.Windows.Forms.RadioButton()
        Me.lblDescEnsayoI = New System.Windows.Forms.Label()
        Me.lblDescEnsayoII = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckPt = New System.Windows.Forms.CheckBox()
        Me.ckSe = New System.Windows.Forms.CheckBox()
        Me.ckNk = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(52, 123)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(104, 42)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DESDE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "HASTA:"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(76, 56)
        Me.txtDesde.MaxLength = 4
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(38, 20)
        Me.txtDesde.TabIndex = 0
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(76, 87)
        Me.txtHasta.MaxLength = 4
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(38, 20)
        Me.txtHasta.TabIndex = 4
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(167, 123)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(104, 42)
        Me.btnVolver.TabIndex = 5
        Me.btnVolver.Text = "CERRAR"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 40)
        Me.Panel1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(314, 18)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Listado de Ensayos de Productos Terminados"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(388, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "SURFACTAN S.A."
        '
        'rabPantalla
        '
        Me.rabPantalla.AutoSize = True
        Me.rabPantalla.Checked = True
        Me.rabPantalla.Location = New System.Drawing.Point(456, 58)
        Me.rabPantalla.Name = "rabPantalla"
        Me.rabPantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabPantalla.TabIndex = 9
        Me.rabPantalla.TabStop = True
        Me.rabPantalla.Text = "Pantalla"
        Me.rabPantalla.UseVisualStyleBackColor = True
        '
        'RabImprimir
        '
        Me.RabImprimir.AutoSize = True
        Me.RabImprimir.Location = New System.Drawing.Point(456, 89)
        Me.RabImprimir.Name = "RabImprimir"
        Me.RabImprimir.Size = New System.Drawing.Size(60, 17)
        Me.RabImprimir.TabIndex = 10
        Me.RabImprimir.TabStop = True
        Me.RabImprimir.Text = "Imprimir"
        Me.RabImprimir.UseVisualStyleBackColor = True
        '
        'lblDescEnsayoI
        '
        Me.lblDescEnsayoI.BackColor = System.Drawing.Color.Cyan
        Me.lblDescEnsayoI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescEnsayoI.Location = New System.Drawing.Point(120, 56)
        Me.lblDescEnsayoI.Name = "lblDescEnsayoI"
        Me.lblDescEnsayoI.Size = New System.Drawing.Size(315, 20)
        Me.lblDescEnsayoI.TabIndex = 1
        '
        'lblDescEnsayoII
        '
        Me.lblDescEnsayoII.BackColor = System.Drawing.Color.Cyan
        Me.lblDescEnsayoII.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescEnsayoII.Location = New System.Drawing.Point(120, 87)
        Me.lblDescEnsayoII.Name = "lblDescEnsayoII"
        Me.lblDescEnsayoII.Size = New System.Drawing.Size(315, 20)
        Me.lblDescEnsayoII.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckNk)
        Me.GroupBox1.Controls.Add(Me.ckSe)
        Me.GroupBox1.Controls.Add(Me.ckPt)
        Me.GroupBox1.Location = New System.Drawing.Point(294, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 57)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INCLUIR"
        '
        'ckPt
        '
        Me.ckPt.AutoSize = True
        Me.ckPt.Checked = True
        Me.ckPt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckPt.Location = New System.Drawing.Point(18, 26)
        Me.ckPt.Name = "ckPt"
        Me.ckPt.Size = New System.Drawing.Size(47, 17)
        Me.ckPt.TabIndex = 0
        Me.ckPt.Text = "PT's"
        Me.ckPt.UseVisualStyleBackColor = True
        '
        'ckSe
        '
        Me.ckSe.AutoSize = True
        Me.ckSe.Location = New System.Drawing.Point(90, 26)
        Me.ckSe.Name = "ckSe"
        Me.ckSe.Size = New System.Drawing.Size(47, 17)
        Me.ckSe.TabIndex = 0
        Me.ckSe.Text = "SE's"
        Me.ckSe.UseVisualStyleBackColor = True
        '
        'ckNk
        '
        Me.ckNk.AutoSize = True
        Me.ckNk.Location = New System.Drawing.Point(162, 26)
        Me.ckNk.Name = "ckNk"
        Me.ckNk.Size = New System.Drawing.Size(48, 17)
        Me.ckNk.TabIndex = 0
        Me.ckNk.Text = "NK's"
        Me.ckNk.UseVisualStyleBackColor = True
        '
        'ListadoDeEnsayoDePT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 177)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RabImprimir)
        Me.Controls.Add(Me.rabPantalla)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.txtHasta)
        Me.Controls.Add(Me.txtDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblDescEnsayoII)
        Me.Controls.Add(Me.lblDescEnsayoI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListadoDeEnsayoDePT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rabPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents RabImprimir As System.Windows.Forms.RadioButton
    Friend WithEvents lblDescEnsayoI As System.Windows.Forms.Label
    Friend WithEvents lblDescEnsayoII As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckNk As System.Windows.Forms.CheckBox
    Friend WithEvents ckSe As System.Windows.Forms.CheckBox
    Friend WithEvents ckPt As System.Windows.Forms.CheckBox
End Class
