Imports System.Data.SqlClient

Public Class MPPTConLote0

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As sqldataadapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteLote0
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
        Dim cm As SqlCommand = New SqlCommand("SELECT i.clave, i.Articulo, i.Terminado, i.Cantidad, Descripcion = CASE i.tipo WHEN 'M' THEN a.Descripcion ELSE t.Descripcion END, i.lote, i.Observaciones, i.Ubicacion, Empresa = '" & WEmpresa & "', i.Tipo, i.Talon, i.Numero from Inventario i LEFT OUTER JOIN Articulo a ON a.Codigo = i.Articulo LEFT OUTER JOIN Terminado t ON t.Codigo = i.Terminado WHERE NOT (i.Articulo = '  -   -   ' AND i.Terminado = '  -     -   ') AND i.Lote = '0' order by Clave")

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