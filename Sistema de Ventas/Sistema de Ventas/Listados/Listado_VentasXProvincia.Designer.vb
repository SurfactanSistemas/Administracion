<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_VentasXProvincia
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
        Me.txt_FechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txt_FechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.rabtn_Imprimir = New System.Windows.Forms.RadioButton()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
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
        Me.panel1.Size = New System.Drawing.Size(380, 40)
        Me.panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(225, 15)
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
        Me.Label5.Location = New System.Drawing.Point(7, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(217, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Listado Ventas por Provincia"
        '
        'txt_FechaDesde
        '
        Me.txt_FechaDesde.Location = New System.Drawing.Point(96, 50)
        Me.txt_FechaDesde.Mask = "00/00/0000"
        Me.txt_FechaDesde.Name = "txt_FechaDesde"
        Me.txt_FechaDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaDesde.Size = New System.Drawing.Size(69, 20)
        Me.txt_FechaDesde.TabIndex = 8
        '
        'txt_FechaHasta
        '
        Me.txt_FechaHasta.Location = New System.Drawing.Point(96, 85)
        Me.txt_FechaHasta.Mask = "00/00/0000"
        Me.txt_FechaHasta.Name = "txt_FechaHasta"
        Me.txt_FechaHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_FechaHasta.Size = New System.Drawing.Size(69, 20)
        Me.txt_FechaHasta.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Desde Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hasta Fecha"
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(16, 121)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(63, 17)
        Me.rabtn_Pantalla.TabIndex = 12
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'rabtn_Imprimir
        '
        Me.rabtn_Imprimir.AutoSize = True
        Me.rabtn_Imprimir.Location = New System.Drawing.Point(111, 121)
        Me.rabtn_Imprimir.Name = "rabtn_Imprimir"
        Me.rabtn_Imprimir.Size = New System.Drawing.Size(60, 17)
        Me.rabtn_Imprimir.TabIndex = 13
        Me.rabtn_Imprimir.Text = "Imprimir"
        Me.rabtn_Imprimir.UseVisualStyleBackColor = True
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(212, 70)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 48)
        Me.btn_Aceptar.TabIndex = 14
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(293, 70)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 48)
        Me.btn_Cerrar.TabIndex = 15
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Listado_VentasXProvincia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 150)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.rabtn_Imprimir)
        Me.Controls.Add(Me.rabtn_Pantalla)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_FechaHasta)
        Me.Controls.Add(Me.txt_FechaDesde)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximumSize = New System.Drawing.Size(396, 189)
        Me.MinimumSize = New System.Drawing.Size(396, 189)
        Me.Name = "Listado_VentasXProvincia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_FechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_FechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Imprimir As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
End Class
