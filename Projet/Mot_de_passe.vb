Public Class Mot_de_passe
    Dim mdp As ClassMotDePasse = New ClassMotDePasse

    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub EtatSortiePanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles EtatSortiePanel.Paint

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mdp.traitementMdp("admin", Me.AnetBox.Text, Me.TextBoxnouveau.Text)
        Me.TextBoxnouveau.Clear()
        Me.AnetBox.Clear()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        mdp.traitementMdp("personnel", Me.TextBox1.Text, Me.TextBoxnouveauPers.Text)
        Me.TextBox1.Clear()
        Me.TextBoxnouveauPers.Clear()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.TextBox1.Clear()
        Me.TextBoxnouveauPers.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.AnetBox.Clear()
        Me.TextBoxnouveau.Clear()


    End Sub


    Private Sub deconnexionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles deconnexionPanel.Paint

    End Sub

    Private Sub TextBoxnouveau_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TextBoxnouveau.MaskInputRejected

    End Sub

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click
        Parametrage.Show()
        Me.Close()

    End Sub
End Class