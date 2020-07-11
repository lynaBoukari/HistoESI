<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chargement
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
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.deconnexionPanel = New System.Windows.Forms.Panel()
        Me.AnnulerButton = New System.Windows.Forms.Button()
        Me.OuiButton = New System.Windows.Forms.Button()
        Me.deconnexionLabel = New System.Windows.Forms.Label()
        Me.PanelStat = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Correction = New System.Windows.Forms.Button()
        Me.CHRG_NV = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.AccueilButton = New System.Windows.Forms.Button()
        Me.ParamButton = New System.Windows.Forms.Button()
        Me.AideButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DeconnexionButton = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Rectanglewhite = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.deconnexionPanel)
        Me.Panel1.Controls.Add(Me.PanelStat)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 749)
        Me.Panel1.TabIndex = 5
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = Global.Projet.My.Resources.Resources.blank_database_symbol
        Me.PictureBox5.Location = New System.Drawing.Point(359, 116)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(38, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 17
        Me.PictureBox5.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(403, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 31)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Chargement"
        '
        'deconnexionPanel
        '
        Me.deconnexionPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deconnexionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.deconnexionPanel.Controls.Add(Me.AnnulerButton)
        Me.deconnexionPanel.Controls.Add(Me.OuiButton)
        Me.deconnexionPanel.Controls.Add(Me.deconnexionLabel)
        Me.deconnexionPanel.Location = New System.Drawing.Point(607, 307)
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
        Me.AnnulerButton.ForeColor = System.Drawing.Color.Black
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
        Me.OuiButton.ForeColor = System.Drawing.Color.Black
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
        Me.deconnexionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.deconnexionLabel.Location = New System.Drawing.Point(54, 36)
        Me.deconnexionLabel.Name = "deconnexionLabel"
        Me.deconnexionLabel.Size = New System.Drawing.Size(376, 23)
        Me.deconnexionLabel.TabIndex = 0
        Me.deconnexionLabel.Text = "Voulez-vous vraiment vous déconnecter?"
        '
        'PanelStat
        '
        Me.PanelStat.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PanelStat.Controls.Add(Me.Panel5)
        Me.PanelStat.Controls.Add(Me.Panel3)
        Me.PanelStat.Controls.Add(Me.Correction)
        Me.PanelStat.Controls.Add(Me.CHRG_NV)
        Me.PanelStat.Controls.Add(Me.PictureBox2)
        Me.PanelStat.Controls.Add(Me.PictureBox1)
        Me.PanelStat.Location = New System.Drawing.Point(0, 1)
        Me.PanelStat.Name = "PanelStat"
        Me.PanelStat.Size = New System.Drawing.Size(329, 749)
        Me.PanelStat.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(0, 310)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(18, 53)
        Me.Panel5.TabIndex = 22
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(1, 226)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(18, 53)
        Me.Panel3.TabIndex = 21
        '
        'Correction
        '
        Me.Correction.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Correction.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Correction.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Correction.FlatAppearance.BorderSize = 0
        Me.Correction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Correction.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Correction.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Correction.Location = New System.Drawing.Point(19, 310)
        Me.Correction.Name = "Correction"
        Me.Correction.Size = New System.Drawing.Size(301, 48)
        Me.Correction.TabIndex = 20
        Me.Correction.Text = "Correction des erreurs"
        Me.Correction.UseVisualStyleBackColor = False
        '
        'CHRG_NV
        '
        Me.CHRG_NV.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CHRG_NV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CHRG_NV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CHRG_NV.FlatAppearance.BorderSize = 0
        Me.CHRG_NV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CHRG_NV.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRG_NV.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CHRG_NV.Location = New System.Drawing.Point(12, 226)
        Me.CHRG_NV.Name = "CHRG_NV"
        Me.CHRG_NV.Size = New System.Drawing.Size(305, 53)
        Me.CHRG_NV.TabIndex = 19
        Me.CHRG_NV.Text = "Charger de nouveaux fichiers"
        Me.CHRG_NV.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Projet.My.Resources.Resources.HE_HISTOESI
        Me.PictureBox2.Location = New System.Drawing.Point(110, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Projet.My.Resources.Resources.HE_HE
        Me.PictureBox1.Location = New System.Drawing.Point(19, 12)
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
        Me.Panel4.Controls.Add(Me.ParamButton)
        Me.Panel4.Controls.Add(Me.AideButton)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.DeconnexionButton)
        Me.Panel4.Location = New System.Drawing.Point(319, 29)
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
        Me.AccueilButton.ForeColor = System.Drawing.Color.White
        Me.AccueilButton.Location = New System.Drawing.Point(610, -1)
        Me.AccueilButton.Name = "AccueilButton"
        Me.AccueilButton.Size = New System.Drawing.Size(105, 71)
        Me.AccueilButton.TabIndex = 2
        Me.AccueilButton.Text = "Accueil"
        Me.AccueilButton.UseVisualStyleBackColor = False
        '
        'ParamButton
        '
        Me.ParamButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ParamButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ParamButton.FlatAppearance.BorderSize = 0
        Me.ParamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ParamButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParamButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ParamButton.Location = New System.Drawing.Point(830, -1)
        Me.ParamButton.Name = "ParamButton"
        Me.ParamButton.Size = New System.Drawing.Size(105, 71)
        Me.ParamButton.TabIndex = 4
        Me.ParamButton.Text = "Paramètres"
        Me.ParamButton.UseVisualStyleBackColor = False
        '
        'AideButton
        '
        Me.AideButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.AideButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AideButton.FlatAppearance.BorderSize = 0
        Me.AideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AideButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AideButton.ForeColor = System.Drawing.Color.White
        Me.AideButton.Location = New System.Drawing.Point(721, 0)
        Me.AideButton.Name = "AideButton"
        Me.AideButton.Size = New System.Drawing.Size(105, 71)
        Me.AideButton.TabIndex = 1
        Me.AideButton.Text = "Aide"
        Me.AideButton.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Location = New System.Drawing.Point(12, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 68)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "< Retour"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'DeconnexionButton
        '
        Me.DeconnexionButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.DeconnexionButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DeconnexionButton.FlatAppearance.BorderSize = 0
        Me.DeconnexionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeconnexionButton.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeconnexionButton.ForeColor = System.Drawing.Color.White
        Me.DeconnexionButton.Location = New System.Drawing.Point(943, 0)
        Me.DeconnexionButton.Name = "DeconnexionButton"
        Me.DeconnexionButton.Size = New System.Drawing.Size(108, 71)
        Me.DeconnexionButton.TabIndex = 0
        Me.DeconnexionButton.Text = "Deconnexion"
        Me.DeconnexionButton.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Rectanglewhite, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1370, 749)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'Rectanglewhite
        '
        Me.Rectanglewhite.BackColor = System.Drawing.Color.White
        Me.Rectanglewhite.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Rectanglewhite.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.Rectanglewhite.CornerRadius = 5
        Me.Rectanglewhite.Location = New System.Drawing.Point(338, 111)
        Me.Rectanglewhite.Name = "Rectanglewhite"
        Me.Rectanglewhite.Size = New System.Drawing.Size(1022, 42)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.LightGray
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(338, 116)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1022, 42)
        '
        'Chargement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(1370, 749)
        Me.MinimumSize = New System.Drawing.Size(1364, 726)
        Me.Name = "Chargement"
        Me.Text = "Chargement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.deconnexionPanel.ResumeLayout(False)
        Me.deconnexionPanel.PerformLayout()
        Me.PanelStat.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents deconnexionPanel As System.Windows.Forms.Panel
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OuiButton As System.Windows.Forms.Button
    Friend WithEvents deconnexionLabel As System.Windows.Forms.Label
    Friend WithEvents PanelStat As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents AccueilButton As System.Windows.Forms.Button
    Friend WithEvents ParamButton As System.Windows.Forms.Button
    Friend WithEvents AideButton As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DeconnexionButton As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Rectanglewhite As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Correction As System.Windows.Forms.Button
    Friend WithEvents CHRG_NV As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
End Class
