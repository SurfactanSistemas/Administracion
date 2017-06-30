Public Enum ValidatorType
    None = 0
    NotEmpty
    Numeric
    Positive
    PositiveWithMax
    DateFormat
    PositiveFloat
    Float
    StrictlyPositiveFloat
End Enum

Public Enum NumericType
    None = 0
    ShortType
    IntegerType
    LongType
    DoubleType
    FloatType
End Enum

Public Interface CustomControl
    Property EnterIndex() As Integer
    Property Cleanable() As Boolean
    Property LabelAssociationKey() As Integer
End Interface

Public Interface ValidableControl
    Property Validator As ValidatorType
    Property Empty As Boolean
End Interface

'TextBox
Public Class CustomTextBox
    Inherits TextBox
    Implements CustomControl, ValidableControl

    Private customIndex As Integer = -1
    Private cleanStatus As Boolean = False
    Private emptyPermitted As Boolean = True
    Private validatorConstant As ValidatorType = ValidatorType.None
    Private associationKey As Integer = -1

    Private Function getEnterIndex() As Integer
        Return customIndex
    End Function

    Private Sub setEnterIndex(ByVal anIndex As Integer)
        customIndex = anIndex
    End Sub

    Private Function getCleanStatus() As Integer
        Return cleanStatus
    End Function

    Private Sub setCleanStatus(ByVal status As Integer)
        cleanStatus = status
    End Sub

    Private Function getEmptyPermitted() As Boolean
        Return emptyPermitted
    End Function

    Private Sub setEmptyPermitted(ByVal value As Boolean)
        emptyPermitted = value
    End Sub

    Private Function getValidatorType() As Integer
        Return validatorConstant
    End Function

    Private Sub setValidatorType(ByVal type As Integer)
        validatorConstant = type
    End Sub

    Private Function getAssociationKey() As Integer
        Return associationKey
    End Function

    Private Sub setAssociationKey(ByVal key As Integer)
        associationKey = key
    End Sub

    Public Property EnterIndex() As Integer Implements CustomControl.EnterIndex
        Get
            Return CType(getEnterIndex(), Integer)
        End Get
        Set(ByVal value As Integer)
            setEnterIndex(value)
        End Set
    End Property

    Public Property Cleanable() As Boolean Implements CustomControl.Cleanable
        Get
            Return CType(getCleanStatus(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setCleanStatus(value)
        End Set
    End Property

    Public Property Empty() As Boolean Implements ValidableControl.Empty
        Get
            Return CType(getEmptyPermitted(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setEmptyPermitted(value)
        End Set
    End Property

    Public Property Validator() As ValidatorType Implements ValidableControl.Validator
        Get
            Return CType(getValidatorType(), ValidatorType)
        End Get
        Set(ByVal value As ValidatorType)
            setValidatorType(value)
        End Set
    End Property

    Public Property LabelAssociationKey() As Integer Implements CustomControl.LabelAssociationKey
        Get
            Return CType(getAssociationKey(), Integer)
        End Get
        Set(ByVal value As Integer)
            setAssociationKey(value)
        End Set
    End Property
End Class


'ComboBox
Public Class CustomComboBox
    Inherits ComboBox
    Implements CustomControl, ValidableControl

    Private customIndex As Integer = -1
    Private cleanStatus As Boolean = False
    Private emptyPermitted As Boolean
    Private validatorConstant As ValidatorType = ValidatorType.None
    Private associationKey As Integer = -1

    Private Function getEnterIndex() As Integer
        Return customIndex
    End Function

    Private Sub setEnterIndex(ByVal anIndex As Integer)
        customIndex = anIndex
    End Sub

    Private Function getCleanStatus() As Integer
        Return cleanStatus
    End Function

    Private Sub setCleanStatus(ByVal status As Integer)
        cleanStatus = status
    End Sub

    Private Function getEmptyPermitted() As Boolean
        Return emptyPermitted
    End Function

    Private Sub setEmptyPermitted(ByVal value As Boolean)
        emptyPermitted = value
    End Sub

    Private Function getValidatorType() As Integer
        Return validatorConstant
    End Function

    Private Sub setValidatorType(ByVal type As Integer)
        validatorConstant = type
    End Sub

    Private Function getAssociationKey() As Integer
        Return associationKey
    End Function

    Private Sub setAssociationKey(ByVal key As Integer)
        associationKey = key
    End Sub

    Public Property EnterIndex() As Integer Implements CustomControl.EnterIndex
        Get
            Return CType(getEnterIndex(), Integer)
        End Get
        Set(ByVal value As Integer)
            setEnterIndex(value)
        End Set
    End Property

    Public Property Cleanable() As Boolean Implements CustomControl.Cleanable
        Get
            Return CType(getCleanStatus(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setCleanStatus(value)
        End Set
    End Property

    Public Property Empty() As Boolean Implements ValidableControl.Empty
        Get
            Return CType(getEmptyPermitted(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setEmptyPermitted(value)
        End Set
    End Property

    Public Property Validator() As ValidatorType Implements ValidableControl.Validator
        Get
            Return CType(getValidatorType(), ValidatorType)
        End Get
        Set(ByVal value As ValidatorType)
            setValidatorType(value)
        End Set
    End Property

    Public Property LabelAssociationKey() As Integer Implements CustomControl.LabelAssociationKey
        Get
            Return CType(getAssociationKey(), Integer)
        End Get
        Set(ByVal value As Integer)
            setAssociationKey(value)
        End Set
    End Property
End Class

'ListBox
Public Class CustomListBox
    Inherits ListBox
    Implements CustomControl

    Private customIndex As Integer = -1
    Private cleanStatus As Boolean = False
    Private associationKey As Integer = -1

    Private Function getEnterIndex() As Integer
        Return customIndex
    End Function

    Private Sub setEnterIndex(ByVal anIndex As Integer)
        customIndex = anIndex
    End Sub

    Private Function getCleanStatus() As Integer
        Return cleanStatus
    End Function

    Private Sub setCleanStatus(ByVal status As Integer)
        cleanStatus = status
    End Sub

    Private Function getAssociationKey() As Integer
        Return associationKey
    End Function

    Private Sub setAssociationKey(ByVal key As Integer)
        associationKey = key
    End Sub

    Public Property EnterIndex() As Integer Implements CustomControl.EnterIndex
        Get
            Return CType(getEnterIndex(), Integer)
        End Get
        Set(ByVal value As Integer)
            setEnterIndex(value)
        End Set
    End Property

    Public Property Cleanable() As Boolean Implements CustomControl.Cleanable
        Get
            Return CType(getCleanStatus(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setCleanStatus(value)
        End Set
    End Property

    Public Property LabelAssociationKey() As Integer Implements CustomControl.LabelAssociationKey
        Get
            Return CType(getAssociationKey(), Integer)
        End Get
        Set(ByVal value As Integer)
            setAssociationKey(value)
        End Set
    End Property
End Class

'Button
Public Class CustomButton
    Inherits Button
    Implements CustomControl

    Private customIndex As Integer = -1
    Private cleanStatus As Boolean = False
    Private associationKey As Integer = -1

    Private Function getEnterIndex() As Integer
        Return customIndex
    End Function

    Private Sub setEnterIndex(ByVal anIndex As Integer)
        customIndex = anIndex
    End Sub

    Private Function getCleanStatus() As Integer
        Return cleanStatus
    End Function

    Private Sub setCleanStatus(ByVal status As Integer)
        cleanStatus = status
    End Sub

    Private Function getAssociationKey() As Integer
        Return associationKey
    End Function

    Private Sub setAssociationKey(ByVal key As Integer)
        associationKey = key
    End Sub

    Public Property EnterIndex() As Integer Implements CustomControl.EnterIndex
        Get
            Return CType(getEnterIndex(), Integer)
        End Get
        Set(ByVal value As Integer)
            setEnterIndex(value)
        End Set
    End Property

    Public Property Cleanable() As Boolean Implements CustomControl.Cleanable
        Get
            Return CType(getCleanStatus(), Boolean)
        End Get
        Set(ByVal value As Boolean)
            setCleanStatus(value)
        End Set
    End Property

    Public Property LabelAssociationKey() As Integer Implements CustomControl.LabelAssociationKey
        Get
            Return CType(getAssociationKey(), Integer)
        End Get
        Set(ByVal value As Integer)
            setAssociationKey(value)
        End Set
    End Property
End Class


'Label
Public Class CustomLabel
    Inherits Label

    Private associationKey As Integer = -1

    Private Function getAssociationKey() As Integer
        Return associationKey
    End Function

    Private Sub setAssociationKey(ByVal key As Integer)
        associationKey = key
    End Sub

    Public Property ControlAssociationKey() As Integer
        Get
            Return CType(getAssociationKey(), Integer)
        End Get
        Set(ByVal value As Integer)
            setAssociationKey(value)
        End Set
    End Property
End Class