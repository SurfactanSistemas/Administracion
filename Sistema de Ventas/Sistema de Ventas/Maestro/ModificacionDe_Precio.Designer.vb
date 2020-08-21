<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificacionDe_Precio
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ProductoTerminado = New System.Windows.Forms.TabPage()
        Me.btn_ConsultaPT = New System.Windows.Forms.Button()
        Me.btn_ConsultaCliPT = New System.Windows.Forms.Button()
        Me.btn_AceptarPT = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_HastaCliPTDes = New System.Windows.Forms.TextBox()
        Me.txt_DesdeCliPTDes = New System.Windows.Forms.TextBox()
        Me.txt_PorcentajePT = New System.Windows.Forms.TextBox()
        Me.txt_HastaPT = New System.Windows.Forms.MaskedTextBox()
        Me.txt_DesdePT = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaCliPT = New System.Windows.Forms.TextBox()
        Me.txt_DesdeCliPT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ReVenta = New System.Windows.Forms.TabPage()
        Me.btn_ConsultaCliMP = New System.Windows.Forms.Button()
        Me.btn_ConsultaMP = New System.Windows.Forms.Button()
        Me.btn_AceptarMP = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_HastaCliMPDes = New System.Windows.Forms.TextBox()
        Me.txt_DesdeCliMPDes = New System.Windows.Forms.TextBox()
        Me.txt_PorcentajeMP = New System.Windows.Forms.TextBox()
        Me.txt_HastaMP = New System.Windows.Forms.MaskedTextBox()
        Me.txt_DesdeMP = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaCliMP = New System.Windows.Forms.TextBox()
        Me.txt_DesdeCliMP = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.ProductoTerminado.SuspendLayout()
        Me.ReVenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(466, 55)
        Me.panel1.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(311, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(180, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Modificacion de Precios"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.ProductoTerminado)
        Me.TabControl1.Controls.Add(Me.ReVenta)
        Me.TabControl1.Location = New System.Drawing.Point(6, 62)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(453, 246)
        Me.TabControl1.TabIndex = 36
        '
        'ProductoTerminado
        '
        Me.ProductoTerminado.Controls.Add(Me.btn_ConsultaPT)
        Me.ProductoTerminado.Controls.Add(Me.btn_ConsultaCliPT)
        Me.ProductoTerminado.Controls.Add(Me.btn_AceptarPT)
        Me.ProductoTerminado.Controls.Add(Me.Label8)
        Me.ProductoTerminado.Controls.Add(Me.Label7)
        Me.ProductoTerminado.Controls.Add(Me.Label6)
        Me.ProductoTerminado.Controls.Add(Me.Label5)
        Me.ProductoTerminado.Controls.Add(Me.txt_HastaCliPTDes)
        Me.ProductoTerminado.Controls.Add(Me.txt_DesdeCliPTDes)
        Me.ProductoTerminado.Controls.Add(Me.txt_PorcentajePT)
        Me.ProductoTerminado.Controls.Add(Me.txt_HastaPT)
        Me.ProductoTerminado.Controls.Add(Me.txt_DesdePT)
        Me.ProductoTerminado.Controls.Add(Me.txt_HastaCliPT)
        Me.ProductoTerminado.Controls.Add(Me.txt_DesdeCliPT)
        Me.ProductoTerminado.Controls.Add(Me.Label4)
        Me.ProductoTerminado.Controls.Add(Me.Label3)
        Me.ProductoTerminado.Location = New System.Drawing.Point(4, 22)
        Me.ProductoTerminado.Name = "ProductoTerminado"
        Me.ProductoTerminado.Padding = New System.Windows.Forms.Padding(3)
        Me.ProductoTerminado.Size = New System.Drawing.Size(445, 220)
        Me.ProductoTerminado.TabIndex = 0
        Me.ProductoTerminado.Text = "PRODUCTO TERMINADO"
        Me.ProductoTerminado.UseVisualStyleBackColor = True
        '
        'btn_ConsultaPT
        '
        Me.btn_ConsultaPT.Location = New System.Drawing.Point(344, 161)
        Me.btn_ConsultaPT.Name = "btn_ConsultaPT"
        Me.btn_ConsultaPT.Size = New System.Drawing.Size(75, 46)
        Me.btn_ConsultaPT.TabIndex = 117
        Me.btn_ConsultaPT.Text = "CONSULTA PT"
        Me.btn_ConsultaPT.UseVisualStyleBackColor = True
        '
        'btn_ConsultaCliPT
        '
        Me.btn_ConsultaCliPT.Location = New System.Drawing.Point(344, 109)
        Me.btn_ConsultaCliPT.Name = "btn_ConsultaCliPT"
        Me.btn_ConsultaCliPT.Size = New System.Drawing.Size(75, 46)
        Me.btn_ConsultaCliPT.TabIndex = 116
        Me.btn_ConsultaCliPT.Text = "CONSULTA CLIENTE"
        Me.btn_ConsultaCliPT.UseVisualStyleBackColor = True
        '
        'btn_AceptarPT
        '
        Me.btn_AceptarPT.Location = New System.Drawing.Point(263, 131)
        Me.btn_AceptarPT.Name = "btn_AceptarPT"
        Me.btn_AceptarPT.Size = New System.Drawing.Size(75, 46)
        Me.btn_AceptarPT.TabIndex = 114
        Me.btn_AceptarPT.Text = "ACEPTAR"
        Me.btn_AceptarPT.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Porcentaje"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Desde Producto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Hasta Producto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hasta Cliente"
        '
        'txt_HastaCliPTDes
        '
        Me.txt_HastaCliPTDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_HastaCliPTDes.Location = New System.Drawing.Point(202, 76)
        Me.txt_HastaCliPTDes.Name = "txt_HastaCliPTDes"
        Me.txt_HastaCliPTDes.ReadOnly = True
        Me.txt_HastaCliPTDes.Size = New System.Drawing.Size(227, 20)
        Me.txt_HastaCliPTDes.TabIndex = 8
        '
        'txt_DesdeCliPTDes
        '
        Me.txt_DesdeCliPTDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesdeCliPTDes.Location = New System.Drawing.Point(202, 50)
        Me.txt_DesdeCliPTDes.Name = "txt_DesdeCliPTDes"
        Me.txt_DesdeCliPTDes.ReadOnly = True
        Me.txt_DesdeCliPTDes.Size = New System.Drawing.Size(227, 20)
        Me.txt_DesdeCliPTDes.TabIndex = 7
        '
        'txt_PorcentajePT
        '
        Me.txt_PorcentajePT.Location = New System.Drawing.Point(96, 175)
        Me.txt_PorcentajePT.MaxLength = 6
        Me.txt_PorcentajePT.Name = "txt_PorcentajePT"
        Me.txt_PorcentajePT.Size = New System.Drawing.Size(100, 20)
        Me.txt_PorcentajePT.TabIndex = 6
        '
        'txt_HastaPT
        '
        Me.txt_HastaPT.Location = New System.Drawing.Point(96, 139)
        Me.txt_HastaPT.Mask = ">LL-00000-000"
        Me.txt_HastaPT.Name = "txt_HastaPT"
        Me.txt_HastaPT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaPT.Size = New System.Drawing.Size(82, 20)
        Me.txt_HastaPT.TabIndex = 5
        '
        'txt_DesdePT
        '
        Me.txt_DesdePT.Location = New System.Drawing.Point(96, 113)
        Me.txt_DesdePT.Mask = ">LL-00000-000"
        Me.txt_DesdePT.Name = "txt_DesdePT"
        Me.txt_DesdePT.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdePT.Size = New System.Drawing.Size(82, 20)
        Me.txt_DesdePT.TabIndex = 4
        '
        'txt_HastaCliPT
        '
        Me.txt_HastaCliPT.Location = New System.Drawing.Point(96, 76)
        Me.txt_HastaCliPT.MaxLength = 6
        Me.txt_HastaCliPT.Name = "txt_HastaCliPT"
        Me.txt_HastaCliPT.Size = New System.Drawing.Size(100, 20)
        Me.txt_HastaCliPT.TabIndex = 3
        '
        'txt_DesdeCliPT
        '
        Me.txt_DesdeCliPT.Location = New System.Drawing.Point(96, 50)
        Me.txt_DesdeCliPT.MaxLength = 6
        Me.txt_DesdeCliPT.Name = "txt_DesdeCliPT"
        Me.txt_DesdeCliPT.Size = New System.Drawing.Size(100, 20)
        Me.txt_DesdeCliPT.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Desde Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(310, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ACTUALIZACION DE PRECIOS DE PRODUCTO TERMINADO"
        '
        'ReVenta
        '
        Me.ReVenta.Controls.Add(Me.btn_ConsultaCliMP)
        Me.ReVenta.Controls.Add(Me.btn_ConsultaMP)
        Me.ReVenta.Controls.Add(Me.btn_AceptarMP)
        Me.ReVenta.Controls.Add(Me.Label9)
        Me.ReVenta.Controls.Add(Me.Label10)
        Me.ReVenta.Controls.Add(Me.Label11)
        Me.ReVenta.Controls.Add(Me.Label12)
        Me.ReVenta.Controls.Add(Me.txt_HastaCliMPDes)
        Me.ReVenta.Controls.Add(Me.txt_DesdeCliMPDes)
        Me.ReVenta.Controls.Add(Me.txt_PorcentajeMP)
        Me.ReVenta.Controls.Add(Me.txt_HastaMP)
        Me.ReVenta.Controls.Add(Me.txt_DesdeMP)
        Me.ReVenta.Controls.Add(Me.txt_HastaCliMP)
        Me.ReVenta.Controls.Add(Me.txt_DesdeCliMP)
        Me.ReVenta.Controls.Add(Me.Label13)
        Me.ReVenta.Controls.Add(Me.Label14)
        Me.ReVenta.Location = New System.Drawing.Point(4, 22)
        Me.ReVenta.Name = "ReVenta"
        Me.ReVenta.Padding = New System.Windows.Forms.Padding(3)
        Me.ReVenta.Size = New System.Drawing.Size(445, 220)
        Me.ReVenta.TabIndex = 1
        Me.ReVenta.Text = "REVENTA"
        Me.ReVenta.UseVisualStyleBackColor = True
        '
        'btn_ConsultaCliMP
        '
        Me.btn_ConsultaCliMP.Location = New System.Drawing.Point(344, 109)
        Me.btn_ConsultaCliMP.Name = "btn_ConsultaCliMP"
        Me.btn_ConsultaCliMP.Size = New System.Drawing.Size(75, 46)
        Me.btn_ConsultaCliMP.TabIndex = 133
        Me.btn_ConsultaCliMP.Text = "CONSULTA CLIENTE"
        Me.btn_ConsultaCliMP.UseVisualStyleBackColor = True
        '
        'btn_ConsultaMP
        '
        Me.btn_ConsultaMP.Location = New System.Drawing.Point(344, 161)
        Me.btn_ConsultaMP.Name = "btn_ConsultaMP"
        Me.btn_ConsultaMP.Size = New System.Drawing.Size(75, 46)
        Me.btn_ConsultaMP.TabIndex = 132
        Me.btn_ConsultaMP.Text = "CONSULTA MP"
        Me.btn_ConsultaMP.UseVisualStyleBackColor = True
        '
        'btn_AceptarMP
        '
        Me.btn_AceptarMP.Location = New System.Drawing.Point(263, 130)
        Me.btn_AceptarMP.Name = "btn_AceptarMP"
        Me.btn_AceptarMP.Size = New System.Drawing.Size(75, 46)
        Me.btn_AceptarMP.TabIndex = 130
        Me.btn_AceptarMP.Text = "ACEPTAR"
        Me.btn_AceptarMP.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Porcentaje"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "Desde MP"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "Hasta MP"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Hasta Cliente"
        '
        'txt_HastaCliMPDes
        '
        Me.txt_HastaCliMPDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_HastaCliMPDes.Location = New System.Drawing.Point(192, 76)
        Me.txt_HastaCliMPDes.Name = "txt_HastaCliMPDes"
        Me.txt_HastaCliMPDes.ReadOnly = True
        Me.txt_HastaCliMPDes.Size = New System.Drawing.Size(233, 20)
        Me.txt_HastaCliMPDes.TabIndex = 125
        '
        'txt_DesdeCliMPDes
        '
        Me.txt_DesdeCliMPDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_DesdeCliMPDes.Location = New System.Drawing.Point(192, 50)
        Me.txt_DesdeCliMPDes.Name = "txt_DesdeCliMPDes"
        Me.txt_DesdeCliMPDes.ReadOnly = True
        Me.txt_DesdeCliMPDes.Size = New System.Drawing.Size(233, 20)
        Me.txt_DesdeCliMPDes.TabIndex = 124
        '
        'txt_PorcentajeMP
        '
        Me.txt_PorcentajeMP.Location = New System.Drawing.Point(86, 175)
        Me.txt_PorcentajeMP.Name = "txt_PorcentajeMP"
        Me.txt_PorcentajeMP.Size = New System.Drawing.Size(100, 20)
        Me.txt_PorcentajeMP.TabIndex = 123
        '
        'txt_HastaMP
        '
        Me.txt_HastaMP.Location = New System.Drawing.Point(86, 139)
        Me.txt_HastaMP.Mask = ">LL-000-000"
        Me.txt_HastaMP.Name = "txt_HastaMP"
        Me.txt_HastaMP.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaMP.Size = New System.Drawing.Size(72, 20)
        Me.txt_HastaMP.TabIndex = 122
        '
        'txt_DesdeMP
        '
        Me.txt_DesdeMP.Location = New System.Drawing.Point(86, 113)
        Me.txt_DesdeMP.Mask = ">LL-000-000"
        Me.txt_DesdeMP.Name = "txt_DesdeMP"
        Me.txt_DesdeMP.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeMP.Size = New System.Drawing.Size(72, 20)
        Me.txt_DesdeMP.TabIndex = 121
        '
        'txt_HastaCliMP
        '
        Me.txt_HastaCliMP.Location = New System.Drawing.Point(86, 76)
        Me.txt_HastaCliMP.Name = "txt_HastaCliMP"
        Me.txt_HastaCliMP.Size = New System.Drawing.Size(100, 20)
        Me.txt_HastaCliMP.TabIndex = 120
        '
        'txt_DesdeCliMP
        '
        Me.txt_DesdeCliMP.Location = New System.Drawing.Point(86, 50)
        Me.txt_DesdeCliMP.Name = "txt_DesdeCliMP"
        Me.txt_DesdeCliMP.Size = New System.Drawing.Size(100, 20)
        Me.txt_DesdeCliMP.TabIndex = 119
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 118
        Me.Label13.Text = "Desde Cliente"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(76, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(280, 13)
        Me.Label14.TabIndex = 117
        Me.Label14.Text = "ACTUALIZACION DE PRECIOS DE MATERIAS PRIMAS"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(196, 310)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 46)
        Me.btn_Cerrar.TabIndex = 115
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'ModificacionDe_Precio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 361)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ModificacionDe_Precio"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ProductoTerminado.ResumeLayout(False)
        Me.ProductoTerminado.PerformLayout()
        Me.ReVenta.ResumeLayout(False)
        Me.ReVenta.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ProductoTerminado As System.Windows.Forms.TabPage
    Friend WithEvents ReVenta As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_HastaCliPTDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesdeCliPTDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_PorcentajePT As System.Windows.Forms.TextBox
    Friend WithEvents txt_HastaPT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DesdePT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaCliPT As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesdeCliPT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_ConsultaCliPT As System.Windows.Forms.Button
    Friend WithEvents btn_AceptarPT As System.Windows.Forms.Button
    Friend WithEvents btn_ConsultaMP As System.Windows.Forms.Button
    Friend WithEvents btn_AceptarMP As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_HastaCliMPDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesdeCliMPDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_PorcentajeMP As System.Windows.Forms.TextBox
    Friend WithEvents txt_HastaMP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DesdeMP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaCliMP As System.Windows.Forms.TextBox
    Friend WithEvents txt_DesdeCliMP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_ConsultaPT As System.Windows.Forms.Button
    Friend WithEvents btn_ConsultaCliMP As System.Windows.Forms.Button
End Class