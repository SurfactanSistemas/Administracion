Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Depositos
    Dim dataGridBuilder As GridBuilder
    Dim showFunction As ShowMethod
    Dim cheques As New List(Of Cheque)
    Private _ClavesCheques As New List(Of Object)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dataGridBuilder = New GridBuilder(gridCheques)
        dataGridBuilder.addTextColumn(0, "Tipo")
        dataGridBuilder.addTextColumn(1, "Número")
        dataGridBuilder.addDateColumn(2, "Fecha")
        dataGridBuilder.addTextColumn(3, "Nombre")
        dataGridBuilder.addPositiveFloatColumn(4, "Importe")

        Dim commonEventsHandler As New CommonEventsHandler
        commonEventsHandler.setIndexTab(Me)
        btnLimpiar.PerformClick()
    End Sub

    Private Function sumaImportes() As Double
        Dim valorImportes As Double = 0
        For Each row As DataGridViewRow In gridCheques.Rows
            valorImportes += row.Cells(4).Value
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

        validador.validate(Me)
        validador.alsoValidate(CustomConvert.toDoubleOrZero(txtImporte.Text) = Math.Round(sumaImportes(), 2), "El campo importe tiene que ser igual a la suma de la grilla (" & sumaImportes() & ")")
        validador.alsoValidate(validarTipoUnico(), "Sólo puede realizarse un tipo de depósito por carga")
        validador.alsoValidate(validarEstadoGrilla(), "Hay campos en la grilla con estados inválidos")
        validador.alsoValidate(Not DAODeposito.existeDepositoNumero(txtNroDeposito.Text), "Ya existe un depósito con número " & txtNroDeposito.Text)

        Return validador.flush
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Cleanner.clean(Me)
        lstSeleccion.SelectedIndex = 0
        txtFecha.Text = Date.Today
        txtFechaAcreditacion.Text = Date.Today
        txtNroDeposito.Text = ceros(DAODeposito.siguienteNumero(), 6)
        gridCheques.Rows.Clear()
        cheques.Clear()
        gridCheques.AllowUserToAddRows = True
        gridCheques.Columns(0).ReadOnly = False
        gridCheques.Columns(4).ReadOnly = False
        sumarImportes()
        _ClavesCheques.Clear()
    End Sub

    Private Sub sumarImportes()
        lblTotal.Text = CustomConvert.toStringWithTwoDecimalPlaces(sumaImportes)
    End Sub

    Private Sub mostrarSeleccionDeConsulta()
        lstConsulta.Visible = False
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
            txtImporte.Text = CustomConvert.toStringWithTwoDecimalPlaces(deposito.importeTotal)
            For Each item As ItemDeposito In deposito.items
                If item.tipo = 3 Then
                    mostrarCheque(item)
                Else
                    gridCheques.Rows.Add(item.tipo, item.numero, item.fecha, item.nombre, item.importe, "")
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
        If IsNothing(cheque) Then : Exit Sub
        End If
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
                gridCheques.Rows.Add(3, cheque.numero, cheque.fecha, cheque.banco, CustomConvert.toStringWithTwoDecimalPlaces(cheque.importe))
                gridCheques.AllowUserToAddRows = False
                gridCheques.Columns(0).ReadOnly = True
                gridCheques.Columns(4).ReadOnly = True
                lstConsulta.Items.Remove(lstConsulta.SelectedItem)
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
            DAODeposito.buscarCheques().ForEach(Sub(cheque) lstConsulta.Items.Add(cheque))
        End If
        lstSeleccion.Visible = False
        lstConsulta.Visible = True
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click
        showFunction.Invoke(lstConsulta.SelectedItem)
        If lstSeleccion.SelectedItem = "Bancos" Then
            lstConsulta.Visible = False
            txtCodigoBanco.Focus()
        End If
    End Sub

    Private Sub gridCheques_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCheques.CellValueChanged
        sumarImportes()
    End Sub

    Private Sub gridCheques_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridCheques.UserAddedRow
        sumarImportes()
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
            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigoBanco.Text)
            Dim deposito As Deposito = New Deposito(txtNroDeposito.Text, banco, txtFecha.Text, txtFechaAcreditacion.Text, txtImporte.Text)
            If cheques.Count > 0 Then
                Dim chequesADepositar As New List(Of ItemDeposito)
                cheques.ForEach(Sub(cheque) chequesADepositar.Add(cheque))
                DAODeposito.agregarDeposito(deposito, chequesADepositar)
            Else
                DAODeposito.agregarDeposito(deposito, gridCheques.Rows)
            End If
            btnLimpiar_Click(sender, e)
        End If
    End Sub

    Private Sub txtCodigoBanco_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoBanco.Leave
        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtCodigoBanco.Text)
        If Not IsNothing(banco) Then
            txtDescripcionBanco.Text = banco.nombre
        Else
            txtDescripcionBanco.Text = ""
        End If
    End Sub

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

        End If

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCodigoBanco.Focus()
        End If
    End Sub

    Private Sub txtCodigoBanco_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoBanco.KeyDown
        If e.KeyData = Keys.Enter Then
            txtFechaAcreditacion.Focus()
        End If
    End Sub

    Private Sub txtFechaAcreditacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAcreditacion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtImporte.Focus()
        End If
    End Sub

    Private Sub txtImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporte.KeyDown
        If e.KeyData = Keys.Enter Then
            gridCheques.CurrentCell = gridCheques.Rows(0).Cells(0)
        End If
    End Sub

    Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
        _ImprimirDeposito()
    End Sub

    Private Sub _ImprimirDeposito()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New DepositoBancario
        Dim WDeposito, WRenglon, WFecha, WBanco, WNombre, WTotal, WTitulo, WTipo, WNumero, WImporte, WDescripcion As String
        Dim XRenglon As Integer = 0

        WDeposito = ""
        WRenglon = ""
        WFecha = ""
        WBanco = ""
        WNombre = ""
        WTotal = ""
        WTitulo = ""
        WTipo = ""
        WNumero = ""
        WBanco = ""
        WImporte = ""
        WDescripcion = ""

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
        WTotal = Trim(txtImporte.Text)
        WTitulo = "SURFACTAN S.A"

        For iRow = 0 To gridCheques.Rows.Count - 1

            With gridCheques.Rows(iRow)

                XRenglon += 1
                WRenglon = ceros(XRenglon, 2)

                WTipo = ""
                WNumero = ""
                WImporte = ""
                WDescripcion = ""

                Select Case Val(.Cells(0).Value)
                    Case 1
                        WTipo = "Efectivo"
                        WBanco = ""
                        WNombre = ""
                    Case 2
                        WTipo = "Dólares"
                        WBanco = ""
                        WNombre = ""
                    Case Else
                        WTipo = "Cheque"
                        WNumero = .Cells(1).Value
                        WDescripcion = .Cells(3).Value.ToString.Split("/")(0)
                End Select

                WImporte = CDbl(.Cells(4).Value)

                row = Tabla.NewRow

                row.Item("Deposito") = WDeposito
                row.Item("Renglon") = WRenglon
                row.Item("Fecha") = WFecha
                row.Item("Banco") = WBanco
                row.Item("Nombre") = WNombre
                row.Item("Total") = CDbl(WTotal)
                row.Item("Titulo") = WTitulo
                row.Item("Tipo") = WTipo
                row.Item("Numero") = WNumero
                row.Item("Banco") = WBanco
                row.Item("Importe") = CDbl(WImporte)
                row.Item("Descripcion") = WDescripcion

                Tabla.Rows.Add(row)

            End With

        Next

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With

        crdoc = New DepositoBancario2

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With gridCheques
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Dim valor = .Rows(iRow).Cells(iCol).Value

                    If Not IsNothing(valor) Then

                        If iCol = 0 And iRow > -1 Then
                            If Trim(valor.ToString.Length) = 31 Then
                                If _ProcesarCheque(iRow, valor) Then
                                    '.CurrentCell = .Rows(iRow).Cells(iCol + 2)
                                End If
                            Else
                                valor = valor.ToString().Substring(valor.ToString.Length - 1, 1)
                                If valor = "1" Or valor = "2" Or valor = "3" Or valor = "4" Then
                                    'eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow, iCol)
                                Else ' Sólo se aceptan los valores 1 (Efectivo) , 2 (Cheque), 3 (Doc) y 4 (Varios) ?
                                    .CurrentCell = .Rows(iRow).Cells(iCol)
                                End If
                            End If

                            Return True
                        End If

                    End If


                    If iCol = 3 Then
                        If .Rows(iRow).Cells(0).Value = "02" Then
                            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(valor)
                            If Not IsNothing(banco) Then
                                .Rows(iRow).Cells(iCol + 1).Value = banco.nombre
                                iCol = 4 ' Desplazamos a ultima fila.
                            Else
                                MsgBox("Codigo de Banco Incorrecto.", MsgBoxStyle.Information)
                                Return True ' Nos quedamos en la celda.
                            End If
                        End If
                    End If

                    If iCol = 2 And valor <> "" Then
                        valor = _Normalizarfecha(valor)

                        If Not _ValidarFecha(valor, True) Then
                            Return True
                        End If

                        .Rows(iRow).Cells(iCol).Value = valor
                    End If

                    If iCol = 1 Or iCol = 2 Or iCol = 3 Or iCol = 4 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    If iCol = 5 Then

                        If valor <> "" Then
                            .Rows(iRow).Cells(iCol).Value = _NormalizarNumero(valor)
                            .CurrentCell = .Rows(.Rows.Add()).Cells(0)
                        End If

                    End If

                    Return True
                End If
            End If
        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _NormalizarNumero(ByVal numero As String)
        Return _NormalizarNumero(numero, 2)
    End Function

    Private Function _NormalizarNumero(ByVal numero As String, ByVal decimales As Integer)
        Return CustomConvert.asStringWithDecimalPlaces(numero, decimales)
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

    Private Function _ProcesarCheque(ByVal row As Integer, ByVal ClaveCheque As String) As Boolean
        Dim _ClaveBanco, _Banco, _Sucursal, _NumCheque, _NumCta, _Cuit As String
        Dim _LecturaCorrecta As Boolean = True

        If Not _FormatoValidoDeCheque(ClaveCheque) Then
            MsgBox("El formato del cheque no es valido.", MsgBoxStyle.Exclamation)
            Return False
        End If

        _ClaveBanco = Mid$(ClaveCheque, 2, 3)
        _Banco = _ObtenerNombreBanco(_ClaveBanco)
        _Sucursal = Mid$(ClaveCheque, 5, 3)
        _NumCheque = Mid$(ClaveCheque, 12, 8)
        _NumCta = Mid$(ClaveCheque, 20, 11)

        ' Chequeamos que el cheque no se haya cargado.

        If _ChequeYaCargado(ClaveCheque) Then
            _LecturaCorrecta = False

            MsgBox("Cheque ya Cargado con anterioridad.", MsgBoxStyle.Exclamation)

            Return _LecturaCorrecta
        End If

        ' Extraer Datos del String.
        If _Banco = "" Then
            _LecturaCorrecta = False
            MsgBox("Error en la lectura de los datos del codigo de banco del cheque")
        End If

        With gridCheques.Rows(row)
            .Cells(0).Value = "03"
            .Cells(1).Value = _NumCheque
            .Cells(2).Value = ""
            .Cells(4).Value = _Banco '_GenerarCodigoBanco(_Banco)
        End With
        ' Buscamos si existe el cuit.
        _Cuit = _TraerNumeroCuit(_ClaveBanco & _Sucursal & _NumCta)

        ' Guardamos el nuevo Cheque.
        _GuardarNuevoCheque(row, ClaveCheque, _Banco, _Sucursal, _NumCheque, _NumCta, _Cuit)

        Return _LecturaCorrecta
    End Function

    'Private Function _GenerarCodigoBanco(ByVal _Banco As String) As String
    '    _Banco = _Banco.ToString.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

    '    Return _Banco & "/" & Mid(txtCliente.Text, 1, 1) & Val(Mid(txtCliente.Text, 2, 6)).ToString()
    'End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque) As Boolean
        Dim _cargado As Boolean = False

        If _ChequeUtilizadoEnRecibo(ClaveCheque) Then

            _cargado = True

        ElseIf _ChequeUtilizadoEnReciboProvisorio(ClaveCheque) Then

            _cargado = True

        Else

            Dim cheque As Object = _ClavesCheques.FindLast(Function(c) c(1) = ClaveCheque)
            If Not IsNothing(cheque) Then
                _cargado = True
            End If

        End If

        Return _cargado
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
End Class