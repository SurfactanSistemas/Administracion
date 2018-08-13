Imports System.Data.SqlClient

Public Class DiferenciaInventarioMP

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As sqldataadapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioMP
        rpt.SetDataSource(ds)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Show(Me)
        End If

    End Sub

    Private Function _TraerDatos() As SqlDataAdapter

        Dim WEmpresa As String = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A.")
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("select a.Codigo as Articulo, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Articulo a LEFT OUTER JOIN Inventario i ON i.Articulo = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas order by a.Codigo")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            Dim dr As New SqlDataAdapter(cm)

            Return dr

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            'dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function
End Class