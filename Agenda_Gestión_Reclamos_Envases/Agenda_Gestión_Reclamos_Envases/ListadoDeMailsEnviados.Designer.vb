<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoDeMailsEnviados
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DGV_Mails = New Util.DBDataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_ClienteDes = New System.Windows.Forms.TextBox()
        Me.txt_Cliente = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Asunto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Mails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(434, 50)
        Me.panel1.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(279, 30)
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
        Me.label1.Size = New System.Drawing.Size(197, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Listado de Mails Enviados"
        '
        'DGV_Mails
        '
        Me.DGV_Mails.AllowUserToAddRows = False
        Me.DGV_Mails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Mails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Fecha, Me.FechaOrd, Me.Asunto})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Mails.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Mails.DoubleBuffered = True
        Me.DGV_Mails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Mails.Location = New System.Drawing.Point(6, 82)
        Me.DGV_Mails.Name = "DGV_Mails"
        Me.DGV_Mails.OrdenamientoColumnasHabilitado = True
        Me.DGV_Mails.RowHeadersWidth = 15
        Me.DGV_Mails.RowTemplate.Height = 20
        Me.DGV_Mails.ShowCellToolTips = False
        Me.DGV_Mails.SinClickDerecho = False
        Me.DGV_Mails.Size = New System.Drawing.Size(424, 184)
        Me.DGV_Mails.TabIndex = 134
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Cliente"
        '
        'txt_ClienteDes
        '
        Me.txt_ClienteDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ClienteDes.Location = New System.Drawing.Point(120, 56)
        Me.txt_ClienteDes.Name = "txt_ClienteDes"
        Me.txt_ClienteDes.ReadOnly = True
        Me.txt_ClienteDes.Size = New System.Drawing.Size(308, 20)
        Me.txt_ClienteDes.TabIndex = 140
        '
        'txt_Cliente
        '
        Me.txt_Cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Cliente.Location = New System.Drawing.Point(59, 56)
        Me.txt_Cliente.Name = "txt_Cliente"
        Me.txt_Cliente.ReadOnly = True
        Me.txt_Cliente.Size = New System.Drawing.Size(55, 20)
        Me.txt_Cliente.TabIndex = 139
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(175, 271)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 36)
        Me.btn_Cerrar.TabIndex = 142
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
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
        'FechaOrd
        '
        Me.FechaOrd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FechaOrd.DataPropertyName = "FechaOrd"
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.ReadOnly = True
        Me.FechaOrd.Visible = False
        '
        'Asunto
        '
        Me.Asunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Asunto.DataPropertyName = "Asunto"
        Me.Asunto.HeaderText = "Asunto"
        Me.Asunto.Name = "Asunto"
        '
        'ListadoDeMailsEnviados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 313)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_ClienteDes)
        Me.Controls.Add(Me.txt_Cliente)
        Me.Controls.Add(Me.DGV_Mails)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ListadoDeMailsEnviados"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Mails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Mails As Util.DBDataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_ClienteDes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Asunto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
