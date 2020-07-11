Public Class modifierForm
    Dim r As ClassRecherche = New ClassRecherche
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel7.Visible = True 
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RechercheForm.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Panel7.Visible = False
        PanelModif.Visible = True
    End Sub

    Private Sub accueilButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles accueilButton.Click
        AccueilForm.Show()
        Me.Close()
        RechercheForm.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.PanelConfiramtionModification.Visible = True
       


    End Sub

    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Me.Close()
        Mot_de_passe.Show()

    End Sub

    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (RechercheForm.boole) Then
            Dim datatable As DataTable = r.RechercheEtudiant()
            Dim row As DataRow = r.TrouvRow(Me.LabelmatriculeBleu.Text, datatable)
            r.modifierAff(row)
            Me.PanelConfiramtionModification.Visible = False
        Else
            Dim datatable As DataTable = r.RecherchePromo()
            Dim row As DataRow = r.TrouvRow(Me.LabelmatriculeBleu.Text, datatable)
            r.modifierAff(row)
            Me.PanelConfiramtionModification.Visible = False

        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        If (RechercheForm.boole) Then

            Dim datatable As DataTable = r.RechercheEtudiant()
            Dim row As DataRow = r.TrouvRow((Me.LabelmatriculeBleu.Text), datatable)
            r.updateData()
            Me.PanelConfiramtionModification.Visible = False

        Else

            Dim datatable As DataTable = r.RecherchePromo()
            Dim row As DataRow = r.TrouvRow((Me.LabelmatriculeBleu.Text), datatable)
            r.updateData()
            Me.PanelConfiramtionModification.Visible = False

        End If
    End Sub

    Private Sub affch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles affch.Click

    End Sub
End Class