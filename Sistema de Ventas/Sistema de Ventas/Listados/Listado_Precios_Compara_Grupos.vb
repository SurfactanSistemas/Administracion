Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Listado_Precios_Compara_Grupos

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_HastaLista.KeyPress, txt_HastaLinea.KeyPress, txt_DesdeLista.KeyPress, txt_DesdeLinea.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_DesdeLista_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeLista.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_HastaLista.Focus()
            Case Keys.Escape
                txt_DesdeLista.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaLista_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaLista.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_DesdeLinea.Focus()
            Case Keys.Escape
                txt_HastaLista.Text = ""
        End Select
    End Sub

    Private Sub txt_DesdeLinea_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeLinea.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_HastaLinea.Focus()
            Case Keys.Escape
                txt_DesdeLinea.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaLinea_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaLinea.KeyDown

        Select Case e.KeyData
            Case Keys.Escape
                txt_DesdeLinea.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        Dim WFecha As String = ordenaFecha(txt_Fecha.Text)
        Dim WFechaCompa As String = ordenaFecha(txt_FechaCompa.Text)


        Dim SQLCnslt As String = "Select Terminado, Clave, Precio " _
                                & "FROM CargaLista " _
                                & "ORDER BY Clave"

        Dim tablaCargalista As DataTable = GetAll(SQLCnslt, Operador.base)

        If tablaCargalista.Rows.Count > 0 Then


            For Each rowCarga As DataRow In tablaCargalista.Rows
                Dim ZTerminado As String = rowCarga.Item("Terminado")
                Dim ZClave As String = rowCarga.Item("Clave")
                Dim ZPrecio As Double = Val(rowCarga.Item("Precio"))


                Dim Costo As Double = formatonumerico(Calcula_Costo(ZTerminado))

                If Costo <> 0 Then

                    REM ZDife = ZPrecio - Costo
                    Dim ZPorce As Double = formatonumerico(ZPrecio / Costo)
                    ' Call redondeo(ZPorce)
                    Dim CostoII As Double = 0

                    Dim FechaII As String = ""
                    Dim ZDife As String

                    SQLCnslt = "UPDATE CargaLista SET " _
                                & " CostoI = '" & Costo & "'," _
                                & " FactorI = '" & ZPorce & "'," _
                                & " FechaI = '" & txt_Fecha.Text & "'," _
                                & " CostoII = '" & 0 & "'," _
                                & " FactorII = '" & 0 & "'," _
                                & " FechaII = '" & "" & "'," _
                                & " Porce = '" & 0 & "'" _
                                & " Where Clave = '" & ZClave & "'"

                    ExecuteNonQueries({SQLCnslt}, Operador.Base)


                    If txt_FechaCompa.Text <> "  /  /    " Then


                        SQLCnslt = "Select Costo, Fecha" _
                                & " FROM CargaListaII" _
                                & " Where CargaListaII.Terminado = " + "'" + ZTerminado + "'" _
                                & " and CargaListaII.OrdFecha <= " + "'" + WFechaCompa + "'"

                        Dim RowCargaLisII As DataRow = GetSingle(SQLCnslt, Operador.Base)

                        If RowCargaLisII IsNot Nothing Then
                            CostoII = formatonumerico(RowCargaLisII.Item("Costo"))
                            FechaII = RowCargaLisII.Item("Fecha")

                        End If

                        If CostoII <> 0 Then

                            REM ZDife = ZPrecio - CostoII
                            ZPorce = formatonumerico(ZPrecio / CostoII)
                            'Call redondeo(ZPorce)
                            ZDife = ""

                            If Costo <> 0 And CostoII <> 0 Then
                                Dim ZDiferencia As Double = Costo - CostoII
                                Dim ZDifeaux As Double = (ZDiferencia / CostoII) * 100
                                ZDife = ZDifeaux.ToString()
                                ZDife = ZDife.Replace(",", ".")
                                'Call redondeo(ZDife)
                            End If

                            SQLCnslt = "UPDATE CargaLista SET " _
                            & " CostoII = '" & CostoII & "'," _
                            & " FactorII = '" & ZPorce & "'," _
                            & " FechaII = '" & FechaII & "'," _
                            & " Porce = '" & ZDife & "'" _
                            & " Where Clave = '" & ZClave & "'"

                            ExecuteNonQueries({SQLCnslt}, Operador.Base)

                        End If

                    End If

                    ZClave = WFecha + ZTerminado

                    SQLCnslt = "Select Clave" _
                             & " FROM CargaListaII" _
                             & " Where Clave = '" & ZClave & "'"

                    Dim rowCargaII As DataRow = GetSingle(SQLCnslt, Operador.Base)

                    If rowCargaII IsNot Nothing Then

                        SQLCnslt = "UPDATE CargaListaII SET " _
                                  & " Costo = '" & Str$(Costo) & "'" _
                                  & " Where Clave = '" & ZClave & "'"

                        ExecuteNonQueries({SQLCnslt}, Operador.Base)

                    Else


                        SQLCnslt = "INSERT INTO CargaListaII (" _
                                     & "Clave ," _
                                     & "Fecha ," _
                                     & "OrdFecha ," _
                                     & "Terminado ," _
                                     & "Costo )" _
                                     & "Values (" _
                                     & "'" & ZClave & "'," _
                                     & "'" & txt_Fecha.Text & "'," _
                                     & "'" & WFecha & "'," _
                                     & "'" & ZTerminado & "'," _
                                     & "'" & Str$(Costo) & "')"

                        ExecuteNonQueries({SQLCnslt}, Operador.Base)

                    End If

                End If
            Next


        End If

        

        Dim WFormula As String = "{CargaLista.Lista} >= " & txt_DesdeLista.Text & " AND {CargaLista.Lista} <= " & txt_HastaLista.Text & " " _
                                & " AND {CargaLista.Linea} >= " & txt_DesdeLinea.Text & " AND {CargaLista.Linea} <= " & txt_HastaLinea.Text & ""


        With New VistaPrevia
            .Reporte = New Reporte_PreciosCompa()
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With
        
        
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub



    Private Function Calcula_Costo(Producto As String) As Double
        Dim SQLCnslt As String
        Dim Costo As Double
        Dim Vector(200, 2) As String
        Dim Auxiliar(200, 7) As String
        Dim Renglon As Integer = 0

        Vector(1, 1) = Producto
        Vector(1, 2) = "1"
        Costo = 0
        Dim Lugar As Integer = 1
        Dim Cicla As Integer = 0

        Do
            Cicla = Cicla + 1
            If Vector(Cicla, 1) <> "" Then

                Dim Entra As String = "S"

                SQLCnslt = "SELECT Tipo, Articulo1, Articulo2, Cantidad FROM Composicion" _
                                        & " WHERE Terminado = '" & Vector(Cicla, 1) & "' "

                Dim TablaCompocion As DataTable = GetAll(SQLCnslt, Operador.Base)

                If TablaCompocion.Rows.Count > 0 Then

                    For Each RowCompo As DataRow In TablaCompocion.Rows

                        Entra = "N"

                        Dim Tipo As String = RowCompo.Item("Tipo")
                        Dim Articulo1 As String = RowCompo.Item("Articulo1")
                        Dim Articulo2 As String = RowCompo.Item("Articulo2")
                        Dim Cantidad As String = RowCompo.Item("Cantidad")

                        Select Case Tipo
                            Case "T"
                                If Producto <> Articulo2 Then
                                    Lugar = Lugar + 1
                                    Vector(Lugar, 1) = Articulo2
                                    Vector(Lugar, 2) = Str$(Cantidad * Val(Vector(Cicla, 2)))
                                End If
                            Case "M"
                                Renglon = Renglon + 1
                                Auxiliar(Renglon, 1) = Articulo1
                                Auxiliar(Renglon, 2) = Cantidad
                                Auxiliar(Renglon, 3) = Vector(Cicla, 2)
                            Case Else
                        End Select
                    Next




                End If

                If Entra = "S" Then
                    If Microsoft.VisualBasic.Left$(Vector(Cicla, 1), 2) <> "PT" Then
                        Renglon = Renglon + 1
                        Auxiliar(Renglon, 1) = Microsoft.VisualBasic.Left$(Vector(Cicla, 1), 3) + Microsoft.VisualBasic.Right$(Vector(Cicla, 1), 7)
                        Auxiliar(Renglon, 2) = 1
                        Auxiliar(Renglon, 3) = Vector(Cicla, 2)
                    End If
                End If

            Else

                Exit Do

            End If

        Loop

        For DA = 1 To Renglon
            Dim Articulo As String = Auxiliar(DA, 1)
            Dim Cantidad As String = Auxiliar(DA, 2)
            Dim WVector As String = Auxiliar(DA, 3)

            SQLCnslt = "SELECT Costo2 FROM Articulo WHERE Codigo = '" & Articulo & "'"
            Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowArti IsNot Nothing Then

                Costo = Costo + (Cantidad * RowArti.Item("Costo2") * Val(WVector))

            End If
        Next DA

        Return Costo

    End Function



    Private Sub Listado_Precios_Compara_Grupos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Focus()
    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_FechaCompa.Focus()
                Else
                    MsgBox("Verifique el campo de fecha, valor invalido")
                    txt_Fecha.SelectAll()
                    txt_Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
        
    End Sub

    Private Sub txt_FechaCompa_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaCompa.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaCompa.Text) = "S" Then
                    txt_DesdeLista.Focus()
                Else
                    MsgBox("Verifique el campo de fecha a comparar, valor invalido")
                    txt_FechaCompa.SelectAll()
                    txt_FechaCompa.Focus()
                End If
            Case Keys.Escape
                txt_FechaCompa.Text = ""
        End Select
    End Sub
End Class