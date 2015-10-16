$(function () {
    $.datepicker.setDefaults(
      $.extend($.datepicker.regional[''])
    );
    $('#datepicker').datepicker();
});

function editSavingsTransaction(id) {
    window.location = "/Savings/Edit?id=" + id
}