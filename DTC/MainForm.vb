Imports DTC.ClassUser
Imports DTC.LoginForm
Public Class MainForm
    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim TheControl As Control = CType(sender, Control)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(
                                      oRAngle, Color.FromArgb(83, 120, 149),
                                      Color.FromArgb(9, 32, 63),
                                      Drawing.Drawing2D _
                                      .LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = LoginForm.user.UserName
        Label2.Text = LoginForm.user.UserFunction
    End Sub

End Class