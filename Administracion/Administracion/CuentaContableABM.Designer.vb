<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaContableABM
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
        Me.components = New System.ComponentModel.Container()
        Me.btnPrimerRegistro = New System.Windows.Forms.Button()
        Me.btnUltimoRegistro = New System.Windows.Forms.Button()
        Me.btnSiguienteRegistro = New System.Windows.Forms.Button()
        Me.btnAnteriorRegistro = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.LBConsulta_Filtrada = New System.Windows.Forms.ListBox()
        Me.LBConsulta = New System.Windows.Forms.ListBox()
        Me.CustomLabel2 = New Administracion.CustomLabel()
        Me.btnListado = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New Administracion.CustomTextBox()
        Me.txtCodigo = New Administracion.CustomTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrimerRegistro
        '
        Me.btnPrimerRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.PrimerRegistro
        Me.btnPrimerRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPrimerRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimerRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.BorderSize = 0
        Me.btnPrimerRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrimerRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPrimerRegistro.Location = New System.Drawing.Point(11, 23)
        Me.btnPrimerRegistro.Name = "btnPrimerRegistro"
        Me.btnPrimerRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnPrimerRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnPrimerRegistro, "Primer Registro")
        Me.btnPrimerRegistro.UseVisualStyleBackColor = True
        '
        'btnUltimoRegistro
        '
        Me.btnUltimoRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.UltimoRegistro
        Me.btnUltimoRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUltimoRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimoRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.BorderSize = 0
        Me.btnUltimoRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUltimoRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnUltimoRegistro.Location = New System.Drawing.Point(149, 23)
        Me.btnUltimoRegistro.Name = "btnUltimoRegistro"
        Me.btnUltimoRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnUltimoRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnUltimoRegistro, "Último registro")
        Me.btnUltimoRegistro.UseVisualStyleBackColor = True
        '
        'btnSiguienteRegistro
        '
        Me.btnSiguienteRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.SiguienteRegistro
        Me.btnSiguienteRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSiguienteRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguienteRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.BorderSize = 0
        Me.btnSiguienteRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSiguienteRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSiguienteRegistro.Location = New System.Drawing.Point(103, 23)
        Me.btnSiguienteRegistro.Name = "btnSiguienteRegistro"
        Me.btnSiguienteRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnSiguienteRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnSiguienteRegistro, "Siguiente Registro")
        Me.btnSiguienteRegistro.UseVisualStyleBackColor = True
        '
        'btnAnteriorRegistro
        '
        Me.btnAnteriorRegistro.BackgroundImage = Global.Administracion.My.Resources.Resources.AnteriorRegistro
        Me.btnAnteriorRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAnteriorRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnteriorRegistro.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.BorderSize = 0
        Me.btnAnteriorRegistro.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnteriorRegistro.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAnteriorRegistro.Location = New System.Drawing.Point(57, 23)
        Me.btnAnteriorRegistro.Name = "btnAnteriorRegistro"
        Me.btnAnteriorRegistro.Size = New System.Drawing.Size(40, 40)
        Me.btnAnteriorRegistro.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnAnteriorRegistro, "Anterior Registro")
        Me.btnAnteriorRegistro.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtFiltrar)
        Me.Panel1.Controls.Add(Me.LBConsulta_Filtrada)
        Me.Panel1.Controls.Add(Me.LBConsulta)
        Me.Panel1.Controls.Add(Me.CustomLabel2)
        Me.Panel1.Controls.Add(Me.btnListado)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnConsulta)
        Me.Panel1.Controls.Add(Me.btnEliminar)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Location = New System.Drawing.Point(-1, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 382)
        Me.Panel1.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSiguienteRegistro)
        Me.GroupBox1.Controls.Add(Me.btnPrimerRegistro)
        Me.GroupBox1.Controls.Add(Me.btnUltimoRegistro)
        Me.GroupBox1.Controls.Add(Me.btnAnteriorRegistro)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(360, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 80)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Navegar por Cuentas Contables"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(24, 197)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(537, 20)
        Me.txtFiltrar.TabIndex = 19
        Me.txtFiltrar.Text = "Buscar..."
        '
        'LBConsulta_Filtrada
        '
        Me.LBConsulta_Filtrada.FormattingEnabled = True
        Me.LBConsulta_Filtrada.Location = New System.Drawing.Point(23, 227)
        Me.LBConsulta_Filtrada.Name = "LBConsulta_Filtrada"
        Me.LBConsulta_Filtrada.Size = New System.Drawing.Size(538, 121)
        Me.LBConsulta_Filtrada.TabIndex = 18
        Me.LBConsulta_Filtrada.Visible = False
        '
        'LBConsulta
        '
        Me.LBConsulta.FormattingEnabled = True
        Me.LBConsulta.Location = New System.Drawing.Point(23, 227)
        Me.LBConsulta.Name = "LBConsulta"
        Me.LBConsulta.Size = New System.Drawing.Size(538, 121)
        Me.LBConsulta.TabIndex = 16
        '
        'CustomLabel2
        '
        Me.CustomLabel2.AutoSize = True
        Me.CustomLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CustomLabel2.ControlAssociationKey = 2
        Me.CustomLabel2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomLabel2.ForeColor = System.Drawing.SystemColors.Control
        Me.CustomLabel2.Location = New System.Drawing.Point(212, 17)
        Me.CustomLabel2.Name = "CustomLabel2"
        Me.CustomLabel2.Size = New System.Drawing.Size(84, 18)
        Me.CustomLabel2.TabIndex = 12
        Me.CustomLabel2.Text = "Descripción:"
        '
        'btnListado
        '
        Me.btnListado.BackgroundImage = Global.Administracion.My.Resources.Resources.Informe
        Me.btnListado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnListado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListado.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.BorderSize = 0
        Me.btnListado.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListado.ForeColor = System.Drawing.SystemColors.Control
        Me.btnListado.Location = New System.Drawing.Point(246, 77)
        Me.btnListado.Name = "btnListado"
        Me.btnListado.Size = New System.Drawing.Size(105, 42)
        Me.btnListado.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnListado, "Listado de Cuentas Contables")
        Me.btnListado.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Administracion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Location = New System.Drawing.Point(23, 132)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(105, 42)
        Me.btnLimpiar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.Location = New System.Drawing.Point(246, 132)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 42)
        Me.btnCerrar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Salir de Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.BackgroundImage = Global.Administracion.My.Resources.Resources.Consulta_Dat_N1
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.ForeColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.Location = New System.Drawing.Point(134, 132)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(105, 42)
        Me.btnConsulta.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Consultar Cuentas Contables")
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.Administracion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Location = New System.Drawing.Point(135, 77)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(105, 42)
        Me.btnEliminar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Cleanable = True
        Me.txtDescripcion.Empty = False
        Me.txtDescripcion.EnterIndex = 2
        Me.txtDescripcion.LabelAssociationKey = 2
        Me.txtDescripcion.Location = New System.Drawing.Point(295, 16)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(265, 20)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Validator = Administracion.ValidatorType.None
        '
        'txtCodigo
        '
        Me.txtCodigo.Cleanable = True
        Me.txtCodigo.Empty = False
        Me.txtCodigo.EnterIndex = 1
        Me.txtCodigo.LabelAssociationKey = 1
        Me.txtCodigo.Location = New System.Drawing.Point(81, 16)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(114, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Validator = Administracion.ValidatorType.Numeric
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblCódigo)
        Me.Panel2.Location = New System.Drawing.Point(-1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 54)
        Me.Panel2.TabIndex = 15
        '
        'lblCódigo
        '
        Me.lblCódigo.AutoSize = True
        Me.lblCódigo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCódigo.Location = New System.Drawing.Point(26, 17)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(55, 18)
        Me.lblCódigo.TabIndex = 0
        Me.lblCódigo.Text = "Código:"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.BackgroundImage = Global.Administracion.My.Resources.Resources.Aceptar_N2
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Location = New System.Drawing.Point(24, 77)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(105, 42)
        Me.btnAgregar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Aceptar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(580, 58)
        Me.Panel3.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(404, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(28, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Cuentas Contables"
        '
        'CuentaContableABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 344)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CuentaContableABM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCodigo As Administracion.CustomTextBox
    Friend WithEvents txtDescripcion As Administracion.CustomTextBox
    Friend WithEvents CustomLabel2 As Administracion.CustomLabel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnListado As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnPrimerRegistro As System.Windows.Forms.Button
    Friend WithEvents btnUltimoRegistro As System.Windows.Forms.Button
    Friend WithEvents btnSiguienteRegistro As System.Windows.Forms.Button
    Friend WithEvents btnAnteriorRegistro As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents LBConsulta As System.Windows.Forms.ListBox
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents LBConsulta_Filtrada As System.Windows.Forms.ListBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
