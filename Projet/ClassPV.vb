Imports System.Data.OleDb

Public Class ClassPV
    Private Opt As String
    Private AnneeEtude As Integer
    Private AnneeScolaire As String


    Sub New(ByVal Opt As String, ByVal AnneEtude As String, ByVal AnneeScolaire As String)
        Me.Opt = Opt
        Me.AnneeEtude = CInt(AnneEtude)
        Me.AnneeScolaire = AnneeScolaire
    End Sub

    Public Function genererPv() As DataSet
        Dim cnxBdd As OleDbConnection
        Dim dataAdapter As OleDbDataAdapter
        Dim dataSet As DataSet = New DataSet()
        Dim c As FctPV = New FctPV()
        Dim op, ansc As String
        Dim keyList As List(Of String) = New List(Of String)  'contient les clés primaires des etudiants qui ont une moyenne de rattrapage superieure a celle de juin 


        Dim noteTable As DataTable = New DataTable()
        Dim parcoursTable As DataTable = New DataTable()
        Dim rattrapageTable As DataTable = New DataTable()
        Dim etudiantTable As DataTable = New DataTable()
        Dim promoTable As DataTable = New DataTable()

        Dim sqlCmd As String
        Dim cnxString As String
        cnxString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDD_PRJT_EQUIPE14.accdb"

        op = String.Concat("'", String.Concat(Opt, "'"))
        ansc = AnneeScolaire.Substring(2, 2)
        ansc = String.Concat("'", String.Concat(ansc, "'"))

        '0.Table matiere :codeMatiere+coef
        sqlCmd = "SELECT MATIERE.Code,MOYENNEMATIERE.CoefMat FROM MATIERE INNER JOIN MOYENNEMATIERE ON MATIERE.Code=MOYENNEMATIERE.Code AND MATIERE.Option=MOYENNEMATIERE.Option AND MATIERE.AnneeEtude=MOYENNEMATIERE.AnneeEtude where MATIERE.Option =" & op & " AND MATIERE.AnneeEtude=" & AnneeEtude & " AND MOYENNEMATIERE.AnneeScolaire=" & ansc
        cnxBdd = New OleDbConnection(cnxString)
        cnxBdd.Open()
        dataAdapter = New OleDbDataAdapter(sqlCmd, cnxBdd)
        dataAdapter.Fill(dataSet)

        '1.Table promo :option+anneeEtude
        dataAdapter.SelectCommand.CommandText = "SELECT SpecificReleve FROM [SPECIALITE] where Option =" & op & " AND AnneeEtude=" & AnneeEtude
        dataAdapter.Fill(promoTable)
        dataSet.Tables.Add(promoTable)

        '2.Table rattrapage :matricule moyenne,moyennerattrapage,mentionRattrapage
        dataAdapter.SelectCommand.CommandText = "SELECT PARCOURS.Id_Etudiant,PARCOURS.Moyenne,RATTRAPAGE.MoyenneRattrapage,RATTRAPAGE.MentRat FROM PARCOURS INNER JOIN RATTRAPAGE ON PARCOURS.Id_Etudiant=RATTRAPAGE.Id_Etudiant AND PARCOURS.AnneeScolaire=RATTRAPAGE.AnneeScolaire where PARCOURS.Option =" & op & " AND PARCOURS.AnneeEtude=" & AnneeEtude & " AND PARCOURS.AnneeScolaire=" & ansc
        dataAdapter.Fill(rattrapageTable)

        Dim rattrapageTable2 As DataTable = New DataTable()
        With rattrapageTable2.Columns
            .Add("Id_Etudiant", GetType(String))
            .Add("MoyenneRattrapage", GetType(Double))
            .Add("MentRat", GetType(String))
        End With

        For Each row As DataRow In rattrapageTable.Rows()
            If (row(1) < row(2)) Then ' moyenneJuin < moyenneRattrapage
                keyList.Add(row(0))
            End If
            rattrapageTable2.Rows.Add(row("Id_Etudiant"), row("MoyenneRattrapage"), c.modifierMentionRattrapage(row("MentRat")))
        Next
        dataSet.Tables.Add(rattrapageTable2)



        '3.Table note: matricule,code,notejuin 
        dataAdapter.SelectCommand.CommandText = "SELECT Id_Etudiant,Id_Matiere,NoteJuin,NoteRattrapage FROM [NOTE] where Option =" & op & " AND AnneeEtude=" & AnneeEtude & " And AnneeScolaire=" & ansc
        dataAdapter.Fill(noteTable)

        'On crée une 2eme table ou on modifie les valeurs de notejuin = 99.99 ou 88.88 par abd et mld et si l'etudiant a une moyenne de rattrapage > moyenne Juin, on prend le max de ces notes pour toutes les matieres
        Dim noteTable2 As DataTable = New DataTable()
        With noteTable2.Columns
            .Add("Id_Etudiant", GetType(String))
            .Add("Id_Matiere", GetType(String))
            .Add("NoteJuin", GetType(String))
        End With
        For Each row As DataRow In noteTable.Rows()
            If (keyList.Contains(row("Id_Etudiant"))) Then
                noteTable2.Rows.Add(row("Id_Etudiant"), row("Id_Matiere"), c.modifierNoteJuin(Math.Max(row(2), row(3))))
            Else
                noteTable2.Rows.Add(row("Id_Etudiant"), row("Id_Matiere"), c.modifierNoteJuin(row(2)))
            End If

        Next
        dataSet.Tables.Add(noteTable2)


        '4.Table parcours : matricule,ne,moyenne,mention,rang,decision,anneeScolaire
        dataAdapter.SelectCommand.CommandText = "SELECT PARCOURS.Id_Etudiant,PARCOURS.NbNoteElimin,PARCOURS.Moyenne,PARCOURS.Mention,PARCOURS.Rang,PARCOURS.DECIIN FROM PARCOURS where PARCOURS.Option =" & op & " AND PARCOURS.AnneeEtude=" & AnneeEtude & " AND PARCOURS.AnneeScolaire=" & ansc & " ORDER BY Rang"
        dataAdapter.Fill(parcoursTable)

        'on crée une table pour modifier les valeurs des champs decision et mention
        Dim parcoursTable2 As DataTable = New DataTable()
        With parcoursTable2.Columns
            .Add("Id_Etudiant", GetType(String))
            .Add("NbNoteElimin", GetType(Integer))
            .Add("Moyenne", GetType(Double))
            .Add("Mention", GetType(String))
            .Add("Rang", GetType(Integer))
            .Add("DECIIN", GetType(String))
            .Add("AnneeScolaire", GetType(String))
        End With
        Dim ansc2 As String = c.creerAnneeScolaire(AnneeScolaire) 'renvoie une année scolaire du type 2000/2001
        For Each row As DataRow In parcoursTable.Rows()
            parcoursTable2.Rows.Add(row("Id_Etudiant"), row("NbNoteElimin"), row("Moyenne"), c.modifierMentionParcours(row("Mention")), row("Rang"), c.modifierDec(row("DECIIN")), ansc2)
        Next

        dataSet.Tables.Add(parcoursTable2)


        '5.Table etudiant :matricule,nom,prenom
        dataAdapter.SelectCommand.CommandText = "SELECT ETUDIANT.Id_Etudiant,ETUDIANT.NomEtud,ETUDIANT.Prenoms FROM ETUDIANT INNER JOIN PARCOURS ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant  where PARCOURS.Option =" & op & " AND PARCOURS.AnneeEtude=" & AnneeEtude & " AND PARCOURS.AnneeScolaire=" & ansc & " ORDER BY Rang"
        dataAdapter.Fill(etudiantTable)
        dataSet.Tables.Add(etudiantTable)


        Return dataSet
        dataAdapter.Dispose()
        cnxBdd.Close()
    End Function

End Class
