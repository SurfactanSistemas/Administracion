<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvasesEquivEnArticulo
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNomEnvases = New System.Windows.Forms.TextBox()
        Me.txtNroEnvases = New System.Windows.Forms.TextBox()
        Me.DGV_EnvasesEnArticulo = New Util.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_EnvasesEnArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(429, 61)
        Me.Panel1.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(271, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(152, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Envases en Articulo"
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(11, 121)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(405, 20)
        Me.txtBuscador.TabIndex = 29
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(8, 105)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(52, 13)
        Me.label5.TabIndex = 28
        Me.label5.Text = "Buscador"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Nombre Envase"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Nro. Env."
        '
        'txtNomEnvases
        '
        Me.txtNomEnvases.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNomEnvases.ForeColor = System.Drawing.SystemColors.Control
        Me.txtNomEnvases.Location = New System.Drawing.Point(71, 79)
        Me.txtNomEnvases.Name = "txtNomEnvases"
        Me.txtNomEnvases.ReadOnly = True
        Me.txtNomEnvases.Size = New System.Drawing.Size(222, 20)
        Me.txtNomEnvases.TabIndex = 25
        '
        'txtNroEnvases
        '
        Me.txtNroEnvases.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNroEnvases.ForeColor = System.Drawing.SystemColors.Control
        Me.txtNroEnvases.Location = New System.Drawing.Point(11, 79)
        Me.txtNroEnvases.Name = "txtNroEnvases"
        Me.txtNroEnvases.ReadOnly = True
        Me.txtNroEnvases.Size = New System.Drawing.Size(45, 20)
        Me.txtNroEnvases.TabIndex = 24
        '
        'DGV_EnvasesEnArticulo
        '
        Me.DGV_EnvasesEnArticulo.AllowUserToAddRows = False
        Me.DGV_EnvasesEnArticulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DGV_EnvasesEnArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_EnvasesEnArticulo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_EnvasesEnArticulo.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_EnvasesEnArticulo.DoubleBuffered = True
        Me.DGV_EnvasesEnArticulo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_EnvasesEnArticulo.Location = New System.Drawing.Point(11, 149)
        Me.DGV_EnvasesEnArticulo.Name = "DGV_EnvasesEnArticulo"
        Me.DGV_EnvasesEnArticulo.OrdenamientoColumnasHabilitado = True
        Me.DGV_EnvasesEnArticulo.RowHeadersWidth = 15
        Me.DGV_EnvasesEnArticulo.RowTemplate.Height = 20
        Me.DGV_EnvasesEnArticulo.ShowCellToolTips = False
        Me.DGV_EnvasesEnArticulo.SinClickDerecho = False
        Me.DGV_EnvasesEnArticulo.Size = New System.Drawing.Size(405, 167)
        Me.DGV_EnvasesEnArticulo.TabIndex = 23
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'EnvasesEquivEnArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(429, 328)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNomEnvases)
        Me.Controls.Add(Me.txtNroEnvases)
        Me.Controls.Add(Me.DGV_EnvasesEnArticulo)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximumSize = New System.Drawing.Size(445, 367)
        Me.MinimumSize = New System.Drawing.Size(445, 367)
        Me.Name = "EnvasesEquivEnArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_EnvasesEnArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNomEnvases As System.Windows.Forms.TextBox
    Friend WithEvents txtNroEnvases As System.Windows.Forms.TextBox
    Friend WithEvents DGV_EnvasesEnArticulo As Util.DBDataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
