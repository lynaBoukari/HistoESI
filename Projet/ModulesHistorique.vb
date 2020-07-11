Imports System.Data.OleDb
Imports System.Data.DataSet
Public Class ModulesHistorique
    Dim cleft As Integer = 0
    Dim pair As Boolean = True
    Dim repit As Integer = 0



    '----------------------------------------------------------------------------------------------------'
    '-----------  donne une Data table contenant les informations de la Table Parcours d'un Etudiant precis ( par son matricule) --------'

    Function sortieHistoParcours(ByVal idEtud As String) As DataTable
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * from PARCOURS where id_Etudiant= '" & idEtud & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)


    End Function
    '---------------------------------------------------------------------------------------------'
    '------------ donne en sortie une data table de la table SPECIALITE pour tirer l'intitulé d'une année precise (par l'année d'etude et l'option)-----'

    Function sortieHistoSpecialite(ByVal annee As Integer, ByVal opt As String) As DataTable
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * from SPECIALITE where AnneeEtude= " & annee & " AND Option= '" & opt & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)




    End Function
    '---------------------------------------------------------------------------------------------------------------------'
    '------------------------- Affiche les informations relatives au tableau de parcours d'un etudiant ---------------------'
    Sub Histo(ByVal row As DataRowView)

        ' pour une ligne donnée on fait :

        '-------- Création des lignes du tableau de parcours -------'
        Dim c As UserControl3 = New UserControl3
        Historique.PanelTableau.Controls.Add(c)
        c.Top = repit * 35
        c.Left = 20
        '---------------------------------------------------------------'

        '----- remplir les champs par les informations tirées du Row de la table parcours -----'
        c.LabelGroupe.Text = row("Ngroupe").ToString
        c.LabelSection.Text = row("Nsection").ToString
        c.LabelNoteElim.Text = row("NbNoteElimin").ToString
        c.LabelAnneeNum.Text = row("AnneeEtude").ToString
        c.LabelAnneSco.Text = row("anneescolaire").ToString

        '---- remplir le champ de mention par les significations relatives au numéros donnés dans la table PARCOURS---'
        Dim ment As String = row("Mention").ToString

        If (ment = "0") Then
            c.LabelMention.Text = ""
        End If
        If (ment = "1") Then
            c.LabelMention.Text = "TRES BIEN"
        End If
        If (ment = "2") Then
            c.LabelMention.Text = "BIEN"
        End If

        If (ment = "3") Then
            c.LabelMention.Text = "ASSEZ BIEN"
        End If
        If (ment = "4") Then
            c.LabelMention.Text = "PASSABLE"
        End If

        If (ment = "6") Then
            c.LabelMention.Text = "RATTRAPAGE"

        End If
        If (ment = "7") Then
            c.LabelMention.Text = "ABANDON"

        End If
        If (ment = "8") Then
            c.LabelMention.Text = "REDOUBLE"

        End If
        '--------------------------------------------------------------------------------------------------------------------'

        '------ Ecrire les années scolaire sous forme de date ( 2020 au lieu de 02 comme figurent dans la table PARCOURS ) ---'
        Dim result As Integer
        Dim str1 As String = row("AnneeScolaire").ToString
        result = String.Compare(str1, "00")

        If (result >= 0) Then
            c.LabelAnnUniv.Text = "20" & row("AnneeScolaire").ToString
        End If

        result = String.Compare(str1, "80")
        If (result >= 0) Then

            c.LabelAnnUniv.Text = "19" & row("AnneeScolaire").ToString
        End If
        '-----------------------------------------------------------------------------------------------------------------------'


        '--------------- pour remplir l'intitulé de l'année d'etude en alphabet on accede à la table SPECIALITE ---------------'

        Dim data As DataTable = sortieHistoSpecialite(row("AnneeEtude"), row("Option").ToString)
        For Each rows As DataRow In data.Rows
            c.LabelAnnEtu.Text = rows("SpecificAttestation").ToString
        Next
        '---------------------------------------------------------------------------------------------------------------------------'

        '--------------- Remplir les champs de Resultat ( decision) dans le tableau parcours par leurs significations-----------------'

        Dim dec As String = row("DECIIN").ToString

        If (dec = "0") Then
            c.LabelRes.Text = ""
        End If
        If (dec = "1") Then
            c.LabelRes.Text = "ADMIS"
        End If
        If (dec = "2") Then
            c.LabelRes.Text = "Admis avec Rachat"
        End If

        If (dec = "3") Then
            c.LabelRes.Text = "Redouble"
        End If
        If ((dec = "5") Or (dec = "6")) Then
            c.LabelRes.Text = "Maladie ou Abandon"

        End If
        '----------------------------------------------------------------------------------------------------------------------------'

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------'
    '-------------------- Afichage final du tableau de parcours ( cursus) d'un etudiant---------------------------------------------------'

    Sub histoAff(ByVal table As DataTable)
        table.DefaultView.Sort = "AnneeScolaire ASC"

        For Each row As DataRowView In table.DefaultView
            Histo(row)
            repit = repit + 1
        Next
        repit = 0
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------'
    '--------------- Donne en sortie un data table de la table NOTE d'un etudiant precis en une année precise-----------------------------'
    Function sortieReleve(ByVal id As String, ByVal annee As Integer) As DataTable


        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * FROM [NOTE] WHERE AnneeEtude= " & annee & " AND Id_Etudiant= '" & id & "'"

        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)

    End Function
    '--------------------------------------------------------------------------------------------------------------'
    '----------------- Donne un data table contenant l'intitulé d'une matiere precisée par son Code -------------------'

    Function sortieMatiere(ByVal idMat As String) As DataTable


        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * FROM [MATIERE] WHERE Code= '" & idMat & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)

    End Function


    '-------------------------------------------------------------------------------------------------'
    '--------- Donne un data table contenant les informations relatives a une matiere dans une année precise ( car les coeff changent dans les années)---------------'
    Function sortieMoyenneMatiere(ByVal idMat As String, ByVal anneSco As String) As DataTable


        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * FROM [MOYENNEMATIERE] WHERE Code= '" & idMat & "' AND AnneeScolaire= '" & anneSco & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)

    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------------'
    '------- Creation du tableau de relevé de note par année pour un etudiant precis dans une année precise -------------------------------------'

    Sub releve(ByVal data As DataTable, ByRef idetud As String, ByRef anne As String, ByVal annesco As String)


        '----- pour chaque ligne de la table NOTE de cet etudiant on fait : ---------'
        For Each row As DataRow In data.Rows
            If (row("anneescolaire").Equals(annesco)) Then


                Dim tableparcour As DataTable = sortieHistoParcours(idetud)
                Dim tableMatiere As DataTable = sortieMatiere(row("Id_Matiere").ToString)
                Dim tableMoyenneMatiere As DataTable = sortieMoyenneMatiere(row("Id_Matiere").ToString, row("AnneeScolaire").ToString)

                '------ creer les lignes du tableau du relevé annuel--'
                Dim c As UserControl4 = New UserControl4
                Historique.PanelReleve.Controls.Add(c)
                c.Top = repit * 34
                c.Left = 25
                '-----------------------------------------------------'

                '-------remplir les champs par les informations de la table de NOTE -----------'
                c.LabelMoyJuin.Text = row("NoteJuin").ToString
                If (row("Elimine")) Then
                    c.LabelNoteElim.Text = "Oui"
                Else
                    c.LabelNoteElim.Text = "Non"
                End If

                '----------------------------------------------------------------------------'


                '------------------------ verifier si la moyenne de rattrapage est 0 donc l'etudiant n'as pas passer par le rattrapage--------'
                If (row("NoteRattrapage") = 0) Then
                    c.LabelMoyRattr.Text = "-"
                Else
                    c.LabelMoyRattr.Text = row("NoteRattrapage").ToString
                End If
                '-----------------------------------------------------------------------------------------------------------------------'


                '---------- remplir les informations de l'intitulé de chaque matiere dans cette année ------'
                For Each rows As DataRow In tableMatiere.Rows

                    c.LabelMatiere.Text = rows("Intitule").ToString
                Next
                '-------------------------------------------------------------------------------------'

                '--------- remplir les champs coefficients de chaque matiere de cette année --------------'
                For Each rowss As DataRow In tableMoyenneMatiere.Rows

                    c.LabelCoef.Text = rowss("CoefMat").ToString
                Next
                '---------------------------------------------------------------------------------------------'
                '------------------remplir le champs de moyenne annuelle et mention a partir de la table PARCOURS  -------------------------------'


                For Each rowss As DataRow In tableparcour.Rows

                    '--------------- verifier si la moyenne et de rattrapage pour afficger la plus grande----------------'

                    If (String.Equals(rowss("AnneeEtude").ToString, anne) And (row("anneescolaire").Equals(annesco))) Then
                        If (rowss("Moyenne") >= rowss("MOYENNE_RATTRAPAGE")) Then
                            Historique.LabelMoyAnnu.Text = rowss("Moyenne").ToString
                        Else
                            Historique.LabelMoyAnnu.Text = rowss("MOYENNE_RATTRAPAGE").ToString
                        End If
                        '------------------------------------------------------------------------------'

                        '------ Ecrire les années scolaire sous forme de date ( 2020 au lieu de 02 comme figurent dans la table PARCOURS ) ---'
                        Dim result As Integer
                        Dim str1 As String = rowss("AnneeScolaire").ToString

                        result = String.Compare(str1, "00")

                        If (result >= 0) Then
                            Historique.Labelannescolreleve.Text = "20" & row("AnneeScolaire").ToString
                        End If

                        result = String.Compare(str1, "80")
                        If (result >= 0) Then

                            Historique.Labelannescolreleve.Text = "19" & row("AnneeScolaire").ToString
                        End If


                        '----------- signification de la mention -----------------------'
                        Dim ment As String = rowss("Mention").ToString

                        If (ment = "0") Then
                            Historique.LabelMentionReleve.Text = ""
                        End If
                        If (ment = "1") Then
                            Historique.LabelMentionReleve.Text = "TRES BIEN"
                        End If
                        If (ment = "2") Then
                            Historique.LabelMentionReleve.Text = "BIEN"
                        End If

                        If (ment = "3") Then
                            Historique.LabelMentionReleve.Text = "ASSEZ BIEN"
                        End If
                        If (ment = "4") Then
                            Historique.LabelMentionReleve.Text = "PASSABLE"
                        End If

                        If (ment = "6") Then
                            Historique.LabelMentionReleve.Text = "RATTRAPAGE"

                        End If
                        If (ment = "7") Then
                            Historique.LabelMentionReleve.Text = "ABANDON"

                        End If
                        If (ment = "8") Then
                            Historique.LabelMentionReleve.Text = "REDOUBLE"

                        End If

                        '--------------------------------------------------------------------------------'
                        '---------- afficher l'année d'étude dans le relevé correspandant -------------------'
                        Dim specialite As DataTable = sortieHistoSpecialite(rowss("AnneeEtude"), rowss("Option").ToString)
                        For Each rows As DataRow In specialite.Rows
                            Historique.LabelAnnetreleve.Text = rows("SpecificAttestation").ToString
                        Next
                        '--------------------------------------------------------------------------------------------'


                    End If

                Next
                repit = repit + 1
            End If
        Next

        repit = 0


    End Sub
    '------------------------------------------AUTRES ------------------------------'
    Private Function Exception() As Exception
        Throw New NotImplementedException
    End Function
    '------------------------------------------------------------------------------------'

End Class
