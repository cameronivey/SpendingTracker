Imports SpendingTracker.Domain

Public Class SavingsViewModel
    Public Property CurrentBalance As Decimal
    Public Property Transactions As List(Of SavingsTransaction)
    Public Property LabelsJsString As String
    Public Property DataJsString As String
End Class
