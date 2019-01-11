Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class AyudaCentrosSac
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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Me.Panel1 = New Panel()
        Me.Label2 = New Label()
        Me.Label1 = New Label()
        Me.dgvCentros = New DataGridView()
        Me.Codigo = New DataGridViewTextBoxColumn()
        Me.Descripcion = New DataGridViewTextBoxColumn()
        Me.Label3 = New Label()
        Me.txtFiltrar = New TextBox()
        Me.btnNuevo = New Button()
        Me.btnCerrar = New Button()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New Size(391, 50)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(18, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(83, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Centros SAC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(264, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(108, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SURFACTAN S.A."
        '
        'dgvCentros
        '
        Me.dgvCentros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentros.Columns.AddRange(New DataGridViewColumn() {Me.Codigo, Me.Descripcion})
        Me.dgvCentros.Dock = DockStyle.Bottom
        Me.dgvCentros.Location = New Point(0, 123)
        Me.dgvCentros.Name = "dgvCentros"
        Me.dgvCentros.RowHeadersWidth = 15
        Me.dgvCentros.RowTemplate.Height = 20
        Me.dgvCentros.Size = New Size(391, 163)
        Me.dgvCentros.TabIndex = 3
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle2
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(15, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(32, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Filtrar"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New Point(53, 90)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New Size(322, 20)
        Me.txtFiltrar.TabIndex = 5
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New Point(53, 61)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New Size(115, 23)
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Nuevo Centro"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New Point(174, 61)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(68, 23)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'AyudaCentrosSac
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(391, 286)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvCentros)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AyudaCentrosSac"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCentros, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCentros As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
End Class
