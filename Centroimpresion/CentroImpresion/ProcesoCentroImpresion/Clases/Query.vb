Imports System.Configuration
Imports System.Data.SqlClient

Module Query

    Public Function GetSingle(ByVal q As String, Optional ByVal cs As String = "SurfactanSa") As DataRow

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q, cs)
        tabla.Load(reader)

        If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

        Return Nothing

    End Function

    Public Function GetAll(ByVal q As String, Optional ByVal cs As String = "SurfactanSa") As DataTable

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q, cs)
        tabla.Load(reader)

        Return tabla

    End Function

    Public Function ExecuteQueryRead(ByVal q As String, Optional ByVal cs As String = "SurfactanSa") As SqlDataReader

        Dim cn As New SqlConnection
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        Dim _cs As String = _GenerarCS(cs)

        cn.ConnectionString = _cs
        cn.Open()

        cm.Connection = cn
        cm.CommandText = q

        dr = cm.ExecuteReader

        Return dr

    End Function

    Public Function _GenerarCS(ByVal cs As String) As String
        Dim _cs As String = ConfigurationManager.ConnectionStrings("CS").ToString
        Return _cs.Replace("#EMPRESA#", cs)
    End Function

    Public Sub ExecuteNonQueries(ByVal ParamArray q As String())
        ExecuteNonQueries("SurfactanSa", q)
    End Sub

    Public Sub ExecuteNonQueries(ByVal cs As String, ParamArray q As String())
        Dim trans As SqlTransaction = Nothing
        Try

            Dim _cs As String = _GenerarCS(cs)

            Using cn As New SqlConnection
                cn.ConnectionString = _cs
                cn.Open()
                trans = cn.BeginTransaction

                Using cm As New SqlCommand()

                    cm.Connection = cn
                    cm.Transaction = trans

                    For Each _q As String In q
                        'MsgBox(_q)
                        cm.CommandText = _q
                        cm.ExecuteNonQuery()
                    Next

                    trans.Commit()
                End Using
            End Using

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Module
