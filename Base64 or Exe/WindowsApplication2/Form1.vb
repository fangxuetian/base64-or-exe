Imports System.IO


Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New OpenFileDialog
        With OpenFileDialog
            .Title = "Select exe file"

            .ShowDialog()
        End With
        TextBox1.Text = OpenFileDialog.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("Please select a file", MsgBoxStyle.Critical)
        Else RichTextBox1.Text = Convert.ToBase64String(File.ReadAllBytes(TextBox1.Text))
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrEmpty(RichTextBox1.Text) Then
            MsgBox("There is nothing to copy", MsgBoxStyle.Critical)
        End If
        RichTextBox1.SelectAll()
        RichTextBox1.Copy()

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(i) Is RichTextBox Then
                Me.Controls(i).Text = ""
            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RichTextBox1.Text = Nothing Then
            MsgBox("Please paste some base64 characters", MsgBoxStyle.Critical)
        Else
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "Exe Files (*.exe) | *.exe"
            If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    IO.File.WriteAllBytes(SaveFile.FileName, Convert.FromBase64String(RichTextBox1.Text))
                    MsgBox("Done", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox("Invalid base64 characters", MsgBoxStyle.Exclamation)
                End Try


            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        RichTextBox1.SelectAll()
        If My.Computer.Clipboard.ContainsText Then
            RichTextBox1.Text = My.Computer.Clipboard.GetText
        End If
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If RichTextBox1.Text = Nothing Then
            MsgBox("Please paste some base64 characters", MsgBoxStyle.Critical)
            Return
        End If
        Try
            RichTextBox1.Text = New System.Text.ASCIIEncoding().GetString(Convert.FromBase64String(RichTextBox1.Text))
            MsgBox("Done", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Invalid base64 characters", MsgBoxStyle.Exclamation)

        End Try

    End Sub
End Class


