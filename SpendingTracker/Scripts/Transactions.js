function selectMonth(month) {
    $('#monthSelect option:contains(' + month + ')').prop({ selected: true });
}

function selectTab(category) {
    var tabName = "#tab_" + category
    $("a[href=" + tabName + "]").tab('show');
}

function getExpenseTransactions() {
    window.location = "/Transaction?Month=" + $("#monthName").val() + "&Year=" + $("#yearNum").val()
}

function getIncomeTransactions() {
    window.location = "/Transaction/Income?Month=" + $("#monthName").val() + "&Year=" + $("#yearNum").val()
}


function deleteTransaction(id) {
    var con = confirm("Are you sure you want to delete this transaction?");
    if (con == true) {
        $.ajax({
            url: "/Transaction/DeleteTransaction/" + id,
            type: "POST",
            success: function () {
                window.location = "/transaction/Addtransaction"
            },
            error: function() {
                alert("delete transaction fail")
            }
        })
    } 
}