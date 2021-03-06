﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Pallets
    Dim Grabar As Boolean = True
    Sub New(Optional ByVal WProforma As String = "", Optional ByVal WPedido As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtProforma.Text = WProforma
        txtPedido.Text = WPedido

    End Sub

    Private Sub Pallets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Cargamos los datos de la Proforma.
        If Trim(txtProforma.Text) <> "" Then
            txtControlKgTotalesProforma.Text = "0"
            _CargarInformacionPallets()
        End If
    End Sub

    Public Sub _CargarInformacionPallets()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ap.Pallet Nro, ap.CodigoPallet Pallet, a.Descripcion, SUM(ap.Bultos) Bultos," _
                                              & "(SUM(ap.KgBultos * ap.Bultos) + ISNULL(a.Tara, 0) + sum(ap.Bultos * ISNULL(ar.Tara, 0))) KgBrutos," _
                                              & "(sum(ap.KgBultos * ap.Bultos)) KgNetos, ap.FechaDisponible As Disponible " _
                                              & "FROM ArmadoPallets ap LEFT JOIN Articulo a ON a.Codigo = ap.CodigoPallet INNER JOIN Articulo ar ON ap.CodigoEnvase = ar.Codigo " _
                                              & "WHERE ap.Proforma = '" & txtProforma.Text & "' " _
                                              & "GROUP BY ap.Pallet, ap.CodigoPallet, a.Tara, a.Descripcion, ap.FechaDisponible")


        'Dim dr As SqlDataReader
        Dim tabla As New DataTable
        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn


            Using dr = cm.ExecuteReader

                If dr.HasRows Then
                    tabla.Load(dr)
                End If

            End Using


            ' Buscamos la cantidad de Kilos totales del pedido asociado si hubiese alguno.

            txtControlKgTotalesProforma.Text = "0"
            lblAviso.Visible = False

            If txtProforma.Text.Trim <> "" Then
                cm.CommandText = "select ISNULL(sum(Cantidad),0) TotalKilos from ProformaExportacion where Proforma = '" & txtProforma.Text & "'"
                Using dr = cm.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        txtControlKgTotalesProforma.Text = IIf(IsDBNull(dr.Item("TotalKilos")), "0", dr.Item("TotalKilos"))
                    End If

                End Using

            End If

            With txtControlKgTotalesProforma
                .Text = Helper.formatonumerico(.Text)
            End With

        Catch ex As Exception
            Throw New Exception("Hubo un problema al cargar los Pallets referidos a esta Proforma desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try


        dgvPallets.DataSource = tabla

        For Each col As String In {"Nro", "Pallet", "Bultos", "KgBrutos", "KgNetos", "Disponible"}
            Dim WColumn As DataGridViewColumn = dgvPallets.Columns(col)
            If Not IsNothing(WColumn) Then WColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        _CalcularPesos()

        lblTotalKgNetos.Text = Val(lblTotalKgNetos.Text)

        Try
            Dim SQLCnslt As String = "SELECT AvisoPackingList FROM ProformaExportacion where Proforma = '" & txtProforma.Text & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If Row IsNot Nothing Then
                With Row
                    If Val(OrDefault(.Item("AvisoPackingList"), 0)) = 1 Then
                        btn_ReAbrirPackinglist.Visible = True
                        Grabar = False
                        btnAgregarPallet.Enabled = False
                    End If
                End With
            End If
        Catch ex As Exception
            MsgBox("Error al consultar ProformaExportacioin para la validacion de la re apertura de Packing List")
        End Try




    End Sub


    Private Sub _CalcularPesos()
        Dim WKgBrutos = 0.0
        Dim WKgNetos = 0.0
        For Each row As DataGridViewRow In dgvPallets.Rows
            Dim WBrutos = If(row.Cells("KgBrutos").Value, "")
            Dim WNetos = If(row.Cells("KgNetos").Value, "")

            WKgBrutos += Val(Helper.formatonumerico(WBrutos))
            WKgNetos += Val(Helper.formatonumerico(WNetos))

        Next

        lblTotalKgBrutos.Text = Helper.formatonumerico(WKgBrutos)
        lblTotalKgNetos.Text = Helper.formatonumerico(WKgNetos)
        lblTotalPallets.Text = dgvPallets.Rows.Count

        Dim a, b

        a = Val(Helper.formatonumerico(lblTotalKgNetos.Text))
        b = Val(Helper.formatonumerico(txtControlKgTotalesProforma.Text))

        With lblAviso
            .Visible = False
            lblAvisoPackingList.Visible = False

            If b <> 0 Then
                If a <> b Then
                    .Visible = True
                    _ActualizarMarcaProforma(txtProforma.Text, "0")
                Else
                    _ActualizarMarcaProforma(txtProforma.Text, "1")
                End If
            End If

        End With
    End Sub

    Private Sub _ActualizarMarcaProforma(ByVal WProforma As String, ByVal WMarca As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "UPDATE ProformaExportacion SET PackingList = '" & WMarca & "' WHERE Proforma = '" & WProforma & "'"

            cm.ExecuteNonQuery()

            cm.CommandText = "SELECT AvisoPackingList as Aviso, PackingList, Cerrada, Entregado FROM ProformaExportacion WHERE Proforma = '" & WProforma & "' AND Renglon = '01'"

            Using dr As SqlDataReader = cm.ExecuteReader

                With dr
                    If .HasRows Then
                        .Read()

                        Dim WCompleto = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))
                        Dim WMarcaAviso = IIf(IsDBNull(.Item("Aviso")), "", .Item("Aviso"))
                        Dim WCerrada = IIf(IsDBNull(.Item("Cerrada")), "0", .Item("Cerrada"))
                        Dim WEntregado = IIf(IsDBNull(.Item("Entregado")), "", .Item("Entregado"))

                        ' Corroboramos si se ha marcado como PackingList completo.
                        If Val(WCompleto) <> 0 Then

                            '
                            ' Se checkea si ya se realizo el aviso a Federico Monti y
                            ' que no se encuentre cerrada ni entregada.
                            ' En caso de que no, se pregunta si se quiere enviar un aviso por email.
                            '
                            If Val(WMarcaAviso) = 0 And Val(WCerrada) <> 1 And UCase(WEntregado.trim) <> "X" Then

                                lblAvisoPackingList.Visible = True
                                _AvisarPorEmail(WProforma)

                            End If

                        End If

                    End If
                End With

            End Using

        Catch ex As Exception

            MsgBox("Hubo un problema al querer actualizar el Estado del Packing List de la Proforma '" & WProforma & "' en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _AvisarPorEmail(ByVal wProforma As String)

        If MsgBox("¿Desea avisar por Email que ya se encuentra disponible el PackingList de la Proforma '" & wProforma & "'", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim oApp As Outlook._Application
            Dim oMsg As Outlook._MailItem

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("")
            Dim trans As SqlTransaction = Nothing
            'DEVUELVE TRUE SI ES FARMA FALSE SINO ES FARMA
            Dim EsFarma As Boolean = VerificarFarma(wProforma)
            Try
                If wProforma.ToString.Length < 6 Then : Helper.ceros(wProforma, 6) : End If

                cn.ConnectionString = Helper._ConectarA
                cn.Open()
                trans = cn.BeginTransaction
                cm.Connection = cn
                cm.Transaction = trans

                cm.CommandText = "UPDATE ProformaExportacion SET AvisoPackingList = '1', PackingList = '1' WHERE Proforma = '" & wProforma & "'"
                cm.ExecuteNonQuery()

                oApp = New Outlook.Application()

                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                oMsg.Subject = "Notificación de Packing List Finalizado (Proforma Nº: " & wProforma & ")"
                oMsg.Body = vbCrLf & vbCrLf & vbCrLf & "Se encuentra FINALIZADA el Packing List correspondiente a la Proforma Nº: " & wProforma

                'WArchivoProforma = Helper._CarpetaArchivosProforma(wProforma) & "Proforma" & wProforma & ".pdf"

                'If Not File.Exists(WArchivoProforma) Then
                '    _ActualizarPDFProforma(wProforma)
                'End If

                'oMsg.Attachments.Add(WArchivoProforma)

                If EsFarma Then
                    ' Modificar por los E-Mails que correspondan.
                    oMsg.To = Configuration.ConfigurationManager.AppSettings("AVISO_PACKINGLIST_FARMA") '"gferreyra@surfactan.com.ar"
                    'oMsg.To = "nsoto@surfactan.com.ar"
                Else
                    ' Modificar por los E-Mails que correspondan.
                    oMsg.To = Configuration.ConfigurationManager.AppSettings("AVISO_PACKINGLIST") '"gferreyra@surfactan.com.ar"
                    'oMsg.To = "nsoto@surfactan.com.ar"
                End If


                'oMsg.Display()

                oMsg.Send()


                trans.Commit()

                If EsFarma Then
                    MsgBox("Aviso Enviado correctamente a Hernan Copiello, German Rodriguez y Beatriz Iglecias", MsgBoxStyle.Information)
                Else
                    MsgBox("Aviso Enviado correctamente a Hernan Copiello y Beatriz Iglecias", MsgBoxStyle.Information)
                End If


                lblAvisoPackingList.Visible = False


                Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtProforma.Text & "\" & "Packing List"

                Dim SQLCnslt As String = "SELECT Idioma FROM ProformaExportacion WHERE Proforma = '" & txtProforma.Text & "' AND (Renglon = '1' OR Renglon = '01')"

                Dim RowPro As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                Dim Idioma As Integer = 0
                If RowPro IsNot Nothing Then
                    Idioma = RowPro.Item("Idioma")
                End If

                'COMPROBAMOS QUE EXISTA LA CARPETA SINO LA CREAMOS

                If Not Directory.Exists(WRutaArchivosRelacionados) Then
                    Directory.CreateDirectory(WRutaArchivosRelacionados)
                End If

                'ELIMINO CUALQUIERA DE LOS DOS QUE ESTUVIERA GENERADO PARA QUE SOLO QUEDE UNO
                Dim WRutaArchivosRelacionadosI = WRutaArchivosRelacionados & "\" & "Nota de Empaque.pdf"
                Dim WRutaArchivosRelacionadosII = WRutaArchivosRelacionados & "\" & "Nota de Empaque Ingles.pdf"

                System.IO.File.Delete(WRutaArchivosRelacionadosI)
                System.IO.File.Delete(WRutaArchivosRelacionadosII)

                'CREAMOS UNA TABLA EN MEMORIA PARA MOSTRAR LOS DATOS
                Dim TablaNotaEmpaque As DataTable = New DBAuxi.TablaNotaEmpaqueDataTable

                'Para el Mostrarlo ne el reporte en el reporte
                Dim TotalPesoBruto As Double = 0

                CargaTablaParaNotaEmpaque(txtProforma.Text, TablaNotaEmpaque, TotalPesoBruto)

                Select Case Idioma

                    Case 0, 1


                        With New Util.VistaPrevia
                            .Reporte = New ReporteNotaEmpaque()
                            .Reporte.SetDataSource(TablaNotaEmpaque)
                            .Reporte.SetParameterValue(0, TotalPesoBruto)
                            '.Mostrar()
                            .Exportar("Nota de Empaque", ExportFormatType.PortableDocFormat, WRutaArchivosRelacionados)
                            '.GuardarPDF("Nota de Empaque Ingles", WRutaArchivosRelacionados)
                        End With

                    Case 2

                        With New Util.VistaPrevia
                            .Reporte = New ReporteNotaEmpaqueIngles()
                            .Reporte.SetDataSource(TablaNotaEmpaque)
                            .Reporte.SetParameterValue(0, TotalPesoBruto)
                            '.Mostrar()
                            .Exportar("Nota de Empaque Ingles", ExportFormatType.PortableDocFormat, WRutaArchivosRelacionados)
                            '.GuardarPDF("Nota de Empaque Ingles", WRutaArchivosRelacionados)
                        End With

                End Select

                GenerarRegistroEnHistorial()

            Catch ex As Exception
                If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

                Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

            End Try
        End If

    End Sub

    Private Function VerificarFarma(ByVal wProforma As String) As Boolean

        Dim EsFarma As Boolean = False
        Dim SQLCnslt As String = "SELECT Producto FROM ProformaExportacion WHERE Proforma = '" & wProforma & "'"
        Dim RowProf As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowProf IsNot Nothing Then
            SQLCnslt = "SELECT Linea FROM TERMINADO WHERE Codigo = '" & RowProf.Item("Producto") & "'"
            Dim RowLinea As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowLinea IsNot Nothing Then

                Dim Codprod As String = Mid(RowProf.Item("Producto"), 4, 5)
                If Val(Codprod) >= 25000 And Val(Codprod) <= 25999 Then
                    EsFarma = True
                End If
                Select Case RowLinea.Item("linea")
                    Case 10, 20, 22, 24, 25, 26, 27, 28, 29, 30
                        EsFarma = True
                End Select

                Return EsFarma
            End If
        End If

        MsgBox("Hubo un problema al querer verificar si es un producto FARMA")
        Return False

    End Function

    Private Sub CargaTablaParaNotaEmpaque(ByVal Proforma As String, ByRef TablaNotaEmpaque As DataTable, ByRef TotalPesoBruto As Double)

        Dim SQLCnslt As String = "SELECT Cliente, Localidad, Pais, Factura FROM ProformaExportacion WHERE Proforma = '" & Proforma & "' And (Renglon = '01' OR Renglon = '1')"

        Dim WLocalidad As String = ""
        Dim WPais As String = ""
        Dim WFactura As String = ""
        Dim WRazon As String = ""

        Try
            Dim RowProfExp As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowProfExp IsNot Nothing Then
                With RowProfExp
                    WRazon = ObtenerRazon(.Item("Cliente"))
                    WLocalidad = .Item("Localidad")
                    WPais = .Item("Pais")
                    WFactura = IIf(IsDBNull(.Item("Factura")), "", .Item("Factura"))
                    WFactura = Trim(WFactura).PadLeft(8, "0")
                End With

            End If
            'OBTENGO LA CANTIDAD DE PALLETES
            SQLCnslt = "SELECT NroPallets = MAX(Pallet) FROM ArmadoPallets WHERE Proforma = '" & Proforma & "'"
            Dim RowNroPallets As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            SQLCnslt = "SELECT Proforma, Pallet, CodigoPallet, CodigoEnvase, Bultos, KgBultos, Partida, Producto, TamanioBase, Altura FROM ArmadoPallets WHERE Proforma = '" & Proforma & "'"
            Dim TablaPro As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If TablaPro.Rows.Count > 0 Then
                Dim CantidadDePallets As Integer = RowNroPallets.Item("NroPallets")
                Dim PalletAnterior As Integer = 0
                For i = 1 To CantidadDePallets
                    For Each Row As DataRow In TablaPro.Rows
                        With Row
                            Dim PalletActual As Integer = .Item("Pallet")
                            If PalletActual = i Then

                                Dim WPallet As Integer = i
                                Dim WCodPallet As String = .Item("CodigoPallet")
                                Dim WDescripPallet As String = ObtenerDescPallet(WCodPallet)
                                Dim WTaraPallet As Double
                                'Para no volver a tener el peso de los pallet cuando es el mismo pallet
                                If PalletAnterior <> PalletActual Then
                                    WTaraPallet = ObtenerTara(WCodPallet)
                                Else
                                    WTaraPallet = 0
                                End If

                                PalletAnterior = PalletActual
                                Dim WCodigoBultos As String = .Item("CodigoEnvase")
                                Dim WDescripBultos As String = ObtenerDescPallet(WCodigoBultos)
                                Dim WTaraBultos As Double = ObtenerTara(WCodigoBultos)
                                Dim WBultos As Integer = .Item("Bultos")
                                Dim WKGBultos As Double = .Item("KgBultos")
                                Dim WPartida As Double = .Item("Partida")
                                Dim WProducto As String = .Item("Producto")
                                Dim WDescripProductoIngles As String = ObtenerDescpProductoIngles(WProducto)
                                Dim WDescripProducto As String = ObtenerDescpProducto(WProducto)
                                Dim WtamanioBase As String = IIf(IsDBNull(.Item("TamanioBase")), "", .Item("TamanioBase"))
                                Dim WDescripcionPackingListIngles As String = ObtenerDescripPackingListIngles(WCodigoBultos)
                                Dim WAltura As Double = .Item("Altura")
                                Dim WKgNeto As Double = (WKGBultos * WBultos)
                                'Dim WKgNeto As Double = (WKGBultos * WBultos) + (WTaraBultos * WBultos)
                                TablaNotaEmpaque.Rows.Add(Proforma, WPallet, WCodPallet, WDescripPallet, WTaraPallet,
                                                          WBultos, WCodigoBultos, WDescripBultos, WTaraBultos,
                                                          WKGBultos, WKgNeto, WLocalidad, WPais, WFactura, WRazon,
                                                          WProducto, WDescripProductoIngles, WDescripProducto,
                                                          WPartida, WDescripcionPackingListIngles, WtamanioBase, WAltura)
                                Dim pesolinea As Double = (WBultos * (WKGBultos + WTaraBultos)) + WTaraPallet
                                TotalPesoBruto += pesolinea
                                'MsgBox(pesolinea)
                            End If
                        End With
                    Next
                Next

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Function ObtenerDescripPackingListIngles(ByVal Codigo As String) As String
        Dim SQLCnslt As String = "SELECT DescPackingListIngles FROM Articulo WHERE Codigo = '" & Codigo & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Dim DescPackingListIngles As String = IIf(IsDBNull(Row.Item("DescPackingListIngles")), "", Row.Item("DescPackingListIngles"))
            Return DescPackingListIngles
        End If
        Return ""
    End Function
    Private Function ObtenerDescpProducto(ByVal Codigo As String) As String
        Dim SQLCnslt As String = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & Codigo & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Return Trim(Row.Item("Descripcion"))
        End If
        Return ""
    End Function

    Private Function ObtenerDescpProductoIngles(ByVal Codigo As String) As String
        Dim SQLCnslt As String = "SELECT DescripcionIngles FROM Terminado WHERE Codigo = '" & Codigo & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Return Trim(Row.Item("DescripcionIngles"))
        End If
        Return ""
    End Function

    Private Function ObtenerTara(ByVal Codigo As String) As String
        Dim SQLCnslt As String = "SELECT Tara FROM Articulo WHERE Codigo = '" & Codigo & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Return Trim(Row.Item("Tara"))
        End If
        Return ""
    End Function
    Private Function ObtenerDescPallet(ByVal Codigo As String) As String
        Dim SQLCnslt As String = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Codigo & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Return Trim(Row.Item("Descripcion"))
        End If
        Return ""
    End Function

    Private Function ObtenerRazon(ByVal Cliente As String) As String
        Dim SQLCnslt As String = "SELECT Razon FROM Cliente WHERE Cliente = '" & Cliente & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            Return Trim(Row.Item("Razon"))
        End If
        Return ""
    End Function
    Private Sub _AvisarReaperturaPorEmail()



        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem

        Try


            oApp = New Outlook.Application()

            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = "Notificación de reapertura de la Proforma (Pedido Nº: " & Trim(txtProforma.Text) & ")"
            oMsg.Body = vbCrLf & vbCrLf & vbCrLf & "" & Trim(Operador.Descripcion) & " acaba de re abrir el Packing List " _
                         & vbCrLf & "Para la proforma Nro : " & Trim(txtProforma.Text) & ""


            ' Modificar por los E-Mails que correspondan.
            oMsg.To = Configuration.ConfigurationManager.AppSettings("AVISO_PACKINGLIST") '"soporte@surfactan.com.ar"
            'oMsg.To = "nsoto@surfactan.com.ar"

            'oMsg.Display()


            oMsg.Send()


            ' trans.Commit()

            MsgBox("Aviso Enviado correctamente", MsgBoxStyle.Information)


        Catch ex As Exception
            'If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        End Try


    End Sub

    Private Sub GenerarRegistroEnHistorial(Optional ByVal Reapertura As Boolean = False)

        Try
            Dim WNro_Observacion As String = _ProximoNroObservacion()
            Dim WRenglon As String = "01"
            Dim WClave As String = WNro_Observacion.PadRight(6, "0") & WRenglon
            Dim WProforma As String = Trim(txtProforma.Text)
            Dim WObservaciones As String = "Se genero la Nota de Envases por " & Trim(Operador.Descripcion)
            Dim WUsuario As String = Operador.Descripcion
            Dim WFecha As String = Date.Today.ToString("dd/MM/yyyy")
            Dim WFechaOrd As String = ordenaFecha(WFecha)

            Dim SQLCnslt As String = ""
            If Reapertura = False Then
                SQLCnslt = "INSERT INTO ProformaExportacionHistorial (Clave, NroObservacion, Renglon, Proforma, Usuario, Fecha, FechaOrd, Observaciones) " _
                                      & "VALUES ('" & WClave & "'," & WNro_Observacion & ",'" & WRenglon & "','" & WProforma & "','" & WUsuario & "','" & WFecha & "','" & WFechaOrd & "','" & WObservaciones & "')"
            Else

                WObservaciones = "Reapertura del Packing list por " & Trim(Operador.Descripcion)

                SQLCnslt = "INSERT INTO ProformaExportacionHistorial (Clave, NroObservacion, Renglon, Proforma, Usuario, Fecha, FechaOrd, Observaciones) " _
                                      & "VALUES ('" & WClave & "'," & WNro_Observacion & ",'" & WRenglon & "','" & WProforma & "','" & WUsuario & "','" & WFecha & "','" & WFechaOrd & "','" & WObservaciones & "')"


            End If

            ExecuteNonQueries("SurfactanSa", SQLCnslt)

        Catch ex As Exception
            MsgBox("Hubo un error al generar el registro de historial para la proforma " & Trim(txtProforma.Text) & "")
        End Try





    End Sub

    Private Function _ProximoNroObservacion()

        Dim actual = 0
        Dim SQLCnslt As String = "SELECT TOP 1 NroObservacion as NroActual FROM ProformaExportacionHistorial ORDER BY NroObservacion DESC"
        Try
            Dim RowObservacion As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowObservacion IsNot Nothing Then
                actual = RowObservacion.Item("NroActual")

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el próximo número de Observación de la Base de Datos.")

        End Try

        Return actual + 1

    End Function



    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Pallets_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub btnAgregarPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPallet.Click

        Dim frm As New IngresoPallet(txtProforma.Text, txtPedido.Text, -1)
        frm.Show(Me)

    End Sub

    Private Sub dgvPallets_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPallets.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WNroPallet = If(dgvPallets.CurrentRow.Cells("Nro").Value, "")

        Dim frm As IngresoPallet = New IngresoPallet(txtProforma.Text, txtPedido.Text, WNroPallet, Grabar)
        frm.ShowDialog(Me)

        _CargarInformacionPallets()

    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        btn.Enabled = False
        btn.Cursor = Cursors.No

        Cursor = Cursors.WaitCursor

        Dim SQLCnslt As String = "SELECT Idioma FROM ProformaExportacion WHERE Proforma = '" & txtProforma.Text & "' AND (Renglon = '1' OR Renglon = '01')"

        Dim RowPro As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        Dim Idioma As Integer = 0
        If RowPro IsNot Nothing Then
            Idioma = RowPro.Item("Idioma")
        End If

        'CREAMOS UNA TABLA EN MEMORIA PARA MOSTRAR LOS DATOS
        Dim TablaNotaEmpaque As DataTable = New DBAuxi.TablaNotaEmpaqueDataTable

        'Para el Mostrarlo ne el reporte en el reporte
        Dim TotalPesoBruto As Double = 0

        CargaTablaParaNotaEmpaque(txtProforma.Text, TablaNotaEmpaque, TotalPesoBruto)

        Select Case Idioma

            Case 0, 1

                With New Util.VistaPrevia
                    .Reporte = New ReporteNotaEmpaque()
                    .Reporte.SetDataSource(TablaNotaEmpaque)
                    .Reporte.SetParameterValue(0, TotalPesoBruto)
                    .Mostrar()
                End With
            Case 2
                With New Util.VistaPrevia
                    .Reporte = New ReporteNotaEmpaqueIngles()
                    .Reporte.SetDataSource(TablaNotaEmpaque)
                    .Reporte.SetParameterValue(0, TotalPesoBruto)
                    .Mostrar()
                End With

        End Select

        Cursor = Cursors.Default
        btn.Enabled = True
        btn.Cursor = Cursors.Hand
    End Sub

    Private Sub btnInfoProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoProforma.Click

        If txtProforma.Text.Trim <> "" Then

            Proforma.Dispose()
            Dim frm As New Proforma()
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.txtNroProforma.Text = txtProforma.Text
            frm.txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            frm.Show(ListadoProformas)

        End If
    End Sub

    Private Sub lblAviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAviso.Click
        btnInfoProforma_Click(Nothing, Nothing)
    End Sub

    Private Sub lblAvisoPackingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAvisoPackingList.Click
        _ActualizarMarcaProforma(txtProforma.Text, "1")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_AdjuntarArchivos.Click
        If Trim(txtProforma.Text) <> "" Then

            With ArchivosProforma

                .NroProforma = txtProforma.Text

                .Show()

            End With

        End If
    End Sub

    Private Sub btn_ReAbrirPackinglist_Click(sender As Object, e As EventArgs) Handles btn_ReAbrirPackinglist.Click
        If MsgBox("¿Desea re abrir el Packing List? Se generara una registro de re apertura y se informara a Beatriz Iglesias y Hernan Copiello.", vbYesNo) = vbNo Then
            Exit Sub
        End If
        Try
            Dim SQLCnlst As String = "UPDATE ProformaExportacion SET AvisoPackingList = '0', PackingList = '0' WHERE Proforma = '" & Trim(txtProforma.Text) & "'"
            ExecuteNonQueries("SurfactanSa", SQLCnlst)

            Grabar = True
            btnAgregarPallet.Enabled = True

            _AvisarReaperturaPorEmail()

            GenerarRegistroEnHistorial(True)

            Dim WRutaArchivosRelacionadosI = _RutaCarpetaArchivos() & "\" & txtProforma.Text & "\" & "Packing List" & "\" & "Nota de Empaque.pdf"
            Dim WRutaArchivosRelacionadosII = _RutaCarpetaArchivos() & "\" & txtProforma.Text & "\" & "Packing List" & "\" & "Nota de Empaque Ingles.pdf"

            Try
                System.IO.File.Delete(WRutaArchivosRelacionadosI)
                System.IO.File.Delete(WRutaArchivosRelacionadosII)
            Catch ex As Exception

            End Try




        Catch ex As Exception
            MsgBox("Error al re abrir la Proforma", vbExclamation)
        End Try


    End Sub
End Class