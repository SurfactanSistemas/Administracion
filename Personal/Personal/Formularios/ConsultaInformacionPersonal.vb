Imports System.Data.SqlClient
Imports System.IO

Public Class ConsultaInformacionPersonal

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        ' Limpiamos los campos.
        _LimpiarCampos()

        ' Limpiamos los archivos cargados en notas.

        ' Posicionamos en Orden y mostramos la primer pestaña.
        TabControl1.SelectedIndex = 0
        txtDni.Focus()

    End Sub

    Private Sub _LimpiarCampos()

        For Each _txt As TextBox In _CamposDeTexto()
            _txt.Text = ""
        Next

        For Each _m As MaskedTextBox In {}
            _m.Clear()
        Next

        For Each _c As ComboBox In {}
            _c.SelectedIndex = 0
        Next

        pnlConsulta.Visible = False

    End Sub

    Private Function _CamposDeTexto() As TextBox()
        Return {txtAyuda}
    End Function

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDni.Focus
    End Sub

Private Sub TabPage3_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TabPage3.Click

End Sub
End Class