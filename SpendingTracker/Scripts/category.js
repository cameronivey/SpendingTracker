$(function () {

    

})

function getAllCharts() {
    getTotalSpentChartData();
    getTotalSpentWithoutNeedsChartData();
    getNetIncomeChartData();
    getIncomeChartData();
    getSavingsChartData();
    getFoodChartData();
    getAlcoholBarsChartData();
    getEntertainmentChartData();
    getShoppingChartData();
    getNeedsChartData();
    getOtherChartData();
}

function changeYear(categoryName) {
    window.location = "/Category?CategoryName=" + categoryName + "&Year=" + $("#yearNum").val()
}

function getTotalSpentChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetTotalSpentChartData/",
        data: "{year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getTotalSpentChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("get total spent chart error")
        }
    })
}

function getTotalSpentWithoutNeedsChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetTotalSpentWithoutNeedsChartData/",
        data: "{year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getTotalSpentWithoutNeedsChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("get total spent without needs chart error")
        }
    })
}

function getNetIncomeChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetNetIncomeChartData/",
        data: "{year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getNetIncomeChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("get net income chart error")
        }
    })
}

function getIncomeChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Income', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getIncomeChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("get income chart error")
        }
    })
}

function getSavingsChartData() {
    $.ajax({
        type: "POST",
        url: "/Savings/GetSavingsChartData/",
        data: "{year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getSavingsChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}

function getFoodChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Food', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getFoodChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}

function getAlcoholBarsChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'AlcoholBars', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getAlcoholBarsChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}


function getEntertainmentChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Entertainment', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getEntertainmentChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}


function getShoppingChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Shopping', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getShoppingChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}


function getNeedsChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Needs', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getNeedsChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}


function getOtherChartData() {
    $.ajax({
        type: "POST",
        url: "/Category/GetChartData/",
        data: "{category: 'Other', year: 2015}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (chartData) {
            getOtherChart(chartData.Labels, chartData.Data)
        },
        error: function () {
            alert("error")
        }
    })
}
