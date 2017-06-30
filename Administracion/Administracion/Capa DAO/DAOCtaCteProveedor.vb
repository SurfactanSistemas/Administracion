Imports ClasesCompartidas

Public Class DAOCtaCteProveedor


    Public Shared Sub modificarCuentaSi(ByVal cuenta As DataGridViewRow, ByVal tipoMov As Char)
        Dim saldoNuevo, intereses, iva As Decimal
        Dim referencia As String

        intereses = Convert.ToDecimal(cuenta.Cells("Intereses").Value)
        iva = Convert.ToDecimal(cuenta.Cells("IvaIntereses").Value)
        referencia = cuenta.Cells("Referencia").Value

        If (validarModifcacionIntereses(cuenta, tipoMov, intereses, iva, referencia)) Then
            saldoNuevo = Convert.ToDecimal(cuenta.Cells("Saldo").Value) + intereses + iva
            SQLConnector.executeProcedure("modificar_carga_intereses", cuenta.Cells("clave").Value, saldoNuevo, intereses, iva, cuenta.Cells("Referencia").Value)
        End If
    End Sub

    Private Shared Function validarModifcacionIntereses(ByVal cuenta As DataGridViewRow, ByVal tipoMov As Char, ByVal intereses As Decimal, ByVal iva As Decimal, ByVal referencia As String)
        Dim valido As Boolean
        ' tipo = C equivale a cargaIntereses y M equivale a ModificaIntereses y validan de forma distinta
        ' la carga en la base de datos
        If (tipoMov = "C") Then
            valido = intereses <> 0 Or iva <> 0 Or referencia <> ""
        Else
            Dim interesesControl, ivaControl As Decimal
            Dim referenciaControl As String

            interesesControl = Convert.ToDecimal(cuenta.Cells("InteresesControl").Value)
            ivaControl = Convert.ToDecimal(cuenta.Cells("IvaControl").Value)
            referenciaControl = cuenta.Cells("ReferenciaControl").Value

            valido = intereses <> interesesControl Or iva <> ivaControl Or referencia <> referenciaControl
        End If

        Return valido
    End Function

    Public Shared Function buscarCuentas() As List(Of CtaCteProveedor)
        Return buscar("C")
    End Function

    Public Shared Function buscarCuentasAModificarIntereses() As List(Of CtaCteProveedor)
        Return buscar("M")
    End Function

    Private Shared Function buscar(ByVal tipo As String)
        Dim cuentas As New List(Of CtaCteProveedor)
        For Each row In SQLConnector.retrieveDataTable("get_carga_intereses", "C").Rows
            'cuentas.Add(New CtaCteProveedor(row("FechaOriginal").ToString, row("DesProveOriginal").ToString, row("FacturaOriginal").ToString, row("Cuota").ToString, row("fecha").ToString, formatonumerico(redondeo(Convert.ToDouble(row("Saldo"))), "########.##", "."), row("Intereses"), row("IvaIntereses"), row("Referencia").ToString, row("Clave").ToString, row("NroInterno").ToString))
            cuentas.Add(New CtaCteProveedor(row("FechaOriginal").ToString, row("DesProveOriginal").ToString, row("FacturaOriginal").ToString, row("Cuota").ToString, row("fecha").ToString, redondeo(Convert.ToDouble(row("Saldo"))), row("Intereses"), row("IvaIntereses"), row("Referencia").ToString, row("Clave").ToString, row("NroInterno").ToString))
        Next
        Return cuentas
    End Function

    Public Shared Function cuentasSinSaldar(ByVal proveedor As Proveedor) As List(Of DetalleCompraCuentaCorriente)
        Dim cuentas As New List(Of DetalleCompraCuentaCorriente)
        For Each row In SQLConnector.retrieveDataTable("get_cuentas_sin_saldar", proveedor.id).Rows
            cuentas.Add(New DetalleCompraCuentaCorriente(row("Tipo").ToString, row("Impre").ToString, row("Punto").ToString, row("Numero").ToString,
                                                         row("Letra").ToString, row("fecha").ToString, row("Saldo"),
                                                         row("Total"), row("NroInterno").ToString, proveedor, row("Pago"), row("Paridad")))
        Next
        Return cuentas
    End Function


    Public Shared Function buscardeuda(ByVal proveedor As String, ByVal tipo As Char)
        Dim ctacteprv As New List(Of CtaCteProveedoresDeuda)
        For Each row In SQLConnector.retrieveDataTable("buscar_Cuenta_Corriente_Proveedores_deuda", proveedor, tipo).Rows
            ctacteprv.Add(New CtaCteProveedoresDeuda(row("Tipo").ToString, row("letra").ToString, row("punto").ToString, row("numero").ToString, row("total"), row("saldo"), row("fecha").ToString, row("vencimiento").ToString))
        Next
        Return ctacteprv
    End Function

End Class
