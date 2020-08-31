Imports System.IO
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class VencimientosProximosEvaluaciones

    Private dir As DireccionOrdenamiento = DireccionOrdenamiento.ASC
    Private ReadOnly WGenerarReporteSemanal As Boolean = False

    Sub New(Optional ByVal GenerarReporteSemanal As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WGenerarReporteSemanal = GenerarReporteSemanal
    End Sub

    Private Sub VencimientosProximosEvaluaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtDesde.Text = "" 'Date.Now.AddDays(-7).ToString("dd/MM/yyyy")
        txtHasta.Text = Date.Now.AddMonths(1).ToString("dd/MM/yyyy")

        _CargarDatos()

    End Sub

    Private Sub _CargarDatos()
        Dim WFechaInicialOrd As String = Helper.ordenaFecha(txtDesde.Text)
        Dim WFechaFinalOrd As String = Helper.ordenaFecha(txtHasta.Text)

        Dim WDatos As DataTable = GetAll("select e.Proveedor, p.Nombre, e.Articulo, a.Descripcion, e.FechaVto as Fecha, e.FechaVtoOrd as FechaOrd, e.Renglon as Item, i.Descripcion DescItem from EvaluacionProvMP e INNER JOIN Proveedor p ON p.Proveedor = e.Proveedor INNER JOIN EvaluacionProvMPItems i on i.ID = e.Renglon INNER JOIN Articulo a ON a.Codigo = e.Articulo where LTRIM(replace(e.FechaVto, '/', '')) <> '' and e.fechavtoord BETWEEN '" & WFechaInicialOrd & "' and '" & WFechaFinalOrd & "' order by e.fechavtoord, e.Proveedor, p.Nombre")

        For Each row As DataRow In GetAll("select e.Proveedor, p.Nombre, e.Articulo, a.Descripcion, e.FechaEvaluaVto as Fecha, e.FechaEvaluaVtoOrd As FechaOrd, 0 AS Item, 'EVALUACION GENERAL' As DescItem from EvaluacionProvMP e INNER JOIN Proveedor p ON p.Proveedor = e.Proveedor INNER JOIN Articulo a ON a.Codigo = e.Articulo where LTRIM(replace(FechaEvaluaVto, '/', '')) <> '' and renglon = 1 and e.FechaEvaluaVtoOrd BETWEEN '" & WFechaInicialOrd & "' and '" & WFechaFinalOrd & "' order by e.FechaEvaluaVtoOrd, e.Proveedor, p.Nombre").Rows
            WDatos.ImportRow(row)
        Next

        WDatos.DefaultView.Sort = "FechaOrd ASC, Proveedor, Nombre"

        txtDesde.Text = WDatos.Rows.Cast(Of DataRow).ToList.First()("Fecha")

        If WGenerarReporteSemanal Then

            Dim WExcelApp As New Microsoft.Office.Interop.Excel.Application

            Dim WB As Microsoft.Office.Interop.Excel.Workbook = WExcelApp.Workbooks.Open(Application.StartupPath & "/" & "template.xlsx")

            Try
                WB.Activate()

                Dim WSheet As Microsoft.Office.Interop.Excel.Worksheet = WB.Worksheets(1)

                Const WOffsetCabecera As Short = 4

                Dim WRenglon As Short = WOffsetCabecera

                WSheet.Cells(2, 1).Value = String.Format("DESDE  {0}  AL  {1}", txtDesde.Text, txtHasta.Text)

                For Each eval As DataRow In WDatos.Rows

                    WRenglon += 1

                    With WSheet

                        .Cells(WRenglon, 1) = eval("Proveedor")
                        .Cells(WRenglon, 2) = eval("Nombre")
                        .Cells(WRenglon, 3) = eval("Articulo")
                        .Cells(WRenglon, 4) = eval("Descripcion")
                        .Cells(WRenglon, 5) = eval("Fecha")
                        .Cells(WRenglon, 6) = eval("Item")
                        .Cells(WRenglon, 7) = eval("DescItem")

                    End With

                Next

                If WRenglon > 0 Then

                    WExcelApp.DisplayAlerts = False
                    'WB.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "/" & WPedido(0)("Pedido") & ".xls")
                    Dim WNombreArchivo As String = Path.GetTempPath & "VencimientosEvalProvMPFarma" & Date.Now.ToString("yyyyMMdd") & ".xlsx"

                    WB.SaveAs(WNombreArchivo)

                    WExcelApp.DisplayAlerts = False

                    Dim WDestinatarios As String = "calidad@surfactan.com.ar; calidad2@surfactan.com.ar; isocalidad@surfactan.com.ar; ebiglieri@surfactan.com.ar; wbarosio@surfactan.com.ar; msosa@surfactan.com.ar; gferreyra@surfactan.com.ar"

                    Helper._EnviarEmail(WDestinatarios, "VENCIMIENTOS EVALUACION DE PROV DE MP FARMA", "SE ADJUNTAN LOS VENCIMIENTOS DE LAS EVALUACIONES DE PROVEEDORES DE MP FARMA CORRESPONDIENTE AL PERIODO COMPRENDIDO ENTRE EL " & txtDesde.Text & " Y " & txtHasta.Text, {WNombreArchivo})

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                WB.Close()
            End Try

            Close()
        End If

        dgvItems.DataSource = WDatos

        For Each row As DataGridViewRow In dgvItems.Rows
            If Val(row.Cells("Item").Value) = 0 Then
                row.DefaultCellStyle.BackColor = Util.Clases.Globales.WBackColorTerciario
            End If
        Next
    End Sub

    Private Sub dgvItems_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvItems.ColumnHeaderMouseClick

        Dim tabla As DataTable = TryCast(dgvItems.DataSource, DataTable)

        If tabla Is Nothing Then Exit Sub

        Dim _dir As String

        If dir = DireccionOrdenamiento.ASC Then
            dir = DireccionOrdenamiento.DESC
            _dir = "DESC"
        Else
            dir = DireccionOrdenamiento.ASC
            _dir = "ASC"
        End If

        If e.ColumnIndex = dgvItems.Columns("Fecha").Index Then
            tabla.DefaultView.Sort = "FechaOrd " + _dir
        Else
            tabla.DefaultView.Sort = dgvItems.Columns(e.ColumnIndex).DataPropertyName & " " & _dir
        End If

    End Sub

    Private Enum DireccionOrdenamiento
        ASC
        DESC
    End Enum

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        _CargarDatos()
        TextBox1_KeyUp(Nothing, Nothing)
    End Sub

    Private Sub txtDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            _CargarDatos()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If
        
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Dim tabla As DataTable = TryCast(dgvItems.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Proveedor LIKE '%{0}%' OR Nombre LIKE '%{0}%' OR DescItem LIKE '%{0}%' OR Fecha LIKE '%{0}%' OR Articulo LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", TextBox1.Text)
    End Sub

    Private Sub VencimientosProximosEvaluaciones_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TextBox1.Focus()
    End Sub
End Class