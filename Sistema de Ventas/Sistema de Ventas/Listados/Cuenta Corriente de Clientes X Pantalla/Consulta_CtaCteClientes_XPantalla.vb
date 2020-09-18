Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Consulta_CtaCteClientes_XPantalla : Implements IBuscarClienteCashFlow



    Private Sub Proceso_Click()

        DGV_CtaCte.Rows.Clear()

        Dim Renglon As Integer = 0

        Dim ZDesdeAño As Integer = Val(Date.Today.Year) - 4

        Dim WSaldo As Double = 0

        Dim ZMarcarSedamil As String
        Dim ZMarcarColor As String

        ZMarcarSedamil = ""
        If txt_Cliente.Text = "S00008" Then
            ZMarcarSedamil = "S"
        End If

        ZMarcarColor = ""
        If txt_Cliente.Text = "C00055" Then
            ZMarcarColor = "S"
        End If


        Dim SQLCnslt As String = "Select Tipo, Total, Saldo, TotalUS, SaldoUS,Impre, Numero, Fecha, Vencimiento, Vencimiento1 " _
        & " FROM CtaCte" _
        & " Where Cliente = '" & txt_Cliente.Text & "'"

        'FILTRO Tipo de Listado
        If rabtn_CtaCte.Checked Then

            SQLCnslt = SQLCnslt & " AND (Tipo < 50 OR Tipo = 60)"

        End If
        If rabtn_Documentos.Checked Then

            SQLCnslt = SQLCnslt & " AND Tipo >= 50 AND Tipo <> 60"
            
        End If
        'FIN FILTRO Tipo de listado

        'FILTRO Tipo de Datos
        'FIN FILTRO Tipo de Datos

      
        If chk_RevertirOrd.Checked Then
            SQLCnslt = SQLCnslt & " Order by CtaCte.OrdFecha,CtaCte.Numero"
        Else
            SQLCnslt = SQLCnslt & " Order by CtaCte.OrdFecha desc,CtaCte.Numero desc"
        End If

        Dim TablaCtaCte As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaCtaCte.Rows.Count > 0 Then

            For Each RowCtaCte As DataRow In TablaCtaCte.Rows

                Dim WPasa As String = "S"

                Dim Importe1 As Double
                Dim Importe2 As Double
                Dim Importe3 As Double

                If rabtn_Pesos.Checked Then
                    If RowCtaCte.Item("Total") > 0 Then
                        Importe1 = RowCtaCte.Item("Total")
                        Importe2 = 0
                    Else
                        Importe1 = 0
                        Importe2 = RowCtaCte.Item("Total")
                    End If
                    Importe3 = RowCtaCte.Item("Saldo")
                Else
                    If RowCtaCte.Item("TotalUS") > 0 Then
                        Importe1 = RowCtaCte.Item("TotalUS")
                        Importe2 = 0
                    Else
                        Importe1 = 0
                        Importe2 = RowCtaCte.Item("TotalUS")
                    End If
                    Importe3 = RowCtaCte.Item("SaldoUS")
                End If



                If Importe3 = 0 Then
                    If chk_Ultimos5.Checked Then
                        Dim ZAno As Integer = Val(Mid$(RowCtaCte.Item("Fecha"), 7, 4))
                        If ZAno < ZDesdeAño And ZDesdeAño > 2000 Then
                            WPasa = "N"
                        End If
                    End If
                End If


                If WPasa = "S" Then
                    
                    If Importe3 <> 0 Or rabtn_TotalDatos.Checked Then

                        DGV_CtaCte.Rows.Add()

                        If ZMarcarSedamil = "S" Then

                            Dim ZSedamilFechaOrd As String = ordenaFecha(RowCtaCte.Item("Fecha"))

                            If Val(ZSedamilFechaOrd) > 20180411 Then

                                For i = 0 To DGV_CtaCte.Columns.Count - 1
                                    'VER DESPUES
                                    'Muestra.Col = i
                                    'Muestra.CellBackColor = &H80000008

                                Next

                                ZMarcarSedamil = "N"
                            End If

                        End If

                        If ZMarcarColor = "S" Then

                            Dim ZColorFechaOrd As String = ordenaFecha(RowCtaCte.Item("Fecha"))

                            If Val(ZColorFechaOrd) > 20181201 Then

                                For i = 0 To DGV_CtaCte.Columns.Count - 1

                                    'VER DESPUES
                                    'Muestra.Col = i
                                    'Muestra.CellBackColor = &H80000008

                                Next


                                ZMarcarColor = "N"
                            End If

                        End If



                        Select Case RowCtaCte.Item("Tipo")
                            Case 1
                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Fac"


                                If Trim(OrDefault(RowCtaCte.Item("Impre"), "")) = "FCE" Then
                                    DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "FCE"
                                End If


                            Case 2

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Dev"
                            Case 3

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Fac"
                            Case 4

                                Select Case Microsoft.VisualBasic.Left$(RowCtaCte.Item("Impre"), 2)
                                    Case "DC"
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "D.C"
                                    Case "CH"
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "CHR"
                                    Case Else
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "N/D"
                                End Select
                            Case 5

                                Select Case Microsoft.VisualBasic.Left$(RowCtaCte.Item("Impre"), 2)
                                    Case "DC"
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "D.C"
                                    Case "CH"
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "CHR"
                                    Case Else
                                        DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "N/C"
                                End Select
                            Case 6

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Rec"
                            Case 7

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Ant"
                            Case 10

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "FCR"
                            Case 50

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "Doc"
                            Case 60

                                DGV_CtaCte.Rows(Renglon).Cells("Tipo").Value = "NCE"
                            Case Else
                        End Select


                        DGV_CtaCte.Rows(Renglon).Cells("Numero").Value = RowCtaCte.Item("Numero")


                        DGV_CtaCte.Rows(Renglon).Cells("Fecha").Value = RowCtaCte.Item("Fecha")

                        If Importe1 <> 0 Then
                            DGV_CtaCte.Rows(Renglon).Cells("Debito").Value = formatonumerico(Importe1)
                            Else
                            DGV_CtaCte.Rows(Renglon).Cells("Debito").Value = ""
                        End If

                        If Importe2 <> 0 Then
                            DGV_CtaCte.Rows(Renglon).Cells("Credito").Value = formatonumerico(Importe2)
                            Else
                            DGV_CtaCte.Rows(Renglon).Cells("Credito").Value = ""
                        End If

                        If Importe3 <> 0 Then
                            DGV_CtaCte.Rows(Renglon).Cells("Saldo").Value = formatonumerico(Importe3)
                        Else
                            DGV_CtaCte.Rows(Renglon).Cells("Saldo").Value = ""
                        End If

                        If chk_RevertirOrd.Checked = False Then

                            WSaldo = WSaldo + Val(Importe3)

                            DGV_CtaCte.Rows(Renglon).Cells("Vencimiento").Value = RowCtaCte.Item("Vencimiento")


                            DGV_CtaCte.Rows(Renglon).Cells("VencimientoII").Value = RowCtaCte.Item("Vencimiento1")


                            DGV_CtaCte.Rows(Renglon).Cells("Acumulado").Value = formatonumerico(WSaldo)


                        Else

                            REM WSaldo = WSaldo + Importe3

                           DGV_CtaCte.Rows(Renglon).Cells("Vencimiento").Value = RowCtaCte.Item("Vencimiento")


                            DGV_CtaCte.Rows(Renglon).Cells("VencimientoII").Value = RowCtaCte.Item("Vencimiento1")

                            REM Muestra.Col = 9
                            REM Muestra.Text = Pusing("###,###,###.##", Str$(WSaldo))

                        End If

                        Renglon += 1

                    End If

                End If


            Next


        End If

        If chk_RevertirOrd.Checked Then
            WSaldo = 0
            For ciclo = (DGV_CtaCte.Rows.Count - 1) To 0 Step -1
                WSaldo = WSaldo + Val(DGV_CtaCte.Rows(ciclo).Cells("Saldo").Value)
                DGV_CtaCte.Rows(ciclo).Cells("Acumulado").Value = formatonumerico(WSaldo)
            Next
        End If
        
        txt_Saldo.Text = formatonumerico(WSaldo)

    End Sub
    
    Private Sub txt_Cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txt_Cliente.Text = UCase(txt_Cliente.Text)

                Dim SQLCnslt As String = "SELECT Razon From Cliente WHERE Cliente = '" & txt_Cliente.Text & "'"

                Dim RowClie As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If RowClie IsNot Nothing Then
                    txt_ClienteDes.Text = RowClie.Item("Razon")
                    Proceso_Click()
                Else
                    MsgBox("No es un codigo de cliente valido, verificar")
                    txt_Cliente.Focus()
                    txt_Cliente.SelectAll()
                End If

            Case Keys.Escape
                txt_Cliente.Text = ""
        End Select
      
    End Sub

    Private Sub btn_ConsultaCliente_Click(sender As Object, e As EventArgs) Handles btn_ConsultaCliente.Click
        With New ConsultaCliente()
            .Show(Me)
        End With
    End Sub

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        txt_Cliente.Text = CodigoCliente
        txt_Cliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Listar_Click(sender As Object, e As EventArgs) Handles btn_Listar.Click
        Dim WTitulo As String = ""
        dim Acumula as double = 0


        If rabtn_CtaCte.Checked Then
            WTitulo = "Cuenta Corriente - "
        End If
        If rabtn_Documentos.Checked Then
            WTitulo = "Documentos - "
        End If
        If rabtn_Total.Checked Then
            WTitulo = "Total - "
        End If

        If rabtn_Pesos.Checked Then
            WTitulo = WTitulo + "Pesos"
        End If
        If rabtn_Dolares.Checked Then
            WTitulo = WTitulo + "Dolares"
        End If


        Dim WCliente As String = UCase(txt_Cliente.Text)


        Dim tablaReporteCtaCte As DataTable = New DBAuxi.tablaReporteCtaCteDataTable()
       
        Dim SQLCnslt As String = "SELECT ct.clave, c.Razon, ct.tipo, ct.impre, ct.numero, ct.renglon,ct.Fecha, " _
                                 & "ct.vencimiento, ct.vencimiento1, ct.total, ct.saldo, ct.totalus, ct.saldous, " _
                                 & "ct.ordfecha, ct.ordvencimiento, ct.ordvencimiento1, ct.Importe1, ct.importe2, " _
                                 & "ct.importe3, ct.importe4 " _
                                 & " FROM Ctacte ct INNER JOIN Cliente C ON ct.Cliente = c.Cliente" _
                                 & " Where ct.Cliente =  '" & WCliente & "' and ct.saldo <> 0"
        If chk_Ultimos5.Checked Then
            Dim año As Integer = Date.Today.Year - 5
            Dim OrdFechaActual As String = año & Date.Today.Month.ToString().PadLeft(2, "0") & Date.Today.Day.ToString().ToString().PadLeft(2, "0")
            SQLCnslt = SQLCnslt & " AND ct.ordFecha >= '" & OrdFechaActual & "'"
        End If

        'FILTRO Tipo de Listado
        If rabtn_CtaCte.Checked Then

            SQLCnslt = SQLCnslt & " AND (ct.Tipo < 50 OR ct.Tipo = 60)"

        End If
        If rabtn_Documentos.Checked Then

            SQLCnslt = SQLCnslt & " AND (ct.Tipo >= 50 OR ct.Tipo <> 60)"

        End If
        'FIN FILTRO Tipo de listado

        Dim tablaCtaCte As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tablaCtaCte.Rows.Count > 0 Then
            For Each Row As DataRow In tablaCtaCte.Rows

                Dim WTipo As String = Row.Item("Tipo")
                Dim WImpre As String = Row.Item("Impre")
                Dim WNumero As String = Row.Item("Numero")
                Dim WFecha As String = Row.Item("Fecha")
                Dim WRazon As String = Row.Item("Razon")
                Dim Wvencimiento As String = Row.Item("Vencimiento")
                Dim WVencimiento1 As String = Row.Item("Vencimiento1")
                ' Dim WTotal As String = Row.Item("Total")
                ' Dim WTotalUs As String = Row.Item("Totalus")
                '  Dim WSaldo As String = Row.Item("Saldo")
                ' Dim WSaldoUs As String = Row.Item("Saldous")

                Dim WOrdFecha As String = Row.Item("OrdFecha")
                Dim WOrdVencimiento As String = Row.Item("OrdVencimiento")
                ' Dim WOrdVencimiento1 As String = Row.Item("OrdVencimiento1")

                Dim WImporte1 As Double
                Dim WImporte2 As Double
                Dim WImporte3 As Double

                If rabtn_Pesos.Checked Then
                    WImporte1 = Row.Item("Total")
                    WImporte2 = 0
                    WImporte3 = Row.Item("Saldo")
                Else
                    WImporte1 = Row.Item("Totalus")
                    WImporte2 = 0
                    WImporte3 = Row.Item("Saldous")
                End If



                If rabtn_Total.Checked Or Val(WImporte3) <> 0 Then
                    Dim Posicion As Integer = tablaReporteCtaCte.Rows.Count

                    'Acumula = Acumula + Val(WImporte3)
                    Acumula = Acumula + Val(formatonumerico(WImporte3))
                    Dim WImporte4 As Double = Acumula


                    tablaReporteCtaCte.Rows.Add()

                    With tablaReporteCtaCte.Rows(Posicion)
                        .Item("Cliente") = WCliente
                        .Item("Razon") = WRazon
                        .Item("Impre") = WImpre
                        .Item("Numero") = WNumero
                        .Item("Fecha") = WFecha
                        .Item("FechaOrd") = ordenaFecha(WFecha)
                        .Item("Vencimiento") = Wvencimiento
                        .Item("Vencimiento1") = WVencimiento1
                        .Item("OrdVencimiento") = WOrdVencimiento
                        .Item("Claveimpre") = WCliente & WOrdFecha & WTipo & WNumero.PadLeft(8, "0")
                        .Item("Importe1") = WImporte1
                        .Item("Importe2") = WImporte2
                        .Item("Importe3") = WImporte3
                        .Item("Importe4") = WImporte4
                    End With
                End If


            Next
        End If

        With New VistaPrevia
            .Reporte = New ReporteListado_CtaCte
            .Reporte.SetDataSource(tablaReporteCtaCte)
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)

            .Mostrar()


        End With
    End Sub

    Private Sub btn_Reclamos_Click(sender As Object, e As EventArgs) Handles btn_Reclamos.Click
        With New Reclamos_CtaCteClientes(txt_Cliente.Text, txt_ClienteDes.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub btn_DatosClientes_Click(sender As Object, e As EventArgs) Handles btn_DatosClientes.Click
        With New DatosdeCliente(txt_Cliente.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_CtaCte_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_CtaCte.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 0
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 1
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)
          
            Case 2, 6, 7
                'Fechas
                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

            Case 3, 4, 5, 8
                'Numericos con coma
                num1 = CDbl(Val(e.CellValue1))
                num2 = CDbl(Val(e.CellValue2))
            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True

    End Sub

  

    Private Sub txt_Cliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_Cliente.MouseDoubleClick
        With New ConsultaCliente()
            .Show(Me)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txt_Cliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub
End Class