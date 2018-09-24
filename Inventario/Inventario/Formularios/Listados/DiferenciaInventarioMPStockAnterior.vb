Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class DiferenciaInventarioMPStockAnterior

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim WEntradas, WSalidas As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        WEntradas = WSalidas = 0.0

        Dim WArticulos As DataTable = Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion  FROM Articulo WHERE Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)

        If ckSoloInventariado.Checked Then
            WArticulos = GetAll("SELECT i.Codigo, ISNULL(a.Descripcion, '') Descripcion FROM Inventario i INNER JOIN Articulo a ON i.Articulo = a.Codigo WHERE i.Tipo = 'M'")
        End If

        With ProgressBar1
            .Value = 0
            .Maximum = (WArticulos.Rows.Count * 2) + 5
            .Step = 1
        End With

        For Each WArticulo As datarow In WArticulos.Rows
            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            Dim WLaudos As DataRow = Query.GetSingle("SELECT ISNULL(SUM(LiberadaAnt), 0) As Entrada FROM Laudo WHERE MarcaAnt <> 'X' AND Articulo = '" & WArticulo.Item("Codigo") & "'", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WLaudos) Then
                WEntradas += WLaudos.Item("Entrada")
            End If

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) As Salida FROM Hoja WHERE Tipo = 'M' AND Articulo = '" & WArticulo.Item("Codigo") & "' AND (MarcaAnt <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218)", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WHojas) Then
                WSalidas += WHojas.Item("Salida")
            End If

            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = Query.GetAll("SELECT Articulo, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Codigo") & "' GROUP BY Articulo, Movi ", Conexion.EmpresaDeTrabajo)

            For Each WMovVario As DataRow In WMovVarios.Rows

                With WMovVario

                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If

                End With

            Next

            '
            ' Calculamos las Entradas y Salidas por Guías.
            '
            Dim WGuias As DataTable = Query.GetAll("SELECT Articulo, ISNULL(SUM(Cantidad), 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Codigo") & "' GROUP BY Articulo, Movi", Conexion.EmpresaDeTrabajo)

            For Each WGuia As DataRow In WGuias.Rows

                With WGuia
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With

            Next

            '
            ' Calculamos Entradas y Salidas por Movimientos de Laboratorio.
            '
            Dim WMovsLaboratorio As DataTable = Query.GetAll("SELECT Articulo, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Codigo") & "' GROUP BY Articulo, Movi", Conexion.EmpresaDeTrabajo)

            For Each WMovLab As DataRow In WMovsLaboratorio.Rows
                With WMovLab
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With
            Next

            '
            ' Grabamos la fila para pasar al Reporte.
            '
            Dim r As DataRow = WTabla.NewRow

            With r
                .Item("Articulo") = WArticulo.Item("Codigo")
                .Item("Terminado") = ""
                .Item("Descripcion") = WArticulo.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = 0
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

            ProgressBar1.Increment(1)

        Next

        For Each row As DataRow In WTabla.Rows

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Articulo = '" & row.Item("Articulo") & "' GROUP BY Articulo", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                row.Item("Inventario") = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

            ProgressBar1.Increment(1)

        Next

        'Dim ds As New DSDiferenciaInventario
        'Dim WDatos As sqldataadapter = _TraerDatos()
        'WDatos.Fill(ds, "Detalles")
        
        Dim rpt As New ReporteDiferenciaInventarioStockAnteriorMP
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

    Private Sub DiferenciaInventarioMPStockAnterior_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        txtDesde.Text = "AA-000-000"
        txtHasta.Text = "ZZ-999-999"
        ckSoloInventariado.Checked = False
    End Sub

    Private Sub DiferenciaInventarioMPStockAnterior_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtDesde.Text = txtDesde.Text.ToUpper

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtHasta.Text = txtHasta.Text.ToUpper

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub
End Class