<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Centro_Importaciones_CarpetasPendientes
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btn_CerrarP = New System.Windows.Forms.Button()
        Me.btn_Impresion = New System.Windows.Forms.Button()
        Me.DGV_Pendientes = New Util.DBDataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Carpeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInforme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(503, 50)
        Me.panel1.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(348, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(318, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Carpeta Pendientes de Calcular los Costos"
        '
        'btn_CerrarP
        '
        Me.btn_CerrarP.Location = New System.Drawing.Point(148, 56)
        Me.btn_CerrarP.Name = "btn_CerrarP"
        Me.btn_CerrarP.Size = New System.Drawing.Size(91, 38)
        Me.btn_CerrarP.TabIndex = 38
        Me.btn_CerrarP.Text = "CERRAR PANTALLA"
        Me.btn_CerrarP.UseVisualStyleBackColor = True
        '
        'btn_Impresion
        '
        Me.btn_Impresion.Location = New System.Drawing.Point(257, 56)
        Me.btn_Impresion.Name = "btn_Impresion"
        Me.btn_Impresion.Size = New System.Drawing.Size(91, 38)
        Me.btn_Impresion.TabIndex = 39
        Me.btn_Impresion.Text = "IMPRESION"
        Me.btn_Impresion.UseVisualStyleBackColor = True
        '
        'DGV_Pendientes
        '
        Me.DGV_Pendientes.AllowUserToAddRows = False
        Me.DGV_Pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Pendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.Carpeta, Me.CodProveedor, Me.NombreProveedor, Me.FechaInforme, Me.Empresa, Me.FechaOrd})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Pendientes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Pendientes.DoubleBuffered = True
        Me.DGV_Pendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Pendientes.Location = New System.Drawing.Point(6, 100)
        Me.DGV_Pendientes.Name = "DGV_Pendientes"
        Me.DGV_Pendientes.OrdenamientoColumnasHabilitado = True
        Me.DGV_Pendientes.ReadOnly = True
        Me.DGV_Pendientes.RowHeadersWidth = 15
        Me.DGV_Pendientes.RowTemplate.Height = 20
        Me.DGV_Pendientes.ShowCellToolTips = False
        Me.DGV_Pendientes.SinClickDerecho = False
        Me.DGV_Pendientes.Size = New System.Drawing.Size(492, 236)
        Me.DGV_Pendientes.TabIndex = 40
        '
        'Orden
        '
        Me.Orden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Width = 61
        '
        'Carpeta
        '
        Me.Carpeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Carpeta.HeaderText = "Carpeta"
        Me.Carpeta.Name = "Carpeta"
        Me.Carpeta.ReadOnly = True
        Me.Carpeta.Width = 69
        '
        'CodProveedor
        '
        Me.CodProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CodProveedor.HeaderText = "CodProveedor"
        Me.CodProveedor.Name = "CodProveedor"
        Me.CodProveedor.ReadOnly = True
        Me.CodProveedor.Visible = False
        '
        'NombreProveedor
        '
        Me.NombreProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreProveedor.HeaderText = "Proveedor"
        Me.NombreProveedor.Name = "NombreProveedor"
        Me.NombreProveedor.ReadOnly = True
        '
        'FechaInforme
        '
        Me.FechaInforme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaInforme.HeaderText = "Fecha"
        Me.FechaInforme.Name = "FechaInforme"
        Me.FechaInforme.ReadOnly = True
        Me.FechaInforme.Width = 62
        '
        'Empresa
        '
        Me.Empresa.HeaderText = "Empresa"
        Me.Empresa.Name = "Empresa"
        Me.Empresa.ReadOnly = True
        Me.Empresa.Visible = False
        '
        'FechaOrd
        '
        Me.FechaOrd.HeaderText = "FechaOrd"
        Me.FechaOrd.Name = "FechaOrd"
        Me.FechaOrd.ReadOnly = True
        Me.FechaOrd.Visible = False
        '
        'Centro_Importaciones_CarpetasPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 340)
        Me.Controls.Add(Me.DGV_Pendientes)
        Me.Controls.Add(Me.btn_Impresion)
        Me.Controls.Add(Me.btn_CerrarP)
        Me.Controls.Add(Me.panel1)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "Centro_Importaciones_CarpetasPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btn_CerrarP As System.Windows.Forms.Button
    Friend WithEvents btn_Impresion As System.Windows.Forms.Button
    Friend WithEvents DGV_Pendientes As Util.DBDataGridView
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carpeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaInforme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrd As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
