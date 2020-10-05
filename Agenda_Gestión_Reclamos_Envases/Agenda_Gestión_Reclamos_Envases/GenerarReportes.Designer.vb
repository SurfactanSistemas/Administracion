<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarReportes
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
        Me.rbFaltantes = New System.Windows.Forms.RadioButton()
        Me.rbCumplidos = New System.Windows.Forms.RadioButton()
        Me.rbCompleto = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.pnl_Fechas = New System.Windows.Forms.Panel()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_FechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txt_FechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.panel1.SuspendLayout()
        Me.pnl_Fechas.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(385, 50)
        Me.panel1.TabIndex = 128
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(230, 30)
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
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(128, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Imprimir Reporte"
        '
        'rbFaltantes
        '
        Me.rbFaltantes.AutoSize = True
        Me.rbFaltantes.Location = New System.Drawing.Point(10, 135)
        Me.rbFaltantes.Name = "rbFaltantes"
        Me.rbFaltantes.Size = New System.Drawing.Size(119, 17)
        Me.rbFaltantes.TabIndex = 131
        Me.rbFaltantes.TabStop = True
        Me.rbFaltantes.Text = "SÓLO FALTANTES"
        Me.rbFaltantes.UseVisualStyleBackColor = True
        '
        'rbCumplidos
        '
        Me.rbCumplidos.AutoSize = True
        Me.rbCumplidos.Location = New System.Drawing.Point(10, 107)
        Me.rbCumplidos.Name = "rbCumplidos"
        Me.rbCumplidos.Size = New System.Drawing.Size(120, 17)
        Me.rbCumplidos.TabIndex = 132
        Me.rbCumplidos.TabStop = True
        Me.rbCumplidos.Text = "SÓLO CUMPLIDOS"
        Me.rbCumplidos.UseVisualStyleBackColor = True
        '
        'rbCompleto
        '
        Me.rbCompleto.AutoSize = True
        Me.rbCompleto.Checked = True
        Me.rbCompleto.Location = New System.Drawing.Point(10, 80)
        Me.rbCompleto.Name = "rbCompleto"
        Me.rbCompleto.Size = New System.Drawing.Size(84, 17)
        Me.rbCompleto.TabIndex = 133
        Me.rbCompleto.TabStop = True
        Me.rbCompleto.Text = "COMPLETO"
        Me.rbCompleto.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(156, 137)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(217, 27)
        Me.Button2.TabIndex = 134
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(156, 65)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(217, 55)
        Me.btnListar.TabIndex = 135
        Me.btnListar.Text = "GENERAR LISTADO"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'pnl_Fechas
        '
        Me.pnl_Fechas.Controls.Add(Me.txt_FechaHasta)
        Me.pnl_Fechas.Controls.Add(Me.txt_FechaDesde)
        Me.pnl_Fechas.Controls.Add(Me.Label4)
        Me.pnl_Fechas.Controls.Add(Me.Label3)
        Me.pnl_Fechas.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Fechas.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Fechas.Location = New System.Drawing.Point(100, 65)
        Me.pnl_Fechas.Name = "pnl_Fechas"
        Me.pnl_Fechas.Size = New System.Drawing.Size(200, 92)
        Me.pnl_Fechas.TabIndex = 136
        Me.pnl_Fechas.Visible = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(20, 54)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(111, 54)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.TabIndex = 1
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'txt_FechaDesde
        '
        Me.txt_FechaDesde.Location = New System.Drawing.Point(20, 25)
        Me.txt_FechaDesde.Mask = "00/00/0000"
        Me.txt_FechaDesde.Name = "txt_FechaDesde"
        Me.txt_FechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaDesde.Size = New System.Drawing.Size(65, 20)
        Me.txt_FechaDesde.TabIndex = 4
        '
        'txt_FechaHasta
        '
        Me.txt_FechaHasta.Location = New System.Drawing.Point(118, 25)
        Me.txt_FechaHasta.Mask = "00/00/0000"
        Me.txt_FechaHasta.Name = "txt_FechaHasta"
        Me.txt_FechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaHasta.Size = New System.Drawing.Size(65, 20)
        Me.txt_FechaHasta.TabIndex = 5
        '
        'GenerarReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 176)
        Me.Controls.Add(Me.pnl_Fechas)
        Me.Controls.Add(Me.rbFaltantes)
        Me.Controls.Add(Me.rbCumplidos)
        Me.Controls.Add(Me.rbCompleto)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.panel1)
        Me.Name = "GenerarReportes"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.pnl_Fechas.ResumeLayout(False)
        Me.pnl_Fechas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents rbFaltantes As System.Windows.Forms.RadioButton
    Friend WithEvents rbCumplidos As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnListar As System.Windows.Forms.Button
    Friend WithEvents pnl_Fechas As System.Windows.Forms.Panel
    Friend WithEvents txt_FechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_FechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
End Class
