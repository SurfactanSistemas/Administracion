Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaHojaDeRuta : Implements IHojaDeRuta

    Private Sub txtNroHoja_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroHoja.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = "SELECT Hoja FROM HojaRuta WHERE Hoja = '" & txtNroHoja.Text & "'"
                Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tabla.Rows.Count > 0 Then
                    Dim Auxiliar As String = txtNroHoja.Text
                    btnLimpiar_Click(Nothing, Nothing)
                    txtNroHoja.Text = Auxiliar
                    CargarGrilla()
                End If

            Case Keys.Escape
                txtNroHoja.Text = ""
        End Select
    End Sub



    Sub CargarGrilla()
        Dim SQLCnslt As String = "SELECT Fecha, Chofer, Camion, NroViaje, RetiraProv, Pedido, Cliente, Razon, " _
                                 & "Remito, Kilos, Seguridad, Comprobante, Clave, Integridad, Archivo " _
                                 & "FROM HojaRuta WHERE Hoja = '" & txtNroHoja.Text & "' ORDER BY Clave"
        Dim TablaHoja As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaHoja.Rows.Count > 0 Then
            For Each Row As DataRow In TablaHoja.Rows
                txtFecha.Text = Row.Item("Fecha")
                txtCamion.Text = Row.Item("Camion")
                txtChofer.Text = Row.Item("Chofer")
                txtNroViaje.Text = IIf(IsDBNull(Row.Item("NroViaje")), "", Row.Item("NroViaje"))
                txtRetiraProv.Text = IIf(IsDBNull(Row.Item("RetiraProv")), "", Row.Item("RetiraProv"))
                With Row
                    Dim Array1(3) As String
                    Dim Array2(2) As String
                    Array1 = BuscarDireccionesCliente(.Item("Pedido"), .Item("Cliente"))
                    Array2 = ValorCuentaCorriente(.Item("Pedido"), .Item("Remito"))


                    'If Array1(2) = "" Then
                    '    Array1(2) = Row.Item("Remito")
                    'End If


                    Dim ValorKilos As Double
                    If Val(Array2(1)) <> 0 Then
                        ValorKilos = Val(Array2(1))
                    Else
                        ValorKilos = Val(.Item("Kilos"))
                    End If

                    DGV_HojaRuta.Rows.Add(.Item("Pedido"), .Item("Cliente"), .Item("Razon"),
                                              Array1(2), ValorKilos, formatonumerico(Array2(0), 2),
                                              .Item("Seguridad"), Array1(0), Array1(1),
                                              IIf(IsDBNull(Row.Item("Comprobante")), "", Row.Item("Comprobante")), .Item("Clave"),
                                              IIf(IsDBNull(Row.Item("integridad")), "", Row.Item("Integridad")),
                                              IIf(IsDBNull(Row.Item("Archivo")), "", Row.Item("Archivo")))

                End With
            Next
            SQLCnslt = "SELECT Descripcion FROM Camion WHERE Codigo = '" & txtCamion.Text & "'"
            Dim rowCamion As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowCamion IsNot Nothing Then
                txtCamionDesc.Text = rowCamion.Item("Descripcion")
            End If

            SQLCnslt = "SELECT Descripcion FROM Chofer WHERE Codigo = '" & txtChofer.Text & "'"
            Dim rowChofer As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowChofer IsNot Nothing Then
                txtChoferDesc.Text = rowChofer.Item("Descripcion")
            End If

            '
            '   Call Calcula_Click
            '
            CalcularTotales()


        End If
    End Sub

    Private Function ValorCuentaCorriente(ByVal Pedido As String, ByVal Remito As String) As Object
        Dim SQlCnslt As String = "SELECT Total, Remito, Numero, Tipo FROM CtaCte WHERE Pedido = '" & Pedido & "'"
        Dim Tabla As DataTable = GetAll(SQlCnslt, "SurfactanSa")
        Dim RespuestaArray(2) As String


        If Tabla.Rows.Count > 0 Then
            Dim Suma As Double = 0
            For Each row As DataRow In Tabla.Rows
                If Val(Remito) = Val(row.Item("Remito")) Then
                    RespuestaArray(0) = row.Item("Total")
                    If Val(row.Item("Numero")) <> 0 Then

                        SQlCnslt = "SELECT Cantidad FROM Estadistica WHERE Tipo = '" & row.Item("Tipo") & "' AND Numero = '" & row.Item("Numero") & "'"
                        Dim tablaEstadistica As DataTable = GetAll(SQlCnslt, "SurfactanSa")
                        If tablaEstadistica.Rows.Count > 0 Then
                            For Each rowEstadistica As DataRow In tablaEstadistica.Rows
                                Suma = Suma + Val(rowEstadistica.Item("Cantidad"))
                            Next
                            RespuestaArray(1) = Suma
                        End If
                    End If
                End If
            Next


        End If

        Return RespuestaArray
    End Function

    Private Sub CalcularTotales()
        Dim TotalKilos As Double = 0
        Dim TotalPesos As Double = 0
        For Each row As DataGridViewRow In DGV_HojaRuta.Rows
            TotalPesos = TotalPesos + Val(row.Cells("Pesos").Value)
            TotalKilos = TotalKilos + Val(row.Cells("Kilos").Value)
        Next
        txtTotalKilos.Text = formatonumerico(TotalPesos.ToString(), 2)
        txtTotalPesos.Text = formatonumerico(TotalKilos.ToString(), 2)
    End Sub
    Private Function DevuelveProvincia(ByVal NumeroProv As Integer) As String
        Dim Provincia(26) As String
        Provincia(0) = "Capital"
        Provincia(1) = "Bs.As"
        Provincia(2) = "Catamarca"
        Provincia(3) = "Cordoba"
        Provincia(4) = "Corrientes"
        Provincia(5) = "Chaco"
        Provincia(6) = "Chubut"
        Provincia(7) = "Entre Rios"
        Provincia(8) = "Formosa"
        Provincia(9) = "Jujuy"
        Provincia(10) = "La Pampa"
        Provincia(11) = "La Rioja"
        Provincia(12) = "Mendoza"
        Provincia(13) = "Misiones"
        Provincia(14) = "Neuquen"
        Provincia(15) = "Rio Negro"
        Provincia(16) = "Salta"
        Provincia(17) = "San Juan"
        Provincia(18) = "San Luis"
        Provincia(19) = "Santa Cruz"
        Provincia(20) = "Santa Fe"
        Provincia(21) = "Santiago del Estero"
        Provincia(22) = "Tucuman"
        Provincia(23) = "Tierra del Fuego"
        Provincia(24) = "Exterior"
        Provincia(25) = ""
        Return Provincia(NumeroProv)
    End Function

    Private Function BuscarDireccionesCliente(ByVal Pedido As String, ByVal Cliente As String) As Object
        Dim RespuestaArray(3) As String
        Dim SQLCnlst As String = "SELECT Provincia, DirEntrega, DirEntregaII, DirEntregaIII, DirEntregaIV, DirEntregaV " _
                                 & "FROM Cliente WHERE Cliente = '" & Cliente & "'"
        Dim row As DataRow = GetSingle(SQLCnlst, "SurfactanSa")
        Dim WDireccionEntregaArray(6) As String
        If row IsNot Nothing Then
            RespuestaArray(0) = DevuelveProvincia(row.Item("Provincia"))

            WDireccionEntregaArray(1) = row.Item("DirEntrega")
            WDireccionEntregaArray(2) = Trim(IIf(IsDBNull(row.Item("DirEntregaII")), "", row.Item("DirEntregaII")))
            WDireccionEntregaArray(3) = Trim(IIf(IsDBNull(row.Item("DirEntregaIII")), "", row.Item("DirEntregaIII")))
            WDireccionEntregaArray(4) = Trim(IIf(IsDBNull(row.Item("DirEntregaIV")), "", row.Item("DirEntregaIV")))
            WDireccionEntregaArray(5) = Trim(IIf(IsDBNull(row.Item("DirEntregaV")), "", row.Item("DirEntregaV")))
        End If




        SQLCnlst = "SELECT DirEntrega, Remito FROM Pedido WHERE Pedido = '" & Pedido & "' ORDER BY Remito DESC"
        Dim rowPedido As DataRow = GetSingle(SQLCnlst, "SurfactanSa")

        If rowPedido IsNot Nothing Then
            RespuestaArray(1) = WDireccionEntregaArray(IIf(IsDBNull(rowPedido.Item("DirEntrega")), 1, rowPedido.Item("DirEntrega")))
            RespuestaArray(2) = IIf(IsDBNull(rowPedido.Item("Remito")), "", rowPedido.Item("Remito"))
        End If


        Return RespuestaArray


    End Function









    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNroHoja.Text = ""
        txtFecha.Text = ""
        txtTotalPesos.Text = ""
        txtTotalKilos.Text = ""
        txtChofer.Text = ""
        txtChoferDesc.Text = ""
        txtCamion.Text = ""
        txtCamionDesc.Text = ""
        txtNroViaje.Text = ""
        txtRetiraProv.Text = ""
        DGV_HojaRuta.Rows.Clear()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim SQLCnslt As String
        Dim tabla As New DataTable
        With tabla.Columns
            .Add("Pedido")
            .Add("Cliente")
            .Add("Razon")
            .Add("Remito")
            .Add("Kilos")
            .Add("Pesos")
            .Add("Clase")
            .Add("Provincia")
            .Add("Direccion")
            .Add("Comprobante")
            .Add("Clave")
            .Add("Integridad")
            .Add("Articulo")
            .Add("Cuit")
            .Add("Postal")
            .Add("Factura")
            .Add("CodigoArticulo")
            .Add("Punto")
        End With
        'Paso los valores del DGV a la tabla
        For Each DGV_Row As DataGridViewRow In DGV_HojaRuta.Rows
            With DGV_Row
                tabla.Rows.Add(
                    .Cells("Pedido").Value,
                    .Cells("Cliente").Value, .Cells("Razon").Value,
                    .Cells("Remito").Value, .Cells("Kilos").Value,
                    .Cells("Pesos").Value, .Cells("Clase").Value,
                    .Cells("Provincia").Value, .Cells("Direccion").Value,
                    .Cells("Comprobante").Value, .Cells("Clave").Value,
                    .Cells("Integridad").Value, .Cells("Archivo").Value,
                    "",
                    "",
                    "",
                    "",
                    "")
            End With
        Next

        For Each Row As DataRow In tabla.Rows
            SQLCnslt = "SELECT Cuit, Postal FROM Cliente WHERE Cliente = '" & Row.Item("Cliente") & "'"
            Dim rowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowCliente IsNot Nothing Then
                Row.Item("Cuit") = rowCliente.Item("Cuit")
                Row.Item("Postal") = rowCliente.Item("Postal")
            End If

            SQLCnslt = "SELECT Remito, Numero FROM CtaCte WHERE Pedido = '" & Row.Item("Pedido") & "' Order by OrdFecha DESC"
            Dim tablaCtaCte As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If tablaCtaCte.Rows.Count > 0 Then
                For Each RowCtaCte As DataRow In tablaCtaCte.Rows
                    If Val(RowCtaCte.Item("Remito")) = Val(Row.Item("Remito")) Then
                        Row.Item("Factura") = RowCtaCte.Item("Numero")
                    End If
                Next
            End If

            SQLCnslt = " SELECT TipoPedido FROM Pedido WHERE Pedido = '" & Row.Item("Pedido") & "'"
            Dim RowPedido As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowPedido IsNot Nothing Then
                Select Case RowPedido.Item("TipoPedido")
                    Case 1
                        'WTipoPedido = "CO"
                        Row.Item("CodigoArticulo") = "320411"
                        Row.Item("Punto") = "1"
                    Case 3
                        ' WTipoPedido = "BI"
                        Row.Item("CodigoArticulo") = "340391"
                        Row.Item("Punto") = "4"
                    Case 4
                        '  WTipoPedido = "FA"
                        Row.Item("CodigoArticulo") = "291815"
                        Row.Item("Punto") = "3"
                    Case 5
                        ' WTipoPedido = "PG"
                        Row.Item("CodigoArticulo") = "340391"
                        Row.Item("Punto") = "1"
                    Case Else
                        ' WTipoPedido = "PT"
                        Row.Item("CodigoArticulo") = "340391"
                        Row.Item("Punto") = "4"
                End Select
            End If


            SQLCnslt = "UPDATE HojaRuta SET Remito = '" & Row.Item("Remito") & "', " _
                & "Kilos = '" & Row.Item("Kilos") & "', " _
                & "Pesos = '" & Row.Item("Pesos") & "', " _
                & "Razon = '" & Row.Item("Razon") & "', " _
                & "Cuit = '" & Row.Item("Cuit") & "', " _
                & "Postal = '" & Row.Item("Postal") & "', " _
                & "Direccion = '" & Row.Item("Direccion") & "', " _
                & "Factura = '" & Row.Item("Factura") & "', " _
                & "Punto = '" & Row.Item("Punto") & "', " _
                & "Provincia = '" & Row.Item("Provincia") & "', " _
                & "CodigoArticulo = '" & Row.Item("CodigoArticulo") & "' " _
                & "WHERE Clave = '" & Row.Item("Clave") & "'"

            ExecuteNonQueries("SurfactanSa", {SQLCnslt})

        Next


        Dim Formula As String = "{HojaRuta.Hoja} = " & txtNroHoja.Text & ""
        With New VistaPrevia
            .Reporte = New hojarutacotnuevo()
            .Formula = Formula
            .Mostrar()
        End With

    End Sub

    Private Sub btnBuscarFecha_Click(sender As Object, e As EventArgs) Handles btnBuscarFecha.Click
        With ConsultaHojaDeRutaXRangoFecha
            .Show(Me)
        End With
    End Sub

    Public Sub CargarHojaDeRuta(Hoja As String) Implements IHojaDeRuta.CargarHojaDeRuta
        txtNroHoja.Text = Hoja
        txtNroHoja_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub


End Class