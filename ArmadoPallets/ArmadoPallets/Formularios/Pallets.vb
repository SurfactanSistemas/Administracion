Imports System.Data.SqlClient
Imports System.IO

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

    Private Sub _CargarInformacionPallets()

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

            If txtPedido.Text.Trim <> "" Then
                cm.CommandText = "select sum(Cantidad) TotalKilos from Pedido where pedido = '" & txtPedido.Text & "'"
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
            If a <> b Then
                .Visible = True
                _ActualizarMarcaProforma(txtProforma.Text, "0")
            Else
                _ActualizarMarcaProforma(txtProforma.Text, "1")
            End If
        End With
    End Sub

    Private Sub _ActualizarMarcaProforma(ByVal WProforma As String, ByVal WMarca As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("UPDATE ProformaExportacion SET PackingList = '" & WMarca & "' WHERE Proforma = '" & WProforma & "'")
        Dim dr As SqlDataReader
        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

            cm.CommandText = "SELECT AvisoPackingList as Aviso, PackingList FROM ProformaExportacion WHERE Proforma = '" & WProforma & "' AND Renglon = '01'"

            Using dr = cm.ExecuteReader

                With dr
                    If .HasRows Then
                        .Read()

                        Dim WCompleto = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))
                        Dim WMarcaAviso = IIf(IsDBNull(.Item("Aviso")), "", .Item("Aviso"))

                        ' Corroboramos si se ha marcado como PackingList completo.
                        If Val(WCompleto) <> 0 Then

                            ' En Caso de que si, se checkea si ya se ha realizado el aviso a Federico Monti.
                            ' En caso de que no, se pregunta si se quiere enviar un aviso por email.
                            If Val(WMarcaAviso) = 0 Then

                                _AvisarPorEmail(WProforma)

                            End If

                        End If

                    End If
                End With

            End Using

        Catch ex As Exception
            MsgBox("Hubo un problema al querer actualizar el Estado del Packing List de la Proforma '" & WProforma & "' en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _AvisarPorEmail(ByVal wProforma As String)

        If MsgBox("¿Desea avisar por Email que ya se encuentra disponible el PackingList de la Proforma '" & wProforma & "' a Federico Monti (fgmonti@surfactan.com.ar)?") = MsgBoxResult.Yes Then

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

        _CargarInformacionPallets()
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
End Class