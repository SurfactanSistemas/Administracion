Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class VerificacionCorrelatividades

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub VerificacionCorrelatividades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbTodos.Checked = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Numero As Movimiento, Producto = CASE Tipo WHEN 'T' THEN Terminado ELSE Articulo END, ISNULL(Talon, 0) Talon, ISNULL(Observaciones, '') Obs FROM Inventario ORDER BY Talon")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

            If tabla.Rows.Count > 0 Then

                Dim WNumero = 0

                Dim tabla2 As New DSVerificaCorrelatividad

                Dim i2 = 0

                For i = 1 To tabla.Rows(tabla.Rows.Count - 1).Item("Talon")

                    If WNumero = 0 Then WNumero = tabla.Rows(i2).Item("Talon")

                    Dim _r = tabla2.Tables("Detalles").NewRow

                    With _r

                        .Item("Numero") = WNumero
                        .Item("Descripcion") = IIf(WNumero = tabla.Rows(i2).Item("Talon"), "TALÓN", "")
                        .Item("Estado") = IIf(WNumero = tabla.Rows(i2).Item("Talon"), "", "FALTANTE")
                        .Item("Producto") = IIf(WNumero = tabla.Rows(i2).Item("Talon"), tabla.Rows(i2).Item("Producto"), "")
                        .Item("Empresa") = IIf(Helper._EsPellital, "PELLITAL", "SURFACTAN")
                        .Item("Observaciones") = IIf(WNumero = tabla.Rows(i2).Item("Talon"), tabla.Rows(i2).Item("Obs"), "")
                        .Item("Movimiento") = IIf(WNumero = tabla.Rows(i2).Item("Talon"), tabla.Rows(i2).Item("Movimiento"), "")

                    End With

                    tabla2.Tables("Detalles").Rows.Add(_r)

                    If WNumero = tabla.Rows(i2).Item("Talon") Then i2 += 1

                    WNumero += 1

                Next

                Dim rpt As New VerificaCorrelatividadReporte
                Dim frm As New VistaPrevia

                rpt.SetDataSource(tabla2)

                frm.Reporte = rpt

                If rbSoloFaltantes.Checked Then
                    frm.Formula = "{Detalles.Estado} <> ''"
                End If

                frm.Mostrar()

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class