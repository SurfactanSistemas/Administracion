Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class EvaluacionProveedorMateriaPrima
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BntLimpiar = New System.Windows.Forms.Button()
        Me.BtnCopiar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtDescProveedor = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PanelCopiarGrilla = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.PanelCopiarGrilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1152, 50)
        Me.Panel1.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(976, 12)
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
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(307, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EVALUACIÓN DE PROVEEDOR DE MATERIA PRIMA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BntLimpiar)
        Me.GroupBox1.Controls.Add(Me.BtnCopiar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.txtDescProveedor)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1152, 52)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        '
        'BntLimpiar
        '
        Me.BntLimpiar.Location = New System.Drawing.Point(928, 9)
        Me.BntLimpiar.Name = "BntLimpiar"
        Me.BntLimpiar.Size = New System.Drawing.Size(109, 37)
        Me.BntLimpiar.TabIndex = 4
        Me.BntLimpiar.Text = "LIMPIAR"
        Me.BntLimpiar.UseVisualStyleBackColor = True
        '
        'BtnCopiar
        '
        Me.BtnCopiar.Location = New System.Drawing.Point(1043, 9)
        Me.BtnCopiar.Name = "BtnCopiar"
        Me.BtnCopiar.Size = New System.Drawing.Size(106, 37)
        Me.BtnCopiar.TabIndex = 3
        Me.BtnCopiar.Text = "COPIAR GRILLA"
        Me.BtnCopiar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(815, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 38)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "CERRAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(703, 9)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(106, 38)
        Me.btnGrabar.TabIndex = 2
        Me.btnGrabar.Text = "GRABAR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtDescProveedor
        '
        Me.txtDescProveedor.BackColor = System.Drawing.Color.Cyan
        Me.txtDescProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescProveedor.Location = New System.Drawing.Point(201, 18)
        Me.txtDescProveedor.Name = "txtDescProveedor"
        Me.txtDescProveedor.ReadOnly = True
        Me.txtDescProveedor.Size = New System.Drawing.Size(488, 20)
        Me.txtDescProveedor.TabIndex = 1
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(106, 18)
        Me.txtProveedor.MaxLength = 11
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(89, 20)
        Me.txtProveedor.TabIndex = 1
        Me.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PROVEEDOR"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(120, 30)
        Me.TabControl1.Location = New System.Drawing.Point(3, 105)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1152, 381)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 53
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1144, 343)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'PanelCopiarGrilla
        '
        Me.PanelCopiarGrilla.Controls.Add(Me.Button3)
        Me.PanelCopiarGrilla.Controls.Add(Me.Label6)
        Me.PanelCopiarGrilla.Controls.Add(Me.Label5)
        Me.PanelCopiarGrilla.Controls.Add(Me.CheckBox1)
        Me.PanelCopiarGrilla.Controls.Add(Me.Button2)
        Me.PanelCopiarGrilla.Controls.Add(Me.ComboBox1)
        Me.PanelCopiarGrilla.Controls.Add(Me.Label4)
        Me.PanelCopiarGrilla.Location = New System.Drawing.Point(303, 145)
        Me.PanelCopiarGrilla.Name = "PanelCopiarGrilla"
        Me.PanelCopiarGrilla.Size = New System.Drawing.Size(547, 188)
        Me.PanelCopiarGrilla.TabIndex = 55
        Me.PanelCopiarGrilla.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(282, 131)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(155, 42)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "VOLVER"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(394, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(332, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "EN"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CheckBox1.Location = New System.Drawing.Point(187, 91)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(173, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Copiar tambien los documentos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(110, 131)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(155, 42)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ACEPTAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(113, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(188, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(81, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(384, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ELIJA DE QUE MATERIA PRIMA DESEA COPIAR LA GRILLA"
        '
        'EvaluacionProveedorMateriaPrima
        '
        Me.ClientSize = New System.Drawing.Size(1158, 489)
        Me.Controls.Add(Me.PanelCopiarGrilla)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Name = "EvaluacionProveedorMateriaPrima"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.PanelCopiarGrilla.ResumeLayout(False)
        Me.PanelCopiarGrilla.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescProveedor As TextBox
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents BtnCopiar As System.Windows.Forms.Button
    Friend WithEvents PanelCopiarGrilla As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BntLimpiar As System.Windows.Forms.Button
End Class
