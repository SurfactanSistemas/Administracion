Imports System.Configuration
Imports System.Data.SqlClient

Public Class ListadoEspecifPTFecha



    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub mastxtFechaDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFechaDesde.KeyDown
        If (Trim(mastxtFechaDesde.Text.Replace("/", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    If (IsDate(mastxtFechaDesde.Text)) Then
                        mastxtFechaHasta.Focus()
                    Else
                        MsgBox("No es una fecha valida")
                    End If
                Case Keys.Escape
                    mastxtFechaDesde.Text = ""

            End Select
        End If
    End Sub

    Private Sub mastxtFechaHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFechaHasta.KeyDown
        If (Trim(mastxtFechaHasta.Text.Replace("/", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    If (IsDate(mastxtFechaHasta.Text)) Then
                        mastxtDePT.Focus()
                    Else
                        MsgBox("No es una fecha valida")
                    End If
                Case Keys.Escape
                    mastxtFechaHasta.Text = ""


            End Select
        End If
    End Sub

    Private Sub mastxtDePT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtDePT.KeyDown
        If (Trim(mastxtDePT.Text.Replace("-", "")) <> "") Then
            Select Case e.KeyData
                Case Keys.Enter
                    mastxtAPT.Focus()

                Case Keys.Escape
                    mastxtDePT.Text = ""
            End Select
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (IsDate(mastxtFechaDesde.Text)) Then
            If (IsDate(mastxtFechaHasta.Text)) Then


                If (Trim(mastxtDePT.Text.Replace("-", "")) = "") Then
                    mastxtDePT.Text = "AA-00000-000"
                End If


                If (Trim(mastxtAPT.Text.Replace("-", "")) = "") Then
                    mastxtAPT.Text = "ZZ-99999-999"
                End If


                Try
                    Dim cn As New SqlConnection(Helper._ConectarA("surfactan_II"))
                    cn.Open()
                    Dim sqlconsulta As String
                    Dim tablaListadoExpecif As New DataTable
                    With tablaListadoExpecif.Columns
                        .Add("Titulo")
                        .Add("Producto")
                        .Add("Descripcion")
                        .Add("Version")
                        .Add("Fecha")
                    End With
                    Dim FechaDesde As String = ordenaFecha(mastxtFechaDesde.Text.Trim())
                    Dim FechaHasta As String = ordenaFecha(mastxtFechaHasta.Text.Trim())
                    sqlconsulta = "SELECT Producto, Fecha, Version FROM EspecifUnifica where RIGHT(fecha, 4) + '' + SUBSTRING(Fecha, 4, 2) + left(Fecha, 2) between '" & FechaDesde & "' and '" & FechaHasta & "' and Producto between '" & mastxtDePT.Text.Trim() & "' and '" & mastxtAPT.Text.Trim() & "' "
                    Dim cmd As New SqlCommand(sqlconsulta, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    If (dr.HasRows) Then
                        While (dr.Read())


                            Dim row As DataRow = tablaListadoExpecif.NewRow()
                            row("Producto") = dr.Item("Producto")
                            row("Fecha") = dr.Item("Fecha")
                            row("Version") = dr.Item("Version")
                            row("Titulo") = "DE " & mastxtFechaDesde.Text & " A " & mastxtFechaHasta.Text

                            tablaListadoExpecif.Rows.Add(row)
                        End While
                        dr.Close()

                        Dim sqlconsulta2 As String = "SELECT Descripcion , Codigo FROM Terminado"
                        Dim cmd2 As New SqlCommand(sqlconsulta2, cn)
                        dr = cmd2.ExecuteReader()
                        If (dr.HasRows) Then
                            While (dr.Read())
                                For i As Integer = 0 To tablaListadoExpecif.Rows.Count - 1
                                    If (Trim(UCase(tablaListadoExpecif.Rows(i)("Producto"))) = Trim(dr.Item("Codigo"))) Then
                                        tablaListadoExpecif.Rows(i)("Descripcion") = dr.Item("Descripcion")
                                    End If
                                Next
                            End While
                        End If
                    End If

                    With New VistaPrevia
                        .Reporte = New ReporteListadoEspecifPTaFecha()
                        .Reporte.SetDataSource(tablaListadoExpecif)

                        If (rabPantalla.Checked = True) Then
                            .Mostrar()
                        Else
                            .Imprimir()
                        End If
                    End With
                Catch ex As Exception

                End Try
            Else
                MsgBox("Ingrese un valor al campo -Hasta-")
            End If
        Else
            MsgBox("Ingrese un valor al campo -Desde-")
        End If


    End Sub


    Private Sub mastxtAPT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtAPT.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                mastxtAPT.Text = ""

        End Select
    End Sub



End Class