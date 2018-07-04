<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DireccionesCliente
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
        Me.dgvDirecciones = New System.Windows.Forms.DataGridView()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvDirecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDirecciones
        '
        Me.dgvDirecciones.AllowUserToAddRows = False
        Me.dgvDirecciones.AllowUserToDeleteRows = False
        Me.dgvDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDirecciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Direccion})
        Me.dgvDirecciones.Location = New System.Drawing.Point(10, 89)
        Me.dgvDirecciones.Name = "dgvDirecciones"
        Me.dgvDirecciones.ReadOnly = True
        Me.dgvDirecciones.RowHeadersWidth = 15
        Me.dgvDirecciones.RowTemplate.Height = 18
        Me.dgvDirecciones.Size = New System.Drawing.Size(411, 212)
        Me.dgvDirecciones.TabIndex = 0
        '
        'Direccion
        '
        Me.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 55)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Direcciones de Entrega de Cliente"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(408, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DireccionesCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvDirecciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DireccionesCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DireccionesCliente"
        CType(Me.dgvDirecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDirecciones As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
