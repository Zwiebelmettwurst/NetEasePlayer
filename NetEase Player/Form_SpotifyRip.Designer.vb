<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_SpotifyRip
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SpotifyRip))
        Me.txt_spotifyplaylist = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_spotifyplrip = New System.Windows.Forms.Button()
        Me.lvw_spotify = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_importchecked = New System.Windows.Forms.Button()
        Me.lbl_spotifyuser = New System.Windows.Forms.Label()
        Me.btn_checkuncheckall = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_spotifyplaylist
        '
        Me.txt_spotifyplaylist.Location = New System.Drawing.Point(139, 18)
        Me.txt_spotifyplaylist.Name = "txt_spotifyplaylist"
        Me.txt_spotifyplaylist.Size = New System.Drawing.Size(460, 20)
        Me.txt_spotifyplaylist.TabIndex = 0
        Me.txt_spotifyplaylist.Text = "https://play.spotify.com/user/k3174r0/playlist/7hUhKnkbrFJLefHeKVz3D6"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Spotify Playlist URL:"
        '
        'btn_spotifyplrip
        '
        Me.btn_spotifyplrip.Location = New System.Drawing.Point(605, 16)
        Me.btn_spotifyplrip.Name = "btn_spotifyplrip"
        Me.btn_spotifyplrip.Size = New System.Drawing.Size(75, 23)
        Me.btn_spotifyplrip.TabIndex = 2
        Me.btn_spotifyplrip.Text = "Get Music"
        Me.btn_spotifyplrip.UseVisualStyleBackColor = True
        '
        'lvw_spotify
        '
        Me.lvw_spotify.CheckBoxes = True
        Me.lvw_spotify.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvw_spotify.FullRowSelect = True
        Me.lvw_spotify.Location = New System.Drawing.Point(34, 99)
        Me.lvw_spotify.MultiSelect = False
        Me.lvw_spotify.Name = "lvw_spotify"
        Me.lvw_spotify.Size = New System.Drawing.Size(665, 264)
        Me.lvw_spotify.TabIndex = 3
        Me.lvw_spotify.UseCompatibleStateImageBehavior = False
        Me.lvw_spotify.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Title"
        Me.ColumnHeader1.Width = 198
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artist"
        Me.ColumnHeader2.Width = 179
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Album"
        Me.ColumnHeader3.Width = 176
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Duration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(136, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(375, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Format: https://play|open.spotify.com/user/USERNAME/playlist/PLAYLISTID"
        '
        'btn_importchecked
        '
        Me.btn_importchecked.Enabled = False
        Me.btn_importchecked.Location = New System.Drawing.Point(561, 369)
        Me.btn_importchecked.Name = "btn_importchecked"
        Me.btn_importchecked.Size = New System.Drawing.Size(138, 37)
        Me.btn_importchecked.TabIndex = 5
        Me.btn_importchecked.Text = "Import Tracks"
        Me.btn_importchecked.UseVisualStyleBackColor = True
        '
        'lbl_spotifyuser
        '
        Me.lbl_spotifyuser.AutoSize = True
        Me.lbl_spotifyuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_spotifyuser.Location = New System.Drawing.Point(31, 69)
        Me.lbl_spotifyuser.Name = "lbl_spotifyuser"
        Me.lbl_spotifyuser.Size = New System.Drawing.Size(386, 16)
        Me.lbl_spotifyuser.TabIndex = 6
        Me.lbl_spotifyuser.Text = "Spotify-Account required. Please authenticate this app."
        '
        'btn_checkuncheckall
        '
        Me.btn_checkuncheckall.Enabled = False
        Me.btn_checkuncheckall.Location = New System.Drawing.Point(34, 369)
        Me.btn_checkuncheckall.Name = "btn_checkuncheckall"
        Me.btn_checkuncheckall.Size = New System.Drawing.Size(125, 23)
        Me.btn_checkuncheckall.TabIndex = 7
        Me.btn_checkuncheckall.Text = "check / uncheck all"
        Me.btn_checkuncheckall.UseVisualStyleBackColor = True
        '
        'Form_SpotifyRip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 418)
        Me.Controls.Add(Me.btn_checkuncheckall)
        Me.Controls.Add(Me.lbl_spotifyuser)
        Me.Controls.Add(Me.btn_importchecked)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvw_spotify)
        Me.Controls.Add(Me.btn_spotifyplrip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_spotifyplaylist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_SpotifyRip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Playlist from Spotify"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_spotifyplaylist As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_spotifyplrip As Button
    Friend WithEvents lvw_spotify As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents btn_importchecked As Button
    Friend WithEvents lbl_spotifyuser As Label
    Friend WithEvents btn_checkuncheckall As Button
End Class
