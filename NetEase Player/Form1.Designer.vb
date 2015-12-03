<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btn_searchQuery = New System.Windows.Forms.Button()
        Me.lvw_Songs = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txt_searchQuery = New System.Windows.Forms.TextBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lb_playlist = New System.Windows.Forms.ListBox()
        Me.chb_dl = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btn_dlsong = New System.Windows.Forms.Button()
        Me.nup_limit = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_dlplay = New System.Windows.Forms.Button()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nup_limit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_searchQuery
        '
        Me.btn_searchQuery.Location = New System.Drawing.Point(230, 12)
        Me.btn_searchQuery.Name = "btn_searchQuery"
        Me.btn_searchQuery.Size = New System.Drawing.Size(72, 20)
        Me.btn_searchQuery.TabIndex = 0
        Me.btn_searchQuery.Text = "suchen"
        Me.btn_searchQuery.UseVisualStyleBackColor = True
        '
        'lvw_Songs
        '
        Me.lvw_Songs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvw_Songs.FullRowSelect = True
        Me.lvw_Songs.Location = New System.Drawing.Point(12, 38)
        Me.lvw_Songs.MultiSelect = False
        Me.lvw_Songs.Name = "lvw_Songs"
        Me.lvw_Songs.Size = New System.Drawing.Size(619, 374)
        Me.lvw_Songs.TabIndex = 4
        Me.lvw_Songs.UseCompatibleStateImageBehavior = False
        Me.lvw_Songs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Titel"
        Me.ColumnHeader1.Width = 207
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Interpret"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Album"
        Me.ColumnHeader3.Width = 229
        '
        'txt_searchQuery
        '
        Me.txt_searchQuery.Location = New System.Drawing.Point(57, 12)
        Me.txt_searchQuery.Name = "txt_searchQuery"
        Me.txt_searchQuery.Size = New System.Drawing.Size(167, 20)
        Me.txt_searchQuery.TabIndex = 5
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 445)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(802, 45)
        Me.AxWindowsMediaPlayer1.TabIndex = 3
        '
        'lb_playlist
        '
        Me.lb_playlist.FormattingEnabled = True
        Me.lb_playlist.Location = New System.Drawing.Point(637, 82)
        Me.lb_playlist.Name = "lb_playlist"
        Me.lb_playlist.Size = New System.Drawing.Size(139, 303)
        Me.lb_playlist.TabIndex = 6
        '
        'chb_dl
        '
        Me.chb_dl.AutoSize = True
        Me.chb_dl.Checked = True
        Me.chb_dl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_dl.Location = New System.Drawing.Point(637, 59)
        Me.chb_dl.Name = "chb_dl"
        Me.chb_dl.Size = New System.Drawing.Size(122, 17)
        Me.chb_dl.TabIndex = 8
        Me.chb_dl.Text = "320kbit/s Download"
        Me.chb_dl.UseVisualStyleBackColor = True
        '
        'btn_dlsong
        '
        Me.btn_dlsong.Location = New System.Drawing.Point(12, 418)
        Me.btn_dlsong.Name = "btn_dlsong"
        Me.btn_dlsong.Size = New System.Drawing.Size(75, 23)
        Me.btn_dlsong.TabIndex = 9
        Me.btn_dlsong.Text = "Download"
        Me.btn_dlsong.UseVisualStyleBackColor = True
        '
        'nup_limit
        '
        Me.nup_limit.Location = New System.Drawing.Point(382, 12)
        Me.nup_limit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nup_limit.Name = "nup_limit"
        Me.nup_limit.Size = New System.Drawing.Size(94, 20)
        Me.nup_limit.TabIndex = 10
        Me.nup_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nup_limit.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(345, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Limit:"
        '
        'btn_dlplay
        '
        Me.btn_dlplay.Location = New System.Drawing.Point(93, 418)
        Me.btn_dlplay.Name = "btn_dlplay"
        Me.btn_dlplay.Size = New System.Drawing.Size(131, 23)
        Me.btn_dlplay.TabIndex = 12
        Me.btn_dlplay.Text = "Download + Playlist"
        Me.btn_dlplay.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btn_searchQuery
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 490)
        Me.Controls.Add(Me.btn_dlplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nup_limit)
        Me.Controls.Add(Me.btn_dlsong)
        Me.Controls.Add(Me.chb_dl)
        Me.Controls.Add(Me.lb_playlist)
        Me.Controls.Add(Me.txt_searchQuery)
        Me.Controls.Add(Me.lvw_Songs)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.btn_searchQuery)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetEase Player"
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nup_limit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_searchQuery As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents lvw_Songs As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents txt_searchQuery As TextBox
    Friend WithEvents lb_playlist As ListBox
    Friend WithEvents chb_dl As CheckBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents btn_dlsong As Button
    Friend WithEvents nup_limit As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_dlplay As Button
End Class
