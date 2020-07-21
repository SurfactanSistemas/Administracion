Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Consulta_GastImportacion

    Private Sub DGV_GastosImportacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_GastosImportacion.CellDoubleClick
        Dim WOwner As IConsulta_GasImportacion = TryCast(Owner, IConsulta_GasImportacion)
        If WOwner IsNot Nothing Then
            WOwner.PasaGasto(DGV_GastosImportacion.CurrentRow.Cells("Concepto").Value, DGV_GastosImportacion.CurrentRow.Cells("Descripcion").Value)
        End If

    End Sub

    Private Sub Consulta_GastImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Concepto = Codigo, Descripcion = TRIM(Nombre) FROM GasImpo ORDER BY Codigo"

        Dim tabla As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tabla.Rows.Count > 0 Then
            DGV_GastosImportacion.DataSource = tabla
        End If
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class