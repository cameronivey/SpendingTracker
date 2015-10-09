@ModelType IncomePageViewModel

@Code
    ViewData("Title") = "Income"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<body onload="getIncomeChart(@Model.LabelsJavascriptString, @Model.DataJavascriptString)">
    <h2 class="page-header">Income</h2>

    <div class="row">
        <div class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .id = "yearNum", .class = "form-control", .style = "float: left", .onchange = "getIncomeTransactions()"})
        </div>

        <div class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .id = "monthName", .class = "form-control", .style = "float: left", .onchange = "getIncomeTransactions()"})
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
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
                        <td style="border: inset">@Model.Totals.SingleOrDefault(Function(t) t.Description = "Total Income").Total</td>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="col-lg-6">
            <h4 style="text-align: center">Income @Model.Year</h4>
            <canvas id="incomeChart" width="500" height="250"></canvas>
        </div>
    </div>
</body>

