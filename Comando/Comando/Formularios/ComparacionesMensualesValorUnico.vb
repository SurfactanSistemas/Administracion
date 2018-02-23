Imports System.Data.SqlClient

' ReSharper disable once CheckNamespace
Public Class ComparacionesMensualesValorUnico

    Private Sub ComparacionesMensuales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()
        _CargarAniosComparables()

        rbMenusal.Checked = True
        ckConsolidado.Checked = True
        cmbTipoGrafico.SelectedIndex = 0
        cmbPeriodo.SelectedIndex = 0
        txtAnioDesde.Text = _BuscarAnoPorDefecto()
        txtAnioHasta.Text = txtAnioDesde.Text
        txtFechaDiaria.Text = Date.Now.AddDays(-1).ToString("dd/MM/yyyy")

    End Sub

    Private Function _BuscarAnoPorDefecto() As String

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Ano) as Anio FROM ComandoDatosII")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Return dr.Item("Anio")

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Date.Now.Year

    End Function

    Private Sub _CargarAniosComparables()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Distinct Ano FROM ComandoDatosII")
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

                    Aux = Trim(dr.Item("Ano"))

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
        Dim chks() As CheckBox = {ckQuimicos, ckColorantes, ckFarma, ckBiocidas, ckPapel, ckFazonPellital, _
                                  ckFazonFarma, ckFazonQuimicos, ckVarios}

        If (cmbPeriodo.SelectedIndex = 2 Or (rbDiaria.Checked And cmbPeriodo.SelectedIndex = 1)) And ckConsolidado.Checked Then
            Return "Linea IN('1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11')"
        End If

        Dim WBuscarFamilias = " Linea in ("

        For i = 0 To chks.Count - 1
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
        Dim WMesesCompletos(12) As String
        Dim WAnios(12) As String

        Dim datos As DataTable = _CrearTablaDetalles()
        Dim ds As New DataSet

        '
        ' Obtenemos los meses con los cuales trabajar.
        '
        _TraerMesesAConsultar(WMeses, WAnios, WMesesCompletos)
        
        '
        ' Obtenemos los valores a comparar.
        '

        Dim WDatos() As String = _TraerValoresAComparar()

        If Not WDatos.Any(Function(v) Not IsNothing(v)) Then : Exit Function : End If

        '
        ' Obtenemos los datos de las familias en el periodo dado.
        '

        Select Case cmbPeriodo.SelectedIndex
            Case 0
                _BuscarDatosBrutos(WMeses, WDatos, datos)

                DataGridView1.DataSource = datos

                ' Si es consolidado, rearmamos la tabla con los totales por valor comparable.
                If ckConsolidado.Checked Then
                    _FormatearConsolidado(datos)
                End If

                ds.Tables.Add(datos)
            Case 1
                _BuscarDatosBrutos(WMeses, WDatos, datos)

                _FormatearAnual(datos)

                ds.Tables.Add(datos)
            Case 2

                Dim anios(4) As Integer

                If ckConsolidado.Checked And Not _ValidoParaConsolidarEntrePeriodos() Then
                    Return Nothing
                End If

                If Val(txtAnioDesde.Text) = Val(txtAnioHasta.Text) Then

                    For Each WAnio In clbAniosAComparar.CheckedItems

                        _BuscarDatosComparativoMensual(Val(WAnio), Val(WAnio), WDatos, datos, WMeses)

                    Next

                Else

                    anios(1) = Val(txtAnioDesde.Text)
                    anios(2) = Val(txtAnioHasta.Text)
                    anios(3) = Val(txtAnioDesde.Text) - 1
                    anios(4) = Val(txtAnioHasta.Text) - 1

                    For i = 1 To 4 Step 2
                        _BuscarDatosComparativoMensual(anios(i), anios(i + 1), WDatos, datos, WMeses)
                    Next

                End If

                If datos.Rows.Count = 0 OrElse datos.Rows.Count - 9 = 0 Then
                    Throw New Exception("No existen datos para alguno de los siguientes Años: " & anios(1) & " o " & anios(3))
                End If

                If ckConsolidado.Checked Then

                    _FormatearConsolidadoComparativoMensual(datos)

                End If

                ds.Tables.Add(datos)

                DataGridView1.DataSource = datos

        End Select

        '
        ' Traemos datos restantes para mostrar debajo de los graficos.
        '
        Dim datos_restantes = datos.Copy

        datos_restantes.Clear()
        datos_restantes.TableName = "Detalles2"

        WDatos(1) = "1"

        WDatos(2) = "2"

        'WDatos(3) = "3" ' Costo no se Grafica.

        WDatos(3) = "4"

        WDatos(4) = "5"

        WDatos(5) = "6"

        WDatos(6) = "7"

        WDatos(7) = "8"

        WDatos(8) = "9"

        WDatos(9) = "10"

        WDatos(10) = "11"

        _BuscarDatosBrutos(WMesesCompletos, WDatos, datos_restantes)

        Dim WTipo = 0, WAcum = 0.0

        For Each row As DataRow In datos_restantes.Rows

            WTipo = 0

            With row

                WTipo = IIf(IsDBNull(.Item("Corte")), 0, Val(.Item("Corte")))

                Select Case WTipo
                    Case 1, 2, 5, 6

                        WAcum = 0.0

                        For i = 1 To 12

                            If Not IsDBNull(.Item("Valor" & i)) Then

                                WAcum += Val(Helper.formatonumerico(.Item("Valor" & i)))

                            End If

                        Next

                        .Item("TotalFila") = WAcum

                    Case Else
                        Continue For
                End Select

            End With

        Next

        If (cmbPeriodo.SelectedIndex = 0 And ckConsolidado.Checked) Or cmbPeriodo.SelectedIndex = 1 Then

            For i = 1 To 4
                datos_restantes.Rows.Add(99999)
            Next

        End If

        ds.Tables.Add(datos_restantes)

        Dim WTablaConsolidado = datos_restantes.Copy

        WTablaConsolidado.TableName = "Consolidados"

        If (cmbPeriodo.SelectedIndex = 0 And ckConsolidado.Checked) Or cmbPeriodo.SelectedIndex = 1 Then

            _FormatearConsolidado(WTablaConsolidado, _ValoresComparables.Count, True, WDatos)

        End If

        DataGridView1.DataSource = WTablaConsolidado

        ds.Tables.Add(WTablaConsolidado)

        Return ds

    End Function

    Private Sub _FormatearConsolidadoComparativoMensual(ByRef datos As DataTable)

        If datos.Rows.Count = 0 Then Exit Sub

        Dim _datos = datos.Copy
        Dim _row As DataRow

        _datos.Clear()

        For i = 1 To datos.Rows.Count / 9
            _row = _datos.NewRow()
            _datos.Rows.Add(_row)
        Next

        Dim aux = -9

        For i = 0 To _datos.Rows.Count - 1

            With _datos.Rows(i)

                aux += 9

                ' Asignamos los datos generales segun el primer registro de cada año.
                .Item("Tipo") = datos.Rows(aux).Item("Tipo")
                .Item("Corte") = datos.Rows(aux).Item("Corte")
                .Item("Titulo") = datos.Rows(aux).Item("Titulo")
                .Item("Descripcion") = "Consolidado"

                ' Extraemos los datos de las fechas e inicializamos los valores de cada uno en cero.
                For j = 1 To 12
                    .Item("Valor" & j) = 0
                    .Item("Titulo" & j) = datos.Rows(aux).Item("Titulo" & j)
                Next

                ' Recorremos los datos de todas las lineas por mes y vamos consolidando en el mes correspondiente.
                For x = aux To aux + 8

                    For j = 1 To 12

                        .Item("Valor" & j) += IIf(IsDBNull(datos.Rows(x).Item("Valor" & j)), 0, datos.Rows(x).Item("Valor" & j))

                    Next

                Next

            End With

        Next

        datos = _datos.Copy

    End Sub

    Private Function _ValidoParaConsolidarEntrePeriodos() As Boolean
        Return {ckVenta, ckKilos, ckPedidos, ckAtrasados}.Any(Function(ck) ck.Checked)
    End Function

    Private Sub _BuscarDatosComparativoMensual(ByVal anio1 As Object, ByVal anio2 As Object, ByVal wDatos As String(), ByRef datos As DataTable, ByVal wMeses As String())

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim row As DataRow
        Dim rowIndex = 0
        Dim ZCorte = 0
        Dim WBuscarFamilias = _ArmarBuscarFamilias()
        Dim WDatosABuscar = "", WValoresABuscar = ""
        Dim WMes = ""
        Dim WAnio1 = anio1, WAnio2 = anio2
        Dim WDato = ""
        Dim WCantDatos = (From d In wDatos Where Trim(d) <> "").Count

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()

            ' Armamos la consulta de los campos a comparar para cada mes.
            If WAnio1 = WAnio2 Then
                For j = 1 To 10

                    ' Recorremos los meses pedidos.
                    WDatosABuscar = ""

                    If Not IsNothing(wDatos(j)) OrElse wDatos(j) <> "" Then

                        If ckConsolidado.Checked Then
                            Select Case Val(wDatos(j))

                                Case 1, 2, 5, 6

                                    WDatosABuscar &= wDatos(j) & ","

                                Case Else

                                    WDatosABuscar = ""

                            End Select
                        Else
                            WDatosABuscar &= wDatos(j) & ","
                        End If

                    End If

                    WValoresABuscar = ""
                    For i = 0 To 12

                        If wMeses(i) > -1 AndAlso Not IsNothing(wMeses(i)) Then

                            WValoresABuscar &= "Importe" & i & ","

                        End If

                    Next

                    ' Chequeamos que hayan datos que buscar.
                    If Trim(WDatosABuscar) = "" Then
                        Return
                    End If

                    ' Eliminamos la ultima coma.
                    WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)
                    WValoresABuscar = WValoresABuscar.Substring(0, WValoresABuscar.Length - 1)


                    ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                    WMes = ""

                    WMes = " 1/ " & WAnio1 & " "

                    cm.CommandText = "SELECT Linea, Tipo, DesTipo as Descripcion, " & WValoresABuscar & " FROM ComandoDatosII WHERE Tipo IN (" & WDatosABuscar & ") and " & WBuscarFamilias & " AND Ano = '" & WAnio1 & "' order by linea, ano, tipo"

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = datos.NewRow
                            rowIndex = 0
                            ZCorte += 1
                            With row
                                .Item("Tipo") = dr.Item("Linea")
                                .Item("Descripcion") = _NombreLineaSegunNumero(.Item("Tipo"))
                                .Item("Corte") = ZCorte
                                .Item("Titulo") = _DescripcionSegunTipo(dr.Item("Tipo"))

                                For i = 0 To 12

                                    If wMeses(i) > -1 AndAlso Not IsNothing(wMeses(i)) Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = wMeses(i) & "/" & Str$(WAnio1)

                                        WDato = dr.Item("Importe" & Trim(wMeses(i)))

                                        .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
                                        .Item("Titulo" & rowIndex) = WMes

                                    End If

                                Next
                            End With

                            datos.Rows.Add(row)

                        Loop

                    End If

                    If Not dr.IsClosed Then
                        dr.Close()
                        dr = Nothing
                    End If

                Next
            Else

                For j = 1 To 10

                    ' Recorremos los meses pedidos.
                    WDatosABuscar = ""

                    If Not IsNothing(wDatos(j)) OrElse wDatos(j) <> "" Then
                        WDatosABuscar &= wDatos(j) & ","
                    End If

                    Dim WMesDesde = Val(txtMesDesde.Text), WMesHasta = Val(txtMesHasta.Text)

                    WValoresABuscar = ""
                    Dim auxi1 = 0

                    For i = WMesDesde To 12
                        auxi1 += 1
                    Next

                    For i = 0 To 11

                        If wMeses(i) > -1 And Not IsNothing(wMeses(i)) Then

                            WValoresABuscar &= "Importe" & Val(wMeses(i)) & ","

                        End If

                    Next

                    Dim auxi2 = auxi1 + 1

                    'For i = 0 To WMesHasta

                    '    If wMeses(auxi2) > -1 Then

                    '        WValoresABuscar &= "Importe" & i + 1 & ","

                    '        auxi2 += 1
                    '    End If

                    'Next

                    ' Chequeamos que hayan datos que buscar.
                    If Trim(WDatosABuscar) = "" Then
                        Return
                    End If

                    ' Eliminamos la ultima coma.
                    WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)
                    WValoresABuscar = WValoresABuscar.Substring(0, WValoresABuscar.Length - 1)


                    ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                    WMes = ""

                    WMes = " 1/ " & WAnio1 & " "

                    cm.CommandText = "SELECT Linea, Tipo, DesTipo as Descripcion, " & WValoresABuscar & " FROM ComandoDatosII WHERE Tipo IN (" & WDatosABuscar & ") and " & WBuscarFamilias & " AND Ano in ('" & WAnio1 & "', '" & WAnio2 & "') order by linea, ano, tipo"

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = datos.NewRow
                            rowIndex = 0
                            ZCorte += 1
                            With row
                                .Item("Tipo") = IIf(WCantDatos = 1, ZCorte, dr.Item("Linea"))
                                .Item("Descripcion") = _NombreLineaSegunNumero(.Item("Tipo"))
                                .Item("Corte") = ZCorte
                                .Item("Titulo") = Trim(dr.Item("Descripcion"))

                                For i = 0 To auxi1 - 1

                                    If wMeses(i) > -1 Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = Val(wMeses(i)) & "/" & Str$(WAnio1)

                                        WDato = dr.Item("Importe" & Val(wMeses(i)))

                                        .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
                                        .Item("Titulo" & rowIndex) = WMes

                                    End If

                                Next

                                If dr.Read Then

                                    auxi2 = auxi1

                                    For i = 0 To WMesHasta - 1

                                        If wMeses(auxi2) > -1 Then

                                            rowIndex += 1

                                            WMes = ""
                                            WMes = Val(wMeses(auxi2)) & "/" & Str$(WAnio2)

                                            WDato = dr.Item("Importe" & Val(wMeses(auxi2)))

                                            .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
                                            .Item("Titulo" & rowIndex) = WMes

                                            auxi2 += 1

                                        End If

                                    Next

                                End If
                            End With


                            datos.Rows.Add(row)

                        Loop

                    End If

                    If Not dr.IsClosed Then
                        dr.Close()
                        dr = Nothing
                    End If

                Next

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        DataGridView1.DataSource = datos
    End Sub

    Private Sub _FormatearAnual(ByRef datos As DataTable)

        ' Tenemos los datos del periodo seleccionado por familias?
        Dim _datos As DataTable = datos.Copy
        Dim _rows() As DataRow
        Dim row As DataRow
        Dim wacu = 0.0

        Dim WInicial = "", WFinal = ""

        _datos.Rows.Clear()

        If datos.Rows.Count > 0 Then

            WInicial = datos.Rows(0).Item(16)

            For i = 27 To 16 Step -1

                If Not IsDBNull(datos.Rows(0).Item(i)) Then

                    WFinal = datos.Rows(0).Item(i)

                    Exit For

                End If

            Next

        End If

        For i = 1 To 9

            _rows = datos.Select("Tipo = '" & i & "'")

            If _rows.Count > 0 Then

                row = _datos.NewRow

                For j = 0 To _rows.Count - 1

                    wacu = 0.0

                    For x = 4 To 15

                        If Not IsDBNull(_rows(j).Item(x)) Then
                            wacu += Val(Helper.formatonumerico(_rows(j).Item(x)))
                        End If

                    Next

                    With row

                        .Item(1) = _rows(j).Item(1)
                        .Item("Titulo" & j + 1) = _rows(j).Item(2)
                        .Item(2) = WInicial & " Al " & WFinal
                        .Item(4 + j) = wacu

                    End With

                Next

                _datos.Rows.Add(row)

            End If

        Next

        datos = _datos.Copy

    End Sub

    Public Sub _RegraficarConsolidado(ByVal valor As String, Optional ByVal limpiar As Boolean = False)

        If limpiar Then
            For Each _c As CheckBox In _ValoresComparables()
                _c.Checked = False
            Next
        End If

        ' Seleccionamos el valor comparable.


        Select Case UCase(valor)
            Case "VENTAS U$S"
                ckVenta.Checked = True
            Case "KILOS"
                ckKilos.Checked = True
            Case "STOCK"
                ckStock.Checked = True
            Case "ATRASO"
                ckAtrasados.Checked = True
            Case "PEDIDOS"
                ckPedidos.Checked = True
            Case "ROTACIÓN"
                ckRotacion.Checked = True
            Case "FACTOR"
                ckFactor.Checked = True
            Case "PRECIO"
                ckPrecio.Checked = True
            Case Else
                Exit Sub
        End Select

        btnGenerar.PerformClick()

    End Sub

    Private Sub _FormatearConsolidado(ByRef datos As DataTable, Optional ByVal valoresSeleccionados As Integer = 0, Optional ByVal consolidadoTotal As Boolean = False, Optional ByVal WDatos() As String = Nothing)
        Dim _datos = datos.Copy
        Dim aux = valoresSeleccionados
        Dim aux2 = 0.0

        If valoresSeleccionados = 0 Then
            aux = _ValoresComparables.Count(Function(v) v.Checked)
        End If

        Dim corte = Math.Ceiling(datos.Rows.Count / aux)

        _datos.Rows.Clear()

        For i = 0 To aux - 1

            _datos.Rows.Add()

            For j = 1 To 12
                _datos.Rows(i).Item("Valor" & j) = 0
            Next

            _datos.Rows(i).Item("Titulo") = txtMesDesde.Text & "/" & txtAnioDesde.Text & " al " & txtMesHasta.Text & "/" & txtAnioHasta.Text

            _datos.Rows(i).Item("TotalFila") = 0

        Next

        aux2 = 0

        If consolidadoTotal Then

            For i = 0 To _datos.Rows.Count - 1

                If Not IsNothing(WDatos(i + 1)) Then
                    _datos.Rows(i).Item("Corte") = WDatos(i + 1)
                End If

            Next

            datos.DefaultView.Sort = "Titulo"

            DataGridView1.DataSource = datos

            Dim WRow() As DataRow

            For i = 0 To WDatos.Length - 2

                If Not IsNothing(WDatos(i + 1)) And i <= WDatos.Length + 1 Then

                    WRow = datos.Select("Corte = '" & WDatos(i + 1) & "'")

                    If WRow.Length = 0 Then Continue For

                    For j = 1 To 12

                        For x = 0 To WRow.Length - 1

                            _datos.Rows(i).Item("Valor" & j) += IIf(IsDBNull(WRow(x).Item("Valor" & j)), 0, WRow(x).Item("Valor" & j))
                            _datos.Rows(i).Item("Titulo" & j) = IIf(IsDBNull(WRow(x).Item("Titulo" & j)), "", WRow(x).Item("Titulo" & j))
                            _datos.Rows(i).Item("Tipo") = IIf(IsDBNull(WRow(x).Item("Tipo")), 0, WRow(x).Item("Tipo"))

                        Next

                    Next

                End If

            Next

            ' Dim cou = datos.Select("Titulo is null").Count

            ' Recalculamos los valores.
            For i = 0 To _datos.Rows.Count - 1

                With _datos.Rows(i)

                    .Item("Descripcion") = _DescripcionSegunTipo(.Item("Corte"))

                    Select Case Val(.Item("Corte"))

                        Case 7 ' Factor

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", .Item("Titulo" & j))
                                ZAu = Trim(ZAu)

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 1) ' Venta
                                    WAux2 = _BuscarDato(WMes, WAnio, 3) ' Costo

                                    WAux = WAux / WAux2

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(WAux))

                                End If

                            Next

                        Case 9 ' % Ventas

                            Dim WAux = 0.0, WAux2 = 0.0, WCantMeses = 0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", .Item("Titulo" & j))
                                ZAu = Trim(ZAu)

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Ventas U$S.
                                    WAux += _BuscarDato(WMes, WAnio, 1) ' Ventas U$S

                                    WCantMeses += 1

                                End If

                            Next

                            WAux /= WCantMeses

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", .Item("Titulo" & j))
                                ZAu = Trim(ZAu)

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    WAux2 = _BuscarDato(WMes, WAnio, 1) ' Nro Pedidos

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(((WAux2 / WAux) - 1) * 100))

                                End If

                            Next

                        Case 10 ' % Atraso

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", .Item("Titulo" & j))
                                ZAu = Trim(ZAu)

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Nro Atrasos y Nro Pedidos para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 6) ' Nro Atrasos
                                    WAux2 = _BuscarDato(WMes, WAnio, 5) ' Nro Pedidos

                                    .Item("Valor" & j) = Val(Helper.formatonumerico((WAux / WAux2) * 100))

                                End If

                            Next

                        Case 11 'Rotacion

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", .Item("Titulo" & j))
                                ZAu = Trim(ZAu)

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 4) ' Stock
                                    WAux2 = _BuscarDato(WMes, WAnio, 3) ' Costo

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(WAux / WAux2))

                                End If

                            Next

                    End Select

                End With

            Next

        Else

            ' ACA esta fallando a la hora de traer Rotacion como mensual acumulado.
            Dim WA = 0

            For x = 0 To datos.Rows.Count - 1

                If x <> 0 AndAlso x Mod corte = 0 Then
                    aux2 += 1
                End If

                For i = 1 To 12

                    WA = IIf(IsDBNull(datos.Rows(x).Item("Corte")), 0, datos.Rows(x).Item("Corte"))

                    If WA = 3 Then Continue For

                    _datos.Rows(aux2).Item("Valor" & i) += IIf(IsDBNull(datos.Rows(x).Item("Valor" & i)), 0, datos.Rows(x).Item("Valor" & i))
                    _datos.Rows(aux2).Item("Titulo" & i) = IIf(IsDBNull(datos.Rows(x).Item("Titulo" & i)), "", datos.Rows(x).Item("Titulo" & i))
                    _datos.Rows(aux2).Item("Descripcion") = IIf(IsDBNull(datos.Rows(x).Item("Titulo")), "", datos.Rows(x).Item("Titulo"))
                    _datos.Rows(aux2).Item("Corte") = IIf(IsDBNull(datos.Rows(x).Item("Corte")), 0, datos.Rows(x).Item("Corte"))
                    _datos.Rows(aux2).Item("Tipo") = IIf(IsDBNull(datos.Rows(x).Item("Tipo")), 0, datos.Rows(x).Item("Tipo"))

                Next

            Next

            For i = 0 To aux2

                With _datos.Rows(i)

                    Select Case Val(.Item("Corte"))

                        Case 7 ' Factor

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", Trim(.Item("Titulo" & j)))

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 1) ' Venta
                                    WAux2 = _BuscarDato(WMes, WAnio, 3) ' Costo

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(WAux / WAux2))

                                End If

                            Next

                        Case 9 ' % Ventas

                            Dim WAux = 0.0, WAux2 = 0.0, WCantMeses = 0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", Trim(.Item("Titulo" & j)))

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux += _BuscarDato(WMes, WAnio, 1) ' Ventas U$S

                                    WCantMeses += 1

                                End If

                            Next

                            WAux /= WCantMeses

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", Trim(.Item("Titulo" & j)))

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    WAux2 = _BuscarDato(WMes, WAnio, 1) ' Nro Pedidos

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(((WAux2 / WAux) - 1) * 100))

                                End If

                            Next

                        Case 10 ' % Atraso

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", Trim(.Item("Titulo" & j)))

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 6) ' Nro Atrasos
                                    WAux2 = _BuscarDato(WMes, WAnio, 5) ' Nro Pedidos

                                    .Item("Valor" & j) = Val(Helper.formatonumerico((WAux / WAux2) * 100))

                                End If

                            Next

                        Case 11 'Rotacion

                            Dim WAux = 0.0, WAux2 = 0.0
                            Dim WMes, WAnio
                            Dim ZAu = ""

                            For j = 1 To 12

                                ZAu = ""
                                ZAu = IIf(IsDBNull(.Item("Titulo" & j)), "", Trim(.Item("Titulo" & j)))

                                If Trim(ZAu) <> "" Then

                                    WMes = Mid(ZAu, 1, 1)
                                    WAnio = ZAu.Substring(ZAu.Length - 4)

                                    ' Buscamos los valores de Costo y Stock para determinado mes.
                                    WAux = _BuscarDato(WMes, WAnio, 4) ' Stock
                                    WAux2 = _BuscarDato(WMes, WAnio, 3) ' Costo

                                    .Item("Valor" & j) = Val(Helper.formatonumerico(WAux / WAux2))

                                End If

                            Next

                    End Select

                End With

            Next


        End If

        datos = _datos.Copy

        DataGridView1.DataSource = datos
    End Sub

    Private Function _BuscarDato(ByVal wMes As Object, ByVal wAnio As Object, ByVal _Tipo As Integer) As Double

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT sum(Importe" & wMes & ") as Valor FROM ComandoDatosII WHERE Tipo = '" & _Tipo & "' AND Ano = '" & wAnio & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Return IIf(IsDBNull(dr.Item("Valor")), 0, Val(Helper.formatonumerico(dr.Item("Valor"))))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return 0.0
    End Function

    Private Sub _BuscarDatosBrutos(ByVal wMeses() As String, ByVal WDatos As String(), ByRef tabla As DataTable)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim row As DataRow
        Dim rowIndex = 0
        Dim WBuscarFamilias = _ArmarBuscarFamilias()
        Dim WDatosABuscar = "", WValoresABuscar = ""
        Dim WMes = ""
        Dim WAnio = ""
        Dim WDato = ""

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()

            ' Armamos la consulta de los campos a comparar para cada mes.
            For j = 1 To 10

                ' Recorremos los meses pedidos.
                WDatosABuscar = ""

                If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                    WDatosABuscar &= "'" & WDatos(j) & "',"
                End If

                WValoresABuscar = ""
                For i = 0 To 12

                    If Val(wMeses(i)) > 0 AndAlso Not IsNothing(wMeses(i)) Then

                        WValoresABuscar &= "Importe" & i & ","

                    End If

                Next


                ' Chequeamos que hayan datos que buscar.
                If Trim(WDatosABuscar) = "" Or Trim(WValoresABuscar) = "" Then
                    Continue For
                End If

                ' Eliminamos la ultima coma.
                WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)
                WValoresABuscar = WValoresABuscar.Substring(0, WValoresABuscar.Length - 1)


                ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                WMes = ""
                ' Los meses y años se estan guardando como ' 1/ 2017 '

                If Val(txtAnioDesde.Text) = Val(txtAnioHasta.Text) Then

                    WAnio = Trim(txtAnioDesde.Text)

                    cm.CommandText = "SELECT Linea, Tipo, DesTipo as Descripcion, " & WValoresABuscar & " FROM ComandoDatosII WHERE Ano = '" & WAnio & "' AND " & WBuscarFamilias & " AND Tipo in (" & WDatosABuscar & ") order by linea, ano, tipo"

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = tabla.NewRow
                            rowIndex = 0
                            With row
                                .Item("Tipo") = dr.Item("Linea")
                                .Item("Descripcion") = _NombreLineaSegunNumero(.Item("Tipo"))
                                .Item("Corte") = Val(dr.Item("Tipo"))
                                .Item("Titulo") = _DescripcionSegunTipo(.Item("Corte"))

                                For i = 0 To 12

                                    If wMeses(i) > -1 AndAlso Not IsNothing(wMeses(i)) Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = Val(wMeses(i)) & "/" & Str$(WAnio)

                                        WDato = dr.Item("Importe" & i)

                                        .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
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

                    For i = Val(txtMesDesde.Text) To 12

                        aux1 += 1

                    Next


                    WDatosABuscar = ""

                    If Not IsNothing(WDatos(j)) OrElse WDatos(j) <> "" Then
                        WDatosABuscar &= "'" & WDatos(j) & "',"
                    End If

                    WValoresABuscar = ""
                    'For i = Val(txtMesDesde.Text) - 1 To 12

                    '    If Val(wMeses(i)) > 0 AndAlso Not IsNothing(wMeses(i)) Then

                    '        WValoresABuscar &= "Importe" & i & ","

                    '    End If

                    'Next

                    Dim aux2 = aux1 + 1

                    'For i = 0 To Val(txtMesHasta.Text) - 1

                    '    If wMeses(i) > -1 AndAlso Not IsNothing(wMeses(i)) Then

                    '        WValoresABuscar &= "Importe" & i + 1 & ","

                    '        aux2 += 1

                    '    End If

                    'Next

                    For i = 0 To 11

                        If wMeses(i) > -1 AndAlso Not IsNothing(wMeses(i)) Then

                            WValoresABuscar &= "Importe" & Val(wMeses(i)) & ","

                            aux2 += 1

                        End If

                    Next

                    ' Chequeamos que hayan datos que buscar.
                    If Trim(WDatosABuscar) = "" Then
                        Return
                    End If

                    ' Eliminamos la ultima coma.
                    WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)
                    WValoresABuscar = WValoresABuscar.Substring(0, WValoresABuscar.Length - 1)

                    WAnio = Trim(txtAnioDesde.Text)

                    WMes = " 1/ " & WAnio & " "
                    Dim WAnio2 = Trim(txtAnioHasta.Text)

                    cm.CommandText = "SELECT Linea, Tipo, DesTipo as Descripcion, " & WValoresABuscar & " FROM ComandoDatosII WHERE Ano IN ('" & WAnio & "', '" & WAnio2 & "') AND " & WBuscarFamilias & " AND Tipo in (" & WDatosABuscar & ") ORDER BY Linea, Ano, tipo"

                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        ' Agregamos una fila por cada familia.
                        Do While dr.Read()

                            row = tabla.NewRow
                            rowIndex = 0
                            With row
                                .Item("Tipo") = dr.Item("Linea")
                                .Item("Descripcion") = _NombreLineaSegunNumero(.Item("Tipo"))
                                .Item("Corte") = Val(dr.Item("Tipo"))
                                .Item("Titulo") = _DescripcionSegunTipo(.Item("Corte"))

                                For i = 0 To aux1 - 1

                                    If wMeses(i) > -1 And Not IsNothing(wMeses(i)) Then
                                        rowIndex += 1

                                        WMes = ""
                                        WMes = Val(wMeses(i)) & "/" & Str$(WAnio)

                                        WDato = dr.Item("Importe" & Val(wMeses(i)))

                                        .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
                                        .Item("Titulo" & rowIndex) = WMes

                                    End If

                                Next

                                ' Leemos los meses del Próximo año.
                                If dr.Read() Then

                                    aux2 = aux1

                                    For i = 1 To Val(txtMesHasta.Text)

                                        If wMeses(aux2) > -1 And Not IsNothing(wMeses(i)) Then
                                            rowIndex += 1

                                            WMes = ""
                                            WMes = Val(wMeses(aux2)) & "/" & Str$(WAnio2)

                                            WDato = dr.Item("Importe" & i)

                                            .Item("Valor" & rowIndex) = Val(Helper.formatonumerico(WDato))
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

    Private Function _DescripcionSegunTipo(ByVal item As Object) As String

        Return Helper._DescripcionSegunTipo(item)

    End Function

    Private Function _NombreLineaSegunNumero(ByVal item As Object) As String

        Return Helper._NombreLineaSegunNumero(item)

    End Function

    Private Function _TraerValoresAComparar() As String()
        Dim WDatos(11) As String
        Dim i = 0
        i = 0
        If ckVenta.Checked Then
            i += 1
            WDatos(i) = "1"
        End If

        If ckKilos.Checked Then
            i += 1
            WDatos(i) = "2"
        End If

        If ckStock.Checked Then
            i += 1
            WDatos(i) = "4"
        End If

        If ckPedidos.Checked Then
            i += 1
            WDatos(i) = "5"
        End If

        If ckAtrasados.Checked Then
            i += 1
            WDatos(i) = "6"
        End If

        If ckFactor.Checked Then
            i += 1
            WDatos(i) = "7"
        End If

        If ckRotacion.Checked Then
            i += 1
            WDatos(i) = "11"

            i += 1
            WDatos(i) = "3" ' Costo

        End If

        If ckPrecio.Checked And Not ckConsolidado.Checked Then
            i += 1
            WDatos(i) = "8"
        End If

        If ckPorcentaje.Checked Then
            i += 1
            WDatos(i) = "9"
        End If

        If ckPorcentajeAtrasos.Checked Then
            i += 1
            WDatos(i) = "10"
        End If

        Return WDatos
    End Function

    Private Sub _TraerMesesAConsultar(ByRef WMeses() As String, ByRef WAnios() As String, ByRef WMesesCompletos() As String)
        ReDim WMeses(12)
        ReDim WAnios(12)

        Dim WIndice = 0
        Dim WMesInicial = Val(txtMesDesde.Text)
        Dim WMesFinal = Val(txtMesHasta.Text)
        Dim WAnioInicial = Val(txtAnioDesde.Text)
        Dim WAnioFinal = Val(txtAnioHasta.Text)

        '
        ' Guardamos la posicion del mes chequeado y le sumamos uno para que coincida con el numero de mes.
        '

        If WAnioInicial = WAnioFinal Then
            For i = WMesInicial To WMesFinal

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
                Throw New Exception("Las fechas deben ser correlativas.")
            End If

            ' Calculamos la cantidad de meses del primer año.
            For i = WMesInicial To 12

                aux1 += 1

            Next

            For i = 0 To aux1 - 1

                WMeses(i) = Str$(WMesInicial)
                WAnios(i) = Str$(WAnioInicial)

                WMesInicial += 1

                WIndice = i
            Next

            For i = 1 To WMesFinal

                aux2 += 1

                WMeses(aux1) = Str$(aux2)
                WAnios(aux1) = Str$(WAnioFinal)

                aux1 += 1
                WIndice += 1
            Next

        End If

        WMesesCompletos = WMeses

        If Val(txtMesHasta.Text) = Date.Now.Month Then

            If WMesesCompletos(WIndice - 1) < Val(txtMesHasta.Text) Then

                WMesesCompletos(WIndice) = txtMesHasta.Text
                WIndice += 1

            End If

        End If

        '
        ' Completamos los lugares restantes con -1 asi no los tenemos en cuenta en la consulta.
        '
        For i = WIndice + 1 To 12
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
            .Columns.Add("Corte", System.Type.GetType("System.Double"))

            For i = 1 To 12
                .Columns.Add("Valor" & i, System.Type.GetType("System.Double"))
            Next

            For i = 1 To 12
                .Columns.Add("Titulo" & i)
            Next

            .Columns.Add("TotalFila", System.Type.GetType("System.Double"))

        End With

        Return tabla

    End Function

    Private Function _FamiliasSeleccionadas() As Boolean

        Return Familias().Any(Function(ck) ck.Checked)

    End Function

    Private Function Familias() As CheckBox()

        Return {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios, ckBiocidas, ckPapel}
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim tabla As DataSet

        '
        ' VERIFICAMOS SI ES UNA COMPARACIÓN DIARIA. EN CASO DE QUE SI, LO PROCESAMOS A PARTE.
        '

        If rbDiaria.Checked Then
            _ProcesarComparacionDiaria()
            Exit Sub
        End If

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
        ' BUSCAMOS LOS DATOS CON LOS CUALES TRABAJAR.
        '

        Try

            tabla = _ArmarTablaYDatos() '_TraerDatosParaGraficos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        If tabla Is Nothing Then : Exit Sub : End If

        If tabla.Tables(0).Rows.Count = 0 Then
            MsgBox("No hay datos para graficar.", MsgBoxStyle.Information)
            txtMesDesde.Focus()
            Exit Sub
        End If

        With Grafico
            .Tabla = tabla.Tables(0)
            .TablaGrilla = tabla.Tables(1)
            .TablaConsolidados = tabla.Tables(2)

            Select Case cmbPeriodo.SelectedIndex
                Case 0 ' Mensual

                    If ckConsolidado.Checked Then
                        .Tipo = 1
                    Else
                        .Tipo = 2
                    End If
                Case 1 ' Ex anual

                    .Tipo = 3
                Case 2 ' Ex Comparativo Mensual

                    .Tipo = 4
            End Select

            .WindowState = FormWindowState.Maximized
            .Show()

            ._ProcesarGrafico()

        End With

    End Sub

    Private Sub _ProcesarComparacionDiaria()

        Dim WMes, WDesde, WAnio, WTitulo, WLineas As String
        Dim WValores() As String
        Dim WDatosRows As DataRowCollection
        Dim WDatos As DataTable = _ArmarTablaDiario()
        Dim WTipo As Short = -1
        Dim WTablaGrilla As DataTable = WDatos.Clone

        Try
            WMes = Mid$(txtFechaDiaria.Text, 4, 2) 'txtMesDesdeCompDiario.Text
            WAnio = Mid$(txtFechaDiaria.Text, 7, 4) 'txtAnioCompDiario.Text
            WDesde = Mid$(txtFechaDiaria.Text, 1, 2) 'txtDesdeDia.Text

            ' Validamos Mes.
            If Val(WMes) < 1 Or Val(WMes) > 12 Then Throw New Exception("El mes debe ser un valor válido.")

            ' Validamos los dias.
            If Val(WDesde) < 1 Or Val(WDesde) > 31 Then Throw New Exception("El Inicio del Período debe ser válido.")

            WValores = _TraerValoresAComparar()

            ' Verificamos que se haya seleccionado por lo menos un valor a comparar.
            If Not WValores.Any(Function(v) Not IsNothing(v)) Then Throw New Exception("No se ha seleccionado ningún valor a comparar.")

            ' Extraemos los datos, segun sea el tipo de comparacion diaria que se seleccionó.

            Select Case cmbPeriodo.SelectedIndex
                Case 0

                    ' Obtenemos los datos del mes indicado.
                    WDatosRows = _TraerDatosDiariosEntreLineas(WMes, WDesde, WAnio, WValores) '_TraerDatosDiarios(WMes, WDia, WAnio, WValores)

                    For Each WRow As DataRow In WDatosRows
                        WDatos.ImportRow(WRow)
                    Next



                    ' Armamos el titulo.
                    WLineas = ""

                    For i = 0 To 11

                        If Not IsNothing(WValores(i)) AndAlso Val(WValores(i)) > 0 Then

                            WLineas &= Helper._DescripcionSegunTipo(WValores(i)) & ", "

                        End If

                    Next
                    WLineas = Trim(WLineas)
                    If WLineas.Length > 0 Then WLineas = WLineas.Substring(0, WLineas.Length - 1)
                    WLineas = Helper.ReplaceLastComma(WLineas)


                    WTipo = 1

                    'DataGridView1.DataSource = WDatos

                    WTitulo = "Comparación Entre Lineas" & vbCrLf & "- Fecha: " & txtFechaDiaria.Text & " -" & vbCrLf & "( " & WLineas & " )"

                Case 1

                    ' Obtenemos los datos del mes indicado.
                    
                    If ckConsolidado.Checked Then

                        WDatosRows = _TraerDatosDiariosEntrePeriodosConsolidado(WMes, WDesde, WAnio, WValores)

                        For Each WRow As DataRow In WDatosRows
                            WDatos.ImportRow(WRow)
                        Next

                        WTitulo = "Comparación Entre Periodos" & vbCrLf & "- Fecha: " & txtFechaDiaria.Text & " -" & vbCrLf & "( CONSOLIDADO )"

                    Else

                        WDatosRows = _TraerDatosDiariosEntreLineas(WMes, WDesde, WAnio, WValores) '_TraerDatosDiariosEntrePeriodos(WMes, WDesde, WAnio, WValores)

                        For Each WRow As DataRow In WDatosRows
                            WDatos.ImportRow(WRow)
                        Next

                    End If
                    
                    WTipo = 1

                    If ckConsolidado.Checked Then
                        WTipo = 2
                    End If

                    '    DataGridView1.DataSource = WDatos


            End Select

            If WDatos.Rows.Count = 0 Then Throw New Exception("No hay datos que graficar.")

            ' Cargamos la descripcion de las Lineas.
            For Each row As DataRow In WDatos.Rows
                row.Item("LineaDesc") = Mid$(txtFechaDiaria.Text, 1, 2) '_NombreLineaSegunNumero(row.Item("Linea"))
            Next

            ' Obtenemos todos los datos del mes indicado para mostrar en grilla luego.
            Array.Clear(WValores, 0, WValores.Length)

            WValores(1) = "1"
            WValores(2) = "2"

            WDatosRows = _TraerDatosDiariosEntreLineas(WMes, WDesde, WAnio, WValores, True) '_TraerDatosDiarios(WMes, WDia, WAnio, WValores)

            For Each WRow As DataRow In WDatosRows
                WTablaGrilla.ImportRow(WRow)
            Next

            With GraficoDiario

                .Tipo = WTipo
                .Tabla = WDatos
                .Titulo = WTitulo

                .TablaGrilla = WTablaGrilla
                
                ._ProcesarGrafico()
                .WindowState = FormWindowState.Maximized
                .Show()
                .Focus()

            End With

        Catch ex As Exception
            MsgBox("Error al querer graficar." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function _TraerDatosDiariosEntrePeriodosConsolidado(ByVal wMes As String, ByVal wDesde As String, ByVal wAnio As String, ByVal wValores As String()) As DataRowCollection
        Dim Tabla As DataTable = _ArmarTablaDiario()
        Dim WBuscarLineas As String = _ArmarBuscarFamilias()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WBuscarTipos As String = ""

        Try

            For i = 0 To wValores.Length - 1

                If Not IsNothing(wValores(i)) Then

                    WBuscarTipos &= "'" & wValores(i) & "', "

                End If

            Next

            If WBuscarTipos = "" Then Return Nothing

            WBuscarTipos = Trim(WBuscarTipos).Substring(0, Trim(WBuscarTipos).Length - 1)

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT Tipo, Dia, Mes, Ano, sum(Importe1) as Importe1, sum(Importe2) as Importe2, sum(Importe3) as Importe3 FROM ComandoDatosDiario WHERE Tipo IN(" & WBuscarTipos & ") AND " & WBuscarLineas & " AND Dia = " & wDesde & " AND Mes = '" & wMes & "' AND Ano = '" & wAnio & "' GROUP BY Tipo, Dia, Mes, Ano"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos para graficar." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Tabla.Rows
    End Function


    Private Function _TraerDatosDiariosEntreLineas(ByVal wMes As String, ByVal wDesde As String, ByVal wAnio As String, ByVal wValores As String(), Optional ByVal WConsolidado As Boolean = False) As DataRowCollection
        Dim Tabla As DataTable = _ArmarTablaDiario()
        Dim WBuscarLineas As String = IIf(WConsolidado, "Linea IN('1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11')", _ArmarBuscarFamilias())
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WBuscarTipos As String = ""

        Try

            For i = 0 To wValores.Length - 1

                If Not IsNothing(wValores(i)) Then

                    WBuscarTipos &= "'" & wValores(i) & "', "

                End If

            Next

            If WBuscarTipos = "" Then Return Nothing

            WBuscarTipos = Trim(WBuscarTipos).Substring(0, Trim(WBuscarTipos).Length - 1)

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT Linea, Tipo, Dia, Mes, Ano, sum(Importe1) as Importe1, sum(Importe2) as Importe2, sum(Importe3) as Importe3 FROM ComandoDatosDiario WHERE Tipo IN(" & WBuscarTipos & ") AND " & WBuscarLineas & " AND Dia = " & wDesde & " AND Mes = '" & wMes & "' AND Ano = '" & wAnio & "' GROUP BY Linea, Tipo,Dia, Mes, Ano"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos para graficar." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Tabla.Rows
    End Function

    Private Function _ArmarTablaDiario() As DataTable
        Dim tabla As New DataTable

        With tabla.Columns
            .Add("Linea")
            .Add("Tipo")
            .Add("Dia")
            .Add("Mes")
            .Add("Ano")
            .Add("Importe1", System.Type.GetType("System.Double"))
            .Add("Importe2", System.Type.GetType("System.Double"))
            .Add("Importe3", System.Type.GetType("System.Double"))
            .Add("LineaDesc")
        End With

        Return tabla
    End Function

    Private Function _PeriodoValido() As Boolean

        Dim valido = False
        Dim aux = 0

        For i = Val(txtMesDesde.Text) To 12
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

        Dim control As CheckBox = sender

        If cmbPeriodo.SelectedIndex = 2 Then 'Or (rbDiaria.Checked And cmbPeriodo.SelectedIndex = 1) Then

            For Each ck As CheckBox In _ValoresComparables()

                If control.Checked = False Then
                    Exit For
                End If

                If control.Name <> ck.Name Then
                    ck.Checked = False
                End If

            Next

        End If

    End Sub

    Private Sub btnSeleccionarAnios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarAnios.Click

        PanelSeleccionAnios.Visible = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        PanelSeleccionAnios.Visible = False
    End Sub

    Private Sub _ProcesarPeriodo()

        GroupBox2.Enabled = True

        If rbDiaria.Checked Then

            ckConsolidado.Checked = cmbPeriodo.SelectedIndex = 1

        Else

            Select Case cmbPeriodo.SelectedIndex
                Case 1

                    cmbTipoGrafico.SelectedIndex = 0
                    btnSeleccionarAnios.Visible = False
                    ckConsolidado.Checked = True

                Case 2

                    If clbAniosAComparar.Items.Count = 0 Then
                        Dim WAnioHasta, WAnioDesde

                        WAnioDesde = Val(txtAnioDesde.Text)
                        WAnioHasta = Val(txtAnioHasta.Text)

                        If WAnioDesde > 0 And WAnioHasta > 0 And WAnioHasta = WAnioDesde Then

                            clbAniosAComparar.Items.Clear()

                            Dim WAnioActual = WAnioDesde

                            For i = 0 To 3

                                clbAniosAComparar.Items.Add(Val(WAnioActual) - i)

                            Next

                            btnSeleccionarAnios.Visible = True
                            btnSeleccionarAnios.PerformClick()

                        End If
                    End If

                    For Each ck As CheckBox In _ValoresComparables()

                        If _ValoresComparables.Count(Function(_ck) _ck.Checked) = 1 Then
                            Exit For
                        End If

                        ck.Checked = False

                    Next

                    If Familias.Count(Function(_ck) _ck.Checked) > 1 Then

                        For Each ck As CheckBox In Familias()

                            ck.Checked = False

                            If Familias.Count(Function(_ck) _ck.Checked) = 1 Then
                                Exit For
                            End If

                        Next
                    End If


                    If ckConsolidado.Checked Then
                        ckConsolidado.Checked = False
                    End If


                    If ckTodosValores.Checked Then
                        ckTodosValores.Checked = False
                    End If

                    If Trim(txtMesDesde.Text) = "" Then
                        txtMesDesde.Text = "1"
                    End If

                    If Trim(txtMesHasta.Text) = "" Then
                        txtMesHasta.Text = "12"
                    End If

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


            Dim WAnioHasta, WAnioDesde

            WAnioDesde = Val(txtAnioDesde.Text)
            WAnioHasta = Val(txtAnioHasta.Text)

            If WAnioDesde > 0 And WAnioHasta > 0 And WAnioHasta = WAnioDesde Then

                clbAniosAComparar.Items.Clear()

                Dim WAnioActual = WAnioDesde

                For i = 0 To 3

                    clbAniosAComparar.Items.Add(Val(WAnioActual) - i)

                Next

            End If

            cmbPeriodo.DroppedDown = True
            cmbPeriodo.Focus()

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

    Private Sub ckConsolidado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckConsolidado.CheckedChanged

        If ckConsolidado.Checked Then

            If rbDiaria.Checked Then

                cmbPeriodo.SelectedIndex = 1

            End If

            For Each ck As CheckBox In Familias()

                With ck

                    .Checked = True

                    .Enabled = False

                End With

            Next

        Else

            If rbDiaria.Checked Then

                cmbPeriodo.SelectedIndex = 0

            End If

            For Each ck As CheckBox In Familias()

                With ck

                    .Checked = False
                    .Enabled = True

                End With

            Next

        End If

    End Sub

    Private Sub cmbPeriodo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPeriodo.KeyDown

        If e.KeyData = Keys.Enter Then

            _ProcesarPeriodo()

        ElseIf e.KeyData = Keys.Escape Then
            cmbPeriodo.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbPeriodo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriodo.DropDownClosed
        _ProcesarPeriodo()
    End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    '    Dim WRand As New Random
    '    Dim WImporte1, WImporte2, WImporte3 As Double
    '    Dim Vector(11, 7) As String
    '    Dim ZSql As String
    '    Dim cn As SqlConnection = New SqlConnection()
    '    Dim cm As SqlCommand = New SqlCommand("")
    '    Dim WClave, WAno, WMes, WDia As String

    '    Try

    '        cn.ConnectionString = Helper._ConectarA
    '        cn.Open()
    '        cm.Connection = cn

    '        cm.CommandText = "DELETE FROM ComandoDatosDiario"
    '        cm.ExecuteNonQuery()

    '        For A = 2017 To 2018

    '            For i = 1 To 12

    '                For d = 1 To 31

    '                    For Each WLinea As Integer In {1, 2, 3, 4, 5, 6, 7, 8, 9}

    '                        Dim XTipo As String

    '                        For j = 1 To 11

    '                            XTipo = j
    '                            WAno = A
    '                            WMes = i
    '                            WDia = d
    '                            WImporte1 = (WRand.NextDouble() * (350.1 - 1000.9)) + 1000.9
    '                            WImporte1 = Val(Helper.formatonumerico(WImporte1))

    '                            WImporte2 = (WRand.NextDouble() * (350.1 - 1000.9)) + 1000.9
    '                            WImporte2 = Val(Helper.formatonumerico(WImporte2))

    '                            WImporte3 = (WRand.NextDouble() * (350.1 - 1000.9)) + 1000.9
    '                            WImporte3 = Val(Helper.formatonumerico(WImporte3))

    '                            WClave = ceros(WLinea, 4) & WAno & ceros(WMes, 2) & ceros(WDia, 2) & ceros(XTipo, 2)

    '                            ZSql = ""
    '                            ZSql = "INSERT INTO ComandoDatosDiario (Clave, Linea, Ano, Mes, Dia, Tipo, Importe1, Importe2, Importe3) " & _
    '                                   " VALUES ('" & WClave & "', " & WLinea & ", " & WAno & ", " & WMes & ", " & WDia & ", " & XTipo & ", " & Str$(WImporte1) & ", " & Str$(WImporte2) & ", " & Str$(WImporte3) & ")"

    '                            cm.CommandText = ZSql
    '                            cm.ExecuteNonQuery()
    '                        Next

    '                    Next

    '                Next

    '            Next

    '        Next

    '        MsgBox("Termino")

    '    Catch ex As Exception
    '        Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
    '    Finally

    '        cn.Close()
    '        cn = Nothing
    '        cm = Nothing

    '    End Try

    'End Sub

    Private Sub rbMenusal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMenusal.CheckedChanged

        If rbMenusal.Checked Then
            gbDesde.Enabled = True
            gbHasta.Enabled = True
            gbComparativoDiario.Enabled = False
            cmbPeriodo.DataSource = {"Mensual", "Comparativo Entre Lineas", "Comparativo Entre Periodos"}
            txtMesDesde.Focus()
        End If

    End Sub

    Private Sub rbDiaria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDiaria.CheckedChanged

        If rbDiaria.Checked Then
            gbDesde.Enabled = False
            gbHasta.Enabled = False
            gbComparativoDiario.Enabled = True
            cmbPeriodo.DataSource = {"Comparativo Entre Lineas", "Comparativo Entre Periodos"}
            cmbPeriodo.SelectedIndex = 1
            _ProcesarPeriodo()
            btnSeleccionarAnios.Visible = False
            txtFechaDiaria.Focus()
            txtFechaDiaria.SelectionStart = 0
            txtFechaDiaria.SelectionLength = txtFechaDiaria.Text.Length

        End If

    End Sub

    Private Sub Lineas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBiocidas.CheckedChanged, ckColorantes.CheckedChanged, ckFarma.CheckedChanged, ckFazonFarma.CheckedChanged, ckFazonPellital.CheckedChanged, ckFazonQuimicos.CheckedChanged, ckPapel.CheckedChanged, ckQuimicos.CheckedChanged, ckVarios.CheckedChanged

        Dim control As CheckBox = sender

        If cmbPeriodo.SelectedIndex = 2 Then 'Or (rbDiaria.Checked And cmbPeriodo.SelectedIndex = 1) Then

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

End Class