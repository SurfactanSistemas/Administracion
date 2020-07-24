﻿Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Namespace Clases

    Public Class Query

        Public Shared Function GetSingle(ByVal q As String, Optional ByVal WBase As String = "SurfactanSa") As DataRow

            Dim tabla As New DataTable

            Using cn As New SqlConnection

                cn.ConnectionString = Helper._ConectarA(WBase) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()

                Using cm As New SqlCommand(q)

                    cm.Connection = cn

                    Using dr As SqlDataReader = cm.ExecuteReader(CommandBehavior.SingleRow)
                        tabla.Load(dr)
                    End Using

                End Using

            End Using

            If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

            Return Nothing

        End Function

        Public Shared Function GetAll(ByVal q As String, Optional ByVal WBase As String = "SurfactanSa") As DataTable

            Dim tabla As New DataTable

            Using cn As New SqlConnection

                cn.ConnectionString = Helper._ConectarA(WBase) 'ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()

                Using cm As New SqlCommand(q)

                    cm.Connection = cn

                    Using dr As SqlDataReader = cm.ExecuteReader
                        tabla.Load(dr)
                    End Using

                End Using

            End Using

            Return tabla

        End Function

        Public Shared Function ExecuteQueryRead(ByVal q As String, Optional ByVal WBase As String = "SurfactanSa") As SqlDataReader

            Dim cn As New SqlConnection
            Dim cm As New SqlCommand
            Dim dr As SqlDataReader

            cn.ConnectionString = Helper._ConectarA(WBase) 'ConfigurationManager.ConnectionStrings("CS").ToString
            cn.Open()

            cm.Connection = cn
            cm.CommandText = q

            dr = cm.ExecuteReader

            Return dr

        End Function

        Public Shared Sub ExecuteNonQueries(ByVal q As String(), Optional ByVal WBase As String = "SurfactanSa")

            Dim trans As SqlTransaction = Nothing
            Try
                If q.Length = 0 Then Throw New Exception("No se han pasado consultas para ejecutar.")

                Using cn As New SqlConnection
                    cn.ConnectionString = Helper._ConectarA(WBase) 'Helper._ConectarA(Conexion.EmpresaDeTrabajo) 'ConfigurationManager.ConnectionStrings("CS").ToString
                    cn.Open()
                    trans = cn.BeginTransaction

                    Using cm As New SqlCommand()

                        cm.Connection = cn
                        cm.Transaction = trans

                        For Each _q As String In q

                            Using sw As New StreamWriter(Environment.SpecialFolder.Desktop & "sql.txt")
                                sw.WriteLine(_q)
                            End Using

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

    End Class

End Namespace