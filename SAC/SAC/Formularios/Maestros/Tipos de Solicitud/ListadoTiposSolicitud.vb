Public Class ListadoTiposSolicitud : Implements INuevoTipoSolicitud

    Private Sub ListadoTiposSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Helper.NombreEmpresa

        _CargarTipos()
    End Sub

    Private Sub _CargarTipos()

        Dim WTipos As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac Order by Codigo")

        dgvTIpos.DataSource = WTipos

        txtFiltrar.Text = ""

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        
        If dgvTIpos.SelectedRows.Count = 0 Then Exit Sub

        Dim WCodigo As String = OrDefault(dgvTIpos.SelectedRows(0).Cells("Codigo").Value, "")

        Dim frm As New NuevoTipoSolicitud(WCodigo)
        frm.ShowDialog(Me)

    End Sub

    Private Sub txtFiltrar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Try
            Dim tabla As DataTable = CType(dgvTIpos.DataSource, DataTable)

            If Not IsNothing(tabla) Then
                tabla.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%' Or Convert(Codigo, System.String) LIKE '%{0}%'", txtFiltrar.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Public Sub _ProcesarNuevoTipoSolicitud(ByVal WCodigo As Object) Implements INuevoTipoSolicitud._ProcesarNuevoTipoSolicitud
        _CargarTipos()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New NuevoTipoSolicitud
        frm.ShowDialog(Me)
    End Sub

    Private Sub dgvTIpos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTIpos.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then Exit Sub

        Dim WCodigo As String = OrDefault(dgvTIpos.CurrentRow.Cells("Codigo").Value, "")

        Dim frm As New NuevoTipoSolicitud(WCodigo)
        frm.ShowDialog(Me)

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If

            Dim WTipo As DataRow = Query.GetSingle("SELECT Codigo FROM TipoSac WHERE Codigo = '" & txtCodigo.Text & "'")
            If Not IsNothing(WTipo) Then
                Dim frm As New NuevoTipoSolicitud(txtCodigo.Text)
                frm.ShowDialog(Me)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub dgvTIpos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTIpos.RowHeaderMouseDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class