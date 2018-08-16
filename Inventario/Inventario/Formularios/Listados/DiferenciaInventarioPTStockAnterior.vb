
Imports Inventario.Clases

Public Class DiferenciaInventarioPTStockAnterior

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim WEntradas, WSalidas, WInventario As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        Dim WTerminados As DataTable = Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion, Entradas, Salidas FROM Terminado WHERE Codigo LIKE 'PT-%' AND Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)

        With ProgressBar1
            .Value = 0
            .Maximum = WTerminados.Rows.Count + 5
            .Step = 1
        End With

        For Each WTerminado As DataRow In WTerminados.Rows
            WEntradas = 0.0
            WSalidas = 0.0
            WInventario = 0.0

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Terminado = '" & WTerminado.Item("Codigo") & "' GROUP BY Terminado", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                WInventario = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

            WEntradas = WTerminado.Item("Entradas")
            WSalidas = WTerminado.Item("Salidas")

            '
            ' Grabamos la fila para pasar al Reporte.
            '
            Dim r As DataRow = WTabla.NewRow

            With r
                .Item("Articulo") = ""
                .Item("Terminado") = WTerminado.Item("Codigo")
                .Item("Descripcion") = WTerminado.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = WInventario
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

            ProgressBar1.Increment(1)

        Next

        'Dim ds As New DSDiferenciaInventario
        'Dim WDatos As sqldataadapter = _TraerDatos()
        'WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioStockAnteriorPT
        rpt.SetDataSource(WTabla)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Show(Me)
        End If

        ProgressBar1.Value = 0

    End Sub

    Private Sub DiferenciaInventarioPTStockAnterior_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        txtDesde.Text = "AA-00000-000"
        txtHasta.Text = "ZZ-99999-999"
    End Sub

    Private Sub DiferenciaInventarioPTStockAnterior_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            txtDesde.Text = txtDesde.Text.ToUpper

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            txtHasta.Text = txtHasta.Text.ToUpper
            
        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub
End Class