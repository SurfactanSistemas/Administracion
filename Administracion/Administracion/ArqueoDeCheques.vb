﻿Imports System.Net.Configuration
Imports CrystalDecisions.Shared

Public Class ArqueoDeCheques

    Dim RowIndex As Integer = 0
    Dim tablaChequesEliminados As New DataTable
    Dim ultimaFechaLeida As String = "  /  /    "
    Dim UltimoImporte As Double
    Dim AqueBase As String = ""
    Dim CodigoUltimoCheque As String = ""
    Dim MontoTotal As Double = 0
    Dim CantidadTotalChques As Integer
    Dim SumaPorFecha(9) As Double
    Dim fechaInicial As Date = Today
    Dim RangoFechas(9, 2) As String







    Private Sub ArqueoDeCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With tablaChequesEliminados.Columns
            .Add("Fecha")
            .Add("Numero")
            .Add("Importe")
            .Add("Banco")
            .Add("ClaveCheque")
        End With

        Me.Text = ""
        txtCodigoCheque.Focus()
        CargarCheques()
        For i = 0 To DGV_Cheques.Rows.Count - 1
            MontoTotal += Val(DGV_Cheques.Rows(i).Cells("Importe").Value)
        Next
        CantidadTotalChques = DGV_Cheques.Rows.Count
        Label17.Text = "en " & CantidadTotalChques & " cheques"
        txtMontoTotal.Text = formatonumerico(MontoTotal, 2)

        'DEFINO LOS RANGOS HORARIOS DE CADA LUGAR EN LA GRILLA MENSUAL
        Label9.Text = "1 al " & DateTime.DaysInMonth(Year(fechaInicial), Month(fechaInicial)) & " de " & MonthName(Month(fechaInicial))
        RangoFechas(1, 1) = ordenaFecha("01/" & (Month(fechaInicial)).ToString().PadLeft(2, "0") & "/" & Year(fechaInicial))
        RangoFechas(1, 2) = ordenaFecha(DateTime.DaysInMonth(Year(fechaInicial), Month(fechaInicial)) & "/" & (Month(fechaInicial)).ToString().PadLeft(2, "0") & "/" & Year(fechaInicial))


        Dim FechaRango2y3 As Date = fechaInicial.AddMonths(1)
        'PRIMER QUINCENA DEL MES SIGUIENTE
        Label10.Text = "1 al " & "15 de " & MonthName(Month(FechaRango2y3))
        RangoFechas(2, 1) = ordenaFecha("01/" & (Month(FechaRango2y3)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango2y3))
        RangoFechas(2, 2) = ordenaFecha("15/" & (Month(FechaRango2y3)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango2y3))
        'SEGUNDA QUINCENA DE MES SIGUIENTE
        Label11.Text = "16 al " & DateTime.DaysInMonth(Year(FechaRango2y3), Month(FechaRango2y3)) & " de " & MonthName(Month(FechaRango2y3))
        RangoFechas(3, 1) = ordenaFecha("16/" & (Month(FechaRango2y3)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango2y3))
        RangoFechas(3, 2) = ordenaFecha(DateTime.DaysInMonth(Year(FechaRango2y3), Month(FechaRango2y3)) & "/" & (Month(FechaRango2y3)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango2y3))



        Dim FechaRango4y5 As Date = fechaInicial.AddMonths(2)
        'PRIMER QUINCENA DEL 2 MES SIGUIENTE
        Label12.Text = "1 al " & "15 de " & MonthName(Month(FechaRango4y5))
        RangoFechas(4, 1) = ordenaFecha("01/" & (Month(FechaRango4y5)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango4y5))
        RangoFechas(4, 2) = ordenaFecha("15/" & (Month(FechaRango4y5)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango4y5))
        'SEGUNDA QUINCENA DE 2 MES SIGUIENTE
        Label13.Text = "16 al " & DateTime.DaysInMonth(Year(FechaRango4y5), Month(FechaRango4y5)) & " de " & MonthName(Month(FechaRango4y5))
        RangoFechas(5, 1) = ordenaFecha("16/" & (Month(FechaRango4y5)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango4y5))
        RangoFechas(5, 2) = ordenaFecha(DateTime.DaysInMonth(Year(FechaRango4y5), Month(FechaRango4y5)) & "/" & (Month(FechaRango4y5)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango4y5))


        Dim FechaRango6y7 As Date = fechaInicial.AddMonths(3)
        'PRIMER QUINCENA DEL 3 MES SIGUIENTE
        Label14.Text = "1 al " & "15 de " & MonthName(Month(FechaRango6y7))
        RangoFechas(6, 1) = ordenaFecha("01/" & (Month(FechaRango6y7)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango6y7))
        RangoFechas(6, 2) = ordenaFecha("15/" & (Month(FechaRango6y7)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango6y7))
        'SEGUNDA QUINCENA DE 3 MES SIGUIENTE
        Label15.Text = "16 al " & DateTime.DaysInMonth(Year(FechaRango6y7), Month(FechaRango6y7)) & " de " & MonthName(Month(FechaRango6y7))
        RangoFechas(7, 1) = ordenaFecha("16/" & (Month(FechaRango6y7)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango6y7))
        RangoFechas(7, 2) = ordenaFecha(DateTime.DaysInMonth(Year(FechaRango6y7), Month(FechaRango6y7)) & "/" & (Month(FechaRango6y7)).ToString().PadLeft(2, "0") & "/" & Year(FechaRango6y7))

        'EL ULTIMO RANGO ES MAYOR A LA ULTIMA FECHA POR ESO GUARDAMOS EL MISMO VALOR
        Label16.Text = "De " & MonthName(Month(FechaRango6y7.AddMonths(1))) & " en adelante"
        RangoFechas(8, 1) = RangoFechas(7, 2)

        For i = 1 To 8
            SumaPorFecha(i) = 0
        Next

        _RefrescartxtboxSumas()



    End Sub

    Private Sub _RefrescartxtboxSumas()
        txtmesInicial.Text = SumaPorFecha(1)
        txtmes2Q1.Text = SumaPorFecha(2)
        txtmes2Q2.Text = SumaPorFecha(3)
        txtmes3Q1.Text = SumaPorFecha(4)
        txtmes3Q2.Text = SumaPorFecha(5)
        txtmes4Q1.Text = SumaPorFecha(6)
        txtmes4Q2.Text = SumaPorFecha(7)
        txtmesesRestantes.Text = SumaPorFecha(8)
    End Sub



    Private Sub CargarCheques()

        Dim SQLCnslt As String = ""

        'TRAIGO LOS CHEQUES EN RECIBOS
        SQLCnslt = "SELECT Importe2, Numero2, Fecha2 , Banco2, ClaveCheque FROM Recibos WHERE TipoReg = '2' "
        SQLCnslt = SQLCnslt & "AND Estado2 <> 'X' AND Tipo2 = '02' ORDER BY FechaOrd2, Numero2"

        Dim tablaRecibos As DataTable = GetAll(SQLCnslt)

        If tablaRecibos.Rows.Count > 0 Then
            For Each row In tablaRecibos.Rows

                DGV_Cheques.Rows.Add(row.Item("Fecha2"), row.Item("Numero2"), formatonumerico(row.Item("Importe2")), row.Item("Banco2"), UCase(row.Item("ClaveCheque")), "R", ordenaFecha(row.Item("Fecha2")))

            Next
        End If

        'TRAIGO LOS CHEQUES EN RECIBOS PROVISORIOS
        SQLCnslt = "SELECT Importe2, Numero2, Fecha2 , Banco2, ClaveCheque FROM RecibosProvi WHERE TipoReg = '2' "
        SQLCnslt = SQLCnslt & "AND Estado2 = 'P' AND ReciboDefinitivo = '0' AND FechaOrd2 > '20191231' ORDER BY FechaOrd2, Numero2"

        Dim tablaRecibosProvisorios As DataTable = GetAll(SQLCnslt)

        If tablaRecibosProvisorios.Rows.Count > 0 Then
            For Each row In tablaRecibosProvisorios.Rows

                DGV_Cheques.Rows.Add(row.Item("Fecha2"), row.Item("Numero2"), formatonumerico(row.Item("Importe2")), row.Item("Banco2"), UCase(row.Item("ClaveCheque")), "RP", ordenaFecha(row.Item("Fecha2")))

            Next
        End If

    End Sub



    Private Sub txtCodigoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCheque.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtCodigoCheque.Text <> "" Then
                    txtCodigoCheque.Text = txtCodigoCheque.Text.ToUpper().Replace(";", "C").Replace(":", "E")
                    If txtCodigoCheque.Text.Length = 31 Then
                        For Each row As DataGridViewRow In DGV_Cheques.Rows
                            If Trim(row.Cells("ClaveCheque").Value).ToUpper = txtCodigoCheque.Text.ToUpper Then
                                mastxtFecha.Text = row.Cells("Fecha").Value
                                txtNumeroCheque.Text = row.Cells("Numero").Value
                                txtImporte.Text = row.Cells("Importe").Value
                                txtBanco.Text = row.Cells("Banco").Value

                                'DESCUENTO DEL TOTAL DE CHEQUES EL IMPORTE DEL CHEQUE
                                MontoTotal -= Val(row.Cells("Importe").Value)

                                'GUARDO LA FECHA PARA PODER VERIFICARLA DESPUES SI HACE UNA MODIFICACION
                                ultimaFechaLeida = row.Cells("Fecha").Value
                                'GUARDO EL ULTIMO IMPORTE PARA PODER MODIFICARLO DESPUES
                                UltimoImporte = Val(row.Cells("Importe").Value)
                                'Y A QUE BASE TENGO Q MODIFICAR
                                AqueBase = row.Cells("Origen").Value
                                'Y EL CODIGO DEL CHEQUE
                                CodigoUltimoCheque = row.Cells("ClaveCheque").Value

                                'RESTO DE LA CANTIDAD DE CHEQUES
                                CantidadTotalChques -= 1
                                Label17.Text = "en " & CantidadTotalChques & " cheques"

                                'MUESTRO EL VALOR NUEVO
                                'txtMontoTotal.Text = MontoTotal
                                txtMontoTotal.Text = formatonumerico(MontoTotal, 2)


                                _SumarDondeDebe(Val(row.Cells("Importe").Value), ordenaFecha(row.Cells("Fecha").Value))

                                RowIndex = row.Index

                                'AGREGO A LA TABLA REGISTRO DE LOS CHEQUES QUE SACO DEL GRID
                                tablaChequesEliminados.Rows.Add(row.Cells("Fecha").Value, row.Cells("Numero").Value, row.Cells("Importe").Value, row.Cells("Banco").Value, row.Cells("ClaveCheque").Value)


                                DGV_Cheques.Rows.RemoveAt(RowIndex)

                                txtCodigoCheque.Text = ""
                                Exit Sub

                            End If
                        Next
                    End If
                End If

                If _BuscarEnEliminados() = "Esta" Then
                    MsgBox("Ya desconto ese cheque de la lista")
                    txtCodigoCheque.Text = ""
                Else
                    MsgBox("Cheque no encontrado")
                    txtCodigoCheque.Text = ""
                End If

                txtCodigoCheque.SelectAll()
            Case Keys.Escape
                txtCodigoCheque.Text = ""
        End Select

    End Sub


    Private Sub _SumarDondeDebe(ByVal Importe As Double, ByVal FechaOrd As String, Optional ByVal Restas As Boolean = False)
        'SI RECIBO TRUE, ES PORQUE SE DESCUENTA
        'SINO SE SUMA
        If FechaOrd >= RangoFechas(1, 1) And FechaOrd <= RangoFechas(1, 2) Then
            If Restas = False Then
                SumaPorFecha(1) += Importe
            Else
                SumaPorFecha(1) -= Importe
            End If

        End If

        If FechaOrd >= RangoFechas(2, 1) And FechaOrd <= RangoFechas(2, 2) Then
            If Restas = False Then
                SumaPorFecha(2) += Importe
            Else
                SumaPorFecha(2) -= Importe
            End If
        End If

        If FechaOrd >= RangoFechas(3, 1) And FechaOrd <= RangoFechas(3, 2) Then
            If Restas = False Then
                SumaPorFecha(3) += Importe
            Else
                SumaPorFecha(3) -= Importe
            End If
        End If

        If FechaOrd >= RangoFechas(4, 1) And FechaOrd <= RangoFechas(4, 2) Then
            If Restas = False Then
                SumaPorFecha(4) += Importe
            Else
                SumaPorFecha(4) -= Importe
            End If
        End If

        If FechaOrd >= RangoFechas(5, 1) And FechaOrd <= RangoFechas(5, 2) Then
            If Restas = False Then
                SumaPorFecha(5) += Importe
            Else
                SumaPorFecha(5) -= Importe
            End If
        End If

        If FechaOrd >= RangoFechas(6, 1) And FechaOrd <= RangoFechas(6, 2) Then
            If Restas = False Then
                SumaPorFecha(6) += Importe
            Else
                SumaPorFecha(6) -= Importe
            End If
        End If

        If FechaOrd >= RangoFechas(7, 1) And FechaOrd <= RangoFechas(7, 2) Then
            If Restas = False Then
                SumaPorFecha(7) += Importe
            Else
                SumaPorFecha(7) -= Importe
            End If
        End If

        If FechaOrd > RangoFechas(8, 1) Then
            If Restas = False Then
                SumaPorFecha(8) += Importe
            Else
                SumaPorFecha(8) -= Importe
            End If
        End If

        _RefrescartxtboxSumas()

    End Sub


    Private Function _BuscarEnEliminados() As String
        For i = 0 To tablaChequesEliminados.Rows.Count - 1

            If txtCodigoCheque.Text.ToUpper.Trim = Trim(tablaChequesEliminados.Rows(i).Item("ClaveCheque")).ToUpper Then
                Return "Esta"
            End If

        Next
        Return "No Esta"
    End Function

    Private Sub mastxtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then

                    If mastxtFecha.Text <> ultimaFechaLeida Then

                        Dim fechaOrd As String = ordenaFecha(mastxtFecha.Text)
                        Dim SQLCnslt As String = ""

                        _RestarYsumarDondeCorresponda(ordenaFecha(ultimaFechaLeida), ordenaFecha(mastxtFecha.Text), UltimoImporte)
                        'CON ORIGEN BUSCAMOS A QUE BASE TENEMOS QUE MODIFICAR
                        If AqueBase = "R" Then

                            SQLCnslt = "UPDATE Recibos SET Fecha2 = '" & mastxtFecha.Text & "', FechaOrd2 = '" & fechaOrd & "' WHERE ClaveCheque = '" & CodigoUltimoCheque & "'"

                        Else

                            SQLCnslt = "UPDATE RecibosProvi SET Fecha2 = '" & mastxtFecha.Text & "', FechaOrd2 = '" & fechaOrd & "' WHERE ClaveCheque = '" & CodigoUltimoCheque & "'"

                        End If

                        ExecuteNonQueries({SQLCnslt})

                        MsgBox("La Fecha se a modificado con exito")

                        txtCodigoCheque.Focus()
                        txtCodigoCheque.SelectAll()
                    End If



                Else
                    MsgBox("Verifique que la Fecha sea valida")


                End If




            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub

    Private Sub _RestarYsumarDondeCorresponda(ByVal FechaAntigua As String, ByVal FechaNueva As String, ByVal ImporteModificar As Double)

        _SumarDondeDebe(ImporteModificar, FechaAntigua, True)
        _SumarDondeDebe(ImporteModificar, FechaNueva)


    End Sub

    Private Function _buscarPosicionActual() As Integer
        For Each row As DataGridViewRow In DGV_Cheques.Rows
            If row.Cells("ClaveCheque").Value = txtCodigoCheque.Text Then
                Return row.Index
            End If
        Next

        Return 1
    End Function

    Private Sub _limpiarDatos()
        txtCodigoCheque.Text = ""
        txtNumeroCheque.Text = ""
        mastxtFecha.Text = ""
        txtImporte.Text = ""
        txtBanco.Text = ""

        txtCodigoCheque.Focus()

    End Sub


    'Private Sub DGV_Cheques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Cheques.CellDoubleClick
    '    txtNumeroCheque.Text = DGV_Cheques.CurrentRow.Cells("Numero").Value
    '    mastxtFecha.Text = DGV_Cheques.CurrentRow.Cells("Fecha").Value
    '    txtImporte.Text = DGV_Cheques.CurrentRow.Cells("Importe").Value
    '    txtBanco.Text = DGV_Cheques.CurrentRow.Cells("Banco").Value
    '    Dim index As Integer = DGV_Cheques.CurrentRow.Index
    '    DGV_Cheques.Rows.RemoveAt(index)
    'End Sub



    Private Sub DGV_Cheques_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_Cheques.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            '            Case 4
            '
            '                num1 = e.CellValue1
            '                num2 = e.CellValue2
            '
            Case 2

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 0

                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim TablaArqueoCheques As New DataTable

        With TablaArqueoCheques.Columns
            .Add("Fecha")
            .Add("Numero")
            .Add("Importe")
            .Add("Banco")
            .Add("ClaveCheque")
            .Add("Origen")
            .Add("FechaOrd")
        End With

        For Each Row As DataGridViewRow In DGV_Cheques.Rows
            TablaArqueoCheques.Rows.Add()
            TablaArqueoCheques(Row.Index).Item("Fecha") = Row.Cells("Fecha").Value
            TablaArqueoCheques(Row.Index).Item("Numero") = Row.Cells("Numero").Value
            TablaArqueoCheques(Row.Index).Item("Importe") = Row.Cells("Importe").Value
            TablaArqueoCheques(Row.Index).Item("Banco") = Row.Cells("Banco").Value
            TablaArqueoCheques(Row.Index).Item("ClaveCheque") = Row.Cells("ClaveCheque").Value
            TablaArqueoCheques(Row.Index).Item("Origen") = Row.Cells("Origen").Value
            TablaArqueoCheques(Row.Index).Item("FechaOrd") = Row.Cells("FechaOrd").Value
        Next



        With New ConsultasVarias.VistaPrevia
            .Reporte = New ReporteArqueoCheques
            .Reporte.SetDataSource(TablaArqueoCheques)

            .Imprimir()
            '.Exportar("", ExportFormatType.Excel, "")
        End With

    End Sub

    Private Sub DGV_Cheques_MouseUp(sender As Object, e As MouseEventArgs) Handles DGV_Cheques.MouseUp
        Dim sumaImportes As Double = 0

        For Each cell As DataGridViewCell In DGV_Cheques.SelectedCells
            DGV_Cheques.Rows(cell.RowIndex).Selected = True

        Next



        If DGV_Cheques.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DGV_Cheques.SelectedRows
                sumaImportes += Val(row.Cells("Importe").Value)
            Next
            txtSumaImportes.Text = sumaImportes
            txtSumaImportes.Visible = True
            Label8.Visible = True
        Else
            txtSumaImportes.Visible = False
            Label8.Visible = False
        End If


    End Sub

    Private Sub DGV_Cheques_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Cheques.RowHeaderMouseDoubleClick
        With DGV_Cheques.CurrentRow
            txtNumeroCheque.Text = .Cells("Numero").Value
            mastxtFecha.Text = .Cells("Fecha").Value
            txtImporte.Text = .Cells("Importe").Value
            txtBanco.Text = .Cells("Banco").Value

            'GUARDO LA FECHA PARA PODER VERIFICARLA DESPUES SI HACE UNA MODIFICACION
            ultimaFechaLeida = .Cells("Fecha").Value
            'GUARDO EL ULTIMO IMPORTE PARA PODER MODIFICARLO DESPUES
            UltimoImporte = Val(.Cells("Importe").Value)
            'AGREGO A LA TABLA REGISTRO DE LOS CHEQUES QUE SACO DEL GRID
            tablaChequesEliminados.Rows.Add(.Cells("Fecha").Value, .Cells("Numero").Value, .Cells("Importe").Value, .Cells("Banco").Value, .Cells("ClaveCheque").Value)

            'SUMAMOS EN EL TEXTBOX QUE CORRESPONDE
            _SumarDondeDebe(Val(.Cells("Importe").Value), ordenaFecha(.Cells("Fecha").Value))


            'DESCUENTO DEL TOTAL DE CHEQUES EL IMPORTE DEL CHEQUE
            MontoTotal -= Val(.Cells("Importe").Value)


            'RESTO DE LA CANTIDAD DE CHEQUES
            CantidadTotalChques -= 1
            Label17.Text = "en " & CantidadTotalChques & " cheques"

            'MUESTRO EL VALOR NUEVO
            txtMontoTotal.Text = formatonumerico(MontoTotal, 2)
            'txtMontoTotal.Text = MontoTotal

            Dim index As Integer = DGV_Cheques.CurrentRow.Index

            DGV_Cheques.Rows.RemoveAt(index)

            txtCodigoCheque.Focus()
        End With


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim TablaArqueoCheques As New DataTable

        With TablaArqueoCheques.Columns
            .Add("Fecha")
            .Add("Numero")
            .Add("Importe")
            .Add("Banco")
            .Add("ClaveCheque")
            .Add("Origen")
            .Add("FechaOrd")
        End With

        For Each Row As DataGridViewRow In DGV_Cheques.Rows
            TablaArqueoCheques.Rows.Add()
            TablaArqueoCheques(Row.Index).Item("Fecha") = Row.Cells("Fecha").Value
            TablaArqueoCheques(Row.Index).Item("Numero") = Row.Cells("Numero").Value
            TablaArqueoCheques(Row.Index).Item("Importe") = Row.Cells("Importe").Value
            TablaArqueoCheques(Row.Index).Item("Banco") = Row.Cells("Banco").Value
            TablaArqueoCheques(Row.Index).Item("ClaveCheque") = Row.Cells("ClaveCheque").Value
            TablaArqueoCheques(Row.Index).Item("Origen") = Row.Cells("Origen").Value
            TablaArqueoCheques(Row.Index).Item("FechaOrd") = Row.Cells("FechaOrd").Value
        Next



        With New ConsultasVarias.VistaPrevia
            .Reporte = New ReporteArqueoCheques
            .Reporte.SetDataSource(TablaArqueoCheques)

            .Exportar("", ExportFormatType.Excel, "")
        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim Total As Double = 0

        Total = _SumarTexts()

        With New ConsultasVarias.VistaPrevia
            .Reporte = New ReporteArqueoMensualChequesAcumulado()
            .Reporte.SetParameterValue(0, Label9.Text)
            .Reporte.SetParameterValue(1, Label10.Text)
            .Reporte.SetParameterValue(2, Label11.Text)
            .Reporte.SetParameterValue(3, Label12.Text)
            .Reporte.SetParameterValue(4, Label13.Text)
            .Reporte.SetParameterValue(5, Label14.Text)
            .Reporte.SetParameterValue(6, Label15.Text)
            .Reporte.SetParameterValue(7, Label16.Text)
            .Reporte.SetParameterValue(8, Val(formatonumerico(txtmesInicial.Text)))
            .Reporte.SetParameterValue(9, Val(formatonumerico(txtmes2Q1.Text)))
            .Reporte.SetParameterValue(10, Val(formatonumerico(txtmes2Q2.Text)))
            .Reporte.SetParameterValue(11, Val(formatonumerico(txtmes3Q1.Text)))
            .Reporte.SetParameterValue(12, Val(formatonumerico(txtmes3Q2.Text)))
            .Reporte.SetParameterValue(13, Val(formatonumerico(txtmes4Q1.Text)))
            .Reporte.SetParameterValue(14, Val(formatonumerico(txtmes4Q2.Text)))
            .Reporte.SetParameterValue(15, Val(formatonumerico(txtmesesRestantes.Text)))
            .Reporte.SetParameterValue(16, Total)

            .Imprimir()
            '.Exportar("", ExportFormatType.Excel, "")
        End With
    End Sub

    Private Function _Sumartexts() As Double
        Dim Total As Double = 0

        Total += Val(formatonumerico(txtmesInicial.Text))
        Total += Val(formatonumerico(txtmes2Q1.Text))
        Total += Val(formatonumerico(txtmes2Q2.Text))
        Total += Val(formatonumerico(txtmes3Q1.Text))
        Total += Val(formatonumerico(txtmes3Q2.Text))
        Total += Val(formatonumerico(txtmes4Q1.Text))
        Total += Val(formatonumerico(txtmes4Q2.Text))
        Total += Val(formatonumerico(txtmesesRestantes.Text))

        Return Total
    End Function


End Class