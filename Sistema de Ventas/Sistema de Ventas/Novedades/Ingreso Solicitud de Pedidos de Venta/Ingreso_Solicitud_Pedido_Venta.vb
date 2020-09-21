Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Ingreso_Solicitud_Pedido_Venta

    Dim WLugarDirEntrega As Integer
    Dim WDirEntrega(6) As String
    Dim WDirEntregaElegida As String
    Dim WEspecif(11) As String
    Dim TablaXEnvase As New DataTable
    Dim VectorXEspecificaciones() As String
    Dim TablaXDatosMuestra As New DataTable
    Dim TablaAuxiliar As New DataTable
    Dim WCalcula As String
    Dim WEntra As String
    Dim TablaWEnvase As DataTable
    Dim WVectorTabla As New DataTable
     


    Private Sub Ingreso_Solicitud_Pedido_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With WVectorTabla.Columns
            .Add("Envase")
            .Add("Kilos")
            .Add("Abreviatura")
            .Add("Saldo")
        End With

        With TablaWEnvase.Columns
            .Add("Envase")
            .Add("Abreviatura") 'WImpre()
        End With

        With TablaXEnvase.Columns
            .Add("Envase1")
            .Add("Canti1")
            .Add("Envase2")
            .Add("Canti2")
            .Add("Envase3")
            .Add("Canti3")
        End With

        With TablaXDatosMuestra.Columns
            .Add("NombreComercial")
            .Add("OrdenTrabajo")
            .Add("Referencia")
        End With

        With TablaAuxiliar.Columns
            .Add("Cliente")
            .Add("Terminado")
            .Add("NombreComercial")
        End With


        TablaWEnvase.Rows.Add("20", "")
        TablaWEnvase.Rows.Add("21", "")
        TablaWEnvase.Rows.Add("22", "")
        TablaWEnvase.Rows.Add("23", "")
        TablaWEnvase.Rows.Add("24", "")
        TablaWEnvase.Rows.Add("25", "")
        TablaWEnvase.Rows.Add("26", "")
        TablaWEnvase.Rows.Add("30", "")
        TablaWEnvase.Rows.Add("28", "")
        For Cicla = 1 To 9
            Dim SQLCnslt As String = "SELECT Abreviatura FROM Envase WHERE Envases = '" & TablaWEnvase.Rows(Cicla).Item("Envase") & "'"
            Dim RowEnvase As DataRow = GetSingle(SQLCnslt, Operador.Base)

            If RowEnvase IsNot Nothing Then
                TablaWEnvase(Cicla).Item("Abreviatura") = Microsoft.VisualBasic.Left$(RowEnvase.Item("Abreviatura"), 7)
                Else
                TablaWEnvase(Cicla).Item("Abreviatura") = ""
            End If
        Next Cicla

        txt_Pedido.Text = ""



        cbx_TipoPedido.SelectedIndex = 0

        cbx_Via.SelectedIndex = 0

        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_FechaEntrega.Text = "  /  /    "
        txt_Version.Text = ""

        WCalcula = "N"
        txt_FechaEntrega.Enabled = False
        WCalcula = "S"

        pnl_DirEntrega.Visible = False
        pnl_EntraNombre.Visible = False
        pnl_EntraNombreMl.Visible = False
        pnl_Especificaciones.Visible = False

    End Sub

    Private Sub txt_Pedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Pedido.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                Try

                    Dim SQLCnslt As String = "SELECT Fecha, Cleinte, FecEntrega, Hora, Observaciones, OrdenCpa, TipoPed, " _
                                             & "Version, DirEntrega, Via FROM PedidoSol WHERE Pedido = '" & txt_Pedido.Text & "' " _
                                             & "ORDER BY Clave"
                    Dim RowPed As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowPed IsNot Nothing Then
                        With RowPed
                            txt_Fecha.Text = .Item("Fecha")
                            txt_Cliente.Text = .Item("Cliente")
                            txt_FechaEntrega.Text = .Item("FecEntrega")
                            txt_Hora.Text = .Item("Hora")
                            txt_Observaciones.Text = .Item("Observaciones")
                            txt_OrdenCompra.Text = IIf(IsDBNull(.Item("OrdenCpa")), "", .Item("OrdenCpa"))
                            cbx_TipoPedido.SelectedIndex = IIf(IsDBNull(.Item("Tipoped")), 0, .Item("Tipoped"))
                            txt_Version.Text = IIf(IsDBNull(.Item("Version")), "0", .Item("Version"))
                            WLugarDirEntrega = IIf(IsDBNull(.Item("DirEntrega")), 1, .Item("DirEntrega"))
                            cbx_Via.SelectedIndex = IIf(IsDBNull(.Item("Via")), 0, .Item("Via"))
                        End With

                        SQLCnslt = "SELECT  Razon, Pago1, DirEntrega, DirEntregaII, DirEntregaIII, DirEntregaIV, " _
                                  & "DirEntregaV, Observaciones, Precio, Especif1, Especif2, Especif3, Especif4, Especif5, " _
                                  & "Especif6, Especif7, Especif8, Especif9 FROM Cliente WHERE Cliente '" & txt_Cliente.Text & "'"

                        Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)

                        

                        If RowCli IsNot Nothing Then
                            With RowCli
                                txt_ClienteDescrip.Text = .Item("Razon")
                                txt_Pago.Text = .Item("Pago1")
                                WDirEntrega(1) = .Item("DirEntrega")
                                WDirEntrega(2) = Trim(IIf(IsDBNull(.Item("DirEntregaII")), "", .Item("DirEntregaII")))
                                WDirEntrega(3) = Trim(IIf(IsDBNull(.Item("DirEntregaIII")), "", .Item("DirEntregaIII")))
                                WDirEntrega(4) = Trim(IIf(IsDBNull(.Item("DirEntregaIV")), "", .Item("DirEntregaIV")))
                                WDirEntrega(5) = Trim(IIf(IsDBNull(.Item("DirEntregaV")), "", .Item("DirEntregaV")))
                                WDirEntregaElegida = WDirEntrega(WLugarDirEntrega)

                                txt_Precio.Text = IIf(IsDBNull(.Item("Precio")), "", .Item("Precio"))


                                WEspecif(1) = ""
                                WEspecif(2) = IIf(IsDBNull(.Item("Especif1")), "", .Item("Especif1"))
                                WEspecif(3) = IIf(IsDBNull(.Item("Especif2")), "", .Item("Especif2"))
                                WEspecif(4) = IIf(IsDBNull(.Item("Especif3")), "", .Item("Especif3"))
                                WEspecif(5) = IIf(IsDBNull(.Item("Especif4")), "", .Item("Especif4"))
                                WEspecif(6) = IIf(IsDBNull(.Item("Especif5")), "", .Item("Especif5"))
                                WEspecif(7) = IIf(IsDBNull(.Item("Especif6")), "", .Item("Especif6"))
                                WEspecif(8) = IIf(IsDBNull(.Item("Especif7")), "", .Item("Especif7"))
                                WEspecif(9) = IIf(IsDBNull(.Item("Especif8")), "", .Item("Especif8"))
                                WEspecif(10) = IIf(IsDBNull(.Item("Especif9")), "", .Item("Especif9"))
                                

                                SQLCnslt = "SELECT Nombre FROM Pago WHERE Pago = '" & txt_Pago.Text & "'"

                                Dim RowPago As DataRow = GetSingle(SQLCnslt, Operador.Base)

                                If RowPago IsNot Nothing Then
                                    txt_PagoDescrip.Text = RowPago.Item("Nombre")
                                End If
                                
                                Proceso()
                            End With
                                  

                        End If



                    Else

                        SQLCnslt = "SELECT Pedido FROM PedidoSol WHERE Pedido = '" & txt_Pedido.Text & "' ORDER BY Clave"

                        Dim RowPedCheck As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        'EN ESTE CASO ES AL CONTRARIO DE LO USUAL SI ES NADA 
                        'LIMPIAMOS EL FORMULARIO Y PASAMOS AL SIGUIENTE CAMPO
                        If RowPedCheck Is Nothing Then
                            Dim Aux As String = txt_Pedido.Text
                            '                Call Limpia_Click()
                            txt_Pedido.Text = Aux
                            txt_Cliente.Focus()
                        End If
                   
                    End If


                Catch ex As Exception

                End Try
            Case Keys.Escape
                txt_Pedido.Text = ""
        End Select
      
    End Sub

    Sub Proceso()
        ' Erase XEnvase
        ' Erase XEspecificaciones
        ' Erase XDatosMuestra
        '
        ' Call Limpia_Vector()
        '
        ' Renglon = 0
        ' Erase Auxiliar
        ' WRenglon = 0
        '
        DGV_Pedido.Rows.Clear()

        Dim SQLCnslt As String = "SELECT Terminado, Cliente, Cantidad, Envase1, Canti1, Envase2, Canti2, Envase3, Canti3, " _
                                 & "Especificaciones, NombreComercial, OrdenTrabajo, Referencia, NombreComercial " _
                                 & "FROM PedidoSol WHERE Pedido = '" & txt_Pedido.Text & "' ORDER BY Clave"

        Dim tablaPedidos As DataTable = GetAll(SQLCnslt, Operador.Base)

        Dim Renglon As String = 0

        TablaXEnvase.Rows.Clear()
        TablaXDatosMuestra.Rows.Clear()


        If tablaPedidos.Rows.Count > 0 Then

            For Each Row As DataRow In tablaPedidos.Rows

                DGV_Pedido.Rows.Add()

                DGV_Pedido.Rows(Renglon).Cells("Producto").Value = Row.Item("Terminado")
                DGV_Pedido.Rows(Renglon).Cells("Descripcion").Value = ""
                DGV_Pedido.Rows(Renglon).Cells("Cantidad").Value = formatonumerico(Row.Item("Cantidad") - Row.Item("Facturado"), 2)


                TablaXEnvase.Rows.Add()

                TablaXEnvase.Rows(Renglon).Item("Envase1") = Row.Item("Envase1")
                TablaXEnvase.Rows(Renglon).Item("Canti1") = Row.Item("Canti1")
                TablaXEnvase.Rows(Renglon).Item("Envase2") = Row.Item("Envase2")
                TablaXEnvase.Rows(Renglon).Item("Canti2") = Row.Item("Canti2")
                TablaXEnvase.Rows(Renglon).Item("Envase3") = Row.Item("Envase3")
                TablaXEnvase.Rows(Renglon).Item("Canti3") = Row.Item("Canti3")

                VectorXEspecificaciones(Renglon) = IIf(IsDBNull(Row.Item("Especificaciones")), "0", Row.Item("Especificaciones"))

                TablaXDatosMuestra.Rows.Add()
                TablaXDatosMuestra.rows(Renglon).item("NombreComercial") = IIf(IsDBNull(Row.Item("NombreComercial")), "", Row.Item("NombreComercial"))
                TablaXDatosMuestra.rows(Renglon).item("OrdenTrabajo") = IIf(IsDBNull(Row.Item("OrdenTrabajo")), "", Row.Item("OrdenTrabajo"))
                TablaXDatosMuestra.rows(Renglon).item("Referencia") = IIf(IsDBNull(Row.Item("Referencia")), "", Row.Item("Referencia"))



                TablaAuxiliar.Rows.Add()

                TablaAuxiliar.Rows(Renglon).Item("Cliente") = Row.Item("Cliente")
                TablaAuxiliar.Rows(Renglon).Item("Terminado") = Row.Item("Terminado")
                If Microsoft.VisualBasic.Left$(Row.Item("Terminado"), 2) = "ML" Then
                    TablaAuxiliar.Rows(Renglon).Item("NombreComercial") = IIf(IsDBNull(Row.Item("NombreComercial")), "", Row.Item("NombreComercial"))
                End If
                Renglon = Renglon + 1
            Next

        End If


        For Each row As DataRow In TablaAuxiliar.Rows
            Dim Vuelta As Integer = 0
            Dim Cliente As String = row.Item("Cliente")
            Dim Terminado As String = row.Item("Terminado")
            Dim NombreComercial As String = row.Item("NombreComercial")

            Dim WtipoPro As String

            If Microsoft.VisualBasic.Left$(Terminado, 2) <> "PT" And Microsoft.VisualBasic.Left$(Terminado, 2) <> "YQ" And Microsoft.VisualBasic.Left$(Terminado, 2) <> "YF" And Microsoft.VisualBasic.Left$(Terminado, 2) <> "YP" And Microsoft.VisualBasic.Left$(Terminado, 2) <> "YH" Then
                WtipoPro = "M"
            Else
                WtipoPro = "T"
            End If

            Select Case WtipoPro
                Case "M"
                    Dim WArti As String = Microsoft.VisualBasic.Left$(Terminado, 3) + Microsoft.VisualBasic.Right$(Terminado, 7)
                    SQLCnslt = "SELECT Precio FROM PreciosMp WHERE Clave = '" & Cliente & WArti & "'"

                    Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)


                    If row IsNot Nothing Then

                        If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                            DGV_Pedido.Rows(Vuelta).Cells("Precio").Value = formatonumerico("0", 2)
                        Else
                            DGV_Pedido.Rows(Vuelta).Cells("Precio").Value = formatonumerico(RowArti.Item("Precio"), 2)

                        End If

                        txt_CodProduc.Focus()

                    Else

                        DGV_Pedido.Rows(Vuelta).Cells("Precio").Value = formatonumerico("0", 2)

                    End If

                    If Trim(NombreComercial) = "" Then
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArti & "'"

                        Dim Row_Arti As DataRow = GetSingle(SQLCnslt, Operador.Base)

                        If Row_Arti IsNot Nothing Then

                            DGV_Pedido.Rows(Vuelta).Cells("Descripcion").Value = Row_Arti.Item("Descripcion")


                        End If
                    Else
                        DGV_Pedido.Rows(Vuelta).Cells("Descripcion").Value = NombreComercial
                    End If

                Case "T"

                    Dim WDescripcion As String = ""

                    SQLCnslt = "SELECT Precio FROM Precios WHERE Clave = '" & Cliente & Terminado & "'"

                    Dim rowConPre As DataRow = GetSingle(SQLCnslt, Operador.Base)

                    If rowConPre IsNot Nothing Then

                        DGV_Pedido.Rows(Vuelta).Cells("Descripcion").Value = rowConPre.Item("Descripcion")
                        WDescripcion = rowConPre.Item("Descripcion")

                        If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                            DGV_Pedido.Rows(Vuelta).Cells("Precio").Value = formatonumerico("0", 2)
                        Else
                            DGV_Pedido.Rows(Vuelta).Cells("Precio").Value = formatonumerico(rowConPre.Item("Precio"), 2)
                        End If

                        If Trim(WDescripcion) = "" Then
                            SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & Terminado & "'"
                            Dim RowTer As DataRow = GetSingle(SQLCnslt, Operador.Base)

                            If RowTer IsNot Nothing Then

                                DGV_Pedido.Rows(Vuelta).Cells("Descripcion").Value = RowTer.Item("Descripcion")

                            End If

                        End If


                    End If

            End Select

            Vuelta += 1
        Next
    
        txt_CodProduc.Focus()

    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_Cliente.Focus()
                Else
                    txt_Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
        
    End Sub

    Private Sub txt_Cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Cliente.Text = UCase(txt_Cliente.Text)
                If txt_Cliente.Text <> "" Then
                    Dim SQLCnslt As String = "SELECT  Razon, Pago1, DirEntrega, DirEntregaII, DirEntregaIII, DirEntregaIV, " _
                                  & "DirEntregaV, Observaciones, Precio, Especif1, Especif2, Especif3, Especif4, Especif5, " _
                                  & "Especif6, Especif7, Especif8, Especif9 FROM Cliente WHERE Cliente '" & txt_Cliente.Text & "'"

                    Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)






                    If RowCli IsNot Nothing Then
                        With RowCli

                            txt_ClienteDescrip.Text = .Item("Razon")
                            txt_Pago.Text = .Item("Pago1")
                            txt_Observaciones.Text = RTrim(.Item("Observaciones"))
                            txt_Precio.Text = IIf(IsDBNull(.Item("Precio")), "", .Item("Precio"))

                            WDirEntrega(1) = .Item("DirEntrega")
                            WDirEntrega(2) = Trim(IIf(IsDBNull(.Item("DirEntregaII")), "", .Item("DirEntregaII")))
                            WDirEntrega(3) = Trim(IIf(IsDBNull(.Item("DirEntregaIII")), "", .Item("DirEntregaIII")))
                            WDirEntrega(4) = Trim(IIf(IsDBNull(.Item("DirEntregaIV")), "", .Item("DirEntregaIV")))
                            WDirEntrega(5) = Trim(IIf(IsDBNull(.Item("DirEntregaV")), "", .Item("DirEntregaV")))
                            



                            WDirEntregaElegida = ""
                            Dim CantiLugarEntrega As Integer = 0
                            For CicloDirEntrega = 1 To 5
                                If WDirEntrega(CicloDirEntrega) <> "" Then
                                    WDirEntregaElegida = WDirEntrega(CicloDirEntrega)
                                    WLugarDirEntrega = CicloDirEntrega
                                    CantiLugarEntrega = CantiLugarEntrega + 1
                                End If
                            Next CicloDirEntrega

                            If CantiLugarEntrega > 1 Then
                                DGV_DirEntrega.Rows.Clear()
                                For CicloDirEntrega = 1 To 5
                                    If WDirEntrega(CicloDirEntrega) <> "" Then
                                        DGV_DirEntrega.Rows.Add(WDirEntrega(CicloDirEntrega))
                                    End If
                                Next CicloDirEntrega

                                pnl_DirEntrega.Visible = True

                            End If




                            WEspecif(1) = ""
                            WEspecif(2) = IIf(IsDBNull(.Item("Especif1")), "", .Item("Especif1"))
                            WEspecif(3) = IIf(IsDBNull(.Item("Especif2")), "", .Item("Especif2"))
                            WEspecif(4) = IIf(IsDBNull(.Item("Especif3")), "", .Item("Especif3"))
                            WEspecif(5) = IIf(IsDBNull(.Item("Especif4")), "", .Item("Especif4"))
                            WEspecif(6) = IIf(IsDBNull(.Item("Especif5")), "", .Item("Especif5"))
                            WEspecif(7) = IIf(IsDBNull(.Item("Especif6")), "", .Item("Especif6"))
                            WEspecif(8) = IIf(IsDBNull(.Item("Especif7")), "", .Item("Especif7"))
                            WEspecif(9) = IIf(IsDBNull(.Item("Especif8")), "", .Item("Especif8"))
                            WEspecif(10) = IIf(IsDBNull(.Item("Especif9")), "", .Item("Especif9"))


                            SQLCnslt = "SELECT Nombre FROM Pago WHERE Pago = '" & txt_Pago.Text & "'"

                            Dim RowPago As DataRow = GetSingle(SQLCnslt, Operador.Base)

                            If RowPago IsNot Nothing Then
                                txt_PagoDescrip.Text = RowPago.Item("Nombre")
                            End If


                        End With

                    Else
                        txt_Cliente.Focus()
                    End If

                End If

            Case Keys.Escape
                txt_Cliente.Text = ""

        End Select
       

    End Sub

    Private Sub DGV_DirEntrega_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DirEntrega.CellDoubleClick
        Dim ZZDirEntrega As Integer = DGV_DirEntrega.CurrentRow.Index + 1
        WLugarDirEntrega = WDirEntrega(ZZDirEntrega)
        pnl_DirEntrega.Visible = False
        cbx_TipoPedido.Focus()
    End Sub

    Private Sub cbx_TipoPedido_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_TipoPedido.DropDownClosed
        If WCalcula = "S" Then
            If cbx_TipoPedido.SelectedIndex = 0 Then
                If txt_FechaEntrega.Text = "  /  /    " And cbx_TipoPedido.SelectedIndex = 0 And txt_Fecha.Text <> "  /  /    " Then
                    Dim FecEntrega As String = Calcula_FecEntrega()
                    Dim Fecha As String = Calcula_Feriado(FecEntrega)
                    txt_FechaEntrega.Text = Fecha
                End If

                txt_FechaEntrega.Enabled = False
                REM Hora.SetFocus
            Else
                If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                    If txt_FechaEntrega.Text = "  /  /    " And txt_Fecha.Text <> "  /  /    " Then
                        Dim FechaEntrega As String = Calcula_FecEntrega_Muestra()
                        txt_FechaEntrega.Text = FechaEntrega
                    End If
                    txt_FechaEntrega.Enabled = True
                    txt_FechaEntrega.Focus()
                Else
                    txt_FechaEntrega.Enabled = True
                    txt_FechaEntrega.Focus()
                End If
            End If
        End If
    End Sub



   

    Private Function Calcula_FecEntrega_Muestra() As String

        REM 1 - DOMINGO
        REM 2 - LUNES
        REM 3 - MARTES
        REM 4 - MIERCOLES
        REM 5 - JUEVES
        REM 6 - VIERNES
        REM 7 - SABADO
        Dim WProvincia As Integer

        Dim SQLCnslt As String = "SELECT Provincia FROM Cliente WHERE Cliente = '" & txt_Cliente.Text & "'"
        Dim RowCliente As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowCliente IsNot Nothing Then
            WProvincia = RowCliente.Item("Provincia")
        End If

        Dim XFec1 As String = txt_Fecha.Text
        Dim XFec2 As String
        If WProvincia <> 24 Then



            Dim SumaDia As Integer = 8
            XFec2 = Calcula_vencimiento(XFec1, SumaDia)
            Return XFec2
        Else


            Dim SumaDia As String = 15
            Do
                SumaDia = SumaDia + 1
                XFec2 = Calcula_vencimiento(XFec1, SumaDia)

                XFec1 = XFec2

                Dim FechaFormatDate As Date = XFec1
                Dim WBDia As Integer = FechaFormatDate.DayOfWeek
                SumaDia = 1
                If Val(WBDia) <> 7 And Val(WBDia) <> 1 Then
                    Exit Do
                End If
            Loop
            Return XFec2
        End If
        

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

    Private Sub txt_FechaEntrega_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaEntrega.KeyDown

        Select Case e.KeyData
            Case Keys.Enter

                If txt_FechaEntrega.Text = "  /  /    " Then
                    txt_FechaEntrega.Text = "00/00/0000"
                End If
                Dim Auxi As String = ValidaFecha(txt_FechaEntrega.Text)
                If Auxi = "S" Or txt_FechaEntrega.Text = "00/00/0000" Then
                    txt_Hora.Focus()
                Else
                    txt_FechaEntrega.Focus()
                End If


            Case Keys.Escape
                txt_FechaEntrega.Text = ""
        End Select
        
    End Sub

    Private Sub txt_Hora_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hora.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Observaciones.Focus()
            Case Keys.Escape
                txt_Hora.Text = ""
        End Select

    End Sub

    Private Sub txt_Observaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Observaciones.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_OrdenCompra.Focus()
            Case Keys.Escape
                txt_Observaciones.Text = ""
        End Select
    End Sub

    Private Sub txt_OrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_OrdenCompra.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Ingresa_Click()
            Case Keys.Escape
                txt_OrdenCompra.Text = ""
        End Select
    End Sub



    Private Sub Ingresa_Click()

        txt_Fila.Text = ""
        txt_CodProduc.Text = "  -     -   "
        txt_ProducDescrip.Text = ""
        txt_Cantidad.Text = ""
        txt_Precio.Text = ""
        Lbl_Stock.Text = "0"
        lbl_StkPedido.Text = "0"
        lbl_Produccion.Text = "0"
        lbl_Disponible.Text = "0"
        Lbl_WStock1.Text = "0"
        Lbl_WStock2.Text = "0"
        Lbl_WStock3.Text = "0"
        Lbl_WStock4.Text = "0"
        Lbl_WStock5.Text = "0"
        Lbl_WStock6.Text = "0"
        Lbl_WStock7.Text = "0"

        txt_NombreComercialMl.Text = ""
        txt_OrdenTrabajo.Text = ""
        txt_Referencia.Text = ""

        lbl_Envase1.Text = ""
        lbl_Envase2.Text = ""
        lbl_Envase3.Text = ""
        lbl_Envase4.Text = ""
        lbl_Envase5.Text = ""
        lbl_Envase6.Text = ""

        lbl_Abre1.Text = ""
        lbl_Abre2.Text = ""
        lbl_Abre3.Text = ""
        lbl_Abre4.Text = ""
        lbl_Abre5.Text = ""
        lbl_Abre6.Text = ""

        lbl_Capa1.Text = ""
        lbl_Capa2.Text = ""
        lbl_Capa3.Text = ""
        lbl_Capa4.Text = ""
        lbl_Capa5.Text = ""
        lbl_Capa6.Text = ""

        txt_Envase1.Text = ""
        txt_Envase2.Text = ""
        txt_Envase3.Text = ""

        txt_Canti1.Text = ""
        txt_Canti2.Text = ""
        txt_Canti3.Text = ""

        txt_Especificaciones.Text = ""

        txt_CodProduc.Focus()

    End Sub

 
    
    Private Sub txt_CodProduc_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_CodProduc.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim WCliente As String = txt_Cliente.Text
                Dim WTerminado = txt_CodProduc.Text

                Dim WArti As String = Microsoft.VisualBasic.Left$(WTerminado, 3) + Microsoft.VisualBasic.Right$(WTerminado, 7)
                Dim WClave As String = Wcliente + WTerminado
                Dim WClaveMp = WCliente + WArti

                Dim WTipoPro As String

                If Microsoft.VisualBasic.Left$(WTerminado, 2) <> "PT" And Microsoft.VisualBasic.Left$(WTerminado, 2) <> "YQ" And Microsoft.VisualBasic.Left$(WTerminado, 2) <> "YF" And Microsoft.VisualBasic.Left$(WTerminado, 2) <> "YP" And Microsoft.VisualBasic.Left$(WTerminado, 2) <> "YH" Then
                    WTipopro = "M"
                Else
                    WTipopro = "T"
                End If

                Select Case WTipopro
                    Case "M"
                        Dim SQLCnslt As String = "SELECT Precio FROM PreciosMp WHERE Clave = '" & WClaveMp & "'"
                        Dim RowPreciosMp As DataRow = GetSingle(SQLCnslt, Operador.Base)

                        
                        If RowPreciosMp IsNot Nothing Then
                            WEntra = "S"
                            If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                                txt_Precio.Text = formatonumerico("0", 2)
                            Else
                                txt_Precio.Text = formatonumerico(Str$(RowPreciosMp.Item("Precio")), 2)
                            End If

                            If Microsoft.VisualBasic.Left$(WArti, 2) <> "ML" Then
                                Call Busca_Stock()
                            End If
                            txt_Cantidad.Focus()
                        Else
                            If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArti & "'"
                                Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)

                                
                                If RowArti IsNot Nothing Then
                                    txt_ProducDescrip.Text = RowArti.Item("Descripcion")
                                    If Microsoft.VisualBasic.Left$(WArti, 2) = "ML" Then

                                        WEntra = "S"
                                        txt_Precio.Text = formatonumerico("0", 2)
                                        pnl_EntraNombreMl.Visible = True
                                        REM NombreComercialMl.Text = ""
                                        REM OrdenTrabajo.Text = ""
                                        REM Referencia.Text = ""
                                        txt_NombreComercialMl.Focus()
                                    Else

                                        WEntra = "S"
                                        txt_Precio.Text = formatonumerico("0", 2)
                                        Busca_Stock()
                                        txt_Cantidad.Focus()
                                    End If
                                Else
                                    txt_CodProduc.Focus()
                                End If
                            Else
                                txt_CodProduc.Focus()
                            End If
                        End If

                    Case Else
                        Dim SQLCnslt As String = "SELECT Descripcion, Precio FROM Precios WHERE Clave = '" & WClave & "'"
                        Dim RowPrecios As DataRow = GetSingle(SQLCnslt, Operador.Base)


                        If RowPrecios IsNot Nothing Then
                            WEntra = "S"
                            txt_ProducDescrip.Text = RowPrecios.Item("Descripcion")
                            If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                                txt_Precio.Text = formatonumerico("0", 2)
                            Else
                                txt_Precio.Text = formatonumerico(Str$(RowPrecios.Item("Precio")), 2)
                            End If

                            Busca_Stock()
                            txt_Cantidad.Focus()
                        Else
                            If cbx_TipoPedido.SelectedIndex = 5 Or cbx_TipoPedido.SelectedIndex = 6 Then
                                
                                If MsgBox("Articulo sin nombre comercial. Desea ingresarlo :", vbYesNo) = vbYes Then
                                    pnl_EntraNombre.Visible = True
                                    txt_NombreComercial.Text = ""
                                    txt_NombreComercial.Focus()
                                Else
                                    txt_CodProduc.Focus()
                                End If
                            Else
                                txt_CodProduc.Focus()
                            End If
                        End If

                End Select

            Case Keys.Escape
                txt_CodProduc.Text = ""
        End Select

    End Sub



    Private Sub Busca_Stock()


        Dim WTermi As String = txt_CodProduc.Text
        Dim WStkPedido As Double = StkPed()
        lbl_StkPedido.Text = WStkPedido

        'If Val(WEmpresa) = 8 Then
        '    Call Calcula_Produccion()
        '    Produccion.Caption = Str$(WProduccion)
        'Else
        lbl_Produccion.Text = ""
        'End If


        ' If Val(WEmpresa) = 1 Then
        Lbl_Stock1.Text = "SI"
        Lbl_Stock2.Text = "SII"
        Lbl_Stock3.Text = "SIII"
        Lbl_Stock4.Text = "SIV"
        Lbl_Stock5.Text = "SV"
        Lbl_Stock6.Text = "SVI"
        Lbl_Stock7.Text = "SVII"
        ' Else
        ' Stock1.Caption = "PI"
        ' Stock2.Caption = "PII"
        ' Stock3.Caption = "PV"
        ' Stock4.Caption = "PVI"
        ' Stock5.Caption = ""
        ' Stock6.Caption = ""
        ' Stock7.Caption = ""
        'End If

        Lbl_WStock1.Text = ""
        Lbl_WStock2.Text = ""
        Lbl_WStock3.Text = ""
        Lbl_WStock4.Text = ""
        Lbl_WStock5.Text = ""
        Lbl_WStock6.Text = ""
        Lbl_WStock7.Text = ""

        If WTermi = "  -     -   " Then Exit Sub

        Dim WTipoPro As String

        If Microsoft.VisualBasic.Left$(WTermi, 2) <> "PT" And Microsoft.VisualBasic.Left$(WTermi, 2) <> "YQ" And Microsoft.VisualBasic.Left$(WTermi, 2) <> "YF" And Microsoft.VisualBasic.Left$(WTermi, 2) <> "YP" And Microsoft.VisualBasic.Left$(WTermi, 2) <> "YH" Then
            WTipoPro = "M"
        Else
            WTipoPro = "T"
        End If

        Select Case WTipopro
            Case "M"
                Dim WArti As String = Microsoft.VisualBasic.Left$(WTermi, 3) + Microsoft.VisualBasic.Right$(WTermi, 7)
                Dim SQLCnslt As String = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArti & "'"

                Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If RowArti IsNot Nothing Then
                    txt_ProducDescrip.Text = RowArti.Item("Descripcion")

                End If

                'XEmpresa = WEmpresa
                'Select Case Val(WEmpresa)
                'Case 1
                SQLCnslt = "SELECT Inicial, Entradas, Salidas FROM Articulo WHERE Codigo = '" & WArti & "'"
                Dim RowArti2 As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowArti2 IsNot Nothing Then
                    Lbl_WStock1.Text = RowArti2.Item("Inicial") + RowArti2.Item("Entradas") - RowArti2.Item("Salidas")

                Else
                    Lbl_WStock1.Text = "0"
                End If

                'Case 8
                REM WEmpresa = "0002"
                REM txtOdbc = "Empresa02"
                REM strConnect = "odbc;dsn=" & txtOdbc & ";uid=" & txtUserName & ";pwd=" & txtPassword & ";app=" & gAplicacion
                REM Set db = DBEngine.Workspaces(0).OpenDatabase("", False, False, strConnect)

                REM spArticulo = "ConsultaArticulo " + "'" + WArti + "'"
                REM Set rstArticulo = db.OpenRecordset(spArticulo, dbOpenSnapshot, dbSQLPassThrough)
                REM If rstArticulo.RecordCount > 0 Then
                REM     WStock1.Caption = rstArticulo!Inicial + rstArticulo!Entradas - rstArticulo!Salidas
                REM     rstArticulo.Close
                REM         Else
                REM     WStock1.Caption = "0"
                REM End If

                REM WEmpresa = "0004"
                REM txtOdbc = "Empresa04"
                REM strConnect = "odbc;dsn=" & txtOdbc & ";uid=" & txtUserName & ";pwd=" & txtPassword & ";app=" & gAplicacion
                REM Set db = DBEngine.Workspaces(0).OpenDatabase("", False, False, strConnect)

                REM spArticulo = "ConsultaArticulo " + "'" + WArti + "'"
                REM Set rstArticulo = db.OpenRecordset(spArticulo, dbOpenSnapshot, dbSQLPassThrough)
                REM If rstArticulo.RecordCount > 0 Then
                REM     WStock2.Caption = rstArticulo!Inicial + rstArticulo!Entradas - rstArticulo!Salidas
                REM     rstArticulo.Close
                REM         Else
                REM     WStock2.Caption = "0"
                REM End If

                REM WEmpresa = "0008"
                REM txtOdbc = "Empresa08"
                REM strConnect = "odbc;dsn=" & txtOdbc & ";uid=" & txtUserName & ";pwd=" & txtPassword & ";app=" & gAplicacion
                REM Set db = DBEngine.Workspaces(0).OpenDatabase("", False, False, strConnect)

                '  spArticulo = "ConsultaArticulo " + "'" + WArti + "'"
                '  rstArticulo = db.OpenRecordset(spArticulo, dbOpenSnapshot, dbSQLPassThrough)
                '  If rstArticulo.RecordCount > 0 Then
                '      WStock3.Caption = rstArticulo!Inicial + rstArticulo!Entradas - rstArticulo!Salidas
                '      rstArticulo.Close()
                '  Else
                '      WStock3.Caption = "0"
                '  End If

                REM WEmpresa = "0008"
                REM txtOdbc = "Empresa08"
                REM strConnect = "odbc;dsn=" & txtOdbc & ";uid=" & txtUserName & ";pwd=" & txtPassword & ";app=" & gAplicacion
                REM Set db = DBEngine.Workspaces(0).OpenDatabase("", False, False, strConnect)

                'Case Else
                ' End Select

                Lbl_Stock.Text = Str$(Val(Lbl_WStock1.Text) + Val(Lbl_WStock2.Text) + Val(Lbl_WStock3.Text) + Val(Lbl_WStock4.Text) + Val(Lbl_WStock5.Text) + Val(Lbl_WStock6.Text) + Val(Lbl_WStock7.Text))
                lbl_Disponible.Text = Str$(Val(Lbl_Stock.Text) - Val(lbl_StkPedido.Text) + Val(lbl_Produccion.Text))

                REM Busca que envases hay

                WVectorTabla.Rows.Clear()

                For i = 1 To 7
                    WVectorTabla.Rows.Add("", "", "", "")
                Next

                SQLCnslt = "SELECT Articulo, Marca, Saldo, Envase FROM Laudo " _
                        & "WHERE Articulo >= '" & WArti & "' and Articulo <= '" & WArti & "' Order by Laudo"
                Dim tablaLaudo As DataTable = GetAll(SQLCnslt, Operador.Base)
                If tablaLaudo.Rows.Count > 0 Then
                    For Each RowLaudo As DataRow In tablaLaudo.Rows

                        If RowLaudo.Item("Marca") = "X" And RowLaudo.Item("Saldo") = 0 Then

                        Else

                            If RowLaudo.Item("Articulo") = WArti Then

                                Dim WSaldo As String = IIf(IsDBNull(RowLaudo.Item("Saldo")), "0", RowLaudo.Item("Saldo"))
                                WSaldo = formatonumerico(WSaldo, 2)

                                If Val(WSaldo) <> 0 Then

                                    Dim WEnv As String = IIf(IsDBNull(RowLaudo.Item("Envase")), "0", RowLaudo.Item("Envase"))
                                    'WEnv = Str$(XEnv)
                                    For CicloEnvase = 1 To 6
                                        If Val(WEnv) = Val(WVectorTabla.Rows(CicloEnvase).Item("Envases")) Then
                                            WVectorTabla.Rows(CicloEnvase).Item("Saldo") = Str$(Val(WVectorTabla.Rows(CicloEnvase).Item("Slado")) + WSaldo)
                                            Exit For
                                        End If
                                        If Val(WVectorTabla.Rows(CicloEnvase).Item("Ënvase")) = 0 Then
                                            WVectorTabla.Rows(CicloEnvase).Item("Envase") = WEnv
                                            WVectorTabla.Rows(CicloEnvase).Item("Saldo") = Str$(WSaldo)
                                            Exit For
                                        End If
                                    Next CicloEnvase

                                End If

                            End If

                        End If
                    Next
                    
                End If

                Carga_Envases()

            Case "T"

                WVectorTabla.Rows.Clear()

                For i = 1 To 7
                    WVectorTabla.Rows.Add("", "", "", "")
                Next

                Dim SQLCnslt As String = "SELECT 1, Envase2, Envase3, Envase4, Envase5, Envase6 " _
                                        & "FROM Terminado WHERE Codigo = '" & WTermi & "'"
                Dim RowTermi As DataRow = GetSingle(SQLCnslt, Operador.Base)

                
                If RowTermi IsNot Nothing Then
                    WVectorTabla.Rows(1).Item("Envase") = RowTermi.Item("Envase1")
                    WVectorTabla.Rows(2).Item("Envase") = RowTermi.Item("Envase2")
                    WVectorTabla.Rows(3).Item("Envase") = RowTermi.Item("Envase3")
                    WVectorTabla.Rows(4).Item("Envase") = RowTermi.Item("Envase4")
                    WVectorTabla.Rows(5).Item("Envase") = RowTermi.Item("Envase5")
                    WVectorTabla.Rows(6).Item("Envase") = RowTermi.Item("Envase6")

                    Carga_Envases()
                End If


                Dim VectorPlantas(8) As String
                VectorPlantas(1) = "SurfactanSa"
                VectorPlantas(2) = "Surfactan_II"
                VectorPlantas(3) = "Surfactan_III"
                VectorPlantas(4) = "Surfactan_IV"
                VectorPlantas(5) = "Surfactan_V"
                VectorPlantas(6) = "Surfactan_VI"
                VectorPlantas(7) = "Surfactan_VII"

                Dim VectorStock(8) As Double

                SQLCnslt = "SELECT Inicial, Entradas, Salidas FROM Terminado WHERE Codigo = '" & WTermi & "'"

                For i = 1 To 7
                    Dim RowTer As DataRow = GetSingle(SQLCnslt, VectorPlantas(i))
                    VectorStock(i) = RowTer.Item("Inicial") + RowTer.Item("Entradas") - RowTer.Item("Salidas")
                Next

                Lbl_WStock1.Text = VectorStock(1)
                Lbl_WStock2.Text = VectorStock(2)
                Lbl_WStock3.Text = VectorStock(3)
                Lbl_WStock4.Text = VectorStock(4)
                Lbl_WStock5.Text = VectorStock(5)
                Lbl_WStock6.Text = VectorStock(6)
                Lbl_WStock7.Text = VectorStock(7)



                Dim ZZClave As String = txt_Cliente.Text + WTermi

                Lbl_Stock.Text = Str$(Val(Lbl_WStock1.Text) + Val(Lbl_WStock2.Text) + Val(Lbl_WStock3.Text) + Val(Lbl_WStock4.Text) + Val(Lbl_WStock5.Text) + Val(Lbl_WStock6.Text) + Val(Lbl_WStock7.Text))
                lbl_Disponible.Text = Str$(Val(Lbl_Stock.Text) - Val(lbl_StkPedido.Text) + Val(lbl_Produccion.Text))

            Case Else
        End Select

        For WDa = 1 To 6
            If Val(WVectorTabla.Rows(WDa).Item("Envase")) <> 0 Then
                Dim SQLCnslt As String = "SELECT Abreviatura FROM Envases " _
                                          & "WHERE Envase = '" & WVectorTabla.Rows(WDa).Item("Envase") & "'"
                Dim RowEnvase As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowEnvase IsNot Nothing Then
                    WVectorTabla.Rows(WDa).Item("Abreviatura") = RowEnvase.Item("Abreviatura")

                End If
            End If
        Next WDa

        Lbl_Stock.Text = formatonumerico(Lbl_Stock.Text, 2)
        Lbl_WStock1.Text = formatonumerico(Lbl_WStock1.Text, 2)
        Lbl_WStock2.Text = formatonumerico(Lbl_WStock2.Text, 2)
        Lbl_WStock3.Text = formatonumerico(Lbl_WStock3.Text, 2)
        Lbl_WStock4.Text = formatonumerico(Lbl_WStock4.Text, 2)
        Lbl_WStock5.Text = formatonumerico(Lbl_WStock5.Text, 2)
        Lbl_WStock6.Text = formatonumerico(Lbl_WStock6.Text, 2)
        Lbl_WStock7.Text = formatonumerico(Lbl_WStock7.Text, 2)
        lbl_StkPedido.Text = formatonumerico(lbl_StkPedido.Text, 2)
        lbl_Produccion.Text = formatonumerico(lbl_Produccion.Text, 2)
        lbl_Disponible.Text = formatonumerico(lbl_Disponible.Text, 2)

        'If Val(WEmpresa) <> 1 Then
        '    PantallaPro.Visible = False
        'End If

        Exit Sub



    End Sub


    Private Function StkPed() As Double

        Dim WTermi As String = txt_CodProduc.Text
        Dim WArti As String = Microsoft.VisualBasic.Left$(WTermi, 3) + Microsoft.VisualBasic.Right$(WTermi, 7)
        Dim WStkPedido As Double = 0

        Dim SQLCnslt As String = "SELECT Cantidad, Facturado, Pedido FROM PedidoSol " _
                                 & "WHERE Terminado = '" & WTermi & "' ORDER BY Clave"
        Dim TablaPedTer As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaPedTer.Rows.Count > 0 Then

            For Each rowPedTer As DataRow In TablaPedTer.Rows
                Dim XPed As Double = rowPedTer.Item("Cantidad") - rowPedTer.Item("Facturado")

                If XPed <> 0 Then
                    If txt_Pedido.Text <> rowPedTer.Item("Pedido") Then
                        WStkPedido = WStkPedido + XPed
                    End If
                End If
            Next
            
        End If

        Return WStkPedido
    End Function


    Sub Carga_Envases()

        Dim ZZDa As Integer = 0

        For Cicla = 1 To 6
            Dim SQLCnslt As String = "SELECT Kilos, Abreviatura FROM Envase WHERE Envase = '" & WVectorTabla.Rows(Cicla).Item("Envase") & "'"
            Dim RowEnvase As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowEnvase IsNot Nothing Then
                WVectorTabla.Rows(Cicla).Item("Kilos") = RowEnvase.Item("Kilos")
                WVectorTabla.Rows(Cicla).Item("Abreviatura") = RowEnvase.Item("Abreviatura")

            Else
                If ZZDa = 0 Then
                    WVectorTabla.Rows(Cicla).Item("Envase") = "99"
                    WVectorTabla.Rows(Cicla).Item("Kilos") = "0"
                    WVectorTabla.Rows(Cicla).Item("Abreviatura") = "Indis."
                    ZZDa = 1
                Else
                    WVectorTabla.Rows(Cicla).Item("Kilos") = ""
                    WVectorTabla.Rows(Cicla).Item("Abreviatura") = ""
                End If
            End If
        Next Cicla

        lbl_Envase1.Text = WVectorTabla.Rows(1).Item("Envase")
        lbl_Envase2.Text = WVectorTabla.Rows(2).Item("Envase")
        lbl_Envase3.Text = WVectorTabla.Rows(3).Item("Envase")
        lbl_Envase4.Text = WVectorTabla.Rows(4).Item("Envase")
        lbl_Envase5.Text = WVectorTabla.Rows(5).Item("Envase")
        lbl_Envase6.Text = WVectorTabla.Rows(6).Item("Envase")

        REM WCapa1.Caption = WVector(1, 2)
        REM WCapa2.Caption = WVector(2, 2)
        REM Wcapa3.Caption = WVector(3, 2)
        REM WCapa4.Caption = WVector(4, 2)
        REM WCapa5.Caption = WVector(5, 2)
        REM WCapa6.Caption = WVector(6, 2)

        lbl_Capa1.Text = WVectorTabla.Rows(1).Item("Kilos")
        lbl_Capa2.Text = WVectorTabla.Rows(2).Item("Kilos")
        lbl_Capa3.Text = WVectorTabla.Rows(3).Item("Kilos")
        lbl_Capa4.Text = WVectorTabla.Rows(4).Item("Kilos")
        lbl_Capa5.Text = WVectorTabla.Rows(5).Item("Kilos")
        lbl_Capa6.Text = WVectorTabla.Rows(6).Item("Kilos")

        lbl_Abre1.Text = WVectorTabla.Rows(1).Item("Abreviatura")
        lbl_Abre2.Text = WVectorTabla.Rows(2).Item("Abreviatura")
        lbl_Abre3.Text = WVectorTabla.Rows(3).Item("Abreviatura")
        lbl_Abre4.Text = WVectorTabla.Rows(4).Item("Abreviatura")
        lbl_Abre5.Text = WVectorTabla.Rows(5).Item("Abreviatura")
        lbl_Abre6.Text = WVectorTabla.Rows(6).Item("Abreviatura")


    End Sub




    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cantidad.KeyPress, txt_Canti3.KeyPress, txt_Canti2.KeyPress, txt_Canti1.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub




    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Pedido.KeyPress, txt_OrdenCompra.KeyPress, txt_Envase3.KeyPress, txt_Envase2.KeyPress, txt_Envase1.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub





    Private Sub txt_Cantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cantidad.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_Cantidad.Text = formatonumerico(txt_Cantidad.Text, 2)


                Dim ZLinea As Integer = 0

                Dim SQLCnslt As String = "SELECT linea FROM Terminado WHERE Codigo = '" & txt_CodProduc.Text & "'"
                Dim RowTermi As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowTermi IsNot Nothing Then
                    ZLinea = RowTermi.Item("Linea")

                End If


                Dim XCodigo As Integer = Val(Microsoft.VisualBasic.Mid$(txt_CodProduc.Text, 4, 5))
                REM If (XCodigo >= 25000 And XCodigo <= 25999) Or ZLinea = 10 Or ZLinea = 20 Then
                If UCase(Operador.Base) = UCase("SurfactanSa") Then
                    pnl_Especificaciones.Visible = True
                    If txt_Especificaciones.Text = "" Then
                        SQLCnslt = "SELECT Especificaciones FROM EspeCli WHERE Cliente = '" & txt_Cliente.Text & "' and Terminado = '" & txt_CodProduc.Text & "'"
                        Dim RowEspecli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        
                        If RowEspecli IsNot Nothing Then
                            txt_Especificaciones.Text = RowEspecli.Item("Especificaciones")
                        End If
                    End If
                    txt_Especificaciones.Focus()
                Else
                    txt_Envase1.Focus()
                End If
                REM         Else
                REM     Envase1.SetFocus
                REM End If

            Case Keys.Escape
                txt_Cantidad.Text = ""
        End Select



    End Sub

    Private Sub txt_Envase1_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Envase1.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Envase1.Text) <> 0 Then
                    Dim Ingre As String = "N"
                    For DA = 1 To 6
                        If Val(WVectorTabla.Rows(DA).Item("Envase")) = Val(txt_Envase1.Text) Then
                            Ingre = "S"
                            Exit For
                        End If
                    Next DA
                    If Ingre = "S" Or Val(txt_Envase1.Text) = 99 Then
                        txt_Canti1.Focus()
                    Else
                        txt_Envase1.Focus()
                    End If
                Else
                    REM Call Alta_Vector
                    REM Call Ingresa_Click
                    REM WArticulo.SetFocus
                End If
            Case Keys.Escape
                txt_Envase1.Text = ""
        End Select

    End Sub

    Private Sub txt_Envase2_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Envase2.KeyDown


        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Envase2.Text) <> 0 Then
                    Dim Ingre As String = "N"
                    For DA = 1 To 6
                        If Val(WVectorTabla.Rows(DA).Item("Envase")) = Val(txt_Envase2.Text) Then
                            Ingre = "S"
                            Exit For
                        End If
                    Next DA
                    If Ingre = "S" Then
                        txt_Canti2.Focus()
                    Else

                        txt_Envase2.Focus()
                    End If
                Else
                    If txt_Envase1.Text <> 0 Then
                        Alta_Vector()
                        Ingresa_Click()
                        txt_CodProduc.Focus()
                    End If
                   
                End If
            Case Keys.Escape
                txt_Envase1.Text = ""
        End Select

     
    End Sub

    Private Sub txt_Envase3_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Envase3.KeyDown





        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Envase3.Text) <> 0 Then
                    Dim Ingre As String = "N"
                    For DA = 1 To 6
                        If Val(WVectorTabla.Rows(DA).Item("Envase")) = Val(txt_Envase3.Text) Then
                            Ingre = "S"
                            Exit For
                        End If
                    Next DA
                    If Ingre = "S" Then
                        txt_Canti3.Focus()
                    Else

                        txt_Envase3.Focus()
                    End If
                Else
                    If txt_Envase1.Text <> 0 Then
                        Alta_Vector()
                        Ingresa_Click()
                        txt_CodProduc.Focus()
                    End If

                End If
            Case Keys.Escape
                txt_Envase1.Text = ""
        End Select

    End Sub


    Private Sub Alta_Vector()

        If txt_Fila.Text = "" Then

            Dim XCodigo As Integer = Val(Microsoft.VisualBasic.Mid$(txt_CodProduc.Text, 4, 5))
            If XCodigo >= 11000 And XCodigo <= 11999 Then
                If cbx_TipoPedido.SelectedIndex = 0 Then
                    Dim XFec1 As String = txt_FechaEntrega.Text
                    Dim SumaDia As Integer = 2
                    Do
                        SumaDia = SumaDia + 1
                        Dim Xfec2 As String = Calcula_vencimiento(XFec1, SumaDia)
                        txt_FechaEntrega.Text = Xfec2
                        XFec1 = XFec2
                        Dim DateXfec1 As Date = XFec1
                        Dim BDia As Integer = DateXfec1.DayOfWeek
                        SumaDia = 1
                        If Val(BDia) <> 7 And Val(BDia) <> 1 Then
                            txt_FechaEntrega.Text = XFec1
                            Exit Do
                        End If
                    Loop
                End If
            End If

            Dim Renglon As Integer = DGV_Pedido.Rows.Count

            If DGV_Pedido.Rows.Count = 0 Then
                Renglon = 0
            Else
                Renglon = DGV_Pedido.Rows.Count
            End If

            DGV_Pedido.Rows.Add()

            DGV_Pedido.Rows(Renglon).Cells("Producto").Value = txt_CodProduc.Text
            DGV_Pedido.Rows(Renglon).Cells("Descripcion").Value = txt_ProducDescrip.Text
            DGV_Pedido.Rows(Renglon).Cells("Cantidad").Value = txt_Cantidad.Text
            DGV_Pedido.Rows(Renglon).Cells("Precio").Value = txt_Precio.Text

            TablaXEnvase.Rows.Add()

            TablaXEnvase.Rows(Renglon).Item("Envase1") = txt_Envase1
            TablaXEnvase.Rows(Renglon).Item("Canti1") = txt_Canti1
            TablaXEnvase.Rows(Renglon).Item("Envase2") = txt_Envase2
            TablaXEnvase.Rows(Renglon).Item("Canti2") = txt_Canti2
            TablaXEnvase.Rows(Renglon).Item("Envase3") = txt_Envase3
            TablaXEnvase.Rows(Renglon).Item("Canti3") = txt_Canti3
            
            VectorXEspecificaciones(Renglon) = txt_Especificaciones.Text

            TablaXDatosMuestra.Rows.Add()

            TablaXDatosMuestra.Rows(Renglon).Item("NombreComecial") = txt_NombreComercialMl.Text
            TablaXDatosMuestra.Rows(Renglon).Item("OrdenTrabajo") = txt_OrdenTrabajo.Text
            TablaXDatosMuestra.Rows(Renglon).Item("Referencia") = txt_Referencia.Text

        Else

            Dim Renglon As Integer = txt_Fila.Text



            DGV_Pedido.Rows(Renglon).Cells("Producto").Value = txt_CodProduc.Text
            DGV_Pedido.Rows(Renglon).Cells("Descripcion").Value = txt_ProducDescrip.Text
            DGV_Pedido.Rows(Renglon).Cells("Cantidad").Value = txt_Cantidad.Text
            DGV_Pedido.Rows(Renglon).Cells("Precio").Value = txt_Precio.Text



            TablaXEnvase.Rows(Renglon).Item("Envase1") = txt_Envase1
            TablaXEnvase.Rows(Renglon).Item("Canti1") = txt_Canti1
            TablaXEnvase.Rows(Renglon).Item("Envase2") = txt_Envase2
            TablaXEnvase.Rows(Renglon).Item("Canti2") = txt_Canti2
            TablaXEnvase.Rows(Renglon).Item("Envase3") = txt_Envase3
            TablaXEnvase.Rows(Renglon).Item("Canti3") = txt_Canti3

            VectorXEspecificaciones(Renglon) = txt_Especificaciones.Text



            TablaXDatosMuestra.Rows(Renglon).Item("NombreComecial") = txt_NombreComercialMl.Text
            TablaXDatosMuestra.Rows(Renglon).Item("OrdenTrabajo") = txt_OrdenTrabajo.Text
            TablaXDatosMuestra.Rows(Renglon).Item("Referencia") = txt_Referencia.Text


            
        End If

    End Sub


    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_Fila.Text = ""
        txt_CodProduc.Text = "  -     -   "
        txt_ProducDescrip.Text = ""
        txt_Cantidad.Text = ""
        txt_PrecioProduc.Text = ""
        txt_Version.Text = ""
        Lbl_Stock.Text = "0"
        lbl_StkPedido.Text = "0"
        lbl_Produccion.Text = "0"
        lbl_Disponible.Text = "0"
        Lbl_WStock1.Text = "0"
        Lbl_WStock2.Text = "0"
        Lbl_WStock3.Text = "0"
        Lbl_WStock4.Text = "0"
        Lbl_WStock5.Text = "0"
        Lbl_WStock6.Text = "0"
        Lbl_WStock7.Text = "0"

        txt_NombreComercialMl.Text = ""
        txt_OrdenTrabajo.Text = ""
        txt_Referencia.Text = ""


        lbl_Envase1.Text = ""
        lbl_Envase2.Text = ""
        lbl_Envase3.Text = ""
        lbl_Envase4.Text = ""
        lbl_Envase5.Text = ""
        lbl_Envase6.Text = ""

        lbl_Abre1.Text = ""
        lbl_Abre2.Text = ""
        lbl_Abre3.Text = ""
        lbl_Abre4.Text = ""
        lbl_Abre5.Text = ""
        lbl_Abre6.Text = ""

        lbl_Capa1.Text = ""
        lbl_Capa2.Text = ""
        lbl_Capa3.Text = ""
        lbl_Capa4.Text = ""
        lbl_Capa5.Text = ""
        lbl_Capa6.Text = ""

        txt_Envase1.Text = ""
        txt_Envase2.Text = ""
        txt_Envase3.Text = ""

        txt_Canti1.Text = ""
        txt_Canti2.Text = ""
        txt_Canti3.Text = ""

        txt_Especificaciones.Text = ""

        txt_Pedido.Text = ""
        txt_Cliente.Text = ""
        txt_ClienteDescrip.Text = ""
        txt_Precio.Text = ""
        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_FechaEntrega.Text = "  /  /    "
        txt_Hora.Text = ""
        txt_Pago.Text = ""
        _txt_PagoDescrip.Text = ""
        txt_Observaciones.Text = ""
        txt_OrdenCompra.Text = ""
        WCalcula = "N"
        txt_FechaEntrega.Enabled = False
        WCalcula = "S"

        cbx_TipoPedido.SelectedIndex = 0
        cbx_Via.SelectedIndex = 0

        pnl_DirEntrega.Visible = False
        pnl_EntraNombre.Visible = False
        pnl_EntraNombreMl.Visible = False
        pnl_Especificaciones.Visible = False


        TablaXEnvase.Rows.Clear()
        Erase VectorXEspecificaciones
        TablaXDatosMuestra.Rows.Clear()

        DGV_DirEntrega.Rows.Clear()

        txt_Pedido.Text = ""


        txt_Pedido.Focus()

    End Sub

  
    

    Private Sub DGV_Pedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Pedido.CellDoubleClick

        If e.ColumnIndex <> -1 Then

            If Len(DGV_Pedido.CurrentRow.Cells("Producto").Value) = 12 Then
                txt_Fila.Text = DGV_Pedido.CurrentRow.Index
                txt_CodProduc.Text = DGV_Pedido.CurrentRow.Cells("Producto").Value
            End If


            txt_ProducDescrip.Text = DGV_Pedido.CurrentRow.Cells("Descripcion").Value


            If Val(DGV_Pedido.CurrentRow.Cells("Cantidad").Value) <> 0 Then
                txt_Cantidad.Text = formatonumerico(DGV_Pedido.CurrentRow.Cells("Cantidad").Value, 2)
            Else
                txt_Cantidad.Text = ""
            End If


            txt_Precio.Text = formatonumerico(DGV_Pedido.CurrentRow.Cells("Precio").Value)

            Dim WLugar As Integer = DGV_Pedido.CurrentRow.Index

            txt_Envase1.Text = TablaXEnvase.Rows(WLugar).Item("Envase1")
            txt_Canti1.Text = TablaXEnvase.Rows(WLugar).Item("Canti1")
            txt_Envase2.Text = TablaXEnvase.Rows(WLugar).Item("Envase2")
            txt_Canti2.Text = TablaXEnvase.Rows(WLugar).Item("Canti2")
            txt_Envase3.Text = TablaXEnvase.Rows(WLugar).Item("Envase3")
            txt_Canti3.Text = TablaXEnvase.Rows(WLugar).Item("Canti3")

            txt_Especificaciones.Text = VectorXEspecificaciones(WLugar)

            txt_NombreComercialMl.Text = TablaXDatosMuestra.Rows(WLugar).Item("NombreComercial")
            txt_OrdenTrabajo.Text = TablaXDatosMuestra.Rows(WLugar).Item("OrdenTrabajo")
            txt_Referencia.Text = TablaXDatosMuestra.Rows(WLugar).Item("Referencia")


            lbl_StkPedido.Text = StkPed()
            If Microsoft.VisualBasic.Left$(txt_CodProduc.Text, 2) <> "ML" Then
                Call Busca_Stock()
            End If

            txt_CodProduc.Focus()
        End If

    End Sub

    Private Sub btn_BajaPedido_Click(sender As Object, e As EventArgs) Handles btn_BajaPedido.Click

        If MsgBox("¿Desea eliminar el pedido nro. : " & txt_Pedido.Text & "?", vbYesNo) = vbYes Then
            Dim SQLCnslt As String = "DELETE PedidoSol WHERE Pedido = '" & txt_Pedido.Text & "'"

            ExecuteNonQueries(Operador.Base, {SQLCnslt})

            btn_Limpiar_Click(Nothing, Nothing)
        End If

        txt_Pedido.Focus()
    End Sub

    Private Sub DGV_Pedido_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Pedido.RowHeaderMouseDoubleClick
        With DGV_Pedido.CurrentRow
            If MsgBox("Desea borrar el Producto: " & Trim(.Cells("Producto").Value) & " con un cantidad de: " & .Cells("Cantidad").Value, vbYesNo) = vbYes Then
                Dim Posicion As Integer = .Index
                DGV_Pedido.Rows.RemoveAt(Posicion)
            End If

        End With
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()

    End Sub

  
    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click

        Dim listaSQlCnslt As New List(Of String)

        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")

        If txt_FechaEntrega.Text = "00/00/0000" Or txt_FechaEntrega.Text = "  /  /    " Then
            MsgBox("No esta informada la fecha de entrega", 0, "INGRESO DE PEDIDOS")
            Exit Sub
        End If

        Dim WFechaord As String = ordenaFecha(txt_Fecha.Text)
        Dim WOrdFecEntrega As String = ordenaFecha(txt_FechaEntrega.Text)
        If WFechaord > WOrdFecEntrega Then

            MsgBox("La fecha de entrega no puede ser menor a la fecha del pedido", 0, "INGRESO DE PEDIDOS")
            Exit Sub
        End If

        If UCase(Operador.Base) = UCase("SurfactanSa") Then
            Dim ZZPasaMsds As String = Verifica_Msds()
            If ZZPasaMsds = "N" Then
                Exit Sub
            End If
        End If

        Dim WFechaInicial As String = txt_FechaEntrega.Text
        Dim WOrdFechaInicial As String = WOrdFecEntrega

        Dim XPasa As String = "S"
        Dim WLLave As Integer = 0
        Dim ZNroSedronar As String = ""

        Dim ZImpreVto As Integer = 0

        Dim SQLCnslt As String = "SELECT NroSedronar, ImpreVto FROM Cliente WHERE Cliente = '" & txt_Cliente.Text & "'"

        Dim RowCliente As DataRow = GetSingle(SQLCnslt, Operador.Base)
        If RowCliente IsNot Nothing Then
            ZNroSedronar = Trim(IIf(IsDBNull(RowCliente.Item("NroSedronar")), "", RowCliente.Item("NroSedronar")))
            ZImpreVto = IIf(IsDBNull(RowCliente.Item("ImpreVto")), "0", RowCliente.Item("ImpreVto"))

        End If

        Dim ZVeriSedronar As String = "N"

        For Each DGV_Row As DataGridViewRow In DGV_Pedido.Rows


            Dim Articulo As String = UCase(DGV_Row.Cells("Producto").Value)


            Dim WCantidad As String = DGV_Row.Cells("Producto").Value

            If Val(Cantidad) <> 0 Then

                Dim WCliente As String = UCase(txt_Cliente.Text)
                Dim WTerminado As String = UCase(Articulo)
                Dim WClave As String = WCliente + WTerminado
                Dim Xpago As Integer = 0

                Dim WEnvase1 As String = TablaXEnvase(DGV_Row.Index).Item(1)
                If Val(WEnvase1) = 0 Then
                     MsgBox("Se debe informar envases", 0, "Emision de Facturas")
                    Exit Sub
                End If

                SQLCnslt = "SELECT Pago FROM Precios WHERE Clave = '" & WClave & "'"
                Dim RowPrecios As DataRow = GetSingle(SQLCnslt, Operador.Base)


                If RowPrecios IsNot Nothing Then
                    Xpago = IIf(IsDBNull(RowPrecios.Item("Pago")), 0, RowPrecios.Item("Pago"))
                    If Xpago = Val(txt_Pago.Text) Then
                        Xpago = 0
                    End If

                End If

                Dim XTipoPro As String
                Dim XCodigo As Integer = Val(Mid$(WTerminado, 4, 5))
                If Microsoft.VisualBasic.Left$(WTerminado, 2) <> "PT" Then
                    Select Case Microsoft.VisualBasic.Left$(WTerminado, 2)
                        Case "DY", "DS"
                            XTipoPro = "CO"
                        Case "QC"
                            XTipoPro = "FA"
                        Case Else
                            XTipoPro = "PT"
                    End Select
                Else
                    If XCodigo >= 0 And XCodigo <= 999 Then
                        XTipoPro = "CO"
                    Else
                        If XCodigo >= 11000 And XCodigo <= 12999 Then
                            XTipoPro = "CO"
                        Else
                            If XCodigo >= 25000 And XCodigo <= 25999 Then
                                XTipoPro = "FA"
                            Else
                                If XCodigo >= 2300 And XCodigo <= 2399 Then
                                    XTipoPro = "BI"
                                Else
                                    XTipoPro = "PT"
                                End If
                            End If
                        End If
                    End If
                End If

                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "YQ" Then
                    XTipoPro = "PT"
                End If
                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "YH" Then
                    XTipoPro = "PT"
                End If
                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "YP" Then
                    XTipoPro = "PT"
                End If
                If Microsoft.VisualBasic.Left$(WTerminado, 2) = "YF" Then
                    XTipoPro = "FA"
                End If

                Dim ZSedronar As Integer = 0
                Dim ZLinea As Integer = 0

                SQLCnslt = "SELECT Sedronar, Linea FROM Terminado WHERE Codigo = '" & WTerminado & "''"

                Dim RowTermi As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowTermi IsNot Nothing Then
                    ZLinea = RowTermi.Item("Linea")
                    ZSedronar = IIf(IsDBNull(RowTermi.Item("Sedronar")), "0", RowTermi.Item("Sedronar"))

                End If

                If ZSedronar = 1 Then
                    ZVeriSedronar = "S"
                End If

                Select Case ZLinea
                    Case 8
                        XTipoPro = "PG"
                    Case 10, 20, 22, 24, 25, 26, 27, 28, 29, 30
                        XTipoPro = "FA"
                    Case Else
                End Select

                REM If UCase(Cliente.Text) = "S00130" Then
                REM     XTipoPro = "CO"
                REM End If

                Dim WConpago As Integer
                Dim WTipopro As String

                If WLLave = 0 Then
                    WLLave = 1
                    WConpago = Xpago
                    WTipopro = XTipoPro
                End If

                If WConpago <> Xpago Then
                    XPasa = "1"
                End If

                If WTipopro <> XTipoPro Then
                    XPasa = "2"
                End If

                If Microsoft.VisualBasic.Left$(WTerminado, 4) = "PT-5" Then

                    If UCase(Operador.Base) = UCase("SurfactanSa") And txt_CodProduc.Text = "P00005" Then

                        Dim ZPasa As String = "S"

                        
                        Dim ZZTerminado As String = "PT-0" + Mid$(WTerminado, 5, 8)

                        SQLCnslt = "SELECT Estado, EstadoII FROM Terminado WHERE Codigo = '" & ZZTerminado & "'"
                        Dim RowTermiPelli As DataRow = GetSingle(SQLCnslt, "Pellital_III")
                        If RowTermiPelli IsNot Nothing Then

                            Dim WEstadoI As String = IIf(IsDBNull(RowTermiPelli.Item("Estado")), "", RowTermiPelli.Item("Estado"))
                            Dim WEstadoIII As String = IIf(IsDBNull(RowTermiPelli.Item("Estado")), "", RowTermiPelli.Item("EstadoII"))



                            If WEstadoI <> "S" Or WEstadoIII <> "S" Then
                                Dim m As String = "El Producto Terminado no se encuentra autorizado para la Faturacion"
                                If WEstadoI <> "S" Then
                                    m = m & vbCrLf & "(No se encuentra habilitada la formula)"
                                End If
                                If WEstadoIII <> "S" Then
                                    m = m & vbCrLf & "(No se encuentra habilitada las especificaciones)"
                                End If
                                MsgBox(m, 0, "Emision de Facturas")
                                ZPasa = "N"
                            End If

                        Else


                            MsgBox("Producto Terminado Inexistente", 0, "Emision de Facturas")
                            ZPasa = "N"

                        End If

                      
                        If ZPasa = "N" Then
                            Exit Sub
                        End If

                    Else

                        If Microsoft.VisualBasic.Left$(UCase(WTerminado), 2) = "PT" Then

                            SQLCnslt = "SELECT Estado, EstadoII FROM Terminado WHERE Codigo = '" & WTerminado & "'"
                            Dim rowTerminad As DataRow = GetSingle(SQLCnslt, Operador.Base)
                            If rowTerminad IsNot Nothing Then
                                Dim WEstadoI As String = IIf(IsDBNull(rowTerminad.Item("Estado")), "", rowTerminad.Item("Estado"))
                                Dim WEstadoIII As String = IIf(IsDBNull(rowTerminad.Item("EstadoII")), "", rowTerminad.Item("EstadoII"))



                                If WEstadoI <> "S" Or WEstadoIII <> "S" Then
                                    Dim m As String = "El Producto Terminado no se encuentra autorizado para la Faturacion"
                                    If WEstadoI <> "S" Then
                                        m = m & vbCrLf & "(No se encuentra habilitada la formula)"
                                    End If
                                    If WEstadoIII <> "S" Then
                                        m = m & vbCrLf & "(No se encuentra habilitada las especificaciones)"
                                    End If
                                    MsgBox(m, 0, "Emision de Facturas")
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If

                Else

                    If Microsoft.VisualBasic.Left$(UCase(WTerminado), 2) = "PT" Then

                        SQLCnslt = "SELECT Estado, EstadoIIFROM Terminado WHERE Codigo = '" & WTerminado & "'"
                        Dim rowTerminad As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        If rowTerminad IsNot Nothing Then
                            Dim WEstadoI As String = IIf(IsDBNull(rowTerminad.Item("Estado")), "", rowTerminad.Item("Estado"))
                            Dim WEstadoIII As String = IIf(IsDBNull(rowTerminad.Item("EstadoII")), "", rowTerminad.Item("EstadoII"))


                            If WEstadoI <> "S" Or WEstadoIII <> "S" Then
                                Dim m As String = "El Producto Terminado no se encuentra autorizado para la Faturacion"
                                If WEstadoI <> "S" Then
                                    m = m & vbCrLf & "(No se encuentra habilitada la formula)"
                                End If
                                If WEstadoIII <> "S" Then
                                    m = m & vbCrLf & "(No se encuentra habilitada las especificaciones)"
                                End If
                                MsgBox(m, 0, "Emision de Facturas")
                                Exit Sub
                            End If

                        End If

                    End If

                End If

                If ZImpreVto = 1 Then

                    Dim ZVida As Integer = 0

                    If Microsoft.VisualBasic.Left$(WTerminado, 2) = "PT" Or Microsoft.VisualBasic.Left$(WTerminado, 2) = "YQ" Or Microsoft.VisualBasic.Left$(WTerminado, 2) = "YF" Or Microsoft.VisualBasic.Left$(WTerminado, 2) = "YP" Or Microsoft.VisualBasic.Left$(WTerminado, 2) = "YH" Then
                        SQLCnslt = "SELECT Vida FROM Terminado WHERE Codigo = '" & WTerminado & "'"
                        Dim Row_Termi As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        
                        If Row_Termi IsNot Nothing Then
                            ZVida = IIf(IsDBNull(Row_Termi.Item("Vida")), "0", Row_Termi.Item("Vida"))

                        End If
                    Else

                        Dim WArti As String = Microsoft.VisualBasic.Left$(WTerminado, 3) + Microsoft.VisualBasic.Right$(WTerminado, 7)
                        SQLCnslt = "SELECT Meses FROM Articulo WHERE Codigo = '" & WArti & "'"
                        Dim Row_Arti As DataRow = GetSingle(SQLCnslt, Operador.Base)

                        If Row_Arti IsNot Nothing Then
                            ZVida = IIf(IsDBNull(Row_Arti.Item("Meses")), "0", Row_Arti.Item("Meses"))

                        End If
                    End If

                    If ZVida = 0 Then
                        Dim m As String = "Atencion: El producto terminado " + WTerminado + " no posee vida util y el cliente lo exige"
                        MsgBox(m, 0, "INGRESO DE PEDIDOS")
                        Exit Sub
                    End If

                End If
            End If

        Next

        If UCase(Operador.Base) = UCase("SurfactanSa") Then

            If XPasa = "1" Then
                Dim m As String = "Se cargaron articulos con distinta condicion de pago"
                MsgBox(m, 0, "INGRESO DE PEDIDOS")
                Exit Sub
            End If

            If XPasa = "2" Then
                Dim m As String = "Se cargaron articulos PT, Biosidas, Farma, Pigmentos o Colorantes en forma conjunta un mismo Pedido"
                MsgBox(m, 0, "INGRESO DE PEDIDOS")
                Exit Sub
            End If

        End If

        If ZVeriSedronar = "S" Then
            If Trim(ZNroSedronar) = "" Then
                Dim m As String = "Atencion: El cliente debe estar inscripto en el Sedronar para adquirir estos productos"
                MsgBox(m, 0, "INGRESO DE PEDIDOS")
            End If
        End If

        Dim Xversion As Integer = 0

        If Val(txt_Pedido.Text) = 0 Then

            SQLCnslt = "Select PedidoMayor = Max(Pedido) FROM PedidoSol"
            Dim RowPedido As DataRow = GetSingle(SQLCnslt, Operador.Base)

            If RowPedido IsNot Nothing Then

                Dim WPedidoMayor As Integer = IIf(IsDBNull(RowPedido.Item("PedidoMayor")), 0, RowPedido.Item("PedidoMayor"))
                txt_Pedido.Text = Trim(Str$(WPedidoMayor + 1))

            End If
        Else
            txt_Pedido.Text = "1"
        End If

        SQLCnslt = "DELETE Pedido WHERE Pedido = '" & txt_Pedido.Text & "'"

        listaSQlCnslt.Add(SQLCnslt)

        Dim Auxiliar As New DataTable
        With Auxiliar.Columns
            .Add("Articulo")
            .Add("Cantidad")
        End With

        Dim Renglon As Integer = 0
        Dim _WRenglon As Integer = 0


        For Each DGV_ROw As DataGridViewRow In DGV_Pedido.Rows


            Dim WLugar As Integer = DGV_ROw.Index


            Dim Articulo As String = UCase(DGV_ROw.Cells("Producto").Value)


            Dim NombreComercial As String = DGV_ROw.Cells("Descripcion").Value


            Dim Cantidad As String = DGV_ROw.Cells("Cantidad").Value


            Dim Precio As String = DGV_ROw.Cells("Precio").Value

            If Val(Cantidad) <> 0 Then

                Renglon = Renglon + 1
                _WRenglon = _WRenglon + 1

                Auxiliar.Rows.Add()
                Auxiliar.Rows(_WRenglon - 1).Item("Articulo") = Articulo
                Auxiliar.Rows(_WRenglon - 1).Item("Cantidad") = Cantidad

                Dim Auxi As String = Str$(Renglon).PadLeft(2, "0")


                Dim Auxi1 As String = txt_Pedido.Text.PadLeft(6, "0")


                Dim WPedido As String = txt_Pedido.Text
                Dim WRenglon As String = Str$(Renglon)
                Dim WCliente As String = txt_Cliente.Text
                Dim WFecha As String = txt_Fecha.Text
                Dim WFecEntrega As String = txt_FechaEntrega.Text
                Dim WHora As String = txt_Hora.Text
                Dim WObservaciones As String = txt_Observaciones.Text
                Dim WOrdenCpa As String = txt_OrdenCompra.Text
                Dim WTerminado As String = Articulo
                Dim WCantidad As String = Cantidad
                REM aca se reemplaza la rutina de cambio envase
                Dim WEnvase1 As String = TablaXEnvase.Rows(WLugar).Item("Envase1")
                Dim WCanti1 As String = TablaXEnvase.Rows(WLugar).Item("Canti1")
                Dim WEnvase2 As String = TablaXEnvase.Rows(WLugar).Item("Envase2")
                Dim WCanti2 As String = TablaXEnvase.Rows(WLugar).Item("Canti2")
                Dim WEnvase3 As String = TablaXEnvase.Rows(WLugar).Item("Envase3")
                Dim WCanti3 As String = TablaXEnvase.Rows(WLugar).Item("Canti3")
                Dim WEspecificaciones As String = VectorXEspecificaciones(WLugar)
                Dim WOrdenTrabajo As String = TablaXDatosMuestra.Rows(WLugar).Item("OrdenTrabajo")
                Dim WReferencia As String = TablaXDatosMuestra.Rows(WLugar).Item("Referencia")
                Dim WEnvase4 As String = 0
                Dim WCanti4 As String = ""
                WFechaord = ordenaFecha(txt_Fecha.Text)
                WOrdFecEntrega = ordenaFecha(txt_FechaEntrega.Text)
                Dim WPrecio As String = Precio
                '  Dim WWLinea As String = Linea
                Dim WFacturado As String = ""
                Dim WImporte As String = ""
                Dim WClave As String = Auxi1 + Auxi
                Dim WAutorizo As String = "N"
                Dim WImpresion As String = "N"
                Dim WTipoPed As String = Str$(cbx_TipoPedido.SelectedIndex)
                Dim WCantidad1 As String = ""
                Dim WCantidad2 As String = ""
                Dim WLote1 As String = "0"
                Dim WLote2 As String = "0"
                Dim Wlote3 As String = "0"
                Dim WLote4 As String = "0"
                Dim WLote5 As String = "0"
                Dim WCantiLote1 As String = "0"
                Dim WCantiLote2 As String = "0"
                Dim WCantiLote3 As String = "0"
                Dim WCantiLote4 As String = "0"
                Dim WCantiLote5 As String = "0"
                Dim WEnv1 As String = "0"
                Dim WEnv2 As String = "0"
                Dim WEnv3 As String = "0"
                Dim WEnv4 As String = "0"
                Dim WEnv5 As String = "0"
                Dim WCantiEnv1 As String = "0"
                Dim WCantiEnv2 As String = "0"
                Dim WCantiEnv3 As String = "0"
                Dim WCantiEnv4 As String = "0"
                Dim WCantiEnv5 As String = "0"
                Dim WVersion As String = Str$(Xversion + 1)

                Dim WTipopro As String
                Dim WArti As String
                If Microsoft.VisualBasic.Left$(Articulo, 2) <> "PT" And Microsoft.VisualBasic.Left$(Articulo, 2) <> "YQ" And Microsoft.VisualBasic.Left$(Articulo, 2) <> "YF" And Microsoft.VisualBasic.Left$(Articulo, 2) <> "YP" And Microsoft.VisualBasic.Left$(Articulo, 2) <> "YH" Then
                    WTipopro = "M"
                    WArti = Microsoft.VisualBasic.Left$(Articulo, 3) + Microsoft.VisualBasic.Right$(Articulo, 7)
                Else
                    WTipopro = "T"
                    WArti = "  -   -   "
                End If
                Dim WVia As String = Str$(cbx_Via.SelectedIndex)

                'SE COMENTA PARA QUE NO TIRE ERROR
                '         SQLCnslt = "INSERT INTO PedidoSol (" _
                '                     & "Clave ," _
                '                     & "Pedido ," _
                '                     & "Renglon ," _
                '                     & "Cliente ," _
                '                     & "Fecha ," _
                '                     & "FecEntrega ," _
                '                     & "Hora ," _
                '                     & "Observaciones ," _
                '                     & "Terminado ," _
                '                     & "Cantidad ," _
                '                     & "Envase1 ," _
                '                     & "Canti1 ," _
                '                     & "Envase2 ," _
                '                     & "Canti2 ," _
                '                     & "Envase3 ," _
                '                     & "Canti3 ," _
                '                     & "Envase4 ," _
                '                     & "Canti4 ," _
                '                     & "FechaOrd ," _
                '                     & "Precio ," _
                '                     & "Linea ," _
                '                     & "Facturado ," _
                '                     & "Importe ," _
                '                     & "Autorizo ," _
                '                     & "Impresion ," _
                '                     & "TipoPed ," _
                '                     & "Cantidad1 ," _
                '                     & "Cantidad2 ," _
                '                     & "Lote1 ," _
                '                     & "CantiLote1 ," _
                '                     & "Lote2 ," _
                '                     & "CantiLote2 ," _
                '                     & "Lote3 ," _
                '                     & "CantiLote3 ," _
                '                     & "Lote4 ," _
                '                     & "CantiLote4 ," _
                '                     & "Lote5 ," _
                '                     & "CantiLote5 ," _
                '                     & "Env1 ," _
                '                     & "CantiEnv1 ," _
                '                     & "Env2 ," _
                '                     & "CantiEnv2 ," _
                '                     & "Env3 ," _
                '                     & "CantiEnv3 ," _
                '                     & "Env4 ," _
                '                     & "CantiEnv4 ," _
                '                     & "Env5 ," _
                '                     & "CantiEnv5 ," _
                '                     & "Version ," _
                '                     & "OrdFecEntrega ," _
                '                     & "OrdenCpa ," _
                '                     & "TipoPro ," _
                '                     & "Articulo )" _
                '         & "Values (" _
                '         & " '" & WClave & "'," _
                '         & " '" & WPedido & "'," _
                '         & " '" & WRenglon & "'," _
                '         & " '" & WCliente & "'," _
                '         & " '" & WFecha & "'," _
                '         & " '" & WFecEntrega & "'," _
                '         & " '" & WHora & "'," _
                '         & " '" & WObservaciones & "'," _
                '         & " '" & WTerminado & "'," _
                '         & " '" & WCantidad & "'," _
                '         & " '" & WEnvase1 & "'," _
                '         & " '" & WCanti1 & "'," _
                '         & " '" & WEnvase2 & "'," _
                '         & " '" & WCanti2 & "'," _
                '         & " '" & WEnvase3 & "'," _
                '         & " '" & WCanti3 & "'," _
                '         & " '" & WEnvase4 & "'," _
                '         & " '" & WCanti4 & "'," _
                '         & " '" & WFechaord & "'," _
                '         & " '" & WPrecio & "'," _
                '         & " '" & WLinea & "'," _
                '         & " '" & WFacturado & "'," _
                '         & " '" & WImporte & "'," _
                '         & " '" & WAutorizo & "'," _
                '         & " '" & WImpresion & "'," _
                '         & " '" & WTipoPed & "'," _
                '         & " '" & WCantidad1 & "'," _
                '         & " '" & WCantidad2 & "'," _
                '         & " '" & WLote1 & "'," _
                '         & " '" & WCantiLote1 & "'," _
                '         & " '" & WLote2 & "'," _
                '         & " '" & WCantiLote2 & "'," _
                '         & " '" & Wlote3 & "'," _
                '         & " '" & WCantiLote3 & "'," _
                '         & " '" & WLote4 & "'," _
                '         & " '" & WCantiLote4 & "'," _
                '         & " '" & WLote5 & "'," _
                '         & " '" & WCantiLote5 & "'," _
                '         & " '" & WEnv1 & "'," _
                '         & " '" & WCantiEnv1 & "'," _
                '         & " '" & WEnv2 & "'," _
                '         & " '" & WCantiEnv2 & "'," _
                '         & " '" & WEnv3 & "'," _
                '         & " '" & WCantiEnv3 & "'," _
                '         & " '" & WEnv4 & "'," _
                '         & " '" & WCantiEnv4 & "'," _
                '         & " '" & WEnv5 & "'," _
                '         & " '" & WCantiEnv5 & "'," _
                '         & " '" & WVersion & "'," _
                '         & " '" & WOrdFecEntrega & "'," _
                '         & " '" & WOrdenCpa & "'," _
                '         & " '" & WTipopro & "'," _
                '         & " '" & WArti & "')"

                listaSQlCnslt.Add(SQLCnslt)

                Dim ZZDesCliente As String = ""
                Dim ZZVendedor As String = ""
                Dim ZZDesVendedor As String = ""

                SQLCnslt = "SELECT Razon, Vendedor FROM Cliente WHERE Cliente = '" & txt_Cliente.Text & "'"
                Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCli IsNot Nothing Then
                    ZZDesCliente = RowCli.Item("Razon")
                    ZZVendedor = Str$(RowCli.Item("Vendedor"))

                End If

                SQLCnslt = "SELECT Nombre FROM Vendedor WHERE Vendedor = '" & ZZVendedor & "'"
                Dim RowVendedor As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowVendedor IsNot Nothing Then
                    ZZDesVendedor = RowVendedor.Item("Nombre")

                End If

                SQLCnslt = "UPDATE PedidoSol SET" _
                            & " DesCliente = " + "'" + ZZDesCliente + "'," _
                            & " DesVendedor = " + "'" + ZZDesVendedor + "'," _
                            & " Vendedor = " + "'" + ZZVendedor + "'," _
                            & " NombreComercial = " + "'" + NombreComercial + "'," _
                            & " OrdenTrabajo = " + "'" + WOrdenTrabajo + "'," _
                            & " Referencia = " + "'" + WReferencia + "'," _
                            & " Via = " + "'" + WVia + "'" _
                            & " Where Clave = " + "'" + WClave + "'"

                listaSQlCnslt.Add(SQLCnslt)


            End If

        Next

        ExecuteNonQueries(Operador.Base, listaSQlCnslt.ToArray())

        'SE COMENTA PARA QUE NO TIRE ERROR
        '' If MsgBox("Desea Imprimir la solicitud del pedido", vbYesNo) = vbYes Then
        ''Call Impresion()
        '' End If

        btn_Limpiar_Click(Nothing, Nothing)
        txt_Pedido.Focus()

    End Sub



    Private Function Verifica_Msds() As String

        Dim ZZRequiereMsds As Integer = 0
        Dim ZZRequiereMsdsCada As Integer = 0
        Dim ZZBusqueda As String = ""
        Dim ZZPasaMsds As String = "S"

        Dim SQLCnslt As String = "SELECT RequiereMsds, RequiereMsdsCada FROM ClienteEspeci WHERE Cliente = '" & txt_Cliente.Text & "'"
        Dim RowClienEspef As DataRow = GetSingle(SQLCnslt, Operador.Base)
        If RowClienEspef IsNot Nothing Then

            ZZRequiereMsds = IIf(IsDBNull(RowClienEspef.Item("RequiereMsds")), "0", RowClienEspef.Item("RequiereMsds"))
            ZZRequiereMsdsCada = IIf(IsDBNull(RowClienEspef.Item("RequiereMsdsCada")), "0", RowClienEspef.Item("RequiereMsdsCada"))

        End If
        ' SE PARA EL DESARROLLO POR POSIBLE INUTILIDAD
        'For Each DGV_Row As DataGridViewRow In DGV_Pedido.Rows
        '
        '    Dim Articulo As String = UCase(WVector1.TextMatrix(a, 1))
        '    Dim ZZDescriArticulo As String = UCase(WVector1.TextMatrix(a, 2))
        '    Dim Cantidad As String = WVector1.TextMatrix(a, 3)
        '
        '    Dim ZZValida As String = "S"
        '    Dim WTerminado As String = Articulo
        '    XCodigo = Val(Mid$(WTerminado, 4, 5))
        '    If Left$(WTerminado, 2) = "PT" Then
        '
        '        If XCodigo >= 0 And XCodigo <= 999 Then
        '            XTipoPro = "CO"
        '        Else
        '            If XCodigo >= 11000 And XCodigo <= 12999 Then
        '                XTipoPro = "CO"
        '            Else
        '                If XCodigo >= 25000 And XCodigo <= 25999 Then
        '                    XTipoPro = "FA"
        '                Else
        '                    If XCodigo >= 2300 And XCodigo <= 2399 Then
        '                        XTipoPro = "BI"
        '                    Else
        '                        If XCodigo >= 40000 And XCodigo <= 49999 Then
        '                            XTipoPro = "TA"
        '                        Else
        '                            XTipoPro = "PT"
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '
        '        ZLinea = 0
        '        spTerminado = "ConsultaTerminado " + "'" + WTerminado + "'"
        '        rstTerminado = db.OpenRecordset(spTerminado, dbOpenSnapshot, dbSQLPassThrough)
        '        If rstTerminado.RecordCount > 0 Then
        '            ZLinea = rstTerminado!Linea
        '            rstTerminado.Close()
        '        End If
        '
        '        Select Case ZLinea
        '            Case 8
        '                XTipoPro = "PG"
        '            Case 10, 20, 22, 24, 25, 26, 27, 28, 29, 30
        '                XTipoPro = "FA"
        '            Case Else
        '        End Select
        '
        '        If XTipoPro = "FA" Or XTipoPro = "TA" Then
        '            ZZValida = "N"
        '        End If
        '
        '    End If
        '
        '    If Left$(WTerminado, 2) = "YQ" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "YH" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "YP" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "YF" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "ML" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "QC" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "ZE" Then
        '        ZZValida = "N"
        '    End If
        '    If Left$(WTerminado, 2) = "ZT" Then
        '        ZZValida = "N"
        '    End If
        '
        '    If Val(Cantidad) <> 0 And ZZValida = "S" Then
        '
        '        If Val(ZZRequiereMsdsCada) = 1 Then
        '
        '            ZZBusqueda = "S"
        '
        '        Else
        '
        '            ZSql = ""
        '            ZSql = ZSql + "Select *"
        '            ZSql = ZSql + " FROM Estadistica"
        '            ZSql = ZSql + " Where Estadistica.Cliente = " + "'" + Cliente.Text + "'"
        '            ZSql = ZSql + " and Estadistica.Articulo = " + "'" + Articulo + "'"
        '            spEstadistica = ZSql
        '            rstEstadistica = db.OpenRecordset(spEstadistica, dbOpenSnapshot, dbSQLPassThrough)
        '            If rstEstadistica.RecordCount > 0 Then
        '                rstEstadistica.Close()
        '            Else
        '                ZZBusqueda = "S"
        '            End If
        '
        '        End If
        '
        '        If ZZBusqueda = "S" Then
        '
        '            If Left$(UCase(Articulo), 2) = "PT" Then
        '
        '                Es = ZZDescriArticulo
        '                x = ""
        '                For XX = 1 To Len(Es)
        '                    Y = Mid$(Es, XX, 1)
        '                    If Y <> " " And Y <> "/" Then
        '                        x = x + Y
        '                    End If
        '                Next
        '                ZZCodArt = x + Mid$(Articulo, 4, 5) + Right$(Articulo, 3)
        '
        '            Else
        '
        '                ZZCodArt = Mid$(Articulo, 1, 3) + Mid$(Articulo, 6, 7)
        '
        '            End If
        '
        '            ZZRuta = "W:\IMPRESION PDF\MSDSSIS\MSDS" + ZZCodArt + ".PDF"
        '            ZZEstado = Dir(ZZRuta)
        '            ZZEstado = Trim(ZZEstado)
        '            If ZZEstado = "" Then
        '
        '                ZZPasaMsds = "N"
        '
        '                m$ = "El MSDS  (" + ZZCodArt + ")  no se ha encontrado"
        '                AAAAA% = MsgBox(m$, 0, "Impresion de comprobantes varios")
        '
        '                sTo = "dsuarez@surfactan.com.ar; pcorna@surfactan.com.ar; ebiglieri@surfactan.com.ar; isocalidad@surfacatn.com.ar; lalmiron@surfactan.com.ar; textil@surfactan.com.ar"
        '                REM sTo = "d_esquenazi@yahoo.com"
        '                sCC = ""
        '                sBCC = ""
        '                sSubject = "Falta de MSDS"
        '                sBody = "Falta de MSDS del " + ZZCodArt + "para el cliente " + DesCliente.Caption + "  Pedido Nro.:" + Pedido.Text + " fecha de entrega:" + FecEntrega.Text + "  (" + Tipoped.Text + ")"
        '                SFile = ""
        '
        '                EmailAddress = sTo
        '                CopiaAddress = sCC
        '                MSubject = sSubject
        '                MBody = sBody
        '                MAttach = ""
        '                MAttachI = ""
        '                MAttachII = ""
        '                MAttachIII = ""
        '                MAttachIV = ""
        '                MAttachVI = ""
        '                MAttachVII = ""
        '                MAttachVIII = ""
        '
        '                SendEmail()
        '
        '            End If
        '
        '        End If
        '    End If
        '
        'Next a
        '
    End Function

End Class