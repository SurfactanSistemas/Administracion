Public Class ListadoDeEnsayoDePT

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        ExecuteNonQueries("Surfactan_II", {"DELETE VerificaEnsayo"})

        Dim WDatos As DataTable = _ProcesarDatos(txtDesde.Text, txtHasta.Text, "Surfactan_II")

        With New VistaPrevia
            .Base = "SURFACTAN_II"
            .Reporte = New ReporteListadoEnsayosPT()
            .Reporte.SetDataSource(WDatos)

            If rabPantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

    Private Function _ProcesarDatos(ByVal Desde As String, ByVal Hasta As String, ByVal Base As String) As DataTable
        Dim WDatos As DataTable = New DBAuxi.VerificaEnsayosDataTable
        Dim WDatosI As DataTable

        Dim WColumnasI, WFiltroI, WFiltroII As String

        For i = 1 To 10
            WFiltroI &= String.Format("e.Ensayo{0} BETWEEN '{1}' And '{2}' OR ", i, Desde, Hasta)
            WColumnasI &= String.Format("e.Ensayo{0}, e.Valor{0}, e.Valor{0}{0},", i)
        Next

        WFiltroI = WFiltroI.Trim.Substring(0, WFiltroI.Trim.LastIndexOf("OR"))
        WColumnasI = WColumnasI.Trim.TrimEnd(",")

        WFiltroII = ""

        If Not ckPt.Checked And Not ckSe.Checked And Not ckNk.Checked Then
            ckPt.Checked = True
            ckSe.Checked = True
            ckNk.Checked = True
        End If

        If ckPt.Checked Then WFiltroII &= "'PT',"
        If ckSe.Checked Then WFiltroII &= "'SE',"
        If ckNk.Checked Then WFiltroII &= "'NK',"

        If WFiltroII.Trim.EndsWith(",") Then WFiltroII = WFiltroII.Trim.TrimEnd(",")

        WDatosI = GetAll("SELECT e.Producto, a.Descripcion, " & WColumnasI & " FROM EspecifUnifica e INNER JOIN Terminado a ON a.Codigo = e.Producto WHERE LEFT(e.Producto, 2) IN (" & WFiltroII & ") AND (" & WFiltroI & ")", Base)

        For Each row As DataRow In WDatosI.Rows
            With row

                For i = 1 To 10
                    If OrDefault(.Item("Ensayo" & i), 0) >= Val(Desde) And OrDefault(.Item("Ensayo" & i), 0) <= Val(Hasta) Then
                        Dim r As DataRow = WDatos.NewRow

                        r.Item("Ensayo") = Trim(OrDefault(.Item("Ensayo" & i), 0))
                        r.Item("DescEnsayo") = "" '
                        r.Item("Producto") = Trim(OrDefault(.Item("Producto"), "")).ToUpper
                        r.Item("Descripcion") = Trim(OrDefault(.Item("Descripcion"), "")).ToUpper
                        r.Item("Resultado") = Trim(OrDefault(.Item("Valor" & i), "")) & " " & Trim(OrDefault(.Item("Valor" & i & i), ""))
                        r.Item("Resultado") = r.Item("Resultado").ToString.Trim
                        WDatos.Rows.Add(r)
                    End If
                Next

            End With
        Next

        Dim WEnsayos As DataTable = (New DataView(WDatos)).ToTable(True, "Ensayo")

        For Each row As DataRow In WEnsayos.Rows
            Dim WDescripcion As String = ""
            Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & row.Item("Ensayo") & "'", Base)

            If WEnsayo IsNot Nothing Then
                WDescripcion = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                For Each r As DataRow In WDatos.Select("Ensayo = " & row.Item("Ensayo"))
                    r.Item("DescEnsayo") = WDescripcion.ToUpper
                Next
            End If
        Next

        Return WDatos

    End Function

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtDesde.Text) = 0 Then Exit Sub

                lblDescEnsayoI.Text = _TraerDescripcionEnsayo(txtDesde.Text)

                txtHasta.Focus()

            Case Keys.Escape
                txtDesde.Text = ""
        End Select
    End Sub

    Private Function _TraerDescripcionEnsayo(ByVal Ensayo As String)

        Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo & "'", "Surfactan_II")

        Return IIf(WEnsayo IsNot Nothing, OrDefault(WEnsayo.Item("Descripcion"), ""), "").ToString.Trim.ToUpper

    End Function
    
    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtHasta.Text) = 0 Then txtHasta.Text = txtDesde.Text
                lblDescEnsayoII.Text = _TraerDescripcionEnsayo(txtHasta.Text)

                txtDesde.Focus()

            Case Keys.Escape
                txtHasta.Text = ""
        End Select
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesde.KeyPress, txtHasta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ListadoDeEnsayoDePT_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub
End Class