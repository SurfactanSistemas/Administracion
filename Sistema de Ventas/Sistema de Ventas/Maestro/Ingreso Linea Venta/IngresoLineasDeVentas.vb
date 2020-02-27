Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Public Class IngresoLineasDeVentas : Implements IAgregarLineaVenta

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoLineasDeVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = Linea, Descripcion = Nombre FROM Lineas WHERE Linea <> 0 ORDER BY Linea"
        Dim tablaRubro As DataTable = GetAll(SQLCnslt)
        DGV_LineasVentas.DataSource = tablaRubro

    End Sub

    Private Sub IngresoLineasDeVentas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaRubros As DataTable = DGV_LineasVentas.DataSource
        TablaRubros.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub DGV_LineasVentas_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_LineasVentas.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar la linea de venta " & Trim(DGV_LineasVentas.CurrentRow.Cells("Descripcion").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Lineas WHERE Linea = '" & DGV_LineasVentas.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo = Linea, Descripcion = Nombre FROM Lineas WHERE Linea <> 0 ORDER BY Linea"
            Dim tablaLineasVentas As DataTable = GetAll(SQlCnslt)
            DGV_LineasVentas.DataSource = tablaLineasVentas
        End If
    End Sub

    Private Sub btnAgregarRubro_Click(sender As Object, e As EventArgs) Handles btnAgregarLineaVenta.Click
        With New AgregarLineaVentas(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_LineasVentas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_LineasVentas.CellMouseDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarRubro(DGV_LineasVentas.CurrentRow.Cells("Codigo").Value, DGV_LineasVentas.CurrentRow.Cells("Descripcion").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_LineasVentas.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarLineaVentas(Row.Cells("Codigo").Value, Row.Cells("Descripcion").Value)
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

    Public Sub _ProcesarDatosLineaVenta() Implements IAgregarLineaVenta._ProcesarDatosLineaVenta
        Dim SQLCnslt As String = ""
        SQLCnslt = "SELECT Codigo = linea, Descripcion = Nombre FROM lineas WHERE linea <> 0 ORDER BY linea"
        Dim tablaRubro As DataTable = GetAll(SQLCnslt)
        DGV_LineasVentas.DataSource = tablaRubro

    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With New VistaPrevia
            .Reporte = New ReporteLineasDeVentas()
            .Mostrar()
        End With
    End Sub
End Class