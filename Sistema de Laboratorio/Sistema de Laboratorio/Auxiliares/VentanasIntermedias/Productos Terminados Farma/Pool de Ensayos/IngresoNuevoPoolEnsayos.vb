Public Class IngresoNuevoPoolEnsayos

    Private Datos As DataGridViewRow
    Private Partida, Etapa, RenglonRef As String

    Sub New(ByVal Datos As DataGridViewRow, ByVal Partida As String, ByVal Etapa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Datos = Datos
        Me.Partida = Partida
        Me.Etapa = Etapa
        Me.RenglonRef = Datos.Index + 1
        lblDescEnsayo.Text = Datos.Cells("Descripcion").Value
        lblParametros.Text = Datos.Cells("Parametro").Value
    End Sub

    Sub New(ByVal RenglonRef As Integer, ByVal DescEnsayo As String, ByVal Parametro As String, ByVal Partida As String, ByVal Etapa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Datos = Datos
        Me.Partida = Partida
        Me.Etapa = Etapa
        Me.RenglonRef = RenglonRef

        lblDescEnsayo.Text = DescEnsayo
        lblParametros.Text = Parametro

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub IngresoNuevoPoolEnsayos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WPooles As DataTable = GetAll("SELECT * FROM PrueterPoolEnsayos WHERE RenglonEnsayos = '" & RenglonRef & "' And Partida = '" & Partida & "' And Etapa = '" & Etapa & "' ORDER BY Renglon")

        For Each row As Datarow In WPooles.Rows
            With row
                dgvPooles.Rows.Add(.Item("Descripcion"), .Item("Valor"), .Item("Observaciones"))
            End With
        Next

        dgvPooles.Rows.Add("", "", "")

        dgvPooles.CurrentCell = dgvPooles.Rows(0).Cells(0)
        dgvPooles.Focus()

    End Sub




    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvPooles
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor As String = OrDefault(.CurrentCell.Value, "")

                '' Limitamos los caracteres permitidos para cada una de las columnas.
                'Select Case iCol
                '    Case 1
                '        If Not _EsNumeroOControl(keyData) Then
                '            Return True
                '        End If
                '    Case 4
                '        If Not _EsDecimalOControl(keyData) Then
                '            Return True
                '        End If
                '    Case Else

                'End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Select Case iCol
                        Case 2

                            If .Rows.Count <= iRow + 1 Then .Rows.Add()

                            .CurrentCell = .Rows(iRow + 1).Cells(0)

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""

                    If iCol = 2 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim WDescripcion, WValor, WObservacion As String

        ' Comprobamos que no hayan valores sin designar un nombre de Pool.
        For Each row As DataGridViewRow In dgvPooles.Rows
            With row
                WDescripcion = Trim(OrDefault(.Cells("Descripcion").Value, ""))
                WValor = Trim(OrDefault(.Cells("Valor").Value, ""))
                WObservacion = Trim(OrDefault(.Cells("Observacion").Value, ""))

                If WDescripcion = "" And WValor <> "" Then
                    MsgBox("Hay Valores que no tienen designado un nombre de Pool.")
                    Exit Sub
                End If
            End With
        Next

        '
        ' Grabamos los datos que nos indicaron.
        '
        Dim WClave As String
        Dim WSqls As New List(Of String)
        WSqls.Add("DELETE FROM PrueterPoolEnsayos WHERE Partida = '" & Partida & "' And Etapa = '" & Etapa & "' And RenglonEnsayos = '" & RenglonRef & "'")
        For Each row As DataGridViewRow In dgvPooles.Rows
            With row
                WDescripcion = Trim(OrDefault(.Cells("Descripcion").Value, ""))
                WValor = Trim(OrDefault(.Cells("Valor").Value, ""))
                WObservacion = Trim(OrDefault(.Cells("Observacion").Value, ""))

                If WDescripcion <> "" And WValor <> "" Then

                    WClave = Partida.PadLeft(6, "0") & Etapa.PadLeft(2, "0") & RenglonRef.PadLeft(2, "0") & (row.Index + 1).ToString.PadLeft(2, "0")

                    WSqls.Add(String.Format("INSERT INTO PrueterPoolEnsayos (Clave, Partida, Etapa, RenglonEnsayos, Renglon, Descripcion, Valor, Observaciones) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", WClave, Partida, Etapa, RenglonRef, row.Index + 1, WDescripcion, WValor, WObservacion))

                End If
            End With
        Next

        If WSqls.Count > 0 Then
            ExecuteNonQueries(WSqls.ToArray)
        End If

        DialogResult = Windows.Forms.DialogResult.OK

        Close()

    End Sub

    Private Sub dgvPooles_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPooles.RowHeaderMouseDoubleClick
        If e.RowIndex < -1 Then Exit Sub

        If MsgBox("¿Está seguro de querer eliminar la fila?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            dgvPooles.Rows.Remove(dgvPooles.CurrentRow)

            If dgvPooles.Rows.Count > 0 Then
                If Trim(OrDefault(dgvPooles.Rows(dgvPooles.Rows.Count - 1).Cells(0).Value, "")) <> "" Then
                    dgvPooles.Rows.Add("", "", "")
                End If
            ElseIf dgvPooles.Rows.Count = 0 Then
                dgvPooles.Rows.Add("", "", "")
            End If

        End If

    End Sub
End Class