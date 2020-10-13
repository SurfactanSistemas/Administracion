Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class FechaReprog : Implements IMinutaDirecta

    Private CODIGOCLI As String
    Private CLIENTEDES As String
    Sub New(ByVal Codigo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Dim SQLCnslt As String = "SELECT Razon, Telefono, Contacto, Horario, Email, EmailEnv, Direccion, DirEntregaII, DirEntregaIII, DirEntregaIV, DirEntregaV " _
                                 & "FROM Cliente WHERE Cliente = '" & Codigo & "'"

        Dim RowCli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        If RowCli IsNot Nothing Then
            Dim Contacto As String = "Razon: " & RowCli.Item("Razon") & "" & vbCrLf & "" _
                                   & "Contacto: " & RowCli.Item("Contacto") & "" & vbCrLf & "" _
                                   & "Telefono: " & RowCli.Item("Telefono") & " " & vbCrLf & "" _
                                   & "Horarios: " & RowCli.Item("Horario") & " " & vbCrLf & "" _
                                   & "Mail: " & RowCli.Item("Email") & " " & vbCrLf & "" _
                                   & "Mail Envases: " & RowCli.Item("EmailEnv") & " " & vbCrLf & "" _
                                   & "Direcciones: " & RowCli.Item("Direccion") & " " & vbCrLf & "                  " _
                                   & "- " & RowCli.Item("DirEntregaII") & " " & vbCrLf & "                  " _
                                   & "- " & RowCli.Item("DirEntregaIII") & " " & vbCrLf & "                  " _
                                   & "- " & RowCli.Item("DirEntregaIV") & " " & vbCrLf & "                  " _
                                   & "- " & RowCli.Item("DirEntregaV") & " " & vbCrLf & ""

            txt_DatosContacto.Text = Contacto

            CODIGOCLI = Codigo
            CLIENTEDES = RowCli.Item("Razon")

        End If

    End Sub




    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If ValidaFecha(txt_Fecha.Text) <> "S" Then
            MsgBox("La fecha ingresada es invalida, verificar")
            txt_Fecha.Focus()
            txt_Fecha.SelectAll()
            Exit Sub
        End If

        Dim WOwner As IPasarFecha = TryCast(Owner, IPasarFecha)

        If WOwner IsNot Nothing Then
            WOwner.pasaFecha(txt_Fecha.Text, txt_Observaciones.Text)
            Close()
        End If

    End Sub

    Private Sub btn_Minuta_Click(sender As Object, e As EventArgs) Handles btn_Minuta.Click
        With New MinutaAgenda(CODIGOCLI, CLIENTEDES)
            .Show(Me)
        End With
    End Sub

    Public Sub CerrarIngresoAgenda() Implements IMinutaDirecta.CerrarIngresoAgenda
        Close()
    End Sub

    Private Sub btn_MAIL_Click(sender As Object, e As EventArgs) Handles btn_MAIL.Click
        With New EnviarMAIL_Cliente(CODIGOCLI)
            .Show(Me)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With New PedidosPendientesXClientes(CODIGOCLI, CLIENTEDES)
            .Show(Me)
        End With
    End Sub
End Class