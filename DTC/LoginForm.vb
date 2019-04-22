Imports DTC.ClassUser

Public Class LoginForm
    Public user As New ClassUser

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
        user.UserName = Login.Text
        MsgBox(user.UserName)


    End Sub
End Class
