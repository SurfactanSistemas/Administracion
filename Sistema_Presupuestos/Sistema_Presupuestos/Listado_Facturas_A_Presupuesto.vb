Imports Util.Clases.Query

Public Class Listado_Facturas_A_Presupuesto

    Sub New(Optional ByVal NroPresupuesto As Integer = 0)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If NroPresupuesto <> 0 Then
            Dim SQLCnslt As String = "SELECT NroInterno, Numero, Fecha, Neto FROM IvaComp WHERE NroPresupuesto = '" & NroPresupuesto & "'"
            Dim TablaIvaComp As DataTable = getall(SQLCnslt, "SurfactanSa")
            If TablaIvaComp.Rows.Count > 0 Then
                dgv_Facturas.DataSource = TablaIvaComp
            Else
                MsgBox("No se encontraron facturas para este presupuesto.", vbExclamation)
            End If
        End If

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub dgv_Facturas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Facturas.CellMouseDoubleClick
        With New MostrarFactura(dgv_Facturas.CurrentRow.Cells("NroInterno").Value)
            .Show()
        End With
    End Sub
End Class