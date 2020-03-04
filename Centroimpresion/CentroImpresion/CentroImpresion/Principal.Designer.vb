<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.EtiquetasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmisiónDeEtiquetasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EtiquetasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(718, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EtiquetasToolStripMenuItem
        '
        Me.EtiquetasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmisiónDeEtiquetasToolStripMenuItem, Me.EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem, Me.PruebaToolStripMenuItem})
        Me.EtiquetasToolStripMenuItem.Name = "EtiquetasToolStripMenuItem"
        Me.EtiquetasToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.EtiquetasToolStripMenuItem.Text = "Etiquetas"
        '
        'EmisiónDeEtiquetasToolStripMenuItem
        '
        Me.EmisiónDeEtiquetasToolStripMenuItem.Name = "EmisiónDeEtiquetasToolStripMenuItem"
        Me.EmisiónDeEtiquetasToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.EmisiónDeEtiquetasToolStripMenuItem.Text = "Emisión de Etiquetas"
        '
        'EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem
        '
        Me.EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem.Name = "EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem"
        Me.EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem.Text = "Emisión de Etiquetas de Preenvasado"
        '
        'PruebaToolStripMenuItem
        '
        Me.PruebaToolStripMenuItem.Name = "PruebaToolStripMenuItem"
        Me.PruebaToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.PruebaToolStripMenuItem.Text = "prueba"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 380)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EtiquetasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmisiónDeEtiquetasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmisiónDeEtiquetasDePreenvasadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PruebaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
