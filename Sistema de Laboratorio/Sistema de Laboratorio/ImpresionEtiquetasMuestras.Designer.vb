﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionEtiquetasMuestras
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
        Me.txtInforme = New System.Windows.Forms.TextBox()
        Me.txtDescripcionMP = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtAnalista = New System.Windows.Forms.TextBox()
        Me.TxtCantEtiq = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.mastxtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.LtbMP = New System.Windows.Forms.ListBox()
        Me.txtCodigoMP = New System.Windows.Forms.TextBox()
        Me.LtbLotes = New System.Windows.Forms.ListBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(144, 94)
        Me.txtInforme.MaxLength = 6
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.Size = New System.Drawing.Size(100, 20)
        Me.txtInforme.TabIndex = 0
        '
        'txtDescripcionMP
        '
        Me.txtDescripcionMP.BackColor = System.Drawing.Color.Cyan
        Me.txtDescripcionMP.Enabled = False
        Me.txtDescripcionMP.Location = New System.Drawing.Point(250, 131)
        Me.txtDescripcionMP.Name = "txtDescripcionMP"
        Me.txtDescripcionMP.Size = New System.Drawing.Size(262, 20)
        Me.txtDescripcionMP.TabIndex = 2
        '
        'txtLote
        '
        Me.txtLote.Enabled = False
        Me.txtLote.Location = New System.Drawing.Point(144, 176)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(100, 20)
        Me.txtLote.TabIndex = 3
        '
        'txtAnalista
        '
        Me.txtAnalista.Location = New System.Drawing.Point(144, 259)
        Me.txtAnalista.Name = "txtAnalista"
        Me.txtAnalista.Size = New System.Drawing.Size(100, 20)
        Me.txtAnalista.TabIndex = 5
        '
        'TxtCantEtiq
        '
        Me.TxtCantEtiq.Location = New System.Drawing.Point(144, 304)
        Me.TxtCantEtiq.Name = "TxtCantEtiq"
        Me.TxtCantEtiq.Size = New System.Drawing.Size(100, 20)
        Me.TxtCantEtiq.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Informe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Materia Prima"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Lote de Proveedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(79, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Analista"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cantidad de Etiquetas"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 77)
        Me.Panel1.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(11, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(283, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Emision de Etiquetas de Muestras"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(348, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 24)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SURFACTAN S.A."
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(343, 301)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(391, 262)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(437, 301)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 16
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'mastxtFecha
        '
        Me.mastxtFecha.Location = New System.Drawing.Point(144, 218)
        Me.mastxtFecha.Mask = ">00/00/0000"
        Me.mastxtFecha.Name = "mastxtFecha"
        Me.mastxtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mastxtFecha.Size = New System.Drawing.Size(100, 20)
        Me.mastxtFecha.TabIndex = 17
        Me.mastxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LtbMP
        '
        Me.LtbMP.FormattingEnabled = True
        Me.LtbMP.Location = New System.Drawing.Point(144, 131)
        Me.LtbMP.Name = "LtbMP"
        Me.LtbMP.Size = New System.Drawing.Size(293, 82)
        Me.LtbMP.TabIndex = 18
        '
        'txtCodigoMP
        '
        Me.txtCodigoMP.Enabled = False
        Me.txtCodigoMP.Location = New System.Drawing.Point(144, 131)
        Me.txtCodigoMP.Name = "txtCodigoMP"
        Me.txtCodigoMP.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoMP.TabIndex = 1
        '
        'LtbLotes
        '
        Me.LtbLotes.FormattingEnabled = True
        Me.LtbLotes.Location = New System.Drawing.Point(144, 176)
        Me.LtbLotes.Name = "LtbLotes"
        Me.LtbLotes.Size = New System.Drawing.Size(293, 82)
        Me.LtbLotes.TabIndex = 19
        '
        'ImpresionEtiquetasMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 346)
        Me.Controls.Add(Me.LtbLotes)
        Me.Controls.Add(Me.LtbMP)
        Me.Controls.Add(Me.mastxtFecha)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCantEtiq)
        Me.Controls.Add(Me.txtAnalista)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.txtDescripcionMP)
        Me.Controls.Add(Me.txtCodigoMP)
        Me.Controls.Add(Me.txtInforme)
        Me.Name = "ImpresionEtiquetasMuestras"
        Me.Text = "ImpresionEtiquetasMuestras"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInforme As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionMP As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtAnalista As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents mastxtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LtbMP As System.Windows.Forms.ListBox
    Friend WithEvents txtCodigoMP As System.Windows.Forms.TextBox
    Friend WithEvents LtbLotes As System.Windows.Forms.ListBox
End Class
