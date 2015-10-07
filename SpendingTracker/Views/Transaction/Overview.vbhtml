@ModelType TransactionsViewModel

@Code
    ViewData("Title") = "Overview"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2 class="page-header">Overview 2015</h2>

@*@Using (Html.BeginForm("Overview", "Transaction"))

    @<div class="form-group" style="float: left">
        @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float: left"})
    </div>

    @<button type="submit" class="btn btn-primary">Filter</button>
End Using*@

<table class="table table-striped">
    <tr>
        <th>Month</th>
        <th>Food</th>
        <th>Alcohol/Bars</th>
        <th>Entertainment</th>
        <th>Shopping</th>
        <th>Needs</th>
        <th>Other</th>
        <th>Total Spent</th>
        <th>Total Income</th>
        <th>Net</th>
    </tr>
    @For Each name In Constants.Month_List
        @<tr>
            <td>@Html.ActionLink(name.Text, "Index", New With {.Month = name.Text, .Year = 2015})</td>
            @For Each cat In Constants.Category_List
                @<td>@Html.ActionLink("$" + Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_" + cat + "_2015").Total.ToString, "Index", New With {.Month = name.Text, .Year = 2015, .CategorySelected = cat})</td>
                @*@<td>$@Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_" + cat + "_2015").Total</td>*@
            Next
            <td style="border-left: double">$@Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_2015").Total</td>
            @*<td>$@Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_Income_2015").Total</td>*@
            <td>@Html.ActionLink("$" + Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_Income_2015").Total.ToString, "Income", New With {.Month = name.Text, .Year = 2015})</td>
            <td>$@Model.Totals.SingleOrDefault(Function(t) t.Description = name.Text + "_Net_2015").Total</td>
        </tr>
    Next
    <tr>
        <td><b>Totals:</b></td>
        @For Each cat In Constants.Category_List
            @<td>$@Model.Totals.SingleOrDefault(Function(t) t.Description = cat + "_2015").Total</td>
        Next
        <td style="border: inset">$@Model.Totals.SingleOrDefault(Function(t) t.Description = "2015").Total</td>
        <td style="border: inset">$@Model.Totals.SingleOrDefault(Function(t) t.Description = "Income_2015").Total</td>
        <td style="border: inset">$@Model.Totals.SingleOrDefault(Function(t) t.Description = "Net_2015").Total</td>
    </tr>
</table>

