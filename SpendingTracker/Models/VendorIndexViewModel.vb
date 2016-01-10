Imports SpendingTracker.Domain

Public Class VendorIndexViewModel
    Public Property Vendors As List(Of VendorViewModel)

    Public Sub New()
        Vendors = New List(Of VendorViewModel)
    End Sub
End Class
