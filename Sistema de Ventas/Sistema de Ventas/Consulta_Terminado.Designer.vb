<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_Terminado
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.DGV_Terminado = New Util.DBDataGridView()
        Me.chk_Hasta = New System.Windows.Forms.CheckBox()
        Me.chk_Desde = New System.Windows.Forms.CheckBox()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV_Terminado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Filtro"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(124, 300)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 43)
        Me.btn_Cerrar.TabIndex = 17
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'DGV_Terminado
        '
        Me.DGV_Terminado.AllowUserToAddRows = False
        Me.DGV_Terminado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Terminado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Terminado.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Terminado.DoubleBuffered = True
        Me.DGV_Terminado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Terminado.Location = New System.Drawing.Point(12, 88)
        Me.DGV_Terminado.Name = "DGV_Terminado"
        Me.DGV_Terminado.OrdenamientoColumnasHabilitado = True
        Me.DGV_Terminado.RowHeadersWidth = 15
        Me.DGV_Terminado.RowTemplate.Height = 20
        Me.DGV_Terminado.ShowCellToolTips = False
        Me.DGV_Terminado.SinClickDerecho = False
        Me.DGV_Terminado.Size = New System.Drawing.Size(305, 206)
        Me.DGV_Terminado.TabIndex = 16
        '
        'chk_Hasta
        '
        Me.chk_Hasta.AutoSize = True
        Me.chk_Hasta.Checked = True
        Me.chk_Hasta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Hasta.Location = New System.Drawing.Point(237, 64)
        Me.chk_Hasta.Name = "chk_Hasta"
        Me.chk_Hasta.Size = New System.Drawing.Size(62, 17)
        Me.chk_Hasta.TabIndex = 15
        Me.chk_Hasta.Text = "HASTA"
        Me.chk_Hasta.UseVisualStyleBackColor = True
        '
        'chk_Desde
        '
        Me.chk_Desde.AutoSize = True
        Me.chk_Desde.Checked = True
        Me.chk_Desde.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Desde.Location = New System.Drawing.Point(237, 46)
        Me.chk_Desde.Name = "chk_Desde"
        Me.chk_Desde.Size = New System.Drawing.Size(63, 17)
        Me.chk_Desde.TabIndex = 14
        Me.chk_Desde.Text = "DESDE"
        Me.chk_Desde.UseVisualStyleBackColor = True
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(12, 61)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(219, 20)
        Me.txt_Filtro.TabIndex = 13
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(325, 40)
        Me.panel1.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(170, 9)
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
        Me.Label5.Location = New System.Drawing.Point(3, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Consulta Terminado"
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Consulta_Terminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 345)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_Terminado)
        Me.Controls.Add(Me.chk_Hasta)
        Me.Controls.Add(Me.chk_Desde)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Name = "Consulta_Terminado"
        CType(Me.DGV_Terminado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents DGV_Terminado As Util.DBDataGridView
    Friend WithEvents chk_Hasta As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Desde As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
