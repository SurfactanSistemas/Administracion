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
        txtAnioDesde.Text = Date.Now.ToString("yyyy")
        txtAnioHasta.Text = Date.Now.ToString("yyyy")
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

                ' Si es consolidado, rearmamos la tabla con los totales por valor comparable.
                If ckConsolidado.Checked Then
                    _FormatearConsolidado(datos)
                End If

                ds.Tables.Add(datos)
            Case 1
                _BuscarDatosBrutos(WMeses, WAnios, WDatos, datos)

                _FormatearAnual(datos)

                ds.Tables.Add(datos)
            Case 2
                ' Validamos que se haya seleccionado un unico valor a comparar.
                'Dim WCantValoresSeleccionados = (From v In ValoresComparables() Where v.Checked).Count

                ' Modificar por el comportamiento de familias cuando mensual.
                'If WCantValoresSeleccionados > 1 Then
                '    Throw New Exception("En 'Comparativo Mensual', sólo puede seleccionarse un único valor a comparar.")
                'End If

                ' Recorremos los años. Buscamos los datos y los agrupamos por Valor Comparativo y Año.

                For Each anio In ckAnios.CheckedItems
                    '_BuscarDatosBrutos(WMeses, anio, WDatos, datos)

                    _buscarDatosComparativoMensual(anio, WDatos, datos)

                Next

                '_BuscarDatosBrutosAnualComparativo(WMeses, datos)

                ds.Tables.Add(datos)

        End Select

        Return ds

    End Function

    Private Sub _BuscarDatosComparativoMensual(ByVal anio As Object, ByVal wDatos As String(), ByVal datos As DataTable)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim tabla As DataTable = datos.Copy
        Dim row As DataRow
        Dim rowIndex = 0
        Dim ZCorte = 0
        Dim WBuscarFamilias = _ArmarBuscarFamilias()
        Dim WDatosABuscar = ""
        Dim WMes = ""
        Dim WAnio = anio
        Dim WDato = ""
        Dim WCantDatos = (From d In wDatos Where Trim(d) <> "").Count
        Dim WMeses(12) As String

        'tabla = _CrearTablaDetalles()
        tabla.Rows.Clear()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()

            For i = 0 To 11
                WMeses(i) = i + 1
            Next

            WMeses(12) = -1

            ' Armamos la consulta de los campos a comparar para cada mes.
            For j = 1 To 10

                ' Recorremos los meses pedidos.
                WDatosABuscar = ""
                For i = 0 To 11

                    If wMeses(i) > -1 Then

                        If Not IsNothing(wDatos(j)) OrElse wDatos(j) <> "" Then
                            WDatosABuscar &= wDatos(j) & Trim(wMeses(i)) & ","
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
                            .Item("Titulo") = UCase(_NombreValorSegunColumna(wDatos(j)))

                            For i = 0 To 11

                                If wMeses(i) > -1 Then
                                    rowIndex += 1

                                    WMes = ""
                                    WMes = wMeses(i) & "/" & Str$(WAnio)

                                    WDato = wDatos(j) & Trim(wMeses(i))

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

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _FormatearAnual(ByRef datos As DataTable)

        ' Tenemos los datos del periodo seleccionado por familias?
        Dim _datos As DataTable = datos.Copy
        Dim _rows() As DataRow
        Dim row As DataRow
        Dim wacu = 0.0

        _datos.Rows.Clear()

        For i = 1 To 7

            _rows = datos.Select("Tipo = '" & i & "'")

            If _rows.Count > 0 Then

                row = _datos.NewRow

                For j = 0 To _rows.Count - 1

                    wacu = 0.0

                    For x = 4 To 14

                        If Not IsDBNull(_rows(j).Item(x)) Then
                            wacu += Val(Helper.formatonumerico(_rows(j).Item(x)))
                        End If

                    Next

                    With row

                        .Item(1) = _rows(j).Item(1)
                        .Item("Titulo" & j + 1) = _rows(j).Item(2)
                        .Item(4 + j) = wacu

                    End With

                Next

                _datos.Rows.Add(row)

            End If

        Next

        datos = _datos.Copy

    End Sub

    Private Sub _FormatearConsolidado(ByRef datos As DataTable)
        Dim _datos = datos.Copy
        Dim temp() As DataRow
        Dim aux = _ValoresComparables.Count(Function(v) v.Checked)
        Dim aux2 = 0.0

        _datos.Rows.Clear()

        _datos.Rows.Add()

        For i = 1 To aux
            _datos.Rows(0).Item("Valor" & i) = 0
        Next

        For i = 1 To 7

            temp = datos.Select("Tipo = '" & i & "'")

            If temp.Count > 0 Then

                For x = 1 To aux

                    aux2 = 0.0

                    For z = 1 To 12

                        aux2 += IIf(IsDBNull(temp(x - 1).Item("Valor" & z)), 0, temp(x - 1).Item("Valor" & z))

                    Next

                    If Not IsDBNull(temp(x - 1).Item("Titulo")) Then
                        _datos.Rows(0).Item("Titulo" & x) = temp(x - 1).Item("Titulo")
                    End If

                    _datos.Rows(0).Item("Valor" & x) += aux2

                Next

            End If


        Next

        _datos.Rows(0).Item("Descripcion") = "Consolidado"

        datos = _datos.Copy
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
                                .Item("Titulo") = UCase(_NombreValorSegunColumna(WDatos(j)))

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
                                .Item("Titulo") = UCase(_NombreValorSegunColumna(WDatos(j)))

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

                                    aux2 = aux1 + 1

                                    For i = 1 To Val(txtMesHasta.Text)

                                        If wMeses(aux2) > -1 Then
                                            rowIndex += 1

                                            WMes = ""
                                            WMes = wMeses(aux2) & "/" & Str$(WAnio2)

                                            WDato = WDatos(j) & Trim(wMeses(aux2))

                                            .Item("Valor" & rowIndex) = dr.Item(WDato)
                                            .Item("Titulo" & rowIndex) = WMes

                                            aux2 += 1
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

    Private Function _NombreValorSegunColumna(ByVal columna As String) As String

        Select Case UCase(columna)
            Case "VENTA"
                Return "Venta (U$S)"
            Case "PRECIO"
                Return "Precio (U$S)"
            Case "PORCEVENTA"
                Return "Ventas (%)"
            Case "PORCEATRASO"
                Return "Atrasos (%)"
            Case "KILOS"
                Return "Kilos (Kgs)"
            Case "COSTO"
                Return "Costo (U$S)"
            Case "STOCK"
                Return "Stock (Kgs)"
            Case "PRECIO"
                Return "Precio Promedio (U$S)"
            Case Else
                Return columna
        End Select

    End Function

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

        If seleccionados > 1 And Not ckConsolidado.Checked Then ' Seleccionamos tipo de grafico 'Linea' cuando es mas de un valor
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

        'DataGridView1.DataSource = tabla

        With Grafico
            .Tabla = tabla.Tables(0)


            Select Case cmbPeriodo.SelectedIndex
                Case 0 ' Mensual

                    If ckConsolidado.Checked Then
                        .Tipo = 1
                    Else
                        .Tipo = 2
                    End If
                Case 1 ' Ex anual

                    .Tipo = 3

            End Select
            
            If Not .IsDisposed Then
                .Show()
            Else
                .Focus()
            End If

            ._ProcesarGrafico()

        End With


        'With VistaPrevia

        '    .Reporte = WReporte
        '    .Reporte.SetDataSource(tabla)
        '    .Mostrar()

        'End With
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
        If seleccionados > 1 And Not ckConsolidado.Checked Then
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
                ckConsolidado.Checked = False

            Case 2
                btnSeleccionarAnios.Visible = True
                btnSeleccionarAnios.PerformClick()

            Case Else

                btnSeleccionarAnios.Visible = False
                Button1.PerformClick()

        End Select

        If Not ckConsolidado.Checked Then
            For Each ck As CheckBox In Familias()
                If Familias.Count(Function(c) c.Checked) > 1 Then
                    ck.Checked = False
                End If
            Next
        End If

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

        If _EsComparacionMensual() And Not ckConsolidado.Checked Then

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
                    .Checked = True
                    .Enabled = False
                End With
            Next

        Else

            For Each ck As CheckBox In Familias()
                With ck
                    .Checked = False
                    .Enabled = True
                End With
            Next

        End If

    End Sub
End Class