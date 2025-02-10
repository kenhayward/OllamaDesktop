Imports System.Drawing.Drawing2D

Public Class PromptEntry

    Private _radius As Int32 = 40     'Radius of the Corner Curve
    Private _opacity As Int32 = 125   'Opacity of the Control
    Private _backColor As System.Drawing.Color = Color.Black 'Back Color of Control

    Private Sub UserControl1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim rect As Rectangle = Me.ClientRectangle 'Drawing Rounded Rectangle
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, _backColor)), rect)
        rect.X = rect.X + 1
        rect.Y = rect.Y + 1
        rect.Width -= 2
        rect.Height -= 2
        Using bb As GraphicsPath = GetPath(rect, _radius)
            Using br As Brush = New SolidBrush(Color.FromArgb(_opacity, _backColor))
                e.Graphics.FillPath(br, bb)
            End Using
        End Using
    End Sub
    'Returns the GraphicsPath to Draw a RoundedRectangle
    Protected Function GetPath(ByVal rc As Rectangle, ByVal r As Int32) As GraphicsPath
        Dim x As Int32 = rc.X, y As Int32 = rc.Y, w As Int32 = rc.Width, h As Int32 = rc.Height
        r = r << 1
        Dim path As GraphicsPath = New GraphicsPath()
        If r > 0 Then
            If (r > h) Then r = h
            If (r > w) Then r = w
            path.AddArc(x, y, r, r, 180, 90)
            path.AddArc(x + w - r, y, r, r, 270, 90)
            path.AddArc(x + w - r, y + h - r, r, r, 0, 90)
            path.AddArc(x, y + h - r, r, r, 90, 90)
            path.CloseFigure()
        Else
            path.AddRectangle(rc)
        End If
        Return path
    End Function
End Class
