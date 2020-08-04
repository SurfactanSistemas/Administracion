Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_DY_SinVentas

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        Dim WDesdeFecha As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WHastaFecha As String = ordenaFecha(txt_HastaFecha.Text)


        txt_DesdeMP.Text = UCase(txt_DesdeMP.Text)
        txt_HastaMP.Text = UCase(txt_HastaMP.Text)


        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "DELETE Minimo"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)
        'ListaSQLCnslt.Add(SQLCnslt)

        Dim VectorEmpre(7) As String

        VectorEmpre(0) = "SurfactanSa"
        VectorEmpre(1) = "Surfactan_II"
        VectorEmpre(2) = "Surfactan_III"
        VectorEmpre(3) = "Surfactan_IV"
        VectorEmpre(4) = "Surfactan_V"
        VectorEmpre(5) = "Surfactan_VI"
        VectorEmpre(6) = "Surfactan_VII"



        For i = 0 To 6

            Dim TablaCalculo As New DataTable

            With TablaCalculo.Columns
                .Add("Codigo")
                .Add("Descripcion")
                .Add("Stock")

            End With
            Dim fila As Double = 0

            SQLCnslt = "SELECT Entradas, Salidas, Codigo, Descripcion FROM Articulo  " _
                      & "WHERE Codigo >= '" & txt_DesdeMP.Text & "' AND Codigo <= '" & txt_HastaMP.Text & "' " _
                      & "ORDER BY Codigo"

            Dim TablaMP As DataTable = GetAll(SQLCnslt, VectorEmpre(i))

            If TablaMP.Rows.Count > 0 Then

                For Each RowMP As DataRow In TablaMP.Rows

                    Dim ZStock As Double = RowMP.Item("Entradas") - RowMP.Item("Salidas")
                    Dim WStock As Double = ZStock
                    ' Call redondeo(ZZStock)

                    If WStock > 0 Then
                        TablaCalculo.Rows.Add()
                        TablaCalculo.Rows(fila).Item("Codigo") = UCase(RowMP.Item("Codigo"))
                        TablaCalculo.Rows(fila).Item("Descripcion") = RowMP.Item("Descripcion")
                        TablaCalculo.Rows(fila).Item("Stock") = formatonumerico(WStock)

                        fila += 1

                    End If

                Next

            End If

           


            For Each RowCalculo As DataRow In TablaCalculo.Rows

                Dim WTerminado As String = RowCalculo.Item("Codigo")
                WTerminado = Microsoft.VisualBasic.Left$(WTerminado, 3) & "00" & Microsoft.VisualBasic.Right$(WTerminado, 7)

                Dim WArticulo As String = ""
                Dim WCodigo As String = WTerminado
                Dim WDescri1 As String = Trim(RowCalculo.Item("Descripcion")).PadRight(50, "")
                Dim WStock As String = formatonumerico(OrDefault(RowCalculo.Item("Stock"), ""))
                Dim WDescripcion As String = ""
                Dim WMInimo As String = ""

                For Saca1 = 1 To 50
                    Dim cara As String = Mid$(WDescri1, Saca1, 1)
                    Dim Ingre As String = "S"
                    If Mid$(WDescri1, Saca1, 1) <> "" Then
                        If Asc(Mid$(WDescri1, Saca1, 1)) = 39 Then
                            Ingre = "N"
                        End If
                    End If
                    If Ingre = "S" Then
                        WDescripcion = WDescripcion + cara
                    End If
                Next Saca1

                SQLCnslt = "SELECT Stock1, Stock2, Stock3, Stock4, Stock5 FROM Minimo WHERE Codigo = '" & WCodigo & "'"

                Dim RowMinimo As DataRow = GetSingle(SQLCnslt, VectorEmpre(i))
                If RowMinimo IsNot Nothing Then

                    Dim WStock1 As String = formatonumerico(RowMinimo.Item("Stock1"))
                    Dim WStock2 As String = formatonumerico(RowMinimo.Item("Stock2"))
                    Dim WStock3 As String = formatonumerico(RowMinimo.Item("Stock3"))
                    Dim WStock4 As String = formatonumerico(RowMinimo.Item("Stock4"))
                    Dim WStock5 As String = formatonumerico(RowMinimo.Item("Stock5"))

                    Select Case i
                        Case 0
                            WStock1 = Str$(Val(WStock1) + Val(WStock))
                        Case 1
                            WStock2 = Str$(Val(WStock2) + Val(WStock))
                        Case 2
                            WStock3 = Str$(Val(WStock3) + Val(WStock))
                        Case 3
                            WStock4 = Str$(Val(WStock4) + Val(WStock))
                        Case 4
                            WStock5 = Str$(Val(WStock5) + Val(WStock))
                        Case Else
                    End Select


                    'SQLCnslt = "UPDATE  " & VectorEmpre(i) & ".dbo.Minimo SET  " _
                    SQLCnslt = "UPDATE Minimo SET  " _
                                    & "Stock1 = '" & WStock1.Replace(",", ".") & "', " _
                                    & "Stock2 = '" & WStock2.Replace(",", ".") & "', " _
                                    & "Stock3 = '" & WStock3.Replace(",", ".") & "', " _
                                    & "Stock4 = '" & WStock4.Replace(",", ".") & "', " _
                                    & "Stock5 = '" & WStock5.Replace(",", ".") & "' " _
                                    & "WHERE Codigo = '" & WCodigo & "'"

                    ListaSQLCnslt.Add(SQLCnslt)

                Else

                    Dim WStock1 As String = "0"
                    Dim WStock2 As String = "0"
                    Dim WStock3 As String = "0"
                    Dim WStock4 As String = "0"
                    Dim WStock5 As String = "0"

                    Select Case i
                        Case 0
                            WStock1 = WStock
                        Case 1
                            WStock2 = WStock
                        Case 2
                            WStock3 = WStock
                        Case 3
                            WStock4 = WStock
                        Case 4
                            WStock5 = WStock
                        Case Else
                    End Select



                    'SQLCnslt = "INSERT INTO  " & VectorEmpre(i) & ".dbo.Minimo( " _
                    SQLCnslt = "INSERT INTO Minimo( " _
                            & "Codigo, " _
                            & "Articulo, " _
                            & "Terminado, " _
                            & "Descripcion, " _
                            & "Stock1, " _
                            & "Stock2, " _
                            & "Stock3, " _
                            & "Stock4, " _
                            & "Stock5, " _
                            & "Minimo) " _
                            & "VALUES( " _
                            & "'" & WCodigo & "', " _
                            & "'" & WArticulo & "', " _
                            & "'" & WTerminado & "', " _
                            & "'" & WDescripcion & "', " _
                            & "'" & WStock1.Replace(",", ".") & "', " _
                            & "'" & WStock2.Replace(",", ".") & "', " _
                            & "'" & WStock3.Replace(",", ".") & "', " _
                            & "'" & WStock4.Replace(",", ".") & "', " _
                            & "'" & WStock5.Replace(",", ".") & "', " _
                            & "'" & WMInimo & "')"

                    ListaSQLCnslt.Add(SQLCnslt)

                End If
            Next

        Next


        ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)


        ListaSQLCnslt.Clear()

        Dim listaCodigos As New List(Of String)


        Dim Suma As Integer = 0

        SQLCnslt = "Select Codigo FROM Minimo"
        Dim TablaMin As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaMin.Rows.Count > 0 Then

            For Each RowMin As DataRow In TablaMin.Rows
                listaCodigos.Add(RowMin.Item("Codigo"))
            Next

        End If

        For i = 0 To listaCodigos.Count - 1

            Dim ZZCodigo As String = listaCodigos(i)
            Dim ZZVenta As Double = 0

            SQLCnslt = "SELECT Cantidad, Tipo FROM Estadistica WHERE Articulo = '" & ZZCodigo & "' " _
                         & "AND OrdFecha >= '" & WDesdeFecha & "' " _
                         & "AND OrdFecha <= '" & WHastaFecha & "'"

            Dim TablaEstadistica As DataTable = GetAll(SQLCnslt, Operador.Base)

            If TablaEstadistica.Rows.Count > 0 Then

                For Each RowEsta As DataRow In TablaEstadistica.Rows

                    Dim WCantidad As Double = RowEsta.Item("Cantidad")

                    If RowEsta.Item("Tipo") = 2 Then
                        WCantidad = WCantidad * -1
                    End If

                    ZZVenta = ZZVenta + WCantidad

                Next


            End If

            SQLCnslt = "SELECT Stock1, Stock2, Stock3, Stock4, Stock5 " _
                       & "FROM Minimo WHERE Codigo = '" & ZZCodigo & "'"

            Dim TablaMinimo As DataTable = GetAll(SQLCnslt, Operador.Base)

            If TablaMinimo.Rows.Count > 0 Then

                For Each RowMin As DataRow In TablaMinimo.Rows

                    Dim Stock1 As Double = RowMin.Item("Stock1")
                    Dim Stock2 As Double = RowMin.Item("Stock2")
                    Dim Stock3 As Double = RowMin.Item("Stock3")
                    Dim Stock4 As Double = RowMin.Item("Stock4")
                    Dim Stock5 As Double = RowMin.Item("Stock5")

                    Dim ZZStock As Double = Val(Stock1) + Val(Stock2) + Val(Stock3) + Val(Stock4) + Val(Stock5)
                    Dim ZZPorce As Double = 0

                    If ZZStock <= 0 Then

                        SQLCnslt = "DELETE Minimo Where Codigo = '" & ZZCodigo & "'"

                        ListaSQLCnslt.Add(SQLCnslt)
                        'ExecuteNonQueries({SQLCnslt}, Operador.Base)

                    Else

                        If Val(ZZVenta) <> 0 Then
                            If ZZVenta < 0 Then
                                ZZVenta = ZZVenta * -1
                            End If
                            ZZPorce = (ZZVenta / ZZStock) * 100
                            ' Call redondeo(ZZPorce)
                        End If

                        If ZZPorce > Val(txt_Porcentaje.Text) Then

                            SQLCnslt = "DELETE Minimo Where Codigo = '" & ZZCodigo & "'"

                            ListaSQLCnslt.Add(SQLCnslt)
                            'ExecuteNonQueries({SQLCnslt}, Operador.Base)

                        Else

                            SQLCnslt = "UPDATE Minimo SET  Minimo = '" & Str$(ZZPorce) & "', " _
                                        & "Venta1 = '" & Str$(ZZVenta) & "' " _
                                        & "WHERE Codigo = '" & ZZCodigo & "'"

                            ListaSQLCnslt.Add(SQLCnslt)
                            'ExecuteNonQueries({SQLCnslt}, Operador.Base)

                        End If

                    End If

                Next

            End If

        Next

          ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)

        With New VistaPrevia
            .Reporte = New Reporte_PT_SinVentas()
            .Reporte.SetParameterValue(0, Operador.Base)

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click

        Close()

    End Sub

    Private Sub Listado_DY_SinVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_DesdeMP.Text = "DY-000-000"
        txt_HastaMP.Text = "DY-999-999"
        txt_DesdeFecha.Text = "01/01/2020"
        txt_HastaFecha.Text = "01/12/2020"
        txt_Porcentaje.Text = 50
    End Sub
End Class