Imports ConsultasVarias.Clases

Public Class DBDataGridView : Inherits DataGridView

    Public Overloads Property DoubleBuffered() As Boolean
        Get
            Return MyBase.DoubleBuffered
        End Get
        Set(ByVal value As Boolean)
            MyBase.DoubleBuffered = value
        End Set
    End Property

    Sub New()
        MyBase.DoubleBuffered = True
        MyBase.RowHeadersWidth = 15
        MyBase.RowTemplate.Height = 20

        DefaultCellStyle.BackColor = Globales.WBackColorSecundario
        DefaultCellStyle.SelectionBackColor = Globales.WBackColorTerciario
        DefaultCellStyle.SelectionForeColor = Color.White
        EditMode = DataGridViewEditMode.EditOnEnter
        ShowCellToolTips = False

        AddHandler MyBase.MouseDown, AddressOf MyBase_MouseDown
    End Sub

    Public Sub InhabilitarOrdenamientoColumnas()
        For Each column As DataGridViewColumn In Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Public Sub CopiarSeleccion(Optional ByVal IncluirCabeceras As Boolean = False)

        ClipboardCopyMode = IIf(IncluirCabeceras, DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText, DataGridViewClipboardCopyMode.EnableWithoutHeaderText)

        RowHeadersVisible = False

        Dim WData As Object = MyBase.GetClipboardContent()
        If WData IsNot Nothing Then Clipboard.SetDataObject(WData)

        RowHeadersVisible = True

    End Sub

    Public Overridable Sub MyBase_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        With CType(sender, DataGridView)
            If e.Button = MouseButtons.Right Then
                If .SelectedRows.Count > 1 Then Exit Sub

                Dim WHit As HitTestInfo = .HitTest(e.X, e.Y)

                If WHit.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(WHit.RowIndex).Cells(WHit.ColumnIndex)
                End If

            End If
        End With
    End Sub

End Class
