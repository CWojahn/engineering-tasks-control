Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Sample
    Class DataGridViewProgressCell
        Inherits DataGridViewImageCell

        Shared emptyImage As Image
        Shared _ProgressBarColor As Color

        Public Property ProgressBarColor As Color
            Get
                Return _ProgressBarColor
            End Get
            Set(ByVal value As Color)
                _ProgressBarColor = value
            End Set
        End Property

        Private Shared Sub New()
            emptyImage = New Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        End Sub

        Public Sub New()
            Me.ValueType = GetType(Integer)
        End Sub

        Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, ByVal valueTypeConverter As TypeConverter, ByVal formattedValueTypeConverter As TypeConverter, ByVal context As DataGridViewDataErrorContexts) As Object
            Return emptyImage
        End Function

        Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
            If Convert.ToInt16(value) = 0 OrElse value Is Nothing Then
                value = 0
            End If

            Dim progressVal As Integer = Convert.ToInt32(value)
            Dim percentage As Single = (CSng(progressVal) / 100.0F)
            Dim backColorBrush As Brush = New SolidBrush(cellStyle.BackColor)
            Dim foreColorBrush As Brush = New SolidBrush(cellStyle.ForeColor)
            MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts And Not DataGridViewPaintParts.ContentForeground))
            Dim posX As Single = cellBounds.X
            Dim posY As Single = cellBounds.Y
            Dim textWidth As Single = TextRenderer.MeasureText(progressVal.ToString() & "%", cellStyle.Font).Width
            Dim textHeight As Single = TextRenderer.MeasureText(progressVal.ToString() & "%", cellStyle.Font).Height

            Select Case cellStyle.Alignment
                Case DataGridViewContentAlignment.BottomCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.BottomLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.BottomRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.MiddleCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.MiddleLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.MiddleRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.TopCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y
                Case DataGridViewContentAlignment.TopLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y
                Case DataGridViewContentAlignment.TopRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y
            End Select

            If percentage >= 0.0 Then
                g.FillRectangle(New SolidBrush(_ProgressBarColor), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width * 0.8)), cellBounds.Height / 1 - 5)
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreColorBrush, posX, posY)
            Else

                If Me.DataGridView.CurrentRow.Index = rowIndex Then
                    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), posX, posX)
                Else
                    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreColorBrush, posX, posY)
                End If
            End If
        End Sub

        Public Overrides Function Clone() As Object
            Dim dataGridViewCell As DataGridViewProgressCell = TryCast(MyBase.Clone(), DataGridViewProgressCell)

            If dataGridViewCell IsNot Nothing Then
                dataGridViewCell.ProgressBarColor = Me.ProgressBarColor
            End If

            Return dataGridViewCell
        End Function

        Friend Sub SetProgressBarColor(ByVal rowIndex As Integer, ByVal value As Color)
            Me.ProgressBarColor = value
        End Sub
    End Class
End Namespace
