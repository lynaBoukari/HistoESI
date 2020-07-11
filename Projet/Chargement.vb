Public Class Chargement
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Parametrage.Show()
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

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click
        Parametrage.Show()
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

    Private Sub CHRG_NV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHRG_NV.Click
        Chargement_nv_fichiers.Show()
        Me.Close()
    End Sub

    Private Sub Correction_Click(sender As System.Object, e As System.EventArgs) Handles Correction.Click
        CorrectionErreur.Show()
        Me.Close()
    End Sub
End Class