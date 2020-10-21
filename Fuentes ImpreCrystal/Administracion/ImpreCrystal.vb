Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Util

Public Class ImpreCrystal

    Private Sub ImpreCrystal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String

        Dim txtNombrePdf As String
        Dim txtNombreBusqueda As String
        Dim txtDocuments As String

        Dim txtCodigo As Integer
        Dim txtProceso As Integer
        Dim txtDestino As Integer
        Dim txtPlanta As Integer
        Dim txtOrden As String
        Dim txtNombre As String
        Dim txtNombreReporte As String

        Dim txtTipoCompro As String

        Dim txtClave As Integer = 1
        Dim x As Char = Chr(34)

        Dim trabajo = TryCast(DAOTrabajo.buscarTrabajoPorCodigo(txtClave), Trabajo)

        '    trabajo = New Trabajo(1, 2, 2, 5, 11608, "DIRECCION DE PRUEBA")

        txtOrden = ""
        txtNombre = ""
        txtDocuments = ""
        pasanombre.Text = ""

        If Not IsNothing(trabajo) Then
            txtProceso = trabajo.Proceso
            txtPlanta = trabajo.Planta
            txtOrden = trabajo.Orden.ToString
            txtCodigo = trabajo.Codigo
            txtDestino = trabajo.Destino
            txtOrden = trabajo.Orden.ToString
            txtNombre = trabajo.Nombre.ToString
        Else
            MsgBox("no  encontro registro")
        End If

        'txtProceso = 2
        'txtDestino = 2

        Select Case txtProceso
            Case 1
                txtNombre = ""
                REM genera la orden de compra 
                txtUno = "{Orden.Orden} in " + txtOrden + " to " + txtOrden
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtNombrePdf = "Orden " + txtOrden + " Orden de Importacion"
                        txtNombreBusqueda = "c:\orden\" + "Orden " + txtOrden + " Orden de Importacion.pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If

                        Select Case txtPlanta
                            Case 1
                                With New VistaPrevia
                                    .Base = "SurfactanSa"
                                    .Reporte = New impreordenimportacionplantainet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaINet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case 3
                                With New VistaPrevia
                                    .Base = "Surfactan_II"
                                    .Reporte = New impreordenimportacionplantaiinet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaIINet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case 5
                                With New VistaPrevia
                                    .Base = "Surfactan_III"
                                    .Reporte = New impreordenimportacionplantaiiinet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaIIINet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case 6
                                With New VistaPrevia
                                    .Base = "Surfactan_IV"
                                    .Reporte = New impreordenimportacionplantaivnet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaIVNet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case 7
                                With New VistaPrevia
                                    .Base = "Surfactan_V"
                                    .Reporte = New impreordenimportacionplantavnet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaVnet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case 10
                                With New VistaPrevia
                                    .Base = "Surfactan_VI"
                                    .Reporte = New impreordenimportacionplantavinet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaVINet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                            Case Else
                                With New VistaPrevia
                                    .Base = "Surfactan_VII"
                                    .Reporte = New impreordenimportacionplantavinet()
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionPlantaVIINet.rpt", txtFormula, txtNombrePdf, "")
                                'viewer.descargarComoPDF()

                        End Select

                End Select


                REM genera la orden de compra 
                txtUno = "{CertificadoMp.Renglon} in 0 to 999999"
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra de Importaciones", "n:\net\crystal\ImpreOrdenImportacionNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtNombrePdf = "Orden " + txtOrden + " Especificaciones"
                        txtNombreBusqueda = "c:\orden\" + "Orden " + txtOrden + " Especificaciones.pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If

                        With New VistaPrevia
                            .Base = "Surfactan_II"
                            .Reporte = New recuired_specs_po_nro_net()
                            .Formula = txtFormula
                            .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                        End With

                        'Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra de Importaciones", "n:\net\crystal\recuired specs po nro net.rpt", txtFormula, txtNombrePdf, "")
                        'viewer.descargarComoPDF()

                End Select

            Case 2
                REM genera la orden de compra 
                txtUno = "{Orden.Orden} in " + txtOrden + " to " + txtOrden
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\OrdenNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\OrdenNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtNombrePdf = txtOrden + " Orden de Compra"
                        txtNombreBusqueda = "c:\orden\" + txtOrden + " Orden de Compra.pdf"
                        'If File.Exists(txtNombreBusqueda) Then
                        File.Delete(txtNombreBusqueda)
                        'End If

                        Select Case txtPlanta
                            Case 1
                                With New VistaPrevia
                                    .Base = "SurfactanSa"
                                    .Reporte = New orden1net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden1Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 3
                                With New VistaPrevia
                                    .Base = "Surfactan_II"
                                    .Reporte = New orden2net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\orden2Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 5
                                With New VistaPrevia
                                    .Base = "Surfactan_III"
                                    .Reporte = New orden3net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden3Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 6
                                With New VistaPrevia
                                    .Base = "Surfactan_IV"
                                    .Reporte = New orden4net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden4Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 7
                                With New VistaPrevia
                                    .Base = "Surfactan_V"
                                    .Reporte = New orden7net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden7Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 10
                                With New VistaPrevia
                                    .Base = "Surfactan_VI"
                                    .Reporte = New orden110net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden110Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case 11
                                With New VistaPrevia
                                    .Base = "Surfactan_VII"
                                    .Reporte = New orden111net
                                    .Reporte.SetParameterValue(0, txtNombre)
                                    .Formula = txtFormula
                                    .Exportar(txtNombrePdf, ExportFormatType.PortableDocFormat, "c:\Orden")
                                End With
                                'Dim viewer As New ReportViewer("Ordenes de Compra", "n:\net\crystal\Orden111Net.rpt", txtFormula, txtNombrePdf, txtNombre)
                                'viewer.descargarComoPDF()

                            Case Else

                        End Select

                End Select

            Case 3
                REM genera las especificaciones
                txtNombre = ""
                txtUno = "{ListaEspe.Codigo} in " + x + "" + x + " to " + x + "ZZZZZZZZZZ" + x
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra", "N:\net\crystal\ListaEspePdfNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra", "N:\net\crystal\ListaEspePdfNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtNombrePdf = txtOrden + " Especificaciones"
                        txtNombreBusqueda = "c:\orden\" + txtOrden + " Especificaciones.pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If

                        Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra", "n:\net\crystal\ListaEspePdfNet.rpt", txtFormula, txtNombrePdf, "")
                        viewer.descargarComoPDF()

                End Select

            Case 4, 5, 6, 10
                REM genera la factura
                txtNombre = ""

                If txtProceso = 4 Then
                    txtNombreReporte = "N:\net\crystal\ImpreFacturaLocalDolarNuevoNet.rpt"
                    REM txtNombreReporte = "c:\orden\crystal\ImpreFacturaLocalDolarNuevoNet.rpt"
                Else
                    If txtProceso = 5 Then
                        txtNombreReporte = "N:\net\crystal\ImpreFacturaLocalPesosNuevoPesosNet.rpt"
                    Else
                        If txtProceso = 6 Then
                            txtNombreReporte = "N:\net\crystal\ImpreFacturaLocalPesosNuevoNet.rpt"
                        Else
                            txtNombreReporte = "N:\net\crystal\ImpreFacturaLocalPesosNuevoNetC55.rpt"
                        End If
                    End If
                End If

                txtUno = "{ImpreFactura.Numero} in " + x + "0" + x + " to " + x + "999999" + x
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        REM Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra", "N:\net\crystal\ListaEspePdfNet.rpt", txtFormula, "")
                        Dim viewer As New ReportViewer("Facturas", txtNombreReporte, txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Facturas", txtNombreReporte, txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtTipoCompro = ""
                        Select Case txtPlanta
                            Case 0
                                txtTipoCompro = "FC"
                            Case 1
                                txtTipoCompro = "ND"
                            Case 2
                                txtTipoCompro = "NC"
                            Case Else
                                txtTipoCompro = ""
                        End Select


                        txtNombrePdf = txtTipoCompro + " 0009-" + ceros(txtOrden, 8)
                        txtNombreBusqueda = "c:\orden\" + txtTipoCompro + " 0009-" + ceros(txtOrden, 8) + ".pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If

                        Dim viewer As New ReportViewer("Facturas", txtNombreReporte, txtFormula, txtNombrePdf, "")
                        viewer.descargarComoPDF()

                End Select

            Case 7
                REM genera las certificados de analisis
                txtUno = "{Certificado.Partida} in 0 to 999999"
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Certificados de Analisis", "N:\net\crystal\CertificadoPdfNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Certificados de Analisis", "N:\net\crystal\CertificadoPdfNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        pasanombre.Text = "c:\PdfPrintII\"
                        txtNombrePdf = LTrim(RTrim(txtNombre))
                        txtNombreBusqueda = "c:\PdfPrintII\" + txtNombre + ".pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If
                        Dim viewer As New ReportViewer("Certificados de Analisis", "n:\net\crystal\CertificadoPdfNet.rpt", txtFormula, txtNombrePdf, "")
                        viewer.descargarComoPDF()
                End Select



            Case 8
                'Dim varInicio As Double
                'Dim varFinal As Double
                'Dim varControl As Double
                'Dim varHora As String


                For Each Archivo As String In My.Computer.FileSystem.GetFiles("c:\PdfPrint", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                    With New Process
                        txtNombrePdf = Archivo
                        MsgBox("Impresion de :" + txtNombrePdf)
                        Call ImpresionPdf(txtNombrePdf)
                    End With
                Next


                'txtNombrePdf = txtNombre
                'Call ImpresionPdf(txtNombrePdf)

                'varHora = Now.ToString("HH:mm:ss")
                'varInicio = (Val(Mid$(varHora, 1, 2)) * 3600) + (Val(Mid$(varHora, 4, 2)) * 60) + (Val(Mid$(varHora, 7, 2)) * 1)
                'varFinal = varInicio + 5

                'Do
                '    varHora = Now.ToString("HH:mm:ss")
                '    varControl = (Val(Mid$(varHora, 1, 2)) * 3600) + (Val(Mid$(varHora, 4, 2)) * 60) + (Val(Mid$(varHora, 7, 2)) * 1)
                '    If varControl > varFinal Then
                '        Exit Do
                '    End If
                'Loop


            Case 9

                txtNombre = LTrim(RTrim(txtNombre))
                txtNombrePdf = ""
                txtNombreBusqueda = ""

                If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                    pasanombre.Text = FolderBrowserDialog1.SelectedPath + "\"
                    txtNombrePdf = LTrim(RTrim(txtNombre))
                    txtNombreBusqueda = FolderBrowserDialog1.SelectedPath + "\" + txtNombre + ".pdf"
                End If

                REM genera las especificaciones
                txtUno = "{ListaEspe.Codigo} in " + x + txtNombre + "" + x + " to " + x + txtNombre + x
                txtDos = ""
                txtFormula = txtUno + txtDos

                If File.Exists(txtNombreBusqueda) Then
                    File.Delete(txtNombreBusqueda)
                End If

                Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra", "n:\net\crystal\ListaEspePdfNet.rpt", txtFormula, txtNombrePdf, "")
                viewer.descargarComoPDF()

            Case 11
                REM genera las ordens de comrpa de dy
                REM txtDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                pasanombre.Text = "c:\users\"
                txtNombre = LTrim(RTrim(txtNombre))
                txtUno = "{Orden.Orden} in " + txtOrden + " to " + txtOrden
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Ordenes de Compra de Importacion ", "N:\net\crystal\ImpreOrdenDyNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Ordenes de Compra de Importacion ", "N:\net\crystal\ImpreOrdenDyfNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        txtNombrePdf = "\Hector-TXT\Documents\DYSTAR\PEDIDOS\" + txtNombre
                        MsgBox("Generacion del PDF :" + txtNombrePdf)
                        txtNombreBusqueda = "\Hector-TXT\Documents\DYSTAR\PEDIDOS\" + txtNombre + ".pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If

                        Dim viewer As New ReportViewer("Ordenes de Compra de Importacion ", "n:\net\crystal\ImpreOrdenDyNet.rpt", txtFormula, txtNombrePdf, "")
                        viewer.descargarComoPDF()

                End Select

            Case 12

                txtNombre = LTrim(RTrim(txtNombre))
                txtNombrePdf = ""
                txtNombreBusqueda = ""

                If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                    pasanombre.Text = FolderBrowserDialog1.SelectedPath + "\"
                    txtNombrePdf = LTrim(RTrim(txtNombre))
                    txtNombreBusqueda = FolderBrowserDialog1.SelectedPath + "\" + txtNombre + ".pdf"
                End If

                REM genera las especificaciones
                txtUno = "{ListaEspe.Codigo} in " + x + txtNombre + "" + x + " to " + x + txtNombre + x
                txtDos = ""
                txtFormula = txtUno + txtDos

                If File.Exists(txtNombreBusqueda) Then
                    File.Delete(txtNombreBusqueda)
                End If

                Dim viewer As New ReportViewer("Especificaciones de Ordenes de Compra (INGLES)", "n:\net\crystal\ListaEspePdfInglesNet.rpt", txtFormula, txtNombrePdf, "")
                viewer.descargarComoPDF()

            Case 13
                REM genera las certificados de analisis
                txtUno = "{Certificado.Partida} in 0 to 999999"
                txtDos = ""
                txtFormula = txtUno + txtDos

                Select Case txtDestino
                    Case 0
                        Dim viewer As New ReportViewer("Certificados de Analisis", "N:\net\crystal\CertificadoTanatexPdfNet.rpt", txtFormula, "", "")
                        viewer.Show()

                    Case 1
                        Dim viewer As New ReportViewer("Certificados de Analisis", "N:\net\crystal\CertificadoTanatexPdfNet.rpt", txtFormula, "", "")
                        viewer.imprimirReporte()

                    Case Else
                        pasanombre.Text = "N:\Net\ProcesoImpresionPDF\CertificadosTanatex\"
                        txtNombrePdf = LTrim(RTrim(txtNombre))
                        txtNombreBusqueda = "N:\Net\ProcesoImpresionPDF\CertificadosTanatex\" + txtNombre + ".pdf"
                        If File.Exists(txtNombreBusqueda) Then
                            File.Delete(txtNombreBusqueda)
                        End If
                        Dim viewer As New ReportViewer("Certificados de Analisis", "n:\net\crystal\CertificadoTanatexPdfNet.rpt", txtFormula, txtNombrePdf, "")
                        viewer.descargarComoPDF()
                End Select

            Case 14
                txtUno = "{ImpreFactura.Numero} in " + x + "0" + x + " to " + x + "999999" + x
                txtDos = ""
                txtFormula = txtUno + txtDos

                txtNombrePdf = "14" + " 0009-" + ceros(txtOrden, 8)
                txtNombreBusqueda = "c:\orden\" + "14" + " 0009-" + ceros(txtOrden, 8) + ".pdf"
                If File.Exists(txtNombreBusqueda) Then
                    File.Delete(txtNombreBusqueda)
                End If

                Dim viewer As New ReportViewer("Facturas", New imprerechazadosurfa(), txtFormula, txtNombrePdf)
                viewer.descargarComoPDF()

            Case Else

        End Select


        Close()
        End


    End Sub

End Class