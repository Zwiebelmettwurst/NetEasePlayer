Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Public Class MusicVideoForm
    Private mvid As String
    Dim newMV As videoClass
    Dim cookieCon As New CookieContainer
    Dim request As HttpWebRequest
    Dim seitenQuelltext As String
    'Public Sub New()
    '    InitializeComponent()
    'End Sub

    Public Sub New(ByVal newmvid As String)
        InitializeComponent()

        mvid = newmvid
    End Sub

    Private Sub doVideo()

        'Dim wc As New WebClient
        'wc.Headers.Add("Referer", "http://music.163.net")
        'wc.Headers.Add("Cookie", "appver 2.0.2")
        'wc.header


        request = DirectCast(HttpWebRequest.Create("http://music.163.com/api/mv/detail?id=" & mvid), HttpWebRequest)
        request.Method = "GET"
        request.CookieContainer = cookieCon
        '     request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0"
        request.ContentType = "application/x-www-form-urlencoded"
        '    request.Host = "streamcloud.eu"
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
        request.Headers.Add("Cookie: appver = 2.0.2")

        request.Referer = "http://music.163.com"
        '     Dim dataStream As Stream = request.GetRequestStream()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

        response = DirectCast(request.GetResponse(), HttpWebResponse)

        Dim reader As New StreamReader(response.GetResponseStream(), Encoding.ASCII)
        seitenQuelltext = reader.ReadToEnd()


        Dim mv = Linq.JObject.Parse(seitenQuelltext)
        ' Dim c As Linq.JToken = song.Item("result")("songs")
        If mv.Item("code").ToString = "200" Then
            Dim q240 As String = ""
            Dim q480 As String = ""
            Dim q720 As String = ""
            Dim q1080 As String = ""
            'If Not IsDBNull(mv.Item("data")("brs")("240")) Then
            '    q240 = mv.Item("data")("brs")("240").ToString
            'End If
            'If Not IsDBNull(mv.Item("data")("brs")("480")) Then
            '    q480 = mv.Item("data")("brs")("480").ToString
            'End If
            'If Not IsDBNull(mv.Item("data")("brs")("720")) Then
            '    q720 = mv.Item("data")("brs")("720").ToString
            'End If
            'If Not IsDBNull(mv.Item("data")("brs")("1080").i) Then
            '    q1080 = mv.Item("data")("brs")("1080").ToString
            'End If
            Dim videourls As New List(Of String)

            For i As Integer = 0 To mv.Item("data")("brs").Count - 1
                Dim getVideo As String = mv.Item("data")("brs").ElementAt(i).ToString
                Dim r As New Regex("http+(.*?)mp4")



                videourls.Add(r.Match(getVideo).Value)

            Next
            newMV = New videoClass(mvid, mv.Item("data")("name").ToString, mv.Item("data")("artistName").ToString, mv.Item("data")("duration").ToString, q240, q480, q720, q1080)
            Me.Text = newMV.getvideoName & " - " & newMV.getvideoArtist
            AxWindowsMediaPlayer1.URL = videourls.First
            '.LastbestVideoQuality()
        End If
    End Sub

    Private Sub MusicVideoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim v As New Threading.Thread(AddressOf doVideo)
        v.IsBackground = True
        v.Start()


    End Sub
    Private Function bestVideoQuality(ByVal MV As videoClass) As String
        If MV.getq1080video.StartsWith("http") Then Return MV.getq1080video
        If MV.getq720video.StartsWith("http") Then Return MV.getq720video
        If MV.getq480video.StartsWith("http") Then Return MV.getq480video
        If MV.getq240video.StartsWith("http") Then Return MV.getq240video
        Return ""

    End Function
End Class