Imports System.Threading
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Security
Imports System.ComponentModel
'Imports System.Windows.Shell
Imports System.Windows
Public Class Form1
    Dim ImpPath As String
    Dim ExpPath As String
    Dim ExpFile As String
    Dim command As String
    Dim converter As Thread
    Dim GetFrames As New Process()
    Dim GetFramesInfo As New ProcessStartInfo(Application.StartupPath & "\GetFrames.bat")
    Dim GetVidAudioInfo As New ProcessStartInfo(Application.StartupPath & "\GetVidAudioInfo.bat")
    Dim Conversion As New Process()
    Dim ConversionInfo As New ProcessStartInfo(Application.StartupPath & "\converter.bat")
    Dim GetFullDVDFrames As New Process
    Dim GetFullDVDFramesInfo As New ProcessStartInfo(Application.StartupPath & "\GetFullDVDFrames.bat")
    Public frames As Integer
    Dim DVDImpPath As String
    Dim VobPath As String
    Dim DVDItems() As String
    Dim DVDFilesCount As Integer
    Dim FullDVDFrames As Integer
    Dim FullDVDItems() As String = New String() {}
    Dim RipDVD As New Process()
    Dim RipFullDVD As New Process()
    Dim RipFullDVDInfo As New ProcessStartInfo(Application.StartupPath & "\RipFullDVD.bat")
    Dim GetAudioPic As New Process()
    Dim GetAudioPicInfo As New ProcessStartInfo(Application.StartupPath & "\GetAudioPic.bat")
    Dim ExpQuality As String = " "
    Dim ripper As Thread
    Dim AlbumArt As Image
    Dim AlbumArtLocation As String
    Dim NewArtLocation As String
    Dim ReplaceCover As New Process()
    Dim ReplaceCoverInfo As New ProcessStartInfo(Application.StartupPath & "\ReplaceCover.bat")
    Dim MusicStatus As Boolean
    Dim VidPath As String
    Dim GetAudioStuff As New Process()
    Dim GetAudioStuffInfo As New ProcessStartInfo(Application.StartupPath & "\GetAudioStuff.bat")
    Public AudioTitle As String
    Public AudioArtist As String
    Public AudioAlbum As String
    Public AudioGenre As String
    Public AudioComposer As String
    Public AudioComment As String
    Dim FrameError As Boolean
    Dim AudioID3Changed As Boolean
    Dim AudioArtChanged As Boolean
    Dim NewArt As String
    Dim ChangeAudioStuff As New Process()
    Dim ChangeAudioStuffInfo As New ProcessStartInfo(Application.StartupPath & "\ChangeAudioStuff.bat")
    Dim YoutubeURL As String
    Dim GetVideoQuality As New Process
    Dim GetVideoQualityInfo As New ProcessStartInfo(Application.StartupPath & "\GetVideoQuality.bat")
    Dim FormatCount As Integer
    Dim FormatNumber() As String
    Dim FormatFileType() As String
    Dim FormatSize() As String
    Dim FormatType() As String
    Dim FormatQualityIndex() As String
    Dim FormatResolution() As String
    Dim UsingMethod As String
    Dim GetVideoThumbnail As New Process()
    Dim GetVideoThumbnailInfo As New ProcessStartInfo(Application.StartupPath & "\GetVideoThumbnail.bat")
    Dim DownloadMP3 As New Process()
    Dim DownloadMP3Info As New ProcessStartInfo(Application.StartupPath & "\DownloadMP3.bat")
    Dim downloader As Thread
    Dim FileName As String
    Dim OriginalName As String
    Dim OriginalExtension As String
    Dim DownloadMP3Only As New Process()
    Dim DownloadMP3OnlyInfo As New ProcessStartInfo(Application.StartupPath & "\DownloadOnlyMP3.bat")
    'Dim TaskBarValue As System.Windows.Shell
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = ("Select the media file you would want to convert")
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            ImpPath = OpenFileDialog1.FileName
            Label2.Text = OpenFileDialog1.SafeFileName
            RichTextBox1.AppendText(DateTime.Now & "  selected file: " & OpenFileDialog1.FileName & vbCrLf)
            AxWindowsMediaPlayer1.URL = ImpPath


        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If File.Exists(Application.StartupPath & "\ffmpeg\bin\ffmpeg.exe") = False Then
        'Dim result1 As Integer = MessageBox.Show("Some prerequisites have not been found. Would you like to download them?", "Prerequisites error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
        'If result1 = DialogResult.Yes Then
        'MsgBox("Downloading...")
        'Else
        '
        'End If
        'End If
        'Form2.AppStart.Abort()
        ComboBox1.Items.Add("MPEG-4 H.264 Video/ MP4")
        ComboBox1.Items.Add("Windows Media Video / WMV")
        ComboBox1.Items.Add("Audio video Interleaved / AVI")
        ComboBox1.Items.Add("Matroska video / MKV")
        ComboBox1.Items.Add("Flash video / flv")
        ComboBox1.Items.Add("Graphics Interlaced Format / GIF")
        ComboBox1.Items.Add("Shockwave Flash / SWF")
        ComboBox3.Items.Add("MPEG 4 / MP4")
        ComboBox3.Items.Add("Matroska Video / mkv")
        ComboBox3.Items.Add("Flash Video / flv")
        ComboBox2.Items.Add("original")
        ComboBox2.Items.Add("4K UHD")
        ComboBox2.Items.Add("1080p")
        ComboBox2.Items.Add("900p")
        ComboBox2.Items.Add("720p")
        ComboBox2.Items.Add("DVGA (1136x640)")
        ComboBox2.Items.Add("SVGA (800x600)")
        ComboBox2.Items.Add("QVGA (320x240)")
        ComboBox2.Items.Add("WQVGA (320x320)")
        ComboBox2.Items.Add("WSXGA (1440x900)")
        ComboBox2.Items.Add("SXGA (1280x1024)")
        ComboBox2.Items.Add("SXGA+ (1400x1050)")
        ComboBox2.Items.Add("480p")
        ComboBox2.Items.Add("360p")
        ComboBox2.Items.Add("240p")
        ComboBox2.Items.Add("144p")
        ComboBox2.Items.Add("Custom")
        MusicStatus = False
        OpenFileDialog1.Filter = "All Supported Formats (*.mp4,*.avi,*.mkv ,*.swf, *.m4v, *.flv, *.gif, *.mxf, *.3gp, *.3g2, *.mov, *.webm)|*.flv; *.mp4; *.m4v; *.swf; *.mkv; *.avi; *.gif; *.mxf; *.3gp; *.3g2; *.mov; *.webm"
        Button13.Enabled = False
        Button14.Enabled = False
        Button16.Enabled = False
        Button18.Enabled = False
        Button19.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
        'ExpPath = FolderBrowserDialog1.SelectedPath

        'End If
        Dim type As String
        type = ComboBox1.SelectedItem
        If type = "Matroska video / MKV" Then
            SaveFileDialog1.Filter = ("Matroska Video Files (*.mkv)|*.mkv")
        ElseIf type = "Windows Media Video / WMV" Then
            SaveFileDialog1.Filter = ("Windows Media Video(*.wmv)|*.wmv")
        ElseIf type = "MPEG-4 H.264 Video/ MP4" Then
            SaveFileDialog1.Filter = "MPEG-4 Video (*.mp4) |*.mp4"
        ElseIf type = "Audio video Interleaved / AVI" Then
            SaveFileDialog1.Filter = "Audio Video Interleaved (*.avi) |*.avi"
        ElseIf type = "Flash video / flv" Then
            SaveFileDialog1.Filter = "Flash video (*.flv) |*.flv"
        ElseIf type = "Graphics Interlaced Format / GIF" Then
            SaveFileDialog1.Filter = "Graphics Interlaced Format (*.gif) |*.gif"
        ElseIf type = "Shockwave Flash / SWF" Then
            SaveFileDialog1.Filter = "Shockwave Flash (*.swf) |*.swf"
        End If
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            ExpFile = SaveFileDialog1.FileName
            RichTextBox1.AppendText(DateTime.Now & "  Output file location: " & ExpFile & vbCrLf)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Name() As String
        Dim filetype As String
        Dim typeset As String

        If ComboBox2.SelectedItem = "original" Then
            ExpQuality = " "
        ElseIf ComboBox2.SelectedItem = "4K UHD" Then
            ExpQuality = " -vf scale=3840:2160 "
        ElseIf ComboBox2.SelectedItem = "1080p" Then
            ExpQuality = " -vf scale=1920:1080 "
        ElseIf ComboBox2.SelectedItem = "900p" Then
            ExpQuality = " -vf scale=1600:900 "
        ElseIf ComboBox2.SelectedItem = "720p" Then
            ExpQuality = " -vf scale=1280:720 "
        ElseIf ComboBox2.SelectedItem = "DVGA" Then
            ExpQuality = " -vf scale=1136:640 "
        ElseIf ComboBox2.SelectedItem = "SVGA" Then
            ExpQuality = " -vf scale=800:600 "
        ElseIf ComboBox2.SelectedItem = "QVGA" Then
            ExpQuality = " -vf scale=320:240 "
        ElseIf ComboBox2.SelectedItem = "WQVGA" Then
            ExpQuality = " -vf scale=320:320 "
        ElseIf ComboBox2.SelectedItem = "WSXGA" Then
            ExpQuality = " -vf scale=1440:900 "
        ElseIf ComboBox2.SelectedItem = "SXGA" Then
            ExpQuality = " -vf scale=1280:1024 "
        ElseIf ComboBox2.SelectedItem = "SXGA+" Then
            ExpQuality = " -vf scale=1400:1050 "
        ElseIf ComboBox2.SelectedItem = "480p" Then
            ExpQuality = " -vf scale=640:480 "
        ElseIf ComboBox2.SelectedItem = "360p" Then
            ExpQuality = " -vf scale=480:360 "
        ElseIf ComboBox2.SelectedItem = "240p" Then
            ExpQuality = " -vf scale=352:240 "
        ElseIf ComboBox2.SelectedItem = "144p" Then
            ExpQuality = " -vf scale=256:144 "
        End If
        typeset = ComboBox1.SelectedItem
        Name = OpenFileDialog1.SafeFileName.Split(".")
        'If typeset = "Matroska video / MKV" Then
        'ExpFile = ExpPath & "\" & "(CONVERTED)" & Name(0) & ".mkv"
        'MsgBox(ExpFile)
        ' End If
        converter = New Thread(AddressOf Converterthread)
        RichTextBox1.AppendText(DateTime.Now & "  creating conversion thread" & vbCrLf)
        converter.Start()
        RichTextBox1.AppendText(DateTime.Now & " Launched conversion thread with ID " & converter.ManagedThreadId & vbCrLf)
    End Sub
    Public Sub Converterthread()

        Dim command1_1 As String
        Dim command1_2 As String
        RichTextBox1.AppendText(DateTime.Now & " Creating commands" & vbCrLf)
        command1_1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
        command1_2 = "ffprobe -select_streams v -show_streams " & Chr(34) & ImpPath & Chr(34)
        RichTextBox1.AppendText(DateTime.Now & "  Writing to GetFrames.bat" & vbCrLf)
        Dim editBAT As StreamWriter
        editBAT = New StreamWriter(Application.StartupPath & "\GetFrames.bat")
        editBAT.WriteLine(command1_1)
        editBAT.WriteLine(command1_2)
        editBAT.Close()
        RichTextBox1.AppendText(DateTime.Now & "  Successfully wrote to GetFrames.bat" & vbCrLf)
        GetFramesInfo.RedirectStandardError = True
        GetFramesInfo.RedirectStandardInput = True
        GetFramesInfo.RedirectStandardOutput = True
        GetFramesInfo.CreateNoWindow = True
        GetFramesInfo.UseShellExecute = False
        GetFramesInfo.WindowStyle = ProcessWindowStyle.Hidden
        GetFrames.StartInfo = GetFramesInfo
        RichTextBox1.AppendText(DateTime.Now & "  Starting process GetFrames.bat" & vbCrLf)
        GetFrames.Start()
        RichTextBox1.AppendText(DateTime.Now & " process GetFrames.bat started with ID " & GetFrames.Id & vbCrLf)
        Dim output_1 As String
        output_1 = GetFrames.StandardOutput.ReadToEnd()
        'MsgBox(output_1)
        Dim output_11() As String
        output_11 = Regex.Split(output_1, "nb_frames=")
        Dim output_12() As String
        output_12 = output_11(1).Split(Chr(10))
        'MsgBox(output_12(0))
        RichTextBox1.AppendText(DateTime.Now & " GetFrames.bat completed")
        If output_12(0).Contains("N/A") Then
            RichTextBox1.AppendText(DateTime.Now & " Error in reading frame count, will not use progress bar")
            FrameError = True
            GoTo FramesDone
        Else
            FrameError = False
            frames = output_12(0)
            ProgressBar1.Maximum = frames
        End If

FramesDone:
        RichTextBox1.AppendText(DateTime.Now & "  No. of frames is " & frames & vbCrLf)
        Dim command2_1 As String
        Dim command2_2 As String
        command2_1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
        command2_2 = "ffmpeg -i " & Chr(34) & ImpPath & Chr(34) & ExpQuality & Chr(34) & ExpFile & Chr(34)
        RichTextBox1.AppendText(DateTime.Now & "  Writing to converter.bat" & vbCrLf)
        editBAT = New StreamWriter(Application.StartupPath & "\converter.bat")
        editBAT.WriteLine(command2_1)
        editBAT.WriteLine(command2_2)
        editBAT.Close()
        RichTextBox1.AppendText(DateTime.Now & "  Successfully written to converter.bat" & vbCrLf)
        RichTextBox1.AppendText(DateTime.Now & "  Applying batch settings" & vbCrLf)
        ConversionInfo.RedirectStandardError = True
        ConversionInfo.RedirectStandardInput = True
        ConversionInfo.RedirectStandardOutput = True
        ConversionInfo.CreateNoWindow = True
        ConversionInfo.UseShellExecute = False
        ConversionInfo.WindowStyle = ProcessWindowStyle.Hidden
        'AddHandler Conversion.OutputDataReceived, AddressOf ChangePercent
        'AddHandler Conversion.ErrorDataReceived, AddressOf ChangeErrorpercent
        Conversion.StartInfo = ConversionInfo
        AddHandler Conversion.Exited, AddressOf FinishedConversion
        RichTextBox1.AppendText(DateTime.Now & "  Starting process converter.bat" & vbCrLf)
        'MsgBox("test1")
        Conversion.Start()
        RichTextBox1.AppendText(DateTime.Now & "  Successfully started process converter.bat with ID " & Conversion.Id & vbCrLf)
        Dim ErrorRead As StreamReader = Conversion.StandardError
        RichTextBox1.AppendText(DateTime.Now & "  Reading output" & vbCrLf)
        'Conversion.BeginOutputReadLine()
        'Conversion.BeginErrorReadLine()
        'MsgBox("Pausing thread 1000")
        'Thread.Sleep(1000)
        'Conversion.WaitForExit()
        'MsgBox("reached")
        'Conversion.Close()
        GetErrorOutput(ErrorRead)
        Conversion.WaitForExit()
        Conversion.Close()
        ProgressBar1.Value = "0"
        Label9.Text = "Current Frame:"
        MsgBox("Completed")
        converter.Abort()
    End Sub

    'Private Sub ChangePercent(sendingProcess As Object, Input As DataReceivedEventArgs)
    'Dim test() As String
    'Dim count As Integer
    'Do
    '   count = count + 1
    '    MsgBox(Input.Data)
    '     MsgBox(Input.Data.ToString)
    '      test(count) = Input.Data
    '   Loop Until String.IsNullOrEmpty(Input.Data)
    'End Sub

    Private Sub ChangeErrorPercent(sendingProcess As Object, Input As DataReceivedEventArgs)
        Dim test() As String
        Dim count As Integer
        Do

            MsgBox(Input.Data)
            MsgBox(Input.Data.ToString)
            test(count) = Input.Data
        Loop Until String.IsNullOrEmpty(Input.Data)
    End Sub
    Private Async Sub GetErrorOutput(ErrorRead As StreamReader)
        Dim newline As String = Await ErrorRead.ReadLineAsync()
        Dim errors As String
        If newline IsNot Nothing Then
            'MsgBox(newline)
            RichTextBox1.AppendText(DateTime.Now & "  " & newline & vbCrLf)

            If newline.Contains("frame= ") Then
                Dim sparts() As String
                newline.Replace("frame= ", "")
                newline = (New Regex("frame= ").Replace(newline, ""))
                'MsgBox(newline)
                'sparts = Regex.Split(newline, "frame= ")
                'MsgBox(sparts(0))
                Dim sparts1() As String
                sparts = Regex.Split(newline, " fps=")
                'MsgBox(sparts(0))
                Dim CurrentFrame As String
                'MsgBox(sparts1(0))

                CurrentFrame = sparts(0)
                'MsgBox(CurrentFrame)
                If FrameError = False Then
                    ProgressBar1.Value = CurrentFrame
                End If
                'AxWindowsMediaPlayer1.
                Label9.Text = "Current Frame:" & CurrentFrame & "/" & frames & " (" & ((CurrentFrame / frames) * 100) & "%)"
            ElseIf newline.Contains("frame=") Then
                Dim sparts() As String
                newline.Replace("frame=", "")
                newline = (New Regex("frame=").Replace(newline, ""))
                'MsgBox(newline)
                'sparts = Regex.Split(newline, "frame= ")
                'MsgBox(sparts(0))
                Dim sparts1() As String
                sparts = Regex.Split(newline, " fps=")
                'MsgBox(sparts(0))
                Dim CurrentFrame As String
                'MsgBox(sparts1(0))

                CurrentFrame = sparts(0)
                'MsgBox(CurrentFrame)
                If CurrentFrame < ProgressBar1.Maximum Then
                    If FrameError = False Then
                        ProgressBar1.Value = CurrentFrame
                        Label9.Text = "Current Frame:" & CurrentFrame & "/" & frames & " (" & ((CurrentFrame / frames) * 100) & "%)"
                    End If
                    Label9.Text = "Current Frame:" & CurrentFrame & "/" & frames & " (" & ((CurrentFrame / frames) * 100) & "%)"
                Else
                    RichTextBox1.AppendText(DateTime.Now & "  Error: Frame count has exceeded number of frames, would pause progress bar" & vbCrLf)
                    errors = "ERROR:Current frame has exceeded max frame count"
                End If
                If errors IsNot Nothing Then
                    Label9.Text = "Current Frame:" & CurrentFrame & "/" & frames & " (" & (CurrentFrame / frames * 100) & "%)"
                Else
                    Label9.Text = errors
                End If
            End If
            GetErrorOutput(ErrorRead)

        End If
    End Sub
    Public Sub FinishedConversion(sender As Object, input As EventArgs)
        ProgressBar1.Value = "0"
        MsgBox("conversion is finished")
        converter.Abort()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Conversion.HasExited = False Then
            Conversion.Close()
            ProgressBar1.Value = "0"
            converter.Abort()
            MsgBox("conversion canceled", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            FullDVDFrames = 0
            DVDFilesCount = 0
            DVDImpPath = FolderBrowserDialog1.SelectedPath
            Label5.Text = "Selected Drive:" & FolderBrowserDialog1.SelectedPath
            VobPath = DVDImpPath & "VIDEO_TS\"
            DVDItems = IO.Directory.GetFiles(VobPath)
            Dim count As Integer
            count = 0
            'FullDVDItems(0) = "test"
            'FullDVDItems(1) = "test"
            For Each item As String In DVDItems

                'MsgBox(item)
                If item.Contains("VTS") And item.Contains(".VOB") Then
                    DVDFilesCount = DVDFilesCount + 1
                    ' MsgBox("progresstest")
                    'MsgBox(FullDVDItems(0))
                    'MsgBox(FullDVDItems(1))
                    ReDim Preserve FullDVDItems(DVDFilesCount - 1)
                    FullDVDItems(DVDFilesCount - 1) = item
                End If
            Next
            Label6.Text = "Files Present:" & DVDFilesCount

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If RadioButton2.Checked = True Then
            If ComboBox3.SelectedItem = "MPEG 4 / MP4" Then
                SaveFileDialog2.Filter = "MPEG-4 (*.mp4)|*.mp4"
            ElseIf ComboBox3.SelectedItem = "Matroska Video / mkv" Then
                SaveFileDialog2.Filter = "Matroska video (*.mkv)|*.mkv"
            ElseIf ComboBox3.SelectedItem = "Flash Video / flv" Then
                SaveFileDialog2.Filter = "Flash Video (*.flv)|*.flv"
            End If
            If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
                ExpFile = SaveFileDialog2.FileName
            Else
                GoTo finishsave
            End If
            ripper = New Thread(AddressOf Ripperthread)
            ripper.Start()
            RichTextBox1.AppendText(DateTime.Now & " Launched conversion thread with ID " & ripper.ManagedThreadId & vbCrLf)
finishsave:
        End If
        'MsgBox("started1")
    End Sub
    Public Sub Ripperthread()
        ' MsgBox("started2")

        'MsgBox("started3")
        Dim editBAT As StreamWriter
        editBAT = New StreamWriter(Application.StartupPath & "\GetFullDVDFrames.bat")
        editBAT.WriteLine("")
        editBAT.Close()
        'MsgBox("progresstest0")

        'MsgBox("progresstest1")
        Dim count As Integer
        FullDVDFrames = 0
        'MsgBox("progresstest2")
        Dim currentFrames As Integer
        Dim currentfps As Integer
        Dim currenttime As String
        Dim ctparts() As String
        Dim VidTime As Integer
        Dim t1, t2, t3 As Integer
        Dim VidFrames As Integer
        Dim command1_10 As String
        command1_10 = "ffmpeg -i " & Chr(34) & "concat:"
        For Each item As String In FullDVDItems
            editBAT = New StreamWriter(Application.StartupPath & "\GetFullDVDFrames.bat")
            'MsgBox("progresstest3")
            count = count + 1
            Dim command1_1 As String
            Dim command1_2 As String
            RichTextBox1.AppendText(DateTime.Now & " Creating commands" & vbCrLf)
            command1_1 = "cd " & Application.StartupPath & "\mediainfo"
            command1_2 = "mediainfo --fullscan " & item
            command1_2 = "mediainfo --fullscan " & item
            command1_2 = "mediainfo --fullscan " & item
            command1_10 = command1_10 & item & "|"
            RichTextBox1.AppendText(DateTime.Now & "  Writing to GetFullDVDFrames.bat" & vbCrLf)
            editBAT.WriteLine(command1_1)
            editBAT.WriteLine(command1_2)
            editBAT.Close()
            'MsgBox("progresstest4")
            RichTextBox1.AppendText(DateTime.Now & "  Successfully wrote to GetFullDVDFrames.bat" & vbCrLf)
            GetFullDVDFramesInfo.RedirectStandardError = True
            GetFullDVDFramesInfo.RedirectStandardInput = True
            GetFullDVDFramesInfo.RedirectStandardOutput = True
            GetFullDVDFramesInfo.CreateNoWindow = True
            GetFullDVDFramesInfo.UseShellExecute = False
            GetFullDVDFramesInfo.WindowStyle = ProcessWindowStyle.Hidden
            GetFullDVDFrames.StartInfo = GetFullDVDFramesInfo
            RichTextBox1.AppendText(DateTime.Now & "  Starting process GetFullDVDFrames.bat for file " & count & vbCrLf)
            'MsgBox("progresstest4")
            GetFullDVDFrames.Start()
            RichTextBox1.AppendText(DateTime.Now & "   process GetFullDVDFrames.bat for file " & count & "successfully started with ID " & GetFullDVDFrames.Id & vbCrLf)
            Dim output As String
            RichTextBox1.AppendText(DateTime.Now & "  reading output" & vbCrLf)
            output = GetFullDVDFrames.StandardOutput.ReadToEnd
            'MsgBox(output)
            'MsgBox("progresstest5")
            Dim output11() As String
            Dim output12() As String
            Dim output13() As String
            Dim output14() As String
            ReDim Preserve output11(0)
            ReDim Preserve output11(1)
            ReDim Preserve output12(0)
            ReDim Preserve output12(1)
            ReDim Preserve output13(0)
            ReDim Preserve output13(1)
            ReDim Preserve output13(0)
            ReDim Preserve output13(1)
            ReDim Preserve output14(0)
            ReDim Preserve output14(1)
            'MsgBox(output)
            output11 = Regex.Split(output, "Frame count                              : ")
            'MsgBox(output11(0))
            'MsgBox(output11(1))
            'MsgBox(output11(1))
            'MsgBox(output11(0))
            output12 = Regex.Split(output11(1), "Stream size                              : ")
            output12(0) = output12(0).TrimEnd(Chr(10))
            output12(0) = output12(0).TrimEnd(Chr(13))
            'MsgBox(output12(0))
            'Dim writer As StreamWriter
            'writer = New StreamWriter(Application.StartupPath & "\log1.txt")
            'writer.Write(output)
            'writer.WriteLine("--------------------------------------------------------------------------------------")
            'writer.Write(output11(0))
            'writer.WriteLine("--------------------------------------------------------------------------------------")
            'writer.Write(output11(1))
            'writer.WriteLine("--------------------------------------------------------------------------------------")
            'writer.Write(output12(0))
            'writer.Close()
            'currentfps = output12(0)
            'output13 = Regex.Split(output, "Duration: ")
            'output14 = Regex.Split(output13(1), ", start:")
            'currenttime = output14(0)
            'ctparts = Regex.Split(currenttime, ":")
            't1 = ctparts(0)
            't2 = ctparts(1)
            't3 = ctparts(2)
            'VidTime = ((t3) + 70 + (t2 * 60) + (t1 * 3600))
            'MsgBox(VidTime)
            'MsgBox(t3)
            'MsgBox(t2)
            VidFrames = output12(0)
            'MsgBox(VidFrames)
            RichTextBox1.AppendText(DateTime.Now & "  Number of frames in video:" & VidFrames & vbCrLf)
            FullDVDFrames = FullDVDFrames + VidFrames
        Next
        FullDVDFrames = FullDVDFrames + (FullDVDFrames / 12)
        ProgressBar1.Maximum = FullDVDFrames
        RichTextBox1.AppendText(DateTime.Now & "  Frames in DVD:" & FullDVDFrames & vbCrLf)
        'MsgBox(FullDVDFrames)
        Dim command1_0 As String
        command1_0 = "cd " & Application.StartupPath & "\ffmpeg\bin"
        command1_10 = command1_10.TrimEnd("|")
        command1_10 = command1_10 & Chr(34) & " " & Chr(34) & ExpFile & Chr(34)
        editBAT = New StreamWriter(Application.StartupPath & "\RipFullDVD.bat")
        editBAT.WriteLine(command1_0)
        editBAT.WriteLine(command1_10)
        editBAT.Close()
        'MsgBox("started3")
        RipFullDVDInfo.RedirectStandardError = True
        RipFullDVDInfo.RedirectStandardInput = True
        RipFullDVDInfo.RedirectStandardOutput = True
        RipFullDVDInfo.CreateNoWindow = True
        RipFullDVDInfo.UseShellExecute = False
        RipFullDVDInfo.WindowStyle = ProcessWindowStyle.Hidden
        RipFullDVD.StartInfo = RipFullDVDInfo
        AddHandler RipFullDVD.Exited, AddressOf FullRipFinishedConversion
        'AddHandler RipFullDVD.ErrorDataReceived, AddressOf FullRipNErrorRead
        RichTextBox1.AppendText(DateTime.Now & "  Starting process RipFullDVD.bat" & vbCrLf)
        'MsgBox("started4")
        RipFullDVD.Start()
        RichTextBox1.AppendText(DateTime.Now & "  Successfully started process RipFullDVD.bat with ID " & RipFullDVD.Id & vbCrLf)
        Dim FullRipErrorRead As StreamReader = RipFullDVD.StandardError
        'RipFullDVD.BeginErrorReadLine()
        RichTextBox1.AppendText(DateTime.Now & "  Reading output" & vbCrLf)
        FullRipErrorOutput(FullRipErrorRead)
        ' MsgBox("started5")
        RipFullDVD.WaitForExit()
        RipFullDVD.Close()
        ProgressBar1.Value = "0"
        MsgBox("Successfully ripped")
        Label8.Text = "Current Frame:"
        ripper.Abort()
    End Sub
    Private Async Sub FullRipErrorOutput(FullRipErrorRead As StreamReader)
        'MsgBox("progresstest")
        Dim newline As String = Await FullRipErrorRead.ReadLineAsync()
        If newline IsNot Nothing Then
            'MsgBox(newline)
            RichTextBox1.AppendText(DateTime.Now & "  " & newline & vbCrLf)

            If newline.Contains("frame= ") Then
                Dim sparts() As String
                newline.Replace("frame= ", "")
                newline = (New Regex("frame= ").Replace(newline, ""))
                'MsgBox(newline)
                'sparts = Regex.Split(newline, "frame= ")
                'MsgBox(sparts(0))
                Dim sparts1() As String
                sparts = Regex.Split(newline, " fps=")
                'MsgBox(sparts(0))
                Dim CurrentFrame As String
                'MsgBox(sparts1(0))

                CurrentFrame = sparts(0)
                'MsgBox(CurrentFrame)
                If CurrentFrame < ProgressBar1.Maximum Then
                    ProgressBar1.Value = CurrentFrame
                    Label13.Text = ("ERROR:Current frame has exceeded max frame count")
                Else
                    RichTextBox1.AppendText(DateTime.Now & "  Error: Frame count has exceeded number of frames, would pause progress bar" & vbCrLf)
                End If
                Label8.Text = "Current Frame:" & CurrentFrame & "/" & FullDVDFrames & " (" & (CurrentFrame / FullDVDFrames * 100) & "%)"
                GoTo Endread
            ElseIf newline.Contains("frame=") Then
                Dim sparts() As String
                newline.Replace("frame=", "")
                newline = (New Regex("frame=").Replace(newline, ""))
                'MsgBox(newline)
                'sparts = Regex.Split(newline, "frame= ")
                'MsgBox(sparts(0))
                Dim sparts1() As String
                sparts = Regex.Split(newline, " fps=")
                'MsgBox(sparts(0))
                Dim CurrentFrame As String
                'MsgBox(sparts1(0))

                CurrentFrame = sparts(0)
                'MsgBox(CurrentFrame)
                If CurrentFrame < ProgressBar1.Maximum Then
                    ProgressBar1.Value = CurrentFrame
                Else
                    RichTextBox1.AppendText(DateTime.Now & "  Error: Frame count has exceeded number of frames, would pause progress bar" & vbCrLf)
                    Label13.Text = ("ERROR:Current frame has exceeded max frame count")
                End If
                Label8.Text = "Current Frame:" & CurrentFrame & "/" & FullDVDFrames & " (" & (CurrentFrame / FullDVDFrames * 100) & "%)"
            Else
                'MsgBox(newline)

            End If
Endread:
            FullRipErrorOutput(FullRipErrorRead)

        End If
    End Sub
    Public Sub FullRipNErrorRead(sendingprocess As Object, newline As DataReceivedEventArgs)
        MsgBox(newline)
    End Sub
    Public Sub FullRipFinishedConversion(sender As Object, input As EventArgs)
        ProgressBar1.Value = "0"
        MsgBox("Successfully ripped")
        ripper.Abort()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            If File.Exists(Application.StartupPath & "\temp.jpg") Then
                PictureBox1.Image = Image.FromFile(Application.StartupPath & "\cover.jpg")
                Image.FromFile(Application.StartupPath & "\temp.jpg").Dispose()
                'PictureBox1.Dispose()
                If AlbumArt IsNot Nothing Then
                    AlbumArt.Dispose()
                End If
                'Me.Dispose()
                File.Delete(Application.StartupPath & "\temp.jpg")
            End If
            Dim command1 As String
            Dim command2 As String
            command1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
            command2 = "ffmpeg -i " & Chr(34) & OpenFileDialog2.FileName & Chr(34) & " " & Chr(34) & Application.StartupPath & "\temp.jpg" & Chr(34)
            Dim editBAT As StreamWriter
            editBAT = New StreamWriter(Application.StartupPath & "\GetAudioPic.bat")
            editBAT.WriteLine(command1)
            editBAT.WriteLine(command2)
            editBAT.Close()
            GetAudioPicInfo.RedirectStandardError = True
            GetAudioPicInfo.RedirectStandardInput = True
            GetAudioPicInfo.RedirectStandardOutput = True
            GetAudioPicInfo.CreateNoWindow = True
            GetAudioPicInfo.UseShellExecute = False
            GetAudioPicInfo.WindowStyle = ProcessWindowStyle.Hidden
            GetAudioPic.StartInfo = GetAudioPicInfo
            GetAudioPic.Start()
            GetAudioPic.WaitForExit()
            GetAudioPic.Close()
            If File.Exists(Application.StartupPath & "\temp.jpg") Then
                AlbumArt = Image.FromFile(Application.StartupPath & "\temp.jpg")
                PictureBox1.Image = AlbumArt
                AlbumArtLocation = Application.StartupPath & "\temp.jpg"
            Else
                AlbumArt = Image.FromFile(Application.StartupPath & "\blank.jpg")
                PictureBox1.Image = AlbumArt
                AlbumArtLocation = Application.StartupPath & "\blank.jpg"
            End If
            Dim command_1 As String
            Dim command_2 As String
            editBAT = New StreamWriter(Application.StartupPath & "\GetAudioStuff.bat")
            command_1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
            command_2 = "ffmpeg -i " & Chr(34) & OpenFileDialog2.FileName & Chr(34)
            editBAT.WriteLine(command_1)
            editBAT.WriteLine(command_2)
            editBAT.Close()
            Dim output1 As String
            Dim error1 As String
            GetAudioStuffInfo.RedirectStandardError = True
            GetAudioStuffInfo.RedirectStandardInput = True
            GetAudioStuffInfo.RedirectStandardOutput = True
            GetAudioStuffInfo.CreateNoWindow = True
            GetAudioStuffInfo.UseShellExecute = False
            GetAudioStuffInfo.WindowStyle = ProcessWindowStyle.Hidden
            GetAudioStuff.StartInfo = GetAudioStuffInfo
            GetAudioStuff.Start()
            output1 = GetAudioStuff.StandardOutput.ReadToEnd()
            error1 = GetAudioStuff.StandardError.ReadToEnd()
            GetAudioStuff.WaitForExit()
            GetAudioStuff.Close()
            'MsgBox(error1)
            'MsgBox(output1)
            Dim sparts() As String
            Dim sparts1() As String
            sparts = Regex.Split(error1, "Metadata:")
            'MsgBox(sparts.Rank)
            'MsgBox(sparts(1))
            sparts1 = sparts(1).Split(vbCrLf)
            'MsgBox(sparts1.Rank)
            'MsgBox(sparts1.GetUpperBound(0))
            'MsgBox(sparts1(0))
            'MsgBox(sparts1(1))
            'MsgBox(sparts1(2))
            For Each item As String In sparts1
                If item.Contains("    comment         : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "comment         : ")
                    AudioComment = sparts11(1)
                End If
                If item.Contains("    title           : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "title           : ")
                    AudioTitle = sparts11(1)
                End If
                If item.Contains("    artist          : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "artist          : ")
                    AudioArtist = sparts11(1)
                End If
                If item.Contains("    album           : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "album           : ")
                    AudioAlbum = sparts11(1)
                End If
                If item.Contains("    genre           : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "genre           : ")
                    AudioGenre = sparts11(1)
                End If
                If item.Contains("    composer        : ") Then
                    Dim sparts11() As String
                    sparts11 = Regex.Split(item, "composer        : ")
                    AudioComposer = sparts11(1)
                End If
            Next
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If File.Exists(Application.StartupPath & "\temp.jpg") Then
            PictureBox1.Image = Nothing
            AlbumArt.Dispose()
            File.Delete(Application.StartupPath & "\temp.jpg")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If OpenFileDialog3.ShowDialog() = DialogResult.OK Then
            AudioArtChanged = True
            NewArtLocation = OpenFileDialog3.FileName
            NewArt = OpenFileDialog3.FileName
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If SaveFileDialog3.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.CopyFile(AlbumArtLocation, SaveFileDialog3.FileName)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AudioArtChanged = True
        NewArt = Application.StartupPath & "\blank.jpg"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form3.ShowDialog()

    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            VidPath = OpenFileDialog1.FileName
            Button13.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True
            Button18.Enabled = True
            Button19.Enabled = True
            Button22.Enabled = True
            Button23.Enabled = True
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        AudioID3Changed = True
        Form4.ShowDialog()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If SaveFileDialog4.ShowDialog = DialogResult.OK Then
            Dim part1 As String
            Dim part2 As String
            If AudioArtChanged = True Then
                part1 = " -i " & Chr(34) & NewArt & Chr(34) & " -map 0:0 -map 1:0 -c copy"
            Else
                part1 = " "
            End If
            If AudioID3Changed = True Then
                If Form4.NewAlbum IsNot String.Empty Then
                    part2 = part2 & " -metadata album=" & Chr(34) & Form4.NewAlbum & Chr(34)
                End If
                If Form4.NewArtist IsNot String.Empty Then
                    part2 = part2 & " -metadata artist=" & Chr(34) & Form4.NewArtist & Chr(34)
                End If
                If Form4.NewComment IsNot String.Empty Then
                    part2 = part2 & " -metadata comment=" & Chr(34) & Form4.NewComment & Chr(34)
                End If
                If Form4.NewComposer IsNot String.Empty Then
                    part2 = part2 & " -metadata composer=" & Chr(34) & Form4.NewComposer & Chr(34)
                End If
                If Form4.NewGenre IsNot String.Empty Then
                    part2 = part2 & " -metadata genre=" & Chr(34) & Form4.NewGenre & Chr(34)
                End If
                If Form4.NewTitle IsNot String.Empty Then
                    part2 = part2 & " -metadata title=" & Chr(34) & Form4.NewTitle & Chr(34)
                End If
            Else
                part2 = " "
            End If
            Dim command1 As String
            Dim command2 As String
            command1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
            command2 = "ffmpeg -i " & Chr(34) & OpenFileDialog2.FileName & Chr(34) & part1 & part2 & " " & Chr(34) & SaveFileDialog4.FileName & Chr(34)
            Dim editBAT As StreamWriter
            editBAT = New StreamWriter(Application.StartupPath & "\ChangeAudioStuff.bat")
            editBAT.WriteLine(command1)
            editBAT.WriteLine(command2)
            editBAT.Close()
            ChangeAudioStuffInfo.RedirectStandardError = True
            ChangeAudioStuffInfo.RedirectStandardInput = True
            ChangeAudioStuffInfo.RedirectStandardOutput = True
            ChangeAudioStuffInfo.CreateNoWindow = True
            ChangeAudioStuffInfo.UseShellExecute = False
            ChangeAudioStuffInfo.WindowStyle = ProcessWindowStyle.Hidden
            ChangeAudioStuff.StartInfo = ChangeAudioStuffInfo
            RichTextBox1.AppendText(DateTime.Now & "  Starting process ChangeAudioStuff.bat" & vbCrLf)
            ChangeAudioStuff.Start()
            ChangeAudioStuff.WaitForExit()
            ChangeAudioStuff.Close()
            MsgBox("Successfully saved")
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Form5.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'Dim reply As Integer
        Dim reply As Integer = MessageBox.Show("Would you like to use the automatic format detecting method (only for development)?", "Please select", MessageBoxButtons.YesNo)
        If reply = DialogResult.Yes Then
            UsingMethod = "Development"
            FormatCount = 0
            Dim editBAT As StreamWriter
            Dim output1 As String
            Dim error1 As String
            Dim output2() As String
            Dim MainOutput As String
            Dim SplitString As String
            Dim SubOutputs() As String
            editBAT = New StreamWriter(Application.StartupPath & "\GetVideoQuality.bat")
            editBAT.WriteLine("cd " & Chr(34) & Application.StartupPath & Chr(34))
            editBAT.WriteLine("youtube-dl -F " & TextBox1.Text)
            editBAT.Close()
            GetVideoQualityInfo.WindowStyle = ProcessWindowStyle.Hidden
            GetVideoQualityInfo.CreateNoWindow = True
            GetVideoQualityInfo.UseShellExecute = False
            GetVideoQualityInfo.RedirectStandardError = True
            GetVideoQualityInfo.RedirectStandardOutput = True
            GetVideoQuality.StartInfo = GetVideoQualityInfo
            GetVideoQuality.Start()
            output1 = GetVideoQuality.StandardOutput.ReadToEnd()
            error1 = GetVideoQuality.StandardError.ReadToEnd()
            GetVideoQuality.WaitForExit()
            GetVideoQuality.Close()
            editBAT = New StreamWriter(Application.StartupPath & "\viderr1.txt")
            editBAT.Write(error1)
            editBAT.Close()
            editBAT = New StreamWriter(Application.StartupPath & "\vidout1.txt")
            editBAT.Write(output1)
            editBAT.Close()
            output2 = Regex.Split(output1, "resolution note")
            MainOutput = output2(1)
            MsgBox(MainOutput)
            SubOutputs = Regex.Split(MainOutput, "iB")
            Dim replaceString As String
            For Each item As String In SubOutputs
                Dim output3() As String
                Dim output4() As String
                Dim output5() As String
                Dim output6() As String
                replaceString = item
                MsgBox(item)
                If item.Contains("small") = False And item.Contains("medium") = False And item.Contains("(best)") = False And item.Contains("hd720") = False Then

                    If item.Contains("audio only") Then
                        MsgBox(replaceString)
                        MsgBox("contains audio")
                        'FormatType(FormatCount) = "Audio"

                        MsgBox(replaceString)
                        output3 = Regex.Split(item, "         ")
                        FormatNumber(FormatCount) = output3(0)
                        If output3(1).Contains("webm") Then
                            FormatFileType(FormatCount) = "webm"
                            output5 = Regex.Split(output3(1), "DASH audio  ")
                            output6 = Regex.Split(output5(1), "k , ")
                            FormatQualityIndex(FormatCount) = output6(0)
                            If output3(1).Contains("Hz), ") Then
                                output4 = Regex.Split(output3(1), "Hz), ")
                                FormatSize(FormatCount) = output4(1)
                            ElseIf output3(1).Contains("k, ") Then
                                output4 = Regex.Split(output3(1), "k, ")
                                FormatSize(FormatCount) = output4(1)
                            End If
                        ElseIf output3(1).Contains("m4a") Then
                            FormatFileType(FormatCount) = "m4a"
                            output5 = Regex.Split(output3(1), "DASH audio  ")
                            output6 = Regex.Split(output5(1), "k , ")
                            FormatQualityIndex(FormatCount) = output6(0)
                            If output3(1).Contains("Hz), ") Then
                                output4 = Regex.Split(output3(1), "Hz), ")
                                FormatSize(FormatCount) = output4(1)
                            ElseIf output3(1).Contains("k, ") Then
                                output4 = Regex.Split(output3(1), "k, ")
                                FormatSize(FormatCount) = output4(1)
                            End If
                        End If

                    Else

                        output3 = Regex.Split(item, "          ")
                        FormatNumber(FormatCount) = output3(0)
                        If output3(1).Contains("mp4") Then
                            FormatType(FormatCount) = "Video"
                            FormatFileType(FormatCount) = "mp4"
                            If output3(1).Contains("x144") Or output3(1).Contains("x240") Or output3(1).Contains("x360") Or output3(1).Contains("x480") Then
                                output4 = Regex.Split(output3(1), "    DASH video")
                                output5 = Regex.Split(output4(0), "mp4        ")
                                MsgBox(output5(1))
                            End If
                        End If
                    End If

                End If

            Next
        Else
            UsingMethod = "Working"
            Label17.Text = "Status: Getting Video Thumbnail"
            TrackBar1.Enabled = False
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("MP4 1080p")
            ComboBox4.Items.Add("MP4 720p")
            ComboBox4.Items.Add("MP4 480p")
            ComboBox4.Items.Add("MP4 360p")
            ComboBox4.Items.Add("MP4 240p")
            ComboBox4.Items.Add("MP4 144p")
            ComboBox4.Items.Add("MP3 only")
            ComboBox4.Items.Add("MP3 + Video")
            ComboBox4.Text = "Please select a quality"
            Dim VidURL As String
            VidURL = TextBox1.Text
            Dim editBAT As StreamWriter
            Dim output1 As String
            editBAT = New StreamWriter(Application.StartupPath & "\GetVideoThumbnail.bat")
            editBAT.WriteLine("cd " & Chr(34) & Application.StartupPath & Chr(34))
            editBAT.WriteLine("youtube-dl --get-thumbnail " & TextBox1.Text)
            editBAT.Close()
            GetVideoThumbnailInfo.UseShellExecute = False
            GetVideoThumbnailInfo.CreateNoWindow = True
            GetVideoThumbnailInfo.WindowStyle = ProcessWindowStyle.Hidden
            GetVideoThumbnailInfo.RedirectStandardOutput = True
            GetVideoThumbnail.StartInfo = GetVideoThumbnailInfo
            GetVideoThumbnail.Start()
            output1 = GetVideoThumbnail.StandardOutput.ReadToEnd()
            'MsgBox(output1)
            editBAT = New StreamWriter(Application.StartupPath & "\file2.txt")
            editBAT.Write(output1)
            editBAT.Close()
            Dim ReadFile As StreamReader
            ReadFile = New StreamReader(Application.StartupPath & "\file2.txt")
            Dim readOutput As String
            readOutput = ReadFile.ReadToEnd()
            Dim output2() As String
            output1 = output1.Trim(Chr(10))
            output1 = output1.Trim(Chr(13))
            'output1 = output1.Trim(Chr())
            If output1.Contains(VidURL) Then
                'MsgBox("works")
            End If
            output1.Replace(TextBox1.Text, "hello")
            output1 = (New Regex(TextBox1.Text).Replace(output1, "TO.BE.SPLIT.HERE"))
            output1 = System.Text.RegularExpressions.Regex.Replace(output1, TextBox1.Text, "hello")
            'MsgBox("output1:" & output1)
            output2 = Regex.Split(output1, "https://")
            'MsgBox(TextBox1.Text)
            'MsgBox(output2(0))
            For Each item As String In output2
                'MsgBox(item)
                If item.Contains("i.ytimg") Then
                    Dim URL As String
                    URL = "https://" & item
                    If File.Exists(Application.StartupPath & "\vidthumbnail.jpg") Then
                        File.Delete(Application.StartupPath & "\vidthumbnail.jpg")
                    End If
                    My.Computer.Network.DownloadFile(URL, Application.StartupPath & "\vidthumbnail.jpg")
                    PictureBox2.Image = Image.FromFile(Application.StartupPath & "\vidthumbnail.jpg")
                End If
            Next
            'MsgBox(output2(2))
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If UsingMethod = "Working" Then
            If ComboBox4.SelectedItem = "MP3 + Video" Then
                If SaveFileDialog6.ShowDialog = DialogResult.OK Then
                    If downloader.IsAlive = False Then
                        downloader = New Thread(AddressOf MP3Downloader)
                        downloader.Start()
                    Else
                        MsgBox("Please wait for the current process to finish")
                    End If
                End If
            End If
            If ComboBox4.SelectedItem = "MP3 only" Then
                If SaveFileDialog7.ShowDialog = DialogResult.OK Then
                    'If downloader.IsAlive = False Then
                    downloader = New Thread(AddressOf MP3OnlyDownloader)
                    downloader.Start()
                    'Else
                    MsgBox("Please wait for the current process to finish")
                    'End If
                End If
            End If
        ElseIf UsingMethod = "Development" Then

        End If
    End Sub

    Public Sub MP3Downloader()

        Dim command As String
        command = "youtube-dl --extract-audio --audio-format mp3 --newline -k " & TextBox1.Text
        Dim editBAT As StreamWriter
        editBAT = New StreamWriter(Application.StartupPath & "\DownloadMP3.bat")
        editBAT.WriteLine("cd " & Chr(34) & Application.StartupPath & Chr(34))
        editBAT.WriteLine(command)
        editBAT.Close()
        DownloadMP3Info.UseShellExecute = False
        DownloadMP3Info.WindowStyle = ProcessWindowStyle.Hidden
        DownloadMP3Info.RedirectStandardError = True
        DownloadMP3Info.RedirectStandardOutput = True
        DownloadMP3Info.CreateNoWindow = True
        DownloadMP3.StartInfo = DownloadMP3Info
        ProgressBar1.Maximum = 1000
        ProgressBar1.Value = 0
        DownloadMP3.Start()
        Dim OutputRead As StreamReader = DownloadMP3.StandardOutput
        ReadOutput(OutputRead)
        DownloadMP3.WaitForExit()
        DownloadMP3.Close()
        Label17.Text = "Status:Copying"
        If SaveFileDialog6.FileName.Contains("files stored here") Then
            Dim FolderPath As String
            Dim output1() As String
            output1 = Regex.Split(SaveFileDialog6.FileName, "files stored here")
            FolderPath = output1(0)
            'MsgBox(FolderPath)
            'MsgBox(OriginalName)
            'MsgBox(FileName)
            File.Copy(Application.StartupPath & "/" & OriginalName, FolderPath & OriginalName)
            File.Copy(Application.StartupPath & "/" & FileName & ".mp3", FolderPath & FileName & ".mp3")
        Else
            File.Copy(Application.StartupPath & "/" & OriginalName, SaveFileDialog6.FileName & "." & OriginalExtension)
            File.Copy(Application.StartupPath & "/" & FileName & ".mp3", SaveFileDialog6.FileName & "(MP3)" & ".mp3")
        End If
        Label17.Text = "Status: Deleting residual files"
        File.Delete(Application.StartupPath & "/" & OriginalName)
        File.Delete(Application.StartupPath & "/" & FileName & ".mp3")
        If File.Exists(Application.StartupPath & "/" & FileName & ".mkv") Then
            File.Delete(Application.StartupPath & "/" & FileName & ".mkv")
        End If
        Label17.Text = "Status:"
        MsgBox("Successfully Downloaded")
    End Sub

    Private Async Sub ReadOutput(OutputRead As StreamReader)
        Dim newline As String = Await OutputRead.ReadLineAsync()
        'MsgBox(newline)
        If newline IsNot Nothing Then
            If newline.Contains("[download] Destination: ") Then
                Dim output1 As String()
                Dim output2() As String

                output1 = Regex.Split(newline, "download] Destination: ")
                OriginalName = output1(1)
                output2 = output1(1).Split(".")
                FileName = output2(0)
                OriginalExtension = output2(1)
            ElseIf newline.Contains("[download] ") Then
                If newline.Contains("Destination: ") = False And newline.Contains("ETA") = True Then
                    Dim output1() As String
                    Dim output2() As String
                    Dim output3() As String
                    Dim output4() As String
                    Dim output5() As String
                    Dim VideoSize As String
                    Dim RawProgress As Decimal
                    Dim Progress As Integer
                    Dim RemainingTime As String

                    output1 = Regex.Split(newline, "download] ")
                    output2 = Regex.Split(output1(1), "%")
                    RawProgress = output2(0)
                    Progress = RawProgress * 10
                    output3 = Regex.Split(newline, "ETA ")
                    RemainingTime = output3(1)
                    output4 = Regex.Split(newline, "% of ")
                    output5 = Regex.Split(output4(1), " at ")
                    VideoSize = output5(0)
                    Label17.Text = "Status: Downloading, " & RawProgress & "% of " & VideoSize & ", ETA " & RemainingTime
                    ProgressBar1.Value = Progress
                End If
            ElseIf newline.Contains("[download] 100% of ") Then
                ProgressBar1.Value = 1000
            ElseIf newline.Contains("[ffmpeg] Destination: ") Then
                ProgressBar1.Value = 0
                Label17.Text = "Status: Converting"

            End If
        End If
        ReadOutput(OutputRead)
    End Sub
    Public Sub MP3OnlyDownloader()
        Dim command As String
        command = "youtube-dl --extract-audio --audio-format mp3 --newline " & TextBox1.Text
        Dim editBAT As StreamWriter
        editBAT = New StreamWriter(Application.StartupPath & "\DownloadOnlyMP3.bat")
        editBAT.WriteLine("cd " & Chr(34) & Application.StartupPath & Chr(34))
        editBAT.WriteLine(command)
        editBAT.Close()
        DownloadMP3OnlyInfo.UseShellExecute = False
        DownloadMP3OnlyInfo.WindowStyle = ProcessWindowStyle.Hidden
        DownloadMP3OnlyInfo.RedirectStandardError = True
        DownloadMP3OnlyInfo.RedirectStandardOutput = True
        DownloadMP3OnlyInfo.CreateNoWindow = True
        DownloadMP3Only.StartInfo = DownloadMP3OnlyInfo
        ProgressBar1.Maximum = 1000
        ProgressBar1.Value = 0
        DownloadMP3Only.Start()
        Dim OutputRead As StreamReader = DownloadMP3Only.StandardOutput
        ReadOutput(OutputRead)
        DownloadMP3Only.WaitForExit()
        DownloadMP3Only.Close()
        Label17.Text = "Status:Copying"
        If SaveFileDialog7.FileName.Contains("default") Then
            Dim FolderPath As String
            Dim output1() As String
            output1 = Regex.Split(SaveFileDialog7.FileName, "default")
            FolderPath = output1(0)
            If File.Exists(Application.StartupPath & "\" & FileName & ".mp3") Then
                File.Copy(Application.StartupPath & "\" & FileName & ".mp3", FolderPath & FileName & ".mp3")
            End If
        Else
            If File.Exists(Application.StartupPath & "\" & FileName & ".mp3") Then
                File.Copy(Application.StartupPath & "\" & FileName & ".mp3", SaveFileDialog7.FileName & ".mp3")
            End If
        End If
        Label17.Text = "Status: Deleting residual files"
        If File.Exists(Application.StartupPath & "\" & FileName & ".mp3") Then
            File.Delete(Application.StartupPath & "\" & FileName & ".mp3")
        End If
        Label17.Text = "Status:"
        MsgBox("Successfully Downloaded")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class
'cut code
'If SaveFileDialog4.ShowDialog() = DialogResult.OK Then
'Dim command1 As String
'Dim command2 As String
'command1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
'command2 = "ffmpeg -i " & Chr(34) & OpenFileDialog2.FileName & Chr(34) & " -i " & Chr(34) & Application.StartupPath & "\blank.jpg" & Chr(34) & " -map 0:0 -map 1:0 -c copy -id3v2_version 3 -metadata:s:v title=" & Chr(34) & "Album cover" & Chr(34) & " -metadata:s:v comment=" & Chr(34) & "Cover (Front)" & Chr(34) & " " & SaveFileDialog4.FileName
'Dim editBAT As StreamWriter
'editBAT = New StreamWriter(Application.StartupPath & "\ReplaceCover.bat")
'editBAT.WriteLine(command1)
'editBAT.WriteLine(command2)
'editBAT.Close()
'ReplaceCoverInfo.RedirectStandardError = True
'ReplaceCoverInfo.RedirectStandardInput = True
'ReplaceCoverInfo.RedirectStandardOutput = True
'ReplaceCoverInfo.CreateNoWindow = True
'ReplaceCoverInfo.UseShellExecute = False
'ReplaceCoverInfo.WindowStyle = ProcessWindowStyle.Hidden
'ReplaceCover.StartInfo = ReplaceCoverInfo
'ReplaceCover.Start()
'ReplaceCover.WaitForExit()
'ReplaceCover.Close()
'command1 = "cd " & Application.StartupPath & "\ffmpeg\bin"
'command2 = "ffmpeg -i " & Chr(34) & SaveFileDialog4.FileName & Chr(34) & " " & Chr(34) & Application.StartupPath & "\temp.jpg" & Chr(34)
'If File.Exists(Application.StartupPath & "\temp.jpg") Then
'PictureBox1.Image = Image.FromFile(Application.StartupPath & "\cover.jpg")
'Image.FromFile(Application.StartupPath & "\temp.jpg").Dispose()
''PictureBox1.Dispose()
'If AlbumArt IsNot Nothing Then
'AlbumArt.Dispose()
'End If
'Me.Dispose()
'File.Delete(Application.StartupPath & "\temp.jpg")
'End If
'editBAT = New StreamWriter(Application.StartupPath & "\GetAudioPic.bat")
'editBAT.WriteLine(command1)
'editBAT.WriteLine(command2)
'editBAT.Close()
'GetAudioPicInfo.RedirectStandardError = True
'GetAudioPicInfo.RedirectStandardInput = True
'GetAudioPicInfo.RedirectStandardOutput = True
'GetAudioPicInfo.CreateNoWindow = True
'GetAudioPicInfo.UseShellExecute = False
'GetAudioPicInfo.WindowStyle = ProcessWindowStyle.Hidden
'GetAudioPic.StartInfo = GetAudioPicInfo
'GetAudioPic.Start()
'GetAudioPic.WaitForExit()
'GetAudioPic.Close()
'If File.Exists(Application.StartupPath & "\temp.jpg") Then
'AlbumArt = Image.FromFile(Application.StartupPath & "\temp.jpg")
'PictureBox1.Image = AlbumArt
'AlbumArtLocation = Application.StartupPath & "\temp.jpg"
'Else
'AlbumArt = Image.FromFile(Application.StartupPath & "\blank.jpg")
'PictureBox1.Image = AlbumArt
'AlbumArtLocation = Application.StartupPath & "\blank.jpg"
'End If
'End If
