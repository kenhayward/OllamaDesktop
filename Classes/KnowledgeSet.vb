﻿Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class KnowledgeSet
    Inherits List(Of KnowledgeEntry)

    Private Const FileName As String = "OllamaKnowledge.bin"
    Public Sub Save()
        Dim formatter As New BinaryFormatter()
        Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim filePath As String = Path.Combine(documentsPath, FileName)
        Using stream As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
            formatter.Serialize(stream, Me)
        End Using
    End Sub
    Public Shared Function Load() As KnowledgeSet
        Try

            Dim formatter As New BinaryFormatter()
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim filePath As String = Path.Combine(documentsPath, FileName)

            Using stream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                Return CType(formatter.Deserialize(stream), KnowledgeSet)
            End Using
        Catch ex As Exception
            Return New KnowledgeSet
        End Try
    End Function

    Public Function GetEntry(Key As String) As KnowledgeEntry
        Dim theKey = Key.Trim
        For Each entry In Me
            If entry.Key.Equals(theKey, StringComparison.CurrentCultureIgnoreCase) Then
                Return entry
            End If
        Next
        Return Nothing
    End Function

End Class

<Serializable()> Public Class KnowledgeEntry

    Public Property Key As String
    Public Property Name As String
    Public Property Text As String
    Public ReadOnly Property Size As Integer
        Get
            If Text Is Nothing Then
                Return 0
            Else
                Return Text.Length
            End If
        End Get
    End Property

    Public Property Tokens As Integer
    Public Property Tables As New PDFTables
End Class

<Serializable()> Public Class PDFTables
    Inherits List(Of PDFTable)

End Class
<Serializable()> Public Class PDFTable
    Public Property DocumentName As String

    Public Property Page As Integer
    Public Property RowCount As Integer
    Public Property ColumnCount As Integer
    Public Property Rows As New PDFRows

End Class
<Serializable()> Public Class PDFRows
    Inherits List(Of PDFRow)

End Class
<Serializable()> Public Class PDFRow

    Public Property Cells As New List(Of String)

End Class
