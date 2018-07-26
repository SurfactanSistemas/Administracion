Imports System.Data.SqlClient
Imports System.IO

Public Class EjemploFormulario

    Private Sub EjemploFormulario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        ' Limpiamos los campos.
        _LimpiarCampos()
        
    End Sub

    Private Sub _LimpiarCampos()

    End Sub

    Private Sub EjemploFormulario_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

    End Sub

End Class