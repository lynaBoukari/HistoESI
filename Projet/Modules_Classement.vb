Imports System.Data.OleDb
Imports System.Math
Public Class Classement_Modules


    '--------------------------------------------[Traitement]-----------------------------------------------------

    '[Trait_Classement]: Effectue le classement de fin de cursus des etudiant d'une annee scolaire donnee 
    Public Function Trait_Classement() As DataTable
        Dim cnx As OleDbConnection
        Dim dataAdapter As OleDbDataAdapter
        Dim cmd As String = ""

        'Etablissement et ouverture de la connexion a la base de donnees
        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()

        'Recherche des etudiants etant en 5eme annee a une annee scolaire donnee par l'utilisateur 
        Dim IdDT As New DataTable
        cmd = genererSqlID()

        'Si il y'a erreur a la saisie, on EXIT
        If cmd Is Nothing Then
            Return Nothing
            Exit Function
        End If

        'On remplit la table avec les ID des etudiants
        dataAdapter = New OleDbDataAdapter(cmd, cnx)
        dataAdapter.Fill(IdDT)

        'Verification de la presence des resultats
        If (IdDT.Rows.Count = 0) Then
            MessageBox.Show("Il n'existe aucun resultat", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        'text du chargement
        Classement.chgLabel.Text = "Chargement des résultas en cours ... "
        Classement.chgLabel.Location = New Point(130, 37)

        'Recherche du parcours des etudiants 
        Dim ParcoursDT As New DataTable

        'Implementation de la commande sql selon les champs de saisie
        cmd = genererSqlParcours()

        'Si il y'a erreur a la saise, on EXIT
        If cmd Is Nothing Then
            Return Nothing
            Exit Function
        End If

        'Remplissage la table
        dataAdapter = New OleDbDataAdapter(cmd, cnx)
        dataAdapter.Fill(ParcoursDT)


        'Recuperation de la table de rattrapage pour les etudiants concernees.
        Dim RattrapDT As New DataTable

        'Implementation de la commande sql selon les champs de saisie
        cmd = genererSqlRattrapage()

        'Si erreur a la saisie,  EXIT
        If cmd Is Nothing Then
            Return Nothing
            Exit Function
        End If

        'Remplissage de la table rattrapage
        dataAdapter = New OleDbDataAdapter(cmd, cnx)
        dataAdapter.Fill(RattrapDT)

        'Implementation de la table de classement, avec les informations requises
        Dim Classes As New DataTable

        Classes.Columns.Add("Rang", GetType(String))
        Classes.Columns.Add("Matricule", GetType(String))
        Classes.Columns.Add("Nom", GetType(String))
        Classes.Columns.Add("Prénoms", GetType(String))
        Classes.Columns.Add("Option", GetType(String))
        Classes.Columns.Add("1ère Juin", GetType(String))
        Classes.Columns.Add("1ère Sept", GetType(String))
        Classes.Columns.Add("2ème Juin", GetType(String))
        Classes.Columns.Add("2ème Sept", GetType(String))
        Classes.Columns.Add("3ème Juin", GetType(String))
        Classes.Columns.Add("3ème Sept", GetType(String))
        Classes.Columns.Add("4ème Juin", GetType(String))
        Classes.Columns.Add("4ème Sept", GetType(String))
        Classes.Columns.Add("5ème Juin", GetType(String))
        Classes.Columns.Add("5ème Sept", GetType(String))
        Classes.Columns.Add("Moyenne Générale", GetType(Double))

        'ErreurBDD permet de determiner si la table de la bdd est erronee ou incomplete
        Dim noRattrap As Boolean = False ' en cas d'absence de la note de rattrapage
        Dim moyenne0 As Boolean = False ' en cas d'absence d'une moyenne 

        Dim index As Integer = 0
        Dim id As String = ""
        Dim stopp As Integer = 0

        For Each row As DataRow In IDDT.Rows
            id = row("Id_Etudiant")
            Dim nom As String = ""
            Dim prenom As String = ""
            Dim opt As String = ""

            'Ji,si, et gi sont des variable contenant la moyenne de Juin, Septembre et Max(Juin,Sept) respectivement, pour i dans (1,2,3,4,5) annees d'etudes
            Dim J1 As Double = 0
            Dim s1 As Double = 0
            Dim g1 As Double = 0


            Dim J2 As Double = 0
            Dim s2 As Double = 0
            Dim g2 As Double = 0

            Dim J3 As Double = 0
            Dim s3 As Double = 0
            Dim g3 As Double = 0

            Dim J4 As Double = 0
            Dim s4 As Double = 0
            Dim g4 As Double = 0

            Dim J5 As Double = 0
            Dim s5 As Double = 0
            Dim g5 As Double = 0

            'G contient la moyenne generale des 5 annees 
            Dim g As Double = 0

            'On filtre la table parcours pour un etudiant donnee
            ParcoursDT.DefaultView.RowFilter = " Id_Etudiant='" & id & "'"

            'Pour chaque etudiant, on calcule sa moyenne generale, et on met les infos du classement dans la table Classement
            For Each rv As DataRowView In ParcoursDT.DefaultView
                nom = rv("NomEtud")
                prenom = rv("Prenoms")
                Select Case rv("AnneeEtude")
                    Case 1
                        J1 = rv("Moyenne")
                        If (rv("NbNoteElimin") > 0) Or (rv("NbRattrapage") > 0) Then
                            RattrapDT.DefaultView.RowFilter = " Id_Etudiant ='" & id & "' AND AnneeScolaire='" & rv("AnneeScolaire") & "'"
                            If RattrapDT.DefaultView.ToTable.Rows.Count > 0 Then
                                s1 = RattrapDT.DefaultView(0)("MoyenneRattrapage")
                                g1 = Max(s1, J1)
                            Else
                                noRattrap = True
                            End If
                        Else
                            g1 = J1
                        End If
                    Case 2
                        J2 = rv("Moyenne")
                        If (rv("NbNoteElimin") > 0) Or (rv("NbRattrapage") > 0) Then
                            RattrapDT.DefaultView.RowFilter = "Id_Etudiant ='" & id & "' AND AnneeScolaire='" & rv("AnneeScolaire") & "'"
                            If RattrapDT.DefaultView.ToTable.Rows.Count > 0 Then
                                s2 = RattrapDT.DefaultView(0)("MoyenneRattrapage")
                                g2 = Max(s2, J2)
                            Else
                                noRattrap = True
                            End If
                        Else
                            g2 = J2
                        End If
                    Case 3
                        J3 = rv("Moyenne")
                        If (rv("NbNoteElimin") > 0) Or (rv("NbRattrapage") > 0) Then
                            RattrapDT.DefaultView.RowFilter = "Id_Etudiant = '" & id & "' AND AnneeScolaire='" & rv("AnneeScolaire") & "'"
                            If RattrapDT.DefaultView.ToTable.Rows.Count > 0 Then
                                s3 = RattrapDT.DefaultView(0)("MoyenneRattrapage")
                                g3 = Max(s3, J3)
                            Else
                                noRattrap = True
                            End If
                        Else
                            g3 = J3
                        End If
                    Case 4
                        J4 = rv("Moyenne")
                        If (rv("NbNoteElimin") > 0) Or (rv("NbRattrapage") > 0) Then
                            RattrapDT.DefaultView.RowFilter = " Id_Etudiant = '" & id & "' AND AnneeScolaire='" & rv("AnneeScolaire") & "'"
                            If RattrapDT.DefaultView.ToTable.Rows.Count > 0 Then
                                s4 = RattrapDT.DefaultView(0)("MoyenneRattrapage")
                                g4 = Max(s4, J4)
                            Else
                                noRattrap = True
                            End If
                        Else
                            g4 = J4
                        End If
                    Case 5
                        J5 = rv("Moyenne")
                        opt = rv("Option")
                        If (rv("NbNoteElimin") > 0) Or (rv("NbRattrapage") > 0) Then
                            RattrapDT.DefaultView.RowFilter = " Id_Etudiant = '" & id & "' AND AnneeScolaire='" & rv("AnneeScolaire") & "'"
                            If RattrapDT.DefaultView.ToTable.Rows.Count > 0 Then
                                s5 = RattrapDT.DefaultView(0)("MoyenneRattrapage")
                                g5 = Max(s5, J5)
                            Else
                                noRattrap = True
                            End If
                        Else
                            g5 = J5
                        End If
                End Select

            Next

            'Calcul de la moyenne generale des 5 ans
            If g1 = 0 Or g2 = 0 Or g3 = 0 Or g4 = 0 Or g5 = 0 Then
                moyenne0 = True
            End If

            g = (g1 + g2 + g3 + g4 + g5) / 5
            g = Math.Round(g, 2)

            If g.ToString.Length > 5 Then
                g = CDbl((g.ToString).Substring(0, 5))
            End If

            'Insertion des informations recuperes dans la table Classement
            Classes.Rows.Add(0, id, nom, prenom, opt, ifzero(J1), ifzero(s1), ifzero(J2), ifzero(s2), ifzero(J3), ifzero(s3), ifzero(J4), ifzero(s4), ifzero(J5), ifzero(s5), g)

            stopp = stopp + 1

            If stopp = Classement.nbBox.Value Then
                Exit For
            End If
        Next

        If noRattrap = True Or moyenne0 = True Then
            MessageBox.Show("Il se peut que les résultats obtenus soient érronés à cause du manque de données dans la BDD:", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'Filtrage par ordre descendant des moyennes generales
        Classes.DefaultView.Sort = " Moyenne générale DESC "
        cnx.Close()
        Return Classes.DefaultView.ToTable
    End Function
   


    '[genererTable]: Renvoit un DataTable fournit avec les information specifies dans la commande
    Public Function genererTable(ByVal commande As String, ByRef DA As IDataAdapter, ByRef cnx As OleDbConnection) As DataTable
        Dim DT As New DataSet

        'Si il y'a erreur a la saisie, on EXIT
        If commande Is Nothing Then
            Return Nothing
            Exit Function
        End If

        'On remplit la table avec les ID des etudiants
        DA = New OleDbDataAdapter(commande, cnx)
        DA.Fill(DT)

        Return DT.Tables(0)
    End Function

    '--------------------------------------[Commandes SQL] ------------------------------------------

    '[genererSqlID]: Renvoit la chaine SQL qui sert de commande pour la recherche des ID
    Public Function genererSqlID() As String
        'slct va contenir la premiere partie de la command

        'strsql va conteir la suite de la commande selon la disponibilite de l'information dans les champs 
        Dim strsql As String = ""
        Dim CmdID As String = ""

        'Selection des etudiant admis de 5eme annee
        CmdID = " SELECT PARCOURS.Id_Etudiant FROM PARCOURS WHERE AnneeEtude= 5 AND ( DECIIN= '1' OR DECIIN= '2' ) "
        If (Classement.anesBox.SelectedIndex = 0) Then
            MessageBox.Show("Saisissez l'année scolaire pour pouvoir effectuer la recherche.", "Erreur de saisie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
            Exit Function
        End If

        'If Classement.anesBox.SelectedValue Then
        If (Classement.anesBox.SelectedIndex <> -1) Then
            CmdID = CmdID + "AND AnneeScolaire= '" & Classement.anesBox.Text.Substring(2) & "' "
        End If

        If (Classement.optBox.SelectedIndex <> -1) And (Classement.optBox.SelectedIndex <> 0) Then
            If String.IsNullOrEmpty(CmdID) Then
                CmdID = "[Option]= '" & Classement.optBox.Text & "' "
            Else
                CmdID = CmdID + " AND [Option]= '" & Classement.optBox.Text & "' "
            End If
        End If
        Console.WriteLine("strsql: " + CmdID)
        Return CmdID
    End Function
    '[genererSqlParcours]: Renvoit la chaine SQL qui sert de commande pour la recherche du parcours 
    Private Function genererSqlParcours() As String
        Dim cmdP As String = ""
        Dim CmdID As String = genererSqlID()

        If String.IsNullOrEmpty(CmdID) Then
            Return Nothing
            Exit Function
        End If
        cmdP = "SELECT ETUDIANT.Id_Etudiant, ETUDIANT.NomEtud, ETUDIANT.Prenoms, PARCOURS.AnneeScolaire, PARCOURS.AnneeEtude,PARCOURS.[OPTION], PARCOURS.Moyenne, PARCOURS.NbNoteElimin, PARCOURS.NbRattrapage, PARCOURS.DECIIN FROM PARCOURS INNER JOIN ETUDIANT ON PARCOURS.Id_Etudiant=ETUDIANT.Id_Etudiant " & _
               "WHERE PARCOURS.Id_Etudiant In (" + CmdID + ")"
        Return cmdP
    End Function
    '[genererSqlParcours]: Renvoit la chaine SQL qui sert de commande pour la recherche des moyennes de rattrapage
    Private Function genererSqlRattrapage() As String
        Dim cmdR As String = ""
        Dim CmdID As String = genererSqlID()

        If String.IsNullOrEmpty(CmdID) Then
            Return Nothing
            Exit Function
        End If
        cmdR = "SELECT RATTRAPAGE.Id_Etudiant, AnneeScolaire, MoyenneRattrapage FROM RATTRAPAGE " & _
               "WHERE RATTRAPAGE.Id_Etudiant In (" + CmdID + ") ORDER BY Id_Etudiant"
        Return cmdR
    End Function

    '----------------------------------------------[Affichage]---------------------------------------------
    '[affichageClassement]: affiche les resultats du classement dans un dataGridView
    Public Sub affichageClassement()
        Dim dgv As DataGridView
        Dim dt As DataTable

        dt = Trait_Classement()
        If dt Is Nothing Then
            Classement.DataGridView1.Visible = False
            Classement.textPanel.Visible = True
            Classement.podiumPic.Visible = True

            Exit Sub
        End If

        dgv = Classement.DataGridView1
        dgv.DataSource = dt

        'alterner les couleurs des rows
        For i As Integer = 0 To Classement.DataGridView1.RowCount - 1
            dt(i)("Rang") = i + 1
            If (i Mod 2) = 0 Then
                Classement.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242)
            Else
                Classement.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next

        Classement.DataGridView1.Columns(0).Width = 40
        Classement.DataGridView1.Columns(1).Width = 70
        Classement.DataGridView1.Columns(2).Width = 120
        Classement.DataGridView1.Columns(3).Width = 120
        Classement.DataGridView1.Columns(4).Width = 55
        Classement.DataGridView1.Columns(5).Width = 50
        Classement.DataGridView1.Columns(6).Width = 50
        Classement.DataGridView1.Columns(7).Width = 50
        Classement.DataGridView1.Columns(8).Width = 50
        Classement.DataGridView1.Columns(9).Width = 50
        Classement.DataGridView1.Columns(10).Width = 50
        Classement.DataGridView1.Columns(11).Width = 50
        Classement.DataGridView1.Columns(12).Width = 50
        Classement.DataGridView1.Columns(13).Width = 50
        Classement.DataGridView1.Columns(14).Width = 50
        Classement.DataGridView1.Columns(15).Width = 65

        dgv.Visible = True
        Classement.podiumPic.Visible = False
        Classement.textPanel.Visible = False
        If Classement.optBox.SelectedIndex = 0 Then
            Classement.anesoptLabel.Text = Classement.anesBox.Text
            Classement.anesoptLabel.Visible = True
        Else
            Classement.anesoptLabel.Text = Classement.anesBox.Text & "/" & Classement.optBox.Text
            Classement.anesoptLabel.Visible = True
        End If
        dgv.Sort(dgv.Columns(15), System.ComponentModel.ListSortDirection.Descending)
        Dim Etudiant As New DataTable
        Dim Parc As New DataTable
        Dim Grp As New DataTable
        With Etudiant
            .Columns.Add("Id_Etudiant")
            .Columns.Add("NomEtud")
            .Columns.Add("Prenoms")
            .Columns.Add("DATENAIS")
            .Columns.Add("WILNAIS")
            .Columns.Add("SERIEBAC")
            .Columns.Add("FILS_DE")
            .Columns.Add("ET_DE")
            .Columns.Add("MATRIC_INS")
            .Columns.Add("VILLE")
            .Columns.Add("WILAYA")
            .Columns.Add("CODPOST")
            .Columns.Add("Cycle")
            .Columns.Add("MOYBAC")

        End With
        With Parc
            .Columns.Add("Rang")
            .Columns.Add("Option")
        End With
        With Grp
            .Columns.Add("AnneeScolaire")
            .Columns.Add("Option")
        End With
        For Each dgr As DataGridViewRow In dgv.Rows
            Etudiant.Rows.Add(dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(5).Value, dgr.Cells(6).Value, dgr.Cells(7).Value, dgr.Cells(8).Value, dgr.Cells(9).Value, dgr.Cells(10).Value, dgr.Cells(11).Value, dgr.Cells(12).Value, dgr.Cells(13).Value, dgr.Cells(14).Value, dgr.Cells(15).Value)
        Next
        For Each dgr As DataGridViewRow In dgv.Rows
            Parc.Rows.Add(dgr.Cells(0).Value, dgr.Cells(4).Value)
        Next
        For Each dgr As DataGridViewRow In dgv.Rows
            Grp.Rows.Add(dgr.Cells(4).Value)
        Next
      
        For Each dr As DataRow In Grp.Rows
            If dr.Item("Option").ToString = "SI" Then
                dr.Item("Option") = "4eme année Ingénieur -SI"
            End If
            If dr.Item("Option").ToString = "SIQ" Then
                dr.Item("Option") = "4eme année Ingénieur -SIQ"
            End If
            dr.Item("AnneeScolaire") = Classement.anesoptLabel.Text
        Next
       
        'ml9itch kifah njiib année scolaire  mn classement n7atha fi datatable an 


        Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Rpt = New ClassImp
        Rpt.Database.Tables("ETUDIANT").SetDataSource(Etudiant)
        Rpt.Database.Tables("PARCOURS").SetDataSource(Parc)
        Rpt.Database.Tables("GROUPE").SetDataSource(Grp)
        Impression.CrystalReportViewer1.ReportSource = Rpt






    End Sub

    Public Function ifzero(ByVal n As Double) As String
        If n = 0 Then
            Return "-"
        Else
            Return n.ToString
        End If
    End Function
    Private Function Exception() As Exception
        Throw New NotImplementedException
    End Function


End Class
