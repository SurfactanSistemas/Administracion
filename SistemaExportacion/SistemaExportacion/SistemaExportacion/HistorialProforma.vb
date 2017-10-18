Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop

Public Class HistorialProforma

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 6
    Private Const EXTENSIONES_PERMITIDAS = "*.docx|*.doc|*.xls|*.xlsx|*.xlsm|*.pdf|*.bmp|*.png|*.jpg|*.jpeg|*.ico|*.txt"
    Private TIPO_ESPECIFICACIONES() As String = {"", "Envase", "Entrega", "Varios"}

    Private _NroProforma As String

    Public Property NroProforma() As String
        Get
            Return _NroProforma
        End Get
        Set(ByVal value As String)
            _NroProforma = value
        End Set
    End Property

    Private Sub HistorialProforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsNothing(Me.NroProforma) Then
            Try
                _LimpiarTodo()

                txtNroProforma.Text = Helper.ceros(Me.NroProforma, 6)

                _TraerHistorialYArchivos()

                TabControl1.SelectTab(0)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Me.Close()
            End Try
        End If

        txtFechaAux.Visible = False

        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

        WRow = -1
        Wcol = -1

    End Sub

    Private Sub HistorialProforma_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtNroProforma.Focus()
    End Sub

    Private Function _CS()
        Return Helper._ConectarA()
    End Function

    Private Sub _LimpiarTodo()

        dgvArchivos.Rows.Clear()
        dgvHistorial.Rows.Clear()
        txtCliente.Text = ""
        txtDescripcionCliente.Text = ""
        txtNroProforma.Text = ""

        TabControl1.SelectTab(0)
        txtNroProforma.Focus()

    End Sub

    Private Sub _MostrarHistorial()
        'If IsNothing(Me.Proforma) Then : Exit Sub : End If

        GrupoNuevaObs.Visible = False

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WClave, WFecha, WFechaOrd, WNroObservacion, WNroObsAnt, WObservacion, WUsuario, XRenglon, ZSql, WRefPrimeraFilaObs

        ZSql = ""
        ZSql &= "SELECT DISTINCT h.Clave, h.NroObservacion, h.Renglon, h.Fecha, h.FechaOrd, h.Usuario, h.Observaciones, p.Cliente, c.Razon"
        ZSql &= " FROM ProformaExportacionHistorial as h, ProformaExportacion as p, Cliente as c"
        ZSql &= " WHERE h.Proforma = '" & txtNroProforma.Text & "' AND p.Proforma = h.Proforma AND c.Cliente = p.Cliente ORDER BY h.FechaOrd, h.NroObservacion, h.Renglon"

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.CommandText = ZSql
            cm.Connection = cn

            dr = cm.ExecuteReader()

            btnLimpiar.PerformClick()

            dgvHistorial.Rows.Clear()

            If dr.HasRows Then



                WRefPrimeraFilaObs = 0
                WNroObsAnt = -1

                Do While dr.Read()

                    WClave = ""
                    WFecha = ""
                    WFechaOrd = 0
                    WObservacion = ""
                    WUsuario = ""
                    WNroObservacion = 0

                    txtCliente.Text = IIf(IsDBNull(dr.Item("Cliente")), "", dr.Item("Cliente"))
                    txtDescripcionCliente.Text = IIf(IsDBNull(dr.Item("Razon")), "", dr.Item("Razon"))

                    XRenglon = dgvHistorial.Rows.Add

                    WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))
                    WNroObservacion = IIf(IsDBNull(dr.Item("NroObservacion")), 0, dr.Item("NroObservacion"))
                    WFechaOrd = IIf(IsDBNull(dr.Item("FechaOrd")), "", dr.Item("FechaOrd"))
                    WObservacion = IIf(IsDBNull(dr.Item("Observaciones")), "", dr.Item("Observaciones"))
                    WClave = IIf(IsDBNull(dr.Item("Clave")), "", dr.Item("Clave"))
                    WUsuario = IIf(IsDBNull(dr.Item("Usuario")), "", dr.Item("Usuario"))

                    With dgvHistorial.Rows(XRenglon)

                        .Cells("Fecha").Value = WFecha
                        .Cells("FechaOrd").Value = WFechaOrd
                        .Cells("Clave").Value = WClave
                        .Cells("Observacion").Value = Trim(WObservacion)
                        .Cells("Usuario").Value = Trim(WUsuario)
                        '.Cells("NroObservacion").Value = WNroObservacion

                        If WNroObservacion = WNroObsAnt Then

                            If WNroObservacion & WRefPrimeraFilaObs = dgvHistorial.Rows(XRenglon - 1).Cells("NroObservacion").Value Then
                                .Cells("Fecha").Value = ""
                                .Cells("Usuario").Value = ""
                            End If

                            .Cells("NroObservacion").Value = WNroObservacion & WRefPrimeraFilaObs
                        Else
                            WNroObsAnt = WNroObservacion
                            WRefPrimeraFilaObs = Helper.ceros(XRenglon, 4)
                            .Cells("NroObservacion").Value = WNroObservacion & WRefPrimeraFilaObs
                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _MostrarEspecificaciones()
        'If IsNothing(Me.Proforma) Then : Exit Sub : End If

        GrupoNuevaObs.Visible = False

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim auxi = 0
        Dim WClave, WFecha, WFechaOrd, WNroEspecificacion, WNroObsAnt, WEspecificacion, WUsuario, XRenglon, ZSql, WRefPrimeraFilaEsp, WRenglon, WTipoEsp

        ZSql = ""
        ZSql &= "SELECT DISTINCT e.Clave, e.NroEspecificacion, e.Renglon, e.Fecha, e.FechaOrd, e.Usuario, e.Especificacion, e.Tipo"
        ZSql &= " FROM ProformaExportacionEspecificaciones as e"
        ZSql &= " WHERE e.Proforma = '" & txtNroProforma.Text & "' ORDER BY e.FechaOrd, e.NroEspecificacion, e.Renglon"

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.CommandText = ZSql
            cm.Connection = cn

            dr = cm.ExecuteReader()

            btnLimpiar.PerformClick()

            dgvEspecificaciones.Rows.Clear()

            If dr.HasRows Then



                WRefPrimeraFilaEsp = 0
                WNroObsAnt = -1

                Do While dr.Read()

                    WClave = ""
                    WFecha = ""
                    WFechaOrd = 0
                    WEspecificacion = ""
                    WUsuario = ""
                    WRenglon = ""
                    WNroEspecificacion = 0
                    WTipoEsp = 0

                    'txtCliente.Text = IIf(IsDBNull(dr.Item("Cliente")), "", dr.Item("Cliente"))
                    'txtDescripcionCliente.Text = IIf(IsDBNull(dr.Item("Razon")), "", dr.Item("Razon"))

                    XRenglon = dgvEspecificaciones.Rows.Add

                    WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))
                    WNroEspecificacion = IIf(IsDBNull(dr.Item("NroEspecificacion")), 0, dr.Item("NroEspecificacion"))
                    WFechaOrd = IIf(IsDBNull(dr.Item("FechaOrd")), "", dr.Item("FechaOrd"))
                    WEspecificacion = IIf(IsDBNull(dr.Item("Especificacion")), "", dr.Item("Especificacion"))
                    WClave = IIf(IsDBNull(dr.Item("Clave")), "", dr.Item("Clave"))
                    WRenglon = IIf(IsDBNull(dr.Item("Renglon")), "", dr.Item("Renglon"))
                    WUsuario = IIf(IsDBNull(dr.Item("Usuario")), "", dr.Item("Usuario"))
                    WTipoEsp = IIf(IsDBNull(dr.Item("Tipo")), 0, Val(dr.Item("Tipo")))

                    With dgvEspecificaciones.Rows(XRenglon)

                        .Cells("FechaEspecificacion").Value = WFecha
                        '.Cells("FechaOrd").Value = WFechaOrd
                        .Cells("NroEspecificacion").Value = WNroEspecificacion
                        .Cells("Especificacion").Value = Trim(WEspecificacion)
                        .Cells("UsuarioEspecificacion").Value = Trim(WUsuario)
                        '.Cells("NroObservacion").Value = WNroObservacion
                        .Cells("TipoEspecificacion").Value = TIPO_ESPECIFICACIONES(WTipoEsp)

                        If WNroEspecificacion = WNroObsAnt Then

                            auxi = XRenglon - 1

                            auxi = IIf(auxi < 0, 0, auxi )

                            If WNroEspecificacion = dgvEspecificaciones.Rows(auxi).Cells("NroEspecificacion").Value Then
                                .Cells("FechaEspecificacion").Value = ""
                                .Cells("UsuarioEspecificacion").Value = ""
                                .Cells("TipoEspecificacion").Value = ""
                            End If

                            .Cells("NroEspecificacion").Value = WNroEspecificacion '& WRefPrimeraFilaEsp
                            .Cells("RenglonEspecificacion").Value = WRenglon '& WRefPrimeraFilaEsp
                        Else
                            WNroObsAnt = WNroEspecificacion
                            WRefPrimeraFilaEsp = Helper.ceros(XRenglon, 4)
                            .Cells("NroEspecificacion").Value = WNroEspecificacion '& WRefPrimeraFilaEsp
                            .Cells("RenglonEspecificacion").Value = WRenglon '& WRefPrimeraFilaEsp
                        End If

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub txtNroProforma_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroProforma.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

            Try
                Dim WNroProforma = Helper.ceros(txtNroProforma.Text, 6)

                _LimpiarTodo()

                txtNroProforma.Text = WNroProforma

                _TraerHistorialYArchivos()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            txtFechaAux.Visible = False
            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNroProforma.Text = ""
        End If

    End Sub

    'Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

    '        If Helper._ValidarFecha(txtFecha.Text) Then
    '            txtCliente.Focus()
    '        End If

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtFecha.Text = ""
    '    End If

    'End Sub

    'Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

    '    If e.KeyData = Keys.Enter Then
    '        If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then : Exit Sub : End If

    '        If WRow >= 0 And Wcol >= 0 Then

    '            'With dgvHistorial
    '            '    .Rows(WRow).Cells(0).Value = txtFechaAux.Text

    '            '    Dim terminado = _BuscarTerminado(txtFechaAux.Text)

    '            '    If Not IsNothing(terminado) Then
    '            '        .Rows(WRow).Cells(0).Value = terminado("Codigo")
    '            '        .Rows(WRow).Cells(1).Value = terminado("Descripcion")

    '            '        .CurrentCell = .Rows(WRow).Cells(2)
    '            '        .Focus()

    '            '        txtFechaAux.Visible = False
    '            '        txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
    '            '    Else
    '            '        txtFechaAux.Focus()
    '            '    End If
    '            'End With

    '        End If

    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtFechaAux.Clear()
    '    End If

    'End Sub

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

        With dgvHistorial
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = .CurrentCell.Value

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    'Case 1
                    'If Not _EsNumeroOControl(keyData) Then
                    '    Return True
                    'End If
                    'Case 1
                    '    If Not _EsDecimalOControl(keyData) Then
                    '        Return True
                    '    End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If valor <> "" Then

                        Select Case iCol
                            'Case 2, 3
                            '    _RecalcularTotalFila(iRow)
                            Case Else

                        End Select

                        '_NormalizarNumerosGrilla()

                    End If

                    Select Case iCol
                        'Case 3, 4
                        '    If iRow = PRODUCTOS_MAX - 1 Then
                        '        .CurrentCell = .Rows(iRow).Cells(iCol)
                        '    Else
                        '        Try
                        '            .CurrentCell = .Rows(iRow + 1).Cells(0)
                        '        Catch ex As Exception
                        '            .CurrentCell = .Rows(iRow).Cells(iCol)
                        '        End Try
                        '    End If

                        'Case Else
                        '    .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then


                    Select Case iCol
                        'Case 0, 2, 3

                        '    .Rows(iRow).Cells(iCol).Value = ""

                        '    If iCol = 4 Then
                        '        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                        '    Else
                        '        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        '    End If

                        '    .CurrentCell = .Rows(iRow).Cells(iCol)

                        Case Else

                    End Select

                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Private Sub dgvHistorial_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistorial.CellEnter
    '    With dgvHistorial
    '        If e.ColumnIndex = 0 Then
    '            .ClearSelection()
    '            .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
    '            Dim _location As Point = .GetCellDisplayRectangle(0, e.RowIndex, False).Location

    '            _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
    '            _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
    '            txtFechaAux.Location = _location
    '            txtFechaAux.Text = .Rows(e.RowIndex).Cells(0).Value
    '            WRow = e.RowIndex
    '            Wcol = e.ColumnIndex
    '            txtFechaAux.Visible = True
    '            txtFechaAux.Focus()
    '        End If
    '    End With
    'End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProforma.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Function _Left(ByVal texto, ByVal largo) As String
        Return Microsoft.VisualBasic.Left(Trim(texto), largo)
    End Function

    Private Function _TraerProximoRenglon() As Integer
        Dim _ProximoRenglon As Integer = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT MAX(Renglon) as Ultimo FROM ProformaExportacionHistorial WHERE Proforma = '" & txtNroProforma.Text & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _ProximoRenglon = IIf(IsDBNull(dr.Item("Ultimo")), 0, Val(dr.Item("Ultimo")) + 1)

            Else
                MsgBox("Error consulta sql", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
        Return _ProximoRenglon
    End Function

    Private Function _ProximoNroObservacion()
        Dim actual = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 NroObservacion as NroActual FROM ProformaExportacionHistorial ORDER BY NroObservacion DESC")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                actual = dr.Item("NroActual")

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el próximo número de Observación de la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return actual + 1

    End Function

    Private Function _DatosValidos() As Boolean

        ' Validamos que la fecha indicada sea correcta.
        If Not Helper._ValidarFecha(txtFecha.Text) Then
            MsgBox("La fecha indicada no es válida", MsgBoxStyle.Critical)
            txtFecha.Focus()
            Return False
        End If

        ' Validamos que se haya cargado algun nombre de usuario.
        If Trim(txtUsuario.Text) = "" Then
            MsgBox("Debe indicarse un usuario al que le corresponda la presente observación", MsgBoxStyle.Critical)
            txtUsuario.Focus()
            Return False
        End If

        ' Validamos que se haya cargado contenido para grabar una observacion.
        ' Se eliminan todos los caracteres de Nueva Linea y de Acarreo antes de validar.
        If Trim(txtObservacion.Text.Replace(vbCrLf, "").Replace(vbLf, "")) = "" Then
            MsgBox("La observacioón no puede estar vacía.", MsgBoxStyle.Critical)
            txtObservacion.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim trans As SqlTransaction = Nothing

        Dim WClave, WRenglon, XRenglon, WNroProforma, WFecha, WFechaOrd, WCliente, WObservacion, WUsuario, WNroObservacion, WClaveObs, ZSql
        Dim WFila = "", WFilasAGrabar() As String
        Dim WParrafosAGrabar() As String

        cn.ConnectionString = _CS()
        cn.Open()

        trans = cn.BeginTransaction
        cm.Connection = cn
        cm.Transaction = trans

        ZSql = ""
        WNroProforma = Helper.ceros(txtNroProforma.Text, 6)
        WFecha = txtFecha.Text
        WFechaOrd = Helper.ordenaFecha(WFecha)
        WCliente = txtCliente.Text
        WObservacion = Trim(txtObservacion.Text)
        WClaveObs = Trim(WClaveObservacion.Text)

        WUsuario = txtUsuario.Text

        ' Validamos datos minimos antes de grabar.
        If Not _DatosValidos() Then
            Exit Sub
        End If

        ' Chequeamos si se trata de la actualización de un renglon existente.
        ' Si tiene clave, es una actualizacion y recuperamos el nro de referencia.
        If WClaveObs = "" Then

            Try
                WNroObservacion = _ProximoNroObservacion()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

        Else

            WNroObservacion = Mid(WClaveObs, 1, WClaveObs.ToString.Length - 4)

        End If

        Try

            ZSql = ""
            ZSql = "DELETE FROM ProformaExportacionHistorial WHERE NroObservacion = '" & WNroObservacion & "'"

            cm.CommandText = ZSql

            cm.ExecuteNonQuery()

            ' Aca calculamos y grabamos todas las filas correspondientes.

            WObservacion = Trim(WObservacion)

            ' Separamos los párrafos para conservar el formato del comentario.
            WParrafosAGrabar = WObservacion.ToString.Split(vbCrLf)

            WRenglon = 0

            For i = 0 To WParrafosAGrabar.Length - 1

                If WParrafosAGrabar(i) <> "" Then

                    ' Redondeamos el párrafo a un multiplo de 100 (max de caracteres por linea.)
                    WParrafosAGrabar(i) = LSet(WParrafosAGrabar(i), 100 - (WParrafosAGrabar(i).Length Mod 100))

                    ' Calculamos el numero de filas a grabar.
                    ReDim WFilasAGrabar((WParrafosAGrabar(i).Length / 100))

                    ' Por cada fila, cortamos trozos del parrafo cada 100 caracteres.
                    For x = 0 To WFilasAGrabar.Length - 1

                        WFilasAGrabar(x) = Trim(Mid(WParrafosAGrabar(i), (x * 100) + 1, 100))

                        ' Grabamos unicamente aquellos que no sean nueva fila y tengan contenido.
                        If Trim(WFilasAGrabar(x)) <> "" And WFilasAGrabar(x) <> vbLf Then
                            WRenglon += 1

                            XRenglon = Helper.ceros(WRenglon, 2)

                            WClave = Helper.ceros(WNroObservacion, 6) + XRenglon

                            ZSql = ""
                            ZSql = "INSERT INTO ProformaExportacionHistorial (Clave, NroObservacion, Renglon, Proforma, Usuario, Fecha, FechaOrd, Observaciones) "
                            ZSql &= "VALUES "
                            ZSql &= "('" & WClave & "'," & WNroObservacion & ",'" & XRenglon & "','" & WNroProforma & "','" & WUsuario & "','" & WFecha & "','" & WFechaOrd & "','" & WFilasAGrabar(x) & "')"

                            cm.CommandText = ZSql

                            cm.ExecuteNonQuery()
                        End If

                    Next

                End If

            Next

        Catch ex As Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            cn.Close()
            MsgBox("No se pudo grabar la observación en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        trans.Commit()

        ' Aca consultamos si quiere enviar este mismo contenido por email. Abrimos un nuevo email, sin enviarlo automaticamente.
        If MsgBox("¿Desea enviar este comentario por E-Mail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            _AbrirNuevoEmail(Trim(txtObservacion.Text))
        End If


        'MsgBox("La observación ha sido grabada con exito.", MsgBoxStyle.Information)

        _TraerHistorialYArchivos()

        ' Despues de cargar todo el historial, no posicionamos en la primer fila de ese comentario creado/actualizado.
        For Each row As DataGridViewRow In dgvHistorial.Rows
            If row.Cells("Clave").Value = WClaveObs Then
                row.Cells(0).Selected = True
                Exit For
            End If
        Next

        'btnVistaPrevia.PerformClick()

        'btnLimpiar.PerformClick()
        GrupoNuevaObs.Visible = False

    End Sub

    Private Sub _AbrirNuevoEmail(ByVal body)
        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem

        Try
            oApp = New Outlook.Application()

            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = ""
            oMsg.Body = body
            oMsg.To = ""

            oMsg.Display()

        Catch ex As Exception
            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub _TraerHistorialYArchivos()

        _BuscarClienteProforma()

        _MostrarHistorial()

        _CargarArchivosRelacionados()

        _MostrarEspecificaciones()

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        txtObservacion.Text = ""

        'If Trim(WClaveObservacion.Text) = "" Then
        txtUsuario.Text = ""
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        WClaveObservacion.Text = ""
        'End If

        txtFecha.Focus()
    End Sub

    Private Sub _CargarRenglon(ByVal rowIndex As Integer)
        Dim WRow = rowIndex
        If rowIndex + 1 <> Val(Microsoft.VisualBasic.Right(WClaveObservacion.Text, 2)) Or Trim(WClaveObservacion.Text) = "" Then
            WClaveObservacion.Text = ""

            btnLimpiar.PerformClick()

            ' Calculamos la primera fila de la observacion, segun su clave.
            rowIndex = Val(Microsoft.VisualBasic.Right(dgvHistorial.Rows(rowIndex).Cells("NroObservacion").Value, 4))

            With dgvHistorial.Rows(rowIndex)
                txtFecha.Text = Trim(.Cells("Fecha").Value)

                txtUsuario.Text = Trim(.Cells("Usuario").Value)
                WClaveObservacion.Text = Trim(.Cells("NroObservacion").Value)

                txtObservacion.Text = ""

                ' Recorremos hasta la ultima fila de la observacion.
                For i = rowIndex To dgvHistorial.Rows.Count - 1

                    ' Salimos en la primera en la que ya no coincidan las claves de la observacion.
                    If Val(dgvHistorial.Rows(i).Cells("NroObservacion").Value) <> Val(WClaveObservacion.Text) Then
                        Exit For
                    End If

                    txtObservacion.Text &= dgvHistorial.Rows(i).Cells("Observacion").Value.ToString.Trim() & vbCrLf

                Next

            End With

            GrupoNuevaObs.Visible = True
        End If

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFecha.Text) Then
                txtUsuario.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If

    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtUsuario.Text) = "" Then : Exit Sub : End If

            txtObservacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtUsuario.Text = ""
        End If

    End Sub

    Private Sub btnEliminar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(WClaveObservacion.Text) = "" Then : Exit Sub : End If

        If MsgBox("¿Está seguro de que quiere eliminar la observación actual?", MsgBoxStyle.YesNo, MsgBoxStyle.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            _EliminarObservacion(WClaveObservacion.Text)
        Catch ex As Exception
            MsgBox("No se pudo eliminar la observación de la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Sub _EliminarObservacion(ByVal WClave As String)
        WClave = Trim(WClave)
        If WClave = "" Then : Exit Sub : End If

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim WNroObs = Mid(WClave, 1, WClave.Length - 4)

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "DELETE FROM ProformaExportacionHistorial WHERE NroObservacion = '" & WNroObs & "'"

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        btnLimpiar.PerformClick()

        _TraerHistorialYArchivos()

    End Sub

    Private Sub _EliminarEspecificacion(ByVal WClave As String)
        WClave = Trim(WClave)
        If WClave = "" Then : Exit Sub : End If

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        'Dim WNroObs = Mid(WClave, 1, WClave.Length - 4)

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "DELETE FROM ProformaExportacionEspecificaciones WHERE NroEspecificacion = '" & WClave & "'"

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        btnLimpiar.PerformClick()

        _TraerHistorialYArchivos()

    End Sub

    Private Sub btnArchivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivos.Click
        ' Abrimos ventana de archivos Relacionados.
        'With ArchivosRelacionados
        '    .NroProforma = txtNroProforma.Text
        '    .Show()
        'End With

        TabControl1.SelectTab(1)
        'Process.Start("explorer.exe", "C:\")
        Try
            _AdjuntarArchivos()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub _AdjuntarArchivos()
        Dim _ArchivosAdjuntos() As String

        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            _ArchivosAdjuntos = OpenFileDialog1.FileNames

            'txtNombreArchivoAdjunto.Text = _ArchivoAdjunto

            _SubirArchivos(_ArchivosAdjuntos)

        End If

        OpenFileDialog1.Dispose()

        _TraerHistorialYArchivos()


    End Sub

    Private Function _ExisteProforma() As Boolean

        If Trim(txtNroProforma.Text) = "" Then
            Return False
        End If

        If Trim(txtNroProforma.Text).Length < 6 Then : txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6) : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Proforma FROM ProformaExportacion WHERE Proforma = '" & txtNroProforma.Text & "'")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub btnNuevaObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaObservacion.Click

        If Not _ExisteProforma() Then
            txtNroProforma.Focus()
            txtNroProforma.SelectAll()
            Exit Sub
        End If

        TabControl1.SelectTab(0)

        GrupoNuevaObs.Visible = True
        btnLimpiar.PerformClick()
        txtFecha.Focus()
    End Sub

    Private Sub btnCerrarFormObs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarFormObs.Click
        btnLimpiar.PerformClick()
        GrupoNuevaObs.Visible = False
    End Sub

    Private Sub dgvHistorial_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHistorial.RowHeaderMouseDoubleClick

        ' Verificamos que tenga una clave de Observacion para poder eliminar.
        With dgvHistorial.Rows(e.RowIndex)

            If Not IsNothing(.Cells("NroObservacion").Value) Then
                If Trim(.Cells("NroObservacion").Value) <> "" Then

                    If MsgBox("¿Está seguro de querer eliminar la observacion indicada?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then : Exit Sub : End If

                    Try
                        _EliminarObservacion(.Cells("NroObservacion").Value)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                End If
            End If

        End With

    End Sub

    Private Sub dgvHistorial_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistorial.CellContentDoubleClick
        _CargarRenglon(e.RowIndex)
    End Sub

    '
    ' MANEJO DE PESTAÑA ARCHIVOS.
    '

    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub _CargarArchivosRelacionados()
        Dim WRutaArchivosRelacionados As String = ""

        dgvArchivos.Rows.Clear()

        If Not Directory.Exists(_RutaCarpetaArchivos) Then
            Throw New Exception("No se ha logrado tener acceso a la Carpeta Compartida de Archivos Relacionados.")
            Exit Sub
        End If

        If txtNroProforma.Text.Trim.Length < 6 Then : txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6) : End If

        WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text

        ' Creamos la Carpeta en caso de que no exista aún.
        If Not Directory.Exists(WRutaArchivosRelacionados) Then
            Try
                Directory.CreateDirectory(WRutaArchivosRelacionados)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If

        Dim InfoArchivo As FileInfo


        ' Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
        For Each WNombreArchivo As String In Directory.GetFiles(WRutaArchivosRelacionados).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

            InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

            With InfoArchivo
                dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName)
            End With

        Next

    End Sub

    Private Function _ObtenerIconoSegunTipoArchivo(ByVal extension As String)
        Dim icono = Nothing

        'My.Resources.pdf_icon


        Select Case UCase(extension)

            Case ".DOC", ".DOCX"
                icono = My.Resources.Word_icon
            Case ".XLS", ".XLSX", ".XLSM"
                icono = My.Resources.Excel_icon
            Case ".PDF"
                icono = My.Resources.pdf_icono
            Case ".JPG", ".JPEG", ".BMP", ".ICO", ".PNG"
                icono = My.Resources.imagen_icono
            Case ".TXT"
                icono = My.Resources.txt_icono
            Case Else
                icono = My.Resources.archivo_default
        End Select


        Return icono
    End Function

    Private Sub _BuscarClienteProforma()
        If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Cliente, c.Razon FROM ProformaExportacion as p, Cliente as c WHERE Proforma = '" & txtNroProforma.Text & "' AND p.Cliente = c.Cliente")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr
                    txtCliente.Text = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                    txtDescripcionCliente.Text = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                End With

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los datos del Cliente correspondiente a la Proforma en la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub


    Private Sub dgvArchivos_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs)

        If Trim(txtNroProforma.Text).Length < 6 Then : txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6) : End If

        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
        

        If archivos.Length = 0 Then : Exit Sub : End If

        _SubirArchivos(archivos)

        'If WCantCorrectas > 0 Then
        '    MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        'End If

        _CargarArchivosRelacionados()

    End Sub

    Private Sub _SubirArchivos(ByVal archivos() As String)
        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text
        Dim WDestino As String = ""
        Dim WCantCorrectas = 0

        For Each archivo In archivos

            If File.Exists(archivo) Then

                If EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(archivo).ToLower()) Then

                    WDestino = WRutaArchivosRelacionados & "\" & Path.GetFileName(archivo)

                    Try
                        If Not File.Exists(WDestino) Then
                            File.Copy(archivo, WDestino)
                            WCantCorrectas += 1
                        Else
                            If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                File.Copy(archivo, WDestino, True)
                                WCantCorrectas += 1
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                End If

            End If

        Next

    End Sub

    Private Sub dgvArchivos_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub dgvArchivos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArchivos.RowHeaderMouseDoubleClick

        With dgvArchivos.Rows(e.RowIndex)

            Dim WRutaArchivo = .Cells("RutaArchivo").Value

            If IsNothing(WRutaArchivo) Then : Exit Sub : End If

            If Trim(WRutaArchivo) = "" Then : Exit Sub : End If

            If Not File.Exists(WRutaArchivo) Then : Exit Sub : End If

            If MsgBox("¿Está seguro de que quiere eliminar el archivo de manera definitiva?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then : Exit Sub : End If

            Try
                File.Delete(WRutaArchivo)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            _TraerHistorialYArchivos()

            TabControl1.SelectTab(1)
        End With

    End Sub

    Private Sub dgvArchivos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivos.CellContentDoubleClick
        With dgvArchivos.Rows(e.RowIndex)
            If Not IsNothing(.Cells("RutaArchivo").Value) Then

                Try
                    Process.Start(.Cells("RutaArchivo").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then

            'TabControl1.TabPages(1).Font = New Font(TabControl1.TabPages(1).Font.FontFamily, TabControl1.TabPages(1).Font.Size - 0.25)
            'TabControl1.ItemSize = New Size(TabControl1.ItemSize.Width, TabControl1.ItemSize.Height + 5)

        ElseIf TabControl1.SelectedIndex = 1 Then

            '            TabControl1.TabPages(0).Font = New Font(TabControl1.TabPages(0).Font.FontFamily, TabControl1.TabPages(0).Font.Size - 0.25)

        End If

    End Sub

    Private Sub btnEnviarPorEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarPorEmail.Click
        Dim WObservacion As String = ""
        Dim WNroObservacion As Integer = 0

        Try

            If Trim(txtObservacion.Text) = "" Then : Exit Sub : End If

            _AbrirNuevoEmail(txtObservacion.Text)

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Sub btnNuevaEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaEspecificacion.Click
        TabControl1.SelectTab(2)
        GrupoEspecificacion.Visible = True
        btnLimpiarFormularioEspecificacion.PerformClick()
    End Sub

    Private Sub btnCerrarFormularioEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarFormularioEspecificacion.Click
        GrupoEspecificacion.Visible = False
    End Sub

    Private Sub btnLimpiarFormularioEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFormularioEspecificacion.Click
        GrupoEspecificacion.Visible = True
        txtFechaEspecificacion.Text = Date.Now.ToString("dd/MM/yyyy")
        cmbTipoEspecificacion.SelectedIndex = 0
        txtEspecificacion.Text = ""
        WNroEspecificacion.Text = ""
        txtFechaEspecificacion.Focus()

    End Sub

    Private Sub txtFechaEspecificacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaEspecificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaEspecificacion.Text).Length < 10 Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFechaEspecificacion.Text) Then

                cmbTipoEspecificacion.Focus()
                cmbTipoEspecificacion.DroppedDown = True

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEspecificacion.Clear()
        End If

    End Sub

    Private Function _ProximoNroEspecificacion()
        Dim actual = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 NroEspecificacion as NroActual FROM ProformaExportacionEspecificaciones ORDER BY NroEspecificacion DESC")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                actual = IIf(IsDBNull(dr.Item("NroActual")), 0, dr.Item("NroActual"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer el próximo número de Espeficación de la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return actual + 1

    End Function

    Private Function _DatosEspecificacionValidos()

        If Not _ExisteProforma() Then
            Return False
        End If

        If Not Helper._ValidarFecha(txtFechaEspecificacion.Text) Then
            MsgBox("La fecha de Especificación indicada no es una fecha válida.", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Trim(txtEspecificacion.Text) = "" Then
            MsgBox("Debe cargar alguna especificación antes de grabar.", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Trim(txtUsuarioEspecificacion.Text) = "" Then
            MsgBox("Debe indicar quién carga la nueva especificación.", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Val(cmbTipoEspecificacion.SelectedIndex) < 1 Then
            MsgBox("Debe indicar de qué Tipo de Especificación se trata.", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAgregarEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarEspecificacion.Click

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim trans As SqlTransaction = Nothing

        Dim WClave, WRenglon, XRenglon, WNroProforma, WFecha, WFechaOrd, WTipo, WEspecificacion, WUsuario, WNroEspecif, WClaveEsp, ZSql
        Dim WFila = "", WFilasAGrabar() As String
        Dim WParrafosAGrabar() As String

        cn.ConnectionString = _CS()
        cn.Open()

        trans = cn.BeginTransaction
        cm.Connection = cn
        cm.Transaction = trans

        ZSql = ""
        WNroProforma = Helper.ceros(txtNroProforma.Text, 6)
        WFecha = txtFecha.Text
        WFechaOrd = Helper.ordenaFecha(WFecha)
        WTipo = cmbTipoEspecificacion.SelectedIndex
        WEspecificacion = Trim(txtEspecificacion.Text)
        WClaveEsp = Trim(WNroEspecificacion.Text)

        WUsuario = txtUsuarioEspecificacion.Text

        ' Validamos datos minimos antes de grabar.
        If Not _DatosEspecificacionValidos() Then
            txtFechaEspecificacion.Focus()
            Exit Sub
        End If

        ' Chequeamos si se trata de la actualización de un renglon existente.
        ' Si tiene clave, es una actualizacion y recuperamos el nro de referencia.
        If WClaveEsp = "" Then

            Try
                WNroEspecif = _ProximoNroEspecificacion()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

        Else

            WNroEspecif = Val(WClaveEsp) 'Mid(WClaveEsp, 1, WClaveEsp.ToString.Length - 4)

        End If

        Try

            ZSql = ""
            ZSql = "DELETE FROM ProformaExportacionEspecificaciones WHERE NroEspecificacion = '" & WNroEspecif & "'"

            cm.CommandText = ZSql

            cm.ExecuteNonQuery()

            ' Aca calculamos y grabamos todas las filas correspondientes.

            WEspecificacion = Trim(WEspecificacion)

            ' Separamos los párrafos para conservar el formato del comentario.
            WParrafosAGrabar = WEspecificacion.ToString.Split(vbCrLf)

            WRenglon = 0

            For i = 0 To WParrafosAGrabar.Length - 1

                If WParrafosAGrabar(i) <> "" And WParrafosAGrabar(i) <> vbLf Then

                    ' Redondeamos el párrafo a un multiplo de 100 (max de caracteres por linea.)
                    WParrafosAGrabar(i) = LSet(WParrafosAGrabar(i), 100 - (WParrafosAGrabar(i).Length Mod 100))

                    ' Calculamos el numero de filas a grabar.
                    ReDim WFilasAGrabar((WParrafosAGrabar(i).Length / 100))

                    ' Por cada fila, cortamos trozos del parrafo cada 100 caracteres.
                    For x = 0 To WFilasAGrabar.Length - 1

                        WFilasAGrabar(x) = Trim(Mid(WParrafosAGrabar(i), (x * 100) + 1, 100))

                        ' Grabamos unicamente aquellos que no sean nueva fila y tengan contenido.
                        If Trim(WFilasAGrabar(x)) <> "" And WFilasAGrabar(x) <> vbLf Then
                            WRenglon += 1

                            XRenglon = Helper.ceros(WRenglon, 2)

                            WClave = Helper.ceros(WNroEspecif, 6) + XRenglon

                            ZSql = ""
                            ZSql = "INSERT INTO ProformaExportacionEspecificaciones (Clave, NroEspecificacion, Renglon, Proforma, Especificacion, Tipo, Fecha, FechaOrd, Usuario) "
                            ZSql &= "VALUES "
                            ZSql &= "('" & WClave & "'," & WNroEspecif & ",'" & XRenglon & "','" & WNroProforma & "','" & WFilasAGrabar(x) & "','" & WTipo & "','" & WFecha & "','" & WFechaOrd & "','" & WUsuario & "')"

                            cm.CommandText = ZSql

                            cm.ExecuteNonQuery()
                        End If

                    Next

                End If

            Next

        Catch ex As Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            cn.Close()
            MsgBox("No se pudo grabar la Especificacion en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        trans.Commit()

        ' Aca consultamos si quiere enviar este mismo contenido por email. Abrimos un nuevo email, sin enviarlo automaticamente.
        If MsgBox("¿Desea enviar esta Especificación por E-Mail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                _AbrirNuevoEmail(Trim(txtEspecificacion.Text))
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If


        'MsgBox("La observación ha sido grabada con exito.", MsgBoxStyle.Information)

        _TraerHistorialYArchivos()

        ' Despues de cargar todo el historial, no posicionamos en la primer fila de ese comentario creado/actualizado.
        If dgvEspecificaciones.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvEspecificaciones.Rows
                If row.Cells("NroEspecificacion").Value = WNroEspecif And Val(row.Cells("RenglonEspecificacion").Value) = 1 Then
                    row.Cells(0).Selected = True
                    Exit For
                End If
            Next
        End If

        'btnVistaPrevia.PerformClick()

        'btnLimpiar.PerformClick()
        GrupoEspecificacion.Visible = False

    End Sub

    Private Sub cmbTipoEspecificacion_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoEspecificacion.DropDownClosed
        If cmbTipoEspecificacion.SelectedIndex > 0 Then
            txtUsuarioEspecificacion.Focus()
        End If
    End Sub

    Private Sub cmbTipoEspecificacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoEspecificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(cmbTipoEspecificacion.Text) < 0 Then : Exit Sub : End If

            txtUsuarioEspecificacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbTipoEspecificacion.SelectedIndex = 0
        End If

    End Sub

    Private Sub txtUsuarioEspecificacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuarioEspecificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtUsuarioEspecificacion.Text) = "" Then : Exit Sub : End If

            txtEspecificacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtUsuarioEspecificacion.Text = ""
        End If

    End Sub

    Private Sub _CargarEspecificacion(ByVal NroEspecificacion)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM ProformaExportacionEspecificaciones WHERE NroEspecificacion = '" & Val(NroEspecificacion) & "' ORDER BY Renglon")
        Dim dr As SqlDataReader
        Dim WClave, WNroEspec, WRenglon, WProforma, WEspecificacion, WTipo, WFecha, WFechaOrd, WUsuario


        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            'btnLimpiarFormularioEspecificacion.PerformClick()
            txtFechaEspecificacion.Text = ""
            cmbTipoEspecificacion.SelectedIndex = 0
            txtUsuarioEspecificacion.Text = ""
            txtEspecificacion.Text = ""

            If dr.HasRows Then

                WClave = ""
                WNroEspec = ""
                WRenglon = ""
                WEspecificacion = ""
                WTipo = 0
                WFecha = ""
                WFechaOrd = ""
                WUsuario = ""

                Do While dr.Read()

                    WClave = IIf(IsDBNull(dr.Item("Clave")), "", dr.Item("Clave"))
                    WNroEspec = IIf(IsDBNull(dr.Item("NroEspecificacion")), "", dr.Item("NroEspecificacion"))
                    WRenglon = IIf(IsDBNull(dr.Item("Renglon")), "", dr.Item("Renglon"))
                    WProforma = IIf(IsDBNull(dr.Item("Proforma")), "", dr.Item("Proforma"))
                    WEspecificacion = IIf(IsDBNull(dr.Item("Especificacion")), "", dr.Item("Especificacion"))
                    WTipo = IIf(IsDBNull(dr.Item("Tipo")), 0, dr.Item("Tipo"))
                    WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))
                    WFechaOrd = IIf(IsDBNull(dr.Item("FechaOrd")), "", dr.Item("FechaOrd"))
                    WUsuario = IIf(IsDBNull(dr.Item("Usuario")), "", dr.Item("Usuario"))

                    txtFechaEspecificacion.Text = WFecha
                    cmbTipoEspecificacion.SelectedIndex = WTipo
                    txtUsuarioEspecificacion.Text = Trim(WUsuario)
                    txtEspecificacion.Text &= Trim(WEspecificacion) & vbCrLf

                    WNroEspecificacion.Text = Val(WNroEspec)

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer recuperar la Especificación desde la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub


    Private Sub dgvEspecificaciones_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEspecificaciones.CellContentDoubleClick

        With dgvEspecificaciones.CurrentRow

            If Not IsNothing(.Cells("NroEspecificacion").Value) Then
                If Val(.Cells("NroEspecificacion").Value) > 0 Then

                    Try
                        _CargarEspecificacion(.Cells("NroEspecificacion").Value)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                    GrupoEspecificacion.Visible = True

                End If
            End If

        End With

    End Sub

    Private Sub PegarArchivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarArchivosToolStripMenuItem.Click
        Dim _Archivos() As String

        ReDim _Archivos(Clipboard.GetFileDropList.Count)

        For i = 0 To Clipboard.GetFileDropList.Count - 1
            _Archivos(i) = Clipboard.GetFileDropList.Item(i)
        Next

        _SubirArchivos(_Archivos)

        _TraerHistorialYArchivos()

    End Sub

    Private Sub dgvArchivos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivos.CellDoubleClick
        If dgvArchivos.SelectedRows.Count > 0 Then : Exit Sub : End If
        With dgvArchivos.Rows(e.RowIndex)

            If Not IsNothing(.Cells("RutaArchivo").Value) Then

                Try
                    Process.Start(.Cells("RutaArchivo").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    Private Sub btnEnviarEmailEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarEmailEspecificacion.Click
        If Trim(txtEspecificacion.Text) <> "" Then
            Try
                _AbrirNuevoEmail(Trim(txtEspecificacion.Text))
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub btnEliminarEspecificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarEspecificacion.Click
        If Trim(WNroEspecificacion.Text) = "" Then : Exit Sub : End If

        If MsgBox("¿Está seguro de que quiere eliminar la especificación actual?", MsgBoxStyle.YesNo, MsgBoxStyle.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            _EliminarEspecificacion(WNroEspecificacion.Text)

        Catch ex As Exception
            MsgBox("No se pudo eliminar la observación de la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        btnCerrarFormularioEspecificacion.PerformClick()
    End Sub
End Class