Imports System.ComponentModel.DataAnnotations
Imports SpendingTracker.Domain

Public Class AddTransactionViewModel

    <Required()>
    Public Property CategoryId As Integer

    <Required()>
    Public Property Description As String

    <Required()>
    Public Property Cost As Decimal

    Public Property Month As String

    Public Property Year As String

End Class
