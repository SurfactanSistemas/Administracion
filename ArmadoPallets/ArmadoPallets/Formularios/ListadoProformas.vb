Imports System.Data.SqlClient

Public Class ListadoProformas

    Private Sub ListadoProformas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarProformas()
    End Sub

    Private Sub _CargarProformas()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT p.Proforma, ISNULL(p.Pedido, '') As Pedido, p.Fecha, p.Cliente, ISNULL(c.Razon, '') Descripcion, p.Pais FROM ProformaExportacion p LEFT OUTER JOIN Cliente c ON p.Cliente = c.Cliente WHERE p.Renglon = 1 ORDER BY p.Proforma")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable
        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al traer las Proformas desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        dgvProformas.DataSource = tabla
        For Each c As DataGridViewColumn In dgvProformas.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub

    Private Sub ListadoProformas_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp

        Dim tabla As DataTable = dgvProformas.DataSource

        If Not IsNothing(tabla) Then

            tabla.DefaultView.RowFilter = String.Format("Proforma LIKE '%{0}%'" _
                                                      & " OR Pedido LIKE '%{0}%'" _
                                                      & " OR Fecha LIKE '%{0}%'" _
                                                      & " OR Descripcion LIKE '%{0}%'" _
                                                      & " OR Pais LIKE '%{0}%'" _
                                                      & " OR Cliente LIKE '%{0}%'", txtFiltrar.Text)

        End If

    End Sub

    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        With txtFiltrar
            .Text = ""
            .Focus()
        End With
        txtFiltrar_KeyUp(Nothing, Nothing)
    End Sub

    Private Sub txtPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPedido.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPedido.Text) = "" Then : Exit Sub : End If

            For Each row As DataGridViewRow In dgvProformas.Rows

                Dim WProforma = If(row.Cells("Proforma").Value, "")
                Dim WPedido = If(row.Cells("Pedido").Value, "")

                If txtPedido.Text = WPedido Then
                    Dim frm As Pallets = New Pallets(WProforma, WPedido)
                    frm.ShowDialog(Me)

                    Exit For
                End If

            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtPedido.Text = ""
        End If

    End Sub

    Private Sub dgvProformas_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProformas.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            Dim WProforma = If(dgvProformas.CurrentRow.Cells("Proforma").Value, "")
            Dim WPedido = If(dgvProformas.CurrentRow.Cells("Pedido").Value, "")

            Dim frm As Pallets = New Pallets(WProforma, WPedido)
            frm.ShowDialog(Me)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class