Imports System.Data.OleDb

Imports System.Data.DataSet

Public Class ClassMotDePasse

    Public Function sortieMdp(ByVal id As String) As DataTable

        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select * FROM [MotDePasse] WHERE Id= '" & id & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Return ds.Tables(0)

    End Function

    Public Sub ModifierMdp(ByVal id As String, ByVal mdp As String)

        Dim myConnection As OleDbConnection = New OleDbConnection


        Try


            myConnection.ConnectionString = connexionForm.chcnx
            myConnection.Open()


            Dim str As String = "Update MotDePasse SET Mdp=? where Id=?"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)

            cmd.Parameters.AddWithValue("Mdp", mdp)
            cmd.Parameters.AddWithValue("Id", id)

            cmd.ExecuteNonQuery()

            cmd.Dispose()
            myConnection.Close()

            MsgBox(" Modification avec succès ! ", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub
    Sub traitementMdp(ByVal id As String, ByRef ancien As String, ByVal nouveau As String)
        Dim table As DataTable = sortieMdp(id)
        For Each row As DataRow In table.Rows
            If (String.Equals(row("Mdp").ToString, ancien)) Then
                ModifierMdp(id, nouveau)
            Else
                MsgBox("  L'ancien mot de passe est erroné veuillez reéssayer ! ")
            End If

        Next


    End Sub

End Class
