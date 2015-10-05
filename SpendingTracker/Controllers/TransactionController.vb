Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class TransactionController
        Inherits Controller

        Private Property context As AppContext = New AppContext()

        ' GET: Transaction
        Function Index() As ActionResult

            Dim viewModel = New TransactionsViewModel
            With viewModel
                .Month = DateTime.Now().ToString("MMMM")
                .Year = DateTime.Now().Year
            End With

            Return GetTransactions(viewModel)
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

            Return RedirectToAction("AddTransaction", "Transaction")
        End Function

        <HttpPost()>
        Function DeleteTransaction(id As Integer)
            Dim transaction = context.Transactions.SingleOrDefault(Function(t) t.Id = id)
            context.Transactions.Remove(transaction)
            context.SaveChanges()

            Return RedirectToAction("AddTransaction", "Transaction")
        End Function

        Function GetTransactions(viewModel As TransactionsViewModel)
            If viewModel Is Nothing Or viewModel.Month Is Nothing Or viewModel.Year = 0 Then
                Return RedirectToAction("Index")
            End If

            Dim context = New AppContext()

            viewModel.Transactions = context.Transactions.Where(Function(t) t.Month = viewModel.Month And t.Year = viewModel.Year).ToList
            viewModel.Totals.AddRange(GetCategoryTotals(viewModel.Transactions))
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Spent Without Needs", .Total = GetCostTotals(viewModel.Transactions.Where(Function(t) t.Category.Name <> "Needs" And t.Category.Name <> "Income").ToList)})
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Needs", .Total = GetCostTotals(viewModel.Transactions.Where(Function(t) t.Category.Name = "Needs").ToList)})
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Spent", .Total = GetCostTotals(viewModel.Transactions.Where(Function(t) t.Category.Name <> "Income").ToList)})
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Total Income", .Total = GetCostTotals(viewModel.Transactions.Where(Function(t) t.Category.Name = "Income").ToList)})
            viewModel.Totals.Add(New TotalsViewModel With {.Type = "Sum", .Description = "Net Income", .Total = viewModel.Totals.SingleOrDefault(Function(total) total.Description = "Total Income").Total -
                                                                                                                viewModel.Totals.SingleOrDefault(Function(total) total.Description = "Total Spent").Total})

            Return View("Index", viewModel)
        End Function

        Private Function GetCategoryTotals(transactions As List(Of Transaction)) As List(Of TotalsViewModel)
            Dim list = New List(Of TotalsViewModel)

            For Each category In context.Categories
                list.Add(New TotalsViewModel With {.Type = "Category", .Description = category.Name, .Total = GetCostTotals(transactions.Where(Function(t) t.Category.Id = category.Id).ToList)})
            Next

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