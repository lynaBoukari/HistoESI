<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl4
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
        Me.LabelMatiere = New System.Windows.Forms.Label()
        Me.LabelCoef = New System.Windows.Forms.Label()
        Me.LabelMoyJuin = New System.Windows.Forms.Label()
        Me.LabelMoyRattr = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LabelNoteElim = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelMatiere
        '
        Me.LabelMatiere.AutoSize = True
        Me.LabelMatiere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMatiere.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelMatiere.Location = New System.Drawing.Point(0, 8)
        Me.LabelMatiere.Name = "LabelMatiere"
        Me.LabelMatiere.Size = New System.Drawing.Size(55, 13)
        Me.LabelMatiere.TabIndex = 9
        Me.LabelMatiere.Text = "MATIERE"
        '
        'LabelCoef
        '
        Me.LabelCoef.AutoSize = True
        Me.LabelCoef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelCoef.Location = New System.Drawing.Point(269, 6)
        Me.LabelCoef.Name = "LabelCoef"
        Me.LabelCoef.Size = New System.Drawing.Size(43, 15)
        Me.LabelCoef.TabIndex = 10
        Me.LabelCoef.Text = "COEF"
        '
        'LabelMoyJuin
        '
        Me.LabelMoyJuin.AutoSize = True
        Me.LabelMoyJuin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMoyJuin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelMoyJuin.Location = New System.Drawing.Point(355, 5)
        Me.LabelMoyJuin.Name = "LabelMoyJuin"
        Me.LabelMoyJuin.Size = New System.Drawing.Size(62, 26)
        Me.LabelMoyJuin.TabIndex = 11
        Me.LabelMoyJuin.Text = "Moyenne " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   JUIN"
        '
        'LabelMoyRattr
        '
        Me.LabelMoyRattr.AutoSize = True
        Me.LabelMoyRattr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMoyRattr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelMoyRattr.Location = New System.Drawing.Point(447, 5)
        Me.LabelMoyRattr.Name = "LabelMoyRattr"
        Me.LabelMoyRattr.Size = New System.Drawing.Size(62, 26)
        Me.LabelMoyRattr.TabIndex = 12
        Me.LabelMoyRattr.Text = "Moyenne " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  RATTR"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LabelNoteElim)
        Me.Panel3.Controls.Add(Me.LabelMoyRattr)
        Me.Panel3.Controls.Add(Me.LabelMoyJuin)
        Me.Panel3.Controls.Add(Me.LabelCoef)
        Me.Panel3.Controls.Add(Me.LabelMatiere)
        Me.Panel3.Controls.Add(Me.ShapeContainer2)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(596, 32)
        Me.Panel3.TabIndex = 1
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1, Me.LineShape5, Me.LineShape4, Me.LineShape3})
        Me.ShapeContainer2.Size = New System.Drawing.Size(594, 30)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 528
        Me.LineShape1.X2 = 528
        Me.LineShape1.Y1 = 0
        Me.LineShape1.Y2 = 35
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 437
        Me.LineShape5.X2 = 437
        Me.LineShape5.Y1 = -1
        Me.LineShape5.Y2 = 34
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 344
        Me.LineShape4.X2 = 344
        Me.LineShape4.Y1 = 1
        Me.LineShape4.Y2 = 36
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 252
        Me.LineShape3.X2 = 252
        Me.LineShape3.Y1 = -3
        Me.LineShape3.Y2 = 32
        '
        'LabelNoteElim
        '
        Me.LabelNoteElim.AutoSize = True
        Me.LabelNoteElim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoteElim.ForeColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LabelNoteElim.Location = New System.Drawing.Point(533, 6)
        Me.LabelNoteElim.Name = "LabelNoteElim"
        Me.LabelNoteElim.Size = New System.Drawing.Size(46, 15)
        Me.LabelNoteElim.TabIndex = 13
        Me.LabelNoteElim.Text = "NElim"
        '
        'UserControl4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel3)
        Me.Name = "UserControl4"
        Me.Size = New System.Drawing.Size(596, 34)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelMatiere As System.Windows.Forms.Label
    Friend WithEvents LabelCoef As System.Windows.Forms.Label
    Friend WithEvents LabelMoyJuin As System.Windows.Forms.Label
    Friend WithEvents LabelMoyRattr As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelNoteElim As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape

End Class
