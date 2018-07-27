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
            _CargarInformacionPallets()
        End If
    End Sub

    Private Sub _CargarInformacionPallets()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ap.Pallet Nro, ap.CodigoPallet Pallet, a.Descripcion, SUM(ap.Bultos) Bultos, (SUM(ap.KgBultos * ap.Bultos) + ISNULL(a.Tara, 0)) KgBrutos, (sum(ap.KgBultos * ap.Bultos)) KgNetos, ap.FechaDisponible As Disponible FROM ArmadoPallets ap LEFT JOIN Articulo a ON a.Codigo = ap.CodigoPallet WHERE ap.Proforma = '" & txtProforma.Text & "' GROUP BY ap.Pallet, ap.CodigoPallet, a.Tara, a.Descripcion, ap.FechaDisponible")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable
        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al cargar los Pallets referidos a esta Proforma desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
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

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Pallets_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub btnAgregarPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPallet.Click

        Dim frm As New IngresoPallet(txtProforma.Text, txtPedido.Text, -1)
        frm.ShowDialog(Me)

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
        frm.Reporte = New PlanillaPallets
        frm.Formula = "{ArmadoPallets.Proforma} = '" & txtProforma.Text & "' AND {ArmadoPallets.Pedido} = '" & txtPedido.Text & "' AND {ArmadoPallets.CodigoPallet} = {ArtPallet.Codigo} AND {ArmadoPallets.CodigoEnvase} = {ArtEnvase.Codigo}" &
                      " AND {ArmadoPallets.Proforma} = {ProformaExportacion.Proforma} AND {ProformaExportacion.Cliente} = {Cliente.Cliente} AND {ProformaExportacion.Renglon} = '01'"
        frm.Mostrar()


        Cursor = Cursors.Default
        btn.Enabled = True
        btn.Cursor = Cursors.Hand
    End Sub

    Private Sub btnInfoProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoProforma.Click
        If txtProforma.Text.Trim <> "" Then

            Dim frm As New Proforma()
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.txtNroProforma.Text = txtProforma.Text
            frm.txtNroProforma_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            frm.Show(Me)

        End If
    End Sub
End Class