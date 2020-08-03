Imports System.Net.Configuration
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Ventana_Boton_Autorizo
    Dim ClavePedido As String
    Dim CAMBIOAutorizado As String
    Dim CodigoPedido As String
    Dim CodigoCliente As String
    Dim RazonCliente As String
    Sub New(ByVal Tipo As String, ByVal Clave As String, ByVal Pedido As String, Optional ByVal Cliente As String = "", Optional ByVal Razon As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CAMBIOAutorizado = "N"
        CodigoPedido = Pedido
        CodigoCliente = Cliente
        RazonCliente = Razon
        ClavePedido = Clave

        If Tipo = "OTRO" Then

            Dim WPedido As String = Pedido

            Dim WTipoPedido As Integer
            Dim WTipoPed As Integer
            Dim WfechaEntrega As String
            Dim WFechaPedido As String


            Dim WParcial As String = "N"

            Dim SQLCnslt As String = "SELECT Facturado FROM Pedido WHERE Pedido = '" & WPedido & "' Order by Clave"

            Dim TablaPedido As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If TablaPedido.Rows.Count > 0 Then
                For Each Row As DataRow In TablaPedido.Rows
                    If Row.Item("Facturado") <> 0 Then
                        WParcial = "S"
                    End If
                Next
            End If

            SQLCnslt = "SELECT TipoPedido, TipoPed, FecEntrega, Fecha FROM Pedido " _
                                     & "WHERE Pedido = '" & WPedido & "'"
            Dim RowPedido As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowPedido IsNot Nothing Then
                WTipoPedido = RowPedido.Item("TipoPedido")
                WTipoPed = RowPedido.Item("Tipoped")
                WfechaEntrega = RowPedido.Item("FecEntrega")
                WFechaPedido = RowPedido.Item("Fecha")



                Dim WFechaAutoriza As String = Date.Today.ToString("MM/dd/yyyy")

                If WFechaPedido <> WFechaAutoriza And WParcial = "N" Then
                    txt_VtoOriginal.Text = WfechaEntrega
                    txt_VtoNuevo.Text = WfechaEntrega
                    txt_TipoPedido.Text = DevuelveTipoPedido(WTipoPed)

                    If WTipoPed = 0 Then
                        Dim FechaEntrega As String = Calcula_FecEntrega()
                        FechaEntrega = Calcula_Feriado(FechaEntrega)
                        txt_VtoNuevo.Text = FechaEntrega
                    Else
                        Dim FechaActual As String = Date.Today.ToString("MM/dd/yyyy")
                        Dim FechaActualOrdenada As String = Date.Today.ToString("yyyy/MM/dd")
                        Dim FechaOrdenadaEntrega As String = ordenaFecha(txt_VtoNuevo.Text)

                        If FechaOrdenadaEntrega < FechaActualOrdenada Then
                            txt_VtoNuevo.Text = FechaActual
                        End If
                    End If
                    cbx_Concepto.SelectedIndex = 13
                    txt_Observaciones.Text = ""
                    txt_VtoNuevo.Focus()
                Else
                    CAMBIOAutorizado = "S"

                End If



            End If
            Pnl_Devol.Visible = False
        Else
            Pnl_Devol.Visible = True
        End If
    End Sub

    Private Function DevuelveTipoPedido(ByVal Posicion As Integer) As String
        Dim VectorTipos(6) As String
        VectorTipos(0) = "Normal"
        VectorTipos(1) = "a Fecha"
        VectorTipos(2) = "Fecha Limite"
        VectorTipos(3) = "Urgente"
        VectorTipos(4) = "Retira Cliente"
        VectorTipos(5) = "Muestra"
        VectorTipos(6) = "Muestra Retira"

        Return VectorTipos(Posicion)
    End Function
    Private Function Calcula_FecEntrega() As String

        REM 0 - DOMINGO
        REM 1 - LUNES
        REM 2 - MARTES
        REM 3 - MIERCOLES
        REM 4 - JUEVES
        REM 5 - VIERNES
        REM 6 - SABADO
        Dim WSumaDia As Integer
        Dim WFecha1 As String = Date.Today.ToString("MM/dd/yyyy")
        'Dim WstrDia As String = Format$(WFecha1, "dddd")
        Dim WBDia As Integer = Date.Today.DayOfWeek
        Select Case WBDia
            Case 1, 2, 3
                WSumaDia = 2
            Case 4, 5
                WSumaDia = 4
            Case 6
                WSumaDia = 3
            Case 0
                WSumaDia = 2
            Case Else
        End Select
        WSumaDia = WSumaDia + 1
        Dim WFecha2 As String = Calcula_vencimiento(WFecha1, WSumaDia)
        Return WFecha2

    End Function

    Private Function Calcula_Feriado(ByVal FechaEntrega As String) As String

        'Erase DiaFeriado
        Dim TotalFeriado As Integer = 0
        Dim ListaFeriados As New DataTable
        With ListaFeriados.Columns
            .Add("FechaFeriado")
        End With


        Dim SQLCnslt As String = "SELECT Fecha FROM Feriado Order by Codigo"
        Dim TablaFeriado As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaFeriado.Rows.Count > 0 Then
            For Each RowFeriado As DataRow In TablaFeriado.Rows
                ListaFeriados.Rows.Add(RowFeriado.Item("Fecha"))
            Next
        End If


        Dim WFecha1 As String
        Do
            Dim Feriado As String = "N"
            For Each Row As DataRow In ListaFeriados.Rows
                Feriado = "N"
                If Row.Item("FechaFeriado") = FechaEntrega Then
                    Feriado = "S"
                    Exit For
                End If
            Next

            REM 0 - DOMINGO
            REM 1 - LUNES
            REM 2 - MARTES
            REM 3 - MIERCOLES
            REM 4 - JUEVES
            REM 5 - VIERNES
            REM 6 - SABADO
            WFecha1 = FechaEntrega

            Dim strDia As Date = WFecha1

            Dim BDia As Integer = strDia.DayOfWeek

            If BDia = 0 Or BDia = 6 Then
                Feriado = "S"
            End If

            If Feriado = "S" Then
                Dim SumaDia As Integer = 2
                Dim WFecha2 As String = Calcula_vencimiento(WFecha1, SumaDia)
                Return WFecha2
            Else
                Exit Do
            End If

        Loop

        Return WFecha1
    End Function

    Private Function Calcula_vencimiento(WFecha As String, Plazo As Integer) As String

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

        Dg = 0
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

    Private Sub Ventana_Boton_Autorizo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CAMBIOAutorizado = "S" Then
            Dim WOwner As IAutorizacionDePedidos = TryCast(Owner, IAutorizacionDePedidos)
            If WOwner IsNot Nothing Then
                WOwner.CambiaAutorizado(ClavePedido)
                Close()
            End If
        End If
    End Sub

    Private Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click
        If Pnl_Devol.Visible = False Then

            If ValidaFecha(txt_VtoNuevo.Text) = "N" Then
                MsgBox("Fecha de Nuevo vencimiento invalida", vbExclamation)
                Exit Sub
            End If
            If cbx_Concepto.SelectedIndex <> 0 And cbx_Concepto.SelectedIndex <> 14 Then

                Dim WAtraso As Integer = 1

                Dim SQLCnslt As String = "SELECT NumeroMayor = Max(Numero) FROM Atraso"
                Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If Row IsNot Nothing Then
                    WAtraso = Row.Item("NumeroMayor") + 1
                End If

                Dim WFecha As String = Date.Today.ToString("MM/dd/yyyy")
                Dim WFechaOrd As String = ordenaFecha(WFecha)
                Dim WFechaEntregaOrd = ordenaFecha(txt_VtoNuevo.Text)

                Dim WVersionPedido As String = ""

                SQLCnslt = "SELECT Version FROM Pedido WHERE Pedido = '" & CodigoPedido & "' Order by Clave"
                Dim RowPedido As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowPedido IsNot Nothing Then
                    SQLCnslt = "INSERT INTO Atraso (Numero, Fecha, OrdFecha, Pedido, Cliente, Terminado, Problema, Articulo, FechaEntrega, " _
                            & "OrdFechaEntrega, DesCliente, DesTerminado, DesArticulo, Concepto, Solicitud, Origen, VersionPedido) " _
                            & "Values ('" & WAtraso & "', '" & WFecha & "', '" & WFechaOrd & "', '" & CodigoPedido & "', '" & CodigoCliente & "', " _
                            & "'" & "  -     -  " & "', '" & txt_Observaciones.Text & "', '" & "  -   -   " & "', '" & txt_VtoNuevo.Text & "', " _
                            & "'" & WFechaEntregaOrd & "', '" & RazonCliente & "', '" & "" & "', '" & "" & "', '" & cbx_Concepto.TabIndex & "', " _
                            & "'" & 0 & "', '" & 1 & "', '" & WVersionPedido & "')"

                    ExecuteNonQueries({SQLCnslt}, "SurfactanSa")
                End If

                Dim WOwner As IAutorizacionDePedidos = TryCast(Owner, IAutorizacionDePedidos)
                If WOwner IsNot Nothing Then
                    WOwner.CambiaAutorizado(ClavePedido, txt_VtoNuevo.Text)
                    Close()
                End If

            

            End If


        Else

            Dim Inicial As String = ""

            If rabtn_Opcion1.Checked Then
                Inicial = "N"
            End If

            If rabtn_Opcion2.Checked Then
                Inicial = "P"
            End If

            If rabtn_Opcion3.Checked Then
                Inicial = "S"
            End If


            Dim WOwner As IAutorizacionDePedidos = TryCast(Owner, IAutorizacionDePedidos)
            If WOwner IsNot Nothing Then
                WOwner.CambiaAutorizadoChecks(ClavePedido, Inicial)
                Close()
            End If
           
        End If

    End Sub
End Class