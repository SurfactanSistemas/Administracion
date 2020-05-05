Imports Util
Imports Util.Clases.Query
Public Class IngresoCondiPago : Implements IAgregarPago

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Close()
    End Sub

    Private Sub IngresoCondiPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo = Pago, Nombre = TRIM(Nombre), Dias , Plazo, Tasa, Descuento FROM Pago WHERE Pago <> 0 ORDER by Pago"
        Dim TablaPagos As DataTable = GetAll(SQLCnslt)
        DGV_Pagos.DataSource = TablaPagos
    End Sub

    Private Sub btnAgregarPago_Click(sender As Object, e As EventArgs) Handles btnAgregarPago.Click
        With New AgregaPago(0)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_Pagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Pagos.CellDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregaPago(DGV_Pagos.CurrentRow.Cells("Codigo").Value, DGV_Pagos.CurrentRow.Cells("Nombre").Value, DGV_Pagos.CurrentRow.Cells("Dias").Value, DGV_Pagos.CurrentRow.Cells("Plazo").Value, DGV_Pagos.CurrentRow.Cells("Tasa").Value, DGV_Pagos.CurrentRow.Cells("Descuento").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub DGV_Pagos_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Pagos.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar la Condicion de Pago  " & Trim(DGV_Pagos.CurrentRow.Cells("Nombre").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Pago WHERE Pago = '" & DGV_Pagos.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo = Pago, Nombre = TRIM(Nombre), Dias , Plazo, Tasa, Descuento FROM Pago WHERE Pago <> 0 ORDER by Pago"
            Dim TablaPagos As DataTable = GetAll(SQlCnslt)
            DGV_Pagos.DataSource = TablaPagos
        End If
    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim tablaVendedores As DataTable = DGV_Pagos.DataSource
        tablaVendedores.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Nombre LIKE '%" & txtBuscador.Text & "%' "
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub

    Public Sub _ProcesarDatosPago() Implements IAgregarPago._ProcesarDatosPago
        Dim SQLCnslt As String = "SELECT Codigo = Pago, Nombre = TRIM(Nombre), Dias , Plazo, Tasa, Descuento FROM Pago WHERE Pago <> 0 ORDER by Pago"
        Dim TablaPagos As DataTable = GetAll(SQLCnslt)
        DGV_Pagos.DataSource = TablaPagos
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_Pagos.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregaPago(Row.Cells("Codigo").Value, Row.Cells("Nombre").Value, Row.Cells("Dias").Value, Row.Cells("Plazo").Value, Row.Cells("Tasa").Value, Row.Cells("Descuento").Value)
                                .Show(Me)
                            End With
                        End If
                    Next
                End If
            Case Keys.Escape
                txtAccesoRap.Text = ""
        End Select
    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click

        With New VistaPrevia
            .Reporte = New ReporteCondicionesDePagos()
            .Mostrar()
        End With
    End Sub
End Class