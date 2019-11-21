Imports System.Configuration
Imports System.Data.SqlClient

Public Class FrasesHP
    Inherits HojaIngresoFrases
    Sub New(ByVal H)

        ' This call is required by the designer.
        InitializeComponent()
        L = H
        ' Add any initialization after the InitializeComponent() call.
        txtCodigo.Focus()
    End Sub



    Private Sub FrasesHP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblTitulo.Text = IIf(L = "H", "INGRESO FRASES H", "INGRESO FRASES P")
        pnlListar.Visible = False
    End Sub
End Class