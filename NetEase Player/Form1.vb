Option Strict On

Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json


Imports System.Text.RegularExpressions
Imports AxWMPLib
Imports System.ComponentModel
Imports WMPLib
Imports System.Runtime.InteropServices

Public Class Form1
    Private WithEvents _Hotkey As New Hotkey
    Dim play As WMPLib.IWMPPlaylist
    Dim med As WMPLib.IWMPMedia
    Private cLvwSort As ListViewSort
    Dim cookieCon As New CookieContainer
    Dim request As HttpWebRequest
    Dim getSongInfo As New List(Of SongClass)
    Dim seitenQuelltext As String
    Dim newPlayList As WMPLib.IWMPPlaylist
    Dim myPlaylist As New List(Of mp3Class)
    Dim playlistfile As String = Application.StartupPath & "\playlist\playlist.nep"
    Dim songC As SongClass ' = getSongInfobyID(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag)
    Dim songH As mp3Class ' = songC.gethMusic
    Dim songURL As String '= songC.getSongMP3URL.Replace("m2.", "m5.")
    Dim songName As String '= songC.getSongName
    Dim oldselectedindex As Integer = -1
    Dim playlistcombolist As New List(Of CBPlaylistClass)
    Public Event nextTrack(ByVal nextTrack As mp3Class)

    Dim ips As String() = {"180.97.178.211", "180.97.178.61", "58.220.6.81", "180.97.178.212", "180.97.180.93", "180.97.180.91", "180.97.180.92", "58.220.6.80", "180.97.178.60", "180.97.178.59", "58.220.39.89", "58.220.43.55", "58.220.6.82", "218.64.94.53", "113.17.140.176", "59.108.137.202", "59.108.137.204", "59.108.137.203", "60.207.246.103", "60.207.246.101", "59.108.137.201", "183.136.208.39", "115.231.132.70", "119.84.111.82", "119.84.86.37", "117.23.2.80", "117.23.51.72", "117.23.54.67", "117.23.51.73", "117.23.54.68", "117.23.2.79", "222.216.188.92", "61.138.219.42", "115.231.87.131", "115.231.82.104", "115.231.84.168", "115.231.84.167", "115.231.82.106", "115.231.87.130", "115.231.82.100", "115.231.82.105", "218.93.206.56", "218.93.206.57", "218.75.225.190", "218.75.225.60", "218.75.225.57", "61.134.46.44", "222.246.232.157", "221.229.167.44", "58.218.208.202", "58.218.208.39", "61.136.167.71", "220.165.142.79", "61.136.211.34", "220.169.243.174", "218.92.209.69", "218.92.209.73", "218.92.209.70", "218.92.226.86", "183.134.16.88", "183.134.20.72", "183.134.12.74", "183.134.11.85", "183.134.16.89", "183.134.24.76", "183.134.10.82", "183.134.16.87", "183.134.16.90", "183.134.20.73", "183.134.20.74", "183.134.9.62", "183.134.11.83", "183.134.12.72", "183.134.16.91", "115.153.176.76", "218.76.79.128", "221.235.205.200", "59.45.42.43", "125.91.249.26", "218.77.2.85", "58.221.78.109", "58.221.78.70", "61.188.191.90", "180.97.211.37", "222.186.132.74", "180.97.211.53", "219.149.47.34", "59.44.209.184", "59.47.50.33", "220.162.97.229", "183.131.116.54", "183.131.119.90", "183.131.116.57", "115.231.158.73", "183.131.116.58", "115.231.156.75", "183.131.116.56", "183.131.116.55", "115.231.158.74", "218.242.103.104", "218.242.103.102", "211.144.81.26", "211.144.81.28", "218.242.103.105", "218.242.103.103", "211.144.81.25", "211.144.81.27", "182.40.30.18", "222.218.45.207", "222.218.45.214", "182.140.142.158", "182.140.147.56", "182.140.218.59", "182.140.218.60", "182.140.231.59", "222.84.167.53", "222.84.167.52", "117.21.204.75", "117.21.204.76", "222.243.110.58", "125.90.204.50", "125.90.204.96", "60.174.241.86", "60.174.243.185", "58.222.19.41", "58.222.19.42", "219.138.28.40", "219.138.21.62", "219.138.27.66", "61.183.53.82", "14.215.93.37", "219.128.78.71", "121.9.222.53", "121.9.222.54", "219.145.171.184", "182.132.33.42", "220.167.102.24", "14.215.9.79", "14.215.9.80", "183.61.67.42", "183.61.67.87", "113.107.57.42", "122.228.6.64", "122.228.94.65", "183.131.168.144", "122.228.94.73", "122.228.6.67", "122.228.94.64", "183.131.208.53", "183.131.168.135", "183.131.168.134", "122.228.94.183", "222.170.95.35", "59.56.26.47", "117.27.243.110", "117.27.245.60", "117.27.241.104", "117.27.241.103", "117.27.245.78", "124.116.133.42", "36.42.32.66", "117.21.168.85", "122.225.28.140", "115.231.171.46", "115.231.171.47", "115.231.171.48", "115.231.171.49", "221.235.187.54", "221.235.187.51", "61.184.116.82", "61.184.116.83", "58.51.241.33", "223.151.245.44", "223.151.245.42", "113.107.112.212", "115.231.22.76", "115.231.30.107", "115.231.30.106", "115.231.22.77", "115.231.30.105", "115.231.20.47", "115.231.20.48", "115.231.22.75", "58.216.21.97", "61.160.209.74", "61.160.209.76", "58.216.22.214", "58.216.21.100", "58.216.21.99", "42.81.5.144", "42.81.9.50", "61.184.249.41", "61.184.249.40", "182.34.127.89", "124.161.229.68", "124.161.229.69", "124.161.224.43", "124.161.224.44", "221.206.120.67", "221.206.124.46", "218.60.132.33", "153.36.110.59", "113.207.77.60", "113.207.77.58", "113.207.80.48", "113.207.80.47", "113.207.77.61", "113.207.72.68", "124.167.236.86", "124.167.236.85", "124.167.222.40", "124.167.232.95", "220.194.200.229", "220.194.203.62", "60.5.252.75", "60.5.255.37", "60.5.255.28", "101.26.37.114", "60.5.252.74", "36.250.74.14", "36.250.76.208", "121.17.124.25", "60.220.196.248", "175.154.189.32", "175.154.189.31", "175.154.189.48", "113.5.251.95", "221.208.158.219", "113.5.251.94", "113.5.251.96", "61.167.54.107", "61.167.54.104", "218.59.186.252", "218.59.186.253", "122.143.27.241", "122.143.27.152", "122.143.23.44", "124.165.216.190", "124.165.216.189", "124.165.216.253", "60.222.223.55", "60.222.223.63", "220.194.207.94", "220.194.207.99", "42.48.1.72", "42.48.1.73", "110.53.75.46", "58.20.164.52", "110.53.75.45", "110.53.72.57", "58.20.197.66", "58.20.197.64", "58.20.197.61", "58.20.197.65", "183.95.189.35", "58.20.139.51", "58.20.139.52", "124.95.147.29", "36.250.93.46", "36.250.93.47", "218.58.222.94", "218.58.222.93", "113.5.170.36", "113.5.80.41", "113.5.80.40", "121.18.230.10", "121.18.230.88", "121.18.230.89", "60.8.123.159", "122.136.46.96", "218.60.109.76", "124.164.8.68", "124.164.8.67", "124.164.245.162", "122.143.76.32", "218.26.67.78", "218.26.67.76", "218.26.75.211", "121.22.252.52", "121.22.252.51", "110.18.247.56", "110.18.246.31", "60.221.254.223", "60.221.222.25", "111.1.59.55", "112.17.2.98", "112.17.2.95", "112.17.2.97", "112.17.2.179", "112.17.2.207", "117.144.230.115", "120.192.87.87", "120.209.141.82", "117.172.21.86", "117.172.21.88", "117.172.21.87", "112.25.35.34", "183.207.229.19", "183.207.229.17", "124.14.17.225", "124.14.17.223", "124.14.17.228", "124.14.7.54", "124.14.7.53", "124.14.7.55", "211.162.48.55", "211.162.48.57", "211.162.55.7", "211.162.58.57", "211.162.48.56", "222.42.4.191", "222.42.4.110", "159.226.225.150", "101.100.190.113", "61.200.88.54", "61.200.88.55", "61.90.241.27", "122.155.238.57", "124.40.233.189", "180.180.248.184", "198.47.104.133", "198.47.104.134"}
    Dim proxy As new List(Of WebProxy)


    'Private Const KEYEVENTF_EXTENDEDKEY As Long = &H1
    'Private Const KEYEVENTF_KEYUP As Long = &H2
    'Private Const VK_LWIN As Byte = &H5B
    'Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte,
    'ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)

    'Private Const WH_KEYBOARD_LL As Integer = 13
    'Private Const WM_KEYUP As Integer = &H101
    'Private Shared _proc As LowLevelKeyboardProc = AddressOf HookCallback
    'Private Shared _hookID As IntPtr = IntPtr.Zero

    'Public Declare Auto Function SetWindowsHookEx Lib "user32.dll" (
    '    ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProc,
    '    ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr

    'Public Declare Auto Function UnhookWindowsHookEx _
    'Lib "user32.dll" (ByVal hhk As IntPtr) As IntPtr

    'Public Declare Auto Function CallNextHookEx _
    'Lib "user32.dll" (ByVal hhk As IntPtr, ByVal nCode As Integer,
    '                  ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    'Public Declare Auto Function GetModuleHandle Lib "kernel32.dll" (
    'ByVal lpModuleName As String) As IntPtr
    'Private Shared Function SetHook(
    '    ByVal proc As LowLevelKeyboardProc) As IntPtr

    '    Dim curProcess As Process = Process.GetCurrentProcess()
    '    Dim curModule As ProcessModule = curProcess.MainModule

    '    Return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
    '            GetModuleHandle(curModule.ModuleName), 0)

    'End Function

    'Public Delegate Function LowLevelKeyboardProc(
    '    ByVal nCode As Integer, ByVal wParam As IntPtr,
    '    ByVal lParam As IntPtr) As IntPtr

    'Public Shared Function HookCallback(
    '    ByVal nCode As Integer,
    '    ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    '    If nCode >= 0 And wParam = CType(WM_KEYUP, IntPtr) Then
    '        Dim vkCode As Keys = CType(Marshal.ReadInt32(lParam), Keys)
    '        If vkCode = Keys.MediaPlayPause Then
    '            'keybd_event(CByte(Keys.Zoom), 0, KEYEVENTF_EXTENDEDKEY, 0)
    '            'MsgBox("LOL WINDOWS KEY MON")
    '            playpause()

    '        End If
    '    End If

    '    Return CallNextHookEx(_hookID, nCode, wParam, lParam)
    'End Function

    Private Sub generatePlaylistCombo()
        playlistcombolist.Clear()
        '  combo_playlist.Items.Clear()
        combo_playlist.DataSource = New List(Of CBPlaylistClass)


        If Not IO.Directory.Exists(Application.StartupPath & "\playlist") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\playlist")
        End If
        Dim fileEntries As String() = Directory.GetFiles(Application.StartupPath & "\playlist")
        ' Dim filewithoutpathEntries As String() = Path.get()
        ' Process the list of files found in the directory.
        Dim fileName As String
        For Each fileName In fileEntries
            If fileName.EndsWith(".nep") Then
                playlistcombolist.Add(New CBPlaylistClass(Path.GetFileNameWithoutExtension(fileName), fileName))
            End If

        Next fileName

        combo_playlist.DataSource = playlistcombolist
        combo_playlist.DisplayMember = "Description"
        combo_playlist.ValueMember = "Value"



        'Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        '' Recurse into subdirectories of this directory.
        'Dim subdirectory As String
        'For Each subdirectory In subdirectoryEntries
        '    ProcessDirectory(subdirectory)
        'Next subdirectory
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '''' SAVE PLAYLIST SOFORT

        CheckForIllegalCrossThreadCalls = False

        Label4.Text = "Version " & Application.ProductVersion & " _ made with ♥"
        generatePlaylistCombo()

        If readProxy() Then
            Dim l As New Threading.Thread(AddressOf downloadProxy)
            l.IsBackground = True
            l.Start()
        End If


        ' downloadProxy()

        '  _hookID = SetHook(_proc)
        lbl_status.Text = ""
        '  Dim playlistarray As IWMPPlaylistArray =
        'For i As Integer = 0 To playlistarray.count
        ' IWMPPlayer.

        '    AxWindowsMediaPlayer1.playlistCollection.remove(playlistarray.Item(i))
        'Next
        ' MsgBox(playlistarray.count.ToString)

        ' newPlayList = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("soundsToPlay")
        '  Dim playlistarray As IWMPPlaylistArray = AxWindowsMediaPlayer1.playlistCollection.getByName("soundsToPlay")
        '   MsgBox(playlistarray.Item(0).count)
        AxWindowsMediaPlayer1.settings.autoStart = False
        AxWindowsMediaPlayer1.network.setProxySettings("HTTP", 2)
        AxWindowsMediaPlayer1.network.setProxyName("HTTP", "120.198.231.24")
        AxWindowsMediaPlayer1.network.setProxyPort("HTTP", 86)
        '  If playlistarray.Item(0). = 0 Then
        '  newPlayList = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("soundsToPlay")
        newPlayList = AxWindowsMediaPlayer1.newPlaylist("soundsToPlay", Application.StartupPath & "\playlist\")

        ' Else
        '   newPlayList = AxWindowsMediaPlayer1.playlistCollection.importPlaylist(playlistarray.Item(0).ToString)
        ' End If
        cLvwSort = New ListViewSort(lvw_Songs)
        If Not Directory.Exists(Application.StartupPath & "\offline") Then
            Directory.CreateDirectory(Application.StartupPath & "\offline")
        End If
        readPlaylist(playlistfile)
        _Hotkey.TryRegister(Keys.MediaNextTrack)
        _Hotkey.TryRegister(Keys.MediaPlayPause)
        _Hotkey.TryRegister(Keys.MediaPreviousTrack)
        _Hotkey.TryRegister(Keys.MediaStop)
        'If File.Exists(playlistfile) Then
        '    readPlaylist(playlistfile)
        'End If


        '    AxWindowsMediaPlayer1.playState = 
    End Sub
    Private Sub doQuery()
        If txt_searchQuery.Text.Length < 1 Then Exit Sub
        btn_searchQuery.Enabled = False
        lbl_status.Text = "searching..."

        Try


            Dim myApi As String = getApi("http://music.163.com/api/search/get/", txt_searchQuery.Text, nup_limit.Value.ToString)
            '  Dim jreader As New JsonTextReader(New StringReader(TextBox1.Text))
            '  
            Dim song = Linq.JObject.Parse(myApi)
            Dim hasResult As Linq.JToken = song.Item("result")
            If hasResult.Item("songCount").ToString = "0" Then
                Exit Sub
            End If
            Dim s As Linq.JToken = song.Item("result")("songs")
            Dim songList As New List(Of String)
            For Each item In s.Children
                songList.Add(item.Item("id").ToString)
            Next
            Dim mySongQuery As String = String.Join(",", songList)
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("http://music.163.com/api/song/detail?ids=[" & mySongQuery & "]")
            Dim resultsongs = Linq.JObject.Parse(result)
            Dim mynewSongs As Linq.JToken = resultsongs.Item("songs")


            getSongInfo.Clear()
            lvw_Songs.Items.Clear()


            For Each songi In mynewSongs.Children
                Dim getSongArtists As New List(Of String)

                '   Dim at As Linq.JToken = resultsongs.Item("songs").Item("artists")
                Dim at As Linq.JToken = songi.Item("artists")

                For Each artist In at
                    getSongArtists.Add(Unicode2UTF8(artist.Item("name").ToString))
                Next

                Dim hM As mp3Class = Nothing
                Dim mM As mp3Class = Nothing
                Dim lM As mp3Class = Nothing
                Dim bM As mp3Class = Nothing

                If songi.Item("hMusic").HasValues Then
                    hM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("hMusic")("id").ToString, Unicode2UTF8(songi.Item("hMusic")("name").ToString), songi.Item("hMusic")("size").ToString, songi.Item("hMusic")("extension").ToString, songi.Item("hMusic")("dfsId").ToString, songi.Item("hMusic")("playTime").ToString, songi.Item("hMusic")("bitrate").ToString, songi.Item("hMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("mMusic").HasValues Then
                    mM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("mMusic")("id").ToString, Unicode2UTF8(songi.Item("mMusic")("name").ToString), songi.Item("mMusic")("size").ToString, songi.Item("mMusic")("extension").ToString, songi.Item("mMusic")("dfsId").ToString, songi.Item("mMusic")("playTime").ToString, songi.Item("mMusic")("bitrate").ToString, songi.Item("mMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("lMusic").HasValues Then
                    lM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("lMusic")("id").ToString, Unicode2UTF8(songi.Item("lMusic")("name").ToString), songi.Item("lMusic")("size").ToString, songi.Item("lMusic")("extension").ToString, songi.Item("lMusic")("dfsId").ToString, songi.Item("lMusic")("playTime").ToString, songi.Item("lMusic")("bitrate").ToString, songi.Item("lMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("bMusic").HasValues Then
                    bM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("bMusic")("id").ToString, Unicode2UTF8(songi.Item("bMusic")("name").ToString), songi.Item("bMusic")("size").ToString, songi.Item("bMusic")("extension").ToString, songi.Item("bMusic")("dfsId").ToString, songi.Item("bMusic")("playTime").ToString, songi.Item("bMusic")("bitrate").ToString, songi.Item("bMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                'songi.Item("album")("name").ToString
                getSongInfo.Add(New SongClass(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString,
                                             hM,
                                             mM,
                                              lM,
                                              bM,
                                                   songi.Item("mvid").ToString))

            Next

            For Each foundSound In getSongInfo
                Dim mvidcheck As String = "✖"
                If Not foundSound.getSongMVID = "0" Then
                    mvidcheck = "✔"
                End If
                lvwAddItem(lvw_Songs, foundSound.getSongID, foundSound.getSongName, foundSound.getSongArtists(0), foundSound.getSongAlbum, timemiltommss(foundSound.getSongDuration), (CInt(getBestMusic(foundSound).getSongBitrate) / 1000).ToString & " kbit/s", mvidcheck)
            Next

        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        lbl_status.Text = ""
        btn_searchQuery.Enabled = True
    End Sub

    Private Sub getSongByIDOnly(ByVal ID As String)
        Try

            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("http://music.163.com/api/song/detail?ids=[" & ID & "]")
            Dim resultsongs = Linq.JObject.Parse(result)
            Dim mynewSongs As Linq.JToken = resultsongs.Item("songs")


            getSongInfo.Clear()
            lvw_Songs.Items.Clear()


            For Each songi In mynewSongs.Children
                Dim getSongArtists As New List(Of String)

                '   Dim at As Linq.JToken = resultsongs.Item("songs").Item("artists")
                Dim at As Linq.JToken = songi.Item("artists")

                For Each artist In at
                    getSongArtists.Add(Unicode2UTF8(artist.Item("name").ToString))
                Next

                Dim hM As mp3Class = Nothing
                Dim mM As mp3Class = Nothing
                Dim lM As mp3Class = Nothing
                Dim bM As mp3Class = Nothing

                If songi.Item("hMusic").HasValues Then
                    hM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("hMusic")("id").ToString, Unicode2UTF8(songi.Item("hMusic")("name").ToString), songi.Item("hMusic")("size").ToString, songi.Item("hMusic")("extension").ToString, songi.Item("hMusic")("dfsId").ToString, songi.Item("hMusic")("playTime").ToString, songi.Item("hMusic")("bitrate").ToString, songi.Item("hMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("mMusic").HasValues Then
                    mM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("mMusic")("id").ToString, Unicode2UTF8(songi.Item("mMusic")("name").ToString), songi.Item("mMusic")("size").ToString, songi.Item("mMusic")("extension").ToString, songi.Item("mMusic")("dfsId").ToString, songi.Item("mMusic")("playTime").ToString, songi.Item("mMusic")("bitrate").ToString, songi.Item("mMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("lMusic").HasValues Then
                    lM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("lMusic")("id").ToString, Unicode2UTF8(songi.Item("lMusic")("name").ToString), songi.Item("lMusic")("size").ToString, songi.Item("lMusic")("extension").ToString, songi.Item("lMusic")("dfsId").ToString, songi.Item("lMusic")("playTime").ToString, songi.Item("lMusic")("bitrate").ToString, songi.Item("lMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("bMusic").HasValues Then
                    bM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("bMusic")("id").ToString, Unicode2UTF8(songi.Item("bMusic")("name").ToString), songi.Item("bMusic")("size").ToString, songi.Item("bMusic")("extension").ToString, songi.Item("bMusic")("dfsId").ToString, songi.Item("bMusic")("playTime").ToString, songi.Item("bMusic")("bitrate").ToString, songi.Item("bMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                'songi.Item("album")("name").ToString
                getSongInfo.Add(New SongClass(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString,
                                             hM,
                                             mM,
                                              lM,
                                              bM,
                                                   songi.Item("mvid").ToString))

            Next

            For Each foundSound In getSongInfo
                Dim mvidcheck As String = "✖"
                If Not foundSound.getSongMVID = "0" Then
                    mvidcheck = "✔"
                End If
                lvwAddItem(lvw_Songs, foundSound.getSongID, foundSound.getSongName, foundSound.getSongArtists(0), foundSound.getSongAlbum, timemiltommss(foundSound.getSongDuration), (CInt(getBestMusic(foundSound).getSongBitrate) / 1000).ToString & " kbit/s", mvidcheck)
            Next

        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AddSongsByIDOnly(ByVal ID As String)
        Try

            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("http://music.163.com/api/song/detail?ids=[" & ID & "]")
            Dim resultsongs = Linq.JObject.Parse(result)
            Dim mynewSongs As Linq.JToken = resultsongs.Item("songs")


            getSongInfo.Clear()
            lvw_Songs.Items.Clear()


            For Each songi In mynewSongs.Children
                Dim getSongArtists As New List(Of String)

                '   Dim at As Linq.JToken = resultsongs.Item("songs").Item("artists")
                Dim at As Linq.JToken = songi.Item("artists")

                For Each artist In at
                    getSongArtists.Add(Unicode2UTF8(artist.Item("name").ToString))
                Next

                Dim hM As mp3Class = Nothing
                Dim mM As mp3Class = Nothing
                Dim lM As mp3Class = Nothing
                Dim bM As mp3Class = Nothing

                If songi.Item("hMusic").HasValues Then
                    hM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("hMusic")("id").ToString, Unicode2UTF8(songi.Item("hMusic")("name").ToString), songi.Item("hMusic")("size").ToString, songi.Item("hMusic")("extension").ToString, songi.Item("hMusic")("dfsId").ToString, songi.Item("hMusic")("playTime").ToString, songi.Item("hMusic")("bitrate").ToString, songi.Item("hMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("mMusic").HasValues Then
                    mM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("mMusic")("id").ToString, Unicode2UTF8(songi.Item("mMusic")("name").ToString), songi.Item("mMusic")("size").ToString, songi.Item("mMusic")("extension").ToString, songi.Item("mMusic")("dfsId").ToString, songi.Item("mMusic")("playTime").ToString, songi.Item("mMusic")("bitrate").ToString, songi.Item("mMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("lMusic").HasValues Then
                    lM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("lMusic")("id").ToString, Unicode2UTF8(songi.Item("lMusic")("name").ToString), songi.Item("lMusic")("size").ToString, songi.Item("lMusic")("extension").ToString, songi.Item("lMusic")("dfsId").ToString, songi.Item("lMusic")("playTime").ToString, songi.Item("lMusic")("bitrate").ToString, songi.Item("lMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("bMusic").HasValues Then
                    bM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("bMusic")("id").ToString, Unicode2UTF8(songi.Item("bMusic")("name").ToString), songi.Item("bMusic")("size").ToString, songi.Item("bMusic")("extension").ToString, songi.Item("bMusic")("dfsId").ToString, songi.Item("bMusic")("playTime").ToString, songi.Item("bMusic")("bitrate").ToString, songi.Item("bMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                'songi.Item("album")("name").ToString
                getSongInfo.Add(New SongClass(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString,
                                             hM,
                                             mM,
                                              lM,
                                              bM,
                                                   songi.Item("mvid").ToString))

            Next

            For Each foundSound In getSongInfo
                addMusictoPlaylist(foundSound)
            Next

        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub startQuery()
        Dim t As New Threading.Thread(AddressOf doQuery)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_searchQuery.Click

        startQuery()


    End Sub

    Private Function getSongInfobyID(ByVal SongID As String) As SongClass
        For i As Integer = 0 To getSongInfo.Count - 1
            If getSongInfo(i).getSongID = SongID Then
                Return getSongInfo(i)
            End If
        Next
        Return Nothing

    End Function

    Private Function getApi(ByVal URL As String, ByVal query As String, ByVal limit As String) As String
        'Login auf Facebook
        Try


            request = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
            request.Method = "POST"
            request.CookieContainer = cookieCon
            '     request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0"
            request.ContentType = "application/x-www-form-urlencoded"
            '    request.Host = "streamcloud.eu"
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
            request.Headers.Add("Cookie: appver = 2.0.2")
            '  request.Headers.Add("Referer: http://music.163.com")
            '  request.Headers.Add("Content-Type: application/x-www-form-urlencoded")
            request.Referer = "http://music.163.com"
            Dim post As String = "s=" & query & "&type=1&offset=0&sub=false&limit=" & limit
            Dim byteArr() As Byte = Encoding.Default.GetBytes(post)
            request.ContentLength = byteArr.Length

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArr, 0, byteArr.Length)

            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)


            response = DirectCast(request.GetResponse(), HttpWebResponse)

            Dim reader As New StreamReader(response.GetResponseStream(), Encoding.ASCII)
            seitenQuelltext = reader.ReadToEnd()

            ' Dim f As Match = Regex.Match(seitenQuelltext, "(?<=file: "")(.*)(?="")", RegexOptions.IgnoreCase)
            '  Dim p As String = f.Groups(0).Value

            'Account Daten überprüfen

            Return seitenQuelltext

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""

        End Try
    End Function

    Private Function getBestMusic(ByVal SongClasstoCheck As SongClass) As mp3Class
        'If Not SongClasstoCheck.gethMusic = Nothing Then Return SongClasstoCheck.gethMusic()
        'If Not SongClasstoCheck.getmMusic.getSongID = Nothing Then Return SongClasstoCheck.getmMusic()
        'If Not SongClasstoCheck.getlMusic.getSongID = Nothing Then Return SongClasstoCheck.getlMusic()
        'If Not SongClasstoCheck.getbMusic.getSongID = Nothing Then Return SongClasstoCheck.getbMusic()
        If SongClasstoCheck.hashMusic Then Return SongClasstoCheck.gethMusic()
        If SongClasstoCheck.hasmMusic Then Return SongClasstoCheck.getmMusic()
        If SongClasstoCheck.haslMusic Then Return SongClasstoCheck.getlMusic()
        If SongClasstoCheck.hasbMusic Then Return SongClasstoCheck.getbMusic()

        Return Nothing
    End Function

    Public Sub addMusictoPlaylist(ByVal newsongclass As SongClass)
        songC = newsongclass
        songH = getBestMusic(songC)
        songURL = songC.getSongMP3URL '.Replace("m2.", "198.47.104.134/m1.")
        songName = songC.getSongName

        If File.Exists(Application.StartupPath & "\offline\" & songC.getSongID & "." & songH.getSongExtension) Then
            songURL = Application.StartupPath & "\offline\" & songC.getSongID & "." & songH.getSongExtension
        Else
            If chb_dl.Checked Then
                subDownloadMusicBymp3Class(songH)
            End If
        End If
        '   flp_infoMusic.Controls.Clear()
        If Not myPlaylist.Contains(songH) Then
            lb_playlist.Items.Add(songName)

            myPlaylist.Add(songH)
            newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(songURL))
            AxWindowsMediaPlayer1.currentPlaylist = newPlayList
            '  AxWindowsMediaPlayer1.currentPlaylist.appendItem(songURL)
            lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1

        End If

    End Sub

    Private Sub lvw_Songs_DoubleClick(sender As Object, e As EventArgs) Handles lvw_Songs.DoubleClick ' Handles lvw_Songs.SelectedIndexChanged

        If lvw_Songs.SelectedItems.Count = 1 Then
            '

            songC = getSongInfobyID(CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, String))
            songH = getBestMusic(songC)
            songURL = songC.getSongMP3URL '.Replace("m2.", "198.47.104.134/m1.")
            songName = songC.getSongName

            If File.Exists(Application.StartupPath & "\offline\" & songC.getSongID & "." & songH.getSongExtension) Then
                songURL = Application.StartupPath & "\offline\" & songC.getSongID & "." & songH.getSongExtension
            Else
                If chb_dl.Checked Then
                    subDownloadMusic(songC.getSongID)
                End If
            End If
            '   flp_infoMusic.Controls.Clear()
            If Not myPlaylist.Contains(songH) Then
                lb_playlist.Items.Add(songName)

                myPlaylist.Add(songH)
                newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(songURL))
                AxWindowsMediaPlayer1.currentPlaylist = newPlayList
                '  AxWindowsMediaPlayer1.currentPlaylist.appendItem(songURL)
                lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1
                Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)

                AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)
            Else
                For i As Integer = 0 To myPlaylist.Count - 1
                    If AxWindowsMediaPlayer1.currentPlaylist.Item(i).sourceURL = Application.StartupPath & "\offline\" & songC.getSongID & "." & songH.getSongExtension Then

                        Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(i)
                        AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)

                        Exit For

                    End If

                Next
            End If


            '  AxWindowsMediaPlayer1.URL = songURL



            '  AxWindowsMediaPlayer1.currentPlaylist.appendItem()
        End If
    End Sub



    Private Function decryptID(ByVal dfsID As String) As String
        Dim byte1 As Byte() = TextStringToByteArray("3go8&$8*3*3h0k(2)2")
        Dim byte2 As Byte() = TextStringToByteArray(dfsID)
        Dim byte1_len As Integer = byte1.Length
        For i As Integer = 0 To byte2.Length - 1
            byte2(i) = byte2(i) Xor byte1(i Mod byte1_len)
        Next
        Dim md5Hash As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create

        Dim result As String = ByteArrayToString(md5Hash.ComputeHash(byte2))
        result = result.Replace("/", "_")
        result = result.Replace("+", "-")
        Return result
        ' MsgBox(result)
    End Function
    Private Sub subDownloadMusicBymp3Class(ByVal mp3class As mp3Class)
        Dim mysong As mp3Class = mp3class
        Dim decryptedStr As String = decryptID(mp3class.getSongdfsID)
        Dim dl As New WebClient
        ' AddHandler dl.DownloadFileCompleted, AddressOf MusicDownloadDone

        If chb_useproxy.Checked And proxy.Count > 0 Then
            dl.Proxy = RandomProxy()
        End If

        dl.DownloadFileAsync(New Uri("http://" & RandomIP() & "m1.music.126.net/" & decryptedStr & "/" & mysong.getSongdfsID & "." & mysong.getSongExtension), Application.StartupPath & "\offline\" & mysong.getSongMainID & "." & mysong.getSongExtension)

    End Sub
    Private Sub subDownloadMusic(ByVal SongID As String)
        Dim mysong As SongClass = getSongInfobyID(SongID)
        Dim myfoundsong As mp3Class = getBestMusic(mysong)
        Dim decryptedStr As String = decryptID(myfoundsong.getSongdfsID)
        Dim dl As New WebClient

        If chb_useproxy.Checked And proxy.Count > 0 Then
            dl.Proxy = RandomProxy()
        End If
        ' AddHandler dl.DownloadFileCompleted, AddressOf MusicDownloadDone

        dl.DownloadFileAsync(New Uri("http://" & RandomIP() & "m1.music.126.net/" & decryptedStr & "/" & myfoundsong.getSongdfsID & "." & myfoundsong.getSongExtension), Application.StartupPath & "\offline\" & mysong.getSongID & "." & myfoundsong.getSongExtension)
    End Sub

    Private Sub subDownloadMusicFromPlaylist(playlistindex As Integer)
        Dim mysong As mp3Class = myPlaylist(playlistindex)
        Dim decryptedStr As String = decryptID(mysong.getSongdfsID)
        Dim dl As New WebClient
        If chb_useproxy.Checked And proxy.Count > 0 Then
            dl.Proxy = RandomProxy()
        End If

        dl.DownloadFileAsync(New Uri("http://" & RandomIP() & "m1.music.126.net/" & decryptedStr & "/" & mysong.getSongdfsID & "." & mysong.getSongExtension), Application.StartupPath & "\offline\" & mysong.getSongMainID & "." & mysong.getSongExtension)
    End Sub

    Private Sub MusicDownloadDone(sender As Object, e As AsyncCompletedEventArgs)

    End Sub

    Private Function RandomIP() As String
        Dim rnd As New Random()
        Return ""



        'Dim newip As String = ips(rnd.Next(0, ips.Count - 1))
        'Return newip & "/"


    End Function

    Private Sub downloadProxy()
        Dim wc As New WebClient
        Dim proxypage As String = wc.DownloadString("http://cn-proxy.com")
        '    Dim rx As New Regex("<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>", RegexOptions.Multiline)

        Dim mmatch As MatchCollection = Regex.Matches(proxypage, "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>")

        Dim rxmatches As MatchCollection = Regex.Matches(proxypage, "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>") ', "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>")
        proxy.Clear()
        Dim sw As New StreamWriter(Application.StartupPath & "/Proxy.txt", False)

        For Each m As Match In mmatch
            proxy.Add(New WebProxy(m.Groups(1).ToString, CInt(m.Groups(2).ToString)))
            sw.WriteLine(m.Groups(1).ToString & ":" & m.Groups(2).ToString)

        Next
        chb_useproxy.Text = "Proxy (" & proxy.Count.ToString & ")"
        sw.Close()

    End Sub

    Private Function RandomProxy() As WebProxy
        Dim rnd As New Random()
        Dim newproxy As WebProxy = proxy(rnd.Next(0, proxy.Count - 1))
        Return newproxy


    End Function
    Private Sub lb_playlist_SelectedDC(sender As Object, e As EventArgs) Handles lb_playlist.DoubleClick
        If lb_playlist.SelectedItems.Count = 1 Then
            Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(lb_playlist.SelectedIndex)
            AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)
            If chb_dl.Checked And File.Exists(Application.StartupPath & "\offline\" & myPlaylist(lb_playlist.SelectedIndex).getSongMainID & "." & myPlaylist(lb_playlist.SelectedIndex).getSongExtension) = False Then
                subDownloadMusicFromPlaylist(lb_playlist.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub refreshMediaItems()

        If AxWindowsMediaPlayer1.currentMedia Is Nothing Then
            Return
        End If
        Dim nt As mp3Class = getmp3classFromPlaylistbyIDorName(AxWindowsMediaPlayer1.currentMedia.name)
        Dim playlistIndex As Integer = getPlaylistindexfromIDorName(AxWindowsMediaPlayer1.currentMedia.name)


        '  AxWindowsMediaPlayer1.currentMedia.in
        If Not nt Is Nothing Then
            lbl_title.Text = nt.getSongMainName
            lbl_artist.Text = String.Join(" && ", nt.getSongArtists)
            lbl_album.Text = nt.getSongAlbum
            '  lbl_artist =
            Me.Text = "NetEase Player - " & nt.getSongMainName & " - " & String.Join(" & ", nt.getSongArtists)

        Else

            lbl_title.Text = "Unknown Track"
            lbl_artist.Text = "Unknown"
            lbl_album.Text = "Unknown"
            Me.Text = "NetEase Player - Unknown Track"
        End If
        RaiseEvent nextTrack(nt)
        If playlistIndex > -1 Then
            lb_playlist.SelectedIndex = playlistIndex
        End If


    End Sub
    Private Sub AxWindowsMediaPlayer1_CurrentItemChange(sender As Object, e As _WMPOCXEvents_CurrentItemChangeEvent) Handles AxWindowsMediaPlayer1.CurrentItemChange
        refreshMediaItems()

    End Sub

    Private Function getmp3classFromPlaylistbyIDorName(ByVal IDorName As String) As mp3Class
        For Each title In myPlaylist
            If title.getSongMainID = IDorName Or title.getSongMainName = IDorName Or title.getSongName = IDorName Or title.getSongdfsID = IDorName Then
                Return title
            End If
        Next
        Return Nothing
    End Function
    Private Function getPlaylistindexfromIDorName(ByVal IDorName As String) As Integer
        For i As Integer = 0 To myPlaylist.Count - 1
            If myPlaylist(i).getSongMainID = IDorName Or myPlaylist(i).getSongMainName = IDorName Or myPlaylist(i).getSongName = IDorName Or myPlaylist(i).getSongdfsID = IDorName Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        writePlaylist(myPlaylist)
        '  AxWindowsMediaPlayer1.playlistCollection.remove(AxWindowsMediaPlayer1.currentPlaylist)

    End Sub
    Private Function readProxy() As Boolean
        If File.Exists(Application.StartupPath & "\Proxy.txt") Then
            Dim sr As StreamReader = New StreamReader(Application.StartupPath & "\Proxy.txt")
            Do While sr.Peek() >= 0
                Dim prline As String = sr.ReadLine
                proxy.Add(New WebProxy(Split(prline, ":")(0), CInt(Split(prline, ":")(1))))

            Loop
            chb_useproxy.Text = "Proxy (" & proxy.Count.ToString & ")"
            sr.Close()

        End If
        Return True

    End Function
    Private Sub writePlaylist(ByVal playlist As List(Of mp3Class))

        If Not IO.Directory.Exists(Application.StartupPath & "\playlist") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\playlist")
        End If
        File.WriteAllText(playlistfile, "", Encoding.Default)
        Dim sep As String = "+*;*+"
        For Each song In playlist
            File.AppendAllText(playlistfile,
                   song.getSongMainID & sep & song.getSongMainName & sep & String.Join(",", song.getSongArtists) & sep & song.getSongAlbum & sep & song.getSongDuration & sep &
            song.getSongID & sep & song.getSongName & sep & song.getSongSize & sep & song.getSongExtension & sep &
                 song.getSongdfsID & sep & song.getSongPlaytime & sep & song.getSongBitrate & sep & song.getSongSR & sep & song.getSongMVID & sep &
                vbCrLf)
        Next
    End Sub

    Private Sub readPlaylist(ByVal playlistfilepath As String)
        If File.Exists(playlistfilepath) Then


            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(playlistfilepath, Encoding.UTF8)
            myPlaylist.Clear()
            lb_playlist.Items.Clear()
            newPlayList.clear()
            Dim fi As New FileInfo(playlistfilepath)
            If fi.Length < 20 Then Exit Sub

            Dim a As String
            Dim sep As String = "+*;*+"
            Do
                a = reader.ReadLine
                Dim pl As String() = Strings.Split(a, sep)
                If pl.Length < 2 Then Exit Do

                Dim at As String() = Strings.Split(pl(2), ",")
                Dim atl As List(Of String) = at.ToList

                myPlaylist.Add(New mp3Class(pl(0), pl(1), atl, pl(3), pl(4), Nothing, pl(5), pl(6), pl(7), pl(8), pl(9), pl(10), pl(11), pl(12), pl(13)))
                lb_playlist.Items.Add(pl(1))

                ' Code here
                '
            Loop Until a Is Nothing

            reader.Close()
            For Each pli In myPlaylist
                Dim myfile As String = Application.StartupPath & "\offline\" & pli.getSongMainID & "." & pli.getSongExtension
                If File.Exists(myfile) Then
                    Dim myFileInfo As New FileInfo(myfile)
                    Dim sizeInBytes As Long = myFileInfo.Length
                    If sizeInBytes = Long.Parse(pli.getSongSize) Then
                        newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(myfile))
                        AxWindowsMediaPlayer1.currentPlaylist = newPlayList
                    Else
                        Dim decryptedStr As String = decryptID(pli.getSongdfsID)
                        newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia("http://" & RandomIP() & "m1.music.126.net/" & decryptedStr & "/" & pli.getSongdfsID & "." & pli.getSongExtension))
                        AxWindowsMediaPlayer1.currentPlaylist = newPlayList
                    End If

                Else
                    Dim decryptedStr As String = decryptID(pli.getSongdfsID)
                    newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia("http://" & RandomIP() & "m1.music.126.net/" & decryptedStr & "/" & pli.getSongdfsID & "." & pli.getSongExtension))
                    AxWindowsMediaPlayer1.currentPlaylist = newPlayList
                End If

                'lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1
                '  Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)
            Next

        End If

    End Sub

    Private Sub btn_dlsong_Click(sender As Object, e As EventArgs) Handles btn_dlsong.Click
        If lvw_Songs.SelectedItems.Count = 1 Then
            subDownloadMusic(CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, String))
        End If
    End Sub

    Private Sub btn_dlplay_Click(sender As Object, e As EventArgs) Handles btn_dlplay.Click
        If lvw_Songs.SelectedItems.Count = 1 Then
            songC = getSongInfobyID(CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, String))
            ' songH = songC.gethMusic
            songH = getBestMusic(songC)
            songURL = songC.getSongMP3URL.Replace("m2.", "198.47.104.134/m1.")
            songName = songC.getSongName
            songURL = Application.StartupPath & "\offline\" & songC.getSongID & "." & songC.gethMusic.getSongExtension

            If Not File.Exists(songURL) Then

                '  Else
                '  If chb_dl.Checked Then
                subDownloadMusic(songC.getSongID)
                ' End If
            End If

            If Not myPlaylist.Contains(songH) Then
                lb_playlist.Items.Add(songName)

                myPlaylist.Add(songH)
                newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(songURL))
                AxWindowsMediaPlayer1.currentPlaylist = newPlayList

                '   lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1
                '  Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)

                '  AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)

            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles timer_position.Tick
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            Try



                Dim t As Double = Math.Floor(AxWindowsMediaPlayer1.currentMedia.duration - AxWindowsMediaPlayer1.Ctlcontrols.currentPosition)
                Dim sec1 As Integer = CInt(t Mod 60)
                Dim min1 As Integer = CInt((t - sec1) / 60)
                Dim cur As Double = Math.Floor(AxWindowsMediaPlayer1.Ctlcontrols.currentPosition)
                Dim sec2 As Integer = CInt(cur Mod 60)
                Dim min2 As Integer = CInt((cur - sec2) / 60)
                lbl_position.Text = AxWindowsMediaPlayer1.currentMedia.durationString & " - " & min2.ToString("00") & ":" & sec2.ToString("00") & " - " & min1.ToString("00") & ":" & sec1.ToString("00")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btn_delfromplaylist_Click(sender As Object, e As EventArgs) Handles btn_delfromplaylist.Click
        If lb_playlist.SelectedItems.Count = 1 Then

            Dim myindex As Integer = lb_playlist.SelectedIndex

            newPlayList.removeItem(AxWindowsMediaPlayer1.currentPlaylist.Item(myindex))
            AxWindowsMediaPlayer1.currentPlaylist = newPlayList
            If File.Exists(Application.StartupPath & "\offline\" & myPlaylist(myindex).getSongMainID & "." & myPlaylist(myindex).getSongExtension) Then
                Try
                    File.Delete(Application.StartupPath & "\offline\" & myPlaylist(myindex).getSongMainID & "." & myPlaylist(myindex).getSongExtension)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit sub
                End Try

            End If
            myPlaylist.RemoveAt(myindex)
            lb_playlist.Items.RemoveAt(myindex)    '  Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)
            Dim nindex = myindex
            If myindex = myPlaylist.Count Then
                nindex = myindex - 1

            End If
            Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(nindex)
            AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)
        End If
    End Sub
    Private Function formatBytes(ByVal Bytes As Long) As String
        If Bytes >= 1073741824 Then
            Return (Bytes / 1024 / 1024 / 1024).ToString("#0.00") & " GB"
        ElseIf Bytes >= 1048576 Then
            Return (Bytes / 1024 / 1024).ToString("#0.00") & " MB"
        ElseIf Bytes >= 1024 Then
            Return (Bytes / 1024).ToString("#0.00") & " KB"
        ElseIf Bytes < 1024 Then
            Return (Bytes).ToString("#0.00") & " Bytes"
        End If
        Return "0 Bytes"
    End Function
    Private Sub gatherMusicInformationforGB(ByVal playlistindex As Object)
        Dim myindex As Integer = CInt(playlistindex)
        Dim myfiletocheck As String = Application.StartupPath & "\offline\" & myPlaylist(myindex).getSongMainID & "." & myPlaylist(myindex).getSongExtension

        Dim doesfileexists As Boolean = File.Exists(myfiletocheck)
        Dim sizeInBytes As Long
        'flp_infoMusic.Controls.Clear()


        If doesfileexists Then

            Dim myFile As New FileInfo(myfiletocheck)
            sizeInBytes = myFile.Length
            If sizeInBytes = Long.Parse(myPlaylist(myindex).getSongSize) Then
                btn_exportfromplaylist.Enabled = True
                btn_dlrepair.Enabled = False

            Else
                btn_exportfromplaylist.Enabled = False
                btn_dlrepair.Enabled = True
            End If

        Else


            btn_exportfromplaylist.Enabled = False
            btn_dlrepair.Enabled = True
        End If
        If myPlaylist(myindex).getSongMVID = "0" Then
            btn_video.Enabled = False
        Else
            btn_video.Enabled = True
        End If

        'Dim l1 As New Label
        'Dim l2 As New Label
        'Dim l3 As New Label
        'Dim l4 As New Label
        'Dim l5 As New Label
        'l1.AutoSize = True
        'l2.AutoSize = True
        'l3.AutoSize = True
        'l4.AutoSize = True
        'l5.AutoSize = True
        Dim lblinfo_offline As String = ""
        Dim lblinfo_bitrate As String = ""
        Dim lblinfo_size As String = ""
        Dim lblinfo_duration As String = ""
        Dim lblinfo_download As String = ""

        If doesfileexists Then
            '   l1.Text = "Offline: Yes"
            lblinfo_offline = "Offline: Yes"
            Dim p As Double = CDbl(sizeInBytes) / Double.Parse(myPlaylist(myindex).getSongSize) * 100
            p = Math.Round(p, 2)
            lblinfo_size = "Size: " & formatBytes(sizeInBytes) & " / " & formatBytes(CLng(myPlaylist(myindex).getSongSize)) '& " (" & p.ToString("0.00") & "%)"
            '   l3.Text = "Size: " & formatBytes(sizeInBytes) & " / " & formatBytes(CLng(myPlaylist(myindex).getSongSize)) '& " (" & p.ToString("0.00") & "%)"
            lblinfo_download = "Download: " & p.ToString("0.00") & " %"
            '     l5.Text = "Download: " & p.ToString("0.00") & " %"
            ' l3.Text = "Size: " & " (" & p.ToString & "%) " & formatBytes(sizeInBytes)
        Else
            'l1.Text = "Offline: No"
            'l3.Text = "Size: -"
            'l5.Text = "Download: 0%"
            lblinfo_offline = "Offline: No"
            lblinfo_size = "Size: -"
            lblinfo_download = "Download: 0%"
        End If

        'l2.Text = "Bitrate: " & CStr(CInt(myPlaylist(myindex).getSongBitrate) / 1000) & " kbit/s"
        'l4.Text = "Duration: " & timemiltommss(myPlaylist(myindex).getSongDuration)
        lblinfo_bitrate = "Bitrate: " & CStr(CInt(myPlaylist(myindex).getSongBitrate) / 1000) & " kbit/s"
        lblinfo_duration = "Duration: " & timemiltommss(myPlaylist(myindex).getSongDuration)

        lbl_infoffline.BeginInvoke(New addLabelFromThreadDelegate(AddressOf LabelDelegate), {lbl_infoffline, lblinfo_offline})
        lbl_infobitrate.BeginInvoke(New addLabelFromThreadDelegate(AddressOf LabelDelegate), {lbl_infobitrate, lblinfo_bitrate})
        lbl_infosize.BeginInvoke(New addLabelFromThreadDelegate(AddressOf LabelDelegate), {lbl_infosize, lblinfo_size})
        lbl_infodownload.BeginInvoke(New addLabelFromThreadDelegate(AddressOf LabelDelegate), {lbl_infodownload, lblinfo_download})

        lbl_infoduration.BeginInvoke(New addLabelFromThreadDelegate(AddressOf LabelDelegate), {lbl_infoduration, lblinfo_duration})
        ' flp_infoMusic.Controls.AddRange({l1, l2, l3})

    End Sub
    Private Delegate Sub addLabelFromThreadDelegate(label As Label, ltext As String)
    Public Sub LabelDelegate(label As Label, ltext As String)
        '  myControl.Text = myText
        label.Text = ltext
        'If flp_infoMusic.Controls.ContainsKey(myControl.Name) Then
        '    flp_infoMusic.Controls.RemoveByKey(myControl.Name)
        'End If
        'flp_infoMusic.Controls.Add(myControl)
    End Sub
    'Private Sub addLabel(ByVal mycontrol As Control)
    '    flp_infoMusic.Controls.Add(mycontrol)
    'End Sub
    Private Sub lb_playlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_playlist.SelectedIndexChanged

        If lb_playlist.SelectedItems.Count = 1 Then

            btn_delfromplaylist.Enabled = True
            If Not oldselectedindex = lb_playlist.SelectedIndex Then
                'flp_infoMusic.Controls.Clear()
                Dim gi As New Threading.Thread(AddressOf gatherMusicInformationforGB)
                gi.IsBackground = True
                gi.Start(lb_playlist.SelectedIndex)
                oldselectedindex = lb_playlist.SelectedIndex
            End If

        Else
                btn_delfromplaylist.Enabled = False


        End If

    End Sub

    Private Sub btn_exportfromplaylist_Click(sender As Object, e As EventArgs) Handles btn_exportfromplaylist.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
            .FileName = (myPlaylist(lb_playlist.SelectedIndex).getSongMainName & "_-_" & String.Join("_&_", myPlaylist(lb_playlist.SelectedIndex).getSongArtists) & "." & myPlaylist(lb_playlist.SelectedIndex).getSongExtension).Replace(" ", "_")
            .Filter = myPlaylist(lb_playlist.SelectedIndex).getSongExtension.ToUpper & "|*." & myPlaylist(lb_playlist.SelectedIndex).getSongExtension.ToLower
            If .ShowDialog = DialogResult.OK Then
                File.Copy(Application.StartupPath & "\offline\" & myPlaylist(lb_playlist.SelectedIndex).getSongMainID & "." & myPlaylist(lb_playlist.SelectedIndex).getSongExtension, .FileName)

            End If
        End With
    End Sub

    Private Sub btn_dlrepair_Click(sender As Object, e As EventArgs) Handles btn_dlrepair.Click
        If lb_playlist.SelectedItems.Count = 1 Then
            btn_dlrepair.Enabled = False
            subDownloadMusicFromPlaylist(lb_playlist.SelectedIndex)
        End If
    End Sub

    Private Sub lbl_title_Click(sender As Object, e As EventArgs) Handles lbl_title.Click
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            txt_searchQuery.Text = lbl_title.Text
            startQuery()

        End If
    End Sub

    Private Sub lbl_artist_Click(sender As Object, e As EventArgs) Handles lbl_artist.Click
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            txt_searchQuery.Text = lbl_artist.Text.Replace("&&", "&")
            startQuery()

        End If
    End Sub

    Private Sub lbl_album_Click(sender As Object, e As EventArgs) Handles lbl_album.Click
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            txt_searchQuery.Text = lbl_album.Text
            startQuery()

        End If
    End Sub



    Private Sub txt_searchQuery_Click(sender As Object, e As EventArgs) Handles txt_searchQuery.Click
        btn_searchQuery.Enabled = True

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        refreshMediaItems()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_video.Click

        AxWindowsMediaPlayer1.Ctlcontrols.pause()

        Dim f As New MusicVideoForm(myPlaylist(lb_playlist.SelectedIndex).getSongMVID)
        f.Show()


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sf As New Form_SpotifyRip(myPlaylist)

        AddHandler sf.newSongClassArrived, AddressOf addMusictoPlaylist

        sf.Show()

    End Sub

    Private Sub combo_playlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_playlist.SelectedIndexChanged
        '  MsgBox(combo_playlist.Selected)
    End Sub

    Private Sub btn_loadplaylist_Click(sender As Object, e As EventArgs) Handles btn_loadplaylist.Click
        If combo_playlist.Text.Length > 0 Then
            playlistfile = combo_playlist.SelectedValue.ToString


            readPlaylist(playlistfile)

        End If

    End Sub

    Private Sub btn_addplaylist_Click(sender As Object, e As EventArgs) Handles btn_addplaylist.Click
        If txt_addplaylist.Text.Length > 0 Then


            If Not IO.Directory.Exists(Application.StartupPath & "\playlist") Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\playlist")
            End If
            If File.Exists(Application.StartupPath & "\playlist\" & txt_addplaylist.Text & ".nep") Then
                If MessageBox.Show("That playlist already exists. Overwrite?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    File.WriteAllText(Application.StartupPath & "\playlist\" & txt_addplaylist.Text & ".nep", "", Encoding.Default)
                    txt_addplaylist.Text = ""

                End If
            Else
                File.WriteAllText(Application.StartupPath & "\playlist\" & txt_addplaylist.Text & ".nep", "", Encoding.Default)
                txt_addplaylist.Text = ""

            End If
        Else
            MessageBox.Show("Give me a playlist name!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub combo_playlist_MouseEnter(sender As Object, e As EventArgs) Handles combo_playlist.MouseEnter
        generatePlaylistCombo()

    End Sub

    Private Sub txt_addplaylist_TextChanged(sender As Object, e As EventArgs) Handles txt_addplaylist.TextChanged
        If txt_addplaylist.Text.Length < 1 Then
            btn_addplaylist.Enabled = False
        Else
            btn_addplaylist.Enabled = True

        End If
    End Sub



    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized And chb_miniplayerifminized.Checked Then
            MiniPlayer.Show()
            If lb_playlist.SelectedItems.Count = 1 Then
                ' RaiseEvent nextTrack(myPlaylist(lb_playlist.SelectedIndex))
                RaiseEvent nextTrack(getmp3classFromPlaylistbyIDorName(AxWindowsMediaPlayer1.currentMedia.name))
            End If
            '  Me.ShowInTaskbar = False
        ElseIf Me.WindowState = FormWindowState.Normal
            MiniPlayer.Close()

        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        refreshMediaItems()
        If chb_repeatplaylist.Checked Then
            If AxWindowsMediaPlayer1.playState = WMPPlayState.wmppsMediaEnded Then
                AxWindowsMediaPlayer1.Ctlcontrols.play()
            End If
        End If
    End Sub

    Private Sub readdfromcache()
        btn_readdfromcache.Enabled = False
        Dim mf As String() = Directory.GetFiles(Application.StartupPath & "\offline", "*.mp3", SearchOption.TopDirectoryOnly)
        Dim combinedfilenames As New List(Of String)
        Dim currentPlaylistIDs As New List(Of String)



        For Each song In myPlaylist
            currentPlaylistIDs.Add(song.getSongMainID)
        Next

        For Each file As String In mf

            If Not currentPlaylistIDs.Contains(Path.GetFileNameWithoutExtension(file)) Then
                combinedfilenames.Add(Path.GetFileNameWithoutExtension(file))

            End If
        Next


        AddSongsByIDOnly(String.Join(",", combinedfilenames))
        btn_readdfromcache.Enabled = True

    End Sub
    Private Sub btn_readdfromcache_Click(sender As Object, e As EventArgs) Handles btn_readdfromcache.Click
        Dim rafc As New Threading.Thread(AddressOf readdfromcache)
        rafc.IsBackground = True
        rafc.Start()

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        _Hotkey.Dispose()

    End Sub
    Private Sub _Hotkey_Pressed(ByVal sender As Object, ByVal e As EventArgs) Handles _Hotkey.Pressed
        Select Case _Hotkey.Value
            Case Keys.MediaNextTrack
                AxWindowsMediaPlayer1.Ctlcontrols.next()
            Case Keys.MediaPreviousTrack
                AxWindowsMediaPlayer1.Ctlcontrols.previous()
            Case Keys.MediaPlayPause
                If AxWindowsMediaPlayer1.playState = WMPPlayState.wmppsPlaying Then
                    AxWindowsMediaPlayer1.Ctlcontrols.pause()
                Else
                    AxWindowsMediaPlayer1.Ctlcontrols.play()
                End If
            Case Keys.MediaStop
                AxWindowsMediaPlayer1.Ctlcontrols.stop()


        End Select
    End Sub







    'Private Sub chb_repeatplaylist_CheckStateChanged(sender As Object, e As EventArgs) Handles chb_repeatplaylist.CheckStateChanged
    '    If chb_repeatplaylist.Checked Then
    '        AxWindowsMediaPlayer1.settings.setMode("loop", True)
    '    Else
    '        AxWindowsMediaPlayer1.settings.setMode("loop", False)
    '    End If


    'End Sub
End Class
