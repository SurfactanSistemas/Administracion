Imports ClasesCompartidas

Public Class CuentaContableABM

    Dim organizadorABM As New FormOrganizer(Me, 400, 600)

    Private Sub CuentaContableABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        organizadorABM.addControls(txtCodigo, txtDescripcion)
        organizadorABM.setAddButtonClick(AddressOf agregar)
        organizadorABM.setDeleteButtonClick(AddressOf borrar)
        organizadorABM.setDefaultCleanButtonClick()
        organizadorABM.setDefaultCloseButtonClick()
        organizadorABM.setListButtonClick(AddressOf listado)
        organizadorABM.addQueryFunction(AddressOf DAOCuentaContable.buscarCuentaContablePorDescripcion, "Cuentas Contables", AddressOf mostrarCuenta, txtCodigo)
        organizadorABM.controlsDefinedBy("get_cuenta", AddressOf DAOCuentaContable.crearCuenta, AddressOf mostrarCuenta)
        organizadorABM.organize()
    End Sub

    Private Sub mostrarCuenta(ByVal cuenta As CuentaContable)
        txtCodigo.Text = cuenta.id
        txtDescripcion.Text = cuenta.descripcion
    End Sub

    Private Sub agregar()
        Dim cuenta As New CuentaContable(txtCodigo.Text, txtDescripcion.Text)
        DAOCuentaContable.agregarCuentaContable(cuenta)
    End Sub

    Private Sub borrar()
        DAOCuentaContable.eliminarCuentaContable(txtCodigo.Text)
    End Sub

    Private Sub listado()

    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCodigo.Text)
        If Not IsNothing(cuenta) Then
            txtDescripcion.Text = cuenta.descripcion
        Else
            txtDescripcion.Text = ""
        End If
    End Sub

End Class
