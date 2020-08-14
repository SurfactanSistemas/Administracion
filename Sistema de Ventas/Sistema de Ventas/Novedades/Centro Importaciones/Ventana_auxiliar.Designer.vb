<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventana_auxiliar
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txt_FiltroOrden = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbx_Empresa = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lbx_467 = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txt_Carpeta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.lbl_Cambiar = New System.Windows.Forms.Label()
        Me.cbx_8al13 = New System.Windows.Forms.ComboBox()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Articulo = New System.Windows.Forms.MaskedTextBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Informar = New System.Windows.Forms.MaskedTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Location = New System.Drawing.Point(2, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(241, 85)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txt_FiltroOrden)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(233, 59)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Orden de Compra"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txt_FiltroOrden
        '
        Me.txt_FiltroOrden.Location = New System.Drawing.Point(110, 21)
        Me.txt_FiltroOrden.Name = "txt_FiltroOrden"
        Me.txt_FiltroOrden.Size = New System.Drawing.Size(100, 20)
        Me.txt_FiltroOrden.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Orden de Compra"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.cbx_Empresa)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(233, 59)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Empresa"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Empresa"
        '
        'cbx_Empresa
        '
        Me.cbx_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Empresa.FormattingEnabled = True
        Me.cbx_Empresa.Items.AddRange(New Object() {"", "Planta I", "Planta II", "Planta III", "Planta V", "Planta VI", "Planta VII"})
        Me.cbx_Empresa.Location = New System.Drawing.Point(78, 20)
        Me.cbx_Empresa.Name = "cbx_Empresa"
        Me.cbx_Empresa.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Empresa.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.txt_HastaFecha)
        Me.TabPage3.Controls.Add(Me.txt_DesdeFecha)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(233, 59)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Fecha"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Desde"
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(78, 32)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(100, 20)
        Me.txt_HastaFecha.TabIndex = 5
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(78, 6)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(100, 20)
        Me.txt_DesdeFecha.TabIndex = 4
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lbx_467)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(233, 59)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Listado"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lbx_467
        '
        Me.lbx_467.FormattingEnabled = True
        Me.lbx_467.Location = New System.Drawing.Point(7, 7)
        Me.lbx_467.Name = "lbx_467"
        Me.lbx_467.Size = New System.Drawing.Size(292, 160)
        Me.lbx_467.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txt_Carpeta)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(233, 59)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Carpeta"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txt_Carpeta
        '
        Me.txt_Carpeta.Location = New System.Drawing.Point(77, 16)
        Me.txt_Carpeta.Name = "txt_Carpeta"
        Me.txt_Carpeta.Size = New System.Drawing.Size(100, 20)
        Me.txt_Carpeta.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Carpeta"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.lbl_Cambiar)
        Me.TabPage6.Controls.Add(Me.cbx_8al13)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(233, 59)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'lbl_Cambiar
        '
        Me.lbl_Cambiar.AutoSize = True
        Me.lbl_Cambiar.Location = New System.Drawing.Point(10, 20)
        Me.lbl_Cambiar.Name = "lbl_Cambiar"
        Me.lbl_Cambiar.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Cambiar.TabIndex = 3
        Me.lbl_Cambiar.Text = "Opcion"
        '
        'cbx_8al13
        '
        Me.cbx_8al13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_8al13.FormattingEnabled = True
        Me.cbx_8al13.Items.AddRange(New Object() {"", "Planta I", "Planta II", "Planta III", "Planta V", "Planta VI", "Planta VII"})
        Me.cbx_8al13.Location = New System.Drawing.Point(95, 17)
        Me.cbx_8al13.Name = "cbx_8al13"
        Me.cbx_8al13.Size = New System.Drawing.Size(121, 21)
        Me.cbx_8al13.TabIndex = 2
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Button1)
        Me.TabPage7.Controls.Add(Me.Label6)
        Me.TabPage7.Controls.Add(Me.txt_Articulo)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(233, 59)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Articulo"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(152, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "CONSULTA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Articulo"
        '
        'txt_Articulo
        '
        Me.txt_Articulo.Location = New System.Drawing.Point(49, 22)
        Me.txt_Articulo.Mask = ">LL-000-000"
        Me.txt_Articulo.Name = "txt_Articulo"
        Me.txt_Articulo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Articulo.Size = New System.Drawing.Size(100, 20)
        Me.txt_Articulo.TabIndex = 7
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(83, 96)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 35)
        Me.btn_Aceptar.TabIndex = 1
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.Label7)
        Me.TabPage8.Controls.Add(Me.txt_Informar)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(233, 59)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "TXT DJAI"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Periodo a informar"
        '
        'txt_Informar
        '
        Me.txt_Informar.Location = New System.Drawing.Point(104, 19)
        Me.txt_Informar.Mask = "00/00/0000"
        Me.txt_Informar.Name = "txt_Informar"
        Me.txt_Informar.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Informar.Size = New System.Drawing.Size(100, 20)
        Me.txt_Informar.TabIndex = 7
        '
        'Ventana_auxiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 203)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Ventana_auxiliar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txt_FiltroOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbx_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lbx_467 As System.Windows.Forms.ListBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txt_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Cambiar As System.Windows.Forms.Label
    Friend WithEvents cbx_8al13 As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Articulo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_Informar As System.Windows.Forms.MaskedTextBox
End Class
