﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionPlanillaEnsayosMP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvEspecif = New ConsultasVarias.DBDataGridView()
        Me.Ensayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescParametros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(593, 49)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(403, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SURFACTAN S.A."
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(363, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PLANILLA DE ENSAYOS A REALIZAR EN LABORATORIO"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(172, 291)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(116, 45)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCodigo.Location = New System.Drawing.Point(81, 56)
        Me.txtCodigo.Mask = ">LL-000-000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCodigo.Size = New System.Drawing.Size(65, 20)
        Me.txtCodigo.TabIndex = 6
        Me.txtCodigo.Text = "PT999999"
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescripcion.BackColor = System.Drawing.Color.Cyan
        Me.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(150, 55)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(432, 23)
        Me.lblDescripcion.TabIndex = 5
        Me.lblDescripcion.Text = "Código:"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAyuda
        '
        Me.btnAyuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAyuda.BackgroundImage = Global.Laboratorio.My.Resources.Resources.Consulta_Dat_N1
        Me.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAyuda.FlatAppearance.BorderSize = 0
        Me.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyuda.Location = New System.Drawing.Point(53, 56)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(24, 21)
        Me.btnAyuda.TabIndex = 4
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(304, 291)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(116, 45)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'dgvEspecif
        '
        Me.dgvEspecif.AllowUserToAddRows = False
        Me.dgvEspecif.AllowUserToDeleteRows = False
        Me.dgvEspecif.AllowUserToOrderColumns = True
        Me.dgvEspecif.AllowUserToResizeColumns = False
        Me.dgvEspecif.AllowUserToResizeRows = False
        Me.dgvEspecif.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEspecif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEspecif.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ensayo, Me.Descripcion, Me.DescParametros, Me.Parametro})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEspecif.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEspecif.DoubleBuffered = True
        Me.dgvEspecif.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEspecif.Location = New System.Drawing.Point(9, 86)
        Me.dgvEspecif.Name = "dgvEspecif"
        Me.dgvEspecif.OrdenamientoColumnasHabilitado = False
        Me.dgvEspecif.RowHeadersWidth = 15
        Me.dgvEspecif.RowTemplate.Height = 20
        Me.dgvEspecif.ShowCellToolTips = False
        Me.dgvEspecif.SinClickDerecho = False
        Me.dgvEspecif.Size = New System.Drawing.Size(575, 200)
        Me.dgvEspecif.TabIndex = 3
        '
        'Ensayo
        '
        Me.Ensayo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Ensayo.DataPropertyName = "Ensayo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "#00"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Ensayo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Ensayo.HeaderText = "Ens"
        Me.Ensayo.Name = "Ensayo"
        Me.Ensayo.ReadOnly = True
        Me.Ensayo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ensayo.Width = 34
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DescParametros
        '
        Me.DescParametros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescParametros.HeaderText = "Desc. Parámetros"
        Me.DescParametros.MinimumWidth = 115
        Me.DescParametros.Name = "DescParametros"
        Me.DescParametros.ReadOnly = True
        Me.DescParametros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DescParametros.Width = 115
        '
        'Parametro
        '
        Me.Parametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Parametro.DataPropertyName = "Parametro"
        Me.Parametro.HeaderText = "Parámetro"
        Me.Parametro.Name = "Parametro"
        Me.Parametro.ReadOnly = True
        Me.Parametro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Parametro.Width = 64
        '
        'ImpresionPlanillaEnsayosMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 341)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAyuda)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvEspecif)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImpresionPlanillaEnsayosMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEspecif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvEspecif As ConsultasVarias.DBDataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Ensayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescParametros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class