@ModelType TransactionsViewModel

@Code
    ViewData("Title") = "Transactions"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<body onload="selectMonth('@Model.Month')">
    <h2 class="page-header">Transactions</h2>

    <div class="row">
        @Using (Html.BeginForm("GetTransactions", "Transaction"))

            @<div Class="form-group" style="float: left">
                @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float: left"})
            </div>

            @<div Class="form-group" style="float: left">
                @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left"})
            </div>

            @<button type="submit" class="btn btn-primary">Filter</button>


            @<div style = "float: right;" >
                <a href="/Transaction/AddTransaction" class="btn btn-primary">Add A Transaction</a>
            </div>
        End Using

    </div>

    <ul class="nav nav-tabs">
        <li role="presentation" class="active"><a data-toggle="tab" href="#tab_Summary">Summary</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_Food">Food</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_AlcoholBars">Alcohol / Bars</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_Entertainment">Entertainment</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_Shopping">Shopping</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_Needs">Needs</a></li>
        <li role="presentation"><a data-toggle="tab" href="#tab_Other">Other</a></li>
    </ul>

    
    <div class="tab-content">
        <div id="tab_Summary" class="tab-pane fade in active">
            <div class="col-lg-6">
                <table class="table table-striped">
                    <thead>
                        <tr><td style="font-size: large">Total Spending For @Model.Month, @Model.Year</td></tr>
                    </thead>
                    @For Each category In Constants.Category_List
                        @<tr>
                            <td>@category</td>
                            <td align="right">$@Model.Totals.SingleOrDefault(Function(t) t.Description = category).Total</td>
                        </tr>
                    Next
                    <tfoot>
                        <tr>
                            <td><b>Total:</b></td>
                            <td align="right">$@Model.Totals.SingleOrDefault(Function(t) t.Description = "Total Spent").Total</td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="col-lg-6">
                <table class="table table-striped">
                    @For Each total In Model.Totals.Where(Function(t) t.Type = "Sum")
                        @<tr>
                            <td>@total.Description</td>
                            <td>$@total.Total</td>
                        </tr>
                    Next
                </table>
            </div>
        </div>

        @For Each category In Constants.Category_List
            @<div id="tab_@category" class="tab-pane fade">
                <table class="table table-condensed">
                    <thead>
                        <tr><td style="font-size: large">@category in @Model.Month, @Model.Year</td></tr>
                    </thead>
                    @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = category)
                        @<tr>
                            <td>@transaction.Description</td>
                            <td align="right">$@transaction.Cost</td>
                        </tr>
                    Next
                    <tfoot>
                        <tr>
                            <td><b>Total:</b></td>
                            <td align="right" style="background-color: darkgray">$@Model.Totals.SingleOrDefault(Function(t) t.Description = category).Total</td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        Next
    </div>
</body>

