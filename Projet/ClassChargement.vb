Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class ClassChargement


#Region "Module principal"

    Function CHARGEMENT_PRINCIPAL(ByVal cheminBDD As String, ByVal cheminBDDER As String, ByVal cheminINSCRIT As String, ByVal cheminRATTRAPAGE As String, ByVal cheminNOTES As String, ByVal cheminMATIERE As String, ByRef rechrep As FolderBrowserDialog, ByRef L As Integer) As DataSet
        L = 0
        Dim i As Integer = 0
        Dim DsFichiers As DataSet = New DataSet
        Dim DsERREURS As DataSet = New DataSet

        Dim bddcnx As New OleDbConnection(cheminBDD)

        i = ImportFichierExcel(DsFichiers, DsERREURS, cheminINSCRIT, cheminRATTRAPAGE, cheminNOTES, cheminMATIERE)
        L = i
        If i = 0 Then
            bddcnx.Open()
            chargerNouveauxFichers(bddcnx, DsFichiers, DsERREURS)
            bddcnx.Close()
            MessageBox.Show("Fichiers importés avec succes,l'importation des tables contenant les erreurs va debuter.cliquez OK pour continuer", "Importation avec succes", MessageBoxButtons.OK)
            MessageBox.Show("Veuillez selectionner le répertoire ou vous souhaitez stocker les tables contenant les erreurs", "Selection du répertoire", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Vous avez entré les mauvais fichier ou les noms des feuilles de clacul ne sont pas comme suit : INSCRIT,RATRAP,NOTE,MATIERE;Il se pourrait aussi que les nom des colonnes ont été changé .Veuillez s'il vous plait vérifier vos Fichiers sélectionnés et réessayer", "Echec de l'Importation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return DsERREURS
    End Function
#End Region

#Region "MODULES_Englobants"

    Function ImportFichierExcel(ByRef DsFichier As DataSet, ByRef DsERREURS As DataSet, ByVal cheminINSCRIT As String, ByVal cheminRATTRAPAGE As String, ByVal cheminNOTES As String, ByVal cheminMATIERE As String) As Integer

        Dim i As Integer = 0 ' si i=0 -> aucune erreurs sinon erreur 
        Dim j As Integer = 0 ' si j <> 0 a la fin du prog ca veut dire qu'il y a eu une erreur lors du chargement de l'un des fichiers 
        Dim dsu As DataSet = New DataSet

        'importation des fichier (on selectionnera les lignes ou les clés primaire ne sont pas vide ) 
        i = LoadExcelFileIntoDT(DsFichier, "SELECT * FROM [INSCRIT$] WHERE MATRIN<>NULL AND ANSCIN<>NULL", cheminINSCRIT, "INSCRIT")
        j = j + i

        i = LoadExcelFileIntoDT(DsFichier, "SELECT DISTINCT NG,NS,OPTIIN,ANETIN ,ANSCIN  from [INSCRIT$] WHERE NG IS NOT NULL  AND  NS IS NOT NULL AND ANETIN IS NOT NULL AND OPTIIN IS NOT NULL AND ANSCIN IS NOT NULL", cheminINSCRIT, "GROUPE")
        j = j + i

        i = LoadExcelFileIntoDT(DsFichier, "SELECT DISTINCT NS,OPTIIN,ANETIN ,ANSCIN  from [INSCRIT$] WHERE NS IS NOT NULL AND ANETIN IS NOT NULL AND OPTIIN IS NOT NULL AND ANSCIN IS NOT NULL ", cheminINSCRIT, "SECTION")
        j = j + i

        i = LoadExcelFileIntoDT(DsFichier, " SELECT * FROM [RATRAP$] WHERE MATRRA<>NULL AND ANSCRA<>NULL ", cheminRATTRAPAGE, "RATTRAPAGE")
        j = j + i

        i = LoadExcelFileIntoDT(DsFichier, "SELECT DISTINCT COMAMA,OPTIMA,ANETMA,LIBEMA  from [MATIERE$]", cheminMATIERE, "MATIERE")
        j = j + i

        i = LoadExcelFileIntoDT(DsFichier, "SELECT *  from [MATIERE$] where COMAMA is not null AND OPTIMA is not null  AND ANETMA is not null AND ANSCMA is not null", cheminMATIERE, "MOYENNEMATIERE")
        j = j + i

        i = LoadExcelFileIntoDT(dsu, "SELECT * FROM [NOTE$] WHERE ANSCNO IS NOT NULL AND MATRNO IS NOT NULL AND COMANO IS NOT NULL", cheminNOTES, "NOTES") 'on utilise dsu car on ne met pas directe dans dsfichier car il y a deux etapes dans l'import des notes
        j = j + i

        If i = 0 Then ' s'il ny avait aucun prob avec le fichier note on continue sinon pas la peine 
            removeDuplicatesNote(dsu.Tables("NOTES"), DsFichier, DsERREURS)
            dsu.Dispose()
        End If



        'importation des lignes ou la clé primaire est vides et qu'on devra charger une deuxieme fois 
        If j = 0 Then
            i = LoadExcelFileIntoDT(DsERREURS, "SELECT * FROM [INSCRIT$] WHERE MATRIN IS NULL OR ANSCIN IS NULL", cheminINSCRIT, "Rejetees_INSCRIT")
            j = j + i
            i = LoadExcelFileIntoDT(DsERREURS, "SELECT * FROM [INSCRIT$] WHERE (MATRIN<>NULL AND ANSCIN<>NULL) AND (NomEtud IS NULL OR Prenoms IS NULL OR NomEtudA IS NULL OR PrenomsA IS NULL OR MATRIC_INS IS NULL OR DATENAIS IS NULL OR LIEUNAISA IS NULL OR WILNAISA IS NULL OR LIEUNAIS IS NULL OR WILNAIS IS NULL OR ADRESSE IS NULL OR VILLE IS NULL OR WILAYA IS NULL OR CODPOST IS NULL OR ANETIN IS NULL OR CYCLIN IS NULL OR OPTIIN IS NULL OR NS IS NULL OR NG IS NULL OR MOYEIN IS NULL OR RANGIN IS NULL OR MENTIN IS NULL OR ELIMIN IS NULL OR RATRIN IS NULL OR DECIIN IS NULL OR DEC IS NULL OR  WILBAC IS NULL OR SEXE IS NULL OR SERIEBAC IS NULL OR MOYBAC IS NULL OR ANNEEBAC IS NULL OR FILS_DE IS NULL OR ET_DE IS NULL OR ADM IS NULL)", cheminINSCRIT, "Vides_INSCRIT")
            j = j + i
            i = LoadExcelFileIntoDT(DsERREURS, "SELECT * FROM [RATRAP$] WHERE MATRRA IS NULL OR ANSCRA IS NULL ", cheminRATTRAPAGE, "Rejetees_RATTRAPAGE")
            j = j + i
            i = LoadExcelFileIntoDT(DsERREURS, "SELECT * FROM [NOTE$] WHERE ANSCNO IS NULL OR MATRNO IS NULL OR COMANO IS NULL OR ANETNO IS NULL OR OPTINO IS NULL OR NOJUNO IS NULL OR NOSYNO IS NULL OR NORANO IS NULL OR ELIMNO IS NULL OR  RATRNO IS NULL", cheminNOTES, "Vides_NOTES")
            j = j + i
            i = LoadExcelFileIntoDT(DsERREURS, "SELECT * from [MATIERE$] where COMAMA is null OR OPTIMA is null OR ANETMA is null OR ANSCMA is null OR MOYMAT=0 ", cheminMATIERE, "Vides_MATIERE")
            j = j + i
            i = LoadExcelFileIntoDT(DsERREURS, " SELECT * FROM [RATRAP$] WHERE (MATRRA<>NULL AND ANSCRA<>NULL) AND (ANETRA IS NULL OR OPTIRA IS NULL OR MOYERA IS NULL OR MENTRA IS NULL OR ELIMRA IS NULL OR RATRRA IS NULL) ", cheminRATTRAPAGE, "Vides_RATTRAPAGE")
            j = j + i
        End If

        If j <> 0 Then
            MessageBox.Show("une erreurs est survenue lors de l'importation de l'un des fichier excel.Veuillez, s'il vous plait, Verifiers les fichiers selectionnés et les nom des feuilles de calculs de ces fichiers ou Les nom des Colonnes.Pour plus d'information Consultez l'aide", "Fichiers Excel erronés", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        ImportFichierExcel = j
    End Function

    Sub chargerNouveauxFichers(ByVal bddcnx As OleDbConnection, ByVal DsFichier As DataSet, ByRef DsERREURS As DataSet)

        Dim listeparcoursAJOUTE As New List(Of String) 'servira a sauvegardé seulement les clé des enregistement ajouté a la bdd lors du chargement 

        Save_inscrit_access(DsERREURS, bddcnx, DsFichier.Tables("INSCRIT"), listeparcoursAJOUTE) 'rempli les tables Etudiant et Parcours de la bdd et remplie la dataset DsERREUR AVEC DES DT CONTENANT LES LIGNES AVEC ERREURS 
        Save_ratrapage_access(DsERREURS, bddcnx, DsFichier.Tables("RATTRAPAGE"), listeparcoursAJOUTE) 'rempli les tables Rattrapage de la bdd et remplie la dataset DsERREUR AVEC DES DT CONTENANT LES LIGNES AVEC ERREURS 
        saveSectionAccess(bddcnx, DsFichier.Tables("SECTION")) 'rempli la table SECTION de la bdd 
        saveGroupeAccess(bddcnx, DsFichier.Tables("GROUPE")) 'rempli la table Groupe de la bdd 
        saveMatiereAccess(bddcnx, DsFichier.Tables("MATIERE")) 'rempli la table Matiere de la bdd 
        saveMoyenneMatiereAccess(bddcnx, DsFichier.Tables("MOYENNEMATIERE")) 'rempli la table MoyenneMatiere  de la bdd 
        saveNOTE(bddcnx, DsFichier.Tables("NOTES"), listeparcoursAJOUTE, DsERREURS) 'rempli la table NOTES de la bdd et mets une tables de lignes rejetee dans Dsrejetees car ces dernieres n'on aucune correspondance dans parcours

    End Sub

    Sub ImportErreurAccess(ByVal bddcnx As OleDbConnection, ByVal DsERREURS As DataSet)
        Dim req As String
        req = " "
        Dim cmd As New OleDbCommand(req, bddcnx)
        Dim ob As VNUL = New VNUL

        For Each Dt As DataTable In DsERREURS.Tables

            Select Case Dt.TableName
                '===================ERREURS INSCRIT============================================='
                Case "Vides_INSCRIT"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into [Vides_INSCRIT] values ('" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "','" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "','" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "','" & ob.TestValeurNullSTR(Ligne("ANSCIN")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIN")) & "','" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "','" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "','" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "','" & ob.TestValeurNullSTR(Ligne("WILNAIS")) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "','" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "','" & ob.TestValeurNullSTR(Ligne("ANETIN")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "','" & ob.TestValeurNullSTR(Ligne("NS")) & "','" & ob.TestValeurNullSTR(Ligne("NG")) & "','" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "'," & ob.TestValeurNullNBR(Ligne("RANGIN")) & "," & ob.TestValeurNullNBR(Ligne("MENTIN")) & "," & ob.TestValeurNullNBR(Ligne("ELIMIN")) & "," & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("DECIIN"))) & "','" & ob.TestValeurNullSTR(Ligne("DEC")) & "','" & ob.TestValeurNullSTR(Ligne("WILBAC")) & "'," & ob.TestValeurNullNBR(Ligne("SEXE")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "','" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next

                Case "Doubles_INSCRIT"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into [Doubles_INSCRIT] values ('" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "','" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "','" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "','" & ob.TestValeurNullSTR(Ligne("ANSCIN")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIN")) & "','" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "','" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "','" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "','" & ob.TestValeurNullSTR(Ligne("WILNAIS")) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "','" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "','" & ob.TestValeurNullSTR(Ligne("ANETIN")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "','" & ob.TestValeurNullSTR(Ligne("NS")) & "','" & ob.TestValeurNullSTR(Ligne("NG")) & "','" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "'," & ob.TestValeurNullNBR(Ligne("RANGIN")) & "," & ob.TestValeurNullNBR(Ligne("MENTIN")) & "," & ob.TestValeurNullNBR(Ligne("ELIMIN")) & "," & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("DECIIN"))) & "','" & ob.TestValeurNullSTR(Ligne("DEC")) & "','" & ob.TestValeurNullSTR(Ligne("WILBAC")) & "'," & ob.TestValeurNullNBR(Ligne("SEXE")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "','" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
                Case "Rejetees_INSCRIT"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into [Rejetees_INSCRIT] values ('" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "','" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "','" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "','" & ob.TestValeurNullSTR(Ligne("ANSCIN")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIN")) & "','" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "','" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "','" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "','" & ob.TestValeurNullSTR(Ligne("WILNAIS")) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "','" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "','" & ob.TestValeurNullSTR(Ligne("ANETIN")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "','" & ob.TestValeurNullSTR(Ligne("NS")) & "','" & ob.TestValeurNullSTR(Ligne("NG")) & "','" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "'," & ob.TestValeurNullNBR(Ligne("RANGIN")) & "," & ob.TestValeurNullNBR(Ligne("MENTIN")) & "," & ob.TestValeurNullNBR(Ligne("ELIMIN")) & "," & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("DECIIN"))) & "','" & ob.TestValeurNullSTR(Ligne("DEC")) & "','" & ob.TestValeurNullSTR(Ligne("WILBAC")) & "'," & ob.TestValeurNullNBR(Ligne("SEXE")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "','" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
                    '===================ERREURS RATTRAPAGE============================================='
                Case "Vides_RATTRAPAGE"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into Vides_RATTRAPAGE values ('" & (ob.TestValeurNullSTR(Ligne("ANSCRA"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETRA")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLRA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIRA")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRRA"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullNBR(Ligne("RATRRA")) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next

                Case "Doubles_RATTRAPAGE"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into Doubles_RATTRAPAGE values ('" & (ob.TestValeurNullSTR(Ligne("ANSCRA"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETRA")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLRA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIRA")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRRA"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullNBR(Ligne("RATRRA")) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
                Case "Rejetees_RATTRAPAGE"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into Rejetees_RATTRAPAGE values ('" & (ob.TestValeurNullSTR(Ligne("ANSCRA"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETRA")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLRA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIRA")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRRA"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullNBR(Ligne("RATRRA")) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
                Case "Rejetees_RATTRAPAGE2"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into Rejetees_RATTRAPAGE values ('" & (ob.TestValeurNullSTR(Ligne("ANSCRA"))) & "'," & ob.TestValeurNullNBR(Ligne("ANETRA")) & ",'" & ob.TestValeurNullSTR(Ligne("CYCLRA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIRA")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRRA"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullNBR(Ligne("RATRRA")) & "')"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next

                    '=====================MATIERES=============================='
                Case "Vides_MATIERE"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into Vides_MATIERE values ('" & (ob.TestValeurNullSTR(Ligne("ANSCMA"))) & "',' " & ob.TestValeurNullSTR(Ligne("ANETMA")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLMA")) & "','" & ob.TestValeurNullSTR(Ligne("OPTIMA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("COMAMA"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIBEMA"))) & "'," & ob.TestValeurNullNBR(Ligne("TYPEMA")) & ",'" & ob.TestValeurNullNBR(Ligne("COEFMA")) & "','" & ob.TestValeurNullNBR(Ligne("MOYMAT")) & "')"
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
                Case "Doubles_NOTES"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into [Doubles_NOTES] values ('" & (ob.TestValeurNullSTR(Ligne("ANSCNO"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETNO")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLNO")) & "','" & ob.TestValeurNullSTR(Ligne("OPTINO")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRNO"))) & "','" & ob.TestValeurNullSTR(Ligne("COMANO")) & "','" & ob.TestValeurNullNBR(Ligne("NOJUNO")) & "','" & ob.TestValeurNullNBR(Ligne("NOSYNO")) & "','" & ob.TestValeurNullNBR(Ligne("NORANO")) & "','" & ob.TestValeurNullSTR(Ligne("ELIMNO")) & "'," & ob.TestValeurNullNBR(Ligne("RATRNO")) & ")"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
                Case "Rejetees_NOTES"
                    For Each Ligne As DataRow In Dt.Rows()
                        Try
                            req = "Insert into [Rejetees_NOTES] values ('" & (ob.TestValeurNullSTR(Ligne("ANSCNO"))) & "','" & ob.TestValeurNullSTR(Ligne("ANETNO")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLNO")) & "','" & ob.TestValeurNullSTR(Ligne("OPTINO")) & "','" & (ob.TestValeurNullSTR(Ligne("MATRNO"))) & "','" & ob.TestValeurNullSTR(Ligne("COMANO")) & "','" & ob.TestValeurNullNBR(Ligne("NOJUNO")) & "','" & ob.TestValeurNullNBR(Ligne("NOSYNO")) & "','" & ob.TestValeurNullNBR(Ligne("NORANO")) & "','" & ob.TestValeurNullSTR(Ligne("ELIMNO")) & "'," & ob.TestValeurNullNBR(Ligne("RATRNO")) & ")"
                            cmd.CommandText = req
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                    Next
            End Select
        Next

        MessageBox.Show("Veuillez consulter la BDDERREURS pour prendre connaissance des lignes avec erreurs.Si l'une des tables est vide cela veut dire qu'aucune erreurs n'a de ce type n'a été detectée.", " ", MessageBoxButtons.OK)

    End Sub

#End Region

#Region "MODULES_DE_CHRGMNT_TABLES"
    'MODULES DE CHARGEMENT DES DIFFERENTES TABLES 

    Sub Save_inscrit_access(ByRef DSres As DataSet, ByVal BddCnx As OleDbConnection, ByVal DT As DataTable, ByRef listepar As List(Of String))
        'VARIABLES & INITIALISATIONS 
        Dim listeMat As List(Of String) = New List(Of String) ' sera utilisé pour verifier si un etudiant a été deja inséré ou pas 
        ' Dim listepar As List(Of String) = New List(Of String) ' pour verifier si on a deja insérer cette ligne de parcours 

        Dim req As String
        req = " "
        Dim cmd As New OleDbCommand(req, BddCnx)
        Dim ob As New VNUL()
        Dim i As Integer = 0
        Dim s As String = ""

        Dim dtres2 As DataTable
        dtres2 = DirectCast(DT.Clone, DataTable)
        dtres2.TableName = "Doubles_INSCRIT"

        Dim j As Integer = 0
        For Each Ligne As DataRow In DT.Rows()
            Try
                i = 0
                If (listeMat.Contains(Ligne("MATRIN")) = False) Then
                    listeMat.Add(Ligne("MATRIN"))
                    'il faut le mettre dans un try catch on sait jamais la ligne existe deja 
                    req = "Insert into ETUDIANT(Id_Etudiant,NomEtud,Prenoms,NomEtudA,PrenomsA,MATRIC_INS,DATENAIS,LIEUNAISA,WILNAISA,LIEUNAIS,WILNAIS,ADRESSE,VILLE,WILAYA,CODPOST,Cycle,WILBAC,SEXE,SERIEBAC,ANNEEBAC,FILS_DE,ET_DE,MOYBAC,Nb_ATTESTATION,Nb_RNG) values ('" & Ligne("MATRIN") & "','" & apos(ob.TestValeurNullSTR(Ligne("NomEtud"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("Prenoms"))) & "','" & ob.TestValeurNullSTR(Ligne("NomEtudA")) & "','" & ob.TestValeurNullSTR(Ligne("PrenomsA")) & "','" & ob.TestValeurNullSTR(Ligne("MATRIC_INS")) & "','" & ob.TestValeurNullSTR(Ligne("DATENAIS")) & "','" & ob.TestValeurNullSTR(Ligne("LIEUNAISA")) & "','" & ob.TestValeurNullSTR(Ligne("WILNAISA")) & "','" & apos(ob.TestValeurNullSTR(Ligne("LIEUNAIS"))) & "'," & ob.TestValeurNullNBR(Ligne("WILNAIS")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("ADRESSE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("VILLE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("WILAYA"))) & "','" & ob.TestValeurNullSTR(Ligne("CODPOST")) & "','" & ob.TestValeurNullSTR(Ligne("CYCLIN")) & "'," & ob.TestValeurNullNBR(Ligne("WILBAC")) & "," & ob.TestValeurNullNBR(Ligne("SEXE")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("SERIEBAC"))) & "','" & ob.TestValeurNullSTR((Ligne("ANNEEBAC"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("FILS_DE"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("ET_DE"))) & "','" & ob.TestValeurNullNBR(Ligne("MOYBAC")) & "',0,0)"
                    cmd.CommandText = req
                    Try
                        cmd.ExecuteNonQuery() 'on met dans un try car il se peut que par erreur cet etudiant soit deja enregistré dans la table Etudiant mais qu'il ne soit pas ENregistré dans PARCOURS 
                    Catch ex As Exception
                        j = 1

                    End Try


                End If
                s = String.Concat(Ligne("MATRIN"), Ligne("ANSCIN"))
                If (listepar.Contains(s) = False) Then 'on insere 
                    req = "Insert into PARCOURS(Id_Etudiant,[AnneeScolaire],[AnneeEtude],[Option],[Ngroupe],[Nsection],[Moyenne],[Rang],[Mention],[NbNoteElimin],[NbRattrapage],[ADM],[DEC],[DECIIN],NB_RN) values ('" & Ligne("MATRIN") & "','" & Ligne("ANSCIN") & "'," & ob.TestValeurNullNBR(Ligne("ANETIN")) & ",'" & ob.TestValeurNullSTR(Ligne("OPTIIN")) & "'," & ob.TestValeurNullNBR(Ligne("NG")) & ",'" & ob.TestValeurNullSTR(Ligne("NS")) & "','" & ob.TestValeurNullNBR(Ligne("MOYEIN")) & "'," & ob.TestValeurNullNBR(Ligne("RANGIN")) & "," & ob.TestValeurNullNBR(Ligne("MENTIN")) & "," & ob.TestValeurNullNBR(Ligne("ELIMIN")) & "," & ob.TestValeurNullNBR(Ligne("RATRIN")) & ",'" & apos(ob.TestValeurNullSTR(Ligne("ADM"))) & "','" & apos(ob.TestValeurNullSTR(Ligne("DEC"))) & "','" & ob.TestValeurNullSTR(Ligne("DECIIN")) & "',0)"
                    cmd.CommandText = req
                    cmd.ExecuteNonQuery()
                    listepar.Add(s)

                Else ' il existe une ligne en deux fois, alors on a enregistré la premiere et on renvois la 2eme en erreur 
                    dtres2.ImportRow(Ligne)
                End If
            Catch ex As Exception
                j = 1

            End Try

        Next


        DSres.Tables.Add(dtres2)
        cmd.Dispose()

        If j = 1 Then
            MessageBox.Show("[INSCRIT]Une ou plusieurs lignes n'ont pas été prises en considerations car ces dernieres sont deja présentes  dans la base de données,Vous ne pouvez pas les inserer une deuxieme fois.Dirigez vous vers l'aide pour plus d'informations.", " ", MessageBoxButtons.OK)
        End If

    End Sub 'IMPORTE LES DONNEE DU DT( select * from inscrit where id<> null) VERS LA TABLE ETUDIANT 

    Sub Save_ratrapage_access(ByRef DSres As DataSet, ByVal bddcnx As OleDbConnection, ByVal DTRAT As DataTable, ByVal listeinscrit As List(Of String))



        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, bddcnx)
        Dim ob As VNUL = New VNUL


        Dim listerat As List(Of String) = New List(Of String) ' pour verifier si on a deja insérer cette ligne de RATRAPAGE 
        Dim s As String

        '***tables d'erreurs****'
        Dim dtres2 As DataTable
        dtres2 = DirectCast(DTRAT.Clone, DataTable) ' creer une datatable avec la meme structure que la table RATTRAPAGE 
        dtres2.TableName = "Doubles_RATTRAPAGE"

        Dim dtres3 As DataTable
        dtres3 = DirectCast(DTRAT.Clone, DataTable)
        dtres3.TableName = "Rejetees_RATTRAPAGE2"

        Dim j As Integer = 0

        '*****************

        For Each Ligne As DataRow In DTRAT.Rows()
            Try
                s = String.Concat(Ligne("MATRRA"), Ligne("ANSCRA"))
                If (listeinscrit.Contains(s) = True) Then 'si cette ligne est inclue dans parcours on l'insert sinon on la renvois 
                    If (listerat.Contains(s) = False) Then 'on insere si elle n'a pas deja été inserée et si on retombe une autre fois sur elle on la signale comme double 

                        req = "Insert into RATTRAPAGE(Id_Etudiant,AnneeScolaire,MoyenneRattrapage,MentRat,ElimRAt,RATRRA) values ('" & (Ligne("MATRRA")) & "','" & (Ligne("ANSCRA")) & "','" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "','" & ob.TestValeurNullNBR(Ligne("MENTRA")) & "','" & ob.TestValeurNullNBR(Ligne("ELIMRA")) & "','" & ob.TestValeurNullSTR(Ligne("RATRRA")) & "')"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()

                        req = "UPDATE PARCOURS SET [MOYENNE_RATTRAPAGE] = '" & ob.TestValeurNullNBR(Ligne("MOYERA")) & "' WHERE Id_Etudiant='" & Ligne("MATRRA") & "' AND AnneeScolaire='" & Ligne("ANSCRA") & "'"
                        cmd.CommandText = req
                        cmd.ExecuteNonQuery()

                        listerat.Add(s)

                    Else ' on insert dans le datatable des doublants
                        dtres2.ImportRow(Ligne)
                    End If

                Else ' on renvoit la ligne car aucune ligne dans la table parcours ne lui correspond(ie l'etudiant n'est pas marqué inscrit donc il ne peut pas avoir de notes de rattrapage)
                    dtres3.ImportRow(Ligne)
                End If
            Catch ex As Exception
                j = 1
            End Try

        Next
        DSres.Tables.Add(dtres2)
        DSres.Tables.Add(dtres3)
        cmd.Dispose()

        If j = 1 Then
            MessageBox.Show("[RATTRAPAGE] Une ou plusieurs lignes n'ont pas été prises en considerations car ces dernieres sont deja présentes  dans la base de données,Vous ne pouvez pas les inserer une deuxieme fois.Dirigez vous vers l'aide pour plus d'informations.", " ", MessageBoxButtons.OK)
        End If

    End Sub 'IMPORTE LES DONNEE DU DT VERS LA TABLE RATTRAPAGE 

    Sub saveGroupeAccess(ByVal cnxBdd As OleDbConnection, ByVal groupeTable As DataTable)
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sqlcmd, cnxBdd)
        For Each row As DataRow In groupeTable.Rows()
            Try
                sqlcmd = "insert into [GROUPE] (NGroupe,NSection,[Option],AnneeEtude,AnneeScolaire) values ('" & row("NG") & "','" & row("NS") & "','" & row("OPTIIN") & "','" & row("ANETIN") & "','" & row("ANSCIN") & "')"
                cmd.CommandText = sqlcmd
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                ' eliminate doubles , cause we can have for NG 01 as well as 1
            End Try

        Next
        cmd.Dispose()
    End Sub 'ENREGISTRE Le contenu de DT dans la table GROUPE DE LA BDD

    Sub saveSectionAccess(ByVal cnxBdd As OleDbConnection, ByVal sectionTable As DataTable)
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sqlcmd, cnxBdd)
        For Each row As DataRow In sectionTable.Rows()
            Try
                sqlcmd = "insert into [SECTION] (NSection,[Option],AnneeEtude,AnneeScolaire) values ('" & row("NS") & "','" & row("OPTIIN") & "','" & row("ANETIN") & "','" & row("ANSCIN") & "')"

                cmd.CommandText = sqlcmd
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                'eliminer les douboulons, car on peut avoir 1 ou 01 pour NS
            End Try

        Next
        cmd.Dispose()
    End Sub 'ENREGISTRE Le contenu de DT dans la table SECTION DE LA BDD

    Sub saveMoyenneMatiereAccess(ByVal cnxBdd As OleDbConnection, ByVal moyenneMatiereTable As DataTable)
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sqlcmd, cnxBdd)
        For Each row As DataRow In moyenneMatiereTable.Rows()
            'sqlcmd = "insert into MOYENNEMATIERE ([Code],[Option],AnneeEtude,AnneeScolaire,CoefMat,MoyenMat) values ('" & row("COMAMA") & "','" & row("OPTIMA") & "','" & row("ANETMA") & "','" & row("ANSCMA") & "','" & row("COEFMA") & "','" & row("MOYMAT") & "')"
            sqlcmd = "insert into MOYENNEMATIERE ([Code],[Option],AnneeEtude,AnneeScolaire,CoefMat,MoyenMat,TypeMat) values ('" & row("COMAMA") & "','" & row("OPTIMA") & "','" & row("ANETMA") & "','" & row("ANSCMA") & "','" & row("COEFMA") & "','" & row("MOYMAT") & "','" & row("TYPEMA") & "')"

            cmd.CommandText = sqlcmd
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

        Next
        cmd.Dispose()
    End Sub 'ENREGISTRE Le contenu de DT dans la table MOYENNEMATIERE DE LA BDD

    Sub saveMatiereAccess(ByVal cnxBdd As OleDbConnection, ByVal matiereTable As DataTable)
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sqlcmd, cnxBdd)
        For Each row As DataRow In matiereTable.Rows()
            Try
                If (row("LIBEMA") <> "INIT ECONOMIE") Then
                    sqlcmd = "insert into [MATIERE] ([Code],[Option],AnneeEtude,Intitule) values ('" & row("COMAMA") & "','" & row("OPTIMA") & "','" & row("ANETMA") & "','" & apos(row("LIBEMA")) & "')"
                    cmd.CommandText = sqlcmd
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try


                End If
            Catch ex As Exception

            End Try

        Next
        cmd.Dispose()
    End Sub 'ENREGISTRE Le contenu de DT dans la table MATIERE DE LA BDD

    Sub saveNOTE(ByVal cnxBdd As OleDbConnection, ByVal noteTable As DataTable, ByVal listeKeyParcours As List(Of String), ByRef DsRejetees As DataSet)
        Dim c As VNUL = New VNUL
        Dim sqlcmd As String = " "
        Dim cmd As OleDbCommand
        Dim keyParcours As String
        cmd = New OleDbCommand(sqlcmd, cnxBdd)

        Dim rejeteTable As DataTable = New DataTable()   ' Va contenir les lignes rejetées 
        With rejeteTable.Columns
            .Add("ANSCNO", GetType(String))
            .Add("ANETNO", GetType(Integer))
            .Add("CYCLNO", GetType(String))
            .Add("OPTINO", GetType(String))
            .Add("MATRNO", GetType(String))
            .Add("COMANO", GetType(String))
            .Add("NOJUNO", GetType(Double))
            .Add("NOSYNO", GetType(Double))
            .Add("NORANO", GetType(Double))
            .Add("ELIMNO", GetType(Boolean))
            .Add("RATRNO", GetType(Integer))
        End With
        For Each row As DataRow In noteTable.Rows()
            Try
                keyParcours = String.Concat(row("MATRNO"), row("ANSCNO")) 'la clé primaire de la table  Parcours
                If (listeKeyParcours.Contains(keyParcours) = True) Then
                    If (IsDBNull(row("ELIMNO"))) Then
                        sqlcmd = "insert into [NOTE] (Id_Etudiant,AnneeScolaire,Id_Matiere,[Option],AnneeEtude,NoteJuin,NoteSynthese,NoteRattrapage,Elimine,RATRNO) values('" & row("MATRNO") & "','" & row("ANSCNO") & "','" & row("COMANO") & "','" & row("OPTINO") & "','" & row("ANETNO") & "','" & row("NOJUNO") & "','" & c.TestValeurNullSYNTHESE(row("NOSYNO")) & "','" & row("NORANO") & "', FALSE ,'" & c.TestValeurNullRATRNO(row("RATRNO")) & "')"
                    ElseIf (row("ELIMNO") = False) Then
                        sqlcmd = "insert into [NOTE] (Id_Etudiant,AnneeScolaire,Id_Matiere,[Option],AnneeEtude,NoteJuin,NoteSynthese,NoteRattrapage,Elimine,RATRNO) values('" & row("MATRNO") & "','" & row("ANSCNO") & "','" & row("COMANO") & "','" & row("OPTINO") & "','" & row("ANETNO") & "','" & row("NOJUNO") & "','" & c.TestValeurNullSYNTHESE(row("NOSYNO")) & "','" & row("NORANO") & "', FALSE ,'" & c.TestValeurNullRATRNO(row("RATRNO")) & "')"
                    Else
                        sqlcmd = "insert into [NOTE] (Id_Etudiant,AnneeScolaire,Id_Matiere,[Option],AnneeEtude,NoteJuin,NoteSynthese,NoteRattrapage,Elimine,RATRNO) values('" & row("MATRNO") & "','" & row("ANSCNO") & "','" & row("COMANO") & "','" & row("OPTINO") & "','" & row("ANETNO") & "','" & row("NOJUNO") & "','" & c.TestValeurNullSYNTHESE(row("NOSYNO")) & "','" & row("NORANO") & "', TRUE ,'" & c.TestValeurNullRATRNO(row("RATRNO")) & "')"
                    End If

                    cmd.CommandText = sqlcmd
                    cmd.ExecuteNonQuery()
                Else
                    rejeteTable.Rows.Add(row("ANSCNO"), row("ANETNO"), "I", row("OPTINO"), row("MATRNO"), row("COMANO"), row("NOJUNO"), row("NOSYNO"), row("NORANO"), row("ELIMNO"), row("RATRNO"))
                End If

            Catch ex As Exception
            End Try
        Next
        cmd.Dispose()
        rejeteTable.TableName = "Rejetees_NOTES"
        DsRejetees.Tables.Add(rejeteTable)

    End Sub

#End Region

#Region "autres_fonctions"

    Function LoadExcelFileIntoDT(ByRef DS As DataSet, ByVal sqlCmd As String, ByVal excelfileChemin As String, ByVal DataTableName As String) As Integer
        Dim cnx As System.Data.OleDb.OleDbConnection
        Dim DT As System.Data.OleDb.OleDbDataAdapter
        Dim i As Integer = 0
        Try
            cnx = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelfileChemin & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';")
            cnx.Open()
            DT = New System.Data.OleDb.OleDbDataAdapter(sqlCmd, cnx)
            DT.TableMappings.Add("Table", DataTableName)
            DT.Fill(DS)
            cnx.Close()
        Catch ex As Exception
            i = 1

        End Try
        LoadExcelFileIntoDT = i
    End Function 'ajoute la feuille de calcul excel a partir de la cmd comme une nouvelle datatable avec le nom datatblename A la DATASET DS; renvoit 0 s'il n'y a aucune erreur, 1 sinon 

    Sub removeDuplicatesNote(ByVal noteTableWithDuplicates As DataTable, ByRef DsFichier As DataSet, ByRef DsERREURS As DataSet)
        Dim noteTableFreeOfDuplicates As DataTable = New DataTable()   'chaque ligne dans cette table apparait qu'une seule fois
        Dim noteDoublons As DataTable = New DataTable() 'Va contenir les lignes qui ont été dupliquées
        Dim dataset As DataSet = New DataSet()

        'Creation des colonnes 
        With noteTableFreeOfDuplicates.Columns
            .Add("MATRNO", GetType(String))
            .Add("ANSCNO", GetType(String))
            .Add("ANETNO", GetType(Integer))
            .Add("OPTINO", GetType(String))
            .Add("COMANO", GetType(String))
            .Add("NOJUNO", GetType(Double))
            .Add("NOSYNO", GetType(Double))
            .Add("NORANO", GetType(Double))
            .Add("ELIMNO", GetType(Boolean))
            .Add("RATRNO", GetType(Integer))
        End With


        With noteDoublons.Columns
            .Add("ANSCNO", GetType(String))
            .Add("ANETNO", GetType(Integer))
            .Add("CYCLNO", GetType(String))
            .Add("OPTINO", GetType(String))
            .Add("MATRNO", GetType(String))
            .Add("COMANO", GetType(String))
            .Add("NOJUNO", GetType(Double))
            .Add("NOSYNO", GetType(Double))
            .Add("NORANO", GetType(Double))
            .Add("ELIMNO", GetType(Boolean))
            .Add("RATRNO", GetType(Integer))
        End With

        'eliminer les doublons
        Dim keyList As List(Of String) = New List(Of String)  'Liste des clés primaires
        Dim key As String

        For Each row As DataRow In noteTableWithDuplicates.Rows()
            key = String.Concat(row("ANSCNO"), String.Concat(row("MATRNO"), row("COMANO"))) 'la clé primaire de la table note
            If (keyList.Contains(key) = False) Then  'la ligne n'existe pas dans la table
                keyList.Add(key)
                noteTableFreeOfDuplicates.Rows.Add(row("MATRNO"), row("ANSCNO"), row("ANETNO"), row("OPTINO"), row("COMANO"), row("NOJUNO"), row("NOSYNO"), row("NORANO"), row("ELIMNO"), row("RATRNO"))
            Else    'la ligne est dupliquée
                noteDoublons.Rows.Add(row("ANSCNO"), row("ANETNO"), "I", row("OPTINO"), row("MATRNO"), row("COMANO"), row("NOJUNO"), row("NOSYNO"), row("NORANO"), row("ELIMNO"), row("RATRNO"))
            End If
        Next
        noteTableFreeOfDuplicates.TableName = "NOTES"
        noteDoublons.TableName = "Doubles_NOTES"

        DsFichier.Tables.Add(noteTableFreeOfDuplicates)
        DsERREURS.Tables.Add(noteDoublons)

    End Sub

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


    End Function 'VERIFIE ET REGLE LE PROBLEME D'APOSTROPHE DANS LA CMD SQL 
#End Region


End Class

