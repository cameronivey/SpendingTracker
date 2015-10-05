function selectMonth(month) {
    $('#monthSelect option:contains(' + month + ')').prop({ selected: true });
}

function changeMonth() {
    window.location.href = "/Transaction/GetMonthTransactions/" + $("#monthSelect").val();
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