Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoRecuperoIva

    Dim nombreArchivo As String
    Dim ordDesde As String
    Dim ordHasta As String
    Dim WCuit As String
    Dim WFecha As String

    Dim WCampo1 As String
    Dim WCampo2 As String
    Dim WCampo3 As String
    Dim WCampo4 As String
    Dim WCampo5 As String

    Private Sub ProcesoPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesde.Text = "  /  /    "
        txtHasta.Text = "  /  /    "

    End Sub


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click
        Dim Vector(10000, 21) As String
        Dim WIndice = 0
        Dim escritor As System.IO.StreamWriter = Nothing

        If Trim(txtNombre.Text) = "" Then Exit Sub

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        nombreArchivo = nombreArchivo & "\" & Trim(txtNombre.Text) & ".txt"

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Try

            escritor = New StreamWriter(nombreArchivo)

            Dim tabla As DataTable
            tabla = _TraerImputacionesAduana(ordDesde, ordHasta)

            WIndice = 0

            ProgressBar1.Step = 1
            ProgressBar1.Maximum = tabla.Rows.Count * 2 + 1

            For Each WImputac As DataRow In tabla.Rows

                With WImputac

                    Vector(WIndice, 1) = IIf(IsDBNull(.Item("Cuenta")), "", .Item("Cuenta"))
                    Vector(WIndice, 2) = IIf(IsDBNull(.Item("Despacho")), "", .Item("Despacho"))
                    Vector(WIndice, 3) = IIf(IsDBNull(.Item("Debito")), "", .Item("Debito"))
                    Vector(WIndice, 4) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                    Vector(WIndice, 5) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))

                End With

                WIndice += 1

                ProgressBar1.Increment(1)

            Next

            Dim WCuenta = "", WCodigo = "", WDespacho = "", WDebito = ""
            Dim WImpre = ""

            For i = 0 To WIndice

                WCuenta = Vector(i, 1)

                If Trim(WCuenta) = "" Then Continue For

                WCodigo = "924"

                WDespacho = Vector(i, 2)
                WDebito = Proceso.formatonumerico(Vector(i, 3))
                WCuit = Vector(i, 4)
                WFecha = Vector(i, 5)

                If Val(WDebito) <= 0 Then Continue For

                WDespacho = _Left(WDespacho & Space(20), 20)
                WCuit = _Left(WCuit, 13)
                WDebito = ceros(WDebito, 10)

                WCampo1 = WCodigo
                WCampo2 = WCuit
                WCampo3 = WFecha
                WCampo4 = WDespacho
                WCampo5 = WDebito.Replace(".", ",")

                WImpre = WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & vbCrLf

                escritor.Write(WImpre)

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()

            GroupBox1.Visible = False

            MsgBox("Finalizado Proceso de Percepciones Aduanera SIAPRE", MsgBoxStyle.Information)

        Catch ex As Exception

            If Not IsNothing(escritor) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor.Dispose()
            End If

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Function _TraerImputacionesAduana(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT i.Debito, i.Cuenta, i.Fecha, iv.Despacho, p.Cuit" & _
                                              " FROM Imputac as i, IvaComp as iv, Proveedor as p" & _
                                              " WHERE i.NroInterno = iv.NroInterno AND p.Proveedor = i.Proveedor AND i.FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND i.Debito <> 0" & _
                                              " AND i.Proveedor IN ('10069345023', '10014123562', '10022098824') AND i.Cuenta = '168'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar las Ctas Ctes desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _Left(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Left(wClave, i)
    End Function

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtHasta.Text) Then
                txtNombre.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown, txtNombreArchivo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombre.Text) = "" Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click

        With OpenFileDialog1
            If .ShowDialog() = DialogResult.OK Then

                txtNombreArchivo.Text = Path.GetFileName(.FileName)
                lblRuta.Text = .FileName

            Else
                Exit Sub
            End If
        End With

    End Sub
End Class