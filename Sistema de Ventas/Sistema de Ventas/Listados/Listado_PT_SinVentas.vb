Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_PT_SinVentas : Implements IConsulta_Terminado



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Porcentaje.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WDesdeFecha As String = ordenaFecha(txt_DesdeFecha.Text)

        Dim WHastaFecha As String = ordenaFecha(txt_HastaFecha.Text)


        txt_DesdeTer.Text = UCase(txt_DesdeTer.Text)
        txt_HastaTer.Text = UCase(txt_HastaTer.Text)

        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "DELETE Minimo"

        ExecuteNonQueries({SQLCnslt})
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

            SQLCnslt = "SELECT Entradas, Salidas, Codigo, Descripcion FROM Terminado " _
                       & "WHERE Codigo >= '" & txt_DesdeTer.Text & "' AND Codigo <= '" & txt_HastaTer.Text & "' " _
                       & "ORDER BY Codigo"

            Dim TablaTer As DataTable = GetAll(SQLCnslt, VectorEmpre(i))

            If TablaTer.Rows.Count > 0 Then

                For Each RowTer As DataRow In TablaTer.Rows

                    Dim ZStock As Double = RowTer.Item("Entradas") - RowTer.Item("Salidas")
                    Dim WStock As String = ZStock

                    If WStock > 0 Then
                        TablaCalculo.Rows.Add()
                        Dim codigo As String = UCase(RowTer.Item("Codigo"))
                        TablaCalculo.Rows(fila).Item("Codigo") = IIf(IsDBNull(codigo), "", codigo)
                        ' codigo = TablaCalculo.Rows(fila).Item("Codigo")
                        TablaCalculo.Rows(fila).Item("Descripcion") = RowTer.Item("Descripcion")
                        TablaCalculo.Rows(fila).Item("Stock") = WStock

                        fila += 1

                    End If

                Next
                
            End If



            For Each RowCalculo As DataRow In TablaCalculo.Rows

                Dim WTerminado As String = RowCalculo.Item("Codigo")
                Dim WArticulo As String = ""
                Dim WCodigo As String = WTerminado
                Dim WDescri1 As String = Trim(RowCalculo.Item("Descripcion")).PadRight(50, "")
                Dim WStock As String = RowCalculo.Item("Stock")
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

                    Dim WStock1 As String = RowMinimo.Item("Stock1")
                    Dim WStock2 As String = RowMinimo.Item("Stock2")
                    Dim WStock3 As String = RowMinimo.Item("Stock3")
                    Dim WStock4 As String = RowMinimo.Item("Stock4")
                    Dim WStock5 As String = RowMinimo.Item("Stock5")

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

                    'ExecuteNonQueries({SQLCnslt})
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

                    'ExecuteNonQueries({SQLCnslt})
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

                    Dim Stock1 As String = RowMin.Item("Stock1")
                    Dim Stock2 As String = RowMin.Item("Stock2")
                    Dim Stock3 As String = RowMin.Item("Stock3")
                    Dim Stock4 As String = RowMin.Item("Stock4")
                    Dim Stock5 As String = RowMin.Item("Stock5")

                    Dim ZZStock As Double = Val(Stock1) + Val(Stock2) + Val(Stock3) + Val(Stock4) + Val(Stock5)
                    Dim ZZPorce As Double = 0

                    If ZZStock <= 0 Then

                        SQLCnslt = "DELETE Minimo Where Codigo = '" & ZZCodigo & "'"

                        ListaSQLCnslt.Add(SQLCnslt)
                        ' ExecuteNonQueries({SQLCnslt}, Operador.Base)

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

                            ' ExecuteNonQueries({SQLCnslt}, Operador.Base)
                            ListaSQLCnslt.Add(SQLCnslt)
                        Else

                            SQLCnslt = "UPDATE Minimo SET  Minimo = '" & Str$(ZZPorce) & "', " _
                                        & "Venta1 = '" & Str$(ZZVenta) & "' " _
                                        & "WHERE Codigo = '" & ZZCodigo & "'"

                            'ExecuteNonQueries({SQLCnslt}, Operador.Base)
                            ListaSQLCnslt.Add(SQLCnslt)
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

    Private Sub Listado_PT_SinVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_DesdeTer.Text = "AA-00000-000"
        txt_HastaTer.Text = "ZZ-99999-999"
        txt_DesdeFecha.Text = "01/01/2020"
        txt_HastaFecha.Text = "01/12/2020"
        txt_Porcentaje.Text = 50
    End Sub

    Private Sub txt_DesdeTer_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeTer.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_DesdeTer.Text).Length = 12 Then
                    txt_HastaTer.Focus()
                    End If
            Case Keys.Escape
                txt_DesdeTer.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaTer_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaTer.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_HastaTer.Text).Length = 12 Then
                    txt_DesdeFecha.Focus()
                End If
            Case Keys.Escape
                txt_HastaTer.Text = ""
        End Select
    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha desde es invalida, verificar")
                    txt_DesdeFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) = "S" Then
                    txt_Porcentaje.Focus()
                Else
                    MsgBox("La fecha hasta es invalida, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    
    Private Sub txt_Porcentaje_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Porcentaje.KeyDown

        Select Case e.KeyData

            Case Keys.Escape
                txt_Porcentaje.Text = ""

        End Select
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click

        With Consulta_Terminado
            .Show(Me)
        End With

    End Sub

    Public Sub PasaCodigo(Codigo As String, Accion As String) Implements IConsulta_Terminado.PasaCodigo
        If Accion = "Ambos" Then
            txt_DesdeTer.Text = Codigo
            txt_HastaTer.Text = Codigo
        End If

        If Accion = "Desde" Then
            txt_DesdeTer.Text = Codigo
        End If

        If Accion = "Hasta" Then
            txt_HastaTer.Text = Codigo
        End If
    End Sub

    Private Sub Listado_PT_SinVentas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeTer.Focus()
    End Sub
End Class