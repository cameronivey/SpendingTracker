Imports SpendingTracket.DataAccessLayer

Public Class ProjectionsCalculator

    Private Property context As AppContext = New AppContext()
    Private Property TotalsCalculator As TotalsCalculator = New TotalsCalculator()
    Private Property AveragesCalculator As AveragesCalculator = New AveragesCalculator()

    Public Function GetCategoryMonthProjection(category As String, month As String, year As Integer) As Decimal
        Dim monthTotal = TotalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = category), month, year)

        If year < DateTime.Today.Year Or (year = DateTime.Today.Year And Constants.MonthName_List.IndexOf(month) + 1 < DateTime.Today.Month) Then
            Return monthTotal
        End If

        If category = "Needs" Then
            Return GetNeedsProjection(month, year)
        ElseIf category = "Income" Then
            Return GetIncomeProjection(month, year)
        End If

        Return ((1 / (DateTime.Today.Day / DateTime.DaysInMonth(year, Constants.MonthName_List.IndexOf(month) + 1))) * monthTotal)
    End Function

    Private Function GetNeedsProjection(month As String, year As Integer) As Decimal
        Dim projectedBills = New Dictionary(Of String, Decimal)
        For Each billName In Constants.CurrentStaticBills.Keys
            projectedBills.Add(billName, GetBillProjection(billName, month, year))
        Next

        projectedBills.Add("Water", GetWaterBillProjection(month, year))
        projectedBills.Add("Electric", GetElectricBillProjection(month, year))
        projectedBills.Add("Gas", GetGasBillProjection(month, year))

        Return projectedBills.Sum(Function(bill) bill.Value)
    End Function

    Private Function GetBillProjection(billName As String, month As String, year As Integer) As Decimal
        Dim currentMonthTransaction = context.Transactions.SingleOrDefault(Function(t) t.Month = month And t.Year = year And
                                                                                       t.Category.Name = "Needs" And t.Description = billName)


        If currentMonthTransaction IsNot Nothing Then
            Return currentMonthTransaction.Cost
        Else
            Return Constants.CurrentStaticBills.Item(billName)
        End If
    End Function

    Private Function GetWaterBillProjection(month As String, year As Integer) As Decimal
        Dim currentMonthTransaction = context.Transactions.SingleOrDefault(Function(t) t.Month = month And t.Year = year And
                                                                                       t.Category.Name = "Needs" And t.Description = "Water")
        If currentMonthTransaction IsNot Nothing Then
            Return currentMonthTransaction.Cost
        Else
            Return AveragesCalculator.GetThreeMonthAverage("Water", month, year)
        End If
    End Function

    Private Function GetElectricBillProjection(month As String, year As Integer) As Decimal
        Return 0
    End Function

    Private Function GetGasBillProjection(month As String, year As Integer) As Decimal
        Return 0
    End Function

    Private Function GetIncomeProjection(month As String, year As Integer) As Decimal
        Dim monthIncome = TotalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = "Income"), month, year)
        Dim paycheckTransactions = context.Transactions.Where(Function(t) t.Month = month And t.Year = year And t.Description = "Paycheck")
        If paycheckTransactions IsNot Nothing And paycheckTransactions.Count < 2 Then
            Return ((2 - paycheckTransactions.Count) * Constants.CurrentPayCheckAmount) + monthIncome
        Else
            Return monthIncome
        End If

    End Function

End Class
