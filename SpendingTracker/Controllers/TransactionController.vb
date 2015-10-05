Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class TransactionController
        Inherits Controller

        Private months = New List(Of SelectListItem)

        ' GET: Transaction
        Function Index() As ActionResult
            Return GetMonthTransactions(DateTime.Now().ToString("MMMM"))
        End Function

        <HttpGet()>
        Function AddTransaction() As ActionResult
            Dim context = New AppContext()

            Dim viewModel = New AddTransactionPageViewModel
            With viewModel
                .Categories = context.Categories.ToList
                .RecentTransactions = context.Transactions.OrderByDescending(Function(t) t.Id).ToList
            End With

            Return View(viewModel)
        End Function

        <HttpPost()>
        Function AddTransaction(viewModel As AddTransactionViewModel) As ActionResult
            Dim context = New AppContext()

            Dim newTransaction = New Transaction
            With newTransaction
                .Category = context.Categories.SingleOrDefault(Function(c) c.Id = viewModel.Category)
                .Description = viewModel.Description
                .Cost = viewModel.Cost
                .Month = viewModel.Month
                .Year = viewModel.Year
            End With

            context.Transactions.Add(newTransaction)
            context.SaveChanges()

            Return RedirectToAction("AddTransaction", "Transaction")
            Return View(viewModel)
        End Function

        <HttpGet()>
        Function EditTransaction(id As Integer)
            Dim context = New AppContext()
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
            Dim context = New AppContext()
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
            Dim context = New AppContext()
            Dim transaction = context.Transactions.SingleOrDefault(Function(t) t.Id = id)
            context.Transactions.Remove(transaction)
            context.SaveChanges()

            Return RedirectToAction("AddTransaction", "Transaction")
        End Function

        Function GetMonthTransactions(monthName As String)
            Dim context = New AppContext()

            Dim viewModel = New TransactionsViewModel
            With viewModel
                .Transactions = context.Transactions.Where(Function(t) t.Month = monthName).ToList
                .Month = monthName
            End With

            Return View("Index", viewModel)
        End Function

        'Function AddTransaction(viewModel As AddTransactionViewModel) As ActionResult
        '    Dim newTransaction = New Transaction
        '    With newTransaction
        '        .Category = viewModel.Category
        '        .Description = viewModel.Description
        '        .Cost = viewModel.Cost
        '        .Month = viewModel.Month
        '        .Year = viewModel.Year
        '    End With

        '    Dim context = New AppContext()
        '    context.Transactions.Add(newTransaction)
        '    context.SaveChanges()

        '    Return RedirectToAction("Index", "Transaction")
        'End Function
    End Class
End Namespace