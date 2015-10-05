Imports System.ComponentModel.DataAnnotations

Public Class AddTransactionViewModel

    <Required()>
    Public Property Category As String

    <Required()>
    Public Property Description As String

    <Required()>
    Public Property Cost As Decimal

    Public Property Month As String

    Public Property Year As String

End Class
