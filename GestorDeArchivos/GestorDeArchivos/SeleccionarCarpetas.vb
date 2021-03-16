Public Class SeleccionarCarpetas

    Private ReadOnly RutaBase As String
    Private ReadOnly DragOn As Boolean
    Private ReadOnly Warchivos As Object
    Sub New(ByVal ruta As String, Optional ByVal Drag As Boolean = False, Optional ByVal Archivos As Object = Nothing)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RutaBase = ruta
        DragOn = Drag
        Warchivos = Archivos
    End Sub
    Private Sub CANCELAR_Click(sender As Object, e As EventArgs) Handles CANCELAR.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim VectorChk(7) As String
        For i = 0 To 7
            VectorChk(i) = ""
        Next
        Dim contador As Integer = 0
        For Each ctrl As Control In gbx_Carpetas.Controls
            If (ctrl.GetType() Is GetType(CheckBox)) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked Then
                    Select Case chk.Name
                        Case "chk_General"
                            VectorChk(contador) = RutaBase
                        Case "chk_Proforma"
                            VectorChk(contador) = RutaBase & "\Proforma"
                        Case "chk_SIMI"
                            VectorChk(contador) = RutaBase & "\SIMI"
                        Case "chk_OrdenCompra"
                            VectorChk(contador) = RutaBase & "\Orden de Compra"
                        Case "chk_PackingList"
                            VectorChk(contador) = RutaBase & "\Packing List"
                        Case "chk_COAS"
                            VectorChk(contador) = RutaBase & "\COAS"
                        Case "chk_BL"
                            VectorChk(contador) = RutaBase & "\BL"
                        Case "chk_INVOICE"
                            VectorChk(contador) = RutaBase & "\INVOICE"
                        Case "chk_Despacho"
                            VectorChk(contador) = RutaBase & "\Despacho"
                    End Select
                    contador += 1
                End If
            End If
        Next
        
        Dim Wowner As SelectorCarpetas = TryCast(Owner, SelectorCarpetas)

        If Wowner IsNot Nothing Then
            If DragOn Then
                Wowner.PasavectorDragOn(VectorChk, WArchivos)
            Else
                Wowner.Pasavector(VectorChk)
            End If

            Close()
        End If


    End Sub

  
End Class