Public Class Recherche_Choix
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AccueilForm.Show()
        Me.Close()

    End Sub

    Private Sub etudButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles etudButton.Click


        RechercheForm.PromoPanel.Visible = False
        RechercheForm.EtudPanel.Visible = True
        RechercheForm.Show()
        Me.Close()


    End Sub

    Private Sub intervalleAnneeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles intervalleAnneeButton.Click
        RechercheForm.EtudPanel.Visible = False
        RechercheForm.PromoPanel.Visible = True

        RechercheForm.Show()
        Me.Close()

    End Sub

    Private Sub AccueilButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccueilButton.Click
        AccueilForm.Show()
        Me.Close()

    End Sub

    Private Sub AideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideButton.Click
        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub DeconnexionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeconnexionButton.Click
        deconnexionPanel.Visible = True

    End Sub

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        deconnexionPanel.Visible = False

    End Sub

    Private Sub OuiButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuiButton.Click
        Me.Close()
        connexionForm.Show()

    End Sub

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click
        Me.Close()
        Mot_de_passe.Show()

    End Sub
End Class