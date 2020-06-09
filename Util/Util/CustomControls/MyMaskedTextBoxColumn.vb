Imports Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn

Public Class MyMaskedTextBoxColumn : Inherits MaskedTextBoxColumn

    Public Overrides Function Clone() As Object
        Dim col As MyMaskedTextBoxColumn = CType(MyBase.Clone(), MyMaskedTextBoxColumn)
        With col
            .Mask = Mask
            .PromptChar = " "
            .IncludePrompt = True
            .IncludeLiterals = True
        End With

        Return col
    End Function

End Class
