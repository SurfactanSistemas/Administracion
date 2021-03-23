Public Class ImprePlanillaValidaciones
    Private ReadOnly WProducto As String = ""
    Private ReadOnly WRenglon As String = ""
    Sub New(ByVal Prod As String, ByVal Renglon As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WProducto = Prod
        WRenglon = Renglon

        If WProducto.Trim = "" Then Close()

    End Sub
    Private Sub ImprePlanillaValidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim SQLCnslt = "SELECT fe.Descripcion As DescFormula, fe.Formula As FormulaOrig, fe.FormulaAdic1, fe.FormulaAdic2, fe.FormulaAdic3, fe.FormulaAdic1dec, fe.FormulaAdic2dec, fe.FormulaAdic3dec, fe.FechaVerificacion, fe.ReferenciaVerificacion, fe.PartidaVerificacion, fe.Unidad, fv.*, t.Descripcion DescProducto FROM FormulasDeEnsayos fe INNER JOIN FormulasVerificadasValores fv ON fv.Terminado = fe.Terminado AND fv.IDRenglon = fe.Renglon INNER JOIN SurfactanSa.dbo.Terminado t ON t.Codigo = fv.Terminado WHERE fv.Terminado = '" & WProducto & "' And fv.Variable <> '' AND fv.IDRenglon = '" & WRenglon & "' Order By fv.IDRenglon, fv.Fila"

        Dim tabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")

        DbDataGridView1.DataSource = tabla

        Dim datos As DataTable = New DBAuxi.TablaImprePlanillaValidacionesDataTable

        Dim WUnidad As String = ""

        For Each row As datarow In tabla.rows

            Dim r As DataRow = datos.NewRow

            Dim WForm As String = row("FormulaOrig").ToString.Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa1 As String = Trim(OrDefault(row("FormulaAdic1"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa2 As String = Trim(OrDefault(row("FormulaAdic2"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa3 As String = Trim(OrDefault(row("FormulaAdic3"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")

            If Trim(WUnidad) = "" Then

                WUnidad = Trim(OrDefault(row("Unidad"), ""))

                If WUnidad.Trim = "" Then

                    Dim WEspe As DataRow = GetSingle("SELECT TOP 1 UnidadEspecif FROM CargaV WHERE Terminado = '" & WProducto & "' AND rtrim(FormulaEspecif) = '" & WForm.Replace(" ", "").Trim & "'")

                    If WEspe IsNot Nothing Then
                        WUnidad = Trim(OrDefault(WEspe("UnidadEspecif"), ""))
                    End If

                End If

            End If

            With r
                .Item("Producto") = row("Terminado")
                .Item("DescProducto") = row("DescProducto")
                .Item("Formula") = WForm
                .Item("DescFormula") = row("DescFormula")
                .Item("Resultado") = Trim(Trim(row("ResultadoVerificado")) & " " & WUnidad).Trim
                .Item("Variable") = row("Variable")
                .Item("Valor") = row("Valor")
                .Item("Fecha") = row("FechaVerificacion")
                .Item("Referencia") = row("ReferenciaVerificacion")
                .Item("Partida") = row("PartidaVerificacion")
                .Item("FA1") = WFa1
                .Item("FA2") = WFa2
                .Item("FA3") = WFa3
            End With

            datos.Rows.Add(r)

        Next

        With New Util.VistaPrevia
            .Reporte = New PlanillaValidaciones
            .Reporte.SetDataSource(datos)
            .Imprimir()
        End With

        Close()

    End Sub
End Class