Imports SAC.Clases

Public Class MenuPrincipal

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Login.Dispose()
        Close()
    End Sub

    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Val(Operador.CodigoResponsableSac) = 0 Or Val(Operador.Codigo) = 3 Or Val(Operador.Codigo) = 21 Then
            For Each i As ToolStripMenuItem In {TiposDeSolicitudToolStripMenuItem, ResponsablesToolStripMenuItem}
                i.Enabled = False
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Login.Show()
        Close()
    End Sub

    Private Sub TiposDeSolicitudToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TiposDeSolicitudToolStripMenuItem.Click
        Abrir(New ListadoTiposSolicitud)
    End Sub

    Private Sub ResponsablesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ResponsablesToolStripMenuItem.Click
        Abrir(New ListadoResponsablesSAC)
    End Sub

    Private Sub CentrosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CentrosToolStripMenuItem.Click
        Abrir(New ListadoCentros)
    End Sub

    Private Sub IndiceGeneralDeAccionesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IndiceGeneralDeAccionesToolStripMenuItem.Click
        Abrir(New IndiceGralSac)
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim WGuiasOrigen As DataTable = GetAll("SELECT * FROM Guia WHERE FechaOrd >= '20180801' And upper(Movi) = 'S' Order by Codigo", ComboBox1.SelectedItem)
        Dim WGuiasAImprimir As DataTable = WGuiasOrigen.Clone

        ProgressBar1.Maximum = WGuiasOrigen.Rows.Count
        ProgressBar1.Value = 0

        DataGridView1.DataSource = Nothing

        For Each WGuiaOrig As DataRow In WGuiasOrigen.Rows

            With WGuiaOrig

                Dim WEmpr As String = Conexion.DeterminarSegunIDIDBasePara(.Item("Destino"))

                If Trim(WEmpr) = "" Or {2, 4, 8, 9}.Contains(.Item("Destino")) Then Continue For

                Dim WGuiaDestino As DataRow = Nothing

                If .Item("Tipo") = "M" Then
                    WGuiaDestino = GetSingle("SELECT Clave FROM Guia WHERE Codigo = '" & .Item("Codigo") & "' AND Articulo = '" & .Item("Articulo") & "'", WEmpr)
                Else
                    WGuiaDestino = GetSingle("SELECT Clave FROM Guia WHERE Codigo = '" & .Item("Codigo") & "' AND Terminado = '" & .Item("Terminado") & "'", WEmpr)
                End If

                If WGuiaDestino Is Nothing Then
                    WGuiasAImprimir.ImportRow(WGuiaOrig)
                End If

            End With

            ProgressBar1.Increment(1)
        Next

        DataGridView1.DataSource = WGuiasAImprimir

        ProgressBar1.Value = 0

    End Sub

    Private Sub ListadoDeIncidenciasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeIncidenciasToolStripMenuItem.Click
        Abrir(New ListadoIncidencias)
    End Sub
End Class
