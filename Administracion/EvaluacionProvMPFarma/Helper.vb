Imports System.Configuration

Public Class Helper : Inherits ConsultasVarias.Clases.Helper

    Public Overloads Shared Function _ConectarA(ByVal empresa As Integer) As String

        Return ConfigurationManager.ConnectionStrings("CS").ConnectionString.ToString().Replace("#EMPRESA#", empresa)

    End Function

End Class
