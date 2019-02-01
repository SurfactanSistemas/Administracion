Imports System.ComponentModel

Public Class AuxiNuevaSACDesdeINC

    Private WFecha, WTitulo, WReferencia, WMotivo, WRefIncidencia, WComentarios As String
    Private WTipos As New DataTable
    Private WResponsables As New DataTable
    Private WEmisores As New DataTable
    Private WCentros As New DataTable

    Sub New(ByVal _Incidencia, ByVal _Fecha, ByVal _Titulo, ByVal _Referencia, ByVal _Motivo, Optional ByVal _Comentarios = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WFecha = _Fecha
        WTitulo = Trim(_Titulo)
        WReferencia = Trim(_Referencia)
        WMotivo = Trim(_Motivo)
        WRefIncidencia = Trim(_Incidencia)
        WComentarios = Trim(_Comentarios)

    End Sub

    Private Sub AuxiNuevaSACDesdeINC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        txtFecha.Text = WFecha
        txtTitulo.Text = WTitulo
        txtReferencia.Text = WReferencia
        txtMotivo.Text = WMotivo

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Seguro de que quiere cerrar esta ventana? Se perderán las modificaciones que haya realizado.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        WTipos = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Descripcion")

        WTipos.DefaultView.Sort = "Codigo"

        BackgroundWorker1.ReportProgress(10, WTipos)

        WEmisores = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        BackgroundWorker1.ReportProgress(20, WEmisores)

        WResponsables = WEmisores.Copy

        WResponsables.DefaultView.Sort = "Codigo"

        BackgroundWorker1.ReportProgress(30, WResponsables)

        WCentros = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM CentroSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        WCentros.DefaultView.Sort = "Codigo"

        BackgroundWorker1.ReportProgress(40, WCentros)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim WTabla As DataTable = CType(e.UserState, DataTable)

        Select Case e.ProgressPercentage
            Case 10
                With cmbTipo
                    .DataSource = WTabla
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Codigo"
                End With
            Case 20
                With cmbEmisor
                    .DataSource = WTabla
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Codigo"
                End With
            Case 30
                With cmbResponsable
                    .DataSource = WTabla
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Codigo"
                End With
            Case 40
                With cmbCentro
                    .DataSource = WTabla
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Codigo"
                End With
        End Select

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerar.Click
        Try

            Dim WTipo As String = OrDefault(CType(cmbTipo.SelectedItem, DataRowView).Item("Codigo"), 0)
            Dim WAnio As String = Microsoft.VisualBasic.Right(txtFecha.Text, 4)
            Dim WNumero = 0

            Dim WUltimo As DataRow = GetSingle("SELECT Max(Numero) Ultimo FROM CargaSAC WHERE Tipo = '" & WTipo & "' And Ano = '" & WAnio & "'")

            If WUltimo IsNot Nothing Then WNumero = WUltimo.Item("Ultimo")

            WNumero += 1

            Dim WClave = WTipo.PadLeft(4, "0") & WAnio.PadLeft(4, "0") & WNumero.ToString.PadLeft(6, "0")

            Dim _Fecha = txtFecha.Text
            Dim WFechaOrd = ordenaFecha(_Fecha)
            Dim WResponsable = OrDefault(CType(cmbResponsable.SelectedItem, DataRowView).Item("Codigo"), 0)
            Dim WCentro = OrDefault(CType(cmbCentro.SelectedItem, DataRowView).Item("Codigo"), 0)
            Dim WEmisor = OrDefault(CType(cmbEmisor.SelectedItem, DataRowView).Item("Codigo"), 0)
            Dim _Titulo = txtTitulo.Text.Trim
            Dim _Referencia = txtReferencia.Text.Trim
            Dim _Motivo = txtMotivo.Text.Trim
            Dim WOrigen = 3
            Dim WEstado = 1

            Dim ZSQL = String.Format("INSERT INTO CargaSAC (Clave, Tipo, Ano, Numero, Centro, Fecha, OrdFecha, Origen, Estado, IngresoNoCon, ResponsableEmisor, ResponsableDestino, Titulo, Referencia) " _
                                     & " VALUES " _
                                     & " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')",
                                     WClave, WTipo, WAnio, WNumero, WCentro, _Fecha, WFechaOrd, WOrigen, WEstado, _Motivo, WEmisor, WResponsable, _Titulo, _Referencia)

            ExecuteNonQueries(ZSQL, "UPDATE CargaSacAdicional SET Dato1 = '" & WComentarios & "' WHERE Clave = '" & WClave & "'", "UPDATE CargaIncidencias SET ClaveSAC = '" & WClave & "' WHERE Incidencia = '" & WRefIncidencia & "'")

            Dim WOwner As IAuxiNuevaSACDesdeINC = CType(Owner, IAuxiNuevaSACDesdeINC)

            If WOwner IsNot Nothing Then WOwner._ProcesarNuevaSACDesdeINC(WClave)

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        For Each c As ComboBox In {cmbCentro, cmbEmisor, cmbResponsable, cmbTipo}
            With c
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Next
    End Sub
End Class