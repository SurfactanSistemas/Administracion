<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoEnvases
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnAgregarEnvases = New System.Windows.Forms.Button()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.txtAccesoRap = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DGV_FliaMP = New ConsultasVarias.DBDataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abreviatura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_FliaMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Acceso Rapido"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(109, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Buscador"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(347, 371)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 23)
        Me.btnCerrar.TabIndex = 26
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.Location = New System.Drawing.Point(212, 371)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(88, 23)
        Me.btnPantalla.TabIndex = 25
        Me.btnPantalla.Text = "Pantalla"
        Me.btnPantalla.UseVisualStyleBackColor = True
        '
        'btnAgregarEnvases
        '
        Me.btnAgregarEnvases.Location = New System.Drawing.Point(79, 371)
        Me.btnAgregarEnvases.Name = "btnAgregarEnvases"
        Me.btnAgregarEnvases.Size = New System.Drawing.Size(97, 23)
        Me.btnAgregarEnvases.TabIndex = 24
        Me.btnAgregarEnvases.Text = "Agregar Envases"
        Me.btnAgregarEnvases.UseVisualStyleBackColor = True
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(107, 86)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(441, 20)
        Me.txtBuscador.TabIndex = 23
        '
        'txtAccesoRap
        '
        Me.txtAccesoRap.Location = New System.Drawing.Point(6, 86)
        Me.txtAccesoRap.Name = "txtAccesoRap"
        Me.txtAccesoRap.Size = New System.Drawing.Size(95, 20)
        Me.txtAccesoRap.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 61)
        Me.Panel1.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(395, 26)
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
        Me.label1.Size = New System.Drawing.Size(151, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Ingreso de Envases"
        '
        'DGV_FliaMP
        '
        Me.DGV_FliaMP.AllowUserToAddRows = False
        Me.DGV_FliaMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FliaMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Abreviatura, Me.Kilos, Me.Tipo, Me.Peso})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FliaMP.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_FliaMP.DoubleBuffered = True
        Me.DGV_FliaMP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_FliaMP.Location = New System.Drawing.Point(6, 112)
        Me.DGV_FliaMP.Name = "DGV_FliaMP"
        Me.DGV_FliaMP.OrdenamientoColumnasHabilitado = True
        Me.DGV_FliaMP.RowHeadersWidth = 15
        Me.DGV_FliaMP.RowTemplate.Height = 20
        Me.DGV_FliaMP.ShowCellToolTips = False
        Me.DGV_FliaMP.SinClickDerecho = False
        Me.DGV_FliaMP.Size = New System.Drawing.Size(542, 253)
        Me.DGV_FliaMP.TabIndex = 20
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
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Abreviatura
        '
        Me.Abreviatura.DataPropertyName = "Abreviatura"
        Me.Abreviatura.HeaderText = "Abreviatura"
        Me.Abreviatura.Name = "Abreviatura"
        '
        'Kilos
        '
        Me.Kilos.DataPropertyName = "Kilos"
        Me.Kilos.HeaderText = "Kilos"
        Me.Kilos.Name = "Kilos"
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        '
        'Peso
        '
        Me.Peso.DataPropertyName = "Peso"
        Me.Peso.HeaderText = "Peso"
        Me.Peso.Name = "Peso"
        '
        'IngresoEnvases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 400)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnAgregarEnvases)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.txtAccesoRap)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV_FliaMP)
        Me.Name = "IngresoEnvases"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_FliaMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnAgregarEnvases As System.Windows.Forms.Button
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents txtAccesoRap As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_FliaMP As ConsultasVarias.DBDataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abreviatura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
