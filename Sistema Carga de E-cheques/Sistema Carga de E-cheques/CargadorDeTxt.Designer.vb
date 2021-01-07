<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargadorDeTxt
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txt_Archivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_ObtenerDatos = New System.Windows.Forms.Button()
        Me.dgv_Cheques = New Util.DBDataGridView()
        Me.chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_Cheques, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(817, 40)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(641, 10)
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
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(182, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "CARGA DE E-CHEQUES"
        '
        'txt_Archivo
        '
        Me.txt_Archivo.Location = New System.Drawing.Point(78, 52)
        Me.txt_Archivo.Name = "txt_Archivo"
        Me.txt_Archivo.Size = New System.Drawing.Size(181, 20)
        Me.txt_Archivo.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ruta archivo"
        '
        'btn_ObtenerDatos
        '
        Me.btn_ObtenerDatos.Location = New System.Drawing.Point(266, 43)
        Me.btn_ObtenerDatos.Name = "btn_ObtenerDatos"
        Me.btn_ObtenerDatos.Size = New System.Drawing.Size(105, 37)
        Me.btn_ObtenerDatos.TabIndex = 10
        Me.btn_ObtenerDatos.Text = "Obtener Cheques de Archivo"
        Me.btn_ObtenerDatos.UseVisualStyleBackColor = True
        '
        'dgv_Cheques
        '
        Me.dgv_Cheques.AllowUserToAddRows = False
        Me.dgv_Cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Cheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chk})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Cheques.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Cheques.DoubleBuffered = True
        Me.dgv_Cheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Cheques.Location = New System.Drawing.Point(7, 86)
        Me.dgv_Cheques.Name = "dgv_Cheques"
        Me.dgv_Cheques.OrdenamientoColumnasHabilitado = True
        Me.dgv_Cheques.RowHeadersWidth = 15
        Me.dgv_Cheques.RowTemplate.Height = 20
        Me.dgv_Cheques.ShowCellToolTips = False
        Me.dgv_Cheques.SinClickDerecho = False
        Me.dgv_Cheques.Size = New System.Drawing.Size(804, 271)
        Me.dgv_Cheques.TabIndex = 9
        '
        'chk
        '
        Me.chk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.chk.DataPropertyName = "chk"
        Me.chk.HeaderText = "chk"
        Me.chk.Name = "chk"
        Me.chk.Width = 31
        '
        'CargadorDeTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 361)
        Me.Controls.Add(Me.btn_ObtenerDatos)
        Me.Controls.Add(Me.dgv_Cheques)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Archivo)
        Me.Controls.Add(Me.panel1)
        Me.Name = "CargadorDeTxt"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_Cheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Archivo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_Cheques As Util.DBDataGridView
    Friend WithEvents btn_ObtenerDatos As System.Windows.Forms.Button
    Friend WithEvents chk As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
