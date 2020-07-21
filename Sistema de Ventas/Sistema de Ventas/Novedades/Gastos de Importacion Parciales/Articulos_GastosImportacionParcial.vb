Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Articulos_GastosImportacionParcial

    Sub New(ByVal Codigo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Dim SQLCnslt As String = "SELECT Articulo, Cantidad, Clave FROM MovGasParcialArti " _
                                & "WHERE Codigo = '" & Codigo & "' ORDER BY Clave"
        Dim Tabla_Art As DataTable = GetAll(SQLCnslt, Operador.Base)

        If Tabla_Art.Rows.Count > 0 Then
            For Each row As DataRow In Tabla_Art.Rows
                With row
                    DGV_Articulos.Rows.Add(.Item("Articulo"), "", formatonumerico(.Item("Cantidad"), 2))
                End With

            Next
        End If

        For Each DGV_Row As DataGridViewRow In DGV_Articulos.Rows
            With DGV_Row
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & .Cells("Articulo").Value & "'"

                Dim Row As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If Row IsNot Nothing Then
                    .Cells("Descripcion").Value = Row.Item("Descripcion")
                End If
            End With
        Next

    End Sub

    Private Sub btn_FinIngreso_Click(sender As Object, e As EventArgs) Handles btn_FinIngreso.Click
        Dim WOwner As IGastosImpoParcial = TryCast(Owner, IGastosImpoParcial)
        If WOwner IsNot Nothing Then
            Dim tabla As New DataTable
            With tabla.Columns
                .Add("Articulo")
                .Add("Cantidad")
            End With
            For Each DGVRow As DataGridViewRow In DGV_Articulos.Rows
                tabla.Rows.Add(DGVRow.Cells("Articulo").Value, DGVRow.Cells("Cantidad").Value)
            Next

            WOwner.PasaTabla(tabla)
        End If
        Close()
    End Sub
End Class