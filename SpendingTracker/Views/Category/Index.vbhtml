@ModelType CategoryViewModel

@Code
    ViewData("Title") = "Categories"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<body onload="getCategoryChart(@Model.LabelsJavascriptString, @Model.DataJavascriptString, '@Model.CategoryName')">
    <h2>@Model.CategoryName</h2>

    <div class="row">
        <div class="form-group" style="float: left">
            @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .id = "yearNum", .class = "form-control", .style = "float: left", .onchange = "changeYear('" + Model.CategoryName + "')"})
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <table class="table table-striped">
                @For Each entry As KeyValuePair(Of String, Decimal) In Model.MonthTotals
                    @<tr>
                        <td>@entry.Key</td>
                        <td align="right">@Html.ActionLink("$" + entry.Value.ToString, "Index", "Transaction", New With {.Month = entry.Key, .Year = Model.Year, .CategorySelected = Model.CategoryName}, New With {.style = "strong"})</td>

                    </tr>
                Next
                <tr>
                    <td style="border-top: double"><b>Total:</b></td>
                    <td align="right" style="border: inset; border-top: double">@Model.Total</td>
                </tr>
            </table>
        </div>
        <div class="col-lg-6">
            <div class="col-lg-6">
                <h4 style="text-align: center">@Model.CategoryName @Model.Year</h4>
                <div id="categoryChartDiv"></div>
                @*<canvas id="categoryChart" width="500" height="250"></canvas>*@
            </div>
        </div>
    </div>
</body>

