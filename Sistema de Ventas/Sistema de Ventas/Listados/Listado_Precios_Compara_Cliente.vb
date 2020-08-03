Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Precios_Compara_Cliente : Implements IBuscadorCliente 

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WFecha As String = ordenaFecha(txt_Fecha.Text)
        Dim WFechaCompa As String = ordenaFecha(txt_FechaCompa.Text)

        Dim ZVersion As String = "9999"
        Dim ZCliente As String = txt_Cliente.Text


        Dim ListaSQLCnslt As New List(Of String)


        Dim SQLCnlst As String = "DELETE CargaLista WHERE Lista = '" & ZVersion & "'"
        
        ListaSQLCnslt.Add(SQLCnlst)
       





        SQLCnlst = "Select Terminado, Fecha, Precio " _
                    & " FROM Precios" _
                    & " Where Precios.Cliente = '" & ZCliente & "'"
        Dim TablaPrecios As DataTable = GetAll(SQLCnlst, Operador.Base)

        Dim ZRazon As String = txt_DesCliente.Text

        If TablaPrecios.Rows.Count > 0 Then

            Dim Fila As Integer = 1
            For Each RowPrecios As DataRow In TablaPrecios.Rows


                Dim ZTerminado As String = RowPrecios("Terminado")
                Dim ZFechaI As String = RowPrecios("Fecha")
                Dim ZPrecio As Double = Val(RowPrecios("Precio"))

                Dim ZDifeI As Double = 0
                Dim ZPorceI As Double = 0
                Dim ZCostoI As Double = 0

                Dim ZDifeII As Double = 0
                Dim ZPorceII As Double = 0
                Dim ZCostoII As Double = 0
                Dim ZFechaII As String = ""

                Dim ZDife As Double = 0


                ZCostoI = Calcula_Costo(ZTerminado)

                If ZCostoI <> 0 Then
                    REM ZDifeI = ZPrecio - ZCostoI
                    ZPorceI = ZPrecio / ZCostoI

                    ZPorceI = ZPorceI
                    'Control variable
                    '                    Call redondeo(ZPorceI)
                End If

                If Trim(txt_FechaCompa.Text.Replace("/", "")) <> "" Then

                    SQLCnlst = "Select Costo, Fecha" _
                                & " FROM CargaListaII" _
                                & " WHERE Terminado = '" & ZTerminado & "'" _
                                & " AND OrdFecha <= '" & WFechaCompa & "'" _
                                & " ORDER BY OrdFecha"
                    Dim tablaCargaLista As DataTable = GetAll(SQLCnlst, Operador.Base)

                    If tablaCargaLista.Rows.Count > 0 Then

                        For Each RowCarList As DataRow In tablaCargaLista.Rows
                            ZCostoII = RowCarList.Item("Costo")
                            ZFechaII = RowCarList.Item("Fecha")
                        Next
                    End If
                End If



                If ZCostoII <> 0 Then
                    REM ZDifeII = ZPrecio - ZCostoII
                    ZPorceII = ZPrecio / ZCostoII

                    ZPorceII = ZPorceII
                    'Control variable
                    'Call redondeo(ZPorceII)
                End If

                If ZCostoI <> 0 And ZCostoII <> 0 Then
                    Dim ZDiferencia As Double = ZCostoI - ZCostoII
                    ZDife = (ZDiferencia / ZCostoII) * 100

                    ZDife = ZDife
                    'Control variable
                    'Call redondeo(ZDife)
                End If

                Dim ZLinea As String = "0"
                Dim ZDesTerminado As String = ""

                SQLCnlst = "Select Linea, Descripcion" _
                            & " FROM Terminado" _
                            & " Where Terminado.Codigo = '" & ZTerminado & "'"

                Dim RowTermi As DataRow = GetSingle(SQLCnlst, Operador.Base)

                If RowTermi IsNot Nothing Then
                    ZLinea = RowTermi.Item("Linea")
                    ZDesTerminado = RowTermi.Item("Descripcion")

                End If

                REM dar de alta

                Dim ZLista As String = "9999"
                Dim ZRenglon As String = Fila
                Dim ZFecha As String = ZFechaI
                Dim ZOrdFecha As String = ordenaFecha(ZFechaI)
                Dim ZTitulo As String = "Cliente : " & ZCliente & "   " & ZRazon
                Dim ZObservaciones = ""




                Dim ZClave As String = ZVersion.PadLeft(6, "0") + ZRenglon.PadLeft(3, "0")

                SQLCnlst = "INSERT INTO CargaLista (" _
                             & "Clave ," _
                             & "Lista ," _
                             & "Renglon ," _
                             & "Fecha ," _
                             & "OrdFecha ," _
                             & "Titulo ," _
                             & "Observaciones ," _
                             & "Terminado ," _
                             & "Precio ," _
                             & "Descripcion ," _
                             & "Linea ," _
                             & "Empresa ," _
                             & "CostoI ," _
                             & "CostoII ," _
                             & "FactorI ," _
                             & "FactorII ," _
                             & "Porce ," _
                             & "FechaI ," _
                             & "FechaII )" _
                             & "Values (" _
                             & "'" & ZClave & "'," _
                             & "'" & ZLista & "'," _
                             & "'" & ZRenglon & "'," _
                             & "'" & ZFecha & "'," _
                             & "'" & ZOrdFecha & "'," _
                             & "'" & ZTitulo & "'," _
                             & "'" & ZObservaciones & "'," _
                             & "'" & ZTerminado & "'," _
                             & "'" & Str$(ZPrecio) & "'," _
                             & "'" & ZDesTerminado & "'," _
                             & "'" & ZLinea & "'," _
                             & "'" & UCase(Operador.Base) & "'," _
                             & "'" & Str$(ZCostoI) & "'," _
                             & "'" & Str$(ZCostoII) & "'," _
                             & "'" & Str$(ZPorceI) & "'," _
                             & "'" & Str$(ZPorceII) & "'," _
                             & "'" & Str$(ZDife) & "'," _
                             & "'" & ZFechaI & "'," _
                             & "'" & ZFechaII & "')"

                ListaSQLCnslt.Add(SQLCnlst)

                ZClave = WFecha + ZTerminado

                SQLCnlst = "Select Clave" _
                           & " FROM CargaListaII" _
                           & " Where Clave = '" & ZClave & "'"

                Dim RowListaII As DataRow = GetSingle(SQLCnlst, Operador.Base)
                'VERIFICAMOS SI EXISTE, SI EXISTE LA MODIFICAMOS , SINO LO AGREGAMOS
                If RowListaII IsNot Nothing Then



                    SQLCnlst = "UPDATE CargaListaII SET " _
                                & " Costo = '" & Str$(ZCostoI) & "'" _
                                & " WHERE Clave = '" & ZClave & "'"

                    ListaSQLCnslt.Add(SQLCnlst)

                Else

                    SQLCnlst = "INSERT INTO CargaListaII (" _
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
                    & "'" & Str$(ZCostoI) & "')"

                    ListaSQLCnslt.Add(SQLCnlst)

                End If

                Fila += 1
            Next
        End If

        ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)
      

        Dim WFormula As String = "{CargaLista.Lista} = " & ZVersion & " AND {CargaLista.Linea}  >= " & "0" & " AND {CargaLista.Linea}  <= " & "9999"

        With New VistaPrevia
            .Reporte = New Reporte_Lista_Precios_Compa_Clientes()
            .Formula = WFormula
            If rabtn_Pantalla.Checked = True Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With


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

    Private Sub txt_Cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Cliente.Text.Length = 6 Then
                    txt_Cliente.Text = UCase(txt_Cliente.Text)
                    Dim SQLCnslt As String = "SELECT Razon FROM Cliente WHERE Cliente = '" & txt_Cliente.Text & "'"

                    Dim RowCli As DataRow = GetSingle(SQLCnslt, Operador.Base)

                    If RowCli IsNot Nothing Then
                        txt_DesCliente.Text = RowCli.Item("Razon")
                    Else
                        MsgBox("Verifique el codigo de cliente ingresado")
                        txt_Cliente.SelectAll()
                        txt_Cliente.Focus()
                        txt_DesCliente.Text = ""
                    End If
                Else
                    MsgBox("Verifique el codigo de cliente ingresado")
                    txt_Cliente.SelectAll()
                    txt_Cliente.Focus()
                    txt_DesCliente.Text = ""
                End If
            Case Keys.Escape
                txt_Cliente.Text = ""
        End Select
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
                    txt_Cliente.Focus()
                Else
                    MsgBox("Verifique el campo de fecha a comparar, valor invalido")
                    txt_FechaCompa.SelectAll()
                    txt_FechaCompa.Focus()
                End If
            Case Keys.Escape
                txt_FechaCompa.Text = ""
        End Select
    End Sub

  
    Private Sub Listado_Precios_Compara_Cliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Focus()
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With BuscadorCliente
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarDatosCLiente(Codigo As String, Nombre As String) Implements IBuscadorCliente._ProcesarDatosCLiente
        txt_Cliente.Text = Codigo
        txt_DesCliente.Text = Nombre
    End Sub
End Class
