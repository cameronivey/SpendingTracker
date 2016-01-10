Imports SpendingTracker.Domain

Public Class AddTransactionsViewModel

    Public Property TransactionViewModels As List(Of AddTransactionViewModel)
    Public Property RecentTransactions As List(Of Transaction)

    Public Sub New()
        TransactionViewModels = New List(Of AddTransactionViewModel)({New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel(),
                                                                       New AddTransactionViewModel()})
    End Sub

End Class
