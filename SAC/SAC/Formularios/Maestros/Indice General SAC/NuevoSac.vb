﻿Imports System.Data.SqlClient

Public Class NuevoSac : Implements INuevaAccion, IAyudaContenedor, IAyudaCentroSac, IAyudaReponsableSac, IAyudaTipoSac, IExportarSac

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
            Dim WTipo = txtTipo.Text
            Dim WAnio = txtAnio.Text
            Dim WNumero = txtNumero.Text

            btnLimpiar.PerformClick()

            txtTipo.Text = WTipo
            txtTipo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            txtAnio.Text = WAnio
            txtNumero.Text = WNumero

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

            End If

            txtFecha.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _LimpiarCampos()

        For Each t As Control In {txtCentro, txtEmisor, txtFecha, txtReferencia, txtResponsable, txtTitulo}
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
        Dim WTipo = txtTipo.Text
        Dim WNumero = txtNumero.Text
        Dim WAnio = txtAnio.Text

        btnLimpiar_Click(Nothing, Nothing)

        txtTipo.Text = WTipo
        txtNumero.Text = WNumero
        txtAnio.Text = WAnio

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
                                Dim WResp As DataRow = GetSingle("SELECT LTRIM(RTRIM(Descripcion)) As Descrip FROM ResponsableSac WHERE Codigo = '" & valor & "'")

                                If Not IsNothing(WResp) Then
                                    .Rows(iRow).Cells("DescResponsable").Value = OrDefault(WResp.Item("Descrip"), "")
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
                                .Rows(iRow).Cells("ImpleDescResponsable").Value = _TraerDescripcionResponsable(valor)
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

                    .CurrentCell = .Rows(WRow).Cells("Estado")
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
        If txtTipo.Text.Trim <> "" And txtAnio.Text.Trim <> "" And txtNumero.Text.Trim <> "" Then
            If MsgBox("¿Está seguro de querer salir? Las modificaciones que no se hayan guardado se perderán.", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
        End If

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
        cmbEstado.SelectedIndex = 1
        cmbOrigen.SelectedIndex = 1

        txtAnio.Text = Date.Now.Year
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

        TabControl1.SelectedIndex = 0

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

    Private Function _TraerValorRefEstado(ByVal valor As Object)

        Select Case OrDefault(valor, "")
            Case "Imple."
                Return 1
            Case "Nula"
                Return 2
            Case Else
                Return 0
        End Select

    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand("")
        Dim trans As SqlTransaction = Nothing

        '
        ' Validamos los datos minimos para dar de alta la sac.
        '
        Try
            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            _DatosValidos()

            '
            ' Guardo los datos generales.
            '
            Dim WTipo As String = txtTipo.Text.Trim
            Dim WNumero As String = txtNumero.Text.Trim
            Dim WAnio As String = txtAnio.Text
            Dim WFechaSac As String = txtFecha.Text
            Dim WOrdFechaSac As String = ordenaFecha(txtFecha.Text)
            Dim WOrigen As String = cmbOrigen.SelectedIndex
            Dim WEstado As String = cmbEstado.SelectedIndex
            Dim WTitulo As String = txtTitulo.Text.Trim.Replace("'", "")
            Dim WReferencia As String = txtReferencia.Text.Trim.Replace("'", "")
            Dim WCentro As String = Val(txtCentro.Text)
            Dim WEmisor As String = Val(txtEmisor.Text)
            Dim WResponsable As String = Val(txtResponsable.Text)
            Dim WClave As String = WTipo.PadLeft(4, "0") & WAnio.PadLeft(4, "0") & WNumero.PadLeft(6, "0")

            Dim WNoConformidad As String = txtIngresoNoCon.Text.Trim.Replace("'", "")
            Dim WCausa As String = txtIngresoCausa.Text.Trim.Replace("'", "")

            Dim WSql As String = ""

            '
            ' Grabamos los datos generales. Verificando primero si existe anteriormente el SAC.
            '
            cm.CommandText = String.Format("SELECT Clave FROM CargaSac WHERE Clave = '{0}'", WClave)

            Using dr As SqlDataReader = cm.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    WSql = String.Format("UPDATE CargaSAC SET Fecha = '{3}', OrdFecha = '{12}', Origen = '{4}', Estado = '{5}', " &
                                         " Titulo = '{6}', Referencia = '{7}', Centro = '{8}', ResponsableEmisor = '{9}', ResponsableDestino = '{10}', " &
                                         " IngresoNoCon = '{13}', IngresoCausa = '{14}' " &
                                         " WHERE Clave = '{11}'",
                                         WTipo, WNumero, WAnio, WFechaSac, WOrigen, WEstado, WTitulo, WReferencia, WCentro, WEmisor, WResponsable, WClave, WOrdFechaSac, WNoConformidad, WCausa)
                Else

                    WSql = String.Format("INSERT INTO CargaSAC (Clave, Tipo, Numero, Ano, Fecha, OrdFecha, Origen, Estado, Titulo, Referencia, Centro, ResponsableEmisor, ResponsableDestino, IngresoNoCon, IngresoCausa) " &
                                         " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                                         WClave, WTipo, WNumero, WAnio, WFechaSac, WOrdFechaSac, WOrigen, WEstado, WTitulo, WReferencia, WCentro, WEmisor, WResponsable, WNoConformidad, WCausa)
                End If

            End Using

            'Debug.Print(WSql)

            cm.CommandText = WSql
            cm.ExecuteNonQuery()


            '
            ' Grabamos 'Acciones'
            '
            WSql = String.Format("SELECT Clave FROM CargaSACII WHERE Clave = '{0}'", WClave)
            cm.CommandText = WSql

            Using dr As SqlDataReader = cm.ExecuteReader

                If Not dr.HasRows Then

                    If Not dr.IsClosed Then dr.Close()

                    WSql = "INSERT INTO CargaSacII (Clave) VALUES ('" & WClave & "')"
                    cm.CommandText = WSql
                    cm.ExecuteNonQuery()

                End If

            End Using

            Dim WDatos As String = ""

            For i = 1 To 12

                Dim row As DataGridViewRow = dgvAcciones.Rows(i - 1)

                With row
                    Dim WAccion As String = OrDefault(.Cells("Acciones").Value, "")
                    WAccion = WAccion.Replace("'", "").PadRight(120, " ")
                    Dim WAccionI As String = WAccion.Substring(0, 60)
                    Dim WAccionII As String = WAccion.Substring(60, 60)
                    Dim WResp As String = OrDefault(.Cells("Responsable").Value, "0")
                    Dim WPlazo As String = OrDefault(.Cells("Plazo").Value, "  /  /    ")

                    WDatos &= String.Format(" Accion{0}1 = '{1}', Accion{0}2 = '{2}', Responsable{0} = '{3}', Plazo{0} = '{4}',", i, WAccionI, WAccionII, WResp, WPlazo)

                End With

            Next

            WDatos = WDatos.Remove(WDatos.Length - 1, 1)

            WSql = String.Format("UPDATE CargaSACII SET Tipo = '{2}', Numero = '{3}', Ano = '{4}', {0} WHERE Clave = '{1}'", WDatos, WClave, WTipo, WNumero, WAnio)

            'Debug.Print(WSql)

            cm.CommandText = WSql
            cm.ExecuteNonQuery()


            '
            ' Grabamos Implementaciones.
            '
            WSql = String.Format("SELECT Clave FROM CargaSACIII WHERE Clave = '{0}'", WClave)
            cm.CommandText = WSql

            Using dr As SqlDataReader = cm.ExecuteReader

                If Not dr.HasRows Then

                    If Not dr.IsClosed Then dr.Close()

                    WSql = "INSERT INTO CargaSacIII (Clave) VALUES ('" & WClave & "')"
                    cm.CommandText = WSql
                    cm.ExecuteNonQuery()

                End If

            End Using

            WDatos = ""

            For i = 1 To 12

                Dim row As DataGridViewRow = dgvImplementaciones.Rows(i - 1)

                With row
                    Dim WComentario As String = OrDefault(.Cells("Comentarios").Value, "")
                    WComentario = WComentario.Replace("'", "").PadRight(100, " ")
                    Dim WComentarioI As String = WComentario.Substring(0, 50)
                    Dim WComentarioII As String = WComentario.Substring(50, 50)
                    Dim WResp As String = OrDefault(.Cells("ImpleResponsable").Value, "0")
                    Dim WImpleFecha As String = OrDefault(.Cells("ImpleFecha").Value, "  /  /    ")
                    Dim WImpleEstado As String = _TraerValorRefEstado(.Cells("Estado").Value)

                    WDatos &= String.Format(" Comentario{0}1 = '{1}', Comentario{0}2 = '{2}', Responsable{0} = '{3}', Fecha{0} = '{4}', Estado{0} = '{5}',", i, WComentarioI, WComentarioII, WResp, WImpleFecha, WImpleEstado)

                End With

            Next

            WDatos = WDatos.Remove(WDatos.Length - 1, 1)

            WSql = String.Format("UPDATE CargaSACIII SET Tipo = '{2}', Numero = '{3}', Ano = '{4}', {0} WHERE Clave = '{1}'", WDatos, WClave, WTipo, WNumero, WAnio)

            'Debug.Print(WSql)

            cm.CommandText = WSql
            cm.ExecuteNonQuery()


            '
            ' Grabamos Verificaciones.
            '
            WSql = String.Format("SELECT Clave FROM CargaSACIV WHERE Clave = '{0}'", WClave)
            cm.CommandText = WSql

            Using dr As SqlDataReader = cm.ExecuteReader

                If Not dr.HasRows Then

                    If Not dr.IsClosed Then dr.Close()

                    WSql = "INSERT INTO CargaSacIV (Clave) VALUES ('" & WClave & "')"
                    cm.CommandText = WSql
                    cm.ExecuteNonQuery()

                End If

            End Using

            WDatos = ""

            For i = 1 To 12

                Dim row As DataGridViewRow = dgvVerificaciones.Rows(i - 1)

                With row

                    Dim WRespI As String = OrDefault(.Cells("VerResponsableI").Value, "0")
                    Dim WRespII As String = OrDefault(.Cells("VerResponsableII").Value, "0")
                    Dim WVerFechaI As String = OrDefault(.Cells("VerFechaI").Value, "  /  /    ")
                    Dim WVerFechaII As String = OrDefault(.Cells("VerFechaII").Value, "  /  /    ")
                    Dim WVerEstadoI As String = _TraerValorRefEstado(.Cells("VerEstadoI").Value)
                    Dim WVerEstadoII As String = _TraerValorRefEstado(.Cells("VerEstadoII").Value)
                    Dim WComentario As String = OrDefault(.Cells("VerComentario").Value, "")
                    WComentario = WComentario.Replace("'", "").PadRight(100, " ")
                    Dim WVerComentarioI As String = WComentario.Substring(0, 50)
                    Dim WVerComentarioII As String = WComentario.Substring(50, 50)

                    If i < 7 Then

                        WDatos &= String.Format(" Responsable{0} = '{1}', Responsable1{0} = '{2}', Fecha{0} = '{3}', Fecha1{0} = '{4}', Estado{0} = '{5}', Estado1{0} = '{6}', Comentario{0}1 = '{7}', Comentario{0}2 = '{8}',",
                                                i, WRespI, WRespII, WVerFechaI, WVerFechaII, WVerEstadoI, WVerEstadoII, WVerComentarioI, WVerComentarioII)

                    Else

                        WDatos &= String.Format(" Responsable{0}1 = '{1}', Responsable{0}2 = '{2}', Fecha{0}1 = '{3}', Fecha{0}2 = '{4}', Estado{0}1 = '{5}', Estado{0}2 = '{6}', Comentario{0}1 = '{7}', Comentario{0}2 = '{8}',",
                                                i, WRespI, WRespII, WVerFechaI, WVerFechaII, WVerEstadoI, WVerEstadoII, WVerComentarioI, WVerComentarioII)

                    End If

                End With

            Next

            WDatos = WDatos.Remove(WDatos.Length - 1, 1)

            WSql = String.Format("UPDATE CargaSACIV SET Tipo = '{2}', Numero = '{3}', Ano = '{4}', {0} WHERE Clave = '{1}'", WDatos, WClave, WTipo, WNumero, WAnio)

            'Debug.Print(WSql)

            cm.CommandText = WSql
            cm.ExecuteNonQuery()


            '
            ' Grabamos Comentarios.
            '
            WSql = String.Format("SELECT Clave FROM CargaSACAdicional WHERE Clave = '{0}'", WClave)
            cm.CommandText = WSql

            Using dr As SqlDataReader = cm.ExecuteReader

                If Not dr.HasRows Then

                    If Not dr.IsClosed Then dr.Close()

                    WSql = "INSERT INTO CargaSacAdicional (Clave) VALUES ('" & WClave & "')"
                    cm.CommandText = WSql
                    cm.ExecuteNonQuery()

                End If

            End Using

            WDatos = "Dato1 = '" & txtComentarios.Text.Trim.Replace("'", "") & "'"

            WSql = String.Format("UPDATE CargaSACAdicional SET Tipo = '{2}', Numero = '{3}', Ano = '{4}', {0} WHERE Clave = '{1}'", WDatos, WClave, WTipo, WNumero, WAnio)

            '            Debug.Print(WSql)
            cm.CommandText = WSql
            cm.ExecuteNonQuery()

            trans.Commit()

            MsgBox("Actualización realizada con Éxito", MsgBoxStyle.Information)

            Dim WOwner As INuevoSAC = CType(Owner, INuevoSAC)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoSAC(txtTipo.Text, txtNumero.Text, txtAnio.Text)
                Close()
                Exit Sub
            End If

            btnLimpiar.PerformClick()

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

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

        If cmbEstado.SelectedIndex <= 0 Then
            Throw New Exception("Se debe indicar un Estado de SAC válido.")
        End If

        If cmbOrigen.SelectedIndex <= 0 Then
            Throw New Exception("Se debe indicar un Origen de SAC válido.")
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

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFecha.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If
            If Not _ValidarFecha(txtFecha.Text) Then Exit Sub

            txtCentro.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Sub txtTitulo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitulo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtTitulo.Text) = "" Then : Exit Sub : End If

            txtReferencia.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtTitulo.Text = ""
        End If

    End Sub

    Private Sub txtReferencia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencia.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtReferencia.Text) = "" Then : Exit Sub : End If
            TabControl1.SelectedIndex = 0
            txtIngresoNoCon.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtReferencia.Text = ""
        End If

    End Sub

    Private Sub txtAnio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipo.Leave, txtAnio.Leave
        btnProximoNumeroLibre.Enabled = txtAnio.Text.Trim <> "" And txtTipo.Text.Trim <> ""
    End Sub

    Private Sub btnProximoNumeroLibre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProximoNumeroLibre.Click

        If txtTipo.Text.Trim = "" Or txtAnio.Text.Trim = "" Then
            MsgBox("Se debe definir primero el Tipo de Solicitud y el Año al cual pertenece", MsgBoxStyle.Exclamation)
            txtTipo.Focus()
            Exit Sub
        End If

        If Val(txtNumero.Text) <> 0 Then
            If MsgBox("¿Está seguro de querer traer próximo número libre? Las modificaciones que no se hayan guardado se perderán.", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                txtFecha.Focus()
                Exit Sub
            End If
        End If

        Dim WUltimo As DataRow = GetSingle("SELECT ISNULL(MAX(Numero), 0) Ultimo FROM CargaSac WHERE Tipo = '" & txtTipo.Text & "' AND Ano = '" & txtAnio.Text & "'")

        If Not IsNothing(WUltimo) Then
            txtNumero.Text = WUltimo.Item("Ultimo") + 1
            txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

        txtFecha.Focus()

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            '
            ' Recargamos los datos de la SAC.
            '
            txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            '
            ' Verificamos que exista la SAC.
            '
            Dim WSAC As DataRow = GetSingle("SELECT Clave FROM CargaSAC WHERE Tipo = '" & txtTipo.Text & "' And Ano = '" & txtAnio.Text & "' And Numero = '" & txtNumero.Text & "'")

            If IsNothing(WSAC) Then Exit Sub

            '
            ' Cargamos la carátula y filtramos para el SAC indicado.
            '

            Dim frm As New VistaPrevia
            With frm
                .Reporte = New NuevoSACCaratula
                .Formula = "{CargaSac.Tipo} = " & txtTipo.Text & " And {CargaSac.Numero} = " & txtNumero.Text & " And {CargaSac.Ano} = " & txtAnio.Text & ""
            End With

            _PrepararImpreSacII()

            Dim frm2 As New VistaPrevia
            With frm2
                .Reporte = New NuevoSACAcciones
                .Formula = "{ImpreSacII.Tipo} = " & txtTipo.Text & " And {ImpreSacII.Numero} = " & txtNumero.Text & " And {ImpreSacII.Ano} = " & txtAnio.Text & ""
            End With

            frm.Imprimir()
            frm2.Imprimir()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _PrepararImpreSacII()

        '
        ' Cargamos las Acciones y filtramos para el SAC indicado.
        '
        Dim WNroAccion, WDescAccion, WFechaAccion, WRespAccion, WRespImple, WImpleEstado, WImpleFecha, WImpleComentarios, WDescImpleEstado, WVerRespImple, WVerFechaImple, WVerEstadoImple, WDescEstadoImple, WVerRespEfect, WVerFechaEfect, WVerEstadoEfect, WDescEstadoEfect, WVerComentarios As String

        Dim WSQls As New List(Of String)

        WSQls.Add("DELETE FROM ImpreSACII")

        For i = 1 To 12

            With dgvAcciones.Rows(i - 1)

                WNroAccion = i
                WDescAccion = OrDefault(.Cells("Acciones").Value, "")

                If WDescAccion.Trim = "" Then Continue For

                WFechaAccion = OrDefault(.Cells("Plazo").Value, "  /  /    ")
                WRespAccion = OrDefault(.Cells("Responsable").Value, 0)

            End With

            With dgvImplementaciones.Rows(i - 1)

                WRespImple = OrDefault(.Cells("ImpleResponsable").Value, 0)
                WDescImpleEstado = OrDefault(.Cells("Estado").Value, 0)
                WImpleFecha = OrDefault(.Cells("ImpleFecha").Value, "  /  /    ")
                WImpleComentarios = OrDefault(.Cells("Comentarios").Value, "")
                'WDescImpleEstado = _TraerEstado(WImpleEstado)

            End With

            With dgvVerificaciones.Rows(i - 1)

                WVerRespImple = OrDefault(.Cells("VerResponsableI").Value, 0)
                WVerFechaImple = OrDefault(.Cells("VerFechaI").Value, 0)
                WDescEstadoImple = OrDefault(.Cells("VerEstadoI").Value, 0)
                'WDescEstadoImple = _TraerEstado(WVerEstadoImple)

                WVerRespEfect = OrDefault(.Cells("VerResponsableII").Value, 0)
                WVerFechaEfect = OrDefault(.Cells("VerFechaII").Value, 0)
                WVerEstadoEfect = OrDefault(.Cells("VerEstadoII").Value, 0)
                WDescEstadoEfect = _TraerEstado(WVerEstadoImple)

                WVerComentarios = OrDefault(.Cells("VerComentario").Value, "")

            End With

            Dim WSql As String = ""
            Dim WClave As String = ""

            WClave = txtTipo.Text.PadLeft(4, "0") & txtAnio.Text.PadLeft(4, "0") & txtNumero.Text.PadLeft(6, "0") & i.ToString.PadLeft(2, "0")

            WSql = String.Format("INSERT INTO ImpreSacII (Clave, Renglon, Tipo, Numero, Ano, FechaSac, Accion, DescAccion, RespAccion, FechaAccion, RespImple, FechaImple, DescImpleEstado, ImpleComentarios, VerImpleResp, VerImpleEstado, VerImpleFecha, VerEfecResp, VerEfecEstado, VerEfecFecha, VerComentario) " &
                                 " VALUES " &
                                 " ('{0}', {1}, {2}, {3}, {4}, '{5}', {6}, '{7}', {8}, '{20}', {9}, '{10}', '{11}', '{12}', {13}, '{14}', '{15}', {16}, '{17}', '{18}', '{19}')",
                                 WClave, i, txtTipo.Text, txtNumero.Text, txtAnio.Text, txtFecha.Text, WNroAccion, WDescAccion, WRespAccion, WRespImple, WImpleFecha, WDescEstadoImple, WImpleComentarios, WVerRespImple, WDescEstadoImple, WVerFechaImple, WVerRespEfect, WDescEstadoEfect, WVerFechaEfect, WVerComentarios, WFechaAccion)

            WSQls.Add(WSql)

        Next

        Query.ExecuteNonQueries(WSQls.ToArray())

    End Sub

    Public Sub _ProcesarExportarSac(ByVal WOpcion1 As Boolean, ByVal WOpcion2 As Boolean, ByVal WFormato As Object) Implements IExportarSac._ProcesarExportarSac

        Try
            '
            ' Recargamos los datos de la SAC.
            '
            txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            '
            ' Verificamos que exista la SAC.
            '
            Dim WSAC As DataRow = GetSingle("SELECT Clave FROM CargaSAC WHERE Tipo = '" & txtTipo.Text & "' And Ano = '" & txtAnio.Text & "' And Numero = '" & txtNumero.Text & "'")

            If IsNothing(WSAC) Then Exit Sub

            '
            ' Cargamos la carátula y filtramos para el SAC indicado.
            '

            Dim frm As New VistaPrevia
            With frm
                .Reporte = New NuevoSACCaratula
                .Formula = "{CargaSac.Tipo} = " & txtTipo.Text & " And {CargaSac.Numero} = " & txtNumero.Text & " And {CargaSac.Ano} = " & txtAnio.Text & ""
            End With

            _PrepararImpreSacII()

            Dim frm2 As New VistaPrevia
            With frm2
                .Reporte = New NuevoSACAcciones
                .Formula = "{ImpreSacII.Tipo} = " & txtTipo.Text & " And {ImpreSacII.Numero} = " & txtNumero.Text & " And {ImpreSacII.Ano} = " & txtAnio.Text & ""
            End With

            If WFormato = 3 Then
                '
                ' Exportamos ambos archivos en el caso que corresponda en un archivo temporal.
                '
                Dim WRuta As String = "C:/tSac/"

                If IO.Directory.Exists(WRuta) Then IO.Directory.Delete(WRuta, True)

                IO.Directory.CreateDirectory(WRuta)

                If WOpcion2 Then frm2.Exportar("2.pdf", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, WRuta)
                If WOpcion1 Then frm.Exportar("1.pdf", CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, WRuta)

                Dim WNombreArchivo = String.Format("SAC {0} {1} {2} - {3}.pdf", txtTipo.Text, txtNumero.Text, txtAnio.Text, Date.Now.ToString("dd-MM-yyyy"))

                With VistaPrevia
                    .MergePDFs(WRuta, WNombreArchivo)
                    .EnviarPorEmail(WRuta & WNombreArchivo)
                End With

            ElseIf WOpcion1 And WOpcion2 Then

                With frm
                    .Reporte = New NuevoSACAmbos
                    .Formula = "{CargaSac.Tipo} = " & txtTipo.Text & " And {CargaSac.Numero} = " & txtNumero.Text & " And {CargaSac.Ano} = " & txtAnio.Text & ""
                End With

                _ExportarReporte(frm, WFormato)

            Else

                If WOpcion2 Then _ExportarReporte(frm2, WFormato)
                If WOpcion1 Then _ExportarReporte(frm, WFormato)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _ExportarReporte(ByVal frm2 As VistaPrevia, ByVal WFormato As Object)

        With frm2

            Dim WNombreArchivo = String.Format("SAC {0} {1} {2} - {3}", txtTipo.Text, txtNumero.Text, txtAnio.Text, Date.Now.ToString("dd-MM-yyyy"))

            Select Case WFormato

                Case 0 ' PDF
                    .Exportar(WNombreArchivo, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
                Case 1 ' Excel
                    .Exportar(WNombreArchivo, CrystalDecisions.Shared.ExportFormatType.Excel)
                Case 2 ' Word
                    .Exportar(WNombreArchivo, CrystalDecisions.Shared.ExportFormatType.WordForWindows)
            End Select

        End With
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim frm As New ExportarSAC
        frm.Show(Me)

    End Sub

    Private Sub btnTipoAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoAnterior.Click
        Try
            Dim WAnterior As DataRow = GetSingle("select top 1 Codigo from TipoSac where Codigo < " & Val(txtTipo.Text) & " Order by Codigo DEsc")

            If Not IsNothing(WAnterior) Then
                txtTipo.Text = WAnterior.Item("Codigo")
                txtTipo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnTipoSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoSiguiente.Click
        Try
            Dim WProximo As DataRow = GetSingle("select top 1 Codigo from TipoSac where Codigo > " & Val(txtTipo.Text) & " Order by Codigo")

            If Not IsNothing(WProximo) Then
                txtTipo.Text = WProximo.Item("Codigo")
                txtTipo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnNumeroAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumeroAnterior.Click
        Try
            Dim WAnterior As DataRow = GetSingle("SELECT TOP 1 Numero FROM cargasac WHERE Tipo = '" & txtTipo.Text & "' AND Numero < " & Val(txtNumero.Text) & " AND Ano = '" & txtAnio.Text & "' ORDER BY Numero DESC")

            If Not IsNothing(WAnterior) Then
                txtNumero.Text = WAnterior.Item("Numero")
                txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnNumeroSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumeroSiguiente.Click
        Try
            Dim WProximo As DataRow = GetSingle("SELECT TOP 1 Numero FROM cargasac WHERE Tipo = '" & txtTipo.Text & "' AND Numero > " & Val(txtNumero.Text) & " AND Ano = '" & txtAnio.Text & "' ORDER BY Numero")

            If Not IsNothing(WProximo) Then
                txtNumero.Text = WProximo.Item("Numero")
                txtNumero_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class