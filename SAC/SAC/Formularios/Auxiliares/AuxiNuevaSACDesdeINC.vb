Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Office.Interop.Outlook

Public Class AuxiNuevaSACDesdeINC

    Private WFecha, WTitulo, WReferencia, WMotivo, WRefIncidencia, WComentarios As String
    Private WTipos As New DataTable
    Private WResponsables As New DataTable
    Private WEmisores As New DataTable
    Private WCentros As New DataTable
    Private WNumero As Integer = 0

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

        WNumero = 0

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Seguro de que quiere cerrar esta ventana? Se perderán las modificaciones que haya realizado.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        WTipos = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Descripcion")

        WTipos.Rows.Add(0, "")
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
            Dim WDescTipo As String = OrDefault(CType(cmbTipo.SelectedItem, DataRowView).Item("Descripcion"), "")
            Dim WAnio As String = Microsoft.VisualBasic.Right(txtFecha.Text, 4)
            WNumero = 0

            If Val(WTipo) = 0 Then
                MsgBox("Debe indicarse el Tipo de SAC.", MsgBoxStyle.Exclamation)
                cmbTipo.Focus()
                Exit Sub
            End If

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

            ExecuteNonQueries(ZSQL, "UPDATE CargaSacAdicional SET Dato1 = '" & WComentarios & "' WHERE Clave = '" & WClave & "'", "UPDATE CargaIncidencias SET ClaveSAC = '" & WClave & "', EsSACAsociada = '0' WHERE Incidencia = '" & WRefIncidencia & "'")

            '
            ' Enviamos emails.
            '
            Dim WCent As DataRow = GetSingle("SELECT Responsable FROM CentroSac WHERE Codigo = '" & WCentro & "'")

            If WCent IsNot Nothing Then

                Dim WResp As DataRow = GetSingle("SELECT Email FROM ResponsableSAC WHERE Codigo = '" & OrDefault(WCent.Item("Responsable"), 0) & "'")

                If WResp IsNot Nothing AndAlso Trim(OrDefault(WResp.Item("Email"), "")) <> "" Then

                    If MsgBox("¿Desea enviar el aviso al Responsable del Área?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        _EnviarEmail(WResp.Item("Email"), "Carga de " & Trim(WDescTipo), "Se inicio una " & Trim(WDescTipo) & " : " & WAnio & "/" & WNumero & " para determinar CAUSAS y Acciones Correctivas correspondientes. Referencia : " & txtReferencia.Text.Trim & " Título : " & txtTitulo.Text.Trim)

                    End If

                End If

            End If

            If Val(WResponsable) <> 0 Then

                Dim WResp As DataRow = GetSingle("SELECT Email FROM ResponsableSAC WHERE Codigo = '" & WResponsable & "'")

                If WResp IsNot Nothing AndAlso Trim(OrDefault(WResp.Item("Email"), "")) <> "" Then

                    If MsgBox("¿Desea enviar el aviso al Responsable de Investigación?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        _EnviarEmail(WResp.Item("Email"), "Carga de " & Trim(WDescTipo), "Se inicio una " & Trim(WDescTipo) & " : " & WAnio & "/" & WNumero & " para determinar CAUSAS y Acciones Correctivas correspondientes. Referencia : " & txtReferencia.Text.Trim & " Título : " & txtTitulo.Text.Trim)

                    End If

                End If

            End If

            If MsgBox("¿Desea enviar el aviso al Responsable de Calidad?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                _EnviarEmail("ebiglieri@surfactan.com.ar; calidad@surfactan.com.ar; wbarosio@surfactan.com.ar; calidad2@surfactan.com.ar; isocalidad@surfactan.com.ar;juanfs@surfactan.com.ar; lsantos@surfactan.com.ar; drodriguez@surfactan.com.ar", "Carga de " & Trim(WDescTipo), "Se inicio una " & Trim(WDescTipo) & " : " & WAnio & "/" & WNumero & " para determinar CAUSAS y Acciones Correctivas correspondientes. Referencia : " & txtReferencia.Text.Trim & " Título : " & txtTitulo.Text.Trim)

            End If

            Dim WOwner As IAuxiNuevaSACDesdeINC = CType(Owner, IAuxiNuevaSACDesdeINC)

            If WOwner IsNot Nothing Then WOwner._ProcesarNuevaSACDesdeINC(WClave)

            Close()

        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _EnviarEmail(ByVal Direccion As String, ByVal Subject As String, ByVal Body As String, Optional ByVal EnvioAutomatico As Boolean = False)
        Dim oApp As _Application
        Dim oMsg As _MailItem

        Try
            oApp = New Application()

            oMsg = oApp.CreateItem(OlItemType.olMailItem)
            oMsg.Subject = Subject
            oMsg.Body = Body

            ' Modificar por los E-Mails que correspondan.
            oMsg.To = Direccion

            Dim WTipo As String = cmbTipo.SelectedIndex
            Dim WAnio As String = Mid(txtFecha.Text, 7, 4) 'txtAnio.Text

            Dim frm As New Util.VistaPrevia

            With frm

                .Reporte = New NuevoSACAmbos

                .Formula = "{CargaSac.Tipo} = " & WTipo & " And {CargaSac.Numero} = " & WNumero & " And {CargaSac.Ano} = " & WAnio & ""

            End With

            Util.Clases.Conexion.EmpresaDeTrabajo = "SurfactanSa"
            Util.Clases.Helper._ExportarReporte(frm, Util.Clases.Enumeraciones.FormatoExportacion.PDF, WTipo & WNumero & WAnio & ".pdf", "C:\TempReclamos\")

            If File.Exists("C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf") Then
                oMsg.Attachments.Add("C:\TempReclamos\" & WTipo & WNumero & WAnio & ".pdf")
            End If

            If EnvioAutomatico Then
                oMsg.Send()
            Else
                oMsg.Display()
            End If

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
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