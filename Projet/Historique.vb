Public Class Historique

    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If

    End Sub
    Private Sub relnoteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EtatSortiePanel.Visible = True

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        deconnexionPanel.Visible = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AccueilForm.Show()
        Me.Close()
        RechercheForm.Close()
    End Sub

    Private Sub okBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EtatSortiePanel.Visible = True
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        deconnexionPanel.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AideForm.Show()
        Me.Close()
    End Sub

    Private Sub ReleveSimpleLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False

    End Sub

    Private Sub RetourBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetourBtn.Click
        If Not (Me.PanelTabl.Visible) Then


            Me.PanelTabl.Visible = True
            Me.PanelTableau.BringToFront()
            Me.Label12.Visible = False
            Me.LabelMoyAnnu.Visible = False
            Me.LabelMentionReleve.Visible = False
            Me.Label14.Visible = False
            Me.PanelTableau.Visible = True
            Me.Label15.Visible = False
            Me.LabelAnnetreleve.Visible = False
            Me.PanelReleve.Visible = False
            Me.Panel3.Visible = False
            Me.Label17.Visible = False
            Me.Labelannescolreleve.Visible = False
        Else
            RechercheForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.PanelTabl.Visible = True
        Me.PanelTableau.BringToFront()
        Me.Label12.Visible = False
        Me.LabelMoyAnnu.Visible = False
        Me.LabelMentionReleve.Visible = False
        Me.Label14.Visible = False
        Me.PanelTableau.Visible = True
        Me.Label15.Visible = False
        Me.LabelAnnetreleve.Visible = False
        Me.PanelReleve.Visible = False
        Me.Panel3.Visible = False
        Me.Label17.Visible = False
        Me.Labelannescolreleve.Visible = False
    End Sub

    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Me.Close()
        Parametrage.Show()

    End Sub

    Private Sub PanelTabl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTabl.Paint

    End Sub

    Private Sub PanelTableau_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTableau.Paint

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub LabelAnnetreleve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelAnnetreleve.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Labelannescolreleve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Labelannescolreleve.Click

    End Sub

    Private Sub PanelReleve_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelReleve.Paint

    End Sub

    Private Sub deconnexionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles deconnexionPanel.Paint

    End Sub
End Class