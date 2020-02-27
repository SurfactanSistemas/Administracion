Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query

Public Class IngresoVendedores : Implements IAgregarVendedores

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Close()
    End Sub

    Private Sub IngresoVendedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String = "SELECT Codigo = Vendedor, Nombre = TRIM(Nombre), Email1 = TRIM(Email1), Email2 = TRIM(Email2) FROM Vendedor WHERE Vendedor <> 0 ORDER by Vendedor"
        Dim TablaVendedores As DataTable = getall(SQLCnslt)
        DGV_Vendedores.DataSource = TablaVendedores
    End Sub

    Private Sub txtBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtBuscador.Text = ""
        End Select
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccesoRap.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim tablaVendedores As DataTable = DGV_Vendedores.DataSource
        tablaVendedores.DefaultView.RowFilter = "Convert(Codigo,System.String) LIKE '%" & txtBuscador.Text & "%' OR Nombre LIKE '%" & txtBuscador.Text & "%' OR Email1 LIKE '%" & txtBuscador.Text & "%' OR Email2 LIKE '%" & txtBuscador.Text & "%'"

    End Sub

    Private Sub DGV_Vendedores_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Vendedores.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar el Vendedor " & Trim(DGV_Vendedores.CurrentRow.Cells("Nombre").Value) & "?", vbYesNo) = vbYes Then
            Dim SQlCnslt As String = "DELETE FROM Vendedor WHERE Vendedor = '" & DGV_Vendedores.CurrentRow.Cells("Codigo").Value & "'"
            ExecuteNonQueries({SQlCnslt})
            SQlCnslt = "SELECT Codigo = Vendedor,Nombre = TRIM(Nombre), Email1 = TRIM(Email1), Email2 = TRIM(Email2) FROM Vendedor WHERE Vendedor <>  0 ORDER by Vendedor"
            Dim TablaVendedores As DataTable = GetAll(SQLCnslt)
            DGV_Vendedores.DataSource = TablaVendedores
        End If
    End Sub

    Private Sub DGV_Vendedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Vendedores.CellDoubleClick
        If e.ColumnIndex < 0 Then
            Exit Sub
        End If
        With New AgregarVendedor(DGV_Vendedores.CurrentRow.Cells("Codigo").Value, DGV_Vendedores.CurrentRow.Cells("Nombre").Value, DGV_Vendedores.CurrentRow.Cells("Email1").Value, DGV_Vendedores.CurrentRow.Cells("Email2").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub txtAccesoRap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRap.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtAccesoRap.Text <> "" Then
                    For Each Row As DataGridViewRow In DGV_Vendedores.Rows
                        If Row.Cells("Codigo").Value = txtAccesoRap.Text Then
                            With New AgregarVendedor(Row.Cells("Codigo").Value, Row.Cells("Nombre").Value, Row.Cells("Email1").Value, Row.Cells("Email2").Value)
                                .Show(Me)
                            End With
                        End If
                    Next
                End If
            Case Keys.Escape
                txtAccesoRap.Text = ""
        End Select
    End Sub

    Public Sub _ProcesarDatosVendedores() Implements IAgregarVendedores._ProcesarDatosVendedores
        Dim SQLCnslt As String = "SELECT Codigo = Vendedor, Nombre = TRIM(Nombre), Email1 = TRIM(Email1), Email2 = TRIM(Email2) FROM Vendedor WHERE Vendedor <> 0 ORDER by Vendedor"
        Dim TablaVendedores As DataTable = GetAll(SQLCnslt)
        DGV_Vendedores.DataSource = TablaVendedores
    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click

        With New VistaPrevia
            .Reporte = New ReporteVendedores()
            .Mostrar()
        End With
    End Sub


    Private Sub btnAgregarVendedor_Click(sender As Object, e As EventArgs) Handles btnAgregarVendedor.Click
        With New AgregarVendedor(0)
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoVendedores_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub
End Class