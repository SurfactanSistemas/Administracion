Namespace Clases
    Public Class Normalizaciones

        ''' <summary>
        ''' Setea la Configuración Regional de la PC, pisando la configuración actual.
        ''' </summary>
        ''' <returns>
        ''' Devuelve <c>Verdadero</c> en caso de que se haya modificado alguna configuración, <c>Falso</c> en caso de que no haya hecho falta realizar modificación alguna.
        '''</returns>
        Public Shared Function ConfiguracionRegional() As Boolean

            '
            ' Obtenemos los valores actuales para poder comparar.
            '
            Dim val1 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sDecimal", ".")
            Dim val2 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sThousand", ",")
            Dim val3 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sMonDecimalSep", ".")
            Dim val4 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sMonThousandSep", ",")
            Dim val5 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "")

            '
            ' Modificamos en caso de que haga falta modificar alguno.
            '
            If val1 <> "," Or val2 <> "." Or val3 <> "," Or val4 <> "." Or val5 <> "dd/MM/yyyy" Then

                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sCurrency", "$")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sDate", "/")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sDecimal", ",")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sMonDecimalSep", ",")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sMonThousandSep", ".")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sThousand", ".")

                Return True

            End If

            Return False

        End Function
    End Class
End Namespace