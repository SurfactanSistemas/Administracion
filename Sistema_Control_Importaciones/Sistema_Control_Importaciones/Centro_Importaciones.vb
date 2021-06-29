Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports System.IO




Public Class Centro_Importaciones 'Implements ICentroImportaciones_auxiliar


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



    Dim ZZFiltroOrdenI As String
    Dim ZZFiltroOrdenII As String
    Dim ZZFiltroOrdenIII As String


    Dim ZZColumnaI As Integer
    Dim ZZColumnaII As Integer
    Dim ZZColumnaIII As Integer

    Dim ZZTipoFiltro As Integer

    'Fin de Globales





    Private Sub Proceso_Click()

        If ZProcesa = "N" Then
            Exit Sub
        End If
        
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

        'SE USA EN LA PRIMER VENTANA
        ' Dim TablaAenviar As New System.Data.DataTable
        ' With TablaAenviar.Columns
        '     .Add("Orden")
        '     .Add("Carpeta")
        '     .Add("Proveedor")
        '     .Add("FechaInforme")
        '     .Add("Empresa")
        ' End With
        Dim Lugar As Integer = 0
        
        Dim LugarTabla As Integer = 0
        Dim TablaPasa As New System.Data.DataTable
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

                ExecuteNonQueries(VectorEmpresas(CiclaEmpresa), {SQLCnslt})
                
                SQLCnslt = "SELECT Orden, Carpeta, Impoletra, Impodespacho," _
                    & " Proveedor, PagoLetra = isnull(PagoLetra,'0'), PagoDespacho = isnull(PagoDespacho,'0'), TipoPago, Baja = isnull(Baja,'')" _
                    & " FROM Orden " _
                    & " WHERE Tipo = '1'" _
                    & " AND Cantidad <> 0" _
                    & " AND Renglon = 1" _
                    & " AND FechaOrd >= '20140101'" _
                    & " AND ((isnull(PagoLetra,'0') <> 1 And isnull(PagoDespacho,'0') <> 1) Or (isnull(Baja,'') <> 'S'))" _
                    & " ORDER BY Clave"
                
                Dim TablaOrden As System.Data.DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))

                If TablaOrden.Rows.Count > 0 Then

                    For Each RowOrden As DataRow In TablaOrden.Rows
                        
                        REM If Val(rstOrden!Carpeta) = 3515 Then Stop
                        
                        TablaPasa.Rows.Add()
                        TablaPasa.Rows(LugarTabla).Item("Empresa") = VectorEmpresas(CiclaEmpresa)
                        TablaPasa.Rows(LugarTabla).Item("Orden") = RowOrden.Item("Orden")
                        TablaPasa.Rows(LugarTabla).Item("Carpeta") = RowOrden.Item("Carpeta")
                        TablaPasa.Rows(LugarTabla).Item("Proveedor") = RowOrden.Item("Proveedor")
                        TablaPasa.Rows(LugarTabla).Item("ImpoLetra") = Str$(RowOrden.Item("ImpoLetra"))
                        TablaPasa.Rows(LugarTabla).Item("ImpoDespacho") = Str$(RowOrden.Item("ImpoDespacho"))
                        TablaPasa.Rows(LugarTabla).Item("PagoLetra") = RowOrden.Item("PagoLetra")
                        TablaPasa.Rows(LugarTabla).Item("PagoDespacho") = RowOrden.Item("PagoDespacho")
                        TablaPasa.Rows(LugarTabla).Item("TipoPago") = RowOrden.Item("TipoPago")

                        LugarTabla += 1
                        
                    Next
                    
                End If
                
                ' Dim TablaPendienteII As New System.Data.DataTable

                'With TablaPendienteII.Columns
                '    .Add("Orden")
                '    .Add("Carpeta")
                '    .Add("Proveedor")
                '    .Add("Articulo")
                'End With
                '
                'LugarTabla = 0
                '
                'SQLCnslt = "SELECT Orden, Carpeta, Proveedor, Articulo" _
                '& " FROM Orden" _
                '& " WHERE MarcaActualiza = '" & "" & "'" _
                '& " AND FechaOrd >= '" & "20140101" & "'" _
                '& " AND Renglon = 1" _
                '& " AND Tipo = 1" _
                '& " ORDER BY Clave"
                '
                'Dim TablaOrdenII As System.Data.DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))
                'If TablaOrdenII.Rows.Count > 0 Then
                '    For Each RowOrden As DataRow In TablaOrdenII.Rows
                '
                '        TablaPendienteII.Rows.Add()
                '
                '        TablaPendienteII.Rows(LugarTabla).Item("Orden") = RowOrden.Item("Orden")
                '        TablaPendienteII.Rows(LugarTabla).Item("Carpeta") = RowOrden.Item("Carpeta")
                '        TablaPendienteII.Rows(LugarTabla).Item("Proveedor") = RowOrden.Item("Proveedor")
                '        TablaPendienteII.Rows(LugarTabla).Item("Articulo") = RowOrden.Item("Articulo")
                '
                '        LugarTabla += 1
                '    Next
                '
                'End If



                ' For Each RowPendiente As DataRow In TablaPendienteII.Rows
                '     SQLCnslt = "SELECT Fecha" _
                '                & " FROM Informe " _
                '                & " Where Orden ='" & RowPendiente.Item("Orden") & "'" _
                '                & " and Articulo = '" & RowPendiente.Item("Articulo") & "'"
                '
                '     Dim RowPendi As DataRow = GetSingle(SQLCnslt, VectorEmpresas(CiclaEmpresa))
                '
                '     If RowPendi IsNot Nothing Then
                '
                '         Dim fechaactual As Date = Date.Today.ToString()
                '         Dim FechaInforme As Date = RowPendi.Item("Fecha")
                '
                '         Dim ZZDias As Integer = DateDiff("d", FechaInforme, fechaactual)
                '
                '         If ZZDias > 10 Then
                '
                '             TablaAenviar.Rows.Add()
                '             TablaAenviar.Rows(Lugar).Item("Orden") = RowPendiente.Item("Orden")
                '             TablaAenviar.Rows(Lugar).Item("Carpeta") = RowPendiente.Item("Carpeta")
                '             TablaAenviar.Rows(Lugar).Item("Proveedor") = RowPendiente.Item("Proveedor")
                '             TablaAenviar.Rows(Lugar).Item("FechaInforme") = RowPendi.Item("Fecha")
                '             TablaAenviar.Rows(Lugar).Item("Empresa") = VectorEmpresas(CiclaEmpresa)
                '
                '             Lugar += 1
                '
                '         End If
                '
                '
                '
                '     End If
                ' Next


            Next CiclaEmpresa


            'ENVIAR A LA OTRA VENTANA TABLAaENVIAR

            'With New Centro_Importaciones_CarpetasPendientes(TablaAenviar)
            '    .Show(Me)
            'End With



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


                Dim TablaAnticipo As New System.Data.DataTable
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

                    Dim TablaPagos As System.Data.DataTable = GetAll(SQLCnslt, Operador.Base)

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

                                                TablaAnticipo.Rows.Add()
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

                    ExecuteNonQueries(ConectarA, {SQLCnslt})

                    If ZZGrabaII = "S" Then
                        SQLCnslt = "UPDATE Orden SET" _
                                & " TipoPago = '" & ZZTipoPago & "'" _
                                & " WHERE Orden = '" & ZZOrden & "'"
                        ExecuteNonQueries(ConectarA, {SQLCnslt})
                    End If
                    
                End If

            Next

            ZZCiclaProceso = "N"

        End If

        
        Dim WLugar As Integer = 0
        Dim ZZDesde As Integer
        Dim ZZHasta As Integer

      
            ' ESTOS VALORES SALEN DEL VECTOR DE EMPRESA
            ZZDesde = 1
            ZZHasta = 6


        Dim ZZSumaLetra As Double = 0
        Dim ZZSumaDespacho As Double = 0
        Dim ZZSumaArticulo As Double = 0

        lbl_Articulo.Visible = False
        txt_Articulo.Visible = False
        lbl_ArticuloKg.Visible = False

        For CiclaEmpresa = ZZDesde To ZZHasta


            Dim WDesdeFecha As String
            Dim WHastaFecha As String

            Dim filtro As String = ""

            If chk_LetraPendiente.Checked Then
                filtro = " AND PagoLetra = 0"
            End If
            

            SQLCnslt = "SELECT o.Tipo, o.Recibida, o.Cantidad, o.Clave, o.Orden, o.fecha, o.fechaord, " _
                & "o.Proveedor, o.Articulo, o.Cantidad, o.Precio, o.Condicion, o.Moneda, o.Carpeta, " _
                & "o.Djai, o.derechos, o.Origen, o.Leyenda, o.TipoImpo, o.PagoDespacho, o.Fechallegada, " _
                & "o.FechaEmbarque, o.impodespacho, o.tipopago, o.vtodespacho, o.impoletra, o.vtoletra, " _
                & "o.pagoletra, o.fechadjai,  p.Nombre, o.PagoParcialLetra " _
                & " FROM Orden o inner join Proveedor p on o.Proveedor = p.Proveedor" _
                & " WHERE o.Tipo = 1" _
                & " AND o.Cantidad <> 0" _
                & " AND o.Renglon = 1" _
                & " AND fechaOrd >=20140101" _
                & " AND isnull(Orden,'0') <> '0'" _
                & filtro _
                & " ORDER BY o.Clave"
            

            Dim tablaOrd As System.Data.DataTable = GetAll(SQLCnslt, VectorEmpresas(CiclaEmpresa))

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
                        If ZZRecibida <> 0 And RowOrd.Item("PagoLetra") = 1 Then
                            ZEntra = "S"
                        Else
                            ZEntra = "N"
                        End If
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

                        'DGV_Muestra.Rows(WLugar).Cells("Fecha").Value = Microsoft.VisualBasic.Left$(RowOrd.Item("Fecha"), 5) + "/" + Mid$(RowOrd.Item("Fecha"), 9, 2)
                        DGV_Muestra.Rows(WLugar).Cells("Fecha").Value = RowOrd.Item("Fecha")

                        DGV_Muestra.Rows(WLugar).Cells("Proveedor").Value = RowOrd.Item("Nombre")

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

                        Dim TipoImpo As Integer = IIf(IsDBNull(RowOrd.Item("TipoImpo")), 0, RowOrd.Item("TipoImpo"))
                        Select Case TipoImpo
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

                        Dim TipoPago As Integer = IIf(IsDBNull(RowOrd.Item("TipoPago")), 0, RowOrd.Item("TipoPago"))
                        Select Case TipoPago
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

                        DGV_Muestra.Rows(WLugar).Cells("USPagadoLetra").Value = formatonumerico(IIf(IsDBNull(RowOrd.Item("pagoparcialletra")), "0", RowOrd.Item("pagoparcialletra")))


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

        'COLOREAMOS LAS CELDAS SEGUN CORRESPONDA
        ColorearCeldas()

        'ACUMULAMOS EL TOTAL DE LETRA PENDIENTE
        ZZSumaLetra = CalcularTotalLetraPendiente()
       



        'If ColumnaOpcion = 13 Or ColumnaOpcionII = 10 Or ColumnaOpcionIII = 10 Or ZZBorra = "S" Then
        '
        '    Dim TablaPas As New System.Data.DataTable
        '
        '    With TablaPas.Columns
        '        .Add("Orden")
        '        .Add("Pta")
        '        .Add("Fecha")
        '        .Add("Proveedor")
        '        .Add("Mon")
        '        .Add("Carpeta")
        '        .Add("Djai")
        '        .Add("Origen")
        '        .Add("Incoterms")
        '        .Add("Transporte")
        '        .Add("FLLegada")
        '        .Add("TPago")
        '        .Add("Despacho")
        '        .Add("PagoDes")
        '        .Add("LetraTotal")
        '        .Add("PagoLetra")
        '        .Add("VtoLetra")
        '        .Add("UsPagadoLetra")
        '        .Add("FEmbarque")
        '        .Add("SaldoLetra")
        '        .Add("ProveedorCod")
        '    End With
        '
        '
        '    Dim Fila As Integer = 0
        '    For Each row In DGV_Muestra.Rows
        '        TablaPas.Rows.Add()
        '        TablaPas.Rows(Fila).Item("Orden") = row.cells("Orden").value
        '        TablaPas.Rows(Fila).Item("Pta") = row.cells("Pta").value
        '        TablaPas.Rows(Fila).Item("Fecha") = row.cells("Fecha").value
        '        TablaPas.Rows(Fila).Item("Proveedor") = row.cells("Proveedor").value
        '        TablaPas.Rows(Fila).Item("Mon") = row.cells("Mon").value
        '        TablaPas.Rows(Fila).Item("Carpeta") = row.cells("Carpeta").value
        '        TablaPas.Rows(Fila).Item("Djai") = row.cells("Djai").value
        '        TablaPas.Rows(Fila).Item("Origen") = row.cells("Origen").value
        '        TablaPas.Rows(Fila).Item("Incoterms") = row.cells("Incoterms").value
        '        TablaPas.Rows(Fila).Item("Transporte") = row.cells("Transporte").value
        '        TablaPas.Rows(Fila).Item("FLLegada") = row.cells("FLLegada").value
        '        TablaPas.Rows(Fila).Item("TPago") = row.cells("TPago").value
        '        TablaPas.Rows(Fila).Item("Despacho") = row.cells("Despacho").value
        '        TablaPas.Rows(Fila).Item("PagoDes") = row.cells("PagoDes").value
        '        TablaPas.Rows(Fila).Item("LetraTotal") = row.cells("LetraTotal").value
        '        TablaPas.Rows(Fila).Item("PagoLetra") = row.cells("PagoLetra").value
        '        TablaPas.Rows(Fila).Item("VtoLetra") = row.cells("VtoLetra").value
        '        TablaPas.Rows(Fila).Item("UsPagadoLetra") = row.cells("UsPagadoLetra").value
        '        TablaPas.Rows(Fila).Item("FEmbarque") = row.cells("FEmbarque").value
        '        TablaPas.Rows(Fila).Item("SaldoLetra") = row.cells("SaldoLetra").value
        '        TablaPas.Rows(Fila).Item("ProveedorCod") = row.cells("ProveedorCod").value
        '
        '        Fila += 1
        '    Next
        '
        '    DGV_Muestra.Rows.Clear()
        '
        '    Fila = 0
        '
        '    For Each RowPas As DataRow In TablaPas.Rows
        '
        '        ' If Val(RowPas.Item("Orden")) <> 0 Then
        '
        '        DGV_Muestra.Rows.Add()
        '
        '        DGV_Muestra.Rows(Fila).Cells("Orden").Value = RowPas.Item("Orden")
        '        DGV_Muestra.Rows(Fila).Cells("Pta").Value = RowPas.Item("Pta")
        '        DGV_Muestra.Rows(Fila).Cells("Fecha").Value = RowPas.Item("Fecha")
        '        DGV_Muestra.Rows(Fila).Cells("Proveedor").Value = RowPas.Item("Proveedor")
        '        DGV_Muestra.Rows(Fila).Cells("Mon").Value = RowPas.Item("Mon")
        '        DGV_Muestra.Rows(Fila).Cells("Carpeta").Value = RowPas.Item("Carpeta")
        '        DGV_Muestra.Rows(Fila).Cells("Djai").Value = RowPas.Item("Djai")
        '        DGV_Muestra.Rows(Fila).Cells("Origen").Value = RowPas.Item("Origen")
        '        DGV_Muestra.Rows(Fila).Cells("Incoterms").Value = RowPas.Item("Incoterms")
        '        DGV_Muestra.Rows(Fila).Cells("Transporte").Value = RowPas.Item("Transporte")
        '        DGV_Muestra.Rows(Fila).Cells("FLLegada").Value = RowPas.Item("FLLegada")
        '        DGV_Muestra.Rows(Fila).Cells("TPago").Value = RowPas.Item("TPago")
        '        DGV_Muestra.Rows(Fila).Cells("Despacho").Value = RowPas.Item("Despacho")
        '        DGV_Muestra.Rows(Fila).Cells("PagoDes").Value = RowPas.Item("PagoDes")
        '        DGV_Muestra.Rows(Fila).Cells("LetraTotal").Value = RowPas.Item("LetraTotal")
        '        DGV_Muestra.Rows(Fila).Cells("PagoLetra").Value = RowPas.Item("PagoLetra")
        '        DGV_Muestra.Rows(Fila).Cells("VtoLetra").Value = RowPas.Item("VtoLetra")
        '        DGV_Muestra.Rows(Fila).Cells("UsPagadoLetra").Value = RowPas.Item("UsPagadoLetra")
        '        DGV_Muestra.Rows(Fila).Cells("FEmbarque").Value = RowPas.Item("FEmbarque")
        '        DGV_Muestra.Rows(Fila).Cells("SaldoLetra").Value = RowPas.Item("SaldoLetra")
        '        DGV_Muestra.Rows(Fila).Cells("ProveedorCod").Value = RowPas.Item("ProveedorCod")
        '        
        '        Fila += 1
        '        '  End If
        '        Next
        '    
        'End If

        txt_SumaDespacho.Text = formatonumerico(ZZSumaDespacho)
        txt_SumaLetra.Text = formatonumerico(ZZSumaLetra)


        If ColumnaOpcion = 15 Then
            txt_Articulo.Text = formatonumerico(ZZSumaArticulo)
            lbl_Articulo.Visible = True
            lbl_ArticuloKg.Visible = True
            txt_Articulo.Visible = True
        End If
        
    End Sub

    Private Function CalcularTotalLetraPendiente() As Double
        Dim ZZSumaLetra As Double = 0.0
        For Each rowMuestra As DataGridViewRow In DGV_Muestra.Rows

            Dim ZPagoLetra As String = rowMuestra.Cells("PagoLetra").Value
            
            Select Case ZPagoLetra
                Case "Pendiente"
                    ZZSumaLetra = ZZSumaLetra + Val(rowMuestra.Cells("LetraTotal").Value) - Val(rowMuestra.Cells("USPagadoLetra").Value)
                Case Else
            End Select

        Next
        Return ZZSumaLetra
    End Function

    Private Sub ColorearCeldas()
        For Each RowDGV As DataGridViewRow In DGV_Muestra.Rows

            Dim ZDJai As String = RowDGV.Cells("Djai").Value
            Dim ZFechaLlegada As String = RowDGV.Cells("FLLegada").Value
            Dim ZPagoDespacho As String = RowDGV.Cells("PagoDes").Value
            Dim ZPagoLetra As String = RowDGV.Cells("PagoLetra").Value
            Dim ZFechaLetra As String = RowDGV.Cells("VtoLetra").Value
            Dim ZFechaDJai As String = RowDGV.Cells("SaldoLetra").Value

            If Trim(ZDJai) <> "" Then
                If Trim(ZFechaDJai) <> "" Then

                    If ValidaFecha(ZFechaDJai) = "S" Then

                        Dim Wvencimiento As String = Calcula_vencimiento(ZFechaDJai, 180)

                        Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                        Dim ZZOrdFechaDjai As String = Microsoft.VisualBasic.Right$(Wvencimiento, 4) & Mid$(Wvencimiento, 4, 2) & Microsoft.VisualBasic.Left$(Wvencimiento, 2)

                        If ZZOrdFechaDjai < ZZOrdFecha Then
                            RowDGV.Cells("Djai").Style.BackColor = Color.Red
                            RowDGV.Cells("Djai").Style.ForeColor = Color.White
                        End If
                    End If
                End If
            End If

            If ZPagoDespacho = "Pendiente" Then
                Dim ZZOrdFechaLlegada As String = Microsoft.VisualBasic.Right$(ZFechaLlegada, 4) & Mid$(ZFechaLlegada, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLlegada, 2)
                Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                If ZZOrdFechaLlegada <= ZZOrdFecha Then
                    RowDGV.Cells("Despacho").Style.BackColor = Color.Red
                    RowDGV.Cells("Despacho").Style.ForeColor = Color.White
                End If
            End If

            If ZPagoLetra = "Pendiente" Then
                If ZFechaLetra <> "" And ZFechaLetra <> "  /  /    " Then
                    Dim ZZOrdFechaLetra As String = Microsoft.VisualBasic.Right$(ZFechaLetra, 4) & Mid$(ZFechaLetra, 4, 2) & Microsoft.VisualBasic.Left$(ZFechaLetra, 2)
                    Dim ZZOrdFecha As String = Date.Today.ToString("yyyyMMdd")
                    If ZZOrdFechaLetra <= ZZOrdFecha Then
                        RowDGV.Cells("LetraTotal").Style.BackColor = Color.Red
                        RowDGV.Cells("LetraTotal").Style.ForeColor = Color.White
                    End If
                End If
            End If
        Next
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



        'cbx_Ordenamiento.SelectedIndex = 5

        cbx_FiltroI.SelectedIndex = 0
        cbx_FiltroII.SelectedIndex = 0
        cbx_FiltroIII.SelectedIndex = 0

        cbx_Activas.SelectedIndex = 0

        ZProcesa = ""



        'Call OrdenaI_click()

        REM Call Proceso_Click
        Proceso_Click()



    End Sub

    Private Sub btn_Actualiza_Click(sender As Object, e As EventArgs) Handles btn_Actualiza.Click
        Proceso_Click()
    End Sub

    Private Sub chk_LetraPendiente_CheckedChanged(sender As Object, e As EventArgs) Handles chk_LetraPendiente.CheckedChanged
        Proceso_Click()
    End Sub

    ' Private Sub cbx_FiltroI_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_FiltroI.DropDownClosed
    '
    '     ColumnaOpcion = cbx_FiltroI.SelectedIndex
    '     ZZFiltroOrdenI = cbx_FiltroI.SelectedIndex
    '     ZZTipoFiltro = 1
    '
    '
    '
    '     Select Case ColumnaOpcion
    '         Case 0
    '             Call Proceso_Click()
    '
    '         Case 1
    '             With New Ventana_auxiliar(ColumnaOpcion, cbx_Activas.SelectedIndex)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 2
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 3
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '         Case 4, 6, 7
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 5
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '         Case 8, 9, 11, 12, 13
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '         Case 10
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '         Case 14
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '         Case 15
    '             With New Ventana_auxiliar(ColumnaOpcion)
    '                 .Show(Me)
    '             End With
    '
    '
    '     End Select
    ' End Sub

    ' Public Sub PasaFiltro(Filtro As String) Implements ICentroImportaciones_auxiliar.PasaFiltro
    '     If Filtro <> "" Then
    '         Select Case ZZTipoFiltro
    '             Case 1
    '                 Seleccion = Filtro
    '             Case 2
    '                 SeleccionIII = Filtro
    '             Case Else
    '                 SeleccionV = Filtro
    '         End Select
    '
    '     Else
    '
    '         Seleccion = ""
    '
    '         Select Case ZZTipoFiltro
    '             Case 1
    '                 ColumnaOpcion = 0
    '             Case 2
    '                 ColumnaOpcionII = 0
    '             Case Else
    '                 ColumnaOpcionIII = 0
    '         End Select
    '
    '     End If
    '
    '     Proceso_Click()
    ' End Sub
    '
    ' Public Sub pasafechas(Desde As String, Hasta As String) Implements ICentroImportaciones_auxiliar.pasafechas
    '     Select Case ZZTipoFiltro
    '         Case 1
    '             Seleccion = Desde
    '             SeleccionII = Hasta
    '         Case 2
    '             SeleccionIII = Desde
    '             SeleccionIV = Hasta
    '         Case 3
    '             SeleccionV = Desde
    '             SeleccionVI = Hasta
    '         Case Else
    '     End Select
    '
    '
    '     Call Proceso_Click()
    '
    ' End Sub
    '
    ' Public Sub PasaOrden(Orden As String, Planta As String) Implements ICentroImportaciones_auxiliar.PasaOrden
    '
    '     Dim SQLCnslt As String = "SELECT o.Tipo, o.Recibida, o.Cantidad, o.Clave, o.Orden, o.fecha, o.fechaord, " _
    '                  & "o.Proveedor, o.Articulo, o.Cantidad, o.Precio, o.Condicion, o.Moneda, o.Carpeta, " _
    '                  & "o.Djai, o.derechos, o.Origen, o.Leyenda, o.TipoImpo, o.PagoDespacho, o.Fechallegada, " _
    '                  & "o.FechaEmbarque, o.impodespacho, o.tipopago, o.vtodespacho, o.impoletra, o.vtoletra, " _
    '                  & "o.pagoletra, o.fechadjai, o.PagoParcialLetra,  p.Nombre " _
    '                  & " FROM Orden o INNER JOIN Proveedor p ON o.Proveedor = p.Proveedor" _
    '                  & " WHERE o.Orden = '" & Orden & "'" _
    '                  & " AND fechaord >=20140101"
    '
    '     Dim RowOrden As DataRow = GetSingle(SQLCnslt, Planta)
    '     If RowOrden IsNot Nothing Then
    '
    '         DGV_Muestra.Rows.Clear()
    '         DGV_Muestra.Rows.Add()
    '         Dim lugar As Integer = 0
    '         Dim ZDJai As String = IIf(IsDBNull(RowOrden.Item("DJai")), "", RowOrden.Item("DJai"))
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("Orden").Value = RowOrden.Item("Orden")
    '
    '         Dim WPta As String
    '         Select Case UCase(Planta)
    '             Case "SURFACTANSA"
    '                 WPta = "I"
    '             Case "SURFACTAN_II"
    '                 WPta = "II"
    '             Case "SURFACTAN_III"
    '                 WPta = "III"
    '             Case "SURFACTAN_V"
    '                 WPta = "V"
    '             Case "SURFACTAN_VI"
    '                 WPta = "VI"
    '             Case "SURFACTAN_VII"
    '                 WPta = "VII"
    '             Case Else
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Pta").Value = WPta
    '
    '         DGV_Muestra.Rows(lugar).Cells("Fecha").Value = Microsoft.VisualBasic.Left$(RowOrden.Item("Fecha"), 5) + "/" + Mid$(RowOrden.Item("Fecha"), 9, 2)
    '         DGV_Muestra.Rows(lugar).Cells("Proveedor").Value = RowOrden.Item("Nombre")
    '
    '         Dim WMon As String
    '         Select Case RowOrden.Item("Moneda")
    '             Case 0
    '                 WMon = "U$S"
    '             Case 1
    '                 WMon = "$"
    '             Case 2
    '                 WMon = "Eur"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Mon").Value = WMon
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("Carpeta").Value = RowOrden.Item("Carpeta")
    '         DGV_Muestra.Rows(lugar).Cells("Djai").Value = ZDJai
    '         DGV_Muestra.Rows(lugar).Cells("Origen").Value = RowOrden.Item("Origen")
    '
    '         Dim WIncoterms As String
    '         Select Case RowOrden.Item("Leyenda")
    '             Case 1
    '                 WIncoterms = "FOB"
    '             Case 2
    '                 WIncoterms = "CIF"
    '             Case 3
    '                 WIncoterms = "CFR"
    '             Case 4
    '                 WIncoterms = "CPT"
    '             Case 5
    '                 WIncoterms = "EXW"
    '             Case 6
    '                 WIncoterms = "FCA"
    '             Case Else
    '                 WIncoterms = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Incoterms").Value = WIncoterms
    '
    '         Dim WTransporte As String
    '         Select Case RowOrden.Item("TipoImpo")
    '             Case 1
    '                 WTransporte = "Maritimo"
    '             Case 2
    '                 WTransporte = "Terrestre"
    '             Case 3
    '                 WTransporte = "Aereo"
    '             Case Else
    '                 WTransporte = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Transporte").Value = WTransporte
    '
    '         DGV_Muestra.Rows(lugar).Cells("FLLegada").Value = IIf(IsDBNull(RowOrden.Item("FechaLlegada")), "", RowOrden.Item("FechaLlegada"))
    '
    '         Dim WTPago As String
    '         Select Case RowOrden.Item("TipoPago")
    '             Case 1
    '                 WTPago = "Pago Anti."
    '             Case 2
    '                 WTPago = "A la vista"
    '             Case 3
    '                 WTPago = "Cta.Cte."
    '             Case Else
    '                 WTPago = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("TPago").Value = WTPago
    '
    '         DGV_Muestra.Rows(lugar).Cells("Despacho").Value = formatonumerico(RowOrden.Item("ImpoDespacho"))
    '
    '
    '         Dim WPagoDes As String
    '         Select Case RowOrden.Item("PagoDespacho")
    '             Case 0
    '                 WPagoDes = "Pendiente"
    '             Case Else
    '                 WPagoDes = "Pagado"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("PagoDes").Value = WPagoDes
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("LetraTotal").Value = formatonumerico(RowOrden.Item("ImpoLetra"))
    '
    '
    '         Dim WPagoLetra As String
    '         Select Case RowOrden.Item("PagoLetra")
    '             Case 0
    '                 WPagoLetra = "Pendiente"
    '             Case Else
    '                 WPagoLetra = "Pagado"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("PagoLetra").Value = WPagoLetra
    '
    '         DGV_Muestra.Rows(lugar).Cells("VtoLetra").Value = RowOrden.Item("VtoLetra")
    '         DGV_Muestra.Rows(lugar).Cells("USPagadoLetra").Value = RowOrden.Item("PagoParcialLetra")
    '         DGV_Muestra.Rows(lugar).Cells("FEmbarque").Value = IIf(IsDBNull(RowOrden.Item("FechaEmbarque")), "", RowOrden.Item("FechaEmbarque"))
    '         DGV_Muestra.Rows(lugar).Cells("SaldoLetra").Value = IIf(IsDBNull(RowOrden.Item("FechaDJai")), "", RowOrden.Item("FechaDJai"))
    '         DGV_Muestra.Rows(lugar).Cells("ProveedorCod").Value = RowOrden.Item("Proveedor")
    '
    '         Dim ZZSumaLetra As Double = Val(DGV_Muestra.Rows(lugar).Cells("LetraTotal").Value) - Val(DGV_Muestra.Rows(lugar).Cells("USPagadoLetra").Value)
    '         Dim ZZSumaDespacho As Double = Val(DGV_Muestra.Rows(lugar).Cells("Despacho").Value)
    '
    '         txt_SumaDespacho.Text = formatonumerico(ZZSumaDespacho)
    '
    '
    '         txt_SumaLetra.Text = formatonumerico(ZZSumaLetra)
    '     End If
    '
    '
    ' End Sub
    '
    ' Public Sub PasaCarpeta(Carpeta As String, Planta As String) Implements ICentroImportaciones_auxiliar.PasaCarpeta
    '
    '     Dim SQLCnslt As String = "SELECT o.Tipo, o.Recibida, o.Cantidad, o.Clave, o.Orden, o.fecha, o.fechaord, " _
    '                  & "o.Proveedor, o.Articulo, o.Cantidad, o.Precio, o.Condicion, o.Moneda, o.Carpeta, " _
    '                  & "o.Djai, o.derechos, o.Origen, o.Leyenda, o.TipoImpo, o.PagoDespacho, o.Fechallegada, " _
    '                  & "o.FechaEmbarque, o.impodespacho, o.tipopago, o.vtodespacho, o.impoletra, o.vtoletra, " _
    '                  & "o.pagoletra, o.fechadjai, o.PagoParcialLetra,  p.Nombre " _
    '                  & " FROM Orden o INNER JOIN Proveedor p ON o.Proveedor = p.Proveedor" _
    '                  & " WHERE o.Carpeta = '" & Carpeta & "'" _
    '                  & " AND fechaord >=20140101"
    '
    '     Dim RowOrden As DataRow = GetSingle(SQLCnslt, Planta)
    '     If RowOrden IsNot Nothing Then
    '
    '         DGV_Muestra.Rows.Clear()
    '         DGV_Muestra.Rows.Add()
    '         Dim lugar As Integer = 0
    '         Dim ZDJai As String = IIf(IsDBNull(RowOrden.Item("DJai")), "", RowOrden.Item("DJai"))
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("Orden").Value = RowOrden.Item("Orden")
    '
    '         Dim WPta As String
    '         Select Case UCase(Planta)
    '             Case "SURFACTANSA"
    '                 WPta = "I"
    '             Case "SURFACTAN_II"
    '                 WPta = "II"
    '             Case "SURFACTAN_III"
    '                 WPta = "III"
    '             Case "SURFACTAN_V"
    '                 WPta = "V"
    '             Case "SURFACTAN_VI"
    '                 WPta = "VI"
    '             Case "SURFACTAN_VII"
    '                 WPta = "VII"
    '             Case Else
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Pta").Value = WPta
    '
    '         DGV_Muestra.Rows(lugar).Cells("Fecha").Value = Microsoft.VisualBasic.Left$(RowOrden.Item("Fecha"), 5) + "/" + Mid$(RowOrden.Item("Fecha"), 9, 2)
    '         DGV_Muestra.Rows(lugar).Cells("Proveedor").Value = RowOrden.Item("Nombre")
    '
    '         Dim WMon As String
    '         Select Case RowOrden.Item("Moneda")
    '             Case 0
    '                 WMon = "U$S"
    '             Case 1
    '                 WMon = "$"
    '             Case 2
    '                 WMon = "Eur"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Mon").Value = WMon
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("Carpeta").Value = RowOrden.Item("Carpeta")
    '         DGV_Muestra.Rows(lugar).Cells("Djai").Value = ZDJai
    '         DGV_Muestra.Rows(lugar).Cells("Origen").Value = RowOrden.Item("Origen")
    '
    '         Dim WIncoterms As String
    '         Select Case RowOrden.Item("Leyenda")
    '             Case 1
    '                 WIncoterms = "FOB"
    '             Case 2
    '                 WIncoterms = "CIF"
    '             Case 3
    '                 WIncoterms = "CFR"
    '             Case 4
    '                 WIncoterms = "CPT"
    '             Case 5
    '                 WIncoterms = "EXW"
    '             Case 6
    '                 WIncoterms = "FCA"
    '             Case Else
    '                 WIncoterms = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Incoterms").Value = WIncoterms
    '
    '         Dim WTransporte As String
    '         Select Case RowOrden.Item("TipoImpo")
    '             Case 1
    '                 WTransporte = "Maritimo"
    '             Case 2
    '                 WTransporte = "Terrestre"
    '             Case 3
    '                 WTransporte = "Aereo"
    '             Case Else
    '                 WTransporte = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("Transporte").Value = WTransporte
    '
    '         DGV_Muestra.Rows(lugar).Cells("FLLegada").Value = IIf(IsDBNull(RowOrden.Item("FechaLlegada")), "", RowOrden.Item("FechaLlegada"))
    '
    '         Dim WTPago As String
    '         Select Case RowOrden.Item("TipoPago")
    '             Case 1
    '                 WTPago = "Pago Anti."
    '             Case 2
    '                 WTPago = "A la vista"
    '             Case 3
    '                 WTPago = "Cta.Cte."
    '             Case Else
    '                 WTPago = ""
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("TPago").Value = WTPago
    '
    '         DGV_Muestra.Rows(lugar).Cells("Despacho").Value = formatonumerico(RowOrden.Item("ImpoDespacho"))
    '
    '
    '         Dim WPagoDes As String
    '         Select Case RowOrden.Item("PagoDespacho")
    '             Case 0
    '                 WPagoDes = "Pendiente"
    '             Case Else
    '                 WPagoDes = "Pagado"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("PagoDes").Value = WPagoDes
    '
    '
    '         DGV_Muestra.Rows(lugar).Cells("LetraTotal").Value = formatonumerico(RowOrden.Item("ImpoLetra"))
    '
    '
    '         Dim WPagoLetra As String
    '         Select Case RowOrden.Item("PagoLetra")
    '             Case 0
    '                 WPagoLetra = "Pendiente"
    '             Case Else
    '                 WPagoLetra = "Pagado"
    '         End Select
    '         DGV_Muestra.Rows(lugar).Cells("PagoLetra").Value = WPagoLetra
    '
    '         DGV_Muestra.Rows(lugar).Cells("VtoLetra").Value = RowOrden.Item("VtoLetra")
    '         DGV_Muestra.Rows(lugar).Cells("USPagadoLetra").Value = RowOrden.Item("PagoParcialLetra")
    '         DGV_Muestra.Rows(lugar).Cells("FEmbarque").Value = IIf(IsDBNull(RowOrden.Item("FechaEmbarque")), "", RowOrden.Item("FechaEmbarque"))
    '         DGV_Muestra.Rows(lugar).Cells("SaldoLetra").Value = IIf(IsDBNull(RowOrden.Item("FechaDJai")), "", RowOrden.Item("FechaDJai"))
    '         DGV_Muestra.Rows(lugar).Cells("ProveedorCod").Value = RowOrden.Item("Proveedor")
    '
    '         Dim ZZSumaLetra As Double = Val(DGV_Muestra.Rows(lugar).Cells("LetraTotal").Value) - Val(DGV_Muestra.Rows(lugar).Cells("USPagadoLetra").Value)
    '         Dim ZZSumaDespacho As Double = Val(DGV_Muestra.Rows(lugar).Cells("Despacho").Value)
    '
    '         txt_SumaDespacho.Text = formatonumerico(ZZSumaDespacho)
    '
    '
    '         txt_SumaLetra.Text = formatonumerico(ZZSumaLetra)
    '     End If
    '
    ' End Sub
    '
    ' Public Sub PasaTXTDjai(Fecha As String) Implements ICentroImportaciones_auxiliar.PasaTXTDjai
    '
    '
    '     Dim ZZPasa(1000, 10) As String
    '     Dim ZZLugarPasa As Integer
    '     Dim LugarPlanilla As Integer
    '
    '     Erase ZZPasa
    '     ZZLugarPasa = 0
    '     LugarPlanilla = 7
    '
    '     REM
    '     REM proceso los comodatos
    '     REM
    '
    '     '' Creamos un objeto Excel
    '
    '     Dim appExcel = CreateObject("Excel.application")
    '
    '     Dim ruta As String = "C:\Djai\djai.xls"
    '
    '     If Len(Dir(ruta)) > 0 Then
    '
    '         Dim objLibro = appExcel.workbooks.Open(ruta)
    '
    '         Do
    '
    '             LugarPlanilla = LugarPlanilla + 1
    '
    '
    '             Dim Aa4 As Double = appExcel.cells(LugarPlanilla, 4).Value
    '
    '             Dim Aa9 As String = appExcel.cells(LugarPlanilla, 9).Value
    '
    '             If Trim(appExcel.cells(LugarPlanilla, 1).Value) <> "" Then
    '
    '                 If Val(Aa4) <> 0 And Trim(Aa9) <> "" Then
    '                     REM If Mid$(FechaTxtDjai.Text, 4, 7) = Mid$(appExcel.cells(LugarPlanilla, 6).Value, 4, 7) Then
    '
    '                     ZZLugarPasa = ZZLugarPasa + 1
    '
    '                     ZZPasa(ZZLugarPasa, 1) = appExcel.cells(LugarPlanilla, 1).Value
    '                     ZZPasa(ZZLugarPasa, 2) = appExcel.cells(LugarPlanilla, 2).Value
    '                     ZZPasa(ZZLugarPasa, 3) = appExcel.cells(LugarPlanilla, 3).Value
    '                     Dim ZZImporte As Double = appExcel.cells(LugarPlanilla, 4).Value
    '                     ZZPasa(ZZLugarPasa, 4) = Str$(ZZImporte)
    '                     ZZPasa(ZZLugarPasa, 5) = appExcel.cells(LugarPlanilla, 5).Value
    '                     ZZPasa(ZZLugarPasa, 6) = appExcel.cells(LugarPlanilla, 6).Value
    '                     ZZPasa(ZZLugarPasa, 7) = appExcel.cells(LugarPlanilla, 7).Value
    '                     ZZPasa(ZZLugarPasa, 8) = appExcel.cells(LugarPlanilla, 8).Value
    '                     ZZPasa(ZZLugarPasa, 9) = appExcel.cells(LugarPlanilla, 9).Value
    '
    '                 End If
    '
    '             Else
    '
    '                 If LugarPlanilla = 1000 Then
    '                     Exit Do
    '                 End If
    '
    '
    '             End If
    '
    '         Loop
    '
    '         appExcel.Quit()
    '
    '     End If
    '
    '
    '
    '     Dim XNOmbre As String = "c:\DJAI\F4106." & "30549165083." & Microsoft.VisualBasic.Right$(Fecha, 4) & Mid$(Fecha, 4, 2) & "00.0000.txt"
    '
    '     'Abro el archivos para que sino existe lo creo
    '     Dim Test As New FileStream(XNOmbre, FileMode.OpenOrCreate)
    '     Test.Close()
    '
    '     Dim Archivo As New StreamWriter(XNOmbre)
    '     'open XNombreFor Output As #1
    '
    '     Dim WImpo1 As String = "01"
    '     Dim WImpo2 As String = "30549165083"
    '     Dim WImpo3 As String = "4106"
    '     Dim WImpo4 As String = "00100"
    '     Dim WImpo5 As String = Microsoft.VisualBasic.Right$(Fecha, 4) & Mid$(Fecha, 4, 2)
    '     Dim WImpo6 As String = "00"
    '     Dim WImpo7 As String = "0103"
    '     Dim WImpo8 As String = "857"
    '
    '     Dim WImpre As String = WImpo1 + WImpo2 + WImpo3 + WImpo4 + WImpo5 + WImpo6 + WImpo7 + WImpo8
    '
    '     Archivo.WriteLine(WImpre)
    '     ' Print #1, WImpre
    '
    '
    '     For Ciclo = 1 To ZZLugarPasa
    '
    '         WImpo1 = "02"
    '         WImpo2 = Trim(ZZPasa(Ciclo, 9))
    '         WImpo3 = Trim(ZZPasa(Ciclo, 7))
    '         WImpo4 = Trim(ZZPasa(Ciclo, 9))
    '         WImpo5 = Str$(Val(ZZPasa(Ciclo, 4)) * 100)
    '         WImpo5 = WImpo5.PadLeft(15, "0")
    '
    '
    '         WImpre = WImpo1 + WImpo2 + WImpo3 + WImpo4 + WImpo5
    '         Archivo.WriteLine(WImpre)
    '         ' Print #1, WImpre
    '
    '     Next Ciclo
    '
    '     Archivo.Close()
    '     'Close #1
    '
    '
    '     Dim mensaje As String = "El archivo se a generado el archivo " & "c:\DJAI\F4106." & "30549165083." & Microsoft.VisualBasic.Right$(Fecha, 4) & Mid$(Fecha, 4, 2) & "00.0000.txt"
    '     MsgBox(mensaje, 0, "Archivo de Proveedores")
    '
    '
    '
    '
    '
    ' End Sub

    ' Private Sub cbx_FiltroII_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_FiltroII.DropDownClosed
    '
    '     Dim SelecionadoFiltro As Integer = cbx_FiltroII.SelectedIndex
    '     ColumnaOpcionII = cbx_FiltroII.SelectedIndex
    '
    '
    '
    '     'LE AGREGO UN MAS 1 o 3 PARA QUE SE IGUALE A EL FILTRO I 
    '     'QUE TIENE MAS VALORES
    '     If SelecionadoFiltro > 0 Then
    '         If SelecionadoFiltro >= 1 And SelecionadoFiltro <= 3 Then
    '             SelecionadoFiltro += 1
    '         Else
    '             SelecionadoFiltro += 3
    '         End If
    '
    '     End If
    '
    '     ZZFiltroOrdenII = cbx_FiltroII.SelectedIndex
    '     ZZTipoFiltro = 2
    '
    '
    '
    '
    '     Select Case SelecionadoFiltro
    '         Case 0 'Vacio
    '             '  Call Proceso_Click()
    '
    '         Case 1 'ORDEN
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 2 'PLANTA
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 3 'FECHA
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 4, 6, 7 '4- Proveedor/ 6-DJai / 7-Origen  
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 5 'Carpeta
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 8, 9, 11, 12, 13 '8-Incoterms /9-Transporte/11-TPago/12-PagoDespacho/13-PagoLetra
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '         Case 10 ' FLLegada
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 14 'VtoLetra
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 15 'M.Prima
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '     End Select
    '
    '
    '
    '
    ' End Sub
    '
    ' Private Sub cbx_FiltroIII_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_FiltroIII.DropDownClosed
    '
    '     Dim SelecionadoFiltro As Integer = cbx_FiltroIII.SelectedIndex
    '     ColumnaOpcionIII = cbx_FiltroIII.SelectedIndex
    '
    '
    '
    '     'LE AGREGO UN MAS 1 o 3 PARA QUE SE IGUALE A EL FILTRO I 
    '     'QUE TIENE MAS VALORES
    '     If SelecionadoFiltro > 0 Then
    '         If SelecionadoFiltro >= 1 And SelecionadoFiltro <= 3 Then
    '             SelecionadoFiltro += 1
    '         Else
    '             SelecionadoFiltro += 3
    '         End If
    '
    '     End If
    '
    '     ZZFiltroOrdenIII = cbx_FiltroIII.SelectedIndex
    '     ZZTipoFiltro = 3
    '
    '
    '
    '
    '     Select Case SelecionadoFiltro
    '         Case 0 'Vacio
    '             '  Call Proceso_Click()
    '
    '         Case 1 'ORDEN
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 2 'PLANTA
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 3 'FECHA
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 4, 6, 7 '4- Proveedor/ 6-DJai / 7-Origen  
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '         Case 5 'Carpeta
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 8, 9, 11, 12, 13 '8-Incoterms /9-Transporte/11-TPago/12-PagoDespacho/13-PagoLetra
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '         Case 10 ' FLLegada
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 14 'VtoLetra
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '         Case 15 'M.Prima
    '             With New Ventana_auxiliar(SelecionadoFiltro)
    '                 .Show(Me)
    '             End With
    '
    '
    '     End Select
    '
    '
    ' End Sub

    Private Sub DGV_Muestra_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_Muestra.SortCompare
        Dim num1, num2

        Select Case e.Column.Index
            Case 0, 5
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)
            Case 1
                Select Case e.CellValue1
                    Case "I"
                        num1 = 1
                    Case "II"
                        num1 = 2
                    Case "III"
                        num1 = 3
                    Case "V"
                        num1 = 5
                    Case "VI"
                        num1 = 6
                    Case "VII"
                        num1 = 7
                End Select
                Select Case e.CellValue2
                    Case "I"
                        num2 = 1
                    Case "II"
                        num2 = 2
                    Case "III"
                        num2 = 3
                    Case "V"
                        num2 = 5
                    Case "VI"
                        num2 = 6
                    Case "VII"
                        num2 = 7
                End Select

            Case 3, 4, 6, 7, 8, 9, 11, 13, 15
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 2, 10, 16, 18, 19
                'Fechas
                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

            Case 12, 14, 17
                'Numericos con coma
                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)
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

    ' Private Sub btn_Exportacion_Click(sender As Object, e As EventArgs) Handles btn_Exportacion.Click
    '
    '     Dim SQLCnlst As String = "DELETE ControlImpoImpre"
    '
    '     ExecuteNonQueries(Operador.Base, {SQLCnlst})
    '
    '     Dim ListaSQLCnslt As New List(Of String)
    '
    '     For Each DGVRow As DataGridViewRow In DGV_Muestra.SelectedRows
    '
    '         Dim ZOrden As String = DGVRow.Cells("Orden").Value
    '         Dim ZPta As String = DGVRow.Cells("Pta").Value
    '         Dim ZFecha As String = DGVRow.Cells("Fecha").Value
    '         Dim ZProveedor As String = DGVRow.Cells("Proveedor").Value
    '         Dim ZMoneda As String = DGVRow.Cells("Mon").Value
    '         Dim ZCarpeta As String = DGVRow.Cells("Carpeta").Value
    '         Dim ZDJai As String = DGVRow.Cells("Djai").Value
    '         Dim ZOrigen As String = DGVRow.Cells("Origen").Value
    '         Dim ZIncoterms As String = DGVRow.Cells("Incoterms").Value
    '         Dim ZTransporte As String = DGVRow.Cells("Transporte").Value
    '         Dim ZFLLegada As String = DGVRow.Cells("FLLegada").Value
    '         Dim ZTPago As String = DGVRow.Cells("TPago").Value
    '         Dim ZDespacho As String = DGVRow.Cells("Despacho").Value
    '         Dim ZPagoDespacho As String = DGVRow.Cells("PagoDes").Value
    '         Dim ZLetra As String = DGVRow.Cells("LetraTotal").Value
    '         Dim ZPagoLetra As String = DGVRow.Cells("PagoLetra").Value
    '         Dim ZVtoLetra As String = DGVRow.Cells("VtoLetra").Value
    '         Dim ZPagoParcial As String = DGVRow.Cells("UsPagadoLetra").Value
    '         Dim ZFEmbarque As String = DGVRow.Cells("FEmbarque").Value
    '
    '         Dim ZSumaI As String = "0"
    '         If ZPagoDespacho = "Pendiente" Then
    '             ZSumaI = ZDespacho
    '         End If
    '         Dim ZSumaII As String = "0"
    '         If ZPagoLetra = "Pendiente" Then
    '             ZSumaII = Str(Val(ZLetra) - Val(ZPagoParcial))
    '             If Val(ZSumaII) < 0 Then
    '                 ZSumaII = "0"
    '             End If
    '         End If
    '
    '
    '         SQLCnlst = "INSERT INTO ControlImpoImpre (" _
    '         & "Orden ," _
    '         & "Pta ," _
    '         & "Fecha ," _
    '         & "Proveedor ," _
    '         & "Moneda ," _
    '         & "Carpeta ," _
    '         & "Djai ," _
    '         & "Origen ," _
    '         & "Incoterms ," _
    '         & "Transporte," _
    '         & "FLLegada  ," _
    '         & "TPago ," _
    '         & "SumaI ," _
    '         & "SumaII ," _
    '         & "Despacho ," _
    '         & "PagoDespacho ," _
    '         & "Letra ," _
    '         & "PagoLetra ," _
    '         & "VtoLetra ," _
    '         & "PagoParcial ," _
    '         & "FEmbarque) " _
    '         & "Values (" _
    '         & "'" & ZOrden & "'," _
    '         & "'" & ZPta & "'," _
    '         & "'" & ZFecha & "'," _
    '         & "'" & ZProveedor & "'," _
    '         & "'" & ZMoneda & "'," _
    '         & "'" & ZCarpeta & "'," _
    '         & "'" & ZDJai & "'," _
    '         & "'" & ZOrigen & "'," _
    '         & "'" & ZIncoterms & "'," _
    '         & "'" & ZTransporte & "'," _
    '         & "'" & ZFLLegada & "'," _
    '         & "'" & ZTPago & "'," _
    '         & "'" & ZSumaI & "'," _
    '         & "'" & ZSumaII & "'," _
    '         & "'" & ZDespacho & "'," _
    '         & "'" & ZPagoDespacho & "'," _
    '         & "'" & ZLetra & "'," _
    '         & "'" & ZPagoLetra & "'," _
    '         & "'" & ZVtoLetra & "'," _
    '         & "'" & ZPagoParcial & "'," _
    '         & "'" & ZFEmbarque & "')"
    '
    '         ListaSQLCnslt.Add(SQLCnlst)
    '     Next
    '
    '     If ListaSQLCnslt.Count > 0 Then
    '         ExecuteNonQueries(Operador.Base, ListaSQLCnslt.ToArray())
    '
    '         With New VistaPrevia
    '             .Reporte = New Reporte_CentroDe_Exportacion()
    '
    '             .Mostrar()
    '         End With
    '     End If
    '
    '
    '
    ' End Sub
    '
    ' Private Sub DGV_Muestra_MouseUp(sender As Object, e As MouseEventArgs) Handles DGV_Muestra.MouseUp
    '
    '     For Each cell As DataGridViewCell In DGV_Muestra.SelectedCells
    '         DGV_Muestra.Rows(cell.RowIndex).Selected = True
    '
    '     Next
    ' End Sub
    '
    Private Sub DGV_Muestra_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Muestra.CellMouseClick
        DGV_Muestra.Rows(DGV_Muestra.CurrentCell.RowIndex).Selected = True
    End Sub
    '
    ' Private Sub btn_Djai_Click(sender As Object, e As EventArgs) Handles btn_Djai.Click
    '     With New Ventana_auxiliar(20)
    '         .Show(Me)
    '     End With
    ' End Sub
    '
    Private Sub DGV_Muestra_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Muestra.CellMouseDoubleClick

        Dim Worden As String = DGV_Muestra.CurrentRow.Cells("Orden").Value
        Dim WCarpeta As String = DGV_Muestra.CurrentRow.Cells("Carpeta").Value
        Dim WPlanta As String = DGV_Muestra.CurrentRow.Cells("Pta").Value

        Dim WEmpresa As String = ""
        Select Case WPlanta
            Case "I"
                WEmpresa = "SurfactanSa"
            Case "II"
                WEmpresa = "Surfactan_II"
            Case "III"
                WEmpresa = "Surfactan_III"
            Case "V"
                WEmpresa = "Surfactan_V"
            Case "VI"
                WEmpresa = "Surfactan_VI"
            Case "VII"
                WEmpresa = "Surfactan_VII"
        End Select

        With New IngresoOrdenComprayObservaciones(Worden, WCarpeta, WEmpresa)
            .Show()
        End With
        
        'With New Ingreso_OrdenCompra(Worden, WCarpeta, WEmpresa)
        '    .Show()
        'End With
        '
        '
        'With New IngresoObservaciones_Orden(Worden, WCarpeta, WEmpresa)
        '    .Show()
        'End With
    End Sub

    Private Sub dgv_DGV_Muestra_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_Muestra.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 1, 3, 4, 6, 7, 8, 9, 11, 13, 15
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 0, 5
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)

            Case 12, 14, 17
                'Double
                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 2, 10, 16, 18, 19
                'Fechas
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


End Class
