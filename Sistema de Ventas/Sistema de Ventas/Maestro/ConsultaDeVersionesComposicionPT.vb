Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class ConsultaDeVersionesComposicionPT : Implements IConsultaTerminado




    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub mastxtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtProducto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtProducto.Text.Length = 12 Then
                    Dim SQLCnslt As String = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & UCase(mastxtProducto.Text) & "'"
                    Dim Row As DataRow = GetSingle(SQLCnslt)
                    If Row IsNot Nothing Then
                        txtDescripcion.Text = UCase(Row.Item("Descripcion"))
                        txtVersion.Focus()
                    End If
                End If
            Case Keys.Escape
                mastxtProducto.Text = ""
        End Select
    End Sub

    Private Sub txtVersion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVersion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtVersion.Text <> "" Then
                    Dim SQLCnslt As String = "SELECT FechaInicio, FechaFinal FROM ComposicionVersion WHERE Terminado = '" & UCase(mastxtProducto.Text) & "' AND Version = '" & txtVersion.Text & "'"
                    Dim Row As DataRow = GetSingle(SQLCnslt)
                    If Row IsNot Nothing Then
                        txtFechaInicial.Text = Row.Item("FechaInicio")
                        txtFechaFinal.Text = Row.Item("FechaFinal")
                        Carga_DGV_Composicion()
                    End If
                End If
            Case Keys.Escape
                txtVersion.Text = ""
        End Select
    End Sub



    Private Sub Carga_DGV_Composicion()
        Try
            DGV_Composicion.Rows.Clear()
            Dim SQLCnslt As String = "SELECT Tipo, Articulo1, Articulo2, Cantidad, Referencia, Observaciones1, Observaciones2 " _
                                    & "FROM ComposicionVersion WHERE Terminado = '" & UCase(mastxtProducto.Text) & "' AND " _
                                    & "Version = '" & txtVersion.Text & "' ORDER BY Clave"
            Dim tablaComposicion As DataTable = GetAll(SQLCnslt)
            If tablaComposicion.Rows.Count > 0 Then
                For Each row As DataRow In tablaComposicion.Rows
                    Dim DescripcionAux As String = ""
                    If row.Item("Tipo") = "M" Then
                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & row.Item("Articulo1") & "'"
                        Dim RowArticulo As DataRow = GetSingle(SQLCnslt)
                        If RowArticulo IsNot Nothing Then
                            DescripcionAux = RowArticulo.Item("Descripcion")
                        End If
                    Else
                        SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & row.Item("Articulo2") & "'"
                        Dim RowTerminado As DataRow = GetSingle(SQLCnslt)
                        If RowTerminado IsNot Nothing Then
                            DescripcionAux = RowTerminado.Item("Descripcion")
                        End If
                    End If

                    DGV_Composicion.Rows.Add(row.Item("Tipo"), row.Item("Articulo1"), row.Item("Articulo2"), DescripcionAux, formatonumerico(row.Item("Cantidad"), 4))
                    txtRefLaboratorio.Text = row.Item("Referencia")
                    txtObservaciones.Text = Trim(row.Item("Observaciones1")) & Trim(row.Item("Observaciones2"))
                Next
            Else
                DGV_Composicion.Rows.Clear()
                txtFechaInicial.Text = ""
                txtFechaFinal.Text = ""
                txtRefLaboratorio.Text = ""
                txtObservaciones.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        mastxtProducto.Text = ""
        txtDescripcion.Text = ""
        txtVersion.Text = ""
        txtFechaInicial.Text = ""
        txtFechaFinal.Text = ""
        txtRefLaboratorio.Text = ""
        txtObservaciones.Text = ""
        DGV_Composicion.Rows.Clear()
        mastxtProducto.Focus()
    End Sub


    Public Sub CargaDatos(Codigo As String, Descripcion As String) Implements IConsultaTerminado.CargaDatos
        mastxtProducto.Text = Codigo
        txtDescripcion.Text = Descripcion
        txtVersion.Focus()
        txtVersion.Text = ""
        txtFechaInicial.Text = ""
        txtFechaFinal.Text = ""
        txtRefLaboratorio.Text = ""
        txtObservaciones.Text = ""
        DGV_Composicion.Rows.Clear()
    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        With ConsultaTerminado
            .Show(Me)
        End With
    End Sub
End Class