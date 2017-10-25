Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Depositos
    Dim dataGridBuilder As GridBuilder
    Dim showFunction As ShowMethod
    Dim cheques As New List(Of Cheque)
    Private _ClavesCheques As New List(Of Object)
    Private WClaveCheques(1000) As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dataGridBuilder = New GridBuilder(gridCheques)
        'dataGridBuilder.addTextColumn(0, "Tipo")
        'dataGridBuilder.addTextColumn(1, "Número")
        'dataGridBuilder.addDateColumn(2, "Fecha")
        'dataGridBuilder.addTextColumn(3, "Nombre")
        'dataGridBuilder.addPositiveFloatColumn(4, "Importe")

        'Dim commonEventsHandler As New CommonEventsHandler
        'commonEventsHandler.setIndexTab(Me)
        btnLimpiar.PerformClick()
    End Sub

    Private Function sumaImportes() As Double
        Dim valorImportes As Double = 0
        For Each row As DataGridViewRow In gridCheques.Rows
            valorImportes += Val(Proceso.formatonumerico(row.Cells(4).Value))
        Next
        Return valorImportes
    End Function

    Private Function validarTipoUnico() As Boolean
        Dim bool As Boolean = True
        Dim tipo As Integer
        If gridCheques.Rows.Count > 0 Then
            tipo = gridCheques.Rows(0).Cells(0).Value
        Else
            Return True
        End If
        For Each row As DataGridViewRow In gridCheques.Rows
            If tipo <> row.Cells(0).Value Then
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
        validador.alsoValidate(validarTipoUnico(), "Sólo puede realizarse un tipo de depósito por carga")
        validador.alsoValidate(validarEstadoGrilla(), "Hay campos en la grilla con estados inválidos")
        validador.alsoValidate(Not DAODeposito.existeDepositoNumero(txtNroDeposito.Text), "Ya existe un depósito con número " & txtNroDeposito.Text)

        Return validador.flush
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'Cleanner.clean(Me)
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
        'gridCheques.AllowUserToAddRows = True
        'gridCheques.Columns(0).ReadOnly = False
        'gridCheques.Columns(4).ReadOnly = False
        lstConsulta.Visible = False
        lstSeleccion.Visible = False
        lstFiltrado.Visible = False
        txtAyuda.Text = ""
        txtAyuda.Visible = False
        sumarImportes()
        _ClavesCheques.Clear()
        txtNroDeposito.Focus()
    End Sub

    Private Sub sumarImportes()
        lblTotal.Text = Proceso.formatonumerico(sumaImportes) 'CustomConvert.toStringWithTwoDecimalPlaces(sumaImportes)
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

    Private Sub mostrarDeposito(ByVal deposito As Deposito)
        If IsNothing(deposito) Then
            'Cleanner.cleanWithoutChangeFocus(Me)
            btnLimpiar.PerformClick()
        Else
            _ClavesCheques.Clear()
            txtFecha.Text = deposito.fecha
            mostrarBanco(deposito.banco)
            txtFechaAcreditacion.Text = deposito.fechaAcreditacion
            txtImporte.Text = _NormalizarNumero(deposito.importeTotal)
            For Each item As ItemDeposito In deposito.items
                If item.tipo = 3 Then
                    mostrarCheque(item)
                Else
                    gridCheques.Rows.Add(item.tipo, item.numero, item.fecha, item.nombre, _NormalizarNumero(item.importe), "")
                End If
            Next

        End If
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
        Dim msgBoxResult As Boolean = True

        If IsNothing(cheque) Then : Exit Sub : End If

        If Not cheques.Any(Function(otroCheque) otroCheque.igualA(cheque)) Then
            If gridCheques.AllowUserToAddRows Then
                If gridCheques.Rows.Count > 1 Then
                    msgBoxResult = MsgBox("Si agrega un cheque se borrarán todos los datos de la grilla. ¿Desea agregarlo igual?", vbYesNo, "Agregar Cheque") = vbYes
                    If msgBoxResult Then
                        gridCheques.Rows.Clear()
                    End If
                End If
            End If
            If msgBoxResult Then
                cheques.Add(cheque)
                Dim rowIndex = gridCheques.Rows.Add(3, cheque.numero, cheque.fecha, cheque.banco, _NormalizarNumero(cheque.importe))
                'gridCheques.AllowUserToAddRows = False
                'gridCheques.Columns(0).ReadOnly = True
                'gridCheques.Columns(4).ReadOnly = True
                'lstConsulta.Items.Remove(lstConsulta.SelectedItem)
            End If
            sumarImportes()
        End If
    End Sub

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

                        '_ChequesRecibos.Add({item, _
                        '                     "1" & .Item("Clave"), _
                        '                     IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), "") _
                        '                    })

                        _ChequesRecibos.Add({item, New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Val(Proceso.formatonumerico(dr.Item("Importe2"))), dr.Item("banco2"), "1" & dr.Item("Clave"), dr.Item("ClaveCheque"))})

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
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

                        '_ChequesRecibos.Add({item, _
                        '                     "2" & .Item("Clave"), _
                        '                     IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), ""), _
                        '                     ceros(.Item("Numero2"), 6), _
                        '                     .Item("Fecha2")
                        '                    })

                        _ChequesRecibos.Add({item, New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Val(Proceso.formatonumerico(dr.Item("Importe2"))), dr.Item("banco2"), "2" & dr.Item("Clave"), dr.Item("ClaveCheque"))})

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _ChequesRecibos
    End Function

    Private Sub _ListarCheques()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Numero2, Importe2, Fecha2, Banco2, Clave, FechaOrd2, Estado2 FROM Recibos WHERE Estado2 = 'P' AND (Tipo2 = '02' OR Tipo2 = '2') AND TipoReg = '2'")
        Dim dr As SqlDataReader

        Dim cheques As New List(Of Cheque)
        Dim chequesOrdenados As List(Of Cheque)

        SQLConnector.conexionSql(cn, cm)

        ' Listamos Cheques pendientes en Recibos Definitivos.
        Try

            dr = cm.ExecuteReader()

            lstConsulta.Items.Clear()

            If dr.HasRows Then

                Do While dr.Read()
                    cheques.Add(New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Val(Proceso.formatonumerico(dr.Item("Importe2"))), dr.Item("banco2"), "1" & dr.Item("Clave")))
                Loop
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try


        ' Listamos Cheques pendientes en Recibos Provisorios.
        Try
            cm.CommandText = "SELECT Numero2, Importe2, Fecha2, Banco2, Clave, FechaOrd2, Estado2, ReciboDefinitivo FROM RecibosProvi WHERE Estado2 = 'P' AND (Tipo2 = '02' OR Tipo2 = '2') AND TipoReg = '2' and ReciboDefinitivo = '0'"
            cn.Open()

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    If Not _ChequeUtilizadoEnRecibo(dr.Item("Numero2"), dr.Item("Fecha2")) Then
                        cheques.Add(New Cheque(dr.Item("Numero2").ToString, dr.Item("Fecha2").ToString, Proceso.formatonumerico(dr.Item("Importe2")), dr.Item("banco2"), "2" & dr.Item("Clave")))
                    End If

                Loop
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try


        chequesOrdenados = cheques.OrderBy(Function(c) c.Orden).ToList()

        For Each _cheque As Cheque In chequesOrdenados

            'If Not _ChequeUtilizadoEnRecibo(_cheque.clave) Then
            lstConsulta.Items.Add(_cheque)
            'End If

        Next

    End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        If IsNothing(lstConsulta.SelectedItem) Then : Exit Sub : End If

        If lstSeleccion.SelectedItem = "Bancos" Then
            lstConsulta.Visible = False
            txtAyuda.Visible = False
            txtCodigoBanco.Focus()
        Else

            Dim row As Integer = -1
            Dim cheq As Cheque

            cheq = lstConsulta.SelectedItem

            'showFunction.Invoke(lstConsulta.SelectedItem)

            For Each _row As DataGridViewRow In gridCheques.Rows
                If Not _row.IsNewRow Then
                    If _row.Cells(5).Value = cheq.ClaveCheque Then
                        lstConsulta.Items.Remove(lstConsulta.SelectedItem)
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

            If _ProcesarCheque(row, cheq.ClaveCheque) Then
                lstConsulta.Items.Remove(lstConsulta.SelectedItem)
                Dim nuevafila = gridCheques.Rows.Add()
                sumarImportes()
                gridCheques.CurrentCell = gridCheques.Rows(nuevafila).Cells(0)
                gridCheques.Focus()
            End If

            'txtAyuda.Focus()

        End If
    End Sub

    'Private Sub gridCheques_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCheques.CellValueChanged
    '    sumarImportes()
    'End Sub

    'Private Sub gridCheques_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridCheques.UserAddedRow
    '    sumarImportes()
    'End Sub

    Private Sub gridCheques_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles gridCheques.UserDeletingRow
        Dim chequeABorrar As Cheque = cheques.Find(Function(cheque) cheque.numero = e.Row.Cells(1).Value And cheque.fecha = e.Row.Cells(2).Value And cheque.banco = e.Row.Cells(3).Value And cheque.importe = e.Row.Cells(4).Value)
        If Not IsNothing(chequeABorrar) Then
            cheques.Remove(chequeABorrar)
        End If
        sumarImportes()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarCampos() Then
            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigoBanco.Text)
            Dim deposito As Deposito = New Deposito(txtNroDeposito.Text, banco, txtFecha.Text, txtFechaAcreditacion.Text, Val(Proceso.formatonumerico(txtImporte.Text)))

            If cheques.Count > 0 Then

                Dim chequesADepositar As New List(Of ItemDeposito)
                For Each _cheque As Cheque In cheques

                    _cheque.valorImporte = Val(Proceso.formatonumerico(_cheque.valorImporte))

                    chequesADepositar.Add(_cheque)

                Next

                Try
                    DAODeposito.agregarDeposito(deposito, chequesADepositar)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Exit Sub
                End Try

                ' Damos marcamos los cheques.
                _MarcarCheques(cheques)

            Else
                DAODeposito.agregarDeposito(deposito, gridCheques.Rows)
            End If

            MsgBox("Deposito cargado con exito.", MsgBoxStyle.Information)

            btnImpresion.PerformClick()

            btnLimpiar_Click(sender, e)
        End If
    End Sub

    Private Function _CS(Optional ByVal empresa As String = "SurfactanSA") As String
        
        Return Proceso._ConectarA(empresa)

    End Function

    Private Sub _MarcarCheques(ByVal WCheques As List(Of Cheque))
        Dim ZSql = "", XClaveRecibo = "", XObservaciones = "", WReciboDefintivo = 0
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand("")
        Dim trans As SqlTransaction

        If WCheques.Count <= 0 Then : Exit Sub : End If

        cn.ConnectionString = _CS()
        cm.Connection = cn

        For Each WCheque As Cheque In WCheques
            WReciboDefintivo = 0
            XObservaciones = Microsoft.VisualBasic.Left$("Deposito Nro : " + Str$(txtNroDeposito.Text) + " Banco : " + txtDescripcionBanco.Text, 50)
            XClaveRecibo = Mid(WCheque.clave, 2, 10)

            If WCheque.clave.StartsWith("1") Then

                ZSql = ""
                ZSql = ZSql + "UPDATE Recibos SET "
                ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                ZSql = ZSql + " Where Clave = " + "'" + XClaveRecibo + "'"

            Else

                Try
                    WReciboDefintivo = _BuscarReciboDefinitivo(XClaveRecibo)
                Catch ex As Exception
                    Throw New Exception("Hubo un problema al consultar la base de datos.")
                    Exit For
                End Try


                ZSql = ""
                ZSql = ZSql + "UPDATE RecibosProvi SET "
                ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                ZSql = ZSql + " Where Clave = " + "'" + XClaveRecibo + "'"

            End If

            Try

                cn.Open()
                trans = cn.BeginTransaction

                cm.CommandText = ZSql
                cm.Transaction = trans
                cm.ExecuteNonQuery()
                trans.Commit()

            Catch ex As Exception
                If Not IsNothing(trans) Then
                    trans.Rollback()
                End If
                Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
                Exit For
            Finally

                cn.Close()

            End Try

            If WReciboDefintivo <> 0 Then

                ZSql = ""
                ZSql = ZSql + "UPDATE Recibos SET "
                ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                ZSql = ZSql + "Destino = " + "'" + XObservaciones + "'"
                ZSql = ZSql + " Where Recibo = " + "'" + Proceso.ceros(WReciboDefintivo, 6) + "' AND Numero2 = '" & WCheque.numero & "'"

                Try
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.CommandText = ZSql
                    cm.Transaction = trans
                    cm.ExecuteNonQuery()
                    trans.Commit()
                Catch ex As Exception
                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If
                    Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
                    Exit For
                Finally

                    cn.Close()

                End Try

            End If

        Next

    End Sub

    Private Function _BuscarReciboDefinitivo(ByVal xclaverecibo) As Integer
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ReciboDefinitivo FROM RecibosProvi WHERE Recibo = '" & xclaverecibo & "'")
        Dim dr As SqlDataReader

        Try

            SQLConnector.conexionSql(cn, cm)

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("ReciboDefintivo")), 0, Val(dr.Item("ReciboDefinitivo")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
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
            txtNroDeposito.Text = numero
            Dim deposito As Deposito = DAODeposito.buscarDeposito(txtNroDeposito.Text)
            If Not IsNothing(deposito) Then
                mostrarDeposito(deposito)
            Else
                btnLimpiar.PerformClick()
                txtNroDeposito.Text = numero
                txtFecha.Focus()
            End If
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
                            Exit Sub
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
            .Mostrar()
        End With

        If XTipo = 3 Then

            crdoc = New DepositoBancario2

            crdoc.SetDataSource(Tabla)

            With VistaPrevia
                .Reporte = crdoc
                .Mostrar()
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
                                    Case 1, 2
                                        .CurrentCell = .Rows(iRow).Cells(4)
                                    Case 3
                                        .CurrentCell.Value = ""
                                        btnChequeTerceros.PerformClick()
                                    Case Else
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

    Private Function _NormalizarNumero(ByVal numero As String, ByVal decimales As Integer)
        'Return CustomConvert.asStringWithDecimalPlaces(numero, decimales)
        Return Proceso.formatonumerico(numero, decimales)
    End Function

    Private Function _ObtenerNombreBanco(ByVal claveBanco As String) As String
        Dim _NombreBanco As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM BCRA WHERE Banco = '" & Val(claveBanco) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                _NombreBanco = Trim(UCase(dr.Item("Nombre")))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _NombreBanco
    End Function

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

        If _ChequeYaCargado(ClaveCheque, row) Then
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
                .Cells(0).Value = "03"
                .Cells(1).Value = WNumero
                .Cells(2).Value = WFecha
                .Cells(3).Value = WBanco
                .Cells(4).Value = WImporte
                .Cells(5).Value = WClave
            End With
        End If

        Return _LecturaCorrecta
    End Function

    'Private Function _GenerarCodigoBanco(ByVal _Banco As String) As String
    '    _Banco = _Banco.ToString.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

    '    Return _Banco & "/" & Mid(txtCliente.Text, 1, 1) & Val(Mid(txtCliente.Text, 2, 6)).ToString()
    'End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque As String, ByVal rowIndex As Integer) As Boolean
        Dim _cargado As Boolean = False

        For Each row As DataGridViewRow In gridCheques.Rows

            If ClaveCheque = row.Cells(5).Value And row.Index <> rowIndex Then
                _cargado = True
                Exit For
            End If

        Next

        Return _cargado
    End Function

    Private Function _ChequeUtilizadoEnRecibo(ByVal numero2 As String, ByVal fecha2 As String) As Boolean
        Dim utilizado As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Numero2 FROM Recibos WHERE Numero2 = '" & Trim(numero2) & "' AND Fecha2 = '" & Trim(fecha2) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                utilizado = True
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return utilizado
    End Function

    Private Function _ChequeUtilizadoEnRecibo(ByVal ClaveCheque As String) As Boolean
        Dim utilizado As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 ClaveCheque FROM Recibos WHERE ClaveCheque = '" & ClaveCheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                utilizado = True
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return utilizado
    End Function

    Private Function _ChequeUtilizadoEnReciboProvisorio(ByVal ClaveCheque As String) As Boolean
        Dim utilizado As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 ClaveCheque FROM RecibosProvi WHERE ClaveCheque = '" & ClaveCheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                utilizado = True
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return utilizado
    End Function

    Private Function _TraerNumeroCuit(ByVal clave As String) As String
        Dim _cuit As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cuit FROM Cuit WHERE Clave = '" & Trim(clave) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _cuit = dr.Item("Cuit")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _cuit
    End Function


    Private Sub _GuardarNuevoCheque(ByVal row As Integer, ByVal Clave As String, _
                                    ByVal banco As String, ByVal sucursal As String, _
                                    ByVal numCheque As String, ByVal numCta As String, _
                                    ByVal _Cuit As String)

        _ClavesCheques.Add({row, Clave, banco, sucursal, numCheque, numCta, _Cuit, "", ""})

    End Sub

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