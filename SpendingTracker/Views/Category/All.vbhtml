@ModelType AllGraphsViewModel

@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<body onload="getAllCharts(@Model.LabelsJsString, @Model.TotalSpent_DataJsString, @Model.Income_DataJsString)">
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
                <h5>Total Spent Without Needs</h5>
            </div>
            <div class="col-lg-4">
                <h5>Net Income</h5>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <h4>Income</h4>
                <canvas id="incomeChart" width="350" height="200"></canvas>
            </div>
            <div class="col-lg-4">
                <h5>Savings</h5>
            </div>
            <div class="col-lg-4">

            </div>
        </div>
    </div>

    <hr />

    <div>
        <label>Categories</label>
        <div class="row">
            <div class="col-lg-4">Food</div>
            <div class="col-lg-4">AlcoholBars</div>
            <div class="col-lg-4">Entertainment</div>
        </div>
        <div class="row">
            <div class="col-lg-4">Shopping</div>
            <div class="col-lg-4">Needs</div>
            <div class="col-lg-4">Other</div>
        </div>
    </div>
</body>
