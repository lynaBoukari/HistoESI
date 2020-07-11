Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class Modules_Recherche
    Public cleft As Integer = 0
    Public pair As Boolean = True
    Public repit As Integer = 0
    ' |-------------------------------------------[Recherche par Etudiant]----------------------------------------------|

    '[RechercheEtudiant]: Effectue la recherche d'un etudiant selon les criteres choisis
    Function RechercheEtudiant() As DataTable
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter
        Dim cmd As String = ""

        'Etablissement et ouverture de la connexion a la base de donnees
        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()

        'Implementation de la commande sql selon les champs de saisie
        cmd = genererSqlEtud()

        'Si tout les champs sont vides on arrete l'execution de la fonction et on affiche un message d'erreur
        If cmd Is Nothing Then
            Return Nothing
            Exit Function
        End If


        ds = New DataSet
        dataAdapter = New OleDbDataAdapter(cmd, cnx)
        dataAdapter.Fill(ds)


        'Verification de la presence des resultats
        If (ds.Tables(0).Rows.Count = 0) Then
            MessageBox.Show("Il n'existe aucun resultat", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        RechercheForm.etudPic.Visible = False
        RechercheForm.textPanel.Visible = False



        cnx.Close()

        Return ds.Tables(0)
    End Function

    'GenererSqlEtud: Genere la chaine de caractere pour la commande SQL, dans le cas de la recherche par etudiant
    Public Function genererSqlEtud() As String

        'slct va contenir la premiere partie de la commande
        Dim slct As String = "SELECT * FROM ETUDIANT WHERE "


        'strsql va conteir la suite de la commande selon la disponibilite de l'information dans les champs 
        Dim strsql As String = ""



        'Tests sur les champs de saisie et implementation de la suite de la commande
        If (String.IsNullOrEmpty(RechercheForm.MatriculeBox.Text) Or RechercheForm.MatriculeBox.Text = "Matricule") And (RechercheForm.yearBox.SelectedIndex = 0) And (RechercheForm.monthBox.SelectedIndex = 0) And (RechercheForm.dayBox.SelectedIndex = 0) And (String.IsNullOrEmpty(RechercheForm.NomBox.Text) Or RechercheForm.NomBox.Text = "Nom") And (String.IsNullOrEmpty(RechercheForm.PrenomBox.Text) Or RechercheForm.PrenomBox.Text = "Prénom") Then

            MessageBox.Show("Remplissez au moins un seul champs pour pouvoir effectuer la recherche.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        If (String.IsNullOrEmpty(RechercheForm.MatriculeBox.Text) = False) And (String.Compare(RechercheForm.MatriculeBox.Text, "Matricule") <> 0) Then
            strsql = "id_Etudiant= '" & RechercheForm.MatriculeBox.Text & "'"
        End If


        If (String.IsNullOrEmpty(RechercheForm.NomBox.Text) = False) And (String.Compare(RechercheForm.NomBox.Text, "Nom") <> 0) Then
            If String.IsNullOrEmpty(strsql) Then
                strsql = "NomEtud= '" & RechercheForm.NomBox.Text & "'"
            Else
                Console.WriteLine(String.Compare(RechercheForm.NomBox.Text, "Nom"))
                strsql = strsql + " AND NomEtud= '" & RechercheForm.NomBox.Text & "'"
            End If
        End If

        If ((String.IsNullOrEmpty(RechercheForm.PrenomBox.Text)) = False) And (String.Compare(RechercheForm.PrenomBox.Text, "Prénom") <> 0) Then
            If String.IsNullOrEmpty(strsql) Then
                strsql = "Prenoms= '" & RechercheForm.PrenomBox.Text & "'"
            Else
                strsql = strsql + " AND Prenoms= '" & RechercheForm.PrenomBox.Text & "'"
                Console.WriteLine(String.Compare(RechercheForm.PrenomBox.Text, "Prénom"))


            End If
        End If

        If ((RechercheForm.monthBox.SelectedIndex = -1) Or (RechercheForm.monthBox.SelectedIndex = 0)) And ((RechercheForm.dayBox.SelectedIndex = -1) Or (RechercheForm.dayBox.SelectedIndex = 0)) And ((RechercheForm.yearBox.SelectedIndex = -1) Or (RechercheForm.yearBox.SelectedIndex = 0)) Then
        Else
            If getDate() = Nothing Then
                Return Nothing
                Exit Function
            End If
            If String.IsNullOrEmpty(strsql) Then
                strsql = "DATENAIS= " & getDate()
            Else
                strsql = strsql + " AND DATENAIS= " & getDate()
            End If
        End If

            'Concatenation des deux chaines pour completer la commande
            strsql = slct & strsql
            Console.WriteLine("strsql: (" + strsql + ")")

            Return strsql
    End Function

    'getDate: Genere une chaine de caractere formant la date de naissance a partir de la saisie, dans le cas d'une recherche par etudiant
    Public Function getDate() As String
        Dim d As String = "'"

        If ((RechercheForm.dayBox.SelectedIndex <> -1) And (RechercheForm.dayBox.SelectedIndex <> 0)) Then
            d = d + RechercheForm.dayBox.Text
        End If

        If ((RechercheForm.monthBox.SelectedIndex <> -1) And (RechercheForm.monthBox.SelectedIndex <> 0)) Then
            d = d + "/" + RechercheForm.monthBox.Text
        End If
        If ((RechercheForm.yearBox.SelectedIndex <> -1) And (RechercheForm.yearBox.SelectedIndex <> 0)) Then
            d = d + "/" + RechercheForm.yearBox.Text.Substring(2)
        End If
        d = d + "'"
        If d.Length < 10 Then
            MessageBox.Show("Veuillez remplir tout les champs de la date de naissance.", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        Return d
    End Function
    'getDate: Genere une chaine de caractere formant la date de naissance a partir de la saisie, dans le cas de modification  par etudiant
    Public Function getDateModif() As String
        Dim d As String = ""

        If ((modifierForm.dayBox.SelectedIndex <> -1) And (modifierForm.dayBox.SelectedIndex <> 0)) Then
            d = d + modifierForm.dayBox.Text
        End If

        If ((modifierForm.monthBox.SelectedIndex <> -1) And (modifierForm.monthBox.SelectedIndex <> 0)) Then
            d = d + "/" + modifierForm.monthBox.Text
        End If
        If ((modifierForm.yearBox.SelectedIndex <> -1) And (modifierForm.yearBox.SelectedIndex <> 0)) Then
            d = d + "/" + modifierForm.yearBox.Text.Substring(2)
        End If

        If d.Length < 8 Then
            MessageBox.Show("Veuillez remplir tout les champs de la date de naissance.", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        Return d
    End Function

    '[AffichageRechEtudiant]: Effectue l'affichage des resultats de la recherche d'un etudiant
    Public Function affichageRechEtudiant(ByVal k As Integer) As Integer

        Dim d As DataTable = RechercheEtudiant()
        Dim j As Integer = 0
        If d Is Nothing Then

        Else

            Dim ds As New DataSet

            Dim i As Integer = 0
            Dim ResultDT As New DataTable
            ResultDT.Columns.Add("Id_Etudiant", GetType(String))
            ResultDT.Columns.Add("NomEtud", GetType(String))
            ResultDT.Columns.Add("Prenoms", GetType(String))
            ResultDT.Columns.Add("NomEtudA", GetType(String))
            ResultDT.Columns.Add("PrenomsA", GetType(String))
            ResultDT.Columns.Add("MATRIC_INS", GetType(String))
            ResultDT.Columns.Add("DATENAIS", GetType(String))
            ResultDT.Columns.Add("LIEUNAISA", GetType(String))
            ResultDT.Columns.Add("WILNAISA", GetType(String))
            ResultDT.Columns.Add("LIEUNAIS", GetType(String))
            ResultDT.Columns.Add("WILNAIS", GetType(String))
            ResultDT.Columns.Add("ADRESSE", GetType(String))
            ResultDT.Columns.Add("VILLE", GetType(String))
            ResultDT.Columns.Add("WILAYA", GetType(String))
            ResultDT.Columns.Add("CODPOST", GetType(String))
            ResultDT.Columns.Add("Cycle", GetType(String))
            ResultDT.Columns.Add("WILBAC", GetType(String))
            ResultDT.Columns.Add("SEXE", GetType(String))
            ResultDT.Columns.Add("SERIEBAC", GetType(String))
            ResultDT.Columns.Add("MOYBAC", GetType(String))
            ResultDT.Columns.Add("ANNEEBAC", GetType(String))
            ResultDT.Columns.Add("FILS_DE", GetType(String))
            ResultDT.Columns.Add("ET_DE", GetType(String))
            ResultDT.Columns.Add("Nb_ATTESTATION", GetType(String))
            ResultDT.Columns.Add("Nb_RNG", GetType(String))
            ds.Tables.Add(ResultDT)


            Try
                For Each row As DataRow In d.Rows()

                    If i > 6 Then

                        Dim ResultDTs As New DataTable

                        ResultDTs.Columns.Add("Id_Etudiant", GetType(String))
                        ResultDTs.Columns.Add("NomEtud", GetType(String))
                        ResultDTs.Columns.Add("Prenoms", GetType(String))
                        ResultDTs.Columns.Add("NomEtudA", GetType(String))
                        ResultDTs.Columns.Add("PrenomsA", GetType(String))
                        ResultDTs.Columns.Add("MATRIC_INS", GetType(String))
                        ResultDTs.Columns.Add("DATENAIS", GetType(String))
                        ResultDTs.Columns.Add("LIEUNAISA", GetType(String))
                        ResultDTs.Columns.Add("WILNAISA", GetType(String))
                        ResultDTs.Columns.Add("LIEUNAIS", GetType(String))
                        ResultDTs.Columns.Add("WILNAIS", GetType(String))
                        ResultDTs.Columns.Add("ADRESSE", GetType(String))
                        ResultDTs.Columns.Add("VILLE", GetType(String))
                        ResultDTs.Columns.Add("WILAYA", GetType(String))
                        ResultDTs.Columns.Add("CODPOST", GetType(String))
                        ResultDTs.Columns.Add("Cycle", GetType(String))
                        ResultDTs.Columns.Add("WILBAC", GetType(String))
                        ResultDTs.Columns.Add("SEXE", GetType(String))
                        ResultDTs.Columns.Add("SERIEBAC", GetType(String))
                        ResultDTs.Columns.Add("MOYBAC", GetType(String))
                        ResultDTs.Columns.Add("ANNEEBAC", GetType(String))
                        ResultDTs.Columns.Add("FILS_DE", GetType(String))
                        ResultDTs.Columns.Add("ET_DE", GetType(String))
                        ResultDTs.Columns.Add("Nb_ATTESTATION", GetType(String))
                        ResultDTs.Columns.Add("Nb_RNG", GetType(String))
                        ds.Tables.Add(ResultDTs)
                        ' j est le nombre de dataTable dans le dataSet ds
                        j = j + 1
                        i = 0
                    End If
                    ' on remplit la j eme table avec des ligne du resultet de la recherche

                    ds.Tables(j).ImportRow(row)
                    i = i + 1
                Next

                If (k <= j) Then


                    For Each row As DataRow In ds.Tables(k).Rows
                        rechPanel(row)
                    Next
                Else
                    MsgBox("La page :" & k + 1 & " n'éxiste pas !")
                    Return j
                    Exit Function
                End If
                cleft = 0
                pair = True

                d.Clear()
                ds.Dispose()
            Catch ex As Exception
                MsgBox(" exception is here ! ")
            End Try




        End If
        Return j
    End Function
    ' |------------------------------------------------------------------- ----------------------------------------------|


    ' |-------------------------------------------[Recherche par promotion]----------------------------------------------|

    '[RecherchePromo]: Effectue la recherche par promotion 
    Public Function RecherchePromo() As DataTable
        Dim cnx As OleDbConnection
        Dim ResultDT As New DataTable
        Dim dataAdapter As OleDbDataAdapter
        Dim cmd As String = ""

        'Etablissement et ouverture de la connexion a la base de donnees
        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()

        'Implementation de la commande sql selon les champs de saisie
        cmd = genererSqlPromo()

        'Si tout les champs sont vides on arrete l'execution de la fonction et on affiche un message d'erreur
        If cmd Is Nothing Then
            Return Nothing
            Exit Function
        End If

        'Construire les colonnes de la table des resultats
        ResultDT.Columns.Add("Id_Etudiant", GetType(String))
        ResultDT.Columns.Add("NomEtud", GetType(String))
        ResultDT.Columns.Add("Prenoms", GetType(String))
        ResultDT.Columns.Add("NomEtudA", GetType(String))
        ResultDT.Columns.Add("PrenomsA", GetType(String))
        ResultDT.Columns.Add("MATRIC_INS", GetType(String))
        ResultDT.Columns.Add("DATENAIS", GetType(String))
        ResultDT.Columns.Add("LIEUNAISA", GetType(String))
        ResultDT.Columns.Add("WILNAISA", GetType(String))
        ResultDT.Columns.Add("LIEUNAIS", GetType(String))
        ResultDT.Columns.Add("WILNAIS", GetType(String))
        ResultDT.Columns.Add("ADRESSE", GetType(String))
        ResultDT.Columns.Add("VILLE", GetType(String))
        ResultDT.Columns.Add("WILAYA", GetType(String))
        ResultDT.Columns.Add("CODPOST", GetType(String))
        ResultDT.Columns.Add("Cycle", GetType(String))
        ResultDT.Columns.Add("WILBAC", GetType(String))
        ResultDT.Columns.Add("SEXE", GetType(String))
        ResultDT.Columns.Add("SERIEBAC", GetType(String))
        ResultDT.Columns.Add("MOYBAC", GetType(String))
        ResultDT.Columns.Add("ANNEEBAC", GetType(String))
        ResultDT.Columns.Add("FILS_DE", GetType(String))
        ResultDT.Columns.Add("ET_DE", GetType(String))
        ResultDT.Columns.Add("Nb_ATTESTATION", GetType(String))
        ResultDT.Columns.Add("Nb_RNG", GetType(String))

        'Remplir le dataset ds avec les resultats
        dataAdapter = New OleDbDataAdapter(cmd, cnx)
        dataAdapter.Fill(ResultDT)

        'Verification de la presence des resultats
        If (ResultDT.Rows.Count = 0) Then
            MessageBox.Show("Il n'existe aucun resultat", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        RechercheForm.etudPic.Visible = False
        RechercheForm.textPanel.Visible = False

        cnx.Close()
        'MessageBox.Show("Traitement fini, affichage en cours..", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return ResultDT
    End Function

    '[genererSqlPromo]: Genere la chaine de caractere pour la commande SQL, dans le cas de la recherche par promotion
    Public Function genererSqlPromo() As String
        'slct va contenir la premiere partie de la commande
        Dim slct As String = "SELECT  ETUDIANT.Id_Etudiant , NomEtud, Prenoms  , NomEtudA , PrenomsA , MATRIC_INS , DATENAIS , LIEUNAISA , WILNAISA , LIEUNAIS , WILNAIS , ADRESSE , VILLE  , CODPOST , Cycle , WILBAC , SEXE , SERIEBAC , MOYBAC , ANNEEBAC , FILS_DE , ET_DE , Nb_ATTESTATION , Nb_RNG FROM ETUDIANT INNER JOIN PARCOURS ON ETUDIANT.Id_Etudiant = PARCOURS.Id_Etudiant WHERE "


        'strsql va conteir la suite de la commande selon la disponibilite de l'information dans les champs 
        Dim strsql As String = ""



        'Tests sur les champs de saisie et implementation de la suite de la commande
        If (RechercheForm.anetBox.SelectedIndex = 0) And (RechercheForm.anesBox.SelectedIndex = 0) Then
            MessageBox.Show("Saisissez L'année scolaire et l'année d'étude pour pouvoir effectuer la recherche.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        If (RechercheForm.anetBox.SelectedIndex = 0) And (RechercheForm.anesBox.SelectedIndex <> 0) Then
            MessageBox.Show("Saisissez l'année d'étude pour pouvoir effectuer la recherche.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If
        If (RechercheForm.anetBox.SelectedIndex <> 0) And (RechercheForm.anesBox.SelectedIndex = 0) Then
            MessageBox.Show("Saisissez l'année scolaire pour pouvoir effectuer la recherche.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        If (RechercheForm.anetBox.SelectedIndex <> -1) Then
            strsql = "PARCOURS.AnneeEtude= " & RechercheForm.anetBox.Text
        End If


        If (RechercheForm.anesBox.SelectedIndex <> 0) Then
            If String.IsNullOrEmpty(strsql) Then
                strsql = "PARCOURS.AnneeScolaire= '" & RechercheForm.anesBox.Text.Substring(2) & "'"
            Else
                strsql = strsql + " AND PARCOURS.AnneeScolaire= '" & RechercheForm.anesBox.Text.Substring(2) & "'"
            End If
        End If

        If (RechercheForm.optBox.SelectedIndex <> 0) Then
            If String.IsNullOrEmpty(strsql) Then
                strsql = "[Option]= '" & RechercheForm.optBox.Text & "'"
            Else
                If optionMisMatch(RechercheForm.anetBox.Text, RechercheForm.optBox.Text) Then
                    MessageBox.Show("L'option est incompatible avec l'année d'étude.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return Nothing
                    Exit Function
                End If
                strsql = strsql + " AND PARCOURS.[Option]= '" & RechercheForm.optBox.Text & "'"
            End If
        End If

        'Concatenation des deux chaines pour completer la commande
        strsql = slct & strsql
        Console.WriteLine("strsql: (" + strsql + ")")

        Return strsql
    End Function
    '[affichageRechPromo]: Effectue l'affichage des resultats de la recherche par promotion
    Public Function affichageRechPromo(ByVal k As Integer) As Integer

        Dim d As DataTable = RecherchePromo()
        Dim j As Integer = 0
        If d Is Nothing Then

        Else

            Dim ds As New DataSet

            Dim i As Integer = 0
            Dim ResultDT As New DataTable

            ResultDT.Columns.Add("Id_Etudiant", GetType(String))
            ResultDT.Columns.Add("NomEtud", GetType(String))
            ResultDT.Columns.Add("Prenoms", GetType(String))


            ResultDT.Columns.Add("NomEtudA", GetType(String))
            ResultDT.Columns.Add("PrenomsA", GetType(String))
            ResultDT.Columns.Add("MATRIC_INS", GetType(String))
            ResultDT.Columns.Add("DATENAIS", GetType(String))
            ResultDT.Columns.Add("LIEUNAISA", GetType(String))
            ResultDT.Columns.Add("WILNAISA", GetType(String))
            ResultDT.Columns.Add("LIEUNAIS", GetType(String))
            ResultDT.Columns.Add("WILNAIS", GetType(String))
            ResultDT.Columns.Add("ADRESSE", GetType(String))
            ResultDT.Columns.Add("VILLE", GetType(String))
            ResultDT.Columns.Add("WILAYA", GetType(String))
            ResultDT.Columns.Add("CODPOST", GetType(String))
            ResultDT.Columns.Add("Cycle", GetType(String))
            ResultDT.Columns.Add("WILBAC", GetType(String))
            ResultDT.Columns.Add("SEXE", GetType(String))
            ResultDT.Columns.Add("SERIEBAC", GetType(String))
            ResultDT.Columns.Add("MOYBAC", GetType(String))
            ResultDT.Columns.Add("ANNEEBAC", GetType(String))
            ResultDT.Columns.Add("FILS_DE", GetType(String))
            ResultDT.Columns.Add("ET_DE", GetType(String))
            ResultDT.Columns.Add("Nb_ATTESTATION", GetType(String))
            ResultDT.Columns.Add("Nb_RNG", GetType(String))
            ds.Tables.Add(ResultDT)


            Try
                For Each row As DataRow In d.Rows()

                    If i > 6 Then

                        Dim ResultDTs As New DataTable

                        ResultDTs.Columns.Add("Id_Etudiant", GetType(String))
                        ResultDTs.Columns.Add("NomEtud", GetType(String))
                        ResultDTs.Columns.Add("Prenoms", GetType(String))
                        ResultDTs.Columns.Add("NomEtudA", GetType(String))
                        ResultDTs.Columns.Add("PrenomsA", GetType(String))
                        ResultDTs.Columns.Add("MATRIC_INS", GetType(String))
                        ResultDTs.Columns.Add("DATENAIS", GetType(String))
                        ResultDTs.Columns.Add("LIEUNAISA", GetType(String))
                        ResultDTs.Columns.Add("WILNAISA", GetType(String))
                        ResultDTs.Columns.Add("LIEUNAIS", GetType(String))
                        ResultDTs.Columns.Add("WILNAIS", GetType(String))
                        ResultDTs.Columns.Add("ADRESSE", GetType(String))
                        ResultDTs.Columns.Add("VILLE", GetType(String))
                        ResultDTs.Columns.Add("WILAYA", GetType(String))
                        ResultDTs.Columns.Add("CODPOST", GetType(String))
                        ResultDTs.Columns.Add("Cycle", GetType(String))
                        ResultDTs.Columns.Add("WILBAC", GetType(String))
                        ResultDTs.Columns.Add("SEXE", GetType(String))
                        ResultDTs.Columns.Add("SERIEBAC", GetType(String))
                        ResultDTs.Columns.Add("MOYBAC", GetType(String))
                        ResultDTs.Columns.Add("ANNEEBAC", GetType(String))
                        ResultDTs.Columns.Add("FILS_DE", GetType(String))
                        ResultDTs.Columns.Add("ET_DE", GetType(String))
                        ResultDTs.Columns.Add("Nb_ATTESTATION", GetType(String))
                        ResultDTs.Columns.Add("Nb_RNG", GetType(String))
                        ds.Tables.Add(ResultDTs)
                        ' j est le nombre de dataTable dans le dataSet ds
                        j = j + 1
                        i = 0
                    End If
                    ' on remplit la j eme table avec des ligne du resultat de la recherche

                    ds.Tables(j).ImportRow(row)
                    i = i + 1
                Next

                '--------------------- verifier l'existance de la table voulue dans le data set---------------------------'
                If (k <= j) Then


                    For Each row As DataRow In ds.Tables(k).Rows
                        rechPanelPromo(row)

                    Next
                Else
                    MsgBox("La page :" & k + 1 & " n'éxiste pas !")
                    Return j
                    Exit Function
                End If
                cleft = 0
                pair = True

                d.Clear()
                ds.Dispose()
            Catch ex As Exception
                MsgBox(" exception is here ! ")
            End Try

        End If
        Return j
    End Function

    ' |--------------------------------------------------------------------------------------------------------------------|


    ' |-------------------------------------------[Autres]----------------------------------------------|
    ' verifie si l'option saisie est compatible avec l'annee d'etude

    Public Function optionMisMatch(ByVal anet As String, ByVal opt As String) As Boolean
        If (anet = "1" Or anet = "2") And (opt = "SI" Or opt = "SIQ") Then
                Return True
            Else
                Return False
            End If

        If (anet = "3" Or anet = "4" Or anet = "5") And (opt = "TRC") Then
            Return True
        Else
            Return False
        End If
    End Function
    'Renvoi une exception
    Private Function Exception() As Exception
        Throw New NotImplementedException
    End Function

    '----------------------------------------------------------------------------------------------'
    '------------------- Créer les panels (user control) du resultat de la recherche pour etudiant et remplir les infos necessaires ----------------------------'

    Public Sub rechPanel(ByVal row As DataRow)


        Dim ResulPanel As UserControl1 = New UserControl1

        ' ---------------- rendre la modification inacessible que par l'administrateur
        If (connexionForm.AuthPersonnelPanel.Visible) Then
            ResulPanel.ButtonModifier.Visible = False
        End If

        '----------------- generer les panels de recherche deux par ligne et remplir les champs d'informations'
        If (pair) Then
            RechercheForm.PanelBack.Controls.Add(ResulPanel)
            ResulPanel.Top = cleft * 180
            ResulPanel.Left = 30
            ResulPanel.LabelRechMatricule.Text = row("Id_Etudiant").ToString()
            ResulPanel.LabelRechNom.Text = row("NomEtud").ToString()
            ResulPanel.LabelRechPrenom.Text = row("Prenoms").ToString()
            ResulPanel.LabelRechDDN.Text = row("DATENAIS").ToString()

            pair = False
        Else
            RechercheForm.PanelBack.Controls.Add(ResulPanel)
            ResulPanel.Top = cleft * 180
            ResulPanel.Left = 500
            cleft = cleft + 1
            ResulPanel.LabelRechMatricule.Text = row("Id_Etudiant").ToString()
            ResulPanel.LabelRechNom.Text = row("NomEtud").ToString()
            ResulPanel.LabelRechPrenom.Text = row("Prenoms").ToString()
            ResulPanel.LabelRechDDN.Text = row("DATENAIS").ToString()

            pair = True
        End If



    End Sub



    '----------------------------------------------------------------------------------------------'
    '------------------- Créer les panels (user control) du resultat de la recherche pour promo et remplir les infos necessaires ----------------------------'

    Public Sub rechPanelPromo(ByVal row As DataRow)


        Dim ResulPanel As UserControl5 = New UserControl5

        ' ---------------- rendre la modification inacessible que par l'administrateur
        If (connexionForm.AuthPersonnelPanel.Visible) Then
            ResulPanel.ButtonModifier.Visible = False
        End If

        '----------------- generer les panels de recherche deux par ligne et remplir les champs d'informations'
        If (pair) Then
            RechercheForm.PanelBack.Controls.Add(ResulPanel)
            ResulPanel.Top = cleft * 190
            ResulPanel.Left = 30
            ResulPanel.LabelRechMatricule.Text = row("Id_Etudiant").ToString()
            ResulPanel.LabelRechNom.Text = row("NomEtud").ToString()
            ResulPanel.LabelRechPrenom.Text = row("Prenoms").ToString()
            ResulPanel.LabelRechDDN.Text = row("DATENAIS").ToString()

            pair = False
        Else
            RechercheForm.PanelBack.Controls.Add(ResulPanel)
            ResulPanel.Top = cleft * 190
            ResulPanel.Left = 500
            cleft = cleft + 1
            ResulPanel.LabelRechMatricule.Text = row("Id_Etudiant").ToString()
            ResulPanel.LabelRechNom.Text = row("NomEtud").ToString()
            ResulPanel.LabelRechPrenom.Text = row("Prenoms").ToString()
            ResulPanel.LabelRechDDN.Text = row("DATENAIS").ToString()

            pair = True
        End If



    End Sub

    '-------------------------------------------------------------------------------------------------------------------'
    '----------------------- Afficher les informations détaillées d'un étudiant ----------------------------------------'


    Public Sub detailsAff(ByVal row As DataRow)
        ' row est une ligne de d'une data table contenant les information tirées de la tables ETUDIANT ---'

        Try


            Details.nomBox.Text = row("NomEtud").ToString
            Details.LabelNomBleu.Text = row("NomEtud").ToString
            Details.prenomBox.Text = row("Prenoms").ToString()
            Details.LabelPrenomBleu.Text = row("Prenoms").ToString()
            Details.LabelmatriculeBleu.Text = row("Id_Etudiant").ToString()
            Details.nomABox.Text = row("NomEtudA").ToString()
            Details.prenomABox.Text = row("PrenomsA").ToString()
            Details.dateNaisBox.Text = row("DATENAIS").ToString()
            Details.lieunaisarabe.Text = row("LIEUNAISA").ToString() & " " & row("WILNAISA").ToString
            Details.Lieudenais.Text = row("LIEUNAIS").ToString & " wilaya " & row("WILNAIS").ToString
            Details.adresseBox.Text = row("ADRESSE").ToString() & " " & row("VILLE").ToString() & " " & row("WILAYA").ToString()
            If (row("SEXE") = 1) Then
                Details.sexebox.Text = " Masculin "
            Else
                Details.sexebox.Text = "Feminin "
            End If
            Details.TextBox1.Text = row("FILS_DE").ToString()
            Details.TextBox2.Text = row("ET_DE").ToString()
            Details.BacBox.Text = row("MOYBAC").ToString
            Details.wilBacBox.Text = row("WILBAC").ToString()
           
            Details.anneeBACbox.Text = row("ANNEEBAC").ToString


        Catch ex As NullReferenceException
            MsgBox("Exception catch here ..")
        Finally

        End Try


    End Sub
    '--------------------------------------------------------------------------------------------'
    '------------------- Afficher les informations détaillées d'un etudiant telles que dans la BDD pour pouvoir modifier '
    Public Sub modifierAff(ByVal row As DataRow)
        Try


            modifierForm.LabelmatriculeBleu.Text = row("Id_Etudiant").ToString()
            modifierForm.nomBox.Text = row("NomEtud").ToString()
            modifierForm.LabelNomBleu.Text = row("NomEtud").ToString()
            modifierForm.prenomBox.Text = row("Prenoms").ToString()
            modifierForm.LabelPrenomBleu.Text = row("Prenoms").ToString()
            modifierForm.nomABox.Text = row("NomEtudA").ToString()
            modifierForm.prenomABox.Text = row("PrenomsA").ToString()
            Dim ddn As String = row("DATENAIS").ToString()


            '*** decouper la date de naissance en 3 partie jour mois et annee afin de remplir les champs des combobox*****"
            Dim strArr() As String
            strArr = ddn.Split("/")
            modifierForm.dayBox.Text = strArr(0)
            modifierForm.monthBox.Text = strArr(1)
            If strArr(2) < "30" Then
                modifierForm.yearBox.Text = "20" + strArr(2)

            Else
                modifierForm.yearBox.Text = "19" + strArr(2)

            End If
            '----------------------------------------------------------------------------------------------'
            modifierForm.wilNaisBox.Text = row("LIEUNAIS").ToString()
            modifierForm.adresseBox.Text = row("ADRESSE").ToString()
            modifierForm.adrWilBox.Text = row("WILAYA").ToString()
            modifierForm.TextBox1.Text = row("FILS_DE").ToString()
            modifierForm.TextBox2.Text = row("ET_DE").ToString()
            modifierForm.lieunaisarabe.Text = row("LIEUNAISA").ToString
            modifierForm.wilnaisarabe.Text = row("WILNAISA").ToString
            modifierForm.lieunaisbox.Text = row("LIEUNAIS").ToString
            modifierForm.adrvillebox.Text = row("VILLE").ToString
        Catch ex As NullReferenceException
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------- Fonction qui aide a retrouver une ligne dans une data table par rapport a un matricule donné -----'

    Public Function TrouvRow(ByVal str As String, ByVal datatable As DataTable) As DataRow
        Dim trouv As Boolean = False
        Dim row As DataRow
        Try

            For Each row In datatable.Rows

                Dim mat As String = row("Id_Etudiant").ToString

                If (String.Equals(mat, str)) Then

                    trouv = True
                    Exit For

                End If
            Next

        Catch ex As NullReferenceException
            MsgBox("Exception catch here ..")
        Finally

        End Try


        Return row

    End Function

    '--------------------------------------------------------------------------------------------------------------------'
    '-------------------- Remplir la BDD avec les information modifiées qu'a saisie l'administrateur dans le form de Modification ----'
    Public Sub updateData()
        Dim myConnection As OleDbConnection = New OleDbConnection


        Try


            myConnection.ConnectionString = connexionForm.chcnx
            myConnection.Open()


            Dim str As String = "Update ETUDIANT SET NomEtud=?,Prenoms=?,NomEtudA=?,PrenomsA=?,DATENAIS=?,WILNAIS=?,ADRESSE=?,WILAYA=?,FILS_DE=?,ET_DE=?, VILLE=?, LIEUNAISA=?, WILNAISA=?, LIEUNAIS=?  where Id_Etudiant=?"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.AddWithValue("NomEtud", modifierForm.nomBox.Text)
            cmd.Parameters.AddWithValue("Prenoms", modifierForm.prenomBox.Text)
            cmd.Parameters.AddWithValue("NomEtudA", modifierForm.nomABox.Text)
            cmd.Parameters.AddWithValue("PrenomsA", modifierForm.prenomABox.Text)

            cmd.Parameters.AddWithValue("DATENAIS", getDateModif())

            cmd.Parameters.AddWithValue("WILNAIS", modifierForm.wilNaisBox.Text)
            cmd.Parameters.AddWithValue("ADRESSE", modifierForm.adresseBox.Text)
            cmd.Parameters.AddWithValue("WILAYAt", modifierForm.adrWilBox.Text)
            cmd.Parameters.AddWithValue("FILS_DE", modifierForm.TextBox1.Text)
            cmd.Parameters.AddWithValue("ET_DE", modifierForm.TextBox2.Text)
            cmd.Parameters.AddWithValue("VILLE", modifierForm.adrvillebox.Text)
            cmd.Parameters.AddWithValue("LIEUNAISA", modifierForm.lieunaisarabe.Text)
            cmd.Parameters.AddWithValue("LIEUNAIS", modifierForm.lieunaisbox.Text)
            cmd.Parameters.AddWithValue("WILNAISA", modifierForm.wilnaisarabe.Text)
            cmd.Parameters.AddWithValue("Id_Etudiant", modifierForm.LabelmatriculeBleu.Text)


            cmd.ExecuteNonQuery()

            cmd.Dispose()
            myConnection.Close()

            MsgBox(" Modification avec succès ! ", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub


End Class
