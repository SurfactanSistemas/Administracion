Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Ventas_FueraDeFecha
    Dim listaFeriados As New List(Of String)
    Private TotalFeriado As Integer


    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)

        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)

        Dim TablaVentasFueraFecha As DataTable = New DBAuxi.TablaVentasFueraFechaDataTable()

        Dim listaFilasABorrar As New List(Of Integer)


        Dim Fila As Integer = 0
        Dim SQLCnslt As String = "SELECT Tipo, Numero, Articulo, Cantidad, Cliente, Costo2, Pedido, Fecha, " _
                                 & " Ordfecha, Clave FROM Estadistica " _
                                 & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' " _
                                 & "AND Pedido <> '0' AND Articulo <> 'PT-99999-999' " _
                                 & "ORDER BY OrdFecha"

        Dim TablaEstadistica As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaEstadistica.Rows.Count > 0 Then

            For Each rowEsta As DataRow In TablaEstadistica.Rows

                Dim WTipo As String = rowEsta.Item("Tipo")
                Dim WNumero As String = rowEsta.Item("Numero")
                Dim WArticulo As String = rowEsta.Item("Articulo")
                Dim WCantidad As String = rowEsta.Item("Cantidad")
                Dim WCliente As String = rowEsta.Item("Cliente")
                Dim WCosto2 As String = rowEsta.Item("Costo2")
                Dim WPedido As String = rowEsta.Item("Pedido")
                Dim WFecha As String = rowEsta.Item("Fecha")
                Dim WOrdFecha As String = rowEsta.Item("OrdFecha")
                Dim WClave As String = rowEsta.Item("Clave")

                TablaVentasFueraFecha.Rows.Add()

                TablaVentasFueraFecha.Rows(Fila).Item("Tipo") = WTipo
                TablaVentasFueraFecha.Rows(Fila).Item("Numero") = WNumero
                TablaVentasFueraFecha.Rows(Fila).Item("Articulo") = WArticulo
                TablaVentasFueraFecha.Rows(Fila).Item("Cantidad") = WCantidad
                TablaVentasFueraFecha.Rows(Fila).Item("Cliente") = WCliente
                TablaVentasFueraFecha.Rows(Fila).Item("Costo2") = WCosto2
                TablaVentasFueraFecha.Rows(Fila).Item("Pedido") = WPedido
                TablaVentasFueraFecha.Rows(Fila).Item("Fecha") = WFecha
                TablaVentasFueraFecha.Rows(Fila).Item("OrdFecha") = WOrdFecha
                TablaVentasFueraFecha.Rows(Fila).Item("Clave") = WClave

                Fila += 1

            Next

        End If

        Fila = 0

        For Each rowRep As DataRow In TablaVentasFueraFecha.Rows
         

            Dim WCliente As String = rowRep.Item("Cliente")
            Dim WPedido As String = rowRep.Item("Pedido")
            Dim WOrdFecha As String = rowRep.Item("OrdFecha")
            Dim WDescriCliente As String = ""

            SQLCnslt = "SELECT Razon FROM Cliente WHERE Cliente = '" & WCliente & "'"
            Dim RowCliente As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowCliente IsNot Nothing Then
                WDescriCliente = RowCliente("Razon")

            End If

            rowRep.Item("DescriCliente") = WDescriCliente

            Dim WFecEntrega As String = ""
            Dim WFecEntrega1 As String = ""


            SQLCnslt = "SELECT FecEntrega FROM Pedido WHERE Pedido = '" & WPedido & "' ORDER BY Clave"

            Dim rowPedido As DataRow = GetSingle(SQLCnslt, Operador.Base)

            If rowPedido IsNot Nothing Then
                WFecEntrega = ordenaFecha(rowPedido.Item("FecEntrega"))
                WFecEntrega1 = rowPedido.Item("FecEntrega")
            End If

            If WOrdFecha <= WFecEntrega Then
                listaFilasABorrar.Add(Fila)
            Else
                rowRep.Item("FecEntrega") = WFecEntrega1

                Dim WDias As Integer = 0

                Dim AUXTesteo As String = rowRep.Item("Numero")

                Dim WFechaHasta As String = rowRep.Item("Fecha")
                Dim WFechaDesde As String = rowRep.Item("FecEntrega")

                Dim Feriado As String



                If WFechaDesde <> "" Then

                    Do

                        Feriado = "N"
                        For Ciclo = 0 To TotalFeriado - 1
                            If listaFeriados.Item(Ciclo) = WFechaDesde Then
                                Feriado = "S"
                                Exit For
                            End If
                        Next Ciclo

                        REM 1 - DOMINGO
                        REM 2 - LUNES
                        REM 3 - MARTES
                        REM 4 - MIERCOLES
                        REM 5 - JUEVES
                        REM 6 - VIERNES
                        REM 7 - SABADO
                        Dim XFec1 As String = WFechaDesde
                        Dim DXfec1 As Date = CType(XFec1, Date)
                        Dim BDia As Integer = DXfec1.DayOfWeek()
                        If BDia = 1 Or BDia = 7 Then
                            Feriado = "S"
                        End If

                        If Feriado = "N" Then
                            WDias = WDias + 1
                        End If
                        Dim SumaDia As Integer = 2

                        WFechaDesde = Calcula_vencimiento(XFec1, SumaDia)

                        If WFechaDesde = WFechaHasta Then
                            Exit Do
                        End If

                    Loop

                    rowRep.Item("Costo2") = WDias

                End If

            End If

        Next


        For i = listaFilasABorrar.Count To 0
            TablaVentasFueraFecha.Rows.RemoveAt(i)
        Next


        Dim WTitulo As String = "Entre el " & txt_DesdeFecha.Text & " hasta el " & txt_HastaFecha.Text

        Dim WFormula As String = "{TablaVentasFueraFecha.FecEntrega} <> '' AND {TablaVentasFueraFecha.Costo2} > '0'"

        With New VistaPrevia
            .Reporte = New ReporteVEntas_FueraDeFecha()
            .Reporte.SetDataSource(TablaVentasFueraFecha)
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With


    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha desde es infalida, verificar")
                    txt_DesdeFecha.SelectAll()
                    txt_DesdeFecha.Focus()
                End If

            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) = "S" Then

                Else
                    MsgBox("La fecha hasta es infalida, verificar")
                    txt_HastaFecha.SelectAll()
                    txt_HastaFecha.Focus()
                End If

            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
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

   
    Private Sub Listado_Ventas_FueraDeFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        TotalFeriado = 0

        Dim SQLCnslt As String = "SELECT Fecha FROM Feriado ORDER BY Codigo"
        Dim tabla As DataTable = GetAll(SQLCnslt, Operador.Base)
        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                listaFeriados.Add(row.Item("Fecha"))
                TotalFeriado = TotalFeriado + 1

            Next

        End If
    End Sub
    Private Sub Listado_IvaVentas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeFecha.Focus()
    End Sub
End Class