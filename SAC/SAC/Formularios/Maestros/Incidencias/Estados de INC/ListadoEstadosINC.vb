Public Class ListadoEstadosINC : Implements INuevoEstadoINC

    Private Sub ListadoTiposSolicitud_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label1.Text = NombreEmpresa

        _CargarEstados()
    End Sub

    Private Sub _CargarEstados()

        Dim WEstados As DataTable = GetAll("SELECT Estado As Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM EstadosINC Order by Estado")

        dgvResponsables.DataSource = WEstados

        txtFiltrar.Text = ""

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditar.Click

        If dgvResponsables.SelectedRows.Count = 0 Then Exit Sub

        Dim WCodigo As String = OrDefault(dgvResponsables.SelectedRows(0).Cells("Codigo").Value, "")

        Dim frm As New NuevoEstadoINC(WCodigo)
        frm.ShowDialog(Me)

    End Sub

    Private Sub txtFiltrar_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Try
            Dim tabla = CType(dgvResponsables.DataSource, DataTable)

            If Not IsNothing(tabla) Then
                tabla.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%' " & _
                                                            " Or Convert(Codigo, System.String) LIKE '%{0}%'", txtFiltrar.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        Dim frm As New NuevoEstadoINC
        frm.ShowDialog(Me)
    End Sub

    Private Sub dgvTIpos_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvResponsables.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then Exit Sub

        Dim WCodigo As String = OrDefault(dgvResponsables.CurrentRow.Cells("Codigo").Value, "")

        Dim frm As New NuevoEstadoINC(WCodigo)
        frm.ShowDialog(Me)

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If

            Dim WTipo As DataRow = GetSingle("SELECT Estado FROM EstadosINC WHERE Estado = '" & txtCodigo.Text & "'")
            If Not IsNothing(WTipo) Then
                Dim frm As New NuevoEstadoINC(txtCodigo.Text)
                frm.ShowDialog(Me)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub dgvTIpos_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvResponsables.RowHeaderMouseDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub _ProcesarNuevoEstadoINC(ByVal Estado As String, ByVal Descripcion As String) Implements INuevoEstadoINC._ProcesarNuevoEstadoINC
        _CargarEstados()
    End Sub
End Class