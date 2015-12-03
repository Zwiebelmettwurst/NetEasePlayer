Option Strict On

Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json


Imports System.Text.RegularExpressions
Imports AxWMPLib

Public Class Form1
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


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        newPlayList = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("soundsToPlay")
        cLvwSort = New ListViewSort(lvw_Songs)
        If Not Directory.Exists(Application.StartupPath & "\offline") Then
            Directory.CreateDirectory(Application.StartupPath & "\offline")
        End If

        If File.Exists(playlistfile) Then
            readPlaylist(playlistfile)
        End If
        '  AxWindowsMediaPlayer1.Ctlcontrols.pause()

        '        AxWindowsMediaPlayer1.URL = "http://m5.music.126.net/q9cuWR1WmSzJgqJaWThfMA==/7785641837374895.mp3"

    End Sub
    Private Sub doQuery()
        If txt_searchQuery.Text.Length < 1 Then Exit Sub


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
                getSongArtists.Add(artist.Item("name").ToString)
            Next

            Dim hM As mp3Class = Nothing
            Dim mM As mp3Class = Nothing
            Dim lM As mp3Class = Nothing
            Dim bM As mp3Class = Nothing

            If songi.Item("hMusic").HasValues Then
                hM = New mp3Class(songi.Item("id").ToString, songi.Item("name").ToString, getSongArtists, songi.Item("album")("name").ToString, songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("hMusic")("id").ToString, songi.Item("hMusic")("name").ToString, songi.Item("hMusic")("size").ToString, songi.Item("hMusic")("extension").ToString, songi.Item("hMusic")("dfsId").ToString, songi.Item("hMusic")("playTime").ToString, songi.Item("hMusic")("bitrate").ToString, songi.Item("hMusic")("sr").ToString)
            End If
            If songi.Item("mMusic").HasValues Then
                mM = New mp3Class(songi.Item("id").ToString, songi.Item("name").ToString, getSongArtists, songi.Item("album")("name").ToString, songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("mMusic")("id").ToString, songi.Item("mMusic")("name").ToString, songi.Item("mMusic")("size").ToString, songi.Item("mMusic")("extension").ToString, songi.Item("mMusic")("dfsId").ToString, songi.Item("mMusic")("playTime").ToString, songi.Item("mMusic")("bitrate").ToString, songi.Item("mMusic")("sr").ToString)
            End If
            If songi.Item("lMusic").HasValues Then
                lM = New mp3Class(songi.Item("id").ToString, songi.Item("name").ToString, getSongArtists, songi.Item("album")("name").ToString, songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("lMusic")("id").ToString, songi.Item("lMusic")("name").ToString, songi.Item("lMusic")("size").ToString, songi.Item("lMusic")("extension").ToString, songi.Item("lMusic")("dfsId").ToString, songi.Item("lMusic")("playTime").ToString, songi.Item("lMusic")("bitrate").ToString, songi.Item("lMusic")("sr").ToString)
            End If
            If songi.Item("bMusic").HasValues Then
                bM = New mp3Class(songi.Item("id").ToString, songi.Item("name").ToString, getSongArtists, songi.Item("album")("name").ToString, songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("bMusic")("id").ToString, songi.Item("bMusic")("name").ToString, songi.Item("bMusic")("size").ToString, songi.Item("bMusic")("extension").ToString, songi.Item("bMusic")("dfsId").ToString, songi.Item("bMusic")("playTime").ToString, songi.Item("bMusic")("bitrate").ToString, songi.Item("bMusic")("sr").ToString)
            End If
            'songi.Item("album")("name").ToString
            getSongInfo.Add(New SongClass(songi.Item("id").ToString, songi.Item("name").ToString, getSongArtists, songi.Item("album")("name").ToString, songi.Item("duration").ToString, songi.Item("mp3Url").ToString,
                                         hM,
                                         mM,
                                          lM,
                                          bM))

        Next

        For Each foundSound In getSongInfo
            lvwAddItem(lvw_Songs, foundSound.getSongID, foundSound.getSongName, foundSound.getSongArtists(0), foundSound.getSongAlbum)
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_searchQuery.Click

        Dim t As New Threading.Thread(AddressOf doQuery)
        t.IsBackground = True
        t.Start()

    End Sub
    'Private Function getBestMusic(ByVal SongID As String) As mp3Class
    '    Dim sc As SongClass = getSongInfobyID(SongID)




    'End Function
    Private Function getSongInfobyID(ByVal SongID As String) As SongClass
        For i As Integer = 0 To getSongInfo.Count - 1
            If getSongInfo(i).getSongID = SongID Then
                Return getSongInfo(i)
            End If
        Next
        Return Nothing

    End Function
    Public Sub lvwAddItem(ByVal lvw As ListView, ByVal mytag As Object, ByVal ParamArray Text() As String)

        With lvw

            .Items.Add(New ListViewItem(Text)).Tag = mytag
        End With
    End Sub
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

            Dim reader As New StreamReader(response.GetResponseStream())
            seitenQuelltext = reader.ReadToEnd()

            ' Dim f As Match = Regex.Match(seitenQuelltext, "(?<=file: "")(.*)(?="")", RegexOptions.IgnoreCase)
            '  Dim p As String = f.Groups(0).Value

            'Account Daten überprüfen

            Return seitenQuelltext

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End

        End Try
    End Function

    Private Function getBestMusic(ByVal SongClasstoCheck As SongClass) As mp3Class
        If Not SongClasstoCheck.gethMusic.getSongID = Nothing Then SongClasstoCheck.gethMusic()
        If Not SongClasstoCheck.getmMusic.getSongID = Nothing Then SongClasstoCheck.getmMusic()
        If Not SongClasstoCheck.getlMusic.getSongID = Nothing Then SongClasstoCheck.getlMusic()
        If Not SongClasstoCheck.getbMusic.getSongID = Nothing Then SongClasstoCheck.getbMusic()
        Return Nothing
    End Function

    Private Sub lvw_Songs_DoubleClick(sender As Object, e As EventArgs) Handles lvw_Songs.DoubleClick ' Handles lvw_Songs.SelectedIndexChanged
        If lvw_Songs.SelectedItems.Count = 1 Then
            songC = getSongInfobyID(CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, String))
            songH = getBestMusic(songC)
            songURL = songC.getSongMP3URL.Replace("m2.", "m5.")
            songName = songC.getSongName

            If File.Exists(Application.StartupPath & "\offline\" & songC.getSongID & "." & songC.gethMusic.getSongExtension) Then
                songURL = Application.StartupPath & "\offline\" & songC.getSongID & "." & songC.gethMusic.getSongExtension
            Else
                If chb_dl.Checked Then
                    subDownloadMusic(songC.getSongID)
                End If
            End If

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
    Public Function TextStringToByteArray(ByRef str As String) As Byte()
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default
        Return enc.GetBytes(str)
    End Function

    Public Function ByteArrayToString(ByRef Barr() As Byte) As String
        Return Convert.ToBase64String(Barr)
    End Function

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

    Private Sub subDownloadMusic(ByVal SongID As String)
        Dim mysong As SongClass = getSongInfobyID(SongID)
        Dim myfoundsong As mp3Class = getBestMusic(mysong)
        Dim decryptedStr As String = decryptID(myfoundsong.getSongdfsID)
        Dim dl As New WebClient
        dl.DownloadFileAsync(New Uri("http://m5.music.126.net/" & decryptedStr & "/" & myfoundsong.getSongdfsID & "." & myfoundsong.getSongExtension), Application.StartupPath & "\offline\" & mysong.getSongID & "." & myfoundsong .getSongExtension)
    End Sub

    Private Sub subDownloadMusicFromPlaylist(playlistindex As Integer)
        Dim mysong As mp3Class = myPlaylist(playlistindex)
        Dim decryptedStr As String = decryptID(mysong.getSongdfsID)
        Dim dl As New WebClient
        dl.DownloadFileAsync(New Uri("http://m5.music.126.net/" & decryptedStr & "/" & mysong.getSongdfsID & "." & mysong.getSongExtension), Application.StartupPath & "\offline\" & mysong.getSongMainID & "." & mysong.getSongExtension)
    End Sub

    Private Sub lb_playlist_SelectedDC(sender As Object, e As EventArgs) Handles lb_playlist.DoubleClick
        If lb_playlist.SelectedItems.Count = 1 Then
            Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(lb_playlist.SelectedIndex)
            AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)
            If chb_dl.Checked Then
                subDownloadMusicFromPlaylist(lb_playlist.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_CurrentItemChange(sender As Object, e As _WMPOCXEvents_CurrentItemChangeEvent) Handles AxWindowsMediaPlayer1.CurrentItemChange
        ' lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.
        'Label1.Text = AxWindowsMediaPlayer1.Ctlcontr
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        writePlaylist(myPlaylist)

    End Sub

    Private Sub writePlaylist(ByVal playlist As List(Of mp3Class))

        If Not IO.Directory.Exists(Application.StartupPath & "\playlist") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\playlist")
        End If
        File.WriteAllText(playlistfile, "")
        Dim sep As String = "+*;*+"
        For Each song In playlist
            File.AppendAllText(playlistfile,
                   song.getSongMainID & sep & song.getSongMainName & sep & String.Join(",", song.getSongArtists) & sep & song.getSongAlbum & sep & song.getSongDuration & sep &
            song.getSongID & sep & song.getSongName & sep & song.getSongSize & sep & song.getSongExtension & sep &
                 song.getSongdfsID & sep & song.getSongPlaytime & sep & song.getSongBitrate & sep & song.getSongSR & sep &
                vbCrLf)
        Next
    End Sub

    Private Sub readPlaylist(ByVal playlistfilepath As String)
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(playlistfilepath, Encoding.Default)
        Dim a As String
        Dim sep As String = "+*;*+"
        Do
            a = reader.ReadLine
            Dim pl As String() = Strings.Split(a, sep)
            If pl.Length < 2 Then Exit Do

            Dim at As String() = Strings.Split(pl(2), ",")
            Dim atl As List(Of String) = at.ToList

            myPlaylist.Add(New mp3Class(pl(0), pl(1), atl, pl(3), pl(4), Nothing, pl(5), pl(6), pl(7), pl(8), pl(9), pl(10), pl(11), pl(12)))
            lb_playlist.Items.Add(pl(1))

            ' Code here
            '
        Loop Until a Is Nothing

        reader.Close()
        For Each pli In myPlaylist

            If File.Exists(Application.StartupPath & "\offline\" & pli.getSongMainID & "." & pli.getSongExtension) Then
                newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(Application.StartupPath & "\offline\" & pli.getSongMainID & "." & pli.getSongExtension))
                AxWindowsMediaPlayer1.currentPlaylist = newPlayList
            Else
                Dim decryptedStr As String = decryptID(pli.getSongdfsID)
                newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia("http://m5.music.126.net/" & decryptedStr & "/" & pli.getSongdfsID & "." & pli.getSongExtension))
                AxWindowsMediaPlayer1.currentPlaylist = newPlayList
            End If
            lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1
            Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)
        Next



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
            songURL = songC.getSongMP3URL.Replace("m2.", "m5.")
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

                lb_playlist.SelectedIndex = AxWindowsMediaPlayer1.currentPlaylist.count - 1
                Dim Media As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.currentPlaylist.Item(AxWindowsMediaPlayer1.currentPlaylist.count - 1)

                '  AxWindowsMediaPlayer1.Ctlcontrols.playItem(Media)

            End If
        End If
    End Sub


End Class
