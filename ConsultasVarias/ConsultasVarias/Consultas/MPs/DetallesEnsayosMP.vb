Public Class DetallesEnsayosMP
    Private WLote As String = ""
    
    Sub New(ByVal _Lote As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WLote = _Lote
    End Sub

    Private Sub DetallesEnsayosMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Val(WLote) = 0 Then Close()
        txtDescMP.BackColor = WBackColorTerciario
        txtProveedor.BackColor = WBackColorTerciario
        txtSaldo.BackColor = WBackColorTerciario
        DataGridView1.RowsDefaultCellStyle.BackColor = WBackColorSecundario
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = WBackColorTerciario

        For Each c As Control In {txtCantidad, txtCodigo, txtDescMP, txtFecha, txtInforme, txtLote, txtLoteProv, txtOrden, txtProveedor, DataGridView1}
            c.TabStop = False
        Next

        _ImprimeEnsayos()
    End Sub

    Private Sub _ImprimeEnsayos()
        Dim WEnsayos As New DataTable
        Dim WFecha, WProducto As String

        With WEnsayos.Columns
            .Add("Ensayo")
            .Add("ValorStd")
            .Add("ValorReg")
            .Add("Valor")
        End With

        For Each emp As String In Empresas
            Dim WDatosEnsayos As DataRow = GetSingle(String.Format("SELECT * FROM Prueart WHERE Prueba IN ('1{0}', '2{0}')", WLote.PadLeft(6, "0")), emp)

            If WDatosEnsayos Is Nothing Then Continue For

            With WDatosEnsayos
                WFecha = OrDefault(.Item("Fecha"), "")
                WProducto = OrDefault(.Item("Producto"), "")

                For i = 1 To 30

                    Dim r As DataRow = WEnsayos.NewRow

                    r.Item("Ensayo") = ""
                    r.Item("ValorStd") = ""
                    r.Item("ValorReg") = OrDefault(.Item("Valor" & i), "")
                    r.Item("Valor") = OrDefault(.Item("ValorNumero" & i), "")

                    If Trim(r.Item("ValorReg")) <> "" Then WEnsayos.Rows.Add(r)
                    'WEnsayos.Rows.Add(r)

                Next

            End With

            Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

            Dim WEspecif As DataRow = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
            End If

            Dim WSinVersion = False

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                WSinVersion = True
            End If

            If WEspecif IsNot Nothing Then

                For i = 1 To 20
                    If i <= WEnsayos.Rows.Count Then
                        If i > 10 And Not WSinVersion Then
                            WEnsayos.Rows(i - 1).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                            WEnsayos.Rows(i - 1).Item("ValorStd") = OrDefault(WEspecif.Item("ZValor" & (i - 10)), "")
                        Else
                            WEnsayos.Rows(i - 1).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                            WEnsayos.Rows(i - 1).Item("ValorStd") = OrDefault(WEspecif.Item("Valor" & i), "")
                        End If
                    End If
                Next

                Dim WClaveEspecif As String = ""

                If Not WSinVersion Then WClaveEspecif = OrDefault(WEspecif.Item("Clave"), "")

                If WClaveEspecif.Trim <> "" Or WSinVersion Then

                    If WSinVersion Then
                        WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaIII WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                    Else
                        WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersionII WHERE Clave = '{0}'", WClaveEspecif), WBaseEspecif)
                    End If

                    If WEspecif IsNot Nothing Then
                        For i = 21 To 30
                            If i <= (WEnsayos.Rows.Count) Then
                                WEnsayos.Rows(i - 1).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                                WEnsayos.Rows(i - 1).Item("ValorStd") = OrDefault(WEspecif.Item("Valor" & i), "")
                            End If
                        Next
                    End If

                End If

            End If

            For Each _e As DataRow In WEnsayos.Rows
                With _e
                    Dim WEns As DataRow = GetSingle("SELECT ISNULL(Descripcion, '') Descripcion FROM Ensayos WHERE Codigo = '" & _e.Item("Ensayo") & "'", WBaseEspecif)

                    If WEns Is Nothing Then Continue For

                    _e.Item("Ensayo") = _e.Item("Ensayo").ToString.PadLeft(4, "0") & "  " & Trim(WEns.Item("Descripcion"))

                End With
            Next

            Dim WLaudo As DataRow = GetSingle("select l.Articulo, l.Fecha, l.Informe, l.Orden, DescMP = a.Descripcion, l.Saldo, Cantidad = (l.Liberada + l.Devuelta), Proveedor = p.Nombre, LoteProv = i.PartidaProveedor from laudo l LEFT OUTER JOIN Informe i ON i.Informe = l.Informe And i.Articulo = l.Articulo LEFT OUTER JOIN Orden o ON o.Orden = i.Orden And o.Articulo = l.Articulo LEFT OUTER JOIN Proveedor p ON p.Proveedor = o.Proveedor LEFT OUTER JOIN Articulo a ON a.Codigo = l.Articulo where l.laudo = '" & WLote & "' And l.Renglon IN ('1', '01')", emp)

            If WLaudo IsNot Nothing Then
                With WLaudo
                    txtCodigo.Text = OrDefault(.Item("Articulo"), "")
                    txtFecha.Text = OrDefault(.Item("Fecha"), "")
                    txtLote.Text = WLote
                    txtDescMP.Text = OrDefault(.Item("DescMP"), "")
                    txtProveedor.Text = OrDefault(.Item("Proveedor"), "")
                    txtLoteProv.Text = OrDefault(.Item("LoteProv"), "")
                    txtInforme.Text = OrDefault(.Item("Informe"), "")
                    txtOrden.Text = OrDefault(.Item("Orden"), "")
                    txtCantidad.Text = OrDefault(.Item("Cantidad"), "")

                    txtCantidad.Text = formatonumerico(txtCantidad.Text)

                    txtSaldo.Text = _CalcularSaldoLaudo()

                End With
            End If

            Exit For

        Next

        If WEnsayos.Rows.Count = 0 Then
            MsgBox("No se encontraron resultados para poder mostrar.", MsgBoxStyle.Information)
            Button1_Click(Nothing, Nothing)
        End If

        DataGridView1.DataSource = WEnsayos

    End Sub

    Private Function _CalcularSaldoLaudo() As String
        Dim WSaldo, WEntradas, WSalidas As Double
        Dim WSalir As Boolean = False

        For Each empresa As String In Empresas

            WEntradas = 0.0
            WSalidas = 0.0

            '
            ' Calculamos las entradas de los laudos.
            '
            Dim WLaudos As DataRow = GetSingle("SELECT ISNULL(SUM(Liberada), 0) As Entrada FROM Laudo WHERE Marca <> 'X' AND Articulo = '" & txtCodigo.Text & "' And Laudo = '" & WLote & "'", empresa)

            If Not IsNothing(WLaudos) Then
                If WLaudos.Item("Entrada") <> 0 Then WSalir = True
                WEntradas += WLaudos.Item("Entrada")
            End If

            'If Not WSalir Then Continue For

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'M' AND Articulo = '" & txtCodigo.Text & "' AND Marca <> 'X' AND (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' OR Lote3 = '" & WLote & "')", empresa)

            If Not IsNothing(WHojas) Then
                For Each row As DataRow In WHojas.Rows
                    With row
                        For i = 1 To 3
                            Dim _Lote As Integer = OrDefault(.Item("Lote" & i), 0)

                            If _Lote = 0 Then Continue For

                            If Val(_Lote) = WLote Then
                                WSalidas += OrDefault(.Item("Canti" & i), 0)
                            End If
                        Next
                    End With
                Next
            End If

            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = GetAll("SELECT Articulo, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & txtCodigo.Text & "' And Lote = '" & WLote & "' GROUP BY Articulo, Movi ", empresa)

            For Each WMovVario As DataRow In WMovVarios.Rows

                With WMovVario

                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    ElseIf .Item("Movi").ToString.ToUpper = "S" Then
                        WSalidas += .Item("Cantidad")
                    End If

                End With

            Next

            '
            ' Calculamos las Entradas y Salidas por Guías.
            '
            Dim WGuias As DataTable = GetAll("SELECT Articulo, ISNULL(Cantidad, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & txtCodigo.Text & "' And (Lote = '" & WLote & "' Or Partida = '" & WLote & "')", empresa)

            For Each WGuia As DataRow In WGuias.Rows

                With WGuia
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    ElseIf .Item("Movi").ToString.ToUpper = "S" Then
                        WSalidas += .Item("Cantidad")
                    End If
                End With

            Next

            '
            ' Calculamos Entradas y Salidas por Movimientos de Laboratorio.
            '
            Dim WMovsLaboratorio As DataTable = GetAll("SELECT Articulo, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'M' AND Articulo = '" & txtCodigo.Text & "' And Lote = '" & WLote & "' GROUP BY Articulo, Movi", empresa)

            For Each WMovLab As DataRow In WMovsLaboratorio.Rows
                With WMovLab
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    ElseIf .Item("Movi").ToString.ToUpper = "S" Then
                        WSalidas += .Item("Cantidad")
                    End If
                End With
            Next

            'If WSalir Then Exit For

            WSaldo += (WEntradas - WSalidas)

        Next

        If WSaldo < 0 Then WSaldo = 0

        Return formatonumerico(WSaldo)

    End Function

    Private Sub DetallesEnsayosMP_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        Button1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class