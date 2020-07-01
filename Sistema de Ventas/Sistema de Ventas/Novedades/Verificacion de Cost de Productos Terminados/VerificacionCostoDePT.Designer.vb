<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificacionCostoDePT
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
        Me.btn_ProcCostosFuturos = New System.Windows.Forms.Button()
        Me.btnProcesaCostoAnt = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.DGV_Articulos = New Util.DBDataGridView()
        Me.MPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(591, 40)
        Me.panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(415, 10)
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
        Me.label1.Location = New System.Drawing.Point(21, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(353, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Verificacion de Costo de Productos Terminados"
        '
        'btn_ProcCostosFuturos
        '
        Me.btn_ProcCostosFuturos.Location = New System.Drawing.Point(484, 46)
        Me.btn_ProcCostosFuturos.Name = "btn_ProcCostosFuturos"
        Me.btn_ProcCostosFuturos.Size = New System.Drawing.Size(95, 54)
        Me.btn_ProcCostosFuturos.TabIndex = 6
        Me.btn_ProcCostosFuturos.Text = "PROCESA COSTOS FUTUROS"
        Me.btn_ProcCostosFuturos.UseVisualStyleBackColor = True
        '
        'btnProcesaCostoAnt
        '
        Me.btnProcesaCostoAnt.Location = New System.Drawing.Point(484, 106)
        Me.btnProcesaCostoAnt.Name = "btnProcesaCostoAnt"
        Me.btnProcesaCostoAnt.Size = New System.Drawing.Size(95, 54)
        Me.btnProcesaCostoAnt.TabIndex = 7
        Me.btnProcesaCostoAnt.Text = "PROCESA COSTO ANTERIOR"
        Me.btnProcesaCostoAnt.UseVisualStyleBackColor = True
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(484, 166)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(95, 54)
        Me.btn_Limpiar.TabIndex = 8
        Me.btn_Limpiar.Text = "LIMPIAR PANTALLA"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Location = New System.Drawing.Point(484, 226)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(95, 54)
        Me.btn_Consulta.TabIndex = 9
        Me.btn_Consulta.Text = "CONSULTA DATOS"
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(484, 286)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(95, 54)
        Me.btn_Cerrar.TabIndex = 10
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'DGV_Articulos
        '
        Me.DGV_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Articulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MPrima, Me.Descripcion, Me.Costo1, Me.Costo2, Me.Factor})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Articulos.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Articulos.DoubleBuffered = True
        Me.DGV_Articulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Articulos.Location = New System.Drawing.Point(12, 46)
        Me.DGV_Articulos.Name = "DGV_Articulos"
        Me.DGV_Articulos.OrdenamientoColumnasHabilitado = True
        Me.DGV_Articulos.RowHeadersWidth = 15
        Me.DGV_Articulos.RowTemplate.Height = 20
        Me.DGV_Articulos.ShowCellToolTips = False
        Me.DGV_Articulos.SinClickDerecho = False
        Me.DGV_Articulos.Size = New System.Drawing.Size(466, 294)
        Me.DGV_Articulos.TabIndex = 5
        '
        'MPrima
        '
        Me.MPrima.HeaderText = "M.Prima"
        Me.MPrima.Name = "MPrima"
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Costo1
        '
        Me.Costo1.HeaderText = "Costo 1"
        Me.Costo1.Name = "Costo1"
        '
        'Costo2
        '
        Me.Costo2.HeaderText = "Costo 2"
        Me.Costo2.Name = "Costo2"
        '
        'Factor
        '
        Me.Factor.HeaderText = "Factor"
        Me.Factor.Name = "Factor"
        Me.Factor.Visible = False
        '
        'VerificacionCostoDePT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 352)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.btn_Consulta)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.btnProcesaCostoAnt)
        Me.Controls.Add(Me.btn_ProcCostosFuturos)
        Me.Controls.Add(Me.DGV_Articulos)
        Me.Controls.Add(Me.panel1)
        Me.Name = "VerificacionCostoDePT"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Articulos As Util.DBDataGridView
    Friend WithEvents btn_ProcCostosFuturos As System.Windows.Forms.Button
    Friend WithEvents btnProcesaCostoAnt As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Consulta As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents MPrima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Costo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Costo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
