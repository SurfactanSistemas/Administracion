<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarDatosEnvases
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Codigo = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.txt_DescPackingList = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_TamanioBase = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Tara = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_DescInglesPackingList = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(373, 40)
        Me.panel1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(218, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SURFACTAN S.A."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Actualizar Datos Envases"
        '
        'txt_Codigo
        '
        Me.txt_Codigo.Location = New System.Drawing.Point(70, 60)
        Me.txt_Codigo.Mask = ">LL-000-000"
        Me.txt_Codigo.Name = "txt_Codigo"
        Me.txt_Codigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Codigo.Size = New System.Drawing.Size(67, 20)
        Me.txt_Codigo.TabIndex = 9
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Descripcion.Location = New System.Drawing.Point(143, 60)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.ReadOnly = True
        Me.txt_Descripcion.Size = New System.Drawing.Size(218, 20)
        Me.txt_Descripcion.TabIndex = 10
        '
        'txt_DescPackingList
        '
        Me.txt_DescPackingList.Location = New System.Drawing.Point(119, 106)
        Me.txt_DescPackingList.MaxLength = 10
        Me.txt_DescPackingList.Name = "txt_DescPackingList"
        Me.txt_DescPackingList.Size = New System.Drawing.Size(100, 20)
        Me.txt_DescPackingList.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Envase"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 26)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Desc." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PackingList"
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(260, 101)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 35)
        Me.btn_Grabar.TabIndex = 14
        Me.btn_Grabar.Text = "Guardar"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(260, 148)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 35)
        Me.btn_Cerrar.TabIndex = 15
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Tamaño base"
        '
        'txt_TamanioBase
        '
        Me.txt_TamanioBase.Location = New System.Drawing.Point(119, 132)
        Me.txt_TamanioBase.Name = "txt_TamanioBase"
        Me.txt_TamanioBase.Size = New System.Drawing.Size(100, 20)
        Me.txt_TamanioBase.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Tara"
        '
        'txt_Tara
        '
        Me.txt_Tara.Location = New System.Drawing.Point(119, 158)
        Me.txt_Tara.Name = "txt_Tara"
        Me.txt_Tara.Size = New System.Drawing.Size(100, 20)
        Me.txt_Tara.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 26)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Desc. Ingles" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PackingList"
        '
        'txt_DescInglesPackingList
        '
        Me.txt_DescInglesPackingList.Location = New System.Drawing.Point(119, 189)
        Me.txt_DescInglesPackingList.MaxLength = 10
        Me.txt_DescInglesPackingList.Name = "txt_DescInglesPackingList"
        Me.txt_DescInglesPackingList.Size = New System.Drawing.Size(100, 20)
        Me.txt_DescInglesPackingList.TabIndex = 20
        '
        'ActualizarDatosEnvases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 226)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_DescInglesPackingList)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Tara)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_TamanioBase)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_DescPackingList)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.txt_Codigo)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ActualizarDatosEnvases"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Codigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_DescPackingList As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_TamanioBase As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Tara As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_DescInglesPackingList As System.Windows.Forms.TextBox
End Class
