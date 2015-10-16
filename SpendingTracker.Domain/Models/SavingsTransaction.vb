Public Class SavingsTransaction
    Public Property Id As Integer
    Public Property Type As SavingsTransactionType
    Public Property DateOfTransaction As Date
    Public Property Amount As Decimal
    Public Property Description As String
End Class

Public Enum SavingsTransactionType
    Deposit = 0
    Withdrawal = 1
End Enum

