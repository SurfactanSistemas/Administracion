Imports ClasesCompartidas

Public Class DAODeposito

    Public Shared Function buscarDeposito(ByVal nroDeposito As String)
        Dim rows = SQLConnector.retrieveDataTable("get_deposito_por_numero", nroDeposito).Rows
        Try
            Dim deposito As New Deposito(nroDeposito, DAOBanco.buscarBancoPorCodigo(rows(0)("Banco").ToString), rows(0)("Fecha").ToString,
                                     rows(0)("Acredita").ToString, rows(0)("Importe"))
            Dim items As New List(Of ItemDeposito)
            For Each row In rows
                Dim item As ItemDeposito
                If CustomConvert.toIntOrZero(row("Tipo2")) = 3 Then
                    item = New Cheque(row("Numero2").ToString, row("Fecha2").ToString, row("Importe2"), row("Observaciones2").ToString, "")
                Else
                    item = New Efectivo(row("Tipo2").ToString, row("Importe2"))
                End If
                items.Add(item)
                deposito.agregarItems(items)
            Next
            Return deposito
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function siguienteNumero()
        Return SQLConnector.executeProcedureWithReturnValue("get_siguiente_deposito")
    End Function

    Public Shared Function existeDepositoNumero(ByVal nroDeposito As String) As Boolean
        Return SQLConnector.checkIfExists("get_deposito_por_numero", nroDeposito)
    End Function

    Public Shared Sub agregarDeposito(ByVal deposito As Deposito, ByVal gridRows As DataGridViewRowCollection)
        deposito.agregarItems(createItems(gridRows))
        agregarDeposito(deposito)
    End Sub

    Public Shared Sub agregarDeposito(ByVal deposito As Deposito, ByVal cheques As List(Of ItemDeposito))
        deposito.agregarItems(cheques)
        agregarDeposito(deposito)
    End Sub

    Private Shared Sub agregarDeposito(ByVal deposito As Deposito)
        For Each item As ItemDeposito In deposito.items
            Dim renglon As String = indiceComoString(item, deposito.items)
            SQLConnector.executeProcedure("alta_deposito", deposito.numero & renglon, deposito.numero, renglon, deposito.banco.id, deposito.fecha, Proceso.ordenaFecha(deposito.fecha), Proceso.formatonumerico(deposito.importeTotal), deposito.fechaAcreditacion, Proceso.ordenaFecha(deposito.fechaAcreditacion), item.tipo, item.numero, item.fecha, Proceso.formatonumerico(item.importe), item.nombre)
            'SQLConnector.executeProcedure("alta_deposito", deposito.numero & renglon, deposito.numero, renglon, deposito.banco.id, deposito.fecha, Proceso.ordenaFecha(deposito.fecha), Proceso.formatonumerico(deposito.importeTotal), deposito.fechaAcreditacion, Proceso.ordenaFecha(deposito.fechaAcreditacion), item.tipo, item.numero, item.fecha, item.importe, item.nombre)
        Next
    End Sub

    Private Shared Function indiceComoString(ByVal item As ItemDeposito, ByVal items As List(Of ItemDeposito))
        Dim index As Integer = items.IndexOf(item) + 1
        Return ceros(index.ToString, 2)
    End Function


    Public Shared Function buscarCheques() As List(Of Cheque)
        Dim cheques As New List(Of Cheque)
        For Each row In SQLConnector.retrieveDataTable("get_cheque_en_cartera").Rows
            cheques.Add(New Cheque(row("Numero2").ToString, row("Fecha2").ToString, row("Importe2"), row("banco2"), row("Clave")))
        Next
        Return cheques
    End Function

    Private Shared Function createItems(ByVal gridRows As DataGridViewRowCollection)
        Dim items As New List(Of ItemDeposito)
        For Each row As DataGridViewRow In gridRows
            If Not row.IsNewRow Then
                items.Add(New Efectivo(row.Cells(0).Value, Val(row.Cells(4).Value)))
            End If
        Next
        Return items
    End Function
End Class
