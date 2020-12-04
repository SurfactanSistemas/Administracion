Imports Util.Clases.Query
Public Class ConsultaPedidosDeProforma

    Private Sub ConsultaPedidosDeProforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' dgvPrincipal.Rows.Clear()
        dgvPrincipal.DataSource = Nothing
        

        Dim SQLCnslt As String = "SELECT p.NroPedido, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.OperadorDesc " _
                                & "FROM PedidoProformaExportacion p INNER JOIN Cliente c on p.Cliente  = c.Cliente " _
                                & "WHERE p.Renglon = 1 AND NroProforma = ''"

        Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If Tabla.Rows.Count > 0 Then
            dgvPrincipal.DataSource = Tabla
        End If

        'For Each row As DataRow In Tabla.Rows
        '    With row
        '        dgvPrincipal.Rows.Add(.Item("NroPedido"), .Item("Fecha"), .Item("Cliente"), .Item("Razon"), .Item("Pais"), .Item("Total"))
        '    End With
        'Next

    End Sub

    Private Sub dgvPrincipal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrincipal.CellDoubleClick

        Dim WOwner As IConsultaPedPrepo = TryCast(Owner, IConsultaPedPrepo)
        If WOwner IsNot Nothing Then
            WOwner.PasarNroPedido(dgvPrincipal.CurrentRow.Cells("NroPedido").Value)
            Close()
        End If


    End Sub



    Private Sub txtFiltrarPor_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrarPor.KeyUp
        Dim tabla As DataTable = dgvPrincipal.DataSource
        tabla.DefaultView.RowFilter = "NroPedido LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Fecha LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Cliente LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Pais LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR OperadorDesc LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class