Imports CrystalDecisions.Shared

Public Class ArqueoDeCheques

    Dim RowIndex As Integer = 0
    Dim tablaChequesEliminados As New DataTable
    Dim ultimaFechaLeida As String = "  /  /    "
    Dim AqueBase As String = ""
    Dim CodigoUltimoCheque As String = ""





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
                    txtCodigoCheque.Text = txtCodigoCheque.Text.Replace(";", "C").Replace(":", "E")
                    If txtCodigoCheque.Text.Length = 31 Then
                        For Each row As DataGridViewRow In DGV_Cheques.Rows
                            If Trim(row.Cells("ClaveCheque").Value).ToUpper = txtCodigoCheque.Text.ToUpper Then
                                mastxtFecha.Text = row.Cells("Fecha").Value
                                txtNumeroCheque.Text = row.Cells("Numero").Value
                                txtImporte.Text = row.Cells("Importe").Value
                                txtBanco.Text = row.Cells("Banco").Value

                                'GUARDO LA FECHA PARA PODER VERIFICARLA DESPUES SI HACE UNA MODIFICACION
                                ultimaFechaLeida = row.Cells("Fecha").Value
                                'Y A QUE BASE TENGO Q MODIFICAR
                                AqueBase = row.Cells("Origen").Value
                                'Y EL CODIGO DEL CHEQUE
                                CodigoUltimoCheque = row.Cells("ClaveCheque").Value

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
                End If

                txtCodigoCheque.SelectAll()
            Case Keys.Escape
                txtCodigoCheque.Text = ""
        End Select

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
            'AGREGO A LA TABLA REGISTRO DE LOS CHEQUES QUE SACO DEL GRID
            tablaChequesEliminados.Rows.Add(.Cells("Fecha").Value, .Cells("Numero").Value, .Cells("Importe").Value, .Cells("Banco").Value, .Cells("ClaveCheque").Value)

            Dim index As Integer = DGV_Cheques.CurrentRow.Index

            DGV_Cheques.Rows.RemoveAt(index)

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
End Class