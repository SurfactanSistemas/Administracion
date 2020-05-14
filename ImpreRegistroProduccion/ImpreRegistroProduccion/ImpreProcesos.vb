Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop.Outlook
Imports Util.Clases

Public Class ImpreProcesos

    Dim WTipoVencimiento As Integer = 0

    Private Sub ImpreRegistroProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If Environment.GetCommandLineArgs.Length > 1 Then

                Dim WProceso As Integer = Environment.GetCommandLineArgs(1)

                'WProceso = 1

                Select Case WProceso
                    Case 1, 4, 2, 3, 6

                        If Normalizaciones.ConfiguracionRegional() Then
                            MsgBox("La CONFIGURACIÓN REGIONAL de su PC no se encontraba correctamente seteada y hubo que modificarla." & vbCrLf & " Por favor, vuelva a realizar la acción que solicitó para que tome la nueva configuración.", MsgBoxStyle.Exclamation)
                            Close()
                        End If

                End Select


                Select Case WProceso
                    Case 1, 4 ' REGISTRO DE PRODUCCIÓN.

                        Dim WTerminado As String = Environment.GetCommandLineArgs(2)
                        Dim WPartida As Integer = Environment.GetCommandLineArgs(3)
                        Dim WInicio, WFinal, WFraccionamiento, WEtiquetas, WMerma, WConciliacion As Integer

                        WFraccionamiento = 1
                        WEtiquetas = 1
                        WMerma = 1

                        If Environment.GetCommandLineArgs.Length > 4 Then WInicio = Environment.GetCommandLineArgs(4)
                        If Environment.GetCommandLineArgs.Length > 5 Then WFinal = Environment.GetCommandLineArgs(5)
                        If Environment.GetCommandLineArgs.Length > 6 Then WFraccionamiento = Environment.GetCommandLineArgs(6)
                        If Environment.GetCommandLineArgs.Length > 7 Then WEtiquetas = Environment.GetCommandLineArgs(7)
                        If Environment.GetCommandLineArgs.Length > 8 Then WMerma = Environment.GetCommandLineArgs(8)
                        If Environment.GetCommandLineArgs.Length > 9 Then WConciliacion = Environment.GetCommandLineArgs(9)

                        _GenerarRegistroProduccion(WTerminado, WPartida, WInicio, WFinal, WFraccionamiento, WEtiquetas, WMerma, WProceso = 4, WConciliacion)

                    Case 2 ' CERTIFICADO DE CALIDAD.

                        Dim WTipoReporte As Integer = Environment.GetCommandLineArgs(2)
                        Dim WPartida As Integer = Environment.GetCommandLineArgs(3)
                        Dim WTipoSalida As Integer = Environment.GetCommandLineArgs(4)
                        Dim WNombrePDF As String = ""
                        Dim WRuta As String = ""
                        If Environment.GetCommandLineArgs.Length > 5 Then WNombrePDF = Environment.GetCommandLineArgs(5)
                        If Environment.GetCommandLineArgs.Length > 6 Then WRuta = Environment.GetCommandLineArgs(6)

                        _GenerarCertificadoAnalisisFarma(WTipoReporte, WPartida, WTipoSalida, WNombrePDF, WRuta)

                    Case 3 ' Resultados de Calidad (PrueterFarma -> Registro de Producción)

                        Dim WLim = Environment.GetCommandLineArgs.Length - 1

                        Dim WPartida As Integer = Environment.GetCommandLineArgs(2)
                        Dim WTipoSalida As Integer = 0
                        Dim WFechaVto = " ", WImpreFechaVto = " ", WFechaElabora = " ", WImpreFechaElaboracion = " "

                        If WLim > 2 Then
                            WTipoSalida = Environment.GetCommandLineArgs(3)
                        End If

                        If WLim > 3 Then
                            WFechaVto = Environment.GetCommandLineArgs(4)
                        End If

                        If WLim > 4 Then
                            WImpreFechaVto = Environment.GetCommandLineArgs(5)
                        End If

                        If WLim > 5 Then
                            WFechaElabora = Environment.GetCommandLineArgs(6)
                        End If

                        If WLim > 6 Then
                            WImpreFechaElaboracion = Environment.GetCommandLineArgs(7)
                        End If

                        _GenerarReporteResultadosCalidad(WPartida, WTipoSalida, WFechaVto, WImpreFechaVto, WFechaElabora, WImpreFechaElaboracion)
                    Case 5

                        Dim WLim = Environment.GetCommandLineArgs.Length

                        Dim WDestinatarios As String = Environment.GetCommandLineArgs(2)
                        Dim WAsunto As String = ""
                        Dim WCuerpo = "", WAdjuntos = ""

                        'For Each o As Object In Environment.GetCommandLineArgs
                        'MsgBox(WLim)
                        ' Next

                        If WLim > 3 Then
                            WAsunto = Environment.GetCommandLineArgs(3)
                        End If

                        If WLim > 4 Then
                            WCuerpo = Environment.GetCommandLineArgs(4)
                        End If

                        If WLim > 5 Then
                            WAdjuntos = Environment.GetCommandLineArgs(5)
                        End If

                        'MsgBox(WAdjuntos)

                        _EnviarMail(WDestinatarios, WAsunto, WCuerpo, WAdjuntos)

                    Case 6 'HOJA DE RUTA (DANIEL RODRIGUEZ)

                        Dim WLim = Environment.GetCommandLineArgs.Length

                        Dim WHojaRuta As String = Environment.GetCommandLineArgs(2)
                        Dim WRutaArchivo As String = "C:\TempHojaRuta"
                        'Dim WCuerpo = "", WAdjuntos = ""

                        'For Each o As Object In Environment.GetCommandLineArgs
                        'MsgBox(WLim)
                        ' Next

                        If WLim > 3 Then
                            WRutaArchivo = Environment.GetCommandLineArgs(3)
                        End If

                        _GenerarInformeHojaRuta(WHojaRuta, WRutaArchivo)

                        'If WLim > 4 Then
                        ' WCuerpo = Environment.GetCommandLineArgs(4)
                        ' End If
                        '
                        '                        If WLim > 5 Then
                        ' WAdjuntos = Environment.GetCommandLineArgs(5)
                        ' End If
                        '
                        'MsgBox(WAdjuntos)

                        '_EnviarMail(WHojaRuta, WAsunto, WCuerpo, WAdjuntos)

                    Case Else
                        Close()
                End Select

            End If

            '_GenerarInformeHojaRuta("17899", "C:\TempHojaRuta")

            'Dim WTipoReporte2 As Integer = 4
            'Dim WPartida2 As Integer = 0
            'Dim WTerminado2 As String = "PT-25062-780"
            'Dim WTipoSalida2 As Integer = 2

            '_GenerarCertificadoAnalisisFarma(1, 310583, 3)

            'WTipoReporte2 = 3

            '_GenerarCertificadoAnalisisFarma(WTipoReporte2, WPartida2, WTipoSalida2, "C:\blablabla\prueba.pdf")

            'Dim WTerminado2 As String = "PT-25071-100"
            ''Dim WPartida2 As Integer = "310445"
            'Dim WPartida2 As Integer = "0"

            ' _GenerarRegistroProduccion("PT-25015-110", "310479", 0, 0, 1, 0, 1, True, 1)

            'Dim WImpreFechaVto2 = "", WFechaElabora2 = "", WImpreFechaElaboracion2 = "", WFechaVto2 = ""

            '_GenerarReporteResultadosCalidad(WPartida2, 1, WFechaVto2, WImpreFechaVto2, WFechaElabora2, WImpreFechaElaboracion2)
            '_GenerarReporteResultadosCalidad(WPartida2, 4, WFechaVto2, WImpreFechaVto2, WFechaElabora2, WImpreFechaElaboracion2)

        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally

            Close()

        End Try

    End Sub

    Private Sub _GenerarInformeHojaRuta(WHojaRuta As String, WRutaArchivo As String)

        If Val(WHojaRuta) = 0 Then Exit Sub
        If Trim(WRutaArchivo) = "" Then WRutaArchivo = "C:\TempHojaRuta\"

        If Not Directory.Exists(WRutaArchivo) Then Directory.CreateDirectory(WRutaArchivo)

        Dim WHoja As DataTable = GetAll("SELECT Hoja, Pedido, Remito FROM HojaRuta WHERE Hoja = '" & WHojaRuta & "' And Archivo <> ''", "SurfactanSa")

        If WHoja.Rows.Count = 0 Then Exit Sub

        '
        ' Armamos los registros para el reporte.
        '
        'ExecuteNonQueries("SurfactanSa", {"DELETE FROM HojaRutaLotePedidos WHERE Pedido = ''"})
        Dim WColumnas As String = ""

        For i As Integer = 1 To 5
            WColumnas &= String.Format("Lote{0}, CantiLote{0}, UltimoLote{0}, UltimoCantiLote{0},", i)
        Next

        WColumnas = WColumnas.Substring(0, WColumnas.LastIndexOf(","))

        Dim WSqls As New List(Of String)

        WHoja.Rows.Cast(Of DataRow).ToList.ForEach(Sub(p) WSqls.Add("DELETE FROM HojaRutaLotePedidos WHERE Pedido = '" & p.Item("Pedido") & "' And Remito = '" & p.Item("Remito") & "'"))

        For Each row As DataRow In WHoja.Rows

            If row.Item("Pedido") = 401340 Then Stop

            Dim WPedido As DataTable = GetAll("SELECT Terminado, " & WColumnas & " FROM Pedido WHERE Pedido = '" & row.Item("Pedido") & "' And (Remito = '" & row.Item("Remito") & "' Or NroRemito = '" & row.Item("Remito") & "')", "SurfactanSa")

            For Each WProd As DataRow In WPedido.Rows

                Dim WLote, WCant As String

                For i As Integer = 1 To 5
                    WLote = OrDefault(WProd.Item("Lote" & i), "")
                    WCant = formatonumerico(OrDefault(WProd.Item("CantiLote" & i), ""))

                    If Val(WLote) = 0 And Val(WCant) = 0 Then
                        WLote = OrDefault(WProd.Item("UltimoLote" & i), "")
                        WCant = formatonumerico(OrDefault(WProd.Item("UltimoCantiLote" & i), ""))
                    End If

                    If Val(WLote) = 0 Or Val(WCant) = 0 Then Continue For

                    WSqls.Add(String.Format("INSERT INTO HojaRutaLotePedidos (Pedido, Remito, Producto, Lote, Cantidad) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", row.Item("Pedido"), row.Item("Remito"), WProd.Item("Terminado"), WLote, WCant))

                Next

            Next

        Next

        ExecuteNonQueries("SurfactanSa", WSqls.ToArray)

        With New VistaPrevia
            .Base = "SurfactanSa"
            .Reporte = New ResumenHojaRuta
            .Formula = "{HojaRuta.Hoja} = " & WHojaRuta & " And {HojaRuta.Archivo} <> ''"
            .Exportar(WHojaRuta & ".pdf", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, WRutaArchivo)
        End With

    End Sub

    Private Sub _EnviarMail(wDestinatarios As String, wAsunto As String, wCuerpo As String, wAdjuntos As String)
        Dim oApp As _Application
        Dim oMsg As _MailItem

        Try
            oApp = New Application()

            oMsg = oApp.CreateItem(OlItemType.olMailItem)
            oMsg.Subject = wAsunto
            oMsg.Body = wCuerpo

            ' Modificar por los E-Mails que correspondan.
            oMsg.To = wDestinatarios

            If wAdjuntos.Split(";").Count > 0 Then

                For Each archivosAdjunto As String In wAdjuntos.Split(";")

                    If archivosAdjunto.Trim <> "" Then oMsg.Attachments.Add(archivosAdjunto)

                Next

            End If

            'oMsg.Display()
            oMsg.Send()

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        End Try
    End Sub

    Private Sub _GenerarReporteResultadosCalidad(ByVal wPartida As Integer, ByVal wTipoSalida As Integer, ByVal wFechaVto As String, ByVal wImpreFechaVto As String, ByVal wFechaElabora As String, ByVal wImpreFechaElaboracion As String)

        With New VistaPrevia

            '.Reporte = New imprecalidadresultado
            If {0, 1}.Contains(wTipoSalida) Then
                .Reporte = New imprecalidadresultadoReduccionAl80
            Else
                .Reporte = New imprecalidadresultado
            End If

            .Reporte.SetParameterValue("FechaVto", wFechaVto)
            .Reporte.SetParameterValue("ImpreFechaVto", wImpreFechaVto)
            .Reporte.SetParameterValue("FechaElabora", wFechaElabora)
            .Reporte.SetParameterValue("ImpreFechaElaboracion", wImpreFechaElaboracion)
            .Formula = "{Prueterfarma.Partida} = " & wPartida & " And {Hoja.Hoja} = {Prueterfarma.Partida} And {Hoja.Renglon} = 1"

            Select Case wTipoSalida
                Case 0, 1, 4
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    .Exportar("Resultados de Calidad " & wPartida & " " & Date.Now.ToString("dd-MM-yyyy"), CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select

        End With

    End Sub

    Private Sub _GenerarCertificadoAnalisisFarma(ByVal WTipoReporte As Integer, ByVal wPartida As Integer, ByVal wTipoSalida As Integer, Optional ByVal WNombrePDF As String = "", Optional ByVal Ruta As String = "")

        Dim frm As New ReportDocument
        Dim WFormulas() As String
        Dim WNombreArchivoFormulas As String = "C:\ImpreCertificados\" & wPartida

        Directory.CreateDirectory("C:\ImpreCertificados")

        '
        ' Determinamos el Reporte a imprimir y los datos de las formulas a pasar como parámetro.
        '
        Select Case WTipoReporte
            Case 1

                frm = New certificadonuevofarma

                WNombreArchivoFormulas &= "Formulas.txt"

            Case 2

                frm = New certificadonuevofarmaprimero

                WNombreArchivoFormulas &= "FormulasPrimero.txt"

            Case 3

                frm = New certificadonuevofarmasegunda

                WNombreArchivoFormulas &= "FormulasSegunda.txt"

            Case Else
                Exit Sub
        End Select

        If Not File.Exists(WNombreArchivoFormulas) Then
            MsgBox("No se encuentra archivo " & WNombreArchivoFormulas)
            Exit Sub
        End If

        WFormulas = File.ReadAllLines(WNombreArchivoFormulas, UTF7Encoding.UTF7)

        For Each wFormula As String In WFormulas
            Dim WDato() As String = wFormula.Split("=")

            If WDato.Length < 2 Then Continue For

            frm.DataDefinition.FormulaFields(WDato(0)).Text = WDato(1)

        Next

        frm.SetParameterValue("MostrarLogo", 0)
        frm.SetParameterValue("MostrarPie", 0)

        If wTipoSalida = 3 Or wTipoSalida = 4 Or wTipoSalida = 6 Or wTipoSalida = 7 Then
            frm.SetParameterValue("MostrarLogo", 1)
            frm.SetParameterValue("MostrarPie", 1)
        End If

        With New VistaPrevia
            .Reporte = frm
            .Formula = "{Certificado.Partida} = " & wPartida & ""

            Dim WNombre As String = WNombrePDF
            Dim WRuta As String = ""

            If wTipoSalida = 4 Then WRuta = "C:\ImpreCertificados\"
            If wTipoSalida = 7 Then WRuta = "\\193.168.0.2\w\Impresion pdf\Certificados Analisis Farma Liberacion Pedidos\" & Ruta

            If WNombre.Trim = "" Then

                WNombre = "Certificado " & wPartida
                Select Case WTipoReporte
                    Case 2
                        WNombre &= " - Primera"
                    Case 3
                        WNombre &= " - Segunda"
                End Select

            Else

                Dim match = Regex.Split(WNombrePDF, "[\w+\.pdf]+$")

                If match.Count > 0 AndAlso match(0).Trim <> "" And wTipoSalida <> 7 Then
                    wTipoSalida = 4
                    WRuta = match(0)
                    WNombre = WNombrePDF.Replace(WRuta, "")
                End If

            End If

            If Not UCase(WNombre).EndsWith("PDF") And WNombre.Trim <> "" Then WNombre &= ".pdf"
            If WRuta.EndsWith(Chr(34)) Then WRuta = WRuta.Substring(0, WRuta.IndexOf(Chr(34))) & "\"

            'MsgBox(wTipoSalida)
            'MsgBox(WRuta)

            Select Case wTipoSalida
                Case 1, 6
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    'MsgBox(WNombre)
                    .Exportar(WNombre, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
                Case 4, 7
                    'MsgBox("Tipo: " & wTipoSalida & " - Ruta: " & WRuta & " - Nombre PDF: " & WNombrePDF & " - Nombre: " & WNombre)
                    .Exportar(WNombre, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, WRuta)
                    If wTipoSalida = 7 And WTipoReporte <> 2 Then .MergePDFs(WRuta, WNombrePDF)
                Case 5
                    .Exportar(WNombre, CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select


        End With

    End Sub

    Private Sub _GenerarRegistroProduccion(ByVal WTerminado As String, ByVal WPartida As Integer, ByVal Inicio As Integer, ByVal Final As Integer, ByVal Fraccionamiento As Integer, ByVal Etiquetas As Integer, ByVal Merma As Integer, Optional ByVal RegistroMaestro As Boolean = False, Optional ByVal Conciliacion As Integer = 0)

        _ProcesarInformacionParaRegistroProduccion(WTerminado, WPartida, RegistroMaestro)

        Dim WTer As DataRow = GetSingle("SELECT Escrito, MarcaLabora FROM Terminado WHERE Codigo = '" & WTerminado & "'")

        If WTer Is Nothing Then Close()

        Dim WMarcaLabora = OrDefault(WTer.Item("MarcaLabora"), 0)

        Dim WImprePlanilla = 0
        Dim WImprePlanillaII = 0
        Dim WImprePlanillaIII = 0
        Dim WImprePlanillaIV = 0

        Dim WCargaIII As DataRow = GetSingle("SELECT ImprimePlanilla, ImprimePlanillaII, ImprimePlanillaIII, ImprimePlanillaIV FROM CargaIII WHERE Terminado = '" & WTerminado & "'", "Surfactan_III")

        If WCargaIII Is Nothing Then Close()

        WImprePlanilla = OrDefault(WCargaIII.Item("ImprimePlanilla"), 0)
        WImprePlanillaII = OrDefault(WCargaIII.Item("ImprimePlanillaII"), 0)
        WImprePlanillaIII = OrDefault(WCargaIII.Item("ImprimePlanillaIII"), 0)
        WImprePlanillaIV = OrDefault(WCargaIII.Item("ImprimePlanillaIV"), 0)

        Dim WMostrarHumedad As Integer = 0

        Dim WHumedad As DataRow = GetSingle("SELECT Humedad FROM CargaIII WHERE Terminado = '" & WTerminado & "' AND Humedad = 1 And Renglon = 1")

        If Not IsNothing(WHumedad) Then WMostrarHumedad = 1

        Dim WBuscaMonoII As DataRow = GetSingle("SELECT Codigo, Tipo FROM CodigoMono WHERE Codigo = '" & WTerminado & "'")

        Dim WPasaMono As Integer = 0

        If Not IsNothing(WBuscaMonoII) Then WPasaMono = IIf(OrDefault(WBuscaMonoII.Item("Tipo"), 0) = 0, 1, 2)

        Dim WImpreVto As String = "FECHA DE REANÁLISIS:"

        If WPasaMono > 0 Or _EsFazon(WTerminado) Then

            If Val(WTipoVencimiento) = 1 Then
                WImpreVto = "FECHA DE REANÁLISIS:"
            Else
                WImpreVto = "FECHA DE VENCIMIENTO:"
            End If

        End If

        If RegistroMaestro Then WImpreVto = "TIEMPO DE VIDA ÚTIL"

        Dim rpt As New ReportDocument

        If RegistroMaestro Then
            rpt = New ImpreFarmaIIRegMaestro
        Else
            rpt = New ImpreFarmaII
        End If

        rpt.SetParameterValue("ImpreVto", WImpreVto)

        rpt.SetParameterValue("MostrarHumedad", WMostrarHumedad)
        rpt.SetParameterValue("ImprimePlanillaII", WImprePlanillaII.ToString)
        rpt.SetParameterValue("MarcaLabora", WMarcaLabora)

        If Inicio >= 0 And Final >= 0 Then

            Dim frm As New VistaPrevia

            With frm
                .Reporte = rpt
                .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = '" & WTerminado & "' And {Hoja.Renglon} = 1" ' And {CargaIII.Partida} = {Hoja.Hoja}"
                '.Mostrar()
                .Imprimir(1, Inicio, Final)
            End With

        End If

        If Inicio > 0 Or Final > 0 Then Exit Sub

        '
        ' Anexos
        '
        If ((WImprePlanilla <> 0 Or WImprePlanillaIII <> 0) And (Fraccionamiento = 1 Or Etiquetas = 1)) Or (Conciliacion <> 0 And WImprePlanillaIV = 1) Then
            Dim rptAnexos As ReportDocument

            If RegistroMaestro Then
                rptAnexos = New ImpreAnexosRegistroMaestro
            Else
                rptAnexos = New ImpreAnexos
            End If

            ' Definimos el rango de impresión para que respete la numeración de hojas.
            Inicio = 0
            Final = 0

            If WImprePlanilla <> 0 And WImprePlanillaIII <> 0 Then
                If Fraccionamiento = 1 And Etiquetas = 0 Then
                    Inicio = 1
                    Final = 1
                ElseIf Fraccionamiento = 0 And Etiquetas = 1 Then
                    Inicio = 2
                    Final = 2
                End If
            End If

            rptAnexos.SetParameterValue("ImprePlanilla", WImprePlanilla)
            rptAnexos.SetParameterValue("ImprePlanillaIII", WImprePlanillaIII)
            rptAnexos.SetParameterValue("ImpreConciliacion", WImprePlanillaIV)

            With New VistaPrevia
                .Reporte = rptAnexos
                .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = '" & WTerminado & "' And {Hoja.Renglon} = 1" ' And {CargaIII.Partida} = {Hoja.Hoja}"
                '.Mostrar()
                .Imprimir(1, Inicio, Final)
            End With

        End If

        If Val(WTerminado.Substring(3, 5)) = 3000 And Merma = 1 Then

            With New VistaPrevia
                .Reporte = IIf(RegistroMaestro, New impremermadescartestercerosRegistroMaestro, New impremermadescartesterceros)
                .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = {Terminado.Codigo} " '= '" & WTerminado & "'" ' And {CargaIII.Partida} = {Hoja.Hoja}"
                '.Mostrar()
                .Imprimir()
            End With

        End If

    End Sub

    Private Function _EsFazon(ByVal Terminado As String) As Boolean

        Dim WTer As String

        WTer = Mid(Terminado, 4, 5)

        Return Val(WTer) > 2999 And Val(WTer) < 4000

    End Function

    Private Sub _ProcesarInformacionParaRegistroProduccion(ByVal wTerminado As String, ByVal wPartida As Integer, Optional ByVal RegistroMaestro As Boolean = False)
        WTipoVencimiento = 0
        Dim WTeorico As Double = 0
        '
        ' Buscamos informacion del Terminado y Hoja.
        '
        Dim WTerm As DataRow = GetSingle("SELECT Descripcion, Linea, Vida FROM Terminado WHERE Codigo = '" & wTerminado & "'")
        Dim WHoja As DataTable = GetAll("SELECT Teorico, Fecha, Terminado, Articulo, Lote1, Lote2, Lote3, Tipo FROM Hoja WHERE Hoja = '" & wPartida & "' Order by Renglon", "Surfactan_III")

        If IsNothing(WTerm) Then Throw New System.Exception("No existe Producto Terminado con Código '" & wTerminado & "'")
        If WHoja.Rows.Count = 0 And Not RegistroMaestro Then Throw New System.Exception("No existe Hoja '" & wTerminado & "'")

        Dim WSqls As New List(Of String)

        WSqls.Add("DELETE FROM ImpreCarga")
        WSqls.Add("DELETE FROM ImpreCargaI")

        Dim WCargaI As DataTable = GetAll("SELECT Codigo = 1, c1.Cantidad, c1.Metodo, c1.Equipo, e.Descripcion, e.DescripcionII, e.Poe, e.Identificacion, e.PoeLimpieza FROM CargaI c1 INNER JOIN Equipo e ON c1.Equipo = e.Codigo WHERE c1.Terminado = '" & wTerminado & "' Order by c1.Clave", "Surfactan_III")
        Dim WCargaII As DataTable = GetAll("SELECT Codigo = 2, ma.Descripcion FROM CargaII c2 INNER JOIN MaterialAuxiliar ma ON c2.MaterialAuxiliar = ma.Codigo WHERE c2.Terminado = '" & wTerminado & "' Order by c2.Clave", "Surfactan_III")

        If WHoja.Rows.Count Then WTeorico = WHoja.Rows(0).Item("Teorico")

        For Each row As DataRow In WCargaI.Rows
            With row
                Dim WTipo As Integer = OrDefault(.Item("Codigo"), 0)
                Dim WDescripcion As String = OrDefault(.Item("Descripcion"), "")
                Dim WDescripcionII As String = OrDefault(.Item("DescripcionII"), "")
                Dim WPoe As String = OrDefault(.Item("Poe"), "")
                Dim WIdentificacion As String = OrDefault(.Item("Identificacion"), "")
                Dim WPoeLimpieza As String = OrDefault(.Item("PoeLimpieza"), "")
                Dim ZTeorico As String = formatonumerico(OrDefault(WTeorico, 0))
                Dim WDescTerminado As String = OrDefault(WTerm.Item("Descripcion"), "").ToString.Trim

                If WIdentificacion.Trim <> "" Then WDescripcion = WIdentificacion.Trim & " - " & WDescripcion

                WSqls.Add(String.Format("INSERT INTO ImpreCarga (Partida, Descripcion, Terminado, Cantidad, Tipo, DescripcionI, DescripcionII) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                        wPartida, WDescTerminado, wTerminado, ZTeorico, WTipo, WDescripcion, WDescripcionII))

            End With
        Next

        For Each row As DataRow In WCargaII.Rows
            With row
                Dim WTipo As Integer = OrDefault(.Item("Codigo"), 0)
                Dim WDescripcion As String = OrDefault(.Item("Descripcion"), "")
                Dim WDescripcionII As String = ""
                Dim WPoe As String = ""
                Dim WIdentificacion As String = ""
                Dim WPoeLimpieza As String = ""
                Dim ZTeorico As String = formatonumerico(OrDefault(WTeorico, 0))
                Dim WDescTerminado As String = OrDefault(WTerm.Item("Descripcion"), "").ToString.Trim

                If WIdentificacion.Trim <> "" Then WDescripcion = WIdentificacion.Trim & " - " & WDescripcion

                WSqls.Add(String.Format("INSERT INTO ImpreCarga (Partida, Descripcion, Terminado, Cantidad, Tipo, DescripcionI, DescripcionII) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                        wPartida, WDescTerminado, wTerminado, ZTeorico, WTipo, WDescripcion, WDescripcionII))

            End With
        Next

        Dim WImpreCargaIDatos As New DataTable

        With WImpreCargaIDatos.Columns
            .Add("Terminado")
            .Add("Descripcion")
            .Add("Partida")
            .Add("Cantidad")
            .Add("EquipoI")
            .Add("DescEquipoI")
            .Add("DescEquipoOtroI")
            .Add("MetodoI")
            .Add("EquipoII")
            .Add("DescEquipoII")
            .Add("DescEquipoOtroII")
            .Add("MetodoII")
            .Add("EquipoIII")
            .Add("DescEquipoIII")
            .Add("DescEquipoOtroIII")
            .Add("MetodoIII")
        End With

        Dim WLugar = 1

        For Each row As DataRow In WCargaI.Rows
            With row
                Dim WTipo As Integer = OrDefault(.Item("Codigo"), 0)
                Dim WCantidad As Integer = OrDefault(.Item("Cantidad"), 0)

                Dim WEquipo As String = OrDefault(.Item("Equipo"), "")
                Dim WDescripcion As String = OrDefault(.Item("Descripcion"), "")
                Dim WDescripcionII As String = OrDefault(.Item("DescripcionII"), "")
                Dim WPoe As String = OrDefault(.Item("Poe"), "")
                Dim WIdentificacion As String = OrDefault(.Item("Identificacion"), "")
                Dim WPoeLimpieza As String = OrDefault(.Item("PoeLimpieza"), "")
                Dim ZTeorico As String = formatonumerico(OrDefault(WTeorico, 0))
                Dim WDescTerminado As String = OrDefault(WTerm.Item("Descripcion"), "").ToString.Trim

                Dim WMetodo As String = WPoeLimpieza & " - " & OrDefault(.Item("Metodo"), "").ToString.Trim

                If WIdentificacion.Trim <> "" Then WDescripcion = WIdentificacion.Trim & " - " & WDescripcion

                For i = 1 To WCantidad

                    Dim r As DataRow = WImpreCargaIDatos.NewRow

                    Select Case WLugar
                        Case 1
                            r.Item("Terminado") = wTerminado
                            r.Item("Descripcion") = WDescTerminado
                            r.Item("Partida") = "0"
                            r.Item("Cantidad") = "0"
                            r.Item("EquipoI") = WEquipo
                            r.Item("DescEquipoI") = WDescripcion
                            r.Item("DescEquipoOtroI") = WDescripcionII
                            r.Item("MetodoI") = WMetodo

                            WLugar = 2
                        Case 2

                            r.Item("EquipoII") = WEquipo
                            r.Item("DescEquipoII") = WDescripcion
                            r.Item("DescEquipoOtroII") = WDescripcionII
                            r.Item("MetodoII") = WMetodo

                            WLugar = 3
                        Case 3

                            r.Item("EquipoIII") = WEquipo
                            r.Item("DescEquipoIII") = WDescripcion
                            r.Item("DescEquipoOtroIII") = WDescripcionII
                            r.Item("MetodoIII") = WMetodo

                            WLugar = 1
                    End Select

                    WImpreCargaIDatos.Rows.Add(r)

                Next

                'WSqls.Add(String.Format("INSERT INTO ImpreCarga (Partida, Descripcion, Terminado, Cantidad, Tipo, DescripcionI, DescripcionII) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                '                        wPartida, WDescTerminado.Trim, wTerminado, WTeorico, WTipo, WDescripcion.Trim, WDescripcionII.Trim))

            End With
        Next

        WLugar = 0

        For Each row As DataRow In WImpreCargaIDatos.Rows
            With row

                WLugar += 1

                Dim ZZCodigo = WLugar

                Dim ZZTerminado = OrDefault(.Item("Terminado"), "")
                Dim ZZDescripcion = OrDefault(.Item("Descripcion"), "")
                Dim ZZPartida = OrDefault(.Item("Partida"), "")
                Dim ZZCantidad = OrDefault(.Item("Cantidad"), "")

                Dim ZZEquipoI = OrDefault(.Item("EquipoI"), "")
                Dim ZZDesEquipoI = OrDefault(.Item("DescEquipoI"), "")
                Dim ZZDesEquipoOtroI = OrDefault(.Item("DescEquipoOtroI"), "")
                Dim ZZMetodoI = OrDefault(.Item("MetodoI"), "")

                Dim ZZEquipoII = OrDefault(.Item("EquipoII"), "")
                Dim ZZDesEquipoII = OrDefault(.Item("DescEquipoII"), "")
                Dim ZZDesEquipoOtroII = OrDefault(.Item("DescEquipoOtroII"), "")
                Dim ZZMetodoII = OrDefault(.Item("MetodoII"), "")

                Dim ZZEquipoIII = OrDefault(.Item("EquipoIII"), "")
                Dim ZZDesEquipoIII = OrDefault(.Item("DescEquipoIII"), "")
                Dim ZZDesEquipoOtroIII = OrDefault(.Item("DescEquipoOtroIII"), "")
                Dim ZZMetodoIII = OrDefault(.Item("MetodoIII"), "")

                Dim ZSql2 = ""
                ZSql2 = ZSql2 & "INSERT INTO ImpreCargaI ("
                ZSql2 = ZSql2 & "Codigo ,"
                ZSql2 = ZSql2 & "Terminado ,"
                ZSql2 = ZSql2 & "Descripcion ,"
                ZSql2 = ZSql2 & "Partida ,"
                ZSql2 = ZSql2 & "Cantidad ,"
                ZSql2 = ZSql2 & "MetodoI ,"
                ZSql2 = ZSql2 & "EquipoI ,"
                ZSql2 = ZSql2 & "DesEquipoI ,"
                ZSql2 = ZSql2 & "DesEquipoOtroI ,"
                ZSql2 = ZSql2 & "MetodoII ,"
                ZSql2 = ZSql2 & "EquipoII ,"
                ZSql2 = ZSql2 & "DesEquipoII ,"
                ZSql2 = ZSql2 & "DesEquipoOtroII ,"
                ZSql2 = ZSql2 & "MetodoIII ,"
                ZSql2 = ZSql2 & "EquipoIII ,"
                ZSql2 = ZSql2 & "DesEquipoIII ,"
                ZSql2 = ZSql2 & "DesEquipoOtroIII )"
                ZSql2 = ZSql2 & "Values ("
                ZSql2 = ZSql2 & "'" & ZZCodigo & "',"
                ZSql2 = ZSql2 & "'" & ZZTerminado & "',"
                ZSql2 = ZSql2 & "'" & ZZDescripcion & "',"
                ZSql2 = ZSql2 & "'" & ZZPartida & "',"
                ZSql2 = ZSql2 & "'" & Str$(ZZCantidad) & "',"
                ZSql2 = ZSql2 & "'" & ZZMetodoI & "',"
                ZSql2 = ZSql2 & "'" & ZZEquipoI & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoI & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoOtroI & "',"
                ZSql2 = ZSql2 & "'" & ZZMetodoII & "',"
                ZSql2 = ZSql2 & "'" & ZZEquipoII & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoII & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoOtroII & "',"
                ZSql2 = ZSql2 & "'" & ZZMetodoIII & "',"
                ZSql2 = ZSql2 & "'" & ZZEquipoIII & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoIII & "',"
                ZSql2 = ZSql2 & "'" & ZZDesEquipoOtroIII & "')"

                WSqls.Add(ZSql2)

            End With
        Next

        WSqls.Add("UPDATE CargaIII SET Partida = '" & wPartida & "', CantidadPartida = '" & formatonumerico(OrDefault(WTeorico, 0)) & "' WHERE Terminado = '" & wTerminado & "'")
        WSqls.Add("UPDATE CargaV SET Partida = '" & wPartida & "', CantidadPartida = '" & formatonumerico(OrDefault(WTeorico, 0)) & "', ImprePaso = Paso WHERE Terminado = '" & wTerminado & "'")

        Dim WCargaIII As DataRow = GetSingle("SELECT TOP 1 Version, FechaVersion, TipoProceso FROM CargaIII WHERE Terminado = '" & wTerminado & "' Order by Clave", "Surfactan_III")

        Dim WVers, WFechaVersion, WTipoProceso As String

        If Not IsNothing(WCargaIII) Then

            WVers = OrDefault(WCargaIII.Item("Version"), "")
            WFechaVersion = OrDefault(WCargaIII.Item("FechaVersion"), "")
            WTipoProceso = OrDefault(WCargaIII.Item("TipoProceso"), "")

        End If

        Dim WVida As Integer = 0
        Dim WImpreVto = ""

        WVida = OrDefault(WTerm.Item("Vida"), 0)

        If WVida <> 0 Then

            Dim WFechaHoja As String = "01/01/1901"

            If WHoja.Rows.Count > 0 Then WFechaHoja = WHoja.Rows(0).Item("Fecha").ToString

            Dim WMes As Integer = Date.ParseExact(WFechaHoja, "dd/MM/yyyy", Nothing).Month 'Date.Now.Month
            Dim WAnio As Integer = Date.ParseExact(WFechaHoja, "dd/MM/yyyy", Nothing).Year

            For Ciclo = 1 To WVida
                WMes = WMes + 1
                If WMes > 12 Then
                    WAnio = WAnio + 1
                    WMes = 1
                End If
            Next Ciclo

            Dim XMes = Str$(WMes)
            Dim XAno = Str$(WAnio)
            XMes = XMes.Trim().PadLeft(2, "0")
            XAno = XAno.Trim().PadLeft(4, "0")
            WImpreVto = XMes + "/" + XAno

        End If

        If Not RegistroMaestro Then

            Dim ZZMezcla = "S"
            Dim ZZMezclaPartida = 999999
            Dim ZZMezclaPartidaII = ""

            For Each row As DataRow In WHoja.Rows
                With row

                    If Microsoft.VisualBasic.Left(wTerminado, 8) <> Microsoft.VisualBasic.Left(OrDefault(.Item("Terminado"), ""), 8) Then
                        ZZMezcla = "N"
                    Else

                        Dim WLote1 As Integer = OrDefault(.Item("Lote1"), 0)
                        Dim WLote2 As Integer = OrDefault(.Item("Lote2"), 0)
                        Dim WLote3 As Integer = OrDefault(.Item("Lote3"), 0)

                        If WLote1 < ZZMezclaPartida And WLote1 <> 0 Then
                            ZZMezclaPartida = WLote1
                            ZZMezclaPartidaII = OrDefault(.Item("Terminado"), "")
                        End If

                        If WLote2 < ZZMezclaPartida And WLote2 <> 0 Then
                            ZZMezclaPartida = WLote2
                            ZZMezclaPartidaII = OrDefault(.Item("Terminado"), "")
                        End If

                        If WLote3 < ZZMezclaPartida And WLote3 <> 0 Then
                            ZZMezclaPartida = WLote3
                            ZZMezclaPartidaII = OrDefault(.Item("Terminado"), "")
                        End If

                    End If

                End With
            Next

            If ZZMezcla = "S" Then

                If ZZMezclaPartida <> 999999 Then

                    Dim WHoja2 As DataRow = GetSingle("SELECT Top 1 Fecha FROM Hoja WHERE Hoja = '" & ZZMezclaPartida & "' And Producto = '" & ZZMezclaPartidaII & "' Order by Clave", "Surfactan_III")

                    If Not IsNothing(WHoja2) Then

                        Dim WFecha As Date = Date.ParseExact(WHoja2.Item("Fecha"), "dd/MM/yyyy", Nothing)

                        Dim WMes As Integer = WFecha.Month
                        Dim WAnio As Integer = WFecha.Year

                        For Ciclo = 1 To WVida
                            WMes = WMes + 1
                            If WMes > 12 Then
                                WAnio = WAnio + 1
                                WMes = 1
                            End If
                        Next Ciclo

                        Dim XMes = Trim(Str$(WMes))
                        Dim XAno = Trim(Str$(WAnio))
                        XMes = XMes.PadLeft(2, "0")
                        XAno = XAno.PadLeft(4, "0")
                        WImpreVto = XMes + "/" + XAno

                    Else
                        If Not RegistroMaestro Then Throw New System.Exception("No se encontró Hoja '" & ZZMezclaPartida & "', informada como componente de mezcla.")
                    End If

                Else
                    If Not RegistroMaestro Then Throw New System.Exception("Es una Hoja de producción de mezcla y no se informaron las partidas a utilizar, por lo que no se puede imprimir la fecha de reanálisis")
                End If

            End If

            Dim ZZMono = "N"

            Dim WMono As DataRow = GetSingle("SELECT Codigo FROM CodigoMono WHERE Codigo = '" & wTerminado & "'")

            If Not IsNothing(WMono) Then
                ZZMono = "S"
            End If

            Dim WLinea As Integer = OrDefault(WTerm.Item("Linea"), 0)

            If ZZMono = "S" Or WLinea = 20 Or WLinea = 28 Then

                Dim WLoteMP As Integer = 999999
                Dim WArtMp As String = ""

                For Each row As DataRow In WHoja.Rows
                    With row
                        If OrDefault(.Item("Tipo"), "").ToString.ToUpper = "M" Then

                            WLoteMP = OrDefault(.Item("Lote1"), 999999)
                            WArtMp = OrDefault(.Item("Articulo"), "")

                        Else
                            WLoteMP = 999999
                        End If
                    End With
                Next

                If WLoteMP = 0 And Not RegistroMaestro Then Throw New System.Exception("Es una hoja de producción de monoproducto y no se informaron las partidas a utilizar, por lo que no se puede imprimir la fecha de reanálisis")

                If WLoteMP <> 999999 Then

                    For Each emp As String In {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

                        Dim WLaudo As DataRow = GetSingle("SELECT FechaVencimiento, TipoVencimiento FROM Laudo WHERE Laudo = '" & WLoteMP & "' And Articulo = '" & WArtMp & "'", emp)

                        If Not IsNothing(WLaudo) Then

                            Dim WFechaVto As String = OrDefault(WLaudo.Item("FechaVencimiento"), "")
                            WTipoVencimiento = Val(OrDefault(WLaudo.Item("TipoVencimiento"), ""))

                            If WFechaVto = "" Then Continue For

                            Dim WFecha As Date = Date.ParseExact(WFechaVto, "dd/MM/yyyy", Nothing)

                            Dim XMes = WFecha.Month.ToString.Trim
                            Dim XAno = WFecha.Year.ToString.Trim
                            XMes = XMes.PadLeft(2, "0")
                            XAno = XAno.PadLeft(4, "0")
                            WImpreVto = XMes + "/" + XAno

                            Exit For
                        End If

                    Next

                End If

            End If
        End If

        WSqls.Add("UPDATE Terminado SET TipoProceso = '" & WTipoProceso & "' Where Codigo = '" & wTerminado & "'")

        Dim ZSql = ""
        ZSql = ZSql & "UPDATE hoja SET "
        ZSql = ZSql & " FechaReanalisis = " & "'" & WImpreVto & "',"
        ZSql = ZSql & " Impreversion = " & "'" & WVers & "',"
        ZSql = ZSql & " Imprefechaversion = " & "'" & WFechaVersion & "'"
        ZSql = ZSql & " Where hoja = " & "'" & wPartida & "'"

        WSqls.Add(ZSql)

        WSqls.Add("UPDATE Hoja SET Hoja.ImpreArticulo = LEFT(Articulo.Descripcion, 50) FROM Hoja, Articulo WHERE Hoja.Tipo = 'M' And Hoja.Articulo = Articulo.Codigo AND Hoja.Hoja = '" & wPartida & "'")

        ExecuteNonQueries("Surfactan_III", WSqls.ToArray)

    End Sub
End Class
