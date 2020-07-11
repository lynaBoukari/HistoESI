Public Class CorrectionErreur

    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If

    End Sub

#Region "Buttons related to the function"
    Private Sub BT_TROUV_EMP_INSCIT_Click(sender As System.Object, e As System.EventArgs) Handles BT_TROUV_EMP_INSCIT.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Inscrit"
        OpenFileDialog1.ShowDialog()
        TXT_EMP_INSCRIT.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub BT_TROUV_EMP_MAT_Click(sender As System.Object, e As System.EventArgs) Handles BT_TROUV_EMP_MAT.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Matiere"
        OpenFileDialog1.ShowDialog()
        TXT_EMP_MAT.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub BT_TROUV_EMP_NOTE_Click(sender As System.Object, e As System.EventArgs) Handles BT_TROUV_EMP_NOTE.Click
        OpenFileDialog1.Title = "Selectionnez le fichier NOTE"
        OpenFileDialog1.ShowDialog()
        TXT_EMP_NOTE.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub BT_TROUV_EMP_RATRAP_Click(sender As System.Object, e As System.EventArgs) Handles BT_TROUV_EMP_RATRAP.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Rattrapage"
        OpenFileDialog1.ShowDialog()
        TXT_EMP_RATRAP.Text = OpenFileDialog1.FileName()
    End Sub


    Private Sub BT_CorrigerErreur_Click(sender As System.Object, e As System.EventArgs) Handles BT_CorrigerErreur.Click
        If (String.IsNullOrEmpty(TXT_EMP_INSCRIT.Text) And String.IsNullOrEmpty(TXT_EMP_MAT.Text) And String.IsNullOrEmpty(TXT_EMP_NOTE.Text) And String.IsNullOrEmpty(TXT_EMP_RATRAP.Text)) Then
            MessageBox.Show("Veuiller remplir l'un des champs", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim chem As String = "" 'contiendra le chemin de la nouvelle bdderreur qui est une copie de bdderreur
            FolderBrowserDialog1.ShowDialog()
            chem = FolderBrowserDialog1.SelectedPath()
            Try 'copie du model bdd erreur dans le chemin selectionné
                My.Computer.FileSystem.CopyFile("..\BDDErreur.accdb", String.Concat(chem, "\BDDErreur.accdb"), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim bddErreurChemin As String = String.Concat(chem, "\BDDErreur.accdb")
            Dim c As ClassCorriectionErreur = New ClassCorriectionErreur(connexionForm.chcnx, bddErreurChemin)
            ' ****************************      INSCRIT     *******************************
            If Not (String.IsNullOrEmpty(TXT_EMP_INSCRIT.Text)) Then
                c.corrigerInscrit(TXT_EMP_INSCRIT.Text)
            End If


            ' ****************************      MATIERE         ****************************
            If Not (String.IsNullOrEmpty(TXT_EMP_MAT.Text)) Then
                c.corrigerMatiere(TXT_EMP_MAT.Text)
            End If


            '*****************************        NOTE         ********************************
            If Not (String.IsNullOrEmpty(TXT_EMP_NOTE.Text)) Then
                c.corrigerNote(TXT_EMP_NOTE.Text)
            End If

            '*****************************        Rattrapage   ********************************
            If Not (String.IsNullOrEmpty(TXT_EMP_RATRAP.Text)) Then
                c.corrigerRattrapage(TXT_EMP_RATRAP.Text)
            End If
            MessageBox.Show("Veuillez consulter la BDDERREURS pour prendre connaissance des lignes avec erreurs.Si l'une des tables est vide cela veut dire qu'aucune erreurs de ce type n'a été detectée.", "Fin de la Correction", MessageBoxButtons.OK)
        End If
    End Sub
#End Region

#Region "Different boutons"
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles DeconnexionButton.Click
        deconnexionPanel.Visible = True
    End Sub

    Private Sub OuiButton_Click(sender As System.Object, e As System.EventArgs) Handles OuiButton.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        deconnexionPanel.Visible = False

    End Sub


    Private Sub AideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideButton.Click
        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub AccueilButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccueilButton.Click
        AccueilForm.Show()
        Me.Close()

    End Sub

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click
        Parametrage.Show()
        Me.Close()

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles BT_RETOURCHARGEMENT.Click
        Chargement.Show()
        Me.Close()
    End Sub
#End Region


End Class