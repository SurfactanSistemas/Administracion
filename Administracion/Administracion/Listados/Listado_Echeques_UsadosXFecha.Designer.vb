<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_Echeques_UsadosXFecha
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
        Me.gbx_Fechas = New System.Windows.Forms.GroupBox()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.gbx_TipoImpresion = New System.Windows.Forms.GroupBox()
        Me.rabtn_Imprimir = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pantalla = New System.Windows.Forms.RadioButton()
        Me.panel1.SuspendLayout()
        Me.gbx_Fechas.SuspendLayout()
        Me.gbx_TipoImpresion.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(533, 59)
        Me.panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(337, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(311, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado E-Cheques Usados a Fecha"
        '
        'gbx_Fechas
        '
        Me.gbx_Fechas.Controls.Add(Me.Label4)
        Me.gbx_Fechas.Controls.Add(Me.Label3)
        Me.gbx_Fechas.Controls.Add(Me.txt_HastaFecha)
        Me.gbx_Fechas.Controls.Add(Me.txt_DesdeFecha)
        Me.gbx_Fechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Fechas.Location = New System.Drawing.Point(7, 66)
        Me.gbx_Fechas.Name = "gbx_Fechas"
        Me.gbx_Fechas.Size = New System.Drawing.Size(203, 100)
        Me.gbx_Fechas.TabIndex = 10
        Me.gbx_Fechas.TabStop = False
        Me.gbx_Fechas.Text = "Rango Fechas"
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(94, 30)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(100, 22)
        Me.txt_DesdeFecha.TabIndex = 0
        Me.txt_DesdeFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(94, 67)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(100, 22)
        Me.txt_HastaFecha.TabIndex = 1
        Me.txt_HastaFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Location = New System.Drawing.Point(405, 66)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(108, 38)
        Me.btn_Aceptar.TabIndex = 11
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Location = New System.Drawing.Point(405, 120)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(108, 38)
        Me.btn_Cerrar.TabIndex = 12
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'gbx_TipoImpresion
        '
        Me.gbx_TipoImpresion.Controls.Add(Me.rabtn_Imprimir)
        Me.gbx_TipoImpresion.Controls.Add(Me.rabtn_Pantalla)
        Me.gbx_TipoImpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_TipoImpresion.Location = New System.Drawing.Point(216, 66)
        Me.gbx_TipoImpresion.Name = "gbx_TipoImpresion"
        Me.gbx_TipoImpresion.Size = New System.Drawing.Size(183, 100)
        Me.gbx_TipoImpresion.TabIndex = 13
        Me.gbx_TipoImpresion.TabStop = False
        Me.gbx_TipoImpresion.Text = "Tipo Impresion"
        '
        'rabtn_Imprimir
        '
        Me.rabtn_Imprimir.AutoSize = True
        Me.rabtn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rabtn_Imprimir.Location = New System.Drawing.Point(42, 62)
        Me.rabtn_Imprimir.Name = "rabtn_Imprimir"
        Me.rabtn_Imprimir.Size = New System.Drawing.Size(86, 21)
        Me.rabtn_Imprimir.TabIndex = 1
        Me.rabtn_Imprimir.Text = "Imprimir"
        Me.rabtn_Imprimir.UseVisualStyleBackColor = True
        '
        'rabtn_Pantalla
        '
        Me.rabtn_Pantalla.AutoSize = True
        Me.rabtn_Pantalla.Checked = True
        Me.rabtn_Pantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rabtn_Pantalla.Location = New System.Drawing.Point(42, 30)
        Me.rabtn_Pantalla.Name = "rabtn_Pantalla"
        Me.rabtn_Pantalla.Size = New System.Drawing.Size(88, 21)
        Me.rabtn_Pantalla.TabIndex = 0
        Me.rabtn_Pantalla.TabStop = True
        Me.rabtn_Pantalla.Text = "Pantalla"
        Me.rabtn_Pantalla.UseVisualStyleBackColor = True
        '
        'Listado_Echeques_UsadosXFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 176)
        Me.Controls.Add(Me.gbx_TipoImpresion)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.gbx_Fechas)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Listado_Echeques_UsadosXFecha"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.gbx_Fechas.ResumeLayout(False)
        Me.gbx_Fechas.PerformLayout()
        Me.gbx_TipoImpresion.ResumeLayout(False)
        Me.gbx_TipoImpresion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents gbx_Fechas As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents gbx_TipoImpresion As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Imprimir As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pantalla As System.Windows.Forms.RadioButton
End Class
