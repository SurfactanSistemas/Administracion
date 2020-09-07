Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Remitos

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        If ValidaFecha(txt_DesdeFecha.Text) <> "S" Then
            MsgBox("La fecha desde no es una fecha valida, verificar")

            If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                MsgBox("La fecha hasta no es una fecha valida, verificar")
            End If
            txt_DesdeFecha.SelectAll()
            txt_DesdeFecha.Focus()
            Exit Sub
        Else
            If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                MsgBox("La fecha hasta no es una fecha valida, verificar")
                txt_HastaFecha.SelectAll()
                txt_HastaFecha.Focus()
                Exit Sub
            End If
        
        End If



        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)

        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)



        Dim WTitulo As String = "Del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text



        Dim Wformula As String = "({CtaCte.Tipo} = '" & "01" & "' or {CtaCte.Tipo} = '" & "10" & "') " _
                                 & "AND {CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'"
        

        With New VistaPrevia
            .Reporte = New Reporte_Listado_Remitos()
            .Reporte.SetParameterValue(0, WTitulo)
            .Reporte.SetParameterValue(1, Operador.Base)
            .Formula = Wformula
            If rabtn_Pantalla.Checked Then

                .Mostrar()
            Else
                .Imprimir()
            End If
        End With
        

      

      



    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha desde no es una fecha valida, verificar")
                    txt_DesdeFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) = "S" Then

                Else
                    MsgBox("La fecha hasta no es una fecha valida, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    Private Sub Listado_Remitos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeFecha.Focus()
    End Sub
End Class