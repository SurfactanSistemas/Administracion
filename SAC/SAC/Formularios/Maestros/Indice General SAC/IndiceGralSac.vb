Public Class IndiceGralSac

    Private Sub IndiceGralSac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarTiposSolicitud()
        _CargarEmisores()
        ' _CargarResponsables()
        _CargarCentros()
    End Sub

    Private Sub _CargarResponsables()
        'Throw New NotImplementedException
    End Sub

    Private Sub _CargarCentros()
        Dim WCentros As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM CentroSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        CType(clbCentros, ListBox).DataSource = WCentros
        CType(clbCentros, ListBox).DisplayMember = "Descripcion"
        CType(clbCentros, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarEmisores()
        Dim WEmisores As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        CType(clbEmisores, ListBox).DataSource = WEmisores
        CType(clbEmisores, ListBox).DisplayMember = "Descripcion"
        CType(clbEmisores, ListBox).ValueMember = "Codigo"

        Dim WResponsables As DataTable = WEmisores.Copy

        CType(clbResponsables, ListBox).DataSource = WResponsables
        CType(clbResponsables, ListBox).DisplayMember = "Descripcion"
        CType(clbResponsables, ListBox).ValueMember = "Codigo"

    End Sub

    Private Sub _CargarTiposSolicitud()
        Dim WTipos As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac ORDER BY Descripcion")

        CType(clbTiposSolicitud, ListBox).DataSource = WTipos
        CType(clbTiposSolicitud, ListBox).DisplayMember = "Descripcion"
        CType(clbTiposSolicitud, ListBox).ValueMember = "Codigo"

        'For Each row As datarow In WTipos.Rows
        '    With row
        '        clbTiposSolicitud.Items.Add(.Item("Descripcion"))
        '    End With
        'Next
        
    End Sub
    
    Private Sub clbEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbEstados.Click

        'For i As Integer = 0 To clbEstados.Items.Count - 1
        '    clbEstados.SetItemChecked(i, True)
        '    MsgBox(clbEstados.GetItemCheckState(i))
        'Next

    End Sub

    Private Sub clbEstados_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbEstados.MouseUp
        With clbEstados
            If .SelectedIndex = 0 Then
                For i As Integer = 1 To .Items.Count - 1

                    If .GetItemCheckState(0) = CheckState.Checked Then
                        .SetItemChecked(i, True)
                    Else
                        .SetItemChecked(i, False)
                    End If

                Next
            Else
                .SetItemChecked(0, False)
            End If
        End With
    End Sub

    Private Sub clbOrigenes_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbOrigenes.MouseUp
        With clbOrigenes
            If .SelectedIndex = 0 Then
                For i As Integer = 1 To .Items.Count - 1

                    If .GetItemCheckState(0) = CheckState.Checked Then
                        .SetItemChecked(i, True)
                    Else
                        .SetItemChecked(i, False)
                    End If

                Next
            Else
                .SetItemChecked(0, False)
            End If
        End With
    End Sub
End Class