Imports ClasesCompartidas
Imports System.IO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ProcesoPercepciones


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WImporte As String
    Dim WRecibo As String
    Dim WTipoFac As String
    Dim WTipo As String
    Dim WNumero As String
    Dim WNeto As String
    Dim WImporteII As Double
    Dim WNetoII As Double
    Dim WPorceIb As String
    Dim WPorceIbII As Double

    Dim WCampo1 As String
    Dim WCampo2 As String
    Dim WCampo3 As String
    Dim WCampo4 As String
    Dim WCampo5 As String
    Dim WCampo6 As String
    Dim WCampo7 As String
    Dim WCampo8 As String
    Dim WCampo9 As String
    Dim WCampo10 As String
    Dim WCampo11 As String
    Dim WCampo12 As String
    Dim WCampo13 As String
    Dim WCampo14 As String
    Dim WCampo15 As String
    Dim WCampo16 As String
    Dim WCampo17 As String
    Dim WCampo18 As String
    Dim WCampo19 As String
    Dim WCampo20 As String
    Dim WSucursal As String

    Private Sub ProcesoPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

        TipoProceso.Items.Clear()
        TipoProceso.Items.Add("Buenos Aires")
        TipoProceso.Items.Add("Tucuman")

        TipoProceso.SelectedIndex = 0

    End Sub


    Private Sub txtdesde_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtDesde.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesde.Text) = "S" Then
                txtHasta.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesde.Text = "  /  /    "
            Me.txtDesde.SelectionStart = 0
        End If
    End Sub

    Private Sub txthasta_KeyPress(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtHasta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtHasta.Text) = "S" Then
                txtNombre.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHasta.Text = "  /  /    "
            Me.txtHasta.SelectionStart = 0
        End If
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesde.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtNombre.Text = ""
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        End If

        If TipoProceso.SelectedIndex = 0 Then
            REM XNombre = WDir + "\AR-30610524598-" + Nombre.Text + "-7-LOTE1.txt"
            nombreArchivo = nombreArchivo + "\AR-30549165083-" + txtNombre.Text + "7-LOTE1.txt"
        Else
            nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"
        End If

        File.Create(nombreArchivo).Dispose()

        Dim escritor As New System.IO.StreamWriter(nombreArchivo)

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Select Case TipoProceso.SelectedIndex
            Case 0
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoperceib", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposPercepciones As New ProcesoPercecion(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6).ToString, row.Item(7), row.Item(8).ToString)

                    WCuit = leederecha(CamposPercepciones.cuit, 13)
                    WFecha = CamposPercepciones.fecha
                    If CamposPercepciones.impoib > 0 Then
                        WTipoFac = "F"
                        WImporte = ceros(formatonumerico(redondeo(CamposPercepciones.impoib), "########0.#0", "."), 11)
                        WNeto = ceros(formatonumerico(redondeo(CamposPercepciones.neto), "########0.#0", "."), 12)
                    Else
                        WTipoFac = "C"
                        WImporteII = CamposPercepciones.impoib * -1
                        WNetoII = CamposPercepciones.neto * -1
                        WImporte = "-" + ceros(formatonumerico(redondeo(WImporteII), "########0.#0", "."), 10)
                        WNeto = "-" + ceros(formatonumerico(redondeo(WNetoII), "########0.#0", "."), 11)
                    End If
                    WNumero = ceros(CamposPercepciones.numero, 8)

                    WCampo1 = WCuit
                    WCampo2 = WFecha
                    WCampo3 = WTipoFac
                    WCampo4 = "A0001"
                    WCampo5 = WNumero
                    WCampo6 = WNeto
                    WCampo7 = WImporte
                    WCampo8 = WFecha
                    WCampo9 = "A"

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

            Case Else
                Dim tabla As DataTable
                tabla = SQLConnector.retrieveDataTable("procesoperceibtucuman", ordDesde, ordHasta)

                For Each row As DataRow In tabla.Rows

                    Dim CamposPercepcionTucuman As New ProcesoPercepcionTucuman(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString, row.Item(6), row.Item(7).ToString, row.Item(8), row.Item(9))


                    WFecha = CamposPercepcionTucuman.fecha
                    WCuit = sacaguiones(CamposPercepcionTucuman.cuit)
                    WNumero = ceros(CamposPercepcionTucuman.numero, 8)
                    WNeto = ceros(formatonumerico(redondeo(CamposPercepcionTucuman.neto), "########0.#0", "."), 15)
                    WPorceIbII = 1.75
                    WPorceIb = ceros(formatonumerico(redondeo(WPorceIbII), "########0.#0", "."), 6)
                    WImporte = ceros(formatonumerico(redondeo(CamposPercepcionTucuman.impoibtucu), "########0.#0", "."), 15)


                    REM fecha
                    WCampo1 = WFecha
                    REM tipo de documento
                    WCampo2 = "80"
                    REM documento
                    WCampo3 = WCuit
                    REM tipo de comprobante
                    Select Case Val(CamposPercepcionTucuman.tipo)
                        Case 1, 3
                            WCampo4 = "01"
                        Case 4
                            WCampo4 = "02"
                        Case Else
                            WCampo4 = "03"
                    End Select
                    REM Letra de comprobante
                    WCampo5 = "A"
                    REM Punto de Venta
                    WCampo6 = "0001"
                    REM Numero del Comprobante
                    WCampo7 = WNumero
                    REM Numero del Comprobante
                    WCampo8 = WNeto
                    REM alicutoa
                    WCampo9 = WPorceIb
                    REM importe de la retencion
                    WCampo10 = WImporte
                    REM nor de ingresos brutos
                    REM Campo11 = Left$(WNroIbTucu + Space$(11), 11)
                    WCampo11 = ""

                    escritor.Write(WCampo1 + WCampo2 + WCampo3 + WCampo4 + WCampo5 + WCampo6 + WCampo7 + WCampo8 + WCampo9 + WCampo10 + WCampo11 + vbCrLf)

                Next

                escritor.Close()

                MsgBox("Proceso Finalizado de Percepciones de Ingresoe Brutos", MsgBoxStyle.Information)

        End Select

    End Sub

    
    Private Sub CustomButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomButton1.Click
        Dim viewer As New ReportViewer("Bancos", Globals.reportPathWithName("bancosnew.rpt"), "")
        viewer.Show()
        'viewer.imprimirReporte()
        'viewer.descargarComoPDF()


        ' Dim cryRpt As New ReportDocument
        'cryRpt.Load("C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt")
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()

        'REM cryRpt.PrintToPrinter(1, False, 1, 1)
        'cryRpt.PrintToPrinter(1, False, 1, 1)

        'Dim CrExportOptions As ExportOptions
        'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        'CrExportOptions = cryRpt.ExportOptions
        'With CrExportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.PortableDocFormat
        '    .DestinationOptions = CrDiskFileDestinationOptions
        '    .FormatOptions = CrFormatTypeOptions
        'End With

        ''Exporta y crea el pdf.
        'cryRpt.Export()

    End Sub

    Private Sub CustomButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomButton2.Click
        Dim viewer As New ReportViewer("Bancos", "C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt", "")
        viewer.descargarComoPDF()
        MsgBox("Descargado en: " & Application.StartupPath & "\Reportes")
    End Sub

    Private Sub CustomButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomButton3.Click
        Dim viewer As New ReportViewer("Bancos", "C:\surfactan\sistemas\administracion\crystalreport\bancosnew.rpt", "")
        viewer.imprimirReporte()
    End Sub
End Class