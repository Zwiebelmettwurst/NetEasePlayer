Option Strict On

Imports System.IO
Imports System.Net
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.RegularExpressions
Imports SpotifyAPI.Web
Imports SpotifyAPI.Web.Auth
Imports SpotifyAPI.Web.Enums
Imports SpotifyAPI.Web.Models
Imports Newtonsoft.Json


Public Class Form_SpotifyRip
    Dim cookieCon As New CookieContainer
    Dim request As HttpWebRequest
    Dim seitenQuelltext As String
    Private _spotify As SpotifyWebAPI
    Private _auth As ImplicitGrantAuth
    Dim newplaylist As Paging(Of PlaylistTrack)
    Private _profile As PrivateProfile
    Private _savedTracks As List(Of FullTrack)
    Private _playlists As List(Of SimplePlaylist)
    Private myplaylistbeforespotify As New List(Of mp3Class)
    Dim getSongInfo As New List(Of SongClass)
    Dim checker As Boolean = False

    ' Dim songclasstoimport As New List(Of SongClass)
    Public Event newSongClassArrived(ByVal newSongClass As SongClass)
    Public Sub New(ByVal myplaylist As List(Of mp3Class))
        InitializeComponent()
        myplaylistbeforespotify = myplaylist
        _savedTracks = New List(Of FullTrack)()

        _auth = New ImplicitGrantAuth() With {
        .RedirectUri = "http://localhost:53647",
        .ClientId = "9e9a425cba8f446f8f39bf7c2c34a22c",
        .Scope = Scope.UserReadPrivate Or Scope.PlaylistReadPrivate Or Scope.UserReadPrivate,
        .State = "XSS"
        }

        AddHandler _auth.OnResponseReceivedEvent, AddressOf _auth_OnResponseReceivedEvent
    End Sub

    Private Sub _auth_OnResponseReceivedEvent(token As Token, state As String)
        _auth.StopHttpServer()

        If state <> "XSS" Then
            MessageBox.Show("Wrong state received.", "SpotifyWeb API Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If
        If token.[Error] IsNot Nothing Then
            MessageBox.Show("Error: {token.Error}", "SpotifyWeb API Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        _spotify = New SpotifyWebAPI() With {
              .UseAuth = True,
               .AccessToken = token.AccessToken,
                .TokenType = token.TokenType
            }

        '   TextBox1.Text = _spotify.AccessToken

        If txt_spotifyplaylist.Text.StartsWith("https") Then
            Me.Activate()
            Me.Focus()


            Dim mr As New Regex("https:\/\/(?:play|open).spotify.com\/user\/(.*)\/playlist\/(.*)")
            Dim myURL As String = txt_spotifyplaylist.Text

            Dim mym As Match = mr.Match(myURL)
            If mym.Success Then
                newplaylist = _spotify.GetPlaylistTracks(mym.Groups(1).ToString, mym.Groups(2).ToString)
                _profile = _spotify.GetPrivateProfile
                lbl_spotifyuser.Text = "Welcome, " & _profile.DisplayName & "!"

                If newplaylist.Items.Count > 0 Then

                    '         newplaylist.Items.ForEach(Function(track) Console.WriteLine(track.Track.Name))
                    For Each track In newplaylist.Items
                        '   Dim artistsstring As String = t
                        'For Each a In track.Track.Artists
                        '    artistsstring
                        'Next
                        lvwAddItem(lvw_spotify, Nothing, track.Track.Name, track.Track.Artists(0).Name, track.Track.Album.Name, timemiltommss(track.Track.DurationMs.ToString))

                        '     ListBox1.Items.Add(track.Track.)
                    Next
                    btn_importchecked.Enabled = True

                End If
            End If
        End If


        'InitialSetup()
    End Sub


    Private Function GetSavedTracks() As List(Of FullTrack)
        Dim savedTracks As Paging(Of SavedTrack) = _spotify.GetSavedTracks()
        Dim list As List(Of FullTrack) = savedTracks.Items.[Select](Function(track) track.Track).ToList()

        While savedTracks.[Next] IsNot Nothing
            savedTracks = _spotify.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit)
            list.AddRange(savedTracks.Items.[Select](Function(track) track.Track))
        End While

        Return list
    End Function

    Private Function GetPlaylists() As List(Of SimplePlaylist)
        Dim playlists As Paging(Of SimplePlaylist) = _spotify.GetUserPlaylists(_profile.Id)
        Dim list As List(Of SimplePlaylist) = playlists.Items.ToList()

        While playlists.[Next] IsNot Nothing
            playlists = _spotify.GetUserPlaylists(_profile.Id, 20, playlists.Offset + playlists.Limit)
            list.AddRange(playlists.Items)
        End While

        Return list
    End Function


    Private Sub btn_spotifyplrip_Click(sender As Object, e As EventArgs) Handles btn_spotifyplrip.Click
        'doSpotify()
        'Dim s As New Threading.Thread(AddressOf doSpotify)
        's.IsBackground = True
        's.Start()
        lvw_spotify.Items.Clear()
        btn_importchecked.Enabled = False
        _auth.StartHttpServer(53647)
        _auth.DoAuth()

    End Sub

    'Private Sub doSpotify()
    '    If txt_spotifyplaylist.Text.StartsWith("https") Then
    '        Dim mr As New Regex("https:\/\/play.spotify.com\/user\/(.*)\/playlist\/(.*)")
    '        Dim myURL As String = txt_spotifyplaylist.Text

    '        Dim mym As Match = mr.Match(myURL)
    '        If mym.Success Then

    '            Dim newplaylist As Paging(Of PlaylistTrack) = _spotify.GetPlaylistTracks(mym.Groups(1).ToString, mym.Groups(2).ToString)
    '            '         newplaylist.Items.ForEach(Function(track) Console.WriteLine(track.Track.Name))
    '            For Each track In newplaylist.Items
    '                ListBox1.Items.Add(track.Track.Name)
    '            Next


    '            MsgBox(mym.Groups(1).ToString)
    '            MsgBox(mym.Groups(2).ToString)
    '            Dim AccessToken As String = "BQAcfHKh5cIihApOp3TFzqCP10HgRKLK4JWG-o0hckaBbsJYsLT3aDnVkdr1gTmRjXrwbOAufzsqvrBxF6ww0m0OwxUBfYXiVFmXrU0EQmLO5S7_Azmg_WGoWZCLXg8r3OUp_M5T-BMrDtfD39bMVWC80n-XlHMYSjbFCXmNHyPJt_y0a1BLMLHP0iMNjqlJ4wnq37vpDjfUNZTsBKdol0o4WBs9l9EttBS8HPylFExXxNibsBo"
    '            request = DirectCast(HttpWebRequest.Create("https://api.spotify.com/v1/users/" & mym.Groups(1).ToString & "/playlists/" & mym.Groups(2).ToString & "/tracks"), HttpWebRequest)
    '            request.Headers.Add("Authorization", "Bearer " + AccessToken)

    '            request.Method = "GET"
    '            request.CookieContainer = cookieCon
    '            request.Host = "api.spotify.com"
    '            request.UserAgent = "Spotify API Console v0.1"
    '            request.ContentType = "application/json"
    '            '    request.Host = "streamcloud.eu"
    '            request.Accept = "application/json"


    '            'request.Headers.Add(New AuthenticationHeaderValue("Bearer", "BQDP8IYgX2fbohjdX1wAEcWszJZ1nh1wSv-CU6mGwmR1h-qDIgdlYn6jdMi5RYqA-QKO-yZlDEcn9NDp9rZr7_DV6s8PaTV5T31WYFJuIbrnR8nLfvlgl_Pgk8XUZOm7KIYl6O9go_o9KjQi0prAD9s")
    '            ' request.Headers.Add("Authorization", "Bearer " + AccessToken)
    '            ' request.Headers.Add("Authorization: Bearer BQDP8IYgX2fbohjdX1wAEcWszJZ1nh1wSv-CU6mGwmR1h-qDIgdlYn6jdMi5RYqA-QKO-yZlDEcn9NDp9rZr7_DV6s8PaTV5T31WYFJuIbrnR8nLfvlgl_Pgk8XUZOm7KIYl6O9go_o9KjQi0prAD9s")
    '            '  curl -X GET "https://api.spotify.com/v1/users/k3174r0/playlists/7hUhKnkbrFJLefHeKVz3D6/tracks" -H "Accept: application/json" -H "Authorization: Bearer BQDP8IYgX2fbohjdX1wAEcWszJZ1nh1wSv-CU6mGwmR1h-qDIgdlYn6jdMi5RYqA-QKO-yZlDEcn9NDp9rZr7_DV6s8PaTV5T31WYFJuIbrnR8nLfvlgl_Pgk8XUZOm7KIYl6O9go_o9KjQi0prAD9s"


    '            '  request.Referer = "http://music.163.com"
    '            '     Dim dataStream As Stream = request.GetRequestStream()

    '            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

    '            ' response = DirectCast(request.GetResponse(), HttpWebResponse)

    '            Dim reader As New StreamReader(response.GetResponseStream(), Encoding.ASCII)
    '            seitenQuelltext = reader.ReadToEnd()

    '        End If



    '    End If

    'End Sub

    Private Sub Form_SpotifyRip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    _auth.StartHttpServer(8000)
    '    _auth.DoAuth()


    'End Sub

    Private Sub btn_importchecked_Click(sender As Object, e As EventArgs) Handles btn_importchecked.Click


        Dim t As New Threading.Thread(AddressOf doQuery)
        t.IsBackground = True
        t.Start()

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
    Private Sub doQuery()
        'If txt_searchQuery.Text.Length < 1 Then Exit Sub
        'btn_searchQuery.Enabled = False
        'lbl_status.Text = "searching..."
        btn_importchecked.Enabled = False

        'For Each checked As ListViewItem In lvw_spotify.Items

        'Next


        For Each track In newplaylist.Items
            Dim ot As Boolean = False

            For Each oldtrack In myplaylistbeforespotify
                If oldtrack.getSongMainName = track.Track.Name Then
                    ot = True
                    Exit For

                End If

            Next
            If ot = True Then Continue For
            Try
                Dim purifiedTrack As String = track.Track.Name
                If track.Track.Name.Contains("(") And track.Track.Name.Contains(")") Then
                    purifiedTrack = Regex.Replace(purifiedTrack, "\(.*\)", String.Empty).Trim()
                End If

                Dim querystr As String = purifiedTrack & " " & track.Track.Artists(0).Name

                Dim myApi As String = getApi("http://music.163.com/api/search/get/", querystr, "50")
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


                '   getSongInfo.Clear()


                For Each songi In mynewSongs.Children
                    '   If Unicode2UTF8(songi.Item("name").ToString) <> track.Track.Name Then Continue For
                    '    If Not Unicode2UTF8(songi.Item("name").ToString).Contains(track.Track.Name) Or Not track.Track.Name.Contains(Unicode2UTF8(songi.Item("name").ToString)) Then Continue For
                    'If track.Track.Name.Length >= Unicode2UTF8(songi.Item("name").ToString).Length Then
                    '    If Not track.Track.Name.Contains(Unicode2UTF8(songi.Item("name").ToString)) Then Continue For

                    'Else
                    '    If Not Unicode2UTF8(songi.Item("name").ToString).Contains(track.Track.Name) Then Continue For


                    'End If




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
                    If track.Track.Name.Contains(foundSound.getSongName) Or foundSound.getSongName.Contains(track.Track.Name) Then
                        If track.Track.DurationMs <= CInt(foundSound.getSongDuration) + 2000 And track.Track.DurationMs >= CInt(foundSound.getSongDuration) - 2000 Then
                            '  songclasstoimport.Add(foundSound)
                            RaiseEvent newSongClassArrived(foundSound)

                            Exit For
                        End If
                    End If

                    '    Dim mvidcheck As String = "✖"
                    '    If Not foundSound.getSongMVID = "0" Then
                    '        mvidcheck = "✔"
                    '    End If
                    '    lvwAddItem(lvw_Songs, foundSound.getSongID, foundSound.getSongName, foundSound.getSongArtists(0), foundSound.getSongAlbum, timemiltommss(foundSound.getSongDuration), (CInt(getBestMusic(foundSound).getSongBitrate) / 1000).ToString & " kbit/s", mvidcheck)
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
        btn_importchecked.Enabled = True
        'lbl_status.Text = ""
        'btn_searchQuery.Enabled = True
    End Sub

    Private Sub btn_checkuncheckall_Click(sender As Object, e As EventArgs) Handles btn_checkuncheckall.Click

        For Each item As ListViewItem In lvw_spotify.Items
            If checker = False Then
                item.Checked = True
            Else
                item.Checked = False

            End If
        Next
        checker = Not checker

    End Sub
End Class