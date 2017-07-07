<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaRemitos
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.LBProveedores = New System.Windows.Forms.ListBox()
        Me.btnConsultaRemitos = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcionProveedor = New System.Windows.Forms.TextBox()
        Me.txtRemitos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LBRemitos = New System.Windows.Forms.ListBox()
        Me.LBConsulta_Filtrada = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 50)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(492, 10)
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
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consulta de Remitos"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(28, 61)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(605, 20)
        Me.txtFiltrar.TabIndex = 2
        Me.txtFiltrar.Text = "Buscar..."
        '
        'LBProveedores
        '
        Me.LBProveedores.FormattingEnabled = True
        Me.LBProveedores.Location = New System.Drawing.Point(28, 45)
        Me.LBProveedores.Name = "LBProveedores"
        Me.LBProveedores.Size = New System.Drawing.Size(605, 199)
        Me.LBProveedores.TabIndex = 3
        '
        'btnConsultaRemitos
        '
        Me.btnConsultaRemitos.BackgroundImage = Global.Administracion.My.Resources.Resources.Informe
        Me.btnConsultaRemitos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultaRemitos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaRemitos.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRemitos.FlatAppearance.BorderSize = 0
        Me.btnConsultaRemitos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRemitos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaRemitos.ForeColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRemitos.Location = New System.Drawing.Point(190, 374)
        Me.btnConsultaRemitos.Name = "btnConsultaRemitos"
        Me.btnConsultaRemitos.Size = New System.Drawing.Size(132, 48)
        Me.btnConsultaRemitos.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnConsultaRemitos, "Consultar Remitos de Proveedor")
        Me.btnConsultaRemitos.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.Location = New System.Drawing.Point(328, 374)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(132, 48)
        Me.btnCerrar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar Formulario")
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(111, 304)
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(135, 20)
        Me.txtCodigoProveedor.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtCodigoProveedor, "Doble Click: Abrir Consulta de Proveedores")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(32, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Proveedor"
        '
        'txtDescripcionProveedor
        '
        Me.txtDescripcionProveedor.Location = New System.Drawing.Point(252, 304)
        Me.txtDescripcionProveedor.Name = "txtDescripcionProveedor"
        Me.txtDescripcionProveedor.Size = New System.Drawing.Size(376, 20)
        Me.txtDescripcionProveedor.TabIndex = 5
        '
        'txtRemitos
        '
        Me.txtRemitos.Location = New System.Drawing.Point(111, 329)
        Me.txtRemitos.Name = "txtRemitos"
        Me.txtRemitos.Size = New System.Drawing.Size(517, 20)
        Me.txtRemitos.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(46, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Remitos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LBRemitos)
        Me.Panel2.Controls.Add(Me.LBConsulta_Filtrada)
        Me.Panel2.Controls.Add(Me.LBProveedores)
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(665, 309)
        Me.Panel2.TabIndex = 7
        '
        'LBRemitos
        '
        Me.LBRemitos.FormattingEnabled = True
        Me.LBRemitos.Location = New System.Drawing.Point(244, 45)
        Me.LBRemitos.Name = "LBRemitos"
        Me.LBRemitos.Size = New System.Drawing.Size(157, 199)
        Me.LBRemitos.TabIndex = 9
        '
        'LBConsulta_Filtrada
        '
        Me.LBConsulta_Filtrada.FormattingEnabled = True
        Me.LBConsulta_Filtrada.Location = New System.Drawing.Point(28, 44)
        Me.LBConsulta_Filtrada.Name = "LBConsulta_Filtrada"
        Me.LBConsulta_Filtrada.Size = New System.Drawing.Size(605, 199)
        Me.LBConsulta_Filtrada.TabIndex = 8
        Me.LBConsulta_Filtrada.Visible = False
        '
        'ConsultaRemitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 437)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcionProveedor)
        Me.Controls.Add(Me.txtRemitos)
        Me.Controls.Add(Me.txtCodigoProveedor)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsultaRemitos)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ConsultaRemitos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents LBProveedores As System.Windows.Forms.ListBox
    Friend WithEvents btnConsultaRemitos As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LBConsulta_Filtrada As System.Windows.Forms.ListBox
    Friend WithEvents LBRemitos As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
