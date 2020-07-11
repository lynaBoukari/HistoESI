Public Class Classement
    Dim c As New Classement_Modules

    Private Sub Classement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        anesBox.SelectedIndex = 0
        optBox.SelectedIndex = 0
        podiumPic.Visible = True
        textPanel.Visible = True
        anesoptLabel.Visible = False

        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If


    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel7.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Panel7.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        connexionForm.Show()

    End Sub

    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click

        Parametrage.Show()
        Me.Close()

    End Sub

    Private Sub OkPromoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkPromoButton.Click
        c.anS = anesoptLabel.Text()
        c.affichageClassement()
        'OkPromoButton.Hide()
        ImpBut.Show()

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        AccueilForm.Show()
        Me.Close()
    End Sub

    Private Sub optBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBox.SelectedIndexChanged

    End Sub

    Private Sub ImpBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpBut.Click
        Impression.ShowDialog()
        Impression.Dispose()
    End Sub

    Private Sub anesoptLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles anesoptLabel.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class