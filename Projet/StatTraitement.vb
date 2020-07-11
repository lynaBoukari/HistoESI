Imports System.Data.OleDb

Public Class Statistiques

    '-----------------[STAT REUSSITE GENERALE]----------------
#Region "REUSSITE GENERALE"
    Public Function ReussiteParNiveau(ByRef dt As DataTable, ByVal Opt As String, ByVal anneeScolaire As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double
        er = False 'servira a verifier s'il ya eu une erreur ( possible que l'année entrée ne figure pas dans la bdd donc on aura une division par 0 pas d'exception mais on le sinale )
        Dim k As Double
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS As String
        Dim anEtude As Integer
        Dim test As Integer = 0
        Dim nbrach, nbadm, nbred, nbetu, nbex, nbmald, nbabond, total As Integer
        nbetu = 0
        dt = New DataTable
        With dt.Columns
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Nombre d'admis", GetType(Integer))
            .Add("Nombre des rachetés", GetType(Integer))
            .Add("Nombre redoublons", GetType(Integer))
            .Add("Nombre d'exclus", GetType(Integer))
            .Add("Nombre d'abondons", GetType(Integer))
            .Add("Nombre de maladie", GetType(Integer))
        End With
        cnx.Open()
        anneeScolaireS = anneeScolaire.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
        Integer.TryParse(anneeEtude, anEtude)
        If Opt = "Option" Then
            'On recupere le nombre dEtudiants qui ont reussit leurs année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='1')"
            cmd.CommandText = req
            nbadm = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='2' )"
            cmd.CommandText = req
            nbrach = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='3' )"
            cmd.CommandText = req
            nbred = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='4' )"
            cmd.CommandText = req
            nbex = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( Moyenne=88.88 )"
            cmd.CommandText = req
            nbmald = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( Moyenne=99.99 )"
            cmd.CommandText = req
            nbabond = cmd.ExecuteScalar()
            nbetu = nbrach + nbadm
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & ""
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            'on teste si y a des etudiant ou la decision n'est pas fixée donc les stat ne seront pas correcte 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='0' OR DECIIN='' )"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        Else
            'On recupere le nombre dEtudiants qui ont reussit leurs année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='1')"
            cmd.CommandText = req
            nbadm = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='2')"
            cmd.CommandText = req
            nbrach = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='3')"
            cmd.CommandText = req
            nbred = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='4')"
            cmd.CommandText = req
            nbex = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( Moyenne=99.99)"
            cmd.CommandText = req
            nbabond = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( Moyenne=88.88)"
            cmd.CommandText = req
            nbmald = cmd.ExecuteScalar()
            nbetu = nbadm + nbrach
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & ""
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            'on teste si y a des etudiant ou la decision n'est pas fixée donc les stat ne seront pas correcte 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='0' OR DECIIN='')"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        End If
        dt.Rows.Add(total, nbadm, nbrach, nbred, nbex, nbabond, nbmald)
        k = nbetu / total
        If Double.IsNaN(k) Then
            er = True
        End If
        k = Math.Round(k, 4)
        k = k * 100
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        ReussiteParNiveau = k
    End Function 'renvoit un tableau d'une colonne deux lignes avec une année et son taux de réussite ( on pourrait renvoyer que le taux )  'renvoit un tableau d'une colonne deux lignes avec une année et son taux de réussite ( on pourrait renvoyer que le taux )


    Public Function ReussiteParNiveau(ByRef dt As DataTable, ByVal Opt As String, ByVal anneeScolaire1 As String, ByVal anneeScolaire2 As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double(,)
        er = False 'servira a verifier s'il ya eu une erreur ( possible que l'année entrée ne figure pas dans la bdd donc on aura une division par 0 pas d'exception mais on le sinale )
        Dim k As Double
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS, anneeScolaireSs As String
        Dim nbetu, total, i, j, test, g As Integer
        g = 0 ' servira a gerer les indice du tableau resultat

        dt = New DataTable
        With dt.Columns
            .add("Année", GetType(Integer))
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Nombre d'etudiants ayant réussit", GetType(Integer)) ' hnaya admis + rachat = reussite
            .Add("Nombre d'étudiants ayant échoué", GetType(Integer)) ' non admis = echec
        End With


        cnx.Open()
        Integer.TryParse(anneeScolaire1, i) ' pour pouvoir faire la boucle on le transforme en entier 
        Integer.TryParse(anneeScolaire2, j)
        Dim res(1, j - i) As Double 'on calcule la taille de lintervalle pour creer le tab resultat 

        For h As Integer = i To j Step 1
            anneeScolaireS = CStr(h) 'donne lannee courante de la boucle en string pour lutiliser dans la requette 
            anneeScolaireSs = anneeScolaireS.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
            If Opt = "Option" Then
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND ( DECIIN='1' OR DECIIN='2')"
                cmd.CommandText = req
                nbetu = cmd.ExecuteScalar()

                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                'on teste si y a des etudiant ou la decision n'est pas fixée donc les stat ne seront pas correcte 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND ( DECIIN='0' OR DECIIN='' )"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            Else
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND ( DECIIN='1' OR DECIIN='2')"
                cmd.CommandText = req
                nbetu = cmd.ExecuteScalar()


                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                'on teste si y a des etudiant ou la decision n'est pas fixée donc les stat ne seront pas correcte 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND ( DECIIN='0' OR DECIIN='')"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            End If

            dt.Rows.Add(h, total, nbetu, total - nbetu)
            k = nbetu / total
            If Double.IsNaN(k) Then
                er = True ' erreur division par 0 car l'année scolaire nexiste pas dans la bdd 
            End If
            k = Math.Round(k, 4)
            k = k * 100
            res(0, g) = anneeScolaireS
            res(1, g) = k
            g = g + 1
        Next
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        ReussiteParNiveau = res
    End Function 'pour lintervalle d'année  

#End Region

    '-----------------[STAT REUSSITE GROUPE]----------------
#Region "REUSSITE PAR GROUPE"

    Public Function ReussiteParGroupe(ByRef dt As DataTable, ByVal opt As String, ByVal anneeScolaire As String, ByVal NG As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anEtude, ngrp, k As Double
        Dim anneeScolaireS As String
        Dim test As Integer = 0
        anneeScolaireS = anneeScolaire.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
        Integer.TryParse(anneeEtude, anEtude)
        Integer.TryParse(NG, ngrp)
        Dim nbrach, nbadm, nbred, nbetu, nbex, nbmald, nbabond, total As Integer
        nbetu = 0
        er = False
        dt = New DataTable
        With dt.Columns
            .Add("Nombre d'étudiants du groupe", GetType(Integer))
            .Add("Nombre d'admis", GetType(Integer))
            .Add("Nombre des rachetés", GetType(Integer))
            .Add("Nombre redoublons", GetType(Integer))
            .Add("Nombre d'exclus", GetType(Integer))
            .Add("Nombre d'abondons", GetType(Integer))
            .Add("Nombre de maladie", GetType(Integer))
        End With '" AND Ngroupe=" & ngrp & " 
        cnx.Open()
        'On recupere le nombre dEtudiants qui ont reussit leurs année 
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( DECIIN='1')"
        cmd.CommandText = req
        nbadm = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( DECIIN='2' )"
        cmd.CommandText = req
        nbrach = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( DECIIN='3' )"
        cmd.CommandText = req
        nbred = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( DECIIN='4' )"
        cmd.CommandText = req
        nbex = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( Moyenne=88.88 )"
        cmd.CommandText = req
        nbmald = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & " AND ( Moyenne=99.99 )"
        cmd.CommandText = req
        nbabond = cmd.ExecuteScalar()
        nbetu = nbrach + nbadm
        'On recupere le nombre total des etudiant dans ce groupe
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & ngrp & ""
        cmd.CommandText = req
        total = cmd.ExecuteScalar()
        'on teste si y a des etudiant ou la decision n'est pas fixée donc les stat ne seront pas correcte 
        req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( DECIIN='0' OR DECIIN='' )"
        cmd.CommandText = req
        test = cmd.ExecuteScalar() + test
        dt.Rows.Add(total, nbadm, nbrach, nbred, nbex, nbabond, nbmald)
        k = nbetu / total
        If Double.IsNaN(k) Then
            er = True 'il y a eu une div par 0 car l'année scolaire ou le groupe nexiste pas dans la bdd 
        End If
        k = Math.Round(k, 4)
        k = k * 100
        cnx.Close()
        cmd.Dispose()
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        ReussiteParGroupe = k
    End Function

    Public Function ReussiteParGroupe(ByVal opt As String, ByVal anneeScolaire1 As String, ByVal anneeScolaire2 As String, ByVal NG As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double(,)
        er = False
        Dim k, nbEtu, total, ngrp As Double
        Dim i, j As Integer
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS, anneeScolaireSs As String
        Dim test As Integer = 0
        cnx.Open()

        Integer.TryParse(NG, ngrp)
        Integer.TryParse(anneeScolaire1, i) ' pour pouvoir faire la boucle on le transforme en entier 
        Integer.TryParse(anneeScolaire2, j)

        Dim res(1, j - i) As Double 'on calcule la taille de lintervalle pour creer le tab resultat 
        Dim g As Integer = 0 ' servira a gerer les indice du tableau resultat

        For h As Integer = i To j Step 1

            anneeScolaireS = CStr(h) 'donne lannee courante de la boucle en string pour lutiliser dans la requette 
            anneeScolaireSs = anneeScolaireS.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
            If opt = "Option" Then
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & " AND ( DECIIN='1' OR DECIIN='2')"
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()

                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & " AND ( DECIIN='0' OR DECIIN='')"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            Else
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & " AND ( DECIIN='1' OR DECIIN='2')"
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()

                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Ngroupe=" & NG & " AND ( DECIIN='0' OR DECIIN='')"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            End If


            k = nbEtu / total
            If Double.IsNaN(k) Then
                er = True
            End If
            k = Math.Round(k, 4)
            k = k * 100

            res(0, g) = anneeScolaireS
            res(1, g) = k
            g = g + 1
        Next


        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        ReussiteParGroupe = res

    End Function

#End Region

    '-----------------[STAT TAUX D'ABONDONS]----------------
#Region "TAUX D'ABANDON"

    Public Function Abondons(ByRef dt As DataTable, ByVal opt As String, ByVal anneeScolaire As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double(,)
        Dim res(1, 1) As Double
        Dim k As Double
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS As String
        Dim anEtude, nbetu, total As Integer
        Dim test As Integer = 0
        dt = New DataTable
        With dt.Columns
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Nombre d'abandons", GetType(Integer))
        End With
        cnx.Open()
        anneeScolaireS = anneeScolaire.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
        Integer.TryParse(anneeEtude, anEtude)
        If opt = "Option" Then
            'On recupere le nombre dEtudiants qui ont reussit leurs année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND  Moyenne=99.99" 'a revoir si deccin5 howa abadons 
            cmd.CommandText = req
            nbetu = cmd.ExecuteScalar()
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & ""
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anEtude & " AND ( Moyenne=0 OR Moyenne is null )" ' a revoir si deccin5 howa abadons 
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        Else
            'On recupere le nombre dEtudiants qui ont reussit leurs année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Moyenne=99.99"
            cmd.CommandText = req
            nbetu = cmd.ExecuteScalar()
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & ""
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND (Moyenne=0 OR Moyenne is null)"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        End If
        dt.Rows.Add(total, nbetu)
        k = nbetu / total
        If Double.IsNaN(k) Then
            er = True
        End If
        k = Math.Round(k, 4)
        k = k * 100
        cnx.Close()
        res(0, 0) = Integer.Parse(anneeScolaire)
        res(1, 0) = k
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Abondons = res
    End Function

    Public Function Abondons(ByRef dt As DataTable, ByVal Opt As String, ByVal anneeScolaire1 As String, ByVal anneeScolaire2 As String, ByVal anneeEtude As String, ByRef er As Boolean) As Double(,)
        Dim k, nbEtu, total As Double
        Dim i, j As Integer
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS, anneeScolaireSs As String
        Dim test As Integer = 0
        cnx.Open()
        dt = New DataTable
        With dt.Columns
            .Add("Année", GetType(Integer))
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Nombre d'abandons", GetType(Integer))
        End With
        Integer.TryParse(anneeScolaire1, i) ' pour pouvoir faire la boucle on le transforme en entier 
        Integer.TryParse(anneeScolaire2, j)
        Dim res(1, j - i) As Double 'on calcule la taille de lintervalle pour creer le tab resultat 
        Dim g As Integer = 0 ' servira a gerer les indice du tableau resultat
        For h As Integer = i To j Step 1
            anneeScolaireS = CStr(h) 'donne lannee courante de la boucle en string pour lutiliser dans la requette 
            anneeScolaireSs = anneeScolaireS.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
            If Opt = "Option" Then
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Moyenne=99.99"
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()
                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND (Moyenne IS NULL  OR Moyenne=0)"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            Else
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Moyenne=99.99"
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()
                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & ""
                cmd.CommandText = req
                total = cmd.ExecuteScalar()
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND (Moyenne IS NULL OR Moyenne=0)"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            End If
            k = nbEtu / total
            If Double.IsNaN(k) Then
                er = True
            End If
            k = Math.Round(k, 4)
            k = k * 100
            res(0, g) = anneeScolaireS
            res(1, g) = k
            g = g + 1
            dt.Rows.Add(h, total, nbEtu)
        Next
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        Abondons = res
    End Function 'pour lintervalle d'année

#End Region

    '-----------------[STAT taux de reussite par module]-------------
#Region " REUSSITE PAR MODULE "
    Public Function ReussiteParModule(ByRef dt As DataTable, ByVal intitule As String, ByVal Opt As String, ByVal anneeEtude As String, ByVal anneeScolaire As String, ByRef er As Boolean, ByRef err As Boolean) As Double
        er = False
        err = False
        Dim k As Double
        Dim anneeScolaireS, cd As String
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim test, nbEtu, total, nbelim As Integer
        test = 0
        cd = ""
        dt = New DataTable
        With dt.Columns
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Etudiants ayant la moyenne", GetType(Integer))
            .Add("Etudiants n'ayant pas la moyenne", GetType(Integer))
            .Add("Etudiants ayant une NE ", GetType(Integer))
        End With
        cnx.Open()
        anneeScolaireS = anneeScolaire.Substring(2, 2)  '(2002-> 02 Car cest stocké comme ça dans la bdd°
        'on recupere le code du module 
        req = " SELECT Code FROM MATIERE WHERE AnneeEtude=" & anneeEtude & "AND [Option]='" & Opt & "' AND Intitule='" & intitule & "'"
        Try
            cmd.CommandText = req
            cd = cmd.ExecuteScalar
            If (cd = "" Or IsDBNull(cd)) Then
                err = True
            End If
        Catch ex As Exception
            err = True
        End Try
        'On recupere le nombre dEtudiants qui ont une moyenne superieure a 10 dans le module  
        req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ((NoteJuin >= 10) OR (NoteRattrapage >= 10))"
        cmd.CommandText = req
        nbEtu = cmd.ExecuteScalar()
        'On recupere le nombre total des etudiant dans cette année 
        req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "'"
        cmd.CommandText = req
        total = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ( Elimine=true )"
        cmd.CommandText = req
        nbelim = cmd.ExecuteScalar()
        req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ((NoteJuin=0) OR (NoteRattrapage=0))"
        cmd.CommandText = req
        test = cmd.ExecuteScalar() + test
        k = nbEtu / total
        If Double.IsNaN(k) Then
            er = True
        End If
        dt.Rows.Add(total, nbEtu, total - nbEtu, nbelim)
        k = Math.Round(k, 4) ' on recupere 4 chiffre apres la virgule 
        k = k * 100
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        ReussiteParModule = k
    End Function

    Public Function ReussiteParModule(ByRef dt As DataTable, ByVal intitule As String, ByVal Opt As String, ByVal anneeEtude As String, ByVal anneeScolaire1 As String, ByVal anneeScolaire2 As String, ByRef er As Boolean, ByRef err As Boolean) As Double(,)
        er = False
        err = False
        Dim k As Double
        Dim i, j As Integer
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS, anneeScolaireSs, cd As String
        Dim test, nbEtu, total, nbelim As Integer
        test = 0
        cnx.Open()
        dt = New DataTable
        With dt.Columns
            .Add("Année", GetType(Integer))
            .Add("Nombre total d'étudiants", GetType(Integer))
            .Add("Etudiants ayant la moyenne", GetType(Integer))
            .Add("Etudiants n'ayant pas la moyenne", GetType(Integer))
            .Add("Etudiants ayant une NE ", GetType(Integer))
        End With
        Integer.TryParse(anneeScolaire1, i) ' pour pouvoir faire la boucle on le transforme en entier 
        Integer.TryParse(anneeScolaire2, j)
        Dim res(1, j - i) As Double 'on calcule la taille de lintervalle pour creer le tab resultat 
        Dim g As Integer = 0 ' servira a gerer les indice du tableau resultat
        'on recupere le code du module 
        req = " SELECT Code FROM MATIERE WHERE AnneeEtude=" & anneeEtude & "AND [Option]='" & Opt & "' AND Intitule='" & intitule & "'"
        Try
            cmd.CommandText = req
            cd = cmd.ExecuteScalar
            If (cd = "" Or IsDBNull(cd)) Then
                err = True
            End If
        Catch ex As Exception
            err = True
        End Try
        For h As Integer = i To j Step 1
            anneeScolaireS = CStr(h) 'donne lannee courante de la boucle en string pour lutiliser dans la requette 
            anneeScolaireSs = anneeScolaireS.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)
            'On recupere le nombre dEtudiants qui ont une moyenne superieure a 10 dans le module  
            req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ((NoteJuin >= 10) OR (NoteRattrapage >= 10))"
            cmd.CommandText = req
            nbEtu = cmd.ExecuteScalar()
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "'"
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ( Elimine=true )"
            cmd.CommandText = req
            nbelim = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM [NOTE] WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=" & anneeEtude & " AND Id_Matiere='" & cd & "' AND ((NoteJuin=0) OR (NoteRattrapage=0))"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
            k = nbEtu / total
            If Double.IsNaN(k) Then 'possible que l'année voulu ne figure pas dans la bdd (pas encore chargé ) alors on aura une div par 0 
                er = True
            End If
            k = Math.Round(k, 4) ' on recupere 4 chiffre apres la virgule 
            k = k * 100
            res(0, g) = anneeScolaireS
            res(1, g) = k
            g = g + 1
            dt.Rows.Add(h, total, nbEtu, total - nbEtu, nbelim)
        Next
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        ReussiteParModule = res
    End Function

#End Region

    '-----------------[STAT NOMBRE DE DIPLOME PAR GENRE]---------------------------------
#Region "DIPLOME PAR GENRE"
    Public Function Diplomes(ByRef dt As DataTable, ByVal Opt As String, ByVal anneeScolaire As String, ByRef er As Boolean) As Double
        er = False
        Dim k As Double
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS As String
        Dim test, nbetu, total, totaletu As Integer
        test = 0
        dt = New DataTable

        With dt.Columns
            .Add("Nombre total d'étudiants en 5eme année", GetType(Integer))
            .Add("Nombre total de diplomés", GetType(Integer))
            .Add("Nombre de femmes diplomées ", GetType(Integer))
            .Add("Nombre d'hommes diplomés ", GetType(Integer))
        End With

        cnx.Open()
        anneeScolaireS = anneeScolaire.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02 c'est stocké comme ça dans la bdd)
        If Opt = "Option " Then 'si l'option n'est pas specifié alors on fait pour toute lannee detude en general 
            'On recupere le nombre dEtudiants qui ont reussit leurs année ie ont eu leur diplome
            req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireS & "' AND PARCOURS.AnneeEtude=5 AND ( PARCOURS.DECIIN='1' OR PARCOURS.DECIIN='2' ) AND ETUDIANT.Sexe=1 "
            cmd.CommandText = req
            nbetu = cmd.ExecuteScalar() ' recup nb diplomé homme 
            'On recupere le nombre total des diplomé dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=5 AND ( DECIIN='1' OR DECIIN='2' )"
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            'On recupere le nombre total etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=5"
            cmd.CommandText = req
            totaletu = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireS & "' AND PARCOURS.AnneeEtude=5 AND ( PARCOURS.DECIIN='0' OR PARCOURS.DECIIN='' )"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        Else 'l'option est specifié alors on la rajoute comme condition
            'On recupere le nombre dEtudiants qui ont reussit leurs année 
            req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireS & "' AND PARCOURS.AnneeEtude=5 AND PARCOURS.[Option]='" & Opt & "' AND ( PARCOURS.DECIIN='1' OR PARCOURS.DECIIN='2' ) AND ETUDIANT.Sexe=1 "
            cmd.CommandText = req
            nbetu = cmd.ExecuteScalar()
            'On recupere le nombre total des etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=5 AND ( DECIIN='1' OR DECIIN='2' )"
            cmd.CommandText = req
            total = cmd.ExecuteScalar()
            'On recupere le nombre total etudiant dans cette année 
            req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireS & "' AND AnneeEtude=5"
            cmd.CommandText = req
            totaletu = cmd.ExecuteScalar()
            req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireS & "' AND PARCOURS.AnneeEtude=5 AND PARCOURS.[Option]='" & Opt & "' AND ( PARCOURS.DECIIN='1' OR PARCOURS.DECIIN='2' )"
            cmd.CommandText = req
            test = cmd.ExecuteScalar() + test
        End If
        dt.Rows.Add(totaletu, total, total - nbetu, nbetu)
        k = nbetu / total
        If Double.IsNaN(k) Then
            er = True
        End If
        k = Math.Round(k, 4)
        k = k * 100
        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        Diplomes = k
    End Function

    Public Function Diplomes(ByVal Opt As String, ByVal anneeScolaire1 As String, ByVal anneeScolaire2 As String, ByRef er As Boolean)
        er = False
        Dim k, nbEtu, total As Double
        Dim i, j As Integer
        Dim cnx As New OleDbConnection(connexionForm.chcnx)
        Dim req As String = " "
        Dim cmd As New OleDbCommand(req, cnx)
        Dim anneeScolaireS, anneeScolaireSs As String
        Dim test As Integer = 0
        cnx.Open()

        Integer.TryParse(anneeScolaire1, i) ' pour pouvoir faire la boucle on le transforme en entier 
        Integer.TryParse(anneeScolaire2, j)
        Dim res(1, j - i) As Double 'on calcule la taille de lintervalle pour creer le tab resultat 

        Dim g As Integer = 0 ' servira a gerer les indice du tableau resultat
        For h As Integer = i To j Step 1

            anneeScolaireS = CStr(h) 'donne lannee courante de la boucle en string pour lutiliser dans la requette 
            anneeScolaireSs = anneeScolaireS.Substring(2, 2)   'on recupere les 2 dernier chiffre (2002-> 02..)

            If Opt = "Option " Then 'si l'option n'est pas specifié alors on fait pour toute lannee detude en general 
                'On recupere le nombre dEtudiants qui ont reussit leurs année ie ont eu leur diplome
                req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireSs & "' AND PARCOURS.AnneeEtude=5 AND ( PARCOURS.DECIIN='1' OR PARCOURS.DECIIN='2' ) AND ETUDIANT.Sexe=1 "
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()

                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=5 AND ( DECIIN='1' OR DECIIN='2' )"
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireSs & "' AND PARCOURS.AnneeEtude=5 AND ( PARCOURS.DECIIN='0' OR PARCOURS.DECIIN='')"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test

            Else 'l'option est specifié alors on la rajoute comme condition
                'On recupere le nombre dEtudiants qui ont reussit leurs année 
                req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireSs & "' AND PARCOURS.AnneeEtude=5 AND PARCOURS.[Option]='" & Opt & "' AND ( PARCOURS.DECIIN='1' OR PARCOURS.DECIIN='2' ) AND ETUDIANT.Sexe=1 "
                cmd.CommandText = req
                nbEtu = cmd.ExecuteScalar()

                'On recupere le nombre total des etudiant dans cette année 
                req = "SELECT count(*) FROM PARCOURS WHERE [Option]='" & Opt & "' AND AnneeScolaire='" & anneeScolaireSs & "' AND AnneeEtude=5 AND ( DECIIN='1' OR DECIIN='2' )"
                cmd.CommandText = req
                total = cmd.ExecuteScalar()

                req = "SELECT count(*) FROM PARCOURS INNER JOIN ETUDIANT ON ETUDIANT.Id_Etudiant=PARCOURS.Id_Etudiant WHERE PARCOURS.AnneeScolaire='" & anneeScolaireSs & "' AND PARCOURS.AnneeEtude=5 AND PARCOURS.[Option]='" & Opt & "' AND ( PARCOURS.DECIIN='0' OR PARCOURS.DECIIN='' )"
                cmd.CommandText = req
                test = cmd.ExecuteScalar() + test
            End If

            k = nbEtu / total
            If Double.IsNaN(k) Then
                er = True
            End If
            k = Math.Round(k, 4) ' on recupere 4 chiffre apres la virgule 
            k = k * 100

            res(0, g) = anneeScolaireS
            res(1, g) = k
            g = g + 1
        Next

        If test <> 0 Then
            MessageBox.Show("Il se peut que les résultats ne soient pas representatifs à cause du manques de données dans la Base de données", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cnx.Close()
        Diplomes = res
    End Function

#End Region

End Class

