Imports Util

Public Class Listado_GastosImportacionXCarpeta

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Desde.KeyPress, txt_Hasta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WDesde As String
        Dim WHasta As String

        If Trim(txt_Desde.Text) = "" Then
            WDesde = "0"
        Else
            WDesde = txt_Desde.Text
        End If

        If Trim(txt_Hasta.Text) = "" Then
            WHasta = "999999"
        Else
            WHasta = txt_Hasta.Text
        End If


        Dim WFormula As String = "{Movgas.Carpeta} >= " & WDesde & " AND {Movgas.Carpeta} <= " & WHasta


        With New VistaPrevia
            .Reporte = New Reporte_GastosImportacionXCarpeta()
            .Reporte.SetParameterValue(0, Operador.Base)
            .Formula = WFormula
            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

    Private Sub txt_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Desde.Text <> "" Then
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

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
End Class