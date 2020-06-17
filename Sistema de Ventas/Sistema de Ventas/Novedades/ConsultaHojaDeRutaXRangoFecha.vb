Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaHojaDeRutaXRangoFecha

    Private Sub ConsultaHojaDeRutaXRangoFecha_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtFechaDesde.Focus()
    End Sub

    Private Sub txtFechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtFechaDesde.Text) = "S" Then
                    txtFechaHasta.Focus()
                End If
            Case Keys.Escape
                txtFechaDesde.Text = ""
        End Select
    End Sub

    Private Sub txtFechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtFechaHasta.Text) = "S" And ValidaFecha(txtFechaDesde.Text) = "S" Then
                    Cargar_DGV()
                End If
            Case Keys.Escape
                txtFechaHasta.Text = ""
        End Select
    End Sub

    Private Sub Cargar_DGV()
        'BORRO LO QUE ALLA CARGADO
        DGV_HojaRuta.DataSource = Nothing
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True

        Dim PosicionTabla As Integer = 0
        Dim tablaDGV As New DataTable
        With tablaDGV.Columns
            .Add("Hoja")
            .Add("Factura")
            .Add("Remito")
            .Add("Pedido")
            .Add("RazonSocial")
            .Add("Producto")
            .Add("Descripcion")
            .Add("Kilos")
            .Add("Cliente")
        End With

        Dim SQLCnslt As String = "SELECT Pedido, Cliente, Razon, Remito, Hoja " _
                                 & "FROM HojaRuta " _
                                 & "WHERE OrdFecha >= '" & ordenaFecha(txtFechaDesde.Text) & "' AND OrdFecha <= '" & ordenaFecha(txtFechaHasta.Text) & "' " _
                                 & "Order by Clave"
        Dim tablaDatos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If tablaDatos.Rows.Count > 0 Then
            With tablaDatos.Columns
                .Add("Factura")
                .Add("TipoPedido")
            End With


            For Each Row As DataRow In tablaDatos.Rows

                Row.Item("Factura") = 0

                SQLCnslt = "SELECT Remito, TipoPedido FROM Pedido WHERE Pedido = '" & Row.Item("Pedido") & "'"
                Dim RowPEDIDO As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowPEDIDO IsNot Nothing Then
                    ' Row.Item("Remito") = IIf(IsDBNull(RowPEDIDO.Item("Remito")), "", RowPEDIDO.Item("Remito"))
                    Row.Item("Remito") = IIf(IsDBNull(RowPEDIDO.Item("Remito")), "0", RowPEDIDO.Item("Remito"))
                    Row.Item("TipoPedido") = IIf(IsDBNull(RowPEDIDO.Item("TipoPedido")), "0", RowPEDIDO.Item("TipoPedido"))
                End If


                SQLCnslt = "SELECT Pedido, Remito, Numero FROM CtaCte " _
                         & "WHERE Pedido = '" & Row.Item("Pedido") & "'"
                Dim TablaCtaCte As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If TablaCtaCte.Rows.Count > 0 Then
                    For Each RowCtaCte As DataRow In TablaCtaCte.Rows
                        If Val(Row.Item("Remito")) = Val(RowCtaCte.Item("Remito")) Then
                            Row.Item("Factura") = RowCtaCte.Item("Numero")
                        End If
                    Next
                End If

                If Val(Row.Item("Factura")) <> 0 Then

                    SQLCnslt = "SELECT Numero, Cliente, Articulo, Cantidad FROM Estadistica " _
                            & "WHERE Numero = '" & Row.Item("Factura") & "' AND Cliente = '" & Row.Item("Cliente") & "'"

                    Dim tablaEstadistica As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                    If tablaEstadistica.Rows.Count > 0 Then
                        For Each RowEstadistica As DataRow In tablaEstadistica.Rows
                            tablaDGV.Rows.Add()
                            tablaDGV(PosicionTabla).Item("Hoja") = Row.Item("Hoja")
                            tablaDGV(PosicionTabla).Item("Factura") = Row.Item("Factura")
                            If Row.Item("Remito") = 0 Then
                                tablaDGV(PosicionTabla).Item("Remito") = ""
                            Else
                                tablaDGV(PosicionTabla).Item("Remito") = Row.Item("Remito")
                            End If
                            tablaDGV(PosicionTabla).Item("Pedido") = Row.Item("Pedido")
                            tablaDGV(PosicionTabla).Item("RazonSocial") = Row.Item("Razon")
                            If UCase(Microsoft.VisualBasic.Left(RowEstadistica.Item("Articulo"), 2)) <> "PT" Then
                                tablaDGV(PosicionTabla).Item("Producto") = UCase(Microsoft.VisualBasic.Left(RowEstadistica.Item("Articulo"), 3)) & Microsoft.VisualBasic.Right(RowEstadistica.Item("Articulo"), 7)
                            Else
                                tablaDGV(PosicionTabla).Item("Producto") = RowEstadistica.Item("Articulo")
                            End If
                            ' tablaDGV(PosicionTabla).Item("Producto") = RowEstadistica.Item("Articulo")
                            tablaDGV(PosicionTabla).Item("Descripcion") = ""
                            tablaDGV(PosicionTabla).Item("Kilos") = formatonumerico(RowEstadistica.Item("Cantidad"), 3)
                            tablaDGV(PosicionTabla).Item("Cliente") = Row.Item("Cliente")

                            PosicionTabla += 1
                            ProgressBar1.Value += 1
                        Next
                    End If

                Else
                    Dim WCantidad1, WCantidad2, WCantidad3, WCantidad4, WCantidad5, WCantidadFac, WSumaCantidad, WKilos As String


                    SQLCnslt = "SELECT Pedido, CantiLote1, CantiLote2, CantiLote3, CantiLote4, CantiLote5, Cantidad, Terminado, CantidadFac " _
                             & "FROM Pedido WHERE Pedido = '" & Row.Item("Pedido") & "'"

                    Dim tablaPedido As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                    If tablaPedido.Rows.Count > 0 Then
                        For Each RowPed As DataRow In tablaPedido.Rows
                            WCantidad1 = IIf(IsDBNull(RowPed.Item("CantiLote1")), "0", RowPed.Item("CantiLote1"))
                            WCantidad2 = IIf(IsDBNull(RowPed.Item("CantiLote2")), "0", RowPed.Item("CantiLote2"))
                            WCantidad3 = IIf(IsDBNull(RowPed.Item("CantiLote3")), "0", RowPed.Item("CantiLote3"))
                            WCantidad4 = IIf(IsDBNull(RowPed.Item("CantiLote4")), "0", RowPed.Item("CantiLote4"))
                            WCantidad5 = IIf(IsDBNull(RowPed.Item("CantiLote5")), "0", RowPed.Item("CantiLote5"))
                            WCantidadFac = IIf(IsDBNull(RowPed.Item("CantidadFac")), "0", RowPed.Item("CantidadFac"))
                            WSumaCantidad = Val(WCantidad1) + Val(WCantidad2) + Val(WCantidad3) + Val(WCantidad4) + Val(WCantidad5)

                            If Val(WSumaCantidad) = 0 Then
                                WSumaCantidad = WCantidadFac
                            End If
                            If Val(WSumaCantidad) <> 0 Then
                                WKilos = WSumaCantidad
                            Else
                                WKilos = RowPed.Item("Cantidad")
                            End If

                            tablaDGV.Rows.Add()
                            tablaDGV(PosicionTabla).Item("Hoja") = Row.Item("Hoja")
                            tablaDGV(PosicionTabla).Item("Factura") = ""
                            If Row.Item("Remito") = 0 Then
                                tablaDGV(PosicionTabla).Item("Remito") = ""
                            Else
                                tablaDGV(PosicionTabla).Item("Remito") = Row.Item("Remito")
                            End If
                            tablaDGV(PosicionTabla).Item("Pedido") = Row.Item("Pedido")
                            tablaDGV(PosicionTabla).Item("RazonSocial") = Row.Item("Razon")
                            If UCase(Microsoft.VisualBasic.Left(RowPed.Item("Terminado"), 2)) <> "PT" Then
                                tablaDGV(PosicionTabla).Item("Producto") = UCase(Microsoft.VisualBasic.Left(RowPed.Item("Terminado"), 3)) & Microsoft.VisualBasic.Right(RowPed.Item("Terminado"), 7)
                            Else
                                tablaDGV(PosicionTabla).Item("Producto") = RowPed.Item("Terminado")
                            End If
                            tablaDGV(PosicionTabla).Item("Descripcion") = ""
                            tablaDGV(PosicionTabla).Item("Kilos") = formatonumerico(WKilos, 3)
                            tablaDGV(PosicionTabla).Item("Cliente") = Row.Item("Cliente")

                            PosicionTabla += 1
                            ProgressBar1.Value += 1

                        Next

                    End If


                End If

            Next


            For Each Row_DGV As DataRow In tablaDGV.Rows
                Dim Cliente As String = Row_DGV.Item("Cliente")
                Dim Producto As String = Row_DGV.Item("Producto")
                Dim WTipoPro As String = "T"

                If UCase(Microsoft.VisualBasic.Left(Producto, 2)) <> "PT" Then
                    WTipoPro = "M"
                End If

                Select Case WTipoPro
                    Case "M"
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Producto & "'"
                        Dim RowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                        If RowArticulo IsNot Nothing Then
                            Row_DGV.Item("Descripcion") = RowArticulo.Item("Descripcion")
                        End If
                    Case "T"
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & Producto & "'"
                        Dim RowTerminado As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                        If RowTerminado IsNot Nothing Then
                            Row_DGV.Item("Descripcion") = RowTerminado.Item("Descripcion")
                        End If
                End Select

            Next
            ProgressBar1.Value = 1000
            DGV_HojaRuta.DataSource = tablaDGV

            ProgressBar1.Visible = False
        End If
    End Sub





    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        Dim Tablafiltro As DataTable = DGV_HojaRuta.DataSource
        Tablafiltro.DefaultView.RowFilter = "RazonSocial LIKE '%" & txtFiltro.Text & "%' OR Producto LIKE '%" & txtFiltro.Text & "%' OR Descripcion LIKE '%" & txtFiltro.Text & "%'"
    End Sub

    Private Sub DGV_HojaRuta_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_HojaRuta.CellMouseDoubleClick
        Dim WOwner As IHojaDeRuta = TryCast(Owner, IHojaDeRuta)
        If WOwner IsNot Nothing Then
            WOwner.CargarHojaDeRuta(DGV_HojaRuta.CurrentRow.Cells("Hoja").Value)
        End If

    End Sub

   
End Class