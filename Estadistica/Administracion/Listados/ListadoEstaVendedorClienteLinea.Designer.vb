<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoEstaVendedorClienteLinea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoEstaVendedorClienteLinea))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.P_Buscar = New System.Windows.Forms.Panel()
        Me.TipoCosto = New Esta.CustomComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDesdeVendedor = New System.Windows.Forms.TextBox()
        Me.txthastafecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtHastaVendedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBErrorFecha = New System.Windows.Forms.Label()
        Me.LBError = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btnImpresora = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstAyuda = New Esta.CustomListBox()
        Me.txtAyuda = New Esta.CustomTextBox()
        Me.lstFiltrada = New Esta.CustomListBox()
        Me.P_Buscar.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 202)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(526, 29)
        Me.ProgressBar1.TabIndex = 88
        Me.ProgressBar1.Visible = False
        '
        'btnPantalla
        '
        Me.btnPantalla.AutoSize = True
        Me.btnPantalla.BackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.BackgroundImage = CType(resources.GetObject("btnPantalla.BackgroundImage"), System.Drawing.Image)
        Me.btnPantalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPantalla.FlatAppearance.BorderSize = 0
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPantalla.Location = New System.Drawing.Point(176, 123)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(72, 72)
        Me.btnPantalla.TabIndex = 87
        Me.ToolTip1.SetToolTip(Me.btnPantalla, "Generacion del Reporte por Pantalla")
        Me.btnPantalla.UseVisualStyleBackColor = False
        '
        'btnConsulta
        '
        Me.btnConsulta.AutoSize = True
        Me.btnConsulta.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsulta.BackgroundImage = CType(resources.GetObject("btnConsulta.BackgroundImage"), System.Drawing.Image)
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.Location = New System.Drawing.Point(49, 123)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(72, 72)
        Me.btnConsulta.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.btnConsulta, "Ayuda de Busqueda de Vendedores")
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'P_Buscar
        '
        Me.P_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.P_Buscar.Controls.Add(Me.TipoCosto)
        Me.P_Buscar.Controls.Add(Me.Label5)
        Me.P_Buscar.Controls.Add(Me.txtDesdeVendedor)
        Me.P_Buscar.Controls.Add(Me.txthastafecha)
        Me.P_Buscar.Controls.Add(Me.txtDesdeFecha)
        Me.P_Buscar.Controls.Add(Me.txtHastaVendedor)
        Me.P_Buscar.Controls.Add(Me.Label2)
        Me.P_Buscar.Controls.Add(Me.LBErrorFecha)
        Me.P_Buscar.Controls.Add(Me.LBError)
        Me.P_Buscar.Controls.Add(Me.label1)
        Me.P_Buscar.Location = New System.Drawing.Point(0, 30)
        Me.P_Buscar.Name = "P_Buscar"
        Me.P_Buscar.Size = New System.Drawing.Size(571, 78)
        Me.P_Buscar.TabIndex = 85
        '
        'TipoCosto
        '
        Me.TipoCosto.Cleanable = False
        Me.TipoCosto.Empty = False
        Me.TipoCosto.EnterIndex = -1
        Me.TipoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoCosto.FormattingEnabled = True
        Me.TipoCosto.LabelAssociationKey = -1
        Me.TipoCosto.Location = New System.Drawing.Point(103, 39)
        Me.TipoCosto.Name = "TipoCosto"
        Me.TipoCosto.Size = New System.Drawing.Size(151, 21)
        Me.TipoCosto.TabIndex = 85
        Me.TipoCosto.Validator = Esta.ValidatorType.None
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 18)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Tipo de Costo"
        '
        'txtDesdeVendedor
        '
        Me.txtDesdeVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesdeVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeVendedor.Location = New System.Drawing.Point(103, 14)
        Me.txtDesdeVendedor.MaxLength = 4
        Me.txtDesdeVendedor.Name = "txtDesdeVendedor"
        Me.txtDesdeVendedor.Size = New System.Drawing.Size(74, 20)
        Me.txtDesdeVendedor.TabIndex = 83
        Me.txtDesdeVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txthastafecha
        '
        Me.txthastafecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthastafecha.Location = New System.Drawing.Point(436, 14)
        Me.txthastafecha.Mask = "##/##/####"
        Me.txthastafecha.Name = "txthastafecha"
        Me.txthastafecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txthastafecha.Size = New System.Drawing.Size(95, 20)
        Me.txthastafecha.TabIndex = 4
        '
        'txtDesdeFecha
        '
        Me.txtDesdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeFecha.Location = New System.Drawing.Point(332, 14)
        Me.txtDesdeFecha.Mask = "##/##/####"
        Me.txtDesdeFecha.Name = "txtDesdeFecha"
        Me.txtDesdeFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDesdeFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtDesdeFecha.TabIndex = 3
        '
        'txtHastaVendedor
        '
        Me.txtHastaVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHastaVendedor.Location = New System.Drawing.Point(183, 14)
        Me.txtHastaVendedor.MaxLength = 4
        Me.txtHastaVendedor.Name = "txtHastaVendedor"
        Me.txtHastaVendedor.Size = New System.Drawing.Size(74, 20)
        Me.txtHastaVendedor.TabIndex = 1
        Me.txtHastaVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(273, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Fecha"
        '
        'LBErrorFecha
        '
        Me.LBErrorFecha.AutoSize = True
        Me.LBErrorFecha.ForeColor = System.Drawing.Color.DarkRed
        Me.LBErrorFecha.Location = New System.Drawing.Point(12, 39)
        Me.LBErrorFecha.Name = "LBErrorFecha"
        Me.LBErrorFecha.Size = New System.Drawing.Size(11, 13)
        Me.LBErrorFecha.TabIndex = 10
        Me.LBErrorFecha.Text = "*"
        '
        'LBError
        '
        Me.LBError.AutoSize = True
        Me.LBError.Location = New System.Drawing.Point(73, 56)
        Me.LBError.Name = "LBError"
        Me.LBError.Size = New System.Drawing.Size(0, 13)
        Me.LBError.TabIndex = 9
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.label1.Location = New System.Drawing.Point(13, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(69, 18)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Vendedor"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(571, 31)
        Me.panel1.TabIndex = 84
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(3, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(358, 19)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Listado de Estadistica por Vendedor, Cliente y Linea"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(415, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(156, 26)
        Me.label3.TabIndex = 0
        Me.label3.Text = "SURFACTAN S.A."
        '
        'btnImpresora
        '
        Me.btnImpresora.AutoSize = True
        Me.btnImpresora.BackColor = System.Drawing.SystemColors.Control
        Me.btnImpresora.BackgroundImage = Global.Esta.My.Resources.Resources.imprimir
        Me.btnImpresora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnImpresora.FlatAppearance.BorderSize = 0
        Me.btnImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpresora.Location = New System.Drawing.Point(303, 124)
        Me.btnImpresora.Name = "btnImpresora"
        Me.btnImpresora.Size = New System.Drawing.Size(72, 72)
        Me.btnImpresora.TabIndex = 82
        Me.ToolTip1.SetToolTip(Me.btnImpresora, "Generacion del Reporte por Impresora")
        Me.btnImpresora.UseVisualStyleBackColor = False
        '
        'btnCancela
        '
        Me.btnCancela.AutoSize = True
        Me.btnCancela.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancela.BackgroundImage = Global.Esta.My.Resources.Resources.Salir1
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancela.Location = New System.Drawing.Point(441, 123)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(101, 73)
        Me.btnCancela.TabIndex = 83
        Me.btnCancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.btnCancela, "Menu Principal")
        Me.btnCancela.UseVisualStyleBackColor = False
        '
        'lstAyuda
        '
        Me.lstAyuda.Cleanable = False
        Me.lstAyuda.EnterIndex = -1
        Me.lstAyuda.FormattingEnabled = True
        Me.lstAyuda.LabelAssociationKey = -1
        Me.lstAyuda.Location = New System.Drawing.Point(12, 270)
        Me.lstAyuda.Name = "lstAyuda"
        Me.lstAyuda.Size = New System.Drawing.Size(526, 121)
        Me.lstAyuda.TabIndex = 89
        Me.lstAyuda.Visible = False
        '
        'txtAyuda
        '
        Me.txtAyuda.Cleanable = False
        Me.txtAyuda.Empty = True
        Me.txtAyuda.EnterIndex = -1
        Me.txtAyuda.LabelAssociationKey = -1
        Me.txtAyuda.Location = New System.Drawing.Point(12, 244)
        Me.txtAyuda.Name = "txtAyuda"
        Me.txtAyuda.Size = New System.Drawing.Size(526, 20)
        Me.txtAyuda.TabIndex = 90
        Me.txtAyuda.Validator = Esta.ValidatorType.None
        Me.txtAyuda.Visible = False
        '
        'lstFiltrada
        '
        Me.lstFiltrada.Cleanable = False
        Me.lstFiltrada.EnterIndex = -1
        Me.lstFiltrada.FormattingEnabled = True
        Me.lstFiltrada.LabelAssociationKey = -1
        Me.lstFiltrada.Location = New System.Drawing.Point(12, 270)
        Me.lstFiltrada.Name = "lstFiltrada"
        Me.lstFiltrada.Size = New System.Drawing.Size(526, 121)
        Me.lstFiltrada.TabIndex = 91
        Me.lstFiltrada.Visible = False
        '
        'ListadoEstaVendedorClienteLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 243)
        Me.Controls.Add(Me.lstFiltrada)
        Me.Controls.Add(Me.lstAyuda)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnPantalla)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.P_Buscar)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btnImpresora)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.txtAyuda)
        Me.Name = "ListadoEstaVendedorClienteLinea"
        Me.P_Buscar.ResumeLayout(False)
        Me.P_Buscar.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Private WithEvents P_Buscar As System.Windows.Forms.Panel
    Friend WithEvents txtDesdeVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txthastafecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDesdeFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHastaVendedor As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents LBErrorFecha As System.Windows.Forms.Label
    Private WithEvents LBError As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents btnImpresora As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtAyuda As Esta.CustomTextBox
    Friend WithEvents lstAyuda As Esta.CustomListBox
    Friend WithEvents TipoCosto As Esta.CustomComboBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstFiltrada As Esta.CustomListBox
End Class
