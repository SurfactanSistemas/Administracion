﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargadorDeTxt
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btn_ObtenerDatos = New System.Windows.Forms.Button()
        Me.dgv_Cheques = New Util.DBDataGridView()
        Me.DGV_RutasArchivos = New Util.DBDataGridView()
        Me.Rutas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_CargarEnTabla = New System.Windows.Forms.Button()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        CType(Me.dgv_Cheques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_RutasArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panel1.Size = New System.Drawing.Size(1089, 49)
        Me.panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(855, 12)
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
        Me.label1.Size = New System.Drawing.Size(220, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "CARGA DE E-CHEQUES"
        '
        'btn_ObtenerDatos
        '
        Me.btn_ObtenerDatos.Location = New System.Drawing.Point(421, 69)
        Me.btn_ObtenerDatos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_ObtenerDatos.Name = "btn_ObtenerDatos"
        Me.btn_ObtenerDatos.Size = New System.Drawing.Size(140, 70)
        Me.btn_ObtenerDatos.TabIndex = 10
        Me.btn_ObtenerDatos.Text = "Obtener Cheques de Archivo"
        Me.btn_ObtenerDatos.UseVisualStyleBackColor = True
        '
        'dgv_Cheques
        '
        Me.dgv_Cheques.AllowUserToAddRows = False
        Me.dgv_Cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Cheques.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Cheques.DoubleBuffered = True
        Me.dgv_Cheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgv_Cheques.Location = New System.Drawing.Point(9, 159)
        Me.dgv_Cheques.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Cheques.Name = "dgv_Cheques"
        Me.dgv_Cheques.OrdenamientoColumnasHabilitado = True
        Me.dgv_Cheques.RowHeadersWidth = 15
        Me.dgv_Cheques.RowTemplate.Height = 20
        Me.dgv_Cheques.ShowCellToolTips = False
        Me.dgv_Cheques.SinClickDerecho = False
        Me.dgv_Cheques.Size = New System.Drawing.Size(1072, 323)
        Me.dgv_Cheques.TabIndex = 9
        '
        'DGV_RutasArchivos
        '
        Me.DGV_RutasArchivos.AllowDrop = True
        Me.DGV_RutasArchivos.AllowUserToAddRows = False
        Me.DGV_RutasArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_RutasArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rutas})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_RutasArchivos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_RutasArchivos.DoubleBuffered = True
        Me.DGV_RutasArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_RutasArchivos.Location = New System.Drawing.Point(9, 57)
        Me.DGV_RutasArchivos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_RutasArchivos.Name = "DGV_RutasArchivos"
        Me.DGV_RutasArchivos.OrdenamientoColumnasHabilitado = True
        Me.DGV_RutasArchivos.RowHeadersWidth = 15
        Me.DGV_RutasArchivos.RowTemplate.Height = 20
        Me.DGV_RutasArchivos.ShowCellToolTips = False
        Me.DGV_RutasArchivos.SinClickDerecho = False
        Me.DGV_RutasArchivos.Size = New System.Drawing.Size(585, 98)
        Me.DGV_RutasArchivos.TabIndex = 11
        '
        'Rutas
        '
        Me.Rutas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Rutas.HeaderText = "Rutas"
        Me.Rutas.Name = "Rutas"
        '
        'btn_CargarEnTabla
        '
        Me.btn_CargarEnTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CargarEnTabla.Location = New System.Drawing.Point(925, 63)
        Me.btn_CargarEnTabla.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_CargarEnTabla.Name = "btn_CargarEnTabla"
        Me.btn_CargarEnTabla.Size = New System.Drawing.Size(151, 82)
        Me.btn_CargarEnTabla.TabIndex = 12
        Me.btn_CargarEnTabla.Text = "Cargar en Base Datos"
        Me.btn_CargarEnTabla.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Location = New System.Drawing.Point(514, 453)
        Me.btn_Eliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(100, 53)
        Me.btn_Eliminar.TabIndex = 13
        Me.btn_Eliminar.Text = "Eliminar marcados"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        Me.btn_Eliminar.Visible = False
        '
        'CargadorDeTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 496)
        Me.Controls.Add(Me.btn_CargarEnTabla)
        Me.Controls.Add(Me.DGV_RutasArchivos)
        Me.Controls.Add(Me.btn_ObtenerDatos)
        Me.Controls.Add(Me.dgv_Cheques)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CargadorDeTxt"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgv_Cheques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_RutasArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_Cheques As Util.DBDataGridView
    Friend WithEvents btn_ObtenerDatos As System.Windows.Forms.Button
    Friend WithEvents DGV_RutasArchivos As Util.DBDataGridView
    Friend WithEvents Rutas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_CargarEnTabla As System.Windows.Forms.Button
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
End Class
