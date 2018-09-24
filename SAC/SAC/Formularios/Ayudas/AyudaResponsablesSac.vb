Public Class AyudaResponsablesSac : Implements INuevoResponsableSac

    Private Sub txtFiltrar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Dim tabla As DataTable = CType(dgvResponsables.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.DefaultView.RowFilter = String.Format("Convert(Codigo, System.String) LIKE '%{0}%' Or Descripcion LIKE '%{0}%'", txtFiltrar.Text)
        End If

    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub dgvResponsables_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvResponsables.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaReponsableSac = CType(Owner, IAyudaReponsableSac)

        If Not IsNothing(WOwner) Then
            WOwner._ProcesarAyudaResponsableSac(OrDefault(dgvResponsables.CurrentRow.Cells("Codigo").Value, ""))
        End If

        Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New NuevoResponsableSac()
        frm.ShowDialog(Me)
    End Sub

    Public Sub _ProcesarNuevoResponsableSac(ByVal WCodigo As Object) Implements INuevoResponsableSac._ProcesarNuevoResponsableSac
        _CargarResponsables()
    End Sub

    Private Sub AyudaResponsablesSac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarResponsables()
    End Sub

    Private Sub _CargarResponsables()
        Dim WResponsables As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac ORDER BY Codigo")
        dgvResponsables.DataSource = WResponsables
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class