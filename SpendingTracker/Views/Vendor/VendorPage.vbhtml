@modeltype VendorViewModel

@Code
    ViewData("Title") = "VendorPage"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>@Model.VendorName</h2>

<table>
    <tr>
        <th>Month</th>
        <th>Year</th>
        <th>Description</th>
        <th>Cost</th>
    </tr>
    @For Each transaction In Model.Transactions
       @<tr>
            <td>@transaction.Month</td>
            <td>@transaction.Year</td>
            <td>@transaction.Description</td>
            <td>@transaction.Cost</td>
        </tr>
    Next
</table>

