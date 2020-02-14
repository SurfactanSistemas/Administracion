<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmisionEtiquetaPreenvasado
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTerminado = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescTerminado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCantidadPorEnvase = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCantEtiq = New System.Windows.Forms.TextBox()
        Me.btnEmitir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(557, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(371, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(30, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMISIÓN DE ETIQUETAS (PREENVASADO)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Partida:"
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(52, 61)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(47, 20)
        Me.txtLote.TabIndex = 4
        Me.txtLote.Text = "999999"
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(103, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Terminado:"
        '
        'txtTerminado
        '
        Me.txtTerminado.Location = New System.Drawing.Point(169, 62)
        Me.txtTerminado.Mask = ">LL-99999-999"
        Me.txtTerminado.Name = "txtTerminado"
        Me.txtTerminado.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTerminado.Size = New System.Drawing.Size(78, 20)
        Me.txtTerminado.TabIndex = 5
        Me.txtTerminado.Text = "PT99999999"
        '
        'txtDescTerminado
        '
        Me.txtDescTerminado.Location = New System.Drawing.Point(253, 61)
        Me.txtDescTerminado.Name = "txtDescTerminado"
        Me.txtDescTerminado.Size = New System.Drawing.Size(292, 20)
        Me.txtDescTerminado.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Cantidad (Kgs.):"
        '
        'txtCantidadPorEnvase
        '
        Me.txtCantidadPorEnvase.Location = New System.Drawing.Point(95, 91)
        Me.txtCantidadPorEnvase.Name = "txtCantidadPorEnvase"
        Me.txtCantidadPorEnvase.Size = New System.Drawing.Size(47, 20)
        Me.txtCantidadPorEnvase.TabIndex = 4
        Me.txtCantidadPorEnvase.Text = "999999"
        Me.txtCantidadPorEnvase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(165, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cantidad Etiquetas:"
        '
        'txtCantEtiq
        '
        Me.txtCantEtiq.Location = New System.Drawing.Point(270, 91)
        Me.txtCantEtiq.Name = "txtCantEtiq"
        Me.txtCantEtiq.Size = New System.Drawing.Size(47, 20)
        Me.txtCantEtiq.TabIndex = 4
        Me.txtCantEtiq.Text = "999999"
        Me.txtCantEtiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEmitir
        '
        Me.btnEmitir.Location = New System.Drawing.Point(100, 120)
        Me.btnEmitir.Name = "btnEmitir"
        Me.btnEmitir.Size = New System.Drawing.Size(115, 41)
        Me.btnEmitir.TabIndex = 6
        Me.btnEmitir.Text = "EMITIR ETIQ."
        Me.btnEmitir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(221, 120)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(115, 41)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(342, 120)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(115, 41)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'EmisionEtiquetaPreenvasado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 168)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnEmitir)
        Me.Controls.Add(Me.txtTerminado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescTerminado)
        Me.Controls.Add(Me.txtCantEtiq)
        Me.Controls.Add(Me.txtCantidadPorEnvase)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EmisionEtiquetaPreenvasado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTerminado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescTerminado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPorEnvase As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents btnEmitir As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
