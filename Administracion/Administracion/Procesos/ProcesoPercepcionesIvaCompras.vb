Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoPercepcionesIvaCompras


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WFecha As String

    Dim WCampo1 As String
    Dim WCampo2 As String
    Dim WCampo3 As String
    Dim WCampo4 As String
    Dim WCampo5 As String
    Dim WCampo6 As String

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
        Dim Vector(10000, 15) As String
        Dim WIndice = 0
        Dim escritor As System.IO.StreamWriter

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If Trim(txtNombre.Text) = "" Then Exit Sub

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        REM XNombre = WDir + "\AR-30610524598-" + Nombre.Text + "-7-LOTE1.txt"
        nombreArchivo = nombreArchivo + "\" + txtNombre.Text + ".txt"
        
        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        Try


            File.Create(nombreArchivo).Dispose()

            escritor = New System.IO.StreamWriter(nombreArchivo)
            Dim tabla As DataTable

            tabla = _TraerFacturas()

            ProgressBar1.Step = 1
            ProgressBar1.Maximum = tabla.Rows.Count * 2 + 10

            ProgressBar1.Increment(10)

            Dim WPeriodoOrd = 0
            Dim WPunto = "", WNumero = "", WProveedor = "", WIva5 = "", WCuit = "", WPeriodo = ""

            For Each WFactura As DataRow In tabla.Rows

                With WFactura

                    WPeriodo = IIf(IsDBNull(.Item("Periodo")), "", .Item("Periodo"))

                    WPeriodoOrd = Proceso.ordenaFecha(WPeriodo)

                    If WPeriodoOrd >= ordDesde And WPeriodoOrd <= ordHasta Then

                        Vector(WIndice, 0) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        Vector(WIndice, 1) = IIf(IsDBNull(.Item("Punto")), "", .Item("Punto"))
                        Vector(WIndice, 2) = IIf(IsDBNull(.Item("Numero")), "", .Item("Numero"))
                        Vector(WIndice, 3) = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))
                        Vector(WIndice, 4) = IIf(IsDBNull(.Item("Iva5")), "0", .Item("Iva5"))
                        Vector(WIndice, 5) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))

                        WIndice += 1

                    End If

                End With

                ProgressBar1.Increment(1)

            Next

            For i = 0 To WIndice

                WFecha = Vector(i, 0)
                WPunto = Vector(i, 1)
                WNumero = Vector(i, 2)
                WProveedor = Vector(i, 3)
                WIva5 = Proceso.formatonumerico(Vector(i, 4))

                WIva5 = Str$(Val(WIva5))

                WIva5 = WIva5.Replace(",", ".")

                WCuit = Vector(i, 5)

                If Val(WIva5) <= 0 Then Continue For

                WPunto = ceros(WPunto, 8)
                WNumero = ceros(WNumero, 8)
                WIva5 = ceros(WIva5, 16)

                Select Case WProveedor
                    Case "10069345023", "10169345023", "10014123562", "10022098824"
                        WCampo1 = "267"
                    Case Else
                        WCampo1 = "493"
                End Select

                WCampo2 = Trim(WCuit)
                WCampo3 = Trim(WFecha)
                WCampo4 = Trim(WPunto)
                WCampo5 = Trim(WNumero)
                WCampo6 = Trim(WIva5)

                escritor.Write(WCampo1 & WCampo2 & WCampo3 & WCampo4 & WCampo5 & WCampo6 & vbCrLf)

                ProgressBar1.Increment(1)

            Next

            escritor.Dispose()

            GroupBox1.Visible = False

            MsgBox("Ha Finalizado correctamente el Proceso de Percepción de Iva (Compras)", MsgBoxStyle.Information)

        Catch ex As Exception
            If Not IsNothing(escritor) Then
                ' ReSharper disable once VBWarnings::BC42104
                escritor.Dispose()
            End If

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Function _TraerFacturas() As DataTable

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT i.Punto, i.Numero, i.Proveedor, i.Iva5, p.Cuit, i.Periodo, i.Fecha FROM IvaComp as i JOIN Proveedor as p ON p.Proveedor = i.Proveedor ORDER BY i.OrdFecha")
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
            Throw New Exception("Hubo un problema al querer consultar las Facturas en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla

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

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombre.Text) = "" Then : Exit Sub : End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

End Class