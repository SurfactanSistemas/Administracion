Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form1

    '
    '   ACLARACIONES IMPORTANTES:
    '           
    '       - Los parámetros pasados por consola, deben estar separados por un espacio.
    '       - Por lo anterior, en caso de mandar un parámetro que en su contenido tenga un espacio,
    '            debe ser encerrado dentro de triples comillas. (Ej: C:\Foo\Bar Baz => """C:\Foo\Bar Baz"""
    '
    '
    '   PARÁMETROS:
    '       - El Primer parámetro debe ser SIEMPRE el Nro de Proceso.
    '

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If Environment.GetCommandLineArgs.Length > 1 Then

                txtProceso.Text = Environment.GetCommandLineArgs(1)

                Select Case Val(txtProceso.Text)
                    Case 1
                        _PrepararGeneracionComposicionFormula()
                    Case Else
                        Exit Sub
                End Select

                If Trim(txtProceso.Text) <> "" Then
                    btnGenerar.PerformClick()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _PrepararGeneracionComposicionFormula()

        txtClave.Text = Environment.GetCommandLineArgs(2)
        txtCarpeta.Text = Environment.GetCommandLineArgs(3)

        txtCarpeta.Text = txtCarpeta.Text.Replace(ChrW(34), "")

        If Not txtCarpeta.Text.EndsWith("\") Then
            txtCarpeta.Text &= "\"
        End If


    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim WReporte As ReportDocument = Nothing

        '
        ' DISCRIMINAMOS LOS PROCESOS.
        '

        Select Case Val(txtProceso.Text)

            Case 1 ' COMPOSICION DE FORMULA.
                _GenerarReporteComposicionFormula()
            Case Else
                Me.Close()
        End Select

    End Sub

    Private Sub _GenerarReporteComposicionFormula()


        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tipo, Articulo1, Articulo2, Cantidad, Clave, Terminado, DescriTerminado, DescriArticulo1, DescriArticulo2, Referencia, Observaciones1, Observaciones2 FROM Composicion WHERE Terminado = '" & Trim(txtClave.Text) & "'")
        Dim dr As SqlDataReader
        Dim WComposicion(100, 13) As String
        Dim WIndice = 0
        Dim Waux = "", ZSql = "", WReporte = ""
        Dim XXXCodigo As Integer

        Try

            cn.ConnectionString = Helper._ConectarA("Surfactan_II")
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    With dr

                        WComposicion(WIndice, 0) = IIf(IsDBNull(.Item("Tipo")), "", .Item("Tipo"))
                        WComposicion(WIndice, 1) = IIf(IsDBNull(.Item("Articulo1")), "", .Item("Articulo1"))
                        WComposicion(WIndice, 2) = IIf(IsDBNull(.Item("Articulo2")), "", .Item("Articulo2"))
                        WComposicion(WIndice, 3) = IIf(IsDBNull(.Item("Cantidad")), "0", Helper.formatonumerico(.Item("Cantidad"), 5))
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

            XXXCodigo = Val(Mid$(txtClave.Text, 4, 5))
            If XXXCodigo < 25000 Or XXXCodigo > 25999 Then

                cm.CommandText = "SELECT * FROM EspecifUnifica WHERE Producto = '" & Trim(txtClave.Text) & "'"

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    With dr

                        .Read()

                        WIndice = 0

                        For i = 1 To 10

                            Waux = IIf(IsDBNull(.Item("Ensayo" & i)), "0", .Item("Ensayo" & i))

                            If Val(Waux) <> 0 Then
                                Waux = ""

                                WComposicion(WIndice, 11) = IIf(IsDBNull(.Item("Ensayo" & i)), "0", .Item("Ensayo" & i))
                                WComposicion(WIndice, 12) = IIf(IsDBNull(.Item("Valor" & i)), "0", .Item("Valor" & i))
                                WComposicion(WIndice, 13) = _BuscarDescripcionEnsayo(WComposicion(WIndice, 11))

                                Waux = " " & IIf(IsDBNull(.Item("Valor" & i & i)), "0", .Item("Valor" & i & i))

                                If Trim(Waux) <> "" Then

                                    If Trim(WComposicion(WIndice, 12)) <> "" Then

                                        WIndice += 1

                                        WComposicion(WIndice, 11) = ""

                                        WComposicion(WIndice, 13) = ""

                                    End If

                                    WComposicion(WIndice, 12) = Waux

                                End If

                                WIndice += 1

                            End If

                            Waux = ""

                        Next

                    End With


                End If
            End If
        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn.Close()
            cm.Dispose()

        End Try

        WIndice = 0
        Dim WRenglon = "", WTerminado = "", WClave = "", WEmpresa = "", WDescriTerminado = "", WObservaciones = "", WControlCambio = "", WRef = ""
        Dim WTipo = "", WArticulo = "", WDescriarticulo = "", WCantidad = 0.0, WEnsayo = "", WDescriEnsayo = "", WEspecif = ""
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            cm.CommandText = "DELETE FROM ImpreProcesoPDF WHERE Codigo = '" & Trim(txtClave.Text) & "' AND Proceso = '" & Trim(txtProceso.Text) & "'"
            cm.ExecuteNonQuery()

            For i = 0 To 100

                If Trim(WComposicion(i, 0)) <> "" OrElse Not IsNothing(WComposicion(i, 11)) Then

                    WIndice += 1

                    WRenglon = Helper.ceros(WIndice, 2)
                    WTerminado = Trim(txtClave.Text)
                    WClave = WTerminado & WRenglon
                    WEmpresa = "Surfactan S.A."
                    WDescriTerminado = WComposicion(0, 5)
                    WObservaciones = WComposicion(0, 8)
                    WControlCambio = WComposicion(0, 9)
                    WRef = WComposicion(0, 10)
                    WTipo = WComposicion(i, 0)

                    If Trim(UCase(WTipo)) = "M" Then
                        WArticulo = WComposicion(i, 1)
                        WDescriarticulo = _BuscarNombreMP(WComposicion(i, 1))
                    Else
                        WArticulo = WComposicion(i, 2)
                        WDescriarticulo = _BuscarNombreTerminado(WComposicion(i, 2))
                    End If

                    WCantidad = Val(Helper.formatonumerico(WComposicion(i, 3), 5))
                    WEnsayo = WComposicion(i, 11)
                    WDescriEnsayo = WComposicion(i, 13)
                    WEspecif = WComposicion(i, 12)


                    ZSql = "INSERT INTO ImpreProcesoPDF " _
                           & "(Clave, Proceso, Codigo, Renglon, Empresa, Observa1, Observa2, Observa3, Observa4, " _
                           & " Descri1, Descri2, Descri3, Valor1, Descri4, Descri5, Descri6" _
                           & ")" _
                           & " VALUES (" _
                           & "'" & WClave & "'," _
                           & "'" & Trim(txtProceso.Text) & "'," _
                           & "'" & WTerminado & "'," _
                           & "'" & WRenglon & "'," _
                           & "'" & Trim(WEmpresa) & "'," _
                           & "'" & Trim(WDescriTerminado) & "'," _
                           & "'" & Trim(WObservaciones) & "'," _
                           & "'" & Trim(WControlCambio) & "'," _
                           & "'" & Trim(WRef) & "'," _
                           & "'" & Trim(UCase(WTipo)) & "'," _
                           & "'" & Trim(WArticulo) & "'," _
                           & "'" & Trim(WDescriarticulo) & "'," _
                           & "" & Str$(WCantidad) & "," _
                           & "'" & Trim(WEnsayo) & "'," _
                           & "'" & Trim(WDescriEnsayo) & "'," _
                           & "'" & Trim(WEspecif) & "'" _
                           & ")"

                    cm.CommandText = ZSql
                    cm.ExecuteNonQuery()
                Else
                    Exit For
                End If

            Next

            trans.Commit()

            WReporte = "WCaratulaNet.rpt"

            If XXXCodigo >= 25000 And XXXCodigo <= 25999 Then
                WReporte = "WCaratulaFarmaNet.rpt"
            End If

            Dim formula = "{ImpreProcesoPDF.Codigo} = '" & Trim(WTerminado) & "' AND {ImpreProcesoPDF.Proceso} = '" & Trim(txtProceso.Text) & "'"
            Dim report = New ReportViewer("Composición de Fórmula", Configuration.ConfigurationManager.AppSettings("CARPETA_RPTS") & WReporte, formula)

            If Trim(txtCarpeta.Text) <> "" Then

                report.descargarComoPDF(WTerminado, txtCarpeta.Text)
                Me.Close()
            Else

                report.Show()
            End If


        Catch ex As Exception
            If Not IsNothing(trans) And Not IsNothing(trans.Connection) Then
                trans.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Me.Close()
        End Try
    End Sub

    Private Function _BuscarNombreTerminado(ByVal WCodigo As String) As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Terminado WHERE Codigo = '" & Trim(WCodigo) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Descripción del Producto desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""
    End Function

    Private Function _BuscarNombreMP(ByVal wCodigo As String) As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Articulo WHERE Codigo = '" & Trim(wCodigo) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Descripción del Articulo desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ""
    End Function

    Private Function _BuscarDescripcionEnsayo(ByVal WEnsayo As String) As String
        Dim WDescripcion = ""

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Descripcion FROM Ensayos WHERE Codigo = '" & Trim(WEnsayo) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA("Surfactan_II")
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la descripción del ensayo " & Trim(WEnsayo) & " la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WDescripcion
    End Function
End Class
