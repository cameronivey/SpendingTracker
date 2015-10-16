@ModelType SavingsViewModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2 class="page-header">Index</h2>
<body onload="getSavingsChart(@Model.LabelsJsString, @Model.DataJsString)">
    <div class="row">
        <div class="col-lg-6">
            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#addSavingsTransactionModal">Add Savings Transaction</button>
            <div id="balanceDisplay" style="float:right">
                <label>Current Balance</label>
                <span style="border: outset; padding: 5px">@Model.CurrentBalance</span>
            </div>
        </div>
        <div class="col-lg-6">

        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-lg-6">
            <table class="table table-striped">
                <tr>
                    <th></th>
                    <th>Date</th>
                    <th>Type</th>
                    <th>Description</th>
                    <th>Amount</th>
                </tr>
                @For Each transaction In Model.Transactions
                    @<tr>
                        <td><button type="button" class="btn btn-link" onclick="editSavingsTransaction(@transaction.Id)">Edit</button></td>
                        <td>@transaction.DateOfTransaction.ToShortDateString</td>
                        <td>@transaction.Type</td>
                        <td>@transaction.Description</td>
                        <td>@transaction.Amount</td>
                    </tr>
                Next
            </table>
        </div>

        <div class="col-lg-6">
            <h4 style="text-align: center">Savings</h4>
            <canvas id="savingsChart" width="500" height="250"></canvas>
        </div>
    </div>

    <div id="addSavingsTransactionModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Savings Transaction</h4>
                </div>
                <div class="modal-body">
                    @Html.Partial("AddSavingsPartial", New AddSavingsViewModel With {.DateOfTransaction = DateTime.Now})
                </div>
            </div>

        </div>
    </div>
</body>

@*<div id="editSavingsTransactionModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Edit Savings Transaction</h4>
            </div>
            <div class="modal-body">
                @Html.Partial("EditSavingsPartial", New EditSavingsViewModel With {.DateOfTransaction = DateTime.Now})
            </div>
        </div>

    </div>
</div>*@

