Imports System.ComponentModel
Imports ConsultasVarias.Clases.Query

Public Class AyudaProveedores

    Private Sub AyudaProveedores_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ckSoloFarma.Enabled = False

        Dim WProveedores As DataTable = Nothing

        If ckSoloFarma.Checked Then
            WProveedores = GetAll("SELECT DISTINCT ct.Proveedor As Codigo, UPPER(RTRIM(p.Nombre)) Nombre FROM Cotiza ct INNER JOIN Proveedor p ON p.Proveedor = ct.Proveedor INNER JOIN Articulo a ON a.Codigo = ct.Articulo  And (ISNULL(a.ClasificacionFarma,0) = 1 Or (ISNULL(a.ClasificacionFarma,0) = 0 And a.ReqEvalEspecial = '1') Or (ISNULL(a.ClasificacionFarma,0) > 1 And a.ReqEvalEspecial = '1'))")
        Else
            WProveedores = GetAll("SELECT Proveedor AS Codigo, UPPER(RTRIM(Nombre)) Nombre FROM Proveedor Order by Nombre, Proveedor")
        End If

        BackgroundWorker1.ReportProgress(1, WProveedores)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim WProveedores As DataTable = TryCast(e.UserState, DataTable)

        DataGridView1.DataSource = WProveedores

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ckSoloFarma.Enabled = True
        txtFiltrar.Focus()
    End Sub

    Private Sub AyudaProveedores_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub txtFiltrar_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim WTabla As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        If WTabla IsNot Nothing Then WTabla.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR Nombre LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim WProveedor As String = DataGridView1.CurrentRow.Cells("Codigo").Value
        Dim WNombre As String = DataGridView1.CurrentRow.Cells("Nombre").Value

        Dim WOwner As IAyudaProveedores = TryCast(Owner, IAyudaProveedores)

        If WOwner IsNot Nothing Then WOwner._ProcesarAyudaProveedores(WProveedor, WNombre)

        Close()

    End Sub

    Private Sub ckSoloFarma_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckSoloFarma.MouseClick
        BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class