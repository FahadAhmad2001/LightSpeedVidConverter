Public Class Form6
    Public Width As String
    Public Height As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Width = TextBox1.Text
        Label3.Text = "Selected Resolution: " & Width & "x" & Height
        Me.Text = "Custom Resolution: " & Width & "x" & Height
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Height = TextBox2.Text
        Label3.Text = "Selected Resolution: " & Width & "x" & Height
        Me.Text = "Custom Resolution: " & Width & "x" & Height
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles Me.Load
        Width = "1920"
        Height = "1080"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class