Public Class Stat_choix
    Public generale As Boolean
    Public groupe As Boolean
    Public modu As Boolean
    Public abondons As Boolean
    Public diplomes As Boolean
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If

    End Sub
    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles intervalleAnneeButton.Click

        Stats_saisie.Show()
        Stats_saisie.intervallePanel.Visible = True
        'Indication du type de requete
        Stats_saisie.annee = False
        Stats_saisie.intervalle = True

        'Affichage des pannels et labels
        If Me.reussiteGeneralLabel.Visible = True Or Me.abondons = True Then
            Stats_saisie.champsGeneralPanel.Visible = True
            Stats_saisie.reussiteGeneralLabel.Visible = True
        Else
            Stats_saisie.champsGeneralPanel.Visible = False
            Stats_saisie.reussiteGeneralLabel.Visible = False
        End If
        If Me.groupe = True Then
            Stats_saisie.champsGroupePanel.Visible = True
            Stats_saisie.reussiteGroupeLabel.Visible = True
        Else
            Stats_saisie.champsGroupePanel.Visible = False
            Stats_saisie.reussiteGroupeLabel.Visible = False
        End If

        If Me.abondons = True Then
            Stats_saisie.abondonsLabel.Visible = True
        Else
            Stats_saisie.abondonsLabel.Visible = False
        End If

        If Me.modu = True Then
            Stats_saisie.anneeModulePanel.Visible = True
            Stats_saisie.reussiteModuleLabel.Visible = True
        Else
            Stats_saisie.anneeModulePanel.Visible = False
            Stats_saisie.reussiteModuleLabel.Visible = False
        End If

        If Me.diplomes = True Then
            Stats_saisie.champsDiplomesPanel.Visible = True
            Stats_saisie.diplomesLabel.Visible = True
        Else
            Stats_saisie.champsDiplomesPanel.Visible = False
            Stats_saisie.diplomesLabel.Visible = False
        End If

        Me.Hide()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuiButton.Click
        Me.Close()
        connexionForm.connexionPanel.Visible = False
        connexionForm.authAdminPanel.Visible = True
        connexionForm.Show()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormStatistiques.Show()
        Me.Close()
        Stats_saisie.Close()

    End Sub

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        deconnexionPanel.Visible = False
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

    Private Sub AnneeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnneeButton.Click

        Stats_saisie.anneePanel.Visible = True

        'indication du type de requete
        Stats_saisie.annee = True
        Stats_saisie.intervalle = False

        'affichage des pannels et labels
        If reussiteGeneralLabel.Visible = True Or Me.abondons = True Then
            Stats_saisie.champsGeneralPanel.Visible = True
            Stats_saisie.reussiteGeneralLabel.Visible = True
        Else
            Stats_saisie.champsGeneralPanel.Visible = False
            Stats_saisie.reussiteGeneralLabel.Visible = False
        End If

        If Me.groupe = True Then
            Stats_saisie.champsGroupePanel.Visible = True
            Stats_saisie.reussiteGroupeLabel.Visible = True
        Else
            Stats_saisie.champsGroupePanel.Visible = False
            Stats_saisie.reussiteGroupeLabel.Visible = False
        End If

        If Me.abondons = True Then
            Stats_saisie.abondonsLabel.Visible = True
        Else
            Stats_saisie.abondonsLabel.Visible = False
        End If

        If Me.modu = True Then
            Stats_saisie.anneeModulePanel.Visible = True
            Stats_saisie.reussiteModuleLabel.Visible = True
        Else
            Stats_saisie.anneeModulePanel.Visible = False
            Stats_saisie.reussiteModuleLabel.Visible = False
        End If

        If Me.diplomes = True Then
            Stats_saisie.champsDiplomesPanel.Visible = True
            Stats_saisie.diplomesLabel.Visible = True
        Else
            Stats_saisie.champsDiplomesPanel.Visible = False
            Stats_saisie.diplomesLabel.Visible = False
        End If

        Stats_saisie.Show()
        Me.Hide()


    End Sub

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click

        Parametrage.Show()
        Me.Close()
    End Sub

End Class