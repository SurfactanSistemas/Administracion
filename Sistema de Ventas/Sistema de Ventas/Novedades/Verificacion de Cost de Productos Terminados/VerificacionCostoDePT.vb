Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class VerificacionCostoDePT : Implements IVerificaCostoPT

    Private Sub btn_ProcCostosFuturos_Click(sender As Object, e As EventArgs) Handles btn_ProcCostosFuturos.Click
        'Confirmo los cambios que no se hubiera guardado
        DGV_Articulos.CommitEdit(DataGridViewDataErrorContexts.Commit)


        Dim SQLCnslt As String = "DELETE ComparaCostos"

        ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

        Dim TablaLista As New DataTable

        With TablaLista.Columns
            .Add("Terminado")
        End With

        Dim TablaDGV_Calculos As New DataTable
        Dim ContadorTablaDGV_Calculos As Integer = 0
        With TablaDGV_Calculos.Columns
            .Add("MPrima")
            .Add("Descripcion")
            .Add("Costo1")
            .Add("Factor")
        End With


        Dim FilaTabla As Integer = 0

        For Each RowDGV As DataGridViewRow In DGV_Articulos.Rows
            Dim WMateria As String = UCase(RowDGV.Cells("MPrima").Value)
            If Trim(WMateria) <> "" Then

                SQLCnslt = "SELECT Terminado FROM Composicion WHERE Articulo1 = '" & WMateria & "'"
                Dim tablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tablaComposicion.Rows.Count > 0 Then
                    Dim Entra As String
                    For Each RowComposicion As DataRow In tablaComposicion.Rows
                        Entra = "S"

                        For Each RoWLista In TablaLista.Rows
                            If RoWLista.Item("Terminado") = RowComposicion.Item("Terminado") Then
                                Entra = "N"
                            End If
                        Next

                        If Entra = "S" Then
                            TablaLista.Rows.Add()
                            TablaLista.Rows(FilaTabla).Item("Terminado") = RowComposicion.Item("Terminado")
                            FilaTabla += 1
                        End If
                    Next


                End If
            End If
        Next


        Dim CantidadFilas As Integer = TablaLista.Rows.Count - 1
        'For Each RowLista As DataRow In TablaLista.Rows
        For i = 0 To CantidadFilas
            Dim WTerminado As String = TablaLista.Rows(i).Item("Terminado")
            If WTerminado <> "" Then
                SQLCnslt = "SELECT Terminado FROM Composicion WHERE Articulo2 = '" & WTerminado & "'"
                Dim TablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaComposicion.Rows.Count > 0 Then
                    For Each RowComposicion As DataRow In TablaComposicion.Rows
                        Dim Entra As String = "S"

                        If RowComposicion.Item("Terminado") = WTerminado Then
                            Entra = "N"
                        End If

                        If Entra = "S" Then
                            TablaLista.Rows.Add()
                            TablaLista.Rows(FilaTabla).Item("Terminado") = RowComposicion.Item("Terminado")
                            FilaTabla += 1
                            i += 1
                        End If

                    Next
                End If
            End If
        Next

        For Each DGV_Row As DataGridViewRow In DGV_Articulos.Rows
            Dim WMateria As String = UCase(DGV_Row.Cells("MPrima").Value)

            TablaDGV_Calculos.Rows.Add()

            TablaDGV_Calculos.Rows(ContadorTablaDGV_Calculos).Item("MPrima") = WMateria
            TablaDGV_Calculos.Rows(ContadorTablaDGV_Calculos).Item("Descripcion") = DGV_Row.Cells("Descripcion").Value
            TablaDGV_Calculos.Rows(ContadorTablaDGV_Calculos).Item("Costo1") = DGV_Row.Cells("Costo1").Value


            If Trim(WMateria) <> "" Then

                Dim WFactor As Double
                Dim WOrdenI As Double
                Dim WOrdenII As Double
                Dim WOrdenIII As Double
                Dim WPTAOrdenI As Double
                Dim WPTAOrdenII As Double
                Dim WPTAOrdenIII As Double
                Dim WFechaOrdenI As String = ""
                Dim WFechaOrdenII As String = ""
                Dim WFechaOrdenIII As String = ""
                Dim BaseConsultar As String

                SQLCnslt = "SELECT Factor ,OrdenI ,OrdenII ,OrdenIII ,PtaOrdenI ,PtaOrdenII ,PtaOrdenIII FROM Articulo " _
                          & "WHERE Codigo = '" & WMateria & "'"

                Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowArticulo IsNot Nothing Then
                    WFactor = IIf(IsDBNull(RowArticulo.Item("Factor")), "1", RowArticulo.Item("Factor"))
                    If WFactor = 0 Then
                        WFactor = 1
                    End If
                    WOrdenI = IIf(IsDBNull(RowArticulo.Item("OrdenI")), "0", RowArticulo.Item("OrdenI"))
                    WOrdenII = IIf(IsDBNull(RowArticulo.Item("OrdenII")), "0", RowArticulo.Item("OrdenII"))
                    WOrdenIII = IIf(IsDBNull(RowArticulo.Item("OrdenIII")), "0", RowArticulo.Item("OrdenIII"))
                    WPTAOrdenI = IIf(IsDBNull(RowArticulo.Item("PtaOrdenI")), "0", RowArticulo.Item("PtaOrdenI"))
                    WPTAOrdenII = IIf(IsDBNull(RowArticulo.Item("PtaOrdenII")), "0", RowArticulo.Item("PtaOrdenII"))
                    WPTAOrdenIII = IIf(IsDBNull(RowArticulo.Item("PtaOrdenIII")), "0", RowArticulo.Item("PtaOrdenIII"))


                    '   
                    '    VERIFICA COMPRAS IMPORTADAS
                    '   

                    If WPTAOrdenI <> 0 And WOrdenI <> 0 Then
                        Dim WBaseConsultar As String = RetornaBase(WPTAOrdenI)

                        SQLCnslt = "SELECT Fecha FROM Orden WHERE Orden = '" & WOrdenI & "' AND Articulo = '" & WMateria & "'"
                        Dim RowOrden As DataRow = GetSingle(SQLCnslt, WBaseConsultar)
                        If RowOrden IsNot Nothing Then
                            WFechaOrdenI = RowOrden.Item("Fecha")
                        End If

                        SQLCnslt = "SELECT Liberadaant, Liberada, Fecha FROM Laudo " _
                                    & "WHERE Orden = '" & WOrdenI & "' AND Articulo = '" & WMateria & "'"
                        Dim RowLaudo As DataRow = GetSingle(SQLCnslt, WBaseConsultar)

                        If RowLaudo IsNot Nothing Then
                            Dim WLiberadaAnt As Double = IIf(IsDBNull(RowLaudo.Item("Liberadaant")), "0", RowLaudo.Item("Liberadaant"))
                            Dim WLiberada As Double = IIf(IsDBNull(RowLaudo.Item("Liberada")), "0", RowLaudo.Item("Liberada"))
                            Dim WCalculo As Double = WLiberadaAnt + WLiberada
                            If WCalculo <> 0 Then
                                WFechaOrdenI = RowLaudo.Item("Fecha")
                            End If
                        End If
                    End If

                    '
                    '   VERIFICA COMPRAS LOCALES
                    '   
                    If WPTAOrdenII <> 0 And WOrdenII <> 0 Then
                        Dim WBaseConsultar As String = RetornaBase(WPTAOrdenII)

                        SQLCnslt = "SELECT Fecha FROM Orden WHERE Orden = '" & WOrdenII & "'"
                        Dim RowOrden As DataRow = GetSingle(SQLCnslt, WBaseConsultar)

                        If RowOrden IsNot Nothing Then
                            WFechaOrdenII = RowOrden.Item("Fecha")
                        End If

                        SQLCnslt = "SELECT Liberadaant, Liberada, Fecha FROM Laudo " _
                                  & "WHERE Orden = '" & WOrdenII & "' AND Articulo = '" & WMateria & "'"
                        Dim RowLaudo As DataRow = GetSingle(SQLCnslt, WBaseConsultar)

                        If RowLaudo IsNot Nothing Then
                            Dim WLiberadaAnt As Double = IIf(IsDBNull(RowLaudo.Item("Liberadaant")), "0", RowLaudo.Item("Liberadaant"))
                            Dim WLiberada As Double = IIf(IsDBNull(RowLaudo.Item("Liberada")), "0", RowLaudo.Item("Liberada"))
                            Dim WCalculo As Double = WLiberadaAnt + WLiberada
                            If WCalculo <> 0 Then
                                WFechaOrdenII = RowLaudo.Item("Fecha")
                            End If
                        End If
                    End If

                    '   
                    '    VERIFICA COMPRAS LOCALES 2
                    ' 
                    If WPTAOrdenIII <> 0 And WOrdenIII <> 0 Then
                        Dim WBaseConsultar As String = RetornaBase(WPTAOrdenIII)

                        SQLCnslt = "SELECT Fecha FROM Orden WHERE Orden = '" & WOrdenIII & "'"
                        Dim RowOrden As DataRow = GetSingle(SQLCnslt, WBaseConsultar)

                        If RowOrden IsNot Nothing Then
                            WFechaOrdenIII = RowOrden.Item("Fecha")
                        End If

                        SQLCnslt = "SELECT Liberadaant, Liberada, Fecha FROM Laudo " _
                                  & "WHERE Orden = '" & WOrdenIII & "' AND Articulo = '" & WMateria & "'"
                        Dim RowLaudo As DataRow = GetSingle(SQLCnslt, WBaseConsultar)

                        If RowLaudo IsNot Nothing Then
                            Dim WLiberadaAnt As Double = IIf(IsDBNull(RowLaudo.Item("Liberadaant")), "0", RowLaudo.Item("Liberadaant"))
                            Dim WLiberada As Double = IIf(IsDBNull(RowLaudo.Item("Liberada")), "0", RowLaudo.Item("Liberada"))
                            Dim WCalculo As Double = WLiberadaAnt + WLiberada
                            If WCalculo <> 0 Then
                                WFechaOrdenIII = RowLaudo.Item("Fecha")
                            End If
                        End If
                    End If


                    Dim WFechaOrdenadaI As String = ""
                    Dim WFechaOrdenadaII As String = ""
                    Dim WFechaOrdenadaIII As String = ""


                    If WFechaOrdenI <> "" Then
                        WFechaOrdenadaI = ordenaFecha(WFechaOrdenI)
                    End If
                    If WFechaOrdenII <> "" Then
                        WFechaOrdenadaII = ordenaFecha(WFechaOrdenII)
                    End If
                    If WFechaOrdenIII <> "" Then
                        WFechaOrdenadaIII = ordenaFecha(WFechaOrdenIII)
                    End If

                    If WFechaOrdenadaI <> "" And WFechaOrdenadaI > WFechaOrdenadaII And WFechaOrdenadaI > WFechaOrdenadaIII Then
                        ' DEJAMOS_TODO COMO ESTA YA QUE LA COMPRAIMPORTADA ES LA MAS RECIENTE
                    End If

                    If WFechaOrdenadaII <> "" And WFechaOrdenadaII > WFechaOrdenadaI And WFechaOrdenadaII > WFechaOrdenadaIII Then
                        ' PONEMOS EL FACTOR EN UNO PORQUE LA COMPRA LOCAL ES LA MAS RECIENTE
                        WFactor = 1
                    End If

                    If WFechaOrdenadaIII <> "" And WFechaOrdenadaIII > WFechaOrdenadaI And WFechaOrdenadaIII > WFechaOrdenadaII Then
                        ' PONEMOS EL FACTOR EN UNO PORQUE LA COMPRA LOCAL2 ES LA MAS RECIENTE
                        WFactor = 1
                    End If
                    'GUARDO EL VALOR EN MI TABLA EN MEMORIA
                    TablaDGV_Calculos.Rows(ContadorTablaDGV_Calculos).Item("Factor") = formatonumerico(WFactor, 2)
                    'Y EN UNA COLUMNA INVISIBLE EN EL DGV
                    DGV_Row.Cells("Factor").Value = formatonumerico(WFactor, 2)

                    ContadorTablaDGV_Calculos += 1

                End If
            End If
        Next


        For Each RowTerminado As DataRow In TablaLista.Rows
            Dim WProducto = RowTerminado.Item("Terminado")

            Dim WCostoI As String = formatonumerico(CalculaCostoI(WProducto), 2)

            Dim WCostoII As String = formatonumerico(CalculaCostoIII(WProducto, 1))

            Dim WCostoIII As String = formatonumerico(CalculaCostoIII(WProducto, 2))

            Dim WEntra = "N"



            If WCostoII <> 0 And WCostoII <> WCostoI Then
                WEntra = "S"
            End If

            If WCostoIII <> 0 And WCostoIII <> WCostoI Then
                WEntra = "S"
            End If

            If WEntra = "S" Then

                Dim WDescripcion As String = ""

                SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & WProducto & "'"
                Dim Row_Terminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If Row_Terminado IsNot Nothing Then

                    WDescripcion = Row_Terminado.Item("Descripcion")

                    SQLCnslt = "INSERT INTO ComparaCostos (Codigo ,Descripcion ,Precio1 , Precio2 , Precio3 ) " _
                             & "Values ('" & WProducto & "', '" & WDescripcion & "', '" & WCostoI & "', " _
                             & "'" & WCostoII & "', '" & WCostoIII & "')"

                    ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

                End If

            End If
        Next

        'Dim Formula As String = "{ComparaCostos.Codigo} > " & "" & "OR {ComparaCostos.Codigo} <= " & "ZZZZZZZZZ" & "'"
        With New VistaPrevia
            .Reporte = New ReporteVerificaCostoOtro()
            ' .Formula = Formula
            .Mostrar()
        End With


    End Sub



    Private Function RetornaBase(ByVal BaseNumerica As Integer) As String
        Dim Vector(12) As String
        Vector(1) = "SurfactanSa"
        Vector(2) = "PellitalSa"
        Vector(3) = "Surfactan_II"
        Vector(4) = "Pelitall_II"
        Vector(5) = "Surfactan_III"
        Vector(6) = "Surfactan_IV"
        Vector(7) = "Surfactan_V"
        Vector(8) = "Pellital_III"
        Vector(9) = "Pellital_V"
        Vector(10) = "Surfactan_VI"
        Vector(11) = "Surfactan_VII"

        Return Vector(BaseNumerica)
    End Function

    Private Function CalculaCostoI(ByVal Producto As String) As String

        Dim TablaTerminados As New DataTable
        With TablaTerminados.Columns
            .Add("Codigo")
            .Add("Vector")
        End With

        Dim TablaMP As New DataTable
        With TablaMP.Columns
            .Add("Codigo")
            .Add("Cantidad")
            .Add("Vector")
        End With

        Dim i As Integer = 0
        Dim Entra As String
        'AGREGO EL PRIMER CODIGO DEL PRODUCTO QUE VOY A CALCULAR
        TablaTerminados.Rows.Add(UCase(Producto), 1)

        Dim ContadorTabla As Integer = TablaTerminados.Rows.Count - 1
        'RECORRO LA TABLA DE TERMINADO DONDE RECIEN AGREGUE EL PRIMERO
        'For Each Row As DataRow In TablaTerminados.Rows
        For i = 0 To ContadorTabla
            If TablaTerminados.Rows(i).Item("Codigo") <> "" Then
                Entra = "S"
                'BUSCO LA COMPOSICION DEL PRODUCTO
                Dim SQLCnslt As String = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion " _
                                         & "WHERE Terminado = '" & TablaTerminados.Rows(i).Item("Codigo") & "'"
                Dim TablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaComposicion.Rows.Count > 0 Then
                    For Each RowComposicion As DataRow In TablaComposicion.Rows
                        Entra = "N"

                        Select Case RowComposicion.Item("Tipo")
                            Case "T"
                                'SI ES TERMINO LO AGREGO A LA TABLA DE TERMINADOS PARA BUSCAR SUS COMPONENTES
                                Dim Terminado As String = RowComposicion.Item("Articulo2")
                                Dim CalculoCantidad As String = formatonumerico(RowComposicion.Item("Cantidad") * Val(TablaTerminados.Rows(i).Item("Vector")))
                                'SE AGREGA A LA TABLA Y SE AUMENTA EL CONTADOR TOTAL DE LINEA
                                TablaTerminados.Rows.Add(Terminado, CalculoCantidad)
                                ContadorTabla += 1
                            Case "M"
                                'SI ES MATERIA PRIMA LO AGREGO A LA TABLA DE MATERIAS PRIMAS PARA CALCULAR SU PRECIO
                                With RowComposicion
                                    TablaMP.Rows.Add(.Item("Articulo1"), .Item("cantidad").ToString(), TablaTerminados.Rows(i).Item("Vector"))
                                End With
                        End Select

                    Next

                End If



            End If
            'SI NO SE ENCONTRO COMPOCICION Y NO ES PT SE LO TRATA COMO MATERIA PRIMA
            ' Y SE INCLUYE EN LA TABLA MP
            If Entra = "S" Then
                If Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 2) <> "PT" Then
                    'ACOMODO EL CODIGO PARA QUE SEA COMO LOS DE MP
                    Dim CodigoAux As String = Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 3) & Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 7)
                    TablaMP.Rows.Add(CodigoAux, "1", TablaTerminados.Rows(i).Item("Vector"))
                End If
            End If
        Next


        Dim Costo As Double = 0
        Dim WCosto As Double
        'CALCULO POR CADA MATERIA PRIMA CUANTO ME CUESTA PARA  HACER LA CANTIDAD DEL PRODUCTO INICIAL
        For Each row As DataRow In TablaMP.Rows
            Dim Cantidad As Double = Val(row.Item("Cantidad"))
            Dim Vector As Double = Val(row.Item("Vector"))

            Dim SQLCnslt As String = "SELECT Costo2 FROM Articulo WHERE Codigo = '" & row.Item("Codigo") & "'"
            Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowArticulo IsNot Nothing Then
                WCosto = Cantidad * Val(RowArticulo.Item("Costo2")) * Vector
                Costo = Costo + WCosto
            End If
        Next

        Dim CostoString As String = Costo

        Return CostoString.Replace(",", ".")

    End Function

    Private Function CalculaCostoII(ByVal Producto As String) As String

        Dim TablaTerminados As New DataTable
        With TablaTerminados.Columns
            .Add("Codigo")
            .Add("Vector")
        End With

        Dim TablaMP As New DataTable
        With TablaMP.Columns
            .Add("Codigo")
            .Add("Cantidad")
            .Add("Vector")
        End With

        Dim i As Integer = 0
        Dim Entra As String = "S"
        'AGREGO EL PRIMER CODIGO DEL PRODUCTO QUE VOY A CALCULAR
        TablaTerminados.Rows.Add(UCase(Producto), 1)


        Dim ContadorTabla As Integer = TablaTerminados.Rows.Count - 1
        'RECORRO LA TABLA DE TERMINADO DONDE RECIEN AGREGUE EL PRIMERO
        'For Each Row As DataRow In TablaTerminados.Rows
        For i = 0 To ContadorTabla
            If TablaTerminados.Rows(i).Item("Codigo") <> "" Then
                Entra = "S"
                'BUSCO LA COMPOSICION DEL PRODUCTO
                Dim SQLCnslt As String = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion " _
                                         & "WHERE Terminado = '" & TablaTerminados.Rows(i).Item("Codigo") & "'"
                Dim TablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaComposicion.Rows.Count > 0 Then
                    For Each RowComposicion As DataRow In TablaComposicion.Rows
                        Entra = "N"

                        Select Case RowComposicion.Item("Tipo")
                            Case "T"
                                'SI ES TERMINO LO AGREGO A LA TABLA DE TERMINADOS PARA BUSCAR SUS COMPONENTES
                                Dim Terminado As String = RowComposicion.Item("Articulo2")
                                Dim CalculoCantidad As String = formatonumerico(RowComposicion.Item("Cantidad") * Val(TablaTerminados.Rows(i).Item("Vector")))
                                'SE AGREGA A LA TABLA Y SE AUMENTA EL CONTADOR TOTAL DE LINEA
                                TablaTerminados.Rows.Add(Terminado, CalculoCantidad)
                                ContadorTabla += 1
                            Case "M"
                                'SI ES MATERIA PRIMA LO AGREGO A LA TABLA DE MATERIAS PRIMAS PARA CALCULAR SU PRECIO
                                With RowComposicion
                                    TablaMP.Rows.Add(.Item("Articulo1"), .Item("cantidad").ToString(), TablaTerminados.Rows(i).Item("Vector"))
                                End With
                        End Select

                    Next

                End If



            End If
            'SI NO SE ENCONTRO COMPOCICION Y NO ES PT SE LO TRATA COMO MATERIA PRIMA
            ' Y SE INCLUYE EN LA TABLA MP
            If Entra = "S" Then
                If Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 2) <> "PT" Then
                    'ACOMODO EL CODIGO PARA QUE SEA COMO LOS DE MP
                    Dim CodigoAux As String = Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 3) & Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 7)
                    TablaMP.Rows.Add(CodigoAux, "1", TablaTerminados.Rows(i).Item("Vector"))
                End If
            End If
        Next


        Dim Costo As Double = 0
        Dim WCostoAux As Double
        Dim WCosto As Double
        Dim Calculo As Double

        'CALCULO POR CADA MATERIA PRIMA CUANTO ME CUESTA PARA  HACER LA CANTIDAD DEL PRODUCTO INICIAL
        For Each row As DataRow In TablaMP.Rows
            Dim Articulo As String = row.Item("Codigo")
            Dim Cantidad As Double = Val(row.Item("Cantidad"))
            Dim Vector As Double = Val(row.Item("Vector"))

            Dim SQLCnslt As String = "SELECT Costo2, Costo2Anterior FROM Articulo WHERE Codigo = '" & row.Item("Codigo") & "'"
            Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowArticulo IsNot Nothing Then

                Dim Ingresa As String = "N"
                For Each rowDGV As DataGridViewRow In DGV_Articulos.Rows
                    If UCase(Articulo) = UCase(rowDGV.Cells("MPrima").Value) Then
                        Ingresa = "S"
                        Exit For
                    End If
                Next



                If Ingresa = "N" Then
                    WCostoAux = RowArticulo.Item("Costo2")
                Else
                    WCostoAux = IIf(IsDBNull(RowArticulo.Item("Costo2Anterior")), 0, RowArticulo.Item("Costo2Anterior"))
                    If WCostoAux = 0 Then
                        WCostoAux = RowArticulo.Item("Costo2")
                    End If
                End If

                WCosto = Cantidad * Val(WCostoAux) * Vector
                Costo = Costo + WCosto
            End If
        Next

        Dim CostoString As String = Costo

        Return CostoString.Replace(",", ".")

    End Function



    Private Function CalculaCostoIII(ByVal Producto As String, ByVal NumCondicion As Integer) As String

        Dim TablaTerminados As New DataTable
        With TablaTerminados.Columns
            .Add("Codigo")
            .Add("Vector")
        End With

        Dim TablaMP As New DataTable
        With TablaMP.Columns
            .Add("Codigo")
            .Add("Cantidad")
            .Add("Vector")
        End With

        Dim i As Integer = 0
        Dim Entra As String
        'AGREGO EL PRIMER CODIGO DEL PRODUCTO QUE VOY A CALCULAR
        TablaTerminados.Rows.Add(UCase(Producto), 1)


        Dim ContadorTabla As Integer = TablaTerminados.Rows.Count - 1
        'RECORRO LA TABLA DE TERMINADO DONDE RECIEN AGREGUE EL PRIMERO
        'For Each Row As DataRow In TablaTerminados.Rows
        For i = 0 To ContadorTabla
            If TablaTerminados.Rows(i).Item("Codigo") <> "" Then
                Entra = "S"
                'BUSCO LA COMPOSICION DEL PRODUCTO
                Dim SQLCnslt As String = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion " _
                                         & "WHERE Terminado = '" & TablaTerminados.Rows(i).Item("Codigo") & "'"
                Dim TablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaComposicion.Rows.Count > 0 Then
                    For Each RowComposicion As DataRow In TablaComposicion.Rows
                        Entra = "N"

                        Select Case RowComposicion.Item("Tipo")
                            Case "T"
                                'SI ES TERMINO LO AGREGO A LA TABLA DE TERMINADOS PARA BUSCAR SUS COMPONENTES
                                Dim Terminado As String = RowComposicion.Item("Articulo2")
                                Dim CalculoCantidad As String = formatonumerico(RowComposicion.Item("Cantidad") * Val(TablaTerminados.Rows(i).Item("Vector")))
                                'SE AGREGA A LA TABLA Y SE AUMENTA EL CONTADOR TOTAL DE LINEA
                                TablaTerminados.Rows.Add(Terminado, CalculoCantidad)
                                ContadorTabla += 1
                            Case "M"
                                'SI ES MATERIA PRIMA LO AGREGO A LA TABLA DE MATERIAS PRIMAS PARA CALCULAR SU PRECIO
                                With RowComposicion
                                    TablaMP.Rows.Add(.Item("Articulo1"), .Item("cantidad").ToString(), TablaTerminados.Rows(i).Item("Vector"))
                                End With
                        End Select

                    Next

                End If



            End If
            'SI NO SE ENCONTRO COMPOCICION Y NO ES PT SE LO TRATA COMO MATERIA PRIMA
            ' Y SE INCLUYE EN LA TABLA MP
            If Entra = "S" Then
                If Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 2) <> "PT" Then
                    'ACOMODO EL CODIGO PARA QUE SEA COMO LOS DE MP
                    Dim CodigoAux As String = Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 3) & Microsoft.VisualBasic.Left(TablaTerminados.Rows(i).Item("Codigo"), 7)
                    TablaMP.Rows.Add(CodigoAux, "1", TablaTerminados.Rows(i).Item("Vector"))
                End If
            End If
        Next


        Dim Costo As Double = 0
        Dim WCosto As Double
        Dim Calculo As Double
        'CALCULO POR CADA MATERIA PRIMA CUANTO ME CUESTA PARA  HACER LA CANTIDAD DEL PRODUCTO INICIAL
        For Each row As DataRow In TablaMP.Rows
            Dim Cantidad As Double = Val(row.Item("Cantidad"))
            Dim Vector As Double = Val(row.Item("Vector"))

            Dim SQLCnslt As String = "SELECT Costo2 FROM Articulo WHERE Codigo = '" & row.Item("Codigo") & "'"
            Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowArticulo IsNot Nothing Then
                WCosto = RowArticulo.Item("Costo2")
                For Each DGV_Row As DataGridViewRow In DGV_Articulos.Rows
                    If UCase(DGV_Row.Cells("MPrima").Value) = UCase(row.Item("Codigo")) Then
                        If NumCondicion = 1 Then
                            WCosto = Val(DGV_Row.Cells("Costo1").Value) * Val(DGV_Row.Cells("Factor").Value)
                        Else
                            WCosto = Val(DGV_Row.Cells("Costo2").Value) * Val(DGV_Row.Cells("Factor").Value)
                        End If
                    End If
                Next
                Calculo = Cantidad * WCosto * Vector
                Costo = Costo + Calculo
            End If
        Next

        Dim CostoString As String = Costo

        Return CostoString.Replace(",", ".")

    End Function






    Private Sub DGV_Articulos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Articulos.CellEndEdit
        Select Case e.ColumnIndex
            Case 0

                Dim Articulo As String = DGV_Articulos.CurrentRow.Cells("MPrima").Value
                If Articulo <> "" Then
                    If Articulo.Length = 10 Then
                        Dim SQLCnslt As String = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Articulo & "'"
                        Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                        If RowArticulo IsNot Nothing Then
                            Dim RowDGV As Integer = DGV_Articulos.CurrentRow.Index
                            DGV_Articulos.CurrentRow.Cells("Descripcion").Value = RowArticulo.Item("Descripcion")
                            DGV_Articulos.Rows(RowDGV).Cells("Costo1").Selected = True
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190 Or keycode = 109)
    End Function
    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If DGV_Articulos.Focused Or DGV_Articulos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            DGV_Articulos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = DGV_Articulos.CurrentCell.ColumnIndex
            Dim iRow = DGV_Articulos.CurrentCell.RowIndex

            ' Limitamos los caracteres permitidos para cada una de las columnas.
            Select Case iCol
                Case 2
                    If Not _EsDecimalOControl(keyData) Then
                        Return True
                    End If
                Case 3
                    If Not _EsDecimalOControl(keyData) Then
                        Return True
                    End If
            End Select



            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = DGV_Articulos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then

                        If Trim(valor.ToString.Length) = 10 Then

                            Dim Articulo As String = DGV_Articulos.CurrentRow.Cells("MPrima").Value
                            If Articulo <> "" Then
                                If Articulo.Length = 10 Then
                                    Dim SQLCnslt As String = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Articulo & "'"
                                    Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                                    If RowArticulo IsNot Nothing Then
                                        Dim RowDGV As Integer = DGV_Articulos.CurrentRow.Index
                                        DGV_Articulos.CurrentRow.Cells("Descripcion").Value = RowArticulo.Item("Descripcion")

                                        DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("Costo1") ' Nos desplazamos para que coloque el Costo 1
                                        Return True 'Devuelvo true para informar que el evento se cumplio
                                    Else
                                        MsgBox("No se encontro materia prima con ese codigo, verifiquelo", MsgBoxStyle.Exclamation)
                                        DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("MPrima") ' Nos mantememos en el campo codigo
                                        Return True 'Devuelvo true para informar que el evento se cumplio
                                    End If

                                End If
                            End If
                        Else
                            MsgBox("No se encontro materia prima con ese codigo, verifiquelo", MsgBoxStyle.Exclamation)
                            DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("MPrima") ' Nos mantememos en el campo codigo
                            Return True 'Devuelvo true para informar que el evento se cumplio
                        End If
                    End If

                    If iCol = 2 And iRow > -1 Then
                        If Val(valor) > 0 Then
                            DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("Costo2") ' Nos desplazamos para que coloque el Costo 2
                            Return True 'Devuelvo true para informar que el evento se cumplio

                        Else
                            MsgBox("Se debe ingresar un valor superior a 0", MsgBoxStyle.Exclamation)
                            DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("Costo1")
                            Return True 'Devuelvo true para informar que el evento se cumplio

                        End If
                    End If

                    If iCol = 3 Then ' Avanzamos a la fila siguiente.


                        If Val(valor) > 0 Then
                            ' Intentamos desplazarnos a la fila de abajo, sino existe la agregamos

                            Try
                                DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow + 1).Cells("MPrima")
                                Return True 'Devuelvo true para informar que el evento se cumplio

                            Catch ex As Exception
                                DGV_Articulos.Rows.Add()
                                DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow + 1).Cells("MPrima")
                                Return True 'Devuelvo true para informar que el evento se cumplio

                            End Try
                        Else
                            MsgBox("Se debe ingresar un valor superior a 0", MsgBoxStyle.Exclamation)
                            DGV_Articulos.CurrentCell = DGV_Articulos.Rows(iRow).Cells("Costo2")
                            Return True 'Devuelvo true para informar que el evento se cumplio

                        End If

                    End If





                End If
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        DGV_Articulos.Rows.Clear()
        DGV_Articulos.Focus()
        DGV_Articulos.CurrentCell = DGV_Articulos.Rows(0).Cells("MPrima")

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With Ayuda_MP
            .Show(Me)
        End With
    End Sub

    Public Sub AgregaMP(Codigo As String, Descripcion As String) Implements IVerificaCostoPT.AgregaMP
        DGV_Articulos.Rows.Add()
        For Each row As DataGridViewRow In DGV_Articulos.Rows
            If row.Cells("MPrima").Value = "" Then
                row.Cells("Mprima").Value = Codigo
                row.Cells("Descripcion").Value = Descripcion
                Exit For
            End If
        Next
    End Sub

    
    Private Sub btnProcesaCostoAnt_Click(sender As Object, e As EventArgs) Handles btnProcesaCostoAnt.Click

        Dim SQLCnslt As String = "UPDATE Terminado SET CodigoEmpresa = '" & 1 & "', " _
                                                     & "Precio1 = '" & 0 & "', " _
                                                     & "Precio2 = '" & 0 & "', " _
                                                     & "MarcaPrecio = '" & "" & "'"

        ExecuteNonQueries({SQLCnslt}, "SurfactanSa")



        Dim TablaLista As New DataTable

        With TablaLista.Columns
            .Add("Terminado")
        End With


        Dim FilaTabla As Integer = 0


        For Each RowDGV As DataGridViewRow In DGV_Articulos.Rows
            Dim WMateria As String = RowDGV.Cells("MPrima").Value
            If Trim(WMateria) <> "" Then

                SQLCnslt = "SELECT Terminado FROM Composicion WHERE Articulo1 = '" & WMateria & "'"
                Dim tablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tablaComposicion.Rows.Count > 0 Then
                    Dim Entra As String
                    For Each RowComposicion As DataRow In tablaComposicion.Rows
                        Entra = "S"

                        For Each RoWLista In TablaLista.Rows
                            If RoWLista.Item("Terminado") = RowComposicion.Item("Terminado") Then
                                Entra = "N"
                            End If
                        Next

                        If Entra = "S" Then
                            TablaLista.Rows.Add()
                            TablaLista.Rows(FilaTabla).Item("Terminado") = RowComposicion.Item("Terminado")
                            FilaTabla += 1
                        End If
                    Next


                End If
            End If
        Next

        Dim CantidadFilas As Integer = TablaLista.Rows.Count - 1

        ' For Each RowLista As DataRow In TablaLista.Rows
        For i = 0 To CantidadFilas
            Dim WTerminado As String = TablaLista.Rows(i).Item("Terminado")
            If WTerminado <> "" Then
                SQLCnslt = "SELECT Terminado FROM Composicion WHERE Articulo2 = '" & WTerminado & "'"
                Dim TablaComposicion As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaComposicion.Rows.Count > 0 Then
                    For Each RowComposicion As DataRow In TablaComposicion.Rows
                        Dim Entra As String = "S"

                        If RowComposicion.Item("Terminado") = WTerminado Then
                            Entra = "N"
                        End If

                        If Entra = "S" Then
                            TablaLista.Rows.Add()
                            TablaLista.Rows(FilaTabla).Item("Terminado") = RowComposicion.Item("Terminado")
                            FilaTabla += 1
                            CantidadFilas += 1
                        End If

                    Next
                End If
            End If
        Next

        For Each row As DataRow In TablaLista.Rows

            Dim Producto As String = row.Item("Terminado")

            Dim WCosto1 As String = CalculaCostoI(Producto)

            Dim WCosto2 As String = CalculaCostoII(Producto)

            SQLCnslt = "UPDATE TERMINADO SET Precio1 = '" & WCosto1 & "', " _
                                        & "  Precio2 = '" & WCosto2 & "', " _
                                        & "  MarcaPrecio = '" & "S" & "' " _
                                        & "  WHERE Codigo = '" & Producto & "'"

            ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

        Next


        Dim Formula As String = "{Terminado.Marcaprecio} = '" & "S" & "'"
        With New VistaPrevia
            .Reporte = New ReporteVerificaCosto()
            .Formula = Formula
            .Mostrar()
        End With

    End Sub








End Class