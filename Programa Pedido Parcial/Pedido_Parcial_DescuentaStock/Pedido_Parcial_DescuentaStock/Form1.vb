Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Form1 : Implements IPasaCodigo

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cant_Restar.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Pedido.KeyPress, txt_Partida.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    
    Private Sub txt_Pedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Pedido.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Pedido.Text <> "" And txt_Pedido.Text.Length = 6 Then
                    ObtenerDatosPedido(Trim(txt_Pedido.Text))
                Else
                    LimpiarForm()
                    MsgBox("El Pedido no existe o no tiene endientes", vbExclamation)
                End If
            Case Keys.Escape
                txt_Pedido.Text = ""
        End Select
    End Sub

    Private Sub ObtenerDatosPedido(ByVal NroPedido As String)
        Dim SQLCnslt As String = "SELECT Cliente, TipoPedido FROM Pedido WHERE Pedido = '" & NroPedido & "'"
        Dim RowPedido As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowPedido IsNot Nothing Then
            txt_Cliente.Text = RowPedido.Item("Cliente")
            BuscarDescrip_Cliente()
            txt_Planta.Text = AnalizarPlanta_SegunTipoPedido(RowPedido.Item("TipoPedido"))
            Dim BaseConsultar As String = ObtenerBase()
            SQLCnslt = "SELECT DISTINCT Articulo FROM Estadistica WHERE Pedido = '" & NroPedido & "'" _
                                     & " AND Marca = 'X' AND Lote1 = '999999'"
            Dim tableEstadistica As DataTable = GetAll(SQLCnslt, BaseConsultar)
            If tableEstadistica.Rows.Count > 0 Then
                If tableEstadistica.Rows.Count > 1 Then
                    With New ListaProductos_XPedido(NroPedido, BaseConsultar)
                        .Show(Me)
                    End With
                Else
                    txt_Producto.Text = tableEstadistica.Rows(0).Item("Articulo")
                    txt_Producto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txt_Cant_Restar.Focus()
                End If
            Else
                LimpiarForm()
                MsgBox("No se encontraron productos a despachar en ese pedido", vbExclamation)
            End If
        Else
            LimpiarForm()
            MsgBox("No existe el pedido", vbExclamation)

        End If
    End Sub

    Private Sub BuscarDescrip_Cliente()
        Dim SQLCnslt As String = "SELECT Razon FROM Cliente WHERE cliente = '" & Trim(txt_Cliente.Text) & "'"
        Dim RowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowCliente IsNot Nothing Then
            txt_Desc_Cliente.Text = RowCliente.Item("Razon")
        End If
    End Sub
    Private Function AnalizarPlanta_SegunTipoPedido(ByVal TipoPedido As Integer) As String
        Dim Planta As String = ""

        Select Case TipoPedido
            Case 1, 5 '1= Colorante 5=Pigmento
                Planta = "Planta 1"
            Case 4 '4=FARMA
                Planta = "Planta 3"
            Case 2, 3 '2= PT    3=Biocida
                Planta = "Planta 5"
        End Select

        Return Planta

    End Function


    Private Sub txt_Producto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Producto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Producto.Text.Length = 12 Then
                    ObtenerDatosEstadistica(Trim(txt_Producto.Text), Trim(txt_Pedido.Text))
                End If
            Case Keys.Escape
                txt_Producto.Text = ""
        End Select
    End Sub

    Private Function ObtenerBase() As String
        Dim Base As String = ""
        Select Case txt_Planta.Text
            Case "Planta 1"
                Base = "SurfactanSa"
            Case "Planta 3"
                Base = "Surfactan_III"
            Case "Planta 5"
                Base = "Surfactan_V"
        End Select
        Return Base
    End Function
    Private Sub ObtenerDatosEstadistica(ByVal Producto As String, ByVal Pedido As String)
        Dim BaseConsultar As String = ObtenerBase()
        Dim SQLCnslt As String = "SELECT * FROM Estadistica WHERE Articulo = '" & Producto & "' " _
                                 & "AND Pedido = '" & Pedido & "' AND Marca = 'X' AND Lote1 = '999999'"
        Dim RowEstadistica As DataRow = GetSingle(SQLCnslt, BaseConsultar)
        If RowEstadistica IsNot Nothing Then

            With RowEstadistica
                txt_Cantidad_Pendiente.Text = formatonumerico(.Item("Canti1"))
            End With

            txt_Cant_Restar.Focus()
        End If
    End Sub


    Private Sub txt_Cant_Restar_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cant_Restar.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Cant_Restar.Text = formatonumerico(txt_Cant_Restar.Text)
                If Val(txt_Cant_Restar.Text) > Val(txt_Cantidad_Pendiente.Text) Then
                    MsgBox("No puede ser mayor a la cantidad pendiente", vbExclamation)
                    Exit Sub
                End If
                txt_Partida.Focus()
            Case Keys.Escape
                txt_Cant_Restar.Text = ""
        End Select
    End Sub

    Private Sub txt_Partida_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Partida.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
               
            Case Keys.Escape
                txt_Partida.Text = ""
        End Select
    End Sub

    Private Function ValidarLote_Stock() As Boolean
        Dim WEntra As String = "N"
        Dim WCantidad As Double = 0
        Dim BaseConsultar As String = ObtenerBase()
        Dim SQLCnslt As String

        If txt_Producto.Text.StartsWith("DY") Then
            'SI ES UN DY
            Dim WCodigo As String = Microsoft.VisualBasic.Left(txt_Producto.Text, 3) & Microsoft.VisualBasic.Right(txt_Producto.Text, 7)

            SQLCnslt = "SELECT Saldo FROM Laudo WHERE Articulo = '" & WCodigo & "' " _
                       & "AND Laudo = '" & txt_Partida.Text & "' AND Renglon = 1 AND Marca <> 'X'"
            Dim RowHoja As DataRow = GetSingle(SQLCnslt, BaseConsultar)
            If RowHoja IsNot Nothing Then
                WCantidad = IIf(IsDBNull(RowHoja.Item("Saldo")), 0, RowHoja.Item("Saldo"))
                WEntra = "S"
            End If

            If WEntra = "N" Then
                SQLCnslt = "SELECT Saldo FROM Guia WHERE Articulo = '" & WCodigo & "' " _
                         & "AND Lote = '" & txt_Partida.Text & "' AND Marca <> 'X' " _
                         & "ORDER BY Saldo DESC, FechaOrd"
                Dim RowGuia As DataRow = GetSingle(SQLCnslt, BaseConsultar)
                If RowGuia IsNot Nothing Then
                    WCantidad = IIf(IsDBNull(RowHoja.Item("Saldo")), 0, RowHoja.Item("Saldo"))
                End If
            End If

            If Val(WCantidad) < Val(txt_Cant_Restar.Text) Then
                MsgBox("El saldo es insufiente para generar este despacho", vbExclamation)
                Return False
            End If
        Else 'SI ES UN PT
            SQLCnslt = "SELECT Saldo FROM Hoja WHERE Producto = '" & txt_Producto.Text & "' " _
                     & "AND Hoja = '" & txt_Partida.Text & "' AND Renglon = 1 AND Marca <> 'X'"
            Dim RowHoja As DataRow = GetSingle(SQLCnslt, BaseConsultar)
            If RowHoja IsNot Nothing Then
                WCantidad = IIf(IsDBNull(RowHoja.Item("Saldo")), 0, RowHoja.Item("Saldo"))
                WEntra = "S"
            End If

            If WEntra = "N" Then
                SQLCnslt = "SELECT Saldo FROM Guia WHERE Terminado = '" & txt_Producto.Text & "' " _
                         & "AND Lote = '" & txt_Partida.Text & "' AND Marca <> 'X' " _
                         & "ORDER BY saldo DESC, FechaOrd"
                Dim RowGuia As DataRow = GetSingle(SQLCnslt, BaseConsultar)
                If RowGuia IsNot Nothing Then
                    WCantidad = IIf(IsDBNull(RowHoja.Item("Saldo")), 0, RowHoja.Item("Saldo"))
                End If
            End If

            If Val(WCantidad) < Val(txt_Cant_Restar.Text) Then
                MsgBox("El saldo es insufiente para generar este despacho", vbExclamation)
                Return False
            End If
        End If
        'SI LLEGO HASTA ACA ES QUE HAY STOCK Y EL LOTE ES VALIDO
        Return True

    End Function

    Public Sub PasaCodigo(Codigo As String) Implements IPasaCodigo.PasaCodigo
        txt_Producto.Text = Codigo
        txt_Producto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub


    Private Sub DescontarStock()

        GenerarRegistroEstadistica()

        If txt_Producto.Text.StartsWith("DY") Then
            ActualzarSaldosDY()
        Else
            ActualzarSaldosTerminado()
        End If



    End Sub

    Private Sub ActualzarSaldosDY()
        Dim BaseConsultar As String = ObtenerBase()
        Dim WControla As Integer = 0
        Dim WSalidas As Double
        Dim WCodigo As String = Microsoft.VisualBasic.Left(txt_Producto.Text, 3) & Microsoft.VisualBasic.Right(txt_Producto.Text, 7)
        Dim WDate As String = Date.Today.ToString("MM-dd-yyyy")

        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "SELECT Controla, Salidas  FROM Articulo WHERE Codigo = '" & WCodigo & "'"
        Dim RowTerminado As DataRow = GetSingle(SQLCnslt, BaseConsultar)
        If RowTerminado IsNot Nothing Then

            WControla = IIf(IsDBNull(RowTerminado.Item("Controla")), 0, RowTerminado.Item("Controla"))

            WSalidas = RowTerminado.Item("Salidas") + Val(txt_Cant_Restar.Text)

        End If

        SQLCnslt = "UPDATE Articulo SET Salidas = '" & formatonumerico(WSalidas) & "', WDate = '" & WDate & "' " _
                    & "WHERE Codigo = '" & WCodigo & "'"

        ListaSQLCnslt.Add(SQLCnslt)



        If WControla = 0 And Val(txt_Partida.Text) <> 0 Then

            Dim WSaldo As Double

            SQLCnslt = "SELECT Clave, Saldo FROM Laudo " _
                     & "WHERE Articulo = '" & WCodigo & "' " _
                     & "AND Laudo = '" & txt_Partida.Text & "' AND Renglon = 1 "
            Dim RowLaudo As DataRow = GetSingle(SQLCnslt, BaseConsultar)

            If RowLaudo IsNot Nothing Then 'CHEQUEO QUE EXISTA LA HOJA

                WSaldo = Str$(RowLaudo.Item("Saldo") - Val(txt_Cant_Restar.Text))

                Dim WClave As String = txt_Partida.Text & "01" ' La CLAVE es Laudo & Renglon

                SQLCnslt = "UPDATE Laudo SET Saldo = '" & formatonumerico(WSaldo) & "', WDate = '" & WDate & "' WHERE Clave = '" & WClave & "'"

                ListaSQLCnslt.Add(SQLCnslt)

            Else ' SINO BUSCO LA GUIA

                SQLCnslt = "SELECT Clave, Saldo FROM Guia " _
                         & "WHERE Articulo = '" & WCodigo & "' " _
                         & "AND Lote = '" & txt_Partida.Text & "' " _
                         & "ORDER BY saldo DESC, FechaOrd"

                Dim RowTermi As DataRow = GetSingle(SQLCnslt, BaseConsultar)
                If RowTermi IsNot Nothing Then

                    WSaldo = Str$(RowTermi.Item("Saldo") - Val(txt_Cant_Restar.Text))

                End If

                Dim WClave As String = txt_Partida.Text & "01" ' La CLAVE es Laudo & Renglon

                SQLCnslt = "UPDATE Guia SET Saldo = '" & WSaldo & "', WDate = '" & WDate & "' WHERE Clave = '" & WClave & "'"

                ListaSQLCnslt.Add(SQLCnslt)
            End If

        End If
        
        Try
            ExecuteNonQueries(BaseConsultar, ListaSQLCnslt.ToArray())
        Catch ex As Exception
            MsgBox("No se pudieron Actualizar los Saldos", vbExclamation)
        End Try

    End Sub

    Private Sub ActualzarSaldosTerminado()
        Dim BaseConsultar As String = ObtenerBase()
        Dim WControla As Integer = 0
        Dim WSalidas As Double
        Dim WCodigo As String = txt_Producto.Text
        Dim WDate As String = Date.Today.ToString("MM-dd-yyyy")

        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "SELECT Controla, Salidas  FROM Terminado WHERE Codigo = '" & WCodigo & "'"
        Dim RowTerminado As DataRow = GetSingle(SQLCnslt, BaseConsultar)
        If RowTerminado IsNot Nothing Then

            WControla = IIf(IsDBNull(RowTerminado.Item("Controla")), 0, RowTerminado.Item("Controla"))

            WSalidas = RowTerminado.Item("Salidas") + Val(txt_Cant_Restar.Text)

        End If

        SQLCnslt = "UPDATE Terminado SET Salidas = '" & formatonumerico(WSalidas) & "', WDate = '" & WDate & "' " _
                    & "WHERE Codigo = '" & WCodigo & "'"

        ListaSQLCnslt.Add(SQLCnslt)



        If WControla = 0 And Val(txt_Partida.Text) <> 0 Then

            Dim WSaldo As Double

            SQLCnslt = "SELECT Clave, Saldo FROM Hoja " _
                     & "WHERE Producto = '" & txt_Producto.Text & "' " _
                     & "AND Hoja = '" & txt_Partida.Text & "' AND Renglon = 1 "
            Dim RowHoja As DataRow = GetSingle(SQLCnslt, BaseConsultar)

            If RowHoja IsNot Nothing Then 'CHEQUEO QUE EXISTA LA HOJA

                WSaldo = Str$(RowHoja.Item("Saldo") - Val(txt_Cant_Restar.Text))

                Dim WClave As String = txt_Partida.Text & "01" ' LA CLAVE ES LOTE & Renglon

                SQLCnslt = "UPDATE Hoja SET Saldo = '" & formatonumerico(WSaldo) & "', WDate = '" & WDate & "' WHERE Clave = '" & WClave & "'"

                ListaSQLCnslt.Add(SQLCnslt)

            Else ' SINO BUSCO LA GUIA

                SQLCnslt = "SELECT Clave, Saldo FROM Guia " _
                         & "WHERE Terminado = '" & txt_Producto.Text & "' " _
                         & "AND Lote = '" & txt_Partida.Text & "' " _
                         & "ORDER BY saldo DESC, FechaOrd"

                Dim RowTermi As DataRow = GetSingle(SQLCnslt, BaseConsultar)
                If RowTermi IsNot Nothing Then

                    WSaldo = Str$(RowTermi.Item("Saldo") - Val(txt_Cant_Restar.Text))

                End If

                Dim WClave As String = txt_Partida.Text & "01" ' LA CLAVE ES LOTE & Renglon

                SQLCnslt = "UPDATE Guia SET Saldo = '" & WSaldo & "', WDate = '" & WDate & "' WHERE Clave = '" & WClave & "'"

                ListaSQLCnslt.Add(SQLCnslt)
            End If

        End If

        Try
            ExecuteNonQueries(BaseConsultar, ListaSQLCnslt.ToArray())
        Catch ex As Exception
            MsgBox("No se pudieron Actualizar los Saldos", vbExclamation)
        End Try

    End Sub
    Private Sub GenerarRegistroEstadistica()
        Dim WClave, WArticulo, WCliente, WWArticulo, WFecha, WOrdFecha, WRemito, WWDate, WMarca, WTipopro, WMarcaant, WTipoProDy, WArticuloDy, WFechaEntrada, WFechaPedido, WObservaDevol, WLoteAdicional, WEnvAdicional, WClaveCtaCte, WImpreTerminado, WImpreTipo, WImpreNumeros, WTitulo, WDescriTerminado, WDescriTerminadoII, WMarcaMono As String
        Dim WCantidad, WPrecio, WPrecioUs, WImporte, WImporteUs, WParidad, WCosto1, WCosto2, WCoeficiente, WImporte1, WImporte2, WImporte3, WImporte4, Wwcantidad, Wwimporte, Wwimporteus, WCanti1, WCanti2, WCanti3, WCanti4, WCanti5, WEntrada, WImpreBruto As Double
        Dim WTipo, WNumero, WRenglon, WVendedor, WRubro, WLinea, WPedido, WLote1, WLote2, WLote3, WLote4, WLote5, WHoja, WEmpresa, WEnv1, WCantiEnv1, WEnv2, WCantiEnv2, WEnv3, WCantiEnv3, WEnv4, WCantiEnv4, WEnv5, WCantiEnv5, WNroEntrada, WNroPedido, WLoteOriginal, WImpreCantidad As Integer

        Dim BaseConsultar As String = ObtenerBase()
        Dim SQLCnslt As String = "SELECT * FROM Estadistica WHERE Articulo = '" & txt_Producto.Text & "' " _
                                 & "AND Pedido = '" & txt_Pedido.Text & "' AND Marca = 'X' AND Lote1 = '999999'"
        Dim rowEstadistica As DataRow = GetSingle(SQLCnslt, BaseConsultar)
        
        If rowEstadistica IsNot Nothing Then
            With rowEstadistica
                WClave = .Item("Clave")
                WTipo = .Item("Tipo")
                WNumero = .Item("Numero")
                WRenglon = .Item("Renglon")
                Warticulo = .Item("Articulo")
                WCantidad = .Item("Cantidad")
                WPrecio = .Item("Precio")
                WPrecioUs = .Item("PrecioUs")
                WImporte = .Item("Importe")
                WImporteUs = .Item("ImporteUs")
                WCliente = .Item("Cliente")
                WParidad = .Item("Paridad")
                WVendedor = .Item("Vendedor")
                WRubro = .Item("Rubro")
                WLinea = .Item("Linea")
                WCosto1 = .Item("Costo1")
                WCosto2 = .Item("Costo2")
                WCoeficiente = .Item("Coeficiente")
                WPedido = .Item("Pedido")
                WFecha = .Item("Fecha")
                WImporte1 = .Item("Importe1")
                WImporte2 = .Item("Importe2")
                WImporte3 = .Item("Importe3")
                WImporte4 = .Item("Importe4")
                WOrdFecha = .Item("OrdFecha")
                WWArticulo = .Item("WArticulo")
                WRemito = .Item("Remito")
                WWDate = .Item("WDate")
                Wwcantidad = .Item("wcantidad")
                Wwimporte = .Item("wimporte")
                Wwimporteus = .Item("wimporteus")
                WMarca = .Item("Marca")
                WLote1 = .Item("Lote1")
                wCanti1 = .Item("Canti1")
                WLote2 = .Item("Lote2")
                WCanti2 = .Item("Canti2")
                WLote3 = .Item("Lote3")
                wCanti3 = .Item("Canti3")
                WLote4 = .Item("Lote4")
                wCanti4 = .Item("Canti4")
                WLote5 = .Item("Lote5")
                WCanti5 = .Item("Canti5")
                WEntrada = IIf(IsDBNull(.Item("Entrada")), 0, .Item("Entrada"))
                WTipopro = IIf(IsDBNull(.Item("Tipopro")), "", .Item("Tipopro"))
                WHoja = IIf(IsDBNull(.Item("Hoja")), 0, .Item("Hoja"))
                WEmpresa = IIf(IsDBNull(.Item("Empresa")), 0, .Item("Empresa"))
                WMarcaant = IIf(IsDBNull(.Item("Marcaant")), "", .Item("Marcaant"))
                WTipoProDy = .Item("TipoProDy")
                WArticuloDy = .Item("ArticuloDy")
                WEnv1 = .Item("Env1")
                wCantiEnv1 = .Item("CantiEnv1")
                WEnv2 = .Item("Env2")
                wCantiEnv2 = .Item("CantiEnv2")
                WEnv3 = .Item("Env3")
                wCantiEnv3 = .Item("CantiEnv3")
                WEnv4 = .Item("Env4")
                wCantiEnv4 = .Item("CantiEnv4")
                WEnv5 = .Item("Env5")
                wCantiEnv5 = .Item("CantiEnv5")
                WNroEntrada = IIf(IsDBNull(.Item("NroEntrada")), 0, .Item("NroEntrada"))
                WFechaEntrada = IIf(IsDBNull(.Item("FechaEntrada")), "", .Item("FechaEntrada"))
                WNroPedido = IIf(IsDBNull(.Item("NroPedido")), 0, .Item("NroPedido"))
                WFechaPedido = IIf(IsDBNull(.Item("FechaPedido")), "", .Item("FechaPedido"))
                WLoteOriginal = IIf(IsDBNull(.Item("LoteOriginal")), 0, .Item("LoteOriginal"))
                WObservaDevol = IIf(IsDBNull(.Item("ObservaDevol")), "", .Item("ObservaDevol"))
                WLoteAdicional = .Item("LoteAdicional")
                WEnvAdicional = .Item("EnvAdicional")
                WClaveCtaCte = IIf(IsDBNull(.Item("ClaveCtaCte")), "", .Item("ClaveCtaCte"))
                WImpreTerminado = IIf(IsDBNull(.Item("ImpreTerminado")), "", .Item("ImpreTerminado"))
                WImpreCantidad = IIf(IsDBNull(.Item("ImpreCantidad")), 0, .Item("ImpreCantidad"))
                WImpreTipo = IIf(IsDBNull(.Item("ImpreTipo")), "", .Item("ImpreTipo"))
                WImpreNumeros = IIf(IsDBNull(.Item("ImpreNumeros")), "", .Item("ImpreNumeros"))
                WImpreBruto = IIf(IsDBNull(.Item("ImpreBruto")), 0, .Item("ImpreBruto"))
                WTitulo = .Item("Titulo")
                WDescriTerminado = IIf(IsDBNull(.Item("DescriTerminado")), "", .Item("DescriTerminado"))
                WDescriTerminadoII = .Item("DescriTerminadoII")
                WMarcaMono = IIf(IsDBNull(.Item("MarcaMono")), "", .Item("MarcaMono"))

                Dim NuevoRenglon As Integer = 0
                SQLCnslt = "SELECT MaxRenglon = MAX(Renglon) FROM Estadistica WHERE Articulo = '" & txt_Producto.Text & "' " _
                                 & "AND Pedido = '" & txt_Pedido.Text & "'"
                Dim rowRenglon As DataRow = GetSingle(SQLCnslt, BaseConsultar)
                If rowRenglon IsNot Nothing Then
                    NuevoRenglon = rowRenglon.Item("MaxRenglon") + 1
                End If


                Dim ListaSQLCnslt As New List(Of String)

                If NuevoRenglon > 0 Then
                    Dim CantidadActualizar As Double = WCantidad - Val(txt_Cant_Restar.Text)
                    Dim NuevoImporte, NuevoImporteUs As Double
                    NuevoImporte = CantidadActualizar * WPrecio
                    NuevoImporteUs = CantidadActualizar * WPrecioUs

                    SQLCnslt = "UPDATE Estadistica SET Cantidad = '" & formatonumerico(CantidadActualizar) & "', Canti1 = '" & formatonumerico(CantidadActualizar) & "', Importe = '" & formatonumerico(NuevoImporte) & "', ImporteUs = '" & formatonumerico(NuevoImporteUs) & "' WHERE Articulo = '" & txt_Producto.Text & "' " _
                                 & "AND Pedido = '" & txt_Pedido.Text & "' AND Marca = 'X' AND Lote1 = '999999'"

                    ListaSQLCnslt.Add(SQLCnslt)

                    WClave = WTipo.ToString().PadLeft(2, "0") & WNumero.ToString().PadLeft(8, "0") & NuevoRenglon.ToString().PadLeft(2, "0")
                    WCantidad = Val(txt_Cant_Restar.Text)
                    WImporte = WCantidad * WPrecio
                    WImporteUs = WCantidad * WPrecioUs
                    WLote1 = txt_Partida.Text
                    WCanti1 = Val(txt_Cant_Restar.Text)
                    WMarca = ""


                    SQLCnslt = "INSERT INTO Estadistica (Clave, Tipo, Numero, Renglon, Articulo, Cantidad, Precio, PrecioUs, " _
                            & "Importe, ImporteUs, Cliente, Paridad, Vendedor, Rubro, Linea, Costo1, Costo2, Coeficiente, " _
                            & "Pedido, Fecha, Importe1, Importe2, Importe3, Importe4, OrdFecha, WArticulo, Remito, WDate, " _
                            & "WCantidad, WImporte, WImporteUs, Marca, Lote1, Canti1, Lote2, Canti2, Lote3, Canti3, Lote4, " _
                            & "Canti4, Lote5, Canti5, Entrada, Tipopro, Hoja, Empresa, Marcaant, TipoProDy, ArticuloDy, " _
                            & "Env1, CantiEnv1, Env2, CantiEnv2, Env3, CantiEnv3, Env4, CantiEnv4, Env5, CantiEnv5, " _
                            & "NroEntrada, FechaEntrada, NroPedido, FechaPedido, LoteOriginal, ObservaDevol, LoteAdicional, " _
                            & "EnvAdicional, ClaveCtaCte, ImpreTerminado, ImpreCantidad, ImpreTipo, ImpreNumeros, " _
                            & "ImpreBruto, Titulo, DescriTerminado, DescriTerminadoII, MarcaMono) " _
                            & "Values( " _
                            & "'" & WClave & "', '" & WTipo & "', '" & WNumero & "', '" & WRenglon & "', '" & WArticulo & "', '" & formatonumerico(WCantidad) & "', '" & formatonumerico(WPrecio) & "', '" & formatonumerico(WPrecioUs) & "', " _
                            & "'" & formatonumerico(WImporte) & "', '" & formatonumerico(WImporteUs) & "', '" & WCliente & "', '" & formatonumerico(WParidad) & "', '" & WVendedor & "', '" & WRubro & "', '" & WLinea & "', '" & WCosto1 & "', '" & WCosto2 & "', '" & WCoeficiente & "', " _
                            & "'" & WPedido & "', '" & WFecha & "', '" & WImporte1 & "', '" & WImporte2 & "', '" & WImporte3 & "', '" & WImporte4 & "', '" & WOrdFecha & "', '" & WWArticulo & "', '" & WRemito & "', '" & WWDate & "', " _
                            & "'" & Wwcantidad & "', '" & Wwimporte & "', '" & Wwimporteus & "', '" & WMarca & "', '" & WLote1 & "', '" & formatonumerico(WCanti1) & "', '" & WLote2 & "', '" & WCanti2 & "', '" & WLote3 & "', '" & WCanti3 & "', '" & WLote4 & "', " _
                            & "'" & WCanti4 & "', '" & WLote5 & "', '" & WCanti5 & "', '" & WEntrada & "', '" & WTipopro & "', '" & WHoja & "', '" & WEmpresa & "', '" & WMarcaant & "', '" & WTipoProDy & "', '" & WArticuloDy & "', " _
                            & "'" & WEnv1 & "', '" & WCantiEnv1 & "', '" & WEnv2 & "', '" & WCantiEnv2 & "', '" & WEnv3 & "', '" & WCantiEnv3 & "', '" & WEnv4 & "', '" & WCantiEnv4 & "', '" & WEnv5 & "', '" & WCantiEnv5 & "', " _
                            & "'" & WNroEntrada & "', '" & WFechaEntrada & "', '" & WNroPedido & "', '" & WFechaPedido & "', '" & WLoteOriginal & "', '" & WObservaDevol & "', '" & WLoteAdicional & "', " _
                            & "'" & WEnvAdicional & "', '" & WClaveCtaCte & "', '" & WImpreTerminado & "', '" & WImpreCantidad & "', '" & WImpreTipo & "', '" & WImpreNumeros & "', " _
                            & "'" & WImpreBruto & "', '" & WTitulo & "', '" & WDescriTerminado & "', '" & WDescriTerminadoII & "', '" & WMarcaMono & "')"

                    ListaSQLCnslt.Add(SQLCnslt)


                    ExecuteNonQueries(BaseConsultar, ListaSQLCnslt.ToArray())

                End If

            End With

        End If

    End Sub

    Private Sub LimpiarForm()
        Dim AuxPedido As String = txt_Pedido.Text
        txt_Pedido.Text = ""
        txt_Producto.Text = ""
        txt_Cant_Restar.Text = ""
        txt_Cantidad_Pendiente.Text = ""
        txt_Cliente.Text = ""
        txt_Desc_Cliente.Text = ""
        txt_Planta.Text = ""
        txt_Partida.Text = ""

        txt_Pedido.Text = AuxPedido

    End Sub
    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click

        If Val(txt_Cant_Restar.Text) > Val(txt_Cantidad_Pendiente.Text) Then
            MsgBox("No puede ser mayor a la cantidad pendiente", vbExclamation)
            Exit Sub
        End If

        Dim Validarlote As Boolean = ValidarLote_Stock()
        If Validarlote = True Then
            DescontarStock()
            btn_Limpiar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_Pedido.Text = ""
        LimpiarForm()
        txt_Pedido.Focus()
    End Sub
End Class
