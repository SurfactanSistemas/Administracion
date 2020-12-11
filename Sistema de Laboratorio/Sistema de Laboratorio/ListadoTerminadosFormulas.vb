Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ListadoTerminadosFormulas : Implements Util.IAyudaGeneral

    Private Sub ListadoTerminadosFormulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WDatos As DataTable = GetAll("SELECT DISTINCT f.Terminado AS Producto, t.Descripcion FROM FormulasDeEnsayos f INNER JOIN Terminado t ON t.Codigo = f.Terminado ORDER BY Terminado", "Surfactan_II")

        DGV_Formulas.DataSource = WDatos

        txtBuscador.Focus()
    End Sub

    Private Sub DGV_Formulas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Formulas.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WTerminado As String = OrDefault(DGV_Formulas.CurrentRow.Cells("Producto").Value, "")

        If WTerminado.Trim = "" Then Exit Sub

        With New IngresoFormulasEnsayo(WTerminado)
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

        With New IngresoFormulasEnsayo(WTerminado)
            .Show(Me)
            .btnAgregar.PerformClick()
        End With

    End Sub
End Class