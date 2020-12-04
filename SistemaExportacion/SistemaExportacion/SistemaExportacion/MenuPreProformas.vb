Imports Util.Clases.Query
Public Class MenuPreProformas : Implements IPreProforma


    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_PedidoProforma_Click(sender As Object, e As EventArgs) Handles btn_PedidoProforma.Click
        With New PedidoProforma()
            .Show(Me)
        End With
    End Sub

    Private Sub dgvPrincipal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrincipal.CellDoubleClick
        With New PedidoProforma(dgvPrincipal.CurrentRow.Cells("NroPedido").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub MenuPreProformas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecargaGrilla()
    End Sub

    Public Sub RecargaGrilla() Implements IPreProforma.RecargaGrilla



        Dim Filtro As String = ""

        If Not chk_MostrarConProforma.Checked Then
            Filtro = " AND NroProforma = ''"
        End If

        Dim SQLCnslt As String = "SELECT p.NroPedido, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.NroProforma " _
                                & "FROM PedidoProformaExportacion p INNER JOIN Cliente c on p.Cliente  = c.Cliente " _
                                & "WHERE p.Renglon = 1" & Filtro & " ORDER BY p.NroPedido"

        Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        
        If Tabla.Rows.Count > 0 Then

            With Tabla.Columns
                .Add("Producto_0")
                .Add("Producto_1")
                .Add("Producto_2")
                .Add("Producto_3")
                .Add("Producto_4")
                .Add("Producto_5")
                .Add("Producto_6")
                .Add("Producto_7")
            End With

            For Each row As DataRow In Tabla.Rows

                Dim productos(7) As String

                productos = CargarProductos(row.Item("NroPedido"))

                For i = 0 To 7
                    row.Item("Producto_" & i & "") = productos(i)
                Next
                
            Next
            
            dgvPrincipal.DataSource = Tabla
        End If
      


        If Not chk_MostrarConProforma.Checked Then
            Dim TablaFiltrar As DataTable = dgvPrincipal.DataSource
            Tabla.DefaultView.RowFilter = "NroProforma = ''"
        End If


    End Sub


    Private Function CargarProductos(ByVal NroPedido As String) As Object

        Dim Vector(7) As String
        Dim SQLCnslt As String = "SELECT Producto FROM PedidoProformaExportacion WHERE NroPedido = '" & NroPedido & "'"

        Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If Tabla.Rows.Count > 0 Then
            Dim Contador As Integer = 0
            For Each row As DataRow In Tabla.Rows
                Vector(Contador) = row.Item("Producto")
                Contador += 1
            Next
            Return Vector
        End If
    End Function

    Private Sub chk_MostrarConProforma_CheckedChanged(sender As Object, e As EventArgs) Handles chk_MostrarConProforma.CheckedChanged
        RecargaGrilla()
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        RecargaGrilla()
        txtFiltrarPor.Focus()
    End Sub

    

    
    Private Sub txtFiltrarPor_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrarPor.KeyUp
        Dim tabla As DataTable = dgvPrincipal.DataSource

        If Not chk_MostrarConProforma.Checked Then

            tabla.DefaultView.RowFilter = "NroPedido LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Fecha LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Cliente LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Pais LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_0 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_1 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_2 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_3 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_4 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_5 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_6 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_7 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR NroProforma = ''"
        End If

        tabla.DefaultView.RowFilter = "NroPedido LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Fecha LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Cliente LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%' " _
                                    & "OR Pais LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_0 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_1 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_2 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_3 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_4 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_5 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR Producto_6 LIKE '%" & Trim(txtFiltrarPor.Text) & "%'" _
                                    & "OR Producto_7 LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR NroProforma LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
    End Sub
End Class