Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class ControlMarcaLote

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Dim WInventarioTotal As DataTable = Query.GetAll("SELECT Tipo, Articulo, Terminado, Lote FROM Inventario WHERE NOT (Articulo = '  -   -   ' AND Terminado = '  -     -   ') ORDER BY Clave", Conexion.EmpresaDeTrabajo)
            Dim WSinProblemas = True

            With ProgressBar1
                .Value = 0
                .Maximum = WInventarioTotal.Rows.Count + 5
            End With

            For Each WProducto As datarow In WInventarioTotal.rows

                With WProducto

                    If .Item("Tipo") = "M" Then
                        '
                        ' Controlo si tiene Marca de Controla Lote. En caso de que no, verifico que exista el Lote en algún Laudo o Guía.
                        '

                        Dim WArticulo As DataRow = Query.GetSingle("SELECT ISNULL(Controla, 0) Controla FROM Articulo WHERE Codigo = '" & .Item("Articulo") & "'")

                        If Not IsNothing(WArticulo) Then

                            If Val(WArticulo.Item("Controla")) = 1 Then
                                WSinProblemas = False
                                MsgBox("La Materia Prima " & .Item("Articulo") & " no posee Marca de Control Lote.")
                            Else

                                Dim WLaudo As DataRow = Query.GetSingle("SELECT Laudo FROM Laudo WHERE Laudo = '" & .Item("Lote") & "' AND Articulo = '" & .Item("Articulo") & "'", Conexion.EmpresaDeTrabajo)

                                If IsNothing(WLaudo) Then

                                    Dim WGuia As DataRow = Query.GetSingle("SELECT Lote FROM Guia WHERE Lote = '" & .Item("Lote") & "' AND Articulo = '" & .Item("Articulo") & "'", Conexion.EmpresaDeTrabajo)

                                    If IsNothing(WGuia) Then
                                        WSinProblemas = False
                                        MsgBox("No existe el Lote " & .Item("Lote") & " de la Materia Prima " & .Item("Articulo"))
                                    End If

                                End If

                            End If

                        Else
                            WSinProblemas = False
                            MsgBox("No existe el articulo " & .Item("Articulo"))
                        End If

                    Else
                        '
                        ' Controlo si el Producto Terminado tiene Marca de no controla Lote. En caso de que no, compruebo la existencia del Lote (Partida) en alguna Hoja de Producción o Guia.
                        '

                        Dim WProductoTerminado As DataRow = Query.GetSingle("SELECT ISNULL(Controla, 0) Controla FROM Terminado WHERE Codigo = '" & .Item("Terminado") & "'")

                        If Not IsNothing(WProductoTerminado) Then

                            If Val(WProductoTerminado.Item("Controla")) = 1 Then
                                WSinProblemas = False
                                MsgBox("El Producto Terminado " & .Item("Terminado") & " no tiene Marca de Controla Lote.")
                            Else

                                Dim WHoja As DataRow = Query.GetSingle("SELECT Hoja FROM Hoja WHERE Hoja = '" & .Item("Lote") & "' AND Producto = '" & .Item("Terminado") & "' and Renglon = 1", Conexion.EmpresaDeTrabajo)

                                If IsNothing(WHoja) Then

                                    Dim WGuia As DataRow = Query.GetSingle("SELECT Lote FROM Guia WHERE Lote = '" & .Item("Lote") & "' AND Terminado = '" & .Item("Terminado") & "'", Conexion.EmpresaDeTrabajo)

                                    If IsNothing(WGuia) Then
                                        WSinProblemas = False
                                        MsgBox("No existe el Lote " & .Item("Lote") & " del Producto Terminado " & .Item("Terminado"))
                                    End If

                                End If

                            End If

                        Else
                            WSinProblemas = False
                            MsgBox("El Producto Terminado " & .Item("Terminado") & " no eixte.")
                        End If

                    End If

                End With

                ProgressBar1.Increment(1)

            Next

            ProgressBar1.Value = 0

            If WSinProblemas Then
                MsgBox("Finalizó la revisión sin encontrar ningún problema.")
            Else
                MsgBox("Finalizó la revisión encontrándose uno o mas problemas durante la misma.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ControlMarcaLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
    End Sub
End Class