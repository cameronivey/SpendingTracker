<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/chart.min.js"></script>
    <script src="~/Scripts/Transactions.js"></script>
    <script src="~/Scripts/Category.js"></script>
    <script src="~/Scripts/charts.js"></script>
    <title>@ViewBag.Title - Spending</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <style>
        ul.nav li.dropdown:hover ul.dropdown-menu {
            display: block;
        }
    </style>

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar">aa</span>
                    <span class="icon-bar">aa</span>
                    <span class="icon-bar">aa</span>
                </button>
                @Html.ActionLink("Spending Tracker", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Overview", "Overview", "Transaction")</li>
                    <li>@Html.ActionLink("Transactions", "Index", "Transaction")</li>
                    <li>@Html.ActionLink("Income", "Income", "Transaction")</li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" role="button" aria-haspopup="true" aria-expanded="false" href="/Category/All">Categories</a>
                        <ul class="dropdown-menu"  style="background-color: black;">
                            <li>@Html.ActionLink("Food", "Index", "Category", New With {.CategoryName = "Food"}, New With {.style = "color: White"})</li>
                            <li>@Html.ActionLink("Alcohol / Bars", "Index", "Category", New With {.CategoryName = "AlcoholBars"}, New With {.style = "color: White"})</li>
                            <li>@Html.ActionLink("Entertainment", "Index", "Category", New With {.CategoryName = "Entertainment"}, New With {.style = "color: White"})</li>
                            <li>@Html.ActionLink("Shopping", "Index", "Category", New With {.CategoryName = "Shopping"}, New With {.style = "color: White"})</li>
                            <li>@Html.ActionLink("Needs", "Index", "Category", New With {.CategoryName = "Needs"}, New With {.style = "color: White"})</li>
                            <li>@Html.ActionLink("Other", "Index", "Category", New With {.CategoryName = "Other"}, New With {.style = "color: White"})</li>
                        </ul>
                    </li>
                    <li>@Html.ActionLink("Savings", "Index", "Category")</li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
