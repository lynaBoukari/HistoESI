Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class ClassCorriectionErreur
    Private bddChemin, bddErreurChemin As String


    Sub New(ByVal bddChemin As String, ByVal bddErreurChemin As String)
        Me.bddChemin = bddChemin
        Me.bddErreurChemin = bddErreurChemin
    End Sub


    Function correction_vides_doubles_Rattrapage(ByVal rattrapageTable As DataTable) As DataTable
        Dim dtres As DataTable 'contiendra les erreurs (s'il y a toujours des vides )
        dtres = DirectCast(rattrapageTable.Clone, DataTable) ' creer une datatable avec la meme structure que la table RATTRAPAGE
        dtres.TableName = "Vides_RATTRAPAGE"

        Dim cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & bddChemin)
        Dim req As String = " "
        Dim ob As New VNUL() ' objet qui reglera les probleme des valeurs null
        Dim cmd As New OleDbCommand(req, cnx)
        cnx.Open()

        Dim i As Integer = 0 'i sera mit a 1 des que l'on detecte une erreurs et a la fin on verifie si i =1 on signale a l'utilisateur qu'il y a eu une erreurs


        For Each Ligne As DataRow In rattrapageTable.Rows()
            ' a mettre dans un try on sait jamais la ligne n'existe pas dans parcours ou etudiant
            Try
                req = "UPDATE RATTRAPAGE SET [MoyenneRattrapage] = '" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "',[MentRat] = " & ob.TestValeurNullNBR(Ligne("MENTRA")) & ",[ElimRAt] = " & ob.TestValeurNullNBR(Ligne("ELIMRA")) & ",[RATRRA] = " & ob.TestValeurNullNBR(Ligne("RATRRA")) & " WHERE Id_Etudiant='" & Ligne("MATRRA") & "' AND AnneeScolaire='" & Ligne("ANSCRA") & "'"
                ' "UPDATE RATTRAPAGE SET [MoyenneRattrapage] = " & ob.TestValeurNullNBR(Ligne("MOYERA")) & ",[MentRat] = " & ob.TestValeurNullNBR(Ligne("MENTRA")) & ",[ElimRAt] = " & ob.TestValeurNullNBR(Ligne("ELIMRA")) & ",[RATRRA] = " & ob.TestValeurNullNBR(Ligne("RATRRA")) & ",[Moyenne] = '" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "',[Rang] = " & ob.TestValeurNullNBR(Ligne("RANGIN")) & ",[Mention] = " & ob.TestValeurNullNBR(Ligne("MENTIN")) & ",[NbNoteElimin] = " & ob.TestValeurNullNBR(Ligne("ELIMIN")) & ",[NbRattrapage] = " & ob.TestValeurNullNBR(Ligne("RATRIN")) & " WHERE Id_Etudiant='" & Ligne("MATRRA") & "' AND AnneeScolaire='" & Ligne("ANSCRA") & "'"
                cmd.CommandText = req
                cmd.ExecuteNonQuery()

                req = "UPDATE PARCOURS SET [Moyenne_Rattrapage] = '" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "' WHERE Id_Etudiant='" & Ligne("MATRRA") & "' AND AnneeScolaire='" & Ligne("ANSCRA") & "'"
                cmd.CommandText = req
                cmd.ExecuteNonQuery()

                'maintenant on verifie s'il y a des vides pour les signaler
                If ((IsDBNull(Ligne("MENTRA"))) Or (IsDBNull(Ligne("ELIMRA"))) Or (IsDBNull(Ligne("MOYERA"))) Or (IsDBNull(Ligne("RATRRA")))) Then
                    dtres.ImportRow(Ligne)
                End If
                'les vides sont aussi dans le catch car on ne signale que si la ligne est importée dans la bdd
                'il y aura une exception seulement si la ligne n'existe pas la la bdd et que ça a été mit dans le programme de correction (on ne traitera pas cette erreur de l'utilisateur )
            Catch ex As Exception
                i = 1
            End Try

        Next
        If i = 1 Then
            MessageBox.Show("Une ou plusieurs lignes n'ont pas été prises en considération car ces dernieres ne figurent pas dans la base de donnée.", "Lignes Non existantes dans la Bdd", MessageBoxButtons.OK)
        End If
        cmd.Dispose()
        cnx.Close()
        Return dtres
    End Function

    Function correction_vides_doubles_Note(ByVal noteTable As DataTable) As DataTable

        Dim dtres As DataTable   'contiendra les erreurs (s'il y a toujours des vides )
        dtres = DirectCast(noteTable.Clone, DataTable) ' creer une datatable avec la meme structure que la table RATTRAPAGE
        dtres.TableName = "Vides_NOTES"

        Dim cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & bddChemin)
        Dim req As String = " " '
        Dim ob As New VNUL() ' objet qui reglera les probleme des valeurs null
        Dim cmd As New OleDbCommand(req, cnx)
        cnx.Open()

        Dim i As Integer = 0 'i sera mit a 1 des que l'on detecte une erreur et a la fin on verifie si i =1 on signale a l'utilisateur qu'il y a eu une erreur


        For Each Ligne As DataRow In noteTable.Rows()
            ' a mettre dans un try on sait jamais la ligne n'existe pas dans NOTE
            Try
                req = "UPDATE [NOTE] SET [NoteJuin] = '" & ob.TestValeurNullNBR(Ligne("NOJUNO")) & "',[NoteSynthese] = '" & ob.TestValeurNullNBR(Ligne("NOSYNO")) & "',[NoteRattrapage] = '" & ob.TestValeurNullNBR(Ligne("NORANO")) & "',[Elimine] = " & ob.TestValeurNullBOOL(Ligne("ELIMNO")) & ", [RATRNO] = " & ob.TestValeurNullNBR(Ligne("RATRNO")) & " WHERE Id_Etudiant='" & Ligne("MATRNO") & "' AND Id_Matiere='" & Ligne("COMANO") & "' AND AnneeScolaire='" & Ligne("ANSCNO") & "'"
                cmd.CommandText = req
                cmd.ExecuteNonQuery()


                'maintenant on verifie s'il y a des vides pour les signaler
                If ((IsDBNull(Ligne("NOJUNO"))) Or (IsDBNull(Ligne("NOSYNO"))) Or (IsDBNull(Ligne("NORANO"))) Or (IsDBNull(Ligne("RATRNO"))) Or (IsDBNull(Ligne("ELIMNO")))) Then
                    dtres.ImportRow(Ligne)
                End If
                'les vides sont aussi dans le catch car on ne signale que si la ligne est importée dans la bdd
                'il y aura une exception seulement si la ligne n'existe pas la la bdd et que ça a été mit dans le programme de correction (on ne traitera pas cette erreur de l'utilisateur )
            Catch ex As Exception
                i = 1
            End Try

        Next
        If i = 1 Then
            MessageBox.Show("Une ou plusieurs lignes n'ont pas été prises en considération car ces dernieres ne figurent pas dans la base de donnée.", "Lignes Non existantes dans la Bdd", MessageBoxButtons.OK)
        End If

        cmd.Dispose()
        cnx.Close()

        Return dtres
    End Function


    Function correction_vides_doubles_MoyenMatiere(ByVal moyenneMatiereTable As DataTable) As DataTable
        Dim cnxBdd As OleDbConnection
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        Dim exceptionBool As Boolean = False
        Dim ob As New VNUL()
        Dim emptyFieldTable As DataTable = New DataTable("Vides_MATIERE")
        emptyFieldTable = DirectCast(moyenneMatiereTable.Clone, DataTable)

        cnxBdd = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & bddChemin)
        cmd = New OleDbCommand(sqlcmd, cnxBdd)
        cnxBdd.Open()
        For Each row As DataRow In moyenneMatiereTable.Rows()
            Try

                sqlcmd = "UPDATE MOYENNEMATIERE SET [CoefMat] = '" & ob.TestValeurNullNBR(row("COEFMA")) & "' ,[MoyenMat] = '" & ob.TestValeurNullNBR(row("MOYMAT")) & "',[TypeMat] = " & ob.TestValeurNullNBR(row("TYPEMA")) & " where [Code]= '" & row("COMAMA") & "'  AND [Option]='" & row("OPTIMA") & "'  AND [AnneeEtude] =" & row("ANETMA") & " AND [AnneeScolaire]='" & row("ANSCMA") & "' "
                cmd.CommandText = sqlcmd
                cmd.ExecuteNonQuery()

                If (IsDBNull(row("COEFMA")) Or IsDBNull(row("MOYMAT")) Or IsDBNull(row("TYPEMA"))) Then
                    emptyFieldTable.ImportRow(row)
                End If
            Catch ex As Exception  'L'exception se lance si l'utilisateur a essayé d'upadter une ligne qui n'existe pas dans la bdd
                exceptionBool = True
            End Try
        Next
        If (exceptionBool = True) Then
            MessageBox.Show("Une ou plusieurs lignes n'ont pas été prises en considération car ces dernieres ne figurent pas dans la base de donnée.", "Lignes Non existantes dans la Bdd", MessageBoxButtons.OK)
        End If
        cmd.Dispose()
        cnxBdd.Close()
        Return emptyFieldTable
    End Function

    Function Correction_vides_doubles_Inscrit(ByVal inscritTable As DataTable) As DataTable
        Dim dtres As DataTable   'contiendra les datatables d'erreurs (s'il y a toujours des vides )
        dtres = DirectCast(inscritTable.Clone, DataTable) ' creer une datatable avec la meme structure que la table inscrit
        dtres.TableName = "Vides_INSCRIT"

        Dim cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & bddChemin)
        cnx.Open()

        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim ob As New VNUL() ' objet qui reglera les probleme des valeurs null
        Dim i As Integer = 0
        Dim j As Integer = 0 'sera mis a 1 dés qune erreur survient comme ça on affiche un msg a lutilisateur
        ' Dim s As String = ""
        Dim listeMat As List(Of String) = New List(Of String) ' sera utilisé pour verifier si un etudiant a été deja mis a jour ou pas


        For Each Ligne As DataRow In inscritTable.Rows()
            i = 0
            Try
                If (listeMat.Contains(Ligne("MATRIN")) = False) Then
                    listeMat.Add(Ligne("MATRIN"))
                    'il faut le mettre dans un try catch on sait jamais la ligne existe pas  
                    req = "UPDATE ETUDIANT SET NomEtud = '" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "',Prenoms = '" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "',NomEtudA = '" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "',PrenomsA = '" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "',MATRIC_INS = '" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "',DATENAIS = '" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "',LIEUNAISA = '" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "',WILNAISA = '" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "',LIEUNAIS = '" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "',WILNAIS = " & ob.TestValeurNullNBR(Ligne("WILNAIS")) & ",ADRESSE = '" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "',VILLE = '" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "',WILAYA = '" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "',CODPOST = '" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "',Cycle = '" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "',WILBAC = " & ob.TestValeurNullNBR(Ligne("WILBAC")) & ",SEXE = " & ob.TestValeurNullNBR(Ligne("SEXE")) & ",SERIEBAC = '" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "',ANNEEBAC = '" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "',FILS_DE = '" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "',ET_DE = '" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "',MOYBAC = '" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "' WHERE Id_Etudiant='" & Ligne("MATRIN") & "'"
                    cmd.CommandText = req
                    cmd.ExecuteNonQuery()

                    'on teste si cette ligne inserer a des vides alors on le signal en la metant dans un dtable
                    If ((IsDBNull(Ligne("NomEtud"))) Or (IsDBNull(Ligne("Prenoms"))) Or (IsDBNull(Ligne("NomEtudA"))) Or (IsDBNull(Ligne("PrenomsA"))) Or (IsDBNull(Ligne("MATRIC_INS"))) Or (IsDBNull(Ligne("DATENAIS"))) Or (IsDBNull(Ligne("LIEUNAISA"))) Or (IsDBNull(Ligne("WILNAISA"))) Or (IsDBNull(Ligne("LIEUNAIS"))) Or (IsDBNull(Ligne("WILNAIS"))) Or (IsDBNull(Ligne("ADRESSE"))) Or (IsDBNull(Ligne("VILLE"))) Or (IsDBNull(Ligne("WILAYA"))) Or (IsDBNull(Ligne("CODPOST"))) Or (IsDBNull(Ligne("CYCLIN"))) Or (IsDBNull(Ligne("WILBAC"))) Or (IsDBNull(Ligne("SEXE"))) Or (IsDBNull(Ligne("SERIEBAC"))) Or (IsDBNull(Ligne("ANNEEBAC"))) Or (IsDBNull(Ligne("FILS_DE"))) Or (IsDBNull(Ligne("ET_DE"))) Or (IsDBNull(Ligne("MOYBAC")))) Then
                        i = 1 'comme ça si cette ligne contient des vide meme dans les chammps parcours elle ne sera oas signalée deux fois
                        dtres.ImportRow(Ligne)
                        'on insere dans le datasetd'erreur
                    End If
                End If

                req = "UPDATE PARCOURS SET [AnneeEtude] = " & ob.TestValeurNullNBR(Ligne("ANETIN")) & ",[Option] = '" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "',[Ngroupe] = " & ob.TestValeurNullNBR(Ligne("NG")) & ",[Nsection] = '" & ob.TestValeurNullSTR(Ligne("NS")) & "',[Moyenne] = '" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "',[Rang] = " & ob.TestValeurNullNBR(Ligne("RANGIN")) & ",[Mention] = " & ob.TestValeurNullNBR(Ligne("MENTIN")) & ",[NbNoteElimin] = " & ob.TestValeurNullNBR(Ligne("ELIMIN")) & ",[NbRattrapage] = " & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",[ADM] = '" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "',[DEC] = '" & apos(ob.TestValeurNullSTR(Ligne("DEC"))) & "',[DECIIN] = " & ob.TestValeurNullNBR(Ligne("DECIIN")) & " WHERE Id_Etudiant='" & Ligne("MATRIN") & "' AND AnneeScolaire='" & Ligne("ANSCIN") & "'"
                cmd.CommandText = req
                cmd.ExecuteNonQuery()
                If (i = 0) Then   'on verifie s'il y a des vides
                    If ((IsDBNull(Ligne("ANETIN"))) Or (IsDBNull(Ligne("OPTIIN"))) Or (IsDBNull(Ligne("NG"))) Or (IsDBNull(Ligne("NS"))) Or (IsDBNull(Ligne("MOYEIN"))) Or (IsDBNull(Ligne("RANGIN"))) Or (IsDBNull(Ligne("MENTIN"))) Or (IsDBNull(Ligne("ELIMIN"))) Or (IsDBNull(Ligne("RATRIN"))) Or (IsDBNull(Ligne("ADM"))) Or (IsDBNull(Ligne("DECIIN")))) Then 'Or (IsDBNull(Ligne("DEC")))
                        'On la met dans le tds Vide
                        dtres.ImportRow(Ligne)

                    End If
                End If
            Catch ex As Exception
                j = 1
            End Try
        Next
        If j = 1 Then
            MessageBox.Show("Une ou plusieurs lignes n'ont pas été prises en considération car ces dernieres ne figurent pas dans la base de donnée.", "Lignes Non existantes dans la Bdd", MessageBoxButtons.OK)
        End If

        cmd.Dispose()
        cnx.Close()
        Correction_vides_doubles_Inscrit = dtres
    End Function

    Sub corrigerInscrit(ByVal excelChemin As String)
        Dim cnxExcel As OleDbConnection
        Dim extractCmd As String
        Dim inscritTable As DataTable = New DataTable()
        Dim inscritErreurTable As DataTable = New DataTable()
        cnxExcel = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelChemin & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';")
        cnxExcel.Open()
        extractCmd = "SELECT * FROM [INSCRIT$] WHERE MATRIN IS NOT NULL"
        'NomEtud,Prenoms,NomEtudA,PrenomsA,MATRIC_INS,MATRICULE,ANSCIN,DATENAIS,LIEUNAISA,WILNAISA,LIEUNAIS,WILNAIS,ADRESSE,VILLE,WILAYA,CODPOST,ANETIN,CYCLIN,OPTIIN,NS,NG,MOYEIN,RANGIN,MENTIN,ELIMIN,RATRIN,DECIIN,DEC,WILBAC,SEXE,SERIEBAC,MOYBAC,ANNEEBAC,FILS_DE,ET_DE,ADM
        Try
            inscritTable = LoadExcelFileIntoDataTable(cnxExcel, extractCmd)
            inscritErreurTable = Correction_vides_doubles_Inscrit(inscritTable)
        Catch ex As Exception
            MessageBox.Show("Le fichier Inscrit que vous avez donné est inexploitable", "Fichier inexploitable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cnxExcel.Close()
        ImportErreurAccess(bddErreurChemin, inscritErreurTable)
        MessageBox.Show("Fin de la correction des données pour le fichier Inscrit", "Fin Correction Inscrit", MessageBoxButtons.OK)

    End Sub

    Sub corrigerMatiere(ByVal excelChemin As String)
        Dim cnxExcel As OleDbConnection
        Dim extractCmd As String
        Dim matiereTable As DataTable = New DataTable()
        Dim matiereErreurTable As DataTable = New DataTable()
        cnxExcel = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelChemin & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';")
        cnxExcel.Open()
        extractCmd = "SELECT * FROM [MATIERE$] WHERE COMAMA IS NOT NULL AND ANSCMA IS NOT NULL AND ANETMA IS NOT NULL AND OPTIMA IS NOT NULL "

        Try
            matiereTable = LoadExcelFileIntoDataTable(cnxExcel, extractCmd)
            matiereErreurTable = correction_vides_doubles_MoyenMatiere(matiereTable)
        Catch ex As Exception
            MessageBox.Show("Le fichier Matiere que vous avez donné est inexploitable", "Fichier inexploitable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cnxExcel.Close()
        ImportErreurAccess(bddErreurChemin, matiereErreurTable)
        MessageBox.Show("Fin de la correction des données pour le fichier Matiere", "Fin Correction Matiere", MessageBoxButtons.OK)
    End Sub

    Sub corrigerNote(ByVal excelChemin As String)
        Dim cnxExcel As OleDbConnection
        Dim extractCmd As String
        Dim noteTable As DataTable = New DataTable()
        Dim noteErreurTable As DataTable = New DataTable()
        cnxExcel = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelChemin & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';")
        cnxExcel.Open()
        extractCmd = "SELECT ANSCNO,ANETNO,CYCLNO,OPTINO,MATRNO,COMANO,NOJUNO,NOSYNO,NORANO,ELIMNO,RATRNO FROM [NOTE$] WHERE COMANO IS NOT NULL AND MATRNO IS NOT NULL AND ANSCNO IS NOT NULL "

        Try
            noteTable = LoadExcelFileIntoDataTable(cnxExcel, extractCmd)
            noteErreurTable = correction_vides_doubles_Note(noteTable)
        Catch ex As Exception
            MessageBox.Show("Le fichier Note que vous avez donné est inexploitable", "Fichier inexploitable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cnxExcel.Close()
        ImportErreurAccess(bddErreurChemin, noteErreurTable)
        MessageBox.Show("Fin de la correction des données pour le fichier Note", "Fin Correction Note", MessageBoxButtons.OK)

    End Sub


    Sub corrigerRattrapage(ByVal excelChemin As String)
        Dim cnxExcel As OleDbConnection
        Dim extractCmd As String
        Dim rattrapageTable As DataTable = New DataTable()
        Dim rattrapageErreurTable As DataTable = New DataTable()
        cnxExcel = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelChemin & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';")
        cnxExcel.Open()
        extractCmd = "SELECT * FROM [RATRAP$] WHERE MATRRA IS NOT NULL AND ANSCRA IS NOT NULL  "

        Try
            rattrapageTable = LoadExcelFileIntoDataTable(cnxExcel, extractCmd)
            rattrapageErreurTable = correction_vides_doubles_Rattrapage(rattrapageTable)
        Catch ex As Exception
            MessageBox.Show("Le fichier Rattrapage que vous avez donné est inexploitable", "Fichier inexploitable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cnxExcel.Close()
        ImportErreurAccess(bddErreurChemin, rattrapageErreurTable)
        MessageBox.Show("Fin de la correction des données pour le fichier Rattrapage", "Fin Correction Rattrapage", MessageBoxButtons.OK)

    End Sub

#Region "other functions"

    Function apos(ByVal input As String) As String
        If input.Contains("'") Then
            Dim re As String = ""
            Dim result As String() = Regex.Split(input, "'")

            For Each s As String In result
                s = String.Concat(s, "''")
                re = String.Concat(re, s)
            Next
            re = re.Substring(0, re.Length - 2)
            apos = re
        Else
            apos = input
        End If
    End Function

    Function LoadExcelFileIntoDataTable(ByVal cnxExcel As OleDbConnection, ByVal sqlCmd As String) As DataTable
        Dim dataAdapter As OleDbDataAdapter
        Dim dataTable As DataTable
        dataAdapter = New OleDbDataAdapter(sqlCmd, cnxExcel)
        dataTable = New DataTable()
        dataAdapter.Fill(dataTable)
        Return dataTable
    End Function

    Sub ImportErreurAccess(ByVal bddErreurChemin As String, ByVal Dt As DataTable)
        Dim bddcnx As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & bddErreurChemin)
        bddcnx.Open()
        Dim req As String
        req = " "
        Dim cmd As New OleDbCommand(req, bddcnx)
        Dim ob As VNUL = New VNUL

        Select Case Dt.TableName
            '===================ERREURS INSCRIT============================================='
            Case "Vides_INSCRIT"
                For Each Ligne As DataRow In Dt.Rows()
                    Try
                        req = "Insert into [Vides_INSCRIT] values ('" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "','" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "','" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "','" & ob.TestValeurNullSTR(Ligne("ANSCIN")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIN")) & "','" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "','" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "','" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "'," & ob.TestValeurNullNBR(Ligne("WILNAIS")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "','" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "','" & ob.TestValeurNullSTR(Ligne("ANETIN")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "','" & ob.TestValeurNullSTR(Ligne("NS")) & "','" & ob.TestValeurNullSTR(Ligne("Ng")) & "','" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "'," & ob.TestValeurNullNBR(Ligne("RANGIN")) & "," & ob.TestValeurNullNBR(Ligne("MENTIN")) & "," & ob.TestValeurNullNBR(Ligne("ELIMIN")) & "," & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("DECIIN"))) & "','" & ob.TestValeurNullSTR(Ligne("DEC")) & "','" & ob.TestValeurNullSTR(Ligne("WILBAC")) & "'," & ob.TestValeurNullNBR(Ligne("SEXE")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "','" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "')"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                Next

                '===================ERREURS RATTRAPAGE============================================='
            Case "Vides_RATTRAPAGE"
                For Each Ligne As DataRow In Dt.Rows()
                    Try
                        req = "Insert into [Vides_RATTRAPAGE] values ('" & (ob.TestValeurNullSTR(Ligne("ANSCRA"))) & "'," & ob.TestValeurNullNBR(Ligne("ANETRA")) & ",'" & ob.TestValeurNullSTR(Ligne("CYCLRA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIRA")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRRA"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullNBR(Ligne("RATRRA")) & "')"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                    End Try
                Next
                '=====================MATIERES=============================='
            Case "Vides_MATIERE"
                For Each Ligne As DataRow In Dt.Rows()
                    Try
                        req = "Insert into [Vides_MATIERE] values ('" & Ligne("ANSCMA") & "','" & Ligne("ANETMA") & "','" & ob.TestValeurNullSTR(Ligne("CYCLMA")) & "','" & Ligne("OPTIMA") & "','" & Ligne("COMAMA") & "','" & apos(ob.TestValeurNullSTR(Ligne("LIBEMA"))) & "','" & ob.TestValeurNullNBR(Ligne("TYPEMA")) & "','" & ob.TestValeurNullNBR(Ligne("COEFMA")) & "','" & ob.TestValeurNullNBR(Ligne("MOYMAT")) & "')"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                Next
                '=====================NOTES================================='
            Case "Vides_NOTES"
                For Each Ligne As DataRow In Dt.Rows()
                    Try
                        req = "Insert into [Vides_NOTES] values ('" & (ob.TestValeurNullSTR(Ligne("ANSCNO"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETNO")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLNO")) & "','" & ob.TestValeurNullSTR(Ligne("OPTINO")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRNO"))) & "','" & ob.TestValeurNullSTR(Ligne("COMANO")) & "','" & ob.TestValeurNullNBR(Ligne("NOJUNO")) & "','" & ob.TestValeurNullNBR(Ligne("NOSYNO")) & "','" & ob.TestValeurNullNBR(Ligne("NORANO")) & "','" & ob.TestValeurNullSTR(Ligne("ELIMNO")) & "'," & ob.TestValeurNullNBR(Ligne("RATRNO")) & ")"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                    End Try
                Next
        End Select
        bddcnx.Close()
        cmd.Dispose()


    End Sub
#End Region
End Class
