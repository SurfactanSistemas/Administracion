﻿Imports System.Runtime.CompilerServices

Module AuxiExtensiones

    <Extension()>
    Public Function AsList(Of t As {IEnumerable})(ByVal rows As t) As List(Of t)
        Return rows.Cast(Of t).ToList
    End Function

    <Extension()>
    Public Function Ceros(ByVal txt As TextBox, ByVal longitud As Object) As String
        Return txt.Text.PadLeft(longitud, "0")
    End Function

    <Extension()>
    Public Function Ceros(ByVal txt As MaskedTextBox, ByVal longitud As Object) As String
        Return txt.Text.PadLeft(longitud, "0")
    End Function

    <Extension()>
    Public Function Ceros(ByVal obj As Object, ByVal longitud As Object) As String
        Return OrDefault(obj, "").ToString.PadLeft(longitud, "0")
    End Function

    <Extension()>
    Public Function left(ByVal obj As Object, ByVal longitud As Object) As String
        Return Microsoft.VisualBasic.Left$(OrDefault(obj, "").ToString.Trim.PadRight(longitud), longitud)
    End Function

    <Extension()>
    Public Function right(ByVal obj As Object, ByVal longitud As Object) As String
        Return Microsoft.VisualBasic.Right(OrDefault(obj, "").ToString.Trim.PadRight(longitud), longitud)
    End Function

    <Extension()>
    Public Function toDbl(ByVal obj As Object) As Double
        Return CDbl(OrDefault(obj, 0).ToString.Replace(".", ","))
    End Function

    <Extension()>
    Public Function toDbl(ByVal obj As String) As Double
        If obj.Trim = "" Then obj = "0"
        Return CDbl(obj.Replace(".", ","))
    End Function

End Module
