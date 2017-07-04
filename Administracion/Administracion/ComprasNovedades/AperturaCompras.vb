Public Class Apertura

    Private seAbrio As Boolean = False

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
        Return CustomConvert.toStringWithTwoDecimalPlaces(CustomConvert.toDoubleOrZero(valor))
    End Function


    Private Function sumarColumna(ByVal index As Integer)
        Dim suma As Double
        For Each row As DataGridViewRow In gridApertura.Rows
            If Not row.IsNewRow Then
                suma += CustomConvert.toDoubleOrZero(row.Cells(index).Value)
            End If
        Next
        Return suma
    End Function

    Private Sub Apertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gridBuilder As New GridBuilder(gridApertura)

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

        If _FechasInvalidas Then ' Si se encuentra que hay fechas ingresadas y alguna de estas es invalida, se notifica al usuario y se le pregunta si quiere continuar o no.
            If MsgBox("Algunas de las fechas ingresadas no es correcta." & vbCrLf & vbCrLf & "¿Quiere cerrar igual la ventana de aperturas?", MsgBoxStyle.YesNo) = DialogResult.No Then
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

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Dim valor = .Rows(iRow).Cells(iCol).Value

                    Select Case iCol
                        Case 6 ' Columna Fecha

                            If Not IsNothing(valor) Then

                                If Not _ValidarFecha(valor) Then
                                    Return True
                                End If

                            End If

                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        Case 13 ' Ultima Columna
                            .CurrentCell = .Rows(.Rows.Add).Cells(0) ' Agregamos una fila y nos posicionamos en la primer celda.
                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select


                    Return True

                End If
            End If
        End With
        
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class