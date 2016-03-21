<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btn_searchQuery = New System.Windows.Forms.Button()
        Me.lvw_Songs = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txt_searchQuery = New System.Windows.Forms.TextBox()
        Me.lb_playlist = New System.Windows.Forms.ListBox()
        Me.chb_dl = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btn_dlsong = New System.Windows.Forms.Button()
        Me.nup_limit = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_dlplay = New System.Windows.Forms.Button()
        Me.lbl_position = New System.Windows.Forms.Label()
        Me.timer_position = New System.Windows.Forms.Timer(Me.components)
        Me.btn_delfromplaylist = New System.Windows.Forms.Button()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.btn_exportfromplaylist = New System.Windows.Forms.Button()
        Me.btn_dlrepair = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_video = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_artist = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_album = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_infoduration = New System.Windows.Forms.Label()
        Me.lbl_infodownload = New System.Windows.Forms.Label()
        Me.lbl_infosize = New System.Windows.Forms.Label()
        Me.lbl_infobitrate = New System.Windows.Forms.Label()
        Me.lbl_infoffline = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.combo_playlist = New System.Windows.Forms.ComboBox()
        Me.btn_loadplaylist = New System.Windows.Forms.Button()
        Me.txt_addplaylist = New System.Windows.Forms.TextBox()
        Me.btn_addplaylist = New System.Windows.Forms.Button()
        Me.chb_miniplayerifminized = New System.Windows.Forms.CheckBox()
        Me.btn_readdfromcache = New System.Windows.Forms.Button()
        Me.chb_useproxy = New System.Windows.Forms.CheckBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.chb_repeatplaylist = New System.Windows.Forms.CheckBox()
        CType(Me.nup_limit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_searchQuery
        '
        Me.btn_searchQuery.Location = New System.Drawing.Point(185, 14)
        Me.btn_searchQuery.Name = "btn_searchQuery"
        Me.btn_searchQuery.Size = New System.Drawing.Size(61, 20)
        Me.btn_searchQuery.TabIndex = 0
        Me.btn_searchQuery.Text = "search"
        Me.btn_searchQuery.UseVisualStyleBackColor = True
        '
        'lvw_Songs
        '
        Me.lvw_Songs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvw_Songs.FullRowSelect = True
        Me.lvw_Songs.Location = New System.Drawing.Point(12, 38)
        Me.lvw_Songs.MultiSelect = False
        Me.lvw_Songs.Name = "lvw_Songs"
        Me.lvw_Songs.Size = New System.Drawing.Size(619, 492)
        Me.lvw_Songs.TabIndex = 4
        Me.lvw_Songs.UseCompatibleStateImageBehavior = False
        Me.lvw_Songs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Title"
        Me.ColumnHeader1.Width = 193
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artist"
        Me.ColumnHeader2.Width = 121
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Album"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Duration"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Quality"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "MV"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_searchQuery
        '
        Me.txt_searchQuery.Location = New System.Drawing.Point(12, 14)
        Me.txt_searchQuery.Name = "txt_searchQuery"
        Me.txt_searchQuery.Size = New System.Drawing.Size(167, 20)
        Me.txt_searchQuery.TabIndex = 5
        '
        'lb_playlist
        '
        Me.lb_playlist.FormattingEnabled = True
        Me.lb_playlist.Location = New System.Drawing.Point(637, 70)
        Me.lb_playlist.Name = "lb_playlist"
        Me.lb_playlist.Size = New System.Drawing.Size(159, 264)
        Me.lb_playlist.TabIndex = 6
        '
        'chb_dl
        '
        Me.chb_dl.AutoSize = True
        Me.chb_dl.Checked = True
        Me.chb_dl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_dl.Location = New System.Drawing.Point(558, 18)
        Me.chb_dl.Name = "chb_dl"
        Me.chb_dl.Size = New System.Drawing.Size(74, 17)
        Me.chb_dl.TabIndex = 8
        Me.chb_dl.Text = "Download"
        Me.chb_dl.UseVisualStyleBackColor = True
        '
        'btn_dlsong
        '
        Me.btn_dlsong.Location = New System.Drawing.Point(12, 536)
        Me.btn_dlsong.Name = "btn_dlsong"
        Me.btn_dlsong.Size = New System.Drawing.Size(75, 23)
        Me.btn_dlsong.TabIndex = 9
        Me.btn_dlsong.Text = "Download"
        Me.btn_dlsong.UseVisualStyleBackColor = True
        '
        'nup_limit
        '
        Me.nup_limit.Location = New System.Drawing.Point(395, 15)
        Me.nup_limit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nup_limit.Name = "nup_limit"
        Me.nup_limit.Size = New System.Drawing.Size(68, 20)
        Me.nup_limit.TabIndex = 10
        Me.nup_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nup_limit.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Limit:"
        '
        'btn_dlplay
        '
        Me.btn_dlplay.Location = New System.Drawing.Point(93, 536)
        Me.btn_dlplay.Name = "btn_dlplay"
        Me.btn_dlplay.Size = New System.Drawing.Size(131, 23)
        Me.btn_dlplay.TabIndex = 12
        Me.btn_dlplay.Text = "Download + Playlist"
        Me.btn_dlplay.UseVisualStyleBackColor = True
        '
        'lbl_position
        '
        Me.lbl_position.AutoSize = True
        Me.lbl_position.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_position.Location = New System.Drawing.Point(16, 596)
        Me.lbl_position.Name = "lbl_position"
        Me.lbl_position.Size = New System.Drawing.Size(106, 16)
        Me.lbl_position.TabIndex = 13
        Me.lbl_position.Text = "--:-- - --:-- - --:--"
        '
        'timer_position
        '
        Me.timer_position.Enabled = True
        Me.timer_position.Interval = 1000
        '
        'btn_delfromplaylist
        '
        Me.btn_delfromplaylist.Enabled = False
        Me.btn_delfromplaylist.Location = New System.Drawing.Point(6, 16)
        Me.btn_delfromplaylist.Name = "btn_delfromplaylist"
        Me.btn_delfromplaylist.Size = New System.Drawing.Size(65, 23)
        Me.btn_delfromplaylist.TabIndex = 14
        Me.btn_delfromplaylist.Text = "delete"
        Me.btn_delfromplaylist.UseVisualStyleBackColor = True
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Location = New System.Drawing.Point(252, 19)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(23, 13)
        Me.lbl_status.TabIndex = 16
        Me.lbl_status.Text = "idle"
        '
        'btn_exportfromplaylist
        '
        Me.btn_exportfromplaylist.Enabled = False
        Me.btn_exportfromplaylist.Location = New System.Drawing.Point(88, 16)
        Me.btn_exportfromplaylist.Name = "btn_exportfromplaylist"
        Me.btn_exportfromplaylist.Size = New System.Drawing.Size(65, 23)
        Me.btn_exportfromplaylist.TabIndex = 17
        Me.btn_exportfromplaylist.Text = "export"
        Me.btn_exportfromplaylist.UseVisualStyleBackColor = True
        '
        'btn_dlrepair
        '
        Me.btn_dlrepair.Enabled = False
        Me.btn_dlrepair.Location = New System.Drawing.Point(88, 42)
        Me.btn_dlrepair.Name = "btn_dlrepair"
        Me.btn_dlrepair.Size = New System.Drawing.Size(65, 23)
        Me.btn_dlrepair.TabIndex = 18
        Me.btn_dlrepair.Text = "repair"
        Me.btn_dlrepair.UseMnemonic = False
        Me.btn_dlrepair.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_video)
        Me.GroupBox1.Controls.Add(Me.btn_dlrepair)
        Me.GroupBox1.Controls.Add(Me.btn_delfromplaylist)
        Me.GroupBox1.Controls.Add(Me.btn_exportfromplaylist)
        Me.GroupBox1.Location = New System.Drawing.Point(637, 459)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 71)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Optionen"
        '
        'btn_video
        '
        Me.btn_video.Enabled = False
        Me.btn_video.Location = New System.Drawing.Point(6, 42)
        Me.btn_video.Name = "btn_video"
        Me.btn_video.Size = New System.Drawing.Size(65, 23)
        Me.btn_video.TabIndex = 24
        Me.btn_video.Text = "Video"
        Me.btn_video.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_title)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_artist)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_album)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 566)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(784, 27)
        Me.FlowLayoutPanel1.TabIndex = 20
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbl_title.Location = New System.Drawing.Point(3, 0)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(45, 24)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Title"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(54, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = " - "
        '
        'lbl_artist
        '
        Me.lbl_artist.AutoSize = True
        Me.lbl_artist.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbl_artist.Location = New System.Drawing.Point(86, 0)
        Me.lbl_artist.Name = "lbl_artist"
        Me.lbl_artist.Size = New System.Drawing.Size(50, 24)
        Me.lbl_artist.TabIndex = 2
        Me.lbl_artist.Text = "Artist"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(142, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " - "
        '
        'lbl_album
        '
        Me.lbl_album.AutoSize = True
        Me.lbl_album.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lbl_album.Location = New System.Drawing.Point(174, 0)
        Me.lbl_album.Name = "lbl_album"
        Me.lbl_album.Size = New System.Drawing.Size(65, 24)
        Me.lbl_album.TabIndex = 4
        Me.lbl_album.Text = "Album"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(185, 595)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 19)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_infoduration)
        Me.GroupBox2.Controls.Add(Me.lbl_infodownload)
        Me.GroupBox2.Controls.Add(Me.lbl_infosize)
        Me.GroupBox2.Controls.Add(Me.lbl_infobitrate)
        Me.GroupBox2.Controls.Add(Me.lbl_infoffline)
        Me.GroupBox2.Location = New System.Drawing.Point(637, 358)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(159, 95)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information"
        '
        'lbl_infoduration
        '
        Me.lbl_infoduration.AutoSize = True
        Me.lbl_infoduration.Location = New System.Drawing.Point(6, 68)
        Me.lbl_infoduration.Name = "lbl_infoduration"
        Me.lbl_infoduration.Size = New System.Drawing.Size(10, 13)
        Me.lbl_infoduration.TabIndex = 4
        Me.lbl_infoduration.Text = " "
        '
        'lbl_infodownload
        '
        Me.lbl_infodownload.AutoSize = True
        Me.lbl_infodownload.Location = New System.Drawing.Point(6, 55)
        Me.lbl_infodownload.Name = "lbl_infodownload"
        Me.lbl_infodownload.Size = New System.Drawing.Size(10, 13)
        Me.lbl_infodownload.TabIndex = 3
        Me.lbl_infodownload.Text = " "
        '
        'lbl_infosize
        '
        Me.lbl_infosize.AutoSize = True
        Me.lbl_infosize.Location = New System.Drawing.Point(6, 42)
        Me.lbl_infosize.Name = "lbl_infosize"
        Me.lbl_infosize.Size = New System.Drawing.Size(10, 13)
        Me.lbl_infosize.TabIndex = 2
        Me.lbl_infosize.Text = " "
        '
        'lbl_infobitrate
        '
        Me.lbl_infobitrate.AutoSize = True
        Me.lbl_infobitrate.Location = New System.Drawing.Point(6, 29)
        Me.lbl_infobitrate.Name = "lbl_infobitrate"
        Me.lbl_infobitrate.Size = New System.Drawing.Size(10, 13)
        Me.lbl_infobitrate.TabIndex = 1
        Me.lbl_infobitrate.Text = " "
        '
        'lbl_infoffline
        '
        Me.lbl_infoffline.AutoSize = True
        Me.lbl_infoffline.Location = New System.Drawing.Point(6, 16)
        Me.lbl_infoffline.Name = "lbl_infoffline"
        Me.lbl_infoffline.Size = New System.Drawing.Size(10, 13)
        Me.lbl_infoffline.TabIndex = 0
        Me.lbl_infoffline.Text = " "
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(590, 608)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "made with ♥"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(255, 536)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Spotify Ripper"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'combo_playlist
        '
        Me.combo_playlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_playlist.FormattingEnabled = True
        Me.combo_playlist.Location = New System.Drawing.Point(637, 43)
        Me.combo_playlist.Name = "combo_playlist"
        Me.combo_playlist.Size = New System.Drawing.Size(125, 21)
        Me.combo_playlist.TabIndex = 25
        '
        'btn_loadplaylist
        '
        Me.btn_loadplaylist.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_loadplaylist.Location = New System.Drawing.Point(768, 42)
        Me.btn_loadplaylist.Name = "btn_loadplaylist"
        Me.btn_loadplaylist.Size = New System.Drawing.Size(28, 23)
        Me.btn_loadplaylist.TabIndex = 26
        Me.btn_loadplaylist.Text = "✔"
        Me.btn_loadplaylist.UseVisualStyleBackColor = True
        '
        'txt_addplaylist
        '
        Me.txt_addplaylist.Location = New System.Drawing.Point(637, 19)
        Me.txt_addplaylist.Name = "txt_addplaylist"
        Me.txt_addplaylist.Size = New System.Drawing.Size(125, 20)
        Me.txt_addplaylist.TabIndex = 27
        '
        'btn_addplaylist
        '
        Me.btn_addplaylist.Enabled = False
        Me.btn_addplaylist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_addplaylist.Location = New System.Drawing.Point(768, 17)
        Me.btn_addplaylist.Name = "btn_addplaylist"
        Me.btn_addplaylist.Size = New System.Drawing.Size(28, 23)
        Me.btn_addplaylist.TabIndex = 28
        Me.btn_addplaylist.Text = "+"
        Me.btn_addplaylist.UseVisualStyleBackColor = True
        '
        'chb_miniplayerifminized
        '
        Me.chb_miniplayerifminized.AutoSize = True
        Me.chb_miniplayerifminized.Checked = True
        Me.chb_miniplayerifminized.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_miniplayerifminized.Location = New System.Drawing.Point(478, 18)
        Me.chb_miniplayerifminized.Name = "chb_miniplayerifminized"
        Me.chb_miniplayerifminized.Size = New System.Drawing.Size(74, 17)
        Me.chb_miniplayerifminized.TabIndex = 29
        Me.chb_miniplayerifminized.Text = "MiniPlayer"
        Me.chb_miniplayerifminized.UseVisualStyleBackColor = True
        '
        'btn_readdfromcache
        '
        Me.btn_readdfromcache.Location = New System.Drawing.Point(637, 537)
        Me.btn_readdfromcache.Name = "btn_readdfromcache"
        Me.btn_readdfromcache.Size = New System.Drawing.Size(125, 23)
        Me.btn_readdfromcache.TabIndex = 30
        Me.btn_readdfromcache.Text = "Re-Add from Cache"
        Me.btn_readdfromcache.UseVisualStyleBackColor = True
        '
        'chb_useproxy
        '
        Me.chb_useproxy.AutoSize = True
        Me.chb_useproxy.Checked = True
        Me.chb_useproxy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_useproxy.Location = New System.Drawing.Point(558, 540)
        Me.chb_useproxy.Name = "chb_useproxy"
        Me.chb_useproxy.Size = New System.Drawing.Size(52, 17)
        Me.chb_useproxy.TabIndex = 31
        Me.chb_useproxy.Text = "Proxy"
        Me.chb_useproxy.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 624)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(802, 45)
        Me.AxWindowsMediaPlayer1.TabIndex = 3
        '
        'chb_repeatplaylist
        '
        Me.chb_repeatplaylist.AutoSize = True
        Me.chb_repeatplaylist.Checked = True
        Me.chb_repeatplaylist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_repeatplaylist.Location = New System.Drawing.Point(637, 340)
        Me.chb_repeatplaylist.Name = "chb_repeatplaylist"
        Me.chb_repeatplaylist.Size = New System.Drawing.Size(56, 17)
        Me.chb_repeatplaylist.TabIndex = 32
        Me.chb_repeatplaylist.Text = "repeat"
        Me.chb_repeatplaylist.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btn_searchQuery
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 669)
        Me.Controls.Add(Me.chb_repeatplaylist)
        Me.Controls.Add(Me.chb_useproxy)
        Me.Controls.Add(Me.btn_readdfromcache)
        Me.Controls.Add(Me.chb_miniplayerifminized)
        Me.Controls.Add(Me.btn_addplaylist)
        Me.Controls.Add(Me.txt_addplaylist)
        Me.Controls.Add(Me.btn_loadplaylist)
        Me.Controls.Add(Me.combo_playlist)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.lbl_position)
        Me.Controls.Add(Me.btn_dlplay)
        Me.Controls.Add(Me.Button1)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetEase Player"
        CType(Me.nup_limit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbl_position As Label
    Friend WithEvents timer_position As Timer
    Friend WithEvents btn_delfromplaylist As Button
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents lbl_status As Label
    Friend WithEvents btn_exportfromplaylist As Button
    Friend WithEvents btn_dlrepair As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lbl_title As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_artist As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_album As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_video As Button
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents lbl_infoduration As Label
    Friend WithEvents lbl_infodownload As Label
    Friend WithEvents lbl_infosize As Label
    Friend WithEvents lbl_infobitrate As Label
    Friend WithEvents lbl_infoffline As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents combo_playlist As ComboBox
    Friend WithEvents btn_loadplaylist As Button
    Friend WithEvents txt_addplaylist As TextBox
    Friend WithEvents btn_addplaylist As Button
    Friend WithEvents chb_miniplayerifminized As CheckBox
    Friend WithEvents btn_readdfromcache As Button
    Friend WithEvents chb_useproxy As CheckBox
    Friend WithEvents chb_repeatplaylist As CheckBox
End Class
