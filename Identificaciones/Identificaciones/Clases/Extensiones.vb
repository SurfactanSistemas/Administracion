Imports System.Runtime.CompilerServices

Module Extensiones

    <Extension()>
    Function SliceLeft(ByVal text As String, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Left(text, length)
    End Function

    <Extension()>
    Function Capitalize(ByVal texto As String) As String

        If String.IsNullOrEmpty(texto) OrElse texto.Length = 0 Then Return texto

        Dim temp As String = ""

        texto = LCase(texto)

        For Each txt As String In texto.Split(" ")

            temp &= UCase(txt.Substring(0, 1)) & txt.Substring(1) & " "

        Next

        Return Trim(temp)

    End Function

End Module
