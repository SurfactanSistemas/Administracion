Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If Environment.GetCommandLineArgs.Length > 1 Then

                txtProceso.Text = Environment.GetCommandLineArgs(1)

                Select Case Val(txtProceso.Text)
                    Case 1

                        txtClave.Text = Environment.GetCommandLineArgs(2)

                    Case Else
                        Exit Sub
                End Select

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim WReporte As ReportDocument = Nothing

        '
        ' DISCRIMINAMOS LOS PROCESOS.
        '

        Select Case Val(txtProceso.Text)

            Case 1 ' COMPOSICION DE FORMULA.

                Dim cn As SqlConnection = New SqlConnection()
                Dim cm As SqlCommand = New SqlCommand("SELECT Tipo, Articulo1, Articulo2, Cantidad, Clave, Terminado, DescriTerminado, DescriArticulo1, DescriArticulo2, Referencia, Observaciones1, Observaciones2 FROM Composicion WHERE Terminado = '" & Trim(txtClave.Text) & "'")
                Dim dr As SqlDataReader
                Dim WComposicion(100, 12) As String
                Dim WIndice = 0
                Dim Waux = ""
                Dim ZSql = ""

                Try

                    cn.ConnectionString = Helper._ConectarA
                    cn.Open()
                    cm.Connection = cn

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        Do While dr.Read()

                            With dr

                                WComposicion(WIndice, 0) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                                WComposicion(WIndice, 1) = IIf(IsDBNull(.Item("Articulo1")), "", .Item("Articulo1"))
                                WComposicion(WIndice, 2) = IIf(IsDBNull(.Item("Articulo2")), "", .Item("Articulo2"))
                                WComposicion(WIndice, 3) = IIf(IsDBNull(.Item("Cantidad")), "0", Helper.formatonumerico(.Item("Cantidad")))
                                WComposicion(WIndice, 4) = IIf(IsDBNull(.Item("Terminado")), "", .Item("Terminado"))
                                WComposicion(WIndice, 5) = IIf(IsDBNull(.Item("DescriTerminado")), "", .Item("DescriTerminado"))
                                WComposicion(WIndice, 6) = IIf(IsDBNull(.Item("DescriArticulo1")), "", .Item("DescriArticulo1"))
                                WComposicion(WIndice, 7) = IIf(IsDBNull(.Item("DescriArticulo2")), "", .Item("DescriArticulo2"))
                                WComposicion(WIndice, 8) = IIf(IsDBNull(.Item("Observaciones1")), "", .Item("Observaciones1"))
                                WComposicion(WIndice, 9) = IIf(IsDBNull(.Item("Observaciones2")), "", .Item("Observaciones2"))
                                WComposicion(WIndice, 10) = IIf(IsDBNull(.Item("Referencia")), "", .Item("Referencia"))

                            End With

                            WIndice += 1
                        Loop

                    End If

                    If Not dr.IsClosed Then
                        dr.Close()
                    End If

                    cm.CommandText = "SELECT * FROM EspecifUnifica WHERE Terminado = '" & Trim(txtClave.Text) & "'"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        
                        With dr

                            WIndice = 0

                            For i = 1 To 10

                                Waux = IIf(IsDBNull(.Item("Ensayo" & i)), "0", .Item("Ensayo" & i))

                                If Val(Waux) <> 0 Then

                                    WComposicion(WIndice, 11) = IIf(IsDBNull(.Item("Ensayo" & i)), "0", .Item("Ensayo" & i))
                                    WComposicion(WIndice, 12) = IIf(IsDBNull(.Item("Valor" & i)), "0", .Item("Valor" & i))

                                    WIndice += 1

                                End If

                                Waux = ""

                            Next

                        End With


                    End If

                Catch ex As Exception
                    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
                Finally

                    dr = Nothing
                    cn.Close()
                    cn = Nothing
                    cm = Nothing

                End Try

                WIndice = 0
                Dim WRenglon = "", WTerminado = "", WClave = ""

                For i = 0 To 100

                    If Trim(WComposicion(i, 0)) <> "" OrElse Trim(WComposicion(i, 11)) <> "" Then

                        WIndice += 1

                        WRenglon = Helper.ceros(WIndice, 2)
                        WTerminado = Trim(txtClave.Text)
                        WClave = WTerminado & WRenglon

                        ZSql &= "INSERT INTO ImpreProcesoPDF " _
                             & "(Clave, Proceso, Codigo, Observa1, Observa2, Observa3, Observa4, Observa5, Observa6, Observa7, Observa8, Observa9, Observa10, " _
                             & " Descri1, Descri2, Descri3, Descri4, Descri5, Descri6, Descri7, Descri8, Descri9, Descri10, " _
                             & " Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10)" _
                             & " VALUES (" _
                             & "'" & WClave & "'," _
                             & "'" & Trim(txtProceso.Text) & "'," _
                             & "'" & WTerminado & "'," _
                             & "'" & "Surfactan S.A." & "'," _
                             & "'" & WComposicion(i, 5) & "'," _
                             & ")"

                    End If

                Next

            Case Else
                Me.Close()
        End Select

    End Sub
End Class
