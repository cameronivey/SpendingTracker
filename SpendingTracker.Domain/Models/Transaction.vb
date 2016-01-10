Public Class Transaction
    Public Property Id As Integer
    Public Property Description As String
    Public Overridable Property Vendor As Vendor
    Public Property Cost As Decimal
    Public Property Month As String
    Public Property Year As Integer
    Public Overridable Property Category As Category
End Class
