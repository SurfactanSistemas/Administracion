<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPermisos
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Sistema = New System.Windows.Forms.TextBox()
        Me.txt_Perfil = New System.Windows.Forms.TextBox()
        Me.btn_Grabar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.DGV_OpcionesHabilitadas = New Util.DBDataGridView()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDhab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreHab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPadreHab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpcionPreviaHab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lectura = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Escritura = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgv_Opciones = New Util.DBDataGridView()
        Me.check1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPadre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombrePadre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_Planta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_DesHabilitar = New System.Windows.Forms.Button()
        Me.btn_Habilitar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_OpcionesHabilitadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Opciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1019, 52)
        Me.Panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(838, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EDITAR PERMISOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Sistema"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Perfil"
        '
        'txt_Sistema
        '
        Me.txt_Sistema.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Sistema.Location = New System.Drawing.Point(56, 64)
        Me.txt_Sistema.Name = "txt_Sistema"
        Me.txt_Sistema.ReadOnly = True
        Me.txt_Sistema.Size = New System.Drawing.Size(199, 20)
        Me.txt_Sistema.TabIndex = 13
        '
        'txt_Perfil
        '
        Me.txt_Perfil.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Perfil.Location = New System.Drawing.Point(292, 64)
        Me.txt_Perfil.Name = "txt_Perfil"
        Me.txt_Perfil.ReadOnly = True
        Me.txt_Perfil.Size = New System.Drawing.Size(199, 20)
        Me.txt_Perfil.TabIndex = 14
        '
        'btn_Grabar
        '
        Me.btn_Grabar.Location = New System.Drawing.Point(780, 58)
        Me.btn_Grabar.Name = "btn_Grabar"
        Me.btn_Grabar.Size = New System.Drawing.Size(75, 41)
        Me.btn_Grabar.TabIndex = 15
        Me.btn_Grabar.Text = "GRABAR"
        Me.btn_Grabar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(861, 58)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 41)
        Me.btn_Cancelar.TabIndex = 16
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'DGV_OpcionesHabilitadas
        '
        Me.DGV_OpcionesHabilitadas.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_OpcionesHabilitadas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_OpcionesHabilitadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_OpcionesHabilitadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.IDhab, Me.NombreHab, Me.IDPadreHab, Me.OpcionPreviaHab, Me.Lectura, Me.Escritura})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_OpcionesHabilitadas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_OpcionesHabilitadas.DoubleBuffered = True
        Me.DGV_OpcionesHabilitadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_OpcionesHabilitadas.Location = New System.Drawing.Point(470, 117)
        Me.DGV_OpcionesHabilitadas.Name = "DGV_OpcionesHabilitadas"
        Me.DGV_OpcionesHabilitadas.OrdenamientoColumnasHabilitado = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_OpcionesHabilitadas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_OpcionesHabilitadas.RowHeadersWidth = 15
        Me.DGV_OpcionesHabilitadas.RowTemplate.Height = 20
        Me.DGV_OpcionesHabilitadas.ShowCellToolTips = False
        Me.DGV_OpcionesHabilitadas.SinClickDerecho = False
        Me.DGV_OpcionesHabilitadas.Size = New System.Drawing.Size(544, 307)
        Me.DGV_OpcionesHabilitadas.TabIndex = 8
        '
        'Check
        '
        Me.Check.HeaderText = "Check"
        Me.Check.Name = "Check"
        Me.Check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Check.Width = 40
        '
        'IDhab
        '
        Me.IDhab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IDhab.HeaderText = "IDhab"
        Me.IDhab.Name = "IDhab"
        Me.IDhab.ReadOnly = True
        Me.IDhab.Visible = False
        Me.IDhab.Width = 61
        '
        'NombreHab
        '
        Me.NombreHab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NombreHab.HeaderText = "Nombre"
        Me.NombreHab.Name = "NombreHab"
        Me.NombreHab.ReadOnly = True
        Me.NombreHab.Width = 69
        '
        'IDPadreHab
        '
        Me.IDPadreHab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IDPadreHab.HeaderText = "IDPadreHab"
        Me.IDPadreHab.Name = "IDPadreHab"
        Me.IDPadreHab.ReadOnly = True
        Me.IDPadreHab.Visible = False
        Me.IDPadreHab.Width = 91
        '
        'OpcionPreviaHab
        '
        Me.OpcionPreviaHab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.OpcionPreviaHab.HeaderText = "Opcion Previa"
        Me.OpcionPreviaHab.Name = "OpcionPreviaHab"
        Me.OpcionPreviaHab.ReadOnly = True
        Me.OpcionPreviaHab.Width = 99
        '
        'Lectura
        '
        Me.Lectura.HeaderText = "Lectura"
        Me.Lectura.Name = "Lectura"
        Me.Lectura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lectura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Lectura.Width = 50
        '
        'Escritura
        '
        Me.Escritura.HeaderText = "Escritura"
        Me.Escritura.Name = "Escritura"
        Me.Escritura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Escritura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Escritura.Width = 50
        '
        'dgv_Opciones
        '
        Me.dgv_Opciones.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Opciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_Opciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Opciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check1, Me.ID, Me.Nombre, Me.IDPadre, Me.NombrePadre})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Opciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_Opciones.DoubleBuffered = True
        Me.dgv_Opciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Opciones.Location = New System.Drawing.Point(6, 117)
        Me.dgv_Opciones.Name = "dgv_Opciones"
        Me.dgv_Opciones.OrdenamientoColumnasHabilitado = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Opciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_Opciones.RowHeadersWidth = 15
        Me.dgv_Opciones.RowTemplate.Height = 20
        Me.dgv_Opciones.ShowCellToolTips = False
        Me.dgv_Opciones.SinClickDerecho = False
        Me.dgv_Opciones.Size = New System.Drawing.Size(389, 307)
        Me.dgv_Opciones.TabIndex = 7
        '
        'check1
        '
        Me.check1.FalseValue = "False"
        Me.check1.HeaderText = "Check"
        Me.check1.IndeterminateValue = "False"
        Me.check1.Name = "check1"
        Me.check1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.check1.TrueValue = "True"
        Me.check1.Width = 40
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 69
        '
        'IDPadre
        '
        Me.IDPadre.HeaderText = "IDPadre"
        Me.IDPadre.Name = "IDPadre"
        Me.IDPadre.ReadOnly = True
        Me.IDPadre.Visible = False
        '
        'NombrePadre
        '
        Me.NombrePadre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NombrePadre.HeaderText = "Opcion Previa"
        Me.NombrePadre.Name = "NombrePadre"
        Me.NombrePadre.ReadOnly = True
        Me.NombrePadre.Width = 99
        '
        'txt_Planta
        '
        Me.txt_Planta.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Planta.Location = New System.Drawing.Point(543, 64)
        Me.txt_Planta.Name = "txt_Planta"
        Me.txt_Planta.ReadOnly = True
        Me.txt_Planta.Size = New System.Drawing.Size(199, 20)
        Me.txt_Planta.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(505, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Planta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "NO AUTORIZADAS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(467, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "AUTORIZADAS"
        '
        'btn_DesHabilitar
        '
        Me.btn_DesHabilitar.BackgroundImage = Global.SistemaGestionPerfiles.My.Resources.Resources.flecha_correctaIZQ
        Me.btn_DesHabilitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_DesHabilitar.Location = New System.Drawing.Point(401, 289)
        Me.btn_DesHabilitar.Name = "btn_DesHabilitar"
        Me.btn_DesHabilitar.Size = New System.Drawing.Size(65, 45)
        Me.btn_DesHabilitar.TabIndex = 10
        Me.btn_DesHabilitar.UseVisualStyleBackColor = True
        '
        'btn_Habilitar
        '
        Me.btn_Habilitar.BackgroundImage = Global.SistemaGestionPerfiles.My.Resources.Resources.flecha_correcta
        Me.btn_Habilitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Habilitar.Location = New System.Drawing.Point(401, 197)
        Me.btn_Habilitar.Name = "btn_Habilitar"
        Me.btn_Habilitar.Size = New System.Drawing.Size(65, 45)
        Me.btn_Habilitar.TabIndex = 9
        Me.btn_Habilitar.UseVisualStyleBackColor = True
        '
        'EditarPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 429)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Planta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Grabar)
        Me.Controls.Add(Me.txt_Perfil)
        Me.Controls.Add(Me.txt_Sistema)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_DesHabilitar)
        Me.Controls.Add(Me.btn_Habilitar)
        Me.Controls.Add(Me.DGV_OpcionesHabilitadas)
        Me.Controls.Add(Me.dgv_Opciones)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EditarPermisos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_OpcionesHabilitadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Opciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_Opciones As Util.DBDataGridView
    Friend WithEvents DGV_OpcionesHabilitadas As Util.DBDataGridView
    Friend WithEvents btn_Habilitar As System.Windows.Forms.Button
    Friend WithEvents btn_DesHabilitar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Sistema As System.Windows.Forms.TextBox
    Friend WithEvents txt_Perfil As System.Windows.Forms.TextBox
    Friend WithEvents btn_Grabar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents check1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPadre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombrePadre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDhab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreHab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPadreHab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpcionPreviaHab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lectura As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Escritura As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txt_Planta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
