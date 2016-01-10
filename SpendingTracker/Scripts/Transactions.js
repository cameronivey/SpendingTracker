$(function () {



})

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

function addTransaction() {
    var addData = {
        year: $("#tYear").val(),
        month: $("#tMonth").val(),
        categoryId: $("#tCategoryId").val(),
        description: $("#tDescription").val(),
        cost: $("#tCost").val()
    }

    $.ajax({
        url: "/Transaction/AddTransaction",
        type: "POST",
        data: addData,
        success: function () {
            window.location = "/Transaction?Month=" + $("#tMonth").val() + "&Year=" + $("#tYear").val() + "&categorySelected=" + getCategoryName($("#tCategoryId").val())
        },
        error: function() {
            alert("add post modal fail")
        }
    });
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

function getCategoryName(id) {
    if (id == 1) {
        return "Food"
    } else if (id == 2) {
        return "AlcoholBars"
    } else if (id == 3) {
        return "Entertainment"
    } else if (id == 4) {
        return "Shopping"
    } else if (id == 5) {
        return "Needs"
    } else {
        return "Other"
    }
}
