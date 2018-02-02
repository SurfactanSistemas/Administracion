Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Namespace Clases

    Module ExtensionesTipoString

        ''' <summary>
        ''' Devuelve la cadena con la longitud indicada, comenzando desde la Izquierda.
        ''' </summary>
        <Extension()>
        Function SliceLeft(ByVal text As String, ByVal length As Integer) As String

            If text.Length <= length Then Return text

            Return Microsoft.VisualBasic.Left(text, length)

        End Function

        ''' <summary>
        ''' Devuelve la cadena con la longitud indicada, comenzando desde la Derecha.
        ''' </summary>
        <Extension()>
        Function SliceRight(ByVal text As String, ByVal length As Integer) As String

            If text.Length <= length Then Return text

            Return Microsoft.VisualBasic.Right(text, length)

        End Function

        ''' <summary>
        ''' Devuelve la cadena Capitalizada.
        ''' </summary>
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

        ''' <summary>
        ''' Devuelve el Valor de Hash calculado en MD5.
        ''' </summary>
        <Extension()>
        Function hashMD5(ByVal sCadena As String) As String
            ' Objeto de codificación
            Dim ueCodigo As New UnicodeEncoding()
            ' Objeto para instanciar las codificación
            Dim Md5 As New MD5CryptoServiceProvider()

            ' Calcula el valor hash de la cadena recibida
            Dim bHash() As Byte = Md5.ComputeHash(ueCodigo.GetBytes(sCadena))

            ' Convierte el valor anterior en cadena y lo devuelve
            Return Convert.ToBase64String(bHash)
        End Function

    End Module
End Namespace