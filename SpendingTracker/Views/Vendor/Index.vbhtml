@Modeltype VendorIndexViewModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Vendors</h2>

@For Each vendor In Model.Vendors
    @<a href="/Vendor/VendorPage/@vendor.VendorId">@vendor.VendorName (@vendor.Transactions.Count)</a>@<br />
Next

