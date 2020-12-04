Public Class IngresoFrasesH : Implements IFrasesHP
    ReadOnly FRASE As String

    Dim PermisoGrabar As Boolean
    Sub New(ByVal TipoFrase As String, ByVal ID As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim SQLCnslt As String
        FRASE = TipoFrase
        If TipoFrase = "H" Then
            LblTitulo.Text = "Frases H"
            SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseH"

        Else
            LblTitulo.Text = "Frases P"
            SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseP"

        End If

        Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSA")

        DGV_Frases.DataSource = tabla

        SQLCnslt = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If

    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp

        Dim tabla As DataTable = TryCast(DGV_Frases.DataSource, DataTable)

        tabla.DefaultView.RowFilter = "Codigo like '%" & txtBuscador.Text & "%' OR Descripcion Like '%" & txtBuscador.Text & "%' OR Observaciones Like '%" & txtBuscador.Text & "%'"
    End Sub

    Private Sub DGV_Frases_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Frases.RowHeaderMouseDoubleClick
        Dim SQLCnslt As String
        If PermisoGrabar Then
            If (MsgBox("¿Desea borrar la frase " & DGV_Frases.CurrentRow.Cells("Codigo").Value & "?", vbYesNo) = vbYes) Then

                If (FRASE = "H") Then
                    SQLCnslt = "DELETE  FROM FraseH WHERE Codigo = '" & DGV_Frases.CurrentRow.Cells("Codigo").Value & "'"
                Else
                    SQLCnslt = "DELETE  FROM Frasep WHERE Codigo = '" & DGV_Frases.CurrentRow.Cells("Codigo").Value & "' "
                End If

                ExecuteNonQueries("SurfactanSA", SQLCnslt)

                If FRASE = "H" Then
                    LblTitulo.Text = "Frases H"
                    SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseH"


                Else
                    LblTitulo.Text = "Frases P"
                    SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseP"

                End If

                Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSA")

                DGV_Frases.DataSource = tabla


            End If
        End If
        
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        With New VistaPrevia
            .Base = "SurfactanSA"
            If (FRASE = "H") Then
                .Reporte = New ReporteListadoFrasesH()
            Else
                .Reporte = New ReporteListadosP()
            End If
            .Mostrar()
        End With
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAgregarFrase_Click(sender As Object, e As EventArgs) Handles btnAgregarFrase.Click
        With New CargaDatosFrases(FRASE)
            .Show(Me)
        End With
    End Sub

    Public Sub ProcesarFrases() Implements IFrasesHP.ProcesarFrases
        Dim SQLCnslt As String
        If FRASE = "H" Then

            SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseH"


        Else
            SQLCnslt = "SELECT Codigo, Descripcion = RTRIM(LTRIM(Descripcion)) + ' ' + RTRIM(LTRIM(DescripcionII)) + ' ' + RTRIM(LTRIM(DescripcionIII)), Observaciones = Observa FROM FraseP"

        End If

        Dim tabla As DataTable = GetAll(SQLCnslt, "SurfactanSA")

        DGV_Frases.DataSource = tabla
    End Sub

    Private Sub txtAccesoRapido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccesoRapido.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                For Each Row As DataGridViewRow In DGV_Frases.Rows
                    With Row
                        If Trim(UCase(.Cells("Codigo").Value)) = Trim(UCase(txtAccesoRapido.Text)) Then
                            With New CargaDatosFrases(FRASE, .Cells("Codigo").Value, .Cells("Descripcion").Value, .Cells("Observaciones").Value, PermisoGrabar)
                                .Show(Me)
                            End With
                        End If
                    End With
                Next
        End Select
    End Sub
    
    Private Sub DGV_Frases_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Frases.CellMouseDoubleClick
        If e.ColumnIndex <> -1 Then
            With New CargaDatosFrases(FRASE, DGV_Frases.CurrentRow.Cells("Codigo").Value, DGV_Frases.CurrentRow.Cells("Descripcion").Value, DGV_Frases.CurrentRow.Cells("Observaciones").Value, PermisoGrabar)
                .Show(Me)
            End With
        End If
    End Sub

    Private Sub IngresoFrasesH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PermisoGrabar = False Then
            btnAgregarFrase.Enabled = False
        End If
    End Sub
End Class