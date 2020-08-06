Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Util
Imports Util.Interfaces

Public Class ListadoComposicionesProductos : Implements IExportar, IAyudaPTs

    Private WControl As MaskedTextBox

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoComposicionesProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        txtDesde.Text = "PT-00000-000"
        txtHasta.Text = "PT-99999-999"
        txtFiltrar.Text = ""
        txtProducto.Text = ""

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If txtDesde.Text.Replace(" ", "").Length = 2 Then txtDesde.Text = "PT-00000-000"
        If txtHasta.Text.Replace(" ", "").Length = 2 Then txtHasta.Text = "ZZ-99999-999"

        txtFiltrar.Text = ""

        Dim WDatos As DataTable = GetAll("SELECT c.Terminado As Producto, RTRIM(t.Descripcion) As Descripcion, t.FechaVersion As Fecha, t.Version, t.Estado, RTRIM(o.Descripcion) As Responsable, RTRIM(c.Referencia) As RefLaboratorio FROM Composicion c INNER JOIN Terminado t ON t.Codigo = c.Terminado LEFT OUTER JOIN Operador o ON o.Operador = c.Operador WHERE c.Renglon = 1 AND c.Terminado BETWEEN '" & txtDesde.Text & "' And '" & txtHasta.Text & "' AND c.Terminado >= 'PT-00005-000' And t.Version > 0 ORDER BY c.Terminado")

        BackgroundWorker1.ReportProgress(1, WDatos)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim WDatos As DataTable = TryCast(e.UserState, DataTable)

        If WDatos Is Nothing Then Exit Sub

        dgvListado.DataSource = WDatos

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtFiltrar.Focus()
    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim WDatos As DataTable = TryCast(dgvListado.DataSource, DataTable)

        If WDatos IsNot Nothing Then WDatos.DefaultView.RowFilter = String.Format("Producto LIKE '%{0}%' OR Descripcion LIKE '%{0}%' OR Fecha LIKE '%{0}%' OR Responsable LIKE '%{0}%' OR RefLaboratorio LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        With New Exportar
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarExportar(TipoSalida As [Enum]) Implements IExportar._ProcesarExportar

        Dim rpt As ReportDocument = New ReporteListadoComposicionProductos

        rpt.SetDataSource(dgvListado.DataSource)

        rpt.SetParameterValue("ImpreRangoProductos", String.Format("Productos {0} Al {1}", txtDesde.Text, txtHasta.Text))

        _ExportarReporte(rpt, TipoSalida)

    End Sub

    Private Sub _ExportarReporte(ByVal rpt As ReportDocument, ByVal WFormato As Object)

        With New VistaPrevia

            .Reporte = rpt

            Dim WNombreArchivo = String.Format("Listado de Composicion de Productos - {0} al {2} - {1}", txtDesde.Text, txtHasta.Text, Date.Now.ToString("dd-MM-yyyy"))

            Select Case WFormato
                Case 0 ' Imprimir
                    .Imprimir()
                Case 1 ' Mostrar por Pantalla
                    .Mostrar()
                Case 2 ' PDF
                    .Exportar(WNombreArchivo, ExportFormatType.PortableDocFormat)
                Case 3 ' Excel
                    .Exportar(WNombreArchivo, ExportFormatType.Excel)
                Case 4 ' Word
                    .Exportar(WNombreArchivo, ExportFormatType.WordForWindows)
                Case 5
                    .EnviarPorEmail(WNombreArchivo)
            End Select

        End With
    End Sub

    Private Sub txtDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.Replace(" ", "").Length = 2 Then txtDesde.Text = "PT-00000-000"
            If txtDesde.Text.Replace(" ", "").Length < 10 Then Exit Sub

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.Replace(" ", "").Length = 2 Then txtHasta.Text = "ZZ-99999-999"
            If txtHasta.Text.Replace(" ", "").Length < 10 Then Exit Sub

            btnBuscar_Click(Nothing, Nothing)

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub ListadoCmposicionesProductos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub txtDesde_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtDesde.MouseDoubleClick
        WControl = txtDesde
        With New AyudaPTs
            .Show(Me)
        End With
    End Sub

    Private Sub txtHasta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtHasta.MouseDoubleClick
        WControl = txtHasta
        With New AyudaPTs
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaPTs(Codigo As String, Desc As String) Implements IAyudaPTs._ProcesarAyudaPTs
        If WControl Is Nothing Then Exit Sub

        WControl.Text = Codigo

        If txtDesde.Name = WControl.Name Then
            txtDesde_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        ElseIf txtHasta.Name = WControl.Name Then
            txtHasta_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Else
            txtProducto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

        WControl = Nothing

    End Sub

    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown

    End Sub

    Private Sub txtProducto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtProducto.MouseDoubleClick
        WControl = txtProducto
        With New AyudaPTs
            .Show(Me)
        End With
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        With New ComposicionProducto
            .Show(Me)
        End With
    End Sub
End Class