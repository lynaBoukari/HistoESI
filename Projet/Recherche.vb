Imports System.Data.OleDb

Class RechercheForm
    Public boole As Boolean = True
    Dim Rech As ClassRecherche = New ClassRecherche
    Dim ind As Integer = 0
    Dim k As Integer = 0
    ' |-------------------------------------------[Gestion des actions sur boutons]----------------------------------------------|

    Private Sub Recherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        etudPic.Visible = True
        textPanel.Visible = True
        anetBox.SelectedIndex = 0
        anesBox.SelectedIndex = 0
        optBox.SelectedIndex = 0
        yearBox.SelectedIndex = 0
        dayBox.SelectedIndex = 0
        monthBox.SelectedIndex = 0

        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ind = 0
        Me.PanelBack.Controls.Clear()
        AccueilForm.Show()
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AideForm.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel7.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Panel7.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Recherche_Choix.Show()

        Me.Close()

    End Sub

    Private Sub OkPromoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkPromoButton.Click
        Me.PanelBack.Controls.Clear()
        boole = False
        Me.LabelPagepromo.Visible = True
        Dim j As Integer = Rech.affichageRechPromo(k)
        Me.LabelPagepromo.Text = "Page: " & k + 1 & "/" & j + 1
        Me.ButtonpagesuivPromo.Visible = True
        Me.ButtonPrecedentPromo.Visible = True


    End Sub

    Private Sub OkEtudiantButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkEtudiantButton.Click
        boole = True
        Me.PanelBack.Controls.Clear()
        Me.LabelPageResultat.Visible = True
        Dim j As Integer = Rech.affichageRechEtudiant(ind)
        Me.LabelPageResultat.Text = "Page: " & ind + 1 & "/" & j + 1
        Me.Button7.Visible = True
        Me.Button8.Visible = True

    End Sub
    ' |----------------------------------------------------------------------------------------------------------------------------|



    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If ind > 0 Then
            ind = ind - 1
            Me.PanelBack.Controls.Clear()
            Dim j As Integer = Rech.affichageRechEtudiant(ind)
            Me.LabelPageResultat.Text = "Page: " & ind + 1 & "/" & j + 1
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ind = ind + 1
        Me.PanelBack.Controls.Clear()
        Dim j As Integer = Rech.affichageRechEtudiant(ind)
        Me.LabelPageResultat.Text = "Page: " & ind + 1 & "/" & j + 1


    End Sub

    Private Sub ButtonPrecedentPromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrecedentPromo.Click
        If k > 0 Then
            Me.PanelBack.Controls.Clear()
            k = k - 1
            Dim j As Integer = Rech.affichageRechPromo(k)
            Me.LabelPageResultat.Text = "Page: " & k + 1 & "/" & j + 1


        End If
    End Sub

    Private Sub ButtonpagesuivPromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonpagesuivPromo.Click

        Me.PanelBack.Controls.Clear()
        k = k + 1
        Dim j As Integer = Rech.affichageRechPromo(k)
        Me.LabelPagepromo.Text = "Page: " & (k + 1) & "/" & j + 1

    End Sub

    Private Sub LabelPagepromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelPagepromo.Click

    End Sub


    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Me.Close()
        Parametrage.Show()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        MatriculeBox.Text = "Matricule"
        NomBox.Text = "Nom"
        PrenomBox.Text = "Prénom"
        dayBox.SelectedIndex = 0
        yearBox.SelectedIndex = 0
        monthBox.SelectedIndex = 0

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

    End Sub
End Class