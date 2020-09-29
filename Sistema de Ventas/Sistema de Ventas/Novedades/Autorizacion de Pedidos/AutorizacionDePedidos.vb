Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class AutorizacionDePedidos : Implements IAutorizacionDePedidos


    Dim WGraba As String = "N"
    Private Function DevuelveTipo(ByVal Posicion As Integer) As String


        Select Case Posicion
            Case 0
                Return "Normal"
            Case 1
                Return "A Fecha"
            Case 2
                Return "Fecha LImite"
            Case 3
                Return "Urgente"
            Case 4
                Return "Retira Cliente"
            Case 5
                Return "MUESTRA"
            Case Else
                Return ""
        End Select
    End Function
    Private Sub btn_LeeDatos_Click(sender As Object, e As EventArgs) Handles btn_LeeDatos.Click

        DGV_Pedidos.DataSource = Nothing

        Dim WOrdFechaDesde As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WOrdFechaHasta As String = ordenaFecha(txt_HastaFecha.Text)

        Dim Pedido As String = ""
        Dim Fecha As String = "  /  /    "
        Dim Cliente As String = ""
        Dim FEntrega As String = "  /  /    "
        Dim Tipo As Integer = 0
        Dim Importe As Double = 0
        Dim Estado As String = ""
        Dim Impresa As String = ""
        Dim Clave As String = ""

        Dim TablaDGV_Pedidos As New DataTable
        With TablaDGV_Pedidos.Columns
            .Add("Pedido")
            .Add("Fecha")
            .Add("Cliente")
            .Add("Razon")
            .Add("FEntrega")
            .Add("Tipo")
            .Add("Importe")
            .Add("Estado")
            .Add("Impresa")
            .Add("Auxiliar1")
            .Add("Auxiliar2")
            .Add("Clave")
        End With

        '
        'PEDIDOS DE VENTAS
        '

        'CONSULTAMOS LOS PEDIDOS QUE SEAN DE UNA FECHA ANTERIOR A LA FECHA DESDE Y NO ESTUVIERAN AUTORIZADOS
        Dim SQLCnslt As String = "SELECT Pedido, Fecha, Cliente, FecEntrega, Tipoped, Autorizo, Impresion, Cantidad, Facturado, Precio, Clave " _
                                & "FROM Pedido WHERE Fechaord < '" & WOrdFechaDesde & "'  and Autorizo = 'N' Order by Clave"

        Dim TablaPedidoViejos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPedidoViejos.Rows.Count > 0 Then
            For Each RowPedido As DataRow In TablaPedidoViejos.Rows

                Pedido = RowPedido.Item("Pedido")
                Fecha = RowPedido.Item("Fecha")
                Cliente = RowPedido.Item("Cliente")
                FEntrega = RowPedido.Item("FecEntrega")
                Tipo = RowPedido.Item("Tipoped")
                Importe = 0
                Estado = RowPedido.Item("Autorizo")
                Impresa = RowPedido.Item("Impresion")
                Clave = RowPedido.Item("Clave")


                Dim RespuestaAutorizado As String = ""
                If Estado = "X" Then
                    RespuestaAutorizado = "Autorizad"

                End If
                Dim RespuestaImpresa As String = ""
                If Impresa = "X" Then
                    RespuestaImpresa = "SI"
                End If

                Importe = Importe + ((RowPedido.Item("Cantidad") - RowPedido.Item("Facturado")) * RowPedido.Item("Precio"))

                TablaDGV_Pedidos.Rows.Add(Pedido, Fecha, Cliente, "", FEntrega, DevuelveTipo(Tipo), formatonumerico(Importe, 2),
                                          RespuestaAutorizado, RespuestaImpresa, "", "", Clave)



            Next
        End If

        'CONSULTAMOS LOS PEDIDOS QUE ESTUVIERAN EN EL RANGO DE FECHAS
        SQLCnslt = "SELECT Pedido, Fecha, Cliente, FecEntrega, Tipoped, Autorizo, Impresion, Cantidad, Facturado, Precio, Clave " _
                   & "FROM Pedido WHERE Fechaord >= '" & WOrdFechaDesde & "'  and Fechaord <= '" & WOrdFechaHasta & "' Order by Clave"

        Dim TablaPedido As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPedido.Rows.Count > 0 Then
            For Each RowPedido As DataRow In TablaPedido.Rows

                Pedido = RowPedido.Item("Pedido")
                Fecha = RowPedido.Item("Fecha")
                Cliente = RowPedido.Item("Cliente")
                FEntrega = RowPedido.Item("FecEntrega")
                Tipo = RowPedido.Item("Tipoped")
                Importe = 0
                Estado = RowPedido.Item("Autorizo")
                Impresa = RowPedido.Item("Impresion")
                Clave = RowPedido.Item("Clave")


                Dim RespuestaAutorizado As String = ""
                If Estado = "X" Then
                    RespuestaAutorizado = "Autorizad"

                End If
                Dim RespuestaImpresa As String = ""
                If Impresa = "X" Then
                    RespuestaImpresa = "SI"
                End If

                Importe = Importe + ((RowPedido.Item("Cantidad") - RowPedido.Item("Facturado")) * RowPedido.Item("Precio"))

                TablaDGV_Pedidos.Rows.Add(Pedido, Fecha, Cliente, "", FEntrega, DevuelveTipo(Tipo), formatonumerico(Importe, 2),
                                          RespuestaAutorizado, RespuestaImpresa, "", "", Clave)

            Next

        End If



        '
        ' SOLICITUD DE DEVOLUCION
        '

        'CONSULTAMOS LOS PEDIDOS DE DEVOLUCION QUE SEAN DE UNA FECHA ANTERIOR A LA FECHA DESDE Y NO ESTUVIERAN AUTORIZADOS
        SQLCnslt = "SELECT Pedido, Fecha, Cliente, Autorizo, Impresion, Cantidad, Facturado, Precio, Clave " _
                 & "FROM PedidoDevol WHERE FechaOrd < '" & WOrdFechaDesde & "' and Autorizo = 'N' Order by Clave"

        Dim TablaPedDevolViejos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPedDevolViejos.Rows.Count > 0 Then
            For Each RowPedido As DataRow In TablaPedDevolViejos.Rows

                Pedido = RowPedido.Item("Pedido")
                Fecha = RowPedido.Item("Fecha")
                Cliente = RowPedido.Item("Cliente")
                Importe = 0
                Estado = RowPedido.Item("Autorizo")
                Impresa = RowPedido.Item("Impresion")
                Clave = RowPedido.Item("Clave")


                Dim RespuestaAutorizado As String = ""
                If Estado = "X" Then
                    RespuestaAutorizado = "Autorizad"

                End If
                Dim RespuestaImpresa As String = ""
                If Impresa = "X" Then
                    RespuestaImpresa = "SI"
                End If

                Importe = Importe + ((RowPedido.Item("Cantidad") - RowPedido.Item("Facturado")) * RowPedido.Item("Precio"))

                TablaDGV_Pedidos.Rows.Add(Pedido, Fecha, Cliente, "", "", "DEVOL", formatonumerico(Importe, 2),
                                          RespuestaAutorizado, RespuestaImpresa, "", "", Clave)

            Next

        End If

        'CONSULTAMOS LOS PEDIDOS DE DEVOLUCION QUE ESTUVIERAN EN EL RANGO DE FECHAS
        SQLCnslt = "SELECT Pedido, Fecha, Cliente, Autorizo, Impresion, Cantidad, Facturado, Precio, Clave " _
                 & "FROM PedidoDevol WHERE FechaOrd >= '" & WOrdFechaDesde & "' and FechaOrd <= '" & WOrdFechaHasta & "' Order by Clave"

        Dim TablaPedDevol As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPedDevol.Rows.Count > 0 Then
            For Each RowPedido As DataRow In TablaPedDevol.Rows

                Pedido = RowPedido.Item("Pedido")
                Fecha = RowPedido.Item("Fecha")
                Cliente = RowPedido.Item("Cliente")
                Importe = 0
                Estado = RowPedido.Item("Autorizo")
                Impresa = RowPedido.Item("Impresion")
                Clave = RowPedido.Item("Clave")


                Dim RespuestaAutorizado As String = ""
                If Estado = "X" Then
                    RespuestaAutorizado = "Autorizad"

                End If
                Dim RespuestaImpresa As String = ""
                If Impresa = "X" Then
                    RespuestaImpresa = "SI"
                End If

                Importe = Importe + ((RowPedido.Item("Cantidad") - RowPedido.Item("Facturado")) * RowPedido.Item("Precio"))

                TablaDGV_Pedidos.Rows.Add(Pedido, Fecha, Cliente, "", "", "DEVOL", formatonumerico(Importe, 2),
                                          RespuestaAutorizado, RespuestaImpresa, "", "", Clave)

            Next

        End If


        For Each RowTablaDGV As DataRow In TablaDGV_Pedidos.Rows
            SQLCnslt = "SELECT Razon FROM Cliente WHERE Cliente = '" & RowTablaDGV.Item("Cliente") & "'"
            Dim RowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowCliente IsNot Nothing Then
                RowTablaDGV.Item("Razon") = RowCliente.Item("Razon")
            End If
        Next

        Dim TotalPedidos As Integer = TablaDGV_Pedidos.Rows.Count

        DGV_Pedidos.DataSource = TablaDGV_Pedidos

    End Sub

    Private Sub AutorizacionDePedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_DesdeFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_HastaFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        btn_LeeDatos_Click(Nothing, Nothing)
    End Sub

    Private Sub btn_Graba_Click(sender As Object, e As EventArgs) Handles btn_Graba.Click

        WGraba = "S"

        If WGraba <> "S" Then
            With New VentanaPassword
                .Show(Me)
            End With
        Else

            Dim ListaSQLCnslt As New List(Of String)

            WGraba = ""

            Dim WFechaAutoriza As String = Date.Today.ToString("MM/dd/yyyy")

            For Each DGV_Row As DataGridViewRow In DGV_Pedidos.Rows
                If DGV_Row.Cells("Estado").Value = "Autorizado" Then

                    If DGV_Row.Cells("Tipo").Value = "DEVOL" Then




                        Dim WCliente As String = DGV_Row.Cells("Cliente").Value

                        Dim WBloqueo As String = DGV_Row.Cells("Auxiliar1").Value


                        Dim WPedido As String = DGV_Row.Cells("Pedido").Value
                        Dim WMarca As String = "X"
                        Dim WFecha As String = txt_DesdeFecha.Text
                        Dim WfechaOrd As String = ordenaFecha(txt_DesdeFecha.Text)

                        Dim SQLCnslt1 As String = "UPDATE  PedidoDevol SET Autorizo 	= '" & WMarca & "', Fecha = '" & WFecha & "', " _
                                                 & "Fechaord = '" & WfechaOrd & "' WHERE Pedido = '" & WPedido & "'"

                        ListaSQLCnslt.Add(SQLCnslt1)


                        Dim WImpreLaboI As String = ""
                        Dim WImpreLaboII As String = ""
                        Dim WImpreProdI As String = "N"
                        Dim WImpreProdII As String = "N"
                        Dim WImpreProdIII As String = "N"
                        Dim WImpreProdIV As String = "N"
                        Dim WImpresionII As String = "N"


                        SQLCnslt1 = "UPDATE PedidoDevol SET " _
                        & "ImpreLaboI = '" & WImpreLaboI & "', " _
                        & "ImpreLaboII = '" & WImpreLaboII & "', " _
                        & "ImpreProdI = '" & WImpreProdI & "', " _
                        & "ImpreProdII = '" & WImpreProdII & "', " _
                        & "ImpreProdIII = '" & WImpreProdIII & "', " _
                        & "ImpreProdIV = '" & WImpreProdIV & "', " _
                        & "ImpresionII = '" & WImpresionII & "', " _
                        & "Bloqueo = '" & WBloqueo & "' " _
                        & "Where Pedido = '" & WPedido & "'"

                        ListaSQLCnslt.Add(SQLCnslt1)


                        If WBloqueo = "S" Then
                            ' BLOQUEA LOS ARTICULOS

                            Dim TablaBloqueo As New DataTable
                            With TablaBloqueo.Columns
                                .Add("Terminado")
                                .Add("Cantidad")
                                .Add("Partida")
                            End With


                            Dim VectorEmpresas(7) As String
                            VectorEmpresas(0) = "SurfactanSa"
                            VectorEmpresas(1) = "Surfactan_II"
                            VectorEmpresas(2) = "Surfactan_III"
                            VectorEmpresas(3) = "Surfactan_IV"
                            VectorEmpresas(4) = "Surfactan_V"
                            VectorEmpresas(5) = "Surfactan_VI"
                            VectorEmpresas(6) = "Surfactan_VII"



                            SQLCnslt1 = "SELECT Terminado, Cantidad, Partida FROM PedidoDevol " _
                                     & "WHERE Pedido = '" & WPedido & "' Order by Clave "

                            TablaBloqueo = GetAll(SQLCnslt1, "SurfactanSa")

                            If TablaBloqueo.Rows.Count > 0 Then
                                For Each RowBloqueo As DataRow In TablaBloqueo.Rows
                                    Dim Terminado As String = RowBloqueo.Item("Terminado")
                                    Dim Cantidad As String = RowBloqueo.Item("Cantidad")
                                    Dim Lote As String = RowBloqueo.Item("Partida")

                                    'HACEMOS UN FOR, UNA VUELTA POR EMPRESA
                                    For i = 0 To 6
                                        If Microsoft.VisualBasic.Left$(Terminado, 2) <> "PT" And Microsoft.VisualBasic.Left$(Terminado, 2) <> "PE" Then

                                            Dim WEntra As String = "N"
                                            Dim WArti As String = ""

                                            If Microsoft.VisualBasic.Left$(Terminado, 2) = "DY" Or Microsoft.VisualBasic.Left$(Terminado, 2) = "DK" Then
                                                WArti = "DY-" + Microsoft.VisualBasic.Right$(Terminado, 7)
                                            Else
                                                If Microsoft.VisualBasic.Left$(Terminado, 2) = "DS" Or Microsoft.VisualBasic.Left$(Terminado, 2) = "NS" Then
                                                    WArti = "DS-" + Microsoft.VisualBasic.Right$(Terminado, 7)
                                                Else
                                                    If Microsoft.VisualBasic.Left$(Terminado, 2) = "DQ" Or Microsoft.VisualBasic.Left$(Terminado, 2) = "NQ" Then
                                                        WArti = "DQ-" + Microsoft.VisualBasic.Right$(Terminado, 7)
                                                    Else
                                                        WArti = Microsoft.VisualBasic.Left$(Terminado, 2) + "-" + Microsoft.VisualBasic.Right$(Terminado, 7)
                                                    End If
                                                End If
                                            End If

                                            'VERIFICO QUE EXISTA UN REGISTRO DE LAUDO
                                            SQLCnslt1 = "Select Articulo FROM Laudo WHERE Articulo = '" & WArti & "' and Lote = '" & Lote & "' Order by Laudo"
                                            Dim Row As DataRow = GetSingle(SQLCnslt1, VectorEmpresas(i))

                                            If Row IsNot Nothing Then
                                                'SI EXISTE LO ACTUALIZAMOS
                                                WEntra = "S"
                                                Dim WMarcaEstado As String = "N"

                                                SQLCnslt1 = "UPDATE " & VectorEmpresas(i) & ".dbo.Laudo SET Estado = '" & WMarcaEstado & "' " _
                                                          & "WHERE Articulo = '" & WArti & "' AND Lote = '" & Lote & "'"
                                                'LO INCLUYO EN LA LISTA DE CONSULTAS
                                                ListaSQLCnslt.Add(SQLCnslt1)
                                            End If

                                            If WEntra = "N" Then
                                                'REVISAMOS QUE EXISTA UNA GUIA
                                                SQLCnslt1 = "SELECT Articulo FROM Guia WHERE Articulo ='" & WArti & "' AND Lote = '" & Lote & "'"
                                                Dim RowGuia As DataRow = GetSingle(SQLCnslt1, VectorEmpresas(i))

                                                If RowGuia IsNot Nothing Then
                                                    'SI EXISTE ACTUALIZAMOS
                                                    Dim WMarcaEstado As String = "N"

                                                    SQLCnslt1 = "UPDATE " & VectorEmpresas(i) & ".dbo.Guia SET Estado = '" & WMarcaEstado & "' " _
                                                          & "WHERE Articulo = '" & WArti & "' AND Lote = '" & Lote & "'"
                                                    'LO INCLUYO EN LA LISTA DE CONSULTAS
                                                    ListaSQLCnslt.Add(SQLCnslt1)
                                                End If
                                            End If

                                        Else


                                            Dim WEntra As String = "N"

                                            'VERIFICAMOS QUE EXISTA UNA HOJA
                                            SQLCnslt1 = "SELECT Hoja FROM Hoja WHERE Producto = '" & Terminado & "' and Hoja = '" & Lote & "' and Renglon = 1 Order by Hoja"
                                            Dim RowHoja As DataRow = GetSingle(SQLCnslt1, VectorEmpresas(i))

                                            If RowHoja IsNot Nothing Then
                                                'SI EXISTE LA ACTUALIZAMOS
                                                WEntra = "S"
                                                Dim WMarcaEstado As String = "N"

                                                SQLCnslt1 = "UPDATE " & VectorEmpresas(i) & ".dbo.Hoja SET Estado = '" & WMarcaEstado & "' " _
                                                         & "WHERE Producto = '" & Terminado & "' AND Hoja = '" & Lote & "'"
                                                'LO INCLUYO EN LA LISTA DE CONSULTAS
                                                ListaSQLCnslt.Add(SQLCnslt1)

                                            End If

                                            If WEntra = "N" Then
                                                'VERIFICAMOS QUE EXISTA UNA GUIA PARA ESA HOJA

                                                SQLCnslt1 = "SELECT Lote FROM Guia WHERE Terminado = '" & Terminado & "' and Lote = '" & Lote & "' and Renglon = 1 Order by Saldo DESC, FechaOrd"
                                                Dim RowGuia As DataRow = GetSingle(SQLCnslt1, VectorEmpresas(i))

                                                If RowGuia IsNot Nothing Then
                                                    'SI EXISTE LA ACTUALIZAMOS

                                                    Dim WMarcaEstado As String = "N"

                                                    SQLCnslt1 = "UPDATE " & VectorEmpresas(i) & ".dbo.Guia SET Estado = '" & WMarcaEstado & "' " _
                                                             & "WHERE Terminado = '" & Terminado & "' AND Lote = '" & Lote & "'"
                                                    'LO INCLUYO EN LA LISTA DE CONSULTAS
                                                    ListaSQLCnslt.Add(SQLCnslt1)
                                                End If



                                            End If
                                        End If



                                    Next

                                Next
                            End If

                        End If
                    End If

                    If DGV_Row.Cells("Tipo").Value = "MUESTRA" Then
                        Dim WPedido As String = DGV_Row.Cells("Pedido").Value

                        Dim TablaPedidos As New DataTable
                        With TablaPedidos.Columns
                            .Add("Terminado")
                            .Add("Cantidad")
                            .Add("NombreComercial")
                            .Add("OrdenTrabajo")
                            .Add("Referencia")
                            .Add("Clave")
                        End With

                        Dim WFechaPedido As String = ""
                        Dim WCliente As String = ""
                        Dim WObservaciones As String = ""
                        Dim WLugarDirEntrega As String = ""



                        Dim SQLCnslt2 As String = "SELECT Terminado, Cantidad, NombreComercial, OrdenTrabajo, Referencia, Clave, Fecha, " _
                                                 & "Cliente ,Observaciones, DirEntrega FROM Pedido WHERE Pedido = '" & WPedido & "' Order by Clave"

                        Dim Tabla As DataTable = GetAll(SQLCnslt2, "SurfactanSa")

                        If Tabla.Rows.Count > 0 Then
                            For Each Row_Pedido As DataRow In Tabla.Rows

                                Dim Terminado As String = Row_Pedido.Item("Terminado")
                                Dim Cantidad As String = Row_Pedido.Item("Cantidad")
                                Dim NombreComercial As String = ""
                                If Microsoft.VisualBasic.Left$(Row_Pedido.Item("Terminado"), 2) = "ML" Then
                                    NombreComercial = IIf(IsDBNull(Row_Pedido.Item("NombreComercial")), "", Row_Pedido.Item("NombreComercial"))
                                End If
                                Dim OrdenTrabajo As String = IIf(IsDBNull(Row_Pedido.Item("OrdenTrabajo")), "", Row_Pedido.Item("OrdenTrabajo"))
                                Dim Referencia As String = IIf(IsDBNull(Row_Pedido.Item("Referencia")), "", Row_Pedido.Item("Referencia"))
                                Dim Clave As String = Row_Pedido.Item("Clave")
                                WFechaPedido = Row_Pedido.Item("Fecha")
                                WCliente = Row_Pedido.Item("Cliente")
                                WObservaciones = Row_Pedido.Item("Observaciones")
                                WLugarDirEntrega = Row_Pedido.Item("DirEntrega")
                                'CARGAMOS UMA FILA EN LA TABLA EN MEMORIA
                                TablaPedidos.Rows.Add(Terminado, Cantidad, NombreComercial, OrdenTrabajo, Referencia, Clave)
                            Next

                        End If

                        'CON EL CLIENTE BUSCAMOS LA RAZON SOCIAL Y EL VENDEDOR

                        Dim WRazon As String = ""
                        Dim WVendedor As String = ""
                        Dim VectorDireccionEntrega(6) As String

                        SQLCnslt2 = "SELECT Razon, Vendedor, DirEntrega, DirEntregaII, DirEntregaIII, DirEntregaIV, DirEntregaV " _
                                  & "FROM Cliente WHERE Cliente = '" & WCliente & "'"

                        Dim Row As DataRow = GetSingle(SQLCnslt2, "SurfactanSa")

                        If Row IsNot Nothing Then
                            WRazon = Row.Item("Razon")
                            WVendedor = Row.Item("Vendedor")
                            VectorDireccionEntrega(1) = Row.Item("DirEntrega")
                            VectorDireccionEntrega(2) = Trim(IIf(IsDBNull(Row.Item("DirEntregaII")), "", Row.Item("DirEntregaII")))
                            VectorDireccionEntrega(3) = Trim(IIf(IsDBNull(Row.Item("DirEntregaIII")), "", Row.Item("DirEntregaIII")))
                            VectorDireccionEntrega(4) = Trim(IIf(IsDBNull(Row.Item("DirEntregaIV")), "", Row.Item("DirEntregaIV")))
                            VectorDireccionEntrega(5) = Trim(IIf(IsDBNull(Row.Item("DirEntregaV")), "", Row.Item("DirEntregaV")))
                        End If

                        Dim WDescriDirEntrega As String = VectorDireccionEntrega(Val(WLugarDirEntrega))
                        Dim WDesVendedor As String = ""

                        SQLCnslt2 = "SELECT Nombre FROM Vendedor WHERE Vendedor = '" & WVendedor & "'"

                        Dim Row_Vendedor As DataRow = GetSingle(SQLCnslt2, "SurfactanSa")

                        If Row_Vendedor IsNot Nothing Then
                            WDesVendedor = Row_Vendedor.Item("Nombre")
                        End If


                        For Each RowPedidos As DataRow In TablaPedidos.Rows


                            Dim WCodigoTerminado As String = RowPedidos.Item("Terminado")
                            Dim WCantidad As String = RowPedidos.Item("Cantidad")
                            Dim WNombreComercial As String = Trim(RowPedidos.Item("NombreComercial"))
                            Dim WOrdenTrabajo As String = RowPedidos.Item("OrdenTrabajo")
                            Dim WReferencia As String = Trim(RowPedidos.Item("Referencia"))
                            Dim WClavePedido As String = Trim(RowPedidos.Item("Clave"))


                            Dim WTerminado As String
                            Dim WArticulo As String

                            Select Case Microsoft.VisualBasic.Left$(WCodigoTerminado, 2)
                                Case "PT", "PE", "YQ", "YF", "YP", "YH"
                                    WTerminado = WCodigoTerminado
                                    WArticulo = ""
                                Case Else
                                    WTerminado = ""
                                    WArticulo = Microsoft.VisualBasic.Left$(WCodigoTerminado, 3) + Microsoft.VisualBasic.Right$(WCodigoTerminado, 7)
                            End Select

                            Dim WEnsayo As String = ""
                            Dim WNombre As String = ""



                            If WArticulo = "" Then
                                SQLCnslt2 = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & WTerminado & "'"

                            Else

                                SQLCnslt2 = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArticulo & "'"

                            End If

                            Dim RowProducto As DataRow = GetSingle(SQLCnslt2, "SurfactanSa")

                            If RowProducto IsNot Nothing Then
                                WNombre = RowProducto.Item("Descripcion")
                            End If

                            Dim WAutoriza As String = "S"
                            Dim WImpresion As String = "S"
                            Dim WDescriCliente As String = ""

                            If WNombreComercial = "" Then
                                WDescriCliente = WNombre
                            Else
                                WDescriCliente = WNombreComercial
                            End If

                            If WTerminado <> "" Then
                                Dim ClavePrecios As String = WCliente & WTerminado
                                SQLCnslt2 = "SELECT Descripcion FROM Precios WHERE Clave = '" & ClavePrecios & "'"

                                Dim RowPrecios As DataRow = GetSingle(SQLCnslt2, "SurfactanSa")

                                If RowPrecios IsNot Nothing Then
                                    WDescriCliente = RowPrecios.Item("Descripcion")
                                End If

                            End If


                            Dim WCodigoMayor As Integer
                            Dim WCodigo As String
                            SQLCnslt2 = "SELECT CodigoMayor = Max(Codigo) FROM Muestra"

                            Dim RowMuestra As DataRow = GetSingle(SQLCnslt2, "SurfactanSa")

                            If RowMuestra IsNot Nothing Then
                                WCodigoMayor = IIf(IsDBNull(RowMuestra.Item("CodigoMayor")), 0, RowMuestra.Item("CodigoMayor"))
                                WCodigo = Mid$(Str$(WCodigoMayor + 1), 2, 8)

                            Else
                                WCodigo = "1"
                            End If

                            Dim ZZDescripcion As String = ""
                            Dim ZZUnidad As String = ""
                            Dim ZZDeposito As String = ""
                            Dim ZZInicial As String = ""
                            Dim ZZEntradas As String = ""
                            Dim ZZSalidas As String = ""
                            Dim ZZMInimo As String = ""
                            Dim ZZMinimo1 As String = ""
                            Dim ZZVenta As String = ""
                            Dim ZZEnvase As String = ""
                            Dim ZZCosto1 As String = ""
                            Dim ZZWCosto1 As String = ""
                            Dim ZZZCosto1 As String = ""
                            Dim ZZCosto6 As String = ""
                            Dim ZZWCosto2 As String = ""
                            Dim ZZWCosto3 As String = ""
                            Dim ZZCosto4 As String = ""
                            Dim ZZOrdenI As String = ""
                            Dim ZZOrdenII As String = ""
                            Dim ZZOrdenIII As String = ""
                            Dim ZZPtaOrdenI As String = ""
                            Dim ZZPtaOrdenII As String = ""
                            Dim ZZPtaOrdenIII As String = ""
                            Dim ZZRs As String = ""
                            Dim ZZFlete As String = ""
                            Dim ZZMoneda As String = ""
                            Dim ZZControla As String = ""
                            Dim ZZReventa As String = ""
                            Dim ZZSedronar As String = ""
                            Dim ZZTipoMp As String = ""
                            Dim ZZCodSedronar As String = ""
                            Dim ZZDensidad As String = ""
                            Dim ZZCodigoDy As String = ""
                            Dim ZZLeyenda As String = ""
                            Dim ZZClase As String = ""
                            Dim ZZIntervencion As String = ""
                            Dim ZZNaciones As String = ""
                            Dim ZZEmbalaje As String = ""
                            Dim ZZMeses As String = ""
                            Dim ZZDerechos As String = ""
                            Dim ZZparance As String = ""
                            Dim ZZTipoCosto As String = ""
                            Dim ZZProveedor As String = ""




                            If WArticulo = "ML-008-100" Then

                                SQLCnslt2 = "SELECT Descripcion, Unidad, Deposito, Inicial, Entradas, Salidas, Minimo, Minimo1, Venta, Envase, Rs " _
                                    & "Flete, Moneda, Controla, Reventa, Sedronar, TipoMp, CodSedronar, Densidad, CodigoDy, Leyenda, Clase, " _
                                    & "Intervencion, Naciones, Embalaje, Meses, Derechos, Posarance, TipoCosto, Proveedor " _
                                    & "FROM Articulo WHERE Codigo = '" & "ML-008-100" & "'"

                                Dim Row_CodArticulo As DataRow = GetSingle(SQLCnslt2, SQLCnslt2 = "SurfactanSa")

                                If Row_CodArticulo IsNot Nothing Then

                                    ZZDescripcion = Trim(Row_CodArticulo.Item("Descripcion"))
                                    ZZUnidad = Row_CodArticulo.Item("Unidad")
                                    ZZDeposito = Row_CodArticulo.Item("Deposito")
                                    ZZInicial = Str$(Row_CodArticulo.Item("Inicial"))
                                    ZZEntradas = Str$(Row_CodArticulo.Item("Entradas"))
                                    ZZSalidas = Str$(Row_CodArticulo.Item("Salidas"))
                                    ZZMInimo = Str$(Row_CodArticulo.Item("MInimo"))
                                    ZZMinimo1 = IIf(IsDBNull(Row_CodArticulo.Item("Minimo1")), "0", Row_CodArticulo.Item("Minimo1"))
                                    ZZVenta = IIf(IsDBNull(Row_CodArticulo.Item("Venta")), "0", Row_CodArticulo.Item("Venta"))
                                    ZZEnvase = Str$(Row_CodArticulo.Item("Envase"))

                                    ZZCosto1 = "0"
                                    ZZWCosto1 = "0"
                                    ZZZCosto1 = "0"
                                    ZZCosto6 = "0"
                                    ZZWCosto2 = "0"
                                    ZZWCosto3 = "0"
                                    ZZCosto4 = "0"

                                    ZZOrdenI = ""
                                    ZZOrdenII = ""
                                    ZZOrdenIII = ""
                                    ZZPtaOrdenI = ""
                                    ZZPtaOrdenII = ""
                                    ZZPtaOrdenIII = ""

                                    ZZRs = Row_CodArticulo.Item("Rs")
                                    ZZFlete = Str$(Row_CodArticulo.Item("Flete"))
                                    ZZMoneda = Row_CodArticulo.Item("Moneda")
                                    ZZControla = IIf(IsDBNull(Row_CodArticulo.Item("Controla")), "0", Row_CodArticulo.Item("Controla"))
                                    ZZReventa = IIf(IsDBNull(Row_CodArticulo.Item("Reventa")), "0", Row_CodArticulo.Item("Reventa"))
                                    ZZSedronar = IIf(IsDBNull(Row_CodArticulo.Item("Sedronar")), "0", Row_CodArticulo.Item("Sedronar"))
                                    ZZTipoMp = IIf(IsDBNull(Row_CodArticulo.Item("!TipoMp")), "0", Row_CodArticulo.Item("TipoMp"))
                                    ZZCodSedronar = IIf(IsDBNull(Row_CodArticulo.Item("CodSedronar")), "", Row_CodArticulo.Item("CodSedronar"))
                                    ZZDensidad = IIf(IsDBNull(Row_CodArticulo.Item("Densidad")), "", Row_CodArticulo.Item("Densidad"))
                                    ZZCodigoDy = IIf(IsDBNull(Row_CodArticulo.Item("CodigoDy")), "", Row_CodArticulo.Item("CodigoDy"))
                                    ZZLeyenda = IIf(IsDBNull(Row_CodArticulo.Item("Leyenda")), "0", Row_CodArticulo.Item("Leyenda"))
                                    ZZClase = IIf(IsDBNull(Row_CodArticulo.Item("Clase")), "", Row_CodArticulo.Item("Clase"))
                                    ZZIntervencion = IIf(IsDBNull(Row_CodArticulo.Item("Intervencion")), "", Row_CodArticulo.Item("Intervencion"))
                                    ZZNaciones = IIf(IsDBNull(Row_CodArticulo.Item("Naciones")), "", Row_CodArticulo.Item("Naciones"))
                                    ZZEmbalaje = IIf(IsDBNull(Row_CodArticulo.Item("Embalaje")), "", Row_CodArticulo.Item("Embalaje"))
                                    ZZMeses = IIf(IsDBNull(Row_CodArticulo.Item("Meses")), "0", Row_CodArticulo.Item("Meses"))
                                    ZZDerechos = IIf(IsDBNull(Row_CodArticulo.Item("Derechos")), "0", Row_CodArticulo.Item("Derechos"))
                                    ZZparance = IIf(IsDBNull(Row_CodArticulo.Item("Posarance")), "0", Row_CodArticulo.Item("Posarance"))

                                    ZZTipoCosto = IIf(IsDBNull(Row_CodArticulo.Item("TipoCosto")), "0", Row_CodArticulo.Item("TipoCosto"))
                                    ZZProveedor = Row_CodArticulo.Item("Proveedor")


                                    Dim WCodigoNuevo As String = ""

                                    SQLCnslt2 = "SELECT Codigo FROM Articulo WHERE Codigo <= '" & "ML-999-100" & "' ORDER BY Codigo"

                                    Dim TablaCodigoArticulos As DataTable = GetAll(SQLCnslt2, "SurfactanSa")

                                    If TablaCodigoArticulos.Rows.Count > 0 Then
                                        For Each RowCodigoArticulos As DataRow In TablaCodigoArticulos.Rows

                                            WCodigoNuevo = RowCodigoArticulos.Item("Codigo")

                                        Next
                                    End If

                                    Dim ZZNroMuestra As Integer

                                    ZZNroMuestra = Val(Mid$(WCodigoNuevo, 4, 3))
                                    If ZZNroMuestra < 100 Then
                                        ZZNroMuestra = 100
                                    Else
                                        ZZNroMuestra = ZZNroMuestra + 1
                                    End If
                                    Dim Auxi As String = Str$(ZZNroMuestra)
                                    Call ceros(Auxi, 3)

                                    Dim ZArticulo As String = "ML-" + Auxi + "-100"


                                    SQLCnslt2 = "INSERT INTO  Articulo (" _
                                                 & "Codigo, " _
                                                 & "Descripcion, " _
                                                 & "Costo1, " _
                                                 & "Costo2, " _
                                                 & "Inicial, " _
                                                 & "Entradas, " _
                                                 & "Salidas, " _
                                                 & "Minimo, " _
                                                 & "Laboratorio, " _
                                                 & "Unidad, " _
                                                 & "Pedido, " _
                                                 & "Deposito, " _
                                                 & "Envase, " _
                                                 & "Rs, " _
                                                 & "Fecha, " _
                                                 & "Orden, " _
                                                 & "Dife, " _
                                                 & "Proveedor, " _
                                                 & "WDate, " _
                                                 & "Flete, " _
                                                 & "Moneda, " _
                                                 & "Controla, " _
                                                 & "Densidad, " _
                                                 & "Costo3, " _
                                                 & "WCosto1, " _
                                                 & "WCosto2, " _
                                                 & "WCosto3, " _
                                                 & "Venta) " _
                                                 & "VALUES ( " _
                                                 & "'" & ZArticulo & "', " _
                                                 & "'" & ZZDescripcion & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & ZZUnidad & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & "0" & "', " _
                                                 & "'" & ZZEnvase & "', " _
                                                 & "'" & ZZRs & "', " _
                                                 & "'" & "  /  /    " & "', " _
                                                 & "'" & "" & "', " _
                                                 & "'" & "" & "', " _
                                                 & "'" & ZZProveedor & "', " _
                                                 & "'" & "" & "','" & ZZFlete & "', " _
                                                 & "'" & ZZMoneda & "','" & Str$(ZZControla) & "', " _
                                                 & "'" & ZZDensidad & "','" & "" & "', " _
                                                 & "'" & "" & "','" & "" & "', " _
                                                 & "'" & "" & "', " _
                                                 & "'" & "" & "')"


                                    ListaSQLCnslt.Add(SQLCnslt2)


                                    SQLCnslt2 = "UPDATE Articulo SET " _
                                     & "Descripcion = '" & ZZDescripcion & "'," _
                                     & "Costo1 = '" & "" & "'," _
                                     & "Costo2 = '" & "" & "'," _
                                     & "Inicial = '" & "0" & "'," _
                                     & "Entradas = '" & "" & "'," _
                                     & "Salidas = '" & "" & "'," _
                                     & "Minimo = '" & "" & "'," _
                                     & "Laboratorio = '" & "" & "'," _
                                     & "Unidad = '" & ZZUnidad & "'," _
                                     & "Pedido = '" & "" & "'," _
                                     & "Deposito = '" & "" & "'," _
                                     & "Envase = '" & ZZEnvase & "'," _
                                     & "Rs = '" & ZZRs & "'," _
                                     & "Fecha = '" & "" & "'," _
                                     & "Orden = '" & "" & "'," _
                                     & "Dife = '" & "" & "'," _
                                     & "Proveedor = '" & ZZProveedor & "'," _
                                     & "WDate = '" & "" & "'," _
                                     & "Flete = '" & ZZFlete & "'," _
                                     & "Moneda = '" & ZZMoneda & "'," _
                                     & "Controla = '" & Str$(ZZControla) & "'," _
                                     & "Densidad = '" & ZZDensidad & "'," _
                                     & "Costo3 = '" & 7 & "'," _
                                     & "WCosto1 = '" & "" & "'," _
                                     & "WCosto2 = '" & "" & "'," _
                                     & "WCosto3 = '" & "" & "'," _
                                     & "Venta = '" & "" & "'" _
                                     & " Where Codigo = '" & ZArticulo & "'"

                                    ListaSQLCnslt.Add(SQLCnslt2)


                                    SQLCnslt2 = "UPDATE  Articulo SET Minimo1 = '" & "" & "' WHERE Codigo = '" & ZArticulo & "'"

                                    ListaSQLCnslt.Add(SQLCnslt2)


                                    SQLCnslt2 = "UPDATE  Articulo SET Leyenda = '" & "" & "' WHERE Codigo = '" & ZArticulo & "'"

                                    ListaSQLCnslt.Add(SQLCnslt2)

                                    SQLCnslt2 = "UPDATE Articulo SET " _
                                                & "Responsable = '" & "" & "'," _
                                                & "Reventa = '" & Str$(ZZReventa) & "'," _
                                                & "CodSedronar = '" & ZZCodSedronar & "'," _
                                                & "Sedronar = '" & ZZSedronar & "'," _
                                                & "TipoMp = '" & ZZTipoMp & "'," _
                                                & "Minimo1 = '" & Str$(ZZMinimo1) & "'," _
                                                & "Leyenda = '" & Str$(ZZLeyenda) & "'," _
                                                & "Clase = '" & "" & "'," _
                                                & "Intervencion = '" & "" & "'," _
                                                & "Naciones = '" & "" & "'," _
                                                & "Embalaje = '" & "" & "'," _
                                                & "Meses = '" & "" & "'," _
                                                & "TipoCosto = '" & ZZTipoCosto & "'," _
                                                & "CodigoDy = '" & ZZCodigoDy & "'" _
                                                & " Where Codigo = '" & ZArticulo & "'"

                                    ListaSQLCnslt.Add(SQLCnslt2)


                                End If

                            End If

                            Dim WFecha As String = WFechaPedido

                            Dim WFechaOrd As String = ordenaFecha(WFechaPedido)



                            WNombre = WNombre.PadLeft(50, "")
                            WRazon = WRazon.PadLeft(50, "")
                            WDescriCliente = WDescriCliente.PadLeft(50, "")
                            WObservaciones = WObservaciones.PadLeft(50, "")
                            If Trim(WReferencia) <> "" Then
                                WObservaciones = WReferencia.PadLeft(50, "")
                            End If
                            WDescriDirEntrega = WDescriDirEntrega.PadLeft(50, "")
                            WOrdenTrabajo = WOrdenTrabajo

                            SQLCnslt2 = "INSERT INTO Muestra (" _
                                       & "Codigo ," _
                                       & "Producto ," _
                                       & "Articulo ," _
                                       & "Ensayo ," _
                                       & "Nombre ," _
                                       & "Fecha ," _
                                       & "OrdFecha ," _
                                       & "Cantidad ," _
                                       & "Cliente ," _
                                       & "Razon ," _
                                       & "DescriCliente ," _
                                       & "Vendedor ," _
                                       & "DesVendedor ," _
                                       & "Observaciones ," _
                                       & "OrdenTRabajo ," _
                                       & "Autoriza ," _
                                       & "Impresion ," _
                                       & "Pedido ," _
                                       & "ClavePedido ," _
                                       & "DirEntrega ," _
                                       & "DescriDirEntrega) " _
                                       & "Values (" _
                                       & "'" & WCodigo & "'," _
                                       & "'" & WTerminado & "'," _
                                       & "'" & WArticulo & "'," _
                                       & "'" & WEnsayo & "'," _
                                       & "'" & WNombre & "'," _
                                       & "'" & WFecha & "'," _
                                       & "'" & WFechaOrd & "'," _
                                       & "'" & WCantidad & "'," _
                                       & "'" & WCliente & "'," _
                                       & "'" & WRazon & "'," _
                                       & "'" & WDescriCliente & "'," _
                                       & "'" & WVendedor & "'," _
                                       & "'" & WDesVendedor & "'," _
                                       & "'" & WObservaciones & "'," _
                                       & "'" & WOrdenTrabajo & "'," _
                                       & "'" & WAutoriza & "'," _
                                       & "'" & WImpresion & "'," _
                                       & "'" & WPedido & "'," _
                                       & "'" & WClavePedido & "'," _
                                       & "'" & WLugarDirEntrega & "'," _
                                       & "'" & WDescriDirEntrega & "')"

                            ListaSQLCnslt.Add(SQLCnslt2)

                        Next

                    End If



                    '
                    ' ACTUALIZA PEDIDO
                    '

                    Dim ZPedido As String = DGV_Row.Cells("Pedido").Value
                    Dim ZMarca As String = "X"
                    Dim FechaDesde As String = txt_DesdeFecha.Text
                    Dim FechaDesdeOrd As String = ordenaFecha(txt_DesdeFecha.Text)

                    Dim SQLCnslt3 As String = "UPDATE  Pedido SET " _
                                               & "Autorizo 	= '" & ZMarca & "', " _
                                               & "Fecha		= '" & FechaDesde & "', " _
                                               & "Fechaord	= '" & FechaDesdeOrd & "' " _
                                               & "WHERE Pedido = '" & ZPedido & "'"

                    ListaSQLCnslt.Add(SQLCnslt3)


                    Dim WTipoPedido As Integer = 0
                    Dim WTipoPed As Integer = 0

                    SQLCnslt3 = "SELECT TipoPedido, Tipoped FROM Pedido WHERE Pedido = '" & ZPedido & "' ORDER BY Clave"

                    Dim RowPedido As DataRow = GetSingle(SQLCnslt3, "SurfactanSa")

                    If RowPedido IsNot Nothing Then
                        WTipoPedido = RowPedido.Item("TipoPedido")
                        WTipoPed = RowPedido.Item("Tipoped")
                    End If

                    Select Case WTipoPedido
                        Case 1, 4
                            ZMarca = "0"
                        Case Else
                            ZMarca = "1"
                    End Select

                    SQLCnslt3 = "UPDATE Pedido SET Proceso1 = '" & ZMarca & "' WHERE Pedido = '" & ZPedido & "'"

                    ListaSQLCnslt.Add(SQLCnslt3)

                    SQLCnslt3 = "UPDATE Pedido SET ImpreMuestra = '" & "N" & "' WHERE Pedido ='" & ZPedido & "'"

                    ListaSQLCnslt.Add(SQLCnslt3)

                Else


                    ' dada
                    ' actualiza pedido
                    ' dada




                    Dim WPedido As String = DGV_Row.Cells("Pedido").Value
                    Dim WTipoPedido As Integer = 0
                    Dim WTipoPed As Integer = 0
                    Dim WFechaPedido As String = "00/00/0000"
                    Dim Wcliente As String = ""

                    Dim SQLCnslt4 As String = "SELECT TipoPedido, Tipoped, Fecha, Cliente FROM Pedido WHERE Pedido = '" & WPedido & "' ORDER BY Clave"

                    Dim RowPedido As DataRow = GetSingle(SQLCnslt4, "SurfactanSa")

                    If RowPedido IsNot Nothing Then
                        WTipoPedido = RowPedido.item("TipoPedido")
                        WTipoPed = RowPedido.Item("Tipoped")
                        WFechaPedido = RowPedido.Item("Fecha")
                        Wcliente = RowPedido.Item("Cliente")

                    End If

                    Dim WMarca As String = "X"
                    Dim WFecha As String = WFechaAutoriza
                    Dim WFechaOrd As String = ordenaFecha(WFechaAutoriza)

                    SQLCnslt4 = "UPDATE Pedido SET Autorizo = '" & WMarca & "' , Fecha = '" & WFecha & "', Fechaord = '" & WFechaOrd & "' WHERE Pedido = '" & WPedido & "'"

                    ListaSQLCnslt.Add(SQLCnslt4)

                    If (Operador.Codigo = 1) Then


                        Dim WCanti As Double = 0

                        SQLCnslt4 = "SELECT Cantidad, Movimiento FROM MovEnv WHERE Cliente = '" & Wcliente & "' " _
                                  & "AND FechaOrd >= '" & 201220101 & "' AND Envase = '" & 30 & "'"

                        Dim Tabla_MovEnv As DataTable = GetAll(SQLCnslt4, "SurfactanSa")

                        If Tabla_MovEnv.Rows.Count > 0 Then
                            For Each Row_MovEnv As DataRow In Tabla_MovEnv.Rows
                                Dim WCantidad As String = Row_MovEnv.Item("Cantidad")
                                Dim WMovi As String = Row_MovEnv.Item("Movimiento")

                                If WMovi = "E" Then
                                    WCanti = WCanti - WCantidad
                                Else
                                    WCanti = WCanti + WCantidad
                                End If
                            Next

                        End If


                        If WCanti > 0 Then
                            SQLCnslt4 = "UPDATE Pedido SET " _
                                       & " MarcaEnvase =  '" & "N" & "'," _
                                       & " CantidadEnvase =  '" & Str$(WCanti) & "'" _
                                       & " Where Pedido = '" & WPedido & "'" _
                                       & " and Renglon = '" & "1" & "'"

                            ListaSQLCnslt.Add(SQLCnslt4)


                        End If
                    End If

                    If WFechaPedido <> WFechaAutoriza Then


                        Dim WXFecha2 = DGV_Row.Cells("Auxiliar2").Value


                        If WXFecha2 <> "" Then

                            Dim ZZFecha As String = Date.Today.ToString("MM/dd/yyyy")
                            Dim ZZFechaOrd As String = ordenaFecha(ZZFecha)
                            Dim WXFecEntrega As String = WXFecha2
                            Dim WXOrdFecEntrega As String = ordenaFecha(WXFecEntrega)
                            Dim WFechaOriginal As String = ""

                            SQLCnslt4 = "SELECT Fecha FROM Pedido WHERE Pedido = '" & WPedido & "' ORDER BY Clave"

                            Dim Row_Pedido As DataRow = GetSingle(SQLCnslt4, "SurfactanSa")

                            If Row_Pedido IsNot Nothing Then
                                WFechaOriginal = Row_Pedido.Item("Fecha")
                            End If


                            SQLCnslt4 = "UPDATE Pedido SET " _
                                       & " MarcaAutorizacion = '" & "S" & "'," _
                                       & " Fecha = '" & ZZFecha & "'," _
                                       & " FechaOrd = '" & ZZFechaOrd & "'," _
                                       & " FecEntrega = '" & WXFecEntrega & "'," _
                                       & " OrdFecEntrega = '" & WXOrdFecEntrega & "'" _
                                       & " Where Pedido = '" & WPedido & "'"

                            ListaSQLCnslt.Add(SQLCnslt4)

                        End If



                    End If



                    Dim WX_TipoPedido As Integer = 0

                    SQLCnslt4 = "SELECT TipoPedido FROM Pedido WHERE Pedido = '" & WPedido & "' ORDER BY Clave"

                    Dim RowAux As DataRow = GetSingle(SQLCnslt4, "SurfactanSA")

                    If RowAux IsNot Nothing Then
                        WX_TipoPedido = RowAux.Item("TipoPedido")
                    End If

                    Select Case WX_TipoPedido
                        Case 1, 4
                            WMarca = "0"
                        Case Else
                            WMarca = "1"
                    End Select

                    SQLCnslt4 = "UPDATE Pedido SET Proceso1	= '" & WMarca & "' WHERE Pedido = '" & WPedido & "'"

                    ListaSQLCnslt.Add(SQLCnslt4)

                End If



                If DGV_Row.Cells("Estado").Value = "Anulado" Then


                    Dim SQLCnslt5 As String
                    Dim WPedido As String = DGV_Row.Cells("Pedido").Value
                    Dim WMarca As String = ""

                    Dim T As String = ""
                    Dim m As String = ""


                    If DGV_Row.Cells("Tipo").Value = "DEVOL" Then

                        

                        T = "Anulacion de la Solicitud de Devolucion"
                        m = "Confirma la anulacion de la Solcitud Nro.:" & WPedido

                        If MsgBox(m$, 32 + 4, T$) = 6 Then

                            'Muestra.Col = 1
                            'WPedido = Muestra.Text

                            WMarca = "X"
                            SQLCnslt5 = "UPDATE PedidoDevol SET " _
                                & "Autorizo = 'X', " _
                                & "Impresion = 'X', " _
                                & "Facturado = Cantidad " _
                                & "WHERE Pedido = '" & WPedido & "'"

                            ListaSQLCnslt.Add(SQLCnslt5)

                        End If

                    Else

                        If DGV_Row.Cells("Tipo").Value = "MUESTRA" Then


                            T = "Anulacion de Muestras"
                            m = "Confirma la anulacion de la Muestra Nro.:" & WPedido

                            If MsgBox(m$, 32 + 4, T$) = 6 Then

                                SQLCnslt5 = "DELETE Muestra WHERE Codigo = '" & WPedido & "'"

                                ListaSQLCnslt.Add(SQLCnslt5)

                            End If

                        Else

                            
                            

                            T = "Anulacion de Pedido"
                            m = "Confirma la anulacion del pedido Nro.:" & WPedido
                            If MsgBox(m$, 32 + 4, T$) = 6 Then




                                WMarca = "X"

                                SQLCnslt5 = "UPDATE  Pedido SET " _
                                    & "Autorizo = '" & WMarca & "', " _
                                    & "Impresion = '" & WMarca & "', " _
                                    & "Facturado = Cantidad " _
                                    & "WHERE Pedido = '" & WPedido & "'"
                                
                                WMarca = "0"

                                SQLCnslt5 = "UPDATE Pedido SET Proceso1	= '" & WMarca & "' WHERE Pedido = '" & WPedido & "'"

                                ListaSQLCnslt.Add(SQLCnslt5)
                            End If
                    End If
                End If

                End If


            Next

            'EJECTUTAMOS TODAS LAS MODIFICACIONES A LAS TABLAS
            ExecuteNonQueries("SurfactanSa", ListaSQLCnslt.ToArray())
        End If
    End Sub



    '
    '        If Muestra.Text = "Anulado" Then
    '
    '            Muestra.Col = 6
    '            If Muestra.Text = "DEVOL" Then
    '
    '                Muestra.Col = 1
    '                WPedido = Muestra.Text
    '
    '                T$ = "Anulacion de la Solicitud de Devolucion"
    '                m$ = "Confirma la anulacion de la Solcitud Nro.:" + Muestra.Text
    '                Respuesta% = MsgBox(m$, 32 + 4, T$)
    '                If Respuesta% = 6 Then
    '
    '                    Muestra.Col = 1
    '                    WPedido = Muestra.Text
    '
    '                    WMarca = "X"
    '                    XParam = "'" + WPedido + "'"
    '                    spPedidoDevol = "ModificaPedidoDevolAnulacion " + XParam
    '                    Set rstPedidoDevol = db.OpenRecordset(spPedidoDevol, dbOpenSnapshot, dbSQLPassThrough)
    '
    '                End If
    '
    '                    Else
    '
    '                If Muestra.Text = "MUESTRA" Then
    '
    '                    Muestra.Col = 1
    '                    WPedido = Muestra.Text
    '
    '                    T$ = "Anulacion de Muestras"
    '                    m$ = "Confirma la anulacion de la Muestra Nro.:" + Muestra.Text
    '                    Respuesta% = MsgBox(m$, 32 + 4, T$)
    '                    If Respuesta% = 6 Then
    '
    '                        Muestra.Col = 1
    '                        WPedido = Muestra.Text
    '
    '                        Sql1 = "DELETE Muestra"
    '                        Sql2 = " Where Codigo = " + "'" + WPedido + "'"
    '                        spMuestra = Sql1 + Sql2
    '                        Set rstMuestra = db.OpenRecordset(spMuestra, dbOpenSnapshot, dbSQLPassThrough)
    '
    '                    End If
    '
    '                        Else
    '
    '                    Muestra.Col = 1
    '                    WPedido = Muestra.Text
    '
    '                    T$ = "Anulacion de Pedido"
    '                    m$ = "Confirma la anulacion del pedido Nro.:" + Muestra.Text
    '                    Respuesta% = MsgBox(m$, 32 + 4, T$)
    '                    If Respuesta% = 6 Then
    '
    '                        Muestra.Col = 1
    '                        WPedido = Muestra.Text
    '
    '                        WMarca = "X"
    '                        XParam = "'" + WPedido + "'"
    '                        spPedido = "ModificaPedidoAnulacion " + XParam
    '                        Set rstPedido = db.OpenRecordset(spPedido, dbOpenSnapshot, dbSQLPassThrough)
    '
    '                        WMarca = "0"
    '                        XParam = "'" + WPedido + "','" _
    '                                + WMarca + "'"
    '                        spPedido = "ModificaPedidoProceso1 " + XParam
    '                        Set rstPedido = db.OpenRecordset(spPedido, dbOpenSnapshot, dbSQLPassThrough)
    '
    '                    End If
    '                End If
    '            End If
    '
    '        End If
    '
    '    Next Ciclo
    '
    '    Call cmdClose_Click
    'End If

    Private Sub btn_Autorizo_Click(sender As Object, e As EventArgs) Handles btn_Autorizo.Click
        If DGV_Pedidos.CurrentRow.Cells("Tipo").Value = "DEVOL" Then
            With New Ventana_Boton_Autorizo("DEVOL", DGV_Pedidos.CurrentRow.Cells("Clave").Value, DGV_Pedidos.CurrentRow.Cells("Pedido").Value)
                .Show(Me)
            End With
        Else
            With New Ventana_Boton_Autorizo("OTRO", DGV_Pedidos.CurrentRow.Cells("Clave").Value, DGV_Pedidos.CurrentRow.Cells("Pedido").Value, DGV_Pedidos.CurrentRow.Cells("Cliente").Value, DGV_Pedidos.CurrentRow.Cells("Razon").Value)
                .Show(Me)
            End With
        End If
    End Sub










    Private Sub btn_CERRAR_Click(sender As Object, e As EventArgs) Handles btn_CERRAR.Click
        Close()
    End Sub

    Private Sub DGV_Pedidos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Pedidos.CellClick
        DGV_Pedidos.CurrentRow.Selected = True
    End Sub

    Private Sub btn_AnulaPedido_Click(sender As Object, e As EventArgs) Handles btn_AnulaPedido.Click
        DGV_Pedidos.CurrentRow.Cells("Estado").Value = "Anulado"
    End Sub

    '    Public Sub CambiaAutorizado(ClavePedido As String,Optional FechaVto as String) Implements IAutorizacionDePedidos.CambiaAutorizado
    '
    '        
    '
    '    End Sub
    Public Sub CambiaAutorizado(ClavePedido As String, Optional FechaVto As String = "") Implements IAutorizacionDePedidos.CambiaAutorizado
        If FechaVto <> "" Then
            For Each DGV_Row As DataGridViewRow In DGV_Pedidos.Rows
                If DGV_Row.Cells("Clave").Value = ClavePedido Then

                    DGV_Row.Cells("Estado").Value = "Autorizado"
                    DGV_Row.Cells("Auxiliar2").Value = FechaVto
                End If
            Next
        Else
            For Each DGV_Row As DataGridViewRow In DGV_Pedidos.Rows
                If DGV_Row.Cells("Clave").Value = ClavePedido Then

                    DGV_Row.Cells("Estado").Value = "Autorizado"

                End If
            Next
        End If


    End Sub

    Public Sub CambiaAutorizadoChecks(ClavePedido As String, Inicial As String) Implements IAutorizacionDePedidos.CambiaAutorizadoChecks

        For Each DGV_Row As DataGridViewRow In DGV_Pedidos.Rows
            If DGV_Row.Cells("Clave").Value = ClavePedido Then

                DGV_Row.Cells("Estado").Value = "Autorizado"
                DGV_Row.Cells("Auxiliar1").Value = Inicial
            End If
        Next

    End Sub
End Class