Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

' ReSharper disable once CheckNamespace
Public Class ComparacionesMensualesValorUnico

    Private Sub ComparacionesMensuales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()
        _CargarAniosComparables()

        ckConsolidado.Checked = True
        cmbTipoGrafico.SelectedIndex = 0
        cmbPeriodo.SelectedIndex = 0
        txtAnioDesde.Text = ""
        txtAnioDesde.Text = Date.Now.ToString("yyyy")
    End Sub

    Private Sub _CargarAniosComparables()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Distinct Impre1 FROM ComandoII")
        Dim dr As SqlDataReader
        Dim Aux = ""

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            ckAnios.Items.Clear()

            If dr.HasRows Then

                Do While dr.Read()

                    Aux = Trim(dr.Item("Impre1"))

                    Aux = Microsoft.VisualBasic.Right(Aux, 4)

                    ckAnios.Items.Add(Aux)

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Function _ArmarBuscarFamilias() As String
        Dim chks() As CheckBox = {ckQuimicos, ckColorantes, ckFarma, ckFazonPellital, _
                                  ckFazonFarma, ckFazonQuimicos, ckVarios}

        Dim WBuscarFamilias = " Tipo in ("

        For i = 0 To 6
            If chks(i).Checked Then
                WBuscarFamilias &= "'" & i + 1 & "',"
            End If
        Next

        If WBuscarFamilias.EndsWith(",") Then
            WBuscarFamilias = Mid(WBuscarFamilias, 1, WBuscarFamilias.Length - 1)
        End If

        Return WBuscarFamilias & ")"

    End Function

    Private Function _ArmarTablaYDatos() As DataSet
        Dim WAnio As Integer = 0
        Dim WMeses(12) As String
        Dim WAnios(12) As String

        Dim datos As DataTable = _CrearTablaDetalles()
        Dim ds As New DataSet

        '
        ' Obtenemos los meses con los cuales trabajar.
        '
        _TraerMesesAConsultar(WMeses, WAnios)

        '
        ' Obtenemos el año por el cual se van a traer los datos.
        '
        'WAnio = Val(txtAnioDesde.Text)

        '
        ' Obtenemos los valores a comparar.
        '

        Dim WDatos() As String = _TraerValoresAComparar()

        '
        ' Obtenemos los datos de las familias en el periodo dado.
        '

        Select Case cmbPeriodo.SelectedIndex
            Case 0
                _BuscarDatosBrutos(WMeses, WAnios, WDatos, datos)
                ds.Tables.Add(datos)
            Case 1
                '_BuscarDatosBrutosAnual(WMeses, WAnio, WDatos, datos)
                ds.Tables.Add(datos)
            Case 2
                ' Validamos que se haya seleccionado un unico valor a comparar.
                Dim WCantValoresSeleccionados = (From v In ValoresComparables() Where v.Checked).Count

                If WCantValoresSeleccionados > 1 Then
                    Throw New Exception("En 'Comparativo Mensual', sólo puede seleccionarse un único valor a comparar.")
                End If

                ' Recorremos los años. Buscamos los datos y los agrupamos por Valor Comparativo y Año.

                For Each anio In ckAnios.CheckedItems
                    _BuscarDatosBrutos(WMeses, anio, WDatos, datos)
                Next

                '_BuscarDatosBrutosAnualComparativo(WMeses, datos)

                ds.Tables.Add(datos)

        End Select

        Return ds

    End Function

    Private Function _BuscarDatosBrutosAnualComparativo(ByVal wMeses As Integer(), ByRef tabla As DataTable)
        Dim tabla2 As DataTable = _CrearTablaDetalles()
        Dim WCantMeses = (From m In wMeses Where m > 0).Count
        Dim WCantAnios = ckAnios.CheckedItems.Count
        Dim WCantFamilias = (From f In Familias() Where f.Checked).Count

        ' Creamos una fila por mes.

        For i = 1 To (WCantMeses * (WCantAnios / 2) * WCantFamilias)

            tabla2.Rows.Add()

        Next

        ' recorremos las filas de la tabla original.
        Dim WIndiceMes = 0, aux = 0

        Dim WDescFamilias(7) As String

        WDescFamilias(1) = "Químicos"
        WDescFamilias(2) = "Colorantes"
        WDescFamilias(3) = "Farma"
        WDescFamilias(4) = "Fazón Pellital"
        WDescFamilias(5) = "Fazón Farma"
        WDescFamilias(6) = "Fazón Químicos"
        WDescFamilias(7) = "Varios"

        Dim rows() As DataRow
        Dim WTotales() As Double

        ' Recorremos las familias.
        For i = 1 To 7

            rows = tabla.Select("Tipo = " & i)

            ' Calculamos los totales en caso de que se requiera como porcentaje.
            If rbPorcentaje.Checked Then

                ReDim WTotales(rows.Count)

                For x = 0 To rows.Count - 1
                    WTotales(x) = 0.0
                Next

                Dim aux2 = 0.0

                For k = 0 To rows.Count - 1

                    aux2 = 0.0

                    For w = 1 To 12
                        aux2 += Val(Helper.formatonumerico(rows(k).Item("Valor" & w)))
                    Next

                    WTotales(k) = Val(Helper.formatonumerico(aux2))

                Next

            End If

            If rows.Count > 0 Then

                For j = 0 To WCantAnios - 1

                    WIndiceMes = aux

                    For x = 1 To WCantMeses

                        tabla2.Rows(WIndiceMes).Item("Tipo") = Str$(i)

                        If rbPorcentaje.Checked Then
                            ' ReSharper disable once VBWarnings::BC42104
                            tabla2.Rows(WIndiceMes).Item("Valor" & j + 1) = (tabla.Rows(j).Item("Valor" & x) * 100) / WTotales(j)
                        Else
                            tabla2.Rows(WIndiceMes).Item("Valor" & j + 1) = tabla.Rows(j).Item("Valor" & x)
                        End If

                        tabla2.Rows(WIndiceMes).Item("Titulo" & j + 1) = Microsoft.VisualBasic.Right(Trim(rows(j).Item("Titulo" & x)), 4)
                        tabla2.Rows(WIndiceMes).Item("Descripcion") = UCase(MonthName(x)) & " (" & (IIf(rbPorcentaje.Checked, "%", "$")) & ")"
                        tabla2.Rows(WIndiceMes).Item("Titulo") = WDescFamilias(i)

                        WIndiceMes += 1

                    Next

                Next

                aux = WIndiceMes

            End If

        Next

        tabla = tabla2.Copy

        Return tabla
    End Function

    Private Sub _BuscarDatosBrutosAnual(ByVal wMeses As Integer(), ByVal wAnio As Integer, ByVal WDatos As String(), ByRef tabla As DataTable)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        'Dim tabla As DataTable
        Dim row As DataRow
        Dim rowIndex = 0
        Dim WBuscarFamilias = _ArmarBuscarFamilias()
        Dim WDatosABuscar = ""
        Dim WMes = ""
        Dim WValor = 0.0

        'tabla = _CrearTablaDetalles()
        'tabla.Rows.Clear()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()

            ' Recorremos los datos a pedir y cada dato


            ' Armamos la consulta de los campos a comparar para cada mes.
            For j = 1 To 10

                ' Recorremos los meses pedidos.
                WDatosABuscar = ""
                For i = 0 To 11

                    If wMeses(i) > -1 Then

                        If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                            WDatosABuscar &= WDatos(j) & wMeses(i) & "+"
                        End If

                    End If

                Next

                ' Chequeamos que hayan datos que buscar.
                If Trim(WDatosABuscar) = "" Then
                    Return
                End If

                ' Eliminamos el ultimo '+'.
                WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)


                ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                WMes = ""
                ' Los meses y años se estan guardando como ' 1/ 2017 '
                WMes = " 1/ " & wAnio & " "

                cm.CommandText = "SELECT Tipo, Descripcion, (" & WDatosABuscar & ") as Total FROM ComandoII WHERE Impre1 = '" & WMes & "' and " & WBuscarFamilias

                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    ' Agregamos una fila por cada familia.
                    row = tabla.NewRow

                    rowIndex = 0

                    Do While dr.Read()
                        row.Item("Corte") = Str$(j) & Str$(wAnio)
                        row.Item("Tipo") = Val(Str$(j) & Str$(wAnio))
                        row.Item("Descripcion") = WDatos(j)

                        With row

                            WValor = IIf(IsDBNull(dr.Item("Total")), 0.0, dr.Item("Total"))

                            If WValor <> 0 Then
                                rowIndex += 1

                                .Item("Valor" & rowIndex) = WValor 'dr.Item("")
                                .Item("Titulo" & rowIndex) = dr.Item("Descripcion") 'WMes
                            End If

                        End With

                    Loop

                    tabla.Rows.Add(row)

                End If

                If Not dr.IsClosed Then
                    dr.Close()
                    dr = Nothing
                End If

            Next


        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return
    End Sub

    Private Sub _BuscarDatosBrutos(ByVal wMeses() As String, ByVal WAnios() As String, ByVal WDatos As String(), ByRef tabla As DataTable)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        'Dim tabla As DataTable
        Dim row As DataRow
        Dim rowIndex = 0
        Dim ZCorte = 0
        Dim WBuscarFamilias = _ArmarBuscarFamilias()
        Dim WDatosABuscar = ""
        Dim WMes = ""
        Dim WAnio = ""
        Dim WDato = ""
        Dim WCantDatos = (From d In WDatos Where Trim(d) <> "").Count

        'tabla = _CrearTablaDetalles()
        'tabla.Rows.Clear()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()

            ' Recorremos los datos a pedir y cada dato


            ' Armamos la consulta de los campos a comparar para cada mes.
            For j = 1 To 10

                ' Recorremos los meses pedidos.
                WDatosABuscar = ""
                For i = 0 To 11

                    If wMeses(i) > -1 Then

                        If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                            WDatosABuscar &= WDatos(j) & Trim(wMeses(i)) & ","
                        End If

                    End If

                Next

                ' Chequeamos que hayan datos que buscar.
                If Trim(WDatosABuscar) = "" Then
                    Return
                End If

                ' Eliminamos la ultima coma.
                WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)


                ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                WMes = ""
                ' Los meses y años se estan guardando como ' 1/ 2017 '
                If Val(txtAnioDesde.Text) = Val(txtAnioHasta.Text) Then

                    WAnio = Trim(WAnios(0))

                    WMes = " 1/ " & WAnio & " "

                    cm.CommandText = "SELECT Tipo, Descripcion, " & WDatosABuscar & " FROM ComandoII WHERE Impre1 = '" & WMes & "' and " & WBuscarFamilias

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = tabla.NewRow
                            rowIndex = 0
                            ZCorte += 1
                            With row
                                .Item("Tipo") = IIf(WCantDatos = 1, ZCorte, dr.Item("Tipo"))
                                .Item("Descripcion") = dr.Item("Descripcion")
                                .Item("Corte") = ZCorte
                                .Item("Titulo") = UCase(WDatos(j))

                                For i = 0 To 11

                                    If wMeses(i) > -1 Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = wMeses(i) & "/" & Str$(WAnio)

                                        WDato = WDatos(j) & Trim(wMeses(i))

                                        .Item("Valor" & rowIndex) = dr.Item(WDato)
                                        .Item("Titulo" & rowIndex) = WMes

                                    End If

                                Next
                            End With

                            tabla.Rows.Add(row)

                        Loop

                    End If

                    If Not dr.IsClosed Then
                        dr.Close()
                        dr = Nothing
                    End If

                Else

                    Dim aux1 = 0

                    For i = Val(txtMesDesde.Text) To 11

                        aux1 += 1

                    Next


                    WDatosABuscar = ""
                    For i = 0 To aux1

                        If wMeses(i) > -1 Then

                            If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                                WDatosABuscar &= WDatos(j) & Trim(wMeses(i)) & ","
                            End If

                        End If

                    Next

                    Dim aux2 = aux1 + 1

                    For i = 0 To Val(txtMesHasta.Text)

                        If wMeses(aux2) > -1 Then

                            If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                                WDatosABuscar &= WDatos(j) & Trim(wMeses(aux2)) & ","
                            End If

                            aux2 += 1
                        End If

                    Next


                    ' Chequeamos que hayan datos que buscar.
                    If Trim(WDatosABuscar) = "" Then
                        Return
                    End If

                    ' Eliminamos la ultima coma.
                    WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)

                    WAnio = Trim(txtAnioDesde.Text)

                    WMes = " 1/ " & WAnio & " "
                    Dim WAnio2 = Trim(txtAnioHasta.Text)
                    Dim WMes2 = " 1/ " & WAnio2 & " "

                    cm.CommandText = "SELECT Tipo, Descripcion, " & WDatosABuscar & " FROM ComandoII WHERE (Impre1 = '" & WMes & "' OR Impre1 = '" & WMes2 & "' ) and " & WBuscarFamilias & " ORDER BY Tipo"

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = tabla.NewRow
                            rowIndex = 0
                            ZCorte += 1
                            With row
                                .Item("Tipo") = IIf(WCantDatos = 1, ZCorte, dr.Item("Tipo"))
                                .Item("Descripcion") = dr.Item("Descripcion")
                                .Item("Corte") = ZCorte
                                .Item("Titulo") = UCase(WDatos(j))

                                For i = 0 To aux1

                                    If wMeses(i) > -1 Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = wMeses(i) & "/" & Str$(WAnio)

                                        WDato = WDatos(j) & Trim(wMeses(i))

                                        .Item("Valor" & rowIndex) = dr.Item(WDato)
                                        .Item("Titulo" & rowIndex) = WMes

                                    End If

                                Next

                                ' Leemos los meses del Próximo año.
                                If dr.Read() Then

                                    For i = 1 To Val(txtMesHasta.Text)

                                        If wMeses(aux1) > -1 Then
                                            rowIndex += 1

                                            WMes = ""
                                            WMes = wMeses(aux1) & "/" & Str$(WAnio)

                                            WDato = WDatos(j) & Trim(wMeses(aux1))

                                            .Item("Valor" & rowIndex) = dr.Item(WDato)
                                            .Item("Titulo" & rowIndex) = WMes

                                            aux1 += 1
                                        End If

                                    Next

                                End If
                                
                            End With

                            tabla.Rows.Add(row)

                        Loop

                    End If

                    If Not IsNothing(dr) AndAlso Not dr.IsClosed Then
                        dr.Close()
                        dr = Nothing
                    End If

                End If

            Next


        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return
    End Sub

    Private Function _TraerValoresAComparar() As String()
        Dim WDatos(10) As String
        Dim i = 0
        i = 0
        If ckVenta.Checked Then
            i += 1
            WDatos(i) = "Venta"
        End If

        If ckKilos.Checked Then
            i += 1
            WDatos(i) = "Kilos"
        End If

        If ckFactor.Checked Then
            i += 1
            WDatos(i) = "Factor"
        End If

        If ckPrecio.Checked Then
            i += 1
            WDatos(i) = "Precio"
        End If

        If ckStock.Checked Then
            i += 1
            WDatos(i) = "Stock"
        End If

        If ckRotacion.Checked Then
            i += 1
            WDatos(i) = "Rotacion"
        End If

        If ckPorcentaje.Checked Then
            i += 1
            WDatos(i) = "PorceVenta"
        End If

        If ckPedidos.Checked Then
            i += 1
            WDatos(i) = "Pedidos"
        End If

        If ckAtrasados.Checked Then
            i += 1
            WDatos(i) = "Atraso"
        End If

        If ckPorcentajeAtrasos.Checked Then
            i += 1
            WDatos(i) = "PorceAtraso"
        End If

        Return WDatos
    End Function

    Private Sub _TraerMesesAConsultar(ByRef WMeses() As String, ByRef WAnios() As String)
        ReDim WMeses(12)
        ReDim WAnios(12)

        Dim WIndice = 0
        Dim WMesInicial = Val(txtMesDesde.Text)
        Dim WMesFinal = Val(txtMesHasta.Text)
        Dim WAnioInicial = Val(txtAnioDesde.Text)
        Dim WAnioFinal = Val(txtAnioHasta.Text)

        ' Se controla que se consulten solo meses cerrados.
        If WMesFinal = Date.Now.Month And WAnioFinal = Date.Now.Year Then
            WMesFinal = WMesFinal - 1
        End If

        ''
        '' Guardamos la posicion del mes chequeado y le sumamos uno para que coincida con el numero de mes.
        ''

        If WAnioInicial = WAnioFinal Then
            For i = 0 To 12

                If WMesInicial <= WMesFinal Then
                    WMeses(i) = Str$(WMesInicial)
                    WAnios(i) = Str$(WAnioInicial)
                Else
                    Exit For
                End If

                WMesInicial += 1

                WIndice = i + 1
            Next

        Else

            Dim aux1 = 0, aux2 = 0

            If WAnioInicial > WAnioFinal Then
                Throw New Exception("Las fechas deben correlativas.")
            End If

            ' Calculamos la cantidad de meses del primer año.
            For i = WMesInicial To 11

                aux1 += 1

            Next

            For i = 0 To aux1

                WMeses(i) = Str$(WMesInicial)
                WAnios(i) = Str$(WAnioInicial)

                WMesInicial += 1

                WIndice = i + 1
            Next

            For i = 1 To WMesFinal

                aux2 += 1
                aux1 += 1

                WMeses(aux1) = Str$(aux2)
                WAnios(aux1) = Str$(WAnioFinal)

                WIndice += 1
            Next

        End If

        '
        ' Completamos los lugares restantes con -1 asi no los tenemos en cuenta en la consulta.
        '
        For i = WIndice To 12
            WMeses(i) = Str$(-1)
            WAnios(i) = Str$(-1)
        Next

    End Sub

    Private Function _CrearTablaDetalles() As DataTable

        Dim tabla As New DataTable("Detalles")

        '
        ' CREAMOS LA ESTRUCTURA DE LA TABLA.
        '

        With tabla

            .Columns.Add("Tipo", System.Type.GetType("System.Double"))
            .Columns.Add("Descripcion")
            .Columns.Add("Titulo")
            .Columns.Add("Corte")

            For i = 1 To 12
                .Columns.Add("Valor" & i, System.Type.GetType("System.Double"))
            Next

            For i = 1 To 12
                .Columns.Add("Titulo" & i)
            Next

        End With

        Return tabla

    End Function

    Private Function _FamiliasSeleccionadas() As Boolean

        Return Familias().Any(Function(ck) ck.Checked)

    End Function

    Private Function _TraerReporteMensual()

        Dim seleccionados = ValoresComparables().Count(Function(ck) ck.Checked)

        ' Por defecto, en caso de comparaciones anuales es solamente en Barras.
        If cmbPeriodo.SelectedIndex = 1 Then
            Return New AnualPorFamiliaBarras
        End If

        If cmbPeriodo.SelectedIndex = 2 Then
            Return New MensualComparativoBarras
        Else
            rbMonto.Checked = True
        End If

        If seleccionados > 1 Then ' Seleccionamos tipo de grafico 'Linea' cuando es mas de un valor
            cmbTipoGrafico.SelectedIndex = 1
        End If

        Select Case cmbTipoGrafico.SelectedIndex
            Case 0 ' Barras

                'EN CASO DE QUE HAYA MAS DE UNA FAMILIA, PUEDE PASAR DOS COSAS: QUE SEAN SOLO DOS O QUE SEAN MAS DE DOS.

                ' EN CUALQUIER OTRO CASO, RETORNAREMOS EL GRAFICO COMUN DE MES/AÑO POR BARRA.

                Return New MensualPorFamiliaBarras

            Case 1 ' Lineas

                'EN CASO DE QUE HAYA MAS DE UNA FAMILIA, PUEDE PASAR DOS COSAS: QUE SEAN SOLO DOS O QUE SEAN MAS DE DOS.

                ' EN CUALQUIER OTRO CASO, RETORNAREMOS EL GRAFICO COMUN DE MES/AÑO POR BARRA.

                Return New MensualPorFamiliaLineas

            Case Else

                Return Nothing

        End Select

    End Function

    Private Function ValoresComparables() As CheckBox()

        Return {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}
    End Function

    Private Function Familias() As CheckBox()

        Return {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim WReporte As ReportDocument = Nothing
        Dim tabla As DataSet
        Dim valido As Boolean = _PeriodoValido()


        '
        ' VALIDAMOS QUE EL PERIODO SEA DE UN AÑO.
        '
        If Not _ValidaDatosPeriodo() Then

            MsgBox("Periodo no valido. Debe seleccionarse un periodo de máximo 12 meses para generar el reporte.", MsgBoxStyle.Exclamation)
            Exit Sub

        End If

        '
        ' VALIDAMOS QUE SE HAYAN ELEGIDO POR LO MENOS ALGUNA DE LAS SIETE FAMILIAS.
        '

        If Not _FamiliasSeleccionadas() Then
            MsgBox("Se debe seleccionar por lo menos una familia para generar un reporte.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' VALIDAMOS QUE SE HAYA SELECCIONADO ALGUN MES.

        If Not _MesesElegidos() Then
            MsgBox("Se debe seleccionar por lo menos un mes para generar un reporte.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' BUSCAMOS EL RPT SEGUN TIPO DE COMPARACION Y TIPO DE GRAFICO INDICADO.
        '

        WReporte = _TraerReporteMensual()

        '
        ' BUSCAMOS LOS DATOS CON LOS CUALES TRABAJAR.
        '

        Try

            tabla = _ArmarTablaYDatos() '_TraerDatosParaGraficos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        '
        '   VALIDAMOS QUE HAYAN DATOS Y RPT PARA PODER GENERAR LOS REPORTES.
        '

        If WReporte Is Nothing Then
            MsgBox("Debe indicarse un tipo de Gráfico válido.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If tabla Is Nothing Then : Exit Sub : End If

        DataGridView1.DataSource = tabla

        With VistaPrevia

            .Reporte = WReporte
            .Reporte.SetDataSource(tabla)
            .Mostrar()

        End With
    End Sub

    Private Function _PeriodoValido() As Boolean

        Dim valido = False
        Dim aux = 0

        For i = Val(txtMesDesde.Text) To 11
            aux += 1
        Next

        If Val(txtAnioDesde.Text) < Val(txtAnioHasta.Text) Then
            For i = 1 To Val(txtMesHasta.Text)
                aux += 1
            Next
        End If

        If aux <= 12 Then
            valido = True
        End If

        Return valido
    End Function

    Private Function _MesesElegidos() As Boolean
        Return True '{ckEnero, ckFebrero, ckMarzo, ckAbril, ckMayo, ckJunio, ckJulio, ckAgosto, ckSeptiembre, ckOctubre, ckNoviembre, ckDiciembre}.Any(Function(ck) ck.Checked)
    End Function

    Private Sub ckTodosValores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodosValores.CheckedChanged
        For Each ck As CheckBox In _ValoresComparables()
            ck.Checked = ckTodosValores.Checked
        Next
    End Sub

    Private Function _ValoresComparables() As CheckBox()
        Return {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}
    End Function

    Private Sub ckValoresAComparar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVenta.CheckedChanged, ckAtrasados.CheckedChanged, ckFactor.CheckedChanged, ckKilos.CheckedChanged, ckPedidos.CheckedChanged, ckPorcentajeAtrasos.CheckedChanged, ckPrecio.CheckedChanged, ckRotacion.CheckedChanged, ckStock.CheckedChanged, ckPorcentaje.CheckedChanged
        '
        ' Contamos los valores que se seleccionaron para graficar.
        '
        Dim seleccionados As Integer = {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}.Count(Function(ck) ck.Checked)

        '
        ' Seleccionamos por defecto tipo de grafico en linea en caso de que hayan mas de dos valores marcados. Sino lo colocamos como "Barras"
        '
        If seleccionados > 1 Then
            cmbTipoGrafico.SelectedIndex = 1 ' Lineas
        Else
            cmbTipoGrafico.SelectedIndex = 0 ' Barras
        End If

    End Sub

    Private Sub btnSeleccionarAnios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarAnios.Click

        'Dim x

        'x = New Point((Me.Width - pnlAnios.Width * 1.5), Me.Height - pnlAnios.Height * 2)

        'pnlAnios.Location = x
        pnlAnios.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pnlAnios.Visible = False
    End Sub

    Private Sub cmbPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriodo.SelectedIndexChanged

        Select Case cmbPeriodo.SelectedIndex
            Case 1

                cmbTipoGrafico.SelectedIndex = 0
                btnSeleccionarAnios.Visible = False
                Button1.PerformClick()

            Case 2
                btnSeleccionarAnios.Visible = True
                btnSeleccionarAnios.PerformClick()
            Case Else

                btnSeleccionarAnios.Visible = False
                Button1.PerformClick()

                For Each ck As CheckBox In Familias()
                    If Familias.Count(Function(c) c.Checked) > 1 Then
                        ck.Checked = False
                    End If
                Next

        End Select

    End Sub

    Private Sub txtMesDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMesDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtMesDesde.Text) = "" Then : Exit Sub : End If

            ' Validamos mes
            If Not _MesValido(txtMesDesde.Text) Then
                Exit Sub
            End If

            ' Deberiamos validar el periodo. O Capaz despues ya en la generacion?

            txtMesDesde.Text = Helper.ceros(txtMesDesde.Text, 2)
            txtAnioDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMesDesde.Text = ""
        End If

    End Sub

    Private Function _MesValido(ByVal WMes As String) As Boolean
        Return Val(WMes) >= 1 And Val(WMes) <= 12
    End Function

    Private Sub txtAnioDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnioDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAnioDesde.Text) = "" Then : Exit Sub : End If

            ' validamos el año.
            If Not _ValidarAnio(txtAnioDesde.Text) Then
                Exit Sub
            End If

            txtMesHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtAnioDesde.Text = ""
        End If

    End Sub

    Private Function _ValidarAnio(ByVal WAnio As String) As Boolean
        Return Trim(WAnio).Length = 4 And Val(WAnio) >= 1900 And Val(WAnio) <= 2999
    End Function

    Private Sub txtMesHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMesHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtMesHasta.Text) = "" Then : Exit Sub : End If

            ' Validamos mes
            If Not _MesValido(txtMesHasta.Text) Then
                Exit Sub
            End If

            ' Deberiamos validar el periodo. O Capaz despues ya en la generacion?

            txtMesHasta.Text = Helper.ceros(txtMesHasta.Text, 2)
            txtAnioHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMesHasta.Text = ""
        End If
    End Sub

    Private Sub txtAnioHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnioHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAnioHasta.Text) = "" Then : Exit Sub : End If

            ' validamos el año.
            If Not _ValidarAnio(txtAnioHasta.Text) Then
                Exit Sub
            End If

            If Not _ValidaDatosPeriodo() Then

                Exit Sub

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtAnioHasta.Text = ""
        End If

    End Sub

    Private Function _ValidaDatosPeriodo() As Boolean

        If {txtMesDesde, txtMesHasta, txtAnioDesde, txtAnioHasta}.Any(Function(t) Val(t.Text) <= 0) Then
            Return False
        End If

        Dim WMesDesde = Val(txtMesDesde.Text)
        Dim WMesHasta = Val(txtMesHasta.Text)
        Dim WAnioDesde = Val(txtAnioDesde.Text)
        Dim WAnioHasta = Val(txtAnioHasta.Text)
        
        If WAnioDesde <> WAnioHasta Then

            If WAnioHasta < WAnioDesde Then
                Return False
            End If

            If WMesHasta > WMesDesde Then
                Return False
            End If

        Else

            If WMesHasta < WMesDesde Then
                Return False
            End If

        End If

        Return _PeriodoValido()
    End Function

    Private Sub ComparacionesMensualesValorUnico_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtMesDesde.Focus()
    End Sub

    Private Sub cmbTipoGrafico_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoGrafico.KeyDown
        If e.KeyData = Keys.Enter Then

            cmbPeriodo.DroppedDown = True
            cmbPeriodo.Focus()

        End If
    End Sub

    Private Sub ckFamilias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckQuimicos.CheckedChanged, ckColorantes.CheckedChanged, ckFarma.CheckedChanged, ckFazonFarma.CheckedChanged, ckFazonPellital.CheckedChanged, ckFazonQuimicos.CheckedChanged, ckVarios.CheckedChanged

        Dim control As CheckBox = sender

        If _EsComparacionMensual() Then

            For Each ck As CheckBox In Familias()

                If control.Checked = False Then
                    Exit For
                End If

                If control.Name <> ck.Name Then
                    ck.Checked = False
                End If

            Next

        End If

    End Sub

    Private Function _EsComparacionMensual() As Boolean
        Return cmbPeriodo.SelectedIndex = 0
    End Function

    Private Sub ckConsolidado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckConsolidado.CheckedChanged

        If ckConsolidado.Checked Then

            For Each ck As CheckBox In Familias()
                With ck
                    .Checked = False
                    .Enabled = False
                End With
            Next

        Else

            For Each ck As CheckBox In Familias()
                With ck
                    .Enabled = True
                End With
            Next

        End If

    End Sub
End Class