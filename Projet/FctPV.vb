Public Class FctPV
    Function modifierNoteJuin(ByVal note As Double) As String
        If note = 99.99 Then
            Return "Abd"
        ElseIf note = 88.88 Then
            Return "Mld"
        Else
            Return note.ToString()
        End If
    End Function

    Function modifierMentionParcours(ByVal mention As Integer) As String
        If mention = 1 Then
            Return "TB"
        ElseIf mention = 2 Then
            Return "B"
        ElseIf mention = 3 Then
            Return "AB"
        ElseIf mention = 4 Then
            Return "P"
        ElseIf mention = 7 Then
            Return "Abandon"
        ElseIf mention = 8 Then
            Return "Redouble sans passer au rattrapage"
        Else  'la valeur= 0 dont on connait pas la signification ou la valeur=6 et dans ce cas on doit pendre en cosideration la mention du rattrapage
            Return " "
        End If
    End Function

    Function modifierDec(ByVal dec As String) As String
        If dec = "1" Then
            Return "Admis"
        ElseIf dec = "2" Then
            Return "Admis avec rachat"
        ElseIf dec = "3" Then
            Return "Redouble"
        ElseIf dec = "4" Then
            Return "Non Admis"
        Else   ' si la decision est 0 on la laisse vide
            Return " "
        End If
    End Function


    Function creerAnneeScolaire(ByVal ansc As String) As String
        Dim annee2 As Integer = CInt(ansc) + 1
        Dim an2 As String = annee2.ToString()
        Return String.Concat(ansc, String.Concat("/", an2))

    End Function

    Function modifierMentionRattrapage(ByVal mention As Integer) As String
        If mention = 3 Then
            Return "AB"
        ElseIf mention = 4 Then
            Return "P"
        ElseIf mention = 7 Then
            Return "Abandon"
        ElseIf mention = 8 Then
            Return "Redouble"
        Else  'la valeur= 6 dont on connait pas la signification 
            Return " "
        End If
    End Function

End Class
