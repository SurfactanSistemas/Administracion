Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class ListadoTiposSolicitud
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
        Me.dgvTIpos = New DataGridView()
        Me.Codigo = New DataGridViewTextBoxColumn()
        Me.Descripcion = New DataGridViewTextBoxColumn()
        Me.Abreviatura = New DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvTIpos, ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New Size(457, 50)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(25, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(183, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Listado de Tipos de Solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(316, 16)
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
        Me.Panel2.Size = New Size(457, 75)
        Me.Panel2.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New Point(308, 37)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(93, 29)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New Point(177, 37)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New Size(93, 29)
        Me.btnEditar.TabIndex = 3
        Me.btnEditar.Text = "Editar Tipo"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New Point(46, 37)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New Size(93, 29)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Nuevo Tipo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New Point(79, 9)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New Size(48, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New Point(194, 9)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New Size(219, 20)
        Me.txtFiltrar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(33, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Código"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(156, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(32, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Filtrar"
        '
        'dgvTIpos
        '
        Me.dgvTIpos.AllowUserToAddRows = False
        Me.dgvTIpos.AllowUserToDeleteRows = False
        Me.dgvTIpos.AllowUserToResizeRows = False
        Me.dgvTIpos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTIpos.Columns.AddRange(New DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Abreviatura})
        Me.dgvTIpos.Dock = DockStyle.Fill
        Me.dgvTIpos.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvTIpos.Location = New Point(0, 125)
        Me.dgvTIpos.Name = "dgvTIpos"
        Me.dgvTIpos.RowHeadersWidth = 15
        Me.dgvTIpos.RowTemplate.Height = 20
        Me.dgvTIpos.ShowCellToolTips = False
        Me.dgvTIpos.Size = New Size(457, 276)
        Me.dgvTIpos.TabIndex = 2
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
        'Abreviatura
        '
        Me.Abreviatura.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Abreviatura.DataPropertyName = "Abreviatura"
        Me.Abreviatura.HeaderText = "Abrev."
        Me.Abreviatura.Name = "Abreviatura"
        Me.Abreviatura.ReadOnly = True
        Me.Abreviatura.Width = 63
        '
        'ListadoTiposSolicitud
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(457, 401)
        Me.Controls.Add(Me.dgvTIpos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ListadoTiposSolicitud"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Sistema SAC"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvTIpos, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvTIpos As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Abreviatura As DataGridViewTextBoxColumn
End Class
