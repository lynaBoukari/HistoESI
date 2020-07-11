Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.OleDb

Public Class Stats_saisie
    Public intervalle As Boolean
    Public annee As Boolean
    Private stt As Statistiques = New Statistiques
    Private j As Integer = 0
    Private k As Integer
    ' ------------------------------------------- chargement de la fenetre -----------------------------------------------------
#Region "chargement de la fenetre"
    Private Sub stat_saisie_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        j = 1
        If annee = True Then
            anneeComboBox.Visible = True
            annee1ComboBox.Visible = False
            annee2ComboBox.Visible = False
        Else
            anneeComboBox.Visible = False
            annee1ComboBox.Visible = True
            annee2ComboBox.Visible = True
        End If
        annee1ComboBox.SelectedItem = "Année scolaire 1"
        annee2ComboBox.SelectedItem = "Année scolaire 2"
        anneeComboBox.SelectedIndex = 0

        'ajout des valeurs par defaut pour le pannel de stat general / abandon 
        generalAnetComboBox.SelectedIndex = 5
        generalOptionComboBox.SelectedIndex = 0

        'ajout des valeurs par defaut pour le pannel de stat GROUPE
        groupeOptionComboBox.SelectedIndex = 0
        groupeAnetComboBox.SelectedIndex = 5
        groupeGroupeComboBox.SelectedIndex = 0

        'ajout des valeurs par defaut pour le pannel de stat diplome 
        diplomesOptionComboBox.SelectedIndex = 0

        'ajout des valeurs par defaut pour le pannel de stat module
        moduleOptionComboBox.SelectedIndex = 0
        moduleAnetComboBox.SelectedIndex = 4
        moduleModuleComboBox.SelectedIndex = 0

        iconPicture.Visible = True
        If reussiteGeneralLabel.Visible = True Then
            champsGeneralPanel.Visible = True
        Else
            champsGeneralPanel.Visible = False
        End If


        textPanel.Visible = True
        j = 0


        If connexionForm.acces = False Then
            Me.AideButton.Location = New Point(820, 0)
            Me.AccueilButton.Location = New Point(720, 0)
            Me.ParamButton.Visible = False
        End If
    End Sub
#End Region

    '--------------------------------------------------  DIFFERENTS BOUTONS --------------------------------------------------------
#Region "differents boutons"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Stat_choix.groupe = True Then
            FormStatistiques.Show() 'le groupe a l'option année seulemnt donc on revient a la page des stat 
            Me.Close()
        Else
            Stat_choix.Show() ' les autre stat ont deux options donc on revient vers loption stat par année ou intervalle 
            Me.Close()
        End If
    End Sub   'BOUTON DE RETOUR VERS LE CHOIX ANNEE OU INTERVAL 

    Private Sub AccueilButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccueilButton.Click

        AccueilForm.Show()
        Me.Close()
    End Sub 'BOUTON RETOUR VERS L'ACCEUIL

    Private Sub ParamButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamButton.Click

        Parametrage.Show()
        Me.Close()
    End Sub

    Private Sub DeconnexionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeconnexionButton.Click
        deconnexionPanel.Visible = True

    End Sub

    Private Sub AideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideButton.Click
        AideForm.Show()
        Me.Close()
    End Sub

    Private Sub OuiButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuiButton.Click
        Me.Close()
        connexionForm.Show()

    End Sub ' oui a la deconnexion

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        deconnexionPanel.Visible = False

    End Sub

#End Region

    '===================================================[REUSSITE GENERALE / ABANDON  ]=========================================================
#Region "REUSSITE GENERAL / ABANDON "
    Private Sub OkGeneralButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkGeneralButton.Click


        Dim er As Boolean = False
        Dim chart1 As New Chart
        chart1 = PieChart
        Dim d As New DataTable
        'Controles ____________________________________________________________________________________________________________________________
        If (((annee1ComboBox.SelectedItem = "Année scolaire 1") Or (annee2ComboBox.SelectedItem = "Année scolaire 2")) And intervalle = True) Then
            ' ces deux champs sont obligatoires donc si ils nont pas ete remplis on affiche un msg derreur 
            MessageBox.Show("Veuillez remplire les champs d'intervalle d'année,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((anneeComboBox.SelectedItem = "Année scolaire ") And intervalle = False) Then
            MessageBox.Show("Veuillez remplire l'année scolaire,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (generalAnetComboBox.SelectedItem = "Année d'étude ") Then
            MessageBox.Show("Veuillez selectionner l'année d'étude,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((((generalAnetComboBox.SelectedIndex = 0) Or (generalAnetComboBox.SelectedIndex = 1)) And ((generalOptionComboBox.SelectedIndex <> 0) And (generalOptionComboBox.SelectedIndex <> 1))) Or ((((generalAnetComboBox.SelectedIndex = 2) Or (generalAnetComboBox.SelectedIndex = 3) Or (generalAnetComboBox.SelectedIndex = 4)) And ((generalOptionComboBox.SelectedIndex <> 0) And (generalOptionComboBox.SelectedIndex <> 2) And (generalOptionComboBox.SelectedIndex <> 3))))) Then
            MessageBox.Show("l'option que vous venez d'inserer n'est pas compatible avec l'année d'etude", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((intervalle = True) And (annee1ComboBox.SelectedIndex < annee2ComboBox.SelectedIndex)) Then
            MessageBox.Show("l'année scolaire 1 doit etre inferieure ou egale a l'année scolaire 2", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            'aucune erreur de saisie alors on execute____________________________________________________________________________________________
        ElseIf ((intervalle = True) And (annee1ComboBox.SelectedIndex <> annee2ComboBox.SelectedIndex)) Then

            Dim tab(,) As Double

            If (Stat_choix.abondons = True) Then ' on verifie si le choix voulu est taux abondon 
                tab = stt.Abondons(d, generalOptionComboBox.SelectedItem, annee1ComboBox.SelectedItem, annee2ComboBox.SelectedItem, generalAnetComboBox.SelectedItem, er) 'traitement
                If er Then 'on verifie si y a eu une erreur 
                    MessageBox.Show("Une ou plusieurs des années scolaires selectionnées ne figurent pas dans notre base de données ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False

                    TitleLabel.Visible = False
                    LigneShape.Visible = False
                    grosRectangle.Visible = False

                    PieChart.Visible = False
                    intervalleChart.Visible = False

                    iconPicture.Visible = True
                    textPanel.Visible = True



                End If


                grosRectangle.Visible = True
                LigneShape.Visible = True

                iconPicture.Visible = False
                textPanel.Visible = False

                intervalleChart.Visible = True
                PieChart.Visible = False
                Stat_abondons_intervalle(d, tab)


            ElseIf (Stat_choix.generale = True) Then ' on verifie si le choix voulu est taux reussite generale 
                tab = stt.ReussiteParNiveau(d, generalOptionComboBox.SelectedItem, annee1ComboBox.SelectedItem, annee2ComboBox.SelectedItem, generalAnetComboBox.SelectedItem, er) 'traitement
                If er Then 'on verifie si y a eu une erreur 
                    MessageBox.Show("Une ou plusieurs des années scolaire selectionnées ne figurent pas dans notre base de données ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False

                    TitleLabel.Visible = False
                    LigneShape.Visible = False
                    grosRectangle.Visible = False

                    PieChart.Visible = False
                    intervalleChart.Visible = False

                    iconPicture.Visible = True
                    textPanel.Visible = True
                End If

                grosRectangle.Visible = True
                LigneShape.Visible = True

                iconPicture.Visible = False
                textPanel.Visible = False

                intervalleChart.Visible = True
                PieChart.Visible = False
                Stat_niveau_intervalle(d, tab) 'module d'affichage du contenue de tab sous forme d'histogrm

            End If

        Else

            Dim taux As Double 'contiendra le pourcentage des etudiant ayant réussit leur année
            Dim s As String = ""
            If (annee1ComboBox.SelectedIndex = annee2ComboBox.SelectedIndex And intervalle = True) Then
                s = annee1ComboBox.SelectedItem
                anneeComboBox.SelectedItem = s
            Else
                s = anneeComboBox.SelectedItem
            End If
            'ABANDON 
            If (Stat_choix.abondons = True) Then ' on verifie si le choix voulu est taux abondon 
                Dim tab(,) As Double

                tab = stt.Abondons(d, generalOptionComboBox.SelectedItem, s, generalAnetComboBox.SelectedItem, er) 'traitement
                If er Then 'on verifie si y a eu une erreur 
                    MessageBox.Show("années scolaire selectionnée ne figure pas dans notre base de données ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False
                    TitleLabel.Visible = False
                    grosRectangle.Visible = False
                    LigneShape.Visible = False

                    iconPicture.Visible = True
                    textPanel.Visible = True

                    intervalleChart.Visible = False
                    PieChart.Visible = False

                Else
                    grosRectangle.Visible = True
                    LigneShape.Visible = True

                    iconPicture.Visible = False
                    textPanel.Visible = False

                    intervalleChart.Visible = True
                    PieChart.Visible = False

                    Stat_abondons_annee(d, tab) 'module d'affichage du contenue de tab sous forme d'histogrm
                End If
                'RES GENERALE
            ElseIf (Stat_choix.generale = True) Then ' on verifie si le choix voulu est taux reussite generale 
                taux = stt.ReussiteParNiveau(d, generalOptionComboBox.SelectedItem, s, generalAnetComboBox.SelectedItem, er) 'traitement 
                If er Then 'on verifie si y a eu une erreur 
                    MessageBox.Show("années scolaire selectionnée ne figure pas dans notre base de données ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False
                    TitleLabel.Visible = False
                    iconPicture.Visible = True
                    textPanel.Visible = True

                    intervalleChart.Visible = False
                    PieChart.Visible = False

                    grosRectangle.Visible = False
                    LigneShape.Visible = False
                Else
                    iconPicture.Visible = False
                    textPanel.Visible = False

                    intervalleChart.Visible = False
                    PieChart.Visible = True

                    grosRectangle.Visible = True
                    LigneShape.Visible = True


                    Stat_niveau_annee(d, taux) 'affichage du taux en digramme circulaire 
                End If
            End If


        End If


    End Sub 'comme reussite genral et abondon ont les meme champs alors ce bouton sera pour les deux 

    '------------------AFFICHAGE-------------------------'
    Private Sub Stat_niveau_intervalle(ByRef dt As DataTable, ByRef tableau(,) As Double)
        Dim l As Integer

        l = tableau.GetLength(1) - 1

        'Il y a un intervalleChart sur la form
        intervalleChart.Series.Clear()

        'Instanciation series 
        Dim series1 As New Series("Reussite")
        Dim series2 As New Series("Echec")

        'remplissage du graphe avec les valeurs du tableau
        Dim i As Integer = 0

        intervalleChart.Series.Add(series1)
        intervalleChart.Series.Add(series2)

        'couleurs
        intervalleChart.Series("Reussite").Color = Color.FromArgb(195, 95, 158, 160)
        intervalleChart.Series("Echec").Color = Color.FromArgb(241, 188, 48)
        Try
            'remplissage du graphe avec les valeurs du tableau
            For i = 0 To l Step 1
                intervalleChart.Series("Reussite").Points.AddXY(CInt(tableau(0, i)), tableau(1, i))
                intervalleChart.Series("Echec").Points.AddXY(CInt(tableau(0, i)), 100 - tableau(1, i))
            Next
        Catch ex As Exception


        End Try
        'Format et proprietes de la legende
        '   PieChart.Series(0).LegendText = "#VALX"
        intervalleChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        intervalleChart.Legends(0).BorderWidth = 2
        intervalleChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        intervalleChart.Legends(0).Docking = Docking.Left

        'Ajouter le maximum des valeurs de l'axe Y
        intervalleChart.ChartAreas(0).AxisY.Maximum = 100

        'Format des dataLabels
        intervalleChart.Series(0).Label = "#VALY %"
        intervalleChart.Series(1).Label = "#VALY %"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(680, 634)
        DataGridView1.Size = New Point(420, 150)

        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If generalAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If
        If generalOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de réussite par niveau " & generalAnetComboBox.Text & suffix & " année " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
        Else
            TitleLabel.Text = "Taux de réussite par niveau " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(635, 180)

        'Visibilite
        intervalleChart.Visible = True
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub
    Private Sub Stat_niveau_annee(ByRef dt As DataTable, ByVal tab As Double)
        'Il y a un PieChart sur la form
        PieChart.ChartAreas.Clear()
        PieChart.Series.Clear()

        ' Creer Chart Area
        Dim chartArea1 As New ChartArea()
        Dim chartArea2 As New ChartArea()

        ' Ajouter Chart Area au PieChart
        PieChart.ChartAreas.Add(chartArea1)
        PieChart.ChartAreas.Add(chartArea2)

        'Instanciation series 
        Dim series1 As New Series("Details")

        ' Ajout de data points a la serie
        series1.Points.AddXY("Admis", (dt(0)(1)))
        series1.Points.AddXY("Rachetés", (dt(0)(2)))
        series1.Points.AddXY("Redoublons", (dt(0)(3)))
        series1.Points.AddXY("Exclus", (dt(0)(4)))
        series1.Points.AddXY("Abondons", (dt(0)(5)))
        series1.Points.AddXY("Maladie", (dt(0)(6)))

        ' Ajout de la series au chart
        series1.ChartArea = chartArea1.Name
        PieChart.Series.Add(series1)

        'Couleurs
        series1.Points(0).Color = Color.FromArgb(195, 95, 158, 160)
        series1.Points(1).Color = Color.FromArgb(130, 95, 158, 160)
        series1.Points(2).Color = Color.FromArgb(150, 241, 188, 48)
        series1.Points(3).Color = Color.FromArgb(255, 221, 175)


        'Seconde series
        Dim series2 As New Series("Reussite/Echec")

        series2.Points.AddXY("Reussite", dt(0)(1) + dt(0)(2))
        series2.Points.AddXY("Echec", dt(0)(3) + dt(0)(4) + dt(0)(5) + dt(0)(6))

        series2.ChartArea = chartArea2.Name

        PieChart.Series.Add(series2)

        'Couleurs 
        series2.Points(0).Color = Color.FromArgb(95, 158, 160)
        series2.Points(1).Color = Color.FromArgb(241, 188, 48)


        'Les mettre en 3D
        PieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        PieChart.ChartAreas("ChartArea2").Area3DStyle.Enable3D = True

        'Utiliser un Graphique en camembert
        PieChart.Series(0).ChartType = SeriesChartType.Pie
        PieChart.Series(1).ChartType = SeriesChartType.Pie

        'Couleurs d'arrière-plan en transparent
        PieChart.ChartAreas(1).BackColor = Color.Transparent
        PieChart.ChartAreas(0).BackColor = Color.Transparent
        PieChart.ChartAreas(1).BackSecondaryColor = Color.Transparent
        PieChart.ChartAreas(0).BackSecondaryColor = Color.Transparent

        'Epaisseur des disques
        PieChart.ChartAreas(0).Area3DStyle.PointDepth = 40
        PieChart.ChartAreas(1).Area3DStyle.PointDepth = 30

        'Rectangle qui contient le graphique dans un chart area
        'Les coordonnées utilisées pour cette propriété (0,0 à 100,100) 
        'sont associées à l'objet ChartArea, et pas au Chart en entier.
        PieChart.ChartAreas(0).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(0).InnerPlotPosition.Height = 100
        PieChart.ChartAreas(0).InnerPlotPosition.Width = 100

        'Position du ChartArea dans le Chart
        PieChart.ChartAreas(0).Position.Auto = False

        'hauteur  et largeur relative du ChartArea
        PieChart.ChartAreas(0).Position.Height = 100 '70
        PieChart.ChartAreas(0).Position.Width = 100 '50
        'Position du ChartAreas1 dans le Chart
        'Les coordonnées relatives utilisées pour cette propriété (0,0 à 100,100%) par rapport au graphique en entier.
        PieChart.ChartAreas(0).Position.X = 0
        PieChart.ChartAreas(0).Position.Y = 0

        '****Second ChartArea
        ' 'Rectangle qui contient le graphique dans un chart area
        'idem le premier ChartArea
        PieChart.ChartAreas(1).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(1).InnerPlotPosition.Height = 75
        PieChart.ChartAreas(1).InnerPlotPosition.Width = 69

        'Hauteur et largeur du ChartArea (celui-ci est plus petit)
        PieChart.ChartAreas(1).Position.Auto = False
        PieChart.ChartAreas(1).Position.Height = 40 '30
        PieChart.ChartAreas(1).Position.Width = 40 '30
        'Position du Chart Area
        PieChart.ChartAreas(1).Position.X = 36
        PieChart.ChartAreas(1).Position.Y = 33


        'Format et proprietes de la legende
        PieChart.Series(0).LegendText = "#VALX"
        PieChart.Series(1).LegendText = "#VALX"
        PieChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        PieChart.Legends(0).BorderWidth = 2
        PieChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        PieChart.Legends(0).Docking = Docking.Left


        'Format des dataLabels
        PieChart.Series(0).Label = "#VALX" + "\n" + "#PERCENT"
        PieChart.Series(1).Label = "#VALX" + "\n" + "#PERCENT"
        'PieChart.Series(1).Label

        ' labels style , par défaut label sur l'anneau
        PieChart.Series(0)("PieLabelStyle") = "Outside"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(540, 634)
        DataGridView1.Size = New Point(799, 95)


        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If generalAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If
        If generalOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de réussite par niveau " & generalAnetComboBox.Text & suffix & " année " & anneeComboBox.Text
        Else
            TitleLabel.Text = "Taux de réussite par niveau " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & anneeComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(635, 180)

        'Visibilite
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True


    End Sub
    Private Sub Stat_abondons_annee(ByRef dt As DataTable, ByVal tableau(,) As Double)
        Dim l As Integer

        l = tableau.GetLength(1) - 1

        'Il y a un intervalleChart sur la form
        intervalleChart.Series.Clear()

        'Instanciation series 
        Dim series1 As New Series("Abondons")

        'remplissage du graphe avec les valeurs du tableau
        Dim i As Integer = 0

        intervalleChart.Series.Add(series1)

        'couleurs
        intervalleChart.Series("Abondons").Color = Color.FromArgb(195, 95, 158, 160)
        Try
            'remplissage du graphe avec les valeurs du tableau

            intervalleChart.Series("Abondons").Points.AddXY(CInt(tableau(0, 0)), tableau(1, 0))

        Catch ex As Exception
        End Try
        'Format et proprietes de la legende
        '   PieChart.Series(0).LegendText = "#VALX"
        intervalleChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        intervalleChart.Legends(0).BorderWidth = 2
        intervalleChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        intervalleChart.Legends(0).Docking = Docking.Left

        'Ajouter le maximum des valeurs de l'axe Y
        intervalleChart.ChartAreas(0).AxisY.Maximum = 100

        'Format des dataLabels
        intervalleChart.Series(0).Label = "#VALY %"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(800, 634)
        DataGridView1.Size = New Point(400, 150)


        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If generalAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If
        'Titre de la statistique
        If generalOptionComboBox.SelectedIndex = 0 Then
            If ((intervallePanel.Visible = True) And (annee1ComboBox.Text <> annee2ComboBox.Text)) Then
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
            Else
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & anneeComboBox.Text
            End If
        Else
            If ((intervallePanel.Visible = True) And (annee1ComboBox.Text <> annee2ComboBox.Text)) Then
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
            Else
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & anneeComboBox.Text
            End If

        End If

        'Location du titre 
        TitleLabel.Location = New Point(750, 180)

        'Visibilite
        intervalleChart.Visible = True
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True
    End Sub
    Private Sub Stat_abondons_intervalle(ByRef dt As DataTable, ByVal tableau(,) As Double)

        Dim l As Integer

        l = tableau.GetLength(1) - 1

        'Il y a un intervalleChart sur la form
        intervalleChart.Series.Clear()

        'Instanciation series 
        Dim series1 As New Series("Abondons")

        'remplissage du graphe avec les valeurs du tableau
        Dim i As Integer = 0

        intervalleChart.Series.Add(series1)

        'couleurs
        intervalleChart.Series("Abondons").Color = Color.FromArgb(195, 95, 158, 160)
        Try
            'remplissage du graphe avec les valeurs du tableau
            For i = 0 To l Step 1
                intervalleChart.Series("Abondons").Points.AddXY(CInt(tableau(0, i)), tableau(1, i))
            Next

        Catch ex As Exception
        End Try
        'Format et proprietes de la legende
        '   PieChart.Series(0).LegendText = "#VALX"
        intervalleChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        intervalleChart.Legends(0).BorderWidth = 2
        intervalleChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        intervalleChart.Legends(0).Docking = Docking.Left

        'Ajouter le maximum des valeurs de l'axe Y
        intervalleChart.ChartAreas(0).AxisY.Maximum = 100

        'Format des dataLabels
        intervalleChart.Series(0).Label = "#VALY %"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(800, 634)
        DataGridView1.Size = New Point(400, 150)


        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If generalAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If
        'Titre de la statistique
        If generalOptionComboBox.SelectedIndex = 0 Then
            If ((intervallePanel.Visible = True) And (annee1ComboBox.Text <> annee2ComboBox.Text)) Then
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
            Else
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & anneeComboBox.Text
            End If
        Else
            If ((intervallePanel.Visible = True) And (annee1ComboBox.Text <> annee2ComboBox.Text)) Then
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
            Else
                TitleLabel.Text = "Taux d'abondons " & generalAnetComboBox.Text & suffix & " année " & generalOptionComboBox.Text & " " & anneeComboBox.Text
            End If

        End If

        'Location du titre 
        TitleLabel.Location = New Point(750, 180)

        'Visibilite
        intervalleChart.Visible = True
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub

#End Region


    '================================================== [TAUX DE REUSSITE PAR MODULE]===================
#Region "REUSSITE PAR MODULE "
    Private Sub OkModuleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkModuleButton.Click
        Dim er As Boolean = False ' verifie si lannée scolaire existe 
        Dim d As DataTable ' contient le tableau de details
        Dim err As Boolean = False ' verifie si le module existe pour lannee d'etude voulu 
        'Controles ____________________________________________________________________________________________________________________________
        If (((annee1ComboBox.SelectedItem = "Année scolaire 1") Or (annee2ComboBox.SelectedItem = "Année scolaire 2")) And intervalle = True) Then
            ' ces deux champs sont obligatoires donc si ils nont pas ete remplis on affiche un msg derreur 
            MessageBox.Show("Veuillez remplire les champs d'intervalle d'année,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((annee1ComboBox.SelectedIndex < annee2ComboBox.SelectedIndex)) Then
            MessageBox.Show("l'année scolaire 1 doit etre inferieure ou egale a l'année scolaire 2.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((anneeComboBox.SelectedItem = "Année scolaire ") And intervalle = False) Then
            MessageBox.Show("Veuillez remplire l'année scolaire,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (moduleAnetComboBox.SelectedItem = "Année d'étude ") Then
            MessageBox.Show("Veuillez selectionner l'année d'étude,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'aucune erreur de saisie 
        ElseIf (moduleOptionComboBox.SelectedIndex = 0) Then
            MessageBox.Show("Veuillez selectionner l'option,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((((moduleAnetComboBox.SelectedIndex = 0) Or (moduleAnetComboBox.SelectedIndex = 1)) And ((moduleOptionComboBox.SelectedIndex <> 0) And (moduleOptionComboBox.SelectedIndex <> 1))) Or ((((moduleAnetComboBox.SelectedIndex = 2) Or (moduleAnetComboBox.SelectedIndex = 3) Or (moduleAnetComboBox.SelectedIndex = 4)) And ((moduleOptionComboBox.SelectedIndex <> 0) And (moduleOptionComboBox.SelectedIndex <> 2) And (moduleOptionComboBox.SelectedIndex <> 3))))) Then
            MessageBox.Show("l'option que vous venez d'inserer n'est pas compatible avec l'année d'etude", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf (moduleModuleComboBox.SelectedIndex = k) Then

            MessageBox.Show("Veuillez selectionner le Module,s'il vous plait.", "champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            If ((intervalle = True) And (annee1ComboBox.SelectedIndex <> annee2ComboBox.SelectedIndex)) Then
                Dim tab(,) As Double
                tab = stt.ReussiteParModule(d, moduleModuleComboBox.SelectedItem("Intitule").ToString, moduleOptionComboBox.SelectedItem, moduleAnetComboBox.SelectedItem, annee1ComboBox.SelectedItem, annee2ComboBox.SelectedItem, er, err)
                If err = True Then
                    MessageBox.Show("Le module séléctionné ne correspond pas a l'année d'étude sélectionnée et/ou a l'option", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False

                    TitleLabel.Visible = False
                    grosRectangle.Visible = False
                    LigneShape.Visible = False

                    textPanel.Visible = True
                    iconPicture.Visible = True

                    intervalleChart.Visible = False
                    PieChart.Visible = False

                Else
                    If er = True Then
                        MessageBox.Show("Une ou plusieurs années scolaires selectionnées ne figurent pas dans notre base de donnée", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DataGridView1.Visible = False
                        TitleLabel.Visible = False
                        grosRectangle.Visible = False
                        LigneShape.Visible = False

                        textPanel.Visible = True
                        iconPicture.Visible = True

                        intervalleChart.Visible = False
                        PieChart.Visible = False
                    End If
                    TitleLabel.Visible = True
                    grosRectangle.Visible = True
                    LigneShape.Visible = True


                    iconPicture.Visible = False
                    textPanel.Visible = False

                    intervalleChart.Visible = True
                    PieChart.Visible = False

                    Stat_Module_intervalle(d, tab)

                End If

            Else 'année
                Dim s As String = ""
                If intervalle = True Then
                    s = annee1ComboBox.SelectedItem
                    anneeComboBox.SelectedItem = s
                Else
                    s = anneeComboBox.SelectedItem
                End If
                Dim taux As Double
                taux = stt.ReussiteParModule(d, moduleModuleComboBox.SelectedItem("Intitule").ToString, moduleOptionComboBox.SelectedItem, moduleAnetComboBox.SelectedItem, s, er, err)
                If err = True Then
                    MessageBox.Show("Le module séléctionné ne correspond pas a l'année d'étude sélectionnée et/ou a l'option", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DataGridView1.Visible = False
                    TitleLabel.Visible = False
                    grosRectangle.Visible = False
                    LigneShape.Visible = False

                    textPanel.Visible = True
                    iconPicture.Visible = True

                    intervalleChart.Visible = False
                    PieChart.Visible = False

                Else
                    If er = True Then
                        MessageBox.Show("l'année scolaire selectionnée ne figure pas dans notre base de donnée", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DataGridView1.Visible = False
                        LigneShape.Visible = False
                        grosRectangle.Visible = False
                        TitleLabel.Visible = False

                        iconPicture.Visible = True
                        textPanel.Visible = True

                        intervalleChart.Visible = False
                        PieChart.Visible = False

                    Else
                        LigneShape.Visible = True
                        grosRectangle.Visible = True

                        iconPicture.Visible = False
                        textPanel.Visible = False

                        TitleLabel.Visible = True

                        intervalleChart.Visible = False
                        PieChart.Visible = True
                        Stat_Module_annee(d, taux)
                    End If

                End If
            End If

        End If




    End Sub

    '------------------AFFICHAGE-------------------------'
    Private Sub Stat_Module_intervalle(ByRef dt As DataTable, ByRef tableau(,) As Double)
        Dim l As Integer

        l = tableau.GetLength(1) - 1

        'Il y a un intervalleChart sur la form
        intervalleChart.Series.Clear()

        'Instanciation series 
        Dim series1 As New Series("Reussite")
        Dim series2 As New Series("Echec")

        'remplissage du graphe avec les valeurs du tableau
        Dim i As Integer = 0

        intervalleChart.Series.Add(series1)
        intervalleChart.Series.Add(series2)

        'couleurs
        intervalleChart.Series("Reussite").Color = Color.FromArgb(195, 95, 158, 160)
        intervalleChart.Series("Echec").Color = Color.FromArgb(241, 188, 48)
        Try
            'remplissage du graphe avec les valeurs du tableau
            For i = 0 To l Step 1
                intervalleChart.Series("Reussite").Points.AddXY(CInt(tableau(0, i)), tableau(1, i))
                intervalleChart.Series("Echec").Points.AddXY(CInt(tableau(0, i)), 100 - tableau(1, i))
            Next
        Catch ex As Exception


        End Try
        'Format et proprietes de la legende
        '   PieChart.Series(0).LegendText = "#VALX"
        intervalleChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        intervalleChart.Legends(0).BorderWidth = 2
        intervalleChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        intervalleChart.Legends(0).Docking = Docking.Left

        'Ajouter le maximum des valeurs de l'axe Y
        intervalleChart.ChartAreas(0).AxisY.Maximum = 100

        'Format des dataLabels
        intervalleChart.Series(0).Label = "#VALY %"
        intervalleChart.Series(1).Label = "#VALY %"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 130
        DataGridView1.Columns(1).Width = 130
        DataGridView1.Columns(2).Width = 130
        DataGridView1.Columns(3).Width = 130
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(650, 634)
        DataGridView1.Size = New Point(520, 150)

        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If moduleAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If

        'Titre de la statistique
        If moduleOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de réussite " & moduleModuleComboBox.Text & " " & moduleAnetComboBox.Text & suffix & " année " & annee1ComboBox.Text & "/" & annee2ComboBox.Text
        Else
            TitleLabel.Text = "Taux de réussite " & moduleModuleComboBox.Text & " " & moduleAnetComboBox.Text & suffix & " année " & moduleOptionComboBox.Text & " " & annee1ComboBox.Text & "/" & annee2ComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(590, 180)

        'Visibilite
        intervalleChart.Visible = True
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True


    End Sub
    Private Sub Stat_Module_annee(ByRef dt As DataTable, ByVal tableau As Double)
        'Il y a un PieChart sur la form
        PieChart.ChartAreas.Clear()
        PieChart.Series.Clear()

        ' Creer Chart Area
        Dim chartArea1 As New ChartArea()
        Dim chartArea2 As New ChartArea()

        ' Ajouter Chart Area au PieChart
        PieChart.ChartAreas.Add(chartArea1)
        PieChart.ChartAreas.Add(chartArea2)

        'Instanciation series 
        Dim series1 As New Series("Details")

        ' Ajout de data points a la serie
        series1.Points.AddXY("Reussite", (dt(0)(1)))
        series1.Points.AddXY("Echec", (dt(0)(0)) - (dt(0)(1)))

        ' Ajout de la series au chart
        series1.ChartArea = chartArea1.Name
        PieChart.Series.Add(series1)

        'Couleurs
        series1.Points(0).Color = Color.FromArgb(195, 95, 158, 160)
        series1.Points(1).Color = Color.FromArgb(241, 188, 48)

        'Les mettre en 3D
        PieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Utiliser un Graphique en camembert
        PieChart.Series(0).ChartType = SeriesChartType.Pie

        'Couleurs d'arrière-plan en transparent
        PieChart.ChartAreas(1).BackColor = Color.Transparent

        'Epaisseur des disques
        PieChart.ChartAreas(0).Area3DStyle.PointDepth = 40

        'Rectangle qui contient le graphique dans un chart area
        'Les coordonnées utilisées pour cette propriété (0,0 à 100,100) 
        'sont associées à l'objet ChartArea, et pas au Chart en entier.
        PieChart.ChartAreas(0).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(0).InnerPlotPosition.Height = 100
        PieChart.ChartAreas(0).InnerPlotPosition.Width = 100

        'Position du ChartArea dans le Chart
        PieChart.ChartAreas(0).Position.Auto = False

        'hauteur  et largeur relative du ChartArea
        PieChart.ChartAreas(0).Position.Height = 100 '70
        PieChart.ChartAreas(0).Position.Width = 100 '50
        'Position du ChartAreas1 dans le Chart
        'Les coordonnées relatives utilisées pour cette propriété (0,0 à 100,100%) par rapport au graphique en entier.
        PieChart.ChartAreas(0).Position.X = 0
        PieChart.ChartAreas(0).Position.Y = 0

        'Format et proprietes de la legende
        PieChart.Series(0).LegendText = "#VALX"
        PieChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        PieChart.Legends(0).BorderWidth = 2
        PieChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid

        'Format des dataLabels
        PieChart.Series(0).Label = "#VALX" + "\n" + "#PERCENT"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100

        DataGridView1.Visible = True

        DataGridView1.Location = New Point(700, 634)
        DataGridView1.Size = New Point(450, 175)

        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If moduleAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If

        'Titre de la statistique
        If moduleOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de réussite " & moduleModuleComboBox.Text & " " & moduleAnetComboBox.Text & suffix & " année " & anneeComboBox.Text
        Else
            TitleLabel.Text = "Taux de réussite " & moduleModuleComboBox.Text & " " & moduleAnetComboBox.Text & suffix & " année " & moduleOptionComboBox.Text & " " & anneeComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(630, 180)

        'Visibilite
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub

#End Region


    '===================================================[TAUX DE REUSSITE PAR GROUPE=============================================
#Region " REUSSITE PAR GROUPE"
    Private Sub OkGroupeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkGroupeButton.Click


        Dim er As Boolean = False
        Dim d As New DataTable
        'Controles ____________________________________________________________________________________________________________________________
        If (((annee1ComboBox.SelectedItem = "Année scolaire 1") Or (annee2ComboBox.SelectedItem = "Année scolaire 2")) And intervalle = True) Then
            ' ces deux champs sont obligatoires donc si ils nont pas ete remplis on affiche un msg derreur 
            MessageBox.Show("Veuillez remplire les champs d'intervalle d'année,s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((anneeComboBox.SelectedItem = "Année scolaire ") And intervalle = False) Then
            MessageBox.Show("Veuillez remplire le année scolaire,s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (groupeAnetComboBox.SelectedItem = "Année d'étude ") Then
            MessageBox.Show("Veuillez selectionner l'année d'étude,s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((((groupeAnetComboBox.SelectedIndex = 0) Or (groupeAnetComboBox.SelectedIndex = 1)) And ((groupeOptionComboBox.SelectedIndex <> 0) And (groupeOptionComboBox.SelectedIndex <> 1))) Or ((((groupeAnetComboBox.SelectedIndex = 2) Or (groupeAnetComboBox.SelectedIndex = 3) Or (groupeAnetComboBox.SelectedIndex = 4)) And ((groupeOptionComboBox.SelectedIndex <> 0) And (groupeOptionComboBox.SelectedIndex <> 2) And (groupeOptionComboBox.SelectedIndex <> 3))))) Then
            MessageBox.Show("l'option que vous venez d'inserer n'est pas compatible avec l'année d'etude", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (groupeGroupeComboBox.SelectedIndex = 0) Then
            MessageBox.Show("Veuiller selectionner le groupe voulu,s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf (groupeOptionComboBox.SelectedIndex = 0) Then
            MessageBox.Show("Veuiller selectionner l'option voulue,s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'aucune erreur de saisie alors on execute____________________________________________________________________________________________

        Else
            Dim taux As Double 'contiendra le pourcentage des etudiant ayant réussit leur année
            taux = stt.ReussiteParGroupe(d, groupeOptionComboBox.SelectedItem, anneeComboBox.SelectedItem, groupeGroupeComboBox.SelectedItem, groupeAnetComboBox.SelectedItem, er) 'traitement 

            If er Then 'il se peut que l'année entrée n'existe pas dans la bdd alors on aura une erreur dans le calcul du taux ( division par 0)
                MessageBox.Show("l'année scolaire ou le groupe  selectionné ne figure pas dans notre base de donnée ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TitleLabel.Visible = False
                LigneShape.Visible = False
                grosRectangle.Visible = False

                DataGridView1.Visible = False

                intervalleChart.Visible = False
                PieChart.Visible = False


                textPanel.Visible = True
                iconPicture.Visible = True

            Else
                TitleLabel.Visible = True
                LigneShape.Visible = True

                intervalleChart.Visible = False
                PieChart.Visible = True

                iconPicture.Visible = False
                textPanel.Visible = False

                Stat_groupe_annee(d, taux) 'affichage du taux en digramme circulaire 


            End If

        End If
    End Sub
    '------------------AFFICHAGE-------------------------'
    Private Sub Stat_groupe_annee(ByRef dt As DataTable, ByVal tableau As Double)
        'Il y a un PieChart sur la form
        PieChart.ChartAreas.Clear()
        PieChart.Series.Clear()

        ' Creer Chart Area
        Dim chartArea1 As New ChartArea()
        Dim chartArea2 As New ChartArea()

        ' Ajouter Chart Area au PieChart
        PieChart.ChartAreas.Add(chartArea1)
        PieChart.ChartAreas.Add(chartArea2)

        'Instanciation series 
        Dim series1 As New Series("Details")

        ' Ajout de data points a la serie
        series1.Points.AddXY("Admis", (dt(0)(1)))
        series1.Points.AddXY("Rachetés", (dt(0)(2)))
        series1.Points.AddXY("Redoublons", (dt(0)(3)))
        series1.Points.AddXY("Exclus", (dt(0)(4)))
        series1.Points.AddXY("Abondons", (dt(0)(5)))
        series1.Points.AddXY("Maladie", (dt(0)(6)))

        ' Ajout de la series au chart
        series1.ChartArea = chartArea1.Name
        PieChart.Series.Add(series1)

        'Couleurs
        series1.Points(0).Color = Color.FromArgb(195, 95, 158, 160)
        series1.Points(1).Color = Color.FromArgb(130, 95, 158, 160)
        series1.Points(2).Color = Color.FromArgb(150, 241, 188, 48)
        series1.Points(3).Color = Color.FromArgb(255, 221, 175)


        'Seconde series
        Dim series2 As New Series("Reussite/Echec")

        series2.Points.AddXY("Reussite", dt(0)(1) + dt(0)(2))
        series2.Points.AddXY("Echec", dt(0)(3) + dt(0)(4) + dt(0)(5) + dt(0)(6))

        series2.ChartArea = chartArea2.Name

        PieChart.Series.Add(series2)

        'Couleurs 
        series2.Points(0).Color = Color.FromArgb(95, 158, 160)
        series2.Points(1).Color = Color.FromArgb(241, 188, 48)


        'Les mettre en 3D
        PieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        PieChart.ChartAreas("ChartArea2").Area3DStyle.Enable3D = True

        'Utiliser un Graphique en camembert
        PieChart.Series(0).ChartType = SeriesChartType.Pie
        PieChart.Series(1).ChartType = SeriesChartType.Pie

        'Couleurs d'arrière-plan en transparent
        PieChart.ChartAreas(1).BackColor = Color.Transparent
        PieChart.ChartAreas(0).BackColor = Color.Transparent
        PieChart.ChartAreas(1).BackSecondaryColor = Color.Transparent
        PieChart.ChartAreas(0).BackSecondaryColor = Color.Transparent

        'Epaisseur des disques
        PieChart.ChartAreas(0).Area3DStyle.PointDepth = 40
        PieChart.ChartAreas(1).Area3DStyle.PointDepth = 30

        'Rectangle qui contient le graphique dans un chart area
        'Les coordonnées utilisées pour cette propriété (0,0 à 100,100) 
        'sont associées à l'objet ChartArea, et pas au Chart en entier.
        PieChart.ChartAreas(0).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(0).InnerPlotPosition.Height = 100
        PieChart.ChartAreas(0).InnerPlotPosition.Width = 100

        'Position du ChartArea dans le Chart
        PieChart.ChartAreas(0).Position.Auto = False

        'hauteur  et largeur relative du ChartArea
        PieChart.ChartAreas(0).Position.Height = 100 '70
        PieChart.ChartAreas(0).Position.Width = 100 '50
        'Position du ChartAreas1 dans le Chart
        'Les coordonnées relatives utilisées pour cette propriété (0,0 à 100,100%) par rapport au graphique en entier.
        PieChart.ChartAreas(0).Position.X = 0
        PieChart.ChartAreas(0).Position.Y = 0

        '****Second ChartArea
        ' 'Rectangle qui contient le graphique dans un chart area
        'idem le premier ChartArea
        PieChart.ChartAreas(1).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(1).InnerPlotPosition.Height = 75
        PieChart.ChartAreas(1).InnerPlotPosition.Width = 69

        'Hauteur et largeur du ChartArea (celui-ci est plus petit)
        PieChart.ChartAreas(1).Position.Auto = False
        PieChart.ChartAreas(1).Position.Height = 40 '30
        PieChart.ChartAreas(1).Position.Width = 40 '30
        'Position du Chart Area
        PieChart.ChartAreas(1).Position.X = 36
        PieChart.ChartAreas(1).Position.Y = 33


        'Format et proprietes de la legende
        PieChart.Series(0).LegendText = "#VALX"
        PieChart.Series(1).LegendText = "#VALX"
        PieChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        PieChart.Legends(0).BorderWidth = 2
        PieChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        PieChart.Legends(0).Docking = Docking.Left

        'Format des dataLabels
        PieChart.Series(0).Label = "#VALX" + "\n" + "#PERCENT"
        PieChart.Series(1).Label = "#VALX" + "\n" + "#PERCENT"
        'PieChart.Series(1).Label

        ' labels style , par défaut label sur l'anneau
        PieChart.Series(0)("PieLabelStyle") = "Outside"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(540, 634)
        DataGridView1.Size = New Point(799, 95)

        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique
        Dim suffix As String
        If groupeAnetComboBox.Text = "1" Then
            suffix = "ère"
        Else
            suffix = "ème"
        End If
        If groupeOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de réussite G" & groupeGroupeComboBox.Text & " " & groupeAnetComboBox.Text & suffix & " année " & anneeComboBox.Text
        Else
            TitleLabel.Text = "Taux de réussite G" & groupeGroupeComboBox.Text & " " & groupeAnetComboBox.Text & suffix & " année " & groupeOptionComboBox.Text & " " & anneeComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(635, 180)

        'Visibilite
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub
#End Region


    '===================================================[TAUX DE DIPLOMES]=============================================================
#Region "DIPLOMES"
    Private Sub OkdiplomesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkdiplomesButton.Click
        Dim er As Boolean
        Dim d As New DataTable

        er = False
        'on verifie si les champs on été correctement remplis 
        If (((annee1ComboBox.SelectedItem = "Année scolaire 1") Or (annee2ComboBox.SelectedItem = "Année scolaire 2")) And intervalle = True) Then
            ' ces deux champs sont obligatoires donc si ils nont pas ete remplis on affiche un msg derreur 
            MessageBox.Show("Veuillez remplire les champs d'intervalle d'année,s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((anneeComboBox.SelectedItem = "Année scolaire ") And intervalle = False) Then
            MessageBox.Show("Veuillez remplire le année scolaire,s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((annee1ComboBox.SelectedIndex < annee2ComboBox.SelectedIndex) And intervalle = True) Then
            MessageBox.Show("l'année scolaire 1 doit etre inferieure ou egale a l'année scolaire 2.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'aucune erreur de saisie on commence le traitement 
        Else
            If ((intervalle = True) And (annee1ComboBox.SelectedIndex <> annee2ComboBox.SelectedIndex)) Then
                Dim tab(,) As Double
                tab = stt.Diplomes(diplomesOptionComboBox.SelectedItem, annee1ComboBox.SelectedItem, annee2ComboBox.SelectedItem, er)
                If er = True Then
                    MessageBox.Show("l'année scolaire selectionnée ne figure pas dans notre base de donnée ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    iconPicture.Visible = True
                    textPanel.Visible = True

                    DataGridView1.Visible = False

                    grosRectangle.Visible = False
                    LigneShape.Visible = False
                    TitleLabel.Visible = False

                    intervalleChart.Visible = False
                    PieChart.Visible = False
                End If
                grosRectangle.Visible = True
                LigneShape.Visible = True
                TitleLabel.Visible = True

                iconPicture.Visible = False
                textPanel.Visible = False

                intervalleChart.Visible = True
                PieChart.Visible = False
                Stat_diplomes_intervalle(d, tab)



            Else ' année=true
                Dim s As String = ""
                If intervalle = True Then
                    s = annee1ComboBox.SelectedItem
                    anneeComboBox.SelectedItem = s
                Else
                    s = anneeComboBox.SelectedItem
                End If


                Dim taux As Double = stt.Diplomes(d, diplomesOptionComboBox.SelectedItem, s, er)
                If er = True Then
                    MessageBox.Show("l'année d'étude selectionnée ne figure pas dans notre base de donnée ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    iconPicture.Visible = True
                    textPanel.Visible = True

                    DataGridView1.Visible = False

                    grosRectangle.Visible = False
                    LigneShape.Visible = False
                    TitleLabel.Visible = False

                    intervalleChart.Visible = False
                    PieChart.Visible = False

                Else

                    iconPicture.Visible = False
                    textPanel.Visible = False

                    grosRectangle.Visible = True
                    LigneShape.Visible = True

                    intervalleChart.Visible = False
                    PieChart.Visible = True

                    Stat_diplomes_annee(d, taux)
                End If

            End If

        End If

    End Sub
    '------------------AFFICHAGE-------------------------'
    Private Sub Stat_diplomes_intervalle(ByRef dt As DataTable, ByRef tableau(,) As Double)
        Dim l As Integer

        l = tableau.GetLength(1) - 1

        'Il y a un intervalleChart sur la form
        intervalleChart.Series.Clear()

        'Instanciation series 
        Dim series1 As New Series("Hommes")
        Dim series2 As New Series("Femmes")

        'remplissage du graphe avec les valeurs du tableau
        Dim i As Integer = 0

        intervalleChart.Series.Add(series1)
        intervalleChart.Series.Add(series2)

        'couleurs
        intervalleChart.Series("Hommes").Color = Color.FromArgb(195, 95, 158, 160)
        intervalleChart.Series("Femmes").Color = Color.FromArgb(241, 188, 48)
        Try
            'remplissage du graphe avec les valeurs du tableau
            For i = 0 To l Step 1
                intervalleChart.Series("Hommes").Points.AddXY(CInt(tableau(0, i)), tableau(1, i))
                intervalleChart.Series("Femmes").Points.AddXY(CInt(tableau(0, i)), 100 - tableau(1, i))
            Next
        Catch ex As Exception
            MsgBox("Les deux années scolaires sont identiques.")
        End Try
        'Format et proprietes de la legende
        '   PieChart.Series(0).LegendText = "#VALX"
        intervalleChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        intervalleChart.Legends(0).BorderWidth = 2
        intervalleChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        intervalleChart.Legends(0).Docking = Docking.Left

        'Ajouter le maximum des valeurs de l'axe Y
        intervalleChart.ChartAreas(0).AxisY.Maximum = 100

        'Format des dataLabels
        intervalleChart.Series(0).Label = "#VALY %"
        intervalleChart.Series(1).Label = "#VALY %"

        'Tableau de details
        ' DataGridView1.DataSource = dt

        ' DataGridView1.Columns(0).Width = 130
        ' DataGridView1.Columns(1).Width = 130
        ' DataGridView1.Columns(2).Width = 130
        ' DataGridView1.Columns(3).Width = 130
        ' DataGridView1.Visible = True

        ' DataGridView1.Location = New Point(650, 634)
        ' DataGridView1.Size = New Point(520, 150)

        'Titre de la statistique
        If generalOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de diplomés " & annee1ComboBox.Text & "-" & annee2ComboBox.Text
        Else
            TitleLabel.Text = "Taux de diplomés " & annee1ComboBox.Text & "-" & annee2ComboBox.Text & " " & diplomesOptionComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(680, 176)

        'Visibilite
        intervalleChart.Visible = True
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub
    Private Sub Stat_diplomes_annee(ByRef dt As DataTable, ByVal tableau As Double)

        'Il y a un PieChart sur la form
        PieChart.ChartAreas.Clear()
        PieChart.Series.Clear()

        ' Creer Chart Area
        Dim chartArea1 As New ChartArea()
        Dim chartArea2 As New ChartArea()

        ' Ajouter Chart Area au PieChart
        PieChart.ChartAreas.Add(chartArea1)
        PieChart.ChartAreas.Add(chartArea2)

        'Instanciation series 
        Dim series1 As New Series("Details")

        ' Ajout de data points a la serie
        series1.Points.AddXY("Femmes", (dt(0)(2)))
        series1.Points.AddXY("Homme", (dt(0)(3)))

        ' Ajout de la series au chart
        series1.ChartArea = chartArea1.Name
        PieChart.Series.Add(series1)

        'Couleurs
        series1.Points(0).Color = Color.FromArgb(195, 95, 158, 160)
        series1.Points(1).Color = Color.FromArgb(241, 188, 48)

        'Les mettre en 3D
        PieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Utiliser un Graphique en camembert
        PieChart.Series(0).ChartType = SeriesChartType.Pie

        'Couleurs d'arrière-plan en transparent
        PieChart.ChartAreas(1).BackColor = Color.Transparent

        'Epaisseur des disques
        PieChart.ChartAreas(0).Area3DStyle.PointDepth = 40

        'Rectangle qui contient le graphique dans un chart area
        'Les coordonnées utilisées pour cette propriété (0,0 à 100,100) 
        'sont associées à l'objet ChartArea, et pas au Chart en entier.
        PieChart.ChartAreas(0).InnerPlotPosition.Auto = False
        PieChart.ChartAreas(0).InnerPlotPosition.Height = 100
        PieChart.ChartAreas(0).InnerPlotPosition.Width = 100

        'Position du ChartArea dans le Chart
        PieChart.ChartAreas(0).Position.Auto = False

        'hauteur  et largeur relative du ChartArea
        PieChart.ChartAreas(0).Position.Height = 100 '70
        PieChart.ChartAreas(0).Position.Width = 100 '50
        'Position du ChartAreas1 dans le Chart
        'Les coordonnées relatives utilisées pour cette propriété (0,0 à 100,100%) par rapport au graphique en entier.
        PieChart.ChartAreas(0).Position.X = 0
        PieChart.ChartAreas(0).Position.Y = 0


        'Format et proprietes de la legende
        PieChart.Series(0).LegendText = "#VALX"
        PieChart.Legends(0).BorderColor = Color.FromArgb(55, 178, 159)
        PieChart.Legends(0).BorderWidth = 2
        PieChart.Legends(0).BorderDashStyle = ChartDashStyle.Solid

        'Format des dataLabels
        PieChart.Series(0).Label = "#VALX" + "\n" + "#PERCENT"

        'Tableau de details
        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Width = 110
        DataGridView1.Columns(1).Width = 110
        DataGridView1.Columns(2).Width = 110
        DataGridView1.Columns(3).Width = 110
        DataGridView1.ColumnHeadersHeight = 55
        DataGridView1.Visible = True

        DataGridView1.Location = New Point(640, 634)
        DataGridView1.Size = New Point(799, 95)

        DataGridView1.AutoResizeColumnHeadersHeight()

        'Titre de la statistique

        If diplomesOptionComboBox.SelectedIndex = 0 Then
            TitleLabel.Text = "Taux de diplomés par sexe " & anneeComboBox.Text
        Else
            TitleLabel.Text = "Taux de diplomés par sexe " & anneeComboBox.Text & " " & diplomesOptionComboBox.Text
        End If

        'Location du titre 
        TitleLabel.Location = New Point(673, 180)

        'Visibilite
        TitleLabel.Visible = True
        LigneShape.Visible = True
        grosRectangle.Visible = True

    End Sub


#End Region

    Private Sub moduleOptionComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moduleOptionComboBox.SelectedIndexChanged
        If j = 0 Then
            Dim connetionString As String = Nothing
            Dim connection As OleDbConnection
            Dim command As OleDbCommand
            Dim adapter As New OleDbDataAdapter()
            Dim ds As New DataSet()
            Dim i As Integer = 0
            Dim sql As String = Nothing
            connetionString = connexionForm.chcnx
            sql = "select Intitule from MATIERE where AnneeEtude=" & moduleAnetComboBox.SelectedItem & " and [Option]='" & moduleOptionComboBox.SelectedItem & "'"
            connection = New OleDbConnection(connetionString)
            connection.Open()
            command = New OleDbCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ds.Tables(0).Rows.Add("Module")
            moduleModuleComboBox.DataSource = ds.Tables(0)
            moduleModuleComboBox.ValueMember = "Intitule"
            moduleModuleComboBox.DisplayMember = "Intitule"
            moduleModuleComboBox.SelectedIndex = ds.Tables(0).Rows.Count - 1
            k = ds.Tables(0).Rows.Count - 1

        End If

    End Sub


End Class