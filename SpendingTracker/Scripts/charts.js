function getChart(category) {

}


function getAllCharts(labels, totalSpentData, incomeData) {
    //getTotalSpentChart(labels, totalSpentData)
    getIncomeChart(labels, incomeData)
}

function getTotalSpentChart(labels, totalSpentData) {
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Total Spent",
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

    var options = {
        scaleLabel: "<%='$' + Number(value)%>",
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>",
        bezierCurve: false
    }

    var totalSpentContext = $("#totalSpentChart").get(0).getContext("2d");

    var myTotalSpentChart = new Chart(totalSpentContext).Line(data, options);
}

function getIncomeChart(labels, data) {
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Total Income",
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

    var options = {
        scaleLabel: "<%='$' + Number(value)%>",
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>",
        bezierCurve: false
    }

    var incomeContext = $("#incomeChart").get(0).getContext("2d");

    var myIncomeChart = new Chart(incomeContext).Line(data, options);
}

function getSavingsChart(labels, data) {
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Total Savings",
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

    var options = {
        scaleLabel: "<%='$' + Number(value)%>",
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>",
        bezierCurve: false
    }

    var savingsContext = $("#savingsChart").get(0).getContext("2d");

    var mySavingsChart = new Chart(savingsContext).Line(data, options);
}

function getCategoryChart(labels, data, category) {
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Total " + category,
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

    var options = {
        scaleLabel: "<%='$' + Number(value)%>",
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>",
        bezierCurve: false
    }

    var context = $("#categoryChart").get(0).getContext("2d");

    var myCategoryChart = new Chart(context).Line(data, options);
}