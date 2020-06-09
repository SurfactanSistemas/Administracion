Imports Util

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistorialCambios
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvVersiones = New Util.DBDataGridView()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MotivoCambios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvVersiones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(582, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(392, 12)
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
        Me.Label1.Location = New System.Drawing.Point(34, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "HISTORIAL DE CAMBIOS"
        '
        'dgvVersiones
        '
        Me.dgvVersiones.AllowUserToAddRows = False
        Me.dgvVersiones.AllowUserToDeleteRows = False
        Me.dgvVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVersiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Version, Me.FechaInicio, Me.FechaFinal, Me.MotivoCambios})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVersiones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVersiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVersiones.DoubleBuffered = True
        Me.dgvVersiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVersiones.Location = New System.Drawing.Point(0, 49)
        Me.dgvVersiones.Name = "dgvVersiones"
        Me.dgvVersiones.OrdenamientoColumnasHabilitado = False
        Me.dgvVersiones.ReadOnly = True
        Me.dgvVersiones.RowHeadersWidth = 15
        Me.dgvVersiones.ShowCellToolTips = False
        Me.dgvVersiones.SinClickDerecho = False
        Me.dgvVersiones.Size = New System.Drawing.Size(582, 347)
        Me.dgvVersiones.TabIndex = 4
        '
        'Version
        '
        Me.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Version.DataPropertyName = "Version"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "0#"
        DataGridViewCellStyle1.NullValue = "0"
        Me.Version.DefaultCellStyle = DataGridViewCellStyle1
        Me.Version.HeaderText = "Versión"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Version.Width = 48
        '
        'FechaInicio
        '
        Me.FechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaInicio.DataPropertyName = "FechaInicio"
        Me.FechaInicio.HeaderText = "Fecha Inicio"
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.ReadOnly = True
        Me.FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaInicio.Width = 71
        '
        'FechaFinal
        '
        Me.FechaFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaFinal.DataPropertyName = "FechaFinal"
        Me.FechaFinal.HeaderText = "Fecha Final"
        Me.FechaFinal.Name = "FechaFinal"
        Me.FechaFinal.ReadOnly = True
        Me.FechaFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaFinal.Width = 68
        '
        'MotivoCambios
        '
        Me.MotivoCambios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MotivoCambios.DataPropertyName = "ControlCambio"
        Me.MotivoCambios.HeaderText = "Motivos de Cambio"
        Me.MotivoCambios.MinimumWidth = 375
        Me.MotivoCambios.Name = "MotivoCambios"
        Me.MotivoCambios.ReadOnly = True
        Me.MotivoCambios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MotivoCambios.Width = 375
        '
        'HistorialCambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 396)
        Me.Controls.Add(Me.dgvVersiones)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HistorialCambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvVersiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvVersiones As DBDataGridView
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotivoCambios As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
