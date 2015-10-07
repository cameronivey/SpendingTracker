Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class TransactionController
        Inherits Controller

        Private Property context As AppContext = New AppContext()
        Private Property totalsCalculator As TotalsCalculatorService = New TotalsCalculatorService()

        ' GET: Transaction

        <HttpGet()>
        Function Index(viewModel As TransactionsViewModel) As ActionResult
            If viewModel.Month Is Nothing Or viewModel.Year = 0 Then
                viewModel.Month = DateTime.Now().ToString("MMMM")
                viewModel.Year = DateTime.Now().Year
            End If

            viewModel.Transactions = context.Transactions.Where(Function(t) t.Month = viewModel.Month And t.Year = viewModel.Year).ToList
            viewModel.Totals.AddRange(GetCategoryTotals(viewModel.Transactions))
            viewModel.Totals.AddRange(GetSummaryTotals(viewModel.Transactions))

            Return View(viewModel)
        End Function

        <HttpGet()>
        Function AddTransaction() As ActionResult
            Dim viewModel = New AddTransactionViewModel
            With viewModel
                .RecentTransactions = context.Transactions.OrderByDescending(Function(t) t.Id).AsQueryable.Take(10).ToList
            End With

            Return View(viewModel)
        End Function

        <HttpPost()>
        Function AddTransaction(viewModel As AddTransactionViewModel) As ActionResult
            Dim newTransaction = New Transaction
            With newTransaction
                .Category = context.Categories.SingleOrDefault(Function(c) c.Id = viewModel.CategoryId)
                .Description = viewModel.Description
                .Cost = viewModel.Cost
                .Month = viewModel.Month
                .Year = viewModel.Year
            End With

            context.Transactions.Add(newTransaction)
            context.Categories.SingleOrDefault(Function(c) c.Id = viewModel.CategoryId).Transactions.Add(newTransaction)
            context.SaveChanges()

            Return RedirectToAction("AddTransaction", "Transaction")
        End Function

        <HttpGet()>
        Function EditTransaction(id As Integer)
            Dim transaction = context.Transactions.SingleOrDefault(Function(t) t.Id = id)
            Dim viewModel = New EditTransactionViewModel
            With viewModel
                .Id = transaction.Id
                .Description = transaction.Description
                .Cost = transaction.Cost
                .Month = transaction.Month
                .Year = transaction.Year
            End With

            If transaction.Category IsNot Nothing Then
                viewModel.CategoryId = transaction.Category.Id
            Else
                viewModel.CategoryId = 1
            End If

            Return View(viewModel)
        End Function

        <HttpPost()>
        Function EditTransaction(viewModel As EditTransactionViewModel)
            Dim transaction = context.Transactions.SingleOrDefault(Function(t) t.Id = viewModel.Id)
            transaction.Description = viewModel.Description
            transaction.Category = context.Categories.SingleOrDefault(Function(c) c.Id = viewModel.CategoryId)
            transaction.Cost = viewModel.Cost
            transaction.Month = viewModel.Month
            transaction.Year = viewModel.Year

            context.SaveChanges()

            Return RedirectToAction("Index", "Transaction")
        End Function

        <HttpPost()>
        Function DeleteTransaction(id As Integer)
            Dim transaction = context.Transactions.SingleOrDefault(Function(t) t.Id = id)
            context.Transactions.Remove(transaction)
            context.SaveChanges()

            Return RedirectToAction("AddTransaction", "Transaction")
        End Function

        <HttpGet()>
        Function Income(viewModel As TransactionsViewModel) As ActionResult
            If viewModel.Month Is Nothing Or viewModel.Year = 0 Then
                viewModel.Month = DateTime.Now().ToString("MMMM")
                viewModel.Year = DateTime.Now().Year
            End If

            viewModel.Transactions = context.Transactions.Where(Function(t) t.Category.Name = "Income" _
                                                                            And t.Month = viewModel.Month _
                                                                            And t.Year = viewModel.Year).ToList

            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Income", .Total = GetCostTotals(viewModel.Transactions)})

            Return View(viewModel)
        End Function

        <HttpGet()>
        Function Overview() As ActionResult
            Dim viewModel = New TransactionsViewModel

            Dim category = Nothing
            Dim incomeCategory = context.Categories.SingleOrDefault(Function(c) c.Name = "Income")
            Dim yearNum = 2015

            For Each monthSelectItem In Constants.Month_List
                For Each cat In Constants.Category_List
                    category = context.Categories.SingleOrDefault(Function(c) c.Name = cat)
                    viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("{0}_{1}_{2}", monthSelectItem.Text, cat, yearNum), category, monthSelectItem.Text, yearNum))
                Next
                viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("{0}_{1}", monthSelectItem.Text, yearNum), monthSelectItem.Text, yearNum))
                viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("{0}_Income_{1}", monthSelectItem.Text, yearNum), incomeCategory, monthSelectItem.Text, yearNum))
                viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = String.Format("{0}_Net_{1}", monthSelectItem.Text, yearNum),
                                                               .Total = totalsCalculator.GetTotalCost(incomeCategory, monthSelectItem.Text, yearNum) - totalsCalculator.GetTotalCost(monthSelectItem.Text, yearNum)})
            Next

            For Each cat In Constants.Category_List
                category = context.Categories.SingleOrDefault(Function(c) c.Name = cat)
                viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("{0}_{1}", cat, yearNum), category, yearNum))
            Next

            viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("{0}", yearNum), yearNum))
            viewModel.Totals.Add(totalsCalculator.GetTotalViewModel("Sum", String.Format("Income_{0}", yearNum), incomeCategory, yearNum))
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = String.Format("Net_{0}", yearNum),
                                                               .Total = totalsCalculator.GetTotalCost(incomeCategory, yearNum) - totalsCalculator.GetTotalCost(yearNum)})

            Return View(viewModel)
        End Function

        Private Function GetCategoryTotals(transactions As List(Of Transaction)) As List(Of TotalsViewModel)
            Dim list = New List(Of TotalsViewModel)

            For Each category In context.Categories
                Dim cost = GetCostTotals(transactions.Where(Function(t) t.Category.Id = category.Id).ToList)
                list.Add(New TotalsViewModel With {.Type = "Category", .Description = category.Name, .Total = cost})
            Next

            Return list
        End Function

        'TODO: Refactor
        Private Function GetSummaryTotals(transactions As List(Of Transaction)) As List(Of TotalsViewModel)
            Dim list = New List(Of TotalsViewModel)

            list.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Spent Without Needs", .Total = GetCostTotals(transactions.Where(Function(t) t.Category.Name <> "Needs" And t.Category.Name <> "Income").ToList)})
            list.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Needs", .Total = GetCostTotals(transactions.Where(Function(t) t.Category.Name = "Needs").ToList)})
            list.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Spent", .Total = GetCostTotals(transactions.Where(Function(t) t.Category.Name <> "Income").ToList)})
            list.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Income", .Total = GetCostTotals(transactions.Where(Function(t) t.Category.Name = "Income").ToList)})
            list.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Net Income", .Total = list.SingleOrDefault(Function(total) total.Description = "Total Income").Total -
                                                                                                                list.SingleOrDefault(Function(total) total.Description = "Total Spent").Total})

            Return list
        End Function

        Private Function GetCostTotals(transactions As List(Of Transaction)) As Decimal
            Dim sum As Decimal = 0.0
            For Each transaction In transactions
                sum += transaction.Cost
            Next

            Return sum
        End Function

    End Class
End Namespace