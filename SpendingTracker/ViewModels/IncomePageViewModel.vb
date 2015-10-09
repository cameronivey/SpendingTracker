Imports SpendingTracker.Domain

Public Class IncomePageViewModel
    Public Property Transactions As List(Of Transaction)
    Public Property Month As String
    Public Property Year As Integer
    Public Property Totals As List(Of TotalsViewModel)
    Public Property LabelsJavascriptString As String
    Public Property DataJavascriptString As String

    Public Sub New()
        Totals = New List(Of TotalsViewModel)
    End Sub
End Class
