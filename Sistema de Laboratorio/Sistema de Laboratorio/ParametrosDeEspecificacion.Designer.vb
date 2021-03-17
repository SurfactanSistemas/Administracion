<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosDeEspecificacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbVariables = New System.Windows.Forms.GroupBox()
        Me.txtVar8 = New System.Windows.Forms.TextBox()
        Me.txtVar4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVar7 = New System.Windows.Forms.TextBox()
        Me.txtVar3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVar10 = New System.Windows.Forms.TextBox()
        Me.txtVar6 = New System.Windows.Forms.TextBox()
        Me.txtVar2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVar9 = New System.Windows.Forms.TextBox()
        Me.txtVar5 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVar1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.btnTraer = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.gbVariables.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(517, 294)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(155, 36)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(20, 294)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(163, 36)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtFormula)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(677, 99)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fórmula"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(87, 48)
        Me.txtDescripcion.MaxLength = 200
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(583, 43)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Descripcion:"
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(87, 22)
        Me.txtFormula.MaxLength = 100
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(583, 20)
        Me.txtFormula.TabIndex = 1
        Me.txtFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Definición:"
        '
        'gbVariables
        '
        Me.gbVariables.Controls.Add(Me.txtVar8)
        Me.gbVariables.Controls.Add(Me.txtVar4)
        Me.gbVariables.Controls.Add(Me.Label10)
        Me.gbVariables.Controls.Add(Me.Label6)
        Me.gbVariables.Controls.Add(Me.txtVar7)
        Me.gbVariables.Controls.Add(Me.txtVar3)
        Me.gbVariables.Controls.Add(Me.Label9)
        Me.gbVariables.Controls.Add(Me.Label5)
        Me.gbVariables.Controls.Add(Me.txtVar10)
        Me.gbVariables.Controls.Add(Me.txtVar6)
        Me.gbVariables.Controls.Add(Me.txtVar2)
        Me.gbVariables.Controls.Add(Me.Label12)
        Me.gbVariables.Controls.Add(Me.Label8)
        Me.gbVariables.Controls.Add(Me.Label4)
        Me.gbVariables.Controls.Add(Me.txtVar9)
        Me.gbVariables.Controls.Add(Me.txtVar5)
        Me.gbVariables.Controls.Add(Me.Label11)
        Me.gbVariables.Controls.Add(Me.txtVar1)
        Me.gbVariables.Controls.Add(Me.Label7)
        Me.gbVariables.Controls.Add(Me.Label3)
        Me.gbVariables.Location = New System.Drawing.Point(7, 59)
        Me.gbVariables.Name = "gbVariables"
        Me.gbVariables.Size = New System.Drawing.Size(678, 129)
        Me.gbVariables.TabIndex = 9
        Me.gbVariables.TabStop = False
        Me.gbVariables.Text = "Configuración de Variables"
        '
        'txtVar8
        '
        Me.txtVar8.Location = New System.Drawing.Point(249, 94)
        Me.txtVar8.MaxLength = 30
        Me.txtVar8.Name = "txtVar8"
        Me.txtVar8.Size = New System.Drawing.Size(196, 20)
        Me.txtVar8.TabIndex = 1
        '
        'txtVar4
        '
        Me.txtVar4.Location = New System.Drawing.Point(27, 94)
        Me.txtVar4.MaxLength = 30
        Me.txtVar4.Name = "txtVar4"
        Me.txtVar4.Size = New System.Drawing.Size(196, 20)
        Me.txtVar4.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(229, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "8)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "4)"
        '
        'txtVar7
        '
        Me.txtVar7.Location = New System.Drawing.Point(249, 70)
        Me.txtVar7.MaxLength = 30
        Me.txtVar7.Name = "txtVar7"
        Me.txtVar7.Size = New System.Drawing.Size(196, 20)
        Me.txtVar7.TabIndex = 1
        '
        'txtVar3
        '
        Me.txtVar3.Location = New System.Drawing.Point(27, 70)
        Me.txtVar3.MaxLength = 30
        Me.txtVar3.Name = "txtVar3"
        Me.txtVar3.Size = New System.Drawing.Size(196, 20)
        Me.txtVar3.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(229, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "7)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "3)"
        '
        'txtVar10
        '
        Me.txtVar10.Location = New System.Drawing.Point(475, 47)
        Me.txtVar10.MaxLength = 30
        Me.txtVar10.Name = "txtVar10"
        Me.txtVar10.Size = New System.Drawing.Size(196, 20)
        Me.txtVar10.TabIndex = 1
        '
        'txtVar6
        '
        Me.txtVar6.Location = New System.Drawing.Point(249, 47)
        Me.txtVar6.MaxLength = 30
        Me.txtVar6.Name = "txtVar6"
        Me.txtVar6.Size = New System.Drawing.Size(196, 20)
        Me.txtVar6.TabIndex = 1
        '
        'txtVar2
        '
        Me.txtVar2.Location = New System.Drawing.Point(27, 47)
        Me.txtVar2.MaxLength = 30
        Me.txtVar2.Name = "txtVar2"
        Me.txtVar2.Size = New System.Drawing.Size(196, 20)
        Me.txtVar2.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(448, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "10)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(229, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "6)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "2)"
        '
        'txtVar9
        '
        Me.txtVar9.Location = New System.Drawing.Point(475, 23)
        Me.txtVar9.MaxLength = 30
        Me.txtVar9.Name = "txtVar9"
        Me.txtVar9.Size = New System.Drawing.Size(196, 20)
        Me.txtVar9.TabIndex = 1
        '
        'txtVar5
        '
        Me.txtVar5.Location = New System.Drawing.Point(249, 23)
        Me.txtVar5.MaxLength = 30
        Me.txtVar5.Name = "txtVar5"
        Me.txtVar5.Size = New System.Drawing.Size(196, 20)
        Me.txtVar5.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(454, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "9)"
        '
        'txtVar1
        '
        Me.txtVar1.Location = New System.Drawing.Point(27, 23)
        Me.txtVar1.MaxLength = 30
        Me.txtVar1.Name = "txtVar1"
        Me.txtVar1.Size = New System.Drawing.Size(196, 20)
        Me.txtVar1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(229, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "5)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "1)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(693, 49)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(538, 15)
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
        'btnVerificar
        '
        Me.btnVerificar.Location = New System.Drawing.Point(191, 294)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(155, 36)
        Me.btnVerificar.TabIndex = 13
        Me.btnVerificar.Text = "VERIFICAR"
        Me.btnVerificar.UseVisualStyleBackColor = True
        '
        'btnTraer
        '
        Me.btnTraer.Location = New System.Drawing.Point(354, 294)
        Me.btnTraer.Name = "btnTraer"
        Me.btnTraer.Size = New System.Drawing.Size(155, 36)
        Me.btnTraer.TabIndex = 11
        Me.btnTraer.Text = "TRAER FÓRMULA"
        Me.btnTraer.UseVisualStyleBackColor = True
        '
        'ParametrosDeEspecificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 336)
        Me.Controls.Add(Me.btnVerificar)
        Me.Controls.Add(Me.btnTraer)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbVariables)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ParametrosDeEspecificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbVariables.ResumeLayout(False)
        Me.gbVariables.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbVariables As System.Windows.Forms.GroupBox
    Friend WithEvents txtVar8 As System.Windows.Forms.TextBox
    Friend WithEvents txtVar4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVar7 As System.Windows.Forms.TextBox
    Friend WithEvents txtVar3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVar10 As System.Windows.Forms.TextBox
    Friend WithEvents txtVar6 As System.Windows.Forms.TextBox
    Friend WithEvents txtVar2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVar9 As System.Windows.Forms.TextBox
    Friend WithEvents txtVar5 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVar1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents btnTraer As System.Windows.Forms.Button
End Class
