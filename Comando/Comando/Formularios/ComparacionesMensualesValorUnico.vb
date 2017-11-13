﻿Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

' ReSharper disable once CheckNamespace
Public Class ComparacionesMensualesValorUnico

    Private Sub cmbTipoGrafico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoGrafico.SelectedIndexChanged, cmbValorAComparar.SelectedIndexChanged

        Select Case cmbTipoGrafico.SelectedIndex
            Case 1
                PictureBox1.Image = My.Resources.GraficoBarras
            Case 2
                PictureBox1.Image = My.Resources.GraficoTortas
            Case 3
                PictureBox1.Image = My.Resources.GraficoLineas
            Case 4
                PictureBox1.Image = My.Resources.GraficoBarras3D
            Case Else
                PictureBox1.Image = Nothing
                Exit Sub
        End Select

    End Sub

    Private Function _ArmarBuscarFamilias() As String

        Dim WBuscarFamilias = " WHERE Tipo in ("

        If ckQuimicos.Checked Then
            WBuscarFamilias &= "'1',"
        End If

        If ckColorantes.Checked Then
            WBuscarFamilias &= "'2',"
        End If

        If ckFarma.Checked Then
            WBuscarFamilias &= "'3',"
        End If

        If ckFazonPellital.Checked Then
            WBuscarFamilias &= "'4',"
        End If

        If ckFazonFarma.Checked Then
            WBuscarFamilias &= "'5',"
        End If

        If ckFazonQuimicos.Checked Then
            WBuscarFamilias &= "'6',"
        End If

        If ckVarios.Checked Then
            WBuscarFamilias &= "'7',"
        End If

        If WBuscarFamilias.EndsWith(",") Then
            WBuscarFamilias = Mid(WBuscarFamilias, 1, WBuscarFamilias.Length - 1)
        End If

        WBuscarFamilias &= ")"


        Return WBuscarFamilias
    End Function

    Private Function _BuscarTituloGrafico() As String
        Return cmbValorAComparar.SelectedItem
    End Function

    Private Function _BuscarDatosAComparar() As String

        Select Case cmbValorAComparar.SelectedIndex
            Case 1
                Return "Venta"
            Case 2
                Return "Kilos"
            Case 3
                Return "Factor"
            Case 4
                Return "Precio"
            Case 5
                Return "Stock"
            Case 6
                Return "Rotacion"
            Case 7
                Return "PorceVenta"
            Case 8
                Return "Pedidos"
            Case 9
                Return "Atraso"
            Case 10
                Return "PorceAtraso"
            Case 11
                Return "Promedio"
            Case Else
                Return Nothing
        End Select

    End Function

    Private Function _TraerDatosParaGraficos() As DataTable
        Dim tabla As DataTable = _ArmarTablaYDatos()

        Select Case cmbTipoComparacion.SelectedIndex

            Case 2

                '
                ' Modificamos los datos en la tabla principal. Los nombres de las familias, pasan a ser los titulos 1-12 y valores 1-12 son ahora los valores de cada familia para un mes determinado que será el tipo.
                '
                Return _FormatearDatosEntreFamilias(tabla)

            Case Else

                '
                ' Cargamos el titulo correspondiente.
                '
                Dim titulo = _BuscarTituloGrafico()

                For Each row As DataRow In tabla.Rows
                    With row
                        .Item("Titulo") = titulo
                    End With
                Next

                Return tabla

        End Select

    End Function

    Private Function _ArmarTablaYDatos() As DataTable
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

    Private Function _ArmarConsultaSQL() As String
        Dim ZSql As String = ""

        '
        ' ARMAMOS EL CONDICIONAL CON LAS FAMILIAS A BUSCAR.
        '
        Dim WBuscarFamilias = _ArmarBuscarFamilias()

        Dim Temp = "SELECT Tipo, Descripcion, Descripcion as Titulo #DATOS# FROM Comando", Aux = ""
        Dim dato = _BuscarDatosAComparar()

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

    Private Function _FormatearDatosEntreFamilias(ByVal tabla As DataTable) As DataTable
        Dim auxi As DataTable

        ' Copiamos la tabla y limpiamos las filas para quedarnos solo con la estructura.
        auxi = tabla.Copy
        auxi.Rows.Clear()


        For i = 1 To 12
            auxi.Rows.Add()
        Next

        For i = 1 To 12

            For j = 0 To 6
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

        For Each ck As CheckBox In {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}

            If ck.Checked Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Function _TraerReporteTrimestralPorValorUnico()

        Select Case cmbTipoGrafico.SelectedIndex
            Case 1
                Return New TrimestralValorUnicoBarras
            Case 2
                Return New TrimestralValorUnicoTortas
            Case 3
                Return New TrimestralValorUnicoLineas
            Case 4
                Return New TrimestralValorUnicoBarras3D
            Case Else
                Return Nothing
        End Select

    End Function

    Private Function _TraerReporteMensualPorValorUnico()
        Dim EntreFlias = False

        If cmbTipoComparacion.SelectedIndex = 2 Then
            EntreFlias = True
        End If

        Select Case cmbTipoGrafico.SelectedIndex
            Case 1

                If EntreFlias Then
                    Return New MensualEntreFamiliasValorUnicoBarras
                End If

                Return New MensualPorFamiliaValorUnicoBarras
                
            Case 4

                If EntreFlias Then
                    Return New MensualEntreFamiliasValorUnicoBarras3D
                End If

                Return New MensualPorFamiliaValorUnicoBarras3D

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
        ' BUSCAMOS EL RPT SEGUN TIPO DE COMPARACION Y TIPO DE GRAFICO INDICADO.
        '

        Select Case cmbTipoComparacion.SelectedIndex
            Case 1, 2 ' Mensual por/entre Familia

                WReporte = _TraerReporteMensualPorValorUnico()

            Case 4 ' Trimestral

                WReporte = _TraerReporteTrimestralPorValorUnico()

            Case Else
                Exit Sub
        End Select

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

        With VistaPrevia

            .Reporte = WReporte
            .Reporte.SetDataSource(tabla)
            .Mostrar()

        End With
    End Sub

    Private Sub ckTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodas.CheckedChanged
        Dim valor As Boolean = False

        Select Case ckTodas.Checked
            Case True

                valor = True

            Case False

                valor = False

            Case Else
                Exit Sub
        End Select


        For Each ck As CheckBox In {ckColorantes, ckFarma, ckFazonFarma, ckFazonPellital, ckFazonQuimicos, ckQuimicos, ckVarios}
            ck.Checked = valor
        Next

    End Sub

    Private Sub ComparacionesMensuales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ckTodas.Checked = True
    End Sub
End Class