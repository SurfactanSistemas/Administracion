<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncuestaFarma
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvProductos = New ConsultasVarias.DBDataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enviar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.rbIng = New System.Windows.Forms.RadioButton()
        Me.rbEsp = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(587, 48)
        Me.Panel1.TabIndex = 82
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(417, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ENVÍO DE ENCUESTA FARMA"
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.Descripcion, Me.Enviar})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.DoubleBuffered = True
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductos.Location = New System.Drawing.Point(13, 125)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersWidth = 15
        Me.dgvProductos.RowTemplate.Height = 20
        Me.dgvProductos.ShowCellToolTips = False
        Me.dgvProductos.Size = New System.Drawing.Size(561, 236)
        Me.dgvProductos.TabIndex = 83
        '
        'Producto
        '
        Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 75
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Enviar
        '
        Me.Enviar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Enviar.DataPropertyName = "Enviar"
        Me.Enviar.HeaderText = "Enviar"
        Me.Enviar.Name = "Enviar"
        Me.Enviar.Width = 43
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFiltrar)
        Me.GroupBox1.Controls.Add(Me.rbIng)
        Me.GroupBox1.Controls.Add(Me.rbEsp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 69)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(98, 45)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(420, 20)
        Me.txtFiltrar.TabIndex = 2
        '
        'rbIng
        '
        Me.rbIng.AutoSize = True
        Me.rbIng.Location = New System.Drawing.Point(389, 16)
        Me.rbIng.Name = "rbIng"
        Me.rbIng.Size = New System.Drawing.Size(64, 17)
        Me.rbIng.TabIndex = 1
        Me.rbIng.Text = "INGLÉS"
        Me.rbIng.UseVisualStyleBackColor = True
        '
        'rbEsp
        '
        Me.rbEsp.AutoSize = True
        Me.rbEsp.Checked = True
        Me.rbEsp.Location = New System.Drawing.Point(291, 16)
        Me.rbEsp.Name = "rbEsp"
        Me.rbEsp.Size = New System.Drawing.Size(75, 17)
        Me.rbEsp.TabIndex = 1
        Me.rbEsp.TabStop = True
        Me.rbEsp.Text = "ESPAÑOL"
        Me.rbEsp.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "FILTRAR:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(103, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "IDIOMA DE LA ENCUESTA:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 366)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(561, 16)
        Me.ProgressBar1.TabIndex = 85
        '
        'btnEnviar
        '
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Location = New System.Drawing.Point(143, 388)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(147, 39)
        Me.btnEnviar.TabIndex = 86
        Me.btnEnviar.Text = "ENVIAR ENCUESTA(S)"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(296, 388)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(147, 39)
        Me.btnCancelar.TabIndex = 86
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'EncuestaFarma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 433)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EncuestaFarma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EncuestaFarma"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvProductos As ConsultasVarias.DBDataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbIng As System.Windows.Forms.RadioButton
    Friend WithEvents rbEsp As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Enviar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
