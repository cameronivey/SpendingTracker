Imports SpendingTracker.Domain

Public Class TransactionsViewModel
    Public Property Transactions As List(Of Transaction)
    Public Property Totals As List(Of TotalsViewModel)
    Public Property Month As String
    Public Property Year As Integer
    Public Property CategorySelected As String

    Public Sub New()
        Totals = New List(Of TotalsViewModel)
    End Sub
End Class
