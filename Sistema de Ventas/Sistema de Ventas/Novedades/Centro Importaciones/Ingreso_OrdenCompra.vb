Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Ingreso_OrdenCompra
    Dim WBASEACONECTAR As String = ""
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

    Sub New(Optional ByVal NumeroOrden As String = "", Optional ByVal NumeroCarpeta As String = "", Optional ByVal BaseConectar As String = "")


        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        With Tabla_Aux.Columns
            .Add("Articulo")
            .Add("PosArancel")
        End With



        If (NumeroCarpeta <> "" And NumeroOrden <> "" And BaseConectar <> "") Then

            WBaseAConectar = BaseConectar
            txt_Orden.Text = NumeroOrden
            txt_Carpeta.Text = NumeroCarpeta
            Dim Wclave As String = NumeroOrden.PadLeft(6, "0") & "01"


            DGV_Orden.Rows.Clear()


            Dim Renglon As Integer = 0

            Dim SQLCnlst As String = "SELECT o.Origen, o.Moneda, o.Tarjeta, o.Tipo, o.TipoPago, o.Leyenda, o.FechaImpo, " _
                                     & "o.Clave, o.PedidoImpo, o.TipoImpo, o.Flete, o.Fecha, o.Proveedor, o.Djai, " _
                                     & "o.FechaDjai, o.ARticulo, o.Cantidad, o.Precio, p.Nombre " _
                                     & "FROM Orden o INNER JOIN Proveedor p ON o.Proveedor = p.Proveedor " _
                                     & "WHERE o.Orden = '" & txt_Orden.Text & "' AND o.Carpeta = '" & txt_Carpeta.Text & "' " _
                                     & "ORDER BY o.Clave"


            Dim TablaOrden As DataTable = GetAll(SQLCnlst, BaseConectar)

            If TablaOrden.Rows.Count > 0 Then

                For Each RowOrden As DataRow In TablaOrden.Rows

                    If RowOrden.Item("Clave") = Wclave Then

                        With RowOrden
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

                    DGV_Orden.Rows(Renglon).Cells("Producto").Value = RowOrden.Item("Articulo")
                    DGV_Orden.Rows(Renglon).Cells("Cantidad").Value = formatonumerico(RowOrden.Item("Cantidad"))
                    DGV_Orden.Rows(Renglon).Cells("Precio").Value = formatonumerico(RowOrden.Item("Precio"))



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

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Orden.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click


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


        Dim ZZGraba As String = "N"

        If Trim(ZZOrigen) <> Trim(WORIGEN) Then
            ZZGraba = "S"
        End If
        If ZZLeyenda <> WLEYENDA Then
            ZZGraba = "S"
        End If
        If Trim(ZZPedidoImpo) <> Trim(WPEDIDOIMPO) Then
            ZZGraba = "S"
        End If
        If ZZFechaImpo <> WFECHAIMPO Then
            ZZGraba = "S"
        End If
        If ZZTipoImpo <> WTIPOIMPO Then
            ZZGraba = "S"
        End If
        If ZZTipoPago <> WTIPOPAGO Then
            ZZGraba = "S"
        End If
        If ZZFlete <> Val(WFLETE) Then
            ZZGraba = "S"
        End If
        If ZZDJai <> WDJAI Then
            ZZGraba = "S"
        End If
        If Trim(ZZFechaDJai) <> Trim(WFECHADJAI) Then
            ZZGraba = "S"
        End If


        If ZZGraba = "S" Then
            
            If MsgBox("Desea Guardar los cambios a la Orden de Compra ", vbYesNo) = vbYes Then

                Dim SQLCnslt As String = "UPDATE Orden SET " _
                & " DJai = '" & ZZDJai & "'," _
                & " FechaDJai = '" & ZZFechaDJai & "'," _
                & " Flete = '" & ZZFlete & "'," _
                & " Origen = '" & ZZOrigen & "'," _
                & " Leyenda = '" & ZZLeyenda & "'," _
                & " PedidoImpo = '" & ZZPedidoImpo & "'," _
                & " FechaImpo = '" & ZZFechaImpo & "'," _
                & " OrdFechaImpo = '" & ZZOrdFechaImpo & "'," _
                & " TipoImpo = '" & ZZTipoImpo & "'," _
                & " TipoPago = '" & ZZTipoPago & "'" _
                & " Where Orden = '" & txt_Orden.Text & "'"

                ExecuteNonQueries({SQLCnslt}, WBASEACONECTAR)
            End If

        End If

        For i = 0 To DGV_Orden.Rows.Count - 1
            If DGV_Orden.Rows(i).Cells("Producto").Value = Tabla_Aux.Rows(i).Item("Articulo") Then
                If DGV_Orden.Rows(i).Cells("PosicionArancelaria").Value <> Tabla_Aux.Rows(i).Item("PosArancel") Then
                    Dim SqlCnslt As String = "UPDATE Articulo SET " _
                                            & " Posarance = '" & DGV_Orden.Rows(i).Cells("PosicionArancelaria").Value & "'" _
                                            & " Where Codigo = '" & DGV_Orden.Rows(i).Cells("Producto").Value & "'"
                    ExecuteNonQueries({SqlCnslt}, Operador.Base)
                End If
            End If
        Next

        Close()
    End Sub
End Class