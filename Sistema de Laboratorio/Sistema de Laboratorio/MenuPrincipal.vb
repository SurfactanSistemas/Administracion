Public Class MenuPrincipal

    Const SISTEMA As String = "LABORATORIO"

    Public Shared Function ItemsMenu() As DataTable

        Dim TablaItems As New DataTable
        With TablaItems.Columns
            .Add("ID")
            .Add("Nombre")
            .Add("IDPadre")
            .Add("NombrePadre")
        End With

        Dim posicion As Integer = -1
        
        'For Each Item As ToolStripMenuItem In (New MenuPrincipal).MaestrosToolStripMenuItem.DropDownItems
        For Each Item As ToolStripMenuItem In (New MenuPrincipal).MenuStrip1.Items
            Dim ID As String = Microsoft.VisualBasic.Right(Item.Name, 2)
            Dim Nombre As String = Item.Text
            If Item.DropDownItems.Count > 0 Then
                Dim IDAnterior As String = ID
                Dim NombreAnterior As String = Nombre
                For Each Item2 As ToolStripMenuItem In Item.DropDownItems

                    If Item2.DropDownItems.Count > 0 Then
                        ID = Microsoft.VisualBasic.Right(Item2.Name, 2)
                        Nombre = Item2.Text

                        For Each Item3 As ToolStripMenuItem In Item2.DropDownItems
                            With TablaItems.Rows
                                .Add(Microsoft.VisualBasic.Right(Item3.Name, 2), Item3.Text, ID, Nombre)
                            End With
                        Next
                    Else
                        ID = IDAnterior
                        Nombre = NombreAnterior
                        'With TablaItems.Rows
                        '    .Add(ID, Nombre, "", "")
                        'End With
                        With TablaItems.Rows
                            .Add(Microsoft.VisualBasic.Right(Item2.Name, 2), Item2.Text, ID, Nombre)
                        End With

                    End If


                Next
             End If
        Next
        For Each Item As ToolStripMenuItem In (New MenuPrincipal).MenuStrip1.Items
            If Item.DropDownItems.Count > 0 Then
                For Each Item2 As ToolStripMenuItem In Item.DropDownItems
                    If Item2.DropDownItems.Count > 0 Then
                        With TablaItems.Rows
                            .Add(Microsoft.VisualBasic.Right(Item2.Name, 2), Item2.Text, Microsoft.VisualBasic.Right(Item.Name, 2), Item.Text)
                        End With
                    End If
                Next
                With TablaItems.Rows
                    .Add(Microsoft.VisualBasic.Right(Item.Name, 2), Item.Text, "", "")
                End With

            End If
        Next
        
        Return TablaItems
    End Function

    Private Sub DeshabilitarTodos()
        For Each Item1 As ToolStripMenuItem In Me.MenuStrip1.Items
            Dim ID As String = Microsoft.VisualBasic.Right(Item1.Name, 2)

            If Item1.DropDownItems.Count > 0 Then

                For Each Item2 As ToolStripMenuItem In Item1.DropDownItems

                    If Item2.DropDownItems.Count > 0 Then

                        For Each Item3 As ToolStripMenuItem In Item2.DropDownItems
                            Item3.Enabled = False
                        Next
                    Else
                        Item2.Enabled = False
                    End If
                    
                Next
            End If
            
            Item1.Enabled = False

            Next
    End Sub

    Private Sub PermisosMenu()

        Dim SQLCnslt As String = "SELECT ID, Visible, Lectura, Escritura FROM PermisosPerfiles WHERE Sistema = '" & SISTEMA & "' AND Perfil = '" & Operador.Perfil & "' AND Planta = '" & Operador.Base & "' ORDER BY ID"
        Dim TablaDatos As DataTable = GetAll(SQLCnslt, "SurfactanSA")

        If TablaDatos.Rows.Count = 0 Then

            MsgBox("No tiene permisos configurados para esta planta")
            DeshabilitarTodos()
        Else
            For Each Item1 As ToolStripMenuItem In Me.MenuStrip1.Items
                Dim ID As String = Microsoft.VisualBasic.Right(Item1.Name, 2)
                Dim Row = BuscarPermisos(TablaDatos, Microsoft.VisualBasic.Right(Item1.Name, 2))
                If Not Row.Item("Visible") Then
                    Item1.Enabled = False
                End If
                If Item1.DropDownItems.Count > 0 Then

                    For Each Item2 As ToolStripMenuItem In Item1.DropDownItems

                        If Item2.DropDownItems.Count > 0 Then

                            For Each Item3 As ToolStripMenuItem In Item2.DropDownItems
                                Dim Row3 = BuscarPermisos(TablaDatos, Microsoft.VisualBasic.Right(Item3.Name, 2))
                                If Not Row3.Item("Visible") Then
                                    Item3.Enabled = False
                                End If

                            Next
                        Else
                            Dim Row2 = BuscarPermisos(TablaDatos, Microsoft.VisualBasic.Right(Item2.Name, 2))
                            If Not Row2.Item("Visible") Then
                                Item2.Enabled = False
                            End If

                        End If


                    Next
                End If


            Next

        End If
        'For Each Item1 As ToolStripMenuItem In (New MenuPrincipal).MenuStrip1.Items

        'DeshabilitarTodos()

        

    End Sub

    Private Function BuscarPermisos(ByVal TablaDatos As DataTable, ByVal IDItem As String) As DataRow
        For Each row As DataRow In TablaDatos.Rows
            ' If row.Item("Id") = Val(IDItem) Then
            If row.Item("Id") = IDItem Then
                Return row
            End If
        Next

    End Function


    Private Sub btnCambioEmpresa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCambioEmpresa.Click
        With New Login
            .Show()
            .txtClave.Text = Clave
        End With
        Close()
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
       
        ' LotesVencidosToolStripMenuItem_09.Visible = (Base = "Surfactan_II" Or Base = "SurfactanSa")
        ' AutorizaciónDePedidosToolStripMenuItem_22.Visible = Base = "Surfactan_III"
        
        PermisosMenu()

    End Sub

    Private Sub FinDeSistemaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FinDeSistemaToolStripMenuItem_36.Click
        Close()
    End Sub

    Private Sub EnsayosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menu_01.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New ListaEnsayos(id)
            .Show(Me)
        End With
    End Sub

    Private Sub ListadoDeEnsayosEnMPToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEnsayosEnMPToolStripMenuItem_08.Click
        Dim frm = New ProcesarListadoEnsayosEnMateriaPrima()
        frm.Show(Me)
    End Sub

    Private Sub ListadoDeEspecificacionesDeMPAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEspecificacionesDeMPAFechaToolStripMenuItem_07.Click
        Dim frm = New ListadoEspecificacionesMPAFecha
        frm.Show(Me)
    End Sub

    Private Sub EspecificacionesPorVersiónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EspecificacionesPorVersiónToolStripMenuItem_06.Click
        With New EspecificacionesMPPorVersion
            .Show(Me)
        End With
    End Sub

    Private Sub EmisiónDeEtiquetasSimplesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EmisiónDeEtiquetasSimplesToolStripMenuItem_11.Click
        With New EmisionEtiquetasSimples
            .Show(Me)
        End With
    End Sub

    Private Sub HToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HToolStripMenuItem_25.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoFrasesH("H", id)
            .Show(Me)
        End With
    End Sub

    Private Sub PToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PToolStripMenuItem_26.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoFrasesH("P", id)
            .Show(Me)
        End With
    End Sub

    Private Sub MateriasPrimasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MateriasPrimasToolStripMenuItem1_28.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoDatosAdicMP("MP", id)
            .Show(Me)
            .pnlConsultarDatos.Visible = False
            .masktxtCodigo.Focus()
            .txtConsultaDatos.Visible = False
        End With
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ProductosTerminadosToolStripMenuItem1_29.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoDatosAdicMP("PT", id)
            .Show(Me)
            .pnlConsultarDatos.Visible = False
            .masktxtCodigo.Focus()
            .txtConsultaDatos.Visible = False
        End With
    End Sub

    Private Sub ListadoDeEnsayosDePTToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEnsayosDePTToolStripMenuItem_18.Click
        With New ListadoDeEnsayoDePT
            .Show(Me)
        End With
    End Sub

    Private Sub ListaDeEspecificacionesDePTAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListaDeEspecificacionesDePTAFechaToolStripMenuItem_16.Click
        With New ListadoEspecifPTFecha
            .Show(Me)
        End With
    End Sub

    Private Sub ListaDePTVencidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListaDePTVencidosToolStripMenuItem_19.Click
        With New ListadoPTVencidos
            .Show(Me)
        End With
    End Sub

    Private Sub ConsultaDeEspecificacionesPorVersionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsultaDeEspecificacionesPorVersionToolStripMenuItem_15.Click
        With New ConsDeEspefXVersion
            .Show(Me)
        End With
    End Sub

    Private Sub EmisionDeEtiquetasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EmisionDeEtiquetasToolStripMenuItem_30.Click
        With New ImpresionEtiquetasMuestras
            .Show(Me)
        End With
    End Sub

    Private Sub LotesVencidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LotesVencidosToolStripMenuItem_09.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New VerificacionLoteVencidoMP(id)
            .Show(Me)
        End With
    End Sub

    Private Sub VerificacionDeVencimientosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerificacionDeVencimientosToolStripMenuItem_10.Click
        With New VerificacionDeVencimientosMP
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoDeEspecificacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeEspecificacionesToolStripMenuItem_14.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoEspecificacionesPT(id)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_17.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoEnsayosIntermediosPT(id)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2_20.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoDatosMostrarEnCertificadosAnalisis("", "", False, id)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3_21.Click
        With New EmisionCertificadoAnalisis
            .Show(Me)
        End With
    End Sub

    Private Sub EspecificacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EspecificacionesToolStripMenuItem1_05.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoEspecificacionesMP(id)
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoDeEnsayosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeEnsayosToolStripMenuItem_04.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoEnsayosLaboratorioMP(id)
            .Show(Me)
        End With
    End Sub

    Private Sub MovimientosVariosDeLaboratorioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientosVariosDeLaboratorioToolStripMenuItem_32.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New MovimientosVariosDeLaboratorio(id)
            .Show(Me)
        End With
    End Sub

    Private Sub AutorizaciónDePedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaciónDePedidosToolStripMenuItem_22.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New ListadoAutorizacionPedidos(id)
            .Show(Me)
        End With
    End Sub
    
    Private Sub InformeDeRecepcionDeDrogaDeLaboratorioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeDeRecepcionDeDrogaDeLaboratorioToolStripMenuItem_31.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New InformeRecepcionDrogaLAB(id)
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoYActualizacionDeHojaDeProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoYActualizacionDeHojaDeProduccionToolStripMenuItem_33.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoActualizacionHojaProduccionFarma(id)
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoFormulasDeEnsayosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menu_02.Click
        Dim itemStrip As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        Dim id As String = Microsoft.VisualBasic.Right(itemStrip.Name, 2)
        With New IngresoFormulasEnsayo(id)
            .Show(Me)
        End With
    End Sub

    Private Sub ImpresiónPlanillaDeEnsayosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónPlanillaDeEnsayosToolStripMenuItem_23.Click
        With New ImpresionPlanillaEnsayosPT()
            .Show(Me)
        End With
    End Sub

    Private Sub ImpresiónPlanillaDeEnsayosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImpresiónPlanillaDeEnsayosToolStripMenuItem1_12.Click
        With New ImpresionPlanillaEnsayosMP()
            .Show(Me)
        End With
    End Sub
End Class