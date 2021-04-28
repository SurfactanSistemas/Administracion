<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mail_Reclamo_Historial
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DGV_HistorialMails = New Util.DBDataGridView()
        Me.Envio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Asunto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuerpo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1.SuspendLayout()
        CType(Me.DGV_HistorialMails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(900, 49)
        Me.panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(665, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(28, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(173, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "HISTORIAL MAILS "
        '
        'DGV_HistorialMails
        '
        Me.DGV_HistorialMails.AllowUserToAddRows = False
        Me.DGV_HistorialMails.AllowUserToDeleteRows = False
        Me.DGV_HistorialMails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_HistorialMails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Envio, Me.Asunto, Me.Cuerpo, Me.NumeroMail})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_HistorialMails.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_HistorialMails.DoubleBuffered = True
        Me.DGV_HistorialMails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_HistorialMails.Location = New System.Drawing.Point(16, 57)
        Me.DGV_HistorialMails.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_HistorialMails.Name = "DGV_HistorialMails"
        Me.DGV_HistorialMails.OrdenamientoColumnasHabilitado = True
        Me.DGV_HistorialMails.RowHeadersWidth = 15
        Me.DGV_HistorialMails.RowTemplate.Height = 80
        Me.DGV_HistorialMails.ShowCellToolTips = False
        Me.DGV_HistorialMails.SinClickDerecho = False
        Me.DGV_HistorialMails.Size = New System.Drawing.Size(868, 411)
        Me.DGV_HistorialMails.TabIndex = 8
        '
        'Envio
        '
        Me.Envio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Envio.DataPropertyName = "Envio"
        Me.Envio.HeaderText = "Envio"
        Me.Envio.Name = "Envio"
        Me.Envio.Width = 72
        '
        'Asunto
        '
        Me.Asunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Asunto.DataPropertyName = "Asunto"
        Me.Asunto.HeaderText = "Asunto"
        Me.Asunto.Name = "Asunto"
        Me.Asunto.Width = 81
        '
        'Cuerpo
        '
        Me.Cuerpo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cuerpo.DataPropertyName = "Cuerpo"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cuerpo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cuerpo.HeaderText = "Cuerpo"
        Me.Cuerpo.Name = "Cuerpo"
        '
        'NumeroMail
        '
        Me.NumeroMail.DataPropertyName = "NumeroMail"
        Me.NumeroMail.HeaderText = "NumeroMail"
        Me.NumeroMail.Name = "NumeroMail"
        Me.NumeroMail.Visible = False
        '
        'Mail_Reclamo_Historial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 482)
        Me.Controls.Add(Me.DGV_HistorialMails)
        Me.Controls.Add(Me.panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Mail_Reclamo_Historial"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DGV_HistorialMails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_HistorialMails As Util.DBDataGridView
    Friend WithEvents Envio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Asunto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuerpo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroMail As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
