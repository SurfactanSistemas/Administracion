Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query


Public Class Listado_VentasDiarasPendientesDePago

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeFecha.Text.Length = 10 Then
                    If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                        txt_HastaFecha.Focus()
                    Else
                        MsgBox("La fecha desde es invalida, verificar")
                        txt_DesdeFecha.SelectAll()
                    End If
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaFecha.Text.Length = 10 Then
                    If ValidaFecha(txt_HastaFecha.Text) = "S" Then

                    Else
                        MsgBox("La fecha hasta es invalida, verificar")
                        txt_HastaFecha.SelectAll()
                    End If
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If ValidaFecha(txt_DesdeFecha.Text) <> "S" Then
            If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                MsgBox("Las fechas son invalidas, verificar ambas fechas")
                txt_DesdeFecha.Focus()
                Exit Sub
            End If
            MsgBox("La fecha desde es invalida, verificar")
            Exit Sub
        End If
        If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
            MsgBox("La fecha hasta es invalida, verificar")
            Exit Sub
        End If

        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)
        
        Dim SQLCnslt As String = "UPDATE Ctacte SET Importe4 = 0, " _
                                & "Importe5 = 0, " _
                                & "Importe6 = 0, " _
                                & "Importe7 = 0, " _
                                & "Importe8 = 0"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)



        SQLCnslt = "UPDATE Ctacte SET " _
                    & "Importe4 = Saldo " _
                    & "WHERE OrdFecha >= '" & WDesde & "' " _
                    & "AND OrdFecha <= '" & WHasta & "'"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)
        
        
        Dim WTitulo As String = "del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text
        
        Dim WFormula As String = "{CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'"

        With New VistaPrevia
            .Reporte = New Reporte_Listado_VentasDiariasPendientesPago()
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
End Class