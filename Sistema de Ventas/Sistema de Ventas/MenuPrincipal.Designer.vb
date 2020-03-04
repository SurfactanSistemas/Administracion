<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoRubroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoVendedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CondicionDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoDeLineasDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoDeEnvasesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidosPendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinDeSistemasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoDeGastosDeImportacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        Me.panel1.Size = New System.Drawing.Size(785, 40)
        Me.panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(609, 10)
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
        Me.label1.Size = New System.Drawing.Size(166, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "SISTEMA DE VENTAS"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaestrosToolStripMenuItem, Me.NovedadesToolStripMenuItem, Me.ListadosToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 40)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(785, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MaestrosToolStripMenuItem
        '
        Me.MaestrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresoRubroToolStripMenuItem, Me.IngresoVendedoresToolStripMenuItem, Me.CondicionDePagoToolStripMenuItem, Me.IngresoDeLineasDeVentasToolStripMenuItem, Me.IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem, Me.IngresoDeEnvasesToolStripMenuItem, Me.IngresoDeGastosDeImportacionToolStripMenuItem})
        Me.MaestrosToolStripMenuItem.Name = "MaestrosToolStripMenuItem"
        Me.MaestrosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.MaestrosToolStripMenuItem.Text = "Maestros"
        '
        'IngresoRubroToolStripMenuItem
        '
        Me.IngresoRubroToolStripMenuItem.Name = "IngresoRubroToolStripMenuItem"
        Me.IngresoRubroToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoRubroToolStripMenuItem.Text = "Ingreso Rubro"
        '
        'IngresoVendedoresToolStripMenuItem
        '
        Me.IngresoVendedoresToolStripMenuItem.Name = "IngresoVendedoresToolStripMenuItem"
        Me.IngresoVendedoresToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoVendedoresToolStripMenuItem.Text = "Ingreso Vendedores"
        '
        'CondicionDePagoToolStripMenuItem
        '
        Me.CondicionDePagoToolStripMenuItem.Name = "CondicionDePagoToolStripMenuItem"
        Me.CondicionDePagoToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.CondicionDePagoToolStripMenuItem.Text = "Ingreso de  Condiciones de Pago"
        '
        'IngresoDeLineasDeVentasToolStripMenuItem
        '
        Me.IngresoDeLineasDeVentasToolStripMenuItem.Name = "IngresoDeLineasDeVentasToolStripMenuItem"
        Me.IngresoDeLineasDeVentasToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoDeLineasDeVentasToolStripMenuItem.Text = "Ingreso de Lineas de Ventas"
        '
        'IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem
        '
        Me.IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem.Name = "IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem"
        Me.IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem.Text = "Ingreso de Familias de Materias Primas"
        '
        'IngresoDeEnvasesToolStripMenuItem
        '
        Me.IngresoDeEnvasesToolStripMenuItem.Name = "IngresoDeEnvasesToolStripMenuItem"
        Me.IngresoDeEnvasesToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoDeEnvasesToolStripMenuItem.Text = "Ingreso de Envases"
        '
        'NovedadesToolStripMenuItem
        '
        Me.NovedadesToolStripMenuItem.Name = "NovedadesToolStripMenuItem"
        Me.NovedadesToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.NovedadesToolStripMenuItem.Text = "Novedades"
        '
        'ListadosToolStripMenuItem
        '
        Me.ListadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PedidosPendientesToolStripMenuItem})
        Me.ListadosToolStripMenuItem.Name = "ListadosToolStripMenuItem"
        Me.ListadosToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ListadosToolStripMenuItem.Text = "Listados"
        '
        'PedidosPendientesToolStripMenuItem
        '
        Me.PedidosPendientesToolStripMenuItem.Name = "PedidosPendientesToolStripMenuItem"
        Me.PedidosPendientesToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PedidosPendientesToolStripMenuItem.Text = "Pedidos Pendientes"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FinDeSistemasToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'FinDeSistemasToolStripMenuItem
        '
        Me.FinDeSistemasToolStripMenuItem.Name = "FinDeSistemasToolStripMenuItem"
        Me.FinDeSistemasToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.FinDeSistemasToolStripMenuItem.Text = "Fin de Sistema"
        '
        'IngresoDeGastosDeImportacionToolStripMenuItem
        '
        Me.IngresoDeGastosDeImportacionToolStripMenuItem.Name = "IngresoDeGastosDeImportacionToolStripMenuItem"
        Me.IngresoDeGastosDeImportacionToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.IngresoDeGastosDeImportacionToolStripMenuItem.Text = "Ingreso de Gastos de Importacion"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 475)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.panel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MaestrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NovedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinDeSistemasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosPendientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoRubroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoVendedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CondicionDePagoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoDeLineasDeVentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoDeEnvasesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoDeGastosDeImportacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
