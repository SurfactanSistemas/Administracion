Public Class SeleccionTipoIncidencia

    Private Sub btnInformeGral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformeGral.Click
        _Proceso(TipoIncidencias.General)
    End Sub

    Sub _Proceso(ByVal opt As Object)

        Dim WOwner As ISeleccionNuevaIncidencia = CType(Owner, ISeleccionNuevaIncidencia)

        If Not IsNothing(WOwner) Then WOwner._ProcesarNuevaIncidencia(opt)

        Close()
    End Sub

    Private Sub btnInformeRechazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformeRechazo.Click
        _Proceso(TipoIncidencias.RechazoMP)
    End Sub

End Class