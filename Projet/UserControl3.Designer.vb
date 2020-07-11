<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl3
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl3))
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape7 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape8 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LabelAnnUniv = New System.Windows.Forms.Label()
        Me.LabelRes = New System.Windows.Forms.Label()
        Me.LabelAnnEtu = New System.Windows.Forms.Label()
        Me.LabelAnneeNum = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LabelNoteElim = New System.Windows.Forms.Label()
        Me.LabelSection = New System.Windows.Forms.Label()
        Me.LabelGroupe = New System.Windows.Forms.Label()
        Me.LabelMention = New System.Windows.Forms.Label()
        Me.LabelAnneSco = New System.Windows.Forms.Label()
        Me.ButtonImpression = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 820
        Me.LineShape2.X2 = 820
        Me.LineShape2.Y1 = 0
        Me.LineShape2.Y2 = 36
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 157
        Me.LineShape1.X2 = 157
        Me.LineShape1.Y1 = 0
        Me.LineShape1.Y2 = 36
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape6, Me.LineShape7, Me.LineShape8, Me.LineShape1, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(960, 37)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 730
        Me.LineShape3.X2 = 730
        Me.LineShape3.Y1 = 0
        Me.LineShape3.Y2 = 36
        '
        'LineShape6
        '
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 500
        Me.LineShape6.X2 = 500
        Me.LineShape6.Y1 = 0
        Me.LineShape6.Y2 = 36
        '
        'LineShape7
        '
        Me.LineShape7.Name = "LineShape7"
        Me.LineShape7.X1 = 565
        Me.LineShape7.X2 = 565
        Me.LineShape7.Y1 = 0
        Me.LineShape7.Y2 = 36
        '
        'LineShape8
        '
        Me.LineShape8.Name = "LineShape8"
        Me.LineShape8.X1 = 633
        Me.LineShape8.X2 = 633
        Me.LineShape8.Y1 = 0
        Me.LineShape8.Y2 = 36
        '
        'LabelAnnUniv
        '
        Me.LabelAnnUniv.AutoSize = True
        Me.LabelAnnUniv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnnUniv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelAnnUniv.Location = New System.Drawing.Point(12, 11)
        Me.LabelAnnUniv.Name = "LabelAnnUniv"
        Me.LabelAnnUniv.Size = New System.Drawing.Size(144, 16)
        Me.LabelAnnUniv.TabIndex = 7
        Me.LabelAnnUniv.Text = "Année Universitaire"
        '
        'LabelRes
        '
        Me.LabelRes.AutoSize = True
        Me.LabelRes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelRes.Location = New System.Drawing.Point(821, 12)
        Me.LabelRes.Name = "LabelRes"
        Me.LabelRes.Size = New System.Drawing.Size(65, 16)
        Me.LabelRes.TabIndex = 9
        Me.LabelRes.Text = "Résultat"
        '
        'LabelAnnEtu
        '
        Me.LabelAnnEtu.AutoSize = True
        Me.LabelAnnEtu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnnEtu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelAnnEtu.Location = New System.Drawing.Point(163, 14)
        Me.LabelAnnEtu.Name = "LabelAnnEtu"
        Me.LabelAnnEtu.Size = New System.Drawing.Size(90, 13)
        Me.LabelAnnEtu.TabIndex = 10
        Me.LabelAnnEtu.Text = "Année d'Etude"
        '
        'LabelAnneeNum
        '
        Me.LabelAnneeNum.AutoSize = True
        Me.LabelAnneeNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnneeNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelAnneeNum.Location = New System.Drawing.Point(485, 21)
        Me.LabelAnneeNum.Name = "LabelAnneeNum"
        Me.LabelAnneeNum.Size = New System.Drawing.Size(14, 13)
        Me.LabelAnneeNum.TabIndex = 11
        Me.LabelAnneeNum.Text = "1"
        Me.LabelAnneeNum.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(902, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 37)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LabelNoteElim
        '
        Me.LabelNoteElim.AutoSize = True
        Me.LabelNoteElim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoteElim.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelNoteElim.Location = New System.Drawing.Point(642, 12)
        Me.LabelNoteElim.Name = "LabelNoteElim"
        Me.LabelNoteElim.Size = New System.Drawing.Size(77, 26)
        Me.LabelNoteElim.TabIndex = 13
        Me.LabelNoteElim.Text = "Notes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "éliminatoires"
        '
        'LabelSection
        '
        Me.LabelSection.AutoSize = True
        Me.LabelSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelSection.Location = New System.Drawing.Point(572, 12)
        Me.LabelSection.Name = "LabelSection"
        Me.LabelSection.Size = New System.Drawing.Size(55, 15)
        Me.LabelSection.TabIndex = 14
        Me.LabelSection.Text = "Section"
        '
        'LabelGroupe
        '
        Me.LabelGroupe.AutoSize = True
        Me.LabelGroupe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGroupe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelGroupe.Location = New System.Drawing.Point(506, 12)
        Me.LabelGroupe.Name = "LabelGroupe"
        Me.LabelGroupe.Size = New System.Drawing.Size(54, 15)
        Me.LabelGroupe.TabIndex = 15
        Me.LabelGroupe.Text = "Groupe"
        '
        'LabelMention
        '
        Me.LabelMention.AutoSize = True
        Me.LabelMention.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMention.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelMention.Location = New System.Drawing.Point(731, 13)
        Me.LabelMention.Name = "LabelMention"
        Me.LabelMention.Size = New System.Drawing.Size(46, 12)
        Me.LabelMention.TabIndex = 16
        Me.LabelMention.Text = "Mention"
        '
        'LabelAnneSco
        '
        Me.LabelAnneSco.AutoSize = True
        Me.LabelAnneSco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnneSco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelAnneSco.Location = New System.Drawing.Point(484, 7)
        Me.LabelAnneSco.Name = "LabelAnneSco"
        Me.LabelAnneSco.Size = New System.Drawing.Size(14, 13)
        Me.LabelAnneSco.TabIndex = 17
        Me.LabelAnneSco.Text = "1"
        Me.LabelAnneSco.Visible = False
        '
        'ButtonImpression
        '
        Me.ButtonImpression.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ButtonImpression.BackgroundImage = CType(resources.GetObject("ButtonImpression.BackgroundImage"), System.Drawing.Image)
        Me.ButtonImpression.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonImpression.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImpression.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImpression.Location = New System.Drawing.Point(925, 0)
        Me.ButtonImpression.Name = "ButtonImpression"
        Me.ButtonImpression.Size = New System.Drawing.Size(36, 37)
        Me.ButtonImpression.TabIndex = 18
        Me.ButtonImpression.Text = "+"
        Me.ButtonImpression.UseVisualStyleBackColor = False
        '
        'UserControl3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.ButtonImpression)
        Me.Controls.Add(Me.LabelAnneSco)
        Me.Controls.Add(Me.LabelMention)
        Me.Controls.Add(Me.LabelGroupe)
        Me.Controls.Add(Me.LabelSection)
        Me.Controls.Add(Me.LabelNoteElim)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelAnneeNum)
        Me.Controls.Add(Me.LabelAnnEtu)
        Me.Controls.Add(Me.LabelRes)
        Me.Controls.Add(Me.LabelAnnUniv)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "UserControl3"
        Me.Size = New System.Drawing.Size(960, 37)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LabelAnnUniv As System.Windows.Forms.Label
    Friend WithEvents LabelRes As System.Windows.Forms.Label
    Friend WithEvents LabelAnnEtu As System.Windows.Forms.Label
    Friend WithEvents LabelAnneeNum As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape7 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape8 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LabelNoteElim As System.Windows.Forms.Label
    Friend WithEvents LabelSection As System.Windows.Forms.Label
    Friend WithEvents LabelGroupe As System.Windows.Forms.Label
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LabelMention As System.Windows.Forms.Label
    Friend WithEvents LabelAnneSco As System.Windows.Forms.Label
    Friend WithEvents ButtonImpression As System.Windows.Forms.Button

End Class
