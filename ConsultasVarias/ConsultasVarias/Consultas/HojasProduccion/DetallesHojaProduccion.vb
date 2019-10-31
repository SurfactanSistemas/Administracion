Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Globales


Public Class DetallesHojaProduccion

    Private WLote As Object = 0

    Sub New(ByVal _Lote As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WLote = _Lote

    End Sub

    Private Sub DetallesHojaProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each c As Control In {txtCodigo, txtDescTerminado, txtFecha, txtFechaIngreso, txtInicioEnv, txtInicioEnvII, txtInicioProd, txtInicioProdII, txtPartida, txtReal, txtTeorico, txtSaldo}
            c.Text = ""
            c.TabStop = False
        Next

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            column.DefaultCellStyle.BackColor = Globales.WBackColorSecundario
            column.DefaultCellStyle.SelectionBackColor = Globales.WBackColorTerciario
            column.DefaultCellStyle.SelectionForeColor = Color.White
        Next

        txtDescTerminado.BackColor = Globales.WBackColorTerciario
        txtTeorico.BackColor = Globales.WBackColorTerciario
        txtReal.BackColor = Globales.WBackColorTerciario
        txtSaldo.BackColor = WBackColorTerciario

        txtPartida.Text = WLote

        _CargarDatosHoja()

        Button1.Focus()

    End Sub

    Private Sub _CargarDatosHoja()
        For Each empresa As String In Empresas
            Dim WHoja As DataTable = GetAll("SELECT h.*, t.Descripcion FROM Hoja h LEFT OUTER JOIN Terminado t ON t.Codigo = h.Producto WHERE h.Hoja = '" & WLote & "' Order by h.Clave", empresa)

            If WHoja.Rows.Count = 0 Then Continue For

            Dim WPorSeparado(2, 3) As String

            WPorSeparado(1, 1) = "AA-100-100"
            WPorSeparado(1, 2) = "0"
            WPorSeparado(1, 3) = "AGUA POTABLE Tratada"

            WPorSeparado(2, 1) = "AR-000-100"
            WPorSeparado(2, 2) = "0"
            WPorSeparado(2, 3) = "AGUA POTABLE DE RED"

            For Each row As DataRow In WHoja.Rows
                Dim WTipo, WTerminado, WArticulo, WCantidad, WDescripcion As String

                With row
                    txtCodigo.Text = OrDefault(.Item("Producto"), "")
                    txtFecha.Text = OrDefault(.Item("Fecha"), "")
                    txtFechaIngreso.Text = OrDefault(.Item("FechaIng"), "")
                    txtTeorico.Text = OrDefault(.Item("Teorico"), "0")
                    txtReal.Text = OrDefault(.Item("Real"), "0")
                    txtInicioProd.Text = OrDefault(.Item("FechaInicio"), "")
                    txtInicioProdII.Text = OrDefault(.Item("HoraInicio"), "")
                    txtInicioEnv.Text = OrDefault(.Item("FechaFinal"), "")
                    txtInicioEnvII.Text = OrDefault(.Item("HoraFinal"), "")
                    txtDescTerminado.Text = Trim(OrDefault(.Item("Descripcion"), ""))

                    WTipo = OrDefault(.Item("Tipo"), "")
                    WTerminado = OrDefault(.Item("Terminado"), "  -     -   ")
                    WArticulo = OrDefault(.Item("Articulo"), "  -   -   ")
                    WDescripcion = ""
                End With

                If UCase(WTipo) = "M" Then
                    Dim WArt As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArticulo & "'")
                    If WArt IsNot Nothing Then WDescripcion = Trim(WArt.Item("Descripcion"))
                ElseIf UCase(WTipo) = "T" Then
                    Dim WTer As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & WTerminado & "'")
                    If WTer IsNot Nothing Then WDescripcion = Trim(WTer.Item("Descripcion"))
                End If

                Dim WEntraAComparar As String = "S"
                Dim WGenerarRenglonEnCero As String = "S"

                For i = 1 To 3

                    WCantidad = OrDefault(row.Item("Canti" & i), "0")
                    WCantidad = formatonumerico(WCantidad)
                    Dim _Lote = OrDefault(row.Item("Lote" & i), "0")

                    '
                    ' Buscamos aquellos que no se informan lotes.
                    '
                    Dim WSalir As String = "N"
                    For x = 1 To 2
                        If WArticulo = WPorSeparado(x, 1) Then
                            If Val(_Lote) = 0 And Val(WCantidad) = 0 And WEntraAComparar = "S" Then
                                WSalir = "S"
                                WPorSeparado(x, 2) += 1
                            Else
                                WEntraAComparar = "N"
                            End If
                        End If
                    Next

                    If WSalir = "S" Then Continue For

                    If Val(WCantidad) <> 0 And Val(_Lote) <> 0 Then

                        WGenerarRenglonEnCero = "N"

                        Dim r = DataGridView1.Rows.Add

                        With DataGridView1.Rows(r)
                            .Cells("Tipo").Value = WTipo
                            .Cells("Terminado").Value = IIf(i = 1 And UCase(WTipo) = "T", WTerminado, "")
                            .Cells("MateriaPrima").Value = IIf(i = 1 And UCase(WTipo) = "M", WArticulo, "")
                            .Cells("Descripcion").Value = IIf(i = 1, WDescripcion, "")
                            .Cells("LotePartida").Value = _Lote
                            .Cells("Cantidad").Value = WCantidad
                        End With

                    End If

                Next

                If WGenerarRenglonEnCero = "S" Then
                    Dim r = DataGridView1.Rows.Add

                    With DataGridView1.Rows(r)
                        .Cells("Tipo").Value = WTipo
                        .Cells("Terminado").Value = IIf(UCase(WTipo) = "T", WTerminado, "")
                        .Cells("MateriaPrima").Value = IIf(UCase(WTipo) = "M", WArticulo, "")
                        .Cells("Descripcion").Value = WDescripcion.Trim()
                        .Cells("LotePartida").Value = "0"
                        .Cells("Cantidad").Value = "0.00"
                    End With
                End If

            Next

            For i = 1 To 2
                If Val(WPorSeparado(i, 2)) > 0 Then
                    Dim r = DataGridView1.Rows.Add

                    With DataGridView1.Rows(r)
                        .Cells("Tipo").Value = "M"
                        .Cells("Terminado").Value = ""
                        .Cells("MateriaPrima").Value = WPorSeparado(i, 1)
                        .Cells("Descripcion").Value = WPorSeparado(i, 3)
                        .Cells("LotePartida").Value = "0"
                        .Cells("Cantidad").Value = "0.00"
                    End With
                End If
            Next

            Dim WEnsayos As DataRow = Nothing

            If empresa.ToUpper = "SURFACTAN_III" Then
                WEnsayos = GetSingle("SELECT Clave FROM Prueterfarma WHERE Partida = '" & WLote & "' And Renglon = 1", empresa)
            Else
                WEnsayos = GetSingle(String.Format("SELECT Prueba FROM Prueter WHERE Prueba IN ('1{0}', '2{0}')", WLote.ToString.PadLeft(6, "0")), empresa)
            End If

            btnVerEnsayos.Enabled = Not IsNothing(WEnsayos)

            Exit For

        Next

        txtSaldo.Text = _CalcularSaldoHoja()

        For Each c As Control In {txtInicioEnvII, txtInicioProdII, txtSaldo, txtTeorico, txtReal}
            Dim valor = c.Text.Trim.ToUpper.Replace("HS", "")
            c.Text = formatonumerico(valor)
        Next

        Button1.Focus()

    End Sub

    Private Function _CalcularSaldoHoja() As String
        Dim WSaldo As Double

        Dim WEntradas = 0.0
        Dim WSalidas = 0.0

        Dim WSalir = False

        For Each empresa As String In Empresas


            '
            ' Entradas por Hojas.
            '
            Dim WHojasII As DataTable = GetAll("SELECT ISNULL(Saldo, 0) As Cantidad FROM Hoja WHERE Hoja = '" & WLote & "' And Saldo <> 0 And Marca <> 'X' And Renglon = 1", empresa)

            For Each row As DataRow In WHojasII.Rows
                WSalir = True
                With row
                    WEntradas += OrDefault(.Item("Cantidad"), 0)
                End With
            Next

            If Not WSalir Then Continue For

            '
            ' Calculamos las Salidas por Hojas de Producción.
            '
            Dim WHojas As DataTable = GetAll("SELECT Canti1, Lote1, Canti2, Lote2, Canti3, Lote3 FROM Hoja WHERE Tipo = 'T' AND Terminado = '" & txtCodigo.Text & "' AND (Marca <> 'X' OR (RIGHT(Fecha, 4) + SUBSTRING(fecha, 4,2) + LEFT(fecha, 2))*1 >= 20001218) AND (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' OR Lote3 = '" & WLote & "')", empresa)

            For Each row As DataRow In WHojas.Rows
                With row
                    For i = 1 To 3
                        Dim _Lote As Integer = OrDefault(.Item("Lote" & i), 0)

                        If _Lote = 0 Then Continue For

                        If Val(_Lote) = _Lote Then
                            WSalidas += OrDefault(.Item("Canti" & i), 0)
                        End If
                    Next
                End With
            Next


            '
            ' Calculamos Salidas y Entradas por Movimientos Varios.
            '
            Dim WMovVarios As DataTable = GetAll("SELECT Terminado, ISNULL(Movi, '') Movi, ISNULL(SUM(Cantidad), 0) Cantidad FROM MovVar WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & txtCodigo.Text & "' And Lote = '" & WLote & "' GROUP BY Terminado, Movi ", empresa)

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
            Dim WGuias As DataTable = GetAll("SELECT Terminado, ISNULL(Saldo, 0) As Cantidad, Movi FROM Guia WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & txtCodigo.Text & "' And (Lote = '" & WLote & "' Or Partida = '" & WLote & "')", empresa)

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
            Dim WMovsLaboratorio As DataTable = GetAll("SELECT Terminado, ISNULL(SUM(Cantidad), 0) Cantidad, Movi FROM MovLab WHERE Marca <> 'X' AND Tipo = 'T' AND Terminado = '" & txtCodigo.Text & "' And Lote = '" & WLote & "' GROUP BY Terminado, Movi", empresa)

            For Each WMovLab As DataRow In WMovsLaboratorio.Rows
                With WMovLab
                    If .Item("Movi").ToString.ToUpper = "E" Then
                        WEntradas += .Item("Cantidad")
                    Else
                        WSalidas += .Item("Cantidad")
                    End If
                End With
            Next

            If WSalir Then Exit For

        Next

        WSaldo = WEntradas - WSalidas

        If WSaldo < 0 Then WSaldo = 0

        Return formatonumerico(WSaldo)
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WLotePartida = OrDefault(DataGridView1.CurrentRow.Cells("LotePartida").Value, 0)
        Dim WTipo = OrDefault(DataGridView1.CurrentRow.Cells("Tipo").Value, "")

        If Val(WLotePartida) = 0 Then Exit Sub

        Select Case UCase(WTipo)
            Case "T"
                With New DetallesEnsayosPT(WLotePartida)
                    .Show(Me)
                End With
            Case "M"
                With New DetallesEnsayosMP(WLotePartida)
                    .Show(Me)
                End With
            Case Else

        End Select

    End Sub

    Private Sub btnVerEnsayos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerEnsayos.Click
        With New DetallesEnsayosPT(txtPartida.Text)
            .Show(Me)
        End With
    End Sub
End Class