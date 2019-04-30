Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Public Class TransparentTabControl
    Inherits TabControl

    Private pages As List(Of Panel) = New List(Of Panel)()

    Public Sub MakeTransparent()
        If TabCount = 0 Then Throw New InvalidOperationException()
        Dim height = GetTabRect(0).Bottom

        For tab As Integer = 0 To TabCount - 1
            Dim page = New Panel With {
                .Left = Me.Left,
                .Top = Me.Top + height,
                .Width = Me.Width,
                .Height = Me.Height - height,
                .BackColor = Color.Transparent,
                .Visible = tab = Me.SelectedIndex
            }

            For ix As Integer = TabPages(tab).Controls.Count - 1 To 0
                TabPages(tab).Controls(ix).Parent = page
            Next

            pages.Add(page)
            Me.Parent.Controls.Add(page)
        Next

        Me.Height = height
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As EventArgs)
        MyBase.OnSelectedIndexChanged(e)

        For tab As Integer = 0 To pages.Count - 1
            pages(tab).Visible = tab = SelectedIndex
        Next
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then

            For Each page In pages
                page.Dispose()
            Next
        End If

        MyBase.Dispose(disposing)
    End Sub
End Class
