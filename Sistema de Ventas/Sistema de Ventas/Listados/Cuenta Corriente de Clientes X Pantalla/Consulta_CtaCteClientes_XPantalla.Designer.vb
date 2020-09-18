<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_CtaCteClientes_XPantalla
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.txt_ClienteDes = New System.Windows.Forms.TextBox()
        Me.txt_Saldo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Dolares = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pesos = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rabtn_TotalDatos = New System.Windows.Forms.RadioButton()
        Me.rabtn_Pendiente = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rabtn_Total = New System.Windows.Forms.RadioButton()
        Me.rabtn_Documentos = New System.Windows.Forms.RadioButton()
        Me.rabtn_CtaCte = New System.Windows.Forms.RadioButton()
        Me.chk_Ultimos5 = New System.Windows.Forms.CheckBox()
        Me.chk_RevertirOrd = New System.Windows.Forms.CheckBox()
        Me.btn_DatosClientes = New System.Windows.Forms.Button()
        Me.btn_Reclamos = New System.Windows.Forms.Button()
        Me.btn_ConsultaCliente = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Listar = New System.Windows.Forms.Button()
        Me.DGV_CtaCte = New Util.DBDataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VencimientoII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acumulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV_CtaCte, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(772, 50)
        Me.panel1.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(617, 30)
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
        Me.label1.Size = New System.Drawing.Size(313, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Consulta de Cuenta Corriente de Clientes "
        '
        'txt_Cliente
        '
        Me.txt_Cliente.Location = New System.Drawing.Point(56, 56)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.Size = New System.Drawing.Size(100, 20)
        Me.txt_Cliente.TabIndex = 39
        '
        'txt_ClienteDes
        '
        Me.txt_ClienteDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ClienteDes.Location = New System.Drawing.Point(162, 56)
        Me.txt_ClienteDes.Name = "txt_ClienteDes"
        Me.txt_ClienteDes.ReadOnly = True
        Me.txt_ClienteDes.Size = New System.Drawing.Size(257, 20)
        Me.txt_ClienteDes.TabIndex = 40
        '
        'txt_Saldo
        '
        Me.txt_Saldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Saldo.Location = New System.Drawing.Point(56, 82)
        Me.txt_Saldo.Name = "txt_Saldo"
        Me.txt_Saldo.ReadOnly = True
        Me.txt_Saldo.Size = New System.Drawing.Size(100, 20)
        Me.txt_Saldo.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Saldo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rabtn_Dolares)
        Me.GroupBox1.Controls.Add(Me.rabtn_Pesos)
        Me.GroupBox1.Location = New System.Drawing.Point(181, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 58)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Moneda"
        '
        'rabtn_Dolares
        '
        Me.rabtn_Dolares.AutoSize = True
        Me.rabtn_Dolares.Location = New System.Drawing.Point(7, 35)
        Me.rabtn_Dolares.Name = "rabtn_Dolares"
        Me.rabtn_Dolares.Size = New System.Drawing.Size(61, 17)
        Me.rabtn_Dolares.TabIndex = 1
        Me.rabtn_Dolares.Text = "Dolares"
        Me.rabtn_Dolares.UseVisualStyleBackColor = True
        '
        'rabtn_Pesos
        '
        Me.rabtn_Pesos.AutoSize = True
        Me.rabtn_Pesos.Checked = True
        Me.rabtn_Pesos.Location = New System.Drawing.Point(7, 19)
        Me.rabtn_Pesos.Name = "rabtn_Pesos"
        Me.rabtn_Pesos.Size = New System.Drawing.Size(54, 17)
        Me.rabtn_Pesos.TabIndex = 0
        Me.rabtn_Pesos.TabStop = True
        Me.rabtn_Pesos.Text = "Pesos"
        Me.rabtn_Pesos.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rabtn_TotalDatos)
        Me.GroupBox2.Controls.Add(Me.rabtn_Pendiente)
        Me.GroupBox2.Location = New System.Drawing.Point(318, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 58)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Datos"
        '
        'rabtn_TotalDatos
        '
        Me.rabtn_TotalDatos.AutoSize = True
        Me.rabtn_TotalDatos.Location = New System.Drawing.Point(6, 35)
        Me.rabtn_TotalDatos.Name = "rabtn_TotalDatos"
        Me.rabtn_TotalDatos.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_TotalDatos.TabIndex = 3
        Me.rabtn_TotalDatos.Text = "Total"
        Me.rabtn_TotalDatos.UseVisualStyleBackColor = True
        '
        'rabtn_Pendiente
        '
        Me.rabtn_Pendiente.AutoSize = True
        Me.rabtn_Pendiente.Checked = True
        Me.rabtn_Pendiente.Location = New System.Drawing.Point(6, 19)
        Me.rabtn_Pendiente.Name = "rabtn_Pendiente"
        Me.rabtn_Pendiente.Size = New System.Drawing.Size(73, 17)
        Me.rabtn_Pendiente.TabIndex = 2
        Me.rabtn_Pendiente.TabStop = True
        Me.rabtn_Pendiente.Text = "Pendiente"
        Me.rabtn_Pendiente.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rabtn_Total)
        Me.GroupBox3.Controls.Add(Me.rabtn_Documentos)
        Me.GroupBox3.Controls.Add(Me.rabtn_CtaCte)
        Me.GroupBox3.Location = New System.Drawing.Point(445, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(117, 62)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Listado"
        '
        'rabtn_Total
        '
        Me.rabtn_Total.AutoSize = True
        Me.rabtn_Total.Location = New System.Drawing.Point(6, 45)
        Me.rabtn_Total.Name = "rabtn_Total"
        Me.rabtn_Total.Size = New System.Drawing.Size(49, 17)
        Me.rabtn_Total.TabIndex = 4
        Me.rabtn_Total.Text = "Total"
        Me.rabtn_Total.UseVisualStyleBackColor = True
        '
        'rabtn_Documentos
        '
        Me.rabtn_Documentos.AutoSize = True
        Me.rabtn_Documentos.Location = New System.Drawing.Point(6, 28)
        Me.rabtn_Documentos.Name = "rabtn_Documentos"
        Me.rabtn_Documentos.Size = New System.Drawing.Size(85, 17)
        Me.rabtn_Documentos.TabIndex = 3
        Me.rabtn_Documentos.Text = "Documentos"
        Me.rabtn_Documentos.UseVisualStyleBackColor = True
        '
        'rabtn_CtaCte
        '
        Me.rabtn_CtaCte.AutoSize = True
        Me.rabtn_CtaCte.Checked = True
        Me.rabtn_CtaCte.Location = New System.Drawing.Point(6, 12)
        Me.rabtn_CtaCte.Name = "rabtn_CtaCte"
        Me.rabtn_CtaCte.Size = New System.Drawing.Size(66, 17)
        Me.rabtn_CtaCte.TabIndex = 2
        Me.rabtn_CtaCte.TabStop = True
        Me.rabtn_CtaCte.Text = "Cta. Cte."
        Me.rabtn_CtaCte.UseVisualStyleBackColor = True
        '
        'chk_Ultimos5
        '
        Me.chk_Ultimos5.AutoSize = True
        Me.chk_Ultimos5.Checked = True
        Me.chk_Ultimos5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Ultimos5.Location = New System.Drawing.Point(569, 56)
        Me.chk_Ultimos5.Name = "chk_Ultimos5"
        Me.chk_Ultimos5.Size = New System.Drawing.Size(96, 17)
        Me.chk_Ultimos5.TabIndex = 47
        Me.chk_Ultimos5.Text = "Ultimos 5 Años"
        Me.chk_Ultimos5.UseVisualStyleBackColor = True
        '
        'chk_RevertirOrd
        '
        Me.chk_RevertirOrd.AutoSize = True
        Me.chk_RevertirOrd.Location = New System.Drawing.Point(665, 55)
        Me.chk_RevertirOrd.Name = "chk_RevertirOrd"
        Me.chk_RevertirOrd.Size = New System.Drawing.Size(95, 17)
        Me.chk_RevertirOrd.TabIndex = 48
        Me.chk_RevertirOrd.Text = "Revertir Orden"
        Me.chk_RevertirOrd.UseVisualStyleBackColor = True
        '
        'btn_DatosClientes
        '
        Me.btn_DatosClientes.Location = New System.Drawing.Point(589, 71)
        Me.btn_DatosClientes.Name = "btn_DatosClientes"
        Me.btn_DatosClientes.Size = New System.Drawing.Size(75, 40)
        Me.btn_DatosClientes.TabIndex = 49
        Me.btn_DatosClientes.Text = "DATOS DE CLIENTE"
        Me.btn_DatosClientes.UseVisualStyleBackColor = True
        '
        'btn_Reclamos
        '
        Me.btn_Reclamos.Location = New System.Drawing.Point(669, 71)
        Me.btn_Reclamos.Name = "btn_Reclamos"
        Me.btn_Reclamos.Size = New System.Drawing.Size(75, 40)
        Me.btn_Reclamos.TabIndex = 50
        Me.btn_Reclamos.Text = "RECLAMOS"
        Me.btn_Reclamos.UseVisualStyleBackColor = True
        '
        'btn_ConsultaCliente
        '
        Me.btn_ConsultaCliente.Location = New System.Drawing.Point(24, 108)
        Me.btn_ConsultaCliente.Name = "btn_ConsultaCliente"
        Me.btn_ConsultaCliente.Size = New System.Drawing.Size(129, 31)
        Me.btn_ConsultaCliente.TabIndex = 51
        Me.btn_ConsultaCliente.Text = "CONSULTA CLIENTE"
        Me.btn_ConsultaCliente.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(669, 111)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 40)
        Me.btn_Cerrar.TabIndex = 52
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Listar
        '
        Me.btn_Listar.Location = New System.Drawing.Point(589, 111)
        Me.btn_Listar.Name = "btn_Listar"
        Me.btn_Listar.Size = New System.Drawing.Size(75, 40)
        Me.btn_Listar.TabIndex = 53
        Me.btn_Listar.Text = "LISTAR"
        Me.btn_Listar.UseVisualStyleBackColor = True
        '
        'DGV_CtaCte
        '
        Me.DGV_CtaCte.AllowUserToAddRows = False
        Me.DGV_CtaCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_CtaCte.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Numero, Me.Fecha, Me.Debito, Me.Credito, Me.Saldo, Me.Vencimiento, Me.VencimientoII, Me.Acumulado})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_CtaCte.DefaultCellStyle = DataGridViewCellStyle18
        Me.DGV_CtaCte.DoubleBuffered = True
        Me.DGV_CtaCte.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_CtaCte.Location = New System.Drawing.Point(14, 153)
        Me.DGV_CtaCte.Name = "DGV_CtaCte"
        Me.DGV_CtaCte.OrdenamientoColumnasHabilitado = True
        Me.DGV_CtaCte.RowHeadersWidth = 15
        Me.DGV_CtaCte.RowTemplate.Height = 20
        Me.DGV_CtaCte.ShowCellToolTips = False
        Me.DGV_CtaCte.SinClickDerecho = False
        Me.DGV_CtaCte.Size = New System.Drawing.Size(746, 282)
        Me.DGV_CtaCte.TabIndex = 44
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 53
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle13
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 69
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'Debito
        '
        Me.Debito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Debito.DefaultCellStyle = DataGridViewCellStyle14
        Me.Debito.HeaderText = "Debito"
        Me.Debito.Name = "Debito"
        Me.Debito.ReadOnly = True
        Me.Debito.Width = 63
        '
        'Credito
        '
        Me.Credito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Credito.DefaultCellStyle = DataGridViewCellStyle15
        Me.Credito.HeaderText = "Credito"
        Me.Credito.Name = "Credito"
        Me.Credito.ReadOnly = True
        Me.Credito.Width = 65
        '
        'Saldo
        '
        Me.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle16
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        Me.Saldo.Width = 59
        '
        'Vencimiento
        '
        Me.Vencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        Me.Vencimiento.Width = 90
        '
        'VencimientoII
        '
        Me.VencimientoII.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.VencimientoII.HeaderText = "VencimientoII"
        Me.VencimientoII.Name = "VencimientoII"
        Me.VencimientoII.ReadOnly = True
        Me.VencimientoII.Width = 96
        '
        'Acumulado
        '
        Me.Acumulado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Acumulado.DefaultCellStyle = DataGridViewCellStyle17
        Me.Acumulado.HeaderText = "Acumulado"
        Me.Acumulado.Name = "Acumulado"
        Me.Acumulado.ReadOnly = True
        Me.Acumulado.Width = 85
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 120)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 27)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "LEE DATOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Consulta_CtaCteClientes_XPantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 440)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Listar)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_ConsultaCliente)
        Me.Controls.Add(Me.btn_Reclamos)
        Me.Controls.Add(Me.btn_DatosClientes)
        Me.Controls.Add(Me.chk_RevertirOrd)
        Me.Controls.Add(Me.chk_Ultimos5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGV_CtaCte)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Saldo)
        Me.Controls.Add(Me.txt_ClienteDes)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Consulta_CtaCteClientes_XPantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGV_CtaCte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_ClienteDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Saldo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGV_CtaCte As Util.DBDataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Dolares As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pesos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_TotalDatos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Pendiente As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rabtn_Total As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_Documentos As System.Windows.Forms.RadioButton
    Friend WithEvents rabtn_CtaCte As System.Windows.Forms.RadioButton
    Friend WithEvents chk_Ultimos5 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_RevertirOrd As System.Windows.Forms.CheckBox
    Friend WithEvents btn_DatosClientes As System.Windows.Forms.Button
    Friend WithEvents btn_Reclamos As System.Windows.Forms.Button
    Friend WithEvents btn_ConsultaCliente As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Listar As System.Windows.Forms.Button
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VencimientoII As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acumulado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
