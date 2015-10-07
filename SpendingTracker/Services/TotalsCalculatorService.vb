Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Public Class TotalsCalculatorService
    Private Property context As AppContext = New AppContext()

    Public Function GetTotalViewModel(type As String, Description As String, category As Category, month As String, year As Integer) As TotalsViewModel
        Return New TotalsViewModel With {.Type = type, .Description = Description, .Total = GetTotalCost(category, month, year)}
    End Function

    Public Function GetTotalViewModel(type As String, Description As String, month As String, year As Integer) As TotalsViewModel
        Return New TotalsViewModel With {.Type = type, .Description = Description, .Total = GetTotalCost(month, year)}
    End Function

    Public Function GetTotalViewModel(type As String, Description As String, category As Category, year As Integer) As TotalsViewModel
        Return New TotalsViewModel With {.Type = type, .Description = Description, .Total = GetTotalCost(category, year)}
    End Function

    Public Function GetTotalViewModel(type As String, Description As String, year As Integer) As TotalsViewModel
        Return New TotalsViewModel With {.Type = type, .Description = Description, .Total = GetTotalCost(year)}
    End Function

    Public Function GetTotalCost(year As Integer) As Decimal
        Dim transactions = context.Transactions.Where(Function(t) t.Year = year And t.Category.Name <> "Income")
        Return GetSum(transactions)
    End Function

    Public Function GetTotalCost(month As String, year As Integer) As Decimal
        Dim transactions = context.Transactions.Where(Function(t) t.Month = month And t.Year = year And t.Category.Name <> "Income")
        Return GetSum(transactions)
    End Function

    Public Function GetTotalCost(category As Category, year As Integer) As Decimal
        Dim transactions = context.Transactions.Where(Function(t) t.Category.Id = category.Id And t.Year = year)
        Return GetSum(transactions)
    End Function

    Public Function GetTotalCost(category As Category, month As String, year As Integer) As Decimal
        Dim transactions = context.Transactions.Where(Function(t) t.Category.Id = category.Id And t.Month = month And t.Year = year)
        Return GetSum(transactions)
    End Function

    Private Function GetSum(transactions As IQueryable(Of Transaction)) As Decimal
        If transactions.Count > 0 Then
            Return transactions.Sum(Function(t) t.Cost)
        Else
            Return 0
        End If
    End Function

End Class
