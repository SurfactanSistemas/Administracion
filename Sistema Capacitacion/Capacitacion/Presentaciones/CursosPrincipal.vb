Imports System.Data.SqlClient

Public Class CursosPrincipal

    Private DT_ORIGINAL As DataTable

    Private Sub CursosPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarTodos()
    End Sub

    Public Sub _CargarTodos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tema, Descripcion, Curso, Horas FROM Tema WHERE Descripcion <> '' ORDER BY Curso, Tema")
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
                        .Item("Curso") = IIf(IsDBNull(dr.Item("Curso")), "", dr.Item("Curso"))
                        .Item("Descripcion") = IIf(IsDBNull(dr.Item("Descripcion")), "", dr.Item("Descripcion"))
                        .Item("Tema") = IIf(IsDBNull(dr.Item("Tema")), "", dr.Item("Tema"))
                        '.Item("Lugar") = IIf(IsDBNull(dr.Item("Lugar")), "", dr.Item("Lugar"))
                        .Item("Horas") = IIf(IsDBNull(dr.Item("Horas")), "0", dr.Item("Horas"))

                        .Item("Horas") = Helper.formatonumerico(.Item("Horas"))
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

                    .Cells("Curso").Value = row.Item("Curso")
                    .Cells("Descripcion").Value = row.Item("Descripcion")
                    .Cells("Tema").Value = row.Item("Tema")
                    '.Cells("Lugar").Value = row.Item("Lugar")
                    .Cells("Horas").Value = row.Item("Horas")

                End With

            Next
        End If

    End Sub

    Private Sub _LimpiarDataTableOriginal()
        DT_ORIGINAL = New DataTable()

        With DT_ORIGINAL
            .Columns.Add("Curso")
            .Columns.Add("Descripcion")
            .Columns.Add("Tema")
            '.Columns.Add("Lugar")
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

                Dim tabla As DataTable = Nothing

                Try


                    Select Case cmbFiltro.SelectedIndex
                        Case 0
                            tabla = Nothing
                        Case 1, 3
                            tabla = DT_ORIGINAL.Select(cmbFiltro.SelectedItem & " = '" & Trim(txtFiltro.Text) & "'").CopyToDataTable
                        Case Else
                            tabla = DT_ORIGINAL.Select(cmbFiltro.SelectedItem & " like '%" & Trim(txtFiltro.Text) & "%'").CopyToDataTable
                    End Select

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

        With AMBCursos
            .txtTema.Text = row.Cells("Curso").Value
            ._AbrirParaModificar()
        End With
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        AMBCursos.Show()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        AMBCursos.Close()
        Me.Close()
    End Sub

    Private Sub btnCargarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTodos.Click
        txtFiltro.Text = ""
        cmbFiltro.SelectedIndex = 0
        _CargarTodos()
    End Sub

    Private Sub dgvGrilla_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvGrilla.SortCompare

        Dim n1, n2

        Select Case e.Column.Index
            Case 0, 2, 3

                n1 = CDbl(e.CellValue1)
                n2 = CDbl(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If n1 < n2 Then
            e.SortResult = -1
        ElseIf n1 = n2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True
    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltro.SelectedIndexChanged

        Select Case cmbFiltro.SelectedIndex
            Case 0
                btnCargarTodos.PerformClick()
            Case Else
                _CargarTodos()
                txtFiltro.Text = ""
                txtFiltro.Focus()
        End Select

    End Sub
End Class