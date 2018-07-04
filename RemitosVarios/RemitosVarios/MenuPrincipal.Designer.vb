<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoDeRemitoVarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutMenu, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.Panel1, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 2
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(1009, 463)
        Me.LayoutPrincipal.TabIndex = 0
        '
        'LayoutMenu
        '
        Me.LayoutMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutMenu.ColumnCount = 3
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.LayoutMenu.Controls.Add(Me.Panel4, 2, 0)
        Me.LayoutMenu.Controls.Add(Me.Panel2, 0, 0)
        Me.LayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutMenu.Location = New System.Drawing.Point(0, 0)
        Me.LayoutMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutMenu.Name = "LayoutMenu"
        Me.LayoutMenu.RowCount = 1
        Me.LayoutMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutMenu.Size = New System.Drawing.Size(1009, 46)
        Me.LayoutMenu.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(762, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(247, 46)
        Me.Panel4.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(35, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(294, 46)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Remitos Varios"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1009, 417)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 252)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 46)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cambiar de Empresa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaestrosToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1009, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MaestrosToolStripMenuItem
        '
        Me.MaestrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresoDeRemitoVarioToolStripMenuItem})
        Me.MaestrosToolStripMenuItem.Name = "MaestrosToolStripMenuItem"
        Me.MaestrosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.MaestrosToolStripMenuItem.Text = "Maestros"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSistemaToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'CerrarSistemaToolStripMenuItem
        '
        Me.CerrarSistemaToolStripMenuItem.Name = "CerrarSistemaToolStripMenuItem"
        Me.CerrarSistemaToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CerrarSistemaToolStripMenuItem.Text = "Cerrar Sistema"
        '
        'IngresoDeRemitoVarioToolStripMenuItem
        '
        Me.IngresoDeRemitoVarioToolStripMenuItem.Name = "IngresoDeRemitoVarioToolStripMenuItem"
        Me.IngresoDeRemitoVarioToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.IngresoDeRemitoVarioToolStripMenuItem.Text = "Ingreso de Remito Vario"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 463)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MaestrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IngresoDeRemitoVarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
