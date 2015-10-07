@ModelType TransactionsViewModel

@Code
    ViewData("Title") = "Income"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2 class="page-header">Income</h2>

@Using (Html.BeginForm("Income", "Transaction"))

    @<div class="form-group" style="float: left">
        @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float: left"})
    </div>

    @<div class="form-group" style="float: left">
        @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left"})
    </div>

    @<button type="submit" class="btn btn-primary">Filter</button>
End Using

<table class="table table-striped">
    <thead style="font-size: large">
        <tr><td>Income for @Model.Month, @Model.Year</td></tr>
    </thead>
    @For Each transaction In Model.Transactions
        @<tr>
            <td>@transaction.Description</td>
            <td>@transaction.Cost</td>
        </tr>
    Next
    <tfoot>
        <tr>
            <td><b>Total:</b></td>
            <td>@Model.Totals.SingleOrDefault(Function(t) t.Description = "Total Income").Total</td>
        </tr>
    </tfoot>
</table>

