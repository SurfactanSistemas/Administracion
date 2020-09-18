<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.chk_MostrarAFavor = New System.Windows.Forms.CheckBox()
        Me.txt_Filtro = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Procesar = New System.Windows.Forms.Button()
        Me.btn_ReprogramarLlamado = New System.Windows.Forms.Button()
        Me.btn_ListaReprogramados = New System.Windows.Forms.Button()
        Me.cbx_AFecha = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_DesdeCodigo = New System.Windows.Forms.TextBox()
        Me.txt_HastaCodigo = New System.Windows.Forms.TextBox()
        Me.DGV_Clientes = New Util.DBDataGridView()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entradas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salidas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_Clientes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(537, 50)
        Me.panel1.TabIndex = 127
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(382, 30)
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
        Me.label1.Size = New System.Drawing.Size(334, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Agenda de Gestión de Reclamos de Envases"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Location = New System.Drawing.Point(233, 369)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Cerrar.TabIndex = 130
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 120)
        Me.ProgressBar1.Maximum = 3000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(519, 11)
        Me.ProgressBar1.TabIndex = 131
        Me.ProgressBar1.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'chk_MostrarAFavor
        '
        Me.chk_MostrarAFavor.AutoSize = True
        Me.chk_MostrarAFavor.Location = New System.Drawing.Point(388, 100)
        Me.chk_MostrarAFavor.Name = "chk_MostrarAFavor"
        Me.chk_MostrarAFavor.Size = New System.Drawing.Size(131, 17)
        Me.chk_MostrarAFavor.TabIndex = 132
        Me.chk_MostrarAFavor.Text = "Mostrar Stock a Favor"
        Me.chk_MostrarAFavor.UseVisualStyleBackColor = True
        '
        'txt_Filtro
        '
        Me.txt_Filtro.Location = New System.Drawing.Point(7, 99)
        Me.txt_Filtro.Name = "txt_Filtro"
        Me.txt_Filtro.Size = New System.Drawing.Size(375, 20)
        Me.txt_Filtro.TabIndex = 133
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Filtro"
        '
        'txt_Procesar
        '
        Me.txt_Procesar.Location = New System.Drawing.Point(233, 54)
        Me.txt_Procesar.Name = "txt_Procesar"
        Me.txt_Procesar.Size = New System.Drawing.Size(83, 41)
        Me.txt_Procesar.TabIndex = 135
        Me.txt_Procesar.Text = "LEER DATOS"
        Me.txt_Procesar.UseVisualStyleBackColor = True
        '
        'btn_ReprogramarLlamado
        '
        Me.btn_ReprogramarLlamado.Location = New System.Drawing.Point(317, 54)
        Me.btn_ReprogramarLlamado.Name = "btn_ReprogramarLlamado"
        Me.btn_ReprogramarLlamado.Size = New System.Drawing.Size(100, 41)
        Me.btn_ReprogramarLlamado.TabIndex = 136
        Me.btn_ReprogramarLlamado.Text = "AGENDAR CLIENTE"
        Me.btn_ReprogramarLlamado.UseVisualStyleBackColor = True
        '
        'btn_ListaReprogramados
        '
        Me.btn_ListaReprogramados.Location = New System.Drawing.Point(418, 54)
        Me.btn_ListaReprogramados.Name = "btn_ListaReprogramados"
        Me.btn_ListaReprogramados.Size = New System.Drawing.Size(117, 41)
        Me.btn_ListaReprogramados.TabIndex = 137
        Me.btn_ListaReprogramados.Text = "CLIENTES REPROGRAMADOS"
        Me.btn_ListaReprogramados.UseVisualStyleBackColor = True
        '
        'cbx_AFecha
        '
        Me.cbx_AFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_AFecha.FormattingEnabled = True
        Me.cbx_AFecha.Items.AddRange(New Object() {"1 mes", "3 meses", "6 meses", "12 meses"})
        Me.cbx_AFecha.Location = New System.Drawing.Point(140, 66)
        Me.cbx_AFecha.Name = "cbx_AFecha"
        Me.cbx_AFecha.Size = New System.Drawing.Size(89, 21)
        Me.cbx_AFecha.TabIndex = 138
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(140, 53)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(42, 13)
        Me.label6.TabIndex = 139
        Me.label6.Text = "Tiempo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Desde Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Hasta Cliente"
        '
        'txt_DesdeCodigo
        '
        Me.txt_DesdeCodigo.Location = New System.Drawing.Point(4, 66)
        Me.txt_DesdeCodigo.MaxLength = 6
        Me.txt_DesdeCodigo.Name = "txt_DesdeCodigo"
        Me.txt_DesdeCodigo.Size = New System.Drawing.Size(51, 20)
        Me.txt_DesdeCodigo.TabIndex = 142
        '
        'txt_HastaCodigo
        '
        Me.txt_HastaCodigo.Location = New System.Drawing.Point(74, 66)
        Me.txt_HastaCodigo.MaxLength = 6
        Me.txt_HastaCodigo.Name = "txt_HastaCodigo"
        Me.txt_HastaCodigo.Size = New System.Drawing.Size(51, 20)
        Me.txt_HastaCodigo.TabIndex = 143
        '
        'DGV_Clientes
        '
        Me.DGV_Clientes.AllowUserToAddRows = False
        Me.DGV_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cliente, Me.Descripcion, Me.Entradas, Me.Salidas, Me.Diferencia})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Clientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Clientes.DoubleBuffered = True
        Me.DGV_Clientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_Clientes.Location = New System.Drawing.Point(6, 133)
        Me.DGV_Clientes.Name = "DGV_Clientes"
        Me.DGV_Clientes.OrdenamientoColumnasHabilitado = True
        Me.DGV_Clientes.RowHeadersWidth = 15
        Me.DGV_Clientes.RowTemplate.Height = 20
        Me.DGV_Clientes.ShowCellToolTips = False
        Me.DGV_Clientes.SinClickDerecho = False
        Me.DGV_Clientes.Size = New System.Drawing.Size(522, 232)
        Me.DGV_Clientes.TabIndex = 128
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 64
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Entradas
        '
        Me.Entradas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Entradas.DataPropertyName = "Entradas"
        Me.Entradas.HeaderText = "Entradas"
        Me.Entradas.Name = "Entradas"
        Me.Entradas.ReadOnly = True
        Me.Entradas.Width = 74
        '
        'Salidas
        '
        Me.Salidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Salidas.DataPropertyName = "Salidas"
        Me.Salidas.HeaderText = "Salidas"
        Me.Salidas.Name = "Salidas"
        Me.Salidas.ReadOnly = True
        Me.Salidas.Width = 66
        '
        'Diferencia
        '
        Me.Diferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Diferencia.DataPropertyName = "Diferencia"
        Me.Diferencia.HeaderText = "Diferencia"
        Me.Diferencia.Name = "Diferencia"
        Me.Diferencia.ReadOnly = True
        Me.Diferencia.Width = 80
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 407)
        Me.Controls.Add(Me.txt_HastaCodigo)
        Me.Controls.Add(Me.txt_DesdeCodigo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.cbx_AFecha)
        Me.Controls.Add(Me.btn_ListaReprogramados)
        Me.Controls.Add(Me.btn_ReprogramarLlamado)
        Me.Controls.Add(Me.txt_Procesar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Filtro)
        Me.Controls.Add(Me.chk_MostrarAFavor)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.DGV_Clientes)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_Clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Clientes As Util.DBDataGridView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chk_MostrarAFavor As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Procesar As System.Windows.Forms.Button
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entradas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Salidas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Diferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_ReprogramarLlamado As System.Windows.Forms.Button
    Friend WithEvents btn_ListaReprogramados As System.Windows.Forms.Button
    Friend WithEvents cbx_AFecha As System.Windows.Forms.ComboBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_DesdeCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_HastaCodigo As System.Windows.Forms.TextBox

End Class
