Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class LimpiarCargaInventario : Implements IClaveAutorizacion

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Está seguro de querer limpiar toda la información de Inventario?" & vbCrLf & vbCrLf & "¡ATENCIÓN! ESTE PROCESO NO PUEDE RETROTRAERSE", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        Dim frm As New IngresoClave
        frm.ShowDialog(Me)
        Close()
    End Sub

    Public Sub ProcesarClave(ByVal WAutorizado As Boolean) Implements IClaveAutorizacion.ProcesarClave

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE Inventario")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

            MsgBox("Inventario Eliminado Correctamente!", MsgBoxStyle.Information)

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