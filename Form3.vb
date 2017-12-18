Imports System.Threading
Imports System.IO
Public Class Form3
    Dim FileURL As String
    Dim sparts() As String
    Dim TotalSize As Integer
    Dim download As Thread
    Public MissingFiles As String
    Dim FileError As Boolean

    Public Sub Downloader()

    End Sub

    Private Sub Filesdownload()
        'If Me.Visible = True Then

        For Each item As String In sparts
            'MsgBox("item:" & item)
            If item = String.Empty = False Then
                Label1.Text = "Downloading:" & item
                FileURL = item.Replace("\", "/")
                My.Computer.Network.DownloadFile("ftp://serverwebsite.ddns.net:2048/downloads/dvdkit/prerequisites" & FileURL, Application.StartupPath & item)
                If item = "\ffmpeg\bin\avcodec-57.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 27148
                End If
                If item = "\ffmpeg\bin\avdevice-57.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 2187
                End If
                If item = "\ffmpeg\bin\avfilter-6.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 4301
                End If
                If item = "\ffmpeg\bin\avformat-57.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 5413
                End If
                If item = "\ffmpeg\bin\avutil-55.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 638
                End If
                If item = "\ffmpeg\bin\postproc-54.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 125
                End If
                If item = "\ffmpeg\bin\swresample-2.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 338
                End If
                If item = "\ffmpeg\bin\swscale-4.dll" Then
                    ProgressBar1.Value = ProgressBar1.Value + 523
                End If
                If item = "\ffmpeg\bin\ffmpeg.exe" Then
                    ProgressBar1.Value = ProgressBar1.Value + 273
                End If
                If item = "\ffmpeg\bin\ffprobe.exe" Then
                    ProgressBar1.Value = ProgressBar1.Value + 1468
                End If
            End If
        Next
        Label1.Text = "Download complete"
        download.Abort()
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If File.Exists(Application.StartupPath & "\ffmpeg\bin\avcodec-57.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\avcodec-57.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\avdevice-57.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\avdevice-57.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\avfilter-6.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\avfilter-6.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\avformat-57.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\avformat-57.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\avutil-55.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\avutil-55.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\postproc-54.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\postproc-54.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\swresample-2.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\swresample-2.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\swscale-4.dll") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\swscale-4.dll"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\ffmpeg.exe") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\ffmpeg.exe"
            FileError = True
        End If
        If File.Exists(Application.StartupPath & "\ffmpeg\bin\ffprobe.exe") = False Then
            MissingFiles = MissingFiles + ":\ffmpeg\bin\ffprobe.exe"
            FileError = True
        End If
        If FileError = False Then
            MsgBox("All files and prerequisites are present")
        Else
            Label1.Text = "Files need to be downloaded"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FileError = False Then
            MsgBox("All files and prerequisites are present")
            GoTo EndUpdate
        End If

        'MsgBox(MissingFiles)

        sparts = MissingFiles.Split(":")

        For Each item As String In sparts
            If item = String.Empty = False Then
                If item = "\ffmpeg\bin\avcodec-57.dll" Then
                    TotalSize = TotalSize + 27148
                End If
                If item = "\ffmpeg\bin\avdevice-57.dll" Then
                    TotalSize = TotalSize + 2187
                End If
                If item = "\ffmpeg\bin\avfilter-6.dll" Then
                    TotalSize = TotalSize + 4301
                End If
                If item = "\ffmpeg\bin\avformat-57.dll" Then
                    TotalSize = TotalSize + 5413
                End If
                If item = "\ffmpeg\bin\avutil-55.dll" Then
                    TotalSize = TotalSize + 638
                End If
                If item = "\ffmpeg\bin\postproc-54.dll" Then
                    TotalSize = TotalSize + 125
                End If
                If item = "\ffmpeg\bin\swresample-2.dll" Then
                    TotalSize = TotalSize + 338
                End If
                If item = "\ffmpeg\bin\swscale-4.dll" Then
                    TotalSize = TotalSize + 523
                End If
                If item = "\ffmpeg\bin\ffmpeg.exe" Then
                    TotalSize = TotalSize + 283
                End If
                If item = "\ffmpeg\bin\ffprobe.exe" Then
                    TotalSize = TotalSize + 1468
                End If
            End If
        Next
        ProgressBar1.Maximum = TotalSize
        download = New Thread(AddressOf Filesdownload)
        download.Start()
EndUpdate:
    End Sub
End Class