Imports System.IO
Imports System.Text.RegularExpressions

Public Class PDFVersionesPTFarma
    Private WPartida As String = ""
    Private WMostrarDiscriminado As Boolean = False

    Sub New(ByVal Partida As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WPartida = Partida

    End Sub

    Private Sub PDFVersionesPTFarma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _ProcesarArchivos()
    End Sub

    Private Sub _ProcesarArchivos()
        Dim WDirectorioRaiz As String = Configuration.ConfigurationManager.AppSettings("PATH_ENSAYOS_INTERMEDIOS").ToString
        Dim WDirectorioPartida As String = WDirectorioRaiz & WPartida & "\"
        If Directory.Exists(WDirectorioPartida) Then
            Dim tabla As DataTable = _GenerarTablaPrincipal()
            Dim WEtapas() As String = Directory.GetDirectories(WDirectorioPartida)
            For Each wEtapa As String In WEtapas

                Dim WVersiones() As String = Directory.GetFiles(wEtapa, "*.pdf", SearchOption.TopDirectoryOnly)

                If WVersiones.Length = 0 Then Continue For

                Dim WUltAct As Date = Nothing

                For Each version As String In WVersiones
                    If WUltAct < Directory.GetCreationTime(version) Then WUltAct = Directory.GetCreationTime(version)
                Next

                tabla.Rows.Add(WPartida, wEtapa.Replace(WDirectorioPartida, ""), WVersiones.Length, WUltAct, wEtapa)

            Next

            dgvDatos.DataSource = tabla

            dgvDatos.Columns("Nombre").Visible = False

            btnVolver.Enabled = False
        End If
    End Sub

    Private Function _GenerarTablaPrincipal() As DataTable
        Dim tabla As New DataTable

        With tabla.Columns
            .Add("Partida", GetType(Integer))
            .Add("Etapa", GetType(Integer))
            .Add("CantVersiones", GetType(Integer))
            .Add("UltActualizacion", GetType(Date))
            .Add("Path")
            .Add("Nombre")
        End With

        Return tabla
    End Function

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        
        If btnVolver.Enabled Then
            Process.Start(dgvDatos.CurrentRow.Cells("Path").Value)
        Else
            _PresentarArchivosIndividuales()
        End If

    End Sub

    Private Sub _PresentarArchivosIndividuales()

        Dim WEtapaPath As String = OrDefault(dgvDatos.CurrentRow.Cells("Path").Value, "")

        If Directory.Exists(WEtapaPath) Then
            Dim tabla As DataTable = _GenerarTablaPrincipal()
            Dim WPDFs() As String = Directory.GetFiles(WEtapaPath, "*.pdf", SearchOption.TopDirectoryOnly)
            Dim WUltAct As Date = Nothing

            For Each pdf As String In WPDFs
                If WUltAct < File.GetLastWriteTime(pdf) Then WUltAct = File.GetLastWriteTime(pdf)
                tabla.Rows.Add(WPartida, _Right(WEtapaPath, 2), WPDFs.Length, File.GetLastWriteTime(pdf), pdf, pdf.Replace(WEtapaPath & "\", ""))
            Next

            tabla.DefaultView.Sort = "UltActualizacion DESC"

            dgvDatos.DataSource = tabla

            dgvDatos.Columns("CantVersiones").Visible = False
            dgvDatos.Columns("Nombre").Visible = True

            btnVolver.Enabled = True
        End If
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        _ProcesarArchivos()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class