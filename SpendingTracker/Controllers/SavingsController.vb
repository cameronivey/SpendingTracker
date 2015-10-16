Imports System.Web.Script.Serialization
Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class SavingsController
        Inherits Controller

        Private context As AppContext = New AppContext()
        Private Property totalsCalculator As TotalsCalculatorService = New TotalsCalculatorService()
        Private Property Serializer As JavaScriptSerializer = New JavaScriptSerializer()

        ' GET: Savings
        Function Index() As ActionResult
            Dim viewModel = New SavingsViewModel()
            viewModel.Transactions = context.SavingsTransactions.OrderByDescending(Function(t) t.DateOfTransaction).ToList
            viewModel.CurrentBalance = viewModel.Transactions.Sum(Function(t) t.Amount)

            Dim dataList = New List(Of Decimal)
            Dim labelList = New List(Of String)

            For Each mon In Constants.MonthName_List
                Dim currentTransaction = viewModel.Transactions.Last
                Dim totalAmount = 0
                Dim amt = totalsCalculator.GetTotalCost(mon, 2015)
                If amt > 0 Then
                    labelList.Add(mon)
                    Dim firstDayOfMon = New Date(DateTime.Now.Year, Constants.MonthName_List.IndexOf(mon) + 1, 1)
                    Dim transactions = context.SavingsTransactions.Where(Function(t) t.DateOfTransaction < firstDayOfMon)
                    If (transactions.Count > 0) Then
                        dataList.Add(transactions.Sum(Function(t) t.Amount))
                    Else
                        dataList.Add(0)
                    End If
                End If
            Next

            viewModel.LabelsJsString = Serializer.Serialize(labelList.ToArray)
            viewModel.DataJsString = Serializer.Serialize(dataList.ToArray)

            Return View(viewModel)
        End Function

        Function Add(viewModel As AddSavingsViewModel) As ActionResult
            Dim newSavingsTransaction = New SavingsTransaction
            With newSavingsTransaction
                .Type = viewModel.Type
                .DateOfTransaction = viewModel.DateOfTransaction
                .Description = viewModel.Description
                .Amount = viewModel.Amount
            End With

            context.SavingsTransactions.Add(newSavingsTransaction)
            context.SaveChanges()

            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim savingsTransaction = context.SavingsTransactions.SingleOrDefault(Function(t) t.Id = id)
            Dim viewModel = New EditSavingsViewModel
            With viewModel
                .Id = savingsTransaction.Id
                .DateOfTransaction = savingsTransaction.DateOfTransaction
                .Type = savingsTransaction.Type
                .Description = savingsTransaction.Description
                .Amount = savingsTransaction.Amount
            End With

            Return View(viewModel)
        End Function

        <HttpPost()>
        Function Edit(viewModel As EditSavingsViewModel) As ActionResult
            Dim savingsTransaction = context.SavingsTransactions.SingleOrDefault(Function(t) t.Id = viewModel.Id)
            savingsTransaction.DateOfTransaction = viewModel.DateOfTransaction
            savingsTransaction.Type = viewModel.Type
            savingsTransaction.Description = viewModel.Description
            savingsTransaction.Amount = viewModel.Amount

            context.SaveChanges()

            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace