<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoVendedores
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
        Me.DGV_Vendedores = New Util.DBDataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtAccesoRap = New System.Windows.Forms.TextBox()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgregarVendedor = New System.Windows.Forms.Button()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.bntCerrar = New System.Windows.Forms.Button()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerCliente = New System.Windows.Forms.DataGridViewLinkColumn()
        CType(Me.DGV_Vendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Vendedores
        '
        Me.DGV_Vendedores.AllowUserToAddRows = False
        Me.DGV_Vendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Vendedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.Email1, Me.Email2, Me.VerCliente})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Vendedores.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Vendedores.DoubleBuffered = True
        Me.DGV_Vendedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Vendedores.Location = New System.Drawing.Point(9, 113)
        Me.DGV_Vendedores.Name = "DGV_Vendedores"
        Me.DGV_Vendedores.OrdenamientoColumnasHabilitado = True
        Me.DGV_Vendedores.RowHeadersWidth = 15
        Me.DGV_Vendedores.RowTemplate.Height = 20
        Me.DGV_Vendedores.ShowCellToolTips = False
        Me.DGV_Vendedores.SinClickDerecho = False
        Me.DGV_Vendedores.Size = New System.Drawing.Size(550, 276)
        Me.DGV_Vendedores.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(571, 61)
        Me.Panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(413, 26)
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
        Me.label1.Size = New System.Drawing.Size(177, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Ingreso de Vendedores"
        '
        'txtAccesoRap
        '
        Me.txtAccesoRap.Location = New System.Drawing.Point(9, 87)
        Me.txtAccesoRap.Name = "txtAccesoRap"
        Me.txtAccesoRap.Size = New System.Drawing.Size(97, 20)
        Me.txtAccesoRap.TabIndex = 5
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(112, 87)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(447, 20)
        Me.txtBuscador.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Acceso Rapido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Buscador"
        '
        'btnAgregarVendedor
        '
        Me.btnAgregarVendedor.Location = New System.Drawing.Point(12, 403)
        Me.btnAgregarVendedor.Name = "btnAgregarVendedor"
        Me.btnAgregarVendedor.Size = New System.Drawing.Size(108, 23)
        Me.btnAgregarVendedor.TabIndex = 9
        Me.btnAgregarVendedor.Text = "Agregar Vendedor"
        Me.btnAgregarVendedor.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.Location = New System.Drawing.Point(238, 403)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(108, 23)
        Me.btnPantalla.TabIndex = 10
        Me.btnPantalla.Text = "Pantalla"
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'bntCerrar
        '
        Me.bntCerrar.Location = New System.Drawing.Point(451, 403)
        Me.bntCerrar.Name = "bntCerrar"
        Me.bntCerrar.Size = New System.Drawing.Size(108, 23)
        Me.bntCerrar.TabIndex = 11
        Me.bntCerrar.Text = "Cerrar"
        Me.bntCerrar.UseVisualStyleBackColor = True
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
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 69
        '
        'Email1
        '
        Me.Email1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Email1.DataPropertyName = "Email1"
        Me.Email1.HeaderText = "1º mail"
        Me.Email1.Name = "Email1"
        Me.Email1.ReadOnly = True
        Me.Email1.Width = 63
        '
        'Email2
        '
        Me.Email2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Email2.DataPropertyName = "Email2"
        Me.Email2.HeaderText = "2º Mail"
        Me.Email2.Name = "Email2"
        Me.Email2.ReadOnly = True
        '
        'VerCliente
        '
        Me.VerCliente.DataPropertyName = "VerCliente"
        Me.VerCliente.HeaderText = "Clientes"
        Me.VerCliente.Name = "VerCliente"
        '
        'IngresoVendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 434)
        Me.Controls.Add(Me.bntCerrar)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnAgregarVendedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.txtAccesoRap)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV_Vendedores)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "IngresoVendedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.DGV_Vendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Vendedores As Util.DBDataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccesoRap As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarVendedor As System.Windows.Forms.Button
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents bntCerrar As System.Windows.Forms.Button
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerCliente As System.Windows.Forms.DataGridViewLinkColumn
End Class
