Imports System.Data.SqlClient

Public Class AltaAgenda

    Private _Cliente As String

    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private _EsPrimerFecha As Boolean

    Public Property EsPrimerFecha() As Boolean
        Get
            Return _EsPrimerFecha
        End Get
        Private Set(ByVal value As Boolean)
            _EsPrimerFecha = value
        End Set
    End Property


    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(Trim(txtFecha.Text)) Then
                ' Saltamos hacia el otro campo
                txtHora.Focus()
            Else
                MsgBox("Fecha inválida.", MsgBoxStyle.Information)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If

    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub AltaAgenda_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFecha.Focus()
    End Sub

    Private Sub AltaAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button3.PerformClick()

        ' Si tenemos un cliente, buscamos la informacion pertinente.
        If Trim(Cliente) <> "" Then
            _BuscarFechaAgenda()
        End If

    End Sub

    Private Sub _BuscarFechaAgenda()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Fecha, Hora, Anotacion, OrdFecha, FechaII, HoraII, AnotacionII, OrdFechaII, Razon FROM Cliente WHERE Cliente = '" & Trim(Me.Cliente) & "'")
        Dim dr As SqlDataReader
        Dim WFecha, WAnotacion, WHora, WOrdFecha, WFechaII, WAnotacionII, WHoraII, WOrdFechaII As String
        Dim WDesCliente As String = ""

        WFecha = ""
        WAnotacion = ""
        WHora = ""
        WOrdFecha = ""

        WFechaII = ""
        WAnotacionII = ""
        WHoraII = ""
        WOrdFechaII = ""

        ClasesCompartidas.SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WDesCliente = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))

                    WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                    WAnotacion = IIf(IsDBNull(.Item("Anotacion")), "", .Item("Anotacion"))
                    WHora = IIf(IsDBNull(.Item("Hora")), "", .Item("Hora"))
                    WOrdFecha = Proceso.ordenaFecha(WFecha) 'IIf(IsDBNull(.Item("OrdFecha")), "", .Item("OrdFecha")) ' Porque hay casos en los que se tiene cargado OrdFecha pero no fecha.

                    WFechaII = IIf(IsDBNull(.Item("FechaII")), "", .Item("FechaII"))
                    WAnotacionII = IIf(IsDBNull(.Item("AnotacionII")), "", .Item("AnotacionII"))
                    WHoraII = IIf(IsDBNull(.Item("HoraII")), "", .Item("HoraII"))
                    WOrdFechaII = Proceso.ordenaFecha(WFechaII) ' IIf(IsDBNull(.Item("OrdFechaII")), "", .Item("OrdFechaII")) ' Porque hay casos en los que se tiene cargado OrdFecha pero no fecha.

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtCliente.Text = Trim(Me.Cliente)
        txtDescripcionCliente.Text = Trim(WDesCliente)
        txtHora.Text = "0"

        Me.EsPrimerFecha = True

        ' Una vez obtenidos los datos, vemos cual es el mas actual.
        ' Vemos que haya por lo menos una fecha, sino pasamos directamente al formulario 
        ' y asumimos que se guardara en el primer campo de fechas.
        If Val(WOrdFecha) > 0 Or Val(WOrdFechaII) > 0 Then

            If Val(WOrdFechaII) < Val(WOrdFecha) Then ' La segunda fecha es mas actual.

                txtFecha.Text = Trim(WFechaII)
                txtHora.Text = Proceso.formatonumerico(WHoraII)
                txtAnotacion.Text = Trim(WAnotacionII)

                Me.EsPrimerFecha = False

            Else ' La primer fecha es mas actual.

                txtFecha.Text = Trim(WFecha)
                txtHora.Text = Proceso.formatonumerico(WHora)
                txtAnotacion.Text = Trim(WAnotacion)

                Me.EsPrimerFecha = True

            End If

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        
        txtFecha.Clear()
        txtHora.Text = ""
        txtAnotacion.Text = ""

        Me.EsPrimerFecha = True

        txtFecha.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ZSql As String = ""

        If Not Proceso._ValidarFecha(txtFecha.Text) Then : Exit Sub : End If

        If Val(txtHora.Text) < 0 Then : Exit Sub : End If

        ZSql = "UPDATE Cliente SET #FECHA# = '" & Trim(txtFecha.Text) & "', #HORA# = " & Proceso.formatonumerico(txtHora.Text) & ", #ANOTACION# = '" & Trim(txtAnotacion.Text) & "', #ORDFECHA# = '" & Proceso.ordenaFecha(txtFecha.Text) & "' WHERE Cliente = '" & Me.Cliente & "'"

        If Me.EsPrimerFecha Then
            ZSql = ZSql.Replace("#FECHA#", "Fecha") _
                        .Replace("#ORDFECHA#", "OrdFecha") _
                        .Replace("#ANOTACION#", "Anotacion") _
                        .Replace("#HORA#", "Hora")
        Else
            ZSql = ZSql.Replace("#FECHA#", "FechaII") _
                        .Replace("#ORDFECHA#", "OrdFechaII") _
                        .Replace("#ANOTACION#", "AnotacionII") _
                        .Replace("#HORA#", "HoraII")
        End If

        'MsgBox(ZSql)

        'Exit Sub ' Comentar cuando ya se comience a querer probar.

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand(ZSql)

        ClasesCompartidas.SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        btnCerrar.PerformClick()

    End Sub

    Private Sub txtHora_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHora.Text) = "" Then : Exit Sub : End If

            txtHora.Text = Proceso.formatonumerico(txtHora.Text)

            txtAnotacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHora.Text = ""
        End If

    End Sub

    Private Sub txtAnotacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnotacion.KeyDown

        If e.KeyData = Keys.Escape Then
            txtAnotacion.Text = ""
        End If

    End Sub
End Class