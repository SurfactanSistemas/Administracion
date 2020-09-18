Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_CtaCte_Analitico : Implements IBuscarClienteCashFlow


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Dias.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
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
                txt_HastaCodigo.Text = ""
        End Select
    End Sub


    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

      
        Dim WFecha As String = txt_Fecha.Text
        Dim Cicla As Integer = 0

        Do

            Cicla = Cicla + 1
            If Cicla = 1000 Then Exit Sub

            Dim ZDias As Integer = DateDiff("d", WFecha, txt_Fecha.Text)
            If ZDias >= Val(txt_Dias.Text) Then Exit Do

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
                    ZDia = "30"
                End If
            End If


            ZDia = ZDia.PadLeft(2, "0")
            ZMes = ZMes.PadLeft(2, "0")
            ZAno = ZAno.PadLeft(4, "0")
            
            WFecha = ZDia & "/" & ZMes & "/" & ZAno

        Loop

        Dim WDesde As String = "00000000"

        Dim WDia As String = WFecha.Substring(0, 2)
        Dim WMes As String = WFecha.Substring(3, 2)
        Dim WAno As String = WFecha.Substring(6, 4)
        
        Dim WHasta As String = WAno & WMes & WDia

        Dim WTitulo As String = "Fecha de Emision : " & txt_Fecha.Text & "    (Plazo :" & Val(txt_Dias.Text) & ")"
        
        Dim SQLCnslt As String = "UPDATE CtaCte SET Empresa = 1"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)


        Dim WFormula As String = "{CtaCte.Cliente} >= '" & txt_DesdeCodigo.Text & "' AND {CtaCte.Cliente} <=  '" & txt_HastaCodigo.Text & "' " _
                               & "AND {CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "' " _
                               & "AND ({CtaCte.Saldo} > 1 OR  {CtaCte.Saldo} < -1)"

        With New VistaPrevia
            .Reporte = New Reporte_Listado_CtaCte_Analitico()
            .Reporte.SetParameterValue(0, Operador.Base)
            .Reporte.SetParameterValue(1, WTitulo)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

  

    Private Sub Listado_CtaCte_Analitico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")
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