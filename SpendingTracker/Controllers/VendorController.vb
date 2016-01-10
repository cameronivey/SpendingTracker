Imports System.Web.Mvc
Imports SpendingTracket.DataAccessLayer
Imports SpendingTracker.Domain

Namespace Controllers
    Public Class VendorController
        Inherits Controller

        Private Property Context As AppContext = New AppContext()

        ' GET: Vendor
        Function Index() As ActionResult
            Dim viewModel = New VendorIndexViewModel()
            Dim vendors = Context.Vendors.Where(Function(v) v.Id > 0).ToList()
            For Each Vendor In vendors
                Dim transactions = Context.Transactions.Where(Function(t) t.Vendor.Id = Vendor.Id).ToList()
                viewModel.Vendors.Add(New VendorViewModel() With {.VendorId = Vendor.Id, .VendorName = Vendor.Name, .Transactions = transactions})
            Next
            Return View(viewModel)
        End Function

        <HttpGet()>
        Function VendorPage(id As Integer)
            Dim vendor = Context.Vendors.SingleOrDefault(Function(v) v.Id = id)
            Dim viewModel = New VendorViewModel() With {.VendorId = vendor.Id, .VendorName = vendor.Name, .Transactions = Context.Transactions.Where(Function(t) t.Vendor.Id = vendor.Id).ToList()}

            Return View(viewModel)
        End Function
    End Class
End Namespace