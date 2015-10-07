function linkToMonth(month, year) {
    var model = {
        monthName: month,
        yearNum: year
    }
    $.ajax({
        type: 'POST',
        url: '/transaction/income/',
        data: model
    }).done(function () {
        window.location = "addpostsuccess"
    }).fail(function () {
        window.location = "addposterror"
    })
}