Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Minutas

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()

    End Sub

    Private Sub Listado_Minutas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeFecha.Focus()
    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha es invalida, verificar")
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
                    MsgBox("La fecha es invalida, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        
        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)
    
        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)

        ' Dim WTitulo As String = "Entre el " & txt_DesdeFecha.Text & " hasta el " + txt_HastaFecha.Text

        

        Dim WFormula As String = "{Minuta.OrdFecha} >= '" & WDesde & "' AND {Minuta.OrdFecha} <= '" & WHasta & "'"

        With New VistaPrevia
            .Reporte = New Reporte_Listado_Minutas()
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With
        
       
       
    End Sub
End Class