Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class AyudaClientes
    
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub AyudaClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvClientes.DataSource = _TraerClientes()

        Dim column As DataGridViewColumn = dgvClientes.Columns("Razon")

        If Not IsNothing(column) Then
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        Dim frm As IngresoRemitoVario = Owner

        Location = New Point((frm.Width + Width) / 2, frm.Location.Y + 10)

        txtFiltrar.Focus()
    End Sub

    Private Function _TraerClientes() As DataTable
        
        Dim tabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cliente, Razon FROM Cliente Order by Razon")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla

    End Function

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = dgvClientes.DataSource

        If Not IsNothing(tabla) Then
            tabla.DefaultView.RowFilter = String.Format("Cliente LIKE '%{0}%' OR Razon LIKE '%{0}%'", txtFiltrar.Text)
        End If

    End Sub

    Private Sub AyudaClientes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub dgvClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IngresoRemitoVario = Owner
        Dim WCliente = If(dgvClientes.CurrentRow.Cells("Cliente").Value, "")

        If Not IsNothing(WOwner) Then
            WOwner.AsignarCliente(WCliente)
        End If

        Close()
    End Sub
End Class
