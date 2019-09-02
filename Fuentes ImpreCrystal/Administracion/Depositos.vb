Imports ClasesCompartidas

Public Class Depositos
    Dim dataGridBuilder As GridBuilder
    Dim showFunction As ShowMethod
    Dim cheques As New List(Of Cheque)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dataGridBuilder = New GridBuilder(gridCheques)
        dataGridBuilder.addTextColumn(0, "Tipo")
        dataGridBuilder.addTextColumn(1, "Número")
        dataGridBuilder.addDateColumn(2, "Fecha")
        dataGridBuilder.addTextColumn(3, "Nombre")
        dataGridBuilder.addPositiveFloatColumn(4, "Importe")
        lstSeleccion.SelectedIndex = 0
        Me.Width = formNormalWidth()
        Dim commonEventsHandler As New CommonEventsHandler
        commonEventsHandler.setIndexTab(Me)
        txtFecha.Text = Date.Today
        txtFechaAcreditacion.Text = Date.Today
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
        gridCheques.Rows.Clear()
        cheques.Clear()
        Me.Width = formNormalWidth()
        gridCheques.AllowUserToAddRows = True
        gridCheques.Columns(0).ReadOnly = False
        gridCheques.Columns(4).ReadOnly = False
        lblTotal.Text = sumaImportes()
    End Sub

    Private Sub mostrarSeleccionDeConsulta()
        lstConsulta.Visible = False
        lstSeleccion.Visible = True
        Me.Width = formWithListsWidth()
    End Sub

    Private Function formNormalWidth()
        Return 480
    End Function

    Private Function formWithListsWidth()
        Return 800
    End Function

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        mostrarSeleccionDeConsulta()
    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        txtCodigoBanco.Text = banco.id
        txtDescripcionBanco.Text = banco.nombre
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
                gridCheques.Rows.Add(3, cheque.numero, cheque.fecha, cheque.banco, cheque.importe)
                gridCheques.AllowUserToAddRows = False
                gridCheques.Columns(0).ReadOnly = True
                gridCheques.Columns(4).ReadOnly = True
                lstConsulta.Items.Remove(lstConsulta.SelectedItem)
            End If
            lblTotal.Text = sumaImportes()
        End If
    End Sub

    Private Sub lstSeleccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSeleccion.DoubleClick
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

    Private Sub lstConsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.DoubleClick
        showFunction.Invoke(lstConsulta.SelectedItem)
        If lstSeleccion.SelectedItem = "Bancos" Then
            lstConsulta.Visible = False
            Me.Width = formNormalWidth()
        End If
    End Sub

    Private Sub gridCheques_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCheques.CellValueChanged
        lblTotal.Text = sumaImportes()
    End Sub

    Private Sub gridCheques_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridCheques.UserAddedRow
        lblTotal.Text = sumaImportes()
    End Sub

    Private Sub gridCheques_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles gridCheques.UserDeletingRow
        Dim chequeABorrar As Cheque = cheques.Find(Function(cheque) cheque.numero = e.Row.Cells(1).Value And cheque.fecha = e.Row.Cells(2).Value And cheque.banco = e.Row.Cells(3).Value And cheque.importe = e.Row.Cells(4).Value)
        If Not IsNothing(chequeABorrar) Then
            cheques.Remove(chequeABorrar)
        End If
        lblTotal.Text = sumaImportes()
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

    Private Sub txtNroDeposito_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroDeposito.Leave
        txtNroDeposito.Text = ceros(txtNroDeposito.Text, 6)
    End Sub

    Private Sub txtCodigoBanco_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBanco.DoubleClick
        lstSeleccion.SelectedIndex = 0
        btnConsulta_Click(sender, e)
        lstSeleccion_DoubleClick(sender, e)
    End Sub
End Class