@ModelType AddTransactionsViewModel

@Code
    ViewData("Title") = "AddTransaction"
End Code

<body>
    <h2 class="page-header">Add Transaction</h2>
    <div class="col-lg-7">

        @Using (Html.BeginForm("AddTransaction", "Transaction"))
            @<fieldset>
                @For i As Integer = 0 To Model.TransactionViewModels.Count - 1
                    @Html.DropDownListFor(Function(m) m.TransactionViewModels(i).Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float:left; width: 85px"})
                    @Html.DropDownListFor(Function(m) Model.TransactionViewModels(i).Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left; width: 125px"})
                    @Html.DropDownListFor(Function(m) Model.TransactionViewModels(i).CategoryId, Constants.Category_SelectList, New With {Key .class = "form-control", .style = "float: left; width: 120px"})
                    @Html.TextBoxFor(Function(m) Model.TransactionViewModels(i).Description, New With {Key .class = "form-control", .maxlength = "20", .style = "float: left; width: 200px", .placeholder = "Description"})
                    @Html.TextBoxFor(Function(m) Model.TransactionViewModels(i).Cost, New With {Key .class = "form-control", .maxlength = "7", .style = "float: left; width: 80px", .placeholder = "$$$"})
                Next
                 
                <button type="submit" class="btn btn-success">Add Transactions</button>
            </fieldset>
        End Using
    </div>

    <div class="col-lg-5">
        <h4>Recently Added</h4>
         <table class="table">
             <tr>
                 <th style="width: 15%"></th>
                 <th style="width: 25%">Month</th>
                 <th style="width: 35%">Category</th>
                 <th style="width: 40%">Description</th>
                 <th style="width: 10%">Amount</th>
             </tr>
            @For Each transaction In Model.RecentTransactions
                @<tr>
                     <td><a href="/Transaction/EditTransaction/@transaction.Id">Edit</a></td>
                     <td>@transaction.Month</td>  
                     @If (transaction.Category IsNot Nothing) Then
                        @<td>@transaction.Category.Name</td>
                     Else
                        @<td>Null Category</td>
                     End If
                     <td>@transaction.Description</td>
                     <td>@transaction.Cost</td>
                </tr>
            Next
         </table>
    </div>
</body>

