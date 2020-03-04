Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class IngresoEnvases : Implements IAgregarEnvase

    Public Sub _ProcesarDatosEnvases() Implements IAgregarEnvase._ProcesarDatosEnvases
        _CargarDGVEnvases()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoEnvases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        _CargarDGVEnvases()
    End Sub

    Private Sub _CargarDGVEnvases()
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Envases, Descripcion = trim(Descripcion), Abreviatura, Kilos, Tipo, Peso FROM Envases WHERE Envases <> 0 ORDER BY Envases"
        Dim tablaEnvases As DataTable = GetAll(SQLCnslt)
        tablaEnvases.Columns.Add("TipoNombre")
        For Each rowEnvases As DataRow In tablaEnvases.Rows
            Select Case OrDefault(rowEnvases.Item("Tipo"), 0)
                Case 0
                    rowEnvases.Item("TipoNombre") = "Otro"
                Case 1
                    rowEnvases.Item("TipoNombre") = "Contenedor"
                Case 2
                    rowEnvases.Item("TipoNombre") = "Tambor"
            End Select
            rowEnvases.Item("Kilos") = Val(formatonumerico(OrDefault(rowEnvases.Item("Kilos"), 0), 2))
            rowEnvases.Item("Peso") = Val(formatonumerico(OrDefault(rowEnvases.Item("Peso"), 0), 2))
        Next
        DGV_Envases.DataSource = tablaEnvases
    End Sub

    Private Sub IngresoEnvases_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub
    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaEnvases As DataTable = DGV_Envases.DataSource
        TablaEnvases.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%' OR Abreviatura LIKE '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub DGV_Envases_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Envases.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar el Envase " & Trim(DGV_Envases.CurrentRow.Cells("Descripcion").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Envases WHERE Envases = '" & DGV_Envases.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
           
            _CargarDGVEnvases()
        End If
    End Sub

    Private Sub btnAgregarEnvases_Click(sender As Object, e As EventArgs) Handles btnAgregarEnvases.Click
        With New AgregarEnvases(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_Envases_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Envases.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarEnvases(Trim(DGV_Envases.CurrentRow.Cells("Codigo").Value), Trim(DGV_Envases.CurrentRow.Cells("Descripcion").Value), Trim(DGV_Envases.CurrentRow.Cells("Abreviatura").Value), Trim(DGV_Envases.CurrentRow.Cells("Kilos").Value), OrDefault(DGV_Envases.CurrentRow.Cells("Tipo").Value, ""), OrDefault(DGV_Envases.CurrentRow.Cells("Peso").Value, ""))
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_Envases.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarEnvases(Row.Cells("Codigo").Value, Trim(Row.Cells("Descripcion").Value), OrDefault(Trim(Row.Cells("Abreviatura").Value), ""), OrDefault(Row.Cells("Kilos").Value, ""), OrDefault(Row.Cells("Tipo").Value, ""), Row.Cells("Peso").Value)
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

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With New VistaPrevia
            .Reporte = New ReporteEnvases()
            .Mostrar()
        End With
    End Sub

End Class