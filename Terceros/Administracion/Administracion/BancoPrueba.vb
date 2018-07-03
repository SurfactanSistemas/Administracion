Imports ClasesCompartidas

Public Class BancoPrueba



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigo.Text)
        If Not IsNothing(banco) Then
            txtNombre.Text = banco.nombre
            REM mostrarCuenta(banco.cuenta)
        Else
            txtNombre.Text = ""
            txtCuenta.Text = ""
            txtDescripcion.Text = ""
        End If



    End Sub
End Class