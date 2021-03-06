﻿Imports System.Data.SqlClient
Imports System.IO
Module Query

    Public Function GetSingle(ByVal q As String, Optional ByVal WBase As String = "", Optional ByVal TmbPellital As Boolean = False) As DataRow
        Try
            If WBase.Trim = "" Then WBase = Operador.Base

            Dim tabla As New DataTable

            Using cn As New SqlConnection

                cn.ConnectionString = _ConectarA(WBase, TmbPellital) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()

                Using cm As New SqlCommand(q)

                    cm.Connection = cn

                    Using dr As SqlDataReader = cm.ExecuteReader(CommandBehavior.SingleResult)
                        tabla.Load(dr)
                    End Using

                End Using

            End Using

            If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

            Return Nothing

        Catch ex As Exception

            'Using sw As New StreamWriter("C:\sql.txt")
            Using sw As New StreamWriter("sql.txt")
                sw.WriteLine(q)
            End Using

            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function GetAll(ByVal q As String, Optional ByVal WBase As String = "", Optional ByVal TmbPellital As Boolean = False) As DataTable

        If WBase.Trim = "" Then WBase = Operador.Base
        Try

            Dim tabla As New DataTable

            Using cn As New SqlConnection

                cn.ConnectionString = _ConectarA(WBase, TmbPellital) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()

                Using cm As New SqlCommand(q)

                    cm.Connection = cn

                    Using dr As SqlDataReader = cm.ExecuteReader
                        tabla.Load(dr)
                    End Using

                End Using

            End Using

            Return tabla

        Catch ex As Exception

            'Using sw As New StreamWriter("C:\sql.txt")
            Using sw As New StreamWriter("sql.txt")
                sw.WriteLine(q)
            End Using

            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ExecuteQueryRead(ByVal q As String, Optional ByVal WBase As String = "SurfactanSa") As SqlDataReader

        Dim cn As New SqlConnection
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        cn.ConnectionString = _ConectarA(WBase) 'ConfigurationManager.ConnectionStrings("CS").ToString
        cn.Open()

        cm.Connection = cn
        cm.CommandText = q

        dr = cm.ExecuteReader

        Return dr

    End Function

    Public Sub ExecuteNonQueries(ByVal ParamArray q As String())

        Dim trans As SqlTransaction = Nothing
        Dim s As String = ""
        Try
            If q.Length = 0 Then Throw New Exception("No se han pasado consultas para ejecutar.")

            Using cn As New SqlConnection
                cn.ConnectionString = _ConectarA(Operador.Base) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()
                trans = cn.BeginTransaction

                Using cm As New SqlCommand()

                    cm.Connection = cn
                    cm.Transaction = trans

                    For Each _q As String In q
                        s = _q
                        cm.CommandText = _q
                        cm.ExecuteNonQuery()

                    Next

                    trans.Commit()
                End Using
            End Using

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            'Using sw As New StreamWriter("C:\sql.txt")
            Using sw As New StreamWriter("sql.txt")
                sw.WriteLine(s)
            End Using

            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub ExecuteNonQueries(ByVal q As String)
        ExecuteNonQueries({q})
    End Sub

    Public Sub ExecuteNonQueries(ByVal empresa As String, ByVal ParamArray q As String())

        Dim trans As SqlTransaction = Nothing
        Dim s As String = ""
        Try
            If q.Length = 0 Then Throw New Exception("No se han pasado consultas para ejecutar.")

            Using cn As New SqlConnection
                cn.ConnectionString = _ConectarA(empresa) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()
                trans = cn.BeginTransaction

                Using cm As New SqlCommand()

                    cm.Connection = cn
                    cm.Transaction = trans

                    For Each _q As String In q
                        s = _q
                        cm.CommandText = _q
                        cm.ExecuteNonQuery()
                    Next

                    trans.Commit()
                End Using
            End Using

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()
            'Using sw As New StreamWriter("C:\sql.txt")
            Using sw As New StreamWriter("sql.txt")
                sw.WriteLine(s)
            End Using

            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function CallProcedureWithReturns(ByVal proc As String, ByVal params As Dictionary(Of String, Object), Optional ByVal Base As String = "") As DataTable
        If Base.Trim = "" Then Base = Operador.Base
        Dim tabla As New DataTable
        Try

            Using cn As New SqlConnection
                cn.ConnectionString = _ConectarA(Base) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()

                Using cm As New SqlCommand()

                    cm.CommandType = CommandType.StoredProcedure
                    cm.CommandText = proc
                    cm.Connection = cn

                    For Each v As KeyValuePair(Of String, Object) In params
                        Dim p As New SqlParameter
                        p.DbType = SqlDbType.VarChar
                        p.Value = v.Value
                        p.ParameterName = v.Key
                        cm.Parameters.Add(p)
                    Next

                    Using dr As SqlDataReader = cm.ExecuteReader()
                        tabla.Load(dr)
                    End Using

                End Using
            End Using

            Return tabla

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

End Module
