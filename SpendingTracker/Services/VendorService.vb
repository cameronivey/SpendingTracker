Imports SpendingTracker.Domain
Imports SpendingTracket.DataAccessLayer

Public Class VendorService

    Private Property myContext As AppContext = New AppContext()

    Public Function GetVendor(vendorName As String) As Integer
        Dim vendor = myContext.Vendors.SingleOrDefault(Function(v) v.Name = vendorName)

        If vendor Is Nothing Then
            vendor = New Vendor() With {.Name = vendorName}
            myContext.Vendors.Add(vendor)
            myContext.SaveChanges()
        End If

        Return vendor.Id
    End Function
End Class
