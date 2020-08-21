﻿Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Consulta_DY




    Private Sub Consulta_DY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Articulo WHERE Codigo LIKE 'DY%' ORDER BY Codigo ASC"

        Dim TablaDY As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaDY.Rows.Count > 0 Then

            DGV_DY.DataSource = TablaDY

        End If
    End Sub



    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_DY.DataSource
        TablaFiltrar.DefaultView.RowFilter = "Codigo LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub DGV_Cliente_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_DY.CellMouseDoubleClick
        Dim Accion As String = "Desde"
        If chk_Desde.Checked And chk_Hasta.Checked Then
            Accion = "Ambos"
        Else
            If chk_Hasta.Checked And chk_Desde.Checked = False Then
                Accion = "Hasta"
            End If
        End If
        Dim WOwner As IConsulta_DY = TryCast(Owner, IConsulta_DY)
        If WOwner IsNot Nothing Then
            WOwner.PasaCodigo(DGV_DY.CurrentRow.Cells("Codigo").Value, Accion)
        End If


    End Sub

End Class