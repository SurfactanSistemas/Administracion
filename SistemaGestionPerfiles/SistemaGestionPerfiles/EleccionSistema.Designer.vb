<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EleccionSistema
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbx_Sistemas = New System.Windows.Forms.ComboBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Perfil = New System.Windows.Forms.TextBox()
        Me.cbx_Planta = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(284, 52)
        Me.Panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(103, 27)
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
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE SISTEMA"
        '
        'cbx_Sistemas
        '
        Me.cbx_Sistemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Sistemas.FormattingEnabled = True
        Me.cbx_Sistemas.Items.AddRange(New Object() {"Laboratorio"})
        Me.cbx_Sistemas.Location = New System.Drawing.Point(91, 89)
        Me.cbx_Sistemas.Name = "cbx_Sistemas"
        Me.cbx_Sistemas.Size = New System.Drawing.Size(144, 21)
        Me.cbx_Sistemas.TabIndex = 6
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(40, 151)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 34)
        Me.btn_Aceptar.TabIndex = 7
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(160, 151)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 34)
        Me.btn_Cancelar.TabIndex = 8
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Sistema"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Perfil"
        '
        'txt_Perfil
        '
        Me.txt_Perfil.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Perfil.Location = New System.Drawing.Point(91, 61)
        Me.txt_Perfil.Name = "txt_Perfil"
        Me.txt_Perfil.ReadOnly = True
        Me.txt_Perfil.Size = New System.Drawing.Size(144, 20)
        Me.txt_Perfil.TabIndex = 11
        '
        'cbx_Planta
        '
        Me.cbx_Planta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Planta.FormattingEnabled = True
        Me.cbx_Planta.Items.AddRange(New Object() {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"})
        Me.cbx_Planta.Location = New System.Drawing.Point(91, 119)
        Me.cbx_Planta.Name = "cbx_Planta"
        Me.cbx_Planta.Size = New System.Drawing.Size(144, 21)
        Me.cbx_Planta.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Planta"
        '
        'EleccionSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 197)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbx_Planta)
        Me.Controls.Add(Me.txt_Perfil)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.cbx_Sistemas)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EleccionSistema"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_Sistemas As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Perfil As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Planta As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
