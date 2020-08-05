Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class AltaMinuta
    Sub New(Optional ByVal Cliente As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtCliente.Text = Cliente

        txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub
    Private Sub AltaMinuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtObservaciones.Text = ""
        txtObservaciones2.Text = ""
        lblACobrar.Text = ""
        lblTotal.Text = ""

        dgvCtaCtes.Columns("Marca").ReadOnly = False

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            lblDescCliente.Text = ""

            If Trim(txtCliente.Text) = "" Then : Exit Sub : End If

            txtCliente.Text = FormatoCodigoCliente(txtCliente.Text)

            Dim WCli As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If WCli Is Nothing Then Exit Sub

            lblDescCliente.Text = UCase(WCli("Razon"))

            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Not FechaValidaParaEmitir() Then Exit Sub

            txtObservaciones.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Function FechaValidaParaEmitir() As Boolean

        If txtFecha.Text.Replace(" ", "").Length < 10 OrElse Not _ValidarFecha(txtFecha.Text) Then
            MsgBox("La fecha ingresada no es una fecha válida.", MsgBoxStyle.Exclamation)
            Return False
        End If

        '
        ' Sólo Fechas posteriores.
        '
        If Val(ordenaFecha(txtFecha.Text)) < Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) Then
            MsgBox("No se permiten realizar minutas para fechas anteriores al dia de hoy.", MsgBoxStyle.Exclamation)
            Return False
        End If

        '
        ' Controlamos que no se trate de fin de semana.
        '
        If EsFeriado(txtFecha.Text) Then
            If MsgBox("La Fecha indicada corresponde a un Fin de Semana.", MsgBoxStyle.Exclamation) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WCtaCte As DataTable = GetAll("SELECT Impre, Tipo, Numero, Fecha, Total, TotalUs, Saldo, SaldoUs, Vencimiento, Vencimiento1 FROM CtaCte WHERE Cliente = '" & txtCliente.Text & "' And Saldo <> 0")
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
                Select Case Clases.Helper.Left(ZImpre, 2)
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

        txtObservaciones.Focus()
    End Sub

    Private Sub rbDolares_MouseClick(sender As Object, e As MouseEventArgs) Handles rbPesos.MouseClick, rbDolares.MouseClick
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not FechaValidaParaEmitir() Then
            txtFecha.Focus()
            Exit Sub
        End If
        
        Dim WCli As DataRow = GetSingle("SELECT Direccion, Localidad FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

        If WCli Is Nothing Then
            MsgBox("El Cliente indicado no es un Cliente Válido.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim WCtasCtes = dgvCtaCtes.Rows.Cast(Of DataGridViewRow).ToList.Where(Function(r) r.Cells("Marca").Value = 1)

        If WCtasCtes.Count = 0 Then
            MsgBox("No hay Ctas Ctes seleccionadas para realizar la minuta.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim WMinuta As DataRow = GetSingle("SELECT Max(Codigo) As Mayor FROM Minuta")

        If WMinuta Is Nothing Then Exit Sub

        Dim WProx As Integer = OrDefault(WMinuta("Mayor"), 0) + 1
        Dim WRenglon As Short = 0

        Dim WSqls As New List(Of String)

        For Each r As DataGridViewRow In WCtasCtes
            WRenglon += 1
            Dim WMoneda As Byte = IIf(rbPesos.Checked, 0, 1)

            Dim Sql As String = String.Format("INSERT INTO Minuta (Clave, Codigo, Renglon, FechaAlta, Cliente, Razon, Direccion, Localidad, Horario, Fecha, FechaFactura, Tipo, Factura, Importe, Moneda, OrdFecha, OrdFechaAlta, Observaciones, ObservacionesII) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
                                             ceros(WProx, 6) & ceros(WRenglon, 2), WProx, WRenglon, Date.Now.ToString("dd/MM/yyyy"), txtCliente.Text, lblDescCliente.Text, WCli("Direccion"), WCli("Localidad"), "", txtFecha.Text, r.Cells("Fecha").Value, r.Cells("Impre").Value, r.Cells("Numero").Value, formatonumerico(r.Cells("Saldo").Value), WMoneda, ordenaFecha(txtFecha.Text), ordenaFecha(Date.Now.ToString("dd/MM/yyyy")), txtObservaciones.Text, txtObservaciones2.Text)

            WSqls.Add(Sql)
        Next

        WSqls.Add("UPDATE Cliente SET FechaMinuta = '" & txtFecha.Text & "' WHERE Cliente = '" & txtCliente.Text & "'")

        ExecuteNonQueries(WSqls.ToArray)

        With New VistaPrevia
            .Reporte = New ReporteMinuta
            .Formula = "{Minuta.Codigo} = " & WProx
            .Mostrar()
            .Imprimir()
        End With

        Close()

    End Sub

    Private Sub dgvCtaCtes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCtaCtes.CellMouseClick
        If e.ColumnIndex <> dgvCtaCtes.Columns("Marca").Index Then Exit Sub

        dgvCtaCtes.CurrentCell.Value = IIf(OrDefault(dgvCtaCtes.CurrentCell.Value, 0) = 0, 1, 0)

        _RecalcularImporteAPagar()

    End Sub

    Private Sub _RecalcularImporteAPagar()

        lblACobrar.Text = ""

        Dim datos As DataTable = TryCast(dgvCtaCtes.DataSource, DataTable)

        If datos Is Nothing Then Exit Sub

        Dim WImporteAPagar As Double = dgvCtaCtes.Rows.Cast(Of DataGridViewRow).ToList.Where(Function(r) r.Cells("Marca").Value = 1).Sum(Function(r) Val(formatonumerico(IIf(rbPesos.Checked, r.Cells("Saldo").Value, r.Cells("SaldoUs").Value))))

        dgvCtaCtes.RowsDefaultCellStyle.BackColor = Clases.Globales.WBackColorSecundario
        dgvCtaCtes.Rows.Cast(Of DataGridViewRow).ToList.Where(Function(r) r.Cells("Marca").Value = 1).ToList.ForEach(Sub(r) r.DefaultCellStyle.BackColor = Clases.Globales.WBackColorTerciario)

        lblACobrar.Text = String.Format("{0:N2}", WImporteAPagar)

    End Sub
End Class