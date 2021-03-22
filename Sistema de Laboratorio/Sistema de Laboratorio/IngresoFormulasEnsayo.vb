Public Class IngresoFormulasEnsayo : Implements IGrabadoDeFormula, INotificaActualizacion
    Private ReadOnly Terminado As String
    Dim PermisoGrabar As Boolean
    Dim ForzarNuevo As Boolean
    Dim WID As String = ""
    Sub New(ByVal ID As String, ByVal Terminado As String, Optional ByVal ForzarNuevo As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Terminado = Terminado
        Me.ForzarNuevo = ForzarNuevo
        WID = ID

        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If

        If PermisoGrabar = False Then
            btnAgregar.Enabled = False
        End If

    End Sub

    Sub _GrabarFormulaMod(ByVal Formula As String, ByVal ParametrosFormula() As String, ByVal Descripcion As String, Optional ByVal Renglon As Integer = 0, Optional ByVal Moficado As Boolean = False, Optional ByVal adic1 As String = "", Optional ByVal adic2 As String = "", Optional ByVal adic3 As String = "", Optional ByVal decadic1 As String = "", Optional ByVal decadic2 As String = "", Optional ByVal decadic3 As String = "") Implements IGrabadoDeFormula._GrabarFormulaMod

        Dim listSQLCnslt As New List(Of String)

        Dim SQLCnslt As String

        If Renglon = 0 Then

            Dim WProx As DataRow = GetSingle("SELECT Renglon FROM FormulasDeEnsayos WHERE Terminado = '" & Terminado & "' ORDER BY Renglon DESC", "Surfactan_II")

            If WProx IsNot Nothing Then
                Renglon = Val(OrDefault(WProx(0), ""))
            End If

            Renglon += 1

            SQLCnslt = "INSERT INTO FormulasDeEnsayos(Terminado, Renglon, Descripcion, Formula, Var1,Var2,Var3,Var4,Var5,Var6,Var7,Var8,Var9,Var10) Values('" & Terminado & "', '" & Renglon & "', '" & Descripcion & "',"
            SQLCnslt = SQLCnslt & "'" & Formula & "', '" & ParametrosFormula(1) & "', '" & ParametrosFormula(2) & "', '" & ParametrosFormula(3) & "', '" & ParametrosFormula(4) & "',"
            SQLCnslt = SQLCnslt & "'" & ParametrosFormula(5) & "', '" & ParametrosFormula(6) & "', '" & ParametrosFormula(7) & "', '" & ParametrosFormula(8) & "'"
            SQLCnslt = SQLCnslt & ", '" & ParametrosFormula(9) & "', '" & ParametrosFormula(10) & "')"

            listSQLCnslt.Add(SQLCnslt)
        Else
            If Moficado = False Then
                SQLCnslt = "UPDATE FormulasDeEnsayos SET Descripcion = '" & Descripcion & "', Formula = '" & Formula & "', Var1 = '" & ParametrosFormula(1) & "',"
                SQLCnslt = SQLCnslt & "Var2 = '" & ParametrosFormula(2) & "',Var3 = '" & ParametrosFormula(3) & "',Var4 = '" & ParametrosFormula(4) & "',Var5 = '" & ParametrosFormula(5) & "',"
                SQLCnslt = SQLCnslt & "Var6 = '" & ParametrosFormula(6) & "',Var7 = '" & ParametrosFormula(7) & "',Var8 = '" & ParametrosFormula(8) & "',Var9 = '" & ParametrosFormula(9) & "'"
                SQLCnslt = SQLCnslt & ",Var10 = '" & ParametrosFormula(10) & "' WHERE Renglon = '" & Renglon & "' And Terminado = '" & Terminado & "'"
                listSQLCnslt.Add(SQLCnslt)
            Else
                SQLCnslt = "UPDATE FormulasDeEnsayos SET Descripcion = '" & Descripcion & "', Formula = '" & Formula & "', Var1 = '" & ParametrosFormula(1) & "',"
                SQLCnslt = SQLCnslt & "Var2 = '" & ParametrosFormula(2) & "',Var3 = '" & ParametrosFormula(3) & "',Var4 = '" & ParametrosFormula(4) & "',Var5 = '" & ParametrosFormula(5) & "',"
                SQLCnslt = SQLCnslt & "Var6 = '" & ParametrosFormula(6) & "',Var7 = '" & ParametrosFormula(7) & "',Var8 = '" & ParametrosFormula(8) & "',Var9 = '" & ParametrosFormula(9) & "'"
                SQLCnslt = SQLCnslt & ",Var10 = '" & ParametrosFormula(10) & "', EstadoVerificado = 0 , AnalistaLab = null WHERE Renglon = '" & Renglon & "' And Terminado = '" & Terminado & "'"

                listSQLCnslt.Add(SQLCnslt)

                SQLCnslt = "DELETE FROM FormulasVerificadasValores WHERE IDRenglon = '" & Renglon & "' And Terminado = '" & Terminado & "'"

                listSQLCnslt.Add(SQLCnslt)
            End If

        End If

        listSQLCnslt.Add("UPDATE FormulasDeEnsayos SET FormulaAdic1 = '" & adic1 & "', FormulaAdic2 = '" & adic2 & "', FormulaAdic3 = '" & adic3 & "', FormulaAdic1dec = '" & decadic1 & "', FormulaAdic2dec = '" & decadic2 & "', FormulaAdic3dec = '" & decadic3 & "' WHERE Terminado = '" & Terminado & "' And Renglon = '" & Renglon & "'")

        ExecuteNonQueries("Surfactan_II", listSQLCnslt.ToArray())

        'SQLCnslt = "SELECT Renglon, Descripcion, Formula FROM FormulasDeEnsayos"
        SQLCnslt = "SELECT Renglon, Descripcion, Formula , AnalistaLab, CheckVerificado = ISNULL(EstadoVerificado, 0) FROM FormulasDeEnsayos WHERE Terminado = '" & Terminado & "' Order By Renglon"

        DGV_Formulas.DataSource = GetAll(SQLCnslt, "Surfactan_II")

        _CambiarAnalistaLabXIniciales()

        SQLCnslt = "SELECT Renglon FROM FormulasDeEnsayos WHERE Descripcion = '" & Descripcion & "' AND Formula = '" & Formula & "' And Terminado = '" & Terminado & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then
            For Each DGVRow As DataGridViewRow In DGV_Formulas.Rows
                If row.Item("Renglon") = DGVRow.Cells("Renglon").Value Then
                    DGVRow.Selected = True
                    DGV_Formulas.CurrentCell = DGVRow.Cells("Descripcion")
                    Exit For
                End If
            Next
        End If


    End Sub

    Public Sub _GrabarFormula(Formula As String, ParametrosFormula As String(), Descripcion As String, Optional Renglon As Integer = 0, Optional ByVal Adic(,) As String = Nothing) Implements IGrabadoDeFormula._GrabarFormula
        Throw New NotImplementedException
    End Sub

    Private Sub IngresoFormulasEnsayo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _CargarDatos()
    End Sub

    Private Sub _CargarDatos()

        lblTerminado.Text = ""
        lblDescTerminado.Text = ""

        Dim WTerm As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & Terminado & "'")

        If WTerm Is Nothing Then
            WTerm = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & Terminado & "'")
        End If

        If WTerm Is Nothing Then Exit Sub

        lblTerminado.Text = Terminado
        lblDescTerminado.Text = Trim(OrDefault(WTerm("Descripcion"), ""))

        'Dim SQLCnslt As String = "SELECT Renglon = f.Renglon, Descripcion = f.Descripcion, Formula = f.Formula, AnalistaLab = o.Iniciales, CheckVerificado = EstadoVerificado  FROM FormulasDeEnsayos f JOIN SurfactanSa.dbo.Operador o ON f.AnalistaLab = o.Operador"
        Dim SQLCnslt As String = "SELECT Renglon, RTRIM(Upper(Descripcion)) Descripcion, RTRIM(Formula) Formula , RTRIM(AnalistaLab) AnalistaLab, CheckVerificado = ISNULL(EstadoVerificado, 0) FROM FormulasDeEnsayos WHERE Terminado = '" & Terminado & "' ORDER BY Renglon"

        Dim tabla As DataTable = GetAll(SQLCnslt, "Surfactan_II")


        DGV_Formulas.DataSource = tabla
        _CambiarAnalistaLabXIniciales()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click

        Me.Close()

    End Sub

    Private Sub _CambiarAnalistaLabXIniciales()

        For Each row As DataGridViewRow In DGV_Formulas.Rows
            Dim SQLCnslt As String

            SQLCnslt = "SELECT Iniciales FROM Operador WHERE Operador = '" & row.Cells("AnalistaLab").Value & "'"

            Dim RowOperador As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowOperador IsNot Nothing Then
                row.Cells("Analista").Value = RowOperador.Item("Iniciales")
            End If


        Next
    End Sub
    
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        With New ParametrosDeEspecificacion(Terminado, 0, PermisoGrabar)
            .ShowDialog(Me)
        End With

    End Sub

    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp

        Dim tabla As DataTable = TryCast(DGV_Formulas.DataSource, DataTable)

        tabla.DefaultView.RowFilter = "Descripcion LIKE '%" & txtBuscador.Text & "%'"

        _CambiarAnalistaLabXIniciales()

    End Sub

    Private Sub DGV_Formulas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Formulas.CellDoubleClick

        Dim _owner As IGrabadoDeFormula = TryCast(Owner, IGrabadoDeFormula)

        If _owner IsNot Nothing Then

            Dim ArrayParametros() As String = New String(11) {}
            Dim WAdic(2, 1) As String

            Dim SQLCnslt = "SELECT * FROM FormulasDeEnsayos WHERE Renglon = '" & OrDefault(DGV_Formulas.CurrentRow.Cells("Renglon").Value, 0) & "' And Terminado = '" & Terminado & "'"

            Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

            For i = 1 To 10
                ArrayParametros(i) = row.Item("Var" & i)
            Next

            For i = 1 To 3
                WAdic(i - 1, 0) = OrDefault(row.Item("FormulaAdic" & i), "")
                WAdic(i - 1, 1) = OrDefault(row.Item("FormulaAdic" & i & "dec"), "")
            Next

            _owner._GrabarFormula(row.Item("Formula"), ArrayParametros, row.Item("Descripcion"), adicionales:=WAdic)

            Me.Close()
            Exit Sub
        Else
            Dim WOwner As ITraerFormulaOtroCodigo = TryCast(Owner, ITraerFormulaOtroCodigo)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarTraerFormulaOtroCodigo(0, OrDefault(DGV_Formulas.CurrentRow.Cells("Renglon").Value, 0), Terminado)
                Me.Close()
                Exit Sub
            End If
        End If

        If e.ColumnIndex <> -1 Then
            Dim fila As Object = IIf(forzarnuevo, 0, DGV_Formulas.CurrentRow.Cells("Renglon").Value)
            With New ParametrosDeEspecificacion(Terminado, fila, PermisoGrabar)
                .Show(Me)
            End With
        End If

    End Sub

    Private Sub DGV_Formulas_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Formulas.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea eliminar esta Formula?", vbYesNo) = vbYes Then
            Dim SQLCnslt As String
            SQLCnslt = "DELETE FROM FormulasDeEnsayos WHERE Renglon = '" & DGV_Formulas.CurrentRow.Cells("Renglon").Value & "' And Terminado = '" & Terminado & "'"

            ExecuteNonQueries("Surfactan_II", SQLCnslt)

            SQLCnslt = "DELETE FROM FormulasVerificadasValores WHERE IDRenglon = '" & DGV_Formulas.CurrentRow.Cells("Renglon").Value & "' And Terminado = '" & Terminado & "'"

            ExecuteNonQueries("Surfactan_II", SQLCnslt)


            SQLCnslt = "SELECT Renglon, Descripcion, Formula , AnalistaLab, CheckVerificado = ISNULL(EstadoVerificado, 0) FROM FormulasDeEnsayos WHERE Terminado = '" & Terminado & "' ORDER BY Renglon"
            'SQLCnslt = "SELECT Renglon, Descripcion, Formula FROM FormulasDeEnsayos"

            DGV_Formulas.DataSource = GetAll(SQLCnslt, "Surfactan_II")

            _CambiarAnalistaLabXIniciales()
        End If
    End Sub

    Public Sub _ProcesarNotificaActualizacion() Implements INotificaActualizacion._ProcesarNotificaActualizacion
        _CargarDatos()
    End Sub

    Private Sub btnPlanillaValidaciones_Click(sender As Object, e As EventArgs) Handles btnPlanillaValidaciones.Click

        If DGV_Formulas.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un ensayo para imprimir la planilla.", MsgBoxStyle.Information)
            Exit Sub
        End If
        
        With New ImprePlanillaValidaciones(lblTerminado.Text, DGV_Formulas.SelectedRows(0).Cells("Renglon").Value)
            .Show(Me)
        End With
    End Sub
End Class