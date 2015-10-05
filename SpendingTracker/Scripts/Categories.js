function PopulateCategoriesDropdown() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:50873/api/Categories',
        success: function (data) {
            $.each(function () {
                $("#categorySelect").append("<option value='" + this.id + "'>" + this.name + "</option>")
            })
        },
        error: function () {
            alert("Error populating categories dropdown");
        }
    })
}