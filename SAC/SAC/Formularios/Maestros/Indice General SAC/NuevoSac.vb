﻿Public Class NuevoSac : Implements INuevaAccion, IAyudaContenedor, IAyudaCentroSac, IAyudaReponsableSac, IAyudaTipoSac

    Private Const YMARGEN = 2
    Private Const XMARGEN = 7
    Private WRow, Wcol As Integer
    Private WRefTipoResp As Control

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

    End Sub

    Sub New(ByVal WTipo As Object, ByVal WNumero As Object, ByVal WAnio As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtTipo.Text = WTipo
        txtNumero.Text = WNumero
        txtAnio.Text = WAnio

    End Sub

    Private Sub txtTipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtTipo.Text) = "" Then : Exit Sub : End If

            lblDescTipo.Text = ""

            Dim WTipo As DataRow = GetSingle(String.Format("SELECT Descripcion FROM TipoSac WHERE Codigo = '{0}'", txtTipo.Text))

            If Not IsNothing(WTipo) Then
                lblDescTipo.Text = OrDefault(WTipo.Item("Descripcion"), "")
                txtAnio.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtTipo.Text = ""
        End If

    End Sub

    Private Sub txtAnio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnio.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtAnio.Text) = "" Then : Exit Sub : End If

            txtNumero.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtAnio.Text = ""
        End If

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNumero.Text) = "" Then : Exit Sub : End If

            _CargarDatosGenerales()
            _CargarAcciones()
            _CargarImplementaciones()
            _CargarVerificaciones()
            _CargarComentarios()

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If

    End Sub

    Private Sub _CargarComentarios()

        Dim WComentario As DataRow = GetSingle("SELECT Dato1 FROM CargaSacAdicional WHERE Tipo = '" & txtTipo.Text & "' AND Ano = '" & txtAnio.Text & "' AND Numero = '" & txtNumero.Text & "'")

        txtComentarios.Text = ""

        If Not IsNothing(WComentario) Then
            txtComentarios.Text = OrDefault(WComentario.Item("Dato1"), "")
        End If

        txtComentarios.Text = txtComentarios.Text.Trim

    End Sub

    Private Sub _CargarVerificaciones()

        Dim WVerif As DataRow = GetSingle("SELECT * FROM CargaSacIV WHERE Tipo = '" & txtTipo.Text & "' AND Ano = '" & txtAnio.Text & "' AND Numero = '" & txtNumero.Text & "'")

        If Not IsNothing(WVerif) Then
            For i = 1 To 12

                Dim WRespI, WDescRespI, WRespII, WDescRespII, WFechaI, WFechaII, WEstadoI, WEstadoII, WComentario

                With WVerif

                    If i < 7 Then

                        WRespI = OrDefault(.Item("Responsable" & i), 0)
                        WDescRespI = _TraerDescripcionResponsable(WRespI)
                        WRespII = OrDefault(.Item("Responsable1" & i), 0)
                        WDescRespII = _TraerDescripcionResponsable(WRespII)
                        WFechaI = OrDefault(.Item("Fecha" & i), "  /  /    ")
                        WFechaII = OrDefault(.Item("Fecha1" & i), "  /  /    ")
                        WEstadoI = _TraerEstado(.Item("Estado" & i))
                        WEstadoII = _TraerEstado(.Item("Estado1" & i))
                        WComentario = OrDefault(.Item("Comentario" & i & "1"), "").ToString.Trim & " " & OrDefault(.Item("Comentario" & i & "2"), "").ToString.Trim

                    Else

                        WRespI = OrDefault(.Item("Responsable" & i & "1"), 0)
                        WDescRespI = _TraerDescripcionResponsable(WRespI)
                        WRespII = OrDefault(.Item("Responsable" & i & "2"), 0)
                        WDescRespII = _TraerDescripcionResponsable(WRespII)
                        WFechaI = OrDefault(.Item("Fecha" & i & "1"), "  /  /    ")
                        WFechaII = OrDefault(.Item("Fecha" & i & "2"), "  /  /    ")
                        WEstadoI = _TraerEstado(.Item("Estado" & i & "1"))
                        WEstadoII = _TraerEstado(.Item("Estado" & i & "1"))
                        WComentario = OrDefault(.Item("Comentario" & i & "1"), "").ToString.Trim & " " & OrDefault(.Item("Comentario" & i & "2"), "").ToString.Trim

                    End If

                End With

                With dgvVerificaciones.Rows(i - 1)

                    .Cells("VerResponsableI").Value = WRespI
                    .Cells("VerResponsableII").Value = WRespII
                    .Cells("VerDescResponsableI").Value = WDescRespI
                    .Cells("VerDescResponsableII").Value = WDescRespII
                    .Cells("VerEstadoI").Value = WEstadoI
                    .Cells("VerEstadoII").Value = WEstadoII
                    .Cells("VerFechaI").Value = WFechaI
                    .Cells("VerFechaII").Value = WFechaII
                    .Cells("VerComentario").Value = WComentario

                End With
            Next
        End If

    End Sub

    Private Sub _CargarImplementaciones()
        Try

            Dim WImple As DataRow = GetSingle(String.Format("SELECT * FROM CargaSacIII WHERE Tipo = '{0}' And Numero = '{1}' And Ano = '{2}'", txtTipo.Text, txtNumero.Text, txtAnio.Text))

            If Not IsNothing(WImple) Then
                For i = 1 To 12
                    With dgvImplementaciones.Rows(i - 1)

                        .Cells("ImpleResponsable").Value = OrDefault(WImple.Item("Responsable" & i), 0)
                        .Cells("ImpleDescResponsable").Value = _TraerDescripcionResponsable(.Cells("ImpleResponsable").Value)
                        .Cells("Estado").Value = _TraerEstado(WImple.Item("Estado" & i))
                        .Cells("Comentarios").Value = Trim(OrDefault(WImple.Item("Comentario" & i & "1"), "")) & Trim(OrDefault(WImple.Item("Comentario" & i & "2"), ""))
                        .Cells("ImpleFecha").Value = OrDefault(WImple.Item("Fecha" & i), "  /  /    ")

                    End With
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function _TraerEstado(ByVal item As Object) As Object

        Select Case OrDefault(item, 0)
            Case 1
                Return "Imple."
            Case 2
                Return "Nula"
            Case Else
                Return ""
        End Select

    End Function

    Private Function _TraerDescripcionResponsable(ByVal value As Object) As Object

        If Not IsNothing(value) AndAlso value.ToString.Trim <> "" Then
            Dim WResp As DataRow = GetSingle("SELECT LTRIM(RTRIM(Descripcion)) As Descripcion FROM ResponsableSac WHERE Codigo = '" & value & "'")

            If Not IsNothing(WResp) Then
                Return OrDefault(WResp.Item("Descripcion"), "")
            End If

        End If

        Return ""

    End Function

    Private Sub _CargarDatosGenerales()
        Try
            Dim WDatos As DataRow = GetSingle(String.Format("SELECT * FROM CargaSAC WHERe Tipo = '{0}' And Numero = '{1}' And Ano = '{2}'", txtTipo.Text, txtNumero.Text, txtAnio.Text))

            If Not IsNothing(WDatos) Then
                With WDatos

                    txtFecha.Text = OrDefault(.Item("Fecha"), "")
                    txtCentro.Text = OrDefault(.Item("Centro"), "")
                    txtEmisor.Text = OrDefault(.Item("ResponsableEmisor"), "")
                    txtResponsable.Text = OrDefault(.Item("ResponsableDestino"), "")
                    txtTitulo.Text = OrDefault(.Item("Titulo"), "")
                    txtReferencia.Text = OrDefault(.Item("Referencia"), "")
                    txtIngresoNoCon.Text = OrDefault(.Item("IngresoNoCon"), "")
                    txtIngresoCausa.Text = OrDefault(.Item("IngresoCausa"), "")
                    cmbEstado.SelectedIndex = OrDefault(.Item("Estado"), 0)
                    cmbOrigen.SelectedIndex = OrDefault(.Item("Origen"), 0)

                    txtCentro_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txtTipo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txtEmisor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txtResponsable_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

                    For Each o As Control In {txtFecha, txtCentro, txtEmisor, txtResponsable, txtTitulo, txtReferencia, txtIngresoNoCon, txtIngresoCausa}
                        o.Text = o.Text.Trim
                    Next

                End With

                txtFecha.Focus()
            Else
                _LimpiarCampos()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _LimpiarCampos()

        For Each t As TextBox In {txtCentro, txtEmisor, txtFecha, txtReferencia, txtResponsable, txtTitulo}
            t.Text = ""
        Next

        cmbEstado.SelectedIndex = 0
        cmbOrigen.SelectedIndex = 0

        For Each l As Label In {lblDescCentro, lblDescEmisor, lblDescResponsable}
            l.Text = ""
        Next

    End Sub

    Private Sub _LimpiarTodo()
        For Each c As Control In {txtTipo, txtNumero, txtAnio, lblDescTipo}
            c.Text = ""
        Next

        _LimpiarCampos()

        txtTipo.Focus()

    End Sub

    Private Sub _CargarAcciones()

        _LimpiarGrillaAcciones()

        _LimpiarGrillaImplementaciones()

        _LimpiarGrillaVerificaciones()

        dgvVerificaciones.Columns("VerAcciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Dim WCargaSacII As DataRow = Query.GetSingle(String.Format("SELECT * FROM CargaSACII WHERE Tipo = '{0}' AND Numero = '{1}' AND Ano = '{2}'", txtTipo.Text, txtNumero.Text, txtAnio.Text))

        If IsNothing(WCargaSacII) Then Exit Sub

        For i = 1 To 12
            With WCargaSacII

                Dim WAccionI As String = OrDefault(.Item("Accion" & i & "1"), "")
                Dim WAccionII As String = OrDefault(.Item("Accion" & i & "2"), "")
                Dim WResponsable As String = OrDefault(.Item("Responsable" & i), "")
                Dim WPlazo As String = OrDefault(.Item("Plazo" & i), "  /  /    ")

                With dgvAcciones.Rows(i - 1)

                    .Cells("Acciones").Value = WAccionI.Trim & " " & WAccionII.Trim
                    .Cells("Plazo").Value = WPlazo
                    .Cells("idAccion").Value = i

                    Dim WResp As DataRow = GetSingle("SELECT Descripcion FROM ResponsableSac WHERE Codigo = '" & WResponsable & "'")

                    If IsNothing(WResp) Then Continue For

                    Dim WDescResp As String = OrDefault(WResp.Item("Descripcion"), "")

                    .Cells("Responsable").Value = WResponsable
                    .Cells("DescResponsable").Value = WDescResp.Trim

                    dgvImplementaciones.Rows(i - 1).Cells("ImpleAcciones").Value = .Cells("Acciones").Value
                    dgvVerificaciones.Rows(i - 1).Cells("VerAcciones").Value = .Cells("Acciones").Value

                    dgvVerificaciones.Columns("VerAcciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                End With

            End With
        Next

    End Sub

    Private Sub _LimpiarGrillaAcciones()

        dgvAcciones.Rows.Clear()

        For i = 1 To 12
            dgvAcciones.Rows.Add(i, "", "", "", "  /  /    ")
        Next

    End Sub

    Private Sub _LimpiarGrillaImplementaciones()

        dgvImplementaciones.Rows.Clear()

        For i = 1 To 12
            dgvImplementaciones.Rows.Add(i, "", "", "", "  /  /    ")
        Next

    End Sub

    Private Sub _LimpiarGrillaVerificaciones()

        dgvVerificaciones.Rows.Clear()

        For i = 1 To 12
            dgvVerificaciones.Rows.Add(i, "", "", "", "  /  /    ", "", "", "", "  /  /    ", "", "")
        Next

    End Sub

    Public Sub _ProcesarNuevaAccion() Implements INuevaAccion._ProcesarNuevaAccion
        _CargarAcciones()
    End Sub

    Private Sub NuevoSac_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtTipo.Focus()
    End Sub

    Private Sub txtCentro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCentro.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCentro.Text) = "" Then : Exit Sub : End If

            lblDescCentro.Text = ""

            Dim WCentro As DataRow = GetSingle(String.Format("SELECT Descripcion FROM CentroSac WHERE Codigo = '{0}'", txtCentro.Text))

            If Not IsNothing(WCentro) Then

                lblDescCentro.Text = OrDefault(WCentro.Item("Descripcion"), "")

                txtEmisor.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCentro.Text = ""
        End If

    End Sub

    Private Sub txtEmisor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmisor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtEmisor.Text) = "" Then : Exit Sub : End If

            lblDescEmisor.Text = ""

            Dim WEmisor As DataRow = GetSingle(String.Format("SELECT Descripcion FROM ResponsableSac WHERE Codigo = '{0}'", txtEmisor.Text))

            If Not IsNothing(WEmisor) Then

                lblDescEmisor.Text = OrDefault(WEmisor.Item("Descripcion"), "")

                txtResponsable.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtEmisor.Text = ""
        End If

    End Sub

    Private Sub txtResponsable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtResponsable.Text) = "" Then : Exit Sub : End If

            lblDescResponsable.Text = ""

            Dim WResp As DataRow = GetSingle(String.Format("SELECT Descripcion FROM ResponsableSac WHERE Codigo = '{0}'", txtResponsable.Text))

            If Not IsNothing(WResp) Then

                lblDescResponsable.Text = OrDefault(WResp.Item("Descripcion"), "")

                txtTitulo.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtResponsable.Text = ""
        End If

    End Sub

    Private Sub NuevoSac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        With dgvVerificaciones

            For Each column As DataGridViewColumn In .Columns
                column.HeaderCell.Style.BackColor = Color.White
            Next

            For Each s As String In {"VerResponsableI", "VerDescResponsableI", "VerFechaI", "VerEstadoI"}
                .Columns(s).HeaderCell.Style.BackColor = Color.Orange
                .Columns(s).HeaderCell.Style.ForeColor = Color.White
            Next

            For Each s As String In {"VerResponsableII", "VerDescResponsableII", "VerFechaII", "VerEstadoII"}
                .Columns(s).HeaderCell.Style.BackColor = Color.Green
                .Columns(s).HeaderCell.Style.ForeColor = Color.White
            Next

            .EnableHeadersVisualStyles = False

        End With
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

        With dgvAcciones
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 2
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case -1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    '
                    ' Control de Valores.
                    '

                    Select Case iCol

                        Case 1
                            '
                            ' Mantengo actualizadas las filas entre las diferentes grillas.
                            '
                            Dim WId = .Rows(iRow).Cells("idAccion").Value
                            dgvImplementaciones.Rows(iRow).Cells("ImpleAcciones").Value = valor
                            dgvVerificaciones.Rows(iRow).Cells("VerAcciones").Value = valor

                            If valor.Trim <> "" Then
                                dgvVerificaciones.Columns("VerAcciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                            End If

                        Case 2

                            If Val(valor) <> 0 Then
                                Dim WResp As DataRow = GetSingle("SELECT LTRIM(RTRIM(Descripcion)) As Desc FROM ResponsableSac WHERE Codigo = '" & valor & "'")

                                If Not IsNothing(WResp) Then
                                    .Rows(iRow).Cells("DescResponsable").Value = OrDefault(WResp.Item("Desc"), "")
                                End If

                            End If
                        Case 4

                            If valor.Replace(" ", "").Length = 10 Then
                                If Not _ValidarFecha(valor) Then
                                    Return True
                                End If
                            End If

                    End Select


                    '
                    ' Navegación.
                    '
                    Select Case iCol
                        Case 2
                            .CurrentCell = .Rows(iRow).Cells("Plazo")
                        Case 4
                            If iRow = .Rows.Count - 1 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                .CurrentCell = .Rows(iRow + 1).Cells("Acciones")
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

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

        With dgvImplementaciones
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 2
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case -1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    '
                    ' Control de Valores.
                    '
                    Select Case iCol

                        Case 2

                            If Val(valor) <> 0 Then
                                .Rows(iRow).Cells("DescResponsable").Value = _TraerDescripcionResponsable(valor)
                            End If

                        Case 4

                            If valor.Replace(" ", "").Length = 10 Then
                                If Not _ValidarFecha(valor) Then
                                    Return True
                                End If
                            End If

                    End Select


                    '
                    ' Navegación.
                    '
                    Select Case iCol
                        Case 2
                            .CurrentCell = .Rows(iRow).Cells("ImpleFecha")
                        Case 6
                            If iRow = .Rows.Count - 1 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                .CurrentCell = .Rows(iRow + 1).Cells("ImpleResponsable")
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 6 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        With dgvVerificaciones
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    Case 2, 6
                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If
                    Case -1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    '
                    ' Control de Valores.
                    '
                    Select Case iCol

                        Case 2, 6

                            If Val(valor) <> 0 Then
                                .Rows(iRow).Cells(iCol + 1).Value = _TraerDescripcionResponsable(valor)
                            End If

                        Case 4, 8

                            If valor.Replace(" ", "").Length = 10 Then
                                If Not _ValidarFecha(valor) Then
                                    Return True
                                End If
                            End If

                    End Select


                    '
                    ' Navegación.
                    '
                    Select Case iCol
                        Case 2, 6
                            .CurrentCell = .Rows(iRow).Cells(iCol + 2)
                        Case 10
                            If iRow = .Rows.Count - 1 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                .CurrentCell = .Rows(iRow + 1).Cells("VerResponsableI")
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 10 Then
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

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaAux.Text.Replace(" ", "").Length = 10 Then
                If Not _ValidarFecha(Trim(txtFechaAux.Text)) Then
                    Exit Sub
                End If
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvAcciones
                    .Rows(WRow).Cells("Plazo").Value = txtFechaAux.Text

                    .CurrentCell = IIf(WRow = .Rows.Count - 1, .Rows(WRow).Cells("Plazo"), .Rows(WRow + 1).Cells("Acciones"))
                    .Focus()

                    txtFechaAux.Visible = False
                    txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub dgvAcciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAcciones.CellEnter
        With dgvAcciones
            If e.ColumnIndex = .Columns("Plazo").Index Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells("Plazo").Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub

    Private Sub dgvAcciones_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAcciones.RowHeaderMouseDoubleClick

        Try

            If MsgBox("¿Esta seguro de querer borrar la acción indicada?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            With dgvAcciones.CurrentRow
                .Cells("Acciones").Value = ""
                .Cells("Responsable").Value = ""
                .Cells("DescResponsable").Value = ""
                .Cells("Plazo").Value = "  /  /    "
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txtFechaAux2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux2.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaAux2.Text.Replace(" ", "").Length = 10 Then
                If Not _ValidarFecha(Trim(txtFechaAux2.Text)) Then
                    Exit Sub
                End If
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvImplementaciones
                    .Rows(WRow).Cells("ImpleFecha").Value = txtFechaAux2.Text

                    .CurrentCell = IIf(WRow = .Rows.Count - 1, .Rows(WRow).Cells("ImpleFecha"), .Rows(WRow + 1).Cells("ImpleAcciones"))
                    .Focus()

                    txtFechaAux2.Visible = False
                    txtFechaAux2.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux2.Text = ""
        End If

    End Sub

    Private Sub dgvImplementaciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImplementaciones.CellEnter
        With dgvImplementaciones
            If e.ColumnIndex = .Columns("ImpleFecha").Index Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux2.Size.Width) - XMARGEN
                txtFechaAux2.Location = _location
                txtFechaAux2.Text = .Rows(e.RowIndex).Cells("ImpleFecha").Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux2.Visible = True
                txtFechaAux2.Focus()
            End If
        End With
    End Sub

    Private Sub dgvImplementaciones_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvImplementaciones.RowHeaderMouseDoubleClick

        Try

            If MsgBox("¿Esta seguro de querer borrar la implementación indicada?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            With dgvImplementaciones.CurrentRow
                .Cells("ImpleResponsable").Value = ""
                .Cells("ImpleDescResponsable").Value = ""
                .Cells("ImpleFecha").Value = "  /  /    "
                .Cells("Estado").Value = ""
                .Cells("Comentarios").Value = ""
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub MovilizarInmovilizarAccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovilizarInmovilizarAccionesToolStripMenuItem.Click

        If btnInmovilizarAcciones.Text = "Movilizar" Then

            For Each column As DataGridViewColumn In dgvVerificaciones.Columns
                column.Frozen = False
            Next

            btnInmovilizarAcciones.Text = "Inmovilizar"

        Else
            Dim WSeleccionados As Integer = 0
            Dim WAnt As Integer = 0

            For Each cell As DataGridViewCell In dgvVerificaciones.SelectedCells
                If WAnt <> cell.ColumnIndex Then
                    WAnt = cell.ColumnIndex
                    WSeleccionados += 1
                End If
            Next

            If WSeleccionados = 1 Then

                Dim WIndex As Integer = dgvVerificaciones.SelectedCells(0).ColumnIndex

                dgvVerificaciones.Columns(WIndex).Frozen = Not dgvVerificaciones.Columns(WIndex).Frozen

                For i = WIndex - 1 To 0 Step -1
                    dgvVerificaciones.Columns(i).Frozen = dgvVerificaciones.Columns(WIndex).Frozen
                Next

                btnInmovilizarAcciones.Text = IIf(dgvVerificaciones.Columns("VerAcciones").Frozen, "Movilizar", "Inmovilizar")

            End If
        End If
        dgvVerificaciones.ClearSelection()
    End Sub

    Private Sub btnInmovilizarAcciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInmovilizarAcciones.Click
        MovilizarInmovilizarAccionesToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub txtFechaAux3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux3.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaAux3.Text.Replace(" ", "").Length = 10 Then
                If Not _ValidarFecha(Trim(txtFechaAux3.Text)) Then
                    Exit Sub
                End If
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvVerificaciones
                    .Rows(WRow).Cells("VerFechaI").Value = txtFechaAux3.Text

                    .CurrentCell = IIf(WRow = .Rows.Count - 1, .Rows(WRow).Cells("VerFechaI"), .Rows(WRow).Cells("VerEstadoI"))
                    .Focus()

                    txtFechaAux3.Visible = False
                    txtFechaAux3.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux3.Text = ""
        End If

    End Sub

    Private Sub dgvVerificaciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVerificaciones.CellEnter
        With dgvVerificaciones
            Dim WControl As Control = IIf(e.ColumnIndex = .Columns("VerFechaI").Index, txtFechaAux3, txtFechaAux4)

            If e.ColumnIndex = .Columns("VerFechaI").Index Or e.ColumnIndex = .Columns("VerFechaII").Index Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - WControl.Size.Width) - XMARGEN
                WControl.Location = _location
                WControl.Text = .Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                WControl.Visible = True
                WControl.Focus()
            End If
        End With
    End Sub

    Private Sub txtFechaAux4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux4.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaAux4.Text.Replace(" ", "").Length = 10 Then
                If Not _ValidarFecha(Trim(txtFechaAux4.Text)) Then
                    Exit Sub
                End If
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvVerificaciones
                    .Rows(WRow).Cells("VerFechaII").Value = txtFechaAux4.Text

                    .CurrentCell = IIf(WRow = .Rows.Count - 1, .Rows(WRow).Cells("VerFechaII"), .Rows(WRow).Cells("VerEstadoII"))
                    .Focus()

                    txtFechaAux4.Visible = False
                    txtFechaAux4.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux4.Text = ""
        End If

    End Sub

    Private Sub dgvAcciones_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAcciones.CellLeave
        Dim WValor As String = If(dgvAcciones.Rows(e.RowIndex).Cells("Acciones").Value, "")

        dgvImplementaciones.Rows(e.RowIndex).Cells("ImpleAcciones").Value = WValor
        dgvVerificaciones.Rows(e.RowIndex).Cells("VerAcciones").Value = WValor

        If WValor.Trim <> "" Then
            dgvVerificaciones.Columns("VerAcciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End If
    End Sub

    Private Sub dgvVerificaciones_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvVerificaciones.ColumnHeaderMouseClick
        For i = 0 To 11
            dgvVerificaciones.Rows(i).Cells(e.ColumnIndex).Selected = True
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Está seguro de querer salir? Las modificaciones que no se hayan guardado se perderán.", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        '
        ' Limpiamos Campos.
        '
        For Each c As Control In {txtAnio, txtCentro, txtComentarios, txtEmisor, txtFecha, txtFechaAux, txtFechaAux2, txtFechaAux3, txtFechaAux4, txtIngresoCausa, txtIngresoNoCon, txtNumero, txtReferencia, txtResponsable, txtTipo, txtTitulo, _
                                  lblDescCentro, lblDescEmisor, lblDescResponsable, lblDescTipo}
            c.Text = ""
        Next

        '
        ' Limpiamos las grillas.
        '
        _LimpiarGrillaAcciones()
        _LimpiarGrillaImplementaciones()
        _LimpiarGrillaVerificaciones()

        '
        ' Reseteamos Combos.
        '
        cmbEstado.SelectedIndex = 0
        cmbOrigen.SelectedIndex = 0

        txtTipo.Focus()
    End Sub

    Public Sub _ProcesarAyudaContenedor(ByVal WIndice As Integer) Implements IAyudaContenedor._ProcesarAyudaContenedor

        Select Case WIndice
            Case 0
                Dim frm As New AyudaTipoSac()
                _Centrar(frm)
                frm.Show(Me)

            Case 1
                Dim frm As New AyudaCentrosSac()
                _Centrar(frm)
                frm.Show(Me)

            Case 2, 3
                WRefTipoResp = IIf(WIndice = 2, txtEmisor, txtResponsable)
                Dim frm As New AyudaResponsablesSac()
                _Centrar(frm)
                frm.Show(Me)

        End Select

    End Sub

    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click
        Dim frm As New AyudaContenedor("Tipo de Sac", "Centro SAC", "Emisor", "Responsable")
        _Centrar(frm)
        frm.Show(Me)
    End Sub

    Private Sub _Centrar(ByRef frm As Form)
        frm.StartPosition = FormStartPosition.Manual
        frm.Location = New Point(Me.Location.X + frm.Width * 0.5, Me.Location.Y + frm.Height * 0.5)
    End Sub

    Public Sub _ProcesarAyudaCentroSac(ByVal WCodigo As String) Implements IAyudaCentroSac._ProcesarAyudaCentroSac
        txtCentro.Text = WCodigo
        txtCentro_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Public Sub _ProcesarAyudaResponsableSac(ByVal WCodigo As String) Implements IAyudaReponsableSac._ProcesarAyudaResponsableSac
        If Not IsNothing(WRefTipoResp) Then
            WRefTipoResp.Text = WCodigo
            txtEmisor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            txtResponsable_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If
    End Sub

    Public Sub _ProcesarAyudaTipoSac(ByVal WCodigo As String) Implements IAyudaTipoSac._ProcesarAyudaTipoSac
        txtTipo.Text = WCodigo
        txtTipo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        '
        ' Validamos los datos minimos para dar de alta la sac.
        '
        Try

            _DatosValidos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _DatosValidos()

        If txtTipo.Text.Trim = "" OrElse Not _ExisteTipoSac() Then
            Throw New Exception("Se debe indicar un Tipo de Solicitud de SAC válido.")
        End If

        If txtAnio.Text.Trim.Length < 4 Then
            Throw New Exception("Se debe indicar un Año válido.")
        End If

        If Val(txtNumero.Text.Trim) = 0 Then
            Throw New Exception("Se debe indicar un Número de SAC válido.")
        End If

        If txtFecha.Text.Replace(" ", "").Length < 10 OrElse Not _ValidarFecha(txtFecha.Text) Then
            Throw New Exception("Se debe indicar una Fecha de Emisión válida.")
        End If

        '
        ' Validamos centro, emisor y responsable en caso de haber un dato cargado.
        '
        If Val(txtCentro.Text) > 0 Then
            Dim WCentro As DataRow = GetSingle("SELECT Codigo FROM CentroSac WHERE Codigo = '" & txtCentro.Text & "'")
            If IsNothing(WCentro) Then
                Throw New Exception("Se debe indicar un Centro válido.")
            End If
        End If

        If Val(txtEmisor.Text) > 0 Then
            Dim WResp As DataRow = GetSingle("SELECT Codigo FROM ResponsableSac WHERE Codigo = '" & txtEmisor.Text & "'")
            If IsNothing(WResp) Then
                Throw New Exception("Se debe indicar un Emisor válido.")
            End If
        End If

        If Val(txtResponsable.Text) > 0 Then
            Dim WResp As DataRow = GetSingle("SELECT Codigo FROM ResponsableSac WHERE Codigo = '" & txtResponsable.Text & "'")
            If IsNothing(WResp) Then
                Throw New Exception("Se debe indicar un Responsable válido.")
            End If
        End If

    End Sub

    Private Function _ExisteTipoSac() As Boolean
        Dim WTipo As DataRow = GetSingle("SELECT Codigo FROM TipoSAC WHERE Codigo = '" & txtTipo.Text & "'")

        Return Not IsNothing(WTipo)

    End Function
End Class