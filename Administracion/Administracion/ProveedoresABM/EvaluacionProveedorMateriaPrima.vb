Imports System.ComponentModel
Imports System.Configuration
Imports System.IO
Imports System.Threading
Imports ConsultasVarias

Public Class EvaluacionProveedorMateriaPrima

    Private ReadOnly WProveedor As String

    Sub New(ByVal Proveedor As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WProveedor = Proveedor

        btnGrabar.Enabled = False

    End Sub

    Private Sub EvaluacionProveedorMateriaPrima_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        If Val(WProveedor) <> 0 Then

            Dim WPath As String = ConfigurationManager.AppSettings("PATH_DOCS_EVAL_PROV_MP")

            Directory.CreateDirectory(WPath & "" & WProveedor)

            Dim WProv As DataRow = GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")

            If WProv IsNot Nothing Then

                txtProveedor.Text = WProveedor
                txtDescProveedor.Text = Trim(OrDefault(WProv.Item("Nombre"), ""))

                BackgroundWorker1.RunWorkerAsync()

            End If

        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        TabControl1.TabPages.Clear()

        Dim WDatos As DataTable = GetAll("SELECT DISTINCT ct.Articulo MP, a.Descripcion FROM Cotiza ct INNER JOIN Articulo a ON a.Codigo = ct.Articulo  And a.ClasificacionFarma > 0  WHERE ct.Proveedor = '" & txtProveedor.Text & "' Order by ct.Articulo")

        For i = 0 To WDatos.Rows.Count - 1

            BackgroundWorker1.ReportProgress(i, WDatos.Rows(i))

            Thread.Sleep(100)

        Next

        btnGrabar.Enabled = WDatos.Rows.Count > 0

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim WDato As DataRow = TryCast(e.UserState, DataRow)

        Dim WTab As TabPage

        If WDato IsNot Nothing Then

            WTab = New TabPage(WDato.Item("MP"))

            TabControl1.TabPages.Add(WTab)

            WTab = Nothing

            'GC.Collect()

        End If

    End Sub

    Private Sub EvaluacionProveedorMateriaPrima_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker1.IsBusy Then BackgroundWorker1.CancelAsync()

        For Each tab As TabPage In TabControl1.TabPages
            With tab
                Dim controles As IEnumerable(Of EvaluacionPorMpUserControl) = .Controls.OfType(Of EvaluacionPorMpUserControl)()
                If controles.Any() Then
                    controles(0)._DetenerASync()
                End If
            End With
        Next

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Está seguro de querer salir? Se perderán los datos que no se hayan guardado.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        If TabControl1.TabPages.Count = 0 Then Exit Sub

        Dim WPath As String = ConfigurationManager.AppSettings("PATH_DOCS_EVAL_PROV_MP") & "" & WProveedor

        Directory.CreateDirectory(WPath)

        For Each MP As TabPage In TabControl1.TabPages

            Dim WCodMP As String = MP.Text

            Directory.CreateDirectory(WPath & "/" & WCodMP)

            If MP.Controls.OfType(Of EvaluacionPorMpUserControl)().Count() = 0 Then Continue For

            Dim WControl As EvaluacionPorMpUserControl = MP.Controls.OfType(Of EvaluacionPorMpUserControl)()(0)

            Dim WEstadoMP As Integer = WControl._ObtenerEstado()
            Dim WDatos As DBDataGridView = WControl._ObtenerDatosItems()

            Dim WClave, WReq, WSolicitado, WFechaSolicitado, WFechaSolicitadoOrd, WEntrego, WFechaEntrego, WFechaEntregoOrd, WAprobo, WFechaAprobo, WFechaAproboOrd, WFechaVto, WFechaVtoOrd, WAclaraciones As String

            Dim WSqls As New List(Of String)

            WSqls.Add("DELETE FROM EvaluacionProvMp WHERE Proveedor = '" & WProveedor & "' And Articulo = '" & WCodMP & "'")

            For Each row As DataGridViewRow In WDatos.Rows
                With row

                    WReq = .Cells("Req").Value

                    Directory.CreateDirectory(WPath & "/" & WCodMP & "/" & WReq.PadLeft(2, "0"))

                    WSolicitado = IIf(.Cells("Solicitado").Value, "1", "0")
                    WFechaSolicitado = OrDefault(.Cells("FechaSolicitado").Value, "")
                    WFechaSolicitadoOrd = ordenaFecha(WFechaSolicitado)

                    WEntrego = IIf(.Cells("Entrego").Value, "1", "0")
                    WFechaEntrego = OrDefault(.Cells("FechaEntrego").Value, "")
                    WFechaEntregoOrd = ordenaFecha(WFechaEntrego)

                    WAprobo = _ObtenerIDAprobo(.Cells("Aprobo").Value)
                    WFechaAprobo = OrDefault(.Cells("FechaAprobo").Value, "")
                    WFechaAproboOrd = ordenaFecha(WFechaAprobo)

                    WFechaVto = OrDefault(.Cells("Vto").Value, "")
                    WFechaVtoOrd = ordenaFecha(WFechaVto)

                    WAclaraciones = Trim(OrDefault(.Cells("Aclaraciones").Value, ""))

                    WClave = WProveedor.PadLeft(11, "0") & WCodMP & WReq.PadLeft(2, "0")

                    Dim WSql As String = String.Format("INSERT INTO EvaluacionProvMP (Clave, Proveedor, Renglon, Solicitado, FechaSolicitado, FechaSolicitadoOrd, Entrego, FechaEntrego, FechaEntregoOrd, Aprobo, FechaAprobo, FechaAproboOrd, Aclaraciones, EstadoMp, FechaVto, FechaVtoOrd, Articulo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}')",
                                                       WClave, WProveedor, WReq, WSolicitado, WFechaSolicitado, WFechaSolicitadoOrd, WEntrego, WFechaEntrego, WFechaEntregoOrd, WAprobo, WFechaAprobo, WFechaAproboOrd, WAclaraciones, WEstadoMP, WFechaVto, WFechaVtoOrd, WCodMP)

                    WSqls.Add(WSql)

                End With
            Next

            ExecuteNonQueries(WSqls.ToArray())

        Next

        MsgBox("¡Grabación realizada correctamente!", MsgBoxStyle.Information)

    End Sub

    Private Function _ObtenerIDAprobo(ByVal s As String) As Integer

        Select Case s
            Case "APROBADO"
                Return 1
            Case "NO APLICA"
                Return 2
            Case Else
                Return 0
        End Select

    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If TabControl1.TabPages.Count = 0 Then
            MsgBox("El Proveedor no comercializa ningún Producto Farma.", MsgBoxStyle.Information)
            Close()
        Else

            Dim WControl As EvaluacionPorMpUserControl

            WControl = New EvaluacionPorMpUserControl(txtProveedor.Text, TabControl1.TabPages(0).Text)

            WControl.Dock = DockStyle.Fill

            TabControl1.TabPages(TabControl1.TabPages(0).TabIndex).Controls.Add(WControl)

        End If

    End Sub

    Private Sub TabControl1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TabControl1.MouseClick

        If TabControl1.TabPages(TryCast(sender, TabControl).SelectedTab.TabIndex).Controls.OfType(Of EvaluacionPorMpUserControl)().Any() Then Exit Sub

        Dim WControl As EvaluacionPorMpUserControl

        WControl = New EvaluacionPorMpUserControl(txtProveedor.Text, TryCast(sender, TabControl).SelectedTab.Text)

        WControl.Dock = DockStyle.Fill

        TabControl1.TabPages(TryCast(sender, TabControl).SelectedTab.TabIndex).Controls.Add(WControl)

    End Sub
End Class