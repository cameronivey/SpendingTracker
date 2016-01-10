@ModelType TransactionsViewModel

@Code
    ViewData("Title") = "Transactions"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<body onload="selectMonth('@Model.Month'); selectTab('@Model.CategorySelected')">
    <h2 class="page-header">Transactions</h2>

    <div class="row">
        <div Class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .id = "yearNum", .class = "form-control", .style = "float: left", .onchange = "getExpenseTransactions()"})
        </div>

        <div Class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .id = "monthName", .class = "form-control", .style = "float: left", .onchange = "getExpenseTransactions()"})
        </div>

        <div style="float: right">
            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#addTransactionModal">Add Transaction</button>
        </div>
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
                        <tr><td colspan="5" style="font-size: large">Total Spending For @Model.Month, @Model.Year</td></tr>
                        <tr>
                            <th>Category</th>
                            <th>Projected</th>
                            <th>Average</th>
                            <th style="text-align: right;border-bottom: solid">Total</th>
                        </tr>
                    </thead>
                    @For Each category In Constants.Category_List
                        @<tr>
                            <td>@category</td>
                            <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Projection" And t.Description = category).Total.ToString("C")</td>
                             <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Average" And t.Description = category).Total.ToString("C")</td>
                            <td align="right" style="border-left: solid; border-right: solid"><b>$@Model.Totals.SingleOrDefault(Function(t) t.Type = "Category" And t.Description = category).Total</b></td>
                        </tr>
                    Next
                    <tfoot>
                        <tr>
                            <td><b>Total:</b></td>
                            <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Projection" And t.Description = "Total Spent").Total.ToString("C")</td>
                            <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Average" And t.Description = "Total Spent").Total.ToString("C")</td>
                            <td align="right" style="border: inset; border-top: solid">$@Model.Totals.SingleOrDefault(Function(t) t.Type = "Sum" And t.Description = "Total Spent").Total</td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="col-lg-6">
                <table class="table table-striped">
                    <thead>
                        <tr><td colspan="5" style="font-size: large">Totals</td></tr>
                    </thead>
                    <tr>
                        <th></th>
                        <th>Projected</th>
                        <th>Average</th>
                        <th style="text-align: right">Total</th>
                    </tr>
                    @For Each total In Model.Totals.Where(Function(t) t.Type = "Sum")
                        @<tr>
                            <td>@total.Description</td>
                            <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Projection" And t.Description = total.Description).Total.ToString("C")</td>
                            <td>@Model.Totals.SingleOrDefault(Function(t) t.Type = "Average" And t.Description = total.Description).Total.ToString("C")</td>
                            <td align="right">$@total.Total</td>
                        </tr>
                    Next
                </table>
            </div>
        </div>

        @For Each category In Constants.Category_List
            @<div id="tab_@category" class="tab-pane fade">
                 <div class="col-lg-6">
                     <table class="table table-condensed">
                         <thead>
                             <tr><td style="font-size: large">@category in @Model.Month, @Model.Year</td></tr>
                         </thead>
                         @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = category)
                             @<tr>
                                 <td>@transaction.Description <a href="/Vendor/VendorPage/@transaction.vendor.Id" style="font-size: xx-small">View Vendor Page</a></td>
                                 <td><a href="/Transaction/EditTransaction/@transaction.Id">Edit</a></td>
                                 <td align="right">$@transaction.Cost</td>
                             </tr>
                         Next
                         <tfoot>
                             <tr>
                                 <td><b>Total:</b></td>
                                 <td></td>
                                 <td align="right" style="border: inset">$@Model.Totals.SingleOrDefault(Function(t) t.type = "Category" And t.Description = category).Total</td>
                             </tr>
                         </tfoot>
                     </table>
                 </div>  
            </div>
        Next
    </div>
</body>

<div id="addTransactionModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Add Transaction</h4>
            </div>
            <div class="modal-body">
                @Html.Partial("AddTransactionPartial", New AddTransactionViewModel With {.Month = Model.Month, .Year = Model.Year})
            </div>
            <div class="modal-footer">
                <button class="btn btn-success" onclick="addTransaction()">Add Transaction</button>
                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
            </div>
        </div>

    </div>
</div>
