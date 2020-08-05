Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class AgendaDatosCtaCte

    Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtCliente.Text = Cliente

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim FiltroTipo As String = ""

        If Not rbTotal.Checked Then
            If rbCtaCte.Checked Then
                FiltroTipo = " And (Tipo < 50 Or Tipo = 60) "
            Else
                FiltroTipo = " And (Tipo >= 50 And Tipo <> 60) "
            End If
        End If

        Dim FiltroTipoDatos As String = ""

        If Not rbTodos.Checked Then
            FiltroTipoDatos = " And Saldo <> 0"
        End If

        Dim WCtaCte As DataTable = GetAll("SELECT Impre, Tipo, Numero, Fecha, Total, TotalUs, Saldo, SaldoUs, Vencimiento, Vencimiento1 FROM CtaCte WHERE Cliente = '" & txtCliente.Text & "'" & FiltroTipo & FiltroTipoDatos)
        With WCtaCte.Columns
            .Add("Importe1", GetType(Double))
            .Add("Importe2", GetType(Double))
        End With

        BackgroundWorker1.ReportProgress(1, WCtaCte)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim WCtaCte As DataTable = TryCast(e.UserState, DataTable)

        If WCtaCte Is Nothing Then Exit Sub

        WCtaCte.Rows.Cast(Of DataRow).ToList.ForEach(Sub(r) _ProcesarRenglon(r))

        dgvCtaCtes.DataSource = WCtaCte

        If rbPesos.Checked Then
            dgvCtaCtes.Columns("Saldo").Visible = True
            dgvCtaCtes.Columns("SaldoUs").Visible = False
        Else
            dgvCtaCtes.Columns("Saldo").Visible = False
            dgvCtaCtes.Columns("SaldoUs").Visible = True
        End If

    End Sub

    Private Sub _ProcesarRenglon(ByVal r As DataRow)
        r("Impre") = _GenerarImpre(r("Tipo"), r("Impre"))
        r("Importe1") = 0
        r("Importe2") = 0

        If rbPesos.Checked Then
            r("Importe1") = IIf(r("Total") > 0, r("Total"), 0)
            r("Importe2") = IIf(r("Total") < 0, r("Total"), 0)
        Else
            r("Importe1") = IIf(r("TotalUs") > 0, r("TotalUs"), 0)
            r("Importe2") = IIf(r("TotalUs") < 0, r("TotalUs"), 0)
        End If

    End Sub

    Private Function _GenerarImpre(ByVal ZTipo As String, ByVal ZImpre As String) As String

        Select Case Val(ZTipo)
            Case 1, 3
                If ZImpre = "FCE" Then Return "FCE"
                Return "FAC"
            Case 2
                Return "DEV"
            Case 4, 5
                Select Case Util.Clases.Helper.Left(ZImpre, 2)
                    Case "DC"
                        Return "D.C"
                    Case "CH"
                        Return "CHR"
                    Case Else
                        Return "N/D"
                End Select
            Case 6
                Return "REC"
            Case 7
                Return "ANT"
            Case 10
                Return "FCR"
            Case 50
                Return "COD"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Dim WTotal As Double = dgvCtaCtes.Rows.Cast(Of DataGridViewRow).ToList.Sum(Function(r) Val(formatonumerico(IIf(rbPesos.Checked, r.Cells("Saldo").Value, r.Cells("SaldoUs").Value))))

        lblTotal.Text = String.Format("{0:N2}", WTotal)

        dgvCtaCtes.Focus()
    End Sub

    Private Sub dgvCtaCtes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCtaCtes.CellMouseClick
        If e.ColumnIndex <> dgvCtaCtes.Columns("Marca").Index Then Exit Sub

        dgvCtaCtes.CurrentCell.Value = IIf(OrDefault(dgvCtaCtes.CurrentCell.Value, 0) = 0, 1, 0)

        _RecalcularImporteAPagar()

    End Sub

    Private Sub _RecalcularImporteAPagar()

        lblTotal.Text = ""

        Dim datos As DataTable = TryCast(dgvCtaCtes.DataSource, DataTable)

        If datos Is Nothing Then Exit Sub

        Dim WImporteAPagar As Double = dgvCtaCtes.Rows.Cast(Of DataGridViewRow).Sum(Function(r) Val(formatonumerico(IIf(rbPesos.Checked, r.Cells("Saldo").Value, r.Cells("SaldoUs").Value))))

        lblTotal.Text = String.Format("{0:N2}", WImporteAPagar)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With New AgendaReclamoACliente(txtCliente.Text)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub AgendaDatosCtaCte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub rbDolares_MouseClick(sender As Object, e As MouseEventArgs) Handles rbTotal.MouseClick, rbTodos.MouseClick, rbPesos.MouseClick, rbPendientes.MouseClick, rbDolares.MouseClick, rbDocumentos.MouseClick, rbCtaCte.MouseClick
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class