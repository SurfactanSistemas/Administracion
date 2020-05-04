<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_Cambios
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
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGV_Cambios = New ConsultasVarias.DBDataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dolar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Euro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Divisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reflex30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reflex60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reflex90 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reflex120 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Cambios, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(402, 49)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(235, 26)
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
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(137, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Consulta Cambios"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(13, 71)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(379, 20)
        Me.txtFiltro.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Filtro"
        '
        'DGV_Cambios
        '
        Me.DGV_Cambios.AllowUserToAddRows = False
        Me.DGV_Cambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Cambios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.OrdFecha, Me.Dolar, Me.Euro, Me.Divisa, Me.Reflex30, Me.Reflex60, Me.Reflex90, Me.Reflex120})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Cambios.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Cambios.DoubleBuffered = True
        Me.DGV_Cambios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Cambios.Location = New System.Drawing.Point(13, 98)
        Me.DGV_Cambios.Name = "DGV_Cambios"
        Me.DGV_Cambios.OrdenamientoColumnasHabilitado = True
        Me.DGV_Cambios.RowHeadersWidth = 15
        Me.DGV_Cambios.RowTemplate.Height = 20
        Me.DGV_Cambios.ShowCellToolTips = False
        Me.DGV_Cambios.SinClickDerecho = False
        Me.DGV_Cambios.Size = New System.Drawing.Size(379, 227)
        Me.DGV_Cambios.TabIndex = 8
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(156, 334)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'OrdFecha
        '
        Me.OrdFecha.DataPropertyName = "OrdFecha"
        Me.OrdFecha.HeaderText = "OrdFecha"
        Me.OrdFecha.Name = "OrdFecha"
        Me.OrdFecha.Visible = False
        '
        'Dolar
        '
        Me.Dolar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Dolar.DataPropertyName = "Dolar"
        Me.Dolar.HeaderText = "Dolar"
        Me.Dolar.Name = "Dolar"
        Me.Dolar.ReadOnly = True
        Me.Dolar.Width = 57
        '
        'Euro
        '
        Me.Euro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Euro.DataPropertyName = "Euro"
        Me.Euro.HeaderText = "Euro"
        Me.Euro.Name = "Euro"
        Me.Euro.ReadOnly = True
        Me.Euro.Width = 54
        '
        'Divisa
        '
        Me.Divisa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Divisa.DataPropertyName = "Divisa"
        Me.Divisa.HeaderText = "Divisa"
        Me.Divisa.Name = "Divisa"
        Me.Divisa.ReadOnly = True
        Me.Divisa.Width = 61
        '
        'Reflex30
        '
        Me.Reflex30.DataPropertyName = "Reflex30"
        Me.Reflex30.HeaderText = "Reflex30"
        Me.Reflex30.Name = "Reflex30"
        Me.Reflex30.Visible = False
        '
        'Reflex60
        '
        Me.Reflex60.DataPropertyName = "Reflex60"
        Me.Reflex60.HeaderText = "Reflex60"
        Me.Reflex60.Name = "Reflex60"
        Me.Reflex60.Visible = False
        '
        'Reflex90
        '
        Me.Reflex90.DataPropertyName = "Reflex90"
        Me.Reflex90.HeaderText = "Reflex90"
        Me.Reflex90.Name = "Reflex90"
        Me.Reflex90.Visible = False
        '
        'Reflex120
        '
        Me.Reflex120.DataPropertyName = "Reflex120"
        Me.Reflex120.HeaderText = "Reflex120"
        Me.Reflex120.Name = "Reflex120"
        Me.Reflex120.Visible = False
        '
        'Consulta_Cambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 369)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.DGV_Cambios)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Consulta_Cambios"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Cambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV_Cambios As ConsultasVarias.DBDataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dolar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Euro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Divisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reflex30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reflex60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reflex90 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reflex120 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
