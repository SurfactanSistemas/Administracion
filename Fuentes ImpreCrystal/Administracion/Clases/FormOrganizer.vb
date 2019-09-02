Imports System.IO
Imports System.Text

Public Delegate Function QueryFunction(ByVal text As String)
Public Delegate Sub ShowMethod(ByVal selectedValue)
Public Delegate Function RowToObject(ByVal row As DataRow)

Public Class FormOrganizer

    Private form As Form
    Private maxHeight As Integer
    Private width As Integer
    Private queryFunctions As New List(Of Tuple(Of QueryFunction, String, ShowMethod, String))
    Private queryFunction As QueryFunction
    Private queryText As CustomTextBox
    Private queryList As CustomListBox
    Private selectionList As CustomListBox
    Private allControls As New List(Of CustomControl)
    Private firstColumnControls As New List(Of CustomControl)
    Private columnedControls As List(Of Object)
    Private compactedControls As List(Of Object)
    Private compactedFirstColumnControls As New List(Of CustomControl)
    Private annexedControls As New List(Of CustomControl)
    Private buttons As New List(Of CustomButton)
    Private buttonsTop As New List(Of CustomButton)
    Private buttonsBottom As New List(Of CustomButton)
    Private btnAddClick As EventHandler
    Private btnDeleteClick As EventHandler
    Private btnCleanClick As EventHandler
    Private btnQueryClick As EventHandler
    Private btnListClick As EventHandler
    Private btnCloseClick As EventHandler
    Private showMethodFunction As ShowMethod
    Private usingQueryText As Boolean = True
    Private usingControllerButtons As Boolean = True
    Private organizingCompactedControls As Boolean = False
    Private isCompact As Boolean = False
    Private isCRUDForm As Boolean = True
    Private usingCancelButton As Boolean = True

    Private buttonsWidth As Integer
    Private formNormalHeight As Integer
    Private formNeededHeight As Integer
    Private formWithQueryControlsHeight As Integer
    Private formWithSelectionListHeight As Integer
    Private topMargin As Integer = 30
    Private leftMargin As Integer = 30
    Private rightMargin As Integer = 30
    Private bottomMargin As Integer = 30
    Private separation As Integer = 6
    Private actionButtonHeight As Integer = 35
    Private listQueryHeight As Integer = 160
    Private containerHeight As Integer
    Private containerWidth As Integer
    Private separationBetweenControlsAndButtons As Integer = 45
    Private controlSeparation As Integer = 10
    Private charPixelSize As Double = 7.5
    Private compactHeightConstant As Integer = 0
    Private filePath As String
    Private realButtonsTop As Integer
    Private getProcedureName As String
    Private fromRowToObjectFunction As RowToObject
    Private fromRowShowFunction As ShowMethod

    Public Sub New(ByVal someForm As Form, ByVal formWidth As Integer, ByVal formHeight As Integer)
        form = someForm
        maxHeight = formHeight
        width = formWidth
        buttonsWidth = width - leftMargin - rightMargin
    End Sub

    Public Sub createControlsFile()
        Dim folderPath As String = Application.StartupPath & "\FormsOrg\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Try
            Dim fileStream As FileStream = File.Create(filePath)

            Dim stringToWrite As String = "'name-height-width-left-top. Last line reserved for buttons top" & vbCrLf
            For Each customControl In allControls
                Dim control As Control = DirectCast(customControl, Control)
                stringToWrite = stringToWrite & control.Name & vbCrLf & control.Height & vbCrLf & control.Width & vbCrLf & _
                    control.Left & vbCrLf & control.Top & vbCrLf

                Dim label As CustomLabel = labelFor(customControl.LabelAssociationKey)
                If Not IsNothing(label) Then
                    stringToWrite = stringToWrite & label.Name & vbCrLf & label.Height & vbCrLf & label.Width & vbCrLf & _
                    label.Left & vbCrLf & label.Top & vbCrLf
                End If

                For Each annexedCustomControl In annexedControlsFor(customControl.LabelAssociationKey)
                    Dim annexedControl As Control = DirectCast(annexedCustomControl, Control)
                    stringToWrite = stringToWrite & annexedControl.Name & vbCrLf & annexedControl.Height & vbCrLf & annexedControl.Width & vbCrLf & _
                    annexedControl.Left & vbCrLf & annexedControl.Top & vbCrLf
                Next
            Next

            stringToWrite = stringToWrite & realButtonsTop
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(stringToWrite)
            fileStream.Write(info, 0, info.Length)
            fileStream.Close()

        Catch ex As Exception
            File.Delete(filePath)

            createControlsFile()
        End Try

    End Sub

    Public Sub addControls(ByVal ParamArray controlsColumn() As Object)
        addControls(columnedControls, firstColumnControls, controlsColumn)
    End Sub

    Public Sub addCompactedControls(ByVal ParamArray controlsColumn() As Object)
        addControls(compactedControls, compactedFirstColumnControls, controlsColumn)
    End Sub

    Private Sub addControls(ByRef objectsCollection As List(Of Object), ByVal firstColumnCollection As List(Of CustomControl), ByVal ParamArray controlsColumn() As Object)
        objectsCollection = controlsColumn.ToList
        For Each control In objectsCollection
            If control.GetType.GetInterface(GetType(CustomControl).Name) = GetType(CustomControl) Then
                firstColumnCollection.Add(control)
                allControls.Add(control)
            Else
                Dim listOfControls As List(Of Control) = castToListOfControl(DirectCast(control, Object()))
                firstColumnCollection.Add(listOfControls.First)
                listOfControls.ForEach(Sub(aControl) allControls.Add(DirectCast(aControl, CustomControl)))
            End If
        Next
    End Sub

    Public Sub addAnnexedControls(ByVal someControls As List(Of CustomControl))
        annexedControls = someControls
        annexedControls.OrderBy(Function(control) control.LabelAssociationKey)
    End Sub

    Private Function controlsHeight()
        Return firstColumnControls.Sum(Function(control As CustomControl) DirectCast(control, Control).Height) + (firstColumnControls.Count - 1) * controlSeparation
    End Function

    Private Function buttonsHeight()
        Return actionButtonHeight * 2 + separation 'Las dos filas de botones + separation entre botones
    End Function

    Private Function notCRUDButtonsHeight()
        Return actionButtonHeight
    End Function

    Private Function calculateFormNormalHeight()
        Dim height As Integer = topMargin + bottomMargin + controlsHeight() + compactHeightConstant
        If isCRUDForm Then
            height += separationBetweenControlsAndButtons + buttonsHeight()
        Else
            height += notCRUDButtonsHeight() + separationBetweenControlsAndButtons
        End If
        Return height
    End Function

    Private Function calculateFormNeededHeight()
        If isCompact Then
            If Not isCRUDForm Then : Throw New ApplicationException("No deberías tener una ventana que no es ABM con formato compacto")
            End If
            Return formNormalHeight + compactedFirstColumnControls.Sum(Function(control As CustomControl) DirectCast(control, Control).Height) + (compactedFirstColumnControls.Count - 1) * controlSeparation - buttonsHeight()
        Else
            Return formNormalHeight
        End If
    End Function

    Private Function recalculateFormNeededHeight()
        If isCompact Then
            If Not isCRUDForm Then : Throw New ApplicationException("No deberías tener una ventana que no es ABM con formato compacto")
            End If
            Return formNormalHeight + compactedFirstColumnControls.Sum(Function(control As CustomControl) DirectCast(control, Control).Height) + (compactedFirstColumnControls.Count - 1) * controlSeparation - buttonsHeight()
        Else
            Return formNormalHeight + containerHeight - buttonsHeight()
        End If
    End Function

    Private Function calculateFormWithQueryControlsHeight()
        If isCRUDForm Then
            Dim height As Integer = formNormalHeight + separation + queryList.Height
            If usingQueryText Then
                height += separation + queryTextHeight()
            End If
            Return height
        Else
            Return formNormalHeight
        End If
    End Function

    Private Function calculateFormWithSelectionListHeight()
        If isCRUDForm Then
            Return formNormalHeight + separation + selectionListHeight
        Else
            Return formNormalHeight
        End If
    End Function

    Public Sub organize()
        Dim left As Integer

        formNormalHeight = calculateFormNormalHeight()
        formNeededHeight = calculateFormNeededHeight()

        form.Height = Math.Min(maxHeight, formNeededHeight)
        form.Width = width

        filePath = Application.StartupPath & "\FormsOrg\" & form.Name & ".txt"

        Dim btnsTop As Integer = organizeControls() + separationBetweenControlsAndButtons
        realButtonsTop = btnsTop - separationBetweenControlsAndButtons 'Se hace esto ya que se debe guardar el valor sin la suma del separation
        Dim commonEventsHandler As New CommonEventsHandler
        If isCRUDForm Then
            commonEventsHandler.setIndexTab(form)
            left = organizeButtons(btnsTop)
            organizeQueryControllers(btnsTop + buttonsHeight())
            If usingControllerButtons Then
                addControlerButtons(btnsTop, left)
            End If
            formWithSelectionListHeight = calculateFormWithSelectionListHeight()
            formWithQueryControlsHeight = calculateFormWithQueryControlsHeight()
        Else
            commonEventsHandler.setIndexTabNotCRUDForm(form)
            organizeNotCRUDButtons(btnsTop)
        End If
        createControlsFile()
    End Sub

    Public Sub organizeForNotCRUDForm()
        isCRUDForm = False
        organize()
    End Sub

    Public Sub compactOrganize()
        topMargin = 10
        bottomMargin = 10
        leftMargin = 20
        actionButtonHeight = 25
        separationBetweenControlsAndButtons = 10
        controlSeparation = separation
        compactHeightConstant = 30
        buttonsWidth = buttonsWidth \ 2
        isCompact = True
        organize()
    End Sub

    Private Function organizeControls()
        Dim top As Integer = topMargin

        If File.Exists(filePath) Then
            top = organizeControlsFromFile()
        Else
            top = organizeControls(top, leftMargin, columnedControls)
            If isCompact Then
                organizingCompactedControls = True
                organizeCompactedControls(top + separationBetweenControlsAndButtons)
                organizingCompactedControls = False
            End If
        End If
        Return top
    End Function

    Private Function organizeControlsFromFile()
        Dim reader As New StreamReader(filePath)
        Dim lines = reader.ReadToEnd.Split(Environment.NewLine.ToCharArray()).ToList
        lines.RemoveAll(Function(value) value = "")

        For index As Integer = 1 To lines.Count - 2 Step 5
            Dim control As Control = form.Controls(lines(index))
            control.Height = lines(index + 1)
            control.Width = lines(index + 2)
            control.Left = lines(index + 3)
            control.Top = lines(index + 4)
        Next
        reader.Close()
        Return Convert.ToInt32(lines.Last) 'La última línea está reservada para el top de los buttons
    End Function

    Private Sub organizeCompactedControls(ByVal top As Integer)
        organizeControls(top, leftMargin + buttonsWidth + separation, compactedControls)
    End Sub

    Private Function organizeControls(ByVal top As Integer, ByVal realLeftMargin As Integer, ByVal collectionOfControls As List(Of Object))
        'Setteo el top y el left de los controls y labels
        For Each castControl As Object In collectionOfControls
            If castControl.GetType.GetInterface(GetType(CustomControl).Name) = GetType(CustomControl) Then
                top = organizeSimpleControl(castControl, top, realLeftMargin)
            Else
                top = organizeColumnControl(castControl, top, realLeftMargin)
            End If
        Next
        Return top - topMargin
    End Function

    Private Function organizeSimpleControl(ByVal castControl As Control, ByVal top As Integer, ByVal realLeftMargin As Integer)
        'EXCLUSIVO CONTROLES SIN COLUMNAS
        Dim left As Integer = realLeftMargin
        Dim control As CustomControl = DirectCast(castControl, CustomControl)

        setLabelTopFor(control.LabelAssociationKey, top)
        setLabelLeftFor(control.LabelAssociationKey, realLeftMargin)

        left += separation + maxLabelWidth() 'Se cambia el left para el próximo control

        castControl.Top = top - 3
        castControl.Left = left

        Dim maxWidth As Integer = maxWidthForColumnControls(New List(Of Control) From {castControl})
        Dim widthPercentage As Double = widthPercentageForColumnControls(New List(Of Control) From {castControl})
        castControl.Width = maxWidthFor(control, 0, maxWidth, widthPercentage)

        left += castControl.Width + separation

        Dim annexedCustomControls = annexedControlsFor(control.LabelAssociationKey)
        For Each annexedCustomControl As CustomControl In annexedCustomControls
            Dim annexedControl As Control = DirectCast(annexedCustomControl, Control)
            annexedControl.Top = top - 3
            annexedControl.Left = left
            annexedControl.Width = maxWidthFor(annexedCustomControl, -1, maxWidth, widthPercentage)
            left += annexedControl.Width + separation
        Next

        Return top + castControl.Height + controlSeparation
    End Function

    Private Function maxWidthFor(ByVal control As CustomControl, ByVal columnNumber As Integer, ByVal maxWidth As Integer, ByVal widthPercentage As Double)
        If variableWidthFor(control, columnNumber) > maxWidth Then
            Return maxWidth 'variableWidthFor(control, columnNumber) - variableWidthFor(control, columnNumber) * widthPercentage TODO
        Else
            Return variableWidthFor(control, columnNumber)
        End If
    End Function

    Private Function organizeColumnControl(ByVal castControl As Object, ByVal top As Integer, ByVal realLeftMargin As Integer)
        'EXCLUSIVO PARA CONTROLS ENCOLUMNADOS
        Dim left As Integer = realLeftMargin
        Dim controlList As List(Of Control) = castToListOfControl(castControl)
        Dim maxWidth As Integer = maxWidthForColumnControls(controlList)
        Dim widthPercentage As Double = widthPercentageForColumnControls(controlList)

        For Each specificControl In controlList
            Dim custControl As CustomControl = DirectCast(specificControl, CustomControl)
            Dim index As Integer = controlList.IndexOf(specificControl)

            setLabelTopFor(custControl.LabelAssociationKey, top)
            setLabelLeftFor(custControl.LabelAssociationKey, left)
            If left = realLeftMargin Then
                left += separation + maxLabelWidth() 'Se cambia el left para el próximo control
            Else
                left += separation + labelWidthFor(custControl.LabelAssociationKey)
            End If

            specificControl.Top = top - 3
            specificControl.Left = left
            specificControl.Width = maxWidthFor(custControl, index, maxWidth, widthPercentage)

            left += specificControl.Width + separation 'Se cambia el left para el próximo control

            Dim annexedCustomControls = annexedControlsFor(custControl.LabelAssociationKey)
            For Each annexedCustomControl As CustomControl In annexedCustomControls
                Dim annexedControl As Control = DirectCast(annexedCustomControl, Control)
                annexedControl.Top = top - 3
                annexedControl.Left = left
                annexedControl.Width = maxWidthFor(annexedCustomControl, -1, maxWidth, widthPercentage)
                left += annexedControl.Width + separation 'Se cambia el left para el próximo control
            Next
        Next
        Return top + controlList(0).Height + controlSeparation
    End Function

    Private Function maxWidthForColumnControls(ByVal controlList As List(Of Control)) 'TODO Mejorar para que devuelva el coeficiente de resta y no una división de cantidad
        Dim annexedControlsInRow As New List(Of CustomControl)
        controlList.ConvertAll(Function(control) annexedControlsFor(DirectCast(control, CustomControl).LabelAssociationKey)).ForEach(Sub(list) annexedControlsInRow.AddRange(list))
        Dim annexedControlsCount = annexedControlsInRow.Count

        Dim availableSpace As Integer
        If organizingCompactedControls Then
            availableSpace = buttonsWidth - maxLabelWidth() + labelWidthFor(DirectCast(controlList(0), CustomControl).LabelAssociationKey) 'Ya que el maxLabelWidth suma el label más largo de la primer columna, se "resta" el primero
        Else
            availableSpace = form.Width - leftMargin - rightMargin - maxLabelWidth() + labelWidthFor(DirectCast(controlList(0), CustomControl).LabelAssociationKey) 'Ya que el maxLabelWidth suma el label más largo de la primer columna, se "resta" el primero
        End If
        availableSpace = availableSpace - controlList.Count * 2 * separation - controlList.Sum(Function(control) labelWidthFor(DirectCast(control, CustomControl).LabelAssociationKey))
        availableSpace = availableSpace - annexedControlsCount * separation

        Dim avgMax As Integer = availableSpace \ (controlList.Count + annexedControlsCount)

        Dim smallerControls As List(Of Control) = controlList.Concat(castToListOfControl(annexedControlsInRow)).ToList.FindAll(Function(control) Math.Min(variableWidthFor(DirectCast(control, CustomControl), controlList.IndexOf(control)), avgMax) < avgMax)
        Dim smallerControlsSize As Integer = smallerControls.Sum(Function(control) variableWidthFor(DirectCast(control, CustomControl), controlList.IndexOf(control)))

        Dim biggerControlsCount As Integer = controlList.Count - smallerControls.Count + annexedControlsCount

        If biggerControlsCount <> 0 Then
            Return (availableSpace - smallerControlsSize) \ biggerControlsCount
        Else
            Return avgMax
        End If
    End Function

    Private Function widthPercentageForColumnControls(ByVal controlList As List(Of Control)) As Double 'TODO Mejorar para que devuelva el coeficiente de resta y no una división de cantidad
        Dim annexedControlsInRow As New List(Of CustomControl)
        controlList.ConvertAll(Function(control) annexedControlsFor(DirectCast(control, CustomControl).LabelAssociationKey)).ForEach(Sub(list) annexedControlsInRow.AddRange(list))
        Dim annexedControlsCount As Integer = annexedControlsInRow.Count

        Dim availableSpace As Integer
        If organizingCompactedControls Then
            availableSpace = buttonsWidth
        Else
            availableSpace = form.Width - leftMargin - rightMargin
        End If
        availableSpace = availableSpace - maxLabelWidth() + labelWidthFor(DirectCast(controlList(0), CustomControl).LabelAssociationKey) 'Ya que el maxLabelWidth suma el label más largo de la primer columna, se "resta" el primero
        availableSpace = availableSpace - controlList.Count * 2 * separation - controlList.Sum(Function(control) labelWidthFor(DirectCast(control, CustomControl).LabelAssociationKey))
        availableSpace = availableSpace - annexedControlsCount * separation

        Dim avgMax As Integer = availableSpace \ (controlList.Count + annexedControlsCount)

        Dim smallerControls As List(Of Control) = controlList.Concat(castToListOfControl(annexedControlsInRow)).ToList.FindAll(Function(control) Math.Min(variableWidthFor(DirectCast(control, CustomControl), controlList.IndexOf(control)), avgMax) < avgMax)
        Dim smallerControlsSize As Integer = smallerControls.Sum(Function(control) variableWidthFor(DirectCast(control, CustomControl), controlList.IndexOf(control)))

        Dim allControlsSize As Integer = (controlList.Sum(Function(control) variableWidthFor(control)) + annexedControlsInRow.Sum(Function(control) variableWidthFor(DirectCast(control, Control))))

        Return Math.Min((availableSpace - smallerControlsSize) / (allControlsSize - smallerControlsSize), 1)
    End Function

    Private Function castToListOfControl(ByVal controls As List(Of CustomControl)) As List(Of Control)
        Dim list As New List(Of Control)
        For Each c In controls
            list.Add(DirectCast(c, Control))
        Next
        Return list
    End Function

    Private Function castToListOfControl(ByVal controls As Object) As List(Of Control)
        Dim list As New List(Of Control)
        For Each c In DirectCast(controls, Object())
            list.Add(DirectCast(c, Control))
        Next
        Return list
    End Function

    Private Function variableWidthFor(ByVal control As CustomControl)
        Return variableWidthFor(control, 0)
    End Function

    Private Function variableWidthFor(ByVal textBox As CustomTextBox, ByVal columnNumber As Integer)
        Return Math.Min(Math.Round(textBox.MaxLength * charPixelSize), variableWidthOfControl(textBox, columnNumber))
    End Function

    Private Function variableWidthFor(ByVal control As CustomControl, ByVal columnNumber As Integer)
        Try
            Return variableWidthFor(DirectCast(control, CustomTextBox), columnNumber)
        Catch e As InvalidCastException
            Return variableWidthOfControl(control, columnNumber)
        End Try
    End Function

    Private Function variableWidthOfControl(ByVal control As CustomControl, ByVal columnNumber As Integer)
        Dim labelWidth As Integer

        Select Case columnNumber
            Case -1
                labelWidth = 0 'Es anexo
            Case 0
                labelWidth = maxLabelWidth() 'Es first column control
            Case Else
                labelWidth = labelWidthFor(control.LabelAssociationKey)
        End Select

        If organizingCompactedControls Then
            Return buttonsWidth - labelWidth - separation
        Else
            Return width - leftMargin - rightMargin - labelWidth - separation
        End If
    End Function

    Private Function maxLabelWidth(ByVal collection As List(Of CustomControl))
        Return collection.ConvertAll(Function(control) labelWidthFor(control.LabelAssociationKey)).Max()
    End Function

    Private Function maxLabelWidth()
        If organizingCompactedControls Then
            Return maxLabelWidth(compactedFirstColumnControls)
        Else
            Return maxLabelWidth(firstColumnControls)
        End If
    End Function

    Private Function controllerButtonsWidth()
        If usingControllerButtons Then
            Return buttonsWidth \ 3
        Else
            Return 0
        End If
    End Function

    Private Function actionButtonsWidth()
        Return buttonsWidth - controllerButtonsWidth()
    End Function

    Private Sub organizeNotCRUDButtons(ByVal top As Integer)
        Dim buttonWidth As Integer = 100
        Dim cancelButtonLeft As Integer = form.Width - rightMargin - buttonWidth
        Dim acceptButtonLeft As Integer = cancelButtonLeft - separation - buttonWidth

        Dim closeButton As New CustomButton
        closeButton.Parent = form
        closeButton.Name = "btnClose"
        closeButton.Visible = False
        closeButton.DialogResult = DialogResult.OK 'Fundamental para que se guarde la info

        Dim acceptButton As New CustomButton
        acceptButton.Parent = form
        acceptButton.Name = "btnAccept"
        acceptButton.Text = "Aceptar"
        acceptButton.Width = buttonWidth
        acceptButton.Height = actionButtonHeight
        acceptButton.Left = acceptButtonLeft
        acceptButton.Top = top
        AddHandler acceptButton.Click, AddressOf acceptButtonClick

        If usingCancelButton Then
            Dim cancelButton As New CustomButton
            cancelButton.Parent = form
            cancelButton.Name = "btnCancel"
            cancelButton.Text = "Cancelar"
            cancelButton.Width = buttonWidth
            cancelButton.Height = actionButtonHeight
            cancelButton.Left = cancelButtonLeft
            cancelButton.Top = top
            AddHandler cancelButton.Click, AddressOf form.Dispose
        End If
    End Sub

    Private Sub acceptButtonClick()
        If validateForAdd() Then
            form.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Function organizeButtons(ByVal top As Integer)
        createActionButtons()

        Dim buttonWidth As Integer = (actionButtonsWidth() - separation * buttonsTop.Count) \ buttonsTop.Count
        buttons.ForEach(Sub(button) button.Width = buttonWidth)
        buttons.ForEach(Sub(button) button.Height = actionButtonHeight)

        Dim left As Integer = leftMargin
        For Each button As CustomButton In buttonsTop
            setButtonPosition(button, top, left)
            left += buttonWidth + separation
        Next

        left = leftMargin
        For Each button As CustomButton In buttonsBottom
            setButtonPosition(button, top + button.Height + separation, left)
            left += buttonWidth + separation
        Next

        Return left
    End Function

    Private Sub addControlerButtons(ByVal top As Integer, ByVal left As Integer)
        Dim buttonsNamesAndTexts As New List(Of Tuple(Of String, String)) _
            From {Tuple.Create("btnFirstReg", "Primer Reg."), Tuple.Create("btnLastReg", "Último Reg."), Tuple.Create("btnNextReg", "Siguiente Reg."), Tuple.Create("btnPreviousReg", "Reg. Anterior")}

        Dim container As New GroupBox
        container.Parent = form
        container.Name = "controlButtonsGroupBox"
        container.Width = controllerButtonsWidth() - separation
        container.Height = containerHeight
        container.Top = top - separation
        container.Left = left + separation

        formNeededHeight = recalculateFormNeededHeight()
        form.Height = Math.Max(formNormalHeight, formNeededHeight)

        Dim btnTop As Integer = separation * 1.5

        For Each buttonInfo In buttonsNamesAndTexts
            Dim button As New CustomButton
            button.Parent = form
            button.Name = buttonInfo.Item1
            button.Text = buttonInfo.Item2
            button.Width = container.Width - separation * 2
            button.Height = (container.Height - separation * 2) \ 4
            button.Top = btnTop
            btnTop += button.Height
            button.Left = separation

            container.Controls.Add(button)
        Next

        addHandlersForControlerButtons(container)
    End Sub

    Private Sub addHandlersForControlerButtons(ByVal container As GroupBox)
        AddHandler container.Controls("btnFirstReg").Click, AddressOf btnFirstClick
        AddHandler container.Controls("btnLastReg").Click, AddressOf btnLastClick
        AddHandler container.Controls("btnNextReg").Click, AddressOf btnNextClick
        AddHandler container.Controls("btnPreviousReg").Click, AddressOf btnPreviousClick
    End Sub


    Private Function defaultContainerHeight()
        Return buttonsHeight()
    End Function

    Private Sub organizeQueryControllers(ByVal top As Integer)
        Dim width As Integer = buttonsWidth
        Dim realQueryListHeight As Integer = Math.Min(listQueryHeight, maxHeight - formNormalHeight - compactHeightConstant)

        If defaultContainerHeight() < 100 Then
            width -= controllerButtonsWidth()
        End If

        If usingQueryText Then
            queryText = New CustomTextBox
            queryText.Parent = form
            queryText.Name = "txtQuery"
            queryText.Width = width
            queryText.Top = top + separation
            top = queryText.Top
            queryText.Left = leftMargin
            queryText.Visible = False
            AddHandler queryText.KeyDown, AddressOf queryTextEnterPressed
        End If

        If defaultContainerHeight() < 100 Then
            containerHeight = Math.Min(defaultContainerHeight() + realQueryListHeight + queryTextHeight(), 100)
        End If

        queryList = New CustomListBox
        queryList.Parent = form
        queryList.Name = "lstQuery"
        queryList.Width = width
        queryList.Height = realQueryListHeight
        queryList.Top = top + queryTextHeight() + separation
        queryList.Left = leftMargin
        queryList.Visible = False
        AddHandler queryList.DoubleClick, AddressOf listDoubleClickEventWithHide

        If queryFunctions.Count > 1 Then
            selectionList = New CustomListBox
            selectionList.Parent = form
            selectionList.Name = "lstSelection"
            selectionList.Width = width
            selectionList.Height = Math.Min(Math.Round(listQueryHeight / 2), maxHeight - formNormalHeight - compactHeightConstant)
            selectionList.Top = top + separation
            selectionList.Left = leftMargin
            selectionList.Visible = False
            AddHandler selectionList.DoubleClick, AddressOf selectionDoubleClick
        End If
    End Sub

    Private Sub setButtonPosition(ByVal button As CustomButton, ByVal top As Integer, ByVal left As Integer)
        button.Top = top
        button.Left = left
    End Sub

    Private Sub createActionButtons()
        buttonsTop.Add(addButton)
        buttonsTop.Add(deleteButton)
        buttonsTop.Add(cleanButton)

        buttonsBottom.Add(queryButton)
        buttonsBottom.Add(listButton)
        buttonsBottom.Add(closeButton)

        buttons.AddRange(buttonsTop)
        buttons.AddRange(buttonsBottom)
    End Sub
    Private Function addButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnAdd"
        btn.Text = "Agregar"

        If Not IsNothing(btnAddClick) Then
            AddHandler btn.Click, AddressOf addClickWithClean
        End If

        Return btn
    End Function
    Private Function deleteButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnDelete"
        btn.Text = "Eliminar"

        If Not IsNothing(btnDeleteClick) Then
            AddHandler btn.Click, AddressOf deleteClickWithConfirmation
        End If

        Return btn
    End Function
    Private Function cleanButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnClean"
        btn.Text = "Limpiar"

        If Not IsNothing(btnCleanClick) Then
            AddHandler btn.Click, btnCleanClick
        End If

        Return btn
    End Function
    Private Function queryButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnQuery"
        btn.Text = "Consulta"

        If Not IsNothing(btnQueryClick) Then
            AddHandler btn.Click, btnQueryClick
        End If

        Return btn
    End Function
    Private Function listButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnList"
        btn.Text = "Listado"

        If Not IsNothing(btnListClick) Then
            AddHandler btn.Click, btnListClick
        End If

        Return btn
    End Function
    Private Function closeButton()
        Dim btn As CustomButton
        btn = New CustomButton()
        btn.Parent = form
        btn.Name = "btnClose"
        btn.Text = "Cerrar"

        If Not IsNothing(btnCloseClick) Then
            AddHandler btn.Click, btnCloseClick
        End If

        Return btn
    End Function

    Private Function labelWidthFor(ByVal index As Integer)
        If IsNothing(labelFor(index)) Then
            Return 0
        Else
            Return labelFor(index).Width
        End If
    End Function

    Private Sub setLabelTopFor(ByVal index As Integer, ByVal top As Integer)
        If Not IsNothing(labelFor(index)) Then
            labelFor(index).Top = top
        End If
    End Sub

    Private Sub setLabelLeftFor(ByVal index As Integer, ByVal left As Integer)
        If Not IsNothing(labelFor(index)) Then
            labelFor(index).Left = left
        End If
    End Sub

    Private Function labelFor(ByVal index As Integer) As CustomLabel
        Return form.Controls.OfType(Of CustomLabel).ToList.Find(Function(label) label.ControlAssociationKey = index)
    End Function

    Private Function annexedControlsFor(ByVal index As Integer) As List(Of CustomControl)
        Dim list = annexedControls.FindAll(Function(control) control.LabelAssociationKey = index)
        If IsNothing(list) Then
            Return New List(Of CustomControl)
        Else
            Return list
        End If
    End Function

    Private Function validateForDelete()
        Return validateControls(False)
    End Function
    Private Function validateForAdd()
        Return validateControls(True)
    End Function
    Private Function validateControls(ByVal isAdd As Boolean)
        Dim firstControl As ValidableControl = allControls.Find(Function(control) control.EnterIndex = 1) 'TODO HACERLO GENÉRICO PARA TODOS LOS CONTROLERS
        Dim validator As New Validator
        validateControl(firstControl, validator)
        If isAdd Then
            validateAnnexedControlsFor(firstControl, validator)
            Dim controlsToValidate As List(Of ValidableControl) = allControls.OfType(Of ValidableControl).ToList 'TODO HACERLO GENÉRICO PARA TODOS LOS CONTROLERS
            controlsToValidate.Remove(firstControl)
            For Each validableControl In controlsToValidate
                validateControl(validableControl, validator)
                validateAnnexedControlsFor(validableControl, validator)
            Next
        End If
        Return validator.flush()
    End Function

    Private Sub validateControl(ByVal validableControl As ValidableControl, ByVal validator As Validator)
        Dim control = DirectCast(validableControl, Control)
        Dim customControl = DirectCast(validableControl, CustomControl)
        validator.validate(control.Text, validableControl.Validator, validableControl.Empty, labelFor(customControl.LabelAssociationKey).Text)
    End Sub

    Private Sub validateAnnexedControlsFor(ByVal validableControl, ByVal validator)
        Dim annexedCustomControls = annexedControlsFor(DirectCast(validableControl, CustomControl).LabelAssociationKey)
        For Each annexedCustomControl In annexedCustomControls
            Dim annexedControl = DirectCast(annexedCustomControl, Control)
            Dim annexedValidableControl = DirectCast(annexedCustomControl, ValidableControl)
            validator.validate(annexedControl.Text, annexedValidableControl.Validator, annexedValidableControl.Empty, "asociado a " & labelFor(annexedCustomControl.LabelAssociationKey).Text)
        Next
    End Sub

    Public Sub setAddButtonClick(ByRef btnClick As EventHandler)
        btnAddClick = btnClick
    End Sub
    Public Sub setDeleteButtonClick(ByRef btnClick As EventHandler)
        btnDeleteClick = btnClick
    End Sub
    Public Sub setCleanButtonClick(ByRef btnClick As EventHandler)
        btnCleanClick = btnClick
    End Sub
    Public Sub setQueryButtonClick(ByRef btnClick As EventHandler)
        btnQueryClick = btnClick
    End Sub
    Public Sub setListButtonClick(ByRef btnClick As EventHandler)
        btnListClick = btnClick
    End Sub
    Public Sub setCloseButtonClick(ByRef btnClick As EventHandler)
        btnCloseClick = btnClick
    End Sub

    Public Sub setDefaultCleanButtonClick()
        btnCleanClick = AddressOf defaultCleanClick
    End Sub
    Public Sub addQueryFunction(ByVal listFunction As QueryFunction, ByVal name As String, ByVal showFunction As ShowMethod, Optional ByVal customControl As CustomControl = Nothing)
        Dim controlName As String = ""
        If Not IsNothing(customControl) Then
            Dim control As Control = DirectCast(customControl, Control)
            controlName = control.Name
            AddHandler control.DoubleClick, AddressOf queryControlDoubleClick
        End If
        queryFunctions.Add(Tuple.Create(listFunction, name, showFunction, controlName))
        btnQueryClick = AddressOf defaultQueryClick
    End Sub

    Private Sub queryControlDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Control = DirectCast(sender, Control)
        Dim queryTuple = queryFunctions.Find(Function(tuple) tuple.Item4 = control.Name)
        queryFunction = queryTuple.Item1
        showMethodFunction = queryTuple.Item3
        showQueryList()
    End Sub
    Public Sub dontUseQueryText()
        usingQueryText = False
    End Sub
    Public Sub setDefaultCloseButtonClick()
        btnCloseClick = AddressOf defaultCloseClick
    End Sub

    Private Sub listDoubleClickEventWithHide(ByVal sender As Object, ByVal e As EventArgs)
        showMethodFunction.Invoke(queryList.SelectedValue)
        queryFunction = Nothing
        hideQueryControls()
    End Sub
    Private Sub selectionDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        queryFunction = selectionList.SelectedValue.Item1
        showMethodFunction = selectionList.SelectedValue.Item3
        hideSelectionList()
        showQueryList()
    End Sub

    Private Sub addClickWithClean(ByVal sender As Object, ByVal e As EventArgs)
        If validateForAdd() Then
            btnAddClick.Invoke(sender, e)
            Cleanner.clean(form)
        End If
    End Sub
    Private Sub deleteClickWithConfirmation(ByVal sender As Object, ByVal e As EventArgs)
        If validateForDelete() Then
            If MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, "Eliminar") = vbYes Then
                btnDeleteClick.Invoke(sender, e)
                Cleanner.clean(form)
            End If
        End If
    End Sub

    Private Sub defaultCleanClick(ByVal sender As Object, ByVal e As EventArgs)
        Cleanner.clean(form)
    End Sub
    Private Sub defaultQueryClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case queryFunctions.Count
            Case 0
            Case 1
                queryFunction = queryFunctions.First().Item1
                showMethodFunction = queryFunctions.First().Item3
                showQueryList()
            Case Else
                If queryList.Visible Then
                    hideQueryControls()
                End If
                showSelectionList()
        End Select
    End Sub
    Private Sub showQueryList()
        queryTextEnterPressed(Nothing, Nothing)
        If usingQueryText Then
            queryText.Visible = True
            queryText.Focus()
        End If
        queryList.Visible = True
        form.Height = formWithQueryControlsHeight
    End Sub
    Private Sub showSelectionList()
        selectionList.DataSource = queryFunctions
        selectionList.DisplayMember = "Item2"
        selectionList.Visible = True
        form.Height = formWithSelectionListHeight
    End Sub

    Private Sub defaultCloseClick(ByVal sender As Object, ByVal e As EventArgs)
        form.Close()
    End Sub

    Private Sub queryTextEnterPressed(ByVal sender As Object, ByVal e As KeyEventArgs)
        If IsNothing(e) OrElse e.KeyValue = Keys.Enter Then
            Dim searchText As String = ""
            If usingQueryText Then
                searchText = queryText.Text
            End If
            queryList.DataSource = queryFunction.Invoke(searchText)
        End If
    End Sub

    Private Sub hideQueryControls()
        If usingQueryText Then
            queryText.Visible = False
            queryText.Text = ""
        End If
        queryList.Visible = False
        hideSelectionList()
        form.Height = Math.Max(formNormalHeight, formNeededHeight)
    End Sub
    Private Sub hideSelectionList()
        If Not IsNothing(selectionList) Then
            selectionList.Visible = False
            form.Height = formNormalHeight
        End If
    End Sub

    Private Function queryTextHeight() As Integer
        Dim heigth As Integer = 0
        If usingQueryText Then
            heigth = queryText.Height
        End If
        Return heigth
    End Function

    Private Function selectionListHeight() As Integer
        Dim heigth As Integer = 0
        If Not IsNothing(selectionList) Then
            heigth = selectionList.Height
        End If
        Return heigth
    End Function

    Public Sub controlsDefinedBy(ByVal procedureName As String, ByVal fromRowFunction As RowToObject, ByVal showFunction As ShowMethod)
        getProcedureName = procedureName
        fromRowToObjectFunction = fromRowFunction
        fromRowShowFunction = showFunction
    End Sub

    Private Sub btnFirstClick()
        fromRowShowFunction.Invoke(fromRowToObjectFunction.Invoke(ClasesCompartidas.SQLConnector.retrieveDataTable(getProcedureName, "primero", "").Rows(0)))
    End Sub

    Private Sub btnLastClick()
        fromRowShowFunction.Invoke(fromRowToObjectFunction.Invoke(ClasesCompartidas.SQLConnector.retrieveDataTable(getProcedureName, "ultimo", "").Rows(0)))
    End Sub

    Private Sub btnNextClick()
        Dim firstControl As Control = allControls.Find(Function(control) control.EnterIndex = 1)
        fromRowShowFunction.Invoke(fromRowToObjectFunction.Invoke(ClasesCompartidas.SQLConnector.retrieveDataTable(getProcedureName, "siguiente", firstControl.Text).Rows(0)))
    End Sub

    Private Sub btnPreviousClick()
        Dim firstControl As Control = allControls.Find(Function(control) control.EnterIndex = 1)
        fromRowShowFunction.Invoke(fromRowToObjectFunction.Invoke(ClasesCompartidas.SQLConnector.retrieveDataTable(getProcedureName, "anterior", firstControl.Text).Rows(0)))
    End Sub
End Class
