Imports System.Configuration
Imports System.Data.SqlClient

Public Class HojaIngresoFrases
    Protected L As Char ' Variable que define de que opcion del menu entro

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyData = Keys.Enter Then
            If (txtCodigo.Text <> "") Then

                Dim variable As String = txtCodigo.Text
                btnLimpiar_Click(Nothing, Nothing)
                txtCodigo.Text = variable

                Try
                    Dim SqlConsulta As String
                    If (L = "H") Then

                        SqlConsulta = "SELECT * FROM FraseH WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    Else
                        SqlConsulta = "SELECT * FROM FraseP WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    End If

                    Dim row As DataRow = GetSingle(SqlConsulta)

                    If row IsNot Nothing Then
                        txtDescripcion.Text = Trim(row.Item("Descripcion").ToString() & row.Item("DescripcionII") & row.Item("DescripcionIII"))
                        txtObservacion.Text = Trim(row.Item("Observa"))
                    End If
                    txtDescripcion.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        End If
        If e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtDescripcion.Text <> "" Then
                txtObservacion.Focus()
            End If
        End If
        If e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCodigo.Focus()
        End If
        If e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtObservacion.Text = ""
        txtCodigo.Focus()

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click
        If (txtCodigo.Text <> "") Then
            Try
                Dim SqlConsulta As String = ""
                Dim CantidadDeFilas As Integer = ContieneAlgoLaBase()

                txtDescripcion.Text = txtDescripcion.Text.Trim().PadRight(450, " ") 'Rellenamos los espacios vacio con " " para poder hacer el substring


                If (CantidadDeFilas = 0) Then
                    If (L = "H") Then

                        SqlConsulta = "INSERT INTO FraseH (Codigo , Descripcion, DescripcionII, DescripcionIII, Observa) values ('" + txtCodigo.Text.Trim() + " ', '" + txtDescripcion.Text.Substring(0, 249).Trim() + "', '" + txtDescripcion.Text.Substring(250, 100).Trim() + "', '" + txtDescripcion.Text.Substring(350, 100).Trim() + "', '" + txtObservacion.Text.Trim() + "')"
                    Else
                        SqlConsulta = "INSERT INTO FraseP (Codigo ,  Descripcion, DescripcionII, DescripcionIII, Observa) values ('" + txtCodigo.Text.Trim() + " ', '" + txtDescripcion.Text.Substring(0, 249).Trim() + "', '" + txtDescripcion.Text.Substring(250, 100).Trim() + "', '" + txtDescripcion.Text.Substring(350, 100).Trim() + "', '" + txtObservacion.Text.Trim() + "' "
                    End If
                Else

                    If (CantidadDeFilas > 0) Then

                        If (L = "H") Then
                            SqlConsulta = "UPDATE FraseH SET Descripcion = '" + txtDescripcion.Text.Substring(0, 249).Trim() + "' , DescripcionII = '" + txtDescripcion.Text.Substring(250, 100).Trim() + "' , DescripcionIII = '" + txtDescripcion.Text.Substring(350, 100).Trim() + "' , Observa = '" + txtObservacion.Text.Trim() + "'   WHERE Codigo = '" + txtCodigo.Text.Trim() + "'"
                        Else
                            SqlConsulta = "UPDATE FraseP SET Descripcion = '" + txtDescripcion.Text.Substring(0, 249).Trim() + "' , DescripcionII = '" + txtDescripcion.Text.Substring(250, 100).Trim() + "' , DescripcionIII = '" + txtDescripcion.Text.Substring(350, 100).Trim() + "' , Observa = '" + txtObservacion.Text.Trim() + "'   WHERE Codigo = '" + txtCodigo.Text.Trim() + "'"
                        End If
                    End If

                End If
                ExecuteNonQueries(SqlConsulta)
                btnLimpiar_Click(Nothing, Nothing) ' Uso el boton limpiar
                txtCodigo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click
        Try
            Dim TieneElRegistro As Integer = ContieneAlgoLaBase()
            If (txtCodigo.Text <> "") Then
                If (TieneElRegistro > 0) Then
                    Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                    cn.Open()
                    Dim SqlConsulta As String
                    If (L = "H") Then
                        SqlConsulta = "DELETE  FROM FraseH WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    Else
                        SqlConsulta = "DELETE  FROM Frasep WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    End If
                    ExecuteNonQueries(SqlConsulta)
                End If
                btnLimpiar_Click(Nothing, Nothing) ' Uso el boton limpiar
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function ContieneAlgoLaBase() As Integer
  
        Dim SqlConsulta As String
        If (L = "H") Then
            SqlConsulta = "SELECT Codigo FROM FraseH WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
        Else
            SqlConsulta = "SELECT Codigo FROM FraseP WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
        End If
        Return GetAll(SqlConsulta).Rows.Count
    End Function

    Private Sub btnListar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnListar.Click
        pnlListar.Visible = True

        Dim SqlConsulta As String

        If (L = "H") Then
            SqlConsulta = "SELECT Codigo, Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII), Observa FROM FraseH"
        Else
            SqlConsulta = "SELECT Codigo, Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII), Observa FROM FraseP"
        End If

        Dim tabla As DataTable = GetAll(SqlConsulta)

        DGV_ListadoI.DataSource = tabla

    End Sub

    Private Sub btnVolPnlListar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolPnlListar.Click
        txtBuscadorListar.Text = ""
        pnlListar.Visible = False
    End Sub

    Private Sub txtBuscadorListar_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBuscadorListar.KeyUp
        Try

            Dim tabla As DataTable = TryCast(DGV_ListadoI.DataSource, DataTable)

            tabla.DefaultView.RowFilter = "Codigo like '%" & txtBuscadorListar.Text & "%' OR Descripcion Like '%" & txtBuscadorListar.Text & "%'"

        Catch ex As Exception
            MsgBox("se petio")
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        With New VistaPrevia
            If (L = "H") Then
                .Reporte = New ReporteListadoFrasesH()
            Else
                .Reporte = New ReporteListadosP()
            End If
            .Mostrar()
        End With
    End Sub

    Private Sub DGV_ListadoI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListadoI.CellDoubleClick
        Try

            txtCodigo.Text = DGV_ListadoI.CurrentRow.Cells("Codigo").Value
            txtObservacion.Text = DGV_ListadoI.CurrentRow.Cells("Observa").Value

            Dim SQLCnslt As String

            If (L = "H") Then

                SQLCnslt = "SELECT  Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII) FROM FraseH WHERE Codigo = '" & txtCodigo.Text & "'"

            Else
                SQLCnslt = "SELECT  Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII) FROM FraseP WHERE Codigo = '" & txtCodigo.Text & "'"
            End If

            Dim row As DataRow = GetSingle(SQLCnslt)
            If row IsNot Nothing Then
                txtDescripcion.Text = row.Item("Descripcion")
            End If

            btnVolPnlListar_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub HojaIngresoFrases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = ""
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class