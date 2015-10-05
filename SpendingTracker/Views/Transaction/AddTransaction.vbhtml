@ModelType AddTransactionViewModel

@Code
    ViewData("Title") = "AddTransaction"
End Code

<body>
    <h2 class="page-header">Add Transaction</h2>
    <div class="col-lg-6">

        @Using (Html.BeginForm("AddTransaction", "Transaction"))
            @<fieldset>
                 <div class="form-group" style="float: left">
                     @Html.LabelFor(Function(m) m.Year)
                     @Html.DropDownListFor(Function(m) m.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float:left"})
                 </div>

                 <div class="form-group" style="float: left">
                     @Html.LabelFor(Function(m) Model.Month)
                     @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left"})
                 </div>

                 <div class="form-group" style="clear: both">
                     @Html.DropDownListFor(Function(m) Model.CategoryId, Constants.Category_SelectList, New With {Key .class = "form-control", .style = "float: left; width: 120px"})<br />
                 </div>

                @Html.TextBoxFor(Function(m) Model.Description, New With {Key .class = "form-control", .maxlength = "20", .style = "width: 200px", .placeholder = "Description"})<br />

                @Html.TextBoxFor(Function(m) Model.Cost, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px", .placeholder = "$$$"})<br />

                <button type="submit" class="btn btn-success">Add Transaction</button>
            </fieldset>
        End Using
    </div>

    <div class="col-lg-6">
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

