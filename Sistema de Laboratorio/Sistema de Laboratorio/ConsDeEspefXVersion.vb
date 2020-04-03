Imports System.Configuration
Imports System.Data.SqlClient

Public Class ConsDeEspefXVersion

    Dim tablaParaDGV As New DataTable
    Dim VersionMax As Integer


    Private Sub ConsDeEspefXVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ""
        With tablaParaDGV.Columns
            .Add("Ensayo")
            .Add("Descripcion")
            .Add("ValorEstandar")
            .Add("Desde")
            .Add("Hasta")
            .Add("ControlDeCambios")
        End With

        For i As Integer = 0 To 9
            tablaParaDGV.Rows.Add()
            DGV_ConsultaVersiones.Rows.Add()
        Next
        For i As Integer = 0 To 9

            DGV_ConsultaVersiones.Rows.Item(i).Cells("Ensayo").Value = tablaParaDGV.Rows(i).Item("Ensayo")
            DGV_ConsultaVersiones.Rows.Item(i).Cells("Descripcion").Value = tablaParaDGV.Rows(i).Item("Descripcion")
            DGV_ConsultaVersiones.Rows.Item(i).Cells("ValorEstandar").Value = tablaParaDGV.Rows(i).Item("ValorEstandar")
            DGV_ConsultaVersiones.Rows.Item(i).Cells("Desde").Value = tablaParaDGV.Rows(i).Item("Desde")
            DGV_ConsultaVersiones.Rows.Item(i).Cells("Hasta").Value = tablaParaDGV.Rows(i).Item("Hasta")

        Next

    End Sub

    Private Sub mastxtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtCodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtVersion.Focus()
            Case Keys.Escape
                mastxtCodigo.Text = ""
        End Select
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVersion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtVersion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVersion.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtVersion.Text = ""
            Case Keys.Enter
                Try
                    If (mastxtCodigo.Text.Replace("-", "").Trim() <> "") Then
                        _LimpiarGrilla()
                        _BuscarVersionMax()
                        If txtVersion.Text > VersionMax Then
                            txtVersion.Text = VersionMax
                        End If



                        If (DebeMOstrar(txtVersion.Text) = True) Then
                           
                            Dim SQLConsulta As String

                            SQLConsulta = "SELECT * FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"
                            SQLConsulta = SQLConsulta & "AND Version = '" & txtVersion.Text.Trim() & "'"

                            ' Dim cmd = New SqlCommand(SQLConsulta, cn)
                            ' Dim dr As SqlDataReader = cmd.ExecuteReader()
                            Dim tabla As New DataTable
                            tabla = GetAll(SQLConsulta, "Surfactan_II")

                            If (tabla.Rows.Count > 0) Then

                                For i As Integer = 1 To 10
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Ensayo").Value = IIf(IsDBNull(tabla.Rows(0).Item("Ensayo" & i)), "", tabla.Rows(0).Item("Ensayo" & i))
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("ValorEstandar").Value = tabla.Rows(0).Item("Valor" & i) & IIf(IsDBNull(tabla.Rows(0).Item("Valor" & i & i)), "", tabla.Rows(0).Item("Valor" & i & i))
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Desde").Value = tabla.Rows(0).Item("Desde" & i)
                                    DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Hasta").Value = tabla.Rows(0).Item("Hasta" & i)
                                Next
                                txtFechaDesde.Text = tabla.Rows(0).Item("FechaInicio")
                                txtFechaHasta.Text = tabla.Rows(0).Item("FechaFinal")
                                txtControlDeCambios.Text = IIf(IsDBNull(tabla.Rows(0).Item("ControlCambio")), "", tabla.Rows(0).Item("ControlCambio"))
                            End If
                            CargarDescripciones()
                        Else
                            For i As Integer = 1 To 10
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Ensayo").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Descripcion").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("ValorEstandar").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Desde").Value = ""
                                DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Hasta").Value = ""
                            Next
                            txtFechaDesde.Text = ""
                            txtFechaHasta.Text = ""
                            txtControlDeCambios.Text = ""
                        End If
                    End If
                Catch ex As Exception

                End Try

            Case Keys.Right
                btnSiguienteVersion_Click(Nothing, Nothing)


            Case Keys.Left
                btnAnteriorVersion_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub CargarDescripciones()
    
        For Each row As Datagridviewrow In DGV_ConsultaVersiones.Rows
            With row

                Dim e As Integer = Val(OrDefault(row.Cells("Ensayo").Value, ""))

                If e = 0 Then Continue For

                Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & e & "'")

                If WEnsayo Is Nothing Then Continue For

                row.Cells("Descripcion").Value = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

            End With
        Next

    End Sub

    Private Function DebeMOstrar(ByVal Version As Integer) As Boolean
      
        Dim SQLConsulta As String

        Version = Version + 1

        SQLConsulta = "SELECT * FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"
        SQLConsulta = SQLConsulta & "AND Version = '" & Version & "'"

        Dim tabla As New DataTable
        tabla = GetAll(SQLConsulta, "Surfactan_II")

        If tabla.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnSiguienteVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteVersion.Click
        If (txtVersion.Text <> "") Then
            txtVersion.Text = txtVersion.Text + 1
            txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub btnAnteriorVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorVersion.Click
        If (txtVersion.Text <> "") Then
            If (txtVersion.Text > 1) Then
                txtVersion.Text = txtVersion.Text - 1
                txtVersion_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        mastxtCodigo.Text = ""
        txtVersion.Text = ""

        _LimpiarGrilla()
       
        txtFechaDesde.Text = ""
        txtFechaHasta.Text = ""
        txtControlDeCambios.Text = ""

        mastxtCodigo.Focus()

    End Sub

    Private Sub _LimpiarGrilla()
        For i As Integer = 1 To 10
            DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Ensayo").Value = ""
            DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Descripcion").Value = ""
            DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("ValorEstandar").Value = ""
            DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Desde").Value = ""
            DGV_ConsultaVersiones.Rows.Item(i - 1).Cells("Hasta").Value = ""
        Next
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim tablaReporte As New DataTable
        With tablaReporte.Columns
            .Add("Codigo")
            .Add("DescripcionPT")
            .Add("Version")
            .Add("FechaDesde")
            .Add("FechaHasta")
            .Add("Ensayo")
            .Add("Descripcion")
            .Add("Valor")
        End With
        For i As Integer = 0 To 9
            tablaReporte.Rows.Add()
            tablaReporte.Rows(i).Item("Codigo") = mastxtCodigo.Text.Trim()
            tablaReporte.Rows(i).Item("Version") = txtVersion.Text.Trim()
            tablaReporte.Rows(i).Item("FechaDesde") = txtFechaDesde.Text.Trim()
            tablaReporte.Rows(i).Item("FechaHasta") = txtFechaHasta.Text.Trim()

            tablaReporte.Rows(i).Item("Ensayo") = DGV_ConsultaVersiones.Rows.Item(i).Cells("Ensayo").Value
            tablaReporte.Rows(i).Item("Descripcion") = DGV_ConsultaVersiones.Rows.Item(i).Cells("Descripcion").Value
            tablaReporte.Rows(i).Item("Valor") = DGV_ConsultaVersiones.Rows.Item(i).Cells("ValorEstandar").Value
        Next
        Try
          
            Dim SQLConsulta As String

            SQLConsulta = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & mastxtCodigo.Text.Trim() & "'"

            Dim tabla As New DataTable
            tabla = GetAll(SQLConsulta, "Surfactan_II")
            If (tabla.Rows.Count > 0) Then
                For i As Integer = 0 To 9
                    tablaReporte.Rows(i).Item("DescripcionPT") = tabla.Rows(0).Item("Descripcion")
                Next

            End If
        Catch ex As Exception

        End Try


        With New VistaPrevia
            .Reporte = New ReporteEspecifXVersion()
            .Reporte.SetDataSource(tablaReporte)
            .Imprimir()
        End With


    End Sub

    Private Sub _BuscarVersionMax()
        Dim SQLCnslt As String

        SQLCnslt = "SELECT VersionMax = MAX(Version) FROM EspecifUnificaVersion WHERE Producto = '" & mastxtCodigo.Text.Trim() & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then
            VersionMax = row.Item("VersionMax")
        End If

    End Sub
End Class