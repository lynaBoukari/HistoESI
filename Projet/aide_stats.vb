Public Class aide_stats
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AideForm.Show()
        Me.Close()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False

    End Sub
End Class