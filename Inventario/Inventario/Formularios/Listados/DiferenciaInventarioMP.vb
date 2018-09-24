Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class DiferenciaInventarioMP

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ckAbrirPorLotes.Checked Then
            _ReportePorLotes()
            Exit Sub
        End If

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As SqlDataAdapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioMP
        rpt.SetDataSource(ds)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt

        frm.Formula = "{Detalles.Articulo} IN '" & txtDesde.Text & "' TO '" & txtHasta.Text & "'"
        frm.Refresh()

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Mostrar()
        End If

    End Sub

    Private Sub _ReportePorLotes()
        Dim WEntradas, WSalidas As Double
        Dim WTabla As DataTable = (New DSDiferenciaInventario()).Tables("Detalles").Clone

        WEntradas = WSalidas = 0.0

        Dim WArticulos As DataTable '= Query.GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion  FROM Articulo WHERE Codigo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Codigo", Conexion.EmpresaDeTrabajo)
        WArticulos = GetAll("SELECT Distinct i.Articulo, i.Lote, ISNULL(a.Descripcion, '') Descripcion FROM Inventario i INNER JOIN Articulo a ON i.Articulo = a.Codigo WHERE i.Tipo = 'M' order by i.Articulo", Conexion.EmpresaDeTrabajo)

        For Each WArticulo As DataRow In WArticulos.Rows
            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            Dim WLaudos As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Liberada), 0) As Entrada FROM Laudo WHERE Saldo <> 0 And Marca <> 'X' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Laudo = '" & WArticulo.Item("Lote") & "'", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WLaudos) Then
                WEntradas += WLaudos.Item("Entrada")
            End If

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = Query.GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' AND (Marca <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218) AND (Lote1 = '" & WArticulo.Item("Lote") & "' Or Lote2 = '" & WArticulo.Item("Lote") & "' OR Lote3 = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

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
            Dim WMovVarios As DataTable = Query.GetAll("SELECT Articulo, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Articulo, Movi ", Conexion.EmpresaDeTrabajo)

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
            Dim WGuias As DataTable = Query.GetAll("SELECT Articulo, ISNULL(Cantidad, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And (Lote = '" & WArticulo.Item("Lote") & "' Or Partida = '" & WArticulo.Item("Lote") & "')", Conexion.EmpresaDeTrabajo)

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
            Dim WMovsLaboratorio As DataTable = Query.GetAll("SELECT Articulo, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & WArticulo.Item("Articulo") & "' And Lote = '" & WArticulo.Item("Lote") & "' GROUP BY Articulo, Movi", Conexion.EmpresaDeTrabajo)

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
                .Item("Articulo") = WArticulo.Item("Articulo")
                .Item("Lote") = WArticulo.Item("Lote")
                .Item("Terminado") = ""
                .Item("Descripcion") = WArticulo.Item("Descripcion")
                .Item("Stock") = WEntradas - WSalidas
                .Item("Inventario") = 0
                .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A")
            End With

            WTabla.Rows.Add(r)

        Next

        For Each row As DataRow In WTabla.Rows

            Dim WInve As DataRow = Query.GetSingle("SELECT ISNULL(SUM(Cantidad), 0) Cantidad FROM Inventario WHERE Articulo = '" & row.Item("Articulo") & "' And Lote = '" & row.Item("Lote") & "' GROUP BY Articulo, Lote", Conexion.EmpresaDeTrabajo)

            If Not IsNothing(WInve) Then

                row.Item("Inventario") = Val(Helper.formatonumerico(WInve.Item("Cantidad")))

            End If

        Next

        'Dim ds As New DSDiferenciaInventario
        'Dim WDatos As sqldataadapter = _TraerDatos()
        'WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioMPAbiertoLotes
        rpt.SetDataSource(WTabla)

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

        If ckSoloInventariados.Checked Then
            cm.CommandText = "select a.Codigo as Articulo, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Articulo a INNER JOIN Inventario i ON i.Articulo = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas order by a.Codigo"
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

    Private Sub DiferenciaInventarioMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Text = "AA-000-000"
        txtHasta.Text = "ZZ-999-999"
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
        With txtHasta
            If e.KeyData = Keys.Enter Then
                If Trim(.Text.Replace("-", "")) = "" Then : Exit Sub : End If
                If .Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

                .Text = .Text.ToUpper

            ElseIf e.KeyData = Keys.Escape Then
                .Text = ""
            End If
        End With
    End Sub

    Private Sub DiferenciaInventarioMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub
End Class