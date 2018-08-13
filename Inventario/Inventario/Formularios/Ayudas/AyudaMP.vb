Imports System.Data.SqlClient

Public Class AyudaMP

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = CType(dgvArticulos.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.DefaultView.RowFilter = String.Format("Codigo LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)
        End If

    End Sub

    Private Sub AyudaMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarArticulos()
    End Sub

    Private Sub _CargarArticulos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Articulo ORDER BY Codigo")
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

            dgvArticulos.DataSource = tabla

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub dgvArticulos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArticulos.CellMouseDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Try

            Dim WOwner As IAyudaMP = CType(Owner, IAyudaMP)
            Dim WCodigo = If(dgvArticulos.CurrentRow.Cells("Codigo").Value, "")
            Dim WDescripcion = If(dgvArticulos.CurrentRow.Cells("Descripcion").Value, "")

            If Not IsNothing(WOwner) Then

                WOwner.AsignarMP(WCodigo, WDescripcion)

                Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class