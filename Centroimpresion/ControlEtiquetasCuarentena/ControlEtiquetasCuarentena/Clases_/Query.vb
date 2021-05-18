Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data

Module Query

    Public Function GetSingle(ByVal q As String, Optional ByVal empresa As String = "SurfactanSa") As DataRow

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q, empresa)
        tabla.Load(reader)

        If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

        Return Nothing

    End Function

    Public Function GetAll(ByVal q As String, Optional ByVal empresa As String = "SurfactanSa") As DataTable

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q, empresa)
        tabla.Load(reader)

        Return tabla

    End Function

    Public Function ExecuteQueryRead(ByVal q As String, Optional ByVal empresa As String = "SurfactanSa") As SqlDataReader

        Dim cn As New SqlConnection
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        Dim cs As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

        cs = cs.Replace("#EMPRESA#", empresa)

        cn.ConnectionString = cs 'ConfigurationManager.ConnectionStrings("CS").ToString
        cn.Open()

        cm.Connection = cn
        cm.CommandText = q

        dr = cm.ExecuteReader

        Return dr

    End Function

    Public Sub ExecuteNonQueries(ByVal q As String)
        ExecuteNonQueries("SurfactanSa", q)
    End Sub

    Public Sub ExecuteNonQueries(ByVal empresa As String, ByVal ParamArray q As String())
        Dim trans As SqlTransaction = Nothing
        Try
            Using cn As New SqlConnection

                Dim cs As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

                cs = cs.Replace("#EMPRESA#", empresa)

                cn.ConnectionString = cs 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()
                trans = cn.BeginTransaction

                Using cm As New SqlCommand()

                    cm.Connection = cn
                    cm.Transaction = trans

                    For Each _q As String In q
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
