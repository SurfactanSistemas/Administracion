Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient

Public Class HojaIngresoFrases
    Protected L As Char ' Variable que define de que opcion del menu entro




    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyData = Keys.Enter Then
            If (txtCodigo.Text <> "") Then
                Try
                    Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                    cn.Open()
                    Dim SqlConsulta As String
                    If (L = "H") Then

                        SqlConsulta = "SELECT * FROM FraseH WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    Else


                        SqlConsulta = "SELECT * FROM FraseP WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
                    End If

                    Dim cmd As New SqlCommand(SqlConsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr)
                    If (tabla.Rows.Count > 0) Then
                        txtDescripcion.Text = Trim(tabla.Rows(0).Item("Descripcion").ToString() & tabla.Rows(0).Item("DescripcionII") & tabla.Rows(0).Item("DescripcionIII"))
                        txtObservacion.Text = Trim(tabla.Rows(0).Item("Observa"))
                        cn.Close()
                    End If

                Catch ex As Exception
                    MsgBox("no conecto")
                End Try
            End If

        End If
        If e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtObservacion.Focus()
        End If
        If e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCodigo.Focus()
        End If
        If e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtObservacion.Text = ""
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If (txtCodigo.Text <> "") Then
            Try
                Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
                cn.Open()
                Dim SqlConsulta As String
                Dim CantidadDeFilas As Integer = ContieneAlgoLaBase()
                If (CantidadDeFilas = 0) Then
                    txtDescripcion.Text = txtDescripcion.Text.Trim().PadRight(450, " ") 'Rellenamos los espacios vacio con " " para poder hacer el substring
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

                Dim cmd As New SqlCommand(SqlConsulta, cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                btnLimpiar_Click(Nothing, Nothing) ' Uso el boton limpiar
                txtCodigo.Focus()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
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
                    Dim cmd As New SqlCommand(SqlConsulta, cn)
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If
                btnLimpiar_Click(Nothing, Nothing) ' Uso el boton limpiar
                txtCodigo.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function ContieneAlgoLaBase() As Integer
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
        cn.Open()
        Dim SqlConsulta As String
        If (L = "H") Then

            SqlConsulta = "SELECT * FROM FraseH WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
        Else


            SqlConsulta = "SELECT * FROM FraseP WHERE Codigo = '" + txtCodigo.Text.ToString().Trim() + "' "
        End If
        Dim cmd As New SqlCommand(SqlConsulta, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim tabla As New DataTable

        tabla.Load(dr)
        Return tabla.Rows.Count()
    End Function

    Private Sub btnListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListar.Click
        pnlListar.Visible = True
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("LOCAL").ToString())
        cn.Open()
        Dim SqlConsulta As String
        If (L = "H") Then

            SqlConsulta = "SELECT Codigo, Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII), Observa FROM FraseH"
        Else


            SqlConsulta = "SELECT Codigo, Descripcion = TRIM(Descripcion) + ' ' + TRIM(DescripcionII) + ' ' + TRIM(DescripcionIII), Observa FROM FraseP"
        End If
        Dim cmd As New SqlCommand(SqlConsulta, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim tabla As New DataTable
        tabla.Load(dr)
        DGV_ListadoI.DataSource = tabla

    End Sub

    Private Sub btnVolPnlListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolPnlListar.Click
        pnlListar.Visible = False
    End Sub

    Private Sub txtBuscadorListar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscadorListar.KeyUp
        Try

            Dim tabla As DataTable = TryCast(DGV_ListadoI.DataSource, DataTable)

            tabla.DefaultView.RowFilter = "Codigo like '%" & txtBuscadorListar.Text & "%' OR Descripcion Like '%" & txtBuscadorListar.Text & "%'"

        Catch ex As Exception
            MsgBox("se petio")
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        With New VistaPrevia
            If (L = "H") Then
                .Reporte = New ReporteListadoFrasesH()
            Else
                .Reporte = New ReporteListadosP()
            End If
            .Mostrar()
        End With
    End Sub
End Class