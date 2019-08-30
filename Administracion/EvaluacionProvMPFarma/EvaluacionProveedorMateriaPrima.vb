Imports System.ComponentModel
Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports EvaluacionProvMPFarma.Helper
Imports ConsultasVarias.Clases.Query

Public Class EvaluacionProveedorMateriaPrima : Implements IAyudaProveedores, ConsultasVarias.IIngresoClaveSeguridad

    Private WProveedor As String
    Private WAutorizadoGrabar As Boolean = False
    Private ZOperador As Integer = 0
    Private WCodMP As String = ""
    Private WTipoMP As Integer = 0

    Sub New(Optional ByVal Proveedor As String = "", Optional ByVal HabilitarGrabacion As Boolean = False, Optional ByVal CodMP As String = "", Optional ByVal TipoMP As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WProveedor = Proveedor
        WCodMP = CodMP
        WTipoMP = TipoMP

        btnGrabar.Enabled = HabilitarGrabacion

    End Sub

    Private Sub EvaluacionProveedorMateriaPrima_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        'Conexion.EmpresaDeTrabajo = "SurfactanSa"

        CheckForIllegalCrossThreadCalls = False
        WAutorizadoGrabar = False

        TabControl1.TabPages.Clear()

        If Val(WProveedor) <> 0 Then
            _TraerInformacionProveedorMP()
        End If

    End Sub

    Private Sub _TraerInformacionProveedorMP()

        WAutorizadoGrabar = False

        Dim WProv As DataRow = GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")

        If WProv Is Nothing Then Return

        txtProveedor.Text = WProveedor
        txtDescProveedor.Text = Trim(OrDefault(WProv.Item("Nombre"), ""))

        TabControl1.TabPages.Clear()

        Dim WFiltro As String = _GenerarFiltroPorTipo(Me.WTipoMP)
        Dim WDatos As DataTable = GetAll("SELECT DISTINCT ct.Articulo MP, a.Descripcion FROM Cotiza ct INNER JOIN Articulo a ON a.Codigo = ct.Articulo  And (" & WFiltro & ")  WHERE ct.Proveedor = '" & txtProveedor.Text & "' Order by ct.Articulo")

        For i = 0 To WDatos.Rows.Count - 1

            BackgroundWorker1.ReportProgress(i, WDatos.Rows(i))

            Thread.Sleep(100)
        Next

        If TabControl1.TabPages.Count = 0 Then
            MsgBox("El Proveedor no comercializa ningún Producto Farma.", MsgBoxStyle.Information)
            TabControl1.TabPages.Clear()
            txtProveedor_MouseDoubleClick(Nothing, Nothing)
            ' Close()
        Else

            Dim WPath As String = ConfigurationManager.AppSettings("PATH_DOCS_EVAL_PROV_MP")

            Directory.CreateDirectory(WPath & "" & WProveedor)

            Dim WControl As EvaluacionPorMpUserControl
            Dim WIndicePrimero As Integer = 0

            If WCodMP.Trim() <> "" Then
                For Each tab As TabPage In TabControl1.TabPages
                    If UCase(tab.Text) = UCase(WCodMP) Then
                        WIndicePrimero = tab.TabIndex
                        TabControl1.SelectedTab = tab
                        Exit For
                    End If
                Next
            End If

            WControl = New EvaluacionPorMpUserControl(txtProveedor.Text, TabControl1.TabPages(WIndicePrimero).Text)

            WControl.Dock = DockStyle.Fill

            WControl.HabilitarControles(btnGrabar.Enabled)

            TabControl1.TabPages(TabControl1.TabPages(WIndicePrimero).TabIndex).Controls.Add(WControl)

        End If

        txtProveedor.Focus()

    End Sub

    Private Function _GenerarFiltroPorTipo(ByVal wTipoMp As Integer) As String
        Select Case (wTipoMp)
            Case 0
                Return "ISNULL(a.ClasificacionFarma,0) = 1 Or (ISNULL(a.ClasificacionFarma,0) = 0 And a.ReqEvalEspecial = '1'" & _
                ") Or (ISNULL(a.ClasificacionFarma,0) > 1 And a.ReqEvalEspecial = '1') "
            Case 1
                Return "ISNULL(a.ClasificacionFarma,0) = 1"
            Case 2, 3
                Return String.Format("ISNULL(a.ClasificacionFarma,0) = ${0} And a.ReqEvalEspecial = '1'", wTipoMp)
            Case Else
                Return "ISNULL(a.ClasificacionFarma, 0) = 0 And a.ReqEvalEspecial = '1'"
        End Select

    End Function

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WProv As DataRow = GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")

        If WProv Is Nothing Then Exit Sub

        txtProveedor.Text = WProveedor
        txtDescProveedor.Text = Trim(OrDefault(WProv.Item("Nombre"), ""))

        TabControl1.TabPages.Clear()

        Dim WDatos As DataTable = GetAll("SELECT DISTINCT ct.Articulo MP, a.Descripcion FROM Cotiza ct INNER JOIN Articulo a ON a.Codigo = ct.Articulo  And a.ClasificacionFarma > 0  WHERE ct.Proveedor = '" & txtProveedor.Text & "' Order by ct.Articulo")

        BackgroundWorker1.ReportProgress(1, WDatos)

        btnGrabar.Enabled = WDatos.Rows.Count > 0

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim WDato As DataRow = TryCast(e.UserState, DataRow)

        Dim WTab As TabPage

        If WDato IsNot Nothing Then

            WTab = New TabPage(WDato.Item("MP"))

            TabControl1.TabPages.Add(WTab)

            WTab = Nothing

            GC.Collect()

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
        If btnGrabar.Enabled Then
            If MsgBox("¿Está seguro de querer salir? Se perderán los datos que no se hayan guardado.", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        End If

        Close()

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        If TabControl1.TabPages.Count = 0 Then Exit Sub

        If Not WAutorizadoGrabar Then
            With New ConsultasVarias.IngresoClaveSeguridad
                .ShowDialog(Me)
            End With
            Exit Sub
        End If

        WAutorizadoGrabar = False

        Dim WFecha, WFechaOrd As String

        WFecha = Date.Now.ToString("dd/MM/yyyy")
        WFechaOrd = ordenaFecha(WFecha)

        Dim WPath As String = ConfigurationManager.AppSettings("PATH_DOCS_EVAL_PROV_MP") & "" & WProveedor

        Directory.CreateDirectory(WPath)

        For Each MP As TabPage In TabControl1.TabPages

            Dim WCodMP As String = MP.Text

            Directory.CreateDirectory(WPath & "/" & WCodMP)

            If MP.Controls.OfType(Of EvaluacionPorMpUserControl)().Count() = 0 Then Continue For

            Dim WControl As EvaluacionPorMpUserControl = MP.Controls.OfType(Of EvaluacionPorMpUserControl)()(0)

            Dim WEstadoMP As Integer = WControl._ObtenerEstado()
            Dim WFechaEvaluaVto As String = WControl._ObtenerFechaEvaluaVto()
            Dim WFechaEvaluaVtoOrd As String = ordenaFecha(WFechaEvaluaVto)
            Dim WDatos As ConsultasVarias.DBDataGridView = WControl._ObtenerDatosItems()

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
                    
                    Dim WSql As String = String.Format("INSERT INTO EvaluacionProvMP (Clave, Proveedor, Renglon, Solicitado, FechaSolicitado, FechaSolicitadoOrd, Entrego, FechaEntrego, FechaEntregoOrd, Aprobo, FechaAprobo, FechaAproboOrd, Aclaraciones, EstadoMp, FechaVto, FechaVtoOrd, Articulo, Operador, FechaEvaluaVto, FechaEvaluaVtoOrd, Fecha, FechaOrd) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}')",
                                                       WClave, WProveedor, WReq, WSolicitado, WFechaSolicitado, WFechaSolicitadoOrd, WEntrego, WFechaEntrego, WFechaEntregoOrd, WAprobo, WFechaAprobo, WFechaAproboOrd, WAclaraciones, WEstadoMP, WFechaVto, WFechaVtoOrd, WCodMP, ZOperador, WFechaEvaluaVto, WFechaEvaluaVtoOrd, WFecha, WFechaOrd)

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

            Dim WPath As String = ConfigurationManager.AppSettings("PATH_DOCS_EVAL_PROV_MP")

            Directory.CreateDirectory(WPath & "" & WProveedor)

            Dim WControl As EvaluacionPorMpUserControl

            WControl = New EvaluacionPorMpUserControl(txtProveedor.Text, TabControl1.TabPages(0).Text)

            WControl.Dock = DockStyle.Fill

            WControl.HabilitarControles(btnGrabar.Enabled)

            TabControl1.TabPages(TabControl1.TabPages(0).TabIndex).Controls.Add(WControl)

        End If

    End Sub

    Private Sub TabControl1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TabControl1.MouseClick

        If TabControl1.TabPages(TryCast(sender, TabControl).SelectedTab.TabIndex).Controls.OfType(Of EvaluacionPorMpUserControl)().Any() Then Exit Sub

        Dim WControl As EvaluacionPorMpUserControl

        WControl = New EvaluacionPorMpUserControl(txtProveedor.Text, TryCast(sender, TabControl).SelectedTab.Text)

        WControl.Dock = DockStyle.Fill

        WControl.HabilitarControles(btnGrabar.Enabled)

        TabControl1.TabPages(TryCast(sender, TabControl).SelectedTab.TabIndex).Controls.Add(WControl)

    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtProveedor.KeyPress
        e.Handled = Regex.IsMatch(txtProveedor.Text, "[^0-9]") And Not Char.IsControl(e.KeyChar)
    End Sub

    Private Sub EvaluacionProveedorMateriaPrima_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtProveedor.Focus()
        If Val(txtProveedor.Text) = 0 Then txtProveedor_MouseDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtProveedor.MouseDoubleClick
        With New AyudaProveedores
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaProveedores(ByVal Codigo As String, ByVal Nombre As String, Optional ByVal TipoMP As Integer = 0) Implements IAyudaProveedores._ProcesarAyudaProveedores
        txtProveedor.Text = Codigo
        Me.WTipoMP = TipoMP
        txtProveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtProveedor.Text) = "" Then : Exit Sub : End If

            WProveedor = txtProveedor.Text

            _TraerInformacionProveedorMP()

        ElseIf e.KeyData = Keys.Escape Then
            txtProveedor.Text = ""
        End If

    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements ConsultasVarias.IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad
        Dim _Operador As DataRow = GetSingle("SELECT Operador, EvaluaProvMpFarma Permiso FROM Operador WHERE UPPER(Clave) = '" & WClave.ToString().ToUpper() & "'")

        If _Operador IsNot Nothing Then
            WAutorizadoGrabar = UCase(OrDefault(_Operador.Item("Permiso"), "")) = "S"
            ZOperador = OrDefault(_Operador.Item("Operador"), 0).ToString()
        End If

        btnGrabar_Click(Nothing, Nothing)

    End Sub
End Class