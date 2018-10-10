Public Class NuevoSac : Implements INuevaAccion

    Private Const YMARGEN = 2
    Private Const XMARGEN = 7
    Private WRow, Wcol As Integer
    
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

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If

    End Sub

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

        dgvAcciones.Rows.Clear()

        For i = 1 To 12
            dgvAcciones.Rows.Add(i, "", "", "", "  /  /    ")
        Next

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

                End With

            End With
        Next

    End Sub

    Private Sub dgvAcciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim WNroAccion = If(dgvAcciones.CurrentRow.Cells("idAccion").Value, "")

        If WNroAccion.ToString.Trim = "" Then Exit Sub

        Dim WAccion As New NuevaAccion(txtTipo.Text, txtAnio.Text, txtNumero.Text, WNroAccion)

        WAccion.Show(Me)

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
End Class