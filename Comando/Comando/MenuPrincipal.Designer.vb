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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaestrosToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(787, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MaestrosToolStripMenuItem
        '
        Me.MaestrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PruebaToolStripMenuItem, Me.ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem})
        Me.MaestrosToolStripMenuItem.Name = "MaestrosToolStripMenuItem"
        Me.MaestrosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.MaestrosToolStripMenuItem.Text = "Maestros"
        '
        'PruebaToolStripMenuItem
        '
        Me.PruebaToolStripMenuItem.Name = "PruebaToolStripMenuItem"
        Me.PruebaToolStripMenuItem.Size = New System.Drawing.Size(332, 22)
        Me.PruebaToolStripMenuItem.Text = "Prueba"
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
        'ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem
        '
        Me.ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem.Name = "ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem"
        Me.ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem.Size = New System.Drawing.Size(332, 22)
        Me.ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem.Text = "Comparación de Familias entre mismos periodos"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 428)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.Text = "Menú Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MaestrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PruebaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComparaciónDeFamiliasEntreMismosPeriodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
