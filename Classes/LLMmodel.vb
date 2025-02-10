<Serializable()> Public Class LLMmodel
    Public Property Name As String
    Public Property Size As Long
    Public Property ParameterSize As String
    Public Property Quantization As String

    Public ReadOnly Property SizeString As String
        Get
            Return Utils.FormatFileSize(Size)
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class

<Serializable()> Public Class LLMmodels : Inherits List(Of LLMmodel)

End Class
