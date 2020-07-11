Public Class FormStatistiques

    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        'Labels
        Stat_choix.abondonsLabel.Visible = False
        Stat_choix.reussiteGeneralLabel.Visible = True
        Stat_choix.reussiteModuleLabel.Visible = False
        Stat_choix.reussiteGroupeLabel.Visible = False
        Stat_choix.diplomesLabel.Visible = False


        'Variables indicatrices
        Stat_choix.modu = False
        Stat_choix.groupe = False
        Stat_choix.abondons = False
        Stat_choix.generale = True
        Stat_choix.diplomes = False

        Stat_choix.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AccueilForm.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        deconnexionPanel.Visible = True

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AideForm.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False


    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        'Labels
        Stat_choix.abondonsLabel.Visible = False
        Stat_choix.reussiteGeneralLabel.Visible = False
        Stat_choix.reussiteModuleLabel.Visible = True
        Stat_choix.reussiteGroupeLabel.Visible = False
        Stat_choix.diplomesLabel.Visible = False


        'Variables indicatrices
        Stat_choix.modu = True
        Stat_choix.groupe = False
        Stat_choix.abondons = False
        Stat_choix.generale = False
        Stat_choix.diplomes = False

        Stat_choix.Show()
        Me.Close()

    End Sub ' le choix est réussite generale alors on affiche la page de choix année ou intervalle 

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        Stats_saisie.anneePanel.Visible = True
        Stats_saisie.champsGroupePanel.Visible = True
        Stats_saisie.reussiteGroupeLabel.Visible = True



        'indication du type de requete
        Stats_saisie.annee = True
        Stat_choix.groupe = True
        Stat_choix.modu = False
        Stat_choix.abondons = False
        Stat_choix.generale = False
        Stat_choix.diplomes = False

        Stats_saisie.Show()
        Me.Close()

    End Sub ' le choix est réussite par groupe alors on affiche la fenetre de saisie 

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Labels
        Stat_choix.abondonsLabel.Visible = True
        Stat_choix.reussiteGeneralLabel.Visible = False
        Stat_choix.reussiteModuleLabel.Visible = False
        Stat_choix.reussiteGroupeLabel.Visible = False
        Stat_choix.diplomesLabel.Visible = False


        'Variables indicatrices
        Stat_choix.modu = False
        Stat_choix.groupe = False
        Stat_choix.abondons = True
        Stat_choix.generale = False
        Stat_choix.diplomes = False

        Stat_choix.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Labels
        Stat_choix.abondonsLabel.Visible = False
        Stat_choix.reussiteGeneralLabel.Visible = False
        Stat_choix.reussiteModuleLabel.Visible = False
        Stat_choix.reussiteGroupeLabel.Visible = False
        Stat_choix.diplomesLabel.Visible = True


        'Variables indicatrices
        Stat_choix.modu = False
        Stat_choix.groupe = False
        Stat_choix.abondons = False
        Stat_choix.generale = False
        Stat_choix.diplomes = True

        Stat_choix.Show()
        Me.Close()
    End Sub

    
    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click

        Parametrage.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AccueilForm.Show()
        Me.Close()

    End Sub
End Class
