<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VistaPreviaDBAuxi
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
        Me.DbDataGridView1 = New ConsultasVarias.DBDataGridView()
        CType(Me.DbDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbDataGridView1
        '
        Me.DbDataGridView1.AllowUserToAddRows = False
        Me.DbDataGridView1.AllowUserToDeleteRows = False
        Me.DbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DbDataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DbDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DbDataGridView1.DoubleBuffered = True
        Me.DbDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DbDataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DbDataGridView1.Name = "DbDataGridView1"
        Me.DbDataGridView1.OrdenamientoColumnasHabilitado = True
        Me.DbDataGridView1.ReadOnly = True
        Me.DbDataGridView1.RowHeadersWidth = 15
        Me.DbDataGridView1.RowTemplate.Height = 20
        Me.DbDataGridView1.ShowCellToolTips = False
        Me.DbDataGridView1.SinClickDerecho = False
        Me.DbDataGridView1.Size = New System.Drawing.Size(620, 341)
        Me.DbDataGridView1.TabIndex = 0
        '
        'VistaPreviaDBAuxi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 341)
        Me.Controls.Add(Me.DbDataGridView1)
        Me.Name = "VistaPreviaDBAuxi"
        Me.Text = "VistaPreviaDBAuxi"
        CType(Me.DbDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbDataGridView1 As ConsultasVarias.DBDataGridView
End Class
