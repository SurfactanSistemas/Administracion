Imports System.IO
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine

Public Class ImpreProcesos

    Private Sub ImpreRegistroProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Environment.GetCommandLineArgs.Length > 1 Then

                Dim WProceso As Integer = Environment.GetCommandLineArgs(1)

                Select Case WProceso
                    Case 1 ' REGISTRO DE PRODUCCIÓN.

                        Dim WTerminado As String = Environment.GetCommandLineArgs(2)
                        Dim WPartida As Integer = Environment.GetCommandLineArgs(3)

                        _GenerarRegistroProduccion(WTerminado, WPartida)

                    Case 2 ' CERTIFICADO DE CALIDAD.

                        Dim WTipoReporte As Integer = Environment.GetCommandLineArgs(2)
                        Dim WPartida As Integer = Environment.GetCommandLineArgs(3)
                        Dim WTipoSalida As Integer = Environment.GetCommandLineArgs(4)
                        
                        _GenerarCertificadoAnalisisFarma(WTipoReporte, WPartida, WTipoSalida)

                    Case 3 ' Resultados de Calidad (PrueterFarma -> Registro de Producción)

                        Dim WPartida As Integer = Environment.GetCommandLineArgs(2)
                        Dim WTipoSalida As Integer = 0

                        If Environment.GetCommandLineArgs.Length > 2 Then
                            WTipoSalida = Environment.GetCommandLineArgs(3)
                        End If

                        _GenerarReporteResultadosCalidad(WPartida, WTipoSalida)

                    Case Else
                        Close()
                End Select

            End If

            'Dim WTipoReporte2 As Integer = 1
            'Dim WPartida2 As Integer = 308719
            'Dim WCliente2 As String = ""
            'Dim WCantidad2 As String = "100.00"
            'Dim WTipoSalida2 As Integer = 3

            '_GenerarCertificadoAnalisisFarma(WTipoReporte2, WPartida2, WCliente2, WCantidad2, WTipoSalida2)

            'Dim WTerminado2 As String = "PT-25015-110"
            'Dim WPartida2 As Integer = "308933"

            '_GenerarRegistroProduccion(WTerminado2, WPartida2)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally

            Close()

        End Try

    End Sub

    Private Sub _GenerarReporteResultadosCalidad(ByVal wPartida As Integer, ByVal wTipoSalida As Integer)

        With New VistaPrevia
            .Reporte = New imprecalidadresultado
            .Formula = "{Prueterfarma.Partida} = " & wPartida & " And {Hoja.Hoja} = {Prueterfarma.Partida} And {Hoja.Renglon} = 1"

            Select Case wTipoSalida
                Case 0, 1
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    .Exportar("Resultados de Calidad " & wPartida & " " & Date.Now.ToString("dd-MM-yyyy"), CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select

        End With

    End Sub

    Private Sub _GenerarCertificadoAnalisisFarma(ByVal WTipoReporte As Integer, ByVal wPartida As Integer, ByVal wTipoSalida As Integer)

        Dim frm As ReportDocument
        Dim WFormulas() As String
        Dim WNombreArchivoFormulas As String = "C:\ImpreCertificados\" & wPartida
        '
        ' Determinamos el Reporte a imprimir y los datos de las formulas a pasar como parámetro.
        '

        Select Case wTipoReporte
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
                Close()
        End Select

        If Not File.Exists(WNombreArchivoFormulas) Then
            MsgBox("No se encuentra archivo " & WNombreArchivoFormulas)
            Close()
        End If

        WFormulas = File.ReadAllLines(WNombreArchivoFormulas, UTF7Encoding.UTF7)

        For Each wFormula As String In WFormulas
            Dim WDato() As String = wFormula.Split("=")

            If WDato.Length < 2 Then Continue For

            frm.DataDefinition.FormulaFields(WDato(0)).Text = WDato(1)

        Next

        With New VistaPrevia
            .Reporte = frm
            .Formula = "{Certificado.Partida} = " & wPartida & ""
            
            Select Case wTipoSalida
                Case 1
                    .Imprimir()
                Case 2
                    .Mostrar()
                Case 3
                    .Exportar("Certificado Calidad " & wPartida & " " & Date.Now.ToString("dd-MM-yyyy"), CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select


        End With

    End Sub

    Private Sub _GenerarRegistroProduccion(ByVal WTerminado As String, ByVal WPartida As Integer)

        _ProcesarInformacionParaRegistroProduccion(WTerminado, WPartida)

        Dim WEscrito = 0

        Dim WTer As DataRow = GetSingle("SELECT Escrito, MarcaLabora FROM Terminado WHERE Codigo = '" & WTerminado & "'")

        If WTer Is Nothing Then Close()

        WEscrito = OrDefault(WTer.Item("Escrito"), 0)
        Dim WMarcaLabora = OrDefault(WTer.Item("MarcaLabora"), 0)

        Dim WImprePlanilla = 0
        Dim WImprePlanillaII = 0
        Dim WImprePlanillaIII = 0

        Dim WCargaIII As DataRow = GetSingle("SELECT ImprimePlanilla, ImprimePlanillaII, ImprimePlanillaIII FROM CargaIII WHERE Terminado = '" & WTerminado & "'", "Surfactan_III")

        If WCargaIII Is Nothing Then Close()

        WImprePlanilla = OrDefault(WCargaIII.Item("ImprimePlanilla"), 0)
        WImprePlanillaII = OrDefault(WCargaIII.Item("ImprimePlanillaII"), 0)
        WImprePlanillaIII = OrDefault(WCargaIII.Item("ImprimePlanillaIII"), 0)

        Dim WMostrarHumedad As Integer = 0

        Dim WHumedad As DataRow = GetSingle("SELECT Humedad FROM CargaIII WHERE Terminado = '" & WTerminado & "' AND Humedad = 1 And Renglon = 1")

        If Not IsNothing(WHumedad) Then WMostrarHumedad = 1

        Dim rpt As New ImpreFarmaII

        rpt.SetParameterValue("MostrarHumedad", WMostrarHumedad)
        rpt.SetParameterValue("ImprimePlanillaII", WImprePlanillaII.ToString)
        rpt.SetParameterValue("MarcaLabora", WMarcaLabora)

        Dim frm As New VistaPrevia

        With frm
            .Reporte = rpt
            .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = '" & WTerminado & "' And {Hoja.Renglon} = 1" ' And {CargaIII.Partida} = {Hoja.Hoja}"
            '.Mostrar()
            .Imprimir()
        End With

        '
        ' Anexos
        '

        If WImprePlanilla <> 0 Or WImprePlanillaIII <> 0 Then
            Dim rptAnexos As New ImpreAnexos

            rptAnexos.SetParameterValue("ImprePlanilla", WImprePlanilla)
            rptAnexos.SetParameterValue("ImprePlanillaIII", WImprePlanillaIII)

            With New VistaPrevia
                .Reporte = rptAnexos
                .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = '" & WTerminado & "' And {Hoja.Renglon} = 1" ' And {CargaIII.Partida} = {Hoja.Hoja}"
                '.Mostrar()
                .Imprimir()
            End With

        End If

        If Val(WTerminado.Substring(3, 5)) = 3000 Then

            With New VistaPrevia
                .Reporte = New impremermadescartesterceros
                .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = {Terminado.Codigo} " '= '" & WTerminado & "'" ' And {CargaIII.Partida} = {Hoja.Hoja}"
                '.Mostrar()
                .Imprimir()
            End With

        End If

    End Sub

    Private Sub _ProcesarInformacionParaRegistroProduccion(ByVal wTerminado As String, ByVal wPartida As Integer)

        '
        ' Buscamos informacion del Terminado y Hoja.
        '
        Dim WTerm As DataRow = GetSingle("SELECT Descripcion, Linea, Vida FROM Terminado WHERE Codigo = '" & wTerminado & "'")
        Dim WHoja As DataTable = GetAll("SELECT * FROM Hoja WHERE Hoja = '" & wPartida & "' Order by Renglon", "Surfactan_III")

        If IsNothing(WTerm) Then Throw New Exception("No existe Producto Terminado con Código '" & wTerminado & "'")
        If WHoja.Rows.Count = 0 Then Throw New Exception("No existe Hoja '" & wTerminado & "'")

        Dim WSqls As New List(Of String)

        WSqls.Add("DELETE FROM ImpreCarga")
        WSqls.Add("DELETE FROM ImpreCargaI")

        Dim WCargaI As DataTable = GetAll("SELECT Codigo = 1, c1.Cantidad, c1.Metodo, c1.Equipo, e.Descripcion, e.DescripcionII, e.Poe, e.Identificacion, e.PoeLimpieza FROM CargaI c1 INNER JOIN Equipo e ON c1.Equipo = e.Codigo WHERE c1.Terminado = '" & wTerminado & "' Order by c1.Clave", "Surfactan_III")
        Dim WCargaII As DataTable = GetAll("SELECT Codigo = 2, ma.Descripcion FROM CargaII c2 INNER JOIN MaterialAuxiliar ma ON c2.MaterialAuxiliar = ma.Codigo WHERE c2.Terminado = '" & wTerminado & "' Order by c2.Clave", "Surfactan_III")

        For Each row As DataRow In WCargaI.Rows
            With row
                Dim WTipo As Integer = OrDefault(.Item("Codigo"), 0)
                Dim WDescripcion As String = OrDefault(.Item("Descripcion"), "")
                Dim WDescripcionII As String = OrDefault(.Item("DescripcionII"), "")
                Dim WPoe As String = OrDefault(.Item("Poe"), "")
                Dim WIdentificacion As String = OrDefault(.Item("Identificacion"), "")
                Dim WPoeLimpieza As String = OrDefault(.Item("PoeLimpieza"), "")
                Dim WTeorico As String = formatonumerico(OrDefault(WHoja.Rows(0).Item("Teorico"), 0))
                Dim WDescTerminado As String = OrDefault(WTerm.Item("Descripcion"), "").ToString.Trim

                If WIdentificacion.Trim <> "" Then WDescripcion = WIdentificacion.Trim & " - " & WDescripcion

                WSqls.Add(String.Format("INSERT INTO ImpreCarga (Partida, Descripcion, Terminado, Cantidad, Tipo, DescripcionI, DescripcionII) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                        wPartida, WDescTerminado, wTerminado, WTeorico, WTipo, WDescripcion, WDescripcionII))

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
                Dim WTeorico As String = formatonumerico(OrDefault(WHoja.Rows(0).Item("Teorico"), 0))
                Dim WDescTerminado As String = OrDefault(WTerm.Item("Descripcion"), "").ToString.Trim

                If WIdentificacion.Trim <> "" Then WDescripcion = WIdentificacion.Trim & " - " & WDescripcion

                WSqls.Add(String.Format("INSERT INTO ImpreCarga (Partida, Descripcion, Terminado, Cantidad, Tipo, DescripcionI, DescripcionII) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                        wPartida, WDescTerminado, wTerminado, WTeorico, WTipo, WDescripcion, WDescripcionII))

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
                Dim WTeorico As String = formatonumerico(OrDefault(WHoja.Rows(0).Item("Teorico"), 0))
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

        WSqls.Add("UPDATE CargaIII SET Partida = '" & wPartida & "', CantidadPartida = '" & formatonumerico(OrDefault(WHoja.Rows(0).Item("Teorico"), 0)) & "' WHERE Terminado = '" & wTerminado & "'")
        WSqls.Add("UPDATE CargaV SET Partida = '" & wPartida & "', CantidadPartida = '" & formatonumerico(OrDefault(WHoja.Rows(0).Item("Teorico"), 0)) & "', ImprePaso = Paso WHERE Terminado = '" & wTerminado & "'")

        Dim WCargaIII As DataRow = GetSingle("SELECT TOP 1 * FROM CargaIII WHERE Terminado = '" & wTerminado & "' Order by Clave", "Surfactan_III")

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

            Dim WMes As Integer = Date.ParseExact(WHoja.Rows(0).Item("Fecha").ToString, "dd/MM/yyyy", Nothing).Month 'Date.Now.Month
            Dim WAnio As Integer = Date.ParseExact(WHoja.Rows(0).Item("Fecha").ToString, "dd/MM/yyyy", Nothing).Year

            For Ciclo = 1 To WVida
                WMes = WMes + 1
                If WMes > 12 Then
                    WAnio = WAnio + 1
                    WMes = 1
                End If
            Next Ciclo

            Dim XMes = Str$(WMes)
            Dim XAno = Str$(WAnio)
            XMes = XMes.PadLeft(2, "0")
            XAno = XAno.PadLeft(4, "0")
            WImpreVto = XMes + "/" + XAno

        End If

        Dim WImpreFecha = WHoja.Rows(0).Item("Fecha")

        Dim ZZMezcla = "S"
        Dim ZZMezclaPartida = 999999
        Dim ZZMezclaPartidaII = ""

        For Each row As DataRow In WHoja.Rows
            With row

                If wTerminado <> OrDefault(.Item("Terminado"), "") Then
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

                    Dim XMes = Str$(WMes)
                    Dim XAno = Str$(WAnio)
                    XMes = XMes.PadLeft(2, "0")
                    XAno = XAno.PadLeft(4, "0")
                    WImpreVto = XMes + "/" + XAno

                Else
                    Throw New Exception("No se encontró Hoja '" & ZZMezclaPartida & "', informada como componente de mezcla.")
                End If

            Else
                Throw New Exception("Es una Hoja de producción de mezcla y no se informaron las partidas a utilizar, por lo que no se puede imprimir la fecha de reanálisis")
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

            If WLoteMP = 0 Then Throw New Exception("Es una hoja de producción de monoproducto y no se informaron las partidas a utilizar, por lo que no se puede imprimir la fecha de reanálisis")

            If WLoteMP <> 999999 Then

                For Each emp As String In {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

                    Dim WLaudo As DataRow = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLoteMP & "' And Articulo = '" & WArtMp & "'", emp)

                    If Not IsNothing(WLaudo) Then

                        Dim WFechaVto As String = OrDefault(WLaudo.Item("FechaVencimiento"), "")

                        If WFechaVto = "" Then Continue For

                        Dim WFecha As Date = Date.ParseExact(WFechaVto, "dd/MM/yyyy", Nothing)

                        Dim XMes = WFecha.Month.ToString
                        Dim XAno = WFecha.Year.ToString
                        XMes = XMes.PadLeft(2, "0")
                        XAno = XAno.PadLeft(4, "0")
                        WImpreVto = XMes + "/" + XAno

                        Exit For
                    End If

                Next

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
