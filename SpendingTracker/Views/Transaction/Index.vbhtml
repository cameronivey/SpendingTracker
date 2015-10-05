@ModelType TransactionsViewModel

@Code
    ViewData("Title") = "Transactions"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<body onload="selectMonth('@Model.Month')">
    <h2 class="page-header">Transactions</h2>

    <div class="row">
        <a href="/Transaction/AddTransaction">Add A Transaction</a>

        <div Class="form-group" style="float: left">
            <Label for="yearSelect" style="float: left">Year:</label>
            <select name="year" Class="form-control" id="yearSelect" style="float: left">
                <option value = "2015" > 2015</Option>
                <option value = "2016" > 2016</Option>
            </select>
        </div>

      <div Class="form-group" style="float: left">
            <Label for="monthSelect">Month:</label>
            <select name="month" Class="form-control" id="monthSelect" onchange="changeMonth()">
                <option value = "All" > All</Option>
                <option value = "January" > January</Option>
                <option value = "February" > February</Option>
                <option value = "March" > March</Option>
                <option value = "April" > April</Option>
                <option value = "May" > May</Option>
                <option value = "June" > June</Option>
                <option value = "July" > July</Option>
                <option value = "August" > August</Option>
                <option value = "September"> September</Option>
                <option value = "October" > October</Option>
                <option value = "November" > November</Option>
                <option value = "December" > December</Option>
            </select>
        </div>
  
    </div>

    <div Class="row">
        <div Class="col-lg-2">
            <Table>
                <caption> Food</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Food")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
        <div class="col-lg-2">
            <table>
                <caption>Alcohol/Bars</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Alcohol/Bars")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
        <div class="col-lg-2">
            <table>
                <caption>Entertainment</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Entertainment")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
        <div class="col-lg-2">
            <table>
                <caption>Shopping</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Shopping")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
        <div class="col-lg-2">
            <table>
                <caption>Needs</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Needs")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
        <div class="col-lg-2">
            <table>
                <caption>Other</caption>
                @For Each transaction In Model.Transactions.Where(Function(t) t.Category.Name = "Other")
                    @<tr><td>@transaction.Description, @transaction.Cost</td></tr>
                Next
            </table>
        </div>
    </div>
</body>

