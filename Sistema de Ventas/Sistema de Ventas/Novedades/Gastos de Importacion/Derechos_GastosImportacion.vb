Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Derechos_GastosImportacion
    Dim baseA As String
    Sub New(ByVal CodOrden As String, ByVal BaseAConectar As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        baseA = BaseAConectar

        Dim SQLCnslt As String = "SELECT Articulo, Derechos, Clave FROM Orden WHERE Orden = '" & CodOrden & "' ORDER BY Orden, Renglon"

        Dim Tabla As DataTable = GetAll(SQLCnslt, BaseAConectar)

        If Tabla.Rows.Count > 0 Then
            For Each Row As DataRow In Tabla.Rows
                DGV_Derechos.Rows.Add(Row.Item("Articulo"), "", formatonumerico(Row.Item("Derechos"), 2), Row.Item("Clave"))
            Next


            For Each Row_DGV As DataGridViewRow In DGV_Derechos.Rows
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Row_DGV.Cells("Articulo").Value & "'"
                Dim RowArti As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowArti IsNot Nothing Then
                    Row_DGV.Cells("Descripcion").Value = RowArti.Item("Descripcion")
                End If
            Next
        End If

    End Sub

    Private Sub btn_FinIngreso_Click(sender As Object, e As EventArgs) Handles btn_FinIngreso.Click

        Dim ArtiDerechos As New DataTable

        With ArtiDerechos.Columns
            .Add("Articulo")
            .Add("Derechos")

        End With

        Dim ListaSQlCnslt As New List(Of String)

        For Each DGV_row As DataGridViewRow In DGV_Derechos.Rows
            Dim SQLCnslt As String = "SELECT Articulo, Derechos FROM Orden WHERE Clave = '" & DGV_row.Cells("Clave").Value & "'"

            Dim row As DataRow = GetSingle(SQLCnslt, baseA)

            If row IsNot Nothing Then
                ArtiDerechos.Rows.Add(row.Item("Articulo"), row.Item("Derechos"))

                SQLCnslt = "UPDATE " & baseA & ".dbo.Orden SET Derechos = '" & formatonumerico(DGV_row.Cells("Derechos").Value, 2) & "' WHERE Clave = '" & DGV_row.Cells("Clave").Value & "'"

                ListaSQlCnslt.Add(SQLCnslt)
            End If
        Next

        For Each row_artiderechos As DataRow In ArtiDerechos.Rows

            Dim SQLCnslt As String = "UPDATE Articulo SET Derechos = '" & row_artiderechos.Item("Derechos") & "' " _
                                     & "WHERE Codigo = '" & row_artiderechos.Item("Articulo") & "'"

            ListaSQlCnslt.Add(SQLCnslt)

        Next

        ExecuteNonQueries("SurfactanSa", ListaSQlCnslt.ToArray())

        Close()
    End Sub
End Class