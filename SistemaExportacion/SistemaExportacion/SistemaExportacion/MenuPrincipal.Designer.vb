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
        Me.components = New System.ComponentModel.Container()
        Me.LayoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LayoutCuerpoPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnHistorialProforma = New System.Windows.Forms.Button()
        Me.btnNuevaProforma = New System.Windows.Forms.Button()
        Me.LayoutFiltros = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LayoutPrincipal.SuspendLayout()
        Me.LayoutCabecera.SuspendLayout()
        Me.LayoutCuerpoPrincipal.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPrincipal
        '
        Me.LayoutPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.LayoutPrincipal.ColumnCount = 1
        Me.LayoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCabecera, 0, 0)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutCuerpoPrincipal, 0, 2)
        Me.LayoutPrincipal.Controls.Add(Me.LayoutFiltros, 0, 1)
        Me.LayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutPrincipal.Name = "LayoutPrincipal"
        Me.LayoutPrincipal.RowCount = 3
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.LayoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPrincipal.Size = New System.Drawing.Size(826, 479)
        Me.LayoutPrincipal.TabIndex = 0
        '
        'LayoutCabecera
        '
        Me.LayoutCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LayoutCabecera.ColumnCount = 3
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.LayoutCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.LayoutCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.LayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCabecera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutCabecera.ForeColor = System.Drawing.SystemColors.Control
        Me.LayoutCabecera.Location = New System.Drawing.Point(0, 0)
        Me.LayoutCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCabecera.Name = "LayoutCabecera"
        Me.LayoutCabecera.RowCount = 1
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.LayoutCabecera.Size = New System.Drawing.Size(826, 45)
        Me.LayoutCabecera.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sistema de Exportaciones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(649, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutCuerpoPrincipal
        '
        Me.LayoutCuerpoPrincipal.ColumnCount = 2
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.LayoutCuerpoPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.DataGridView1, 1, 0)
        Me.LayoutCuerpoPrincipal.Controls.Add(Me.Panel1, 0, 0)
        Me.LayoutCuerpoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutCuerpoPrincipal.Location = New System.Drawing.Point(0, 91)
        Me.LayoutCuerpoPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutCuerpoPrincipal.Name = "LayoutCuerpoPrincipal"
        Me.LayoutCuerpoPrincipal.RowCount = 1
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutCuerpoPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 388.0!))
        Me.LayoutCuerpoPrincipal.Size = New System.Drawing.Size(826, 388)
        Me.LayoutCuerpoPrincipal.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(99, 15)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(712, 358)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnHistorialProforma)
        Me.Panel1.Controls.Add(Me.btnNuevaProforma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(84, 388)
        Me.Panel1.TabIndex = 1
        '
        'btnHistorialProforma
        '
        Me.btnHistorialProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHistorialProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHistorialProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistorialProforma.Location = New System.Drawing.Point(5, 89)
        Me.btnHistorialProforma.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnHistorialProforma.Name = "btnHistorialProforma"
        Me.btnHistorialProforma.Size = New System.Drawing.Size(74, 56)
        Me.btnHistorialProforma.TabIndex = 3
        Me.btnHistorialProforma.Text = "Historial de Proforma"
        Me.ToolTip1.SetToolTip(Me.btnHistorialProforma, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btnHistorialProforma.UseVisualStyleBackColor = True
        '
        'btnNuevaProforma
        '
        Me.btnNuevaProforma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevaProforma.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaProforma.Location = New System.Drawing.Point(5, 24)
        Me.btnNuevaProforma.Margin = New System.Windows.Forms.Padding(10, 10, 0, 10)
        Me.btnNuevaProforma.Name = "btnNuevaProforma"
        Me.btnNuevaProforma.Size = New System.Drawing.Size(74, 56)
        Me.btnNuevaProforma.TabIndex = 2
        Me.btnNuevaProforma.Text = "Nueva Proforma"
        Me.ToolTip1.SetToolTip(Me.btnNuevaProforma, "Abrir Formulario para Alta / Consulta de Proforma")
        Me.btnNuevaProforma.UseVisualStyleBackColor = True
        '
        'LayoutFiltros
        '
        Me.LayoutFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.LayoutFiltros.ColumnCount = 1
        Me.LayoutFiltros.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.LayoutFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutFiltros.Location = New System.Drawing.Point(0, 45)
        Me.LayoutFiltros.Margin = New System.Windows.Forms.Padding(0)
        Me.LayoutFiltros.Name = "LayoutFiltros"
        Me.LayoutFiltros.RowCount = 1
        Me.LayoutFiltros.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.LayoutFiltros.Size = New System.Drawing.Size(826, 46)
        Me.LayoutFiltros.TabIndex = 2
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 479)
        Me.Controls.Add(Me.LayoutPrincipal)
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.LayoutPrincipal.ResumeLayout(False)
        Me.LayoutCabecera.ResumeLayout(False)
        Me.LayoutCuerpoPrincipal.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LayoutCuerpoPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LayoutFiltros As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnHistorialProforma As System.Windows.Forms.Button
    Friend WithEvents btnNuevaProforma As System.Windows.Forms.Button

End Class
