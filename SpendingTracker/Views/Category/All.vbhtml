@ModelType AllGraphsViewModel

@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<body onload="getAllCharts()">
    <h2>Details</h2>

    <div class="row">
        <div class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .id = "yearNum", .class = "form-control", .style = "float: left"})
        </div>
    </div>

    <div>
        <h3>Overall</h3>
        <div class="row">
            <div class="col-lg-4">
                <h4>Total Spent</h4>
                <canvas id="totalSpentChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Total Spent Without Needs</h4>
                <canvas id="totalSpentWithoutNeedsChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Net Income</h4>
                <canvas id="netIncomeChart" width="350" height="200"></canvas>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <h4>Income</h4>
                <canvas id="incomeChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Savings</h4>
                <canvas id="savingsChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">

            </div>
        </div>
    </div>

    <hr />

    <div>
        <label>Categories</label>
        <div class="row">
            <div class="col-lg-4">
                <h4>Food</h4>
                <canvas id="foodChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Alcohol / Bars</h4>
                <canvas id="alcoholBarsChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Entertainment</h4>
                <canvas id="entertainmentChart" width="350" height="200"></canvas>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <h4>Shopping</h4>
                <canvas id="shoppingChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Needs</h4>
                <canvas id="needsChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h4>Other</h4>
                <canvas id="otherChart" width="350" height="200"></canvas>
            </div>
        </div>
    </div>
</body>
