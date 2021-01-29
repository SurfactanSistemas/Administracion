Public Class ConsultaTiposDeCambios

    Private Sub CalendarControl_DateSelected(sender As Object, e As DateRangeEventArgs) Handles CalendarControl.DateSelected

        mastxtFecha.Text = CalendarControl.SelectionStart

        Dim FechaOrd As String = ordenaFecha(mastxtFecha.Text)
        
        BuscarCambios(FechaOrd)



    End Sub
    Private Sub BuscarCambios(ByVal FechaOrd As String)
        Try
            Dim SQLCnslt As String = "SELECT Fecha, OrdFecha, Dolar = Cambio, Euro = CambioII, Divisa = CambioDivisa, " _
                                 & "Reflex30 = CambioIII, Reflex60 = CambioIV, Reflex90 = CambioV, Reflex120 = CambioVI " _
                                 & "From Cambios WHERE OrdFecha = '" & FechaOrd & "'"
            Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If row IsNot Nothing Then
                With row
                    txtDolar.Text = .Item("Dolar")
                    txtEuro.Text = .Item("Euro")
                    txtDivisa.Text = .Item("divisa")
                    txtReflex30.Text = .Item("Reflex30")
                    txtReflex60.Text = .Item("Reflex60")
                    txtReflex90.Text = .Item("Reflex90")
                    txtReflex120.Text = .Item("Reflex120")
                End With
            Else

                txtDolar.Text = "0.0"
                txtEuro.Text = "0.0"
                txtDivisa.Text = "0.0"
                txtReflex30.Text = "0.0"
                txtReflex60.Text = "0.0"
                txtReflex90.Text = "0.0"
                txtReflex120.Text = "0.0"

            End If

        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub ConsultaTiposDeCambios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechaOrd As String = ordenaFecha(Date.Today.ToString("dd/MM/yyyy"))

        BuscarCambios(FechaOrd)
    End Sub
End Class