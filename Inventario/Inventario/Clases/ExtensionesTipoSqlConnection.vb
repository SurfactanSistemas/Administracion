Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Module ExtensionesTipoSqlConnection

    ''' <summary>
    ''' Comprueba el estado de la Conexión SQL.
    ''' </summary>
    <Extension()>
    Function IsOpened(ByVal cn As SqlConnection) As Boolean

        Return cn.State = ConnectionState.Open

    End Function

End Module
