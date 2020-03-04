Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query

Public Class IngresoConcepDGastosImportacion : Implements IAgregarGastosImpo
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoGastosImpo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion = Nombre FROM Gasimpo WHERE Codigo <> 0 ORDER BY Codigo"
        Dim tablaGastos As DataTable = GetAll(SQLCnslt)
        DGV_GastosImportacion.DataSource = tablaGastos
    End Sub

    Private Sub IngresoGastosImpo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub
    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaGastosImpo As DataTable = DGV_GastosImportacion.DataSource
        TablaGastosImpo.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub DGV_GastosImpo_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_GastosImportacion.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar el gasto de Importacion : " & Trim(DGV_GastosImportacion.CurrentRow.Cells("Descripcion").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Gasimpo WHERE Codigo = '" & DGV_GastosImportacion.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo , Descripcion = Nombre FROM Gasimpo WHERE Codigo <> 0 ORDER BY Codigo"
            Dim tablaGastosImpo As DataTable = GetAll(SQlCnslt)
            DGV_GastosImportacion.DataSource = tablaGastosImpo
        End If
    End Sub

    Private Sub btnAgregarGastosImpo_Click(sender As Object, e As EventArgs) Handles btnAgregarGastImp.Click
        With New AgregarConcepDGastosImpor(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_GastosImpo_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_GastosImportacion.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarConcepDGastosImpor(Trim(DGV_GastosImportacion.CurrentRow.Cells("Codigo").Value), Trim(DGV_GastosImportacion.CurrentRow.Cells("Descripcion").Value))
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_GastosImportacion.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarConcepDGastosImpor(Row.Cells("Codigo").Value, Trim(Row.Cells("Descripcion").Value))
                                .Show(Me)
                            End With
                        End If
                    Next
                End If
            Case Keys.Escape
                txtAccesoRap.Text = ""
        End Select
    End Sub
    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles txtAccesoRap.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With New VistaPrevia
            .Reporte = New ReporteConcepDGastosImportacion()
            .Mostrar()
        End With
    End Sub

    Public Sub _ProcesarDatosGastosImpo() Implements IAgregarGastosImpo._ProcesarDatosGastosImpo
        Dim SQLCnslt As String = "SELECT Codigo, Descripcion = Nombre FROM Gasimpo WHERE Codigo <> 0 ORDER BY Codigo"
        Dim tablaGastos As DataTable = GetAll(SQLCnslt)
        DGV_GastosImportacion.DataSource = tablaGastos
    End Sub
End Class