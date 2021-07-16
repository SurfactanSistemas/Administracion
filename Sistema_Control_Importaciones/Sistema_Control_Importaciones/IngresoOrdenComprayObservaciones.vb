Imports System.Data.SqlClient
Imports System.IO
Imports GestorDeArchivos
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Microsoft.Office.Interop
Imports System.Configuration


Public Class IngresoOrdenComprayObservaciones

    Dim WCARPETA As String
    Dim WORDEN As String
    Dim WBASEACONECTAR As String


    Dim WORIGEN As String
    Dim WMONEDA As String
    Dim WTIPOPAGO As String
    Dim WLEYENDA As String
    Dim WPEDIDOIMPO As String
    Dim WFECHAIMPO As String
    Dim WTIPOIMPO As String
    Dim WFLETE As String
    Dim WFECHA As String
    Dim WPROVEEDOR As String
    Dim WDESPROVEEDOR As String
    Dim WDJAI As String
    Dim WFECHADJAI As String

    Dim Tabla_Aux As New DataTable


    Dim WFechaCoordinacionAnterior As String
    Dim WHoraCoordinacionAnterior As String

    Sub New(ByVal NumeroOrden As String, ByVal NumeroCarpeta As String, ByVal BaseConectar As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        WCARPETA = NumeroCarpeta
        WORDEN = NumeroOrden
        WBASEACONECTAR = BaseConectar


        'PARTE ORDEN

        Cbx_PagoDespacho.SelectedIndex = 0
        
        cbx_PagoLetra.SelectedIndex = 0
        
        cbx_EntregaI.SelectedIndex = 0

        cbx_EntregaII.SelectedIndex = 0
        '
        ' Call Limpia_VectorII()
        '
        ' WRenglon = 0
        '
        Dim SQLCnslt As String = "SELECT Texto1, Texto2 FROM ObservaOrden WHERE Carpeta = '" & NumeroCarpeta & "' ORDER BY Clave"

        Dim tabla As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tabla.Rows.Count > 0 Then
            For Each rowAux As DataRow In tabla.Rows
                Dim Texto1 As String = IIf(IsDBNull(rowAux.Item("Texto1")), "", rowAux.Item("Texto1"))
                Dim Texto2 As String = IIf(IsDBNull(rowAux.Item("Texto2")), "", rowAux.Item("Texto2"))
                DGV_Observaciones.Rows.Add(Texto1, Texto2)
            Next

        End If

        Dim CodOrdenAux As String = NumeroOrden.PadLeft(6, "0")

        Dim WClave As String = CodOrdenAux + "01"



        SQLCnslt = "SELECT FechaEmbarque, FechaLlegada, PagoDespacho, ImpoDespacho, VtoDespacho, PagoLetra, EntregaI, " _
            & "EntregaII, ImpoLetra, VtoLetra, VtoLetraII, BL, Buque, Contenedor, Despacho, Tipo_cbx, Estado, FechaIngreso, FechaIngresoOrd, " _
            & "FechaCoordinacion, HoraCoordinacion, EstadoSIMI, chk_DisponiblePagar " _
            & "FROM Orden WHERE Clave = '" & WClave & "'"
        
        Dim RowOrden As DataRow = GetSingle(SQLCnslt, BaseConectar)

        If RowOrden IsNot Nothing Then
            txt_FechaEmbarque.Text = IIf(IsDBNull(RowOrden.Item("FechaEmbarque")), "  /  /    ", RowOrden.Item("FechaEmbarque"))
            txt_FechaLlegada.Text = IIf(IsDBNull(RowOrden.Item("FechaLlegada")), "  /  /    ", RowOrden.Item("FechaLlegada"))
            Cbx_PagoDespacho.SelectedIndex = IIf(IsDBNull(RowOrden.Item("PagoDespacho")), 0, RowOrden.Item("PagoDespacho"))
            txt_ImpoDespacho.Text = IIf(IsDBNull(RowOrden.Item("ImpoDespacho")), 0, RowOrden.Item("ImpoDespacho"))
            txt_VtoDespacho.Text = IIf(IsDBNull(RowOrden.Item("VtoDespacho")), "  /  /    ", RowOrden.Item("VtoDespacho"))
            cbx_PagoLetra.SelectedIndex = IIf(IsDBNull(RowOrden.Item("PagoLetra")), 0, RowOrden.Item("PagoLetra"))
            cbx_EntregaI.SelectedIndex = IIf(IsDBNull(RowOrden.Item("EntregaI")), 0, RowOrden.Item("EntregaI"))
            cbx_EntregaII.SelectedIndex = IIf(IsDBNull(RowOrden.Item("EntregaII")), 0, RowOrden.Item("EntregaII"))
            txt_ImpoLetra.Text = IIf(IsDBNull(RowOrden.Item("ImpoLetra")), 0, RowOrden.Item("ImpoLetra"))
            txt_VtoLetra.Text = IIf(IsDBNull(RowOrden.Item("VtoLetra")), "  /  /    ", RowOrden.Item("VtoLetra"))
            txt_VtoLetraII.Text = IIf(IsDBNull(RowOrden.Item("VtoLetraII")), "  /  /    ", RowOrden.Item("VtoLetraII"))

            txt_BL.Text = IIf(IsDBNull(RowOrden.Item("BL")), "", RowOrden.Item("BL"))
            txt_Buque.Text = IIf(IsDBNull(RowOrden.Item("Buque")), "", RowOrden.Item("Buque"))
            txt_Contenedor.Text = IIf(IsDBNull(RowOrden.Item("Contenedor")), "", RowOrden.Item("Contenedor"))
            txt_Despacho.Text = IIf(IsDBNull(RowOrden.Item("Despacho")), "", RowOrden.Item("Despacho"))
            'cbx_Tipo.SelectedItem = IIf(IsDBNull(RowOrden.Item("Tipo_cbx")), "", Trim(RowOrden.Item("Tipo_cbx")))
            Dim WTipo_cbx As String = OrDefault(RowOrden.Item("Tipo_cbx"), "")
            cbx_Tipo.SelectedItem = Trim(WTipo_cbx)
            'cbx_Estado.SelectedItem = IIf(IsDBNull(RowOrden.Item("Estado")), "", Trim(RowOrden.Item("Estado")))
            Dim WEstado As String = OrDefault(RowOrden.Item("Estado"), "")
            cbx_Estado.SelectedItem = Trim(WEstado)
            txt_FechaIngreso.Text = IIf(IsDBNull(RowOrden.Item("FechaIngreso")), "", RowOrden.Item("FechaIngreso"))

            Dim WEstadoSImi As String = OrDefault(RowOrden.Item("EstadoSIMI"), "")
            cbx_EstadoSIMI.SelectedItem = Trim(WEstadoSImi)

            'txtFechaCoordinacion.Text = If(IsDBNull(RowOrden.Item("FechaCoordinacion")), "", RowOrden.Item("FechaCoordinacion"))
            txtFechaCoordinacion.Text = OrDefault(RowOrden.Item("FechaCoordinacion"), "")
            WFechaCoordinacionAnterior = txtFechaCoordinacion.Text

            txt_HoraCoordinacion.Text = IIf(IsDBNull(RowOrden.Item("HoraCoordinacion")), "", RowOrden.Item("HoraCoordinacion"))
            WHoraCoordinacionAnterior = txt_HoraCoordinacion.Text

            Dim WDisponiblepagar As Boolean = OrDefault(RowOrden.Item("chk_DisponiblePagar"), False)
            Chk_DisponibleParaPagar.Checked = WDisponiblepagar

        End If

        Dim SQLCnlst As String = "Select EntregaI FROM " & BaseConectar & ".dbo.Orden WHERE Orden = '" & NumeroOrden & "'"

        Dim Row As DataRow = GetSingle(SQLCnlst)
        If Row IsNot Nothing Then
            REM BY NAN

            cbx_EntregaI.SelectedIndex = IIf(IsDBNull(Row.Item("EntregaI")), 0, Row.Item("EntregaI"))
        End If


        'PARTE OBSERVACIONES
        With Tabla_Aux.Columns
            .Add("Articulo")
            .Add("PosArancel")
        End With


        If (NumeroCarpeta <> "" And NumeroOrden <> "" And BaseConectar <> "") Then

            WBASEACONECTAR = BaseConectar
            txt_Orden.Text = NumeroOrden
            txt_Carpeta.Text = NumeroCarpeta
            Dim ZClave As String = NumeroOrden.PadLeft(6, "0") & "01"


            DGV_Orden.Rows.Clear()


            Dim Renglon As Integer = 0

            SQLCnlst = "SELECT o.Origen, o.Moneda, o.Tarjeta, o.Tipo, o.TipoPago, o.Leyenda, o.FechaImpo, " _
                                     & "o.Clave, o.PedidoImpo, o.TipoImpo, o.Flete, o.Fecha, o.Proveedor, o.Djai, " _
                                     & "o.FechaDjai, o.ARticulo, o.Cantidad, o.Precio, p.Nombre " _
                                     & "FROM Orden o INNER JOIN Proveedor p ON o.Proveedor = p.Proveedor " _
                                     & "WHERE o.Orden = '" & txt_Orden.Text & "' AND o.Carpeta = '" & txt_Carpeta.Text & "' " _
                                     & "ORDER BY o.Clave"


            Dim TablaOrden As DataTable = GetAll(SQLCnlst, BaseConectar)

            If TablaOrden.Rows.Count > 0 Then

                For Each RowOrdenOb As DataRow In TablaOrden.Rows

                    If RowOrdenOb.Item("Clave") = ZClave Then

                        With RowOrdenOb
                            WMONEDA = IIf(IsDBNull(.Item("Moneda")), "0", .Item("Moneda"))
                            cbx_Moneda.SelectedIndex = WMONEDA

                            WORIGEN = IIf(IsDBNull(.Item("Origen")), "", .Item("Origen"))
                            txt_Origen.Text = WORIGEN
                            'cbx_Tarjeta.SelectedIndex = IIf(IsNull(rstOrden!Tarjeta), "0", rstOrden!Tarjeta)
                            'cbx_TipoOrden.SelectedIndex = IIf(IsNull(rstOrden!Tipo), "0", rstOrden!Tipo)
                            WTIPOPAGO = IIf(IsDBNull(.Item("TipoPago")), "0", .Item("TipoPago"))
                            cbx_TipoPago.SelectedIndex = WTIPOPAGO

                            WLEYENDA = IIf(IsDBNull(.Item("Leyenda")), "0", .Item("Leyenda"))
                            cbx_Leyenda.SelectedIndex = WLEYENDA

                            WPEDIDOIMPO = IIf(IsDBNull(.Item("PedidoImpo")), "", .Item("PedidoImpo"))
                            txt_PedidoImpo.Text = WPEDIDOIMPO

                            WFECHAIMPO = IIf(IsDBNull(.Item("FechaImpo")), "  /  /    ", .Item("FechaImpo"))
                            txt_FechaImpo.Text = WFECHAIMPO

                            WTIPOIMPO = IIf(IsDBNull(.Item("TipoImpo")), "0", .Item("TipoImpo"))
                            cbx_TipoImpo.SelectedIndex = WTIPOIMPO

                            WFLETE = IIf(IsDBNull(.Item("Flete")), "", .Item("Flete"))
                            txt_Flete.Text = WFLETE

                            WFECHA = .Item("Fecha")
                            txt_Fecha.Text = WFECHA

                            WPROVEEDOR = .Item("Proveedor")
                            txt_Proveedor.Text = WPROVEEDOR

                            WDESPROVEEDOR = .Item("Nombre")
                            txt_DesProveedor.Text = WDESPROVEEDOR

                            WDJAI = Trim(IIf(IsDBNull(.Item("DJai")), "", .Item("DJai")))
                            txt_Djai.Text = WDJAI

                            WFECHADJAI = IIf(IsDBNull(.Item("FechaDJai")), "  /  /    ", .Item("FechaDJai"))
                            txt_FechaDjai.Text = WFECHADJAI

                        End With

                    End If

                    DGV_Orden.Rows.Add()

                    DGV_Orden.Rows(Renglon).Cells("Producto").Value = RowOrdenOb.Item("Articulo")
                    DGV_Orden.Rows(Renglon).Cells("Cantidad").Value = formatonumerico(RowOrdenOb.Item("Cantidad"))
                    DGV_Orden.Rows(Renglon).Cells("Precio").Value = formatonumerico(RowOrdenOb.Item("Precio"))



                    'XPorceDerechos(WLugar) = IIf(IsNull(rstOrden!Derechos), "0", rstOrden!Derechos)

                    ' XSolicitud(WLugar, 1) = IIf(IsNull(rstOrden!Solicitud1), "0", rstOrden!Solicitud1)
                    ' XSolicitud(WLugar, 2) = IIf(IsNull(rstOrden!Solicitud2), "0", rstOrden!Solicitud2)
                    ' XSolicitud(WLugar, 3) = IIf(IsNull(rstOrden!Solicitud3), "0", rstOrden!Solicitud3)

                    Renglon += 1

                Next

                For Each DGV_Row As DataGridViewRow In DGV_Orden.Rows
                    SQLCnlst = "SELECT Descripcion, Derechos, Posarance " _
                                & "FROM Articulo WHERE Codigo = '" & DGV_Row.Cells("Producto").Value & "'"

                    Dim RowArt As DataRow = GetSingle(SQLCnlst, Operador.Base)

                    If RowArt IsNot Nothing Then


                        DGV_Row.Cells("Descripcion").Value = RowArt("Descripcion")
                        Dim WDerechos As String = formatonumerico(IIf(IsDBNull(RowArt("Derechos")), "0", RowArt("Derechos")))
                        DGV_Row.Cells("Derechos").Value = WDerechos
                        Dim WPosArancelica As String = IIf(IsDBNull(RowArt("Posarance")), "0", RowArt("Posarance"))
                        DGV_Row.Cells("PosicionArancelaria").Value = WPosArancelica

                        Tabla_Aux.Rows.Add(DGV_Row.Cells("Producto").Value, WPosArancelica)
                    End If
                Next
            End If
        End If
    End Sub


    Private Function ValidarHora(ByVal Hora As String) As String
        Dim Respuesta As String = "S"
        Dim WHora As Integer = 0
        WHora = Val(Microsoft.VisualBasic.Left(Hora, 2))
        Dim WMin As Integer = 0
        WMin = Val(Microsoft.VisualBasic.Right(Hora, 2))

        If WHora > 23 Or WHora < 0 Then
            Respuesta = "N"
        End If

        If WMin > 59 Or WMin < 0 Then
            Respuesta = "N"
        End If

        Return Respuesta
    End Function

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        'VALIDACIONES DE FECHA EN OBSERVACIONES
        If Trim(txt_FechaLlegada.Text) <> "/  /" And txt_FechaLlegada.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaLlegada.Text) <> "S" Then
                MsgBox("Fecha de Llegada Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_FechaLlegada.Focus()
                txt_FechaLlegada.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txt_FechaEmbarque.Text) <> "/  /" And txt_FechaEmbarque.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaEmbarque.Text) <> "S" Then
                MsgBox("Fecha de Embarque Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_FechaEmbarque.Focus()
                txt_FechaEmbarque.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txt_VtoLetra.Text) <> "/  /" And txt_VtoLetra.Text <> "00/00/0000" Then
            If ValidaFecha(txt_VtoLetra.Text) <> "S" Then
                MsgBox("Fecha de Vto. de Letra Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_VtoLetra.Focus()
                txt_VtoLetra.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txt_VtoLetraII.Text) <> "/  /" And txt_VtoLetraII.Text <> "00/00/0000" Then
            If ValidaFecha(txt_VtoLetraII.Text) <> "S" Then
                MsgBox("Fecha de Vto. Real de Letra Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_VtoLetraII.Focus()
                txt_VtoLetraII.SelectAll()
                Exit Sub
            End If
        End If

        'validoFecha DJai

        If Trim(txt_FechaImpo.Text) <> "/  /" And txt_FechaImpo.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaImpo.Text) <> "S" Then
                MsgBox("Fecha de Fecha Impo Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_FechaImpo.Focus()
                txt_FechaImpo.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txt_FechaDjai.Text) <> "/  /" And txt_FechaDjai.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaDjai.Text) <> "S" Then
                MsgBox("Fecha de Fecha Djai Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_FechaDjai.Focus()
                txt_FechaDjai.SelectAll()
                Exit Sub
            End If
        End If


        If Trim(txt_FechaIngreso.Text) <> "/  /" And txt_FechaIngreso.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaIngreso.Text) <> "S" Then
                MsgBox("Fecha de Fecha ingreso Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_FechaIngreso.Focus()
                txt_FechaIngreso.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txtFechaCoordinacion.Text) <> "/  /" And txtFechaCoordinacion.Text <> "00/00/0000" Then
            If ValidaFecha(txtFechaCoordinacion.Text) <> "S" Then
                MsgBox("Fecha de Fecha de Coordinacion Invalida", 0, "Actualizacion de Ordenes de Compra")
                txtFechaCoordinacion.Focus()
                txtFechaCoordinacion.SelectAll()
                Exit Sub
            End If
        End If

        If Trim(txt_HoraCoordinacion.Text) <> ":" Then
            If ValidarHora(txt_HoraCoordinacion.Text) <> "S" Then
                MsgBox("Fecha de Hora de Coordinacion Invalida", 0, "Actualizacion de Ordenes de Compra")
                txt_HoraCoordinacion.Focus()
                txt_HoraCoordinacion.SelectAll()
                Exit Sub
            End If
        End If

        'FIN VALIDACIONES DE FECHAS

        'ACTUALIZAMOS LA PARTE DE ORDEN
        Dim ZZOrigen As String
        Dim ZZLeyenda As String
        Dim ZZPedidoImpo As String
        Dim ZZFechaImpo As String
        Dim ZZTipoImpo As String
        Dim ZZTipoPago As String
        Dim ZZFlete As String
        Dim ZZDJai As String
        Dim ZZFechaDJai As String
        Dim ZZOrdFechaImpo As String
        
        ZZOrigen = txt_Origen.Text
        ZZLeyenda = cbx_Leyenda.SelectedIndex
        ZZPedidoImpo = txt_PedidoImpo.Text
        ZZFechaImpo = txt_FechaImpo.Text
        ZZTipoImpo = cbx_TipoImpo.SelectedIndex
        ZZTipoPago = cbx_TipoPago.SelectedIndex
        ZZFlete = txt_Flete.Text
        ZZDJai = txt_Djai.Text
        ZZFechaDJai = txt_FechaDjai.Text

        ZZOrdFechaImpo = ordenaFecha(ZZFechaImpo)
        
        If MsgBox("¿Desea Guardar estos valores? ", vbYesNo) = vbYes Then

            For i = 0 To DGV_Orden.Rows.Count - 1
                If DGV_Orden.Rows(i).Cells("Producto").Value = Tabla_Aux.Rows(i).Item("Articulo") Then
                    If DGV_Orden.Rows(i).Cells("PosicionArancelaria").Value <> Tabla_Aux.Rows(i).Item("PosArancel") Then
                        Dim SqlCnslt As String = "UPDATE Articulo SET " _
                                                & " Posarance = '" & DGV_Orden.Rows(i).Cells("PosicionArancelaria").Value & "'" _
                                                & " Where Codigo = '" & DGV_Orden.Rows(i).Cells("Producto").Value & "'"
                        ExecuteNonQueries(Operador.Base, {SqlCnslt})
                    End If
                End If
            Next

            'ACTUALIZAMOS LA PARTE DE OBSERVACIONES
            Dim ListaSQLCnslt As New List(Of String)

            Dim SQLCnsl As String = "DELETE ObservaOrden WHERE Carpeta = '" & WCARPETA & "'"

            ListaSQLCnslt.Add(SQLCnsl)
            Dim Renglon As Integer = 0

            For Each DGV_Row As DataGridViewRow In DGV_Observaciones.Rows
                If Trim(DGV_Row.Cells("Fecha").Value) <> "" Or Trim(DGV_Row.Cells("Observaciones").Value) <> "" Then

                    Renglon += 1

                    Dim CarpetaAux As String = WCARPETA.PadLeft(6, "0")

                    Dim RenglonAux As String = Renglon.ToString().PadLeft(2, "0")

                    Dim WClave As String = CarpetaAux & RenglonAux

                    SQLCnsl = "INSERT INTO ObservaOrden ( " _
                        & "Clave, " _
                        & "Carpeta, " _
                        & "Renglon, " _
                        & "Orden, " _
                        & "Texto1, " _
                        & "Texto2) " _
                        & "VALUES (" _
                        & "'" & WClave & "', " _
                        & "'" & CarpetaAux & "', " _
                        & "'" & RenglonAux & "', " _
                        & "'" & WORDEN & "', " _
                        & "'" & Trim(DGV_Row.Cells("Fecha").Value) & "', " _
                        & "'" & Trim(DGV_Row.Cells("Observaciones").Value) & "')"


                    ListaSQLCnslt.Add(SQLCnsl)

                End If
            Next

            Dim WTipoPago As String = ""
            Dim WFecha As String = ""

            Dim OrdenAuxi As String = WORDEN.PadLeft(6, "0")

            Dim WClaveORDEN As String = OrdenAuxi + "01"

            SQLCnsl = "SELECT TipoPago, Fecha FROM " & WBASEACONECTAR & ".dbo.Orden WHERE Clave = '" & WClaveORDEN & "'"

            Dim RowOrden As DataRow = GetSingle(SQLCnsl)

            If RowOrden IsNot Nothing Then
                WTipoPago = IIf(IsDBNull(RowOrden.Item("TipoPago")), 0, RowOrden.Item("TipoPago"))
                WFecha = RowOrden.Item("Fecha")
            End If

            If WTipoPago = 1 Then
                txt_VtoLetra.Text = WFecha
            End If
            If WTipoPago = 2 Then
                txt_VtoLetra.Text = txt_FechaLlegada.Text
            End If
            txt_VtoDespacho.Text = txt_FechaLlegada.Text

            Dim WOrdVtoDespacho As String = ordenaFecha(txt_VtoDespacho.Text)
            Dim WOrdVtoLetra As String = ordenaFecha(txt_VtoLetra.Text)
            Dim WOrdVtoLetraII As String = ordenaFecha(txt_VtoLetraII.Text)
            Dim WOrdfechaingreso As String = ordenaFecha(txt_FechaIngreso.Text)
            Dim WMarca As String = "X"

            SQLCnsl = "UPDATE " & WBASEACONECTAR & ".dbo.Orden SET " _
                & " DJai = '" & ZZDJai & "'," _
                & " FechaDJai = '" & ZZFechaDJai & "'," _
                & " Flete = '" & ZZFlete & "'," _
                & " Origen = '" & ZZOrigen & "'," _
                & " Leyenda = '" & ZZLeyenda & "'," _
                & " PedidoImpo = '" & ZZPedidoImpo & "'," _
                & " FechaImpo = '" & ZZFechaImpo & "'," _
                & " OrdFechaImpo = '" & ZZOrdFechaImpo & "'," _
                & " TipoImpo = '" & ZZTipoImpo & "'," _
                & " TipoPago = '" & ZZTipoPago & "', " _
                        & "Fecha1 = '" & txt_FechaLlegada.Text & "', " _
                        & "Fecha2 = '" & txt_FechaLlegada.Text & "', " _
                        & "FechaEmbarque = '" & txt_FechaEmbarque.Text & "', " _
                        & "FechaLlegada = '" & txt_FechaLlegada.Text & "', " _
                        & "PagoDespacho = '" & Str$(Cbx_PagoDespacho.SelectedIndex) & "', " _
                        & "ImpoDespacho = '" & txt_ImpoDespacho.Text & "', " _
                        & "VtoDespacho =  '" & txt_VtoDespacho.Text & "', " _
                        & "OrdVtoDespacho = '" & WOrdVtoDespacho & "', " _
                        & "PagoLetra = '" & Str$(cbx_PagoLetra.SelectedIndex) & "', " _
                        & "EntregaI = '" & Str$(cbx_EntregaI.SelectedIndex) & "', " _
                        & "EntregaII = '" & Str$(cbx_EntregaII.SelectedIndex) & "', " _
                        & "ImpoLetra = '" & txt_ImpoLetra.Text & "', " _
                        & "VtoLetra = '" & txt_VtoLetra.Text & "', " _
                        & "VtoLetraII = '" & txt_VtoLetraII.Text & "', " _
                        & "OrdVtoLetra = '" & WOrdVtoLetra & "', " _
                        & "OrdVtoLetraII ='" & WOrdVtoLetraII & "', " _
                        & "BL = '" & Trim(txt_BL.Text) & "', " _
                        & "Despacho = '" & Trim(txt_Despacho.Text) & "', " _
                        & "Contenedor = '" & Trim(txt_Contenedor.Text) & "', " _
                        & "Buque = '" & Trim(txt_Buque.Text) & "', " _
                        & "Estado = '" & cbx_Estado.SelectedItem & "', " _
                        & "Tipo_cbx = '" & cbx_Tipo.SelectedItem & "', " _
                        & "FechaIngreso = '" & txt_FechaIngreso.Text & "', " _
                        & "FechaIngresoOrd = '" & WOrdfechaingreso & "' ," _
                        & "FechaCoordinacion = '" & txtFechaCoordinacion.Text & "', " _
                        & "FechaCoordinacionOrd = '" & ordenaFecha(txtFechaCoordinacion.Text) & "', " _
                        & "HoraCoordinacion = '" & txt_HoraCoordinacion.Text & "', " _
                        & "EstadoSIMI = '" & cbx_EstadoSIMI.SelectedItem & "', " _
                        & "chk_DisponiblePagar = '" & Chk_DisponibleParaPagar.Checked & "' " _
            & "Where Orden = '" & WORDEN & "'"

            ListaSQLCnslt.Add(SQLCnsl)

            ExecuteNonQueries(Operador.Base, ListaSQLCnslt.ToArray())


            'EN CASO DE QUE SE CARGARA UNA HORA Y UNA FECHA DE COORDINACION DIFERENTE A LA ANTERIOR
            'CONSULTAMOS SI DESEA ENVIAR UN MAIL DE AVISO
            If txtFechaCoordinacion.Text <> WFechaCoordinacionAnterior Or txt_HoraCoordinacion.Text <> WHoraCoordinacionAnterior Then
                If MsgBox("Se modifico la fecha u hora de coordinacion¿Desea enviar un aviso?", vbYesNo) = vbYes Then
                    EnviarAvisoDeCoordinacion()
                End If
            End If

            Close()

        End If
        
    End Sub
    
    Private Sub EnviarAvisoDeCoordinacion()

       
        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        
        Try

            Dim SQLCnslt As String = "SELECT "


            oApp = New Outlook.Application()

            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = "Aviso de Fecha y Hora de Coordinacion para la Orden Nº: " & WORDEN
            oMsg.HTMLBody = vbCrLf & "Datos de Coordinacion: <br/>" _
                & "Carpeta: " & "<strong>" & WCARPETA & "</strong><br/>" _
                & "Orden: " & "<strong>" & WORDEN & "</strong><br/>" _
                & "Proveedor: " & "<strong>" & WPROVEEDOR & " - " & UCase(txt_DesProveedor.Text) & "</strong><br/>" _
                & "Tipo: " & "<strong>" & cbx_Tipo.SelectedItem & "</strong><br/>" _
                & "Contenedor: " & "<strong>" & txt_Contenedor.Text & "</strong><br/>" _
                & "Planta: " & "<strong>" & DevolverPlantaEnString() & "</strong><br/>" _
                & "Despacho Nº: " & "<strong>" & txt_Despacho.Text & "</strong><br/>" _
                & "Fecha y Hora Coordinacion: " & "<strong>" & txtFechaCoordinacion.Text & "  " & txt_HoraCoordinacion.Text & "</strong>"



            Dim ArchivoProforma As New List(Of String)

            If Directory.Exists("\\193.168.0.2\w\Impresion Pdf\Orden\" & WORDEN & "\COAS") Then
                For Each Archivo As String In Directory.GetFiles("\\193.168.0.2\w\Impresion Pdf\Orden\" & WORDEN & "\COAS")
                    ArchivoProforma.Add(Archivo)
                Next
            End If

            If Directory.Exists("\\193.168.0.2\w\Impresion Pdf\Orden\" & WORDEN & "\Packing List") Then
                For Each Archivo As String In Directory.GetFiles("\\193.168.0.2\w\Impresion Pdf\Orden\" & WORDEN & "\Packing List")
                    ArchivoProforma.Add(Archivo)
                Next
            End If

            If ArchivoProforma.Count > 0 Then
                For Each Archivo As String In ArchivoProforma
                    oMsg.Attachments.Add(Archivo)
                Next
            End If
            
            If DevolverPlantaEnString() = "I" Then
                ' Modificar por los E-Mails que correspondan.

                oMsg.To = ConfigurationManager.AppSettings("AVISO_MAILS_PLANTA_I") '"gferreyra@surfactan.com.ar"

            Else
                ' Modificar por los E-Mails que correspondan.
                oMsg.To = ConfigurationManager.AppSettings("AVISO_MAILS_OTRAS_PLANTA") '"gferreyra@surfactan.com.ar"

            End If


            'oMsg.Display()

            oMsg.Send()
            
            
            If DevolverPlantaEnString() = "I" Then
                'MODIFICAR MSG SEGUN CORRESPONDA
                MsgBox("Aviso Enviado correctamente a Hernan Copiello, German Rodriguez y Beatriz Iglecias", MsgBoxStyle.Information)
            Else
                'MODIFICAR MSG SEGUN CORRESPONDA
                MsgBox("Aviso Enviado correctamente a Hernan Copiello y Beatriz Iglecias", MsgBoxStyle.Information)
            End If




        Catch ex As Exception
           
            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        End Try

    End Sub

    Private Function DevolverPlantaEnString() As String
        Dim WPta As String = ""
        Select Case UCase(WBASEACONECTAR)
            Case "SURFACTANSA"
                WPta = "I"
            Case "SURFACTAN_II"
                WPta = "II"
            Case "SURFACTAN_III"
                WPta = "III"
            Case "SURFACTAN_V"
                WPta = "V"
            Case "SURFACTAN_VI"
                WPta = "VI"
            Case "SURFACTAN_VII"
                WPta = "VII"
        End Select
        
        Return WPta

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Los datos que no fueron grabados se perderan." & vbCrLf & " ¿Desea cerrar la ventana?", vbYesNo, "Aviso") = vbYes Then
            Close()
        End If
    End Sub

    Private Sub btn_EnviarDocumentacion_Click(sender As Object, e As EventArgs) Handles btn_EnviarDocumentacion.Click

        With New EnviarDocumentacion(txt_Orden.Text, txt_Proveedor.Text, txt_DesProveedor.Text, WBASEACONECTAR)
            .Show(Me)
        End With
    End Sub

   
    Private Sub btn_AdjuntarArchivos_Click(sender As Object, e As EventArgs) Handles btn_AdjuntarArchivos.Click
        Dim WPath As String = "\\193.168.0.2\w\Impresion Pdf\Orden\" & Trim(txt_Orden.Text)
        Dim Wmail As String = ""
        Dim WTitulo As String = ""
        Dim WCuerpoMail As String = ""


        With New EditorArchivos(3, WPath, Operador.Clave, 1, Wmail, WTitulo, WCuerpoMail)
            .Show()
        End With

    End Sub
End Class