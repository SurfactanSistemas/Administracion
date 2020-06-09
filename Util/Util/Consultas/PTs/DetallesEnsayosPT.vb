Imports System.ComponentModel
Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Util.Clases.Globales

Public Class DetallesEnsayosPT
    Private WLote As String = ""

    Sub New(ByVal _Lote As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WLote = _Lote
    End Sub

    Private Sub DetallesEnsayosMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        If Val(WLote) = 0 Then Close()
        txtDescMP.BackColor = WBackColorTerciario
        txtProveedor.BackColor = WBackColorTerciario
        txtSaldo.BackColor = WBackColorTerciario
        DataGridView1.RowsDefaultCellStyle.BackColor = WBackColorSecundario
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = WBackColorTerciario

        For Each c As Control In {txtCantidad, txtCodigo, txtDescMP, txtFecha, txtInforme, txtLote, txtLoteProv, txtOrden, txtProveedor, DataGridView1}
            c.TabStop = False
        Next

        '        _ImprimeEnsayos()
        Cursor = Cursors.WaitCursor
        With BackgroundWorker1
            If Not .IsBusy Then .RunWorkerAsync()
        End With

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

        Dim WDatosEnsayos As DataRow = Nothing

        For Each emp As String In Empresas

            If emp.ToUpper = "SURFACTAN_III" Then
                ' Verificamos si se trata o no de un producto de Farma (Planta III).
                WDatosEnsayos = GetSingle(String.Format("SELECT TOP 1 Clave FROM PrueterFarma WHERE Partida = {0} And Renglon = 1 ", WLote), emp)
                If WDatosEnsayos IsNot Nothing Then
                    _MostrarEnsayosFarma()
                    Exit Sub
                End If

            Else
                WDatosEnsayos = GetSingle(String.Format("SELECT TOP 1 * FROM Prueter WHERE Prueba IN ('1{0}', '2{0}')", WLote.PadLeft(6, "0")), emp)
            End If

            If WDatosEnsayos Is Nothing Then Continue For

            With WDatosEnsayos
                WFecha = OrDefault(.Item("Fecha"), "")
                WProducto = OrDefault(.Item("Producto"), "")

                For i = 1 To 10

                    Dim r As DataRow = WEnsayos.NewRow

                    r.Item("Ensayo") = ""
                    r.Item("ValorStd") = ""
                    r.Item("ValorReg") = OrDefault(.Item("Valor" & i), "")
                    r.Item("Valor") = "" 'OrDefault(.Item("ValorNumero" & i), "")

                    If Trim(r.Item("ValorReg")) <> "" Then WEnsayos.Rows.Add(r)
                    'WEnsayos.Rows.Add(r)

                Next

            End With

            Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

            Dim WEspecif As DataRow = GetSingle(String.Format("SELECT * FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
            End If

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecifUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
            End If

            If WEspecif IsNot Nothing Then

                Dim WRenglonEns = 0

                For i = 1 To 10
                    If WRenglonEns < WEnsayos.Rows.Count Then
                        If Val(OrDefault(WEspecif.Item("Ensayo" & i), "")) <> 0 Then
                            WEnsayos.Rows(WRenglonEns).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                            WEnsayos.Rows(WRenglonEns).Item("ValorStd") = Trim(OrDefault(WEspecif.Item("Valor" & i), "")) & " " & Trim(OrDefault(WEspecif.Item("Valor" & i & "" & i), ""))
                            WRenglonEns += 1
                        End If
                    End If
                Next

            End If

            For Each _e As DataRow In WEnsayos.Rows
                With _e
                    Dim WEns As DataRow = GetSingle("SELECT ISNULL(Descripcion, '') Descripcion FROM Ensayos WHERE Codigo = '" & _e.Item("Ensayo") & "'", WBaseEspecif)

                    If WEns Is Nothing Then Continue For

                    _e.Item("Ensayo") = _e.Item("Ensayo").ToString.PadLeft(4, "0") & "  " & Trim(WEns.Item("Descripcion"))

                End With
            Next

            _ImprimeDatosHoja(emp)

            Exit For

        Next

        If WEnsayos.Rows.Count = 0 Then
            MsgBox("No se encontraron resultados para poder mostrar.", MsgBoxStyle.Information)
            Button1_Click(Nothing, Nothing)
            Exit Sub
        End If

        DataGridView1.Columns("Valor").Visible = False

        BackgroundWorker1.ReportProgress(0, WEnsayos)

    End Sub

    Private Sub _MostrarEnsayosFarma()
        Dim WEnsayos As New DataTable
        Dim WDatosEnsayos As DataTable = Nothing

        _ImprimeDatosHoja("Surfactan_III")


        With WEnsayos.Columns
            .Add("Ensayo")
            .Add("ValorStd")
            .Add("ValorReg")
            .Add("Valor")
        End With

        WDatosEnsayos = GetAll("SELECT TOP 50 ptf.Codigo, ptf.Estado, ptf.Resultado, ptf.Valor, ptf.ValorReal, ptf.TipoEspecif, ptf.DesdeEspecif, ptf.HastaEspecif, ptf.UnidadEspecif, ptf.MenorIgualEspecif, ptf.Confecciono FROM PrueterFarma ptf INNER JOIN Hoja h ON h.Hoja = ptf.Partida And h.Producto = ptf.Producto And h.Renglon = 1 WHERE ptf.Partida = " & WLote & " Order By ptf.Clave", "Surfactan_III")

        If WDatosEnsayos.Rows.Count = 0 Then Exit Sub

        Dim WEns = 0
        Dim WEspecificacion = ""
        Dim WValor = ""
        Dim WTipoEspecif = ""
        Dim WDesdeEspecif = ""
        Dim WHastaEspecif = ""
        Dim WUnidadEspecif = ""
        Dim WMenorIgualEspecif = ""
        Dim WImpreParametro = ""
        Dim WImpreResultado = ""

        If OrDefault(WDatosEnsayos.Rows(0).Item("Estado"), 0) = 1 Then
            For Each row As DataRow In WDatosEnsayos.Rows
                With row
                    WEns = OrDefault(.Item("Codigo"), 0)
                    WEspecificacion = OrDefault(.Item("Valor"), "")
                    WValor = OrDefault(.Item("ValorReal"), "")
                    WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                    WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                    WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                    WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                    WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                    WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)
                    WImpreResultado = _GenerarImpreResultado(WValor, WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    Dim r = WEnsayos.NewRow

                    With r
                        .Item("Ensayo") = WEns
                        .Item("ValorStd") = WEspecificacion
                        .Item("ValorReg") = WImpreParametro
                        .Item("Valor") = WImpreResultado
                    End With

                    WEnsayos.Rows.Add(r)

                End With

            Next

        Else
            For Each row As DataRow In WDatosEnsayos.Rows
                With row
                    WEns = OrDefault(.Item("Codigo"), 0)
                    WEspecificacion = OrDefault(.Item("Valor"), "")
                    WValor = OrDefault(.Item("Resultado"), "")

                    Dim r = WEnsayos.NewRow

                    With r
                        .Item("Ensayo") = WEns
                        .Item("ValorStd") = WEspecificacion
                        .Item("ValorReg") = WValor
                        .Item("Valor") = ""
                    End With

                    WEnsayos.Rows.Add(r)

                End With
            Next

        End If

        If WEnsayos.Rows.Count = 0 Then
            MsgBox("No se encontraron resultados para poder mostrar.", MsgBoxStyle.Information)
            Button1_Click(Nothing, Nothing)
            Exit Sub
        End If



        BackgroundWorker1.ReportProgress(0, WEnsayos)

    End Sub

    Private Function _GenerarImpreResultado(ByVal wValor As Object, ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object)
        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If Val(wTipoEspecif) = 0 Then

            Select Case UCase(Trim(wValor))
                Case "S"
                    Return "Cumple"
                Case "N"
                    Return "No Cumple"
            End Select

        Else

            Return String.Format("{0} {1}", Trim(wValor), Trim(wUnidadEspecif))

        End If

        Return ""
    End Function

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object) As String
        ' If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If Val(wTipoEspecif) = 0 Then
            Return "Cumple Ensayo"
        Else

            If Val(wDesdeEspecif) = 0 And {99, 999, 9999}.Contains(Math.Truncate(Val(wHastaEspecif))) Then Return "Registrar e Informar."

            If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                    Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
                End If

                If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                    If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)

                    Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

                End If

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                    If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Mínimo {0} {1}", wHastaEspecif, wUnidadEspecif)

                    Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

                End If

            End If
        End If

        Return ""
    End Function

    Private Sub DetallesEnsayosMP_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        Button1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _ImprimeEnsayos()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Debug.Print(e.UserState.GetType.ToString)

        If e.UserState.GetType = GetType(DataTable) Then
            Dim WEnsayos As DataTable = CType(e.UserState, DataTable)

            If WEnsayos.Rows.Count > 0 Then
                DataGridView1.Columns("Valor").Visible = Trim(OrDefault(WEnsayos.Rows(0).Item("Valor"), "")) <> ""
            End If

            DataGridView1.DataSource = WEnsayos
        End If

    End Sub

    Private Sub _ImprimeDatosHoja(ByVal WEmpresa As Object)

        Dim WHoja As DataRow = Nothing

        If UCase(WEmpresa) = "SURFACTAN_III" Then
            WHoja = GetSingle("SELECT TOP 1 h.Producto, ptf.Confecciono, h.fecha, Teorico = CASE WHEN ISNULL(h.Real, 0) <> 0 THEN h.Real ELSE h.Teorico END, h.Saldo, DescTerminado = t.Descripcion from hoja h LEFT OUTER JOIN Terminado t ON t.Codigo = h.Producto LEFT OUTER JOIN PrueterFarma ptf ON ptf.Partida = h.Hoja And ptf.Producto = h.Producto And ptf.Renglon = 1 where h.hoja = " & WLote & " and h.renglon = 1", WEmpresa)
        Else
            WHoja = GetSingle("SELECT TOP 1 h.Producto, pt.Confecciono, h.fecha, Teorico = CASE WHEN ISNULL(h.Real, 0) <> 0 THEN h.Real ELSE h.Teorico END, h.Saldo, DescTerminado = t.Descripcion from hoja h LEFT OUTER JOIN Terminado t ON t.Codigo = h.Producto LEFT OUTER JOIN Prueter pt ON Right(pt.Prueba, 6) = h.Hoja*1.0 And pt.Producto = h.Producto where h.hoja = " & WLote & " and h.renglon = 1", WEmpresa)
        End If

        If WHoja IsNot Nothing Then
            With WHoja
                txtCodigo.Text = OrDefault(.Item("Producto"), "")
                txtFecha.Text = OrDefault(.Item("Fecha"), "")
                txtLote.Text = WLote
                txtDescMP.Text = OrDefault(.Item("DescTerminado"), "")
                txtCantidad.Text = OrDefault(.Item("Teorico"), "")
                txtSaldo.Text = OrDefault(.Item("Saldo"), "")
                txtConfecciono.Text = Trim(OrDefault(.Item("Confecciono"), ""))

                txtCantidad.Text = formatonumerico(txtCantidad.Text)
                txtSaldo.Text = _CalcularSaldoHoja()

            End With
        End If

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

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With New DetallesHojaProduccion(txtLote.Text)
            .Show(Me)
        End With
    End Sub
End Class