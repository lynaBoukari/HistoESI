Public Class AccueilForm



    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If

    End Sub
    Private Sub Recherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rechAccButton.Click
        Recherche_Choix.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles classementAccButton.Click

        Classement.Show()
        Me.Close()

    End Sub

    Private Sub statistiquesAccButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statistiquesAccButton.Click

        FormStatistiques.Show()
        Me.Close()



    End Sub

    Private Sub PanelStat_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelStat.Paint

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        deconnexionPanel.Visible = True


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        AideForm.Show()
        Me.Close()


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()

    End Sub

    Private Sub deconnexionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles deconnexionPanel.Paint


    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PvF.Show()
        Me.Close()

    End Sub

    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click

        Parametrage.Show()
        Me.Close()
    End Sub

End Class