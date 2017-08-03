Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class DAORecibo

    Public Shared Function existeReciboProvisorio(ByVal codigo As String)
        Dim tabla As DataTable = SQLConnector.retrieveDataTable("get_recibo_provisorio_sin_numero", codigo)
        Return tabla.Rows.Count = 0

        'Return SQLConnector.checkIfExists("get_recibo_provisorio_sin_numero", codigo)
    End Function

    Public Shared Function permiteActualizacionProvisorio(ByVal codigo As String)
        Dim existencia As Integer = SQLConnector.executeProcedureWithReturnValue("permite_actualizacion", codigo)
        Return existencia = 1
    End Function

    Public Shared Sub eliminarReciboProvisorio(ByVal codigo As String)
        SQLConnector.executeProcedure("baja_recibo_provisorio", codigo)
    End Sub

    Public Shared Function existeRecibo(ByVal codigo As String)
        Dim tabla As DataTable = SQLConnector.retrieveDataTable("get_recibo", codigo)
        Return tabla.Rows.Count = 0

        'Return SQLConnector.checkIfExists("get_recibo", codigo)
    End Function

    Public Shared Sub agregarRecibo(ByVal recibo As Recibo)
        Dim renglon As Integer = 1
        For Each formaPago As FormaPago In recibo.formasPago
            SQLConnector.executeProcedure("alta_recibo_forma_pago", recibo.codigo, ceros(renglon, 2), recibo.codigoCliente, recibo.fecha,
                                        recibo.retGanancias, recibo.retIVA, recibo.retIB, recibo.retSuss, ceros(formaPago.tipo, 2),
                                        formaPago.numero, formaPago.fecha, formaPago.nombre, formaPago.importe, recibo.total,
                                        recibo.paridad, recibo.observaciones, recibo.tipo, recibo.cuenta)
            renglon += 1
        Next
        renglon = 1
        For Each pago As Pago In recibo.pagos
            SQLConnector.executeProcedure("alta_recibo_pago", recibo.codigo, ceros(renglon, 2), recibo.codigoCliente, recibo.fecha,
                                        recibo.retGanancias, recibo.retIVA, recibo.retIB, recibo.retSuss, ceros(pago.tipo, 2),
                                        pago.letra, pago.punto, pago.numero, pago.importe, recibo.total,
                                        recibo.paridad, recibo.observaciones, recibo.tipo, recibo.cuenta)
            renglon += 1
        Next
    End Sub

    Public Shared Sub actualizarReciboProvisorio(ByVal codProvisorio As String, ByVal codRecibo As String)
        SQLConnector.executeProcedure("actualizar_recibo_provisorio", codProvisorio, codRecibo)
    End Sub

    Public Shared Sub agregarReciboProvisorio(ByVal id As String, ByVal fecha2 As String, ByVal cli As Cliente, ByVal tipoRec As Integer, ByVal ganancias As String, ByVal IB As String, ByVal IVA As String,
        ByVal Suss As String, ByVal valorParidad As String, ByVal valorTotal As String, ByVal FormasDePago As List(Of FormaPago), ByVal CompGanancias As String, ByVal CompIva As String,
        ByVal CompSuss As String, ByVal RetIB1 As String, ByVal CompIB1 As String, ByVal RetIB2 As String, ByVal CompIB2 As String, ByVal RetIB3 As String,
        ByVal CompIB3 As String, ByVal RetIB4 As String, ByVal CompIB4 As String, ByVal RetIB5 As String, ByVal CompIB5 As String, ByVal RetIB6 As String,
        ByVal CompIB6 As String, ByVal RetIB7 As String, ByVal CompIB7 As String, ByVal RetIB8 As String, ByVal CompIB8 As String, ByVal _cheques As List(Of Object))

        Dim renglon As Integer = 1
        Dim estado2 As Char = ""
        Dim _fechaord2 As String = ""
        Dim _fechaord As String() = fecha2.Split("/")
        Dim ConsultaSQL_Template As String = "('#CLAVE#', '" & id & "', '#RENGLON#', '" & cli.id & "', '" & fecha2 & "','" & _fechaord(2).ToString() & _fechaord(1).ToString() & _fechaord(0).ToString() & "', '#TIPOREC#', " & ganancias & ", '" & CompGanancias & "'," & IVA & ", '" & CompIva & "'," & IB & ", " & Suss & ", '" & CompSuss & "',0,2, '#TIPO#', '#NUMERO2#', '#FECHA2#', '#FECHAORD2#', '#BANCO2#', #IMPORTE2#, " & valorTotal & ", 1, 0, '', '', '#ESTADO2#', " & RetIB1.ToString() & ", " & CompIB1.ToString() & ", " & RetIB2.ToString() & ", " & CompIB2.ToString() & ", " & RetIB3.ToString() & ", " _
                                        & CompIB3.ToString() & ", " & RetIB4.ToString() & ", " & CompIB4.ToString() & ", " & RetIB5.ToString() & ", " & CompIB5.ToString() & ", " & RetIB6.ToString() & ", " & CompIB6.ToString() & ", " & RetIB7.ToString() & ", " & CompIB7.ToString() & ", " & RetIB8.ToString() & ", " & CompIB8.ToString() _
                                        & ", '#FechaDepo#', '#FechaDepoOrd#', '#ClaveCheque#', '#BancoCheque#', '#SucursalCheque#', '#ChequeCheque#', '#CuentaCheque#', '#Cuit#', '0')"



        Dim SQL As String = ""
        Dim _tipoRec As String = ""

        Select Case tipoRec
            Case 1
                _tipoRec = "1"
            Case 2
                _tipoRec = "2"
            Case Else
                _tipoRec = "3"
        End Select


        ' Concatenamos todos los renglones a insertar con el fin de realizar una única llamada a la BD.
        For Each formaPago As FormaPago In FormasDePago
            If (Convert.ToInt32(formaPago.tipo) = 2) Then
                estado2 = "P"
            ElseIf (Convert.ToInt32(formaPago.tipo) = 1) Or (Convert.ToInt32(formaPago.tipo) = 4) Then
                estado2 = "X"
            Else
                estado2 = ""
            End If

            _fechaord2 = String.Join("", formaPago.fecha.Split("/").Reverse())

            Dim temp As String = ""

            temp &= ConsultaSQL_Template _
                .Replace("#TIPOREC#", _tipoRec) _
                .Replace("#CLAVE#", id + ceros(renglon, 2)) _
                .Replace("#RENGLON#", ceros(renglon, 2)) _
                .Replace("#TIPO#", formaPago.tipo) _
                .Replace("#NUMERO2#", formaPago.numero) _
                .Replace("#FECHA2#", formaPago.fecha) _
                .Replace("#FECHAORD2#", _fechaord2) _
                .Replace("#BANCO2#", formaPago.nombre) _
                .Replace("#IMPORTE2#", Val(formaPago.importe).ToString.Replace(",", ".")) _
                .Replace("#ESTADO2#", estado2) _
                .Replace("#FechaDepo#", "") _
                .Replace("#FechaDepoOrd#", "")

            Dim _cheque As Object = _cheques.FindLast(Function(c) c(0) = (renglon - 1))

            If Not IsNothing(_cheque) Then
                temp = temp.Replace("#ClaveCheque#", _Left(_cheque(1), 31)) _
                            .Replace("#BancoCheque#", _Left(_cheque(2), 3)) _
                            .Replace("#SucursalCheque#", _Left(_cheque(3), 3)) _
                            .Replace("#ChequeCheque#", _Left(_cheque(4), 8)) _
                            .Replace("#CuentaCheque#", _Left(_cheque(5), 11)) _
                            .Replace("#Cuit#", _Left(_cheque(6), 15)) & ","
            Else
                temp = temp.Replace("#ClaveCheque#", "") _
                            .Replace("#BancoCheque#", "") _
                            .Replace("#SucursalCheque#", "") _
                            .Replace("#ChequeCheque#", "") _
                            .Replace("#CuentaCheque#", "") _
                            .Replace("#Cuit#", "") & ","
            End If

            SQL &= temp

            renglon += 1
        Next

        If Trim(SQL) <> "" Then
            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand()

            SQL = SQL.Substring(0, SQL.Length - 1) ' Quitamos la ultima ',' de la lista de valores.
            cm.CommandText = "INSERT INTO RecibosProvi(Clave, Recibo, Renglon, Cliente, Fecha," _
                        & "Fechaord, TipoRec, RetGanancias,ComproGanan, RetIva, ComproIva, RetOtra," _
                        & "RetSuss, ComproSuss, Retencion, TipoReg, Tipo2, Numero2, Fecha2, FechaOrd2," _
                        & "banco2, Importe2, Importe, Empresa, Impolist, Observaciones, Cuenta," _
                        & "Estado2, RetIb1, NroRetIb1, RetIb2, NroRetIb2, RetIb3, NroRetIb3, RetIb4, NroRetIb4," _
                        & "RetIb5, NroRetIb5, RetIb6, NroRetIb6, RetIb7, NroRetIb7, RetIb8, NroRetIb8, FechaDepo, FechaDepoOrd," _
                        & "ClaveCheque, BancoCheque, SucursalCheque, ChequeCheque, CuentaCheque, Cuit, ReciboDefinitivo) VALUES " & SQL
            SQLConnector.conexionSql(cn, cm)

            Try

                cm.ExecuteNonQuery()

            Catch ex As Exception
                Throw New Exception("Hubo un problema al querer guardar el Recibo Provisorio")
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    Private Shared Function _Left(ByVal texto As String, ByVal largo As Integer) As String
        Return Mid(texto, 1, largo)
    End Function

    Private Shared Function crearFormaPago(ByVal rowA As DataRow)
        Return New FormaPago(rowA("Tipo2").ToString, 0, rowA("Numero2").ToString, rowA("Fecha2").ToString, rowA("banco2").ToString,
                            asDouble(rowA("Importe2")))
    End Function

    Private Shared Function crearPago(ByVal rowA As DataRow)
        Return New Pago(rowA("Tipo1").ToString, rowA("Letra1").ToString, rowA("Punto1").ToString, rowA("Numero1").ToString,
                        "", asDouble(rowA("Importe1")))
    End Function

    Public Shared Function buscarRecibo(ByVal codRecibo As String)
        Try
            Dim tabla As DataTable = SQLConnector.retrieveDataTable("get_recibo", codRecibo)
            Dim cantidad As Integer = tabla.Rows.Count
            Dim row As DataRow = tabla.Rows(0)
            Dim cuenta As String = ""
            If Not (IsNothing(row("Cuenta").ToString)) Then
                cuenta = row("Cuenta").ToString
            End If
            Dim recibo As New Recibo(row("Recibo").ToString, CustomConvert.asTextDate(row("Fecha").ToString), DAOCliente.buscarClientePorCodigo(row("Cliente").ToString),
                                        asDouble(row("RetGanancias")), asDouble(row("RetOtra")), asDouble(row("RetIva")), asDouble(row("RetSuss")), asDouble(row("Paridad")),
                                        0, cuenta, row("Observaciones").ToString, CustomConvert.toIntOrZero(row("TipoRec")))
            Dim formasPago As New List(Of FormaPago)
            Dim pagos As New List(Of Pago)
            For Each rowA As DataRow In tabla.Rows
                If rowA("TipoReg").ToString = "2" Then
                    formasPago.Add(crearFormaPago(rowA))
                Else
                    pagos.Add(crearPago(rowA))
                End If
            Next
            recibo.formasPago = formasPago
            recibo.pagos = pagos
            Return recibo
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function buscarReciboProvisorio(ByVal codRecibo As String)
        Try
            Dim tabla As DataTable = SQLConnector.retrieveDataTable("get_recibo_provisorio_sin_numero", codRecibo)
            Dim row As DataRow = tabla.Rows(0)
            Dim recibo As ReciboProvisorio = New ReciboProvisorio(row("Recibo").ToString, CustomConvert.asTextDate(row("Fecha").ToString), DAOCliente.buscarClientePorCodigo(row("Cliente").ToString),
                                        asDouble(row("RetGanancias")), asDouble(row("RetOtra")), asDouble(row("RetIva")), asDouble(row("RetSuss")), asDouble(row("Paridad")),
                                        asDouble(row("Importe")))
            Dim formasPago As New List(Of FormaPago)
            For Each rowA As DataRow In tabla.Rows
                If rowA("TipoReg").ToString = "2" Then
                    formasPago.Add(crearFormaPago(rowA))
                End If
            Next
            recibo.formasPago = formasPago
            Return recibo
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function asDouble(ByVal value)
        'value = IIf(value = "", "0", value)
        Return CustomConvert.toDoubleOrZero(value)
    End Function
End Class
