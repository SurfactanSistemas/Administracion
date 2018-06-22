Imports ClasesCompartidas

Public Class ModificaIntereses

    Private Sub CargaIntereses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()

        Dim gridBuilder As New GridBuilder(gridCtaCte)

        gridBuilder.addDateColumn(0, "Fecha")
        gridBuilder.addTextColumn(1, "Razón")
        gridBuilder.addTextColumn(2, "Factura")
        gridBuilder.addNumericColumn(3, "Cuota")
        gridBuilder.addDateColumn(4, "Vencimiento")
        gridBuilder.addFloatColumn(5, "Saldo")
        gridBuilder.addFloatColumn(6, "Intereses")
        gridBuilder.addFloatColumn(7, "Iva Int.")
        gridBuilder.addTextColumn(8, "Referencia")

        CargarIntereses()
    End Sub

    Private Sub CargarIntereses()
        DAOCtaCteProveedor.buscarCuentasAModificarIntereses().ForEach(Sub(cuenta) gridCtaCte.Rows.Add(cuenta.fechaOriginal, cuenta.desProveedorOriginal, cuenta.factura, cuenta.cuota, cuenta.fecha, cuenta.saldo, cuenta.intereses, cuenta.ivaIntereses, cuenta.referencia, cuenta.clave, cuenta.nroInterno, cuenta.intereses, cuenta.ivaIntereses, cuenta.referencia))

        gridCtaCte.AllowUserToAddRows = False
    End Sub

    Private Sub limpiar()
        gridCtaCte.Rows.Clear()
    End Sub

    Private Sub btnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraba.Click
        For Each fila As DataGridViewRow In gridCtaCte.Rows
            DAOCtaCteProveedor.modificarCuentaSi(fila, "M")
        Next

        limpiar()
        CargarIntereses()
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Close()
    End Sub
End Class