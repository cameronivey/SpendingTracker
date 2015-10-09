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
        multiTooltipTemplate: "<%= datasetLabel %> - <%= value %>"
    }

    var context = $("#incomeChart").get(0).getContext("2d");

    var myIncomeChart = new Chart(context).Line(data, options);
}