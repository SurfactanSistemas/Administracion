Imports System.Data.SqlClient

Public Class SQLConnector

    Shared Sub conexionSql(ByVal cn As SqlConnection, ByVal cm As SqlCommand)
        Dim sconcompleto As String = Globals.getConnectionString()

        cn.ConnectionString = sconcompleto
        cm.Connection = cn
        cn.Open()
    End Sub

    Public Shared Function tryConnection(ByVal connectionString As String)
        Try
            Dim connection As New SqlConnection
            connection.ConnectionString = connectionString
            connection.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function retrieveDataTable(ByVal procedure As String, ByVal ParamArray values() As Object) As DataTable
        Dim args As List(Of String) = _generateArguments(procedure)
        Return _retrieveDataTable(procedure, args, values)
    End Function

    Public Shared Function retrieveDataTable(ByVal procedure As String) As DataTable
        Return _retrieveDataTable(procedure, Nothing, Nothing)
    End Function

    Public Shared Sub executeProcedure(ByVal procedure As String, ByVal ParamArray values() As Object)
        Dim args As List(Of String) = _generateArguments(procedure)
        _executeProcedure(procedure, args, values)
    End Sub

    Public Shared Sub executeProcedure(ByVal procedure As String)
        _executeProcedure(procedure, Nothing, Nothing)
    End Sub

    Public Shared Function checkIfExists(ByVal procedure As String, ByVal ParamArray values() As Object) As Boolean
        Dim args As List(Of String) = _generateArguments(procedure)
        Return _checkIfExists(procedure, args, values)
    End Function

    Public Shared Function checkIfExists(ByVal procedure As String) As Boolean
        Return _checkIfExists(procedure, Nothing, Nothing)
    End Function

    Public Shared Function executeProcedureWithReturnValue(ByVal procedure As String, ByVal ParamArray values() As Object) As Integer
        Dim args As List(Of String) = _generateArguments(procedure)
        Return _executeProcedureWithReturnValue(procedure, args, values)
    End Function

    Private Shared Function procedurePrefix()
        Return "PR_"
    End Function

    Private Shared Sub _executeProcedure(ByVal procedureName As String, ByVal args As List(Of String), ByVal ParamArray values() As Object)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim procedure As String = procedurePrefix() & procedureName

        Try
            conexionSql(cn, cm)
            cm.CommandType = CommandType.StoredProcedure
            'schema_name
            cm.CommandText = "" + procedure
            If (_validateArgumentsAndParameters(args, values)) Then
                _loadSqlCommand(args, cm, values)
            End If
            cm.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Shared Function _checkIfExists(ByVal procedureName As String, ByVal args As List(Of String), ByVal ParamArray values() As Object) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        Dim procedure As String = procedurePrefix() & procedureName

        Try
            conexionSql(cn, cm)
            cm.CommandType = CommandType.StoredProcedure
            'schema_name
            cm.CommandText = "" + procedure
            If (_validateArgumentsAndParameters(args, values)) Then
                _loadSqlCommand(args, cm, values)
            End If
            dr = cm.ExecuteReader()
            Return dr.HasRows
        Catch ex As Exception
            Throw ex
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
            End If
        End Try
    End Function

    Private Shared Function _executeProcedureWithReturnValue(ByVal procedureName As String, ByVal args As List(Of String), ByVal ParamArray values() As Object) As Integer
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim procedure As String = procedurePrefix() & procedureName

        Try
            conexionSql(cn, cm)
            cm.CommandType = CommandType.StoredProcedure
            'schema_name
            cm.CommandText = "" + procedure
            If (_validateArgumentsAndParameters(args, values)) Then
                _loadSqlCommand(args, cm, values)
            End If
            cm.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cm.ExecuteNonQuery()
            Return Val(cm.Parameters("@RETURN_VALUE").Value)
        Catch e As Exception
            Return -1
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
            End If
        End Try
    End Function

    Private Shared Function _retrieveDataTable(ByVal procedureName As String, ByVal args As List(Of String), ByVal ParamArray values() As Object) As DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        Dim procedure As String = procedurePrefix() & procedureName

        Try
            conexionSql(cn, cm)
            cm.CommandType = CommandType.StoredProcedure
            'schema_name
            cm.CommandText = "" + procedure

            If (_validateArgumentsAndParameters(args, values)) Then
                _loadSqlCommand(args, cm, values)
            End If

            dr = cm.ExecuteReader()
            dt.Load(dr)
            Return dt
        Catch e As Exception
            Throw e
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
            End If
        End Try
    End Function

    Private Shared Function _generateArguments(ByVal procedureName As String) As List(Of String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        Dim procedure As String = procedurePrefix() & procedureName

        Dim args As List(Of String) = New List(Of String)
        Try
            conexionSql(cn, cm)
            cm.CommandType = CommandType.Text
            cm.CommandText = "SELECT PARAMETER_NAME FROM information_schema.parameters WHERE SPECIFIC_NAME='" & procedure & "'"
            dr = cm.ExecuteReader()
            dt.Load(dr)
            For Each d As DataRow In dt.Rows
                args.Add(d(0).ToString)
            Next
            Return args
        Catch e As Exception
            Return Nothing
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
            End If
        End Try
    End Function


    Private Shared Function _validateArgumentsAndParameters(ByVal args As List(Of String), ByVal ParamArray values() As Object)

        If (Not args Is Nothing And Not values Is Nothing) Then
            If (args.Count <> values.Length) Then
                Throw New ApplicationException("La cantidad de parámetros enviados (" & values.Length & ") no coincide con la cantidad de argumentos de la acción de SQL (" & args.Count & ")")
            End If
            Return True
        Else
            Return False
        End If
    End Function


    Private Shared Sub _loadSqlCommand(ByVal args As List(Of String), ByVal cm As SqlCommand, ByVal ParamArray values() As Object)
        For i As Integer = 0 To args.Count - 1
            cm.Parameters.AddWithValue(args(i), values(i))
        Next
    End Sub
End Class
