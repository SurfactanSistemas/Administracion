Imports ClasesCompartidas

Public Class BancosABM

    Dim organizadorABM As New FormOrganizer(Me, 485, 600)

    Private Sub BancosABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCodigo.Text = DAOBanco.siguienteCodigo()

        organizadorABM.addControls(txtCodigo, txtNombre, txtCuenta)
        organizadorABM.addAnnexedControls(New List(Of CustomControl) From {txtDescripcion})
        organizadorABM.setAddButtonClick(AddressOf agregar)
        organizadorABM.setDeleteButtonClick(AddressOf borrar)
        organizadorABM.setDefaultCleanButtonClick()
        organizadorABM.setDefaultCloseButtonClick()
        organizadorABM.setListButtonClick(AddressOf listado)
        organizadorABM.addQueryFunction(AddressOf DAOBanco.buscarBancoPorNombre, "Bancos", AddressOf mostrarBanco, txtCodigo)
        organizadorABM.addQueryFunction(AddressOf DAOCuentaContable.buscarCuentaContablePorDescripcion, "Cuentas Contables", AddressOf mostrarCuenta, txtCuenta)
        organizadorABM.controlsDefinedBy("get_banco", AddressOf DAOBanco.crearBanco, AddressOf mostrarBanco)
        organizadorABM.organize()
    End Sub

    Private Sub agregar()
        Dim cuenta As New CuentaContable(txtCuenta.Text, txtDescripcion.Text)
        Dim banco As New Banco(txtCodigo.Text, txtNombre.Text, cuenta)
        DAOBanco.agregarBanco(banco)
    End Sub

    Private Sub borrar()
        Dim cuenta As New CuentaContable(txtCuenta.Text, txtDescripcion.Text)
        Dim banco As New Banco(txtCodigo.Text, txtNombre.Text, cuenta)
        DAOBanco.eliminarBanco(banco)
    End Sub

    Private Sub listado()

    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        txtCodigo.Text = banco.id
        txtNombre.Text = banco.nombre
        mostrarCuenta(banco.cuenta)
    End Sub

    Private Sub mostrarCuenta(ByVal cuenta As CuentaContable)
        txtCuenta.Text = cuenta.id
        txtDescripcion.Text = cuenta.descripcion
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigo.Text)
        If Not IsNothing(banco) Then
            txtNombre.Text = banco.nombre
            mostrarCuenta(banco.cuenta)
        Else
            txtNombre.Text = ""
            txtCuenta.Text = ""
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub txtCuenta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.Leave
        Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCuenta.Text)
        If Not IsNothing(cuenta) Then
            txtDescripcion.Text = cuenta.descripcion
        Else
            txtDescripcion.Text = ""
        End If
    End Sub
End Class