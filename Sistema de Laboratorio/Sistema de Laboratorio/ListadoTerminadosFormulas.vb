﻿Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ListadoTerminadosFormulas : Implements Util.IAyudaGeneral

    Private ID_Permiso As Integer = 0
    Private PermisoGrabar As Boolean = True

    Sub New(Optional ByVal ID As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Val(ID) <> 0 Then
            ID_Permiso = Val(ID)

            Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' ORDER BY ID"
            Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If Row IsNot Nothing Then
                PermisoGrabar = Row.Item("Escritura")
            End If

        End If

    End Sub

    Private Sub ListadoTerminadosFormulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WDatos As DataTable = GetAll("SELECT DISTINCT f.Terminado AS Producto, t.Descripcion FROM FormulasDeEnsayos f INNER JOIN Terminado t ON t.Codigo = f.Terminado ORDER BY Terminado", "Surfactan_II")

        DGV_Formulas.DataSource = WDatos

        txtBuscador.Focus()
    End Sub

    Private Sub DGV_Formulas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Formulas.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WTerminado As String = OrDefault(DGV_Formulas.CurrentRow.Cells("Producto").Value, "")

        If WTerminado.Trim = "" Then Exit Sub

        With New IngresoFormulasEnsayo(ID_Permiso, WTerminado)
            .Show(Me)
        End With

    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        With New Util.AyudaGeneral(GetAll("SELECT Codigo, Descripcion FROM Terminado ORDER BY Codigo"), "SELECCIONE EL CODIGO DEL PRODUCTO")
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral

        Dim WTerminado As String = OrDefault(row.Cells("Codigo").Value, "")

        With New IngresoFormulasEnsayo(ID_Permiso, WTerminado)
            .Show(Me)
            .btnAgregar.PerformClick()
        End With

    End Sub
End Class