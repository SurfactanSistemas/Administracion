Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class AgregarArchivosEvalProvMP
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
        Me.Button2 = New Button()
        Me.Button1 = New Button()
        Me.dgvArchivos = New DataGridView()
        Me.FechaArchivo = New DataGridViewTextBoxColumn()
        Me.DescArchivo = New DataGridViewTextBoxColumn()
        Me.Icono = New DataGridViewImageColumn()
        Me.PathArchivo = New DataGridViewTextBoxColumn()
        Me.Button3 = New Button()
        Me.OpenFileDialog1 = New OpenFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvArchivos, ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New Size(679, 50)
        Me.Panel1.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Calibri", 15.75!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = SystemColors.Control
        Me.Label2.Location = New Point(503, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left), AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Calibri", 12.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.Control
        Me.Label1.Location = New Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(426, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EVALUACIÓN DE PROVEEDOR DE MATERIA PRIMA - ARCHIVOS"
        '
        'Button2
        '
        Me.Button2.Location = New Point(178, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(164, 23)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "Eliminar Archivo(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New Point(8, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(164, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Agregar Archivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New DataGridViewColumn() {Me.FechaArchivo, Me.DescArchivo, Me.Icono, Me.PathArchivo})
        Me.dgvArchivos.Dock = DockStyle.Bottom
        Me.dgvArchivos.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvArchivos.Location = New Point(0, 85)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersWidth = 15
        Me.dgvArchivos.RowTemplate.Height = 30
        Me.dgvArchivos.ShowCellToolTips = False
        Me.dgvArchivos.Size = New Size(679, 244)
        Me.dgvArchivos.TabIndex = 53
        '
        'FechaArchivo
        '
        Me.FechaArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaArchivo.HeaderText = "Fecha"
        Me.FechaArchivo.Name = "FechaArchivo"
        Me.FechaArchivo.ReadOnly = True
        Me.FechaArchivo.Width = 62
        '
        'DescArchivo
        '
        Me.DescArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DescArchivo.HeaderText = "Descripción"
        Me.DescArchivo.Name = "DescArchivo"
        Me.DescArchivo.ReadOnly = True
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = DataGridViewTriState.[True]
        Me.Icono.SortMode = DataGridViewColumnSortMode.Automatic
        Me.Icono.Width = 50
        '
        'PathArchivo
        '
        Me.PathArchivo.HeaderText = "Path"
        Me.PathArchivo.Name = "PathArchivo"
        Me.PathArchivo.ReadOnly = True
        Me.PathArchivo.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New Point(495, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New Size(164, 23)
        Me.Button3.TabIndex = 55
        Me.Button3.Text = "CERRAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AgregarArchivosEvalProvMP
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(679, 329)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvArchivos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AgregarArchivosEvalProvMP"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvArchivos, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvArchivos As DataGridView
    Friend WithEvents FechaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents DescArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Icono As DataGridViewImageColumn
    Friend WithEvents PathArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Button3 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
