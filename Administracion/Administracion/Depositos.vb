Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Depositos
    ' ReSharper disable once NotAccessedField.Local
    Dim showFunction As ShowMethod
    Dim cheques As New List(Of Cheque)
    Private _ClavesCheques As New List(Of Object)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        btnLimpiar.PerformClick()

        Proceso._PurgarSaldosCtaCtePrvs()
    End Sub

    Private Function sumaImportes() As Double
        Return gridCheques.Rows.Cast(Of DataGridViewRow)().Sum(Function(row) Val(Proceso.formatonumerico(row.Cells(4).Value)))
    End Function

    Private Function validarTipoUnico() As Boolean
        ' ReSharper disable once LocalVariableHidesMember
        Dim _tipo As Integer
        If gridCheques.Rows.Count > 0 Then
            _tipo = gridCheques.Rows(0).Cells(0).Value
        Else
            Return True
        End If
        For Each row As DataGridViewRow In From row1 As DataGridViewRow In gridCheques.Rows Where _tipo <> row1.Cells(0).Value

            If Not IsNothing(row.Cells(0).Value) Then
                Return (row.Index + 1 = gridCheques.Rows.Count) And IsNothing(row.Cells(0).Value)
            End If

        Next
        Return True
    End Function

    Private Function validarEstadoGrilla()
        For Each row As DataGridViewRow In gridCheques.Rows
            Dim tipo As Integer = row.Cells(0).Value
            Dim importe As Double = CustomConvert.toDoubleOrZero(row.Cells(4).Value)
            If (tipo <> 1 And tipo <> 2 And tipo <> 3) Or importe = 0 Then
                Return (row.Index + 1 = gridCheques.Rows.Count) And IsNothing(row.Cells(0).Value)
            End If
        Next
        Return True
    End Function

    Private Function validarCampos()
        Dim validador As New Validator
        '
        ' Validamos que el deposito no se encuentre ya grabado.
        '
        Try
            If _ExisteDeposito(txtNroDeposito.Text) Then
                MsgBox("Ya existe un Deposito con este número. No se puede actualizar los datos del mismo.", MsgBoxStyle.Exclamation)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
        

        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(Trim(txtCodigoBanco.Text))

        ' Normalizamos los valores antes de compararlos.
        For i = 0 To gridCheques.Rows.Count - 1
            With gridCheques.Rows(i)
                If Not IsNothing(.Cells(4).Value) Then
                    If Val(.Cells(4).Value) <> 0 Then
                        .Cells(4).Value = Proceso.formatonumerico(.Cells(4).Value)
                    End If
                End If
            End With
        Next

        validador.validate(Me)

        Dim ZSumaImporte = Proceso.formatonumerico(Math.Round(sumaImportes(), 2))

        validador.alsoValidate(Val(Proceso.formatonumerico(txtImporte.Text)) = Val(ZSumaImporte), "El campo importe tiene que ser igual a la suma de los valores (" & ZSumaImporte & ")")
        validador.alsoValidate(Not IsNothing(banco), "Debe ingresar un Banco válido.")
        'validador.alsoValidate(validarTipoUnico(), "Sólo puede realizarse un tipo de depósito por carga")
        validador.alsoValidate(validarEstadoGrilla(), "Hay campos en la grilla con estados inválidos")
        validador.alsoValidate(Not DAODeposito.existeDepositoNumero(txtNroDeposito.Text), "Ya existe un depósito con número " & txtNroDeposito.Text)

        Return validador.flush
    End Function

    Private Function _ExisteDeposito(ByVal _NroDeposito As String) As Boolean
        If Val(_NroDeposito) = 0 Then
            Return False
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Deposito FROM Depositos WHERE Deposito = '" & _NroDeposito & "' AND (Renglon = '01' OR Renglon = '1')")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer verificar la existencia del deposito desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lstSeleccion.SelectedIndex = 0
        txtNroDeposito.Text = ceros(DAODeposito.siguienteNumero(), 6)
        txtCodigoBanco.Text = ""
        txtDescripcionBanco.Text = ""
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtFechaAcreditacion.Text = txtFecha.Text
        txtImporte.Text = ""
        gridCheques.Rows.Clear()
        gridCheques.Rows.Add()
        cheques.Clear()
        txtAyuda.Text = ""
        sumarImportes()
        _ClavesCheques.Clear()

        btnChequeTerceros.PerformClick()

        txtNroDeposito.Focus()
    End Sub

    Private Sub sumarImportes()
        lblTotal.Text = Proceso.formatonumerico(sumaImportes)
    End Sub

    Private Sub mostrarSeleccionDeConsulta()
        txtAyuda.Text = ""
        txtAyuda.Visible = False
        lstConsulta.Visible = False
        lstFiltrado.Visible = False
        lstSeleccion.Visible = True
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        mostrarSeleccionDeConsulta()
    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        If Not IsNothing(banco) Then
            txtCodigoBanco.Text = banco.id
            txtDescripcionBanco.Text = banco.nombre
        Else
            txtCodigoBanco.Text = ""
            txtDescripcionBanco.Text = ""
        End If
    End Sub

    Private Sub mostrarCheque(ByVal cheque As Cheque)

        If IsNothing(cheque) Then : Exit Sub : End If

        Dim rowIndex As Integer = _TraerProximaFila()

        With gridCheques.Rows(rowIndex)
            .Cells(0).Value = "3"
            .Cells(1).Value = cheque.numero
            .Cells(2).Value = cheque.fecha
            .Cells(3).Value = cheque.banco
            .Cells(4).Value = _NormalizarNumero(cheque.importe)
        End With

        sumarImportes()
    End Sub

    Private Function _TraerProximaFila() As Integer

        For Each row As DataGridViewRow In From row1 As DataGridViewRow In gridCheques.Rows Where row1.IsNewRow _
                                                                                                  OrElse IsNothing(row1.Cells(0).Value) _
                                                                                                  OrElse Trim(row1.Cells(0).Value) = ""
            Return row.Index
        Next

        Return gridCheques.Rows.Add()

    End Function

    Private Sub lstSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSeleccion.Click

        If lstSeleccion.SelectedItem = "Bancos" Then
            showFunction = AddressOf mostrarBanco
            lstConsulta.DataSource = DAOBanco.buscarBancoPorNombre("")
        Else
            showFunction = AddressOf mostrarCheque
            lstConsulta.DataSource = Nothing
            lstConsulta.Items.Clear()
            
            _ListarChequesTerceros()

        End If
        lstSeleccion.Visible = False
        lstConsulta.Visible = True
        txtAyuda.Visible = True
        txtAyuda.Focus()
    End Sub

    Private Sub _ListarChequesTerceros()
        Dim _ChequesRecibos As New List(Of Object)
        Dim _ChequesRecibosProvisorios As New List(Of Object)
        Dim _ChequesTotales As New List(Of Object)

        lstConsulta.Items.Clear()

        ' Traemos los cheques que se encuentran aun disponibles.
        _ChequesRecibos = _TraerChequesEnRecibos()
        _ChequesRecibosProvisorios = _TraerChequesEnRecibosProvisorios()

        ' Agrupamos todos los cheques
        _ChequesTotales.AddRange(_ChequesRecibos)
        _ChequesTotales.AddRange(_ChequesRecibosProvisorios)

        ' Los ordenamos de manera ASC segun fecha
        _ChequesTotales.Sort(Function(a As Object, b As Object)
                                 Return Val(a(1).orden()) < Val(b(1).orden())
                             End Function)

        ' Lo colocamos en la lista.
        For Each _cheque As Object In _ChequesTotales
            lstConsulta.Items.Add(_cheque(1))
        Next

    End Sub


    Private Function _TraerChequesEnRecibos() As List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim itemTemplate As String = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " _
                                              & "Fecha2, Banco2, Clave, FechaOrd2, ClaveCheque FROM Recibos WHERE " _
                                              & "TipoReg = '2' AND Estado2 <> 'X' AND Tipo2 = '02' " _
                                              & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)) _
                                            .Replace("#FECHA#", .Item("Fecha2")) _
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2")).ToString.PadLeft(10, "_")) _
                                            .Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Val(Proceso.formatonumerico(dr.Item("Importe2"))), dr.Item("banco2"), "1" & dr.Item("Clave"), dr.Item("ClaveCheque"))})

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los cheques en recibos definitivos en la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _ChequesRecibos
    End Function

    Private Function _TraerChequesEnRecibosProvisorios() As List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim itemTemplate As String = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " _
                                              & "Fecha2, Banco2, Clave, FechaOrd2, ClaveCheque FROM RecibosProvi WHERE " _
                                              & "TipoReg = '2' AND Estado2 = 'P' AND ReciboDefinitivo = '0' AND FechaOrd2 > '20080430'" _
                                              & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)) _
                                            .Replace("#FECHA#", .Item("Fecha2")) _
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2")).ToString.PadLeft(10, "_")) _
                                            .Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Val(Proceso.formatonumerico(dr.Item("Importe2"))), dr.Item("banco2"), "2" & dr.Item("Clave"), dr.Item("ClaveCheque"))})

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los cheques en Recibos Provisorios en la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _ChequesRecibos
    End Function

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        If IsNothing(lstConsulta.SelectedItem) Then : Exit Sub : End If

        If lstSeleccion.SelectedItem = "Bancos" Then
            lstConsulta.Visible = False
            txtAyuda.Visible = False
            Dim banco As Banco = lstConsulta.SelectedItem

            If banco Is Nothing Then
                Exit Sub
            End If
            txtCodigoBanco.Text = banco.id
            txtDescripcionBanco.Text = Trim(banco.nombre)
            'txtCodigoBanco.Focus()
            btnChequeTerceros.PerformClick()
            txtFechaAcreditacion.Focus()

        Else

            Dim row As Integer = -1
            Dim cheq As Cheque

            cheq = lstConsulta.SelectedItem

            For Each _row As DataGridViewRow In gridCheques.Rows
                If Not _row.IsNewRow Then
                    If _row.Cells(5).Value = cheq.clave Then
                        MsgBox("Cheque ya cargado.", MsgBoxStyle.Exclamation)
                        lstConsulta.Items.Remove(lstConsulta.SelectedItem)
                        txtAyuda.Focus()
                        Exit Sub
                    End If
                End If
            Next

            For Each _row As DataGridViewRow In gridCheques.Rows
                If IsNothing(_row.Cells(0).Value) Then
                    row = _row.Index
                    Exit For
                ElseIf Trim(_row.Cells(0).Value) = "" Then
                    row = _row.Index
                    Exit For
                End If
            Next

            If row < 0 Then
                row = gridCheques.Rows.Add
            End If

            If cheq.ClaveCheque <> "" Then

                If _ProcesarCheque(row, cheq.ClaveCheque) Then
                    lstConsulta.Items.Remove(lstConsulta.SelectedItem)
                    sumarImportes()
                Else
                    MsgBox("Hubo un problema al querer cargar el cheque.", MsgBoxStyle.Exclamation)
                End If
            Else
                _TraerChequeRecibo(row, cheq.clave)
                sumarImportes()
            End If

            Dim nuevafila = gridCheques.Rows.Add()
            gridCheques.CurrentCell = gridCheques.Rows(nuevafila).Cells(0)
            gridCheques.Focus()

        End If
    End Sub

    Private Sub _TraerChequeRecibo(ByVal rowIndex As Integer, ByVal ClaveRecibo As String)
        Dim WTipo = "", WNumero = "", WFecha = "", WNombre = "", WImporte = "", WTipoRec = ""

        WTipoRec = Mid(ClaveRecibo, 1, 1)
        Dim ZSql = "SELECT Tipo2, Numero2, Fecha2, Banco2, Importe2 FROM #TABLA# WHERE Clave = '" & Mid(ClaveRecibo, 2, 8) & "'"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        Try

            If Val(WTipoRec) = 1 Then
                cm.CommandText = ZSql.Replace("#TABLA#", "Recibos")
            ElseIf Val(WTipoRec) = 2 Then
                cm.CommandText = ZSql.Replace("#TABLA#", "RecibosProvi")
            Else
                Exit Sub
            End If

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr

                    WTipo = "3"
                    WNumero = IIf(IsDBNull(.Item("Numero2")), "", .Item("Numero2"))
                    WFecha = IIf(IsDBNull(.Item("Fecha2")), "", .Item("Fecha2"))
                    WNombre = IIf(IsDBNull(.Item("Banco2")), "", .Item("Banco2"))
                    WImporte = IIf(IsDBNull(.Item("Importe2")), "", Proceso.formatonumerico(.Item("Importe2")))

                End With

                With gridCheques.Rows(rowIndex)

                    .Cells("Tipo").Value = WTipo
                    .Cells("Numero").Value = WNumero
                    .Cells("Fecha").Value = WFecha
                    .Cells("Nombre").Value = WNombre
                    .Cells("Importe").Value = WImporte
                    .Cells("ClaveCheque").Value = ClaveRecibo

                End With

                lstConsulta.Items.Remove(lstConsulta.SelectedItem)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub gridCheques_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles gridCheques.UserDeletingRow
        Dim chequeABorrar As Cheque = cheques.Find(Function(cheque) cheque.numero = e.Row.Cells(1).Value And cheque.fecha = e.Row.Cells(2).Value And cheque.banco = e.Row.Cells(3).Value And cheque.importe = e.Row.Cells(4).Value)
        If Not IsNothing(chequeABorrar) Then
            cheques.Remove(chequeABorrar)
        End If
        sumarImportes()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarCampos() Then
            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("")
            Dim trans As SqlTransaction = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim WControlaMarcaRecibos(100) As String
            Dim WIndiceMarca As Integer = 0

            Dim ZSql = "", XClaveRecibo = "", XObservaciones = "", WReciboDefintivo = 0, WTipoRecibo = ""
            Dim WClave, WDeposito, WRenglon, XRenglon, WBanco, WFecha, WFechaOrd, WImporte, WFechaAcredita, WFechaAcreditaOrd, WTipo2, WNumero2, WFecha2, WImporte2, WObservaciones2, WEmpresa, WImpoLista

            WClave = ""
            WDeposito = ""
            WRenglon = ""
            XRenglon = 0
            WBanco = 0
            WFecha = ""
            WFechaOrd = ""
            WImporte = 0.0
            WFechaAcredita = ""
            WFechaAcreditaOrd = ""
            WTipo2 = ""
            WNumero2 = ""
            WFecha2 = ""
            WImporte2 = 0.0
            WObservaciones2 = ""
            WEmpresa = 1
            WImpoLista = 0

            'DAODeposito.agregarDeposito(deposito, gridCheques.Rows)

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            trans = cn.BeginTransaction()
            cm.Connection = cn
            cm.Transaction = trans

            For Each row As DataGridViewRow In gridCheques.Rows

                If Not row.IsNewRow Then
                    Try
                        XRenglon += 1

                        WRenglon = Proceso.ceros(XRenglon, 2)
                        WDeposito = Trim(txtNroDeposito.Text)
                        WClave = WDeposito & WRenglon

                        WBanco = Val(txtCodigoBanco.Text)
                        WFecha = txtFecha.Text
                        WFechaOrd = Proceso.ordenaFecha(WFecha)
                        WImporte = Val(Proceso.formatonumerico(txtImporte.Text))
                        WFechaAcredita = txtFechaAcreditacion.Text
                        WFechaAcreditaOrd = Proceso.ordenaFecha(WFechaAcredita)
                        WTipo2 = Str$(Val(row.Cells("Tipo").Value))
                        WNumero2 = Proceso.ceros(row.Cells("Numero").Value, 8)
                        WFecha2 = row.Cells("Fecha").Value
                        WImporte2 = Val(Proceso.formatonumerico(row.Cells("Importe").Value))
                        WObservaciones2 = row.Cells("nombre").Value
                        WObservaciones2 = Microsoft.VisualBasic.Left$(WObservaciones2, 20)
                        WEmpresa = 1
                        WImpoLista = 0

                        If IsNothing(WTipo2) OrElse Val(WTipo2) = 0 Then
                            Continue For
                        End If

                        cm.CommandText = "INSERT INTO Depositos (Clave, Deposito, Renglon, Banco, Fecha, FechaOrd, Importe, Acredita, AcreditaOrd, Tipo2, Numero2, Fecha2, Importe2, Observaciones2, Empresa, ImpoLista) " _
                                        & " Values ('" & WClave & "', '" & WDeposito & "', '" & WRenglon & "', " & Str$(WBanco) & ", '" & WFecha & "', '" & WFechaOrd & "', " & Str$(WImporte) & ", '" & WFechaAcredita & "', '" & WFechaAcreditaOrd & "', '" & WTipo2 & "', '" & WNumero2 & "', '" & WFecha2 & "', " & Str$(WImporte2) & ", '" & WObservaciones2 & "', " & Str$(WEmpresa) & ", " & Str$(WImpoLista) & ")"

                        cm.ExecuteNonQuery()

                    Catch ex As Exception
                        If Not IsNothing(trans) Then
                            trans.Rollback()
                        End If
                        MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End Try


                    WReciboDefintivo = 0
                    XObservaciones = Microsoft.VisualBasic.Left$("Deposito Nro : " + Str$(txtNroDeposito.Text) + " Banco : " + txtDescripcionBanco.Text, 50)
                    WTipoRecibo = Microsoft.VisualBasic.Left$(row.Cells("ClaveCheque").Value, 1)
                    XClaveRecibo = Mid(row.Cells("ClaveCheque").Value, 2, 10)

                    If Not IsNothing(row.Cells("ClaveCheque").Value) AndAlso Trim(row.Cells("ClaveCheque").Value) <> "" Then

                        If Val(WTipoRecibo) = 1 Then

                            ZSql = ""
                            ZSql = ZSql + "UPDATE Recibos SET "
                            ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                            ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                            ZSql = ZSql + " Where Clave = " + "'" + XClaveRecibo + "'"

                            WControlaMarcaRecibos(WIndiceMarca) = Microsoft.VisualBasic.Left$(XClaveRecibo, 6)

                        Else

                            Try
                                WReciboDefintivo = _BuscarReciboDefinitivo(XClaveRecibo)
                            Catch ex As Exception
                                If Not IsNothing(trans) Then
                                    trans.Rollback()
                                End If
                                MsgBox("Hubo un problema al consultar el numero de Recibo Provisorio Relacionado desde la base de datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
                                Exit Sub
                            End Try


                            ZSql = ""
                            ZSql = ZSql + "UPDATE RecibosProvi SET "
                            ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                            ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                            ZSql = ZSql + " Where Clave = " + "'" + XClaveRecibo + "'"

                        End If

                        Try

                            'cn.Open()
                            'trans = cn.BeginTransaction

                            cm.CommandText = ZSql
                            'cm.Transaction = trans
                            cm.ExecuteNonQuery()
                            'trans.Commit()

                        Catch ex As Exception
                            If Not IsNothing(trans) Then
                                trans.Rollback()
                            End If
                            MsgBox("Hubo un problema al querer actualizar el estado del cheque en el registro de Recibos Provisorios relacionado a este Depósito en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        Finally

                            'cn.Close()

                        End Try

                        If WReciboDefintivo <> 0 Then

                            ZSql = ""
                            ZSql = ZSql + "UPDATE Recibos SET "
                            ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                            ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                            ZSql = ZSql + " Where Recibo = " + "'" + Proceso.ceros(WReciboDefintivo, 6) + "' AND Numero2 = '" & WNumero2 & "'"

                            Try
                                'cn.Open()
                                'trans = cn.BeginTransaction

                                cm.CommandText = ZSql
                                'cm.Transaction = trans
                                cm.ExecuteNonQuery()
                                'trans.Commit()
                            Catch ex As Exception
                                If Not IsNothing(trans) Then
                                    trans.Rollback()
                                End If
                                MsgBox("Hubo un problema al querer actualizar el estado del Recibo Definitivo relacionado a este Depósito en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
                                Exit Sub
                            Finally

                                'cn.Close()

                            End Try

                        End If
                    End If

                    Dim WAux, WActualizaMarca

                    ' Controlamos las marcas de todos los recibos relacionado a este deposito.
                    For i = 0 To WIndiceMarca

                        Try

                            WAux = ""
                            WActualizaMarca = True

                            If Val(WControlaMarcaRecibos(i)) = 0 Then
                                Exit For
                            End If

                            ZSql = ""
                            ZSql = ZSql + "SELECT Estado2 FROM Recibos WHERE Recibo = '" & WControlaMarcaRecibos(i) & "' AND (TipoReg = '02' OR TipoReg = '2')"

                            cm.CommandText = ZSql
                            dr = cm.ExecuteReader()

                            If dr.HasRows Then
                                With dr
                                    Do While .Read()

                                        WAux = IIf(IsDBNull(.Item("Estado2")), "", .Item("Estado2"))

                                        If UCase(Trim(WAux)) <> "X" Then
                                            WActualizaMarca = False
                                            Exit Do
                                        End If

                                    Loop
                                End With
                            End If

                            dr.Close()

                            If WActualizaMarca Then
                                ZSql = ""
                                ZSql = ZSql + "UPDATE Recibos SET Marca = 'X', FechaDepo = '" & WFecha & "', FechaDepoOrd = '" & WFechaOrd & "' WHERE Recibo = '" & WControlaMarcaRecibos(i) & "'"

                                cm.CommandText = ZSql
                                cm.ExecuteNonQuery()

                            End If

                        Catch ex As Exception
                            If Not IsNothing(trans) Then
                                trans.Rollback()
                            End If

                            MsgBox("Hubo un problema al querer actualizar las marcas de los recibos relacionados a este deposito." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        Finally
                            dr = Nothing
                        End Try

                    Next

                End If
            Next

            dr = Nothing
            cn = Nothing
            cm = Nothing

            trans.Commit()

            'MsgBox("Deposito cargado con exito.", MsgBoxStyle.Information)

            btnImpresion.PerformClick()

            btnLimpiar_Click(sender, e)
        Else
            txtNroDeposito.Focus()
        End If
    End Sub
    
    Private Function _BuscarReciboDefinitivo(ByVal xclaverecibo) As Integer
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ReciboDefinitivo FROM RecibosProvi WHERE Clave = '" & xclaverecibo & "'")
        Dim dr As SqlDataReader

        Try

            SQLConnector.conexionSql(cn, cm)

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                'Return IIf(IsDBNull(dr.Item("ReciboDefintivo")), 0, Val(dr.Item("ReciboDefinitivo")))
                Return Val(dr.Item("ReciboDefinitivo"))

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return 0
    End Function

    Private Sub txtCodigoBanco_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBanco.DoubleClick
        lstSeleccion.SelectedIndex = 0
        btnConsulta_Click(sender, e)
        lstSeleccion_Click(sender, e)
    End Sub

    Private Sub txtNroDeposito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroDeposito.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtNroDeposito.Text) = "" Then
                Exit Sub
            End If

            Dim numero As String = ceros(txtNroDeposito.Text, 6)

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("")
            Dim dr As SqlDataReader
            Dim WDeposito, WRenglon, WBanco, WFecha, WImporte, WFechaAcredita, WTipo2, WNumero2, WFecha2, WImporte2, WObservaciones2, rowIndex

            btnLimpiar.PerformClick()

            txtNroDeposito.Text = numero
            'Dim deposito As Deposito = DAODeposito.buscarDeposito(txtNroDeposito.Text)

            Try

                cn.ConnectionString = Proceso._ConectarA
                cn.Open()
                cm.Connection = cn
                cm.CommandText = "SELECT * FROM Depositos WHERE Deposito = '" & Trim(txtNroDeposito.Text) & "' ORDER BY Renglon"

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    Do While dr.Read()

                        With dr
                            WDeposito = txtNroDeposito.Text
                            WRenglon = IIf(IsDBNull(.Item("Renglon")), "0", Trim(.Item("Renglon")))
                            WBanco = IIf(IsDBNull(.Item("Banco")), "", Trim(.Item("Banco")))
                            WFecha = IIf(IsDBNull(.Item("Fecha")), "", Trim(.Item("Fecha")))
                            WImporte = IIf(IsDBNull(.Item("Importe")), "0", Proceso.formatonumerico(.Item("Importe")))
                            WFechaAcredita = IIf(IsDBNull(.Item("Acredita")), "", Trim(.Item("Acredita")))
                            WTipo2 = IIf(IsDBNull(.Item("Tipo2")), "", Trim(.Item("Tipo2")))
                            WNumero2 = IIf(IsDBNull(.Item("Numero2")), "", Trim(.Item("Numero2")))
                            WFecha2 = IIf(IsDBNull(.Item("Fecha2")), "", Trim(.Item("Fecha2")))
                            WImporte2 = IIf(IsDBNull(.Item("Importe2")), "0", Proceso.formatonumerico(Trim(.Item("Importe2"))))
                            WObservaciones2 = IIf(IsDBNull(.Item("Observaciones2")), "", Trim(.Item("Observaciones2")))

                            If Val(WRenglon) = 1 Then
                                txtNroDeposito.Text = WDeposito
                                txtFecha.Text = WFecha
                                txtCodigoBanco.Text = WBanco
                                txtFechaAcreditacion.Text = WFechaAcredita
                                txtImporte.Text = WImporte
                            End If

                            rowIndex = _TraerProximaFila()

                            With gridCheques.Rows(rowIndex)

                                .Cells(0).Value = WTipo2
                                .Cells(1).Value = WNumero2
                                .Cells(2).Value = WFecha2
                                .Cells(3).Value = WObservaciones2
                                .Cells(4).Value = WImporte2

                            End With

                        End With


                    Loop
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la informacion del Depósito indicado desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, vbExclamation)
                Exit Sub
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

            'If Not IsNothing(deposito) Then
            'mostrarDeposito(Deposito)
            'Else
            'btnLimpiar.PerformClick()
            txtNroDeposito.Text = numero
            txtFecha.Focus()
            'End If
        ElseIf e.KeyData = Keys.Escape Then
            txtNroDeposito.Text = ""
        End If

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCodigoBanco.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If
    End Sub

    Private Sub txtCodigoBanco_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoBanco.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigoBanco.Text)
            If Not IsNothing(banco) Then
                txtDescripcionBanco.Text = banco.nombre
                txtFechaAcreditacion.Focus()
            Else
                txtDescripcionBanco.Text = ""
                lstSeleccion.SelectedIndex = 0
                btnConsulta_Click(sender, e)
                lstSeleccion_Click(sender, e)
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoBanco.Text = ""
            txtDescripcionBanco.Text = ""
        End If
    End Sub

    Private Sub txtFechaAcreditacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAcreditacion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtImporte.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAcreditacion.Clear()
        End If
    End Sub

    Private Sub txtImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporte.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtImporte.Text) = "" Then
                txtImporte.Text = "0"
            End If

            txtImporte.Text = Proceso.formatonumerico(txtImporte.Text)
            gridCheques.CurrentCell = gridCheques.Rows(0).Cells(0)
            gridCheques.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtImporte.Text = ""
        End If
    End Sub

    Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
        Try
            _ImprimirDeposito()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub _ImprimirDeposito()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New DepositoBancario
        Dim WDeposito, WRenglon, WFecha, WBanco, WNombre, WTotal, WTitulo, WTipo, WNumero, WImporte, WDescripcion, XTipo
        Dim XRenglon As Integer = 0

        WDeposito = ""
        WRenglon = ""
        WFecha = ""
        WBanco = ""
        WNombre = ""
        WTotal = 0.0
        WTitulo = ""
        WTipo = ""
        WNumero = ""
        WBanco = ""
        WImporte = 0.0
        WDescripcion = ""
        XTipo = 0

        ' Preparamos las columnas.
        With Tabla
            .Columns.Add("Deposito")
            .Columns.Add("Renglon")
            .Columns.Add("Fecha")
            .Columns.Add("Banco")
            .Columns.Add("Nombre")
            .Columns.Add("Total").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Titulo")
            .Columns.Add("Tipo")
            .Columns.Add("Numero")
            .Columns.Add("Importe").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Descripcion")
        End With


        WDeposito = Trim(txtNroDeposito.Text)
        WFecha = txtFecha.Text
        WBanco = Trim(txtCodigoBanco.Text)
        WNombre = Trim(txtDescripcionBanco.Text)
        WTotal = Val(Proceso.formatonumerico(txtImporte.Text))
        WTitulo = "SURFACTAN S.A"

        ' CAMBIAMOS EL CUIT SEGUN SEA O NO PELLITAL
        If Proceso._EsPellital() Then
            'WEmpCuit = "30-61052459-8"
            WTitulo = "PELLITAL S.A."
        End If

        For iRow = 0 To gridCheques.Rows.Count - 1

            With gridCheques.Rows(iRow)

                If Not IsNothing(.Cells(0).Value) Then

                    XRenglon += 1
                    WRenglon = ceros(XRenglon, 2)

                    WTipo = ""
                    WNumero = ""
                    WImporte = 0.0
                    WDescripcion = ""

                    XTipo = Val(.Cells(0).Value)

                    Select Case XTipo
                        Case 1
                            WTipo = "Efectivo"
                        Case 3
                            WTipo = "Cheque"
                            WNumero = .Cells(1).Value
                            WDescripcion = .Cells(3).Value.ToString.Split("/")(0)
                        Case Else
                            Throw New Exception("No se ha podido identificar el Tipo de Depósito.")
                    End Select

                    WImporte = Val(Proceso.formatonumerico(.Cells(4).Value))

                    row = Tabla.NewRow

                    row.Item("Deposito") = WDeposito
                    row.Item("Renglon") = WRenglon
                    row.Item("Fecha") = WFecha
                    row.Item("Banco") = WBanco
                    row.Item("Nombre") = WNombre
                    row.Item("Total") = Val(WTotal)
                    row.Item("Titulo") = WTitulo
                    row.Item("Tipo") = WTipo
                    row.Item("Numero") = WNumero
                    row.Item("Banco") = WBanco
                    row.Item("Importe") = Val(WImporte)
                    row.Item("Descripcion") = WDescripcion

                    Tabla.Rows.Add(row)

                End If

            End With

        Next

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .Reporte = crdoc
            '.Mostrar()
            .Imprimir()
        End With

        If Not Proceso._EsPellital() Then

            crdoc = New DepositoBancario2

            crdoc.SetDataSource(Tabla)

            With VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir()
            End With

        End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With gridCheques
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex

                'If Val(.Rows(iRow).Cells(0).Value) = 3 Then
                '    .Rows(iRow).Cells(4).ReadOnly = True
                'Else
                '    .Rows(iRow).Cells(4).ReadOnly = False
                'End If

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Dim valor = .Rows(iRow).Cells(iCol).Value

                    If Not IsNothing(valor) Then

                        If iCol = 0 And iRow > -1 Then
                            If Trim(valor.ToString.Length) = 31 Then
                                .Rows(iRow).Cells(5).Value = valor
                                If _ProcesarCheque(iRow, valor) Then
                                    '.CurrentCell = .Rows(iRow).Cells(4)
                                    .CurrentCell = .Rows(.Rows.Add()).Cells(0)

                                    sumarImportes()
                                Else
                                    .Rows(iRow).Cells(iCol).Value = ""
                                    .CurrentCell = .Rows(iRow).Cells(iCol + 1) ' Sólo para que refresque los datos de la celda 0, sino sigue la cadena hasta que se abandona la celda.
                                    .CurrentCell = .Rows(iRow).Cells(iCol)
                                End If
                            Else

                                Select Case Val(valor)
                                    Case 1
                                        .Rows(iRow).Cells("importe").Value = txtImporte.Text

                                        If iRow + 1 > .Rows.Count - 1 Then
                                            .Rows.Add()
                                        End If
                                        .CurrentCell = .Rows(iRow + 1).Cells(0)
                                    Case 2
                                        .CurrentCell = .Rows(iRow).Cells(4)
                                    Case 3
                                        .CurrentCell.Value = ""
                                        btnChequeTerceros.PerformClick()
                                End Select

                            End If

                            Return True
                        End If

                    End If

                    If iCol = 1 Or iCol = 2 Or iCol = 3 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    If iCol = 4 Then

                        If valor <> "" Then
                            .Rows(iRow).Cells(iCol).Value = _NormalizarNumero(valor)

                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                .CurrentCell = .Rows(.Rows.Add()).Cells(0)
                            End Try

                            sumarImportes()
                        End If

                    End If

                    Return True
                End If
            End If
        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _NormalizarNumero(ByVal numero As String)
        'Return _NormalizarNumero(numero, 2)
        Return Proceso.formatonumerico(numero)
    End Function

    '    Private Function _NormalizarNumero(ByVal numero As String, ByVal decimales As Integer)
    '        'Return CustomConvert.asStringWithDecimalPlaces(numero, decimales)
    '        Return Proceso.formatonumerico(numero, decimales)
    '    End Function

    '    Private Function _ObtenerNombreBanco(ByVal claveBanco As String) As String
    '        Dim _NombreBanco As String = ""
    '        Dim cn As SqlConnection = New SqlConnection()
    '        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM BCRA WHERE Banco = '" & Val(claveBanco) & "'")
    '        Dim dr As SqlDataReader
    '
    '        SQLConnector.conexionSql(cn, cm)
    '
    '        Try
    '
    '            dr = cm.ExecuteReader()
    '
    '            If dr.HasRows Then
    '
    '                dr.Read()
    '
    '                _NombreBanco = Trim(UCase(dr.Item("Nombre")))
    '
    '            End If
    '
    '        Catch ex As Exception
    '            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
    '        Finally
    '
    '            dr = Nothing
    '            cn.Close()
    '            cn = Nothing
    '            cm = Nothing
    '
    '        End Try
    '
    '        Return _NombreBanco
    '    End Function

    Private Function _FormatoValidoDeCheque(ByVal ClaveCheque As String) As Boolean
        Dim valido = False

        ClaveCheque = UCase(Trim(ClaveCheque))

        If ClaveCheque.Length = 31 And Mid(ClaveCheque, 1, 1) = "C" And Mid(ClaveCheque, ClaveCheque.Length, 1) = "E" Then
            valido = True
        End If

        Return valido
    End Function

    Private Function _BuscarClaveRecibo(ByVal Clavecheque) As String
        Dim clave As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM Recibos WHERE ClaveCheque = '" & Clavecheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr
                    clave = IIf(Not IsDBNull(.Item("Clave")), "1" & .Item("Clave"), "")
                End With

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try


        If clave = "" Then
            Try
                cn.Open()
                cm.CommandText = "SELECT Clave FROM RecibosProvi WHERE ClaveCheque = '" & Clavecheque & "'"
                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    dr.Read()

                    With dr
                        clave = IIf(Not IsDBNull(.Item("Clave")), "2" & .Item("Clave"), "")
                    End With

                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        End If

        cn = Nothing
        cm = Nothing
        dr = Nothing

        Return clave
    End Function

    Private Function _ProcesarCheque(ByVal row As Integer, ByVal ClaveCheque As String) As Boolean

        Dim WNumero, WFecha, WBanco, WImporte, WClave As String
        Dim _LecturaCorrecta As Boolean = True
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader


        If Not _FormatoValidoDeCheque(ClaveCheque) Then
            MsgBox("El formato del cheque no es valido.", MsgBoxStyle.Exclamation)
            Return False
        End If

        WClave = _BuscarClaveRecibo(ClaveCheque)

        ' Chequeamos que el cheque no se haya cargado.

        If _ChequeYaCargado(WClave, row) Then
            _LecturaCorrecta = False

            MsgBox("Cheque ya Cargado con anterioridad.", MsgBoxStyle.Exclamation)

            Return _LecturaCorrecta
        End If

        SQLConnector.conexionSql(cn, cm)
        Dim _Tabla As String = "Recibos"


        If Mid(WClave, 1, 1) = "2" Then
            _Tabla = "RecibosProvi"
        End If

        Try
            cm.CommandText = "SELECT Numero2, Fecha2, Importe2, Banco2 FROM " & _Tabla & " WHERE ClaveCheque = '" & ClaveCheque & "' AND Estado2 = 'P'"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr
                    WNumero = .Item("Numero2")
                    WFecha = .Item("Fecha2")
                    WImporte = Proceso.formatonumerico(.Item("Importe2"))
                    WBanco = .Item("Banco2")
                End With
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Return False
        Finally

            cn.Close()

        End Try

        If _LecturaCorrecta Then
            With gridCheques.Rows(row)
                .Cells(0).Value = "3"
                .Cells(1).Value = WNumero
                .Cells(2).Value = WFecha
                .Cells(3).Value = WBanco
                .Cells(4).Value = WImporte
                .Cells(5).Value = WClave
            End With
        Else
            MsgBox("Hubo un problema al querer cargar el cheque correspondiente.", MsgBoxStyle.Exclamation)
        End If

        Return _LecturaCorrecta
    End Function
    
    Private Function _ChequeYaCargado(ByVal ClaveCheque As String, ByVal rowIndex As Integer) As Boolean

        Return gridCheques.Rows.Cast(Of DataGridViewRow)().Any(Function(row) ClaveCheque = row.Cells("ClaveCheque").Value And row.Index <> rowIndex)
    End Function

    Private Sub Depositos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtNroDeposito.Focus()
    End Sub

    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
        Dim final As ListBox = lstFiltrado
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrado.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = lstFiltrado
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub txtFecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFecha.TypeValidationCompleted
        e.Cancel = Not Proceso._ValidarFecha(txtFecha.Text, e.IsValidInput)
    End Sub

    Private Sub txtFechaAcreditacion_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaAcreditacion.TypeValidationCompleted
        e.Cancel = Not Proceso._ValidarFecha(txtFechaAcreditacion.Text, e.IsValidInput)
    End Sub

    Private Sub btnChequeTerceros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChequeTerceros.Click
        lstSeleccion.SelectedItem = "Cheques de Terceros"
        lstSeleccion_Click(Nothing, Nothing)
    End Sub

    Private Sub txtImporte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.Leave
        txtImporte.Text = Proceso.formatonumerico(txtImporte.Text)
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDeposito.KeyPress, txtCodigoBanco.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporte.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

End Class