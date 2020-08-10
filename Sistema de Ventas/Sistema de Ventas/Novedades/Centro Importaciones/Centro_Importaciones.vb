Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper


Public Class Centro_Importaciones


    'VariablesGlobales en Version vieja
    Dim Seleccion As String
    Dim SeleccionII As String

    Dim SeleccionIII As String
    Dim SeleccionIV As String

    Dim SeleccionV As String
    Dim SeleccionVI As String

    Dim ColumnaOpcion As Integer
    Dim ColumnaOpcionII As Integer
    Dim ColumnaOpcionIII As Integer
    Dim ZZCiclaProceso As String


    Dim FiltroVtoI As String
    Dim FiltroVtoII As String
    Dim ZProcesa As String
    'Fin de Globales

   



    Private Sub Proceso_Click()

        '  If ZProcesa = "N" Then
        '     Exit Sub
        '   End If



        DGV_Muestra.Rows.Clear()



        If Seleccion = "" Then
            ColumnaOpcion = 0
        End If

        If SeleccionIII = "" Then
            ColumnaOpcionII = 0
        End If

        If SeleccionV = "" Then
            ColumnaOpcionIII = 0
        End If


        Dim VectorEmpresas(8) As String

        VectorEmpresas(1) = "SurfactanSa"
        VectorEmpresas(2) = "Surfactan_II"
        VectorEmpresas(3) = "Surfactan_III"
        VectorEmpresas(4) = "Surfactan_V"
        VectorEmpresas(5) = "Surfactan_VI"
        VectorEmpresas(6) = "Surfactan_VII"


        Dim SQLCnslt As String = ""


        Dim TablaAenviar As New DataTable
        With TablaAenviar.Columns
            .Add("Orden")
            .Add("Carpeta")
            .Add("Proveedor")
            .Add("FechaInforme")
            .Add("Empresa")
        End With
        Dim Lugar As Integer = 0


        Dim LugarTabla As Integer = 0
        Dim TablaPasa As New DataTable
        With TablaPasa.Columns
            .Add("Empresa")
            .Add("Orden")
            .Add("Carpeta")
            .Add("Proveedor")
            .Add("ImpoLetra")
            .Add("ImpoDespacho")
            .Add("PagoLetra")
            .Add("PagoDespacho")
            .Add("TipoPago")
        End With



        If ZZCiclaProceso = "S" Then

            For CiclaEmpresa = 1 To 6


                SQLCnslt = "UPDATE Orden SET " _
                & " MarcaActualiza = '" & "" & "'" _
                & " Where MarcaActualiza IS NULL"

                ExecuteNonQueries({SQLCnslt}, VectorEmpresas(CiclaEmpresa))



                SQLCnslt = "Select Orden, Carpeta, Impoletra, Impodespacho," _
                    & " Proveedor, PagoLetra, PagoDespacho, TipoPago, Baja" _
                    & " FROM Orden " _
                    & " WHERE Tipo = '1'" _
                    & " AND Cantidad <> 0" _
                    & " AND Renglon = 1" _
                    & " AND FechaOrd >= '20140101'" _
                    & " ORDER BY Clave"

                Dim TablaOrden As DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))

                If TablaOrden.Rows.Count > 0 Then

                    For Each RowOrden As DataRow In TablaOrden.Rows

                        Dim ZZPagoLetra As String = IIf(IsDBNull(RowOrden.Item("PagoLetra")), "0", RowOrden.Item("PagoLetra"))
                        Dim ZZPagoDespacho As String = IIf(IsDBNull(RowOrden.Item("PagoDespacho")), "0", RowOrden.Item("PagoDespacho"))
                        Dim ZZBaja As String = IIf(IsDBNull(RowOrden.Item("Baja")), "", RowOrden.Item("Baja"))

                        REM If Val(rstOrden!Carpeta) = 3515 Then Stop

                        If (ZZPagoLetra <> 1 And ZZPagoDespacho <> 1) Or ZZBaja <> "S" Then

                            TablaPasa.Rows.Add()
                            TablaPasa.Rows(LugarTabla).Item("Empresa") = VectorEmpresas(CiclaEmpresa)
                            TablaPasa.Rows(LugarTabla).Item("Orden") = RowOrden.Item("Orden")
                            TablaPasa.Rows(LugarTabla).Item("Carpeta") = RowOrden.Item("Carpeta")
                            TablaPasa.Rows(LugarTabla).Item("Proveedor") = RowOrden.Item("Proveedor")
                            TablaPasa.Rows(LugarTabla).Item("ImpoLetra") = Str$(RowOrden.Item("ImpoLetra"))
                            TablaPasa.Rows(LugarTabla).Item("ImpoDespacho") = Str$(RowOrden.Item("ImpoDespacho"))
                            ZZPagoLetra = IIf(IsDBNull(RowOrden.Item("PagoLetra")), "0", RowOrden.Item("PagoLetra"))
                            ZZPagoDespacho = IIf(IsDBNull(RowOrden.Item("PagoDespacho")), "0", RowOrden.Item("PagoDespacho"))
                            TablaPasa.Rows(LugarTabla).Item("PagoLetra") = ZZPagoLetra
                            TablaPasa.Rows(LugarTabla).Item("PagoDespacho") = ZZPagoDespacho
                            TablaPasa.Rows(LugarTabla).Item("TipoPago") = RowOrden.Item("TipoPago")

                            LugarTabla += 1

                        End If
                    Next


                End If





                Dim TablaPendienteII As New DataTable

                With TablaPendienteII.Columns
                    .Add("Orden")
                    .Add("Carpeta")
                    .Add("Proveedor")
                    .Add("Articulo")
                End With

                LugarTabla = 0

                SQLCnslt = "Select Orden, Carpeta, Proveedor, Articulo" _
                & " FROM Orden" _
                & " WHERE MarcaActualiza = '" & "" & "'" _
                & " AND FechaOrd >= '" & "20140101" & "'" _
                & " AND Renglon = 1" _
                & " AND Tipo = 1" _
                & " ORDER BY Clave"

                Dim TablaOrdenII As DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))
                If TablaOrdenII.Rows.Count > 0 Then
                    For Each RowOrden As DataRow In TablaOrdenII.Rows

                        TablaPendienteII.Rows.Add()

                        TablaPendienteII.Rows(LugarTabla).Item("Orden") = RowOrden.Item("Orden")
                        TablaPendienteII.Rows(LugarTabla).Item("Carpeta") = RowOrden.Item("Carpeta")
                        TablaPendienteII.Rows(LugarTabla).Item("Proveedor") = RowOrden.Item("Proveedor")
                        TablaPendienteII.Rows(LugarTabla).Item("Articulo") = RowOrden.Item("Articulo")

                        LugarTabla += 1
                    Next

                End If



                For Each RowPendiente As DataRow In TablaPendienteII.Rows
                    SQLCnslt = "Select Fecha" _
                               & " FROM Informe " _
                               & " Where Orden ='" & RowPendiente.Item("Orden") & "'" _
                               & " and Articulo = '" & RowPendiente.Item("Articulo") & "'"

                    Dim RowPendi As DataRow = GetSingle(SQLCnslt, VectorEmpresas(CiclaEmpresa))

                    If RowPendi IsNot Nothing Then

                        Dim fechaactual As Date = Date.Today.ToString("MM/dd/yyyy")
                        Dim FechaInforme As Date = RowPendi.Item("Fecha")

                        Dim ZZDias As Integer = DateDiff("d", FechaInforme, fechaactual)

                        If ZZDias > 10 Then

                            TablaAenviar.Rows.Add()
                            TablaAenviar.Rows(Lugar).Item("Orden") = RowPendiente.Item("Orden")
                            TablaAenviar.Rows(Lugar).Item("Carpeta") = RowPendiente.Item("Carpeta")
                            TablaAenviar.Rows(Lugar).Item("Proveedor") = RowPendiente.Item("Proveedor")
                            TablaAenviar.Rows(Lugar).Item("FechaInforme") = RowPendi.Item("Fecha")
                            TablaAenviar.Rows(Lugar).Item("Empresa") = VectorEmpresas(CiclaEmpresa)

                            Lugar += 1

                        End If



                    End If
                Next


            Next CiclaEmpresa


            'ENVIAR A LA OTRA VENTANA TABLAaENVIAR

            With New Centro_Importaciones_CarpetasPendientes(TablaAenviar)
                .Show(Me)
            End With



            For Each RowPasa As DataRow In TablaPasa.Rows

                Dim ZZEmpresa As String = IIf(IsDBNull(RowPasa.Item("Empresa")), "", RowPasa.Item("Empresa"))
                Dim ZZOrden As String = IIf(IsDBNull(RowPasa.Item("Orden")), "", RowPasa.Item("Orden"))
                Dim ZZCarpeta As String = IIf(IsDBNull(RowPasa.Item("Carpeta")), "", RowPasa.Item("Carpeta"))
                Dim ZZProveedor As String = IIf(IsDBNull(RowPasa.Item("Proveedor")), "", RowPasa.Item("Proveedor"))
                Dim ZZImpoLetra As Double = Val(IIf(IsDBNull(RowPasa.Item("ImpoLetra")), "0", RowPasa.Item("ImpoLetra")))
                Dim ZZImpoDespacho As Double = Val(IIf(IsDBNull(RowPasa.Item("ImpoDespacho")), "0", RowPasa.Item("ImpoDespacho")))
                Dim ZZPagoLetra As String = IIf(IsDBNull(RowPasa.Item("PagoLetra")), "", RowPasa.Item("PagoLetra"))
                Dim ZZPagoDespacho As String = IIf(IsDBNull(RowPasa.Item("PagoDespacho")), "", RowPasa.Item("PagoDespacho"))
                Dim ZZPagoLetraII As String = "0"
                Dim ZZPagoDespachoII As String = "0"
                Dim ZZTipoPago As String = IIf(IsDBNull(RowPasa.Item("TipoPago")), "", RowPasa.Item("TipoPago"))


                Dim TablaAnticipo As New DataTable
                With TablaAnticipo.Columns
                    .Add("Orden")
                    .Add("Importe")
                End With
                Dim WLugarII As Integer = 0

                Dim ZZSuma As Double = 0




                If ZZProveedor <> "" Then


                    SQLCnslt = "SELECT Carpeta, Carpeta1, Carpeta2, Carpeta3, Carpeta4, Carpeta5, Carpeta6, Carpeta7, Carpeta8, Carpeta9," _
                                & " Orden, Proveedor, Observaciones2, Tipoord, Tiporeg, Tipo1, Numero1, Punto1, Importe1, Paridad " _
                                & " FROM Pagos" _
                                & " WHERE (Carpeta = '" & ZZCarpeta & "'" _
                                & " OR Carpeta1 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta2 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta3 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta4 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta5 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta6 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta7 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta8 = '" & ZZCarpeta & "'" _
                                & " OR Carpeta9 = '" & ZZCarpeta & "')" _
                                & " AND TipoReg = '" & "1" & "'" _
                                & " AND Proveedor = '" & ZZProveedor & "'" _
                                & " ORDER BY clave"

                    Dim TablaPagos As DataTable = GetAll(SQLCnslt, Operador.Base)

                    If TablaPagos.Rows.Count > 0 Then


                        For Each RowPagos As DataRow In TablaPagos.Rows



                            Dim WWWOrden As String = RowPagos.Item("Orden")
                            Dim WWWObservaciones As String = Trim(RowPagos.Item("Observaciones2"))

                            If Val(RowPagos.Item("tipoord")) = 1 Then

                                If Val(RowPagos.Item("Tipo1")) = 5 Then
                                    For i = 0 To TablaAnticipo.Rows.Count - 1

                                        Dim WNumero1 As String = IIf(IsDBNull(RowPagos.Item("Numero1")), "", RowPagos.Item("Numero1"))
                                        Dim WOrden As String = IIf(IsDBNull(RowPagos.Item("Orden")), "", RowPagos.Item("Orden"))
                                        If Val(WOrden) = Val(WNumero1) Then

                                            TablaAnticipo.Rows.Add()
                                            TablaAnticipo.Rows(i).Item("Orden") = ""
                                            TablaAnticipo.Rows(i).Item("Importe") = formatonumerico(RowPagos.Item("Importe1") / RowPagos.Item("Paridad"))
                                            WLugarII += 1
                                            Exit For
                                        End If
                                    Next
                                End If

                                If Val(RowPagos.Item("Punto1")) = Val(ZZCarpeta) Then
                                    ZZSuma = ZZSuma + (RowPagos.Item("Importe1") / RowPagos.Item("Paridad"))
                                End If

                            Else

                                Dim WWCarpeta As String = IIf(IsDBNull(RowPagos.Item("Carpeta")), "0", RowPagos.Item("Carpeta"))
                                Dim WWCarpeta1 As String = IIf(IsDBNull(RowPagos.Item("Carpeta1")), "0", RowPagos.Item("Carpeta1"))
                                Dim WWCarpeta2 As String = IIf(IsDBNull(RowPagos.Item("Carpeta2")), "0", RowPagos.Item("Carpeta2"))
                                Dim WWCarpeta3 As String = IIf(IsDBNull(RowPagos.Item("Carpeta3")), "0", RowPagos.Item("Carpeta3"))
                                Dim WWCarpeta4 As String = IIf(IsDBNull(RowPagos.Item("Carpeta4")), "0", RowPagos.Item("Carpeta4"))
                                Dim WWCarpeta5 As String = IIf(IsDBNull(RowPagos.Item("Carpeta5")), "0", RowPagos.Item("Carpeta5"))
                                Dim WWCarpeta6 As String = IIf(IsDBNull(RowPagos.Item("Carpeta6")), "0", RowPagos.Item("Carpeta6"))
                                Dim WWCarpeta7 As String = IIf(IsDBNull(RowPagos.Item("Carpeta7")), "0", RowPagos.Item("Carpeta7"))
                                Dim WWCarpeta8 As String = IIf(IsDBNull(RowPagos.Item("Carpeta8")), "0", RowPagos.Item("Carpeta8"))
                                Dim WWCarpeta9 As String = IIf(IsDBNull(RowPagos.Item("Carpeta9")), "0", RowPagos.Item("Carpeta9"))

                                Dim ZZBusca As String = "S"

                                If Val(WWCarpeta) <> 0 Then
                                    If WWCarpeta1 = 0 And WWCarpeta2 = 0 And WWCarpeta3 = 0 And WWCarpeta4 = 0 And WWCarpeta5 = 0 And WWCarpeta6 = 0 And WWCarpeta7 = 0 And WWCarpeta8 = 0 And WWCarpeta9 = 0 Then

                                        TablaAnticipo.Rows.Add()
                                        TablaAnticipo.Rows(WLugarII).Item("Orden") = RowPagos.Item("Orden")
                                        TablaAnticipo.Rows(WLugarII).Item("Importe") = formatonumerico(RowPagos.Item("Importe1") / RowPagos.Item("Paridad"))
                                        ZZBusca = "N"
                                        WLugarII += 1
                                    End If
                                End If

                                If Val(ZZCarpeta) <> 0 Then 'Se lo egregue para que no pasaran los nullos
                                    If ZZBusca = "S" Then
                                        Dim WCarpeta As String = ZZCarpeta.PadLeft(4, "0")

                                        Dim WEspacios As Integer = Len(WCarpeta)
                                        Dim DA As Integer = Len(WWWObservaciones) - WEspacios

                                        For Aaa = 1 To DA + 1
                                            If Microsoft.VisualBasic.Left$(WCarpeta, WEspacios) = Mid$(WWWObservaciones, Aaa, WEspacios) Then

                                                TablaAnticipo.Rows(WLugarII).Item("Orden") = RowPagos.Item("Orden")
                                                TablaAnticipo.Rows(WLugarII).Item("Importe") = formatonumerico(RowPagos.Item("Importe1") / RowPagos.Item("Paridad"))
                                                WLugarII += 1
                                            End If
                                        Next Aaa
                                    End If
                                End If


                            End If



                            ZZPagoDespachoII = "1"


                        Next

                    End If



                End If





                For CicloII = 0 To TablaAnticipo.Rows.Count - 1
                    Dim WImporte As String = IIf(IsDBNull(TablaAnticipo.Rows(CicloII).Item("Importe")), "0", TablaAnticipo.Rows(CicloII).Item("Importe"))
                    ZZSuma = ZZSuma + Val(WImporte)
                Next


                Dim ZZPagado As String = formatonumerico(ZZSuma)

                ZZSuma = ZZSuma * 1.18
                If ZZSuma > ZZImpoLetra Then
                    ZZPagoLetraII = "1"
                Else
                    ZZPagoLetraII = "0"
                End If

                Dim ZZGraba As String = "N"
                Dim ZZGrabaII As String = "N"



                If ZZPagoLetra <> ZZPagoLetraII Then
                    ZZGraba = "S"

                    REM If ZZPagoLetra = "1" And ZZPagoLetraII = "0" Then
                    REM     Stop
                    REM End If
                End If

                If ZZPagoDespacho <> ZZPagoDespachoII Then
                    ZZGraba = "S"

                    REM If ZZPagoDespacho = "1" And ZZPagoDespachoII = "0" Then
                    REM     Stop
                    REM End If
                End If

                If ZZPagoLetraII = "0" And Val(ZZPagado) <> 0 Then
                    ZZGraba = "S"
                End If

                If Val(ZZTipoPago) = 1 And Val(ZZPagado) <> 0 And Val(ZZPagoLetra) = 0 Then
                    ZZGraba = "S"
                    ZZGrabaII = "S"
                    ZZTipoPago = "2"

                End If

                If ZZGraba = "S" Then

                    Dim ConectarA As String

                    Select Case Val(ZZEmpresa)
                        Case 1
                            ConectarA = "SurfactanSa"


                        Case 3
                            ConectarA = "Surfactan_II"

                        Case 5
                            ConectarA = "Surfactan_III"

                        Case 6
                            ConectarA = "Surfactan_IV"

                        Case 7
                            ConectarA = "Surfactan_V"


                        Case 10
                            ConectarA = "Surfactan_VI"

                        Case 11
                            ConectarA = "Surfactan_VII"

                    End Select

                    SQLCnslt = "UPDATE Orden SET" _
                                & " PagoLetra = '" & ZZPagoLetraII & "'," _
                                & " PagoDespacho = '" & ZZPagoDespachoII & "'," _
                                & " PagoParcialLetra = '" & ZZPagado & "'" _
                                & " WHERE Orden = '" & ZZOrden & "'"

                    ExecuteNonQueries({SQLCnslt}, ConectarA)

                    If ZZGrabaII = "S" Then
                        SQLCnslt = "UPDATE Orden SET" _
                                & " TipoPago = '" & ZZTipoPago & "'" _
                                & " WHERE Orden = '" & ZZOrden & "'"
                        ExecuteNonQueries({SQLCnslt}, ConectarA)
                    End If



                End If

            Next

        ZZCiclaProceso = "N"

        End If










        Dim WLugar As Integer = 0
        Dim ZZDesde As Integer
        Dim ZZHasta As Integer

        If ColumnaOpcion = 2 Then
            ZZDesde = Seleccion
            ZZHasta = Seleccion
        Else
            ' ESTOS VALORES SALEN DEL VECTOR DE EMPRESA
            ZZDesde = 1
            ZZHasta = 6
        End If

        Dim ZZSumaLetra As Double = 0
        Dim ZZSumaDespacho As Double = 0
        Dim ZZSumaArticulo As Double = 0

        lbl_Articulo.Visible = False
        txt_Articulo.Visible = False
        lbl_ArticuloKg.Visible = False

        For CiclaEmpresa = ZZDesde To ZZHasta


            Dim WDesdeFecha As String
            Dim WHastaFecha As String

            Select Case ColumnaOpcion
                Case 0, 1, 2
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                    & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                    & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                    & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                    & " FROM Orden, Proveedor" _
                    & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                    & " AND Orden.Tipo = 1" _
                    & " AND Orden.Cantidad <> 0" _
                    & " AND Orden.Renglon = 1" _
                    & " AND fechaOrd >=20140101" _
                    & " ORDER BY Orden.Clave"




                Case 3
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                      & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                      & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                      & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                      & " FROM Orden, Proveedor" _
                      & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                      & " AND Orden.Tipo = 1" _
                      & " AND Orden.Cantidad <> 0" _
                      & " AND Orden.Renglon = 1" _
                      & " AND Orden.FechaOrd >= '" & Seleccion & "'" _
                      & " AND Orden.FechaOrd <= '" & SeleccionII & "'" _
                      & " ORDER BY Orden.Clave"


                Case 4
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " AND Orden.Proveedor = '" & Seleccion & "'" _
                     & " AND fechaord >= 20140101" _
                     & " ORDER BY Orden.Clave"


                Case 6
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                       & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                       & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                       & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                       & " FROM Orden, Proveedor" _
                       & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                       & " AND Orden.Tipo = 1" _
                       & " AND Orden.Cantidad <> 0" _
                       & " AND Orden.Renglon = 1" _
                       & " AND Orden.Djai = '" & Seleccion & "'" _
                       & " AND fechaord >=20140101" _
                       & " ORDER BY Orden.Clave"


                Case 7
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                      & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                      & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                      & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                      & " FROM Orden, Proveedor" _
                      & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                      & " AND Orden.Tipo = 1" _
                      & " AND Orden.Cantidad <> 0" _
                      & " AND Orden.Renglon = 1" _
                      & " AND fechaord >= 20140101" _
                      & " AND Orden.Origen = '" & Seleccion & "'" _
                      & " ORDER BY Orden.Clave"


                Case 8
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                   & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                   & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                   & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                   & " FROM Orden, Proveedor" _
                   & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                   & " AND Orden.Tipo = 1" _
                   & " AND Orden.Cantidad <> 0" _
                   & " AND Orden.Renglon = 1" _
                   & " AND fechaord >=20140101" _
                   & " AND Orden.Leyenda = '" & Seleccion & "'" _
                   & " ORDER BY Orden.Clave"


                Case 9
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " and fechaord >= 20140101" _
                     & " and Orden.TipoImpo = '" & Seleccion & "'" _
                     & " Order by Orden.Clave"


                Case 10
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " AND fechaord >= 20140101" _
                     & " ORDER BY Orden.Clave"

                    WDesdeFecha = Seleccion
                    WHastaFecha = SeleccionII

                Case 11
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                      & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                      & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                      & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                      & " FROM Orden, Proveedor" _
                      & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                      & " AND Orden.Tipo = 1" _
                      & " AND Orden.Cantidad <> 0" _
                      & " AND Orden.Renglon = 1" _
                      & " AND Orden.TipoPago = '" & Seleccion & "'" _
                      & " AND fechaord >= 20140101" _
                      & " ORDER BY Orden.Clave"


                Case 12
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " AND Orden.PagoDespacho = '" & Seleccion & "'" _
                     & " AND fechaord >= 20140101" _
                     & " ORDER BY Orden.Clave"


                Case 13
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " AND fechaord >= 20140101" _
                     & " ORDER BY Orden.Clave"
                    ' ZSql = ZSql + " and Orden.PagoLetra = " + "'" + Seleccion + "'"

                Case 14
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                     & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                     & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                     & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                     & " FROM Orden, Proveedor" _
                     & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                     & " AND Orden.Tipo = 1" _
                     & " AND Orden.Cantidad <> 0" _
                     & " AND Orden.Renglon = 1" _
                     & " AND fechaord >= 20140101" _
                     & " ORDER BY Orden.Clave"

                    WDesdeFecha = Microsoft.VisualBasic.Right$(FiltroVtoI, 4) + Mid$(FiltroVtoI, 4, 2) + Microsoft.VisualBasic.Left$(FiltroVtoI, 2)
                    WHastaFecha = Microsoft.VisualBasic.Right$(FiltroVtoII, 4) + Mid$(FiltroVtoII, 4, 2) + Microsoft.VisualBasic.Left$(FiltroVtoII, 2)

                Case 15
                    SQLCnslt = "SELECT Orden.Tipo, Orden.Recibida, Orden.Cantidad, Orden.Clave, Orden.Orden, Orden.fecha, Orden.fechaord, Orden.Proveedor, Orden.Articulo, " _
                      & "Orden.Cantidad, Orden.Precio, Orden.Condicion, Orden.Moneda, Orden.Carpeta, Orden.Djai, Orden.derechos, Orden.Origen, Orden.Leyenda, Orden.TipoImpo, " _
                      & "Orden.PagoDespacho, Orden.Fechallegada, Orden.FechaEmbarque, Orden.impodespacho, Orden.tipopago, Orden.vtodespacho, Orden.impoletra, Orden.vtoletra, " _
                      & "Orden.pagoletra, Orden.fechadjai,  Proveedor.Nombre as [WProveedor]" _
                      & " FROM Orden, Proveedor" _
                      & " WHERE Orden.Proveedor = Proveedor.Proveedor" _
                      & " AND Orden.Tipo = 1" _
                      & " AND Orden.Cantidad <> 0" _
                      & " AND fechaord >= 20140101" _
                      & " AND Orden.Articulo = '" & Seleccion & "'" _
                      & " ORDER BY Orden.Clave"


                Case Else
            End Select

            Dim tablaOrd As DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))

            If tablaOrd.Rows.Count > 0 Then

                For Each RowOrd As DataRow In tablaOrd.Rows
                    REM If rstOrden!Orden = 3205 Then Stop

                    REM by nan
                    Dim ZZRecibida As Double = RowOrd.Item("Recibida")
                    If RowOrd.Item("Cantidad") = 0 Then
                        ZZRecibida = 0
                    End If

                    Dim ZEntra As String = ""

                    If cbx_Activas.SelectedIndex <> 1 Then
                        If ZZRecibida <> 0 And RowOrd.Item("PagoLetra") = 1 Then
                            ZEntra = "N"
                        Else
                            ZEntra = "S"
                        End If
                    Else
                        If ZZRecibida <> 0 And RowOrd.Item("PagoLetra = 1") Then
                            ZEntra = "S"
                        Else
                            ZEntra = "N"
                        End If
                    End If

                    If ColumnaOpcion = 10 Then
                        Dim ZZLlegada As String = IIf(IsDBNull(RowOrd.Item("FechaLlegada")), "", RowOrd.Item("FechaLlegada"))
                        Dim ZZOrdLLegada As String = Microsoft.VisualBasic.Right$(ZZLlegada, 4) + Mid$(ZZLlegada, 4, 2) + Microsoft.VisualBasic.Left$(ZZLlegada, 2)
                        If WDesdeFecha > ZZOrdLLegada Or WHastaFecha < ZZOrdLLegada Then
                            ZEntra = "N"
                        End If
                    End If

                    If ColumnaOpcion = 14 Then
                        Dim ZZVtoLetra As String = RowOrd.Item("VtoLetra")
                        Dim ZZOrdVtoLetra As String = Microsoft.VisualBasic.Right$(ZZVtoLetra, 4) + Mid$(ZZVtoLetra, 4, 2) + Microsoft.VisualBasic.Left$(ZZVtoLetra, 2)
                        If WDesdeFecha > ZZOrdVtoLetra Or WHastaFecha < ZZOrdVtoLetra Then
                            ZEntra = "N"
                        End If
                    End If

                    If ZEntra = "S" And ColumnaOpcionII <> 0 Then

                        Select Case ColumnaOpcionII
                            Case 1
                                If CiclaEmpresa <> SeleccionIII Then
                                    ZEntra = "N"
                                End If

                            Case 2
                                If RowOrd.Item("FechaOrd") < SeleccionIII Or RowOrd.Item("FechaOrd") > SeleccionIV Then
                                    ZEntra = "N"
                                End If

                            Case 3
                                If Trim(RowOrd.Item("Proveedor")) <> Trim(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 4
                                If Trim(RowOrd.Item("Origen")) <> Trim(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 5
                                If Trim(RowOrd.Item("Leyenda")) <> Trim(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 6
                                If Trim(RowOrd.Item("TipoImpo")) <> Trim(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 7
                                Dim ZZLlegada As String = IIf(IsDBNull(RowOrd.Item("FechaLlegada")), "", RowOrd.Item("FechaLlegada"))
                                Dim ZZOrdLLegada As String = Microsoft.VisualBasic.Right$(ZZLlegada, 4) + Mid$(ZZLlegada, 4, 2) + Microsoft.VisualBasic.Left$(ZZLlegada, 2)
                                WDesdeFecha = SeleccionIII
                                WHastaFecha = SeleccionIV
                                If WDesdeFecha > ZZOrdLLegada Or WHastaFecha < ZZOrdLLegada Then
                                    ZEntra = "N"
                                End If

                            Case 8
                                If RowOrd.Item("TipoPago") <> Val(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 9
                                If RowOrd.Item("PagoDespacho") <> Val(SeleccionIII) Then
                                    ZEntra = "N"
                                End If

                            Case 10
                                REM If rstOrden!PagoLetra <> Val(SeleccionIII) Then
                                REM     ZEntra = "N"
                                REM End If

                            Case 11
                                Dim ZZVtoLetra As String = RowOrd.Item("VtoLetra")
                                Dim ZZOrdVtoLetra As String = Microsoft.VisualBasic.Right$(ZZVtoLetra, 4) + Mid$(ZZVtoLetra, 4, 2) + Microsoft.VisualBasic.Left$(ZZVtoLetra, 2)
                                WDesdeFecha = SeleccionIII
                                WHastaFecha = SeleccionIV
                                If WDesdeFecha > ZZOrdVtoLetra Or WHastaFecha < ZZOrdVtoLetra Then
                                    ZEntra = "N"
                                End If

                            Case 12
                                If UCase(RowOrd.Item("Articulo")) <> UCase(SeleccionIII) Then
                                    ZEntra = "N"
                                End If


                            Case Else

                        End Select

                    End If


                    If ZEntra = "S" And ColumnaOpcionIII <> 0 Then

                        Select Case ColumnaOpcionIII
                            Case 1
                                If CiclaEmpresa <> SeleccionV Then
                                    ZEntra = "N"
                                End If

                            Case 2
                                If RowOrd.Item("FechaOrd") < SeleccionV Or RowOrd.Item("FechaOrd") > SeleccionVI Then
                                    ZEntra = "N"
                                End If

                            Case 3
                                If Trim(RowOrd.Item("Proveedor")) <> Trim(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 4
                                If Trim(RowOrd.Item("Origen")) <> Trim(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 5
                                If Trim(RowOrd.Item("Leyenda")) <> Trim(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 6
                                If Trim(RowOrd.Item("TipoImpo")) <> Trim(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 7
                                Dim ZZLlegada As String = IIf(IsDBNull(RowOrd.Item("FechaLlegada")), "", RowOrd.Item("FechaLlegada"))
                                Dim ZZOrdLLegada As String = Microsoft.VisualBasic.Right$(ZZLlegada, 4) + Mid$(ZZLlegada, 4, 2) + Microsoft.VisualBasic.Left$(ZZLlegada, 2)
                                WDesdeFecha = SeleccionV
                                WHastaFecha = SeleccionVI
                                If WDesdeFecha > ZZOrdLLegada Or WHastaFecha < ZZOrdLLegada Then
                                    ZEntra = "N"
                                End If

                            Case 8
                                If RowOrd.Item("TipoPago") <> Val(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 9
                                If RowOrd.Item("PagoDespacho") <> Val(SeleccionV) Then
                                    ZEntra = "N"
                                End If

                            Case 10
                                REM If rstOrden!PagoLetra <> Val(SeleccionV) Then
                                REM     ZEntra = "N"
                                REM End If

                            Case 11
                                Dim ZZVtoLetra As String = RowOrd.Item("VtoLetra")
                                Dim ZZOrdVtoLetra As String = Microsoft.VisualBasic.Right$(ZZVtoLetra, 4) + Mid$(ZZVtoLetra, 4, 2) + Microsoft.VisualBasic.Left$(ZZVtoLetra, 2)
                                WDesdeFecha = SeleccionV
                                WHastaFecha = SeleccionVI
                                If WDesdeFecha > ZZOrdVtoLetra Or WHastaFecha < ZZOrdVtoLetra Then
                                    ZEntra = "N"
                                End If

                            Case 12
                                If UCase(RowOrd.Item("Articulo")) <> UCase(SeleccionV) Then
                                    ZEntra = "N"
                                End If


                            Case Else

                        End Select

                    End If




                    If ZEntra = "S" Then



                        DGV_Muestra.Rows.Add()



                        DGV_Muestra.Rows(WLugar).Cells("Orden").Value = RowOrd.Item("Orden")

                        Select Case CiclaEmpresa
                            Case 1
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "I"
                            Case 2
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "II"
                            Case 3
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "III"
                            Case 4
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "V"
                            Case 5
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "VI"
                            Case 6
                                DGV_Muestra.Rows(WLugar).Cells("Pta").Value = "VII"
                            Case Else
                        End Select
                        DGV_Muestra.Rows(WLugar).Cells("Fecha").Value = Microsoft.VisualBasic.Left$(RowOrd.Item("Fecha"), 5) + "/" + Mid$(RowOrd.Item("Fecha"), 9, 2)
                        DGV_Muestra.Rows(WLugar).Cells("Proveedor").Value = RowOrd.Item("WProveedor")

                        Select Case RowOrd.Item("Moneda")
                            Case 0
                                DGV_Muestra.Rows(WLugar).Cells("Mon").Value = "U$S"
                            Case 1
                                DGV_Muestra.Rows(WLugar).Cells("Mon").Value = "$"
                            Case 2
                                DGV_Muestra.Rows(WLugar).Cells("Mon").Value = "Eur"
                        End Select

                        DGV_Muestra.Rows(WLugar).Cells("Carpeta").Value = RowOrd.Item("Carpeta")

                        Dim ZDJai As String = IIf(IsDBNull(RowOrd.Item("DJai")), "", RowOrd.Item("DJai"))
                        DGV_Muestra.Rows(WLugar).Cells("Djai").Value = ZDJai




                        DGV_Muestra.Rows(WLugar).Cells("Origen").Value = RowOrd.Item("Origen")

                        Select Case RowOrd.Item("Leyenda")
                            Case 1
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "FOB"
                            Case 2
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "CIF"
                            Case 3
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "CFR"
                            Case 4
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "CPT"
                            Case 5
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "EXW"
                            Case 6
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = "FCA"
                            Case Else
                                DGV_Muestra.Rows(WLugar).Cells("Incoterms").Value = ""
                        End Select


                        Select Case RowOrd.Item("TipoImpo")
                            Case 1
                                DGV_Muestra.Rows(WLugar).Cells("Transporte").Value = "Maritimo"
                            Case 2
                                DGV_Muestra.Rows(WLugar).Cells("Transporte").Value = "Terrestre"
                            Case 3
                                DGV_Muestra.Rows(WLugar).Cells("Transporte").Value = "Aereo"
                            Case Else
                                DGV_Muestra.Rows(WLugar).Cells("Transporte").Value = ""
                        End Select

                        DGV_Muestra.Rows(WLugar).Cells("FLLegada").Value = IIf(IsDBNull(RowOrd.Item("FechaLlegada")), "", RowOrd.Item("FechaLlegada"))

                        Select Case RowOrd.Item("TipoPago")
                            Case 1
                                DGV_Muestra.Rows(WLugar).Cells("TPago").Value = "Pago Anti."
                            Case 2
                                DGV_Muestra.Rows(WLugar).Cells("TPago").Value = "A la vista"
                            Case 3
                                DGV_Muestra.Rows(WLugar).Cells("TPago").Value = "Cta.Cte."
                            Case Else
                                DGV_Muestra.Rows(WLugar).Cells("TPago").Value = ""
                        End Select

                        DGV_Muestra.Rows(WLugar).Cells("Despacho").Value = formatonumerico(IIf(IsDBNull(RowOrd.Item("ImpoDespacho")), "0", RowOrd.Item("ImpoDespacho")))

                        Select Case RowOrd.Item("PagoDespacho")
                            Case 0
                                ZZSumaDespacho = ZZSumaDespacho + Val(DGV_Muestra.Rows(WLugar).Cells("Despacho").Value)
                                DGV_Muestra.Rows(WLugar).Cells("PagoDes").Value = "Pendiente"
                            Case Else
                                DGV_Muestra.Rows(WLugar).Cells("PagoDes").Value = "Pagado"
                        End Select



                        ' saaa = rstOrden!Carpeta


                        DGV_Muestra.Rows(WLugar).Cells("LetraTotal").Value = formatonumerico(IIf(IsDBNull(RowOrd.Item("ImpoLetra")), "0", RowOrd.Item("ImpoLetra")))

                        Select Case RowOrd.Item("PagoLetra")
                            Case 0
                                DGV_Muestra.Rows(WLugar).Cells("PagoLetra").Value = "Pendiente"
                            Case Else
                                DGV_Muestra.Rows(WLugar).Cells("PagoLetra").Value = "Pagado"
                        End Select
                        DGV_Muestra.Rows(WLugar).Cells("VtoLetra").Value = IIf(IsDBNull(RowOrd.Item("VtoLetra")), "0", RowOrd.Item("VtoLetra"))

                        If ColumnaOpcion = 15 Then
                            ZZSumaArticulo = ZZSumaArticulo + RowOrd.Item("Cantidad")
                        End If

                        ' 18 = ("USPagadoLetra")
                        REM Muestra.TextMatrix(WLugar, 18) = IIf(IsNull(rstOrden!pagoparcialletra), "0", rstOrden!pagoparcialletra)
                        REM Muestra.TextMatrix(WLugar, 18) = Pusing("###,###", Muestra.TextMatrix(WLugar, 18))

                        'DGV_Muestra.Rows(WLugar).Cells("USPagadoLetra").Value = ""

                        DGV_Muestra.Rows(WLugar).Cells("FEmbarque").Value = IIf(IsDBNull(RowOrd.Item("FechaEmbarque")), "", RowOrd.Item("FechaEmbarque"))
                        DGV_Muestra.Rows(WLugar).Cells("SaldoLetra").Value = IIf(IsDBNull(RowOrd.Item("FechaDJai")), "", RowOrd.Item("FechaDJai"))
                        DGV_Muestra.Rows(WLugar).Cells("ProveedorCod").Value = RowOrd.Item("Proveedor")




                        REM Muestra.TextMatrix(WLugar, 5) = rstOrden!Articulo
                        REM Muestra.TextMatrix(WLugar, 6) = rstOrden!Cantidad
                        REM Muestra.TextMatrix(WLugar, 7) = rstOrden!Precio
                        REM Muestra.TextMatrix(WLugar, 12) = rstOrden!Derechos



                        WLugar += 1

                    End If
                Next





            End If

        Next CiclaEmpresa



        Dim ZZBorra As String = "N"



        For Each rowMuestra As DataGridViewRow In DGV_Muestra.Rows


            Dim ZOrden As String = rowMuestra.Cells("Orden").Value

            Dim ZPagoLetra As String = rowMuestra.Cells("PagoLetra").Value


            Dim SQLCnlst As String = "Select pagoparcialletra" _
            & " FROM Orden" _
            & " Where Orden = '" & ZOrden & "'"
            Dim rowOrden As DataRow = GetSingle(SQLCnlst, Operador.Base)

            If rowOrden IsNot Nothing Then
                rowMuestra.Cells("USPagadoLetra").Value = formatonumerico(IIf(IsDBNull(rowOrden.Item("pagoparcialletra")), "0", rowOrden.Item("pagoparcialletra")))
            End If

            'Call Conecta_Empresa()

            Dim ZtipoPagoLetra As String
            Select Case ZPagoLetra
                Case "Pendiente"
                    ZtipoPagoLetra = "0"
                Case Else
                    ZtipoPagoLetra = "1"
            End Select

            If ColumnaOpcion = 13 Then
                If ZtipoPagoLetra <> Val(Seleccion) Then
                    For CicloBaja = 0 To 20
                        rowMuestra.Cells(CicloBaja).Value = ""
                    Next CicloBaja
                End If
            End If

            If chk_LetraPendiente.Checked Then
                If ZtipoPagoLetra <> 0 Then
                    For CicloBaja = 0 To 20
                        rowMuestra.Cells(CicloBaja).Value = ""
                        ZZBorra = "S"
                    Next CicloBaja
                End If
            End If

            If ColumnaOpcionII = 10 Then
                If ZtipoPagoLetra <> Val(SeleccionIII) Then
                    For CicloBaja = 0 To 20
                        rowMuestra.Cells(CicloBaja).Value = ""
                    Next CicloBaja
                End If
            End If

            If ColumnaOpcionIII = 10 Then
                If ZtipoPagoLetra <> Val(SeleccionV) Then
                    For CicloBaja = 0 To 20
                        rowMuestra.Cells(CicloBaja).Value = ""
                    Next CicloBaja
                End If
            End If

            Select Case Val(ZtipoPagoLetra)
                Case 0
                    ZZSumaLetra = ZZSumaLetra + Val(rowMuestra.Cells("LetraTotal").Value) - Val(rowMuestra.Cells("USPagadoLetra").Value)
                Case Else
            End Select


            Dim ZDJai = rowMuestra.Cells("Djai").Value
            Dim ZFechaLlegada = rowMuestra.Cells("FLLegada").Value
            Dim ZPagoDespacho = rowMuestra.Cells("Despacho").Value

            Dim ZFechaLetra = rowMuestra.Cells("VtoLetra").Value
            Dim ZFechaDJai = rowMuestra.Cells("SaldoLetra").Value

            If Trim(ZDJai) <> "" Then
                If Trim(ZFechaDJai) <> "" Then

                    If ValidaFecha(ZFechaDJai) = "S" Then
                        Dim WDias1 As Integer = 180
                        Dim WFecha As String = ZFechaDJai
                        Dim Wvencimiento As String = Calcula_vencimiento(WFecha, WDias1)

                        Dim ZZOrdFecha As String = Date.Today.ToString("MMddyyyy")
                        Dim ZZOrdFechaDjai As String = Microsoft.VisualBasic.Right$(Wvencimiento, 4) & Mid$(Wvencimiento, 4, 2) & Microsoft.VisualBasic.Left$(Wvencimiento, 2)

                        If ZZOrdFechaDjai < ZZOrdFecha Then
                            rowMuestra.Cells("Djai").Style.BackColor = Color.FromArgb(&H8080FF)

                        End If
                    End If

                End If
            End If

            If ZPagoDespacho = "Pendiente" Then
                Dim ZZOrdFechaLlegada As String = Microsoft.VisualBasic.Right$(ZFechaLlegada, 4) & Mid$(ZFechaLlegada, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLlegada, 2)
                Dim ZZOrdFecha As String = Date.Today.ToString("MMddyyyy")
                If ZZOrdFechaLlegada <= ZZOrdFecha Then
                    rowMuestra.Cells("Despacho").Style.BackColor = Color.FromArgb(&H8080FF)
                End If
            End If

            If ZPagoLetra = "Pendiente" Then
                If ZFechaLetra <> "" And ZFechaLetra <> "  /  /    " Then
                    Dim ZZOrdFechaLetra As String = Microsoft.VisualBasic.Right$(ZFechaLetra, 4) & Mid$(ZFechaLetra, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLetra, 2)
                    Dim ZZOrdFecha As String = Date.Today.ToString("MMddyyyy")
                    If ZZOrdFechaLetra <= ZZOrdFecha Then
                        rowMuestra.Cells("LetraTotal").Style.BackColor = Color.FromArgb(&H8080FF)

                    End If
                End If
            End If
        Next



        If ColumnaOpcion = 13 Or ColumnaOpcionII = 10 Or ColumnaOpcionIII = 10 Or ZZBorra = "S" Then

            Dim TablaPas As New DataTable

            With TablaPas.Columns
                .Add("Orden")
                .Add("Pta")
                .Add("Fecha")
                .Add("Proveedor")
                .Add("Mon")
                .Add("Carpeta")
                .Add("Djai")
                .Add("Origen")
                .Add("Incoterms")
                .Add("Transporte")
                .Add("FLLegada")
                .Add("TPago")
                .Add("Despacho")
                .Add("PagoDes")
                .Add("LetraTotal")
                .Add("PagoTotal")
                .Add("VtoTotal")
                .Add("UsPagadoLetra")
                .Add("FEmbarque")
                .Add("SaldoLetra")
            End With


            Dim Fila As Integer = 0
            For Each row In DGV_Muestra.Rows
                TablaPas.Rows.Add()
                TablaPas.Rows(Fila).Item("Orden") = row.cell("Orden").value
                TablaPas.Rows(Fila).Item("Pta") = row.cell("Pta").value
                TablaPas.Rows(Fila).Item("Fecha") = row.cell("Fecha").value
                TablaPas.Rows(Fila).Item("Proveedor") = row.cell("Proveedor").value
                TablaPas.Rows(Fila).Item("Mon") = row.cell("Mon").value
                TablaPas.Rows(Fila).Item("Carpeta") = row.cell("Carpeta").value
                TablaPas.Rows(Fila).Item("Djai") = row.cell("Djai").value
                TablaPas.Rows(Fila).Item("Origen") = row.cell("Origen").value
                TablaPas.Rows(Fila).Item("Incoterms") = row.cell("Incoterms").value
                TablaPas.Rows(Fila).Item("Transporte") = row.cell("Transporte").value
                TablaPas.Rows(Fila).Item("FLLegada") = row.cell("FLLegada").value
                TablaPas.Rows(Fila).Item("TPago") = row.cell("TPago").value
                TablaPas.Rows(Fila).Item("Despacho") = row.cell("Despacho").value
                TablaPas.Rows(Fila).Item("PagoDes") = row.cell("PagoDes").value
                TablaPas.Rows(Fila).Item("LetraTotal") = row.cell("LetraTotal").value
                TablaPas.Rows(Fila).Item("PagoTotal") = row.cell("PagoTotal").value
                TablaPas.Rows(Fila).Item("VtoTotal") = row.cell("VtoTotal").value
                TablaPas.Rows(Fila).Item("UsPagadoLetra") = row.cell("UsPagadoLetra").value
                TablaPas.Rows(Fila).Item("FEmbarque") = row.cell("FEmbarque").value
                TablaPas.Rows(Fila).Item("SaldoLetra") = row.cell("SaldoLetra").value

                Fila += 1
            Next

            DGV_Muestra.Rows.Clear()

            Fila = 0

            For Each RowPas As DataRow In TablaPas.Rows

                If Val(RowPas.Item("Orden")) <> 0 Then

                    DGV_Muestra.Rows.Add()

                    DGV_Muestra.Rows(Fila).Cells("Orden").Value = RowPas.Item("Orden")
                    DGV_Muestra.Rows(Fila).Cells("Pta").Value = RowPas.Item("Pta")
                    DGV_Muestra.Rows(Fila).Cells("Fecha").Value = RowPas.Item("Fecha")
                    DGV_Muestra.Rows(Fila).Cells("Proveedor").Value = RowPas.Item("Proveedor")
                    DGV_Muestra.Rows(Fila).Cells("Mon").Value = RowPas.Item("Mon")
                    DGV_Muestra.Rows(Fila).Cells("Carpeta").Value = RowPas.Item("Carpeta")
                    DGV_Muestra.Rows(Fila).Cells("Djai").Value = RowPas.Item("Djai")
                    DGV_Muestra.Rows(Fila).Cells("Origen").Value = RowPas.Item("Origen")
                    DGV_Muestra.Rows(Fila).Cells("Incoterms").Value = RowPas.Item("Incoterms")
                    DGV_Muestra.Rows(Fila).Cells("Transporte").Value = RowPas.Item("Transporte")
                    DGV_Muestra.Rows(Fila).Cells("FLLegada").Value = RowPas.Item("FLLegada")
                    DGV_Muestra.Rows(Fila).Cells("TPago").Value = RowPas.Item("TPago")
                    DGV_Muestra.Rows(Fila).Cells("Despacho").Value = RowPas.Item("Despacho")
                    DGV_Muestra.Rows(Fila).Cells("PagoDes").Value = RowPas.Item("PagoDes")
                    DGV_Muestra.Rows(Fila).Cells("LetraTotal").Value = RowPas.Item("LetraTotal")
                    DGV_Muestra.Rows(Fila).Cells("PagoTotal").Value = RowPas.Item("PagoTotal")
                    DGV_Muestra.Rows(Fila).Cells("VtoTotal").Value = RowPas.Item("VtoTotal")
                    DGV_Muestra.Rows(Fila).Cells("UsPagadoLetra").Value = RowPas.Item("UsPagadoLetra")
                    DGV_Muestra.Rows(Fila).Cells("FEmbarque").Value = RowPas.Item("FEmbarque")
                    DGV_Muestra.Rows(Fila).Cells("SaldoLetra").Value = RowPas.Item("SaldoLetra")



                    Dim ZDJai As String = DGV_Muestra.Rows(Fila).Cells("Djai").Value
                    Dim ZFechaLlegada As String = DGV_Muestra.Rows(Fila).Cells("FLLegada").Value
                    Dim ZPagoDespacho As String = DGV_Muestra.Rows(Fila).Cells("PagoDes").Value
                    Dim ZPagoLetra As String = DGV_Muestra.Rows(Fila).Cells("PagoTotal").Value
                    Dim ZFechaLetra As String = DGV_Muestra.Rows(Fila).Cells("VtoTotal").Value
                    Dim ZFechaDJai As String = DGV_Muestra.Rows(Fila).Cells("SaldoLetra").Value

                    If Trim(ZDJai) <> "" Then
                        If Trim(ZFechaDJai) <> "" Then

                            If ValidaFecha(ZFechaDJai) = "S" Then

                                Dim Wvencimiento As String = Calcula_vencimiento(ZFechaDJai, 180)

                                Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                                Dim ZZOrdFechaDjai As String = Microsoft.VisualBasic.Right$(Wvencimiento, 4) & Mid$(Wvencimiento, 4, 2) & Microsoft.VisualBasic.Left$(Wvencimiento, 2)

                                If ZZOrdFechaDjai < ZZOrdFecha Then

                                    DGV_Muestra.Rows(Fila).Cells("Djai").Style.BackColor = Color.FromArgb(&H8080FF)

                                End If
                            End If
                        End If
                    End If

                    If ZPagoDespacho = "Pendiente" Then
                        Dim ZZOrdFechaLlegada As String = Microsoft.VisualBasic.Right$(ZFechaLlegada, 4) & Mid$(ZFechaLlegada, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLlegada, 2)
                        Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                        If ZZOrdFechaLlegada <= ZZOrdFecha Then

                            DGV_Muestra.Rows(Fila).Cells("Despacho").Style.BackColor = Color.FromArgb(&H8080FF)

                        End If
                    End If

                    If ZPagoLetra = "Pendiente" Then
                        If ZFechaLetra <> "" And ZFechaLetra <> "  /  /    " Then
                            Dim ZZOrdFechaLetra As String = Microsoft.VisualBasic.Right$(ZFechaLetra, 4) & Mid$(ZFechaLetra, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLetra, 2)
                            Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                            If ZZOrdFechaLetra <= ZZOrdFecha Then

                                DGV_Muestra.Rows(Fila).Cells("LetraTotal").Style.BackColor = Color.FromArgb(&H8080FF)

                            End If
                        End If
                    End If



                    Fila += 1
                End If



            Next





        End If

        txt_SumaDespacho.Text = formatonumerico(ZZSumaDespacho)


        txt_SumaLetra.Text = formatonumerico(ZZSumaLetra)


        If ColumnaOpcion = 15 Then
            txt_Articulo.Text = formatonumerico(ZZSumaArticulo)
            lbl_Articulo.Visible = True
            lbl_ArticuloKg.Visible = True
            txt_Articulo.Visible = True
        End If






        REM Muestra.SetFocus

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



    Private Sub Centro_Importaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chk_LetraPendiente.Checked = 0

        ZZCiclaProceso = "S"
        ' ZZProcesoPendiente = 0

      

        cbx_Ordenamiento.SelectedIndex = 5

        cbx_FiltroI.SelectedIndex = 0
        cbx_FiltroII.SelectedIndex = 0
        cbx_FiltroIII.SelectedIndex = 0
        
        cbx_Activas.SelectedIndex = 0
      
        ZProcesa = ""



        Proceso_Click()
        'Call OrdenaI_click()

        REM Call Proceso_Click


    End Sub
End Class