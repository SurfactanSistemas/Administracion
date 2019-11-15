Imports Laboratorio.Clases

Namespace Entidades
    Public Class ProductoTerminado

        Public Shared Function Info(ByVal Producto As String, ByVal Columnas() As String) As DataRow
            Return GetSingle(String.Format("SELECT {0} FROM Terminado WHERE Codigo = '{1}'", String.Join(",", Columnas), Producto))
        End Function

        Public Shared Function TipoProd(ByVal Producto As String) As String
            Dim WTipoPro = "PT"
            Dim Auxi As String = Mid(Producto, 4, 5)
            Dim WTer As DataRow = Info(Producto, {"Linea"})

            If WTer Is Nothing Then Return ""

            If Not Producto.StartsWith("PT") Then
                Select Case _Left(Producto, 2)
                    Case "DY", "DS"
                        WTipoPro = "CO"
                    Case "QC", "YF"
                        WTipoPro = "FA"
                    Case "YQ", "YH", "YP"
                        WTipoPro = "PT"
                End Select
            Else
                If (Val(Auxi) > 0 And Val(Auxi) < 999) Or (Val(Auxi) > 11000 And Val(Auxi) < 12999) Then
                    WTipoPro = "CO"
                ElseIf Val(Auxi) > 25000 And Val(Auxi) < 25999 Then
                    WTipoPro = "FA"
                ElseIf Val(Auxi) > 2300 And Val(Auxi) < 2399 Then
                    WTipoPro = "BI"
                End If
            End If

            Dim WLinea As Integer = OrDefault(WTer.Item("Linea"), 0)

            If (Auxi >= 25000 And Auxi <= 25999) Or {10, 20, 22, 24, 25, 26, 27, 28, 29, 30}.Contains(WLinea) Then
                WTipoPro = "FA"
            End If

            Return WTipoPro
        End Function

        ''' <summary>
        ''' Devuelve la Fecha de Elaboracion y Vencimiento de un producto según Componentes y Linea.
        ''' </summary>
        Public Shared Function CalcularFechaElabVto(ByVal Producto As String, ByVal Partida As String, Optional ByVal SoloConsulta As Boolean = False) As String()
            Dim WFechaVto As String = ""
            Dim WElaboracion As String = ""

            Dim WTerm As DataRow = Info(Producto, {"Vida", "Linea"})

            If WTerm Is Nothing Then Return {"", WFechaVto}

            Dim WMeses As Integer = OrDefault(WTerm.Item("Vida"), 0)
            Dim WLinea As Integer = OrDefault(WTerm.Item("Linea"), 0)

            Dim WTipoPro As String = TipoProd(Producto)

            Dim WEmpresaHoja As String = HojaProduccion.EmpresaOrigen(Partida)

            Dim WVencimiento, WMes, WAnio, WMesesRevalida, WRevalida, WFechaRevalida, WFechaHoja, WVida As String
            Dim WHoja As DataRow = HojaProduccion.SingleInfo({"Revalida, MesesRevalida, FechaRevalida, Fecha"},
                                                             {"Hoja = '" & Partida & "'"},
                                                             WEmpresaHoja)

            WVencimiento = ""
            WElaboracion = ""

            With WHoja
                WRevalida = OrDefault(.Item("Revalida"), "")
                WMesesRevalida = OrDefault(.Item("MesesRevalida"), "0")
                WFechaRevalida = OrDefault(.Item("FechaRevalida"), "00/00/0000")
                WFechaHoja = OrDefault(.Item("Fecha"), "")
                WElaboracion = WFechaHoja
            End With

            '
            ' Verificamos el 100% de vida útil.
            '
            If Val(WRevalida) <> 0 Then
                WVida = CInt(Val(WMesesRevalida))
                WMes = Mid(WFechaRevalida, 4, 2)
                WAnio = _Right(WFechaRevalida, 4)
            Else
                WVida = CInt(Val(WMeses))
                WMes = Mid(WFechaHoja, 4, 2)
                WAnio = _Right(WFechaHoja, 4)
            End If

            For Ciclo = 1 To Val(WVida)
                WMes = WMes + 1
                If WMes > 12 Then
                    WAnio = WAnio + 1
                    WMes = 1
                End If
            Next

            If Val(WVida) <> 0 Then WVencimiento = "01" & "/" & WMes.ToString.PadLeft(2, "0") & "/" & WAnio.ToString.PadLeft(4, "0")

            '
            ' Determinamos si la Hoja de Producción, se trata de una mezcla y guardamos el Lote mas antiguo para la validación de Vencimiento posterior.
            '
            Dim WMezcla, WMezclaPartida, WMezclaCodTerminado As String

            WMezcla = "S"
            WMezclaPartida = "999999"
            WMezclaCodTerminado = ""

            Dim WHojaComposicion As DataTable = GetAll("SELECT Fecha, Terminado, Producto, Lote1, Lote2, Lote3 FROM Hoja WHERE Hoja = '" & Partida & "' Order by Renglon", WEmpresaHoja)

            For Each row As DataRow In WHojaComposicion.Rows
                With row

                    If _Left(OrDefault(.Item("Terminado"), ""), 8) <> _Left(OrDefault(.Item("Producto"), ""), 8) Then
                        WMezcla = "N"
                    Else
                        Dim WLote1, WLote2, WLote3 As String

                        WLote1 = OrDefault(.Item("Lote1"), "")
                        WLote2 = OrDefault(.Item("Lote2"), "")
                        WLote3 = OrDefault(.Item("Lote3"), "")

                        If Val(WLote1) < Val(WMezclaPartida) And Val(WLote1) <> 0 Then

                            WMezclaPartida = WLote1
                            WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                        ElseIf Val(WLote2) < Val(WMezclaPartida) And Val(WLote2) <> 0 Then

                            WMezclaPartida = WLote2
                            WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                        ElseIf Val(WLote3) < Val(WMezclaPartida) And Val(WLote3) <> 0 Then

                            WMezclaPartida = WLote3
                            WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                        End If

                    End If

                End With
            Next

            '
            ' Calculamos la Fecha de Vencimiento en los casos de que se trate de un Mono Componente o una Mezcla.
            '
            Dim WFechaActual = Date.Now.ToString("dd/MM/yyyy")
            Dim WFechaActualOrd = ordenaFecha(WFechaActual)

            If WTipoPro = "FA" Then
                If WMezcla = "S" And WEmpresaHoja = "Surfactan_III" Then

                    If Val(WMezclaPartida) = 999999 Then
                        MsgBox("Es una Hoja de produccion de mezcla y no se informaron las partidas a utilizar")
                        Return {"", ""}
                    End If

                    '
                    ' Verifico la fecha de vencimiento de la hoja mas antigua.
                    '
                    Dim WHojaMezcla As DataRow = GetSingle("SELECT Fecha, Revalida, MesesRevalida, FechaRevalida FROM Hoja WHERE Hoja = '" & WMezclaPartida & "' And Producto = '" & WMezclaCodTerminado & "' And Renglon = 1", WEmpresaHoja)

                    If WHojaMezcla IsNot Nothing Then

                        With WHojaMezcla

                            Dim WFechaAuxi As String = OrDefault(.Item("Fecha"), "00/00/0000")
                            WElaboracion = WFechaAuxi

                            Dim WMesMezcla As Integer = Val(Mid(WFechaAuxi, 4, 2))
                            Dim WAnioMezcla As Integer = Val(_Left(WFechaAuxi, 4))
                            Dim WVidaMezcla As Integer = WVida

                            Dim WRevalidaMezcla As Integer = OrDefault(.Item("Revalida"), 0)
                            Dim WMesesRevalidaMezcla As Integer = OrDefault(.Item("MesesRevalida"), 0)
                            Dim WFechaRevalidaMezcla As String = OrDefault(.Item("FechaRevalida"), "00/00/0000")

                            If WRevalidaMezcla <> 0 Then
                                WMesMezcla = Mid(WFechaRevalidaMezcla, 4, 2)
                                WAnioMezcla = _Left(WFechaRevalidaMezcla, 4)
                                WVidaMezcla = WMesesRevalidaMezcla
                            End If

                            For Ciclo = 1 To WVidaMezcla
                                WMesMezcla += 1
                                If WMesMezcla > 12 Then
                                    WAnioMezcla += 1
                                    WMesMezcla = 1
                                End If
                            Next Ciclo

                            If Val(WVidaMezcla) <> 0 Then WVencimiento = "01" & "/" & WMesMezcla.ToString.PadLeft(2, "0") & "/" & WAnioMezcla.ToString.PadLeft(4, "0")

                        End With
                    End If

                    '
                    ' Verificamos si se trata de un Mono Producto.
                    '
                    Dim WBuscaMono As DataRow = GetSingle("SELECT Codigo FROM CodigoMono WHERE Codigo = '" & Producto & "'", "SurfactanSa")

                    If WBuscaMono IsNot Nothing Or WLinea = 20 Or WLinea = 28 Then

                        Dim WDatosMono() As String = _CalculaMonoOtro(Partida, WEmpresaHoja)

                        If WDatosMono(0) = "-1" And WDatosMono(1) = "-1" Then Exit Function

                        If Trim(WDatosMono(1)) <> "" Then
                            WVencimiento = WDatosMono(1)
                        End If

                        If Trim(WDatosMono(0)) <> "" Then
                            WElaboracion = WDatosMono(0)
                        End If

                        If WVencimiento <> "" Then
                            If Val(ordenaFecha(WVencimiento)) < Val(WFechaActualOrd) Then
                                If Not SoloConsulta Then
                                    MsgBox("La Partida se encuentra vencida " + Chr(13) + _
                        "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                                    Exit Function
                                End If
                            End If
                        End If

                    End If
                Else
                    Dim WDatosMono() As String = _CalculaMonoOtro(Partida, WEmpresaHoja)

                    If WDatosMono(0) = "-1" And WDatosMono(1) = "-1" Then Exit Function

                    If Trim(WDatosMono(1)) <> "" Then
                        WVencimiento = WDatosMono(1)
                    End If

                    If Trim(WDatosMono(0)) <> "" Then
                        WElaboracion = WDatosMono(0)
                    End If

                    If WVencimiento <> "" Then
                        If Val(ordenaFecha(WVencimiento)) < Val(WFechaActualOrd) Then
                            If Not SoloConsulta Then
                                MsgBox("La Partida se encuentra vencida " + Chr(13) + _
                    "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Else

                Dim WDatosMono() As String = _CalculaMonoOtro(Partida, WEmpresaHoja)

                If WDatosMono(0) = "-1" And WDatosMono(1) = "-1" Then Exit Function

                If Trim(WDatosMono(0)) <> "" Then
                    WElaboracion = WDatosMono(0)
                End If

                If Trim(WDatosMono(1)) <> "" Then
                    WVencimiento = WDatosMono(1)

                    If WVencimiento <> "" Then
                        If Val(ordenaFecha(WVencimiento)) < Val(WFechaActualOrd) Then
                            If Not SoloConsulta Then
                                MsgBox("La Partida se encuentra vencida " + Chr(13) + _
                                       "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                                Exit Function
                            End If
                        End If
                    End If

                End If
            End If
            
            Return {WElaboracion, WVencimiento}
        End Function

        ''' <summary>
        ''' Devuelve las Fechas de Elaboración y Vencimiento de un mono componente, en un Array de dos items. (0 - Elaboración   1 - Vencimiento  2 - Tipo Vencimiento)
        ''' Si hubo un problema, se devuelven en ambos items '-1'.
        ''' </summary>
        Public Shared Function _CalculaMonoOtro(ByVal Hoja As String, ByVal EmpresaHoja As String) As String()
            Dim WDatos(2) As String
            WDatos(0) = "-1"
            WDatos(1) = "-1"
            WDatos(2) = "0"

            Dim WRenglon = 0
            Dim WLote, WLote1, WLote2, WLote3, WTipo, WArticulo, WProducto As String

            Dim WFechaVtoI, WFechaVtoII, WFechaVtoIII, WFechaVtoIOrd, WFechaVtoIIOrd, WFechaVtoIIIOrd

            WFechaVtoI = "99/99/9999"
            WFechaVtoII = "99/99/9999"
            WFechaVtoIII = "99/99/9999"

            Dim WHoja As DataTable = GetAll("SELECT Lote1, Lote2, Lote3, Tipo, Articulo, Producto FROM Hoja WHERE Hoja = '" & Hoja & "'", EmpresaHoja)

            For Each row As DataRow In WHoja.Rows
                With row
                    WRenglon += 1
                    WLote = OrDefault(.Item("Lote1"), "0")
                    WLote1 = OrDefault(.Item("Lote1"), "0")
                    WLote2 = OrDefault(.Item("Lote2"), "0")
                    WLote3 = OrDefault(.Item("Lote3"), "0")

                    If Val(WLote2) < Val(WLote) And Val(WLote2) <> 0 Then WLote = WLote2
                    If Val(WLote3) < Val(WLote) And Val(WLote3) <> 0 Then WLote = WLote3

                    WTipo = OrDefault(.Item("Tipo"), "")
                    WArticulo = OrDefault(.Item("Articulo"), "")
                    WProducto = OrDefault(.Item("Producto"), "")
                End With
            Next

            Dim WTer As DataRow = GetSingle("SELECT Linea FROM Terminado WHERE Codigo  = '" & WProducto & "'")

            If WTer Is Nothing Then
                MsgBox("No se encontró el Producto Relacionado a este Mono Componente.")
                Return WDatos
            End If

            WDatos(0) = "-1"
            WDatos(1) = "-1"
            WDatos(2) = "0"

            Dim WLinea As Integer = OrDefault(WTer.Item("Linea"), 0)

            Dim WLaudo As DataRow = Nothing

            For Each empresa As String In Conexion.Empresas

                If Val(WLote1) <> 0 Then
                    WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote1 & "' And Articulo = '" & WArticulo & "'", empresa)
                    If WLaudo IsNot Nothing Then WFechaVtoI = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
                End If

                If Val(WLote2) <> 0 Then
                    WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote2 & "' And Articulo = '" & WArticulo & "'", empresa)
                    If WLaudo IsNot Nothing Then WFechaVtoII = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
                End If

                If Val(WLote3) <> 0 Then
                    WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote3 & "' And Articulo = '" & WArticulo & "'", empresa)
                    If WLaudo IsNot Nothing Then WFechaVtoIII = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
                End If

            Next

            WFechaVtoIOrd = ordenaFecha(WFechaVtoI)
            WFechaVtoIIOrd = ordenaFecha(WFechaVtoII)
            WFechaVtoIIIOrd = ordenaFecha(WFechaVtoIII)

            Dim Auxi As String = WFechaVtoIOrd
            WLote = WLote1

            If Val(WFechaVtoIIOrd) < Val(Auxi) Then
                Auxi = WFechaVtoIIOrd
                WLote = WLote2
            ElseIf Val(WFechaVtoIIIOrd) < Val(Auxi) Then
                Auxi = WFechaVtoIIIOrd
                WLote = WLote3
            End If

            '
            ' Solo si es Mono Componente y de una Materia Prima, prosigo calculando la Fecha de Vencimiento.
            '
            If WRenglon = 1 And UCase(WTipo) = "M" Then

                '
                ' Verifico que se hayan cargado algun lote de MP. Si no, se detiene la impresión de las mismas.
                ' 
                If Val(WLote) = 0 Then

                    If Val(Hoja) = 0 Then
                        MsgBox("Se debe informar lote de MP", MsgBoxStyle.Exclamation)

                        WDatos(0) = "-1"
                        WDatos(1) = "-1"
                        Return WDatos
                    End If
                End If

                'WLote = Hoja

            End If


            Dim WFechaVencimiento, WFechaElaboracion As String

            WFechaVencimiento = ""
            WFechaElaboracion = ""

            For Each emp As String In Conexion.Empresas
                WLaudo = GetSingle("SELECT TipoVencimiento, FechaVencimiento, TipoVencimiento, FechaElaboracion, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "'and Articulo = '" & WArticulo & "'", emp)

                If WLaudo IsNot Nothing Then
                    With WLaudo

                        WFechaVencimiento = OrDefault(.Item("FechaVencimiento"), "")
                        WDatos(2) = OrDefault(.Item("TipoVencimiento"), "0")

                        If WLinea <> 20 And WLinea <> 28 Then WFechaElaboracion = OrDefault(.Item("FechaElaboracion"), "")

                        Dim WPartiOri = OrDefault(.Item("PartiOri"), "")

                        If Trim(WPartiOri) = "" Then
                            If MsgBox("El Lote Original del Laudo no se encuentra cargado. ¿Desea continuar con la impresión?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                                WDatos(0) = "-1"
                                WDatos(1) = "-1"
                                Return WDatos
                            End If
                        End If

                        Exit For

                    End With
                End If
            Next

            If Val(WFechaElaboracion.Replace("/", "")) <> 0 Then

                If _ValidarFecha(WFechaElaboracion) Then
                    WDatos(0) = WFechaElaboracion
                End If
            Else
                WDatos(0) = ""
            End If

            If Val(WFechaVencimiento.Replace("/", "")) <> 0 Then

                If _ValidarFecha(WFechaVencimiento) Then
                    WDatos(1) = WFechaVencimiento
                End If
            Else
                WDatos(1) = ""
            End If

            Return WDatos
        End Function

        ''' <summary>
        ''' Devuelve si el Producto es o no monocomponente.
        ''' </summary>
        Public Shared Function EsMono(ByVal Codigo As String) As Boolean
            Return GetSingle("SELECT Codigo FROM codigomono WHERE Codigo = '" & Codigo & "'", "SurfactanSa") IsNot Nothing
        End Function

    End Class
End Namespace
