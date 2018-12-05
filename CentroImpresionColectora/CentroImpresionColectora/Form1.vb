Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports CentroImpresionColectora.Clases

Public Class Form1

    Dim tipo As String = ""
    Dim _Traducir As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '
        ' Buscamos las etiquetas que estén pendientes ¿para este centro?
        '

        Dim WEtiquetas As DataTable = GetAll("SELECT * FROM ImpreColectora WHERE ISNULL(Impresion, '') = '' ORDER BY Clave")

        For Each WEtiqueta As DataRow In WEtiquetas.Rows
            With WEtiqueta

                Dim WContenedor As String = OrDefault(.Item("Contenedor"), "")
                Dim WKilos = formatonumerico(OrDefault(.Item("Kilos"), "0").ToString).ToString
                Dim WTerminado = ""
                Dim WPartida = WContenedor.Substring(0, 6)
                Dim WDescTerminado = ""
                Dim WPuesto = OrDefault(.Item("Puesto"), 0)
                Dim WFecha = OrDefault(.Item("Fecha"), "  /  /    ")

                Dim empresas() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}

                For Each i As Integer In empresas

                    Dim cs = Conexion.DeterminarSegunIDIDBasePara(i)

                    Dim WDatos As DataRow = GetSingle("SELECT Hoja.Hoja, Hoja.Producto, RTRIM(LTRIM(ISNULL(Terminado.Descripcion, ''))) as Descripcion FROM Hoja LEFT OUTER JOIN Terminado ON Hoja.Producto = Terminado.Codigo WHERE Hoja = '" & WPartida & "' AND Renglon = '1'", cs)

                    If IsNothing(WDatos) Then Continue For

                    WTerminado = OrDefault(WDatos.Item("Producto"), "")
                    WDescTerminado = OrDefault(WDatos.Item("Descripcion"), "").ToString.Trim

                    Dim WEmpresa = "SURFACTAN S.A."

                    tipo = "Chica"

                    Dim WSGA() As String = _ObtenerDatosSGA(WTerminado)



                    Exit For
                Next

            End With
        Next

    End Sub

    Private Function _DeterminarTabla(ByVal codigo As String) As String
        Select Case codigo.Substring(0, 2)
            Case "PT", "YQ", "YF", "YP"
                Return If((tipo = "Frasco" OrElse tipo = "Chica") AndAlso Not _Traducir, "DatosEtiqueta", "DatosEtiquetaImpre")
            Case Else
                Return If(Not _Traducir, "DatosEtiquetaMP", "DatosEtiquetaImpre")
        End Select
    End Function

    Private Function _DeterminarColumna(ByVal codigo As String) As String
        Select Case codigo.Substring(0, 2)
            Case "PT", "YQ", "YF", "YP"
                Return "Terminado"
            Case Else
                Return "Articulo"
        End Select
    End Function

    Private Function _ObtenerDatosSGA(ByVal _Codigo As String) As String()
        Dim datos As String() = New String(30) {}
        Dim sufix As String = If(_Traducir, "Ingles", "")
        Dim _ViejoTraducir As Boolean = _Traducir

        If _Codigo.Substring(0, 2).ToUpper() = "DY" Then
            sufix = ""
            _Traducir = False
        End If

        For i As Integer = 0 To 31 - 1
            datos(i) = ""
        Next

        Try

            Using cn As SqlConnection = New SqlConnection(_ConectarA("SurfactanSa"))
                cn.Open()
                Dim Tabla As String = _DeterminarTabla(_Codigo)
                Dim Columna As String = _DeterminarColumna(_Codigo)
                Dim cmd As SqlCommand = New SqlCommand("Select * From " & Tabla & " WHERE " & Columna & " = '" & _Codigo.Trim() & "'", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim renglon As Integer = 8
                    Dim pictograma As Integer = 1
                    Dim _tipo As Integer = If((tipo = "Chica" OrElse tipo = "Frasco" OrElse Tabla = "DatosEtiquetaMP"), 0, 1)

                    Select Case _tipo
                        Case 0
                            datos(0) = dr("Frase1" & sufix).ToString()
                            datos(1) = dr("Frase2" & sufix).ToString()
                            datos(2) = dr("Frase3" & sufix).ToString()
                            datos(3) = dr("Frase4" & sufix).ToString()
                            datos(4) = dr("Frase5" & sufix).ToString()
                            datos(5) = dr("Frase6" & sufix).ToString()
                            datos(6) = dr("Frase7" & sufix).ToString()
                        Case Else
                            datos(14) = dr("Frase9" & sufix).ToString()
                            datos(15) = dr("Frase10" & sufix).ToString()
                            datos(16) = dr("Frase11" & sufix).ToString()
                            datos(17) = dr("Frase12" & sufix).ToString()
                            datos(18) = dr("Frase13" & sufix).ToString()
                            datos(19) = dr("Frase14" & sufix).ToString()
                            datos(20) = dr("Frase15" & sufix).ToString()
                            datos(21) = dr("Frase16" & sufix).ToString()
                            datos(22) = dr("Frase17" & sufix).ToString()
                            datos(23) = dr("Frase18" & sufix).ToString()
                            datos(24) = dr("Frase19" & sufix).ToString()
                            datos(25) = dr("Frase20" & sufix).ToString()
                            datos(26) = dr("Frase21" & sufix).ToString()
                            datos(27) = dr("Frase22" & sufix).ToString()
                            datos(28) = dr("Frase23" & sufix).ToString()
                    End Select

                    datos(7) = If((_tipo = 0), dr("Frase8" & sufix).ToString(), datos(28))

                    If _Codigo.StartsWith("DY") Then

                        For i As Integer = 0 To 7 - 1
                            datos(i + 14) = datos(i)
                        Next
                    End If

                    If datos(7) = "" Then
                        Dim exists = Enumerable.Range(0, dr.FieldCount).Any(Function(i) String.Equals(dr.GetName(i), "Palabra", StringComparison.OrdinalIgnoreCase))
                        Dim pal As String = If(exists, dr("Palabra").ToString().Trim(), "")

                        Select Case pal
                            Case "1"
                                pal = If((_Traducir), "Danger", "Peligro")
                            Case "2"
                                pal = If((_Traducir), "Warning", "Atención")
                            Case Else
                                pal = ""
                        End Select

                        datos(7) = pal
                    Else

                        If _Traducir Then
                            datos(7) = datos(7).Replace("Peligro", "DANGER")
                            datos(7) = datos(7).Replace("PELIGRO", "DANGER")
                            datos(7) = datos(7).Replace("Atención", "WARNING")
                            datos(7) = datos(7).Replace("Atencion", "WARNING")
                            datos(7) = datos(7).Replace("ATENCIÓN", "WARNING")
                            datos(7) = datos(7).Replace("ATENCION", "WARNING")
                        End If
                    End If

                    While pictograma <= 9 AndAlso renglon < 13

                        If Int32.Parse(dr("Pictograma" & pictograma).ToString()) <> 0 Then
                            datos(renglon) = _ObtenerRutaImagenSGA(pictograma.ToString())
                            renglon += 1
                        End If

                        pictograma += 1
                    End While

                    While renglon < 13
                        datos(renglon) = _ObtenerRutaImagenSGA("0")
                        renglon += 1
                    End While
                Else

                    If Tabla <> "DatosEtiquetaImpre" Then
                        Dim i As Integer = 0

                        While i <= 13
                            datos(i) = If(i >= 8, _ObtenerRutaImagenSGA("0"), "")
                            i += 1
                        End While
                    Else
                        dr.Close()
                        cmd = New SqlCommand("Select * From DatosEtiqueta WHERE " & Columna & " = '" & _Codigo.Trim() & "'", cn)
                        dr = cmd.ExecuteReader()

                        If dr.HasRows Then
                            dr.Read()
                            datos(14) = dr("Frase1" & sufix).ToString()
                            datos(15) = dr("Frase2" & sufix).ToString()
                            datos(16) = dr("Frase3" & sufix).ToString()
                            datos(17) = dr("Frase4" & sufix).ToString()
                            datos(18) = dr("Frase5" & sufix).ToString()
                            datos(19) = dr("Frase6" & sufix).ToString()
                            datos(20) = dr("Frase7" & sufix).ToString()
                            datos(7) = dr("Frase8" & sufix).ToString()
                            Dim renglon As Integer = 8
                            Dim pictograma As Integer = 1

                            While pictograma <= 9 AndAlso renglon < 13

                                If Int32.Parse(dr("Pictograma" & pictograma).ToString()) <> 0 Then
                                    datos(renglon) = _ObtenerRutaImagenSGA(pictograma.ToString())
                                    renglon += 1
                                End If

                                pictograma += 1
                            End While

                            While renglon < 13
                                datos(renglon) = _ObtenerRutaImagenSGA("0")
                                renglon += 1
                            End While

                            If datos(7) = "" Then
                                Dim pal As String = dr("Palabra").ToString().Trim()

                                Select Case pal
                                    Case "1"
                                        pal = If((_Traducir), "Danger", "Peligro")
                                    Case "2"
                                        pal = If((_Traducir), "Warning", "Atención")
                                    Case Else
                                        pal = ""
                                End Select

                                datos(7) = pal
                            Else

                                If _Traducir Then
                                    datos(7) = datos(7).Replace("Peligro", "DANGER")
                                    datos(7) = datos(7).Replace("PELIGRO", "DANGER")
                                    datos(7) = datos(7).Replace("Atención", "WARNING")
                                    datos(7) = datos(7).Replace("Atencion", "WARNING")
                                    datos(7) = datos(7).Replace("ATENCIÓN", "WARNING")
                                    datos(7) = datos(7).Replace("ATENCION", "WARNING")
                                End If
                            End If
                        Else
                            Dim i As Integer = 0

                            While i < 13
                                datos(i) = If(i >= 8, _ObtenerRutaImagenSGA("0"), "")
                                i += 1
                            End While
                        End If
                    End If
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("Ocurrio un error al querer consultar las especificaciones SGA del siguiente producto: " & _Codigo)
        End Try

        _Traducir = _ViejoTraducir
        Return datos
    End Function

    Private Function _ObtenerRutaImagenSGA(ByVal numero As String) As String
        Dim WInicioPath As String = Application.ExecutablePath
        Select Case tipo
            Case "Grande"

                If numero = "0" Then
                    'Return If(_EnProduccion, Path.GetFullPath(".\SGA\SB_SGA0.JPG"), Path.GetFullPath("..\..\Resources\SB_SGA0.JPG"))
                    Return WInicioPath & "\SB_SGA0.JPG"
                End If

                Return WInicioPath & "\SB_SGA" & numero & ".png"
            Case Else

                If numero = "0" Then
                    Return WInicioPath & "\SGA0.JPG"
                End If

                Return WInicioPath & "\SGA" & numero & ".png"
        End Select
    End Function

End Class
