Public Class CustomConvert

    Public Shared Function toBoolOrFalse(ByVal value)
        Select Case value.ToString().ToUpper
            Case "TRUE", "1"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Shared Function toBoolOrTrue(ByVal value)
        Select Case value.ToString().ToUpper
            Case "FALSE", "0"
                Return False
            Case Else
                Return True
        End Select
    End Function

    Public Shared Function toDoubleOrZero(ByVal value)
        value = IIf(IsNothing(value) Or value = "", "0", value)
        Return toDoubleOr(value, 0)
    End Function

    Public Shared Function toDoubleOr(ByVal value, ByVal defaultValue)
        Try
            Return Convert.ToDouble(value)
        Catch
            Return defaultValue
        End Try
    End Function

    Public Shared Function toIntOrNull(ByVal value)
        Return toIntOr(value, Nothing)
    End Function

    Public Shared Function toIntOrZero(ByVal value)
        Return toIntOr(value, 0)
    End Function

    Public Shared Function toIntOr(ByVal value, ByVal defaultValue)
        Try
            Return Convert.ToInt32(value)
        Catch
            Return defaultValue
        End Try
    End Function

    Public Shared Function toStringWithTwoDecimalPlaces(ByVal value As Double)
        Return asStringWithDecimalPlaces(value, 2)
    End Function

    Public Shared Function asStringWithDecimalPlaces(ByVal value As Double, ByVal decimalPlaces As Integer)
        If Math.Abs(value) < 0.01 Then
            value = 0
        End If
        Dim originalString As String = value.ToString
        If originalString.IndexOf(",") = -1 Then
            Return originalString & "," & ceros("", decimalPlaces)
        Else
            Dim difference As Integer = originalString.Count - originalString.IndexOf(",") - 1
            If difference < decimalPlaces Then
                Return originalString & ceros("", decimalPlaces - difference)
            Else
                Return Math.Round(value, 2).ToString
            End If
        End If
        Return originalString
    End Function

    Public Shared Function asTextDate(ByVal value) As String
        Try
            Dim myDate As Date = Convert.ToDateTime(value)
            Return myDate.ToShortDateString
        Catch ex As Exception
            Return "  /  /    "
        End Try
    End Function
End Class
