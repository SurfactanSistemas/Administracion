Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class AyudaProveedores
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.ckSoloFarma = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(449, 50)
        Me.Panel1.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(273, 12)
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
        Me.Label1.Size = New System.Drawing.Size(109, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PROVEEDORES"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.txtFiltrar)
        Me.GroupBox1.Controls.Add(Me.ckSoloFarma)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 80)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FILTRAR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(95, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "SEGUN TIPO DE MP"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"TODOS", "FARMA", "FOOD", "VETERINARIA", "OTROS"})
        Me.ComboBox1.Location = New System.Drawing.Point(216, 49)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Location = New System.Drawing.Point(27, 23)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(378, 20)
        Me.txtFiltrar.TabIndex = 0
        '
        'ckSoloFarma
        '
        Me.ckSoloFarma.AutoSize = True
        Me.ckSoloFarma.Checked = True
        Me.ckSoloFarma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckSoloFarma.Location = New System.Drawing.Point(28, 26)
        Me.ckSoloFarma.Name = "ckSoloFarma"
        Me.ckSoloFarma.Size = New System.Drawing.Size(377, 17)
        Me.ckSoloFarma.TabIndex = 1
        Me.ckSoloFarma.Text = "ÚNICAMENTE PROVEEDORES CON MP DE SEGUIMIENTO ESPECIAL"
        Me.ckSoloFarma.UseVisualStyleBackColor = True
        Me.ckSoloFarma.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.Location = New System.Drawing.Point(0, 142)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 15
        Me.DataGridView1.RowTemplate.Height = 18
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.Size = New System.Drawing.Size(449, 232)
        Me.DataGridView1.TabIndex = 54
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Codigo.DataPropertyName = "Codigo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nombre.HeaderText = "Nombre Proveedor"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'AyudaProveedores
        '
        Me.ClientSize = New System.Drawing.Size(449, 374)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AyudaProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ckSoloFarma As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
