Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Listado_Precios_Grupo



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_HastaLista.KeyPress, txt_HastaLinea.KeyPress, txt_DesdeLista.KeyPress, txt_DesdeLinea.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub





    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WFormula = "{CargaLista.Lista} >= " & txt_DesdeLista.Text & " " _
                       & "AND {CargaLista.Lista} <= " & txt_HastaLista.Text & " " _
                       & "AND {CargaLista.Linea} >= " & txt_DesdeLinea.Text & " " _
                       & "AND {CargaLista.Linea} <= " & txt_HastaLinea.Text & ""

        With New VistaPrevia
            If cbx_Tipo.SelectedIndex = 0 Then
                .Reporte = New Reporte_Precios_Grupo_ConCodigo()
            Else
                .Reporte = New Reporte_Precios_Grupo_SinCodigo()
            End If
            .Formula = WFormula
            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With


    End Sub

    Private Sub Listado_Precios_Grupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_Tipo.SelectedIndex = 0

    End Sub

    Private Sub Listado_Precios_Grupo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeLista.Focus()
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
End Class