Imports System.Data.SqlClient
Imports Sedronar.Clases

Public Class DeclaracionJuradaPT

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Dim tabla As DataTable = CType(dgvProductos.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.Rows.Clear()
        End If

        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtDesde.Text) Then Exit Sub

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtHasta.Text) Then Exit Sub

            If Val(Helper.ordenaFecha(txtHasta.Text)) > Val(Helper.ordenaFecha(txtDesde.Text)) Then
                MsgBox("Las fechas deben ser iguales o consecutivas.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If

    End Sub

    Private Sub DeclaracionJuradaMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Clear()
        txtHasta.Clear()
        ckLimpia.Checked = False
        dgvProductos.Rows.Clear()
        txtCodigo.Clear()

        _CargarDatos()

        txtDesde.Focus()
    End Sub

    Private Sub _CargarDatos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Terminado WHERE Sedronar = '1' ORDER BY Codigo")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

            dgvProductos.DataSource = tabla

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try

    End Sub

    Private Sub dgvProductos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductos.RowHeaderMouseDoubleClick
        If MsgBox("¿Seguro de querer eliminar este Codigo del Listado?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        Dim row As DataGridViewRow = dgvProductos.CurrentRow

        dgvProductos.Rows.Remove(row)

        txtDesde.Focus()

    End Sub

    Private Sub DeclaracionJuradaMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtCodigo.Text.Replace("-", "").Trim = "" Then Exit Sub
        If txtCodigo.Text.Replace(" ", "").Length < 10 Then Exit Sub

        Dim WProducto As DataRow = Helper.QuerySingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")

        If Not IsNothing(WProducto) Then

            For Each row As DataGridViewRow In dgvProductos.Rows
                Dim WCodigo = If(row.Cells("Codigo").Value, "")

                If WCodigo.ToString.Trim.ToUpper = txtCodigo.Text.Trim.ToUpper Then
                    txtCodigo.Clear()
                    txtCodigo.Focus()
                    Exit Sub
                End If

            Next

            Dim tabla As DataTable = CType(dgvProductos.DataSource, DataTable)

            If Not IsNothing(tabla) Then
                Dim r As DataRow = tabla.NewRow

                With r
                    .Item("Codigo") = If(WProducto.Item("Codigo"), "")
                    .Item("Descripcion") = If(WProducto.Item("Descripcion"), "")
                End With

                tabla.Rows.Add(r)

                tabla.DefaultView.Sort = "Codigo ASC"
            
            End If

            txtCodigo.Clear()
            txtCodigo.Focus()

        End If

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            btnAgregar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Clear()
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            '
            ' Validamos que las fechas ingresadas sean válidas.
            '
            If Not Helper._ValidarFecha(txtHasta.Text) Then Throw New Exception("La fecha 'Hasta' no es válida.")
            If Not Helper._ValidarFecha(txtDesde.Text) Then Throw New Exception("La fecha 'Desde' no es válida.")

            '
            ' Validamos que las fechas sean iguales o consecutivas.
            '
            If Val(Helper.ordenaFecha(txtHasta.Text)) > Val(Helper.ordenaFecha(txtDesde.Text)) Then
                MsgBox("Las fechas deben ser iguales o consecutivas.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            '
            ' WGuardamos los 
            '



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class