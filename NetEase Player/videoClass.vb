Imports NetEase_Player

Public Class videoClass : Implements IEquatable(Of videoClass)
    Dim MVID As String
    Dim videoName As String
    Dim videoArtist As String
    Dim videoDuration As String
    Dim q240 As String
    Dim q480 As String
    Dim q720 As String
    Dim q1080 As String

    Public Sub New(ByVal MVID As String, ByVal videoName As String, ByVal videoArtist As String, ByVal videoDuration As String,
                   ByVal q240 As String, ByVal q480 As String, ByVal q720 As String, ByVal q1080 As String)
        Me.MVID = MVID
        Me.videoName = videoName
        Me.videoArtist = videoArtist
        Me.videoDuration = videoDuration
        Me.q240 = q240
        Me.q480 = q480
        Me.q720 = q720
        Me.q1080 = q1080

    End Sub
    Public Overloads Function Equals(other As videoClass) As Boolean _
                   Implements IEquatable(Of videoClass).Equals
        If other Is Nothing Then Return False
        Return other.MVID.Equals(Me.MVID)
    End Function

    Public Function getMVID() As String
        Return Me.MVID
    End Function
    Public Function getvideoName() As String
        Return Me.videoName
    End Function
    Public Function getvideoArtist() As String
        Return Me.videoArtist
    End Function
    Public Function getvideoDuration() As String
        Return Me.videoDuration
    End Function

    Public Function getq240video() As String
        Return Me.q240
    End Function
    Public Function getq480video() As String
        Return Me.q480
    End Function
    Public Function getq720video() As String
        Return Me.q720
    End Function
    Public Function getq1080video() As String
        Return Me.q1080
    End Function
End Class
