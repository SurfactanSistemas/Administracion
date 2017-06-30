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
        Me.Hide()
    End Sub

    Private Sub gridApertura_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridApertura.CellValueChanged
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Dim cantCeros As Integer = 0
            Dim cell As DataGridViewCell = gridApertura.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Select Case e.ColumnIndex
                Case 4
                    cantCeros = 4
                Case 5
                    cantCeros = 8
                Case Else
                    Exit Sub
            End Select
            cell.Value = ceros(cell.Value, cantCeros)
        End If
    End Sub
End Class