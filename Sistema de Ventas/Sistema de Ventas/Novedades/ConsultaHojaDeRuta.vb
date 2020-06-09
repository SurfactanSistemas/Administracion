Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class ConsultaHojaDeRuta

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

        Dim SQLCnslt As String = "SELECT hr.Hoja, hr.Renglon, hr.Fecha, hr.Chofer, hr.Camion, hr.Pedido, hr.Cliente," _
                    & " hr.Remito, hr.Seguridad, hr.Kilos, hr.ObservaI, hr.ObservaII, hr.Bultos, hr.Razon," _
                    & " c.Descripcion, c.patente, ch.Descripcion FROM Camion c RIGHT JOIN  hojaruta hr" _
                    & " ON c.Codigo  = hr.Camion left join chofer ch on hr.Chofer = ch.Codigo WHERE hr.Hoja = '" & txtNroHoja.Text & "'"
        With New VistaPrevia
            .Reporte = New hojarutacotnuevo()
            .Formula = SQLCnslt
            .Mostrar()
        End With
        '  DbConnect = db.Connect
        '  DSQ = getDatabase(DbConnect)
        '
        '  Listado.SQLQuery = "SELECT HojaRuta.Hoja, HojaRuta.Renglon, HojaRuta.Fecha, HojaRuta.Chofer, HojaRuta.Camion, HojaRuta.Pedido, HojaRuta.Cliente, HojaRuta.Remito, HojaRuta.Seguridad, HojaRuta.Kilos, HojaRuta.ObservaI, HojaRuta.ObservaII, HojaRuta.Bultos, HojaRuta.Razon, " _
        '          + "Chofer.Descripcion, " _
        '          + "Camion.Descripcion, Camion.Patente " _
        '          + "From " _
        '          + DSQ + ".dbo.HojaRuta HojaRuta, " _
        '          + DSQ + ".dbo.Chofer Chofer, " _
        '          + DSQ + ".dbo.Camion Camion " _
        '          + "Where " _
        '          + "HojaRuta.Chofer = Chofer.Codigo AND " _
        '          + "HojaRuta.Camion = Camion.Codigo AND " _
        '          + "HojaRuta.Hoja >= " + Hoja.Text + " AND " _
        '          + "HojaRuta.Hoja <= " + Hoja.Text
        '
        '  Listado.Connect = Connect()
        '
        '  Listado.GroupSelectionFormula = "{HojaRuta.Hoja} in " + Hoja.Text + " to " + Hoja.Text
        '  Listado.SelectionFormula = "{HojaRuta.Hoja} in " + Hoja.Text + " to " + Hoja.Text
        '
        '  Listado.Destination = 1
        '  REM Listado.Destination = 0
        '
        '  If Val(WEmpresa) = 1 Then
        '      Listado.ReportFileName = "HojaRuta.rpt"
        '  Else
        '      Listado.ReportFileName = "HojaRutapelli.rpt"
        '  End If
        '
        '  Listado.Action = 1
    End Sub
End Class