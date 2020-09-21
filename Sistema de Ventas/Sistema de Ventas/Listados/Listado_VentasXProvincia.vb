Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Listado_VentasXProvincia

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        'SI ALGUNA FECHA EN INVALIDA,SALIMOS DE LA FUNCION
        If ValidaFecha(txt_FechaDesde.Text) <> "S" Then
            MsgBox("Fecha 'DESDE' invalida, verificar", vbExclamation)
            
            If ValidaFecha(txt_FechaDesde.Text) <> "S" Then
                MsgBox("Fecha 'HASTA' invalida, verificar", vbExclamation)
                Exit Sub
            End If
            Exit Sub
        End If


        Dim WDesde As String = ordenaFecha(txt_FechaDesde.Text)
        Dim WHasta As String = ordenaFecha(txt_FechaHasta.Text)

        Dim Lista As New List(Of String)

        Dim SQLCnslt As String = "UPDATE CtaCte SET ImpoIbTucu = 0 WHERE ImpoIbTucu IS NULL"
        Lista.Add(SQLCnslt)

        SQLCnslt = "UPDATE CtaCte SET ImpoIbCiudad = 0 WHERE ImpoIbCiudad IS NULL"
        Lista.Add(SQLCnslt)

        SQLCnslt = "UPDATE CtaCte SET Importe4 = 0, Importe5 = 0, Importe6 = 0, Importe7 = 0  , Importe8 = 0"
        Lista.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = Neto, Importe5	= Iva1, Importe6 = Iva2, Importe7 = 0, " _
                    & "Importe8 = ImpoIb WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' and Iva1 <> 0"
        Lista.Add(SQLCnslt)

        SQLCnslt = "UPDATE Ctacte SET Importe4 = 0, Importe5 = 0, Importe6 = 0, Importe7 = Neto, Importe8 = ImpoIb " _
            & "WHERE OrdFecha >= '" & WDesde & "' AND OrdFecha <= '" & WHasta & "' and Iva1 = 0"
        Lista.Add(SQLCnslt)

        ExecuteNonQueries("SurfactanSa", Lista.ToArray())

        Dim WTitulo As String = "del " + txt_FechaDesde.Text + " al " + txt_FechaHasta.Text

        Dim WFormula As String = "{CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'"

        With New VistaPrevia
            .Reporte = New ReporteListadoVentasXProvincia()
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
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

    Private Sub txt_FechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaDesde.Text) = "S" Then
                    txt_FechaHasta.Focus()
                Else
                    MsgBox("Fecha invalida, verificar", vbExclamation)
                    txt_FechaDesde.SelectAll()
                    txt_FechaDesde.Focus()
                End If
            Case Keys.Escape
                txt_FechaDesde.Text = ""
        End Select
    End Sub

    Private Sub txt_FechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaHasta.Text) = "S" Then
                    btn_Aceptar_Click(Nothing, Nothing)
                Else
                    MsgBox("Fecha invalida, verificar", vbExclamation)
                    txt_FechaHasta.SelectAll()
                    txt_FechaHasta.Focus()
                End If
            Case Keys.Escape
                txt_FechaHasta.Text = ""
        End Select
    End Sub
End Class