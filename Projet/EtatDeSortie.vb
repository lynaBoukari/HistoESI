Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.DataSet
Public Class EtatDeSortie
    Private Sub Module_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If connexionForm.acces = False Then
            Me.Button4.Location = New Point(820, 0)
            Me.Button5.Location = New Point(720, 0)
            Me.ButtonParam.Visible = False
        End If
        '====Remplissage des combobox=====
        '  LabelMat.Text = RechercheForm.matric
        'ASCom.SelectedIndex = 0 'on met "Année scolaire" comme selecteditem au debut dans le combobox annéescolaire 
        Dim connetionString As String = Nothing
        Dim connection As OleDbConnection
        Dim command As OleDbCommand
        Dim adapter As New OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = connexionForm.chcnx
        sql = "select Distinct AnneeEtude from PARCOURS where id_Etudiant='" & LabelMat.Text & "'"

        connection = New OleDbConnection(connetionString)
        connection.Open()
        command = New OleDbCommand(sql, connection)
        adapter.SelectCommand = command
        adapter.Fill(ds)
        adapter.Dispose()
        command.Dispose()
        connection.Close()
        'mntn ds.tables(0) fiha les année d'étude li 9rahom siyed
        HistoANET.DataSource = ds.Tables(0) 'ndiro le datatable fle combobox
        HistoANET.ValueMember = "AnneeEtude"
        HistoANET.DisplayMember = "AnneeEtude"

    End Sub
    Private Sub relnoteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles globalButton.Click
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select Nb_RNG from ETUDIANT where id_Etudiant= '" & LabelMat.Text & "'"

        If HistoANET.Items.Count = 5 Then
            cnx = New OleDbConnection(connexionForm.chcnx)
            cnx.Open()
            dataAdapter = New OleDbDataAdapter(str, cnx)
            ds = New DataSet()
            dataAdapter.Fill(ds)
            cnx.Close()

            'Dim dt As DataTable()  ds.Tables(0)
            For Each rows As DataRow In ds.Tables(0).Rows
                Label7.Text = rows("Nb_RNG").ToString
            Next


            'EtatSortiePanel.Visible = True
            ImpGlb.Visible = True

        Else
            MessageBox.Show("Impossible de faire un relevé de notes global à un étudiant n'ayant pas terminé ses 5 ans d'étude.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
        'Dim not1 As DataTable

    End Sub

    Private Sub pvBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpleButton.Click
        HistoAnetPanel.Visible = True
        Me.globalButton.Location = New Point(0, 580)
        Me.Panel5.Location = New Point(0, 589)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        deconnexionPanel.Visible = True
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        '----------- Donne 2 DataTable contenant les informations d'un Etudiant precis ( Par son Matricule ) --------'
        '------------------------------------------------------------------------------------------------------------'

       



        '----------------------------------------------------------------------------------------------------'
        '-----------  donne une Data table contenant les informations de la Table Parcours d'un Etudiant precis ( par son matricule) --------'


        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select Nb_ATTESTATION from ETUDIANT where id_Etudiant= '" & LabelMat.Text & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()

        'Dim dt As DataTable()  ds.Tables(0)
        For Each rows As DataRow In ds.Tables(0).Rows
            LabelAt.Text = rows("Nb_ATTESTATION").ToString
        Next
        ImpressionPanel.Visible = True
        ' Dim Access As New BDDControl
        ' Access.ExecQuery(" Select Id_Etudiant,NomEtud,Prenoms,DATENAIS,LIEUNAIS from [ETUDIANT] WHERE Id_Etudiant = '" & LabelMat.Text & "'")
        ' If Not String.IsNullOrEmpty(Access.Exception) Then MsgBox(Access.Exception) : Exit Sub
        ' Ets.DataGridView.DataSource = Access.DBDT




        '-----------  Le 2eme DataTable contient les informations de la Table PARCOURS -----------'



    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.ConfGb.Visible = False
        Me.ConfSmp.Visible = False
        Me.ConfPanel.Visible = False
        Me.ImpressionPanel.Visible = False
        Me.ImpGlb.Visible = False
        Me.ImpSim.Visible = False
        AccueilForm.Show()
        Me.Close()
        RechercheForm.Close()
    End Sub

    Private Sub okBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okBtn.Click
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter
        Dim AnneeEtude As Integer
        AnneeEtude = CInt(HistoANET.SelectedItem(0))
        If AnneeEtude <> 5 Then
            Dim str As String
            str = "select Nb_RN from PARCOURS where id_Etudiant= '" & LabelMat.Text & "' AND AnneeEtude=" & AnneeEtude & ""


            cnx = New OleDbConnection(connexionForm.chcnx)
            cnx.Open()
            dataAdapter = New OleDbDataAdapter(str, cnx)
            ds = New DataSet()
            dataAdapter.Fill(ds)
            cnx.Close()

            'Dim dt As DataTable()  ds.Tables(0)
            For Each rows As DataRow In ds.Tables(0).Rows
                Label14.Text = rows("Nb_RN").ToString
            Next
            HistoAnetPanel.Visible = False
            ImpSim.Visible = True
        Else
            MessageBox.Show("la 5eme année n'est pas concernée par le relevé de note .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
        If Not (HistoAnetPanel.Visible) Then
            Me.globalButton.Location = New Point(0, 404)
            Me.Panel5.Location = New Point(0, 413)
        End If

        '----------- Donne 3 DataTable contenant les informations d'un Etudiant precis ( par son Matricule et son AnneeEtude) --------'
        '-----------------------------------------------------------------------------------------------------------------------------'



        '-----------  Le 1er DataTable contient les informations de la Table ETUDIANT -----------'

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        deconnexionPanel.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.ConfGb.Visible = False
        Me.ConfSmp.Visible = False
        Me.ConfPanel.Visible = False
        Me.ImpressionPanel.Visible = False
        Me.ImpGlb.Visible = False
        Me.ImpSim.Visible = False
        AideForm.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        connexionForm.Show()
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        deconnexionPanel.Visible = False

    End Sub

    Private Sub RetourBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetourBtn.Click
        Me.ConfGb.Visible = False
        Me.ConfSmp.Visible = False
        Me.ConfPanel.Visible = False
        Me.ImpressionPanel.Visible = False
        Me.ImpGlb.Visible = False
        Me.ImpSim.Visible = False
        RechercheForm.Show()
        Me.Hide()
    End Sub


    Private Sub ButtonParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParam.Click
        Me.ConfGb.Visible = False
        Me.ConfSmp.Visible = False
        Me.ConfPanel.Visible = False
        Me.ImpressionPanel.Visible = False
        Me.ImpGlb.Visible = False
        Me.ImpSim.Visible = False
        Parametrage.Show()
        Me.Close()
    End Sub

    Public ReadOnly Property Selecteditem As String
        Get
            Return HistoANET.Items(HistoANET.SelectedIndex)
        End Get
    End Property

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PanelStat_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles PanelStat.Paint

    End Sub

    Private Sub HistoAnetPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles HistoAnetPanel.Paint

    End Sub

    Private Sub HistoANET_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles HistoANET.SelectedIndexChanged
        Dim Etats As Class_Etats_Sorties = New Class_Etats_Sorties
        Dim connetionString As String = Nothing
        Dim connection As OleDbConnection
        Dim command As OleDbCommand
        Dim adapter As New OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = connexionForm.chcnx
        sql = "select Distinct AnneeScolaire from PARCOURS where id_Etudiant='" & LabelMat.Text & "' AND anneeEtude=" & HistoANET.SelectedItem(0) & ""

        connection = New OleDbConnection(connetionString)
        connection.Open()
        command = New OleDbCommand(sql, connection)
        adapter.SelectCommand = command
        adapter.Fill(ds)
        adapter.Dispose()
        command.Dispose()
        connection.Close()
        'mntn ds.tables(0) fiha les année d'étude li 9rahom siyed
        ASCom.DataSource = ds.Tables(0) 'ndiro le datatable fle combobox
        ASCom.ValueMember = "AnneeScolaire"
        ASCom.DisplayMember = "AnneeScolaire"

    End Sub

    Private Sub AttestationLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ImprimerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkAtButton.Click
        Dim Etats As Class_Etats_Sorties = New Class_Etats_Sorties
        Dim matricule As String
        matricule = LabelMat.Text
        Etats.Attestation(matricule)

        ImpressionPanel.Hide()

        ConfPanel.Visible = True


        ImpressionPanel.Visible = False


        Ets.Hide()

    End Sub

    Private Sub LabelAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub deconnexionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles deconnexionPanel.Paint

    End Sub

    Private Sub ImpressionPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ImpressionPanel.Paint

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select Nb_ATTESTATION from ETUDIANT where id_Etudiant= '" & LabelMat.Text & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Dim nbAt As Integer
        'Dim dt As DataTable()  ds.Tables(0)
        For Each rows As DataRow In ds.Tables(0).Rows
            nbAt = rows("Nb_ATTESTATION")
        Next
        nbAt = nbAt + 1


        Dim myConnection As OleDbConnection = New OleDbConnection


        Try


            myConnection.ConnectionString = connexionForm.chcnx
            myConnection.Open()


            '  Dim str As String = "Update ETUDIANT SET [Nb_ATTESTATION]='nbAt' where id_Etudiant= '" & LabelMat.Text & "'"
            str = "Update ETUDIANT SET [Nb_ATTESTATION]=" & nbAt & " where id_Etudiant= '" & LabelMat.Text & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)



            cmd.ExecuteNonQuery()

            cmd.Dispose()
            myConnection.Close()

            MsgBox(" Modification avec succès ! ", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        ConfPanel.Hide()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ConfPanel.Hide()

    End Sub

    Private Sub ReleveSimpleLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AttestationLabel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ImpGlb_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ImpGlb.Paint

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        Dim Etats As Class_Etats_Sorties = New Class_Etats_Sorties
        Dim matricule As String
        matricule = LabelMat.Text
        Etats.ReleveGlobal(matricule)


        ImpGlb.Hide()
        ' ReleveGlobalF.ShowDialog()
        ' ReleveGlobalF.Dispose()


        ConfGb.Visible = True


    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter


        Dim str As String
        str = "select NB_RNG from ETUDIANT where id_Etudiant= '" & LabelMat.Text & "'"


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Dim nbAt As Integer
        'Dim dt As DataTable()  ds.Tables(0)
        For Each rows As DataRow In ds.Tables(0).Rows
            nbAt = rows("Nb_RNG")
        Next
        nbAt = nbAt + 1


        Dim myConnection As OleDbConnection = New OleDbConnection


        Try


            myConnection.ConnectionString = connexionForm.chcnx
            myConnection.Open()


            '  Dim str As String = "Update ETUDIANT SET [Nb_ATTESTATION]='nbAt' where id_Etudiant= '" & LabelMat.Text & "'"
            str = "Update ETUDIANT SET [Nb_RNG]=" & nbAt & " where id_Etudiant= '" & LabelMat.Text & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)



            cmd.ExecuteNonQuery()

            cmd.Dispose()
            myConnection.Close()

            MsgBox(" Modification avec succès ! ", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        ConfGb.Hide()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        ConfGb.Hide()

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim AnneeEtude As Integer
        Dim matricule As String
        Dim AnneeScolaire As String
        Dim Etats As Class_Etats_Sorties = New Class_Etats_Sorties
        AnneeEtude = CInt(HistoANET.SelectedItem(0))
        matricule = LabelMat.Text
        AnneeScolaire = ASCom.SelectedItem("AnneeScolaire").ToString

        Etats.ReleveSimple(matricule, AnneeEtude, AnneeScolaire)





        ImpSim.Hide()
        ConfSmp.Visible = True




        Ets.Hide()
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Dim cnx As OleDbConnection
        Dim ds As DataSet
        Dim dataAdapter As OleDbDataAdapter
        Dim AnneeEtude As Integer
        Dim AnneeSco As Integer
        AnneeEtude = CInt(HistoANET.SelectedItem)


        Dim str As String
        str = "select Nb_RN from PARCOURS where id_Etudiant= '" & LabelMat.Text & "' AND AnneeEtude=" & AnneeEtude & ""


        cnx = New OleDbConnection(connexionForm.chcnx)
        cnx.Open()
        dataAdapter = New OleDbDataAdapter(str, cnx)
        ds = New DataSet()
        dataAdapter.Fill(ds)
        cnx.Close()
        Dim nbAt As Integer
        'Dim dt As DataTable()  ds.Tables(0)
        For Each rows As DataRow In ds.Tables(0).Rows
            nbAt = rows("Nb_RN")
        Next
        nbAt = nbAt + 1


        Dim myConnection As OleDbConnection = New OleDbConnection


        Try


            myConnection.ConnectionString = connexionForm.chcnx
            myConnection.Open()


            '  Dim str As String = "Update ETUDIANT SET [Nb_ATTESTATION]='nbAt' where id_Etudiant= '" & LabelMat.Text & "'"
            str = "Update PARCOURS SET [Nb_RN]=" & nbAt & " where id_Etudiant= '" & LabelMat.Text & "' AND AnneeEtude = " & AnneeEtude & ""
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)



            cmd.ExecuteNonQuery()

            cmd.Dispose()
            myConnection.Close()

            MsgBox(" Modification avec succès ! ", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        ConfSmp.Hide()
    End Sub

   

    
  

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        ConfSmp.Hide()

    End Sub

    
    
    Private Sub RechercheLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Me.ImpressionPanel.Visible = False
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Me.ImpSim.Visible = False
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Me.ImpGlb.Visible = False
    End Sub

    Private Sub ASCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASCom.SelectedIndexChanged

    End Sub
End Class