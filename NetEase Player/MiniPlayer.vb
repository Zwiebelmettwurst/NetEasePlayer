Imports System.ComponentModel

Public Class MiniPlayer
    Private Sub MiniPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        AddHandler Form1.nextTrack, AddressOf mynextTrack
        TrackBar1.Value = Form1.AxWindowsMediaPlayer1.settings.volume
    End Sub
    Public Sub mynextTrack(ByVal mynextTrack As mp3Class)
        If Not mynextTrack Is Nothing Then
            lbl_songinfo.Text = mynextTrack.getSongMainName & " - " & mynextTrack.getSongArtists(0)
        Else
            lbl_songinfo.Text = "Unknown Track - Unknown Artist"
        End If

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Form1.AxWindowsMediaPlayer1.settings.volume = TrackBar1.Value

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.AxWindowsMediaPlayer1.Ctlcontrols.next()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.AxWindowsMediaPlayer1.Ctlcontrols.previous()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Form1.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Form1.AxWindowsMediaPlayer1.Ctlcontrols.pause()
        Else
            Form1.AxWindowsMediaPlayer1.Ctlcontrols.play()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Form1.AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub

    Private Sub MiniPlayer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.WindowState = FormWindowState.Normal
        Form1.ShowInTaskbar = True
    End Sub
End Class