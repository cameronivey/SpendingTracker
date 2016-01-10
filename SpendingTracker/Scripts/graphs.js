function getCategoryChart(labels, data, category) {
    switch (category) {
        case "Food":
            $("#categoryChartDiv").html("<canvas id='foodChart' width='500' height='250'></canvas>")
            getFoodChart(labels, data)
        case "AlcoholBars":
            $("#categoryChartDiv").html("<canvas id='alcoholBarsChart' width='500' height='250'></canvas>")
            getAlcoholBarsChart(labels, data)
        case "Entertainment":
            $("#categoryChartDiv").html("<canvas id='entertainmentChart' width='500' height='250'></canvas>")
            getEntertainmentChart(labels, data)
        case "Shopping":
            $("#categoryChartDiv").html("<canvas id='shoppingChart' width='500' height='250'></canvas>")
            getShoppingChart(labels, data)
        case "Needs":
            $("#categoryChartDiv").html("<canvas id='needsChart' width='500' height='250'></canvas>")
            getNeedsChart(labels, data)
        case "Other":
            $("#categoryChartDiv").html("<canvas id='otherChart' width='500' height='250'></canvas>")
            getOtherChart(labels, data)
    }
}

function getTotalSpentChart(labels, data) {
    var data = getChartData("Total Spent", labels, data)
    var options = getChartOptions();

    var totalSpentContext = $("#totalSpentChart").get(0).getContext("2d");
    var myTotalSpentChart = new Chart(totalSpentContext).Line(data, options);
}

function getTotalSpentWithoutNeedsChart(labels, data) {
    var data = getChartData("Total Spent Without Needs", labels, data)
    var options = getChartOptions();

    var totalSpentWithoutNeedsContext = $("#totalSpentWithoutNeedsChart").get(0).getContext("2d");
    var myTotalSpentWithoutNeedsChart = new Chart(totalSpentWithoutNeedsContext).Line(data, options);
}

function getNetIncomeChart(labels, data) {
    var data = getChartData("Net Income", labels, data)
    var options = getChartOptions();

    var netIncomeContext = $("#netIncomeChart").get(0).getContext("2d");
    var netIncomeChart = new Chart(netIncomeContext).Line(data, options);
}

function getIncomeChart(labels, data) {
    var data = getChartData("Total Income", labels, data)
    var options = getChartOptions()

    var incomeContext = $("#incomeChart").get(0).getContext("2d");
    var myIncomeChart = new Chart(incomeContext).Line(data, options);
}

function getSavingsChart(labels, data) {
    var data = getChartData("Total Savings", labels, data)
    var options = getChartOptions()

    var savingsContext = $("#savingsChart").get(0).getContext("2d");
    var mySavingsChart = new Chart(savingsContext).Line(data, options);
}

function getFoodChart(labels, data) {
    var data = getChartData("Food", labels, data)
    var options = getChartOptions()

    var foodContext = $("#foodChart").get(0).getContext("2d");
    var myFoodChart = new Chart(foodContext).Line(data, options);
}


function getAlcoholBarsChart(labels, data) {
    var data = getChartData("AlcoholBars", labels, data)
    var options = getChartOptions()

    var alcoholBarsContext = $("#alcoholBarsChart").get(0).getContext("2d");
    var myAlcoholBarsChart = new Chart(alcoholBarsContext).Line(data, options);
}


function getEntertainmentChart(labels, data) {
    var data = getChartData("Entertainment", labels, data)
    var options = getChartOptions()

    var entertainmentContext = $("#entertainmentChart").get(0).getContext("2d");
    var myEntertainmentChart = new Chart(entertainmentContext).Line(data, options);
}


function getShoppingChart(labels, data) {
    var data = getChartData("Shopping", labels, data)
    var options = getChartOptions()

    var shoppingContext = $("#shoppingChart").get(0).getContext("2d");
    var myShoppingChart = new Chart(shoppingContext).Line(data, options);
}


function getNeedsChart(labels, data) {
    var data = getChartData("Needs", labels, data)
    var options = getChartOptions()

    var needsContext = $("#needsChart").get(0).getContext("2d");
    var myNeedsChart = new Chart(needsContext).Line(data, options);
}


function getOtherChart(labels, data) {
    var data = getChartData("Other", labels, data)
    var options = getChartOptions()

    var otherContext = $("#otherChart").get(0).getContext("2d");
    var myOtherChart = new Chart(otherContext).Line(data, options);
}

function getChartData(title, labels, data) {
    return {
        labels: labels,
        datasets: [
            {
                label: title,
                fillColor: "rgba(255,0,0,0.3)",
                strokeColor: "rgba(255,0,0,0.3)",
                pointColor: "rgba(255,0,0,0.3)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(255,0,0,0.3)",
                data: data,
            }
        ]
    };
}

function getChartOptions() {
    return {
        scaleLabel: "<%='$' + Number(value)%>",
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>",
        bezierCurve: false
    }
}