Imports SpendingTracket.DataAccessLayer

Public Class AveragesCalculator
    Private Property context As AppContext = New AppContext()

    Public Function GetCategoryMonthlyAverage(category As String, year As Integer) As Decimal
        Dim totalsCalculator = New TotalsCalculator()
        Dim monthTotalsList = New List(Of Decimal)

        For Each mon In Constants.MonthName_List
            ' add only if total is above certain number?
            Dim monthCost = totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = category), mon, year)
            If IsAdequateMonth(mon, year, monthCost) Then
                monthTotalsList.Add(monthCost)
            End If
        Next

        If monthTotalsList.Count > 0 Then
            Return monthTotalsList.Average()
        Else
            Return 0
        End If
    End Function

    Public Function GetThreeMonthAverage(transactionDescription As String, month As String, year As Integer) As Decimal
        Dim bills = New List(Of Decimal)

        Dim currentMonth = Constants.MonthName_List.IndexOf(month) + 1
        Dim currentYear = year
        Dim searchMonth = currentMonth
        Dim searchyear = currentYear
        UpdateSearchMonthAndYear(searchMonth, searchyear)

        For i As Integer = 0 To 3
            Dim monthName = Constants.MonthName_List(searchMonth - 1)
            Dim bill = context.Transactions.SingleOrDefault(Function(t) t.Month = monthName And t.Year = searchyear And
                                                                        t.Category.Name = "Needs" And t.Description = transactionDescription)

            If bill IsNot Nothing Then
                bills.Add(bill.Cost)
            End If
            UpdateSearchMonthAndYear(searchMonth, searchyear)
            i = i + 1
        Next

        If bills.Count > 0 Then
            Return bills.Average()
        Else
            Return 0
        End If

    End Function

    Private Function IsAdequateMonth(mon As String, year As Integer, monthCost As Decimal) As Boolean
        If monthCost > 0 And Not (mon Is "June" And year = 2015) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub UpdateSearchMonthAndYear(ByRef searchMonth As Integer, ByRef searchYear As Integer)
        searchMonth = searchMonth - 1
        If searchMonth = 0 Then
            searchMonth = 12
            searchYear = searchYear - 1
        End If
    End Sub
End Class
