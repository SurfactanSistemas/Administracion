<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventana_Boton_Autorizo
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
        Me.txt_VtoOriginal = New System.Windows.Forms.MaskedTextBox()
        Me.txt_VtoNuevo = New System.Windows.Forms.MaskedTextBox()
        Me.txt_TipoPedido = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbx_Concepto = New System.Windows.Forms.ComboBox()
        Me.txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.Pnl_Devol = New System.Windows.Forms.Panel()
        Me.rabtn_Opcion3 = New System.Windows.Forms.RadioButton()
        Me.rabtn_Opcion2 = New System.Windows.Forms.RadioButton()
        Me.rabtn_Opcion1 = New System.Windows.Forms.RadioButton()
        Me.btn_Confirmar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.Pnl_Devol.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(386, 40)
        Me.panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(210, 10)
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
        Me.Label5.Location = New System.Drawing.Point(21, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Autorizar Pedido"
        '
        'txt_VtoOriginal
        '
        Me.txt_VtoOriginal.Location = New System.Drawing.Point(115, 67)
        Me.txt_VtoOriginal.Mask = "00/00/0000"
        Me.txt_VtoOriginal.Name = "txt_VtoOriginal"
        Me.txt_VtoOriginal.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoOriginal.ReadOnly = True
        Me.txt_VtoOriginal.Size = New System.Drawing.Size(64, 20)
        Me.txt_VtoOriginal.TabIndex = 8
        '
        'txt_VtoNuevo
        '
        Me.txt_VtoNuevo.Location = New System.Drawing.Point(115, 104)
        Me.txt_VtoNuevo.Mask = "00/00/0000"
        Me.txt_VtoNuevo.Name = "txt_VtoNuevo"
        Me.txt_VtoNuevo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_VtoNuevo.Size = New System.Drawing.Size(64, 20)
        Me.txt_VtoNuevo.TabIndex = 9
        '
        'txt_TipoPedido
        '
        Me.txt_TipoPedido.Location = New System.Drawing.Point(275, 67)
        Me.txt_TipoPedido.Name = "txt_TipoPedido"
        Me.txt_TipoPedido.ReadOnly = True
        Me.txt_TipoPedido.Size = New System.Drawing.Size(100, 20)
        Me.txt_TipoPedido.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fecha Vto. Original"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Nueva Fecha Vto."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tipo Pedido"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Concepto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Observaciones"
        '
        'cbx_Concepto
        '
        Me.cbx_Concepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Concepto.FormattingEnabled = True
        Me.cbx_Concepto.Items.AddRange(New Object() {"", "Falta M.P. Local", "Falta M.P. Importada", "Cambio de Prioridades", "Falta de Capacidad Disponible", "Error del Sistema", "Varios", "Problemas Vehiculos", "Problemas Logistica", "Problemas Recepcion Cliente", "Varios", "Corte de luz", "Pedido por el Cliente", "Falta de Pago", "Confirmacion Pedido Parcial", "Envase"})
        Me.cbx_Concepto.Location = New System.Drawing.Point(115, 151)
        Me.cbx_Concepto.Name = "cbx_Concepto"
        Me.cbx_Concepto.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Concepto.TabIndex = 16
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.Location = New System.Drawing.Point(115, 194)
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.Size = New System.Drawing.Size(100, 20)
        Me.txt_Observaciones.TabIndex = 17
        '
        'Pnl_Devol
        '
        Me.Pnl_Devol.Controls.Add(Me.rabtn_Opcion3)
        Me.Pnl_Devol.Controls.Add(Me.rabtn_Opcion2)
        Me.Pnl_Devol.Controls.Add(Me.rabtn_Opcion1)
        Me.Pnl_Devol.Location = New System.Drawing.Point(12, 51)
        Me.Pnl_Devol.Name = "Pnl_Devol"
        Me.Pnl_Devol.Size = New System.Drawing.Size(363, 163)
        Me.Pnl_Devol.TabIndex = 18
        Me.Pnl_Devol.Visible = False
        '
        'rabtn_Opcion3
        '
        Me.rabtn_Opcion3.AutoSize = True
        Me.rabtn_Opcion3.Location = New System.Drawing.Point(101, 99)
        Me.rabtn_Opcion3.Name = "rabtn_Opcion3"
        Me.rabtn_Opcion3.Size = New System.Drawing.Size(191, 17)
        Me.rabtn_Opcion3.TabIndex = 2
        Me.rabtn_Opcion3.Text = "Bloquea Partida Entregada y Stock"
        Me.rabtn_Opcion3.UseVisualStyleBackColor = True
        '
        'rabtn_Opcion2
        '
        Me.rabtn_Opcion2.AutoSize = True
        Me.rabtn_Opcion2.Location = New System.Drawing.Point(101, 58)
        Me.rabtn_Opcion2.Name = "rabtn_Opcion2"
        Me.rabtn_Opcion2.Size = New System.Drawing.Size(176, 17)
        Me.rabtn_Opcion2.TabIndex = 1
        Me.rabtn_Opcion2.Text = "Bloquea Solo Partida Entregada"
        Me.rabtn_Opcion2.UseVisualStyleBackColor = True
        '
        'rabtn_Opcion1
        '
        Me.rabtn_Opcion1.AutoSize = True
        Me.rabtn_Opcion1.Checked = True
        Me.rabtn_Opcion1.Location = New System.Drawing.Point(101, 19)
        Me.rabtn_Opcion1.Name = "rabtn_Opcion1"
        Me.rabtn_Opcion1.Size = New System.Drawing.Size(159, 17)
        Me.rabtn_Opcion1.TabIndex = 0
        Me.rabtn_Opcion1.TabStop = True
        Me.rabtn_Opcion1.Text = "No Bloquea Partida ni Stock"
        Me.rabtn_Opcion1.UseVisualStyleBackColor = True
        '
        'btn_Confirmar
        '
        Me.btn_Confirmar.Location = New System.Drawing.Point(145, 220)
        Me.btn_Confirmar.Name = "btn_Confirmar"
        Me.btn_Confirmar.Size = New System.Drawing.Size(86, 41)
        Me.btn_Confirmar.TabIndex = 19
        Me.btn_Confirmar.Text = "CONFIRMAR"
        Me.btn_Confirmar.UseVisualStyleBackColor = True
        '
        'Ventana_Boton_Autorizo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 273)
        Me.Controls.Add(Me.btn_Confirmar)
        Me.Controls.Add(Me.Pnl_Devol)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.cbx_Concepto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_TipoPedido)
        Me.Controls.Add(Me.txt_VtoNuevo)
        Me.Controls.Add(Me.txt_VtoOriginal)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Ventana_Boton_Autorizo"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.Pnl_Devol.ResumeLayout(False)
        Me.Pnl_Devol.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_VtoOriginal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_VtoNuevo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_TipoPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbx_Concepto As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Devol As System.Windows.Forms.Panel
    Friend WithEvents rabtn_Opcion3 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Opcion2 As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Opcion1 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Confirmar As System.Windows.Forms.Button
End Class
