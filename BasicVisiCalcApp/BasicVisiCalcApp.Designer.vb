<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasicVisiCalcApp
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
        Me.gBoxCurrCell = New System.Windows.Forms.GroupBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.gBoxShortCuts = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gBoxTable = New System.Windows.Forms.GroupBox()
        Me.dbGridTable = New System.Windows.Forms.DataGridView()
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.B = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.G = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.editMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyRangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteRangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.InsertRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcludeRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcludeColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gBoxCurrCell.SuspendLayout()
        Me.gBoxShortCuts.SuspendLayout()
        Me.gBoxTable.SuspendLayout()
        CType(Me.dbGridTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxCurrCell
        '
        Me.gBoxCurrCell.Controls.Add(Me.btnUpdate)
        Me.gBoxCurrCell.Controls.Add(Me.t3)
        Me.gBoxCurrCell.Controls.Add(Me.t2)
        Me.gBoxCurrCell.Controls.Add(Me.t1)
        Me.gBoxCurrCell.Location = New System.Drawing.Point(12, 27)
        Me.gBoxCurrCell.Name = "gBoxCurrCell"
        Me.gBoxCurrCell.Size = New System.Drawing.Size(339, 55)
        Me.gBoxCurrCell.TabIndex = 0
        Me.gBoxCurrCell.TabStop = False
        Me.gBoxCurrCell.Text = "[Cell]            [Value]                   [Formula/Text]"
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUpdate.Location = New System.Drawing.Point(279, 13)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(54, 36)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        't3
        '
        Me.t3.Location = New System.Drawing.Point(133, 19)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(140, 20)
        Me.t3.TabIndex = 2
        '
        't2
        '
        Me.t2.Location = New System.Drawing.Point(53, 19)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(74, 20)
        Me.t2.TabIndex = 1
        '
        't1
        '
        Me.t1.Location = New System.Drawing.Point(6, 19)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(41, 20)
        Me.t1.TabIndex = 0
        '
        'gBoxShortCuts
        '
        Me.gBoxShortCuts.Controls.Add(Me.btnExit)
        Me.gBoxShortCuts.Controls.Add(Me.btnEdit)
        Me.gBoxShortCuts.Controls.Add(Me.btnHelp)
        Me.gBoxShortCuts.Controls.Add(Me.btnNew)
        Me.gBoxShortCuts.Controls.Add(Me.btnSave)
        Me.gBoxShortCuts.Location = New System.Drawing.Point(357, 27)
        Me.gBoxShortCuts.Name = "gBoxShortCuts"
        Me.gBoxShortCuts.Size = New System.Drawing.Size(211, 55)
        Me.gBoxShortCuts.TabIndex = 1
        Me.gBoxShortCuts.TabStop = False
        Me.gBoxShortCuts.Text = "Shortcuts"
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnExit.Location = New System.Drawing.Point(163, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(40, 36)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.Location = New System.Drawing.Point(123, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(40, 36)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHelp.Location = New System.Drawing.Point(83, 16)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 36)
        Me.btnHelp.TabIndex = 0
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNew.Location = New System.Drawing.Point(43, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(40, 36)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(40, 36)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gBoxTable
        '
        Me.gBoxTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxTable.Controls.Add(Me.dbGridTable)
        Me.gBoxTable.Location = New System.Drawing.Point(12, 88)
        Me.gBoxTable.Name = "gBoxTable"
        Me.gBoxTable.Size = New System.Drawing.Size(559, 394)
        Me.gBoxTable.TabIndex = 2
        Me.gBoxTable.TabStop = False
        '
        'dbGridTable
        '
        Me.dbGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dbGridTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.A, Me.B, Me.C, Me.D, Me.E, Me.F, Me.G})
        Me.dbGridTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dbGridTable.Location = New System.Drawing.Point(3, 16)
        Me.dbGridTable.Name = "dbGridTable"
        Me.dbGridTable.RowHeadersWidth = 50
        Me.dbGridTable.Size = New System.Drawing.Size(553, 375)
        Me.dbGridTable.TabIndex = 0
        '
        'A
        '
        Me.A.HeaderText = "A"
        Me.A.Name = "A"
        '
        'B
        '
        Me.B.HeaderText = "B"
        Me.B.Name = "B"
        '
        'C
        '
        Me.C.HeaderText = "C"
        Me.C.Name = "C"
        '
        'D
        '
        Me.D.HeaderText = "D"
        Me.D.Name = "D"
        '
        'E
        '
        Me.E.HeaderText = "E"
        Me.E.Name = "E"
        '
        'F
        '
        Me.F.HeaderText = "F"
        Me.F.Name = "F"
        '
        'G
        '
        Me.G.HeaderText = "G"
        Me.G.Name = "G"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenu, Me.editMenu, Me.helpMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(583, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileMenu
        '
        Me.fileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFileToolStripMenuItem, Me.OpenFileToolStripMenuItem, Me.SaveFileToolStripMenuItem, Me.SaveFileAsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.fileMenu.Name = "fileMenu"
        Me.fileMenu.Size = New System.Drawing.Size(37, 20)
        Me.fileMenu.Text = "&File"
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.NewFileToolStripMenuItem.Text = "&New File"
        '
        'OpenFileToolStripMenuItem
        '
        Me.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem"
        Me.OpenFileToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OpenFileToolStripMenuItem.Text = "&Open File"
        '
        'SaveFileToolStripMenuItem
        '
        Me.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem"
        Me.SaveFileToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SaveFileToolStripMenuItem.Text = "&Save File"
        '
        'SaveFileAsToolStripMenuItem
        '
        Me.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem"
        Me.SaveFileAsToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SaveFileAsToolStripMenuItem.Text = "Save File &As"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'editMenu
        '
        Me.editMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ToolStripSeparator2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2, Me.CopyRangeToolStripMenuItem, Me.ToolStripMenuItem5, Me.DeleteRangeToolStripMenuItem, Me.ToolStripSeparator1, Me.InsertRowToolStripMenuItem, Me.InsertColumnToolStripMenuItem, Me.DeleteRowsToolStripMenuItem, Me.DeleteColumnsToolStripMenuItem, Me.ExcludeRowsToolStripMenuItem, Me.ExcludeColumnsToolStripMenuItem})
        Me.editMenu.Name = "editMenu"
        Me.editMenu.Size = New System.Drawing.Size(39, 20)
        Me.editMenu.Text = "&Edit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem1.Text = "&Edit Cell"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem4.Text = "&View Cell"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(198, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem3.Text = "&Format Range"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem2.Text = "&Delete Range"
        '
        'CopyRangeToolStripMenuItem
        '
        Me.CopyRangeToolStripMenuItem.Name = "CopyRangeToolStripMenuItem"
        Me.CopyRangeToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CopyRangeToolStripMenuItem.Text = "Co&py Range"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem5.Text = "Resize Columns"
        '
        'DeleteRangeToolStripMenuItem
        '
        Me.DeleteRangeToolStripMenuItem.Name = "DeleteRangeToolStripMenuItem"
        Me.DeleteRangeToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DeleteRangeToolStripMenuItem.Text = "&Hide/Unhide Rows/Cols"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(198, 6)
        '
        'InsertRowToolStripMenuItem
        '
        Me.InsertRowToolStripMenuItem.Name = "InsertRowToolStripMenuItem"
        Me.InsertRowToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.InsertRowToolStripMenuItem.Text = "&Insert Row"
        '
        'InsertColumnToolStripMenuItem
        '
        Me.InsertColumnToolStripMenuItem.Name = "InsertColumnToolStripMenuItem"
        Me.InsertColumnToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.InsertColumnToolStripMenuItem.Text = "I&nsert Column"
        '
        'DeleteRowsToolStripMenuItem
        '
        Me.DeleteRowsToolStripMenuItem.Name = "DeleteRowsToolStripMenuItem"
        Me.DeleteRowsToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DeleteRowsToolStripMenuItem.Text = "Delete &Row(s)"
        '
        'DeleteColumnsToolStripMenuItem
        '
        Me.DeleteColumnsToolStripMenuItem.Name = "DeleteColumnsToolStripMenuItem"
        Me.DeleteColumnsToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DeleteColumnsToolStripMenuItem.Text = "Delete &Column(s)"
        '
        'ExcludeRowsToolStripMenuItem
        '
        Me.ExcludeRowsToolStripMenuItem.Name = "ExcludeRowsToolStripMenuItem"
        Me.ExcludeRowsToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ExcludeRowsToolStripMenuItem.Text = "E&xclude Row(s)"
        '
        'ExcludeColumnsToolStripMenuItem
        '
        Me.ExcludeColumnsToolStripMenuItem.Name = "ExcludeColumnsToolStripMenuItem"
        Me.ExcludeColumnsToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ExcludeColumnsToolStripMenuItem.Text = "Exc&lude Column(s)"
        '
        'helpMenu
        '
        Me.helpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHelpToolStripMenuItem, Me.FunctionsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.helpMenu.Name = "helpMenu"
        Me.helpMenu.Size = New System.Drawing.Size(44, 20)
        Me.helpMenu.Text = "Help"
        '
        'ShowHelpToolStripMenuItem
        '
        Me.ShowHelpToolStripMenuItem.Name = "ShowHelpToolStripMenuItem"
        Me.ShowHelpToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ShowHelpToolStripMenuItem.Text = "Show &Help"
        '
        'FunctionsToolStripMenuItem
        '
        Me.FunctionsToolStripMenuItem.Name = "FunctionsToolStripMenuItem"
        Me.FunctionsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.FunctionsToolStripMenuItem.Text = "&Functions"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 494)
        Me.Controls.Add(Me.gBoxTable)
        Me.Controls.Add(Me.gBoxShortCuts)
        Me.Controls.Add(Me.gBoxCurrCell)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form4"
        Me.Text = "Basic Visicalc Spreadsheet"
        Me.gBoxCurrCell.ResumeLayout(False)
        Me.gBoxCurrCell.PerformLayout()
        Me.gBoxShortCuts.ResumeLayout(False)
        Me.gBoxTable.ResumeLayout(False)
        CType(Me.dbGridTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxCurrCell As System.Windows.Forms.GroupBox
    Friend WithEvents t3 As System.Windows.Forms.TextBox
    Friend WithEvents t2 As System.Windows.Forms.TextBox
    Friend WithEvents t1 As System.Windows.Forms.TextBox
    Friend WithEvents gBoxShortCuts As System.Windows.Forms.GroupBox
    Friend WithEvents gBoxTable As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dbGridTable As System.Windows.Forms.DataGridView
    Friend WithEvents A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents G As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents editMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteRowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcludeRowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcludeColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyRangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteRangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents helpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunctionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
End Class
