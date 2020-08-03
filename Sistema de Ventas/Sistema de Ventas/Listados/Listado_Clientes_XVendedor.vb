Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_Clientes_XVendedor



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_HastaVendedor.KeyPress, txt_DesdeVendedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub Listado_Clientes_XVendedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeVendedor.Focus()
    End Sub

    Private Sub txt_DesdeVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeVendedor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_DesdeVendedor.Text) <> "" Then
                    txt_HastaVendedor.Focus()
                End If

            Case Keys.Escape
                txt_DesdeVendedor.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaVendedor.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_HastaVendedor.Text = ""
        End Select
    End Sub
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


       

       

       
        Dim WFormula As String = "{Cliente.Vendedor} >= " & txt_DesdeVendedor.Text & " AND {Cliente.Vendedor} <= " & txt_HastaVendedor.Text & ""

        With New VistaPrevia
            .Reporte = New Reporte_Clientes_XVendedor
            .Reporte.SetParameterValue(0, Operador.Base)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With
        
    End Sub


    Private Sub Listado_Clientes_XVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_DesdeVendedor.Text = "0"
        txt_HastaVendedor.Text = "9999"
    End Sub
End Class