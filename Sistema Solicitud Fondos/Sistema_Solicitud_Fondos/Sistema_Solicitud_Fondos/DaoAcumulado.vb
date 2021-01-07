Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class DaoAcumulado

    Public Shared Function buscarAcumulado(ByVal varproveedor As String, ByVal varfecha As String)
        Try
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_acumulado_proveedor", varproveedor, varfecha)
            If tabla.Rows.Count > 0 Then
                Return New LeeAcumulado(tabla(0)("Neto"), tabla(0)("Retenido"), tabla(0)("Anticipo"), tabla(0)("Bruto"), tabla(0)("Iva"))
            Else
                '
                ' En caso de que no exista un registro, se lo da de alta.
                '
                Dim cn As SqlConnection = New SqlConnection()
                Dim cm As SqlCommand = New SqlCommand("")
                Dim dr As SqlDataReader

                cn.ConnectionString = Proceso._ConectarA
                cn.Open()
                cm.Connection = cn

                Dim WFecha = varfecha
                Dim WProveedor = varproveedor.PadLeft(11, "0")
                Dim WClave = WFecha & WProveedor

                cm.CommandText = "INSERT INTO Retencion (Clave, Fecha, Proveedor, Neto, Anticipo, Bruto, Iva, Retenido) VALUES ('" & WClave & "','" & WFecha & "','" & WProveedor & "', 0,0,0,0,0)"
                cm.ExecuteNonQuery()

                Return New LeeAcumulado(0, 0, 0, 0, 0)
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

End Class
