Imports ClasesCompartidas

Public Class ModificaIntereses

    Dim dataGridBuilder As GridBuilder

    Private Sub CargaIntereses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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