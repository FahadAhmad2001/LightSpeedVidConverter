Public Class Form4
    Public NewTitle As String
    Public NewArtist As String
    Public NewAlbum As String
    Public NewGenre As String
    Public NewComposer As String
    Public NewComment As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Form1.AudioTitle
        TextBox2.Text = Form1.AudioArtist
        TextBox3.Text = Form1.AudioAlbum
        TextBox4.Text = Form1.AudioGenre
        TextBox5.Text = Form1.AudioComposer
        TextBox6.Text = Form1.AudioComment
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = String.Empty Then
            NewTitle = Form1.AudioTitle
        Else
            NewTitle = TextBox1.Text
        End If
        If TextBox2.Text = String.Empty Then
            NewArtist = Form1.AudioArtist
        Else
            NewArtist = TextBox2.Text
        End If
        If TextBox3.Text = String.Empty Then
            NewAlbum = Form1.AudioAlbum
        Else
            NewAlbum = TextBox3.Text
        End If
        If TextBox4.Text = String.Empty Then
            NewGenre = Form1.AudioGenre
        Else
            NewGenre = TextBox4.Text
        End If
        If TextBox5.Text = String.Empty Then
            NewComposer = Form1.AudioComposer
        Else
            NewComposer = TextBox5.Text
        End If
        If TextBox6.Text = String.Empty Then
            NewComment = Form1.AudioComment
        Else
            NewComment = TextBox6.Text
        End If
        Me.Close()
    End Sub
End Class