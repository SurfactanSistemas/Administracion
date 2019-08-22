Public Class ListaEnsayos :Implements IActualizarPorNuevoIngreso

    Dim WBase As String = "Surfactan_II"

    Private Sub ListaEnsayos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _LeerDatos()
    End Sub

    Private Sub _LeerDatos()

        If Helper._EsPellital Then WBase = "Pelitall_II"

        Dim WEnsayos As DataTable = GetAll("SELECT Codigo, LTRIM(Descripcion) Descripcion FROM Ensayos Order By Codigo", WBase)

        dgvEnsayos.DataSource = WEnsayos

        txtFiltrar.Text = ""

    End Sub

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvEnsayos.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("CONVERT(Codigo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With New IngresoEnsayos
            .Show(Me)
        End With
    End Sub

    Private Sub dgvEnsayos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEnsayos.CellMouseDoubleClick
        Dim WCodigo As Short = OrDefault(dgvEnsayos.CurrentRow.Cells("Codigo").Value, 0)

        If WCodigo > 0 Then
            With New IngresoEnsayos(WCodigo)
                .Show(Me)
            End With
        End If

    End Sub

    Public Sub _ProcesarActualizarPorNuevoIngreso() Implements IActualizarPorNuevoIngreso._ProcesarActualizarPorNuevoIngreso
        _LeerDatos()

        txtFiltrar.Focus()

    End Sub

    Private Sub ListaEnsayos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If

            Dim WEnsayo As DataRow = GetSingle("SELECT Codigo FROM Ensayos WHERE Codigo = '" & txtCodigo.Text & "'", WBase)

            If WEnsayo IsNot Nothing Then
                With New IngresoEnsayos(txtCodigo.Text)
                    .ShowDialog(Me)
                End With

                txtCodigo.Text = ""
                txtFiltrar.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub
End Class