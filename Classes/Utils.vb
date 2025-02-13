Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices

Public Module Globals


    <Extension()>
    Public Function ReplaceAt(ByVal str As String, ByVal index As Integer, ByVal length As Integer, ByVal replace As String) As String
        Return str.Remove(index, Math.Min(length, str.Length - index)).Insert(index, replace)
    End Function


End Module
Public Class Utils

    Public Shared Function GetColorMode(f As Form) As DarkModeCS
        Return New DarkModeCS(f, True, True) With {.ColorMode = DarkModeCS.DisplayMode.ClearMode}
    End Function


    Private Shared OServers As OllamaServers
    Public Shared ReadOnly Property OllamaServers As OllamaServers
        Get
            If OServers Is Nothing Then
                OServers = OllamaServers.Load()
            End If
            Return OServers
        End Get
    End Property


    Private Shared _Knowledge As KnowledgeSet
    Public Shared ReadOnly Property Knowledge As KnowledgeSet
        Get
            If _Knowledge Is Nothing Then
                _Knowledge = KnowledgeSet.Load()
            End If
            Return _Knowledge
        End Get
    End Property


    Public Shared Function TimeSpanFormat(ByVal timeSpan As TimeSpan) As String
        Dim result As String = String.Empty
        If Math.Floor(timeSpan.TotalDays) > 0.0R Then result += TrimFirst(String.Format("{0:ddd}d ", timeSpan), "0"c)
        If Math.Floor(timeSpan.TotalHours) > 0.0R Then result += TrimFirst(String.Format("{0:hh}h ", timeSpan), "0"c)
        If Math.Floor(timeSpan.TotalMinutes) > 0.0R Then result += TrimFirst(String.Format("{0:mm}m ", timeSpan), "0"c)

        If Math.Floor(timeSpan.TotalSeconds) > 0.0R Then
            result += TrimFirst(String.Format("{0:ss}s ", timeSpan), "0"c)
        Else
            result += "0s"
        End If
        If timeSpan.TotalMilliseconds > 0.0R Then
            If result = "0s" Then
                result = TrimFirst(String.Format("{0:fff}ms", timeSpan), "0"c)
            Else
                result += TrimFirst(String.Format("{0:fff}ms", timeSpan), "0"c)
            End If
        End If
        Return result
    End Function

    Public Shared Function TrimFirst(ByVal value As String, ByVal c As String) As String
        If value.Substring(0, 1) = c Then Return value.Substring(1)
        Return value
    End Function
    Public Shared Function FileNameOnly(FilePath As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FilePath)
    End Function
    Public Shared Function IgnoreNulls(Cell As Object, Optional NullReturn As String = "n/a") As String
        Dim Result As String
        If IsDBNull(Cell) Then
            Result = NullReturn
        Else
            Result = Cell
        End If
        Return Result
    End Function
    Public Shared Function FormatFileSize(size As Long) As String
        Dim unit As String = "b"
        If size >= 1073741824 Then
            ' More than 1GB
            size /= 1073741824
            unit = "gb"
        ElseIf size >= 1048576 Then
            ' More than 1MB but less than 1GB
            size /= 1048576
            unit = "mb"
        ElseIf size >= 1024 Then
            ' More than 1KB but less than 1MB
            size /= 1024
            unit = "kb"
        End If

        Return String.Format("{0:0.##}{1}", size, unit)
    End Function

End Class
