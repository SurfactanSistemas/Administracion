Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class Apertura

    Private seAbrio As Boolean = False
    Private WRow, Wcol As Integer

    Public Function valorNeto()
        Return sumarColumna(7)
    End Function

    Public Function valorIVA21()
        Return sumarColumna(8)
    End Function

    Public Function valorIVA27()
        Return sumarColumna(9)
    End Function

    Public Function valorIVA105()
        Return sumarColumna(10)
    End Function

    Public Function valorIVARG()
        Return sumarColumna(11)
    End Function

    Public Function valorIB()
        Return sumarColumna(12)
    End Function

    Public Function valorExento()
        Return sumarColumna(13)
    End Function

    Public Function noSeAbrio()
        Return Not seAbrio
    End Function

    Public Sub cargarTablaSegun(ByVal tabla As DataTable)
        For Each dataRow As DataRow In tabla.Rows
            gridApertura.Rows.Add(dataRow("Cuit").ToString, dataRow("Razon").ToString, dataRow("Tipo").ToString, dataRow("Letra").ToString,
                                  dataRow("Punto").ToString, dataRow("Numero").ToString, dataRow("Fecha").ToString, asDouble(dataRow("Neto")),
                                  asDouble(dataRow("Iva21")), asDouble(dataRow("Iva27")), asDouble(dataRow("Iva105")), asDouble(dataRow("PerceIva")),
                                  asDouble(dataRow("PerceIB")), asDouble(dataRow("Exento")))
        Next
    End Sub

    Private Function asDouble(ByVal valor)
        'Return CustomConvert.toStringWithTwoDecimalPlaces(CustomConvert.toDoubleOrZero(valor))
        Return Proceso.formatonumerico(valor)
    End Function


    Private Function sumarColumna(ByVal index As Integer)
        Dim suma As Double
        suma += (From row As DataGridViewRow In gridApertura.Rows Where Not row.IsNewRow).Sum(Function(row) Val(asDouble(row.Cells(index).Value)))
        Return suma
    End Function

    Private Sub Apertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gridBuilder As New GridBuilder(gridApertura)

        WRow = -1
        Wcol = -1

        gridBuilder.addTextColumn(0, "CUIT")
        gridBuilder.addTextColumn(1, "Razón Social")
        gridBuilder.addTextColumn(2, "Tipo")
        gridBuilder.addTextColumn(3, "Letra")
        gridBuilder.addNumericColumn(4, "Punto")
        gridBuilder.addNumericColumn(5, "Número")
        gridBuilder.addDateColumn(6, "Fecha")
        gridBuilder.addFloatColumn(7, "Neto")
        gridBuilder.addFloatColumn(8, "IVA 21")
        gridBuilder.addFloatColumn(9, "IVA 27")
        gridBuilder.addFloatColumn(10, "IVA 10.5")
        gridBuilder.addFloatColumn(11, "Perc. IVA")
        gridBuilder.addFloatColumn(12, "Perc. IB")
        gridBuilder.addFloatColumn(13, "Exento")
        seAbrio = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim _FechasInvalidas As Boolean = False
        Dim _CuitsInvalidos As Boolean = False

        ' Eliminamos la filas en blanco
        For Each row As DataGridViewRow In gridApertura.Rows

            With row
                gridApertura.CommitEdit(DataGridViewDataErrorContexts.Commit)
                If IsNothing(.Cells(0).Value) And IsNothing(.Cells(1).Value) And IsNothing(.Cells(2).Value) And IsNothing(.Cells(3).Value) Then
                    If Not .IsNewRow Then
                        gridApertura.Rows().Remove(row)
                    End If
                End If
            End With

        Next

        For Each row As DataGridViewRow In gridApertura.Rows
            With row

                If Not IsNothing(.Cells(6).Value) Then
                    If Not _ValidarFecha(.Cells(6).Value.ToString()) Then
                        _FechasInvalidas = True
                        Exit For
                    End If
                End If

            End With
        Next

        For Each row As DataGridViewRow In gridApertura.Rows
            With row

                If Not IsNothing(.Cells(0).Value) Then
                    If .Cells(0).Value.ToString() <> "" Then
                        If Not Proceso.CuitValido(.Cells(0).Value.ToString()) Then
                            _CuitsInvalidos = True
                            Exit For
                        End If
                    End If
                End If

            End With
        Next

        If _FechasInvalidas Then ' Si se encuentra que hay fechas ingresadas y alguna de estas es invalida, se notifica al usuario y se le pregunta si quiere continuar o no.
            If MsgBox("Algunas de las fechas ingresadas no es correcta." & vbCrLf & vbCrLf & "¿Quiere cerrar igual la ventana de aperturas?", MsgBoxStyle.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If _CuitsInvalidos Then ' Si se encuentra que hay fechas ingresadas y alguna de estas es invalida, se notifica al usuario y se le pregunta si quiere continuar o no.
            If MsgBox("Algunas de los Cuit ingresados no es correcto." & vbCrLf & vbCrLf & "¿Quiere cerrar igual la ventana de aperturas?", MsgBoxStyle.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Me.Hide()
    End Sub

    Private Function _Normalizarfecha(ByVal fecha As String) As String
        Dim xfecha As String = ""
        Dim _temp As String = fecha
        Dim _Fecha As String() = fecha.Split("/")

        Try
            _Fecha(0) = Val(_Fecha(0)).ToString()
            _Fecha(1) = Val(_Fecha(1)).ToString()
            _Fecha(2) = Val(_Fecha(2)).ToString()

            xfecha = String.Join("/", _Fecha)

            xfecha = Date.ParseExact(fecha, "d/M/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("dd/MM/yyyy")
        Catch ex As Exception
            xfecha = _temp
        End Try

        Return xfecha
    End Function

    Private Function _FormatoValidoFecha(ByVal fecha As String) As Boolean
        fecha = Trim(_Normalizarfecha(fecha))

        Return fecha.Replace("/", "").Length = 8 And IsDate(fecha)
    End Function

    Private Function _ValidarFecha(ByVal fecha As String) As Boolean
        Dim valida As Boolean = True

        If Trim(fecha.Replace("/", "")) <> "" Then

            If Not _FormatoValidoFecha(fecha) Then
                valida = False
            End If

        End If

        Return valida
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        With gridApertura
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = .Rows(iRow).Cells(iCol).Value

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Select Case iCol
                        Case 0

                            If Not IsNothing(valor) Then
                                If Not Proceso.CuitValido(valor) And Trim(valor) <> "" Then
                                    MsgBox("El CUIT ingresado no es correcto.")
                                    Return True
                                Else
                                    ' Traemos la razon social en caso de ya haber sido agregado en alguna apertura anterior.
                                    .Rows(iRow).Cells(1).Value = _BuscarRazonSocial(valor)

                                    .CurrentCell = .Rows(iRow).Cells(1)

                                End If
                            Else
                                Return True
                            End If

                        Case 2 ' Columna tipo

                            Select Case UCase(valor)
                                Case "FC", "ND", "NC"
                                    .Rows(iRow).Cells(iCol).Value = UCase(valor)
                                    .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                                Case Else
                                    Return True
                            End Select

                        Case 3 ' Columna Letra

                            Select Case UCase(valor)
                                Case "A", "B", "C", "X", "M", "I"
                                    .Rows(iRow).Cells(iCol).Value = UCase(valor)
                                    .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                                Case Else
                                    Return True
                            End Select
                        Case 4, 5

                            If Val(valor) = 0 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                                If iCol = 5 Then
                                    Dim _location As Point = .GetCellDisplayRectangle(6, iRow, False).Location
                                    'Dim _size As Size = .GetCellDisplayRectangle(6, iRow, False).Size

                                    'txtFechaAux.Size = _size
                                    '.CurrentCell.Style.BackColor = Color.White
                                    .ClearSelection()
                                    _location.Y += 4
                                    _location.X += 7
                                    txtFechaAux.Location = _location
                                    txtFechaAux.Text = .Rows(iRow).Cells(6).Value
                                    WRow = iRow
                                    Wcol = iCol
                                    txtFechaAux.Visible = True
                                    txtFechaAux.Focus()
                                End If
                            End If

                        Case 6 ' Columna Fecha

                            'Debug.Print("==============================================")
                            'Debug.Print(.PointToScreen(.GetCellDisplayRectangle(iCol, iRow, False).Location).ToString)

                            If Not IsNothing(valor) Then

                                If Not _ValidarFecha(valor) Then
                                    Return True
                                End If

                            End If

                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        Case 13 ' Ultima Columna
                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                .CurrentCell = .Rows(.Rows.Add).Cells(0) ' Agregamos una fila y nos posicionamos en la primer celda.
                            End Try

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    If IsNothing(valor) Then

                        Select Case iCol
                            Case 7, 8, 9, 10, 11, 12, 13
                                .Rows(iRow).Cells(iCol).Value = "0"
                            Case Else
                                .Rows(iRow).Cells(iCol).Value = ""
                        End Select

                    End If

                    Return True
                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""
                End If

            End If
        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _BuscarRazonSocial(ByVal cuit As String) As String
        Dim _RazonSocial As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Razon FROM IvaCompAdicional WHERE Cuit = '" & Trim(cuit) & "' AND Razon <> ''")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    _RazonSocial = IIf(IsDBNull(.Item("Razon")), "", Trim(.Item("Razon")))

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

        Return _RazonSocial
    End Function


    Private WithEvents txtNumeric As New DataGridViewTextBoxEditingControl
    Private WithEvents txtNumericWithComma As New DataGridViewTextBoxEditingControl

    Private Sub gridApertura_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridApertura.EditingControlShowing

        Select Case gridApertura.CurrentCell.ColumnIndex
            Case 0, 4, 5
                txtNumeric = CType(e.Control, DataGridViewTextBoxEditingControl)
            Case 7, 8, 9, 10, 11, 12, 13
                txtNumericWithComma = CType(e.Control, DataGridViewTextBoxEditingControl)
            Case Else
                txtNumericWithComma = Nothing
                txtNumeric = Nothing
        End Select

    End Sub

    Private Sub txtNumericWithComma_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumericWithComma.KeyPress
        If _EsNumero(e) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Or e.KeyChar = CChar(","c) Or e.KeyChar = CChar("."c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeric_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeric.KeyPress
        If _EsNumero(e) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Function _EsNumero(ByVal e As KeyPressEventArgs) As Boolean
        Return (e.KeyChar >= CChar("0"c) And e.KeyChar <= CChar("9"c))
    End Function

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(Trim(txtFechaAux.Text)) And WRow >= 0 And Wcol >= 0 Then
                gridApertura.Rows(WRow).Cells(6).Value = txtFechaAux.Text

                gridApertura.CurrentCell = gridApertura.Rows(WRow).Cells(7)
                gridApertura.Focus()

                txtFechaAux.Visible = False
                txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub gridApertura_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridApertura.CellClick

        If e.ColumnIndex = 6 Then
            Dim _location As Point = gridApertura.GetCellDisplayRectangle(6, e.RowIndex, False).Location
            
            gridApertura.ClearSelection()
            _location.Y += 4
            _location.X += 7
            txtFechaAux.Location = _location
            txtFechaAux.Text = gridApertura.Rows(e.RowIndex).Cells(6).Value
            WRow = e.RowIndex
            Wcol = e.ColumnIndex
            txtFechaAux.Visible = True
            txtFechaAux.Focus()
        End If

    End Sub

    Private Sub gridApertura_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridApertura.MouseDoubleClick

        If gridApertura.SelectedRows.Count > 0 Then

            If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Dim row As DataGridViewRow = gridApertura.CurrentRow

                gridApertura.Rows.Remove(row)
            Else
                gridApertura.ClearSelection()
            End If

        End If

    End Sub
End Class