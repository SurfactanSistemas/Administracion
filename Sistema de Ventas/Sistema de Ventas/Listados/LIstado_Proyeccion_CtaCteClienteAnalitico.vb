Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class LIstado_Proyeccion_CtaCteClienteAnalitico : Implements IBuscarClienteCashFlow

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_DesdeCodigo.Focus()
                Else
                    MsgBox("La fecha es invalida, verificar")
                    txt_Fecha.SelectAll()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_DesdeCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_DesdeCodigo.Text.Length = 6 Then
                    txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)
                    txt_HastaCodigo.Focus()
                Else
                    If txt_DesdeCodigo.Text.Length = 0 Then
                        txt_DesdeCodigo.Text = "A00000"
                        txt_HastaCodigo.Focus()
                    End If
                End If
            Case Keys.Escape
                txt_DesdeCodigo.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_HastaCodigo.Text.Length = 6 Then
                    txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)
                Else
                    If txt_HastaCodigo.Text.Length = 0 Then
                        txt_HastaCodigo.Text = "Z99999"

                    End If
                End If

            Case Keys.Escape
                txt_DesdeCodigo.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If ValidaFecha(txt_Fecha.Text) <> "S" Then
            MsgBox("La fecha es invalida, verificar")
            txt_Fecha.Focus()
            txt_Fecha.SelectAll()
            Exit Sub
        End If

        Dim WFecha As String = txt_Fecha.Text
        Dim Wfecha1 As String
        Dim Wfecha2 As String
        Dim Cicla As Integer = 0
        Do

            Cicla = Cicla + 1
            If Cicla = 1000 Then
                REM Exit Sub
                Stop
            End If
            Dim ZDias As Integer = DateDiff("d", WFecha, txt_Fecha.Text)
            If ZDias = 30 Or ZDias = 31 Then
                WFecha1 = WFecha
                Exit Do
            End If

            Dim ZDia As String = WFecha.Substring(0, 2)
            Dim ZMes As String = WFecha.Substring(3, 2)
            Dim ZAno As String = WFecha.Substring(6, 4)



            ZDia = (Val(ZDia) - 1)
            If Val(ZDia) = 0 Then
                ZMes = (Val(ZMes) - 1)
                If Val(ZMes) = 0 Then
                    ZAno = (Val(ZAno) - 1)
                    ZMes = "12"
                End If
                If Val(ZMes) = 2 Then
                    ZDia = "28"
                Else
                    If ZMes = 4 Or ZMes = 6 Or ZMes = 9 Or ZMes = 11 Then
                        ZDia = "30"
                    Else
                        ZDia = "31"
                    End If

                End If
            End If

            ZDia = ZDia.PadLeft(2, "0")
            ZMes = ZMes.PadLeft(2, "0")
            ZAno = ZAno.PadLeft(4, "0")
            
            WFecha = ZDia & "/" & ZMes & "/" & ZAno

        Loop

        WFecha = txt_Fecha.Text
        Cicla = 0
        Do

            Cicla = Cicla + 1
            If Cicla = 1000 Then Exit Sub

            Dim ZDias As Integer = DateDiff("d", WFecha, txt_Fecha.Text)
            If ZDias = 60 Or ZDias = 61 Then
                WFecha2 = WFecha
                Exit Do
            End If

            Dim ZDia As String = WFecha.Substring(0, 2)
            Dim ZMes As String = WFecha.Substring(3, 2)
            Dim ZAno As String = WFecha.Substring(6, 4)

            ZDia = (Val(ZDia) - 1)
            If Val(ZDia) = 0 Then
                ZMes = (Val(ZMes) - 1)
                If Val(ZMes) = 0 Then
                    ZAno = (Val(ZAno) - 1)
                    ZMes = "12"
                End If
                If Val(ZMes) = 2 Then
                    ZDia = "28"
                Else
                    If ZMes = 4 Or ZMes = 6 Or ZMes = 9 Or ZMes = 11 Then
                        ZDia = "30"
                    Else
                        ZDia = "31"
                    End If
                End If
            End If

            ZDia = ZDia.PadLeft(2, "0")
            ZMes = ZMes.PadLeft(2, "0")
            ZAno = ZAno.PadLeft(4, "0")

            WFecha = ZDia & "/" & ZMes & "/" & ZAno

        Loop

        Dim WAno As String = Microsoft.VisualBasic.Right$(Wfecha1, 4)
        Dim WMes As String = Mid$(Wfecha1, 4, 2)
        Dim WDia As String = Microsoft.VisualBasic.Left$(Wfecha1, 2)
        Dim WFechaOrd1 As String = WAno & WMes & WDia

        WAno = Microsoft.VisualBasic.Right$(Wfecha2, 4)
        WMes = Mid$(Wfecha2, 4, 2)
        WDia = Microsoft.VisualBasic.Left$(Wfecha2, 2)
        Dim WFechaord2 As String = WAno & WMes & WDia

    

        Dim SQLCnslt As String = "UPDATE CtaCte SET " _
                                & " Empresa = 1"

        ExecuteNonQueries(Operador.Base, {SQLCnslt})


        Dim Wformula As String


        Wformula = "{CtaCte.Cliente} >= '" & txt_DesdeCodigo.Text & "' AND {CtaCte.Cliente} <= '" & txt_HastaCodigo.Text & "' AND ({CtaCte.Saldo} > 1 OR  {CtaCte.Saldo} < -1)"
        
        


        With New VistaPrevia
            If cbx_Tipo.SelectedIndex = 0 Then
                .Reporte = New Reporte_ProyCtaCteAnaliticoCliente()
                .Reporte.SetParameterValue(0, Operador.Base)
                .Reporte.SetParameterValue(1, WFechaOrd1)
                .Reporte.SetParameterValue(2, WFechaord2)
                .Formula = Wformula
                If rabtn_Pantalla.Checked Then
                    .Mostrar()
                Else
                    .Imprimir()
                End If
            Else
'                For i = 1 To 9
'
'                    Dim vend As String = ""
'
'                    Select Case i
'                        Case 1
'                            vend = "1"
'                        Case 2
'                            vend = "2"
'                        Case 3
'                            vend = "4"
'                        Case 4
'                            vend = "10"
'                        Case 5
'                            vend = "11"
'                        Case 6
'                            vend = "12"
'
'                        Case 7
'                            vend = "15"
'                        Case 8
'                            vend = "16"
'                        Case 9
'                            vend = "18"
'
'                    End Select

                ' Wformula = Wformula & " AND {Cliente.Vendedor} = " & vend & ""
                    .Reporte = New Reporte_ProyCtaCteAnaliticoVendedor()
                    .Reporte.SetParameterValue(0, Operador.Base)
                    .Reporte.SetParameterValue(1, WFechaOrd1)
                    .Reporte.SetParameterValue(2, WFechaord2)
                    .Formula = Wformula
                    If rabtn_Pantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
'                Next



            End If
         
        End With



    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With New ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        If Accion = "Desde" Then
            txt_DesdeCodigo.Text = CodigoCliente
        End If
        If Accion = "Hasta" Then
            txt_HastaCodigo.Text = CodigoCliente
        End If
        If Accion = "Ambos" Then
            txt_HastaCodigo.Text = CodigoCliente
            txt_DesdeCodigo.Text = CodigoCliente
        End If
       
    End Sub

    
    Private Sub LIstado_Proyeccion_CtaCteClienteAnalitico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")
        cbx_Tipo.SelectedIndex = 0
    End Sub

   
    Private Sub txt_DesdeCodigo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_DesdeCodigo.MouseDoubleClick
        With New ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Private Sub txt_HastaCodigo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_HastaCodigo.MouseDoubleClick
        With New ConsultaCliente
            .Show(Me)
        End With
    End Sub
End Class