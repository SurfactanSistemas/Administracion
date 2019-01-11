Public Class AyudaTipoSac : Implements INuevoTipoSolicitud

    Private Sub txtFiltrar_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Dim tabla = CType(dgvCentros.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.DefaultView.RowFilter = String.Format("Convert(Codigo, System.String) LIKE '%{0}%' Or Descripcion LIKE '%{0}%'", txtFiltrar.Text)
        End If

    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub dgvResponsables_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvCentros.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner = CType(Owner, IAyudaTipoSac)

        If Not IsNothing(WOwner) Then
            WOwner._ProcesarAyudaTipoSac(OrDefault(dgvCentros.CurrentRow.Cells("Codigo").Value, ""))
        End If

        Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        Dim frm As New NuevoTipoSolicitud()
        frm.ShowDialog(Me)
    End Sub

    Private Sub AyudaCentrosSac_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        _CargarTipos()
    End Sub

    Private Sub _CargarTipos()
        Dim WTiposSac As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Codigo")
        dgvCentros.DataSource = WTiposSac
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Public Sub _ProcesarNuevoTipoSolicitud(ByVal WCodigo As Object) Implements INuevoTipoSolicitud._ProcesarNuevoTipoSolicitud
        _CargarTipos()
    End Sub
End Class
