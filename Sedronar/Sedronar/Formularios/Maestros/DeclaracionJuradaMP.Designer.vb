<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeclaracionJuradaMP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.MaskedTextBox()
        Me.txtHasta = New System.Windows.Forms.MaskedTextBox()
        Me.ckLimpia = New System.Windows.Forms.CheckBox()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 54)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DECLARACIÓN JURADA MATERIA PRIMA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckLimpia)
        Me.GroupBox1.Controls.Add(Me.txtHasta)
        Me.GroupBox1.Controls.Add(Me.txtDesde)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 92)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros"
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToResizeColumns = False
        Me.dgvProductos.AllowUserToResizeRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        Me.dgvProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvProductos.Location = New System.Drawing.Point(0, 250)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        Me.dgvProductos.RowHeadersWidth = 15
        Me.dgvProductos.RowTemplate.Height = 18
        Me.dgvProductos.ShowCellToolTips = False
        Me.dgvProductos.Size = New System.Drawing.Size(493, 152)
        Me.dgvProductos.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(27, 163)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(97, 33)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(141, 163)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(97, 33)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar Lista"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(255, 163)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(97, 33)
        Me.btnConsulta.TabIndex = 3
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(369, 163)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(97, 33)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(452, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Desde Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Hasta Fecha:"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(150, 22)
        Me.txtDesde.Mask = "00/00/0000"
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesde.Size = New System.Drawing.Size(68, 20)
        Me.txtDesde.TabIndex = 1
        Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(150, 55)
        Me.txtHasta.Mask = "00/00/0000"
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtHasta.Size = New System.Drawing.Size(68, 20)
        Me.txtHasta.TabIndex = 1
        Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckLimpia
        '
        Me.ckLimpia.AutoSize = True
        Me.ckLimpia.Location = New System.Drawing.Point(261, 24)
        Me.ckLimpia.Name = "ckLimpia"
        Me.ckLimpia.Size = New System.Drawing.Size(140, 17)
        Me.ckLimpia.TabIndex = 2
        Me.ckLimpia.Text = "Limpiar Datos Anteriores"
        Me.ckLimpia.UseVisualStyleBackColor = True
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.MinimumWidth = 100
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Agregar:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(164, 15)
        Me.txtCodigo.Mask = "AA-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(249, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(97, 21)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'DeclaracionJuradaMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 402)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DeclaracionJuradaMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckLimpia As System.Windows.Forms.CheckBox
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
End Class
