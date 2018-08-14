Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class Pallets

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
        Dim cm As SqlCommand = New SqlCommand("SELECT ap.Pallet Nro, ap.CodigoPallet Pallet, a.Descripcion, SUM(ap.Bultos) Bultos, (SUM(ap.KgBultos * ap.Bultos) + ISNULL(a.Tara, 0)) KgBrutos, (sum(ap.KgBultos * ap.Bultos)) KgNetos, ap.FechaDisponible As Disponible FROM ArmadoPallets ap LEFT JOIN Articulo a ON a.Codigo = ap.CodigoPallet WHERE ap.Proforma = '" & txtProforma.Text & "' GROUP BY ap.Pallet, ap.CodigoPallet, a.Tara, a.Descripcion, ap.FechaDisponible")
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

        If MsgBox("¿Desea avisar por Email que ya se encuentra disponible el PackingList de la Proforma '" & wProforma & "' a Federico Monti (fgmonti@surfactan.com.ar)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim oApp As Outlook._Application
            Dim oMsg As Outlook._MailItem

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("")
            Dim trans As SqlTransaction = Nothing

            Try
                If wProforma.ToString.Length < 6 Then : Helper.ceros(wProforma, 6) : End If

                cn.ConnectionString = Helper._ConectarA
                cn.Open()
                trans = cn.BeginTransaction
                cm.Connection = cn
                cm.Transaction = trans

                cm.CommandText = "UPDATE ProformaExportacion SET AvisoPackingList = '1' WHERE Proforma = '" & wProforma & "'"
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

                ' Modificar por los E-Mails que correspondan.
                oMsg.To = Configuration.ConfigurationManager.AppSettings("AVISO_PACKINGLIST") '"gferreyra@surfactan.com.ar"
                'oMsg.To = "nsoto@surfactan.com.ar"

                'oMsg.Display()
                oMsg.Send()

                trans.Commit()

                MsgBox("Aviso Enviado correctamente a <Federico García Monti> fgmonti@surfactan.com.ar", MsgBoxStyle.Information)

                lblAvisoPackingList.Visible = False

            Catch ex As Exception
                If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

                Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

            End Try
        End If

    End Sub

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

        Dim frm As IngresoPallet = New IngresoPallet(txtProforma.Text, txtPedido.Text, WNroPallet)
        frm.ShowDialog(Me)

        _CargarInformacionPallets()

    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        btn.Enabled = False
        btn.Cursor = Cursors.No

        Cursor = Cursors.WaitCursor
        Dim frm As New VistaPrevia()
        frm.Reporte = New NotaEmpaque
        frm.Formula = "{ArmadoPallets.Proforma} = '" & txtProforma.Text & "' AND {ArmadoPallets.Proforma} = {ProformaExportacion.Proforma} AND {ProformaExportacion.Renglon} = '01'"
        frm.Mostrar()


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
End Class