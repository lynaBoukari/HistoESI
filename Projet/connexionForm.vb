Public Class connexionForm
    Public Const chcnx As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDD_PRJT_EQUIPE14.accdb"
    Public Const chcnxbdder As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDDErreur.accdb"
    Dim mdp As ClassMotDePasse = New ClassMotDePasse
    Public acces As Boolean


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        authAdminPanel.Visible = True
        connexionPanel.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        connexionPanel.Visible = True

        authAdminPanel.Visible = False
        AccueilForm.acceuilPersLabel.Visible = False





    End Sub

    Private Sub PersBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AuthPersonnelPanel.Visible = True
        connexionPanel.Visible = False
        AccueilForm.ButtonParam.Visible = False
        AideForm.ButtonParam.Visible = False
        EtatDeSortie.ButtonParam.Visible = False
        modifierForm.ButtonParam.Visible = False
        RechercheForm.ButtonParam.Visible = False
        FormStatistiques.ButtonParam.Visible = False
        AccueilForm.acceuilAdminLabel.Visible = False





    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AccueilForm.Show()





    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AccueilForm.Show()


    End Sub

    Private Sub prePersBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        connexionPanel.Visible = True
        AuthPersonnelPanel.Visible = False



    End Sub

    Private Sub connexionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles connexionPanel.Paint

    End Sub

    Private Sub authPersPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        connexionPanel.Visible = True
        authAdminPanel.Visible = False
        AuthPersonnelPanel.Visible = False

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim datatable As DataTable = mdp.sortieMdp("admin")
        For Each row As DataRow In datatable.Rows

            If (String.Equals(row("Mdp").ToString, Me.MaskedTextBox2.Text)) Then
                acces = True
                AccueilForm.Show()
                Me.Hide()
            Else
                MsgBox(" Mot de passe incorrect !")
            End If
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        authAdminPanel.Visible = True
        connexionPanel.Visible = False
        AuthPersonnelPanel.Visible = False
        authAdminPanel.Visible = True
       


    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        AuthPersonnelPanel.Visible = True
        connexionPanel.Visible = False
        authAdminPanel.Visible = False
        AuthPersonnelPanel.Visible = True
        Mot_de_passe.Label1.Visible = False
        Mot_de_passe.AnetBox.Visible = False
        Mot_de_passe.Button1.Visible = False
        Mot_de_passe.Button3.Visible = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        connexionPanel.Visible = True
        authAdminPanel.Visible = False
        AuthPersonnelPanel.Visible = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AccueilForm.Show()



    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Details.Button2.Visible = False

        Dim datatable As DataTable = mdp.sortieMdp("personnel")
        For Each row As DataRow In datatable.Rows
            If (String.Equals(row("Mdp").ToString, Me.MaskedTextBox1.Text)) Then
                acces = False
                AccueilForm.Show()
                Me.Hide()
            Else
                MsgBox(" Mot de passe incorrect !")
            End If
        Next
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        connexionPanel.Visible = True
        authAdminPanel.Visible = False
        AuthPersonnelPanel.Visible = False
    End Sub

    Private Sub Label4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox2.MaskInputRejected

    End Sub


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub Button6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        connexionPanel.Visible = True
        authAdminPanel.Visible = False
        AuthPersonnelPanel.Visible = False
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub AuthPersonnelPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AuthPersonnelPanel.Paint

    End Sub

    Private Sub LineShape2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape2.Click, LineShape4.Click, LineShape8.Click, LineShape7.Click, LineShape6.Click, LineShape3.Click

    End Sub

    Private Sub authAdminPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles authAdminPanel.Paint

    End Sub
End Class