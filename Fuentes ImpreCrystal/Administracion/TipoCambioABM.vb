Imports ClasesCompartidas

Public Class TipoCambioABM

    Dim organizadorABM As New FormOrganizer(Me, 400, 600)

    Private Sub TipoCambioABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        organizadorABM.addControls(txtFecha, txtParidad)
        organizadorABM.setAddButtonClick(AddressOf agregar)
        organizadorABM.setDeleteButtonClick(AddressOf borrar)
        organizadorABM.setDefaultCleanButtonClick()
        organizadorABM.setDefaultCloseButtonClick()
        organizadorABM.setListButtonClick(AddressOf listado)
        organizadorABM.addQueryFunction(AddressOf DAOTipoCambio.listarTiposCambio, "Cambio", AddressOf mostrarCambio, txtFecha)
        organizadorABM.dontUseQueryText()
        organizadorABM.controlsDefinedBy("get_tipo_cambio", AddressOf DAOTipoCambio.crearTipoCambio, AddressOf mostrarCambio)
        organizadorABM.organize()
    End Sub

    Private Sub agregar()
        Dim cambio As New TipoDeCambio(txtFecha.Text, txtParidad.Text)
        DAOTipoCambio.agregarTipoCambio(cambio)
    End Sub

    Private Sub borrar()
        DAOTipoCambio.eliminarTipoCambio(txtFecha.Text)
    End Sub

    Private Sub listado()

    End Sub

    Private Sub mostrarCambio(ByVal cambio As TipoDeCambio)
        txtFecha.Text = cambio.fecha
        txtParidad.Text = cambio.paridad
    End Sub

    Private Sub txtFecha_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.Leave
        Dim cambio As TipoDeCambio = DAOTipoCambio.buscarTipoCambioPorFecha(txtFecha.Text)
        If Not IsNothing(cambio) Then
            txtFecha.Text = cambio.fecha
            txtParidad.Text = cambio.paridad
        End If
    End Sub
End Class