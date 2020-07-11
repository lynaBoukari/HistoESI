Public Class UserControl1
    Dim r As ClassRecherche = New ClassRecherche
    Dim histor As ClassHistorique = New ClassHistorique
    Public Property MatriculeLabel As String
        Get
            Return LabelRechMatricule.Text
        End Get
        Set(ByVal value As String)
            LabelRechMatricule.Text = value
        End Set
    End Property

    Public WriteOnly Property visibleModifier As Boolean

        Set(ByVal value As Boolean)

            ButtonModifier.Visible = value

        End Set
    End Property


    Private Sub ButtonModifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LabelRechMatricule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonModifier_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonModifier.Click

        Dim datatable As DataTable = r.RechercheEtudiant()
        Dim row As DataRow = r.TrouvRow(MatriculeLabel, datatable)
        r.modifierAff(row)
        modifierForm.Show()
        RechercheForm.Hide()

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim datatable As DataTable = r.RechercheEtudiant()
        Dim row As DataRow = r.TrouvRow(MatriculeLabel, datatable)
        r.detailsAff(row)
        If (connexionForm.AuthPersonnelPanel.Visible) Then
            Details.ButtonParam.Visible = False
            Details.Button2.Visible = False
        End If
        Details.Show()
        RechercheForm.Hide()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Dim datatable As DataTable = histor.sortieHistoParcours(MatriculeLabel)
        histor.histoAff(datatable)
        Historique.LabelMat.Text = MatriculeLabel
        Historique.Labelnom.Text = LabelRechNom.Text
        Historique.Labelprenom.Text = LabelRechPrenom.Text
        Historique.Show()
        RechercheForm.Hide()

    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RechercheForm.Hide()

        EtatDeSortie.LabelMat.Text = MatriculeLabel
        EtatDeSortie.LabelNom.Text = Me.LabelRechNom.Text
        EtatDeSortie.Label21.Text = Me.LabelRechPrenom.Text
        EtatDeSortie.Show()

    End Sub

    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (RechercheForm.ButtonParam.Visible) Then
            Me.ButtonModifier.Visible = False
        End If
    End Sub

    Private Sub LabelRechMatricule_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRechMatricule.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub LabelRechDDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRechDDN.Click

    End Sub
    Private Sub LabelRechPrenom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRechPrenom.Click

    End Sub
    Private Sub LabelRechNom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRechNom.Click

    End Sub

    Private Sub RectangleShape1_Click(sender As System.Object, e As System.EventArgs) Handles RectangleShape1.Click

    End Sub
End Class
