<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutorizacionDePedidos
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_DesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txt_HastaFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_LeeDatos = New System.Windows.Forms.Button()
        Me.btn_Graba = New System.Windows.Forms.Button()
        Me.btn_Autorizo = New System.Windows.Forms.Button()
        Me.btn_CERRAR = New System.Windows.Forms.Button()
        Me.btn_AnulaPedido = New System.Windows.Forms.Button()
        Me.DGV_Pedidos = New Util.DBDataGridView()
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Impresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auxiliar1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auxiliar2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(869, 40)
        Me.panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(693, 10)
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
        Me.Label5.Size = New System.Drawing.Size(184, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Autorizacion de Pedidos"
        '
        'txt_DesdeFecha
        '
        Me.txt_DesdeFecha.Location = New System.Drawing.Point(93, 47)
        Me.txt_DesdeFecha.Mask = "00/00/0000"
        Me.txt_DesdeFecha.Name = "txt_DesdeFecha"
        Me.txt_DesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_DesdeFecha.Size = New System.Drawing.Size(64, 20)
        Me.txt_DesdeFecha.TabIndex = 7
        '
        'txt_HastaFecha
        '
        Me.txt_HastaFecha.Location = New System.Drawing.Point(93, 73)
        Me.txt_HastaFecha.Mask = "00/00/0000"
        Me.txt_HastaFecha.Name = "txt_HastaFecha"
        Me.txt_HastaFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txt_HastaFecha.Size = New System.Drawing.Size(64, 20)
        Me.txt_HastaFecha.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Desde Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hasta Fecha"
        '
        'btn_LeeDatos
        '
        Me.btn_LeeDatos.Location = New System.Drawing.Point(250, 46)
        Me.btn_LeeDatos.Name = "btn_LeeDatos"
        Me.btn_LeeDatos.Size = New System.Drawing.Size(75, 43)
        Me.btn_LeeDatos.TabIndex = 12
        Me.btn_LeeDatos.Text = "LEE DATOS"
        Me.btn_LeeDatos.UseVisualStyleBackColor = True
        '
        'btn_Graba
        '
        Me.btn_Graba.Location = New System.Drawing.Point(331, 46)
        Me.btn_Graba.Name = "btn_Graba"
        Me.btn_Graba.Size = New System.Drawing.Size(75, 43)
        Me.btn_Graba.TabIndex = 13
        Me.btn_Graba.Text = "GRABA"
        Me.btn_Graba.UseVisualStyleBackColor = True
        '
        'btn_Autorizo
        '
        Me.btn_Autorizo.Location = New System.Drawing.Point(412, 47)
        Me.btn_Autorizo.Name = "btn_Autorizo"
        Me.btn_Autorizo.Size = New System.Drawing.Size(75, 43)
        Me.btn_Autorizo.TabIndex = 14
        Me.btn_Autorizo.Text = "AUTORIZO"
        Me.btn_Autorizo.UseVisualStyleBackColor = True
        '
        'btn_CERRAR
        '
        Me.btn_CERRAR.Location = New System.Drawing.Point(493, 47)
        Me.btn_CERRAR.Name = "btn_CERRAR"
        Me.btn_CERRAR.Size = New System.Drawing.Size(75, 43)
        Me.btn_CERRAR.TabIndex = 15
        Me.btn_CERRAR.Text = "CERRAR"
        Me.btn_CERRAR.UseVisualStyleBackColor = True
        '
        'btn_AnulaPedido
        '
        Me.btn_AnulaPedido.Location = New System.Drawing.Point(574, 47)
        Me.btn_AnulaPedido.Name = "btn_AnulaPedido"
        Me.btn_AnulaPedido.Size = New System.Drawing.Size(75, 43)
        Me.btn_AnulaPedido.TabIndex = 16
        Me.btn_AnulaPedido.Text = "ANULA PEDIDO"
        Me.btn_AnulaPedido.UseVisualStyleBackColor = True
        '
        'DGV_Pedidos
        '
        Me.DGV_Pedidos.AllowUserToAddRows = False
        Me.DGV_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pedido, Me.Fecha, Me.Cliente, Me.Razon, Me.FEntrega, Me.Tipo, Me.Importe, Me.Estado, Me.Impresa, Me.Auxiliar1, Me.Auxiliar2, Me.Clave})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Pedidos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Pedidos.DoubleBuffered = True
        Me.DGV_Pedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Pedidos.Location = New System.Drawing.Point(12, 99)
        Me.DGV_Pedidos.Name = "DGV_Pedidos"
        Me.DGV_Pedidos.OrdenamientoColumnasHabilitado = True
        Me.DGV_Pedidos.RowHeadersWidth = 15
        Me.DGV_Pedidos.RowTemplate.Height = 20
        Me.DGV_Pedidos.ShowCellToolTips = False
        Me.DGV_Pedidos.SinClickDerecho = False
        Me.DGV_Pedidos.Size = New System.Drawing.Size(845, 334)
        Me.DGV_Pedidos.TabIndex = 9
        '
        'Pedido
        '
        Me.Pedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Pedido.DataPropertyName = "Pedido"
        Me.Pedido.HeaderText = "Pedido"
        Me.Pedido.Name = "Pedido"
        Me.Pedido.ReadOnly = True
        Me.Pedido.Width = 65
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 64
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.DataPropertyName = "Razon"
        Me.Razon.HeaderText = "Razon Social"
        Me.Razon.Name = "Razon"
        Me.Razon.ReadOnly = True
        '
        'FEntrega
        '
        Me.FEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FEntrega.DataPropertyName = "FEntrega"
        Me.FEntrega.HeaderText = "F.Entrega"
        Me.FEntrega.Name = "FEntrega"
        Me.FEntrega.ReadOnly = True
        Me.FEntrega.Width = 78
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 53
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 67
        '
        'Estado
        '
        Me.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Impresa
        '
        Me.Impresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Impresa.DataPropertyName = "Impresa"
        Me.Impresa.HeaderText = "Impresa"
        Me.Impresa.Name = "Impresa"
        Me.Impresa.ReadOnly = True
        Me.Impresa.Width = 69
        '
        'Auxiliar1
        '
        Me.Auxiliar1.DataPropertyName = "Auxiliar1"
        Me.Auxiliar1.HeaderText = "Auxiliar1"
        Me.Auxiliar1.Name = "Auxiliar1"
        Me.Auxiliar1.Visible = False
        '
        'Auxiliar2
        '
        Me.Auxiliar2.DataPropertyName = "Auxiliar2"
        Me.Auxiliar2.HeaderText = "Auxiliar2"
        Me.Auxiliar2.Name = "Auxiliar2"
        Me.Auxiliar2.Visible = False
        '
        'Clave
        '
        Me.Clave.DataPropertyName = "Clave"
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'AutorizacionDePedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 445)
        Me.Controls.Add(Me.btn_AnulaPedido)
        Me.Controls.Add(Me.btn_CERRAR)
        Me.Controls.Add(Me.btn_Autorizo)
        Me.Controls.Add(Me.btn_Graba)
        Me.Controls.Add(Me.btn_LeeDatos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_Pedidos)
        Me.Controls.Add(Me.txt_HastaFecha)
        Me.Controls.Add(Me.txt_DesdeFecha)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "AutorizacionDePedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_DesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_HastaFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DGV_Pedidos As Util.DBDataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_LeeDatos As System.Windows.Forms.Button
    Friend WithEvents btn_Graba As System.Windows.Forms.Button
    Friend WithEvents btn_Autorizo As System.Windows.Forms.Button
    Friend WithEvents btn_CERRAR As System.Windows.Forms.Button
    Friend WithEvents btn_AnulaPedido As System.Windows.Forms.Button
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Impresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Auxiliar1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Auxiliar2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
