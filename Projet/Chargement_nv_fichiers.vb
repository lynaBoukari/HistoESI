Imports System.Data.OleDb

Public Class Chargement_nv_fichiers
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If

    End Sub

#Region "boutons de parcours des fichiers "
    Private Sub INSCRIT_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSCRIT_Button.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Inscrit"
        OpenFileDialog1.ShowDialog()
        INSCRIT_TextBox.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub MATIERE_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATIERE_Button.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Matiere"
        OpenFileDialog1.ShowDialog()
        MATIERE_TextBox.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub RATTRAPAGE_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RATTRAPAGE_Button.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Rattrapage"
        OpenFileDialog1.ShowDialog()
        RATTRAPAGE_TextBox.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub NOTE_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTE_Button.Click
        OpenFileDialog1.Title = "Selectionnez le fichier Note"
        OpenFileDialog1.ShowDialog()
        NOTE_TextBox.Text = OpenFileDialog1.FileName
    End Sub

#End Region

    Private Sub CHGM_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHGM_Button.Click
        Dim objchrgm As ClassChargement = New ClassChargement
        If (INSCRIT_TextBox.Text = "" Or MATIERE_TextBox.Text = "" Or NOTE_TextBox.Text = "" Or RATTRAPAGE_TextBox.Text = "") Then
            MessageBox.Show("Veuillez remplir tous les champs ,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim DsERREURS As DataSet
            Dim L As Integer = 0
            DsERREURS = objchrgm.CHARGEMENT_PRINCIPAL(connexionForm.chcnx, connexionForm.chcnxbdder, INSCRIT_TextBox.Text, RATTRAPAGE_TextBox.Text, NOTE_TextBox.Text, MATIERE_TextBox.Text, FolderBrowserDialog1, L)
            If L = 0 Then 'si le chargement s'est bien passé on passe a l'importation des erreurs 
                Dim chem As String = "" 'contiendra le chemin de la nouvelle bdderreur qui est une copie de bdderreur 
                FolderBrowserDialog1.ShowDialog()
                chem = FolderBrowserDialog1.SelectedPath()
                Try 'copie du model bdd erreur dans le chemin selectionné 
                    My.Computer.FileSystem.CopyFile("..\BDDErreur.accdb", String.Concat(chem, "\BDDErreur.accdb"), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Dim bddcnx2 As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & String.Concat(chem, "\BDDErreur.accdb"))
                Try
                    bddcnx2.Open()
                    objchrgm.ImportErreurAccess(bddcnx2, DsERREURS) ' on importe les erreurs 
                    bddcnx2.Close()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    MessageBox.Show("Erreur de l'importation des tables d'erreur", "Echec", MessageBoxButtons.OK)
                End Try
            End If

        End If
    End Sub

#Region "differents boutons ( aide, acceuil, deconnexion)"
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
#End Region

    Private Sub BT_RETOURCHARGEMENT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RETOURCHARGEMENT.Click
        Chargement.Show()
        Me.Close()
    End Sub
End Class