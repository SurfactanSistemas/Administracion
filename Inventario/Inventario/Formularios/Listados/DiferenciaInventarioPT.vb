Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class DiferenciaInventarioPT

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ckAbiertoPorLotes.Checked Then
            _ReportePorLotes()
            Exit Sub
        End If

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As sqldataadapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioPT
        rpt.SetDataSource(ds)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt
        frm.Formula = "{Detalles.Terminado} IN '" & txtDesde.Text & "' TO '" & txtHasta.Text & "'"

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Mostrar()
        End If

    End Sub

    Private Function _TraerDatos() As SqlDataAdapter

        Dim WEmpresa As String = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A.")
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("select a.Codigo as Terminado, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Terminado a LEFT OUTER JOIN Inventario i ON i.Terminado = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas HAVING LEFT(UPPER(a.Codigo), 2) IN ('PT', 'SE', 'RE', 'NK', 'YQ') AND NOT ((a.Entradas - a.Salidas) = 0 AND ISNULL(SUM(i.Cantidad), 0) = 0) order by a.Codigo")

        If ckSoloInventariados.Checked Then
            cm.CommandText = "select a.Codigo as Terminado, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Terminado a INNER JOIN Inventario i ON i.Terminado = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas HAVING LEFT(UPPER(a.Codigo), 2) IN ('PT', 'SE', 'RE', 'NK', 'YQ') AND NOT ((a.Entradas - a.Salidas) = 0 AND ISNULL(SUM(i.Cantidad), 0) = 0) order by a.Codigo"
        End If

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

    Private Sub _ReportePorLotes()
        Dim WEntradas, WSalidas As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        WEntradas = WSalidas = 0.0

        Dim WArticulos As DataTable '= Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion  FROM Articulo WHERE Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)
        WArticulos = GetAll("SELECT Distinct i.Terminado, i.Lote, ISNULL(t.Descripcion, '') Descripcion FROM Inventario i INNER JOIN Terminado t ON i.Terminado = t.Codigo WHERE i.Tipo = 'T' order by i.Terminado", Conexion.EmpresaDeTrabajo)

        For Each WArticulo As DataRow In WArticulos.Rows
            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            'Dim WLaudos As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Liberada), 0) As Entrada FROM Laudo WHERE Saldo <> 0 And Marca <> 'X' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Laudo = '" & WArticulo.Item("Lote") & "'", Conexion.EmpresaDeTrabajo)

            'If Not IsNothing(WLaudos) Then
            '    WEntradas += WLaudos.Item("Entrada")
            'End If

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = Query.GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' AND (Marca <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218) AND (Lote1 = '" & WArticulo.Item("Lote") & "' Or Lote2 = '" & WArticulo.Item("Lote") & "' OR Lote3 = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WHojas) Then
                For Each row As datarow In WHojas.Rows
                    With row
                        For i = 1 To 3
                            Dim WLote As Integer = OrDefault(.Item("Lote" & i), 0)

                            If WLote = 0 Then Continue For

                            If Val(WArticulo.Item("Lote")) = WLote Then
                                WSalidas += OrDefault(.Item("Canti" & i), 0)
                            End If
                        Next
                    End With
                Next
            End If

            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = Query.GetAll("SELECT Terminado, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Terminado, Movi ", Conexion.EmpresaDeTrabajo)

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
            Dim WGuias As DataTable = Query.GetAll("SELECT Terminado, ISNULL(Cantidad, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And (Lote = '" & WArticulo.Item("Lote") & "' Or Partida = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

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
            Dim WMovsLaboratorio As DataTable = Query.GetAll("SELECT Terminado, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & WArticulo.Item("Terminado") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Terminado, Movi", Conexion.EmpresaDeTrabajo)

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
                .Item("Articulo") = ""
                .Item("Lote") = WArticulo.Item("Lote")
                .Item("Terminado") = WArticulo.Item("Terminado")
                .Item("Descripcion") = WArticulo.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = 0
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

        Next

        For Each row As DataRow In WTabla.Rows

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Terminado = '" & row.Item("Terminado") & "' And Lote = '" & row.Item("Lote") & "' GROUP BY Terminado, Lote", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                row.Item("Inventario") = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

        Next

        'Dim ds As New DSDiferenciaInventario
        'Dim WDatos As sqldataadapter = _TraerDatos()
        'WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioPTAbiertoLotes
        rpt.SetDataSource(WTabla)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Show(Me)
        End If

    End Sub


    Private Sub LimpiarIngresoInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Text = "AA-00000-000"
        txtHasta.Text = "ZZ-99999-999"
    End Sub

    Private Sub DiferenciaInventarioPT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
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