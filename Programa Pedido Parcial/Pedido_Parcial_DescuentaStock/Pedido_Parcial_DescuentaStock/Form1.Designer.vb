<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txt_Pedido = New System.Windows.Forms.TextBox()
        Me.txt_Cant_Restar = New System.Windows.Forms.TextBox()
        Me.txt_Partida = New System.Windows.Forms.TextBox()
        Me.txt_Planta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.txt_Producto = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Desc_Cliente = New System.Windows.Forms.TextBox()
        Me.txt_Cantidad_Pendiente = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
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
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(813, 49)
        Me.panel1.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(617, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SURFACTAN S.A."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 11)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Despacho Pedido"
        '
        'txt_Pedido
        '
        Me.txt_Pedido.Location = New System.Drawing.Point(115, 56)
        Me.txt_Pedido.MaxLength = 6
        Me.txt_Pedido.Name = "txt_Pedido"
        Me.txt_Pedido.Size = New System.Drawing.Size(130, 22)
        Me.txt_Pedido.TabIndex = 21
        Me.txt_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Cant_Restar
        '
        Me.txt_Cant_Restar.Location = New System.Drawing.Point(115, 137)
        Me.txt_Cant_Restar.Name = "txt_Cant_Restar"
        Me.txt_Cant_Restar.Size = New System.Drawing.Size(130, 22)
        Me.txt_Cant_Restar.TabIndex = 23
        Me.txt_Cant_Restar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Partida
        '
        Me.txt_Partida.Location = New System.Drawing.Point(115, 177)
        Me.txt_Partida.MaxLength = 6
        Me.txt_Partida.Name = "txt_Partida"
        Me.txt_Partida.Size = New System.Drawing.Size(130, 22)
        Me.txt_Partida.TabIndex = 24
        Me.txt_Partida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Planta
        '
        Me.txt_Planta.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Planta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Planta.Location = New System.Drawing.Point(369, 61)
        Me.txt_Planta.Name = "txt_Planta"
        Me.txt_Planta.ReadOnly = True
        Me.txt_Planta.Size = New System.Drawing.Size(100, 22)
        Me.txt_Planta.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 34)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "  Cantidad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Despachar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Partida"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Planta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(285, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Cliente"
        '
        'txt_Cliente
        '
        Me.txt_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cliente.Location = New System.Drawing.Point(369, 99)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.ReadOnly = True
        Me.txt_Cliente.Size = New System.Drawing.Size(100, 22)
        Me.txt_Cliente.TabIndex = 34
        '
        'txt_Producto
        '
        Me.txt_Producto.Location = New System.Drawing.Point(115, 97)
        Me.txt_Producto.Mask = ">LL-00000-000"
        Me.txt_Producto.Name = "txt_Producto"
        Me.txt_Producto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_Producto.ReadOnly = True
        Me.txt_Producto.Size = New System.Drawing.Size(130, 22)
        Me.txt_Producto.TabIndex = 22
        Me.txt_Producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Desc_Cliente
        '
        Me.txt_Desc_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Desc_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Desc_Cliente.Location = New System.Drawing.Point(477, 99)
        Me.txt_Desc_Cliente.Name = "txt_Desc_Cliente"
        Me.txt_Desc_Cliente.ReadOnly = True
        Me.txt_Desc_Cliente.Size = New System.Drawing.Size(321, 22)
        Me.txt_Desc_Cliente.TabIndex = 35
        '
        'txt_Cantidad_Pendiente
        '
        Me.txt_Cantidad_Pendiente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cantidad_Pendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cantidad_Pendiente.Location = New System.Drawing.Point(369, 143)
        Me.txt_Cantidad_Pendiente.Name = "txt_Cantidad_Pendiente"
        Me.txt_Cantidad_Pendiente.ReadOnly = True
        Me.txt_Cantidad_Pendiente.Size = New System.Drawing.Size(148, 22)
        Me.txt_Cantidad_Pendiente.TabIndex = 38
        Me.txt_Cantidad_Pendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(284, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 34)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = " Cantidad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pendiente"
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(393, 180)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(89, 41)
        Me.btn_Grabar.TabIndex = 39
        Me.btn_Grabar.Text = "Grabar"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(502, 180)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(89, 41)
        Me.btn_Limpiar.TabIndex = 40
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 233)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.txt_Cant_Restar)
        Me.Controls.Add(Me.txt_Cantidad_Pendiente)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_Desc_Cliente)
        Me.Controls.Add(Me.txt_Producto)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Planta)
        Me.Controls.Add(Me.txt_Partida)
        Me.Controls.Add(Me.txt_Pedido)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cant_Restar As System.Windows.Forms.TextBox
    Friend WithEvents txt_Partida As System.Windows.Forms.TextBox
    Friend WithEvents txt_Planta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_Producto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Desc_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cantidad_Pendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button

End Class
