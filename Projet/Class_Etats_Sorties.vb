
Public Class Class_Etats_Sorties



#Region "Traitement Releve de note global "
    Public Sub ReleveGlobal(ByVal Matricule As String)


        '----------- Donne 10 DataTables contenant les informations d'un Etudiant precis ( Par son Matricule ) --------'
        '--------------------------------------------------------------------------------------------------------------'





        'Ces deux requetes définis au desous (AccessNote et AccessParcours) sont utiliser pour afficher la table de note et la table obtenu d'aprés PARCOURS vides 
        'D'aprés La Base de donnees l'etudiant avec matricule = 00/0009 et AnneeEtude = 4 n'a pas des notes et meme pas des informations dans Table PARCOURS car il n'a pas 4 annee d'etude
        'Donc les tables affichées seront vides ( l'utilité de cette information , c'est dans le cas où un etudiant n'a pas etait admis dans tous les 5 annee d'etude 
        'Donc on affiche pas le releve de note global , et aprés affectation de ces requetes pour chaque annee d'Etude les tables seront vides. 

        Try
            Dim AccessNote, AccessParcours As New BDDControl
            AccessNote.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant = 00/0009 AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = 4 AND MOYENNEMATIERE.AnneeEtude=4 AND NOTE.AnneeEtude = 4 AND NOTE.AnneeScolaire = MOYENNEMATIERE.AnneeScolaire")
            AccessParcours.ExecQuery("Select SpecificAttestation,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = 00/0009 AND PARCOURS.AnneeEtude = 4 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=4 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")



            '-----------  Le 1er DataTable contient les informations de la Table ETUDIANT -----------'


            Dim Access As New BDDControl
            Access.ExecQuery(" Select Id_Etudiant,NomEtud,Prenoms, DATENAIS from [ETUDIANT] WHERE Id_Etudiant = '" & Matricule & "'")
            If Not String.IsNullOrEmpty(Access.Exception) Then MsgBox(Access.Exception) : Exit Sub
            Ets.DataGridView.DataSource = Access.DBDT


            Dim Etudiant As New DataTable
            With Etudiant
                .Columns.Add("Id_Etudiant")
                .Columns.Add("nomEtud")
                .Columns.Add("Prenoms")
                .Columns.Add("DATANAIS")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView.Rows
                Etudiant.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
            Next


            '-----------  Le 2eme DataTable contient les informations des Tables MATIERE,MOYENNEMATIERE et NOTE pour la 1er Annee d'Etude ---------'


            Dim Access1 As New BDDControl
            Access1.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant = '" & Matricule & "' AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = 1 AND MOYENNEMATIERE.AnneeEtude=1 AND NOTE.AnneeEtude = 1 AND NOTE.AnneeScolaire = MOYENNEMATIERE.AnneeScolaire")
            If Not String.IsNullOrEmpty(Access1.Exception) Then MsgBox(Access1.Exception) : Exit Sub
            Dim not1 As New DataTable
            With not1
                .Columns.Add("Id_Matiere")
                .Columns.Add("noteSynthese")
                .Columns.Add("NoteJuin")
                .Columns.Add("NoteRattrapage")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView1.Rows
                not1.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
            Next


            '-----------  Le 3eme DataTable contient les informations de la Table PARCOURS pour la 1er Annee d'Etude ---------'


            Dim Access6 As New BDDControl
            Access6.ExecQuery("Select SpecificReleve,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = '" & Matricule & "' AND PARCOURS.AnneeEtude = 1 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=1 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")
            Ets.DataGridView5.DataSource = Access6.DBDT

            For i As Integer = 0 To Ets.DataGridView5.Rows.Count - 1
                If Ets.DataGridView5.Rows(i).Cells(1).Value IsNot Nothing Then


                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView5.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView5.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next



            For i As Integer = 0 To Ets.DataGridView5.Rows.Count - 1

                If (Ets.DataGridView5.Rows(i).Cells(4).Value = ("0")) Then
                    Ets.DataGridView5.Rows(i).Cells(4).Value = ("")

                End If
                If (Ets.DataGridView5.Rows(i).Cells(4).Value = ("1")) Then
                    Ets.DataGridView5.Rows(i).Cells(4).Value = ("Admis")

                End If
                If (Ets.DataGridView5.Rows(i).Cells(4).Value = ("2")) Then
                    Ets.DataGridView5.Rows(i).Cells(4).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView5.Rows(i).Cells(4).Value = ("3")) Then
                    Ets.DataGridView5.Rows(i).Cells(4).Value = ("Redouble")

                End If
                If (Ets.DataGridView5.Rows(i).Cells(4).Value = ("4")) Then
                    Ets.DataGridView5.Rows(i).Cells(4).Value = ("Non admis")

                End If
            Next i


            Dim Parc1 As New DataTable
            With Parc1
                .Columns.Add("SpecificReleve")
                .Columns.Add("AnneeScolaire")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
                .Columns.Add("MOYENNE_RATTRAPAGE")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView5.Rows
                Parc1.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
            Next
            Dim sp1 As New DataTable
            With sp1
                .Columns.Add("SpecificReleve")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView5.Rows
                sp1.Rows.Add(dgr.Cells(0).Value)
            Next


            '-----------  Le 4eme DataTable contient les informations des Tables MATIERE,MOYENNEMATIERE et NOTE pour la 2eme Annee d'Etude ---------'


            Dim Access2 As New BDDControl
            Access2.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant = '" & Matricule & "' AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = 2 AND MOYENNEMATIERE.AnneeEtude=2 AND NOTE.AnneeEtude = 2 AND NOTE.AnneeScolaire = MOYENNEMATIERE.AnneeScolaire")
            If Not String.IsNullOrEmpty(Access2.Exception) Then MsgBox(Access2.Exception) : Exit Sub
            Ets.DataGridView2.DataSource = Access2.DBDT
            Dim note2 As New DataTable
            With note2
                .Columns.Add("Id_Matiere")
                .Columns.Add("noteSynthese")
                .Columns.Add("NoteJuin")
                .Columns.Add("NoteRattrapage")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView2.Rows
                note2.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
            Next


            '-----------  Le 5eme DataTable contient les informations de la Table PARCOURS pour la 2eme Annee d'Etude ---------'


            Dim Access8 As New BDDControl
            Access8.ExecQuery("Select SpecificReleve,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = '" & Matricule & "' AND PARCOURS.AnneeEtude = 2 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=2 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")
            Ets.DataGridView7.DataSource = Access8.DBDT

            For i As Integer = 0 To Ets.DataGridView7.Rows.Count - 1
                If Ets.DataGridView7.Rows(i).Cells(1).Value IsNot Nothing Then


                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView7.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView7.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next
            For i As Integer = 0 To Ets.DataGridView7.Rows.Count - 1

                If (Ets.DataGridView7.Rows(i).Cells(4).Value = ("0")) Then
                    Ets.DataGridView7.Rows(i).Cells(4).Value = ("")

                End If
                If (Ets.DataGridView7.Rows(i).Cells(4).Value = ("1")) Then
                    Ets.DataGridView7.Rows(i).Cells(4).Value = ("Admis")

                End If
                If (Ets.DataGridView7.Rows(i).Cells(4).Value = ("2")) Then
                    Ets.DataGridView7.Rows(i).Cells(4).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView7.Rows(i).Cells(4).Value = ("3")) Then
                    Ets.DataGridView7.Rows(i).Cells(4).Value = ("Redouble")

                End If
                If (Ets.DataGridView7.Rows(i).Cells(4).Value = ("4")) Then
                    Ets.DataGridView7.Rows(i).Cells(4).Value = ("Non admis")

                End If
            Next i

            Dim Parc2 As New DataTable
            With Parc2
                .Columns.Add("SpecificReleve")
                .Columns.Add("AnneeScolaire")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
                .Columns.Add("MOYENNE_RATTRAPAGE")
            End With

            For Each dgr As DataGridViewRow In Ets.DataGridView7.Rows
                Parc2.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
            Next
            Dim sp2 As New DataTable
            With sp2
                .Columns.Add("SpecificReleve")
            End With

            For Each dgr As DataGridViewRow In Ets.DataGridView7.Rows
                sp2.Rows.Add(dgr.Cells(0).Value)
            Next


            '-----------  Le 6eme DataTable contient les informations des Tables MATIERE,MOYENNEMATIERE et NOTE pour la 3eme Annee d'Etude ---------'


            Dim Access3 As New BDDControl
            Access3.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant ='" & Matricule & "' AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = 3 AND MOYENNEMATIERE.AnneeEtude=3 AND NOTE.AnneeEtude = 3 AND NOTE.AnneeScolaire = MOYENNEMATIERE.AnneeScolaire")
            If Not String.IsNullOrEmpty(Access3.Exception) Then MsgBox(Access2.Exception) : Exit Sub
            Ets.DataGridView3.DataSource = Access3.DBDT
            Dim note3 As New DataTable
            With note3
                .Columns.Add("Id_Matiere")
                .Columns.Add("noteSynthese")
                .Columns.Add("NoteJuin")
                .Columns.Add("NoteRattrapage")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView3.Rows
                note3.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
            Next


            '-----------  Le 7eme DataTable contient les informations de la Table PARCOURS pour la 3eme Annee d'Etude ---------'


            Dim Access9 As New BDDControl
            Access9.ExecQuery("Select SpecificReleve,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = '" & Matricule & "' AND PARCOURS.AnneeEtude = 3 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=3 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")
            Ets.DataGridView8.DataSource = Access9.DBDT

            For i As Integer = 0 To Ets.DataGridView8.Rows.Count - 1
                If Ets.DataGridView8.Rows(i).Cells(1).Value IsNot Nothing Then

                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView8.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView8.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next
            For i As Integer = 0 To Ets.DataGridView8.Rows.Count - 1

                If (Ets.DataGridView8.Rows(i).Cells(4).Value = ("0")) Then
                    Ets.DataGridView8.Rows(i).Cells(4).Value = ("")

                End If
                If (Ets.DataGridView8.Rows(i).Cells(4).Value = ("1")) Then
                    Ets.DataGridView8.Rows(i).Cells(4).Value = ("Admis")

                End If
                If (Ets.DataGridView8.Rows(i).Cells(4).Value = ("2")) Then
                    Ets.DataGridView8.Rows(i).Cells(4).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView8.Rows(i).Cells(4).Value = ("3")) Then
                    Ets.DataGridView8.Rows(i).Cells(4).Value = ("Redouble")

                End If
                If (Ets.DataGridView8.Rows(i).Cells(4).Value = ("4")) Then
                    Ets.DataGridView8.Rows(i).Cells(4).Value = ("Non admis")

                End If
            Next i

            Dim Parc3 As New DataTable
            With Parc3
                .Columns.Add("SpecificReleve")
                .Columns.Add("AnneeScolaire")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
                .Columns.Add("MOYENNE_RATTRAPAGE")

            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView8.Rows
                Parc3.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
            Next
            Dim sp3 As New DataTable
            With sp3
                .Columns.Add("SpecificReleve")
            End With

            For Each dgr As DataGridViewRow In Ets.DataGridView8.Rows
                sp3.Rows.Add(dgr.Cells(0).Value)
            Next


            '-----------  Le 8eme DataTable contient les informations des Tables MATIERE,MOYENNEMATIERE et NOTE pour la 4ème Annee d'Etude ---------'


            Dim Access4 As New BDDControl
            Access4.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant = '" & Matricule & "' AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = 4 AND MOYENNEMATIERE.AnneeEtude=4 AND NOTE.AnneeEtude = 4 AND NOTE.AnneeScolaire = MOYENNEMATIERE.AnneeScolaire")
            If Not String.IsNullOrEmpty(Access4.Exception) Then MsgBox(Access4.Exception) : Exit Sub
            Ets.DataGridView4.DataSource = Access4.DBDT
            Dim note4 As New DataTable
            With note4
                .Columns.Add("Id_Matiere")
                .Columns.Add("noteSynthese")
                .Columns.Add("NoteJuin")
                .Columns.Add("NoteRattrapage")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView4.Rows
                note4.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
            Next


            '-----------  Le 9eme DataTable contient les informations de la Table PARCOURS pour la 4eme Annee d'Etude ---------'


            Dim Access7 As New BDDControl
            Access7.ExecQuery("Select SpecificReleve,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = '" & Matricule & "' AND PARCOURS.AnneeEtude = 4 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=4 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")
            Ets.DataGridView9.DataSource = Access7.DBDT


            For i As Integer = 0 To Ets.DataGridView9.Rows.Count - 1
                If Ets.DataGridView9.Rows(i).Cells(1).Value IsNot Nothing Then

                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView9.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView9.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next
            For i As Integer = 0 To Ets.DataGridView9.Rows.Count - 1

                If (Ets.DataGridView9.Rows(i).Cells(4).Value = ("0")) Then
                    Ets.DataGridView9.Rows(i).Cells(4).Value = ("")

                End If
                If (Ets.DataGridView9.Rows(i).Cells(4).Value = ("1")) Then
                    Ets.DataGridView9.Rows(i).Cells(4).Value = ("Admis")

                End If
                If (Ets.DataGridView9.Rows(i).Cells(4).Value = ("2")) Then
                    Ets.DataGridView9.Rows(i).Cells(4).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView9.Rows(i).Cells(4).Value = ("3")) Then
                    Ets.DataGridView9.Rows(i).Cells(4).Value = ("Redouble")

                End If
                If (Ets.DataGridView9.Rows(i).Cells(4).Value = ("4")) Then
                    Ets.DataGridView9.Rows(i).Cells(4).Value = ("Non admis")

                End If
            Next i
            Dim Parc4 As New DataTable
            With Parc4
                .Columns.Add("AnneeScolaire")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
                .Columns.Add("MOYENNE_RATTRAPAGE")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView9.Rows
                Parc4.Rows.Add(dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
            Next

            Dim sp4 As New DataTable
            With sp4
                .Columns.Add("SpecificReleve")

            End With

            For Each dgr As DataGridViewRow In Ets.DataGridView9.Rows
                sp4.Rows.Add(dgr.Cells(0).Value)
            Next
            '-----------  Le 10eme DataTable contient les informations de la Table PARCOURS pour la 5eme Annee d'Etude ---------'


            Dim Access5A As New BDDControl
            Access5A.ExecQuery("Select SpecificReleve,AnneeScolaire,Moyenne,Rang,DECIIN,MOYENNE_RATTRAPAGE from [PARCOURS],[SPECIALITE]  WHERE Id_Etudiant = '" & Matricule & "' AND PARCOURS.AnneeEtude = 5 AND (PARCOURS.DECIIN = '1' OR PARCOURS.DECIIN = '2') AND SPECIALITE.AnneeEtude=5 AND PARCOURS.Option = SPECIALITE.Option AND PARCOURS.AnneeEtude = SPECIALITE.AnneeEtude ")
            Ets.DataGridView10.DataSource = Access5A.DBDT

            For i As Integer = 0 To Ets.DataGridView10.Rows.Count - 1
                If Ets.DataGridView10.Rows(i).Cells(1).Value IsNot Nothing Then


                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView10.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView10.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next
            For i As Integer = 0 To Ets.DataGridView10.Rows.Count - 1

                If (Ets.DataGridView10.Rows(i).Cells(4).Value = ("0")) Then
                    Ets.DataGridView10.Rows(i).Cells(4).Value = ("")

                End If
                If (Ets.DataGridView10.Rows(i).Cells(4).Value = ("1")) Then
                    Ets.DataGridView10.Rows(i).Cells(4).Value = ("Admis")

                End If
                If (Ets.DataGridView10.Rows(i).Cells(4).Value = ("2")) Then
                    Ets.DataGridView10.Rows(i).Cells(4).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView10.Rows(i).Cells(4).Value = ("3")) Then
                    Ets.DataGridView10.Rows(i).Cells(4).Value = ("Redouble")

                End If
                If (Ets.DataGridView10.Rows(i).Cells(4).Value = ("4")) Then
                    Ets.DataGridView10.Rows(i).Cells(4).Value = ("Non admis")

                End If
            Next i
            Dim Parc5 As New DataTable
            With Parc5
                .Columns.Add("AnneeScolaire")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
                .Columns.Add("MOYENNE_RATTRAPAGE")
            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView10.Rows
                Parc5.Rows.Add(dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
            Next

            Dim sp5 As New DataTable
            With sp5
                .Columns.Add("SpecificReleve")

            End With


            'Avec cette condition "if" on vérifier si l'etudiant a étudier 5 annee d'etude et est-ce-qui'il a était admis pour chaque annee d'etude
            'Si c'est le cas on affiche le releve de note global de l'etudiant sinon on affiche rien 
            ' le cas où l'etudiant n'etait pas admis pour une annee d'etude et qui a avoir son 5eme anne , ce cas est aussi vèrifier ( on affiche juste les 5 annee d'etude ou il a était admis )

            'Ets.DataGridView5.Rows.Count = 2 ,ie : la table obtenu d'aprés PARCOURS aprés la commande SQL contient 2 lignes , cette condition signifie que le resultat de la table parcours pour une annee d'etude precise existe (vrai) 
            'ie : l'étudiant a était admis , alors on affiche leur parcours durant cette annee d'etude 


            If ((Ets.DataGridView5.Rows.Count = 2) And (Ets.DataGridView7.Rows.Count = 2) And (Ets.DataGridView8.Rows.Count = 2) And (Ets.DataGridView9.Rows.Count = 2) And (Ets.DataGridView10.Rows.Count = 2)) Then
                Ets.DataGridView.DataSource = Access.DBDT
                Ets.DataGridView1.DataSource = Access1.DBDT
                Ets.DataGridView5.DataSource = Access6.DBDT
                Ets.DataGridView2.DataSource = Access2.DBDT
                Ets.DataGridView7.DataSource = Access8.DBDT
                Ets.DataGridView3.DataSource = Access3.DBDT
                Ets.DataGridView8.DataSource = Access9.DBDT
                Ets.DataGridView4.DataSource = Access4.DBDT
                Ets.DataGridView9.DataSource = Access7.DBDT
                Ets.DataGridView10.DataSource = Access5A.DBDT
                Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt = New ReleveGlobale

                Rpt.Database.Tables("ETUDIANT").SetDataSource(Etudiant)

                Rpt.Subreports.Item("Sub1").Database.Tables("Note").SetDataSource(not1)
                Rpt.Subreports.Item("Sub1").Database.Tables("PARCOURS").SetDataSource(Parc1)
                Rpt.Subreports.Item("Sub1").Database.Tables("SPECIALITE").SetDataSource(sp1)
                Rpt.Subreports.Item("Sub2").Database.Tables("Note").SetDataSource(note2)
                Rpt.Subreports.Item("Sub2").Database.Tables("PARCOURS").SetDataSource(Parc2)
                Rpt.Subreports.Item("Sub2").Database.Tables("SPECIALITE").SetDataSource(sp2)
                Rpt.Subreports.Item("Sub3").Database.Tables("Note").SetDataSource(note3)
                Rpt.Subreports.Item("Sub3").Database.Tables("PARCOURS").SetDataSource(Parc3)
                Rpt.Subreports.Item("Sub3").Database.Tables("SPECIALITE").SetDataSource(sp3)
                Rpt.Subreports.Item("Sub4").Database.Tables("Note").SetDataSource(note4)
                Rpt.Subreports.Item("Sub4").Database.Tables("SPECIALITE").SetDataSource(sp4)
                Rpt.Subreports.Item("Sub4").Database.Tables("PARCOURS").SetDataSource(Parc4)
                Rpt.Subreports.Item("Sub").Database.Tables("PARCOURS").SetDataSource(Parc5)
                Rpt.Subreports.Item("Sub").Database.Tables("SPECIALITE").SetDataSource(sp5)
                ReleveGlobalF.CrystalReportViewer1.ReportSource = Rpt
                ReleveGlobalF.CrystalReportViewer1.Refresh()
               


            Else
                ' Ets.DataGridView1.DataSource = AccessNote.DBDT , On ytilise cette methode si la table obtenu d'aprés PARCOURS ne contient pas 2 lignes (etudiant pas admis , selon la cmd sql ) , alors on laisse la table vide 
                'on a utiliser la commande sql  AccessNote et AccessParcours qui sont définis au desus , où on a utiliser une information qui existe dans la base de donnees , 
                'où la table des Notes obtenu et la table obtenu d'aprés parcours sont vides et c'est pour la matricule = 00/0009 et AnneeEtude = 4 

                Ets.DataGridView1.DataSource = AccessNote.DBDT
                Ets.DataGridView5.DataSource = AccessParcours.DBDT
                Ets.DataGridView2.DataSource = AccessNote.DBDT
                Ets.DataGridView7.DataSource = AccessParcours.DBDT
                Ets.DataGridView3.DataSource = AccessNote.DBDT
                Ets.DataGridView8.DataSource = AccessParcours.DBDT
                Ets.DataGridView4.DataSource = AccessNote.DBDT
                Ets.DataGridView9.DataSource = AccessParcours.DBDT
                Ets.DataGridView10.DataSource = AccessParcours.DBDT

            End If
            ReleveGlobalF.ShowDialog()
            ReleveGlobalF.Dispose()
        Catch ex As Exception
            MsgBox(" Veuillez redemarer l'application ")
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region

#Region "Traitement Releve de note simple "
    Public Sub ReleveSimple(ByVal Matricule As String, ByVal AnneeEtude As Integer, ByVal AnneeScolaire As String)

        '----------- Donne 3 DataTable (pour le releve de note simple) contenant les informations d'un Etudiant precis ( par son Matricule,son AnneeEtude et son AnneeScolaire ) --------'
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------'



        '-----------  Le 1er DataTable contient les informations de la Table ETUDIANT -----------'


        Dim Access As New BDDControl
        Access.ExecQuery(" Select Id_Etudiant,NomEtud,Prenoms from [ETUDIANT] WHERE Id_Etudiant ='" & Matricule & "' ")
        Ets.DataGridView.DataSource = Access.DBDT
        Dim dt As New DataTable
        dt.TableName = "dt"
        dt = Access.DBDT
        Ets.DataGridView.DataSource = dt




        '-----------  Le 2eme DataTable contient les informations de la Table Parcours --------'



        Dim Access1 As New BDDControl
        Access1.ExecQuery(" Select id_Etudiant,AnneeScolaire,AnneeEtude,Option,Moyenne,Rang,DECIIN from [PARCOURS] WHERE id_Etudiant = '" & Matricule & "' AND AnneeScolaire ='" & AnneeScolaire & "' AND AnneeEtude =" & AnneeEtude & "")
        If Not String.IsNullOrEmpty(Access1.Exception) Then MsgBox(Access1.Exception) : Exit Sub
        Ets.DataGridView1.DataSource = Access1.DBDT
        Try
            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1
                If Ets.DataGridView1.Rows(i).Cells(1).Value IsNot Nothing Then

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2012/2013"
                    End If
                End If
            Next

            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1

                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("0")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("1")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("Admis")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("2")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("Admis avec rachat")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("3")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("Redouble")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("4")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("Non admis")

                End If
            Next i
            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1

                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("TRC")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("<<Tronc Commun>>")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("SIQ")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("<<Systém informatique>")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("SI")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("<<Systém d'information>>")

                End If
            Next i




            '----------- Le 3eme DataTable contient les informations des Tables : MATIERE,MOYENNEMATIERE et NOTE -------'



            Dim Access2 As New BDDControl
            Access2.ExecQuery("Select Intitule,CoefMat,NoteJuin,NoteRattrapage from [MATIERE],[MOYENNEMATIERE],[NOTE]  WHERE Id_Etudiant ='" & Matricule & "' AND MATIERE.Code =  NOTE.Id_Matiere AND MOYENNEMATIERE.Code = NOTE.Id_Matiere AND MOYENNEMATIERE.Code = MATIERE.Code   AND MATIERE.Option = NOTE.Option  AND MOYENNEMATIERE.Option = NOTE.Option AND  MATIERE.AnneeEtude = " & AnneeEtude & " AND MOYENNEMATIERE.AnneeEtude= " & AnneeEtude & " AND NOTE.AnneeEtude =" & AnneeEtude & " AND NOTE.AnneeScolaire ='" & AnneeScolaire & "' AND MOYENNEMATIERE.AnneeScolaire ='" & AnneeScolaire & "' ")
            If Not String.IsNullOrEmpty(Access2.Exception) Then MsgBox(Access2.Exception) : Exit Sub
            Ets.DataGridView2.DataSource = Access2.DBDT

            Dim Etudiant As New DataTable
            With Etudiant
                .Columns.Add("Id_Etudiant")
                .Columns.Add("nomEtud")
                .Columns.Add("Prenoms")
            End With

            For Each dgr As DataGridViewRow In Ets.DataGridView.Rows
                Etudiant.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value)
            Next
            Dim Parc As New DataTable
            With Parc
                .Columns.Add("Id_Etudiant")
                .Columns.Add("AnneeScolaire")
                .Columns.Add("AnneeEtude")
                .Columns.Add("Option")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")
            End With

            For Each dgr1 As DataGridViewRow In Ets.DataGridView1.Rows
                Parc.Rows.Add(dgr1.Cells(0).Value, dgr1.Cells(1).Value, dgr1.Cells(2).Value, dgr1.Cells(3).Value, dgr1.Cells(4).Value, dgr1.Cells(5).Value, dgr1.Cells(6).Value)
            Next
            Dim grp As New DataTable
            With grp
                .Columns.Add("AnneeScolaire")
                .Columns.Add("AnneeEtude")
                .Columns.Add("Option")
            End With

            For Each dgr1 As DataGridViewRow In Ets.DataGridView1.Rows
                grp.Rows.Add(dgr1.Cells(1).Value, dgr1.Cells(2).Value, dgr1.Cells(3).Value)
            Next

            For Each dr As DataRow In grp.Rows
                If dr.Item("AnneeEtude").ToString = "1" Then
                    dr.Item("AnneeEtude") = "1 ére"
                End If
                If dr.Item("AnneeEtude").ToString = "2" Then
                    dr.Item("AnneeEtude") = "2éme"
                End If
                If dr.Item("AnneeEtude").ToString = "3" Then
                    dr.Item("AnneeEtude") = "3 éme"
                End If
                If dr.Item("AnneeEtude").ToString = "4" Then
                    dr.Item("AnneeEtude") = " 4éme"
                End If
                If dr.Item("AnneeEtude").ToString = "5" Then
                    dr.Item("AnneeEtude") = " 5éme"
                End If
            Next

            For Each dr As DataRow In Parc.Rows
                If dr.Item("AnneeEtude").ToString = "1" Then
                    dr.Item("AnneeEtude") = "2 éme"
                End If
                If dr.Item("AnneeEtude").ToString = "2" Then
                    dr.Item("AnneeEtude") = "3 éme"
                End If
                If dr.Item("AnneeEtude").ToString = "3" Then
                    dr.Item("AnneeEtude") = "4 éme"
                End If
                If dr.Item("AnneeEtude").ToString = "4" Then
                    dr.Item("AnneeEtude") = " 5éme"
                End If

            Next

            Dim note As New DataTable
            With note
                .Columns.Add("Id_Matiere")
                .Columns.Add("noteSynthese")
                .Columns.Add("NoteJuin")
                .Columns.Add("NoteRattrapage")
            End With

            For Each dgr2 As DataGridViewRow In Ets.DataGridView2.Rows
                note.Rows.Add(dgr2.Cells(0).Value, dgr2.Cells(1).Value, dgr2.Cells(2).Value, dgr2.Cells(3).Value)
            Next
            For Each dr As DataRow In note.Rows
                If dr.Item("NoteRattrapage").ToString = "0" Then
                    dr.Item("NoteRattrapage") = ""
                End If
            Next
            Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt = New ReleveSimple
            Rpt.Database.Tables("ETUDIANT").SetDataSource(Etudiant)
            Rpt.Database.Tables("PARCOURS").SetDataSource(Parc)
            Rpt.Database.Tables("NOTE").SetDataSource(note)
            Rpt.Database.Tables("GROUPE").SetDataSource(grp)
            ReleveSimpleF.CrystalReportViewer1.ReportSource = Rpt
            ReleveSimpleF.CrystalReportViewer1.Refresh()


          
            ReleveSimpleF.ShowDialog()
            ReleveSimpleF.Dispose()
            'ReleveSimpleF.CrystalReportViewer1.Refresh()


        Catch ex As Exception
            MsgBox(" Veuillez redemarer l'application ")
            MsgBox(ex.Message)
        End Try


    End Sub
#End Region

#Region "Traitement Attestation "
    Public Sub Attestation(ByVal Matricule As String)

        '----------- Donne 2 DataTable (pour l'Attestation) contenant les informations d'un Etudiant precis ( par son Matricule ) --------'
        '---------------------------------------------------------------------------------------------------------------------------------'




        '-----------  Le 1er DataTable contient les informations de la Table ETUDIANT -----------'

        Try

            Dim Access As New BDDControl
            Access.ExecQuery(" Select Id_Etudiant,NomEtud,Prenoms,DATENAIS,LIEUNAIS from [ETUDIANT] WHERE Id_Etudiant = '" & Matricule & "'")
            If Not String.IsNullOrEmpty(Access.Exception) Then MsgBox(Access.Exception) : Exit Sub
            Ets.DataGridView.DataSource = Access.DBDT




            '-----------  Le 2eme DataTable contient les informations de la Table PARCOURS -----------'



            Dim Access1 As New BDDControl
            Access1.ExecQuery(" Select id_Etudiant,AnneeScolaire , AnneeEtude, Option ,Moyenne,Rang,DECIIN from [PARCOURS] WHERE id_Etudiant = '" & Matricule & "'")
            If Not String.IsNullOrEmpty(Access1.Exception) Then MsgBox(Access1.Exception) : Exit Sub
            Ets.DataGridView1.DataSource = Access1.DBDT

            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1

                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("TRC")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("<<Tronc Commun>>")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("SIQ")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("Ingénieur option <<Systém informatique>")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(3).Value = ("SI")) Then
                    Ets.DataGridView1.Rows(i).Cells(3).Value = ("Ingénieur option <<Systém d'information>>")

                End If
            Next i
            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1
                If Ets.DataGridView1.Rows(i).Cells(1).Value IsNot Nothing Then

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "89" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1989/1990"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "90" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1990/1991"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "91" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1991/1992"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "92" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1992/1993"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "93" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1993/1994"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "94" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1994/1995"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "95" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1995/1996"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "96" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1996/1997"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "97" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1997/1998"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "98" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1998/1999"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "99" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "1999/2000"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "00" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2000/2001"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "01" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2001/2002"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "02" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2002/2003"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "03" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2003/2004"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "04" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2004/2005"
                    End If

                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "05" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2005/2006"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "06" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2006/2007"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "07" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2007/2008"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "08" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2008/2009"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "09" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2009/2010"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "10" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2010/2011"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "11" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2011/2012"
                    End If
                    If Ets.DataGridView1.Rows(i).Cells(1).Value = "12" Then
                        Ets.DataGridView1.Rows(i).Cells(1).Value = "2012/2013"
                    End If

                End If
            Next

            For i As Integer = 0 To Ets.DataGridView1.Rows.Count - 1

                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("0")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("1")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("admis")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("2")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("admis avec rachat")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("3")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("redouble")

                End If
                If (Ets.DataGridView1.Rows(i).Cells(6).Value = ("4")) Then
                    Ets.DataGridView1.Rows(i).Cells(6).Value = ("non admis")

                End If
            Next i


            Ets.DataGridView1.Sort(Ets.DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
            Ets.DataGridView1.Sort(Ets.DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            Dim Etudiant As New DataTable
            With Etudiant
                .Columns.Add("Id_Etudiant")
                .Columns.Add("nomEtud")
                .Columns.Add("Prenoms")
                .Columns.Add("DATENAIS")
                .Columns.Add("LIEUNAIS")


            End With
            For Each dgr As DataGridViewRow In Ets.DataGridView.Rows
                Etudiant.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value)
            Next
            Dim Parc As New DataTable
            With Parc
                .Columns.Add("Id_Etudiant")
                .Columns.Add("AnneeScolaire")
                .Columns.Add("AnneeEtude", GetType(String))
                .Columns.Add("Option")
                .Columns.Add("Moyenne")
                .Columns.Add("Rang")
                .Columns.Add("DECIIN")


            End With

            For Each dgr1 As DataGridViewRow In Ets.DataGridView1.Rows
                Parc.Rows.Add(dgr1.Cells(0).Value, dgr1.Cells(1).Value, dgr1.Cells(2).Value, dgr1.Cells(3).Value, dgr1.Cells(4).Value, dgr1.Cells(5).Value, dgr1.Cells(6).Value)
            Next
            For Each dr As DataRow In Parc.Rows
                If dr.Item("AnneeEtude").ToString = "1" Then
                    dr.Item("AnneeEtude") = "1 ére"
                End If
                If dr.Item("AnneeEtude").ToString = "2" Then
                    dr.Item("AnneeEtude") = "2éme"
                End If
                If dr.Item("AnneeEtude").ToString = "3" Then
                    dr.Item("AnneeEtude") = "3 éme"
                End If
                If dr.Item("AnneeEtude").ToString = "4" Then
                    dr.Item("AnneeEtude") = " 4éme"
                End If
                If dr.Item("AnneeEtude").ToString = "5" Then
                    dr.Item("AnneeEtude") = " 5éme"
                End If
            Next



            Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt = New Attestation

            Rpt.Database.Tables("ETUDIANT").SetDataSource(Etudiant)
            Rpt.Database.Tables("PARCOURS").SetDataSource(Parc)
            AttestationF.CrystalReportViewer1.ReportSource = Rpt
            AttestationF.CrystalReportViewer1.Refresh()
           
            AttestationF.ShowDialog()
            AttestationF.Dispose()
        Catch ex As Exception
            MsgBox(" Veuillez redemarer l'application ")
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region

    ' Cette Fonction est utiliser pour la Selection des Annees scolaires selon une matricule et une annee d'etude precise 
    Public Function SelectAnneeScolaire(ByVal Matricule, ByVal AnneeEtude)

        'Aprés le choix d'une annee d'etude on vas avoir un autre comboBox contenant les annees scolaires associe a une matricule et une annee d'etude precises
        'On remplir le ComboBox de Annees scolaires par un Datatable qui contient les annees scolaires associer d'aprés l'execution de la commande sql 

        Dim AccessAnnee As New BDDControl
        AccessAnnee.ExecQuery(" Select AnneeScolaire from [PARCOURS] WHERE id_Etudiant = '" & Matricule & "' AND AnneeEtude = " & AnneeEtude & " ")
        Dim dt1 As New DataTable
        dt1 = AccessAnnee.DBDT
        Return dt1
    End Function
End Class
