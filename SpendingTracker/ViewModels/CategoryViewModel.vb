Imports SpendingTracker.Domain

Public Class CategoryViewModel
    Public Property CategoryName As String
    Public Property Year As Integer
    Public Property MonthTotals As Dictionary(Of String, Decimal)
    Public Property Total As Decimal
    Public Property LabelsJavascriptString As String
    Public Property DataJavascriptString As String

    Public Sub New()
        MonthTotals = New Dictionary(Of String, Decimal)
    End Sub
End Class
