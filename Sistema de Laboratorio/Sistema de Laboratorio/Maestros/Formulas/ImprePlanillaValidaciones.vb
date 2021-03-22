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

        Dim SQLCnslt = "SELECT fe.Descripcion As DescFormula, fe.FormulaAdic1, fe.FormulaAdic2, fe.FormulaAdic3, fe.FormulaAdic1dec, fe.FormulaAdic2dec, fe.FormulaAdic3dec, fv.*, t.Descripcion DescProducto FROM FormulasDeEnsayos fe INNER JOIN FormulasVerificadasValores fv ON fv.Terminado = fe.Terminado AND fv.IDRenglon = fe.Renglon INNER JOIN SurfactanSa.dbo.Terminado t ON t.Codigo = fv.Terminado WHERE fv.Terminado = '" & WProducto & "' And fv.Variable <> '' AND fv.IDRenglon = '" & WRenglon & "' Order By fv.IDRenglon, fv.Fila"

        Dim tabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")

        DbDataGridView1.DataSource = tabla

        Dim datos As DataTable = New DBAuxi.TablaImprePlanillaValidacionesDataTable

        For Each row As datarow In tabla.rows

            Dim r As DataRow = datos.NewRow

            Dim WForm As String = row("Formula").ToString.Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa1 As String = Trim(OrDefault(row("FormulaAdic1"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa2 As String = Trim(OrDefault(row("FormulaAdic2"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")
            Dim WFa3 As String = Trim(OrDefault(row("FormulaAdic3"), "")).Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")

            With r
                .Item("Producto") = row("Terminado")
                .Item("DescProducto") = row("DescProducto")
                .Item("Formula") = WForm
                .Item("DescFormula") = row("DescFormula")
                .Item("Resultado") = row("ResultadoVerificado")
                .Item("Variable") = row("Variable")
                .Item("Valor") = row("Valor")
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