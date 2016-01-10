Imports SpendingTracker.Domain

Public Class VendorViewModel
    Public Property VendorId As Integer
    Public Property VendorName As String
    Public Property Transactions As List(Of Transaction)

    Public Sub New()
        Transactions = New List(Of Transaction)
    End Sub
End Class
