Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Acciones_Agenda : Implements IBorrarDeAgenda

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Sub New(ByVal Codigo As String, Optional ByVal Fecha As String = "", Optional ByVal Observaciones As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Cliente.Text = Codigo
        txt_Fecha.Text = Fecha
        txt_Observaciones.Text = Trim(Observaciones)

        Dim SQLCnslt As String = "SELECT Razon, Telefono, Contacto, Horario, Email, EmailEnv, Direccion, DirEntregaII, DirEntregaIII, DirEntregaIV, DirEntregaV " _
                                 & "FROM Cliente WHERE Cliente = '" & Codigo & "'"

        Dim RowCli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        If RowCli IsNot Nothing Then
            txt_ClienteDes.Text = RowCli.Item("Razon")
            Dim Contacto As String = "Contacto: " & RowCli.Item("Contacto") & "" & vbCrLf & "" _
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

        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_BorrarDeAgenda.Click
        If MsgBox("Desea borrar de la agenda al cliente: " & txt_Cliente.Text & " ?", vbYesNo) = vbYes Then

            Dim WOwner As IPasaCliente = TryCast(Owner, IPasaCliente)

            If WOwner IsNot Nothing Then
                WOwner.PasaCliente(txt_Cliente.Text)
                Close()
            End If
        End If
    End Sub

    Private Sub btn_ModificarAgenda_Click(sender As Object, e As EventArgs) Handles btn_ModificarAgenda.Click

        If ValidaFecha(txt_Fecha.Text) <> "S" Then
            MsgBox("Verificar la fecha, es un valor invalido")
            txt_Fecha.Focus()
            txt_Fecha.SelectAll()
            Exit Sub
        End If


        If MsgBox("Desea actualizar la Fecha y las Observaciones del cliente: " & txt_Cliente.Text & " ?", vbYesNo) = vbYes Then
            Dim SQLCnslt As String = "UPDATE ReclamosEnvReProg " _
                                     & "SET Fecha = '" & txt_Fecha.Text & "', " _
                                     & "FechaOrd = '" & ordenaFecha(txt_Fecha.Text) & "', " _
                                     & "Observaciones = '" & txt_Observaciones.Text & "', " _
                                     & "WDate = '" & Date.Today.ToString("yyyy-dd-MM") & "' " _
                                     & "WHERE Cliente = '" & txt_Cliente.Text & "'"

            ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

            Dim WOwner As IPasaCliente = TryCast(Owner, IPasaCliente)

            If WOwner IsNot Nothing Then
                WOwner.ActualizaGrilla()
            End If

            Close()

        End If

    End Sub

  
    Private Sub btn_PedidosPendientes_Click(sender As Object, e As EventArgs) Handles btn_PedidosPendientes.Click
        With New PedidosPendientesXClientes(txt_Cliente.Text, txt_ClienteDes.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub btn_Minutas_Click(sender As Object, e As EventArgs) Handles btn_Minutas.Click
        With New MinutaAgenda(txt_Cliente.Text, txt_ClienteDes.Text)
            .Show(Me)
        End With
    End Sub

    Public Sub BorrarDeAgenda(Codigo As String) Implements IBorrarDeAgenda.BorrarDeAgenda
       
        Dim WOwner As IPasaCliente = TryCast(Owner, IPasaCliente)

        If WOwner IsNot Nothing Then
            WOwner.PasaCliente(txt_Cliente.Text)
            Close()
        End If

    End Sub

    
    Private Sub Acciones_Agenda_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Focus()
    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_Observaciones.Focus()
                Else
                    MsgBox("La fecha es invalida, verifique")
                    txt_Fecha.SelectAll()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
        
    End Sub
End Class