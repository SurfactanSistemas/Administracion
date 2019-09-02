Public Class CuotasPyMENacion

    Dim organizadorABM As New FormOrganizer(Me, 300, 600)

    Private Sub CuotasPyMENacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        organizadorABM.addControls(txtCantidadCuotas, txtMes)
        organizadorABM.addAnnexedControls(New List(Of CustomControl) From {txtAnio})
        organizadorABM.organizeForNotCRUDForm()
    End Sub
End Class