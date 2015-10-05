Public Class Category
    Public Property Id As Integer
    Public Property Name As String
    Public Property Transactions As List(Of Transaction)

    Public Sub New()
        Transactions = New List(Of Transaction)
    End Sub

End Class
