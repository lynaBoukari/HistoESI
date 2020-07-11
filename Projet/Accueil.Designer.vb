<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccueilForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccueilForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.acceuilAdminLabel = New System.Windows.Forms.Label()
        Me.acceuilPersLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelStat = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.statistiquesAccButton = New System.Windows.Forms.Button()
        Me.classementAccButton = New System.Windows.Forms.Button()
        Me.rechAccButton = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.deconnexionPanel = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.deconnexionLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ButtonParam = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.PanelStat.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.deconnexionPanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel1.Controls.Add(Me.deconnexionPanel)
        Me.Panel1.Controls.Add(Me.acceuilAdminLabel)
        Me.Panel1.Controls.Add(Me.acceuilPersLabel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PanelStat)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 749)
        Me.Panel1.TabIndex = 1
        '
        'acceuilAdminLabel
        '
        Me.acceuilAdminLabel.AutoSize = True
        Me.acceuilAdminLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acceuilAdminLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.acceuilAdminLabel.Location = New System.Drawing.Point(362, 187)
        Me.acceuilAdminLabel.Name = "acceuilAdminLabel"
        Me.acceuilAdminLabel.Size = New System.Drawing.Size(314, 16)
        Me.acceuilAdminLabel.TabIndex = 4
        Me.acceuilAdminLabel.Text = "Vous êtes  connectés en Tant Que Administrateur"
        '
        'acceuilPersLabel
        '
        Me.acceuilPersLabel.AutoSize = True
        Me.acceuilPersLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acceuilPersLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.acceuilPersLabel.Location = New System.Drawing.Point(362, 187)
        Me.acceuilPersLabel.Name = "acceuilPersLabel"
        Me.acceuilPersLabel.Size = New System.Drawing.Size(282, 16)
        Me.acceuilPersLabel.TabIndex = 5
        Me.acceuilPersLabel.Text = "Vous êtes  connectés en Tant Que Personnel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(349, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(355, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bienvenue dans HistoESI"
        '
        'PanelStat
        '
        Me.PanelStat.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PanelStat.Controls.Add(Me.Panel7)
        Me.PanelStat.Controls.Add(Me.Button2)
        Me.PanelStat.Controls.Add(Me.Panel6)
        Me.PanelStat.Controls.Add(Me.Panel5)
        Me.PanelStat.Controls.Add(Me.Panel3)
        Me.PanelStat.Controls.Add(Me.statistiquesAccButton)
        Me.PanelStat.Controls.Add(Me.classementAccButton)
        Me.PanelStat.Controls.Add(Me.rechAccButton)
        Me.PanelStat.Controls.Add(Me.PictureBox2)
        Me.PanelStat.Controls.Add(Me.PictureBox1)
        Me.PanelStat.Location = New System.Drawing.Point(0, 0)
        Me.PanelStat.Name = "PanelStat"
        Me.PanelStat.Size = New System.Drawing.Size(329, 749)
        Me.PanelStat.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel7.Location = New System.Drawing.Point(0, 405)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(18, 41)
        Me.Panel7.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Info
        Me.Button2.Location = New System.Drawing.Point(1, 389)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(326, 71)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "PV de délibération"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(0, 323)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(18, 41)
        Me.Panel6.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(0, 244)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(18, 41)
        Me.Panel5.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(0, 167)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(18, 41)
        Me.Panel3.TabIndex = 3
        '
        'statistiquesAccButton
        '
        Me.statistiquesAccButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.statistiquesAccButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.statistiquesAccButton.FlatAppearance.BorderSize = 0
        Me.statistiquesAccButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.statistiquesAccButton.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statistiquesAccButton.ForeColor = System.Drawing.SystemColors.Info
        Me.statistiquesAccButton.Location = New System.Drawing.Point(-1, 306)
        Me.statistiquesAccButton.Name = "statistiquesAccButton"
        Me.statistiquesAccButton.Size = New System.Drawing.Size(326, 71)
        Me.statistiquesAccButton.TabIndex = 4
        Me.statistiquesAccButton.Text = "Statistiques"
        Me.statistiquesAccButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.statistiquesAccButton.UseVisualStyleBackColor = False
        '
        'classementAccButton
        '
        Me.classementAccButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.classementAccButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.classementAccButton.FlatAppearance.BorderSize = 0
        Me.classementAccButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.classementAccButton.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.classementAccButton.ForeColor = System.Drawing.SystemColors.Info
        Me.classementAccButton.Location = New System.Drawing.Point(0, 229)
        Me.classementAccButton.Name = "classementAccButton"
        Me.classementAccButton.Size = New System.Drawing.Size(326, 71)
        Me.classementAccButton.TabIndex = 3
        Me.classementAccButton.Text = "Classement"
        Me.classementAccButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.classementAccButton.UseVisualStyleBackColor = False
        '
        'rechAccButton
        '
        Me.rechAccButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.rechAccButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rechAccButton.FlatAppearance.BorderSize = 0
        Me.rechAccButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rechAccButton.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rechAccButton.ForeColor = System.Drawing.SystemColors.Info
        Me.rechAccButton.Location = New System.Drawing.Point(-1, 152)
        Me.rechAccButton.Name = "rechAccButton"
        Me.rechAccButton.Size = New System.Drawing.Size(326, 71)
        Me.rechAccButton.TabIndex = 2
        Me.rechAccButton.Text = "Recherche"
        Me.rechAccButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rechAccButton.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Projet.My.Resources.Resources.HE_HISTOESI
        Me.PictureBox2.Location = New System.Drawing.Point(116, 53)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Projet.My.Resources.Resources.HE_HE
        Me.PictureBox1.Location = New System.Drawing.Point(25, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 61)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'deconnexionPanel
        '
        Me.deconnexionPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deconnexionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.deconnexionPanel.Controls.Add(Me.Button10)
        Me.deconnexionPanel.Controls.Add(Me.Button9)
        Me.deconnexionPanel.Controls.Add(Me.deconnexionLabel)
        Me.deconnexionPanel.Location = New System.Drawing.Point(654, 263)
        Me.deconnexionPanel.Name = "deconnexionPanel"
        Me.deconnexionPanel.Size = New System.Drawing.Size(466, 213)
        Me.deconnexionPanel.TabIndex = 3
        Me.deconnexionPanel.Visible = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button10.FlatAppearance.BorderSize = 2
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Tai Le", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Black
        Me.Button10.Location = New System.Drawing.Point(174, 132)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(118, 34)
        Me.Button10.TabIndex = 2
        Me.Button10.Text = "Annuler"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Black
        Me.Button9.Location = New System.Drawing.Point(174, 82)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(118, 34)
        Me.Button9.TabIndex = 1
        Me.Button9.Text = "Oui"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'deconnexionLabel
        '
        Me.deconnexionLabel.AutoSize = True
        Me.deconnexionLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deconnexionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.deconnexionLabel.Location = New System.Drawing.Point(54, 36)
        Me.deconnexionLabel.Name = "deconnexionLabel"
        Me.deconnexionLabel.Size = New System.Drawing.Size(376, 23)
        Me.deconnexionLabel.TabIndex = 0
        Me.deconnexionLabel.Text = "Voulez-vous vraiment vous déconnecter?"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1370, 29)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.ButtonParam)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Location = New System.Drawing.Point(318, 29)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1050, 71)
        Me.Panel4.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Info
        Me.Button1.Location = New System.Drawing.Point(941, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 71)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Déconnexion"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Info
        Me.Button5.Location = New System.Drawing.Point(607, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 71)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Accueil"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'ButtonParam
        '
        Me.ButtonParam.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ButtonParam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonParam.FlatAppearance.BorderSize = 0
        Me.ButtonParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonParam.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonParam.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonParam.Location = New System.Drawing.Point(830, 0)
        Me.ButtonParam.Name = "ButtonParam"
        Me.ButtonParam.Size = New System.Drawing.Size(104, 71)
        Me.ButtonParam.TabIndex = 3
        Me.ButtonParam.Text = "Paramètres"
        Me.ButtonParam.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.Info
        Me.Button4.Location = New System.Drawing.Point(718, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 71)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Aide"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(643, 306)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(509, 390)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'AccueilForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AccueilForm"
        Me.Text = "Accueil"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelStat.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.deconnexionPanel.ResumeLayout(False)
        Me.deconnexionPanel.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents deconnexionPanel As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents deconnexionLabel As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PanelStat As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents statistiquesAccButton As System.Windows.Forms.Button
    Friend WithEvents classementAccButton As System.Windows.Forms.Button
    Friend WithEvents rechAccButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonParam As System.Windows.Forms.Button
    Friend WithEvents acceuilPersLabel As System.Windows.Forms.Label
    Friend WithEvents acceuilAdminLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
