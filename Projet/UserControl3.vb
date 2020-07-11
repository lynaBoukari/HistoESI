Public Class UserControl3
    Dim histor As ClassHistorique = New ClassHistorique
    Private Sub PanelTabl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
      
    End Sub

    Private Sub LabelRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelRes.Click

    End Sub

    Private Sub UserControl3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Historique.PanelReleve.Visible = True
        Historique.Panel3.Visible = True
        Historique.PanelTabl.Visible = False
        Historique.PanelTableau.BringToFront()
        Historique.PanelReleve.Controls.Clear()

        Historique.PanelTableau.Visible = False
        Historique.Label12.Visible = True
        Historique.LabelMoyAnnu.Visible = True
        Historique.PanelReleve.Visible = True
        Historique.Panel3.Visible = True
        Historique.LabelMentionReleve.Visible = True
        Historique.Label14.Visible = True
        Historique.Label15.Visible = True
        Historique.LabelAnnetreleve.Visible = True
        Historique.Label17.Visible = True
        Historique.Labelannescolreleve.Visible = True
        Dim anne As Integer = Integer.Parse(LabelAnneeNum.Text)
        Dim datatable As DataTable = histor.sortieReleve(Historique.LabelMat.Text, anne)
        anne = 0
        histor.releve(datatable, Historique.LabelMat.Text, LabelAnneeNum.Text, LabelAnneSco.Text)




    End Sub

    Private Sub LabelAnneeNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelAnneeNum.Click

    End Sub

    Private Sub ButtonImpression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImpression.Click
        Dim etats As Class_Etats_Sorties = New Class_Etats_Sorties
        etats.ReleveSimple(Historique.LabelMat.Text, LabelAnneeNum.Text, LabelAnneSco.Text)

    End Sub
End Class
