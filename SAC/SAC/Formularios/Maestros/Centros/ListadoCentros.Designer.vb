Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class ListadoCentros
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New Panel()
        Me.Label2 = New Label()
        Me.Label1 = New Label()
        Me.Panel2 = New Panel()
        Me.btnCerrar = New Button()
        Me.btnEditar = New Button()
        Me.btnNuevo = New Button()
        Me.txtCodigo = New TextBox()
        Me.txtFiltrar = New TextBox()
        Me.Label4 = New Label()
        Me.Label3 = New Label()
        Me.dgvCentros = New DataGridView()
        Me.Codigo = New DataGridViewTextBoxColumn()
        Me.Descripcion = New DataGridViewTextBoxColumn()
        Me.DescResponsable = New DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCentros, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Location = New Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(534, 50)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(149, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Listado de Centros SAC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(414, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnEditar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Controls.Add(Me.txtCodigo)
        Me.Panel2.Controls.Add(Me.txtFiltrar)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = DockStyle.Top
        Me.Panel2.Location = New Point(0, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(534, 75)
        Me.Panel2.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New Point(352, 37)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(93, 29)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New Point(221, 37)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New Size(93, 29)
        Me.btnEditar.TabIndex = 3
        Me.btnEditar.Text = "Editar Centro"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New Point(90, 37)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New Size(93, 29)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Nuevo Centro"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New Point(123, 9)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New Size(48, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New Point(238, 9)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New Size(219, 20)
        Me.txtFiltrar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(77, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Código"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(200, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(32, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Filtrar"
        '
        'dgvCentros
        '
        Me.dgvCentros.AllowUserToAddRows = False
        Me.dgvCentros.AllowUserToDeleteRows = False
        Me.dgvCentros.AllowUserToResizeRows = False
        Me.dgvCentros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentros.Columns.AddRange(New DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.DescResponsable})
        Me.dgvCentros.Dock = DockStyle.Fill
        Me.dgvCentros.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvCentros.Location = New Point(0, 125)
        Me.dgvCentros.Name = "dgvCentros"
        Me.dgvCentros.RowHeadersWidth = 15
        Me.dgvCentros.RowTemplate.Height = 20
        Me.dgvCentros.ShowCellToolTips = False
        Me.dgvCentros.Size = New Size(534, 276)
        Me.dgvCentros.TabIndex = 2
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'DescResponsable
        '
        Me.DescResponsable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescResponsable.DataPropertyName = "DescResponsable"
        Me.DescResponsable.HeaderText = "Responsable"
        Me.DescResponsable.Name = "DescResponsable"
        Me.DescResponsable.Width = 94
        '
        'ListadoCentros
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(534, 401)
        Me.Controls.Add(Me.dgvCentros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ListadoCentros"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Sistema SAC"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvCentros, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvCentros As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents DescResponsable As DataGridViewTextBoxColumn
End Class
