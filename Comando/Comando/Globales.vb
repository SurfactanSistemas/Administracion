Imports System.Data.SqlClient

Public Class Globales
    Public Shared Operador As String = ""
    Public Const TABLA_CURSOS = "Tarea"
    Public Const TABLA_TAREAS = "Curso"

    Public Shared Function _ExisteTarea(ByVal codigo As String)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM " & TABLA_TAREAS & " WHERE Codigo = '" & Trim(codigo) & "'")
        Dim dr As SqlDataReader

        If IsNothing(codigo) Or Trim(codigo) = "" Then : Return False : End If

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer chequear la existencia de la tarea indicada en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False

    End Function

End Class
