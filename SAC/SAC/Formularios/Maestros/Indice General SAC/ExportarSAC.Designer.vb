Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class ExportarSAC
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New Panel()
        Me.Label2 = New Label()
        Me.Label1 = New Label()
        Me.GroupBox1 = New GroupBox()
        Me.Label3 = New Label()
        Me.ComboBox1 = New ComboBox()
        Me.CheckBox2 = New CheckBox()
        Me.CheckBox3 = New CheckBox()
        Me.CheckBox1 = New CheckBox()
        Me.btnAceptar = New Button()
        Me.btnCancelar = New Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Location = New Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(440, 50)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(60, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Exportar"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(320, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New Point(8, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(424, 109)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos a Exportar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(74, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Formato"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"PDF", "EXCEL", "WORD", "Enviar por Correo (como PDF Adjunto)"})
        Me.ComboBox1.Location = New Point(125, 72)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New Size(225, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = CheckState.Checked
        Me.CheckBox2.Location = New Point(108, 37)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New Size(139, 17)
        Me.CheckBox2.TabIndex = 0
        Me.CheckBox2.Text = "Acciones y Seguimiento"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = CheckState.Checked
        Me.CheckBox3.Location = New Point(271, 37)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New Size(135, 17)
        Me.CheckBox3.TabIndex = 0
        Me.CheckBox3.Text = "Comentarios Generales"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = CheckState.Checked
        Me.CheckBox1.Location = New Point(19, 37)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New Size(65, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Carátula"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New Point(112, 178)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New Size(101, 28)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Exportar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New Point(228, 178)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New Size(101, 28)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ExportarSAC
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(440, 213)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ExportarSAC"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox3 As CheckBox
End Class
