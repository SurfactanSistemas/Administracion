Imports System.Data.SqlClient

Public Class SectoresPrincipal

    Private DT_ORIGINAL As DataTable

    Private Sub SectoresPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarTodos()
    End Sub

    Private Sub _CargarTodos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, Descripcion FROM Sector")
        Dim dr As SqlDataReader
        Dim rowIndex As DataRow

        Try
            dgvGrilla.Rows.Clear()
            _LimpiarDataTableOriginal()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    rowIndex = DT_ORIGINAL.NewRow 'dgvGrilla.Rows.Add

                    With rowIndex
                        .Item("ID") = IIf(IsDBNull(dr.Item("Codigo")), "", dr.Item("Codigo"))
                        .Item("Descripcion") = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                    End With

                    DT_ORIGINAL.Rows.Add(rowIndex)

                    'With dgvGrilla.Rows(rowIndex)

                    '    .Cells("ID").Value = IIf(IsDBNull(dr.Item("Codigo")), "", dr.Item("Codigo"))
                    '    .Cells("Descripcion").Value = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))

                    'End With

                Loop

                _AsignarDatosAGrilla(DT_ORIGINAL)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try



    End Sub

    Private Sub _AsignarDatosAGrilla(ByVal DT As DataTable)

        Dim rowindex = 0

        dgvGrilla.Rows.Clear()

        For Each row As DataRow In DT.Rows
            rowindex = dgvGrilla.Rows.Add

            With dgvGrilla.Rows(rowindex)

                .Cells("ID").Value = row.Item("ID")
                .Cells("Descripcion").Value = row.Item("Descripcion")

            End With

        Next

    End Sub

    Private Sub _LimpiarDataTableOriginal()
        DT_ORIGINAL = New DataTable()

        With DT_ORIGINAL
            .Columns.Add("ID")
            .Columns.Add("Descripcion")
        End With

    End Sub

    Private Sub cmbTipoFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoFiltro.KeyDown

        If e.KeyData = Keys.Enter Then
            If cmbTipoFiltro.SelectedIndex = 0 Then : Exit Sub : End If

            txtFiltro.Text = ""
            txtFiltro.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbTipoFiltro.SelectedIndex = 0
        End If

    End Sub
End Class