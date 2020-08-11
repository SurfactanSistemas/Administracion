Imports Util.Clases.Helper
Imports Util.Clases.Query
Imports Util
Imports Util.Clases
Imports Util.Interfaces

Public Class ComposicionProducto : Implements IComposicionDatosAdicionales, IIngresoClaveSeguridad, IListaConsultas, iAyudaPts, IAyudaMPs

    Private WDatosAdicionales As DatosAdicionales
    Private WProceso As Proceso
    Private WAutorizado As Boolean

    Private Enum Proceso
        Grabacion
        Bloqueo
        Revalida
    End Enum

    Sub New(Optional ByVal Producto As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtProducto.Text = Producto
    End Sub

    Private Sub ComposicionProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'btnLimpiar_Click(Nothing, Nothing)
        CheckForIllegalCrossThreadCalls = False
        txtProducto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Public Sub _ProcesarComposicionDatosAdicionales(DatosAdicionales As DatosAdicionales) Implements IComposicionDatosAdicionales._ProcesarComposicionDatosAdicionales
        WDatosAdicionales = DatosAdicionales
    End Sub

    Private Sub btnDatosAdicionales_Click(sender As Object, e As EventArgs) Handles btnDatosAdicionales.Click
        If WDatosAdicionales Is Nothing Then WDatosAdicionales = New DatosAdicionales

        With New ComposicionDatosAdicionales(WDatosAdicionales)
            .ShowDialog(Me)
        End With
    End Sub

    Private Sub btnBloqueo_Click(sender As Object, e As EventArgs) Handles btnBloqueo.Click

        If MsgBox("¿Bloquear el Producto actual para todas las plantas?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        If Not WAutorizado Then

            WProceso = Proceso.Bloqueo

            With New IngresoClaveSeguridad
                .ShowDialog(Me)
                Exit Sub
            End With

        End If

        WAutorizado = False

        Dim WSql As New List(Of String)

        For Each emp As String In Conexion.Empresas
            WSql.Add(String.Format("UPDATE {0}.dbo.Terminado SET Estado = 'N', EstadoI = 'N' WHERE Codigo = '{1}'", emp, txtProducto.Text))
        Next

        ExecuteNonQueries(WSql.ToArray)

    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad

        WAutorizado = False

        Select Case WProceso

            Case Proceso.Bloqueo

                Dim Clave As DataRow = GetSingle("SELECT GrabaI FROM Operador WHERE Clave = '" & WClave & "'")

                If Clave IsNot Nothing Then
                    WAutorizado = OrDefault(Clave("GrabaI"), "") = "S"

                    If WAutorizado Then btnBloqueo_Click(Nothing, Nothing)

                End If

            Case Proceso.Grabacion

        End Select

        If Not WAutorizado Then
            MsgBox("Clave erronea", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        For Each c As Control In {txtControlCambios, txtObservaciones, txtProducto, txtRefLaboratorio, lblDescProducto, lblEstado, lblFecha, lblResponsable, lblVersion, gbPb}
            c.Text = ""
        Next

        pnlPb.Visible = False

        WAutorizado = False
        WProceso = Nothing

        dgvComponentes.Rows.Clear()

        dgvComponentes.Rows.Add("", "", "", "", "")

        WDatosAdicionales = New DatosAdicionales

        txtProducto.Focus()

    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        With New ListaConsultas("PRODUCTO TERMINADO", "MATERIA PRIMA")
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarListaConsultas(Opcion As Integer) Implements IListaConsultas._ProcesarListaConsultas

        Select Case Opcion
            Case 0
                With New AyudaPTs
                    .Show(Me)
                End With
            Case 1
                With New AyudaMPs
                    .Show(Me)
                End With
        End Select

    End Sub

    Public Sub _ProcesarAyudaPTs(Codigo As String, Descrip As String) Implements IAyudaPTs._ProcesarAyudaPTs
        _CargarPTEnFila(Codigo, dgvComponentes.CurrentRow.Index)
    End Sub

    Private Sub _CargarPTEnFila(codigo As String, index As Integer)
        With dgvComponentes.Rows(index)
            .Cells("Tipo").Value = "T"
            .Cells("Terminado").Value = codigo
            .Cells("Articulo").Value = ""
            .Cells("Descripcion").Value = _ObtenerDescripcionTerminado(codigo)
            dgvComponentes.CurrentCell = .Cells("Cantidad")
        End With
        dgvComponentes.Focus()
    End Sub

    Private Function _ObtenerDescripcionTerminado(codigo As String) As String
        Dim Ter As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & codigo & "'")

        If Ter IsNot Nothing Then Return UCase(Trim(OrDefault(Ter("Descripcion"), "")))

        Return ""
    End Function

    Public Sub _ProcesarAyudaMPs(Codigo As String, Descrip As String) Implements IAyudaMPs._ProcesarAyudaMPs
        _CargarMPEnFila(Codigo, dgvComponentes.CurrentRow.Index)
    End Sub

    Private Sub _CargarMPEnFila(codigo As String, index As Integer)
        With dgvComponentes.Rows(index)
            .Cells("Tipo").Value = "M"
            .Cells("Terminado").Value = ""
            .Cells("Articulo").Value = codigo
            .Cells("Descripcion").Value = _ObtenerDescripcionArticulo(codigo)
            dgvComponentes.CurrentCell = .Cells("Cantidad")
        End With
        dgvComponentes.Focus()
    End Sub

    Private Function _ObtenerDescripcionArticulo(codigo As String) As String
        Dim Ter As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & codigo & "'")

        If Ter IsNot Nothing Then Return UCase(Trim(OrDefault(Ter("Descripcion"), "")))

        Return ""
    End Function

    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown

        If e.KeyData = Keys.Enter Then
            Dim Codigo As String = txtProducto.Text.Replace(" ", "")

            btnLimpiar_Click(Nothing, Nothing)

            txtProducto.Text = Codigo

            Dim WComp As DataTable = GetAll("SELECT c.Referencia, c.Observaciones1, c.Observaciones2, c.Tipo, c.Articulo1, c.Articulo2, c.Cantidad, t.DescriOnu, t.Carga, t.Clase, t.Embalaje, t.EstadoProducto, t.Intervencion, t.Naciones, t.Riesgo, t.Secundario As RSec, t.Vida, t.Restriccion, t.Descripcion, o.Descripcion As DescResponsable, t.Version, t.Estado, t.FechaVersion FROM Composicion c INNER JOIN Terminado t ON t.Codigo = c.Terminado LEFT OUTER JOIN Operador o ON o.Operador = c.Operador WHERE c.Terminado = '" & txtProducto.Text & "'")

            dgvComponentes.Rows.Clear()

            For Each Comp As datarow In WComp.Rows

                lblDescProducto.Text = Trim(OrDefault(Comp("Descripcion"), ""))
                lblVersion.Text = Trim(OrDefault(Comp("Version"), ""))
                lblEstado.Text = Trim(OrDefault(Comp("Estado"), ""))
                lblFecha.Text = Trim(OrDefault(Comp("FechaVersion"), ""))
                lblResponsable.Text = Trim(OrDefault(Comp("DescResponsable"), ""))
                txtRefLaboratorio.Text = Trim(OrDefault(Comp("Referencia"), ""))
                txtObservaciones.Text = Trim(OrDefault(Comp("Observaciones1"), ""))
                txtControlCambios.Text = Trim(OrDefault(Comp("Observaciones2"), ""))

                With WDatosAdicionales
                    .Caracteristicas = Trim(OrDefault(Comp("DescriOnu"), ""))
                    .Carga = Val(OrDefault(Comp("Carga"), ""))
                    .Clase = Trim(OrDefault(Comp("Clase"), ""))
                    .Embalaje = Trim(OrDefault(Comp("Embalaje"), ""))
                    .Estado = Val(OrDefault(Comp("EstadoProducto"), ""))
                    .FIntervencion = Trim(OrDefault(Comp("Intervencion"), ""))
                    .NUnidas = Trim(OrDefault(Comp("Naciones"), ""))
                    .Riesgo = Trim(OrDefault(Comp("Riesgo"), ""))
                    .RSec = Trim(OrDefault(Comp("RSec"), ""))
                    .VidaUtil = Val(OrDefault(Comp("Vida"), ""))
                    .Restriccion = Val(OrDefault(Comp("Restriccion"), "")) = 1
                End With

                Dim r As Short = dgvComponentes.Rows.Add()

                With dgvComponentes.Rows(r)

                    .Cells("Tipo").Value = Trim(OrDefault(Comp("Tipo"), ""))

                    Dim t As String = Trim(OrDefault(Comp("Tipo"), ""))

                    .Cells("Terminado").Value = IIf(t = "T", OrDefault(Comp("Articulo2"), ""), "")
                    .Cells("Articulo").Value = IIf(t = "M", OrDefault(Comp("Articulo1"), ""), "")

                    .Cells("Terminado").ReadOnly = t = "M"
                    .Cells("Articulo").ReadOnly = t = "T"

                    .Cells("Descripcion").Value = IIf(t = "T", _ObtenerDescripcionTerminado(.Cells("Terminado").Value), _ObtenerDescripcionArticulo(.Cells("Articulo").Value))
                    .Cells("Cantidad").Value = OrDefault(Comp("Cantidad"), 0)

                End With

            Next

            dgvComponentes.Rows.Add()

            With dgvComponentes
                .CurrentCell = .Rows(0).Cells("Tipo")
                .Focus()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtProducto.Text = ""
        End If

    End Sub




    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvComponentes
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.
                .EndEdit()
                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = UCase(OrDefault(.CurrentCell.Value, ""))

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    'Case 1
                        '    If Not _EsNumeroOControl(keyData) Then
                        '        Return True
                        '    End If
                    Case 4
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If valor <> "" Then

                        Select Case iCol
                            Case 0
                                .Rows(iRow).Cells("Terminado").ReadOnly = True
                                .Rows(iRow).Cells("Articulo").ReadOnly = True

                                .Rows(iRow).Cells("Tipo").Value = valor
                                If valor <> "T" And valor <> "M" Then Return True

                            Case 1
                                Dim Ter As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & valor & "'")
                                .Rows(iRow).Cells("Articulo").Value = ""

                                If Ter Is Nothing Then
                                    .Rows(iRow).Cells("Descripcion").Value = ""
                                    Return True
                                End If

                                .Rows(iRow).Cells("Descripcion").Value = UCase(Trim(OrDefault(Ter("Descripcion"), "")))
                            Case 2
                                Dim Art As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & valor & "'")

                                .Rows(iRow).Cells("Terminado").Value = ""

                                If Art Is Nothing Then
                                    .Rows(iRow).Cells("Descripcion").Value = ""
                                    Return True
                                End If

                                .Rows(iRow).Cells("Descripcion").Value = UCase(Trim(OrDefault(Art("Descripcion"), "")))
                            Case 4
                                .Rows(iRow).Cells("Cantidad").Value = String.Format("{0:N5}", Val(formatonumerico(valor, 5)))

                        End Select

                        Select Case iCol
                            Case 0
                                If valor = "T" Then
                                    .CurrentCell = .Rows(iRow).Cells("Terminado")
                                    .Rows(iRow).Cells("Terminado").ReadOnly = False
                                Else
                                    .CurrentCell = .Rows(iRow).Cells("Articulo")
                                    .Rows(iRow).Cells("Articulo").ReadOnly = False
                                End If
                            Case 1, 2
                                .CurrentCell = .Rows(iRow).Cells("Cantidad")
                            Case 4
                                If .Rows.Count - 1 = iRow Then
                                    .Rows.Add()
                                End If
                                .CurrentCell = .Rows(iRow + 1).Cells("Tipo")
                            Case Else
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                        End Select


                    End If

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 4 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ComposicionProducto_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtProducto.Focus()
    End Sub

    Private Sub btnRevalida_Click(sender As Object, e As EventArgs) Handles btnRevalida.Click
        If MsgBox("¿Revalidar el Producto actual para todas las plantas?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        If Not WAutorizado Then

            WProceso = Proceso.Revalida

            With New IngresoClaveSeguridad
                .ShowDialog(Me)
                Exit Sub
            End With

        End If

        WAutorizado = False

        Dim WSql As New List(Of String)

        For Each emp As String In Conexion.Empresas
            WSql.Add(String.Format("UPDATE {0}.dbo.Terminado SET Estado = 'S' WHERE Codigo = '{1}'", emp, txtProducto.Text))
        Next

        ExecuteNonQueries(WSql.ToArray)
    End Sub

    Private Sub btnComposicionSedronar_Click(sender As Object, e As EventArgs) Handles btnComposicionSedronar.Click

        ' Guarda los PTs y MPs de la composición actual.
        Dim Mps As New List(Of Mp)
        Dim Pts As New List(Of Pt)

        For Each row As DataGridViewRow In dgvComponentes.Rows
            If OrDefault(row.Cells("Tipo").Value, "") = "T" Then
                Pts.Add(New Pt(row.Cells("Terminado").Value, Val(formatonumerico(row.Cells("Cantidad").Value, 5))))
            ElseIf OrDefault(row.Cells("Tipo").Value, "") = "M" Then
                Mps.Add(New Mp(row.Cells("Articulo").Value, Val(formatonumerico(row.Cells("Cantidad").Value, 5))))
            End If
        Next

        Mps.AddRange(_DescomponerPT(Pts))

        ' Suma la cantidad de Kilos de las MPs que sean Sedronar.

        Dim WArts As List(Of Mp) = Mps.FindAll(Function(r) _EsSedronar(r.Codigo))

        ' Calcula el contenido porcentual.
        Dim WKilosComposicion As Double = dgvComponentes.Rows.Cast(Of DataGridViewRow).ToList.Sum(Function(r) Val(formatonumerico(r.Cells("Cantidad").Value, 5)))

        Dim WKilosTotalSedronar As Double = WArts.Sum(Function(r) r.Cantidad)

        Dim WComposicionPorcentual As Double = (WKilosTotalSedronar / WKilosComposicion) * 100

        MsgBox(String.Format("Kilos Composicion: {0:N5}{3}Kilos MP Sedronar: {1:N5}{3}Composicion Porcentual: {2:N2} %", WKilosComposicion, WKilosTotalSedronar, WComposicionPorcentual, vbCrLf))

    End Sub

    Private Function _DescomponerPT(pts As List(Of Pt)) As IEnumerable(Of Mp)

        Dim Mps As New List(Of Mp)

        ' Busca la composicion de los PTs que puede llegar a haber y los separa en PTs y MPs.
        Dim WLimite As Short = Pts.Count
        Dim WComienzo As Short = 0

        While WComienzo < WLimite And WComienzo < 200
            Dim pt As Pt = Pts(WComienzo)
            Dim Composicion As DataTable = GetAll("SELECT Tipo, Articulo1 As Articulo, Articulo2 As Terminado, Cantidad FROM Composicion WHERE Terminado = '" & pt.Codigo & "' ORDER BY Renglon")
            For Each row As DataRow In Composicion.Rows
                If OrDefault(row("Tipo"), "") = "T" Then
                    Pts.Add(New Pt(row("Terminado"), Val(formatonumerico(row("Cantidad"), 5))))
                    WLimite += 1
                ElseIf OrDefault(row("Tipo"), "") = "M" Then
                    Mps.Add(New Mp(row("Articulo"), Val(formatonumerico(row("Cantidad"), 5))))
                End If
            Next
            WComienzo += 1
        End While

        Return Mps

    End Function

    Private Function _EsSedronar(codigo As String) As Boolean
        Dim Art As DataRow = GetSingle("SELECT Sedronar FROM Articulo WHERE Codigo = '" & codigo & "'")

        If Art IsNot Nothing Then
            Return Val(OrDefault(Art("Sedronar"), "")) = 1
        End If

        Return False
    End Function

    Private Class Mp
        Public ReadOnly Codigo As String
        Public ReadOnly Cantidad As Double
        Sub New(ByVal Codigo As String, ByVal Cantidad As Double)
            Me.Codigo = Codigo
            Me.Cantidad = Cantidad
        End Sub
    End Class

    Private Class Pt
        Public ReadOnly Codigo As String
        Public ReadOnly Cantidad As Double
        Sub New(ByVal Codigo As String, ByVal Cantidad As Double)
            Me.Codigo = Codigo
            Me.Cantidad = Cantidad
        End Sub
    End Class

    Private Sub btnPTConSedronar_Click(sender As Object, e As EventArgs) Handles btnPTConSedronar.Click
        'If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()

        With New VistaPrevia
            .Reporte = New ReporteListadoTerminadosSedronar
            .Mostrar()
        End With

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim WPts As DataTable = GetAll("SELECT c.Terminado, Total = sum(c.Cantidad) FROM Composicion c GROUP BY c.Terminado")

        BackgroundWorker1.ReportProgress(1, WPts)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        pb.Value = 0
        pb.Visible = True

        pnlPb.Visible = True
        pnlPb.Refresh()

        Dim WPts As DataTable = TryCast(e.UserState, DataTable)

        pb.Maximum = WPts.Rows.Count

        If WPts Is Nothing Then Exit Sub

        Dim _Pts As List(Of Pt) = WPts.Rows.Cast(Of DataRow).ToList.ConvertAll(Function(r) New Pt(r("Terminado"), r("Total")))

        Dim WSqls As New List(Of String)

        For Each p As Pt In _Pts

            Dim Pts As New List(Of Pt)
            Dim Mps As New List(Of Mp)

            Pts.Add(p)

            ' Busca la composicion de los PTs que puede llegar a haber y los separa en PTs y MPs.
            Dim WLimite As Short = Pts.Count
            Dim WComienzo As Short = 0

            While WComienzo < WLimite And WComienzo < 5 '200
                Dim pt As Pt = Pts(WComienzo)
                Dim Composicion As DataTable = GetAll("SELECT Tipo, Articulo1 As Articulo, Articulo2 As Terminado, Cantidad FROM Composicion WHERE Terminado = '" & pt.Codigo & "' ORDER BY Renglon")
                For Each row As DataRow In Composicion.Rows
                    If OrDefault(row("Tipo"), "") = "T" Then
                        Pts.Add(New Pt(row("Terminado"), Val(formatonumerico(row("Cantidad"), 5))))
                        WLimite += 1
                    ElseIf OrDefault(row("Tipo"), "") = "M" Then
                        Mps.Add(New Mp(row("Articulo"), Val(formatonumerico(row("Cantidad"), 5))))
                    End If
                Next
                WComienzo += 1
            End While

            ' Suma la cantidad de Kilos de las MPs que sean Sedronar.
            Dim WArts As List(Of Mp) = Mps.FindAll(Function(r) _EsSedronar(r.Codigo))

            ' Calcula el contenido porcentual.
            Dim WKilosComposicion As Double = p.Cantidad

            Dim WKilosTotalSedronar As Double = WArts.Sum(Function(r) r.Cantidad)

            Dim WComposicionPorcentual As Double = (WKilosTotalSedronar / WKilosComposicion) * 100

            WSqls.Add(String.Format("UPDATE Terminado SET PorceSedronar = '{0}' WHERE Codigo = '{1}'", formatonumerico(WComposicionPorcentual), p.Codigo))

            pb.Increment(1)

            gbPb.Text = String.Format("GENERANDO REPORTE - PROCESANDO DATOS {0} de {1}", pb.Value - 1, WPts.Rows.Count)
            gbPb.Refresh()

        Next

        If WSqls.Count > 0 Then

            ExecuteNonQueries(WSqls.ToArray)

        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        pnlPb.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy Then BackgroundWorker1.CancelAsync()

        pnlPb.Visible = False
        gbPb.Text = ""

        txtProducto.Focus()

    End Sub

    Private Sub txtRefLaboratorio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRefLaboratorio.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtRefLaboratorio.Text) = "" Then : Exit Sub : End If

            txtObservaciones.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRefLaboratorio.Text = ""
        End If

    End Sub

    Private Sub txtObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtObservaciones.Text) = "" Then : Exit Sub : End If

            txtControlCambios.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If

    End Sub
End Class

Public Class DatosAdicionales
    Property Producto As String
    Property Version As String
    Property NUnidas As String
    Property Embalaje As String
    Property Clase As String
    Property RSec As String
    Property Riesgo As String
    Property Caracteristicas As String
    Property FIntervencion As String
    Property Carga As Short
    Property Estado As Short
    Property VidaUtil As Short
    Property Restriccion As Boolean

End Class