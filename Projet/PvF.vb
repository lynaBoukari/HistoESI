Public Class PvF

    Private Sub PvF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMB_ANNEESCOLAIRE.SelectedIndex = 0
        CMB_ANNEEETUDE.SelectedIndex = 0
        CMB_OPTION.SelectedIndex = 0
    End Sub
    Private Sub OkPVButton_Click(sender As System.Object, e As System.EventArgs) Handles OkPVButton.Click
        If (CMB_OPTION.SelectedIndex = -1 Or CMB_OPTION.SelectedItem = "Option" Or CMB_ANNEEETUDE.SelectedIndex = -1 Or CMB_ANNEEETUDE.SelectedItem = "Année d'étude" Or CMB_ANNEESCOLAIRE.SelectedIndex = -1 Or CMB_ANNEESCOLAIRE.SelectedItem = "Année Scolaire") Then
            MessageBox.Show("Veuillez entrer une valeur pour chaque champ.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((CMB_OPTION.SelectedItem = "TRC" And CMB_ANNEEETUDE.SelectedItem = "3") Or (CMB_OPTION.SelectedItem = "TRC" And CMB_ANNEEETUDE.SelectedItem = "4") Or (CMB_OPTION.SelectedItem = "SI" And CMB_ANNEEETUDE.SelectedItem = "1") Or (CMB_OPTION.SelectedItem = "SI" And CMB_ANNEEETUDE.SelectedItem = "2") Or (CMB_OPTION.SelectedItem = "SIQ" And CMB_ANNEEETUDE.SelectedItem = "1") Or (CMB_OPTION.SelectedItem = "SIQ" And CMB_ANNEEETUDE.SelectedItem = "2")) Then
            MessageBox.Show("Les données que vous avez entré sont erronées,veuillez selectionner d'autres .", "Données erronées", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim dataset As DataSet = New DataSet()
            Dim c As ClassPV = New ClassPV(CMB_OPTION.SelectedItem, CMB_ANNEEETUDE.SelectedItem, CMB_ANNEESCOLAIRE.SelectedItem)
            dataset = c.genererPv()
            Rpt = New PV
            Rpt.Database.Tables("SPECIALITE").SetDataSource(dataset.Tables(1))
            Rpt.Database.Tables("ETUDIANT").SetDataSource(dataset.Tables(5))
            Rpt.Database.Tables("PARCOURS").SetDataSource(dataset.Tables(4))
            Rpt.Database.Tables("Note").SetDataSource(dataset.Tables(3))
            Rpt.Database.Tables("RATTRAPAGE").SetDataSource(dataset.Tables(2))
            Rpt.Database.Tables("MOYENNEMATIERE").SetDataSource(dataset.Tables(0))
            pvFv.CrystalReportViewer1.ReportSource = Rpt
            pvFv.CrystalReportViewer1.Refresh()

            pvFv.ShowDialog()
            pvFv.Dispose()



            ' CrystalReportViewer1.ReportSource = Rpt
        End If
    End Sub

#Region "different Buttons"
    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Parametrage.Show()
        Me.Close()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        deconnexionPanel.Visible = True
    End Sub

    Private Sub OuiButton_Click(sender As System.Object, e As System.EventArgs) Handles OuiButton.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        deconnexionPanel.Visible = False

    End Sub
#End Region

    Private Sub RecherchePanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles RecherchePanel.Paint

    End Sub

    Private Sub CMB_OPTION_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CMB_OPTION.SelectedIndexChanged

    End Sub

    Private Sub CMB_ANNEESCOLAIRE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CMB_ANNEESCOLAIRE.SelectedIndexChanged

    End Sub
End Class