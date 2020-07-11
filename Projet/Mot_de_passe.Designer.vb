<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mot_de_passe
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.EtatSortiePanel = New System.Windows.Forms.Panel()
        Me.deconnexionPanel = New System.Windows.Forms.Panel()
        Me.AnnulerButton = New System.Windows.Forms.Button()
        Me.OuiButton = New System.Windows.Forms.Button()
        Me.deconnexionLabel = New System.Windows.Forms.Label()
        Me.TextBoxnouveau = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBoxnouveauPers = New System.Windows.Forms.MaskedTextBox()
        Me.AnetBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labelprenom = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.PanelStat = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.AccueilButton = New System.Windows.Forms.Button()
        Me.AideButton = New System.Windows.Forms.Button()
        Me.ParamButton = New System.Windows.Forms.Button()
        Me.DeconnexionButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Rectanglewhite = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EtatSortiePanel.SuspendLayout()
        Me.deconnexionPanel.SuspendLayout()
        Me.PanelStat.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label)
        Me.Panel1.Controls.Add(Me.EtatSortiePanel)
        Me.Panel1.Controls.Add(Me.PanelStat)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.ShapeContainer2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 749)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.Image = Global.Projet.My.Resources.Resources.unnamed
        Me.PictureBox3.Location = New System.Drawing.Point(351, 114)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(38, 31)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.White
        Me.Label.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label.Font = New System.Drawing.Font("Microsoft Tai Le", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label.Location = New System.Drawing.Point(395, 115)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(166, 31)
        Me.Label.TabIndex = 9
        Me.Label.Text = "Mot de passe"
        '
        'EtatSortiePanel
        '
        Me.EtatSortiePanel.BackColor = System.Drawing.SystemColors.HighlightText
        Me.EtatSortiePanel.Controls.Add(Me.deconnexionPanel)
        Me.EtatSortiePanel.Controls.Add(Me.TextBoxnouveau)
        Me.EtatSortiePanel.Controls.Add(Me.TextBox1)
        Me.EtatSortiePanel.Controls.Add(Me.TextBoxnouveauPers)
        Me.EtatSortiePanel.Controls.Add(Me.AnetBox)
        Me.EtatSortiePanel.Controls.Add(Me.Label6)
        Me.EtatSortiePanel.Controls.Add(Me.Label5)
        Me.EtatSortiePanel.Controls.Add(Me.Label4)
        Me.EtatSortiePanel.Controls.Add(Me.Label3)
        Me.EtatSortiePanel.Controls.Add(Me.Button4)
        Me.EtatSortiePanel.Controls.Add(Me.Button5)
        Me.EtatSortiePanel.Controls.Add(Me.Button3)
        Me.EtatSortiePanel.Controls.Add(Me.Button1)
        Me.EtatSortiePanel.Controls.Add(Me.Label2)
        Me.EtatSortiePanel.Controls.Add(Me.Label1)
        Me.EtatSortiePanel.Controls.Add(Me.Labelprenom)
        Me.EtatSortiePanel.Controls.Add(Me.ShapeContainer1)
        Me.EtatSortiePanel.Location = New System.Drawing.Point(382, 218)
        Me.EtatSortiePanel.Name = "EtatSortiePanel"
        Me.EtatSortiePanel.Size = New System.Drawing.Size(950, 504)
        Me.EtatSortiePanel.TabIndex = 7
        '
        'deconnexionPanel
        '
        Me.deconnexionPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deconnexionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.deconnexionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.deconnexionPanel.Controls.Add(Me.AnnulerButton)
        Me.deconnexionPanel.Controls.Add(Me.OuiButton)
        Me.deconnexionPanel.Controls.Add(Me.deconnexionLabel)
        Me.deconnexionPanel.Location = New System.Drawing.Point(254, 213)
        Me.deconnexionPanel.Name = "deconnexionPanel"
        Me.deconnexionPanel.Size = New System.Drawing.Size(466, 213)
        Me.deconnexionPanel.TabIndex = 6
        Me.deconnexionPanel.Visible = False
        '
        'AnnulerButton
        '
        Me.AnnulerButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AnnulerButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AnnulerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AnnulerButton.FlatAppearance.BorderSize = 2
        Me.AnnulerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AnnulerButton.Font = New System.Drawing.Font("Microsoft Tai Le", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnnulerButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AnnulerButton.Location = New System.Drawing.Point(174, 132)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(118, 34)
        Me.AnnulerButton.TabIndex = 2
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = False
        '
        'OuiButton
        '
        Me.OuiButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.OuiButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OuiButton.FlatAppearance.BorderSize = 0
        Me.OuiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OuiButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OuiButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.OuiButton.Location = New System.Drawing.Point(174, 82)
        Me.OuiButton.Name = "OuiButton"
        Me.OuiButton.Size = New System.Drawing.Size(118, 34)
        Me.OuiButton.TabIndex = 1
        Me.OuiButton.Text = "Oui"
        Me.OuiButton.UseVisualStyleBackColor = False
        '
        'deconnexionLabel
        '
        Me.deconnexionLabel.AutoSize = True
        Me.deconnexionLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deconnexionLabel.ForeColor = System.Drawing.Color.White
        Me.deconnexionLabel.Location = New System.Drawing.Point(54, 36)
        Me.deconnexionLabel.Name = "deconnexionLabel"
        Me.deconnexionLabel.Size = New System.Drawing.Size(376, 23)
        Me.deconnexionLabel.TabIndex = 0
        Me.deconnexionLabel.Text = "Voulez-vous vraiment vous déconnecter?"
        '
        'TextBoxnouveau
        '
        Me.TextBoxnouveau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxnouveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxnouveau.Location = New System.Drawing.Point(196, 295)
        Me.TextBoxnouveau.MinimumSize = New System.Drawing.Size(150, 34)
        Me.TextBoxnouveau.Name = "TextBoxnouveau"
        Me.TextBoxnouveau.Size = New System.Drawing.Size(169, 26)
        Me.TextBoxnouveau.TabIndex = 40
        Me.TextBoxnouveau.UseSystemPasswordChar = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(676, 255)
        Me.TextBox1.MinimumSize = New System.Drawing.Size(150, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 26)
        Me.TextBox1.TabIndex = 39
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'TextBoxnouveauPers
        '
        Me.TextBoxnouveauPers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxnouveauPers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxnouveauPers.Location = New System.Drawing.Point(676, 295)
        Me.TextBoxnouveauPers.MinimumSize = New System.Drawing.Size(150, 34)
        Me.TextBoxnouveauPers.Name = "TextBoxnouveauPers"
        Me.TextBoxnouveauPers.Size = New System.Drawing.Size(170, 26)
        Me.TextBoxnouveauPers.TabIndex = 38
        Me.TextBoxnouveauPers.UseSystemPasswordChar = True
        '
        'AnetBox
        '
        Me.AnetBox.BackColor = System.Drawing.Color.White
        Me.AnetBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnetBox.Location = New System.Drawing.Point(196, 258)
        Me.AnetBox.MinimumSize = New System.Drawing.Size(150, 34)
        Me.AnetBox.Name = "AnetBox"
        Me.AnetBox.Size = New System.Drawing.Size(170, 26)
        Me.AnetBox.TabIndex = 37
        Me.AnetBox.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(516, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 15)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Ancien mot de passe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(518, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Nouveau mot de passe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(39, 308)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 15)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Nouveau mot de passe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(44, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 15)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Ancien mot de passe"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Tai Le", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(774, 340)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 30)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Annuler"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button5.Location = New System.Drawing.Point(676, 340)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 30)
        Me.Button5.TabIndex = 30
        Me.Button5.Text = "Sauvegarder"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Tai Le", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(291, 339)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Annuler"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Location = New System.Drawing.Point(196, 340)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 30)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Sauvegarder"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(571, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Changer Mot de passe Personnel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(117, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Changer Mot de passe Admin"
        '
        'Labelprenom
        '
        Me.Labelprenom.AutoSize = True
        Me.Labelprenom.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelprenom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Labelprenom.Location = New System.Drawing.Point(395, 69)
        Me.Labelprenom.Name = "Labelprenom"
        Me.Labelprenom.Size = New System.Drawing.Size(164, 31)
        Me.Labelprenom.TabIndex = 3
        Me.Labelprenom.Text = "Paramètres"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(950, 504)
        Me.ShapeContainer1.TabIndex = 41
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 2
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(28, 32)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(931, 446)
        '
        'PanelStat
        '
        Me.PanelStat.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PanelStat.Controls.Add(Me.PictureBox2)
        Me.PanelStat.Controls.Add(Me.PictureBox1)
        Me.PanelStat.Location = New System.Drawing.Point(0, 1)
        Me.PanelStat.Name = "PanelStat"
        Me.PanelStat.Size = New System.Drawing.Size(329, 749)
        Me.PanelStat.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Projet.My.Resources.Resources.HE_HISTOESI
        Me.PictureBox2.Location = New System.Drawing.Point(118, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Projet.My.Resources.Resources.HE_HE
        Me.PictureBox1.Location = New System.Drawing.Point(27, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 61)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
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
        Me.Panel4.Controls.Add(Me.AccueilButton)
        Me.Panel4.Controls.Add(Me.AideButton)
        Me.Panel4.Controls.Add(Me.ParamButton)
        Me.Panel4.Controls.Add(Me.DeconnexionButton)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Location = New System.Drawing.Point(319, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1050, 71)
        Me.Panel4.TabIndex = 2
        '
        'AccueilButton
        '
        Me.AccueilButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.AccueilButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AccueilButton.FlatAppearance.BorderSize = 0
        Me.AccueilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AccueilButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccueilButton.ForeColor = System.Drawing.SystemColors.Info
        Me.AccueilButton.Location = New System.Drawing.Point(594, 0)
        Me.AccueilButton.Name = "AccueilButton"
        Me.AccueilButton.Size = New System.Drawing.Size(109, 71)
        Me.AccueilButton.TabIndex = 2
        Me.AccueilButton.Text = "Accueil"
        Me.AccueilButton.UseVisualStyleBackColor = False
        '
        'AideButton
        '
        Me.AideButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.AideButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AideButton.FlatAppearance.BorderSize = 0
        Me.AideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AideButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AideButton.ForeColor = System.Drawing.SystemColors.Info
        Me.AideButton.Location = New System.Drawing.Point(709, 0)
        Me.AideButton.Name = "AideButton"
        Me.AideButton.Size = New System.Drawing.Size(109, 71)
        Me.AideButton.TabIndex = 1
        Me.AideButton.Text = "Aide"
        Me.AideButton.UseVisualStyleBackColor = False
        '
        'ParamButton
        '
        Me.ParamButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ParamButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ParamButton.FlatAppearance.BorderSize = 0
        Me.ParamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ParamButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParamButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ParamButton.Location = New System.Drawing.Point(824, 0)
        Me.ParamButton.Name = "ParamButton"
        Me.ParamButton.Size = New System.Drawing.Size(109, 71)
        Me.ParamButton.TabIndex = 4
        Me.ParamButton.Text = "Paramètres"
        Me.ParamButton.UseVisualStyleBackColor = False
        '
        'DeconnexionButton
        '
        Me.DeconnexionButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.DeconnexionButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DeconnexionButton.FlatAppearance.BorderSize = 0
        Me.DeconnexionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeconnexionButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeconnexionButton.ForeColor = System.Drawing.SystemColors.Info
        Me.DeconnexionButton.Location = New System.Drawing.Point(939, 0)
        Me.DeconnexionButton.Name = "DeconnexionButton"
        Me.DeconnexionButton.Size = New System.Drawing.Size(105, 71)
        Me.DeconnexionButton.TabIndex = 0
        Me.DeconnexionButton.Text = "Déconnexion"
        Me.DeconnexionButton.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Location = New System.Drawing.Point(16, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 34)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "< Retour"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.Rectanglewhite})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1370, 749)
        Me.ShapeContainer2.TabIndex = 8
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.White
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(335, 109)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(1022, 42)
        '
        'Rectanglewhite
        '
        Me.Rectanglewhite.BackColor = System.Drawing.Color.LightGray
        Me.Rectanglewhite.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Rectanglewhite.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.Rectanglewhite.CornerRadius = 5
        Me.Rectanglewhite.Location = New System.Drawing.Point(335, 114)
        Me.Rectanglewhite.Name = "Rectanglewhite"
        Me.Rectanglewhite.Size = New System.Drawing.Size(1022, 42)
        '
        'Mot_de_passe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Mot_de_passe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametres"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EtatSortiePanel.ResumeLayout(False)
        Me.EtatSortiePanel.PerformLayout()
        Me.deconnexionPanel.ResumeLayout(False)
        Me.deconnexionPanel.PerformLayout()
        Me.PanelStat.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents deconnexionPanel As System.Windows.Forms.Panel
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OuiButton As System.Windows.Forms.Button
    Friend WithEvents deconnexionLabel As System.Windows.Forms.Label
    Friend WithEvents PanelStat As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ParamButton As System.Windows.Forms.Button
    Friend WithEvents AccueilButton As System.Windows.Forms.Button
    Friend WithEvents AideButton As System.Windows.Forms.Button
    Friend WithEvents DeconnexionButton As System.Windows.Forms.Button
    Friend WithEvents EtatSortiePanel As System.Windows.Forms.Panel
    Friend WithEvents Labelprenom As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxnouveau As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBoxnouveauPers As System.Windows.Forms.MaskedTextBox
    Friend WithEvents AnetBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Rectanglewhite As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
