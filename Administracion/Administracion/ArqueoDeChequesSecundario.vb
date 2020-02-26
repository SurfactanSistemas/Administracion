Public Class ArqueoDeChequesSecundario
    Dim tablaChequesEliminados As New DataTable
    Dim tablaRecibos As New DataTable
    Dim ultimaFechaLeida As String = "  /  /    "
    Dim CodigoUltimoCheque As String = ""

    Private Sub ArqueoDeChequesSecundario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With tablaChequesEliminados.Columns
            .Add("Fecha")
            .Add("Numero")
            .Add("Importe")
            .Add("Banco")
            .Add("ClaveCheque")
            .Add("Clave")
        End With

        With tablaRecibos.Columns
            .Add("Fecha")
            .Add("Numero")
            .Add("Importe")
            .Add("Banco")
            .Add("ClaveCheque")
            .Add("Clave")
            .Add("Marca")
        End With


        Me.BackColor = Color.FromKnownColor(KnownColor.Control)



        Dim SQLCnslt As String = ""



        'TRAIGO LOS CHEQUES EN RECIBOS
        SQLCnslt = "SELECT Importe =Importe2,Numero = Numero2, Fecha = Fecha2 ,Banco = Banco2, ClaveCheque, Clave, Marca = Estado2 FROM Recibos WHERE TipoReg = '2' "
        SQLCnslt = SQLCnslt & "AND Estado2 <> 'X' AND Tipo2 = '02' ORDER BY FechaOrd2, Numero2"

        tablaRecibos = GetAll(SQLCnslt)

    End Sub



    Private Sub txtCodigoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCheque.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtCodigoCheque.Text <> "" Then
                    txtCodigoCheque.Text = txtCodigoCheque.Text.ToUpper().Replace(";", "C").Replace(":", "E")
                    If txtCodigoCheque.Text.Length = 31 Then
                        For Each row As DataRow In tablaRecibos.Rows
                            If Trim(row.Item("ClaveCheque")).ToUpper = txtCodigoCheque.Text.ToUpper And row.Item("Marca") = "P" Then
                                mastxtFecha.Text = row.Item("Fecha")
                                txtNumeroCheque.Text = row.Item("Numero")
                                txtImporte.Text = row.Item("Importe")
                                txtBanco.Text = row.Item("Banco")


                                'GUARDO LA FECHA PARA PODER VERIFICARLA DESPUES SI HACE UNA MODIFICACION
                                ultimaFechaLeida = row.Item("Fecha")


                                'Y EL CODIGO DEL CHEQUE
                                CodigoUltimoCheque = row.Item("Clave")




                                'AGREGO A LA TABLA REGISTRO DE LOS CHEQUES QUE SACO DEL GRID EN MEMORIA
                                tablaChequesEliminados.Rows.Add(row.Item("Fecha"), row.Item("Numero"), row.Item("Importe"), row.Item("Banco"), row.Item("ClaveCheque"), row.Item("Clave"))
                                'AGREGO A LA TABLA REGISTRO DE LOS CHEQUES QUE SACO DEL GRID EN LA BASE DE DATOS 
                                'PARA PODER RECUPERARLOS EN CASO DE QUE EL PROGRAMA SE CIERRE
                                AgregarABaseRespaldo(row.Item("Fecha"), row.Item("Numero"), row.Item("Importe"), row.Item("Banco"), row.Item("ClaveCheque"), row.Item("Clave"))

                                row.Item("Marca") = "X"

                                txtCodigoCheque.Text = ""

                                Me.BackColor = Color.FromKnownColor(KnownColor.Lime)
                                Exit Sub

                            End If
                        Next
                    End If
                End If

                If _BuscarEnEliminados() = "Esta" Then
                    MsgBox("Ya desconto ese cheque de la lista")
                    txtCodigoCheque.Text = ""
                Else
                    MsgBox("Cheque no encontrado")
                    txtCodigoCheque.Text = ""
                End If

                Me.BackColor = Color.FromKnownColor(KnownColor.Red)
                txtCodigoCheque.SelectAll()
            Case Keys.Escape
                txtCodigoCheque.Text = ""
        End Select
    End Sub


    Private Sub AgregarABaseRespaldo(ByVal Fecha As String, ByVal Numero As String, ByVal Importe As Double, ByVal Banco As String, ByVal ClaveCheque As String, ByVal Clave As String)

        Dim SQLCnslt As String
        SQLCnslt = "INSERT INTO ArqueoChequesControl (Clave, Fecha, Numero, Importe, Banco, ClaveCheque, MarcaOrigen) VALUES('" & Clave & "','" & Fecha & "', '" & Numero & "', '" & (Importe).ToString().Replace(",", ".") & "', '" & Banco & "', '" & ClaveCheque & "', '" & "S" & "')"

        ExecuteNonQueries("surfactanSa", {SQLCnslt})

    End Sub
    Private Function _BuscarEnEliminados() As String
        For i = 0 To tablaChequesEliminados.Rows.Count - 1

            If txtCodigoCheque.Text.ToUpper.Trim = Trim(tablaChequesEliminados.Rows(i).Item("ClaveCheque")).ToUpper Then
                Return "Esta"
            End If

        Next
        Return "No Esta"
    End Function


    Private Sub mastxtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then

                    If mastxtFecha.Text <> ultimaFechaLeida Then

                        Dim fechaOrd As String = ordenaFecha(mastxtFecha.Text)
                        Dim SQLCnslt As String = ""



                        SQLCnslt = "UPDATE Recibos SET Fecha2 = '" & mastxtFecha.Text & "', FechaOrd2 = '" & fechaOrd & "' WHERE Clave = '" & CodigoUltimoCheque & "'"


                        ExecuteNonQueries({SQLCnslt})

                        MsgBox("La Fecha se a modificado con exito")

                        txtCodigoCheque.Focus()
                        txtCodigoCheque.SelectAll()
                    End If



                Else
                    MsgBox("Verifique que la Fecha sea valida")


                End If




            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub



End Class