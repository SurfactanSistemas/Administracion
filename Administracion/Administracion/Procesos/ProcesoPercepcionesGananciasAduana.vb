Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports System.IO

Public Class ProcesoPercepcionesGananciasAduana


    Dim nombreArchivo As String

    Dim ordDesde As String
    Dim ordHasta As String


    Dim WCuit As String
    Dim WFecha As String
    Dim WNumero As String
    Dim WNeto As String
    Dim WPorceIb As String

    Dim WCampo1 As String
    Dim WCampo2 As String
    Dim WCampo3 As String
    Dim WCampo4 As String
    Dim WCampo5 As String
    Dim WCampo6 As String
    Dim WCampo7 As String
    Dim WCampo8 As String
    Dim WCampo9 As String
    Dim WCampo10 As String
    Dim WCampo11 As String
    Dim WCampo12 As String
    Dim WCampo13 As String
    Dim WCampo14 As String
    Dim WCampo15 As String
    Dim WCampo16 As String
    Dim WCampo17 As String
    Dim WCampo18 As String
    Dim WCampo19 As String
    Dim WCampo20 As String
    Dim WCampo21 As String

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
        Dim VectorEntra(10000, 2) As String
        Dim WIndice = 0, WIndiceEntra = 0
        Dim escritor As System.IO.StreamWriter

        ProgressBar1.Value = 0
        GroupBox1.Visible = True

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            nombreArchivo = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        nombreArchivo = nombreArchivo + "\aduana.txt"

        ordDesde = ordenaFecha(txtDesde.Text)
        ordHasta = ordenaFecha(txtHasta.Text)

        'Try
        '_ModificarCtaCteImporteIva0()

        escritor = New StreamWriter(nombreArchivo)

        Dim tabla As DataTable
        tabla = _TraerDatosAduana(ordDesde, ordHasta) 'SQLConnector.retrieveDataTable("procesoperceibtucuman", ordDesde, ordHasta)

        WIndice = 0
        WIndiceEntra = 0

        ProgressBar1.Step = 1
        ProgressBar1.Maximum = tabla.Rows.Count * 2 + 1

        Dim WRegimen = "", WImporte = "", WNroComprobante = ""

        For Each WAduana As DataRow In tabla.Rows

            With WAduana

                Vector(WIndice, 1) = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                Vector(WIndice, 2) = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                Vector(WIndice, 3) = IIf(IsDBNull(.Item("Regimen")), "", .Item("Regimen"))
                Vector(WIndice, 4) = IIf(IsDBNull(.Item("Importe")), "0", .Item("Importe"))
                Vector(WIndice, 5) = IIf(IsDBNull(.Item("NroComprobante")), "", .Item("NroComprobante"))

            End With

            WIndice += 1

            ProgressBar1.Increment(1)

        Next

        Dim WImpre = ""

        For i = 0 To WIndice

            WCuit = Vector(i, 1)

            If Trim(WCuit) = "" Then Continue For

            WFecha = Vector(i, 2)
            WRegimen = Vector(i, 3)
            WImporte = Str$(Val(Proceso.formatonumerico(Vector(i, 4))))
            WNroComprobante = Vector(i, 5)

            WCampo1 = "2"
            WCampo2 = WCuit
            WCampo3 = WFecha
            WCampo4 = WRegimen
            WCampo5 = WImporte.Replace(",", ".")
            WCampo6 = WNroComprobante

            WCampo4 = ceros(WCampo4, 3)
            WCampo5 = ceros(WCampo5, 15)
            WCampo6 = _Left(WCampo6 & Space(30), 30)

            WImpre = WCampo1 & WCampo2 & WCampo6 & WCampo3 & WCampo4 & WCampo5 & vbCrLf

            escritor.Write(WImpre)

            ProgressBar1.Increment(1)
        Next

        escritor.Dispose()

        GroupBox1.Visible = False

        MsgBox("Proceso Finalizado de Percepciones de Ganancias de Aduana", MsgBoxStyle.Information)

        'Catch ex As Exception

        '    If Not IsNothing(escritor) Then
        '        ' ReSharper disable once VBWarnings::BC42104
        '        escritor.Dispose()
        '    End If

        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End Try
    End Sub

    Private Function _TraerOrdenPago(ByVal wOrden As String) As DataTable

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Importe1 FROM Pagos WHERE Orden = '" & wOrden & "' AND TipoReg='1' ORDER BY Renglon")
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
            Throw New Exception("Hubo un problema al querer consultar la Orden de Pago desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerPagos(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT p.Orden, p.Proveedor, p.Fecha, p.Importe, p.Retencion, p.CertificadoIbCiudad, p.RetIbCiudad, " & _
                                              " pr.Nombre, pr.Iva, pr.NroIb, pr.Cuit, pr.IbCiudadII FROM Pagos p JOIN Proveedor pr ON pr.Proveedor = p.Proveedor " & _
                                              " WHERE FechaOrd BETWEEN " & WDesde & " AND " & WHasta & " AND p.Renglon = '01'")
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
            Throw New Exception("Hubo un problema al querer consultar los Pagos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla
    End Function

    Private Function _TraerDatosAduana(ByVal WDesde As String, ByVal WHasta As String) As DataTable

        Dim tabla As New DataTable
        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\193.168.0.2\g$\system\0001auxi.mdb;Persist Security Info=True;")
        Dim cm As New OleDb.OleDbCommand("SELECT * FROM Aduana")
        Dim dr As OleDb.OleDbDataReader

        Try

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

    Private Function _Right(ByVal wClave As String, ByVal i As Integer) As String
        Return Microsoft.VisualBasic.Right(wClave, i)
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
                txtDesde.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub ProcesoPercepciones_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

End Class