Imports ConsultasVarias
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class Consulta_de_revisiones_de_ensayos: Implements IConsulta_Orden_Trabajo


    Private Sub mastxtOrdenTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtOrdenTrabajo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtOrdenTrabajo.Text <> "" Then
                    Dim SQLCnslt As String = "SELECT Fecha, FechaEntrega, Cliente, Observaciones FROM OrdenTrabajo " _
                                            & "WHERE Orden = '" & mastxtOrdenTrabajo.Text & "'"

                    Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

                    If row IsNot Nothing Then
                        txtFecha.Text = row.Item("Fecha")
                        txtFechaEntraga.Text = row.Item("FechaEntrega")
                        txtCliente.Text = row.Item("Cliente")
                        txtObservaciones.Text = row.Item("Observaciones")
                        Buscar_Descripcion_Cliente()
                        CargaGrid()
                    End If
                End If
            Case Keys.Escape
                mastxtOrdenTrabajo.Text = ""
        End Select
    End Sub

    Private Sub Buscar_Descripcion_Cliente()
        Dim SQLCnslt As String = "SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'"
        Dim row As DataRow = GetSingle(SQLCnslt)
        If row IsNot Nothing Then
            txtDescripcion.Text = row.Item("Razon")
        End If
    End Sub

    Private Sub CargaGrid()
        DGV_Ensayos.Rows.Clear()
        Dim SQLCnslt As String = "SELECT Version, Etapa, Fecha, Participantes, Resultados, Acciones, Responsables, Estado " _
                               & " FROM CargaEnsayoV WHERE Orden = '" & mastxtOrdenTrabajo.Text & "' ORDER BY Clave"
        Dim tabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")

        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                With row
                    DGV_Ensayos.Rows.Add(Trim(.Item("Version")), Trim(.Item("Etapa")), Trim(.Item("Fecha")), Trim(.Item("Participantes")), Trim(.Item("Resultados")), Trim(.Item("Acciones")), Trim(.Item("Responsables")), Trim(.Item("Estado")))
                End With
            Next

        End If

    End Sub

    Private Sub Consulta_de_revisiones_de_ensayos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mastxtOrdenTrabajo.Focus()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        mastxtOrdenTrabajo.Text = ""
        txtFecha.Text = ""
        txtFechaEntraga.Text = ""
        txtCliente.Text = ""
        txtDescripcion.Text = ""
        txtObservaciones.Text = ""
        DGV_Ensayos.Rows.Clear()
        mastxtOrdenTrabajo.Focus()
    End Sub

    Private Sub btnConsultaOrden_Click(sender As Object, e As EventArgs) Handles btnConsultaOrden.Click
        With Consulta_Orden_Trabajo
            .Show(Me)
        End With
    End Sub

    Public Sub PasarDatos(Codigo As String) Implements IConsulta_Orden_Trabajo.PasarDatos
        mastxtOrdenTrabajo.Text = Codigo
        mastxtOrdenTrabajo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub
End Class