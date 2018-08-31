Imports Sedronar.Clases

Public Class DeclaracionJuradaFarma

    Private WArticuloAProcesar As New DataTable
    Private WTipoProceso As New DataTable
    Private WArchivoBase As String = ""

    Private Sub DeclaracionJuradaFarma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Text = ""
        txtHasta.Text = ""

        With WArticuloAProcesar
            .Columns.Add("Articulo")
            .Columns.Add("Terminado")
            .Columns.Add("Fila1")
            .Columns.Add("Fila2")
        End With

        With WTipoProceso
            .Columns.Add("Tipo")
            .Columns.Add("Descripcion")
            .Rows.Add("1", "Litio")
            .Rows.Add("2", "Ibuprofeno")
        End With

        With cmbTipoProceso
            .DataSource = WTipoProceso
            .ValueMember = "Tipo"
            .DisplayMember = "Descripcion"
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub DeclaracionJuradaFarma_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.Replace("/", "").Trim = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtDesde.Text) Then Exit Sub

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.Replace("/", "").Trim = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtHasta.Text) Then Exit Sub

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        

        Select Case Val(CType(cmbTipoProceso.SelectedItem, DataRowView).Item("Tipo"))
            Case 1

                With WArticuloAProcesar
                    .Rows.Clear()
                    .Rows.Add("PC-094", "PT-25047", 5, 6)
                End With

                WArchivoBase = "PlanillaTrimestral-MODELO-Litio.xlsx"

            Case 2

                With WArticuloAProcesar
                    .Rows.Clear()
                    .Rows.Add("AI-000", "PT-25127", 5, 6)
                    .Rows.Add("JM-015", "", 7, 8)
                End With

                WArchivoBase = "PlanillaTrimestral-MODELO-Ibu.xlsx"

            Case Else

                Exit Sub

        End Select

        _Procesar()

    End Sub

    Private Sub _Procesar()
        Dim WExcelApp As New Microsoft.Office.Interop.Excel.Application

        Try

            Dim WSumas As New Dictionary(Of String, Double)
            Dim WDesdeOrd As String = Helper.ordenaFecha(txtDesde.Text)
            Dim WHastaOrd As String = Helper.ordenaFecha(txtHasta.Text)

            Dim WB As Microsoft.Office.Interop.Excel.Workbook = WExcelApp.Workbooks.Open(Application.StartupPath & "/" & WArchivoBase)

            WB.Activate()

            WExcelApp.Visible = True

            For Each WRow As DataRow In WArticuloAProcesar.Rows

                Dim WArticulos As DataTable = QueryAll("select Tipo= 'M', Codigo, Descripcion from Articulo where codigo between '" & WRow.Item("Articulo") & "-000' and '" & WRow.Item("Articulo") & "-999'")

                WSumas = New Dictionary(Of String, Double)

                WSumas.Add("TotalI", 0)
                WSumas.Add("TotalII", 0)
                WSumas.Add("TotalIII", 0)
                WSumas.Add("TotalIV", 0)
                WSumas.Add("TotalV", 0)
                WSumas.Add("TotalVentas", 0)
                WSumas.Add("TotalVentasII", 0)
                WSumas.Add("TotalVentasAjuste", 0)

                For Each WArticulo As DataRow In WArticulos.Rows

                    '
                    ' Procesamos las Compras.
                    '
                    Dim WLaudos As DataTable = QueryAll("SELECT l.Orden, ISNULL(o.Tipo, -1) TipoOrden, SUM(CASE WHEN ISNULL(l.LiberadaAnt, 0) <> 0 THEN l.LiberadaAnt ELSE l.Liberada END) Cantidad FROM laudo l INNER JOIN Orden o ON o.Orden = l.Orden AND o.Articulo = l.Articulo WHERE l.Articulo = '" & WArticulo.Item("Codigo") & "' AND l.FechaOrd BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "' GROUP BY l.Orden, o.Tipo", "Surfactan_III")

                    For Each row As DataRow In WLaudos.Rows

                        Select Case Val(row.Item("TipoOrden"))
                            Case 0
                                WSumas.Item("TotalI") += row.Item("Cantidad")
                            Case 1
                                WSumas.Item("TotalII") += row.Item("Cantidad")
                        End Select

                    Next

                    '
                    ' Procesamos las Hojas de Produccion.
                    '
                    Dim WHojas As DataTable = QueryAll("SELECT ISNULL(Cantidad, 0) Cantidad , ISNULL(Real, 0) Real FROM Hoja WHERE Articulo = '" & WArticulo.Item("Codigo") & "' and (RIGHT(FechaFinal, 4) + SUBSTRING(Fechafinal, 4,2) + left(fechafinal, 2)) BETWEEN '" & WDesdeOrd & "' and '" & WHastaOrd & "'", "Surfactan_III")

                    For Each row As DataRow In WHojas.Rows
                        WSumas.Item("TotalIII") += row.Item("Cantidad")
                        WSumas.Item("TotalIV") += row.Item("Real")
                    Next

                    '
                    ' Procesamos los Ajustes Necesarios.
                    '

                    ' Ajustamos por Movimientos de Laboratorio.
                    Dim WMovimientosLab As DataTable = QueryAll("SELECT ISNULL(Movi, 'S') Movi, ISNULL(Cantidad, 0) Cantidad FROM MovLab WHERE Articulo = '" & WArticulo.Item("Codigo") & "' and FechaOrd BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "'", "Surfactan_III")

                    For Each row As DataRow In WMovimientosLab.Rows
                        If UCase(row.Item("Movi")) = "S" Then
                            WSumas.Item("TotalV") -= row.Item("Cantidad")
                        Else
                            WSumas.Item("TotalV") += row.Item("Cantidad")
                        End If
                    Next

                    ' Ajustamos por Movimientos Varios.
                    Dim WMovimientosVarios As DataTable = QueryAll("SELECT ISNULL(Movi, 'S') Movi, ISNULL(Cantidad, 0) Cantidad FROM MovVar WHERE Articulo = '" & WArticulo.Item("Codigo") & "' and FechaOrd BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "'", "Surfactan_III")

                    For Each row As DataRow In WMovimientosVarios.Rows
                        If UCase(row.Item("Movi")) = "S" Then
                            WSumas.Item("TotalV") -= row.Item("Cantidad")
                        Else
                            WSumas.Item("TotalV") += row.Item("Cantidad")
                        End If
                    Next

                Next

                '
                ' Procesamos las Ventas como Terminado.
                '
                Dim WEstadisticas As DataTable = QueryAll("SELECT ISNULL(Numero, 0) Numero, ISNULL(Cantidad, 0) Cantidad FROM Estadistica WHERE Articulo BETWEEN '" & WRow.Item("Terminado") & "-100' AND '" & WRow.Item("Terminado") & "-999' AND OrdFecha BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "'", "Surfactan_VII")

                For Each row As DataRow In WEstadisticas.Rows
                    If Val(row.Item("Numero")) < 800000 Then
                        WSumas.Item("TotalVentas") += row.Item("Cantidad")
                    Else
                        WSumas.Item("TotalVentasII") += row.Item("Cantidad")
                    End If
                Next

                '
                ' Procesamos el Ajuste de las Ventas.
                '

                ' Ajustamos por Movimientos de Laboratorio.
                Dim WMovLab As DataTable = QueryAll("SELECT ISNULL(Movi, 'S') Movi, ISNULL(Cantidad, 0) Cantidad FROM MovLab WHERE Terminado BETWEEN '" & WRow.Item("Terminado") & "-100' AND '" & WRow.Item("Terminado") & "-999' and FechaOrd BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "'", "Surfactan_VII")

                For Each row As DataRow In WMovLab.Rows
                    If UCase(row.Item("Movi")) = "S" Then
                        WSumas.Item("TotalVentasAjuste") -= row.Item("Cantidad")
                    Else
                        WSumas.Item("TotalVentasAjuste") += row.Item("Cantidad")
                    End If
                Next

                ' Ajustamos por Movimientos Varios.
                Dim WMovVar As DataTable = QueryAll("SELECT ISNULL(Movi, 'S') Movi, ISNULL(Cantidad, 0) Cantidad FROM MovVar WHERE Terminado BETWEEN '" & WRow.Item("Terminado") & "-100' AND '" & WRow.Item("Terminado") & "-999' and FechaOrd BETWEEN '" & WDesdeOrd & "' AND '" & WHastaOrd & "'", "Surfactan_VII")

                For Each row As DataRow In WMovVar.Rows
                    If UCase(row.Item("Movi")) = "S" Then
                        WSumas.Item("TotalVentasAjuste") -= row.Item("Cantidad")
                    Else
                        WSumas.Item("TotalVentasAjuste") += row.Item("Cantidad")
                    End If
                Next

                Dim WFila1 = WRow.Item("Fila1")
                Dim WFila2 = WRow.Item("Fila2")

                Dim WSheet As Microsoft.Office.Interop.Excel.Worksheet = WB.Worksheets(1)

                With WSheet.Cells()
                    .Cells(WFila1, 6).Value = WSumas.Item("TotalI")
                    .Cells(WFila1, 7).Value = WSumas.Item("TotalII")
                    .Cells(WFila1, 8).Value = ""
                    .Cells(WFila1, 9).Value = ""
                    .Cells(WFila1, 11).Value = WSumas.Item("TotalIII")
                    .Cells(WFila1, 12).Value = "0"
                    .Cells(WFila1, 13).Value = "0"
                    .Cells(WFila1, 14).Value = "0"
                    .Cells(WFila1, 16).Value = WSumas.Item("TotalV")

                    .Cells(WFila2, 6).Value = ""
                    .Cells(WFila2, 7).Value = "0"
                    .Cells(WFila2, 8).Value = "0"
                    .Cells(WFila2, 9).Value = "0"
                    .Cells(WFila2, 11).Value = WSumas.Item("TotalIV")
                    .Cells(WFila2, 12).Value = WSumas.Item("TotalVentasII")
                    .Cells(WFila2, 13).Value = "0"
                    .Cells(WFila2, 14).Value = WSumas.Item("TotalVentas")
                    .Cells(WFila2, 16).Value = WSumas.Item("TotalIII") - WSumas.Item("TotalIV") + WSumas.Item("TotalVentasAjuste")
                End With

            Next

            WExcelApp.DisplayAlerts = False
            WB.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "/" & WArchivoBase.Replace("-MODELO", "").Replace(".xlsx", "") & " - (" & txtDesde.Text.Replace("/", "-") & " al " & txtHasta.Text.Replace("/", "-") & ").xlsx")

            WExcelApp.DisplayAlerts = False

            'WB.Close()
            'WExcelApp.Quit()

            MsgBox("Se ha generado el informe y se ha guardado en su escritorio.", MsgBoxStyle.Information)

            'WExcelApp.SaveWorkspace(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "PlanillaTrimestral.xlsx")

        Catch ex As Exception
            If Not IsNothing(WExcelApp) Then WExcelApp.Quit()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class