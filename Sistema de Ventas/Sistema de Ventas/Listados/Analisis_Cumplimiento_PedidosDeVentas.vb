Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class Analisis_Cumplimiento_PedidosDeVentas

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("El campo de fecha Desde es invalido, verificar")
                    txt_DesdeFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""

        End Select

    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                   MsgBox("El campo de fecha Hasta es invalido, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select

    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If ValidaFecha(txt_DesdeFecha.Text) <> "S" Then
            If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                MsgBox("Verificar los valores de fechas, ambos son invalidos. Corregir")
                Exit Sub
            End If
            MsgBox("Verificar la fecha Desde, es un valor invalido")
            txt_DesdeFecha.Focus()
            txt_DesdeFecha.SelectAll()
            Exit Sub
        End If

        If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
            MsgBox("Verificar la fecha Hasta, es un valor invalido")
            txt_HastaFecha.Focus()
            txt_HastaFecha.SelectAll()
            Exit Sub
        End If


        Dim TablaVector As New DataTable
        With TablaVector.Columns
            .Add("Pedido")
            .Add("Fecha")
            .Add("FechaEntrega")
            .Add("Terminado")
            .Add("Clave")
            .Add("FechaOrd")
            .Add("OrdFecEntrega")
            .Add("Cliente")
            .Add("TipoPed")
            .Add("FechaActualizacion")
            .Add("OrdFechaActualizacion")
        End With




        Dim ListaFeriados As New List(Of String)


        Dim TotalFeriado As Integer = 0

        Dim SQLCnslt As String = "SELECT Fecha FROM Feriado ORDER BY Codigo"
        Dim TablaFeriado As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaFeriado.Rows.Count > 0 Then
            For Each RowFeri As DataRow In TablaFeriado.Rows
                ListaFeriados.Add(RowFeri.Item("Fecha"))
                TotalFeriado += 1
            Next
        End If


        Dim WDesde As String = Microsoft.VisualBasic.Right$(txt_DesdeFecha.Text, 4) & Mid$(txt_DesdeFecha.Text, 4, 2) & Microsoft.VisualBasic.Left$(txt_DesdeFecha.Text, 2)
        Dim WHasta As String = Microsoft.VisualBasic.Right$(txt_HastaFecha.Text, 4) & Mid$(txt_HastaFecha.Text, 4, 2) & Microsoft.VisualBasic.Left$(txt_HastaFecha.Text, 2)

        Dim WTitulo As String = "" & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text
        If cbx_Tipo.SelectedIndex <> 4 And cbx_Tipo.SelectedIndex <> 5 Then
            If cbx_FechaPedido.SelectedIndex = 0 Then
                WTitulo = WTitulo + " (F.Pactada)"
            Else
                WTitulo = WTitulo + " (F.Original)"
            End If
        End If
        If cbx_FechaEntrega.SelectedIndex = 0 Then
            WTitulo = WTitulo + "-(F.Factura)"
        Else
            WTitulo = WTitulo + "-(F.Entrega)"
        End If


        SQLCnslt = "UPDATE Pedido SET " _
                    & " Suma1 = 0," _
                    & " Suma2 = 0," _
                    & " Dias = 0," _
                    & " TipoFecha = '" & cbx_FechaEntrega.SelectedIndex & "'," _
                    & " Titulo = '" & WTitulo & "'"
        ExecuteNonQueries({SQLCnslt}, Operador.Base)
      

        Dim Renglon As Integer = 0

        SQLCnslt = "Select Pedido, Fecha, FechaOrd, Terminado, Clave, FecEntrega, OrdFecEntrega, Cliente, " _
                    & "FechaInicial, OrdFechaInicial, TipoPed, FechaActualizacion, OrdFechaActualizacion" _
                    & " FROM Pedido" _
                    & " WHERE FechaOrd >= '" & WDesde & "'" _
                    & " AND FechaOrd <= '" & WHasta & "'" _
                    & " AND TipoPed <> 5"
        Dim TablaPedido As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaPedido.Rows.Count > 0 Then

            For Each RowPed As DataRow In TablaPedido.Rows

                Dim XFechaInicial As String = ""
                Dim XOrdFechaInicial As String = ""

                TablaVector.Rows.Add()

                TablaVector.Rows(Renglon).Item("Pedido") = RowPed.Item("Pedido")
                TablaVector.Rows(Renglon).Item("Fecha") = RowPed.Item("Fecha")
                TablaVector.Rows(Renglon).Item("Terminado") = RowPed.Item("Terminado")
                TablaVector.Rows(Renglon).Item("Clave") = RowPed.Item("Clave")
                TablaVector.Rows(Renglon).Item("FechaOrd") = RowPed.Item("FechaOrd")
                If cbx_FechaPedido.SelectedIndex = 0 Then
                    TablaVector.Rows(Renglon).Item("FechaEntrega") = RowPed.Item("FecEntrega")
                    TablaVector.Rows(Renglon).Item("OrdFecEntrega") = RowPed.Item("OrdFecEntrega")
                Else
                    XFechaInicial = IIf(IsDBNull(RowPed.Item("FechaInicial")), "", RowPed.Item("FechaInicial"))
                    XOrdFechaInicial = IIf(IsDBNull(RowPed.Item("OrdFechaInicial")), "", RowPed.Item("OrdFechaInicial"))
                    If XFechaInicial <> "" Then
                        TablaVector.Rows(Renglon).Item("FechaEntrega") = RowPed.Item("FechaInicial")
                        TablaVector.Rows(Renglon).Item("OrdFecEntrega") = RowPed.Item("OrdFechaInicial")
                    Else
                        TablaVector.Rows(Renglon).Item("FechaEntrega") = RowPed.Item("FecEntrega")
                        TablaVector.Rows(Renglon).Item("OrdFecEntrega") = RowPed.Item("OrdFecEntrega")
                    End If
                End If
                TablaVector.Rows(Renglon).Item("Cliente") = RowPed.Item("Cliente")
                TablaVector.Rows(Renglon).Item("TipoPed") = RowPed.Item("Tipoped")
                Dim XFechaActualizacion As String = IIf(IsDBNull(RowPed.Item("FechaActualizacion")), "", RowPed.Item("FechaActualizacion"))
                Dim XOrdFechaActualizacion As String = IIf(IsDBNull(RowPed.Item("OrdFechaActualizacion")), "", RowPed.Item("OrdFechaActualizacion"))
                TablaVector.Rows(Renglon).Item("FechaActualizacion") = XFechaActualizacion
                TablaVector.Rows(Renglon).Item("OrdFechaActualizacion") = XOrdFechaActualizacion

                Renglon += 1
                
            Next

          
        End If

        For Each RowVec As DataRow In TablaVector.Rows
            
            Dim WPedido As String = RowVec.Item("Pedido")
            Dim WFecha As String = RowVec.Item("Fecha")
            Dim WFechaEntrega As String = RowVec.Item("FechaEntrega")
            Dim WTerminado As String = RowVec.Item("Terminado")
            Dim WClave As String = RowVec.Item("Clave")
            Dim WFechaord As String = RowVec.Item("FechaOrd")
            Dim WOrdFechaEntrega As String = RowVec.Item("OrdFecEntrega")
            Dim WCliente As String = RowVec.Item("Cliente")
            Dim WTipoPedido As String = RowVec.Item("TipoPed")
            Dim WFechaActualizacion As String = RowVec.Item("FechaActualizacion")
            Dim WOrdFechaActualizacion As String = RowVec.Item("OrdFechaActualizacion")


            Dim Entra As String
            Dim FechaFactu As String
            Dim FechaFactuOrd As String


            If Val(WTipoPedido) = 4 Then

               

                If WFechaActualizacion <> "" Then
                    Entra = "S"
                    FechaFactu = WFechaActualizacion
                    FechaFactuOrd = WOrdFechaActualizacion
                Else
                    Entra = "N"
                    FechaFactu = ""
                    FechaFactuOrd = ""
                End If

            Else

                Entra = "N"
                FechaFactu = ""
                FechaFactuOrd = ""
                Dim ZZRemito As String = ""

                SQLCnslt = "SELECT Fecha, OrdFecha, Remito " _
                            & " FROM Estadistica" _
                            & " WHERE Pedido = '" & WPedido & "'" _
                            & " AND Articulo = '" & WTerminado & "'" _
                            & " ORDER BY OrdFecha"

                Dim TablaEstad As DataTable = GetAll(SQLCnslt, Operador.Base)

                If TablaEstad.Rows.Count > 0 Then
                    For Each RowEstad As DataRow In TablaEstad.Rows
                        Entra = "S"
                        FechaFactu = RowEstad.Item("Fecha")
                        FechaFactuOrd = RowEstad.Item("OrdFecha")
                        ZZRemito = RowEstad.Item("Remito")
                    Next
                  End If

                If cbx_FechaEntrega.SelectedIndex = 1 Then
                    If ZZRemito <> "" Then
                        SQLCnslt = "SELECT Fecha, OrdFecha" _
                                    & " FROM HojaRuta" _
                                    & " WHERE Pedido = '" & WPedido & "'" _
                                    & " AND Remito = '" & Trim(ZZRemito) & "'"
                        Dim RowHojaR As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If RowHojaR IsNot Nothing Then
                            FechaFactu = RowHojaR.Item("Fecha")
                            FechaFactuOrd = RowHojaR.Item("OrdFecha")

                        Else
                            SQLCnslt = "Select Fecha, OrdFecha" _
                                        & " FROM HojaRuta" _
                                        & " Where Pedido = '" & WPedido & "'"
                            Dim RowHojaRII As DataRow = GetSingle(SQLCnslt, Operador.Base)
                            If RowHojaRII IsNot Nothing Then
                                FechaFactu = RowHojaRII.Item("Fecha")
                                FechaFactuOrd = RowHojaRII.Item("OrdFecha")
                            End If
                        End If
                    End If
                End If

            End If

            If Entra = "S" Then

                Dim WLinea As String = ""

                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "PT" Or Microsoft.VisualBasic.Left$(WTerminado, 2) = "PE" Then

                    SQLCnslt = "SELECT Linea" _
                                & " FROM Terminado" _
                                & " WHERE Codigo = '" & WTerminado & "'"
                    Dim RowTer As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowTer IsNot Nothing Then
                        WLinea = RowTer.Item("Linea")
                    End If

                Else

                    If Microsoft.VisualBasic.Left$(WTerminado, 2) = "DY" Then
                        WLinea = "16"
                    Else
                        If Microsoft.VisualBasic.Left$(WTerminado, 2) = "DS" Then
                            WLinea = "16"
                        Else
                            If Microsoft.VisualBasic.Left$(WTerminado, 2) = "DQ" Then
                                WLinea = "22"
                            Else
                                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "DW" Then
                                    WLinea = "17"
                                Else
                                    WLinea = "5"
                                End If
                            End If
                        End If
                    End If

                End If

                Dim WDias As Integer = 0
                Dim WSuma2 As String = "0"

                Dim WFechaDesdeOrd As String = WOrdFechaEntrega
                Dim WFechaDesde As String = WFechaEntrega
                If cbx_Tipo.SelectedIndex = 4 Then
                    WFechaDesdeOrd = WFechaord
                    WFechaDesde = WFecha
                End If
                If cbx_Tipo.SelectedIndex = 5 Then
                    WFechaDesdeOrd = WFechaord
                    WFechaDesde = WFecha
                End If

                Dim WFechaHastaOrd As String = FechaFactuOrd
                Dim WFechaHasta As String = FechaFactu


                If WFechaHastaOrd > WFechaDesdeOrd Then

                    WSuma2 = "1"
                    REM by nan
                    Do

                        Dim Feriado As String = "N"
                        For i = 0 To ListaFeriados.Count - 1
                            If ListaFeriados(i) = WFechaDesde Then
                                Feriado = "S"
                                Exit For
                            End If
                        Next

                        REM 1 - DOMINGO
                        REM 2 - LUNES
                        REM 3 - MARTES
                        REM 4 - MIERCOLES
                        REM 5 - JUEVES
                        REM 6 - VIERNES
                        REM 7 - SABADO

                        Dim XFec1 As String = WFechaDesde
                        ' Dim strDia As String = Format$(XFec1, "dddd")
                        Dim Xfec1Date As Date = XFec1
                        Dim Bdia As Integer = Xfec1Date.DayOfWeek
                        'Dim BDia As Integer = Format(XFec1, "w")
                        If BDia = 1 Or BDia = 7 Then
                            Feriado = "S"
                        End If

                        If Feriado = "N" Then
                            WDias = WDias + 1
                        End If
                        Dim SumaDia As Integer = 2
                        Dim XFec2 As String = Calcula_vencimiento(XFec1, SumaDia)
                        WFechaDesde = XFec2

                        If WFechaDesde = WFechaHasta Then
                            Exit Do
                        End If

                    Loop

                End If

                Dim DifeDias As String = Str$(WDias)
                Dim WSuma1 As String = "1"

                If WDias <= 0 Then
                    WSuma2 = 0
                End If

                Dim WSumaLinea As String
                Dim WDesSumaLinea As String

                Select Case Val(WLinea)
                    Case 3, 4, 5, 7, 8, 11, 12, 14
                        WSumaLinea = "1"
                        WDesSumaLinea = "QUIMICOS"
                    Case 6, 16, 17
                        WSumaLinea = "2"
                        WDesSumaLinea = "COLORANTES"
                    Case 10, 22, 24, 25, 26, 27, 28, 29, 30
                        WSumaLinea = "3"
                        WDesSumaLinea = "FARMA"
                    Case 20
                        WSumaLinea = "5"
                        WDesSumaLinea = "FAZONES FARMA"
                    Case 21
                        WSumaLinea = "6"
                        WDesSumaLinea = "FAZONES QUIMICOS"
                    Case Else
                        Dim WRubro As Integer = 0
                        SQLCnslt = "SELECT Rubro FROM Cliente WHERE Cliente = '" & WCliente & "'"
                        Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If RowCli IsNot Nothing Then
                            WRubro = RowCli.Item("Rubro")
                        End If

                        If WCliente = "P00005" Then
                            WSumaLinea = "4"
                            WDesSumaLinea = "FAZONES PELLITAL"
                        Else
                            If WRubro = 10 Then
                                WSumaLinea = "5"
                                WDesSumaLinea = "FAZONES FARMA"
                            Else
                                WSumaLinea = "6"
                                WDesSumaLinea = "FAZONES QUIMICOS"
                            End If
                        End If
                End Select

                If cbx_Tipo.SelectedIndex = 4 Or cbx_Tipo.SelectedIndex = 5 Then
                    If Val(WTipoPedido) = 0 Then
                        Dim ZProvincia As Integer = 0
                        SQLCnslt = "SELECT Provincia FROM Cliente WHERE Cliente = '" & WCliente & "'"
                        Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If RowCli IsNot Nothing Then
                            ZProvincia = RowCli.Item("Provincia")
                        End If
                        
                        If ZProvincia <> 24 Then
                            WSumaLinea = "1"
                            WDesSumaLinea = "Normal"
                        Else
                            WSumaLinea = "2"
                            WDesSumaLinea = "Normal Expo"
                        End If
                    Else
                        WSumaLinea = "3"
                        WDesSumaLinea = "Resto"
                    End If
                End If

                Dim WSolicitud As Integer = 0
                Dim WMp As String = ""
                Dim WConcepto As String = ""
                Dim WProblema As String = ""
                Dim WFechaSolicitud As String = ""
                Dim ZLugar As Integer = 0

                Dim TablaProblema As New DataTable
                With TablaProblema.Columns
                    .Add("Concepto")
                    .Add("Problema")
                    .Add("Origen")
                    .Add("Fecha")
                End With

                SQLCnslt = "SELECT Concepto, Problema, Solicitud, Articulo, Fecha, Origen" _
                            & " FROM Atraso" _
                            & " WHERE Pedido = '" & WPedido & "'" _
                            & " ORDER BY Numero"
                Dim tablaAtraso As DataTable = GetAll(SQLCnslt, Operador.Base)
                If tablaAtraso.Rows.Count > 0 Then

                    For Each rowAtra As DataRow In tablaAtraso.Rows
                        Dim ZOrigen As String = IIf(IsDBNull(rowAtra.Item("Origen")), "0", rowAtra.Item("Origen"))
                        Select Case ZOrigen
                            Case 0
                                WConcepto = IIf(IsDBNull(rowAtra.Item("Concepto")), "0", rowAtra.Item("Concepto"))
                                WProblema = IIf(IsDBNull(rowAtra.Item("Problema")), "", rowAtra.Item("Problema"))
                                WSolicitud = IIf(IsDBNull(rowAtra.Item("Solicitud")), "0", rowAtra.Item("Solicitud"))
                                WMp = IIf(IsDBNull(rowAtra.Item("Articulo")), "", rowAtra.Item("Articulo"))

                                TablaProblema.Rows.Add()
                                TablaProblema.Rows(ZLugar).Item("Concepto") = WConcepto
                                TablaProblema.Rows(ZLugar).Item("Problema") = WProblema
                                TablaProblema.Rows(ZLugar).Item("Origen") = ZOrigen
                                TablaProblema.Rows(ZLugar).Item("Fecha") = Microsoft.VisualBasic.Left$(rowAtra.Item("Fecha"), 5)
                                ZLugar += 1
                            Case Else
                                WConcepto = IIf(IsDBNull(rowAtra.Item("Concepto")), "0", rowAtra.Item("Concepto"))
                                WProblema = IIf(IsDBNull(rowAtra.Item("Problema")), "", rowAtra.Item("Problema"))

                                TablaProblema.Rows.Add()
                                TablaProblema.Rows(ZLugar).Item("Concepto") = WConcepto
                                TablaProblema.Rows(ZLugar).Item("Problema") = WProblema
                                TablaProblema.Rows(ZLugar).Item("Origen") = ZOrigen
                                TablaProblema.Rows(ZLugar).Item("Fecha") = Microsoft.VisualBasic.Left$(rowAtra.Item("Fecha"), 5)
                                ZLugar += 1
                        End Select
                    Next
                  
                End If

                If TablaProblema.Rows.Count < 4 Then
                    While TablaProblema.Rows.Count < 4
                        TablaProblema.Rows.Add("", "", "", "")
                    End While
                End If


                If WSolicitud <> 0 Then
                    SQLCnslt = "Select Fecha" _
                                & " FROM Solic" _
                                & " Where Solicitud = '" & Str$(WSolicitud) & "'"
                    Dim rowSolic As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If rowSolic IsNot Nothing Then
                        WFechaSolicitud = IIf(IsDBNull(rowSolic.Item("Fecha")), "0", rowSolic.Item("Fecha"))
                    End If
                End If

                SQLCnslt = "UPDATE Pedido SET " _
                            & "Suma1 = '" & WSuma1 & "'," _
                            & "Suma2 = '" & Str$(WSuma2) & "'," _
                            & "Dias = '" & DifeDias & "'," _
                            & "FechaReal = '" & FechaFactu & "'," _
                            & "Linea = '" & WLinea & "'," _
                            & "SumaLinea = '" & WSumaLinea & "'," _
                            & "DesSumaLinea = '" & WDesSumaLinea & "'," _
                            & "DesEmpresa = '" & Operador.Base & "'," _
                            & "OrdFechaReal = '" & FechaFactuOrd & "'," _
                            & "Concepto = '" & TablaProblema.Rows(0).Item("Concepto") & "'," _
                            & "Problema = '" & TablaProblema.Rows(0).Item("Problema") & "'," _
                            & "OrigenI = '" & TablaProblema.Rows(0).Item("Origen") & "'," _
                            & "FechaI = '" & TablaProblema.Rows(0).Item("Fecha") & "'," _
                            & "ConceptoII = '" & TablaProblema.Rows(1).Item("Concepto") & "'," _
                            & "ProblemaII = '" & TablaProblema.Rows(1).Item("Problema") & "'," _
                            & "OrigenII = '" & TablaProblema.Rows(1).Item("Origen") & "'," _
                            & "FechaII = '" & TablaProblema.Rows(1).Item("Fecha") & "'," _
                            & "ConceptoIII = '" & TablaProblema.Rows(2).Item("Concepto") & "'," _
                            & "ProblemaIII = '" & TablaProblema.Rows(2).Item("Problema") & "'," _
                            & "OrigenIII = '" & TablaProblema.Rows(2).Item("Origen") & "'," _
                            & "FechaIII = '" & TablaProblema.Rows(2).Item("Fecha") & "'," _
                            & "ConceptoIV = '" & TablaProblema.Rows(3).Item("Concepto") & "'," _
                            & "ProblemaIV = '" & TablaProblema.Rows(3).Item("Problema") & "'," _
                            & "OrigenIV = '" & TablaProblema.Rows(3).Item("Origen") & "'," _
                            & "FechaIV = '" & TablaProblema.Rows(3).Item("Fecha") & "'," _
                            & "Mp = '" & WMp & "'," _
                            & "FechaSolicitud = '" & WFechaSolicitud & "'" _
                            & " WHERE Clave = '" & WClave & "'"



                ExecuteNonQueries({SQLCnslt}, Operador.Base)

            End If
            REM by nan
        Next

        With New VistaPrevia


            Dim WFormula As String = ""

            Select Case cbx_Tipo.SelectedIndex
                Case 0
                    WFormula = "{Pedido.Suma1} = 1 "

                    '.Reporte = "analisispedresu.rpt"
                    .Reporte = New Reporte_AnalisisPedResu()

                Case 1
                    WFormula = "{Pedido.Dias} >= 1 AND {Pedido.Dias} <= 999999 and {Pedido.Suma1} = 1"

                    .Reporte = New Reporte_AnalisisPed()
                    ' .Reporte = "analisisped.rpt"

                Case 2
                    WFormula = "{Pedido.Dias} >= -999999 AND {Pedido.Dias} <= 999999 AND {Pedido.Suma1} = 1"

                    .Reporte = New Reporte_AnalisisPedTotal()
                    ' .Reporte = "analisispedTotal.rpt"

                Case 3
                    WFormula = "{Pedido.Dias} >= 1 AND {Pedido.Dias} <= 999999 AND {Pedido.Suma1} = 1"

                    .Reporte = New Reporte_AnalisisPedConcepto()
                    ' .Reporte = "analisispedconcepto.rpt"

                Case 4
                    REM Listado.GroupSelectionFormula = "{Informe.fechaord} in " + Chr$(34) + WDesde + Chr$(34) + " to " + Chr$(34) + WHasta + Chr$(34)

                    .Reporte = New Reporte_AnalisisPedOtro()
                    '.Reporte = "analisispedOtro.rpt"

                Case 5
                    REM Listado.GroupSelectionFormula = "{Informe.fechaord} in " + Chr$(34) + WDesde + Chr$(34) + " to " + Chr$(34) + WHasta + Chr$(34)
                    .Reporte = New Reporte_AnalisisPedOtroResu()
                    '.Reporte = "analisispedOtroResu.rpt"

                Case Else
                    WFormula = "{Pedido.Dias} >= 1 AND {Pedido.Dias} <= 999999 AND {Pedido.Suma1} = 1"

                    .Reporte = New Reporte_AnalisisPed_Indicador()
                    '.Reporte = "analisispedindicador.rpt"


            End Select


            .Formula = WFormula


            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With
        
       
        
    End Sub


    Function Calcula_vencimiento(WFecha As String, Plazo As Integer) As String

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
        Dim WDia As String
        Dim aa As Integer
        Dim Ds(20) As Integer

        Ds(1) = 31
        Ds(2) = 28
        Ds(3) = 31
        Ds(4) = 30
        Ds(5) = 31
        Ds(6) = 30
        Ds(7) = 31
        Ds(8) = 31
        Ds(9) = 30
        Ds(10) = 31
        Ds(11) = 30
        Ds(12) = 31

        REM   DATA "0101","0105","2505", , ,"0907", ,"1210", ,"2512", , , , , ,


        WAno = Mid$(WFecha, 7, 4)
        Ano = Val(WAno)
        WMes = Mid$(WFecha, 4, 2)
        Mes = Val(WMes)
        WDia = Mid$(WFecha, 1, 2)
        Dia = Val(WDia)

        'CANTIDAD DE DIAS HASTA LA FECHA

        Dg = Dia + Plazo - 1

        Do
            For aa = Mes To 12
                If (Ano Mod 4 = 0) And Mes = 2 Then Ds(2) = 29 Else Ds(2) = 28
                If Dg <= Ds(aa) Then Exit Do
                Dg = Dg - Ds(aa)
            Next aa
            Ano = Ano + 1
            Mes = 1
        Loop

        Dia = Dg
        WDia$ = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Dia), 2, Len(Str$(Dia)) - 1), 2)

        Mes = aa
        WMes = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Mes), 2, Len(Str$(Mes)) - 1), 2)

        WAno = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Ano), 2, Len(Str$(Ano)) - 1), 4)

        Dim Wvenci As String = WDia + "/" + WMes + "/" + WAno

        Return Wvenci
    End Function


    Private Sub Analisis_Cumplimiento_PedidosDeVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        cbx_Tipo.SelectedIndex = 0
        cbx_FechaEntrega.SelectedIndex = 0
        cbx_FechaPedido.SelectedIndex = 0
    End Sub
End Class