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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MateriasPrimasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaPorCódigoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaPorLaudoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosTerminadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaPorCódigoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaPorHojaDeProducciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.VerDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinDeSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(849, 50)
        Me.Panel1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(709, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "- MENÚ PRINCIPAL -"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(349, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SISTEMA DE INVESTIGACIÓN Y SEGUIMIENTO"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultasToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 50)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(849, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MateriasPrimasToolStripMenuItem, Me.ProductosTerminadosToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ConsultasToolStripMenuItem.Text = "Consultas"
        '
        'MateriasPrimasToolStripMenuItem
        '
        Me.MateriasPrimasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultaPorCódigoToolStripMenuItem, Me.ConsultaPorLaudoToolStripMenuItem})
        Me.MateriasPrimasToolStripMenuItem.Name = "MateriasPrimasToolStripMenuItem"
        Me.MateriasPrimasToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.MateriasPrimasToolStripMenuItem.Text = "Materias Primas"
        '
        'ConsultaPorCódigoToolStripMenuItem
        '
        Me.ConsultaPorCódigoToolStripMenuItem.Name = "ConsultaPorCódigoToolStripMenuItem"
        Me.ConsultaPorCódigoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ConsultaPorCódigoToolStripMenuItem.Text = "Consulta por Código"
        '
        'ConsultaPorLaudoToolStripMenuItem
        '
        Me.ConsultaPorLaudoToolStripMenuItem.Name = "ConsultaPorLaudoToolStripMenuItem"
        Me.ConsultaPorLaudoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ConsultaPorLaudoToolStripMenuItem.Text = "Consulta por Laudo"
        '
        'ProductosTerminadosToolStripMenuItem
        '
        Me.ProductosTerminadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultaPorCódigoToolStripMenuItem1, Me.ConsultaPorHojaDeProducciónToolStripMenuItem, Me.ToolStripSeparator1, Me.VerDevolucionesToolStripMenuItem})
        Me.ProductosTerminadosToolStripMenuItem.Name = "ProductosTerminadosToolStripMenuItem"
        Me.ProductosTerminadosToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ProductosTerminadosToolStripMenuItem.Text = "Productos Terminados"
        '
        'ConsultaPorCódigoToolStripMenuItem1
        '
        Me.ConsultaPorCódigoToolStripMenuItem1.Name = "ConsultaPorCódigoToolStripMenuItem1"
        Me.ConsultaPorCódigoToolStripMenuItem1.Size = New System.Drawing.Size(277, 22)
        Me.ConsultaPorCódigoToolStripMenuItem1.Text = "Consulta Por Código"
        '
        'ConsultaPorHojaDeProducciónToolStripMenuItem
        '
        Me.ConsultaPorHojaDeProducciónToolStripMenuItem.Name = "ConsultaPorHojaDeProducciónToolStripMenuItem"
        Me.ConsultaPorHojaDeProducciónToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ConsultaPorHojaDeProducciónToolStripMenuItem.Text = "Consulta por Hoja de Producción"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(274, 6)
        '
        'VerDevolucionesToolStripMenuItem
        '
        Me.VerDevolucionesToolStripMenuItem.Name = "VerDevolucionesToolStripMenuItem"
        Me.VerDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.VerDevolucionesToolStripMenuItem.Text = "Ver Devoluciones por Código o Partida"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FinDeSistemaToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'FinDeSistemaToolStripMenuItem
        '
        Me.FinDeSistemaToolStripMenuItem.Name = "FinDeSistemaToolStripMenuItem"
        Me.FinDeSistemaToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.FinDeSistemaToolStripMenuItem.Text = "Fin de Sistema"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 430)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinDeSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MateriasPrimasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaPorCódigoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosTerminadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaPorCódigoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerDevolucionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaPorLaudoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaPorHojaDeProducciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
