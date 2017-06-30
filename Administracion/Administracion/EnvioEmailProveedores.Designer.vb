<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioEmailProveedores
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuerpoEmail = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraI = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraII = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraIII = New System.Windows.Forms.TextBox()
        Me.txtLineaExtraIV = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.txtNombreArchivoAdjunto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OFDAdjuntarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 50)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(475, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Envío de Email a Proveedores"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(40, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Asunto:"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(105, 63)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(474, 20)
        Me.txtAsunto.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(33, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Mensaje:"
        '
        'txtCuerpoEmail
        '
        Me.txtCuerpoEmail.Location = New System.Drawing.Point(106, 102)
        Me.txtCuerpoEmail.Multiline = True
        Me.txtCuerpoEmail.Name = "txtCuerpoEmail"
        Me.txtCuerpoEmail.Size = New System.Drawing.Size(473, 179)
        Me.txtCuerpoEmail.TabIndex = 5
        '
        'txtLineaExtraI
        '
        Me.txtLineaExtraI.Location = New System.Drawing.Point(106, 287)
        Me.txtLineaExtraI.Name = "txtLineaExtraI"
        Me.txtLineaExtraI.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraI.TabIndex = 6
        '
        'txtLineaExtraII
        '
        Me.txtLineaExtraII.Location = New System.Drawing.Point(105, 313)
        Me.txtLineaExtraII.Name = "txtLineaExtraII"
        Me.txtLineaExtraII.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraII.TabIndex = 6
        '
        'txtLineaExtraIII
        '
        Me.txtLineaExtraIII.Location = New System.Drawing.Point(106, 339)
        Me.txtLineaExtraIII.Name = "txtLineaExtraIII"
        Me.txtLineaExtraIII.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraIII.TabIndex = 6
        '
        'txtLineaExtraIV
        '
        Me.txtLineaExtraIV.Location = New System.Drawing.Point(105, 365)
        Me.txtLineaExtraIV.Name = "txtLineaExtraIV"
        Me.txtLineaExtraIV.Size = New System.Drawing.Size(473, 20)
        Me.txtLineaExtraIV.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAdjuntar)
        Me.Panel2.Controls.Add(Me.txtNombreArchivoAdjunto)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(0, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(649, 402)
        Me.Panel2.TabIndex = 8
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.AllowDrop = True
        Me.btnAdjuntar.BackgroundImage = Global.Administracion.My.Resources.Resources.Attachment
        Me.btnAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAdjuntar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdjuntar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatAppearance.BorderSize = 0
        Me.btnAdjuntar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjuntar.Location = New System.Drawing.Point(21, 339)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(66, 52)
        Me.btnAdjuntar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAdjuntar, "Adjuntar un Archivo al Email")
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'txtNombreArchivoAdjunto
        '
        Me.txtNombreArchivoAdjunto.AllowDrop = True
        Me.txtNombreArchivoAdjunto.Location = New System.Drawing.Point(221, 358)
        Me.txtNombreArchivoAdjunto.Name = "txtNombreArchivoAdjunto"
        Me.txtNombreArchivoAdjunto.ReadOnly = True
        Me.txtNombreArchivoAdjunto.Size = New System.Drawing.Size(357, 20)
        Me.txtNombreArchivoAdjunto.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(103, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Archivo Adjunto:"
        '
        'OFDAdjuntarArchivo
        '
        Me.OFDAdjuntarArchivo.FileName = "OpenFileDialog1"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Administracion.My.Resources.Resources.Salir2
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(322, 459)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(117, 48)
        Me.btnCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar Envio de Email")
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.Administracion.My.Resources.Resources.exportar
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.BorderSize = 0
        Me.btnEnviar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Location = New System.Drawing.Point(199, 459)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(117, 48)
        Me.btnEnviar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnEnviar, "Enviar Email")
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'EnvioEmailProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 524)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtLineaExtraIV)
        Me.Controls.Add(Me.txtLineaExtraIII)
        Me.Controls.Add(Me.txtLineaExtraII)
        Me.Controls.Add(Me.txtLineaExtraI)
        Me.Controls.Add(Me.txtCuerpoEmail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAsunto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.Name = "EnvioEmailProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCuerpoEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraI As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraII As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraIII As System.Windows.Forms.TextBox
    Friend WithEvents txtLineaExtraIV As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents OFDAdjuntarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtNombreArchivoAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
