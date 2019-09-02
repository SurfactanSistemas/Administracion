Public Class CUFEProveedor

    Dim organizadorABM As New FormOrganizer(Me, 500, 600)

    Private Sub CUFEProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        organizadorABM.addControls(txtCUFE1, txtCUFE2, txtCUFE3)
        organizadorABM.addAnnexedControls(New List(Of CustomControl) From {txtCUFE1Fecha, txtCUFE2Fecha, txtCUFE3Fecha})
        organizadorABM.organizeForNotCRUDForm()
    End Sub

End Class