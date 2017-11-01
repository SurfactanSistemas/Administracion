Imports System.Data.SqlClient

Public Class TemasPrincipal

    Private DT_ORIGINAL As DataTable

    Private Sub TemasPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarTodos()
    End Sub

    Public Sub _CargarTodos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, Descripcion, Responsable, Tipo as Lugar, Horas FROM Curso WHERE Descripcion <> '' ORDER BY Codigo")
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
                        .Item("Responsable") = IIf(IsDBNull(dr.Item("Responsable")), "", dr.Item("Responsable"))
                        .Item("Lugar") = IIf(IsDBNull(dr.Item("Lugar")), "", dr.Item("Lugar"))
                        .Item("Horas") = IIf(IsDBNull(dr.Item("Horas")), "", dr.Item("Horas"))
                    End With

                    DT_ORIGINAL.Rows.Add(rowIndex)

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

        If Not IsNothing(DT) Then
            For Each row As DataRow In DT.Rows
                rowindex = dgvGrilla.Rows.Add

                With dgvGrilla.Rows(rowindex)

                    .Cells("ID").Value = row.Item("ID")
                    .Cells("Descripcion").Value = row.Item("Descripcion")
                    .Cells("Responsable").Value = row.Item("Responsable")
                    .Cells("Lugar").Value = row.Item("Lugar")
                    .Cells("Horas").Value = row.Item("Horas")

                End With

            Next
        End If

    End Sub

    Private Sub _LimpiarDataTableOriginal()
        DT_ORIGINAL = New DataTable()

        With DT_ORIGINAL
            .Columns.Add("ID")
            .Columns.Add("Descripcion")
            .Columns.Add("Responsable")
            .Columns.Add("Lugar")
            .Columns.Add("Horas")
        End With

    End Sub

    Private Sub txtFiltro_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyUp

        If e.KeyData = Keys.Escape Then
            txtFiltro.Text = ""
            _AsignarDatosAGrilla(DT_ORIGINAL)
        Else

            If Trim(txtFiltro.Text) = "" Then

                _AsignarDatosAGrilla(DT_ORIGINAL)

            Else

                Dim tabla As DataTable

                Try
                    tabla = DT_ORIGINAL.Select("ID like '%" & Trim(txtFiltro.Text) & "%' OR Lugar like '%" & Trim(txtFiltro.Text) & "%' OR Horas like '%" & Trim(txtFiltro.Text) & "%' OR Responsable like '%" & Trim(txtFiltro.Text) & "%' OR Descripcion like '%" & Trim(txtFiltro.Text) & "%'").CopyToDataTable
                Catch ex As Exception
                    tabla = Nothing
                    'MsgBox("ID like '%" & Trim(txtFiltro.Text) & "%' OR Lugar like '%" & Trim(txtFiltro.Text) & "%' OR Horas like '%" & Trim(txtFiltro.Text) & "%' OR Responsable like '%" & Trim(txtFiltro.Text) & "%' OR Descripcion like '%" & Trim(txtFiltro.Text) & "%'")
                End Try

                _AsignarDatosAGrilla(tabla)

            End If

        End If

    End Sub

    Private Sub dgvGrilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrilla.CellDoubleClick
        Dim row As DataGridViewRow = dgvGrilla.Rows(e.RowIndex)

        With AMBTemas
            .txtCodigo.Text = row.Cells("ID").Value
            ._AbrirParaModificar()
        End With
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        AMBTemas.Show()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        AMBTemas.Close()
        Me.Close()
    End Sub

    Private Sub btnCargarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTodos.Click
        txtFiltro.Text = ""
        _CargarTodos()
    End Sub
End Class