Imports ClasesCompartidas

Public Class RubrosProveedorABM

    Dim organizadorABM As New FormOrganizer(Me, 485, 600)

    Private Sub RubrosProveedorABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCodigo.Text = DAORubroProveedor.siguienteCodigo()

        organizadorABM.addControls(txtCodigo, txtDescripcion)
        organizadorABM.setAddButtonClick(AddressOf agregar)
        organizadorABM.setDeleteButtonClick(AddressOf borrar)
        organizadorABM.setDefaultCleanButtonClick()
        organizadorABM.setDefaultCloseButtonClick()
        organizadorABM.setListButtonClick(AddressOf listado)
        organizadorABM.addQueryFunction(AddressOf DAORubroProveedor.buscarRubroProveedorPorDescripcion, "Rubros", AddressOf mostrarRubroProveedor, txtCodigo)
        organizadorABM.controlsDefinedBy("get_rubro", AddressOf DAORubroProveedor.crearRubroProveedor, AddressOf mostrarRubroProveedor)
        organizadorABM.organize()
    End Sub

    Private Sub agregar()
        Dim rubro As New RubroProveedor(txtCodigo.Text, txtDescripcion.Text)
        DAORubroProveedor.agregarRubroProveedor(rubro)
    End Sub

    Private Sub borrar()
        Dim rubro As New RubroProveedor(txtCodigo.Text, txtDescripcion.Text)
        DAORubroProveedor.eliminarRubroProveedor(rubro)
    End Sub

    Private Sub listado()

    End Sub

    Private Sub mostrarRubroProveedor(ByVal rubro As RubroProveedor)
        txtCodigo.Text = rubro.codigo
        txtDescripcion.Text = rubro.descripcion
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        Dim rubro As RubroProveedor = DAORubroProveedor.buscarRubroProveedorPorCodigo(txtCodigo.Text)
        If Not IsNothing(rubro) Then
            txtDescripcion.Text = rubro.descripcion
        Else
            txtDescripcion.Text = ""
        End If
    End Sub

End Class