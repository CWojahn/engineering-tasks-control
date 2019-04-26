Imports DTC.ClassUser
Imports DTC.LoginForm

Public Class MainForm
    Public connectedOnServer As Boolean
    Private isMouseDown As Boolean
    Private mouseOffset As Point

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'itens a serem excluidos
        '
        connectedOnServer = True

        '
        '


        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.ItemSize = New Size(0, 1)
        TabControl1.SizeMode = TabSizeMode.Fixed
        For Each tab As TabPage In TabControl1.TabPages
            tab.Text = ""
        Next

        If connectedOnServer Then
            PictureBox3.Image = My.Resources.icons8_online
        Else
            PictureBox3.Image = My.Resources.icons8_offline
        End If

        Label1.Text = LoginForm.user.UserName
        Label2.Text = LoginForm.user.UserFunction
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button1.Top
        Panel6.Height = Button1.Height
        'chama as funções da janela inicial
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel8.Hide()
        Button3.Show()
        Panel6.Top = Button2.Top
        Panel6.Height = Button2.Height
        Button11.Show()
        'TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button4.Top
        Panel6.Height = Button4.Height
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button5.Top
        Panel6.Height = Button5.Height
        TabControl1.SelectedTab = TabPage5

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button6.Top
        Panel6.Height = Button6.Height
        TabControl1.SelectedTab = TabPage6
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Panel4.Width = 240 Then
            Panel4.Width = 40
            Panel5.Hide()
            Panel7.Hide()
            PictureBox1.Image = My.Resources.dinamica_eletrica_icon
        Else
            Panel4.Width = 240
            Panel5.Show()
            Panel7.Show()
            PictureBox1.Image = My.Resources.dinamica_eletrica_wht_v2_uai_258x58
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        LoginForm.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Panel7.Top
        Panel6.Height = Button9.Height
        TabControl1.SelectedTab = TabPage7
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, Panel12.MouseDown
        If e.Button = MouseButtons.Left Then
            mouseOffset = New Point(Cursor.Position.X - Me.Location.X, Cursor.Position.Y - Me.Location.Y)
            isMouseDown = True
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, Panel12.MouseMove
        If isMouseDown Then
            Me.Location = New Point(Cursor.Position.X - mouseOffset.X, Cursor.Position.Y - mouseOffset.Y)
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp, Panel12.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button12.Top
        Panel6.Height = Button12.Height
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel8.Show()
        Panel8.Top = Button11.Top
        Panel8.Height = Button11.Height
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel8.Show()
        Panel8.Top = Button3.Top
        Panel8.Height = Button3.Height
        TabControl1.SelectedTab = TabPage8
    End Sub



End Class
