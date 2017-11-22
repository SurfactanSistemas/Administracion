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
        txtAnio.Text = ""
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
        Dim tabla As DataTable = _ArmarTablaYDatos()

        If _EsEntreFamilias() Then
            Return _FormatearDatosMensualEntreFamilias(tabla)
        End If

        Return tabla

    End Function

    Private Function _ArmarTablaYDatos() As DataTable
        Dim WAnio As Integer = 0
        Dim WMeses(12) As Integer
        Dim row As DataRow
        Dim tabla As DataTable = _CrearTablaDetalles()

        '
        ' Obtenemos los mese con los cuales trabajar.
        '
        WMeses = _TraerMesesAConsultar()

        '
        ' Obtenemos el año por el cual se van a traer los datos.
        '
        WAnio = Val(txtAnio.Text)

        For i = 1 To 12

            If WMeses(i - 0) <> -1 Then

                row = tabla.NewRow()



                tabla.Rows.Add(row)

            End If
            
        Next

        Return _TraerInformacionPorFamilia()

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

        Return {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}.Any(Function(ck) ck.Checked)

    End Function

    Private Function _EsEntreFamilias() As Boolean

        Return cmbTipoComparacion.SelectedIndex = 2

    End Function

    Private Function _TraerReporteMensual()

        Select Case cmbTipoGrafico.SelectedIndex
            Case 0 ' Barras

                If _EsEntreFamilias() Then
                    Return New MensualEntreFamiliasValorUnicoBarras
                End If

                Return New MensualPorFamiliaValorUnicoBarras

            Case 1 ' Lineas

                If _EsEntreFamilias() Then
                    Return Nothing
                End If

                Return New MensualPorFamiliaValorUnicoLineas

            Case Else
                Return Nothing
        End Select

    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim WReporte As ReportDocument = Nothing
        Dim tabla As DataTable = Nothing

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

            tabla = _TraerDatosParaGraficos()

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

        'With VistaPrevia

        '    .Reporte = WReporte
        '    .Reporte.SetDataSource(tabla)
        '    .Mostrar()

        'End With
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
        For Each ck As CheckBox In {ckVenta, ckAtrasados, ckFactor, ckKilos, ckPedidos, ckPorcentajeAtrasos, ckPrecio, ckRotacion, ckStock, ckPorcentaje}
            ck.Checked = ckTodosValores.Checked
        Next
    End Sub

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
        If seleccionados > 2 Then
            cmbTipoGrafico.SelectedIndex = 1
        Else
            cmbTipoGrafico.SelectedIndex = 0
        End If

    End Sub
End Class