﻿Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports Util
Imports Util.Clases

Public Class AutorizarPedido
    Private Pedido As String
    Dim PermitirGrabar As Boolean
    Private ZRowReventa As DataGridViewRow = Nothing

    Sub New(ByVal Pedido As String, ByVal PermitirGra As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Pedido = Pedido
        PermitirGrabar = PermitirGra
    End Sub

    Private Sub AutorizarPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each lbl As Label In GroupBox1.Controls.OfType(Of Label).Where(Function(c) _Left(c.Name, 3) = "lbl")
            lbl.BackColor = Globales.WBackColorTerciario
            lbl.Text = ""
        Next

        btnAutorizar.Enabled = PermitirGrabar

        lblPedido.Text = Pedido
        _CargarDatos()

    End Sub

    Private Sub _CargarDatos()

        dgvDatos.Rows.Clear()

        Dim WCamposLotes As String = ""

        For i = 1 To 12
            WCamposLotes &= "p.Lote" & i & ", p.CantiLote" & i & ","
        Next

        WCamposLotes = WCamposLotes.TrimEnd(",")

        Dim WDatos As DataTable = GetAll("SELECT p.Pedido, Producto = p.Terminado, t.Descripcion, Cantidad = (p.Cantidad - p.Facturado), AEntregar = p.Cantidad1, p.Renglon, p.Cliente, c.Razon, p.Fecha, p.FecEntrega, Tipo = CASE p.TipoPed WHEN 0 THEN 'NORMAL' WHEN 1 THEN 'A FECHA' WHEN 2 THEN 'FECHA LIMITE' WHEN 3 THEN 'URGENTE' WHEN 4 THEN 'RETIRA CLIENTE' WHEN 5 THEN 'MUESTRA' ELSE '' END, " & WCamposLotes & ", Partidas = CASE WHEN ISNULL(Lote1, 0) <> 0 And ISNULL(Lote2, 0) <> 0 THEN -1 ELSE Lote1 END from Pedido p INNER JOIN Cliente c ON c.Cliente = p.Cliente INNER JOIN Terminado t ON t.Codigo = p.Terminado where p.Pedido = '" & Pedido & "' ORDER BY p.Renglon", "SurfactanSa")

        For Each row As DataRow In WDatos.Rows
            With row
                If .Item("Renglon") = 1 Then
                    lblCliente.Text = Trim(OrDefault(.Item("Cliente"), ""))
                    lblFecha.Text = Trim(OrDefault(.Item("Fecha"), "00/00/0000"))
                    lblFecEntrega.Text = Trim(OrDefault(.Item("FecEntrega"), "00/00/0000"))
                    lblDescCliente.Text = Trim(OrDefault(.Item("Razon"), ""))
                    lblTipoPedido.Text = Trim(OrDefault(.Item("Tipo"), ""))
                End If

                Dim WProducto, WDescripcion, WCantidad, WEntrega, WPartida As String

                WProducto = OrDefault(row.Item("Producto"), "")
                WDescripcion = OrDefault(row.Item("Descripcion"), "")
                WCantidad = formatonumerico(OrDefault(row.Item("Cantidad"), "0"))
                WEntrega = formatonumerico(OrDefault(row.Item("AEntregar"), "0"))
                WPartida = OrDefault(row.Item("Partidas"), "0")

                '
                ' Si tiene mas de un lote cargado, dejo el primer renglon del producto sin lotes ni partidas ni boton de CoA.
                ' Voy desglosando luego una fila por lote.
                '
                If Val(OrDefault(.Item("Lote1"), "")) <> 0 And Val(OrDefault(.Item("Lote2"), "")) <> 0 Then

                    With dgvDatos.Rows(dgvDatos.Rows.Add)
                        .Cells("Producto").Value = WProducto
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = WCantidad
                        .Cells("Entregar").Value = WEntrega
                        .Cells("Partida").Value = IIf(Val(WPartida) = -1, "VARIOS", WPartida)
                        .Cells("Canti").Value = ""
                        .Cells("CoA").Value = ""
                        .Cells("PathCoa").Value = ""
                    End With

                    For x = 1 To 12

                        WPartida = OrDefault(.Item("Lote" & x), "")

                        If Val(WPartida) <> 0 Then
                            Dim r = dgvDatos.Rows.Add

                            WProducto = ""
                            WDescripcion = ""
                            WCantidad = ""
                            WEntrega = OrDefault(row.Item("CantiLote" & x), "0")

                            If Val(WEntrega) = 0 Then Continue For

                            With dgvDatos.Rows(r)
                                .Cells("Producto").Value = WProducto
                                .Cells("Descripcion").Value = WDescripcion
                                .Cells("Cantidad").Value = "" 'formatonumerico(WCantidad)
                                .Cells("Canti").Value = formatonumerico(WEntrega)
                                .Cells("Partida").Value = WPartida

                                Dim WVenc() As String = _DeterminarVencimientos(WPartida)

                                .Cells("Venc75").Value = WVenc(0)
                                .Cells("Revalida").Value = WVenc(1)
                                .DefaultCellStyle.BackColor = Globales.WBackColorCuaternario

                                .Cells("CoA").Value = "Generar"
                                .Cells("PathCoa").Value = ""

                            End With

                            Dim path As String = _PathArchivoCoa(dgvDatos.Rows(r))

                            If path <> "" Then

                                If path.EndsWith(".pdf") Then
                                    If File.Exists(path) Then
                                        With dgvDatos.Rows(r)
                                            .Cells("CoA").Value = "Ver"
                                            .Cells("PathCoa").Value = path
                                        End With
                                    End If
                                End If

                            End If
                        End If
                    Next
                Else
                    Dim i = dgvDatos.Rows.Add
                    With dgvDatos.Rows(i)
                        .Cells("Producto").Value = WProducto
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = WCantidad
                        .Cells("Entregar").Value = WEntrega
                        .Cells("Partida").Value = WPartida
                        .Cells("Canti").Value = WEntrega

                        Dim WVenc() As String = _DeterminarVencimientos(OrDefault(row.Item("Lote1"), ""))

                        .Cells("Venc75").Value = WVenc(0)
                        .Cells("Revalida").Value = WVenc(1)

                        .Cells("CoA").Value = "Generar"
                        .Cells("PathCoa").Value = ""

                    End With

                    Dim path As String = _PathArchivoCoa(dgvDatos.Rows(i))

                    If path <> "" Then

                        If path.EndsWith(".pdf") Then
                            If File.Exists(path) Then
                                With dgvDatos.Rows(i)
                                    .Cells("CoA").Value = "Ver"
                                    .Cells("PathCoa").Value = path
                                End With
                            End If
                        End If

                    End If

                End If

            End With

        Next
    End Sub

    Private Function _DeterminarVencimientos(ByVal Partida As String) As String()
        Dim WVenc() As String = {"", ""}

        Dim WFecha, WMeses, WRevalida, WMesesRevalida, WFechaRevalida As String
        Dim WVida, WMes, WAnio As Short

        Dim WHoja As DataRow = GetSingle("SELECT h.Fecha, h.FechaRevalida, h.MesesRevalida, h.Revalida, Meses = t.Vida FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Producto WHERE h.Hoja = '" & Partida & "' AND Renglon = 1")

        If WHoja IsNot Nothing Then
            With WHoja
                WFecha = OrDefault(.Item("Fecha"), "")
                WFechaRevalida = OrDefault(.Item("FechaRevalida"), "")
                WMesesRevalida = OrDefault(.Item("MesesRevalida"), "")
                WRevalida = OrDefault(.Item("Revalida"), "")
                WMeses = OrDefault(.Item("Meses"), "")

                '
                ' Verificamos el 75%.
                '
                If Val(WRevalida) <> 0 Then
                    WVida = Val(WMesesRevalida) * 0.75
                    WMes = Val(Mid(WFechaRevalida, 4, 2))
                    WAnio = Val(_Right(WFechaRevalida, 4))

                    WVenc(1) = "S"

                Else
                    WVida = Val(WMeses) * 0.75
                    WMes = Val(Mid(WFecha, 4, 2))
                    WAnio = Val(_Right(WFecha, 4))
                End If

                For CicloVida = 1 To WVida
                    WMes = WMes + 1
                    If WMes > 12 Then
                        WAnio = WAnio + 1
                        WMes = 1
                    End If
                Next CicloVida

                Dim Auxi As String = WAnio.ToString.PadLeft(4, "0") & WMes.ToString.PadLeft(2, "0") & "01"

                If Val(Auxi) < Val(Date.Now.ToString("yyyyMMdd")) Then
                    WVenc(0) = "S"
                End If

            End With

        End If

        Return WVenc

    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If MsgBox("¿Se encuentra seguro de querér autorizar el actual Pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteNonQueries("SurfactanSa", {"UPDATE Pedido SET MarcaFactura = '1' WHERE Pedido = '" & Pedido & "'"})

            '
            ' Enviamos el mail correspondiente a los involucrados en Farma y al Cliente.
            '
            _EnviarAvisoPedidoAutorizado(Pedido)

            Close()
        End If
    End Sub

    Private Sub _EnviarAvisoPedidoAutorizado(ByVal WNroPedido As String)
        '
        'TODO: Filtrar por otra cosa que no sa ]MarcaFactura = 1
        '
        Dim WPed As DataTable = GetAll("SELECT c.Razon, c.Provincia, c.EmailFactura, t.Descripcion, p.* FROM Pedido p INNER JOIN Cliente c ON c.Cliente = p.Cliente INNER JOIN Terminado t ON t.Codigo = p.Terminado WHERE p.Pedido = '" & WNroPedido & "' And p.MarcaFactura = '1' And ISNULL(p.Facturado, 0) < ISNULL(p.Cantidad, 0) ORDER BY p.Renglon", "SurfactanSa")
        Dim WDir As String() = {"grodriguez", "hsein", "calidad3", "calidad2", "calidad", "ebiglieri", "isocalidad", "hmuller", "scoppiello", "sup3", "planta7"}
        Dim WDirecciones As String = ""

        If WPed.Rows.Count = 0 Then Exit Sub

        Dim WEnIngles As Boolean = Val(OrDefault(WPed.Rows(0)("Provincia"), "")) = 24
        Dim WDescCliente As String = Trim(UCase((OrDefault(WPed.Rows(0)("Razon"), ""))))
        Dim WEmailFactura As String = Trim(UCase((OrDefault(WPed.Rows(0)("EmailFactura"), ""))))

        WDir.ToList().ForEach(Sub(d) WDirecciones &= d & "@surfactan.com.ar;")

        If WDirecciones = "" Then Exit Sub

        Dim WAsunto As String = "El Pedido " & WNroPedido & " de " & WDescCliente & ", ha sido autorizado."
        Dim WCuerpo As String = "Se notifica que el pedido " & WNroPedido & ", se encuentra autorizado por Aseg. de la Calidad." & vbCrLf & vbCrLf & "Se adjuntan los FDS y Certificados correspondientes a los Productos y Partidas involucradas."

        Dim WArchivos As New List(Of String)

        For Each r As DataRow In WPed.Rows

            Dim esProductoReventa As Boolean = _EsProductoReventa(r("Terminado"))
            Dim WRutaCertificado As String = ""
            Dim WNombrePdf As String = ""

            '
            ' Determino el tipo de Producto.
            '
            If esProductoReventa Then
                WRutaCertificado = "\\193.168.0.2\w\impresion pdf\Certificados Analisis Farma Reventa\"
            Else
                WRutaCertificado = "\\193.168.0.2\w\impresion pdf\Certificados Analisis Farma Liberacion Pedidos\" & WNroPedido & "\"
            End If

            For i = 1 To 12

                Dim WPartida As String = OrDefault(r("Lote" & i), "")
                Dim WCantidad As String = formatonumerico(OrDefault(r("CantiLote" & i), "0"))

                If Val(WPartida) = 0 Or Val(WCantidad) = 0 Then Continue For

                If esProductoReventa Then
                    WNombrePdf = "*" & "P" & WPartida & "* LP*.pdf"
                Else
                    WNombrePdf = "*" & "Pda " & WPartida & "*.pdf"
                End If

                If Directory.Exists(WRutaCertificado) Then

                    Dim wcer As String() = Directory.GetFiles(WRutaCertificado, WNombrePdf, SearchOption.TopDirectoryOnly)

                    If wcer.Count = 0 Then
                        If esProductoReventa Then

                            WNombrePdf = "*" & WPartida & ".pdf"
                            wcer = Directory.GetFiles(WRutaCertificado, WNombrePdf, SearchOption.TopDirectoryOnly)

                        Else

                            wcer = Directory.GetFiles("\\193.168.0.2\w\impresion pdf\Certificados Analisis Farma Liberacion Pedidos\" & WNroPedido & "\" & WPartida & "\", WNombrePdf, SearchOption.TopDirectoryOnly)

                        End If

                    End If

                    WArchivos.AddRange(wcer)

                    If wcer.Count = 0 Then
                        MsgBox("No se encontró el CoA correspondiente a la partida " & WPartida, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                Else
                    MsgBox("No se encontró el CoA correspondiente a la partida " & WPartida, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                '
                ' Agregamos los adicionales que pidiesen haber (Ej: Informes de Particulas, Informes de Ionics, etc).
                '
                Dim WBuscarAdicionales As String = "\\193.168.0.2\w\impresion pdf\Documentacion Adicional Pedidos\" & WPartida & "\"

                If Directory.Exists(WBuscarAdicionales) Then

                    Dim WAdicionales As String() = Directory.GetFiles(WBuscarAdicionales, "*", SearchOption.TopDirectoryOnly)

                    WArchivos.AddRange(WAdicionales)

                End If

            Next

            '
            ' Buscamos el FDS del Producto.
            '
            Dim WTer As String = r("Terminado")
            WTer = Microsoft.VisualBasic.Right(WTer.Replace(" ", "").Replace("/", "").Replace("-", "").PadLeft(8, "0"), 8)
            Dim WBuscarEn As String = "\\193.168.0.2\w\impresion pdf\FDS\"

            Dim WFDSs As String() = Directory.GetFiles(WBuscarEn, String.Format("FDS*{0}*.pdf", WTer), SearchOption.TopDirectoryOnly)

            Dim arch As String = ""

            For Each wfdS As String In WFDSs

                wfdS = UCase(wfdS)

                If WEnIngles Then
                    If wfdS.Contains("-ING") Or wfdS.Contains(" ING") Then
                        arch = wfdS
                        Exit For
                    End If
                Else
                    If Not wfdS.Contains("-ING") And Not wfdS.Contains(" ING") Then
                        arch = wfdS
                        Exit For
                    End If
                End If

                If arch.Trim = "" Then arch = wfdS

            Next

            If arch.Trim <> "" Then WArchivos.Add(arch)

        Next

        '
        ' Consultamos si quiere enviar aviso al Cliente. Por ahora, únicamente se muestra por pantalla.
        '
        If WEmailFactura <> "" Then

            If MsgBox("¿Enviar aviso con documentación adjunta al Cliente? " & vbCrLf & vbCrLf & "La misma se enviará a la casilla: ( " & WEmailFactura & ") ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                MsgBox("Por encontrarnos en un periodo de prueba, la casilla que figurará en el mail será 'gferreyra@surfactan.com.ar'", MsgBoxStyle.Information)

                WDirecciones = WEmailFactura
                WAsunto = "Pedido #" & WNroPedido & " - Documentación - SURFACTAN S.A."

                WCuerpo = "Estimado Cliente." & vbCrLf & "Le enviamos los Certificados de Análisis y Fichas de Seguridad correspondiente al pedido que estarán recibiendo en breve." & vbCrLf & vbCrLf & "<strong>Saludos cordiales.</strong>" & vbCrLf & "<strong>Aseguramiento de Calidad</strong>" & vbCrLf & "<strong>Surfactan S.A.</strong>"

                '_EnviarMail(WEmailFactura, WAsunto, WCuerpo, String.Join(";", WArchivos.ToArray()), False, CCO:=WDirecciones)
                _EnviarMail("gferreyra@surfactan.com.ar", WAsunto, WCuerpo, String.Join(";", WArchivos.ToArray()), False, CCO:=WDirecciones)

            End If
        Else
            MsgBox("El Cliente no tiene cargado una casilla de correo para enviar la documentación pertinente.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub _EnviarMail(wDestinatarios As String, wAsunto As String, wCuerpo As String, wAdjuntos As String, Optional ByVal EnvioAutomatico As Boolean = True, Optional ByVal CCO As String = "")
        Dim oApp As _Application
        Dim oMsg As _MailItem

        Try
            oApp = New Application()

            oMsg = oApp.CreateItem(OlItemType.olMailItem)

            Dim el = oMsg.GetInspector

            oMsg.HTMLBody = "<p>" & wCuerpo.Replace(vbCrLf, "<br/>") & "<p>" & oMsg.HTMLBody

            oMsg.Subject = wAsunto
            'oMsg.Body = wCuerpo

            ' Modificar por los E-Mails que correspondan.
            oMsg.To = wDestinatarios
            oMsg.BCC = CCO

            If wAdjuntos.Split(";").Count > 0 Then

                For Each archivosAdjunto As String In wAdjuntos.Split(";")

                    If archivosAdjunto.Trim <> "" Then oMsg.Attachments.Add(archivosAdjunto)

                Next

            End If

            If EnvioAutomatico Then
                oMsg.Send()
            Else
                oMsg.Display()
            End If

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.ColumnIndex = dgvDatos.Columns("Partida").Index Then
            Dim WPartida As String = OrDefault(dgvDatos.CurrentCell.Value, "")

            If Val(WPartida) = 0 Then Exit Sub

            With New DetallesHojaProduccion(WPartida)
                .ShowDialog(Me)
            End With

        End If
    End Sub

    Private Sub dgvDatos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseClick
        If e.ColumnIndex <> dgvDatos.Columns("CoA").Index Then Exit Sub

        '
        ' Esto evita errores cuando el click del mouse cuelga y termina soltando el click en otra celda, arrastrando la seleccion a varias celdas.
        '

        For Each c As DataGridViewCell In dgvDatos.SelectedCells
            dgvDatos.Rows(c.RowIndex).Selected = True
        Next

        If dgvDatos.SelectedRows.Count < 1 Then Exit Sub

        Dim row As DataGridViewRow = dgvDatos.SelectedRows(0)

        dgvDatos.ClearSelection()

        Dim tipo As String = UCase(row.Cells("CoA").Value)

        Select Case tipo
            Case "GENERAR"

                '
                ' En caso de ser producto de Reventa, solamente se copia el archivo correspondiente.
                '
                If _EsProductoReventa(row) Then
                    Dim path As String = _PathArchivoCoa(row)

                    If path <> "" Then

                        If Not path.EndsWith(".pdf") Then

                            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)

                        End If

                        Process.Start(path)

                        MsgBox("Presione ACEPTAR cuando haya cargado el CoA correspondiente.", MsgBoxStyle.Information)

                        _CargarDatos()

                    End If

                    'MsgBox("Es producto de reventa!")
                Else
                    Dim path As String = _GenerarCoA(row)

                    If path.Trim <> "" AndAlso System.IO.File.Exists(path) Then
                        With row
                            .Cells("CoA").Value = "Ver"
                            .Cells("PathCoA").Value = path
                        End With

                        Process.Start(path)

                    End If
                End If

            Case "VER"

                With row
                    .Cells("CoA").Value = "Ver"
                    Dim path As String = OrDefault(.Cells("PathCoA").Value, "")

                    If path.Trim <> "" AndAlso System.IO.File.Exists(path) Then
                        Process.Start(path)
                    End If

                End With

        End Select

    End Sub

    Private Function _EsProductoReventa(ByVal row As DataGridViewRow) As Boolean

        Dim WProd As String = _DeterminarProducto(row)

        Return _EsProductoReventa(WProd)

    End Function

    Private Function _PathArchivoCoa(ByVal row As DataGridViewRow) As String

        '
        ' Busco el producto al que corresponde la partida.
        '
        Dim WProducto As String = _DeterminarProducto(row)

        Dim WPartida As String = UCase(OrDefault(row.Cells("Partida").Value, ""))

        '
        ' Esto no deberia pasar, pero en caso de no encontrar absolutamente nada, nos vamos a cara de perro.
        '
        If WProducto.Trim = "" OrElse WProducto.Replace(" ", "").Length < 12 Then Return ""

        Dim WPed As DataRow = GetSingle("SELECT Cliente FROM Pedido WHERE Pedido = '" & Pedido & "'", "SurfactanSa")

        If WPed Is Nothing Then Return ""

        Dim WCliente As String = OrDefault(WPed("Cliente"), "")

        If _EsProductoReventa(WProducto) Then
            '
            ' Verifica si existe el archivo con el primer formato.
            '
            Dim WNombrePDF As String = String.Format("{0} P{1}* *LP*.pdf", WProducto, WPartida)
            Dim WRuta As String = OrDefault(Configuration.ConfigurationManager.AppSettings("PATH_COAS_FARMA_REVENTA"), "") & "\"

            Dim path As String = String.Format("{0}\{1}", WRuta, WNombrePDF)

            If Not IO.File.Exists(path) Then

                WNombrePDF = String.Format("{0} {1}.pdf", WProducto, WPartida)

                path = String.Format("{0}\{1}", WRuta, WNombrePDF)

                If Not IO.File.Exists(path) Then
                    path = String.Format("{0}", WRuta)
                End If

            End If

            Return path

        Else

            Dim WNombrePDF As String = String.Format("Certificado {0} {1} Pda {2}.pdf", Pedido, WCliente, WPartida)
            Dim WRuta As String = Pedido & "\"

            Return String.Format("{0}\{1}\{2}", OrDefault(Configuration.ConfigurationManager.AppSettings("PATH_COAS_FARMA"), ""), WRuta.Replace(Chr(34), ""), WNombrePDF)

        End If

    End Function

    Private Function _EsProductoReventa(ByVal Prod As String) As Boolean

        Dim WProd As DataRow = GetSingle("SELECT Tipo FROM codigomono WHERE Codigo = " + "'" & Prod & "'", "SurfactanSa")

        If WProd IsNot Nothing Then
            Return Val(OrDefault(WProd("Tipo"), "")) = 0
        End If

        Return False

    End Function

    Private Function _GenerarCoA(row As DataGridViewRow) As String

        '
        ' Busco el producto al que corresponde la partida.
        '
        Dim WProducto As String = _DeterminarProducto(row)

        Dim WPartida As String = UCase(OrDefault(row.Cells("Partida").Value, ""))
        Dim WCanti As String = formatonumerico(OrDefault(row.Cells("Canti").Value, ""))

        '
        ' Esto no deberia pasar, pero en caso de no encontrar absolutamente nada, nos vamos a cara de perro.
        '
        If WProducto.Trim = "" OrElse WProducto.Replace(" ", "").Length < 12 Then Return ""

        Dim WPed As DataRow = GetSingle("SELECT Cliente FROM Pedido WHERE Pedido = '" & Pedido & "'", "SurfactanSa")

        If WPed Is Nothing Then Return ""

        Dim WCliente As String = OrDefault(WPed("Cliente"), "")

        Dim WNombrePDF As String = String.Format("Certificado {0} {1} Pda {2}.pdf", Pedido, WCliente, WPartida)
        Dim WRuta As String = Pedido & "\"

        With New EmisionCertificadoAnalisis
            .WindowState = FormWindowState.Minimized
            .Show()
            .txtCantidad.Text = WCanti
            .txtCliente.Text = WCliente
            .txtPartida.Text = WPartida
            .lblTerminado.Text = WProducto
            .cmbTipoSalida.SelectedIndex = 3
            ._EmitirCertificado(True, WNombrePDF, WRuta)
            .Close()
        End With

        Return String.Format("{0}\{1}\{2}", OrDefault(Configuration.ConfigurationManager.AppSettings("PATH_COAS_FARMA"), ""), WRuta.Replace(Chr(34), ""), WNombrePDF)

    End Function

    Private Function _DeterminarProducto(row As DataGridViewRow) As String

        Dim WProducto As String = UCase(OrDefault(row.Cells("Producto").Value, ""))

        '
        ' En caso de estar en blanco, busco el proximo en la fila superior.
        '
        If WProducto.Trim = "" Then
            For i As Integer = row.Index To 0 Step -1
                Dim prod As String = OrDefault(dgvDatos.Rows(i).Cells("Producto").Value, "").ToString.Trim

                If prod <> "" Then
                    WProducto = prod
                    Exit For
                End If
            Next
        End If

        Return WProducto

    End Function
End Class