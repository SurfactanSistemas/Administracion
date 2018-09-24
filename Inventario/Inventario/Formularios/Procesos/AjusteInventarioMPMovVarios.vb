Imports Inventario.Clases
Imports System.Data.SqlClient

Public Class AjusteInventarioMPMovVarios

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        If MsgBox("¿Está seguro de querer realizar el Proceso?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        Dim WEntradas, WSalidas As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        WEntradas = WSalidas = 0.0

        Dim WArticulos As DataTable '= Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion  FROM Articulo WHERE Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)
        WArticulos = GetAll("SELECT Distinct i.Articulo, i.Lote, ISNULL(a.Descripcion, '') Descripcion FROM Inventario i INNER JOIN Articulo a ON i.Articulo = a.Codigo WHERE i.Tipo = 'M' order by i.Articulo", Conexion.EmpresaDeTrabajo)

        For Each WArticulo As DataRow In WArticulos.Rows
            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            Dim WLaudos As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Liberada), 0) As Entrada FROM Laudo WHERE Saldo <> 0 And Marca <> 'X' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Laudo = '" & WArticulo.Item("Lote") & "'", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WLaudos) Then
                WEntradas += WLaudos.Item("Entrada")
            End If

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = Query.GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' AND (Marca <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218) AND (Lote1 = '" & WArticulo.Item("Lote") & "' Or Lote2 = '" & WArticulo.Item("Lote") & "' OR Lote3 = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WHojas) Then
                For Each row As DataRow In WHojas.Rows
                    With row
                        For i = 1 To 3
                            Dim WLote As Integer = OrDefault(.Item("Lote" & i), 0)

                            If WLote = 0 Then Continue For

                            If Val(WArticulo.Item("Lote")) = WLote Then
                                WSalidas += OrDefault(.Item("Canti" & i), 0)
                            End If
                        Next
                    End With
                Next
            End If

            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = Query.GetAll("SELECT Articulo, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Articulo, Movi ", Conexion.EmpresaDeTrabajo)

            For Each WMovVario As DataRow In WMovVarios.Rows

                With WMovVario

                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If

                End With

            Next

            '
            ' Calculamos las Entradas y Salidas por Guías.
            '
            Dim WGuias As DataTable = Query.GetAll("SELECT Articulo, ISNULL(Cantidad, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And (Lote = '" & WArticulo.Item("Lote") & "' Or Partida = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

            For Each WGuia As DataRow In WGuias.Rows

                With WGuia
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With

            Next

            '
            ' Calculamos Entradas y Salidas por Movimientos de Laboratorio.
            '
            Dim WMovsLaboratorio As DataTable = Query.GetAll("SELECT Articulo, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Articulo, Movi", Conexion.EmpresaDeTrabajo)

            For Each WMovLab As DataRow In WMovsLaboratorio.Rows
                With WMovLab
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With
            Next

            '
            ' Grabamos la fila para pasar al Reporte.
            '
            Dim r As DataRow = WTabla.NewRow

            With r
                .Item("Articulo") = WArticulo.Item("Articulo")
                .Item("Lote") = WArticulo.Item("Lote")
                .Item("Terminado") = ""
                .Item("Descripcion") = WArticulo.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = 0
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

        Next

        For Each row As DataRow In WTabla.Rows

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Articulo = '" & row.Item("Articulo") & "' And Lote = '" & row.Item("Lote") & "' GROUP BY Articulo, Lote", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                row.Item("Inventario") = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

        Next

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            For Each row As DataRow In WTabla.Rows
                With row

                    Dim WArticulo As String = OrDefault(.Item("Articulo"), "")
                    Dim WTerminado As String = "  -     -   "
                    Dim WLote As String = OrDefault(.Item("Lote"), 0)
                    Dim WStock As Double = OrDefault(.Item("Stock"), 0)
                    Dim WInventario As Double = OrDefault(.Item("Inventario"), 0)
                    Dim WDiff As Double = 0
                    Dim WCantidad As String = 0
                    Dim WCodMov As Integer = 0
                    Dim WMovi As String = ""
                    Dim WTipoMovi As Integer = 0
                    Dim WObservaciones As String = "AJUSTE POR DIFERENCIA EN INVENTARIO"
                    Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")
                    Dim WMarca As String = ""
                    Dim WTipo As String = "M"
                    Dim WFecha As String = Date.Now.ToString("dd/MM/yyyy")
                    Dim WFechaOrd As String = Helper.ordenaFecha(WFecha)

                    '
                    ' Determino el Proximo numero de Movimiento.
                    '
                    cm.CommandText = "SELECT ISNULL(Max(Codigo), 0) Ultimo FROM MovVar"
                    Using dr As SqlDataReader = cm.ExecuteReader
                        If dr.HasRows Then
                            dr.Read()
                            WCodMov = dr.Item("Ultimo")
                            WCodMov += 1
                        End If
                    End Using

                    '
                    ' Determino si es una entrada o una salida
                    '
                    WDiff = WStock - WInventario

                    If WDiff = 0 Then Continue For

                    If WDiff > 0 And WStock <> 0 Then
                        WMovi = "S"
                        WTipoMovi = 1
                    Else
                        WMovi = "E"
                        WTipoMovi = 0
                    End If

                    WCantidad = Helper.formatonumerico(Math.Abs(WDiff))

                    Dim WClave = WCodMov.ToString.PadLeft(6, "0") & "01"

                    cm.CommandText = String.Format("INSERT INTO MovVar (Clave, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, TipoMov, Observaciones, WDate, Marca, Lote) " &
                                                   " VALUES " &
                                                   " ('{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                                                   WClave, WCodMov, 1, WFecha, "M", WArticulo, WTerminado, WCantidad, WFechaOrd, WMovi, WTipoMovi, WObservaciones, WDate, WMarca, WLote)

                    cm.ExecuteNonQuery()

                End With
            Next

            trans.Commit()

            MsgBox("Listo!", MsgBoxStyle.Information)
        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        Finally

            cn.Close()

        End Try


    End Sub

    Private Sub btnProcesarPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPT.Click
        Dim WEntradas, WSalidas As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        WEntradas = WSalidas = 0.0

        Dim WArticulos As DataTable '= Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion  FROM Articulo WHERE Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)
        WArticulos = GetAll("SELECT Distinct i.Terminado, i.Lote, ISNULL(t.Descripcion, '') Descripcion FROM Inventario i INNER JOIN Terminado t ON i.Terminado = t.Codigo WHERE i.Tipo = 'T' order by i.Terminado", Conexion.EmpresaDeTrabajo)

        For Each WArticulo As DataRow In WArticulos.Rows
            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            'Dim WLaudos As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Liberada), 0) As Entrada FROM Laudo WHERE Saldo <> 0 And Marca <> 'X' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Laudo = '" & WArticulo.Item("Lote") & "'", Conexion.EmpresaDeTrabajo)

            'If Not IsNothing(WLaudos) Then
            '    WEntradas += WLaudos.Item("Entrada")
            'End If

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = Query.GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' AND (Marca <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218) AND (Lote1 = '" & WArticulo.Item("Lote") & "' Or Lote2 = '" & WArticulo.Item("Lote") & "' OR Lote3 = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WHojas) Then
                For Each row As DataRow In WHojas.Rows
                    With row
                        For i = 1 To 3
                            Dim WLote As Integer = OrDefault(.Item("Lote" & i), 0)

                            If WLote = 0 Then Continue For

                            If Val(WArticulo.Item("Lote")) = WLote Then
                                WSalidas += OrDefault(.Item("Canti" & i), 0)
                            End If
                        Next
                    End With
                Next
            End If

            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = Query.GetAll("SELECT Terminado, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Terminado, Movi ", Conexion.EmpresaDeTrabajo)

            For Each WMovVario As DataRow In WMovVarios.Rows

                With WMovVario

                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If

                End With

            Next

            '
            ' Calculamos las Entradas y Salidas por Guías.
            '
            Dim WGuias As DataTable = Query.GetAll("SELECT Terminado, ISNULL(Cantidad, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And (Lote = '" & WArticulo.Item("Lote") & "' Or Partida = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

            For Each WGuia As DataRow In WGuias.Rows

                With WGuia
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With

            Next

            '
            ' Calculamos Entradas y Salidas por Movimientos de Laboratorio.
            '
            Dim WMovsLaboratorio As DataTable = Query.GetAll("SELECT Terminado, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Terminado, Movi", Conexion.EmpresaDeTrabajo)

            For Each WMovLab As DataRow In WMovsLaboratorio.Rows
                With WMovLab
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With
            Next

            '
            ' Grabamos la fila para pasar al Reporte.
            '
            Dim r As DataRow = WTabla.NewRow

            With r
                .Item("Articulo") = ""
                .Item("Lote") = WArticulo.Item("Lote")
                .Item("Terminado") = WArticulo.Item("Terminado")
                .Item("Descripcion") = WArticulo.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = 0
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

        Next

        For Each row As DataRow In WTabla.Rows

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Terminado = '" & row.Item("Terminado") & "' And Lote = '" & row.Item("Lote") & "' GROUP BY Terminado, Lote", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                row.Item("Inventario") = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

        Next

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            For Each row As DataRow In WTabla.Rows
                With row

                    Dim WArticulo As String = "  -   -   "
                    Dim WTerminado As String = OrDefault(.Item("Terminado"), "")
                    Dim WLote As String = OrDefault(.Item("Lote"), 0)
                    Dim WStock As Double = OrDefault(.Item("Stock"), 0)
                    Dim WInventario As Double = OrDefault(.Item("Inventario"), 0)
                    Dim WDiff As Double = 0
                    Dim WCantidad As String = 0
                    Dim WCodMov As Integer = 0
                    Dim WMovi As String = ""
                    Dim WTipoMovi As Integer = 0
                    Dim WObservaciones As String = "AJUSTE POR DIFERENCIA EN INVENTARIO"
                    Dim WDate As String = Date.Now.ToString("MM-dd-yyyy")
                    Dim WMarca As String = ""
                    Dim WTipo As String = "M"
                    Dim WFecha As String = Date.Now.ToString("dd/MM/yyyy")
                    Dim WFechaOrd As String = Helper.ordenaFecha(WFecha)

                    '
                    ' Determino el Proximo numero de Movimiento.
                    '
                    cm.CommandText = "SELECT ISNULL(Max(Codigo), 0) Ultimo FROM MovVar"
                    Using dr As SqlDataReader = cm.ExecuteReader
                        If dr.HasRows Then
                            dr.Read()
                            WCodMov = dr.Item("Ultimo")
                            WCodMov += 1
                        End If
                    End Using

                    '
                    ' Determino si es una entrada o una salida
                    '
                    WDiff = WStock - WInventario

                    If WDiff = 0 Then Continue For

                    If WDiff > 0 And WStock <> 0 Then
                        WMovi = "S"
                        WTipoMovi = 1
                    Else
                        WMovi = "E"
                        WTipoMovi = 0
                    End If

                    WCantidad = Helper.formatonumerico(Math.Abs(WDiff))

                    Dim WClave = WCodMov.ToString.PadLeft(6, "0") & "01"

                    cm.CommandText = String.Format("INSERT INTO MovVar (Clave, Codigo, Renglon, Fecha, Tipo, Articulo, Terminado, Cantidad, FechaOrd, Movi, TipoMov, Observaciones, WDate, Marca, Lote) " &
                                                   " VALUES " &
                                                   " ('{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                                                   WClave, WCodMov, 1, WFecha, "T", WArticulo, WTerminado, WCantidad, WFechaOrd, WMovi, WTipoMovi, WObservaciones, WDate, WMarca, WLote)

                    cm.ExecuteNonQuery()

                End With
            Next

            trans.Commit()

            MsgBox("Listo!", MsgBoxStyle.Information)
        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        Finally

            cn.Close()

        End Try


    End Sub
End Class