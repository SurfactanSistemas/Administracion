Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Listado_GralProductos



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hasta.KeyPress, txt_Desde.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub




    Private Sub Listado_GralProductos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Desde.SelectAll()
        txt_Desde.Focus()
    End Sub


    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Desde.Text <> "" Then
                    txt_Hasta.SelectAll()
                    txt_Hasta.Focus()
                End If
            Case Keys.Escape
                txt_Desde.Text = ""
        End Select
    End Sub

    Private Sub txt_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_Hasta.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        REM On Error GoTo WError

        Dim ZBlanco As String = ""

        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "UPDATE Terminado SET " _
                                & " ImpreEnvase1  = '" & ZBlanco & "'," _
                                & " ImpreEnvase2  = '" & ZBlanco & "'," _
                                & " ImpreEnvase3  = '" & ZBlanco & "'," _
                                & " ImpreEnvase4  = '" & ZBlanco & "'," _
                                & " ImpreEnvase5  = '" & ZBlanco & "'," _
                                & " ImpreEnvase6  = '" & ZBlanco & "'," _
                                & " ImpreEnvase7  = '" & ZBlanco & "'"

        ListaSQLCnslt.Add(SQLCnslt)


        Dim ZMarca As String = "X"

        REM
        REM Bolsas x 20
        REM


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase1  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 13 " _
                    & " OR Envase2 = 13 " _
                    & " OR Envase3 = 13 " _
                    & " OR Envase4 = 13 " _
                    & " OR Envase5 = 13 " _
                    & " OR Envase6 = 13 "

        ListaSQLCnslt.Add(SQLCnslt)

        REM
        REM Bolsas x 25
        REM

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase2  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 9 " _
                    & " OR Envase2 = 9 " _
                    & " OR Envase3 = 9 " _
                    & " OR Envase4 = 9 " _
                    & " OR Envase5 = 9 " _
                    & " OR Envase6 = 9 "

        ListaSQLCnslt.Add(SQLCnslt)

        REM
        REM Tambores x 120
        REM

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase3  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 12 " _
                    & " OR Envase2 = 12 " _
                    & " OR Envase3 = 12 " _
                    & " OR Envase4 = 12 " _
                    & " OR Envase5 = 12 " _
                    & " OR Envase6 = 12 "

        ListaSQLCnslt.Add(SQLCnslt)


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase3  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 21 " _
                    & " OR Envase2 = 21 " _
                    & " OR Envase3 = 21 " _
                    & " OR Envase4 = 21 " _
                    & " OR Envase5 = 21 " _
                    & " OR Envase6 = 21 "

        ListaSQLCnslt.Add(SQLCnslt)
        REM
        REM Tambores x 150
        REM


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase4  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 52 " _
                    & " OR Envase2 = 52 " _
                    & " OR Envase3 = 52 " _
                    & " OR Envase4 = 52 " _
                    & " OR Envase5 = 52 " _
                    & " OR Envase6 = 52 "

        ListaSQLCnslt.Add(SQLCnslt)

        REM
        REM Tambores x 200
        REM

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase5  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 2 " _
                    & " OR Envase2 = 2 " _
                    & " OR Envase3 = 2 " _
                    & " OR Envase4 = 2 " _
                    & " OR Envase5 = 2 " _
                    & " OR Envase6 = 2 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase5  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 5 " _
                    & " OR Envase2 = 5 " _
                    & " OR Envase3 = 5 " _
                    & " OR Envase4 = 5 " _
                    & " OR Envase5 = 5 " _
                    & " OR Envase6 = 5 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase5  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 20 " _
                    & " OR Envase2 = 20 " _
                    & " OR Envase3 = 20 " _
                    & " OR Envase4 = 20 " _
                    & " OR Envase5 = 20 " _
                    & " OR Envase6 = 20 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                   & " ImpreEnvase5  = '" & ZMarca & "'" _
                   & " WHERE Envase1 = 23 " _
                   & " OR Envase2 = 23 " _
                   & " OR Envase3 = 23 " _
                   & " OR Envase4 = 23 " _
                   & " OR Envase5 = 23 " _
                   & " OR Envase6 = 23 "

        ListaSQLCnslt.Add(SQLCnslt)


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase5  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 25 " _
                    & " OR Envase2 = 25 " _
                    & " OR Envase3 = 25 " _
                    & " OR Envase4 = 25 " _
                    & " OR Envase5 = 25 " _
                    & " OR Envase6 = 25 "

        ListaSQLCnslt.Add(SQLCnslt)

        REM
        REM Cist. x 1000
        REM


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase6  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 11 " _
                    & " OR Envase2 = 11 " _
                    & " OR Envase3 = 11 " _
                    & " OR Envase4 = 11 " _
                    & " OR Envase5 = 11 " _
                    & " OR Envase6 = 11 "

        ListaSQLCnslt.Add(SQLCnslt)

        REM
        REM pallets
        REM

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 69 " _
                    & " OR Envase2 = 69 " _
                    & " OR Envase3 = 69 " _
                    & " OR Envase4 = 69 " _
                    & " OR Envase5 = 69 " _
                    & " OR Envase6 = 69 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " Where Envase1 = 70 " _
                    & " or Envase2 = 70 " _
                    & " or Envase3 = 70 " _
                    & " or Envase4 = 70 " _
                    & " or Envase5 = 70 " _
                    & " or Envase6 = 70 "

        ListaSQLCnslt.Add(SQLCnslt)


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " Where Envase1 = 71 " _
                    & " or Envase2 = 71 " _
                    & " or Envase3 = 71 " _
                    & " or Envase4 = 71 " _
                    & " or Envase5 = 71 " _
                    & " or Envase6 = 71 "

        ListaSQLCnslt.Add(SQLCnslt)


        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 72 " _
                    & " OR Envase2 = 72 " _
                    & " OR Envase3 = 72 " _
                    & " OR Envase4 = 72 " _
                    & " OR Envase5 = 72 " _
                    & " OR Envase6 = 72 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 73 " _
                    & " OR Envase2 = 73 " _
                    & " OR Envase3 = 73 " _
                    & " OR Envase4 = 73 " _
                    & " OR Envase5 = 73 " _
                    & " OR Envase6 = 73 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " WHERE Envase1 = 74 " _
                    & " OR Envase2 = 74 " _
                    & " OR Envase3 = 74 " _
                    & " OR Envase4 = 74 " _
                    & " OR Envase5 = 74 " _
                    & " OR Envase6 = 74 "

        ListaSQLCnslt.Add(SQLCnslt)

        SQLCnslt = "UPDATE Terminado SET " _
                    & " ImpreEnvase7  = '" & ZMarca & "'" _
                    & " Where Envase1 = 75 " _
                    & " or Envase2 = 75 " _
                    & " or Envase3 = 75 " _
                    & " or Envase4 = 75 " _
                    & " or Envase5 = 75 " _
                    & " or Envase6 = 75 "

        ListaSQLCnslt.Add(SQLCnslt)

        ExecuteNonQueries({SQLCnslt}, Operador.Base)


        Dim WFormula As String = "{Terminado.Linea} >= " & txt_Desde.Text & " AND {Terminado.Linea} <= " & txt_Hasta.Text & "" _
                                        & " AND {Terminado.ListaProducto} = 1 "
        With New VistaPrevia
            .Reporte = New Reporte_ListadoGeneral_Producto()
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With


        


    End Sub
End Class