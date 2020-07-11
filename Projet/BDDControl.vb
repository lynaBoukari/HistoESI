Imports System.Data.OleDb

Public Class BDDControl

    'Creation et Ouverture de la connexion a la base de donnees

    Private DBCon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDD_PRJT_EQUIPE14.accdb")

    'On prepare la commande 
    Private DBCmd As OleDbCommand


    'On cree un OleDbDataAdapter et un Datatable qui va contenir des données recupérer a partir de la base de donnees 

    Public DBDA As OleDbDataAdapter
    Public DBDT As DataTable


    'Creation d'une liste des parametres 
    Public Params As New List(Of OleDbParameter)

    'Statistique de la requete : pour le traitement et la recuperation des donnees dans un Datatable aprés l'execution de la commande sql 

    Public RecordCount As Integer
    Public Exception As String

    Public Sub ExecQuery(ByVal Query As String)

        'Initialisation de la requete  

        RecordCount = 0
        Exception = ""

        Try
            'L'ouverture de la connexion 
            DBCon.Open()

            'La creation d'une commande base de donnees 
            DBCmd = New OleDbCommand(Query, DBCon)

            'Chargement des parametres vers la command BDD (DBcmd) 
            Params.ForEach(Sub(p) DBCmd.Parameters.Add(p))


            Params.Clear()

            'Execution de la commande et remplir le DataTable 
            DBDT = New DataTable
            DBDA = New OleDbDataAdapter(DBCmd)
            RecordCount = DBDA.Fill(DBDT)


        Catch ex As Exception
            Exception = ex.Message
        End Try

        'Fermeture de la connexion 
        If DBCon.State = ConnectionState.Open Then DBCon.Close()
    End Sub

    'Execution de la requete & Command des parametres  
    Public Sub AddParam(ByVal Name As String, ByVal Value As Object)
        Dim NewParam As New OleDbParameter(Name, Value)
        Params.Add(NewParam)
    End Sub
End Class
