Imports Util
Imports Util.Clases.Query

Public Class IngresoRubros : Implements IAgregarRubro

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoRubros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Rubro, Descripcion = Nombre FROM Rubros WHERE Rubro <> 0 ORDER BY Rubro"
        Dim tablaRubro As DataTable = GetAll(SQLCnslt)
        DGV_Rubros.DataSource = tablaRubro

    End Sub

    Private Sub IngresoRubros_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub


    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaRubros As DataTable = DGV_Rubros.DataSource
        TablaRubros.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub


    Private Sub DGV_Rubros_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Rubros.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar el rubro " & Trim(DGV_Rubros.CurrentRow.Cells("Descripcion").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Rubros WHERE Rubro = '" & DGV_Rubros.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo = Rubro, Descripcion = Nombre FROM Rubros WHERE Rubro <> 0 ORDER BY Rubro"
            Dim tablaRubro As DataTable = GetAll(SQlCnslt)
            DGV_Rubros.DataSource = tablaRubro
        End If
    End Sub

    Private Sub btnAgregarRubro_Click(sender As Object, e As EventArgs) Handles btnAgregarRubro.Click
        With New AgregarRubro(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_Rubros_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Rubros.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarRubro(DGV_Rubros.CurrentRow.Cells("Codigo").Value, DGV_Rubros.CurrentRow.Cells("Descripcion").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_Rubros.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarRubro(Row.Cells("Codigo").Value, Row.Cells("Descripcion").Value)
                                .Show(Me)
                            End With
                        End If
                    Next
                End If
            Case Keys.Escape
                txtAccesoRap.Text = ""
        End Select
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccesoRap.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Public Sub _ProcesarDatosRubro() Implements IAgregarRubro._ProcesarDatosRubro
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Rubro, Descripcion = Nombre FROM Rubros WHERE Rubro <> 0 ORDER BY Rubro"
        Dim tablaRubro As DataTable = GetAll(SQLCnslt)
        DGV_Rubros.DataSource = tablaRubro

    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With New VistaPrevia
            .Reporte = New ReporteRubros
            .Mostrar()
        End With
    End Sub
End Class