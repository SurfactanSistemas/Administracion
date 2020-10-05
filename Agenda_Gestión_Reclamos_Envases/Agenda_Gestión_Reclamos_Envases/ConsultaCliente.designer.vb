<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaCliente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.chk_Desde = New System.Windows.Forms.CheckBox()
        Me.chk_Hasta = New System.Windows.Forms.CheckBox()
        Me.DGV_Cliente = New Util.DBDataGridView()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Razon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Cliente, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(330, 40)
        Me.panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(175, 9)
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
        Me.Label5.Size = New System.Drawing.Size(126, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Consulta Cliente"
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(13, 62)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(219, 20)
        Me.txt_Filtro.TabIndex = 7
        '
        'chk_Desde
        '
        Me.chk_Desde.AutoSize = True
        Me.chk_Desde.Checked = True
        Me.chk_Desde.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Desde.Location = New System.Drawing.Point(238, 47)
        Me.chk_Desde.Name = "chk_Desde"
        Me.chk_Desde.Size = New System.Drawing.Size(63, 17)
        Me.chk_Desde.TabIndex = 8
        Me.chk_Desde.Text = "DESDE"
        Me.chk_Desde.UseVisualStyleBackColor = True
        '
        'chk_Hasta
        '
        Me.chk_Hasta.AutoSize = True
        Me.chk_Hasta.Checked = True
        Me.chk_Hasta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Hasta.Location = New System.Drawing.Point(238, 65)
        Me.chk_Hasta.Name = "chk_Hasta"
        Me.chk_Hasta.Size = New System.Drawing.Size(62, 17)
        Me.chk_Hasta.TabIndex = 9
        Me.chk_Hasta.Text = "HASTA"
        Me.chk_Hasta.UseVisualStyleBackColor = True
        '
        'DGV_Cliente
        '
        Me.DGV_Cliente.AllowUserToAddRows = False
        Me.DGV_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Cliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cliente, Me.Razon})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Cliente.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Cliente.DoubleBuffered = True
        Me.DGV_Cliente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Cliente.Location = New System.Drawing.Point(13, 89)
        Me.DGV_Cliente.Name = "DGV_Cliente"
        Me.DGV_Cliente.OrdenamientoColumnasHabilitado = True
        Me.DGV_Cliente.RowHeadersWidth = 15
        Me.DGV_Cliente.RowTemplate.Height = 20
        Me.DGV_Cliente.ShowCellToolTips = False
        Me.DGV_Cliente.SinClickDerecho = False
        Me.DGV_Cliente.Size = New System.Drawing.Size(305, 206)
        Me.DGV_Cliente.TabIndex = 10
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Codigo"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 65
        '
        'Razon
        '
        Me.Razon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Razon.DataPropertyName = "Razon"
        Me.Razon.HeaderText = "Razon"
        Me.Razon.Name = "Razon"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Filtro"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(125, 301)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 43)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'ConsultaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 356)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_Cliente)
        Me.Controls.Add(Me.chk_Hasta)
        Me.Controls.Add(Me.chk_Desde)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.panel1)
        Me.Name = "ConsultaCliente"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Cliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents chk_Desde As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Hasta As System.Windows.Forms.CheckBox
    Friend WithEvents DGV_Cliente As Util.DBDataGridView
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Razon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
End Class