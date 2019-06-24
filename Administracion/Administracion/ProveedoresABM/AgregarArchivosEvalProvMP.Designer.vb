<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarArchivosEvalProvMP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.FechaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icono = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PathArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(679, 50)
        Me.Panel1.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(503, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(426, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EVALUACIÓN DE PROVEEDOR DE MATERIA PRIMA - ARCHIVOS"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(178, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 23)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "Eliminar Archivo(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Agregar Archivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvArchivos
        '
        Me.dgvArchivos.AllowDrop = True
        Me.dgvArchivos.AllowUserToAddRows = False
        Me.dgvArchivos.AllowUserToDeleteRows = False
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaArchivo, Me.DescArchivo, Me.Icono, Me.PathArchivo})
        Me.dgvArchivos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvArchivos.Location = New System.Drawing.Point(0, 85)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.ReadOnly = True
        Me.dgvArchivos.RowHeadersWidth = 15
        Me.dgvArchivos.RowTemplate.Height = 30
        Me.dgvArchivos.ShowCellToolTips = False
        Me.dgvArchivos.Size = New System.Drawing.Size(679, 244)
        Me.dgvArchivos.TabIndex = 53
        '
        'FechaArchivo
        '
        Me.FechaArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaArchivo.HeaderText = "Fecha"
        Me.FechaArchivo.Name = "FechaArchivo"
        Me.FechaArchivo.ReadOnly = True
        Me.FechaArchivo.Width = 62
        '
        'DescArchivo
        '
        Me.DescArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescArchivo.HeaderText = "Descripción"
        Me.DescArchivo.Name = "DescArchivo"
        Me.DescArchivo.ReadOnly = True
        '
        'Icono
        '
        Me.Icono.HeaderText = ""
        Me.Icono.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Icono.Name = "Icono"
        Me.Icono.ReadOnly = True
        Me.Icono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Icono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.Button3.Location = New System.Drawing.Point(495, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(164, 23)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 329)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvArchivos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AgregarArchivosEvalProvMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvArchivos As System.Windows.Forms.DataGridView
    Friend WithEvents FechaArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Icono As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PathArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
