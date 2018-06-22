Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class EnvioEmailProveedores

    Private _Asunto As String
    Private _CuerpoEmail As String
    Private _LineasExtras As String
    Private _ArchivoAdjunto As String
    Private _ListaEmails() As String
    Private WListaEmails As String
    Private Const LIMITE_DE_DIRECCIONES_POR_EMAIL = 10
    '
    ' TODO - CONSULTAR EN CASO DE USO EN PELLITAL, QUE DIRECCION SE UTILIZA O SI SE EVITA EL ENVIO DE EMAIL EN CASO DE NO UTILIZARLO.
    '
    Private _To As String = "surfactan@surfactan.com.ar" '"gferreyra@surfactan.com.ar" ' Cambiar por la direccion de Surfactan y posibles otras.


    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Try
            _Asunto = Trim(txtAsunto.Text)

            _CuerpoEmail = Trim(txtCuerpoEmail.Text)

            _LineasExtras = _ParsearLineasExtras()

            _ListaEmails = _ProcesarProveedoresDestinatarios()

            'WListaEmails = Trim(txtDestinatarios.Text)

            _ProcesarEnvioEmails()

            Label8.Visible = False
            With ProgressBar2
                .Value = 0
                .Visible = False
            End With

            MsgBox("Los correos han sido enviados.", MsgBoxStyle.Information)
        
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Function _ProcesarProveedoresDestinatarios() As String()
        Return txtDestinatarios.Text.Replace(" ", "").Split(";")
    End Function

    Private Sub _ProcesarEnvioEmails()
        Dim _CantGrupos As Integer = Math.Floor(_ListaEmails.Length / LIMITE_DE_DIRECCIONES_POR_EMAIL)	
        Dim _SubGrupoEmails As New List(Of String)	
        Dim _IndiceEmailActual As Integer = 0

        With ProgressBar2
            .Visible = True
            .Value = 0
            .Maximum = _ListaEmails.Length + 5
        End With

        ' Procesamos los grupos posibles.	
        For i As Integer = 1 To _CantGrupos	
	
            For j As Integer = 0 To LIMITE_DE_DIRECCIONES_POR_EMAIL - 1	
	
                _SubGrupoEmails.Add(_ListaEmails(_IndiceEmailActual))	
	
                _IndiceEmailActual += 1

                ProgressBar2.Increment(1)
	
            Next	
	
                _EnviarEmail(_SubGrupoEmails) ' Descomentar para que comience a funcionar, no olvidarse tambien de descomentar el de mas abajo.	
            
	
            _SubGrupoEmails.Clear() ' Limpiamos para el siguiente grupo.	
	
        Next	
	
        _SubGrupoEmails.Clear() ' Limpiamos antes de procesar los remanentes.	
	
        ' Procesamos los remanentes.	
        For i As Integer = _IndiceEmailActual To _ListaEmails.Length - 1	
            _SubGrupoEmails.Add(_ListaEmails(i))	

            ProgressBar2.Increment(1)
        Next
            
        _EnviarEmail(_SubGrupoEmails)

    End Sub
    
    Private Sub _EnviarEmail(ByVal emails As List(Of String))
        Dim _Outlook As New Outlook.Application

        Try
            Dim _Mail As Outlook.MailItem = _Outlook.CreateItem(Outlook.OlItemType.olMailItem)

            With _Mail

                .To = _To
                .BCC = String.Join(";", emails) 'WListaEmails
                .Subject = _Asunto
                .Body = _CuerpoEmail + vbCrLf + _LineasExtras

                If Trim(_ArchivoAdjunto) <> "" Then
                    .Attachments.Add(_ArchivoAdjunto)
                End If

            End With

            _Mail.Send()
            '_Mail.Display()

            _Mail = Nothing

            Me.Close()

        Catch ex As Exception
            Throw New Exception("Ocurrió un problema al querer enviar el email a los proveedores.")
        Finally
            _Outlook = Nothing
        End Try

    End Sub

    Private Function _ParsearLineasExtras()
        Dim LineasParseadas As String = ""

        If Trim(txtLineaExtraI.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraI.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraII.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraII.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraIII.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraIII.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraIV.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraIV.Text) + vbCrLf
        End If

        Return LineasParseadas
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntar.Click
        _AdjuntarArchivo()
    End Sub

    Private Sub EnvioEmailProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()

        txtAsunto.Text = ""
        txtCuerpoEmail.Text = ""
        txtLineaExtraI.Text = ""
        txtLineaExtraII.Text = ""
        txtLineaExtraIII.Text = ""
        txtLineaExtraIV.Text = ""
        txtNombreArchivoAdjunto.Text = ""
        pnlDestinatarios.Visible=False
    End Sub

    Private sub _TraerProveedoresDestinatarios()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim _FechaUltimo As String
        Dim _Inhabilitado As String = ""
        Dim WProveedor, WRazon, WEmail, WTipoProv As String

        'Calculo un año hacia atrás a partir del dia de hoy.
        _FechaUltimo = _ObtenerFechaLimite()

        Dim tabla As New DataTable

        Try
            cn.ConnectionString = Proceso._ConectarA() '"Data Source=193.168.0.7;Initial Catalog=SurfactanSA;User ID=usuarioadmin; Password=usuarioadmin"

            cm.CommandText = "SELECT DISTINCT IvaComp.Proveedor, Proveedor.Nombre as Razon, Proveedor.Email, Proveedor.TipoProv, Proveedor.Inhabilitado FROM IvaComp, Proveedor WHERE IvaComp.Proveedor = Proveedor.Proveedor AND IvaComp.Ordfecha >= '" + _FechaUltimo + "' AND Proveedor.Email <> '' ORDER BY Razon"
            cm.Connection = cn

            cn.Open()

            dr = cm.ExecuteReader()

            With tabla.Columns
                .Add("Enviar")
                .Add("Proveedor")
                .Add("Razon")
                .Add("Email")
                .Add("TipoProv")
            End With

            If dr.HasRows Then

                Do While dr.Read()

                    _Inhabilitado = IIf(IsDBNull(dr.Item("Inhabilitado")), "0", dr.Item("Inhabilitado"))

                    If _Inhabilitado <> "1" Then
                        WProveedor = IIf(IsDBNull(dr.Item("Proveedor")), "", dr.Item("Proveedor"))
                        WRazon = IIf(IsDBNull(dr.Item("Razon")), "", dr.Item("Razon"))
                        WEmail = IIf(IsDBNull(dr.Item("Email")), "", dr.Item("Email"))
                        WTipoProv = IIf(IsDBNull(dr.Item("TipoProv")), "", dr.Item("TipoProv"))
                        
                        Dim WRow As DataRow = tabla.NewRow

                        WRow.Item("Enviar") = ""
                        WRow.Item("Proveedor") = WProveedor
                        WRow.Item("Razon") = WRazon
                        WRow.Item("Email") = WEmail
                        WRow.Item("TipoProv") = WTipoProv

                        tabla.Rows.Add(WRow)

                    End If

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar las direcciones de E-Mail de los Proveedores.", MsgBoxStyle.Critical)
        Finally
            cn.Close()
            cm = Nothing
            dr = Nothing
        End Try

        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear

        If tabla.Rows.Count > 0 then
            DataGridView1.DataSource = tabla

            With DataGridView1.Columns(0)
                .Width = 20
                .HeaderText=""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            
            With DataGridView1.Columns(1)
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With DataGridView1.Columns(2)
                .Width = 200
            End With

            With DataGridView1.Columns(3)
                .Width = 160
            End With

            With DataGridView1.Columns(4)
                .Visible=False
            End With

        End If
    End sub

    Private Function _ObtenerFechaLimite()
        Dim fecha As String = ""

        fecha += (Today.Year - 1).ToString()

        If Today.Month > 9 Then
            fecha += Today.Month.ToString()
        Else
            fecha += "0" + Today.Month.ToString()
        End If

        Return fecha + "01"
    End Function

    Private Sub _AdjuntarArchivo()

        OFDAdjuntarArchivo.FileName = ""

        If OFDAdjuntarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            _ArchivoAdjunto = OFDAdjuntarArchivo.FileName

            txtNombreArchivoAdjunto.Text = _ArchivoAdjunto

        End If

        OFDAdjuntarArchivo.Dispose()

    End Sub

    Private Sub txtNombreArchivoAdjunto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreArchivoAdjunto.DoubleClick
        _AdjuntarArchivo()
    End Sub


    Private Sub txtNombreArchivoAdjunto_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNombreArchivoAdjunto.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs)
        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
        _ArchivoAdjunto = archivos(0)
        txtNombreArchivoAdjunto.Text = _ArchivoAdjunto
    End Sub

    Private Sub txtNombreArchivoAdjunto_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNombreArchivoAdjunto.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub btnAdjuntar_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAdjuntar.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub btnAdjuntar_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAdjuntar.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub txtAsunto_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAsunto.KeyDown
        
        If e.KeyData = Keys.Enter Then
	       ' If Trim(txtAsunto.Text) = "" Then : Exit Sub : End If

            txtCuerpoEmail.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtAsunto.Text = ""
        End If
        
    End Sub

    Private Sub txtLineaExtraI_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLineaExtraI.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtLineaExtraI.Text) = "" Then : Exit Sub : End If

            txtLineaExtraII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLineaExtraI.Text = ""
        End If
        
    End Sub

    Private Sub txtLineaExtraII_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLineaExtraII.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtLineaExtraII.Text) = "" Then : Exit Sub : End If

            txtLineaExtraIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLineaExtraII.Text = ""
        End If
        
    End Sub

    Private Sub txtLineaExtraIII_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLineaExtraIII.KeyDown
        
        If e.KeyData = Keys.Enter Then
	     '   If Trim(txtLineaExtraIII.Text) = "" Then : Exit Sub : End If
            txtLineaExtraIV.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLineaExtraIII.Text = ""
        End If
        
    End Sub

    Private Sub txtLineaExtraIV_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLineaExtraIV.KeyDown
        
        If e.KeyData = Keys.Escape Then
            txtLineaExtraIV.Text = ""
        End If
        
    End Sub

    Private Sub EnvioEmailProveedores_Shown( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Shown
        txtAsunto.Focus
    End Sub

    Private Sub txtDestinatarios_MouseDoubleClick( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDestinatarios.MouseDoubleClick
        cmbTipoProv.DataSource = _CargarTipoProveedores()
        cmbTipoProv.ValueMember = "Codigo"
        cmbTipoProv.DisplayMember = "Descripcion"
        cmbTipoProv.SelectedIndex = -1
        If DataGridView1.Rows.Count = 0 then _TraerProveedoresDestinatarios()
    End Sub

    Private Function _CargarTipoProveedores() As Datatable
        
        Dim tabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, LTRIM(RTRIM(Descripcion)) as Descripcion FROM TipoProv")
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
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
      
        Return tabla
    End Function

    Private Sub Button1_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button1.Click
        pnlDestinatarios.Visible=False
        txtCuerpoEmail.Focus
    End Sub

    Private Sub DataGridView1_CellMouseClick( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.ColumnIndex = 0 and e.RowIndex > -1 then
            If DataGridView1.Rows(e.RowIndex).Cells(0).Value = "X" then
                DataGridView1.Rows(e.RowIndex).Cells(0).Value = ""
            Else
                DataGridView1.Rows(e.RowIndex).Cells(0).Value = "X"
            End If
        End If
    End Sub

    Private Sub cmbTipoProv_SelectedIndexChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles cmbTipoProv.SelectedIndexChanged
        Dim tabla As DataTable = CType(DataGridView1.DataSource, DataTable)

        If cmbTipoProv.SelectedIndex > -1 then
            If Not IsNothing(tabla) then
                tabla.DefaultView.RowFilter = "CONVERT(TipoProv, System.String) = '" & cmbTipoProv.SelectedValue & "'"
            End If
        Else
            If Not IsNothing(tabla) then
                tabla.DefaultView.RowFilter = String.Empty
            End If
        End If
    End Sub

    Private Sub Button4_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button4.Click
        cmbTipoProv.SelectedIndex = -1
    End Sub

    Private Sub DataGridView1_SortCompare( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DataGridView1.SortCompare
        If e.Column.Index = 0 then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button3.Click
        If cmbTipoProv.SelectedIndex > -1 then
                
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("TipoProv").Value = cmbTipoProv.SelectedValue.ToString then
                    row.Cells("Enviar").Value = "X"
                End If
            Next

        Else
                
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells("Enviar").Value = "X"
            Next

        End If
    End Sub

    Private Sub Button5_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button5.Click
        If cmbTipoProv.SelectedIndex > -1 then
                
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("TipoProv").Value = cmbTipoProv.SelectedValue.ToString then
                    row.Cells("Enviar").Value = ""
                End If
            Next

        Else
                
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells("Enviar").Value = ""
            Next

        End If
    End Sub

    Private Sub Button2_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button2.Click
        
        txtDestinatarios.Text = ""
        With ProgressBar1
            .Value=0
            .Maximum = DataGridView1.Rows.Count
            .Visible=True
        End With
        
        For Each WProveedor As DataGridViewRow In DataGridView1.Rows
            If WProveedor.Cells("Enviar").Value = "X" then
                txtDestinatarios.Text &= WProveedor.Cells("Email").Value & "; "
            End If
            ProgressBar1.Increment(1)
        Next

        ProgressBar1.Visible=False
        Button1.PerformClick

    End Sub

    Private Sub Button6_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button6.Click
        cmbTipoProv.DataSource = _CargarTipoProveedores()
        cmbTipoProv.ValueMember = "Codigo"
        cmbTipoProv.DisplayMember = "Descripcion"
        cmbTipoProv.SelectedIndex = -1
        If DataGridView1.Rows.Count = 0 then _TraerProveedoresDestinatarios()
        pnlDestinatarios.Visible = True
    End Sub
End Class