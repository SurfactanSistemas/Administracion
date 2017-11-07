Imports System.Data.SqlClient

Public Class ComparacionEntreFamiliasPeriodos

    Private DT As New DataTable("Detalles")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case cmbPeriodoComparacion.SelectedIndex
            Case 1 ' Comparacion por mes.
                _ComparacionMensual()
            Case 2 ' Comparacion por bimestre

            Case 3 ' Comparacion por trimestre

            Case 4 ' Comparacion por semestre

            Case Else
                MsgBox("Debe elegir un periodo válido de comparación.", MsgBoxStyle.Exclamation)
                Exit Sub
        End Select

    End Sub

    Private Sub _ComparacionMensual()

        Select Case cmbTipoComparacion.SelectedIndex
            Case 1 ' Valor Unico
                _ComparacionValorUnicoMensual()
            Case 2 ' Comparacion entre Valores

            Case Else
                MsgBox("Debe elegir un tipo de comparacion válido.", MsgBoxStyle.Exclamation)
                Exit Sub
        End Select

    End Sub

    Private Function _PrepararVentasMensuales() As DataTable

        Dim tabla As New DataTable("Detalles")
        Dim _row As DataRow

        With tabla
            .Columns.Add("Corte")
            .Columns.Add("Tipo")
            .Columns.Add("Descripcion")
            .Columns.Add("Venta", System.Type.GetType("System.Double"))
        End With

        For corte = 1 To 12

            For Each row As DataRow In DT.Rows

                If Val(row.Item("Venta" & corte)) <> 0 Then

                    _row = tabla.NewRow

                    With _row
                        .Item("Corte") = corte
                        .Item("Tipo") = row.Item("Tipo")
                        .Item("Descripcion") = row.Item("Descripcion")
                        .Item("Venta") = row.Item("Venta" & corte)
                    End With

                    tabla.Rows.Add(_row)

                End If

            Next

        Next
        
        Return tabla

    End Function

    Private Sub _ComparacionValorUnicoMensual()
        Select Case cmbValoresUnicos.SelectedIndex
            Case 1 ' Ventas

                Dim tabla As DataTable = _PrepararVentasMensuales()

                With VistaPrevia
                    .Reporte = New VentasMensualesBarras
                    .Reporte.SetDataSource(tabla)
                    .Mostrar()
                End With

            Case 2 ' Kilos

            Case 3 ' Factor

            Case 4 ' Precio

            Case 5 ' Stock

            Case 6 ' Rotacion

            Case 7 ' Porcentaje

            Case 8 ' Pedidos

            Case 9 ' Atrasos

            Case 10 ' % Atrasos

            Case Else
                MsgBox("Debe elegir un valor valido de comparacion.", MsgBoxStyle.Exclamation)
                Exit Sub
        End Select

    End Sub

    Private Sub ComparacionEntreFamiliasPeriodos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarDatos()
    End Sub

    Private Sub _CargarDatos()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Comando")
        Dim dr As SqlDataReader

        Try
            DT.Rows.Clear()
            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                DT.Load(dr)
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos de Comando desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class