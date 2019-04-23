Imports DTC.ClassUser

Public Class LoginForm
    Public user As New ClassUser
    Private userSave As Boolean
    Public users(4, 5) As String

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim TheControl As Control = CType(sender, Control)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(
                                      oRAngle, Color.FromArgb(9, 32, 63),
                                      Color.FromArgb(83, 120, 149),
                                      Drawing.Drawing2D _
                                      .LinearGradientMode.ForwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 0 To 4
            For j = 0 To 5
                Try
                    If Login.Text = users(i, 0) Then
                        If Password.Text = users(i, 1) Then
                            user.UserName = users(i, 2)
                            user.UserFunction = users(i, 3)
                            user.UserArea = users(i, 4)
                            user.UserPrivilege = users(i, 4)
                            If userSave = True Then
                                My.Settings.Login = Login.Text
                                My.Settings.pass = Password.Text
                                My.Settings.saved = userSave
                                My.Settings.Save()
                            Else
                                My.Settings.Login = ""
                                My.Settings.pass = ""
                                My.Settings.saved = userSave
                                My.Settings.Save()
                            End If
                            MainForm.Show()
                            Me.Close()
                        Else
                            MsgBox("Senha errada")
                            Password.Clear()
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'users = {{login,password,nome,funcao,area, privilegios}}
        users = {{"projetista", "1234", "Projetista 1", "Projetista", 1, 3},
            {"projetista2", "1234", "Projetista 2", "Projetista", 2, 3},
            {"execusao", "1234", "Técnico de obras 1", "Técnico", 3, 3},
            {"assistente", "1234", "Assistente 1", "Assistente", 3, 2},
            {"supervisao", "1234", "Supervisor 1", "Supervisor", 0, 1}}
        If userSave Then
            Login.Text = My.Settings.Login
            Password.Text = My.Settings.pass
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            userSave = True
        Else
            userSave = False
        End If
    End Sub
End Class
