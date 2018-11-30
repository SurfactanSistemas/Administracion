Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Configuration

Public Class Form1

    Private WTiempo1 As Integer = 0
    Private WTCP As New TCPConnector

    Private WDispositivos As New DataTable

    Private WBoton As Button
    Private WCheck As CheckBox

    Private WData() As Byte
    Private WEstado = True

    Private WDelay As Integer = 10
    Private WComprobado As Boolean = False

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim strHostName = Dns.GetHostName()
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
        Dim addr() = ipEntry.AddressList
        Dim i As Integer
        For i = 0 To addr.Length - 1

            If addr(i).AddressFamily = AddressFamily.InterNetwork Then
                Exit For
            End If

        Next

        With WDispositivos
            .Columns.Add("Descripcion")
            .Columns.Add("IP")
            .Columns.Add("Estado")
        End With

        WDelay = Val(ConfigurationManager.AppSettings("Delay").ToString)

        WTCP.connect(addr(i).ToString, "5000")

        For Each c As Button In Controls.OfType(Of Button)()
            c.BackgroundImage = My.Resources.btn_disabled
        Next

        For Each c As CheckBox In Controls.OfType(Of CheckBox)()
            c.Checked = False
        Next

        WData = New Byte(8) {}

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSurfac1.Click, btnSurfac2.Click, btnPellital.Click, btnSurfac5.Click, btnSurfac3.Click

        WBoton = CType(sender, Button)
        WCheck = Nothing

        Dim WComando = ""
        Dim WIp = ""

        Dim WDispo() As DataRow

        If WDispositivos.Select("Descripcion = '" & WBoton.Name.Replace("btn", "") & "'").Length > 0 Then

            WDispo = WDispositivos.Select("Descripcion = '" & WBoton.Name.Replace("btn", "") & "'")

            With WDispo(0)
                WIp = .Item("IP")
                If Val(.Item("Estado")) = 0 Then
                    Exit Sub
                End If
            End With
        Else
            Exit Sub
        End If


            Select Case WBoton.Name
                Case btnSurfac1.Name
                    WCheck = Surfac1Encendido
                Case btnSurfac2.Name
                    WCheck = Surfac2Encendido
                Case btnSurfac3.Name
                    WCheck = Surfac3Encendido
                Case btnSurfac5.Name
                    WCheck = Surfac5Encendido
                Case btnPellital.Name
                    WCheck = PellitalEncendido
            End Select

            WBoton.BackgroundImage = IIf(WCheck.Checked, My.Resources.btn_off, My.Resources.btn_on)

            If WCheck.Checked Then
                WComando = "2X"
            Else
                WComando = "1X:" & WDelay
            End If

            WTCP.SendData(WComando, WIp, "6722")

            WCheck.Checked = Not WCheck.Checked

            Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick

        If WCheck.Checked Then

            If WTiempo1 Mod Timer1.Interval * 2 = 0 Then
                WBoton.BackgroundImage = My.Resources.btn_off
            Else
                WBoton.BackgroundImage = My.Resources.btn_on
            End If

            WEstado = True

            Array.Clear(WData, 0, 8)

            Dim WIp = ""

            If WDispositivos.Select("Descripcion = '" & WBoton.Name.Replace("btn", "") & "'").Length > 0 Then

                Dim WDispo = WDispositivos.Select("Descripcion = '" & WBoton.Name.Replace("btn", "") & "'")

                With WDispo(0)
                    WIp = .Item("IP")
                    If Val(.Item("Estado")) = 0 Then
                        Exit Sub
                    End If
                End With

            End If

            If WIp = "" Then Exit Sub

            WTCP.SendData("00", WIp, "6722", WEstado, WData)

            Dim W As String

            For i = 0 To 1
                Dim o As Object = WData(i)
                W &= Chr(o.ToString)
            Next

            If Val(W) = 0 Then
                WBoton.BackgroundImage = My.Resources.btn_off
                WCheck.Checked = False
                Timer1.Stop()
            End If

            If Not WEstado Then
                MsgBox("Ocurre un problema con la conexión a la alarma. Reinicie el Programa.", MsgBoxStyle.Information)
                Timer1.Stop()
            End If

            WTiempo1 += Timer1.Interval

        Else
            WTiempo1 = 0
            Timer1.Stop()
        End If

    End Sub

    Private Sub PellitalEncendido_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Surfac5Encendido.CheckStateChanged, Surfac3Encendido.CheckStateChanged, Surfac2Encendido.CheckStateChanged, Surfac1Encendido.CheckStateChanged, PellitalEncendido.CheckStateChanged
        If CType(sender, CheckBox).CheckState = CheckState.Unchecked Then
            GC.Collect()
        End If
    End Sub

    Private Function PingHost(ByVal ipAddress As String) As Boolean

        Dim pingable As Boolean = False
        Dim pinger As Ping = Nothing

        Try
            pinger = New Ping
            Dim reply As PingReply = pinger.Send(ipAddress, 500)
            pingable = reply.Status = IPStatus.Success

        Catch ex As Exception
            '
        Finally
            If Not IsNothing(pinger) Then
                pinger.Dispose()
            End If
        End Try

        Return pingable
        
    End Function
    
    Private Sub _DeterminarEstadosBotones()

        '
        ' Habilito Plantas segun se detecte o no conección con los dispositivos a traves de la red.
        '

        Dim W As String = ConfigurationManager.AppSettings("Dispositivos").ToString

        For Each WDisp As String In W.Split(";")

            If WDisp.Trim = "" Then Continue For

            Dim WPlanta As String = WDisp.Split("=")(0)
            Dim WIp As String = WDisp.Split("=")(1)

            Dim row As DataRow

            row = WDispositivos.NewRow

            Dim WBut As Button = Nothing

            Select Case "btn" & WPlanta
                Case btnSurfac1.Name
                    WBut = btnSurfac1
                Case btnSurfac2.Name
                    WBut = btnSurfac2
                Case btnSurfac3.Name
                    WBut = btnSurfac3
                Case btnSurfac5.Name
                    WBut = btnSurfac5
                Case btnPellital.Name
                    WBut = btnPellital
            End Select

            If IsNothing(WBut) Then Continue For

            WBut.Enabled = PingHost(WIp)

            With row
                .Item("Descripcion") = WPlanta
                .Item("IP") = WIp
                .Item("Estado") = IIf(WBut.Enabled, "1", "0")
            End With

            If WBut.Enabled Then
                WBut.BackgroundImage = My.Resources.btn_off
            Else
                WBut.BackgroundImage = My.Resources.btn_error
                Label6.Text = "Hay Dispositivos inaccesibles."
            End If

            WDispositivos.Rows.Add(row)

        Next
        WComprobado = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Not WComprobado Then
            Label6.Text = "Comprobando Conexiones con Dispositivos..."
            Label6.Refresh()
            Cursor = Cursors.WaitCursor

            _DeterminarEstadosBotones()

            Cursor = Cursors.Default
            Timer2.Stop()
        End If
    End Sub
End Class
