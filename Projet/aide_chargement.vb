Public Class aide_chargement

    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Parametrage.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        deconnexionPanel.Visible = True

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click
        aide_fichiers.Show()
        Me.Close()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        aide_fichiers.Show()
        Me.Close()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        aide_conseils.Show()
        Me.Close()

    End Sub

    Private Sub RectangleShape11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape11.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        aide_conseils.Show()
        Me.Close()

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        aide_correction.Show()
        Me.Close()

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        aide_correction.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AccueilForm.Show()
        Me.Close()
    End Sub
End Class