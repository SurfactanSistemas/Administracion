Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

' ReSharper disable once CheckNamespace
Public Class ComparacionesMensualesValorUnico

    Private Sub ComparacionesMensuales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()
        ckTodas.Checked = True
        cmbTipoGrafico.SelectedIndex = 0
        cmbTipoComparacion.SelectedIndex = 0
        cmbPeriodo.SelectedIndex = 0
        txtAnio.Text = ""
        txtAnio.Text = Date.Now.ToString("yyyy")
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

    Private Function _BuscarDatosAComparar() As String
        Return Nothing
    End Function

    Private Function _TraerDatosParaGraficos() As DataTable
        Return _ArmarTablaYDatos()

        'If _EsEntreFamilias() Then
        '    Return _FormatearDatosMensualEntreFamilias(tabla)
        'End If

        'Return tabla

    End Function

    Private Function _ArmarTablaYDatos() As DataTable
        Dim WAnio As Integer = 0
        Dim WMeses(12) As Integer
        
        Dim row As DataRow
        Dim WDatosBrutos As DataTable
        Dim datos As DataTable = _CrearTablaDetalles()

        '
        ' Obtenemos los meses con los cuales trabajar.
        '
        WMeses = _TraerMesesAConsultar()

        '
        ' Obtenemos el año por el cual se van a traer los datos.
        '
        WAnio = Val(txtAnio.Text)

        '
        ' Obtenemos los valores a comparar.
        '

        Dim WDatos() As String = _TraerValoresAComparar()

        '
        ' Obtenemos los datos de las familias en el periodo dado.
        '

        Select Case cmbPeriodo.SelectedIndex
            Case 0
                _BuscarDatosBrutos(WMeses, WAnio, WDatos, datos)
            Case 1
                _BuscarDatosBrutosAnual(WMeses, WAnio, WDatos, datos)
        End Select

        Return datos

    End Function

    Private Function _BuscarDatosBrutosAnual(ByVal wMeses() As Integer, ByVal wAnio As Integer, ByVal WDatos() As String,
                                        ByRef tabla As DataTable) As DataTable

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
        Dim WDato = ""
        Dim WValor = 0.0
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
                            WDatosABuscar &= WDatos(j) & wMeses(i) & "+"
                        End If

                    End If

                Next

                ' Chequeamos que hayan datos que buscar.
                If Trim(WDatosABuscar) = "" Then
                    Return Nothing
                End If

                ' Eliminamos el ultimo '+'.
                WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)


                ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                WMes = ""
                ' Los meses y años se estan guardando como ' 1/ 2017 '
                WMes = " 1/ " & wAnio & " "

                cm.CommandText = "SELECT Tipo, Descripcion, (" & WDatosABuscar & ") as Total FROM Comando WHERE Impre1 = '" & WMes & "' and " & WBuscarFamilias

                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    ' Agregamos una fila por cada familia.
                    row = tabla.NewRow

                    rowIndex = 0
                    ZCorte += 1

                    Do While dr.Read()
                        row.Item("Corte") = wAnio
                        row.Item("Descripcion") = WDatos(j)  'dr.Item("Descripcion")

                        
                        With row
                            '.Item("Tipo") = IIf(WCantDatos = 1 OrElse rdPorSeparado.Checked, ZCorte, dr.Item("Tipo"))

                            '.Item("Titulo") = UCase(WDatos(j))

                            WValor = IIf(IsDBNull(dr.Item("Total")), 0.0, dr.Item("Total"))

                            If WValor <> 0 Then
                                rowIndex += 1

                                .Item("Valor" & rowIndex) = WValor 'dr.Item("")
                                .Item("Titulo" & rowIndex) = dr.Item("Descripcion") 'WMes
                            End If

                            'For i = 0 To 11

                            '    If wMeses(i) > -1 Then
                            '        rowIndex += 1

                            '        WMes = ""
                            '        WMes = wMeses(i) & "/" & Str$(wAnio)

                            '        WDato = WDatos(j) & wMeses(i)

                            '        .Item("Valor" & rowIndex) = dr.Item(WDato)
                            '        .Item("Titulo" & rowIndex) = WMes

                            '    End If

                            'Next
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

        Return tabla
    End Function

    Private Function _BuscarDatosBrutos(ByVal wMeses() As Integer, ByVal wAnio As Integer, ByVal WDatos() As String,
                                        ByRef tabla As DataTable) As DataTable

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
                            WDatosABuscar &= WDatos(j) & wMeses(i) & ","
                        End If

                    End If

                Next

                ' Chequeamos que hayan datos que buscar.
                If Trim(WDatosABuscar) = "" Then
                    Return Nothing
                End If

                ' Eliminamos la ultima coma.
                WDatosABuscar = WDatosABuscar.Substring(0, WDatosABuscar.Length - 1)


                ' Buscamos el registro correspondiente a ese mes y buscamos los datos de los meses, segun datos de mas arriba.
                WMes = ""
                ' Los meses y años se estan guardando como ' 1/ 2017 '
                WMes = " 1/ " & wAnio & " "

                cm.CommandText = "SELECT Tipo, Descripcion, " & WDatosABuscar & " FROM Comando WHERE Impre1 = '" & WMes & "' and " & WBuscarFamilias

                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    ' Agregamos una fila por cada familia.
                    Do While dr.Read()

                        row = tabla.NewRow
                        rowIndex = 0
                        ZCorte += 1
                        With row
                            .Item("Tipo") = IIf(WCantDatos = 1 OrElse rdPorSeparado.Checked, ZCorte, dr.Item("Tipo"))
                            .Item("Descripcion") = dr.Item("Descripcion")
                            .Item("Corte") = ZCorte
                            .Item("Titulo") = UCase(WDatos(j))

                            For i = 0 To 11

                                If wMeses(i) > -1 Then
                                    rowIndex += 1

                                    WMes = ""
                                    WMes = wMeses(i) & "/" & Str$(wAnio)

                                    WDato = WDatos(j) & wMeses(i)

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
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
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

    Private Function _TraerInformacionPorFamilia() As DataTable


        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        Dim tabla As DataTable = _CrearTablaDetalles()
        Dim ZSql As String = ""

        Try
            ZSql = _ArmarConsultaSQL()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            cm.CommandText = ZSql
            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos necesario para generar los reportes desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerMesesAConsultar() As Integer()
        Dim WMeses(12) As Integer
        Dim WIndice = 0
        Dim temp() As CheckBox = {ckEnero, ckFebrero, ckMarzo, ckAbril, ckMayo, ckJunio, ckJulio, ckAgosto, ckSeptiembre, ckOctubre, ckNoviembre, ckDiciembre}
        Dim ck As CheckBox

        '
        ' Guardamos la posicion del mes chequeado y le sumamos uno para que coincida con el numero de mes.
        '
        For i = 0 To 11

            ck = temp(i)

            If ck.Checked Then
                WMeses(WIndice) = i + 1
                WIndice += 1
            End If

        Next

        '
        ' Completamos los lugares restantes con -1 asi no los tenemos en cuenta en la consulta.
        '
        For i = WIndice To 11
            WMeses(i) = -1
        Next

        Return WMeses
    End Function

    Private Function _ArmarConsultaSQL() As String
        Dim ZSql As String = ""
        Dim WBuscarFamilias As String = ""
        Dim Temp, Aux, dato As String

        '
        ' ARMAMOS EL CONDICIONAL CON LAS FAMILIAS A BUSCAR.
        '
        WBuscarFamilias = _ArmarBuscarFamilias()
        
        Aux = ""
        Temp = "SELECT Tipo, Descripcion, Descripcion as Titulo #DATOS# FROM Comando"
        dato = _BuscarDatosAComparar()

        If dato Is Nothing Then
            Throw New Exception("Debe seleccionarse un valor por el cual comparar.")
        End If

        Aux = _ArmarTraerValores(dato)
        Aux &= _ArmarTraerFechas()

        ZSql = Temp.Replace("#DATOS#", Aux)

        ZSql &= WBuscarFamilias

        Return ZSql

    End Function

    Private Function _ArmarTraerFechas() As String
        Dim Aux As String = ""

        For i = 1 To 12
            Aux &= ", Impre" & i & " as Titulo" & i
        Next

        Return Aux

    End Function

    Private Function _ArmarTraerValores(ByVal dato As String) As String
        Dim Aux As String = ""

        For i = 1 To 12
            Aux &= ", " & dato & i & " as Valor" & i
        Next

        Return Aux

    End Function

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

    Private Function _FormatearDatosMensualEntreFamilias(ByVal tabla As DataTable) As DataTable
        Dim auxi As DataTable

        ' Copiamos la tabla y limpiamos las filas para quedarnos solo con la estructura.
        auxi = tabla.Copy
        auxi.Rows.Clear()


        For i = 1 To 12
            auxi.Rows.Add()
        Next

        For i = 1 To 12

            For j = 0 To tabla.Rows.Count - 1
                ' Crear una fila nueva por cada mes de cada flia.
                With auxi.Rows(i - 1)
                    .Item("tipo") = i
                    .Item("valor" & j + 1) = tabla.Rows(j).Item("valor" & i)
                    .Item("titulo" & j + 1) = tabla.Rows(j).Item("Descripcion")
                    .Item("Descripcion") = tabla.Rows(j).Item("titulo" & i)
                End With

            Next

        Next

        Return auxi
    End Function

    Private Function _FamiliasSeleccionadas() As Boolean

        Return Familias().Any(Function(ck) ck.Checked)

    End Function

    Private Function _EsEntreFamilias() As Boolean

        Return cmbTipoComparacion.SelectedIndex = 2

    End Function

    Private Function _TraerReporteMensual()

        ' CALCULAMOS LA CANTIDAD DE FAMILIAS A COMPARAR PARA SABER QUE TIPO DE GRAFICO SE TIENE QUE UTILIZAR.
        Dim WCantFamilias = (From familia In Familias() Where familia.Checked).Count()
        Dim seleccionados = ValoresComparables().Count(Function(ck) ck.Checked)

        If seleccionados > 1 Then ' Seleccionamos tipo de grafico 'Linea' cuando es mas de un valor
            cmbTipoGrafico.SelectedIndex = 1
        End If

        Select Case cmbTipoGrafico.SelectedIndex
            Case 0 ' Barras

                ''EN CASO DE QUE HAYA MAS DE UNA FAMILIA, PUEDE PASAR DOS COSAS: QUE SEAN SOLO DOS O QUE SEAN MAS DE DOS.

                'If WCantFamilias = 2 AndAlso (_EsComparacionMensual() OrElse _EsComparativoMensual()) Then
                '    ' RETORNAMOS EL GRAFICO QUE SALEN DOS BARRAS POR MES.
                '    Return New MensualEntreFamiliasBarras
                'End If

                ' EN CUALQUIER OTRO CASO, RETORNAREMOS EL GRAFICO COMUN DE MES/AÑO POR BARRA.

                Return New MensualPorFamiliaBarras
            Case 1 ' Lineas

                'EN CASO DE QUE HAYA MAS DE UNA FAMILIA, PUEDE PASAR DOS COSAS: QUE SEAN SOLO DOS O QUE SEAN MAS DE DOS.

                'If WCantFamilias = 2 AndAlso (_EsComparacionMensual() OrElse _EsComparativoMensual()) Then
                '    ' RETORNAMOS EL GRAFICO QUE SALEN DOS BARRAS POR MES.
                '    Return New MensualEntreFamiliaLineas
                'End If

                ' EN CUALQUIER OTRO CASO, RETORNAREMOS EL GRAFICO COMUN DE MES/AÑO POR BARRA.

                Return New MensualPorFamiliaLineas
            Case Else
                Return Nothing
        End Select

    End Function

    Private Function ValoresComparables() As CheckBox()

        Return {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}
    End Function

    Private Function _EsComparativoMensual() As Boolean

        Return cmbTipoComparacion.SelectedIndex = 2
    End Function

    Private Function _EsComparacionMensual() As Boolean

        Return cmbTipoComparacion.SelectedIndex = 0
    End Function

    Private Function Familias() As CheckBox()

        Return {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim WReporte As ReportDocument = Nothing
        Dim tabla As DataTable

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

    Private Function _MesesElegidos() As Boolean
        Return {ckEnero, ckFebrero, ckMarzo, ckAbril, ckMayo, ckJunio, ckJulio, ckAgosto, ckSeptiembre, ckOctubre, ckNoviembre, ckDiciembre}.Any(Function(ck) ck.Checked)
    End Function

    Private Sub ckTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodas.CheckedChanged, ckPedidos.CheckedChanged, ckOctubre.CheckedChanged
        For Each ck As CheckBox In {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}
            ck.Checked = ckTodas.Checked
        Next
    End Sub

    Private Sub ckTodosValores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodosValores.CheckedChanged
        For Each ck As CheckBox In _ValoresComparables()
            ck.Checked = ckTodosValores.Checked
        Next
    End Sub

    Private Function _ValoresComparables() As CheckBox()
        Return {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}
    End Function

    Private Sub ckTodosMeses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodosMeses.CheckedChanged
        For Each ck As CheckBox In {ckEnero, ckFebrero, ckMarzo, ckAbril, ckMayo, ckJunio, ckJulio, ckAgosto, ckSeptiembre, ckOctubre, ckNoviembre, ckDiciembre}
            ck.Checked = ckTodosMeses.Checked
        Next
    End Sub

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
            rdPorSeparado.Enabled = False
            rdTodoEnUno.Checked = True
        Else
            cmbTipoGrafico.SelectedIndex = 0 ' Barras
            rdPorSeparado.Enabled = True
        End If

    End Sub
End Class