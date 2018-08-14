
Imports Inventario.Clases

Public Class DiferenciaInventarioPTStockAnterior

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim WEntradas, WSalidas, WInventario As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        Enabled = False

        Dim WTerminados As DataTable = Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion, Entradas, Salidas FROM Terminado WHERE Codigo LIKE 'PT-%' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)

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

        Enabled = True

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
    End Sub
End Class