﻿Imports System.ComponentModel
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class VistaPrevia
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalReportViewer()
        Me.SaveFileDialog1 = New SaveFileDialog()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = Cursors.Default
        Me.CrystalReportViewer1.Dock = DockStyle.Fill
        Me.CrystalReportViewer1.Location = New Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New Size(701, 443)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
        '
        'VistaPrevia
        '
        Me.ClientSize = New Size(701, 443)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "VistaPrevia"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer2 As CrystalReportViewer
    Friend WithEvents CrystalReportViewer1 As CrystalReportViewer
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
