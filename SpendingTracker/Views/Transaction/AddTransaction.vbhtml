@ModelType AddTransactionPageViewModel

@Code
    ViewData("Title") = "AddTransaction"
End Code

<body>
    <h2 class="page-header">Add Transaction</h2>
    <div class="col-lg-6">

        @Using (Html.BeginForm("AddTransaction", "Transaction"))
            @<fieldset>
                 <div class="form-group" style="float: left">
                     <label for="yearSelect" style="float: left">Year:</label>
                     <select name="year" class="form-control" id="yearSelect" style="float: left">
                         <option value="2015"> 2015</option>
                         <option value="2016"> 2016</option>
                     </select>
                 </div>

                 <div class="form-group" style="float: left">
                     <label for="monthSelect">Month:</label>
                     <select name="month" class="form-control" id="monthSelect">
                         <option selected disabled></option>
                         <option value="January"> January</option>
                         <option value="February"> February</option>
                         <option value="March"> March</option>
                         <option value="April"> April</option>
                         <option value="May"> May</option>
                         <option value="June"> June</option>
                         <option value="July"> July</option>
                         <option value="August"> August</option>
                         <option value="September"> September</option>
                         <option value="October"> October</option>
                         <option value="November"> November</option>
                         <option value="December"> December</option>
                     </select>
                 </div>

                <div class="form-group" style="width: 150px">
                    <select name="category" class="form-control" id="categorySelect">
                        @For Each category In Model.Categories
                            @<option value="@category.Id">@category.Name</option>
                        Next
                    </select>
                </div>

                <input name="description" class="form-control" type="text" maxlength="20" placeholder="Description" style="width: 200px" /><br />

                <input name="cost" class="form-control" type="text" maxlength="7" placeholder="$$$" style="width: 80px" /><br />

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
                 <th style="width: 10%">Cost</th>
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

