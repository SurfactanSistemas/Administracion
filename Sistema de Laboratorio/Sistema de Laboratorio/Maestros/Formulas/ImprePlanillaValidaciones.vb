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

        tabla.Columns.Add("FormulaFinal")

        For Each row As datarow In tabla.rows

            Dim WForm As String = Trim(OrDefault(row("Formula"), ""))

            Dim WFa1, WFa2, WFa3 As String

            WFa1 = Trim(OrDefault(row("FormulaAdic1"), ""))
            WFa2 = Trim(OrDefault(row("FormulaAdic2"), ""))
            WFa3 = Trim(OrDefault(row("FormulaAdic3"), ""))

            WForm = WForm.Replace("FA1", WFa1).Replace("FA2", WFa2).Replace("FA3", WFa3).Replace(" ", "")

            WForm = WForm.Replace("(", "( ").Replace(")", " )").Replace("*", " * ").Replace("/", " / ").Replace("+", " + ").Replace("-", " - ")

            row("FormulaFinal") = WForm

        Next

        DbDataGridView1.DataSource = tabla

        Dim datos As DataTable = New DBAuxi.TablaImprePlanillaValidacionesDataTable

        For Each row As datarow In tabla.rows

            Dim r As DataRow = datos.NewRow

            With r
                .Item("Producto") = row("Terminado")
                .Item("DescProducto") = row("DescProducto")
                .Item("Formula") = row("FormulaFinal")
                .Item("DescFormula") = row("DescFormula")
                .Item("Resultado") = row("ResultadoVerificado")
                .Item("Variable") = row("Variable")
                .Item("Valor") = row("Valor")
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